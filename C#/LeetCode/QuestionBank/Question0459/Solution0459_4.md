#### [方法三：KMP 算法](https://leetcode.cn/problems/repeated-substring-pattern/solutions/386481/zhong-fu-de-zi-zi-fu-chuan-by-leetcode-solution/)

**思路与算法**

在方法二中，我们使用了语言自带的字符串查找函数。同样我们也可以自己实现这个函数，例如使用比较经典的 KMP 算法。

读者需要注意以下几点：

-   KMP 算法虽然有着良好的理论时间复杂度上限，但大部分语言自带的字符串查找函数并不是用 KMP 算法实现的。这是因为在实现 API 时，我们需要在平均时间复杂度和最坏时间复杂度二者之间权衡。普通的暴力匹配算法以及优化的 BM 算法拥有比 KMP 算法更为优秀的平均时间复杂度；
-   学习 KMP 算法时，一定要理解其本质。如果放弃阅读晦涩难懂的材料（即使大部分讲解 KMP 算法的材料都包含大量的图，但图毕竟只能描述特殊而非一般情况）而是直接去阅读代码，是永远无法学会 KMP 算法的。读者甚至无法理解 KMP 算法关键代码中的任意一行。

由于本题就是在一个字符串中查询另一个字符串是否出现，可以直接套用 KMP 算法。因此这里对 KMP 算法本身不再赘述。读者可以自行查阅资料进行学习。这里留了三个思考题，读者可以在学习完毕后尝试回答这三个问题，检验自己的学习成果：

-   设查询串的的长度为 $n$，模式串的长度为 $m$，我们需要判断模式串是否为查询串的子串。那么使用 KMP 算法处理该问题时的时间复杂度是多少？在分析时间复杂度时使用了哪一种分析方法？
-   如果有多个查询串，平均长度为 $n$，数量为 $k$，那么总时间复杂度是多少？
-   在 KMP 算法中，对于模式串，我们需要预处理出一个 $fail$ 数组（有时也称为 $next$ 数组、$\pi$ 数组等）。这个数组到底表示了什么？

**代码**

```cpp
class Solution {
public:
    bool kmp(const string& query, const string& pattern) {
        int n = query.size();
        int m = pattern.size();
        vector<int> fail(m, -1);
        for (int i = 1; i < m; ++i) {
            int j = fail[i - 1];
            while (j != -1 && pattern[j + 1] != pattern[i]) {
                j = fail[j];
            }
            if (pattern[j + 1] == pattern[i]) {
                fail[i] = j + 1;
            }
        }
        int match = -1;
        for (int i = 1; i < n - 1; ++i) {
            while (match != -1 && pattern[match + 1] != query[i]) {
                match = fail[match];
            }
            if (pattern[match + 1] == query[i]) {
                ++match;
                if (match == m - 1) {
                    return true;
                }
            }
        }
        return false;
    }

    bool repeatedSubstringPattern(string s) {
        return kmp(s + s, s);
    }
};
```

```java
class Solution {
    public boolean repeatedSubstringPattern(String s) {
        return kmp(s + s, s);
    }

    public boolean kmp(String query, String pattern) {
        int n = query.length();
        int m = pattern.length();
        int[] fail = new int[m];
        Arrays.fill(fail, -1);
        for (int i = 1; i < m; ++i) {
            int j = fail[i - 1];
            while (j != -1 && pattern.charAt(j + 1) != pattern.charAt(i)) {
                j = fail[j];
            }
            if (pattern.charAt(j + 1) == pattern.charAt(i)) {
                fail[i] = j + 1;
            }
        }
        int match = -1;
        for (int i = 1; i < n - 1; ++i) {
            while (match != -1 && pattern.charAt(match + 1) != query.charAt(i)) {
                match = fail[match];
            }
            if (pattern.charAt(match + 1) == query.charAt(i)) {
                ++match;
                if (match == m - 1) {
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
        def kmp(query: str, pattern: str) -> bool:
            n, m = len(query), len(pattern)
            fail = [-1] * m
            for i in range(1, m):
                j = fail[i - 1]
                while j != -1 and pattern[j + 1] != pattern[i]:
                    j = fail[j]
                if pattern[j + 1] == pattern[i]:
                    fail[i] = j + 1
            match = -1
            for i in range(1, n - 1):
                while match != -1 and pattern[match + 1] != query[i]:
                    match = fail[match]
                if pattern[match + 1] == query[i]:
                    match += 1
                    if match == m - 1:
                        return True
            return False
        
        return kmp(s + s, s)
```

```go
func repeatedSubstringPattern(s string) bool {
    return kmp(s + s, s)
}

func kmp(query, pattern string) bool {
    n, m := len(query), len(pattern)
    fail := make([]int, m)
    for i := 0; i < m; i++ {
        fail[i] = -1
    }
    for i := 1; i < m; i++ {
        j := fail[i - 1]
        for j != -1 && pattern[j + 1] != pattern[i] {
            j = fail[j]
        }
        if pattern[j + 1] == pattern[i] {
            fail[i] = j + 1
        }
    }
    match := -1
    for i := 1; i < n - 1; i++ {
        for match != -1 && pattern[match + 1] != query[i] {
            match = fail[match]
        }
        if pattern[match + 1] == query[i] {
            match++
            if match == m - 1 {
                return true
            }
        }
    }
    return false
}
```

