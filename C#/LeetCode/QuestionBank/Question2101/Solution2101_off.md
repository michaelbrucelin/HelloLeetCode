### [引爆最多的炸弹](https://leetcode.cn/problems/detonate-the-maximum-bombs/solutions/1153683/yin-bao-zui-duo-de-zha-dan-by-leetcode-s-iccp/)

#### 方法一：广度优先搜索

**思路与算法**

为了判断炸弹 $u$ 能否引爆炸弹 $v$，我们需要将两个炸弹之间的距离与炸弹 $u$ 的引爆范围 $r_u$ 进行比较。假设两个炸弹之间横向距离为 $d_x$，纵向距离为 $d_y$，则 $u$ 可以引爆炸弹 $v$ 的 **充要条件**为：

$$r_u \ge \sqrt{d_x^2 + d_y^2}.$$

为了避免开方运算导致的精度问题影响计算结果，我们可以对上式两边取平方，即：

$$r_u^2 \ge d_x^2 + d_y^2.$$

我们可以以炸弹为节点，炸弹之间的引爆关系为边建立一个**有向图**，假设炸弹 $u$ 可以引爆炸弹 $v$，即炸弹 $v$ 在炸弹 $u$ 的引爆范围，那么我们就在有向图中连一条 $u \rightarrow v$ 的有向边。我们遍历所有互不相同的 $u,v$，计算引爆关系，并用邻接表 $edges$ 表示有向图。

随后，我们遍历每个炸弹，计算每个炸弹可以引爆的炸弹数量，并维护这些数量的最大值。一种可行的计算方法是广度优先搜索。具体地，我们用 $cnt$ 表示炸弹爆炸的数量，并用布尔数组 $visited$ 表示每个炸弹是否被遍历到。

我们首先将最初引爆的炸弹对应下标 $i$ 加入队列，并修改 $visited[i]$ 为 $True$，同时将 $cnt$ 置为 $1$。当遍历至下标为 $cidx$ 的炸弹时，我们在 $edges[cidx]$ 枚举它所有可以引爆炸弹的下标 $nidx$，如果该炸弹未被遍历过，则我们将 $nidx$ 加入队列，并修改 $visited[nidx]$ 为 $True$，同时将 $cnt$ 加上 $1$。当广度优先搜索完成后， $cnt$ 即为炸弹 $i$ 可以引爆的炸弹数目。我们维护这些数量的最大值，并返回该最大值作为答案。

**细节**

在判断引爆关系时，$r_u^2$ 或 $d_x^2 + d_y^2$ 的取值很可能超过 $32$ 位有符号整数的上界，因此我们需要使用 $64$ 位整数进行计算与比较。

**代码**

```C++
class Solution {
public:
    int maximumDetonation(vector<vector<int>>& bombs) {
        int n = bombs.size();
        // 判断炸弹 u 能否引爆炸弹 v
        auto isConnected = [&](int u, int v) -> bool {
            long long dx = bombs[u][0] - bombs[v][0];
            long long dy = bombs[u][1] - bombs[v][1];
            return (long long)bombs[u][2] * bombs[u][2] >= dx * dx + dy * dy;
        };
        
        // 维护引爆关系有向图
        unordered_map<int, vector<int>> edges;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i != j && isConnected(i, j)) {
                    edges[i].push_back(j);
                }
            }
        }
        int res = 0;   // 最多引爆数量
        for (int i = 0; i < n; ++i) {
            // 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
            vector<int> visited(n);
            int cnt = 1;
            queue<int> q;
            q.push(i);
            visited[i] = 1;
            while (!q.empty()) {
                int cidx = q.front();
                q.pop();
                for (const int nidx: edges[cidx]) {
                    if (visited[nidx]) {
                        continue;
                    }
                    ++cnt;
                    q.push(nidx);
                    visited[nidx] = 1;
                }
            }
            res = max(res, cnt);
        }
        return res;
    }
};
```

