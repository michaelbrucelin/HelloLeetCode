### [恢复网络路径](https://leetcode.cn/problems/network-recovery-pathways/solutions/3988815/hui-fu-wang-luo-lu-jing-by-leetcode-solu-6luq/)

#### 方法一：二分答案 + 最短路（Dijkstra）

**思路与算法**

提取一下题目的关键信息：

1. 给定一个有向图，节点通过 $online$ 数组确定在线状态。
2. 只有两个端点在线的边才是有效边。
3. 要从节点 $0$ 到节点 $n-1$ 找一条路径，这条路径上边的总权重不能超过 $k$，并且所有节点都要在线。
4. 每条不同路径的分数定义为路径上最小的边权，我们的目标是找到所有有效路径的最大分数，即最大化最小边权。
5. 如果没有有效路径则返回 $-1$。

遇到最大化最小值的题目具有一个关键的性质：单调性，因此能够使用二分答案来解决。

假设存在一条从 $0$ 到 $n-1$ 的路径，满足：

1. 这条路径总权重 $\le k$
2. 路径上的最小边权 $\ge x$

那么对于任意 $y\le x$，这条路径同样满足：

1. 总权重仍然 $\le k$
2. 所有边权都 $\ge y$

也就是说：

如果 $check(x)$ 可行，那么对所有更小的阈值 $y<x$，check(y) 也一定可行；
如果 $check(x)$ 不可行，那么对所有更大的阈值 $z>x$，check(z) 也一定不可能变成可行。
这就是二分答案所需的“单调可行性”条件。

那么如何进行二分答案呢？我们把 $mid$ 看作候选的最小边权，于是有以下限制：

1. 只允许使用权重 $\ge mid$ 的边。
2. 计算是否存在一条从 $0$ 到 $n-1$ 的路径，且路径总权重 $\le k$。

如果 $check(mid)$ 为真，说明有一条路径的最小边权至少是 $mid$，那么我们可以将 $mid$ 调大，寻找更大的可能值；

如果为假，说明没有任何路径能够在总权重的限制下保证所有边的权值都 $\ge mid$，那么就只能将 $mid$ 下调来寻找可行解。

这一题的主要思路已经拆解完毕了，接下来是如何进行 $check$ 的问题。在方法一中我们选择最短路来进行判断，思路如下：

1. 根据节点的在线情况建图，只有两头节点都在线的边才是有效边。
2. 对于每一个候选值 $mid$
  a. 在图中只保留权重 $\ge mid$ 的边，实现过程中跳过不符合条件的边即可。
  b. 用 $Dijkstra$ 求出从 $0$ 到 $n-1$ 的最短路。
  c. 如果最短路长度 $\le k$，说明存在符合条件的路径，$mid$ 可取。

**代码**

```C++
class Solution {
public:
    int findMaxPathScore(vector<vector<int>>& edges, vector<bool>& online,
                         long long k) {
        int n = online.size();
        vector<vector<pair<int, int>>> g(n);
        int l = INT_MAX, r = 0;

        for (auto& edge : edges) {
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];
            if (!online[u] || !online[v]) {
                continue;
            }
            g[u].push_back({v, w});
            l = min(l, w);
            r = max(r, w);
        }

        auto check = [&](int mid) -> bool {
            vector<long long> dis(n, LLONG_MAX);
            priority_queue<pair<long long, int>, vector<pair<long long, int>>,
                           greater<>>
                q;

            dis[0] = 0;
            q.push({0, 0});

            while (!q.empty()) {
                auto [d, u] = q.top();
                q.pop();

                if (d > k) {
                    return false;
                }
                if (u == n - 1) {
                    return true;
                }
                if (d > dis[u]) {
                    continue;
                }

                for (auto& [v, w] : g[u]) {
                    if (w < mid) {
                        continue;
                    }
                    if (dis[v] > dis[u] + w) {
                        dis[v] = dis[u] + w;
                        q.push({dis[v], v});
                    }
                }
            }
            return false;
        };

        if (!check(l)) {
            return -1;
        }

        while (l <= r) {
            int mid = (l + r) >> 1;
            if (check(mid)) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return r;
    }
};
```

```Go
type Pair struct {
    First  int
    Second int64
}

type MinHeap []Pair

func (h MinHeap) Len() int            { return len(h) }
func (h MinHeap) Less(i, j int) bool  { return h[i].Second < h[j].Second }
func (h MinHeap) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *MinHeap) Push(x interface{}) { *h = append(*h, x.(Pair)) }
func (h *MinHeap) Pop() interface{} {
    old := *h
    n := len(old)
    x := old[n-1]
    *h = old[0 : n-1]
    return x
}

func findMaxPathScore(edges [][]int, online []bool, k int64) int {
    n := len(online)
    g := make([][]Pair, n)
    l, r := int(1e9), 0

    for _, edge := range edges {
        u, v, w := edge[0], edge[1], edge[2]
        if !online[u] || !online[v] {
            continue
        }
        g[u] = append(g[u], Pair{v, int64(w)})
        if w < l {
            l = w
        }
        if w > r {
            r = w
        }
    }

    check := func(mid int) bool {
        dis := make([]int64, n)
        for i := range dis {
            dis[i] = math.MaxInt64
        }
        h := &MinHeap{}
        heap.Init(h)

        dis[0] = 0
        heap.Push(h, Pair{0, 0})

        for h.Len() > 0 {
            top := heap.Pop(h).(Pair)
            d, u := top.Second, top.First

            if d > k {
                return false
            }
            if u == n-1 {
                return true
            }
            if d > dis[u] {
                continue
            }

            for _, edge := range g[u] {
                v, w := edge.First, edge.Second
                if w < int64(mid) {
                    continue
                }
                if dis[v] > dis[u]+w {
                    dis[v] = dis[u] + w
                    heap.Push(h, Pair{v, dis[v]})
                }
            }
        }
        return false
    }

    if !check(l) {
        return -1
    }

    for l <= r {
        mid := (l + r) >> 1
        if check(mid) {
            l = mid + 1
        } else {
            r = mid - 1
        }
    }
    return r
}
```

```Python
class Solution:
    def findMaxPathScore(
        self, edges: List[List[int]], online: List[bool], k: int
    ) -> int:
        n = len(online)
        g = [[] for _ in range(n)]
        l, r = float("inf"), 0

        for u, v, w in edges:
            if not online[u] or not online[v]:
                continue
            g[u].append((v, w))
            l = min(l, w)
            r = max(r, w)

        def check(mid: int) -> bool:
            dis = [float("inf")] * n
            pq = [(0, 0)]
            dis[0] = 0

            while pq:
                d, u = heapq.heappop(pq)

                if d > k:
                    return False
                if u == n - 1:
                    return True
                if d > dis[u]:
                    continue

                for v, w in g[u]:
                    if w < mid:
                        continue
                    if dis[v] > dis[u] + w:
                        dis[v] = dis[u] + w
                        heapq.heappush(pq, (dis[v], v))
            return False

        if not check(l):
            return -1

        while l <= r:
            mid = (l + r) >> 1
            if check(mid):
                l = mid + 1
            else:
                r = mid - 1
        return r
```

