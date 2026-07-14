### [最大公约数相等的子序列数量](https://leetcode.cn/problems/find-the-number-of-subsequences-with-equal-gcd/solutions/3990307/zui-da-gong-yue-shu-xiang-deng-de-zi-xu-1ph68/)

#### 方法一：动态规划

**思路与算法**

用 $n$ 表示数组 $nums$ 的长度，$m$ 表示数组 $nums$ 中元素的最大值。对于任意两个正整数 $a,b$ 的最大公约数 $gcd(a,b)$，一定满足 $gcd(a,b)\le min(a,b)$，其中 $min(a,b)$ 表示 $a,b$ 中的最小值。因此，在任意时刻，两个子序列的 $GCD$ 都不会超过数组中的最大值 $m$。

设 $dp[i][j][k]$ 表示考虑数组中前 $i$ 个元素时，第一个子序列 $seq_1$ 当前的 $GCD$ 为 $j$，第二个子序列 $seq_2$ 当前的 $GCD$ 为 $k$ 的方案数。

初始时，未考虑任何元素，两个子序列均为空，其 $GCD$ 视为 $0$，因此 $dp[0][0][0]=1$。

当考虑第 $i$ 个元素 $nums[i]$ 时（下标从 $1$ 开始），对于当前状态 $dp[i-1][j][k]$，我们有三种互斥且完备的选择：

- **将 $nums[i]$ 加入第一个子序列 seq_1**：
  此时 $seq_1$ 的最大公约数变为 $gcd(j,nums[i])$，$seq_2$ 的 $GCD$ 保持 $k$ 不变。该选择为状态 $dp[i][gcd(j,nums[i])][k]$ 贡献 $dp[i-1][j][k]$ 种方案。
- **将 $nums[i]$ 加入第二个子序列 seq_2**：
  此时 $seq_2$ 的最大公约数变为 $gcd(k,nums[i])$，$seq_1$ 的 $GCD$ 保持 $j$ 不变。该选择为状态 $dp[i][j][gcd(k,nums[i])]$ 贡献 $dp[i-1][j][k]$ 种方案。
- **nums[i] 既不加入 $seq_1$，也不加入 seq_2**：
  两个子序列的 $GCD$ 均保持不变。该选择为状态 $dp[i][j][k]$ 贡献 $dp[i-1][j][k]$ 种方案。

这三种选择互斥且覆盖了当前元素的所有可能去向，且同一元素不能同时放入两个子序列。由此，我们可以得到递推公式：

$$\begin{array}{rcl}
    dp[i][j][k] & = & dp[i-1][j][k] \\
    & & +\sum\limits_{j^′} dp[i-1][j^′][k]（其中满足 j=gcd(j^′,nums[i])） \\
    & & +\sum\limits_{k^′} dp[i-1][j][k^′]（其中满足 k=gcd(k^′,nums[i])）
\end{array}$$

或者等价地，在遍历时从 $dp[i-1][j][k]$ 向三个目标状态进行累加：

$$\begin{cases}
    dp[i][j][k] & = dp[i][j][k]+dp[i-1][j][k] \\
    dp[i][gcd(j,nums[i])][k] & = dp[i][gcd(j,nums[i])][k]+dp[i-1][j][k] \\
    dp[i][j][gcd(k,nums[i])] & = dp[i][j][gcd(k,nums[i])]+dp[i-1][j][k]
\end{cases}$$

题目要求对 $10^9+7$ 取模，因此在累加过程中需同时进行取模运算。

当处理完所有 $n$ 个元素后，题目要求返回 $seq_1$ 的 $GCD$ 等于 $seq_2$ 的 $GCD$ 且大于 $0$ 的方案数（空子序列的 $GCD$ 视为 $0$，不计入答案）。因此最终答案为：

$$ans=\sum\limits_{i=1}^{m}dp[n][i][i]$$

对上述结果取模后返回即可。

**空间优化**

