### [穿越网格图的安全路径](https://leetcode.cn/problems/find-a-safe-walk-through-a-grid/solutions/3988214/chuan-yue-wang-ge-tu-de-an-quan-lu-jing-ygb08/)

#### 方法一：Dijkstra

**思路与算法**

题目要求判断从起点 $(0,0)$ 出发是否可以**正数**健康值到达终点 $(m-1,n-1)$。由于经过值为 $1$ 的单元格会导致健康值减少 $1$，这道题本质上是求从起点到终点的最短路径，其中路径的权重是经过格子的值之和。由于格子值非负，我们可以使用 $Dijkstra$ 算法求最小消耗路径，判定最小的路径值是否小于等于初始健康值 $health$，如果满足则可以穿越，否则则无法穿越。

**代码**

```C++
class Solution {
public:
    bool findSafeWalk(vector<vector<int>>& grid, int health) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> dis(m, vector<int>(n, -1));
        int dirs[4][2] = {{0, 1}, {1, 0}, {-1, 0}, {0, -1}};

        priority_queue<tuple<int, int, int>, vector<tuple<int, int, int>>, greater<>> pq;
        pq.emplace(grid[0][0], 0, 0);
        while (!pq.empty()) {
            auto [val, cx, cy] = pq.top();
            pq.pop();
            if (dis[cx][cy] >= 0) {
                continue;
            }
            dis[cx][cy] = val;
            for (int k = 0; k < 4; k++) {
                int nx = cx + dirs[k][0];
                int ny = cy + dirs[k][1];
                if (nx < 0 || ny < 0 || nx >= m || ny >= n || dis[nx][ny] >= 0) {
                    continue;
                }
                pq.emplace(val + grid[nx][ny], nx, ny);
            }
        }

        return dis[m - 1][n - 1] < health;
    }
};
```

```Java
class Solution {
    public boolean findSafeWalk(List<List<Integer>> grid, int health) {
        int m = grid.size(), n = grid.get(0).size();
        int[][] dis = new int[m][n];
        for (int i = 0; i < m; i++) {
            Arrays.fill(dis[i], -1);
        }
        int[][] dirs = {{0, 1}, {1, 0}, {-1, 0}, {0, -1}};

        PriorityQueue<int[]> pq = new PriorityQueue<>(Comparator.comparingInt(a -> a[0]));
        pq.offer(new int[]{grid.get(0).get(0), 0, 0});

        while (!pq.isEmpty()) {
            int[] cur = pq.poll();
            int val = cur[0], cx = cur[1], cy = cur[2];
            if (dis[cx][cy] >= 0) {
                continue;
            }
            dis[cx][cy] = val;
            for (int[] d : dirs) {
                int nx = cx + d[0], ny = cy + d[1];
                if (nx < 0 || ny < 0 || nx >= m || ny >= n) {
                    continue;
                }
                if (dis[nx][ny] >= 0) {
                    continue;
                }
                pq.offer(new int[]{val + grid.get(nx).get(ny), nx, ny});
            }
        }

        return dis[m - 1][n - 1] < health;
    }
}
```

```CSharp
public class Solution {
    public bool FindSafeWalk(IList<IList<int>> grid, int health) {
        int m = grid.Count, n = grid[0].Count;
        int[][] dis = new int[m][];
        for (int i = 0; i < m; i++) {
            dis[i] = new int[n];
            for (int j = 0; j < n; j++) dis[i][j] = -1;
        }
        int[][] dirs = new int[][] { new int[] {0, 1}, new int[] {1, 0}, new int[] {-1, 0}, new int[] {0, -1} };

        var pq = new PriorityQueue<(int val, int x, int y), int>();
        pq.Enqueue((grid[0][0], 0, 0), grid[0][0]);

        while (pq.Count > 0) {
            var (val, cx, cy) = pq.Dequeue();
            if (dis[cx][cy] >= 0) {
                continue;
            }
            dis[cx][cy] = val;
            foreach (var d in dirs) {
                int nx = cx + d[0], ny = cy + d[1];
                if (nx < 0 || ny < 0 || nx >= m || ny >= n || dis[nx][ny] >= 0) {
                    continue;
                }
                int nval = val + grid[nx][ny];
                pq.Enqueue((nval, nx, ny), nval);
            }
        }

        return dis[m - 1][n - 1] < health;
    }
}
```