```Java
class Solution {

    public int findMaxPathScore(int[][] edges, boolean[] online, long k) {
        int n = online.length;
        List<List<int[]>> g = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            g.add(new ArrayList<>());
        }

        int l = Integer.MAX_VALUE;
        int r = 0;
        for (int[] edge : edges) {
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];
            if (!online[u] || !online[v]) {
                continue;
            }
            g.get(u).add(new int[] { v, w });
            l = Math.min(l, w);
            r = Math.max(r, w);
        }

        if (!check(g, l, k, n)) {
            return -1;
        }

        while (l <= r) {
            int mid = (l + r) >> 1;
            if (check(g, mid, k, n)) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return r;
    }

    private boolean check(List<List<int[]>> g, int mid, long k, int n) {
        long[] dis = new long[n];
        Arrays.fill(dis, Long.MAX_VALUE);
        PriorityQueue<long[]> pq = new PriorityQueue<>((a, b) ->
            Long.compare(a[0], b[0])
        );

        dis[0] = 0;
        pq.offer(new long[] { 0, 0 });

        while (!pq.isEmpty()) {
            long[] top = pq.poll();
            long d = top[0];
            int u = (int) top[1];

            if (d > k) {
                return false;
            }
            if (u == n - 1) {
                return true;
            }
            if (d > dis[u]) {
                continue;
            }

            for (int[] edge : g.get(u)) {
                int v = edge[0];
                int w = edge[1];
                if (w < mid) {
                    continue;
                }
                if (dis[v] > dis[u] + w) {
                    dis[v] = dis[u] + w;
                    pq.offer(new long[] { dis[v], v });
                }
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    public int FindMaxPathScore(int[][] edges, bool[] online, long k) {
        int n = online.Length;
        var g = new List<(int, int)>[n];
        for (int i = 0; i < n; i++) {
            g[i] = new List<(int, int)>();
        }

        int l = int.MaxValue, r = 0;
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1], w = edge[2];
            if (!online[u] || !online[v]) {
                continue;
            }
            g[u].Add((v, w));
            l = Math.Min(l, w);
            r = Math.Max(r, w);
        }

        bool Check(int mid) {
            var dis = new long[n];
            Array.Fill(dis, long.MaxValue);
            var pq = new SortedSet<(long, int)>();

            dis[0] = 0;
            pq.Add((0, 0));

            while (pq.Count > 0) {
                var (d, u) = pq.Min;
                pq.Remove(pq.Min);

                if (d > k)
                    return false;
                if (u == n - 1) {
                    return true;
                }
                if (d > dis[u]) {
                    continue;
                }

                foreach (var (v, w) in g[u]) {
                    if (w < mid) {
                        continue;
                    }
                    if (dis[v] > dis[u] + w) {
                        if (dis[v] != long.MaxValue) {
                            pq.Remove((dis[v], v));
                        }
                        dis[v] = dis[u] + w;
                        pq.Add((dis[v], v));
                    }
                }
            }
            return false;
        }

        if (!Check(l)) {
            return -1;
        }

        while (l <= r) {
            int mid = (l + r) >> 1;
            if (Check(mid)) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return r;
    }
}
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int data[2];
} Element;

typedef bool (*compare)(const void*, const void*);

typedef struct PriorityQueue {
    Element* arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

Element* createElement(int x, int y) {
    Element* obj = (Element*)malloc(sizeof(Element));
    obj->data[0] = x;
    obj->data[1] = y;
    return obj;
}

static bool less(const void* a, const void* b) {
    Element* e1 = (Element*)a;
    Element* e2 = (Element*)b;
    return e1->data[0] > e2->data[0] ||
           (e1->data[0] == e2->data[0] && e1->data[1] > e2->data[1]);
}

static bool greater(const void* a, const void* b) {
    Element* e1 = (Element*)a;
    Element* e2 = (Element*)b;
    return e1->data[0] < e2->data[0];
}

static void memswap(void* m1, void* m2, size_t size) {
    unsigned char* a = (unsigned char*)m1;
    unsigned char* b = (unsigned char*)m2;
    while (size--) {
        *b ^= *a ^= *b ^= *a;
        a++;
        b++;
    }
}

static void swap(Element* arr, int i, int j) {
    memswap(&arr[i], &arr[j], sizeof(Element));
}

static void down(Element* arr, int size, int i, compare cmpFunc) {
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

PriorityQueue* createPriorityQueue(compare cmpFunc) {
    PriorityQueue* obj = (PriorityQueue*)malloc(sizeof(PriorityQueue));
    obj->capacity = MIN_QUEUE_SIZE;
    obj->arr = (Element*)malloc(sizeof(Element) * obj->capacity);
    obj->queueSize = 0;
    obj->lessFunc = cmpFunc;
    return obj;
}

void heapfiy(PriorityQueue* obj) {
    for (int i = obj->queueSize / 2 - 1; i >= 0; i--) {
        down(obj->arr, obj->queueSize, i, obj->lessFunc);
    }
}

void enQueue(PriorityQueue* obj, Element* e) {
    if (obj->queueSize == obj->capacity) {
        obj->capacity *= 2;
        obj->arr = realloc(obj->arr, sizeof(Element) * obj->capacity);
    }
    memcpy(&obj->arr[obj->queueSize], e, sizeof(Element));
    for (int i = obj->queueSize;
         i > 0 && obj->lessFunc(&obj->arr[(i - 1) / 2], &obj->arr[i]);
         i = (i - 1) / 2) {
        swap(obj->arr, i, (i - 1) / 2);
    }
    obj->queueSize++;
}

Element* deQueue(PriorityQueue* obj) {
    swap(obj->arr, 0, obj->queueSize - 1);
    down(obj->arr, obj->queueSize - 1, 0, obj->lessFunc);
    Element* e = &obj->arr[obj->queueSize - 1];
    obj->queueSize--;
    return e;
}

bool isEmpty(const PriorityQueue* obj) { return obj->queueSize == 0; }

Element* front(const PriorityQueue* obj) {
    if (obj->queueSize == 0) return NULL;
    return &obj->arr[0];
}

void clear(PriorityQueue* obj) { obj->queueSize = 0; }

int size(const PriorityQueue* obj) { return obj->queueSize; }

void freeQueue(PriorityQueue* obj) {
    free(obj->arr);
    free(obj);
}

typedef struct {
    int to;
    int weight;
} Edge;

typedef struct {
    Edge* data;
    int size;
    int capacity;
} Vector;

static void addEdge(Vector* vec, int to, int weight) {
    if (vec->size == vec->capacity) {
        vec->capacity = (vec->capacity == 0) ? 4 : vec->capacity * 2;
        vec->data = (Edge*)realloc(vec->data, sizeof(Edge) * vec->capacity);
    }
    vec->data[vec->size].to = to;
    vec->data[vec->size].weight = weight;
    vec->size++;
}

static bool check(int mid, Vector* graph, int n, long long k) {
    long long* dis = (long long*)malloc(n * sizeof(long long));
    for (int i = 0; i < n; i++) {
        dis[i] = LLONG_MAX;
    }
    PriorityQueue* pq = createPriorityQueue(less);
    dis[0] = 0;
    Element start = {{0, 0}};
    enQueue(pq, &start);

    bool result = false;
    while (!isEmpty(pq)) {
        Element top = *front(pq);
        deQueue(pq);

        long long d = top.data[0];
        int u = top.data[1];

        if (d > k) {
            result = false;
            break;
        }
        if (u == n - 1) {
            result = true;
            break;
        }
        if (d > dis[u]) {
            continue;
        }
        for (int i = 0; i < graph[u].size; i++) {
            int v = graph[u].data[i].to;
            int w = graph[u].data[i].weight;
            if (w < mid) continue;
            if (dis[v] > dis[u] + w) {
                dis[v] = dis[u] + w;
                Element e = {{(int)dis[v], v}};
                enQueue(pq, &e);
            }
        }
    }

    free(dis);
    freeQueue(pq);
    return result;
}

int findMaxPathScore(int** edges, int edgesSize, int* edgesColSize,
                     bool* online, int n, long long k) {
    Vector* graph = (Vector*)malloc(n * sizeof(Vector));
    for (int i = 0; i < n; i++) {
        graph[i].data = NULL;
        graph[i].size = 0;
        graph[i].capacity = 0;
    }

    int l = INT_MAX, r = 0;
    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0];
        int v = edges[i][1];
        int w = edges[i][2];
        if (!online[u] || !online[v]) {
            continue;
        }
        addEdge(&graph[u], v, w);
        l = fmin(l, w);
        r = fmax(r, w);
    }

    if (!check(l, graph, n, k)) {
        for (int i = 0; i < n; i++) {
            free(graph[i].data);
        }
        free(graph);
        return -1;
    }

    while (l <= r) {
        int mid = l + (r - l) / 2;
        if (check(mid, graph, n, k)) {
            l = mid + 1;
        } else {
            r = mid - 1;
        }
    }

    for (int i = 0; i < n; i++) {
        free(graph[i].data);
    }
    free(graph);
    return r;
}
```

