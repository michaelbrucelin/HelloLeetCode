### [3070\. 元素和小于等于 k 的子矩阵的数目](https://leetcode.cn/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/)

难度：中等

给你一个下标从 **0** 开始的整数矩阵 `grid` 和一个整数 `k`。

返回包含 `grid` 左上角元素、元素和小于或等于 `k` 的 **子矩阵[^1]** 的数目。

**示例 1：**

> ![](./assets/img/Question3070_01.png)
>
> **输入：** grid = \[[7,6,3],[6,6,1]], k = 18
> **输出：** 4
> **解释：** 如上图所示，只有 4 个子矩阵满足：包含 grid 的左上角元素，并且元素和小于或等于 18。

**示例 2：**

> ![](./assets/img/Question3070_02.png)
>
> **输入：** grid = \[[7,2,9],[1,5,0],[2,6,6]], k = 20
> **输出：** 6
> **解释：** 如上图所示，只有 6 个子矩阵满足：包含 grid 的左上角元素，并且元素和小于或等于 20。

**提示：**

- `m == grid.length`
- `n == grid[i].length`
- `1 <= n, m <= 1000`
- `0 <= grid[i][j] <= 1000`
- <code>1 <= k <= 10<sup>9</sup></code>

[^1]: 子矩阵 <code>(x<sub>1</sub>, y<sub>1</sub>, x<sub>2</sub>, y<sub>2</sub>)</code> 是一个通过选择所有 <code>x<sub>1</sub> <= x <= x<sub>2</sub></code> 且 <code>y<sub>1</sub> <= y <= y<sub>2</sub></code> 的元素形成的矩阵。
