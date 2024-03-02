### [受限条件下可到达节点的数目](https://leetcode.cn/problems/reachable-nodes-with-restrictions/solutions/2654302/shou-xian-tiao-jian-xia-ke-dao-da-jie-di-9qee/)

#### 方法一：深度优先搜索

##### 思路与算法

从 $0$ 号点开始深度优先搜索，如果遇到在 $\textit{restricted}$ 的点就跳过，最终遍历到的点的个数就是答案。

##### 代码

```c++
class Solution {
public:
    int reachableNodes(int n, vector<vector<int>>& edges, vector<int>& restricted) {
        vector<int> isrestricted(n);
        for (auto x : restricted) {
            isrestricted[x] = 1;
        }

        vector<vector<int>> g(n);
        for (auto &v : edges) {
            g[v[0]].push_back(v[1]);
            g[v[1]].push_back(v[0]);
        }
        int cnt = 0;
        function<void(int, int)> dfs = [&](int x, int f) {
            cnt++;
            for (auto &y : g[x]) {
                if (y != f && !isrestricted[y]) {
                    dfs(y, x);
                }
            }
        };
        dfs(0, -1);
        return cnt;
    }
};
```

```java
class Solution {
    int cnt = 0;

    public int reachableNodes(int n, int[][] edges, int[] restricted) {
        boolean[] isrestricted = new boolean[n];
        for (int x : restricted) {
            isrestricted[x] = true;
        }

        List<Integer>[] g = new List[n];
        for (int i = 0; i < n; i++) {
            g[i] = new ArrayList<Integer>();
        }
        for (int[] v : edges) {
            g[v[0]].add(v[1]);
            g[v[1]].add(v[0]);
        }
        dfs(0, -1, isrestricted, g);
        return cnt;
    }

    public void dfs(int x, int f, boolean[] isrestricted, List<Integer>[] g) {
        cnt++;
        for (int y : g[x]) {
            if (y != f && !isrestricted[y]) {
                dfs(y, x, isrestricted, g);
            }
        }
    }
}
```

```c
struct ListNode *createdListNode(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

void dfs(int x, int f, struct ListNode **g, int *cnt, int *isrestricted) {
    (*cnt)++;
    for (struct ListNode *p = g[x]; p; p = p->next) {
        int y = p->val;
        if (y != f && !isrestricted[y]) {
            dfs(y, x, g, cnt, isrestricted);
        }
    }
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *p = list;
        list = list->next;
        free(p);
    }
}

int reachableNodes(int n, int** edges, int edgesSize, int* edgesColSize, int* restricted, int restrictedSize) {
    int isrestricted[n];
    memset(isrestricted, 0, sizeof(isrestricted));
    for (int i = 0; i < restrictedSize; i++) {
        isrestricted[restricted[i]] = 1;
    }
    
    struct ListNode *g[n];
    for (int i = 0; i < n; i++) {
        g[i] = NULL;
    }
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0], y = edges[i][1];
        struct ListNode *nodex = createdListNode(x);
        struct ListNode *nodey = createdListNode(y);
        nodex->next = g[y];
        g[y] = nodex;
        nodey->next = g[x];
        g[x] = nodey;
    }
   
    int cnt = 0;
    dfs(0, -1, g, &cnt, isrestricted);
    for (int i = 0; i < n; i++) {
        freeList(g[i]);
    }
    return cnt;
}
```

```python
class Solution:
    def reachableNodes(self, n: int, edges: List[List[int]], restricted: List[int]) -> int:
        is_restricted = [1] * n
        for x in restricted:
            is_restricted[x] = 1
        g = [[] for _ in range(n)]
        for v in edges:
            g[v[0]].append(v[1])
            g[v[1]].append(v[0])

        cnt = 0
        def dfs(x, f):
            nonlocal cnt
            cnt += 1
            for y in g[x]:
                if y != f and not is_restricted[y]:
                    dfs(y, x)

        dfs(0, -1)
        return cnt
```

```go
func reachableNodes(n int, edges [][]int, restricted []int) int {
    isRestricted := make([]int, n)
    for _, x := range restricted {
        isRestricted[x] = 1
    }
    g := make([][]int, n)
    for _, v := range edges {
        g[v[0]] = append(g[v[0]], v[1])
        g[v[1]] = append(g[v[1]], v[0])
    }

    cnt := 0
    var dfs func(int, int)
    dfs = func(x, f int) {
        cnt++
        for _, y := range g[x] {
            if y != f && isRestricted[y] != 1 {
                dfs(y, x)
            }
        }
    }
    dfs(0, -1)
    return cnt
}
```