```JavaScript
var findMaxPathScore = function (edges, online, k) {
    const n = online.length;
    const g = Array.from({ length: n }, () => []);
    let l = Infinity,
        r = 0;

    for (const [u, v, w] of edges) {
        if (!online[u] || !online[v]) {
            continue;
        }
        g[u].push([v, w]);
        l = Math.min(l, w);
        r = Math.max(r, w);
    }

    const check = (mid) => {
        const dis = new Array(n).fill(Infinity);
        const pq = new PriorityQueue((a, b) => a[0] - b[0]);

        dis[0] = 0;
        pq.enqueue([0, 0]);

        while (!pq.isEmpty()) {
            const [d, u] = pq.dequeue();

            if (d > k) {
                return false;
            }
            if (u === n - 1) {
                return true;
            }
            if (d !== dis[u]) {
                continue;
            }

            for (const [v, w] of g[u]) {
                if (w < mid) {
                    continue;
                }
                const nd = d + w;
                if (nd < dis[v]) {
                    dis[v] = nd;
                    pq.enqueue([nd, v]);
                }
            }
        }
        return false;
    };

    if (!check(l)) {
        return -1;
    }

    while (l <= r) {
        const mid = (l + r) >> 1;
        if (check(mid)) {
            l = mid + 1;
        } else {
            r = mid - 1;
        }
    }
    return r;
};
```

```TypeScript
function findMaxPathScore(
    edges: number[][],
    online: boolean[],
    k: number,
): number {
    const n = online.length;
    const g: [number, number][][] = Array.from({ length: n }, () => []);

    let l = Infinity;
    let r = 0;

    for (const edge of edges) {
        const u = edge[0];
        const v = edge[1];
        const w = edge[2];

        if (!online[u] || !online[v]) {
            continue;
        }
        g[u].push([v, w]);
        l = Math.min(l, w);
        r = Math.max(r, w);
    }

    if (!check(l, k, g, n)) {
        return -1;
    }

    while (l <= r) {
        const mid = (l + r) >> 1;
        if (check(mid, k, g, n)) {
            l = mid + 1;
        } else {
            r = mid - 1;
        }
    }

    return r;
}

function check(
    mid: number,
    k: number,
    g: [number, number][][],
    n: number,
): boolean {
    const dis = new Array<number>(n).fill(Infinity);
    const pq = new PriorityQueue<[number, number]>((a, b) => a[0] - b[0]);

    dis[0] = 0;
    pq.enqueue([0, 0]);

    while (!pq.isEmpty()) {
        const [d, u] = pq.dequeue()!;

        if (d > k) {
            return false;
        }
        if (u === n - 1) {
            return true;
        }
        if (d !== dis[u]) {
            continue;
        }

        for (const [v, w] of g[u]) {
            if (w < mid) {
                continue;
            }
            const nd = d + w;
            if (nd < dis[v]) {
                dis[v] = nd;
                pq.enqueue([nd, v]);
            }
        }
    }

    return false;
}
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

impl Solution {
    pub fn find_max_path_score(edges: Vec<Vec<i32>>, online: Vec<bool>, k: i64) -> i32 {
        let n = online.len();
        let mut g = vec![vec![]; n];
        let mut l = i32::MAX;
        let mut r = 0;

        for edge in &edges {
            let u = edge[0] as usize;
            let v = edge[1] as usize;
            let w = edge[2];
            if !online[u] || !online[v] {
                continue;
            }
            g[u].push((v, w as i64));
            l = l.min(w);
            r = r.max(w);
        }

        let check = |mid: i32| -> bool {
            let mut dis = vec![i64::MAX; n];
            let mut pq = BinaryHeap::new();

            dis[0] = 0;
            pq.push(Reverse((0, 0)));

            while let Some(Reverse((d, u))) = pq.pop() {
                if d > k {
                    return false;
                }
                if u == n - 1 {
                    return true;
                }
                if d > dis[u] {
                    continue;
                }

                for &(v, w) in &g[u] {
                    if w < mid as i64 {
                        continue;
                    }
                    if dis[v] > dis[u] + w {
                        dis[v] = dis[u] + w;
                        pq.push(Reverse((dis[v], v)));
                    }
                }
            }
            false
        };

        if !check(l) {
            return -1;
        }

        while l <= r {
            let mid = (l + r) >> 1;
            if check(mid) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        r
    }
}
```

