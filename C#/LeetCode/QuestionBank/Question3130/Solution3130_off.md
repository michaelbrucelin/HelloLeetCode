### [找出所有稳定的二进制数组 II](https://leetcode.cn/problems/find-all-possible-stable-binary-arrays-ii/solutions/2869605/zhao-chu-suo-you-wen-ding-de-er-jin-zhi-6bimt/)

#### 方法一：记忆化搜索

**思路**

根据稳定数组的前两个条件，可知稳定数组的长度为 $zero+one$。第三个条件可知，稳定数组不存在长度为 $limit+1$ 的全 $0$ 或全 $1$ 子数组。

接下来我们分解问题，包含 $zero$ 个 $0$ 和 $one$ 个 $1$ 的稳定数组，末位元素可能为 $1$，也可能为 $0$。

- 如果末位元素为 $1$，我们需要知道有多少个包含 $zero$ 个 $0$ 和 $one-1$ 个 $1$ 的稳定数组，再去掉“由于添加了一个 $1$ 而使得原来的稳定数组变得不稳定”的情况。那么有哪些情况会使得原来稳定的数组变得不稳定呢？即原来的稳定数组的末尾连续 $1$ 的个数正好为 $limit$ 个。在这种情况下，添加一个 $1$ 会使得原来稳定的数组变得不稳定。这种情况出现的次数，即为包含 $zero$ 个 $0$ 和 $one-1-limit$ 个 $1$，且末位元素为 $0$ 的稳定数组的个数。
- 如果末位元素为 $0$，我们需要知道有多少个包含 $zero-1$ 个 $0$ 和 $one$ 个 $1$ 的稳定数组，再去掉“由于添加了一个 $0$ 而使得原来的稳定数组变得不稳定”的情况。

这样一来，我们就将问题分解为子问题了，可以用动态规划求解。用函数 $dp(zero,one,lastBit)$，来求解包含 $zero$ 个 $0$ 和 $one$ 个 $1$，并且末位元素为 $lastBit$ 的稳定数组的个数，其中 $lastBit$ 为 $0$ 或 $1$。根据上面的讨论，可以得到递推公式：

- $dp(zero,one,0) = dp(zero-1,one,0)+dp(zero-1,one,1)-dp(zero-1-limit,one,1)$
- $dp(zero,one,1) = dp(zero,one-1,0)+dp(zero,one-1,1)-dp(zero,one-1-limit,0)$。

另外考虑边界情况。如果 $zero$ 为 $0$，那么当 $lastBit$ 为 $1$ 或者 $one$ 大于 $limit$ 时，不存在这样的稳定数组，返回 $0$，否则返回 $1$。如果 $zero$ 为 $1$，也有对应的结论。

我们用记忆化搜索的方式来计算结果，记录所有的中间状态，最终返回 $dp(zero,one,0) + dp(zero,one,1)$ 取模后的结果。

**代码**

```Python
class Solution:
    def numberOfStableArrays(self, zero: int, one: int, limit: int) -> int:
        mod = 10 ** 9 + 7

        @cache
        def dp(zero, one, lastBit):
            if zero == 0:
                if lastBit == 0 or one > limit:
                    return 0
                else:
                    return 1
            elif one == 0:
                if lastBit == 1 or zero > limit:
                    return 0
                else:
                    return 1
            if lastBit == 0:
                res = dp(zero - 1, one, 0) + dp(zero - 1, one, 1)
                if zero > limit:
                    res -= dp(zero - limit - 1, one, 1)
            else:
                res = dp(zero, one - 1, 0) + dp(zero, one - 1, 1)
                if one > limit:
                    res -= dp(zero, one - limit - 1, 0)
            return res % mod
            
        res = (dp(zero, one, 0) + dp(zero, one, 1)) % mod
        dp.cache_clear()
        return res
```

