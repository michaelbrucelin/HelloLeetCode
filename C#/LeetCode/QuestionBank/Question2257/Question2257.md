### [2257\. 统计网格图中没有被保卫的格子数](https://leetcode.cn/problems/count-unguarded-cells-in-the-grid/)

难度：中等

给你两个整数 `m` 和 `n` 表示一个下标从 **0** 开始的 <code>m &times; n</code> 网格图。同时给你两个二维整数数组 `guards` 和 `walls`，其中 <code>guards[i] = [row<sub>i</sub>, col<sub>i</sub>]</code> 且 <code>walls[j] = [row<sub>j</sub>, col<sub>j</sub>]</code>，分别表示第 `i` 个警卫和第 `j` 座墙所在的位置。

一个警卫能看到 4 个坐标轴方向（即东、南、西、北）的 **所有** 格子，除非他们被一座墙或者另外一个警卫 **挡住** 了视线。如果一个格子能被 **至少** 一个警卫看到，那么我们说这个格子被 **保卫** 了。

请你返回空格子中，有多少个格子是 **没被保卫** 的。

**示例 1：**

![](./assets/img/Question2257_01.png)

> **输入：** m = 4, n = 6, guards = \[[0,0],[1,1],[2,3]], walls = \[[0,1],[2,2],[1,4]]
> **输出：** 7
> **解释：** 上图中，被保卫和没有被保卫的格子分别用红色和绿色表示。
> 总共有 7 个没有被保卫的格子，所以我们返回 7。

**示例 2：**

![](./assets/img/Question2257_02.png)

> **输入：** m = 3, n = 3, guards = \[[1,1]], walls = \[[0,1],[1,0],[2,1],[1,2]]
> **输出：** 4
> **解释：** 上图中，没有被保卫的格子用绿色表示。
> 总共有 4 个没有被保卫的格子，所以我们返回 4。

**提示：**

- <code>1 <= m, n <= 10<sup>5</sup></code>
- <code>2 <= m &times; n <= 10<sup>5</sup></code>
- <code>1 <= guards.length, walls.length <= 5 &times; 10<sup>4</sup></code>
- <code>2 <= guards.length + walls.length <= m &times; n</code>
- `guards[i].length == walls[j].length == 2`
- <code>0 <= row<sub>i</sub>, row<sub>j</sub> < m</code>
- <code>0 <= col<sub>i</sub>, col<sub>j</sub> < n</code>
- `guards` 和 `walls` 中所有位置 **互不相同**。
