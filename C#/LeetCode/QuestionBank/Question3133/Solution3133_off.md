### [数组最后一个元素的最小值](https://leetcode.cn/problems/minimum-array-end/solutions/2885445/shu-zu-zui-hou-yi-ge-yuan-su-de-zui-xiao-4tbz/)

#### 方法一：位运算

**思路与算法**

根据 $AND$ 运算的性质可以知道，$0 \& 1 = 0,1 \& 1 = 1$，由于数组中所有元素按位 $AND$ 的结果为 $x$，因此对于 $x$ 二进制表示为 $1$ 的位，则数组中的所有元素同样的位也为一定为 $1$。由于数组中所有的元素在 $x$ 二进制为 $1$ 的位一定为 $1$，此时只能其余为 $0$ 的位进行填充使得 $AND$ 运算的结果为 $x$，通过填充这些二进制位凑出第 $n$ 小的自然数且满足 $AND$ 运算结果为 $0$。

例如 $x = 1\underline{0}1\underline{00}1\underline{00}_2$，此时我们需要在二进制位为 $0$ 的位进行任意填充。首先将这些位全部填为 $0$，则此时构成的最小的整数为 $nums[0] = x$, 这样即可保证生成的数组中的任意元素 $nums[i] \& nums[0] = x$；其次由于题目要求元素严递增，依次在这些位置按照从小到大填充上数字 $1,2,3,\cdots,n-1$，刚好凑成 $n$ 个元素的正整数。

$$1\underline{0}1\underline{00}1\underline{00}_2,1\underline{0}1\underline{00}1\underline{0}1_2,1\underline{0}1\underline{00}11\underline{0}_2,1\underline{0}1\underline{00}111_2,\cdots$$

此时数组中的最大值即在 $x$ 二进制为 $0$ 的位上填充 $n-1$，返回最终填充结果即可。由于 $n$ 的二进制有 $\lfloor log_2n \rfloor$ 位，$x$ 的二进制位有 $\lfloor log_2x \rfloor$，此时返回结果的二进制最多有 $\lfloor log_2n \rfloor + \lfloor log_2x \rfloor$ 位，因此最多只需填充 $\lfloor log_2n \rfloor + \lfloor log_2x \rfloor$ 位即可。

**代码**

```C++
class Solution {
public:
    long long minEnd(int n, int x) {
        int bitCount = 64 - __builtin_clz(n) - __builtin_clz(x);
        long long res = x;
        long long m = n - 1;
        int j = 0;
        for (int i = 0; i < bitCount; ++i) {
            if (((res >> i) & 1) == 0) {
                if ((m >> j) & 1) {
                    res |= (1LL << i);
                }
                j++;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public long minEnd(int n, int x) {
        int bitCount = 128 - Long.numberOfLeadingZeros(n) - Long.numberOfLeadingZeros(x);
        long res = x;
        long m = n - 1;
        int j = 0;
        for (int i = 0; i < bitCount; ++i) {
            if (((res >> i) & 1) == 0) {
                if (((m >> j) & 1) == 1) {
                    res |= (1L << i);
                }
                j++;
            }
        }
        return res;
    }
}
```

```Go
func minEnd(n int, x int) int64 {
    bitCount := 128 - bits.LeadingZeros(uint(n)) - bits.LeadingZeros(uint(x))
    res := int64(x)
    m := int64(n) - 1
    j := 0
    for i := 0; i < bitCount; i++ {
        if res & (1 << i) == 0 {
            if m & (1 << j) != 0 {
                res |= 1 << i
            }
            j++
        }
    }
    return res
}
```

```Python
class Solution:
    def minEnd(self, n: int, x: int) -> int:
        bitCount = n.bit_length() + x.bit_count()
        res, j = x, 0
        m = n - 1
        for i in range(bitCount):
            if ((res >> i) & 1) == 0:
                if ((m >> j) & 1) != 0:
                    res |= (1 << i)
                j += 1
        return res
```

```C
long long minEnd(int n, int x) {
    int bitCount = 64 - __builtin_clz(n) - __builtin_clz(x);
    long long res = x;
    long long m = n - 1;
    int j = 0;
    for (int i = 0; i < bitCount; ++i) {
        if (((res >> i) & 1) == 0) {
            if ((m >> j) & 1) {
                res |= (1LL << i);
            }
            j++;
        }
    }
    return res;
}
```

```JavaScript
var minEnd = function(n, x) {
    const bitCount = 64 - leadingZeros(n) - leadingZeros(x);
    let res = BigInt(x);
    let j = 0;
    n--;
    for (let i = 0; i < bitCount; ++i) {
        if (((res >> BigInt(i)) & 1n) === 0n) {
            if (((BigInt(n) >> BigInt(j)) & 1n) != 0n) {
                res |= 1n << BigInt(i);
            }
            j++;
        }
    }
    return Number(res);
};

function leadingZeros(x) {
    return x === 0 ? 32 : 31 - Math.floor(Math.log2(x));
}
```

```TypeScript
function minEnd(n: number, x: number): number {
    const bitCount = 64 - leadingZeros(n) - leadingZeros(x);
    let res = BigInt(x);
    let j = 0;
    n--;
    for (let i = 0; i < bitCount; ++i) {
        if (((res >> BigInt(i)) & 1n) === 0n) {
            if (((BigInt(n) >> BigInt(j)) & 1n) != 0n) {
                res |= 1n << BigInt(i);
            }
            j++;
        }
    }
    return Number(res);
};

function leadingZeros(x) {
    return x === 0 ? 32 : 31 - Math.floor(Math.log2(x));
}
```

```Rust
impl Solution {
    pub fn min_end(n: i32, x: i32) -> i64 {
        let bit_count = 64 - n.leading_zeros() - x.leading_zeros();
        let mut res = x as i64;
        let mut j = 0;
        let mut n = (n - 1) as i64;
        for i in 0..bit_count {
            if ((res >> i) & 1) == 0 {
                if ((n >> j) & 1) != 0 {
                    res |= 1 << i;
                }
                j += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(logn+logx)$，其中 $n,x$ 表示给定的整数。
- 空间复杂度：$O(1)$。
