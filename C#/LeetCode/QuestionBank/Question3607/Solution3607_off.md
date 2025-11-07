### [电网维护](https://leetcode.cn/problems/power-grid-maintenance/solutions/3819897/dian-wang-wei-hu-by-leetcode-solution-d92h/)

根据题意，原问题可以拆分为两个相互独立的子问题：**计算连通块** 和 **维护当前在线电站的最小编号**。

针对这两个子问题，下面将分别给出两种求解方法，可根据需求自由组合使用。

#### 方法一 并查集 $+$ 倒序处理查询

**思路与算法**

**计算连通块**

使用并查集计算连通块，该方法假设读者已经了解和掌握并查集的原理、实现以及路径压缩优化方法。

将存在连通关系的节点合并，随后将每个集合的根节点作为连通分量的句柄，后续可以通过并查集的查询操作快速判断某个节点所属的联通分量。

**维护当前在线电站的最小编号**

考虑倒序处理查询。在倒序处理的视角下，电站的下线操作将变为电站的上线操作。随着电站的上线，我们会发现仅通过不断取 $min$ 更新即可维护在线电站的最小编号。

为了实现倒序查询，首先需要预处理出终态的电站在线状态。此时易注意到：**一个电站有可能被多次下线**，这个电站在第一次下线时就已经离线，后面的操作对它的离线状态没有影响。因此，在倒序处理时，我们不能遇到下线操作就立即上线电站，而是应该检查这是否是该电站第一次下线再做相应处理。

在具体实现中，可以为每个电站 $i$ 统计其下线次数 $offlineCount_i$。在倒序处理查询的过程中，每遇到一次下线操作，就将对应的 $offlineCount_i$ 减一。当某个电站 $s$ 满足 $offlineCount_s=1$ 时，表示这是该电站在正序操作中首次下线的时刻。

**代码**

```C++
class DSU {
public:
    vector<int> parent;
    DSU(int size) {
        parent.resize(size);
        iota(parent.begin(), parent.end(), 0);
    }

    int find(int x) { return parent[x] == x ? x : parent[x] = find(parent[x]); }

    void join(int u, int v) { parent[find(v)] = find(u); }
};

class Solution {
public:
    vector<int> processQueries(int c, vector<vector<int>>& connections,
                               vector<vector<int>>& queries) {
        DSU dsu(c + 1);

        for (auto& p : connections) {
            dsu.join(p[0], p[1]);
        }

        vector<bool> online(c + 1, true);
        vector<int> offlineCounts(c + 1, 0);
        unordered_map<int, int> minimumOnlineStations;

        for (auto& q : queries) {
            int op = q[0], x = q[1];
            if (op == 2) {
                online[x] = false;
                offlineCounts[x]++;
            }
        }

        for (int i = 1; i <= c; i++) {
            int root = dsu.find(i);
            if (!minimumOnlineStations.count(root)) {
                minimumOnlineStations[root] = -1;
            }

            int station = minimumOnlineStations[root];
            if (online[i]) {
                if (station == -1 || station > i) {
                    minimumOnlineStations[root] = i;
                }
            }
        }

        vector<int> ans;

        for (int i = (int)queries.size() - 1; i >= 0; i--) {
            int op = queries[i][0], x = queries[i][1];
            int root = dsu.find(x);
            int station = minimumOnlineStations[root];

            if (op == 1) {
                if (online[x]) {
                    ans.push_back(x);
                } else {
                    ans.push_back(station);
                }
            }

            if (op == 2) {
                if (offlineCounts[x] > 1) {
                    offlineCounts[x]--;
                } else {
                    online[x] = true;
                    if (station == -1 || station > x) {
                        minimumOnlineStations[root] = x;
                    }
                }
            }
        }

        reverse(ans.begin(), ans.end());
        return ans;
    }
};
```

```JavaScript
class DSU {
    constructor(size) {
        this.size = size;
        this.parent = Array.from({ length: size }).map((_, i) => i);
    }

    join(u, v) {
        this.parent[this.find(v)] = this.find(u);
    }

    find(x) {
        return this.parent[x] === x ? x : (this.parent[x] = this.find(this.parent[x]));
    }
}

var processQueries = function (c, connections, queries) {
    const dsu = new DSU(c + 1);

    connections.forEach(([u, v]) => {
        dsu.join(u, v);
    });

    const online = Array.from({ length: c + 1 }).fill(true);
    const offlineCounts = Array.from({ length: c + 1 }).fill(0);
    const minimumOnlineStations = new Map();

    for (const [op, x] of queries) {
        if (op === 2) {
            online[x] = false;
            offlineCounts[x] += 1;
        }
    }

    for (let i = 1; i <= c; i++) {
        const root = dsu.find(i);
        if (!minimumOnlineStations.has(root)) {
            minimumOnlineStations.set(root, -1);
        }

        const station = minimumOnlineStations.get(root);
        if (online[i] === true) {
            if (station === -1 || station > i) {
                minimumOnlineStations.set(root, i);
            }
        }
    }

    const ans = [];

    for (const [op, x] of queries.reverse()) {
        const root = dsu.find(x);
        const station = minimumOnlineStations.get(root);

        if (op === 1) {
            if (online[x]) {
                ans.push(x);
            } else {
                ans.push(station);
            }
        }

        if (op === 2) {
            if (offlineCounts[x] > 1) {
                offlineCounts[x] -= 1;
            } else {
                online[x] = true;
                if (station === -1 || station > x) {
                    minimumOnlineStations.set(root, x);
                }
            }
        }
    }

    return ans.reverse();
};
```

