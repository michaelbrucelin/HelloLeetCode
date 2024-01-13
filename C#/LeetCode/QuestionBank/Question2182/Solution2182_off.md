### [构造限制重复的字符串](https://leetcode.cn/problems/construct-string-with-repeat-limit/solutions/1300982/gou-zao-xian-zhi-zhong-fu-de-zi-fu-chuan-v02s/)

#### 方法一：贪心 + 双指针

##### 提示 $1$

我们可以按照如下的方式构造字符串，这样构造出的字符串对应的字典序一定是最大的：

> 每次选择当前剩余的字典序最大的字符加到字符串末尾；如果字符串末尾的字符已经连续出现了 $repeatLimit$ 次，则将字典序次大的字符加到字符串末尾，随后继续选择当前剩余的字典序最大的字符加到字符串末尾，直至使用完字符或没有新的字符可以合法加入。

##### 提示 $1$ 解释

根据反证法，我们只需要证明任意比上述方法构造出的字符串 $ret$ 的字典序更大的字符串都是不合法的即可。

根据字典序的定义，上述证明可以分为两部分：

1. 从高位至低位逐位尝试使用字典序更大的字符替代，并逐个判断；
2. 尝试在 $ret$ 后添加新的字符，并逐个判断。

对于第一部分，任何使用更大的字符替代后的字符串要么使用了 $s$ 中不存在的字符，要么某一字符连续出现的次数大于 $repeatLimit$ 次，而这两种都是不合法的；对于第二部分，任何尝试添加新字符的字符串也一定是第一部分的两种情况之一，因而也是不合法的。

综上所述，按照上文方法构造的字符串的字典序一定是最大的。

##### 思路与算法

我们可以尝试按照提示 $1$ 的方式构造字典序最大的合法字符串 $ret$。具体方法如下：

首先，我们遍历 $s$，并用一个长度为 $N = 26$ 的数组 $count$ 统计 $s$ 中各个字符的出现次数，其中 $count[k]$ 代表小写字母表第 $k$ 个字符的出现次数。

与此同时，我们用下标 $i$ 指向当前未使用的字典序最大的字符，用下标 $j$ 来指向当前未使用的字典序次大的字符（满足 $count[j] > 0$ 以及 $j < i$），用 $m$ 记录当前已经填入的末尾字符的连续次数。

初始时 $i = N - 1$，$j = N - 2$，$m = 0$，接下来，我们模拟构造字符串的过程直到 $i \ge 0$ 且 $j \ge 0$ 不成立，有以下情况：

- 如果 $count[i] = 0$，那么说明当前的字符已经填完，我们将 $i$ 指向下一个字符，即 $i = i - 1$，同时重置 $m = 0$，继续构造字符串的过程。
- 如果 $count[i] \gt 0$ 且 $m \lt repeatLimit$，那么说明当前的字符可以合法填入，我们将该字符填入结果字符串 $ret$ 末尾，令 $count[i] = count[i] - 1$，$m = m + 1$，继续构造字符串的过程。
- 如果前两种情况不满足，且 $j \ge i$ 或 $count[j] = 0$，我们将 $j$ 指向下一个字符，即 $j = j - 1$，直到 $j \lt i$ 且 $count[j] > 0$ 成立；然后我们将第 $j$ 个字符填入结果字符串 $ret$ 的末尾，令 $count[j] = count[j] - 1$，同时重置 $m = 0$，继续构造字符串的过程。

构造结束后，$ret$ 即为符合要求的字典序最大的字符串，我们返回该字符串作为答案。

##### 代码

```c++
const int N = 26;
class Solution {
public:
    string repeatLimitedString(string s, int repeatLimit) {
        vector<int> count(N);
        for (char c : s) {
            count[c - 'a']++;
        }
        string ret;
        int m = 0;
        for (int i = N - 1, j = N - 2; i >= 0 && j >= 0;) {
            if (count[i] == 0) { // 当前字符已经填完，填入后面的字符，重置 m
                m = 0;
                i--;
            } else if (m < repeatLimit) { // 当前字符未超过限制
                count[i]--;
                ret.push_back('a' + i);
                m++;
            } else if (j >= i || count[j] == 0) { // 当前字符已经超过限制，查找可填入的其他字符
                j--;
            } else { // 当前字符已经超过限制，填入其他字符，并且重置 m
                count[j]--;
                ret.push_back('a' + j);
                m = 0;
            }
        }
        return ret;
    }
};
```

```java
class Solution {
    static public int N = 26;
    public String repeatLimitedString(String s, int repeatLimit) {
        int[] count = new int[N];
        for (int i = 0; i < s.length(); i++) {
            count[s.charAt(i) - 'a']++;
        }
        StringBuilder ret = new StringBuilder();
        int m = 0;
        for (int i = N - 1, j = N - 2; i >= 0 && j >= 0;) {
            if (count[i] == 0) { // 当前字符已经填完，填入后面的字符，重置 m
                m = 0;
                i--;
            } else if (m < repeatLimit) { // 当前字符未超过限制
                count[i]--;
                ret.append((char)('a' + i));
                m++;
            } else if (j >= i || count[j] == 0) { // 当前字符已经超过限制，查找可填入的其他字符
                j--;
            } else { // 当前字符已经超过限制，填入其他字符，并且重置 m
                count[j]--;
                ret.append((char)('a' + j));
                m = 0;
            }
        }
        return ret.toString();
    }
}
```

