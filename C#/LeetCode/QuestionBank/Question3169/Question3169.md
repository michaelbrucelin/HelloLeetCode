### [3169\. 无需开会的工作日](https://leetcode.cn/problems/count-days-without-meetings/)

难度：中等

给你一个正整数 `days`，表示员工可工作的总天数（从第 1 天开始）。另给你一个二维数组 `meetings`，长度为 `n`，其中 <code>meetings[i] = [start<sub>i</sub>, end<sub>i</sub>]</code> 表示第 `i` 次会议的开始和结束天数（包含首尾）。

返回员工可工作且没有安排会议的天数。

**注意：** 会议时间可能会有重叠。

**示例 1：**

> **输入：** days = 10, meetings = \[[5,7],[1,3],[9,10]]
> **输出：** 2
> **解释：**
> 第 4 天和第 8 天没有安排会议。

**示例 2：**

> **输入：** days = 5, meetings = \[[2,4],[1,3]]
> **输出：** 1
> **解释：**
> 第 5 天没有安排会议。

**示例 3：**

> **输入：** days = 6, meetings = \[[1,6]]
> **输出：** 0
> **解释：**
> 所有工作日都安排了会议。

**提示：**

- <code>1 <= days <= 10<sup>9</sup></code>
- <code>1 <= meetings.length <= 10<sup>5</sup></code>
- `meetings[i].length == 2`
- `1 <= meetings[i][0] <= meetings[i][1] <= days`
