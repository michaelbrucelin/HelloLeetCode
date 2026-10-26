### [总价值可以被 K 整除的岛屿数目](https://leetcode.cn/problems/count-islands-with-total-value-divisible-by-k/solutions/4043253/zong-jie-zhi-ke-yi-bei-k-zheng-chu-de-da-egkg/)

#### 方法一：深度优先搜索

**思路与算法**

遍历矩阵中的每个格子。当遇到一个值大于 $0$ 的格子时，说明发现了一个尚未访问的岛屿。

从该格子出发进行深度优先搜索，递归访问四方向相邻且值大于 $0$ 的格子，并累加这些格子的值。为了避免重复访问，在访问一个格子后将其值修改为 $0$。

一次搜索结束后，我们就得到了当前岛屿的总价值。如果总价值可以被 $k$ 整除，则将答案加一。

**代码**

```C++
class Solution {
public:
    int countIslands(vector<vector<int>>& grid, int k) {
        int m = grid.size(), n = grid[0].size();
        const int dirs[5] = {-1, 0, 1, 0, -1};

        function<long long(int, int)> dfs = [&](int i, int j) -> long long {
            long long sum = grid[i][j];
            grid[i][j] = 0;
            for (int d = 0; d < 4; ++d) {
                int x = i + dirs[d], y = j + dirs[d + 1];
                if (x >= 0 && x < m && y >= 0 && y < n && grid[x][y] > 0) {
                    sum += dfs(x, y);
                }
            }
            return sum;
        };

        int ans = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] > 0 && dfs(i, j) % k == 0) {
                    ++ans;
                }
            }
        }

        return ans;
    }
};
```

```Python
class Solution:
    def countIslands(self, grid: List[List[int]], k: int) -> int:
        m, n = len(grid), len(grid[0])
        dirs = (-1, 0, 1, 0, -1)

        def dfs(i: int, j: int) -> int:
            total = grid[i][j]
            grid[i][j] = 0
            for d in range(4):
                x, y = i + dirs[d], j + dirs[d + 1]
                if 0 <= x < m and 0 <= y < n and grid[x][y] > 0:
                    total += dfs(x, y)
            return total

        return sum(
            grid[i][j] > 0 and dfs(i, j) % k == 0
            for i in range(m)
            for j in range(n)
        )
```

```Rust
impl Solution {
    pub fn count_islands(mut grid: Vec<Vec<i32>>, k: i32) -> i32 {
        let m = grid.len();
        let n = grid[0].len();

        fn dfs(grid: &mut [Vec<i32>], i: usize, j: usize) -> i64 {
            let mut sum = grid[i][j] as i64;
            grid[i][j] = 0;
            let dirs = [-1, 0, 1, 0, -1];
            for d in 0..4 {
                let x = i as i32 + dirs[d];
                let y = j as i32 + dirs[d + 1];
                if x >= 0 && x < grid.len() as i32
                    && y >= 0 && y < grid[0].len() as i32
                    && grid[x as usize][y as usize] > 0
                {
                    sum += dfs(grid, x as usize, y as usize);
                }
            }
            sum
        }

        let mut ans = 0;
        for i in 0..m {
            for j in 0..n {
                if grid[i][j] > 0 && dfs(&mut grid, i, j) % k as i64 == 0 {
                    ans += 1;
                }
            }
        }

        ans
    }
}
```

```Java
class Solution {
    private int m, n;
    private final int[] dirs = {-1, 0, 1, 0, -1};

    public int countIslands(int[][] grid, int k) {
        m = grid.length;
        n = grid[0].length;
        int ans = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] > 0 && dfs(grid, i, j) % k == 0) {
                    ++ans;
                }
            }
        }
        return ans;
    }

    private long dfs(int[][] grid, int i, int j) {
        long sum = grid[i][j];
        grid[i][j] = 0;
        for (int d = 0; d < 4; ++d) {
            int x = i + dirs[d], y = j + dirs[d + 1];
            if (x >= 0 && x < m && y >= 0 && y < n && grid[x][y] > 0) {
                sum += dfs(grid, x, y);
            }
        }
        return sum;
    }
}
```

