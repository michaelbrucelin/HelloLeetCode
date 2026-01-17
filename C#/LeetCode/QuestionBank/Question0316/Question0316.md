### [316\. 去除重复字母](https://leetcode.cn/problems/remove-duplicate-letters/)

难度：中等

给你一个字符串 `s`，请你去除字符串中重复的字母，使得每个字母只出现一次。需保证 **返回结果的 _字典序[^1]_ 最小**（要求不能打乱其他字符的相对位置）。

**示例 1：**

> **输入：** `s = "bcabc"`
> **输出：** `"abc"`

**示例 2：**

> **输入：** `s = "cbacdcbc"`
> **输出：** `"acdb"`

**提示：**

- <code>1 <= s.length <= 10<sup>4</sup></code>
- `s` 由小写英文字母组成

**注意：** 该题与 1081 [https://leetcode.cn/problems/smallest-subsequence-of-distinct-characters](https://leetcode.cn/problems/smallest-subsequence-of-distinct-characters) 相同

[^1]: 字典序更小
      考虑字符串 `a` 与 字符串 `b`，如果字符串 `a` 在 `a` 与 `b` 相异的第一处的字符在字母表上先于对应 `b` 在此处的字符出现，则称字符串 `a` **字典序小于** `b`。 $ $
      如果 `a` 或 `b` 其中较短的字符串为另一个字符串的前半部分，则较短的字符串字典序小于另一个字符串。
