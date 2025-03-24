### [统计是给定字符串前缀的字符串数目](https://leetcode.cn/problems/count-prefixes-of-a-given-string/solutions/1486081/tong-ji-shi-gei-ding-zi-fu-chuan-qian-zh-vpyg/)

#### 方法一：遍历判断

**思路与算法**

我们可以遍历 $words$ 数组，并判断每个字符串 $word$ 是否是 $s$ 的前缀。与此同时，我们用 $res$ 来维护包含前缀字符串的数量。如果 $word$ 是 $s$ 的前缀，则我们将 $res$ 加上 $1$。最终，我们返回 $res$ 作为答案。

关于判断 $word$ 是否为 $s$ 的前缀，某些语言如 $Python$ 有字符串对应的 $startswith()$ 方法。对于没有类似方法的语言，我们也可以手动实现以达到相似的效果。

具体地，我们用函数 $isPrefix(word)$ 来实现这一判断。首先当 $s$ 的长度小于 $word$ 时，$word$ 一定不可能是 $s$ 的前缀，此时返回 $false$。随后，我们从头开始逐字符判断 $word$ 和 $s$ 的对应字符是否相等。如果某个字符不相等，同样返回 $false$。如果遍历完成 $word$ 后所有字符均相等，则返回 $true$。

**代码**

```C++
class Solution {
public:
    int countPrefixes(vector<string>& words, string s) {
        int res = 0;   // 符合要求字符串个数
        // 判断 word 是否是 s 的前缀
        auto isPrefix = [&](const string& word) -> bool {
            if (s.size() < word.size()) {
                return false;
            }
            for (int i = 0; i < word.size(); ++i) {
                if (word[i] != s[i]) {
                    return false;
                }
            }
            return true;
        };
        
        for (const string& word: words) {
            if (isPrefix(word)) {
                ++res;
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def countPrefixes(self, words: List[str], s: str) -> int:
        res = 0   # 符合要求字符串个数
        for word in words:
            if s.startswith(word):
                res += 1
        return res
```

```Java
class Solution {
    public int countPrefixes(String[] words, String s) {
        int res = 0;
        for (String word : words) {
            if (s.startsWith(word)) {
                res++;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountPrefixes(string[] words, string s) {
        int res = 0;
        foreach (var word in words) {
            if (s.StartsWith(word)) {
                res++;
            }
        }
        return res;
    }
}
```

```Go
func countPrefixes(words []string, s string) int {
    res := 0
    for _, word := range words {
        if len(s) >= len(word) && s[:len(word)] == word {
            res++
        }
    }
    return res
}
```

```C
int countPrefixes(char** words, int wordsSize, char* s) {
    int res = 0;
    for (int i = 0; i < wordsSize; i++) {
        if (strncmp(s, words[i], strlen(words[i])) == 0) {
            res++;
        }
    }
    return res;
}
```

```JavaScript
var countPrefixes = function(words, s) {
    let res = 0;
    for (let word of words) {
        if (s.startsWith(word)) {
            res++;
        }
    }
    return res;
};
```

```TypeScript
function countPrefixes(words: string[], s: string): number {
    let res = 0;
    for (let word of words) {
        if (s.startsWith(word)) {
            res++;
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn count_prefixes(words: Vec<String>, s: String) -> i32 {
        let mut res = 0;
        for word in words {
            if s.starts_with(&word) {
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 为 $words$ 数组的长度，$n$ 为字符串 $s$ 的长度。每判断 $words$ 中一个字符串的时间复杂度为 $O(n)$，我们总共需要判断 $m$ 次。
- 空间复杂度：$O(1)$。
