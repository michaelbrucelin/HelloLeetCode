### [3727\. 最大交替平方和](https://leetcode.cn/problems/maximum-alternating-sum-of-squares/)

难度：中等

给你一个整数数组 `nums`。你可以以任意顺序 **重新排列元素**。

数组 `arr` 的 **交替得分** 定义为：

- <code>score = arr[0]<sup>2</sup> - arr[1]<sup>2</sup> + arr[2]<sup>2</sup> - arr[3]<sup>2</sup> + ...</code>

在对 `nums` 重新排列后，返回其 **最大可能的交替得分**。

**示例 1：**

> **输入：** nums = [1,2,3]
> **输出：** 12
> **解释：**
> `nums` 的一种可行重排为 `[2,1,3]`，该排列在所有可能重排中给出了最大交替得分。
> 交替得分计算如下：
> <code>score = 2<sup>2</sup> - 1<sup>2</sup> + 3<sup>2</sup> = 4 - 1 + 9 = 12</code>

**示例 2：**

> **输入：** nums = [1,-1,2,-2,3,-3]
> **输出：** 16
> **解释：**
> `nums` 的一种可行重排为 `[-3,-1,-2,1,3,2]`，该排列在所有可能重排中给出了最大交替得分。
> 交替得分计算如下：
> <code>score = (-3)<sup>2</sup> - (-1)<sup>2</sup> + (-2)<sup>2</sup> - (1)<sup>2</sup> + (3)<sup>2</sup> - (2)<sup>2</sup> = 9 - 1 + 4 - 1 + 9 - 4 = 16</code>

**提示：**

- <code>1 <= nums.length <= 10<sup>5</sup></code>
- <code>-4 &times; 10<sup>4</sup> <= nums[i] <= 4 &times; 10<sup>4</sup></code>
