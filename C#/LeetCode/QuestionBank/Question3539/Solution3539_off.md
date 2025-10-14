### [魔法序列的数组乘积之和](https://leetcode.cn/problems/find-sum-of-array-product-of-magical-sequences/solutions/3800541/mo-fa-xu-lie-de-shu-zu-cheng-ji-zhi-he-b-54vt/)

#### 方法一：动态规划

令数组 $nums$ 的长度为 $n$。根据题意，我们依次从 $0$ 到 $n-1$ 分别取若干个数（即 $nums$ 的下标）组成序列 $seq$，假设取值等于 $t$ 的元素有 $r_t$ 个，那么有 $\sum_{t=0}^{n-1}r_t=m$，并且这些序列排列数为：

$$\dfrac{m!}{\Pi_{t=0}^{n-1}r_t!}$$

这些序列对应的数组乘积和为：

$$\dfrac{m!}{\Pi_{t=0}^{n-1}r_t!}\times \Pi_{t=0}^{n-1}nums[t]^{r_t}=m!\times \Pi_{t=0}^{n-1}\dfrac{nums[t]^{r_t}}{r_t!}$$

对于数字集合 $X$，我们定义 $mask(X)=\sum_{x\in X}2^x$。根据上述计算公式，我们模拟取数过程，假设从 $0$ 取到 $i$，总共取了 $j$ 个数，并且已取到的数集合对应的 $mask$ 为 $p$，令 $f(i,j,p)$ 为所有的取数方案对应的 $\Pi_{t=0}^i\dfrac{nums[t]^{r_t}}{r_t!}$ 的和。当取到数 $i+1$ 时，并且取数数目为 $r_{i+1}$，那么 $f(i,j,p)$ 对 $f(i+1,j+r_{i+1},p+2^{i+1}\times r_{i+1})$ 的贡献为：

$$f(i,j,p)\times\dfrac{nums[i+1]^{r_{i+1}}}{r_{i+1}!}$$

当我们取到数 $i+1$ 时，不会影响到已取到的数集合的 $T$ 函数值的低 $i$ 位，因此我们可以将 $p$ 拆分成低 $i$ 位和后面的二进制位，令低 $i$ 位的置位为 $q$ 个，类似上面的贡献公式 $(i,j,p,q)$ 对 $f(i+1,j+r_{i+1},\lfloor\dfrac{p}{2}\rfloor +r_{i+1},q+(pmod2))$ 为：

$$f(i,j,p,q)\times\dfrac{nums[i+1]^{r_{i+1}}}{r_{i+1}!}$$

对于递推式 $f(i,j,p,q)$，当 $i=0$ 时，显然也有 $q=0$，那么初始时：

$$f(0,j,j,0)=\dfrac{nums[0]^j}{j!}$$

利用初始值和递推式，我们求解所有的 $f(i,j,p,q)$ 的取值，那么所有魔法序列的数组乘积的总和为：

$$\sum\limits_{b_p+q=k}(m!\times f(n-1,m,p,q))$$

其中 $b_p$ 表示 $p$ 的置位数。

