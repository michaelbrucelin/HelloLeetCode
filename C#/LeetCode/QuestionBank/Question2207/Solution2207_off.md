### [字符串中最多数目的子序列](https://leetcode.cn/problems/maximize-number-of-subsequences-in-a-string/solutions/2921910/zi-fu-chuan-zhong-zui-duo-shu-mu-de-zi-x-iv6p/)

#### 方法一：遍历 + 统计频数

**思路与算法**

遍历字符串，并且同时统计两个字符出现的频数。如果遇见 $pattern[1]$，就可以和前面出现过的 $pattern[0]$ 组成子序列。

然后我们插入字符：

- 如果加上 $pattern[0]$，就加在字符串开头，与字符串中的 $pattern[1]$ 组成新的子序列。
- 如果加上 $pattern[1]$，就加在字符串结尾，与字符串中的 $pattern[0]$ 组成新的子序列。

最终新增的子字符串数量为两个字符频数的最大值，加到结果中并返回。

**代码**

```C++
class Solution {
public:
    long long maximumSubsequenceCount(string text, string pattern) {
        long long res = 0;
        int cnt1 = 0, cnt2 = 0;
        for (char c: text) {
            if (c == pattern[1]) {
                res += cnt1;
                cnt2++;
            }
            if (c == pattern[0]) {
                cnt1++;
            }
        }
        return res + max(cnt1, cnt2);
    }
};

```

```Java
class Solution {
    public long maximumSubsequenceCount(String s, String pattern) {
        long res = 0;
        int cnt1 = 0, cnt2 = 0;
        for (int i = 0; i < s.length(); ++i) {
            if (s.charAt(i) == pattern.charAt(1)) {
                res += cnt1;
                cnt2++;
            }
            if (s.charAt(i) == pattern.charAt(0)) {
                cnt1++;
            }
        }
        return res + Math.max(cnt1, cnt2);
    }
}
```

```Python
class Solution:
    def maximumSubsequenceCount(self, text: str, pattern: str) -> int:
        res = cnt1 = cnt2 = 0
        for c in text:
            if c == pattern[1]:
                res += cnt1
                cnt2 += 1
            if c == pattern[0]:
                cnt1 += 1
        return res + max(cnt1, cnt2)
```

```JavaScript
var maximumSubsequenceCount = function(text, pattern) {
    let res = 0, cnt1 = 0, cnt2 = 0;
    for (let c of text) {
        if (c == pattern[1]) {
            res += cnt1;
            cnt2++;
        }
        if (c == pattern[0]) {
            cnt1++;
        }
    }
    return res + Math.max(cnt1, cnt2);
};
```

```TypeScript
function maximumSubsequenceCount(text: string, pattern: string): number {
    let res = 0, cnt1 = 0, cnt2 = 0;
    for (let c of text) {
        if (c == pattern[1]) {
            res += cnt1;
            cnt2++;
        }
        if (c == pattern[0]) {
            cnt1++;
        }
    }
    return res + Math.max(cnt1, cnt2);
};
```

```Go
func maximumSubsequenceCount(text string, pattern string) int64 {
    var res, cnt1, cnt2 int64
    for _, c := range text {
        if byte(c) == pattern[1] {
            res += cnt1
            cnt2++
        }
        if byte(c) == pattern[0] {
            cnt1++
        }
    }
    if cnt1 > cnt2 {
        return res + cnt1
    }
    return res + cnt2
}
```

```CSharp
public class Solution {
    public long MaximumSubsequenceCount(string text, string pattern) {
        long res = 0, cnt1 = 0, cnt2 = 0;
        foreach (char c in text) {
            if (c == pattern[1]) {
                res += cnt1;
                cnt2++;
            }
            if (c == pattern[0]) {
                cnt1++;
            }
        }
        return res + Math.Max(cnt1, cnt2);
    }
}
```

```C
long long maximumSubsequenceCount(char* text, char* pattern) {
    long long res = 0, cnt1 = 0, cnt2 = 0;
    for (const char *c = text; *c; c++) {
        if (*c == pattern[1]) {
            res += cnt1;
            cnt2++;
        }
        if (*c == pattern[0]) {
            cnt1++;
        }
    }
    return res + (cnt1 > cnt2 ? cnt1 : cnt2);
}
```

```Rust
impl Solution {
    pub fn maximum_subsequence_count(text: String, pattern: String) -> i64 {
        let mut res = 0;
        let mut cnt1 = 0;
        let mut cnt2 = 0;
        for c in text.chars() {
            if c == pattern.chars().nth(1).unwrap() {
                res += cnt1;
                cnt2 += 1;
            }
            if c == pattern.chars().nth(0).unwrap() {
                cnt1 += 1;
            }
        }
        res + std::cmp::max(cnt1, cnt2)
    }
}
```

```Cangjie
class Solution {
    func maximumSubsequenceCount(text: String, pattern: String): Int64 {
        var res = 0
        var cnt1 = 0
        var cnt2 = 0
        for (c in text) {
            if (c == pattern[1]) {
                res += cnt1
                cnt2++
            }
            if (c == pattern[0]) {
                cnt1++
            }
        }
        return res + max(cnt1, cnt2)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串的长度。
- 空间复杂度：$O(1)$。
