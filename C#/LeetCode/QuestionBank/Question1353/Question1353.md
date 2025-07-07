### [1353\. 最多可以参加的会议数目](https://leetcode.cn/problems/maximum-number-of-events-that-can-be-attended/)

难度：中等

给你一个数组 `events`，其中 <code>events[i] = [startDay<sub>i</sub>, endDay<sub>i</sub>]</code>，表示会议 `i` 开始于 <code>startDay<sub>i</sub></code>，结束于 <code>endDay<sub>i</sub></code>。

你可以在满足 <code>startDay<sub>i</sub> <= d <= endDay<sub>i</sub></code> 中的任意一天 `d` 参加会议 `i`。在任意一天 `d` 中只能参加一场会议。

请你返回你可以参加的 **最大** 会议数目。

**示例 1：**

![](./assets/img/Question1353.png)

> **输入：** events = \[[1,2],[2,3],[3,4]]
> **输出：** 3
> **解释：** 你可以参加所有的三个会议。
> 安排会议的一种方案如上图。
> 第 1 天参加第一个会议。
> 第 2 天参加第二个会议。
> 第 3 天参加第三个会议。

**示例 2：**

> **输入：** events= \[[1,2],[2,3],[3,4],[1,2]]
> **输出：** 4

**提示：**

- <code>1 <= events.length <= 10<sup>5</sup></code>
- <code>events[i].length == 2</code>
- <code>1 <= startDay<sub>i</sub> <= endDay<sub>i</sub> <= 10<sup>5</sup></code>
