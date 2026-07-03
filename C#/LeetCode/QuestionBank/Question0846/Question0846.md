### [846\. 一手顺子](https://leetcode.cn/problems/hand-of-straights/)

难度：中等

Alice 手中有一把牌，她想要重新排列这些牌，分成若干组，使每一组的牌数都是 `groupSize`，并且由 `groupSize` 张连续的牌组成。

给你一个整数数组 `hand` 其中 `hand[i]` 是写在第 `i` 张牌上的**数值**。如果她可能重新排列这些牌，返回 `true`；否则，返回 `false`。

**示例 1：**

> **输入：** hand = [1,2,3,6,2,3,4,7,8], groupSize = 3
> **输出：** true
> **解释：** Alice 手中的牌可以被重新排列为 `[1,2,3]，[2,3,4]，[6,7,8]`。

**示例 2：**

> **输入：** hand = [1,2,3,4,5], groupSize = 4
> **输出：** false
> **解释：** Alice 手中的牌无法被重新排列成几个大小为 4 的组。

**提示：**

- <code>1 <= hand.length <= 10<sup>4</sup></code>
- <code>0 <= hand[i] <= 10<sup>9</sup></code>
- `1 <= groupSize <= hand.length`

**注意：** 此题目与 1296 重复：[https://leetcode.cn/problems/divide-array-in-sets-of-k-consecutive-numbers/](https://leetcode.cn/problems/divide-array-in-sets-of-k-consecutive-numbers/)
