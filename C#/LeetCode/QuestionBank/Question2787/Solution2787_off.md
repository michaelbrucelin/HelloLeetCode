### [将一个数字表示成幂的和的方案数](https://leetcode.cn/problems/ways-to-express-an-integer-as-sum-of-powers/solutions/3741781/jiang-yi-ge-shu-zi-biao-shi-cheng-mi-de-bb9ip/)

#### 方法一：动态规划

**思路与算法**

给定数字 $n$，需要返回**互不相同**整数 $[n_1,n_2,\dots ,n_k]$ 的集合数目，满足 $n=n_1^x+n_2^x+\dots +n_k^x$。我们可将 $n$ 看成背包容量，$[1^x,2^x,3^x,\dots ]$ 看成物品，题目本质就是一个 **0-1** 背包问题。我们设 $dp[i][j]$ 表示前 $i$ 个数字中选择不同数字的 $x$ 次幂之和为 $j$ 的方案数。我们从 $1$ 开始枚举所有的整数，假设当前枚举的数字为 $i$，幂次和为 $j$，则此时有以下推论：

- 如果当前不选择数字 $i$，则等价于从前 $i-1$ 个数字中选择不同数字使得所选数字的 $x$ 次幂之和为 $j$，此时可得递推公式为：$dp[i][j]=dp[i-1][j]$；
- 如果当前选择数字 $i$，i 的 $x$ 次幂为 $i^x$，此时需要满足 $i^x\le j$，此时需要从前 $i-1$ 个数字中选择不同数字使得其 $x$ 次幂之和为 $j-i^x$，然后再加上 $i^x$ 才能使得幂之和为 $j$，此时可得到递推公式为：$dp[i][j]=dp[i-1][j-i^x]$；

综上可知动态规划的状态转移公式为：

- 如果满足 $j<i^x$ 时，$dp[i][j]=dp[i-1][j]$；
- 如果满足 $j\ge i^x$ 时，$dp[i][j]=dp[i-1][j]+dp[i-1][j-i^x]$；

根据动态规划的状态转移方程，在外层循环依次从小到枚举 $i$，在内存循环依次从小到大枚举 $j$，计算每个子状态 $dp[i][j]$，最终 $dp[n][n]$ 即为答案。

**代码**

```C++
class Solution {
public:
    int numberOfWays(int n, int x) {
        long long mod = 1e9 + 7;
        vector<vector<long long>> dp(n + 1, vector<long long>(n + 1));
        dp[0][0] = 1;
        for (int i = 1; i <= n; i++) {
            long long val = pow(i, x);
            for (int j = 0; j <= n; j++) {
                dp[i][j] = dp[i - 1][j];
                if (j >= val) {
                    dp[i][j] = (dp[i][j] + dp[i - 1][j - val]) % mod;
                }
            }
        }
        return dp[n][n];
    }
};
```

```Java
class Solution {
    final int MOD = 1_000_000_007;

    public int numberOfWays(int n, int x) {
        long[][] dp = new long[n + 1][n + 1];
        dp[0][0] = 1;
        for (int i = 1; i <= n; i++) {
            long val = (long)Math.pow(i, x);
            for (int j = 0; j <= n; j++) {
                dp[i][j] = dp[i - 1][j];
                if (j >= val) {
                    dp[i][j] = (dp[i][j] + dp[i - 1][j - (int)val]) % MOD;
                }
            }
        }
        return (int)dp[n][n];
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1_000_000_007;

    public int NumberOfWays(int n, int x) {
        long[,] dp = new long[n + 1, n + 1];
        dp[0, 0] = 1;
        for (int i = 1; i <= n; i++) {
            long val = (long)Math.Pow(i, x);
            for (int j = 0; j <= n; j++) {
                dp[i, j] = dp[i - 1, j];
                if (j >= val) {
                    dp[i, j] = (dp[i, j] + dp[i - 1, j - (int)val]) % MOD;
                }
            }
        }
        return (int)dp[n, n];
    }
}
```

