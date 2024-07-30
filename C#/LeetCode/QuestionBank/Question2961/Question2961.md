### [2961\. 双模幂运算](https://leetcode.cn/problems/double-modular-exponentiation/)

难度：中等

给你一个下标从 **0** 开始的二维数组 `variables` ，其中 <code>variables[i] = [a<sub>i</sub>, b<sub>i</sub>, c<sub>i,</sub> m<sub>i</sub>]</code>，以及一个整数 `target` 。

如果满足以下公式，则下标 `i` 是 **好下标**：

- `0 <= i < variables.length`
- <code>((a<sub>i</sub><sup>b<sub>i</sub></sup> % 10)<sup>c<sub>i</sub></sup>) % m<sub>i</sub> == target</code>

返回一个由 **好下标** 组成的数组，**顺序不限** 。

**示例 1：**

> **输入：** variables = \[[2,3,3,10],[3,3,3,1],[6,1,1,4]], target = 2
> **输出：** [0,2]
> **解释：** 对于 variables 数组中的每个下标 i ：
>
> 1) 对于下标 0 ，variables[0] = [2,3,3,10] ，$(2^3 \% 10)^3 \% 10 = 2$。
> 2) 对于下标 1 ，variables[1] = [3,3,3,1] ，$(3^3 \% 10)^3 \% 1 = 0$。
> 3) 对于下标 2 ，variables[2] = [6,1,1,4] ，$(6^1 \% 10)^1 \% 4 = 2$。
>
> 因此，返回 [0,2] 作为答案。

**示例 2：**

> **输入：** variables = \[[39,3,1000,1000]], target = 17
> **输出：** []
> **解释：** 对于 variables 数组中的每个下标 i ：
>
> 1) 对于下标 0 ，variables[0] = [39,3,1000,1000] ，$(39^3 % 10)^1000 % 1000 = 1$。
>
> 因此，返回 [] 作为答案。

**提示：**

- `1 <= variables.length <= 100`
- <code>variables[i] == [a<sub>i</sub>, b<sub>i</sub>, c<sub>i</sub>, m<sub>i</sub>]</code>
- <code>1 <= a<sub>i</sub>, b<sub>i</sub>, c<sub>i</sub>, m<sub>i</sub> <= 10<sup>3</sup></code>
- <code>0 <= target <= 10<sup>3</sup></code>
