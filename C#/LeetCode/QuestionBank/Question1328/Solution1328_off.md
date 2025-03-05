### [破坏回文串](https://leetcode.cn/problems/break-a-palindrome/solutions/3081912/po-pi-hui-wen-chuan-by-leetcode-solution-neft/)

#### 方法一：贪心

令 $palindrome$ 的长度为 $n$，如果 $n=1$，那么无论怎么替换，它都是回文串，返回空字符串。对于 $n>1$，我们将 $palindrome$ 分成两段，遍历前半段，如果某个字符不等于 $‘a’$，那么将它替换成 $‘a’$，得到的就是结果字符串。如果前半段的所有字符都等于 $‘a’$，根据回文串的特性，后半段的所有字符都等于 $‘a’$，将最后一个字符替换成 $‘b’$，得到的就是结果字符串。

```C++
class Solution {
public:
    string breakPalindrome(string palindrome) {
        int n = palindrome.size();
        if (n == 1) {
            return "";
        }
        for (int i = 0; i * 2 + 1 < n; i++) {
            if (palindrome[i] != 'a') {
                palindrome[i] = 'a';
                return palindrome;
            }
        }
        palindrome.back()++;
        return palindrome;
    }
};
```

```Go
func breakPalindrome(palindrome string) string {
    n := len(palindrome)
    if n == 1 {
        return ""
    }
    data := []byte(palindrome)
    for i := 0; i * 2 + 1 < n; i++ {
        if data[i] != 'a' {
            data[i] = 'a'
            return string(data)
        }
    }
    data[n-1]++
    return string(data)
}
```

```Python
class Solution:
    def breakPalindrome(self, palindrome: str) -> str:
        n = len(palindrome)
        if n == 1:
            return ""
        data = list(palindrome)
        for i in range(n // 2):
            if data[i] != 'a':
                data[i] = 'a'
                return "".join(data)
        data[-1] = 'b'
        return "".join(data)
```

```Java
class Solution {
    public String breakPalindrome(String palindrome) {
        int n = palindrome.length();
        if (n == 1) {
            return "";
        }
        char[] data = palindrome.toCharArray();
        for (int i = 0; i * 2 + 1 < n; i++) {
            if (data[i] != 'a') {
                data[i] = 'a';
                return new String(data);
            }
        }
        data[n - 1] = 'b';
        return new String(data);
    }
}
```

```C
char* breakPalindrome(char *palindrome) {
    int n = strlen(palindrome);
    if (n == 1) {
        return "";
    }
    for (int i = 0; i * 2 + 1 < n; i++) {
        if (palindrome[i] != 'a') {
            palindrome[i] = 'a';
            return palindrome;
        }
    }
    palindrome[n - 1]++;
    return palindrome;
}
```

```JavaScript
var breakPalindrome = function(palindrome) {
    let n = palindrome.length;
    if (n === 1) {
        return "";
    }
    let data = palindrome.split("");
    for (let i = 0; i * 2 + 1 < n; i++) {
        if (data[i] !== 'a') {
            data[i] = 'a';
            return data.join("");
        }
    }
    data[n - 1] = 'b';
    return data.join("");
};
```

```TypeScript
function breakPalindrome(palindrome: string): string {
    let n = palindrome.length;
    if (n === 1) {
        return "";
    }
    let data = palindrome.split("");
    for (let i = 0; i * 2 + 1 < n; i++) {
        if (data[i] !== 'a') {
            data[i] = 'a';
            return data.join("");
        }
    }
    data[n - 1] = 'b';
    return data.join("");
}
```

```CSharp
public class Solution {
    public string BreakPalindrome(string palindrome) {
        int n = palindrome.Length;
        if (n == 1) {
            return "";
        }
        char[] data = palindrome.ToCharArray();
        for (int i = 0; i * 2 + 1 < n; i++) {
            if (data[i] != 'a') {
                data[i] = 'a';
                return new string(data);
            }
        }
        data[n - 1] = 'b';
        return new string(data);
    }
}
```

```Rust
impl Solution {
    pub fn break_palindrome(palindrome: String) -> String {
        let n = palindrome.len();
        if n == 1 {
            return "".to_string();
        }
        let mut data: Vec<char> = palindrome.chars().collect();
        for i in 0..(n / 2) {
            if data[i] != 'a' {
                data[i] = 'a';
                return data.iter().collect();
            }
        }
        data[n - 1] = 'b';
        data.iter().collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串的长度。
- 空间复杂度：$O(n)$ 或 $O(1)$。原地修改时，空间复杂度为 $O(1)$。