观察状态转移方程，$dp[i][\cdot ][\cdot ]$ 仅依赖于 $dp[i-1][\cdot ][\cdot ]$，因此我们可以使用滚动数组将第一维优化掉。用 $dp[j][k]$ 表示当前已处理元素下的状态，对于每个新元素 $num$，新建一个临时数组 $ndp[j][k]$ 记录加入该元素后的新状态，计算完毕后将 $dp$ 替换为 $ndp$ 即可。这样空间复杂度从 $O(n\cdot m^2)$ 降至 $O(m^2)$。

**代码**

```C++
class Solution {
    static constexpr int MOD = 1e9 + 7;

public:
    int subsequencePairCount(vector<int>& nums) {
        int m = *max_element(nums.begin(), nums.end());
        int n = nums.size();

        vector<vector<int>> dp(m + 1, vector<int>(m + 1));
        dp[0][0] = 1;

        for (int num : nums) {
            vector<vector<int>> ndp(m + 1, vector<int>(m + 1));
            for (int j = 0; j <= m; j++) {
                int divisor1 = gcd(j, num);
                for (int k = 0; k <= m; k++) {
                    int val = dp[j][k];
                    if (val == 0) {
                        continue;
                    }
                    int divisor2 = gcd(k, num);
                    ndp[j][k] = (ndp[j][k] + val) % MOD;
                    ndp[divisor1][k] = (ndp[divisor1][k] + val) % MOD;
                    ndp[j][divisor2] = (ndp[j][divisor2] + val) % MOD;
                }
            }
            dp.swap(ndp);
        }

        int ans = 0;
        for (int j = 1; j <= m; j++) {
            ans = (ans + dp[j][j]) % MOD;
        }

        return ans;
    }
};
```

```Java
class Solution {
    static final int MOD = 1000000007;

    public int subsequencePairCount(int[] nums) {
        int m = 0;
        for (int num : nums) {
            m = Math.max(m, num);
        }

        int[][] dp = new int[m + 1][m + 1];
        dp[0][0] = 1;

        for (int num : nums) {
            int[][] ndp = new int[m + 1][m + 1];
            for (int j = 0; j <= m; j++) {
                int divisor1 = gcd(j, num);
                for (int k = 0; k <= m; k++) {
                    int val = dp[j][k];
                    if (val == 0) {
                        continue;
                    }
                    int divisor2 = gcd(k, num);
                    ndp[j][k] = (ndp[j][k] + val) % MOD;
                    ndp[divisor1][k] = (ndp[divisor1][k] + val) % MOD;
                    ndp[j][divisor2] = (ndp[j][divisor2] + val) % MOD;
                }
            }
            dp = ndp;
        }

        int ans = 0;
        for (int j = 1; j <= m; j++) {
            ans = (ans + dp[j][j]) % MOD;
        }
        return ans;
    }

    private int gcd(int a, int b) {
        while (b != 0) {
            int temp = a;
            a = b;
            b = temp % b;
        }
        return a;
    }
}
```

```CSharp
public class Solution {
    const int MOD = 1000000007;

    public int SubsequencePairCount(int[] nums) {
        int m = 0;
        foreach (int num in nums) {
            m = Math.Max(m, num);
        }

        int[,] dp = new int[m + 1, m + 1];
        dp[0, 0] = 1;

        foreach (int num in nums) {
            int[,] ndp = new int[m + 1, m + 1];
            for (int j = 0; j <= m; j++) {
                int divisor1 = Gcd(j, num);
                for (int k = 0; k <= m; k++) {
                    int val = dp[j, k];
                    if (val == 0) {
                        continue;
                    }
                    int divisor2 = Gcd(k, num);
                    ndp[j, k] = (ndp[j, k] + val) % MOD;
                    ndp[divisor1, k] = (ndp[divisor1, k] + val) % MOD;
                    ndp[j, divisor2] = (ndp[j, divisor2] + val) % MOD;
                }
            }
            dp = ndp;
        }

        int ans = 0;
        for (int j = 1; j <= m; j++) {
            ans = (ans + dp[j, j]) % MOD;
        }
        return ans;
    }

    private int Gcd(int a, int b) {
        while (b != 0) {
            int temp = a;
            a = b;
            b = temp % b;
        }
        return a;
    }
}
```

