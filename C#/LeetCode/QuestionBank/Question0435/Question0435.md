### [435\. 无重叠区间](https://leetcode.cn/problems/non-overlapping-intervals/)

难度：中等

给定一个区间的集合 `intervals`，其中 <code>intervals[i] = [start<sub>i</sub>, end<sub>i</sub>]</code>。返回 _需要移除区间的最小数量，使剩余区间互不重叠_。

**注意** 只在一点上接触的区间是 **不重叠的**。例如 `[1, 2]` 和 `[2, 3]` 是不重叠的。

**示例 1:**

> **输入:** intervals = \[[1,2],[2,3],[3,4],[1,3]]
> **输出:** 1
> **解释:** 移除 [1,3] 后，剩下的区间没有重叠。

**示例 2:**

> **输入:** intervals = [ [1,2], [1,2], [1,2] ]
> **输出:** 2
> **解释:** 你需要移除两个 [1,2] 来使剩下的区间没有重叠。

**示例 3:**

> **输入:** intervals = [ [1,2], [2,3] ]
> **输出:** 0
> **解释:** 你不需要移除任何区间，因为它们已经是无重叠的了。

**提示:**

- <code>1 <= intervals.length <= 10<sup>5</sup></code>
- `intervals[i].length == 2`
- <code>-5 &times; 10<sup>4</sup> <= start<sub>i</sub> < end<sub>i</sub> <= 5 &times; 10<sup>4</sup></code>
