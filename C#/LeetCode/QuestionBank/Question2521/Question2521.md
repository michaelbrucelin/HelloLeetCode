### [2521\. 数组乘积中的不同质因数数目](https://leetcode.cn/problems/distinct-prime-factors-of-product-of-array/)

难度：中等

给你一个正整数数组 `nums`，对 `nums` 所有元素求积之后，找出并返回乘积中 **不同质因数** 的数目。

**注意：**

- **质数** 是指大于 `1` 且仅能被 `1` 及自身整除的数字。
- 如果 `val2 / val1` 是一个整数，则整数 `val1` 是另一个整数 `val2` 的一个因数。

**示例 1：**

> **输入：** nums = [2,4,3,7,10,6]
> **输出：** 4
> **解释：**
> nums 中所有元素的乘积是：2 &times; 4 &times; 3 &times; 7 &times; 10 &times; 6 = 10080 = 2<sup>5</sup> &times; 3<sup>2</sup> &times; 5 &times; 7。
> 共有 4 个不同的质因数，所以返回 4。

**示例 2：**

> **输入：** nums = [2,4,8,16]
> **输出：** 1
> **解释：**
> nums 中所有元素的乘积是：2 &times; 4 &times; 8 &times; 16 = 1024 = 2<sup>10</sup>。
> 共有 1 个不同的质因数，所以返回 1。

**提示：**

- <code>1 <= nums.length <= 10<sup>4</sup></code>
- `2 <= nums[i] <= 1000`
