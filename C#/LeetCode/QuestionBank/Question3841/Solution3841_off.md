### [查询树上回文路径](https://leetcode.cn/problems/palindromic-path-queries-in-a-tree/solutions/4043910/cha-xun-shu-shang-hui-wen-lu-jing-by-lee-s72r/)

#### 方法一：树状数组 + 最近公共祖先

**思路与算法**

一条路径上的字符能够重新排列成回文串，当且仅当至多有一种字符出现奇数次。由于本题只有 $26$ 种小写英文字母，我们可以用一个 $26$ 位二进制数表示各个字母出现次数的奇偶性：从低到高，第 $i$ 位为 $1$ 表示第 $i$ 个字母出现了奇数次，为 $0$ 表示出现了偶数次。两个二进制数按位异或，就能得到两组字符合并后各个字母出现次数的奇偶性。因此，记 $mask[u]$ 为节点 $u$ 上字符对应的二进制数，其中只有该字符对应的二进制位为 $1$。一条路径上所有节点的 $mask$ 的异或结果，就是这条路径上各个字母出现次数的奇偶性。只要结果中至多有一个二进制位为 $1$，就说明路径上的字符可以重新排列成回文串。

以节点 $0$ 为根，记 $pref[u]$ 为从根节点到节点 $u$ 的路径上所有节点的 $mask$ 的异或结果。对于节点 $u$ 和 $v$，设它们的最近公共祖先为 $w$。将 $pref[u]$ 和 $pref[v]$ 异或，从根节点到 $w$ 的所有节点都出现了两次，因此会相互抵消。剩下的节点恰好构成从 $u$ 到 $v$ 的路径，只是缺少了节点 $w$。因此，从 $u$ 到 $v$ 的路径异或结果为：

$$pref[u]\oplus pref[v]\oplus mask[w]$$

接下来考虑如何维护 $pref$。假设将节点 $u$ 的字符从 $a$ 修改为 $b$，修改前后的二进制数分别为 $old$ 和 $new$。由于从根节点到 $u$ 子树中任意节点的路径都会经过 $u$，因此子树中所有节点的 $pref$ 都需要异或 $old\oplus new$，而其他节点的 $pref$ 不受影响。也就是说，修改一个节点的字符，等价于对其整棵子树中所有节点的 $pref$ 进行异或修改。

为了高效地完成子树修改，我们可以通过深度优先搜索将树转换成数组。按照首次访问节点的顺序给节点编号，记 $l[u]$ 为节点 $u$ 的编号，$r[u]$ 为遍历完 $u$ 的整棵子树时的最大编号。由于深度优先搜索会连续遍历一棵子树中的所有节点，因此节点 $u$ 的子树恰好对应 $DFS$ 序上的区间 $[l[u],r[u]]$。这样，修改节点 $u$ 就转化为将区间 $[l[u],r[u]]$ 中的所有值异或同一个数，而查询 $pref[u]$ 则转化为查询位置 $l[u]$ 的值。

我们可以维护 $pref$ 的异或差分数组。将所有节点的 $pref$ 按照 $DFS$ 序排列，记其差分数组为 $D$，其中 $D[1]$ 为第一个节点的 $pref$，D[i]（$i>1$）为第 $i$ 个节点与第 $i-1$ 个节点的 $pref$ 的异或结果。根据异或运算的性质，$pref[u]$ 等于 $D$ 的前 $l[u]$ 项的异或结果。如果要将区间 $[L,R]$ 中所有节点的 $pref$ 异或 $v$，只需要将 $D[L]$ 和 $D[R+1]$ 分别异或 $v$。因此，我们可以用树状数组维护 $D$，支持单点异或修改和前缀异或查询，每次操作的时间复杂度均为 $O(\log n)$。

初始化时，对于每个节点 $u$，其 $mask[u]$ 都需要计入 $u$ 及其所有后代节点的 $pref$。由于这些节点在 $DFS$ 序上对应区间 $[l[u],r[u]]$，因此只需要将 $D[l[u]]$ 和 $D[r[u]+1]$ 分别异或 $mask[u]$。遍历所有节点完成初始化后，查询 $D$ 的前 $l[u]$ 项的异或结果，就能得到 $pref[u]$。

对于每个操作：

- $update$：设节点 $u$ 修改前后的字符掩码分别为 $old$ 和 $new$，将 $D[l[u]]$ 和 $D[r[u]+1]$ 分别异或 $old\oplus new$，再更新节点 $u$ 的字符。
- $query$：通过倍增法求出节点 $u$ 和 $v$ 的最近公共祖先 $w$，分别查询 $D$ 的前 $l[u]$ 项和前 $l[v]$ 项的异或结果，得到 $pref[u]$ 和 $pref[v]$。根据前面的公式，计算路径异或结果 $pref[u]\oplus pref[v]\oplus mask[w]$。如果结果中至多有一个二进制位为 $1$，则返回 $true$，否则返回 $false$。

