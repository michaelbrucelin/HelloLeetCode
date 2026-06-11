### [给边赋权值的方案数 I](https://leetcode.cn/problems/number-of-ways-to-assign-edge-weights-i/solutions/3981974/gei-bian-fu-quan-zhi-de-fang-an-shu-i-by-7coj/)

#### 方法一：深度优先搜索 + 数学

**思路与算法**

给定一颗以 $1$ 为根的树，需要找到深度最深的节点 $x$，然后计算将从 $1$ 到 $x$ 的路径权值之和为奇数的赋值方案数。每条边可以赋值 $1$ 或 $2$。由于权值 $2$ 不影响奇偶性，路径和的奇偶性仅取决于权值为 $1$ 的边的数量是否为奇数。

因此，我们先使用深度优先搜索算法计算出节点 $1$ 到节点 $x$ 的距离 $max\_dep$，然后计算从 $max\_dep$ 条边中选择奇数条边的方案数。

设 $d[i][0]$ 为从 $i$ 条边中选择偶数条边赋值为 $1$ 的方案数，$d[i][1]$ 为从 $i$ 条边中选择奇数条边赋值为 $1$ 的方案数。那么当 $i\ge 1$ 时有递推方程：

$$d[i][1]=d[i-1][0]+d[i-1][1] \\ d[i][0]=d[i-1][0]+d[i-1][1]$$

以 $d[i][1]$ 为例，第 $i$ 条边赋值为 $1$ 和赋值为 $2$ 两种方案，对应于 $d[i-1][0]$ 和 $d[i-1][1]$。$d[i][0]$ 同理。初始条件为 $d[0][0]=1$ 和 $d[0][1]=0$。最终答案为 $d[max\_dep][1]$。

容易发现当 $i\ge 1$ 时，$d[i][1]$ 是永远等于 $d[i][0]$ 的，而 $d[max\_dep][0]+d[max\_dep][1]$ 等于 $2^{max\_dep}$，因此最终答案为 $2^{max\_dep-1}$。在本题中可以使用递推计算该值，也可以使用快速幂来计算该值。

**代码**

```C++
class Solution {
    static constexpr int mod = 1e9 + 7;
    int qpow(int x, int y) {
        int res = 1;
        for (; y; y >>= 1) {
            if (y & 1) {
                res = 1ll * res * x % mod;
            }
            x = 1ll * x * x % mod;
        }
        return res;
    }
    int dfs(vector<vector<int>> &g, int x, int f) {
        int max_dep = 0;
        for (auto &y : g[x]) {
            if (y == f) {
                continue;
            }
            max_dep = max(max_dep, dfs(g, y, x) + 1);
        }
        return max_dep;
    }
public:
    int assignEdgeWeights(vector<vector<int>>& edges) {
        int n = edges.size() + 1;
        vector<vector<int>> g(n + 1);
        for (auto &e : edges) {
            int u = e[0];
            int v = e[1];
            g[u].emplace_back(v);
            g[v].emplace_back(u);
        }
        int max_dep = dfs(g, 1, 0);
        return qpow(2, max_dep - 1);
    }
};
```

```Rust
impl Solution {
    const MOD: i64 = 1_000_000_007;

    fn qpow(mut x: i64, mut y: i64) -> i64 {
        let mut res = 1;
        while y > 0 {
            if y & 1 == 1 {
                res = (res * x) % Self::MOD;
            }
            x = (x * x) % Self::MOD;
            y >>= 1;
        }
        res
    }

    fn dfs(g: &Vec<Vec<usize>>, x: usize, f: usize) -> i64 {
        let mut max_dep = 0;
        for &y in &g[x] {
            if y == f {
                continue;
            }
            max_dep = max_dep.max(Self::dfs(g, y, x) + 1);
        }
        max_dep
    }

    pub fn assign_edge_weights(edges: Vec<Vec<i32>>) -> i32 {
        let n = edges.len() + 1;
        let mut g = vec![vec![]; n + 1];
        for e in edges {
            let u = e[0] as usize;
            let v = e[1] as usize;
            g[u].push(v);
            g[v].push(u);
        }
        let max_dep = Self::dfs(&g, 1, 0);
        Self::qpow(2, max_dep - 1) as i32
    }
}
```

