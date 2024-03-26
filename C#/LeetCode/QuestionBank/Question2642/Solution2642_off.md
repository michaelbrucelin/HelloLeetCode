### [设计可以求最短路径的图类](https://leetcode.cn/problems/design-graph-with-shortest-path-calculator/solutions/2701377/she-ji-ke-yi-qiu-zui-duan-lu-jing-de-tu-hj8e9/)

#### 方法一：Dijkstra 求最短路径

##### 思路与算法

根据题目要求实现 $\text{Graph}$ 类，分别实现以下函数接口：

- $\text{Graph(int n, int[][] edges)}$ 初始化图有 $n$ 个节点，并输入初始边。根据题意我们可以用**邻接列表**来保存有向图中边的关系，因此 $\text{Graph}$ 类初始化时，直接用**邻接列表**建图即可。
- $\text{addEdge(int[] edge)}$ 向边集中添加一条边，其中 $\textit{edge} = [\textit{from}, \textit{to}, \textit{edgeCost}]$。当调用 $\text{addEdge(int[] edge)}$ 向边集中添加一条边时，此时我们直接更新**邻接列表**即可。
- $\text{int shortestPath(int node1, int node2)}$ 返回从节点 $\text{node1}$ 到 $\text{node2}$ 的路径**最小**代价，一条路径的代价是路径中所有边代价之和。如果路径不存在，返回 $\text{-1}$。求有向图中的最短距离是个经典的问题，我们可以直接利用「[Dijkstra 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fshortest-path%2F%23dijkstra-%E7%AE%97%E6%B3%95)」求图中两个节点的最短距离。本题中我们使用堆优化的「[Dijkstra 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fshortest-path%2F%23dijkstra-%E7%AE%97%E6%B3%95)」求最短距离，需要的时间复杂度为 $O(m \log m)$，其中 $m$ 表示图中边的数目。

##### 代码

```c++
class Graph {
public:
    using pii = pair<int, int>;
    Graph(int n, vector<vector<int>>& edges) {
        this->graph = vector<vector<pii>>(n);
        for (auto &vec : edges) {
            int x = vec[0];
            int y = vec[1];
            int cost = vec[2];
            graph[x].emplace_back(y, cost);
        }
    }
    
    void addEdge(vector<int> edge) {
        int x = edge[0];
        int y = edge[1];
        int cost = edge[2];
        graph[x].emplace_back(y, cost);
    }
    
    int shortestPath(int node1, int node2) {
        priority_queue<pii, vector<pii>, greater<pii>> pq;
        vector<int> dist(graph.size(), INT_MAX);
        dist[node1] = 0;
        pq.emplace(0, node1);
        while (!pq.empty()) {
            auto [cost, cur] = pq.top();
            pq.pop();
            if (cur == node2) {
                return cost;
            }
            for (auto [next, ncost] : graph[cur]) {
                if (dist[next] > cost + ncost) {
                    dist[next] = cost + ncost;
                    pq.emplace(cost + ncost, next);
                }
            }
        }
        return -1;
    }
private:
    vector<vector<pii>> graph;
};
```

```java
class Graph {
    private List<int[]>[] graph;

    public Graph(int n, int[][] edges) {
        graph = new List[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new ArrayList<int[]>();
        }
        for (int[] edge : edges) {
            int x = edge[0];
            int y = edge[1];
            int cost = edge[2];
            graph[x].add(new int[]{y, cost});
        }
    }

    public void addEdge(int[] edge) {
        int x = edge[0];
        int y = edge[1];
        int cost = edge[2];
        graph[x].add(new int[]{y, cost});
    }

    public int shortestPath(int node1, int node2) {
        PriorityQueue<int[]> pq = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);
        int[] dist = new int[graph.length];
        Arrays.fill(dist, Integer.MAX_VALUE);
        dist[node1] = 0;
        pq.offer(new int[]{0, node1});
        while (!pq.isEmpty()) {
            int[] arr = pq.poll();
            int cost = arr[0], cur = arr[1];
            if (cur == node2) {
                return cost;
            }
            for (int[] nextArr : graph[cur]) {
                int next = nextArr[0], ncost = nextArr[1];
                if (dist[next] > cost + ncost) {
                    dist[next] = cost + ncost;
                    pq.offer(new int[]{cost + ncost, next});
                }
            }
        }
        return -1;
    }
}
```

