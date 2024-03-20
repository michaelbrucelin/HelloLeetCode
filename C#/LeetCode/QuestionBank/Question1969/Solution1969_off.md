### [数组元素的最小非零乘积](https://leetcode.cn/problems/minimum-non-zero-product-of-the-array-elements/solutions/2688955/shu-zu-yuan-su-de-zui-xiao-fei-ling-chen-xti0/)

#### 方法一：贪心

##### 思路与算法

我们先思考一个简单的问题，假设给定三个正整数 $a,b,c$，满足 $a < b < c$，此时需要将某个数缩小 $1$，另外一个数增加 $1$，使得 $abc$ 最小，如何选择才是最优选择?

缩小时优先缩小最小的元素：当选择 $a$ 缩小 $1$ 时，此时三者乘积为 $(a-1)bc$，整体较 $abc$ 缩小了 $bc$；当选择缩小 $c$ 时，三者乘积为 $ab(c-1)$，整体较 $abc$ 缩小了 $ab$，此时 $ab < bc$，因此缩小时优先缩小最小的元素；

增加时优先增加最大的元素：缩小 $a$ 然后选择某个元素进行增加，当选择 $b$ 增加 $1$ 时，此时三者乘积为 $(a-1)(b + 1)c$，整体较 $(a-1)bc$ 增加了 $(a-1)c$；当选择增加 $c$ 时，三者乘积为 $(a-1)b(c+1)$，整体较 $(a-1)bc$ 增加了 $(a-1)b$，此时 $(a-1)b < (a-1)c$，因此增加时优先增加最大的元素；

回到本题，两个数在进行相同的位交换时，本质即将一个元素缩小 $2^k$，另外一个元素增加 $2^k$。根据上述分析，我们可以知道一种贪心思路：进行相同位交换时，优先缩小数组中最小的元素，再增加数组中最大的元素。设当前数组为：

$$[1,2,3,\cdots,2^p-2,2^p-1]$$

缩小时按照从小到大考虑每个元素：

首先考虑 $1$，此时需要将 $1$ 减少 $1$，此时从右向左依次考虑最大的元素，由于 $2^p-1$ 每一位均为 $1$ 无法再增加；接着考虑 $2^p-2$，此时将最低位变为 $1$，数组变为：$[0,2,3,\cdots, 2^p-3,2^p-1,2^p-1]$；

接着考虑 $2$，此时需要将 $2$ 减少 $2$，此时从右向左依次考虑最大的元素，由于 $2^p-1$ 每一位均为 $1$ 无法再增加；接着考虑 $2^p-3$，此时将第 $2$ 位变为 $1$，数组变为：$[0,0,3,\cdots, 2^p-1,2^p-1,2^p-1]$；

然后接着考虑 $3, 4, 5, \cdots$，按照上述最优变换原则，数组最终变换为 $[0,0,0,\cdots,2^p-1,\cdots, 2^p-1]$，由于最小乘积不能为 $0$，所有元素均不能为 $0$，此时则需要从所有 $2^p-1$ 中移除最低位的 $1$ 补充到 $0$ 上，此时数组最终变换为 $[\underbrace{1,1,1,\cdots,1}_{2^{p-1}-1},\underbrace{2^p-2,\cdots,2^p-2}_{2^{p-1}-1},2^p-1]$，最终的返回值即为 $(2^p-1)\times(2^p-2)^{2^{p-1}-1}$；

由于计算时幂数较大，此时需要用到快速幂，可以参考「[计算快速幂](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fmath%2Fbinary-exponentiation%2F)」的相关资料。

##### 代码

```c++
class Solution {
public:
    long long fastPow(long long x, long long n, long long mod) {
        long long res = 1;
        for (; n != 0; n >>= 1) {
            if (n & 1) {
                res = res * x % mod;
            }
            x = x * x % mod;
        }
        return res;
    }
    
    int minNonZeroProduct(int p) {
        if (p == 1) {
            return 1;
        }
        long long mod = 1e9 + 7;
        long long x = fastPow(2, p, mod) - 1;
        long long y = (long long) 1 << (p - 1);
        return fastPow(x - 1, y - 1, mod) * x % mod;
    }
};
```