```Go
func numberOfWays(n int, x int) int {
    const mod = 1_000_000_007
    dp := make([][]int64, n + 1)
    for i := range dp {
        dp[i] = make([]int64, n + 1)
    }
    dp[0][0] = 1
    for i := 1; i <= n; i++ {
        val := int64(math.Pow(float64(i), float64(x)))
        for j := 0; j <= n; j++ {
            dp[i][j] = dp[i - 1][j]
            if j >= int(val) {
                dp[i][j] = (dp[i][j] + dp[i - 1][j - int(val)]) % mod
            }
        }
    }
    return int(dp[n][n])
}
```

```Python
class Solution:
    def numberOfWays(self, n: int, x: int) -> int:
        MOD = 10**9 + 7
        dp = [[0] * (n + 1) for _ in range(n + 1)]
        dp[0][0] = 1
        for i in range(1, n + 1):
            val = i ** x
            for j in range(n + 1):
                dp[i][j] = dp[i - 1][j]
                if j >= val:
                    dp[i][j] = (dp[i][j] + dp[i - 1][j - val]) % MOD
        return dp[n][n]
```

```C
int numberOfWays(int n, int x) {
    const int MOD = 1e9 + 7;
    long long dp[n + 1][n + 1];
    memset(dp, 0, sizeof(dp));
    dp[0][0] = 1;
    for (int i = 1; i <= n; i++) {
        long long val = (long long)pow(i, x);
        for (int j = 0; j <= n; j++) {
            dp[i][j] = dp[i - 1][j];
            if (j >= val) {
                dp[i][j] = (dp[i][j] + dp[i - 1][j - val]) % MOD;
            }
        }
    }
    
    return dp[n][n];
}
```

```JavaScript
var numberOfWays = function(n, x) {
    const MOD = 1e9 + 7;
    const dp = Array.from({ length: n + 1 }, () => Array(n + 1).fill(0));
    dp[0][0] = 1;
    for (let i = 1; i <= n; i++) {
        const val = Math.pow(i, x);
        for (let j = 0; j <= n; j++) {
            dp[i][j] = dp[i - 1][j];
            if (j >= val) {
                dp[i][j] = (dp[i][j] + dp[i - 1][j - val]) % MOD;
            }
        }
    }
    return dp[n][n];
}
```

```TypeScript
function numberOfWays(n: number, x: number): number {
    const MOD = 1e9 + 7;
    const dp: number[][] = Array.from({ length: n + 1 }, () => Array(n + 1).fill(0));
    dp[0][0] = 1;
    for (let i = 1; i <= n; i++) {
        const val = Math.pow(i, x);
        for (let j = 0; j <= n; j++) {
            dp[i][j] = dp[i - 1][j];
            if (j >= val) {
                dp[i][j] = (dp[i][j] + dp[i - 1][j - val]) % MOD;
            }
        }
    }
    return dp[n][n];
}
```

```Rust
impl Solution {
    pub fn number_of_ways(n: i32, x: i32) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let n = n as usize;
        let x = x as u32;
        let mut dp = vec![vec![0; n + 1]; n + 1];
        dp[0][0] = 1;
        for i in 1..=n {
            let val = (i as i64).pow(x);
            for j in 0..=n {
                dp[i][j] = dp[i - 1][j];
                if j >= val as usize {
                    dp[i][j] = (dp[i][j] + dp[i - 1][j - val as usize]) % MOD;
                }
            }
        }
        dp[n][n] as i32
    }
}
```

**空间优化**

根据背包原理，可以对空间进行降维，设 $dp[j]$ 表示使用若干个互不相同的数，其 $x$ 次幂的和为 $j$ 的方案数。实际计算时，可以倒序从大到小枚举 $j$，当尝试加入数字 $i$ 时，此时可得到如下推论：

- 如果满足 $j<i^x$ 时，则 $dp[j]$ 保持不变；
- 如果满足 $j\ge i^x$ 时，$dp[j]=dp[j]+dp[j-i^x]$；

依次计算并返回 $dp[n]$ 即为答案。

```C++
class Solution {
public:
    int numberOfWays(int n, int x) {
        long long mod = 1e9 + 7;
        vector<long long> dp(n + 1);
        dp[0] = 1;
        for (int i = 1; i <= n; i++) {
            long long val = pow(i, x);
            if (val > n) {
                break;
            }
            for (int j = n; j >= val; j--) {
                dp[j] = (dp[j] + dp[j - val]) % mod;
            }
        }
        return dp[n];
    }
};
```