```Java
class Solution {
    public int maximumDetonation(int[][] bombs) {
        int n = bombs.length;
        // 维护引爆关系有向图
        Map<Integer, List<Integer>> edges = new HashMap<Integer, List<Integer>>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i != j && isConnected(bombs, i, j)) {
                    edges.putIfAbsent(i, new ArrayList<Integer>());
                    edges.get(i).add(j);
                }
            }
        }
        int res = 0;   // 最多引爆数量
        for (int i = 0; i < n; ++i) {
            // 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
            boolean[] visited = new boolean[n];
            int cnt = 1;
            Queue<Integer> queue = new ArrayDeque<Integer>();
            queue.offer(i);
            visited[i] = true;
            while (!queue.isEmpty()) {
                int cidx = queue.poll();
                for (int nidx : edges.getOrDefault(cidx, new ArrayList<Integer>())) {
                    if (visited[nidx]) {
                        continue;
                    }
                    ++cnt;
                    queue.offer(nidx);
                    visited[nidx] = true;
                }
            }
            res = Math.max(res, cnt);
        }
        return res;
    }

    // 判断炸弹 u 能否引爆炸弹 v
    public boolean isConnected(int[][] bombs, int u, int v) {
        long dx = bombs[u][0] - bombs[v][0];
        long dy = bombs[u][1] - bombs[v][1];
        return (long) bombs[u][2] * bombs[u][2] >= dx * dx + dy * dy;
    }
}
```

```CSharp
public class Solution {
    public int MaximumDetonation(int[][] bombs) {
        int n = bombs.Length;
        // 维护引爆关系有向图
        IDictionary<int, IList<int>> edges = new Dictionary<int, IList<int>>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i != j && IsConnected(bombs, i, j)) {
                    edges.TryAdd(i, new List<int>());
                    edges[i].Add(j);
                }
            }
        }
        int res = 0;   // 最多引爆数量
        for (int i = 0; i < n; ++i) {
            // 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
            bool[] visited = new bool[n];
            int cnt = 1;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(i);
            visited[i] = true;
            while (queue.Count > 0) {
                int cidx = queue.Dequeue();
                foreach (int nidx in edges.ContainsKey(cidx) ? edges[cidx] : new List<int>()) {
                    if (visited[nidx]) {
                        continue;
                    }
                    ++cnt;
                    queue.Enqueue(nidx);
                    visited[nidx] = true;
                }
            }
            res = Math.Max(res, cnt);
        }
        return res;
    }

    // 判断炸弹 u 能否引爆炸弹 v
    public bool IsConnected(int[][] bombs, int u, int v) {
        long dx = bombs[u][0] - bombs[v][0];
        long dy = bombs[u][1] - bombs[v][1];
        return (long) bombs[u][2] * bombs[u][2] >= dx * dx + dy * dy;
    }
}
```

```Python
class Solution:
    def maximumDetonation(self, bombs: List[List[int]]) -> int:
        n = len(bombs)
        # 判断炸弹 u 能否引爆炸弹 v
        def isConnected(u: int, v: int) -> bool:
            dx = bombs[u][0] - bombs[v][0]
            dy = bombs[u][1] - bombs[v][1]
            return bombs[u][2] ** 2 >= dx ** 2 + dy ** 2
        
        # 维护引爆关系有向图
        edges = defaultdict(list)
        for i in range(n):
            for j in range(n):
                if i != j and isConnected(i, j):
                    edges[i].append(j)
        res = 0   # 最多引爆数量
        for i in range(n):
            # 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
            visited = [False] * n
            cnt = 1
            q = deque([i])
            visited[i] = True
            while q:
                cidx = q.popleft()
                for nidx in edges[cidx]:
                    if visited[nidx]:
                        continue
                    cnt += 1
                    q.append(nidx)
                    visited[nidx] = True
            res = max(res, cnt)
        return res
```

