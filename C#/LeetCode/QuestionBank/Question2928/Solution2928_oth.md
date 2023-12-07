### [O(1) 容斥原理（Python/Java/C++/Go）](https://leetcode.cn/problems/distribute-candies-among-children-i/solutions/2522970/o1-rong-chi-yuan-li-pythonjavacgo-by-end-smj5/)

请看 [视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Ww411T7JP%2F)。

要计算合法方案数（每个小朋友分到的糖果都不超过 $limit$），可以先计算所有方案数（没有 $limit$ 限制），再减去不合法的方案数（至少一个小朋友分到的糖果超过 $limit$）。

#### 所有方案数

相当于把 $n$ 个无区别的小球放入 $3$ 个有区别的盒子，允许空盒的方案数。

隔板法：假设 $n$ 个球和 $2$ 个隔板放到 $n+2$ 个位置，第一个隔板前的球放入第一个盒子，第一个隔板和第二个隔板之间的球放入第二个盒子，第二个隔板后的球放入第三个盒子。那么从 $n+2$ 个位置中选 $2$ 个位置放隔板，有 $C(n+2, 2)$ 种放法。注意隔板可以放在最左边或最右边，也可以连续放，对应着空盒的情况。

#### 至少一个小朋友分到的糖果超过 limit

设三个小朋友分别叫 $A,B,C$。

只关注 $A$。如果 $A$ 分到的糖果超过 $limit$，那么他至少分到 $limit+1$ 颗糖果，问题变成剩下 $n-(limit+1)$ 颗糖果分给三个小朋友的方案数，即 $C(n-(limit+1)+2, 2)$。注意 $B$ 和 $C$ 分到的糖果是否超过 $limit$ 我们是不关注的。

只关注 $B$ 的情况和只关注 $C$ 的情况同上，均为 $C(n-(limit+1)+2, 2)$。

直接加起来，就是 $3\cdot C(n-(limit+1)+2, 2)$，但这样就重复统计了「至少两个小朋友分到的糖果超过 $limit$」的情况，要减去。

#### 至少两个小朋友分到的糖果超过 limit

只关注 $A$ 和 $B$。如果他们俩分到的糖果超过 $limit$，那么至少分出去了 $2\cdot (limit+1)$ 颗糖果，问题变成剩下 $n-2\cdot (limit+1)$ 颗糖果分给三个小朋友的方案数，即 $C(n-2\cdot(limit+1)+2, 2)$。注意 $C$ 分到的糖果是否超过 $limit$ 我们是不关注的。

只关注 $A,C$ 的情况和只关注 $B,C$ 的情况同上，均为 $C(n-2\cdot(limit+1)+2, 2)$。

直接加起来，就是 $3\cdot C(n-2\cdot(limit+1)+2, 2)$，但这样就重复统计了「三个小朋友分到的糖果均超过 $limit$」的情况，要减去。

#### 三个小朋友分到的糖果超过 limit

至少分出去了 $3\cdot (limit+1)$ 颗糖果，问题变成剩下 $n-3\cdot (limit+1)$ 颗糖果分给三个小朋友的方案数，即 $C(n-3\cdot(limit+1)+2, 2)$。

#### 总结

不合法的方案数为「至少一个」减去「至少两个」加上「三个」，这就是**容斥原理**。

最后用所有方案数减去不合法的方案数，整理得到答案：

$$C(n+2, 2) - 3\cdot C(n-limit+1, 2) + 3\cdot C(n-2\cdot limit, 2) - C(n-3\cdot limit-1, 2)$$

```python
def c2(n: int) -> int:
    return n * (n - 1) // 2 if n > 1 else 0

class Solution:
    def distributeCandies(self, n: int, limit: int) -> int:
        return c2(n + 2) - 3 * c2(n - limit + 1) + 3 * c2(n - 2 * limit) - c2(n - 3 * limit - 1)
```

```java
class Solution {
    public int distributeCandies(int n, int limit) {
        return c2(n + 2) - 3 * c2(n - limit + 1) + 3 * c2(n - 2 * limit) - c2(n - 3 * limit - 1);
    }

    private int c2(int n) {
        return n > 1 ? n * (n - 1) / 2 : 0;
    }
}
```

```cpp
class Solution {
    int c2(int n) {
        return n > 1 ? n * (n - 1) / 2 : 0;
    }

public:
    int distributeCandies(int n, int limit) {
        return c2(n + 2) - 3 * c2(n - limit + 1) + 3 * c2(n - 2 * limit) - c2(n - 3 * limit - 1);
    }
};
```

```go
func c2(n int) int {
    if n < 2 {
        return 0
    }
    return n * (n - 1) / 2
}

func distributeCandies(n int, limit int) int {
    return c2(n+2) - 3*c2(n-limit+1) + 3*c2(n-2*limit) - c2(n-3*limit-1)
}
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(1)$。
-   空间复杂度：$\mathcal{O}(1)$。
