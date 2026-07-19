### [2862\. 完全子集的最大元素和](https://leetcode.cn/problems/maximum-element-sum-of-a-complete-subset-of-indices/)

难度：困难

给你一个下标从 **1** 开始、由 `n` 个整数组成的数组。你需要从 `nums` 选择一个 **完全集**，其中每对元素下标的乘积都是一个 完全平方数，例如选择 <code>a<sub>i</sub></code> 和 <code>a<sub>j</sub></code>，<code>i &times; j</code> 一定是完全平方数。

返回 **完全子集** 所能取到的 **最大元素和**。

**示例 1：**

> **输入：** nums = [8,7,3,5,7,2,4,9]
> **输出：** 16
> **解释：**
> 我们选择下标为 2 和 8 的元素，并且 <code>2 &times; 8</code> 是一个完全平方数。

**示例 2：**

> **输入：** nums = [8,10,3,8,1,13,7,9,4]
> **输出：** 20
> **解释：**
> 我们选择下标为 1, 4, 9 的元素。<code>1 &times; 4</code>, <code>1 &times; 9</code>, <code>4 &times; 9</code> 是完全平方数。

**提示：**

- <code>1 <= n == nums.length <= 10<sup>4</sup></code>
- <code>1 <= nums[i] <= 10<sup>9</sup></code>