**复杂度分析**

- 时间复杂度：建图 $O(E)$；二分次数为 $O(\log U)$，其中 $U$ 是边权的最大值。跑一次 $Dijkstra$ 时间复杂度为 $O((E+V)\log V)$，其中 $E$ 是 $edges$ 的长度，$V$ 是 $online$ 的长度；总体时间复杂度为 $O((E+V)\log V\log U)$。
- 空间复杂度：邻接表存图 $O(V+E)$，check 的临时空间 $O(V)$；总计 $O(V+E)$。

#### 方法二：二分答案 + 记忆化搜索

**思路与算法**

方法二中的 $check$ 可以使用记忆化搜索来处理。

首先还是根据节点的在线情况建图。

定义 $dfs(u)$ 表示从 $u$ 到 $n-1$ 的有效路径的最小总恢复成本，对于 $u$ 的邻居 $v$，如果边权 $w\ge mid$，则表示当前从 $u$ 到 $v$ 的边是有效的。

定义 $dfs(v)$ 表示从 $v$ 到 $n-1$ 的有效路径的最小总恢复成本，那么对于 $u$ 所有的邻居，有:

$$dfs(u)=\mathop{min}\limits_v dfs(v)+w$$

我们从 $0$ 进入递归，走到 $n-1$ 结束，有 $dfs(n-1)=0$。

在递归过程中使用 $memo$ 数组来记录 $dfs$ 过程中已经计算过的值：$memo[u]$ 表示从 $u$ 到 $n-1$ 的有效路径的最小总恢复成本。

只要我们计算出的 $dfs[0]\le k$ 说明在 $mid$ 的限制下能够得到有效路径，否则无法得到有效路径。

**代码**

```C++
class Solution {
public:
    int findMaxPathScore(vector<vector<int>>& edges, vector<bool>& online, long long k) {
        int n = online.size();
        vector<vector<pair<int, int>>> g(n);
        int l = INT_MAX, r = 0;

        for (auto& edge : edges) {
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];
            if (!online[u] || !online[v]) {
                continue;
            }
            g[u].push_back({v, w});
            l = min(l, w);
            r = max(r, w);
        }

        auto check = [&](int mid) -> int {
            vector<long long> memo(n, -1);
            auto dfs = [&](this auto&& dfs, int u) -> long long {
                if (u == n - 1) {
                    return 0;
                }
                if (memo[u] != -1) {
                    return memo[u];
                }
                long long res = LLONG_MAX / 2;
                for (auto& [v, w] : g[u]) {
                    if (w >= mid) {
                        res = min(res, dfs(v) + w);
                    }
                }
                memo[u] = res;
                return memo[u];
            };
            return dfs(0) <= k;
        };

        if (!check(l)) {
            return -1;
        }

        while (l <= r) {
            int mid = (l + r) >> 1;
            if (check(mid)) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return r;
    }
};
```

```Go
func findMaxPathScore(edges [][]int, online []bool, k int64) int {
    n := len(online)
    g := make([][][2]int, n)
    l, r := int(1e9), 0

    for _, edge := range edges {
        u, v, w := edge[0], edge[1], edge[2]
        if !online[u] || !online[v] {
            continue
        }
        g[u] = append(g[u], [2]int{v, w})
        if w < l {
            l = w
        }
        if w > r {
            r = w
        }
    }

    check := func(mid int) bool {
        memo := make([]int64, n)
        for i := range memo {
            memo[i] = -1
        }

        var dfs func(int) int64
        dfs = func(u int) int64 {
            if u == n-1 {
                return 0
            }
            if memo[u] != -1 {
                return memo[u]
            }
            res := int64(1e18)
            for _, edge := range g[u] {
                v, w := edge[0], edge[1]
                if w >= mid {
                    if val := dfs(v) + int64(w); val < res {
                        res = val
                    }
                }
            }
            memo[u] = res
            return res
        }

        return dfs(0) <= k
    }

    if !check(l) {
        return -1
    }

    for l <= r {
        mid := (l + r) >> 1
        if check(mid) {
            l = mid + 1
        } else {
            r = mid - 1
        }
    }
    return r
}
```

```Python
class Solution:
    def findMaxPathScore(self, edges: List[List[int]], online: List[bool], k: int) -> int:
        n = len(online)
        g = [[] for _ in range(n)]
        l, r = float('inf'), 0

        for u, v, w in edges:
            if not online[u] or not online[v]:
                continue
            g[u].append((v, w))
            l = min(l, w)
            r = max(r, w)

        def check(mid: int) -> bool:
            memo = [-1] * n

            def dfs(u: int) -> int:
                if u == n - 1:
                    return 0
                if memo[u] != -1:
                    return memo[u]

                res = float('inf')
                for v, w in g[u]:
                    if w >= mid:
                        res = min(res, dfs(v) + w)

                memo[u] = res
                return res

            return dfs(0) <= k

        if not check(l):
            return -1

        while l <= r:
            mid = (l + r) >> 1
            if check(mid):
                l = mid + 1
            else:
                r = mid - 1

        return r
```

```Java
class Solution {
    private List<int[]>[] g;
    private long[] memo;
    private int n;

    public int findMaxPathScore(int[][] edges, boolean[] online, long k) {
        n = online.length;
        g = new ArrayList[n];
        for (int i = 0; i < n; i++) {
            g[i] = new ArrayList<>();
        }

        int l = Integer.MAX_VALUE, r = 0;
        for (int[] edge : edges) {
            int u = edge[0], v = edge[1], w = edge[2];
            if (!online[u] || !online[v]) {
                continue;
            }
            g[u].add(new int[]{v, w});
            l = Math.min(l, w);
            r = Math.max(r, w);
        }

        if (!check(l, k)) {
            return -1;
        }

        while (l <= r) {
            int mid = (l + r) >> 1;
            if (check(mid, k)) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return r;
    }

    private boolean check(int mid, long k) {
        memo = new long[n];
        Arrays.fill(memo, -1);
        return dfs(0, mid) <= k;
    }

    private long dfs(int u, int mid) {
        if (u == n - 1) {
            return 0;
        }
        if (memo[u] != -1) {
            return memo[u];
        }

        long res = Long.MAX_VALUE / 2;
        for (int[] edge : g[u]) {
            int v = edge[0], w = edge[1];
            if (w >= mid) {
                res = Math.min(res, dfs(v, mid) + w);
            }
        }
        memo[u] = res;
        return res;
    }
}
```

