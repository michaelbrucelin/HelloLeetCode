#### [方法二：动态规划](https://leetcode.cn/problems/is-subsequence/solutions/346539/pan-duan-zi-xu-lie-by-leetcode-solution/)

**思路及算法**

考虑前面的双指针的做法，我们注意到我们有大量的时间用于在 $t$ 中找到下一个匹配字符。

这样我们可以预处理出对于 $t$ 的每一个位置，从该位置开始往后每一个字符第一次出现的位置。

我们可以使用动态规划的方法实现预处理，令 $f[i][j]$ 表示字符串 $t$ 中从位置 $i$ 开始往后字符 $j$ 第一次出现的位置。在进行状态转移时，如果 $t$ 中位置 $i$ 的字符就是 $j$，那么 $f[i][j]=i$，否则 $j$ 出现在位置 $i+1$ 开始往后，即 $f[i][j]=f[i+1][j]$，因此我们要倒过来进行动态规划，从后往前枚举 $i$。

这样我们可以写出状态转移方程：

$$f[i][j]=\begin{cases} i, & t[i]=j \\ f[i+1][j], & t[i] \neq j \end{cases}$$

假定下标从 $0$ 开始，那么 $f[i][j]$ 中有 $0 \leq i \leq m-1$ ，对于边界状态 $f[m-1][..]$，我们置 $f[m][..]$ 为 $m$，让 $f[m-1][..]$ 正常进行转移。这样如果 $f[i][j]=m$，则表示从位置 $i$ 开始往后不存在字符 $j$。

这样，我们可以利用 $f$ 数组，每次 $O(1)$ 地跳转到下一个位置，直到位置变为 $m$ 或 $s$ 中的每一个字符都匹配成功。

> 同时我们注意到，该解法中对 $t$ 的处理与 $s$ 无关，且预处理完成后，可以利用预处理数组的信息，线性地算出任意一个字符串 $s$ 是否为 $t$ 的子串。这样我们就可以解决「后续挑战」啦。

**代码**

```cpp
class Solution {
public:
    bool isSubsequence(string s, string t) {
        int n = s.size(), m = t.size();

        vector<vector<int> > f(m + 1, vector<int>(26, 0));
        for (int i = 0; i < 26; i++) {
            f[m][i] = m;
        }

        for (int i = m - 1; i >= 0; i--) {
            for (int j = 0; j < 26; j++) {
                if (t[i] == j + 'a')
                    f[i][j] = i;
                else
                    f[i][j] = f[i + 1][j];
            }
        }
        int add = 0;
        for (int i = 0; i < n; i++) {
            if (f[add][s[i] - 'a'] == m) {
                return false;
            }
            add = f[add][s[i] - 'a'] + 1;
        }
        return true;
    }
};
```

```java
class Solution {
    public boolean isSubsequence(String s, String t) {
        int n = s.length(), m = t.length();

        int[][] f = new int[m + 1][26];
        for (int i = 0; i < 26; i++) {
            f[m][i] = m;
        }

        for (int i = m - 1; i >= 0; i--) {
            for (int j = 0; j < 26; j++) {
                if (t.charAt(i) == j + 'a')
                    f[i][j] = i;
                else
                    f[i][j] = f[i + 1][j];
            }
        }
        int add = 0;
        for (int i = 0; i < n; i++) {
            if (f[add][s.charAt(i) - 'a'] == m) {
                return false;
            }
            add = f[add][s.charAt(i) - 'a'] + 1;
        }
        return true;
    }
}
```

```python
class Solution:
    def isSubsequence(self, s: str, t: str) -> bool:
        n, m = len(s), len(t)
        f = [[0] * 26 for _ in range(m)]
        f.append([m] * 26)

        for i in range(m - 1, -1, -1):
            for j in range(26):
                f[i][j] = i if ord(t[i]) == j + ord('a') else f[i + 1][j]
        
        add = 0
        for i in range(n):
            if f[add][ord(s[i]) - ord('a')] == m:
                return False
            add = f[add][ord(s[i]) - ord('a')] + 1
        
        return True
```

```go
func isSubsequence(s string, t string) bool {
    n, m := len(s), len(t)
    f := make([][26]int, m + 1)
    for i := 0; i < 26; i++ {
        f[m][i] = m
    }
    for i := m - 1; i >= 0; i-- {
        for j := 0; j < 26; j++ {
            if t[i] == byte(j + 'a') {
                f[i][j] = i
            } else {
                f[i][j] = f[i + 1][j]
            }
        }
    }
    add := 0
    for i := 0; i < n; i++ {
        if f[add][int(s[i] - 'a')] == m {
            return false
        }
        add = f[add][int(s[i] - 'a')] + 1
    }
    return true
}
```

```c
bool isSubsequence(char* s, char* t) {
    int n = strlen(s), m = strlen(t);

    int f[m + 1][26];
    memset(f, 0, sizeof(f));
    for (int i = 0; i < 26; i++) {
        f[m][i] = m;
    }

    for (int i = m - 1; i >= 0; i--) {
        for (int j = 0; j < 26; j++) {
            if (t[i] == j + 'a')
                f[i][j] = i;
            else
                f[i][j] = f[i + 1][j];
        }
    }
    int add = 0;
    for (int i = 0; i < n; i++) {
        if (f[add][s[i] - 'a'] == m) {
            return false;
        }
        add = f[add][s[i] - 'a'] + 1;
    }
    return true;
}
```

**复杂度分析**

-   时间复杂度：$O(m \times |\Sigma| + n)$，其中 $n$ 为 $s$ 的长度，$m$ 为 $t$ 的长度，$\Sigma$ 为字符集，在本题中字符串只包含小写字母，$|\Sigma| = 26$。预处理时间复杂度 $O(m)$，判断子序列时间复杂度 $O(n)$。
    -   如果是计算 $k$ 个平均长度为 $n$ 的字符串是否为 $t$ 的子序列，则时间复杂度为 $O(m \times |\Sigma| +k \times n)$。
-   空间复杂度：$O(m \times |\Sigma|)$，为动态规划数组的开销。