```C++
class Solution {
public:
    long long quickmul(long long x, long long y, long long mod) {
        long long res = 1, cur = x % mod;
        while(y) {
            if(y & 1) {
                res = res * cur % mod;
            }
            y >>= 1;
            cur = cur * cur % mod;
        }
        return res;
    };

    int magicalSum(int m, int k, vector<int>& nums) {
        int n = nums.size();
        const long long mod = 1e9 + 7;
        vector<long long> fac(m + 1, 1);
        for (int i = 1; i <= m; i++) {
            fac[i] = fac[i - 1] * i % mod;
        }
        vector<long long> ifac(m + 1, 1);
        for (int i = 2; i <= m; i++) {
            ifac[i] = quickmul(i, mod - 2, mod);
        }
        for (int i = 2; i <= m; i++) {
            ifac[i] = ifac[i - 1] * ifac[i] % mod;
        }
        vector numsPower(n, vector<long long>(m + 1, 1));
        for (int i = 0; i < n; i++) {
            for (int j = 1; j <= m; j++) {
                numsPower[i][j] = numsPower[i][j - 1] * nums[i] % mod;
            }
        }

        vector f(n, vector(m + 1, vector(m * 2 + 1, vector<long long>(k + 1, 0))));
        for (int j = 0; j <= m; j++) {
            f[0][j][j][0] = numsPower[0][j] * ifac[j] % mod;
        }
        for (int i = 0; i + 1 < n; i++) {
            for (int j = 0; j <= m; j++) {
                for (int p = 0; p <= m * 2; p++) {
                    for (int q = 0; q <= k; q++) {
                        int q2 = p % 2 + q;
                        if (q2 > k) {
                            break;
                        }
                        for (int r = 0; r + j <= m; r++) {
                            int p2 = p / 2 + r;
                            f[i + 1][j + r][p2][q2] += f[i][j][p][q] * numsPower[i + 1][r] % mod * ifac[r] % mod;
                            f[i + 1][j + r][p2][q2] %= mod;
                        }
                    }
                }
            }
        }
        long long res = 0;
        for (int p = 0; p <= m * 2; p++) {
            for (int q = 0; q <= k; q++) {
                if (__builtin_popcount(p) + q == k) {
                    res = (res + f[n - 1][m][p][q] * fac[m] % mod) % mod;
                }
            }
        }
        return res;
    }
};
```

```Go
func quickmul(x, y, mod int64) int64 {
    res, cur := int64(1), x % mod
    for y > 0 {
        if y & 1 == 1 {
            res = res * cur % mod
        }
        y >>= 1
        cur = cur * cur % mod
    }
    return res
}

func magicalSum(m int, k int, nums []int) int {
    mod := int64(1000000007)
    fac := make([]int64, m + 1)
    fac[0] = 1
    for i := 1; i <= m; i++ {
        fac[i] = fac[i - 1] * int64(i) % mod
    }
    ifac := make([]int64, m+1)
    ifac[0] = 1
    ifac[1] = 1
    for i := 2; i <= m; i++ {
        ifac[i] = quickmul(int64(i), mod - 2, mod)
    }
    for i := 2; i <= m; i++ {
        ifac[i] = ifac[i - 1] * ifac[i] % mod
    }

    numsPower := make([][]int64, len(nums))
    for i := range nums {
        numsPower[i] = make([]int64, m + 1)
        numsPower[i][0] = 1
        for j := 1; j <= m; j++ {
            numsPower[i][j] = numsPower[i][j - 1] * int64(nums[i]) % mod
        }
    }

    f := make([][][][]int64, len(nums))
    for i := range nums {
        f[i] = make([][][]int64, m+1)
        for j := 0; j <= m; j++ {
            f[i][j] = make([][]int64, m * 2 + 1)
            for p := 0; p <= m * 2; p++ {
                f[i][j][p] = make([]int64, k + 1)
            }
        }
    }

    for j := 0; j <= m; j++ {
        f[0][j][j][0] = numsPower[0][j] * ifac[j] % mod
    }
    for i := 0; i + 1 < len(nums); i++ {
        for j := 0; j <= m; j++ {
            for p := 0; p <= m * 2; p++ {
                for q := 0; q <= k; q++ {
                    q2 := p % 2 + q
                    if q2 > k {
                        break
                    }
                    for r := 0; r + j <= m; r++ {
                        p2 := p / 2 + r
                        f[i + 1][j + r][p2][q2] += f[i][j][p][q] * numsPower[i + 1][r] % mod * ifac[r] % mod
                        f[i + 1][j + r][p2][q2] %= mod
                    }
                }
            }
        }
    }

    res := int64(0)
    for p := 0; p <= m * 2; p++ {
        for q := 0; q <= k; q++ {
            if bits.OnesCount(uint(p)) + q == k {
                res = (res + f[len(nums) - 1][m][p][q] * fac[m] % mod) % mod
            }
        }
    }
    return int(res)
}
```

