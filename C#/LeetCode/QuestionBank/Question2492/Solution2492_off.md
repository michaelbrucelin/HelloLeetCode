### [两个城市间路径的最小分数](https://leetcode.cn/problems/minimum-score-of-a-path-between-two-cities/solutions/3988215/liang-ge-cheng-shi-jian-lu-jing-de-zui-x-knmj/)

#### 方法一：深度优先搜索 / 广度优先搜索

**思路与算法**

从图论的角度，题目给定了一个带边权的无向图，该图不一定连通，但是保证节点 $1$ 和节点 $n$ 之间存在路径，即节点 $1$ 和节点 $n$ 一定在同一个连通块上。目标是求解节点 $1$ 到节点 $n$ 之间所有「路径」上的最小边权。

注意这里的「路径」加了引号，因为题目的限制条件比较繁杂，主要就是关于「路径」的定义：

> - 一条路径指的是两个城市之间的道路序列。
> - 一条路径可以 **多次** 包含同一条道路，你也可以沿着路径多次到达城市 $1$ 和城市 $n$。

由于要求的是路径上的最小边权，因此这个**道路序列的顺序**，以及各个**边权出现的次数**都**不是**我们关心的。去掉这两个性质之后，这个序列本质上就是一个相互可达的边集，或者更准确的说，构成了一个**连通子图**上的边集。

因此，该题本质上就是在求解，包含节点 $1$ 和节点 $n$ 的所有**连通子图**上的**最小边权**。接下来不难发现，所有包含目标最小边的连通子图，都能求解出答案，那么显然我们在包含节点 $1$（或节点 $n$）的那个最大连通子图，也就是其所在的**连通分量**上求解即可。

因为题目已经保证节点 $1$ 和节点 $n$ 在同一个连通分量上，所以只需要从节点 $1$ 或节点 $n$ 开始深度优先搜索或广度优先搜索，遍历该连通分量上的所有边权取最小即可。

**代码**

```C++
class Solution {
public:
    int minScore(int n, vector<vector<int>>& roads) {
        struct Edge {
            int v, dis;
        };

        vector<bool> vis(n + 1, false);
        vector<vector<Edge>> graph(n + 1);

        for (const auto& road : roads) {
            graph[road[0]].push_back({road[1], road[2]});
            graph[road[1]].push_back({road[0], road[2]});
        }

        int ans = INT_MAX;
        auto dfs = [&](auto& self, int u) -> void {
            if (vis[u] == false) {
                vis[u] = true;
            }

            for (const auto& edge : graph[u]) {
                ans = min(ans, edge.dis);
                if (vis[edge.v] == false) {
                    self(self, edge.v);
                }
            }
        };

        dfs(dfs, 1);
        return ans;
    }
};
```

```Java
class Solution {
    private record Edge(int v, int dis) {
    }

    public int minScore(int n, int[][] roads) {
        boolean[] vis = new boolean[n + 1];
        List<Edge>[] graph = new ArrayList[n + 1];
        for (int i = 0; i <= n; i++) {
            graph[i] = new ArrayList<>();
        }

        for (int[] road : roads) {
            graph[road[0]].add(new Edge(road[1], road[2]));
            graph[road[1]].add(new Edge(road[0], road[2]));
        }

        int[] ans = { Integer.MAX_VALUE };
        dfs(1, graph, vis, ans);
        return ans[0];
    }

    private void dfs(int u, List<Edge>[] graph, boolean[] vis, int[] ans) {
        if (vis[u] == false) {
            vis[u] = true;
        }

        for (Edge edge : graph[u]) {
            ans[0] = Math.min(ans[0], edge.dis);
            if (vis[edge.v] == false) {
                dfs(edge.v, graph, vis, ans);
            }
        }
    }
}
```

```C
typedef struct Edge {
    int v;
    int dis;
    struct Edge* next;
} Edge;

typedef struct {
    Edge* head;
} GraphNode;

void addEdge(GraphNode* graph, int u, int v, int dis) {
    Edge* edge = (Edge*)malloc(sizeof(Edge));
    edge->v = v;
    edge->dis = dis;
    edge->next = graph[u].head;
    graph[u].head = edge;
}

void dfs(GraphNode* graph, int* vis, int u, int* ans) {
    if (!vis[u]) {
        vis[u] = 1;
    }

    Edge* edge = graph[u].head;
    while (edge) {
        if (edge->dis < *ans) {
            *ans = edge->dis;
        }
        if (!vis[edge->v]) {
            dfs(graph, vis, edge->v, ans);
        }
        edge = edge->next;
    }
}

int minScore(int n, int** roads, int roadsSize, int* roadsColSize) {
    GraphNode* graph = (GraphNode*)calloc(n + 1, sizeof(GraphNode));
    int* vis = (int*)calloc(n + 1, sizeof(int));
    
    for (int i = 0; i < roadsSize; i++) {
        int u = roads[i][0];
        int v = roads[i][1];
        int dis = roads[i][2];
        addEdge(graph, u, v, dis);
        addEdge(graph, v, u, dis);
    }
    
    int ans = INT_MAX;
    dfs(graph, vis, 1, &ans);
    
    for (int i = 0; i <= n; i++) {
        Edge* edge = graph[i].head;
        while (edge) {
            Edge* temp = edge;
            edge = edge->next;
            free(temp);
        }
    }
    free(graph);
    free(vis);
    
    return ans;
}
```

