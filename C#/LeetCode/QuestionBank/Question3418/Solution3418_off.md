### [机器人可以获得的最大金币数](https://leetcode.cn/problems/maximum-amount-of-money-robot-can-earn/solutions/3942281/ji-qi-ren-ke-yi-huo-de-de-zui-da-jin-bi-hf9ay/)

#### 方法一：记忆化搜索

**思路与算法**

本题规定机器人最多可以感化 $2$ 个单元格的强盗，本质相当于可以修改路径上的至多 $2$ 个数，与 「[64\. 最小路径和](https://leetcode.cn/problems/minimum-path-sum/solutions/342122/zui-xiao-lu-jing-he-by-leetcode-solution/)」相比即多了一个修改次数的限制的约束，我们可以采用**动态规划**解法。由于每次只能向下或者向右移动，且限制可用感化次数为 $2$，此时我们定义 $dfs(i,j,k)$ 表示从 $(i,j)$ 走到 $(m-1,n-1)$，在可用感化次数为 $k$ 的情况下，可以获得的最大金币数，其中 $m,n$ 分别表示单元格的行数与列数。

假定当前位置为 $(i,j)$，此时我们用「感化或不感化」来进行分类讨论：

- 不感化（选）：此时从当前单元格获取的金币数为 $coins[i][j]$，然后继续向下或者向右移动，则此时递推公式为：
$$dfs(i,j,k)=max(dfs(i+1,j,k),dfs(i,j+1,k))+coins[i][j]$$
- 感化（不选）：如果当前可使用的感化次数 $k>0$，且 $coins[i][j]$ 为负数，则此时使用感化，此时获取的金币数为 $0$，然后继续向下或者向右移动，则此时递推公式为：
$$dfs(i,j,k)=max(dfs(i+1,j,k-1),dfs(i,j+1,k-1))$$

我们取这两种情况取最大值即为当前的最优解，继续探讨递归边界：

- 当满足 $i\ge m$ 或 $j\ge n$ 时，此时为非法状态，我们返回 $-\infty $ 表示不合法的状态；
- 当满足 $i=m-1$ 且 $j=n-1$ 时，此时已达到终点，当满足 $k>0$ 时，此时可以使用感化，返回值 $max(0,coins[i][j])$；当满足 $k=0$ 时，此时无法使用感化，返回 $coins[i][j]$；

我们从起点 $(0,0)$ 开始进行递归，初始状态为 $(0,0,2)$，$dfs(0,0,2)$，即为答案。

注意：由于 $coins[i][j]$ 可能为负数，所以返回值可能为负数，因此记忆化数组的初始值不能是 $-1$，可以初始化成最小值 $-\infty $。

**代码**

```C++
class Solution {
public:
    int maximumAmount(vector<vector<int>>& coins) {
        int m = coins.size(), n = coins[0].size();
        vector memo(m, vector(n, array<int, 3>{INT_MIN, INT_MIN, INT_MIN}));

        function<int(int, int, int)> dfs = [&](int i, int j, int k) -> int {
            if (i >= m || j >= n) {
                return INT_MIN;
            }

            int x = coins[i][j];
            // 到达终点
            if (i == m - 1 && j == n - 1) {
                return k > 0 ? max(0, x) : x;
            }

            int res = memo[i][j][k];
            if (res != INT_MIN) {
                return res;
            }
            // 不进行感化
            res = max(dfs(i + 1, j, k), dfs(i, j + 1, k)) + x;
            if (k > 0 && x < 0) {
                // 进行感化
                res = max({res, dfs(i + 1, j, k - 1), dfs(i, j + 1, k - 1)});
            }
            return memo[i][j][k] = res;
        };

        return dfs(0, 0, 2);
    }
};
```

```Java
class Solution {
    public int maximumAmount(int[][] coins) {
        int m = coins.length, n = coins[0].length;
        int[][][] memo = new int[m][n][3];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                Arrays.fill(memo[i][j], Integer.MIN_VALUE);
            }
        }

        return dfs(coins, memo, 0, 0, 2);
    }

    private int dfs(int[][] coins, int[][][] memo, int i, int j, int k) {
        int m = coins.length, n = coins[0].length;
        if (i >= m || j >= n) {
            return Integer.MIN_VALUE;
        }

        int x = coins[i][j];
        // 到达终点
        if (i == m - 1 && j == n - 1) {
            return k > 0 ? Math.max(0, x) : x;
        }

        if (memo[i][j][k] != Integer.MIN_VALUE) {
            return memo[i][j][k];
        }

        // 不进行感化
        int res = Math.max(
            dfs(coins, memo, i + 1, j, k),
            dfs(coins, memo, i, j + 1, k)
        ) + x;

        if (k > 0 && x < 0) {
            // 进行感化
            res = Math.max(res, Math.max(
                dfs(coins, memo, i + 1, j, k - 1),
                dfs(coins, memo, i, j + 1, k - 1)
            ));
        }

        memo[i][j][k] = res;
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MaximumAmount(int[][] coins) {
        int m = coins.Length, n = coins[0].Length;
        int[,,] memo = new int[m, n, 3];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < 3; k++) {
                    memo[i, j, k] = int.MinValue;
                }
            }
        }

        return DFS(coins, memo, 0, 0, 2);
    }

    private int DFS(int[][] coins, int[,,] memo, int i, int j, int k) {
        int m = coins.Length, n = coins[0].Length;
        if (i >= m || j >= n) {
            return int.MinValue;
        }

        int x = coins[i][j];
        // 到达终点
        if (i == m - 1 && j == n - 1) {
            return k > 0 ? Math.Max(0, x) : x;
        }

        if (memo[i, j, k] != int.MinValue) {
            return memo[i, j, k];
        }

        // 不进行感化
        int res = Math.Max(
            DFS(coins, memo, i + 1, j, k),
            DFS(coins, memo, i, j + 1, k)
        ) + x;

        if (k > 0 && x < 0) {
            // 进行感化
            res = Math.Max(res, Math.Max(
                DFS(coins, memo, i + 1, j, k - 1),
                DFS(coins, memo, i, j + 1, k - 1)
            ));
        }

        memo[i, j, k] = res;
        return res;
    }
}
```

```Go
func maximumAmount(coins [][]int) int {
    m, n := len(coins), len(coins[0])
    memo := make([][][]int, m)
    for i := range memo {
        memo[i] = make([][]int, n)
        for j := range memo[i] {
            memo[i][j] = make([]int, 3)
            for k := range memo[i][j] {
                memo[i][j][k] = -1 << 31
            }
        }
    }

    var dfs func(i, j, k int) int
    dfs = func(i, j, k int) int {
        if i >= m || j >= n {
            return -1 << 31
        }

        x := coins[i][j]
        // 到达终点
        if i == m-1 && j == n-1 {
            if k > 0 {
                return max(0, x)
            }
            return x
        }

        if memo[i][j][k] != -1<<31 {
            return memo[i][j][k]
        }

        // 不进行感化
        res := max(dfs(i+1, j, k), dfs(i, j+1, k)) + x
        if k > 0 && x < 0 {
            // 进行感化
            res = max(res, max(dfs(i+1, j, k-1), dfs(i, j+1, k-1)))
        }

        memo[i][j][k] = res
        return res
    }

    return dfs(0, 0, 2)
}
```

```Python
class Solution:
    def maximumAmount(self, coins: List[List[int]]) -> int:
        m, n = len(coins), len(coins[0])

        @cache
        def dfs(i: int, j: int, k: int) -> int:
            if i >= m or j >= n:
                return -inf

            x = coins[i][j]
            # 到达终点
            if i == m - 1 and j == n - 1:
                return max(0, x) if k > 0 else x

            # 不进行感化
            res = max(dfs(i + 1, j, k), dfs(i, j + 1, k)) + x
            if k > 0 and x < 0:
                # 进行感化
                res = max(res, dfs(i + 1, j, k - 1), dfs(i, j + 1, k - 1))
            return res

        res = dfs(0, 0, 2)
        dfs.cache_clear()

        return res
```

```C
int dfs(int** coins, int*** memo, int m, int n, int i, int j, int k) {
    if (i < 0 || j < 0) {
        return INT_MIN;
    }

    int x = coins[i][j];
    if (i == 0 && j == 0) {
        return k > 0 ? (x > 0 ? x : 0) : x;
    }
    if (memo[i][j][k] != INT_MIN) {
        return memo[i][j][k];
    }

    int res = fmax(
        dfs(coins, memo, m, n, i - 1, j, k),
        dfs(coins, memo, m, n, i, j - 1, k)
    ) + x;

    if (k > 0 && x < 0) {
        res = fmax(res, fmax(
            dfs(coins, memo, m, n, i - 1, j, k - 1),
            dfs(coins, memo, m, n, i, j - 1, k - 1)
        ));
    }

    memo[i][j][k] = res;
    return res;
}

int maximumAmount(int** coins, int coinsSize, int* coinsColSize) {
    int m = coinsSize, n = coinsColSize[0];

    int*** memo = (int***)malloc(m * sizeof(int**));
    for (int i = 0; i < m; i++) {
        memo[i] = (int**)malloc(n * sizeof(int*));
        for (int j = 0; j < n; j++) {
            memo[i][j] = (int*)malloc(3 * sizeof(int));
            for (int k = 0; k < 3; k++) {
                memo[i][j][k] = INT_MIN;
            }
        }
    }

    int res = dfs(coins, memo, m, n, m - 1, n - 1, 2);
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            free(memo[i][j]);
        }
        free(memo[i]);
    }
    free(memo);

    return res;
}
```

```JavaScript
var maximumAmount = function(coins) {
    const m = coins.length, n = coins[0].length;
    const memo = new Array(m);

    for (let i = 0; i < m; i++) {
        memo[i] = new Array(n);
        for (let j = 0; j < n; j++) {
            memo[i][j] = new Array(3).fill(-Infinity);
        }
    }

    const dfs = (i, j, k) => {
        if (i < 0 || j < 0) {
            return -Infinity;
        }

        const x = coins[i][j];
        if (i === 0 && j === 0) {
            return k > 0 ? Math.max(0, x) : x;
        }

        if (memo[i][j][k] !== -Infinity) {
            return memo[i][j][k];
        }

        let res = Math.max(dfs(i - 1, j, k), dfs(i, j - 1, k)) + x;
        if (k > 0 && x < 0) {
            res = Math.max(res, dfs(i - 1, j, k - 1), dfs(i, j - 1, k - 1));
        }

        memo[i][j][k] = res;
        return res;
    };

    return dfs(m - 1, n - 1, 2);
};
```

```TypeScript
function maximumAmount(coins: number[][]): number {
    const m = coins.length, n = coins[0].length;
    const memo: number[][][] = new Array(m);

    for (let i = 0; i < m; i++) {
        memo[i] = new Array(n);
        for (let j = 0; j < n; j++) {
            memo[i][j] = new Array(3).fill(-Infinity);
        }
    }

    const dfs = (i: number, j: number, k: number): number => {
        if (i < 0 || j < 0) {
            return -Infinity;
        }

        const x = coins[i][j];
        if (i === 0 && j === 0) {
            return k > 0 ? Math.max(0, x) : x;
        }

        if (memo[i][j][k] !== -Infinity) {
            return memo[i][j][k];
        }

        let res = Math.max(dfs(i - 1, j, k), dfs(i, j - 1, k)) + x;

        if (k > 0 && x < 0) {
            res = Math.max(res, dfs(i - 1, j, k - 1), dfs(i, j - 1, k - 1));
        }

        memo[i][j][k] = res;
        return res;
    };

    return dfs(m - 1, n - 1, 2);
}
```

```Rust
use std::cmp::{max, min};

impl Solution {
    pub fn maximum_amount(coins: Vec<Vec<i32>>) -> i32 {
        let m = coins.len();
        let n = coins[0].len();
        let mut memo = vec![vec![vec![i32::MIN; 3]; n]; m];

        fn dfs(coins: &Vec<Vec<i32>>, memo: &mut Vec<Vec<Vec<i32>>>, i: i32, j: i32, k: usize) -> i32 {
            let m = coins.len() as i32;
            let n = coins[0].len() as i32;

            if i >= m || j >= n {
                return i32::MIN;
            }

            let i_usize = i as usize;
            let j_usize = j as usize;
            let x = coins[i_usize][j_usize];

            // 到达终点
            if i == m - 1 && j == n - 1 {
                return if k > 0 { max(0, x) } else { x };
            }

            if memo[i_usize][j_usize][k] != i32::MIN {
                return memo[i_usize][j_usize][k];
            }

            // 不进行感化
            let mut res = max(
                dfs(coins, memo, i + 1, j, k),
                dfs(coins, memo, i, j + 1, k)
            ) + x;

            if k > 0 && x < 0 {
                // 进行感化
                res = max(
                    res,
                    max(
                        dfs(coins, memo, i + 1, j, k - 1),
                        dfs(coins, memo, i, j + 1, k - 1)
                    )
                );
            }

            memo[i_usize][j_usize][k] = res;
            res
        }

        dfs(&coins, &mut memo, 0, 0, 2)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m,n$ 为 $coins$ 的行数与列数。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times $ 单个状态的计算时间。本题状态个数等于 $O(3mn)$，单个状态的计算时间为 $O(1)$，所以总的时间复杂度为 $O(mn)$。
- 空间复杂度：$O(mn)$，其中 $m,n$ 为 $coins$ 的行数与列数。一共有 $3mn$ 个状态需要保存，因此总的空间复杂度为 $O(mn)$。

#### 方法二：动态规划

**思路与算法**

同样的方法，我们还可以使用自底向上的动态规划，设 $dp[i][j][k]$ 表示从 $(0,0)$ 走到 $(i,j)$，最多使用感化次数为 $k$ 的情况下，可以获得的最大金币数。根据题意可知如果使用感化时，当前单元格 $(i,j)$ 可以获得的最大金币数为 $0$，否则为 $coins[i][j]$，此时我们推论如下：

- 当 $i=0$ 且 $j=0$ 时，路径上只有 $(0,0)$ 一个位置，不使用感化的可以获得的最大金币数是 $coins[0][0]$，使用感化的最大金币数是 $max(coins[0][0],0)$，因此动态规划的边界为：
  - 当 $k=0$ 时，$dp[0][0][k]=coins[0][0]$；
  - 当 $k>0$ 时，$dp[0][0][k]=max(coins[0][0],0)$；
- 当 $i=0$ 且 $j>0$ 时，此时只能从 $(i,j-1)$ 向右移动到 $(i,j)$，因此 $dp[i][j][k]=max(dp[i][j-1][k]+coins[i][j],dp[i][j-1][k-1])$。
- 当 $i>0$ 且 $j=0$ 时，此时只能从 $(i-1,j)$ 向下移动到 $(i,j)$，因此 $dp[i][j][k]=max(dp[i-1][j][k]+coins[i][j],dp[i-1][j][k-1])$。
- 当 $i>0$ 且 $j>0$ 时，此时可以从 $(i-1,j)$ 向下移动到 $(i,j)$，或者从 $(i,j-1)$ 向右移动到 $(i,j)$，因此 $dp[i][j][k]=max(dp[i-1][j][k]+coins[i][j],dp[i-1][j][k-1],dp[i][j-1][k]+coins[i][j],dp[i][j-1][k-1])$。

根据上述分析，动态规划的状态转移方程如下：

$$\begin{cases}
    dp[0][0][k]=coins[0][0] & k=0 \\
    dp[0][0][k]=max(coins[0][0],0) & k>0 \\
    dp[i][j][k]=max(dp[i][j-1][k]+coins[i][j],dp[i][j-1][k-1]) & i=0\&j>0 \\
    dp[i][j][k]=max(dp[i-1][j][k]+coins[i][j],dp[i-1][j][k-1]) & i>0\&j=0 \\
    dp[i][j][k]=max(dp[i-1][j][k]+coins[i][j],dp[i-1][j][k-1],dp[i][j-1][k]+coins[i][j],dp[i][j-1][k-1]) & i>0\&j>0
\end{cases}$$

根据动态规划的状态转移方程，计算得到 $dp[m-1][n-1][2]$ 即为机器人从左上角到右下角的路径上可以获得的最大金币数。

```C++
class Solution {
public:
    int maximumAmount(vector<vector<int>>& coins) {
        int m = coins.size();
        int n = coins[0].size();
        vector dp(m, vector(n, array<int, 3>{INT_MIN / 2, INT_MIN / 2, INT_MIN / 2}));

        dp[0][0][0] = coins[0][0];
        for (int k = 1; k <= 2; k++) {
            dp[0][0][k] = max(coins[0][0], 0);
        }
        for (int j = 1; j < n; j++) {
            dp[0][j][0] = dp[0][j - 1][0] + coins[0][j];
            for (int k = 1; k <= 2; k++) {
                dp[0][j][k] = max(dp[0][j - 1][k] + coins[0][j], dp[0][j - 1][k - 1] + max(coins[0][j], 0));
            }
        }
        for (int i = 1; i < m; i++) {
            dp[i][0][0] = dp[i - 1][0][0] + coins[i][0];
            for (int k = 1; k <= 2; k++) {
                dp[i][0][k] = max(dp[i - 1][0][k] + coins[i][0], dp[i - 1][0][k - 1] + max(coins[i][0], 0));
            }
        }

        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                dp[i][j][0] = max(dp[i - 1][j][0], dp[i][j - 1][0]) + coins[i][j];
                for (int k = 1; k <= 2; k++) {
                    dp[i][j][k] = max(max(dp[i - 1][j][k], dp[i][j - 1][k]) + coins[i][j],
                                        max(dp[i - 1][j][k - 1], dp[i][j - 1][k - 1]));
                }
            }
        }

        return dp[m - 1][n - 1][2];
    }
};
```

```Python
class Solution:
    def maximumAmount(self, coins: List[List[int]]) -> int:
        m, n = len(coins), len(coins[0])
        dp = [[[-inf] * 3 for _ in range(n)] for _ in range(m)]

        dp[0][0][0] = coins[0][0]
        for k in range(1, 3):
            dp[0][0][k] = max(coins[0][0], 0)

        for j in range(1, n):
            dp[0][j][0] = dp[0][j-1][0] + coins[0][j]
            x = max(coins[0][j], 0)
            for k in range(1, 3):
                dp[0][j][k] = max(dp[0][j - 1][k] + coins[0][j], dp[0][j - 1][k - 1] + x)

        for i in range(1, m):
            dp[i][0][0] = dp[i - 1][0][0] + coins[i][0]
            x = max(coins[i][0], 0)
            for k in range(1, 3):
                dp[i][0][k] = max(dp[i - 1][0][k] + coins[i][0], dp[i - 1][0][k - 1] + x)

        for i in range(1, m):
            for j in range(1, n):
                x = coins[i][j]
                dp[i][j][2] = max(dp[i - 1][j][2] + x, dp[i][j - 1][2] + x, dp[i - 1][j][1], dp[i][j - 1][1])
                dp[i][j][1] = max(dp[i - 1][j][1] + x, dp[i][j - 1][1] + x, dp[i - 1][j][0], dp[i][j - 1][0])
                dp[i][j][0] = max(dp[i - 1][j][0], dp[i][j - 1][0]) + x

        return dp[m - 1][n - 1][2]
