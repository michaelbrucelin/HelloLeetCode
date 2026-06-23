### [锯齿形数组的总数 I](https://leetcode.cn/problems/number-of-zigzag-arrays-i/solutions/3984255/ju-chi-xing-shu-zu-de-zong-shu-i-by-leet-nioi/)

#### 方法一：动态规划 $+$ 前缀和优化

**思路与算法**

此类序列计数问题一般考虑使用动态规划求解。

记锯齿数组为 $z$，设状态 $dp[i][dir][j]$ 代表 $z$ 的长度为 $i+1$，其末尾的两个元素的排列方式为 $dir$，且 $z[i]=j$ 时的方案总数，其中 $l\le j\le r$。

记 $z$ 末尾的两个元素分别为 $z[i-1]$ 和 $z[i]$，则 $dir$ 的定义如下：

- 当 $z[i-1]>z[i]$，即这两个元素构成一个严格递减排列时，取 $dir=0$；
- 当 $z[i-1]<z[i]$，即这两个元素构成一个严格递增排列时，取 $dir=1$。

考虑状态转移。首先，由于锯齿数组只关心**相邻**两个元素构成的排列情况，因此状态转移显然与且仅与前一个状态相关。也就是对于 $dp[i]$，它的取值仅取决于 $dp[i-1]$ 的值。

同时，根据题目对锯齿数组的定义，相邻的两组元素的排列形式必须是交错的，$dir=0$ 的状态只能从 $dir=1$ 的状态转移过来，反之亦然。

最后，对于 $dp[i][0][j]$，因为相邻元素要形成严格递减序列，故前一个状态的末尾元素 $j^′$ 应该严格大于当前状态的末尾元素 $j$；同理，对于 $dp[i][1][j]$，前一个状态的末尾元素 $j^′$ 应该严格小于当前状态的末尾元素 $j$。将所有可以转移到当前状态的方案数求和，即可得到当前状态的方案数。

最终可以得到如下状态转移方程，下面的式子将给定区间 $[l,r]$ 平移到了 $[0,m-1]$，其中 $m=r-l+1$。注意某些语言在实现时可能直接使用 $[l,r]$ 求解，但原理是一样的：

$$\begin{array}{l}dp[i][0][j]=\sum\limits_{k=j+1}^{m-1}dp[i-1][1][k] \\ dp[i][1][j]=\sum\limits_{k=0}^{j-1}dp[i-1][0][k]\end{array}$$

容易发现，上述两个求和式可以使用前缀和优化，设 $sum[i][dir]$ 代表锯齿数组长度为 i、且末尾元素排列方式为 $dir$ 时，方案数的前缀和数组。为了方便处理边界，我们使用长度为 $m+1$ 的前缀和数组，其中：

$$sum[i][dir][j]=\sum\limits_{k=0}^{j-1}dp[i][dir][k]$$

特别地，

$$sum[i][dir][0]=0$$

引入前缀和后，我们可以在 $O(1)$ 的时间复杂度内完成状态转移，优化后的转移方程如下：

$$\begin{array}{l}dp[i][0][j]=sum[i-1][1][m]-sum[i-1][1][j+1]\\ dp[i][1][j]=sum[i-1][0][j]\end{array}$$

最后初始化的时候，将 $dp[0]$ 的所有元素置为 $1$ 即可，因为长度为 $1$ 时的排列方案只有唯一一种。

实现的时候，我们可以先将 $dp$ 的第二维拆成两个独立变量 $dp0$ 和 $dp1$ 进行独立寻址。同时由于引入了前缀和，因此自然地想到将数组 $sum$ 的第二维也拆成两个独立变量，此时 $sum$ 与 $dp$ 两个状态数组的转移相继轮换进行，且只依赖上一轮对方的值，已经达成类似滚动数组的效果，从而可以直接去掉第一维，直接将空间优化到 $O(m)$。

注：观察到两个方向的状态转移计算具有高度对称性，实际上确实可以通过对称性优化计算过程，这部分交给读者自行思考实现。

**代码**

