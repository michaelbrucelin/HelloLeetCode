### [按键变更的次数](https://leetcode.cn/problems/number-of-changing-keys/solutions/3037277/an-jian-bian-geng-de-ci-shu-by-leetcode-otqk7/)

#### 方法一：一次遍历

**思路与算法**

我们从字符串 $s$ 下标为 $1$ 的字符开始遍历，如果当前遍历到的字符与上一个字符的小写表示不同，说明需要变更一次按键，答案增加 $1$。

**代码**

```C++
class Solution {
public:
    int countKeyChanges(string s) {
        int ans = 0;
        for (int i = 1; i < s.size(); ++i) {
            if (tolower(s[i - 1]) != tolower(s[i])) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countKeyChanges(self, s: str) -> int:
        ans = 0
        for i in range(1, len(s)):
            if s[i - 1].lower() != s[i].lower():
                ans += 1
        return ans
```

```Java
class Solution {
    public int countKeyChanges(String s) {
        int ans = 0;
        for (int i = 1; i < s.length(); ++i) {
            if (Character.toLowerCase(s.charAt(i - 1)) != Character.toLowerCase(s.charAt(i))) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountKeyChanges(string s) {
        int ans = 0;
        for (int i = 1; i < s.Length; ++i) {
            if (char.ToLower(s[i - 1]) != char.ToLower(s[i])) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```Go
func countKeyChanges(s string) int {
    ans := 0
    for i := 1; i < len(s); i++ {
        if strings.ToLower(string(s[i-1])) != strings.ToLower(string(s[i])) {
            ans++
        }
    }
    return ans
}
```

```C
int countKeyChanges(char* s) {
    int ans = 0;
    for (int i = 1; i < strlen(s); ++i) {
        if (tolower(s[i - 1]) != tolower(s[i])) {
            ++ans;
        }
    }
    return ans;
}
```

```JavaScript
var countKeyChanges = function(s) {
    let ans = 0;
    for (let i = 1; i < s.length; i++) {
        if (s[i - 1].toLowerCase() !== s[i].toLowerCase()) {
            ans++;
        }
    }
    return ans;
};
```

```TypeScript
function countKeyChanges(s: string): number {
    let ans = 0;
    for (let i = 1; i < s.length; i++) {
        if (s[i - 1].toLowerCase() !== s[i].toLowerCase()) {
            ans++;
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn count_key_changes(s: String) -> i32 {
        let mut ans = 0;
        let chars: Vec<char> = s.chars().collect();
        for i in 1..chars.len() {
            if chars[i - 1].to_lowercase().to_string() != chars[i].to_lowercase().to_string() {
                ans += 1;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(1)$。
