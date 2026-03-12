### [2568\. 最小无法得到的或值](https://leetcode.cn/problems/minimum-impossible-or/)

难度：中等

给你一个下标从 **0** 开始的整数数组 `nums`。

如果存在一些整数满足 <code>0 <= index<sub>1</sub> < index<sub>2</sub> < ... < index<sub>k</sub> < nums.length</code>，得到 <code>nums[index<sub>1</sub>] | nums[index<sub>2</sub>] | ... | nums[index<sub>k</sub>] = x</code>，那么我们说 `x` 是 **可表达的**。换言之，如果一个整数能由 `nums` 的某个子序列的或运算得到，那么它就是可表达的。

请你返回 `nums` 不可表达的 **最小非零整数**。

**示例 1：**

> **输入：** nums = [2,1]
> **输出：** 4
> **解释：** 1 和 2 已经在数组中，因为 nums[0] | nums[1] = 2 | 1 = 3，所以 3 是可表达的。由于 4 是不可表达的，所以我们返回 4。

**示例 2：**

> **输入：** nums = [5,3,2]
> **输出：** 1
> **解释：** 1 是最小不可表达的数字。

**提示：**

- <code>1 <= nums.length <= 10<sup>5</sup></code>
- <code>1 <= nums[i] <= 10<sup>9</sup></code>
