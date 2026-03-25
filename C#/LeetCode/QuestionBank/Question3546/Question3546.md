### [3546\. 等和矩阵分割 I](https://leetcode.cn/problems/equal-sum-grid-partition-i/)

难度：中等

给你一个由正整数组成的 <code>m &times; n</code> 矩阵 `grid`。你的任务是判断是否可以通过 **一条水平或一条垂直分割线** 将矩阵分割成两部分，使得：

- 分割后形成的每个部分都是 **非空** 的。
- 两个部分中所有元素的和 **相等**。

如果存在这样的分割，返回 `true`；否则，返回 `false`。

**示例 1：**

> **输入：** grid = \[[1,4],[2,3]]
> **输出：** true
> **解释：**
> ![](./assets/img/Question3546.jpeg)
> 在第 0 行和第 1 行之间进行水平分割，得到两个非空部分，每部分的元素之和为 5。因此，答案是 `true`。

**示例 2：**

> **输入：** grid = \[[1,3],[2,4]]
> **输出：** false
> **解释：**
> 无论是水平分割还是垂直分割，都无法使两个非空部分的元素之和相等。因此，答案是 `false`。

**提示：**

- <code>1 <= m == grid.length <= 10<sup>5</sup></code>
- <code>1 <= n == grid[i].length <= 10<sup>5</sup></code>
- <code>2 <= m &times; n <= 10<sup>5</sup></code>
- <code>1 <= grid[i][j] <= 10<sup>5</sup></code>
