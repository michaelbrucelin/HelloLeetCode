### [逃离火灾](https://leetcode.cn/problems/escape-the-spreading-fire/solutions/2515223/tao-chi-huo-zai-by-leetcode-solution-2f1m/)

#### 方法一：二分查找

**思路与算法**

假设已知最大可以停留的时间为 $stayTime$，则当停留的时间大于 $stayTime$ 时则一定无法到达终点，当停留时间小于 $stayTime$ 时，则一定可以到达终点，二者成线性关系，因此可以利用二分查找找到最大停留时间。题目的关键转换为已知停留的时间 $stayTime$，如何检测当前停留时间下是否可以到达终点。 首先我们分析从起点 $(0,0)$ 如何才能到达终点 $(m-1, n-1)$，假设在起点停留时间为 $t$ 分钟，我们从起点到达终点的路径为 $((0,0)\rightarrow (x_1,y_1)\rightarrow (x_2,y_2)\rightarrow \cdots \rightarrow (x_k,y_k)\rightarrow (m-1,n-1))$，则从起点到终点路径中的第 $i$ 个位置 $(x_i,y_i)$ 时，应满足在 $t + i$ 分钟时，$(x_i,y_i)$ 不会着火。由于火到达每个格子的时间是固定的，我们可以提前求出火到达每个格子的时间 $fireTime[i][j]$，然后检测是否满足 $fireTime[i][j] > t + i$ 即可。我们可以利用广度优先搜索从着火的格子开始一层一层往外扩展，即可求出每个格子的着火时间。 利用二分查找检测过程如下：

-   假设在起点停留的时间为 $stayTime$，则从起点 $(0,0)$ 开始出发经过 $time$ 分钟后到达位置 $(i,j)$，此时我们需要检测 $fireTime[i][j] > t + i$，如果满足则表示当前格子可以通过，如果不满足则表示当前格子无法通过，通过广度优先搜索不断扩展，检测是否可以到达终点 $(m-1,n-1)$。在终点 $(m-1,n-1)$ 特殊位置此时只需要考虑 $fireTime[i][j] \ge t + k$，其中 $k$ 表示从起点到达终点需要花费的时间。

为了计算方便，我们初始化时令每个格子着火的时间为无穷大，即火无法到达的格子的着火时间为 $\infty$。

**代码**

```c++
class Solution {
public:
    constexpr static int INF = 1e9;
    constexpr static int dirs[4][2] = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
    int maximumMinutes(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> fireTime(m, vector<int>(n, INF));
        /* 通过 bfs 求出每个格子着火的时间 */
        bfs(grid, fireTime);
        /* 二分查找找到最大停留时间 */
        int ans = -1;
        int low = 0, high = m * n;
        while (low <= high) {
            int mid = low + (high - low) / 2;     
            if (check(fireTime, grid, mid)) {
                ans = mid;
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return ans >= m * n ? 1e9 : ans;
    }

    void bfs(vector<vector<int>> &grid, vector<vector<int>> &fireTime) {
        int m = grid.size();
        int n = grid[0].size();
        queue<pair<int, int>> q;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    q.emplace(i, j);
                    fireTime[i][j] = 0;
                }
            }
        }

        int time = 1;
        while (!q.empty()) {
            int sz = q.size();
            for (int i = 0; i < sz; i++) {
                auto [cx, cy] = q.front();
                q.pop();
                for (int j = 0; j < 4; j++) {
                    int nx = cx + dirs[j][0];
                    int ny = cy + dirs[j][1];
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                            continue;
                        }
                        q.emplace(nx, ny);
                        fireTime[nx][ny] = time;
                    }
                }
            }
            time++;
        }
    }

    bool check(vector<vector<int>> &fireTime, vector<vector<int>> &grid, int stayTime) {
        int m = fireTime.size();
        int n = fireTime[0].size();
        vector<vector<bool>> visit(m, vector<bool>(n, false));
        queue<tuple<int, int, int>> q;
        q.emplace(0, 0, stayTime);
        visit[0][0] = true;

        while (!q.empty()) {
            auto [cx, cy, time] = q.front();
            q.pop();
            for (int i = 0; i < 4; i++) {
                int nx = cx + dirs[i][0];
                int ny = cy + dirs[i][1];
                if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                    if (visit[nx][ny] || grid[nx][ny] == 2) {
                        continue;
                    }
                    /* 到达安全屋 */
                    if (nx == m - 1 && ny == n - 1) {
                        return fireTime[nx][ny] >= time + 1;
                    }
                    /* 火未到达当前位置 */
                    if (fireTime[nx][ny] > time + 1) {
                        q.emplace(nx, ny, time + 1);
                        visit[nx][ny] = true;
                    }
                }
            }
        }
        return false;
    }
};
```

