### [升级后最大生成树稳定性](https://leetcode.cn/problems/maximize-spanning-tree-stability-with-upgrades/solutions/3917376/sheng-ji-hou-zui-da-sheng-cheng-shu-wen-yjcqu/)

#### 方法一：二分答案 + 最小生成树

**前置知识**

该方法假设读者已经掌握：

- 二分答案的思想以及算法框架。
- 最小生成树的定义以及用于求解最小生成树的「[Kruskal 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fmst%2F%23kruskal-%E7%AE%97%E6%B3%95)」，包括其基本思想和实现。

**思路与算法**

注意到本题实质求的是**最大化生成树的边权最小值**，看到这种「最大化最小值」或者「最小化最大值」的表述时，常常在二分答案框架下求解。对本题而言，即事先二分边权最小值作为约束，然后去验证是否可以构建出满足该约束的生成树。

接下来思考：对于给定的最小边权约束，我们应该采取何种策略来构建生成树？显然，我们应该采用一种基于贪心策略的构建方式，如果尽可能选择满足约束的边都无法构建生成树，那么选取次优边就更不可能满足要求。基于最小（最大）生成树的贪心性质，这一推论是严格成立的。

首先不考虑 $k$ 次翻倍边权的机会的情况，容易想到，为了让边权尽可能满足约束，应该贪心地挑选较大的边，实际上这是在求解一个最大生成树。在这里，我们选用 $Kruskal$ 算法作为求解生成树的基础算法框架。

在此基础上考虑翻倍策略：因为我们贪心地选取了边权较大的边，已经尽可能的省下了翻倍机会。此时若遇到一条边的边权小于约束，意味着我们只能尝试将其翻倍，以继续构建生成树。若翻倍后仍小于约束或翻倍机会也用完了，意味着剩下的所有边都无法满足约束了，此轮构建失败。

在预处理阶段，先强制选择 $must=1$ 的边，得到并查集的初始状态，并将此时的最小边权作为二分上界；同时，为了求最大生成树，我们按降序排序 $must=0$ 的边。

在二分答案的过程中，按照 $Kruskal$ 算法的步骤，结合上面提到的构建生成树的思路，继续维护并查集并验证合法性即可。需要说明的是，题目中提到生成树要满足三个性质，实际上在**无环**的情况下，「连通」和「恰好有 $n-1$ 条边」是等价条件。实际实现时已经用并查集来保证不存在环路，因此一般使用选取的边数是否恰好等于 $n-1$ 来判断结果是否为生成树。

**代码**

```C++
struct Edge {
    int u, v, w, type;
};

class DSU {
  public:
    vector<int> parent;

    DSU(const vector<int> &p) : parent(p) {}

    int find(int x) { return parent[x] == x ? x : (parent[x] = find(parent[x])); }

    void join(int x, int y) {
        int px = find(x);
        int py = find(y);
        if (px != py) {
            parent[px] = py;
        }
    }
};

const int MAX_STABILITY = 2e5;

class Solution {
  public:
    int maxStability(int n, vector<vector<int>> &edges, int k) {
        int ans = -1;

        if (edges.size() < n - 1) {
            return -1;
        }

        vector<Edge> sortedEdges;
        sortedEdges.reserve(edges.size());
        for (const auto &edge : edges) {
            sortedEdges.push_back({edge[0], edge[1], edge[2], edge[3]});
        }

        vector<Edge> mustEdges;
        vector<Edge> optionalEdges;

        for (const auto &edge : sortedEdges) {
            if (edge.type == 1) {
                mustEdges.push_back(edge);
            } else {
                optionalEdges.push_back(edge);
            }
        }

        if (mustEdges.size() > n - 1) {
            return -1;
        }
        sort(optionalEdges.begin(), optionalEdges.end(), [](const Edge &a, const Edge &b) { return b.w < a.w; });

        int selectedInit = 0;
        int mustMinStability = MAX_STABILITY;
        vector<int> initialParent(n);
        iota(initialParent.begin(), initialParent.end(), 0);
        DSU dsuInit(initialParent);

        for (const auto &edge : mustEdges) {
            if (dsuInit.find(edge.u) == dsuInit.find(edge.v) || selectedInit == n - 1) {
                return -1;
            }

            dsuInit.join(edge.u, edge.v);
            selectedInit++;
            mustMinStability = std::min(mustMinStability, edge.w);
        }

        int l = 0;
        int r = mustMinStability;

        while (l < r) {
            int mid = l + ((r - l + 1) >> 1);

            DSU dsu(dsuInit.parent);

            int selected = selectedInit;
            int doubledCount = 0;

            for (const auto &edge : optionalEdges) {
                if (dsu.find(edge.u) == dsu.find(edge.v)) {
                    continue;
                }

                if (edge.w >= mid) {
                    dsu.join(edge.u, edge.v);
                    selected++;
                } else if (doubledCount < k && edge.w * 2 >= mid) {
                    doubledCount++;
                    dsu.join(edge.u, edge.v);
                    selected++;
                } else {
                    break;
                }

                if (selected == n - 1) {
                    break;
                }
            }

            if (selected != n - 1) {
                r = mid - 1;
            } else {
                ans = mid;
                l = mid;
            }
        }

        return ans;
    }
};
```

