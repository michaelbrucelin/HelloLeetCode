### [连接两字母单词得到的最长回文串](https://leetcode.cn/problems/longest-palindrome-by-concatenating-two-letter-words/solutions/1202034/lian-jie-liang-zi-mu-dan-ci-de-dao-de-zu-vs99/)

#### 方法一：贪心 + 哈希表

**思路与算法**

根据回文串的定义，回文串可以由奇数或者偶数个 $words$ 中的单词拼接而成，但必须满足以下条件：

- 如果数量为奇数，那么位于**正中间**的单词必须是**回文字符串**（即两个字符相等）；
- 每个单词和反转后对应位置的单词必须**互为反转字符串**。

根据上面的两个条件，我们可以得出构造最长回文串的规则：

- 对于两个字符**不同**的单词，需要尽可能多的**成对选择**它和它的反转字符串（如有）；
- 对于两个字符**相同**的单词，需要尽可能多的**成对选择**该单词；
- 如果按照上述条件挑选后，仍然存在**未被选择**的两个字符相同的单词（此时该字符串只可能有**一个**未被选择，且该字符串一定在 $4words$ 中出现**奇数次**），我们可以**任意选择一个**。

因此，我们用哈希表统计 $words$ 中每个单词的出现次数。随后，我们遍历哈希表的所有元素，并用 $res$ 维护可能构成回文字符串的最长长度，同时用初值为 $false$ 的布尔变量 $mid$ 判断是否存在可以作为中心单词的、出现奇数次的回文单词。在遍历到字符串 $word$ 时，我们首先求出它反转后的字符串 $rev$，此时根据 $word$ 与 $rev$ 的关系，有以下两种情况：

- $word \ne rev$，此时我们需要统计两者在 $words$ 出现次数的最小值，即为成对选择的最多数目。假设此时对数为 $n$，则其对最长回文字符串贡献的字符长度为 $4n$，我们将 $res$ 加上对应值；
- word = rev$，此时可以构成的对数为 $\lfloor m/2 \rfloor$，即对最长回文字符串贡献的字符长度为 $4\lfloor m/2 \rfloor$，我们同样将 $res$ 加上对应值。除此以外，我们还需要判断 $word$ 的出现次数 $m$ 是否为奇数：
  - 如果 $m$ 为奇数，则存在可以作为中心单词的剩余回文单词，我们将 $mid$ 置为 $true$；
  - 如果 $m$ 为偶数，则不存在可以作为中心单词的剩余回文单词，我们不改变 $mid$ 的取值。

最后，我们根据 $mid$ 的取值，判断最长回文串是否含有中心单词。如果 $mid$ 为 $true$，则代表含有，我们将 $res$ 加上 $2$；反之则没有，我们不进行任何操作。

最后，我们返回 $res$ 作为最长回文串的长度。

**细节**

在遍历哈希表中的每个单词时，为了避免重复计算成对选择的单词，我们只在 $word$ 的**字典序大于等于** $rev$ 时更新 $res$。

**代码**

```C++
class Solution {
public:
    int longestPalindrome(vector<string>& words) {
        unordered_map<string, int> freq;   // 单词出现次数
        for (const string& word: words) {
            ++freq[word];
        }
        int res = 0;   // 最长回文串长度
        bool mid = false;   // 是否含有中心单词
        for (const auto& [word, cnt]: freq) {
            // 遍历出现的单词，并更新长度
            string rev = string(1, word[1]) + word[0];   // 反转后的单词
            if (word == rev) {
                if (cnt % 2 == 1) {
                    mid = true;
                }
                res += 2 * (cnt / 2 * 2);
            }
            else if (word > rev) {   // 避免重复遍历
                res += 4 * min(freq[word], freq[rev]);
            }
        }
        if (mid) {
            // 含有中心单词，更新长度
            res += 2;
        }
        return res;
    }
};
```

```Python
class Solution:
    def longestPalindrome(self, words: List[str]) -> int:
        freq = Counter(words)   # 单词出现次数
        res = 0   # 最长回文串长度
        mid = False   # 是否含有中心单词
        for word, cnt in freq.items():
            # 遍历出现的单词，并更新长度
            rev = word[1] + word[0]   # 反转后的单词
            if word == rev:
                if cnt % 2 == 1:
                    mid = True
                res += 2 * (cnt // 2 * 2)
            elif word > rev:   # 避免重复遍历
                res += 4 * min(freq[word], freq[rev])
        if mid:
            # 含有中心单词，更新长度
            res += 2
        return res
```

