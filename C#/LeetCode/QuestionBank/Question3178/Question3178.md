### [3178\. 找出 K 秒后拿着球的孩子](https://leetcode.cn/problems/find-the-child-who-has-the-ball-after-k-seconds/)

难度：简单

给你两个 **正整数** `n` 和 `k`。有 `n` 个编号从 `0` 到 `n - 1` 的孩子按顺序从左到右站成一队。

最初，编号为 0 的孩子拿着一个球，并且向右传球。每过一秒，拿着球的孩子就会将球传给他旁边的孩子。一旦球到达队列的 **任一端** ，即编号为 0 的孩子或编号为 `n - 1` 的孩子处，传球方向就会 **反转** 。

返回 `k` 秒后接到球的孩子的编号。

**示例 1：**

> **输入：** n = 3, k = 5
> **输出：** 1
> **解释：**
> 
> | 经过的时间 | 孩子队列 |
> | --- | --- |
> | `0` | `[0, 1, 2]` |
> | `1` | `[0, 1, 2]` |
> | `2` | `[0, 1, 2]` |
> | `3` | `[0, 1, 2]` |
> | `4` | `[0, 1, 2]` |
> | `5` | `[0, 1, 2]` |

**示例 2：**

> **输入：** n = 5, k = 6
> **输出：** 2
> **解释：**
> 
> | 经过的时间 | 孩子队列 |
> | --- | --- |
> | `0` | `[0, 1, 2, 3, 4]` |
> | `1` | `[0, 1, 2, 3, 4]` |
> | `2` | `[0, 1, 2, 3, 4]` |
> | `3` | `[0, 1, 2, 3, 4]` |
> | `4` | `[0, 1, 2, 3, 4]` |
> | `5` | `[0, 1, 2, 3, 4]` |
> | `6` | `[0, 1, 2, 3, 4]` |

**示例 3：**

> **输入：** n = 4, k = 2
> **输出：** 2
> **解释：**
> 
> | 经过的时间 | 孩子队列 |
> | --- | --- |
> | `0` | `[0, 1, 2, 3]` |
> | `1` | `[0, 1, 2, 3]` |
> | `2` | `[0, 1, 2, 3]` |

**提示：**

- `2 <= n <= 50`
- `1 <= k <= 50`