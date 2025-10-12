### [移除字母异位词后的结果数组](https://leetcode.cn/problems/find-resultant-array-after-removing-anagrams/solutions/1538663/yi-chu-zi-mu-yi-wei-ci-hou-de-jie-guo-sh-xi48/)

#### 方法一：逐个判断

**思路与算法**

由于「字母异位词」具有等价性和传递性，因此对于 $words$ 中出现的多个连续字母异位词，我们只需要保留最前面的即可。

因此，我们可以采用如下的方式实现移除操作：

我们用 $res$ 来表示结果数组，$res$ 中初始含有 $words[0]$。我们**按顺序**遍历 $words$ 的剩余单词，每当遍历到一个新的单词时，我们检查该单词与 $words$ 中它的**前一个**单词是否为字母异位词：如果是，则该单词需要被删除，我们不进行任何操作；反之则将该单词添加至 $res$ 末尾。

关于如何判断两个单词 $word_1$ 与 $word_2$ 是否为字母异位词，我们用函数 $compare(word_1,word_2)$ 实现判断。具体地，我们用长度为英文字符数量（$26$）的频率数组 $freq$ 统计每个字符的出现次数，当我们遍历 $word_1$ 的每个字符时，我们将 $freq$ 对应下标的元素加上 $1$；当我们遍历 $word_2$ 的每个字符时，我们将 $freq$ 对应下标的元素减去 $1$。最终，如果 $freq$ 数组的全部元素均为 $0$，则说明两个单词为字母异位词，我们返回 $true$；反之则不是，我们返回 $false$。

最终 $res$ 即为移除字母异位词之后的结果数组，我们返回该数组作为答案即可。

**代码**

```C++
class Solution {
public:
    vector<string> removeAnagrams(vector<string>& words) {
        vector<string> res = {words[0]};   // 结果数组
        int n = words.size();
        // 判断两个单词是否为字母异位词
        auto compare = [](const string& word1, const string& word2) -> bool {
            vector<int> freq(26);
            for (char ch: word1) {
                ++freq[ch-'a'];
            }
            for (char ch: word2) {
                --freq[ch-'a'];
            }
            return all_of(freq.begin(), freq.end(), [](int x) { return x == 0; });
        };

        for (int i = 1; i < n; ++i) {
            if (compare(words[i], words[i-1])) {
                continue;
            }
            res.push_back(words[i]);
        }
        return res;
    }
};
```

```Python
class Solution:
    def removeAnagrams(self, words: List[str]) -> List[str]:
        res = [words[0]]   # 结果数组
        n = len(words)
        # 判断两个单词是否为字母异位词
        def compare(word1: str, word2: str) -> bool:
            freq = [0] * 26
            for ch in word1:
                freq[ord(ch)-ord('a')] += 1
            for ch in word2:
                freq[ord(ch)-ord('a')] -= 1
            return all(x == 0 for x in freq)
        
        for i in range(1, n):
            if compare(words[i], words[i-1]):
                continue
            res.append(words[i])
        return res
```

```Java
class Solution {
    public List<String> removeAnagrams(String[] words) {
        List<String> res = new ArrayList<>();
        res.add(words[0]);   // 结果数组
        int n = words.length;
        for (int i = 1; i < n; i++) {
            if (!compare(words[i], words[i - 1])) {
                res.add(words[i]);
            }
        }
        return res;
    }
    
    // 判断两个单词是否为字母异位词
    private boolean compare(String word1, String word2) {
        int[] freq = new int[26];
        for (char ch : word1.toCharArray()) {
            freq[ch - 'a']++;
        }
        for (char ch : word2.toCharArray()) {
            freq[ch - 'a']--;
        }
        for (int x : freq) {
            if (x != 0) {
                return false;
            }
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public IList<string> RemoveAnagrams(string[] words) {
        List<string> res = new List<string>();
        res.Add(words[0]);   // 结果数组
        int n = words.Length;
        
        for (int i = 1; i < n; i++) {
            if (!Compare(words[i], words[i-1])) {
                res.Add(words[i]);
            }
        }
        return res;
    }
    
    // 判断两个单词是否为字母异位词
    private bool Compare(string word1, string word2) {
        int[] freq = new int[26];
        foreach (char ch in word1) {
            freq[ch - 'a']++;
        }
        foreach (char ch in word2) {
            freq[ch - 'a']--;
        }
        foreach (int x in freq) {
            if (x != 0) {
                return false;
            }
        }
        return true;
    }
}
```