```C++
class Solution {
public:
    int numberOfStableArrays(int zero, int one, int limit) {
        int mod = 1e9 + 7;
        vector<vector<vector<int>>> memo(zero + 1, vector<vector<int>>(one + 1, vector<int>(2, -1)));

        function<int(int, int, int)> dp = [&](int zero, int one, int lastBit) -> int {
            if (zero == 0) {
                return (lastBit == 0 || one > limit) ? 0 : 1;
            } else if (one == 0) {
                return (lastBit == 1 || zero > limit) ? 0 : 1;
            }

            if (memo[zero][one][lastBit] == -1) {
                int res = 0;
                if (lastBit == 0) {
                    res = (dp(zero - 1, one, 0) + dp(zero - 1, one, 1)) % mod;
                    if (zero > limit) {
                        res = (res - dp(zero - limit - 1, one, 1) + mod) % mod;
                    }
                } else {
                    res = (dp(zero, one - 1, 0) + dp(zero, one - 1, 1)) % mod;
                    if (one > limit) {
                        res = (res - dp(zero, one - limit - 1, 0) + mod) % mod;
                    }
                }
                memo[zero][one][lastBit] = res % mod;
            }
            return memo[zero][one][lastBit];
        };

        return (dp(zero, one, 0) + dp(zero, one, 1)) % mod;
    }
};
```

```Java
class Solution {
    static final int MOD = 1000000007;
    int[][][] memo;
    int limit;

    public int numberOfStableArrays(int zero, int one, int limit) {
        this.memo = new int[zero + 1][one + 1][2];
        for (int i = 0; i <= zero; i++) {
            for (int j = 0; j <= one; j++) {
                Arrays.fill(memo[i][j], -1);
            }
        }
        this.limit = limit;
        return (dp(zero, one, 0) + dp(zero, one, 1)) % MOD;
    }

    public int dp(int zero, int one, int lastBit) {
        if (zero == 0) {
            return (lastBit == 0 || one > limit) ? 0 : 1;
        } else if (one == 0) {
            return (lastBit == 1 || zero > limit) ? 0 : 1;
        }

        if (memo[zero][one][lastBit] == -1) {
            int res = 0;
            if (lastBit == 0) {
                res = (dp(zero - 1, one, 0) + dp(zero - 1, one, 1))% MOD;
                if (zero > limit) {
                    res = (res - dp(zero - limit - 1, one, 1) + MOD) % MOD;
                }
            } else {
                res = (dp(zero, one - 1, 0) + dp(zero, one - 1, 1)) % MOD;
                if (one > limit) {
                    res = (res - dp(zero, one - limit - 1, 0) + MOD) % MOD;
                }
            }
            memo[zero][one][lastBit] = res % MOD;
        }
        return memo[zero][one][lastBit];
    }
}
```

```CSharp
public class Solution {
    const int MOD = 1000000007;
    int[][][] memo;
    int limit;

    public int NumberOfStableArrays(int zero, int one, int limit) {
        this.memo = new int[zero + 1][][];
        for (int i = 0; i <= zero; i++) {
            memo[i] = new int[one + 1][];
            for (int j = 0; j <= one; j++) {
                memo[i][j] = new int[2];
                Array.Fill(memo[i][j], -1);
            }
        }
        this.limit = limit;
        return (DP(zero, one, 0) + DP(zero, one, 1)) % MOD;
    }

    public int DP(int zero, int one, int lastBit) {
        if (zero == 0) {
            return (lastBit == 0 || one > limit) ? 0 : 1;
        } else if (one == 0) {
            return (lastBit == 1 || zero > limit) ? 0 : 1;
        }

        if (memo[zero][one][lastBit] == -1) {
            int res = 0;
            if (lastBit == 0) {
                res = (DP(zero - 1, one, 0) + DP(zero - 1, one, 1))% MOD;
                if (zero > limit) {
                    res = (res - DP(zero - limit - 1, one, 1) + MOD) % MOD;
                }
            } else {
                res = (DP(zero, one - 1, 0) + DP(zero, one - 1, 1)) % MOD;
                if (one > limit) {
                    res = (res - DP(zero, one - limit - 1, 0) + MOD) % MOD;
                }
            }
            memo[zero][one][lastBit] = res % MOD;
        }
        return memo[zero][one][lastBit];
    }
}
```

