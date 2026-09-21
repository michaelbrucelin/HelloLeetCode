### [3525\. 求出数组的 X 值 II](https://leetcode.cn/problems/find-x-value-of-array-ii/)

难度：困难

给你一个由 **正整数** 组成的数组 `nums` 和一个 **正整数** `k`。同时给你一个二维数组 `queries`，其中 <code>queries[i] = [index<sub>i</sub>, value<sub>i</sub>, start<sub>i</sub>, x<sub>i</sub>]</code>。

你可以对 `nums` 执行 **一次** 操作，移除 `nums` 的任意 **后缀**，使得 `nums` 仍然**非空**。

给定一个 `x`，`nums` 的 **x值** 定义为执行以上操作后剩余元素的 **乘积** 除以 `k` 的 **余数** 为 `x` 的方案数。

对于 `queries` 中的每个查询，你需要执行以下操作，然后确定 <code>x<sub>i</sub></code> 对应的 `nums` 的 **x值**：

- 将 <code>nums[index<sub>i</sub>]</code> 更新为 <code>value<sub>i</sub></code>。仅这个更改在接下来的所有查询中保留。
- **移除** 前缀 <code>nums[0..(start<sub>i</sub> - 1)]</code>（`nums[0..(-1)]` 表示 **空前缀** ）。

返回一个长度为 `queries.length` 的数组 `result`，其中 `result[i]` 是第 `i` 个查询的答案。

数组的一个 **前缀** 是从数组开始位置到任意位置的子数组。

数组的一个 **后缀** 是从数组中任意位置开始直到结束的子数组。

**子数组** 是数组中一段连续的元素序列。

**注意**：操作中所选的前缀或后缀可以是 **空的**。

**注意**：x值在本题中与问题 I 有不同的定义。

**示例 1：**

> **输入：** nums = [1,2,3,4,5], k = 3, queries = \[[2,2,0,2],[3,3,3,0],[0,1,0,1]]
> **输出：** [2,2,2]
> **解释：**
>
> - 对于查询 0，`nums` 变为 `[1, 2, 2, 4, 5]`。移除空前缀后，可选操作包括：
>     - 移除后缀 `[2, 4, 5]`，`nums` 变为 `[1, 2]`。
>     - 不移除任何后缀。`nums` 保持为 `[1, 2, 2, 4, 5]`，乘积为 80，对 3 取余为 2。
> - 对于查询 1，`nums` 变为 `[1, 2, 2, 3, 5]`。移除前缀 `[1, 2, 2]` 后，可选操作包括：
>     - 不移除任何后缀，`nums` 为 `[3, 5]`。
>     - 移除后缀 `[5]`，`nums` 为 `[3]`。
> - 对于查询 2，`nums` 保持为 `[1, 2, 2, 3, 5]`。移除空前缀后。可选操作包括：
>     - 移除后缀 `[2, 2, 3, 5]`。`nums` 为 `[1]`。
>     - 移除后缀 `[3, 5]`。`nums` 为 `[1, 2, 2]`。

**示例 2：**

> **输入：** nums = [1,2,4,8,16,32], k = 4, queries = \[[0,2,0,2],[0,2,0,1]]
> **输出：** [1,0]
> **解释：**
>
> - 对于查询 0，`nums` 变为 `[2, 2, 4, 8, 16, 32]`。唯一可行的操作是：
>     - 移除后缀 `[2, 4, 8, 16, 32]`。
> - 对于查询 1，`nums` 仍为 `[2, 2, 4, 8, 16, 32]`。没有任何操作能使余数为 1。

**示例 3：**

> **输入：** nums = [1,1,2,1,1], k = 2, queries = \[[2,1,0,1]]
> **输出：** [5]

**提示：**

- <code>1 <= nums[i] <= 10<sup>9</sup></code>
- <code>1 <= nums.length <= 10<sup>5</sup></code>
- `1 <= k <= 5`
- <code>1 <= queries.length <= 2 &times; 10<sup>4</sup></code>
- <code>queries[i] == [index<sub>i</sub>, value<sub>i</sub>, start<sub>i</sub>, x<sub>i</sub>]</code>
- <code>0 <= index<sub>i</sub> <= nums.length - 1</code>
- <code>1 <= value<sub>i</sub> <= 10<sup>9</sup></code>
- <code>0 <= start<sub>i</sub> <= nums.length - 1</code>
- <code>0 <= x<sub>i</sub> <= k - 1</code>
