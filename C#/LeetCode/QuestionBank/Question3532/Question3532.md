### [3532\. 针对图的路径存在性查询 I](https://leetcode.cn/problems/path-existence-queries-in-a-graph-i/)

难度：中等

给你一个整数 `n`，表示图中的节点数量，这些节点按从 `0` 到 `n - 1` 编号。

同时给你一个长度为 `n` 的整数数组 `nums`，该数组按 **非递减** 顺序排序，以及一个整数 `maxDiff`。

如果满足 `|nums[i] - nums[j]| <= maxDiff`（即 `nums[i]` 和 `nums[j]` 的 **绝对差** 至多为 `maxDiff`），则节点 `i` 和节点 `j` 之间存在一条 **无向边**。

此外，给你一个二维整数数组 `queries`。对于每个 <code>queries[i] = [u<sub>i</sub>, v<sub>i</sub>]</code>，需要判断节点 <code>u<sub>i</sub></code> 和 <code>v<sub>i</sub></code> 之间是否存在路径。

返回一个布尔数组 `answer`，其中 `answer[i]` 等于 `true` 表示在第 `i` 个查询中节点 <code>u<sub>i</sub></code> 和 <code>v<sub>i</sub></code> 之间存在路径，否则为 `false`。

**示例 1：**

> **输入:** n = 2, nums = [1,3], maxDiff = 1, queries = \[[0,0],[0,1]]
> **输出:** [true,false]
> **解释:**
>
> - 查询 `[0,0]`：节点 0 有一条到自己的显然路径。
> - 查询 `[0,1]`：节点 0 和节点 1 之间没有边，因为 `|nums[0] - nums[1]| = |1 - 3| = 2`，大于 `maxDiff`。
> - 因此，在处理完所有查询后，最终答案为 `[true, false]`。

**示例 2：**

> **输入:** n = 4, nums = [2,5,6,8], maxDiff = 2, queries = \[[0,1],[0,2],[1,3],[2,3]]
> **输出:** [false,false,true,true]
> **解释:**
> 生成的图如下：
> ![](./assets/img/Question3532.png)
>
> - 查询 `[0,1]`：节点 0 和节点 1 之间没有边，因为 `|nums[0] - nums[1]| = |2 - 5| = 3`，大于 `maxDiff`。
> - 查询 `[0,2]`：节点 0 和节点 2 之间没有边，因为 `|nums[0] - nums[2]| = |2 - 6| = 4`，大于 `maxDiff`。
> - 查询 `[1,3]`：节点 1 和节点 3 之间存在路径通过节点 2，因为 `|nums[1] - nums[2]| = |5 - 6| = 1` 和 `|nums[2] - nums[3]| = |6 - 8| = 2`，都小于等于 `maxDiff`。
> - 查询 `[2,3]`：节点 2 和节点 3 之间有一条边，因为 `|nums[2] - nums[3]| = |6 - 8| = 2`，等于 `maxDiff`。
> - 因此，在处理完所有查询后，最终答案为 `[false, false, true, true]`。

**提示：**

- <code>1 <= n == nums.length <= 10<sup>5</sup></code>
- <code>0 <= nums[i] <= 10<sup>5</sup></code>
- `nums` 按 **非递减** 顺序排序。
- <code>0 <= maxDiff <= 10<sup>5</sup></code>
- <code>1 <= queries.length <= 10<sup>5</sup></code>
- <code>queries[i] == [u<sub>i</sub>, v<sub>i</sub>]</code>
- <code>0 <= u<sub>i</sub>, v<sub>i</sub> < n</code>