```Go
func maximumDetonation(bombs [][]int) int {
    n := len(bombs)
    // 判断炸弹 u 能否引爆炸弹 v
    isConnected := func(u, v int) bool {
        dx := bombs[u][0] - bombs[v][0]
        dy := bombs[u][1] - bombs[v][1]
        return int64(bombs[u][2]*bombs[u][2]) >= int64(dx*dx+dy*dy)
    }

    // 维护引爆关系有向图
    edges := make(map[int][]int)
    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            if i != j && isConnected(i, j) {
                edges[i] = append(edges[i], j)
            }
        }
    }
   
    res := 0 // 最多引爆数量
    for i := 0; i < n; i++ {
        // 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
        visited := make([]int, n)
        cnt := 1
        q := list.New()
        q.PushBack(i)
        visited[i] = 1
        for q.Len() > 0 {
            cidx := q.Remove(q.Front()).(int)
            for _, nidx := range edges[cidx] {
                if visited[nidx] != 0 {
                    continue
                }
                cnt++
                q.PushBack(nidx)
                visited[nidx] = 1
            }
        }
        if cnt > res {
            res = cnt
        }
    }
    return res
}
```

```C
typedef struct {
    int key;
    struct ListNode *val;
    UT_hash_handle hh;
} HashItem; 

struct ListNode *creatListNode(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *p = list;
        list = list->next;
        free(p);
    }
}

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = key;
        pEntry->val = NULL;
        HASH_ADD_INT(*obj, key, pEntry);
    }
    struct ListNode *node = creatListNode(val);
    node->next = pEntry->val;
    pEntry->val = node;
    return true;
}

struct ListNode* hashGetItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr->val);  
        free(curr);
    }
}

// 判断炸弹 u 能否引爆炸弹 v
bool isConnected(int u, int v, int **bombs) {
    long long dx = bombs[u][0] - bombs[v][0];
    long long dy = bombs[u][1] - bombs[v][1];
    return (long long)bombs[u][2] * bombs[u][2] >= dx * dx + dy * dy;
}

int maximumDetonation(int** bombs, int bombsSize, int* bombsColSize) {
    int n = bombsSize;
    // 维护引爆关系有向图
    HashItem *edges = NULL;
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            if (i != j && isConnected(i, j, bombs)) {
                hashAddItem(&edges, i, j);
            }
        }
    }
    int res = 0;   // 最多引爆数量
    for (int i = 0; i < n; ++i) {
        // 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
        int visited[n];
        memset(visited, 0, sizeof(visited));
        int cnt = 1;
        int queue[n];
        int head = 0, tail = 0;
        queue[tail++] = i;
        visited[i] = 1;
        while (head != tail) {
            int cidx = queue[head++];
            for (struct ListNode *p = hashFindItem(&edges, cidx); p != NULL; p = p->next) {
                int nidx = p->val;
                if (visited[nidx]) {
                    continue;
                }
                ++cnt;
                queue[tail++] = nidx;
                visited[nidx] = 1;
            }
        }
        res = fmax(res, cnt);
    }
    hashFree(&edges);
    return res;
}
```

```Go
func maximumDetonation(bombs [][]int) int {
    n := len(bombs)
    // 判断炸弹 u 能否引爆炸弹 v
    isConnected := func(u, v int) bool {
        dx := bombs[u][0] - bombs[v][0]
        dy := bombs[u][1] - bombs[v][1]
        return int64(bombs[u][2]*bombs[u][2]) >= int64(dx*dx+dy*dy)
    }

    // 维护引爆关系有向图
    edges := make(map[int][]int)
    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            if i != j && isConnected(i, j) {
                edges[i] = append(edges[i], j)
            }
        }
    }
    res := 0 // 最多引爆数量
    for i := 0; i < n; i++ {
        // 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
        visited := make([]int, n)
        cnt := 1
        q := []int{}
        q = append(q, i)
        visited[i] = 1
        for len(q) > 0 {
            cidx := q[0]
            q = q[1:]
            for _, nidx := range edges[cidx] {
                if visited[nidx] != 0 {
                    continue
                }
                cnt++
                q = append(q, nidx)
                visited[nidx] = 1
            }
        }
        if cnt > res {
            res = cnt
        }
    }
    return res
}
```

