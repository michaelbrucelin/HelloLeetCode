﻿#### [教你一步步思考动态规划！（Python/Java/C++/Go）](https://leetcode.cn/problems/dice-roll-simulation/solutions/2103292/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-sje6/)

有些题解一上来就把状态定义甩在了读者脸上，丝毫不说这个定义是怎么来的，仿佛从天而降。这也让很多同学对动态规划产生了畏难心态。

其实，对于不少动态规划问题，「如何想出状态定义和状态转移方程」是有套路的。我在[【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)中讲到，可以用**回溯**来启发思考。本文将遵照这个过程，来讲讲怎么从回溯开始，一步步写出最后的递推代码。

> APP 用户需要分享到 wx 打开链接。

#### 第一步：思考回溯怎么写

想一想，掷了一个骰子（设值为 $x$）后，会发生什么情况？

既然题目有 $rollMax$ 的限制，那么分类讨论：

-   如果和上一个骰子值相同，那么 $x$ 的连续出现次数不能超过 $rollMax[x]$；
-   如果不同，那么可以重置连续出现次数为 $1$。

#### 关键词提取：「上一个骰子值」和「连续出现次数」

那么在回溯中就需要知道（为了方便后面转成递推，定义成**剩余**）：

-   剩余掷骰子的次数，用 $i$ 表示；
-   上一个骰子值，用 $last$ 表示；
-   $last$ 的剩余连续出现次数，用 $left$ 表示。

这样就确定了递归的参数，递归的返回值就是骰子序列个数。

要递归到哪里去呢？我们可以用回溯中的经典技巧「枚举选哪个」：

-   如果选的骰子值和上一个相同，且 $left > 0$，那么递归到 $(i−1, last, left−1)$；
-   如果不同，设为 $j$，那么递归到 $(i−1, j, rollMax[j]−1)$。

枚举 $j=0,1,2,3,4,5$，把递归后的结果相加，就是当前 $(i, last, left)$ 的答案。

递归到 $n=0$ 时结束，返回 $1$，表示找到了一个合法骰子序列。

最终答案为

$$\sum_{j=0}^{j=5}dfs(n-1,j,rollMax[j]-1)$$

记得取模。

```python
# 会超时的回溯写法
class Solution:
    def dieSimulator(self, n: int, rollMax: List[int]) -> int:
        MOD = 10 ** 9 + 7
        def dfs(i: int, last: int, left: int) -> int:
            if i == 0: return 1
            res = 0
            for j, mx in enumerate(rollMax):
                if j != last: res += dfs(i - 1, j, mx - 1)
                elif left: res += dfs(i - 1, j, left - 1)
            return res % MOD
        return sum(dfs(n - 1, j, mx - 1) for j, mx in enumerate(rollMax)) % MOD
```

```java
// 会超时的回溯写法
class Solution {
    private static final long MOD = (long) 1e9 + 7;
    private int[] rollMax;

    public int dieSimulator(int n, int[] rollMax) {
        this.rollMax = rollMax;
        int m = rollMax.length;
        long ans = 0;
        for (int j = 0; j < m; ++j)
            ans += dfs(n - 1, j, rollMax[j] - 1);
        return (int) (ans % MOD);
    }

    private int dfs(int i, int last, int left) {
        if (i == 0) return 1;
        long res = 0;
        for (int j = 0; j < rollMax.length; ++j)
            if (j != last) res += dfs(i - 1, j, rollMax[j] - 1);
            else if (left > 0) res += dfs(i - 1, j, left - 1);
        return (int) (res % MOD);
    }
}
```

```cpp
// 会超时的回溯写法
class Solution {
    const long MOD = 1e9 + 7;
public:
    int dieSimulator(int n, vector<int> &rollMax) {
        int m = rollMax.size();
        function<int(int, int, int)> dfs = [&](int i, int last, int left) -> int {
            if (i == 0) return 1;
            long res = 0;
            for (int j = 0; j < m; ++j)
                if (j != last) res += dfs(i - 1, j, rollMax[j] - 1);
                else if (left) res += dfs(i - 1, j, left - 1);
            return res % MOD;
        };
        long ans = 0;
        for (int j = 0; j < m; ++j)
            ans += dfs(n - 1, j, rollMax[j] - 1);
        return ans % MOD;
    }
};
```

