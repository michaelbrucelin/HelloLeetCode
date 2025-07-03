### [找出第 K 个字符 I](https://leetcode.cn/problems/find-the-k-th-character-in-string-game-i/solutions/3708678/zhao-chu-di-k-ge-zi-fu-i-by-leetcode-sol-9epa/)

#### 方法一：迭代

**思路及解法**

最初有一个字符串 $"a"$，长度为 $1$，已知每一次进行操作，会将当前字符串中的字母改为字母表中的下一个字母，然后将修改后的字符串追加到原始字符串后。

易知每一次操作后，字符串的长度就会倍增，并且在原始字符串的基础上，每一位进行了一次加一取模的操作。

我们的目标是求解第 $k$ 个位置的字符，那么在上一步操作之前，该位置的字符是由哪一位（令其为 $k′$）的字符得来的？

不妨设 $k=2^t+a$，若 $a=0$，则当前的 $k$ 处于第 $t-1$ 次操作中，此时 $k′=k-2^t-1$；若 $a=0$，则当前的 $k$ 处于第 $t$ 次操作中，此时 $k′=k-2^t=a$。

通过这样的迭代，我们可以最后使 $k′=1$，此时位于第 $0$ 步操作。

每一次迭代都会使原始字符串 $"a"$ 进行一次加一取模的操作，因此我们只需要统计一共进行了几次迭代即可。

而在本题 $1 \le k \le 500$ 的数据量下我们也不需要进行取模的操作。

**代码**

```C++
class Solution {
public:
    char kthCharacter(int k) {
        int ans = 0;
        int t;
        while (k != 1) {
            t = __lg(k);
            if ((1 << t) == k) {
                t--;
            }
            k = k - (1 << t);
            ans++;
        }
        return 'a' + ans;
    }
};
```

```Java
class Solution {
    public char kthCharacter(int k) {
        int ans = 0;
        int t;
        while (k != 1) {
            t = 31 - Integer.numberOfLeadingZeros(k);
            if ((1 << t) == k) {
                t--;
            }
            k = k - (1 << t);
            ans++;
        }
        return (char) ('a' + ans);
    }
}
```

```CSharp
public class Solution {
    public char KthCharacter(int k) {
        int ans = 0;
        int t;
        while (k != 1) {
            t = (int)Math.Log(k, 2);
            if ((1 << t) == k) {
                t--;
            }
            k = k - (1 << t);
            ans++;
        }
        return (char)('a' + ans);
    }
}
```

```Go
func kthCharacter(k int) byte {
    ans := 0
    for k != 1 {
        t := bits.Len(uint(k)) - 1
        if 1 << t == k {
            t--
        }
        k -= 1 << t
        ans++
    }
    return byte('a' + ans)
}
```

```Python
class Solution:
    def kthCharacter(self, k: int) -> str:
        ans = 0
        while k != 1:
            t = k.bit_length() - 1
            if (1 << t) == k:
                t -= 1
            k -= 1 << t
            ans += 1
        return chr(ord('a') + ans)
```

```C
char kthCharacter(int k) {
    int ans = 0;
    int t;
    while (k != 1) {
        t = 31 - __builtin_clz(k);
        if ((1 << t) == k) {
            t--;
        }
        k = k - (1 << t);
        ans++;
    }
    return 'a' + ans;
}
```

```JavaScript
var kthCharacter = function(k) {
    let ans = 0;
    while (k !== 1) {
        let t = 31 - Math.clz32(k);
        if ((1 << t) === k) {
            t--;
        }
        k -= 1 << t;
        ans++;
    }
    return String.fromCharCode('a'.charCodeAt(0) + ans);
}
```

```TypeScript
function kthCharacter(k: number): string {
    let ans = 0;
    while (k !== 1) {
        let t = 31 - Math.clz32(k);
        if ((1 << t) === k) {
            t--;
        }
        k -= 1 << t;
        ans++;
    }
    return String.fromCharCode('a'.charCodeAt(0) + ans);
}
```

```Rust
impl Solution {
    pub fn kth_character(k: i32) -> char {
        let mut ans = 0;
        let mut k = k;
        while k != 1 {
            let t = 31 - k.leading_zeros();
            let t = if (1 << t) == k { t - 1 } else { t };
            k -= 1 << t;
            ans += 1;
        }
        (b'a' + ans) as char
    }
}
```

**复杂度分析**

- 时间复杂度：$O(logk)$, 仅与 $k$ 的二进制位数有关。
- 空间复杂度：$O(1)$，申请了常数个变量。
