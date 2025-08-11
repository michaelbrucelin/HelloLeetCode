### [2438\. 二的幂数组中查询范围内的乘积](https://leetcode.cn/problems/range-product-queries-of-powers/)

难度：中等

给你一个正整数 `n`，你需要找到一个下标从 **0** 开始的数组 `powers`，它包含 **最少** 数目的 `2` 的幂，且它们的和为 `n`。`powers` 数组是 **非递减** 顺序的。根据前面描述，构造 `powers` 数组的方法是唯一的。

同时给你一个下标从 **0** 开始的二维整数数组 `queries`，其中 <code>queries[i] = [left<sub>i</sub>, right<sub>i</sub>]</code>，其中 `queries[i]` 表示请你求出满足 <code>left<sub>i</sub> <= j <= right<sub>i</sup></code> 的所有 `powers[j]` 的乘积。

请你返回一个数组 `answers`，长度与 `queries` 的长度相同，其中 `answers[i]`是第 `i` 个查询的答案。由于查询的结果可能非常大，请你将每个 `answers[i]` 都对 <code>10<sup>9</sup> + 7</code> **取余**。

**示例 1：**

> **输入：** n = 15, queries = \[[0,1],[2,2],[0,3]]
> **输出：** [2,4,64]
> **解释：**
对于 $n = 15$，得到 $powers = [1,2,4,8]$。没法得到元素数目更少的数组。
第 $1$ 个查询的答案：$powers[0] \times powers[1] = 1 \times 2 = 2$。
第 $2$ 个查询的答案：$powers[2] = 4$。
第 $3$ 个查询的答案：$powers[0] \times powers[1] \times powers[2] \times powers[3] = 1 \times 2 \times 4 \times 8 = 64$。
每个答案对 <code>10<sup>9</sup> + 7</code> 得到的结果都相同，所以返回 $[2,4,64]$。

**示例 2：**

> **输入：** n = 2, queries = \[[0,0]]
> **输出：** [2]
> **解释：**
对于 $n = 2, powers = [2]$。
唯一一个查询的答案是 $powers[0] = 2$。答案对 <code>10<sup>9</sup> + 7</code> 取余后结果相同，所以返回 $[2]$。

**提示：**

- <code>1 <= n <= 10<sup>9</sup></code>
- <code>1 <= queries.length <= 10<sup>5</sup></code>
- <code>0 <= start<sub>i</sub> <= end<sub>i</sub> < powers.length</code>