```Java
class Solution {
    final int MOD = 1_000_000_007;

    public int numberOfWays(int n, int x) {
        long[] dp = new long[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++) {
            int val = (int)Math.pow(i, x);
            if (val > n) {
                break;
            }
            for (int j = n; j >= val; j--) {
                dp[j] = (dp[j] + dp[j - val]) % MOD;
            }
        }
        return (int)dp[n];
    }
}
```

```CSharp
public class Solution {
    public int NumberOfWays(int n, int x) {
        const int MOD = 1_000_000_007;
        long[] dp = new long[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++) {
            int val = (int)Math.Pow(i, x);
            if (val > n) {
                break;
            }
            for (int j = n; j >= val; j--) {
                dp[j] = (dp[j] + dp[j - val]) % MOD;
            }
        }
        return (int)dp[n];
    }
}
```

```Go
func numberOfWays(n int, x int) int {
    const mod = 1_000_000_007
    dp := make([]int, n + 1)
    dp[0] = 1
    for i := 1; i <= n; i++ {
        val := int(math.Pow(float64(i), float64(x)))
        if val > n {
            break
        }
        for j := n; j >= val; j-- {
            dp[j] = (dp[j] + dp[j - val]) % mod
        }
    }
    return dp[n]
}
```

```Python
class Solution:
    def numberOfWays(self, n: int, x: int) -> int:
        MOD = 10**9 + 7
        dp = [0] * (n + 1)
        dp[0] = 1

        for i in range(1, n + 1):
            val = i**x
            if val > n:
                break
            for j in range(n, val - 1, -1):
                dp[j] = (dp[j] + dp[j - val]) % MOD

        return dp[n]
```

```C
int numberOfWays(int n, int x) {
    const int mod = 1000000007;
    int* dp = calloc(n + 1, sizeof(int));
    dp[0] = 1;
    for (int i = 1; i <= n; i++) {
        int val = (int)pow(i, x);
        if (val > n) {
            break;
        }
        for (int j = n; j >= val; j--) {
            dp[j] = (dp[j] + dp[j - val]) % mod;
        }
    }
    int result = dp[n];
    free(dp);
    
    return result;
}
```

```JavaScript
var numberOfWays = function(n, x) {
    const mod = 1e9 + 7;
    const dp = Array(n + 1).fill(0);
    dp[0] = 1;
    for (let i = 1; i <= n; i++) {
        let val = Math.pow(i, x);
        if (val > n) {
            break;
        }
        for (let j = n; j >= val; j--) {
            dp[j] = (dp[j] + dp[j - val]) % mod;
        }
    }
    return dp[n];
}
```

```TypeScript
function numberOfWays(n: number, x: number): number {
    const mod = 1e9 + 7;
    const dp: number[] = Array(n + 1).fill(0);
    dp[0] = 1;
    for (let i = 1; i <= n; i++) {
        const val = Math.pow(i, x);
        if (val > n) {
            break;
        }
        for (let j = n; j >= val; j--) {
            dp[j] = (dp[j] + dp[j - val]) % mod;
        }
    }
    return dp[n];
};
```

```Rust
impl Solution {
    pub fn number_of_ways(n: i32, x: i32) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let n = n as usize;
        let mut dp = vec![0i64; n + 1];
        dp[0] = 1;
        for i in 1..= n {
            let val = (i as i64).pow(x as u32) as usize;
            if val > n {
                break;
            }
            for j in (val..= n).rev() {
                dp[j] = (dp[j] + dp[j - val]) % MOD;
            }
        }
        dp[n] as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\sqrt[x]{n})$，其中 $n,x$ 表示给定的数字。从小到大遍历 $i$，由于幂次和不超过 $n$，因此 $i$ 的最大值不超过 $xn$，动态规划最多需要计算 $n\sqrt[x]{n}$ 个子状态，每个子状态的计算时间为 $O(1)$，因此时间复杂度为 $O(n\sqrt[x]{n})$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定的数字。经过空间优化后，仅需要存储 $n$ 个状态即可，需要的空间为 $O(n)$。
