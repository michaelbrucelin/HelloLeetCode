### [学生出勤记录 II](https://leetcode.cn/problems/student-attendance-record-ii/solutions/942386/xue-sheng-chu-qin-ji-lu-ii-by-leetcode-s-kdlm/)

#### 方法一：动态规划

可以使用动态规划计算可奖励的出勤记录的数量。

由于可奖励的出勤记录要求缺勤次数少于 $2$ 和连续迟到次数少于 $3$，因此动态规划的状态由总天数、缺勤次数和结尾连续迟到次数决定（由于不会记录连续迟到次数等于或多于 $3$ 的情况，因此非结尾的连续迟到次数一定少于 $3$，只需要记录结尾连续迟到次数即可）。

定义 $dp[i][j][k]$ 表示前 $i$ 天有 $j$ 个 $‘A’$ 且结尾有连续 $k$ 个 $‘L’$ 的可奖励的出勤记录的数量，其中 $0 \le i \le n$，$0 \le j \le 1$，$0 \le k \le 2$。

当 $i=0$ 时，没有任何出勤记录，此时 $‘A’$ 的数量和结尾连续 $‘L’$ 的数量一定是 $0$，因此动态规划的边界情况是 $dp[0][0][0]=1$。

当 $1 \le i \le n$ 时，$dp[i][][]$ 的值从 $dp[i-1][][]$ 的值转移得到，计算每个状态的值需要考虑第 $i$ 天的出勤记录：

- 如果第 $i$ 天的出勤记录是 $‘P’$，则前 $i$ 天和前 $i-1$ 天的出勤记录相比，$‘A’$ 的数量不变，结尾连续 $‘L’$ 的数量清零，因此对 $0 \le j \le 1$，有

$$dp[i][j][0]:=dp[i][j][0]+\sum\limits_{k=0}^2dp[i-1][j][k]$$

- 如果第 $i$ 天的出勤记录是 $‘A’$，则前 $i$ 天和前 $i-1$ 天的出勤记录相比，$‘A’$ 的数量加 $1$，结尾连续 $‘L’$ 的数量清零，此时要求前 $i-1$ 天的出勤记录记录中的 $‘A’$ 的数量必须为 $0$，否则前 $i$ 天的出勤记录至少有 $2$ 个 $‘A’$，不满足可奖励的条件，因此有

$$dp[i][1][0]:=dp[i][1][0]+\sum\limits_{k=0}^2dp[i-1][0][k]$$

- 如果第 $i$ 天的出勤记录是 $‘L’$，则前 $i$ 天和前 $i-1$ 天的出勤记录相比，$‘A’$ 的数量不变，结尾连续 $‘L’$ 的数量加 $1$，此时要求前 $i-1$ 天的出勤记录记录中的结尾连续 $‘L’$ 的数量不超过 $1$，否则前 $i$ 天的出勤记录的结尾至少有 $3$ 个 $‘L’$，不满足可奖励的条件，因此对 $0 \le j \le 1$ 和 $1 \le k \le 2$，有

$$dp[i][j][k]:=dp[i][j][k]+dp[i-1][j][k-1]$$

上述状态转移方程对于 $i=1$ 也适用。

计算长度为 $n$ 的所有可奖励的出勤记录的数量，即为计算 $dp[n][][]$ 的所有元素之和。计算过程中需要将结果对 $10^9+7$ 取模。

根据上述思路，可以得到时间复杂度和空间复杂度都是 $O(n)$ 的实现。

```Java
class Solution {
    public int checkRecord(int n) {
        final int MOD = 1000000007;
        int[][][] dp = new int[n + 1][2][3]; // 长度，A 的数量，结尾连续 L 的数量
        dp[0][0][0] = 1;
        for (int i = 1; i <= n; i++) {
            // 以 P 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 0; k <= 2; k++) {
                    dp[i][j][0] = (dp[i][j][0] + dp[i - 1][j][k]) % MOD;
                }
            }
            // 以 A 结尾的数量
            for (int k = 0; k <= 2; k++) {
                dp[i][1][0] = (dp[i][1][0] + dp[i - 1][0][k]) % MOD;
            }
            // 以 L 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 1; k <= 2; k++) {
                    dp[i][j][k] = (dp[i][j][k] + dp[i - 1][j][k - 1]) % MOD;
                }
            }
        }
        int sum = 0;
        for (int j = 0; j <= 1; j++) {
            for (int k = 0; k <= 2; k++) {
                sum = (sum + dp[n][j][k]) % MOD;
            }
        }
        return sum;
    }
}
```