```csharp
public class Graph {
    private IList<int[]>[] graph;

    public Graph(int n, int[][] edges) {
        graph = new IList<int[]>[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new List<int[]>();
        }
        foreach (int[] edge in edges) {
            int x = edge[0];
            int y = edge[1];
            int cost = edge[2];
            graph[x].Add(new int[]{y, cost});
        }
    }
    
    public void AddEdge(int[] edge) {
        int x = edge[0];
        int y = edge[1];
        int cost = edge[2];
        graph[x].Add(new int[]{y, cost});
    }
    
    public int ShortestPath(int node1, int node2) {
        PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
        int[] dist = new int[graph.Length];
        Array.Fill(dist, int.MaxValue);
        dist[node1] = 0;
        pq.Enqueue(new int[]{0, node1}, 0);
        while (pq.Count > 0) {
            int[] arr = pq.Dequeue();
            int cost = arr[0], cur = arr[1];
            if (cur == node2) {
                return cost;
            }
            foreach (int[] nextArr in graph[cur]) {
                int next = nextArr[0], ncost = nextArr[1];
                if (dist[next] > cost + ncost) {
                    dist[next] = cost + ncost;
                    pq.Enqueue(new int[]{cost + ncost, next}, cost + ncost);
                }
            }
        }
        return -1;
    }
}
```