```Java
class Solution {
    public long quickmul(long x, long y, long mod) {
        long res = 1, cur = x % mod;
        while (y > 0) {
            if ((y & 1) == 1) {
                res = res * cur % mod;
            }
            y >>= 1;
            cur = cur * cur % mod;
        }
        return res;
    }

    public int magicalSum(int m, int k, int[] nums) {
        int n = nums.length;
        long mod = 1000000007;
        long[] fac = new long[m + 1];
        fac[0] = 1;
        for (int i = 1; i <= m; i++) {
            fac[i] = fac[i - 1] * i % mod;
        }
        long[] ifac = new long[m + 1];
        ifac[0] = 1;
        ifac[1] = 1;
        for (int i = 2; i <= m; i++) {
            ifac[i] = quickmul(i, mod - 2, mod);
        }
        for (int i = 2; i <= m; i++) {
            ifac[i] = ifac[i - 1] * ifac[i] % mod;
        }
        long[][] numsPower = new long[n][m + 1];
        for (int i = 0; i < n; i++) {
            numsPower[i][0] = 1;
            for (int j = 1; j <= m; j++) {
                numsPower[i][j] = numsPower[i][j - 1] * nums[i] % mod;
            }
        }
        long[][][][] f = new long[n][m + 1][m * 2 + 1][k + 1];
        for (int j = 0; j <= m; j++) {
            f[0][j][j][0] = numsPower[0][j] * ifac[j] % mod;
        }
        for (int i = 0; i + 1 < n; i++) {
            for (int j = 0; j <= m; j++) {
                for (int p = 0; p <= m * 2; p++) {
                    for (int q = 0; q <= k; q++) {
                        int q2 = p % 2 + q;
                        if (q2 > k) {
                            break;
                        }
                        for (int r = 0; r + j <= m; r++) {
                            int p2 = p / 2 + r;
                            f[i + 1][j + r][p2][q2] += f[i][j][p][q] * numsPower[i + 1][r] % mod * ifac[r] % mod;
                            f[i + 1][j + r][p2][q2] %= mod;
                        }
                    }
                }
            }
        }
        long res = 0;
        for (int p = 0; p <= m * 2; p++) {
            for (int q = 0; q <= k; q++) {
                if (Integer.bitCount(p) + q == k) {
                    res = (res + f[n - 1][m][p][q] * fac[m] % mod) % mod;
                }
            }
        }
        return (int) res;
    }
}
```

