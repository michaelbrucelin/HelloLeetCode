### [元音辅音字符串计数 I](https://leetcode.cn/problems/count-of-substrings-containing-every-vowel-and-k-consonants-i/solutions/3077748/yuan-yin-fu-yin-zi-fu-chuan-ji-shu-i-by-r8rjy/)

#### 方法一：暴力枚举

枚举字符串 $word$ 的所有子字符串，统计每个元音字母都出现且辅音字母出现次数等于 $k$ 的子字符串数目。

```C++
class Solution {
public:
    long long countOfSubstrings(string word, int k) {
        set<char> vowels = {'a', 'e', 'i', 'o', 'u'};
        int n = word.size();
        long long res = 0;
        for (int i = 0; i < n; i++) {
            set<char> occur;
            int consonants = 0;
            for (int j = i; j < n; j++) {
                if (vowels.count(word[j])) {
                    occur.insert(word[j]);
                } else {
                    consonants++;
                }
                if (occur.size() == vowels.size() && consonants == k) {
                    res++;
                }
            }
        }
        return res;
    }
};
```

```Go
func countOfSubstrings(word string, k int) int {
    vowels := map[byte]bool{'a': true, 'e': true, 'i': true, 'o': true, 'u': true}
    n := len(word)
    res := 0
    for i := 0; i < n; i++ {
        occur := map[byte]bool{}
        consonants := 0
        for j := i; j < n; j++ {
            if vowels[word[j]] {
                occur[word[j]] = true
            } else {
                consonants++
            }
            if len(occur) == 5 && consonants == k {
                res++
            }
        }
    }
    return res
}
```

```Python
class Solution:
    def countOfSubstrings(self, word: str, k: int) -> int:
        vowels = {'a', 'e', 'i', 'o', 'u'}
        n = len(word)
        res = 0
        for i in range(n):
            occur = set()
            consonants = 0
            for j in range(i, n):
                if word[j] in vowels:
                    occur.add(word[j])
                else:
                    consonants += 1
                if len(occur) == 5 and consonants == k:
                    res += 1
        return res
```

```Java
class Solution {
    public int countOfSubstrings(String word, int k) {
        Set<Character> vowels = new HashSet<>();
        vowels.add('a');
        vowels.add('e');
        vowels.add('i');
        vowels.add('o');
        vowels.add('u');
        int n = word.length();
        int res = 0;
        for (int i = 0; i < n; i++) {
            Set<Character> occur = new HashSet<>();
            int consonants = 0;
            for (int j = i; j < n; j++) {
                if (vowels.contains(word.charAt(j))) {
                    occur.add(word.charAt(j));
                } else {
                    consonants++;
                }
                if (occur.size() == 5 && consonants == k) {
                    res++;
                }
            }
        }
        return res;
    }
}
```

```JavaScript
var countOfSubstrings = function(word, k) {
    const vowels = new Set(['a', 'e', 'i', 'o', 'u']);
    let n = word.length;
    let res = 0;
    for (let i = 0; i < n; i++) {
        let occur = new Set();
        let consonants = 0;
        for (let j = i; j < n; j++) {
            if (vowels.has(word[j])) {
                occur.add(word[j]);
            } else {
                consonants++;
            }
            if (occur.size === 5 && consonants === k) {
                res++;
            }
        }
    }
    return res;
};
```

```TypeScript
function countOfSubstrings(word: string, k: number): number {
    const vowels = new Set(['a', 'e', 'i', 'o', 'u']);
    let n = word.length;
    let res = 0;
    for (let i = 0; i < n; i++) {
        let occur = new Set<string>();
        let consonants = 0;
        for (let j = i; j < n; j++) {
            if (vowels.has(word[j])) {
                occur.add(word[j]);
            } else {
                consonants++;
            }
            if (occur.size === 5 && consonants === k) {
                res++;
            }
        }
    }
    return res;
}
```