```javascript
var reachableNodes = function(n, edges, restricted) {
    const isRestricted = new Array(n).fill(0);
    for (const x of restricted) {
        isRestricted[x] = 1;
    }

    const g = new Array(n).fill(null).map(() => []);
    for (const [u, v] of edges) {
        g[u].push(v);
        g[v].push(u);
    }

    let cnt = 0;
    const dfs = (x, f) => {
        cnt++;
        for (const y of g[x]) {
            if (y !== f && !isRestricted[y]) {
                dfs(y, x);
            }
        }
    }
    dfs(0, -1);
    return cnt;
};
```

```typescript
function reachableNodes(n: number, edges: number[][], restricted: number[]): number {
    const isRestricted: number[] = new Array(n).fill(0);
    for (const x of restricted) {
        isRestricted[x] = 1;
    }

    const g: number[][] = new Array(n).fill(null).map(() => []);
    for (const [u, v] of edges) {
        g[u].push(v);
        g[v].push(u);
    }

    let cnt = 0;
    function dfs(x: number, f: number): void {
        cnt++;
        for (const y of g[x]) {
            if (y !== f && !isRestricted[y]) {
                dfs(y, x);
            }
        }
    }
    dfs(0, -1);
    return cnt;
};
```

复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是无向树中点的个数。
- 空间复杂度：$O(n)$。

#### 方法二：并查集

##### 思路与算法

如果忽略受限的点，树就会变成若干个连通块，我们要计算的就是 $0$ 号点所在连通块的大小。

因此，我们可以用并查集来不断地将点集进行合并，依次考虑每一条边，如果边上两个点都没有受限，那么合并这两个点的所在集合，否则跳过该边。最终查询 $0$ 号点所在连通块的大小即可。

##### 代码

```c++
class UnionFind {
public:
    UnionFind(int n):f(n), rank(n) {
        for (int i = 0; i < n; i++) {
            f[i] = i;
        }
    }

    void merge(int x, int y) {
        int rx = find(x);
        int ry = find(y);
        if (rx != ry) {
            if (rank[rx] > rank[ry]) {
                f[ry] = rx;
            } else if (rank[rx] < rank[ry]) {
                f[rx] = ry;
            } else {
                f[ry] = rx;
                rank[rx]++;
            }
        }
    }

    int find(int x) {
        if (x != f[x]) {
            x = find(f[x]);
        }
        return f[x];
    }

    int count() {
        int cnt = 0;
        int rt = find(0);
        for (int i = 0; i < f.size(); i++) {
            if (rt == find(i)) {
                cnt++;
            }
        }
        return cnt;
    }
private:
    vector<int> f;
    vector<int> rank;
};
class Solution {
public:
    int reachableNodes(int n, vector<vector<int>>& edges, vector<int>& restricted) {
        vector<int> isrestricted(n);
        for (auto &x : restricted) {
            isrestricted[x] = 1;
        }
        
        UnionFind uf = UnionFind(n);
        for (auto &v : edges) {
            if (isrestricted[v[0]] || isrestricted[v[1]]) {
                continue;
            }
            uf.merge(v[0], v[1]);
        }
        return uf.count();
    }
};
```

```java
class Solution {
    public int reachableNodes(int n, int[][] edges, int[] restricted) {
        boolean[] isrestricted = new boolean[n];
        for (int x : restricted) {
            isrestricted[x] = true;
        }

        UnionFind uf = new UnionFind(n);
        for (int[] v : edges) {
            if (isrestricted[v[0]] || isrestricted[v[1]]) {
                continue;
            }
            uf.merge(v[0], v[1]);
        }
        return uf.count();
    }
}

class UnionFind {
    private int[] f;
    private int[] rank;

    public UnionFind(int n) {
        f = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            f[i] = i;
        }
    }

    public void merge(int x, int y) {
        int rx = find(x);
        int ry = find(y);
        if (rx != ry) {
            if (rank[rx] > rank[ry]) {
                f[ry] = rx;
            } else if (rank[rx] < rank[ry]) {
                f[rx] = ry;
            } else {
                f[ry] = rx;
                rank[rx]++;
            }
        }
    }

    public int find(int x) {
        if (x != f[x]) {
            x = find(f[x]);
        }
        return f[x];
    }

    public int count() {
        int cnt = 0;
        int rt = find(0);
        for (int i = 0; i < f.length; i++) {
            if (rt == find(i)) {
                cnt++;
            }
        }
        return cnt;
    }
}
```