```CSharp
public class Solution {
    public int CheckRecord(int n) {
        const int MOD = 1000000007;
        int[,,] dp = new int[n + 1, 2, 3]; // 长度，A 的数量，结尾连续 L 的数量
        dp[0, 0, 0] = 1;
        for (int i = 1; i <= n; i++) {
            // 以 P 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 0; k <= 2; k++) {
                    dp[i, j, 0] = (dp[i, j, 0] + dp[i - 1, j, k]) % MOD;
                }
            }
            // 以 A 结尾的数量
            for (int k = 0; k <= 2; k++) {
                dp[i, 1, 0] = (dp[i, 1, 0] + dp[i - 1, 0, k]) % MOD;
            }
            // 以 L 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 1; k <= 2; k++) {
                    dp[i, j, k] = (dp[i, j, k] + dp[i - 1, j, k - 1]) % MOD;
                }
            }
        }
        int sum = 0;
        for (int j = 0; j <= 1; j++) {
            for (int k = 0; k <= 2; k++) {
                sum = (sum + dp[n, j, k]) % MOD;
            }
        }
        return sum;
    }
}
```

```JavaScript
var checkRecord = function(n) {
    const MOD = 1000000007;
    const dp = new Array(n + 1).fill(2).map(() => new Array(2).fill(0).map(() => new Array(3).fill(0))); // 长度，A 的数量，结尾连续 L 的数量
    dp[0][0][0] = 1;
    for (let i = 1; i <= n; i++) {
        // 以 P 结尾的数量
        for (let j = 0; j <= 1; j++) {
            for (let k = 0; k <= 2; k++) {
                dp[i][j][0] = (dp[i][j][0] + dp[i - 1][j][k]) % MOD;
            }
        }
        // 以 A 结尾的数量
        for (let k = 0; k <= 2; k++) {
            dp[i][1][0] = (dp[i][1][0] + dp[i - 1][0][k]) % MOD;
        }
        // 以 L 结尾的数量
        for (let j = 0; j <= 1; j++) {
            for (let k = 1; k <= 2; k++) {
                dp[i][j][k] = (dp[i][j][k] + dp[i - 1][j][k - 1]) % MOD;
            }
        }
    }
    let sum = 0;
    for (let j = 0; j <= 1; j++) {
        for (let k = 0; k <= 2; k++) {
            sum = (sum + dp[n][j][k]) % MOD;
        }
    }
    return sum;
};
```

```Python
class Solution:
    def checkRecord(self, n: int) -> int:
        MOD = 10**9 + 7
        # 长度，A 的数量，结尾连续 L 的数量
        dp = [[[0, 0, 0], [0, 0, 0]] for _ in range(n + 1)]
        dp[0][0][0] = 1

        for i in range(1, n + 1):
            # 以 P 结尾的数量
            for j in range(0, 2):
                for k in range(0, 3):
                    dp[i][j][0] = (dp[i][j][0] + dp[i - 1][j][k]) % MOD
            
            # 以 A 结尾的数量
            for k in range(0, 3):
                dp[i][1][0] = (dp[i][1][0] + dp[i - 1][0][k]) % MOD
            
            # 以 L 结尾的数量
            for j in range(0, 2):
                for k in range(1, 3):
                    dp[i][j][k] = (dp[i][j][k] + dp[i - 1][j][k - 1]) % MOD
        
        total = 0
        for j in range(0, 2):
            for k in range(0, 3):
                total += dp[n][j][k]
        
        return total % MOD
```