```Python
class Solution:
    def minScore(self, n: int, roads: list[list[int]]) -> int:
        vis = [False] * (n + 1)
        graph = [[] for _ in range(n + 1)]

        for u, v, dis in roads:
            graph[u].append((v, dis))
            graph[v].append((u, dis))

        ans = math.inf

        def dfs(u: int) -> None:
            nonlocal ans
            if vis[u] is False:
                vis[u] = True

            for v, dis in graph[u]:
                if dis < ans:
                    ans = dis
                if vis[v] is False:
                    dfs(v)

        dfs(1)
        return ans

```

```CSharp
public class Solution {
    public int MinScore(int n, int[][] roads) {
        var vis = new bool[n + 1];
        var graph = new List<(int v, int dis)>[n + 1];
        for (int i = 0; i <= n; i++) {
            graph[i] = new List<(int v, int dis)>();
        }

        foreach (var road in roads) {
            graph[road[0]].Add((road[1], road[2]));
            graph[road[1]].Add((road[0], road[2]));
        }

        int ans = int.MaxValue;

        void Dfs(int u) {
            if (vis[u] == false) {
                vis[u] = true;
            }

            foreach (var edge in graph[u]) {
                ans = Math.Min(ans, edge.dis);
                if (vis[edge.v] == false) {
                    Dfs(edge.v);
                }
            }
        }

        Dfs(1);
        return ans;
    }
}
```

```JavaScript
var minScore = function(n, roads) {
    const vis = Array.from({ length: n + 1 }, () => false);
    const graph = Array.from({ length: n + 1 }, () => []);

    for (const [u, v, dis] of roads) {
        graph[u].push({ v, dis });
        graph[v].push({ v: u, dis });
    }

    let ans = Infinity;
    const dfs = (u) => {
        if (vis[u] === false) {
            vis[u] = true;
        }

        for (const { v, dis } of graph[u]) {
            ans = Math.min(ans, dis);
            if (vis[v] === false) {
                dfs(v);
            }
        }
    };

    dfs(1);
    return ans;
};
```

```TypeScript
function minScore(n: number, roads: number[][]): number {
    type Edge = { v: number, dis: number };

    const vis = Array.from({ length: n + 1 }, () => false);
    const graph = Array.from<unknown, Edge[]>({ length: n + 1 }, () => []);

    for (const [u, v, dis] of roads) {
        graph[u].push({ v: v, dis });
        graph[v].push({ v: u, dis });
    }

    let ans = Infinity;
    const dfs = (u: number) => {
        if (vis[u] === false) {
            vis[u] = true;
        }

        for (const { v, dis } of graph[u]) {
            ans = Math.min(ans, dis);
            if (vis[v] === false) {
                dfs(v);
            }
        }
    }

    dfs(1);
    return ans;
};
```

```Go
func minScore(n int, roads [][]int) int {
    type edge struct {
        v   int
        dis int
    }

    vis := make([]bool, n+1)
    graph := make([][]edge, n+1)

    for _, road := range roads {
        u, v, dis := road[0], road[1], road[2]
        graph[u] = append(graph[u], edge{v: v, dis: dis})
        graph[v] = append(graph[v], edge{v: u, dis: dis})
    }

    ans := math.MaxInt32
    var dfs func(int)
    dfs = func(u int) {
        if vis[u] == false {
            vis[u] = true
        }

        for _, e := range graph[u] {
            if e.dis < ans {
                ans = e.dis
            }
            if vis[e.v] == false {
                dfs(e.v)
            }
        }
    }

    dfs(1)
    return ans
}
```