```java
class Solution {
    static final int INF = 1000000000;
    static int[][] dirs = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

    public int maximumMinutes(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[][] fireTime = new int[m][n];
        for (int i = 0; i < m; i++) {
            Arrays.fill(fireTime[i], INF);
        }
        /* 通过 bfs 求出每个格子着火的时间 */
        bfs(grid, fireTime);
        /* 二分查找找到最大停留时间 */
        int ans = -1;
        int low = 0, high = m * n;
        while (low <= high) {
            int mid = low + (high - low) / 2;     
            if (check(fireTime, grid, mid)) {
                ans = mid;
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return ans >= m * n ? INF : ans;
    }

    public void bfs(int[][] grid, int[][] fireTime) {
        int m = grid.length;
        int n = grid[0].length;
        Queue<int[]> queue = new ArrayDeque<int[]>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    queue.offer(new int[]{i, j});
                    fireTime[i][j] = 0;
                }
            }
        }

        int time = 1;
        while (!queue.isEmpty()) {
            int sz = queue.size();
            for (int i = 0; i < sz; i++) {
                int[] arr = queue.poll();
                int cx = arr[0], cy = arr[1];
                for (int j = 0; j < 4; j++) {
                    int nx = cx + dirs[j][0];
                    int ny = cy + dirs[j][1];
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                            continue;
                        }
                        queue.offer(new int[]{nx, ny});
                        fireTime[nx][ny] = time;
                    }
                }
            }
            time++;
        }
    }

    public boolean check(int[][] fireTime, int[][] grid, int stayTime) {
        int m = fireTime.length;
        int n = fireTime[0].length;
        boolean[][] visit = new boolean[m][n];
        Queue<int[]> queue = new ArrayDeque<int[]>();
        queue.offer(new int[]{0, 0, stayTime});
        visit[0][0] = true;

        while (!queue.isEmpty()) {
            int[] arr = queue.poll();
            int cx = arr[0], cy = arr[1], time = arr[2];
            for (int i = 0; i < 4; i++) {
                int nx = cx + dirs[i][0];
                int ny = cy + dirs[i][1];
                if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                    if (visit[nx][ny] || grid[nx][ny] == 2) {
                        continue;
                    }
                    /* 到达安全屋 */
                    if (nx == m - 1 && ny == n - 1) {
                        return fireTime[nx][ny] >= time + 1;
                    }
                    /* 火未到达当前位置 */
                    if (fireTime[nx][ny] > time + 1) {
                        queue.offer(new int[]{nx, ny, time + 1});
                        visit[nx][ny] = true;
                    }
                }
            }
        }
        return false;
    }
}
```

```csharp
public class Solution {
    const int INF = 1000000000;
    static int[][] dirs = {new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};

    public int MaximumMinutes(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] fireTime = new int[m][];
        for (int i = 0; i < m; i++) {
            fireTime[i] = new int[n];
            Array.Fill(fireTime[i], INF);
        }
        /* 通过 BFS 求出每个格子着火的时间 */
        BFS(grid, fireTime);
        /* 二分查找找到最大停留时间 */
        int ans = -1;
        int low = 0, high = m * n;
        while (low <= high) {
            int mid = low + (high - low) / 2;     
            if (Check(fireTime, grid, mid)) {
                ans = mid;
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return ans >= m * n ? INF : ans;
    }

    public void BFS(int[][] grid, int[][] fireTime) {
        int m = grid.Length;
        int n = grid[0].Length;
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    queue.Enqueue(new Tuple<int, int>(i, j));
                    fireTime[i][j] = 0;
                }
            }
        }

        int time = 1;
        while (queue.Count > 0) {
            int sz = queue.Count;
            for (int i = 0; i < sz; i++) {
                Tuple<int, int> tuple = queue.Dequeue();
                int cx = tuple.Item1, cy = tuple.Item2;
                for (int j = 0; j < 4; j++) {
                    int nx = cx + dirs[j][0];
                    int ny = cy + dirs[j][1];
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                            continue;
                        }
                        queue.Enqueue(new Tuple<int, int>(nx, ny));
                        fireTime[nx][ny] = time;
                    }
                }
            }
            time++;
        }
    }

    public bool Check(int[][] fireTime, int[][] grid, int stayTime) {
        int m = fireTime.Length;
        int n = fireTime[0].Length;
        bool[][] visit = new bool[m][];
        for (int i = 0; i < m; i++) {
            visit[i] = new bool[n];
        }
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
        queue.Enqueue(new Tuple<int, int, int>(0, 0, stayTime));
        visit[0][0] = true;

        while (queue.Count > 0) {
            Tuple<int, int, int> tuple = queue.Dequeue();
            int cx = tuple.Item1, cy = tuple.Item2, time = tuple.Item3;
            for (int i = 0; i < 4; i++) {
                int nx = cx + dirs[i][0];
                int ny = cy + dirs[i][1];
                if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                    if (visit[nx][ny] || grid[nx][ny] == 2) {
                        continue;
                    }
                    /* 到达安全屋 */
                    if (nx == m - 1 && ny == n - 1) {
                        return fireTime[nx][ny] >= time + 1;
                    }
                    /* 火未到达当前位置 */
                    if (fireTime[nx][ny] > time + 1) {
                        queue.Enqueue(new Tuple<int, int, int>(nx, ny, time + 1));
                        visit[nx][ny] = true;
                    }
                }
            }
        }
        return false;
    }
}
```

