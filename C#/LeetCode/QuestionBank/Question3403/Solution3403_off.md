### [从盒子中找出字典序最大的字符串 I](https://leetcode.cn/problems/find-the-lexicographically-largest-string-from-the-box-i/solutions/3685906/cong-he-zi-zhong-zhao-chu-zi-dian-xu-zui-eg0v/)

#### 方法一：枚举

当 $numFriends=1$ 时，直接返回 $word$。

当 $numFriends>1$ 时，对于以 $i$ 为左端点的所有分割子字符串，长度越大字典序也越大，而在题目条件的约束下，这些分割子字符串的最大长度为 $min(n-numFriends+1,n-i)$。因此我们可以从 $i=0$ 开始枚举左端点，然后取出对应的长度为 $min(n-numFriends+1,n-i)$ 的子字符串，最后返回这些子字符串中字典序最大的字符串。

```C++
class Solution {
public:
    string answerString(string word, int numFriends) {
        if (numFriends == 1) {
            return word;
        }
        int n = word.size();
        string res;
        for (int i = 0; i < n; i++) {
            res = max(res, word.substr(i, min(n - numFriends + 1, n - i)));
        }
        return res;
    }
};
```

```Go
func answerString(word string, numFriends int) string {
    if numFriends == 1 {
        return word
    }
    n := len(word)
    res := ""
    for i := 0; i < n; i++ {
        res = max(res, word[i : min(i + n - numFriends + 1, n)])
    }
    return res
}
```

```Python
class Solution:
    def answerString(self, word: str, numFriends: int) -> str:
        if numFriends == 1:
            return word
        n = len(word)
        res = ""
        for i in range(n):
            res = max(res, word[i : min(i + n - numFriends + 1, n)])
        return res
```

```Java
class Solution {
    public String answerString(String word, int numFriends) {
        if (numFriends == 1) {
            return word;
        }
        int n = word.length();
        String res = "";
        for (int i = 0; i < n; i++) {
            String s = word.substring(i, Math.min(i + n - numFriends + 1, n));
            if (res.compareTo(s) <= 0) {
                res = s;
            }
        }
        return res;
    }
}
```

```TypeScript
function answerString(word: string, numFriends: number): string {
    if (numFriends === 1) {
        return word;
    }
    const n = word.length;
    let res = "";
    for (let i = 0; i < n; i++) {
        const s = word.substring(i, Math.min(i + n - numFriends + 1, n));
        if (s > res) {
            res = s;
        }
    }

    return res;
};
```

```JavaScript
var answerString = function(word, numFriends) {
    if (numFriends === 1) {
        return word;
    }
    let n = word.length;
    let res = "";
    for (let i = 0; i < n; i++) {
        let s = word.substring(i, Math.min(i + n - numFriends + 1, n));
        if (s > res) {
            res = s;
        }
    }
    return res;
};
```

```CSharp
public class Solution {
    public string AnswerString(string word, int numFriends) {
        if (numFriends == 1) {
            return word;
        }
        int n = word.Length;
        string res = "";
        for (int i = 0; i < n; i++) {
            string s = word.Substring(i, Math.Min(n - numFriends + 1, n - i));
            if (string.Compare(res, s) <= 0) {
                res = s;
            }
        }
        return res;
    }
}
```

