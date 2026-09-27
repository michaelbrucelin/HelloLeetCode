### [从 $O(n^2)$ 到 $O(n)$：单调栈+计算每个元素对答案的贡献](https://leetcode.cn/problems/sum-of-subarray-ranges/solutions/1153054/cong-on2-dao-ondan-diao-zhan-ji-suan-mei-o1op/)

#### 方法一：暴力枚举所有子数组

写一个二重循环，外层循环枚举子数组的左边界，内层循环枚举子数组的右边界，同时维护当前子数组的最小值和最大值。

```go
func subArrayRanges(nums []int) (ans int64) {
    for i, num := range nums {
        min, max := num, num
        for _, v := range nums[i+1:] {
            if v < min {
                min = v
            } else if v > max {
                max = v
            }
            ans += int64(max - min)
        }
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$，我们只需要常数的空间保存若干变量。

#### 方法二：单调栈 $+$ 计算每个元素对答案的贡献

不了解单调栈的同学请看 [单调栈【基础算法精讲 26】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1VN411J7S7%2F)。

我们可以考虑每个元素作为最大值出现在了多少子数组中，以及作为最小值出现在了多少子数组中。

以最大值为例。我们可以求出 $nums[i]$ 左侧**严格大于**它的最近元素位置 $left[i]$，以及右侧**大于等于**它的最近元素位置 $right[i]$。注意 $nums$ 中可能有重复元素，所以这里右侧取大于等于，这样可以避免在有重复元素的情况下，重复统计相同的子数组。

设以 $nums[i]$ 为最大值的子数组为 $nums[l..r]$，则有

- $left[i]<l\le i$
- $i\le r<right[i]$

所以 $nums[i]$ 可以作为最大值出现在

$$(i-left[i])\cdot (right[i]-i)$$

个子数组中，这对答案产生的贡献是

$$(i-left[i])\cdot (right[i]-i)\cdot nums[i]$$

最小值的做法同理（贡献为负数）。

累加所有贡献即为答案。

```go
func solve(nums []int) (ans int64) {
    n := len(nums)
    left := make([]int, n)  // left[i] 为左侧严格大于 num[i] 的最近元素位置（不存在时为 -1）
    right := make([]int, n) // right[i] 为右侧大于等于 num[i] 的最近元素位置（不存在时为 n）
    for i := range right { right[i] = n }
    st := []int{-1}
    for i, v := range nums {
        for len(st) > 1 && nums[st[len(st)-1]] <= v {
            right[st[len(st)-1]] = i
            st = st[:len(st)-1]
        }
        left[i] = st[len(st)-1]
        st = append(st, i)
    }
    for i, v := range nums {
        ans += int64(i-left[i]) * int64(right[i]-i) * int64(v)
    }
    return
}

func subArrayRanges(nums []int) int64 {
    ans := solve(nums)
    for i, v := range nums { // 小技巧：所有元素取反后算的就是最小值的贡献
        nums[i] = -v
    }
    return ans + solve(nums)
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(n)$。

#### 思考题

把子数组改成**子序列**，要怎么做？

这题是 [891\. 子序列宽度之和](https://leetcode.cn/problems/sum-of-subsequence-widths/)。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
