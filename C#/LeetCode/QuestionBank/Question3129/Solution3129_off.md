### [找出所有稳定的二进制数组 I](https://leetcode.cn/problems/find-all-possible-stable-binary-arrays-i/solutions/2864829/zhao-chu-suo-you-wen-ding-de-er-jin-zhi-29q03/)

#### 方法一：动态规划

题目要求二进制数组 $arr$ 中每个长度超过 $limit$ 的子数组同时包含 $0$ 和 $1$，这个条件等价于二进制数组 $arr$ 中每个长度等于 $limit+1$ 的子数组都同时包含 $0$ 和 $1$（读者可以思考一下证明过程）。

按照题目要求，我们需要将 $zero$ 个 $0$ 和 $one$ 个 $1$ 依次填入二进制数组 $arr$，使用 $dp_0[i][j]$ 表示已经填入 $i$ 个 $0$ 和 $j$ 个 $1$，并且最后填入的数字为 $0$ 的可行方案数目，$dp_1[i][j]$ 表示已经填入 $i$ 个 $0$ 和 $j$ 个 $1$，并且最后填入的数字为 $1$ 的可行方案数目。对于 $dp_0[i][j]$，我们分析一下它的转换方程：

- 当 $j=0$ 且 $i \in [0,min(zero,limit)]$ 时：我们可以不断地填入 $0$，所以 $dp_0[i][j]=1$。
- 当 $i=0$，或者 $j=0$ 且 $i \notin [0,min(zero,limit)]$ 时：我们没法构造可行的方案，所以 $dp_0[i][j]=0$。
- 当 $i>0$ 且 $j>0$ 时：$dp_0[i][j]$ 可以分别由 $dp_0[i-1][j]$ 和 $dp_1[i-1][j]$ 转移而来，分别考虑两种情况：
  - 对于 $dp_1[i-1][j]$：显然可以通过在 $dp_1[i-1][j]$ 对应的所有填入方案后再填入一个 $0$ 得到对应的可行方案。
  - 对于 $dp_0[i-1][j]$：当 $i \le limit$ 时，显然可以通过在 $dp_1[i-1][j]$ 对应的所有填入方案后再填入一个 $0$ 得到对应的可行方案；当 $i > limit$ 时，我们需要去除一些不可行的方案数。因为 $dp_0[i-1][j]$ 对应的所有填入方案都是可行的，而只有一种情况会在额外填入一个 $0$ 时，变成不可行，即先前已经连续填入 $limit$ 个 $0$，对应的方案数为 $dp_1[i-limit-1][j]$。

根据以上分析，我们有 $dp_0[i][j]$ 的转移方程：