```Rust
impl Solution {
    pub fn min_score(n: i32, roads: Vec<Vec<i32>>) -> i32 {
        let n = n as usize;
        let mut vis = vec![false; n + 1];
        let mut graph: Vec<Vec<(usize, i32)>> = vec![vec![]; n + 1];

        for road in roads {
            let u = road[0] as usize;
            let v = road[1] as usize;
            let dis = road[2];
            graph[u].push((v, dis));
            graph[v].push((u, dis));
        }

        let mut ans = i32::MAX;

        fn dfs(u: usize, graph: &Vec<Vec<(usize, i32)>>, vis: &mut Vec<bool>, ans: &mut i32) {
            if vis[u] == false {
                vis[u] = true;
            }

            for &(v, dis) in &graph[u] {
                *ans = (*ans).min(dis);
                if vis[v] == false {
                    dfs(v, graph, vis, ans);
                }
            }
        }

        dfs(1, &graph, &mut vis, &mut ans);
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 是给定无向图的顶点总数，$m$ 是给定无向图的边数，也即 $roads$ 的长度。构建邻接表需要 $O(m)$，以深度优先搜索为例，图上所有节点和边最多遍历到一次，需要 $O(m+n)$，最终时间复杂度为 $O(m+n)$。
- 空间复杂度：$O(n+m)$。邻接表存图需要 $O(m+n)$，遍历所需辅助数组 $vis$ 需要 $O(n)$，深度优先搜索递归调用栈需要 $O(n)$。

#### 方法二：并查集

**思路与算法**

与连通分量相关的问题，常常可以使用并查集求解。对于本题，我们可以用并查集来快速判断边的端点所属的连通分量，即可在所有符合条件的边中求解边权最小值。

根据给定的 $roads$，先使用并查集维护不同连通分量的连通关系，然后遍历 $roads$，使用并查集判断其端点是否属于节点 $1$ 或节点 $n$ 所属的连通分量，最后在符合条件的边上求边权最小值即可。

**代码**

```C++
class Solution {
    struct DSU {
        vector<int> parent;
        vector<int> rank;

        DSU(int size) {
            parent.resize(size);
            for (int i = 0; i < size; ++i) {
                parent[i] = i;
            }
            rank.assign(size, 0);
        }

        void join(int x, int y) {
            int rx = find(x);
            int ry = find(y);

            if (rx == ry) {
                return;
            }

            if (rank[rx] == rank[ry]) {
                rank[rx]++;
            } else if (rank[rx] < rank[ry]) {
                swap(rx, ry);
            }

            parent[ry] = rx;
        }