```C++
constexpr int MOD = 1'000'000'007;

class Solution {
public:
    int zigZagArrays(int n, int l, int r) {
        int m = r - l + 1;
        vector<int> dp0(m, 0);
        vector<int> dp1(m, 0);
        vector<int> sum0(m + 1, 0);
        vector<int> sum1(m + 1, 0);

        for (int i = 0; i < m; i++) {
            dp0[i] = dp1[i] = 1;
        }

        for (int i = 1; i < n; i++) {
            for (int j = 0; j < m; j++) {
                sum0[j + 1] = (sum0[j] + dp0[j]) % MOD;
                sum1[j + 1] = (sum1[j] + dp1[j]) % MOD;
            }

            for (int j = 0; j < m; j++) {
                dp0[j] = (sum1[m] - sum1[j + 1] + MOD) % MOD;
                dp1[j] = sum0[j];
            }
        }

        auto op = [](int acc, int x) { return (acc + x) % MOD; };
        auto ans0 = std::reduce(dp0.begin(), dp0.end(), 0, op);
        auto ans1 = std::reduce(dp1.begin(), dp1.end(), 0, op);

        return (ans0 + ans1) % MOD;
    }
};
```

```Python
class Solution:
    def zigZagArrays(self, n: int, l: int, r: int) -> int:
        MOD = 10**9 + 7
        m = r - l + 1

        dp0 = [1] * m
        dp1 = [1] * m
        for _ in range(n - 1):
            sum0 = list(accumulate(dp0, initial=0))
            sum1 = list(accumulate(dp1, initial=0))

            dp0 = [x % MOD for x in sum1[:-1]]

            s0_m = sum0[-1]
            dp1 = [(s0_m - x) % MOD for x in sum0[1:]]

        return (sum(dp0) + sum(dp1)) % MOD
```

```Java
public class Solution {
    private static final int MOD = 1_000_000_007;

    public int zigZagArrays(int n, int l, int r) {
        int[] dp0 = new int[r + 1];
        int[] dp1 = new int[r + 1];
        int[] sum0 = new int[r + 2];
        int[] sum1 = new int[r + 2];

        for (int i = l; i <= r; i++) {
            dp0[i] = 1;
            dp1[i] = 1;
            sum0[i] = i - l + 1;
            sum1[i] = i - l + 1;
        }

        for (int i = 1; i < n; i++) {
            for (int j = l; j <= r; j++) {
                dp0[j] = (sum1[r] - sum1[j] + MOD) % MOD;
                dp1[j] = sum0[j - 1];
            }

            sum0[l] = dp0[l];
            sum1[l] = dp1[l];
            for (int j = l + 1; j <= r; j++) {
                sum0[j] = (sum0[j - 1] + dp0[j]) % MOD;
                sum1[j] = (sum1[j - 1] + dp1[j]) % MOD;
            }
        }

        return (sum0[r] + sum1[r]) % MOD;
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1_000_000_007;

    public int ZigZagArrays(int n, int l, int r) {
        int[] dp0 = new int[r + 1];
        int[] dp1 = new int[r + 1];
        int[] sum0 = new int[r + 2];
        int[] sum1 = new int[r + 2];

        for (int i = l; i <= r; i++)
        {
            dp0[i] = dp1[i] = 1;
            sum0[i] = sum1[i] = i - l + 1;
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = l; j <= r; j++)
            {
                dp0[j] = (sum1[r] - sum1[j] + MOD) % MOD;
                dp1[j] = sum0[j - 1];
            }

            sum0[l] = dp0[l];
            sum1[l] = dp1[l];
            for (int j = l + 1; j <= r; j++)
            {
                sum0[j] = (sum0[j - 1] + dp0[j]) % MOD;
                sum1[j] = (sum1[j - 1] + dp1[j]) % MOD;
            }
        }

        return (sum0[r] + sum1[r]) % MOD;
    }
}
```

```C
#define MOD 1000000007

int zigZagArrays(int n, int l, int r) {
    int* dp0 = (int*)calloc(r + 1, sizeof(int));
    int* dp1 = (int*)calloc(r + 1, sizeof(int));
    int* sum0 = (int*)calloc(r + 2, sizeof(int));
    int* sum1 = (int*)calloc(r + 2, sizeof(int));

    for (int i = l; i <= r; i++) {
        dp0[i] = 1;
        dp1[i] = 1;
        sum0[i] = sum1[i] = i - l + 1;
    }

    for (int i = 1; i < n; i++) {
        for (int j = l; j <= r; j++) {
            dp0[j] = (sum1[r] - sum1[j] + MOD) % MOD;
            dp1[j] = sum0[j - 1];
        }

        sum0[l] = dp0[l];
        sum1[l] = dp1[l];
        for (int j = l + 1; j <= r; j++) {
            sum0[j] = (sum0[j - 1] + dp0[j]) % MOD;
            sum1[j] = (sum1[j - 1] + dp1[j]) % MOD;
        }
    }

    int ans = (sum0[r] + sum1[r]) % MOD;

    free(dp0);
    free(dp1);
    free(sum0);
    free(sum1);

    return ans;
}
```

