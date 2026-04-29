### [网格图操作后的最大分数](https://leetcode.cn/problems/maximum-score-from-grid-operations/solutions/3957462/wang-ge-tu-cao-zuo-hou-de-zui-da-fen-shu-jsfi/)

#### 方法一：动态规划

**思路与算法**

如无特殊说明，以下涉及矩阵下标的地方全部采用以 $1$ 为起点。即，设给定方阵的维数是 $n$，则左上角第一个元素的下标是 $(1,1)$，所在的行为第 $1$ 行，所在的列为第 $1$ 列；右下角的最后一个元素是 $(n,n)$，所在的行为第 $n$ 行，所在的列为第 $n$ 列。

**从 $O(n^4)$ 的动态规划开始**

由题意易知，经过任意次操作后，每一列的最终状态一定是上黑下白，可以形式化描述为：将每一列看作长度为 $n$ 的数组，则该数组前 $i$ 个元素为黑色元素，后 $n-i$ 个元素为白色元素，其中 $0\le i\le n$。

由于每一列的状态可以用染色的分界点来描述，此时每列的得分只与其前一列和后一列的状态相关，故考虑使用动态规划求解。

首先使用前缀和预处理每一列的积分，我们下面用 $S_{i,j}$ 表示第 $i$ 列前 $j$ 个元素的前缀和，其中 $0\le j\le n$。然后设状态 $dp[i][h_{curr}][h_{prev}]$ 表示处理到第 $i$ 列，将第 $i$ 列的前 $h_{curr}$ 个元素染成黑色，第 $i-1$ 列的前 $h_{prev}$ 个元素染成黑色时，前 $i$ 列的最大得分。那么我们可以通过以下方式来推导状态方程的转移：

- 当前状态 $dp[i]$ 定义了第 $i$ 列和第 $i-1$ 列的染色情况，相当于我们已经固定了 $dp[i-1]$ 状态中的 $h_{curr}$，因此我们可以枚举 $dp[i-1]$ 状态的 $h_{prev}$，即枚举 $i-2$ 列的染色情况，这样因为我们相当于得到了三个相邻列的染色信息，从而推导出新的状态的最大得分。
- 当 $h_{curr}\le h_{prev}$ 时，说当前列的黑色元素比前一列低，此时从前一个状态推过来时需要加上本列新增的得分，如下图蓝色区域所示：
  ![](./assets/img/Solution3225_01.png)
- 当 $h_{curr}>h_{prev}$ 时，说明当前列的黑色元素比前一列高，此时根据前一个状态的 $h_{prev}$ 取值（设为 $k$），存在以下三种情况：
  - 情况一：$k$ 小于 $h_{prev}$，需要补充 $h_{curr}$ 新覆盖的蓝色部分的得分，如下图所示：
    ![](./assets/img/Solution3225_02.png)
  - 情况二：$k$ 大于 $h_{prev}$ 但是小于 $h_{curr}$，此时我们仍然需要补充上 $h_{curr}$ 新覆盖的蓝色区域部分的得分，只是不需要计算之前已经覆盖的黄色区域部分，如下图所示：
    ![](./assets/img/Solution3225_03.png)
  - 情况三：$k$ 大于 $h_{curr}$，此时 $h_{curr}$ 不能贡献新的得分，直接使用旧状态转移，如下图所示：
    ![](./assets/img/Solution3225_03.png)

最终我们得到的状态转移方程如下：

$$dp[i][h_{curr}][h_{prev}]=\begin{cases}
    \mathop{max}\limits_{0\le k\le n}\{dp[i-1][h_{prev}][k]\}+S_{i,h_{prev}}-S_{i,h_{curr}}, & h_{curr}\le h_{prev} \\
    \mathop{max}\limits_{0\le k\le n}\{dp[i-1][h_{prev}][k]+max(0,S_{i-1,h_{curr}}-S_{i-1,max(h_{prev},k)})\}, & h_{curr}>h_{prev}
