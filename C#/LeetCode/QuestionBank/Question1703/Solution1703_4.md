#### [方法一：转化 + 中位数](https://leetcode.cn/problems/minimum-adjacent-swaps-for-k-consecutive-ones/solutions/536550/de-dao-lian-xu-k-ge-1-de-zui-shao-xiang-lpa9i/)

**思路与算法**

显然我们需要
-   找出数组中 $k$ 个连续的 $1$；
-   找出数组中 $k$ 个连续的位置。

然后将每个 $1$ 按照位置先后依次放入位置中。如果不按照顺序放入，那么交换的路线就会产生「交叉」，不会比按照顺序要优。

假设 $1$ 的位置从前往后分别为 $p_0, \cdots, p_{k-1}$，放入的位置分别为 $q, \cdots, q+k-1$，那么我们需要求出
$\sum\limits_{i=0}^{k-1} |p_i-(q+i)|$
的最小值。令 $p_i' = p_i - i$，那么
$\sum\limits_{i=0}^{k-1} |p_i-(q+i)| = \sum\limits_{i=0}^{k-1} |(p'_i+i)-(q+i)| = \sum\limits_{i=0}^{k-1} |p'_i-q|$

当 $q$ 为 $\{p_i'\}$ 的中位数时，上式取到最小值。

因此我们可以记 $f_0, f_1, \cdots, f_{m-1}$ 为数组 $nums$ 中所有 $1$ 的位置，并且令 $g_i = f_i -i$。由于 $f_0 < f_1 < \cdots < f_{m-1}$，因此 $g_0 \leq g_1 \leq \cdots \leq g_{m-1}$。这样一来，我们可以使用一个大小为 $k$ 的滑动窗口在 $\{g\}$ 上实时找出中位数并计算答案。

设我们当前的滑动窗口中包含 $g_i, \cdots, g_{i+k-1}$，它们已经有序，那么中位数为 $q=g_{(2i+k-1)/2}$。这里的除法为整数除法。记 $mid=(2i+k-1)/2$，此时的交换次数为
$\begin{aligned} \sum_{j=i}^{i+k-1} |g_j - q| &= \sum_{j=i}^{mid-1} (q-g_j) + \sum_{j=mid+1}^{i+k-1} (g_j-q) \\ &= (mid-i)q - \sum_{j=i}^{mid-1} g_j + \sum_{j=mid+1}^{i+k-1} g_j - (i+k-mid-1)q \\ &= \big(2(mid-i)-k+1\big)q + \sum_{j=mid+1}^{i+k-1} g_j - \sum_{j=i}^{mid-1} g_j \end{aligned}$

其中的后两项求和可以通过前缀和快速得到。

注意到当我们向右移动滑动窗口时，滑动窗口中的 $g_i, \cdots, g_{i+k-1}$ 是由对应的 $f$ 值减去 $i, \cdots, i+k-1$ 得来，而并不是我们在一开始设定的 $0, \cdots, k-1$。这里其实并不会影响答案：因为这相当于我们把 $f$ 值减去 $0, \cdots, k-1$ 之后再同时减去 $i$，那么取 $q$ 为 $g_i, \cdots, g_{i+k-1}$ 的中位数计算出的答案仍然是正确的。

**代码**

```cpp
class Solution {
public:
    int minMoves(vector<int>& nums, int k) {
        if (k == 1) {
            return 0;
        }
        
        int n = nums.size();
        vector<int> g;
        vector<int> sum = {0};
        int count = -1;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == 1) {
                ++count;
                g.push_back(i - count);
                sum.push_back(sum.back() + g.back());
            }
        }
        
        int m = g.size();
        int ans = INT_MAX;
        for (int i = 0; i + k <= m; ++i) {
            int mid = (i + i + k - 1) / 2;
            int q = g[mid];
            ans = min(ans, (2 * (mid - i) - k + 1) * q + (sum[i + k] - sum[mid + 1]) - (sum[mid] - sum[i]));
        }
        
        return ans;
    }
};
```

```python
class Solution:
    def minMoves(self, nums: List[int], k: int) -> int:
        if k == 1:
            return 0
        
        n = len(nums)
        g, total, count = list(), [0], -1
        
        for i, num in enumerate(nums):
            if num == 1:
                count += 1
                g.append(i - count)
                total.append(total[-1] + g[-1])
        
        m, ans = len(g), float("inf")
        
        for i in range(m - k + 1):
            mid = (i + i + k - 1) // 2
            q = g[mid]
            ans = min(ans, (2 * (mid - i) - k + 1) * q + (total[i + k] - total[mid + 1]) - (total[mid] - total[i]))
        
        return ans
```

**复杂度分析**

-   时间复杂度：$O(n)$。
-   空间复杂度：$O(n)$。
