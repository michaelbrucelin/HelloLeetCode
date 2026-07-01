### [找出最安全路径](https://leetcode.cn/problems/find-the-safest-path-in-a-grid/solutions/3987423/zhao-chu-zui-an-quan-lu-jing-by-leetcode-xsop/)

#### 方法一：二分查找

**思路与算法**

题目要求找出从起点 $(0,0)$ 到终点 $(n-1,n-1)$ 的路径中的**最大安全系数**。所谓**安全系数**，定义为从起点到终点路径上的任意单元格到任意有小偷的单元格的最小曼哈顿距离。由于路径必然包含起点和终点，因此如果这两个单元格中任意一个存在小偷，最小曼哈顿距离即为 $0$，此时最大安全系数也为 $0$。另外，矩阵中至少有一个小偷，无论小偷位于何处，起点到终点路径上任意单元格到小偷的曼哈顿距离都不会超过 $n$。

我们希望最大化路径的安全系数，这等价于最大化路径上所有单元格到小偷的**最小曼哈顿距离**的最小值。如果我们事先计算出每个单元格到最近小偷的曼哈顿距离（可以用一个 $n\times n$ 的二维数组记录），那么原问题就转换为：在二维矩阵中，从起点 $(0,0)$ 走到终点 $(n-1,n-1)$，找出一条路径，最大化路径上节点值的最小值。这个问题与 $\lceil$[1631\. 最小体力消耗路径](https://leetcode.cn/problems/path-with-minimum-effort/description/)$\rfloor$  十分相似。

首先，我们使用多源 $BFS$ 来求出所有单元格到小偷单元格的最小曼哈顿距离：将所有小偷的位置作为源点同时入队，进行广度优先搜索，用二维数组 $dis$ 记录结果，其中 $dis[x][y]$ 表示位置 $(x,y)$ 到最近小偷的曼哈顿距离。

接下来，我们要求在 $dis$ 矩阵中，找到从 $(0,0)$ 到 $(n-1,n-1)$ 的一条路径，使得路径上节点的最小值尽可能大。这可以转化为一个「判定性」问题：

> 是否存在一条从起点 $(0,0)$ 到终点 $(n-1,n-1)$ 的路径，使得路径上所有节点的值都不小于 limit？

我们可以从起点开始进行深度优先搜索或广度优先搜索，只允许经过值大于等于 $limit$ 的节点，搜索结束后判断是否能抵达终点。因为随着 $limit$ 减小，原本可行的路径依然可行，所以答案具有单调性。于是，我们可以用二分查找来寻找满足条件的最大 $limit$，记为 $ans$，满足：

- 当 $limit\le ans$ 时，可以从起点走到终点；
- 当 $limit>ans$ 时，则无法到达终点。

另外，路径必然包含起点和终点，因此二分查找的上界不会超过 $min(dis[0][0],dis[n-1][n-1])$。我们在区间 $[0,min(dis[0][0],dis[n-1][n-1])]$ 上进行二分查找，即可得到最终的答案。

**代码**

```C++
class Solution {
public:
    int maximumSafenessFactor(vector<vector<int>>& grid) {
        int n = grid.size();
        if (grid[0][0] || grid[n - 1][n - 1]) {
            return 0;
        }

        vector<vector<int>> dis(n, vector<int>(n, -1));
        int dirs[4][2] = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
        queue<pair<int, int>> q;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j]) {
                    q.emplace(i, j);
                    dis[i][j] = 0;
                }
            }
        }

        while (!q.empty()) {
            auto [cx, cy] = q.front();
            q.pop();
            for (int j = 0; j < 4; j++) {
                int nx = cx + dirs[j][0];
                int ny = cy + dirs[j][1];
                if (nx < 0 || ny < 0 || nx >= n || ny >= n || dis[nx][ny] != -1) {
                    continue;
                }
                dis[nx][ny] = dis[cx][cy] + 1;
                q.emplace(nx, ny);
            }
        }

        auto check = [&](int limit) -> bool {
            vector<vector<bool>> visit(n, vector<bool>(n, false));
            queue<pair<int, int>> q;
            q.emplace(0, 0);
            visit[0][0] = true;

            while (!q.empty()) {
                auto [cx, cy] = q.front();
                q.pop();
                if (cx == n - 1 && cy == n - 1) {
                    return true;
                }
                for (int i = 0; i < 4; i++) {
                    int nx = cx + dirs[i][0];
                    int ny = cy + dirs[i][1];
                    if (nx < 0 || ny < 0 || nx >= n || ny >= n ||
                        visit[nx][ny] || dis[nx][ny] < limit) {
                        continue;
                    }
                    q.emplace(nx, ny);
                    visit[nx][ny] = true;
                }
            }

            return false;
        };


        int lo = 0, hi = min(dis[0][0], dis[n - 1][n - 1]);
        int res = 0;
        while (lo <= hi) {
            int mid = (lo + hi) / 2;
            if (check(mid)) {
                res = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }

        return res;

    }
};
```

```Java
class Solution {
    public int maximumSafenessFactor(List<List<Integer>> grid) {
        int n = grid.size();
        if (grid.get(0).get(0) == 1 || grid.get(n - 1).get(n - 1) == 1) {
            return 0;
        }

        int[][] dis = new int[n][n];
        for (int[] row : dis) {
            Arrays.fill(row, -1);
        }

        int[][] dirs = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
        Queue<int[]> q = new LinkedList<>();

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid.get(i).get(j) == 1) {
                    q.offer(new int[]{i, j});
                    dis[i][j] = 0;
                }
            }
        }

        while (!q.isEmpty()) {
            int[] cur = q.poll();
            int cx = cur[0], cy = cur[1];
            for (int[] dir : dirs) {
                int nx = cx + dir[0];
                int ny = cy + dir[1];
                if (nx < 0 || ny < 0 || nx >= n || ny >= n || dis[nx][ny] != -1) {
                    continue;
                }
                dis[nx][ny] = dis[cx][cy] + 1;
                q.offer(new int[]{nx, ny});
            }
        }

        int lo = 0, hi = Math.min(dis[0][0], dis[n - 1][n - 1]);
        int res = 0;

        while (lo <= hi) {
            int mid = (lo + hi) / 2;
            if (check(dis, mid, dirs)) {
                res = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }

        return res;
    }

    private boolean check(int[][] dis, int limit, int[][] dirs) {
        int n = dis.length;
        boolean[][] visit = new boolean[n][n];
        Queue<int[]> q = new LinkedList<>();
        q.offer(new int[]{0, 0});
        visit[0][0] = true;

        while (!q.isEmpty()) {
            int[] cur = q.poll();
            int cx = cur[0], cy = cur[1];
            if (cx == n - 1 && cy == n - 1) {
                return true;
            }
            for (int[] dir : dirs) {
                int nx = cx + dir[0];
                int ny = cy + dir[1];
                if (nx < 0 || ny < 0 || nx >= n || ny >= n ||
                    visit[nx][ny] || dis[nx][ny] < limit) {
                    continue;
                }
                q.offer(new int[]{nx, ny});
                visit[nx][ny] = true;
            }
        }

        return false;
    }
}
```

```CSharp
class Solution {
    public int maximumSafenessFactor(List<List<Integer>> grid) {
        int n = grid.size();
        if (grid.get(0).get(0) == 1 || grid.get(n - 1).get(n - 1) == 1) {
            return 0;
        }

        int[][] dis = new int[n][n];
        for (int[] row : dis) {
            Arrays.fill(row, -1);
        }

        int[][] dirs = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
        Queue<int[]> q = new LinkedList<>();

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid.get(i).get(j) == 1) {
                    q.offer(new int[]{i, j});
                    dis[i][j] = 0;
                }
            }
        }

        while (!q.isEmpty()) {
            int[] cur = q.poll();
            int cx = cur[0], cy = cur[1];
            for (int[] dir : dirs) {
                int nx = cx + dir[0];
                int ny = cy + dir[1];
                if (nx < 0 || ny < 0 || nx >= n || ny >= n || dis[nx][ny] != -1) {
                    continue;
                }
                dis[nx][ny] = dis[cx][cy] + 1;
                q.offer(new int[]{nx, ny});
            }
        }

        int lo = 0, hi = Math.min(dis[0][0], dis[n - 1][n - 1]);
        int res = 0;

        while (lo <= hi) {
            int mid = (lo + hi) / 2;
            if (check(dis, mid, dirs)) {
                res = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }

        return res;
    }

    private boolean check(int[][] dis, int limit, int[][] dirs) {
        int n = dis.length;
        boolean[][] visit = new boolean[n][n];
        Queue<int[]> q = new LinkedList<>();
        q.offer(new int[]{0, 0});
        visit[0][0] = true;

        while (!q.isEmpty()) {
            int[] cur = q.poll();
            int cx = cur[0], cy = cur[1];
            if (cx == n - 1 && cy == n - 1) {
                return true;
            }
            for (int[] dir : dirs) {
                int nx = cx + dir[0];
                int ny = cy + dir[1];
                if (nx < 0 || ny < 0 || nx >= n || ny >= n ||
                    visit[nx][ny] || dis[nx][ny] < limit) {
                    continue;
                }
                q.offer(new int[]{nx, ny});
                visit[nx][ny] = true;
            }
        }

        return false;
    }
}
```

```Go
func maximumSafenessFactor(grid [][]int) int {
    n := len(grid)
    if grid[0][0] == 1 || grid[n-1][n-1] == 1 {
        return 0
    }

    dis := make([][]int, n)
    for i := range dis {
        dis[i] = make([]int, n)
        for j := range dis[i] {
            dis[i][j] = -1
        }
    }

    dirs := [][2]int{{-1, 0}, {1, 0}, {0, 1}, {0, -1}}
    q := make([][2]int, 0)

    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            if grid[i][j] == 1 {
                q = append(q, [2]int{i, j})
                dis[i][j] = 0
            }
        }
    }

    for len(q) > 0 {
        cx, cy := q[0][0], q[0][1]
        q = q[1:]
        for _, dir := range dirs {
            nx, ny := cx+dir[0], cy+dir[1]
            if nx < 0 || ny < 0 || nx >= n || ny >= n || dis[nx][ny] != -1 {
                continue
            }
            dis[nx][ny] = dis[cx][cy] + 1
            q = append(q, [2]int{nx, ny})
        }
    }

    check := func(limit int) bool {
        visit := make([][]bool, n)
        for i := range visit {
            visit[i] = make([]bool, n)
        }
        q := [][2]int{{0, 0}}
        visit[0][0] = true

        for len(q) > 0 {
            cx, cy := q[0][0], q[0][1]
            q = q[1:]
            if cx == n-1 && cy == n-1 {
                return true
            }
            for _, dir := range dirs {
                nx, ny := cx+dir[0], cy+dir[1]
                if nx < 0 || ny < 0 || nx >= n || ny >= n ||
                    visit[nx][ny] || dis[nx][ny] < limit {
                    continue
                }
                q = append(q, [2]int{nx, ny})
                visit[nx][ny] = true
            }
        }
        return false
    }

    lo, hi := 0, min(dis[0][0], dis[n-1][n-1])
    res := 0
    for lo <= hi {
        mid := (lo + hi) / 2
        if check(mid) {
            res = mid
            lo = mid + 1
        } else {
            hi = mid - 1
        }
    }
    return res
}
```

```Python
class Solution:
    def maximumSafenessFactor(self, grid: List[List[int]]) -> int:
        n = len(grid)

        if grid[0][0] == 1 or grid[n - 1][n - 1] == 1:
            return 0

        dis = [[-1] * n for _ in range(n)]
        dirs = [(-1, 0), (1, 0), (0, 1), (0, -1)]
        q = deque()

        for i in range(n):
            for j in range(n):
                if grid[i][j] == 1:
                    q.append((i, j))
                    dis[i][j] = 0

        while q:
            cx, cy = q.popleft()
            for dx, dy in dirs:
                nx, ny = cx + dx, cy + dy
                if 0 <= nx < n and 0 <= ny < n and dis[nx][ny] == -1:
                    dis[nx][ny] = dis[cx][cy] + 1
                    q.append((nx, ny))

        def check(limit: int) -> bool:
            visit = [[False] * n for _ in range(n)]
            q = deque([(0, 0)])
            visit[0][0] = True

            while q:
                cx, cy = q.popleft()
                if cx == n - 1 and cy == n - 1:
                    return True
                for dx, dy in dirs:
                    nx, ny = cx + dx, cy + dy
                    if (0 <= nx < n and 0 <= ny < n and
                        not visit[nx][ny] and dis[nx][ny] >= limit):
                        q.append((nx, ny))
                        visit[nx][ny] = True
            return False

        lo, hi = 0, min(dis[0][0], dis[n - 1][n - 1])
        res = 0
        while lo <= hi:
            mid = (lo + hi) // 2
            if check(mid):
                res = mid
                lo = mid + 1
            else:
                hi = mid - 1

        return res
```

```C
typedef struct {
    int x, y;
} Element;

typedef struct {
    Element* data;
    int front, rear, size, capacity;
} Queue;

Queue* createQueue(int capacity) {
    Queue* q = (Queue*)malloc(sizeof(Queue));
    q->data = (Element*)malloc(capacity * sizeof(Element));
    q->front = 0;
    q->rear = 0;
    q->size = 0;
    q->capacity = capacity;
    return q;
}

void enqueue(Queue* q, int x, int y) {
    if (q->size == q->capacity) {
        q->capacity *= 2;
        q->data = (Element*)realloc(q->data, q->capacity * sizeof(Element));
    }
    q->data[q->rear].x = x;
    q->data[q->rear].y = y;
    q->rear = (q->rear + 1) % q->capacity;
    q->size++;
}

Element dequeue(Queue* q) {
    Element p = q->data[q->front];
    q->front = (q->front + 1) % q->capacity;
    q->size--;
    return p;
}

bool isEmpty(Queue* q) {
    return q->size == 0;
}

void freeQueue(Queue* q) {
    free(q->data);
    free(q);
}

bool check(int** dis, int limit, int m, int n, int dirs[4][2]) {
    bool** visit = (bool**)malloc(m * sizeof(bool*));
    for (int i = 0; i < m; i++) {
        visit[i] = (bool*)calloc(n, sizeof(bool));
    }

    Queue* q = createQueue(m * n);
    enqueue(q, 0, 0);
    visit[0][0] = true;

    while (!isEmpty(q)) {
        Element p = dequeue(q);
        if (p.x == m - 1 && p.y == n - 1) {
            for (int i = 0; i < m; i++) {
                free(visit[i]);
            }
            free(visit);
            freeQueue(q);
            return true;
        }
        for (int i = 0; i < 4; i++) {
            int nx = p.x + dirs[i][0];
            int ny = p.y + dirs[i][1];
            if (nx >= 0 && nx < m && ny >= 0 && ny < n &&
                !visit[nx][ny] && dis[nx][ny] >= limit) {
                enqueue(q, nx, ny);
                visit[nx][ny] = true;
            }
        }
    }

    for (int i = 0; i < m; i++) {
        free(visit[i]);
    }
    free(visit);
    freeQueue(q);
    return false;
}

int maximumSafenessFactor(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize;
    int n = gridColSize[0];

    if (grid[0][0] == 1 || grid[m-1][n-1] == 1) {
        return 0;
    }

    int** dis = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; i++) {
        dis[i] = (int*)malloc(n * sizeof(int));
        for (int j = 0; j < n; j++) {
            dis[i][j] = -1;
        }
    }

    int dirs[4][2] = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
    Queue* q = createQueue(m * n);
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (grid[i][j] == 1) {
                enqueue(q, i, j);
                dis[i][j] = 0;
            }
        }
    }

    while (!isEmpty(q)) {
        Element p = dequeue(q);
        for (int i = 0; i < 4; i++) {
            int nx = p.x + dirs[i][0];
            int ny = p.y + dirs[i][1];
            if (nx >= 0 && nx < m && ny >= 0 && ny < n && dis[nx][ny] == -1) {
                dis[nx][ny] = dis[p.x][p.y] + 1;
                enqueue(q, nx, ny);
            }
        }
    }

    int lo = 0, hi = dis[0][0] < dis[m-1][n-1] ? dis[0][0] : dis[m-1][n-1];
    int res = 0;
    while (lo <= hi) {
        int mid = (lo + hi) / 2;
        if (check(dis, mid, m, n, dirs)) {
            res = mid;
            lo = mid + 1;
        } else {
            hi = mid - 1;
        }
    }

    for (int i = 0; i < m; i++) {
        free(dis[i]);
    }
    free(dis);
    freeQueue(q);

    return res;
}
```

```JavaScript
var maximumSafenessFactor = function(grid) {
    const m = grid.length;
    const n = grid[0].length;
    if (grid[0][0] === 1 || grid[m-1][n-1] === 1) {
        return 0;
    }

    const dis = Array.from({ length: m }, () => Array(n).fill(-1));
    const dirs = [[-1, 0], [1, 0], [0, 1], [0, -1]];
    const q = new Queue();
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] === 1) {
                q.push([i, j]);
                dis[i][j] = 0;
            }
        }
    }

    while (!q.isEmpty()) {
        const [cx, cy] = q.dequeue();
        for (const [dx, dy] of dirs) {
            const nx = cx + dx;
            const ny = cy + dy;
            if (nx >= 0 && nx < m && ny >= 0 && ny < n && dis[nx][ny] === -1) {
                dis[nx][ny] = dis[cx][cy] + 1;
                q.push([nx, ny]);
            }
        }
    }

    const check = (limit) => {
        const visit = Array.from({ length: m }, () => Array(n).fill(false));
        const q = [[0, 0]];
        visit[0][0] = true;
        let head = 0;

        while (head < q.length) {
            const [cx, cy] = q[head++];
            if (cx === m - 1 && cy === n - 1) {
                return true;
            }
            for (const [dx, dy] of dirs) {
                const nx = cx + dx;
                const ny = cy + dy;
                if (nx >= 0 && nx < m && ny >= 0 && ny < n &&
                    !visit[nx][ny] && dis[nx][ny] >= limit) {
                    q.push([nx, ny]);
                    visit[nx][ny] = true;
                }
            }
        }
        return false;
    };

    let lo = 0, hi = Math.min(dis[0][0], dis[m-1][n-1]);
    let res = 0;
    while (lo <= hi) {
        const mid = Math.floor((lo + hi) / 2);
        if (check(mid)) {
            res = mid;
            lo = mid + 1;
        } else {
            hi = mid - 1;
        }
    }

    return res;
};
```

```TypeScript
function maximumSafenessFactor(grid: number[][]): number {
    const n: number = grid.length;
    if (grid[0][0] === 1 || grid[n - 1][n - 1] === 1) {
        return 0;
    }

    const dis: number[][] = Array.from({ length: n }, () => Array(n).fill(-1));
    const dirs: number[][] = [[-1, 0], [1, 0], [0, 1], [0, -1]];
    const q: [number, number][] = [];

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] === 1) {
                q.push([i, j]);
                dis[i][j] = 0;
            }
        }
    }

    let head = 0;
    while (head < q.length) {
        const [cx, cy] = q[head++];
        for (const [dx, dy] of dirs) {
            const nx = cx + dx;
            const ny = cy + dy;
            if (nx >= 0 && nx < n && ny >= 0 && ny < n && dis[nx][ny] === -1) {
                dis[nx][ny] = dis[cx][cy] + 1;
                q.push([nx, ny]);
            }
        }
    }

    const check = (limit: number): boolean => {
        const visit: boolean[][] = Array.from({ length: n }, () => Array(n).fill(false));
        const q: [number, number][] = [[0, 0]];
        visit[0][0] = true;
        let head = 0;

        while (head < q.length) {
            const [cx, cy] = q[head++];
            if (cx === n - 1 && cy === n - 1) {
                return true;
            }
            for (const [dx, dy] of dirs) {
                const nx = cx + dx;
                const ny = cy + dy;
                if (nx >= 0 && nx < n && ny >= 0 && ny < n &&
                    !visit[nx][ny] && dis[nx][ny] >= limit) {
                    q.push([nx, ny]);
                    visit[nx][ny] = true;
                }
            }
        }
        return false;
    };

    let lo: number = 0, hi: number = Math.min(dis[0][0], dis[n - 1][n - 1]);
    let res: number = 0;
    while (lo <= hi) {
        const mid: number = Math.floor((lo + hi) / 2);
        if (check(mid)) {
            res = mid;
            lo = mid + 1;
        } else {
            hi = mid - 1;
        }
    }

    return res;
}
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn maximum_safeness_factor(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();

        if grid[0][0] == 1 || grid[m-1][n-1] == 1 {
            return 0;
        }

        let mut dis = vec![vec![-1; n]; m];
        let dirs = [(-1, 0), (1, 0), (0, 1), (0, -1)];
        let mut q = VecDeque::new();

        for i in 0..m {
            for j in 0..n {
                if grid[i][j] == 1 {
                    q.push_back((i, j));
                    dis[i][j] = 0;
                }
            }
        }

        while let Some((cx, cy)) = q.pop_front() {
            for &(dx, dy) in &dirs {
                let nx = cx as i32 + dx;
                let ny = cy as i32 + dy;
                if nx >= 0 && nx < m as i32 && ny >= 0 && ny < n as i32 {
                    let nx = nx as usize;
                    let ny = ny as usize;
                    if dis[nx][ny] == -1 {
                        dis[nx][ny] = dis[cx][cy] + 1;
                        q.push_back((nx, ny));
                    }
                }
            }
        }

        let check = |limit: i32| -> bool {
            let mut visit = vec![vec![false; n]; m];
            let mut q = VecDeque::new();
            q.push_back((0, 0));
            visit[0][0] = true;

            while let Some((cx, cy)) = q.pop_front() {
                if cx == m - 1 && cy == n - 1 {
                    return true;
                }
                for &(dx, dy) in &dirs {
                    let nx = cx as i32 + dx;
                    let ny = cy as i32 + dy;
                    if nx >= 0 && nx < m as i32 && ny >= 0 && ny < n as i32 {
                        let nx = nx as usize;
                        let ny = ny as usize;
                        if !visit[nx][ny] && dis[nx][ny] >= limit {
                            q.push_back((nx, ny));
                            visit[nx][ny] = true;
                        }
                    }
                }
            }
            false
        };

        let mut lo = 0;
        let mut hi = dis[0][0].min(dis[m-1][n-1]);
        let mut res = 0;

        while lo <= hi {
            let mid = (lo + hi) / 2;
            if check(mid) {
                res = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }

        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2\log n)$，其中 $n$ 是二维矩阵 $grid$ 的行数。多源 $BFS$ 计算每个单元格到最近小偷的距离需要 $O(n^2)$ 时间；二分查找的上限为 $n-1$，至多执行 $O(\log n)$ 轮，每轮搜索需要 $O(n^2)$ 时间。因此总时间复杂度为 $O(n^2\log n)$。
- 空间复杂度：$O(n^2)$。记录距离的 $dis$ 数组、每轮搜索的访问标记数组和队列均需要 $O(n^2)$ 空间。

#### 方法二：并查集

**思路与算法**

参考 $\lceil [Kruskal$ 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fmst%2F%23kruskal-%E7%AE%97%E6%B3%95)\rfloor  的思想，我们也可以使用并查集来求解。我们将 $n2$ 个节点放入并查集，实时维护它们的连通性。为了使路径上的最小值最大化，可以将所有单元格按其到小偷的最小距离（即 $dis$ 的值）从大到小排序，然后依次加入并查集。

具体做法是：按距离值降序访问每一个单元格 $(c_x,c_y)$，如果其相邻的上下左右某个单元格 $(n_x,n_y)$ 已经被访问过，则将这两个单元格在并查集中连通。随后，检查起点 $(0,0)$ 和终点 $(n-1,n-1)$ 是否连通。一旦连通，说明存在一条路径，其经过的所有节点的距离值都不小于当前单元格的距离值，此时当前单元格的距离值 $dis[c_x][c_y]$ 即为所求的**最大安全系数**，直接返回即可。

**代码**

```C++
class UnionFind {
public:
    UnionFind(int n) {
        parent =  vector<int>(n);
        rank = vector<int>(n);
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    void unite(int x, int y) {
        int rootx = find(x);
        int rooty = find(y);
        if (rootx != rooty) {
            if (rank[rootx] > rank[rooty]) {
                parent[rooty] = rootx;
            } else if (rank[rootx] < rank[rooty]) {
                parent[rootx] = rooty;
            } else {
                parent[rooty] = rootx;
                rank[rootx]++;
            }
        }
    }

    int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    bool connect(int x, int y) {
        return find(x) == find(y);
    }
private:
    vector<int> parent;
    vector<int> rank;
};

class Solution {
public:
    int maximumSafenessFactor(vector<vector<int>>& grid) {
        int n = grid[0].size();
        if (grid[0][0] || grid[n - 1][n - 1]) {
            return 0;
        }

        vector<vector<int>> dis(n, vector<int>(n, -1));
        int dirs[4][2] = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
        queue<pair<int, int>> q;
        vector<tuple<int, int, int>> cells;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j]) {
                    q.emplace(i, j);
                    dis[i][j] = 0;
                    cells.emplace_back(i, j, 0);
                }
            }
        }

        while (!q.empty()) {
            auto [cx, cy] = q.front();
            q.pop();
            for (int j = 0; j < 4; j++) {
                int nx = cx + dirs[j][0];
                int ny = cy + dirs[j][1];
                if (nx < 0 || ny < 0 || nx >= n || ny >= n || dis[nx][ny] != -1) {
                    continue;
                }
                dis[nx][ny] = dis[cx][cy] + 1;
                cells.emplace_back(nx, ny, dis[nx][ny]);
                q.emplace(nx, ny);
            }
        }

        UnionFind uf(n * n);
        vector<vector<bool>> visit(n, vector<bool>(n, false));
        for (int i = cells.size() - 1; i >= 0; i--) {
            auto [cx, cy, dist] = cells[i];
            visit[cx][cy] = true;
            for (int j = 0; j < 4; j++) {
                int nx = cx + dirs[j][0];
                int ny = cy + dirs[j][1];
                if (nx >= 0 && ny >= 0 && nx < n && ny < n && visit[nx][ny]) {
                    uf.unite(cx * n + cy, nx * n + ny);
                }
            }
            if (uf.connect(0, n * n - 1)) {
                return dist;
            }
        }

        return 0;
    }
};
```

```Java
import java.util.*;