```csharp
public class Solution {
    const int N = 26;

    public string RepeatLimitedString(string s, int repeatLimit) {
        int[] count = new int[N];
        foreach (char c in s) {
            count[c - 'a']++;
        }
        StringBuilder ret = new StringBuilder();
        int m = 0;
        for (int i = N - 1, j = N - 2; i >= 0 && j >= 0;) {
            if (count[i] == 0) { // 当前字符已经填完，填入后面的字符，重置 m
                m = 0;
                i--;
            } else if (m < repeatLimit) { // 当前字符未超过限制
                count[i]--;
                ret.Append((char) ('a' + i));
                m++;
            } else if (j >= i || count[j] == 0) { // 当前字符已经超过限制，查找可填入的其他字符
                j--;
            } else { // 当前字符已经超过限制，填入其他字符，并且重置 m
                count[j]--;
                ret.Append((char) ('a' + j));
                m = 0;
            }
        }
        return ret.ToString();
    }
}
```

```python
class Solution:
    def repeatLimitedString(self, s: str, repeatLimit: int) -> str:
        N = 26
        count = [0] * N
        for c in s:
            count[ord(c) - ord('a')] += 1
        ret = []
        i, j, m = N - 1, N - 2, 0
        while i >= 0 and j >= 0:
            if count[i] == 0: # 当前字符已经填完，填入后面的字符，重置 m
                m, i = 0, i - 1
            elif m < repeatLimit: # 当前字符未超过限制
                count[i] -= 1
                ret.append(chr(ord('a') + i))
                m += 1
            elif j >= i or count[j] == 0: # 当前字符已经超过限制，查找可填入的其他字符
                j -= 1
            else: # 当前字符已经超过限制，填入其他字符，并且重置 m
                count[j] -= 1
                ret.append(chr(ord('a') + j))
                m = 0
        return ''.join(ret)
```

```go
const N = 26

func repeatLimitedString(s string, repeatLimit int) string {
    count := make([]int, 26)
    for _, c := range s {
        count[c - 'a']++
    }
    var ret []byte
    var m int
    for i, j := N - 1, N - 2; i >= 0 && j >= 0; {
        switch {
        case count[i] == 0: // 当前字符已经填完，填入后面的字符，重置 m
            m, i = 0, i - 1
        case m < repeatLimit: // 当前字符未超过限制
            count[i]--
            ret = append(ret, 'a' + byte(i))
            m++
        case j >= i ||count[j] == 0: // 当前字符已经超过限制，查找可填入的其他字符
            j--
        default: // 当前字符已经超过限制，填入其他字符，并且重置 m
            count[j]--
            ret = append(ret, 'a' + byte(j))
            m = 0
        }
    }
    return string(ret)
}
```

```c
#define N 26

char *repeatLimitedString(char *s, int repeatLimit) {
    int n = strlen(s), count[N] = {};
    for (int i = 0; i < n; i++) {
        count[s[i] - 'a']++;
    }
    char *ret = (char *)malloc(sizeof(char) * (n + 1)), *p = ret;
    memset(ret, 0, sizeof(char) * (n + 1));
    int m = 0;
    for (int i = N - 1, j = N - 2; i >= 0 && j >= 0;) {
        if (count[i] == 0) { // 当前字符已经填完，填入后面的字符，重置 m
            m = 0;
            i--;
        } else if (m < repeatLimit) { // 当前字符未超过限制
            count[i]--;
            *(p++) = 'a' + i;
            m++;
        } else if (j >= i || count[j] == 0) { // 当前字符已经超过限制，查找可填入的其他字符
            j--;
        } else { // 当前字符已经超过限制，填入其他字符，并且重置 m
            count[j]--;
            *(p++) = 'a' + j;
            m = 0;
        }
    }
    return ret;
}
```

```javascript
var repeatLimitedString = function(s, repeatLimit) {
    let N = 26;
    let count = new Array(N).fill(0);
    for (let i = 0; i < s.length; i++) {
        count[s.charCodeAt(i) - 97]++;
    }
    let ret = new Array();
    let m = 0;
    for (let i = N - 1, j = N - 2; i >= 0 && j >= 0;) {
        if (count[i] == 0) { // 当前字符已经填完，填入后面的字符，重置 m
            m = 0;
            i--;
        } else if (m < repeatLimit) { // 当前字符未超过限制
            count[i]--;
            ret.push(String.fromCharCode(97 + i));
            m++;
        } else if (j >= i || count[j] == 0) { // 当前字符已经超过限制，查找可填入的其他字符
            j--;
        } else { // 当前字符已经超过限制，填入其他字符，并且重置 m
            count[j]--;
            ret.push(String.fromCharCode(97 + j));
            m = 0;
        }
    }
    return ret.join('');
};
```

#### 复杂度分析

- 时间复杂度：$O(n + \Sigma)$，其中 $n$ 为 $s$ 的长度，$\Sigma = 26$ 为字符集的大小。
- 空间复杂度：$O(\Sigma)$ 或 $O(n + \Sigma)$。返回值不计入空间复杂度。某些语言字符串生成过程中需要 $O(n)$ 的空间开销。
