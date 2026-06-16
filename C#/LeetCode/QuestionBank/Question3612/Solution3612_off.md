### [用特殊操作处理字符串 I](https://leetcode.cn/problems/process-string-with-special-operations-i/solutions/3979301/yong-te-shu-cao-zuo-chu-li-zi-fu-chuan-i-jurn/)

#### 方法一：模拟

根据题意模拟即可：

- 遍历到 $'*'$ 并且 $result$ 不为空字符串时，删除 $result$ 中的最后一个字符。
- 遍历到 $'\#'$ 时，把 $result$ 复制一份并将副本添加到 $result$ 的尾部。
- 遍历到 $'%'$ 时，将当前的 $result$ 翻转。
- 遍历到小写英文字母时，直接将其添加到 $result$ 的尾部。

```C++
class Solution {
public:
    string processStr(string s) {
        string result = "";
        for (auto it : s) {
            if (it == '*') {
                if (result.size()) {
                    result.pop_back();
                }
            } else if (it == '#') {
                result += result;
            } else if (it == '%') {
                result = string(result.rbegin(), result.rend());
            } else {
                result += it;
            }
        }
        return result;
    }
};
```

```Go
func processStr(s string) string {
    var result []rune
    for _, ch := range s {
        switch ch {
        case '*':
            if len(result) > 0 {
                result = result[:len(result)-1]
            }
        case '#':
            copyPart := make([]rune, len(result))
            copy(copyPart, result)
            result = append(result, copyPart...)
        case '%':
            for i, j := 0, len(result)-1; i < j; i, j = i+1, j-1 {
                result[i], result[j] = result[j], result[i]
            }
        default:
            result = append(result, ch)
        }
    }
    return string(result)
}
```

```Python
class Solution:
    def processStr(self, s: str) -> str:
        result = []
        for ch in s:
            if ch == '*':
                if result:
                    result.pop()
            elif ch == '#':
                result += result.copy()
            elif ch == '%':
                result = result[::-1]
            else:
                result.append(ch)
        return ''.join(result)
```

```Java
public class Solution {
    public String processStr(String s) {
        StringBuilder result = new StringBuilder();
        for (char ch : s.toCharArray()) {
            if (ch == '*') {
                if (result.length() > 0) result.deleteCharAt(result.length() - 1);
            } else if (ch == '#') {
                result.append(result.toString());
            } else if (ch == '%') {
                result.reverse();
            } else {
                result.append(ch);
            }
        }
        return result.toString();
    }
}
```

```CSharp
public class Solution {
    public string ProcessStr(string s) {
        var result = new StringBuilder();
        foreach (var ch in s) {
            if (ch == '*') {
                if (result.Length > 0) result.Length--;
            } else if (ch == '#') {
                result.Append(result.ToString());
            } else if (ch == '%') {
                var arr = result.ToString().ToCharArray();
                Array.Reverse(arr);
                result = new StringBuilder(new string(arr));
            } else {
                result.Append(ch);
            }
        }
        return result.ToString();
    }
}
```

```C
char* processStr(const char* s) {
    size_t cap = 16;
    size_t len = 0;
    char *res = malloc(cap);
    if (!res) return NULL;
    res[0] = '\0';
    for (const char *p = s; *p; ++p) {
        char c = *p;
        if (c == '*') {
            if (len) {
                len--;
                res[len] = '\0';
            }
        } else if (c == '#') {
            size_t need = len * 2 + 1;
            if (need > cap) {
                while (cap < need) cap *= 2;
                res = realloc(res, cap);
                if (!res) return NULL;
            }
            memcpy(res + len, res, len);
            len *= 2;
            res[len] = '\0';
        } else if (c == '%') {
            for (size_t i = 0; i < len / 2; ++i) {
                char t = res[i];
                res[i] = res[len - 1 - i];
                res[len - 1 - i] = t;
            }
            res[len] = '\0';
        } else {
            if (len + 2 > cap) {
                while (cap < len + 2) cap *= 2;
                res = realloc(res, cap);
                if (!res) return NULL;
            }
            res[len++] = c;
            res[len] = '\0';
        }
    }
    return res;
}
```

```JavaScript
function processStr(s) {
    let result = [];
    for (const ch of s) {
        if (ch === '*') {
            if (result.length) result.pop();
        } else if (ch === '#') {
            result = result.concat(result);
        } else if (ch === '%') {
            result.reverse();
        } else {
            result.push(ch);
        }
    }
    return result.join('');
}
```

```TypeScript
export function processStr(s: string): string {
    const result: string[] = [];
    for (const ch of s) {
        if (ch === '*') {
            if (result.length) result.pop();
        } else if (ch === '#') {
            result.push(...result.slice());
        } else if (ch === '%') {
            result.reverse();
        } else {
            result.push(ch);
        }
    }
    return result.join('');
}
```

```Rust
impl Solution {
    pub fn process_str(s: String) -> String {
        let mut result: Vec<char> = Vec::new();
        for ch in s.chars() {
            match ch {
                '*' => { result.pop(); }
                '#' => {
                    let mut copy = result.clone();
                    result.append(&mut copy);
                }
                '%' => { result.reverse(); }
                c => result.push(c),
            }
        }
        result.into_iter().collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(2^n)$，其中 $n$ 是原字符串 $s$ 的长度。模拟过程中，普通字符追加和删除为 $O(1)$，而 $'\#'$ 复制当前 $result$ 和 $'%'$ 翻转当前 $result$ 均需要遍历 $result$，整体开销与结果长度成正比。
- 空间复杂度：$O(2^n)$，其中 $n$ 是原字符串 $s$ 的长度，在进行翻转操作时需要存储中间结果字符串，最坏情况下 $result$ 的长度可以达到 $2n$。