```C
#define MOD 1000000007

int ***createMemo(int zero, int one) {
    int ***memo = malloc((zero + 1) * sizeof(int **));
    for (int i = 0; i <= zero; ++i) {
        memo[i] = malloc((one + 1) * sizeof(int *));
        for (int j = 0; j <= one; ++j) {
            memo[i][j] = malloc(2 * sizeof(int));
            memo[i][j][0] = -1;
            memo[i][j][1] = -1;
        }
    }
    return memo;
}

void freeMemo(int zero, int one, int ***memo) {
    for (int i = 0; i <= zero; ++i) {
        for (int j = 0; j <= one; ++j) {
            free(memo[i][j]);
        }
        free(memo[i]);
    }
    free(memo);
}

int dp(int zero, int one, int lastBit, int limit, int ***memo) {
    if (zero == 0) {
        return (lastBit == 0 || one > limit) ? 0 : 1;
    } else if (one == 0) {
        return (lastBit == 1 || zero > limit) ? 0 : 1;
    }
    if (memo[zero][one][lastBit] == -1) {
        int res = 0;
        if (lastBit == 0) {
            res = (dp(zero - 1, one, 0, limit, memo) + dp(zero - 1, one, 1, limit, memo)) % MOD;
            if (zero > limit) {
                res = (res - dp(zero - limit - 1, one, 1, limit, memo) + MOD) % MOD;
            }
        } else {
            res = (dp(zero, one - 1, 0, limit, memo) + dp(zero, one - 1, 1, limit, memo)) % MOD;
            if (one > limit) {
                res = (res - dp(zero, one - limit - 1, 0, limit, memo) + MOD) % MOD;
            }
        }
        memo[zero][one][lastBit] = res % MOD;
    }
    return memo[zero][one][lastBit];
}

int numberOfStableArrays(int zero, int one, int limit) {
    int ***memo = createMemo(zero, one);
    int result = (dp(zero, one, 0, limit, memo) + dp(zero, one, 1, limit, memo)) % MOD;
    freeMemo(zero, one, memo);
    return result;
}
```

```Go
const MOD = 1000000007

func numberOfStableArrays(zero int, one int, limit int) int {
    memo := make([][][]int, zero + 1)
    for i := range memo {
        memo[i] = make([][]int, one + 1)
        for j := range memo[i] {
            memo[i][j] = []int{-1, -1}
        }
    }

    var dp func(int, int, int) int
    dp = func(zero, one, lastBit int) int {
        if zero == 0 {
            if lastBit == 0 || one > limit {
                return 0
            } else {
                return 1
            }
        } else if one == 0 {
            if lastBit == 1 || zero > limit {
                return 0
            } else {
                return 1
            }
        }

        if memo[zero][one][lastBit] == -1 {
            res := 0
            if lastBit == 0 {
                res = (dp(zero-1, one, 0) + dp(zero - 1, one, 1)) % MOD
                if zero > limit {
                    res = (res - dp(zero - limit - 1, one, 1) + MOD) % MOD
                }
            } else {
                res = (dp(zero, one - 1, 0) + dp(zero, one - 1, 1)) % MOD
                if one > limit {
                    res = (res - dp(zero, one - limit - 1, 0) + MOD) % MOD
                }
            }
            memo[zero][one][lastBit] = res % MOD
        }
        return memo[zero][one][lastBit]
    }

    return (dp(zero, one, 0) + dp(zero, one, 1)) % MOD
}
```

```JavaScript
const MOD = 1000000007;

var numberOfStableArrays = function(zero, one, limit) {
    const memo = Array.from({ length: zero + 1 }, () =>
        Array.from({ length: one + 1 }, () => [-1, -1])
    );

    function dp(zero, one, lastBit) {
        if (zero === 0) {
            return lastBit === 0 || one > limit ? 0 : 1;
        } else if (one === 0) {
            return lastBit === 1 || zero > limit ? 0 : 1;
        }

        if (memo[zero][one][lastBit] === -1) {
            let res = 0;
            if (lastBit === 0) {
                res = (dp(zero - 1, one, 0) + dp(zero - 1, one, 1)) % MOD;
                if (zero > limit) {
                    res = (res - dp(zero - limit - 1, one, 1) + MOD) % MOD;
                }
            } else {
                res = (dp(zero, one - 1, 0) + dp(zero, one - 1, 1)) % MOD;
                if (one > limit) {
                    res = (res - dp(zero, one - limit - 1, 0) + MOD) % MOD;
                }
            }
            memo[zero][one][lastBit] = res % MOD;
        }
        return memo[zero][one][lastBit];
    }

    return (dp(zero, one, 0) + dp(zero, one, 1)) % MOD;
};
```