```C
char vowels[] = {'a', 'e', 'i', 'o', 'u'};

bool isVowel(char c) {
    for (int i = 0; i < 5; i++) {
        if (c == vowels[i]) {
            return true;
        }
    }
    return false;
}

int countOfSubstrings(char* word, int k) {
    int n = strlen(word);
    int res = 0;
    for (int i = 0; i < n; i++) {
        int occur[26] = {0};
        int consonants = 0, vowelCount = 0;
        for (int j = i; j < n; j++) {
            if (isVowel(word[j])) {
                occur[word[j] - 'a']++;
                vowelCount += occur[word[j] - 'a'] == 1;
            } else {
                consonants++;
            }
            if (vowelCount == 5 && consonants == k) {
                res++;
            }
        }
    }
    return res;
}
```

```CSharp
public class Solution {
    public int CountOfSubstrings(string word, int k) {
        HashSet<char> vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u'};
        int n = word.Length;
        int res = 0;
        for (int i = 0; i < n; i++) {
            HashSet<char> occur = new HashSet<char>();
            int consonants = 0;
            for (int j = i; j < n; j++) {
                if (vowels.Contains(word[j])) {
                    occur.Add(word[j]);
                } else {
                    consonants++;
                }
                if (occur.Count == 5 && consonants == k) {
                    res++;
                }
            }
        }
        return res;
    }
}
```

```Rust
use std::collections::HashSet;
impl Solution {
    pub fn count_of_substrings(word: String, k: i32) -> i32 {
        let vowels = HashSet::from(['a', 'e', 'i', 'o', 'u']);
        let n = word.len();
        let mut res = 0;
        for i in 0..n {
            let mut occur = HashSet::new();
            let mut consonants = 0;
            for j in i..n {
                if vowels.contains(&word[j..j+1].chars().next().unwrap()) {
                    occur.insert(word[j..j+1].chars().next().unwrap());
                } else {
                    consonants += 1;
                }
                if occur.len() == 5 && consonants == k {
                    res += 1;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $word$ 的长度。
- 空间复杂度：$O(1)$。

#### 方法二：滑动窗口

令 $count(k)$ 表示每个元音字母至少出现一次，并且至少包含 $k$ 个辅音字母的子字符串的总数，那么本问题的答案等于 $count(k)-count(k+1)$。对于 $count(k)$，我们可以使用滑动窗口来求解。

对于区间 $[i,j)$ 内的子字符串，我们依次枚举子字符串的左端点 $i$，对于对应的右端点 $j$，我们不断地右移右端点 $j$，直到区间 $[i,j)$ 对应的子字符满足每个元音字母至少出现一次，并且至少包含 $k$ 个辅音字母，或者 $j=n$。右移操作完成后，如果区间 $[i,j)$ 内的子字符串满足每个元音字母至少出现一次，并且至少包含 $k$ 个辅音字母，那么左端点为 $i$ 的子字符串满足条件的数目为 $n-j+1$。$count(k)$ 即为所有数目之和。

```C++
class Solution {
public:
    long long countOfSubstrings(string word, int k) {
        set<char> vowels = {'a', 'e', 'i', 'o', 'u'};
        auto count = [&](int m) -> long long {
            int n = word.size(), consonants = 0;
            long long res = 0;
            map<char, int> occur;
            for (int i = 0, j = 0; i < n; i++) {
                while (j < n && (consonants < m || occur.size() < vowels.size())) {
                    if (vowels.count(word[j])) {
                        occur[word[j]]++;
                    } else {
                        consonants++;
                    }
                    j++;
                }
                if (consonants >= m && occur.size() == vowels.size()) {
                    res += n - j + 1;
                }
                if (vowels.count(word[i])) {
                    occur[word[i]]--;
                    if (occur[word[i]] == 0) {
                        occur.erase(word[i]);
                    }
                } else {
                    consonants--;
                }
            }
            return res;
        };
        return count(k) - count(k + 1);
    }
};
```

```Go
func countOfSubstrings(word string, k int) int64 {
    vowels := map[byte]bool{'a': true, 'e': true, 'i': true, 'o': true, 'u': true}
    count := func(m int) int64 {
        n := len(word)
        var res int64 = 0
        consonants := 0
        occur := make(map[byte]int)
        for i, j := 0, 0; i < n; i++ {
            for j < n && (consonants < m || len(occur) < 5) {
                if vowels[word[j]] {
                    occur[word[j]]++
                } else {
                    consonants++
                }
                j++
            }
            if consonants >= m && len(occur) == 5 {
                res += int64(n - j + 1)
            }
            if vowels[word[i]] {
                occur[word[i]]--
                if occur[word[i]] == 0 {
                    delete(occur, word[i])
                }
            } else {
                consonants--
            }
        }
        return res
    }
    return count(k) - count(k+1)
}
```

```Python
class Solution:
    def countOfSubstrings(self, word: str, k: int) -> int:
        vowels = {'a', 'e', 'i', 'o', 'u'}
        def count(m: int) -> int:
            n, res, consonants = len(word), 0, 0
            occur = {}
            j = 0
            for i in range(n):
                while j < n and (consonants < m or len(occur) < 5):
                    if word[j] in vowels:
                        occur[word[j]] = occur.get(word[j], 0) + 1
                    else:
                        consonants += 1
                    j += 1
                if consonants >= m and len(occur) == 5:
                    res += n - j + 1
                if word[i] in vowels:
                    occur[word[i]] -= 1
                    if occur[word[i]] == 0:
                        del occur[word[i]]
                else:
                    consonants -= 1
            return res
        return count(k) - count(k + 1)
