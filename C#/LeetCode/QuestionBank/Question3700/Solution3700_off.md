### [锯齿形数组的总数 II](https://leetcode.cn/problems/number-of-zigzag-arrays-ii/solutions/3984256/ju-chi-xing-shu-zu-de-zong-shu-ii-by-lee-z1x1/)

#### 方法一：动态规划 + 矩阵快速幂

本题是[「3699. 锯齿形数组的总数 I」](https://leetcode.cn/problems/number-of-zigzag-arrays-i/)的困难版本，请先理解前置题目的动态规划思想，以及「[矩阵快速幂](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fmath%2Fbinary-exponentiation%2F)」的求法。

**思路与算法**

相较于前置题目，本题在数据范围上大幅降低了取值边界 $l$ 与 $r$ 的范围，但是将数组的长度范围扩展到了 $10^9$，因此不能再直接使用基于下标的遍历转移。

考虑动态规划转移的优化方案：在前置题目中，我们使用了前缀和优化单次状态转移。这本质上揭示了，当前状态是由**前一个状态分量的线性组合**得到的，这意味着我们可以将状态转移写成一个**状态转移矩阵**，将初始状态不断乘上这个状态转移矩阵（左乘右乘均可，但是要保持方向一致），就能得到最终的状态。而一旦将状态转移变换写成矩阵，该矩阵一定是方阵，连乘就可以表达为**方阵的幂次**，我们就可以使用矩阵的快速幂运算来优化求解过程，从而将外层时间复杂度从基于下标遍历的 $O(n)$ 优化到 $O(\log n)$ 级别。这便是本方法的基本思想。

下面来考虑如何构造状态分量和转移矩阵。回顾一下，设区间长度 $m=r-l+1$，之前拆出了两个形状为 $1\times m$ 状态分量 $dp_0$ 和 $dp_1$，其中 $dp_0$ 代表末尾元素和前一个元素构成的排列是严格递减的，$dp_1$ 则代表构成的排列是严格递增的。显然我们可以针对两个状态分量分别构造一个状态转移矩阵，设 $dp_0$ 对应的转移矩阵是 $B$，$dp_1$ 对应的转移矩阵是 $A$，则原来的状态转移过程可以描述为：

$$dp_0[i]=dp_1[i-1]\cdot B \\ dp_1[i]=dp_0[i-1]\cdot A$$

然后我们可以使用分块矩阵的思想，将两个分量合并为一个形状为 $1\times (2\cdot m)$ 的向量 $[dp_0[i],dp_1[i]]$，得到单一转移方程如下：

$$\begin{bmatrix}dp_0[i] & dp_1[i]\end{bmatrix} = \begin{bmatrix}dp_0[i-1] & dp_1[i-1]\end{bmatrix}\cdot \begin{bmatrix}O & A \\ B & O\end{bmatrix}$$

其中，大方阵 $U=\begin{bmatrix}O & A \\ B & O\end{bmatrix}$ 即为合并后的状态转移矩阵，大小为 $(2\cdot m)\times (2\cdot m)$，O 是 $m\times m$ 的零矩阵。这里之所以排列成分块反对角矩阵，是因为两个分量的转移刚好是交错进行的，$dp_0$ 由上一个 $dp_1$ 转移而来，反之同理。

剩下的部分为分块矩阵 $A$ 和 $B$ 的构造。$A$ 和 $B$ 大小均为 $m\times m$，它们定义了前置题目中转移方程的矩阵形式：

- 矩阵 $A$（从 $dp_0$ 转移至 $dp_1$）：设矩阵的行索引和列索引分别为 $i,j$（以 $1$ 为起始下标），根据向量右乘矩阵的定义，对于 $dp_0\cdot A$，新状态的第 $j$ 个分量实际上是由旧状态 $dp_0$ 与矩阵 $A$ 的**第 $j$ 列**进行点乘得到的。换言之，对于 $A$ 的第 $j$ 列，从上到下表达了旧分量参与线性组合的权重。因为转移到 $dp_1$ 要求构成的排列是严格递增的，即旧元素必须严格小于新元素，所以我们要把旧状态中小于 $j$ 的部分求和。反映在矩阵上，意味着对于 $A$ 的第 $j$ 列，只有行索引 $i$ 从 $1$ 到 $j-1$ 的位置系数取 $1$，其余取 $0$。这便构成了主对角线上方全为 $1$ 的**严格上三角矩阵**。
- 矩阵 $B$（从 $dp_1$ 转移至 $dp_0$）：同理可得，转移到要求严格递减的 $dp_0$ 时，因为要求旧元素必须严格大于新元素。反映在矩阵 $B$ 的第 $j$ 列上，就是行索引 $i$ 从 $j+1$ 到 $m$ 的位置的系数取 $1$。最终将构成一个主对角线下方全为 $1$ 的**严格下三角矩阵**。

为了直观地理解，取 $m=3$ 作为示例。此时矩阵 $A$ 和 $B$ 分别为：

$$A=\begin{bmatrix}0 & 1 & 1 \\ 0 & 0 & 1 \\ 0 & 0 & 0\end{bmatrix},B=\begin{bmatrix}0 & 0 & 0 \\ 1 & 0 & 0 \\ 1 & 1 & 0\end{bmatrix}$$

将它们按分块矩阵的规则组装成完整的 $6\times 6$ 状态转移方阵 $U$，如下所示：

$$U=
\left[\begin{array}{ccc:ccc}
    0 & 0 & 0 & 0 & 1 & 1 \\
    0 & 0 & 0 & 0 & 0 & 1 \\
    0 & 0 & 0 & 0 & 0 & 0 \\
    \hdashline
    0 & 0 & 0 & 0 & 0 & 0 \\
    1 & 0 & 0 & 0 & 0 & 0 \\
    1 & 1 & 0 & 0 & 0 & 0
\end{array}\right]$$

设目标锯齿数组的长度是 $n$，此时终态为 $dp[n-1]$，求解过程如下：

$$dp[n-1]=dp[0]\cdot U^{n-1}$$

构造全 $1$ 的向量作为 $dp$ 的初始分量，将其与 $U$ 矩阵使用快速幂进行幂次运算，再对 $dp$ 的结果求和，即为所求。矩阵快速幂算法和整数下的快速幂一致，只是将其中的乘法运算替换为矩阵乘法，这里不再赘述。唯一需要注意一点是，实现的时候可以直接将 $dp[0]$ 而不是单位阵作为左乘的第一个矩阵。由于 $dp[0]$ 是一个 $1\times 2\cdot m$ 的向量，每次乘上 $U$ 后得到的也是 $1\times 2\cdot m$ 的向量，这可以大幅减少快速幂过程中矩阵乘法的运算次数。

**代码**

```C++
class Solution {
private:
    static constexpr long long MOD = 1'000'000'007;
    using Matrix = vector<vector<long long>>;

    Matrix mul(const Matrix& a, const Matrix& b) {
        int n = a.size();
        int m = b[0].size();
        Matrix res(n, vector<long long>(m, 0));

        for (int i = 0; i < n; i++) {
            for (int k = 0; k < a[0].size(); k++) {
                long long r = a[i][k];
                if (r == 0) {
                    continue;
                }
                for (int j = 0; j < m; j++) {
                    res[i][j] = (res[i][j] + r * b[k][j]) % MOD;
                }
            }
        }
        return res;
    }

    Matrix powMul(Matrix base, long long exp, Matrix res) {
        while (exp > 0) {
            if (exp & 1) {
                res = mul(res, base);
            }
            base = mul(base, base);
            exp >>= 1;
        }
        return res;
    }

public:
    int zigZagArrays(int n, int l, int r) {
        int m = r - l + 1;
        if (n == 1) {
            return m;
        }

        int size = 2 * m;
        Matrix u(size, vector<long long>(size, 0));

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < i; j++) {
                u[i][j + m] = 1;
            }
            for (int j = i + 1; j < m; j++) {
                u[i + m][j] = 1;
            }
        }

        Matrix dp(1, vector<long long>(size, 1));

        dp = powMul(std::move(u), n - 1, std::move(dp));

        long long ans = 0;
        for (int i = 0; i < size; i++) {
            ans = (ans + dp[0][i]) % MOD;
        }

        return ans;
    }
};
```

```Python
class Solution:
    MOD = 1_000_000_007

    def mul(self, a, b):
        n = len(a)
        m = len(b[0])
        res = [[0] * m for _ in range(n)]

        for i in range(n):
            for k in range(len(a[0])):
                r = a[i][k]
                if r == 0:
                    continue
                for j in range(m):
                    res[i][j] = (res[i][j] + r * b[k][j]) % self.MOD
        return res

    def powMul(self, base, exp, res):
        while exp > 0:
            if exp & 1:
                res = self.mul(res, base)
            base = self.mul(base, base)
            exp >>= 1
        return res

    def zigZagArrays(self, n: int, l: int, r: int) -> int:
        m = r - l + 1
        if n == 1:
            return m

        size = 2 * m
        u = [[0] * size for _ in range(size)]
        for i in range(m):
            for j in range(i):
                u[i][j + m] = 1
            for j in range(i + 1, m):
                u[i + m][j] = 1

        dp = [[1] * size]
        dp = self.powMul(u, n - 1, dp)
        ans = 0
        for i in range(size):
            ans = (ans + dp[0][i]) % self.MOD

        return ans
```

```Java
class Solution {
    private static final long MOD = 1_000_000_007L;

    static class Matrix {
        int n, m;
        long[] data;

        Matrix(int n, int m) {
            this.n = n;
            this.m = m;
            this.data = new long[n * m];
        }

        long get(int i, int j) {
            return data[i * m + j];
        }

        void set(int i, int j, long val) {
            data[i * m + j] = val;
        }

        Matrix mul(Matrix b) {
            Matrix res = new Matrix(n, b.m);
            for (int i = 0; i < n; i++) {
                for (int k = 0; k < m; k++) {
                    long r = this.get(i, k);
                    if (r == 0) {
                        continue;
                    }

                    for (int j = 0; j < b.m; j++) {
                        res.set(i, j, (res.get(i, j) + r * b.get(k, j)) % MOD);
                    }
                }
            }
            return res;
        }

        Matrix pow(long exp, Matrix res) {
            Matrix base = new Matrix(n, m);
            System.arraycopy(this.data, 0, base.data, 0, this.data.length);

            while (exp > 0) {
                if ((exp & 1L) == 1L) {
                    res = res.mul(base);
                }
                base = base.mul(base);
                exp >>= 1L;
            }
            return res;
        }
    }

    public int zigZagArrays(int n, int l, int r) {
        int m = r - l + 1;
        if (n == 1) {
            return m;
        }

        Matrix u = new Matrix(2 * m, 2 * m);

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < i; j++) {
                u.set(i, j + m, 1L);
            }
            for (int j = i + 1; j < m; j++) {
                u.set(i + m, j, 1L);
            }
        }

        Matrix dp = new Matrix(1, 2 * m);
        for (int i = 0; i < 2 * m; i++) {
            dp.set(0, i, 1L);
        }

        dp = u.pow(n - 1, dp);

        long ans = 0;
        for (int i = 0; i < 2 * m; i++) {
            ans = (ans + dp.get(0, i)) % MOD;
        }

        return (int) ans;
    }
}
```

```CSharp
public class Solution
{
    const long MOD = 1_000_000_007;

    public struct Matrix
    {
        public int n, m;
        public long[] data;

        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            data = new long[n * m];
        }

        public long Get(int i, int j) => data[i * m + j];
        public void Set(int i, int j, long val) => data[i * m + j] = val;

        public static Matrix operator *(Matrix a, Matrix b)
        {
            var res = new Matrix(a.n, b.m);

            for (var i = 0; i < a.n; i++)
            {
                for (var k = 0; k < a.m; k++)
                {
                    var r = a.Get(i, k);
                    if (r == 0) continue;

                    for (var j = 0; j < b.m; j++)
                    {
                        res.Set(i, j, (res.Get(i, j) + r * b.Get(k, j)) % MOD);
                    }
                }
            }
            return res;
        }

        public Matrix PowMul(long exp, Matrix res)
        {
            var baseMat = new Matrix(n, m);
            Array.Copy(data, baseMat.data, data.Length);

            while (exp > 0)
            {
                if ((exp & 1) == 1)
                {
                    res *= baseMat;
                }
                baseMat *= baseMat;
                exp >>= 1;
            }
            return res;
        }
    }

    public int ZigZagArrays(int n, int l, int r)
    {
        if (n == 1) return r - l + 1;

        var m = r - l + 1;
        var size = 2 * m;
        var u = new Matrix(size, size);

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < i; j++) u.Set(i, j + m, 1);
            for (var j = i + 1; j < m; j++) u.Set(i + m, j, 1);
        }

        var dp = new Matrix(1, size);
        Array.Fill(dp.data, 1L);

        dp = u.PowMul(n - 1, dp);

        return (int)dp.data.Aggregate(0L, (acc, val) => (acc + val) % MOD);
    }
}
```

```C
#define MOD 1000000007LL

typedef long long ll;

ll** matrix_alloc(int n, int m) {
    ll** mat = (ll**)malloc(n * sizeof(ll*));
    for (int i = 0; i < n; i++) {
        mat[i] = (ll*)calloc(m, sizeof(ll));
    }
    return mat;
}

void matrix_free(ll** mat, int n) {
    for (int i = 0; i < n; i++) {
        free(mat[i]);
    }
    free(mat);
}

ll** mul(ll** a, ll** b, int an, int am, int bm) {
    ll** res = matrix_alloc(an, bm);

    for (int i = 0; i < an; i++) {
        for (int k = 0; k < am; k++) {
            ll r = a[i][k];
            if (r == 0) {
                continue;
            }
            for (int j = 0; j < bm; j++) {
                res[i][j] = (res[i][j] + r * b[k][j]) % MOD;
            }
        }
    }
    return res;
}

void pow_mul(ll** base, int size, ll exp, ll** res) {
    ll** base_copy = matrix_alloc(size, size);
    ll** res_copy = matrix_alloc(1, size);

    for (int i = 0; i < size; i++) {
        memcpy(base_copy[i], base[i], size * sizeof(ll));
    }
    memcpy(res_copy[0], res[0], size * sizeof(ll));

    while (exp > 0) {
        if (exp & 1) {
            ll** temp = mul(res_copy, base_copy, 1, size, size);
            matrix_free(res_copy, 1);
            res_copy = temp;
        }
        ll** temp = mul(base_copy, base_copy, size, size, size);
        matrix_free(base_copy, size);
        base_copy = temp;
        exp >>= 1;
    }

    memcpy(res[0], res_copy[0], size * sizeof(ll));

    matrix_free(base_copy, size);
    matrix_free(res_copy, 1);
}

int zigZagArrays(int n, int l, int r) {
    int m = r - l + 1;
    if (n == 1) {
        return m;
    }

    int size = 2 * m;
    ll** u = matrix_alloc(size, size);

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < i; j++) {
            u[i][j + m] = 1;
        }
        for (int j = i + 1; j < m; j++) {
            u[i + m][j] = 1;
        }
    }

    ll** dp = matrix_alloc(1, size);
    for (int i = 0; i < size; i++) {
        dp[0][i] = 1;
    }

    pow_mul(u, size, (ll)(n - 1), dp);
    ll ans = 0;
    for (int i = 0; i < size; i++) {
        ans = (ans + dp[0][i]) % MOD;
    }

    matrix_free(u, size);
    matrix_free(dp, 1);

    return (int)ans;
}
```

```JavaScript
const MOD = 1_000_000_007n;

class Matrix {
    constructor(n, m) {
        this.n = n;
        this.m = m;
        this.data = new BigInt64Array(n * m);
    }

    get(i, j) {
        return this.data[i * this.m + j];
    }

    set(i, j, val) {
        this.data[i * this.m + j] = val;
    }

    mul(b) {
        const res = new Matrix(this.n, b.m);

        for (let i = 0; i < this.n; i++) {
            for (let k = 0; k < this.m; k++) {
                const r = this.get(i, k);
                if (r === 0n) continue;

                for (let j = 0; j < b.m; j++) {
                    res.set(i, j, (res.get(i, j) + r * b.get(k, j)) % MOD);
                }
            }
        }
        return res;
    }

    powMul(exp, res) {
        let base = new Matrix(this.n, this.m);
        base.data = new BigInt64Array(this.data);

        while (exp > 0n) {
            if ((exp & 1n) === 1n) {
                res = res.mul(base);
            }
            base = base.mul(base);
            exp >>= 1n;
        }

        return res;
    }
}

function zigZagArrays(n, l, r) {
    const m = r - l + 1;
    if (n === 1) return m;

    let u = new Matrix(2 * m, 2 * m);

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < i; j++) {
            u.set(i, j + m, 1n);
        }
        for (let j = i + 1; j < m; j++) {
            u.set(i + m, j, 1n);
        }
    }

    let dp = new Matrix(1, 2 * m);
    for (let i = 0; i < 2 * m; i++) {
        dp.set(0, i, 1n);
    }

    dp = u.powMul(BigInt(n - 1), dp);

    let ans = 0n;
    for (let i = 0; i < 2 * m; i++) {
        ans = (ans + dp.get(0, i)) % MOD;
    }

    return Number(ans);
}
```

```TypeScript
const MOD = 1_000_000_007n;

class Matrix {
    data: BigInt64Array;

    constructor(public n: number, public m: number) {
        this.data = new BigInt64Array(n * m);
    }

    get(i: number, j: number): bigint {
        return this.data[i * this.m + j];
    }

    set(i: number, j: number, val: bigint) {
        this.data[i * this.m + j] = val;
    }

    mul(b: Matrix): Matrix {
        const res = new Matrix(this.n, b.m);

        for (let i = 0; i < this.n; i++) {
            for (let k = 0; k < this.m; k++) {
                const r = this.get(i, k);
                if (r === 0n) continue;

                for (let j = 0; j < b.m; j++) {
                    res.set(i, j, (res.get(i, j) + r * b.get(k, j)) % MOD);
                }
            }
        }
        return res;
    }

    powMul(exp: bigint, res: Matrix): Matrix {
        let base = new Matrix(this.n, this.m);
        base.data = new BigInt64Array(this.data);

        while (exp > 0n) {
            if ((exp & 1n) === 1n) {
                res = res.mul(base);
            }
            base = base.mul(base);
            exp >>= 1n;
        }

        return res;
    }
}

function zigZagArrays(n: number, l: number, r: number): number {
    const m = r - l + 1;
    if (n === 1) return m;

    let u = new Matrix(2 * m, 2 * m);

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < i; j++) {
            u.set(i, j + m, 1n);
        }
        for (let j = i + 1; j < m; j++) {
            u.set(i + m, j, 1n);
        }
    }

    let dp = new Matrix(1, 2 * m);
    for (let i = 0; i < 2 * m; i++) {
        dp.set(0, i, 1n);
    }

    dp = u.powMul(BigInt(n - 1), dp);

    let ans = 0n;
    for (let i = 0; i < 2 * m; i++) {
        ans = (ans + dp.get(0, i)) % MOD;
    }

    return Number(ans);
}
```

```Go
const MOD = 1000000007

type Matrix [][]int64

func mul(a, b Matrix) Matrix {
    n := len(a)
    m := len(b[0])
    res := make(Matrix, n)
    for i := range res {
        res[i] = make([]int64, m)
    }

    for i := 0; i < n; i++ {
        for k := 0; k < len(a[0]); k++ {
            r := a[i][k]
            if r == 0 {
                continue
            }
            for j := 0; j < m; j++ {
                res[i][j] = (res[i][j] + r * b[k][j]) % MOD
            }
        }
    }
    return res
}

func powMul(base Matrix, exp int64, res Matrix) Matrix {
    for exp > 0 {
        if exp & 1 == 1 {
            res = mul(res, base)
        }
        base = mul(base, base)
        exp >>= 1
    }
    return res
}

func zigZagArrays(n int, l int, r int) int {
    m := r - l + 1
    if n == 1 {
        return m
    }

    size := 2 * m
    u := make(Matrix, size)
    for i := range u {
        u[i] = make([]int64, size)
    }

    for i := 0; i < m; i++ {
        for j := 0; j < i; j++ {
            u[i][j+m] = 1
        }
        for j := i + 1; j < m; j++ {
            u[i+m][j] = 1
        }
    }

    dp := make(Matrix, 1)
    dp[0] = make([]int64, size)
    for i := 0; i < size; i++ {
        dp[0][i] = 1
    }

    dp = powMul(u, int64(n-1), dp)

    var ans int64 = 0
    for i := 0; i < size; i++ {
        ans = (ans + dp[0][i]) % MOD
    }

    return int(ans)
}
```

```Rust
const MOD: i64 = 1_000_000_007;

#[derive(Clone)]
struct Matrix {
    n: usize,
    m: usize,
    data: Vec<i64>,
}

impl Matrix {
    fn new(n: usize, m: usize) -> Self {
        Matrix {
            n,
            m,
            data: vec![0; n * m],
        }
    }

    fn get(&self, i: usize, j: usize) -> i64 {
        self.data[i * self.m + j]
    }

    fn set(&mut self, i: usize, j: usize, val: i64) {
        self.data[i * self.m + j] = val;
    }

    fn pow_mul(mut self, mut exp: i64, mut res: Matrix) -> Matrix {
        while exp > 0 {
            if exp & 1 == 1 {
                res = &res * &self;
            }
            self = &self * &self;
            exp >>= 1;
        }
        res
    }
}

impl std::ops::Mul for &Matrix {
    type Output = Matrix;

    fn mul(self, b: &Matrix) -> Matrix {
        let mut res = Matrix::new(self.n, b.m);
        for i in 0..self.n {
            for k in 0..self.m {
                let r = self.get(i, k);
                if r == 0 { continue; }

                for j in 0..b.m {
                    res.set(i, j, (res.get(i, j) + r * b.get(k, j)) % MOD);
                }
            }
        }
        res
    }
}

impl Solution {
    pub fn zig_zag_arrays(n: i32, l: i32, r: i32) -> i32 {
        let m = (r - l + 1) as usize;
        if n == 1 { return m as i32; }

        let size = 2 * m;
        let mut u = Matrix::new(size, size);

        for i in 0..m {
            for j in 0..i {
                u.set(i, j + m, 1);
            }
            for j in (i + 1)..m {
                u.set(i + m, j, 1);
            }
        }

        let mut dp = Matrix::new(1, size);
        for i in 0..size {
            dp.set(0, i, 1);
        }

        dp = u.pow_mul((n - 1) as i64, dp);

        let mut ans = 0;
        for i in 0..size {
            ans = (ans + dp.get(0, i)) % MOD;
        }

        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m^3\log n)$，其中 $m$ 是给定区间的长度，即 $r-l+1$。其中构造各个矩阵需要 $O(m^2)$；矩阵快速幂外层循环需要 $O(\log n)$，矩阵乘法需要 $O(m^3)$，总时间复杂度为 $O(m^3\log n)$；最后求和需要 $O(m)$。故总时间复杂度为 $O(m^3\log n)$。
- 空间复杂度：$O(m^2)$。状态转移矩阵 $u$ 需要 $O(m^2)$ 的空间，初始状态向量 $dp$ 需要 $O(m)$，矩阵相乘的中间变量需要额外 $O(m^2)$ 空间。故总空间复杂度是 $O(m^2)$。
