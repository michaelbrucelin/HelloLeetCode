#### [方法二：组合数学](https://leetcode.cn/problems/count-sorted-vowel-strings/solutions/2195462/tong-ji-zi-dian-xu-yuan-yin-zi-fu-chuan-sk7y1/)

对于一个按字典序排列的元音字符串，假设 $'a'$，$'e'$，$'i'$，$'o'$，$'u'$ 的起始下标分别为 $i_a$，$i_e$，$i_i$，$i_o$，$i_u$，显然 $i_a=0$ 且 $0 \le i_e \le i_i \le i_o \le i_u \le n$。因此字典序元音字符串的数目等于满足 $0 \le i_e \le i_i \le i_o \le i_u \le n$ 的 $(i_e, i_i, i_o, i_u)$ 的取值数目。想要直接求得 $(i_e, i_i, i_o, i_u)$ 的取值数目是十分困难的，我们可以作以下转换：

$$\begin{align} i_e'&=i_e \\ i_i'&=i_i+1 \\ i_o'&=i_o+2 \\ i_u'&=i_u+3 \\ \end{align}$$

由 $0 \le i_e \le i_i \le i_o \le i_u \le n$ 可知 $0 \le i_e' \lt i_i' \lt i_o' \lt i_u' \le n + 3$。每一个 $(i_e, i_i, i_o, i_u)$ 都唯一地对应一个 $(i_e', i_i', i_o', i_u')$，因此 $(i_e, i_i, i_o, i_u)$ 的取值数目等于 $(i_e', i_i', i_o', i_u')$ 的取值数目。$(i_e', i_i', i_o', i_u')$ 等价于从 $n+4$ 个数中选取互不相等的 $4$ 个数，因此$(i_e', i_i', i_o', i_u')$ 的取值数目等于组合数 $C^{4}_{n+4}$。

```python
class Solution:
    def countVowelStrings(self, n: int) -> int:
        return comb(n + 4, 4)
```

```cpp
class Solution {
public:
    int countVowelStrings(int n) {
        return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
    }
};
```

```java
class Solution {
    public int countVowelStrings(int n) {
        return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
    }
}
```

```csharp
public class Solution {
    public int CountVowelStrings(int n) {
        return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
    }
}
```

```c
int countVowelStrings(int n) {
    return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
}
```

```javascript
var countVowelStrings = function(n) {
    return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
};
```

```go
func countVowelStrings(n int) int {
    return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24
}
```

**复杂度分析**

-   时间复杂度：$O(\Sigma)$，其中 $\Sigma = 5$ 表示元音字符集大小。
-   空间复杂度：$O(1)$。
