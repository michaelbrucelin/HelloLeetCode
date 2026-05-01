### [网格中得分最大的路径](https://leetcode.cn/problems/maximum-path-score-in-a-grid/solutions/3958095/wang-ge-zhong-de-fen-zui-da-de-lu-jing-b-d2xa/)

#### 方法一：动态规划

**思路与算法**

题目要求我们在总花费不超过 $k$ 的情况下，找到一条从 $grid[0][0]$ 到 $grid[m-1][n-1]$ 的路径，使得获得的分数最大。这种有限制的最优化问题结构类似背包问题，可以用动态规划解决。

定义状态 $dp[i][j][c]$ 表示到达位置 $(i,j)$，当前花费为 $c$ 时的最大得分。

我们从当前格子向后转移，即从 $(i,j)$ 出发，可以向下或向右移动，将下一个格子的代价和分数加入：

- 向下：转移到 $(i+1,j)$
- 向右：转移到 $(i,j+1)$

状态转移为：

$$dp[i+1][j][c+cost(i+1,j)]=max(dp[i+1][j][c+cost(i+1,j)],dp[i][j][c]+grid[i+1][j])\\ dp[i][j+1][c+cost(i,j+1)]=max(dp[i][j+1][c+cost(i,j+1)],dp[i][j][c]+grid[i][j+1])$$

其中：

$$cost(i,j)=\begin{cases}1,grid[i][j]\ne 0 \\ 0,grid[i][j]=0\end{cases}$$

初始状态为 $dp[0][0][0]=0$（起点不计入得分和花费）。

最终答案为：

$$\mathop{max}\limits_{0\le c\le k}dp[m-1][n-1][c]$$

**代码**

```C++
class Solution {
public:
    int maxPathScore(vector<vector<int>>& grid, int k) {
        int m = grid.size();
        int n = grid[0].size();
        vector<vector<vector<int>>> dp(
            m, vector<vector<int>>(n, vector<int>(k + 1, INT_MIN)));
        dp[0][0][0] = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int c = 0; c <= k; c++) {
                    if (dp[i][j][c] == INT_MIN)
                        continue;
                    if (i + 1 < m) {
                        int val = grid[i + 1][j];
                        int cost = (val == 0 ? 0 : 1);
                        if (c + cost <= k) {
                            dp[i + 1][j][c + cost] =
                                max(dp[i + 1][j][c + cost], dp[i][j][c] + val);
                        }
                    }
                    if (j + 1 < n) {
                        int val = grid[i][j + 1];
                        int cost = (val == 0 ? 0 : 1);
                        if (c + cost <= k) {
                            dp[i][j + 1][c + cost] =
                                max(dp[i][j + 1][c + cost], dp[i][j][c] + val);
                        }
                    }
                }
            }
        }
        int ans = INT_MIN;
        for (int c = 0; c <= k; c++) {
            ans = max(ans, dp[m - 1][n - 1][c]);
        }
        return ans < 0 ? -1 : ans;
    }
};
```

```Java
class Solution {
    public int maxPathScore(int[][] grid, int k) {
        int m = grid.length;
        int n = grid[0].length;

        int[][][] dp = new int[m][n][k + 1];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                Arrays.fill(dp[i][j], Integer.MIN_VALUE);
            }
        }

        dp[0][0][0] = 0;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int c = 0; c <= k; c++) {
                    if (dp[i][j][c] == Integer.MIN_VALUE) continue;

                    if (i + 1 < m) {
                        int val = grid[i + 1][j];
                        int cost = (val == 0 ? 0 : 1);
                        if (c + cost <= k) {
                            dp[i + 1][j][c + cost] = Math.max(
                                dp[i + 1][j][c + cost],
                                dp[i][j][c] + val
                            );
                        }
                    }

                    if (j + 1 < n) {
                        int val = grid[i][j + 1];
                        int cost = (val == 0 ? 0 : 1);
                        if (c + cost <= k) {
                            dp[i][j + 1][c + cost] = Math.max(
                                dp[i][j + 1][c + cost],
                                dp[i][j][c] + val
                            );
                        }
                    }
                }
            }
        }

        int ans = Integer.MIN_VALUE;
        for (int c = 0; c <= k; c++) {
            ans = Math.max(ans, dp[m - 1][n - 1][c]);
        }

        return ans < 0 ? -1 : ans;
    }
}
```

