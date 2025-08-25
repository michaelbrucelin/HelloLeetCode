### [498\. 对角线遍历](https://leetcode.cn/problems/diagonal-traverse/)

难度：中等

给你一个大小为 <code>m &times; n</code> 的矩阵 `mat`，请以对角线遍历的顺序，用一个数组返回这个矩阵中的所有元素。

**示例 1：**

![](./assets/img/Question0498.jpg)

> **输入：** mat = \[[1,2,3],[4,5,6],[7,8,9]]
> **输出：** [1,2,4,7,5,3,6,8,9]

**示例 2：**

> **输入：** mat = \[[1,2],[3,4]]
> **输出：** [1,2,3,4]

**提示：**

- `m == mat.length`
- `n == mat[i].length`
- <code>1 <= m, n <= 10<sup>4</sup></code>
- <code>1 <= m &times; n <= 10<sup>4</sup></code>
- <code>-10<sup>5</sup> <= mat[i][j] <= 10<sup>5</sup></code>