**代码**

```C++
class BIT {
private:
    vector<int> tree;
    int n;

public:
    BIT(int _n): n(_n), tree(_n + 1) {}

    static int lowbit(int x) {
        return x & -x;
    }

    void update(int x, int v) {
        while (x <= n) {
            tree[x] ^= v;
            x += lowbit(x);
        }
    }

    int query(int x) {
        int ret = 0;
        while (x) {
            ret ^= tree[x];
            x -= lowbit(x);
        }
        return ret;
    }

    void updateRange(int l, int r, int v) {
        update(l, v);
        update(r + 1, v);
    }
};

class Solution {
public:
    vector<bool> palindromePath(int n, vector<vector<int>>& edges, string s, vector<string>& queries) {
        vector<vector<int>> g(n);
        for (auto& e: edges) {
            g[e[0]].push_back(e[1]);
            g[e[1]].push_back(e[0]);
        }

        int LOG = 32 - __builtin_clz(n);
        vector<vector<int>> fa(n, vector<int>(LOG));
        vector<int> dep(n), l(n), r(n);
        int timer = 0;

        auto dfs = [&](auto&& dfs, int u, int p) -> void {
            l[u] = ++timer;
            fa[u][0] = p;
            for (int v: g[u]) {
                if (v == p) {
                    continue;
                }
                dep[v] = dep[u] + 1;
                dfs(dfs, v, u);
            }
            r[u] = timer;
        };
        dfs(dfs, 0, 0);

        for (int j = 1; j < LOG; ++j) {
            for (int i = 0; i < n; ++i) {
                fa[i][j] = fa[fa[i][j - 1]][j - 1];
            }
        }

        auto lca = [&](int u, int v) {
            if (dep[u] < dep[v]) {
                swap(u, v);
            }
            int diff = dep[u] - dep[v];
            for (int i = 0; i < LOG; ++i) {
                if ((diff >> i) & 1) {
                    u = fa[u][i];
                }
            }
            if (u == v) {
                return u;
            }
            for (int i = LOG - 1; i >= 0; --i) {
                if (fa[u][i] != fa[v][i]) {
                    u = fa[u][i];
                    v = fa[v][i];
                }
            }
            return fa[u][0];
        };

        BIT bit(n + 1);
        for (int i = 0; i < n; ++i) {
            bit.updateRange(l[i], r[i], 1 << (s[i] - 'a'));
        }

        vector<bool> ans;
        for (string& q: queries) {
            stringstream ss(q);
            string op;
            ss >> op;
            if (op == "update") {
                int u;
                char c;
                ss >> u >> c;
                bit.updateRange(l[u], r[u], (1 << (s[u] - 'a')) ^ (1 << (c - 'a')));
                s[u] = c;
            } else {
                int u, v;
                ss >> u >> v;
                int w = lca(u, v);
                int mask = bit.query(l[u]) ^ bit.query(l[v]) ^ (1 << (s[w] - 'a'));
                ans.push_back(__builtin_popcount(mask) <= 1);
            }
        }
        return ans;
    }
};
```

```Python
class BIT:
    def __init__(self, n: int):
        self.n = n
        self.tree = [0] * (n + 1)

    @staticmethod
    def lowbit(x: int) -> int:
        return x & -x

    def update(self, x: int, v: int) -> None:
        while x <= self.n:
            self.tree[x] ^= v
            x += BIT.lowbit(x)

    def query(self, x: int) -> int:
        ret = 0
        while x:
            ret ^= self.tree[x]
            x -= BIT.lowbit(x)
        return ret

    def updateRange(self, l: int, r: int, v: int) -> None:
        self.update(l, v)
        self.update(r + 1, v)


class Solution:
    def palindromePath(self, n: int, edges: List[List[int]], s: str, queries: List[str]) -> List[bool]:
        g = [[] for _ in range(n)]
        for u, v in edges:
            g[u].append(v)
            g[v].append(u)

        LOG = n.bit_length()
        fa = [[0] * LOG for _ in range(n)]
        dep = [0] * n
        l = [0] * n
        r = [0] * n
        timer = 0

        def dfs(u: int, p: int) -> None:
            nonlocal timer
            timer += 1
            l[u] = timer
            fa[u][0] = p
            for v in g[u]:
                if v == p:
                    continue
                dep[v] = dep[u] + 1
                dfs(v, u)
            r[u] = timer

        dfs(0, 0)

        for j in range(1, LOG):
            for i in range(n):
                fa[i][j] = fa[fa[i][j - 1]][j - 1]

        def lca(u: int, v: int) -> int:
            if dep[u] < dep[v]:
                u, v = v, u
            diff = dep[u] - dep[v]
            for i in range(LOG):
                if (diff >> i) & 1:
                    u = fa[u][i]
            if u == v:
                return u
            for i in range(LOG - 1, -1, -1):
                if fa[u][i] != fa[v][i]:
                    u = fa[u][i]
                    v = fa[v][i]
            return fa[u][0]

        bit = BIT(n + 1)
        s = list(s)
        for i in range(n):
            bit.updateRange(l[i], r[i], 1 << (ord(s[i]) - ord("a")))

        ans = []
        for q in queries:
            op, *rest = q.split()
            if op == "update":
                u, c = int(rest[0]), rest[1]
                bit.updateRange(l[u], r[u], (1 << (ord(s[u]) - ord("a"))) ^ (1 << (ord(c) - ord("a"))))
                s[u] = c
            else:
                u, v = int(rest[0]), int(rest[1])
                w = lca(u, v)
                mask = bit.query(l[u]) ^ bit.query(l[v]) ^ (1 << (ord(s[w]) - ord("a")))
                ans.append(mask.bit_count() <= 1)
        return ans
```