```CSharp
public class Solution {
    private List<(int, int)>[] g;
    private long[] memo;
    private int n;

    public int FindMaxPathScore(int[][] edges, bool[] online, long k) {
        n = online.Length;
        g = new List<(int, int)>[n];
        for (int i = 0; i < n; i++) {
            g[i] = new List<(int, int)>();
        }

        int l = int.MaxValue, r = 0;
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1], w = edge[2];
            if (!online[u] || !online[v]) {
                continue;
            }
            g[u].Add((v, w));
            l = Math.Min(l, w);
            r = Math.Max(r, w);
        }

        if (!Check(l, k)) {
            return -1;
        }

        while (l <= r) {
            int mid = (l + r) >> 1;
            if (Check(mid, k)) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return r;
    }

    private bool Check(int mid, long k) {
        memo = new long[n];
        Array.Fill(memo, -1);
        return Dfs(0, mid) <= k;
    }

    private long Dfs(int u, int mid) {
        if (u == n - 1) {
            return 0;
        }
        if (memo[u] != -1) {
            return memo[u];
        }

        long res = long.MaxValue / 2;
        foreach (var (v, w) in g[u]) {
            if (w >= mid) {
                res = Math.Min(res, Dfs(v, mid) + w);
            }
        }
        memo[u] = res;
        return res;
    }
}
```

```C
typedef struct {
    int v;
    int w;
} Edge;

typedef struct {
    Edge* edges;
    int size;
    int capacity;
} AdjList;

AdjList* g_graph = NULL;
long long* g_memo = NULL;
int g_n = 0;
int g_mid = 0;

void initAdjList(AdjList* list, int initialCapacity) {
    list->edges = (Edge*)malloc(initialCapacity * sizeof(Edge));
    list->size = 0;
    list->capacity = initialCapacity;
}

void freeAdjList(AdjList* list) {
    free(list->edges);
}

void addEdge(AdjList* list, int v, int w) {
    if (list->size >= list->capacity) {
        list->capacity *= 2;
        list->edges = (Edge*)realloc(list->edges, list->capacity * sizeof(Edge));
    }
    list->edges[list->size].v = v;
    list->edges[list->size].w = w;
    list->size++;
}

long long dfs(int u) {
    if (u == g_n - 1) {
        return 0;
    }

    if (g_memo[u] != -1) {
        return g_memo[u];
    }

    long long res = LLONG_MAX / 2;

    for (int i = 0; i < g_graph[u].size; i++) {
        int v = g_graph[u].edges[i].v;
        int w = g_graph[u].edges[i].w;

        if (w >= g_mid) {
            long long subResult = dfs(v);
            if (subResult != LLONG_MAX / 2) {
                long long total = subResult + w;
                if (total < res) {
                    res = total;
                }
            }
        }
    }

    g_memo[u] = res;
    return res;
}

bool check(int mid, long long k, AdjList* g, int n) {
    long long* memo = (long long*)malloc(n * sizeof(long long));
    for (int i = 0; i < n; i++) {
        memo[i] = -1;
    }

    g_graph = g;
    g_memo = memo;
    g_n = n;
    g_mid = mid;

    long long result = dfs(0);

    free(memo);

    g_graph = NULL;
    g_memo = NULL;
    g_n = 0;
    g_mid = 0;

    return result <= k;
}

int findMaxPathScore(int** edges, int edgesSize, int* edgesColSize,
                     bool* online, int onlineSize, long long k) {
    int n = onlineSize;

    AdjList* g = (AdjList*)malloc(n * sizeof(AdjList));
    for (int i = 0; i < n; i++) {
        initAdjList(&g[i], 4);
    }

    int l = INT_MAX;
    int r = 0;

    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0];
        int v = edges[i][1];
        int w = edges[i][2];

        if (!online[u] || !online[v]) {
            continue;
        }

        addEdge(&g[u], v, w);
        l = fmin(l, w);
        r = fmax(r, w);
    }

    if (!check(l, k, g, n)) {
        for (int i = 0; i < n; i++) {
            freeAdjList(&g[i]);
        }
        free(g);
        return -1;
    }

    while (l <= r) {
        int mid = (l + r) >> 1;
        if (check(mid, k, g, n)) {
            l = mid + 1;
        } else {
            r = mid - 1;
        }
    }

    for (int i = 0; i < n; i++) {
        freeAdjList(&g[i]);
    }
    free(g);

    return r;
}
```

```JavaScript
var findMaxPathScore = function(edges, online, k) {
    const n = online.length;
    const g = Array.from({ length: n }, () => []);
    let l = Infinity, r = 0;

    for (const [u, v, w] of edges) {
        if (!online[u] || !online[v]) {
            continue;
        }
        g[u].push([v, w]);
        l = Math.min(l, w);
        r = Math.max(r, w);
    }

    const check = (mid) => {
        const memo = new Array(n).fill(-1);

        const dfs = (u) => {
            if (u === n - 1) {
                return 0;
            }
            if (memo[u] !== -1) {
                return memo[u];
            }

            let res = Infinity;
            for (const [v, w] of g[u]) {
                if (w >= mid) {
                    res = Math.min(res, dfs(v) + w);
                }
            }
            memo[u] = res;
            return res;
        };

        return dfs(0) <= k;
    };

    if (!check(l)) {
        return -1;
    }

    while (l <= r) {
        const mid = (l + r) >> 1;
        if (check(mid)) {
            l = mid + 1;
        } else {
            r = mid - 1;
        }
    }
    return r;
};
```

```TypeScript
function findMaxPathScore(edges: number[][], online: boolean[], k: number): number {
    const n: number = online.length;
    const g: [number, number][][] = Array.from({ length: n }, () => []);
    let l: number = Infinity, r: number = 0;

    for (const [u, v, w] of edges) {
        if (!online[u] || !online[v]) {
            continue;
        }
        g[u].push([v, w]);
        l = Math.min(l, w);
        r = Math.max(r, w);
    }

    const check = (mid: number): boolean => {
        const memo: number[] = new Array(n).fill(-1);

        const dfs = (u: number): number => {
            if (u === n - 1) {
                return 0;
            }
            if (memo[u] !== -1) {
                return memo[u];
            }

            let res: number = Infinity;
            for (const [v, w] of g[u]) {
                if (w >= mid) {
                    res = Math.min(res, dfs(v) + w);
                }
            }
            memo[u] = res;
            return res;
        };

        return dfs(0) <= k;
    };

    if (!check(l)) {
        return -1;
    }

    while (l <= r) {
        const mid: number = (l + r) >> 1;
        if (check(mid)) {
            l = mid + 1;
        } else {
            r = mid - 1;
        }
    }
    return r;
}
```

