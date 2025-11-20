### [757\. 设置交集大小至少为2](https://leetcode.cn/problems/set-intersection-size-at-least-two/)

难度：困难

给你一个二维整数数组 `intervals`，其中 <code>intervals[i] = [start<sub>i</sub>, end<sub>i</sub>]</code> 表示从 <code>start<sub>i</sup></code> 到 <code>end<sub>i</sup></code> 的所有整数，包括 <code>start<sub>i</sup></code> 和 <code>end<sub>i</sup></code>。

**包含集合** 是一个名为 `nums` 的数组，并满足 `intervals` 中的每个区间都 **至少** 有 **两个** 整数在 `nums` 中。

- 例如，如果 `intervals = [[1,3], [3,7], [8,9]]`，那么 `[1,2,4,7,8,9]` 和 `[2,3,4,8,9]` 都符合 **包含集合** 的定义。

返回包含集合可能的最小大小。

**示例 1：**

> **输入：** intervals = \[[1,3],[3,7],[8,9]]
> **输出：** 5
> **解释：** nums = [2, 3, 4, 8, 9].
> 可以证明不存在元素数量为 4 的包含集合。

**示例 2：**

> **输入：** intervals = \[[1,3],[1,4],[2,5],[3,5]]
> **输出：** 3
> **解释：** nums = [2, 3, 4].
> 可以证明不存在元素数量为 2 的包含集合。

**示例 3：**

> **输入：** intervals = \[[1,2],[2,3],[2,4],[4,5]]
> **输出：** 5
> **解释：** nums = [1, 2, 3, 4, 5].
> 可以证明不存在元素数量为 4 的包含集合。

**提示：**

- `1 <= intervals.length <= 3000`
- `intervals[i].length == 2`
- <code>0 <= start<sub>i</sub> < end<sub>i</sub> <= 10<sup>8</sup></code>
