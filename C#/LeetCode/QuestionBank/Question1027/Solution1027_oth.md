#### [记忆化搜索->递推->常数优化（Python/Java/C++/Go）](https://leetcode.cn/problems/longest-arithmetic-subsequence/solutions/2239191/ji-yi-hua-sou-suo-di-tui-chang-shu-you-h-czvx/)

#### 前置知识：动态规划入门

详见 [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)。

> APP 用户如果无法打开，可以分享到微信。

#### 一、寻找子问题

对于动态规划问题，通常可以从「选或不选」和「枚举选哪个」这两个角度入手。

看到子序列，你可能想到了「选或不选」这个思路，但是本题要寻找的是等差子序列，假设我们确定了等差子序列的末项和公差，那么其它数也就确定了，所以寻找等差子序列更像是一件「枚举选哪个」的事情了。

为方便描述，下文将$nums$ 简记为 $a$，将最长等差子序列称作 LAS。

例如 $a=[9,4,7,2,10]$。假设 $a[4]=10$ 是 LAS 的最后一项，公差 $d=3$，那么倒数第二项就是 $10-3=7$，我们需要在前面找到 $7$ 的位置，如果有多个 $7$，则应该贪心取最靠右的，从而更有机会找到更长的 LAS。这样，问题就变成以 $7$ 结尾的公差为 $3$ 的 LAS 的长度。由于有很多相似的子问题，可以用递归解决。

> 先来试试定义成 $dfs(i,d)$，表示以 $a[i]$ 结尾的公差为 $d$ 的 LAS 的长度。那么需要在前面找到 $a[j]=a[i]-d$，然后继续递归 $dfs(j,d)$。
> 
> 如何找到 $a[i]-d$？
> 
> -   暴力枚举：需要花费 $O(n)$ 的时间。
> -   预处理相同元素的位置列表，然后在列表中二分查找：预处理 $O(n)$，二分查找 $O(\log n)$。
> 
> 无论如何，总是有多余的时间浪费在查找元素上了。

再来观察 $a=[9,4,7,2,10]$。对于 $a[2]=7$ 来说，它和前面的元素形成了公差分别为 $7-9=-2$ 和 $7-4=3$ 的 LAS，长度均为 $2$。对于 $a[4]=10$，它与 $a[2]=7$ 形成子序列时，由于已经知道以 $a[2]$ 结尾的公差为 $3$ 的 LAS 的长度为 $2$，所以立刻得出以 $a[4]$ 结尾的公差为 $3$ 的 LAS 的长度为 $2+1=3$。

那么把**所有**以 $a[i]$ 结尾的（至少有两个元素的）LAS 的公差及其长度都算出来，存到一个哈希表中，$a[i]$ 右边的数 $x$ 就可以直接去哈希表中查找公差 $d=x-a[i]$ 对应的 LAS 长度了。

因此我们换个角度，定义成 $dfs(i)$，它返回上面说的哈希表。由于 $a[i]$ 和前面的元素至多形成 $i$ 个公差不同的 LAS，所以哈希表的大小至多为 $i$。

具体来说，对于 $dfs(i)$，维护一个哈希表 $maxLen$，枚举所有 $j<i$，设公差 $d=a[i]-a[j]$，则更新

$$maxLen[d] = \max(maxLen[d], dfs(j)[d] + 1)$$

> 注：考虑到 $j$ 越大 $dfs(j)[d]$ 也越大，所以代码实现时可以倒序遍历 $j$，对 $maxLen[d]$ 只更新一次。这样执行用时更短。

如果 $d$ 不在 $dfs(j)$ 的返回值中，则 $dfs(j)[d]=1$，相当于 $a[j]$ 是 LAS 的首项。

递归边界：$i=0$ 时，返回空哈希表，因为 $a[0]$ 左边没有元素。注意我们必须要把公差算出来，不考虑只有一个元素的 LAS。

递归入口：计算从 $dfs(1)$ 到 $dfs(n-1)$ 的所有哈希表中的 LAS 的长度的最大值。

```python
class Solution:
    def longestArithSeqLength(self, a: List[int]) -> int:
        @cache  # 缓存装饰器，避免重复计算 dfs 的结果
        def dfs(i: int) -> dict[int, int]:
            # i=0 时不会进入循环，返回空哈希表
            max_len = {}
            for j in range(i - 1, -1, -1):
                d = a[i] - a[j]  # 公差
                if d not in max_len:
                    max_len[d] = dfs(j).get(d, 1) + 1
            return max_len
        return max(max(dfs(i).values()) for i in range(1, len(a)))
```

