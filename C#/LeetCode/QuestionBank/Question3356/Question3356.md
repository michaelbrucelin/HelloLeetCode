### [3356\. 零数组变换 II](https://leetcode.cn/problems/zero-array-transformation-ii/)

难度：中等

给你一个长度为 `n` 的整数数组 `nums` 和一个二维数组 `queries`，其中 <code>queries[i] = [l<sub>i</sub>, r<sub>i</sub>, val<sub>i</sub>]</code>。

每个 `queries[i]` 表示在 `nums` 上执行以下操作：

- 将 `nums` 中 <code>[l<sub>i</sub>, r<sub>i</sub>]</code> 范围内的每个下标对应元素的值 **最多** 减少 <code>val<sub>i</sub></code>。
- 每个下标的减少的数值可以**独立**选择。

**零数组** 是指所有元素都等于 0 的数组。

返回 `k` 可以取到的 **最小** **非负** 值，使得在 **顺序** 处理前 `k` 个查询后，`nums` 变成 **零数组**。如果不存在这样的 `k`，则返回 -1。

**示例 1：**

> **输入：** nums = [2,0,2], queries = \[[0,2,1],[0,2,1],[1,1,3]]
> **输出：** 2
> **解释：**
>
> - **对于 i = 0（l = 0, r = 2, val = 1）：**
>   - 在下标 `[0, 1, 2]` 处分别减少 `[1, 0, 1]`。
>   - 数组将变为 `[1, 0, 1]`。
> - **对于 i = 1（l = 0, r = 2, val = 1）：**
>   - 在下标 `[0, 1, 2]` 处分别减少 `[1, 0, 1]`。
>   - 数组将变为 `[0, 0, 0]`，这是一个零数组。因此，`k` 的最小值为 2。

**示例 2：**

> **输入：** nums = [4,3,2,1], queries = \[[1,3,2],[0,2,1]]
> **输出：** -1
> **解释：**
>
> - **对于 i = 0（l = 1, r = 3, val = 2）：**
>   - 在下标 `[1, 2, 3]` 处分别减少 `[2, 2, 1]`。
>   - 数组将变为 `[4, 1, 0, 0]`。
> - **对于 i = 1（l = 0, r = 2, val = 1）：**
>   - 在下标 `[0, 1, 2]` 处分别减少 `[1, 1, 0]`。
>   - 数组将变为 `[3, 0, 0, 0]`，这不是一个零数组。

**提示：**

- <code>1 <= nums.length <= 10<sup>5</sup></code>
- <code>0 <= nums[i] <= 5 * 10<sup>5</sup></code>
- <code>1 <= queries.length <= 10<sup>5</sup></code>
- <code>queries[i].length == 3</code>
- <code>0 <= l<sub>i</sub> <= r<sub>i</sub> < nums.length</code>
- <code>1 <= val<sub>i</sub> <= 5</code>
