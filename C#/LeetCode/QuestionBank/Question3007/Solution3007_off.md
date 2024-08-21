### [价值和小于等于 K 的最大数字](https://leetcode.cn/problems/maximum-number-that-sum-of-the-prices-is-less-than-or-equal-to-k/solutions/2885442/jie-zhi-he-xiao-yu-deng-yu-k-de-zui-da-s-70ed/)

#### 方法一：二分查找

**思路**

记函数 $accumulatedPrice(num,x)$ 是 $num$ 的累加价值，那么这道题就要求解最大的 $num$，并且满足 $accumulatedPrice(num,x) \le k$。$num$ 越大，它的累加价值就越大，因此这题可以用二分查找来求解。

接下来我们需要正向求解 $accumulatedPrice(num,x)$。记函数 $accumulatedBitPrice(num,x)$ 来求解从 $1$ 到 $num$ 所有整数在二进制表示下在 $x$ 位置处设置位的数字之和。那么 $accumulatedPrice(num,x) = \sum_{k = 1}^n accumulatedBitPrice(num,k \times x)$，其中 $n$ 为 $n \times x$ 不超过 $num$ 二进制表示位数的最大值。

有了上述公式，我们只需要求解 $accumulatedBitPrice(num,x)$。从 $0$ 到 $num$，可以发现这一位的规律是一个循环，周期为 $2^x$，前半个周期的值均为 $0$，后半个周期的值均为 $1$。利用这一规律，可以比较容易计算 $accumulatedBitPrice(num,x)$。先计算周期长度，再计算其中完整的周期可以贡献多少个 $1$，再计算剩下不足一个周期可以贡献多少个 $1$。最后返回总和。

现在我们可以正向求解 $accumulatedPrice(num,x)$。唯一的问题就是需要确定二分查找的上界。我们需要确定一个数字，这个数字的累加价值一定是大于 $k$ 的。仍然按照上一段中提到的规律，如果只考虑在 $x$ 位置处设置位，那么一个长度为 $2^x$ 的周期的设置位和为 $2^{(x-1)}$，不妨令上界为 $(k+1) \times 2^x$，这样它的累加价值一定大于 $k$。上下界和二分查找的判断都确定后，就可以通过不停地正向计算并更新上下界来求出目标值，直到上下界收敛到一个值。

**代码**

```Python
class Solution:
    def findMaximumNumber(self, k: int, x: int) -> int:
        l, r = 1, (k + 1) << x
        while l < r:
            m = (l + r + 1) // 2
            if self.accumulatedPrice(x, m) > k:
                r = m - 1
            else:
                l = m
        return l

    def accumulatedPrice(self, x: int, num: int) -> int:
        res = 0
        length = len(bin(num)) - 2
        for i in range(x, length + 1, x):
            res += self.accumulatedBitPrice(i, num)
        return res

    def accumulatedBitPrice(self, x: int, num: int) -> int:
        period = 1 << x
        res = (period // 2) * (num // period)
        if num % period >= (period // 2):
            res += num % period - ((period // 2) - 1)
        return res
```

```Java
class Solution {
    public long findMaximumNumber(long k, int x) {
        long l = 1, r = (k + 1) << x;
        while (l < r) {
            long m = (l + r + 1) / 2;
            if (accumulatedPrice(x, m) > k) {
                r = m - 1;
            } else {
                l = m;
            }
        }
        return l;
    }

    public long accumulatedPrice(int x, long num) {
        long res = 0;
        int length = 64 - Long.numberOfLeadingZeros(num);
        for (int i = x; i <= length; i += x) {
            res += accumulatedBitPrice(i, num);
        }
        return res;
    }

    public long accumulatedBitPrice(int x, long num) {
        long period = 1L << x;
        long res = period / 2 * (num / period);
        if (num % period >= period / 2) {
            res += num % period - (period / 2 - 1);
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    long long findMaximumNumber(long long k, int x) {
        long long l = 1, r = (k + 1) << x;
        while (l < r) {
            long long m = (l + r + 1) / 2;
            if (accumulatedPrice(x, m) > k) {
                r = m - 1;
            } else {
                l = m;
            }
        }
        return l;
    }

    long long accumulatedBitPrice(int x, long long num) {
        long long period = 1LL << x;
        long long res = period / 2 * (num / period);
        if (num % period >= period / 2) {
            res += num % period - (period / 2 - 1);
        }
        return res;
    }

    long long accumulatedPrice(int x, long long num) {
        long long res = 0;
        int length = 64 - __builtin_clzll(num);
        for (int i = x; i <= length; i += x) {
            res += accumulatedBitPrice(i, num);
        }
        return res;
    }
};
```

