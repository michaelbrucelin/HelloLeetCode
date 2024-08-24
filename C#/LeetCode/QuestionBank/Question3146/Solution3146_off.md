### [两个字符串的排列差](https://leetcode.cn/problems/permutation-difference-between-two-strings/solutions/2885447/liang-ge-zi-fu-chuan-de-pai-lie-chai-by-rtqzd/)

#### 方法一：哈希表

**思路与算法**

首先将字符串 $s$ 中字符与下标的对应关系放到哈希表 $char2index$ 中。然后遍历字符串 $t$，计算同一个字符的下标之差，并求和。

**代码**

```Python
class Solution:
    def findPermutationDifference(self, s: str, t: str) -> int:
        char2index = {c: i for i, c in enumerate(s)}
        return sum(abs(i - char2index[c]) for i, c in enumerate(t))
```

```C++
class Solution {
public:
    int findPermutationDifference(string s, string t) {
        unordered_map<char, int> char2index;
        for (int i = 0; i < s.length(); ++i) {
            char2index[s[i]] = i;
        }
        int sum = 0;
        for (int i = 0; i < t.length(); ++i) {
            sum += abs(i - char2index[t[i]]);
        }
        return sum;
    }
};
```

```Java
class Solution {
    public int findPermutationDifference(String s, String t) {
        Map<Character, Integer> char2index = new HashMap<Character, Integer>();
        for (int i = 0; i < s.length(); ++i) {
            char2index.put(s.charAt(i), i);
        }
        int sum = 0;
        for (int i = 0; i < t.length(); ++i) {
            sum += Math.abs(i - char2index.get(t.charAt(i)));
        }
        return sum;
    }
}
```

```CSharp
public class Solution {
    public int FindPermutationDifference(string s, string t) {
        IDictionary<char, int> char2index = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; ++i) {
            char2index.Add(s[i], i);
        }
        int sum = 0;
        for (int i = 0; i < t.Length; ++i) {
            sum += Math.Abs(i - char2index[t[i]]);
        }
        return sum;
    }
}
```

```C
int findPermutationDifference(char* s, char* t) {
    int char2index[26] = {0}; 
    for (int i = 0; s[i] != '\0'; ++i) {
        char2index[s[i] - 'a'] = i;
    }
    int sum = 0;
    for (int i = 0; t[i] != '\0'; ++i) {
        sum += abs(i - char2index[t[i] - 'a']);
    }
    return sum;
}
```

```Go
func findPermutationDifference(s string, t string) int {
    char2index := make(map[rune]int)
    for i, c := range s {
        char2index[c] = i
    }
    sum := 0
    for i, c := range t {
        sum += int(math.Abs(float64(i - char2index[c])))
    }
    return sum
}
```

```JavaScript
var findPermutationDifference = function(s, t) {
    const char2index = {};
    for (let i = 0; i < s.length; i++) {
        char2index[s[i]] = i;
    }
    let sum = 0;
    for (let i = 0; i < t.length; i++) {
        sum += Math.abs(i - char2index[t[i]]);
    }

    return sum;
};
```

```TypeScript
function findPermutationDifference(s: string, t: string): number {
    const char2index: Record<string, number> = {};
    for (let i = 0; i < s.length; i++) {
        char2index[s[i]] = i;
    }
    let sum = 0;
    for (let i = 0; i < t.length; i++) {
        sum += Math.abs(i - char2index[t[i]]);
    }

    return sum;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn find_permutation_difference(s: String, t: String) -> i32 {
        let mut char2index = HashMap::new();
        for (i, c) in s.chars().enumerate() {
            char2index.insert(c, i as i32);
        }

        t.chars()
            .enumerate()
            .map(|(i, c)| (i as i32 - char2index[&c]).abs())
            .sum()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $s$ 的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是 $s$ 的长度。
