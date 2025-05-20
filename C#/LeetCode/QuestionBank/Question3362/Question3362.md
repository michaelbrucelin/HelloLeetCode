### [3362\. 零数组变换 III](https://leetcode.cn/problems/zero-array-transformation-iii/)

难度：中等

给你一个长度为 `n` 的整数数组 `nums` 和一个二维数组 `queries`，其中 `queries[i] = [l<sub>i</sub>, r<sub>i</sub>]`。

每一个 `queries[i]` 表示对于 `nums` 的以下操作：

- 将 `nums` 中下标在范围 <code>[l<sub>i</sub>, r<sub>i</sub>]</code> 之间的每一个元素 **最多** 减少 1。
- 坐标范围内每一个元素减少的值相互 **独立**。

**零数组** 指的是一个数组里所有元素都等于 0。

请你返回 **最多** 可以从 `queries` 中删除多少个元素，使得 `queries` 中剩下的元素仍然能将 `nums` 变为一个 **零数组**。如果无法将 `nums` 变为一个 **零数组**，返回 -1。

**示例 1：**

> **输入：** nums = [2,0,2], queries = \[[0,2],[0,2],[1,1]]
> **输出：** 1
> **解释：**
> 删除 `queries[2]` 后，`nums` 仍然可以变为零数组。
>
> - 对于 `queries[0]`，将 `nums[0]` 和 `nums[2]` 减少 1，将 `nums[1]` 减少 0。
> - 对于 `queries[1]`，将 `nums[0]` 和 `nums[2]` 减少 1，将 `nums[1]` 减少 0。

**示例 2：**

> **输入：** nums = [1,1,1,1], queries = \[[1,3],[0,2],[1,3],[1,2]]
> **输出：** 2
> **解释：**
> 可以删除 `queries[2]` 和 `queries[3]`。

**示例 3：**

> **输入：** nums = [1,2,3,4], queries = \[[0,3]]
> **输出：** -1
> **解释：**
> `nums` 无法通过 `queries` 变成零数组。

**提示：**

- <code>1 <= nums.length <= 10<sup>5</sup></code>
- <code>0 <= nums[i] <= 10<sup>5</sup></code>
- <code>1 <= queries.length <= 10<sup>5</sup></code>
- <code>queries[i].length == 2</code>
- <code>0 <= l<sub>i</sub> <= r<sub>i</sub> < nums.length</code>
