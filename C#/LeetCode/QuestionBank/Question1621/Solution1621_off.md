### [大小为 K 的不重叠线段的数目](https://leetcode.cn/problems/number-of-sets-of-k-non-overlapping-line-segments/solutions/4022625/da-xiao-wei-k-de-bu-zhong-die-xian-duan-dcg7c/)

#### 方法一：动态规划

**思路与算法**

题目要求我们从 $n$ 个点中选择恰好 $k$ 条不重叠的线段。

令 $dp[i][j]$ 表示在 $[0,j]$ 的点上构造 $i$ 条线段的合法方案数。

首先考虑边界条件。当 $i=0$ 时，只有不选择这一种方案，因此对于 $\forall j\in [0,n)$，都有 $dp[0][j]=1$。而当 $i>0,j=0$ 时，没有合法的方案，因此 $dp[i][0]=0$。

当 $i>0,j>0$ 时，有两种情况：

1. 最后一个线段的右端点不是 $j$。此时等价于在 $j-1$ 个点中选择 $i$ 个线段，即 $dp[i][j-1]$。
2. 最后一个线段的右端点是 $j$。此时对于 $\forall p\in [0,j)$，都有最后一个线段在 $[p,j]$，而前 $i-1$ 个线段在 $[0,p]$ 中的构造方案，方案数为 $\sum\limits_{p=0}^{j-1}dp[i-1][p]$。

因此动态规划的状态转移方程为 $dp[i][j]=dp[i][j-1]+\sum\limits_{p=0}^{j-1}dp[i-1][p]$。

实现时，由于构造 $i$ 条线段的方案数只与构造 $i-1$ 条线段的方案数有关，所以可以使用滚动数组将 $dp$ 数组优化为一维。

**实现**

```C++
const int MOD = 1000000007;

class Solution {
public:
    int numberOfSets(int n, int k) {
        vector<int> dp(n), prefixSums(n + 1);
        for (int j = 0; j < n; j++) {
            dp[j] = 1;
            prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
        }
        for (int i = 1; i <= k; i++) {
            dp[0] = 0;
            for (int j = 1; j < n; j++) {
                dp[j] = (dp[j - 1] + prefixSums[j]) % MOD;
            }
            for (int j = 0; j < n; j++) {
                prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
            }
        }
        return dp[n - 1];
    }
};
```

```Java
class Solution {
    private static final int MOD = 1000000007;

    public int numberOfSets(int n, int k) {
        int[] dp = new int[n];
        int[] prefixSums = new int[n + 1];
        for (int j = 0; j < n; j++) {
            dp[j] = 1;
            prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
        }
        for (int i = 1; i <= k; i++) {
            dp[0] = 0;
            for (int j = 1; j < n; j++) {
                dp[j] = (dp[j - 1] + prefixSums[j]) % MOD;
            }
            for (int j = 0; j < n; j++) {
                prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
            }
        }
        return dp[n - 1];
    }
}
```

```Python
class Solution:
    def numberOfSets(self, n: int, k: int) -> int:
        mod = 10**9 + 7
        dp = [1] * n
        prefix_sums = [0] * (n + 1)
        for j in range(n):
            prefix_sums[j + 1] = (prefix_sums[j] + dp[j]) % mod
        for _ in range(k):
            dp[0] = 0
            for j in range(1, n):
                dp[j] = (dp[j - 1] + prefix_sums[j]) % mod
            for j in range(n):
                prefix_sums[j + 1] = (prefix_sums[j] + dp[j]) % mod
        return dp[n - 1]
```

```Go
func numberOfSets(n int, k int) int {
    const mod = 1000000007
    dp := make([]int, n)
    prefixSums := make([]int, n+1)
    for j := 0; j < n; j++ {
        dp[j] = 1
        prefixSums[j+1] = (prefixSums[j] + dp[j]) % mod
    }
    for i := 1; i <= k; i++ {
        dp[0] = 0
        for j := 1; j < n; j++ {
            dp[j] = (dp[j-1] + prefixSums[j]) % mod
        }
        for j := 0; j < n; j++ {
            prefixSums[j+1] = (prefixSums[j] + dp[j]) % mod
        }
    }
    return dp[n-1]
}
```

```C
int numberOfSets(int n, int k) {
    const int MOD = 1000000007;
    int *dp = malloc(n * sizeof(int));
    int *prefixSums = calloc(n + 1, sizeof(int));
    for (int j = 0; j < n; j++) {
        dp[j] = 1;
        prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
    }
    for (int i = 1; i <= k; i++) {
        dp[0] = 0;
        for (int j = 1; j < n; j++)
            dp[j] = (dp[j - 1] + prefixSums[j]) % MOD;
        for (int j = 0; j < n; j++)
            prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
    }
    int answer = dp[n - 1];
    free(dp);
    free(prefixSums);
    return answer;
}
```

