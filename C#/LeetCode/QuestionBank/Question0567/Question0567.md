### [567\. 字符串的排列](https://leetcode.cn/problems/permutation-in-string/)

难度：中等

给你两个字符串 `s1` 和 `s2`，写一个函数来判断 `s2` 是否包含 `s1` 的 排列。如果是，返回 `true`；否则，返回 `false`。

换句话说，`s1` 的排列之一是 `s2` 的 **子串**。

**示例 1：**

> **输入：** s1 = "ab" s2 = "eidbaooo"
> **输出：** true
> **解释：** s2 包含 s1 的排列之一 ("ba").

**示例 2：**

> **输入：** s1= "ab" s2 = "eidboaoo"
> **输出：** false

**提示：**

- <code>1 <= s1.length, s2.length <= 10<sup>4</sup></code>
- `s1` 和 `s2` 仅包含小写字母
