### [两种思路：动态规划/单调栈（Python/Java/C++/Go）](https://leetcode.cn/problems/minimum-difficulty-of-a-job-schedule/solutions/2271631/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-68nx/)

### [方法一：动态规划](https://leetcode.cn/problems/minimum-difficulty-of-a-job-schedule/solutions/2271631/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-68nx/)

#### 视频讲解

详见 [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)。

> APP 用户如果无法打开，可以分享到微信。

#### 步骤一：寻找子问题

为简化描述，下文用 $a$ 表示 $jobDifficulty$，并设其长度为 $n$。

根据题意，必须按照顺序（从 $a[0]$ 到 $a[n-1]$），**恰好**用 $d$ 天完成这 $n$ 项工作，且每天至少完成一项。

这相当于把数组 $a$ 分割成 $d$ 段（每一段都不能为空），我们需要求出每一段的最大值，并把这些最大值相加。在所有分割方案中，最大值之和的最小值就是我们要返回的值（下文简称为「答案」）。如果 $n<d$，则无法满足「每天至少完成一项工作」的要求，返回 $-1$。

对于这类数组/字符串的分割问题，由于分割出一段后，剩余部分需要分成 $d-1$ 段，**要解决的问题规模变小，且和原问题是相似的**，所以可以从「寻找子问题」的角度来思考。

例如「计算用 $d=3$ 天时间完成 $n=5$ 项工作的答案」，考虑最后一天完成了最后 $2$ 项工作（注意必须按照顺序完成），问题就变成「计算用 $d'=3-1=2$ 天时间完成 $a$ 的前 $n'=5-2=3$ 项工作的答案」这样一个规模更小的子问题了。

#### 步骤二：递归函数的定义与状态转移

由于子问题和原问题是相似的，所以可以用**递归**解决。从上面这个例子可以知道，递归需要两个参数 $(i,j)$，其中 $i$ 用来表示天数，$j$ 用来表示工作数。

具体地，定义 $dfs(i,j)$ 表示用 $i+1$ 天时间完成 $a[0]$ 到 $a[j]$ 这些工作的答案。

> 注：这样定义 $i$ 是为了利用 $0$，方便后面翻译成递推，毕竟数组的下标是从 $0$ 开始的。

枚举最后一段工作的开始下标 $k$，那么问题变成两部分：

-   计算从 $a[k]$ 到 $a[j]$ 的这段的最大值，设为 $mx$。
-   用 $i$ 天时间完成 $a[0]$ 到 $a[k-1]$ 这些工作的答案，即 $dfs(i-1,k-1)$。

用 $dfs(i-1,k-1)$ 加上 $mx$，去更新 $dfs(i,j)$ 的最小值。写成式子就是

$$dfs(i,j) = \min_{k=i}^{j}\left\{dfs(i-1,k-1) + \max_{p=k}^{j}a[p]\right\}$$

这里 $k$ 最小是 $i$，因为题目要求「每天至少完成一项工作」，所以需要给前面的天数预留一些工作。

递归边界：$dfs(0,j) = \max\limits_{p=0}^{j}a[p]$。只有一天，必须完成剩余的所有工作。

递归入口：$dfs(d-1,n-1)$，也就是答案。

> 注：倒着递归是为了方便后面 1:1 翻译成递推，因为「归」的过程就是正向递推的过程。

代码实现时，可以从 $j$ 开始倒着枚举 $k$，一边枚举一边计算 $mx$。

#### 步骤三：改成记忆化搜索

对于最后两天，「先完成 $1$ 项工作，再完成 $2$ 项工作」，以及「先完成 $2$ 项工作，再完成 $1$ 项工作」，都会递归到 $dfs(d-3,n-4)$。

一叶知秋，整个递归中有大量重复递归调用（递归入参相同）。由于递归函数没有副作用，同样的入参无论计算多少次，算出来的结果都是一样的，因此可以用**记忆化搜索**来优化：

-   如果一个状态（递归入参）是第一次遇到，那么可以在返回前，把状态及其结果记到一个 $memo$ 数组（或哈希表）中。
-   如果再次递归到该状态，那么直接返回 $memo$ 中保存的结果。