class UnionFind {
    private int[] parent;
    private int[] rank;

    public UnionFind(int n) {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    public int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    public void unite(int x, int y) {
        int rootX = find(x);
        int rootY = find(y);
        if (rootX != rootY) {
            if (rank[rootX] > rank[rootY]) {
                parent[rootY] = rootX;
            } else if (rank[rootX] < rank[rootY]) {
                parent[rootX] = rootY;
            } else {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }

    public boolean connect(int x, int y) {
        return find(x) == find(y);
    }
}

class Solution {
    public int maximumSafenessFactor(List<List<Integer>> grid) {
        int n = grid.size();
        if (grid.get(0).get(0) == 1 || grid.get(n - 1).get(n - 1) == 1) {
            return 0;
        }

        int[][] dis = new int[n][n];
        for (int[] row : dis) Arrays.fill(row, -1);
        int[][] dirs = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
        Queue<int[]> q = new LinkedList<>();
        List<int[]> cells = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid.get(i).get(j) == 1) {
                    q.offer(new int[]{i, j});
                    dis[i][j] = 0;
                    cells.add(new int[]{i, j, 0});
                }
            }
        }

        while (!q.isEmpty()) {
            int[] cur = q.poll();
            int cx = cur[0], cy = cur[1];
            for (int[] d : dirs) {
                int nx = cx + d[0];
                int ny = cy + d[1];
                if (nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx][ny] == -1) {
                    dis[nx][ny] = dis[cx][cy] + 1;
                    cells.add(new int[]{nx, ny, dis[nx][ny]});
                    q.offer(new int[]{nx, ny});
                }
            }
        }