```Go
func findSafeWalk(grid [][]int, health int) bool {
    m, n := len(grid), len(grid[0])
    dis := make([][]int, m)
    for i := range dis {
        dis[i] = make([]int, n)
        for j := range dis[i] {
            dis[i][j] = -1
        }
    }
    dirs := [4][2]int{{0, 1}, {1, 0}, {-1, 0}, {0, -1}}

    pq := &MinHeap{}
    heap.Push(pq, Item{val: grid[0][0], x: 0, y: 0})
    for pq.Len() > 0 {
        cur := heap.Pop(pq).(Item)
        if dis[cur.x][cur.y] >= 0 {
            continue
        }
        dis[cur.x][cur.y] = cur.val
        for _, d := range dirs {
            nx, ny := cur.x+d[0], cur.y+d[1]
            if nx < 0 || ny < 0 || nx >= m || ny >= n || dis[nx][ny] >= 0 {
                continue
            }
            heap.Push(pq, Item{val: cur.val + grid[nx][ny], x: nx, y: ny})
        }
    }
    return dis[m-1][n-1] < health
}

type Item struct {
    val, x, y int
}
type MinHeap []Item

func (h MinHeap) Len() int            { return len(h) }
func (h MinHeap) Less(i, j int) bool  { return h[i].val < h[j].val }
func (h MinHeap) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *MinHeap) Push(x interface{}) { *h = append(*h, x.(Item)) }

func (h *MinHeap) Pop() interface{}   {
    old := *h;
    n := len(old);
    x := old[n-1];
    *h = old[:n-1];
    return x
}
```

```Python
class Solution:
    def findSafeWalk(self, grid: List[List[int]], health: int) -> bool:
        m, n = len(grid), len(grid[0])
        dis = [[-1] * n for _ in range(m)]
        dirs = [(0, 1), (1, 0), (-1, 0), (0, -1)]

        pq = [(grid[0][0], 0, 0)]  # (cost, x, y)
        while pq:
            val, cx, cy = heapq.heappop(pq)
            if dis[cx][cy] >= 0:
                continue
            dis[cx][cy] = val
            for dx, dy in dirs:
                nx, ny = cx + dx, cy + dy
                if 0 <= nx < m and 0 <= ny < n and dis[nx][ny] == -1:
                    heapq.heappush(pq, (val + grid[nx][ny], nx, ny))
        return dis[m-1][n-1] < health
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

static void memswap(void *m1, void *m2, size_t size) {
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

void heapify(PriorityQueue *obj) {
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
    Element *e = &obj->arr[obj->queueSize - 1];
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

bool findSafeWalk(int** grid, int gridSize, int* gridColSize, int health) {
    int m = gridSize, n = gridColSize[0];
    int** dis = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; i++) {
        dis[i] = (int*)malloc(n * sizeof(int));
        memset(dis[i], -1, n * sizeof(int));
    }

    int dirs[4][2] = {{0, 1}, {1, 0}, {-1, 0}, {0, -1}};
    PriorityQueue* pq = createPriorityQueue(greater);
    Element* start = createElement(grid[0][0], 0);
    enQueue(pq, start);
    free(start);

    while (!isEmpty(pq)) {
        Element* e = front(pq);
        int val = e->data[0];
        int cx = e->data[1] / n;
        int cy = e->data[1] % n;
        deQueue(pq);
        if (dis[cx][cy] >= 0) {
            continue;
        }
        dis[cx][cy] = val;

        for (int k = 0; k < 4; k++) {
            int nx = cx + dirs[k][0];
            int ny = cy + dirs[k][1];
            if (nx < 0 || ny < 0 || nx >= m || ny >= n || dis[nx][ny] >= 0) {
                continue;
            }

            Element* next = createElement(val + grid[nx][ny], nx * n + ny);
            enQueue(pq, next);
            free(next);
        }
    }

    int result = dis[m - 1][n - 1] < health;
    for (int i = 0; i < m; i++) {
        free(dis[i]);
    }
    free(dis);
    freeQueue(pq);

    return result;
}
```