```C
long long quickmul(long long x, long long y, long long mod) {
    long long res = 1, cur = x % mod;
    while (y) {
        if (y & 1) {
            res = res * cur % mod;
        }
        y >>= 1;
        cur = cur * cur % mod;
    }
    return res;
}

int magicalSum(int m, int k, int* nums, int numsSize) {
    const long long mod = 1000000007;
    long long* fac = (long long*)malloc((m + 1) * sizeof(long long));
    long long* ifac = (long long*)malloc((m + 1) * sizeof(long long));
    fac[0] = 1;
    for (int i = 1; i <= m; i++) {
        fac[i] = fac[i - 1] * i % mod;
    }
    ifac[0] = 1;
    ifac[1] = 1;
    for (int i = 2; i <= m; i++) {
        ifac[i] = quickmul(i, mod - 2, mod);
    }
    for (int i = 2; i <= m; i++) {
        ifac[i] = ifac[i - 1] * ifac[i] % mod;
    }

    long long** numsPower = (long long**)malloc(numsSize * sizeof(long long*));
    for (int i = 0; i < numsSize; i++) {
        numsPower[i] = (long long*)malloc((m + 1) * sizeof(long long));
        numsPower[i][0] = 1;
        for (int j = 1; j <= m; j++) {
            numsPower[i][j] = numsPower[i][j - 1] * nums[i] % mod;
        }
    }

    long long**** f = (long long****)malloc(numsSize * sizeof(long long***));
    for (int i = 0; i < numsSize; i++) {
        f[i] = (long long***)malloc((m + 1) * sizeof(long long**));
        for (int j = 0; j <= m; j++) {
            f[i][j] = (long long**)malloc((m * 2 + 1) * sizeof(long long*));
            for (int p = 0; p <= m * 2; p++) {
                f[i][j][p] = (long long*)calloc((k + 1), sizeof(long long));
            }
        }
    }

    for (int j = 0; j <= m; j++) {
        f[0][j][j][0] = numsPower[0][j] * ifac[j] % mod;
    }
    for (int i = 0; i + 1 < numsSize; i++) {
        for (int j = 0; j <= m; j++) {
            for (int p = 0; p <= m * 2; p++) {
                for (int q = 0; q <= k; q++) {
                    int q2 = p % 2 + q;
                    if (q2 > k) {
                        break;
                    }
                    for (int r = 0; r + j <= m; r++) {
                        int p2 = p / 2 + r;
                        f[i + 1][j + r][p2][q2] += f[i][j][p][q] * numsPower[i + 1][r] % mod * ifac[r] % mod;
                        f[i + 1][j + r][p2][q2] %= mod;
                    }
                }
            }
        }
    }

    long long res = 0;
    for (int p = 0; p <= m * 2; p++) {
        for (int q = 0; q <= k; q++) {
            int bitcount = __builtin_popcount(p);
            if (bitcount + q == k) {
                res = (res + f[numsSize - 1][m][p][q] * fac[m] % mod) % mod;
            }
        }
    }
    return (int)res;
}
```

```CSharp
public class Solution {
    public int MagicalSum(int m, int k, int[] nums) {
        int n = nums.Length;
        const long mod = 1000000007;
        
        long[] fac = new long[m + 1];
        fac[0] = 1;
        for (int i = 1; i <= m; i++) {
            fac[i] = fac[i - 1] * i % mod;
        }
        
        long[] ifac = new long[m + 1];
        ifac[0] = 1;
        ifac[1] = 1;
        for (int i = 2; i <= m; i++) {
            ifac[i] = QuickMul(i, mod - 2, mod);
        }
        for (int i = 2; i <= m; i++) {
            ifac[i] = ifac[i - 1] * ifac[i] % mod;
        }
        
        long[][] numsPower = new long[n][];
        for (int i = 0; i < n; i++) {
            numsPower[i] = new long[m + 1];
            numsPower[i][0] = 1;
            for (int j = 1; j <= m; j++) {
                numsPower[i][j] = numsPower[i][j - 1] * nums[i] % mod;
            }
        }

        long[][][][] f = new long[n][][][];
        for (int i = 0; i < n; i++) {
            f[i] = new long[m + 1][][];
            for (int j = 0; j <= m; j++) {
                f[i][j] = new long[m * 2 + 1][];
                for (int p = 0; p <= m * 2; p++) {
                    f[i][j][p] = new long[k + 1];
                }
            }
        }
        
        for (int j = 0; j <= m; j++) {
            f[0][j][j][0] = numsPower[0][j] * ifac[j] % mod;
        }
        
        for (int i = 0; i + 1 < n; i++) {
            for (int j = 0; j <= m; j++) {
                for (int p = 0; p <= m * 2; p++) {
                    for (int q = 0; q <= k; q++) {
                        int q2 = (p % 2) + q;
                        if (q2 > k) {
                            break;
                        }
                        for (int r = 0; r + j <= m; r++) {
                            int p2 = p / 2 + r;
                            f[i + 1][j + r][p2][q2] += f[i][j][p][q] * numsPower[i + 1][r] % mod * ifac[r] % mod;
                            f[i + 1][j + r][p2][q2] %= mod;
                        }
                    }
                }
            }
        }
        
        long res = 0;
        for (int p = 0; p <= m * 2; p++) {
            for (int q = 0; q <= k; q++) {
                if (BitOperations.PopCount((uint)p) + q == k) {
                    res = (res + f[n - 1][m][p][q] * fac[m] % mod) % mod;
                }
            }
        }
        return (int)res;
    }

    private long QuickMul(long x, long y, long mod) {
        long res = 1, cur = x % mod;
        while (y > 0) {
            if ((y & 1) == 1) {
                res = res * cur % mod;
            }
            y >>= 1;
            cur = cur * cur % mod;
        }
        return res;
    }
}
```

