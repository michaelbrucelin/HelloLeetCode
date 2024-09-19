### [最长的字母序连续子字符串的长度](https://leetcode.cn/problems/length-of-the-longest-alphabetical-continuous-substring/solutions/2902877/zui-chang-de-zi-mu-xu-lian-xu-zi-zi-fu-c-n1ic/)

#### 方法一：模拟

**思路与算法**

我们从左到右遍历字符串，过程中维护以当前字符结尾的最长「字母序连续子字符串」的长度 $cur$：

- 若当前字符 $s[i]$ 为上一个字符 $s[i-1]$ 在字母序上的下一个字符，则令 $cur$ 增加 $1$；
- 否则令 $cur$ 等于 $1$，表示新的「字母序连续子字符串」的开头。

取遍历过程中所有 $cur$ 的最大值即为答案。

**代码**

```C++
class Solution {
public:
    int longestContinuousSubstring(string s) {
        int res = 1;
        int cur = 1;
        for (int i = 1; i < s.size(); i++) {
            if (s[i] == s[i - 1] + 1) {
                cur++;
            } else {
                cur = 1;
            }
            res = max(res, cur);
        }
        return res;
    }
};
```

```Java
class Solution {
    public int longestContinuousSubstring(String s) {
        int res = 1;
        int cur = 1;
        for (int i = 1; i < s.length(); i++) {
            if (s.charAt(i) == s.charAt(i - 1) + 1) {
                cur++;
            } else {
                cur = 1;
            }
            res = Math.max(res, cur);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int LongestContinuousSubstring(string s) {
        int res = 1;
        int cur = 1;
        for (int i = 1; i < s.Length; i++) {
            if (s[i] == s[i - 1] + 1) {
                cur++;
            } else {
                cur = 1;
            }
            res = Math.Max(res, cur);
        }
        return res;
    }
}
```

```Python
class Solution:
    def longestContinuousSubstring(self, s: str) -> int:
        res = 1
        cur = 1
        for i in range(1, len(s)):
            if ord(s[i]) == ord(s[i - 1]) + 1:
                cur += 1
            else:
                cur = 1
            res = max(res, cur)
        return res
```

```Go
func longestContinuousSubstring(s string) int {
    res, cur := 1, 1
    for i := 1; i < len(s); i++ {
        if s[i] == s[i - 1] + byte(1) {
            cur++
        } else {
            cur = 1
        }
        res = max(res, cur)
    }
    return res
}
```

```C
int longestContinuousSubstring(char* s) {
    int res = 1;
    int cur = 1;
    int len = strlen(s);
    for (int i = 1; i < len; i++) {
        if (s[i] == s[i - 1] + 1) {
            cur++;
        } else {
            cur = 1;
        }
        res = fmax(res, cur);
    }
    return res;
}
```

```JavaScript
var longestContinuousSubstring = function(s) {
    let res = 1;
    let cur = 1;
    for (let i = 1; i < s.length; i++) {
        if (s[i] == String.fromCharCode(s.charCodeAt(i - 1) + 1)) {
            cur++;
        } else {
            cur = 1;
        }
        res = Math.max(res, cur);
    }
    return res;
};
```

```TypeScript
function longestContinuousSubstring(s: string): number {
    let res: number = 1;
    let cur: number = 1;
    for (let i: number = 1; i < s.length; i++) {
        if (s[i] === String.fromCharCode(s.charCodeAt(i - 1) + 1)) {
            cur++;
        } else {
            cur = 1;
        }
        res = Math.max(res, cur);
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn longest_continuous_substring(s: String) -> i32 {
        let mut res = 1;
        let mut cur = 1;
        for i in 1..s.len() {
            if s.as_bytes()[i] == s.as_bytes()[i - 1] + 1 {
                cur += 1;
            } else {
                cur = 1;
            }
            res = i32::max(res, cur);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为字符串 $s$ 的长度。过程中对 $s$ 遍历一次，因此总体复杂度为 $O(n)$。
- 空间复杂度：$O(1)$。过程中只使用了若干个变量。