```C++
class Solution {
public:
    static constexpr int MOD = 1'000'000'007;

    int checkRecord(int n) {
        vector<vector<vector<int>>> dp(n + 1, vector<vector<int>>(2, vector<int>(3)));  // 长度，A 的数量，结尾连续 L 的数量
        dp[0][0][0] = 1;
        for (int i = 1; i <= n; i++) {
            // 以 P 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 0; k <= 2; k++) {
                    dp[i][j][0] = (dp[i][j][0] + dp[i - 1][j][k]) % MOD;
                }
            }
            // 以 A 结尾的数量
            for (int k = 0; k <= 2; k++) {
                dp[i][1][0] = (dp[i][1][0] + dp[i - 1][0][k]) % MOD;
            }
            // 以 L 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 1; k <= 2; k++) {
                    dp[i][j][k] = (dp[i][j][k] + dp[i - 1][j][k - 1]) % MOD;
                }
            }
        }
        int sum = 0;
        for (int j = 0; j <= 1; j++) {
            for (int k = 0; k <= 2; k++) {
                sum = (sum + dp[n][j][k]) % MOD;
            }
        }
        return sum;
    }
};
```

```C
const int MOD = 1000000007;

int checkRecord(int n) {
    int dp[n + 1][2][3];  // 长度，A 的数量，结尾连续 L 的数量
    memset(dp, 0, sizeof(dp));
    dp[0][0][0] = 1;
    for (int i = 1; i <= n; i++) {
        // 以 P 结尾的数量
        for (int j = 0; j <= 1; j++) {
            for (int k = 0; k <= 2; k++) {
                dp[i][j][0] = (dp[i][j][0] + dp[i - 1][j][k]) % MOD;
            }
        }
        // 以 A 结尾的数量
        for (int k = 0; k <= 2; k++) {
            dp[i][1][0] = (dp[i][1][0] + dp[i - 1][0][k]) % MOD;
        }
        // 以 L 结尾的数量
        for (int j = 0; j <= 1; j++) {
            for (int k = 1; k <= 2; k++) {
                dp[i][j][k] = (dp[i][j][k] + dp[i - 1][j][k - 1]) % MOD;
            }
        }
    }
    int sum = 0;
    for (int j = 0; j <= 1; j++) {
        for (int k = 0; k <= 2; k++) {
            sum = (sum + dp[n][j][k]) % MOD;
        }
    }
    return sum;
}
```

```Go
func checkRecord(n int) (ans int) {
    const mod int = 1e9 + 7
    dp := make([][2][3]int, n+1) // 三个维度分别表示：长度，A 的数量，结尾连续 L 的数量
    dp[0][0][0] = 1
    for i := 1; i <= n; i++ {
        // 以 P 结尾的数量
        for j := 0; j <= 1; j++ {
            for k := 0; k <= 2; k++ {
                dp[i][j][0] = (dp[i][j][0] + dp[i-1][j][k]) % mod
            }
        }
        // 以 A 结尾的数量
        for k := 0; k <= 2; k++ {
            dp[i][1][0] = (dp[i][1][0] + dp[i-1][0][k]) % mod
        }
        // 以 L 结尾的数量
        for j := 0; j <= 1; j++ {
            for k := 1; k <= 2; k++ {
                dp[i][j][k] = (dp[i][j][k] + dp[i-1][j][k-1]) % mod
            }
        }
    }
    for j := 0; j <= 1; j++ {
        for k := 0; k <= 2; k++ {
            ans = (ans + dp[n][j][k]) % mod
        }
    }
    return ans
}
```

注意到 $dp[i][][]$ 只会从 $dp[i-1][][]$ 转移得到。因此可以将 $dp$ 中的总天数的维度省略，将空间复杂度优化到 $O(1)$。

