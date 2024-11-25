### [743\. 网络延迟时间](https://leetcode.cn/problems/network-delay-time/)

难度：中等

有 `n` 个网络节点，标记为 `1` 到 `n`。

给你一个列表 `times`，表示信号经过 **有向** 边的传递时间。 <code>times[i] = (u<sub>i</sub>, v<sub>i</sub>, w<sub>i</sub>)</code>，其中 <code>u<sub>i</sub></code> 是源节点，<code>v<sub>i</sub></code> 是目标节点， <code>w<sub>i</sub></code> 是一个信号从源节点传递到目标节点的时间。

现在，从某个节点 `K` 发出一个信号。需要多久才能使所有节点都收到信号？如果不能使所有节点收到信号，返回 `-1` 。

**示例 1：**

> ![](./assets/img/Question0743_01.png)
> **输入：** times = \[[2,1,1],[2,3,1],[3,4,1]], n = 4, k = 2
> **输出：** 2

**示例 2：**

> **输入：** times = \[[1,2,1]], n = 2, k = 1
> **输出：** 1

**示例 3：**

> **输入：** times = \[[1,2,1]], n = 2, k = 2
> **输出：** \-1

**提示：**

- `1 <= k <= n <= 100`
- `1 <= times.length <= 6000`
- `times[i].length == 3`
- <code>1 <= u<sub>i</sub>, v<sub>i</sub> <= n</code>
- <code>u<sub>i</sub> != v<sub>i</sub></code>
- <code>0 <= w<sub>i</sub> <= 100</code>
- 所有 <code>(u<sub>i</sub>, v<sub>i</sub>)</code> 对都 **互不相同**（即，不含重复边）
