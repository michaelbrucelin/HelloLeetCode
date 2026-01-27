### [3650\. 边反转的最小路径总成本](https://leetcode.cn/problems/minimum-cost-path-with-edge-reversals/)

难度：中等

给你一个包含 `n` 个节点的有向带权图，节点编号从 `0` 到 `n - 1`。同时给你一个数组 `edges`，其中 <code>edges[i] = [u<sub>i</sub>, v<sub>i</sub>, w<sub>i</sub>]</code> 表示一条从节点 <code>u<sub>i</sub></code> 到节点 <code>v<sub>i</sub></code> 的有向边，其成本为 <code>w<sub>i</sub></code>。

每个节点 <code>u<sub>i</sub></code> 都有一个 **最多可使用一次** 的开关：当你到达 <code>u<sub>i</sub></code> 且尚未使用其开关时，你可以对其一条入边 <code>v<sub>i</sub> &rarr; u<sub>i</sub></code> 激活开关，将该边反转为 <code>u<sub>i</sub> &rarr; v<sub>i</sub></code> 并 **立即** 穿过它。

反转仅对那一次移动有效，使用反转边的成本为 <code>2 &times; w<sub>i</sub></code>。

返回从节点 `0` 到达节点 `n - 1` 的 **最小** 总成本。如果无法到达，则返回 -1。

**示例 1:**

**输入:** n = 4, edges = \[[0,1,3],[3,1,1],[2,3,4],[0,2,2]]
**输出:** 5
**解释:**
> ![](./assets/img/Question3650.png)
>
> - 使用路径 <code>0 &rarr; 1</code> (成本 3)。
> - 在节点 1，将原始边 <code>3 &rarr; 1</code> 反转为 <code>1 &rarr; 3</code> 并穿过它，成本为 <code>2 &times; 1 = 2</code>。
> - 总成本为 `3 + 2 = 5`。

**示例 2:**

**输入:** n = 4, edges = \[[0,2,1],[2,1,1],[1,3,1],[2,3,3]]
**输出:** 3
**解释:**
>
> - 不需要反转。走路径 <code>0 &rarr; 2</code> (成本 1)，然后 <code>2 &rarr; 1</code> (成本 1)，再然后 <code>1 &rarr; 3</code> (成本 1)。
> - 总成本为 `1 + 1 + 1 = 3`。

**提示:**

- <code>2 <= n <= 5 &times; 10<sup>4</sup></code>
- <code>1 <= edges.length <= 10<sup>5</sup></code>
- <code>edges[i] = [u<sub>i</sub>, v<sub>i</sub>, w<sub>i</sub>]</code>
- <code>0 <= u<sub>i</sub>, v<sub>i</sub> <= n - 1</code>
- <code>1 <= w<sub>i</sub> <= 1000</code>