```CSharp
public class Solution {
    public int NumberOfSets(int n, int k) {
        const int MOD = 1000000007;
        int[] dp = new int[n];
        int[] prefixSums = new int[n + 1];
        for (int j = 0; j < n; j++) {
            dp[j] = 1;
            prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
        }
        for (int i = 1; i <= k; i++) {
            dp[0] = 0;
            for (int j = 1; j < n; j++)
                dp[j] = (dp[j - 1] + prefixSums[j]) % MOD;
            for (int j = 0; j < n; j++)
                prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
        }
        return dp[n - 1];
    }
}
```

```JavaScript
var numberOfSets = function(n, k) {
    const MOD = 1000000007;
    const dp = Array(n).fill(1);
    const prefixSums = Array(n + 1).fill(0);
    for (let j = 0; j < n; j++)
        prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
    for (let i = 1; i <= k; i++) {
        dp[0] = 0;
        for (let j = 1; j < n; j++)
            dp[j] = (dp[j - 1] + prefixSums[j]) % MOD;
        for (let j = 0; j < n; j++)
            prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
    }
    return dp[n - 1];
};
```

```TypeScript
function numberOfSets(n: number, k: number): number {
    const MOD = 1000000007;
    const dp = Array(n).fill(1) as number[];
    const prefixSums = Array(n + 1).fill(0) as number[];
    for (let j = 0; j < n; j++)
        prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
    for (let i = 1; i <= k; i++) {
        dp[0] = 0;
        for (let j = 1; j < n; j++)
            dp[j] = (dp[j - 1] + prefixSums[j]) % MOD;
        for (let j = 0; j < n; j++)
            prefixSums[j + 1] = (prefixSums[j] + dp[j]) % MOD;
    }
    return dp[n - 1];
}
```

```Rust
impl Solution {
    pub fn number_of_sets(n: i32, k: i32) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let n = n as usize;
        let mut dp = vec![1i64; n];
        let mut prefix_sums = vec![0i64; n + 1];
        for j in 0..n {
            prefix_sums[j + 1] = (prefix_sums[j] + dp[j]) % MOD;
        }
        for _ in 0..k {
            dp[0] = 0;
            for j in 1..n {
                dp[j] = (dp[j - 1] + prefix_sums[j]) % MOD;
            }
            for j in 0..n {
                prefix_sums[j + 1] = (prefix_sums[j] + dp[j]) % MOD;
            }
        }
        dp[n - 1] as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nk)$。状态数为 $O(nk)$，每个状态计算需要 $O(1)$。
- 空间复杂度：$O(n)$。使用滚动数组优化的 $dp$ 数组需要 $O(n)$ 的空间。

#### 方法二：组合数学

**思路与算法**

题目等价于求出一组 $(l_1,\dots ,l_k,r_1,\dots ,r_k)$ 满足

$$0\le l_1<r_1\le l_2<r_2\le \dots \le l_k<r_k<n$$

从组合数学的角度考虑，假如我们能让线段端点不重合，那么问题就转化求解为从一些数中选择 $2k$ 个数的组合方案数。

令 $l_i^′=l_i+(i-1),r_i^′=r_i+(i-1)$，这相当于将第二条线段的端点往右移动 $1$ 个单位，将第三条线段的端点往右移动 $2$ 个单位，以此类推。经过这样的变换，新的 $l^′$ 与 $r^′$ 与原来的 $l$ 与 $r$ 一一对应，且端点之间不再重合。此时满足

$$0\le l_1^′<r_1^′<l_2^′<r_2^′<\dots <l_k^′<r_k^′<n+k-1$$

问题等价于在 $[0,n+k-1)$ 这 $n+k-1$ 个数中选择 $2k$ 个，答案为 $\binom{n+k-1}{2k}$。

**实现**

```C++
const int MOD = 1000000007;

class Solution {
public:
    long long quickPow(long long a, long long e) {
        long long result = 1;
        while (e > 0) {
            if (e & 1) result = result * a % MOD;
            a = a * a % MOD;
            e >>= 1;
        }
        return result;
    }

    int numberOfSets(int n, int k) {
        int m = 2 * k;
        long long numerator = 1, denominator = 1;
        for (int i = 1; i <= m; i++) {
            numerator = numerator * (n + k - i) % MOD;
            denominator = denominator * i % MOD;
        }
        return numerator * quickPow(denominator, MOD - 2) % MOD;
    }
};
```

```Java
class Solution {
    private static final long MOD = 1000000007L;

    private long quickPow(long a, long e) {
        long result = 1;
        while (e > 0) {
            if ((e & 1) != 0) result = result * a % MOD;
            a = a * a % MOD;
            e >>= 1;
        }
        return result;
    }

