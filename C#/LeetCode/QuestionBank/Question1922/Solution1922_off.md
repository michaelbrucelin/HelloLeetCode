### [统计好数字的数目](https://leetcode.cn/problems/count-good-numbers/solutions/857968/tong-ji-hao-shu-zi-de-shu-mu-by-leetcode-53jj/)

#### 方法一：快速幂

**思路与算法**

对于偶数下标处的数字，它可以为 $0,2,4,6,8$ 共计 $5$ 种，而长度为 $n$ 的数字字符串有 $\lfloor \dfrac{n+1}{2} \rfloor$ 个偶数下标，其中 \lfloor x \rfloor 表示对 $x$ 向下取整。

对于奇数下标处的数字，它可以为 $2,3,5,7$ 共计 4 种，而长度为 $n$ 的数字字符串有 $\lfloor \dfrac{n}{2} \rfloor$ 个奇数下标。

因此长度为 $n$ 的数字字符串中，好数字的总数即为：

$$5^{\lfloor \frac{n+1}{2} \rfloor} \cdot 4^{\lfloor \frac{n}{2} \rfloor}$$

在本题中，由于 $n$ 的取值最大可以到 $10^{15}$，如果通过普通的乘法运算直接求出上式中的幂，会超出时间限制，因此我们需要使用快速幂算法对幂的求值进行优化。

快速幂算法可以参考[「50. Pow(x, n)」的官方题解](https://leetcode-cn.com/problems/powx-n/solution/powx-n-by-leetcode-solution/)。

**代码**

```C++
class Solution {
private:
    static constexpr int mod = 1000000007;
    
public:
    int countGoodNumbers(long long n) {
        // 快速幂求出 x^y % mod
        auto quickmul = [](int x, long long y) -> int {
            int ret = 1, mul = x;
            while (y > 0) {
                if (y % 2 == 1) {
                    ret = (long long)ret * mul % mod;
                }
                mul = (long long)mul * mul % mod;
                y /= 2;
            }
            return ret;
        };
        
        return (long long)quickmul(5, (n + 1) / 2) * quickmul(4, n / 2) % mod;
    }
};
```

```Python
class Solution:
    def countGoodNumbers(self, n: int) -> int:
        mod = 10**9 + 7
        
        # 快速幂求出 x^y % mod
        def quickmul(x: int, y: int) -> int:
            ret, mul = 1, x
            while y > 0:
                if y % 2 == 1:
                    ret = ret * mul % mod
                mul = mul * mul % mod
                y //= 2
            return ret
            
        return quickmul(5, (n + 1) // 2) * quickmul(4, n // 2) % mod
```

```Java
class Solution {
    long mod = 1000000007;
    
    public int countGoodNumbers(long n) {
        return (int) (quickmul(5, (n + 1) / 2) * quickmul(4, n / 2) % mod);
    }

    // 快速幂求出 x^y % mod
    public long quickmul(int x, long y) {
        long ret = 1;
        long mul = x;
        while (y > 0) {
            if (y % 2 == 1) {
                ret = ret * mul % mod;
            }
            mul = mul * mul % mod;
            y /= 2;
        }

        return ret;
    }
}
```

```CSharp
public class Solution {
    long mod = 1000000007;

    public int CountGoodNumbers(long n) {
        return (int) (Quickmul(5, (n + 1) / 2) * Quickmul(4, n / 2) % mod);
    }

    // 快速幂求出 x^y % mod
    public long Quickmul(int x, long y) {
        long ret = 1;
        long mul = x;
        while (y > 0) {
            if (y % 2 == 1) {
                ret = ret * mul % mod;
            }
            mul = mul * mul % mod;
            y /= 2;
        }

        return ret;
    }
}
```

```Go
func countGoodNumbers(n int64) int {
    mod := int64(1000000007)

    // 快速幂求出 x^y % mod
    quickmul := func(x, y int64) int64 {
        ret := int64(1)
        mul := x
        for y > 0 {
            if y % 2 == 1 {
                ret = ret * mul % mod
            }
            mul = mul * mul % mod
            y /= 2
        }
        return ret
    }

    return int(quickmul(5, (n + 1) / 2) * quickmul(4, n / 2) % mod)
}
```

```C
#define MOD 1000000007

// 快速幂求出 x^y % mod
long long quickmul(int x, long long y) {
    long long ret = 1;
    long long mul = x;
    while (y > 0) {
        if (y % 2 == 1) {
            ret = (ret * mul) % MOD;
        }
        mul = (mul * mul) % MOD;
        y /= 2;
    }
    return ret;
}

int countGoodNumbers(long long n) {
    return (int)(quickmul(5, (n + 1) / 2) * quickmul(4, n / 2) % MOD);
}
```

```JavaScript
var countGoodNumbers = function(n) {
    const mod = 1000000007n;

    // 快速幂求出 x^y % mod
    function quickmul(x, y) {
        let ret = 1n;
        let mul = x;
        while (y > 0) {
            if (y % 2n === 1n) {
                ret = (ret * mul) % mod;
            }
            mul = (mul * mul) % mod;
            y = y / 2n;
        }
        return ret;
    }

    return Number(quickmul(5n, BigInt(n + 1) / 2n) * quickmul(4n, BigInt(n) / 2n) % mod);
};
```

```TypeScript
function countGoodNumbers(n: number): number {
    const mod: bigint = 1000000007n;

    // 快速幂求出 x^y % mod
    function quickmul(x: bigint, y: bigint): bigint {
        let ret: bigint = 1n;
        let mul: bigint = x;
        while (y > 0n) {
            if (y % 2n === 1n) {
                ret = (ret * mul) % mod;
            }
            mul = (mul * mul) % mod;
            y = y / 2n;
        }
        return ret;
    }

    return Number(quickmul(5n, BigInt(n + 1) / 2n) * quickmul(4n, BigInt(n) / 2n) % mod);
};
```

```Rust
const MOD: i64 = 1000000007;

impl Solution {
    pub fn count_good_numbers(n: i64) -> i32 {
        (Self::quickmul(5, (n + 1) / 2) * Self::quickmul(4, n / 2) % MOD) as i32
    }

    // 快速幂求出 x^y % mod
    fn quickmul(x: i32, mut y: i64) -> i64 {
        let mut ret = 1 as i64;
        let mut mul = x as i64;
        while y > 0 {
            if y % 2 == 1 {
                ret = ret * mul % MOD;
            }
            mul = mul * mul % MOD;
            y /= 2;
        }
        ret
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$。
- 空间复杂度：$O(1)$。