```go
// 会超时的回溯写法
func dieSimulator(n int, rollMax []int) (ans int) {
    const mod int = 1e9 + 7
    var dfs func(int, int, int) int
    dfs = func(i, last, left int) (res int) {
        if i == 0 {
            return 1
        }
        for j, mx := range rollMax {
            if j != last {
                res += dfs(i-1, j, mx-1)
            } else if left > 0 {
                res += dfs(i-1, j, left-1)
            }
        }
        return res % mod
    }
    for j, mx := range rollMax {
        ans += dfs(n-1, j, mx-1)
    }
    return ans % mod
}
```

#### 第二步：改成记忆化搜索

举个例子，「先掷 $1$ 后掷 $3$」和「先掷 $2$ 后掷 $3$」，都会递归到 $dfs(n−2, 3, rollMax[3]−1)$。

一叶知秋，整个回溯过程是有大量重复递归调用的。由于递归函数没有副作用，无论多少次调用 $dfs(i,last,left)$ 算出来的结果都是一样的，因此可以用**记忆化搜索**来优化：

-   如果一个状态（递归入参）是第一次遇到，那么可以在返回前，把状态及其结果记到一个 $cache$ 数组（或者哈希表）中；
-   如果一个状态不是第一次遇到，那么直接返回 $cache$ 中保存的结果。

```python
class Solution:
    def dieSimulator(self, n: int, rollMax: List[int]) -> int:
        MOD = 10 ** 9 + 7
        @cache
        def dfs(i: int, last: int, left: int) -> int:
            if i == 0: return 1
            res = 0
            for j, mx in enumerate(rollMax):
                if j != last: res += dfs(i - 1, j, mx - 1)
                elif left: res += dfs(i - 1, j, left - 1)
            return res % MOD
        return sum(dfs(n - 1, j, mx - 1) for j, mx in enumerate(rollMax)) % MOD
```

```java
class Solution {
    private static final long MOD = (long) 1e9 + 7;
    private int[] rollMax;
    private int[][][] cache;

    public int dieSimulator(int n, int[] rollMax) {
        this.rollMax = rollMax;
        int m = rollMax.length;
        cache = new int[n][m][15];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; ++j)
                Arrays.fill(cache[i][j], -1); // -1 表示没有访问过
        long ans = 0;
        for (int j = 0; j < m; ++j)
            ans += dfs(n - 1, j, rollMax[j] - 1);
        return (int) (ans % MOD);
    }

    private int dfs(int i, int last, int left) {
        if (i == 0) return 1;
        if (cache[i][last][left] >= 0) return cache[i][last][left];
        long res = 0;
        for (int j = 0; j < rollMax.length; ++j)
            if (j != last) res += dfs(i - 1, j, rollMax[j] - 1);
            else if (left > 0) res += dfs(i - 1, j, left - 1);
        return cache[i][last][left] = (int) (res % MOD);
    }
}
```

```cpp
class Solution {
    const long MOD = 1e9 + 7;
public:
    int dieSimulator(int n, vector<int> &rollMax) {
        int m = rollMax.size(), cache[n][m][15];
        memset(cache, -1, sizeof(cache)); // -1 表示没有访问过
        function<int(int, int, int)> dfs = [&](int i, int last, int left) -> int {
            if (i == 0) return 1;
            int *c = &cache[i][last][left];
            if (*c >= 0) return *c;
            long res = 0;
            for (int j = 0; j < m; ++j)
                if (j != last) res += dfs(i - 1, j, rollMax[j] - 1);
                else if (left) res += dfs(i - 1, j, left - 1);
            return *c = res % MOD;
        };
        long ans = 0;
        for (int j = 0; j < m; ++j)
            ans += dfs(n - 1, j, rollMax[j] - 1);
        return ans % MOD;
    }
};
```

