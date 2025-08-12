### [2787\. 将一个数字表示成幂的和的方案数](https://leetcode.cn/problems/ways-to-express-an-integer-as-sum-of-powers/)

难度：中等

给你两个 **正** 整数 `n` 和 `x`。

请你返回将 `n` 表示成一些 **互不相同** 正整数的 `x` 次幂之和的方案数。换句话说，你需要返回互不相同整数 <code>[n<sub>1</sub>, n<sub>2</sub>, ..., n<sub>k</sub>]</code> 的集合数目，满足 <code>n = n<sub>1</sub><sup>x</sup> + n<sub>2</sub><sup>x</sup> + ... + n<sub>k</sub><sup>x</sup></code>。

由于答案可能非常大，请你将它对 <code>10<sup>9</sup> + 7</code> 取余后返回。

比方说，`n = 160` 且 `x = 3`，一个表示 `n` 的方法是 <code>n = 2<sup>3</sup> + 3<sup>3</sup> + 5<sup>3</sup></code>。

**示例 1：**

> **输入：** n = 10, x = 2
> **输出：** 1
> **解释：** 我们可以将 $n$ 表示为：<code>n = 3<sup>2</sup> + 1<sup>2</sup> = 10</code>。
> 这是唯一将 $10$ 表达成不同整数 $2$ 次方之和的方案。

**示例 2：**

> **输入：** n = 4, x = 1
> **输出：** 2
> **解释：** 我们可以将 $n$ 按以下方案表示：
>
> - <code>n = 4<sup>1</sup> = 4</code>。
> - <code>n = 3<sup>1</sup> + 1<sup>1</sup> = 4</code>。

**提示：**

- `1 <= n <= 300`
- `1 <= x <= 5`
