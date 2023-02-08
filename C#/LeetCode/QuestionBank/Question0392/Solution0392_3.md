#### [方法一：双指针](https://leetcode.cn/problems/is-subsequence/solutions/346539/pan-duan-zi-xu-lie-by-leetcode-solution/)

**思路及算法**

本题询问的是，$s$ 是否是 $t$ 的子序列，因此只要能找到任意一种 $s$ 在 $t$ 中出现的方式，即可认为 $s$ 是 $t$ 的子序列。

而当我们从前往后匹配，可以发现每次贪心地匹配靠前的字符是最优决策。

> 假定当前需要匹配字符 $c$，而字符 $c$ 在 $t$ 中的位置 $x_1$ 和 $x_2$ 出现（$x_1 < x_2$），那么贪心取 $x_1$ 是最优解，因为 $x_2$ 后面能取到的字符，$x_1$ 也都能取到，并且通过 $x_1$ 与 $x_2$ 之间的可选字符，更有希望能匹配成功。

这样，我们初始化两个指针 $i$ 和 $j$，分别指向 $s$ 和 $t$ 的初始位置。每次贪心地匹配，匹配成功则 $i$ 和 $j$ 同时右移，匹配 $s$ 的下一个位置，匹配失败则 $j$ 右移，$i$ 不变，尝试用 $t$ 的下一个字符匹配 $s$。

最终如果 $i$ 移动到 $s$ 的末尾，就说明 $s$ 是 $t$ 的子序列。

**代码**

```cpp
class Solution {
public:
    bool isSubsequence(string s, string t) {
        int n = s.length(), m = t.length();
        int i = 0, j = 0;
        while (i < n && j < m) {
            if (s[i] == t[j]) {
                i++;
            }
            j++;
        }
        return i == n;
    }
};
```

```java
class Solution {
    public boolean isSubsequence(String s, String t) {
        int n = s.length(), m = t.length();
        int i = 0, j = 0;
        while (i < n && j < m) {
            if (s.charAt(i) == t.charAt(j)) {
                i++;
            }
            j++;
        }
        return i == n;
    }
}
```

```python
class Solution:
    def isSubsequence(self, s: str, t: str) -> bool:
        n, m = len(s), len(t)
        i = j = 0
        while i < n and j < m:
            if s[i] == t[j]:
                i += 1
            j += 1
        return i == n
```

```go
func isSubsequence(s string, t string) bool {
    n, m := len(s), len(t)
    i, j := 0, 0
    for i < n && j < m {
        if s[i] == t[j] {
            i++
        }
        j++
    }
    return i == n
}
```

```c
bool isSubsequence(char* s, char* t) {
    int n = strlen(s), m = strlen(t);
    int i = 0, j = 0;
    while (i < n && j < m) {
        if (s[i] == t[j]) {
            i++;
        }
        j++;
    }
    return i == n;
}
```

**复杂度分析**

-   时间复杂度：$O(n+m)$，其中 $n$ 为 $s$ 的长度，$m$ 为 $t$ 的长度。每次无论是匹配成功还是失败，都有至少一个指针发生右移，两指针能够位移的总距离为 $n+m$。
-   空间复杂度：$O(1)$。
