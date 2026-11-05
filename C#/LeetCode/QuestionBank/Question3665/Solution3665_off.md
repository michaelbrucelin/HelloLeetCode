### [统计镜子反射路径数目](https://leetcode.cn/problems/twisted-mirror-path-count/solutions/4043260/tong-ji-jing-zi-fan-she-lu-jing-shu-mu-b-fg88/)

#### 方法一：动态规划

根据题意，无论网格中是否存在镜子，机器人始终只能向右或向下移动，因此机器人移动过程中不存在回路，状态之间具有天然的拓扑顺序，每个状态只依赖于其上方和左方的状态，因此可以使用动态规划进行求解。

先考虑一个更简单的情况，即网格中不存在镜子。

我们用 $f(i,j)$ 表示机器人从左上角 $(0,0)$ 移动到网格 $(i,j)$ 的路径数量，其中 $0\le i\le m-1, 0\le j\le n-1$。为了方便起见，下文提及的所有网格均为合法网格。

由于机器人每次只能向右或向下移动一步，因此要到达 $(i,j)$，只有以下两种方式：

- 从网格 $(i-1,j)$ 向下移动一步；
- 从网格 $(i,j-1)$ 向右移动一步。

上述两种情况互斥，根据加法原理，可得状态转移方程：

$$f(i,j)=f(i-1,j)+f(i,j-1)$$

下面考虑加入镜子后对状态转移的影响。

同样分析机器人到达 $(i,j)$ 的过程，上述两种转移方式分别变为：

- 从网格 $(i-1,j)$ 向下移动一步。这又分为两种情况：
    - 网格 $(i-1,j)$ 中没有镜子，此时无论机器人是从哪个方向进入该网格，都可以继续向下移动；
    - 网格 $(i-1,j)$ 中存在镜子，此时机器人只有**从右侧进入**网格 $(i-1,j)$ 时，才能被镜子反射并向下移动至 $(i,j)$。
- 从网格 $(i,j-1)$ 向右移动一步。同理：
    - 网格 $(i,j-1)$ 中没有镜子，此时机器人可以从任意方向进入；
    - 网格 $(i,j-1)$ 中存在镜子，此时机器人只有**从下侧进入**网格 $(i,j-1)$ 时，才能被镜子反射并向右移动至 $(i,j)$。

不难发现，仅记录到达某个网格的路径数量已经不足以完成状态转移，我们还需要知道机器人是从哪个方向进入该网格，因此需要增加状态维度。

我们定义 $f(i,j,k)$ 表示机器人从左上角 $(0,0)$ 移动到网格 $(i,j)$ 的路径数量，其中 $k$ 表示机器人**进入**该网格的方向。具体地：

- $f(i,j,0)$ 表示机器人通过**向下移动**进入网格 $(i,j)$ 的路径数量；
- $f(i,j,1)$ 表示机器人通过**向右移动**进入网格 $(i,j)$ 的路径数量。

需要注意的是，一旦确定了进入方向，机器人进入当前网格的前驱网格也随之唯一确定：若通过向右移动进入，则一定来自左侧网格 $(i,j-1)$；若通过向下移动进入，则一定来自上方网格 $(i-1,j)$。

根据上述分析，可以得到状态转移方程：

$$f(i,j,0)=\begin{cases}f(i-1,j,0)+f(i-1,j,1), & grid[i-1][j]=0 \\ f(i-1,j,1), & grid[i-1][j]=1\end{cases}$$

$$f(i,j,1)=\begin{cases}f(i,j-1,0)+f(i,j-1,1), & grid[i][j-1]=0 \\ f(i,j-1,0), & grid[i][j-1]=1\end{cases}$$

最终答案为：

$$f(m-1,n-1,0)+f(m-1,n-1,1)$$

题目保证起点满足 $grid[0][0]=0$。为了统一状态转移，我们可以将起点视为通过向下移动进入，初始条件为：

$$f(0,0,0)=1,f(0,0,1)=0.$$

当然我们也可以将起点视为通过向右移动进入，将初始条件设置为：

$$f(0,0,0)=0,f(0,0,1)=1.$$

上述的两个初始化条件均表示了唯一的一条初始路径，进而方便了后续状态转移，无需对第一行和第一列进行额外讨论。

**代码**

