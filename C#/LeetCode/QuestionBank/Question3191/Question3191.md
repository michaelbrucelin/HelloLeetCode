### [3191\. 使二进制数组全部等于 1 的最少操作次数 I](https://leetcode.cn/problems/minimum-operations-to-make-binary-array-elements-equal-to-one-i/)

难度：中等

给你一个二进制数组 `nums`。

你可以对数组执行以下操作 **任意** 次（也可以 0 次）：

- 选择数组中 **任意连续** 3 个元素，并将它们 **全部反转**。

**反转** 一个元素指的是将它的值从 0 变 1 ，或者从 1 变 0。

请你返回将 `nums` 中所有元素变为 1 的 **最少** 操作次数。如果无法全部变成 1 ，返回 -1。

**示例 1：**

> **输入：** nums = [0,1,1,1,0,0]
> **输出：** 3
> **解释：**
> 我们可以执行以下操作：
>
> - 选择下标为 0，1 和 2 的元素并反转，得到 <code>nums = [<u><b>1</b></u>,<u><b>0</b></u>,<u><b>0</b></u>,1,0,0]</code>。
> - 选择下标为 1，2 和 3 的元素并反转，得到 <code>nums = [1,<u><b>1</b></u>,<u><b>1</b></u>,<u><b>0</b></u>,0,0]</code>。
> - 选择下标为 3，4 和 5 的元素并反转，得到 <code>nums = [1,1,1,<u><b>1</b></u>,<u><b>1</b></u>,<u><b>1</b></u>]</code>。

**示例 2：**

> **输入：** nums = [0,1,1,1]
> **输出：** -1
> **解释：**
> 无法将所有元素都变为 1。

**提示：**

- <code>3 <= nums.length <= 10<sup>5</sup></code>
- `0 <= nums[i] <= 1`
