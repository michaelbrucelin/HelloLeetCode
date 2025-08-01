### [删除字符使字符串变好](https://leetcode.cn/problems/delete-characters-to-make-fancy-string/solutions/922025/shan-chu-zi-fu-shi-zi-fu-chuan-bian-hao-12ovq/)

#### 方法一：模拟

**思路与算法**

如果想使得好字符串对应的删除字符数量最少，那么最佳的删除策略是：对于 $s$ 中每一个长度为 $k (k \ge 3)$ 的连续相同字符子串，删去其中任意 $k - 2$ 个字符。

我们可以用一个新字符串 $res$ 来维护删除最少字符后得到的好字符串，并从左至右遍历字符串 $s$ 模拟删除过程。每当遍历至一个新的字符时，我们检查 $res$ 中的最后两个字符（如有）是否均等于当前字符：

- 如果是，则该字符应被删除，我们不将该字符添加进 $res$；
- 如果不是，则不需要删除该字符，我们应当将该字符添加进 $res$。

当遍历完成 $s$ 后，$res$ 即为删除最少字符后得到的好字符串，我们返回 $res$ 作为答案。

**代码**

```C++
class Solution {
public:
    string makeFancyString(string s) {
        string res;   // 删除后的字符串
        // 遍历 s 模拟删除过程
        for (char ch : s){
            int n = res.size();
            if (n >= 2 && res[n-1] == ch && res[n-2] == ch){
                // 如果 res 最后两个字符与当前字符均相等，则不添加
                continue;
            }
            // 反之则添加
            res.push_back(ch);
        }
        return res;
    }
};
```

```Python
class Solution:
    def makeFancyString(self, s: str) -> str:
        res = []   # 删除后的字符串
        # 遍历 s 模拟删除过程
        for ch in s:
            if len(res) >= 2 and res[-1] == res[-2] == ch:
                # 如果 res 最后两个字符与当前字符均相等，则不添加
                continue
            # 反之则添加
            res.append(ch)
        return "".join(res)
```

```Java
class Solution {
    public String makeFancyString(String s) {
        StringBuilder res = new StringBuilder();   // 删除后的字符串
        // 遍历 s 模拟删除过程
        for (char ch : s.toCharArray()) {
            int n = res.length();
            if (n >= 2 && res.charAt(n - 1) == ch && res.charAt(n - 2) == ch) {
                // 如果 res 最后两个字符与当前字符均相等，则不添加
                continue;
            }
            // 反之则添加
            res.append(ch);
        }
        return res.toString();
    }
}
```

```CSharp
public class Solution {
    public string MakeFancyString(string s) {
        StringBuilder res = new StringBuilder();   // 删除后的字符串
        // 遍历 s 模拟删除过程
        foreach (char ch in s) {
            int n = res.Length;
            if (n >= 2 && res[n-1] == ch && res[n-2] == ch) {
                // 如果 res 最后两个字符与当前字符均相等，则不添加
                continue;
            }
            // 反之则添加
            res.Append(ch);
        }
        return res.ToString();
    }
}
```

```Go
func makeFancyString(s string) string {
    res := []rune{}   // 删除后的字符串
    // 遍历 s 模拟删除过程
    for _, ch := range s {
        n := len(res)
        if n >= 2 && res[n - 1] == ch && res[n - 2] == ch {
            // 如果 res 最后两个字符与当前字符均相等，则不添加
            continue
        }
        // 反之则添加
        res = append(res, ch)
    }
    return string(res)
}
```

```C
char* makeFancyString(char* s) {
    int len = strlen(s);
    char* res = (char*)malloc(len + 1);   // 删除后的字符串
    int pos = 0;
    // 遍历 s 模拟删除过程
    for (int i = 0; i < len; i++) {
        char ch = s[i];
        if (pos >= 2 && res[pos-1] == ch && res[pos-2] == ch) {
            // 如果 res 最后两个字符与当前字符均相等，则不添加
            continue;
        }
        // 反之则添加
        res[pos++] = ch;
    }
    res[pos] = '\0';
    return res;
}
```

```JavaScript
var makeFancyString = function(s) {
    let res = [];   // 删除后的字符串
    // 遍历 s 模拟删除过程
    for (const ch of s) {
        const n = res.length;
        if (n >= 2 && res[n - 1] === ch && res[n - 2] === ch) {
            // 如果 res 最后两个字符与当前字符均相等，则不添加
            continue;
        }
        // 反之则添加
        res.push(ch);
    }
    return res.join('');
};
```

```TypeScript
function makeFancyString(s: string): string {
    const res: string[] = [];   // 删除后的字符串
    // 遍历 s 模拟删除过程
    for (const ch of s) {
        const n = res.length;
        if (n >= 2 && res[n - 1] === ch && res[n - 2] === ch) {
            // 如果 res 最后两个字符与当前字符均相等，则不添加
            continue;
        }
        // 反之则添加
        res.push(ch);
    }
    return res.join('');
};
```

```Rust
impl Solution {
    pub fn make_fancy_string(s: String) -> String {
        let mut res = Vec::new();   // 删除后的字符串
        // 遍历 s 模拟删除过程
        for ch in s.chars() {
            let n = res.len();
            if n >= 2 && res[n - 1] == ch && res[n - 2] == ch {
                // 如果 res 最后两个字符与当前字符均相等，则不添加
                continue;
            }
            // 反之则添加
            res.push(ch);
        }
        res.into_iter().collect()
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$。
- 空间复杂度：由于不同语言的字符串实现与方法不同，空间复杂度也有所不同。对于 $C++$ 解法，空间复杂度为 $O(1)$；而对于 $Python$ 解法，空间复杂度为 $O(n)$。
