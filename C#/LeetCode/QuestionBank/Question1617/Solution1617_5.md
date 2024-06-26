#### [方法一：枚举子集+树的直径](https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/solutions/2162612/tu-jie-on3-mei-ju-zhi-jing-duan-dian-che-am2n/)

##### 前置知识：子集型回溯

见 [78\. 子集](https://leetcode.cn/problems/subsets/)。

讲解见[【基础算法精讲 14】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1mG4y1A7Gu%2F)。

> APP 用户可以分享到 wx 后打开链接。

##### 前置知识：二叉树的直径

见 [543\. 二叉树的直径](https://leetcode.cn/problems/diameter-of-binary-tree/)。

推荐从这题开始学习树形 DP。

简单来说就是枚举从 $x$ 往左儿子走的最长链和往右儿子走的最长链，这两条链可能会组成直径。枚举所有点作为 $x$ 就能找到答案。

每个节点都需要返回「往左走的最长链长度和往右走的最长链长度的最大值」给父节点，这样父节点才知道往这边走的最长链的长度是多少。

##### 前置知识：树的直径

见 [1245\. 树的直径](https://leetcode.cn/problems/tree-diameter/)。

考虑到这题需要会员，可以做做这些相似题目：

-   [2246\. 相邻字符不同的最长路径](https://leetcode.cn/problems/longest-path-with-different-adjacent-characters/)
-   [2538\. 最大价值和与最小价值和的差值](https://leetcode.cn/problems/difference-between-maximum-and-minimum-price-sum/)

树的直径可以用两次 DFS 或者树形 DP，我在 [周赛 328](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1QT41127kJ%2F) 的第四题讲了树形 DP 的做法，在二叉树直径的基础上略作修改。

##### 思路

本题结合了 78 题和 1245 题：枚举城市的子集（子树），求这棵子树的直径。

需要注意的是，枚举的子集不一定是一棵树，可能是森林（多棵树，多个连通块）。我们可以在计算树形 DP 的同时去统计访问过的点，看看是否与子集相等，只有相等才是一棵树。

```python
class Solution:
    def countSubgraphsForEachDiameter(self, n: int, edges: List[List[int]]) -> List[int]:
        # 建树
        g = [[] for _ in range(n)]
        for x, y in edges:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)  # 编号改为从 0 开始

        ans = [0] * (n - 1)
        in_set = [False] * n
        def f(i: int) -> None:
            if i == n:
                vis = [False] * n
                diameter = 0
                for v, b in enumerate(in_set):
                    if not b: continue
                    # 求树的直径
                    def dfs(x: int) -> int:
                        nonlocal diameter
                        vis[x] = True
                        max_len = 0
                        for y in g[x]:
                            if not vis[y] and in_set[y]:
                                ml = dfs(y) + 1
                                diameter = max(diameter, max_len + ml)
                                max_len = max(max_len, ml)
                        return max_len
                    dfs(v)
                    break
                if diameter and vis == in_set:
                    ans[diameter - 1] += 1
                return
            
            # 不选城市 i
            f(i + 1)

            # 选城市  i
            in_set[i] = True
            f(i + 1)
            in_set[i] = False  # 恢复现场
        f(0)
        return ans
```

```java
class Solution {
    private List<Integer>[] g;
    private boolean[] inSet, vis;
    private int[] ans;
    private int n, diameter;

    public int[] countSubgraphsForEachDiameter(int n, int[][] edges) {
        this.n = n;
        g = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改为从 0 开始
            g[x].add(y);
            g[y].add(x); // 建树
        }

        ans = new int[n - 1];
        inSet = new boolean[n];
        f(0);
        return ans;
    }

    private void f(int i) {
        if (i == n) {
            for (int v = 0; v < n; ++v)
                if (inSet[v]) {
                    vis = new boolean[n];
                    diameter = 0;
                    dfs(v);
                    break;
                }
            if (diameter > 0 && Arrays.equals(vis, inSet))
                ++ans[diameter - 1];
            return;
        }

        // 不选城市 i
        f(i + 1);

        // 选城市 i
        inSet[i] = true;
        f(i + 1);
        inSet[i] = false; // 恢复现场
    }

    // 求树的直径
    private int dfs(int x) {
        vis[x] = true;
        int maxLen = 0;
        for (int y : g[x])
            if (!vis[y] && inSet[y]) {
                int ml = dfs(y) + 1;
                diameter = Math.max(diameter, maxLen + ml);
                maxLen = Math.max(maxLen, ml);
            }
        return maxLen;
    }
}
```

```cpp
class Solution {
public:
    vector<int> countSubgraphsForEachDiameter(int n, vector<vector<int>> &edges) {
        vector<vector<int>> g(n);
        for (auto &e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改为从 0 开始
            g[x].push_back(y);
            g[y].push_back(x); // 建树
        }

        vector<int> ans(n - 1), in_set(n), vis(n);
        int diameter = 0;

        // 求树的直径
        function<int(int)> dfs = [&](int x) -> int {
            vis[x] = true;
            int max_len = 0;
            for (int y : g[x])
                if (!vis[y] && in_set[y]) {
                    int ml = dfs(y) + 1;
                    diameter = max(diameter, max_len + ml);
                    max_len = max(max_len, ml);
                }
            return max_len;
        };

        function<void(int)> f = [&](int i) {
            if (i == n) {
                for (int v = 0; v < n; ++v)
                    if (in_set[v]) {
                        fill(vis.begin(), vis.end(), 0);
                        diameter = 0;
                        dfs(v);
                        break;
                    }
                if (diameter && vis == in_set)
                    ++ans[diameter - 1];
                return;
            }

            // 不选城市 i
            f(i + 1);

            // 选城市 i
            in_set[i] = true;
            f(i + 1);
            in_set[i] = false; // 恢复现场
        };
        f(0);
        return ans;
    }
};
```

```go
func countSubgraphsForEachDiameter(n int, edges [][]int) []int {
    // 建树
    g := make([][]int, n)
    for _, e := range edges {
        x, y := e[0]-1, e[1]-1 // 编号改为从 0 开始
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }

    // 求树的直径
    var inSet, vis [15]bool
    var diameter int
    var dfs func(int) int
    dfs = func(x int) (maxLen int) {
        vis[x] = true
        for _, y := range g[x] {
            if !vis[y] && inSet[y] {
                ml := dfs(y) + 1
                diameter = max(diameter, maxLen+ml)
                maxLen = max(maxLen, ml)
            }
        }
        return
    }

    ans := make([]int, n-1)
    var f func(int)
    f = func(i int) {
        if i == n {
            for v, b := range inSet {
                if b {
                    vis, diameter = [15]bool{}, 0
                    dfs(v)
                    break
                }
            }
            if diameter > 0 && vis == inSet {
                ans[diameter-1]++
            }
            return
        }

        // 不选城市 i
        f(i + 1)

        // 选城市 i
        inSet[i] = true
        f(i + 1)
        inSet[i] = false // 恢复现场
    }
    f(0)
    return ans
}

func max(a, b int) int { if a < b { return b }; return a }
```

##### 复杂度分析

-   时间复杂度：$O(n2^n)$。$O(2^n)$ 枚举子集，$O(n)$ 求直径，所以时间复杂度为 $O(n2^n)$。
-   空间复杂度：$O(n)$。

#### [方法二：二进制枚举](https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/solutions/2162612/tu-jie-on3-mei-ju-zhi-jing-duan-dian-che-am2n/)

这个做法相当于对方法一的优化。

集合/布尔数组可以用二进制表示，二进制从低到高第 $i$ 位为 111 表示 $i$ 在集合中，为 000 表示 $i$ 不在集合中，例如集合 {0,2,3}\\{0,2,3\\}{0,2,3} 对应的二进制数为 1101(2)1101\_{(2)}1101(2)。

```python
class Solution:
    def countSubgraphsForEachDiameter(self, n: int, edges: List[List[int]]) -> List[int]:
        # 建树
        g = [[] for _ in range(n)]
        for x, y in edges:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)  # 编号改为从 0 开始

        ans = [0] * (n - 1)
        #  二进制枚举
        for mask in range(3, 1 << n):
            if (mask & (mask - 1)) == 0:  # 需要至少两个点
                continue
            # 求树的直径
            vis = diameter = 0
            def dfs(x: int) -> int:
                nonlocal vis, diameter
                vis |= 1 << x  # 标记 x 访问过
                max_len = 0
                for y in g[x]:
                    if (vis >> y & 1) == 0 and mask >> y & 1:  # y 没有访问过且在 mask 中
                        ml = dfs(y) + 1
                        diameter = max(diameter, max_len + ml)
                        max_len = max(max_len, ml)
                return max_len
            dfs(mask.bit_length() - 1)  # 从一个在 mask 中的点开始递归
            if vis == mask:
                ans[diameter - 1] += 1
        return ans
```

```java
class Solution {
    private List<Integer>[] g;
    private int mask, vis, diameter;

    public int[] countSubgraphsForEachDiameter(int n, int[][] edges) {
        g = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改为从 0 开始
            g[x].add(y);
            g[y].add(x); // 建树
        }

        var ans = new int[n - 1];
        // 二进制枚举
        for (mask = 3; mask < 1 << n; ++mask) {
            if ((mask & (mask - 1)) == 0) continue; // 需要至少两个点
            vis = diameter = 0;
            dfs(Integer.numberOfTrailingZeros(mask)); // 从一个在 mask 中的点开始递归
            if (vis == mask)
                ++ans[diameter - 1];
        }
        return ans;
    }

    // 求树的直径
    private int dfs(int x) {
        vis |= 1 << x; // 标记 x 访问过
        int maxLen = 0;
        for (int y : g[x])
            if ((vis >> y & 1) == 0 && (mask >> y & 1) == 1) { // y 没有访问过且在 mask 中
                int ml = dfs(y) + 1;
                diameter = Math.max(diameter, maxLen + ml);
                maxLen = Math.max(maxLen, ml);
            }
        return maxLen;
    }
}
```

```cpp
class Solution {
public:
    vector<int> countSubgraphsForEachDiameter(int n, vector<vector<int>> &edges) {
        vector<vector<int>> g(n);
        for (auto &e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改为从 0 开始
            g[x].push_back(y);
            g[y].push_back(x); // 建树
        }

        vector<int> ans(n - 1);
        // 二进制枚举
        for (int mask = 3; mask < 1 << n; ++mask) {
            if ((mask & (mask - 1)) == 0) continue; // 需要至少两个点
            // 求树的直径
            int vis = 0, diameter = 0;
            function<int(int)> dfs = [&](int x) -> int {
                vis |= 1 << x; // 标记 x 访问过
                int max_len = 0;
                for (int y : g[x])
                    if ((vis >> y & 1) == 0 && mask >> y & 1) { // y 没有访问过且在 mask 中
                        int ml = dfs(y) + 1;
                        diameter = max(diameter, max_len + ml);
                        max_len = max(max_len, ml);
                    }
                return max_len;
            };
            dfs(__builtin_ctz(mask)); // 从一个在 mask 中的点开始递归
            if (vis == mask)
                ++ans[diameter - 1];
        }
        return ans;
    }
};
```

```go
func countSubgraphsForEachDiameter(n int, edges [][]int) []int {
    // 建树
    g := make([][]int, n)
    for _, e := range edges {
        x, y := e[0]-1, e[1]-1 // 编号改为从 0 开始
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }

    ans := make([]int, n-1)
    // 二进制枚举
    for mask := 3; mask < 1<<n; mask++ {
        if mask&(mask-1) == 0 { // 需要至少两个点
            continue
        }
        // 求树的直径
        vis, diameter := 0, 0
        var dfs func(int) int
        dfs = func(x int) (maxLen int) {
            vis |= 1 << x // 标记 x 访问过
            for _, y := range g[x] {
                if vis>>y&1 == 0 && mask>>y&1 > 0 { // y 没有访问过且在 mask 中
                    ml := dfs(y) + 1
                    diameter = max(diameter, maxLen+ml)
                    maxLen = max(maxLen, ml)
                }
            }
            return
        }
        dfs(bits.TrailingZeros(uint(mask))) // 从一个在 mask 中的点开始递归
        if vis == mask {
            ans[diameter-1]++
        }
    }
    return ans
}

func max(a, b int) int { if a < b { return b }; return a }
```

##### 复杂度分析

-   时间复杂度：$O(n2^n)$。$O(2^n)$ 枚举子集，$O(n)$ 求直径，所以时间复杂度为 $O(n2^n)$。
-   空间复杂度：$O(n)$。

#### [方法三：枚举直径端点+乘法原理](https://leetcode.cn/problems/count-subtrees-with-max-distance-between-cities/solutions/2162612/tu-jie-on3-mei-ju-zhi-jing-duan-dian-che-am2n/)

##### 前置知识：树的深度

见[【基础算法精讲 09】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1UD4y1Y769%2F)。

##### 前置知识：乘法原理

见 [乘法原理](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E4%B9%98%E6%B3%95%E5%8E%9F%E7%90%86%2F7538447)。

##### 思路

暴力枚举 $i$ 和 $j$ 作为直径的两个端点 ，那么从 $i$ 到 $j$ 的这条简单路径是直径，这上面的每个点都必须选。

还有哪些点是可以选的？

![](./assets/img/Solution1617_5_01.png)

为了计算树上任意两点的距离 $dis$，枚举 $i$ 作为树的根，计算 $i$ 到其余点的距离。这通常用 BFS 来做，但是对于树来说，任意两点的简单路径是唯一的，所以 DFS 也可以。

那么通过 $n$ 次 DFS，就可以得到树上任意两点的距离了。

##### 答疑

**问**：还有类似的「需要避免重复统计」的题目吗？

**答**：例如 [15\. 三数之和](https://leetcode.cn/problems/3sum/)、[90\. 子集 II](https://leetcode.cn/problems/subsets-ii/) 等。

```python
class Solution:
    def countSubgraphsForEachDiameter(self, n: int, edges: List[List[int]]) -> List[int]:
        # 建树
        g = [[] for _ in range(n)]
        for x, y in edges:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)  # 编号改为从 0 开始

        # 计算树上任意两点的距离
        dis = [[0] * n for _ in range(n)]
        def dfs(x: int, fa: int) -> None:
            for y in g[x]:
                if y != fa:
                    dis[i][y] = dis[i][x] + 1  # 自顶向下
                    dfs(y, x)
        for i in range(n):
            dfs(i, -1)  # 计算 i 到其余点的距离

        def dfs2(x: int, fa: int) -> int:
            # 能递归到这，说明 x 可以选
            cnt = 1  # 选 x
            for y in g[x]:
                if y != fa and \
                   (di[y] < d or di[y] == d and y > j) and \
                   (dj[y] < d or dj[y] == d and y > i):  # 满足这些条件就可以选
                    cnt *= dfs2(y, x)  # 每棵子树互相独立，采用乘法原理
            if di[x] + dj[x] > d:  # x 是可选点
                cnt += 1  # 不选 x
            return cnt
        ans = [0] * (n - 1)
        for i, di in enumerate(dis):
            for j in range(i + 1, n):
                dj = dis[j]
                d = di[j]
                ans[d - 1] += dfs2(i, -1)
        return ans
```

```java
class Solution {
    private List<Integer>[] g;
    private int[][] dis;

    public int[] countSubgraphsForEachDiameter(int n, int[][] edges) {
        g = new ArrayList[n];
        Arrays.setAll(g, e -> new ArrayList<>());
        for (var e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改为从 0 开始
            g[x].add(y);
            g[y].add(x); // 建树
        }

        dis = new int[n][n];
        for (int i = 0; i < n; ++i)
            dfs(i, i, -1); // 计算 i 到其余点的距离

        var ans = new int[n - 1];
        for (int i = 0; i < n; ++i)
            for (int j = i + 1; j < n; ++j)
                ans[dis[i][j] - 1] += dfs2(i, j, dis[i][j], i, -1);
        return ans;
    }

    private void dfs(int i, int x, int fa) {
        for (int y : g[x])
            if (y != fa) {
                dis[i][y] = dis[i][x] + 1; // 自顶向下
                dfs(i, y, x);
            }
    }

    private int dfs2(int i, int j, int d, int x, int fa) {
        // 能递归到这，说明 x 可以选
        int cnt = 1; // 选 x
        for (int y : g[x])
            if (y != fa &&
               (dis[i][y] < d || dis[i][y] == d && y > j) &&
               (dis[j][y] < d || dis[j][y] == d && y > i)) // 满足这些条件就可以选
                cnt *= dfs2(i, j, d, y, x); // 每棵子树互相独立，采用乘法原理
        if (dis[i][x] + dis[j][x] > d)  // x 是可选点
            ++cnt; // 不选 x
        return cnt;
    }
}
```

```cpp
class Solution {
public:
    vector<int> countSubgraphsForEachDiameter(int n, vector<vector<int>> &edges) {
        vector<vector<int>> g(n);
        for (auto &e : edges) {
            int x = e[0] - 1, y = e[1] - 1; // 编号改为从 0 开始
            g[x].push_back(y);
            g[y].push_back(x); // 建树
        }

        int dis[n][n]; memset(dis, 0, sizeof(dis));
        function<void(int, int, int)> dfs = [&](int i, int x, int fa) {
            for (int y : g[x])
                if (y != fa) {
                    dis[i][y] = dis[i][x] + 1; // 自顶向下
                    dfs(i, y, x);
                }
        };
        for (int i = 0; i < n; ++i)
            dfs(i, i, -1); // 计算 i 到其余点的距离

        function<int(int, int, int, int, int)> dfs2 = [&](int i, int j, int d, int x, int fa) {
            // 能递归到这，说明 x 可以选
            int cnt = 1; // 选 x
            for (int y : g[x])
                if (y != fa &&
                   (dis[i][y] < d || dis[i][y] == d && y > j) &&
                   (dis[j][y] < d || dis[j][y] == d && y > i)) // 满足这些条件就可以选
                    cnt *= dfs2(i, j, d, y, x); // 每棵子树互相独立，采用乘法原理
            if (dis[i][x] + dis[j][x] > d)  // x 是可选点
                ++cnt; // 不选 x
            return cnt;
        };
        vector<int> ans(n - 1);
        for (int i = 0; i < n; ++i)
            for (int j = i + 1; j < n; ++j)
                ans[dis[i][j] - 1] += dfs2(i, j, dis[i][j], i, -1);
        return ans;
    }
};
```

```go
func countSubgraphsForEachDiameter(n int, edges [][]int) []int {
    // 建树
    g := make([][]int, n)
    for _, e := range edges {
        x, y := e[0]-1, e[1]-1 // 编号改为从 0 开始
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }

    // 计算树上任意两点的距离
    dis := make([][]int, n)
    for i := range dis {
        // 计算 i 到其余点的距离
        dis[i] = make([]int, n)
        var dfs func(int, int)
        dfs = func(x, fa int) {
            for _, y := range g[x] {
                if y != fa {
                    dis[i][y] = dis[i][x] + 1 // 自顶向下
                    dfs(y, x)
                }
            }
        }
        dfs(i, -1)
    }

    ans := make([]int, n-1)
    for i, di := range dis {
        for j := i + 1; j < n; j++ {
            dj := dis[j]
            d := di[j]
            var dfs func(int, int) int
            dfs = func(x, fa int) int {
                // 能递归到这，说明 x 可以选
                cnt := 1 // 选 x
                for _, y := range g[x] {
                    if y != fa &&
                       (di[y] < d || di[y] == d && y > j) &&
                       (dj[y] < d || dj[y] == d && y > i) { // 满足这些条件就可以选
                        cnt *= dfs(y, x) // 每棵子树互相独立，采用乘法原理
                    }
                }
                if di[x]+dj[x] > d { // x 是可选点
                    cnt++ // 不选 x
                }
                return cnt
            }
            ans[d-1] += dfs(i, -1)
        }
    }
    return ans
}
```

##### 复杂度分析

-   时间复杂度：$O(n^3)$。$O(n^2)$ 枚举直径端点，$O(n)$ 计算方案数，所以时间复杂度为 $O(n^3)$。
-   空间复杂度：$O(n^2)$。
