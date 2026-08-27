### [3720\. 大于目标字符串的最小字典序排列](https://leetcode.cn/problems/lexicographically-smallest-permutation-greater-than-target/)

难度：中等

给你两个长度均为 `n` 且仅由小写英文字母组成的字符串 `s` 和 `target`。

返回 `s` 的 **字典序最小的排列**，要求该排列 **严格** 大于 `target`。如果 `s` 不存在任何字典序严格大于 `target` 的排列，则返回一个空字符串。

如果两个长度相同的字符串 `a` 和 `b` 在它们首次出现不同字符的位置上，字符串 `a` 对应的字母在字母表中出现在 `b` 对应字母的 **后面**，则字符串 `a` **字典序严格大于** 字符串 `b`。

**排列** 是字符串中所有字符的一种重新排列。

**示例 1:**

> **输入:** s = "abc", target = "bba"
> **输出:** "bca"
> **解释:**
>
> - `s` 的排列（按字典序）有 `"abc"`, `"acb"`, `"bac"`, `"bca"`, `"cab"` 和 `"cba"`。
> - 字典序严格大于 `target` 的最小排列是 `"bca"`。

**示例 2:**

> **输入:** s = "leet", target = "code"
> **输出:** "eelt"
> **解释:**
>
> - `s` 的排列（按字典序）有 `"eelt"`，`"eetl"`，`"elet"`，`"elte"`，`"etel"`，`"etle"`，`"leet"`，`"lete"`，`"ltee"`，`"teel"`，`"tele"` 和 `"tlee"`。
> - 字典序严格大于 `target` 的最小排列是 `"eelt"`。

**示例 3:**

> **输入:** s = "baba", target = "bbaa"
> **输出:** ""
> **解释:**
>
> - `s` 的排列（按字典序）有 `"aabb"`，`"abab"`，`"abba"`，`"baab"`，`"baba"` 和 `"bbaa"`。
> - 其中没有一个排列的字典序严格大于 `target`。因此，答案是 `""`。

**提示:**

- `1 <= s.length == target.length <= 300`
- `s` 和 `target` 仅由小写英文字母组成。