```

```Java
class Solution {
    public long count(String word, int m) {
        Set<Character> vowels = Set.of('a', 'e', 'i', 'o', 'u');
        int n = word.length(), consonants = 0;
        long res = 0;
        Map<Character, Integer> occur = new HashMap<>();
        int j = 0;
        for (int i = 0; i < n; i++) {
            while (j < n && (consonants < m || occur.size() < 5)) {
                char ch = word.charAt(j);
                if (vowels.contains(ch)) {
                    occur.put(ch, occur.getOrDefault(ch, 0) + 1);
                } else {
                    consonants++;
                }
                j++;
            }
            if (consonants >= m && occur.size() == 5) {
                res += n - j + 1;
            }
            char left = word.charAt(i);
            if (vowels.contains(left)) {
                occur.put(left, occur.get(left) - 1);
                if (occur.get(left) == 0) {
                    occur.remove(left);
                }
            } else {
                consonants--;
            }
        }
        return res;
    }

    public long countOfSubstrings(String word, int k) {
        return count(word, k) - count(word, k + 1);
    }
}
```

```JavaScript
var countOfSubstrings = function(word, k) {
    const vowels = new Set(['a', 'e', 'i', 'o', 'u']);
    const count = (m) => {
        let n = word.length, consonants = 0, res = 0;
        let occur = new Map();
        for (let i = 0, j = 0; i < n; i++) {
            while (j < n && (consonants < m || occur.size < 5)) {
                let ch = word[j];
                if (vowels.has(ch)) {
                    occur.set(ch, (occur.get(ch) || 0) + 1);
                } else {
                    consonants++;
                }
                j++;
            }
            if (consonants >= m && occur.size === 5) {
                res += n - j + 1;
            }
            let left = word[i];
            if (vowels.has(left)) {
                occur.set(left, occur.get(left) - 1);
                if (occur.get(left) === 0) {
                    occur.delete(left);
                }
            } else {
                consonants--;
            }
        }
        return res;
    };
    return count(k) - count(k + 1);
};
```

```TypeScript
function countOfSubstrings(word: string, k: number): number {
    const vowels = new Set(['a', 'e', 'i', 'o', 'u']);
    const count = (m: number): number => {
        let n = word.length, consonants = 0, res = 0;
        let occur = new Map<string, number>();
        for (let i = 0, j = 0; i < n; i++) {
            while (j < n && (consonants < m || occur.size < 5)) {
                let ch = word[j];
                if (vowels.has(ch)) {
                    occur.set(ch, (occur.get(ch) || 0) + 1);
                } else {
                    consonants++;
                }
                j++;
            }
            if (consonants >= m && occur.size === 5) {
                res += n - j + 1;
            }
            let left = word[i];
            if (vowels.has(left)) {
                occur.set(left, occur.get(left)! - 1);
                if (occur.get(left) === 0) {
                    occur.delete(left);
                }
            } else {
                consonants--;
            }
        }
        return res;
    };
    return count(k) - count(k + 1);
}
```

```C
bool isVowel(char ch) {
    return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
}

