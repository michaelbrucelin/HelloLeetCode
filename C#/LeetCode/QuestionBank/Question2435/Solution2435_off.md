### [矩阵中和能被 K 整除的路径](https://leetcode.cn/problems/paths-in-matrix-whose-sum-is-divisible-by-k/solutions/3835592/ju-zhen-zhong-he-neng-bei-k-zheng-chu-de-67ra/)

#### 方法一：动态规划

**思路与算法**

可以看出这是一道典型的计数问题，此类问题一般考虑用动态规划算法求解。

考虑 $k$ 的规模为 $1\le k\le 50$，设状态 $dp(i,j,r)$ 代表在矩阵的 $(i,j)$ 处，当前路径和对 $k$ 求余后为 $r$ 的方案数。那么，初始状态为：

$$dp(i,j,r)=\begin{cases}1, & (i,j,r)=(0,0,grid_{0,0}\mod k) \\ 0, & (i,j,r)\ne (0,0,grid_{0,0}\mod k)\end{cases}$$

然后考虑状态转移。$dp(i,j,r)$ 可以从上方和左侧的状态转移而来，即：

$$dp(i,j,r)=\begin{cases}dp(i-1,j,prevMod), & i>0,j=0 \\ dp(i,j-1,prevMod), & i=0,j>0 \\ dp(i-1,j,prevMod)+dp(i,j-1,prevMod), & i>0,j>0\end{cases}$$

其中的关键是 $prevMod$，即前一个状态的余数分量为多少。考虑 $prevMod$ 与 $r$ 的关系，有：

$$prevMod+grid_{i,j}\equiv r(\mod k)$$

即：

$$prevMod\equiv r-grid_{i,j}(\mod k)$$

根据同余运算的规则将其展开，最后得到：

$$prevMod=(r-grid_{i,j}+k)\mod k$$

按上述转移方程计算 $dp$ 状态数组，并按题目要求对 $10^9+7$ 取模即可。完成 $dp$ 状态的计算后，$dp(n,m,0)$ 即为所求。

**代码**

```C++
typedef long long ll;
const int MOD = 1e9 + 7;

class Solution {
public:
    int numberOfPaths(vector<vector<int>>& grid, int k) {
        int m = grid.size();
        int n = grid[0].size();

        auto dp = vector(m + 1, vector(n + 1, vector<ll>(k)));

        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (i == 1 && j == 1) {
                    dp[i][j][grid[0][0] % k] = 1;
                    continue;
                }

                int value = grid[i - 1][j - 1] % k;
                for (int r = 0; r < k; r++) {
                    int prevMod = (r - value + k) % k;
                    dp[i][j][r] =
                        (dp[i - 1][j][prevMod] + dp[i][j - 1][prevMod]) % MOD;
                }
            }
        }

        return dp[m][n][0];
    }
};
```

```JavaScript
const MOD = 1e9 + 7;

var numberOfPaths = function (grid, k) {
    const m = grid.length;
    const n = grid[0].length;

    const dp = [];

    for (let i = 0; i <= m; i++) {
        dp[i] = [];
        for (let j = 0; j <= n; j++) {
            dp[i][j] = new Array(k).fill(0);

            if (i === 1 && j === 1) {
                dp[i][j][grid[0][0] % k] = 1;
                continue;
            }

            if (i >= 1 && j >= 1) {
                const value = grid[i - 1][j - 1] % k;

                for (let r = 0; r < k; r++) {
                    const prevMod = (r - value + k) % k;

                    dp[i][j][r] = dp[i - 1][j][prevMod] + dp[i][j - 1][prevMod];
                    dp[i][j][r] %= MOD;
                }
            }
        }
    }

    return dp[m][n][0];
}
```

```TypeScript
const MOD = 1e9 + 7;

function numberOfPaths(grid: number[][], k: number): number {
    const m = grid.length;
    const n = grid[0].length;

    const dp: number[][][] = [];

    for (let i = 0; i <= m; i++) {
        dp[i] = [];
        for (let j = 0; j <= n; j++) {
            dp[i][j] = new Array(k).fill(0);

            if (i === 1 && j === 1) {
                dp[i][j][grid[0][0] % k] = 1;
                continue;
            }

            if (i >= 1 && j >= 1) {
                const value = grid[i - 1][j - 1] % k;

                for (let r = 0; r < k; r++) {
                    const prevMod = (r - value + k) % k;

                    dp[i][j][r] = dp[i - 1][j][prevMod] + dp[i][j - 1][prevMod];
                    dp[i][j][r] %= MOD;
                }
            }
        }
    }

    return dp[m][n][0];
}
```