```Java
class BIT {
    private int[] tree;
    private int n;

    public BIT(int _n) {
        n = _n;
        tree = new int[_n + 1];
    }

    private static int lowbit(int x) {
        return x & -x;
    }

    public void update(int x, int v) {
        while (x <= n) {
            tree[x] ^= v;
            x += lowbit(x);
        }
    }

    public int query(int x) {
        int ret = 0;
        while (x > 0) {
            ret ^= tree[x];
            x -= lowbit(x);
        }
        return ret;
    }

    public void updateRange(int l, int r, int v) {
        update(l, v);
        update(r + 1, v);
    }
}

class Solution {
    private List<List<Integer>> g;
    private int[][] fa;
    private int[] dep;
    private int[] l;
    private int[] r;
    private int timer;
    private int LOG;

    public List<Boolean> palindromePath(int n, int[][] edges, String s, String[] queries) {
        g = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            g.add(new ArrayList<>());
        }
        for (int[] e : edges) {
            g.get(e[0]).add(e[1]);
            g.get(e[1]).add(e[0]);
        }

        LOG = 32 - Integer.numberOfLeadingZeros(n);
        fa = new int[n][LOG];
        dep = new int[n];
        l = new int[n];
        r = new int[n];
        timer = 0;

        dfs(0, 0);

        for (int j = 1; j < LOG; j++) {
            for (int i = 0; i < n; i++) {
                fa[i][j] = fa[fa[i][j - 1]][j - 1];
            }
        }

        BIT bit = new BIT(n + 1);
        char[] chars = s.toCharArray();
        for (int i = 0; i < n; i++) {
            bit.updateRange(l[i], r[i], 1 << (chars[i] - 'a'));
        }

        List<Boolean> ans = new ArrayList<>();
        for (String q : queries) {
            String[] parts = q.split(" ");
            if (parts[0].equals("update")) {
                int u = Integer.parseInt(parts[1]);
                char c = parts[2].charAt(0);
                bit.updateRange(l[u], r[u], (1 << (chars[u] - 'a')) ^ (1 << (c - 'a')));
                chars[u] = c;
            } else {
                int u = Integer.parseInt(parts[1]);
                int v = Integer.parseInt(parts[2]);
                int w = lca(u, v);
                int mask = bit.query(l[u]) ^ bit.query(l[v]) ^ (1 << (chars[w] - 'a'));
                ans.add(Integer.bitCount(mask) <= 1);
            }
        }
        return ans;
    }

    private void dfs(int u, int p) {
        l[u] = ++timer;
        fa[u][0] = p;
        for (int v : g.get(u)) {
            if (v == p) {
                continue;
            }
            dep[v] = dep[u] + 1;
            dfs(v, u);
        }
        r[u] = timer;
    }

    private int lca(int u, int v) {
        if (dep[u] < dep[v]) {
            int t = u;
            u = v;
            v = t;
        }
        int diff = dep[u] - dep[v];
        for (int i = 0; i < LOG; i++) {
            if (((diff >> i) & 1) == 1) {
                u = fa[u][i];
            }
        }
        if (u == v) {
            return u;
        }
        for (int i = LOG - 1; i >= 0; i--) {
            if (fa[u][i] != fa[v][i]) {
                u = fa[u][i];
                v = fa[v][i];
            }
        }
        return fa[u][0];
    }
}
```