        UnionFind uf = new UnionFind(n * n);
        boolean[][] visit = new boolean[n][n];
        for (int i = cells.size() - 1; i >= 0; i--) {
            int[] cell = cells.get(i);
            int cx = cell[0], cy = cell[1], dist = cell[2];
            visit[cx][cy] = true;
            for (int[] d : dirs) {
                int nx = cx + d[0];
                int ny = cy + d[1];
                if (nx >= 0 && ny >= 0 && nx < n && ny < n && visit[nx][ny]) {
                    uf.unite(cx * n + cy, nx * n + ny);
                }
            }
            if (uf.connect(0, n * n - 1)) {
                return dist;
            }
        }
        return 0;
    }
}
```

```CSharp
public class UnionFind {
    private int[] parent;
    private int[] rank;

    public UnionFind(int n) {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    public int Find(int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    public void Unite(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY) {
            if (rank[rootX] > rank[rootY]) {
                parent[rootY] = rootX;
            } else if (rank[rootX] < rank[rootY]) {
                parent[rootX] = rootY;
            } else {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }

    public bool Connect(int x, int y) {
        return Find(x) == Find(y);
    }
}

public class Solution {
    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        int n = grid.Count;
        if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return 0;

        int[,] dis = new int[n, n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                dis[i, j] = -1;
            }
        }

        int[][] dirs = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
        Queue<(int, int)> q = new Queue<(int, int)>();
        List<(int, int, int)> cells = new List<(int, int, int)>();

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    q.Enqueue((i, j));
                    dis[i, j] = 0;
                    cells.Add((i, j, 0));
                }
            }
        }

        while (q.Count > 0) {
            var (cx, cy) = q.Dequeue();
            foreach (var d in dirs) {
                int nx = cx + d[0];
                int ny = cy + d[1];
                if (nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx, ny] == -1) {
                    dis[nx, ny] = dis[cx, cy] + 1;
                    cells.Add((nx, ny, dis[nx, ny]));
                    q.Enqueue((nx, ny));
                }
            }
        }

        UnionFind uf = new UnionFind(n * n);
        bool[,] visit = new bool[n, n];
        for (int i = cells.Count - 1; i >= 0; i--) {
            var (cx, cy, dist) = cells[i];
            visit[cx, cy] = true;
            foreach (var d in dirs) {
                int nx = cx + d[0];
                int ny = cy + d[1];
                if (nx >= 0 && ny >= 0 && nx < n && ny < n && visit[nx, ny]) {
                    uf.Unite(cx * n + cy, nx * n + ny);
                }
            }
            if (uf.Connect(0, n * n - 1)) {
                return dist;
            }
        }
        return 0;
    }
}
```

```Go
package main

