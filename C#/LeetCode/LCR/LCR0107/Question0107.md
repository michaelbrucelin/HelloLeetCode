### [LCR 107. 01 矩阵](https://leetcode.cn/problems/2bCMpM/)

难度：中等

给定一个由 `0` 和 `1` 组成的矩阵 `mat`，请输出一个大小相同的矩阵，其中每一个格子是 `mat` 中对应位置元素到最近的 `0` 的距离。

两个相邻元素间的距离为 `1`。

**示例 1：**

> ![](./assets/img/Question0107_01.png)
> **输入：** mat = \[[0,0,0],[0,1,0],[0,0,0]]
> **输出：** \[[0,0,0],[0,1,0],[0,0,0]]

**示例 2：**

> ![](./assets/img/Question0107_02.png)
> **输入：** mat = \[[0,0,0],[0,1,0],[1,1,1]]
> **输出：** \[[0,0,0],[0,1,0],[1,2,1]]

**提示：**

- `m == mat.length`
- `n == mat[i].length`
- <code>1 <= m, n <= 10<sup>4</sup></code>
- <code>1 <= m &times; n <= 10<sup>4</sup></code>
- `mat[i][j] is either 0 or 1.`
- `mat` 中至少有一个 `0` 

**注意：** 本题与主站 542 题相同：[https://leetcode.cn/problems/01-matrix/](https://leetcode.cn/problems/01-matrix/)