```Java
class Solution {
    public int checkRecord(int n) {
        final int MOD = 1000000007;
        int[][] dp = new int[2][3]; // A 的数量，结尾连续 L 的数量
        dp[0][0] = 1;
        for (int i = 1; i <= n; i++) {
            int[][] dpNew = new int[2][3];
            // 以 P 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 0; k <= 2; k++) {
                    dpNew[j][0] = (dpNew[j][0] + dp[j][k]) % MOD;
                }
            }
            // 以 A 结尾的数量
            for (int k = 0; k <= 2; k++) {
                dpNew[1][0] = (dpNew[1][0] + dp[0][k]) % MOD;
            }
            // 以 L 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 1; k <= 2; k++) {
                    dpNew[j][k] = (dpNew[j][k] + dp[j][k - 1]) % MOD;
                }
            }
            dp = dpNew;
        }
        int sum = 0;
        for (int j = 0; j <= 1; j++) {
            for (int k = 0; k <= 2; k++) {
                sum = (sum + dp[j][k]) % MOD;
            }
        }
        return sum;
    }
}
```

```CSharp
public class Solution {
    public int CheckRecord(int n) {
        const int MOD = 1000000007;
        int[,] dp = new int[2, 3]; // A 的数量，结尾连续 L 的数量
        dp[0, 0] = 1;
        for (int i = 1; i <= n; i++) {
            int[,] dpNew = new int[2, 3];
            // 以 P 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 0; k <= 2; k++) {
                    dpNew[j, 0] = (dpNew[j, 0] + dp[j, k]) % MOD;
                }
            }
            // 以 A 结尾的数量
            for (int k = 0; k <= 2; k++) {
                dpNew[1, 0] = (dpNew[1, 0] + dp[0, k]) % MOD;
            }
            // 以 L 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 1; k <= 2; k++) {
                    dpNew[j, k] = (dpNew[j, k] + dp[j, k - 1]) % MOD;
                }
            }
            dp = dpNew;
        }
        int sum = 0;
        for (int j = 0; j <= 1; j++) {
            for (int k = 0; k <= 2; k++) {
                sum = (sum + dp[j, k]) % MOD;
            }
        }
        return sum;
    }
}
```

```JavaScript
var checkRecord = function(n) {
    const MOD = 1000000007;
    let dp = new Array(2).fill(0).map(() => new Array(3).fill(0)); // A 的数量，结尾连续 L 的数量
    dp[0][0] = 1;
    for (let i = 1; i <= n; i++) {
        const dpNew = new Array(2).fill(0).map(() => new Array(3).fill(0));
        // 以 P 结尾的数量
        for (let j = 0; j <= 1; j++) {
            for (let k = 0; k <= 2; k++) {
                dpNew[j][0] = (dpNew[j][0] + dp[j][k]) % MOD;
            }
        }
        // 以 A 结尾的数量
        for (let k = 0; k <= 2; k++) {
            dpNew[1][0] = (dpNew[1][0] + dp[0][k]) % MOD;
        }
        // 以 L 结尾的数量
        for (let j = 0; j <= 1; j++) {
            for (let k = 1; k <= 2; k++) {
                dpNew[j][k] = (dpNew[j][k] + dp[j][k - 1]) % MOD;
            }
        }
        dp = dpNew;
    }
    let sum = 0;
    for (let j = 0; j <= 1; j++) {
        for (let k = 0; k <= 2; k++) {
            sum = (sum + dp[j][k]) % MOD;
        }
    }
    return sum;
};
```

```Python
class Solution:
    def checkRecord(self, n: int) -> int:
        MOD = 10**9 + 7
        # A 的数量，结尾连续 L 的数量
        dp = [[0, 0, 0], [0, 0, 0]]
        dp[0][0] = 1

        for i in range(1, n + 1):
            dpNew = [[0, 0, 0], [0, 0, 0]]

            # 以 P 结尾的数量
            for j in range(0, 2):
                for k in range(0, 3):
                    dpNew[j][0] = (dpNew[j][0] + dp[j][k]) % MOD
            
            # 以 A 结尾的数量
            for k in range(0, 3):
                dpNew[1][0] = (dpNew[1][0] + dp[0][k]) % MOD
            
            # 以 L 结尾的数量
            for j in range(0, 2):
                for k in range(1, 3):
                    dpNew[j][k] = (dpNew[j][k] + dp[j][k - 1]) % MOD
            
            dp = dpNew
        
        total = 0
        for j in range(0, 2):
            for k in range(0, 3):
                total += dp[j][k]
        
        return total % MOD
```

