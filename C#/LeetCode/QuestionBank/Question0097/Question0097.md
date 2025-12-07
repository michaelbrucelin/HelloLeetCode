### [97\. 交错字符串](https://leetcode.cn/problems/interleaving-string/)

难度：中等

给定三个字符串 `s1`、`s2`、`s3`，请你帮忙验证 `s3` 是否是由 `s1` 和 `s2` **交错** 组成的。

两个字符串 `s` 和 `t` **交错** 的定义与过程如下，其中每个字符串都会被分割成若干 **非空** _子字符串[^1]_：

- <code>s = s<sub>1</sub> + s<sub>2</sub> + ... + s<sub>n</sub></code>
- <code>t = t<sub>1</sub> + t<sub>2</sub> + ... + t<sub>m</sub></code>
- `|n - m| <= 1`
- **交错** 是 <code>s<sub>1</sub> + t<sub>1</sub> + s<sub>2</sub> + t<sub>2</sub> + s<sub>3</sub> + t<sub>3</sub> + ...</code> 或者 <code>t<sub>1</sub> + s<sub>1</sub> + t<sub>2</sub> + s<sub>2</sub> + t<sub>3</sub> + s<sub>3</sub> + ...</code>

**注意：** `a + b` 意味着字符串 `a` 和 `b` 连接。

**示例 1：**

> ![](./assets/img/Question0097.jpg)
> **输入：** s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
> **输出：** true

**示例 2：**

> **输入：** s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
> **输出：** false

**示例 3：**

> **输入：** s1 = "", s2 = "", s3 = ""
> **输出：** true

**提示：**

- `0 <= s1.length, s2.length <= 100`
- `0 <= s3.length <= 200`
- `s1`、`s2`、和 `s3` 都由小写英文字母组成

**进阶：** 您能否仅使用 `O(s2.length)` 额外的内存空间来解决它?

[^1]: **子字符串** 是字符串中连续的 **非空** 字符序列。
