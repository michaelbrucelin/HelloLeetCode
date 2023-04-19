﻿#### [教你一步步思考动态规划！（Python/Java/C++/Go）](https://leetcode.cn/problems/partition-array-for-maximum-sum/solutions/2234242/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-rq5i/)

#### [前置知识：动态规划](https://leetcode.cn/problems/partition-array-for-maximum-sum/solutions/2234242/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-rq5i/)

1.  [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)
2.  [动态规划经典思想之「枚举选哪个」【基础算法精讲 20】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1ub411Q7sB%2F)

> APP 用户需要分享到 wx 打开链接。

#### [一、初步思路](https://leetcode.cn/problems/partition-array-for-maximum-sum/solutions/2234242/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-rq5i/)

对于 $arr=[1,15,7,9,2,5,10],k=3$，最后一段子数组可以是 $[10],[5,10],[2,5,10]$（长度不能超过 $k=3$）。根据题意，将子数组内的元素变成子数组的最大值，例如 $[2,5,10]$ 变成 $[10,10,10]$，其元素和为 $30$。

去掉这段子数组，例如去掉 $[2,5,10]$，剩余的要解决的问题是 $[1,15,7,9]$ 在分隔变换后能够得到的元素最大和。由于这是一个和原问题相似的子问题，所以可以用递归解决。

根据上面的讨论，递归参数只需要一个 $i$。定义 $dfs(i)$ 表示把 $arr[0]$ 到 $arr[i]$ 这段做分隔变换后能够得到的元素最大和。

枚举最后一段的子数组的开始下标 $j$，那么从 $arr[j]$ 到 $arr[i]$ 的这段子数组的所有值都要变为这段子数组的最大值，这一共有 $i-j+1$ 个元素，对应的元素和就是

$$(i-j+1)\cdot \max_{p=j}^{i}arr[p]$$

由于最后一段子数组的长度不能超过 $k$，所以 $j$ 最小为 $\max(i-k+1,0)$（注意 $j$ 不能是负数）。

把最后一段子数组的元素和，加上 $dfs(j-1)$ 这个子问题的结果，再取最大值，就是 $dfs(i)$。写成式子就是

$$dfs(i) = \max_{j=\max(i-k+1,0)}^{i}\left\{dfs(j-1) + (i-j+1)\cdot \max_{p=j}^{i}arr[p]\right\}$$

递归边界：$dfs(-1) = 0$。一个数都没有，元素和为 $0$。

递归入口：$dfs(n-1)$，也就是答案。

代码实现时，可以从 $i$ 开始倒着枚举 $j$，一边枚举一边计算子数组的最大值，从而 $\mathcal{O}(1)$ 地计算出元素和。

```python
# 会超时的递归代码
class Solution:
    def maxSumAfterPartitioning(self, arr: List[int], k: int) -> int:
        def dfs(i: int) -> int:
            # i=-1 时不会进入循环
            res = mx = 0
            for j in range(i, max(i - k, -1), -1):
                mx = max(mx, arr[j])  # 一边枚举 j，一边计算子数组的最大值
                res = max(res, dfs(j - 1) + (i - j + 1) * mx)
            return res
        return dfs(len(arr) - 1)
```

```java
// 会超时的递归代码
class Solution {
    private int[] arr;
    private int k;

    public int maxSumAfterPartitioning(int[] arr, int k) {
        this.arr = arr;
        this.k = k;
        return dfs(arr.length - 1);
    }

    private int dfs(int i) {
        // i=-1 时不会进入循环
        int res = 0;
        for (int j = i, mx = 0; j > i - k && j >= 0; --j) {
            mx = Math.max(mx, arr[j]); // 一边枚举 j，一边计算子数组的最大值
            res = Math.max(res, dfs(j - 1) + (i - j + 1) * mx);
        }
        return res;
    }
}
```

```cpp
// 会超时的递归代码
class Solution {
public:
    int maxSumAfterPartitioning(vector<int> &arr, int k) {
        function<int(int)> dfs = [&](int i) -> int {
            // i=-1 时不会进入循环
            int res = 0;
            for (int j = i, mx = 0; j > i - k && j >= 0; --j) {
                mx = max(mx, arr[j]); // 一边枚举 j，一边计算子数组的最大值
                res = max(res, dfs(j - 1) + (i - j + 1) * mx);
            }
            return res;
        };
        return dfs(arr.size() - 1);
    }
};
```