```JavaScript
var findSafeWalk = function(grid, health) {
    const m = grid.length, n = grid[0].length;
    const dis = Array.from({ length: m }, () => new Array(n).fill(-1));
    const dirs = [[0, 1], [1, 0], [-1, 0], [0, -1]];

    const pq = new MinPriorityQueue({
        compare: (a, b) => a[0] - b[0]
    });
    pq.enqueue([grid[0][0], 0, 0]);

    while (!pq.isEmpty()) {
        const [val, cx, cy] = pq.dequeue();
        if (dis[cx][cy] >= 0) {
            continue;
        }
        dis[cx][cy] = val;

        for (const [dx, dy] of dirs) {
            const nx = cx + dx;
            const ny = cy + dy;

            if (nx < 0 || ny < 0 || nx >= m || ny >= n || dis[nx][ny] >= 0) {
                continue;
            }

            pq.enqueue([val + grid[nx][ny], nx, ny]);
        }
    }

    return dis[m - 1][n - 1] < health;
};
```

```TypeScript
function findSafeWalk(grid: number[][], health: number): boolean {
    const m = grid.length, n = grid[0].length;
    const dis: number[][] = Array.from({ length: m }, () => new Array(n).fill(-1));
    const dirs: [number, number][] = [[0, 1], [1, 0], [-1, 0], [0, -1]];

    const pq = new MinPriorityQueue<[number, number, number]>({
        compare: (a: [number, number, number], b: [number, number, number]): number => a[0] - b[0]
    });
    pq.enqueue([grid[0][0], 0, 0]);

    while (!pq.isEmpty()) {
        const element = pq.dequeue();
        const [val, cx, cy] = element;
        if (dis[cx][cy] >= 0) {
            continue;
        }
        dis[cx][cy] = val;

        for (const [dx, dy] of dirs) {
            const nx = cx + dx;
            const ny = cy + dy;

            if (nx < 0 || ny < 0 || nx >= m || ny >= n || dis[nx][ny] >= 0) {
                continue;
            }

            pq.enqueue([val + grid[nx][ny], nx, ny]);
        }
    }

    return dis[m - 1][n - 1] < health;
}
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

impl Solution {
    pub fn find_safe_walk(grid: Vec<Vec<i32>>, health: i32) -> bool {
        let m = grid.len();
        let n = grid[0].len();
        let mut dis = vec![vec![-1; n]; m];
        let dirs = [(0, 1), (1, 0), (-1, 0), (0, -1)];

        let mut pq = BinaryHeap::new();
        pq.push(Reverse((grid[0][0], 0, 0)));
        while let Some(Reverse((val, cx, cy))) = pq.pop() {
            if dis[cx][cy] >= 0 {
                continue;
            }
            dis[cx][cy] = val;
            for (dx, dy) in dirs.iter() {
                let nx = cx as i32 + dx;
                let ny = cy as i32 + dy;
                if nx >= 0 && ny >= 0 && (nx as usize) < m && (ny as usize) < n {
                    let nx = nx as usize;
                    let ny = ny as usize;
                    if dis[nx][ny] == -1 {
                        pq.push(Reverse((val + grid[nx][ny], nx, ny)));
                    }
                }
            }
        }
        dis[m-1][n-1] < health
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn\log (mn))$，其中 $m$ 和 $n$ 分别是矩阵 $grid$ 的行数和列数。广度优先搜索的状态数是 $O(mn)$，每个状态最多加入优先队列和从优先队列取出各一次，每次优先队列操作的时间是 $O(\log (mn))$，因此时间复杂度是 $O(mn\log (mn))$。
- 空间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别是矩阵 $grid$ 的行数和列数。记录每个单元格的最小代价的二维数组和优先队列的空间是 $O(mn)$。

#### 方法二：0-1 BFS

**思路与算法**

由于本题中格子的值只有 $0$ 和 $1$，因此我们可以使用 $\lceil$[0-1 BFS](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fbfs%2F)$\rfloor$，每次遇到权值为 $0$ 的节点则将其加入到队首，权值为 $1$ 的节点则将其加入到队尾，这样即可保证优先访问权值为 $0$ 的节点，保证队首总是最小的，等价于 $Dijkstra$ 的优先队列效果，每次操作队列的时间复杂度是 $O(1)$。$0-1 BFS$ 保证第一次出队的距离就是最短距离，终点出队时可以立即返回。

入队列时可剪枝：

- 如果到达某个点的消耗已经大于等于 $health$，那么从它出发的任何路径都不可能满足条件，可提前终止搜索。

**代码**

```C++
class Solution {
    static constexpr int DIRS[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

public:
    bool findSafeWalk(vector<vector<int>>& grid, int health) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> dis(m, vector<int>(n, INT_MAX));

        deque<pair<int, int>> q;
        q.emplace_front(0, 0);
        dis[0][0] = grid[0][0];

        while (!q.empty()) {
            auto [cx, cy] = q.front();
            q.pop_front();
            // 第一次出队时，保证是最短距离
            if (cx == m - 1 && cy == n - 1) {
                return true;
            }

            for (auto& [dx, dy] : DIRS) {
                int nx = cx + dx, ny = cy + dy;
                if (nx < 0 || ny < 0 || nx >= m || ny >= n) {
                    continue;
                }
                int cost = dis[cx][cy] + grid[nx][ny];
                // 剪枝：新距离不满足健康要求
                if (cost >= health) {
                    continue;
                }
                if (cost < dis[nx][ny]) {
                    dis[nx][ny] = cost;
                    if (grid[nx][ny] == 0) {
                        q.emplace_front(nx, ny);
                    } else {
                        q.emplace_back(nx, ny);
                    }
                }
            }
        }

        return false;
    }
};
```

```Java
class Solution {
    private static final int[][] DIRS = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