```CSharp
class BIT {
    private int[] tree;
    private int n;

    public BIT(int _n) {
        n = _n;
        tree = new int[_n + 1];
    }

    private static int Lowbit(int x) => x & -x;

    public void Update(int x, int v) {
        while (x <= n) {
            tree[x] ^= v;
            x += Lowbit(x);
        }
    }

    public int Query(int x) {
        int ret = 0;
        while (x > 0) {
            ret ^= tree[x];
            x -= Lowbit(x);
        }
        return ret;
    }

    public void UpdateRange(int l, int r, int v) {
        Update(l, v);
        Update(r + 1, v);
    }
}

class Solution {
    public IList<bool> PalindromePath(int n, int[][] edges, string s, string[] queries) {
        var g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = new List<int>();
        foreach (var e in edges) {
            g[e[0]].Add(e[1]);
            g[e[1]].Add(e[0]);
        }

        int LOG = 32 - System.Numerics.BitOperations.LeadingZeroCount((uint)n);
        int[,] fa = new int[n, LOG];
        int[] dep = new int[n], l = new int[n], r = new int[n];
        int timer = 0;

        Action<int, int> dfs = null;
        dfs = (u, p) => {
            l[u] = ++timer;
            fa[u, 0] = p;
            foreach (int v in g[u]) {
                if (v == p) {
                    continue;
                }
                dep[v] = dep[u] + 1;
                dfs(v, u);
            }
            r[u] = timer;
        };
        dfs(0, 0);

        for (int j = 1; j < LOG; j++) {
            for (int i = 0; i < n; i++) {
                fa[i, j] = fa[fa[i, j - 1], j - 1];
            }
        }

        var bit = new BIT(n + 1);
        var chars = s.ToCharArray();
        for (int i = 0; i < n; i++) {
            bit.UpdateRange(l[i], r[i], 1 << (chars[i] - 'a'));
        }

        var ans = new List<bool>();
        foreach (var q in queries) {
            var parts = q.Split(' ');
            if (parts[0] == "update") {
                int u = int.Parse(parts[1]);
                char c = parts[2][0];
                bit.UpdateRange(l[u], r[u], (1 << (chars[u] - 'a')) ^ (1 << (c - 'a')));
                chars[u] = c;
            } else {
                int u = int.Parse(parts[1]);
                int v = int.Parse(parts[2]);
                int w = Lca(u, v, dep, fa, LOG);
                int mask = bit.Query(l[u]) ^ bit.Query(l[v]) ^ (1 << (chars[w] - 'a'));
                ans.Add(System.Numerics.BitOperations.PopCount((uint)mask) <= 1);
            }
        }
        return ans;
    }

    private int Lca(int u, int v, int[] dep, int[,] fa, int LOG) {
        if (dep[u] < dep[v]) { int t = u; u = v; v = t; }
        int diff = dep[u] - dep[v];
        for (int i = 0; i < LOG; i++) {
            if (((diff >> i) & 1) == 1) {
                u = fa[u, i];
            }
        }
        if (u == v) {
            return u;
        }
        for (int i = LOG - 1; i >= 0; i--) {
            if (fa[u, i] != fa[v, i]) {
                u = fa[u, i];
                v = fa[v, i];
            }
        }
        return fa[u, 0];
    }
}
```

