### [可以输入的最大单词数](https://leetcode.cn/problems/maximum-number-of-words-you-can-type/solutions/883398/ke-yi-shu-ru-de-zui-da-dan-ci-shu-by-lee-5dpc/)

#### 方法一：遍历 $+$ 哈希表

**思路与算法**

我们可以遍历字符串 $text$ 统计可以完全输入的单词数目。

为了方便判断某个字符是否可被输入，我们用哈希集合维护因为损坏而无法输入的字符。同时，我们引入布尔变量 $flag$ 来表示当前字符所对应的单词是否可以被完全输入。$flag$ 初值为 $true$，当取值为 $true$ 时代表当前单词可被完全输入，当取值为 $false$ 时则不可以。

在遍历字符串时，根据当前字符的不同，会有三种情况：

- 当前字符为空格，此时代表上一个单词已经结束。如果此时 $flag$ 为 $true$ 则代表上一个单词可以被完全输入，我们需要将可以完全输入的单词数目加上 $1$。除此以外，我们还需要将 $flag$ 重置为初值 $true$。
- 当前字符为字母且不可被输入，那么当前字符所在单词不可被完全输入。我们需要将 $flag$ 置为 $false$。
- 当前字符为字母且可被输入，此时无需进行任何操作。

注意在遍历结束后，我们还要检查 $flag$ 以判断最后一个单词是否可被完全输入并更新可以完全输入的单词数目。最终，我们返回该数目作为答案。

**代码**

```C++
class Solution {
public:
    int canBeTypedWords(string text, string brokenLetters) {
        unordered_set<char> broken;   // 无法输入的字符集合
        for (char ch: brokenLetters){
            broken.insert(ch);
        }
        int res = 0;   // 可以完全输入的单词数目
        bool flag = true;   // 当前字符所在单词是否可被完全输入
        for (char ch: text){
            if (ch == ' '){
                // 当前字符为空格，检查上一个单词状态，更新数目并初始化 flag
                if (flag){
                    ++res;
                }
                flag = true;
            }
            else if (broken.count(ch)){
                // 当前字符不可被输入，所在单词无法被完全输入，更新 flag
                flag = false;
            }
        }
        // 判断最后一个单词状态并更新数目
        if (flag){
            ++res;
        }
        return res;
    }
};
```

```Python
class Solution:
    def canBeTypedWords(self, text: str, brokenLetters: str) -> int:
        broken = set(brokenLetters)   # 无法输入的字符集合
        res = 0   # 可以完全输入的单词数目
        flag = True   # 当前字符所在单词是否可被完全输入
        for ch in text:
            if ch == ' ':
                # 当前字符为空格，检查上一个单词状态，更新数目并初始化 flag
                if flag:
                    res += 1
                flag = True
            elif ch in broken:
                # 当前字符不可被输入，所在单词无法被完全输入，更新 flag
                flag = False
        # 判断最后一个单词状态并更新数目
        if flag:
            res += 1
        return res
```

```Java
class Solution {
    public int canBeTypedWords(String text, String brokenLetters) {
        Set<Character> broken = new HashSet<>();   // 无法输入的字符集合
        for (char ch : brokenLetters.toCharArray()) {
            broken.add(ch);
        }
        int res = 0;   // 可以完全输入的单词数目
        boolean flag = true;   // 当前字符所在单词是否可被完全输入
        for (char ch : text.toCharArray()) {
            if (ch == ' ') {
                // 当前字符为空格，检查上一个单词状态，更新数目并初始化 flag
                if (flag) {
                    ++res;
                }
                flag = true;
            } else if (broken.contains(ch)) {
                // 当前字符不可被输入，所在单词无法被完全输入，更新 flag
                flag = false;
            }
        }
        // 判断最后一个单词状态并更新数目
        if (flag) {
            ++res;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CanBeTypedWords(string text, string brokenLetters) {
        HashSet<char> broken = new HashSet<char>();   // 无法输入的字符集合
        foreach (char ch in brokenLetters) {
            broken.Add(ch);
        }
        int res = 0;   // 可以完全输入的单词数目
        bool flag = true;   // 当前字符所在单词是否可被完全输入
        foreach (char ch in text) {
            if (ch == ' ') {
                // 当前字符为空格，检查上一个单词状态，更新数目并初始化 flag
                if (flag) {
                    ++res;
                }
                flag = true;
            } else if (broken.Contains(ch)) {
                // 当前字符不可被输入，所在单词无法被完全输入，更新 flag
                flag = false;
            }
        }
        // 判断最后一个单词状态并更新数目
        if (flag) {
            ++res;
        }
        return res;
    }
}
```