```c
const int dirs[4][2] = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
const int INF = 1e9;

void bfs(const int **grid, int **fireTime, int m, int n) {
    int q[m * n][2];
    int head = 0, tail = 0;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (grid[i][j] == 1) {
                q[tail][0] = i;
                q[tail][1] = j;
                tail++;
                fireTime[i][j] = 0;
            }
        }
    }

    int time = 1;
    while (head != tail) {
        int sz = tail - head;
        for (int i = 0; i < sz; i++) {
            int cx = q[head][0];
            int cy = q[head][1];
            head++;
            for (int j = 0; j < 4; j++) {
                int nx = cx + dirs[j][0];
                int ny = cy + dirs[j][1];
                if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                    if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                        continue;
                    }
                    q[tail][0] = nx;
                    q[tail][1] = ny;
                    tail++;
                    fireTime[nx][ny] = time;
                }
            }
        }
        time++;
    }
}

bool check(const int **fireTime, const int **grid, int m, int n, int stayTime) {
    bool visit[m][n];
    int q[m * n][3];
    int head = 0, tail = 0;

    memset(visit, 0, sizeof(visit));
    q[tail][0] = 0;
    q[tail][1] = 0;
    q[tail][2] = stayTime;
    tail++;
    visit[0][0] = true;

    while (head != tail) {
        int cx = q[head][0];
        int cy = q[head][1];
        int time = q[head][2];
        head++;
        for (int i = 0; i < 4; i++) {
            int nx = cx + dirs[i][0];
            int ny = cy + dirs[i][1];
            if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                if (visit[nx][ny] || grid[nx][ny] == 2) {
                    continue;
                }
                /* 到达安全屋 */
                if (nx == m - 1 && ny == n - 1) {
                    return fireTime[nx][ny] >= time + 1;
                }
                /* 火未到达当前位置 */
                if (fireTime[nx][ny] < 0 || fireTime[nx][ny] > time + 1) {
                    q[tail][0] = nx;
                    q[tail][1] = ny;
                    q[tail][2] = time + 1;
                    tail++;
                    visit[nx][ny] = true;
                }
            }
        }
    }
    return false;
}

int maximumMinutes(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int **fireTime = (int **)malloc(sizeof(int *) * m);
    for (int i = 0; i < m; i++) {
        fireTime[i] = (int *)calloc(n, sizeof(int));
        for (int j = 0; j < n; j++) {
            fireTime[i][j] = INF;
        }
    }

    /* 通过 bfs 求出每个格子着火的时间 */
    bfs(grid, fireTime, m, n);
    /* 二分查找找到最大停留时间 */
    int ans = -1;
    int low = 0, high = m * n;
    while (low <= high) {
        int mid = low + (high - low) / 2;     
        if (check(fireTime, grid, m, n, mid)) {
            ans = mid;
            low = mid + 1;
        } else {
            high = mid - 1;
        }
    }
    for (int i = 0; i < m; i++) {
        free(fireTime[i]);
    }
    free(fireTime);
    return ans >= m * n ? 1e9 : ans;
}
```

```python
class Solution:
    def maximumMinutes(self, grid: List[List[int]]) -> int:
        def bfs():
            m, n = len(grid), len(grid[0])
            q = []
            for i in range(m):
                for j in range(n):
                    if grid[i][j] == 1:
                        q.append((i, j))
                        fireTime[i][j] = 0
            
            time = 1
            while len(q) > 0:
                tmp = q
                q = []
                for cx, cy in tmp:
                    for nx, ny in (cx, cy - 1), (cx, cy + 1), (cx - 1, cy), (cx + 1, cy):
                        if nx >= 0 and ny >= 0 and nx < m and ny < n:
                            if grid[nx][ny] == 2 or fireTime[nx][ny] != inf:
                                continue
                            q.append((nx, ny))
                            fireTime[nx][ny] = time
                time += 1

        def check(stayTime):
            print(stayTime)
            m, n = len(grid), len(grid[0])
            visit = set((0, 0))
            q = []
            q.append((0, 0, stayTime))
            while len(q) > 0:
                tmp = q
                q = []

                for cx, cy, time in tmp:
                    for nx, ny in (cx, cy - 1), (cx, cy + 1), (cx - 1, cy), (cx + 1, cy):
                        if nx >= 0 and ny >= 0 and nx < m and ny < n:
                            if (nx, ny) in visit or grid[nx][ny] == 2:
                                continue
                            # 到达安全屋
                            if nx == m - 1 and ny == n - 1:
                                return fireTime[nx][ny] >= time + 1
                            # 火未到达当前位置 
                            if fireTime[nx][ny] > time + 1:
                                q.append((nx, ny, time + 1))
                                visit.add((nx, ny))
            return False

        m, n = len(grid), len(grid[0])
        fireTime = [[inf] * n for _ in range(m)]
        # 通过 bfs 求出每个格子着火的时间
        bfs()
        # 二分查找找到最大停留时间
        ans = -1
        low, high = 0, m * n
        while low <= high:
            mid = low + (high - low) // 2
            if check(mid):
                ans = mid
                low = mid + 1
            else:
                high = mid - 1
        return ans if ans < m * n else 10**9
```

