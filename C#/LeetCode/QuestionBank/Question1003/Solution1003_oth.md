#### [栈+简洁写法（Python/Java/C++/Go）](https://leetcode.cn/problems/check-if-word-is-valid-after-substitutions/solutions/2253773/zhan-jian-ji-xie-fa-pythonjavacgo-by-end-i9o7/)

如果把问题改成「将字符串 `()` 插入到 ttt 中的任意位置」，比如 `() -> (()) -> (()())`，是不是很眼熟？在 [20\. 有效的括号](https://leetcode.cn/problems/valid-parentheses/) 中，我们用**栈**来判断括号是否合法：把左括号入栈，对于右括号，去判断栈顶是否为于其匹配的左括号。

对于本题来说，也可以用类似的方法完成：

-   字符 $a$：类似左括号，直接入栈。
-   字符 $b$：如果栈为空，或者栈顶不为 $a$，则返回 `false`，否则将栈顶修改为 $b$（或者出栈再入栈）。
-   字符 $c$：如果栈为空，或者栈顶不为 $b$，则返回 `false`，否则弹出栈顶，相当于找到了一个 $abc$。
-   代码实现时，$b$ 和 $c$ 的逻辑可以合并在一起，$a$ 和 $b$ 的入栈逻辑可以合并在一起。

循环结束后，如果栈为空，则返回 `true`，否则返回 `false`。

```python
class Solution:
    def isValid(self, s: str) -> bool:
        st = []
        for c in map(ord, s):
            if c > ord('a') and (len(st) == 0 or c - st.pop() != 1):
                return False
            if c < ord('c'):
                st.append(c)
        return len(st) == 0
```

```java
class Solution {
    public boolean isValid(String S) {
        var s = S.toCharArray(); // 同时作为栈
        int i = 0; // i-1 表示栈顶下标，i=0 表示栈为空
        for (var c : s) {
            if (c > 'a' && (i == 0 || c - s[--i] != 1))
                return false;
            if (c < 'c')
                s[i++] = c; // 入栈
        }
        return i == 0;
    }
}
```

```cpp
class Solution {
public:
    bool isValid(string s) { // s 同时作为栈
        int i = 0; // i-1 表示栈顶下标，i=0 表示栈为空
        for (char c: s) {
            if (c > 'a' && (i == 0 || c - s[--i] != 1))
                return false;
            if (c < 'c')
                s[i++] = c; // 入栈
        }
        return i == 0;
    }
};
```

```go
func isValid(s string) bool {
    st := []rune{}
    for _, c := range s {
        if c > 'a' {
            if len(st) == 0 {
                return false
            }
            top := st[len(st)-1]
            st = st[:len(st)-1]
            if c-top != 1 {
                return false
            }
        }
        if c < 'c' {
            st = append(st, c)
        }
    }
    return len(st) == 0
}
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $s$ 的长度。
-   空间复杂度：$\mathcal{O}(n)$ 或 $\mathcal{O}(1)$。如果可以直接修改字符串（例如 C++），那么只需 $\mathcal{O}(1)$ 的额外空间。
