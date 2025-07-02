### [3333\. 找到初始输入字符串 II](https://leetcode.cn/problems/find-the-original-typed-string-ii/)

难度：困难

Alice 正在她的电脑上输入一个字符串。但是她打字技术比较笨拙，她 **可能** 在一个按键上按太久，导致一个字符被输入 **多次**。

给你一个字符串 `word`，它表示 **最终** 显示在 Alice 显示屏上的结果。同时给你一个 **正** 整数 `k`，表示一开始 Alice 输入字符串的长度 **至少** 为 `k`。

请你返回 Alice 一开始可能想要输入字符串的总方案数。

由于答案可能很大，请你将它对 <code>10<sup>9</sup> + 7</code> **取余** 后返回。

**示例 1：**

> **输入：** word = "aabbccdd", k = 7
> **输出：** 5
> **解释：**
> 可能的字符串包括：`"aabbccdd"`，`"aabbccd"`，`"aabbcdd"`，`"aabccdd"` 和 `"abbccdd"`。

**示例 2：**

> **输入：** word = "aabbccdd", k = 8
> **输出：** 1
> **解释：**
> 唯一可能的字符串是 `"aabbccdd"`。

**示例 3：**

> **输入：** word = "aaabbb", k = 3
> **输出：** 8

**提示：**

- <code>1 <= word.length <= 5 &times; 10<sup>5</sup></code>
- `word` 只包含小写英文字母。
- `1 <= k <= 2000`
