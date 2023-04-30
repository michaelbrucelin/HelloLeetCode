#### [方法二：字符串匹配](https://leetcode.cn/problems/repeated-substring-pattern/solutions/386481/zhong-fu-de-zi-zi-fu-chuan-by-leetcode-solution/)

**思路与算法**

我们可以把字符串 $s$ 写成

$$s's' \cdots s's'$$

的形式，总计 $\frac{n}{n'}$ 个 $s'$。但我们如何在不枚举 $n'$ 的情况下，判断 $s$ 是否能写成上述的形式呢？

如果我们移除字符串 $s$ 的前 $n'$ 个字符（即一个完整的 $s'$），再将这些字符保持顺序添加到剩余字符串的末尾，那么得到的字符串仍然是 $s$。由于 $1 \leq n' < n$，那么如果将两个 $s$ 连在一起，并移除第一个和最后一个字符，那么得到的字符串一定包含 $s$，即 $s$ 是它的一个子串。

因此我们可以考虑这种方法：我们将两个 $s$ 连在一起，并移除第一个和最后一个字符。如果 $s$ 是该字符串的子串，那么 $s$ 就满足题目要求。

注意到我们证明的是**如果 $s$ 满足题目要求，那么 $s$ 有这样的性质**，而我们使用的方法却是**如果 $s$ 有这样的性质，那么 $s$ 满足题目要求**。因此，只证明了充分性是远远不够的，我们还需要证明必要性。

> 题解区的很多题解都忽略了这一点，但它是非常重要的。

证明需要使用一些同余运算的小技巧，可以见方法三之后的「正确性证明」部分。这里先假设我们已经完成了证明，这样就可以使用非常简短的代码完成本题。在下面的代码中，我们可以从位置 $1$ 开始查询，并希望查询结果不为位置 $n$，这与移除字符串的第一个和最后一个字符是等价的。

**代码**

```cpp
class Solution {
public:
    bool repeatedSubstringPattern(string s) {
        return (s + s).find(s, 1) != s.size();
    }
};
```

```java
class Solution {
    public boolean repeatedSubstringPattern(String s) {
        return (s + s).indexOf(s, 1) != s.length();
    }
}
```

```python
class Solution:
    def repeatedSubstringPattern(self, s: str) -> bool:
        return (s + s).find(s, 1) != len(s)
```

```c
bool repeatedSubstringPattern(char* s) {
    int n = strlen(s);
    char k[2 * n + 1];
    k[0] = 0;
    strcat(k, s);
    strcat(k, s);
    return strstr(k + 1, s) - k != n;
}
```

**复杂度分析**

由于我们使用了语言自带的字符串查找函数，因此这里不深入分析其时空复杂度。