type UnionFind struct {
    parent []int
    rank   []int
}

func NewUnionFind(n int) *UnionFind {
    uf := &UnionFind{
        parent: make([]int, n),
        rank:   make([]int, n),
    }
    for i := 0; i < n; i++ {
        uf.parent[i] = i
    }
    return uf
}

func (uf *UnionFind) Find(x int) int {
    if uf.parent[x] != x {
        uf.parent[x] = uf.Find(uf.parent[x])
    }
    return uf.parent[x]
}

func (uf *UnionFind) Unite(x, y int) {
    rootX := uf.Find(x)
    rootY := uf.Find(y)
    if rootX != rootY {
        if uf.rank[rootX] > uf.rank[rootY] {
            uf.parent[rootY] = rootX
        } else if uf.rank[rootX] < uf.rank[rootY] {
            uf.parent[rootX] = rootY
        } else {
            uf.parent[rootY] = rootX
            uf.rank[rootX]++
        }
    }
}

func (uf *UnionFind) Connect(x, y int) bool {
    return uf.Find(x) == uf.Find(y)
}

func maximumSafenessFactor(grid [][]int) int {
    n := len(grid)
    if grid[0][0] == 1 || grid[n-1][n-1] == 1 {
        return 0
    }

    dis := make([][]int, n)
    for i := range dis {
        dis[i] = make([]int, n)
        for j := range dis[i] {
            dis[i][j] = -1
        }
    }

    dirs := [4][2]int{{-1, 0}, {1, 0}, {0, 1}, {0, -1}}
    type point struct{ x, y int }
    q := make([]point, 0)
    type cell struct{ x, y, dist int }
    cells := make([]cell, 0)

    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            if grid[i][j] == 1 {
                q = append(q, point{i, j})
                dis[i][j] = 0
                cells = append(cells, cell{i, j, 0})
            }
        }
    }

    for len(q) > 0 {
        cur := q[0]
        q = q[1:]
        cx, cy := cur.x, cur.y
        for _, d := range dirs {
            nx, ny := cx+d[0], cy+d[1]
            if nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx][ny] == -1 {
                dis[nx][ny] = dis[cx][cy] + 1
                cells = append(cells, cell{nx, ny, dis[nx][ny]})
                q = append(q, point{nx, ny})
            }
        }
    }

    uf := NewUnionFind(n * n)
    visit := make([][]bool, n)
    for i := range visit {
        visit[i] = make([]bool, n)
    }

    for i := len(cells) - 1; i >= 0; i-- {
        c := cells[i]
        cx, cy, dist := c.x, c.y, c.dist
        visit[cx][cy] = true
        for _, d := range dirs {
            nx, ny := cx+d[0], cy+d[1]
            if nx >= 0 && ny >= 0 && nx < n && ny < n && visit[nx][ny] {
                uf.Unite(cx*n+cy, nx*n+ny)
            }
        }
        if uf.Connect(0, n*n-1) {
            return dist
        }
    }
    return 0
}
```

```Python
class UnionFind:
    def __init__(self, n):
        self.parent = list(range(n))
        self.rank = [0] * n

    def find(self, x):
        if self.parent[x] != x:
            self.parent[x] = self.find(self.parent[x])
        return self.parent[x]

    def unite(self, x, y):
        root_x = self.find(x)
        root_y = self.find(y)
        if root_x != root_y:
            if self.rank[root_x] > self.rank[root_y]:
                self.parent[root_y] = root_x
            elif self.rank[root_x] < self.rank[root_y]:
                self.parent[root_x] = root_y
            else:
                self.parent[root_y] = root_x
                self.rank[root_x] += 1

    def connect(self, x, y):
        return self.find(x) == self.find(y)