\end{cases}$$

最后还需要注意首列和最后一列的特殊处理：

- 在处理第一轮状态转移时，由于前一个状态的 $h_{prev}$ 对应的是不存在的第 $0$ 列，该列的染色高度应强制视为 $0$，即只允许此时的 $k$ 取 $0$。
- 对于最后一列，通过简单观察可以发现，最优值一定在全黑或者全白两种情况中取得。因为在固定前一列的情况下，变更最后一列的染色方案不会再对后续列产生影响，为了让得分最大化，我们要么尽可能不染色第 $n$ 列，以让 $n-1$ 列覆盖尽可能多的第 $n$ 列元素；要么尽可能染色第 $n$ 列，让其覆盖尽可能多的 $n-1$ 列元素，故极值一定在端点处产生。

**优化 $h_{prev}$ 状态**

按照上述转移方程，最终算法的时间复杂度是 $O(n^4)$，无法通过此题，故尝试优化掉状态更新时对 $k$ 的枚举（作为 $i-2$ 列的染色高度）。观察原先的转移方程，容易发现以下关键事实：

当 $h_{curr}\le h_{prev}$ 时，实际上我们不会更改 $i-1$ 列的得分，转移后的取值只是前一个状态 $dp[i-1]$ 在固定 $h_{prev}$ 情况下的最大值，再加上固定的新增分数得到，即我们只需要知道 $\mathop{max}\limits_{0\le k\le n}{dp[i-1][h_{prev}][k]}$ 就可以 $O(1)$ 转移。

顺着这个思路，继续考虑 $h_{curr}>h_{prev}$ 的情况能否也使状态转移方程与 $k$ 无关，从而允许我们预处理最大值来执行 $O(1)$ 的状态更新。我们会发现关键分界点在于 $k$ 是否大于 $h_{curr}$：

当 $k\le h_{curr}$ 时，我们无论如何都会给 $i-1$ 列加上 $h_{curr}$ 高出 $h_{prev}$ 这部分拿到的额外分数。之前为了不重复统计，我们是补上了之前漏加的分数（对应情况二）。这里我们换一种思路，维护一个**不含 $i-1$ 列得分的前缀最大值**，设 $prevMax[h_{prev}][j]$ 代表 $i-1$ 列的高度为 $h_{prev}$ 时，前一个状态 $dp[i-1][h_{prev}]$ 不含 $i-1$ 列得分的前缀最大值：

$$prevMax[h_{prev}][j]=\mathop{max}\limits_{0\le k\le j}\{dp[i-1][h_{prev}][k]-max(0,S_{i-1,k}-S_{i-1,h_{prev}})\}$$

这时候情况转化为和 $h_{curr}\le h_{prev}$ 时类似的状态：由于**额外加上的分数已经和 $k$ 的取值无关**，我们只需要使用 $prevMax[h_{prev}][h_{curr}]$ 加上额外得分 $S_{i-1,h_{curr}}-S_{i-1,h_{prev}}$ 即可在 $O(1)$ 的时间转移状态方程！

同理，当 $k>h_{curr}$ 时，对应之前的情况三，由于没有额外加上的分数，它也天然满足和 $k$ 无关，只需要维护前一个状态的后缀最大值 $prevSuffixMax$ 即可：

$$prevSuffixMax[h_{prev}][j]=\mathop{max}\limits_{j\le k\le n}\{dp[i-1][h_{prev}][k]\}$$

得到最终的状态转移方程如下：

$$dp[i][h_{curr}][h_{prev}]=\begin{cases}
    prevSuffixMax[h_{prev}][0]+S_{i,h_{prev}}-S_{i,h_{curr}}, & h_{curr}\le h_{prev} \\
    max(prevSuffixMax[h_{prev}][h_{curr}],prevMax[h_{prev}][h_{curr}]+S_{i-1,h_{curr}}-S_{i-1,h_{prev}}), & h_{curr}>h_{prev}