```TypeScript
const MOD = 1000000007;

function numberOfStableArrays(zero: number, one: number, limit: number): number {
    const memo: number[][][] = Array.from({ length: zero + 1 }, () =>
        Array.from({ length: one + 1 }, () => [-1, -1])
    );

    function dp(zero: number, one: number, lastBit: number): number {
        if (zero === 0) {
            return lastBit === 0 || one > limit ? 0 : 1;
        } else if (one === 0) {
            return lastBit === 1 || zero > limit ? 0 : 1;
        }

        if (memo[zero][one][lastBit] === -1) {
            let res = 0;
            if (lastBit === 0) {
                res = (dp(zero - 1, one, 0) + dp(zero - 1, one, 1)) % MOD;
                if (zero > limit) {
                    res = (res - dp(zero - limit - 1, one, 1) + MOD) % MOD;
                }
            } else {
                res = (dp(zero, one - 1, 0) + dp(zero, one - 1, 1)) % MOD;
                if (one > limit) {
                    res = (res - dp(zero, one - limit - 1, 0) + MOD) % MOD;
                }
            }
            memo[zero][one][lastBit] = res % MOD;
        }
        return memo[zero][one][lastBit];
    }

    return (dp(zero, one, 0) + dp(zero, one, 1)) % MOD;
};
```

```Rust
const MOD: i32 = 1000000007;

impl Solution {
    pub fn number_of_stable_arrays(zero: i32, one: i32, limit: i32) -> i32 {
        let mut memo = vec![vec![vec![-1; 2]; (one + 1) as usize]; (zero + 1) as usize];

        fn dp(zero: usize, one: usize, last_bit: usize, limit: usize, memo: &mut Vec<Vec<Vec<i32>>>) -> i32 {
            if zero == 0 {
                return if last_bit == 0 || one > limit { 0 } else { 1 };
            } else if one == 0 {
                return if last_bit == 1 || zero > limit { 0 } else { 1 };
            }

            if memo[zero][one][last_bit] == -1 {
                let mut res = 0;
                if last_bit == 0 {
                    res = (dp(zero - 1, one, 0, limit, memo) + dp(zero - 1, one, 1, limit, memo)) % MOD;
                    if zero > limit {
                        res = (res - dp(zero - limit - 1, one, 1, limit, memo) + MOD) % MOD;
                    }
                } else {
                    res = (dp(zero, one - 1, 0, limit, memo) + dp(zero, one - 1, 1, limit, memo)) % MOD;
                    if one > limit {
                        res = (res - dp(zero, one - limit - 1, 0, limit, memo) + MOD) % MOD;
                    }
                }
                memo[zero][one][last_bit] = res % MOD;
            }
            memo[zero][one][last_bit]
        }

        let zero = zero as usize;
        let one = one as usize;
        let limit = limit as usize;
        (dp(zero, one, 0, limit, &mut memo) + dp(zero, one, 1, limit, &mut memo)) % MOD
    }
}
```

**复杂度分析**

- 时间复杂度：$O(zero \times one)$，动态规划的状态一共有 $O(zero \times one)$ 种，每个状态消耗 $O(1)$ 时间消耗。
- 空间复杂度：$O(zero \times one)$。

#### 方法二：动态规划

**思路**

方法一用的是记忆化搜索，状态的求解是自顶向下的。方法二中我们使用动态规划，从而自底向上来求出所有状态，并用数组保存结果。状态方程的关系和方法一一致。

**代码**

```Python
class Solution:
    def numberOfStableArrays(self, zero: int, one: int, limit: int) -> int:
        mod = 10 ** 9 + 7

        dp = [[[0, 0] for _ in range(one + 1)] for _ in range(zero + 1)]
        for i in range(zero+1):
            for j in range(one+1):
                for lastBit in range(2):
                    if i == 0:
                        if lastBit == 0 or j > limit:
                            dp[i][j][lastBit] = 0
                        else:
                            dp[i][j][lastBit] = 1
                    elif j == 0:
                        if lastBit == 1 or i > limit:
                            dp[i][j][lastBit] = 0
                        else:
                            dp[i][j][lastBit] = 1
                    elif lastBit == 0:
                        dp[i][j][lastBit] = dp[i-1][j][0] + dp[i-1][j][1]
                        if i > limit:
                            dp[i][j][lastBit] -= dp[i-limit-1][j][1]
                    else:
                        dp[i][j][lastBit] = dp[i][j-1][0] + dp[i][j-1][1]
                        if j > limit:
                            dp[i][j][lastBit] -= dp[i][j-limit-1][0]
                    dp[i][j][lastBit] %= mod
        return (dp[-1][-1][0] + dp[-1][-1][1]) % mod
```