$$dp_0[i][j]=\left\{\begin{array}{ll}1, & i \in [0,min(zero,limit)],j=0 \\ dp_1[i-1][j]+dp_0[i-1][j]-dp_1[i-limit-1][j], & i>limit,j>0 \\ dp_1[i-1][j]+dp_0[i-1][j], & i \in [0,limit],j>0 \\ 0, & otherwise\end{array}\right.$$

同理，我们也可以获得 $dp_1[i][j]$ 的转移方程：

$$dp_1[i][j]=\left\{\begin{array}{ll}1, & i=0,j \in [0,min(one,limit)] \\ dp_0[i][j-1]+dp_1[i][j-1]-dp_0[i][j-limit-1], & i>0,j>limit \\ dp_0[i][j-1]+dp_1[i][j-1], & i>0,j \in [0,limit] \\ 0, & otherwise\end{array}\right.$$

最后，稳定二进制数组的数目等于 $dp_0[zero][one]+dp_1[zero][one]$。

```C++
class Solution {
public:
    int numberOfStableArrays(int zero, int one, int limit) {
        vector<vector<vector<long long>>> dp(zero + 1, vector<vector<long long>>(one + 1, vector<long long>(2)));
        long long mod = 1e9 + 7;
        for (int i = 0; i <= min(zero, limit); i++) {
            dp[i][0][0] = 1;
        }
        for (int j = 0; j <= min(one, limit); j++) {
            dp[0][j][1] = 1;
        }
        for (int i = 1; i <= zero; i++) {
            for (int j = 1; j <= one; j++) {
                if (i > limit) {
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1] - dp[i - limit - 1][j][1];
                } else {
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1];
                }
                dp[i][j][0] = (dp[i][j][0] % mod + mod) % mod;
                if (j > limit) {
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0] - dp[i][j - limit - 1][0];
                } else {
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0];
                }
                dp[i][j][1] = (dp[i][j][1] % mod + mod) % mod;
            }
        }
        return (dp[zero][one][0] + dp[zero][one][1]) % mod;
    }
};
```

```Java
class Solution {
    public int numberOfStableArrays(int zero, int one, int limit) {
        final long MOD = 1000000007;
        long[][][] dp = new long[zero + 1][one + 1][2];
        for (int i = 0; i <= Math.min(zero, limit); i++) {
            dp[i][0][0] = 1;
        }
        for (int j = 0; j <= Math.min(one, limit); j++) {
            dp[0][j][1] = 1;
        }
        for (int i = 1; i <= zero; i++) {
            for (int j = 1; j <= one; j++) {
                if (i > limit) {
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1] - dp[i - limit - 1][j][1];
                } else {
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1];
                }
                dp[i][j][0] = (dp[i][j][0] % MOD + MOD) % MOD;
                if (j > limit) {
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0] - dp[i][j - limit - 1][0];
                } else {
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0];
                }
                dp[i][j][1] = (dp[i][j][1] % MOD + MOD) % MOD;
            }
        }
        return (int) ((dp[zero][one][0] + dp[zero][one][1]) % MOD);
    }
}
```

```CSharp
public class Solution {
    public int NumberOfStableArrays(int zero, int one, int limit) {
        const long MOD = 1000000007;
        long[][][] dp = new long[zero + 1][][];
        for (int i = 0; i <= zero; i++) {
            dp[i] = new long[one + 1][];
            for (int j = 0; j <= one; j++) {
                dp[i][j] = new long[2];
            }
        }
        for (int i = 0; i <= Math.Min(zero, limit); i++) {
            dp[i][0][0] = 1;
        }
        for (int j = 0; j <= Math.Min(one, limit); j++) {
            dp[0][j][1] = 1;
        }
        for (int i = 1; i <= zero; i++) {
            for (int j = 1; j <= one; j++) {
                if (i > limit) {
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1] - dp[i - limit - 1][j][1];
                } else {
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1];
                }
                dp[i][j][0] = (dp[i][j][0] % MOD + MOD) % MOD;
                if (j > limit) {
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0] - dp[i][j - limit - 1][0];
                } else {
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0];
                }
                dp[i][j][1] = (dp[i][j][1] % MOD + MOD) % MOD;
            }
        }
        return (int) ((dp[zero][one][0] + dp[zero][one][1]) % MOD);
    }
}
```

```Go
func numberOfStableArrays(zero int, one int, limit int) int {
    dp := make([][][2]int, zero + 1)
    mod := int(1e9 + 7)
    for i := 0; i <= zero; i++ {
        dp[i] = make([][2]int, one + 1)
    }
    for i := 0; i <= min(zero, limit); i++ {
        dp[i][0][0] = 1
    }
    for j := 0; j <= min(one, limit); j++ {
        dp[0][j][1] = 1
    }
    for i := 1; i <= zero; i++ {
        for j := 1; j <= one; j++ {
            if i > limit {
                dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1] - dp[i - limit - 1][j][1]
            } else {
                dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1]
            }
            dp[i][j][0] = (dp[i][j][0] % mod + mod) % mod
            if j > limit {
                dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0] - dp[i][j - limit - 1][0]
            } else {
                dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0]
            }
            dp[i][j][1] = (dp[i][j][1] % mod + mod) % mod
        }
    }
    return (dp[zero][one][0] + dp[zero][one][1]) % mod
}
```

```Python
class Solution:
    def numberOfStableArrays(self, zero: int, one: int, limit: int) -> int:
        dp = [[[0, 0] for _ in range(one + 1)] for _ in range(zero + 1)]
        mod = int(1e9 + 7)
        for i in range(min(zero, limit) + 1):
            dp[i][0][0] = 1
        for j in range(min(one, limit) + 1):
            dp[0][j][1] = 1
        for i in range(1, zero + 1):
            for j in range(1, one + 1):
                if i > limit:
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1] - dp[i - limit - 1][j][1]
                else:
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1]
                dp[i][j][0] = (dp[i][j][0] % mod + mod) % mod
                if j > limit:
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0] - dp[i][j - limit - 1][0]
                else:
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0]
                dp[i][j][1] = (dp[i][j][1] % mod + mod) % mod
        return (dp[zero][one][0] + dp[zero][one][1]) % mod
```

```C
#define MOD 1000000007

int numberOfStableArrays(int zero, int one, int limit) {
    long long dp[zero + 1][one + 1][2];
    memset(dp, 0, sizeof(dp));
    for (int i = 0; i <= (zero < limit ? zero : limit); ++i) {
        dp[i][0][0] = 1;
    }
    for (int j = 0; j <= (one < limit ? one : limit); ++j) {
        dp[0][j][1] = 1;
    }
    for (int i = 1; i <= zero; ++i) {
        for (int j = 1; j <= one; ++j) {
            if (i > limit) {
                dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1] - dp[i - limit - 1][j][1];
            } else {
                dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1];
            }
            dp[i][j][0] = (dp[i][j][0] % MOD + MOD) % MOD;
            if (j > limit) {
                dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0] - dp[i][j - limit - 1][0];
            } else {
                dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0];
            }
            dp[i][j][1] = (dp[i][j][1] % MOD + MOD) % MOD;
        }
    }
    int result = (dp[zero][one][0] + dp[zero][one][1]) % MOD;
    return result;
}
```

```JavaScript
const MOD = 1000000007;

var numberOfStableArrays = function(zero, one, limit) {
    const dp = Array.from({ length: zero + 1 }, () =>
        Array.from({ length: one + 1 }, () => [0, 0])
    );

    for (let i = 0; i <= Math.min(zero, limit); i++) {
        dp[i][0][0] = 1;
    }
    for (let j = 0; j <= Math.min(one, limit); j++) {
        dp[0][j][1] = 1;
    }

    for (let i = 1; i <= zero; i++) {
        for (let j = 1; j <= one; j++) {
            if (i > limit) {
                dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1] - dp[i - limit - 1][j][1];
            } else {
                dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1];
            }
            dp[i][j][0] = (dp[i][j][0] % MOD + MOD) % MOD;
            if (j > limit) {
                dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0] - dp[i][j - limit - 1][0];
            } else {
                dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0];
            }
            dp[i][j][1] = (dp[i][j][1] % MOD + MOD) % MOD;
        }
    }
    return (dp[zero][one][0] + dp[zero][one][1]) % MOD;
};
```

```TypeScript
const MOD = 1000000007;

function numberOfStableArrays(zero: number, one: number, limit: number): number {
    const dp: number[][][] = Array.from({ length: zero + 1 }, () =>
        Array.from({ length: one + 1 }, () => [0, 0])
    );

    for (let i = 0; i <= Math.min(zero, limit); i++) {
        dp[i][0][0] = 1;
    }
    for (let j = 0; j <= Math.min(one, limit); j++) {
        dp[0][j][1] = 1;
    }

    for (let i = 1; i <= zero; i++) {
        for (let j = 1; j <= one; j++) {
            if (i > limit) {
                dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1] - dp[i - limit - 1][j][1];
            } else {
                dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1];
            }
            dp[i][j][0] = (dp[i][j][0] % MOD + MOD) % MOD;
            if (j > limit) {
                dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0] - dp[i][j - limit - 1][0];
            } else {
                dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0];
            }
            dp[i][j][1] = (dp[i][j][1] % MOD + MOD) % MOD;
        }
    }
    return (dp[zero][one][0] + dp[zero][one][1]) % MOD;
};
```

```Rust
const MOD: i32 = 1000000007;

impl Solution {
    pub fn number_of_stable_arrays(zero: i32, one: i32, limit: i32) -> i32 {
        let mut dp = vec![vec![vec![0; 2]; one as usize + 1]; zero as usize + 1];

        for i in 0..=zero.min(limit) as usize {
            dp[i][0][0] = 1;
        }
        for j in 0..=one.min(limit) as usize {
            dp[0][j][1] = 1;
        }

        for i in 1..=zero as usize {
            for j in 1..=one as usize {
                if i > limit as usize {
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1] - dp[i - limit as usize - 1][j][1];
                } else {
                    dp[i][j][0] = dp[i - 1][j][0] + dp[i - 1][j][1];
                }
                dp[i][j][0] = (dp[i][j][0] % MOD + MOD) % MOD;
                if j > limit as usize {
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0] - dp[i][j - limit as usize - 1][0];
                } else {
                    dp[i][j][1] = dp[i][j - 1][1] + dp[i][j - 1][0];
                }
                dp[i][j][1] = (dp[i][j][1] % MOD + MOD) % MOD;
            }
        }
        (dp[zero as usize][one as usize][0] + dp[zero as usize][one as usize][1]) % MOD
    }
}
```

**复杂度分析**

- 时间复杂度：$O(zero \times one)$，其中 $zero$ 和 $one$ 分别为 $0$ 和 $1$ 的出现次数。
- 空间复杂度：$O(zero \times one)$。
