### [最短且字典序最小的美丽子字符串](https://leetcode.cn/problems/shortest-and-lexicographically-smallest-beautiful-string/solutions/4015222/zui-duan-qie-zi-dian-xu-zui-xiao-de-mei-nkhoj/)

#### 方法一：枚举

**思路与算法**

题目要求我们在二进制字符串 $s$ 中找到包含 $k$ 个 $1$ 的最短且字典序最小的字符串。

假设 $s$ 的长度为 $n$。注意到题目给定的字符串长度范围较小，在 $10^2$ 内，所以我们可以用 $O(n^3)$ 时间复杂度的算法来解决这个问题。

假设最短字符串的长度为 $m$，我们在 $s$ 中枚举所有长度为 $m$ 的子字符串，判断其中是否有 $k$ 个 $1$，并返回字典序最小的字符串。$m$ 的范围为 $[k,n]$。

**代码**

```C++
class Solution {
public:
    string shortestBeautifulSubstring(string s, int k) {
        for (int m = k; m <= s.length(); m++) {
            string ans = "";
            for (int i = m; i <= s.length(); i++) {
                string t = s.substr(i - m, m);
                if ((ans.empty() || t < ans) && ranges::count(t, '1') == k) {
                    ans = t;
                }
            }
            if (!ans.empty()) {
                return ans;
            }
        }
        return "";
    }
};
```

```Python
class Solution:
    def shortestBeautifulSubstring(self, s: str, k: int) -> str:
        n = len(s)
        for m in range(k, n + 1):
            ans = ""
            for i in range(m, n + 1):
                t = s[i - m:i]
                if (not ans or t < ans) and t.count("1") == k:
                    ans = t
            if ans:
                return ans
        return ""
```

```Java
class Solution {
    public String shortestBeautifulSubstring(String s, int k) {
        int n = s.length();
        for (int m = k; m <= n; m++) {
            String ans = "";
            for (int i = m; i <= n; i++) {
                String t = s.substring(i - m, i);
                int cnt = 0;
                for (int j = 0; j < t.length(); j++) {
                    cnt += t.charAt(j) - '0';
                }
                if ((ans.isEmpty() || t.compareTo(ans) < 0) && cnt == k) {
                    ans = t;
                }
            }
            if (!ans.isEmpty()) {
                return ans;
            }
        }
        return "";
    }
}
```

```CSharp
public class Solution {
    public string ShortestBeautifulSubstring(string s, int k) {
        for (int m = k; m <= s.Length; m++) {
            string ans = "";
            for (int i = m; i <= s.Length; i++) {
                string t = s.Substring(i - m, m);
                if ((ans.Length == 0 || string.CompareOrdinal(t, ans) < 0) &&
                    t.Count(c => c == '1') == k) {
                    ans = t;
                }
            }
            if (ans.Length > 0) {
                return ans;
            }
        }
        return "";
    }
}
```

```C
char* shortestBeautifulSubstring(char* s, int k) {
    static char ans[105], t[105];
    int n = strlen(s);
    for (int m = k; m <= n; m++) {
        ans[0] = '\0';
        for (int i = m; i <= n; i++) {
            int cnt = 0;
            for (int j = i - m; j < i; j++) {
                cnt += s[j] - '0';
            }
            if (cnt == k) {
                memcpy(t, s + i - m, m);
                t[m] = '\0';
                if (ans[0] == '\0' || strcmp(t, ans) < 0) {
                    strcpy(ans, t);
                }
            }
        }
        if (ans[0] != '\0') {
            return ans;
        }
    }
    ans[0] = '\0';
    return ans;
}
```

```Go
func shortestBeautifulSubstring(s string, k int) string {
    for m := k; m <= len(s); m++ {
        ans := ""
        for i := m; i <= len(s); i++ {
            t := s[i-m : i]
            if (ans == "" || t < ans) && strings.Count(t, "1") == k {
                ans = t
            }
        }
        if ans != "" {
            return ans
        }
    }
    return ""
}
```