```Go
func canBeTypedWords(text string, brokenLetters string) int {
    broken := make(map[rune]bool)   // 无法输入的字符集合
    for _, ch := range brokenLetters {
        broken[ch] = true
    }
    res := 0   // 可以完全输入的单词数目
    flag := true   // 当前字符所在单词是否可被完全输入
    for _, ch := range text {
        if ch == ' ' {
            // 当前字符为空格，检查上一个单词状态，更新数目并初始化 flag
            if flag {
                res++
            }
            flag = true
        } else if broken[ch] {
            // 当前字符不可被输入，所在单词无法被完全输入，更新 flag
            flag = false
        }
    }
    // 判断最后一个单词状态并更新数目
    if flag {
        res++
    }
    return res
}
```

```C
int canBeTypedWords(char* text, char* brokenLetters) {
    bool broken[26] = {false};   // 无法输入的字符集合
    for (int i = 0; brokenLetters[i]; i++) {
        broken[brokenLetters[i] - 'a'] = true;
    }
    int res = 0;   // 可以完全输入的单词数目
    bool flag = true;   // 当前字符所在单词是否可被完全输入
    for (int i = 0; text[i]; i++) {
        if (text[i] == ' ') {
            // 当前字符为空格，检查上一个单词状态，更新数目并初始化 flag
            if (flag) {
                ++res;
            }
            flag = true;
        } else if (broken[text[i] - 'a']) {
            // 当前字符不可被输入，所在单词无法被完全输入，更新 flag
            flag = false;
        }
    }
    // 判断最后一个单词状态并更新数目
    if (flag) {
        ++res;
    }
    return res;
}
```

```JavaScript
var canBeTypedWords = function(text, brokenLetters) {
    const broken = new Set();   // 无法输入的字符集合
    for (const ch of brokenLetters) {
        broken.add(ch);
    }
    let res = 0;   // 可以完全输入的单词数目
    let flag = true;   // 当前字符所在单词是否可被完全输入
    for (const ch of text) {
        if (ch === ' ') {
            // 当前字符为空格，检查上一个单词状态，更新数目并初始化 flag
            if (flag) {
                ++res;
            }
            flag = true;
        } else if (broken.has(ch)) {
            // 当前字符不可被输入，所在单词无法被完全输入，更新 flag
            flag = false;
        }
    }
    // 判断最后一个单词状态并更新数目
    if (flag) {
        ++res;
    }
    return res;
};
```

```TypeScript
function canBeTypedWords(text: string, brokenLetters: string): number {
    const broken = new Set<string>();   // 无法输入的字符集合
    for (const ch of brokenLetters) {
        broken.add(ch);
    }
    let res = 0;   // 可以完全输入的单词数目
    let flag = true;   // 当前字符所在单词是否可被完全输入
    for (const ch of text) {
        if (ch === ' ') {
            // 当前字符为空格，检查上一个单词状态，更新数目并初始化 flag
            if (flag) {
                ++res;
            }
            flag = true;
        } else if (broken.has(ch)) {
            // 当前字符不可被输入，所在单词无法被完全输入，更新 flag
            flag = false;
        }
    }
    // 判断最后一个单词状态并更新数目
    if (flag) {
        ++res;
    }
    return res;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn can_be_typed_words(text: String, broken_letters: String) -> i32 {
        let broken: HashSet<char> = broken_letters.chars().collect();   // 无法输入的字符集合
        let mut res = 0;   // 可以完全输入的单词数目
        let mut flag = true;   // 当前字符所在单词是否可被完全输入
        for ch in text.chars() {
            if ch == ' ' {
                // 当前字符为空格，检查上一个单词状态，更新数目并初始化 flag
                if flag {
                    res += 1;
                }
                flag = true;
            } else if broken.contains(&ch) {
                // 当前字符不可被输入，所在单词无法被完全输入，更新 flag
                flag = false;
            }
        }
        // 判断最后一个单词状态并更新数目
        if flag {
            res += 1;
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 为 $text$ 的长度，$ m$ 为无法输入字符的数目。维护无法输入字符哈希集合的时间复杂度为 $O(m)$，遍历 $text$ 计算可以完全输入单词数目的时间复杂度为 $O(n)$。
- 空间复杂度：$O(1)$。