```C++
class Solution {
public:
    int uniquePaths(vector<vector<int>>& grid) {
        constexpr int MOD = 1'000'000'007;

        int m = grid.size();
        int n = grid[0].size();

        vector<vector<array<long long, 2>>> f(
            m, vector<array<long long, 2>>(n, {0, 0})
        );

        f[0][0][0] = 1;

        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i > 0) {
                    if (grid[i - 1][j] == 0) {
                        f[i][j][0] = (f[i - 1][j][0] + f[i - 1][j][1]) % MOD;
                    } else {
                        f[i][j][0] = f[i - 1][j][1];
                    }
                }

                if (j > 0) {
                    if (grid[i][j - 1] == 0) {
                        f[i][j][1] = (f[i][j - 1][0] + f[i][j - 1][1]) % MOD;
                    } else {
                        f[i][j][1] = f[i][j - 1][0];
                    }
                }
            }
        }

        return (f[m - 1][n - 1][0] + f[m - 1][n - 1][1]) % MOD;
    }
};
```

```Python
class Solution:
    def uniquePaths(self, grid: List[List[int]]) -> int:
        MOD = 10**9 + 7
        m, n = len(grid), len(grid[0])

        # f[i][j][0]：通过向下移动进入 (i, j)
        # f[i][j][1]：通过向右移动进入 (i, j)
        f = [[[0, 0] for _ in range(n)] for _ in range(m)]
        f[0][0][0] = 1

        for i in range(m):
            for j in range(n):
                if i > 0:
                    if grid[i - 1][j] == 0:
                        f[i][j][0] = f[i - 1][j][0] + f[i - 1][j][1]
                    else:
                        f[i][j][0] = f[i - 1][j][1]
                    f[i][j][0] %= MOD

                if j > 0:
                    if grid[i][j - 1] == 0:
                        f[i][j][1] = f[i][j - 1][0] + f[i][j - 1][1]
                    else:
                        f[i][j][1] = f[i][j - 1][0]
                    f[i][j][1] %= MOD

        return (f[m - 1][n - 1][0] + f[m - 1][n - 1][1]) % MOD
```

```Java
class Solution {
    public int uniquePaths(int[][] grid) {
        final int MOD = 1000000007;
        int m = grid.length;
        int n = grid[0].length;

        // f[i][j][0]：通过向下移动进入 (i, j)
        // f[i][j][1]：通过向右移动进入 (i, j)
        int[][][] f = new int[m][n][2];
        f[0][0][0] = 1;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i > 0) {
                    if (grid[i - 1][j] == 0) {
                        f[i][j][0] = (f[i - 1][j][0] + f[i - 1][j][1]) % MOD;
                    } else {
                        f[i][j][0] = f[i - 1][j][1];
                    }
                }

                if (j > 0) {
                    if (grid[i][j - 1] == 0) {
                        f[i][j][1] = (f[i][j - 1][0] + f[i][j - 1][1]) % MOD;
                    } else {
                        f[i][j][1] = f[i][j - 1][0];
                    }
                }
            }
        }

        return (f[m - 1][n - 1][0] + f[m - 1][n - 1][1]) % MOD;
    }
}
```

```CSharp
public class Solution {
    public int UniquePaths(int[][] grid) {
        const int MOD = 1000000007;
        int m = grid.Length;
        int n = grid[0].Length;

        // f[i][j][0]：通过向下移动进入 (i, j)
        // f[i][j][1]：通过向右移动进入 (i, j)
        int[,,] f = new int[m, n, 2];
        f[0, 0, 0] = 1;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i > 0) {
                    if (grid[i - 1][j] == 0) {
                        f[i, j, 0] = (f[i - 1, j, 0] + f[i - 1, j, 1]) % MOD;
                    } else {
                        f[i, j, 0] = f[i - 1, j, 1];
                    }
                }

                if (j > 0) {
                    if (grid[i][j - 1] == 0) {
                        f[i, j, 1] = (f[i, j - 1, 0] + f[i, j - 1, 1]) % MOD;
                    } else {
                        f[i, j, 1] = f[i, j - 1, 0];
                    }
                }
            }
        }

        return (f[m - 1, n - 1, 0] + f[m - 1, n - 1, 1]) % MOD;
    }
}
```

```Go
func uniquePaths(grid [][]int) int {
    const MOD = 1000000007
    m, n := len(grid), len(grid[0])

    // f[i][j][0]：通过向下移动进入 (i, j)
    // f[i][j][1]：通过向右移动进入 (i, j)
    f := make([][][2]int, m)
    for i := range f {
        f[i] = make([][2]int, n)
    }
    f[0][0][0] = 1

    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if i > 0 {
                if grid[i-1][j] == 0 {
                    f[i][j][0] = (f[i-1][j][0] + f[i-1][j][1]) % MOD
                } else {
                    f[i][j][0] = f[i-1][j][1]
                }
            }

            if j > 0 {
                if grid[i][j-1] == 0 {
                    f[i][j][1] = (f[i][j-1][0] + f[i][j-1][1]) % MOD
                } else {
                    f[i][j][1] = f[i][j-1][0]
                }
            }
        }
    }

    return (f[m-1][n-1][0] + f[m-1][n-1][1]) % MOD
}
```

