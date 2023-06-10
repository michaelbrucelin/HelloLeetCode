#### [方法一：后缀和](https://leetcode.cn/problems/compare-strings-by-frequency-of-the-smallest-character/solutions/2297291/bi-jiao-zi-fu-chuan-zui-xiao-zi-mu-chu-x-pb50/)

**思路与算法**

题目定义了一个函数 $f(s)$，用于统计字符串 $s$ 中字典序最小的字母的出现频次。然后给定两个字符串数组 $queries$ 和 $words$，要求对于每个 $queries[i]$，统计 $words$ 中有多少个字符串 $word$ 满足 $f(queries[i]) < f(word)$。

在实现函数 $f(s)$ 时，我们首先初始化一个字符变量 $ch = 'z'$ 表示当前遇到的字典序最小的字母，然后再初始化一个整数 $cnt = 0$ 表示该字母的出现次数。接下来依次遍历字符串 $s$ 中的每个字符 $c$：

-   如果 $c$ 的字典序小于 $ch$，则将 $ch$ 更新为 $c$，并将 $cnt$ 置为 $1$。
-   否则如果 $c = ch$，则令 $cnt$ 加 $1$。

最后，$cnt$ 即为 $s$ 中字典序最小的字母的出现次数。

我们可以提前将所有的 $words[i]$ 在 $f(s)$ 中计算一遍，由于 $queries[i]$ 和 $words[i]$ 的长度都不超过 $10$，因此 $f(s)$ 的范围是 $[1, 10]$。然后用一个长度固定的整数数组 $count$ 来统计每种 $f(words[i])$ 的个数，$queries[i]$ 对应的答案即为 $\sum_{u=f(queries[i]) + 1}^{10} count[u]$。

为了加快答案的计算，可以倒序遍历 $count$，将 $count$ 更新为后缀和数组。这样一来， $queries[i]$ 对应的答案即为 $count[f(queries[i]) + 1]$。

**代码**

```cpp
class Solution {
public:
    int f(string &s) {
        int cnt = 0;
        char ch = 'z';
        for (auto c : s) {
            if (c < ch) {
                ch = c;
                cnt = 1;
            } else if (c == ch) {
                cnt++;
            }
        }
        return cnt;
    }

    vector<int> numSmallerByFrequency(vector<string>& queries, vector<string>& words) {
        vector<int> count(12);
        for (auto &s : words) {
            count[f(s)]++;
        }
        for (int i = 9; i >= 1; i--) {
            count[i] += count[i + 1];
        }
        vector<int> res;
        for (auto &s : queries) {
            res.push_back(count[f(s) + 1]);
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] numSmallerByFrequency(String[] queries, String[] words) {
        int[] count = new int[12];
        for (String s : words) {
            count[f(s)]++;
        }
        for (int i = 9; i >= 1; i--) {
            count[i] += count[i + 1];
        }
        int[] res = new int[queries.length];
        for (int i = 0; i < queries.length; i++) {
            String s = queries[i];
            res[i] = count[f(s) + 1];
        }
        return res;
    }

    public int f(String s) {
        int cnt = 0;
        char ch = 'z';
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (c < ch) {
                ch = c;
                cnt = 1;
            } else if (c == ch) {
                cnt++;
            }
        }
        return cnt;
    }
}
```

```csharp
public class Solution {
    public int[] NumSmallerByFrequency(string[] queries, string[] words) {
        int[] count = new int[12];
        foreach (string s in words) {
            count[F(s)]++;
        }
        for (int i = 9; i >= 1; i--) {
            count[i] += count[i + 1];
        }
        int[] res = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            string s = queries[i];
            res[i] = count[F(s) + 1];
        }
        return res;
    }

    public int F(string s) {
        int cnt = 0;
        char ch = 'z';
        foreach (char c in s) {
            if (c < ch) {
                ch = c;
                cnt = 1;
            } else if (c == ch) {
                cnt++;
            }
        }
        return cnt;
    }
}
```

```python
class Solution:
    def f(self, s: str) -> int:
        cnt = 0
        ch = 'z'
        for c in s:
            if c < ch:
                ch = c
                cnt = 1
            elif c == ch:
                cnt += 1
        return cnt

    def numSmallerByFrequency(self, queries: List[str], words: List[str]) -> List[int]:
        count = [0] * 12
        for s in words:
            count[self.f(s)] += 1
        for i in range(9, 0, -1):
            count[i] += count[i + 1]
        res = []
        for s in queries:
            res.append(count[self.f(s) + 1])
        return res
```

```go
func f(s string) int {
    cnt := 0
    ch := 'z'
    for _, c := range s {
        if c < ch {
        ch = c
        cnt = 1
        } else if c == ch {
        cnt++
        }
    }
    return cnt
}

func numSmallerByFrequency(queries []string, words []string) []int {
    count := make([]int, 12)
    for _, s := range words {
        count[f(s)] += 1
    }
    for i := 9; i >= 1; i-- {
        count[i] += count[i + 1]
    }
    res := make([]int, len(queries))
    for i, s := range queries {
        res[i] = count[f(s) + 1]
    }
    return res
}
```

```javascript
function f(s) {
    let cnt = 0;
    let ch = 'z';
    for (let c of s) {
      if (c < ch) {
        ch = c;
        cnt = 1;
      } else if (c == ch) {
        cnt++;
      }
    }
    return cnt;
}

var numSmallerByFrequency = function(queries, words) {
    let count = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    for (let s of words) {
      count[f(s)]++;
    }
    for (let i = 9; i >= 0; i--) {
      count[i] += count[i + 1];
    }
    res = [];
    for (let s of queries) {
      res.push(count[f(s) + 1]);
    }
    return res;
};
```

```c
int f(const char* s) {
    int cnt = 0;
    char ch = 'z';
    for (int i = 0; s[i] != '\0'; i++) {
        char c = s[i];
        if (c < ch) {
            ch = c;
            cnt = 1;
        } else if (c == ch) {
            cnt++;
        }
    }
    return cnt;
}


int* numSmallerByFrequency(char ** queries, int queriesSize, char ** words, int wordsSize, int* returnSize) {
    int count[12] = {0};
    for (int i = 0; i < wordsSize; i++) {
        count[f(words[i])]++;
    }
    for (int i = 9; i >= 1; i--) {
        count[i] += count[i + 1];
    }
    int* res = (int *)malloc(sizeof(int) * queriesSize);
    for (int i = 0; i < queriesSize; i++) {
        res[i] = count[f(queries[i]) + 1];
    }
    *returnSize = queriesSize;
    return res;
}
```

**复杂度分析**

-   时间复杂度：$O((n + m)p)$，其中 $n$ 是 $queries$ 的长度，$m$ 是 $words$ 的长度，$p$ 是 $queries$ 和 $words$ 中的最长字符串的长度。
-   空间复杂度：$O(1)$。不统计返回值所占用的空间，我们只使用到了常数个变量。