```C++
class Solution {
public:
    static constexpr int MOD = 1'000'000'007;

    int checkRecord(int n) {
        int dp[2][3];  // A 的数量，结尾连续 L 的数量
        memset(dp, 0, sizeof(dp));
        dp[0][0] = 1;
        for (int i = 1; i <= n; i++) {
            int dpNew[2][3];  // A 的数量，结尾连续 L 的数量
            memset(dpNew, 0, sizeof(dpNew));
            // 以 P 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 0; k <= 2; k++) {
                    dpNew[j][0] = (dpNew[j][0] + dp[j][k]) % MOD;
                }
            }
            // 以 A 结尾的数量
            for (int k = 0; k <= 2; k++) {
                dpNew[1][0] = (dpNew[1][0] + dp[0][k]) % MOD;
            }
            // 以 L 结尾的数量
            for (int j = 0; j <= 1; j++) {
                for (int k = 1; k <= 2; k++) {
                    dpNew[j][k] = (dpNew[j][k] + dp[j][k - 1]) % MOD;
                }
            }
            memcpy(dp, dpNew, sizeof(dp));
        }
        int sum = 0;
        for (int j = 0; j <= 1; j++) {
            for (int k = 0; k <= 2; k++) {
                sum = (sum + dp[j][k]) % MOD;
            }
        }
        return sum;
    }
};
```

```C
const int MOD = 1000000007;

int checkRecord(int n) {
    int dp[2][3];  // A 的数量，结尾连续 L 的数量
    memset(dp, 0, sizeof(dp));
    dp[0][0] = 1;
    for (int i = 1; i <= n; i++) {
        int dpNew[2][3];  // A 的数量，结尾连续 L 的数量
        memset(dpNew, 0, sizeof(dpNew));
        // 以 P 结尾的数量
        for (int j = 0; j <= 1; j++) {
            for (int k = 0; k <= 2; k++) {
                dpNew[j][0] = (dpNew[j][0] + dp[j][k]) % MOD;
            }
        }
        // 以 A 结尾的数量
        for (int k = 0; k <= 2; k++) {
            dpNew[1][0] = (dpNew[1][0] + dp[0][k]) % MOD;
        }
        // 以 L 结尾的数量
        for (int j = 0; j <= 1; j++) {
            for (int k = 1; k <= 2; k++) {
                dpNew[j][k] = (dpNew[j][k] + dp[j][k - 1]) % MOD;
            }
        }
        memcpy(dp, dpNew, sizeof(dp));
    }
    int sum = 0;
    for (int j = 0; j <= 1; j++) {
        for (int k = 0; k <= 2; k++) {
            sum = (sum + dp[j][k]) % MOD;
        }
    }
    return sum;
}
```

