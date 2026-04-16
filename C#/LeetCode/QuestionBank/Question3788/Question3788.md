### [3788\. 分割的最大得分](https://leetcode.cn/problems/maximum-score-of-a-split/)

难度：中等

给你一个长度为 `n` 的整数数组 `nums`。

请你选出一个下标 `i` 以分割数组，该下标满足 `0 <= i < n - 1`。

对于选择的分割下标 `i`：

- 令 `prefixSum(i)` 表示数组前缀的和，即 `nums[0] + nums[1] + ... + nums[i]`。
- 令 `suffixMin(i)` 表示数组后缀的最小值，即 `nums[i + 1], nums[i + 2], ..., nums[n - 1]` 中的最小值。

在下标 `i` 的 **分割得分** 定义为：

`score(i) = prefixSum(i) - suffixMin(i)`

返回所有有效分割下标中 **最大** 的分割得分。

**示例 1：**

> **输入：** nums = [10,-1,3,-4,-5]
> **输出：** 17
> **解释：**
> 最优的分割下标是 `i = 2`，`score(2) = prefixSum(2) - suffixMin(2) = (10 + (-1) + 3) - (-5) = 17`。

**示例 2：**

> **输入：** nums = [-7,-5,3]
> **输出：** -2
> **解释：**
> 最优的分割下标是 `i = 0`，`score(0) = prefixSum(0) - suffixMin(0) = (-7) - (-5) = -2`。

**示例 3：**

> **输入：** nums = [1,1]
> **输出：** 0
> **解释：**
> 唯一有效分割下标是 `i = 0`，`score(0) = prefixSum(0) - suffixMin(0) = 1 - 1 = 0`。

**提示：**

- <code>2 <= nums.length <= 10<sup>5</sup></code>
- <code>-10<sup>9</sup> <= nums[i] <= 10<sup>9</sup></code>