class Solution:
    def maximumSafenessFactor(self, grid: list[list[int]]) -> int:
        n = len(grid)
        if grid[0][0] or grid[n-1][n-1]:
            return 0

        dis = [[-1] * n for _ in range(n)]
        dirs = [(-1, 0), (1, 0), (0, 1), (0, -1)]
        q = deque()
        cells = []

        for i in range(n):
            for j in range(n):
                if grid[i][j]:
                    q.append((i, j))
                    dis[i][j] = 0
                    cells.append((i, j, 0))

        while q:
            cx, cy = q.popleft()
            for dx, dy in dirs:
                nx, ny = cx + dx, cy + dy
                if 0 <= nx < n and 0 <= ny < n and dis[nx][ny] == -1:
                    dis[nx][ny] = dis[cx][cy] + 1
                    cells.append((nx, ny, dis[nx][ny]))
                    q.append((nx, ny))

        uf = UnionFind(n * n)
        visit = [[False] * n for _ in range(n)]

        for i in range(len(cells) - 1, -1, -1):
            cx, cy, dist = cells[i]
            visit[cx][cy] = True
            for dx, dy in dirs:
                nx, ny = cx + dx, cy + dy
                if 0 <= nx < n and 0 <= ny < n and visit[nx][ny]:
                    uf.unite(cx * n + cy, nx * n + ny)
            if uf.connect(0, n * n - 1):
                return dist

        return 0
```

```C
typedef struct {
    int* parent;
    int* rank;
    int size;
} UnionFind;

UnionFind* createUnionFind(int n) {
    UnionFind* uf = (UnionFind*)malloc(sizeof(UnionFind));
    uf->parent = (int*)malloc(n * sizeof(int));
    uf->rank = (int*)calloc(n, sizeof(int));
    uf->size = n;
    for (int i = 0; i < n; i++) {
        uf->parent[i] = i;
    }
    return uf;
}

int find(UnionFind* uf, int x) {
    if (uf->parent[x] != x) {
        uf->parent[x] = find(uf, uf->parent[x]);
    }
    return uf->parent[x];
}

void unite(UnionFind* uf, int x, int y) {
    int rootX = find(uf, x);
    int rootY = find(uf, y);
    if (rootX != rootY) {
        if (uf->rank[rootX] > uf->rank[rootY]) {
            uf->parent[rootY] = rootX;
        } else if (uf->rank[rootX] < uf->rank[rootY]) {
            uf->parent[rootX] = rootY;
        } else {
            uf->parent[rootY] = rootX;
            uf->rank[rootX]++;
        }
    }
}

bool connect(UnionFind* uf, int x, int y) {
    return find(uf, x) == find(uf, y);
}

void freeUnionFind(UnionFind* uf) {
    free(uf->parent);
    free(uf->rank);
    free(uf);
}

typedef struct {
    int x, y, dist;
} Cell;

int maximumSafenessFactor(int** grid, int gridSize, int* gridColSize) {
    int n = gridSize;
    if (grid[0][0] == 1 || grid[n-1][n-1] == 1) {
        return 0;
    }
    int** dis = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; i++) {
        dis[i] = (int*)malloc(n * sizeof(int));
        memset(dis[i], -1, n * sizeof(int));
    }

    int dirs[4][2] = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
    int* qx = (int*)malloc(n * n * sizeof(int));
    int* qy = (int*)malloc(n * n * sizeof(int));
    int head = 0, tail = 0;
    Cell* cells = (Cell*)malloc(n * n * sizeof(Cell));
    int cellCount = 0;

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (grid[i][j] == 1) {
                qx[tail] = i;
                qy[tail] = j;
                tail++;
                dis[i][j] = 0;
                cells[cellCount++] = (Cell){i, j, 0};
            }
        }
    }

    while (head < tail) {
        int cx = qx[head], cy = qy[head]; head++;
        for (int d = 0; d < 4; d++) {
            int nx = cx + dirs[d][0];
            int ny = cy + dirs[d][1];
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx][ny] == -1) {
                dis[nx][ny] = dis[cx][cy] + 1;
                cells[cellCount++] = (Cell){nx, ny, dis[nx][ny]};
                qx[tail] = nx; qy[tail] = ny; tail++;
            }
        }
    }

    UnionFind* uf = createUnionFind(n * n);
    bool** visit = (bool**)malloc(n * sizeof(bool*));
    for (int i = 0; i < n; i++) {
        visit[i] = (bool*)calloc(n, sizeof(bool));
    }

    for (int i = cellCount - 1; i >= 0; i--) {
        Cell c = cells[i];
        int cx = c.x, cy = c.y, dist = c.dist;
        visit[cx][cy] = true;
        for (int d = 0; d < 4; d++) {
            int nx = cx + dirs[d][0];
            int ny = cy + dirs[d][1];
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && visit[nx][ny]) {
                unite(uf, cx * n + cy, nx * n + ny);
            }
        }
        if (connect(uf, 0, n * n - 1)) {
            free(qx); free(qy); free(cells);
            for (int j = 0; j < n; j++) {
                free(dis[j]);
                free(visit[j]);
            }
            free(dis);
            free(visit);
            freeUnionFind(uf);
            return dist;
        }
    }

    free(qx);
    free(qy);
    free(cells);
    for (int i = 0; i < n; i++) {
        free(dis[i]);
        free(visit[i]);
    }
    free(dis);
    free(visit);
    freeUnionFind(uf);
    return 0;
}
```

```JavaScript
class UnionFind {
    constructor(n) {
        this.parent = Array.from({ length: n }, (_, i) => i);
        this.rank = new Array(n).fill(0);
    }

    find(x) {
        if (this.parent[x] !== x) {
            this.parent[x] = this.find(this.parent[x]);
        }
        return this.parent[x];
    }

    unite(x, y) {
        const rootX = this.find(x);
        const rootY = this.find(y);
        if (rootX !== rootY) {
            if (this.rank[rootX] > this.rank[rootY]) {
                this.parent[rootY] = rootX;
            } else if (this.rank[rootX] < this.rank[rootY]) {
                this.parent[rootX] = rootY;
            } else {
                this.parent[rootY] = rootX;
                this.rank[rootX]++;
            }
        }
    }

    connect(x, y) {
        return this.find(x) === this.find(y);
    }
}

var maximumSafenessFactor = function(grid) {
    const n = grid.length;
    if (grid[0][0] || grid[n-1][n-1]) return 0;

    const dis = Array.from({ length: n }, () => new Array(n).fill(-1));
    const dirs = [[-1, 0], [1, 0], [0, 1], [0, -1]];
    const q = [];
    const cells = [];

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j]) {
                q.push([i, j]);
                dis[i][j] = 0;
                cells.push([i, j, 0]);
            }
        }
    }

    let head = 0;
    while (head < q.length) {
        const [cx, cy] = q[head++];
        for (const [dx, dy] of dirs) {
            const nx = cx + dx, ny = cy + dy;
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx][ny] === -1) {
                dis[nx][ny] = dis[cx][cy] + 1;
                cells.push([nx, ny, dis[nx][ny]]);
                q.push([nx, ny]);
            }
        }
    }

    const uf = new UnionFind(n * n);
    const visit = Array.from({ length: n }, () => new Array(n).fill(false));

    for (let i = cells.length - 1; i >= 0; i--) {
        const [cx, cy, dist] = cells[i];
        visit[cx][cy] = true;
        for (const [dx, dy] of dirs) {
            const nx = cx + dx, ny = cy + dy;
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && visit[nx][ny]) {
                uf.unite(cx * n + cy, nx * n + ny);
            }
        }
        if (uf.connect(0, n * n - 1)) {
            return dist;
        }
    }
    return 0;
};
```

```TypeScript
class UnionFind {
    private parent: number[];
    private rank: number[];

    constructor(n: number) {
        this.parent = Array.from({ length: n }, (_, i) => i);
        this.rank = new Array(n).fill(0);
    }

    find(x: number): number {
        if (this.parent[x] !== x) {
            this.parent[x] = this.find(this.parent[x]);
        }
        return this.parent[x];
    }

    unite(x: number, y: number): void {
        const rootX = this.find(x);
        const rootY = this.find(y);
        if (rootX !== rootY) {
            if (this.rank[rootX] > this.rank[rootY]) {
                this.parent[rootY] = rootX;
            } else if (this.rank[rootX] < this.rank[rootY]) {
                this.parent[rootX] = rootY;
            } else {
                this.parent[rootY] = rootX;
                this.rank[rootX]++;
            }
        }
    }