```TypeScript
class DSU {
    parent: number[];

    constructor(public size: number) {
        this.parent = Array.from({ length: size }).map((_, i) => i);
    }

    join(u: number, v: number) {
        this.parent[this.find(v)] = this.find(u);
    }

    find(x: number) {
        return this.parent[x] === x ? x : (this.parent[x] = this.find(this.parent[x]));
    }
}

function processQueries(c: number, connections: number[][], queries: number[][]): number[] {
    const dsu = new DSU(c + 1);

    connections.forEach(([u, v]) => {
        dsu.join(u, v);
    });

    const online = Array.from<boolean>({ length: c + 1 }).fill(true);
    const offlineCounts = Array.from<number>({ length: c + 1 }).fill(0);
    const minimumOnlineStations = new Map<number, number>();

    for (const [op, x] of queries) {
        if (op === 2) {
            online[x] = false;
            offlineCounts[x] += 1;
        }
    }

    for (let i = 1; i <= c; i++) {
        const root = dsu.find(i);
        if (!minimumOnlineStations.has(root)) {
            minimumOnlineStations.set(root, -1);
        }

        const station = minimumOnlineStations.get(root)!;
        if (online[i] === true) {
            if (station === -1 || station > i) {
                minimumOnlineStations.set(root, i);
            }
        }
    }

    const ans: number[] = [];

    for (const [op, x] of queries.reverse()) {
        const root = dsu.find(x);
        const station = minimumOnlineStations.get(root)!;

        if (op === 1) {
            if (online[x]) {
                ans.push(x);
            } else {
                ans.push(station);
            }
        }

        if (op === 2) {
            if (offlineCounts[x] > 1) {
                offlineCounts[x] -= 1;
            } else {
                online[x] = true;
                if (station === -1 || station > x) {
                    minimumOnlineStations.set(root, x);
                }
            }
        }
    }

    return ans.reverse();
};
```

```Java
class DSU {
    private int[] parent;

    public DSU(int size) {
        parent = new int[size];
        for (int i = 0; i < size; i++) {
            parent[i] = i;
        }
    }

    public int find(int x) {
        return parent[x] == x ? x : (parent[x] = find(parent[x]));
    }

    public void join(int u, int v) {
        parent[find(v)] = find(u);
    }
}

class Solution {
    public int[] processQueries(int c, int[][] connections, int[][] queries) {
        DSU dsu = new DSU(c + 1);

        for (int[] p : connections) {
            dsu.join(p[0], p[1]);
        }

        boolean[] online = new boolean[c + 1];
        int[] offlineCounts = new int[c + 1];
        Arrays.fill(online, true);
        Map<Integer, Integer> minimumOnlineStations = new HashMap<>();
        for (int[] q : queries) {
            int op = q[0], x = q[1];
            if (op == 2) {
                online[x] = false;
                offlineCounts[x]++;
            }
        }

        for (int i = 1; i <= c; i++) {
            int root = dsu.find(i);
            if (!minimumOnlineStations.containsKey(root)) {
                minimumOnlineStations.put(root, -1);
            }

            int station = minimumOnlineStations.get(root);
            if (online[i]) {
                if (station == -1 || station > i) {
                    minimumOnlineStations.put(root, i);
                }
            }
        }

        List<Integer> ans = new ArrayList<>();
        for (int i = queries.length - 1; i >= 0; i--) {
            int op = queries[i][0], x = queries[i][1];
            int root = dsu.find(x);
            int station = minimumOnlineStations.get(root);

            if (op == 1) {
                if (online[x]) {
                    ans.add(x);
                } else {
                    ans.add(station);
                }
            }

            if (op == 2) {
                if (offlineCounts[x] > 1) {
                    offlineCounts[x]--;
                } else {
                    online[x] = true;
                    if (station == -1 || station > x) {
                        minimumOnlineStations.put(root, x);
                    }
                }
            }
        }

        Collections.reverse(ans);
        return ans.stream().mapToInt(Integer::intValue).toArray();
    }
}
```