```Python
class Solution:
    MOD = 10**9 + 7

    def dfs(self, g: list, x: int, f: int) -> int:
        max_dep = 0
        for y in g[x]:
            if y == f:
                continue
            max_dep = max(max_dep, self.dfs(g, y, x) + 1)
        return max_dep

    def assignEdgeWeights(self, edges: List[List[int]]) -> int:
        n = len(edges) + 1
        g = [[] for _ in range(n + 1)]
        for u, v in edges:
            g[u].append(v)
            g[v].append(u)
        max_dep = self.dfs(g, 1, 0)
        return pow(2, max_dep - 1, self.MOD)
```

```Java
class Solution {
    private static final int MOD = 1_000_000_007;

    private int qpow(int x, int y) {
        long res = 1;
        long base = x;
        while (y > 0) {
            if ((y & 1) == 1) {
                res = (res * base) % MOD;
            }
            base = (base * base) % MOD;
            y >>= 1;
        }
        return (int) res;
    }

    private int dfs(List<List<Integer>> g, int x, int f) {
        int maxDep = 0;
        for (int y : g.get(x)) {
            if (y == f) continue;
            maxDep = Math.max(maxDep, dfs(g, y, x) + 1);
        }
        return maxDep;
    }

    public int assignEdgeWeights(int[][] edges) {
        int n = edges.length + 1;
        List<List<Integer>> g = new ArrayList<>();
        for (int i = 0; i <= n; i++) {
            g.add(new ArrayList<>());
        }
        for (int[] e : edges) {
            int u = e[0];
            int v = e[1];
            g.get(u).add(v);
            g.get(v).add(u);
        }
        int maxDep = dfs(g, 1, 0);
        return qpow(2, maxDep - 1);
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1_000_000_007;

    private int QPow(int x, int y) {
        long res = 1;
        long baseVal = x;
        while (y > 0) {
            if ((y & 1) == 1) {
                res = (res * baseVal) % MOD;
            }
            baseVal = (baseVal * baseVal) % MOD;
            y >>= 1;
        }
        return (int)res;
    }

    private int Dfs(List<List<int>> g, int x, int f) {
        int maxDep = 0;
        foreach (int y in g[x]) {
            if (y == f) continue;
            maxDep = System.Math.Max(maxDep, Dfs(g, y, x) + 1);
        }
        return maxDep;
    }

    public int AssignEdgeWeights(int[][] edges) {
        int n = edges.Length + 1;
        var g = new List<List<int>>();
        for (int i = 0; i <= n; i++) {
            g.Add(new List<int>());
        }
        foreach (var e in edges) {
            int u = e[0];
            int v = e[1];
            g[u].Add(v);
            g[v].Add(u);
        }
        int maxDep = Dfs(g, 1, 0);
        return QPow(2, maxDep - 1);
    }
}
```

```Go
const MOD = 1_000_000_007

func dfs(g [][]int, x, f int) int {
	maxDep := 0

	for _, y := range g[x] {
		if y == f {
			continue
		}
		maxDep = max(maxDep, dfs(g, y, x)+1)
	}

	return maxDep
}

func assignEdgeWeights(edges [][]int) int {
	n := len(edges) + 1

	g := make([][]int, n+1)
	for _, e := range edges {
		u, v := e[0], e[1]
		g[u] = append(g[u], v)
		g[v] = append(g[v], u)
	}

	maxDep := dfs(g, 1, 0)
	return powMod(2, maxDep-1)
}

func powMod(a, b int) int {
	res := 1
	a %= MOD

	for b > 0 {
		if b&1 == 1 {
			res = res * a % MOD
		}
		a = a * a % MOD
		b >>= 1
	}

	return res
}
```