```c
typedef struct Edge {
    int to;
    int cost;
    struct Edge *next;
} Edge;

typedef struct {
    int first;
    int second;
} Node;

typedef bool (*cmp)(const void *, const void *);

typedef struct {
    Node *arr;
    int capacity;
    int queueSize;
    cmp compare;
} PriorityQueue;

Edge *createEdge(int to, int cost) {
    Edge *obj = (Edge *)malloc(sizeof(Edge));
    obj->to = to;
    obj->cost = cost;
    obj->next = NULL;
    return obj;
}

void freeEdgeList(Edge *list) {
    while (list) {
        Edge *p = list;
        list = list->next;
        free(p);
    }
}

Node *createNode(long long x, int y) {
    Node *obj = (Node *)malloc(sizeof(Node));
    obj->first = x;
    obj->second = y;
    return obj;
}

PriorityQueue *createPriorityQueue(int size, cmp compare) {
    PriorityQueue *obj = (PriorityQueue *)malloc(sizeof(PriorityQueue));
    obj->arr = (Node *)malloc(sizeof(Node) * size);
    obj->queueSize = 0;
    obj->capacity = size;
    obj->compare = compare;
    return obj;
}

static void swap(Node *arr, int i, int j) {
    Node tmp;
    memcpy(&tmp, &arr[i], sizeof(Node));
    memcpy(&arr[i], &arr[j], sizeof(Node));
    memcpy(&arr[j], &tmp, sizeof(Node));
}

static void down(Node *arr, int size, int i, cmp compare) {
    for (int k = 2 * i + 1; k < size; k = 2 * k + 1) {
        // 父节点 (k - 1) / 2，左子节点 k，右子节点 k + 1
        if (k + 1 < size && compare(&arr[k], &arr[k + 1])) {
            k++;
        }
        if (compare(&arr[k], &arr[(k - 1) / 2])) {
            break;
        }
        swap(arr, k, (k - 1) / 2);
    }
}

void Heapify(PriorityQueue *obj) {
    for (int i = obj->queueSize / 2 - 1; i >= 0; i--) {
        down(obj->arr, obj->queueSize, i, obj->compare);
    }
}

void Push(PriorityQueue *obj, Node *node) {
    memcpy(&obj->arr[obj->queueSize], node, sizeof(Node));
    for (int i = obj->queueSize; i > 0 && obj->compare(&obj->arr[(i - 1) / 2], &obj->arr[i]); i = (i - 1) / 2) {
        swap(obj->arr, i, (i - 1) / 2);
    }
    obj->queueSize++;
}

Node* Pop(PriorityQueue *obj) {
    swap(obj->arr, 0, obj->queueSize - 1);
    down(obj->arr, obj->queueSize - 1, 0, obj->compare);
    Node *ret =  &obj->arr[obj->queueSize - 1];
    obj->queueSize--;
    return ret;
}

bool isEmpty(PriorityQueue *obj) {
    return obj->queueSize == 0;
}

Node* Top(PriorityQueue *obj) {
    if (obj->queueSize == 0) {
        return NULL;
    } else {
        return &obj->arr[0];
    }
}

void FreePriorityQueue(PriorityQueue *obj) {
    free(obj->arr);
    free(obj);
}

bool greater(const void *a, const void *b) {
   return ((Node *)a)->first > ((Node *)b)->first;
}

typedef struct {
    Edge **graph;
    int nodeSize;
} Graph;


Graph* graphCreate(int n, int** edges, int edgesSize, int* edgesColSize) {
    Graph *obj = (Graph *)malloc(sizeof(Graph));
    obj->nodeSize = n;
    obj->graph = (Edge **)malloc(sizeof(Edge *) * n);
    for (int i = 0; i < n; i++) {
        obj->graph[i] = NULL;
    }
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0];
        int y = edges[i][1];
        int cost = edges[i][2];
        Edge *e = (Edge *)malloc(sizeof(Edge));
        e->to = y;
        e->cost = cost;
        e->next = obj->graph[x];
        obj->graph[x] = e;
    }

    return obj;
}

void graphAddEdge(Graph* obj, int* edge, int edgeSize) {
    int x = edge[0];
    int y = edge[1];
    int cost = edge[2];
    Edge *e = (Edge *)malloc(sizeof(Edge));
    e->to = y;
    e->cost = cost;
    e->next = obj->graph[x];
    obj->graph[x] = e;
}

int graphShortestPath(Graph* obj, int node1, int node2) {
    int n = obj->nodeSize;
    int dist[n];
    PriorityQueue *pq = createPriorityQueue(n * n, greater);
    for (int i = 0; i < n; i++) {
        dist[i] = INT_MAX;
    }
    dist[node1] = 0;
    Node val;
    val.first = 0;
    val.second = node1;
    Push(pq, &val);
    while (!isEmpty(pq)) {
        Node *p = Pop(pq);
        int cost = p->first;
        int cur = p->second;
        if (cur == node2) {
            return cost;
        }
        for (Edge *pEntry = obj->graph[cur]; pEntry; pEntry = pEntry->next) {
            int next = pEntry->to;
            int ncost = pEntry->cost;
            if (dist[next] > cost + ncost) {
                dist[next] = cost + ncost;
                val.first = cost + ncost;
                val.second = next;
                Push(pq, &val);
            }
        }
    }
    return -1;
}

void graphFree(Graph* obj) {
    for (int i = 0; i < obj->nodeSize; i++) {
        freeEdgeList(obj->graph[i]);
    }
    free(obj->graph);
    free(obj);
}
```

```python
class Graph:
    def __init__(self, n: int, edges: List[List[int]]):
        self.graph = [[] for _ in range(n)]
        for x, y, cost in edges:
            self.graph[x].append((y, cost))

    def addEdge(self, edge: List[int]) -> None:
        x, y, cost = edge[0], edge[1], edge[2]
        self.graph[x].append((y, cost))  

    def shortestPath(self, node1: int, node2: int) -> int: 
        dist = [inf] * len(self.graph)
        dist[node1] = 0
        q = [(0, node1)]
        while q:
            cost, x = heapq.heappop(q)
            if x == node2:
                return cost
            for y, ncost in self.graph[x]:
                if dist[y] > cost + ncost:
                    dist[y] = cost + ncost
                    heapq.heappush(q, [cost + ncost, y])
        return -1
```