```java
class Solution {
    private Map<Integer, Integer>[] maxLen;
    private int[] a;
    private int ans;

    public int longestArithSeqLength(int[] nums) {
        a = nums;
        int n = a.length;
        maxLen = new HashMap[n];
        for (int i = 1; i < n; ++i)
            dfs(i);
        return ans;
    }

    private Map<Integer, Integer> dfs(int i) {
        if (maxLen[i] != null) return maxLen[i]; // 之前算过了
        // i=0 时不会进入循环
        maxLen[i] = new HashMap<>();
        for (int j = i - 1; j >= 0; --j) {
            int d = a[i] - a[j]; // 公差
            if (!maxLen[i].containsKey(d)) {
                maxLen[i].put(d, dfs(j).getOrDefault(d, 1) + 1);
                ans = Math.max(ans, maxLen[i].get(d));
            }
        }
        return maxLen[i];
    }
}
```

```cpp
class Solution {
public:
    int longestArithSeqLength(vector<int> &a) {
        int ans = 0, n = a.size();
        unordered_map<int, int> max_len[n];
        function<void(int)> dfs = [&](int i) {
            if (!max_len[i].empty()) return; // 之前算过了
            for (int j = i - 1; j >= 0; --j) {
                int d = a[i] - a[j]; // 公差
                if (!max_len[i].count(d)) {
                    dfs(j); // 下面直接用 max_len[j] 拿到结果
                    auto it = max_len[j].find(d);
                    max_len[i][d] = it != max_len[j].end() ? it->second + 1 : 2;
                    ans = max(ans, max_len[i][d]);
                }
            }
        };
        for (int i = 1; i < n; ++i)
            dfs(i);
        return ans;
    }
};
```

```go
func longestArithSeqLength(a []int) (ans int) {
    n := len(a)
    maxLen := make([]map[int]int, n)
    var dfs func(int) map[int]int
    dfs = func(i int) map[int]int {
        if maxLen[i] != nil { // 之前算过了
            return maxLen[i]
        }
        maxLen[i] = map[int]int{}
        for j := i - 1; j >= 0; j-- {
            d := a[i] - a[j] // 公差
            if maxLen[i][d] == 0 {
                maxLen[i][d] = dfs(j)[d] + 1 // 默认的 1 在下面返回时加上
                ans = max(ans, maxLen[i][d])
            }
        }
        return maxLen[i]
    }
    for i := 1; i < n; i++ {
        dfs(i)
    }
    return ans + 1
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n^2)$，其中 $n$ 为 $a$ 的长度。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。这里状态个数为 $\mathcal{O}(n)$，单个状态的计算时间为 $\mathcal{O}(n)$，因此时间复杂度为 $\mathcal{O}(n^2)$。
-   空间复杂度：$\mathcal{O}(n^2)$。有 $\mathcal{O}(n)$ 个状态，每个状态需要 $\mathcal{O}(n)$ 的空间。

#### 二、1:1 翻译成递推

我们可以去掉递归中的「递」，只保留「归」的部分，即自底向上计算。

通用做法：

-   $dfs$ 改成 $f$ 数组；
-   递归改成循环（每个参数都对应一层循环）；
-   递归边界改成 $f$ 数组的初始值。

> 相当于原来是用递归去计算每个状态，现在是按照某个顺序去枚举并计算每个状态。

由于递归中 $i$ 不会为负，所以无需做任何下标的调整，照搬上面的代码就完事了。

```python
class Solution:
    def longestArithSeqLength(self, a: List[int]) -> int:
        f = [{} for _ in range(len(a))]
        for i, x in enumerate(a):
            for j in range(i - 1, -1, -1):
                d = x - a[j]  # 公差
                if d not in f[i]:
                    f[i][d] = f[j].get(d, 1) + 1
        return max(max(d.values()) for d in f[1:])