```Java
class DSU {
    int[] parent;

    DSU(int[] parent) {
        this.parent = parent.clone();
    }

    int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    void join(int x, int y) {
        int px = find(x);
        int py = find(y);
        parent[px] = py;
    }
}

public class Solution {
    private static final int MAX_STABILITY = 200000;

    public int maxStability(int n, int[][] edges, int k) {
        int ans = -1;
        if (edges.length < n - 1) {
            return -1;
        }
        List<int[]> mustEdges = new ArrayList<>();
        List<int[]> optionalEdges = new ArrayList<>();

        for (int[] edge : edges) {
            if (edge[3] == 1) {
                mustEdges.add(edge);
            } else {
                optionalEdges.add(edge);
            }
        }

        if (mustEdges.size() > n - 1) {
            return -1;
        }

        optionalEdges.sort((a, b) -> b[2] - a[2]);
        int selectedInit = 0;
        int mustMinStability = MAX_STABILITY;

        int[] initParent = new int[n];
        for (int i = 0; i < n; i++) {
            initParent[i] = i;
        }
        DSU dsuInit = new DSU(initParent);

        for (int[] e : mustEdges) {
            int u = e[0], v = e[1], s = e[2];
            if (dsuInit.find(u) == dsuInit.find(v) || selectedInit == n - 1) {
                return -1;
            }
            dsuInit.join(u, v);
            selectedInit++;
            mustMinStability = Math.min(mustMinStability, s);
        }

        int l = 0, r = mustMinStability;
        while (l < r) {
            int mid = l + (r - l + 1) / 2;

            DSU dsu = new DSU(dsuInit.parent);
            int selected = selectedInit;
            int doubledCount = 0;

            for (int[] e : optionalEdges) {
                int u = e[0], v = e[1], s = e[2];
                if (dsu.find(u) == dsu.find(v)) {
                    continue;
                }
                if (s >= mid) {
                    dsu.join(u, v);
                    selected++;
                } else if (doubledCount < k && s * 2 >= mid) {
                    doubledCount++;
                    dsu.join(u, v);
                    selected++;
                } else {
                    break;
                }
                if (selected == n - 1) {
                    break;
                }
            }

            if (selected != n - 1) {
                r = mid - 1;
            } else {
                ans = l = mid;
            }
        }

        return ans;
    }
}
```

```Go
const MAX_STABILITY = 200000

type DSU struct {
    parent []int
}

func NewDSU(parent []int) *DSU {
    p := make([]int, len(parent))
    copy(p, parent)
    return &DSU{parent: p}
}

func (d *DSU) find(x int) int {
    if d.parent[x] != x {
        d.parent[x] = d.find(d.parent[x])
    }
    return d.parent[x]
}

func (d *DSU) join(x, y int) {
    px := d.find(x)
    py := d.find(y)
    d.parent[px] = py
}

func maxStability(n int, edges [][]int, k int) int {
    ans := -1

    if len(edges) < n - 1 {
        return -1
    }
    mustEdges := [][]int{}
    optionalEdges := [][]int{}

    for _, e := range edges {
        if e[3] == 1 {
            mustEdges = append(mustEdges, e)
        } else {
            optionalEdges = append(optionalEdges, e)
        }
    }

    if len(mustEdges) > n - 1 {
        return -1
    }

    sort.Slice(optionalEdges, func(i, j int) bool {
        return optionalEdges[i][2] > optionalEdges[j][2]
    })

    selectedInit := 0
    mustMinStability := MAX_STABILITY

    initParent := make([]int, n)
    for i := 0; i < n; i++ {
        initParent[i] = i
    }
    dsuInit := NewDSU(initParent)

    for _, e := range mustEdges {
        u, v, s := e[0], e[1], e[2]
        if dsuInit.find(u) == dsuInit.find(v) || selectedInit == n - 1 {
            return -1
        }
        dsuInit.join(u, v)
        selectedInit++
        if s < mustMinStability {
            mustMinStability = s
        }
    }

    l, r := 0, mustMinStability
    for l < r {
        mid := l + (r - l + 1) / 2

        dsu := NewDSU(dsuInit.parent)
        selected := selectedInit
        doubledCount := 0

        for _, e := range optionalEdges {
            u, v, s := e[0], e[1], e[2]
            if dsu.find(u) == dsu.find(v) {
                continue
            }

            if s >= mid {
                dsu.join(u, v)
                selected++
            } else if doubledCount < k && s*2 >= mid {
                doubledCount++
                dsu.join(u, v)
                selected++
            } else {
                break
            }

            if selected == n-1 {
                break
            }
        }

        if selected != n-1 {
            r = mid - 1
        } else {
            ans = mid
            l = mid
        }
    }

    return ans
}
```