\end{cases}$$

**代码**

```C++
using vll = std::vector<long long>;

class Solution {
public:
    long long maximumScore(vector<vector<int>>& grid) {
        int n = grid[0].size();
        if (n == 1) {
            return 0;
        }

        vector<vector<vll>> dp(n, vector<vll>(n + 1, vll(n + 1, 0)));
        vector<vll> prevMax(n + 1, vll(n + 1, 0));
        vector<vll> prevSuffixMax(n + 1, vll(n + 1, 0));
        vector<vll> colSum(n, vll(n + 1, 0));

        for (int c = 0; c < n; c++) {
            for (int r = 1; r <= n; r++) {
                colSum[c][r] = colSum[c][r - 1] + grid[r - 1][c];
            }
        }

        for (int i = 1; i < n; i++) {
            for (int currH = 0; currH <= n; currH++) {
                for (int prevH = 0; prevH <= n; prevH++) {
                    if (currH <= prevH) {
                        long long extraScore = colSum[i][prevH] - colSum[i][currH];
                        dp[i][currH][prevH] = std::max(dp[i][currH][prevH], prevSuffixMax[prevH][0] + extraScore);
                    } else {
                        long long extraScore = colSum[i - 1][currH] - colSum[i - 1][prevH];
                        dp[i][currH][prevH] = std::max({dp[i][currH][prevH], prevSuffixMax[prevH][currH], prevMax[prevH][currH] + extraScore});
                    }
                }
            }

            for (int currH = 0; currH <= n; currH++) {
                prevMax[currH][0] = dp[i][currH][0];
                for (int prevH = 1; prevH <= n; prevH++) {
                    long long penalty = (prevH > currH) ? (colSum[i][prevH] - colSum[i][currH]) : 0;
                    prevMax[currH][prevH] = std::max(prevMax[currH][prevH - 1], dp[i][currH][prevH] - penalty);
                }

                prevSuffixMax[currH][n] = dp[i][currH][n];
                for (int prevH = n - 1; prevH >= 0; prevH--) {
                    prevSuffixMax[currH][prevH] = std::max(prevSuffixMax[currH][prevH + 1], dp[i][currH][prevH]);
                }
            }
        }

        long long ans = 0;
        for (int k = 0; k <= n; k++) {
            ans = std::max({ans, dp[n - 1][n][k], dp[n - 1][0][k]});
        }

        return ans;
    }
};
```

```Java
class Solution {
    public long maximumScore(int[][] grid) {
        int n = grid[0].length;
        if (n == 1) {
            return 0;
        }

        long[][][] dp = new long[n][n + 1][n + 1];
        long[][] prevMax = new long[n + 1][n + 1];
        long[][] prevSuffixMax = new long[n + 1][n + 1];
        long[][] colSum = new long[n][n + 1];

        for (int c = 0; c < n; c++) {
            for (int r = 1; r <= n; r++) {
                colSum[c][r] = colSum[c][r - 1] + grid[r - 1][c];
            }
        }

        for (int i = 1; i < n; i++) {
            for (int currH = 0; currH <= n; currH++) {
                for (int prevH = 0; prevH <= n; prevH++) {
                    if (currH <= prevH) {
                        long extraScore = colSum[i][prevH] - colSum[i][currH];
                        dp[i][currH][prevH] = Math.max(dp[i][currH][prevH], prevSuffixMax[prevH][0] + extraScore);
                    } else {
                        long extraScore = colSum[i - 1][currH] - colSum[i - 1][prevH];
                        dp[i][currH][prevH] = Math.max(dp[i][currH][prevH],
                                              Math.max(prevSuffixMax[prevH][currH], prevMax[prevH][currH] + extraScore));
                    }
                }
            }

            for (int currH = 0; currH <= n; currH++) {
                prevMax[currH][0] = dp[i][currH][0];
                for (int prevH = 1; prevH <= n; prevH++) {
                    long penalty = (prevH > currH) ? (colSum[i][prevH] - colSum[i][currH]) : 0;
                    prevMax[currH][prevH] = Math.max(prevMax[currH][prevH - 1], dp[i][currH][prevH] - penalty);
                }

                prevSuffixMax[currH][n] = dp[i][currH][n];
                for (int prevH = n - 1; prevH >= 0; prevH--) {
                    prevSuffixMax[currH][prevH] = Math.max(prevSuffixMax[currH][prevH + 1], dp[i][currH][prevH]);
                }
            }
        }

        long ans = 0;
        for (int k = 0; k <= n; k++) {
            ans = Math.max(ans, Math.max(dp[n - 1][n][k], dp[n - 1][0][k]));
        }

        return ans;
    }
}
```