```go
// 会超时的递归代码
func maxSumAfterPartitioning(arr []int, k int) int {
    var dfs func(int) int
    dfs = func(i int) (res int) {
        // i=-1 时不会进入循环
        for j, mx := i, 0; j > i-k && j >= 0; j-- {
            mx = max(mx, arr[j]) // 一边枚举 j，一边计算子数组的最大值
            res = max(res, dfs(j-1)+(i-j+1)*mx)
        }
        return
    }
    return dfs(len(arr) - 1)
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(k^n)$，其中 $n$ 为 $arr$ 的长度。近似地看作是在一棵高度为 $n$ 的 $k$ 叉树上递归，所以时间复杂度为 $\mathcal{O}(k^n)$。
-   空间复杂度：$\mathcal{O}(n)$。递归需要 $\mathcal{O}(n)$ 的栈空间。

#### [二、递归 + 记录返回值 = 记忆化搜索](https://leetcode.cn/problems/partition-array-for-maximum-sum/solutions/2234242/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-rq5i/)

上面的做法太慢了，怎么优化呢？

举个例子，「先分隔出 $arr[n-1]$，再分隔出 $arr[n-2]$（两个子数组）」和「分隔出 $arr[n-2]$ 到 $arr[n-1]$（一个子数组）」，都会递归到 $dfs(n-3)$。

一叶知秋，整个递归中有大量重复递归调用（递归入参相同）。由于递归函数没有副作用，同样的入参无论计算多少次，算出来的结果都是一样的，因此可以用**记忆化搜索**来优化：

-   如果一个状态（递归入参）是第一次遇到，那么可以在返回前，把状态及其结果记到一个 $memo$ 数组（或哈希表）中。
-   如果一个状态不是第一次遇到，那么直接返回 $memo$ 中保存的结果。

```python
class Solution:
    def maxSumAfterPartitioning(self, arr: List[int], k: int) -> int:
        @cache  # 缓存装饰器，避免重复计算 dfs 的结果
        def dfs(i: int) -> int:
            # i=-1 时不会进入循环
            res = mx = 0
            for j in range(i, max(i - k, -1), -1):
                mx = max(mx, arr[j])  # 一边枚举 j，一边计算子数组的最大值
                res = max(res, dfs(j - 1) + (i - j + 1) * mx)
            return res
        return dfs(len(arr) - 1)
```

```java
class Solution {
    private int[] arr, memo;
    private int k;

    public int maxSumAfterPartitioning(int[] arr, int k) {
        this.arr = arr;
        this.k = k;
        int n = arr.length;
        memo = new int[n];
        Arrays.fill(memo, -1); // -1 表示还没有计算过
        return dfs(n - 1);
    }