```Rust
impl Solution {
    pub fn find_max_path_score(edges: Vec<Vec<i32>>, online: Vec<bool>, k: i64) -> i32 {
        let n = online.len();
        let mut g = vec![vec![]; n];
        let mut l = i32::MAX;
        let mut r = 0;

        for edge in &edges {
            let u = edge[0] as usize;
            let v = edge[1] as usize;
            let w = edge[2];
            if !online[u] || !online[v] {
                continue;
            }
            g[u].push((v, w as i64));
            l = l.min(w);
            r = r.max(w);
        }

        let check = |mid: i32| -> bool {
            fn dfs(u: usize, mid: i32, g: &Vec<Vec<(usize, i64)>>, memo: &mut Vec<i64>) -> i64 {
                if u == g.len() - 1 {
                    return 0;
                }
                if memo[u] != -1 {
                    return memo[u];
                }

                let mut res = i64::MAX / 2;
                for &(v, w) in &g[u] {
                    if w >= mid as i64 {
                        res = res.min(dfs(v, mid, g, memo) + w);
                    }
                }
                memo[u] = res;
                res
            }

            let mut memo = vec![-1i64; n];
            dfs(0, mid, &g, &mut memo) <= k
        };

        if !check(l) {
            return -1;
        }

        while l <= r {
            let mid = (l + r) >> 1;
            if check(mid) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        r
    }
}
```

**复杂度分析**

- 时间复杂度：$O((V+E)\log U)$，其中 $V$ 是 $online$ 的长度，$E$ 是 $edges$ 的长度，$U$ 是边权的最大值。
- 空间复杂度：$O(V+E)$。

#### 方法三：二分答案 $+$ 拓扑排序 $+$ 动态规划

**思路与算法**

在方法三中我们可以使用拓扑排序 $+$ 动态规划，从 $0$ 递推到 $n-1$ 地计算最小恢复成本。

需要注意的是我们需要先预处理那些 $0$ 无法到达的点。

这里使用 $dp[u]$ 表示从节点 $0$ 到 节点 $u$ 的最小恢复成本，对于边 $u\rightarrow v$ 若边权满足 $w\ge mid$，有转移方程：

$$dp[v]=min(dp[v],dp[u]+w)$$

拓扑排序加动态规划的思想是直接从 $0$ 递推到 $n-1$，而记忆化搜索是搜索到 $n-1$ 后再逐层返回到 $0$。这两个思路相当于是互相翻译的版本。

**代码**

```C++
class Solution {
public:
    int findMaxPathScore(vector<vector<int>>& edges, vector<bool>& online, long long k) {
        int n = online.size();
        vector<vector<pair<int, int>>> g(n);
        vector<int> deg(n, 0);
        int l = INT_MAX, r = 0;

        for (auto& edge : edges) {
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];
            if (!online[u] || !online[v]) {
                continue;
            }
            g[u].push_back({v, w});
            deg[v]++;
            l = min(l, w);
            r = max(r, w);
        }

        queue<int> q;
        for (int i = 1; i < n; i++) {
            if (!deg[i]) {
                q.push(i);
            }
        }

        while (!q.empty()) {
            int u = q.front();
            q.pop();
            for (auto& [v, _] : g[u]) {
                deg[v]--;
                if (v && deg[v] == 0) {
                    q.push(v);
                }
            }
        }

        auto check = [&](int mid) -> bool {
            vector<long long> dp(n, LLONG_MAX / 2);
            vector<int> cdeg = deg;
            dp[0] = 0;
            queue<int> q;
            q.push(0);
            while (!q.empty()) {
                int u = q.front();
                q.pop();
                if (u == n - 1) {
                    return dp[u] <= k;
                }
                for (auto& [v, w] : g[u]) {
                    if (w >= mid) {
                        dp[v] = min(dp[v], dp[u] + w);
                    }
                    cdeg[v]--;
                    if (!cdeg[v]) {
                        q.push(v);
                    }
                }
            }
            return false;
        };

        if (!check(l)) {
            return -1;
        }

        while (l <= r) {
            int mid = (l + r) >> 1;
            if (check(mid)) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return r;
    }
};
```

```Go
func findMaxPathScore(edges [][]int, online []bool, k int64) int {
    n := len(online)
    g := make([][][2]int, n)
    deg := make([]int, n)
    l, r := int(1e9), 0

    for _, edge := range edges {
        u, v, w := edge[0], edge[1], edge[2]
        if !online[u] || !online[v] {
            continue
        }
        g[u] = append(g[u], [2]int{v, w})
        deg[v]++
        if w < l {
            l = w
        }
        if w > r {
            r = w
        }
    }

    // 删除不可达节点
    q := make([]int, 0)
    for i := 1; i < n; i++ {
        if deg[i] == 0 {
            q = append(q, i)
        }
    }
    for len(q) > 0 {
        u := q[0]
        q = q[1:]
        for _, edge := range g[u] {
            v := edge[0]
            deg[v]--
            if v != 0 && deg[v] == 0 {
                q = append(q, v)
            }
        }
    }

    check := func(mid int) bool {
        dp := make([]int64, n)
        for i := range dp {
            dp[i] = math.MaxInt64 / 2
        }
        cdeg := make([]int, n)
        copy(cdeg, deg)
        dp[0] = 0

        q := []int{0}
        for len(q) > 0 {
            u := q[0]
            q = q[1:]
            if u == n-1 {
                return dp[u] <= k
            }
            for _, edge := range g[u] {
                v, w := edge[0], edge[1]
                if w >= mid {
                    if dp[u]+int64(w) < dp[v] {
                        dp[v] = dp[u] + int64(w)
                    }
                }
                cdeg[v]--
                if cdeg[v] == 0 {
                    q = append(q, v)
                }
            }
        }
        return false
    }

    if !check(l) {
        return -1
    }

    for l <= r {
        mid := (l + r) >> 1
        if check(mid) {
            l = mid + 1
        } else {
            r = mid - 1
        }
    }
    return r
}
```

```Python
class Solution:
    def findMaxPathScore(self, edges: List[List[int]], online: List[bool], k: int) -> int:
        n = len(online)
        g = [[] for _ in range(n)]
        deg = [0] * n
        l, r = float('inf'), 0

        for u, v, w in edges:
            if not online[u] or not online[v]:
                continue
            g[u].append((v, w))
            deg[v] += 1
            l = min(l, w)
            r = max(r, w)

        # 删除不可达节点
        q = deque([i for i in range(1, n) if deg[i] == 0])
        while q:
            u = q.popleft()
            for v, _ in g[u]:
                deg[v] -= 1
                if v and deg[v] == 0:
                    q.append(v)

        def check(mid: int) -> bool:
            dp = [math.inf] * n
            cdeg = deg.copy()
            dp[0] = 0

            q = deque([0])
            while q:
                u = q.popleft()
                if u == n - 1:
                    return dp[u] <= k

                for v, w in g[u]:
                    if w >= mid:
                        dp[v] = min(dp[v], dp[u] + w)
                    cdeg[v] -= 1
                    if cdeg[v] == 0:
                        q.append(v)
            return False

        if not check(l):
            return -1

        while l <= r:
            mid = (l + r) >> 1
            if check(mid):
                l = mid + 1
            else:
                r = mid - 1

        return r
```

