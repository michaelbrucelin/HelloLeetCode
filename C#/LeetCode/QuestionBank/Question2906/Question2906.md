### [2906\. 构造乘积矩阵](https://leetcode.cn/problems/construct-product-matrix/)

难度：中等

给你一个下标从 **0** 开始、大小为 <code>n &times; m</code> 的二维整数矩阵 `grid`，定义一个下标从 **0** 开始、大小为 <code>n &times; m</code> 的的二维矩阵 `p`。如果满足以下条件，则称 `p` 为 `grid` 的 **乘积矩阵**：

- 对于每个元素 `p[i][j]`，它的值等于除了 `grid[i][j]` 外所有元素的乘积。乘积对 `12345` 取余数。

返回 `grid` 的乘积矩阵。

**示例 1：**

> **输入：** grid = \[[1,2],[3,4]]
> **输出：** \[[24,12],[8,6]]
> **解释：**
> p[0][0] = grid[0][1] &times; grid[1][0] &times; grid[1][1] = 2 &times; 3 &times; 4 = 24
> p[0][1] = grid[0][0] &times; grid[1][0] &times; grid[1][1] = 1 &times; 3 &times; 4 = 12
> p[1][0] = grid[0][0] &times; grid[0][1] &times; grid[1][1] = 1 &times; 2 &times; 4 = 8
> p[1][1] = grid[0][0] &times; grid[0][1] &times; grid[1][0] = 1 &times; 2 &times; 3 = 6
> 所以答案是 \[[24,12],[8,6]]。

**示例 2：**

> **输入：** grid = \[[12345],[2],[1]]
> **输出：** \[[2],[0],[0]]
> **解释：**
> p[0][0] = grid[0][1] &times; grid[0][2] = 2     &times; 1 = 2
> p[0][1] = grid[0][0] &times; grid[0][2] = 12345 &times; 1 = 12345. 12345 % 12345 = 0，所以 p[0][1] = 0
> p[0][2] = grid[0][0] &times; grid[0][1] = 12345 &times; 2 = 24690. 24690 % 12345 = 0，所以 p[0][2] = 0
> 所以答案是 \[[2],[0],[0]]。

**提示：**

- <code>1 <= n == grid.length <= 10<sup>5</sup></code>
- <code>1 <= m == grid[i].length <= 10<sup>5</sup></code>
- <code>2 <= n &times; m <= 10<sup>5</sup></code>
- <code>1 <= grid[i][j] <= 10<sup>9</sup></code>