```C
int uniquePaths(int** grid, int gridSize, int* gridColSize) {
    const int MOD = 1000000007;
    int m = gridSize;
    int n = gridColSize[0];

    // 动态分配三维数组 f[m][n][2]
    int*** f = (int***)malloc(m * sizeof(int**));
    for (int i = 0; i < m; i++) {
        f[i] = (int**)malloc(n * sizeof(int*));
        for (int j = 0; j < n; j++) {
            f[i][j] = (int*)calloc(2, sizeof(int));
        }
    }
    f[0][0][0] = 1;

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (i > 0) {
                if (grid[i - 1][j] == 0) {
                    f[i][j][0] = (f[i - 1][j][0] + f[i - 1][j][1]) % MOD;
                } else {
                    f[i][j][0] = f[i - 1][j][1];
                }
            }

            if (j > 0) {
                if (grid[i][j - 1] == 0) {
                    f[i][j][1] = (f[i][j - 1][0] + f[i][j - 1][1]) % MOD;
                } else {
                    f[i][j][1] = f[i][j - 1][0];
                }
            }
        }
    }

    int result = (f[m - 1][n - 1][0] + f[m - 1][n - 1][1]) % MOD;

    // 释放内存
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            free(f[i][j]);
        }
        free(f[i]);
    }
    free(f);

    return result;
}
```

```JavaScript
var uniquePaths = function(grid) {
    const MOD = 1000000007;
    const m = grid.length;
    const n = grid[0].length;

    // f[i][j][0]：通过向下移动进入 (i, j)
    // f[i][j][1]：通过向右移动进入 (i, j)
    const f = Array.from({ length: m }, () =>
        Array.from({ length: n }, () => [0, 0])
    );
    f[0][0][0] = 1;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i > 0) {
                if (grid[i - 1][j] === 0) {
                    f[i][j][0] = (f[i - 1][j][0] + f[i - 1][j][1]) % MOD;
                } else {
                    f[i][j][0] = f[i - 1][j][1];
                }
            }

            if (j > 0) {
                if (grid[i][j - 1] === 0) {
                    f[i][j][1] = (f[i][j - 1][0] + f[i][j - 1][1]) % MOD;
                } else {
                    f[i][j][1] = f[i][j - 1][0];
                }
            }
        }
    }

    return (f[m - 1][n - 1][0] + f[m - 1][n - 1][1]) % MOD;
};
```

```TypeScript
function uniquePaths(grid: number[][]): number {
    const MOD: number = 1000000007;
    const m: number = grid.length;
    const n: number = grid[0].length;

    // f[i][j][0]：通过向下移动进入 (i, j)
    // f[i][j][1]：通过向右移动进入 (i, j)
    const f: number[][][] = Array.from({ length: m }, () =>
        Array.from({ length: n }, () => [0, 0])
    );
    f[0][0][0] = 1;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i > 0) {
                if (grid[i - 1][j] === 0) {
                    f[i][j][0] = (f[i - 1][j][0] + f[i - 1][j][1]) % MOD;
                } else {
                    f[i][j][0] = f[i - 1][j][1];
                }
            }

            if (j > 0) {
                if (grid[i][j - 1] === 0) {
                    f[i][j][1] = (f[i][j - 1][0] + f[i][j - 1][1]) % MOD;
                } else {
                    f[i][j][1] = f[i][j - 1][0];
                }
            }
        }
    }

    return (f[m - 1][n - 1][0] + f[m - 1][n - 1][1]) % MOD;
}
```

```Rust
impl Solution {
    pub fn unique_paths(grid: Vec<Vec<i32>>) -> i32 {
        const MOD: i32 = 1_000_000_007;
        let m = grid.len();
        let n = grid[0].len();

        // f[i][j][0]：通过向下移动进入 (i, j)
        // f[i][j][1]：通过向右移动进入 (i, j)
        let mut f = vec![vec![[0, 0]; n]; m];
        f[0][0][0] = 1;

        for i in 0..m {
            for j in 0..n {
                if i > 0 {
                    if grid[i - 1][j] == 0 {
                        f[i][j][0] = (f[i - 1][j][0] + f[i - 1][j][1]) % MOD;
                    } else {
                        f[i][j][0] = f[i - 1][j][1];
                    }
                }

                if j > 0 {
                    if grid[i][j - 1] == 0 {
                        f[i][j][1] = (f[i][j - 1][0] + f[i][j - 1][1]) % MOD;
                    } else {
                        f[i][j][1] = f[i][j - 1][0];
                    }
                }
            }
        }

        (f[m - 1][n - 1][0] + f[m - 1][n - 1][1]) % MOD
    }
}
```

