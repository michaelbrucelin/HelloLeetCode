### [3805\. 统计凯撒加密对数目](https://leetcode.cn/problems/count-caesar-cipher-pairs/)

难度：中等

给你一个由 `n` 个字符串组成的数组 `words`。每个字符串的长度均为 `m` 且仅包含小写英文字母。

如果我们可以通过执行以下操作任意次数（可能为零次）使得两个字符串 `s` 和 `t` 变得 **相等**，则称这两个字符串是 **相似** 的。

- 选择 `s` 或 `t`。
- 将所选字符串中的 **每个** 字母替换为字母表中的下一个字母（循环替换）。`'z'` 之后的下一个字母是 `'a'`。

计算满足以下条件的下标对 `(i, j)` 的数量：

- `i < j`
- `words[i]` 和 `words[j]` 是 **相似** 的。

返回一个整数，表示此类下标对的数量。

**示例 1：**

> **输入：** words = ["fusion","layout"]
> **输出：** 1
> **解释：**
> `words[0] = "fusion"` 和 `words[1] = "layout"` 是相似的，因为我们可以对 `"fusion"` 执行 6 次操作。字符串 `"fusion"` 的变化如下。
>
> - `"fusion"`
> - `"gvtjpo"`
> - `"hwukqp"`
> - `"ixvlrq"`
> - `"jywmsr"`
> - `"kzxnts"`
> - `"layout"`

**示例 2：**

> **输入：** words = ["ab","aa","za","aa"]
> **输出：** 2
> **解释：**
> `words[0] = "ab"` 和 `words[2] = "za"` 是相似的。`words[1] = "aa"` 和 `words[3] = "aa"` 是相似的。

**提示：**

- <code>1 <= n == words.length <= 10<sup>5</sup></code>
- <code>1 <= m == words[i].length <= 10<sup>5</sup></code>
- <code>1 <= n &times; m <= 10<sup>5</sup></code>
- `words[i]` 仅由小写英文字母组成。