```csharp
public class Solution {
    public int ReachableNodes(int n, int[][] edges, int[] restricted) {
        bool[] isrestricted = new bool[n];
        foreach (int x in restricted) {
            isrestricted[x] = true;
        }

        UnionFind uf = new UnionFind(n);
        foreach (int[] v in edges) {
            if (isrestricted[v[0]] || isrestricted[v[1]]) {
                continue;
            }
            uf.Merge(v[0], v[1]);
        }
        return uf.Count();
    }
}

class UnionFind {
    private int[] f;
    private int[] rank;

    public UnionFind(int n) {
        f = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            f[i] = i;
        }
    }

    public void Merge(int x, int y) {
        int rx = Find(x);
        int ry = Find(y);
        if (rx != ry) {
            if (rank[rx] > rank[ry]) {
                f[ry] = rx;
            } else if (rank[rx] < rank[ry]) {
                f[rx] = ry;
            } else {
                f[ry] = rx;
                rank[rx]++;
            }
        }
    }

    public int Find(int x) {
        if (x != f[x]) {
            x = Find(f[x]);
        }
        return f[x];
    }

    public int Count() {
        int cnt = 0;
        int rt = Find(0);
        for (int i = 0; i < f.Length; i++) {
            if (rt == Find(i)) {
                cnt++;
            }
        }
        return cnt;
    }
}
```

```c
typedef struct UnionFind {
    int *f, *rank;
    int size;
} UnionFind;

UnionFind *createUnionFind(int n) {
    UnionFind *obj = (UnionFind *)malloc(sizeof(UnionFind));
    obj->f = (int *)malloc(sizeof(int) * n);
    obj->rank = (int *)malloc(sizeof(int) * n);
    obj->size = n;
    memset(obj->rank, 0, sizeof(int) * n);
    for (int i = 0; i < n; i++) {
        obj->f[i] = i;
    }
    return obj;
}

int find(UnionFind *obj, int x) {
    if (x != obj->f[x]) {
        x = find(obj, obj->f[x]);
    }
    return obj->f[x];
}

void merge(UnionFind *obj, int x, int y) {
    int rx = find(obj, x);
    int ry = find(obj, y);
    if (rx != ry) {
        if (obj->rank[rx] > obj->rank[ry]) {
            obj->f[ry] = rx;
        } else if (obj->rank[rx] < obj->rank[ry]) {
            obj->f[rx] = ry;
        } else {
            obj->f[ry] = rx;
            obj->rank[rx]++;
        }
    }
}

int count(UnionFind *obj) {
    int cnt = 0;
    int rt = find(obj, 0);
    for (int i = 0; i < obj->size; i++) {
        if (rt == find(obj, i)) {
            cnt++;
        }
    }
    return cnt;
}

void freeUnionFind(UnionFind *obj) {
    free(obj->f);
    free(obj->rank);
    free(obj);
}

int reachableNodes(int n, int** edges, int edgesSize, int* edgesColSize, int* restricted, int restrictedSize) {
    int isrestricted[n];
    memset(isrestricted, 0, sizeof(isrestricted));
    for (int i = 0; i < restrictedSize; i++) {
        isrestricted[restricted[i]] = 1;
    }
    
    UnionFind *uf = createUnionFind(n);
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0], y = edges[i][1];
        if (isrestricted[x] || isrestricted[y]) {
            continue;
        }
        merge(uf, x, y);
    }
    int ret = count(uf);
    freeUnionFind(uf);
    return ret;
}
```

```python
class UnionFind:
    def __init__(self, n):
        self.f = list(range(n))
        self.rank = [0] * n

    def merge(self, x, y):
        rx = self.find(x)
        ry = self.find(y)
        if rx != ry:
            if self.rank[rx] > self.rank[ry]:
                self.f[ry] = rx
            elif self.rank[rx] < self.rank[ry]:
                self.f[rx] = ry
            else:
                self.f[ry] = rx
                self.rank[rx] += 1

    def find(self, x):
        if x != self.f[x]:
            self.f[x] = self.find(self.f[x])
        return self.f[x]

    def count(self):
        cnt = 0
        rt = self.find(0)
        for i in range(len(self.f)):
            if rt == self.find(i):
                cnt += 1
        return cnt

class Solution:
    def reachableNodes(self, n: int, edges: List[List[int]], restricted: List[int]) -> int:
        is_restricted = [0] * n
        for x in restricted:
            is_restricted[x] = 1

        uf = UnionFind(n)
        for v in edges:
            if is_restricted[v[0]] or is_restricted[v[1]]:
                continue
            uf.merge(v[0], v[1])
        return uf.count()
```