```CSharp
public class DSU {
    private int[] parent;

    public DSU(int size) {
        parent = new int[size];
        for (int i = 0; i < size; i++) {
            parent[i] = i;
        }
    }

    public int Find(int x) {
        return parent[x] == x ? x : (parent[x] = Find(parent[x]));
    }

    public void Join(int u, int v) {
        parent[Find(v)] = Find(u);
    }
}

public class Solution {
    public int[] ProcessQueries(int c, int[][] connections, int[][] queries) {
        DSU dsu = new DSU(c + 1);

        foreach (var p in connections) {
            dsu.Join(p[0], p[1]);
        }

        bool[] online = new bool[c + 1];
        int[] offlineCounts = new int[c + 1];
        Array.Fill(online, true);

        Dictionary<int, int> minimumOnlineStations = new Dictionary<int, int>();
        foreach (var q in queries) {
            int op = q[0], x = q[1];
            if (op == 2) {
                online[x] = false;
                offlineCounts[x]++;
            }
        }

        for (int i = 1; i <= c; i++) {
            int root = dsu.Find(i);
            if (!minimumOnlineStations.ContainsKey(root)) {
                minimumOnlineStations[root] = -1;
            }

            int station = minimumOnlineStations[root];
            if (online[i]) {
                if (station == -1 || station > i) {
                    minimumOnlineStations[root] = i;
                }
            }
        }

        List<int> ans = new List<int>();
        for (int i = queries.Length - 1; i >= 0; i--) {
            int op = queries[i][0], x = queries[i][1];
            int root = dsu.Find(x);
            int station = minimumOnlineStations[root];

            if (op == 1) {
                if (online[x]) {
                    ans.Add(x);
                } else {
                    ans.Add(station);
                }
            }

            if (op == 2) {
                if (offlineCounts[x] > 1) {
                    offlineCounts[x]--;
                } else {
                    online[x] = true;
                    if (station == -1 || station > x) {
                        minimumOnlineStations[root] = x;
                    }
                }
            }
        }

        ans.Reverse();
        return ans.ToArray();
    }
}
```

```Go
type DSU struct {
    parent []int
}

func NewDSU(size int) *DSU {
    parent := make([]int, size)
    for i := range parent {
        parent[i] = i
    }
    return &DSU{parent: parent}
}

func (this *DSU) Find(x int) int {
    if this.parent[x] == x {
        return x
    }
    this.parent[x] = this.Find(this.parent[x])
    return this.parent[x]
}

func (this *DSU) Join(u, v int) {
    this.parent[this.Find(v)] = this.Find(u)
}

func processQueries(c int, connections [][]int, queries [][]int) []int {
    dsu := NewDSU(c + 1)

    for _, p := range connections {
        dsu.Join(p[0], p[1])
    }
    online := make([]bool, c+1)
    offlineCounts := make([]int, c+1)
    for i := range online {
        online[i] = true
    }

    minimumOnlineStations := make(map[int]int)
    for _, q := range queries {
        op, x := q[0], q[1]
        if op == 2 {
            online[x] = false
            offlineCounts[x]++
        }
    }

    for i := 1; i <= c; i++ {
        root := dsu.Find(i)
        if _, exists := minimumOnlineStations[root]; !exists {
            minimumOnlineStations[root] = -1
        }
        station := minimumOnlineStations[root]
        if online[i] {
            if station == -1 || station > i {
                minimumOnlineStations[root] = i
            }
        }
    }

    ans := []int{}
    for i := len(queries) - 1; i >= 0; i-- {
        op, x := queries[i][0], queries[i][1]
        root := dsu.Find(x)
        station := minimumOnlineStations[root]
        if op == 1 {
            if online[x] {
                ans = append(ans, x)
            } else {
                ans = append(ans, station)
            }
        }

        if op == 2 {
            if offlineCounts[x] > 1 {
                offlineCounts[x]--
            } else {
                online[x] = true
                if station == -1 || station > x {
                    minimumOnlineStations[root] = x
                }
            }
        }
    }

    for i, j := 0, len(ans)-1; i < j; i, j = i + 1, j - 1 {
        ans[i], ans[j] = ans[j], ans[i]
    }

    return ans
}
```

```Python
class DSU:
    def __init__(self, size):
        self.parent = list(range(size))

    def find(self, x):
        if self.parent[x] != x:
            self.parent[x] = self.find(self.parent[x])
        return self.parent[x]

    def join(self, u, v):
        self.parent[self.find(v)] = self.find(u)

class Solution:
    def processQueries(self, c: int, connections: List[List[int]], queries: List[List[int]]) -> List[int]:
        dsu = DSU(c + 1)
        for p in connections:
            dsu.join(p[0], p[1])

        online = [True] * (c + 1)
        offline_counts = [0] * (c + 1)
        minimum_online_stations = {}

        for q in queries:
            op, x = q[0], q[1]
            if op == 2:
                online[x] = False
                offline_counts[x] += 1

        for i in range(1, c + 1):
            root = dsu.find(i)
            if root not in minimum_online_stations:
                minimum_online_stations[root] = -1

            station = minimum_online_stations[root]
            if online[i]:
                if station == -1 or station > i:
                    minimum_online_stations[root] = i

        ans = []
        for i in range(len(queries) - 1, -1, -1):
            op, x = queries[i][0], queries[i][1]
            root = dsu.find(x)
            station = minimum_online_stations[root]

            if op == 1:
                if online[x]:
                    ans.append(x)
                else:
                    ans.append(station)

            if op == 2:
                if offline_counts[x] > 1:
                    offline_counts[x] -= 1
                else:
                    online[x] = True
                    if station == -1 or station > x:
                        minimum_online_stations[root] = x

        return ans[::-1]
```