    public boolean findSafeWalk(List<List<Integer>> grid, int health) {
        int m = grid.size(), n = grid.get(0).size();
        int[][] dis = new int[m][n];
        for (int[] row : dis) {
            Arrays.fill(row, Integer.MAX_VALUE);
        }
        Deque<int[]> q = new ArrayDeque<>();
        q.offerFirst(new int[]{0, 0});
        dis[0][0] = grid.get(0).get(0);

        while (!q.isEmpty()) {
            int[] cur = q.pollFirst();
            int cx = cur[0], cy = cur[1];
            // 第一次出队时，保证是最短距离
            if (cx == m - 1 && cy == n - 1) {
                return true;
            }

            for (int[] dir : DIRS) {
                int nx = cx + dir[0], ny = cy + dir[1];
                if (nx < 0 || ny < 0 || nx >= m || ny >= n) {
                    continue;
                }
                int cost = dis[cx][cy] + grid.get(nx).get(ny);
                // 剪枝：新距离不满足健康要求
                if (cost >= health) {
                    continue;
                }
                if (cost < dis[nx][ny]) {
                    dis[nx][ny] = cost;
                    if (grid.get(nx).get(ny) == 0) {
                        q.offerFirst(new int[]{nx, ny});
                    } else {
                        q.offerLast(new int[]{nx, ny});
                    }
                }
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    private static readonly int[][] DIRS = new int[][] {
        new int[]{0, 1}, new int[]{0, -1}, new int[]{1, 0}, new int[]{-1, 0}
    };

    public bool FindSafeWalk(IList<IList<int>> grid, int health) {
        int m = grid.Count, n = grid[0].Count;
        int[][] dis = new int[m][];
        for (int i = 0; i < m; i++) {
            dis[i] = new int[n];
            Array.Fill(dis[i], int.MaxValue);
        }

        var q = new LinkedList<int[]>();
        q.AddFirst(new int[]{0, 0});
        dis[0][0] = grid[0][0];

        while (q.Count > 0) {
            int[] cur = q.First.Value;
            q.RemoveFirst();
            int cx = cur[0], cy = cur[1];
            // 第一次出队时，保证是最短距离
            if (cx == m - 1 && cy == n - 1) {
                return true;
            }

            foreach (var dir in DIRS) {
                int nx = cx + dir[0], ny = cy + dir[1];
                if (nx < 0 || ny < 0 || nx >= m || ny >= n) {
                    continue;
                }
                int cost = dis[cx][cy] + grid[nx][ny];
                // 剪枝：新距离不满足健康要求
                if (cost >= health) {
                    continue;
                }
                if (cost < dis[nx][ny]) {
                    dis[nx][ny] = cost;
                    if (grid[nx][ny] == 0) {
                        q.AddFirst(new int[]{nx, ny});
                    } else {
                        q.AddLast(new int[]{nx, ny});
                    }
                }
            }
        }
        return false;
    }
}
```

```Go
func findSafeWalk(grid [][]int, health int) bool {
    m, n := len(grid), len(grid[0])
    dirs := [][2]int{{0, 1}, {0, -1}, {1, 0}, {-1, 0}}

    dis := make([][]int, m)
    for i := range dis {
        dis[i] = make([]int, n)
        for j := range dis[i] {
            dis[i][j] = math.MaxInt32
        }
    }

    q := list.New()
    q.PushFront([2]int{0, 0})
    dis[0][0] = grid[0][0]

    for q.Len() > 0 {
        cur := q.Remove(q.Front()).([2]int)
        cx, cy := cur[0], cur[1]
        // 第一次出队时，保证是最短距离
        if cx == m-1 && cy == n-1 {
            return true
        }

        for _, dir := range dirs {
            nx, ny := cx+dir[0], cy+dir[1]
            if nx < 0 || ny < 0 || nx >= m || ny >= n {
                continue
            }

            cost := dis[cx][cy] + grid[nx][ny]
            // 剪枝：新距离不满足健康要求
            if cost >= health {
                continue
            }

            if cost < dis[nx][ny] {
                dis[nx][ny] = cost
                if grid[nx][ny] == 0 {
                    q.PushFront([2]int{nx, ny})
                } else {
                    q.PushBack([2]int{nx, ny})
                }
            }
        }
    }
    return false
}
```

```Python
class Solution:
    def findSafeWalk(self, grid: List[List[int]], health: int) -> bool:
        m, n = len(grid), len(grid[0])
        dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]
        dis = [[float('inf')] * n for _ in range(m)]

        q = deque()
        q.appendleft((0, 0))
        dis[0][0] = grid[0][0]

        while q:
            cx, cy = q.popleft()
            # 第一次出队时，保证是最短距离
            if cx == m - 1 and cy == n - 1:
                return True

            for dx, dy in dirs:
                nx, ny = cx + dx, cy + dy
                if nx < 0 or ny < 0 or nx >= m or ny >= n:
                    continue

                cost = dis[cx][cy] + grid[nx][ny]
                # 剪枝：新距离不满足健康要求
                if cost >= health:
                    continue

                if cost < dis[nx][ny]:
                    dis[nx][ny] = cost
                    if grid[nx][ny] == 0:
                        q.appendleft((nx, ny))
                    else:
                        q.append((nx, ny))

        return False
```

```C
typedef struct {
    int x, y;
} Point;

typedef struct {
    Point* data;
    int head;      // 指向队首元素
    int tail;      // 指向队尾元素的下一个位置
    int capacity;  // 队列容量
} Deque;

Deque* dequeCreate(int capacity) {
    Deque* dq = (Deque*)malloc(sizeof(Deque));
    dq->data = (Point*)malloc(sizeof(Point) * capacity);
    dq->head = 0;
    dq->tail = 0;
    dq->capacity = capacity;
    return dq;
}

void dequePushFront(Deque* dq, int x, int y) {
    dq->head = (dq->head - 1 + dq->capacity) % dq->capacity;
    dq->data[dq->head].x = x;
    dq->data[dq->head].y = y;
}

void dequePushBack(Deque* dq, int x, int y) {
    dq->data[dq->tail].x = x;
    dq->data[dq->tail].y = y;
    dq->tail = (dq->tail + 1) % dq->capacity;
}

Point dequePopFront(Deque* dq) {
    Point p = dq->data[dq->head];
    dq->head = (dq->head + 1) % dq->capacity;
    return p;
}

bool dequeIsEmpty(Deque* dq) {
    return dq->head == dq->tail;
}

void dequeFree(Deque* dq) {
    free(dq->data);
    free(dq);
}

bool findSafeWalk(int** grid, int gridSize, int* gridColSize, int health) {
    int m = gridSize, n = gridColSize[0];
    int dirs[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};

    int** dis = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; i++) {
        dis[i] = (int*)malloc(n * sizeof(int));
        for (int j = 0; j < n; j++) {
            dis[i][j] = INT_MAX;
        }
    }

    Deque* q = dequeCreate(m * n + 1);
    dequePushFront(q, 0, 0);
    dis[0][0] = grid[0][0];

    while (!dequeIsEmpty(q)) {
        Point cur = dequePopFront(q);
        int cx = cur.x, cy = cur.y;
        // 第一次出队时，保证是最短距离
        if (cx == m - 1 && cy == n - 1) {
            for (int i = 0; i < m; i++) free(dis[i]);
            free(dis);
            dequeFree(q);
            return true;
        }

        for (int k = 0; k < 4; k++) {
            int nx = cx + dirs[k][0];
            int ny = cy + dirs[k][1];
            if (nx < 0 || ny < 0 || nx >= m || ny >= n) {
                continue;
            }
            int cost = dis[cx][cy] + grid[nx][ny];
            // 剪枝：新距离不满足健康要求
            if (cost >= health) {
                continue;
            }
            if (cost < dis[nx][ny]) {
                dis[nx][ny] = cost;
                if (grid[nx][ny] == 0) {
                    dequePushFront(q, nx, ny);
                } else {
                    dequePushBack(q, nx, ny);
                }
            }
        }
    }

    for (int i = 0; i < m; i++) {
        free(dis[i]);
    }
    free(dis);
    dequeFree(q);
    return false;
}
```

```JavaScript
var findSafeWalk = function(grid, health) {
    const m = grid.length, n = grid[0].length;
    const dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
    const dis = Array.from({ length: m }, () => new Array(n).fill(Infinity));

    const q = new Deque();
    q.pushFront([0, 0]);
    dis[0][0] = grid[0][0];

    while (!q.isEmpty()) {
        const [cx, cy] = q.popFront();
        // 第一次出队时，保证是最短距离
        if (cx === m - 1 && cy === n - 1) {
            return true;
        }

        for (const [dx, dy] of dirs) {
            const nx = cx + dx, ny = cy + dy;
            if (nx < 0 || ny < 0 || nx >= m || ny >= n) {
                continue;
            }
            const cost = dis[cx][cy] + grid[nx][ny];
            // 剪枝：新距离不满足健康要求
            if (cost >= health) {
                continue;
            }

            if (cost < dis[nx][ny]) {
                dis[nx][ny] = cost;
                if (grid[nx][ny] === 0) {
                    q.pushFront([nx, ny]);
                } else {
                    q.pushBack([nx, ny]);
                }
            }
        }
    }

    return false;
};
```

```TypeScript
function findSafeWalk(grid: number[][], health: number): boolean {
    const m = grid.length, n = grid[0].length;
    const dirs: [number, number][] = [[0, 1], [0, -1], [1, 0], [-1, 0]];
    const dis: number[][] = Array.from({ length: m }, () => new Array(n).fill(Infinity));

    const q = new Deque<[number, number]>();
    q.pushFront([0, 0]);
    dis[0][0] = grid[0][0];

    while (!q.isEmpty()) {
        const [cx, cy] = q.popFront()!;
        // 第一次出队时，保证是最短距离
        if (cx === m - 1 && cy === n - 1) {
            return true;
        }

        for (const [dx, dy] of dirs) {
            const nx = cx + dx, ny = cy + dy;
            if (nx < 0 || ny < 0 || nx >= m || ny >= n) {
                continue;
            }

            const cost = dis[cx][cy] + grid[nx][ny];
            // 剪枝：新距离不满足健康要求
            if (cost >= health) {
                continue;
            }

            if (cost < dis[nx][ny]) {
                dis[nx][ny] = cost;
                if (grid[nx][ny] === 0) {
                    q.pushFront([nx, ny]);
                } else {
                    q.pushBack([nx, ny]);
                }
            }
        }
    }

    return false;
}
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn find_safe_walk(grid: Vec<Vec<i32>>, health: i32) -> bool {
        let (m, n) = (grid.len(), grid[0].len());
        let dirs: [(i32, i32); 4] = [(0, 1), (0, -1), (1, 0), (-1, 0)];
        let mut dis = vec![vec![i32::MAX; n]; m];
        let mut q = VecDeque::new();

        q.push_front((0usize, 0usize));
        dis[0][0] = grid[0][0];

        while let Some((cx, cy)) = q.pop_front() {
            // 第一次出队时，保证是最短距离
            if cx == m - 1 && cy == n - 1 {
                return true;
            }

            for (dx, dy) in dirs.iter() {
                let nx = cx as i32 + dx;
                let ny = cy as i32 + dy;
                if nx < 0 || ny < 0 || nx >= m as i32 || ny >= n as i32 {
                    continue;
                }

                let (nx, ny) = (nx as usize, ny as usize);
                let cost = dis[cx][cy] + grid[nx][ny];
                // 剪枝：新距离不满足健康要求
                if cost >= health {
                    continue;
                }

                if cost < dis[nx][ny] {
                    dis[nx][ny] = cost;
                    if grid[nx][ny] == 0 {
                        q.push_front((nx, ny));
                    } else {
                        q.push_back((nx, ny));
                    }
                }
            }
        }

        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别是矩阵 $grid$ 的行数和列数。每个点至多入队两次，因此时间复杂度是 $O(mn)$。
- 空间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别是矩阵 $grid$ 的行数和列数。记录每个单元格的最小代价的二维数组和队列的空间是 $O(mn)$。
