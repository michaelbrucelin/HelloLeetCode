### [从字符串中移除星号](https://leetcode.cn/problems/removing-stars-from-a-string/solutions/2909118/cong-zi-fu-chuan-zhong-yi-chu-xing-hao-b-8fqm/)

#### 方法一：模拟

**思路与算法**

用一个字符数组来表示字符串结果，从左到右依次遍历每个字符。

- 如果是英文字母，则加入到数组中。
- 如果是星号，则删除数组中最后一个字母。

最后返回数组所表示的字符串，即为移除所有星号之后的字符串。

**代码**

```C++
class Solution {
public:
    string removeStars(string s) {
        string res;
        for (char c : s) {
            if (c == '*') {
                res.pop_back();
            } else {
                res += c;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public String removeStars(String s) {
        StringBuilder res = new StringBuilder();
        for (char c : s.toCharArray()) {
            if (c != '*') {
                res.append(c);
            } else {
                res.setLength(res.length() - 1);
            }
        }
        return res.toString();
    }
}
```

```Python
class Solution:
    def removeStars(self, s: str) -> str:
        res = []
        for c in s:
            if c != '*':
                res.append(c)
            elif res:
                res.pop()
        return ''.join(res)
```

```JavaScript
var removeStars = function(s) {
    let res = [];
    for (let c of s) {
        if (c !== '*') {
            res.push(c);
        } else {
            res.pop();
        }
    }
    return res.join('');
};
```

```TypeScript
function removeStars(s: string): string {
    let res = [];
    for (let c of s) {
        if (c !== '*') {
            res.push(c);
        } else {
            res.pop();
        }
    }
    return res.join('');
};
```

```Go
func removeStars(s string) string {
    var res []rune
    for _, c := range s {
        if c != '*' {
            res = append(res, c)
        } else {
            res = res[:len(res) - 1]
        }
    }
    return string(res)
}
```

```CSharp
public class Solution {
    public string RemoveStars(string s) {
        StringBuilder res = new StringBuilder();
        foreach (char c in s) {
            if (c != '*') {
                res.Append(c);
            } else {
                res.Length--;
            }
        }
        return res.ToString();
    }
}
```

```C
char* removeStars(char* s) {
    char* res = malloc(strlen(s) + 1);
    int len = 0;
    for (int i = 0; s[i] != '\0'; i++) {
        if (s[i] != '*') {
            res[len++] = s[i];
        } else {
            len--;
        }
    }
    res[len] = '\0';
    return res;
}
```

```Rust
impl Solution {
    pub fn remove_stars(s: String) -> String {
        let mut res = String::new();
        for c in s.chars() {
            if c != '*' {
                res.push(c);
            } else {
                res.pop();
            }
        }
        res
    }
}
```

```Cangjie
class Solution {
    func removeStars(s: String): String {
        let res = ArrayList<Rune>()
        for (c in s.runes()) {
            if (c != r'*') {
                res.append(c)
            } else {
                res.remove(res.size - 1)
            }
        }
        return collectString<Rune>(delimiter:"")(res)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(1)$。
