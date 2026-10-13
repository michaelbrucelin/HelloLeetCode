### [3715\. 完全平方数的祖先个数总和](https://leetcode.cn/problems/sum-of-perfect-square-ancestors/)

难度：困难

给你一个整数 `n`，以及一棵以节点 0 为根、包含 `n` 个节点（编号从 0 到 `n - 1`）的无向树。该树由一个长度为 `n - 1` 的二维数组 `edges` 表示，其中 <code>edges[i] = [u<sub>i</sub>, v<sub>i</sub>]</code> 表示在节点 <code>u<sub>i</sub></code> 与节点 <code>v<sub>i</sub></code> 之间有一条无向边。

同时给你一个整数数组 `nums`，其中 `nums[i]` 是分配给节点 `i` 的正整数。

定义值 <code>t<sub>i</sub></code> 为：节点 `i` 的 **祖先** 节点中，满足乘积 <code>nums[i] &times; nums[ancestor]</code> 为 **完全平方数** 的祖先个数。

请返回所有节点 `i`（范围为 `[1, n - 1]`）的 <code>t<sub>i</sub></code> 之和。

**说明**：

- 在有根树中，节点 `i` 的**祖先**是指从节点 `i` 到根节点 0 的路径上、**不包括** `i` 本身的所有节点。
- **完全平方数**是可以表示为某个整数与其自身乘积的数，例如 `1、4、9、16`。

**示例 1：**

> **输入：** n = 3, edges = \[[0,1],[1,2]], nums = [2,8,2]
> **输出：** 3
> **解释：**
>
> | **`i`** | **祖先** | **<code>nums[i] &times; nums[ancestor]</code>** | 平方数检查 | **<code>t<sub>i</sub></code>** |
> | -- | -- | -- | -- | -- |
> | 1 | [0] | <code>nums[1] &times; nums[0] = 8 &times; 2 = 16</code> | 16 是完全平方数 | 1 |
> | 2 | [1, 0] | <code>nums[2] &times; nums[1] = 2 &times; 8 = 16</code> <br/> <code>nums[2] &times; nums[0] = 2 &times; 2 = 4</code> | 4 和 16 都是完全平方数 | 2 |
>
> 因此，所有非根节点的有效祖先配对总数为 `1 + 2 = 3`。

**示例 2：**

> **输入：** n = 3, edges = \[[0,1],[0,2]], nums = [1,2,4]
> **输出：** 1
> **解释：**
>
> | **`i`** | **祖先** | **<code>nums[i] &times; nums[ancestor]<code/>** | 平方数检查 | **<code>t<sub>i</sub></code>** |
> | -- | -- | -- | -- | -- |
> | 1 | [0] | <code>nums[1] &times; nums[0] = 2 &times; 1 = 2</code> | 2 **不是** 完全平方数 | 0 |
> | 2 | [0] | <code>nums[2] &times; nums[0] = 4 &times; 1 = 4</code> | 4 是完全平方数 | 1 |
>
> 因此，所有非根节点的有效祖先配对总数为 1。

**示例 3：**

> **输入：** n = 4, edges = \[[0,1],[0,2],[1,3]], nums = [1,2,9,4]
> **输出：** 2
> **解释：**
>
> | **`i`** | **祖先** | **nums[i] &times; nums[ancestor]<code/>** | 平方数检查 | **<code>t<sub>i</sub></code>** |
> | -- | -- | -- | -- | -- |
> | 1 | [0] | <code>nums[1] &times; nums[0] = 2 &times; 1 = 2</code> | 2 **不是** 完全平方数 | 0 |
> | 2 | [0] | <code>nums[2] &times; nums[0] = 9 &times; 1 = 9</code> | 9 是完全平方数 | 1 |
> | 3 | [1, 0] | <code>nums[3] &times; nums[1] = 4 &times; 2 = 8</code> <br/> <code>nums[3] &times; nums[0] = 4 &times; 1 = 4</code> | 只有 4 是完全平方数 | 1 |
>
> 因此，所有非根节点的有效祖先配对总数为 `0 + 1 + 1 = 2`。

**提示：**

- <code>1 <= n <= 10<sup>5</sup></code>
- `edges.length == n - 1`
- <code>edges[i] = [u<sub>i</sub>, v<sub>i</sub>]</code>
- <code>0 <= u<sub>i</sub>, v<sub>i</sub> <= n - 1</code>
- `nums.length == n`
- <code>1 <= nums[i] <= 10<sup>5</sup></code>
- 输入保证 `edges` 表示一棵有效的树。