```JavaScript
var shortestBeautifulSubstring = function(s, k) {
    for (let m = k; m <= s.length; m++) {
        let ans = "";
        for (let i = m; i <= s.length; i++) {
            const t = s.slice(i - m, i);
            if ((!ans || t < ans) && [...t].filter(c => c === '1').length === k) {
                ans = t;
            }
        }
        if (ans) return ans;
    }
    return "";
};
```

```TypeScript
function shortestBeautifulSubstring(s: string, k: number): string {
    for (let m = k; m <= s.length; m++) {
        let ans = "";
        for (let i = m; i <= s.length; i++) {
            const t = s.slice(i - m, i);
            if ((!ans || t < ans) && [...t].filter(c => c === '1').length === k) {
                ans = t;
            }
        }
        if (ans) return ans;
    }
    return "";
}
```

```Rust
impl Solution {
    pub fn shortest_beautiful_substring(s: String, k: i32) -> String {
        for m in k as usize..=s.len() {
            let mut ans = String::new();
            for i in m..=s.len() {
                let t = &s[i - m..i];
                if t.bytes().filter(|&b| b == b'1').count() == k as usize
                    && (ans.is_empty() || t < ans.as_str())
                {
                    ans = t.to_string();
                }
            }
            if !ans.is_empty() {
                return ans;
            }
        }
        String::new()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^3)$，其中 $n$ 是字符串 $s$ 的长度。枚举所有长度为 $m$ 的字符串需要 $O(n^2)$，共需要枚举 $O(n)$ 个 $m$。
- 空间复杂度：$O(n)$ 或 $O(1)$。枚举过程中保存答案，字符串切片需要 $O(n)$ 的空间，$Go$ 语言字符串切片仅需 $O(1)$ 空间。

#### 方法二：滑动窗口

**思路与算法**

我们可以维护一个滑动窗口，当窗口中的 $1$ 数量大于 $k$ 或窗口端点处的字符是 $0$，就可以缩小窗口，从而找到最短的子字符串。

**实现**

```C++
class Solution {
public:
    string shortestBeautifulSubstring(string s, int k) {
        if (ranges::count(s, '1') < k) {
            return "";
        }
        string ans = s;
        int cnt = 0;
        for (int left = 0, right = 0; right < s.length(); right++) {
            cnt += s[right] - '0';
            while (cnt > k || s[left] == '0') {
                cnt -= s[left] - '0';
                left++;
            }
            if (cnt == k) {
                string t = s.substr(left, right - left + 1);
                if (t.length() < ans.length() ||
                    t.length() == ans.length() && t < ans) {
                    ans = move(t);
                }
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def shortestBeautifulSubstring(self, s: str, k: int) -> str:
        if s.count("1") < k:
            return ""
        ans = s
        left = cnt = 0
        for right, ch in enumerate(s):
            cnt += int(ch)
            while cnt > k or s[left] == "0":
                cnt -= int(s[left])
                left += 1
            if cnt == k:
                t = s[left:right + 1]
                if len(t) < len(ans) or len(t) == len(ans) and t < ans:
                    ans = t
        return ans
```

```Java
class Solution {
    public String shortestBeautifulSubstring(String s, int k) {
        int total = 0;
        for (int i = 0; i < s.length(); i++) total += s.charAt(i) - '0';
        if (total < k) return "";
        String ans = s;
        int cnt = 0, left = 0;
        for (int right = 0; right < s.length(); right++) {
            cnt += s.charAt(right) - '0';
            while (cnt > k || s.charAt(left) == '0') {
                cnt -= s.charAt(left++) - '0';
            }
            if (cnt == k) {
                String t = s.substring(left, right + 1);
                if (t.length() < ans.length() ||
                    t.length() == ans.length() && t.compareTo(ans) < 0) {
                    ans = t;
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public string ShortestBeautifulSubstring(string s, int k) {
        if (s.Count(c => c == '1') < k) return "";
        string ans = s;
        int cnt = 0, left = 0;
        for (int right = 0; right < s.Length; right++) {
            cnt += s[right] - '0';
            while (cnt > k || s[left] == '0') {
                cnt -= s[left++] - '0';
            }
            if (cnt == k) {
                string t = s.Substring(left, right - left + 1);
                if (t.Length < ans.Length ||
                    t.Length == ans.Length && string.CompareOrdinal(t, ans) < 0) {
                    ans = t;
                }
            }
        }
        return ans;
    }
}
```

```C
char* shortestBeautifulSubstring(char* s, int k) {
    static char ans[105], t[105];
    int n = strlen(s), total = 0;
    for (int i = 0; i < n; i++) total += s[i] - '0';
    if (total < k) {
        ans[0] = '\0';
        return ans;
    }
    strcpy(ans, s);
    int cnt = 0, left = 0;
    for (int right = 0; right < n; right++) {
        cnt += s[right] - '0';
        while (cnt > k || s[left] == '0') cnt -= s[left++] - '0';
        if (cnt == k) {
            int len = right - left + 1;
            memcpy(t, s + left, len);
            t[len] = '\0';
            if (len < (int)strlen(ans) ||
                len == (int)strlen(ans) && strcmp(t, ans) < 0) {
                strcpy(ans, t);
            }
        }
    }
    return ans;
}
```

```Go
func shortestBeautifulSubstring(s string, k int) string {
    if strings.Count(s, "1") < k {
        return ""
    }
    ans := s
    cnt, left := 0, 0
    for right := 0; right < len(s); right++ {
        cnt += int(s[right] - '0')
        for cnt > k || s[left] == '0' {
            cnt -= int(s[left] - '0')
            left++
        }
        if cnt == k {
            t := s[left : right+1]
            if len(t) < len(ans) || len(t) == len(ans) && t < ans {
                ans = t
            }
        }
    }
    return ans
}
```

```JavaScript
var shortestBeautifulSubstring = function(s, k) {
    if ([...s].filter(c => c === '1').length < k) return "";
    let ans = s, cnt = 0, left = 0;
    for (let right = 0; right < s.length; right++) {
        cnt += s[right] - '0';
        while (cnt > k || s[left] === '0') {
            cnt -= s[left++] - '0';
        }
        if (cnt === k) {
            const t = s.slice(left, right + 1);
            if (t.length < ans.length || t.length === ans.length && t < ans) {
                ans = t;
            }
        }
    }
    return ans;
};
```

```TypeScript
function shortestBeautifulSubstring(s: string, k: number): string {
    if ([...s].filter(c => c === '1').length < k) return "";
    let ans = s, cnt = 0, left = 0;
    for (let right = 0; right < s.length; right++) {
        cnt += s[right].charCodeAt(0) - 48;
        while (cnt > k || s[left] === '0') {
            cnt -= s[left++].charCodeAt(0) - 48;
        }
        if (cnt === k) {
            const t = s.slice(left, right + 1);
            if (t.length < ans.length || t.length === ans.length && t < ans) {
                ans = t;
            }
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn shortest_beautiful_substring(s: String, k: i32) -> String {
        let bytes = s.as_bytes();
        if bytes.iter().filter(|&&b| b == b'1').count() < k as usize {
            return String::new();
        }
        let mut ans = s.clone();
        let (mut cnt, mut left) = (0, 0);
        for right in 0..bytes.len() {
            cnt += (bytes[right] - b'0') as i32;
            while cnt > k || bytes[left] == b'0' {
                cnt -= (bytes[left] - b'0') as i32;
                left += 1;
            }
            if cnt == k {
                let t = &s[left..=right];
                if t.len() < ans.len() || t.len() == ans.len() && t < ans.as_str() {
                    ans = t.to_string();
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是字符串 $s$ 的长度。滑动窗口需要 $O(n)$，截取子字符串的操作需要 $O(n)$。
- 空间复杂度：$O(n)$ 或 $O(1)$。枚举过程中保存答案，字符串切片需要 $O(n)$ 的空间，$Go$ 语言字符串切片仅需 $O(1)$ 空间。
