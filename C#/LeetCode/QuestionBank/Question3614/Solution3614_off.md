### [用特殊操作处理字符串 II](https://leetcode.cn/problems/process-string-with-special-operations-ii/solutions/3979302/yong-te-shu-cao-zuo-chu-li-zi-fu-chuan-i-jpwb/)

#### 方法一：模拟

这一题是 [$\lceil$ 3612. 用特殊操作处理字符串 I$\rfloor$ ](https://leetcode.cn/problems/process-string-with-special-operations-i/description/) 的加强版。除了字符串 $s$ 的长度扩展到 $10^5$，字符串 $result$ 的长度扩展到 $10^{15}$ 外，我们还要求出在字符串 $result$ 中第 $k$ 位的字符是什么，我们显然是不能直接将字符串 $result$ 模拟出来后再进行查询的。

常规方法无法解题，我们可以从构造 $result$ 的四条规则之外的 $k$ 来入手，既然无法用最终的 $k$ 来获得对应字符，那么能否通过倒推来获得在构造 $result$ 过程中，这个最终的 $k$ 在 $result$ 中对应的位置呢？

考虑题目条件：如果 $k$ 超出 $result$ 的下标索引范围，则返回 $'.'$，由于 $result$ 的长度是一个未知数，那我们可以先将 $result$ 的长度 $len$ 模拟出来，当 $k+1>len$ 时，满足上述条件，直接返回 $'.'$ 即可。

接下来从字符串 $s$ 的结尾开始倒推最终的 $k$ 在构造 $result$ 过程中对应的位置，在倒推的每一步中必须满足 $k+1\le len$，过程如下：

1. 如果当前字符是 $'*'$，$k$ 的位置不发生变化，并且 $len$ 加一，即补上了 $'*'$ 删除掉的最后一个字符。
2. 如果当前字符是 $'\#'$，若 $k+1>\lceil\dfrac{len}{2}\rceil $，说明当前的 $k$ 在复制的 $result$ 中，因此在执行 $'\#'$ 操作之前的 $k$ 应该在 $k-\lfloor\dfrac{len}{2}\rfloor $ 的位置；若 $k+1\le \lceil\dfrac{len}{2}\rceil $，则说明当前的 $k$ 在原始的 $result$ 中，因此 $k$ 的值不用变化。并且 $len$ 需要更新为 $\lceil\dfrac{len}{2}\rceil $，即删除了 $result$ 的复制。
3. 如果当前字符是 $'%'$，则 $k$ 变为 $len-k-1$ 即可，$len$ 不需要改变。
4. 如果当前字符是小写字母，并且此时 $k+1=len$ 那么说明当前的 $k$ 对应的小写字母就是题目的答案，否则，若 $k+1<len$，则 $k$ 的值不变，$len$ 减一，即删除掉了 $result$ 的最后一个字符。

能够保证每一步操作后 $k+1\le len$。需要注意的是在倒推 $'*'$ 操作的过程中可以不需要考虑 $result$ 是否为空字符串，一种情况是 $s$ 中只有无效操作，没有小写字母，这种情况在进入第二个循环之前就返回 $'.'$ 了；另一种情况是 $s$ 中存在前导无效操作，使得 $result$ 为空字符串，不管是 $result$ 一直为空还是先变化后被 $'*'$ 删成空字符串，这样的前导操作均为无效操作，我们只会考虑 $result$ 的终态，在这个情况下，如果 $k$ 有对应字符一定在无效操作之前返回了，不需要考虑前导字符无效操作。

如果到最终还是得不到答案的话，返回 $'.'$ 即可。

```C++
class Solution {
public:
    char processStr(string s, long long k) {
        long long len = 0;
        for (auto c : s) {
            if (c == '*') {
                if (len) {
                    len--;
                }
            } else if (c == '#') {
                len *= 2;
            } else if (c == '%') {
                continue;
            } else {
                len++;
            }
        }
        if (k + 1 > len) {
            return '.';
        }
        for (int i = s.size() - 1; i >= 0; i--) {
            if (s[i] == '*') {
                len++;
            } else if (s[i] == '#') {
                if (k + 1 > (len + 1) / 2) {
                    k -= len / 2;
                }
                len = (len + 1) / 2;
            } else if (s[i] == '%') {
                k = len - k - 1;
            } else {
                if (k + 1 == len) {
                    return s[i];
                }
                else {
                    len--;
                }
            }
        }
        return '.';
    }
};
```

```Go
func processStr(s string, k int64) byte {
    var length int64
    for i := 0; i < len(s); i++ {
        switch s[i] {
        case '*':
            if length > 0 {
                length--
            }
        case '#':
            length *= 2
        case '%':
            // no length change
        default:
            length++
        }
    }
    if k+1 > length {
        return '.'
    }
    for i := len(s) - 1; i >= 0; i-- {
        switch s[i] {
        case '*':
            length++
        case '#':
            if k+1 > (length+1)/2 {
                k -= length / 2
            }
            length = (length + 1) / 2
        case '%':
            k = length - k - 1
        default:
            if k+1 == length {
                return s[i]
            }
            length--
        }
    }
    return '.'
}
```

```Python
class Solution:
    def processStr(self, s: str, k: int) -> str:
        length = 0
        for c in s:
            if c == "*":
                if length:
                    length -= 1
            elif c == "#":
                length *= 2
            elif c == "%":
                pass
            else:
                length += 1
        if k + 1 > length:
            return "."
        for c in reversed(s):
            if c == "*":
                length += 1
            elif c == "#":
                if k + 1 > (length + 1) // 2:
                    k -= length // 2
                length = (length + 1) // 2
            elif c == "%":
                k = length - k - 1
            else:
                if k + 1 == length:
                    return c
                length -= 1
        return "."

```

```Java
class Solution {
    public char processStr(String s, long k) {
        long len = 0;
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            switch (c) {
                case '*':
                    if (len > 0) {
                        len--;
                    }
                    break;
                case '#':
                    len *= 2;
                    break;
                case '%':
                    break;
                default:
                    len++;
                    break;
            }
        }
        if (k + 1 > len) {
            return '.';
        }
        for (int i = s.length() - 1; i >= 0; i--) {
            char c = s.charAt(i);
            switch (c) {
                case '*':
                    len++;
                    break;
                case '#':
                    if (k + 1 > (len + 1) / 2) {
                        k -= len / 2;
                    }
                    len = (len + 1) / 2;
                    break;
                case '%':
                    k = len - k - 1;
                    break;
                default:
                    if (k + 1 == len) {
                        return c;
                    }
                    len--;
                    break;
            }
        }
        return '.';
    }
}
```

```CSharp
public class Solution {
    public char ProcessStr(string s, long k) {
        long len = 0;
        foreach (char c in s) {
            switch (c) {
                case '*':
                    if (len > 0) {
                        len--;
                    }
                    break;
                case '#':
                    len *= 2;
                    break;
                case '%':
                    break;
                default:
                    len++;
                    break;
            }
        }
        if (k + 1 > len) {
            return '.';
        }
        for (int i = s.Length - 1; i >= 0; i--) {
            char c = s[i];
            switch (c) {
                case '*':
                    len++;
                    break;
                case '#':
                    if (k + 1 > (len + 1) / 2) {
                        k -= len / 2;
                    }
                    len = (len + 1) / 2;
                    break;
                case '%':
                    k = len - k - 1;
                    break;
                default:
                    if (k + 1 == len) {
                        return c;
                    }
                    len--;
                    break;
            }
        }
        return '.';
    }
}
```

```C
char processStr(char *s, long long k) {
    long long len = 0;
    size_t n = strlen(s);
    for (size_t i = 0; i < n; i++) {
        char c = s[i];
        if (c == '*') {
            if (len > 0) {
                len--;
            }
        } else if (c == '#') {
            len *= 2;
        } else if (c == '%') {
            ;
        } else {
            len++;
        }
    }
    if (k + 1 > len) {
        return '.';
    }
    for (long long i = (long long)n - 1; i >= 0; i--) {
        char c = s[i];
        if (c == '*') {
            len++;
        } else if (c == '#') {
            if (k + 1 > (len + 1) / 2) {
                k -= len / 2;
            }
            len = (len + 1) / 2;
        } else if (c == '%') {
            k = len - k - 1;
        } else {
            if (k + 1 == len) {
                return c;
            }
            len--;
        }
    }
    return '.';
}
```

```JavaScript
function processStr(s, k) {
    let len = 0;
    for (const c of s) {
        if (c === '*') {
            if (len > 0) {
                len--;
            }
        } else if (c === '#') {
            len *= 2;
        } else if (c === '%') {
            // no change
        } else {
            len++;
        }
    }
    if (k + 1 > len) {
        return '.';
    }
    for (let i = s.length - 1; i >= 0; i--) {
        const c = s[i];
        if (c === '*') {
            len++;
        } else if (c === '#') {
            if (k + 1 > (len + 1) / 2) {
                k -= Math.floor(len / 2);
            }
            len = Math.floor((len + 1) / 2);
        } else if (c === '%') {
            k = len - k - 1;
        } else {
            if (k + 1 === len) {
                return c;
            }
            len--;
        }
    }
    return '.';
}
```

```TypeScript
function processStr(s: string, k: number): string {
    let len = 0;
    for (const c of s) {
        if (c === '*') {
            if (len > 0) {
                len--;
            }
        } else if (c === '#') {
            len *= 2;
        } else if (c === '%') {
            // no change
        } else {
            len++;
        }
    }
    if (k + 1 > len) {
        return '.';
    }
    for (let i = s.length - 1; i >= 0; i--) {
        const c = s[i];
        if (c === '*') {
            len++;
        } else if (c === '#') {
            if (k + 1 > (len + 1) / 2) {
                k -= Math.floor(len / 2);
            }
            len = Math.floor((len + 1) / 2);
        } else if (c === '%') {
            k = len - k - 1;
        } else {
            if (k + 1 === len) {
                return c;
            }
            len--;
        }
    }
    return '.';
}
```

```Rust
impl Solution {
    pub fn process_str(s: String, mut k: i64) -> char {
        let mut len: i64 = 0;
        for c in s.chars() {
            match c {
                '*' => {
                    if len > 0 {
                        len -= 1;
                    }
                }
                '#' => {
                    len *= 2;
                }
                '%' => {}
                _ => {
                    len += 1;
                }
            }
        }
        if k + 1 > len {
            return '.';
        }
        for c in s.chars().rev() {
            match c {
                '*' => {
                    len += 1;
                }
                '#' => {
                    if k + 1 > (len + 1) / 2 {
                        k -= len / 2;
                    }
                    len = (len + 1) / 2;
                }
                '%' => {
                    k = len - k - 1;
                }
                _ => {
                    if k + 1 == len {
                        return c;
                    }
                    len -= 1;
                }
            }
        }
        '.'
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度，本解法只需要分别正序和倒序遍历一遍字符串 $s$ 即可。
- 空间复杂度：$O(1)$，本解法仅申请了一个 $len$ 用来保存 $result$ 的长度。
