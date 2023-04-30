#### [方法一：枚举](https://leetcode.cn/problems/repeated-substring-pattern/solutions/386481/zhong-fu-de-zi-zi-fu-chuan-by-leetcode-solution/)

**思路与算法**

如果一个长度为 $n$ 的字符串 $s$ 可以由它的一个长度为 $n'$ 的子串 $s'$ 重复多次构成，那么：

-   $n$ 一定是 $n'$ 的倍数；
-   $s'$ 一定是 $s$ 的前缀；
-   对于任意的 $i \in [n', n)$，有 $s[i] = s[i-n']$。

也就是说，$s$ 中长度为 $n'$ 的前缀就是 $s'$，并且在这之后的每一个位置上的字符 $s[i]$，都需要与它之前的第 $n'$ 个字符 $s[i-n']$ 相同。

因此，我们可以从小到大枚举 $n'$，并对字符串 $s$ 进行遍历，进行上述的判断。注意到一个小优化是，因为子串至少需要重复一次，所以 $n'$ 不会大于 $n$ 的一半，我们只需要在 $[1, \frac{n}{2}]$ 的范围内枚举 $n'$ 即可。

**代码**

```cpp
class Solution {
public:
    bool repeatedSubstringPattern(string s) {
        int n = s.size();
        for (int i = 1; i * 2 <= n; ++i) {
            if (n % i == 0) {
                bool match = true;
                for (int j = i; j < n; ++j) {
                    if (s[j] != s[j - i]) {
                        match = false;
                        break;
                    }
                }
                if (match) {
                    return true;
                }
            }
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean repeatedSubstringPattern(String s) {
        int n = s.length();
        for (int i = 1; i * 2 <= n; ++i) {
            if (n % i == 0) {
                boolean match = true;
                for (int j = i; j < n; ++j) {
                    if (s.charAt(j) != s.charAt(j - i)) {
                        match = false;
                        break;
                    }
                }
                if (match) {
                    return true;
                }
            }
        }
        return false;
    }
}
```

```python
class Solution:
    def repeatedSubstringPattern(self, s: str) -> bool:
        n = len(s)
        for i in range(1, n // 2 + 1):
            if n % i == 0:
                if all(s[j] == s[j - i] for j in range(i, n)):
                    return True
        return False
```

```go
func repeatedSubstringPattern(s string) bool {
    n := len(s)
    for i := 1; i * 2 <= n; i++ {
        if n % i == 0 {
            match := true
            for j := i; j < n; j++ {
                if s[j] != s[j - i] {
                    match = false
                    break
                }
            }
            if match {
                return true
            }
        }
    }
    return false
}
```

```c
bool repeatedSubstringPattern(char* s) {
    int n = strlen(s);
    for (int i = 1; i * 2 <= n; ++i) {
        if (n % i == 0) {
            bool match = true;
            for (int j = i; j < n; ++j) {
                if (s[j] != s[j - i]) {
                    match = false;
                    break;
                }
            }
            if (match) {
                return true;
            }
        }
    }
    return false;
}
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 是字符串 $s$ 的长度。枚举 $i$ 的时间复杂度为 $O(n)$，遍历 $s$ 的时间复杂度为 $O(n)$，相乘即为总时间复杂度。
-   空间复杂度：$O(1)$。
