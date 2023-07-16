#### [【图解】一张图秒懂换根 DP！（Python/Java/C++/Go/JS）](https://leetcode.cn/problems/sum-of-distances-in-tree/solutions/2345592/tu-jie-yi-zhang-tu-miao-dong-huan-gen-dp-6bgb/)

暴力做法是，以点 $i$ 为树根，从 $i$ 出发 DFS 这棵树，那么 $i$ 到 $j$ 的距离就是 $j$ 在这棵树的深度。所有点的深度之和就是 $answer[i]$（简称为 $ans[i]$）。

但这样做，DFS 一次的时间是 $\mathcal{O}(n)$，$n$ 个点各 DFS 一次，总时间就是 $\mathcal{O}(n^2)$，会超时。如何优化呢？

![](./assets/img/Solution0834_oth_01.png)

#### 答疑

**问**：子树大小是怎么算的？

**答**：先说二叉树，子树 $x$ 的大小等于左子树的大小，加上右子树的大小，再加上 $1$（节点 $x$ 本身），那么后序遍历这棵树，就可以算出每棵子树的大小。不清楚该过程的同学，需要学习「递归」「子问题」等概念，具体请看[【基础算法精讲 09】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1UD4y1Y769%2F)。然后推广到一般树，子树 $x$ 的大小，等于 $x$ 的所有儿子的子树大小之和，再加上 $1$（节点 $x$ 本身）。

**问**：在 DFS 中，如何保证每个节点只递归访问一次？

**答**：通用做法是用一个 $vis$ 数组标记访问过的点，如果某个点之前访问过，就不再递归访问。但对于树来说，一直向下递归，并不会遇到之前访问过的点，所以不需要 $vis$ 数组。本题是无向树，除了根节点以外，其余每个点的邻居都包含其父节点，所以要避免访问父节点。我们可以定义 $dfs(x,fa)$ 表示递归到节点 $x$ 且 $x$ 的父节点为 $fa$。只要 $x$ 的邻居 $y\ne fa$，就可以 $dfs(y,x)$ 向下递归了。

**问**：这种算法的**本质**是什么？

**答**：以图中的这棵树为例，从「以 $0$ 为根」换到「以 $2$ 为根」时，原来 $2$ 的子节点还是 $2$ 的子节点，原来 $1$ 的子节点还是 $1$ 的子节点，**唯一改变的是** $0$ **和** $2$ **的父子关系**。由此可见，一对节点的距离的「变化量」应该是很小的，那么找出「变化量」的规律，就可以基于 $ans[0]$ 算出 $ans[2]$ 了。这种算法叫做**换根 DP**。

```python
class Solution:
    def sumOfDistancesInTree(self, n: int, edges: List[List[int]]) -> List[int]:
        g = [[] for _ in range(n)]  # g[x] 表示 x 的所有邻居
        for x, y in edges:
            g[x].append(y)
            g[y].append(x)

        ans = [0] * n
        size = [1] * n  # 注意这里初始化成 1 了，下面只需要累加儿子的子树大小
        def dfs(x: int, fa: int, depth: int) -> None:
            ans[0] += depth  # depth 为 0 到 x 的距离
            for y in g[x]:  # 遍历 x 的邻居 y
                if y != fa:  # 避免访问父节点
                    dfs(y, x, depth + 1)  # x 是 y 的父节点
                    size[x] += size[y]  # 累加 x 的儿子 y 的子树大小
        dfs(0, -1, 0)  # 0 没有父节点

        def reroot(x: int, fa: int) -> None:
            for y in g[x]:  # 遍历 x 的邻居 y
                if y != fa:  # 避免访问父节点
                    ans[y] = ans[x] + n - 2 * size[y]
                    reroot(y, x)  # x 是 y 的父节点
        reroot(0, -1)  # 0 没有父节点
        return ans
```

```java
class Solution {
    private List<Integer>[] g;
    private int[] ans, size;

    public int[] sumOfDistancesInTree(int n, int[][] edges) {
        g = new ArrayList[n]; // g[x] 表示 x 的所有邻居
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : edges) {
            int x = e[0], y = e[1];
            g[x].add(y);
            g[y].add(x);
        }
        ans = new int[n];
        size = new int[n];
        dfs(0, -1, 0); // 0 没有父节点
        reroot(0, -1); // 0 没有父节点
        return ans;
    }

    private void dfs(int x, int fa, int depth) {
        ans[0] += depth; // depth 为 0 到 x 的距离
        size[x] = 1;
        for (int y : g[x]) { // 遍历 x 的邻居 y
            if (y != fa) { // 避免访问父节点
                dfs(y, x, depth + 1); // x 是 y 的父节点
                size[x] += size[y]; // 累加 x 的儿子 y 的子树大小
            }
        }
    }

    private void reroot(int x, int fa) {
        for (int y : g[x]) { // 遍历 x 的邻居 y
            if (y != fa) { // 避免访问父节点
                ans[y] = ans[x] + g.length - 2 * size[y];
                reroot(y, x); // x 是 y 的父节点
            }
        }
    }
}
```