```Go
const MOD = 1000000007

func subsequencePairCount(nums []int) int {
    m := 0
    for _, num := range nums {
        m = max(m, num)
    }

    dp := make([][]int, m+1)
    for i := range dp {
        dp[i] = make([]int, m+1)
    }
    dp[0][0] = 1

    for _, num := range nums {
        ndp := make([][]int, m+1)
        for i := range ndp {
            ndp[i] = make([]int, m+1)
        }

        for j := 0; j <= m; j++ {
            divisor1 := gcd(j, num)
            for k := 0; k <= m; k++ {
                val := dp[j][k]
                if val == 0 {
                    continue
                }

                divisor2 := gcd(k, num)
                ndp[j][k] = (ndp[j][k] + val) % MOD
                ndp[divisor1][k] = (ndp[divisor1][k] + val) % MOD
                ndp[j][divisor2] = (ndp[j][divisor2] + val) % MOD
            }
        }
        dp = ndp
    }

    ans := 0
    for j := 1; j <= m; j++ {
        ans = (ans + dp[j][j]) % MOD
    }
    return ans
}

func gcd(a, b int) int {
    for b != 0 {
        a, b = b, a%b
    }
    return a
}
```

```Python
class Solution:
    def subsequencePairCount(self, nums: list[int]) -> int:
        MOD = 1000000007
        m = max(nums)
        dp = [[0] * (m + 1) for _ in range(m + 1)]
        dp[0][0] = 1

        for num in nums:
            ndp = [[0] * (m + 1) for _ in range(m + 1)]

            for j in range(m + 1):
                divisor1 = math.gcd(j, num)
                for k in range(m + 1):
                    val = dp[j][k]
                    if val == 0:
                        continue

                    divisor2 = math.gcd(k, num)
                    ndp[j][k] = (ndp[j][k] + val) % MOD
                    ndp[divisor1][k] = (ndp[divisor1][k] + val) % MOD
                    ndp[j][divisor2] = (ndp[j][divisor2] + val) % MOD

            dp = ndp

        ans = 0
        for j in range(1, m + 1):
            ans = (ans + dp[j][j]) % MOD

        return ans
```

```C
#define MOD 1000000007

int gcd(int a, int b) {
    while (b != 0) {
        int temp = a;
        a = b;
        b = temp % b;
    }
    return a;
}

int subsequencePairCount(int* nums, int numsSize) {
    int m = 0;
    for (int i = 0; i < numsSize; i++) {
        m = fmax(m, nums[i]);
    }

    int dp[m + 1][m + 1];
    memset(dp, 0, sizeof(dp));
    dp[0][0] = 1;

    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        int ndp[m + 1][m + 1];
        memset(ndp, 0, sizeof(ndp));

        for (int j = 0; j <= m; j++) {
            int divisor1 = gcd(j, num);
            for (int k = 0; k <= m; k++) {
                int val = dp[j][k];
                if (val == 0) {
                    continue;
                }
                int divisor2 = gcd(k, num);
                ndp[j][k] = (ndp[j][k] + val) % MOD;
                ndp[divisor1][k] = (ndp[divisor1][k] + val) % MOD;
                ndp[j][divisor2] = (ndp[j][divisor2] + val) % MOD;
            }
        }

        memcpy(dp, ndp, sizeof(ndp));
    }

    int ans = 0;
    for (int j = 1; j <= m; j++) {
        ans = (ans + dp[j][j]) % MOD;
    }

    return ans;
}
```

