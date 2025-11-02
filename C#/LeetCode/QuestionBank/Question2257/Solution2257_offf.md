### [统计网格图中没有被保卫的格子数](https://leetcode.cn/problems/count-unguarded-cells-in-the-grid/solutions/1486086/tong-ji-wang-ge-tu-zhong-mei-you-bei-bao-ba6m/)

#### 方法一：广度优先搜索 + 存储每个格子的状态

**思路与算法**

为了方便操作，我们可以用二维数组 $grid$ 来表示网格图的状态。其中，警卫对应的状态值为 $-1$，墙对应的状态值为 $-2$，未被保卫的格子对应的状态值为 $0$，被保卫格子对应的状态值为正整数。二维数组的初始值均为 $0$，随后我们遍历 $guards$ 和 $walls$ 数组对应更新网格图。

在恢复了网格图后，我们可以使用广度优先搜索维护每个格子的状态。由于视线是向特定方向的，因此在广度优先搜索的过程中，除了要维护格子的横纵坐标，还要维护当前的**视线方向**。我们用 $(i,j,k)$ 来表示广度优先搜索的状态，其中 $(i,j)$ 代表当前点的横纵坐标，$k$ 为 $[0,3]$ 闭区间内的整数，分别代表右、上、左、下的视线方向。同样地，为了防止每个非警卫或墙的点被重复或遗漏，我们用 $4$ 个二进制位组成的正整数来表示该格子的状态，其中**从低到高的**第 $k$ 位为 $1$ 代表有指向第 $k$ 个方向的视线经过该点，反之则代表没有。

我们用队列 $q$ 来进行广度优先搜索。首先，对于每个警卫点 $(i,j)$，由于警卫可以看到四个方向，因此我们需要将 $k$ 为 $[0,3]$ 闭区间内对应的**四种状态** $(i,j,k)$ 全部加进队列。

当遍历到 $(x,y,k)$ 时，我们首先计算沿着该视线方向的**下一个**坐标 $(n_x,n_y)$，如果该坐标不合法或为墙或警卫，则我们直接跳过该坐标；对于余下的情况，我们需要检查该坐标对应状态 $grid[i][j]$ 中从低到高的第 $k$ 位的数值。此时有两种情况：

- 第 $k$ 位为 $1$，则说明该坐标及视线方向对应的状态 $(n_x,n_y,k)$ 已被遍历过，我们直接跳过即可；
- 第 $k$ 位为 $0$，则说明该坐标及视线方向对应的状态 $(n_x,n_y,k)$ 未被遍历过，我们需要将该位置为 $1$，并将该状态加入队列 $q$ 的尾部。

最终，当广度优先搜索完成时，一个格子未被保卫**当且仅当** $grid$ 中的对应状态值为 $0$。我们只需要遍历 $grid$，维护数值为 $0$ 的格子数量，并返回即可。

**代码**