```C++
class Solution {
public:
    constexpr static int MOD = 1000000007;
    int numberOfStableArrays(int zero, int one, int limit) {
        vector<vector<vector<int>>> dp(zero + 1, vector<vector<int>>(one + 1, vector<int>(2)));
        for (int i = 0; i <= zero; i++) {
            for (int j = 0; j <= one; j++) {
                for (int lastBit = 0; lastBit <= 1; lastBit++) {
                    if (i == 0) {
                        if (lastBit == 0 || j > limit) {
                            dp[i][j][lastBit] = 0;
                        } else {
                            dp[i][j][lastBit] = 1;
                        }
                    } else if (j == 0) {
                        if (lastBit == 1 || i > limit) {
                            dp[i][j][lastBit] = 0;
                        } else {
                            dp[i][j][lastBit] = 1;
                        }
                    } else if (lastBit == 0) {
                        dp[i][j][lastBit] = dp[i - 1][j][0] + dp[i - 1][j][1];
                        if (i > limit) {
                            dp[i][j][lastBit] -= dp[i - limit - 1][j][1];
                        }
                    } else {
                        dp[i][j][lastBit] = dp[i][j - 1][0] + dp[i][j -1 ][1];
                        if (j > limit) {
                            dp[i][j][lastBit] -= dp[i][j - limit - 1][0];
                        }
                    }
                    dp[i][j][lastBit] %= MOD;
                    if (dp[i][j][lastBit] < 0) {
                        dp[i][j][lastBit] += MOD;
                    }
                }
            }
        }

        return (dp[zero][one][0] + dp[zero][one][1]) % MOD;
    }
};
```

```Java
class Solution {
    public int numberOfStableArrays(int zero, int one, int limit) {
        final int MOD = 1000000007;
        int[][][] dp = new int[zero + 1][one + 1][2];
        for (int i = 0; i <= zero; i++) {
            for (int j = 0; j <= one; j++) {
                for (int lastBit = 0; lastBit <= 1; lastBit++) {
                    if (i == 0) {
                        if (lastBit == 0 || j > limit) {
                            dp[i][j][lastBit] = 0;
                        } else {
                            dp[i][j][lastBit] = 1;
                        }
                    } else if (j == 0) {
                        if (lastBit == 1 || i > limit) {
                            dp[i][j][lastBit] = 0;
                        } else {
                            dp[i][j][lastBit] = 1;
                        }
                    } else if (lastBit == 0) {
                        dp[i][j][lastBit] = dp[i - 1][j][0] + dp[i - 1][j][1];
                        if (i > limit) {
                            dp[i][j][lastBit] -= dp[i - limit - 1][j][1];
                        }
                    } else {
                        dp[i][j][lastBit] = dp[i][j - 1][0] + dp[i][j -1 ][1];
                        if (j > limit) {
                            dp[i][j][lastBit] -= dp[i][j - limit - 1][0];
                        }
                    }
                    dp[i][j][lastBit] %= MOD;
                    if (dp[i][j][lastBit] < 0) {
                        dp[i][j][lastBit] += MOD;
                    }
                }
            }
        }
        return (dp[zero][one][0] + dp[zero][one][1]) % MOD;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfStableArrays(int zero, int one, int limit) {
        const int MOD = 1000000007;
        int[][][] dp = new int[zero + 1][][];
        for (int i = 0; i <= zero; i++) {
            dp[i] = new int[one + 1][];
            for (int j = 0; j <= one; j++) {
                dp[i][j] = new int[2];
                for (int lastBit = 0; lastBit <= 1; lastBit++) {
                    if (i == 0) {
                        if (lastBit == 0 || j > limit) {
                            dp[i][j][lastBit] = 0;
                        } else {
                            dp[i][j][lastBit] = 1;
                        }
                    } else if (j == 0) {
                        if (lastBit == 1 || i > limit) {
                            dp[i][j][lastBit] = 0;
                        } else {
                            dp[i][j][lastBit] = 1;
                        }
                    } else if (lastBit == 0) {
                        dp[i][j][lastBit] = dp[i - 1][j][0] + dp[i - 1][j][1];
                        if (i > limit) {
                            dp[i][j][lastBit] -= dp[i - limit - 1][j][1];
                        }
                    } else {
                        dp[i][j][lastBit] = dp[i][j - 1][0] + dp[i][j -1 ][1];
                        if (j > limit) {
                            dp[i][j][lastBit] -= dp[i][j - limit - 1][0];
                        }
                    }
                    dp[i][j][lastBit] %= MOD;
                    if (dp[i][j][lastBit] < 0) {
                        dp[i][j][lastBit] += MOD;
                    }
                }
            }
        }
        return (dp[zero][one][0] + dp[zero][one][1]) % MOD;
    }
}
```