long long count(char* word, int k) {
    int n = strlen(word);
    long long res = 0;
    int consonants = 0;
    int occur[26] = {0};
    int vowelCount = 0;
    for (int i = 0, j = 0; i < n; i++) {
        while (j < n && (consonants < k || vowelCount < 5)) {
            if (isVowel(word[j])) {
                occur[word[j] - 'a']++;
                vowelCount += occur[word[j] - 'a'] == 1;
            } else {
                consonants++;
            }
            j++;
        }
        if (consonants >= k && vowelCount == 5) {
            res += n - j + 1;
        }
        if (isVowel(word[i])) {
            occur[word[i] - 'a']--;
            if (occur[word[i] - 'a'] == 0) {
                vowelCount--;
            }
        } else {
            consonants--;
        }
    }
    return res;
}

long long countOfSubstrings(char* word, int k) {
    return count(word, k) - count(word, k + 1);
}
```

```CSharp
public class Solution {
    public long CountOfSubstrings(string word, int k) {
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        long Count(int m) {
            int n = word.Length, consonants = 0;
            long res = 0;
            Dictionary<char, int> occur = new Dictionary<char, int>();
            for (int i = 0, j = 0; i < n; i++) {
                while (j < n && (consonants < m || occur.Count < 5)) {
                    char ch = word[j];
                    if (vowels.Contains(ch)) {
                        if (!occur.ContainsKey(ch)) occur[ch] = 0;
                        occur[ch]++;
                    } else {
                        consonants++;
                    }
                    j++;
                }
                if (consonants >= m && occur.Count == 5) {
                    res += n - j + 1;
                }
                char left = word[i];
                if (vowels.Contains(left)) {
                    occur[left]--;
                    if (occur[left] == 0) {
                        occur.Remove(left);
                    }
                } else {
                    consonants--;
                }
            }
            return res;
        }
        return Count(k) - Count(k + 1);
    }
}
```

```Rust
use std::collections::{HashMap, HashSet};
impl Solution {
    pub fn count_of_substrings(word: String, k: i32) -> i64 {
        let vowels: HashSet<char> = ['a', 'e', 'i', 'o', 'u'].iter().cloned().collect();
        fn count(word: &str, k: i32, vowels: &HashSet<char>) -> i64 {
            let n = word.len();
            let mut res = 0;
            let mut consonants = 0;
            let mut occur: HashMap<char, i32> = HashMap::new();
            let mut j = 0;
            let word_chars: Vec<char> = word.chars().collect();
            for i in 0..n {
                while j < n && (consonants < k || occur.len() < 5) {
                    let ch = word_chars[j];
                    if vowels.contains(&ch) {
                        *occur.entry(ch).or_insert(0) += 1;
                    } else {
                        consonants += 1;
                    }
                    j += 1;
                }
                if consonants >= k && occur.len() == 5 {
                    res += (n - j + 1) as i64;
                }
                let left = word_chars[i];
                if vowels.contains(&left) {
                    if let Some(count) = occur.get_mut(&left) {
                        *count -= 1;
                        if *count == 0 {
                            occur.remove(&left);
                        }
                    }
                } else {
                    consonants -= 1;
                }
            }
            res
        }
        count(&word, k, &vowels) - count(&word, k + 1, &vowels)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $word$ 的长度。
- 空间复杂度：$O(1)$。
