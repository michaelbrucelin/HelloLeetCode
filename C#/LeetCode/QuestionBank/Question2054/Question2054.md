### [2054\. 两个最好的不重叠活动](https://leetcode.cn/problems/two-best-non-overlapping-events/)

难度：中等

给你一个下标从 **0** 开始的二维整数数组 `events`，其中 <code>events[i] = [startTime<sub>i</sub>, endTime<sub>i</sub>, value<sub>i</sub>]</code>。第 `i` 个活动开始于 <code>startTime<sub>i</sub></code>，结束于 <code>endTime<sub>i</sub></code>，如果你参加这个活动，那么你可以得到价值 <code>value<sub>i</sub></code>。你 **最多** 可以参加 **两个时间不重叠** 活动，使得它们的价值之和 **最大**。

请你返回价值之和的 **最大值**。

注意，活动的开始时间和结束时间是 **包括** 在活动时间内的，也就是说，你不能参加两个活动且它们之一的开始时间等于另一个活动的结束时间。更具体的，如果你参加一个活动，且结束时间为 `t`，那么下一个活动必须在 `t + 1` 或之后的时间开始。

**示例 1:**

> ![](./assets/img/Question2054_01.png)
>
> **输入：** events = \[[1,3,2],[4,5,2],[2,4,3]]
> **输出：** 4
> **解释：** 选择绿色的活动 0 和 1，价值之和为 2 + 2 = 4。

**示例 2：**

> ![](./assets/img/Question2054_02.png)
>
> **输入：** events = \[[1,3,2],[4,5,2],[1,5,5]]
> **输出：** 5
> **解释：** 选择活动 2，价值和为 5。

**示例 3：**

> ![](./assets/img/Question2054_03.png)
>
> **输入：** events = \[[1,5,3],[1,5,1],[6,6,5]]
> **输出：** 8
> **解释：** 选择活动 0 和 2，价值之和为 3 + 5 = 8。

**提示：**

- <code>2 <= events.length <= 10<sup>5</sup></code>
- `events[i].length == 3`
- <code>1 <= startTime<sub>i</sub> <= endTime<sub>i</sub> <= 10<sup>9</sup></code>
- <code>1 <= value<sub>i</sub> <= 10<sup>6</sup></code>
