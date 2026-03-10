### [3527\. 找到最常见的回答](https://leetcode.cn/problems/find-the-most-common-response/)

难度：中等

给你一个二维字符串数组 `responses`，其中每个 `responses[i]` 是一个字符串数组，表示第 `i` 天调查的回答结果。

请返回在对每个 `responses[i]` 中的回答 **去重** 后，所有天数中 **最常见** 的回答。如果有多个回答出现频率相同，则返回 **字典序最小[^1]** 的那个回答。

**示例 1：**

> **输入：** responses = \[["good","ok","good","ok"],["ok","bad","good","ok","ok"],["good"],["bad"]]
> **输出：** "good"
> **解释：**
>
> - 每个列表去重后，得到 `responses = \[["good", "ok"], ["ok", "bad", "good"], ["good"], ["bad"]]`。
> - `"good"` 出现了 3 次，`"ok"` 出现了 2 次，`"bad"` 也出现了 2 次。
> - 返回 `"good"`，因为它出现的频率最高。

**示例 2：**

> **输入：** responses = \[["good","ok","good"],["ok","bad"],["bad","notsure"],["great","good"]]
> **输出：** "bad"
> **解释：**
>
> - 每个列表去重后，`responses = \[["good", "ok"], ["ok", "bad"], ["bad", "notsure"], ["great", "good"]]`。
> - `"bad"`、`"good"` 和 `"ok"` 都出现了 2 次。
> - 返回 `"bad"`，因为它在这些最高频率的词中字典序最小。

**提示：**

- `1 <= responses.length <= 1000`
- `1 <= responses[i].length <= 1000`
- `1 <= responses[i][j].length <= 10`
- `responses[i][j]` 仅由小写英文字母组成

[^1]: 在字符串 `a` 和字符串 `b` 出现第一个不同的位置，如果字符串 `a` 有一个字母比字符串 `b` 中的对应字母在字母表中更早出现，则字符串 `a` 在字典序上小于字符串 `b`。
  如果前 `min(a.length, b.length)` 个字符没有不同，则较短的字符串在字段序上较小。
