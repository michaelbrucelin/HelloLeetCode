### [3514\. 不同 XOR 三元组的数目 II](https://leetcode.cn/problems/number-of-unique-xor-triplets-ii/)

难度：中等

给你一个整数数组 `nums`。

**XOR 三元组** 定义为三个元素的异或值 `nums[i] XOR nums[j] XOR nums[k]`，其中 `i <= j <= k`。

返回所有可能三元组 `(i, j, k)` 中 **不同** 的 XOR 值的数量。

**示例 1：**

> **输入：** nums = [1,3]
> **输出：** 2
> **解释：**
> 所有可能的 XOR 三元组值为：
>
> - <code>(0, 0, 0) &rightarrow; 1 XOR 1 XOR 1 = 1</code>
> - <code>(0, 0, 1) &rightarrow; 1 XOR 1 XOR 3 = 3</code>
> - <code>(0, 1, 1) &rightarrow; 1 XOR 3 XOR 3 = 1</code>
> - <code>(1, 1, 1) &rightarrow; 3 XOR 3 XOR 3 = 3</code>
>
> 不同的 XOR 值为 `{1, 3}`。因此输出为 2。

**示例 2：**

> **输入：** nums = [6,7,8,9]
> **输出：** 4
> **解释：**
> 不同的 XOR 值为 `{6, 7, 8, 9}`。因此输出为 4。

**提示：**

- `1 <= nums.length <= 1500`
- `1 <= nums[i] <= 1500`
