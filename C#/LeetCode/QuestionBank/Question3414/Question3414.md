### [3414\. 不重叠区间的最大得分](https://leetcode.cn/problems/maximum-score-of-non-overlapping-intervals/)

难度：困难

给你一个二维整数数组 `intervals`，其中 <code>intervals[i] = [l<sub>i</sub>, r<sub>i</sub>, weight<sub>i</sub>]</code>。区间 `i` 的起点为 <code>l<sub>i</sub></code>，终点为 <code>r<sub>i</sub></code>，权重为 <code>weight<sub>i</sub></code>。你最多可以选择 **4 个互不重叠** 的区间。所选择区间的 **得分** 定义为这些区间权重的总和。

返回一个至多包含 4 个下标且 _字典序最小[^1]_ 的数组，表示从 `intervals` 中选中的互不重叠且得分最大的区间。

如果两个区间没有任何重叠点，则称二者 **互不重叠**。特别地，如果两个区间共享左边界或右边界，也认为二者重叠。

**示例 1：**

> **输入：** intervals = \[[1,3,2],[4,5,2],[1,5,5],[6,9,3],[6,7,1],[8,9,1]]
> **输出：** [2,3]
> **解释：**
> 可以选择下标为 2 和 3 的区间，其权重分别为 5 和 3。

**示例 2：**

> **输入：** intervals = \[[5,8,1],[6,7,7],[4,7,3],[9,10,6],[7,8,2],[11,14,3],[3,5,5]]
> **输出：** [1,3,5,6]
> **解释：**
> 可以选择下标为 1、3、5 和 6 的区间，其权重分别为 7、6、3 和 5。

**提示：**

- <code>1 <= intervals.length <= 5 &times; 10<sup>4</sup></code>
- `intervals[i].length == 3`
- <code>intervals[i] = [l<sub>i</sub>, r<sub>i</sub>, weight<sub>i</sub>]</code>
- <code>1 <= l<sub>i</sub> <= r<sub>i</sub> <= 10<sup>9</sup></code>
- <code>1 <= weight<sub>i</sub> <= 10<sup>9</sup></code>

[^1]: 考虑数组 `a` 与 数组 `b`，如果数组 `a` 在 `a` 与 `b` 相异的第一处的元素小于对应 `b` 在此处的元素，则称数组 `a` **字典序小于** `b`。
    如果 `a` 或 `b` 其中较短的数组为另一个字符串的前半部分，则较短的数组字典序小于另一个数组。
