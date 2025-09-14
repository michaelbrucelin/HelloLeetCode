### [找到频率最高的元音和辅音](https://leetcode.cn/problems/find-most-frequent-vowel-and-consonant/solutions/3765771/zhao-dao-pin-lu-zui-gao-de-yuan-yin-he-f-3z68/)

#### 方法一：遍历

**思路与算法**

首先我们使用哈希表记录字符串中每种字符的出现次数，然后再遍历所有小写字母，分元音和辅音两种去统计出现的最大次数，最后求和就是答案。

**代码**

```C++
class Solution {
public:
    bool is_vowel(char c) {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
    int maxFreqSum(string s) {
        unordered_map<char, int> mp;
        for (auto ch : s) {
            mp[ch]++;
        }
        int vowel = 0, consonant = 0;
        for (char ch = 'a'; ch <= 'z'; ch++) {
            if (is_vowel(ch)) {
                vowel = max(vowel, mp[ch]);
            } else {
                consonant = max(consonant, mp[ch]);
            }
        }
        return vowel + consonant;
    }
};
```

```Python
from collections import Counter

class Solution:
    def maxFreqSum(self, s: str) -> int:
        mp = Counter(s)
        vowel = max((mp[ch] for ch in mp if ch in "aeiou"), default=0)
        consonant = max((mp[ch] for ch in mp if ch not in "aeiou"), default=0)
        return vowel + consonant
```

```Rust
impl Solution {
    fn is_vowel(c: usize) -> bool {
        matches!(c as u8 + b'a', b'a' | b'e' | b'i' | b'o' | b'u')
    }

    pub fn max_freq_sum(s: String) -> i32 {
        let mut freq = [0; 26];
        for ch in s.chars() {
            freq[(ch as u8 - b'a') as usize] += 1;
        }

        let (mut vowel, mut consonant) = (0, 0);
        for (i, &f) in freq.iter().enumerate() {
            if Self::is_vowel(i) {
                vowel = vowel.max(f);
            } else {
                consonant = consonant.max(f);
            }
        }
        vowel + consonant
    }
}
```

```Java
class Solution {
    public int maxFreqSum(String s) {
        Map<Character, Integer> mp = new HashMap<>();
        for (char ch : s.toCharArray()) {
            mp.put(ch, mp.getOrDefault(ch, 0) + 1);
        }
        int vowel = 0, consonant = 0;
        for (char ch = 'a'; ch <= 'z'; ch++) {
            if (isVowel(ch)) {
                vowel = Math.max(vowel, mp.getOrDefault(ch, 0));
            } else {
                consonant = Math.max(consonant, mp.getOrDefault(ch, 0));
            }
        }
        return vowel + consonant;
    }

    private boolean isVowel(char c) {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}
```

```CSharp
public class Solution {
    public int MaxFreqSum(string s) {
        Dictionary<char, int> mp = new Dictionary<char, int>();
        foreach (char ch in s) {
            if (mp.ContainsKey(ch)) {
                mp[ch]++;
            } else {
                mp[ch] = 1;
            }
        }
        int vowel = 0, consonant = 0;
        for (char ch = 'a'; ch <= 'z'; ch++) {
            int count = mp.ContainsKey(ch) ? mp[ch] : 0;
            if (IsVowel(ch)) {
                vowel = Math.Max(vowel, count);
            } else {
                consonant = Math.Max(consonant, count);
            }
        }
        return vowel + consonant;
    }

    private bool IsVowel(char c) {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}
```

```Go
func maxFreqSum(s string) int {
    mp := make(map[byte]int)
    for i := 0; i < len(s); i++ {
        mp[s[i]]++
    }
    
    vowel, consonant := 0, 0
    for ch := 'a'; ch <= 'z'; ch++ {
        count := mp[byte(ch)]
        if isVowel(byte(ch)) {
            vowel = max(vowel, count)
        } else {
            consonant = max(consonant, count)
        }
    }
    return vowel + consonant
}

func isVowel(c byte) bool {
    return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
}
```

```C
int is_vowel(char c) {
    return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
}

int maxFreqSum(char* s) {
    int mp[26] = {0};
    for (int i = 0; s[i] != '\0'; i++) {
        mp[s[i] - 'a']++;
    }
    
    int vowel = 0, consonant = 0;
    for (char ch = 'a'; ch <= 'z'; ch++) {
        if (is_vowel(ch)) {
            vowel = fmax(vowel, mp[ch - 'a']);
        } else {
            consonant = fmax(consonant, mp[ch - 'a']);
        }
    }
    return vowel + consonant;
}
```

```JavaScript
var maxFreqSum = function(s) {
    const isVowel = (c) => {
        return c === 'a' || c === 'e' || c === 'i' || c === 'o' || c === 'u';
    };

    const mp = {};
    for (const ch of s) {
        mp[ch] = (mp[ch] || 0) + 1;
    }
    
    let vowel = 0, consonant = 0;
    for (let ch = 'a'.charCodeAt(0); ch <= 'z'.charCodeAt(0); ch++) {
        const char = String.fromCharCode(ch);
        const count = mp[char] || 0;
        if (isVowel(char)) {
            vowel = Math.max(vowel, count);
        } else {
            consonant = Math.max(consonant, count);
        }
    }
    return vowel + consonant;
};
```

```TypeScript
function maxFreqSum(s: string): number {
    const isVowel = (c) => {
        return c === 'a' || c === 'e' || c === 'i' || c === 'o' || c === 'u';
    };

    const mp: {[key: string]: number} = {};
    for (const ch of s) {
        mp[ch] = (mp[ch] || 0) + 1;
    }
    
    let vowel = 0, consonant = 0;
    for (let ch = 'a'.charCodeAt(0); ch <= 'z'.charCodeAt(0); ch++) {
        const char = String.fromCharCode(ch);
        const count = mp[char] || 0;
        if (isVowel(char)) {
            vowel = Math.max(vowel, count);
        } else {
            consonant = Math.max(consonant, count);
        }
    }
    return vowel + consonant;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(C)$，其中 $C$ 是字符集的大小，这里是 $26$。