```Java
class Solution {
    public int findMaxPathScore(int[][] edges, boolean[] online, long k) {
        int n = online.length;
        List<int[]>[] g = new ArrayList[n];
        int[] deg = new int[n];
        for (int i = 0; i < n; i++) {
            g[i] = new ArrayList<>();
        }

        int l = Integer.MAX_VALUE, r = 0;
        for (int[] edge : edges) {
            int u = edge[0], v = edge[1], w = edge[2];
            if (!online[u] || !online[v]) {
                continue;
            }
            g[u].add(new int[]{v, w});
            deg[v]++;
            l = Math.min(l, w);
            r = Math.max(r, w);
        }

        // 删除不可达节点
        Queue<Integer> q = new LinkedList<>();
        for (int i = 1; i < n; i++) {
            if (deg[i] == 0) {
                q.offer(i);
            }
        }
        while (!q.isEmpty()) {
            int u = q.poll();
            for (int[] edge : g[u]) {
                int v = edge[0];
                if (--deg[v] == 0 && v != 0) {
                    q.offer(v);
                }
            }
        }

        if (!check(l, k, g, deg, n)) {
            return -1;
        }

        while (l <= r) {
            int mid = (l + r) >> 1;
            if (check(mid, k, g, deg, n)) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return r;
    }

    private boolean check(int mid, long k, List<int[]>[] g, int[] deg, int n) {
        long[] dp = new long[n];
        Arrays.fill(dp, Long.MAX_VALUE / 2);
        int[] cdeg = deg.clone();
        dp[0] = 0;

        Queue<Integer> q = new LinkedList<>();
        q.offer(0);

        while (!q.isEmpty()) {
            int u = q.poll();
            if (u == n - 1) {
                return dp[u] <= k;
            }

            for (int[] edge : g[u]) {
                int v = edge[0], w = edge[1];
                if (w >= mid) {
                    dp[v] = Math.min(dp[v], dp[u] + w);
                }
                if (--cdeg[v] == 0) {
                    q.offer(v);
                }
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    public int FindMaxPathScore(int[][] edges, bool[] online, long k) {
        int n = online.Length;
        var g = new List<(int, int)>[n];
        var deg = new int[n];
        for (int i = 0; i < n; i++) {
            g[i] = new List<(int, int)>();
        }

        int l = int.MaxValue, r = 0;
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1], w = edge[2];
            if (!online[u] || !online[v]) {
                continue;
            }
            g[u].Add((v, w));
            deg[v]++;
            l = Math.Min(l, w);
            r = Math.Max(r, w);
        }

        // 删除不可达节点
        var q = new Queue<int>();
        for (int i = 1; i < n; i++) {
            if (deg[i] == 0) {
                q.Enqueue(i);
            }
        }
        while (q.Count > 0) {
            int u = q.Dequeue();
            foreach (var (v, _) in g[u]) {
                if (--deg[v] == 0 && v != 0) {
                    q.Enqueue(v);
                }
            }
        }

        if (!Check(l, k, g, deg, n)) {
            return -1;
        }

        while (l <= r) {
            int mid = (l + r) >> 1;
            if (Check(mid, k, g, deg, n)) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }
        return r;
    }

    private bool Check(int mid, long k, List<(int, int)>[] g, int[] deg, int n) {
        var dp = new long[n];
        Array.Fill(dp, long.MaxValue / 2);
        var cdeg = (int[])deg.Clone();
        dp[0] = 0;

        var q = new Queue<int>();
        q.Enqueue(0);

        while (q.Count > 0) {
            int u = q.Dequeue();
            if (u == n - 1) {
                return dp[u] <= k;
            }

            foreach (var (v, w) in g[u]) {
                if (w >= mid) {
                    dp[v] = Math.Min(dp[v], dp[u] + w);
                }
                if (--cdeg[v] == 0) {
                    q.Enqueue(v);
                }
            }
        }
        return false;
    }
}
```

```C
typedef struct {
    int v;
    int w;
} Edge;

typedef struct {
    Edge* edges;
    int size;
    int capacity;
} AdjList;

typedef struct {
    int* data;
    int front;
    int rear;
    int size;
    int capacity;
} Queue;

Queue* createQueue(int capacity) {
    Queue* q = (Queue*)malloc(sizeof(Queue));
    q->data = (int*)malloc(capacity * sizeof(int));
    q->front = 0;
    q->rear = -1;
    q->size = 0;
    q->capacity = capacity;
    return q;
}

void freeQueue(Queue* q) {
    free(q->data);
    free(q);
}

bool isEmpty(Queue* q) {
    return q->size == 0;
}

void enqueue(Queue* q, int value) {
    q->rear = (q->rear + 1) % q->capacity;
    q->data[q->rear] = value;
    q->size++;
}

int dequeue(Queue* q) {
    int value = q->data[q->front];
    q->front = (q->front + 1) % q->capacity;
    q->size--;
    return value;
}

void initAdjList(AdjList* list, int capacity) {
    list->edges = (Edge*)malloc(capacity * sizeof(Edge));
    list->size = 0;
    list->capacity = capacity;
}

void freeAdjList(AdjList* list) {
    free(list->edges);
}

void addEdge(AdjList* list, int v, int w) {
    if (list->size >= list->capacity) {
        list->capacity *= 2;
        list->edges = (Edge*)realloc(list->edges, list->capacity * sizeof(Edge));
    }
    list->edges[list->size].v = v;
    list->edges[list->size].w = w;
    list->size++;
}

bool check(int mid, long long k, AdjList* g, int* deg, int n) {
    long long* dp = (long long*)malloc(n * sizeof(long long));
    int* cdeg = (int*)malloc(n * sizeof(int));

    for (int i = 0; i < n; i++) {
        dp[i] = LLONG_MAX / 2;
        cdeg[i] = deg[i];
    }

    dp[0] = 0;
    Queue* q = createQueue(n);
    enqueue(q, 0);

    while (!isEmpty(q)) {
        int u = dequeue(q);

        if (u == n - 1) {
            bool result = dp[u] <= k;
            free(dp);
            free(cdeg);
            freeQueue(q);
            return result;
        }

        for (int i = 0; i < g[u].size; i++) {
            int v = g[u].edges[i].v;
            int w = g[u].edges[i].w;

            if (w >= mid) {
                long long newDist = dp[u] + w;
                if (newDist < dp[v]) {
                    dp[v] = newDist;
                }
            }

            cdeg[v]--;
            if (cdeg[v] == 0) {
                enqueue(q, v);
            }
        }
    }

    free(dp);
    free(cdeg);
    freeQueue(q);
    return false;
}

int findMaxPathScore(int** edges, int edgesSize, int* edgesColSize,
                     bool* online, int onlineSize, long long k) {
    int n = onlineSize;
    AdjList* g = (AdjList*)malloc(n * sizeof(AdjList));
    for (int i = 0; i < n; i++) {
        initAdjList(&g[i], 4);
    }
    int* deg = (int*)calloc(n, sizeof(int));
    int l = INT_MAX, r = 0;

    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0];
        int v = edges[i][1];
        int w = edges[i][2];

        if (!online[u] || !online[v]) {
            continue;
        }

        addEdge(&g[u], v, w);
        deg[v]++;
        l = fmin(l, w);
        r = fmax(r, w);
    }

    // 删除不可达节点
    Queue* q = createQueue(n);
    for (int i = 1; i < n; i++) {
        if (deg[i] == 0) {
            enqueue(q, i);
        }
    }

    while (!isEmpty(q)) {
        int u = dequeue(q);

        for (int i = 0; i < g[u].size; i++) {
            int v = g[u].edges[i].v;
            deg[v]--;
            if (deg[v] == 0 && v != 0) {
                enqueue(q, v);
            }
        }
    }
    freeQueue(q);

    if (!check(l, k, g, deg, n)) {
        for (int i = 0; i < n; i++) {
            freeAdjList(&g[i]);
        }
        free(g);
        free(deg);
        return -1;
    }

    // 二分查找
    while (l <= r) {
        int mid = (l + r) >> 1;
        if (check(mid, k, g, deg, n)) {
            l = mid + 1;
        } else {
            r = mid - 1;
        }
    }

    for (int i = 0; i < n; i++) {
        freeAdjList(&g[i]);
    }
    free(g);
    free(deg);

    return r;
}
```

