### [成为 K 特殊字符串需要删除的最少字符数](https://leetcode.cn/problems/minimum-deletions-to-make-string-k-special/solutions/3698508/cheng-wei-k-te-shu-zi-fu-chuan-xu-yao-sh-erdq/)

#### 方法一：哈希表 + 枚举

**思路与算法**

题目要求我们删除指定字符串中的某些字符，使得任意两种字符的出现频率的差值不超过 $k$。

因此，我们首先使用哈希表统计每种字符的出现次数，记 $cnt[c]$ 表示字符 $c$ 出现的次数，然后由于字符种类数只有 $26$，我们可以枚举其中一种作为「删除操作结束后出现频率最低的字符」，将其设置为 $c$，那么所有频率小于 $c$ 的字符都会被删除，所有频率大于 $cnt[c]+k$ 的字符都会被删除至只剩下 $cnt[c]$ 个。

我们取所有枚举方案中，需要删除字符数最小的那个即可。

**代码**

```C++
class Solution {
public:
    int minimumDeletions(string word, int k) {
        unordered_map<char, int> cnt;
        for (auto &ch : word) {
            cnt[ch]++;
        }
        int res = word.size();
        for (auto &[_, a] : cnt) {
            int deleted = 0;
            for (auto &[_, b] : cnt) {
                if (a > b) {
                    deleted += b;
                } else if (b > a + k) {
                    deleted += b - (a + k);
                }
            }
            res = min(res, deleted);
        }
        return res;
    }
};
```

```Python
class Solution:
    def minimumDeletions(self, word: str, k: int) -> int:
        cnt = defaultdict(int)
        for c in word:
            cnt[c] += 1
        res = len(word)
        for a in cnt.values():
            deleted = 0
            for b in cnt.values():
                if a > b:
                    deleted += b
                elif b > a + k:
                    deleted += b - (a + k)
            res = min(res, deleted)
        return res
```

```Rust
use std::collections::HashMap;
impl Solution {
    pub fn minimum_deletions(word: String, k: i32) -> i32 {
        let mut cnt = HashMap::new();
        for c in word.chars() {
            *cnt.entry(c).or_insert(0) += 1;
        }
        let mut res = word.len() as i32;
        for &a in cnt.values() {
            let mut deleted = 0;
            for &b in cnt.values() {
                if a > b {
                    deleted += b;
                } else if b > a + k {
                    deleted += b - (a + k);
                }
            }
            res = res.min(deleted);
        }
        res
    }
}
```

```Java
class Solution {
    public int minimumDeletions(String word, int k) {
        Map<Character, Integer> cnt = new HashMap<>();
        for (char ch : word.toCharArray()) {
            cnt.put(ch, cnt.getOrDefault(ch, 0) + 1);
        }
        int res = word.length();
        for (int a : cnt.values()) {
            int deleted = 0;
            for (int b : cnt.values()) {
                if (a > b) {
                    deleted += b;
                } else if (b > a + k) {
                    deleted += b - (a + k);
                }
            }
            res = Math.min(res, deleted);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MinimumDeletions(string word, int k) {
        Dictionary<char, int> cnt = new Dictionary<char, int>();
        foreach (char ch in word) {
            if (cnt.ContainsKey(ch)) {
                cnt[ch]++;
            } else {
                cnt[ch] = 1;
            }
        }
        int res = word.Length;
        foreach (int a in cnt.Values) {
            int deleted = 0;
            foreach (int b in cnt.Values) {
                if (a > b) {
                    deleted += b;
                } else if (b > a + k) {
                    deleted += b - (a + k);
                }
            }
            res = Math.Min(res, deleted);
        }
        return res;
    }
}
```

```Go
func minimumDeletions(word string, k int) int {
    cnt := make(map[rune]int)
    for _, ch := range word {
        cnt[ch]++
    }
    res := len(word)
    for _, a := range cnt {
        deleted := 0
        for _, b := range cnt {
            if a > b {
                deleted += b
            } else if b > a + k {
                deleted += b - (a + k)
            }
        }
        if deleted < res {
            res = deleted
        }
    }
    return res
}
```

```C
int minimumDeletions(char* word, int k) {
    int cnt[26] = {0};
    for (int i = 0; word[i]; i++) {
        cnt[word[i] - 'a']++;
    }
    int res = strlen(word);
    for (int i = 0; i < 26; i++) {
        if (cnt[i] == 0) {
            continue;
        }
        int a = cnt[i];
        int deleted = 0;
        for (int j = 0; j < 26; j++) {
            if (cnt[j] == 0) {
                continue;
            }
            int b = cnt[j];
            if (a > b) {
                deleted += b;
            } else if (b > a + k) {
                deleted += b - (a + k);
            }
        }
        if (deleted < res) {
            res = deleted;
        }
    }
    return res;
}
```

```JavaScript
var minimumDeletions = function(word, k) {
    const cnt = new Map();
    for (const ch of word) {
        cnt.set(ch, (cnt.get(ch) || 0) + 1);
    }
    let res = word.length;
    for (const a of cnt.values()) {
        let deleted = 0;
        for (const b of cnt.values()) {
            if (a > b) {
                deleted += b;
            } else if (b > a + k) {
                deleted += b - (a + k);
            }
        }
        res = Math.min(res, deleted);
    }
    return res;
};
```

```TypeScript
function minimumDeletions(word: string, k: number): number {
    const cnt = new Map<string, number>();
    for (const ch of word) {
        cnt.set(ch, (cnt.get(ch) || 0) + 1);
    }
    let res = word.length;
    for (const a of cnt.values()) {
        let deleted = 0;
        for (const b of cnt.values()) {
            if (a > b) {
                deleted += b;
            } else if (b > a + k) {
                deleted += b - (a + k);
            }
        }
        res = Math.min(res, deleted);
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n+C^2)$，其中 $n$ 是字符串 $word$ 的长度，$C$ 是字符集大小，本题中为 $26$。
- 空间复杂度：$O(C)$。使用哈希表的空间复杂度是 $O(C)$。