```C
typedef struct {
    int* parent;
    int size;
} DSU;

DSU* dsuCreate(int size) {
    DSU* obj = (DSU*)malloc(sizeof(DSU));
    obj->size = size;
    obj->parent = (int*)malloc(size * sizeof(int));
    for (int i = 0; i < size; i++) {
        obj->parent[i] = i;
    }
    return obj;
}

int dsuFind(DSU* obj, int x) {
    if (obj->parent[x] != x) {
        obj->parent[x] = dsuFind(obj, obj->parent[x]);
    }
    return obj->parent[x];
}

void dsuJoin(DSU* obj, int u, int v) {
    obj->parent[dsuFind(obj, v)] = dsuFind(obj, u);
}

void dsuFree(DSU* obj) {
    free(obj->parent);
    free(obj);
}

typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

int* processQueries(int c, int** connections, int connectionsSize, int* connectionsColSize,
                   int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    DSU* dsu = dsuCreate(c + 1);
    for (int i = 0; i < connectionsSize; i++) {
        dsuJoin(dsu, connections[i][0], connections[i][1]);
    }

    bool* online = (bool*)malloc((c + 1) * sizeof(bool));
    int* offlineCounts = (int*)calloc(c + 1, sizeof(int));
    for (int i = 0; i <= c; i++) {
        online[i] = true;
    }

    HashItem *minimumOnlineStations = NULL;
    for (int i = 0; i < queriesSize; i++) {
        int op = queries[i][0];
        int x = queries[i][1];
        if (op == 2) {
            online[x] = false;
            offlineCounts[x]++;
        }
    }

    for (int i = 1; i <= c; i++) {
        int root = dsuFind(dsu, i);
        if (!hashFindItem(&minimumOnlineStations, root)) {
            hashAddItem(&minimumOnlineStations, root, -1);
        }
        int station = hashGetItem(&minimumOnlineStations, root, -1);
        if (online[i]) {
            if (station == -1 || station > i) {
                hashSetItem(&minimumOnlineStations, root, i);
            }
        }
    }

    int* ans = (int*)malloc(queriesSize * sizeof(int));
    int ansSize = 0;
    for (int i = queriesSize - 1; i >= 0; i--) {
        int op = queries[i][0];
        int x = queries[i][1];
        int root = dsuFind(dsu, x);
        int station = hashGetItem(&minimumOnlineStations, root, -1);

        if (op == 1) {
            if (online[x]) {
                ans[ansSize++] = x;
            } else {
                ans[ansSize++] = station;
            }
        }

        if (op == 2) {
            if (offlineCounts[x] > 1) {
                offlineCounts[x]--;
            } else {
                online[x] = true;
                if (station == -1 || station > x) {
                    hashSetItem(&minimumOnlineStations, root, x);
                }
            }
        }
    }

    for (int i = 0, j = ansSize - 1; i < j; i++, j--) {
        int temp = ans[i];
        ans[i] = ans[j];
        ans[j] = temp;
    }

    *returnSize = ansSize;
    dsuFree(dsu);
    free(online);
    free(offlineCounts);
    hashFree(&minimumOnlineStations);

    return ans;
}
```