```javascript
var Graph = function(n, edges) {
    this.graph = new Array(n).fill(0).map(() => new Array());
    for (const [x, y, cost] of edges) {
        this.graph[x].push([y, cost]);
    }
};

Graph.prototype.addEdge = function(edge) {
    this.graph[edge[0]].push([edge[1], edge[2]]);
};

Graph.prototype.shortestPath = function(node1, node2) {
    const dist = new Array(this.graph.length).fill(Infinity);
    dist[node1] = 0;
    const q = new MinPriorityQueue();
    q.enqueue([0, node1], 0);
    while (!q.isEmpty()) {
        let cost = q.front().element[0];
        let x = q.front().element[1];
        q.dequeue();
        if (x == node2) {
            return cost;
        }
        for (const [y, ncost] of this.graph[x]) {
            if (dist[y] > cost + ncost) {
                dist[y] = cost + ncost
                q.enqueue([cost + ncost, y], cost + ncost);
            }
        }
    }
    return -1;
};
```

```go
type Graph struct {
    graph [][]Pair
}

func Constructor(n int, edges [][]int) Graph {
    g := make([][]Pair, n)
    for i := 0; i < n; i++ {
        g[i] = []Pair{}
    }
    for _, e := range edges {
        x, y, cost := e[0], e[1], e[2]
        g[x] = append(g[x], Pair{y, cost})
    }
    return Graph{g}
}

func (this *Graph) AddEdge(edge []int)  {
    x, y, cost := edge[0], edge[1], edge[2]
    (*this).graph[x] = append((*this).graph[x], Pair{y, cost})
}

func (this *Graph) ShortestPath(node1 int, node2 int) int {
    pq := PriorityQueue{}
    dist := make([]int, len((*this).graph))
    for i := 0; i < len((*this).graph); i++ {
        dist[i] = math.MaxInt32
    }
    dist[node1] = 0
    heap.Push(&pq, Pair{0, node1})
    for len(pq) > 0 {
        p := heap.Pop(&pq).(Pair)
        cost, cur := p.first, p.second
        if cur == node2 {
            return cost
        }
        for _, e := range (*this).graph[cur] {
            next, ncost := e.first, e.second
            if dist[next] > cost + ncost {
                dist[next] = cost + ncost
                heap.Push(&pq, Pair{cost + ncost, next})
            }
        }
    }
    return -1;
}

type Pair struct {
    first int
    second int
}

type PriorityQueue []Pair

func (pq PriorityQueue) Swap(i, j int) {
    pq[i], pq[j] = pq[j], pq[i]
}

func (pq PriorityQueue) Len() int {
    return len(pq)
}

func (pq PriorityQueue) Less(i, j int) bool {
    return pq[i].first < pq[j].first
}

func (pq *PriorityQueue) Push(x any) {
    *pq = append(*pq, x.(Pair))
}

func (pq *PriorityQueue) Pop() any {
    n := len(*pq)
    x := (*pq)[n - 1]
    *pq = (*pq)[:n - 1]
    return x
}
```

```typescript
class Graph {
    private graph: [number, number][][];

    constructor(n: number, edges: number[][]) {
        this.graph = new Array(n).fill(0).map(() => []);
        for (const [x, y, cost] of edges) {
            this.graph[x].push([y, cost]);
        }
    }

    addEdge(edge: number[]): void {
        this.graph[edge[0]].push([edge[1], edge[2]]);
    }

    shortestPath(node1: number, node2: number): number {
        const dist = new Array(this.graph.length).fill(Infinity);
        dist[node1] = 0;
        const q = new MinPriorityQueue();
        q.enqueue([0, node1], 0);
        while (!q.isEmpty()) {
            let [cost, x] = q.front().element;
            q.dequeue();
            if (x === node2) {
                return cost;
            }
            for (const [y, ncost] of this.graph[x]) {
                if (dist[y] > cost + ncost) {
                    dist[y] = cost + ncost
                    q.enqueue([cost + ncost, y], cost + ncost);
                }
            }
        }
        return -1;
    }
}
```

```rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

struct Graph {
    graph: Vec<Vec<(i32, i32)>>,
}

impl Graph {
    fn new(n: i32, edges: Vec<Vec<i32>>) -> Self {
        let mut graph = vec![Vec::new(); n as usize];
        for edge in edges {
            let x = edge[0];
            let y = edge[1];
            let cost = edge[2];
            graph[x as usize].push((y, cost));
        }
        Graph {graph}
    }
    
    fn add_edge(&mut self, edge: Vec<i32>) {
        let x = edge[0];
        let y = edge[1];
        let cost = edge[2];
        &self.graph[x as usize].push((y, cost));
    }
    
    fn shortest_path(&self, node1: i32, node2: i32) -> i32 {
        let mut pq = BinaryHeap::new();
        let mut dist = vec![std::i32::MAX; self.graph.len()];
        dist[node1 as usize] = 0;
        pq.push((Reverse(0), node1));
        while let Some((Reverse(cost), cur)) = pq.pop() {
            if cur == node2 {
                return cost;
            }
            for &(next, ncost) in &self.graph[cur as usize] {
                if dist[next as usize] > cost + ncost as i32 {
                    dist[next as usize] = cost + ncost as i32;
                    pq.push((Reverse(cost + ncost as i32), next));
                }
            }
        }
        -1
    }
}
```

##### 复杂度分析

- 时间复杂度：题目分别要求实现三个函数：
    - $\text{Graph}$ 类初始化时，时间复杂度为 $O(m)$，其中 $m$ 表示给定的 $\text{edges}$ 数组的长度。
    - 调用 $\text{addEdge}$ 时，此时直接在邻接边中添加一条边即可，时间复杂度为 $O(1)$。
    - 调用 $\text{shortestPath}$ 时，需要的时间复杂度为 $O(m + k) \log (m + k)$，其中 $m$ 表示给定的 $\text{edges}$ 数组的长度，$k$ 表示调用 $\text{addEdge}$ 的次数。使用优先队列的 「[Dijkstra 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fshortest-path%2F%23dijkstra-%E7%AE%97%E6%B3%95)」的时间度与图中边的数量关系有关，需要的时间即为 $O(m + k) \log (m + k)$。
- 空间复杂度：$O(n + m + k)$，其中 $n$ 表示给定的数字 $n$，其中 $m$ 表示给定的 $\text{edges}$ 数组的长度，$k$ 表示调用 $\text{addEdge}$ 的次数。使用邻接列表存储图时，需要的空间即为 $O(n + m + k)$。

#### 方法二：Floyd 求最短路径

##### 思路与算法

求图中的最短路径，我们还可以使用「[Floyd 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fshortest-path%2F%23floyd-%E7%AE%97%E6%B3%95)」来求节点之间的最短距离，具体的算法细节可以参考相关资料即可。使用 $\textit{dist}[i][j]$ 存储节点 $i$ 到节点 $j$ 之间的最短距离，利用「[Floyd 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fshortest-path%2F%23floyd-%E7%AE%97%E6%B3%95)」求最短距离需要的时间为 $O(n^3)$。

##### 代码

```c++
class Graph {
public:
    Graph(int n, vector<vector<int>>& edges) {
        dist = vector<vector<int>>(n, vector<int>(n, INT_MAX));
        for (int i = 0; i < n; i++) {
            dist[i][i] = 0;
        }
        for (auto &e: edges) {
            dist[e[0]][e[1]] = e[2];
        }
        for (int k = 0; k < n; k++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (dist[i][k] != INT_MAX && dist[k][j] != INT_MAX) {
                        dist[i][j] = min(dist[i][j], dist[i][k] + dist[k][j]);
                    }
                }
            }
        }
    }
    
    void addEdge(vector<int> edge) {
        int x = edge[0], y = edge[1], cost = edge[2];
        if (cost >= dist[x][y]) {
            return;
        }
        int n = dist.size();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (dist[i][x] != INT_MAX && dist[y][j] != INT_MAX) {
                    dist[i][j] = min(dist[i][j], dist[i][x] + cost + dist[y][j]);
                }
            }
        }
    }
    
    int shortestPath(int node1, int node2) {
        int res = dist[node1][node2];
        return res == INT_MAX ? -1 : res;
    }
private:
    vector<vector<int>> dist;
};
```

