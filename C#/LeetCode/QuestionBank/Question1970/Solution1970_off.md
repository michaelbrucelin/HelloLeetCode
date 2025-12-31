### [你能穿过矩阵的最后一天](https://leetcode.cn/problems/last-day-where-you-can-still-cross/solutions/936684/ni-neng-chuan-guo-ju-zhen-de-zui-hou-yi-9j20y/)

#### 前言

本题和 [1631\. 最小体力消耗路径](https://leetcode-cn.com/problems/path-with-minimum-effort/) 是几乎一样的题目。

#### 方法一：二分查找 + 广度优先搜索

**思路与算法**

如果第 $k$ 天我们能够从最上面一行走到最下面一行，那么第 $0,1,\dots ,k-1$ 天我们也可以。

因此，一定存在一个最大值 $k′$ 使得：

- 当 $k\le k′$ 时，我们可以在第 $k$ 天从最上面一行走到最下面一行；
- 当 $k>k′$ 时，我们不可以在第 $k$ 天从最上面一行走到最下面一行。

我们可以使用二分查找的方法找出 $k′$。二分查找的下界为 $0$，上界为 $row\times col$。

在二分查找的每一步中，我们需要对于二分到的 $k$ 值，判断是否可以最上面一行走到最下面一行。一种可行的方法是，我们构造一个 $row\times col$ 的全 $1$ 矩阵，并把 $cells$ 中前 $k$ 个坐标在矩阵中对应的格子置为 $0$。随后，我们将第一行的所有格子（如果格子上的值为 $1$）放入队列中，进行广度优先搜索，搜索的过程中只能走向上下左右相邻并且值为 $1$ 的格子。如果能够搜索到最后一行的某个格子，那么说明存在一条从最上面一行走到最下面一行的路径，我们修改二分的下界，否则修改二分的上界。

**代码**

```C++
class Solution {
private:
    static constexpr int dirs[4][2] = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

public:
    int latestDayToCross(int row, int col, vector<vector<int>>& cells) {
        int left = 0, right = row * col, ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;

            vector<vector<int>> grid(row, vector<int>(col, 1));
            for (int i = 0; i < mid; ++i) {
                grid[cells[i][0] - 1][cells[i][1] - 1] = 0;
            }

            queue<pair<int, int>> q;
            for (int i = 0; i < col; ++i) {
                if (grid[0][i]) {
                    q.emplace(0, i);
                    grid[0][i] = 0;
                }
            }
            bool found = false;
            while (!q.empty()) {
                auto [x, y] = q.front();
                q.pop();
                for (int d = 0; d < 4; ++d) {
                    int nx = x + dirs[d][0];
                    int ny = y + dirs[d][1];
                    if (nx >= 0 && nx < row && ny >= 0 && ny < col && grid[nx][ny]) {
                        if (nx == row - 1) {
                            found = true;
                            break;
                        }
                        q.emplace(nx, ny);
                        grid[nx][ny] = 0;
                    }
                }
            }
            if (found) {
                ans = mid;
                left = mid + 1;
            }
            else {
                right = mid - 1;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def latestDayToCross(self, row: int, col: int, cells: List[List[int]]) -> int:
        left, right, ans = 0, row * col, 0
        while left <= right:
            mid = (left + right) // 2

            grid = [[1] * col for _ in range(row)]
            for x, y in cells[:mid]:
                grid[x - 1][y - 1] = 0

            q = deque()
            for i in range(col):
                if grid[0][i]:
                    q.append((0, i))
                    grid[0][i] = 0

            found = False
            while q:
                x, y = q.popleft()
                for nx, ny in [(x - 1, y), (x + 1, y), (x, y - 1), (x, y + 1)]:
                    if 0 <= nx < row and 0 <= ny < col and grid[nx][ny]:
                        if nx == row - 1:
                            found = True
                            break
                        q.append((nx, ny))
                        grid[nx][ny] = 0

            if found:
                ans = mid
                left = mid + 1
            else:
                right = mid - 1

        return ans
```

```Java
class Solution {
    private static final int[][] dirs = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

    public int latestDayToCross(int row, int col, int[][] cells) {
        int left = 0, right = row * col, ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            int[][] grid = new int[row][col];
            for (int i = 0; i < row; i++) {
                Arrays.fill(grid[i], 1);
            }
            for (int i = 0; i < mid; i++) {
                grid[cells[i][0] - 1][cells[i][1] - 1] = 0;
            }

            Queue<int[]> q = new LinkedList<>();
            for (int i = 0; i < col; i++) {
                if (grid[0][i] == 1) {
                    q.offer(new int[]{0, i});
                    grid[0][i] = 0;
                }
            }

            boolean found = false;
            while (!q.isEmpty()) {
                int[] cell = q.poll();
                int x = cell[0], y = cell[1];
                for (int[] dir : dirs) {
                    int nx = x + dir[0];
                    int ny = y + dir[1];
                    if (nx >= 0 && nx < row && ny >= 0 && ny < col && grid[nx][ny] == 1) {
                        if (nx == row - 1) {
                            found = true;
                            break;
                        }
                        q.offer(new int[]{nx, ny});
                        grid[nx][ny] = 0;
                    }
                }
                if (found) {
                    break;
                }
            }

            if (found) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    private static readonly int[][] dirs = new int[][] {
        new int[] {-1, 0}, new int[] {1, 0}, new int[] {0, -1}, new int[] {0, 1}
    };

    public int LatestDayToCross(int row, int col, int[][] cells) {
        int left = 0, right = row * col, ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;

            int[][] grid = new int[row][];
            for (int i = 0; i < row; i++) {
                grid[i] = new int[col];
                Array.Fill(grid[i], 1);
            }
            for (int i = 0; i < mid; i++) {
                grid[cells[i][0] - 1][cells[i][1] - 1] = 0;
            }

            Queue<int[]> q = new Queue<int[]>();
            for (int i = 0; i < col; i++) {
                if (grid[0][i] == 1) {
                    q.Enqueue(new int[] {0, i});
                    grid[0][i] = 0;
                }
            }

            bool found = false;
            while (q.Count > 0) {
                int[] cell = q.Dequeue();
                int x = cell[0], y = cell[1];
                foreach (var dir in dirs) {
                    int nx = x + dir[0];
                    int ny = y + dir[1];
                    if (nx >= 0 && nx < row && ny >= 0 && ny < col && grid[nx][ny] == 1) {
                        if (nx == row - 1) {
                            found = true;
                            break;
                        }
                        q.Enqueue(new int[] {nx, ny});
                        grid[nx][ny] = 0;
                    }
                }
                if (found) {
                    break;
                }
            }

            if (found) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }
}
```

```Go
func latestDayToCross(row int, col int, cells [][]int) int {
    dirs := [4][2]int{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}
    left, right, ans := 0, row * col, 0

    for left <= right {
        mid := (left + right) / 2
        grid := make([][]int, row)
        for i := range grid {
            grid[i] = make([]int, col)
            for j := range grid[i] {
                grid[i][j] = 1
            }
        }
        for i := 0; i < mid; i++ {
            grid[cells[i][0] - 1][cells[i][1] - 1] = 0
        }

        queue := [][2]int{}
        for i := 0; i < col; i++ {
            if grid[0][i] == 1 {
                queue = append(queue, [2]int{0, i})
                grid[0][i] = 0
            }
        }

        found := false
        for len(queue) > 0 {
            cell := queue[0]
            queue = queue[1:]
            x, y := cell[0], cell[1]

            for _, dir := range dirs {
                nx, ny := x+dir[0], y+dir[1]
                if nx >= 0 && nx < row && ny >= 0 && ny < col && grid[nx][ny] == 1 {
                    if nx == row-1 {
                        found = true
                        break
                    }
                    queue = append(queue, [2]int{nx, ny})
                    grid[nx][ny] = 0
                }
            }
            if found {
                break
            }
        }

        if found {
            ans = mid
            left = mid + 1
        } else {
            right = mid - 1
        }
    }

    return ans
}
```

```C
typedef struct {
    int x;
    int y;
} Point;

const int dirs[4][2] = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

int latestDayToCross(int row, int col, int** cells, int cellsSize, int* cellsColSize) {
    int left = 0, right = row * col, ans = 0;
    int grid[row][col];
    Point queue[row * col];

    while (left <= right) {
        int mid = (left + right) / 2;
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                grid[i][j] = 1;
            }
        }
        for (int i = 0; i < mid; i++) {
            grid[cells[i][0] - 1][cells[i][1] - 1] = 0;
        }
        int front = 0, rear = 0;
        for (int i = 0; i < col; i++) {
            if (grid[0][i] == 1) {
                queue[rear++] = (Point){0, i};
                grid[0][i] = 0;
            }
        }

        bool found = false;
        while (front < rear) {
            Point cell = queue[front++];
            int x = cell.x, y = cell.y;
            for (int d = 0; d < 4; d++) {
                int nx = x + dirs[d][0];
                int ny = y + dirs[d][1];
                if (nx >= 0 && nx < row && ny >= 0 && ny < col && grid[nx][ny] == 1) {
                    if (nx == row - 1) {
                        found = true;
                        break;
                    }
                    queue[rear++] = (Point){nx, ny};
                    grid[nx][ny] = 0;
                }
            }
            if (found) {
                break;
            }
        }

        if (found) {
            ans = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    return ans;
}
```

```JavaScript

var latestDayToCross = function(row, col, cells) {
    const dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];

    let left = 0, right = row * col, ans = 0;
    while (left <= right) {
        const mid = Math.floor((left + right) / 2);
        const grid = Array.from({length: row}, () =>
            Array.from({length: col}, () => 1));
        for (let i = 0; i < mid; i++) {
            grid[cells[i][0] - 1][cells[i][1] - 1] = 0;
        }

        const queue = [];
        for (let i = 0; i < col; i++) {
            if (grid[0][i] === 1) {
                queue.push([0, i]);
                grid[0][i] = 0;
            }
        }

        let found = false;
        while (queue.length > 0) {
            const [x, y] = queue.shift();
            for (const [dx, dy] of dirs) {
                const nx = x + dx;
                const ny = y + dy;
                if (nx >= 0 && nx < row && ny >= 0 && ny < col && grid[nx][ny] === 1) {
                    if (nx === row - 1) {
                        found = true;
                        break;
                    }
                    queue.push([nx, ny]);
                    grid[nx][ny] = 0;
                }
            }
            if (found) break;
        }

        if (found) {
            ans = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    return ans;
};
```

```TypeScript
function latestDayToCross(row: number, col: number, cells: number[][]): number {
    const dirs: number[][] = [[-1, 0], [1, 0], [0, -1], [0, 1]];
    let left = 0, right = row * col, ans = 0;
    while (left <= right) {
        const mid = Math.floor((left + right) / 2);
        const grid: number[][] = Array.from({length: row}, () =>
            Array.from({length: col}, () => 1));
        for (let i = 0; i < mid; i++) {
            grid[cells[i][0] - 1][cells[i][1] - 1] = 0;
        }

        const queue: number[][] = [];
        for (let i = 0; i < col; i++) {
            if (grid[0][i] === 1) {
                queue.push([0, i]);
                grid[0][i] = 0;
            }
        }
        let found = false;
        while (queue.length > 0) {
            const [x, y] = queue.shift()!;
            for (const [dx, dy] of dirs) {
                const nx = x + dx;
                const ny = y + dy;
                if (nx >= 0 && nx < row && ny >= 0 && ny < col && grid[nx][ny] === 1) {
                    if (nx === row - 1) {
                        found = true;
                        break;
                    }
                    queue.push([nx, ny]);
                    grid[nx][ny] = 0;
                }
            }
            if (found) break;
        }

        if (found) {
            ans = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    return ans;
};
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn latest_day_to_cross(row: i32, col: i32, cells: Vec<Vec<i32>>) -> i32 {
        let dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        let (row, col) = (row as usize, col as usize);

        let mut left = 0;
        let mut right = row * col;
        let mut ans = 0;

        while left <= right {
            let mid = (left + right) / 2;
            let mut grid = vec![vec![1; col]; row];
            for i in 0..mid {
                let r = (cells[i][0] - 1) as usize;
                let c = (cells[i][1] - 1) as usize;
                grid[r][c] = 0;
            }

            let mut queue = VecDeque::new();
            for i in 0..col {
                if grid[0][i] == 1 {
                    queue.push_back((0, i));
                    grid[0][i] = 0;
                }
            }

            let mut found = false;
            while let Some((x, y)) = queue.pop_front() {
                for (dx, dy) in &dirs {
                    let nx = x as i32 + dx;
                    let ny = y as i32 + dy;

                    if nx >= 0 && nx < row as i32 && ny >= 0 && ny < col as i32 {
                        let (nx, ny) = (nx as usize, ny as usize);
                        if grid[nx][ny] == 1 {
                            if nx == row - 1 {
                                found = true;
                                break;
                            }
                            queue.push_back((nx, ny));
                            grid[nx][ny] = 0;
                        }
                    }
                }
                if found {
                    break;
                }
            }

            if found {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(row\times col\times \log (row\times col))$。二分查找的次数为 $O(\log (row\times col))$，在二分查找的每一步中，我们需要 $O(row\times col)$ 的时间进行广度优先搜索。
- 空间复杂度：$O(row\times col)$，即为广度优先搜索中的矩阵以及队列需要使用的空间。

#### 方法二：时光倒流 $+$ 并查集

**思路与算法**

我们也可以倒着考虑这个问题：

在第 $row\times col$ 天时，矩阵中的每个格子都是水域。随后每往前推一天，就会有一个格子从水域变为陆地，问**最少**往前推几天可以从最上面一行走到最下面一行。

因此，我们可以将矩阵中的每一个格子看成并查集中的一个节点。当我们将 $(x,y)$ 从水域变为陆地时，我们将 $(x,y)$ 在并查集中的节点与上下左右四个方向的格子（如果对应的格子也是陆地）在并查集中的节点进行合并。

由于我们需要判断的是最上面一行与最下面一行的连通性，所以我们可以在并查集中额外添加两个超级节点 $s$ 和 $t$，分别表示最上面一行（整体）与最下面一行（整体）。如果 $(x,y)$ 中的 $x=0$，我们就将 $s$ 与 $(x,y)$ 在并查集中的节点进行合并；如果 $x=row-1$，我们就将 $t$ 与 $(x,y)$ 在并查集中的节点进行合并。这样一来，只要 $(s,t)$ 在并查集中连通，就说明我们可以从最上面一行走到最下面一行。

**代码**

```C++
// 并查集模板
class UnionFind {
public:
    vector<int> parent;
    vector<int> size;
    int n;
    // 当前连通分量数目
    int setCount;

public:
    UnionFind(int _n): n(_n), setCount(_n), parent(_n), size(_n, 1) {
        iota(parent.begin(), parent.end(), 0);
    }

    int findset(int x) {
        return parent[x] == x ? x : parent[x] = findset(parent[x]);
    }

    bool unite(int x, int y) {
        x = findset(x);
        y = findset(y);
        if (x == y) {
            return false;
        }
        if (size[x] < size[y]) {
            swap(x, y);
        }
        parent[y] = x;
        size[x] += size[y];
        --setCount;
        return true;
    }

    bool connected(int x, int y) {
        x = findset(x);
        y = findset(y);
        return x == y;
    }
};

class Solution {
public:
    int latestDayToCross(int row, int col, vector<vector<int>>& cells) {
        // 编号为 n 的节点是超级节点 s
        // 编号为 n+1 的节点是超级节点 t
        int n = row * col;
        auto uf = UnionFind(n + 2);

        vector<vector<int>> valid(row, vector<int>(col));
        int ans = 0;
        for (int i = n - 1; i >= 0; --i) {
            int x = cells[i][0] - 1, y = cells[i][1] - 1;
            valid[x][y] = true;
            // 并查集是一维的，(x, y) 坐标是二维的，需要进行转换
            int id = x * col + y;
            if (x - 1 >= 0 && valid[x - 1][y]) {
                uf.unite(id, id - col);
            }
            if (x + 1 < row && valid[x + 1][y]) {
                uf.unite(id, id + col);
            }
            if (y - 1 >= 0 && valid[x][y - 1]) {
                uf.unite(id, id - 1);
            }
            if (y + 1 < col && valid[x][y + 1]) {
                uf.unite(id, id + 1);
            }
            if (x == 0) {
                uf.unite(id, n);
            }
            if (x == row - 1) {
                uf.unite(id, n + 1);
            }
            if (uf.connected(n, n + 1)) {
                ans = i;
                break;
            }
        }
        return ans;
    }
};
```

```Python
# 并查集模板
class UnionFind:
    def __init__(self, n: int):
        self.parent = list(range(n))
        self.size = [1] * n
        self.n = n
        # 当前连通分量数目
        self.setCount = n

    def findset(self, x: int) -> int:
        if self.parent[x] == x:
            return x
        self.parent[x] = self.findset(self.parent[x])
        return self.parent[x]

    def unite(self, x: int, y: int) -> bool:
        x, y = self.findset(x), self.findset(y)
        if x == y:
            return False
        if self.size[x] < self.size[y]:
            x, y = y, x
        self.parent[y] = x
        self.size[x] += self.size[y]
        self.setCount -= 1
        return True

    def connected(self, x: int, y: int) -> bool:
        x, y = self.findset(x), self.findset(y)
        return x == y

class Solution:
    def latestDayToCross(self, row: int, col: int, cells: List[List[int]]) -> int:
        # 编号为 n 的节点是超级节点 s
        # 编号为 n+1 的节点是超级节点 t
        n = row * col
        uf = UnionFind(n + 2)

        valid = [[0] * col for _ in range(row)]
        ans = 0
        for i in range(n - 1, -1, -1):
            x, y = cells[i][0] - 1, cells[i][1] - 1
            valid[x][y] = 1
            # 并查集是一维的，(x, y) 坐标是二维的，需要进行转换
            idx = x * col + y
            if x - 1 >= 0 and valid[x - 1][y]:
                uf.unite(idx, idx - col)
            if x + 1 < row and valid[x + 1][y]:
                uf.unite(idx, idx + col)
            if y - 1 >= 0 and valid[x][y - 1]:
                uf.unite(idx, idx - 1)
            if y + 1 < col and valid[x][y + 1]:
                uf.unite(idx, idx + 1)
            if x == 0:
                uf.unite(idx, n)
            if x == row - 1:
                uf.unite(idx, n + 1)
            if uf.connected(n, n + 1):
                ans = i
                break

        return ans
```

```Java
// 并查集模板
class UnionFind {
    public int[] parent;
    public int[] size;
    public int n;
    // 当前连通分量数目
    public int setCount;

    public UnionFind(int _n) {
        n = _n;
        setCount = _n;
        parent = new int[n];
        size = new int[n];
        Arrays.fill(size, 1);
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    public int findset(int x) {
        return parent[x] == x ? x : (parent[x] = findset(parent[x]));
    }

    public boolean unite(int x, int y) {
        x = findset(x);
        y = findset(y);
        if (x == y) {
            return false;
        }
        if (size[x] < size[y]) {
            int temp = x;
            x = y;
            y = temp;
        }
        parent[y] = x;
        size[x] += size[y];
        --setCount;
        return true;
    }

    public boolean connected(int x, int y) {
        return findset(x) == findset(y);
    }
}

class Solution {
    public int latestDayToCross(int row, int col, int[][] cells) {
        // 编号为 n 的节点是超级节点 s
        // 编号为 n+1 的节点是超级节点 t
        int n = row * col;
        UnionFind uf = new UnionFind(n + 2);
        int[][] valid = new int[row][col];
        int ans = 0;
        for (int i = n - 1; i >= 0; --i) {
            int x = cells[i][0] - 1, y = cells[i][1] - 1;
            valid[x][y] = 1;
            // 并查集是一维的，(x, y) 坐标是二维的，需要进行转换
            int id = x * col + y;
            if (x - 1 >= 0 && valid[x - 1][y] == 1) {
                uf.unite(id, id - col);
            }
            if (x + 1 < row && valid[x + 1][y] == 1) {
                uf.unite(id, id + col);
            }
            if (y - 1 >= 0 && valid[x][y - 1] == 1) {
                uf.unite(id, id - 1);
            }
            if (y + 1 < col && valid[x][y + 1] == 1) {
                uf.unite(id, id + 1);
            }
            if (x == 0) {
                uf.unite(id, n);
            }
            if (x == row - 1) {
                uf.unite(id, n + 1);
            }
            if (uf.connected(n, n + 1)) {
                ans = i;
                break;
            }
        }
        return ans;
    }
}
```

```CSharp
// 并查集模板
public class UnionFind {
    public int[] parent;
    public int[] size;
    public int n;
    // 当前连通分量数目
    public int setCount;

    public UnionFind(int _n) {
        n = _n;
        setCount = _n;
        parent = new int[n];
        size = new int[n];
        Array.Fill(size, 1);
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    public int findset(int x) {
        return parent[x] == x ? x : (parent[x] = findset(parent[x]));
    }

    public bool unite(int x, int y) {
        x = findset(x);
        y = findset(y);
        if (x == y) {
            return false;
        }
        if (size[x] < size[y]) {
            int temp = x;
            x = y;
            y = temp;
        }
        parent[y] = x;
        size[x] += size[y];
        --setCount;
        return true;
    }

    public bool connected(int x, int y) {
        return findset(x) == findset(y);
    }
}

public class Solution {
    public int LatestDayToCross(int row, int col, int[][] cells) {
        // 编号为 n 的节点是超级节点 s
        // 编号为 n+1 的节点是超级节点 t
        int n = row * col;
        UnionFind uf = new UnionFind(n + 2);
        int[][] valid = new int[row][];
        for (int i = 0; i < row; i++) {
            valid[i] = new int[col];
        }

        int ans = 0;
        for (int i = n - 1; i >= 0; --i) {
            int x = cells[i][0] - 1, y = cells[i][1] - 1;
            valid[x][y] = 1;
            // 并查集是一维的，(x, y) 坐标是二维的，需要进行转换
            int id = x * col + y;
            if (x - 1 >= 0 && valid[x - 1][y] == 1) {
                uf.unite(id, id - col);
            }
            if (x + 1 < row && valid[x + 1][y] == 1) {
                uf.unite(id, id + col);
            }
            if (y - 1 >= 0 && valid[x][y - 1] == 1) {
                uf.unite(id, id - 1);
            }
            if (y + 1 < col && valid[x][y + 1] == 1) {
                uf.unite(id, id + 1);
            }
            if (x == 0) {
                uf.unite(id, n);
            }
            if (x == row - 1) {
                uf.unite(id, n + 1);
            }
            if (uf.connected(n, n + 1)) {
                ans = i;
                break;
            }
        }

        return ans;
    }
}
```

```Go
func latestDayToCross(row int, col int, cells [][]int) int {
    // 编号为 n 的节点是超级节点 s
    // 编号为 n+1 的节点是超级节点 t
    n := row * col
    uf := newUnionFind(n + 2)
    valid := make([][]int, row)
    for i := range valid {
        valid[i] = make([]int, col)
    }
    ans := 0
    for i := n - 1; i >= 0; i-- {
        x, y := cells[i][0] - 1, cells[i][1] - 1
        valid[x][y] = 1
        // 并查集是一维的，(x, y) 坐标是二维的，需要进行转换
        id := x * col + y
        if x - 1 >= 0 && valid[x - 1][y] == 1 {
            uf.unite(id, id - col)
        }
        if x + 1 < row && valid[x + 1][y] == 1 {
            uf.unite(id, id + col)
        }
        if y - 1 >= 0 && valid[x][y - 1] == 1 {
            uf.unite(id, id - 1)
        }
        if y + 1 < col && valid[x][y + 1] == 1 {
            uf.unite(id, id + 1)
        }
        if x == 0 {
            uf.unite(id, n)
        }
        if x == row-1 {
            uf.unite(id, n + 1)
        }
        if uf.connected(n, n + 1) {
            ans = i
            break
        }
    }

    return ans
}

// 并查集模板
type UnionFind struct {
    parent []int
    size   []int
    n      int
    // 当前连通分量数目
    setCount int
}

func newUnionFind(n int) *UnionFind {
    parent := make([]int, n)
    size := make([]int, n)
    for i := range parent {
        parent[i] = i
        size[i] = 1
    }
    return &UnionFind{
        parent:   parent,
        size:     size,
        n:        n,
        setCount: n,
    }
}

func (uf *UnionFind) findset(x int) int {
    if uf.parent[x] != x {
        uf.parent[x] = uf.findset(uf.parent[x])
    }
    return uf.parent[x]
}

func (uf *UnionFind) unite(x, y int) bool {
    x, y = uf.findset(x), uf.findset(y)
    if x == y {
        return false
    }
    if uf.size[x] < uf.size[y] {
        x, y = y, x
    }
    uf.parent[y] = x
    uf.size[x] += uf.size[y]
    uf.setCount--
    return true
}

func (uf *UnionFind) connected(x, y int) bool {
    return uf.findset(x) == uf.findset(y)
}
```

```C
// 并查集模板
typedef struct {
    int* parent;
    int* size;
    int n;
    // 当前连通分量数目
    int setCount;
} UnionFind;

UnionFind* createUnionFind(int n) {
    UnionFind* uf = (UnionFind*)malloc(sizeof(UnionFind));
    uf->n = n;
    uf->setCount = n;
    uf->parent = (int*)malloc(n * sizeof(int));
    uf->size = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        uf->parent[i] = i;
        uf->size[i] = 1;
    }
    return uf;
}

int findset(UnionFind* uf, int x) {
    if (uf->parent[x] != x) {
        uf->parent[x] = findset(uf, uf->parent[x]);
    }
    return uf->parent[x];
}

int unite(UnionFind* uf, int x, int y) {
    x = findset(uf, x);
    y = findset(uf, y);
    if (x == y) {
        return 0;
    }
    if (uf->size[x] < uf->size[y]) {
        int temp = x;
        x = y;
        y = temp;
    }
    uf->parent[y] = x;
    uf->size[x] += uf->size[y];
    uf->setCount--;
    return 1;
}

int connected(UnionFind* uf, int x, int y) {
    return findset(uf, x) == findset(uf, y);
}

void freeUnionFind(UnionFind* uf) {
    free(uf->parent);
    free(uf->size);
    free(uf);
}

int latestDayToCross(int row, int col, int** cells, int cellsSize, int* cellsColSize) {
    // 编号为 n 的节点是超级节点 s
    // 编号为 n+1 的节点是超级节点 t
    int n = row * col;
    UnionFind* uf = createUnionFind(n + 2);
    int** valid = (int**)malloc(row * sizeof(int*));
    for (int i = 0; i < row; i++) {
        valid[i] = (int*)malloc(col * sizeof(int));
        memset(valid[i], 0, col * sizeof(int));
    }
    int ans = 0;
    for (int i = n - 1; i >= 0; --i) {
        int x = cells[i][0] - 1, y = cells[i][1] - 1;
        valid[x][y] = 1;
        // 并查集是一维的，(x, y) 坐标是二维的，需要进行转换
        int id = x * col + y;
        if (x - 1 >= 0 && valid[x - 1][y]) {
            unite(uf, id, id - col);
        }
        if (x + 1 < row && valid[x + 1][y]) {
            unite(uf, id, id + col);
        }
        if (y - 1 >= 0 && valid[x][y - 1]) {
            unite(uf, id, id - 1);
        }
        if (y + 1 < col && valid[x][y + 1]) {
            unite(uf, id, id + 1);
        }
        if (x == 0) {
            unite(uf, id, n);
        }
        if (x == row - 1) {
            unite(uf, id, n + 1);
        }
        if (connected(uf, n, n + 1)) {
            ans = i;
            break;
        }
    }

    // 释放内存
    for (int i = 0; i < row; i++) {
        free(valid[i]);
    }
    free(valid);
    freeUnionFind(uf);

    return ans;
}
```

```JavaScript
var latestDayToCross = function(row, col, cells) {
    // 编号为 n 的节点是超级节点 s
    // 编号为 n+1 的节点是超级节点 t
    const n = row * col;
    const uf = new UnionFind(n + 2);
    const valid = Array.from({length: row}, () => new Array(col).fill(0));
    let ans = 0;
    for (let i = n - 1; i >= 0; --i) {
        const x = cells[i][0] - 1, y = cells[i][1] - 1;
        valid[x][y] = 1;
        // 并查集是一维的，(x, y) 坐标是二维的，需要进行转换
        const id = x * col + y;
        if (x - 1 >= 0 && valid[x - 1][y] === 1) {
            uf.unite(id, id - col);
        }
        if (x + 1 < row && valid[x + 1][y] === 1) {
            uf.unite(id, id + col);
        }
        if (y - 1 >= 0 && valid[x][y - 1] === 1) {
            uf.unite(id, id - 1);
        }
        if (y + 1 < col && valid[x][y + 1] === 1) {
            uf.unite(id, id + 1);
        }
        if (x === 0) {
            uf.unite(id, n);
        }
        if (x === row - 1) {
            uf.unite(id, n + 1);
        }
        if (uf.connected(n, n + 1)) {
            ans = i;
            break;
        }
    }
    return ans;
}

// 并查集模板
class UnionFind {
    constructor(n) {
        this.parent = new Array(n);
        this.size = new Array(n).fill(1);
        this.n = n;
        // 当前连通分量数目
        this.setCount = n;
        for (let i = 0; i < n; i++) {
            this.parent[i] = i;
        }
    }

    findset(x) {
        return this.parent[x] === x ? x : (this.parent[x] = this.findset(this.parent[x]));
    }

    unite(x, y) {
        x = this.findset(x);
        y = this.findset(y);
        if (x === y) {
            return false;
        }
        if (this.size[x] < this.size[y]) {
            [x, y] = [y, x];
        }
        this.parent[y] = x;
        this.size[x] += this.size[y];
        this.setCount--;
        return true;
    }

    connected(x, y) {
        return this.findset(x) === this.findset(y);
    }
}
```

```TypeScript
function latestDayToCross(row: number, col: number, cells: number[][]): number {
    // 编号为 n 的节点是超级节点 s
    // 编号为 n+1 的节点是超级节点 t
    const n = row * col;
    const uf = new UnionFind(n + 2);
    const valid: number[][] = Array.from({length: row}, () => new Array(col).fill(0));
    let ans = 0;
    for (let i = n - 1; i >= 0; --i) {
        const x = cells[i][0] - 1, y = cells[i][1] - 1;
        valid[x][y] = 1;
        // 并查集是一维的，(x, y) 坐标是二维的，需要进行转换
        const id = x * col + y;
        if (x - 1 >= 0 && valid[x - 1][y] === 1) {
            uf.unite(id, id - col);
        }
        if (x + 1 < row && valid[x + 1][y] === 1) {
            uf.unite(id, id + col);
        }
        if (y - 1 >= 0 && valid[x][y - 1] === 1) {
            uf.unite(id, id - 1);
        }
        if (y + 1 < col && valid[x][y + 1] === 1) {
            uf.unite(id, id + 1);
        }
        if (x === 0) {
            uf.unite(id, n);
        }
        if (x === row - 1) {
            uf.unite(id, n + 1);
        }
        if (uf.connected(n, n + 1)) {
            ans = i;
            break;
        }
    }
    return ans;
};

// 并查集模板
class UnionFind {
    parent: number[];
    size: number[];
    n: number;
    // 当前连通分量数目
    setCount: number;

    constructor(n: number) {
        this.n = n;
        this.setCount = n;
        this.parent = new Array(n);
        this.size = new Array(n).fill(1);
        for (let i = 0; i < n; i++) {
            this.parent[i] = i;
        }
    }

    findset(x: number): number {
        return this.parent[x] === x ? x : (this.parent[x] = this.findset(this.parent[x]));
    }

    unite(x: number, y: number): boolean {
        x = this.findset(x);
        y = this.findset(y);
        if (x === y) {
            return false;
        }
        if (this.size[x] < this.size[y]) {
            [x, y] = [y, x];
        }
        this.parent[y] = x;
        this.size[x] += this.size[y];
        this.setCount--;
        return true;
    }

    connected(x: number, y: number): boolean {
        return this.findset(x) === this.findset(y);
    }
}
```

```Rust
// 并查集模板
struct UnionFind {
    parent: Vec<usize>,
    size: Vec<i32>,
    n: usize,
    // 当前连通分量数目
    set_count: i32,
}

impl UnionFind {
    fn new(n: usize) -> Self {
        let mut parent = vec![0; n];
        let size = vec![1; n];
        for i in 0..n {
            parent[i] = i;
        }
        UnionFind {
            parent,
            size,
            n,
            set_count: n as i32,
        }
    }

    fn findset(&mut self, x: usize) -> usize {
        if self.parent[x] != x {
            self.parent[x] = self.findset(self.parent[x]);
        }
        self.parent[x]
    }

    fn unite(&mut self, x: usize, y: usize) -> bool {
        let mut x = self.findset(x);
        let mut y = self.findset(y);
        if x == y {
            return false;
        }
        if self.size[x] < self.size[y] {
            std::mem::swap(&mut x, &mut y);
        }
        self.parent[y] = x;
        self.size[x] += self.size[y];
        self.set_count -= 1;
        true
    }

    fn connected(&mut self, x: usize, y: usize) -> bool {
        self.findset(x) == self.findset(y)
    }
}

impl Solution {
    pub fn latest_day_to_cross(row: i32, col: i32, cells: Vec<Vec<i32>>) -> i32 {
        // 编号为 n 的节点是超级节点 s
        // 编号为 n+1 的节点是超级节点 t
        let (row, col) = (row as usize, col as usize);
        let n = row * col;
        let mut uf = UnionFind::new(n + 2);
        let mut valid = vec![vec![0; col]; row];
        let mut ans = 0;
        for i in (0..n).rev() {
            let x = (cells[i][0] - 1) as usize;
            let y = (cells[i][1] - 1) as usize;
            valid[x][y] = 1;
            // 并查集是一维的，(x, y) 坐标是二维的，需要进行转换
            let id = x * col + y;
            if x > 0 && valid[x - 1][y] == 1 {
                uf.unite(id, id - col);
            }
            if x + 1 < row && valid[x + 1][y] == 1 {
                uf.unite(id, id + col);
            }
            if y > 0 && valid[x][y - 1] == 1 {
                uf.unite(id, id - 1);
            }
            if y + 1 < col && valid[x][y + 1] == 1 {
                uf.unite(id, id + 1);
            }
            if x == 0 {
                uf.unite(id, n);
            }
            if x == row - 1 {
                uf.unite(id, n + 1);
            }
            if uf.connected(n, n + 1) {
                ans = i;
                break;
            }
        }
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(row\times col\times \alpha (row\times col))$。其中 $\alpha$ 是阿克曼函数的反函数，表示并查集在均摊意义下单次操作需要的时间。
- 空间复杂度：$O(row\times col)$，即为并查集需要的空间。