```go
var dirs = [][]int{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}
var INF int = 1e9
func maximumMinutes(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    fireTime := make([][]int, m)
    for i := 0; i < m; i++ {
        fireTime[i] = make([]int, n)
        for j := 0; j < n; j++ {
            fireTime[i][j] = INF
        }
    }

    bfs := func() {
        q := [][]int{}
        for i := 0; i < m; i++ {
            for j := 0; j < n; j++ {
                if grid[i][j] == 1 {
                    q = append(q, []int{i, j})
                    fireTime[i][j] = 0
                }
            }
        }
        
        time := 1
        for len(q) > 0 {
            tmp := q
            q = [][]int{}
            for _, p := range tmp {
                cx, cy := p[0], p[1]
                for _, d := range dirs {
                    nx, ny := cx + d[0], cy + d[1]
                    if nx >= 0 && ny >= 0 && nx < m && ny < n {
                        if grid[nx][ny] == 2 || fireTime[nx][ny] != INF {
                                continue
                        }
                        q = append(q, []int{nx, ny})
                        fireTime[nx][ny] = time 
                    }
                }
            }
            time += 1
        }
    }

    /* 通过 bfs 求出每个格子着火的时间 */
    bfs()
    /* 二分查找找到最大停留时间 */
    check := func(stayTime int) bool {
        visit := make([][]bool, m)
        for i := 0; i < m; i++ {
            visit[i] = make([]bool, n)
        }
        q := [][]int{}
        q = append(q, []int{0, 0, stayTime})
        for len(q) > 0 {
            tmp := q
            q = [][]int{}

            for _, p := range tmp {
                cx, cy, time := p[0], p[1], p[2]
                for _, d := range dirs {
                    nx, ny := cx + d[0], cy + d[1]
                    if nx >= 0 && ny >= 0 && nx < m && ny < n {
                        if visit[nx][ny] || grid[nx][ny] == 2 {
                            continue
                        }
                        /* 到达安全屋 */
                        if nx == m - 1 && ny == n - 1 {
                            return fireTime[nx][ny] >= time + 1
                        }
                        /* 火未到达当前位置 */
                        if fireTime[nx][ny] > time + 1 {
                            q = append(q, []int{nx, ny, time + 1})
                            visit[nx][ny] = true
                        }
                    }
                }
            }
        }
        return false   
    }

    ans := -1
    low, high := 0, m * n
    for low <= high {
        mid := low + (high - low) / 2
        if check(mid) {
            ans = mid
            low = mid + 1
        } else {
            high = mid - 1
        }
    }
    if ans >= m * n {
        return 1e9
    }
    return ans
}
```

```javascript
const dirs = [[0, -1], [0, 1], [1, 0], [-1, 0]];

var maximumMinutes = function(grid) {
    const m = grid.length;
    const n = grid[0].length;
    const INF = 1e9;
    const fireTime = new Array(m).fill(0).map(() => new Array(n).fill(INF));

    const bfs = function() {
        let q = [];
        for (let i = 0; i < m; i++) {
            for (let j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    q.push([i, j])
                    fireTime[i][j] = 0
                }
            }
        }
       
        let time = 1;
        while (q.length > 0) {
            const tmp = q;
            q = [];
            for (const [cx, cy] of tmp) {
                for (const [i, j] of dirs) {
                    const nx = cx + i;
                    const ny = cy + j;
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                            continue;
                        }
                        q.push([nx, ny]);
                        fireTime[nx][ny] = time;
                    }
                }
            }
            time++;
        }
    };

    const check = function(stayTime) {
        visit = new Array(m).fill(0).map(() => new Array(n).fill(false));
        let q = [[0, 0, stayTime]]
        while (q.length > 0) {
            const tmp = q
            q = []
            for (const [cx, cy, time] of tmp) {
                for (const [i, j] of dirs) {
                    const nx = cx + i;
                    const ny = cy + j;
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (visit[nx][ny] || grid[nx][ny] == 2) {
                            continue;
                        }
                        /* 到达安全屋 */
                        if (nx == m - 1 && ny == n - 1) {
                            return fireTime[nx][ny] >= time + 1;
                        }
                        /* 火未到达当前位置 */
                        if (fireTime[nx][ny] > time + 1) {
                            q.push([nx, ny, time + 1]);
                            visit[nx][ny] = true;
                        }
                    }
                }
            }
        }
        return false;
    };

    /* 通过 bfs 求出每个格子着火的时间 */
    bfs();
    /* 二分查找找到最大停留时间 */
    let ans = -1;
    let low = 0, high = m * n;
    while (low <= high) {
        const mid = low + Math.floor((high - low) / 2);
        if (check(mid)) {
            ans = mid;
            low = mid + 1;
        } else {
            high = mid - 1;
        }
    }
    return ans >= m * n ? 1e9 : ans;
};
```

**复杂度分析**

