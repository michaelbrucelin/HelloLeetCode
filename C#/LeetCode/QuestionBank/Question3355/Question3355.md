### [3355\. 零数组变换 I](https://leetcode.cn/problems/zero-array-transformation-i/)

难度：中等

给定一个长度为 `n` 的整数数组 `nums` 和一个二维数组 `queries`，其中 <code>queries[i] = [l<sub>i</sub>, r<sub>i</sub>]</code>。

对于每个查询 `queries[i]`：

- 在 `nums` 的下标范围 <code>[l<sub>i</sub>, r<sub>i</sub>]</code> 内选择一个下标 _子集_[^1]。
- 将选中的每个下标对应的元素值减 1。

**零数组** 是指所有元素都等于 0 的数组。

如果在按顺序处理所有查询后，可以将 `nums` 转换为 **零数组**，则返回 `true`，否则返回 `false`。

**示例 1：**

> **输入：** nums = [1,0,1], queries = \[[0,2]]
> **输出：** true
> **解释：**
>
> - **对于 i = 0：**
>   - 选择下标子集 `[0, 2]` 并将这些下标处的值减 1。
>   - 数组将变为 `[0, 0, 0]`，这是一个零数组。

**示例 2：**

> **输入：** nums = [4,3,2,1], queries = \[[1,3],[0,2]]
> **输出：** false
> **解释：**
>
> - **对于 i = 0：**
>   - 选择下标子集 `[1, 2, 3]` 并将这些下标处的值减 1。
>   - 数组将变为 `[4, 2, 1, 0]`。
> - **对于 i = 1：**
>   - 选择下标子集 `[0, 1, 2]` 并将这些下标处的值减 1。
>   - 数组将变为 `[3, 1, 0, 0]`，这不是一个零数组。

**提示：**

- <code>1 <= nums.length <= 10<sup>5</sup></code>
- <code>0 <= nums[i] <= 10<sup>5</sup></code>
- <code>1 <= queries.length <= 10<sup>5</sup></code>
- <code>queries[i].length == 2</code>
- <code>0 <= l<sub>i</sub> <= r<sub>i</sub> < nums.length</code>

[^1]: 数组的 **子集** 是从数组中选择一些元素（可能为空）。