```Rust
use std::collections::HashMap;

struct DSU {
    parent: Vec<usize>,
}

impl DSU {
    fn new(size: usize) -> Self {
        let mut parent = vec![0; size];
        for i in 0..size {
            parent[i] = i;
        }
        Self { parent }
    }

    fn find(&mut self, x: usize) -> usize {
        if self.parent[x] != x {
            self.parent[x] = self.find(self.parent[x]);
        }
        self.parent[x]
    }

    fn join(&mut self, u: usize, v: usize) {
        let root_u = self.find(u);
        let root_v = self.find(v);
        if root_u != root_v {
            self.parent[root_v] = root_u;
        }
    }
}

impl Solution {
    pub fn process_queries(c: i32, connections: Vec<Vec<i32>>, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let c = c as usize;
        let mut dsu = DSU::new(c + 1);

        for p in connections {
            dsu.join(p[0] as usize, p[1] as usize);
        }

        let mut online = vec![true; c + 1];
        let mut offline_counts = vec![0; c + 1];
        let mut minimum_online_stations: HashMap<usize, i32> = HashMap::new();

        for q in &queries {
            let op = q[0];
            let x = q[1] as usize;
            if op == 2 {
                online[x] = false;
                offline_counts[x] += 1;
            }
        }

        for i in 1..=c {
            let root = dsu.find(i);
            if !minimum_online_stations.contains_key(&root) {
                minimum_online_stations.insert(root, -1);
            }

            let station = *minimum_online_stations.get(&root).unwrap();
            if online[i] {
                if station == -1 || station > i as i32 {
                    minimum_online_stations.insert(root, i as i32);
                }
            }
        }

        let mut ans = Vec::new();

        for i in (0..queries.len()).rev() {
            let op = queries[i][0];
            let x = queries[i][1] as usize;
            let root = dsu.find(x);
            let station = *minimum_online_stations.get(&root).unwrap();

            if op == 1 {
                if online[x] {
                    ans.push(x as i32);
                } else {
                    ans.push(station);
                }
            }

            if op == 2 {
                if offline_counts[x] > 1 {
                    offline_counts[x] -= 1;
                } else {
                    online[x] = true;
                    if station == -1 || station > x as i32 {
                        minimum_online_stations.insert(root, x as i32);
                    }
                }
            }
        }

        ans.reverse();
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O((m+c+q)\times$ α(c))。其中 $m$ 是 $connections$ 的长度，即图的边数；$q$ 是 $queries$ 的长度；α 是逆阿克曼函数。假设并查集的实现使用了路径压缩，则使用并查集计算连通块需要 $O(m\times$ α(c))，预处理每个连通分量的在线站点的最小编号需要 $O(c\times$ α(c))，最后反向遍历查询计算答案需要 $O(q\times$ α(c))。
- 空间复杂度：$O(c)$。并查集、online、offlineCount_s 和 $minimumOnlineStations$ 均需要 $O(c)$ 的空间。

#### 方法二 $DFS/BFS +$ 优先队列

**思路与算法**

**计算连通块**

根据题目信息建图，然后使用 $DFS$（深度优先搜索）或 $BFS$（广度优先搜索）计算连通块。

具体做法为：通过外部循环遍历所有**不属于任何一个连通分量的节点**作为新连通分量的入口节点。所有能通过该入口节点遍历到的节点同属于一个连通块，在图上维护该信息即可。

**维护当前在线电站的最小编号**

容易想到，可以使用优先队列（小根堆）来维护连通块内的在线电站的编号。然而，电站下线时需要进行堆上的元素删除操作，该操作较为麻烦。一种解决方案是使用惰性删除的技巧，将元素的删除统一到弹出堆顶的操作上。

在图上对电站维护一个 $offline$ 属性。若需要使某个电站下线，先不处理优先队列，而仅仅更改电站的 $offline$ 属性，直到遇到查询操作为止。此时，先检查所查电站的 $offline$ 属性，若在线则直接作为答案；否则，弹出对应的优先队列的堆顶元素，直到优先队列为空或者堆顶元素的 $offline$ 属性为假，此时堆顶元素即为所求。

**代码**

```C++
class Vertex {
public:
    int vertexId;
    bool offline = false;
    int powerGridId = -1;

    Vertex() {}
    Vertex(int id) : vertexId(id) {}
};

using PowerGrid = priority_queue<int, vector<int>, greater<int>>;
using Graph = vector<vector<int>>;

class Solution {
private:
    vector<Vertex> vertices = vector<Vertex>();

    void traverse(Vertex& u, int powerGridId, PowerGrid& powerGrid,
                  Graph& graph) {
        u.powerGridId = powerGridId;
        powerGrid.push(u.vertexId);
        for (int vid : graph[u.vertexId]) {
            Vertex& v = vertices[vid];
            if (v.powerGridId == -1)
                traverse(v, powerGridId, powerGrid, graph);
        }
    }

public:
    vector<int> processQueries(int c, vector<vector<int>>& connections,
                               vector<vector<int>>& queries) {
        Graph graph(c + 1);
        vertices.resize(c + 1);

        for (int i = 1; i <= c; i++) {
            vertices[i] = Vertex(i);
        }

        for (auto& conn : connections) {
            graph[conn.at(0)].push_back(conn.at(1));
            graph[conn.at(1)].push_back(conn.at(0));
        }

        vector<PowerGrid> powerGrids;

        for (int i = 1, powerGridId = 0; i <= c; i++) {
            auto& v = vertices[i];
            if (v.powerGridId == -1) {
                PowerGrid powerGrid;
                traverse(v, powerGridId, powerGrid, graph);
                powerGrids.push_back(powerGrid);
                powerGridId++;
            }
        }

        vector<int> ans;
        for (auto& q : queries) {
            int op = q.at(0), x = q.at(1);
            if (op == 1) {
                if (!vertices[x].offline) {
                    ans.push_back(x);
                } else {
                    auto& powerGrid = powerGrids[vertices[x].powerGridId];
                    while (!powerGrid.empty() &&
                           vertices[powerGrid.top()].offline) {
                        powerGrid.pop();
                    }
                    ans.push_back(!powerGrid.empty() ? powerGrid.top() : -1);
                }
            } else if (op == 2) {
                vertices[x].offline = true;
            }
        }
        return ans;
    }
};
```

```JavaScript
var processQueries = function (c, connections, queries) {
    const graph = Array.from({ length: c + 1 }, () => []);
    const vertices = Array.from({ length: c + 1 });

    for (let i = 0; i < c; i++) {
        vertices[i + 1] = {
            offline: false,
            powerGridId: -1,
            vertexId: i + 1,
        };
    }

    connections.forEach(([u, v]) => {
        graph[u].push(v);
        graph[v].push(u);
    });

    const powerGrids = new Array();

    for (let i = 1, powerGridId = 0; i <= c; i++) {
        if (vertices[i].powerGridId === -1) {
            const powerGrid = new MinPriorityQueue();

            const traverse = (u) => {
                u.powerGridId = powerGridId;

                powerGrid.enqueue(u.vertexId);

                for (const v of graph[u.vertexId].map(i => vertices[i])) {
                    if (v.powerGridId === -1) {
                        traverse(v);
                    }
                }
            };

            traverse(vertices[i]);
            powerGrids.push(powerGrid);
            powerGridId += 1;
        }
    }

    const ans = [];

    for (const [op, x] of queries) {
        if (op === 1) {
            if (vertices[x].offline === false) {
                ans.push(x);
            } else {
                const powerGrid = powerGrids[vertices[x].powerGridId];
                while (
                    powerGrid.front() !== null &&
                    vertices[powerGrid.front()].offline === true
                ) {
                    powerGrid.dequeue();
                }

                ans.push(powerGrid.front() !== null ? powerGrid.front() : -1);
            }
        } else if (op === 2) {
            vertices[x].offline = true;
        }
    }

    return ans;
};
```

```TypeScript
import { Graph } from '@datastructures-js/graph';