```

我们可以继续优化空间，按行遍历时，由于第 $i$ 行的状态只取决于第 $i-1$ 行的状态，和更早的状态无关，因此可以使用滚动数组的思想，只保留前一行的状态，将空间复杂度降到 $O(n)$。优化时，为了方便计算，可对于每个单元格 $(i,j)$ 计算状态值时应从大到小遍历每个 $k$。

**代码**

```C++
class Solution {
public:
    int maximumAmount(vector<vector<int>>& coins) {
        int n = coins[0].size();
        vector dp(n + 1, vector<int>(3, INT_MIN / 2));

        for (int i = 0; i < 3; i++) {
            dp[1][i] = 0;
        }
        for (auto& row : coins) {
            for (int j = 1; j <= n; j++) {
                int x = row[j - 1];
                dp[j][2] = max({dp[j - 1][2] + x, dp[j][2] + x, dp[j - 1][1], dp[j][1]});
                dp[j][1] = max({dp[j - 1][1] + x, dp[j][1] + x, dp[j - 1][0], dp[j][0]});
                dp[j][0] = max(dp[j - 1][0], dp[j][0]) + x;
            }
        }

        return dp[n][2];
    }
};
```

```Java
class Solution {
    public int maximumAmount(int[][] coins) {
        int n = coins[0].length;
        int[][] dp = new int[n + 1][3];
        for (int i = 0; i <= n; i++) {
            Arrays.fill(dp[i], Integer.MIN_VALUE / 2);
        }

        for (int i = 0; i < 3; i++) {
            dp[1][i] = 0;
        }
        for (int[] row : coins) {
            for (int j = 1; j <= n; j++) {
                int x = row[j - 1];
                dp[j][2] = Math.max(Math.max(dp[j - 1][2] + x, dp[j][2] + x),
                                        Math.max(dp[j - 1][1], dp[j][1]));
                dp[j][1] = Math.max(Math.max(dp[j - 1][1] + x, dp[j][1] + x),
                                        Math.max(dp[j - 1][0], dp[j][0]));
                dp[j][0] = Math.max(dp[j - 1][0], dp[j][0]) + x;
            }
        }

        return dp[n][2];
    }
}
```

```CSharp
public class Solution {
    public int MaximumAmount(int[][] coins) {
        int n = coins[0].Length;
        int[,] dp = new int[n + 1, 3];
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j < 3; j++) {
                dp[i, j] = int.MinValue / 2;
            }
        }

        for (int i = 0; i < 3; i++) {
            dp[1, i] = 0;
        }
        foreach (int[] row in coins) {
            for (int j = 1; j <= n; j++) {
                int x = row[j - 1];
                dp[j, 2] = Math.Max(Math.Max(dp[j - 1, 2] + x, dp[j, 2] + x),
                                        Math.Max(dp[j - 1, 1], dp[j, 1]));
                dp[j, 1] = Math.Max(Math.Max(dp[j - 1, 1] + x, dp[j, 1] + x),
                                        Math.Max(dp[j - 1, 0], dp[j, 0]));
                dp[j, 0] = Math.Max(dp[j - 1, 0], dp[j, 0]) + x;
            }
        }

        return dp[n, 2];
    }
}
```

```Go
func maximumAmount(coins [][]int) int {
    n := len(coins[0])
    dp := make([][]int, n+1)
    const minInt = -1 << 31

    for i := range dp {
        dp[i] = make([]int, 3)
        for j := range dp[i] {
            dp[i][j] = minInt / 2
        }
    }

    for i := 0; i < 3; i++ {
        dp[1][i] = 0
    }
    for _, row := range coins {
        for j := 1; j <= n; j++ {
            x := row[j - 1]
            dp[j][2] = max(max(dp[j - 1][2] + x, dp[j][2] + x),
                             max(dp[j - 1][1], dp[j][1]))
            dp[j][1] = max(max(dp[j - 1][1] + x, dp[j][1] + x),
                             max(dp[j - 1][0], dp[j][0]))
            dp[j][0] = max(dp[j - 1][0], dp[j][0]) + x
        }
    }

    return dp[n][2]
}
```

```Python
class Solution:
    def maximumAmount(self, coins: List[List[int]]) -> int:
        n = len(coins[0])
        dp = [[-inf] * 3 for _ in range(n + 1)]

        dp[1] = [0] * 3
        for row in coins:
            for j, x in enumerate(row):
                dp[j + 1][2] = max(dp[j][2] + x, dp[j + 1][2] + x, dp[j][1], dp[j + 1][1])
                dp[j + 1][1] = max(dp[j][1] + x, dp[j + 1][1] + x, dp[j][0], dp[j + 1][0])
                dp[j + 1][0] = max(dp[j][0], dp[j + 1][0]) + x

        return dp[n][2]