    connect(x: number, y: number): boolean {
        return this.find(x) === this.find(y);
    }
}

function maximumSafenessFactor(grid: number[][]): number {
    const n = grid.length;
    if (grid[0][0] || grid[n - 1][n - 1]) return 0;

    const dis: number[][] = Array.from({ length: n }, () => new Array(n).fill(-1));
    const dirs: [number, number][] = [[-1, 0], [1, 0], [0, 1], [0, -1]];
    const q: [number, number][] = [];
    const cells: [number, number, number][] = [];

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j]) {
                q.push([i, j]);
                dis[i][j] = 0;
                cells.push([i, j, 0]);
            }
        }
    }

    let head = 0;
    while (head < q.length) {
        const [cx, cy] = q[head++];
        for (const [dx, dy] of dirs) {
            const nx = cx + dx, ny = cy + dy;
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx][ny] === -1) {
                dis[nx][ny] = dis[cx][cy] + 1;
                cells.push([nx, ny, dis[nx][ny]]);
                q.push([nx, ny]);
            }
        }
    }

    const uf = new UnionFind(n * n);
    const visit: boolean[][] = Array.from({ length: n }, () => new Array(n).fill(false));

    for (let i = cells.length - 1; i >= 0; i--) {
        const [cx, cy, dist] = cells[i];
        visit[cx][cy] = true;
        for (const [dx, dy] of dirs) {
            const nx = cx + dx, ny = cy + dy;
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && visit[nx][ny]) {
                uf.unite(cx * n + cy, nx * n + ny);
            }
        }
        if (uf.connect(0, n * n - 1)) {
            return dist;
        }
    }
    return 0;
}
```

```Rust
struct UnionFind {
    parent: Vec<usize>,
    rank: Vec<usize>,
}

impl UnionFind {
    fn new(n: usize) -> Self {
        UnionFind {
            parent: (0..n).collect(),
            rank: vec![0; n],
        }
    }

    fn find(&mut self, x: usize) -> usize {
        if self.parent[x] != x {
            self.parent[x] = self.find(self.parent[x]);
        }
        self.parent[x]
    }

    fn unite(&mut self, x: usize, y: usize) {
        let root_x = self.find(x);
        let root_y = self.find(y);
        if root_x != root_y {
            if self.rank[root_x] > self.rank[root_y] {
                self.parent[root_y] = root_x;
            } else if self.rank[root_x] < self.rank[root_y] {
                self.parent[root_x] = root_y;
            } else {
                self.parent[root_y] = root_x;
                self.rank[root_x] += 1;
            }
        }
    }

    fn connect(&mut self, x: usize, y: usize) -> bool {
        self.find(x) == self.find(y)
    }
}

