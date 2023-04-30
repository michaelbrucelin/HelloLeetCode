﻿#### [【图解】非暴力 O(nm) 算法（Python/Java/C++/Go）](https://leetcode.cn/problems/count-substrings-that-differ-by-one-character/solutions/2192600/tu-jie-fei-bao-li-onm-suan-fa-pythonjava-k5og/)

![](./assets/img/Solution1638_5_01.png)

##### 思想总结

如果暴力枚举 $i,j,k$，这种 $O(nm\cdot\min(n,m))$ 的立方复杂度做法也是可以通过本题的。

但注意到 $(i,j)$ 可以复用 $(i-1,j-1)$ 的计算结果（类比动态规划），就可以进一步减少计算量，从而降低时间复杂度。

```python
class Solution:
    def countSubstrings(self, s: str, t: str) -> int:
        ans, n, m = 0, len(s), len(t)
        for d in range(1 - m, n):  # d=i-j, j=i-d
            i = max(d, 0)
            k0 = k1 = i - 1
            while i < n and i - d < m:
                if s[i] != t[i - d]:
                    k0 = k1  # 上上一个不同
                    k1 = i   # 上一个不同
                ans += k1 - k0
                i += 1
        return ans
```

```java
class Solution {
    public int countSubstrings(String S, String T) {
        char[] s = S.toCharArray(), t = T.toCharArray();
        int ans = 0, n = s.length, m = t.length;
        for (int d = 1 - m; d < n; ++d) { // d=i-j, j=i-d
            int i = Math.max(d, 0);
            for (int k0 = i - 1, k1 = k0; i < n && i - d < m; ++i) {
                if (s[i] != t[i - d]) {
                    k0 = k1; // 上上一个不同
                    k1 = i;  // 上一个不同
                }
                ans += k1 - k0;
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int countSubstrings(string s, string t) {
        int ans = 0, n = s.length(), m = t.length();
        for (int d = 1 - m; d < n; ++d) { // d=i-j, j=i-d
            int i = max(d, 0);
            for (int k0 = i - 1, k1 = k0; i < n && i - d < m; ++i) {
                if (s[i] != t[i - d])
                    k0 = k1, k1 = i;
                ans += k1 - k0;
            }
        }
        return ans;
    }
};
```

```go
func countSubstrings(s, t string) (ans int) {
    n, m := len(s), len(t)
    for d := 1 - m; d < n; d++ { // d=i-j, j=i-d
        i := max(d, 0)
        for k0, k1 := i-1, i-1; i < n && i-d < m; i++ {
            if s[i] != t[i-d] {
                k0 = k1 // 上上一个不同
                k1 = i  // 上一个不同
            }
            ans += k1 - k0
        }
    }
    return
}

func max(a, b int) int { if a < b { return b }; return a }
```

##### 复杂度分析

-   时间复杂度：$O(nm)$，其中 $n$ 为 $s$ 的长度，$m$ 为 $t$ 的长度。$d$ 有 $O(n+m)$ 个，每个 $d$ 需要花费 $O(\min(n,m))$ 的时间枚举，所以总的时间复杂度为 $O((n+m)\cdot\min(n,m))$。如果 $n>m$，则 $O(n+m)=O(n)$，$O(\min(n,m))=O(m)$，所以 $O((n+m)\cdot\min(n,m))=O(nm)$；对于 $n<m$ 同理。所以时间复杂度可以简化为 $O(nm)$。
-   空间复杂度：$O(1)$，仅用到若干额外变量。

##### 相似题目

-   [795\. 区间子数组个数](https://leetcode.cn/problems/number-of-subarrays-with-bounded-maximum/)，[题解](https://leetcode.cn/problems/number-of-subarrays-with-bounded-maximum/solution/tu-jie-yi-ci-bian-li-jian-ji-xie-fa-pyth-n75l/)
-   [2444\. 统计定界子数组的数目](https://leetcode.cn/problems/count-subarrays-with-fixed-bounds/)，[题解](https://leetcode.cn/problems/count-subarrays-with-fixed-bounds/solution/jian-ji-xie-fa-pythonjavacgo-by-endlessc-gag2/)
