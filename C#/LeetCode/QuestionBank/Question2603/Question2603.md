### [2603\. 收集树中金币](https://leetcode.cn/problems/collect-coins-in-a-tree/)

难度：困难

给你一个 `n` 个节点的无向无根树，节点编号从 `0` 到 `n - 1` 。给你整数 `n` 和一个长度为 `n - 1` 的二维整数数组 `edges` ，其中 `edges[i] = [a_i, b_i]` 表示树中节点 `a_i` 和 `b_i` 之间有一条边。再给你一个长度为 `n` 的数组 `coins` ，其中 `coins[i]` 可能为 `0` 也可能为 `1` ，`1` 表示节点 `i` 处有一个金币。

一开始，你需要选择树中任意一个节点出发。你可以执行下述操作任意次：

-   收集距离当前节点距离为 `2` 以内的所有金币，或者
-   移动到树中一个相邻节点。

你需要收集树中所有的金币，并且回到出发节点，请你返回最少经过的边数。

如果你多次经过一条边，每一次经过都会给答案加一。

**示例 1：**

![](./assets/img/Question2603_01.png)

```
输入：coins = [1,0,0,0,0,1], edges = [[0,1],[1,2],[2,3],[3,4],[4,5]]
输出：2
解释：从节点 2 出发，收集节点 0 处的金币，移动到节点 3 ，收集节点 5 处的金币，然后移动回节点 2 。
```

**示例 2：**

![](./assets/img/Question2603_02.png)

```
输入：coins = [0,0,0,1,1,0,0,1], edges = [[0,1],[0,2],[1,3],[1,4],[2,5],[5,6],[5,7]]
输出：2
解释：从节点 0 出发，收集节点 4 和 3 处的金币，移动到节点 2 处，收集节点 7 处的金币，移动回节点 0 。
```

**提示：**

-   `n == coins.length`
-   `1 <= n <= 3 * 10^4`
-   `0 <= coins[i] <= 1`
-   `edges.length == n - 1`
-   `edges[i].length == 2`
-   `0 <= a_i, b_i < n`
-   `a_i != b_i`
-   `edges` 表示一棵合法的树。