```C
long long maximumScore(int** grid, int gridSize, int* gridColSize) {
    int n = gridColSize[0];
    if (n == 1) {
        return 0;
    }

    long long*** dp = (long long***)malloc(n * sizeof(long long**));
    for (int i = 0; i < n; i++) {
        dp[i] = (long long**)malloc((n + 1) * sizeof(long long*));
        for (int j = 0; j <= n; j++) {
            dp[i][j] = (long long*)calloc(n + 1, sizeof(long long));
        }
    }

    long long** prevMax = (long long**)malloc((n + 1) * sizeof(long long*));
    for (int i = 0; i <= n; i++) {
        prevMax[i] = (long long*)calloc(n + 1, sizeof(long long));
    }
    long long** prevSuffixMax = (long long**)malloc((n + 1) * sizeof(long long*));
    for (int i = 0; i <= n; i++) {
        prevSuffixMax[i] = (long long*)calloc(n + 1, sizeof(long long));
    }
    long long** colSum = (long long**)malloc(n * sizeof(long long*));
    for (int c = 0; c < n; c++) {
        colSum[c] = (long long*)calloc(n + 1, sizeof(long long));
        for (int r = 1; r <= n; r++) {
            colSum[c][r] = colSum[c][r - 1] + grid[r - 1][c];
        }
    }

    for (int i = 1; i < n; i++) {
        for (int currH = 0; currH <= n; currH++) {
            for (int prevH = 0; prevH <= n; prevH++) {
                if (currH <= prevH) {
                    long long extraScore = colSum[i][prevH] - colSum[i][currH];
                    dp[i][currH][prevH] = fmax(dp[i][currH][prevH], prevSuffixMax[prevH][0] + extraScore);
                } else {
                    long long extraScore = colSum[i - 1][currH] - colSum[i - 1][prevH];
                    dp[i][currH][prevH] = fmax(dp[i][currH][prevH],
                        fmax(prevSuffixMax[prevH][currH], prevMax[prevH][currH] + extraScore));
                }
            }
        }

        for (int currH = 0; currH <= n; currH++) {
            prevMax[currH][0] = dp[i][currH][0];
            for (int prevH = 1; prevH <= n; prevH++) {
                long long penalty = (prevH > currH) ? (colSum[i][prevH] - colSum[i][currH]) : 0;
                prevMax[currH][prevH] = fmax(prevMax[currH][prevH - 1], dp[i][currH][prevH] - penalty);
            }

            prevSuffixMax[currH][n] = dp[i][currH][n];
            for (int prevH = n - 1; prevH >= 0; prevH--) {
                prevSuffixMax[currH][prevH] = fmax(prevSuffixMax[currH][prevH + 1], dp[i][currH][prevH]);
            }
        }
    }

    long long ans = 0;
    for (int k = 0; k <= n; k++) {
        ans = fmax(ans, fmax(dp[n - 1][n][k], dp[n - 1][0][k]));
    }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j <= n; j++) {
            free(dp[i][j]);
        }
        free(dp[i]);
    }
    free(dp);

    for (int i = 0; i <= n; i++) {
        free(prevMax[i]);
        free(prevSuffixMax[i]);
    }
    free(prevMax);
    free(prevSuffixMax);

    for (int c = 0; c < n; c++) {
        free(colSum[c]);
    }
    free(colSum);

    return ans;
}
```

