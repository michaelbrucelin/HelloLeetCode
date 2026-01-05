### [149\. 直线上最多的点数](https://leetcode.cn/problems/max-points-on-a-line/)

难度：困难

给你一个数组 `points`，其中 <code>points[i] = [x<sub>i</sub>, y<sub>i</sub>]</code> 表示 **X-Y** 平面上的一个点。求最多有多少个点在同一条直线上。

**示例 1：**

> ![](./assets/img/Question0149_01.jpg)
>
> **输入：** points = \[[1,1],[2,2],[3,3]]
> **输出：** 3

**示例 2：**

> ![](./assets/img/Question0149_02.jpg)
>
> **输入：** points = \[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
> **输出：** 4

**提示：**

- `1 <= points.length <= 300`
- `points[i].length == 2`
- <code>-10<sup>4</sup> <= x<sub>i</sub>, y<sub>i</sub> <= 10<sup>4</sup></code>
- `points` 中的所有点 **互不相同**
