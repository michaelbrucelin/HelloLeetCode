### [4010\. 数对的最大强度](https://leetcode.cn/problems/maximize-pair-strength-using-gcd/)

难度：简单

给你一个整数数组 `nums`。

选择 **恰好一对** 不同下标 `i` 和 `j`。该数对的 **强度** 定义为：

<code>(nums[i] &times; nums[j]) / gcd(nums[i], nums[j])<sup>2</sup></code>

返回所有可能数对中的 **最大** 强度。

`gcd(a, b)` 表示 `a` 和 `b` 的 **最大公约数**。

**示例 1：**

> **输入：** nums = [2,3,5]
> **输出：** 15
> **解释：**
> 选择 `i = 1` 和 `j = 2`，得到强度：
> <code>(3 &times; 5) / gcd(3, 5)<sup>2</sup> = 15 / 1 = 15</code>，这是所有数对中的最大值。

**示例 2：**

> **输入：** nums = [4,6,8]
> **输出：** 12
> **解释：**
> 选择 `i = 1` 和 `j = 2`，得到强度：
> <code>(6 &times; 8) / gcd(6, 8)<sup>2</sup> = 48 / 4 = 12</code>，这是所有数对中的最大值。

**示例 3：**

> **输入：** nums = [3,3]
> **输出：** 1
> **解释：**
> 选择 `i = 0` 和 `j = 1`，得到强度：
> <code>(3 &times; 3) / gcd(3, 3)<sup>2</sup> = 9 / 9 = 1</code>，这是唯一数对的强度。

**提示：**

- `2 <= nums.length <= 2000`
- <code>1 <= nums[i] <= 10<sup>5</sup></code>
