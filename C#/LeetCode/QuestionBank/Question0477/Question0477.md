### [477\. 汉明距离总和](https://leetcode.cn/problems/total-hamming-distance/)

难度：中等

两个整数的 [汉明距离](https://baike.baidu.com/item/%E6%B1%89%E6%98%8E%E8%B7%9D%E7%A6%BB/475174?fr=aladdin) 指的是这两个数字的二进制数对应位不同的数量。

给你一个整数数组 `nums`，请你计算并返回 `nums` 中任意两个数之间 **汉明距离的总和**。

**示例 1：**

> **输入：** nums = [4,14,2]
> **输出：** 6
> **解释：** 在二进制表示中，4 表示为 0100，14 表示为 1110，2表示为 0010。（这样表示是为了体现后四位之间关系）
> 所以答案为：
> HammingDistance(4, 14) + HammingDistance(4, 2) + HammingDistance(14, 2) = 2 + 2 + 2 = 6

**示例 2：**

> **输入：** nums = [4,14,4]
> **输出：** 4

**提示：**

- <code>1 <= nums.length <= 10<sup>4</sup></code>
- <code>0 <= nums[i] <= 10<sup>9</sup></code>
- 给定输入的对应答案符合 **32-bit** 整数范围