```java
class Graph {
    private int[][] dist;

    public Graph(int n, int[][] edges) {
        dist = new int[n][n];
        for (int i = 0; i < n; i++) {
            Arrays.fill(dist[i], Integer.MAX_VALUE);
            dist[i][i] = 0;
        }
        for (int[] edge : edges) {
            dist[edge[0]][edge[1]] = edge[2];
        }
        for (int k = 0; k < n; k++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (dist[i][k] != Integer.MAX_VALUE && dist[k][j] != Integer.MAX_VALUE) {
                        dist[i][j] = Math.min(dist[i][j], dist[i][k] + dist[k][j]);
                    }
                }
            }
        }
    }

    public void addEdge(int[] edge) {
        int x = edge[0], y = edge[1], cost = edge[2];
        if (cost >= dist[x][y]) {
            return;
        }
        int n = dist.length;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (dist[i][x] != Integer.MAX_VALUE && dist[y][j] != Integer.MAX_VALUE) {
                    dist[i][j] = Math.min(dist[i][j], dist[i][x] + cost + dist[y][j]);
                }
            }
        }
    }

    public int shortestPath(int node1, int node2) {
        int res = dist[node1][node2];
        return res == Integer.MAX_VALUE ? -1 : res;
    }
}
```

```csharp
public class Graph {
    private int[][] dist;

    public Graph(int n, int[][] edges) {
        dist = new int[n][];
        for (int i = 0; i < n; i++) {
            dist[i] = new int[n];
            Array.Fill(dist[i], int.MaxValue);
            dist[i][i] = 0;
        }
        foreach (int[] edge in edges) {
            dist[edge[0]][edge[1]] = edge[2];
        }
        for (int k = 0; k < n; k++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (dist[i][k] != int.MaxValue && dist[k][j] != int.MaxValue) {
                        dist[i][j] = Math.Min(dist[i][j], dist[i][k] + dist[k][j]);
                    }
                }
            }
        }
    }

    public void AddEdge(int[] edge) {
        int x = edge[0], y = edge[1], cost = edge[2];
        if (cost >= dist[x][y]) {
            return;
        }
        int n = dist.Length;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (dist[i][x] != int.MaxValue && dist[y][j] != int.MaxValue) {
                    dist[i][j] = Math.Min(dist[i][j], dist[i][x] + cost + dist[y][j]);
                }
            }
        }
    }

    public int ShortestPath(int node1, int node2) {
        int res = dist[node1][node2];
        return res == int.MaxValue ? -1 : res;
    }
}
```

```c
typedef struct {
    int **dist;  
    int n;  
} Graph;


Graph* graphCreate(int n, int** edges, int edgesSize, int* edgesColSize) {
    Graph *obj = (Graph *)malloc(sizeof(Graph));
    obj->dist = (int **)malloc(sizeof(int *) * n);
    obj->n = n;
    for (int i = 0; i < n; i++) {
        obj->dist[i] = (int *)malloc(sizeof(int) * n);
        for (int j = 0; j < n; j++) {
            obj->dist[i][j] = INT_MAX;
        }
         obj->dist[i][i] = 0;
    }
    for (int i = 0; i < edgesSize; i++) {
        int x = edges[i][0], y = edges[i][1], cost = edges[i][2];
        obj->dist[x][y] = cost;
    }
    for (int k = 0; k < n; k++) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (obj->dist[i][k] != INT_MAX && obj->dist[k][j] != INT_MAX) {
                    obj->dist[i][j] = fmin(obj->dist[i][j], obj->dist[i][k] + obj->dist[k][j]);
                }
            }
        }
    }
    return obj;
}

void graphAddEdge(Graph* obj, int* edge, int edgeSize) {
    int x = edge[0], y = edge[1], cost = edge[2];
    if (cost >= obj->dist[x][y]) {
        return;
    }
    for (int i = 0; i < obj->n; i++) {
        for (int j = 0; j < obj->n; j++) {
            if (obj->dist[i][x] != INT_MAX && obj->dist[y][j] != INT_MAX) {
                obj->dist[i][j] = fmin(obj->dist[i][j], obj->dist[i][x] + cost + obj->dist[y][j]);
            }
        }
    }
}

int graphShortestPath(Graph* obj, int node1, int node2) {
    int res = obj->dist[node1][node2];
    return res == INT_MAX ? -1 : res;
}

void graphFree(Graph* obj) {
    for (int i = 0; i < obj->n; i++) {
        free(obj->dist[i]);
    }
    free(obj->dist);
    free(obj);
}
```

