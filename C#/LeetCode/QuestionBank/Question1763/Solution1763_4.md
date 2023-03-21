#### [方法二：分治](https://leetcode.cn/problems/longest-nice-substring/solutions/1240201/zui-chang-de-mei-hao-zi-zi-fu-chuan-by-l-4l1t/)

**思路**

分治思想来源于「[395\. 至少有K个重复字符的最长子串](https://leetcode-cn.com/problems/longest-substring-with-at-least-k-repeating-characters/)」，详细的解法与其相似。题目要求找到最长的美好子字符串，如果字符串本身即合法的美好字符串，此时最长的完美字符串即为字符串本身。由于字符串中含有部分字符 $ch$ 只出现大写或者小写形式，如果字符串包含这些字符 $ch$ 时，可以判定该字符串肯定不为完美字符串。一个字符串为美好字符串的必要条件是不包含这些非法字符。因此我们可以利用分治的思想，将字符串从这些非法的字符处切分成若干段，则满足要求的最长子串一定出现在某个被切分的段内，而不能跨越一个或多个段。

-   递归时，$maxPos$ 用来记录最长完美字符串的起始索引，$maxLen$ 用来记录最长完美字符串的长度。
-   每次检查区间 $[start, end]$ 中的子字符串是否为完美字符串，如果当前的字符串为合法的完美字符串，则将当前区间的字符串的长度与 $maxLen$ 进行比较和替换；否则我们依次对当前字符串进行切分，然后递归检测切分后的字符串。

**代码**

```java
class Solution {
    private int maxPos;
    private int maxLen;

    public String longestNiceSubstring(String s) {
        this.maxPos = 0;
        this.maxLen = 0;
        dfs(s, 0, s.length() - 1);
        return s.substring(maxPos, maxPos + maxLen);
    }

    public void dfs(String s, int start, int end) {
        if (start >= end) {
            return;
        }
        int lower = 0, upper = 0;
        for (int i = start; i <= end; ++i) {
            if (Character.isLowerCase(s.charAt(i))) {
                lower |= 1 << (s.charAt(i) - 'a');
            } else {
                upper |= 1 << (s.charAt(i) - 'A');
            }
        }
        if (lower == upper) {
            if (end - start + 1 > maxLen) {
                maxPos = start;
                maxLen = end - start + 1;
            }
            return;
        } 
        int valid = lower & upper;
        int pos = start;
        while (pos <= end) {
            start = pos;
            while (pos <= end && (valid & (1 << Character.toLowerCase(s.charAt(pos)) - 'a')) != 0) {
                ++pos;
            }
            dfs(s, start, pos - 1);
            ++pos;
        }
    }
}
```

```cpp
class Solution {
public:
    void dfs(const string & s, int start, int end, int & maxPos, int & maxLen) {
        if (start >= end) {
            return;
        }
        int lower = 0, upper = 0;
        for (int i = start; i <= end; ++i) {
            if (islower(s[i])) {
                lower |= 1 << (s[i] - 'a');
            } else {
                upper |= 1 << (s[i] - 'A');
            }
        }
        if (lower == upper) {
            if (end - start + 1 > maxLen) {
                maxPos = start;
                maxLen = end - start + 1;
            }
            return;
        } 
        int valid = lower & upper;
        int pos = start;
        while (pos <= end) {
            start = pos;
            while (pos <= end && valid & (1 << (tolower(s[pos]) - 'a'))) {
                ++pos;
            }
            dfs(s, start, pos - 1, maxPos, maxLen);
            ++pos;
        }
    }

    string longestNiceSubstring(string s) {
        int maxPos = 0, maxLen = 0;
        dfs(s, 0, s.size() - 1, maxPos, maxLen);
        return s.substr(maxPos, maxLen);
    }
};
```

```csharp
public class Solution {
    private int maxPos;
    private int maxLen;

    public string LongestNiceSubstring(string s) {
        this.maxPos = 0;
        this.maxLen = 0;
        DFS(s, 0, s.Length - 1);
        return s.Substring(maxPos, maxLen);
    }

    public void DFS(String s, int start, int end) {
        if (start >= end) {
            return;
        }
        int lower = 0, upper = 0;
        for (int i = start; i <= end; ++i) {
            if (char.IsLower(s[i])) {
                lower |= 1 << (s[i] - 'a');
            } else {
                upper |= 1 << (s[i] - 'A');
            }
        }
        if (lower == upper) {
            if (end - start + 1 > maxLen) {
                maxPos = start;
                maxLen = end - start + 1;
            }
            return;
        } 
        int valid = lower & upper;
        int pos = start;
        while (pos <= end) {
            start = pos;
            while (pos <= end && (valid & (1 << char.ToLower(s[pos]) - 'a')) != 0) {
                ++pos;
            }
            DFS(s, start, pos - 1);
            ++pos;
        }
    }
}
```

```python
class Solution:
    def longestNiceSubstring(self, s: str) -> str:
        maxPos, maxLen = 0, 0
        def dfs(start, end):
            nonlocal maxPos, maxLen
            if start >= end:
                return
            lower, upper = 0, 0
            for i in range(start, end + 1):
                if s[i].islower():
                    lower|= 1 << (ord(s[i]) - ord('a'))
                else:
                    upper|= 1 << (ord(s[i]) - ord('A'))
            if lower == upper:
                if end - start + 1 > maxLen:
                    maxPos, maxLen = start, end - start + 1
                return
            pos, valid = start, lower & upper
            while pos <= end:
                start = pos
                while pos <= end and valid & (1 << (ord(s[pos].lower()) - ord('a'))):
                    pos += 1
                dfs(start, pos - 1)
                pos += 1
        dfs(0, len(s) - 1)
        return s[maxPos : maxPos + maxLen]
```

```c
void dfs(const char * s, int start, int end, int * maxPos, int * maxLen) {
    if (start >= end) {
        return;
    }
    int lower = 0, upper = 0;
    for (int i = start; i <= end; ++i) {
        if (islower(s[i])) {
            lower |= 1 << (s[i] - 'a');
        } else {
            upper |= 1 << (s[i] - 'A');
        }
    }
    if (lower == upper) {
        if (end - start + 1 > *maxLen ) {
            *maxPos = start;
            *maxLen = end - start + 1;
        }
        return;
    } 
    int valid = lower & upper;
    int pos = start;
    while (pos <= end) {
        start = pos;
        while (pos <= end && valid & (1 << (tolower(s[pos]) - 'a'))) {
            ++pos;
        }
        dfs(s, start, pos - 1, maxPos, maxLen);
        ++pos;
    }
}

char * longestNiceSubstring(char * s){
    int maxPos = 0, maxLen = 0;
    dfs(s, 0, strlen(s) - 1, &maxPos, &maxLen);
    s[maxPos + maxLen] = '\0';
    return s + maxPos;
}
```

```go
func longestNiceSubstring(s string) (ans string) {
    if s == "" {
        return
    }
    lower, upper := 0, 0
    for _, ch := range s {
        if unicode.IsLower(ch) {
            lower |= 1 << (ch - 'a')
        } else {
            upper |= 1 << (ch - 'A')
        }
    }
    if lower == upper {
        return s
    }
    valid := lower & upper
    for i := 0; i < len(s); i++ {
        start := i
        for i < len(s) && valid>>(unicode.ToLower(rune(s[i]))-'a')&1 == 1 {
            i++
        }
        if t := longestNiceSubstring(s[start:i]); len(t) > len(ans) {
            ans = t
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(n \cdot |\Sigma|)$，其中 $n$ 为字符串的长度，$|\Sigma|$ 为字符集的大小，本题中字符串仅包含英文大小写字母，因此 $|\Sigma| = 52$。本题使用了递归，由于字符集最多只有 $\dfrac{|\Sigma|}{2}$ 个不同的英文字母，每次递归都会去掉一个英文字母的所有大小写形式，因此递归深度最多为 $\dfrac{|\Sigma|}{2}$。
-   空间复杂度：$O(|\Sigma|)$。由于递归深度最多为 $|\Sigma|$，因此需要使用 $O(|\Sigma|)$ 的递归栈空间。
