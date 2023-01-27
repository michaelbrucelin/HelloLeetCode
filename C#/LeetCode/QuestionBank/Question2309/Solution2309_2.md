#### [方法一：哈希表](https://leetcode.cn/problems/greatest-english-letter-in-upper-and-lower-case/solutions/2076006/jian-ju-da-xiao-xie-de-zui-hao-ying-wen-o5u2s/)

使用哈希表 $ht$ 保存字符串 $s$ 出现过的字符。遍历字符串 $s$，将当前字符 $c$ 加入到哈希表 $ht$ 中。

从大到小枚举英文字母，如果一个英文字母的大写形式和小写形式都出现在哈希表 $ht$ 中，那么直接返回该英文字母。如果所有的英文字母都不符合要求，那么直接返回空字符串。

```python
class Solution:
    def greatestLetter(self, s: str) -> str:
        s = set(s)
        for lower, upper in zip(reversed(ascii_lowercase), reversed(ascii_uppercase)):
            if lower in s and upper in s:
                return upper
        return ""
```

```cpp
class Solution {
public:
    string greatestLetter(string s) {
        unordered_set<char> ht(s.begin(), s.end());
        for (int i = 25; i >= 0; i--) {
            if (ht.count('a' + i) > 0 && ht.count('A' + i) > 0) {
                return string(1, 'A' + i);
            }
        }
        return "";
    }
};
```

```java
class Solution {
    public String greatestLetter(String s) {
        Set<Character> ht = new HashSet<Character>();
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            ht.add(c);
        }
        for (int i = 25; i >= 0; i--) {
            if (ht.contains((char) ('a' + i)) && ht.contains((char) ('A' + i))) {
                return String.valueOf((char) ('A' + i));
            }
        }
        return "";
    }
}
```

```c#
public class Solution {
    public string GreatestLetter(string s) {
        ISet<char> ht = new HashSet<char>();
        foreach (char c in s) {
            ht.Add(c);
        }
        for (int i = 25; i >= 0; i--) {
            if (ht.Contains((char) ('a' + i)) && ht.Contains((char) ('A' + i))) {
                return ((char) ('A' + i)).ToString();
            }
        }
        return "";
    }
}
```

```c
char * greatestLetter(char * s) {
    int ht[52];
    memset(ht, 0, sizeof(ht));
    for (int i = 0; s[i] != '\0'; i++) {
        if (islower(s[i])) {
            ht[s[i] - 'a'] = 1;
        } else {
            ht[s[i] - 'A' + 26] = 1;
        }
    }
    for (int i = 25; i >= 0; i--) {
        if (ht[i] > 0 && ht[26 + i] > 0) {
            char *res = (char *)malloc(sizeof(char) * 2);
            res[0] = 'A' + i;
            res[1] = '\0';
            return res;
        }
    }
    return "";
}
```

```javascript
var greatestLetter = function(s) {
    const ht = new Set();
    for (let i = 0; i < s.length; i++) {
        const c = s[i];
        ht.add(c);
    }
    for (let i = 25; i >= 0; i--) {
        if (ht.has(String.fromCharCode('a'.charCodeAt() + i)) && ht.has(String.fromCharCode('A'.charCodeAt() + i))) {
            return String.fromCharCode('A'.charCodeAt() + i);
        }
    }
    return "";
};
```

```go
func greatestLetter(s string) string {
    set := map[rune]bool{}
    for _, c := range s {
        set[c] = true
    }
    for i := 'Z'; i >= 'A'; i-- {
        if set[i] && set[unicode.ToLower(i)] {
            return string(i)
        }
    }
    return ""
}
```

**复杂度分析**

-   时间复杂度：$O(n + |\Sigma|)$，其中 $n$ 是字符串 $s$ 的长度，$\Sigma$ 是字符集，本题中 $|\Sigma| = 26$。
-   空间复杂度：$O(|\Sigma|)$，其中 $\Sigma$ 是字符集，本题中 $|\Sigma| = 26$。