```Go
type BIT struct {
	tree []int
	n    int
}

func NewBIT(n int) *BIT {
	return &BIT{tree: make([]int, n+1), n: n}
}

func lowbit(x int) int { return x & -x }

func (b *BIT) Update(x, v int) {
	for x <= b.n {
		b.tree[x] ^= v
		x += lowbit(x)
	}
}

func (b *BIT) Query(x int) int {
	ret := 0
	for x > 0 {
		ret ^= b.tree[x]
		x -= lowbit(x)
	}
	return ret
}

func (b *BIT) UpdateRange(l, r, v int) {
	b.Update(l, v)
	b.Update(r+1, v)
}

func palindromePath(n int, edges [][]int, s string, queries []string) []bool {
	g := make([][]int, n)
	for _, e := range edges {
		g[e[0]] = append(g[e[0]], e[1])
		g[e[1]] = append(g[e[1]], e[0])
	}

	LOG := bits.Len(uint(n))
	fa := make([][]int, n)
	dep := make([]int, n)
	l := make([]int, n)
	r := make([]int, n)
	for i := range fa {
		fa[i] = make([]int, LOG)
	}
	timer := 0

	var dfs func(u, p int)
	dfs = func(u, p int) {
		timer++
		l[u] = timer
		fa[u][0] = p
		for _, v := range g[u] {
			if v == p {
				continue
			}
			dep[v] = dep[u] + 1
			dfs(v, u)
		}
		r[u] = timer
	}
	dfs(0, 0)

	for j := 1; j < LOG; j++ {
		for i := 0; i < n; i++ {
			fa[i][j] = fa[fa[i][j-1]][j-1]
		}
	}

	lca := func(u, v int) int {
		if dep[u] < dep[v] {
			u, v = v, u
		}
		diff := dep[u] - dep[v]
		for i := 0; i < LOG; i++ {
			if (diff>>i)&1 == 1 {
				u = fa[u][i]
			}
		}
		if u == v {
			return u
		}
		for i := LOG - 1; i >= 0; i-- {
			if fa[u][i] != fa[v][i] {
				u = fa[u][i]
				v = fa[v][i]
			}
		}
		return fa[u][0]
	}

	bit := NewBIT(n + 1)
	chars := []byte(s)
	for i := 0; i < n; i++ {
		bit.UpdateRange(l[i], r[i], 1<<(chars[i]-'a'))
	}

	ans := []bool{}
	for _, q := range queries {
		parts := strings.Fields(q)
		if parts[0] == "update" {
			u, _ := strconv.Atoi(parts[1])
			c := parts[2][0]
			bit.UpdateRange(l[u], r[u], (1<<(chars[u]-'a'))^(1<<(c-'a')))
			chars[u] = c
		} else {
			u, _ := strconv.Atoi(parts[1])
			v, _ := strconv.Atoi(parts[2])
			w := lca(u, v)
			mask := bit.Query(l[u]) ^ bit.Query(l[v]) ^ (1 << (chars[w] - 'a'))
			ans = append(ans, bits.OnesCount(uint(mask)) <= 1)
		}
	}
	return ans
}
```

```C
typedef struct {
    int *tree;
    int n;
} BIT;

static int lowbit(int x) {
    return x & -x;
}

static void bit_init(BIT *b, int n) {
    b->n = n;
    b->tree = (int *)calloc(n + 1, sizeof(int));
}

static void bit_update(BIT *b, int x, int v) {
    while (x <= b->n) {
        b->tree[x] ^= v;
        x += lowbit(x);
    }
}

static int bit_query(BIT *b, int x) {
    int ret = 0;
    while (x > 0) {
        ret ^= b->tree[x];
        x -= lowbit(x);
    }
    return ret;
}

static void bit_update_range(BIT *b, int l, int r, int v) {
    bit_update(b, l, v);
    bit_update(b, r + 1, v);
}

static int popcount(unsigned int x) {
    int c = 0;
    while (x) {
        c += x & 1;
        x >>= 1;
    }
    return c;
}

typedef struct {
    int *head;
    int *to;
    int *next;
    int edge_cnt;
} Graph;

static void graph_init(Graph *gr, int n, int max_edges) {
    gr->head = (int *)malloc(n * sizeof(int));
    gr->to = (int *)malloc(max_edges * sizeof(int));
    gr->next = (int *)malloc(max_edges * sizeof(int));
    gr->edge_cnt = 0;
    for (int i = 0; i < n; i++) {
        gr->head[i] = -1;
    }
}

static void graph_add(Graph *gr, int u, int v) {
    gr->to[gr->edge_cnt] = v;
    gr->next[gr->edge_cnt] = gr->head[u];
    gr->head[u] = gr->edge_cnt++;
}

static void graph_free(Graph *gr) {
    free(gr->head);
    free(gr->to);
    free(gr->next);
}

static void dfs(int u, int p, Graph *gr, int **fa, int *dep, int *l, int *r, int *timer) {
    (*timer)++;
    l[u] = *timer;
    fa[u][0] = p;

    for (int idx = gr->head[u]; idx != -1; idx = gr->next[idx]) {
        int v = gr->to[idx];
        if (v == p) {
            continue;
        }
        dep[v] = dep[u] + 1;
        dfs(v, u, gr, fa, dep, l, r, timer);
    }

    r[u] = *timer;
}

static int lca(int u, int v, int *dep, int **fa, int LOG) {
    if (dep[u] < dep[v]) {
        int t = u;
        u = v;
        v = t;
    }
    int diff = dep[u] - dep[v];
    for (int i = 0; i < LOG; i++) {
        if ((diff >> i) & 1) {
            u = fa[u][i];
        }
    }
    if (u == v) {
        return u;
    }
    for (int i = LOG - 1; i >= 0; i--) {
        if (fa[u][i] != fa[v][i]) {
            u = fa[u][i];
            v = fa[v][i];
        }
    }
    return fa[u][0];
}

bool* palindromePath(int n, int** edges, int edgesSize, int* edgesColSize, char* s, char** queries, int queriesSize, int* returnSize) {
    Graph gr;
    graph_init(&gr, n, 2 * edgesSize + 1);
    for (int i = 0; i < edgesSize; i++) {
        graph_add(&gr, edges[i][0], edges[i][1]);
        graph_add(&gr, edges[i][1], edges[i][0]);
    }

    int LOG = 1;
    while ((1 << LOG) <= n) {
        LOG++;
    }

    int **fa = (int **)malloc(n * sizeof(int *));
    for (int i = 0; i < n; i++) {
        fa[i] = (int *)calloc(LOG, sizeof(int));
    }
    int *dep = (int *)calloc(n, sizeof(int));
    int *l = (int *)calloc(n, sizeof(int));
    int *r = (int *)calloc(n, sizeof(int));
    int timer = 0;

    dfs(0, 0, &gr, fa, dep, l, r, &timer);

    for (int j = 1; j < LOG; j++) {
        for (int i = 0; i < n; i++) {
            fa[i][j] = fa[fa[i][j - 1]][j - 1];
        }
    }

    BIT bit;
    bit_init(&bit, n + 1);
    for (int i = 0; i < n; i++) {
        bit_update_range(&bit, l[i], r[i], 1 << (s[i] - 'a'));
    }

    bool *ans = (bool *)malloc(queriesSize * sizeof(bool));
    int ansSize = 0;
    for (int qi = 0; qi < queriesSize; qi++) {
        char *q = queries[qi];
        char *p = q;
        while (*p == ' ') {
            p++;
        }
        if (*p == 'u') {
            int u;
            char c;
            sscanf(p, "update %d %c", &u, &c);
            bit_update_range(&bit, l[u], r[u],
                            (1 << (s[u] - 'a')) ^ (1 << (c - 'a')));
            s[u] = c;
        } else {
            int u, v;
            sscanf(p, "query %d %d", &u, &v);
            int w = lca(u, v, dep, fa, LOG);
            int mask = bit_query(&bit, l[u]) ^ bit_query(&bit, l[v]) ^
                       (1 << (s[w] - 'a'));
            ans[ansSize++] = popcount((unsigned int)mask) <= 1;
        }
    }

    for (int i = 0; i < n; i++) {
        free(fa[i]);
    }
    free(fa);
    free(dep);
    free(l);
    free(r);
    free(bit.tree);
    graph_free(&gr);

    *returnSize = ansSize;
    return ans;
}
```

