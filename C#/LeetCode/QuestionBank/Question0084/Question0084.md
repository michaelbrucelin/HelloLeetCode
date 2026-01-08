### [84\. 柱状图中最大的矩形](https://leetcode.cn/problems/largest-rectangle-in-histogram/)

难度：困难

给定 _n_ 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1。

求在该柱状图中，能够勾勒出来的矩形的最大面积。

**示例 1:**

> ![](./assets/img/Question0084_01.jpg)
>
> **输入：** heights = [2,1,5,6,2,3]
> **输出：** 10
> **解释：** 最大的矩形为图中红色区域，面积为 10

**示例 2：**

> ![](./assets/img/Question0084_02.jpg)
>
> **输入：** heights = [2,4]
> **输出：** 4

**提示：**

- <code>1 <= heights.length <=10<sup>5</sup></code>
- <code>0 <= heights[i] <= 10<sup>4</sup></code>
