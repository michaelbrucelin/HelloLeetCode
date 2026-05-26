### [统计特殊字母的数量 II](https://leetcode.cn/problems/count-the-number-of-special-characters-ii/solutions/3963835/tong-ji-te-shu-zi-mu-de-shu-liang-ii-by-nqseu/)

#### 方法一：记录首尾位置

对于每个字母，记录其小写形式的最后一次出现位置和大写形式的第一次出现位置。当且仅当两者都存在，且小写的最后出现位置严格小于大写的第一次出现位置时，该字母为特殊字母。

```C++
class Solution {
public:
    int numberOfSpecialChars(string word) {
        vector<int> lastLow(26, -1), firstUp(26, -1);
        for (int i = 0; i < word.size(); i++) {
            char c = word[i];
            if (islower(c)) {
                lastLow[c - 'a'] = i;
            } else {
                if (firstUp[c - 'A'] == -1) {
                    firstUp[c - 'A'] = i;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < 26; i++) {
            if (lastLow[i] != -1 && firstUp[i] != -1 && lastLow[i] < firstUp[i]) {
                ans++;
            }
        }
        return ans;
    }
};
```

```Go
func numberOfSpecialChars(word string) int {
    lastLow := [26]int{}
    firstUp := [26]int{}
    for i := range lastLow {
        lastLow[i] = -1
        firstUp[i] = -1
    }
    for i, c := range word {
        if c >= 'a' && c <= 'z' {
            lastLow[c - 'a'] = i
        } else {
            if firstUp[c - 'A'] == -1 {
                firstUp[c - 'A'] = i
            }
        }
    }
    ans := 0
    for i := 0; i < 26; i++ {
        if lastLow[i] != -1 && firstUp[i] != -1 && lastLow[i] < firstUp[i] {
            ans++
        }
    }
    return ans
}
```

```Python
class Solution:
    def numberOfSpecialChars(self, word: str) -> int:
        last_low = {}
        first_up = {}
        for i, c in enumerate(word):
            if c.islower():
                last_low[c] = i
            else:
                if c not in first_up:
                    first_up[c] = i
        ans = 0
        for c in string.ascii_lowercase:
            if c in last_low and c.upper() in first_up and last_low[c] < first_up[c.upper()]:
                ans += 1
        return ans
```

```Java
class Solution {
    public int numberOfSpecialChars(String word) {
        int[] lastLow = new int[26];
        int[] firstUp = new int[26];
        Arrays.fill(lastLow, -1);
        Arrays.fill(firstUp, -1);
        for (int i = 0; i < word.length(); i++) {
            char c = word.charAt(i);
            if (Character.isLowerCase(c)) {
                lastLow[c - 'a'] = i;
            } else {
                if (firstUp[c - 'A'] == -1) {
                    firstUp[c - 'A'] = i;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < 26; i++) {
            if (lastLow[i] != -1 && firstUp[i] != -1 && lastLow[i] < firstUp[i]) {
                ans++;
            }
        }
        return ans;
    }
}
```

```TypeScript
function numberOfSpecialChars(word: string): number {
    const lastLow = new Array(26).fill(-1);
    const firstUp = new Array(26).fill(-1);
    for (let i = 0; i < word.length; i++) {
        const c = word[i];
        if (c >= 'a' && c <= 'z') {
            lastLow[c.charCodeAt(0) - 97] = i;
        } else {
            const idx = c.charCodeAt(0) - 65;
            if (firstUp[idx] === -1) firstUp[idx] = i;
        }
    }
    let ans = 0;
    for (let i = 0; i < 26; i++) {
        if (lastLow[i] !== -1 && firstUp[i] !== -1 && lastLow[i] < firstUp[i]) {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var numberOfSpecialChars = function(word) {
    const lastLow = new Array(26).fill(-1);
    const firstUp = new Array(26).fill(-1);
    for (let i = 0; i < word.length; i++) {
        const c = word[i];
        if (c >= 'a' && c <= 'z') {
            lastLow[c.charCodeAt(0) - 97] = i;
        } else {
            const idx = c.charCodeAt(0) - 65;
            if (firstUp[idx] === -1) firstUp[idx] = i;
        }
    }
    let ans = 0;
    for (let i = 0; i < 26; i++) {
        if (lastLow[i] !== -1 && firstUp[i] !== -1 && lastLow[i] < firstUp[i]) {
            ans++;
        }
    }
    return ans;
};
```

```CSharp
public class Solution {
    public int NumberOfSpecialChars(string word) {
        int[] lastLow = new int[26];
        int[] firstUp = new int[26];
        Array.Fill(lastLow, -1);
        Array.Fill(firstUp, -1);
        for (int i = 0; i < word.Length; i++) {
            char c = word[i];
            if (char.IsLower(c)) {
                lastLow[c - 'a'] = i;
            } else {
                if (firstUp[c - 'A'] == -1) {
                    firstUp[c - 'A'] = i;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < 26; i++) {
            if (lastLow[i] != -1 && firstUp[i] != -1 && lastLow[i] < firstUp[i]) {
                ans++;
            }
        }
        return ans;
    }
}
```

```C
int numberOfSpecialChars(char* word) {
    int lastLow[26], firstUp[26];
    memset(lastLow, -1, sizeof(lastLow));
    memset(firstUp, -1, sizeof(firstUp));
    for (int i = 0; word[i]; i++) {
        char c = word[i];
        if (c >= 'a' && c <= 'z') {
            lastLow[c - 'a'] = i;
        } else {
            if (firstUp[c - 'A'] == -1) {
                firstUp[c - 'A'] = i;
            }
        }
    }
    int ans = 0;
    for (int i = 0; i < 26; i++) {
        if (lastLow[i] != -1 && firstUp[i] != -1 && lastLow[i] < firstUp[i]) {
            ans++;
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn number_of_special_chars(word: String) -> i32 {
        let mut last_low = [-1i32; 26];
        let mut first_up = [-1i32; 26];
        for (i, c) in word.chars().enumerate() {
            if c.is_ascii_lowercase() {
                last_low[(c as u8 - b'a') as usize] = i as i32;
            } else {
                let idx = (c as u8 - b'A') as usize;
                if first_up[idx] == -1 {
                    first_up[idx] = i as i32;
                }
            }
        }
        let mut ans = 0;
        for i in 0..26 {
            if last_low[i] != -1 && first_up[i] != -1 && last_low[i] < first_up[i] {
                ans += 1;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+\vert \sum \vert)$，其中 $n$ 是字符串长度，$\vert \sum \vert =26$。
- 空间复杂度：$O(\vert \sum \vert)$。