```JavaScript
var maximumDetonation = function(bombs) {
    const n = bombs.length;
    // 判断炸弹 u 能否引爆炸弹 v
    const isConnected = (u, v) => {
        const dx = bombs[u][0] - bombs[v][0];
        const dy = bombs[u][1] - bombs[v][1];
        return bombs[u][2] * bombs[u][2] >= dx * dx + dy * dy;
    };
    
    // 维护引爆关系有向图
    const edges = new Map();
    for (let i = 0; i < n; ++i) {
        for (let j = 0; j < n; ++j) {
            if (i !== j && isConnected(i, j)) {
                if (!edges.has(i)) edges.set(i, []);
                edges.get(i).push(j);
            }
        }
    }
    let res = 0; // 最多引爆数量
    for (let i = 0; i < n; ++i) {
        // 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
        const visited = Array(n).fill(0);
        let cnt = 1;
        const q = [i];
        visited[i] = 1;
        while (q.length > 0) {
            const cidx = q.shift();
            for (const nidx of edges.get(cidx) || []) {
                if (visited[nidx]) continue;
                ++cnt;
                q.push(nidx);
                visited[nidx] = 1;
            }
        }
        res = Math.max(res, cnt);
    }
    return res;
};
```

```TypeScript
function maximumDetonation(bombs: number[][]): number {
    const n: number = bombs.length;
    // 判断炸弹 u 能否引爆炸弹 v
    const isConnected = (u: number, v: number): boolean => {
        const dx: number = bombs[u][0] - bombs[v][0];
        const dy: number = bombs[u][1] - bombs[v][1];
        return bombs[u][2] * bombs[u][2] >= dx * dx + dy * dy;
    };
    
    // 维护引爆关系有向图
    const edges: Map<number, number[]> = new Map();
    for (let i = 0; i < n; ++i) {
        for (let j = 0; j < n; ++j) {
            if (i !== j && isConnected(i, j)) {
                if (!edges.has(i)) edges.set(i, []);
                edges.get(i)!.push(j);
            }
        }
    }
    let res: number = 0; // 最多引爆数量
    for (let i = 0; i < n; ++i) {
        // 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
        const visited: number[] = Array(n).fill(0);
        let cnt: number = 1;
        const q: number[] = [i];
        visited[i] = 1;
        while (q.length > 0) {
            const cidx: number = q.shift()!;
            for (const nidx of edges.get(cidx) || []) {
                if (visited[nidx]) continue;
                ++cnt;
                q.push(nidx);
                visited[nidx] = 1;
            }
        }
        res = Math.max(res, cnt);
    }
    return res;
};
```

```Rust
use std::collections::{HashMap, VecDeque};
use std::cmp::max;

impl Solution {
    pub fn maximum_detonation(bombs: Vec<Vec<i32>>) -> i32 {
        let n = bombs.len();
    // 判断炸弹 u 能否引爆炸弹 v
        let is_connected = |u: usize, v: usize| -> bool {
            let dx = (bombs[u][0] - bombs[v][0]) as i64;
            let dy = (bombs[u][1] - bombs[v][1]) as i64;
            (bombs[u][2] as i64) * (bombs[u][2] as i64) >= (dx * dx + dy * dy)
        };

        // 维护引爆关系有向图
        let mut edges: HashMap<usize, Vec<usize>> = HashMap::new();
        for i in 0..n {
            for j in 0..n {
                if i != j && is_connected(i, j) {
                    edges.entry(i).or_insert(Vec::new()).push(j);
                }
            }
        }

        let mut res = 0; // 最多引爆数量
        for i in 0..n {
            // 遍历每个炸弹，广度优先搜索计算该炸弹可引爆的数量，并维护最大值
            let mut visited = vec![0; n];
            let mut cnt = 1;
            let mut q = VecDeque::new();
            q.push_back(i);
            visited[i] = 1;
            while let Some(cidx) = q.pop_front() {
                for &nidx in edges.get(&cidx).unwrap_or(&vec![]) {
                    if visited[nidx] == 1 {
                        continue;
                    }
                    cnt += 1;
                    q.push_back(nidx);
                    visited[nidx] = 1;
                }
            }
            res = max(res, cnt);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^3)$，其中 $n$ 为 $bombs$ 的长度。建立有向图的时间复杂度为 $O(n^2)$，对于每个炸弹进行广度优先搜索确定可引爆数量的时间复杂度为 $O(n^2)$，我们需要对每个炸弹进行一次广度优先搜索。
- 空间复杂度：$O(n^2)$，即为邻接表的空间开销。
