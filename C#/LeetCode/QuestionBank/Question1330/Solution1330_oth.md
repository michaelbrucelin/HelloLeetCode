#### [不会化简？请看这！（Python/Java/C++/Go）](https://leetcode.cn/problems/reverse-subarray-to-maximize-array-value/solutions/2266500/bu-hui-hua-jian-qing-kan-zhe-pythonjavac-c2s6/)

#### 初步分析

如果不翻转，或者翻转的是一个长为 $1$ 的子数组，那么 $nums$ 不变，此时的「数组值」记作 $base$。

> 示例 1 的 $base=|2-3|+|3-1|+|1-5|+|5-4|=1+2+4+1=8$。

为了计算出最大的「数组值」，考虑翻转后与翻转前的差值 $d$，那么答案为 $base+d$，所以 $d$ 越大，答案也就越大。

假设从 $nums[i]$ 到 $nums[j]$ 的这段子数组翻转了，且 $1\le i < j < n-1$（其中 $n$ 为 $nums$ 的长度）。设 $a=nums[i-1],\ b=nums[i],\ x=nums[j],\ y=nums[j+1]$。

> 对于 $i=0$ 或 $j=n-1$ 的翻转，单独用 $\mathcal{O}(n)$ 的时间枚举。

翻转前，这 $4$ 个数对数组值的贡献为

$$|a-b| + |x-y|$$

翻转后，顺序变为 $a,x,b,y$，贡献为

$$|a-x| + |b-y|$$

得到

$$d = |a-x|+|b-y|-|a-b|-|x-y| \tag{1}$$

问题转换成求 $d$ 的最大值。

> 示例 1 中翻转的子数组对应的 $a=2,b=3,x=5,y=4$，代入上式得 $d=2$，数组值为 $base+d=8+2=10$。

暴力枚举 $i$ 和 $j$ 的时间复杂度是 $\mathcal{O}(n^2)$ 的，如何优化？化简 $(1)$ 式是本题的核心。

#### 若干恒等式

对于 $|a-b|$：

-   如果 $a\ge b$，结果是 $a-b$；
-   如果 $a < b$，结果是 $b-a$；
-   总而言之，结果就是大的减去小的。

所以

$$|a-b| = \max(a,b) - \min(a,b) \tag{2}$$

此外还有如下恒等式

$$a+b = \max(a,b) + \min(a,b) \tag{3}$$

$(3)+(2)$ 得

$$a+b+|a-b| = 2\cdot\max(a,b) \tag{4}$$

$(3)-(2)$ 得

$$a+b-|a-b| = 2\cdot\min(a,b) \tag{5}$$

恒等式 $(4)$ 和 $(5)$ 是化简 $(1)$ 式的钥匙。

转动钥匙，让我们开始吧！

#### 分类讨论

$a,b,x,y$ 这 $4$ 个数的大小关系一共有 $4!=24$ 种情况，例如 $a\le b\le x\le y,\ b\le x\le a \le y$ 等等。

按照这 $4$ 个数中的哪两个数是最小的两个，可以分为 $C(4,2)=6$ 类，每类 $4$ 种情况。

利用**对称性**，只需讨论其中 $3$ 类，便可以得到另外 $3$ 类的结果。

**第 1 类**：$\max(a,b) \le \min(x,y)$

把 $a,b,x,y$ 画在数轴上，相当于 $a$ 和 $b$ 都在 $x$ 和 $y$ 的左边（或重合）。

那么

$$\begin{aligned} d = &|a-x|+|b-y|-|a-b|-|x-y|\\ =&(x-a) + (y-b) -|a-b|-|x-y|\\ =&(x+y) - (a+b) -|a-b|-|x-y|\\ =&(x+y-|x-y|)-(a+b +|a-b|)\\ =&2\cdot\min(x,y) - 2\cdot\max(a,b) \end{aligned}$$

注意 $\max(a,b)\le \min(x,y)$，上式是 $\ge 0$ 的。

利用对称性，对于 $\max(x,y)\le \min(a,b)$ 的 $4$ 种情况，可以得到类似的结果

$$d = 2\cdot\min(a,b) - 2\cdot\max(x,y) \ge 0$$

很好，已经讨论清楚 $8$ 种情况了！

**第 2 类**：$\max(a,x)\le \min(b,y)$

把 $a,b,x,y$ 画在数轴上，相当于 $a$ 和 $x$ 都在 $b$ 和 $y$ 的左边（或重合）。

那么

$$\begin{aligned} d = &|a-x|+|b-y|-|a-b|-|x-y|\\ =&|a-x|+|b-y| -(b-a)-(y-x)\\ =&|a-x|+|b-y| +(a+x) -(b+y)\\ =&(a+x+|a-x|)-(b+y -|b-y|)\\ =&2\cdot\max(a,x) - 2\cdot\min(b,y) \end{aligned}$$