```Python
class Solution:
    def maxPathScore(self, grid, k):
        m, n = len(grid), len(grid[0])

        INF = float('-inf')
        dp = [[[INF] * (k + 1) for _ in range(n)] for _ in range(m)]
        dp[0][0][0] = 0

        for i in range(m):
            for j in range(n):
                for c in range(k + 1):
                    if dp[i][j][c] == INF:
                        continue

                    if i + 1 < m:
                        val = grid[i + 1][j]
                        cost = 0 if val == 0 else 1
                        if c + cost <= k:
                            dp[i + 1][j][c + cost] = max(
                                dp[i + 1][j][c + cost],
                                dp[i][j][c] + val
                            )

                    if j + 1 < n:
                        val = grid[i][j + 1]
                        cost = 0 if val == 0 else 1
                        if c + cost <= k:
                            dp[i][j + 1][c + cost] = max(
                                dp[i][j + 1][c + cost],
                                dp[i][j][c] + val
                            )

        ans = max(dp[m - 1][n - 1])
        return -1 if ans < 0 else ans

```

```C
int maxPathScore(int** grid, int m, int* gridColSize, int k) {
    int n = gridColSize[0];

    int*** dp = (int***)malloc(m * sizeof(int**));
    for (int i = 0; i < m; i++) {
        dp[i] = (int**)malloc(n * sizeof(int*));
        for (int j = 0; j < n; j++) {
            dp[i][j] = (int*)malloc((k + 1) * sizeof(int));
            for (int c = 0; c <= k; c++) {
                dp[i][j][c] = INT_MIN;
            }
        }
    }

    dp[0][0][0] = 0;

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            for (int c = 0; c <= k; c++) {
                if (dp[i][j][c] == INT_MIN) continue;

                if (i + 1 < m) {
                    int val = grid[i + 1][j];
                    int cost = val == 0 ? 0 : 1;
                    if (c + cost <= k) {
                        int* target = &dp[i + 1][j][c + cost];
                        if (*target < dp[i][j][c] + val)
                            *target = dp[i][j][c] + val;
                    }
                }

                if (j + 1 < n) {
                    int val = grid[i][j + 1];
                    int cost = val == 0 ? 0 : 1;
                    if (c + cost <= k) {
                        int* target = &dp[i][j + 1][c + cost];
                        if (*target < dp[i][j][c] + val)
                            *target = dp[i][j][c] + val;
                    }
                }
            }
        }
    }

    int ans = INT_MIN;
    for (int c = 0; c <= k; c++) {
        if (dp[m - 1][n - 1][c] > ans)
            ans = dp[m - 1][n - 1][c];
    }

    return ans < 0 ? -1 : ans;
}
```

```Go
func maxPathScore(grid [][]int, k int) int {
    m, n := len(grid), len(grid[0])

    const INF = math.MinInt32

    dp := make([][][]int, m)
    for i := range dp {
        dp[i] = make([][]int, n)
        for j := range dp[i] {
            dp[i][j] = make([]int, k+1)
            for c := range dp[i][j] {
                dp[i][j][c] = INF
            }
        }
    }

    dp[0][0][0] = 0

    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            for c := 0; c <= k; c++ {
                if dp[i][j][c] == INF {
                    continue
                }

                if i+1 < m {
                    val := grid[i+1][j]
                    cost := 0
                    if val != 0 {
                        cost = 1
                    }
                    if c+cost <= k {
                        if dp[i+1][j][c+cost] < dp[i][j][c]+val {
                            dp[i+1][j][c+cost] = dp[i][j][c] + val
                        }
                    }
                }

                if j+1 < n {
                    val := grid[i][j+1]
                    cost := 0
                    if val != 0 {
                        cost = 1
                    }
                    if c+cost <= k {
                        if dp[i][j+1][c+cost] < dp[i][j][c]+val {
                            dp[i][j+1][c+cost] = dp[i][j][c] + val
                        }
                    }
                }
            }
        }
    }

    ans := INF
    for c := 0; c <= k; c++ {
        if dp[m-1][n-1][c] > ans {
            ans = dp[m-1][n-1][c]
        }
    }

    if ans < 0 {
        return -1
    }
    return ans
}
```

