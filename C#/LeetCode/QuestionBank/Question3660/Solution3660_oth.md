### [结论 + 动态规划（Python/Java/C++/Go）](https://leetcode.cn/problems/jump-game-ix/solutions/3762167/jie-lun-ti-pythonjavacgo-by-endlesscheng-x2qu/)

想一想，是 $ans[0]$ 更好算，还是 $ans[n-1]$ 更好算？

对于 $i=n-1$ 来说，它一定能跳到 $nums$ 的最大值：

- 如果最大值等于 $nums[n-1]$，那么命题成立。
- 否则最大值比 $nums[n-1]$ 大，且下标小于 $n-1$。根据规则，能从 $n-1$ 跳到。

所以 $ans[n-1]=max(nums)$。

而对于 $ans[0]$，就变得非常复杂了。比如 $nums=[6,8,5,9,7]$，从 $6$ 跳到 $9$ 的顺序为 $6\rightarrow 5\rightarrow 8\rightarrow 7\rightarrow 9$。

所以**倒着思考更简单**。

那么，每个数都能跳到最大值吗？什么情况下无法跳到最大值？

比如 $nums=[3,1,2,30,10,20]$，无法从 $3,1,2$ 跳到 $30,10,20$。在 $2$ 和 $30$ 之间有一条「分界线」，如果分界线左边的最大值比分界线右边的最小值还小（或者相等），那么无法从分界线左边跳到分界线右边，所以分界线左边的数无法跳到 $nums$ 的最大值。

一般地，设 $[0,i]$ 中的最大值为 $preMax[i]$，[i+1,n-1] 中的最小值为 $sufMin[i+1]$。

- 如果 $preMax[i]\le sufMin[i+1]$，对于 $[0,i]$ 中的任意下标 $p$ 和 $[i+1,n-1]$ 中的任意下标 $q$，我们有 $nums[p]\le preMax[i]\le sufMin[i+1]\le nums[q]$，所以 $[0,i]$ 中的任何下标都无法跳到 $[i+1,n-1]$ 中。问题变成 $[0,i]$ 的子问题。类似前文 $i=n-1$ 的讨论，我们有 $ans[i]=preMax[i]$。
- 否则 $preMax[i]>sufMin[i+1]$，我们可以先从 $i$ 跳到 $preMax[i]$ 的位置，再跳到 $sufMin[i+1]$ 的位置，最后跳到 $i+1$。所以 $i+1$ 能跳到的数，$i$ 也能跳到（反之亦然），所以 $ans[i]=ans[i+1]$。

一般地，我们有如下状态转移方程

$$ans[i]=\begin{cases}preMax[i], & preMax[i]\le sufMin[i+1] \\ ans[i+1], & preMax[i]>sufMin[i+1]\end{cases}$$

规定 $sufMin[n]=\infty$。

代码实现时，可以在计算 $ans$ 的同时计算 $sufMin$，所以 $sufMin$ 可以简化成一个变量。

```Python
class Solution:
    def maxValue(self, nums: List[int]) -> List[int]:
        n = len(nums)
        pre_max = list(accumulate(nums, max))  # nums 的前缀最大值

        ans = [0] * n
        suf_min = inf
        for i in range(n - 1, -1, -1):
            ans[i] = pre_max[i] if pre_max[i] <= suf_min else ans[i + 1]
            suf_min = min(suf_min, nums[i])
        return ans
```

```Python
# 普通写法
class Solution:
    def maxValue(self, nums: List[int]) -> List[int]:
        n = len(nums)
        pre_max = [0] * n
        pre_max[0] = nums[0]
        for i in range(1, n):
            pre_max[i] = max(pre_max[i - 1], nums[i])

        ans = [0] * n
        suf_min = inf
        for i in range(n - 1, -1, -1):
            ans[i] = pre_max[i] if pre_max[i] <= suf_min else ans[i + 1]
            suf_min = min(suf_min, nums[i])
        return ans
```

