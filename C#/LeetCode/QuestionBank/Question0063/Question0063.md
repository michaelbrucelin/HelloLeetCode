### [63\. 不同路径 II](https://leetcode.cn/problems/unique-paths-ii/)

难度：中等

给定一个 <code>m &times; n</code> 的整数数组 `grid`。一个机器人初始位于 **左上角**（即 `grid[0][0]`）。机器人尝试移动到 **右下角**（即 `grid[m - 1][n - 1]`）。机器人每次只能向下或者向右移动一步。

网格中的障碍物和空位置分别用 `1` 和 `0` 来表示。机器人的移动路径中不能包含 **任何** 有障碍物的方格。

返回机器人能够到达右下角的不同路径数量。

测试用例保证答案小于等于 <code>2 &times; 10<sup>9</sup></code>。

**示例 1：**

![](./assets/img/Question0063_01.jpg)

> **输入：** obstacleGrid = \[[0,0,0],[0,1,0],[0,0,0]]
> **输出：** 2
> **解释：** 3 &times; 3 网格的正中间有一个障碍物。
> 从左上角到右下角一共有 `2` 条不同的路径：
>
> 1. 向右 -> 向右 -> 向下 -> 向下
> 2. 向下 -> 向下 -> 向右 -> 向右

**示例 2：**

![](./assets/img/Question0063_02.jpg)

> **输入：** obstacleGrid = \[[0,1],[0,0]]
> **输出：** 1

**提示：**

- `m == obstacleGrid.length`
- `n == obstacleGrid[i].length`
- `1 <= m, n <= 100`
- `obstacleGrid[i][j]` 为 `0` 或 `1`