```Python
class Solution:
    def maximumScore(self, grid: List[List[int]]) -> int:
        n = len(grid[0])
        if n == 1:
            return 0

        dp = [[[0] * (n + 1) for _ in range(n + 1)] for _ in range(n)]
        prev_max = [[0] * (n + 1) for _ in range(n + 1)]
        prev_suffix_max = [[0] * (n + 1) for _ in range(n + 1)]
        col_sum = [[0] * (n + 1) for _ in range(n)]

        for c in range(n):
            for r in range(1, n + 1):
                col_sum[c][r] = col_sum[c][r - 1] + grid[r - 1][c]

        for i in range(1, n):
            for curr_h in range(n + 1):
                for prev_h in range(n + 1):
                    if curr_h <= prev_h:
                        extra_score = col_sum[i][prev_h] - col_sum[i][curr_h]
                        dp[i][curr_h][prev_h] = max(
                            dp[i][curr_h][prev_h],
                            prev_suffix_max[prev_h][0] + extra_score
                        )
                    else:
                        extra_score = col_sum[i - 1][curr_h] - col_sum[i - 1][prev_h]
                        dp[i][curr_h][prev_h] = max(
                            dp[i][curr_h][prev_h],
                            prev_suffix_max[prev_h][curr_h],
                            prev_max[prev_h][curr_h] + extra_score
                        )

            for curr_h in range(n + 1):
                prev_max[curr_h][0] = dp[i][curr_h][0]
                for prev_h in range(1, n + 1):
                    penalty = col_sum[i][prev_h] - col_sum[i][curr_h] if prev_h > curr_h else 0
                    prev_max[curr_h][prev_h] = max(
                        prev_max[curr_h][prev_h - 1],
                        dp[i][curr_h][prev_h] - penalty
                    )

                prev_suffix_max[curr_h][n] = dp[i][curr_h][n]
                for prev_h in range(n - 1, -1, -1):
                    prev_suffix_max[curr_h][prev_h] = max(
                        prev_suffix_max[curr_h][prev_h + 1],
                        dp[i][curr_h][prev_h]
                    )

        ans = 0
        for k in range(n + 1):
            ans = max(ans, dp[n - 1][n][k], dp[n - 1][0][k])

        return ans
```

```CSharp
public class Solution {
    public long MaximumScore(int[][] grid) {
        int n = grid[0].Length;
        if (n == 1) {
            return 0;
        }

        long[,,] dp = new long[n, n + 1, n + 1];
        long[,] prevMax = new long[n + 1, n + 1];
        long[,] prevSuffixMax = new long[n + 1, n + 1];
        long[,] colSum = new long[n, n + 1];

        for (int c = 0; c < n; c++) {
            for (int r = 1; r <= n; r++) {
                colSum[c, r] = colSum[c, r - 1] + grid[r - 1][c];
            }
        }

        for (int i = 1; i < n; i++) {
            for (int currH = 0; currH <= n; currH++) {
                for (int prevH = 0; prevH <= n; prevH++) {
                    if (currH <= prevH) {
                        long extraScore = colSum[i, prevH] - colSum[i, currH];
                        dp[i, currH, prevH] = Math.Max(
                            dp[i, currH, prevH],
                            prevSuffixMax[prevH, 0] + extraScore
                        );
                    } else {
                        long extraScore = colSum[i - 1, currH] - colSum[i - 1, prevH];
                        dp[i, currH, prevH] = Math.Max(
                            dp[i, currH, prevH],
                            Math.Max(
                                prevSuffixMax[prevH, currH],
                                prevMax[prevH, currH] + extraScore
                            )
                        );
                    }
                }
            }

            for (int currH = 0; currH <= n; currH++) {
                prevMax[currH, 0] = dp[i, currH, 0];
                for (int prevH = 1; prevH <= n; prevH++) {
                    long penalty = (prevH > currH) ? (colSum[i, prevH] - colSum[i, currH]) : 0;
                    prevMax[currH, prevH] = Math.Max(
                        prevMax[currH, prevH - 1],
                        dp[i, currH, prevH] - penalty
                    );
                }

                prevSuffixMax[currH, n] = dp[i, currH, n];
                for (int prevH = n - 1; prevH >= 0; prevH--) {
                    prevSuffixMax[currH, prevH] = Math.Max(
                        prevSuffixMax[currH, prevH + 1],
                        dp[i, currH, prevH]
                    );
                }
            }
        }

        long ans = 0;
        for (int k = 0; k <= n; k++) {
            ans = Math.Max(ans, Math.Max(dp[n - 1, n, k], dp[n - 1, 0, k]));
        }

        return ans;
    }
}
```