```C++
class Solution {
public:
    int countUnguarded(int m, int n, vector<vector<int>>& guards, vector<vector<int>>& walls) {
        vector<vector<int>> grid(m, vector<int> (n));   // 网格状态数组
        queue<tuple<int, int, int>> q;   // 广度优先搜索队列
        // 每个方向的单位向量
        vector<int> dx = {1, 0, -1, 0};
        vector<int> dy = {0, 1, 0, -1};
        for (const auto& guard: guards) {
            grid[guard[0]][guard[1]] = -1;
            for (int k = 0; k < 4; ++k) {
                // 将四个方向视线对应的状态均添加进搜索队列中
                q.emplace(guard[0], guard[1], k);
            }
        }
        for (const auto& wall: walls) {
            grid[wall[0]][wall[1]] = -2;
        }
        while (!q.empty()) {
            auto [x, y, k] = q.front();
            q.pop();
            int nx = x + dx[k];
            int ny = y + dy[k];
            if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] >= 0) {
                // 沿着视线方向的下一个坐标合法，且不为警卫或墙
                if ((grid[nx][ny] & (1 << k)) == 0) {
                    // 对应状态未遍历过
                    grid[nx][ny] |= (1 << k);
                    q.emplace(nx, ny, k);
                }
            }
        }
        int res = 0;   // 未被保护格子数目
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    ++res;
                }
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def countUnguarded(self, m: int, n: int, guards: List[List[int]], walls: List[List[int]]) -> int:
        grid = [[0] * n for  _ in range(m)]   # 网格状态数组
        q = deque([])   # 广度优先搜索队列
        # 每个方向的单位向量
        dx = [1, 0, -1, 0]
        dy = [0, 1, 0, -1]
        for i, j in guards:
            grid[i][j] = -1
            for k in range(4):
                # 将四个方向视线对应的状态均添加进搜索队列中
                q.append((i, j, k))
        for i, j in walls:
            grid[i][j] = -2
        while q:
            x, y, k = q.popleft()
            nx, ny = x + dx[k], y + dy[k]
            if 0 <= nx < m and 0 <= ny < n and grid[nx][ny] >= 0:
                # 沿着视线方向的下一个坐标合法，且不为警卫或墙
                if grid[nx][ny] & (1 << k) == 0:
                    # 对应状态未遍历过
                    grid[nx][ny] |= (1 << k)
                    q.append((nx, ny, k))
        res = 0   # 未被保护格子数目
        for i in range(m):
            for j in range(n):
                if grid[i][j] == 0:
                    res += 1
        return res
```

```Java
class Solution {
    public int countUnguarded(int m, int n, int[][] guards, int[][] walls) {
        int[][] grid = new int[m][n];   // 网格状态数组
        Queue<int[]> q = new LinkedList<>();   // 广度优先搜索队列
        // 每个方向的单位向量
        int[] dx = {1, 0, -1, 0};
        int[] dy = {0, 1, 0, -1};
        for (int[] guard : guards) {
            grid[guard[0]][guard[1]] = -1;
            for (int k = 0; k < 4; ++k) {
                // 将四个方向视线对应的状态均添加进搜索队列中
                q.offer(new int[]{guard[0], guard[1], k});
            }
        }
        for (int[] wall : walls) {
            grid[wall[0]][wall[1]] = -2;
        }
        while (!q.isEmpty()) {
            int[] curr = q.poll();
            int x = curr[0], y = curr[1], k = curr[2];
            int nx = x + dx[k];
            int ny = y + dy[k];
            if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] >= 0) {
                // 沿着视线方向的下一个坐标合法，且不为警卫或墙
                if ((grid[nx][ny] & (1 << k)) == 0) {
                    // 对应状态未遍历过
                    grid[nx][ny] |= (1 << k);
                    q.offer(new int[]{nx, ny, k});
                }
            }
        }
        int res = 0;   // 未被保护格子数目
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    ++res;
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls) {
        int[][] grid = new int[m][];   // 网格状态数组
        for (int i = 0; i < m; ++i) {
            grid[i] = new int[n];
        }
        Queue<Tuple<int, int, int>> q = new Queue<Tuple<int, int, int>>();   // 广度优先搜索队列
        // 每个方向的单位向量
        int[] dx = {1, 0, -1, 0};
        int[] dy = {0, 1, 0, -1};
        foreach (var guard in guards) {
            grid[guard[0]][guard[1]] = -1;
            for (int k = 0; k < 4; ++k) {
                // 将四个方向视线对应的状态均添加进搜索队列中
                q.Enqueue(Tuple.Create(guard[0], guard[1], k));
            }
        }
        foreach (var wall in walls) {
            grid[wall[0]][wall[1]] = -2;
        }
        while (q.Count > 0) {
            var curr = q.Dequeue();
            int x = curr.Item1, y = curr.Item2, k = curr.Item3;
            int nx = x + dx[k];
            int ny = y + dy[k];
            if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] >= 0) {
                // 沿着视线方向的下一个坐标合法，且不为警卫或墙
                if ((grid[nx][ny] & (1 << k)) == 0) {
                    // 对应状态未遍历过
                    grid[nx][ny] |= (1 << k);
                    q.Enqueue(Tuple.Create(nx, ny, k));
                }
            }
        }
        int res = 0;   // 未被保护格子数目
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    ++res;
                }
            }
        }
        return res;
    }
}
```

