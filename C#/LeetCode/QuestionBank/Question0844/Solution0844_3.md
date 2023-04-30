#### [方法一：重构字符串](https://leetcode.cn/problems/backspace-string-compare/solutions/451606/bi-jiao-han-tui-ge-de-zi-fu-chuan-by-leetcode-solu/)

**思路及算法**

最容易想到的方法是将给定的字符串中的退格符和应当被删除的字符都去除，还原给定字符串的一般形式。然后直接比较两字符串是否相等即可。

具体地，我们用栈处理遍历过程，每次我们遍历到一个字符：

-   如果它是退格符，那么我们将栈顶弹出；
-   如果它是普通字符，那么我们将其压入栈中。

**代码**

```cpp
class Solution {
public:
    bool backspaceCompare(string S, string T) {
        return build(S) == build(T);
    }

    string build(string str) {
        string ret;
        for (char ch : str) {
            if (ch != '#') {
                ret.push_back(ch);
            } else if (!ret.empty()) {
                ret.pop_back();
            }
        }
        return ret;
    }
};
```

```java
class Solution {
    public boolean backspaceCompare(String S, String T) {
        return build(S).equals(build(T));
    }

    public String build(String str) {
        StringBuffer ret = new StringBuffer();
        int length = str.length();
        for (int i = 0; i < length; ++i) {
            char ch = str.charAt(i);
            if (ch != '#') {
                ret.append(ch);
            } else {
                if (ret.length() > 0) {
                    ret.deleteCharAt(ret.length() - 1);
                }
            }
        }
        return ret.toString();
    }
}
```

```go
func build(str string) string {
    s := []byte{}
    for i := range str {
        if str[i] != '#' {
            s = append(s, str[i])
        } else if len(s) > 0 {
            s = s[:len(s)-1]
        }
    }
    return string(s)
}

func backspaceCompare(s, t string) bool {
    return build(s) == build(t)
}
```

```python
class Solution:
    def backspaceCompare(self, S: str, T: str) -> bool:
        def build(s: str) -> str:
            ret = list()
            for ch in s:
                if ch != "#":
                    ret.append(ch)
                elif ret:
                    ret.pop()
            return "".join(ret)
        
        return build(S) == build(T)
```

```c
char* build(char* str) {
    int n = strlen(str), len = 0;
    char* ret = malloc(sizeof(char) * (n + 1));
    for (int i = 0; i < n; i++) {
        if (str[i] != '#') {
            ret[len++] = str[i];
        } else if (len > 0) {
            len--;
        }
    }
    ret[len] = '\0';
    return ret;
}

bool backspaceCompare(char* S, char* T) {
    return strcmp(build(S), build(T)) == 0;
}
```

**复杂度分析**

-   时间复杂度：$O(N+M)$，其中 $N$ 和 $M$ 分别为字符串 $S$ 和 $T$ 的长度。我们需要遍历两字符串各一次。
-   空间复杂度：$O(N+M)$，其中 $N$ 和 $M$ 分别为字符串 $S$ 和 $T$ 的长度。主要为还原出的字符串的开销。