```c
bool kmp(char* query, char* pattern) {
    int n = strlen(query);
    int m = strlen(pattern);
    int fail[m];
    memset(fail, -1, sizeof(fail));
    for (int i = 1; i < m; ++i) {
        int j = fail[i - 1];
        while (j != -1 && pattern[j + 1] != pattern[i]) {
            j = fail[j];
        }
        if (pattern[j + 1] == pattern[i]) {
            fail[i] = j + 1;
        }
    }
    int match = -1;
    for (int i = 1; i < n - 1; ++i) {
        while (match != -1 && pattern[match + 1] != query[i]) {
            match = fail[match];
        }
        if (pattern[match + 1] == query[i]) {
            ++match;
            if (match == m - 1) {
                return true;
            }
        }
    }
    return false;
}

bool repeatedSubstringPattern(char* s) {
    int n = strlen(s);
    char k[2 * n + 1];
    k[0] = 0;
    strcat(k, s);
    strcat(k, s);
    return kmp(k, s);
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是字符串 $s$ 的长度。
-   空间复杂度：$O(n)$。

#### 正确性证明

一方面，如果长度为 $n$ 的字符串 $s$ 是字符串 $t=s+s$ 的子串，并且 $s$ 在 $t$ 中的起始位置不为 $0$ 或 $n$，那么 $s$ 就满足题目的要求。证明过程如下：

-   我们设 $s$ 在 $t$ 中的起始位置为 $i$，$i \in (0, n)$。也就是说，$t$ 中从位置 $i$ 开始的 $n$ 个连续的字符，恰好就是字符串 $s$。那么我们有：
    $$s[0:n-1] = t[i:n+i-1]$$
    由于 $t$ 是由两个 $s$ 拼接而成的，我们可以将 $t[i:n+i-1]$ 分成位置 $n-1$ 左侧和右侧两部分：
    $$\left \{ \begin{aligned} s[0:n-i-1] &= t[i:n-1] \\ s[n-i:n-1] &= t[n:n+i-1] = t[0:i-1] \end{aligned} \right.$$
    每一部分都可以对应回 $s$：
    $$\left \{ \begin{aligned} s[0:n-i-1] &= s[i:n-1] \\ s[n-i:n-1] &= s[0:i-1] \end{aligned} \right.$$
    这说明，$s$ 是一个「可旋转」的字符串：将 $s$ 的前 $i$ 个字符保持顺序，移动到 $s$ 的末尾，得到的新字符串与 $s$ 相同。也就是说，**在模 $n$ 的意义下**，
    $$s[j] = s[j+i]$$
    对于任意的 $j$ 恒成立。
    > 「在模 $n$ 的意义下」可以理解为，所有的加法运算的结果都需要对 $n$ 取模，使得结果保持在 $[0, n)$ 中，这样加法就自带了「旋转」的效果。

    如果我们不断地连写这个等式：
    $$s[j] = s[j+i] = s[j+2i] = s[j+3i] = \cdots$$
    那么所有满足 $j_0 = j + k \cdot i$ 的位置 $j_0$ 都有 $s[j] = s[j_0]$，$j$ 和 $j_0$ 在模 $i$ 的意义下等价。由于我们已经在模 $n$ 的意义下讨论这个问题，因此 $j$ 和 $j_0$ 在模 $\mathrm{gcd}(n, i)$ 的意义下等价，其中 $\mathrm{gcd}$ 表示最大公约数。也就是说，字符串 $s$ 中的两个位置如果在模 $\mathrm{gcd}(n, i)$ 的意义下等价，那么它们对应的字符必然是相同的。
    由于 $\mathrm{gcd}(n, i)$ 一定是 $n$ 的约数，那么字符串 $s$ 一定可以由其长度为 $\mathrm{gcd}(n, i)$ 的前缀重复 $\frac{n}{\mathrm{gcd}(n, i)}$ 次构成。

另一方面，如果 $s$ 满足题目的要求，那么 $s$ 包含若干个「部分」，$t=s+s$ 包含两倍数量的「部分」，因此 $s$ 显然是 $t$ 的子串，并且起始位置可以不为 $0$ 或 $n$：我们只需要选择 $t$ 中第一个「部分」的起始位置即可。

综上所述，我们证明了：长度为 $n$ 的字符串 $s$ 是字符串 $t=s+s$ 的子串，并且 $s$ 在 $t$ 中的起始位置不为 $0$ 或 $n$，**当且仅当** $s$ 满足题目的要求。因此，

#### 思考题答案

-   设查询串的的长度为 $n$，模式串的长度为 $m$，我们需要判断模式串是否为查询串的子串。那么使用 KMP 算法处理该问题时的时间复杂度是多少？在分析时间复杂度时使用了哪一种分析方法？
    -   时间复杂度为 $O(n+m)$，用到了均摊分析（摊还分析）的方法。
    -   具体地，无论在预处理过程还是查询过程中，虽然匹配失败时，指针会不断地根据 $fail$ 数组向左回退，看似时间复杂度会很高。但考虑匹配成功时，指针会向右移动一个位置，这一部分对应的时间复杂度为 $O(n+m)$。又因为向左移动的次数不会超过向右移动的次数，因此总时间复杂度仍然为 $O(n+m)$。
-   如果有多个查询串，平均长度为 $n$，数量为 $k$，那么总时间复杂度是多少？
    -   时间复杂度为 $O(nk+m)$。模式串只需要预处理一次。
-   在 KMP 算法中，对于模式串，我们需要预处理出一个 $fail$ 数组（有时也称为 $next$ 数组、$\pi$ 数组等）。这个数组到底表示了什么？
    -   $fail[i]$ 等于满足下述要求的 $x$ 的最大值：$s[0:i]$ 具有长度为 $x+1$ 的完全相同的前缀和后缀。这也是 KMP 算法最重要的一部分。
