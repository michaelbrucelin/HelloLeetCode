### [LCR 067. 数组中两个数的最大异或值](https://leetcode.cn/problems/ms70jA/)

难度：中等

给定一个整数数组 `nums`，返回 `nums[i] XOR nums[j]` 的最大运算结果，其中 <code>0 &le; i &le; j < n</code>。

**示例 1：**

> **输入：** nums = [3,10,5,25,2,8]
> **输出：** 28
> **解释：** 最大运算结果是 5 XOR 25 = 28.

**示例 2：**

> **输入：** nums = [0]
> **输出：** 0

**示例 3：**

> **输入：** nums = [2,4]
> **输出：** 6

**示例 4：**

> **输入：** nums = [8,10,2]
> **输出：** 10

**示例 5：**

> **输入：** nums = [14,70,53,83,49,91,36,80,92,51,66,70]
> **输出：** 127

**提示：**

- <code>1 <= nums.length <= 2 &times; 10<sup>5</sup></code>
- <code>0 <= nums[i] <= 2<sup>31</sup> - 1</code>

**进阶**：你可以在 `O(n)` 的时间解决这个问题吗？

**注意**：本题与主站 421 题相同：[https://leetcode.cn/problems/maximum-xor-of-two-numbers-in-an-array/](https://leetcode.cn/problems/maximum-xor-of-two-numbers-in-an-array/)
