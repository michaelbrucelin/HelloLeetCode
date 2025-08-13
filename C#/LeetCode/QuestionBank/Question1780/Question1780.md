### [1780\. 判断一个数字是否可以表示成三的幂的和](https://leetcode.cn/problems/check-if-number-is-a-sum-of-powers-of-three/)

难度：中等

给你一个整数 `n`，如果你可以将 `n` 表示成若干个不同的三的幂之和，请你返回 `true`，否则请返回 `false`。

对于一个整数 `y`，如果存在整数 `x` 满足 <code>y == 3<sup>x</sup></code>，我们称这个整数 `y` 是三的幂。

**示例 1：**

> **输入：** n = 12
> **输出：** true
> **解释：** 12 = 3<sup>1</sup> + 3<sup>2</sup>

**示例 2：**

> **输入：** n = 91
> **输出：** true
> **解释：** 91 = 3<sup>0</sup> + 3<sup>2</sup> + 3<sup>4</sup>

**示例 3：**

> **输入：** n = 21
> **输出：** false

**提示：**

- <code>1 <= n <= 10<sup>7</sup></code>
