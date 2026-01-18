### [1358\. 包含所有三种字符的子字符串数目](https://leetcode.cn/problems/number-of-substrings-containing-all-three-characters/)

难度：中等

给你一个字符串 `s`，它只包含三种字符 a, b 和 c。

请你返回 a，b 和 c 都 **至少** 出现过一次的子字符串数目。

**示例 1：**

> **输入：** s = "abcabc"
> **输出：** 10
> **解释：** 包含 a，b 和 c 各至少一次的子字符串为 "_abc_", "_abca_", "_abcab_", "_abcabc_", "_bca_", "_bcab_", "_bcabc_", "_cab_", "_cabc_" 和 "_abc_" (**相同字符串算多次**)。

**示例 2：**

> **输入：** s = "aaacb"
> **输出：** 3
> **解释：** 包含 a，b 和 c 各至少一次的子字符串为 "_aaacb_", "_aacb_" 和 "_acb_"。

**示例 3：**

> **输入：** s = "abc"
> **输出：** 1

**提示：**

- <code>3 <= s.length <= 5 &times; 10<sup>4</sup></code>
- `s` 只包含字符 a，b 和 c。
