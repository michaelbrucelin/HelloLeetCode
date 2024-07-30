### [50\. Pow(x, n)](https://leetcode.cn/problems/powx-n/)

难度：中等

实现 [pow(_x_, _n_)](https://www.cplusplus.com/reference/valarray/pow/) ，即计算 `x` 的整数 `n` 次幂函数（即，<code>x<sup>n</sup></code> ）。

**示例 1：**

> **输入：** x = 2.00000, n = 10
> **输出：** 1024.00000

**示例 2：**

> **输入：** x = 2.10000, n = 3
> **输出：** 9.26100

**示例 3：**

> **输入：** x = 2.00000, n = -2
> **输出：** 0.25000
> **解释：** $2^{-2} = 1/2^2 = 1/4 = 0.25

**提示：**

- `-100.0 < x < 100.0`
- <code>-2<sup>31</sup> <= n <= 2<sup>31</sup>-1</code>
- `n` 是一个整数
- 要么 `x` 不为零，要么 `n > 0` 。
- <code>-10<sup>4</sup> <= x<sup>n</sup> <= 10<sup>4</sup></code>
