### [网格图中最少访问的格子数](https://leetcode.cn/problems/minimum-number-of-visited-cells-in-a-grid/solutions/2693762/wang-ge-tu-zhong-zui-shao-fang-wen-de-ge-944f/)

#### 方法一：维护每一行及每一列的优先队列

##### 思路与算法

根据题目描述，我们只能向下或者向右走，因此可以直接用二重循环来计算到达每一个位置的最少步数：当遍历到位置 $(i, j)$ 时，所有其左侧和上方位置的最少步数都已经计算完成。

当我们在位置 $(i, j)$ 时，如何计算到达该位置的最少步数呢？我们可以考虑上一步是向下还是向右走的。如果是「向下走」的，那么上一个位置应该是 $(i', j)$，其中 $i' < i$。除此之外，$i'$ 还需要满足下面两个要求：

- $(i', j)$ 要能走到 $(i, j)$；
- 到达 $(i', j)$ 的步数要最少。

对于第二个要求，我们可以想到使用优先队列（小根堆）来维护所有的 $i'$，堆顶对应着步数最少的位置。同时对于第一个要求，我们可以在获取堆顶的 $i_\textit{opt}'$ 时进行判断，如果 $(i_\textit{opt}', j)$ 不满足一步到达 $(i, j)$ 的要求，就可以将它从优先队列中直接移除，因为之后遍历到的同一列的位置，$i$ 的值只会更大，也就更不可能一步走到。如果优先队列中的所有元素均被移除，说明无法走到 $(i, j)$，否则就可以得到最少的步数，并将 $i$ 放入优先队列。

这样一来，我们需要对每一列都维护一个优先队列。第 $j$ 个优先队列存储的是所有位于第 $j$ 列的位置，其中的元素是一个二元组，第一个值是到达 $(i', j)$ 的最少步数，作为比较的关键字；第二个值是 $i'$，用来判断是否可以一步到达。

同理，我们对于每一行也维护一个优先队列，这样就可以处理「向右走」的情况了。

##### 代码

```c++
class Solution {
public:
    int minimumVisitedCells(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> dist(m, vector<int>(n, -1));
        dist[0][0] = 1;
        vector<priority_queue<pair<int, int>, vector<pair<int, int>>, greater<>>> row(m), col(n);

        auto update = [](int& x, int y) {
            if (x == -1 || y < x) {
                x = y;
            }
        };
        
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                while (!row[i].empty() && row[i].top().second + grid[i][row[i].top().second] < j) {
                    row[i].pop();
                }
                if (!row[i].empty()) {
                    update(dist[i][j], dist[i][row[i].top().second] + 1);
                }

                while (!col[j].empty() && col[j].top().second + grid[col[j].top().second][j] < i) {
                    col[j].pop();
                }
                if (!col[j].empty()) {
                    update(dist[i][j], dist[col[j].top().second][j] + 1);
                }
                if (dist[i][j] != -1) {
                    row[i].emplace(dist[i][j], j);
                    col[j].emplace(dist[i][j], i);
                }
            }
        }
        return dist[m - 1][n - 1];
    }
};
```

```java
class Solution {
    public int minimumVisitedCells(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[][] dist = new int[m][n];
        for (int i = 0; i < m; ++i) {
            Arrays.fill(dist[i], -1);
        }
        dist[0][0] = 1;
        PriorityQueue<int[]>[] row = new PriorityQueue[m];
        PriorityQueue<int[]>[] col = new PriorityQueue[n];
        for (int i = 0; i < m; ++i) {
            row[i] = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);
        }
        for (int i = 0; i < n; ++i) {
            col[i] = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);
        }

        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                while (!row[i].isEmpty() && row[i].peek()[1] + grid[i][row[i].peek()[1]] < j) {
                    row[i].poll();
                }
                if (!row[i].isEmpty()) {
                    dist[i][j] = update(dist[i][j], dist[i][row[i].peek()[1]] + 1);
                }

                while (!col[j].isEmpty() && col[j].peek()[1] + grid[col[j].peek()[1]][j] < i) {
                    col[j].poll();
                }
                if (!col[j].isEmpty()) {
                    dist[i][j] = update(dist[i][j], dist[col[j].peek()[1]][j] + 1);
                }

                if (dist[i][j] != -1) {
                    row[i].offer(new int[]{dist[i][j], j});
                    col[j].offer(new int[]{dist[i][j], i});
                }
            }
        }

        return dist[m - 1][n - 1];
    }

    public int update(int x, int y) {
        return x == -1 || y < x ? y : x;
    }
}
```

```csharp
public class Solution {
    public int MinimumVisitedCells(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] dist = new int[m][];
        for (int i = 0; i < m; ++i) {
            dist[i] = new int[n];
            Array.Fill(dist[i], -1);
        }
        dist[0][0] = 1;
        PriorityQueue<int, int>[] row = new PriorityQueue<int, int>[m];
        PriorityQueue<int, int>[] col = new PriorityQueue<int, int>[n];
        for (int i = 0; i < m; ++i) {
            row[i] = new PriorityQueue<int, int>();
        }
        for (int i = 0; i < n; ++i) {
            col[i] = new PriorityQueue<int, int>();
        }

        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                while (row[i].Count > 0 && row[i].Peek() + grid[i][row[i].Peek()] < j) {
                    row[i].Dequeue();
                }
                if (row[i].Count > 0) {
                    dist[i][j] = Update(dist[i][j], dist[i][row[i].Peek()] + 1);
                }

                while (col[j].Count > 0 && col[j].Peek() + grid[col[j].Peek()][j] < i) {
                    col[j].Dequeue();
                }
                if (col[j].Count > 0) {
                    dist[i][j] = Update(dist[i][j], dist[col[j].Peek()][j] + 1);
                }

                if (dist[i][j] != -1) {
                    row[i].Enqueue(j, dist[i][j]);
                    col[j].Enqueue(i, dist[i][j]);
                }
            }
        }

        return dist[m - 1][n - 1];
    }

    public int Update(int x, int y) {
        return x == -1 || y < x ? y : x;
    }
}
```

```python
class Solution:
    def minimumVisitedCells(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        dist = [[-1] * n for _ in range(m)]
        dist[0][0] = 1
        row, col = [[] for _ in range(m)], [[] for _ in range(n)]

        def update(x: int, y: int) -> int:
            return y if x == -1 or y < x else x
        
        for i in range(m):
            for j in range(n):
                while row[i] and row[i][0][1] + grid[i][row[i][0][1]] < j:
                    heapq.heappop(row[i])
                if row[i]:
                    dist[i][j] = update(dist[i][j], dist[i][row[i][0][1]] + 1)

                while col[j] and col[j][0][1] + grid[col[j][0][1]][j] < i:
                    heapq.heappop(col[j])
                if col[j]:
                    dist[i][j] = update(dist[i][j], dist[col[j][0][1]][j] + 1)

                if dist[i][j] != -1:
                    heapq.heappush(row[i], (dist[i][j], j))
                    heapq.heappush(col[j], (dist[i][j], i))

        return dist[m - 1][n - 1]
```

```c
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

Node *createNode(int x, int y) {
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

void Heapfiy(PriorityQueue *obj) {
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

int update(int x, int y) {
    if (x == -1 || y < x) {
        return y;
    } else {
        return x;
    }
}

int minimumVisitedCells(int** grid, int gridSize, int* gridColSize){
    int m = gridSize, n = gridColSize[0];
    int dist[m][n];
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            dist[i][j] = -1;
        }
    }
    dist[0][0] = 1;
    PriorityQueue *row[m], *col[n];
    for (int i = 0; i < m; i++) {
        row[i] = createPriorityQueue(n, greater);
    }
    for (int i = 0; i < n; i++) {
        col[i] = createPriorityQueue(m, greater);
    }
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
            while (!isEmpty(row[i]) && Top(row[i])->second + grid[i][Top(row[i])->second] < j) {
                Pop(row[i]);
            }
            if (!isEmpty(row[i])) {
                dist[i][j] = update(dist[i][j], dist[i][Top(row[i])->second] + 1);
            }
            while (!isEmpty(col[j]) && Top(col[j])->second + grid[Top(col[j])->second][j] < i) {
                Pop(col[j]);
            }
            if (!isEmpty(col[j])) {
                dist[i][j] = update(dist[i][j], dist[Top(col[j])->second][j] + 1);
            }
            if (dist[i][j] != -1) {
                Node node;
                node.first = dist[i][j];
                node.second = j;
                Push(row[i], &node);
                node.second = i;
                Push(col[j], &node);
            }
        }
    }
    return dist[m - 1][n - 1];
}
```

```go
func minimumVisitedCells(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    dist := make([][]int, m)
    for i := range dist {
        dist[i] = make([]int, n)
        for j := range dist[i] {
            dist[i][j] = -1
        }
    }
    dist[0][0] = 1
    row := make([]PriorityQueue, m)
    col := make([]PriorityQueue, n)

    update := func(x *int, y int) {
        if *x == -1 || y < *x {
            *x = y
        }
    }

    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            for len(row[i]) > 0 && row[i][0].second + grid[i][row[i][0].second] < j {
                heap.Pop(&row[i])
            }
            if len(row[i]) > 0 {
                update(&dist[i][j], dist[i][row[i][0].second] + 1)
            }

            for len(col[j]) > 0 && col[j][0].second + grid[col[j][0].second][j] < i {
                heap.Pop(&col[j])
            }
            if len(col[j]) > 0 {
                update(&dist[i][j], dist[col[j][0].second][j] + 1)
            }
            if dist[i][j] != -1 {
                heap.Push(&row[i], Pair{dist[i][j], j})
                heap.Push(&col[j], Pair{dist[i][j], i})
            }
        }
    }
    return dist[m - 1][n - 1]
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

```javascript
var minimumVisitedCells = function(grid) {
    const m = grid.length, n = grid[0].length;
    const dist = new Array(m).fill(0).map(() => new Array(n).fill(-1));
    dist[0][0] = 1;
    const row = new Array(m).fill(0).map(() => new MinPriorityQueue());
    const col = new Array(n).fill(0).map(() => new MinPriorityQueue());

    const update = (x, y) => {
        if (x === -1 || y < x) {
            return y;
        }
        return x;
    };

    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            while (!row[i].isEmpty() && row[i].front().element[1] + grid[i][row[i].front().element[1]] < j) {
                row[i].dequeue();
            }
            if (!row[i].isEmpty()) {
                dist[i][j] = update(dist[i][j], dist[i][row[i].front().element[1]] + 1);
            }

            while (!col[j].isEmpty() && col[j].front().element[1] + grid[col[j].front().element[1]][j] < i) {
                col[j].dequeue();
            }
            if (!col[j].isEmpty()) {
                dist[i][j] = update(dist[i][j], dist[col[j].front().element[1]][j] + 1);
            }
            if (dist[i][j] !== -1) {
                row[i].enqueue([dist[i][j], j], dist[i][j]);
                col[j].enqueue([dist[i][j], i], dist[i][j]);
            }
        }
    }
    return dist[m - 1][n - 1];
};
```

```typescript
function minimumVisitedCells(grid: number[][]): number {
    const m = grid.length, n = grid[0].length;
    const dist = new Array(m).fill(0).map(() => new Array(n).fill(-1));
    dist[0][0] = 1;
    const row = new Array(m).fill(0).map(() => new MinPriorityQueue());
    const col = new Array(n).fill(0).map(() => new MinPriorityQueue());

    const update = (x, y) => {
        if (x === -1 || y < x) {
            return y;
        }
        return x;
    };

    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            while (!row[i].isEmpty() && row[i].front().element[1] + grid[i][row[i].front().element[1]] < j) {
                row[i].dequeue();
            }
            if (!row[i].isEmpty()) {
                dist[i][j] = update(dist[i][j], dist[i][row[i].front().element[1]] + 1);
            }

            while (!col[j].isEmpty() && col[j].front().element[1] + grid[col[j].front().element[1]][j] < i) {
                col[j].dequeue();
            }
            if (!col[j].isEmpty()) {
                dist[i][j] = update(dist[i][j], dist[col[j].front().element[1]][j] + 1);
            }
            
            if (dist[i][j] !== -1) {
                row[i].enqueue([dist[i][j], j], dist[i][j]);
                col[j].enqueue([dist[i][j], i], dist[i][j]);
            }
        }
    }
    return dist[m - 1][n - 1];
};
```

```rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

impl Solution {
    pub fn minimum_visited_cells(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        let mut dist = vec![vec![-1; n]; m];
        dist[0][0] = 1;
        let mut row: Vec<BinaryHeap<(Reverse<i32>, usize)>> = vec![BinaryHeap::new(); m];
        let mut col: Vec<BinaryHeap<(Reverse<i32>, usize)>> = vec![BinaryHeap::new(); n];

        let update = |x: i32, y: i32| {
            if x == -1 || y < x {
                return y;
            } else {
                return x;
            }
        };

        for i in 0..m {
            for j in 0..n {
                while let Some((_, x)) = row[i].peek() {
                    if *x as i32 + grid[i][*x] < j as i32 {
                        row[i].pop();
                    } else {
                        break;
                    }
                }
                if let Some((_, x)) = row[i].peek() {
                    dist[i][j] = update(dist[i][j], dist[i][*x] + 1);
                }

                while let Some((_, x)) = col[j].peek() {
                    if *x as i32 + grid[*x][j] < i as i32 {
                        col[j].pop();
                    } else {
                        break;
                    }
                }
                if let Some((_, x)) = col[j].peek() {
                    dist[i][j] = update(dist[i][j], dist[*x][j] + 1);
                }
                if dist[i][j] != -1 {
                    row[i].push((Reverse(dist[i][j]), j));
                    col[j].push((Reverse(dist[i][j]), i));
                }
            }
        }
        dist[m - 1][n - 1]
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(mn \cdot (\log m + \log n))$。每一个位置会被加入行的优先队列和列的优先队列各一次，时间复杂度为 $O(\log m + \log n)$，所以总时间复杂度为 $O(mn \cdot (\log m + \log n))$。
- 空间复杂度：$Omn$，即为 $m+n$ 个优先队列需要使用的空间。