```Python
class DSU:
    def __init__(self, parent):
        self.parent = parent

    def find(self, x):
        if self.parent[x] == x:
            return x
        self.parent[x] = self.find(self.parent[x])
        return self.parent[x]

    def join(self, x, y):
        px = self.find(x)
        py = self.find(y)
        self.parent[px] = py


MAX_STABILITY = 200000


class Solution:
    def maxStability(self, n: int, edges: List[List[int]], k: int) -> int:
        ans = -1

        if len(edges) < n - 1:
            return -1

        mustEdges = [e for e in edges if e[3] == 1]
        optionalEdges = [e for e in edges if e[3] != 1]

        if len(mustEdges) > n - 1:
            return -1

        optionalEdges.sort(key=lambda x: x[2], reverse=True)

        selectedInit = 0
        mustMinStability = MAX_STABILITY
        dsuInit = DSU(list(range(n)))

        for u, v, s, must in mustEdges:
            if dsuInit.find(u) == dsuInit.find(v) or selectedInit == n - 1:
                return -1
            dsuInit.join(u, v)
            selectedInit += 1
            mustMinStability = min(mustMinStability, s)

        l = 0
        r = mustMinStability

        while l < r:
            mid = l + ((r - l + 1) >> 1)
            dsu = DSU(dsuInit.parent[:])
            selected = selectedInit
            doubledCount = 0

            for u, v, s, must in optionalEdges:
                if dsu.find(u) == dsu.find(v):
                    continue

                if s >= mid:
                    dsu.join(u, v)
                    selected += 1
                elif doubledCount < k and s * 2 >= mid:
                    doubledCount += 1
                    dsu.join(u, v)
                    selected += 1
                else:
                    break

                if selected == n - 1:
                    break

            if selected != n - 1:
                r = mid - 1
            else:
                ans = l = mid

        return ans
```

```CSharp
public class DSU {
    public int[] parent;

    public DSU(int[] parent) {
        this.parent = parent;
    }

    public int Find(int x) {
        return this.parent[x] == x ? x : (this.parent[x] = this.Find(this.parent[x]));
    }

    public void Join(int x, int y) {
        int px = this.Find(x);
        int py = this.Find(y);
        this.parent[px] = py;
    }
}

public class Solution {
    const int MAX_STABILITY = 200000;

    public int MaxStability(int n, int[][] edges, int k) {
        int ans = -1;

        if (edges.Length < n - 1) {
            return -1;
        }

        List<int[]> mustEdges = new List<int[]>();
        List<int[]> optionalEdges = new List<int[]>();

        foreach (var edge in edges) {
            if (edge[3] == 1) {
                mustEdges.Add(edge);
            } else {
                optionalEdges.Add(edge);
            }
        }

        if (mustEdges.Count > n - 1) {
            return -1;
        }
        optionalEdges.Sort((a, b) => b[2].CompareTo(a[2]));

        int selectedInit = 0;
        int mustMinStability = MAX_STABILITY;
        int[] initialParent = Enumerable.Range(0, n).ToArray();
        DSU dsuInit = new DSU(initialParent);

        foreach (var edge in mustEdges) {
            if (dsuInit.Find(edge[0]) == dsuInit.Find(edge[1]) || selectedInit == n - 1) {
                return -1;
            }

            dsuInit.Join(edge[0], edge[1]);
            selectedInit++;
            mustMinStability = Math.Min(mustMinStability, edge[2]);
        }

        int l = 0;
        int r = mustMinStability;

        while (l < r) {
            int mid = l + ((r - l + 1) >> 1);

            DSU dsu = new DSU((int[])dsuInit.parent.Clone());

            int selected = selectedInit;
            int doubledCount = 0;

            foreach (var edge in optionalEdges) {
                if (dsu.Find(edge[0]) == dsu.Find(edge[1])) {
                    continue;
                }

                if (edge[2] >= mid) {
                    dsu.Join(edge[0], edge[1]);
                    selected++;
                } else if (doubledCount < k && edge[2] * 2 >= mid) {
                    doubledCount++;
                    dsu.Join(edge[0], edge[1]);
                    selected++;
                } else {
                    break;
                }

                if (selected == n - 1) {
                    break;
                }
            }

            if (selected != n - 1) {
                r = mid - 1;
            } else {
                ans = l = mid;
            }
        }

        return ans;
    }
}
```