```Go
func checkRecord(n int) (ans int) {
    const mod int = 1e9 + 7
    dp := [2][3]int{} // A 的数量，结尾连续 L 的数量
    dp[0][0] = 1
    for i := 1; i <= n; i++ {
        dpNew := [2][3]int{}
        // 以 P 结尾的数量
        for j := 0; j <= 1; j++ {
            for k := 0; k <= 2; k++ {
                dpNew[j][0] = (dpNew[j][0] + dp[j][k]) % mod
            }
        }
        // 以 A 结尾的数量
        for k := 0; k <= 2; k++ {
            dpNew[1][0] = (dpNew[1][0] + dp[0][k]) % mod
        }
        // 以 L 结尾的数量
        for j := 0; j <= 1; j++ {
            for k := 1; k <= 2; k++ {
                dpNew[j][k] = (dpNew[j][k] + dp[j][k-1]) % mod
            }
        }
        dp = dpNew
    }
    for j := 0; j <= 1; j++ {
        for k := 0; k <= 2; k++ {
            ans = (ans + dp[j][k]) % mod
        }
    }
    return ans
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。动态规划需要计算 $n$ 天的状态，每天的状态有 $2 \times 3=6$ 个，每天的状态需要 $O(1)$ 的时间计算。
- 空间复杂度：$O(1)$。使用空间优化的实现，空间复杂度是 $O(1)$。

#### 方法二：矩阵快速幂

我们还可以使用矩阵快速幂来求解，该方法可以将方法一的时间复杂度由 $O(n)$ 降为 $O(logn)$。

为了使用矩阵快速幂，需要将方法一的动态规划表示中的 $j$ 和 $k$ 合并到一个维度，即动态规划的状态为：$dp[i][j \times 3+k]$ 表示前 $i$ 天有 $j$ 个 $‘A’$ 且结尾有连续 $k$ 个 $‘L’$ 的可奖励的出勤记录的数量，其中 $0 \le i \le n$，$0 \le j \le 1$，$0 \le k \le 2$，$0 \le j \times 3+k<6$。

在新的动态规划状态定义下，边界情况是 $dp[0][0]=1$，当 $1 \le i \le n$ 时，状态转移方程如下：

$$\left\{\begin{array}{l}dp[i][0]=dp[i-1][0]+dp[i-1][1]+dp[i-1][2] \\ dp[i][1]=dp[i-1][0] \\ dp[i][2]=dp[i-1][1] \\ dp[i][3]=dp[i-1][0]+dp[i-1][1]+dp[i-1][2]+dp[i-1][3]+dp[i-1][4]+dp[i-1][5] \\ dp[i][4]=dp[i-1][3] \\ dp[i][5]=dp[i-1][4]\end{array}\right.$$

令 $dp[n]$ 表示包含 $6$ 个元素的行向量：

$$dp[n]=[dp[n][0] dp[n][1], dp[n][2], dp[n][3]dp[n][4]dp[n][5]]$$

我们可以构建这样一个递推关系：

$$dp[n]=dp[n-1] \times ⎣⎡111000100000010000111111000100000010⎦⎤$$

因此：

$$dp[n]=dp[0] \times ⎣⎡111000100000010000111111000100000010⎦⎤n$$

令：

$$M=⎣⎡111000100000010000111111000100000010⎦⎤$$

因此只要我们能快速计算矩阵 $M$ 的 $n$ 次幂，就可以得到 $dp[n]$ 的值，然后计算可奖励的出勤记录的数量。如果直接求取 $M^n$，时间复杂度是 $O(n)$，可以定义矩阵乘法，然后用快速幂算法来加速这里 $M^n$ 的求取。计算过程中需要将结果对 $10^9+7$ 取模。

```Java
class Solution {
    static final int MOD = 1000000007;

    public int checkRecord(int n) {
        long[][] mat = {{1, 1, 0, 1, 0, 0},
                        {1, 0, 1, 1, 0, 0},
                        {1, 0, 0, 1, 0, 0},
                        {0, 0, 0, 1, 1, 0},
                        {0, 0, 0, 1, 0, 1},
                        {0, 0, 0, 1, 0, 0}};
        long[][] res = pow(mat, n);
        long sum = Arrays.stream(res[0]).sum();
        return (int) (sum % MOD);
    }

    public long[][] pow(long[][] mat, int n) {
        long[][] ret = {{1, 0, 0, 0, 0, 0}};
        while (n > 0) {
            if ((n & 1) == 1) {
                ret = multiply(ret, mat);
            }
            n >>= 1;
            mat = multiply(mat, mat);
        }
        return ret;
    }

    public long[][] multiply(long[][] a, long[][] b) {
        int rows = a.length, columns = b[0].length, temp = b.length;
        long[][] c = new long[rows][columns];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                for (int k = 0; k < temp; k++) {
                    c[i][j] += a[i][k] * b[k][j];
                    c[i][j] %= MOD;
                }
            }
        }
        return c;
    }
}
```

```CSharp
public class Solution {
    const int MOD = 1000000007;