```C
long long accumulatedBitPrice(int x, long long num) {
    long long period = 1LL << x;
    long long res = period / 2 * (num / period);
    if (num % period >= period / 2) {
        res += num % period - (period / 2 - 1);
    }
    return res;
}

long long accumulatedPrice(int x, long long num) {
    long long res = 0;
    int length = 64 - __builtin_clzll(num);
    for (int i = x; i <= length; i += x) {
        res += accumulatedBitPrice(i, num);
    }
    return res;
}

long long findMaximumNumber(long long k, int x) {
    long long l = 1, r = (k + 1) << x;
    while (l < r) {
        long long m = (l + r + 1) / 2;
        if (accumulatedPrice(x, m) > k) {
            r = m - 1;
        } else {
            l = m;
        }
    }
    return l;
}
```

```Go
func findMaximumNumber(k int64, x int) int64 {
    l, r := int64(1), (k + 1) << x
    for l < r {
        m := (l + r + 1) / 2
        if accumulatedPrice(x, m) > k {
            r = m - 1
        } else {
            l = m
        }
    }
    return l
}

func accumulatedBitPrice(x int, num int64) int64 {
    period := int64(1) << x
    res := period / 2 * (num / period)
    if num % period >= period / 2 {
        res += num % period - (period / 2 - 1)
    }
    return res
}

func accumulatedPrice(x int, num int64) int64 {
    res := int64(0)
    length := 64 - bits.LeadingZeros64(uint64(num))
    for i := x; i <= length; i += x {
        res += accumulatedBitPrice(i, num)
    }
    return res
}
```

```JavaScript
var findMaximumNumber = function(k, x) {
    let l = 1n, r = (BigInt(k) + 1n) << BigInt(x);
    while (l < r) {
        let m = (l + r + 1n) / 2n;
        if (accumulatedPrice(x, m) > k) {
            r = m - 1n;
        } else {
            l = m;
        }
    }
    return Number(l);
};

function accumulatedBitPrice(x, num) {
    const period = 1n << BigInt(x);
    let res = period / 2n * (num / period);
    if (num % period >= period / 2n) {
        res += num % period - (period / 2n - 1n);
    }
    return res;
}

function accumulatedPrice(x, num) {
    let res = 0n;
    const length = 64 - Math.clz32(Number(num >> 32n));
    for (let i = x; i <= length; i += x) {
        res += accumulatedBitPrice(i, num);
    }
    return res;
}
```

```TypeScript
function findMaximumNumber(k: number, x: number): number {
    let l = 1n, r = (BigInt(k) + 1n) << BigInt(x);
    while (l < r) {
        let m = (l + r + 1n) / 2n;
        if (accumulatedPrice(x, m) > k) {
            r = m - 1n;
        } else {
            l = m;
        }
    }
    return Number(l);
};

function accumulatedBitPrice(x: number, num: bigint): bigint {
    const period = 1n << BigInt(x);
    let res = period / 2n * (num / period);
    if (num % period >= period / 2n) {
        res += num % period - (period / 2n - 1n);
    }
    return res;
}

function accumulatedPrice(x: number, num: bigint): bigint {
    let res = 0n;
    const length = 64 - Math.clz32(Number(num >> 32n));
    for (let i = x; i <= length; i += x) {
        res += accumulatedBitPrice(i, num);
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn find_maximum_number(k: i64, x: i32) -> i64 {
        let (mut l, mut r) = (1i64, (k + 1) << x);
        while l < r {
            let m = (l + r + 1) / 2;
            if Self::accumulated_price(x, m) > k {
                r = m - 1;
            } else {
                l = m;
            }
        }
        return l;
    }

    fn accumulated_bit_price(x: i32, num: i64) -> i64 {
        let period = 1i64 << x;
        let mut res = period / 2 * (num / period);
        if num % period >= period / 2 {
            res += num % period - (period / 2 - 1);
        }
        return res;
    }

    fn accumulated_price(x: i32, num: i64) -> i64 {
        let mut res = 0i64;
        let length = 64 - num.leading_zeros();
        for i in (x..=length as i32).step_by(x as usize) {
            res += Self::accumulated_bit_price(i, num);
        }
        return res;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(x \times (log^2k))$。上界为 $(k+1) \times 2^x$，二分查找的次数为 $O(x \times logk)$，每次计算累加价值消耗 $O(logk)$。
- 空间复杂度：$O(1)$。
