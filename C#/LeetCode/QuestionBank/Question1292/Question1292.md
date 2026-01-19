### [1292\. 元素和小于等于阈值的正方形的最大边长](https://leetcode.cn/problems/maximum-side-length-of-a-square-with-sum-less-than-or-equal-to-threshold/)

难度：中等

给你一个大小为 <code>m &times; n</code> 的矩阵 `mat` 和一个整数阈值 `threshold`。

请你返回元素总和小于或等于阈值的正方形区域的最大边长；如果没有这样的正方形区域，则返回 **0**。

**示例 1：**

> ![](./assets/img/Question1292.png)
>
> **输入：** mat = \[[1,1,3,2,4,3,2],[1,1,3,2,4,3,2],[1,1,3,2,4,3,2]], threshold = 4
> **输出：** 2
> **解释：** 总和小于或等于 4 的正方形的最大边长为 2，如图所示。

**示例 2：**

> **输入：** mat = \[[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2],[2,2,2,2,2]], threshold = 1
> **输出：** 0

**提示：**

- `m == mat.length`
- `n == mat[i].length`
- `1 <= m, n <= 300`
- <code>0 <= mat[i][j] <= 10<sup>4</sup></code>
- <code>0 <= threshold <= 10<sup>5</sup></code>