此外，由于 $f(i,j)$ 仅与第 $i$ 行和第 $i-1$ 行的状态有关，因此我们可以使用滚动数组代替代码中的二维数组，使空间复杂度降低为 $O(n)$。

```C++
class Solution {
public:
    int uniquePaths(vector<vector<int>>& grid) {
        const int MOD = 1'000'000'007;
        int m = grid.size(), n = grid[0].size();

        vector<array<long long, 2>> f(n, {0, 0});
        f[0][0] = 1;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i > 0) {
                    if (grid[i - 1][j] == 0) {
                        f[j][0] = (f[j][0] + f[j][1]) % MOD;
                    } else {
                        f[j][0] = f[j][1];
                    }
                }

                if (j > 0) {
                    if (grid[i][j - 1] == 0) {
                        f[j][1] = (f[j - 1][0] + f[j - 1][1]) % MOD;
                    } else {
                        f[j][1] = f[j - 1][0];
                    }
                }
            }
        }

        return (f[n - 1][0] + f[n - 1][1]) % MOD;
    }
};
```

```Python
class Solution:
    def uniquePaths(self, grid: List[List[int]]) -> int:
        MOD = 10**9 + 7
        m, n = len(grid), len(grid[0])

        f = [[0, 0] for _ in range(n)]
        f[0][0] = 1

        for i in range(m):
            for j in range(n):
                if i > 0:
                    if grid[i - 1][j] == 0:
                        f[j][0] = (f[j][0] + f[j][1]) % MOD
                    else:
                        f[j][0] = f[j][1]

                if j > 0:
                    if grid[i][j - 1] == 0:
                        f[j][1] = (f[j - 1][0] + f[j - 1][1]) % MOD
                    else:
                        f[j][1] = f[j - 1][0]

        return (f[-1][0] + f[-1][1]) % MOD
```

```Java
class Solution {
    public int uniquePaths(int[][] grid) {
        final int MOD = 1000000007;
        int m = grid.length;
        int n = grid[0].length;

        // f[j][0]：通过向下移动进入当前列
        // f[j][1]：通过向右移动进入当前列
        long[][] f = new long[n][2];
        f[0][0] = 1;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i > 0) {
                    if (grid[i - 1][j] == 0) {
                        f[j][0] = (f[j][0] + f[j][1]) % MOD;
                    } else {
                        f[j][0] = f[j][1];
                    }
                }

                if (j > 0) {
                    if (grid[i][j - 1] == 0) {
                        f[j][1] = (f[j - 1][0] + f[j - 1][1]) % MOD;
                    } else {
                        f[j][1] = f[j - 1][0];
                    }
                }
            }
        }

        return (int)((f[n - 1][0] + f[n - 1][1]) % MOD);
    }
}
```

```CSharp
public class Solution {
    public int UniquePaths(int[][] grid) {
        const int MOD = 1000000007;
        int m = grid.Length;
        int n = grid[0].Length;

        // f[j][0]：通过向下移动进入当前列
        // f[j][1]：通过向右移动进入当前列
        long[][] f = new long[n][];
        for (int j = 0; j < n; j++) {
            f[j] = new long[2];
        }
        f[0][0] = 1;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i > 0) {
                    if (grid[i - 1][j] == 0) {
                        f[j][0] = (f[j][0] + f[j][1]) % MOD;
                    } else {
                        f[j][0] = f[j][1];
                    }
                }

                if (j > 0) {
                    if (grid[i][j - 1] == 0) {
                        f[j][1] = (f[j - 1][0] + f[j - 1][1]) % MOD;
                    } else {
                        f[j][1] = f[j - 1][0];
                    }
                }
            }
        }

        return (int)((f[n - 1][0] + f[n - 1][1]) % MOD);
    }
}
```

```Go
func uniquePaths(grid [][]int) int {
    const MOD = 1000000007
    m, n := len(grid), len(grid[0])

    // f[j][0]：通过向下移动进入当前列
    // f[j][1]：通过向右移动进入当前列
    f := make([][2]int64, n)
    f[0][0] = 1

    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if i > 0 {
                if grid[i-1][j] == 0 {
                    f[j][0] = (f[j][0] + f[j][1]) % MOD
                } else {
                    f[j][0] = f[j][1]
                }
            }

            if j > 0 {
                if grid[i][j-1] == 0 {
                    f[j][1] = (f[j-1][0] + f[j-1][1]) % MOD
                } else {
                    f[j][1] = f[j-1][0]
                }
            }
        }
    }

    return int((f[n-1][0] + f[n-1][1]) % MOD)
}
```