```Python
class Solution:
    def quickmul(self, x: int, y: int, mod: int) -> int:
        res, cur = 1, x % mod
        while y:
            if y & 1:
                res = res * cur % mod
            y >>= 1
            cur = cur * cur % mod
        return res

    def magicalSum(self, m: int, k: int, nums: List[int]) -> int:
        n = len(nums)
        mod = 10**9 + 7

        fac = [1] * (m + 1)
        for i in range(1, m + 1):
            fac[i] = fac[i - 1] * i % mod
 
        ifac = [1] * (m + 1)
        for i in range(2, m + 1):
            ifac[i] = self.quickmul(i, mod - 2, mod)
        for i in range(2, m + 1):
            ifac[i] = ifac[i - 1] * ifac[i] % mod
            
        numsPower = [[1] * (m + 1) for _ in range(n)]
        for i in range(n):
            for j in range(1, m + 1):
                numsPower[i][j] = numsPower[i][j - 1] * nums[i] % mod

        f = [[[[0] * (k + 1) for _ in range(m * 2 + 1)] 
              for _ in range(m + 1)] for _ in range(n)]
        
        for j in range(m + 1):
            f[0][j][j][0] = numsPower[0][j] * ifac[j] % mod
            
        for i in range(n - 1):
            for j in range(m + 1):
                for p in range(m * 2 + 1):
                    for q in range(k + 1):
                        if f[i][j][p][q] == 0:
                            continue
                        q2 = (p % 2) + q
                        if q2 > k:
                            break
                        for r in range(m - j + 1):
                            p2 = (p // 2) + r
                            if p2 > m * 2:
                                continue
                            f[i + 1][j + r][p2][q2] = (
                                f[i + 1][j + r][p2][q2] + 
                                f[i][j][p][q] * numsPower[i + 1][r] % mod * ifac[r] % mod
                            ) % mod
        
        res = 0
        for p in range(m * 2 + 1):
            for q in range(k + 1):
                if bin(p).count('1') + q == k:
                    res = (res + f[n - 1][m][p][q] * fac[m] % mod) % mod
        return res
```

