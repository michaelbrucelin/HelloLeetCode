### [两种方法：动态规划/前缀和（附题单！Python/Java/C++/Go/JS）](https://leetcode.cn/problems/maximum-absolute-sum-of-any-subarray/solutions/2377930/liang-chong-fang-fa-dong-tai-gui-hua-qia-dczr/)

#### 方法一：动态规划

#### 前置知识：动态规划入门

请看 [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)。

#### 思路

问题可以转换成求 [53\. 最大子数组和](https://leetcode.cn/problems/maximum-subarray/) 以及「最小子数组和的绝对值（相反数）」，这二者中的最大值就是答案。

考虑以 $nums[i]$ 结尾的最大子数组和：

-   如果子数组只有一个数，那么最大子数组和就是 $nums[i]$。
-   如果把 $nums[i]$ 和前面的子数组拼起来，那么问题变成求「以 $nums[i-1]$ 结尾的最大子数组和」。

这启发我们得到下面的状态定义和状态转移方程。

定义 $f[i]$ 表示以 $nums[i]$ 结尾的最大子数组和：

-   如果子数组只有一个数：$f[i]=nums[i]$。
-   如果把 $nums[i]$ 和前面的子数组拼起来：$f[i]=f[i-1]+nums[i]$。
-   这两种情况取最大值，即

$$f[i] = \max(nums[i], f[i-1]+nums[i]) = \max(f[i-1], 0) + nums[i]$$

枚举子数组的最后一个数，最大子数组和就是

$$\max(\max(f), 0)$$

这里与 $0$ 取最大值是因为子数组可以为空。

最小子数组和的计算方法与最大子数组和类似。

代码实现时，可以按照 [视频](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F) 中讲的，只用几个变量滚动计算。

```python
class Solution:
    def maxAbsoluteSum(self, nums: List[int]) -> int:
        ans = f_max = f_min = 0
        for x in nums:
            f_max = max(f_max, 0) + x
            f_min = min(f_min, 0) + x
            ans = max(ans, f_max, -f_min)
        return ans
```

```java
class Solution {
    public int maxAbsoluteSum(int[] nums) {
        int ans = 0, fMax = 0, fMin = 0;
        for (int x : nums) {
            fMax = Math.max(fMax, 0) + x;
            fMin = Math.min(fMin, 0) + x;
            ans = Math.max(ans, Math.max(fMax, -fMin));
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int maxAbsoluteSum(vector<int> &nums) {
        int ans = 0, f_max = 0, f_min = 0;
        for (int x: nums) {
            f_max = max(f_max, 0) + x;
            f_min = min(f_min, 0) + x;
            ans = max(ans, max(f_max, -f_min));
        }
        return ans;
    }
};
```

```go
func maxAbsoluteSum(nums []int) (ans int) {
    var fMax, fMin int
    for _, x := range nums {
        fMax = max(fMax, 0) + x
        fMin = min(fMin, 0) + x
        ans = max(ans, max(fMax, -fMin))
    }
    return
}

func min(a, b int) int { if b < a { return b }; return a }
func max(a, b int) int { if b > a { return b }; return a }
```

```javascript
var maxAbsoluteSum = function (nums) {
    let ans = 0, fMax = 0, fMin = 0;
    for (const x of nums) {
        fMax = Math.max(fMax, 0) + x;
        fMin = Math.min(fMin, 0) + x;
        ans = Math.max(ans, fMax, -fMin);
    }
    return ans;
};
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $nums$ 的长度。
-   空间复杂度：$\mathcal{O}(1)$。仅用到若干额外变量。

#### 方法二：前缀和

#### 前置知识：前缀和

对于数组 $nums$，定义它的前缀和 $s[0]=0$，$s[i+1] = \sum\limits_{j=0}^{i}nums[j]$。

根据这个定义，有 $s[i+1]=s[i]+nums[i]$。

例如 $nums=[1,2,1,2]$，对应的前缀和数组为 $s=[0,1,3,4,6]$。

通过前缀和，我们可以把**子数组的元素和转换成两个前缀和的差**，即

$$\sum_{j=left}^{right}nums[j] = \sum\limits_{j=0}^{right}nums[j] - \sum\limits_{j=0}^{left-1}nums[j] = s[right+1] - s[left]$$

例如 $nums$ 的子数组 $[2,1,2]$ 的和就可以用 $s[4]-s[1]=6-1=5$ 算出来。

**注**：$s[0]=0$ 表示一个空数组的元素和。为什么要额外定义它？想一想，如果要计算的子数组恰好是一个前缀（从 $nums[0]$ 开始），你要用 $s[right]$ 减去谁呢？通过定义 $s[0]=0$，任意子数组（包括前缀）都可以表示为两个前缀和的差。

#### 思路

由于子数组和等于两个前缀和的差，那么取前缀和中的最大值与最小值，它俩的差就是答案。

如果最大值在最小值右边，那么算的是最大子数组和。

如果最大值在最小值左边，那么算的是最小子数组和的绝对值（相反数）。

**补充说明**：对于 [53\. 最大子数组和](https://leetcode.cn/problems/maximum-subarray/) 这题，可以枚举前缀和，同时维护前面的前缀和的最小值 $minS$，用当前前缀和减去 $minS$ 就是以这个位置结尾的子数组的最大值了。

```python
class Solution:
    def maxAbsoluteSum(self, nums: List[int]) -> int:
        s = list(accumulate(nums, initial=0))  # nums 的前缀和
        return max(s) - min(s)
```

```java
class Solution {
    public int maxAbsoluteSum(int[] nums) {
        int s = 0, mx = 0, mn = 0;
        for (int x : nums) {
            s += x;
            // mx = Math.max(mx, s);
            // mn = Math.min(mn, s);
            if (s > mx) mx = s;
            else if (s < mn) mn = s; // 效率更高的写法
        }
        return mx - mn;
    }
}
```

```cpp
class Solution {
public:
    int maxAbsoluteSum(vector<int> &nums) {
        int s = 0, mx = 0, mn = 0;
        for (int x: nums) {
            s += x;
            mx = max(mx, s);
            mn = min(mn, s);
        }
        return mx - mn;
    }
};
```

```go
func maxAbsoluteSum(nums []int) int {
    var s, mx, mn int
    for _, x := range nums {
        s += x
        if s > mx {
            mx = s
        } else if s < mn {
            mn = s
        }
    }
    return mx - mn
}
```

```javascript
var maxAbsoluteSum = function (nums) {
    let s = 0, mx = 0, mn = 0;
    for (const x of nums) {
        s += x;
        mx = Math.max(mx, s);
        mn = Math.min(mn, s);
    }
    return mx - mn;
};
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $nums$ 的长度。
-   空间复杂度：$\mathcal{O}(n)$ 或 $\mathcal{O}(1)$。Python 为了方便直接生成了前缀和数组，其它语言是一边遍历一边计算的。

#### 练习

-   [53\. 最大子数组和](https://leetcode.cn/problems/maximum-subarray/)
-   [2606\. 找到最大开销的子字符串](https://leetcode.cn/problems/find-the-substring-with-maximum-cost/)
-   [918\. 环形子数组的最大和](https://leetcode.cn/problems/maximum-sum-circular-subarray/)
-   [1186\. 删除一次得到子数组最大和](https://leetcode.cn/problems/maximum-subarray-sum-with-one-deletion/)
-   [2321\. 拼接数组的最大分数](https://leetcode.cn/problems/maximum-score-of-spliced-array/)

动态规划/前缀和，是解决「最大子数组和」问题的两种基本方法。

那么，有没有一道题能同时用到这两种方法呢？

有！这题是 [Codeforces 75D. Big Maximum Sum](https://leetcode.cn/link/?target=https%3A%2F%2Fcodeforces.com%2Fproblemset%2Fproblem%2F75%2FD)
