#### [方法一：枚举](https://leetcode.cn/problems/longest-nice-substring/solutions/1240201/zui-chang-de-mei-hao-zi-zi-fu-chuan-by-l-4l1t/)

**思路**

题目要求找到最长的美好子字符串，题目中给定的字符串 $s$ 的长度 $length$ 范围为 $1 \le length \le 100$。由于字符串的长度比较小，因此可以枚举所有可能的子字符串，然后检测该字符串是否为美好的字符串，并得到长度最长的美好字符串。

-   题目关于美好字符串的定义为: 字符串中的每个字母的大写和小写形式同时出现在该字符串中。检测时，由于英文字母 $‘a’−‘z’$ 最多只有 $26$ 个, 因此可以利用二进制位来进行标记，$lower$ 标记字符中出现过小写英文字母，$upper$ 标记字符中出现过大写英文字母。如果满足 $lower = upper$ ，我们则认为字符串中所有的字符都满足大小写形式同时出现，则认定该字符串为美好字符串。
-   题目要求如果有多个答案，返回在字符串中最早出现的那个。此时，只需要首先检测从以字符串索引 $0$ 为起始的子字符串。

**代码**

```java
class Solution {
    public String longestNiceSubstring(String s) {
        int n = s.length();
        int maxPos = 0;
        int maxLen = 0;
        for (int i = 0; i < n; ++i) {
            int lower = 0;
            int upper = 0;
            for (int j = i; j < n; ++j) {
                if (Character.isLowerCase(s.charAt(j))) {
                    lower |= 1 << (s.charAt(j) - 'a');
                } else {
                    upper |= 1 << (s.charAt(j) - 'A');
                }
                if (lower == upper && j - i + 1 > maxLen) {
                    maxPos = i;
                    maxLen = j - i + 1;
                }
            }
        }
        return s.substring(maxPos, maxPos + maxLen);
    }
}
```

```cpp
class Solution {
public:
    string longestNiceSubstring(string s) {
        int n = s.size();
        int maxPos = 0;
        int maxLen = 0;
        for (int i = 0; i < n; ++i) {
            int lower = 0;
            int upper = 0;
            for (int j = i; j < n; ++j) {
                if (islower(s[j])) {
                    lower |= 1 << (s[j] - 'a');
                } else {
                    upper |= 1 << (s[j] - 'A');
                }
                if (lower == upper && j - i + 1 > maxLen) {
                    maxPos = i;
                    maxLen = j - i + 1;
                }
            }
        }
        return s.substr(maxPos, maxLen);
    }
};
```

```csharp
public class Solution {
    public string LongestNiceSubstring(string s) {
        int n = s.Length;
        int maxPos = 0;
        int maxLen = 0;
        for (int i = 0; i < n; ++i) {
            int lower = 0;
            int upper = 0;
            for (int j = i; j < n; ++j) {
                if (char.IsLower(s[j])) {
                    lower |= 1 << (s[j] - 'a');
                } else {
                    upper |= 1 << (s[j] - 'A');
                }
                if (lower == upper && j - i + 1 > maxLen) {
                    maxPos = i;
                    maxLen = j - i + 1;
                }
            }
        }
        return s.Substring(maxPos, maxLen);
    }
}
```

```python
class Solution:
    def longestNiceSubstring(self, s: str) -> str:
        n = len(s)
        maxPos, maxLen = 0, 0
        for i in range(n):
            lower, upper = 0, 0
            for j in range(i, n):
                if s[j].islower():
                    lower |= 1 << (ord(s[j]) - ord('a'))
                else:
                    upper |= 1 << (ord(s[j]) - ord('A'))
                if lower == upper and j - i + 1 > maxLen:
                    maxPos = i
                    maxLen = j - i + 1
        return s[maxPos: maxPos + maxLen]
```

```c
char * longestNiceSubstring(char * s){
    int n = strlen(s);
    int maxPos = 0;
    int maxLen = 0;
    for (int i = 0; i < n; ++i) {
        int lower = 0;
        int upper = 0;
        for (int j = i; j < n; ++j) {
            if (islower(s[j])) {
                lower |= 1 << (s[j] - 'a');
            } else {
                upper |= 1 << (s[j] - 'A');
            }
            if (lower == upper && j - i + 1 > maxLen) {
                maxPos = i;
                maxLen = j - i + 1;
            }
        }
    }
    char * ans = (char *)malloc(sizeof(char) * (maxLen + 1));
    strncpy(ans, s + maxPos, maxLen);
    ans[maxLen] = '\0';
    return ans;
}
```

```javascript
var longestNiceSubstring = function(s) {
    const n = s.length;
    let maxPos = 0;
    let maxLen = 0;
    for (let i = 0; i < n; ++i) {
        let lower = 0;
        let upper = 0;
        for (let j = i; j < n; ++j) {
            if ('a' <= s[j] && s[j] <= 'z') {
                lower |= 1 << (s[j].charCodeAt() - 'a'.charCodeAt());
            } else {
                upper |= 1 << (s[j].charCodeAt() - 'A'.charCodeAt());
            }
            if (lower === upper && j - i + 1 > maxLen) {
                maxPos = i;
                maxLen = j - i + 1;
            }
        }
    }
    return s.slice(maxPos, maxPos + maxLen);
};
```

```go
func longestNiceSubstring(s string) (ans string) {
    for i := range s {
        lower, upper := 0, 0
        for j := i; j < len(s); j++ {
            if unicode.IsLower(rune(s[j])) {
                lower |= 1 << (s[j] - 'a')
            } else {
                upper |= 1 << (s[j] - 'A')
            }
            if lower == upper && j-i+1 > len(ans) {
                ans = s[i : j+1]
            }
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 为字符串的长度。需要枚举所有可能的子字符串，因此需要双重循环遍历字符串，总共可能有 $n^2$ 个连续的子字符串。
-   空间复杂度：$O(1)$。由于返回值不需要计算空间复杂度，除了需要两个整数变量用来标记以外不需要额外的空间。