```JavaScript
class BIT {
    constructor(n) {
        this.n = n;
        this.tree = new Array(n + 1).fill(0);
    }

    static lowbit(x) {
        return x & -x;
    }

    update(x, v) {
        while (x <= this.n) {
            this.tree[x] ^= v;
            x += BIT.lowbit(x);
        }
    }

    query(x) {
        let ret = 0;
        while (x > 0) {
            ret ^= this.tree[x];
            x -= BIT.lowbit(x);
        }
        return ret;
    }

    updateRange(l, r, v) {
        this.update(l, v);
        this.update(r + 1, v);
    }
}

var palindromePath = function(n, edges, s, queries) {
    const g = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        g[u].push(v);
        g[v].push(u);
    }

    const LOG = 32 - Math.clz32(n);
    const fa = Array.from({ length: n }, () => new Array(LOG).fill(0));
    const dep = new Array(n).fill(0);
    const l = new Array(n).fill(0);
    const r = new Array(n).fill(0);
    let timer = 0;

    function dfs(u, p) {
        l[u] = ++timer;
        fa[u][0] = p;
        for (const v of g[u]) {
            if (v === p) {
                continue;
            }
            dep[v] = dep[u] + 1;
            dfs(v, u);
        }
        r[u] = timer;
    }
    dfs(0, 0);

    for (let j = 1; j < LOG; j++) {
        for (let i = 0; i < n; i++) {
            fa[i][j] = fa[fa[i][j - 1]][j - 1];
        }
    }

    function lca(u, v) {
        if (dep[u] < dep[v]) [u, v] = [v, u];
        const diff = dep[u] - dep[v];
        for (let i = 0; i < LOG; i++) {
            if ((diff >> i) & 1) {
                u = fa[u][i];
            }
        }
        if (u === v) return u;
        for (let i = LOG - 1; i >= 0; i--) {
            if (fa[u][i] !== fa[v][i]) {
                u = fa[u][i];
                v = fa[v][i];
            }
        }
        return fa[u][0];
    }

    const bit = new BIT(n + 1);
    const chars = s.split('');
    for (let i = 0; i < n; i++) {
        bit.updateRange(l[i], r[i], 1 << (chars[i].charCodeAt(0) - 97));
    }

    const ans = [];
    for (const q of queries) {
        const parts = q.split(' ');
        if (parts[0] === 'update') {
            const u = parseInt(parts[1]);
            const c = parts[2];
            bit.updateRange(l[u], r[u], (1 << (chars[u].charCodeAt(0) - 97)) ^ (1 << (c.charCodeAt(0) - 97)));
            chars[u] = c;
        } else {
            const u = parseInt(parts[1]);
            const v = parseInt(parts[2]);
            const w = lca(u, v);
            const mask = bit.query(l[u]) ^ bit.query(l[v]) ^ (1 << (chars[w].charCodeAt(0) - 97));
            let cnt = 0, m = mask;
            while (m) {
                cnt += m & 1; m >>>= 1;
            }
            ans.push(cnt <= 1);
        }
    }
    return ans;
};
```

