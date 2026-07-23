### [3513\. 不同 XOR 三元组的数目 I](https://leetcode.cn/problems/number-of-unique-xor-triplets-i/)

难度：中等

给你一个长度为 `n` 的整数数组 `nums`，其中 `nums` 是范围 `[1, n]` 内所有数的 **排列**。

**XOR 三元组** 定义为三个元素的异或值 `nums[i] XOR nums[j] XOR nums[k]`，其中 `i <= j <= k`。

返回所有可能三元组 `(i, j, k)` 中 **不同** 的 XOR 值的数量。

**排列** 是一个集合中所有元素的重新排列。

**示例 1：**

> **输入：** nums = [1,2]
> **输出：** 2
> **解释：**
> 所有可能的 XOR 三元组值为：
>
> - <code>(0, 0, 0) &rightarrow; 1 XOR 1 XOR 1 = 1</code>
> - <code>(0, 0, 1) &rightarrow; 1 XOR 1 XOR 2 = 2</code>
> - <code>(0, 1, 1) &rightarrow; 1 XOR 2 XOR 2 = 1</code>
> - <code>(1, 1, 1) &rightarrow; 2 XOR 2 XOR 2 = 2</code>
>
> 不同的 XOR 值为 `{1, 2}`，因此输出为 2。

**示例 2：**

> **输入：** nums = [3,1,2]
> **输出：** 4
> **解释：**
> 可能的 XOR 三元组值包括：
>
> - <code>(0, 0, 0) &rightarrow; 3 XOR 3 XOR 3 = 3</code>
> - <code>(0, 0, 1) &rightarrow; 3 XOR 3 XOR 1 = 1</code>
> - <code>(0, 0, 2) &rightarrow; 3 XOR 3 XOR 2 = 2</code>
> - <code>(0, 1, 2) &rightarrow; 3 XOR 1 XOR 2 = 0</code>
>
> 不同的 XOR 值为 `{0, 1, 2, 3}`，因此输出为 4。

**提示：**

- <code>1 <= n == nums.length <= 10<sup>5</sup></code>
- `1 <= nums[i] <= n`
- `nums` 是从 `1` 到 `n` 的整数的一个排列。
