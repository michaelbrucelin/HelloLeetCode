### [在带权树网络中统计可连接服务器对数目](https://leetcode.cn/problems/count-pairs-of-connectable-servers-in-a-weighted-tree-network/solutions/2796531/zai-dai-quan-shu-wang-luo-zhong-tong-ji-j8he9/)

#### 方法一：根枚举

**思路与算法**

我们可以将每个服务器等价于树中的节点，根据题意可知，如果两个节点 $a,b$ 和 节点 $c$ 满足以下条件，那么节点 $a$ 和 $b$ 是通过 $c$ **可连接**。

- $a < b$，$a \neq c$ 且 $b \neq c$；
- 从 $c$ 到 $a$ 的距离是可以被 $\textit{signalSpeed}$ 整除的；
- 从 $c$ 到 $b$ 的距离是可以被 $\textit{signalSpeed}$ 整除的；
- 从 $c$ 到 $b$ 的路径与从 $c$ 到 $a$ 的路径没有任何公共边；

由于 $a$ 与 $b$ 可以互换，$a$ 与 $b$ 只需满足 $a \neq b$ 即可。题目要求求出通过每个节点 $x$ 的**可连接**对数，此时我们可以枚举以 $x$ 为根结点的树，以 $x$ 为根节点的子树一定满足：

- 如果 $a$ 与 $b$ 属于 $x$ 的不同子树，从 $x$ 到 $b$ 的路径与从 $x$ 到 $a$ 的路径一定没有公共边；如果 $a$ 与 $b$ 属于 $x$ 的同一个子树，从 $x$ 到 $b$ 的路径与从 $i$ 到 $a$ 的路径一定存在公共边；
- 如果 $a$ 与 $b$ 属于 $x$ 的不同子树，且满足 $x$ 到 $b$ 的距离与 $x$ 到 $a$ 的距离都能被 $\textit{signalSpeed}$ 整除，则 $a$ 与 $b$ 可以构成**连接对**；

根据以上分析可知，通过 $x$ 节点的**连接对数**即等于以 $x$ 为根节点的任意两个子树中满足距离被 $\textit{signalSpeed}$ 整除的节点数目的乘积之和。我们枚举以 $x$ 为根节点的树，此时分别计算不同子树中存在满足到根节点 $x$ 的距离被 $\textit{signalSpeed}$ 整除的节点数目，假设此时含有 $k$ 个子树，每个子树中含有满足**距离被整数**的节点数目为 $c_0, c_1, c_2, \cdots,c_{k-1}$，根据组合数可知，此时通过节点 $x$ 可连接的节点对数即为：

$$C = \sum_{i < j}c_i \times c_j = \sum_{j=0}^{k-1}(c_i \times \sum_{t=0}^{j-1}c_t)$$

实际计算过程中，枚举每个节点 $x$ 为根节点：

- 用 $\textit{pre}$ 表示当前已经遍历过的到结点 $i$ 的距离可以被 $\textit{signalSpeed}$ 整除的结点数目，初始时 $\textit{pre} = 0$；
- 枚举节点 $x$ 的每一个相邻的节点 $v$，计算以 $v$ 为根节点的子树中含有到 $i$ 的距离可以被整除的节点数目 $\textit{cnt}$，此时可以通过深度优先搜索来实现，每次递归时会传递节点 $i$ 到当前节点的距离对 $\textit{signalSpeed}$ 取模后的结果 $\textit{curr}$，如果 $\textit{curr} = 0$ 则计数加 $1$；
- 每次计算完时，根据上述公式可以知道节点对数会增加 $\textit{pre} \times \textit{cnt}$，当前可被整除的节点数目增加 $\textit{cnt}$；
- 遍历完成后，保存结果返回即可；

**代码**