-   时间复杂度：$O(mn\log(mn))$，其中 $m,n$ 表示二维数组的行数与列数。利用广度优先搜索求每个位置着火的最短时间需要的时间复杂度为 $O(mn)$，然后利用二分查找找到最大的等待时间，二分查找的上限为 $mn$，每次检测终点是否可达需要的时间为 $O(mn)$，总的时间复杂度为 $O(mn + mn\log(mn) = O(mn\log(mn))$。
-   空间复杂度：$O(mn)$，其中 $m,n$ 表示二维数组的行数与列数。需要记录每个位置着火的最短时间以及每个位置的访问状态，需要的空间为 $O(mn)$。

#### 方法二：多次广度优先搜索

**思路与算法**

方法一中已经求出了火到达每个格子的最短时间，则此时我们可以思考在什么情况下可以在火到达该格子之前从起点 $(0,0)$ 到达该格子。对于任意位置的格子 $(i,j)$，已知火到达该格子的时间为 $fireTime[i][j]$，在不考虑安全屋格子的情况下，此时我们必须在 $fireTime[i][j]$ 之前到达该格子，假设从起点 $(0,0)$ 到达格子 $(i,j)$ 的最短时间为 $arriveTime[i][j]$，则此时可以知道：

-   如果 $arriveTime[i][j] \ge fireTime[i][j]$，则此时无论如何到达该格子时，该格子一定已经着火，无法通行；
-   如果 $arriveTime[i][j] < fireTime[i][j]$，则此时可以在该格子着火之前到达，可以通行。假设我们在起点停留了 $stayTime$ 分钟，则此时到达格子 $(i,j)$ 的最短时间则变为 $arriveTime[i][j] + stayTime$，此时 $stayTime + arriveTime[i][j] < fireTime[i][j]$，可以知道 $stayTime < fireTime[i][j] - arriveTime[i][j]$。

根据上述分析，似乎我们只需求出到达安全屋格子 $(m-1,n-1)$ 的最小时间 $arriveTime[m-1][n-1]$，即可求出在起点的最大停留时间 $stayTime$，由于人与火可以同时到达安全屋，则此时 $stayTime = fireTime[m-1][n-1] - arriveTime[m-1][n-1]$。但存在特殊情况需要具体分析：

-   安全屋不可到达时，此时我们直接返回 $-1$；
-   如果安全屋可达，且此时安全屋格子着火的时间为 $\infty$，则表明安全屋永远不会着火，此时不管起点呆多久安全屋都不会着火，返回 $10^9$；
-   安全屋可达，且安全屋格子在有限时间内会着火，此时求出的最大停留时间为 $fireTime[m-1][n-1] - arriveTime[m-1][n-1]$。由于到达安全屋格子时，火也可以同时到达安全屋，但在从起点到终点的其他格子中，人与火不能同时到达该格子，因此我们需要检测当停留 $fireTime[m-1][n-1] - arriveTime[m-1][n-1]$ 时，除终点外其他格子是可以通过，如果满足可以通过则返回 $fireTime[m-1][n-1] - arriveTime[m-1][n-1]$，否则返回 $fireTime[m-1][n-1] - arriveTime[m-1][n-1] - 1$。

**代码**

```c++
class Solution {
public:
    constexpr static int dirs[4][2] = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
    constexpr static int INF = 1e9;
    int maximumMinutes(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> fireTime(m, vector<int>(n, INF));
        /* 通过 bfs 求出每个格子着火的时间 */
        bfs(grid, fireTime);
        /* 找到起点到终点的最短时间 */
        int arriveTime = getArriveTime(grid, fireTime, 0);
        /* 安全屋不可达 */
        if (arriveTime < 0) {
            return -1;
        }
        /* 火不会到达安全屋 */
        if (fireTime[m - 1][n - 1] == INF) {
            return 1e9;
        }
        int ans = fireTime[m - 1][n - 1] - arriveTime;
        return getArriveTime(grid, fireTime, ans) >= 0 ? ans : (ans - 1);
    }    

    void bfs(vector<vector<int>> &grid, vector<vector<int>> &fireTime) {
        int m = grid.size();
        int n = grid[0].size();
        queue<pair<int, int>> q;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    q.emplace(i, j);
                    fireTime[i][j] = 0;
                }
            }
        }

        int time = 1;
        while (!q.empty()) {
            int sz = q.size();
            for (int i = 0; i < sz; i++) {
                auto [cx, cy] = q.front();
                q.pop();
                for (int j = 0; j < 4; j++) {
                    int nx = cx + dirs[j][0];
                    int ny = cy + dirs[j][1];
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                            continue;
                        }
                        q.emplace(nx, ny);
                        fireTime[nx][ny] = time;
                    }
                }
            }
            time++;
        }
    }

    int getArriveTime(vector<vector<int>> &grid, vector<vector<int>> &fireTime, int stayTime) {
        int m = fireTime.size();
        int n = fireTime[0].size();
        queue<tuple<int, int, int>> q;
        vector<vector<bool>> visit(m, vector<bool>(n, false));
        q.emplace(0, 0, stayTime);
        visit[0][0] = true;
        while (!q.empty()) {
            auto [cx, cy, time] = q.front();
            q.pop();
            for (int j = 0; j < 4; j++) {
                int nx = cx + dirs[j][0];
                int ny = cy + dirs[j][1];
                if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                    if (grid[nx][ny] == 2 || visit[nx][ny]) {
                        continue;
                    }
                    if (nx == m - 1 && ny == n - 1) {
                        return time + 1;
                    }
                    if (fireTime[nx][ny] > time + 1) {
                        visit[nx][ny] = true;
                        q.emplace(nx, ny, time + 1);
                    }
                }
            }
        }
        return -1;
    }
};
```

```java
class Solution {
    static final int INF = 1000000000;
    static int[][] dirs = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

    public int maximumMinutes(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[][] fireTime = new int[m][n];
        for (int i = 0; i < m; i++) {
            Arrays.fill(fireTime[i], INF);
        }
        /* 通过 bfs 求出每个格子着火的时间 */
        bfs(grid, fireTime);
        /* 找到起点到终点的最短时间 */
        int arriveTime = getArriveTime(grid, fireTime, 0);
        /* 安全屋不可达 */
        if (arriveTime < 0) {
            return -1;
        }
        /* 火不会到达安全屋 */
        if (fireTime[m - 1][n - 1] == INF) {
            return INF;
        }
        int ans = fireTime[m - 1][n - 1] - arriveTime;
        return getArriveTime(grid, fireTime, ans) >= 0 ? ans : (ans - 1);
    }

    public void bfs(int[][] grid, int[][] fireTime) {
        int m = grid.length;
        int n = grid[0].length;
        Queue<int[]> queue = new ArrayDeque<int[]>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    queue.offer(new int[]{i, j});
                    fireTime[i][j] = 0;
                }
            }
        }

        int time = 1;
        while (!queue.isEmpty()) {
            int sz = queue.size();
            for (int i = 0; i < sz; i++) {
                int[] arr = queue.poll();
                int cx = arr[0], cy = arr[1];
                for (int j = 0; j < 4; j++) {
                    int nx = cx + dirs[j][0];
                    int ny = cy + dirs[j][1];
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                            continue;
                        }
                        queue.offer(new int[]{nx, ny});
                        fireTime[nx][ny] = time;
                    }
                }
            }
            time++;
        }
    }

    public int getArriveTime(int[][] grid, int[][] fireTime, int stayTime) {
        int m = fireTime.length;
        int n = fireTime[0].length;
        boolean[][] visit = new boolean[m][n];
        Queue<int[]> queue = new ArrayDeque<int[]>();
        queue.offer(new int[]{0, 0, stayTime});
        visit[0][0] = true;

        while (!queue.isEmpty()) {
            int[] arr = queue.poll();
            int cx = arr[0], cy = arr[1], time = arr[2];
            for (int j = 0; j < 4; j++) {
                int nx = cx + dirs[j][0];
                int ny = cy + dirs[j][1];
                if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                    if (grid[nx][ny] == 2 || visit[nx][ny]) {
                        continue;
                    }
                    if (nx == m - 1 && ny == n - 1) {
                        return time + 1;
                    }
                    if (fireTime[nx][ny] > time + 1) {
                        visit[nx][ny] = true;
                        queue.offer(new int[]{nx, ny, time + 1});
                    }
                }
            }
        }
        return -1;
    }
}
```

```csharp
public class Solution {
    const int INF = 1000000000;
    static int[][] dirs = {new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};

    public int MaximumMinutes(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] fireTime = new int[m][];
        for (int i = 0; i < m; i++) {
            fireTime[i] = new int[n];
            Array.Fill(fireTime[i], INF);
        }
        /* 通过 BFS 求出每个格子着火的时间 */
        BFS(grid, fireTime);
        /* 找到起点到终点的最短时间 */
        int arriveTime = GetArriveTime(grid, fireTime, 0);
        /* 安全屋不可达 */
        if (arriveTime < 0) {
            return -1;
        }
        /* 火不会到达安全屋 */
        if (fireTime[m - 1][n - 1] == INF) {
            return INF;
        }
        int ans = fireTime[m - 1][n - 1] - arriveTime;
        return GetArriveTime(grid, fireTime, ans) >= 0 ? ans : (ans - 1);
    }

    public void BFS(int[][] grid, int[][] fireTime) {
        int m = grid.Length;
        int n = grid[0].Length;
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    queue.Enqueue(new Tuple<int, int>(i, j));
                    fireTime[i][j] = 0;
                }
            }
        }

        int time = 1;
        while (queue.Count > 0) {
            int sz = queue.Count;
            for (int i = 0; i < sz; i++) {
                Tuple<int, int> tuple = queue.Dequeue();
                int cx = tuple.Item1, cy = tuple.Item2;
                for (int j = 0; j < 4; j++) {
                    int nx = cx + dirs[j][0];
                    int ny = cy + dirs[j][1];
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                            continue;
                        }
                        queue.Enqueue(new Tuple<int, int>(nx, ny));
                        fireTime[nx][ny] = time;
                    }
                }
            }
            time++;
        }
    }

    public int GetArriveTime(int[][] grid, int[][] fireTime, int stayTime) {
        int m = fireTime.Length;
        int n = fireTime[0].Length;
        bool[][] visit = new bool[m][];
        for (int i = 0; i < m; i++) {
            visit[i] = new bool[n];
        }
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
        queue.Enqueue(new Tuple<int, int, int>(0, 0, stayTime));
        visit[0][0] = true;

        while (queue.Count > 0) {
            Tuple<int, int, int> tuple = queue.Dequeue();
            int cx = tuple.Item1, cy = tuple.Item2, time = tuple.Item3;
            for (int j = 0; j < 4; j++) {
                int nx = cx + dirs[j][0];
                int ny = cy + dirs[j][1];
                if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                    if (grid[nx][ny] == 2 || visit[nx][ny]) {
                        continue;
                    }
                    if (nx == m - 1 && ny == n - 1) {
                        return time + 1;
                    }
                    if (fireTime[nx][ny] > time + 1) {
                        visit[nx][ny] = true;
                        queue.Enqueue(new Tuple<int, int, int>(nx, ny, time + 1));
                    }
                }
            }
        }
        return -1;
    }
}
```

```c
const int dirs[4][2] = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
const int INF = 1e9;

void bfs(const int **grid, int **fireTime, int m, int n) {
    int q[m * n][2];
    int head = 0, tail = 0;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (grid[i][j] == 1) {
                q[tail][0] = i;
                q[tail][1] = j;
                tail++;
                fireTime[i][j] = 0;
            }
        }
    }

    int time = 1;
    while (head != tail) {
        int sz = tail - head;
        for (int i = 0; i < sz; i++) {
            int cx = q[head][0];
            int cy = q[head][1];
            head++;
            for (int j = 0; j < 4; j++) {
                int nx = cx + dirs[j][0];
                int ny = cy + dirs[j][1];
                if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                    if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                        continue;
                    }
                    q[tail][0] = nx;
                    q[tail][1] = ny;
                    tail++;
                    fireTime[nx][ny] = time;
                }
            }
        }
        time++;
    }
}

int getArriveTime(const int **grid, const int **fireTime, int m, int n, int stayTime) {
    bool visit[m][n];
    int q[m * n][3];
    int head = 0, tail = 0;

    memset(visit, 0, sizeof(visit));
    q[tail][0] = 0;
    q[tail][1] = 0;
    q[tail][2] = stayTime;
    tail++;
    visit[0][0] = true;

    while (head != tail) {
        int cx = q[head][0];
        int cy = q[head][1];
        int time = q[head][2];
        head++;
        for (int i = 0; i < 4; i++) {
            int nx = cx + dirs[i][0];
            int ny = cy + dirs[i][1];
            if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                if (visit[nx][ny] || grid[nx][ny] == 2) {
                    continue;
                }
                /* 到达安全屋 */
                if (nx == m - 1 && ny == n - 1) {
                    return time + 1;
                }
                /* 火未到达当前位置 */
                if (fireTime[nx][ny] > time + 1) {
                    q[tail][0] = nx;
                    q[tail][1] = ny;
                    q[tail][2] = time + 1;
                    tail++;
                    visit[nx][ny] = true;
                }
            }
        }
    }
    return -1;
}

int maximumMinutes(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int **fireTime = (int **)malloc(sizeof(int *) * m);
    for (int i = 0; i < m; i++) {
        fireTime[i] = (int *)calloc(n, sizeof(int));
        for (int j = 0; j < n; j++) {
            fireTime[i][j] = INF;
        }
    }

    /* 通过 bfs 求出每个格子着火的时间 */
    bfs(grid, fireTime, m, n);
    /* 找到起点到每个格子的最短路径 */
    int arriveTime = getArriveTime(grid, fireTime, m, n, 0);
    /* 安全屋不可达 */
    if (arriveTime < 0) {
        return -1;
    }
    /* 火不会到达安全屋 */
    if (fireTime[m - 1][n - 1] == INF) {
        return 1e9;
    }
    int ans = fireTime[m - 1][n - 1] - arriveTime;
    if (getArriveTime(grid, fireTime, m, n, ans) < 0) {
        ans--;
    }
    for (int i = 0; i < m; i++) {
        free(fireTime[i]);
    }
    free(fireTime);
    return ans;
}
```

```python
class Solution:
    def maximumMinutes(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        fireTime = [[inf] * n for _ in range(m)]

        def bfs():
            q = []
            for i in range(m):
                for j in range(n):
                    if grid[i][j] == 1:
                        q.append((i, j))
                        fireTime[i][j] = 0
            
            time = 1
            while len(q) > 0:
                tmp = q
                q = []
                for cx, cy in tmp:
                    for nx, ny in (cx, cy - 1), (cx, cy + 1), (cx - 1, cy), (cx + 1, cy):
                        if nx >= 0 and ny >= 0 and nx < m and ny < n:
                            if grid[nx][ny] == 2 or fireTime[nx][ny] != inf:
                                continue
                            q.append((nx, ny))
                            fireTime[nx][ny] = time
                time += 1

        def getArriveTime(stayTime):
            visit = set((0, 0))
            q = []
            q.append((0, 0, stayTime))
            while len(q) > 0:
                tmp = q
                q = []

                for cx, cy, time in tmp:
                    if cx == m - 1 and cy == n - 1:
                        return True
                    for nx, ny in (cx, cy - 1), (cx, cy + 1), (cx - 1, cy), (cx + 1, cy):
                        if nx >= 0 and ny >= 0 and nx < m and ny < n:
                            if (nx, ny) in visit or grid[nx][ny] == 2:
                                continue
                            # 到达安全屋
                            if nx == m - 1 and ny == n - 1:
                                return  time + 1
                            # 火未到达当前位置 
                            if fireTime[nx][ny] > time + 1:
                                q.append((nx, ny, time + 1))
                                visit.add((nx, ny))
            return -1

        # 通过 bfs 求出每个格子着火的时间
        bfs()
        # 找到起点到每个格子的最短路径
        arriveTime = getArriveTime(0)
        # 安全屋不可达
        if arriveTime < 0:
            return -1
        # 火不会到达安全屋 
        if fireTime[m - 1][n - 1] == inf:
            return 10**9
        ans = fireTime[m - 1][n - 1] - arriveTime
        return ans if getArriveTime(ans) >= 0 else ans - 1
```

```go
var dirs = [][]int{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}
var INF int = 1e9

func maximumMinutes(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    fireTime := make([][]int, m)
    for i := 0; i < m; i++ {
        fireTime[i] = make([]int, n)
        for j := 0; j < n; j++ {
            fireTime[i][j] = INF
        }
    }

    bfs := func() {
        q := [][]int{}
        for i := 0; i < m; i++ {
            for j := 0; j < n; j++ {
                if grid[i][j] == 1 {
                    q = append(q, []int{i, j})
                    fireTime[i][j] = 0
                }
            }
        }
        
        time := 1
        for len(q) > 0 {
            tmp := q
            q = [][]int{}
            for _, p := range tmp {
                cx, cy := p[0], p[1]
                for _, d := range dirs {
                    nx, ny := cx + d[0], cy + d[1]
                    if nx >= 0 && ny >= 0 && nx < m && ny < n {
                        if grid[nx][ny] == 2 || fireTime[nx][ny] != INF {
                                continue
                        }
                        q = append(q, []int{nx, ny})
                        fireTime[nx][ny] = time 
                    }
                }
            }
            time += 1
        }
    }

    getArriveTime := func(stayTime int) int {
        visit := make([][]bool, m)
        for i := 0; i < m; i++ {
            visit[i] = make([]bool, n)
        }
        q := [][]int{}
        q = append(q, []int{0, 0, stayTime})
        for len(q) > 0 {
            tmp := q
            q = [][]int{}

            for _, p := range tmp {
                cx, cy, time := p[0], p[1], p[2]
                for _, d := range dirs {
                    nx, ny := cx + d[0], cy + d[1]
                    if nx >= 0 && ny >= 0 && nx < m && ny < n {
                        if visit[nx][ny] || grid[nx][ny] == 2 {
                            continue
                        }
                        /* 到达安全屋 */
                        if nx == m - 1 && ny == n - 1 {
                            return time + 1
                        }
                        /* 火未到达当前位置 */
                        if fireTime[nx][ny] > time + 1 {
                            q = append(q, []int{nx, ny, time + 1})
                            visit[nx][ny] = true
                        }
                    }
                }
            }
        }
        return -1   
    }

    /* 通过 bfs 求出每个格子着火的时间 */
    bfs()
    /* 找到起点到终点的最短路径 */
    arriveTime := getArriveTime(0)
    /* 安全屋不可达 */
    if arriveTime < 0 {
        return -1
    }
    /* 火不会到达安全屋 */
    if fireTime[m - 1][n - 1] == INF {
        return 1e9
    }
    ans := fireTime[m - 1][n - 1] - arriveTime
    if getArriveTime(ans) >= 0 {
        return ans
    }
    return ans - 1
}
```

```javascript
const dirs = [[0, -1], [0, 1], [1, 0], [-1, 0]];
const INF = 1e9;

var maximumMinutes = function(grid) {
    const m = grid.length;
    const n = grid[0].length;
    const fireTime = new Array(m).fill(0).map(() => new Array(n).fill(INF));

    const bfs = function() {
        let q = [];
        for (let i = 0; i < m; i++) {
            for (let j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    q.push([i, j])
                    fireTime[i][j] = 0
                }
            }
        }
       
        let time = 1;
        while (q.length > 0) {
            const tmp = q;
            q = [];
            for (const [cx, cy] of tmp) {
                for (const [i, j] of dirs) {
                    const nx = cx + i;
                    const ny = cy + j;
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (grid[nx][ny] == 2 || fireTime[nx][ny] != INF) {
                            continue;
                        }
                        q.push([nx, ny]);
                        fireTime[nx][ny] = time;
                    }
                }
            }
            time++;
        }
    };

    const getArriveTime = function(stayTime) {
        visit = new Array(m).fill(0).map(() => new Array(n).fill(false));
        let q = [[0, 0, stayTime]]
        while (q.length > 0) {
            const tmp = q
            q = []
            for (const [cx, cy, time] of tmp) {
                for (const [i, j] of dirs) {
                    const nx = cx + i;
                    const ny = cy + j;
                    if (nx >= 0 && ny >= 0 && nx < m && ny < n) {
                        if (visit[nx][ny] || grid[nx][ny] == 2) {
                            continue;
                        }
                        /* 到达安全屋 */
                        if (nx == m - 1 && ny == n - 1) {
                            return time + 1;
                        }
                        /* 火未到达当前位置 */
                        if (fireTime[nx][ny] > time + 1) {
                            q.push([nx, ny, time + 1]);
                            visit[nx][ny] = true;
                        }
                    }
                }
            }
        }
        return -1;
    };

    /* 通过 bfs 求出每个格子着火的时间 */
    bfs();
    /* 找到起点到每个格子的最短路径 */
    const arriveTime = getArriveTime(0);
    /* 安全屋不可达 */
    if (arriveTime < 0) {
        return -1;
    }
    /* 火不会到达安全屋 */
    if (fireTime[m - 1][n - 1] == INF) {
        return 1e9;
    }
    let ans = fireTime[m - 1][n - 1] - arriveTime;
    console.log(ans);
    return getArriveTime(ans) >= 0 ? ans : (ans - 1);
};
```

**复杂度分析**

-   时间复杂度：$O(mn)$，其中 $m,n$ 表示二维数组的行数与列数。一共有 $mn$ 个格子，一共需要 333 次广度优先搜索遍历每个格子，每次遍历的时间为 $O(mn)$，因此总的时间复杂度为 $O(mn)$。
-   空间复杂度：$O(mn)$，其中 $m,n$ 表示二维数组的行数与列数。需要记录每个位置着火的最短时间，需要的空间为 $O(mn)$。
