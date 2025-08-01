### [1857\. 有向图中最大颜色值](https://leetcode.cn/problems/largest-color-value-in-a-directed-graph/)

难度：困难

给你一个 **有向图**，它含有 `n` 个节点和 `m` 条边。节点编号从 `0` 到 `n - 1`。

给你一个字符串 `colors`，其中 `colors[i]` 是小写英文字母，表示图中第 `i` 个节点的 **颜色** （下标从 **0** 开始）。同时给你一个二维数组 `edges`，其中 <code>edges[j] = [a<sub>j</sub>, b<sub>j</sub>]</code> 表示从节点 <code>a<sub>j</sub></code> 到节点 <code>b<sub>j</sub></code> 有一条 **有向边**。

图中一条有效 **路径** 是一个点序列 <code>x<sub>1</sub> -> x<sub>2</sub> -> x<sub>3</sub> -> ... -> x<sub>k</sub></code>，对于所有 `1 <= i < k`，从 <code>x<sub>i</sub></code> 到 <code>x<sub>i+1</sub></code> 在图中有一条有向边。路径的 **颜色值** 是路径中 **出现次数最多** 颜色的节点数目。

请你返回给定图中有效路径里面的 **最大颜色值** **。**如果图中含有环，请返回 `-1`。

**示例 1：**

![](./assets/img/Question1857_01.png)

> **输入：** colors = "abaca", edges = \[[0,1],[0,2],[2,3],[3,4]]
> **输出：** 3
> **解释：** 路径 0 -> 2 -> 3 -> 4 含有 3 个颜色为 `"a" 的节点（上图中的红色节点）。`

**示例 2：**

![](./assets/img/Question1857_02.png)

> **输入：** colors = "a", edges = \[[0,0]]
> **输出：** -1
> **解释：** 从 0 到 0 有一个环。

**提示：**

- `n == colors.length`
- `m == edges.length`
- <code>1 <= n <= 10<sup>5</sup></code>
- <code>0 <= m <= 10<sup>5</sup></code>
- `colors` 只含有小写英文字母
- <code>0 <= a<sub>j</sub>, b<sub>j</sub> < n</code>
