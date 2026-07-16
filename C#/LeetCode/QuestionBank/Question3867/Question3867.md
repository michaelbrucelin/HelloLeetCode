### [3867\. 数对的最大公约数之和](https://leetcode.cn/problems/sum-of-gcd-of-formed-pairs/)

难度：中等

给你一个长度为 `n` 的整数数组 `nums`。

构造一个数组 `prefixGcd`，其中对于每个下标 `i`：

- 令 <code>mx<sub>i</sub> = max(nums[0], nums[1], ..., nums[i])</code>。
- <code>prefixGcd[i] = gcd(nums[i], mx<sub>i</sub>)</code>。

在构造 `prefixGcd` 之后：

- 将 `prefixGcd` 按 **非递减** 顺序排序。
- 通过取 **最小的未配对** 元素和 **最大的未配对** 元素来形成数对。
- 重复此过程，直到无法再形成更多数对。
- 对于每个形成的数对，**计算** 两个元素的最大公约数 `gcd`。
- 如果 `n` 是奇数，`prefixGcd` 数组中的 **中间** 元素保持 **未配对** 状态，并应被忽略。

返回一个整数，表示所有形成数对的 **最大公约数之和**。

术语 `gcd(a, b)` 表示 `a` 和 `b` 的 **最大公约数**。

**示例 1：**

> **输入：** nums = [2,6,4]
> **输出：** 2
> **解释：**
> 构造 `prefixGcd`：
>
> | <code>i</code> | <code>nums[i]</code> | <code>mx<sub>i</sub></code> | <code>prefixGcd[i]</code> |
> | -- | -- | -- | -- |
> | 0 | 2 | 2 | 2 |
> | 1 | 6 | 6 | 6 |
> | 2 | 4 | 6 | 2 |
>
> `prefixGcd = [2, 6, 2]`。排序后形成 `[2, 2, 6]`。
> 将最小和最大的元素配对：`gcd(2, 6) = 2`。剩下的中间元素 2 被忽略。因此，总和为 2。

**示例 2：**

> **输入：** nums = [3,6,2,8]
> **输出：** 5
> **解释：**
> 构造 `prefixGcd`：
>
> | <code>i</code> | <code>nums[i]</code> | <code>mx<sub>i</sub></code> | <code>prefixGcd[i]</code> |
> | -- | -- | -- | -- |
> | 0 | 3 | 3 | 3 |
> | 1 | 6 | 6 | 6 |
> | 2 | 2 | 6 | 2 |
> | 3 | 8 | 8 | 8 |
>
> `prefixGcd = [3, 6, 2, 8]`。排序后形成 `[2, 3, 6, 8]`。
> 形成数对：`gcd(2, 8) = 2` 和 `gcd(3, 6) = 3`。因此，总和为 `2 + 3 = 5`。

**提示：**

- <code>1 <= n == nums.length <= 10<sup>5</sup></code>
- <code>1 <= nums[i] <= 10<sup>9</sup></code>