```Go
func maximumScore(grid [][]int) int64 {
    n := len(grid[0])
    if n == 1 {
        return 0
    }

    dp := make([][][]int64, n)
    for i := range dp {
        dp[i] = make([][]int64, n+1)
        for j := range dp[i] {
            dp[i][j] = make([]int64, n+1)
        }
    }

    prevMax := make([][]int64, n+1)
    for i := range prevMax {
        prevMax[i] = make([]int64, n+1)
    }
    prevSuffixMax := make([][]int64, n+1)
    for i := range prevSuffixMax {
        prevSuffixMax[i] = make([]int64, n+1)
    }

    colSum := make([][]int64, n)
    for c := 0; c < n; c++ {
        colSum[c] = make([]int64, n+1)
        for r := 1; r <= n; r++ {
            colSum[c][r] = colSum[c][r-1] + int64(grid[r-1][c])
        }
    }

    for i := 1; i < n; i++ {
        for currH := 0; currH <= n; currH++ {
            for prevH := 0; prevH <= n; prevH++ {
                if currH <= prevH {
                    extraScore := colSum[i][prevH] - colSum[i][currH]
                    dp[i][currH][prevH] = max(dp[i][currH][prevH], prevSuffixMax[prevH][0]+extraScore)
                } else {
                    extraScore := colSum[i-1][currH] - colSum[i-1][prevH]
                    dp[i][currH][prevH] = max(dp[i][currH][prevH],
                        max(prevSuffixMax[prevH][currH], prevMax[prevH][currH]+extraScore))
                }
            }
        }

        for currH := 0; currH <= n; currH++ {
            prevMax[currH][0] = dp[i][currH][0]
            for prevH := 1; prevH <= n; prevH++ {
                var penalty int64 = 0
                if prevH > currH {
                    penalty = colSum[i][prevH] - colSum[i][currH]
                }
                prevMax[currH][prevH] = max(prevMax[currH][prevH-1], dp[i][currH][prevH]-penalty)
            }

            prevSuffixMax[currH][n] = dp[i][currH][n]
            for prevH := n - 1; prevH >= 0; prevH-- {
                prevSuffixMax[currH][prevH] = max(prevSuffixMax[currH][prevH+1], dp[i][currH][prevH])
            }
        }
    }

    var ans int64 = 0
    for k := 0; k <= n; k++ {
        ans = max(ans, max(dp[n-1][n][k], dp[n-1][0][k]))
    }

    return ans
}
```