```Java
class Solution {
    private static final int MOD = 1000000007;

    public int numberOfPaths(int[][] grid, int k) {
        int m = grid.length;
        int n = grid[0].length;

        long[][][] dp = new long[m + 1][n + 1][k];

        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (i == 1 && j == 1) {
                    dp[i][j][grid[0][0] % k] = 1;
                    continue;
                }

                int value = grid[i - 1][j - 1] % k;
                for (int r = 0; r < k; r++) {
                    int prevMod = (r - value + k) % k;
                    dp[i][j][r] = (dp[i - 1][j][prevMod] + dp[i][j - 1][prevMod]) % MOD;
                }
            }
        }

        return (int) dp[m][n][0];
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1000000007;

    public int NumberOfPaths(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;

        long[][][] dp = new long[m + 1][][];
        for (int i = 0; i <= m; i++) {
            dp[i] = new long[n + 1][];
            for (int j = 0; j <= n; j++) {
                dp[i][j] = new long[k];
            }
        }

        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (i == 1 && j == 1) {
                    dp[i][j][grid[0][0] % k] = 1;
                    continue;
                }

                int value = grid[i - 1][j - 1] % k;
                for (int r = 0; r < k; r++) {
                    int prevMod = (r - value + k) % k;
                    dp[i][j][r] = (dp[i - 1][j][prevMod] + dp[i][j - 1][prevMod]) % MOD;
                }
            }
        }

        return (int) dp[m][n][0];
    }
}
```

```Go
func numberOfPaths(grid [][]int, k int) int {
    const MOD = 1000000007
    m, n := len(grid), len(grid[0])
    
    dp := make([][][]int64, m + 1)
    for i := range dp {
        dp[i] = make([][]int64, n + 1)
        for j := range dp[i] {
            dp[i][j] = make([]int64, k)
        }
    }
    
    for i := 1; i <= m; i++ {
        for j := 1; j <= n; j++ {
            if i == 1 && j == 1 {
                dp[i][j][grid[0][0] % k] = 1
                continue
            }
            
            value := grid[i - 1][j - 1] % k
            for r := 0; r < k; r++ {
                prevMod := (r - value + k) % k
                dp[i][j][r] = (dp[i - 1][j][prevMod] + dp[i][j - 1][prevMod]) % MOD
            }
        }
    }
    
    return int(dp[m][n][0])
}
```

```Python
class Solution:
    def numberOfPaths(self, grid: List[List[int]], k: int) -> int:
        MOD = 10**9 + 7
        m, n = len(grid), len(grid[0])
        
        dp = [[[0] * k for _ in range(n + 1)] for _ in range(m + 1)]
        
        for i in range(1, m + 1):
            for j in range(1, n + 1):
                if i == 1 and j == 1:
                    dp[i][j][grid[0][0] % k] = 1
                    continue
                
                value = grid[i-1][j-1] % k
                for r in range(k):
                    prev_mod = (r - value + k) % k
                    dp[i][j][r] = (dp[i-1][j][prev_mod] + dp[i][j-1][prev_mod]) % MOD
        
        return dp[m][n][0]
```

```C
#define MOD 1000000007

int numberOfPaths(int** grid, int gridSize, int* gridColSize, int k) {
    int m = gridSize;
    int n = gridColSize[0];
    
    long long ***dp = (long long ***)malloc((m + 1) * sizeof(long long **));
    for (int i = 0; i <= m; i++) {
        dp[i] = (long long **)malloc((n + 1) * sizeof(long long *));
        for (int j = 0; j <= n; j++) {
            dp[i][j] = (long long *)calloc(k, sizeof(long long));
        }
    }
    
    for (int i = 1; i <= m; i++) {
        for (int j = 1; j <= n; j++) {
            if (i == 1 && j == 1) {
                dp[i][j][grid[0][0] % k] = 1;
                continue;
            }
            
            int value = grid[i - 1][j - 1] % k;
            for (int r = 0; r < k; r++) {
                int prevMod = (r - value + k) % k;
                dp[i][j][r] = (dp[i - 1][j][prevMod] + dp[i][j - 1][prevMod]) % MOD;
            }
        }
    }
    
    int result = dp[m][n][0];
    for (int i = 0; i <= m; i++) {
        for (int j = 0; j <= n; j++) {
            free(dp[i][j]);
        }
        free(dp[i]);
    }
    free(dp);
    
    return result;
}
```

```Rust
impl Solution {
    pub fn number_of_paths(grid: Vec<Vec<i32>>, k: i32) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let m = grid.len();
        let n = grid[0].len();
        let k = k as usize;
        
        let mut dp = vec![vec![vec![0i64; k]; n + 1]; m + 1];
        
        for i in 1..=m {
            for j in 1..=n {
                if i == 1 && j == 1 {
                    dp[i][j][(grid[0][0] % k as i32) as usize] = 1;
                    continue;
                }
                
                let value = (grid[i-1][j-1] % k as i32) as usize;
                for r in 0..k {
                    let prev_mod = (r as i32 - value as i32 + k as i32) as usize % k;
                    dp[i][j][r] = (dp[i-1][j][prev_mod] + dp[i][j-1][prev_mod]) % MOD;
                }
            }
        }
        
        dp[m][n][0] as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m\times n\times k)$。
- 空间复杂度：$O(m\times n\times k)$。
