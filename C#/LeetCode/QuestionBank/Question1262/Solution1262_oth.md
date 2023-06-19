#### [两种算法：贪心/动态规划（Python/Java/C++/Go）](https://leetcode.cn/problems/greatest-sum-divisible-by-three/solutions/2313700/liang-chong-suan-fa-tan-xin-dong-tai-gui-tsll/)

#### 算法一：贪心

由于数组中没有负数，如果整个数组的元素和 $s$ 可以被 $3$ 整除，那么 $s$ 就是最大的元素和。

否则，如果 $s$ 不能被 $3$ 整除，那就看看能否让 $s$ 减去某些 $nums[i]$，使得 $s$ 可以被 $3$ 整除。

找到所有 $nums[i] \bmod 3 = 1$ 的 $nums[i]$，放到数组 $a_1$ 中；找到所有 $nums[i] \bmod 3 = 2$ 的 $nums[i]$，放到数组 $a_2$ 中。

对 $a_1$ 和 $a_2$ 从小到大排序。分类讨论：

-   如果 $s \bmod 3 = 1$：
    -   如果 $a_1$ 不为空，那么答案可能是 $s-a_1[0]$；
    -   如果 $a_2$ 中至少有两个数，那么答案可能是 $s-a_2[0]-a_2[1]$；
    -   这两种情况取最大值。
    -   如果没有这样的数，返回 $0$。
-   如果 $s \bmod 3 = 2$：
    -   如果 $a_2$ 不为空，那么答案可能是 $s-a_2[0]$；
    -   如果 $a_1$ 中至少有两个数，那么答案可能是 $s-a_1[0]-a_1[1]$；
    -   这两种情况取最大值。
    -   如果没有这样的数，返回 $0$。

代码实现时，如果 $s \bmod 3 = 2$，那么可以**交换**数组 $a_1$ 和 $a_2$，从而复用同一套逻辑。

但是，贪心算法是有局限的。试想一下，如果把题目中的 $3$ 换成 $4$，要如何分类讨论？换成 $5$，又要如何分类讨论？随着数字的变大，要讨论的内容越来越复杂。那么，是否有更加通用的做法呢？请继续阅读。

```python
class Solution:
    def maxSumDivThree(self, nums: List[int]) -> int:
        s = sum(nums)
        if s % 3 == 0:
            return s
        a1 = sorted(x for x in nums if x % 3 == 1)
        a2 = sorted(x for x in nums if x % 3 == 2)
        if s % 3 == 2:
            a1, a2 = a2, a1
        ans = s - a1[0] if a1 else 0
        if len(a2) > 1:
            ans = max(ans, s - a2[0] - a2[1])
        return ans
```

```java
class Solution {
    public int maxSumDivThree(int[] nums) {
        int s = 0;
        for (int x : nums)
            s += x;
        if (s % 3 == 0)
            return s;

        var a1 = new ArrayList<Integer>();
        var a2 = new ArrayList<Integer>();
        for (int x : nums) {
            if (x % 3 == 1) a1.add(x);
            else if (x % 3 == 2) a2.add(x);
        }
        Collections.sort(a1);
        Collections.sort(a2);

        if (s % 3 == 2) { // swap(a1,a2)
            var tmp = a1;
            a1 = a2;
            a2 = tmp;
        }
        int ans = a1.isEmpty() ? 0 : s - a1.get(0);
        if (a2.size() > 1)
            ans = Math.max(ans, s - a2.get(0) - a2.get(1));
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int maxSumDivThree(vector<int> &nums) {
        int s = accumulate(nums.begin(), nums.end(), 0);
        if (s % 3 == 0)
            return s;

        vector<int> a[3];
        for (int x: nums)
            a[x % 3].push_back(x);
        sort(a[1].begin(), a[1].end());
        sort(a[2].begin(), a[2].end());

        if (s % 3 == 2)
            swap(a[1], a[2]);
        int ans = a[1].size() ? s - a[1][0] : 0;
        if (a[2].size() > 1)
            ans = max(ans, s - a[2][0] - a[2][1]);
        return ans;
    }
};
```