```CSharp
public class Solution {
    public int MaxPathScore(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;

        int[,,] dp = new int[m, n, k + 1];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                for (int c = 0; c <= k; c++)
                    dp[i, j, c] = int.MinValue;

        dp[0, 0, 0] = 0;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int c = 0; c <= k; c++) {
                    if (dp[i, j, c] == int.MinValue) continue;

                    if (i + 1 < m) {
                        int val = grid[i + 1][j];
                        int cost = val == 0 ? 0 : 1;
                        if (c + cost <= k) {
                            dp[i + 1, j, c + cost] = Math.Max(
                                dp[i + 1, j, c + cost],
                                dp[i, j, c] + val
                            );
                        }
                    }

                    if (j + 1 < n) {
                        int val = grid[i][j + 1];
                        int cost = val == 0 ? 0 : 1;
                        if (c + cost <= k) {
                            dp[i, j + 1, c + cost] = Math.Max(
                                dp[i, j + 1, c + cost],
                                dp[i, j, c] + val
                            );
                        }
                    }
                }
            }
        }

        int ans = int.MinValue;
        for (int c = 0; c <= k; c++) {
            ans = Math.Max(ans, dp[m - 1, n - 1, c]);
        }

        return ans < 0 ? -1 : ans;
    }
}
```

```JavaScript
var maxPathScore = function(grid, k) {
    const m = grid.length, n = grid[0].length;

    const INF = -Infinity;
    const dp = Array.from({ length: m }, () =>
        Array.from({ length: n }, () => Array(k + 1).fill(INF))
    );

    dp[0][0][0] = 0;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            for (let c = 0; c <= k; c++) {
                if (dp[i][j][c] === INF) continue;

                if (i + 1 < m) {
                    const val = grid[i + 1][j];
                    const cost = val === 0 ? 0 : 1;
                    if (c + cost <= k) {
                        dp[i + 1][j][c + cost] = Math.max(
                            dp[i + 1][j][c + cost],
                            dp[i][j][c] + val
                        );
                    }
                }

                if (j + 1 < n) {
                    const val = grid[i][j + 1];
                    const cost = val === 0 ? 0 : 1;
                    if (c + cost <= k) {
                        dp[i][j + 1][c + cost] = Math.max(
                            dp[i][j + 1][c + cost],
                            dp[i][j][c] + val
                        );
                    }
                }
            }
        }
    }

    let ans = Math.max(...dp[m - 1][n - 1]);
    return ans < 0 ? -1 : ans;
};
```

```TypeScript
function maxPathScore(grid: number[][], k: number): number {
    const m = grid.length, n = grid[0].length;

    const INF = -Infinity;
    const dp: number[][][] = Array.from({ length: m }, () =>
        Array.from({ length: n }, () => Array(k + 1).fill(INF))
    );

    dp[0][0][0] = 0;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            for (let c = 0; c <= k; c++) {
                if (dp[i][j][c] === INF) continue;

                if (i + 1 < m) {
                    const val = grid[i + 1][j];
                    const cost = val === 0 ? 0 : 1;
                    if (c + cost <= k) {
                        dp[i + 1][j][c + cost] = Math.max(
                            dp[i + 1][j][c + cost],
                            dp[i][j][c] + val
                        );
                    }
                }

                if (j + 1 < n) {
                    const val = grid[i][j + 1];
                    const cost = val === 0 ? 0 : 1;
                    if (c + cost <= k) {
                        dp[i][j + 1][c + cost] = Math.max(
                            dp[i][j + 1][c + cost],
                            dp[i][j][c] + val
                        );
                    }
                }
            }
        }
    }

    const ans = Math.max(...dp[m - 1][n - 1]);
    return ans < 0 ? -1 : ans;
}
```

```Rust
impl Solution {
    pub fn max_path_score(grid: Vec<Vec<i32>>, k: i32) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        let k = k as usize;

        let inf = i32::MIN / 2;
        let mut dp = vec![vec![vec![inf; k + 1]; n]; m];

        dp[0][0][0] = 0;

        for i in 0..m {
            for j in 0..n {
                for c in 0..=k {
                    if dp[i][j][c] == inf {
                        continue;
                    }

                    if i + 1 < m {
                        let val = grid[i + 1][j];
                        let cost = if val == 0 { 0 } else { 1 };
                        if c + cost <= k {
                            dp[i + 1][j][c + cost] =
                                dp[i + 1][j][c + cost].max(dp[i][j][c] + val);
                        }
                    }

                    if j + 1 < n {
                        let val = grid[i][j + 1];
                        let cost = if val == 0 { 0 } else { 1 };
                        if c + cost <= k {
                            dp[i][j + 1][c + cost] =
                                dp[i][j + 1][c + cost].max(dp[i][j][c] + val);
                        }
                    }
                }
            }
        }

        let mut ans = inf;
        for c in 0..=k {
            ans = ans.max(dp[m - 1][n - 1][c]);
        }

        if ans < 0 { -1 } else { ans }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mnk)$，其中 $m$，$n$ 分别是矩阵 $grid$ 的行数和列数。
- 空间复杂度：$O(mnk)$。
