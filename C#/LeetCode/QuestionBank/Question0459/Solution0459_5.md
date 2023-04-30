#### [方法四：优化的 KMP 算法](https://leetcode.cn/problems/repeated-substring-pattern/solutions/386481/zhong-fu-de-zi-zi-fu-chuan-by-leetcode-solution/)

**思路与算法**

如果读者能够看懂「正确性证明」和「思考题答案」这两部分，那么一定已经发现了方法三中的 KMP 算法有可以优化的地方。即：

-   在「正确性证明」部分，如果我们设 $i$ 为**最小的**起始位置，那么一定有 $\mathrm{gcd}(n, i) = i$，即 $n$ 是 $i$ 的倍数。这说明字符串 $s$ 是由长度为 $i$ 的前缀重复 $\frac{n}{i}$ 次构成；
-   由于 $fail[n-1]$ 表示 $s$ 具有长度为 $fail[n-1]+1$ 的完全相同的（且最长的）前缀和后缀。那么对于满足题目要求的字符串，一定有 $fail[n-1] = n-i-1$，即 $i = n - fail[n-1] - 1$；
-   对于不满足题目要求的字符串，$n$ 一定不是 $n - fail[n-1] - 1$ 的倍数。

> 上述所有的结论都可以很容易地使用反证法证出。

因此，我们在预处理出 $fail$ 数组后，只需要判断 $n$ 是否为 $n - fail[n-1] - 1$ 的倍数即可。

**代码**

```cpp
class Solution {
public:
    bool kmp(const string& pattern) {
        int n = pattern.size();
        vector<int> fail(n, -1);
        for (int i = 1; i < n; ++i) {
            int j = fail[i - 1];
            while (j != -1 && pattern[j + 1] != pattern[i]) {
                j = fail[j];
            }
            if (pattern[j + 1] == pattern[i]) {
                fail[i] = j + 1;
            }
        }
        return fail[n - 1] != -1 && n % (n - fail[n - 1] - 1) == 0;
    }

    bool repeatedSubstringPattern(string s) {
        return kmp(s);
    }
};
```

```java
class Solution {
    public boolean repeatedSubstringPattern(String s) {
        return kmp(s);
    }

    public boolean kmp(String pattern) {
        int n = pattern.length();
        int[] fail = new int[n];
        Arrays.fill(fail, -1);
        for (int i = 1; i < n; ++i) {
            int j = fail[i - 1];
            while (j != -1 && pattern.charAt(j + 1) != pattern.charAt(i)) {
                j = fail[j];
            }
            if (pattern.charAt(j + 1) == pattern.charAt(i)) {
                fail[i] = j + 1;
            }
        }
        return fail[n - 1] != -1 && n % (n - fail[n - 1] - 1) == 0;
    }
}
```

```python
class Solution:
    def repeatedSubstringPattern(self, s: str) -> bool:
        def kmp(pattern: str) -> bool:
            n = len(pattern)
            fail = [-1] * n
            for i in range(1, n):
                j = fail[i - 1]
                while j != -1 and pattern[j + 1] != pattern[i]:
                    j = fail[j]
                if pattern[j + 1] == pattern[i]:
                    fail[i] = j + 1
            return fail[n - 1] != -1 and n % (n - fail[n - 1] - 1) == 0
        
        return kmp(s)
```

```go
func repeatedSubstringPattern(s string) bool {
    return kmp(s)
}

func kmp(pattern string) bool {
    n := len(pattern)
    fail := make([]int, n)
    for i := 0; i < n; i++ {
        fail[i] = -1
    }
    for i := 1; i < n; i++ {
        j := fail[i - 1]
        for (j != -1 && pattern[j + 1] != pattern[i]) {
            j = fail[j]
        }
        if pattern[j + 1] == pattern[i] {
            fail[i] = j + 1
        }
    }
    return fail[n - 1] != -1 && n % (n - fail[n - 1] - 1) == 0
}
```

```c
bool kmp(char* pattern) {
    int n = strlen(pattern);
    int fail[n];
    memset(fail, -1, sizeof(fail));
    for (int i = 1; i < n; ++i) {
        int j = fail[i - 1];
        while (j != -1 && pattern[j + 1] != pattern[i]) {
            j = fail[j];
        }
        if (pattern[j + 1] == pattern[i]) {
            fail[i] = j + 1;
        }
    }
    return fail[n - 1] != -1 && n % (n - fail[n - 1] - 1) == 0;
}

bool repeatedSubstringPattern(char* s) {
    return kmp(s);
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
-   空间复杂度：$O(n)$。