```Java
class Solution {
    public int[] maxValue(int[] nums) {
        int n = nums.length;
        int[] preMax = new int[n];
        preMax[0] = nums[0];
        for (int i = 1; i < n; i++) {
            preMax[i] = Math.max(preMax[i - 1], nums[i]);
        }

        int[] ans = new int[n];
        int sufMin = Integer.MAX_VALUE;
        for (int i = n - 1; i >= 0; i--) {
            ans[i] = preMax[i] <= sufMin ? preMax[i] : ans[i + 1];
            sufMin = Math.min(sufMin, nums[i]);
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    vector<int> maxValue(vector<int>& nums) {
        int n = nums.size();
        vector<int> pre_max(n);
        pre_max[0] = nums[0];
        for (int i = 1; i < n; i++) {
            pre_max[i] = max(pre_max[i - 1], nums[i]);
        }

        vector<int> ans(n);
        int suf_min = INT_MAX;
        for (int i = n - 1; i >= 0; i--) {
            ans[i] = pre_max[i] <= suf_min ? pre_max[i] : ans[i + 1];
            suf_min = min(suf_min, nums[i]);
        }
        return ans;
    }
};
```

```Go
func maxValue(nums []int) []int {
    n := len(nums)
    preMax := make([]int, n)
    preMax[0] = nums[0]
    for i := 1; i < n; i++ {
        preMax[i] = max(preMax[i-1], nums[i])
    }

    ans := make([]int, n)
    sufMin := math.MaxInt
    for i := n - 1; i >= 0; i-- {
        if preMax[i] <= sufMin {
            ans[i] = preMax[i]
        } else {
            ans[i] = ans[i+1]
        }
        sufMin = min(sufMin, nums[i])
    }
    return ans
}
```

也可以直接把答案保存在 $preMax$ 中。

```Python
# 手写 min max 更快
min = lambda a, b: b if b < a else a
max = lambda a, b: b if b > a else a

class Solution:
    def maxValue(self, nums: List[int]) -> List[int]:
        n = len(nums)
        pre_max = list(accumulate(nums, max))  # nums 的前缀最大值

        suf_min = inf
        for i in range(n - 1, -1, -1):
            if pre_max[i] > suf_min:
                pre_max[i] = pre_max[i + 1]
            suf_min = min(suf_min, nums[i])
        return pre_max
```

```Java
class Solution {
    public int[] maxValue(int[] nums) {
        int n = nums.length;
        int[] preMax = new int[n];
        preMax[0] = nums[0];
        for (int i = 1; i < n; i++) {
            preMax[i] = Math.max(preMax[i - 1], nums[i]);
        }

        int sufMin = Integer.MAX_VALUE;
        for (int i = n - 1; i >= 0; i--) {
            if (preMax[i] > sufMin) {
                preMax[i] = preMax[i + 1];
            }
            sufMin = Math.min(sufMin, nums[i]);
        }
        return preMax;
    }
}
```

```C++
class Solution {
public:
    vector<int> maxValue(vector<int>& nums) {
        int n = nums.size();
        vector<int> pre_max(n);
        pre_max[0] = nums[0];
        for (int i = 1; i < n; i++) {
            pre_max[i] = max(pre_max[i - 1], nums[i]);
        }

        int suf_min = INT_MAX;
        for (int i = n - 1; i >= 0; i--) {
            if (pre_max[i] > suf_min) {
                pre_max[i] = pre_max[i + 1];
            }
            suf_min = min(suf_min, nums[i]);
        }
        return pre_max;
    }
};
```

```Go
func maxValue(nums []int) []int {
    n := len(nums)
    preMax := make([]int, n)
    preMax[0] = nums[0]
    for i := 1; i < n; i++ {
        preMax[i] = max(preMax[i-1], nums[i])
    }

    sufMin := math.MaxInt
    for i := n - 1; i >= 0; i-- {
        if preMax[i] > sufMin {
            preMax[i] = preMax[i+1]
        }
        sufMin = min(sufMin, nums[i])
    }
    return preMax
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(1)$。返回值不计入。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/基环树/最短路/最小生成树/网络流）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/划分/状态机/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