```python
class Graph:
    def __init__(self, n: int, edges: List[List[int]]):
        self.dist = [[inf] * n for _ in range(n)]
        for i in range(n):
            self.dist[i][i] = 0
        for x, y, cost in edges:
            self.dist[x][y] = cost
        for k in range(n):
            for i in range(n):
                for j in range(n):
                    self.dist[i][j] = min(self.dist[i][j], self.dist[i][k] + self.dist[k][j])

    def addEdge(self, edge: List[int]) -> None:
        x, y, cost = edge[0], edge[1], edge[2]
        if cost >= self.dist[x][y]:
            return
        n = len(self.dist)
        for i in range(n):
            for j in range(n):
                self.dist[i][j] = min(self.dist[i][j], self.dist[i][x] + cost + self.dist[y][j])

    def shortestPath(self, node1: int, node2: int) -> int: 
        res = self.dist[node1][node2]
        return res if res != inf else -1
```

```javascript
var Graph = function(n, edges) {
    this.dist = new Array(n).fill(0).map(() => new Array(n).fill(Infinity));
    for (let i = 0; i < n; i++) {
        this.dist[i][i] = 0;
    }
    for (const [x, y, cost] of edges) {
        this.dist[x][y] = cost;
    }
    for (let k = 0; k < n; k++) {
        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                this.dist[i][j] = Math.min(this.dist[i][j], this.dist[i][k] + this.dist[k][j]);
            }
        }
    }
};

Graph.prototype.addEdge = function(edge) {
    const [x, y, cost] = edge
    if (cost >= this.dist[x][y]) {
        return;
    }
    const n = this.dist.length;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            this.dist[i][j] = Math.min(this.dist[i][j], this.dist[i][x] + cost + this.dist[y][j]);
        }
    }
};

Graph.prototype.shortestPath = function(node1, node2) {
    let res = this.dist[node1][node2];
    return res == Infinity ? -1 : res;
};
```

```go
type Graph struct {
    dist [][]int
}

const INF = math.MaxInt

func Constructor(n int, edges [][]int) Graph {
    d := make([][]int, n)
    for i := 0; i < n; i++ {
        d[i] = make([]int, n)
        for j := 0; j < n; j++ {
            d[i][j] = INF
        }
        d[i][i] = 0
    }
    for _, e := range edges {
        x, y, cost := e[0], e[1], e[2]
        d[x][y] = cost
    }
    for k := 0; k < n; k++ {
        for i := 0; i < n; i++ {
            for j := 0; j < n; j++ {
                if d[i][k] != INF && d[k][j] != INF {
                    d[i][j] = min(d[i][j], d[i][k] + d[k][j])
                }
            }
        }
    }
    return Graph{d}
}

func (this *Graph) AddEdge(edge []int)  {
    x, y, cost := edge[0], edge[1], edge[2]
    if cost >= this.dist[x][y] {
        return
    }
    for i := 0; i < len(this.dist); i++ {
        for j := 0; j < len(this.dist); j++ {
            if this.dist[i][x] != INF && this.dist[y][j] != INF {
                (*this).dist[i][j] = min(this.dist[i][j], this.dist[i][x] + this.dist[y][j])
            }
        }
    }
}

func (this *Graph) ShortestPath(node1 int, node2 int) int {
    res := this.dist[node1][node2]
	if res == INF {
		return -1
	}
	return res
}
```

