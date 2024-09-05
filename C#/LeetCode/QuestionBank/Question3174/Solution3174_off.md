### [清除数字](https://leetcode.cn/problems/clear-digits/)

#### 方法一：栈

根据题意，我们可以使用栈来模拟所有操作。首先遍历字符串 $s$，令当前访问的字符为 $c$，有两种情况：

- $c$ 为数字，那么我们将栈顶字符弹出。
- $c$ 不为数字，那么我们将 $c$ 压入栈中。

最后返回栈中自底向上的所有字符组成的字符串为结果。

```C++
class Solution {
public:
    string clearDigits(string s) {
        string res;
        for (char c : s) {
            if (isdigit(c)) {
                res.pop_back();
            } else {
                res.push_back(c);
            }
        }
        return res;
    }
};
```

```Go
func clearDigits(s string) string {
    var res []byte
    for _, c := range s {
        if unicode.IsDigit(c) {
            res = res[:len(res)-1]
        } else {
            res = append(res, byte(c))
        }
    }
    return string(res)
}
```

```Python
class Solution:
    def clearDigits(self, s: str) -> str:
        res = []
        for c in s:
            if c.isdigit():
                res.pop()
            else:
                res.append(c)
        return ''.join(res)
```

```Java
class Solution {
    public String clearDigits(String s) {
        StringBuilder res = new StringBuilder();
        for (char c : s.toCharArray()){
            if (Character.isDigit(c)) {
                res.deleteCharAt(res.length() - 1);
            } else {
                res.append(c);
            }
        }
        return res.toString();
    }
}
```

```C
char* clearDigits(char* s) {
    int n = strlen(s), k = 0;
    char *res = (char *)malloc(n + 1);
    for (int i = 0; i < n; i++) {
        if (isdigit(s[i])) {
            k--;
        } else {
            res[k++] = s[i];
        }
    }
    res[k] = '\0';
    return res;
}
```

```JavaScript
var clearDigits = function(s) {
    let res = [];
    for (let c of s){
        if (c >= '0' && c <= '9') {
            res.pop();
        } else {
            res.push(c);
        }
    }
    return res.join('');
};
```

```TypeScript
function clearDigits(s: string): string {
    let res = [];
    for (let c of s){
        if (c >= '0' && c <= '9') {
            res.pop();
        } else {
            res.push(c);
        }
    }
    return res.join('');
};
```

```Rust
impl Solution {
    pub fn clear_digits(s: String) -> String {
        let mut res: Vec<char> = Vec::new();
        for c in s.chars() {
            if c.is_digit(10) {
                res.pop();
            } else {
                res.push(c);
            }
        }
        res.into_iter().collect()
    }
}
```

```CSharp
public class Solution {
    public string ClearDigits(string s) {
        StringBuilder res = new StringBuilder();
        foreach (char c in s.ToCharArray()) {
            if (Char.IsDigit(c)) {
                res.Remove(res.Length - 1, 1);
            } else {
                res.Append(c);
            }
        }
        return res.ToString();
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(n)$。
