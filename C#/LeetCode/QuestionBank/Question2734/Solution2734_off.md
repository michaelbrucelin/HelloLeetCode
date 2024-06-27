### [执行子串操作后的字典序最小字符串](https://leetcode.cn/problems/lexicographically-smallest-string-after-substring-operation/solutions/2821506/zhi-xing-zi-chuan-cao-zuo-hou-de-zi-dian-ugxd/)

#### 方法一：贪心

**思路**

替换的操作，对于大多数字符来说，会使字典序变小，除了字符 ‘a’ 用 ‘z’ 这一替换，会使字典序变大。为了得到字典序最小的字符串，我们需要尽可能早地开始替换，即将被选择的非空子字符串的开始下标要尽可能小。因此，我们要找到第一个非 ‘a’ 字符，将它作为非空子字符串的开始下标。在这之后，再找到第一个 ‘a’ 字符，将它作为非空子字符串的结束下标（不包含），这之间所有的字符，都做一次替换，就得到了目标字符串。还有一种可能是，字符串为全 ‘a’，这种情况下我们找不到第一个非 ‘a’ 字符，题目有要求必须进行一次替换且子字符串非空，这种情况下我们对末尾字符进行一次替换即可。

**代码**

```Python
class Solution:
    def smallestString(self, s: str) -> str:
        indexOfFirstNonA = self.findFirstNonA(s)
        if indexOfFirstNonA == len(s):
            return s[:-1] + 'z'
        indexOfFirstA_AfterFirstNonA = self.findFirstA_AfterFirstNonA(s, indexOfFirstNonA)
        res = []
        for i, c in enumerate(s):
            if indexOfFirstNonA <= i < indexOfFirstA_AfterFirstNonA:
                res.append(chr(ord(c)-1))
            else:
                res.append(c)
        return ''.join(res)

    def findFirstNonA(self, s: str) -> int:
        for i, c in enumerate(s):
            if c != 'a':
                return i
        return len(s)

    def findFirstA_AfterFirstNonA(self, s:str, firstNonA: int) -> int:
        for i in range(firstNonA, len(s)):
            if s[i] == 'a':
                return i
        return len(s)
```

```Java
class Solution {
    public String smallestString(String s) {
        int indexOfFirstNonA = findFirstNonA(s);
        if (indexOfFirstNonA == s.length()) {
            StringBuilder sb = new StringBuilder(s);
            sb.setCharAt(s.length() - 1, 'z');
            return sb.toString();
        }
        int indexOfFirstA_AfterFirstNonA = findFirstA_AfterFirstNonA(s, indexOfFirstNonA);
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (i >= indexOfFirstNonA && i < indexOfFirstA_AfterFirstNonA) {
                res.append((char) (c - 1));
            } else {
                res.append(c);
            }
        }
        return res.toString();
    }

    public int findFirstNonA(String s) {
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) != 'a') {
                return i;
            }
        }
        return s.length();
    }

    public int findFirstA_AfterFirstNonA(String s, int firstNonA) {
        for (int i = firstNonA; i < s.length(); i++) {
            if (s.charAt(i) == 'a') {
                return i;
            }
        }
        return s.length();
    }
}
```

```CSharp
public class Solution {
    public string SmallestString(string s) {
        int indexOfFirstNonA = FindFirstNonA(s);
        if (indexOfFirstNonA == s.Length) {
            StringBuilder sb = new StringBuilder(s);
            sb[s.Length - 1] = 'z';
            return sb.ToString();
        }
        int indexOfFirstA_AfterFirstNonA = FindFirstA_AfterFirstNonA(s, indexOfFirstNonA);
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (i >= indexOfFirstNonA && i < indexOfFirstA_AfterFirstNonA) {
                res.Append((char) (c - 1));
            } else {
                res.Append(c);
            }
        }
        return res.ToString();
    }

    public int FindFirstNonA(string s) {
        for (int i = 0; i < s.Length; i++) {
            if (s[i] != 'a') {
                return i;
            }
        }
        return s.Length;
    }

    public int FindFirstA_AfterFirstNonA(string s, int firstNonA) {
        for (int i = firstNonA; i < s.Length; i++) {
            if (s[i] == 'a') {
                return i;
            }
        }
        return s.Length;
    }
}
```

```C++
class Solution {
public:
    string smallestString(string s) {
        char target = 'a';
        auto it = std::find_if(s.begin(), s.end(), [target](char c) {
            return c != target;
        }); 
        int indexOfFirstNonA = std::distance(s.begin(), it);
        if (indexOfFirstNonA == s.length()) {
            return s.substr(0, s.length() - 1) + 'z';
        }
        size_t indexOfFirstA_AfterFirstNonA = s.find('a', indexOfFirstNonA);
        if (indexOfFirstA_AfterFirstNonA == string::npos) {
            indexOfFirstA_AfterFirstNonA = s.length();
        }
        string res;
        for (int i = 0; i < s.length(); ++i) {
            if (indexOfFirstNonA <= i && i < indexOfFirstA_AfterFirstNonA) {
                res.push_back(static_cast<char>(s[i] - 1));
            } else {
                res.push_back(s[i]);
            }
        }
        return res;
    }
};
```