> 注：Python 在递归函数上面添加一个 `@cache` 装饰器，即可实现记忆化搜索。

```python
class Solution:
    def minDifficulty(self, a: List[int], d: int) -> int:
        n = len(a)
        if n < d:
            return -1

        @cache  # 缓存装饰器，避免重复计算 dfs 的结果
        def dfs(i: int, j: int) -> int:
            if i == 0:  # 只有一天，必须完成所有工作
                return max(a[:j + 1])
            res, mx = inf, 0
            for k in range(j, i - 1, -1):
                mx = max(mx, a[k])  # 从 a[k] 到 a[j] 的最大值
                res = min(res, dfs(i - 1, k - 1) + mx)
            return res

        return dfs(d - 1, n - 1)
```

```java
class Solution {
    private int[] a;
    private int[][] memo;

    public int minDifficulty(int[] a, int d) {
        int n = a.length;
        if (n < d) return -1;

        this.a = a;
        memo = new int[d][n];
        for (int i = 0; i < d; ++i)
            Arrays.fill(memo[i], -1); // -1 表示还没有计算过
        return dfs(d - 1, n - 1);
    }

    private int dfs(int i, int j) {
        if (memo[i][j] != -1) // 之前计算过了
            return memo[i][j];
        if (i == 0) { // 只有一天，必须完成所有工作
            int mx = 0;
            for (int k = 0; k <= j; k++)
                mx = Math.max(mx, a[k]);
            return memo[i][j] = mx;
        }
        int res = Integer.MAX_VALUE;
        int mx = 0;
        for (int k = j; k >= i; k--) {
            mx = Math.max(mx, a[k]); // 从 a[k] 到 a[j] 的最大值
            res = Math.min(res, dfs(i - 1, k - 1) + mx);
        }
        return memo[i][j] = res;
    }
}
```

```cpp
class Solution {
public:
    int minDifficulty(vector<int> &a, int d) {
        int n = a.size();
        if (n < d) return -1;

        int memo[d][n];
        memset(memo, -1, sizeof(memo));
        // -1 表示还没有计算过
        function<int(int, int)> dfs = [&](int i, int j) -> int {
            int &res = memo[i][j]; // 注意这里是引用，下面会直接修改 memo[i][j]
            if (res != -1) // 之前计算过了
                return res;
            if (i == 0) { // 只有一天，必须完成所有工作
                int mx = 0;
                for (int k = 0; k <= j; k++)
                    mx = max(mx, a[k]);
                return res = mx;
            }
            res = INT_MAX;
            int mx = 0;
            for (int k = j; k >= i; k--) {
                mx = max(mx, a[k]); // 从 a[k] 到 a[j] 的最大值
                res = min(res, dfs(i - 1, k - 1) + mx);
            }
            return res;
        };
        return dfs(d - 1, n - 1);
    }
};
```