```C
#define MAX_STABILITY 200000

typedef struct {
    int* parent;
} DSU;

DSU* dsu_create(int* parent, int n) {
    DSU* d = (DSU*)malloc(sizeof(DSU));
    d->parent = (int*)malloc(n * sizeof(int));
    memcpy(d->parent, parent, n * sizeof(int));
    return d;
}

void dsu_free(DSU* d) {
    free(d->parent);
    free(d);
}

int dsu_find(DSU* d, int x) {
    if (d->parent[x] != x) {
        d->parent[x] = dsu_find(d, d->parent[x]);
    }
    return d->parent[x];
}

void dsu_join(DSU* d, int x, int y) {
    int px = dsu_find(d, x);
    int py = dsu_find(d, y);
    d->parent[px] = py;
}

int cmp_desc(const void* a, const void* b) {
    int* edgeA = (int*)a;
    int* edgeB = (int*)b;
    return edgeB[2] - edgeA[2];
}

int maxStability(int n, int** edges, int edgesSize, int* edgesColSize, int k) {
    int ans = -1;
    if (edgesSize < n - 1) {
        return -1;
    }

    int (*mustEdges)[4] = (int(*)[4])malloc(edgesSize * sizeof(int[4]));
    int (*optionalEdges)[4] = (int(*)[4])malloc(edgesSize * sizeof(int[4]));
    int mustCnt = 0, optCnt = 0;
    for (int i = 0; i < edgesSize; i++) {
        if (edges[i][3] == 1) {
            mustEdges[mustCnt][0] = edges[i][0];
            mustEdges[mustCnt][1] = edges[i][1];
            mustEdges[mustCnt][2] = edges[i][2];
            mustCnt++;
        } else {
            optionalEdges[optCnt][0] = edges[i][0];
            optionalEdges[optCnt][1] = edges[i][1];
            optionalEdges[optCnt][2] = edges[i][2];
            optCnt++;
        }
    }

    if (mustCnt > n - 1) {
        free(mustEdges);
        free(optionalEdges);
        return -1;
    }

    qsort(optionalEdges, optCnt, sizeof(int[4]), cmp_desc);
    int selectedInit = 0;
    int mustMinStability = MAX_STABILITY;
    int* initParent = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        initParent[i] = i;
    }
    DSU* dsuInit = dsu_create(initParent, n);
    free(initParent);

    for (int i = 0; i < mustCnt; i++) {
        int u = mustEdges[i][0], v = mustEdges[i][1], s = mustEdges[i][2];
        if (dsu_find(dsuInit, u) == dsu_find(dsuInit, v) || selectedInit == n - 1) {
            dsu_free(dsuInit);
            free(mustEdges);
            free(optionalEdges);
            return -1;
        }
        dsu_join(dsuInit, u, v);
        selectedInit++;
        if (s < mustMinStability) {
            mustMinStability = s;
        }
    }

    int l = 0, r = mustMinStability;
    while (l < r) {
        int mid = l + (r - l + 1) / 2;

        int* currentParent = (int*)malloc(n * sizeof(int));
        memcpy(currentParent, dsuInit->parent, n * sizeof(int));
        DSU* dsu = dsu_create(currentParent, n);
        free(currentParent);

        int selected = selectedInit;
        int doubledCount = 0;

        for (int i = 0; i < optCnt; i++) {
            int u = optionalEdges[i][0], v = optionalEdges[i][1], s = optionalEdges[i][2];
            if (dsu_find(dsu, u) == dsu_find(dsu, v)) {
                continue;
            }
            if (s >= mid) {
                dsu_join(dsu, u, v);
                selected++;
            } else if (doubledCount < k && s * 2 >= mid) {
                doubledCount++;
                dsu_join(dsu, u, v);
                selected++;
            } else {
                break;
            }

            if (selected == n - 1) {
                break;
            }
        }

        dsu_free(dsu);
        if (selected != n - 1) {
            r = mid - 1;
        } else {
            ans = mid;
            l = mid;
        }
    }

    dsu_free(dsuInit);
    free(mustEdges);
    free(optionalEdges);

    return ans;
}
```

