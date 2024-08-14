### [3152\. 特殊数组 II](https://leetcode.cn/problems/special-array-ii/)

难度：中等

如果数组的每一对相邻元素都是两个奇偶性不同的数字，则该数组被认为是一个 **特殊数组**。

周洋哥有一个整数数组 `nums` 和一个二维整数矩阵 `queries`，对于 `queries[i] = [from_i, to_i]`，请你帮助周洋哥检查子数组 `nums[from_i..to_i]` 是不是一个 **特殊数组**。

返回布尔数组 `answer`，如果 `nums[from_i..to_i]` 是特殊数组，则 `answer[i]` 为 `true` ，否则，`answer[i]` 为 `false`。

**示例 1：**

> **输入：** nums = [3,4,1,2,6], queries = [[0,4]]
> **输出：** [false]
> **解释：**
> 子数组是 `[3,4,1,2,6]`。2 和 6 都是偶数。

**示例 2：**

> **输入：** nums = [4,3,1,6], queries = [[0,2],[2,3]]
> **输出：** [false,true]
> **解释：**
>
> 1. 子数组是 `[4,3,1]`。3 和 1 都是奇数。因此这个查询的答案是 `false`。
> 2. 子数组是 `[1,6]`。只有一对：`(1,6)`，且包含了奇偶性不同的数字。因此这个查询的答案是 `true`。

**提示：**

- `1 <= nums.length <= 10^5`
- `1 <= nums[i] <= 10^5`
- `1 <= queries.length <= 10^5`
- `queries[i].length == 2`
- `0 <= queries[i][0] <= queries[i][1] <= nums.length - 1`