```Java
class Solution {
    public int longestPalindrome(String[] words) {
        Map<String, Integer> freq = new HashMap<>();
        for (String word : words) {
            freq.put(word, freq.getOrDefault(word, 0) + 1);
        }
        int res = 0;
        boolean mid = false;
        for (Map.Entry<String, Integer> entry : freq.entrySet()) {
            String word = entry.getKey();
            int cnt = entry.getValue();
            String rev = "" + word.charAt(1) + word.charAt(0);
            if (word.equals(rev)) {
                if (cnt % 2 == 1) {
                    mid = true;
                }
                res += 2 * (cnt / 2 * 2);
            } else if (word.compareTo(rev) > 0) {
                res += 4 * Math.min(freq.getOrDefault(word, 0), freq.getOrDefault(rev, 0));
            }
        }
        if (mid) {
            res += 2;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int LongestPalindrome(string[] words) {
        Dictionary<string, int> freq = new Dictionary<string, int>();
        foreach (string word in words) {
            freq[word] = freq.GetValueOrDefault(word, 0) + 1;
        }
        int res = 0;
        bool mid = false;
        foreach (var entry in freq) {
            string word = entry.Key;
            int cnt = entry.Value;
            string rev = "" + word[1] + word[0];
            if (word == rev) {
                if (cnt % 2 == 1) {
                    mid = true;
                }
                res += 2 * (cnt / 2 * 2);
            } else if (string.Compare(word, rev) > 0) {
                res += 4 * Math.Min(freq.GetValueOrDefault(word, 0), freq.GetValueOrDefault(rev, 0));
            }
        }
        if (mid) {
            res += 2;
        }
        return res;
    }
}
```

```Go
func longestPalindrome(words []string) int {
    freq := make(map[string]int)
    for _, word := range words {
        freq[word]++
    }
    res := 0
    mid := false
    for word, cnt := range freq {
        rev := string(word[1]) + string(word[0])
        if word == rev {
            if cnt%2 == 1 {
                mid = true
            }
            res += 2 * (cnt / 2 * 2)
        } else if strings.Compare(word, rev) > 0 {
            res += 4 * min(freq[word], freq[rev])
        }
    }
    if mid {
        res += 2
    }
    return res
}
```

```C
int longestPalindrome(char** words, int wordsSize) {
    // 统计单词频率
    int freq[26 * 26] = {0}; // 26 * 26 表示所有可能的 2 字母组合
    for (int i = 0; i < wordsSize; i++) {
        int idx = (words[i][0] - 'a') * 26 + (words[i][1] - 'a');
        freq[idx]++;
    }
    int res = 0;
    int mid = 0;
    for (int i = 0; i < 26 * 26; i++) {
        if (freq[i] == 0) continue;
        int rev = (i % 26) * 26 + (i / 26); // 反转单词的索引
        if (i == rev) {
            if (freq[i] % 2 == 1) {
                mid = 1;
            }
            res += 2 * (freq[i] / 2 * 2);
        } else if (i > rev) {
            res += 4 * fmin(freq[i], freq[rev]);
        }
    }
    if (mid) {
        res += 2;
    }
    return res;
}
```

```JavaScript
var longestPalindrome = function(words) {
    const freq = new Map();
    for (const word of words) {
        freq.set(word, (freq.get(word) || 0) + 1);
    }
    let res = 0;
    let mid = false;
    for (const [word, cnt] of freq.entries()) {
        const rev = word[1] + word[0];
        if (word === rev) {
            if (cnt % 2 === 1) {
                mid = true;
            }
            res += 2 * (Math.floor(cnt / 2) * 2);
        } else if (word > rev) {
            res += 4 * Math.min(freq.get(word) || 0, freq.get(rev) || 0);
        }
    }
    if (mid) {
        res += 2;
    }
    return res;
}
```

```TypeScript
function longestPalindrome(words: string[]): number {
    const freq = new Map<string, number>();
    for (const word of words) {
        freq.set(word, (freq.get(word) || 0) + 1);
    }
    let res = 0;
    let mid = false;
    for (const [word, cnt] of freq.entries()) {
        const rev = word[1] + word[0];
        if (word === rev) {
            if (cnt % 2 === 1) {
                mid = true;
            }
            res += 2 * (Math.floor(cnt / 2) * 2);
        } else if (word > rev) {
            res += 4 * Math.min(freq.get(word) || 0, freq.get(rev) || 0);
        }
    }
    if (mid) {
        res += 2;
    }
    return res;
}
```

```Rust
use std::collections::HashMap;
use std::cmp::{min, max};

impl Solution {
    pub fn longest_palindrome(words: Vec<String>) -> i32 {
        let mut freq = HashMap::new();
        for word in &words {
            *freq.entry(word.clone()).or_insert(0) += 1;
        }
        let mut res = 0;
        let mut mid = false;
        for (word, cnt) in &freq {
            let rev = format!("{}{}", word.chars().nth(1).unwrap(), word.chars().nth(0).unwrap());
            if *word == rev {
                if cnt % 2 == 1 {
                    mid = true;
                }
                res += 2 * (cnt / 2 * 2);
            } else if *word > rev {
                res += 4 * min(*cnt, *freq.get(&rev).unwrap_or(&0));
            }
        }
        if mid {
            res += 2;
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组 $words$ 的长度。即为遍历统计数组各个元素的出现次数以及遍历哈希表计算最长回文串长度的时间复杂度。
- 空间复杂度：$O(min(n, \vert \sum \vert^2))$，即为哈希表的空间开销。哈希表的大小受到两方面限制：
  - 哈希表的大小小于等于两字母单词的数量，即 $O(\vert \sum \vert^2)$；
  - 哈希表的大小小于等于 $words$ 中单词数量，即 $O(n)$。