```go
func maxSumDivThree(nums []int) (ans int) {
    s := 0
    for _, x := range nums {
        s += x
    }
    if s%3 == 0 {
        return s
    }

    a := [3][]int{}
    for _, x := range nums {
        a[x%3] = append(a[x%3], x)
    }
    sort.Ints(a[1])
    sort.Ints(a[2])

    if s%3 == 2 {
        a[1], a[2] = a[2], a[1]
    }
    if len(a[1]) > 0 {
        ans = s - a[1][0]
    }
    if len(a[2]) > 1 {
        ans = max(ans, s-a[2][0]-a[2][1])
    }
    return
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

注：由于只要最小的两个数，可以做到 $\mathcal{O}(n)$ 时间和 $\mathcal{O}(1)$ 额外空间，但写起来较为复杂。考虑到动态规划的做法同样可以做到 $\mathcal{O}(n)$ 时间和 $\mathcal{O}(1)$ 额外空间，所以这里就不进一步优化了。

-   时间复杂度：$\mathcal{O}(n\log n)$，其中 $n$ 为 $nums$ 的长度。
-   空间复杂度：$\mathcal{O}(n)$。

#### 算法二：动态规划

#### 前置知识：动态规划入门

详见 [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)。

> 制作不易，欢迎点赞！APP 用户如果无法打开，可以分享到微信。

#### 一、寻找子问题

用「选或不选」的思路，考虑最后一个数 $x = nums[n-1]$：

-   如果 $x \bmod 3= 0$，那么 $x$ 一定要选，问题变成从 $nums[0]$ 到 $nums[n-2]$ 中寻找能被 $3$ 整除的元素最大和。
-   如果 $x \bmod 3= 1$：
    -   如果不选 $x$，和上面一样，问题变成从 $nums[0]$ 到 $nums[n-2]$ 中寻找能被 $3$ 整除的元素最大和 $s_0$。
    -   如果选 $x$，问题变成从 $nums[0]$ 到 $nums[n-2]$ 中寻找最大元素和 $s_2$，满足 $s_2 \bmod 3 = 2$。
    -   答案为 $\max(s_0, s_2 + x)$。
-   如果 $x \bmod 3= 2$：
    -   如果不选 $x$，和上面一样，问题变成从 $nums[0]$ 到 $nums[n-2]$ 中寻找能被 $3$ 整除的元素最大和 $s_0$。
    -   如果选 $x$，问题变成从 $nums[0]$ 到 $nums[n-2]$ 中寻找最大元素和 $s_1$，满足 $s_1 \bmod 3 = 1$。
    -   答案为 $\max(s_0, s_1 + x)$。

上述讨论，刻画了这道题的两个重要参数：

-   $i$：表示从 $nums[0]$ 到 $nums[i]$ 中选数。
-   $j$：表示所选数字之和 $s$ 需要满足 $s \bmod 3 = j$。

那么原问题就是 $(i=n-1, j=0)$，上述讨论得到的子问题有 $(i=n-2,j=0),(i=n-2,j=1),(i=n-2,j=2)$。

> 注：为什么要从最后一个数开始讨论？主要是为了方便后面把记忆化搜索改成递推。当然，你从第一个数开始讨论也是可以的。

#### 二、状态定义与状态转移方程

根据上面的讨论，定义 $dfs(i,j)$ 表示从 $nums[0]$ 到 $nums[i]$ 中选数，所选数字之和 $s$ 满足 $s \bmod 3 = j$ 的前提下，$s$ 的最大值。

设 $x=nums[i]$，分类讨论：

-   如果不选 $x$，问题变成从 $nums[0]$ 到 $nums[i-1]$ 中选数，所选数字之和 $s$ 满足 $s \bmod 3 = j$ 的前提下，$s$ 的最大值。即 $dfs(i,j) = dfs(i-1,j)$。
-   如果选 $x$，问题变成从 $nums[0]$ 到 $nums[n-2]$ 中选数，所选数字之和 $s$ 满足 $(s+x) \bmod 3 = j$，即 $s \bmod 3 = (j-x) \bmod 3$ 的前提下，$s$ 的最大值。即 $dfs(i,j) = dfs(i-1,(j-x) \bmod 3) + x$。

这两种情况取最大值，有

$$dfs(i,j) = \max(dfs(i-1,j),dfs(i-1,(j-x)\bmod 3) + x)$$

注意，如果 $(j-x) \bmod 3 < 0$，需要再 $+3$ 调整到 $[0,2]$ 内。考虑到这样写有些麻烦，不妨把 $j$ 的定义改为**已选**数字之和  $\bmod\\ 3 = j$。

这样修改后，不选 $x$ 仍然是 $dfs(i,j) = dfs(i-1,j)$；选 $x$ 就是 $dfs(i,j) = dfs(i-1,(j+x)\bmod 3)$ 了。

这两种情况取最大值，有

$$dfs(i,j) = \max(dfs(i-1,j),dfs(i-1,(j+x)\bmod 3) + x)$$

递归边界：$dfs(-1,0)=0,dfs(-1,1)=-\infty,dfs(-1,2)=-\infty$。我们需要保证所选数字之和是 $3$ 的倍数，否则不符合题目要求。注意，如果没有选任何数字，那么会递归到 $dfs(-1,0)$，得到 $0$，这是符合题目要求的。

递归入口：$dfs(n-1,0)$。

```python
class Solution:
    def maxSumDivThree(self, nums: List[int]) -> int:
        @cache  # 记忆化搜索
        def dfs(i: int, j: int) -> int:
            if i < 0: return -inf if j else 0
            return max(dfs(i - 1, j), dfs(i - 1, (j + nums[i]) % 3) + nums[i])
        return dfs(len(nums) - 1, 0)