```JavaScript
var maximumScore = function (grid) {
    const n = grid[0].length;
    if (n === 1) {
        return 0;
    }

    const dp = [];
    const prevMax = Array.from({ length: n + 1 }, () => new Array(n + 1).fill(0));
    const prevSuffixMax = Array.from({ length: n + 1 }, () => new Array(n + 1).fill(0));
    const colSum = Array.from({ length: n }, () => new Array(n + 1).fill(0));

    for (let c = 0; c < n; c++) {
        dp[c] = Array.from({ length: n + 1 }, () => new Array(n + 1).fill(0));

        for (let r = 1; r <= n; r++) {
            colSum[c][r] = colSum[c][r - 1] + grid[r - 1][c];
        }
    }

    for (let i = 1; i < n; i++) {
        for (let currH = 0; currH <= n; currH++) {
            for (let prevH = 0; prevH <= n; prevH++) {
                if (currH <= prevH) {
                    const extraScore = colSum[i][prevH] - colSum[i][currH];
                    dp[i][currH][prevH] = Math.max(
                        dp[i][currH][prevH],
                        prevSuffixMax[prevH][0] + extraScore,
                    );
                } else {
                    const extraScore = colSum[i - 1][currH] - colSum[i - 1][prevH];
                    dp[i][currH][prevH] = Math.max(
                        dp[i][currH][prevH],
                        prevSuffixMax[prevH][currH],
                        prevMax[prevH][currH] + extraScore,
                    );
                }
            }
        }

        for (let currH = 0; currH <= n; currH++) {
            prevMax[currH][0] = dp[i][currH][0];
            for (let prevH = 1; prevH <= n; prevH++) {
                const penalty = prevH > currH ? colSum[i][prevH] - colSum[i][currH] : 0;
                prevMax[currH][prevH] = Math.max(
                    prevMax[currH][prevH - 1],
                    dp[i][currH][prevH] - penalty,
                );
            }

            prevSuffixMax[currH][n] = dp[i][currH][n];
            for (let prevH = n - 1; prevH >= 0; prevH--) {
                prevSuffixMax[currH][prevH] = Math.max(
                    prevSuffixMax[currH][prevH + 1],
                    dp[i][currH][prevH],
                );
            }
        }
    }

    let ans = 0;
    for (let k = 0; k <= n; k++) {
        ans = Math.max(ans, dp[n - 1][n][k], dp[n - 1][0][k]);
    }

    return ans;
};
```

```TypeScript
function maximumScore(grid: number[][]): number {
    const n = grid[0].length;
    if (n === 1) {
        return 0;
    }

    const dp: number[][][] = [];
    const prevMax = Array.from({ length: n + 1 }, () => new Array<number>(n + 1).fill(0));
    const prevSuffixMax = Array.from({ length: n + 1 }, () => new Array<number>(n + 1).fill(0));
    const colSum = Array.from({ length: n }, () => new Array<number>(n + 1).fill(0));

    for (let c = 0; c < n; c++) {
        dp[c] = Array.from({ length: n + 1 }, () => new Array(n + 1).fill(0));

        for (let r = 1; r <= n; r++) {
            colSum[c][r] = colSum[c][r - 1] + grid[r - 1][c];
        }
    }

    for (let i = 1; i < n; i++) {
        for (let currH = 0; currH <= n; currH++) {
            for (let prevH = 0; prevH <= n; prevH++) {
                if (currH <= prevH) {
                    const extraScore = colSum[i][prevH] - colSum[i][currH];
                    dp[i][currH][prevH] = Math.max(
                        dp[i][currH][prevH],
                        prevSuffixMax[prevH][0] + extraScore,
                    );
                } else {
                    const extraScore = colSum[i - 1][currH] - colSum[i - 1][prevH];
                    dp[i][currH][prevH] = Math.max(
                        dp[i][currH][prevH],
                        prevSuffixMax[prevH][currH],
                        prevMax[prevH][currH] + extraScore,
                    );
                }
            }
        }

        for (let currH = 0; currH <= n; currH++) {
            prevMax[currH][0] = dp[i][currH][0];
            for (let prevH = 1; prevH <= n; prevH++) {
                const penalty = prevH > currH ? colSum[i][prevH] - colSum[i][currH] : 0;
                prevMax[currH][prevH] = Math.max(
                    prevMax[currH][prevH - 1],
                    dp[i][currH][prevH] - penalty,
                );
            }

            prevSuffixMax[currH][n] = dp[i][currH][n];
            for (let prevH = n - 1; prevH >= 0; prevH--) {
                prevSuffixMax[currH][prevH] = Math.max(
                    prevSuffixMax[currH][prevH + 1],
                    dp[i][currH][prevH],
                );
            }
        }
    }

    let ans = 0;
    for (let k = 0; k <= n; k++) {
        ans = Math.max(ans, dp[n - 1][n][k], dp[n - 1][0][k]);
    }

    return ans;
}
```