```typescript
class Graph {
    private dist: number[][];
    constructor(n: number, edges: number[][]) {
        this.dist = new Array(n).fill(0).map(() => new Array(n).fill(Infinity));
        for (let i = 0; i < n; i++) {
            this.dist[i][i] = 0;
        }
        for (const [x, y, cost] of edges) {
            this.dist[x][y] = cost;
        }
        for (let k = 0; k < n; k++) {
            for (let i = 0; i < n; i++) {
                for (let j = 0; j < n; j++) {
                    this.dist[i][j] = Math.min(this.dist[i][j], this.dist[i][k] + this.dist[k][j]);
                }
            }
        }
    }

    addEdge(edge: number[]): void {
        const [x, y, cost] = edge
        if (cost >= this.dist[x][y]) {
            return;
        }
        const n = this.dist.length;
        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                this.dist[i][j] = Math.min(this.dist[i][j], this.dist[i][x] + cost + this.dist[y][j]);
            }
        }
    }

    shortestPath(node1: number, node2: number): number {
        let res = this.dist[node1][node2];
        return res == Infinity ? -1 : res;
    }
}
```

```rust
use std::cmp::min;

struct Graph {
    dist: Vec<Vec<i32>>,
}

impl Graph {
    fn new(n: i32, edges: Vec<Vec<i32>>) -> Self {
        let n = n as usize;
        let mut dist = vec![vec![i32::MAX; n]; n];
        for i in 0..n {
            dist[i][i] = 0;
        }
        for edge in edges {
            dist[edge[0] as usize][edge[1] as usize] = edge[2];
        }
        for k in 0..n {
            for i in 0..n {
                for j in 0..n {
                    if dist[i][k] != i32::MAX && dist[k][j] != i32::MAX {
                        dist[i][j] = min(dist[i][j], dist[i][k] + dist[k][j]);
                    }
                }
            }
        }
        return Graph{dist};
    }
    
    fn add_edge(&mut self, edge: Vec<i32>) {
        let x = edge[0] as usize;
        let y = edge[1] as usize;
        let cost = edge[2];
        if cost >= self.dist[x][y] {
            return;
        }
        let n = self.dist.len();
        for i in 0..n {
            for j in 0..n {
                if self.dist[i][x] != i32::MAX && self.dist[y][j] != i32::MAX {
                    self.dist[i][j] = min(
                        self.dist[i][j],
                        self.dist[i][x] + cost + self.dist[y][j],
                    );
                }
            }
        }
    }
    
    fn shortest_path(&self, node1: i32, node2: i32) -> i32 {
        let res = self.dist[node1 as usize][node2 as usize];
        if res == i32::MAX {
            -1
        } else {
            res
        }
    }
}
```

##### 复杂度分析

- 时间复杂度：题目分别要求实现三个函数：
    - $\text{Graph}$ 类初始化时，时间复杂度为 $O(n^3 + m)$，其中 $m$ 表示给定的 $\text{edges}$ 数组的长度，$n$ 表示给定的节点数目 $n$。初始边时需要的时间为 $O(m)$，使用「[Floyd 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fshortest-path%2F%23floyd-%E7%AE%97%E6%B3%95)」求任意两条边的最短路径需要的时间复杂度为 $O(n^3)$，总的时间为 $O(n^3 + m)$。
    - 调用 $\text{addEdge}$ 时，$\text{Floyd}$ 本质为动态规划，增加一条新的边时需要动态更新，此时需要的时间复杂度为 $O(n^2)$ 。
    - 调用 $\text{shortestPath}$ 时，需要的时间为 $O(1)$。
- 空间复杂度：$O(n^2)$，其中 $n$ 表示给定的数字 $n$，需要存储所有节点之间的最短距离，需要的空间为 $O(n^2)$。