```JavaScript
var magicalSum = function(m, k, nums) {
    const n = nums.length;
    const mod = 1000000007n;
    
    const fac = new Array(m + 1).fill(1n);
    for (let i = 1; i <= m; i++) {
        fac[i] = fac[i - 1] * BigInt(i) % mod;
    }
    
    const ifac = new Array(m + 1).fill(1n);
    for (let i = 2; i <= m; i++) {
        ifac[i] = quickmul(BigInt(i), mod - 2n, mod);
    }
    for (let i = 2; i <= m; i++) {
        ifac[i] = ifac[i - 1] * ifac[i] % mod;
    }
    
    const numsPower = new Array(n);
    for (let i = 0; i < n; i++) {
        numsPower[i] = new Array(m + 1).fill(1n);
        for (let j = 1; j <= m; j++) {
            numsPower[i][j] = numsPower[i][j - 1] * BigInt(nums[i]) % mod;
        }
    }

    const f = new Array(n);
    for (let i = 0; i < n; i++) {
        f[i] = new Array(m + 1);
        for (let j = 0; j <= m; j++) {
            f[i][j] = new Array(m * 2 + 1);
            for (let p = 0; p <= m * 2; p++) {
                f[i][j][p] = new Array(k + 1).fill(0n);
            }
        }
    }
    
    for (let j = 0; j <= m; j++) {
        f[0][j][j][0] = numsPower[0][j] * ifac[j] % mod;
    }
    
    for (let i = 0; i + 1 < n; i++) {
        for (let j = 0; j <= m; j++) {
            for (let p = 0; p <= m * 2; p++) {
                for (let q = 0; q <= k; q++) {
                    if (f[i][j][p][q] === 0n) {
                        continue;
                    }
                    const q2 = (p % 2) + q;
                    if (q2 > k) {
                        break;
                    }
                    for (let r = 0; r + j <= m; r++) {
                        const p2 = Math.floor(p / 2) + r;
                        if (p2 > m * 2) {
                            continue;
                        }
                        f[i + 1][j + r][p2][q2] = 
                            (f[i + 1][j + r][p2][q2] + 
                                f[i][j][p][q] * numsPower[i + 1][r] % mod * ifac[r] % mod) % mod;
                    }
                }
            }
        }
    }
    
    let res = 0n;
    for (let p = 0; p <= m * 2; p++) {
        for (let q = 0; q <= k; q++) {
            if (popCount(p) + q === k) {
                res = (res + f[n - 1][m][p][q] * fac[m] % mod) % mod;
            }
        }
    }
    return Number(res);
};

const popCount = (x) => {
    let count = 0;
    while (x > 0) {
        count += x & 1;
        x >>= 1;
    }
    return count;
}

const quickmul = (x, y, mod) => {
    let res = 1n;
    let cur = x % mod;
    while (y > 0) {
        if ((y & 1n) == 1n) {
            res = res * cur % mod;
        }
        y >>= 1n;
        cur = cur * cur % mod;
    }
    return res;
}
```

```TypeScript
function magicalSum(m: number, k: number, nums: number[]): number {
    const n = nums.length;
    const mod = 1000000007n;
    
    const fac: bigint[] = new Array(m + 1).fill(1n);
    for (let i = 1; i <= m; i++) {
        fac[i] = fac[i - 1] * BigInt(i) % mod;
    }
    
    const ifac: bigint[] = new Array(m + 1).fill(1n);
    for (let i = 2; i <= m; i++) {
        ifac[i] = quickmul(BigInt(i), mod - 2n, mod);
    }
    for (let i = 2; i <= m; i++) {
        ifac[i] = ifac[i - 1] * ifac[i] % mod;
    }
    
    const numsPower: bigint[][] = new Array(n);
    for (let i = 0; i < n; i++) {
        numsPower[i] = new Array(m + 1).fill(1n);
        for (let j = 1; j <= m; j++) {
            numsPower[i][j] = numsPower[i][j - 1] * BigInt(nums[i]) % mod;
        }
    }

    const f: bigint[][][][] = new Array(n);
    for (let i = 0; i < n; i++) {
        f[i] = new Array(m + 1);
        for (let j = 0; j <= m; j++) {
            f[i][j] = new Array(m * 2 + 1);
            for (let p = 0; p <= m * 2; p++) {
                f[i][j][p] = new Array(k + 1).fill(0n);
            }
        }
    }
    
    for (let j = 0; j <= m; j++) {
        f[0][j][j][0] = numsPower[0][j] * ifac[j] % mod;
    }
    
    for (let i = 0; i + 1 < n; i++) {
        for (let j = 0; j <= m; j++) {
            for (let p = 0; p <= m * 2; p++) {
                for (let q = 0; q <= k; q++) {
                    if (f[i][j][p][q] === 0n) {
                        continue;
                    }
                    const q2 = (p % 2) + q;
                    if (q2 > k) {
                        break;
                    }
                    for (let r = 0; r + j <= m; r++) {
                        const p2 = Math.floor(p / 2) + r;
                        if (p2 > m * 2) {
                            break;
                        }
                        f[i + 1][j + r][p2][q2] = 
                            (f[i + 1][j + r][p2][q2] + 
                                f[i][j][p][q] * numsPower[i + 1][r] % mod * ifac[r] % mod) % mod;
                    }
                }
            }
        }
    }
    
    let res = 0n;
    for (let p = 0; p <= m * 2; p++) {
        for (let q = 0; q <= k; q++) {
            if (bitCount(p) + q === k) {
                res = (res + f[n - 1][m][p][q] * fac[m] % mod) % mod;
            }
        }
    }
    return Number(res);
};

function quickmul(x: bigint, y: bigint, mod: bigint): bigint {
    let res = 1n;
    let cur = x % mod;
    while (y > 0n) {
        if (y & 1n) {
            res = res * cur % mod;
        }
        y >>= 1n;
        cur = cur * cur % mod;
    }
    return res;
}

function bitCount(n: number): number {
    let count = 0;
    while (n > 0) {
        count += n & 1;
        n >>= 1;
    }
    return count;
}
```