```TypeScript
class BIT {
    private tree: number[];
    private n: number;

    constructor(n: number) {
        this.n = n;
        this.tree = new Array(n + 1).fill(0);
    }

    private static lowbit(x: number): number {
        return x & -x;
    }

    update(x: number, v: number): void {
        while (x <= this.n) {
            this.tree[x] ^= v;
            x += BIT.lowbit(x);
        }
    }

    query(x: number): number {
        let ret = 0;
        while (x > 0) {
            ret ^= this.tree[x];
            x -= BIT.lowbit(x);
        }
        return ret;
    }

    updateRange(l: number, r: number, v: number): void {
        this.update(l, v);
        this.update(r + 1, v);
    }
}

function palindromePath(n: number, edges: number[][], s: string, queries: string[]): boolean[] {
    const g: number[][] = Array.from({ length: n }, () => []);
    for (const [u, v] of edges) {
        g[u].push(v);
        g[v].push(u);
    }

    const LOG = 32 - Math.clz32(n);
    const fa: number[][] = Array.from({ length: n }, () => new Array(LOG).fill(0));
    const dep = new Array(n).fill(0);
    const l = new Array(n).fill(0);
    const r = new Array(n).fill(0);
    let timer = 0;

    function dfs(u: number, p: number): void {
        l[u] = ++timer;
        fa[u][0] = p;
        for (const v of g[u]) {
            if (v === p) {
                continue;
            }
            dep[v] = dep[u] + 1;
            dfs(v, u);
        }
        r[u] = timer;
    }
    dfs(0, 0);

    for (let j = 1; j < LOG; j++) {
        for (let i = 0; i < n; i++) {
            fa[i][j] = fa[fa[i][j - 1]][j - 1];
        }
    }

    function lca(u: number, v: number): number {
        if (dep[u] < dep[v]) [u, v] = [v, u];
        const diff = dep[u] - dep[v];
        for (let i = 0; i < LOG; i++) {
            if ((diff >> i) & 1) {
                u = fa[u][i];
            }
        }
        if (u === v) return u;
        for (let i = LOG - 1; i >= 0; i--) {
            if (fa[u][i] !== fa[v][i]) {
                u = fa[u][i];
                v = fa[v][i];
            }
        }
        return fa[u][0];
    }

    const bit = new BIT(n + 1);
    const chars = s.split('');
    for (let i = 0; i < n; i++) {
        bit.updateRange(l[i], r[i], 1 << (chars[i].charCodeAt(0) - 97));
    }

    const ans: boolean[] = [];
    for (const q of queries) {
        const parts = q.split(' ');
        if (parts[0] === 'update') {
            const u = parseInt(parts[1]);
            const c = parts[2];
            bit.updateRange(l[u], r[u], (1 << (chars[u].charCodeAt(0) - 97)) ^ (1 << (c.charCodeAt(0) - 97)));
            chars[u] = c;
        } else {
            const u = parseInt(parts[1]);
            const v = parseInt(parts[2]);
            const w = lca(u, v);
            const mask = bit.query(l[u]) ^ bit.query(l[v]) ^ (1 << (chars[w].charCodeAt(0) - 97));
            let cnt = 0, m = mask;
            while (m) {
                cnt += m & 1; m >>>= 1;
            }
            ans.push(cnt <= 1);
        }
    }
    return ans;
}
```

