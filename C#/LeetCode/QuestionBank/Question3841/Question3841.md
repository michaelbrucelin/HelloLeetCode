### [3841\. 查询树上回文路径](https://leetcode.cn/problems/palindromic-path-queries-in-a-tree/)

难度：困难

给你一棵包含 `n` 个节点的无向树，节点编号从 0 到 `n - 1`。树由一个长度为 `n - 1` 的二维数组 `edges` 表示，其中 <code>edges[i] = [u<sub>i</sub>, v<sub>i</sub>]</code> 表示节点 <code>u<sub>i</sub></code> 和 <code>v<sub>i</sub></code> 之间存在一条无向边。

另给你一个长度为 `n` 且由小写英文字母组成的字符串 `s`，其中 `s[i]` 表示分配给节点 `i` 的字符。

还给你一个字符串数组 `queries`，其中每个 `queries[i]` 为以下形式之一：

- <code>"update u<sub>i</sub> c"</code>：将节点 <code>u<sub>i</sub></code> 处的字符更改为 `c`。正式地，更新 <code>s[u<sub>i</sub>] = c</code>。
- <code>"query u<sub>i</sub> v<sub>i</sub>"</code>：判断从 <code>u<sub>i</sub></code> 到 <code>v<sub>i</sub></code> 的 **唯一** 路径（含两端点）上的字符所组成的字符串，是否可以 **重新排列** 成一个 **回文串**。

返回一个布尔数组 `answer`，如果第 `i` 个类型为 <code>"query u<sub>i</sub> v<sub>i</sub>"</code> 的查询可以重新排列成 **回文串**，则 `answer[i]` 为 `true`，否则为 `false`。

**回文串** 是指正读和反读都相同的字符串。

**示例 1：**

> **输入：** n = 3, edges = \[[0,1],[1,2]], s = "aac", queries = ["query 0 2","update 1 b","query 0 2"]
> **输出：** [true,false]
> **解释：**
>
> - `"query 0 2"`：路径 <code>0 &rightarrow; 1 &rightarrow; 2</code> 得到的字符串是 `"aac"`，可以重新排列形成 `"aca"`，这是一个回文串。因此，`answer[0] = true`。
> - `"update 1 b"`：将节点 1 更新为 `'b'`，现在 `s = "abc"`。
> - `"query 0 2"`：路径上的字符为 `"abc"`，无法重新排列形成回文串。因此，`answer[1] = false`。
>
> 因此，`answer = [true, false]`。

**示例 2：**

> **输入：** n = 4, edges = \[[0,1],[0,2],[0,3]], s = "abca", queries = ["query 1 2","update 0 b","query 2 3","update 3 a","query 1 3"]
> **输出：** [false,false,true]
> **解释：**
>
> - `"query 1 2"`：路径 <code>1 &rightarrow; 0 &rightarrow; 2</code> 得到的字符串是 `"bac"`，无法重新排列形成回文串。因此，`answer[0] = false`。
> - `"update 0 b"`：将节点 0 更新为 `'b'`，现在 `s = "bbca"`。
> - `"query 2 3"`：路径 <code>2 &rightarrow; 0 &rightarrow; 3</code> 得到的字符串是 `"cba"`，无法重新排列形成回文串。因此，`answer[1] = false`。
> - `"update 3 a"`：将节点 3 更新为 `'a'`，`s = "bbca"`。
> - `"query 1 3"`：路径 <code>1 &rightarrow; 0 &rightarrow; 3</code> 得到的字符串是 `"bba"`，可以重新排列形成 `"bab"`，这是一个回文串。因此，`answer[2] = true`。
>
> 因此，`answer = [false, false, true]`。

**提示：**

- <code>1 <= n == s.length <= 5 &times; 10<sup>4</sup></code>
- `edges.length == n - 1`
- <code>edges[i] = [u<sub>i</sub>, v<sub>i</sub>]</code>
- <code>0 <= u<sub>i</sub>, v<sub>i</sub> <= n - 1</code>
- `s` 由小写英文字母组成。
- 输入生成的 `edges` 表示一棵有效的树。
- <code>1 <= queries.length <= 5 &times; 10<sup>4</sup></code>
  - <code>queries[i] = "update u<sub>i</sub> c"</code> 或
  - <code>queries[i] = "query u<sub>i</sub> v<sub>i</sub>"</code>
  - <code>0 <= u<sub>i</sub>, v<sub>i</sub> <= n - 1</code>
  - `c` 是一个小写英文字母。