impl Solution {
    pub fn maximum_safeness_factor(grid: Vec<Vec<i32>>) -> i32 {
        let n = grid.len();
        if grid[0][0] == 1 || grid[n - 1][n - 1] == 1 {
            return 0;
        }

        let mut dis = vec![vec![-1; n]; n];
        let dirs: [(i32, i32); 4] = [(-1, 0), (1, 0), (0, 1), (0, -1)];
        let mut q = std::collections::VecDeque::new();
        let mut cells: Vec<(usize, usize, i32)> = Vec::new();

        for i in 0..n {
            for j in 0..n {
                if grid[i][j] == 1 {
                    q.push_back((i, j));
                    dis[i][j] = 0;
                    cells.push((i, j, 0));
                }
            }
        }

        while let Some((cx, cy)) = q.pop_front() {
            for &(dx, dy) in &dirs {
                let nx = cx as i32 + dx;
                let ny = cy as i32 + dy;
                if nx >= 0 && ny >= 0 && nx < n as i32 && ny < n as i32 {
                    let (nx, ny) = (nx as usize, ny as usize);
                    if dis[nx][ny] == -1 {
                        dis[nx][ny] = dis[cx][cy] + 1;
                        cells.push((nx, ny, dis[nx][ny]));
                        q.push_back((nx, ny));
                    }
                }
            }
        }

        let mut uf = UnionFind::new(n * n);
        let mut visit = vec![vec![false; n]; n];

        for i in (0..cells.len()).rev() {
            let (cx, cy, dist) = cells[i];
            visit[cx][cy] = true;
            for &(dx, dy) in &dirs {
                let nx = cx as i32 + dx;
                let ny = cy as i32 + dy;
                if nx >= 0 && ny >= 0 && nx < n as i32 && ny < n as i32 {
                    let (nx, ny) = (nx as usize, ny as usize);
                    if visit[nx][ny] {
                        uf.unite(cx * n + cy, nx * n + ny);
                    }
                }
            }
            if uf.connect(0, n * n - 1) {
                return dist;
            }
        }

        0
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2\alpha (n^2))$，其中 $n$ 是矩阵的行数，$\alpha $ 是反阿克曼函数。多源 $BFS$ 计算距离需要 $O(n^2)$；并查集每次合并与查找操作均为近似常数时间 $O(\alpha (n^2))$，最多需要合并与查找并查集 $n^2$ 次，因此总的时间复杂度为 $O(n^2\alpha (n^2))$。
- 空间复杂度：$O(n^2)$，其中 $n$ 是矩阵的行数。距离数组和并查集各需要 $O(n^2)$ 的额外空间。

#### 方法三：优先队列

**思路与算法**

参考 $\lceil [Prim$ 算法](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fgraph%2Fmst%2F%23prim-%E7%AE%97%E6%B3%95)\rfloor  的思路，我们还可以采用类似 $Dijkstra$ 的启发式搜索方法。核心想法是：在扩展路径时，总是优先选择当前距离值最大的单元格，从而最大化路径上的最小值。

我们将起点 $(0,0)$ 加入优先队列（大根堆，以距离值为优先级），并维护一个变量记录当前路径上距离值的最小值，即**最大安全系数**。每一步，我们从优先队列中取出当前距离值最大的未访问单元格 $(c_x,c_y)$，更新最大安全系数为当前路径上的最小值（即 $min(maxSafenessFactor,dis[c_x][c_y])$），然后将与其相邻且未访问的单元格加入队列。当我们第一次取出终点 $(n-1,n-1)$ 时，此时的最大安全系数 $maxSafenessFactor$ 就是所求答案。

**代码**

```C++
class Solution {
public:
    int maximumSafenessFactor(vector<vector<int>>& grid) {
        int n = grid[0].size();
        if (grid[0][0] || grid[n - 1][n - 1]) {
            return 0;
        }

        vector<vector<int>> dis(n, vector<int>(n, -1));
        int dirs[4][2] = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
        queue<pair<int, int>> q;
        vector<tuple<int, int, int>> cells;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j]) {
                    q.emplace(i, j);
                    dis[i][j] = 0;
                    cells.emplace_back(i, j, 0);
                }
            }
        }

        while (!q.empty()) {
            auto [cx, cy] = q.front();
            q.pop();
            for (int j = 0; j < 4; j++) {
                int nx = cx + dirs[j][0];
                int ny = cy + dirs[j][1];
                if (nx < 0 || ny < 0 || nx >= n || ny >= n || dis[nx][ny] != -1) {
                    continue;
                }
                dis[nx][ny] = dis[cx][cy] + 1;
                cells.emplace_back(nx, ny, dis[nx][ny]);
                q.emplace(nx, ny);
            }
        }

        vector<vector<bool>> visit(n, vector<bool>(n));
        priority_queue<tuple<int, int, int>, vector<tuple<int, int, int>>, less<>> pq;
        visit[0][0] = true;
        pq.emplace(dis[0][0], 0, 0);
        int maxSafenessFactor = min(dis[0][0], dis[n - 1][n - 1]);
        while (!pq.empty()) {
            auto [val, cx, cy] = pq.top();
            pq.pop();
            maxSafenessFactor = min(maxSafenessFactor, val);
            if (cx == n - 1 && cy == n - 1) {
                break;
            }
            for (int i = 0; i < 4; i++) {
                int nx = cx + dirs[i][0];
                int ny = cy + dirs[i][1];
                if (nx < 0 || ny < 0 || nx >= n || ny >= n || visit[nx][ny]) {
                    continue;
                }
                visit[nx][ny] = true;
                pq.emplace(dis[nx][ny], nx, ny);
            }
        }

        return maxSafenessFactor;
    }
};
```

```Java
class Solution {
    public int maximumSafenessFactor(List<List<Integer>> grid) {
        int n = grid.size();
        if (grid.get(0).get(0) == 1 || grid.get(n - 1).get(n - 1) == 1) {
            return 0;
        }

        int[][] dis = new int[n][n];
        for (int[] row : dis) Arrays.fill(row, -1);
        int[][] dirs = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
        Queue<int[]> q = new LinkedList<>();

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid.get(i).get(j) == 1) {
                    q.offer(new int[]{i, j});
                    dis[i][j] = 0;
                }
            }
        }

        while (!q.isEmpty()) {
            int[] cur = q.poll();
            int cx = cur[0], cy = cur[1];
            for (int[] d : dirs) {
                int nx = cx + d[0];
                int ny = cy + d[1];
                if (nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx][ny] == -1) {
                    dis[nx][ny] = dis[cx][cy] + 1;
                    q.offer(new int[]{nx, ny});
                }
            }
        }

        boolean[][] visit = new boolean[n][n];
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> Integer.compare(b[0], a[0]));
        visit[0][0] = true;
        pq.offer(new int[]{dis[0][0], 0, 0});
        int maxSafenessFactor = Math.min(dis[0][0], dis[n - 1][n - 1]);

        while (!pq.isEmpty()) {
            int[] cur = pq.poll();
            int val = cur[0], cx = cur[1], cy = cur[2];
            maxSafenessFactor = Math.min(maxSafenessFactor, val);
            if (cx == n - 1 && cy == n - 1) {
                break;
            }
            for (int[] d : dirs) {
                int nx = cx + d[0];
                int ny = cy + d[1];
                if (nx >= 0 && ny >= 0 && nx < n && ny < n && !visit[nx][ny]) {
                    visit[nx][ny] = true;
                    pq.offer(new int[]{dis[nx][ny], nx, ny});
                }
            }
        }
        return maxSafenessFactor;
    }
}
```

```CSharp
public class Solution {
    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        int n = grid.Count;
        if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return 0;

        int[,] dis = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                dis[i, j] = -1;

        int[][] dirs = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
        Queue<(int, int)> q = new Queue<(int, int)>();

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    q.Enqueue((i, j));
                    dis[i, j] = 0;
                }
            }
        }

        while (q.Count > 0) {
            var (cx, cy) = q.Dequeue();
            foreach (var d in dirs) {
                int nx = cx + d[0], ny = cy + d[1];
                if (nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx, ny] == -1) {
                    dis[nx, ny] = dis[cx, cy] + 1;
                    q.Enqueue((nx, ny));
                }
            }
        }

        bool[,] visit = new bool[n, n];
        var pq = new PriorityQueue<(int val, int x, int y), int>();
        visit[0, 0] = true;
        pq.Enqueue((dis[0, 0], 0, 0), -dis[0, 0]);
        int maxSafenessFactor = Math.Min(dis[0, 0], dis[n - 1, n - 1]);

        while (pq.Count > 0) {
            var (val, cx, cy) = pq.Dequeue();
            maxSafenessFactor = Math.Min(maxSafenessFactor, val);
            if (cx == n - 1 && cy == n - 1) break;
            foreach (var d in dirs) {
                int nx = cx + d[0], ny = cy + d[1];
                if (nx >= 0 && ny >= 0 && nx < n && ny < n && !visit[nx, ny]) {
                    visit[nx, ny] = true;
                    pq.Enqueue((dis[nx, ny], nx, ny), -dis[nx, ny]);
                }
            }
        }
        return maxSafenessFactor;
    }
}
```

```Go
func maximumSafenessFactor(grid [][]int) int {
    n := len(grid)
    if grid[0][0] == 1 || grid[n-1][n-1] == 1 {
        return 0
    }

    dis := make([][]int, n)
    for i := range dis {
        dis[i] = make([]int, n)
        for j := range dis[i] {
            dis[i][j] = -1
        }
    }

    dirs := [4][2]int{{-1, 0}, {1, 0}, {0, 1}, {0, -1}}
    type point struct{ x, y int }
    q := make([]point, 0)

    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            if grid[i][j] == 1 {
                q = append(q, point{i, j})
                dis[i][j] = 0
            }
        }
    }

    for len(q) > 0 {
        cur := q[0]
        q = q[1:]
        for _, d := range dirs {
            nx, ny := cur.x+d[0], cur.y+d[1]
            if nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx][ny] == -1 {
                dis[nx][ny] = dis[cur.x][cur.y] + 1
                q = append(q, point{nx, ny})
            }
        }
    }

    visit := make([][]bool, n)
    for i := range visit {
        visit[i] = make([]bool, n)
    }

    pq := &MaxHeap{}
    heap.Init(pq)
    visit[0][0] = true
    heap.Push(pq, Item{dis[0][0], 0, 0})

    maxSafenessFactor := dis[0][0]
    if dis[n-1][n-1] < maxSafenessFactor {
        maxSafenessFactor = dis[n-1][n-1]
    }

    for pq.Len() > 0 {
        item := heap.Pop(pq).(Item)
        if item.val < maxSafenessFactor {
            maxSafenessFactor = item.val
        }
        if item.x == n-1 && item.y == n-1 {
            break
        }
        for _, d := range dirs {
            nx, ny := item.x+d[0], item.y+d[1]
            if nx >= 0 && ny >= 0 && nx < n && ny < n && !visit[nx][ny] {
                visit[nx][ny] = true
                heap.Push(pq, Item{dis[nx][ny], nx, ny})
            }
        }
    }
    return maxSafenessFactor
}

type Item struct {
    val, x, y int
}

type MaxHeap []Item

func (h MaxHeap) Len() int            { return len(h) }
func (h MaxHeap) Less(i, j int) bool  { return h[i].val > h[j].val }
func (h MaxHeap) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *MaxHeap) Push(x interface{}) { *h = append(*h, x.(Item)) }
func (h *MaxHeap) Pop() interface{} {
    old := *h
    n := len(old)
    item := old[n-1]
    *h = old[0 : n-1]
    return item
}
```

```Python
class Solution:
    def maximumSafenessFactor(self, grid: list[list[int]]) -> int:
        n = len(grid)
        if grid[0][0] or grid[n-1][n-1]:
            return 0

        dis = [[-1] * n for _ in range(n)]
        dirs = [(-1, 0), (1, 0), (0, 1), (0, -1)]
        q = deque()

        for i in range(n):
            for j in range(n):
                if grid[i][j]:
                    q.append((i, j))
                    dis[i][j] = 0

        while q:
            cx, cy = q.popleft()
            for dx, dy in dirs:
                nx, ny = cx + dx, cy + dy
                if 0 <= nx < n and 0 <= ny < n and dis[nx][ny] == -1:
                    dis[nx][ny] = dis[cx][cy] + 1
                    q.append((nx, ny))

        visit = [[False] * n for _ in range(n)]
        pq = [(-dis[0][0], 0, 0)]
        visit[0][0] = True
        max_safeness = min(dis[0][0], dis[n-1][n-1])

        while pq:
            val, cx, cy = heapq.heappop(pq)
            val = -val
            max_safeness = min(max_safeness, val)
            if cx == n - 1 and cy == n - 1:
                break
            for dx, dy in dirs:
                nx, ny = cx + dx, cy + dy
                if 0 <= nx < n and 0 <= ny < n and not visit[nx][ny]:
                    visit[nx][ny] = True
                    heapq.heappush(pq, (-dis[nx][ny], nx, ny))

        return max_safeness
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int data[3];
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

Element *createElement(int dist, int x, int y) {
    Element *obj = (Element *)malloc(sizeof(Element));
    obj->data[0] = dist;
    obj->data[1] = x;
    obj->data[2] = y;
    return obj;
}

static bool less(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data[0] < e2->data[0];
}

static void memswap(void *m1, void *m2, size_t size) {
    unsigned char *a = (unsigned char *)m1;
    unsigned char *b = (unsigned char *)m2;
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

int maximumSafenessFactor(int** grid, int gridSize, int* gridColSize) {
    int n = gridSize;
    if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1) {
        return 0;
    }

    int **dis = (int **)malloc(sizeof(int *) * n);
    for (int i = 0; i < n; i++) {
        dis[i] = (int *)malloc(sizeof(int) * n);
        memset(dis[i], -1, sizeof(int) * n);
    }

    int dirs[4][2] = {{-1, 0}, {1, 0}, {0, 1}, {0, -1}};
    int *qx = (int *)malloc(sizeof(int) * n * n);
    int *qy = (int *)malloc(sizeof(int) * n * n);
    int head = 0, tail = 0;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (grid[i][j] == 1) {
                qx[tail] = i;
                qy[tail] = j;
                tail++;
                dis[i][j] = 0;
            }
        }
    }

    while (head < tail) {
        int cx = qx[head];
        int cy = qy[head];
        head++;
        for (int d = 0; d < 4; d++) {
            int nx = cx + dirs[d][0];
            int ny = cy + dirs[d][1];
            if (nx >= 0 && nx < n && ny >= 0 && ny < n && dis[nx][ny] == -1) {
                dis[nx][ny] = dis[cx][cy] + 1;
                qx[tail] = nx;
                qy[tail] = ny;
                tail++;
            }
        }
    }

    free(qx);
    free(qy);
    bool **visit = (bool **)malloc(sizeof(bool *) * n);
    for (int i = 0; i < n; i++) {
        visit[i] = (bool *)calloc(n, sizeof(bool));
    }

    PriorityQueue *pq = createPriorityQueue(less);
    Element *start = createElement(dis[0][0], 0, 0);
    enQueue(pq, start);
    free(start);
    visit[0][0] = true;
    int maxSafeness = dis[0][0] < dis[n - 1][n - 1] ? dis[0][0] : dis[n - 1][n - 1];

    while (!isEmpty(pq)) {
        Element *cur = front(pq);
        int dist = cur->data[0];
        int cx = cur->data[1];
        int cy = cur->data[2];
        deQueue(pq);
        if (dist < maxSafeness) {
            maxSafeness = dist;
        }
        if (cx == n - 1 && cy == n - 1) {
            break;
        }

        for (int d = 0; d < 4; d++) {
            int nx = cx + dirs[d][0];
            int ny = cy + dirs[d][1];
            if (nx >= 0 && nx < n && ny >= 0 && ny < n && !visit[nx][ny]) {
                visit[nx][ny] = true;
                Element *next = createElement(dis[nx][ny], nx, ny);
                enQueue(pq, next);
                free(next);
            }
        }
    }

    for (int i = 0; i < n; i++) {
        free(dis[i]);
        free(visit[i]);
    }
    free(dis);
    free(visit);
    freeQueue(pq);

    return maxSafeness;
}
```

```JavaScript
var maximumSafenessFactor = function(grid) {
    const n = grid.length;
    if (grid[0][0] || grid[n - 1][n - 1]) {
        return 0;
    }
    const dis = Array.from({ length: n }, () => new Array(n).fill(-1));
    const dirs = [[-1, 0], [1, 0], [0, 1], [0, -1]];
    const q = [];

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] === 1) {
                q.push([i, j]);
                dis[i][j] = 0;
            }
        }
    }

    let head = 0;
    while (head < q.length) {
        const [cx, cy] = q[head++];
        for (const [dx, dy] of dirs) {
            const nx = cx + dx, ny = cy + dy;
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx][ny] === -1) {
                dis[nx][ny] = dis[cx][cy] + 1;
                q.push([nx, ny]);
            }
        }
    }

    const visit = Array.from({ length: n }, () => new Array(n).fill(false));
    const pq = new MaxPriorityQueue((item) => item.val);
    visit[0][0] = true;
    pq.enqueue({ val: dis[0][0], x: 0, y: 0 });
    let maxSafeness = Math.min(dis[0][0], dis[n - 1][n - 1]);

    while (!pq.isEmpty()) {
        const { val, x: cx, y: cy } = pq.dequeue();
        maxSafeness = Math.min(maxSafeness, val);
        if (cx === n - 1 && cy === n - 1) {
            break;
        }
        for (const [dx, dy] of dirs) {
            const nx = cx + dx, ny = cy + dy;
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && !visit[nx][ny]) {
                visit[nx][ny] = true;
                pq.enqueue({ val: dis[nx][ny], x: nx, y: ny });
            }
        }
    }

    return maxSafeness;
};
```

```TypeScript
interface QueueItem {
    val: number;
    x: number;
    y: number;
}

function maximumSafenessFactor(grid: number[][]): number {
    const n = grid.length;
    if (grid[0][0] === 1 || grid[n - 1][n - 1] === 1) {
        return 0;
    }
    const dis: number[][] = Array.from({ length: n }, () => new Array(n).fill(-1));
    const dirs: [number, number][] = [[-1, 0], [1, 0], [0, 1], [0, -1]];
    const q: [number, number][] = [];

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] === 1) {
                q.push([i, j]);
                dis[i][j] = 0;
            }
        }
    }

    let head = 0;
    while (head < q.length) {
        const [cx, cy] = q[head++];
        for (const [dx, dy] of dirs) {
            const nx = cx + dx;
            const ny = cy + dy;
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && dis[nx][ny] === -1) {
                dis[nx][ny] = dis[cx][cy] + 1;
                q.push([nx, ny]);
            }
        }
    }

    const visit: boolean[][] = Array.from({ length: n }, () => new Array(n).fill(false));
    const pq = new MaxPriorityQueue<QueueItem>((item: QueueItem) => item.val);
    visit[0][0] = true;
    pq.enqueue({ val: dis[0][0], x: 0, y: 0 });
    let maxSafeness = Math.min(dis[0][0], dis[n - 1][n - 1]);

    while (!pq.isEmpty()) {
        const { val, x: cx, y: cy } = pq.dequeue()!;
        maxSafeness = Math.min(maxSafeness, val);
        if (cx === n - 1 && cy === n - 1) {
            break;
        }
        for (const [dx, dy] of dirs) {
            const nx = cx + dx;
            const ny = cy + dy;
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && !visit[nx][ny]) {
                visit[nx][ny] = true;
                pq.enqueue({ val: dis[nx][ny], x: nx, y: ny });
            }
        }
    }

    return maxSafeness;
}
```

```Rust
use std::collections::{VecDeque, BinaryHeap};
use std::cmp::Reverse;

impl Solution {
    pub fn maximum_safeness_factor(grid: Vec<Vec<i32>>) -> i32 {
        let n = grid.len();
        if grid[0][0] == 1 || grid[n - 1][n - 1] == 1 {
            return 0;
        }

        let mut dis = vec![vec![-1; n]; n];
        let dirs: [(i32, i32); 4] = [(-1, 0), (1, 0), (0, 1), (0, -1)];
        let mut q = VecDeque::new();

        for i in 0..n {
            for j in 0..n {
                if grid[i][j] == 1 {
                    q.push_back((i, j));
                    dis[i][j] = 0;
                }
            }
        }

        while let Some((cx, cy)) = q.pop_front() {
            for &(dx, dy) in &dirs {
                let nx = cx as i32 + dx;
                let ny = cy as i32 + dy;
                if nx >= 0 && ny >= 0 && nx < n as i32 && ny < n as i32 {
                    let (nx, ny) = (nx as usize, ny as usize);
                    if dis[nx][ny] == -1 {
                        dis[nx][ny] = dis[cx][cy] + 1;
                        q.push_back((nx, ny));
                    }
                }
            }
        }

        let mut visit = vec![vec![false; n]; n];
        let mut pq: BinaryHeap<(i32, Reverse<i32>, usize, usize)> = BinaryHeap::new();
        visit[0][0] = true;
        pq.push((dis[0][0], Reverse(0), 0, 0));
        let mut max_safeness = std::cmp::min(dis[0][0], dis[n - 1][n - 1]);

        while let Some((val, _, cx, cy)) = pq.pop() {
            max_safeness = std::cmp::min(max_safeness, val);
            if cx == n - 1 && cy == n - 1 {
                break;
            }
            for &(dx, dy) in &dirs {
                let nx = cx as i32 + dx;
                let ny = cy as i32 + dy;
                if nx >= 0 && ny >= 0 && nx < n as i32 && ny < n as i32 {
                    let (nx, ny) = (nx as usize, ny as usize);
                    if !visit[nx][ny] {
                        visit[nx][ny] = true;
                        pq.push((dis[nx][ny], Reverse(0), nx, ny));
                    }
                }
            }
        }
        max_safeness
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2\log n)$，其中 $n$ 表示给定二维矩阵 $grid$ 的行数。使用 $BFS$ 计算每个空单元格到最近的小偷单元格的距离的时间是 $O(n^2)$，使用优先队列查找最大安全系数，最多需要插入和删除队列 $O(n^2)$ 次，每次从队列中插入和删除元素需要的时间为 $O(\log n2)=2\cdot O(\log n)$，因此总的时间复杂度是 $O(n^2\log n)$。
- 空间复杂度：$O(n^2)$，其中 $n$ 表示给定二维矩阵 $grid$ 的行数。记录每个单元格到最近的小偷单元格的距离的二维数组的空间是 $O(n^2)$，队列中最多存在 $O(n^2)$ 个元素，记录元素是否访问需要空间为 $O(n^2)$，因此总的空间为 $O(n^2)$。
