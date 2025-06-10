### [奇偶频次间的最大差值 I](https://leetcode.cn/problems/maximum-difference-between-even-and-odd-frequency-i/solutions/3692731/qi-ou-pin-ci-jian-de-zui-da-chai-zhi-i-b-wy8k/)

#### 方法一：统计每个字符出现的次数

**思路与算法**

我们使用哈希映射对字符串 $s$ 中每个字符出现的次数进行统计。对于哈希映射中的每个键值对，键表示一个字符，值表示该字符出现的次数。

在统计完成后，我们对哈希表的值部分进行遍历，得到最大的奇数 $maxOdd$ 和最小的偶数 $minEven$，那么 $maxOdd-minEven$ 就是最终的答案。

**代码**

```C++
class Solution {
public:
    int maxDifference(string s) {
        unordered_map<char, int> c;
        for (char ch: s) {
            ++c[ch];
        }
        int maxOdd = 1, minEven = s.size();
        for (const auto& [_, value]: c) {
            if (value % 2 == 1) {
                maxOdd = max(maxOdd, value);
            }
            else {
                minEven = min(minEven, value);
            }
        }
        return maxOdd - minEven;
    }
};
```

```Python
class Solution:
    def maxDifference(self, s: str) -> int:
        c = Counter(s)
        maxOdd = max(x for x in c.values() if x % 2 == 1)
        minEven = min(x for x in c.values() if x % 2 == 0)
        return maxOdd - minEven
```

```Java
class Solution {
    public int maxDifference(String s) {
        Map<Character, Integer> c = new HashMap<>();
        for (char ch : s.toCharArray()) {
            c.put(ch, c.getOrDefault(ch, 0) + 1);
        }
        int maxOdd = 1, minEven = s.length();
        for (int value : c.values()) {
            if (value % 2 == 1) {
                maxOdd = Math.max(maxOdd, value);
            } else {
                minEven = Math.min(minEven, value);
            }
        }
        return maxOdd - minEven;
    }
}
```

```CSharp
public class Solution {
    public int MaxDifference(string s) {
        Dictionary<char, int> c = new Dictionary<char, int>();
        foreach (char ch in s) {
            if (c.ContainsKey(ch)) {
                c[ch]++;
            } else {
                c[ch] = 1;
            }
        }
        int maxOdd = 1, minEven = s.Length;
        foreach (var kvp in c) {
            if (kvp.Value % 2 == 1) {
                maxOdd = Math.Max(maxOdd, kvp.Value);
            } else {
                minEven = Math.Min(minEven, kvp.Value);
            }
        }
        return maxOdd - minEven;
    }
}
```

```Go
func maxDifference(s string) int {
    c := make(map[rune]int)
    for _, ch := range s {
        c[ch]++
    }
    maxOdd, minEven := 1, len(s)
    for _, value := range c {
        if value % 2 == 1 {
            maxOdd = max(maxOdd, value)
        } else {
            minEven = min(minEven, value)
        }
    }
    return maxOdd - minEven
}
```

```C
int maxDifference(char* s) {
    int count[26] = {0};   
    int len = strlen(s); 
    for (int i = 0; i < len; i++) {
        count[s[i] - 'a']++;
    }
    int maxOdd = 1, minEven = len;
    for (int i = 0; i < 26; i++) {
        if (count[i] > 0) {
            if (count[i] % 2 == 1) {
                maxOdd = fmax(maxOdd, count[i]);
            } else {
                minEven = fmin(minEven, count[i]);
            }
        }
    }
    return maxOdd - minEven;
}
```

```JavaScript
var maxDifference = function(s) {
    const c = new Map();
    for (const ch of s) {
        c.set(ch, (c.get(ch) || 0) + 1);
    }
    let maxOdd = 1, minEven = s.length;
    for (const [_, value] of c) {
        if (value % 2 === 1) {
            maxOdd = Math.max(maxOdd, value);
        } else {
            minEven = Math.min(minEven, value);
        }
    }
    return maxOdd - minEven;
};
```

```TypeScript
function maxDifference(s: string): number {
    const c: Map<string, number> = new Map();
    for (const ch of s) {
        c.set(ch, (c.get(ch) || 0) + 1);
    }
    let maxOdd = 1, minEven = s.length;
    for (const [_, value] of c) {
        if (value % 2 === 1) {
            maxOdd = Math.max(maxOdd, value);
        } else {
            minEven = Math.min(minEven, value);
        }
    }
    return maxOdd - minEven;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn max_difference(s: String) -> i32 {
        let mut c = HashMap::new();
        for ch in s.chars() {
            *c.entry(ch).or_insert(0) += 1;
        }
        let mut maxOdd = 1;
        let mut minEven = s.len() as i32;
        for &value in c.values() {
            if value % 2 == 1 {
                maxOdd = maxOdd.max(value);
            } else {
                minEven = minEven.min(value);
            }
        }
        maxOdd - minEven
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
- 空间复杂度：$O(\vert\sum\vert)$，其中 $\sum$ 是字符集，即为哈希表需要使用的空间。在本题中字符串 $s$ 仅包含小写字母，因此 $\vert\sum\vert=26$。