    private int dfs(int i) {
        if (i < 0) return 0;
        if (memo[i] != -1) return memo[i]; // 之前计算过了
        int res = 0;
        for (int j = i, mx = 0; j > i - k && j >= 0; --j) {
            mx = Math.max(mx, arr[j]); // 一边枚举 j，一边计算子数组的最大值
            res = Math.max(res, dfs(j - 1) + (i - j + 1) * mx);
        }
        return memo[i] = res; // 记忆化
    }
}
```

```cpp
class Solution {
public:
    int maxSumAfterPartitioning(vector<int> &arr, int k) {
        int n = arr.size(), memo[n];
        memset(memo, -1, sizeof(memo)); // -1 表示还没有计算过
        function<int(int)> dfs = [&](int i) -> int {
            if (i < 0) return 0;
            int &res = memo[i]; // 注意这里是引用，下面会直接修改 memo[i]
            if (res != -1) return res; // 之前计算过了
            for (int j = i, mx = 0; j > i - k && j >= 0; --j) {
                mx = max(mx, arr[j]); // 一边枚举 j，一边计算子数组的最大值
                res = max(res, dfs(j - 1) + (i - j + 1) * mx);
            }
            return res;
        };
        return dfs(n - 1);
    }
};
```

```go
func maxSumAfterPartitioning(arr []int, k int) int {
    n := len(arr)
    memo := make([]int, n)
    for i := range memo {
        memo[i] = -1 // -1 表示还没有计算过
    }
    var dfs func(int) int
    dfs = func(i int) (res int) {
        if i < 0 {
            return
        }
        if memo[i] != -1 { // 之前计算过了
            return memo[i]
        }
        for j, mx := i, 0; j > i-k && j >= 0; j-- {
            mx = max(mx, arr[j]) // 一边枚举 j，一边计算子数组的最大值
            res = max(res, dfs(j-1)+(i-j+1)*mx)
        }
        memo[i] = res // 记忆化
        return
    }
    return dfs(n - 1)
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(nk)$，其中 $n$ 为 $arr$ 的长度。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。这里状态个数为 $\mathcal{O}(n)$，单个状态的计算时间为 $\mathcal{O}(k)$，因此时间复杂度为 $\mathcal{O}(nk)$。
-   空间复杂度：$\mathcal{O}(n)$。

#### [三、1:1 翻译成递推](https://leetcode.cn/problems/partition-array-for-maximum-sum/solutions/2234242/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-rq5i/)

我们可以去掉递归中的「递」，只保留「归」的部分，即自底向上计算。

做法：

-   $dfs$ 改成 $f$ 数组；
-   递归改成循环（每个参数都对应一层循环）；
-   递归边界改成 $f$ 数组的初始值。

具体来说，$f[i]$ 的含义和 $dfs(i)$ 的含义是一致的，都表示把 $arr[0]$ 到 $arr[i]$ 这段做分隔变换后能够得到的元素最大和。

相应的递推式（状态转移方程）也和 $dfs$ 的一致：

$$f[i] = \max_{j=\max(i-k+1,0)}^{i}\left\{f[j-1] + (i-j+1)\cdot \max_{p=j}^{i}arr[p]\right\}$$

但是这种定义方式**没有状态能表示递归边界**，即 $i=-1$ 的情况。

解决办法：在 $f$ 数组的最左边插入一个状态，那么其余状态全部向右偏移一位，也就是 $f[i]$ 改为 $f[i+1]$，$f[j-1]$ 改为 $f[j]$。

修改后 $f[i+1]$ 表示把 $arr[0]$ 到 $arr[i]$ 这段做分隔变换后能够得到的元素最大和。此时 $f[0]$ 就对应递归边界了。

修改后的递推式为

$$f[i+1] = \max_{j=\max(i-k+1,0)}^{i}\left\{f[j] + (i-j+1)\cdot \max_{p=j}^{i}arr[p]\right\}$$

> 问：为什么 $j$ 的起止下标不用变？为什么 $arr[p]$ 的下标不用变？
> 
> 答：既然是在 $f$ 的最左边插入一个状态，那么就只需要修改和 $f$ 有关的下标，其余任何逻辑都无需修改。

初始值 $f[0]=0$。（翻译自 $dfs(-1)=0$。）

答案为 $f[n]$。（翻译自 $dfs(n-1)$。）

```python
class Solution:
    def maxSumAfterPartitioning(self, arr: List[int], k: int) -> int:
        n = len(arr)
        f = [0] * (n + 1)
        for i in range(n):
            mx = 0
            for j in range(i, max(i - k, -1), -1):
                mx = max(mx, arr[j])  # 一边枚举 j，一边计算子数组的最大值
                f[i + 1] = max(f[i + 1], f[j] + (i - j + 1) * mx)
        return f[n]
```

```java
class Solution {
    public int maxSumAfterPartitioning(int[] arr, int k) {
        int n = arr.length;
        var f = new int[n + 1];
        for (int i = 0; i < n; ++i)
            for (int j = i, mx = 0; j > i - k && j >= 0; --j) {
                mx = Math.max(mx, arr[j]); // 一边枚举 j，一边计算子数组的最大值
                f[i + 1] = Math.max(f[i + 1], f[j] + (i - j + 1) * mx);
            }
        return f[n];
    }
}
```

```cpp
class Solution {
public:
    int maxSumAfterPartitioning(vector<int> &arr, int k) {
        int n = arr.size(), f[n + 1];
        f[0] = 0;
        for (int i = 0; i < n; ++i) {
            f[i + 1] = 0;
            for (int j = i, mx = 0; j > i - k && j >= 0; --j) {
                mx = max(mx, arr[j]); // 一边枚举 j，一边计算子数组的最大值
                f[i + 1] = max(f[i + 1], f[j] + (i - j + 1) * mx);
            }
        }
        return f[n];
    }
};
```

```go
func maxSumAfterPartitioning(arr []int, k int) int {
    n := len(arr)
    f := make([]int, n+1)
    for i := range arr {
        for j, mx := i, 0; j > i-k && j >= 0; j-- {
            mx = max(mx, arr[j]) // 一边枚举 j，一边计算子数组的最大值
            f[i+1] = max(f[i+1], f[j]+(i-j+1)*mx)
        }
    }
    return f[n]
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(nk)$，其中 $n$ 为 $arr$ 的长度。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。这里状态个数为 $\mathcal{O}(n)$，单个状态的计算时间为 $\mathcal{O}(k)$，因此时间复杂度为 $\mathcal{O}(nk)$。
-   空间复杂度：$\mathcal{O}(n)$。

#### [四、空间优化](https://leetcode.cn/problems/partition-array-for-maximum-sum/solutions/2234242/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-rq5i/)

假设 $k$ 非常小，例如 $k=3$，如何优化额外空间呢？

观察上面的状态转移方程，在计算 $f[i+1]$ 及其之后的状态时，不会用到下标 $\le i-k$ 的状态。

那么可以用一个长为 $k$ 的数组滚动计算。例如 $k=3$ 时，$f[4]$ 填到 $f[1]$ 中，$f[5]$ 填到 $f[2]$ 中，依此类推。

状态转移方程改为

$$f[(i+1)\bmod k] = \max_{j=\max(i-k+1,0)}^{i}\left\{f[j\\bmod k] + (i-j+1)\cdot \max_{p=j}^{i}arr[p]\right\}$$

初始值 $f[0]=0$。

答案为 $f[n\bmod k]$。

```python
class Solution:
    def maxSumAfterPartitioning(self, arr: List[int], k: int) -> int:
        n = len(arr)
        f = [0] * k
        for i in range(n):
            res = mx = 0
            for j in range(i, max(i - k, -1), -1):
                mx = max(mx, arr[j])  # 一边枚举 j，一边计算子数组的最大值
                # 注意在循环结束前，f[(i+1)%k] 是需要用到的，不能提前覆盖
                res = max(res, f[j % k] + (i - j + 1) * mx)
            f[(i + 1) % k] = res
        return f[n % k]
```

```java
class Solution {
    public int maxSumAfterPartitioning(int[] arr, int k) {
        int n = arr.length;
        var f = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            int res = 0;
            for (int j = i, mx = 0; j > i - k && j >= 0; --j) {
                mx = Math.max(mx, arr[j]); // 一边枚举 j，一边计算子数组的最大值
                // 注意在循环结束前，f[(i+1)%k] 是需要用到的，不能提前覆盖
                res = Math.max(res, f[j % k] + (i - j + 1) * mx);
            }
            f[(i + 1) % k] = res;
        }
        return f[n % k];
    }
}
```

```cpp
class Solution {
public:
    int maxSumAfterPartitioning(vector<int> &arr, int k) {
        int n = arr.size(), f[k];
        f[0] = 0;
        for (int i = 0; i < n; ++i) {
            int res = 0;
            for (int j = i, mx = 0; j > i - k && j >= 0; --j) {
                mx = max(mx, arr[j]); // 一边枚举 j，一边计算子数组的最大值
                // 注意在循环结束前，f[(i+1)%k] 是需要用到的，不能提前覆盖
                res = max(res, f[j % k] + (i - j + 1) * mx);
            }
            f[(i + 1) % k] = res;
        }
        return f[n % k];
    }
};
```

```go
func maxSumAfterPartitioning(arr []int, k int) int {
    n := len(arr)
    f := make([]int, k)
    for i := range arr {
        res := 0
        for j, mx := i, 0; j > i-k && j >= 0; j-- {
            mx = max(mx, arr[j]) // 一边枚举 j，一边计算子数组的最大值
            res = max(res, f[j%k]+(i-j+1)*mx)
        }
        f[(i+1)%k] = res
    }
    return f[n%k]
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(nk)$，其中 $n$ 为 $arr$ 的长度。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。这里状态个数为 $\mathcal{O}(n)$，单个状态的计算时间为 $\mathcal{O}(k)$，因此时间复杂度为 $\mathcal{O}(nk)$。
-   空间复杂度：$\mathcal{O}(k)$。

#### 练习

-   [2369\. 检查数组是否存在有效划分](https://leetcode.cn/problems/check-if-there-is-a-valid-partition-for-the-array/)
-   [1105\. 填充书架](https://leetcode.cn/problems/filling-bookcase-shelves/)