```C
int uniquePaths(int** grid, int gridSize, int* gridColSize) {
    const int MOD = 1000000007;
    int m = gridSize;
    int n = gridColSize[0];

    // 动态分配二维数组 f[n][2]
    int64_t** f = (int64_t**)malloc(n * sizeof(int64_t*));
    for (int j = 0; j < n; j++) {
        f[j] = (int64_t*)calloc(2, sizeof(int64_t));
    }
    f[0][0] = 1;

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (i > 0) {
                if (grid[i - 1][j] == 0) {
                    f[j][0] = (f[j][0] + f[j][1]) % MOD;
                } else {
                    f[j][0] = f[j][1];
                }
            }

            if (j > 0) {
                if (grid[i][j - 1] == 0) {
                    f[j][1] = (f[j - 1][0] + f[j - 1][1]) % MOD;
                } else {
                    f[j][1] = f[j - 1][0];
                }
            }
        }
    }

    int result = (int)((f[n - 1][0] + f[n - 1][1]) % MOD);
    for (int j = 0; j < n; j++) {
        free(f[j]);
    }
    free(f);

    return result;
}
```

```JavaScript
var uniquePaths = function(grid) {
    const MOD = 1000000007;
    const m = grid.length;
    const n = grid[0].length;

    // f[j][0]：通过向下移动进入当前列
    // f[j][1]：通过向右移动进入当前列
    const f = Array.from({ length: n }, () => [0, 0]);
    f[0][0] = 1;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i > 0) {
                if (grid[i - 1][j] === 0) {
                    f[j][0] = (f[j][0] + f[j][1]) % MOD;
                } else {
                    f[j][0] = f[j][1];
                }
            }

            if (j > 0) {
                if (grid[i][j - 1] === 0) {
                    f[j][1] = (f[j - 1][0] + f[j - 1][1]) % MOD;
                } else {
                    f[j][1] = f[j - 1][0];
                }
            }
        }
    }

    return (f[n - 1][0] + f[n - 1][1]) % MOD;
};
```

```TypeScript
function uniquePaths(grid: number[][]): number {
    const MOD: number = 1000000007;
    const m: number = grid.length;
    const n: number = grid[0].length;

    // f[j][0]：通过向下移动进入当前列
    // f[j][1]：通过向右移动进入当前列
    const f: number[][] = Array.from({ length: n }, () => [0, 0]);
    f[0][0] = 1;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i > 0) {
                if (grid[i - 1][j] === 0) {
                    f[j][0] = (f[j][0] + f[j][1]) % MOD;
                } else {
                    f[j][0] = f[j][1];
                }
            }

            if (j > 0) {
                if (grid[i][j - 1] === 0) {
                    f[j][1] = (f[j - 1][0] + f[j - 1][1]) % MOD;
                } else {
                    f[j][1] = f[j - 1][0];
                }
            }
        }
    }

    return (f[n - 1][0] + f[n - 1][1]) % MOD;
}
```

```Rust
impl Solution {
    pub fn unique_paths(grid: Vec<Vec<i32>>) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let m = grid.len();
        let n = grid[0].len();

        // f[j][0]：通过向下移动进入当前列
        // f[j][1]：通过向右移动进入当前列
        let mut f = vec![[0i64, 0i64]; n];
        f[0][0] = 1;

        for i in 0..m {
            for j in 0..n {
                if i > 0 {
                    if grid[i - 1][j] == 0 {
                        f[j][0] = (f[j][0] + f[j][1]) % MOD;
                    } else {
                        f[j][0] = f[j][1];
                    }
                }

                if j > 0 {
                    if grid[i][j - 1] == 0 {
                        f[j][1] = (f[j - 1][0] + f[j - 1][1]) % MOD;
                    } else {
                        f[j][1] = f[j - 1][0];
                    }
                }
            }
        }

        ((f[n - 1][0] + f[n - 1][1]) % MOD) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别为网格的行数和列数。动态规划过程中，每个网格最多计算 $2$ 次状态转移，因此总时间复杂度为 $O(mn)$。
- 空间复杂度：$O(mn)$。动态规划数组 $f$ 需要维护每个网格的两个状态，因此需要 $O(2mn)$ 的空间，忽略常数因子后的空间复杂度为 $O(mn)$。使用滚动数组优化后，空间复杂度为 $O(n)$。