```Rust
use std::cmp::max;

impl Solution {
    pub fn maximum_score(grid: Vec<Vec<i32>>) -> i64 {
        let n = grid[0].len();
        if n == 1 {
            return 0;
        }

        let mut dp = vec![vec![vec![0i64; n + 1]; n + 1]; n];
        let mut prev_max = vec![vec![0i64; n + 1]; n + 1];
        let mut prev_suffix_max = vec![vec![0i64; n + 1]; n + 1];
        let mut col_sum = vec![vec![0i64; n + 1]; n];

        for c in 0..n {
            for r in 1..=n {
                col_sum[c][r] = col_sum[c][r - 1] + grid[r - 1][c] as i64;
            }
        }

        for i in 1..n {
            for curr_h in 0..=n {
                for prev_h in 0..=n {
                    if curr_h <= prev_h {
                        let extra_score = col_sum[i][prev_h] - col_sum[i][curr_h];
                        dp[i][curr_h][prev_h] = max(
                            dp[i][curr_h][prev_h],
                            prev_suffix_max[prev_h][0] + extra_score,
                        );
                    } else {
                        let extra_score = col_sum[i - 1][curr_h] - col_sum[i - 1][prev_h];
                        dp[i][curr_h][prev_h] = max(
                            dp[i][curr_h][prev_h],
                            max(
                                prev_suffix_max[prev_h][curr_h],
                                prev_max[prev_h][curr_h] + extra_score,
                            ),
                        );
                    }
                }
            }

            for curr_h in 0..=n {
                prev_max[curr_h][0] = dp[i][curr_h][0];
                for prev_h in 1..=n {
                    let penalty = if prev_h > curr_h {
                        col_sum[i][prev_h] - col_sum[i][curr_h]
                    } else {
                        0
                    };
                    prev_max[curr_h][prev_h] = max(
                        prev_max[curr_h][prev_h - 1],
                        dp[i][curr_h][prev_h] - penalty,
                    );
                }

                prev_suffix_max[curr_h][n] = dp[i][curr_h][n];
                for prev_h in (0..n).rev() {
                    prev_suffix_max[curr_h][prev_h] = max(
                        prev_suffix_max[curr_h][prev_h + 1],
                        dp[i][curr_h][prev_h],
                    );
                }
            }
        }

        let mut ans = 0i64;
        for k in 0..=n {
            ans = max(ans, max(dp[n - 1][n][k], dp[n - 1][0][k]));
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^3)$，其中 $n$ 是方阵 $grid$ 的维数。预处理列前缀和需要 $O(n^2)$，主循环内状态转移、求前缀最大值和求后缀最大值遍历当前列高度和前一列高度都需要 $O(n^2)$，加上外层遍历列号，总时间需求是 $O(n^3)$。
- 空间复杂度：$O(n^3)$。存储动态规划状态需要 $O(n^3)$，存储列前缀和、列前缀最大值和列后缀最大值需要 $O(n^2)$，故总空间复杂度为 $O(n^3)$。若使用滚动数组优化动态规划状态，则空间复杂度可以降到到 $O(n^2)$。