```Go
func countUnguarded(m int, n int, guards [][]int, walls [][]int) int {
    grid := make([][]int, m)   // 网格状态数组
    for i := range grid {
        grid[i] = make([]int, n)
    }
    q := [][3]int{}   // 广度优先搜索队列
    // 每个方向的单位向量
    dx := []int{1, 0, -1, 0}
    dy := []int{0, 1, 0, -1}
    for _, guard := range guards {
        grid[guard[0]][guard[1]] = -1
        for k := 0; k < 4; k++ {
            // 将四个方向视线对应的状态均添加进搜索队列中
            q = append(q, [3]int{guard[0], guard[1], k})
        }
    }
    for _, wall := range walls {
        grid[wall[0]][wall[1]] = -2
    }
    for len(q) > 0 {
        curr := q[0]
        q = q[1:]
        x, y, k := curr[0], curr[1], curr[2]
        nx := x + dx[k]
        ny := y + dy[k]
        if nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] >= 0 {
            // 沿着视线方向的下一个坐标合法，且不为警卫或墙
            if (grid[nx][ny] & (1 << k)) == 0 {
                // 对应状态未遍历过
                grid[nx][ny] |= (1 << k)
                q = append(q, [3]int{nx, ny, k})
            }
        }
    }
    res := 0   // 未被保护格子数目
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if grid[i][j] == 0 {
                res++
            }
        }
    }
    return res
}
```

```C
typedef struct {
    int x, y, k;
} Tuple;

int countUnguarded(int m, int n, int** guards, int guardsSize, int* guardsColSize, int** walls, int wallsSize, int* wallsColSize) {
    int** grid = (int**)malloc(m * sizeof(int*));   // 网格状态数组
    for (int i = 0; i < m; i++) {
        grid[i] = (int*)calloc(n, sizeof(int));
    }
    Tuple* q = (Tuple*)malloc(4 * m * n * sizeof(Tuple));   // 广度优先搜索队列
    int front = 0, rear = 0;
    // 每个方向的单位向量
    int dx[] = {1, 0, -1, 0};
    int dy[] = {0, 1, 0, -1};
    for (int i = 0; i < guardsSize; i++) {
        int x = guards[i][0], y = guards[i][1];
        grid[x][y] = -1;
        for (int k = 0; k < 4; k++) {
            // 将四个方向视线对应的状态均添加进搜索队列中
            q[rear++] = (Tuple){x, y, k};
        }
    }
    for (int i = 0; i < wallsSize; i++) {
        int x = walls[i][0], y = walls[i][1];
        grid[x][y] = -2;
    }
    while (front < rear) {
        Tuple curr = q[front++];
        int x = curr.x, y = curr.y, k = curr.k;
        int nx = x + dx[k];
        int ny = y + dy[k];
        if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] >= 0) {
            // 沿着视线方向的下一个坐标合法，且不为警卫或墙
            if ((grid[nx][ny] & (1 << k)) == 0) {
                // 对应状态未遍历过
                grid[nx][ny] |= (1 << k);
                q[rear++] = (Tuple){nx, ny, k};
            }
        }
    }
    int res = 0;   // 未被保护格子数目
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (grid[i][j] == 0) {
                res++;
            }
        }
    }
    for (int i = 0; i < m; i++) {
        free(grid[i]);
    }
    free(grid);
    free(q);
    return res;
}
```