```go
func minDifficulty(a []int, d int) int {
    n := len(a)
    if n < d {
        return -1
    }

    memo := make([][]int, d)
    for i := range memo {
        memo[i] = make([]int, n)
        for j := range memo[i] {
            memo[i][j] = -1 // -1 表示还没有计算过
        }
    }
    var dfs func(int, int) int
    dfs = func(i, j int) (res int) {
        p := &memo[i][j]
        if *p != -1 { // 之前计算过了
            return *p
        }
        defer func() { *p = res }() // 记忆化
        if i == 0 { // 只有一天，必须完成所有工作
            for _, x := range a[:j+1] {
                res = max(res, x)
            }
            return
        }
        res = math.MaxInt
        mx := 0
        for k := j; k >= i; k-- {
            mx = max(mx, a[k]) // 从 a[k] 到 a[j] 的最大值
            res = min(res, dfs(i-1, k-1)+mx)
        }
        return
    }
    return dfs(d-1, n-1)
}

func min(a, b int) int { if b < a { return b }; return a }
func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n^2d)$，其中 $n$ 为 $a$ 的长度。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题中状态个数等于 $\mathcal{O}(nd)$，单个状态的计算时间为 $\mathcal{O}(n)$，因此时间复杂度为 $\mathcal{O}(n^2d)$。
-   空间复杂度：$\mathcal{O}(nd)$。有 $\mathcal{O}(nd)$ 个状态。

#### 步骤四：1:1 翻译成递推

根据视频中讲的，我们可以去掉递归中的「递」，只保留「归」的部分，即自底向上计算。

做法：

-   $dfs$ 改成 $f$ 数组。
-   递归改成循环（每个参数都对应一层循环）。
-   递归边界改成 $f$ 数组的初始值。

递推式和递归**完全一致**：

$$f[i][j]=\min_{k=i}^{j}\left\{f[i-1][k-1] + \max_{p=k}^{j}a[p]\right\}$$

初始值 $f[0][j]=\max\limits_{p=0}^{j}a[p]$，翻译自递归边界 $dfs(0,j) = \max\limits_{p=0}^{j}a[p]$。

答案为 $f[d-1][n-1]$，翻译自递归入口 $dfs(d-1,n-1)$。

```python
class Solution:
    def minDifficulty(self, a: List[int], d: int) -> int:
        n = len(a)
        if n < d:
            return -1

        f = [[inf] * n for _ in range(d)]
        f[0] = list(accumulate(a, max))
        for i in range(1, d):
            for j in range(i, n):
                mx = 0
                for k in range(j, i - 1, -1):
                    mx = max(mx, a[k])  # 从 a[k] 到 a[j] 的最大值
                    f[i][j] = min(f[i][j], f[i - 1][k - 1] + mx)
        return f[-1][-1]
```

```java
class Solution {
    public int minDifficulty(int[] a, int d) {
        int n = a.length;
        if (n < d) return -1;

        var f = new int[d][n];
        f[0][0] = a[0];
        for (int i = 1; i < n; i++)
            f[0][i] = Math.max(f[0][i - 1], a[i]);
        for (int i = 1; i < d; i++) {
            for (int j = n - 1; j >= i; j--) {
                f[i][j] = Integer.MAX_VALUE;
                int mx = 0;
                for (int k = j; k >= i; k--) {
                    mx = Math.max(mx, a[k]); // 从 a[k] 到 a[j] 的最大值
                    f[i][j] = Math.min(f[i][j], f[i - 1][k - 1] + mx);
                }
            }
        }
        return f[d - 1][n - 1];
    }
}
```

```cpp
class Solution {
public:
    int minDifficulty(vector<int> &a, int d) {
        int n = a.size();
        if (n < d) return -1;

        int f[d][n];
        f[0][0] = a[0];
        for (int i = 1; i < n; i++)
            f[0][i] = max(f[0][i - 1], a[i]);
        for (int i = 1; i < d; i++) {
            for (int j = n - 1; j >= i; j--) {
                f[i][j] = INT_MAX;
                int mx = 0;
                for (int k = j; k >= i; k--) {
                    mx = max(mx, a[k]); // 从 a[k] 到 a[j] 的最大值
                    f[i][j] = min(f[i][j], f[i - 1][k - 1] + mx);
                }
            }
        }
        return f[d - 1][n - 1];
    }
};
```

```go
func minDifficulty(a []int, d int) int {
    n := len(a)
    if n < d {
        return -1
    }

    f := make([][]int, d)
    f[0] = make([]int, n)
    f[0][0] = a[0]
    for i := 1; i < n; i++ {
        f[0][i] = max(f[0][i-1], a[i])
    }
    for i := 1; i < d; i++ {
        f[i] = make([]int, n)
        for j := n - 1; j >= i; j-- {
            f[i][j] = math.MaxInt
            mx := 0
            for k := j; k >= i; k-- {
                mx = max(mx, a[k]) // 从 a[k] 到 a[j] 的最大值
                f[i][j] = min(f[i][j], f[i-1][k-1]+mx)
            }
        }
    }
    return f[d-1][n-1]
}