```C++
class Solution {
public:
    vector<int> countPairsOfConnectableServers(vector<vector<int>>& edges, int signalSpeed) {
        int n = edges.size() + 1;
        vector<vector<pair<int, int>>> graph(n);
        
        for (auto e : edges) {
            graph[e[0]].emplace_back(e[1], e[2]);
            graph[e[1]].emplace_back(e[0], e[2]);
        }
        function<int(int, int, int)> dfs = [&](int p, int root, int curr) -> int {
            int res = 0;
            if (curr == 0) {
                res++;
            }
            for (auto &[v, cost] : graph[p]) {
                if (v != root) {
                    res += dfs(v, p, (curr + cost) % signalSpeed);
                }
            }
            return res;
        };
        
        vector<int> res(n);
        for (int i = 0; i < n; i++) {
            int pre = 0;
            for (auto &[v, cost] : graph[i]) {
                int cnt = dfs(v, i, cost % signalSpeed);
                res[i] += pre * cnt;
                pre += cnt;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int[] countPairsOfConnectableServers(int[][] edges, int signalSpeed) {
        int n = edges.length + 1;
        List<int[]>[] graph = new ArrayList[n];
        Arrays.setAll(graph, i -> new ArrayList<>());

        for (int[] e : edges) {
            int u = e[0];
            int v = e[1];
            int w = e[2];
            graph[u].add(new int[]{v, w});
            graph[v].add(new int[]{u, w});
        }

        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            int pre = 0;
            for (int[] e : graph[i]) {
                int cnt = dfs(e[0], i, e[1] % signalSpeed, signalSpeed, graph);
                res[i] += pre * cnt;
                pre += cnt;
            }
        }
        return res;
    }

    private int dfs(int p, int root, int curr, int signalSpeed, List<int[]>[] graph) {
        int res = 0;
        if (curr == 0) {
            res++;
        }
        for (int[] e : graph[p]) {
            int v = e[0];
            int cost = e[1];
            if (v != root) {
                res += dfs(v, p, (curr + cost) % signalSpeed, signalSpeed, graph);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int[] CountPairsOfConnectableServers(int[][] edges, int signalSpeed) {
        int n = edges.Length + 1;
        IList<int[]>[] graph = new IList<int[]>[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new List<int[]>();
        }

        foreach (int[] e in edges) {
            int u = e[0];
            int v = e[1];
            int w = e[2];
            graph[u].Add(new int[]{v, w});
            graph[v].Add(new int[]{u, w});
        }

        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            int pre = 0;
            foreach (int[] e in graph[i]) {
                int cnt = DFS(e[0], i, e[1] % signalSpeed, signalSpeed, graph);
                res[i] += pre * cnt;
                pre += cnt;
            }
        }
        return res;
    }

    private int DFS(int p, int root, int curr, int signalSpeed, IList<int[]>[] graph) {
        int res = 0;
        if (curr == 0) {
            res++;
        }
        foreach (int[] e in graph[p]) {
            int v = e[0];
            int cost = e[1];
            if (v != root) {
                res += DFS(v, p, (curr + cost) % signalSpeed, signalSpeed, graph);
            }
        }
        return res;
    }
}
```

```Go
func countPairsOfConnectableServers(edges [][]int, signalSpeed int) []int {
    n := len(edges) + 1
    graph := make([][][]int, n)
    for _, e := range edges {
        u, v, w := e[0], e[1], e[2]
        graph[u] = append(graph[u], []int{v, w})
        graph[v] = append(graph[v], []int{u, w})
    }

    var dfs func(int, int, int) int
    dfs = func(p, root, curr int) int {
        res := 0
        if curr == 0 {
            res++
        }
        for _, e := range graph[p] {
            v, cost := e[0], e[1]
            if v != root {
                res += dfs(v, p, (curr + cost) % signalSpeed)
            }
        }
        return res
    }

    res := make([]int, n)
    for i := 0; i < n; i++ {
        pre := 0
        for _, e := range graph[i] {
            v, cost := e[0], e[1]
            cnt := dfs(v, i, cost % signalSpeed)
            res[i] += pre * cnt
            pre += cnt
        }
    }
    return res
}
```

```Python
class Solution:
    def countPairsOfConnectableServers(self, edges: List[List[int]], signalSpeed: int) -> List[int]:
        n = len(edges) + 1
        graph = [[] for _ in range(n)]
        for u, v, w in edges:
            graph[u].append((v, w))
            graph[v].append((u, w))

        def dfs(p: int, root: int, curr: int) -> int:
            res = 0
            if curr == 0:
                res += 1
            for v, cost in graph[p]:
                if v != root:
                    res += dfs(v, p, (curr + cost) % signalSpeed)
            return res

        res = [0] * n
        for i in range(n):
            pre = 0
            for v, cost in graph[i]:
                cnt = dfs(v, i, cost % signalSpeed)
                res[i] += pre * cnt
                pre += cnt
        return res
```