```C
#define MOD 1000000007

typedef struct Node {
    int val;
    struct Node* next;
} Node;

typedef struct {
    Node** heads;
    int size;
} Graph;

void addEdge(Graph* g, int u, int v) {
    Node* node = (Node*)malloc(sizeof(Node));
    node->val = v;
    node->next = g->heads[u];
    g->heads[u] = node;
}

int qpow(int x, int y) {
    long long res = 1;
    long long base = x;
    while (y) {
        if (y & 1) {
            res = (res * base) % MOD;
        }
        base = (base * base) % MOD;
        y >>= 1;
    }
    return (int)res;
}

int dfs(Graph* g, int x, int f) {
    int maxDep = 0;
    Node* cur = g->heads[x];
    while (cur) {
        int y = cur->val;
        if (y != f) {
            int dep = dfs(g, y, x) + 1;
            if (dep > maxDep) maxDep = dep;
        }
        cur = cur->next;
    }
    return maxDep;
}

int assignEdgeWeights(int** edges, int edgesSize, int* edgesColSize) {
    int n = edgesSize + 1;
    Graph g;
    g.heads = (Node**)calloc(n + 1, sizeof(Node*));
    g.size = n + 1;

    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0];
        int v = edges[i][1];
        addEdge(&g, u, v);
        addEdge(&g, v, u);
    }

    int maxDep = dfs(&g, 1, 0);
    int result = qpow(2, maxDep - 1);

    for (int i = 0; i <= n; i++) {
        Node* cur = g.heads[i];
        while (cur) {
            Node* tmp = cur;
            cur = cur->next;
            free(tmp);
        }
    }
    free(g.heads);

    return result;
}
```

```JavaScript
var assignEdgeWeights = function(edges) {
    const MOD = 1000000007n;

    const qpow = (x, y) => {
        let res = 1n;
        let base = BigInt(x);
        let exp = y;
        while (exp > 0) {
            if (exp & 1) {
                res = (res * base) % MOD;
            }
            base = (base * base) % MOD;
            exp >>= 1;
        }
        return Number(res);
    };

    const dfs = (g, x, f) => {
        let maxDep = 0;
        for (const y of g[x]) {
            if (y === f) continue;
            maxDep = Math.max(maxDep, dfs(g, y, x) + 1);
        }
        return maxDep;
    };

    const n = edges.length + 1;
    const g = Array.from({ length: n + 1 }, () => []);

    for (let i = 0; i < edges.length; i++) {
        const u = edges[i][0];
        const v = edges[i][1];
        g[u].push(v);
        g[v].push(u);
    }

    const maxDep = dfs(g, 1, 0);
    return qpow(2, maxDep - 1);
};
```

```TypeScript
var assignEdgeWeights = function(edges: number[][]): number {
    const MOD: bigint = 1000000007n;

    const qpow = (x: number, y: number): number => {
        let res: bigint = 1n;
        let base: bigint = BigInt(x);
        let exp: number = y;

        while (exp > 0) {
            if (exp & 1) {
                res = (res * base) % MOD;
            }
            base = (base * base) % MOD;
            exp >>= 1;
        }
        return Number(res);
    };

    const dfs = (g: number[][], x: number, f: number): number => {
        let maxDep: number = 0;
        for (const y of g[x]) {
            if (y === f) continue;
            maxDep = Math.max(maxDep, dfs(g, y, x) + 1);
        }
        return maxDep;
    };

    const n: number = edges.length + 1;
    const g: number[][] = Array.from({ length: n + 1 }, () => []);

    for (let i = 0; i < edges.length; i++) {
        const u: number = edges[i][0];
        const v: number = edges[i][1];
        g[u].push(v);
        g[v].push(u);
    }

    const maxDep: number = dfs(g, 1, 0);
    return qpow(2, maxDep - 1);
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是树的节点数。深度优先搜索的时间复杂度是 $O(n)$，快速幂的时间复杂度是 $O(\log n)$。
- 空间复杂度：$O(n)$。
