### [2536\. 子矩阵元素加 1](https://leetcode.cn/problems/increment-submatrices-by-one/)

难度：中等

给你一个正整数 `n`，表示最初有一个 <code>n &times; n</code> 、下标从 **0** 开始的整数矩阵 `mat`，矩阵中填满了 0。

另给你一个二维整数数组 `query`。针对每个查询 <code>query[i] = [row1<sub>i</sub>, col1<sub>i</sub>, row2<sub>i</sub>, col2<sub>i</sub>]</code>，请你执行下述操作：

- 找出 **左上角** 为 <code>(row1<sub>i</sub>, col1<sub>i</sub>)</code> 且 **右下角** 为 <code>(row2<sub>i</sub>, col2<sub>i</sub>)</code> 的子矩阵，将子矩阵中的 **每个元素** 加 `1`。也就是给所有满足 <code>row1<sub>i</sub> <= x <= row2<sub>i</sup></code> 和 <code>col1<sub>i</sub> <= y <= col2<sub>i</sup></code> 的 `mat[x][y]` 加 `1`。

返回执行完所有操作后得到的矩阵 `mat`。

**示例 1：**

![](./assets/img/Question2536_01.png)

> **输入：** n = 3, queries = \[[1,1,2,2],[0,0,1,1]]
> **输出：** \[[1,1,0],[1,2,1],[0,1,1]]
> **解释：** 上图所展示的分别是：初始矩阵、执行完第一个操作后的矩阵、执行完第二个操作后的矩阵。
>
> - 第一个操作：将左上角为 (1, 1) 且右下角为 (2, 2) 的子矩阵中的每个元素加 1。 
> - 第二个操作：将左上角为 (0, 0) 且右下角为 (1, 1) 的子矩阵中的每个元素加 1。 

**示例 2：**

![](./assets/img/Question2536_02.png)

> **输入：** n = 2, queries = \[[0,0,1,1]]
> **输出：** \[[1,1],[1,1]]
> **解释：** 上图所展示的分别是：初始矩阵、执行完第一个操作后的矩阵。 
>
> - 第一个操作：将矩阵中的每个元素加 1。

**提示：**

- `1 <= n <= 500`
- <code>1 <= queries.length <= 10<sup>4</sup></code>
- <code>0 <= row1<sub>i</sub> <= row2<sub>i</sub> < n</code>
- <code>0 <= col1<sub>i</sub> <= col2<sub>i</sub> < n</code>
