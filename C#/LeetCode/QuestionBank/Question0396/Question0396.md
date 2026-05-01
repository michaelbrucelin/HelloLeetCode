### [396\. 旋转函数](https://leetcode.cn/problems/rotate-function/)

难度：中等

给定一个长度为 `n` 的整数数组 `nums`。

假设 <code>arr<sub>k</sub></code> 是数组 `nums` 顺时针旋转 `k` 个位置后的数组，我们定义 `nums` 的 **旋转函数** `F` 为：

- <code>F(k) = 0 &times; arr<sub>k</sub>[0] + 1 &times; arr<sub>k</sub>[1] + ... + (n - 1) &times; arr<sub>k</sub>[n - 1]</code>

返回 _`F(0), F(1), ..., F(n-1)`中的最大值_。

生成的测试用例让答案符合 **32 位** 整数。

**示例 1:**

> **输入:** nums = [4,3,2,6]
> **输出:** 26
> **解释:**
> F(0) = (0 &times; 4) + (1 &times; 3) + (2 &times; 2) + (3 &times; 6) = 0 + 3 + 4 + 18 = 25
> F(1) = (0 &times; 6) + (1 &times; 4) + (2 &times; 3) + (3 &times; 2) = 0 + 4 + 6 + 6 = 16
> F(2) = (0 &times; 2) + (1 &times; 6) + (2 &times; 4) + (3 &times; 3) = 0 + 6 + 8 + 9 = 23
> F(3) = (0 &times; 3) + (1 &times; 2) + (2 &times; 6) + (3 &times; 4) = 0 + 2 + 12 + 12 = 26
> 所以 F(0), F(1), F(2), F(3) 中的最大值是 F(3) = 26。

**示例 2:**

> **输入:** nums = [100]
> **输出:** 0

**提示:**

- `n == nums.length`
- <code>1 <= n <= 10<sup>5</sup></code>
- `-100 <= nums[i] <= 100`
