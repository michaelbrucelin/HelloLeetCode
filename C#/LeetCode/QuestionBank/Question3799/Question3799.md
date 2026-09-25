### [3799\. 单词方块 II](https://leetcode.cn/problems/word-squares-ii/)

难度：中等

给你一个字符串数组 `words`，包含一组 **互不相同** 且由小写英文字母组成的四字母字符串。

**单词方块** 由 4 个 **互不相同** 的单词组成：`top`, `left`, `right` 和 `bottom`，它们按如下方式排列：

- `top` 形成 **顶部行**。
- `bottom` 形成 **底部行**。
- `left` 形成 **左侧列**（从上到下）。
- `right` 形成 **右侧列**（从上到下）。

它必须满足以下条件：

- `top[0] == left[0]`, `top[3] == right[0]`
- `bottom[0] == left[3]`, `bottom[3] == right[3]`

返回所有满足题目要求的 **不同** 单词方块，按 4 元组 `(top, left, right, bottom)` 的 **字典序升序** 排序。

**示例 1：**

> **输入:** words = ["able","area","echo","also"]
> **输出:** \[["able","area","echo","also"],["area","able","also","echo"]]
> **解释:**
> 有且仅有两个符合题目要求的四字母单词方块：
>
> - `"able"` (top), `"area"` (left), `"echo"` (right), `"also"` (bottom)
>   - `top[0] == left[0] == 'a'`
>   - `top[3] == right[0] == 'e'`
>   - `bottom[0] == left[3] == 'a'`
>   - `bottom[3] == right[3] == 'o'`
> - `"area"` (top), `"able"` (left), `"also"` (right), `"echo"` (bottom)
>   - 对角的所有约束均满足。
>
> 因此，答案为 `\[["able","area","echo","also"],["area","able","also","echo"]]`。

**示例 2：**

> **输入:** words = ["code","cafe","eden","edge"]
> **输出:** []
> **解释:**
> 没有任何四个单词的组合可以满足所有四个角的约束。因此，答案为空数组 `[]`。

**提示：**

- `4 <= words.length <= 15`
- `words[i].length == 4`
- `words[i]` 仅由小写英文字母组成。
- 所有 `words[i]` 都 **互不相同**。
