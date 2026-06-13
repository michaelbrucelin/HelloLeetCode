### [带权单词映射](https://leetcode.cn/problems/weighted-word-mapping/solutions/3979288/dai-quan-dan-ci-ying-she-by-leetcode-sol-5oec/)

#### 方法一：模拟

**思路与算法**

我们可以直接按照题意模拟。遍历 $words$ 中的每个字符串，并遍历其中的每个字符，在 $weights$ 中找到对应的字符权重并加和。题目要求将权重和取模后倒序映射为一个字符，相当于把字符 $z$ 减去权重和取模后的值。

**代码**

```C++
class Solution {
public:
    string mapWordWeights(vector<string>& words, vector<int>& weights) {
        string ans;
        ans.reserve(words.size());
        for (string word : words) {
            int s = 0;
            for (char c : word) {
                s += weights[c - 'a'];
            }
            ans += 'z' - s % 26;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def mapWordWeights(self, words: List[str], weights: List[int]) -> str:
        ans = []
        for word in words:
            s = 0
            for c in word:
                s += weights[ord(c) - ord('a')]
            ans.append(chr(ord('z') - s % 26))
        return ''.join(ans)
```

```Java
class Solution {
    public String mapWordWeights(String[] words, int[] weights) {
        StringBuilder ans = new StringBuilder(words.length);
        for (String word : words) {
            int s = 0;
            for (int i = 0; i < word.length(); i++) {
                s += weights[word.charAt(i) - 'a'];
            }
            ans.append((char) ('z' - s % 26));
        }
        return ans.toString();
    }
}
```

```Go
func mapWordWeights(words []string, weights []int) string {
    ans := make([]byte, 0, len(words))
    for _, word := range words {
        s := 0
        for _, c := range word {
            s += weights[c-'a']
        }
        ans = append(ans, byte('z'-s%26))
    }
    return string(ans)
}
```

```C
char* mapWordWeights(char** words, int wordsSize, int* weights, int weightsSize) {
    char* ans = (char*)malloc((wordsSize + 1) * sizeof(char));
    for (int i = 0; i < wordsSize; i++) {
        int s = 0;
        for (char* p = words[i]; *p; p++) {
            s += weights[*p - 'a'];
        }
        ans[i] = 'z' - s % 26;
    }
    ans[wordsSize] = '\0';
    return ans;
}
```

```CSharp
public class Solution {
    public string MapWordWeights(string[] words, int[] weights) {
        var ans = new StringBuilder(words.Length);
        foreach (string word in words) {
            int s = 0;
            foreach (char c in word) {
                s += weights[c - 'a'];
            }
            ans.Append((char)('z' - s % 26));
        }
        return ans.ToString();
    }
}
```

```JavaScript
var mapWordWeights = function(words, weights) {
    let ans = '';
    for (const word of words) {
        let s = 0;
        for (const c of word) {
            s += weights[c.charCodeAt(0) - 'a'.charCodeAt(0)];
        }
        ans += String.fromCharCode('z'.charCodeAt(0) - s % 26);
    }
    return ans;
};
```

```TypeScript
function mapWordWeights(words: string[], weights: number[]): string {
    let ans = '';
    for (const word of words) {
        let s = 0;
        for (const c of word) {
            s += weights[c.charCodeAt(0) - 'a'.charCodeAt(0)];
        }
        ans += String.fromCharCode('z'.charCodeAt(0) - s % 26);
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn map_word_weights(words: Vec<String>, weights: Vec<i32>) -> String {
        let mut ans = String::with_capacity(words.len());

        for word in words {
            let mut s = 0;
            for c in word.bytes() {
                s += weights[(c - b'a') as usize];
            }
            ans.push((b'z' - (s % 26) as u8) as char);
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $words$ 中所有字符的数量。只需要遍历所有字符一次。
- 空间复杂度：$O(1)$。输出字符串不计入空间复杂度，只需要若干辅助变量。
