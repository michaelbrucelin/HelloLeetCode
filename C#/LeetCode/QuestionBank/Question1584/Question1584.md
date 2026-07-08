### [1584\. 连接所有点的最小费用](https://leetcode.cn/problems/min-cost-to-connect-all-points/)

难度：中等

给你一个`points` 数组，表示 2D 平面上的一些点，其中 <code>points[i] = [x<sub>i</sub>, y<sub>i</sub>]</code>。

连接点 <code>[x<sub>i</sub>, y<sub>i</sub>]</code> 和点 <code>[x<sub>j</sub>, y<sub>j</sub>]</code> 的费用为它们之间的 *&times;曼哈顿距离&times;&times;：<code>|x<sub>i</sub> - x<sub>j</sub>| + |y<sub>i</sub> - y<sub>j</sub>|</code>，其中 `|val|` 表示 `val` 的绝对值。

请你返回将所有点连接的最小总费用。只有任意两点之间 **有且仅有** 一条简单路径时，才认为所有点都已连接。

**示例 1：**

> ![](./assets/img/Question1584_01.png)
>
> **输入：** points = \[[0,0],[2,2],[3,10],[5,2],[7,0]]
> **输出：** 20
> **解释：**
> > ![](./assets/img/Question1584_02.png)
> 我们可以按照上图所示连接所有点得到最小总费用，总费用为 20。
> 注意到任意两个点之间只有唯一一条路径互相到达。

**示例 2：**

> **输入：** points = \[[3,12],[-2,5],[-4,1]]
> **输出：** 18

**示例 3：**

> **输入：** points = \[[0,0],[1,1],[1,0],[-1,1]]
> **输出：** 4

**示例 4：**

> **输入：** points = \[[-1000000,-1000000],[1000000,1000000]]
> **输出：** 4000000

**示例 5：**

> **输入：** points = \[[0,0]]
> **输出：** 0

**提示：**

- `1 <= points.length <= 1000`
- <code>-10<sup>6</sup> <= x<sub>i</sub>, y<sub>i</sub> <= 10<sup>6</sup></code>
- 所有点 <code>(x<sub>i</sub>, y<sub>i</sub>)</code> 两两不同。
