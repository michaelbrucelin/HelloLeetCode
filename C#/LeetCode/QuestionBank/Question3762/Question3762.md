### [3762\. 使数组元素相等的最小操作次数](https://leetcode.cn/problems/minimum-operations-to-equalize-subarrays/)

难度：困难

给你一个整数数组 `nums` 和一个整数 `k`。

在一次操作中，你可以恰好将 `nums` 中的某个元素 **增加或减少** `k`。

还给定一个二维整数数组 `queries`，其中每个 <code>queries[i] = [l<sub>i</sub>, r<sub>i</sub>]</code>。

对于每个查询，找到将 **子数组** <code>nums[l<sub>i</sub>..r<sub>i</sub>]</code> 中的 **所有** 元素变为相等所需的 **最小** 操作次数。如果无法实现，返回 `-1`。

返回一个数组 `ans`，其中 `ans[i]` 是第 `i` 个查询的答案。

**子数组** 是数组中一个连续、**非空** 的元素序列。

**示例 1：**

> **输入：** nums = [1,4,7], k = 3, queries = \[[0,1],[0,2]]
> **输出：** [1,2]
> **解释：**
> 一种最优操作方式：
>
> | `i` | <code>[l<sub>i</sub>, r<sub>i</sub>]</code> | <code>nums[l<sub>i</sub>..r<sub>i</sub>]</code> | 可行性 | 操作 | 最终<br><code>nums[l<sub>i</sub>..r<sub>i</sub>]</code> | `ans[i]` |
> | --- | --- | --- | --- | --- | --- | --- |
> | 0 | [0, 1] | [1, 4] | 是 | `nums[0] + k = 1 + 3 = 4 = nums[1]` | [4, 4] | 1 |
> | 1 | [0, 2] | [1, 4, 7] | 是 | `nums[0] + k = 1 + 3 = 4 = nums[1]`<br>`nums[2] - k = 7 - 3 = 4 = nums[1]` | [4, 4, 4] | 2 |
>
> 因此，`ans = [1, 2]`。

**示例 2：**

> **输入：** nums = [1,2,4], k = 2, queries = \[[0,2],[0,0],[1,2]]
> **输出：** [-1,0,1]
> **解释：**
> 一种最优操作方式：
>
> | `i` | <code>[l<sub>i</sub>, r<sub>i</sub>]</code> | <code>nums[l<sub>i</sub>..r<sub>i</sub>]</code> | 可行性 | 操作 | 最终<br><code>nums[l<sub>i</sub>..r<sub>i</sub>]</code> | `ans[i]` |
> | --- | --- | --- | --- | --- | --- | --- |
> | 0 | [0, 2] | [1, 2, 4] | 否 | \- | [1, 2, 4] | \-1 |
> | 1 | [0, 0] | [1] | 是 | 已相等 | [1] | 0 |
> | 2 | [1, 2] | [2, 4] | 是 | `nums[1] + k = 2 + 2 = 4 = nums[2]` | [4, 4] | 1 |
>
> 因此，`ans = [-1, 0, 1]`。

**提示：**

- <code>1 <= n == nums.length <= 4 &times; 10<sup>4</sup></code>
- <code>1 <= nums[i] <= 10<sup>9</sup></code>
- <code>1 <= k <= 10<sup>9</sup></code>
- <code>1 <= queries.length <= 4 &times; 10<sup>4</sup></code>
- <code>queries[i] = [l<sub>i</sub>, r<sub>i</sub>]</code>
- <code>0 <= l<sub>i</sub> <= r<sub>i</sub> <= n - 1</code>