```

```java
class Solution {
    public int longestArithSeqLength(int[] a) {
        int ans = 0, n = a.length;
        Map<Integer, Integer>[] f = new HashMap[n];
        Arrays.setAll(f, e -> new HashMap<>());
        for (int i = 1; i < n; ++i)
            for (int j = i - 1; j >= 0; --j) {
                int d = a[i] - a[j]; // 公差
                if (!f[i].containsKey(d)) {
                    f[i].put(d, f[j].getOrDefault(d, 1) + 1);
                    ans = Math.max(ans, f[i].get(d));
                }
            }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int longestArithSeqLength(vector<int> &a) {
        int ans = 0, n = a.size();
        unordered_map<int, int> f[n];
        for (int i = 1; i < n; ++i)
            for (int j = i - 1; j >= 0; --j) {
                int d = a[i] - a[j]; // 公差
                if (!f[i].count(d)) {
                    auto it = f[j].find(d);
                    f[i][d] = it != f[j].end() ? it->second + 1 : 2;
                    ans = max(ans, f[i][d]);
                }
            }
        return ans;
    }
};
```

```go
func longestArithSeqLength(a []int) (ans int) {
    n := len(a)
    f := make([]map[int]int, n)
    f[0] = map[int]int{}
    for i := 1; i < n; i++ {
        f[i] = map[int]int{}
        for j := i - 1; j >= 0; j-- {
            d := a[i] - a[j] // 公差
            if f[i][d] == 0 {
                f[i][d] = f[j][d] + 1 // 默认的 1 在下面返回时加上
                ans = max(ans, f[i][d])
            }
        }
    }
    return ans + 1
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n^2)$，其中 $n$ 为 $a$ 的长度。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。这里状态个数为 $\mathcal{O}(n)$，单个状态的计算时间为 $\mathcal{O}(n)$，因此时间复杂度为 $\mathcal{O}(n^2)$。
-   空间复杂度：$\mathcal{O}(n^2)$。有 $\mathcal{O}(n)$ 个状态，每个状态需要 $\mathcal{O}(n)$ 的空间。

#### 三、常数优化

由于值域比较小，还可以用数组代替哈希表。

设 $maxD=\max(a)-\min(a)$，那么公差范围在 $[-maxD,maxD]$，这一共有 $2 \cdot maxD + 1$ 个数。代码实现时可以简单地用 $2\cdot 500 + 1 = 1001$ 代替。

> 注：该优化在 Python 上并不明显。

```python
class Solution:
    def longestArithSeqLength(self, a: List[int]) -> int:
        ans, max_d = 0, max(a) - min(a)
        f = [[0] * (max_d * 2 + 1) for _ in range(len(a))]
        for i, x in enumerate(a):
            for j in range(i - 1, -1, -1):
                d = x - a[j]  # 公差
                if f[i][d] == 0:
                    f[i][d] = f[j][d] + 1  # 默认的 1 在下面返回时加上
                    if f[i][d] > ans:
                        ans = f[i][d]
        return ans + 1
```

```java
class Solution {
    public int longestArithSeqLength(int[] a) {
        int ans = 0, n = a.length;
        var f = new int[n][1001];
        for (int i = 1; i < n; ++i)
            for (int j = i - 1; j >= 0; --j) {
                int d = a[i] - a[j] + 500; // +500 防止出现负数
                if (f[i][d] == 0) {
                    f[i][d] = f[j][d] + 1; // 默认的 1 在下面返回时加上
                    ans = Math.max(ans, f[i][d]);
                }
            }
        return ans + 1;
    }
}
```

```cpp
class Solution {
public:
    int longestArithSeqLength(vector<int> &a) {
        int ans = 0, n = a.size(), f[n][1001];
        memset(f, 0, sizeof(f));
        for (int i = 1; i < n; ++i)
            for (int j = i - 1; j >= 0; --j) {
                int d = a[i] - a[j] + 500; // +500 防止出现负数
                if (f[i][d] == 0) {
                    f[i][d] = f[j][d] + 1; // 默认的 1 在下面返回时加上
                    ans = max(ans, f[i][d]);
                }
            }
        return ans + 1;
    }
};
```

```go
func longestArithSeqLength(a []int) (ans int) {
    n := len(a)
    f := make([][1001]int, n)
    for i := 1; i < n; i++ {
        for j := i - 1; j >= 0; j-- {
            d := a[i] - a[j] + 500 // +500 防止出现负数
            if f[i][d] == 0 {
                f[i][d] = f[j][d] + 1 // 默认的 1 在下面返回时加上
                ans = max(ans, f[i][d])
            }
        }
    }
    return ans + 1
}

func max(a, b int) int { if a < b { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n(n+D))$，其中 $n$ 为 $a$ 的长度，$D=\max(a)-\min(a)$。初始化需要 $\mathcal{O}(nD)$。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。这里状态个数为 $\mathcal{O}(n)$，单个状态的计算时间为 $\mathcal{O}(n)$，因此时间复杂度为 $\mathcal{O}(nD+n^2)=\mathcal{O}(n(n+D))$。
-   空间复杂度：$\mathcal{O}(nD)$。有 $\mathcal{O}(n)$ 个状态，每个状态需要 $\mathcal{O}(D)$ 的空间。

#### 相似题目

-   [1218\. 最长定差子序列](https://leetcode.cn/problems/longest-arithmetic-subsequence-of-given-difference/)
-   [873\. 最长的斐波那契子序列的长度](https://leetcode.cn/problems/length-of-longest-fibonacci-subsequence/)