```JavaScript
var findMaxPathScore = function(edges, online, k) {
    const n = online.length;
    const g = Array.from({ length: n }, () => []);
    const deg = new Array(n).fill(0);
    let l = Infinity, r = 0;

    for (const [u, v, w] of edges) {
        if (!online[u] || !online[v]) {
            continue;
        }
        g[u].push([v, w]);
        deg[v]++;
        l = Math.min(l, w);
        r = Math.max(r, w);
    }

    // 删除不可达节点
    const q = [];
    for (let i = 1; i < n; i++) {
        if (deg[i] === 0) {
            q.push(i);
        }
    }
    while (q.length > 0) {
        const u = q.shift();
        for (const [v] of g[u]) {
            if (--deg[v] === 0 && v !== 0) {
                q.push(v);
            }
        }
    }

    const check = (mid) => {
        const dp = new Array(n).fill(Infinity);
        const cdeg = [...deg];
        dp[0] = 0;

        const q = [0];
        while (q.length > 0) {
            const u = q.shift();
            if (u === n - 1) {
                return dp[u] <= k;
            }

            for (const [v, w] of g[u]) {
                if (w >= mid) {
                    dp[v] = Math.min(dp[v], dp[u] + w);
                }
                if (--cdeg[v] === 0) {
                    q.push(v);
                }
            }
        }
        return false;
    };

    if (!check(l)) {
        return -1;
    }

    while (l <= r) {
        const mid = (l + r) >> 1;
        if (check(mid)) {
            l = mid + 1;
        } else {
            r = mid - 1;
        }
    }
    return r;
};
```

```TypeScript
function findMaxPathScore(edges: number[][], online: boolean[], k: number): number {
    const n: number = online.length;
    const g: [number, number][][] = Array.from({ length: n }, () => []);
    const deg: number[] = new Array(n).fill(0);
    let l: number = Infinity, r: number = 0;

    for (const [u, v, w] of edges) {
        if (!online[u] || !online[v]) {
            continue;
        }
        g[u].push([v, w]);
        deg[v]++;
        l = Math.min(l, w);
        r = Math.max(r, w);
    }

    // 删除不可达节点
    const q: number[] = [];
    for (let i = 1; i < n; i++) {
        if (deg[i] === 0) {
            q.push(i);
        }
    }
    while (q.length > 0) {
        const u = q.shift()!;
        for (const [v] of g[u]) {
            if (--deg[v] === 0 && v !== 0) {
                q.push(v);
            }
        }
    }

    const check = (mid: number): boolean => {
        const dp: number[] = new Array(n).fill(Infinity);
        const cdeg: number[] = [...deg];
        dp[0] = 0;

        const q: number[] = [0];
        while (q.length > 0) {
            const u = q.shift()!;
            if (u === n - 1) {
                return dp[u] <= k;
            }

            for (const [v, w] of g[u]) {
                if (w >= mid) {
                    dp[v] = Math.min(dp[v], dp[u] + w);
                }
                if (--cdeg[v] === 0) {
                    q.push(v);
                }
            }
        }
        return false;
    };

    if (!check(l)) {
        return -1;
    }

    while (l <= r) {
        const mid = (l + r) >> 1;
        if (check(mid)) {
            l = mid + 1;
        } else {
            r = mid - 1;
        }
    }
    return r;
}
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn find_max_path_score(edges: Vec<Vec<i32>>, online: Vec<bool>, k: i64) -> i32 {
        let n = online.len();
        let mut g: Vec<Vec<(usize, i32)>> = vec![Vec::new(); n];
        let mut deg = vec![0; n];

        let mut l = i32::MAX;
        let mut r = 0;

        for edge in &edges {
            let u = edge[0] as usize;
            let v = edge[1] as usize;
            let w = edge[2];

            if !online[u] || !online[v] {
                continue;
            }

            g[u].push((v, w));
            deg[v] += 1;
            l = l.min(w);
            r = r.max(w);
        }

        // 删除不可达节点
        let mut q = VecDeque::new();
        for i in 1..n {
            if deg[i] == 0 {
                q.push_back(i);
            }
        }

        while let Some(u) = q.pop_front() {
            for &(v, _) in &g[u] {
                deg[v] -= 1;
                if deg[v] == 0 && v != 0 {
                    q.push_back(v);
                }
            }
        }

        if !Self::check(l, k, &g, &deg, n) {
            return -1;
        }

        while l <= r {
            let mid = (l + r) >> 1;
            if Self::check(mid, k, &g, &deg, n) {
                l = mid + 1;
            } else {
                r = mid - 1;
            }
        }

        r
    }

    fn check(mid: i32, k: i64, g: &[Vec<(usize, i32)>], deg: &[i32], n: usize) -> bool {
        let mut dp = vec![i64::MAX / 2; n];
        let mut cdeg = deg.to_vec();
        let mut q = VecDeque::new();

        dp[0] = 0;
        q.push_back(0);

        while let Some(u) = q.pop_front() {
            if u == n - 1 {
                return dp[u] <= k;
            }

            for &(v, w) in &g[u] {
                if w >= mid {
                    dp[v] = dp[v].min(dp[u].saturating_add(w as i64));
                }
                cdeg[v] -= 1;
                if cdeg[v] == 0 {
                    q.push_back(v);
                }
            }
        }

        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O((V+E)\log U)$，其中 $V$ 是 $online$ 的长度，$E$ 是 $edges$ 的长度，$U$ 是边权的最大值。
- 空间复杂度：$O(V+E)$。