```go
func dieSimulator(n int, rollMax []int) (ans int) {
    const mod int = 1e9 + 7
    const m = 6
    cache := make([][m][]int, n)
    for i := range cache {
        for j := range cache[i] {
            cache[i][j] = make([]int, rollMax[j])
            for k := range cache[i][j] {
                cache[i][j][k] = -1 // -1 表示没有访问过
            }
        }
    }
    var dfs func(int, int, int) int
    dfs = func(i, last, left int) (res int) {
        if i == 0 {
            return 1
        }
        c := &cache[i][last][left]
        if *c != -1 {
            return *c
        }
        for j, mx := range rollMax {
            if j != last {
                res += dfs(i-1, j, mx-1)
            } else if left > 0 {
                res += dfs(i-1, j, left-1)
            }
        }
        res %= mod
        *c = res
        return
    }
    for j, mx := range rollMax {
        ans += dfs(n-1, j, mx-1)
    }
    return ans % mod
}
```

#### 复杂度分析

-   时间复杂度：$O(nmS)$，其中 $m$ 为 $rollMax$ 的长度，即 $6$，$S=\sum rollMax$，这不会超过 $6 \times 15=90$。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的转移个数。本题中状态个数等于 $O(nS)$，而单个状态的转移个数为 $O(m)$，因此时间复杂度为 $O(nmS)$。
-   空间复杂度：$O(nS)$。

#### 第三步：1比1翻译成递推

根据视频中讲的，我们可以去掉递归中的「递」，只保留「归」的部分，即自底向上计算。

做法：

-   $dfs$ 改成 $f$ 数组；
-   递归改成循环（每个参数都对应一层循环）；
-   递归边界改成 $f$ 数组的初始值。

就完事了。

```python
class Solution:
    def dieSimulator(self, n: int, rollMax: List[int]) -> int:
        MOD = 10 ** 9 + 7
        m = len(rollMax)  # 6
        f = [[[0] * mx for mx in rollMax] for _ in range(n)]
        f[0] = [[1] * mx for mx in rollMax]
        for i in range(1, n):
            for last, mx in enumerate(rollMax):
                for left in range(mx):
                    res = 0
                    for j in range(m):
                        if j != last:
                            res += f[i - 1][j][-1]
                        elif left:
                            res += f[i - 1][j][left - 1]
                    f[i][last][left] = res % MOD
        return sum(f[-1][j][-1] for j in range(m)) % MOD
```

```java
class Solution {
    private static final long MOD = (long) 1e9 + 7;

    public int dieSimulator(int n, int[] rollMax) {
        int m = rollMax.length; // 6
        var f = new int[n][m][15];
        for (int j = 0; j < m; ++j)
            Arrays.fill(f[0][j], 1);
        for (int i = 1; i < n; ++i)
            for (int last = 0; last < m; ++last)
                for (int left = 0; left < rollMax[last]; ++left) {
                    long res = 0;
                    for (int j = 0; j < m; ++j)
                        if (j != last) res += f[i - 1][j][rollMax[j] - 1];
                        else if (left > 0) res += f[i - 1][j][left - 1];
                    f[i][last][left] = (int) (res % MOD);
                }
        long ans = 0;
        for (int j = 0; j < m; ++j)
            ans += f[n - 1][j][rollMax[j] - 1];
        return (int) (ans % MOD);
    }
}
```

```cpp
class Solution {
    const long MOD = 1e9 + 7;
public:
    int dieSimulator(int n, vector<int> &rollMax) {
        int m = rollMax.size(), f[n][m][15];
        for (int j = 0; j < m; ++j)
            for (int k = 0; k < rollMax[j]; ++k)
                f[0][j][k] = 1;
        for (int i = 1; i < n; ++i)
            for (int last = 0; last < m; ++last)
                for (int left = 0; left < rollMax[last]; ++left) {
                    long res = 0;
                    for (int j = 0; j < m; ++j)
                        if (j != last) res += f[i - 1][j][rollMax[j] - 1];
                        else if (left) res += f[i - 1][j][left - 1];
                    f[i][last][left] = res % MOD;
                }
        long ans = 0;
        for (int j = 0; j < m; ++j)
            ans += f[n - 1][j][rollMax[j] - 1];
        return ans % MOD;
    }
};
```