```C
char *answerString(char *word, int numFriends) {
    int n = strlen(word);
    char *res = (char *)malloc(n + 1);
    memset(res, 0, n + 1);
    if (numFriends == 1) {
        strcpy(res, word);
        return res;
    }
    for (int i = 0; i < n; i++) {
        int j = fmin(i + n - numFriends + 1, n);
        if (strncmp(res, word + i, j - i) < 0) {
            strncpy(res, word + i, j - i);
            res[j - i] = '\0';
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn answer_string(word: String, num_friends: i32) -> String {
        if num_friends == 1 {
            return word;
        }
        let n = word.len();
        let mut res = String::new();
        for i in 0 ..= n - 1 {
            let s = &word[i .. std::cmp::min(i + n - (num_friends as usize) + 1, n)];
            if res < s.to_string() {
                res = s.to_string();
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是字符串的长度。
- 空间复杂度：$O(n)$ 或 $O(1)$。支持字符串切片的语言的空间复杂度为 $O(1)$。

#### 方法二：双指针

在方法一中，当 $numFriends>1$ 时，如果字典序最大的后缀字符串的左端点为 $i$ 时，那么取出以 $i$ 为左端点，长度为 $min(n-numFriends+1,n-i)$ 的分割子字符串 $s_i$ 就是符合要求的字典序最大的字符串。

我们用反证法来论证以上做法的正确性，假设存在符合题目要求，且以 $j$ 为左端点的分割子字符串 $s_j>s_i$：

- $s_i$ 是后缀子字符串，即 $n-numFriends+1 \ge n-i$，那么 $s_j>s_i$ 与 $s_i$ 是字典序最大的后缀字符串矛盾。
- $s_i$ 不是后缀子字符串，即 $n-numFriends+1<n-i$，而 $s_j$ 的长度小于等于 $s_i$ 的长度 $n-numFriends+1$，所以 $s_j$ 和 $s_i$ 出现第一个不同的位置，$s_j$ 对应位置的字符比 $s_i$ 对应位置的字符的字典序更大，那么以 $j$ 为左端点的后缀字符串显然比以 $i$ 为左端点的后缀字符串的字典序更大，与前提矛盾。

> 取字典序最大的后缀字符串可以参考官方题解「[1163\. 按字典序排在最后的子串](https://leetcode.cn/problems/last-substring-in-lexicographical-order/solutions/2241014/an-zi-dian-xu-pai-zai-zui-hou-de-zi-chua-31yl/)」。

```C++
class Solution {
public:
    string lastSubstring(string s) {
        int i = 0, j = 1, n = s.size();
        while (j < n) {
            int k = 0;
            while (j + k < n && s[i + k] == s[j + k]) {
                k++;
            }
            if (j + k < n && s[i + k] < s[j + k]) {
                int t = i;
                i = j;
                j = max(j + 1, t + k + 1);
            } else {
                j = j + k + 1;
            }
        }
        return s.substr(i, n - i);
    }

    string answerString(string word, int numFriends) {
        if (numFriends == 1) {
            return word;
        }
        string last = lastSubstring(word);
        int n = word.size(), m = last.size();
        return last.substr(0, min(m, n - numFriends + 1));
    }
};
```

```Go
func lastSubstring(s string) string {
    i, j, n := 0, 1, len(s)
    for j < n {
        k := 0
        for j + k < n && s[i + k] == s[j + k] {
            k++
        }
        if j + k < n && s[i + k] < s[j + k] {
            i, j = j, max(j + 1, i + k + 1)
        } else {
            j = j + k + 1
        }
    }
    return s[i:]
}

func answerString(word string, numFriends int) string {
    if numFriends == 1 {
        return word
    }
    last := lastSubstring(word)
    n, m := len(word), len(last)
    return last[:min(m, n - numFriends + 1)]
}
```

```Python
class Solution:
    def lastSubstring(self, s: str) -> str:
        i, j, n = 0, 1, len(s)
        while j < n:
            k = 0
            while j + k < n and s[i + k] == s[j + k]:
                k += 1
            if j + k < n and s[i + k] < s[j + k]:
                i, j = j, max(j + 1, i + k + 1)
            else:
                j = j + k + 1
        return s[i:]

    def answerString(self, word: str, numFriends: int) -> str:
        if numFriends == 1:
            return word
        last = self.lastSubstring(word)
        n, m = len(word), len(last)
        return last[:min(m, n - numFriends + 1)]
```

```Java
class Solution {
    public String lastSubstring(String s) {
        int i = 0, j = 1, n = s.length();
        while (j < n) {
            int k = 0;
            while (j + k < n && s.charAt(i + k) == s.charAt(j + k)) {
                k++;
            }
            if (j + k < n && s.charAt(i + k) < s.charAt(j + k)) {
                int t = i;
                i = j;
                j = Math.max(j + 1, t + k + 1);
            } else {
                j = j + k + 1;
            }
        }
        return s.substring(i);
    }