```Go
const MOD = 1000000007

func numberOfStableArrays(zero int, one int, limit int) int {
    dp := make([][][]int, zero + 1)
    for i := range dp {
        dp[i] = make([][]int, one + 1)
        for j := range dp[i] {
            dp[i][j] = make([]int, 2)
        }
    }

    for i := 0; i <= zero; i++ {
        for j := 0; j <= one; j++ {
            for lastBit := 0; lastBit <= 1; lastBit++ {
                if i == 0 {
                    if lastBit == 0 || j > limit {
                        dp[i][j][lastBit] = 0
                    } else {
                        dp[i][j][lastBit] = 1
                    }
                } else if j == 0 {
                    if lastBit == 1 || i > limit {
                        dp[i][j][lastBit] = 0
                    } else {
                        dp[i][j][lastBit] = 1
                    }
                } else if lastBit == 0 {
                    dp[i][j][lastBit] = dp[i - 1][j][0] + dp[i - 1][j][1]
                    if i > limit {
                        dp[i][j][lastBit] -= dp[i - limit - 1][j][1]
                    }
                } else {
                    dp[i][j][lastBit] = dp[i][j - 1][0] + dp[i][j - 1][1]
                    if j > limit {
                        dp[i][j][lastBit] -= dp[i][j - limit - 1][0]
                    }
                }
                dp[i][j][lastBit] %= MOD
                if dp[i][j][lastBit] < 0 {
                    dp[i][j][lastBit] += MOD
                }
            }
        }
    }

    return (dp[zero][one][0] + dp[zero][one][1]) % MOD
}
```

```C
#define MOD 1000000007

int numberOfStableArrays(int zero, int one, int limit) {
    int dp[zero + 1][one + 1][2];
    memset(dp, 0, sizeof(dp));
    for (int i = 0; i <= zero; i++) {
        for (int j = 0; j <= one; j++) {
            for (int lastBit = 0; lastBit <= 1; lastBit++) {
                if (i == 0) {
                    if (lastBit == 0 || j > limit) {
                        dp[i][j][lastBit] = 0;
                    } else {
                        dp[i][j][lastBit] = 1;
                    }
                } else if (j == 0) {
                    if (lastBit == 1 || i > limit) {
                        dp[i][j][lastBit] = 0;
                    } else {
                        dp[i][j][lastBit] = 1;
                    }
                } else if (lastBit == 0) {
                    dp[i][j][lastBit] = dp[i - 1][j][0] + dp[i - 1][j][1];
                    if (i > limit) {
                        dp[i][j][lastBit] -= dp[i - limit - 1][j][1];
                    }
                } else {
                    dp[i][j][lastBit] = dp[i][j - 1][0] + dp[i][j - 1][1];
                    if (j > limit) {
                        dp[i][j][lastBit] -= dp[i][j - limit - 1][0];
                    }
                }
                dp[i][j][lastBit] %= MOD;
                if (dp[i][j][lastBit] < 0) {
                    dp[i][j][lastBit] += MOD;
                }
            }
        }
    }

    return (dp[zero][one][0] + dp[zero][one][1]) % MOD;
}
```