```Rust
struct BIT {
    n: usize,
    tree: Vec<i32>,
}

impl BIT {
    fn new(n: usize) -> Self {
        BIT {
            n,
            tree: vec![0; n + 1],
        }
    }

    fn lowbit(x: usize) -> usize {
        x & x.wrapping_neg()
    }

    fn update(&mut self, mut x: usize, v: i32) {
        while x <= self.n {
            self.tree[x] ^= v;
            x += Self::lowbit(x);
        }
    }

    fn query(&self, mut x: usize) -> i32 {
        let mut ret = 0;
        while x > 0 {
            ret ^= self.tree[x];
            x -= Self::lowbit(x);
        }
        ret
    }

    fn update_range(&mut self, l: usize, r: usize, v: i32) {
        self.update(l, v);
        self.update(r + 1, v);
    }
}

fn dfs(
    u: usize,
    p: usize,
    g: &mut Vec<Vec<usize>>,
    fa: &mut Vec<Vec<usize>>,
    dep: &mut Vec<usize>,
    l: &mut Vec<usize>,
    r: &mut Vec<usize>,
    timer: &mut usize,
) {
    *timer += 1;
    l[u] = *timer;
    fa[u][0] = p;

    let neighbors = std::mem::take(&mut g[u]);
    for &v in &neighbors {
        if v == p {
            continue;
        }
        dep[v] = dep[u] + 1;
        dfs(v, u, g, fa, dep, l, r, timer);
    }
    g[u] = neighbors;

    r[u] = *timer;
}

fn build_fa(fa: &mut Vec<Vec<usize>>, log: usize, n: usize) {
    for j in 1..log {
        for i in 0..n {
            fa[i][j] = fa[fa[i][j - 1]][j - 1];
        }
    }
}

fn lca(
    mut u: usize,
    mut v: usize,
    fa: &Vec<Vec<usize>>,
    dep: &Vec<usize>,
    log: usize,
) -> usize {
    if dep[u] < dep[v] {
        std::mem::swap(&mut u, &mut v);
    }
    let diff = dep[u] - dep[v];
    for i in 0..log {
        if (diff >> i) & 1 == 1 {
            u = fa[u][i];
        }
    }
    if u == v {
        return u;
    }
    for i in (0..log).rev() {
        if fa[u][i] != fa[v][i] {
            u = fa[u][i];
            v = fa[v][i];
        }
    }
    fa[u][0]
}

impl Solution {
    pub fn palindrome_path(
        n: i32,
        edges: Vec<Vec<i32>>,
        s: String,
        queries: Vec<String>,
    ) -> Vec<bool> {
        let n = n as usize;

        let mut g: Vec<Vec<usize>> = vec![vec![]; n];
        for e in &edges {
            let u = e[0] as usize;
            let v = e[1] as usize;
            g[u].push(v);
            g[v].push(u);
        }

        let log = (32 - (n as u32).leading_zeros()) as usize;
        let mut fa: Vec<Vec<usize>> = vec![vec![0usize; log]; n];
        let mut dep: Vec<usize> = vec![0usize; n];
        let mut l: Vec<usize> = vec![0usize; n];
        let mut r: Vec<usize> = vec![0usize; n];
        let mut timer: usize = 0;

        dfs(0, 0, &mut g, &mut fa, &mut dep, &mut l, &mut r, &mut timer);
        build_fa(&mut fa, log, n);

        let mut bit = BIT::new(n + 1);
        let mut chars: Vec<u8> = s.bytes().collect();
        for i in 0..n {
            let mask = 1i32 << (chars[i] - b'a');
            bit.update_range(l[i], r[i], mask);
        }

        let mut ans: Vec<bool> = Vec::new();
        for q in &queries {
            let parts: Vec<&str> = q.split_whitespace().collect();
            if parts[0] == "update" {
                let u: usize = parts[1].parse().unwrap();
                let c = parts[2].as_bytes()[0];
                let old = 1i32 << (chars[u] - b'a');
                let new = 1i32 << (c - b'a');
                bit.update_range(l[u], r[u], old ^ new);
                chars[u] = c;
            } else {
                let u: usize = parts[1].parse().unwrap();
                let v: usize = parts[2].parse().unwrap();
                let w = lca(u, v, &fa, &dep, log);
                let mask = bit.query(l[u])
                    ^ bit.query(l[v])
                    ^ (1i32 << (chars[w] - b'a'));
                ans.push((mask as u32).count_ones() <= 1);
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O((n+q)\log n)$，其中 $n$ 为节点数，$q$ 为操作数量。$DFS$ 遍历需要 $O(n)$ 时间，预处理倍增数组需要 $O(n\log n)$ 时间。初始化树状数组需要执行 $n$ 次区间异或修改，时间复杂度为 $O(n\log n)$。每次 $update$ 需要一次区间异或修改，每次 $query$ 需要一次最近公共祖先查询和两次树状数组查询，时间复杂度均为 $O(\log n)$。
- 空间复杂度：$O(n\log n)$。倍增数组需要 $O(n\log n)$ 空间，邻接表、DFS 序、节点深度和树状数组均需要 $O(n)$ 空间。递归 $DFS$ 的调用栈最坏需要 $O(n)$ 空间。
