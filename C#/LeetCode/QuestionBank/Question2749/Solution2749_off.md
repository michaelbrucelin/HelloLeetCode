### [得到整数零需要执行的最少操作数](https://leetcode.cn/problems/minimum-operations-to-make-the-integer-zero/solutions/3764854/de-dao-zheng-shu-ling-xu-yao-zhi-xing-de-wztd/)

#### 方法一：枚举

**思路与算法**

我们可以从 $1$ 开始枚举操作数 $k$ 的值，每当枚举到一个数的时候，判断当前操作次数是否可以使 $num_1$ 等于 $0$，如果可以，则返回当前 $k$ 值。

假设操作 $k$ 次，那么相当于 $num_1$ 要减去 $k$ 个 $num_2$，然后判断剩下的数字能否由 $k$ 个 $2^i$ 组成，这里 $k$ 个 $i$ 不一定要相同。令 $x=num_1-k\times num_2$，只需判断 $x$ 能否由 $k$ 个 $2^i$ 组成。

设 $x$ 二进制表示中 $1$ 的个数为 $f(x)$。要使当操作次数 $k$ 成立，必须满足以下条件：

- $k\le x$，这是 $k$ 的上限。当 $k>x$ 时，即使是 $k$ 个 $20$ 也满足不了。
- $k\ge f(x)$，这是 $k$ 的下限。我们至少需要 $f(x)$ 个 $2^i$ 才能组成 $x$。当然可以多于 $f(x)$ 个 $2^i$，因为两个 $2^{i-1}$ 可以组成 $2^i$。

当且仅当 $f(x)\le k\le x$ 成立，$k$ 有效。

接下来继续观察 $x$，当 $k=0$ 时，$x>k$，且 $x$ 随着 $k$ 的增加而单调递减。因此在增加 $k$ 时，如果出现了 $x<k$ 的情况，随着 $k$ 继续增大，$x<k$ 始终满足。因此在第一次出现 $x<k$ 时，我们就可以判定此题无解，提前返回 $-1$。

```Python
class Solution:
    def makeTheIntegerZero(self, num1: int, num2: int) -> int:
        k = 1
        while True:
            x = num1 - num2 * k
            if x < k:
                return -1
            if k >= x.bit_count():
                return k
            k += 1
```

```C++
class Solution {
public:
    int makeTheIntegerZero(int num1, int num2) {
        int k = 1;
        while (true) {
            long long x = num1 - static_cast<long long>(num2) * k;
            if (x < k) {
                return -1;
            }
            if (k >= __builtin_popcountll(x)) {
                return k;
            }
            k++;
        }
    }
};
```

```Java
class Solution {
    public int makeTheIntegerZero(int num1, int num2) {
        int k = 1;
        while (true) {
            long x = num1 - (long) num2 * k;
            if (x < k) {
                return -1;
            }
            if (k >= Long.bitCount(x)) {
                return k;
            }
            k++;
        }
    }
}
```

```CSharp
public class Solution {
    public int MakeTheIntegerZero(int num1, int num2) {
        int k = 1;
        while (true) {
            long x = num1 - (long) num2 * k;
            if (x < k) {
                return -1;
            }
            if (k >= BitCount(x)) {
                return k;
            }
            k++;
        }
    }
    
    private int BitCount(long n) {
        int count = 0;
        while (n != 0) {
            count++;
            n &= (n - 1);
        }
        return count;
    }
}
```

```Go
func makeTheIntegerZero(num1 int, num2 int) int {
    k := 1
    for {
        x := int64(num1) - int64(num2) * int64(k)
        if x < int64(k) {
            return -1
        }
        if k >= bitCount(x) {
            return k
        }
        k++
    }
}

func bitCount(n int64) int {
    count := 0
    for n != 0 {
        count++
        n &= n - 1
    }
    return count
}
```

```C
int makeTheIntegerZero(int num1, int num2) {
    int k = 1;
    while (1) {
        long long x = (long long)num1 - (long long)num2 * k;
        if (x < k) {
            return -1;
        }
        if (k >= __builtin_popcountll(x)) {
            return k;
        }
        k++;
    }
}
```

```JavaScript
var makeTheIntegerZero = function(num1, num2) {
    let k = 1;
    while (true) {
        let x = BigInt(num1) - BigInt(num2) * BigInt(k);
        if (x < BigInt(k)) {
            return -1;
        }
        if (k >= bitCount(x)) {
            return k;
        }
        k++;
    }
};

function bitCount(n) {
    let count = 0;
    while (n !== 0n) {
        count++;
        n &= n - 1n;
    }
    return count;
}
```

```TypeScript
function makeTheIntegerZero(num1: number, num2: number): number {
    let k = 1;
    while (true) {
        let x: bigint = BigInt(num1) - BigInt(num2) * BigInt(k);
        if (x < BigInt(k)) {
            return -1;
        }
        if (k >= bitCount(x)) {
            return k;
        }
        k++;
    }
}

function bitCount(n: bigint): number {
    let count = 0;
    while (n !== 0n) {
        count++;
        n &= n - 1n;
    }
    return count;
}
```

```Rust
impl Solution {
    pub fn make_the_integer_zero(num1: i32, num2: i32) -> i32 {
        let mut k: i64 = 1;
        loop {
            let x: i64 = num1 as i64 - num2 as i64 * k;
            if x < k {
                return -1;
            }
            if k >= x.count_ones() as i64 {
                return k as i32;
            }
            k += 1;
        }
    }
}
```

**复杂度分析**

- 时间复杂度：时间复杂度推导比较复杂，大致在对数复杂度数量级。
- 空间复杂度：$O(1)$。