```

```java
class Solution {
    public int maxSumDivThree(int[] nums) {
        int n = nums.length;
        var memo = new int[n][3];
        for (int i = 0; i < n; i++)
            Arrays.fill(memo[i], -1); // -1 表示没有计算过
        return dfs(memo, nums, n - 1, 0);
    }

    private int dfs(int[][] memo, int[] nums, int i, int j) {
        if (i < 0) return j == 0 ? 0 : Integer.MIN_VALUE;
        if (memo[i][j] != -1) return memo[i][j]; // 之前计算过
        return memo[i][j] = Math.max(dfs(memo, nums, i - 1, j),
                dfs(memo, nums, i - 1, (j + nums[i]) % 3) + nums[i]);
    }
}
```

```cpp
class Solution {
public:
    int maxSumDivThree(vector<int> &nums) {
        int n = nums.size(), memo[n][3];
        memset(memo, -1, sizeof(memo)); // -1 表示没有计算过
        function<int(int, int)> dfs = [&](int i, int j) -> int {
            if (i < 0) return j ? INT_MIN : 0;
            int &res = memo[i][j]; // 注意这里是引用，下面会直接修改 memo[i][j]
            if (res != -1) return res; // 之前计算过
            return res = max(dfs(i - 1, j), dfs(i - 1, (j + nums[i]) % 3) + nums[i]);
        };
        return dfs(n - 1, 0);
    }
};
```

```go
func maxSumDivThree(nums []int) int {
    n := len(nums)
    memo := make([][3]int, n)
    for i := range memo {
        for j := range memo[i] {
            memo[i][j] = -1 // -1 表示没有计算过
        }
    }
    var dfs func(int, int) int
    dfs = func(i, j int) int {
        if i < 0 {
            if j == 0 {
                return 0
            }
            return math.MinInt
        }
        p := &memo[i][j]
        if *p != -1 { // 之前计算过
            return *p
        }
        *p = max(dfs(i-1, j), dfs(i-1, (j+nums[i])%3)+nums[i])
        return *p
    }
    return dfs(n-1, 0)
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(nk)$，其中 $n$ 为 $nums$ 的长度，$k=3$。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题中状态个数等于 $\mathcal{O}(nk)$，单个状态的计算时间为 $\mathcal{O}(1)$，因此时间复杂度为 $\mathcal{O}(nk)$。
-   空间复杂度：$\mathcal{O}(nk)$。

#### 三、1:1 翻译成递推

我们可以去掉递归中的「递」，只保留「归」的部分，即自底向上计算。

做法：

-   $dfs$ 改成 $f$ 数组；
-   递归改成循环（每个参数都对应一层循环）；
-   递归边界改成 $f$ 数组的初始值。

具体来说，$f[i][j]$ 的含义与状态转移方程和 $dfs(i,j)$ 的是一致的，即

$$f[i][j] = \max(f[i-1][j],f[i-1][(j+x)\bmod 3] + x)$$

但当 $i=0$ 时，等号右边会出现负数下标。或者说，**这种定义方式没有状态能表示递归边界**。

解决办法：在 $f$ 数组的上边加一排，把原来的 $f[i]$ 改成 $f[i+1]$，$f[i-1]$ 改成 $f[i]$。此时 $f[0][j]$ 就对应着 $dfs(-1,j)$。

修改后的递推式为

$$f[i+1][j] = \max(f[i][j],f[i][(j+x)\bmod 3] + x)$$

初始值 $f[0]=[0,-\infty,-\infty]$，翻译自 $dfs(-1,0)=0,dfs(-1,1)=-\infty,dfs(-1,2)=-\infty$。

答案为 $f[n][0]$，翻译自 $dfs(n-1,0)$。

```python
class Solution:
    def maxSumDivThree(self, nums: List[int]) -> int:
        f = [[-inf] * 3 for _ in range(len(nums) + 1)]
        f[0][0] = 0
        for i, x in enumerate(nums):
            for j in range(3):
                f[i + 1][j] = max(f[i][j], f[i][(j + x) % 3] + x)
        return f[-1][0]
```

```java
class Solution {
    public int maxSumDivThree(int[] nums) {
        int n = nums.length;
        var f = new int[n + 1][3];
        f[0][1] = f[0][2] = Integer.MIN_VALUE;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < 3; j++)
                f[i + 1][j] = Math.max(f[i][j], f[i][(j + nums[i]) % 3] + nums[i]);
        return f[n][0];
    }
}
```

```cpp
class Solution {
public:
    int maxSumDivThree(vector<int> &nums) {
        int n = nums.size(), f[n + 1][3];
        f[0][0] = 0, f[0][1] = INT_MIN, f[0][2] = INT_MIN;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < 3; j++)
                f[i + 1][j] = max(f[i][j], f[i][(j + nums[i]) % 3] + nums[i]);
        return f[n][0];
    }
};
```

```go
func maxSumDivThree(nums []int) int {
    n := len(nums)
    f := make([][3]int, n+1)
    f[0][1] = math.MinInt
    f[0][2] = math.MinInt
    for i, x := range nums {
        for j := 0; j < 3; j++ {
            f[i+1][j] = max(f[i][j], f[i][(j+x)%3]+x)
        }
    }
    return f[n][0]
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(nk)$，其中 $n$ 为 $nums$ 的长度，$k=3$。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题中状态个数等于 $\mathcal{O}(nk)$，单个状态的计算时间为 $\mathcal{O}(1)$，因此时间复杂度为 $\mathcal{O}(nk)$。
-   空间复杂度：$\mathcal{O}(nk)$。

### 四、用滚动数组优化空间

由于 $f[i+1]$ 只依赖 $f[i]$，那么 $f[i-1]$ 及其之前的数据就没用了。

例如计算 $f[2]$ 的时候，数组 $f[0]$ 不再使用了。

那么干脆把 $f[2]$ 填到 $f[0]$ 中。同理，把 $f[3]$ 填到 $f[1]$ 中，$f[4]$ 填到 $f[0]$ 中，……

因此可以只用两个长为 $n+1$ 的数组滚动计算。

具体可以看[【基础算法精讲 18】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV16Y411v7Y6%2F)中的画图讲解。

```python
class Solution:
    def maxSumDivThree(self, nums: List[int]) -> int:
        f = [[-inf] * 3 for _ in range(2)]
        f[0][0] = 0
        for i, x in enumerate(nums):
            for j in range(3):
                f[(i + 1) % 2][j] = max(f[i % 2][j], f[i % 2][(j + x) % 3] + x)
        return f[len(nums) % 2][0]
```

```java
class Solution {
    public int maxSumDivThree(int[] nums) {
        int n = nums.length;
        var f = new int[2][3];
        f[0][1] = f[0][2] = Integer.MIN_VALUE;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < 3; j++)
                f[(i + 1) % 2][j] = Math.max(f[i % 2][j], f[i % 2][(j + nums[i]) % 3] + nums[i]);
        return f[n % 2][0];
    }
}
```

```cpp
class Solution {
public:
    int maxSumDivThree(vector<int> &nums) {
        int n = nums.size(), f[2][3];
        f[0][0] = 0, f[0][1] = INT_MIN, f[0][2] = INT_MIN;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < 3; j++)
                f[(i + 1) % 2][j] = max(f[i % 2][j], f[i % 2][(j + nums[i]) % 3] + nums[i]);
        return f[n % 2][0];
    }
};
```

```go
func maxSumDivThree(nums []int) int {
    f := [2][3]int{{0, math.MinInt, math.MinInt}}
    for i, x := range nums {
        for j := 0; j < 3; j++ {
            f[(i+1)%2][j] = max(f[i%2][j], f[i%2][(j+x)%3]+x)
        }
    }
    return f[len(nums)%2][0]
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(nk)$，其中 $n$ 为 $nums$ 的长度，$k=3$。
-   空间复杂度：$\mathcal{O}(k)$。

#### 总结

相比贪心算法，动态规划的适用性更广。请你思考，如果数组中有负数，动态规划是否也能得到正确的结果？如果把 $3$ 换成其它数字呢？欢迎在评论区发表你的看法。