```Rust
impl Solution {
    pub fn magical_sum(m: i32, k: i32, nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let m = m as usize;
        let k = k as usize;
        let mod_val = 1_000_000_007u64;
        
        fn quickmul(mut x: u64, mut y: u64, mod_val: u64) -> u64 {
            let mut res = 1;
            let mut cur = x % mod_val;
            while y > 0 {
                if y & 1 == 1 {
                    res = res * cur % mod_val;
                }
                y >>= 1;
                cur = cur * cur % mod_val;
            }
            res
        }

        let mut fac = vec![0u64; m + 1];
        fac[0] = 1;
        for i in 1..=m {
            fac[i] = fac[i - 1] * i as u64 % mod_val;
        }

        let mut ifac = vec![0u64; m + 1];
        ifac[0] = 1;
        ifac[1] = 1;
        for i in 2..=m {
            ifac[i] = quickmul(i as u64, mod_val - 2, mod_val);
        }
        for i in 2..=m {
            ifac[i] = ifac[i - 1] * ifac[i] % mod_val;
        }

        let mut nums_power = vec![vec![0u64; m + 1]; n];
        for i in 0..n {
            nums_power[i][0] = 1;
            let num = nums[i] as u64 % mod_val;
            for j in 1..=m {
                nums_power[i][j] = nums_power[i][j - 1] * num % mod_val;
            }
        }

        let mut f = vec![vec![vec![vec![0u64; k + 1]; m * 2 + 1]; m + 1]; n];
        for j in 0..=m {
            f[0][j][j][0] = nums_power[0][j] * ifac[j] % mod_val;
        }

        for i in 0..n - 1 {
            for j in 0..=m {
                for p in 0..=m * 2 {
                    for q in 0..=k {
                        let current = f[i][j][p][q];
                        let q2 = (p % 2) as usize + q;
                        if q2 > k {
                            break;
                        }
                        
                        for r in 0..=(m - j) {
                            let p2 = (p / 2) as usize + r;
                            let add_val = current * nums_power[i + 1][r] % mod_val * ifac[r] % mod_val;
                            f[i + 1][j + r][p2][q2] = (f[i + 1][j + r][p2][q2] + add_val) % mod_val;
                        }
                    }
                }
            }
        }

        let mut res = 0u64;
        for p in 0..=m * 2 {
            for q in 0..=k {
                if p.count_ones() as usize + q == k {
                    res = (res + f[n - 1][m][p][q] * fac[m] % mod_val) % mod_val;
                }
            }
        }

        res as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm^3k)$，其中 $n$ 是数组 $nums$ 的长度，$m$ 是序列 $seq$ 的长度，$k$ 是限制的置位数。$f(i,j,p,q)$，参数的取值为 $i<n$，$j\le m$，$p\le 2m$，$q\le k$。
- 空间复杂度：$O(nm^2k)$。