```java
class Solution {
    public int minNonZeroProduct(int p) {
        if (p == 1) {
            return 1;
        }
        long mod = 1000000007;
        long x = fastPow(2, p, mod) - 1;
        long y = (long) 1 << (p - 1);
        return (int) (fastPow(x - 1, y - 1, mod) * x % mod);
    }

    public long fastPow(long x, long n, long mod) {
        long res = 1;
        for (; n != 0; n >>= 1) {
            if ((n & 1) != 0) {
                res = res * x % mod;
            }
            x = x * x % mod;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MinNonZeroProduct(int p) {
        if (p == 1) {
            return 1;
        }
        long mod = 1000000007;
        long x = FastPow(2, p, mod) - 1;
        long y = (long) 1 << (p - 1);
        return (int) (FastPow(x - 1, y - 1, mod) * x % mod);
    }

    public long FastPow(long x, long n, long mod) {
        long res = 1;
        for (; n != 0; n >>= 1) {
            if ((n & 1) != 0) {
                res = res * x % mod;
            }
            x = x * x % mod;
        }
        return res;
    }
}
```

```c
long long fastPow(long long x, long long n, long long mod) {
    long long res = 1;
    for (; n != 0; n >>= 1) {
        if (n & 1) {
            res = res * x % mod;
        }
        x = x * x % mod;
    }
    return res;
}

int minNonZeroProduct(int p) {
    if (p == 1) {
        return 1;
    }
    long long mod = 1e9 + 7;
    long long x = fastPow(2, p, mod) - 1;
    long long y = (long long) 1 << (p - 1);
    return fastPow(x - 1, y - 1, mod) * x % mod;
}
```

```python
class Solution:
    def minNonZeroProduct(self, p: int) -> int:
        if p == 1:
            return 1
        mod = 10**9 + 7
        return  pow(2 ** p - 2, 2 ** (p - 1) - 1, mod) * (2 ** p - 1) % mod
```

```go
func minNonZeroProduct(p int) int {
    if p == 1 {
        return 1
    }
    mod := int64(1e9 + 7)
    x := fastPow(2, int64(p), mod) - 1
    y := int64(1) << uint(p - 1)
    return int(fastPow(x - 1, y - 1, mod) * x % mod)
}

func fastPow(x, n, mod int64) int64 {
    res := int64(1)
    for n != 0 {
        if n & 1 == 1 {
            res = (res * x) % mod
        }
        x = (x * x) % mod
        n >>= 1
    }
    return res
}
```

```javascript
var minNonZeroProduct = function(p) {
    if (p === 1) {
        return 1;
    }
    const mod = BigInt(1e9 + 7);
    const x = fastpow(2n, BigInt(p), mod) - 1n;
    const y = 1n << BigInt(p - 1);
    return fastpow(x - 1n, y - 1n, mod) * x % mod;
};

function fastpow(x, n, mod) {
    let res = BigInt(1);
    while (n > 0) {
        if (n & 1n) {
            res = (res * x) % mod;
        }
        x = (x * x) % mod;
        n >>= 1n;
    }
    return res;
}
```

```typescript
function minNonZeroProduct(p: number): number {
    if (p === 1) {
        return 1;
    }
    const mod = BigInt(1e9 + 7);
    const x = fastpow(BigInt(2), BigInt(p), mod) - BigInt(1);
    const y = BigInt(1) << BigInt(p - 1);
    return Number((fastpow(x - BigInt(1), y - BigInt(1), mod) * x) % mod);
};

const fastpow = (x: bigint, n: bigint, mod: bigint): bigint => {
    let res: bigint = BigInt(1);
    while (n > BigInt(0)) {
        if (n & BigInt(1)) {
            res = (res * x) % mod;
        }
        x = (x * x) % mod;
        n >>= BigInt(1);
    }
    return res;
};
```

```rust
function minNonZeroProduct(p: number): number {
    if (p === 1) {
        return 1;
    }
    const mod = BigInt(1e9 + 7);
    const x = fastpow(BigInt(2), BigInt(p), mod) - BigInt(1);
    const y = BigInt(1) << BigInt(p - 1);
    return Number((fastpow(x - BigInt(1), y - BigInt(1), mod) * x) % mod);
};

const fastpow = (x: bigint, n: bigint, mod: bigint): bigint => {
    let res: bigint = BigInt(1);
    while (n > BigInt(0)) {
        if (n & BigInt(1)) {
            res = (res * x) % mod;
        }
        x = (x * x) % mod;
        n >>= BigInt(1);
    }
    return res;
};
```

##### 复杂度分析

- 时间复杂度：$O(p)$，其中 $p$ 表示给定的数 $p$。利用快速幂求 $2$ 需要的时间刚好为 $O(p)$。
- 空间复杂度：$O(1)$。
