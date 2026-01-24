### [2482\. 行和列中一和零的差值](https://leetcode.cn/problems/difference-between-ones-and-zeros-in-row-and-column/)

难度：中等

给你一个下标从 **0** 开始的 <code>m &times; n</code> 二进制矩阵 `grid`。

我们按照如下过程，定义一个下标从 **0** 开始的 <code>m &times; n</code> 差值矩阵 `diff`：

- 令第 `i` 行一的数目为 <code>onesRow<sub>i</sub></code>。
- 令第 `j` 列一的数目为 <code>onesCol<sub>j</sub></code>。
- 令第 `i` 行零的数目为 <code>zerosRow<sub>i</sub></code>。
- 令第 `j` 列零的数目为 <code>zerosCol<sub>j</sub></code>。
- <code>diff[i][j] = onesRow<sub>i</sub> + onesCol<sub>j</sub> - zerosRow<sub>i</sub> - zerosCol<sub>j</sub></code>

请你返回差值矩阵 `diff`。

**示例 1：**

> ![](./assets/img/Question2482_01.png)
>
> **输入：** grid = \[[0,1,1],[1,0,1],[0,0,1]]
> **输出：** \[[0,0,4],[0,0,4],[-2,-2,2]]
> **解释：**
>
> - <code>diff[0][0] = onesRow<sub>0</sub> + onesCol<sub>0</sub> - zerosRow<sub>0</sub> - zerosCol<sub>0</sub> = 2 + 1 - 1 - 2 = 0</code>
> - <code>diff[0][1] = onesRow<sub>0</sub> + onesCol<sub>1</sub> - zerosRow<sub>0</sub> - zerosCol<sub>1</sub> = 2 + 1 - 1 - 2 = 0</code>
> - <code>diff[0][2] = onesRow<sub>0</sub> + onesCol<sub>2</sub> - zerosRow<sub>0</sub> - zerosCol<sub>2</sub> = 2 + 3 - 1 - 0 = 4</code>
> - <code>diff[1][0] = onesRow<sub>1</sub> + onesCol<sub>0</sub> - zerosRow<sub>1</sub> - zerosCol<sub>0</sub> = 2 + 1 - 1 - 2 = 0</code>
> - <code>diff[1][1] = onesRow<sub>1</sub> + onesCol<sub>1</sub> - zerosRow<sub>1</sub> - zerosCol<sub>1</sub> = 2 + 1 - 1 - 2 = 0</code>
> - <code>diff[1][2] = onesRow<sub>1</sub> + onesCol<sub>2</sub> - zerosRow<sub>1</sub> - zerosCol<sub>2</sub> = 2 + 3 - 1 - 0 = 4</code>
> - <code>diff[2][0] = onesRow<sub>2</sub> + onesCol<sub>0</sub> - zerosRow<sub>2</sub> - zerosCol<sub>0</sub> = 1 + 1 - 2 - 2 = -2</code>
> - <code>diff[2][1] = onesRow<sub>2</sub> + onesCol<sub>1</sub> - zerosRow<sub>2</sub> - zerosCol<sub>1</sub> = 1 + 1 - 2 - 2 = -2</code>
> - <code>diff[2][2] = onesRow<sub>2</sub> + onesCol<sub>2</sub> - zerosRow<sub>2</sub> - zerosCol<sub>2</sub> = 1 + 3 - 2 - 0 = 2</code>

**示例 2：**

> ![](./assets/img/Question2482_02.png)
>
> **输入：** grid = \[[1,1,1],[1,1,1]]
> **输出：** \[[5,5,5],[5,5,5]]
> **解释：**
>
> - <code>diff[0][0] = onesRow<sub>0</sub> + onesCol<sub>0</sub> - zerosRow<sub>0</sub> - zerosCol<sub>0</sub> = 3 + 2 - 0 - 0 = 5</code>
> - <code>diff[0][1] = onesRow<sub>0</sub> + onesCol<sub>1</sub> - zerosRow<sub>0</sub> - zerosCol<sub>1</sub> = 3 + 2 - 0 - 0 = 5</code>
> - <code>diff[0][2] = onesRow<sub>0</sub> + onesCol<sub>2</sub> - zerosRow<sub>0</sub> - zerosCol<sub>2</sub> = 3 + 2 - 0 - 0 = 5</code>
> - <code>diff[1][0] = onesRow<sub>1</sub> + onesCol<sub>0</sub> - zerosRow<sub>1</sub> - zerosCol<sub>0</sub> = 3 + 2 - 0 - 0 = 5</code>
> - <code>diff[1][1] = onesRow<sub>1</sub> + onesCol<sub>1</sub> - zerosRow<sub>1</sub> - zerosCol<sub>1</sub> = 3 + 2 - 0 - 0 = 5</code>
> - <code>diff[1][2] = onesRow<sub>1</sub> + onesCol<sub>2</sub> - zerosRow<sub>1</sub> - zerosCol<sub>2</sub> = 3 + 2 - 0 - 0 = 5</code>

**提示：**

- `m == grid.length`
- `n == grid[i].length`
- <code>1 <= m, n <= 10<sup>5</sup></code>
- <code>1 <= m &times; n <= 10<sup>5</sup></code>
- `grid[i][j]` 要么是 `0`，要么是 `1`。