    public int numberOfSets(int n, int k) {
        int m = 2 * k;
        long numerator = 1, denominator = 1;
        for (int i = 1; i <= m; i++) {
            numerator = numerator * (n + k - i) % MOD;
            denominator = denominator * i % MOD;
        }
        return (int)(numerator * quickPow(denominator, MOD - 2) % MOD);
    }
}
```

```Python
class Solution:
    def numberOfSets(self, n: int, k: int) -> int:
        return math.comb(n + k - 1, k * 2) % (10**9 + 7)
```

```Go
const mod1621 int64 = 1000000007

func pow1621(a, e int64) int64 {
    result := int64(1)
    for e > 0 {
        if e&1 == 1 { result = result * a % mod1621 }
        a = a * a % mod1621
        e >>= 1
    }
    return result
}

func numberOfSets(n int, k int) int {
    m := 2 * k
    numerator, denominator := int64(1), int64(1)
    for i := 1; i <= m; i++ {
        numerator = numerator * int64(n+k-i) % mod1621
        denominator = denominator * int64(i) % mod1621
    }
    return int(numerator * pow1621(denominator, mod1621-2) % mod1621)
}
```

```C
long long power1621(long long a, long long e) {
    const long long MOD = 1000000007LL;
    long long result = 1;
    while (e > 0) {
        if (e & 1) result = result * a % MOD;
        a = a * a % MOD;
        e >>= 1;
    }
    return result;
}

int numberOfSets(int n, int k) {
    const long long MOD = 1000000007LL;
    int m = 2 * k;
    long long numerator = 1, denominator = 1;
    for (int i = 1; i <= m; i++) {
        numerator = numerator * (n + k - i) % MOD;
        denominator = denominator * i % MOD;
    }
    return (int)(numerator * power1621(denominator, MOD - 2) % MOD);
}
```

```CSharp
public class Solution {
    private const long MOD = 1000000007;

    private long QuickPow(long a, long e) {
        long result = 1;
        while (e > 0) {
            if ((e & 1) != 0) result = result * a % MOD;
            a = a * a % MOD;
            e >>= 1;
        }
        return result;
    }

    public int NumberOfSets(int n, int k) {
        int m = 2 * k;
        long numerator = 1, denominator = 1;
        for (int i = 1; i <= m; i++) {
            numerator = numerator * (n + k - i) % MOD;
            denominator = denominator * i % MOD;
        }
        return (int)(numerator * QuickPow(denominator, MOD - 2) % MOD);
    }
}
```

```JavaScript
var numberOfSets = function(n, k) {
    const MOD = 1000000007n;
    const pow = (a, e) => {
        let result = 1n;
        while (e > 0n) {
            if (e & 1n) result = result * a % MOD;
            a = a * a % MOD;
            e >>= 1n;
        }
        return result;
    };
    let numerator = 1n, denominator = 1n;
    for (let i = 1; i <= 2 * k; i++) {
        numerator = numerator * BigInt(n + k - i) % MOD;
        denominator = denominator * BigInt(i) % MOD;
    }
    return Number(numerator * pow(denominator, MOD - 2n) % MOD);
};
```

```TypeScript
function numberOfSets(n: number, k: number): number {
    const MOD = 1000000007n;
    const pow = (base: bigint, exponent: bigint): bigint => {
        let result = 1n;
        while (exponent > 0n) {
            if (exponent & 1n) result = result * base % MOD;
            base = base * base % MOD;
            exponent >>= 1n;
        }
        return result;
    };
    let numerator = 1n, denominator = 1n;
    for (let i = 1; i <= 2 * k; i++) {
        numerator = numerator * BigInt(n + k - i) % MOD;
        denominator = denominator * BigInt(i) % MOD;
    }
    return Number(numerator * pow(denominator, MOD - 2n) % MOD);
}
```

```Rust
impl Solution {
    fn power(mut a: i64, mut e: i64) -> i64 {
        const MOD: i64 = 1_000_000_007;
        let mut result = 1;
        while e > 0 {
            if e & 1 == 1 { result = result * a % MOD; }
            a = a * a % MOD;
            e >>= 1;
        }
        result
    }

    pub fn number_of_sets(n: i32, k: i32) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let mut numerator = 1i64;
        let mut denominator = 1i64;
        for i in 1..=2 * k {
            numerator = numerator * (n + k - i) as i64 % MOD;
            denominator = denominator * i as i64 % MOD;
        }
        (numerator * Self::power(denominator, MOD - 2) % MOD) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(k+\log M)$，其中 $M$ 是模数，本题中 $M=10^9+7$。计算组合数需要的时间为 $O(k+\log M)$。
- 空间复杂度：$O(1)$。