```go
type UnionFind struct {
    f    []int
    rank []int
}

func NewUnionFind(n int) *UnionFind {
    uf := &UnionFind{
        f:    make([]int, n),
        rank: make([]int, n),
    }
    for i := 0; i < n; i++ {
        uf.f[i] = i
    }
    return uf
}

func (uf *UnionFind) merge(x, y int) {
    rx := uf.find(x)
    ry := uf.find(y)
    if rx != ry {
        if uf.rank[rx] > uf.rank[ry] {
            uf.f[ry] = rx
        } else if uf.rank[rx] < uf.rank[ry] {
            uf.f[rx] = ry
        } else {
            uf.f[ry] = rx
            uf.rank[rx]++
        }
    }
}

func (uf *UnionFind) find(x int) int {
    if x != uf.f[x] {
        uf.f[x] = uf.find(uf.f[x])
    }
    return uf.f[x]
}

func (uf *UnionFind) count() int {
    cnt := 0
    rt := uf.find(0)
    for i := 0; i < len(uf.f); i++ {
        if rt == uf.find(i) {
            cnt++
        }
    }
    return cnt
}

func reachableNodes(n int, edges [][]int, restricted []int) int {
    isRestricted := make([]int, n)
    for _, x := range restricted {
        isRestricted[x] = 1
    }

    uf := NewUnionFind(n)
    for _, v := range edges {
        if isRestricted[v[0]] == 1 || isRestricted[v[1]] == 1 {
            continue
        }
        uf.merge(v[0], v[1])
    }
    return uf.count()
}
```

```typescript
class UnionFind {
    constructor(n) {
        this.f = Array.from({ length: n }, (_, i) => i);
        this.rank = new Array(n).fill(0);
    }

    merge(x, y) {
        let rx = this.find(x);
        let ry = this.find(y);
        if (rx !== ry) {
            if (this.rank[rx] > this.rank[ry]) {
                this.f[ry] = rx;
            } else if (this.rank[rx] < this.rank[ry]) {
                this.f[rx] = ry;
            } else {
                this.f[ry] = rx;
                this.rank[rx]++;
            }
        }
    }

    find(x) {
        if (x !== this.f[x]) {
            this.f[x] = this.find(this.f[x]);
        }
        return this.f[x];
    }

    count() {
        let cnt = 0;
        let rt = this.find(0);
        for (let i = 0; i < this.f.length; i++) {
            if (rt === this.find(i)) {
                cnt++;
            }
        }
        return cnt;
    }
}

var reachableNodes = function(n, edges, restricted) {
    const isRestricted = new Array(n).fill(0);
    for (const x of restricted) {
        isRestricted[x] = 1;
    }

    const uf = new UnionFind(n);
    for (const [u, v] of edges) {
        if (isRestricted[u] === 1 || isRestricted[v] === 1) {
            continue;
        }
        uf.merge(u, v);
    }
    return uf.count();
};
```

```typescript
class UnionFind {
    f: number[];
    rank: number[];

    constructor(n: number) {
        this.f = Array.from({ length: n }, (_, i) => i);
        this.rank = new Array(n).fill(0);
    }

    merge(x: number, y: number): void {
        let rx = this.find(x);
        let ry = this.find(y);
        if (rx !== ry) {
            if (this.rank[rx] > this.rank[ry]) {
                this.f[ry] = rx;
            } else if (this.rank[rx] < this.rank[ry]) {
                this.f[rx] = ry;
            } else {
                this.f[ry] = rx;
                this.rank[rx]++;
            }
        }
    }

    find(x: number): number {
        if (x !== this.f[x]) {
            this.f[x] = this.find(this.f[x]);
        }
        return this.f[x];
    }

    count(): number {
        let cnt = 0;
        let rt = this.find(0);
        for (let i = 0; i < this.f.length; i++) {
            if (rt === this.find(i)) {
                cnt++;
            }
        }
        return cnt;
    }
}

function reachableNodes(n: number, edges: number[][], restricted: number[]): number {
    const isRestricted: number[] = new Array(n).fill(0);
    for (const x of restricted) {
        isRestricted[x] = 1;
    }

    const uf = new UnionFind(n);
    for (const [u, v] of edges) {
        if (isRestricted[u] === 1 || isRestricted[v] === 1) {
            continue;
        }
        uf.merge(u, v);
    }
    return uf.count();
};
```

#### 复杂度分析

- 时间复杂度：$O(n\times \alpha(n))$，其中 $n$ 是无向树中点的个数，$\alpha$ 是反阿克曼函数。使用路径压缩和按秩合并优化后的并查集，单次查询和合并操作的时间复杂度是 $O(\alpha(n))$，通常比较小，可以忽略。
- 空间复杂度：$O(n)$。