```C
int findFirstNonA(const char *s) {
    int i = 0;
    for (i = 0; s[i] != '\0'; i++) {
        if (s[i]!= 'a') {
            return i;
        }
    }
    return i;
}

int findFirstA_AfterFirstNonA(const char *s, int firstNonA) {
    int i;
    for (i = firstNonA; s[i] != '\0'; i++) {
        if (s[i] == 'a') {
            return i;
        }
    }
    return i;
}
char * smallestString(char * s){
    int indexOfFirstNonA = findFirstNonA(s);
    if (indexOfFirstNonA == strlen(s)) {
        s[strlen(s) - 1] = 'z';
        return s;
    }
    size_t indexOfFirstA_AfterFirstNonA = findFirstA_AfterFirstNonA(s, indexOfFirstNonA);  
    for (int i = 0; s[i] != '\0'; ++i) {
        if (indexOfFirstNonA <= i && i < indexOfFirstA_AfterFirstNonA) {
            s[i] = s[i] - 1;
        }
    }
    
    return s;
}
```

```Go
func smallestString(s string) string {
    t := []byte(s)
    indexOfFirstNonA := findFirstNonA(t)
    if indexOfFirstNonA == len(t) {
        t[len(t) - 1] = 'z'
        return string(t)
    }
    indexOfFirstA_AfterFirstNonA := findFirstA_AfterFirstNonA(t, indexOfFirstNonA)
    res := []byte{}
    for i, ch := range t {
        if indexOfFirstNonA <= i && i < indexOfFirstA_AfterFirstNonA {
            res = append(res, ch - 1)
        } else {
            res = append(res, ch)
        }
    }

    return string(res)
}

func findFirstNonA(t []byte) int {
    for i := 0; i < len(t); i++ {
        if t[i] != 'a' {
            return i
        }
    }
    return len(t)
}

func findFirstA_AfterFirstNonA(t []byte, firstNonA int) int {
    for i := firstNonA; i < len(t); i++ {
        if t[i] == 'a' {
            return i
        }
    }
    return len(t)
}
```

```JavaScript
var smallestString = function(s) {
    let target = 'a';
    let indexOfFirstNonA = s.indexOf(s.split('').find(c => c !== target));
    if (indexOfFirstNonA === -1) {
        return s.substr(0, s.length - 1) + 'z';
    }
    let indexOfFirstA_AfterFirstNonA = s.indexOf('a', indexOfFirstNonA);
    if (indexOfFirstA_AfterFirstNonA === -1) {
        indexOfFirstA_AfterFirstNonA = s.length;
    }
    let res = '';
    for (let i = 0; i < s.length; ++i) {
        if (indexOfFirstNonA <= i && i < indexOfFirstA_AfterFirstNonA) {
            res += String.fromCharCode(s.charCodeAt(i) - 1);
        } else {
            res += s[i];
        }
    }
    return res;
};
```

```TypeScript
function smallestString(s: string): string {
    let target = 'a';
    let indexOfFirstNonA = s.indexOf(s.split('').find(c => c !== target));
    if (indexOfFirstNonA === -1) {
        return s.substr(0, s.length - 1) + 'z';
    }
    let indexOfFirstA_AfterFirstNonA = s.indexOf('a', indexOfFirstNonA);
    if (indexOfFirstA_AfterFirstNonA === -1) {
        indexOfFirstA_AfterFirstNonA = s.length;
    }

    let res = '';
    for (let i = 0; i < s.length; ++i) {
        if (indexOfFirstNonA <= i && i < indexOfFirstA_AfterFirstNonA) {
            res += String.fromCharCode(s.charCodeAt(i) - 1);
        } else {
            res += s[i];
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn smallest_string(s: String) -> String {
        let target = 'a';
        let index_of_first_non_a = s.chars().position(|c| c != target).unwrap_or(s.len());
        if index_of_first_non_a == s.len() {
            return s[0..s.len() - 1].to_string() + "z";
        }
        let mut index_of_first_a_after_first_non_a = Self::findFirstA_AfterFirstNonA(&s, index_of_first_non_a);
        let mut res = String::new();
        for (i, c) in s.chars().enumerate() {
            if index_of_first_non_a <= i && i < index_of_first_a_after_first_non_a {
                res.push((c as u8 - 1) as char);
            } else {
                res.push(c);
            }
        }
        res
    }

    pub fn findFirstA_AfterFirstNonA(s: &String, index_of_first_non_a: usize) ->usize {
        let chars = s.chars().skip(index_of_first_non_a);
        for (index, c) in chars.enumerate() {
            if c == 'a' {
                return index + index_of_first_non_a;
            }
        }
        s.len()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(n)$。