```JavaScript
var countUnguarded = function(m, n, guards, walls) {
    let grid = new Array(m).fill().map(() => new Array(n).fill(0));   // 网格状态数组
    const q = new Queue();   // 广度优先搜索队列
    // 每个方向的单位向量
    const dx = [1, 0, -1, 0];
    const dy = [0, 1, 0, -1];
    for (let guard of guards) {
        grid[guard[0]][guard[1]] = -1;
        for (let k = 0; k < 4; ++k) {
            // 将四个方向视线对应的状态均添加进搜索队列中
            q.enqueue([guard[0], guard[1], k]);
        }
    }
    for (let wall of walls) {
        grid[wall[0]][wall[1]] = -2;
    }
    while (!q.isEmpty()) {
        let [x, y, k] = q.dequeue();
        let nx = x + dx[k];
        let ny = y + dy[k];
        if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] >= 0) {
            // 沿着视线方向的下一个坐标合法，且不为警卫或墙
            if ((grid[nx][ny] & (1 << k)) === 0) {
                // 对应状态未遍历过
                grid[nx][ny] |= (1 << k);
                q.enqueue([nx, ny, k]);
            }
        }
    }
    let res = 0;   // 未被保护格子数目
    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            if (grid[i][j] === 0) {
                ++res;
            }
        }
    }
    return res;
};
```

```TypeScript
function countUnguarded(m: number, n: number, guards: number[][], walls: number[][]): number {
    let grid: number[][] = new Array(m).fill(0).map(() => new Array(n).fill(0));   // 网格状态数组
    let q = new Queue<[number, number, number]>;   // 广度优先搜索队列
    // 每个方向的单位向量
    const dx = [1, 0, -1, 0];
    const dy = [0, 1, 0, -1];
    for (let guard of guards) {
        grid[guard[0]][guard[1]] = -1;
        for (let k = 0; k < 4; ++k) {
            // 将四个方向视线对应的状态均添加进搜索队列中
            q.enqueue([guard[0], guard[1], k]);
        }
    }
    for (let wall of walls) {
        grid[wall[0]][wall[1]] = -2;
    }
    while (!q.isEmpty()) {
        let [x, y, k] = q.dequeue();
        let nx = x + dx[k];
        let ny = y + dy[k];
        if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] >= 0) {
            // 沿着视线方向的下一个坐标合法，且不为警卫或墙
            if ((grid[nx][ny] & (1 << k)) === 0) {
                // 对应状态未遍历过
                grid[nx][ny] |= (1 << k);
                q.enqueue([nx, ny, k]);
            }
        }
    }
    let res = 0;   // 未被保护格子数目
    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            if (grid[i][j] === 0) {
                ++res;
            }
        }
    }
    return res;
}
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn count_unguarded(m: i32, n: i32, guards: Vec<Vec<i32>>, walls: Vec<Vec<i32>>) -> i32 {
        let (m, n) = (m as usize, n as usize);
        let mut grid = vec![vec![0; n]; m];   // 网格状态数组
        let mut q = VecDeque::new();   // 广度优先搜索队列
        // 每个方向的单位向量
        let dx = [1, 0, -1, 0];
        let dy = [0, 1, 0, -1];
        for guard in guards {
            let (x, y) = (guard[0] as usize, guard[1] as usize);
            grid[x][y] = -1;
            for k in 0..4 {
                // 将四个方向视线对应的状态均添加进搜索队列中
                q.push_back((x, y, k));
            }
        }
        for wall in walls {
            let (x, y) = (wall[0] as usize, wall[1] as usize);
            grid[x][y] = -2;
        }
        while let Some((x, y, k)) = q.pop_front() {
            let nx = x as i32 + dx[k];
            let ny = y as i32 + dy[k];
            if nx >= 0 && nx < m as i32 && ny >= 0 && ny < n as i32 {
                let (nx, ny) = (nx as usize, ny as usize);
                if grid[nx][ny] >= 0 {
                    // 沿着视线方向的下一个坐标合法，且不为警卫或墙
                    if (grid[nx][ny] & (1 << k)) == 0 {
                        // 对应状态未遍历过
                        grid[nx][ny] |= 1 << k;
                        q.push_back((nx, ny, k));
                    }
                }
            }
        }
        let mut res = 0;   // 未被保护格子数目
        for i in 0..m {
            for j in 0..n {
                if grid[i][j] == 0 {
                    res += 1;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别为网格图的行数与列数。即为广度优先搜索的时间复杂度。
- 空间复杂度：$O(mn)$，即为网格图数组的空间开销。