    public String answerString(String word, int numFriends) {
        if (numFriends == 1) {
            return word;
        }
        String last = lastSubstring(word);
        int n = word.length(), m = last.length();
        return last.substring(0, Math.min(m, n - numFriends + 1));
    }
}
```

```TypeScript
function lastSubstring(s: string): string {
    let i = 0, j = 1, n = s.length;
    while (j < n) {
        let k = 0;
        while (j + k < n && s[i + k] === s[j + k]) {
            k++;
        }
        if (j + k < n && s[i + k] < s[j + k]) {
            let t = i;
            i = j;
            j = Math.max(j + 1, t + k + 1);
        } else {
            j = j + k + 1;
        }
    }
    return s.substring(i, n);
};

function answerString(word: string, numFriends: number): string {
    if (numFriends === 1) {
        return word;
    }
    let last: string = lastSubstring(word);
    let n: number = word.length;
    let m: number = last.length;
    return last.substring(0, Math.min(m, n - numFriends + 1));
};
```

```JavaScript
var lastSubstring = function(s) {
    let i = 0, j = 1, n = s.length;
    while (j < n) {
        let k = 0;
        while (j + k < n && s[i + k] === s[j + k]) {
            k++;
        }
        if (j + k < n && s[i + k] < s[j + k]) {
            let t = i;
            i = j;
            j = Math.max(j + 1, t + k + 1);
        } else {
            j = j + k + 1;
        }
    }
    return s.substring(i, n);
};

var answerString = function(word, numFriends) {
    if (numFriends === 1) {
        return word;
    }
    let last = lastSubstring(word);
    let n = word.length, m = last.length;
    return last.substring(0, Math.min(m, n - numFriends + 1));
};
```

```CSharp
public class Solution {
    public string LastSubstring(string s) {
        int i = 0, j = 1, n = s.Length;
        while (j < n) {
            int k = 0;
            while (j + k < n && s[i + k] == s[j + k]) {
                k++;
            }
            if (j + k < n && s[i + k] < s[j + k]) {
                int t = i;
                i = j;
                j = Math.Max(j + 1, t + k + 1);
            } else {
                j = j + k + 1;
            }
        }
        return s.Substring(i);
    }

    public string AnswerString(string word, int numFriends) {
        if (numFriends == 1) {
            return word;
        }
        string last = LastSubstring(word);
        int n = word.Length, m = last.Length;
        return last.Substring(0, Math.Min(m, n - numFriends + 1));
    }
}
```

```C
char *lastSubstring(char *s) {
    int i = 0, j = 1, n = strlen(s);
    while (j < n) {
        int k = 0;
        while (j + k < n && s[i + k] == s[j + k]) {
            k++;
        }
        if (j + k < n && s[i + k] < s[j + k]) {
            int t = i;
            i = j;
            j = fmax(j + 1, t + k + 1);
        } else {
            j = j + k + 1;
        }
    }
    return s + i;
}

char *answerString(char *word, int numFriends) {
    if (numFriends == 1) {
        return word;
    }
    char *last = lastSubstring(word);
    int n = strlen(word);
    int m = strlen(last);
    int len = fmin(m, n - numFriends + 1);
    last[len] = '\0';
    return last;
}
```

```Rust
impl Solution {
    pub fn last_substring(s: String) -> String {
        let s = s.as_bytes();
        let n = s.len();
        let mut i = 0;
        let mut j = 1;
        while j < n {
            let mut k = 0;
            while j + k < n && s[i + k] == s[j + k] {
                k += 1;
            }
            if j + k < n && s[i + k] < s[j + k] {
                let t = i;
                i = j;
                j = std::cmp::max(j + 1, t + k + 1);
            } else {
                j = j + k + 1;
            }
        }
        String::from_utf8(s[i..].to_vec()).unwrap()
    }

    pub fn answer_string(word: String, num_friends: i32) -> String {
        if num_friends == 1 {
            return word.to_string();
        }
        let n = word.len();
        let last = Self::last_substring(word);
        let m = last.len();
        let len = std::cmp::min(m, n - num_friends as usize + 1);
        last[..len].to_string()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $word$ 的长度。
- 空间复杂度：$O(n)$ 或 $O(1)$。支持字符串切片的语言的空间复杂度为 $O(1)$。
