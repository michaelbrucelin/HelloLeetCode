### [查找包含给定字符的单词](https://leetcode.cn/problems/find-words-containing-character/solutions/3674716/cha-zhao-bao-han-gei-ding-zi-fu-de-dan-c-ee7m/)

#### 方法一：模拟

**思路与算法**

根据题目模拟，遍历每个字符串，判断每个字符串是否包含字符 $x$。如果包含，就把字符串的下标添加到返回数组中。

最后返回下标数组。

**代码**

```C++
class Solution {
public:
    vector<int> findWordsContaining(vector<string>& words, char x) {
        vector<int> res;
        int n = words.size();
        for (int i = 0; i < n; ++i) {
            if (words[i].find(x) != string::npos) {
                res.push_back(i);
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public List<Integer> findWordsContaining(String[] words, char x) {
        List<Integer> res = new ArrayList<>();
        int n = words.length;
        for (int i = 0; i < n; i++) {
            if (words[i].indexOf(x) != -1) {
                res.add(i);
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def findWordsContaining(self, words: List[str], x: str) -> List[int]:
        res = []
        n = len(words)
        for i in range(n):
            if x in words[i]:
                res.append(i)
        return res
```

```JavaScript
var findWordsContaining = function(words, x) {
    const res = [];
    const n = words.length;
    for (let i = 0; i < n; i++) {
        if (words[i].includes(x)) {
            res.push(i);
        }
    }
    return res;
};
```

```TypeScript
function findWordsContaining(words: string[], x: string): number[] {
    const res = [];
    const n = words.length;
    for (let i = 0; i < n; i++) {
        if (words[i].includes(x)) {
            res.push(i);
        }
    }
    return res;
};
```

```Go
func findWordsContaining(words []string, x byte) []int {
    res := []int{}
    n := len(words)
    for i := 0; i < n; i++ {
        for j := 0; j < len(words[i]); j++ {
            if words[i][j] == x {
                res = append(res, i)
                break
            }
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public IList<int> FindWordsContaining(string[] words, char x) {
        List<int> res = new List<int>();
        int n = words.Length;
        for (int i = 0; i < n; i++) {
            if (words[i].Contains(x)) {
                res.Add(i);
            }
        }
        return res;
    }
}
```

```C
int* findWordsContaining(char** words, int wordsSize, char x, int* returnSize) {
    int* res = (int*)malloc(wordsSize * sizeof(int));
    *returnSize = 0;
    for (int i = 0; i < wordsSize; i++) {
        if (strchr(words[i], x) != NULL) {
            res[(*returnSize)++] = i;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn find_words_containing(words: Vec<String>, x: char) -> Vec<i32> {
        let mut res = Vec::new();
        let n = words.len();
        for i in 0..n {
            if words[i].contains(x) {
                res.push(i as i32);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times m)$，其中 $n$ 是数组的长度，$m$ 是字符串的长度。
- 空间复杂度：$O(1)$，不计算返回变量空间。
