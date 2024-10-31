### [3165\. 不包含相邻元素的子序列的最大和](https://leetcode.cn/problems/maximum-sum-of-subsequence-with-non-adjacent-elements/)

难度：困难

给你一个整数数组 `nums` 和一个二维数组 `queries`，其中 <code>queries[i] = [pos<sub>i</sub>, x<sub>i</sub>]</code>。

对于每个查询 `i`，首先将 <code>nums[pos<sub>i</sub>]</code> 设置为 <code>x<sub>i</sub></code>，然后计算查询 `i` 的答案，该答案为 `nums` 中 **不包含相邻元素** 的 **子序列**[^1] 的 **最大** 和。

返回所有查询的答案之和。

由于最终答案可能非常大，返回其对 <code>10<sup>9</sup> + 7</code> **取余** 的结果。

**子序列** 是指从另一个数组中删除一些或不删除元素而不改变剩余元素顺序得到的数组。

**示例 1：**

> **输入：** nums = [3,5,9], queries = \[[1,-2],[0,-3]]
> **输出：** 21
> **解释：**
> 执行第 1 个查询后，`nums = [3,-2,9]`，不包含相邻元素的子序列的最大和为 `3 + 9 = 12`。
> 执行第 2 个查询后，`nums = [-3,-2,9]`，不包含相邻元素的子序列的最大和为 9 。

**示例 2：**

> **输入：** nums = [0,-1], queries = \[[0,-5]]
> **输出：** 0
> **解释：**
> 执行第 1 个查询后，`nums = [-5,-1]`，不包含相邻元素的子序列的最大和为 0（选择空子序列）。

**提示：**

- <code>1 <= nums.length <= 5 * 10<sup>4</sup></code>
- <code>-10<sup>5</sup> <= nums[i] <= 10<sup>5</sup></code>
- <code>1 <= queries.length <= 5 * 10<sup>4</sup></code>
- <code>queries[i] == [pos<sub>i</sub>, x<sub>i</sub>]</code>
- <code>0 <= pos<sub>i</sub> <= nums.length - 1</code>
- <code>-10<sup>5</sup> <= x<sub>i</sub> <= 10<sup>5</sup></code>

[^1]: **子序列** 是可以通过从另一个数组删除或不删除某些元素，但不更改其余元素的顺序得到的数组。