interface Vertex {
    offline: boolean,
    powerGridId: number,
    vertexId: number
}

function processQueries(c: number, connections: number[][], queries: number[][]): number[] {
    const graph = new Graph<number, Vertex>();

    for (let i = 0; i < c; i++) {
        graph.addVertex(i + 1, {
            offline: false,
            powerGridId: -1,
            vertexId: i + 1
        });
    }

    connections.forEach(([u, v]) => {
        graph.addEdge(u, v);
    });

    const getv = graph.getVertexValue.bind(graph);
    const powerGrids = new Array<MinPriorityQueue<number>>();

    for (let i = 1, powerGridId = 0; i <= c; i++) {
        const v = getv(i);

        if (v.powerGridId === -1) {
            const powerGrid = new MinPriorityQueue<number>();

            const traverse = (u: Vertex) => {
                u.powerGridId = powerGridId;

                powerGrid.enqueue(u.vertexId);

                for (const v of graph.getConnectedVertices(u.vertexId).map(getv)) {
                    if (v.powerGridId === -1) {
                        traverse(v);
                    }
                }
            }

            traverse(v);
            powerGrids.push(powerGrid);
            powerGridId += 1;
        }
    }

    const ans: number[] = [];

    for (const [op, x] of queries) {
        if (op === 1) {
            if (getv(x).offline === false) {
                ans.push(x);
            } else {
                const powerGrid = powerGrids[getv(x).powerGridId];
                while (powerGrid.front() !== null && getv(powerGrid.front()).offline === true) {
                    powerGrid.dequeue();
                }

                ans.push(powerGrid.front() !== null ? powerGrid.front() : -1)
            }
        } else if (op === 2) {
            getv(x).offline = true;
        }
    }

    return ans;
};
```

```Java
class Vertex {
    public int vertexId;
    public boolean offline = false;
    public int powerGridId = -1;
    public Vertex() {}

    public Vertex(int id) {
        this.vertexId = id;
    }
}

class Solution {
    private List<Vertex> vertices = new ArrayList<>();

    private void traverse(Vertex u, int powerGridId, PriorityQueue<Integer> powerGrid,
                         List<List<Integer>> graph) {
        u.powerGridId = powerGridId;
        powerGrid.offer(u.vertexId);
        for (int vid : graph.get(u.vertexId)) {
            Vertex v = vertices.get(vid);
            if (v.powerGridId == -1) {
                traverse(v, powerGridId, powerGrid, graph);
            }
        }
    }

    public int[] processQueries(int c, int[][] connections, int[][] queries) {
        List<List<Integer>> graph = new ArrayList<>();
        for (int i = 0; i <= c; i++) {
            graph.add(new ArrayList<>());
            vertices.add(new Vertex(i));
        }

        for (int[] conn : connections) {
            int u = conn[0];
            int v = conn[1];
            graph.get(u).add(v);
            graph.get(v).add(u);
        }

        List<PriorityQueue<Integer>> powerGrids = new ArrayList<>();

        for (int i = 1, powerGridId = 0; i <= c; i++) {
            Vertex v = vertices.get(i);
            if (v.powerGridId == -1) {
                PriorityQueue<Integer> powerGrid = new PriorityQueue<>();
                traverse(v, powerGridId, powerGrid, graph);
                powerGrids.add(powerGrid);
                powerGridId++;
            }
        }

        List<Integer> ans = new ArrayList<>();
        for (int[] q : queries) {
            int op = q[0];
            int x = q[1];
            if (op == 1) {
                if (!vertices.get(x).offline) {
                    ans.add(x);
                } else {
                    PriorityQueue<Integer> powerGrid = powerGrids.get(vertices.get(x).powerGridId);
                    while (!powerGrid.isEmpty() && vertices.get(powerGrid.peek()).offline) {
                        powerGrid.poll();
                    }
                    ans.add(!powerGrid.isEmpty() ? powerGrid.peek() : -1);
                }
            } else if (op == 2) {
                vertices.get(x).offline = true;
            }
        }

        return ans.stream().mapToInt(Integer::intValue).toArray();
    }
}
```

```CSharp
public class Vertex {
    public int vertexId;
    public bool offline = false;
    public int powerGridId = -1;