```JavaScript
class DSU {
    constructor(parent) { this.parent = parent; }

    find(x) {
        return this.parent[x] === x ? x : (this.parent[x] = this.find(this.parent[x]));
    }

    join(x, y) {
        const px = this.find(x);
        const py = this.find(y);
        this.parent[px] = py;
    }
}

const MAX_STABILITY = 2e5;

var maxStability = function (n, edges, k) {
    let ans = -1;

    if (edges.length < n - 1) {
        return -1;
    }

    const mustEdges = edges.filter(([, , , must]) => must === 1);
    const optionalEdges = edges.filter(([, , , must]) => must !== 1);

    if (mustEdges.length > n - 1) {
        return -1;
    }
    optionalEdges.sort((a, b) => b[2] - a[2]);

    let selectedInit = 0;
    let mustMinStability = MAX_STABILITY;
    const dsuInit = new DSU(Array.from({ length: n }, (_, i) => i));

    for (const [u, v, s] of mustEdges) {
        if (dsuInit.find(u) === dsuInit.find(v) || selectedInit === n - 1) {
            return -1;
        }

        dsuInit.join(u, v);
        selectedInit++;
        mustMinStability = Math.min(mustMinStability, s);
    }

    let l = 0;
    let r = mustMinStability;

    while (l < r) {
        const mid = l + ((r - l + 1) >>> 1);

        const dsu = new DSU(dsuInit.parent.slice());

        let selected = selectedInit;
        let doubledCount = 0;

        for (const [u, v, s] of optionalEdges) {
            if (dsu.find(u) === dsu.find(v)) {
                continue;
            }

            if (s >= mid) {
                dsu.join(u, v);
                selected++;
            } else if (doubledCount < k && s * 2 >= mid) {
                doubledCount++;
                dsu.join(u, v);
                selected++;
            } else {
                break;
            }

            if (selected === n - 1) {
                break;
            }
        }

        if (selected !== n - 1) {
            r = mid - 1;
        } else {
            ans = l = mid;
        }
    }

    return ans;
}
```

```TypeScript
class DSU {
    constructor(public parent: number[]) { }

    find(x: number): number {
        return this.parent[x] === x ? x : (this.parent[x] = this.find(this.parent[x]));
    }

    join(x: number, y: number) {
        const px = this.find(x);
        const py = this.find(y);
        this.parent[px] = py;
    }
}

const MAX_STABILITY = 2e5;

function maxStability(n: number, edges: number[][], k: number): number {
    let ans = -1;

    if (edges.length < n - 1) {
        return -1;
    }

    const mustEdges = edges.filter(([, , , must]) => must === 1);
    const optionalEdges = edges.filter(([, , , must]) => must !== 1);

    if (mustEdges.length > n - 1) {
        return -1;
    }
    optionalEdges.sort((a, b) => b[2] - a[2]);

    let selectedInit = 0;
    let mustMinStability = MAX_STABILITY;
    const dsuInit = new DSU(Array.from({ length: n }, (_, i) => i));

    for (const [u, v, s] of mustEdges) {
        if (dsuInit.find(u) === dsuInit.find(v) || selectedInit === n - 1) {
            return -1;
        }

        dsuInit.join(u, v);
        selectedInit++;
        mustMinStability = Math.min(mustMinStability, s);
    }

    let l = 0;
    let r = mustMinStability;

    while (l < r) {
        const mid = l + ((r - l + 1) >>> 1);

        const dsu = new DSU(dsuInit.parent.slice());

        let selected = selectedInit;
        let doubledCount = 0;

        for (const [u, v, s] of optionalEdges) {
            if (dsu.find(u) === dsu.find(v)) {
                continue;
            }

            if (s >= mid) {
                dsu.join(u, v);
                selected++;
            } else if (doubledCount < k && s * 2 >= mid) {
                doubledCount++;
                dsu.join(u, v);
                selected++;
            } else {
                break;
            }

            if (selected === n - 1) {
                break;
            }
        }

        if (selected !== n - 1) {
            r = mid - 1;
        } else {
            ans = l = mid;
        }
    }

    return ans;
}
```