```C
typedef struct Node {
    int to;
    int weight;
    struct Node *next;
} Node;

Node *creatNode(int to, int weight) {
    Node *obj = (Node *)malloc(sizeof(Node));
    obj->to = to;
    obj->weight = weight;
    obj->next = NULL;
    return obj;
}

void freeList(Node *list) {
    while (list) {
        Node *p = list;
        list = list->next;
        free(p);
    }
}

int dfs(int p, int root, int curr, int signalSpeed, Node **graph) {
    int res = 0;
    if (curr == 0) {
        res++;
    }
    for (Node *pEntry = graph[p]; pEntry; pEntry = pEntry->next) {
        int v = pEntry->to;
        int cost = pEntry->weight;
        if (v != root) {
            res += dfs(v, p, (curr + cost) % signalSpeed, signalSpeed, graph);
        }
    }
    return res;
};

int* countPairsOfConnectableServers(int** edges, int edgesSize, int* edgesColSize, int signalSpeed, int* returnSize) {
    int n = edgesSize + 1;
    Node *graph[n];
    for (int i = 0; i < n; i++) {
        graph[i] = NULL;
    }
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0], y = edges[i][1], weight = edges[i][2];
        Node *px = creatNode(x, weight);
        px->next = graph[y];
        graph[y] = px;
        Node *py = creatNode(y, weight);
        py->next = graph[x];
        graph[x] = py;
    }
    
    int *res = (int *)malloc(sizeof(int) * n);
    memset(res, 0, sizeof(int) * n);
    *returnSize = n;
    for (int i = 0; i < n; i++) {
        int pre = 0;
        for (Node *pEntry = graph[i]; pEntry; pEntry = pEntry->next) {
            int v = pEntry->to, cost = pEntry->weight;
            int cnt = dfs(v, i, cost % signalSpeed, signalSpeed, graph);
            res[i] += pre * cnt;
            pre += cnt;
        }
    }

    for (int i = 0; i < n; i++) {
        freeList(graph[i]);
    }
    return res;
}
```

```JavaScript
var countPairsOfConnectableServers = function(edges, signalSpeed) {
    const n = edges.length + 1;
    const graph = Array.from({ length: n }, () => []);
    for (const [u, v, w] of edges) {
        graph[u].push([v, w]);
        graph[v].push([u, w]);
    }

    const dfs = (p, root, curr) => {
        let res = 0;
        if (curr === 0) {
            res++;
        }
        for (const [v, cost] of graph[p]) {
            if (v !== root) {
                res += dfs(v, p, (curr + cost) % signalSpeed);
            }
        }
        return res;
    };

    const res = Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        let pre = 0;
        for (const [v, cost] of graph[i]) {
            const cnt = dfs(v, i, cost % signalSpeed);
            res[i] += pre * cnt;
            pre += cnt;
        }
    }
    return res;
};
```

```TypeScript
function countPairsOfConnectableServers(edges: number[][], signalSpeed: number): number[] {
    const n = edges.length + 1;
    const graph: Array<Array<[number, number]>> = Array.from({ length: n }, () => []);
    for (const [u, v, w] of edges) {
        graph[u].push([v, w]);
        graph[v].push([u, w]);
    }
    const dfs = (p: number, root: number, curr: number): number => {
        let res = 0;
        if (curr === 0) {
            res++;
        }
        for (const [v, cost] of graph[p]) {
            if (v !== root) {
                res += dfs(v, p, (curr + cost) % signalSpeed);
            }
        }
        return res;
    };

    const res: number[] = Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        let pre = 0;
        for (const [v, cost] of graph[i]) {
            const cnt = dfs(v, i, cost % signalSpeed);
            res[i] += pre * cnt;
            pre += cnt;
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn count_pairs_of_connectable_servers(edges: Vec<Vec<i32>>, signal_speed: i32) -> Vec<i32> {
        let n = edges.len() + 1;
        let mut graph = vec![Vec::new(); n];
        for edge in edges.iter() {
            let x = edge[0] as usize;
            let y = edge[1] as usize;
            let cost = edge[2];
            graph[x].push((y, cost));
            graph[y].push((x, cost));
        }

        fn dfs(graph: &Vec<Vec<(usize, i32)>>, p: usize, root: usize, curr: i32, signal_speed: i32) -> i32 {
            let mut res = 0;
            if curr == 0 {
                res += 1;
            }
            for &(v, cost) in &graph[p] {
                if v != root {
                    res += dfs(graph, v, p, (curr + cost) % signal_speed, signal_speed);
                }
            }
            res
        }
        
        let mut ans = vec![0; n];
        for i in 0..n {
            let mut pre = 0;
            for &(v, cost) in &graph[i] {
                let cnt = dfs(&graph, v, i, cost % signal_speed, signal_speed);
                ans[i] += pre * cnt;
                pre += cnt;
            } 
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 表示节点的数目，即等于 $\textit{edges}$ 的长度加 $1$。每次枚举 $i$ 时，需要遍历以 $i$ 为根的树中的所有节点，需要的时间为 $O(n)$，一共需要枚举 $n$ 次，总的时间复杂度即为 $O(n^2)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示节点的数目，即等于 $\textit{edges}$ 的长度加 $1$。用邻接表存储图的关系，一共存在 $n$ 个节点，且含有 $n-1$ 条边，需要的空间为 $O(n)$。
