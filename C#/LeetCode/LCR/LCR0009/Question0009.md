### [LCR 009. 乘积小于 K 的子数组](https://leetcode.cn/problems/ZVAVXX/)

难度：中等

给定一个正整数数组 `nums`和整数 `k`，请找出该数组内乘积小于 `k` 的连续的子数组的个数。

**示例 1：**

> **输入:** nums = [10,5,2,6], k = 100
> **输出:** 8
> **解释:** 8 个乘积小于 100 的子数组分别为: [10], [5], [2], [6], [10,5], [5,2], [2,6], [5,2,6]。
> 需要注意的是 [10,5,2] 并不是乘积小于100的子数组。

**示例 2：**

> **输入:** nums = [1,2,3], k = 0
> **输出:** 0

**提示：**

- <code>1 <= nums.length <= 3 &times; 10<sup>4</sup></code>
- `1 <= nums[i] <= 1000`
- <code>0 <= k <= 10<sup>6</sup></code>

**注意：** 本题与主站 713 题相同：[https://leetcode.cn/problems/subarray-product-less-than-k/](https://leetcode.cn/problems/subarray-product-less-than-k/)
