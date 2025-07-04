### [找出第 K 个字符 II](https://leetcode.cn/problems/find-the-k-th-character-in-string-game-ii/solutions/3708679/zhao-chu-di-k-ge-zi-fu-ii-by-leetcode-so-kx1d/)

#### 方法一：迭代

**思路及解法**

本题大体思路与「[找出第 K 个字符 I](https://leetcode.cn/problems/find-the-k-th-character-in-string-game-i)」相同，唯一的不同点在于需要明确当前的 $k$ 所在位置处于第几次操作：

不妨设 $k=2^t+a$，若 $a=0$，则当前的 $k$ 处于第 $t-1$ 次操作中；若 $a=0$，则当前的 $k$ 处于第 $t$ 次操作中。

这个结论可以很容易的通过小数据量的模拟得出。

在确定了当前 $k$ 所在的操作次数后，便可以通过题目所给的 $operations$ 数组来判断是否对答案进行累加，若 $operations[t]=1$，则进行累加，反之则不进行累加。

**代码**

```C++
class Solution {
public:
    char kthCharacter(long long k, vector<int>& operations) {
        int ans = 0;
        int t;
        while (k != 1) {
            t = __lg(k);
            if (((long long)1 << t) == k) {
                t--;
            }
            k = k - ((long long)1 << t);
            if (operations[t]) {
                ans++;
            }
        }
        return 'a' + (ans % 26);
    }
};
```

```Java
class Solution {
    public char kthCharacter(long k, int[] operations) {
        int ans = 0;
        int t;
        while (k != 1) {
            t = 63 - Long.numberOfLeadingZeros(k);
            if ((1L << t) == k) {
                t--;
            }
            k = k - (1L << t);
            if (operations[t] != 0) {
                ans++;
            }
        }
        return (char) ('a' + (ans % 26));
    }
}
```

```CSharp
public class Solution {
    public char KthCharacter(long k, int[] operations) {
        int ans = 0;
        int t;
        while (k != 1) {
            t = (int)Math.Log(k, 2);
            if ((1L << t) == k) {
                t--;
            }
            k -= (1L << t);
            if (operations[t] != 0) {
                ans++;
            }
        }
        return (char)('a' + (ans % 26));
    }
}
```

```Go
func kthCharacter(k int64, operations []int) byte {
    ans := 0
    for k != 1 {
        t := bits.Len64(uint64(k)) - 1
        if (1 << t) == k {
            t--
        }
        k -= (1 << t)
        if operations[t] != 0 {
            ans++
        }
    }
    return byte('a' + (ans % 26))
}
```

```Python
class Solution:
    def kthCharacter(self, k: int, operations: List[int]) -> str:
        ans = 0
        while k != 1:
            t = k.bit_length() - 1
            if (1 << t) == k:
                t -= 1
            k -= (1 << t)
            if operations[t]:
                ans += 1
        return chr(ord('a') + (ans % 26))
```

```C
char kthCharacter(long long k, int* operations, int operationsSize) {
    int ans = 0;
    int t;
    while (k != 1) {
        t = 63 - __builtin_clzll(k);
        if ((1LL << t) == k) {
            t--;
        }
        k = k - (1LL << t);
        if (operations[t]) {
            ans++;
        }
    }
    return 'a' + (ans % 26);
}
```

```JavaScript
var kthCharacter = function(k, operations) {
    let ans = 0;
    while (k !== 1) {
        let t = Math.floor(Math.log2(k));
        if (Number(1n << BigInt(t)) === k) {
            t--;
        }
        k -= Number(1n << BigInt(t));
        if (operations[t]) {
            ans++;
        }
    }
    return String.fromCharCode('a'.charCodeAt(0) + (ans % 26));
}
```

```TypeScript
function kthCharacter(k: number, operations: number[]): string {
    let ans = 0;
    while (k !== 1) {
        let t = Math.floor(Math.log2(k));
        if (Number(1n << BigInt(t)) === k) {
            t--;
        }
        k -= Number(1n << BigInt(t));
        if (operations[t]) {
            ans++;
        }
    }
    return String.fromCharCode('a'.charCodeAt(0) + (ans % 26));
}
```

```Rust
impl Solution {
    pub fn kth_character(k: i64, operations: Vec<i32>) -> char {
        let mut ans = 0;
        let mut k = k;
        while k != 1 {
            let t = 63 - k.leading_zeros();
            let t = if (1 << t) == k { t - 1 } else { t };
            k -= 1 << t;
            if operations[t as usize] != 0 {
                ans += 1;
            }
        }
        (b'a' + (ans % 26) as u8) as char
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log k)$, 仅与 $k$ 的二进制位数有关。
- 空间复杂度：$O(1)$，申请了常数个变量。

#### 方法二：数学

**思路及解法**

换一个思考方式，如果从原始字符串的下一位开始计算，到达第 $k$ 位字符等同于向后移动了 $k-1$ 个字符。

将 $k-1$ 写成二进制的形式，当第 $t$ 位为 $1$ 时，正好对应向后移动 $2^{t-1}$ 位，等同于第 $t-1$ 次操作所得效果。

因此我们只需要注意 $k-1$ 所表示的二进制数中 $1$ 的所在位置，当 $1$ 所在位置对应的 $operations$ 的值为 $1$ 时便对答案进行累加即可。

**代码**

```C++
class Solution {
public:
    char kthCharacter(long long k, vector<int>& operations) {
        int ans = 0;
        k--;
        for (int i = __lg(k); i >= 0; i--) {
            if (k >> i & 1) {
                ans += operations[i];
            }
        }
        return 'a' + (ans % 26);
    }
};
```

```Java
class Solution {
    public char kthCharacter(long k, int[] operations) {
        int ans = 0;
        k--;
        for (int i = 63 - Long.numberOfLeadingZeros(k); i >= 0; i--) {
            if ((k >> i & 1) == 1) {
                ans += operations[i];
            }
        }
        return (char) ('a' + (ans % 26));
    }
}
```

```CSharp
public class Solution {
    public char KthCharacter(long k, int[] operations) {
        int ans = 0;
        k--;
        for (int i = (int)Math.Log(k, 2); i >= 0; i--) {
            if ((k >> i & 1) == 1) {
                ans += operations[i];
            }
        }
        return (char)('a' + (ans % 26));
    }
}
```

```Go
func kthCharacter(k int64, operations []int) byte {
    ans := 0
    k--
    for i := bits.Len64(uint64(k)) - 1; i >= 0; i-- {
        if (k >> i) & 1 == 1 {
            ans += operations[i]
        }
    }
    return byte('a' + (ans % 26))
}
```

```Python
class Solution:
    def kthCharacter(self, k: int, operations: List[int]) -> str:
        ans = 0
        k -= 1
        for i in range(k.bit_length() - 1, -1, -1):
            if (k >> i) & 1:
                ans += operations[i]
        return chr(ord('a') + (ans % 26))
```

```C
char kthCharacter(long long k, int* operations, int operationsSize) {
    int ans = 0;
    k--;
    for (int i = (int)log2(k); i >= 0; i--) {
        if ((k >> i) & 1) {
            ans += operations[i];
        }
    }
    return 'a' + (ans % 26);
}
```

```JavaScript
var kthCharacter = function(k, operations) {
    let ans = 0;
    k--;
    for (let i = Math.floor(Math.log2(k)); i >= 0; i--) {
        if ((BigInt(k) >> BigInt(i)) & 1n) {
            ans += operations[i];
        }
    }
    return String.fromCharCode('a'.charCodeAt(0) + (ans % 26));
};
```

```TypeScript
function kthCharacter(k: number, operations: number[]): string {
    let ans = 0;
    k--;
    for (let i = Math.floor(Math.log2(k)); i >= 0; i--) {
        if ((BigInt(k) >> BigInt(i)) & 1n) {
            ans += operations[i];
        }
    }
    return String.fromCharCode('a'.charCodeAt(0) + (ans % 26));
};
```

```Rust
impl Solution {
    pub fn kth_character(k: i64, operations: Vec<i32>) -> char {
        let mut ans = 0;
        let mut k = k - 1;
        for i in (0..64 - k.leading_zeros()).rev() {
            if (k >> i) & 1 == 1 {
                ans += operations[i as usize];
            }
        }
        (b'a' + (ans % 26) as u8) as char
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log k)$, 仅与 $k$ 的二进制位数有关。
- 空间复杂度：$O(1)$，申请了常数个变量。
