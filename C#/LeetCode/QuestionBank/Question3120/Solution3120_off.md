### [统计特殊字母的数量 I](https://leetcode.cn/problems/count-the-number-of-special-characters-i/solutions/3963834/tong-ji-te-shu-zi-mu-de-shu-liang-i-by-l-es7b/)

#### 方法一：哈希集合

用一个集合记录字符串中出现的所有字符，然后遍历 $26$ 个字母，检查小写和大写是否同时存在。

```C++
class Solution {
public:
    int numberOfSpecialChars(string word) {
        unordered_set<char> s(word.begin(), word.end());
        int ans = 0;
        for (char c = 'a'; c <= 'z'; c++) {
            if (s.count(c) && s.count(c - 'a' + 'A')) {
                ans++;
            }
        }
        return ans;
    }
};
```

```Go
func numberOfSpecialChars(word string) int {
    s := make(map[rune]bool)
    for _, c := range word {
        s[c] = true
    }
    ans := 0
    for c := 'a'; c <= 'z'; c++ {
        if s[c] && s[c - 'a' + 'A'] {
            ans++
        }
    }
    return ans
}
```

```Python
class Solution:
    def numberOfSpecialChars(self, word: str) -> int:
        s = set(word)
        return sum(c in s and c.upper() in s for c in string.ascii_lowercase)
```

```Java
class Solution {
    public int numberOfSpecialChars(String word) {
        Set<Character> s = new HashSet<>();
        for (char c : word.toCharArray()) {
            s.add(c);
        }
        int ans = 0;
        for (char c = 'a'; c <= 'z'; c++) {
            if (s.contains(c) && s.contains((char)(c - 'a' + 'A'))) {
                ans++;
            }
        }
        return ans;
    }
}
```

```TypeScript
function numberOfSpecialChars(word: string): number {
    const s = new Set(word);
    let ans = 0;
    for (let i = 0; i < 26; i++) {
        const lo = String.fromCharCode(97 + i);
        const up = String.fromCharCode(65 + i);
        if (s.has(lo) && s.has(up)) {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var numberOfSpecialChars = function(word) {
    const s = new Set(word);
    let ans = 0;
    for (let i = 0; i < 26; i++) {
        const lo = String.fromCharCode(97 + i);
        const up = String.fromCharCode(65 + i);
        if (s.has(lo) && s.has(up)) {
            ans++;
        }
    }
    return ans;
};
```

```CSharp
public class Solution {
    public int NumberOfSpecialChars(string word) {
        var s = new HashSet<char>(word);
        int ans = 0;
        for (char c = 'a'; c <= 'z'; c++) {
            if (s.Contains(c) && s.Contains((char)(c - 'a' + 'A'))) {
                ans++;
            }
        }
        return ans;
    }
}
```

```C
int numberOfSpecialChars(char* word) {
    int seen[128] = {0};
    for (int i = 0; word[i]; i++) {
        seen[(unsigned char)word[i]] = 1;
    }
    int ans = 0;
    for (char c = 'a'; c <= 'z'; c++) {
        if (seen[(int)c] && seen[(int)(c - 'a' + 'A')]) {
            ans++;
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn number_of_special_chars(word: String) -> i32 {
        use std::collections::HashSet;
        let s: HashSet<char> = word.chars().collect();
        let mut ans = 0;
        for c in 'a'..='z' {
            if s.contains(&c) && s.contains(&c.to_uppercase().next().unwrap()) {
                ans += 1;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+\vert \sum \vert)$，其中 $n$ 是字符串长度，$\vert \sum \vert=26$。
- 空间复杂度：$O(\vert \sum \vert)$。