```JavaScript
const MOD = 1000000007;

var numberOfStableArrays = function(zero, one, limit) {
    let dp = Array.from({ length: zero + 1 }, () =>
        Array.from({ length: one + 1 }, () => [0, 0])
    );

    for (let i = 0; i <= zero; i++) {
        for (let j = 0; j <= one; j++) {
            for (let lastBit = 0; lastBit <= 1; lastBit++) {
                if (i === 0) {
                    if (lastBit === 0 || j > limit) {
                        dp[i][j][lastBit] = 0;
                    } else {
                        dp[i][j][lastBit] = 1;
                    }
                } else if (j === 0) {
                    if (lastBit === 1 || i > limit) {
                        dp[i][j][lastBit] = 0;
                    } else {
                        dp[i][j][lastBit] = 1;
                    }
                } else if (lastBit === 0) {
                    dp[i][j][lastBit] = dp[i - 1][j][0] + dp[i - 1][j][1];
                    if (i > limit) {
                        dp[i][j][lastBit] -= dp[i - limit - 1][j][1];
                    }
                } else {
                    dp[i][j][lastBit] = dp[i][j - 1][0] + dp[i][j - 1][1];
                    if (j > limit) {
                        dp[i][j][lastBit] -= dp[i][j - limit - 1][0];
                    }
                }
                dp[i][j][lastBit] %= MOD;
                if (dp[i][j][lastBit] < 0) {
                    dp[i][j][lastBit] += MOD;
                }
            }
        }
    }

    return (dp[zero][one][0] + dp[zero][one][1]) % MOD;
};
```

```TypeScript
const MOD = 1000000007;

function numberOfStableArrays(zero: number, one: number, limit: number): number {
    let dp: number[][][] = Array.from({ length: zero + 1 }, () =>
        Array.from({ length: one + 1 }, () => [0, 0])
    );

    for (let i = 0; i <= zero; i++) {
        for (let j = 0; j <= one; j++) {
            for (let lastBit = 0; lastBit <= 1; lastBit++) {
                if (i === 0) {
                    if (lastBit === 0 || j > limit) {
                        dp[i][j][lastBit] = 0;
                    } else {
                        dp[i][j][lastBit] = 1;
                    }
                } else if (j === 0) {
                    if (lastBit === 1 || i > limit) {
                        dp[i][j][lastBit] = 0;
                    } else {
                        dp[i][j][lastBit] = 1;
                    }
                } else if (lastBit === 0) {
                    dp[i][j][lastBit] = dp[i - 1][j][0] + dp[i - 1][j][1];
                    if (i > limit) {
                        dp[i][j][lastBit] -= dp[i - limit - 1][j][1];
                    }
                } else {
                    dp[i][j][lastBit] = dp[i][j - 1][0] + dp[i][j - 1][1];
                    if (j > limit) {
                        dp[i][j][lastBit] -= dp[i][j - limit - 1][0];
                    }
                }
                dp[i][j][lastBit] %= MOD;
                if (dp[i][j][lastBit] < 0) {
                    dp[i][j][lastBit] += MOD;
                }
            }
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

        for i in 0..=zero as usize {
            for j in 0..=one as usize {
                for last_bit in 0..=1 {
                    if i == 0 {
                        if last_bit == 0 || j > limit as usize {
                            dp[i][j][last_bit] = 0;
                        } else {
                            dp[i][j][last_bit] = 1;
                        }
                    } else if j == 0 {
                        if last_bit == 1 || i > limit as usize {
                            dp[i][j][last_bit] = 0;
                        } else {
                            dp[i][j][last_bit] = 1;
                        }
                    } else if last_bit == 0 {
                        dp[i][j][last_bit] = dp[i - 1][j][0] + dp[i - 1][j][1];
                        if i > limit as usize {
                            dp[i][j][last_bit] -= dp[i - (limit as usize) - 1][j][1];
                        }
                    } else {
                        dp[i][j][last_bit] = dp[i][j - 1][0] + dp[i][j - 1][1];
                        if j > limit as usize {
                            dp[i][j][last_bit] -= dp[i][j - (limit as usize) - 1][0];
                        }
                    }
                    dp[i][j][last_bit] %= MOD;
                    if dp[i][j][last_bit] < 0 {
                        dp[i][j][last_bit] += MOD;
                    }
                }
            }
        }

        return (dp[zero as usize][one as usize][0] + dp[zero as usize][one as usize][1]) % MOD;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(zero \times one)$，动态规划的状态一共有 $O(zero \times one)$ 种，每个状态消耗 $O(1)$ 时间消耗。
- 空间复杂度：$O(zero \times one)$。
