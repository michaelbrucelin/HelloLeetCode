### [有效单词](https://leetcode.cn/problems/valid-word/solutions/3717148/you-xiao-dan-ci-by-leetcode-solution-qege/)

#### 方法一：一次遍历

**思路与算法**

首先，我们可以判断给定的单词长度是否大于等于 $3$，其次我们需要通过一次遍历来判断是否包含元音字母、辅音字母以及除去数字和大小写字母以外的其他字母。

**代码**

```C++
class Solution {
public:
    bool isValid(string word) {
        if (word.size() < 3) {
            return false;
        }
        bool has_vowel = false;
        bool has_consonant = false;
        for (auto c : word) {
            if (isalpha(c)) {
                c = tolower(c);
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') {
                    has_vowel = true;
                } else {
                    has_consonant = true;
                }
            } else if (!isdigit(c)) {
                return false;
            }
        }
        return has_vowel && has_consonant;
    }
};
```

```Python
class Solution:
    def isValid(self, word: str) -> bool:
        if len(word) < 3:
            return False

        has_vowel = False
        has_consonant = False

        for c in word:
            if c.isalpha():
                if c.lower() in 'aeiou':
                    has_vowel = True
                else:
                    has_consonant = True
            elif not c.isdigit():
                return False

        return has_vowel and has_consonant
```

```Rust
impl Solution {
    pub fn is_valid(word: String) -> bool {
        if word.len() < 3 {
            return false;
        }

        let mut has_vowel = false;
        let mut has_consonant = false;

        for c in word.chars() {
            if c.is_ascii_alphabetic() {
                let lc = c.to_ascii_lowercase();
                if "aeiou".contains(lc) {
                    has_vowel = true;
                } else {
                    has_consonant = true;
                }
            } else if !c.is_ascii_digit() {
                return false;
            }
        }

        has_vowel && has_consonant
    }
}
```

```Java
class Solution {
    public boolean isValid(String word) {
        if (word.length() < 3) {
            return false;
        }
        boolean hasVowel = false;
        boolean hasConsonant = false;
        for (char c : word.toCharArray()) {
            if (Character.isLetter(c)) {
                char ch = Character.toLowerCase(c);
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u') {
                    hasVowel = true;
                } else {
                    hasConsonant = true;
                }
            } else if (!Character.isDigit(c)) {
                return false;
            }
        }
        return hasVowel && hasConsonant;
    }
}
```

```CSharp
public class Solution {
    public bool IsValid(string word) {
        if (word.Length < 3) {
            return false;
        }
        bool hasVowel = false;
        bool hasConsonant = false;
        foreach (char c in word) {
            if (char.IsLetter(c)) {
                char ch = char.ToLower(c);
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u') {
                    hasVowel = true;
                } else {
                    hasConsonant = true;
                }
            } else if (!char.IsDigit(c)) {
                return false;
            }
        }
        return hasVowel && hasConsonant;
    }
}
```

```Go
func isValid(word string) bool {
    if len(word) < 3 {
        return false
    }
    hasVowel := false
    hasConsonant := false
    for _, c := range word {
        if unicode.IsLetter(c) {
            ch := unicode.ToLower(c)
            if ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' {
                hasVowel = true
            } else {
                hasConsonant = true
            }
        } else if !unicode.IsDigit(c) {
            return false
        }
    }
    return hasVowel && hasConsonant
}
```

```C
bool isValid(char* word) {
    int len = strlen(word);
    if (len < 3) {
        return false;
    }
    bool has_vowel = false;
    bool has_consonant = false;
    for (int i = 0; i < len; i++) {
        char c = word[i];
        if (isalpha(c)) {
            c = tolower(c);
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') {
                has_vowel = true;
            } else {
                has_consonant = true;
            }
        } else if (!isdigit(c)) {
            return false;
        }
    }
    return has_vowel && has_consonant;
}
```

```JavaScript
var isValid = function(word) {
    if (word.length < 3) {
        return false;
    }
    let hasVowel = false;
    let hasConsonant = false;
    for (const c of word) {
        if (/[a-zA-Z]/.test(c)) {
            const ch = c.toLowerCase();
            if (ch === 'a' || ch === 'e' || ch === 'i' || ch === 'o' || ch === 'u') {
                hasVowel = true;
            } else {
                hasConsonant = true;
            }
        } else if (!/\d/.test(c)) {
            return false;
        }
    }
    return hasVowel && hasConsonant;
};
```

```TypeScript
function isValid(word: string): boolean {
    if (word.length < 3) {
        return false;
    }
    let hasVowel = false;
    let hasConsonant = false;
    for (const c of word) {
        if (/[a-zA-Z]/.test(c)) {
            const ch = c.toLowerCase();
            if (ch === 'a' || ch === 'e' || ch === 'i' || ch === 'o' || ch === 'u') {
                hasVowel = true;
            } else {
                hasConsonant = true;
            }
        } else if (!/\d/.test(c)) {
            return false;
        }
    }
    return hasVowel && hasConsonant;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $word$ 的长度。由于只进行了一次遍历，因此时间复杂度为 $O(n)$。
- 空间复杂度：$O(1)$。