```Rust
const MAX_STABILITY: i32 = 200000;

#[derive(Clone, Copy)]
struct Edge {
    u: usize,
    v: usize,
    w: i32,
    typ: i32,
}

struct DSU {
    parent: Vec<usize>,
}

impl DSU {
    fn new(p: &[usize]) -> Self {
        DSU {
            parent: p.to_vec(),
        }
    }

    fn find(&mut self, x: usize) -> usize {
        if self.parent[x] == x {
            x
        } else {
            self.parent[x] = self.find(self.parent[x]);
            self.parent[x]
        }
    }

    fn join(&mut self, x: usize, y: usize) {
        let px = self.find(x);
        let py = self.find(y);
        if px != py {
            self.parent[px] = py;
        }
    }
}

impl Solution {
    pub fn max_stability(n: i32, edges: Vec<Vec<i32>>, k: i32) -> i32 {
        let n = n as usize;
        let k = k as usize;
        let mut ans = -1;

        if edges.len() < n - 1 {
            return -1;
        }

        let mut sorted_edges: Vec<Edge> = edges
            .iter()
            .map(|edge| Edge {
                u: edge[0] as usize,
                v: edge[1] as usize,
                w: edge[2],
                typ: edge[3],
            })
            .collect();

        let mut must_edges = Vec::new();
        let mut optional_edges = Vec::new();

        for edge in sorted_edges {
            if edge.typ == 1 {
                must_edges.push(edge);
            } else {
                optional_edges.push(edge);
            }
        }

        if must_edges.len() > n - 1 {
            return -1;
        }

        optional_edges.sort_by(|a, b| b.w.cmp(&a.w));

        let mut selected_init = 0;
        let mut must_min_stability = MAX_STABILITY;
        let initial_parent: Vec<usize> = (0..n).collect();
        let mut dsu_init = DSU::new(&initial_parent);

        for &edge in &must_edges {
            if dsu_init.find(edge.u) == dsu_init.find(edge.v) || selected_init == n - 1 {
                return -1;
            }

            dsu_init.join(edge.u, edge.v);
            selected_init += 1;
            must_min_stability = must_min_stability.min(edge.w);
        }

        let mut l = 0;
        let mut r = must_min_stability;

        while l < r {
            let mid = l + ((r - l + 1) >> 1);
            let mut dsu = DSU::new(&dsu_init.parent);
            let mut selected = selected_init;
            let mut doubled_count = 0;

            for &edge in &optional_edges {
                if dsu.find(edge.u) == dsu.find(edge.v) {
                    continue;
                }

                if edge.w >= mid {
                    dsu.join(edge.u, edge.v);
                    selected += 1;
                } else if doubled_count < k && edge.w * 2 >= mid {
                    doubled_count += 1;
                    dsu.join(edge.u, edge.v);
                    selected += 1;
                } else {
                    break;
                }

                if selected == n - 1 {
                    break;
                }
            }

            if selected != n - 1 {
                r = mid - 1;
            } else {
                ans = mid;
                l = mid;
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m\log m+(n+m\cdot \alpha (n))\cdot \log v)$，其中 $m$ 是 $edges$ 的长度，$v$ 是二分上界，并查集的查找需要 $O(\alpha (n))$，其中 $\alpha (\cdot )$ 是反阿克曼函数。预处理中，对 $edges$ 排序需要 $O(m\log m)$，预处理 $must=1$ 的边需要 $O(m\cdot \alpha (n))$。二分答案循环需要 $O(\log v)$，克隆并查集初始状态需要 $O(n)$，维护并查集需要 $m\cdot \alpha (n)$，考虑到 $\alpha (\cdot )$ 取值接近一个小常数，最终的时间复杂度为 $O(m\log m+(n+m\cdot \alpha (n))\cdot \log v)$。
- 空间复杂度：$O(n+m)$，并查集需要 $O(n)$ 的空间，分开存储 $must=1$ 和 $must=0$ 的边需要额外 $O(m)$ 的空间。
