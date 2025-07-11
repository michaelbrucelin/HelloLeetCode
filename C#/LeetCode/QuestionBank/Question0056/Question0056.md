### [56\. 合并区间](https://leetcode.cn/problems/merge-intervals/)

难度：中等

以数组 `intervals` 表示若干个区间的集合，其中单个区间为 <code>intervals[i] = [start<sub>i</sub>, end<sub>i</sub>]</code> 。请你合并所有重叠的区间，并返回 _一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间_ 。

**示例 1：**

> **输入：** intervals = \[[1,3],[2,6],[8,10],[15,18]]
> **输出：** \[[1,6],[8,10],[15,18]]
> **解释：** 区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].

**示例 2：**

> **输入：** intervals = \[[1,4],[4,5]]
> **输出：** \[[1,5]]
> **解释：** 区间 [1,4] 和 [4,5] 可被视为重叠区间。

**提示：**

- <code>1 <= intervals.length <= 10<sup>4</sup></code>
- <code>intervals[i].length == 2</code>
- <code>0 <= start_i <= end_i <= 10<sup>4</sup></code>