```

```C
int maximumAmount(int** coins, int coinsSize, int* coinsColSize) {
    int n = coinsColSize[0];
    int** dp = (int**)malloc((n + 1) * sizeof(int*));

    for (int i = 0; i <= n; i++) {
        dp[i] = (int*)malloc(3 * sizeof(int));
        for (int j = 0; j < 3; j++) {
            dp[i][j] = INT_MIN / 2;
        }
    }

    for (int i = 0; i < 3; i++) {
        dp[1][i] = 0;
    }
    for (int i = 0; i < coinsSize; i++) {
        for (int j = 1; j <= n; j++) {
            int x = coins[i][j - 1];
            dp[j][2] = fmax(fmax(dp[j - 1][2] + x, dp[j][2] + x),
                             fmax(dp[j - 1][1], dp[j][1]));
            dp[j][1] = fmax(fmax(dp[j - 1][1] + x, dp[j][1] + x),
                             fmax(dp[j - 1][0], dp[j][0]));
            dp[j][0] = fmax(dp[j - 1][0], dp[j][0]) + x;
        }
    }

    int result = dp[n][2];
    for (int i = 0; i <= n; i++) {
        free(dp[i]);
    }
    free(dp);

    return result;
}
```

```JavaScript
var maximumAmount = function(coins) {
    const n = coins[0].length;
    const dp = Array.from({length: n + 1}, () => Array(3).fill(-Infinity));

    for (let i = 0; i < 3; i++) {
        dp[1][i] = 0;
    }
    for (const row of coins) {
        for (let j = 1; j <= n; j++) {
            const x = row[j - 1];
            dp[j][2] = Math.max(dp[j - 1][2] + x, dp[j][2] + x, dp[j - 1][1], dp[j][1]);
            dp[j][1] = Math.max(dp[j - 1][1] + x, dp[j][1] + x, dp[j - 1][0], dp[j][0]);
            dp[j][0] = Math.max(dp[j - 1][0], dp[j][0]) + x;
        }
    }

    return dp[n][2];
};
```

```TypeScript
function maximumAmount(coins: number[][]): number {
    const n = coins[0].length;
    const dp: number[][] = Array.from({length: n + 1}, () => Array(3).fill(-Infinity));

    for (let i = 0; i < 3; i++) {
        dp[1][i] = 0;
    }
    for (const row of coins) {
        for (let j = 1; j <= n; j++) {
            const x = row[j - 1];
            dp[j][2] = Math.max(dp[j - 1][2] + x, dp[j][2] + x, dp[j - 1][1], dp[j][1]);
            dp[j][1] = Math.max(dp[j - 1][1] + x, dp[j][1] + x, dp[j - 1][0], dp[j][0]);
            dp[j][0] = Math.max(dp[j - 1][0], dp[j][0]) + x;
        }
    }

    return dp[n][2];
}
```

```Rust
impl Solution {
    pub fn maximum_amount(coins: Vec<Vec<i32>>) -> i32 {
        let n = coins[0].len();
        let mut dp = vec![[i32::MIN / 2; 3]; n + 1];

        dp[1] = [0, 0, 0];
        for row in coins {
            for j in 1..= n {
                let x = row[j - 1];
                dp[j][2] = *[dp[j - 1][2] + x, dp[j][2] + x, dp[j - 1][1], dp[j][1]]
                    .iter().max().unwrap();
                dp[j][1] = *[dp[j - 1][1] + x, dp[j][1] + x, dp[j - 1][0], dp[j][0]]
                    .iter().max().unwrap();
                dp[j][0] = dp[j - 1][0].max(dp[j][0]) + x;
            }
        }

        dp[n][2]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m,n$ 为 $coins$ 的行数与列数。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times $ 单个状态的计算时间。本题中状态个数等于 $O(3mn)$，单个状态的计算时间为 $O(1)$，所以总的时间复杂度为 $O(mn)$。
- 空间复杂度：$O(mn)$，其中 $m,n$ 为 $coins$ 的行数与列数。动态规划一共有 $O(3mn)$ 个状态，经过优化只需要 $O(3n)$ 的空间来存储状态，因此空间复杂度为 $O(n)$。
