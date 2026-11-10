### [3693\. 爬楼梯 II](https://leetcode.cn/problems/climbing-stairs-ii/)

难度：中等

你正在爬一个有 `n + 1` 级台阶的楼梯，台阶编号从 `0` 到 `n`。

你还得到了一个长度为 `n` 的 **下标从 1 开始** 的整数数组 `costs`，其中 `costs[i]` 是第 `i` 级台阶的成本。

从第 `i` 级台阶，你 **只能** 跳到第 `i + 1`、`i + 2` 或 `i + 3` 级台阶。从第 `i` 级台阶跳到第 `j` 级台阶的成本定义为：<code>costs[j] + (j - i)<sup>2</sup></code>

你从第 0 级台阶开始，初始 `cost = 0`。

返回到达第 `n` 级台阶所需的 **最小** 总成本。

****示例 1:****

> **输入：** n = 4, costs = [1,2,3,4]
> **输出：** 13
> **解释：**
> 一个最优路径是 <code>0 &rightarrow; 1 &rightarrow; 2 &rightarrow; 4</code>
>
> | 跳跃 | 成本计算 | 成本 |
> | --- | --- | --- |
> | 0 &rightarrow; 1 | <code>costs[1] + (1 - 0)<sup>2</sup> = 1 + 1</code> | 2 |
> | 1 &rightarrow; 2 | <code>costs[2] + (2 - 1)<sup>2</sup> = 2 + 1</code> | 3 |
> | 2 &rightarrow; 4 | <code>costs[4] + (4 - 2)<sup>2</sup> = 4 + 4</code> | 8 |
>
> 因此，最小总成本为 `2 + 3 + 8 = 13`

****示例 2:****

> **输入：** n = 4, costs = [5,1,6,2]
> **输出：** 11
> **解释：**
> 一个最优路径是 <code>0 &rightarrow; 2 &rightarrow; 4</code>
>
> | 跳跃 | 成本计算 | 成本 |
> | --- | --- | --- |
> | 0 &rightarrow; 2 | <code>costs[2] + (2 - 0)<sup>2</sup> = 1 + 4</code> | 5 |
> | 2 &rightarrow; 4 | <code>costs[4] + (4 - 2)<sup>2</sup> = 2 + 4</code> | 6 |
>
> 因此，最小总成本为 `5 + 6 = 11`

****示例 3:****

> **输入：** n = 3, costs = [9,8,3]
> **输出：** 12
> **解释：**
> 最优路径是 <code>0 &rightarrow; 3</code>，总成本 = <code>costs[3] + (3 - 0)<sup>2</sup> = 3 + 9 = 12</code>

**提示:**

- <code>1 <= n == costs.length <= 10<sup>5</sup></code>
- <code>1 <= costs[i] <= 10<sup>4</sup></code>
