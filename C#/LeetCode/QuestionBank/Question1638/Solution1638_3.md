#### [方法一：枚举](https://leetcode.cn/problems/count-substrings-that-differ-by-one-character/solutions/2192088/tong-ji-zhi-chai-yi-ge-zi-fu-de-zi-chuan-z8xi/)

**思路与算法**

题目要求求出字符串 $s$ 与字符串 $t$ 的连续子串中只差一个字符的子串数目，我们枚举 $s$ 与 $t$ 的所有连续子串，然后找其中只含有差一个字符的子串对的数目即可。在实际枚举时，我们可以枚举 $s$ 与 $t$ 的子串的起点 $i,j$，并依次往后遍历，二者不同的字符个数为 $diff$，当我们遍历到起点开始的第 $k$ 个字符时:

-   如果 $s[i + k] = t[j + k]$，此时 $diff$ 的数目保持不变；
-   如果 $s[i + k] \neq t[j + k]$，此时 $diff$ 的数目加 $1$；
-   如果此时 $diff = 0$ 时，我们继续往后遍历；
-   如果此时 $diff = 1$ 时，此时子串 $s[i, \cdots,(i + k)]$ 与子串 $t[j, \cdots,(j + k)]$ 不同的字符数目为 $1$，此时计入答案一次；
-   如果此时 $diff > 1$ 时，此时子串 $s[i, \cdots,(i + k)]$ 与子串 $t[j, \cdots,(j + k)]$ 不同的字符数目大于 $1$，直接退出遍历；

我们最终统计出所有的符合题目要求的子串对即可。

**代码**

```python
class Solution:
    def countSubstrings(self, s: str, t: str) -> int:
        ans = 0
        for i in range(len(s)):
            for j in range(len(t)):
                diff = 0
                k = 0
                while i + k < len(s) and j + k < len(t):
                    if s[i + k] != t[j + k]:
                        diff += 1
                    if diff == 1:
                        ans += 1
                    elif diff > 1:
                        break
                    k += 1
        return ans
```

```cpp
class Solution {
public:
    int countSubstrings(string s, string t) {
        int m = s.size(), n = t.size();
        int ans = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int diff = 0;
                for (int k = 0; i + k < m && j + k < n; k++) {
                    diff += s[i + k] == t[j + k] ? 0 : 1;
                    if (diff > 1) {
                        break;
                    } else if (diff == 1) {
                        ans++;
                    }
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int countSubstrings(String s, String t) {
        int m = s.length(), n = t.length();
        int ans = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int diff = 0;
                for (int k = 0; i + k < m && j + k < n; k++) {
                    diff += s.charAt(i + k) == t.charAt(j + k) ? 0 : 1;
                    if (diff > 1) {
                        break;
                    } else if (diff == 1) {
                        ans++;
                    }
                }
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int CountSubstrings(string s, string t) {
        int m = s.Length, n = t.Length;
        int ans = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int diff = 0;
                for (int k = 0; i + k < m && j + k < n; k++) {
                    diff += s[i + k] == t[j + k] ? 0 : 1;
                    if (diff > 1) {
                        break;
                    } else if (diff == 1) {
                        ans++;
                    }
                }
            }
        }
        return ans;
    }
}
```

```c
int countSubstrings(char * s, char * t) {
    int m = strlen(s), n = strlen(t);
    int ans = 0;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            int diff = 0;
            for (int k = 0; i + k < m && j + k < n; k++) {
                diff += s[i + k] == t[j + k] ? 0 : 1;
                if (diff > 1) {
                    break;
                } else if (diff == 1) {
                    ans++;
                }
            }
        }
    }
    return ans;
}
```

```javascript
var countSubstrings = function(s, t) {
    const m = s.length, n = t.length;
    let ans = 0;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            let diff = 0;
            for (let k = 0; i + k < m && j + k < n; k++) {
                diff += s[i + k] === t[j + k] ? 0 : 1;
                if (diff > 1) {
                    break;
                } else if (diff === 1) {
                    ans++;
                }
            }
        }
    }
    return ans;
};
```

```go
func countSubstrings(s, t string) (ans int) {
    m, n := len(s), len(t)
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            diff := 0
            for k := 0; i+k < m && j+k < n; k++ {
                if s[i+k] != t[j+k] {
                    diff++
                }
                if diff > 1 {
                    break
                } else if diff == 1 {
                    ans++
                }
            }
        }
    }
    return ans
}
```

**复杂度分析**

-   时间复杂度：$O(m \times n \times \min(m,n))$，其中 $m,n$ 分别为字符串 $s$ 与 $t$ 的长度。我们需要枚举 $s$ 与 $t$ 的起点，此时总共有 $m \times n$ 对起点，每对起点遍历的长度最多为 $\min(m,n)$，因此时间复杂度为 $O(m \times n \times \min(m,n))$。
-   空间复杂度：$O(1)$。
