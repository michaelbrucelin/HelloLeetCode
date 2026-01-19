### [2223\. 构造字符串的总得分和](https://leetcode.cn/problems/sum-of-scores-of-built-strings/)

难度：困难

你需要从空字符串开始 **构造** 一个长度为 `n` 的字符串 `s`，构造的过程为每次给当前字符串 **前面** 添加 **一个** 字符。构造过程中得到的所有字符串编号为 `1` 到 `n`，其中长度为 `i` 的字符串编号为 <code>s<sub>i</sub></code>。

- 比方说，`s = "abaca"`，<code>s<sub>1</sub> == "a"</code>，<code>s<sub>2</sub> == "ca"</code>，<code>s<sub>3</sub> == "aca"</code> 依次类推。

<code>s<sub>i</sub></code> 的 **得分** 为 <code>s<sub>i</sub></code> 和 <code>s<sub>n</sub></code> 的 *&times;最长公共前缀&times;&times; 的长度（注意 <code>s == s<sub>n</sub></code> ）。

给你最终的字符串 `s`，请你返回每一个 <code>s<sub>i</sub></code> 的 **得分之和**。

**示例 1：**

> **输入：** s = "babab"
> **输出：** 9
> **解释：**
> s<sub>1</sub> == "b"，最长公共前缀是 "b"，得分为 1。
> s<sub>2</sub> == "ab"，没有公共前缀，得分为 0。
> s<sub>3</sub> == "bab"，最长公共前缀为 "bab"，得分为 3。
> s<sub>4</sub> == "abab"，没有公共前缀，得分为 0。
> s<sub>5</sub> == "babab"，最长公共前缀为 "babab"，得分为 5。
> 得分和为 1 + 0 + 3 + 0 + 5 = 9，所以我们返回 9。

**示例 2：**

> **输入：** s = "azbazbzaz"
> **输出：** 14
> **解释：**
> s<sub>2</sub> == "az"，最长公共前缀为 "az"，得分为 2。
> s<sub>6</sub> == "azbzaz"，最长公共前缀为 "azb"，得分为 3。
> s<sub>9</sub> == "azbazbzaz"，最长公共前缀为 "azbazbzaz"，得分为 9。
> 其他 s<sub>i</sub> 得分均为 0。
> 得分和为 2 + 3 + 9 = 14，所以我们返回 14。

**提示：**

- <code>1 <= s.length <= 10<sup>5</sup></code>
- `s` 只包含小写英文字母。