        int find(int x) {
            return parent[x] == x ? x : (parent[x] = find(parent[x]));
        }
    };

public:
    int minScore(int n, vector<vector<int>>& roads) {
        int ans = INT_MAX;

        DSU dsu(n + 1);
        for (const auto& road : roads) {
            dsu.join(road[0], road[1]);
        }

        int component = dsu.find(1);
        for (const auto& road : roads) {
            if (dsu.find(road[0]) == component) {
                ans = min(ans, road[2]);
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    class DSU {
        int[] parent;
        int[] rank;

        public DSU(int size) {
            parent = new int[size];
            for (int i = 0; i < size; i++) {
                parent[i] = i;
            }
            rank = new int[size];
        }

        public void join(int x, int y) {
            int rx = find(x);
            int ry = find(y);

            if (rx == ry) {
                return;
            }

            if (rank[rx] == rank[ry]) {
                rank[rx]++;
            } else if (rank[rx] < rank[ry]) {
                int temp = rx;
                rx = ry;
                ry = temp;
            }
            parent[ry] = rx;
        }

        public int find(int x) {
            if (parent[x] != x) {
                parent[x] = find(parent[x]);
            }
            return parent[x];
        }
    }

    public int minScore(int n, int[][] roads) {
        int ans = Integer.MAX_VALUE;

        DSU dsu = new DSU(n + 1);
        for (int[] road : roads) {
            dsu.join(road[0], road[1]);
        }

        int component = dsu.find(1);
        for (int[] road : roads) {
            if (dsu.find(road[0]) == component) {
                ans = Math.min(ans, road[2]);
            }
        }

        return ans;
    }
}
```

```C
typedef struct {
    int* parent;
    int* rank;
} DSU;

DSU* createDSU(int size) {
    DSU* dsu = (DSU*)malloc(sizeof(DSU));
    dsu->parent = (int*)malloc(size * sizeof(int));
    dsu->rank = (int*)calloc(size, sizeof(int));
    
    for (int i = 0; i < size; i++) {
        dsu->parent[i] = i;
    }
    
    return dsu;
}

int find(DSU* dsu, int x) {
    if (dsu->parent[x] != x) {
        dsu->parent[x] = find(dsu, dsu->parent[x]);
    }
    return dsu->parent[x];
}

void join(DSU* dsu, int x, int y) {
    int rx = find(dsu, x);
    int ry = find(dsu, y);
    
    if (rx == ry) {
        return;
    }
    
    if (dsu->rank[rx] == dsu->rank[ry]) {
        dsu->rank[rx]++;
    } else if (dsu->rank[rx] < dsu->rank[ry]) {
        int temp = rx;
        rx = ry;
        ry = temp;
    }
    
    dsu->parent[ry] = rx;
}

void freeDSU(DSU* dsu) {
    free(dsu->parent);
    free(dsu->rank);
    free(dsu);
}

int minScore(int n, int** roads, int roadsSize, int* roadsColSize) {
    int ans = INT_MAX;
    DSU* dsu = createDSU(n + 1);
    
    for (int i = 0; i < roadsSize; i++) {
        join(dsu, roads[i][0], roads[i][1]);
    }
    
    int component = find(dsu, 1);
    for (int i = 0; i < roadsSize; i++) {
        if (find(dsu, roads[i][0]) == component) {
            if (roads[i][2] < ans) {
                ans = roads[i][2];
            }
        }
    }
    
    freeDSU(dsu);
    return ans;
}
```

```Python
class DSU:
    def __init__(self, size: int):
        self.parent = list(range(size))
        self.rank = [0] * size

    def join(self, x: int, y: int):
        rx, ry = self.find(x), self.find(y)

        if rx == ry:
            return

        if self.rank[rx] == self.rank[ry]:
            self.rank[rx] += 1
        else:
            if self.rank[rx] < self.rank[ry]:
                rx, ry = ry, rx
        self.parent[ry] = rx

    def find(self, x: int) -> int:
        if self.parent[x] != x:
            self.parent[x] = self.find(self.parent[x])
        return self.parent[x]


class Solution:
    def minScore(self, n: int, roads: list[list[int]]) -> int:
        ans = math.inf

        dsu = DSU(n + 1)
        for u, v, dis in roads:
            dsu.join(u, v)

        component = dsu.find(1)
        for u, v, dis in roads:
            if dsu.find(u) == component:
                if dis < ans:
                    ans = dis

        return ans

```

```CSharp
public class Solution {
    class DSU {
        int[] parent;
        int[] rank;

        public DSU(int size) {
            parent = new int[size];
            for (int i = 0; i < size; i++) {
                parent[i] = i;
            }
            rank = new int[size];
        }

        public void Join(int x, int y) {
            int rx = Find(x);
            int ry = Find(y);

            if (rx == ry) {
                return;
            }

            if (rank[rx] == rank[ry]) {
                rank[rx]++;
            } else if (rank[rx] < rank[ry]) {
                (rx, ry) = (ry, rx);
            }
            parent[ry] = rx;
        }

        public int Find(int x) {
            return parent[x] == x ? x : (parent[x] = Find(parent[x]));
        }
    }

    public int MinScore(int n, int[][] roads) {
        int ans = int.MaxValue;

        var dsu = new DSU(n + 1);
        foreach (var road in roads) {
            dsu.Join(road[0], road[1]);
        }

        int component = dsu.Find(1);
        foreach (var road in roads) {
            if (dsu.Find(road[0]) == component) {
                ans = Math.Min(ans, road[2]);
            }
        }

        return ans;
    }
}
```

```JavaScript
class DSU {
    constructor(size) {
        this.parent = Array.from({ length: size }, (_, i) => i);
        this.rank = new Array(size).fill(0);
    }

    join(x, y) {
        let rx = this.find(x);
        let ry = this.find(y);

        if (rx === ry) {
            return;
        }

        if (this.rank[rx] === this.rank[ry]) {
            this.rank[rx]++;
        } else if (this.rank[rx] < this.rank[ry]) {
            [rx, ry] = [ry, rx];
        }
        this.parent[ry] = rx;
    }

    find(x) {
        return this.parent[x] === x ? x : (this.parent[x] = this.find(this.parent[x]));
    }
}

var minScore = function (n, roads) {
    let ans = Infinity;

    const dsu = new DSU(n + 1);
    for (const [u, v] of roads) {
        dsu.join(u, v);
    }

    const component = dsu.find(1);
    for (const [u, v, dis] of roads) {
        if (dsu.find(u) === component) {
            ans = Math.min(ans, dis);
        }
    }

    return ans;
};
```

```TypeScript
class DSU {
    parent: number[];
    rank: number[];

    constructor(public size: number) {
        this.parent = Array.from({ length: size }, (_, i) => i);
        this.rank = new Array(size).fill(0);
    }

    join(x: number, y: number): boolean {
        let rx = this.find(x), ry = this.find(y);

        if (rx === ry) return false;

        if (this.rank[rx] === this.rank[ry]) {
            this.rank[rx]++;
        } else if (this.rank[rx] < this.rank[ry]) {
            [rx, ry] = [ry, rx];
        }
        this.parent[ry] = rx;
    }

    find(x: number): number {
        return this.parent[x] === x ? x : (this.parent[x] = this.find(this.parent[x]));
    }
}

function minScore(n: number, roads: number[][]): number {
    type Edge = { v: number, dis: number };
    let ans = Infinity;

    const dsu = new DSU(n + 1);
    for (const [u, v, dis] of roads) {
        dsu.join(u, v);
    }

    const component = dsu.find(1);
    for (const [u, v, dis] of roads) {
        if (dsu.find(u) === component) {
            ans = Math.min(ans, dis);
        }
    }

    return ans;
};
```

```Go
type dsu struct {
    parent []int
    rank   []int
}

func newDSU(size int) *dsu {
    parent := make([]int, size)
    for i := range parent {
        parent[i] = i
    }
    return &dsu{
        parent: parent,
        rank:   make([]int, size),
    }
}

func (d *dsu) join(x, y int) {
    rx, ry := d.find(x), d.find(y)

    if rx == ry {
        return
    }

    if d.rank[rx] == d.rank[ry] {
        d.parent[ry] = rx
        d.rank[rx]++
    } else if d.rank[rx] < d.rank[ry] {
        rx, ry = ry, rx
    }
    d.parent[ry] = rx

}

func (d *dsu) find(x int) int {
    if d.parent[x] != x {
        d.parent[x] = d.find(d.parent[x])
    }
    return d.parent[x]
}

func minScore(n int, roads [][]int) int {
    ans := math.MaxInt32

    d := newDSU(n + 1)
    for _, road := range roads {
        d.join(road[0], road[1])
    }

    component := d.find(1)
    for _, road := range roads {
        if d.find(road[0]) == component {
            if road[2] < ans {
                ans = road[2]
            }
        }
    }

    return ans
}
```

```Rust
struct Dsu {
    parent: Vec<usize>,
    rank: Vec<i32>,
}

impl Dsu {
    fn new(size: usize) -> Self {
        Self {
            parent: (0..size).collect(),
            rank: vec![0; size],
        }
    }

    fn join(&mut self, x: usize, y: usize) -> () {
        let mut rx = self.find(x);
        let mut ry = self.find(y);

        if rx == ry {
            return;
        }

        if self.rank[rx] == self.rank[ry] {
            self.rank[rx] += 1;
        } else if self.rank[rx] < self.rank[ry] {
            std::mem::swap(&mut rx, &mut ry);
        }
        self.parent[ry] = rx;
    }

    fn find(&mut self, x: usize) -> usize {
        if self.parent[x] != x {
            self.parent[x] = self.find(self.parent[x]);
        }
        self.parent[x]
    }
}

impl Solution {
    pub fn min_score(n: i32, roads: Vec<Vec<i32>>) -> i32 {
        let mut ans = i32::MAX;

        let mut dsu = Dsu::new((n + 1) as usize);
        for road in &roads {
            dsu.join(road[0] as usize, road[1] as usize);
        }

        let component = dsu.find(1);
        for road in &roads {
            if dsu.find(road[0] as usize) == component {
                ans = ans.min(road[2]);
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m\cdot \alpha (n))$，其中 $n$ 是给定无向图的顶点总数，$m$ 是给定无向图的边数，也即 $roads$ 的长度，$\alpha $ 是反阿克曼函数。构建并查集需要 $O(n)$，合并连通块和查询边通过并查集完成，其单次均摊复杂度为 $O(\alpha (n))$，总共遍历 $m$ 次，故需要 $O(m\cdot \alpha (n))$。
- 空间复杂度：$O(n)$，并查集内部辅助数组需要 $O(n)$。

#### 方法三：最小生成树

**思路与算法**

通过上面的分析可知，我们实际上要求的就是节点 $1$ 或节点 $n$ 所在的连通分量上的最小边权。那么根据最小生成树的贪心性质，这条边一定会出现在最小生成树构成的子图上，故我们可以考虑使用「[Prim 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fmst%2F%23prim-%E7%AE%97%E6%B3%95)」算法来求解。

Prim 算法是一种启发式广度优先搜索，我们将节点 $1$ 或节点 $n$ 作为起始点，每次从优先队列中选取最小的邻接边加入集合，只需要在选取邻接边的同时更新当前的最小边权即可。

**代码**

```C++
class Solution {
public:
    int minScore(int n, vector<vector<int>>& roads) {
        struct Edge {
            int v, dis;
            bool operator>(const Edge& other) const { return dis > other.dis; }
        };

        vector<vector<Edge>> graph(n + 1);
        vector<bool> vis(n + 1, false);

        int ans = INT_MAX;
        priority_queue<Edge, vector<Edge>, greater<Edge>> pq;

        for (const auto& road : roads) {
            int u = road[0], v = road[1], dis = road[2];
            graph[u].push_back({v, dis});
            graph[v].push_back({u, dis});

            if (pq.empty() && (u == 1 || v == 1)) {
                pq.push({v, dis});
            }
        }

        while (!pq.empty()) {
            auto [u, dis] = pq.top();
            pq.pop();

            if (vis[u]) {
                continue;
            }

            ans = min(ans, dis);
            vis[u] = true;

            for (const auto& edge : graph[u]) {
                if (!vis[edge.v]) {
                    pq.push(edge);
                }
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int minScore(int n, int[][] roads) {
        record Edge(int v, int dis) {}

        List<Edge>[] graph = new ArrayList[n + 1];
        for (int i = 0; i <= n; i++) {
            graph[i] = new ArrayList<>();
        }
        boolean[] vis = new boolean[n + 1];

        int ans = Integer.MAX_VALUE;
        PriorityQueue<Edge> pq = new PriorityQueue<>((a, b) -> Integer.compare(a.dis, b.dis));

        for (int[] road : roads) {
            int u = road[0], v = road[1], dis = road[2];
            graph[u].add(new Edge(v, dis));
            graph[v].add(new Edge(u, dis));

            if (pq.isEmpty() && (u == 1 || v == 1)) {
                pq.offer(new Edge(v, dis));
            }
        }

        while (!pq.isEmpty()) {
            Edge curr = pq.poll();
            int u = curr.v;
            int dis = curr.dis;

            if (vis[u]) {
                continue;
            }

            ans = Math.min(ans, dis);
            vis[u] = true;

            for (Edge edge : graph[u]) {
                if (!vis[edge.v]) {
                    pq.offer(edge);
                }
            }
        }

        return ans;
    }
}
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int data[2];
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

Element *createElement(int x, int y) {
    Element *obj = (Element *)malloc(sizeof(Element));
    obj->data[0] = x;
    obj->data[1] = y;
    return obj;
}

static bool greater(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data[0] > e2->data[0];
}

static void memswap(void *m1, void *m2, size_t size){
    unsigned char *a = (unsigned char*)m1;
    unsigned char *b = (unsigned char*)m2;
    while (size--) {
        *b ^= *a ^= *b ^= *a;
        a++;
        b++;
    }
}

static void swap(Element *arr, int i, int j) {
    memswap(&arr[i], &arr[j], sizeof(Element));
}

static void down(Element *arr, int size, int i, compare cmpFunc) {
    for (int k = 2 * i + 1; k < size; k = 2 * k + 1) {
        if (k + 1 < size && cmpFunc(&arr[k], &arr[k + 1])) {
            k++;
        }
        if (cmpFunc(&arr[k], &arr[(k - 1) / 2])) {
            break;
        }
        swap(arr, k, (k - 1) / 2);
    }
}

PriorityQueue *createPriorityQueue(compare cmpFunc) {
    PriorityQueue *obj = (PriorityQueue *)malloc(sizeof(PriorityQueue));
    obj->capacity = MIN_QUEUE_SIZE;
    obj->arr = (Element *)malloc(sizeof(Element) * obj->capacity);
    obj->queueSize = 0;
    obj->lessFunc = cmpFunc;
    return obj;
}

void heapfiy(PriorityQueue *obj) {
    for (int i = obj->queueSize / 2 - 1; i >= 0; i--) {
        down(obj->arr, obj->queueSize, i, obj->lessFunc);
    }
}

void enQueue(PriorityQueue *obj, Element *e) {
    if (obj->queueSize == obj->capacity) {
        obj->capacity *= 2;
        obj->arr = realloc(obj->arr, sizeof(Element) * obj->capacity);
    }
    memcpy(&obj->arr[obj->queueSize], e, sizeof(Element));
    for (int i = obj->queueSize; i > 0 && obj->lessFunc(&obj->arr[(i - 1) / 2], &obj->arr[i]); i = (i - 1) / 2) {
        swap(obj->arr, i, (i - 1) / 2);
    }
    obj->queueSize++;
}

Element* deQueue(PriorityQueue *obj) {
    swap(obj->arr, 0, obj->queueSize - 1);
    down(obj->arr, obj->queueSize - 1, 0, obj->lessFunc);
    Element *e =  &obj->arr[obj->queueSize - 1];
    obj->queueSize--;
    return e;
}

bool isEmpty(const PriorityQueue *obj) {
    return obj->queueSize == 0;
}

Element* front(const PriorityQueue *obj) {
    if (obj->queueSize == 0) {
        return NULL;
    } else {
        return &obj->arr[0];
    }
}

void clear(PriorityQueue *obj) {
    obj->queueSize = 0;
}

int size(const PriorityQueue *obj) {
    return obj->queueSize;
}

void freeQueue(PriorityQueue *obj) {
    free(obj->arr);
    free(obj);
}

typedef struct Edge {
    int v;
    int dis;
    struct Edge* next;
} Edge;

typedef struct {
    Edge* head;
} GraphNode;

void addEdge(GraphNode* graph, int u, int v, int dis) {
    Edge* edge = (Edge*)malloc(sizeof(Edge));
    edge->v = v;
    edge->dis = dis;
    edge->next = graph[u].head;
    graph[u].head = edge;
}

int minScore(int n, int** roads, int roadsSize, int* roadsColSize) {
    GraphNode* graph = (GraphNode*)calloc(n + 1, sizeof(GraphNode));
    bool* vis = (bool*)calloc(n + 1, sizeof(bool));
    int ans = INT_MAX;
    PriorityQueue* pq = createPriorityQueue(greater);
    
    for (int i = 0; i < roadsSize; i++) {
        int u = roads[i][0];
        int v = roads[i][1];
        int dis = roads[i][2];
        addEdge(graph, u, v, dis);
        addEdge(graph, v, u, dis);
        
        if (isEmpty(pq) && (u == 1 || v == 1)) {
            Element* e = createElement(dis, v);
            enQueue(pq, e);
            free(e);
        }
    }
    
    while (!isEmpty(pq)) {
        Element* top = front(pq);
        int dis = top->data[0];
        int u = top->data[1];
        deQueue(pq);
        
        if (vis[u]) {
            continue;
        }
        ans = fmin(ans, dis);
        vis[u] = true;
        
        Edge* edge = graph[u].head;
        while (edge) {
            if (!vis[edge->v]) {
                Element* e = createElement(edge->dis, edge->v);
                enQueue(pq, e);
                free(e);
            }
            edge = edge->next;
        }
    }
    
    for (int i = 0; i <= n; i++) {
        Edge* edge = graph[i].head;
        while (edge) {
            Edge* temp = edge;
            edge = edge->next;
            free(temp);
        }
    }
    free(graph);
    free(vis);
    freeQueue(pq);
    
    return ans;
}
```

```Python
class Solution:
    def minScore(self, n: int, roads: list[list[int]]) -> int:
        graph = [[] for _ in range(n + 1)]
        vis = [False] * (n + 1)

        ans = math.inf
        pq = []

        for u, v, dis in roads:
            graph[u].append((v, dis))
            graph[v].append((u, dis))

            if not pq and (u == 1 or v == 1):
                heapq.heappush(pq, (dis, v))

        while pq:
            dis, u = heapq.heappop(pq)

            if vis[u]:
                continue

            if dis < ans:
                ans = dis
            vis[u] = True

            for v, next_dis in graph[u]:
                if not vis[v]:
                    heapq.heappush(pq, (next_dis, v))

        return ans

```

```CSharp
public class Solution {
    public int MinScore(int n, int[][] roads) {
        var graph = new List<(int v, int dis)>[n + 1];
        for (int i = 0; i <= n; i++) {
            graph[i] = new List<(int v, int dis)>();
        }
        var vis = new bool[n + 1];

        int ans = int.MaxValue;
        var pq = new PriorityQueue<int, int>();

        foreach (var road in roads) {
            int u = road[0], v = road[1], dis = road[2];
            graph[u].Add((v, dis));
            graph[v].Add((u, dis));

            if (pq.Count == 0 && (u == 1 || v == 1)) {
                pq.Enqueue(v, dis);
            }
        }

        while (pq.Count > 0) {
            pq.TryDequeue(out int u, out int dis);

            if (vis[u]) {
                continue;
            }

            ans = Math.Min(ans, dis);
            vis[u] = true;

            foreach (var edge in graph[u]) {
                if (!vis[edge.v]) {
                    pq.Enqueue(edge.v, edge.dis);
                }
            }
        }

        return ans;
    }
}
```

```JavaScript
var minScore = function(n, roads) {
    const graph = Array.from({ length: n + 1 }, () => []);
    const vis = Array(n + 1).fill(false);

    let ans = Infinity;
    const pq = new MinPriorityQueue((e) => e.dis);

    for (const [u, v, dis] of roads) {
        graph[u].push({ v: v, dis });
        graph[v].push({ v: u, dis });

        if (pq.isEmpty() && (u === 1 || v === 1)) {
            pq.enqueue({ v, dis });
        }
    }

    while (!pq.isEmpty()) {
        const { dis, v: u } = pq.dequeue();

        if (vis[u]) {
            continue;
        }

        ans = Math.min(ans, dis);
        vis[u] = true;

        for (const edge of graph[u]) {
            if (!vis[edge.v]) {
                pq.enqueue(edge);
            }
        }
    }

    return ans;
};
```

```TypeScript
function minScore(n: number, roads: number[][]): number {
    type Edge = { v: number, dis: number };
    const graph = Array.from<unknown, Edge[]>({ length: n + 1 }, () => []);
    const vis = Array(n + 1).fill(false);

    let ans = Infinity;
    const pq = new MinPriorityQueue<Edge>((e) => e.dis);

    for (const [u, v, dis] of roads) {
        graph[u].push({ v: v, dis });
        graph[v].push({ v: u, dis });

        if (pq.isEmpty() && (u === 1 || v === 1)) {
            pq.enqueue({ v, dis });
        }
    }

    while (!pq.isEmpty()) {
        const { dis, v: u } = pq.dequeue();

        if (vis[u]) {
            continue;
        }

        ans = Math.min(ans, dis);
        vis[u] = true;

        for (const edge of graph[u]) {
            if (!vis[edge.v]) {
                pq.enqueue(edge);
            }
        }
    }

    return ans;
};
```

```Go
type edge struct {
    v   int
    dis int
}

type minHeap []edge

func (h minHeap) Len() int           { return len(h) }
func (h minHeap) Less(i, j int) bool { return h[i].dis < h[j].dis }
func (h minHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }

func (h *minHeap) Push(x interface{}) {
    *h = append(*h, x.(edge))
}

func (h *minHeap) Pop() interface{} {
    old := *h
    n := len(old)
    x := old[n-1]
    *h = old[0 : n-1]
    return x
}

func minScore(n int, roads [][]int) int {
    graph := make([][]edge, n+1)
    vis := make([]bool, n+1)

    ans := math.MaxInt32
    pq := &minHeap{}
    heap.Init(pq)

    for _, road := range roads {
        u, v, dis := road[0], road[1], road[2]
        graph[u] = append(graph[u], edge{v: v, dis: dis})
        graph[v] = append(graph[v], edge{v: u, dis: dis})

        if pq.Len() == 0 && (u == 1 || v == 1) {
            heap.Push(pq, edge{v: v, dis: dis})
        }
    }

    for pq.Len() > 0 {
        curr := heap.Pop(pq).(edge)
        u := curr.v
        dis := curr.dis

        if vis[u] {
            continue
        }

        if dis < ans {
            ans = dis
        }
        vis[u] = true

        for _, e := range graph[u] {
            if !vis[e.v] {
                heap.Push(pq, e)
            }
        }
    }

    return ans
}
```

```Rust
type edge struct {
    v   int
    dis int
}

type minHeap []edge

func (h minHeap) Len() int           { return len(h) }
func (h minHeap) Less(i, j int) bool { return h[i].dis < h[j].dis }
func (h minHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }

func (h *minHeap) Push(x interface{}) {
    *h = append(*h, x.(edge))
}

func (h *minHeap) Pop() interface{} {
    old := *h
    n := len(old)
    x := old[n-1]
    *h = old[0 : n-1]
    return x
}

func minScore(n int, roads [][]int) int {
    graph := make([][]edge, n+1)
    vis := make([]bool, n+1)

    ans := math.MaxInt32
    pq := &minHeap{}
    heap.Init(pq)

    for _, road := range roads {
        u, v, dis := road[0], road[1], road[2]
        graph[u] = append(graph[u], edge{v: v, dis: dis})
        graph[v] = append(graph[v], edge{v: u, dis: dis})

        if pq.Len() == 0 && (u == 1 || v == 1) {
            heap.Push(pq, edge{v: v, dis: dis})
        }
    }

    for pq.Len() > 0 {
        curr := heap.Pop(pq).(edge)
        u := curr.v
        dis := curr.dis

        if vis[u] {
            continue
        }

        if dis < ans {
            ans = dis
        }
        vis[u] = true

        for _, e := range graph[u] {
            if !vis[e.v] {
                heap.Push(pq, e)
            }
        }
    }

    return ans
}
```

**复杂度分析**

- 时间复杂度：$O(n+m\log m)$，其中 $n$ 是给定无向图的顶点总数，$m$ 是给定无向图的边数，也即 $roads$ 的长度。初始化辅助数组需要 $O(n)$，建图需要 $O(m)$，边的入队出队上限为 $O(m)$，堆操作需要 $O(\log m)$，故遍历需要 $O(m\log m)$，总共需要 $O(n+m\log m)$。
- 空间复杂度：$O(n+m)$。邻接表需要 $O(n+m)$，优先队列最多需要 $O(m)$，辅助数组 $vis$ 需要 $O(n)$。