```go
func dieSimulator(n int, rollMax []int) (ans int) {
    const mod int = 1e9 + 7
    const m = 6
    f := make([][m][]int, n)
    for i := range f {
        for j := range f[i] {
            f[i][j] = make([]int, rollMax[j])
        }
    }
    for j := range f[0] {
        for k := range f[0][j] {
            f[0][j][k] = 1
        }
    }
    for i := 1; i < n; i++ {
        for last, mx0 := range rollMax {
            for left := 0; left < mx0; left++ {
                res := 0
                for j, mx := range rollMax {
                    if j != last {
                        res += f[i-1][j][mx-1]
                    } else if left > 0 {
                        res += f[i-1][j][left-1]
                    }
                }
                f[i][last][left] = res % mod
            }
        }
    }
    for j, mx := range rollMax {
        ans += f[n-1][j][mx-1]
    }
    return ans % mod
}
```

#### 复杂度分析

同上。

#### 优化

![](./assets/img/Solution1223_5_01.png)

```python
class Solution:
    def dieSimulator(self, n: int, rollMax: List[int]) -> int:
        MOD = 10 ** 9 + 7
        m = len(rollMax)  # 6
        f = [[0] * m for _ in range(n)]
        f[0] = [1] * m
        s = [0] * n
        s[0] = m
        for i in range(1, n):
            for j, mx in enumerate(rollMax):
                res = s[i - 1]
                if i > mx: res -= s[i - mx - 1] - f[i - mx - 1][j]
                elif i == mx: res -= 1
                f[i][j] = res % MOD
            s[i] = sum(f[i]) % MOD
        return s[-1]
```

```java
class Solution {
    private static final int MOD = (int) 1e9 + 7;

    public int dieSimulator(int n, int[] rollMax) {
        int m = rollMax.length; // 6
        var f = new int[n][m];
        var s = new int[n];
        Arrays.fill(f[0], 1);
        s[0] = m;
        for (int i = 1; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                int res = s[i - 1], mx = rollMax[j];
                if (i > mx) res -= s[i - mx - 1] - f[i - mx - 1][j];
                else if (i == mx) --res;
                f[i][j] = (res % MOD + MOD) % MOD; // 防止出现负数
                s[i] = (s[i] + f[i][j]) % MOD;
            }
        }
        return s[n - 1];
    }
}
```

```cpp
class Solution {
    const int MOD = 1e9 + 7;
public:
    int dieSimulator(int n, vector<int> &rollMax) {
        int m = rollMax.size(), f[n][m], s[n];
        for (int j = 0; j < m; ++j) f[0][j] = 1;
        s[0] = m;
        for (int i = 1; i < n; ++i) {
            s[i] = 0;
            for (int j = 0; j < m; ++j) {
                int res = s[i - 1], mx = rollMax[j];
                if (i > mx) res -= s[i - mx - 1] - f[i - mx - 1][j];
                else if (i == mx) --res;
                f[i][j] = (res % MOD + MOD) % MOD; // 防止出现负数
                s[i] = (s[i] + f[i][j]) % MOD;
            }
        }
        return s[n - 1];
    }
};
```

```go
func dieSimulator(n int, rollMax []int) int {
    const mod int = 1e9 + 7
    const m = 6
    f := make([][m]int, n)
    for j := range f[0] {
        f[0][j] = 1
    }
    s := make([]int, n)
    s[0] = m
    for i := 1; i < n; i++ {
        for j, mx := range rollMax {
            res := s[i-1]
            if i > mx {
                res -= s[i-mx-1] - f[i-mx-1][j]
            } else if i == mx {
                res--
            }
            f[i][j] = (res%mod + mod) % mod // 防止出现负数
            s[i] = (s[i] + f[i][j]) % mod
        }
    }
    return s[n-1]
}
```

#### 复杂度分析

-   时间复杂度：$O(nm)$。其中 $m$ 为 $rollMax$ 的长度，即 $6$。
-   空间复杂度：$O(nm)$。

#### 强化训练

可以看 [从周赛中学算法 - 2022 年周赛题目总结（下篇）](https://leetcode.cn/circle/discuss/WR1MJP/) 的「动态规划」这节，所有题目我都写了题解。