    public int CheckRecord(int n) {
        long[,] mat = {{1, 1, 0, 1, 0, 0},
                       {1, 0, 1, 1, 0, 0},
                       {1, 0, 0, 1, 0, 0},
                       {0, 0, 0, 1, 1, 0},
                       {0, 0, 0, 1, 0, 1},
                       {0, 0, 0, 1, 0, 0}};
        long[,] res = Pow(mat, n);
        int sum = 0;
        for (int i = 0; i < 6; i++) {
            sum = (sum + (int) res[0, i]) % MOD;
        }
        return sum;
    }

    public long[,] Pow(long[,] mat, int n) {
        long[,] ret = {{1, 0, 0, 0, 0, 0},
                       {0, 1, 0, 0, 0, 0},
                       {0, 0, 1, 0, 0, 0},
                       {0, 0, 0, 1, 0, 0},
                       {0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 0, 0, 1}};
        while (n > 0) {
            if ((n & 1) == 1) {
                ret = Multiply(ret, mat);
            }
            n >>= 1;
            mat = Multiply(mat, mat);
        }
        return ret;
    }

    public long[,] Multiply(long[,] a, long[,] b) {
        int rows = a.GetLength(0), columns = b.GetLength(1), temp = b.GetLength(0);
        long[,] c = new long[rows, columns];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                for (int k = 0; k < temp; k++) {
                    c[i, j] += a[i, k] * b[k, j];
                    c[i, j] %= MOD;
                }
            }
        }
        return c;
    }
}
```

```JavaScript
var checkRecord = function(n) {
    const MOD = BigInt(1000000007);
    
    const pow = (mat, n) => {
        let ret = [[1, 0, 0, 0, 0, 0]];
        while (n > 0) {
            if ((n & 1) === 1) {
                ret = multiply(ret, mat);
            }
            n >>= 1;
            mat = multiply(mat, mat);
        }
        return ret;
    }

    const multiply = (a, b) => {
        const rows = a.length, columns = b[0].length, temp = b.length;
        const c = new Array(rows).fill(0).map(() => new Array(columns).fill(BigInt(0)));
        for (let i = 0; i < rows; i++) {
            for (let j = 0; j < columns; j++) {
                for (let k = 0; k < temp; k++) {
                    c[i][j] += BigInt(BigInt(a[i][k]) * BigInt(b[k][j]));
                    c[i][j] %= MOD;
                }
            }
        }
        return c;
    }

    const mat = [[1, 1, 0, 1, 0, 0],
                 [1, 0, 1, 1, 0, 0],
                 [1, 0, 0, 1, 0, 0],
                 [0, 0, 0, 1, 1, 0],
                 [0, 0, 0, 1, 0, 1],
                 [0, 0, 0, 1, 0, 0]];
    const res = pow(mat, n);
    const sum = BigInt(eval(res[0].join("+")));
    return sum % MOD;
};
```

```Python
class Solution:
    def checkRecord(self, n: int) -> int:
        MOD = 10**9 + 7
        mat = [
            [1, 1, 0, 1, 0, 0],
            [1, 0, 1, 1, 0, 0],
            [1, 0, 0, 1, 0, 0],
            [0, 0, 0, 1, 1, 0],
            [0, 0, 0, 1, 0, 1],
            [0, 0, 0, 1, 0, 0],
        ]
        
        def multiply(a: List[List[int]], b: List[List[int]]) -> List[List[int]]:
            rows, columns, temp = len(a), len(b[0]), len(b)
            c = [[0] * columns for _ in range(rows)]
            for i in range(rows):
                for j in range(columns):
                    for k in range(temp):
                        c[i][j] += a[i][k] * b[k][j]
                        c[i][j] %= MOD
            return c
        
        def matrixPow(mat: List[List[int]], n: int) -> List[List[int]]:
            ret = [[1, 0, 0, 0, 0, 0]]
            while n > 0:
                if (n & 1) == 1:
                    ret = multiply(ret, mat)
                n >>= 1
                mat = multiply(mat, mat)
            return ret

        res = matrixPow(mat, n)
        ans = sum(res[0])
        return ans % MOD
```

```C++
class Solution {
public:
    static constexpr int MOD = 1'000'000'007;

