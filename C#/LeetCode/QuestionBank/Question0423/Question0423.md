### [423\. 从英文中重建数字](https://leetcode.cn/problems/reconstruct-original-digits-from-english/)

难度：中等

给你一个字符串 `s`，其中包含字母顺序打乱的用英文单词表示的若干数字（`0-9`）。按 **升序** 返回原始的数字。

**示例 1：**

> **输入：** s = "owoztneoer"
> **输出：** "012"

**示例 2：**

> **输入：** s = "fviefuro"
> **输出：** "45"

**提示：**

- <code>1 <= s.length <= 10<sup>5</sup></code>
- `s[i]` 为 `["e","g","f","i","h","o","n","s","r","u","t","w","v","x","z"]` 这些字符之一
- `s` 保证是一个符合题目要求的字符串