```Go
func removeAnagrams(words []string) []string {
    res := []string{words[0]}   // 结果数组
    n := len(words)
    
    // 判断两个单词是否为字母异位词
    compare := func(word1, word2 string) bool {
        freq := make([]int, 26)
        for _, ch := range word1 {
            freq[ch-'a']++
        }
        for _, ch := range word2 {
            freq[ch-'a']--
        }
        for _, x := range freq {
            if x != 0 {
                return false
            }
        }
        return true
    }

    for i := 1; i < n; i++ {
        if !compare(words[i], words[i - 1]) {
            res = append(res, words[i])
        }
    }
    return res
}
```

```C
// 判断两个单词是否为字母异位词
bool compare(const char* word1, const char* word2) {
    int freq[26] = {0};
    for (int i = 0; word1[i] != '\0'; i++) {
        freq[word1[i] - 'a']++;
    }
    for (int i = 0; word2[i] != '\0'; i++) {
        freq[word2[i] - 'a']--;
    }
    for (int i = 0; i < 26; i++) {
        if (freq[i] != 0) {
            return false;
        }
    }
    return true;
}

char** removeAnagrams(char** words, int wordsSize, int* returnSize) {
    char** res = (char**)malloc(wordsSize * sizeof(char*));
    *returnSize = 0;
    res[(*returnSize)++] = words[0];   // 结果数组
    
    for (int i = 1; i < wordsSize; i++) {
        if (!compare(words[i], words[i - 1])) {
            res[(*returnSize)++] = words[i];
        }
    }
    return res;
}
```

```JavaScript
var removeAnagrams = function(words) {
    let res = [words[0]];   // 结果数组
    let n = words.length;
    
    for (let i = 1; i < n; i++) {
        if (!compare(words[i], words[i-1])) {
            res.push(words[i]);
        }
    }
    return res;
};

// 判断两个单词是否为字母异位词
function compare(word1, word2) {
    let freq = new Array(26).fill(0);
    for (let ch of word1) {
        freq[ch.charCodeAt(0) - 'a'.charCodeAt(0)]++;
    }
    for (let ch of word2) {
        freq[ch.charCodeAt(0) - 'a'.charCodeAt(0)]--;
    }
    return freq.every(x => x === 0);
}
```

```TypeScript
function removeAnagrams(words: string[]): string[] {
    let res: string[] = [words[0]];   // 结果数组
    let n: number = words.length;
    
    for (let i = 1; i < n; i++) {
        if (!compare(words[i], words[i-1])) {
            res.push(words[i]);
        }
    }
    return res;
}

// 判断两个单词是否为字母异位词
function compare(word1: string, word2: string): boolean {
    let freq: number[] = new Array(26).fill(0);
    for (let ch of word1) {
        freq[ch.charCodeAt(0) - 'a'.charCodeAt(0)]++;
    }
    for (let ch of word2) {
        freq[ch.charCodeAt(0) - 'a'.charCodeAt(0)]--;
    }
    return freq.every(x => x === 0);
}
```

```Rust
impl Solution {
    pub fn remove_anagrams(words: Vec<String>) -> Vec<String> {
        let mut res = vec![words[0].clone()];   // 结果数组
        let n = words.len();
        
        // 判断两个单词是否为字母异位词
        fn compare(word1: &String, word2: &String) -> bool {
            let mut freq = [0; 26];
            for ch in word1.chars() {
                freq[(ch as u8 - b'a') as usize] += 1;
            }
            for ch in word2.chars() {
                freq[(ch as u8 - b'a') as usize] -= 1;
            }
            freq.iter().all(|&x| x == 0)
        }

        for i in 1..n {
            if !compare(&words[i], &words[i - 1]) {
                res.push(words[i].clone());
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $n$ 为 $words$ 的长度, $m$ 为 $words$ 中单词的长度。即为遍历 $words$ 数组并判断每个元素是否需要移除的时间复杂度。
- 空间复杂度：$O(\vert \sum \vert)$，其中 $\vert \sum \vert $ 为字符集的大小。即为字符出现次数数组的空间开销。
