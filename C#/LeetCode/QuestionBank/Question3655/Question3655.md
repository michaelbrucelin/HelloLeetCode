### [3655\. 区间乘法查询后的异或 II](https://leetcode.cn/problems/xor-after-range-multiplication-queries-ii/)

难度：困难

给你一个长度为 `n` 的整数数组 `nums` 和一个大小为 `q` 的二维整数数组 `queries`，其中 <code>queries[i] = [l<sub>i</sub>, r<sub>i</sub>, k<sub>i</sub>, v<sub>i</sub>]</code>。

对于每个查询，需要按以下步骤依次执行操作：

- 设定 <code>idx = l<sub>i</sub></code>。
- 当 <code>idx <= r<sub>i</sub></code> 时：
  - 更新：<code>nums[idx] = (nums[idx] &times; v<sub>i</sub>) % (10<sup>9</sup> + 7)</code>。
  - 将 <code>idx += k<sub>i</sub></code>。

在处理完所有查询后，返回数组 `nums` 中所有元素的 **按位异或** 结果。

**示例 1：**

> **输入：** nums = [1,1,1], queries = \[[0,2,1,4]]
> **输出：** 4
> **解释：**
>
> - 唯一的查询 `[0, 2, 1, 4]` 将下标 0 到下标 2 的每个元素乘以 4。
> - 数组从 `[1, 1, 1]` 变为 `[4, 4, 4]`。
> - 所有元素的异或为 `4 ^ 4 ^ 4 = 4`。

**示例 2：**

> **输入：** nums = [2,3,1,5,4], queries = \[[1,4,2,3],[0,2,1,2]]
> **输出：** 31
> **解释：**
>
> - 第一个查询 `[1, 4, 2, 3]` 将下标 1 和 3 的元素乘以 3，数组变为 `[2, 9, 1, 15, 4]`。
> - 第二个查询 `[0, 2, 1, 2]` 将下标 0、1 和 2 的元素乘以 2，数组变为 `[4, 18, 2, 15, 4]`。
> - 所有元素的异或为 `4 ^ 18 ^ 2 ^ 15 ^ 4 = 31`。

**提示：**

- <code>1 <= n == nums.length <= 10<sup>5</sup></code>
- <code>1 <= nums[i] <= 10<sup>9</sup></code>
- <code>1 <= q == queries.length <= 10<sup>5</sup></code>
- <code>queries[i] = [l<sub>i</sub>, r<sub>i</sub>, k<sub>i</sub>, v<sub>i</sub>]</code>
- <code>0 <= l<sub>i</sub> <= r<sub>i</sub> < n</code>
- <code>1 <= k<sub>i</sub> <= n</code>
- <code>1 <= v<sub>i</sub> <= 10<sup>5</sup></code>