func min(a, b int) int { if b < a { return b }; return a }
func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(dn^2)$，其中 $n$ 为 $a$ 的长度。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题中状态个数等于 $\mathcal{O}(dn)$，单个状态的计算时间为 $\mathcal{O}(n)$，因此时间复杂度为 $\mathcal{O}(dn^2)$。
-   空间复杂度：$\mathcal{O}(dn)$。有 $\mathcal{O}(dn)$ 个状态。

#### 步骤五：空间优化

视频讲解见 [背包问题](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV16Y411v7Y6%2F) 中的的空间优化。

由于 $f[i]$ 只从 $f[i-1]$ 转移过来，我们可以去掉第一个维度，只用一个一维数组。

和 0-1 背包问题一样，如果 $j$ 从小到大遍历，那么 $f[i-1][j]$ 这一数据会被 $f[i][j]$ 覆盖，但是计算右边的 $f[i][j']$ 时，又需要 $f[i-1][j]$。倒序遍历 $j$ 即可解决此问题。

```python
class Solution:
    def minDifficulty(self, a: List[int], d: int) -> int:
        n = len(a)
        if n < d:
            return -1

        f = list(accumulate(a, max))
        for i in range(1, d):
            for j in range(n - 1, i - 1, -1):
                f[j] = inf
                mx = 0
                for k in range(j, i - 1, -1):
                    mx = max(mx, a[k])  # 从 a[k] 到 a[j] 的最大值
                    f[j] = min(f[j], f[k - 1] + mx)
        return f[-1]
```

```java
class Solution {
    public int minDifficulty(int[] a, int d) {
        int n = a.length;
        if (n < d) return -1;

        var f = new int[n];
        f[0] = a[0];
        for (int i = 1; i < n; i++)
            f[i] = Math.max(f[i - 1], a[i]);
        for (int i = 1; i < d; i++) {
            for (int j = n - 1; j >= i; j--) {
                f[j] = Integer.MAX_VALUE;
                int mx = 0;
                for (int k = j; k >= i; k--) {
                    mx = Math.max(mx, a[k]); // 从 a[k] 到 a[j] 的最大值
                    f[j] = Math.min(f[j], f[k - 1] + mx);
                }
            }
        }
        return f[n - 1];
    }
}
```

```cpp
class Solution {
public:
    int minDifficulty(vector<int> &a, int d) {
        int n = a.size();
        if (n < d) return -1;

        int f[n];
        f[0] = a[0];
        for (int i = 1; i < n; i++)
            f[i] = max(f[i - 1], a[i]);
        for (int i = 1; i < d; i++) {
            for (int j = n - 1; j >= i; j--) {
                f[j] = INT_MAX;
                int mx = 0;
                for (int k = j; k >= i; k--) {
                    mx = max(mx, a[k]); // 从 a[k] 到 a[j] 的最大值
                    f[j] = min(f[j], f[k - 1] + mx);
                }
            }
        }
        return f[n - 1];
    }
};
```

```go
func minDifficulty(a []int, d int) int {
    n := len(a)
    if n < d {
        return -1
    }

    f := make([]int, n)
    f[0] = a[0]
    for i := 1; i < n; i++ {
        f[i] = max(f[i-1], a[i])
    }
    for i := 1; i < d; i++ {
        for j := n - 1; j >= i; j-- {
            f[j] = math.MaxInt
            mx := 0
            for k := j; k >= i; k-- {
                mx = max(mx, a[k]) // 从 a[k] 到 a[j] 的最大值
                f[j] = min(f[j], f[k-1]+mx)
            }
        }
    }
    return f[n-1]
}

func min(a, b int) int { if b < a { return b }; return a }
func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(dn^2)$，其中 $n$ 为 $a$ 的长度。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题中状态个数等于 $\mathcal{O}(dn)$，单个状态的计算时间为 $\mathcal{O}(n)$，因此时间复杂度为 $\mathcal{O}(dn^2)$。
-   空间复杂度：$\mathcal{O}(n)$。

#### 相似题目（动态规划）

-   [1043\. 分隔数组以得到最大和](https://leetcode.cn/problems/partition-array-for-maximum-sum/)，[题解](https://leetcode.cn/problems/partition-array-for-maximum-sum/solution/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-rq5i/)
-   [1105\. 填充书架](https://leetcode.cn/problems/filling-bookcase-shelves/)，[题解](https://leetcode.cn/problems/filling-bookcase-shelves/solution/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-0vg6/)
-   [1416\. 恢复数组](https://leetcode.cn/problems/restore-the-array/)

### [方法二：单调栈优化 DP](https://leetcode.cn/problems/minimum-difficulty-of-a-job-schedule/solutions/2271631/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-68nx/)

阅读前，请确保您已熟悉单调栈的计算过程，具体可以看我之前写的这篇 [题解](https://leetcode.cn/problems/next-greater-node-in-linked-list/solution/tu-jie-dan-diao-zhan-liang-chong-fang-fa-v9ab/)。

设 $left[j]$ 为 $a[j]$ 左侧最近更大元素的下标。

对于 $a=[2,9,1,8,1,2,7]$，分类讨论：

-   如果最后一段**至少**有 $4$ 项工作，由于 $a[3]=8$ 是 $a[6]=7$ 的左侧最近更大元素，所以最后一段的最大值**不可能**是 $[1,2,7]$ 中的任何一个数，那么直接忽略这 $3$ 个数，整个数组的答案和 $[2,9,1,8]$ 的答案是一样的，即 $f[i][6] = f[i][left[6]] = f[i][3]$。特别地，如果 $left[6]$ 不存在，则不考虑这种情况。
-   如果最后一段**至多**有 $3$ 项工作，那么 $a[6]=7$ 就是这些工作的最大值，方法一的递推式可以化简为

$$f[i][6]=a[6] + \min_{k=left[6]+1}^{6} f[i-1][k-1]$$

这两种情况取最小值，即为 $f[i][6]$。

想到这里，已经可以用线段树或者 ST 表等数据结构优化上式中的 $⁡\min$ 了，时间复杂度 $\mathcal{O}(dn\log n)$。但还有更巧妙的做法，可以做到时间复杂度 $\mathcal{O}(dn)$。

由于需要从 $f[i][j]$ 左侧的状态 $f[i][left[j]]$ 转移过来，$j$ 必须从小到大遍历，所以

$$\min_{k=left[j]+1}^{j} f[i-1][k-1]$$

中的 $j$ 也是在不断变大的。（注意 $left[j]$ 并不是单调的。）

那么上式计算最小值的过程，其实和利用单调栈计算 $left[j]$ 是一样的。在用单调栈计算 $left[j]$ 时，栈中除了保存下标 $j$，还可以保存上式的结果。

例如 $a=[4,1,2,3]$，假设此时外层循环的 $i=1$，那么从 $a[1]$ 开始遍历：

-   遍历到 $a[1]=1$ 时，把下标 $j=1$ 以及 $f[i-1][0]$ 入栈。
-   遍历到 $a[2]=2$ 时，由于 $a[2]>a[1]$，弹出栈顶，把下标 $j=2$ 以及 $f[i-1][0]$ 和 $f[i-1][1]$ 的最小值入栈。
-   遍历到 $a[3]=3$ 时，由于 $a[3]>a[2]$，弹出栈顶，把下标 $j=3$ 以及 $f[i-1][0]$、$f[i-1][1]$ 和 $f[i-1][2]$ 的最小值入栈。注意到，栈中已经保存了 $f[i-1][0]$ 和 $f[i-1][1]$ 的最小值，从而可以加快计算最小值的过程。

代码实现时，并不需要显式地计算 $left[j]$。

```python
class Solution:
    def minDifficulty(self, a: List[int], d: int) -> int:
        n = len(a)
        if n < d:
            return -1

        f = [[inf] * n for _ in range(d)]
        f[0] = list(accumulate(a, max))
        for i in range(1, d):
            st = []  # (下标 j，从 f[i-1][left[j]] 到 f[i-1][j-1] 的最小值)
            for j in range(i, n):
                mn = f[i - 1][j - 1]  # 只有 a[j] 一项工作
                while st and a[st[-1][0]] <= a[j]:  # 向左一直计算到 left[j]
                    mn = min(mn, st.pop()[1])
                f[i][j] = mn + a[j]  # 从 a[left[j]+1] 到 a[j] 的最大值是 a[j]
                if st:  # 如果这一段包含 <=left[j] 的工作，那么这一段的最大值必然不是 a[j]
                    f[i][j] = min(f[i][j], f[i][st[-1][0]])  # 答案和 f[i][left[j]] 是一样的
                st.append((j, mn))  # 注意这里保存的不是 f[i][j]
        return f[-1][-1]
```

```java
class Solution {
    public int minDifficulty(int[] a, int d) {
        int n = a.length;
        if (n < d) return -1;

        var f = new int[d][n];
        f[0][0] = a[0];
        for (int i = 1; i < n; i++)
            f[0][i] = Math.max(f[0][i - 1], a[i]);
        for (int i = 1; i < d; i++) {
            var st = new ArrayDeque<int[]>(); // (下标 j，从 f[i-1][left[j]] 到 f[i-1][j-1] 的最小值)
            for (int j = i; j < n; j++) {
                int mn = f[i - 1][j - 1]; // 只有 a[j] 一项工作
                while (!st.isEmpty() && a[st.peek()[0]] <= a[j]) // 向左一直计算到 left[j]
                    mn = Math.min(mn, st.pop()[1]);
                f[i][j] = mn + a[j]; // 从 a[left[j]+1] 到 a[j] 的最大值是 a[j]
                if (!st.isEmpty()) // 如果这一段包含 <=left[j] 的工作，那么这一段的最大值必然不是 a[j]
                    f[i][j] = Math.min(f[i][j], f[i][st.peek()[0]]); // 答案和 f[i][left[j]] 是一样的
                st.push(new int[]{j, mn}); // 注意这里保存的不是 f[i][j]
            }
        }
        return f[d - 1][n - 1];
    }
}
```

```cpp
class Solution {
public:
    int minDifficulty(vector<int> &a, int d) {
        int n = a.size();
        if (n < d) return -1;

        int f[d][n];
        f[0][0] = a[0];
        for (int i = 1; i < n; i++)
            f[0][i] = max(f[0][i - 1], a[i]);
        for (int i = 1; i < d; i++) {
            stack<pair<int, int>> st; // (下标 j，从 f[i-1][left[j]] 到 f[i-1][j-1] 的最小值)
            for (int j = i; j < n; j++) {
                int mn = f[i - 1][j - 1]; // 只有 a[j] 一项工作
                while (!st.empty() && a[st.top().first] <= a[j]) { // 向左一直计算到 left[j]
                    mn = min(mn, st.top().second);
                    st.pop();
                }
                f[i][j] = mn + a[j]; // 从 a[left[j]+1] 到 a[j] 的最大值是 a[j]
                if (!st.empty()) // 如果这一段包含 <=left[j] 的工作，那么这一段的最大值必然不是 a[j]
                    f[i][j] = min(f[i][j], f[i][st.top().first]); // 答案和 f[i][left[j]] 是一样的
                st.emplace(j, mn); // 注意这里保存的不是 f[i][j]
            }
        }
        return f[d - 1][n - 1];
    }
};
```

```go
func minDifficulty(a []int, d int) int {
    n := len(a)
    if n < d {
        return -1
    }

    f := make([][]int, d)
    f[0] = make([]int, n)
    f[0][0] = a[0]
    for i := 1; i < n; i++ {
        f[0][i] = max(f[0][i-1], a[i])
    }
    for i := 1; i < d; i++ {
        f[i] = make([]int, n)
        type pair struct{ j, mn int }
        st := []pair{} // (下标 j，从 f[i-1][left[j]] 到 f[i-1][j-1] 的最小值)
        for j := i; j < n; j++ {
            mn := f[i-1][j-1] // 只有 a[j] 一项工作
            for len(st) > 0 && a[st[len(st)-1].j] <= a[j] { // 向左一直计算到 left[j]
                mn = min(mn, st[len(st)-1].mn)
                st = st[:len(st)-1]
            }
            f[i][j] = mn + a[j] // 从 a[left[j]+1] 到 a[j] 的最大值是 a[j]
            if len(st) > 0 { // 如果这一段包含 <=left[j] 的工作，那么这一段的最大值必然不是 a[j]
                f[i][j] = min(f[i][j], f[i][st[len(st)-1].j]) // 答案和 f[i][left[j]] 是一样的
            }
            st = append(st, pair{j, mn}) // 注意这里保存的不是 f[i][j]
        }
    }
    return f[d-1][n-1]
}

func min(a, b int) int { if b < a { return b }; return a }
func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(dn)$，其中 $n$ 为 $a$ 的长度。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题中状态个数等于 $\mathcal{O}(dn)$，单个状态的计算时间为**均摊** $\mathcal{O}(1)$（在内层循环中，每个下标至多入栈出栈各一次），因此时间复杂度为 $\mathcal{O}(dn)$。
-   空间复杂度：$\mathcal{O}(dn)$。

> 注：利用滚动数组可以把空间复杂度优化到 $\mathcal{O}(n)$。

#### 强化训练

另外附一些单调栈/单调队列的题目。

做题时，无论题目变成什么样，请记住一个核心原则：**及时移除无用数据，保证栈/队列的有序性**。

#### 单调栈

-   [496\. 下一个更大元素 I](https://leetcode.cn/problems/next-greater-element-i/)（单调栈模板题）
-   [503\. 下一个更大元素 II](https://leetcode.cn/problems/next-greater-element-ii/)
-   [2454\. 下一个更大元素 IV](https://leetcode.cn/problems/next-greater-element-iv/)
-   [456\. 132 模式](https://leetcode.cn/problems/132-pattern/)
-   [739\. 每日温度](https://leetcode.cn/problems/daily-temperatures/)
-   [901\. 股票价格跨度](https://leetcode.cn/problems/online-stock-span/)
-   [1019\. 链表中的下一个更大节点](https://leetcode.cn/problems/next-greater-node-in-linked-list/)
-   [1124\. 表现良好的最长时间段](https://leetcode.cn/problems/longest-well-performing-interval/)
-   [1475\. 商品折扣后的最终价格](https://leetcode.cn/problems/final-prices-with-a-special-discount-in-a-shop/)
-   [2289\. 使数组按非递减顺序排列](https://leetcode.cn/problems/steps-to-make-array-non-decreasing/)

#### 矩形系列

-   [84\. 柱状图中最大的矩形](https://leetcode.cn/problems/largest-rectangle-in-histogram/)
-   [85\. 最大矩形](https://leetcode.cn/problems/maximal-rectangle/)
-   [1504\. 统计全 1 子矩形](https://leetcode.cn/problems/count-submatrices-with-all-ones/)

#### 字典序最小

-   [316\. 去除重复字母](https://leetcode.cn/problems/remove-duplicate-letters/)
-   [316 扩展：重复个数不超过一个定值](https://leetcode.cn/contest/tianchi2022/problems/ev2bru/)
-   [402\. 移掉 K 位数字](https://leetcode.cn/problems/remove-k-digits/)
-   [321\. 拼接最大数](https://leetcode.cn/problems/create-maximum-number/)

#### 贡献法

-   [907\. 子数组的最小值之和](https://leetcode.cn/problems/sum-of-subarray-minimums/)
-   [1856\. 子数组最小乘积的最大值](https://leetcode.cn/problems/maximum-subarray-min-product/)
-   [2104\. 子数组范围和](https://leetcode.cn/problems/sum-of-subarray-ranges/)
-   [2281\. 巫师的总力量和](https://leetcode.cn/problems/sum-of-total-strength-of-wizards/)

#### 单调队列

原理见 [两张图秒懂单调队列](https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/solution/liang-zhang-tu-miao-dong-dan-diao-dui-li-9fvh/)。

-   [面试题 59-II. 队列的最大值](https://leetcode.cn/problems/dui-lie-de-zui-da-zhi-lcof/)（单调队列模板题）
-   [239\. 滑动窗口最大值](https://leetcode.cn/problems/sliding-window-maximum/)
-   [862\. 和至少为 K 的最短子数组](https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/)
-   [1438\. 绝对差不超过限制的最长连续子数组](https://leetcode.cn/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/)
