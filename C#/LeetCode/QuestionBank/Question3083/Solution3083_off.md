### [字符串及其反转中是否存在同一子字符串](https://leetcode.cn/problems/existence-of-a-substring-in-a-string-and-its-reverse/solutions/3016932/zi-fu-chuan-ji-qi-fan-zhuan-zhong-shi-fo-ra8p/)

#### 方法一：一次遍历

**思路与算法**

遍历字符串中每个长度为 $2$ 的子串，将其翻转后判断是否在原串中出现即可。

**代码**

```C++
class Solution {
public:
    bool isSubstringPresent(string s) {
        for (int i = 0; i + 1 < s.size(); i++) {
            string substr = s.substr(i, 2);
            reverse(substr.begin(), substr.end());
            if (s.find(substr) != string::npos) {
                return true;
            }
        }
        return false;
    }
};
```

```Java
class Solution {
    public boolean isSubstringPresent(String s) {
        for (int i = 0; i + 1 < s.length(); i++) {
            String substr = new StringBuilder(s.substring(i, i + 2)).reverse().toString();
            if (s.contains(substr)) {
                return true;
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    public bool IsSubstringPresent(string s) {
        for (int i = 0; i + 1 < s.Length; i++) {
            StringBuilder sb = new StringBuilder();
            sb.Append(s[i + 1]);
            sb.Append(s[i]);
            string substr = sb.ToString();
            if (s.Contains(substr)) {
                return true;
            }
        }
        return false;
    }
}
```

```Python
class Solution:
    def isSubstringPresent(self, s: str) -> bool:
        for i in range(len(s) - 1):
            if s[i:i+2][::-1] in s:
                return True
        return False
```

```Rust
impl Solution {
    pub fn is_substring_present(s: String) -> bool {
        let n = s.len();
        for i in 0..(n - 1) {
            let substr = &s[i..i+2].chars().rev().collect::<String>();
            if s.contains(substr) {
                return true
            }
        }
        false
    }
}
```

```Go
func isSubstringPresent(s string) bool {
    for i := 0; i < len(s) - 1; i++ {
        substr := string([]byte{s[i + 1], s[i]})
        if strings.Contains(s, substr) {
            return true
        }
    }
    return false
}
```

```C
bool isSubstringPresent(char* s) {
    int len = strlen(s);
    for (int i = 0; i < len - 1; i++) {
        char substr[3] = {s[i + 1], s[i], '\0'};
        if (strstr(s, substr)) {
            return true;
        }
    }
    return false;
}
```

```JavaScript
var isSubstringPresent = function(s) {
    for (let i = 0; i < s.length - 1; i++) {
        let substr = s[i + 1] + s[i];
        if (s.includes(substr)) {
            return true;
        }
    }
    return false;
};
```

```TypeScript
function isSubstringPresent(s: string): boolean {
    for (let i = 0; i < s.length - 1; i++) {
        let substr = s[i + 1] + s[i];
        if (s.includes(substr)) {
            return true;
        }
    }
    return false;
};
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是字符串的长度。总共有 $O(n)$ 个长度为 $2$ 的子串，每次查找其翻转后的字符串是否在原字符串中出现的时间复杂度为 $O(n)$，因此总共的时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(1)$。

#### 方法二：哈希表 + 位运算优化

**思路与算法**

我们可以用哈希表提前存储字符串中的每个长度为 $2$ 的子串，这样在判断翻转后的字符串是否出现时就避免了花费 $O(n)$ 的时间查找。

由于字符仅包含小写字母，该哈希表可以用一个整数类型的二维数组实现，形如 $hash[26][26]$。如果要进一步优化，还可以考虑将第二维使用二进制表示，例如 $hash[2]$ 二进制形式中，如果从低到高第 $1$ 位为 $1$，则表示子串 $"cb"$ 出现在字符串中（$2$ 表示字符 $c$，$1$ 表示字符 $b$）。

**代码**

```C++
class Solution {
public:
    bool isSubstringPresent(string s) {
        vector<int> h(26);
        for (int i = 0; i + 1 < s.size(); i++) {
            int x = s[i] - 'a';
            int y = s[i + 1] - 'a';
            h[x] |= 1 << y;
            if (h[y] >> x & 1) {
                return true;
            }
        }
        return false;
    }
};
```

```Java
class Solution {
    public boolean isSubstringPresent(String s) {
        int[] h = new int[26];
        for (int i = 0; i + 1 < s.length(); i++) {
            int x = s.charAt(i) - 'a';
            int y = s.charAt(i + 1) - 'a';
            h[x] |= 1 << y;
            if ((h[y] >> x & 1) != 0) {
                return true;
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    public bool IsSubstringPresent(string s) {
        int[] h = new int[26];
        for (int i = 0; i + 1 < s.Length; i++) {
            int x = s[i] - 'a';
            int y = s[i + 1] - 'a';
            h[x] |= 1 << y;
            if ((h[y] >> x & 1) != 0) {
                return true;
            }
        }
        return false;
    }
}
```

```Python
class Solution:
    def isSubstringPresent(self, s: str) -> bool:
        h = [0] * 26
        for i in range(len(s) - 1):
            x = ord(s[i]) - ord('a')
            y = ord(s[i + 1]) - ord('a')
            h[x] |= 1 << y
            if h[y] >> x & 1:
                return True
        return False
```

```Rust
impl Solution {
    pub fn is_substring_present(s: String) -> bool {
        let mut h = vec![0; 26];
        let s = s.as_bytes();
        for i in 0..s.len() - 1 {
            let x = (s[i] - b'a') as usize;
            let y = (s[i + 1] - b'a') as usize;
            h[x] |= 1 << y;
            if h[y] >> x & 1 == 1 {
                return true;
            }
        } 
        false
    }
}
```

```Go
func isSubstringPresent(s string) bool {
    h := make([]int, 26)
    for i := 0; i + 1 < len(s); i++ {
        x, y := s[i] - 'a', s[i + 1] - 'a'
        h[x] |= (1 << y)
        if (h[y] >> x) & 1 != 0 {
            return true
        }
    }
    return false
}
```

```C
bool isSubstringPresent(char* s) {
    int h[26] = {0};
    int len = strlen(s);
    for (int i = 0; i + 1 < len; i++) {
        int x = s[i] - 'a';
        int y = s[i + 1] - 'a';
        h[x] |= (1 << y);
        if ((h[y] >> x) & 1) {
            return true;
        }
    }
    return false;
}
```

```JavaScript
var isSubstringPresent = function(s) {
    let h = new Array(26).fill(0);
    for (let i = 0; i + 1 < s.length; i++) {
        let x = s.charCodeAt(i) - 'a'.charCodeAt(0);
        let y = s.charCodeAt(i + 1) - 'a'.charCodeAt(0);
        h[x] |= (1 << y);
        if ((h[y] >> x) & 1) {
            return true;
        }
    }
    return false;
};
```

```TypeScript
function isSubstringPresent(s: string): boolean {
    let h: number[] = new Array(26).fill(0);
    for (let i = 0; i + 1 < s.length; i++) {
        let x = s.charCodeAt(i) - 'a'.charCodeAt(0);
        let y = s.charCodeAt(i + 1) - 'a'.charCodeAt(0);
        h[x] |= (1 << y);
        if ((h[y] >> x) & 1) {
            return true;
        }
    }
    return false;
};
```

**复杂度分析**

- 时间复杂度：$O(n+C)$，其中 $n$ 是字符串的长度，$C$ 为字符集大小，本题中等于 $26$。
- 空间复杂度：$O(C)$。