```JavaScript
const MOD = 10 ** 9 + 7;

var zigZagArrays = function (n, l, r) {
    const dp0 = new Array(r + 1).fill(0);
    const dp1 = new Array(r + 1).fill(0);
    const sum0 = new Array(r + 2).fill(0);
    const sum1 = new Array(r + 2).fill(0);

    for (let i = l; i <= r; i++) {
        dp0[i] = dp1[i] = 1;
        sum0[i] = sum1[i] = i - l + 1;
    }

    for (let i = 1; i < n; i++) {
        for (let j = l; j <= r; j++) {
            dp0[j] = (sum1[r] - sum1[j] + MOD) % MOD;
            dp1[j] = sum0[j - 1];
        }

        sum0[l] = dp0[l];
        sum1[l] = dp1[l];
        for (let j = l + 1; j <= r; j++) {
            sum0[j] = (sum0[j - 1] + dp0[j]) % MOD;
            sum1[j] = (sum1[j - 1] + dp1[j]) % MOD;
        }
    }

    return (sum0[r] + sum1[r]) % MOD;
};
```

```TypeScript
const MOD = 10 ** 9 + 7;

function zigZagArrays(n: number, l: number, r: number): number {
    const dp0 = new Array<number>(r + 1).fill(0);
    const dp1 = new Array<number>(r + 1).fill(0);
    const sum0 = new Array<number>(r + 2).fill(0);
    const sum1 = new Array<number>(r + 2).fill(0);

    for (let i = l; i <= r; i++) {
        dp0[i] = dp1[i] = 1;
        sum0[i] = sum1[i] = i - l + 1;
    }

    for (let i = 1; i < n; i++) {
        for (let j = l; j <= r; j++) {
            dp0[j] = (sum1[r] - sum1[j] + MOD) % MOD;
            dp1[j] = sum0[j - 1];
        }

        sum0[l] = dp0[l];
        sum1[l] = dp1[l];
        for (let j = l + 1; j <= r; j++) {
            sum0[j] = (sum0[j - 1] + dp0[j]) % MOD;
            sum1[j] = (sum1[j - 1] + dp1[j]) % MOD;
        }
    }

    return (sum0[r] + sum1[r]) % MOD;
}
```

```Go
func zigZagArrays(n int, l int, r int) int {
    const MOD = 1_000_000_007

    dp0 := make([]int, r+1)
    dp1 := make([]int, r+1)
    sum0 := make([]int, r+2)
    sum1 := make([]int, r+2)

    for i := l; i <= r; i++ {
        dp0[i] = 1
        dp1[i] = 1
        val := i - l + 1
        sum0[i] = val
        sum1[i] = val
    }

    for i := 1; i < n; i++ {
        for j := l; j <= r; j++ {
            dp0[j] = (sum1[r] - sum1[j] + MOD) % MOD
            dp1[j] = sum0[j-1]
        }

        sum0[l] = dp0[l]
        sum1[l] = dp1[l]
        for j := l + 1; j <= r; j++ {
            sum0[j] = (sum0[j-1] + dp0[j]) % MOD
            sum1[j] = (sum1[j-1] + dp1[j]) % MOD
        }
    }

    return (sum0[r] + sum1[r]) % MOD
}
```

```Rust
impl Solution {
    const MOD: i32 = 1_000_000_007;

    pub fn zig_zag_arrays(n: i32, l: i32, r: i32) -> i32 {
        let m = (r - l + 1) as usize;

        let mut dp0 = vec![1; m];
        let mut dp1 = vec![1; m];
        let mut sum0 = vec![0; m + 1];
        let mut sum1 = vec![0; m + 1];

        for _ in 1..n {
            for j in 0..m {
                sum0[j + 1] = (sum0[j] + dp0[j]) % Self::MOD;
                sum1[j + 1] = (sum1[j] + dp1[j]) % Self::MOD;
            }

            for j in 0..m {
                dp0[j] = sum1[j];
                dp1[j] = (sum0[m] - sum0[j + 1] + Self::MOD) % Self::MOD;
            }
        }

        let ans0 = dp0.iter().fold(0, |acc, &x| (acc + x) % Self::MOD);
        let ans1 = dp1.iter().fold(0, |acc, &x| (acc + x) % Self::MOD);

        (ans0 + ans1) % Self::MOD
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中 $m$ 为给定区间的长度，即 $r-l+1$。外循环遍历数组下标需要 $O(n)$，内循环进行动态规划求解与前缀和计算需要 $O(m)$。
- 空间复杂度：$O(m)$。用到的辅助数组长度均为 $m$。
