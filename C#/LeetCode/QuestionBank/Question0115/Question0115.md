### [115\. 不同的子序列](https://leetcode.cn/problems/distinct-subsequences/)

难度：困难

给你两个字符串 `s` 和 `t`，统计并返回在 `s` 的 **子序列** 中 `t` 出现的个数。

测试用例保证结果在 32 位有符号整数范围内。

**示例 1：**

> **输入：** s = "rabbbit", t = "rabbit"
> **输出：** 3
> **解释：**
> 如下所示, 有 3 种可以从 s 中得到 `"rabbit" 的方案`。
> <code><b>rabb</b>b<b>it</b></code>
> <code><b>ra</b>b<b>bbit</b></code>
> <code><b>rab</b>b<b>bit</b></code>

**示例 2：**

> **输入：** s = "babgbag", t = "bag"
> **输出：** 5
> **解释：**
> 如下所示, 有 5 种可以从 s 中得到 `"bag" 的方案`。
> <code><b>ba</b>b<b>g</b>bag</code>
> <code><b>ba</b>bgba<b>g</b></code>
> <code><b>b</b>abgb<b>ag</b></code>
> <code>ba<b>b</b>gb<b>ag</b></code>
> <code>babg<b>bag</b></code>

**提示：**

- `1 <= s.length, t.length <= 1000`
- `s` 和 `t` 由英文字母组成