```JavaScript
var subsequencePairCount = function(nums) {
    const MOD = 1000000007;
    const m = Math.max(...nums);

    const gcd = (a, b) => {
        while (b !== 0) {
            [a, b] = [b, a % b];
        }
        return a;
    };

    let dp = Array.from({ length: m + 1 }, () => new Array(m + 1).fill(0));
    dp[0][0] = 1;

    for (const num of nums) {
        const ndp = Array.from({ length: m + 1 }, () => new Array(m + 1).fill(0));

        for (let j = 0; j <= m; j++) {
            const divisor1 = gcd(j, num);
            const dpRow = dp[j];
            const ndpRow = ndp[j];
            const ndpD1Row = ndp[divisor1];

            for (let k = 0; k <= m; k++) {
                const val = dpRow[k];
                if (val === 0) continue;

                const divisor2 = gcd(k, num);
                ndpRow[k] = (ndpRow[k] + val) % MOD;
                ndpD1Row[k] = (ndpD1Row[k] + val) % MOD;
                ndpRow[divisor2] = (ndpRow[divisor2] + val) % MOD;
            }
        }
        dp = ndp;
    }

    let ans = 0;
    for (let j = 1; j <= m; j++) {
        ans = (ans + dp[j][j]) % MOD;
    }

    return ans;
};
```

```TypeScript
function subsequencePairCount(nums: number[]): number {
    const MOD = 1000000007;
    const m = Math.max(...nums);

    const gcd = (a: number, b: number): number => {
        while (b !== 0) {
            [a, b] = [b, a % b];
        }
        return a;
    };

    let dp: number[][] = Array.from({ length: m + 1 }, () => new Array(m + 1).fill(0));
    dp[0][0] = 1;

    for (const num of nums) {
        const ndp: number[][] = Array.from({ length: m + 1 }, () => new Array(m + 1).fill(0));

        for (let j = 0; j <= m; j++) {
            const divisor1 = gcd(j, num);
            const dpRow = dp[j];
            const ndpRow = ndp[j];
            const ndpD1Row = ndp[divisor1];

            for (let k = 0; k <= m; k++) {
                const val = dpRow[k];
                if (val === 0) continue;

                const divisor2 = gcd(k, num);
                ndpRow[k] = (ndpRow[k] + val) % MOD;
                ndpD1Row[k] = (ndpD1Row[k] + val) % MOD;
                ndpRow[divisor2] = (ndpRow[divisor2] + val) % MOD;
            }
        }
        dp = ndp;
    }

    let ans = 0;
    for (let j = 1; j <= m; j++) {
        ans = (ans + dp[j][j]) % MOD;
    }

    return ans;
}
```

```Rust
impl Solution {
    const MOD: i32 = 1_000_000_007;

    pub fn subsequence_pair_count(nums: Vec<i32>) -> i32 {
        let m = *nums.iter().max().unwrap() as usize;

        let mut dp = vec![vec![0; m + 1]; m + 1];
        dp[0][0] = 1;

        for &num in &nums {
            let num = num as usize;
            let mut ndp = vec![vec![0; m + 1]; m + 1];

            for j in 0..=m {
                let divisor1 = Self::gcd(j as i32, num as i32) as usize;
                for k in 0..=m {
                    let val = dp[j][k];
                    if val == 0 {
                        continue;
                    }

                    let divisor2 = Self::gcd(k as i32, num as i32) as usize;
                    ndp[j][k] = (ndp[j][k] + val) % Self::MOD;
                    ndp[divisor1][k] = (ndp[divisor1][k] + val) % Self::MOD;
                    ndp[j][divisor2] = (ndp[j][divisor2] + val) % Self::MOD;
                }
            }
            dp = ndp;
        }

        let mut ans = 0;
        for j in 1..=m {
            ans = (ans + dp[j][j]) % Self::MOD;
        }

        ans
    }

    fn gcd(mut a: i32, mut b: i32) -> i32 {
        while b != 0 {
            let temp = a;
            a = b;
            b = temp % b;
        }
        a
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm^2\log m)$，其中 $n$ 是数组 $nums$ 的长度，$m$ 是数组 $nums$ 中的最大元素。遍历数组 $nums$ 得到最大元素的时间是 $O(n)$，动态规划的状态数是 $O(nm^2)$，每个状态需要计算 $GCD$，需要的时间是 $O(\log m)$，因此时间复杂度是 $O(nm^2\log m)$。
- 空间复杂度：$O(m^2)$，其中 $m$ 是数组 $nums$ 中的最大元素。使用滚动数组优化后仅需维护两个大小为 $O(m^2)$ 的二维数组。
