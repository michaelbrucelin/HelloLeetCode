### [访问消失节点的最少时间](https://leetcode.cn/problems/minimum-time-to-visit-disappearing-nodes/solutions/2844219/fang-wen-xiao-shi-jie-dian-de-zui-shao-s-w9sv/)

#### 方法一：迪杰斯特拉算法

**思路**

此题与[迪杰斯特拉算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fshortest-path%2F%23dijkstra-%E7%AE%97%E6%B3%95)十分相似，唯一的区别是在将当前节点的邻接点 $v$ 放入堆时，还需要判断新的路径长度是否小于等于 $disappear[v]$，如果不满足，则不入堆。其他步骤与迪杰斯特拉算法一致，先根据 $edges$ 构建邻接表，然后利用堆来每次取出最近的节点 $v$，更新 $answer$，并将邻接点放入堆中，直到堆为空。

**代码**

```Python
class Solution:
    def minimumTime(self, n: int, edges: List[List[int]], disappear: List[int]) -> List[int]:
        adj = [[] for _ in range(n)]
        for u, v, length in edges:
            adj[u].append([v, length])
            adj[v].append([u, length])
        pq = [[0, 0]]
        answer = [-1] * n
        answer[0] = 0
        while pq:
            t, u = heappop(pq)
            if t != answer[u]:
                continue
            for v, length in adj[u]:
                if t + length < disappear[v] and (answer[v] == -1 or t + length < answer[v]):
                    heappush(pq, [t + length, v])
                    answer[v] = t + length
        return answer
```

```Java
class Solution {
    public int[] minimumTime(int n, int[][] edges, int[] disappear) {
        List<int[]>[] adj = new List[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new ArrayList<int[]>();
        }
        for (int[] edge : edges) {
            int u = edge[0], v = edge[1], length = edge[2];
            adj[u].add(new int[]{v, length});
            adj[v].add(new int[]{u, length});
        }
        PriorityQueue<int[]> pq = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);
        pq.offer(new int[]{0, 0});
        int[] answer = new int[n];
        Arrays.fill(answer, -1);
        answer[0] = 0;
        while (!pq.isEmpty()) {
            int[] arr = pq.poll();
            int t = arr[0], u = arr[1];
            if (t != answer[u]) {
                continue;
            }
            for (int[] next : adj[u]) {
                int v = next[0], length = next[1];
                if (t + length < disappear[v] && (answer[v] == -1 || t + length < answer[v])) {
                    pq.offer(new int[]{t + length, v});
                    answer[v] = t + length;
                }
            }
        }
        return answer;
    }
}
```

```CSharp
public class Solution {
    public int[] MinimumTime(int n, int[][] edges, int[] disappear) {
        IList<int[]>[] adj = new IList<int[]>[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new List<int[]>();
        }
        foreach (int[] edge in edges) {
            int u = edge[0], v = edge[1], length = edge[2];
            adj[u].Add(new int[]{v, length});
            adj[v].Add(new int[]{u, length});
        }
        PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
        pq.Enqueue(new int[]{0, 0}, 0);
        int[] answer = new int[n];
        Array.Fill(answer, -1);
        answer[0] = 0;
        while (pq.Count > 0) {
            int[] arr = pq.Dequeue();
            int t = arr[0], u = arr[1];
            if (t != answer[u]) {
                continue;
            }
            foreach (int[] next in adj[u]) {
                int v = next[0], length = next[1];
                if (t + length < disappear[v] && (answer[v] == -1 || t + length < answer[v])) {
                    pq.Enqueue(new int[]{t + length, v}, t + length);
                    answer[v] = t + length;
                }
            }
        }
        return answer;
    }
}
```

```C++
class Solution {
public:
    vector<int> minimumTime(int n, vector<vector<int>>& edges, vector<int>& disappear) {
        vector<vector<pair<int, int>>> adj(n);
        for (const auto& edge : edges) {
            int u = edge[0], v = edge[1], length = edge[2];
            adj[u].emplace_back(v, length);
            adj[v].emplace_back(u, length);
        }
        priority_queue<pair<int, int>, vector<pair<int, int>>, greater<pair<int, int>>> pq;
        pq.emplace(0, 0);
        vector<int> answer(n, -1);
        answer[0] = 0;
        while (!pq.empty()) {
            auto [t, u] = pq.top();
            pq.pop();
            if (t != answer[u]) {
                continue;
            }
            for (const auto& [v, length] : adj[u]) {
                if (t + length < disappear[v] && (answer[v] == -1 || t + length < answer[v])) {
                    pq.emplace(t + length, v);
                    answer[v] = t + length;
                }
            }
        }
        return answer;
    }
};
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

static bool less(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data[0] > e2->data[0];
}

static bool greater(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data[0] < e2->data[0];
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
    // we need to alloc more space, just twice space size
    if (obj->queueSize == obj->capacity) {
        obj->capacity *= 2;
        Element *mem = (Element *)malloc(sizeof(Element) * obj->capacity);
        memcpy(mem, obj->arr, sizeof(Element) * obj->queueSize);
        free(obj->arr);
        obj->arr = mem;
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
    int node;
    int length;
    struct Edge *next;
} Edge;

Edge *createEdge(int node, int length) {
    Edge *obj = (Edge *)malloc(sizeof(Edge));
    obj->node = node;
    obj->length = length;
    return obj;
}

void freeList(Edge *list) {
    while (list) {
        Edge *p = list;
        list = list->next;
        free(p);
    }
}

int* minimumTime(int n, int** edges, int edgesSize, int* edgesColSize, int* disappear, int disappearSize, int* returnSize) {
    Edge *adj[n];
    for (int i = 0; i < n; i++) {
        adj[i] = NULL;
    }
    for (int i = 0; i < edgesSize; i++) {
        int u = edges[i][0], v = edges[i][1], length = edges[i][2];
        Edge *ev = createEdge(v, length);
        ev->next = adj[u];
        adj[u] = ev;
        Edge *eu = createEdge(u, length);
        eu->next = adj[v];
        adj[v] = eu;
    }

    PriorityQueue *pq = createPriorityQueue(less);
    Element e;
    e.data[0] = 0;
    e.data[1] = 0;
    enQueue(pq, &e);
    int *answer = (int *)malloc(sizeof(int) * n);
    for (int i = 0; i < n; i++) {
        answer[i] = -1;
    }
    answer[0] = 0;
    while (!isEmpty(pq)) {
        Element *p = front(pq);
        int t = p->data[0];
        int u = p->data[1];
        deQueue(pq);
        if (t != answer[u]) {
            continue;
        }
        for (struct Edge *p = adj[u]; p; p = p->next) {
            int v = p->node, length = p->length;
            if (t + length < disappear[v] && (answer[v] == -1 || t + length < answer[v])) {
                e.data[0] = t + length;
                e.data[1] = v;
                enQueue(pq, &e);
                answer[v] = t + length;
            }
        }
    }
    *returnSize = n;
    freeQueue(pq);
    return answer;
}
```