```CSharp
public class Solution {
    private int m, n;
    private readonly int[] dirs = { -1, 0, 1, 0, -1 };

    public int CountIslands(int[][] grid, int k) {
        m = grid.Length;
        n = grid[0].Length;
        int ans = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] > 0 && Dfs(grid, i, j) % k == 0) {
                    ++ans;
                }
            }
        }
        return ans;
    }

    private long Dfs(int[][] grid, int i, int j) {
        long sum = grid[i][j];
        grid[i][j] = 0;
        for (int d = 0; d < 4; ++d) {
            int x = i + dirs[d], y = j + dirs[d + 1];
            if (x >= 0 && x < m && y >= 0 && y < n && grid[x][y] > 0) {
                sum += Dfs(grid, x, y);
            }
        }
        return sum;
    }
}
```

```Go
func countIslands(grid [][]int, k int) int {
    m, n := len(grid), len(grid[0])
    dirs := [5]int{-1, 0, 1, 0, -1}

    var dfs func(i, j int) int64
    dfs = func(i, j int) int64 {
        sum := int64(grid[i][j])
        grid[i][j] = 0
        for d := 0; d < 4; d++ {
            x := i + dirs[d]
            y := j + dirs[d+1]
            if x >= 0 && x < m && y >= 0 && y < n && grid[x][y] > 0 {
                sum += dfs(x, y)
            }
        }
        return sum
    }

    ans := 0
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if grid[i][j] > 0 && dfs(i, j)%int64(k) == 0 {
                ans++
            }
        }
    }
    return ans
}
```

```C
static const int dirs[5] = {-1, 0, 1, 0, -1};

long long dfs(int** grid, int i, int j, int m, int n) {
    long long sum = grid[i][j];
    grid[i][j] = 0;
    for (int d = 0; d < 4; ++d) {
        int x = i + dirs[d];
        int y = j + dirs[d + 1];
        if (x >= 0 && x < m && y >= 0 && y < n && grid[x][y] > 0) {
            sum += dfs(grid, x, y, m, n);
        }
    }
    return sum;
}

int countIslands(int** grid, int gridSize, int* gridColSize, int k) {
    int m = gridSize;
    int n = gridColSize[0];
    int ans = 0;
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
            if (grid[i][j] > 0 && dfs(grid, i, j, m, n) % k == 0) {
                ++ans;
            }
        }
    }
    return ans;
}
```

```JavaScript
var countIslands = function (grid, k) {
    const m = grid.length, n = grid[0].length;
    const dirs = [-1, 0, 1, 0, -1];

    const dfs = (i, j) => {
        let sum = grid[i][j];
        grid[i][j] = 0;
        for (let d = 0; d < 4; ++d) {
            const x = i + dirs[d], y = j + dirs[d + 1];
            if (x >= 0 && x < m && y >= 0 && y < n && grid[x][y] > 0) {
                sum += dfs(x, y);
            }
        }
        return sum;
    };

    let ans = 0;
    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            if (grid[i][j] > 0 && dfs(i, j) % k === 0) {
                ++ans;
            }
        }
    }
    return ans;
};
```

```TypeScript
function countIslands(grid: number[][], k: number): number {
    const m = grid.length, n = grid[0].length;
    const dirs: number[] = [-1, 0, 1, 0, -1];

    const dfs = (i: number, j: number): number => {
        let sum = grid[i][j];
        grid[i][j] = 0;
        for (let d = 0; d < 4; ++d) {
            const x = i + dirs[d], y = j + dirs[d + 1];
            if (x >= 0 && x < m && y >= 0 && y < n && grid[x][y] > 0) {
                sum += dfs(x, y);
            }
        }
        return sum;
    };

    let ans = 0;
    for (let i = 0; i < m; ++i) {
        for (let j = 0; j < n; ++j) {
            if (grid[i][j] > 0 && dfs(i, j) % k === 0) {
                ++ans;
            }
        }
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，每个格子至多被访问一次。
- 空间复杂度：$O(mn)$，最坏情况下递归栈中需要保存整个岛屿的格子。
