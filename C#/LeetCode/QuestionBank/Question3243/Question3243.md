### [3243\. 新增道路查询后的最短距离 I](https://leetcode.cn/problems/shortest-distance-after-road-addition-queries-i/)

难度：中等

给你一个整数 `n` 和一个二维整数数组 `queries`。

有 `n` 个城市，编号从 `0` 到 `n - 1`。初始时，每个城市 `i` 都有一条**单向**道路通往城市 `i + 1`（ `0 <= i < n - 1`）。

<code>queries[i] = [u<sub>i</sub>, v<sub>i</sub>]</code> 表示新建一条从城市 <code>u<sub>i</sub></code> 到城市 <code>v<sub>i</sub></code> 的**单向**道路。每次查询后，你需要找到从城市 `0` 到城市 `n - 1` 的**最短路径**的**长度**。

返回一个数组 `answer`，对于范围 `[0, queries.length - 1]` 中的每个 `i`，`answer[i]` 是处理完**前** `i + 1` 个查询后，从城市 `0` 到城市 `n - 1` 的最短路径的_长度_。

**示例 1：**

> **输入：** n = 5, queries = \[[2, 4], [0, 2], [0, 4]]
> **输出：** [3, 2, 1]
> **解释：**
> ![](./assets/img/Question3243_01.jpg)
> 新增一条从 2 到 4 的道路后，从 0 到 4 的最短路径长度为 3。
> ![](./assets/img/Question3243_02.jpg)
> 新增一条从 0 到 2 的道路后，从 0 到 4 的最短路径长度为 2。
> ![](./assets/img/Question3243_03.jpg)
> 新增一条从 0 到 4 的道路后，从 0 到 4 的最短路径长度为 1。

**示例 2：**

> **输入：** n = 4, queries = \[[0, 3], [0, 2]]
> **输出：** [1, 1]
> **解释：**
> ![](./assets/img/Question3243_04.jpg)
> 新增一条从 0 到 3 的道路后，从 0 到 3 的最短路径长度为 1。
> ![](./assets/img/Question3243_05.jpg)
> 新增一条从 0 到 2 的道路后，从 0 到 3 的最短路径长度仍为 1。

**提示：**

- `3 <= n <= 500`
- `1 <= queries.length <= 500`
- `queries[i].length == 2`
- `0 <= queries[i][0] < queries[i][1] < n`
- `1 < queries[i][1] - queries[i][0]`
- 查询中没有重复的道路。
