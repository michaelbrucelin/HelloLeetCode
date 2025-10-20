### [3346\. 执行操作后元素的最高频率 I](https://leetcode.cn/problems/maximum-frequency-of-an-element-after-performing-operations-i/)

难度：中等

给你一个整数数组 `nums` 和两个整数 `k` 和 `numOperations`。

你必须对 `nums` 执行 **操作**  `numOperations` 次。每次操作中，你可以：

- 选择一个下标 `i`，它在之前的操作中 **没有** 被选择过。
- 将 `nums[i]` 增加范围 `[-k, k]` 中的一个整数。

在执行完所有操作以后，请你返回 `nums` 中出现 **频率最高** 元素的出现次数。

一个元素 `x` 的 **频率** 指的是它在数组中出现的次数。

**示例 1：**

> **输入：** nums = [1,4,5], k = 1, numOperations = 2
> **输出：** 2
> **解释：**
> 通过以下操作得到最高频率 2：
>
> - 将 `nums[1]` 增加 0，`nums` 变为 `[1, 4, 5]`。
> - 将 `nums[2]` 增加 -1，`nums` 变为 `[1, 4, 4]`。

**示例 2：**

> **输入：** nums = [5,11,20,20], k = 5, numOperations = 1
> **输出：** 2
> **解释：**
> 通过以下操作得到最高频率 2：
>
> - 将 `nums[1]` 增加 0。

**提示：**

- <code>1 <= nums.length <= 10<sup>5</sup></code>
- <code>1 <= nums[i] <= 10<sup>5</sup></code>
- <code>0 <= k <= 10<sup>5</sup></code>
- `0 <= numOperations <= nums.length`