```Go
func minimumTime(n int, edges [][]int, disappear []int) []int {
    adj := make([][]struct{ v, length int }, n)
    for _, edge := range edges {
        u, v, length := edge[0], edge[1], edge[2]
        adj[u] = append(adj[u], struct{ v, length int }{v, length})
        adj[v] = append(adj[v], struct{ v, length int }{u, length})
    }
    pq := &PriorityQueue{}
    heap.Init(pq)
    heap.Push(pq, Item{0, 0})
    answer := make([]int, n)
    for i := range answer {
        answer[i] = -1
    }
    answer[0] = 0
    for pq.Len() > 0 {
        item := heap.Pop(pq).(Item)
        t, u := item.priority, item.value
        if t != answer[u] {
            continue
        }
        for _, edge := range adj[u] {
            v, length := edge.v, edge.length
            if t + length < disappear[v] && (answer[v] == -1 || t + length < answer[v]) {
                heap.Push(pq, Item{t + length, v})
                answer[v] = t + length
            }
        }
    }
    return answer
}

type Item struct {
    priority, value int
}

type PriorityQueue []Item

func (pq PriorityQueue) Len() int { return len(pq) }

func (pq PriorityQueue) Less(i, j int) bool {
    return pq[i].priority < pq[j].priority
}

func (pq PriorityQueue) Swap(i, j int) {
    pq[i], pq[j] = pq[j], pq[i]
}

func (pq *PriorityQueue) Push(x interface{}) {
    *pq = append(*pq, x.(Item))
}

func (pq *PriorityQueue) Pop() interface{} {
    old := *pq
    n := len(old)
    item := old[n-1]
    *pq = old[0 : n-1]
    return item
}
```

```JavaScript
var minimumTime = function(n, edges, disappear) {
    const adj = Array.from({ length: n }, () => []);
    for (const [u, v, length] of edges) {
        adj[u].push([v, length]);
        adj[v].push([u, length]);
    }
    const pq = new MinPriorityQueue();
    pq.enqueue([0, 0], 0);
    const answer = Array(n).fill(-1);
    answer[0] = 0;
    while (!pq.isEmpty()) {
        const [t, u] = pq.dequeue().element;
        if (t !== answer[u]) {
            continue;
        }
        for (const [v, length] of adj[u]) {
            if (t + length < disappear[v] && (answer[v] === -1 || t + length < answer[v])) {
                pq.enqueue([t + length, v], t + length);
                answer[v] = t + length;
            }
        }
    }
    return answer;
};
```

```TypeScript
function minimumTime(n: number, edges: number[][], disappear: number[]): number[] {
    const adj: [number, number][][] = Array.from({ length: n }, () => []);
    for (const [u, v, length] of edges) {
        adj[u].push([v, length]);
        adj[v].push([u, length]);
    }
    
    const pq = new MinPriorityQueue();
    pq.enqueue([0, 0], 0);
    const answer: number[] = Array(n).fill(-1);
    answer[0] = 0;
    while (!pq.isEmpty()) {
        const [t, u] = pq.dequeue().element;
        if (t !== answer[u]) {
            continue;
        }
        for (const [v, length] of adj[u]) {
            if (t + length < disappear[v] && (answer[v] === -1 || t + length < answer[v])) {
                pq.enqueue([t + length, v], t + length);
                answer[v] = t + length;
            }
        }
    }
    
    return answer;
};
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

impl Solution {
    pub fn minimum_time(n: i32, edges: Vec<Vec<i32>>, disappear: Vec<i32>) -> Vec<i32> {
        let mut adj = vec![Vec::new(); n as usize];
        for edge in edges.iter() {
            let u = edge[0] as usize;
            let v = edge[1] as usize;
            let length = edge[2];
            adj[u].push((v, length));
            adj[v].push((u, length));
        }
        
        let mut pq = BinaryHeap::new();
        pq.push(Reverse((0, 0)));
        let mut answer = vec![-1; n as usize];
        answer[0] = 0;
        
        while let Some(Reverse((t, u))) = pq.pop() {
            if t != answer[u] {
                continue;
            }
            for &(v, length) in adj[u].iter() {
                if t + length < disappear[v] && (answer[v] == -1 || t + length < answer[v]) {
                    pq.push(Reverse((t + length, v)));
                    answer[v] = t + length;
                }
            }
        }
        
        answer
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m \times logm)$，其中 $m$ 是数组 $edges$ 的长度。
- 空间复杂度：$O(n+m)$。