由于 $\max(a,x)\le \min(b,y)$，上式 $\le 0$。

利用对称性，对于 $\max(b,y)\le \min(a,x)$ 的 $4$ 种情况，可以得到类似的结果。

$$d = 2\cdot\max(b,y) - 2\cdot\min(a,x) \le 0$$

所以这 $8$ 种情况不会对 $d$ 的最大值产生影响。（注意可以只翻转长为 $1$ 的子数组，此时 $d=0$。）

很好，已经讨论清楚 $16$ 种情况了！

**第 3 类**：$\max(a,y)\le \min(b,x)$

把 $a,b,x,y$ 画在数轴上，相当于 $a$ 和 $y$ 都在 $b$ 和 $x$ 的左边（或重合）。

那么

$$\begin{aligned} d = &|a-x|+|b-y|-|a-b|-|x-y|\\ =&(x-a)+(b-y)-(b-a)-(x-y)\\ =&0 \end{aligned}$$

利用对称性，对于 $\max(b,x)\le \min(a,y)$ 的 $4$ 种情况，同样可以得到 $d=0$。

所以这 $8$ 种情况也不会对 $d$ 的最大值产生影响。

$24$ 种情况讨论完毕。

#### 算法

由于只有第 1 类的情况会影响 $d$ 的最大值，为了最大化 $d$，在遍历 $nums$ 的所有相邻元素 $a,b$ 的同时，维护 $\min(a,b)$ 的最大值 $mx$，以及 $\max(a,b)$ 的最小值 $mn$。

遍历结束后，如果 $mx>mn$，那么对应的 $a,b,x,y$ 存在，且大小关系必然属于第 1 类讨论的 $8$ 种情况之一。则有

$$d=2\cdot (mx-mn)$$

如果 $mx=mn$，由于 $d$ 初始值为 $0$，不会产生影响。

特别地，对于翻转范围在数组边界的情况（$i=0$ 或 $j=n-1$），单独枚举，并更新 $d$ 的最大值。

> 根据题目的数据范围，运算结果可能超出 `int` 范围，但返回类型却是 `int`。
> 
> 我已向官方反馈了这个问题，等待官方修复（改进题目描述）。

```python
class Solution:
    def maxValueAfterReverse(self, nums: List[int]) -> int:
        base = d = 0
        mx, mn = -inf, inf
        for a, b in pairwise(nums):
            base += abs(a - b)
            mx = max(mx, min(a, b))
            mn = min(mn, max(a, b))
            d = max(d, abs(nums[0] - b) - abs(a - b),  # i=0
                       abs(nums[-1] - a) - abs(a - b))  # j=n-1
        return base + max(d, 2 * (mx - mn))
```

```java
class Solution {
    public int maxValueAfterReverse(int[] nums) {
        int base = 0, d = 0, n = nums.length;
        int mx = Integer.MIN_VALUE, mn = Integer.MAX_VALUE;
        for (int i = 1; i < n; i++) {
            int a = nums[i - 1], b = nums[i];
            int dab = Math.abs(a - b);
            base += dab;
            mx = Math.max(mx, Math.min(a, b));
            mn = Math.min(mn, Math.max(a, b));
            d = Math.max(d, Math.max(Math.abs(nums[0] - b) - dab, // i=0
                                     Math.abs(nums[n - 1] - a) - dab)); // j=n-1
        }
        return base + Math.max(d, 2 * (mx - mn));
    }
}
```

```cpp
class Solution {
public:
    int maxValueAfterReverse(vector<int> &nums) {
        int base = 0, d = 0, mx = INT_MIN, mn = INT_MAX, n = nums.size();
        for (int i = 1; i < n; i++) {
            int a = nums[i - 1], b = nums[i];
            base += abs(a - b);
            mx = max(mx, min(a, b));
            mn = min(mn, max(a, b));
            d = max(d, max(abs(nums[0] - b) - abs(a - b), // i=0
                           abs(nums[n - 1] - a) - abs(a - b))); // j=n-1
        }
        return base + max(d, 2 * (mx - mn));
    }
};
```

```go
func maxValueAfterReverse(nums []int) int {
    base, d, n := 0, 0, len(nums)
    mx, mn := math.MinInt, math.MaxInt
    for i := 1; i < n; i++ {
        a, b := nums[i-1], nums[i]
        base += abs(a - b)
        mx = max(mx, min(a, b))
        mn = min(mn, max(a, b))
        d = max(d, max(abs(nums[0]-b)-abs(a-b), // i=0
                       abs(nums[n-1]-a)-abs(a-b))) // j=n-1
    }
    return base + max(d, 2*(mx-mn))
}

func abs(x int) int { if x < 0 { return -x }; return x }
func min(a, b int) int { if b < a { return b }; return a }
func max(a, b int) int { if b > a { return b }; return a }
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为 $nums$ 的长度。
-   空间复杂度：$\mathcal{O}(1)$。仅用到若干额外变量。