```cpp
class Solution {
public:
    vector<int> sumOfDistancesInTree(int n, vector<vector<int>> &edges) {
        vector<vector<int>> g(n); // g[x] 表示 x 的所有邻居
        for (auto &e: edges) {
            int x = e[0], y = e[1];
            g[x].push_back(y);
            g[y].push_back(x);
        }

        vector<int> ans(n);
        vector<int> size(n, 1); // 注意这里初始化成 1 了，下面只需要累加儿子的子树大小
        function<void(int, int, int)> dfs = [&](int x, int fa, int depth) {
            ans[0] += depth; // depth 为 0 到 x 的距离
            for (int y: g[x]) { // 遍历 x 的邻居 y
                if (y != fa) { // 避免访问父节点
                    dfs(y, x, depth + 1); // x 是 y 的父节点
                    size[x] += size[y]; // 累加 x 的儿子 y 的子树大小
                }
            }
        };
        dfs(0, -1, 0); // 0 没有父节点

        function<void(int, int)> reroot = [&](int x, int fa) {
            for (int y: g[x]) { // 遍历 x 的邻居 y
                if (y != fa) { // 避免访问父节点
                    ans[y] = ans[x] + n - 2 * size[y];
                    reroot(y, x); // x 是 y 的父节点
                }
            }
        };
        reroot(0, -1); // 0 没有父节点
        return ans;
    }
};
```

```go
func sumOfDistancesInTree(n int, edges [][]int) []int {
    g := make([][]int, n) // g[x] 表示 x 的所有邻居
    for _, e := range edges {
        x, y := e[0], e[1]
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }

    ans := make([]int, n)
    size := make([]int, n)
    var dfs func(int, int, int)
    dfs = func(x, fa, depth int) {
        ans[0] += depth // depth 为 0 到 x 的距离
        size[x] = 1
        for _, y := range g[x] { // 遍历 x 的邻居 y
            if y != fa { // 避免访问父节点
                dfs(y, x, depth+1) // x 是 y 的父节点
                size[x] += size[y] // 累加 x 的儿子 y 的子树大小
            }
        }
    }
    dfs(0, -1, 0) // 0 没有父节点

    var reroot func(int, int)
    reroot = func(x, fa int) {
        for _, y := range g[x] { // 遍历 x 的邻居 y
            if y != fa { // 避免访问父节点
                ans[y] = ans[x] + n - 2*size[y]
                reroot(y, x) // x 是 y 的父节点
            }
        }
    }
    reroot(0, -1) // 0 没有父节点
    return ans
}
```

```javascript
var sumOfDistancesInTree = function (n, edges) {
    let g = Array(n).fill(null).map(() => []); // g[x] 表示 x 的所有邻居
    for (const [x, y] of edges) {
        g[x].push(y);
        g[y].push(x);
    }

    let ans = Array(n).fill(0);
    let size = Array(n).fill(1); // 注意这里初始化成 1 了，下面只需要累加儿子的子树大小
    function dfs(x, fa, depth) {
        ans[0] += depth; // depth 为 0 到 x 的距离
        for (const y of g[x]) { // 遍历 x 的邻居 y
            if (y !== fa) { // 避免访问父节点
                dfs(y, x, depth + 1); // x 是 y 的父节点
                size[x] += size[y]; // 累加 x 的儿子 y 的子树大小
            }
        }
    }
    dfs(0, -1, 0); // 0 没有父节点

    function reroot(x, fa) {
        for (const y of g[x]) { // 遍历 x 的邻居 y
            if (y !== fa) { // 避免访问父节点
                ans[y] = ans[x] + n - 2 * size[y];
                reroot(y, x); // x 是 y 的父节点
            }
        }
    }
    reroot(0, -1); // 0 没有父节点
    return ans;
};
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n)$。DFS 两次，每次 DFS 会递归访问每个节点恰好一次，所以时间复杂度为 $\mathcal{O}(n)$。
-   空间复杂度：$\mathcal{O}(n)$。

#### 思考题

1.  如果只需要算所有点对的距离之和，你能想出一个只需要一次 DFS 的算法吗？
    提示：我在前天的每日一题中讲解了一种技巧，请看[【图解】没有思路？进来秒懂！](https://leetcode.cn/problems/distribute-coins-in-binary-tree/solution/tu-jie-mei-you-si-lu-jin-lai-miao-dong-p-vrni/)
2.  把题目中的「距离之和」改成「距离的平方和」要怎么做？
    提示 1：换根，把「变化量的平方」这个式子展开。
    提示 2：除了计算子树大小，还需要计算子树中的每个节点的深度之和。
3.  改成「距离的立方和」要怎么做？

欢迎在评论区发表你的思路。

#### 练习：换根 DP

-   [310\. 最小高度树](https://leetcode.cn/problems/minimum-height-trees/)（做法不止一种）
-   [2581\. 统计可能的树根数目](https://leetcode.cn/problems/count-number-of-possible-root-nodes/)
-   [Codeforces 771C. Bear and Tree Jumps](https://leetcode.cn/link/?target=https%3A%2F%2Fcodeforces.com%2Fproblemset%2Fproblem%2F771%2FC)（本题进阶版）