    public Vertex() {}

    public Vertex(int id) {
        this.vertexId = id;
    }
}

public class Solution {
    private List<Vertex> vertices = new List<Vertex>();

    private void Traverse(Vertex u, int powerGridId, PriorityQueue<int, int> powerGrid,
                         List<List<int>> graph) {
        u.powerGridId = powerGridId;
        powerGrid.Enqueue(u.vertexId, u.vertexId);
        foreach (int vid in graph[u.vertexId]) {
            Vertex v = vertices[vid];
            if (v.powerGridId == -1) {
                Traverse(v, powerGridId, powerGrid, graph);
            }
        }
    }

    public int[] ProcessQueries(int c, int[][] connections, int[][] queries) {
        List<List<int>> graph = new List<List<int>>();
        for (int i = 0; i <= c; i++) {
            graph.Add(new List<int>());
            vertices.Add(new Vertex(i));
        }

        foreach (var conn in connections) {
            int u = conn[0];
            int v = conn[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        List<PriorityQueue<int, int>> powerGrids = new List<PriorityQueue<int, int>>();
        for (int i = 1, powerGridId = 0; i <= c; i++) {
            Vertex v = vertices[i];
            if (v.powerGridId == -1) {
                var powerGrid = new PriorityQueue<int, int>();
                Traverse(v, powerGridId, powerGrid, graph);
                powerGrids.Add(powerGrid);
                powerGridId++;
            }
        }

        List<int> ans = new List<int>();
        foreach (var q in queries) {
            int op = q[0];
            int x = q[1];
            if (op == 1) {
                if (!vertices[x].offline) {
                    ans.Add(x);
                } else {
                    var powerGrid = powerGrids[vertices[x].powerGridId];
                    while (powerGrid.Count > 0 && vertices[powerGrid.Peek()].offline) {
                        powerGrid.Dequeue();
                    }
                    ans.Add(powerGrid.Count > 0 ? powerGrid.Peek() : -1);
                }
            } else if (op == 2) {
                vertices[x].offline = true;
            }
        }
        return ans.ToArray();
    }
}
```

```Go
func processQueries(c int, connections [][]int, queries [][]int) []int {
	graph := make([][]int, c + 1)
	vertices := make([]Vertex, c + 1)

	for i := 0; i <= c; i++ {
		graph[i] = make([]int, 0)
		vertices[i] = Vertex{vertexId: i, powerGridId: -1}
	}

	for _, conn := range connections {
		u, v := conn[0], conn[1]
		graph[u] = append(graph[u], v)
		graph[v] = append(graph[v], u)
	}
	powerGrids := make([]*IntHeap, 0)
	for i, powerGridId := 1, 0; i <= c; i++ {
		v := &vertices[i]
		if v.powerGridId == -1 {
			powerGrid := &IntHeap{}
			heap.Init(powerGrid)
			traverse(v, powerGridId, powerGrid, graph, vertices)
			powerGrids = append(powerGrids, powerGrid)
			powerGridId++
		}
	}

	ans := make([]int, 0)
	for _, q := range queries {
		op, x := q[0], q[1]
		if op == 1 {
			if !vertices[x].offline {
				ans = append(ans, x)
			} else {
				powerGrid := powerGrids[vertices[x].powerGridId]
				for powerGrid.Len() > 0 && vertices[(*powerGrid)[0]].offline {
					heap.Pop(powerGrid)
				}
				if powerGrid.Len() > 0 {
					ans = append(ans, (*powerGrid)[0])
				} else {
					ans = append(ans, -1)
				}
			}
		} else if op == 2 {
			vertices[x].offline = true
		}
	}

	return ans
}

func traverse(u *Vertex, powerGridId int, powerGrid *IntHeap, graph [][]int, vertices []Vertex) {
	u.powerGridId = powerGridId
	heap.Push(powerGrid, u.vertexId)
	for _, vid := range graph[u.vertexId] {
		v := &vertices[vid]
		if v.powerGridId == -1 {
			traverse(v, powerGridId, powerGrid, graph, vertices)
		}
	}
}

type Vertex struct {
	vertexId    int
	offline     bool
	powerGridId int
}

type IntHeap []int

func (h IntHeap) Len() int           { return len(h) }
func (h IntHeap) Less(i, j int) bool { return h[i] < h[j] }
func (h IntHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }

func (h *IntHeap) Push(x interface{}) {
	*h = append(*h, x.(int))
}

func (h *IntHeap) Pop() interface{} {
	old := *h
	n := len(old)
	x := old[n-1]
	*h = old[0 : n-1]
	return x
}
```

```Python
class Vertex:
    def __init__(self, vertex_id: int = -1):
        self.vertex_id = vertex_id
        self.offline = False
        self.power_grid_id = -1

class Solution:
    def __init__(self):
        self.vertices = []

    def traverse(self, u: Vertex, power_grid_id: int, power_grid: List[int], graph: List[List[int]]):
        u.power_grid_id = power_grid_id
        heapq.heappush(power_grid, u.vertex_id)
        for vid in graph[u.vertex_id]:
            v = self.vertices[vid]
            if v.power_grid_id == -1:
                self.traverse(v, power_grid_id, power_grid, graph)

    def processQueries(self, c: int, connections: List[List[int]], queries: List[List[int]]) -> List[int]:
        graph = [[] for _ in range(c + 1)]
        self.vertices = [Vertex(i) for i in range(c + 1)]

        for conn in connections:
            u, v = conn
            graph[u].append(v)
            graph[v].append(u)

        power_grids = []
        power_grid_id = 0

        for i in range(1, c + 1):
            v = self.vertices[i]
            if v.power_grid_id == -1:
                power_grid = []
                self.traverse(v, power_grid_id, power_grid, graph)
                power_grids.append(power_grid)
                power_grid_id += 1

        ans = []
        for q in queries:
            op, x = q
            if op == 1:
                if not self.vertices[x].offline:
                    ans.append(x)
                else:
                    power_grid = power_grids[self.vertices[x].power_grid_id]
                    while power_grid and self.vertices[power_grid[0]].offline:
                        heapq.heappop(power_grid)
                    ans.append(power_grid[0] if power_grid else -1)
            elif op == 2:
                self.vertices[x].offline = True

        return ans
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

#[derive(Clone)]
struct Vertex {
    vertex_id: i32,
    offline: bool,
    power_grid_id: i32,
}

impl Vertex {
    fn new(vertex_id: i32) -> Self {
        Self {
            vertex_id,
            offline: false,
            power_grid_id: -1,
        }
    }
}

impl Solution {
    fn traverse(u_idx: usize, power_grid_id: i32, power_grid: &mut BinaryHeap<Reverse<i32>>, graph: &Vec<Vec<i32>>, vertices: &mut Vec<Vertex>) {
        vertices[u_idx].power_grid_id = power_grid_id;
        power_grid.push(Reverse(vertices[u_idx].vertex_id));

        for &vid in &graph[u_idx] {
            let v_idx = vid as usize;
            if vertices[v_idx].power_grid_id == -1 {
                Self::traverse(v_idx, power_grid_id, power_grid, graph, vertices);
            }
        }
    }

    pub fn process_queries(c: i32, connections: Vec<Vec<i32>>, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let c_usize = c as usize;
        let mut graph = vec![Vec::new(); c_usize + 1];
        let mut vertices:Vec<Vertex>  = (0..=c_usize).map(|i| Vertex::new(i as i32)).collect();

        for conn in connections {
            let u = conn[0] as usize;
            let v = conn[1] as usize;
            graph[u].push(v as i32);
            graph[v].push(u as i32);
        }

        let mut power_grids: Vec<BinaryHeap<Reverse<i32>>> = Vec::new();
        let mut power_grid_id = 0;

        for i in 1..=c_usize {
            if vertices[i].power_grid_id == -1 {
                let mut power_grid = BinaryHeap::new();
                Self::traverse(i, power_grid_id, &mut power_grid, &graph, &mut vertices);
                power_grids.push(power_grid);
                power_grid_id += 1;
            }
        }

        let mut ans = Vec::new();
        for q in queries {
            let op = q[0];
            let x = q[1] as usize;

            match op {
                1 => {
                    if !vertices[x].offline {
                        ans.push(vertices[x].vertex_id);
                    } else {
                        let power_grid = &mut power_grids[vertices[x].power_grid_id as usize];
                        while let Some(&Reverse(top)) = power_grid.peek() {
                            if vertices[top as usize].offline {
                                power_grid.pop();
                            } else {
                                break;
                            }
                        }
                        ans.push(power_grid.peek().map_or(-1, |&Reverse(val)| val));
                    }
                }
                2 => {
                    vertices[x].offline = true;
                }
                _ => {}
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m+c\log c+q)$。其中 $m$ 是 $connections$ 的长度，即图的边数；$q$ 是 $queries$ 的长度。其中：
    - 建图需要 $O(c+m)$。
    - 以 $DFS$ 遍历为例，遍历本身需要 $O(c+m)$，将顶点压入优先队列需要 $O(c\log c)$，遍历过程的总共需要 $O(c\log c+m)$。
    - 每个顶点至多在查询阶段从优先队列中弹出一次，查询过程总共需要 $O(q+c\log c)$。
- 空间复杂度：$O(c+m)$。其中，邻接表存图需要 $O(c+m)$，优先队列 $powerGrids$ 共需要 $O(c)$。
