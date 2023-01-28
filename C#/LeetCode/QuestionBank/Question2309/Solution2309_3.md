#### [方法二：位运算](https://leetcode.cn/problems/greatest-english-letter-in-upper-and-lower-case/solutions/2076006/jian-ju-da-xiao-xie-de-zui-hao-ying-wen-o5u2s/)

分别使用 $32$ 位整数 $lower$ 和 $upper$ 表示字符串 $s$ 中小写字母和大写字母的出现情况。遍历字符串 $s$，假设当前遍历到的字符为 $c$，如果 $c$ 为小写字母，那么将 $lower$ 对应的位置 $1$；如果 $c$ 为大写字母，那么将 $upper$ 对应的位置 $1$。

从大到小枚举英文字母，如果一个英文字母在 $lower$ 和 $upper$ 中都出现，那么直接返回该英文字母。如果所有的英文字母都不符合要求，那么直接返回空字符串。

```cpp
class Solution {
public:
    string greatestLetter(string s) {
        int lower = 0, upper = 0;
        for (auto c : s) {
            if (islower(c)) {
                lower |= 1 << (c - 'a');
            } else {
                upper |= 1 << (c - 'A');
            }
        }
        for (int i = 25; i >= 0; i--) {
            if (lower & upper & (1 << i)) {
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
        int lower = 0, upper = 0;
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (Character.isLowerCase(c)) {
                lower |= 1 << (c - 'a');
            } else {
                upper |= 1 << (c - 'A');
            }
        }
        for (int i = 25; i >= 0; i--) {
            if ((lower & upper & (1 << i)) != 0) {
                return String.valueOf((char) ('A' + i));
            }
        }
        return "";
    }
}
```

```csharp
public class Solution {
    public string GreatestLetter(string s) {
        int lower = 0, upper = 0;
        foreach (char c in s) {
            if (char.IsLower(c)) {
                lower |= 1 << (c - 'a');
            } else {
                upper |= 1 << (c - 'A');
            }
        }
        for (int i = 25; i >= 0; i--) {
            if ((lower & upper & (1 << i)) != 0) {
                return ((char) ('A' + i)).ToString();
            }
        }
        return "";
    }
}
```

```c
char * greatestLetter(char * s) {
    int lower = 0, upper = 0;
    for (int i = 0; s[i] != '\0'; i++) {
        char c = s[i];
        if (islower(c)) {
            lower |= 1 << (c - 'a');
        } else {
            upper |= 1 << (c - 'A');
        }
    }
    for (int i = 25; i >= 0; i--) {
        if (lower & upper & (1 << i)) {
            char *res = (char *)malloc(sizeof(char) * 2);
            res[0] = 'A' + i;
            res[1] = 0;
            return res;
        }
    }
    return "";
}
```

```javascript
var greatestLetter = function(s) {
    let lower = 0, upper = 0;
    for (let i = 0; i < s.length; i++) {
        const c = s[i];
        if ('a' <= c && c <= 'z') {
            lower |= 1 << (c.charCodeAt() - 'a'.charCodeAt());
        } else {
            upper |= 1 << (c.charCodeAt() - 'A'.charCodeAt());
        }
    }
    for (let i = 25; i >= 0; i--) {
        if ((lower & upper & (1 << i)) !== 0) {
            return String.fromCharCode('A'.charCodeAt() + i);
        }
    }
    return "";
};
```

**复杂度分析**

-   时间复杂度：$O(n + |\Sigma|)$，其中 $n$ 是字符串 $s$ 的长度，$\Sigma$ 是字符集，本题中 $|\Sigma| = 26$。
-   空间复杂度：$O(1)$。
