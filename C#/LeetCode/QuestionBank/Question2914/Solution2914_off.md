### [使二进制字符串变美丽的最少修改次数](https://leetcode.cn/problems/minimum-number-of-changes-to-make-binary-string-beautiful/solutions/4055008/shi-er-jin-zhi-zi-fu-chuan-bian-mei-li-d-xjg0/)

#### 方法一：贪心

**思路与算法**

美丽字符串可以划分成若干长度为偶数、字符相同的子串，因此下标为 $2i$ 和 $2i+1$ 的字符必须相同。因此只需独立处理每一对字符：若两个字符不同，修改其中一个，答案增加 $1$。

**代码**

```C++
class Solution {
public:
    int minChanges(string s) {
        int ans = 0;
        for (int i = 0; i < s.size(); i += 2) {
            ans += s[i] != s[i + 1];
        }
        return ans;
    }
};
```

```Python
class Solution:
    def minChanges(self, s: str) -> int:
        return sum(s[i] != s[i + 1] for i in range(0, len(s), 2))
```

```Rust
impl Solution {
    pub fn min_changes(s: String) -> i32 {
        s.as_bytes()
            .chunks_exact(2)
            .filter(|pair| pair[0] != pair[1])
            .count() as i32
    }
}
```

```Java
class Solution {
    public int minChanges(String s) {
        int ans = 0;
        for (int i = 0; i < s.length(); i += 2) {
            if (s.charAt(i) != s.charAt(i + 1)) {
                ans++;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinChanges(string s) {
        int ans = 0;
        for (int i = 0; i < s.Length; i += 2) {
            if (s[i] != s[i + 1]) {
                ans++;
            }
        }
        return ans;
    }
}
```

```Go
func minChanges(s string) int {
    ans := 0
    for i := 0; i < len(s); i += 2 {
        if s[i] != s[i+1] {
            ans++
        }
    }
    return ans
}
```

```C
int minChanges(char* s) {
    int ans = 0;
    int n = strlen(s);
    for (int i = 0; i < n; i += 2) {
        if (s[i] != s[i + 1]) {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var minChanges = function(s) {
    let ans = 0;
    for (let i = 0; i < s.length; i += 2) {
        if (s[i] !== s[i + 1]) {
            ans++;
        }
    }
    return ans;
};
```

```TypeScript
function minChanges(s: string): number {
    let ans = 0;
    for (let i = 0; i < s.length; i += 2) {
        if (s[i] !== s[i + 1]) {
            ans++;
        }
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串的长度。
- 空间复杂度：$O(1)$。