    vector<vector<long>> pow(vector<vector<long>> mat, int n) {
        vector<vector<long>> ret = {{1, 0, 0, 0, 0, 0}};
        while (n > 0) {
            if ((n & 1) == 1) {
                ret = multiply(ret, mat);
            }
            n >>= 1;
            mat = multiply(mat, mat);
        }
        return ret;
    }

    vector<vector<long>> multiply(vector<vector<long>> a, vector<vector<long>> b) {
        int rows = a.size(), columns = b[0].size(), temp = b.size();
        vector<vector<long>> c(rows, vector<long>(columns));
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                for (int k = 0; k < temp; k++) {
                    c[i][j] += a[i][k] * b[k][j];
                    c[i][j] %= MOD;
                }
            }
        }
        return c;
    }

    int checkRecord(int n) {
        vector<vector<long>> mat = {{1, 1, 0, 1, 0, 0}, {1, 0, 1, 1, 0, 0}, {1, 0, 0, 1, 0, 0}, {0, 0, 0, 1, 1, 0}, {0, 0, 0, 1, 0, 1}, {0, 0, 0, 1, 0, 0}};
        vector<vector<long>> res = pow(mat, n);
        long sum = accumulate(res[0].begin(), res[0].end(), 0ll);
        return (int)(sum % MOD);
    }
};
```

```C
const int MOD = 1000000007;

struct Matrix {
    long mat[6][6];
    int row, col;
};

struct Matrix multiply(struct Matrix a, struct Matrix b) {
    int rows = a.row, columns = b.col, temp = b.row;
    struct Matrix c;
    memset(c.mat, 0, sizeof(c.mat));
    c.row = rows, c.col = columns;
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < columns; j++) {
            for (int k = 0; k < temp; k++) {
                c.mat[i][j] += a.mat[i][k] * b.mat[k][j];
                c.mat[i][j] %= MOD;
            }
        }
    }
    return c;
}

struct Matrix matricPow(struct Matrix mat, int n) {
    struct Matrix ret = {{{1, 0, 0, 0, 0, 0}}, 1, 6};
    while (n > 0) {
        if ((n & 1) == 1) {
            ret = multiply(ret, mat);
        }
        n >>= 1;
        mat = multiply(mat, mat);
    }
    return ret;
}

int checkRecord(int n) {
    struct Matrix mat = {{{1, 1, 0, 1, 0, 0}, {1, 0, 1, 1, 0, 0}, {1, 0, 0, 1, 0, 0}, {0, 0, 0, 1, 1, 0}, {0, 0, 0, 1, 0, 1}, {0, 0, 0, 1, 0, 0}}, 6, 6};
    struct Matrix res = matricPow(mat, n);
    long sum = 0;
    for (int i = 0; i < res.col; i++) {
        sum += res.mat[0][i];
    }
    return (int)(sum % MOD);
}
```

```Go
const mod int = 1e9 + 7

type matrix [6][6]int

func (a matrix) mul(b matrix) matrix {
    c := matrix{}
    for i, row := range a {
        for j := range b[0] {
            for k, v := range row {
                c[i][j] = (c[i][j] + v*b[k][j]) % mod
            }
        }
    }
    return c
}

func (a matrix) pow(n int) matrix {
    res := matrix{}
    for i := range res {
        res[i][i] = 1
    }
    for ; n > 0; n >>= 1 {
        if n&1 > 0 {
            res = res.mul(a)
        }
        a = a.mul(a)
    }
    return res
}

func checkRecord(n int) (ans int) {
    m := matrix{
        {1, 1, 0, 1, 0, 0},
        {1, 0, 1, 1, 0, 0},
        {1, 0, 0, 1, 0, 0},
        {0, 0, 0, 1, 1, 0},
        {0, 0, 0, 1, 0, 1},
        {0, 0, 0, 1, 0, 0},
    }
    res := m.pow(n)
    for _, v := range res[0] {
        ans = (ans + v) % mod
    }
    return ans
}
```

**复杂度分析**

- 时间复杂度：$O(logn)$。
- 空间复杂度：$O(1)$。
