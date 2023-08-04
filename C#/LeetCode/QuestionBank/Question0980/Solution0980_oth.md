### [两种方法：回溯/状态压缩+记忆化搜索（Python/Java/C++/Go/JS）](https://leetcode.cn/problems/unique-paths-iii/solutions/2372252/liang-chong-fang-fa-hui-su-zhuang-tai-ya-26py/)

#### 前言

写这篇题解的时候，突然想起十年前在b站看到一个计算「不相交路径」的 [动画短篇](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1vx411F7R9%2F)，推荐大家先看看（~谜之感动~

#### 方法一：回溯

#### 前置知识：回溯

请看[【基础算法精讲 14】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1mG4y1A7Gu%2F)。

#### 算法

定义 $dfs(x,y,left)$ 表示从 $(x,y)$ 出发，还剩下 $left$ 个无障碍方格（不含终点）需要访问时的不同路径个数：

-   如果出界，或者 $grid[x][y]=-1$，则返回 $0$，表示不合法的路径。
-   如果 $grid[x][y]=2$，说明到达终点。如果此时 $left=0$ 则返回 $1$ 表示找到了一条合法路径；否则返回 $0$ 表示不合法的路径。
-   否则向上下左右移动，累加四个方向递归的返回值。
-   代码实现时，可以把 $grid[x][y]$ 改成 $-1$，表示这个格子访问过，在返回前改回 $0$（恢复现场）。

设起点为 $(sx,sy)$，$grid$ 中有 $cnt_0$ 个 $0$，那么递归入口为 $dfs(sx,sy, cnt_0+1)$，这里 $+1$ 是把起点这个格子也算上。

注意不存在中途经过终点的情况，因为题目要求「一条路径中不能重复通过同一个方格」，终点也必须只访问一次。（如果感觉题意不清楚可以看英文描述。）

```python
class Solution:
    def uniquePathsIII(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])

        def dfs(x: int, y: int, left: int) -> int:
            if x < 0 or x >= m or y < 0 or y >= n or grid[x][y] < 0:
                return 0  # 不合法
            if grid[x][y] == 2:  # 到达终点
                return left == 0  # 必须访问所有的无障碍方格
            grid[x][y] = -1  # 标记成访问过，因为题目要求「不能重复通过同一个方格」
            ans = dfs(x - 1, y, left - 1) + dfs(x, y - 1, left - 1) + \
                  dfs(x + 1, y, left - 1) + dfs(x, y + 1, left - 1)
            grid[x][y] = 0  # 恢复现场
            return ans

        cnt0 = sum(row.count(0) for row in grid)
        for i, row in enumerate(grid):
            for j, v in enumerate(row):
                if v == 1:  # 起点
                    return dfs(i, j, cnt0 + 1)  # +1 把起点也算上
```

```java
class Solution {
    public int uniquePathsIII(int[][] grid) {
        int cnt0 = 0, sx = -1, sy = -1;
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[i].length; j++) {
                if (grid[i][j] == 0) cnt0++;
                else if (grid[i][j] == 1) { // 起点
                    sx = i;
                    sy = j;
                }
            }
        }
        return dfs(grid, sx, sy, cnt0 + 1); // +1 把起点也算上
    }

    private int dfs(int[][] grid, int x, int y, int left) {
        if (x < 0 || x >= grid.length || y < 0 || y >= grid[x].length || grid[x][y] < 0)
            return 0; // 不合法
        if (grid[x][y] == 2) // 到达终点
            return left == 0 ? 1 : 0; // 必须访问所有的无障碍方格
        grid[x][y] = -1; // 标记成访问过，因为题目要求「不能重复通过同一个方格」
        int ans = dfs(grid, x - 1, y, left - 1) + dfs(grid, x, y - 1, left - 1) +
                  dfs(grid, x + 1, y, left - 1) + dfs(grid, x, y + 1, left - 1);
        grid[x][y] = 0; // 恢复现场
        return ans;
    }
}
```

```cpp
class Solution {
    int dfs(vector<vector<int>> &grid, int x, int y, int left) {
        if (x < 0 || x >= grid.size() || y < 0 || y >= grid[x].size() || grid[x][y] < 0)
            return 0; // 不合法
        if (grid[x][y] == 2) // 到达终点
            return left == 0; // 必须访问所有的无障碍方格
        grid[x][y] = -1; // 标记成访问过，因为题目要求「不能重复通过同一个方格」
        int ans = dfs(grid, x - 1, y, left - 1) + dfs(grid, x, y - 1, left - 1) +
                  dfs(grid, x + 1, y, left - 1) + dfs(grid, x, y + 1, left - 1);
        grid[x][y] = 0; // 恢复现场
        return ans;
    }

public:
    int uniquePathsIII(vector<vector<int>> &grid) {
        int m = grid.size(), n = grid[0].size(), cnt0 = 0, sx, sy;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) cnt0++;
                else if (grid[i][j] == 1) sx = i, sy = j; // 起点
            }
        }
        return dfs(grid, sx, sy, cnt0 + 1); // +1 把起点也算上
    }
};
```

```go
func uniquePathsIII(grid [][]int) int {
    var cnt0, sx, sy int
    for i, row := range grid {
        for j, x := range row {
            if x == 0 {
                cnt0++
            } else if x == 1 { // 起点
                sx, sy = i, j
            }
        }
    }

    var dfs func(int, int, int) int
    dfs = func(x, y, left int) int {
        if x < 0 || x >= len(grid) || y < 0 || y >= len(grid[x]) || grid[x][y] < 0 {
            return 0 // 不合法
        }
        if grid[x][y] == 2 { // 到达终点
            if left == 0 { // 必须访问所有的无障碍方格
                return 1 // 找到了一条合法路径
            }
            return 0 // 不合法
        }
        grid[x][y] = -1 // 标记成访问过，因为题目要求「不能重复通过同一个方格」
        defer func() { grid[x][y] = 0 }() // 恢复现场
        return dfs(x-1, y, left-1) + dfs(x, y-1, left-1) +
               dfs(x+1, y, left-1) + dfs(x, y+1, left-1)
    }
    return dfs(sx, sy, cnt0+1) // +1 把起点也算上
}
```

```javascript
var uniquePathsIII = function (grid) {
    const m = grid.length, n = grid[0].length;
    let cnt0 = 0, sx = -1, sy = -1;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] === 0) cnt0++;
            else if (grid[i][j] === 1) sx = i, sy = j; // 起点
        }
    }

    function dfs(x, y, left) {
        if (x < 0 || x >= m || y < 0 || y >= n || grid[x][y] < 0)
            return 0; // 不合法
        if (grid[x][y] === 2) // 到达终点
            return left === 0; // 必须访问所有的无障碍方格
        grid[x][y] = -1; // 标记成访问过，因为题目要求「不能重复通过同一个方格」
        const ans = dfs(x - 1, y, left - 1) + dfs(x, y - 1, left - 1) +
                    dfs(x + 1, y, left - 1) + dfs(x, y + 1, left - 1);
        grid[x][y] = 0; // 恢复现场
        return ans;
    }
    return dfs(sx, sy, cnt0 + 1); // +1 把起点也算上
};
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(3^{mn})$，其中 $m$ 和 $n$ 分别为 $grid$ 的行数和列数。搜索树的高度为 $\mathcal{O}(mn)$，除了根节点以外，其余节点至多有 $3$ 个儿子（因为不能往回走），所以这棵搜索树至多有 $\mathcal{O}(3^{mn})$ 个节点。由于不能重复访问同一个格子，实际节点个数远小于这里估计的上界。
-   空间复杂度：$\mathcal{O}(mn)$。递归需要 $\mathcal{O}(mn)$ 的栈空间。

#### 相似题目

-   [79\. 单词搜索](https://leetcode.cn/problems/word-search/)

#### 方法二：状态压缩+记忆化搜索

#### 前置知识

-   [从集合论到位运算，常见位运算技巧分类总结！](https://leetcode.cn/circle/discuss/CaOJ45/)
-   [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)

#### 算法

整体思路和方法一类似，区别主要在位运算上（请先看前置知识中的位运算文章）。

-   用二进制数 $vis$ 表示访问过的格子的坐标集合，替换方法一中的递归参数 $left$。我们在递归中去修改 $vis$，不去修改 $grid[x][y]$，做到无后效性，从而可以使用记忆化搜索。
-   为了方便用位运算实现，可以把二维坐标 $(x,y)$ 映射为整数 $nx+y$。如果访问了 $(x,y)$，就把 $vis$ 从低到高第 $nx+y$ 个比特位标记成 $1$。
-   为了方便判断，可以在递归前把障碍方格也加到 $vis$ 中，这样递归到终点时，只需要判断 $vis$ 是否为全集 $all$，即所有格子的坐标集合。

另外，由于有大量状态是无法访问到的，相比数组，用哈希表记忆化更好。

注：实际上，并没有太多重复递归调用，使用哈希表反而拖慢了速度，方法一可能更快。

```python
class Solution:
    def uniquePathsIII(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        ALL = (1 << m * n) - 1  # 全集（所有格子的坐标集合）

        @cache
        def dfs(x: int, y: int, vis: int) -> int:
            if x < 0 or x >= m or y < 0 or y >= n or vis >> (x * n + y) & 1:
                return 0  # 不合法
            vis |= 1 << (x * n + y)  # 标记访问过 (x,y)，因为题目要求「不能重复通过同一个方格」
            if grid[x][y] == 2:  # 到达终点
                return vis == ALL  # 必须访问所有的无障碍方格
            return dfs(x - 1, y, vis) + dfs(x, y - 1, vis) + \
                   dfs(x + 1, y, vis) + dfs(x, y + 1, vis)

        vis = 0
        for i, row in enumerate(grid):
            for j, v in enumerate(row):
                if v < 0:  # 把障碍方格算上
                    vis |= 1 << (i * n + j)
                elif v == 1:  # 起点
                    sx, sy = i, j
        return dfs(sx, sy, vis)
```

```java
class Solution {
    private Map<Integer, Integer> memo = new HashMap<>();

    public int uniquePathsIII(int[][] grid) {
        int n = grid[0].length, vis = 0, sx = -1, sy = -1;
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] < 0) // 把障碍方格算上
                    vis |= 1 << (i * n + j);
                else if (grid[i][j] == 1) { // 起点
                    sx = i;
                    sy = j;
                }
            }
        }
        return dfs(grid, sx, sy, vis);
    }

    private int dfs(int[][] grid, int x, int y, int vis) {
        int m = grid.length, n = grid[0].length;
        int p = x * n + y;
        if (x < 0 || x >= m || y < 0 || y >= n || (vis >> p & 1) > 0)
            return 0; // 不合法
        vis |= 1 << p; // 标记访问过 (x,y)，因为题目要求「不能重复通过同一个方格」
        if (grid[x][y] == 2) // 到达终点
            return vis == (1 << m * n) - 1 ? 1 : 0; // 必须访问所有的无障碍方格
        int key = (p << m * n) | vis; // 把参数压缩成一个整数（左移 m*n 是因为 vis 至多有 m*n 个比特）
        if (memo.containsKey(key)) return memo.get(key); // 之前算过
        int ans = dfs(grid, x - 1, y, vis) + dfs(grid, x, y - 1, vis) +
                  dfs(grid, x + 1, y, vis) + dfs(grid, x, y + 1, vis);
        memo.put(key, ans);
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int uniquePathsIII(vector<vector<int>> &grid) {
        int m = grid.size(), n = grid[0].size(), vis = 0, sx, sy;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] < 0) vis |= 1 << (i * n + j); // 把障碍方格算上
                else if (grid[i][j] == 1) sx = i, sy = j; // 起点
            }
        }

        int all = (1 << m * n) - 1;  // 全集（所有格子的坐标集合）
        unordered_map<int, int> memo;
        function<int(int, int, int)> dfs = [&](int x, int y, int vis) -> int {
            int p = x * n + y;
            if (x < 0 || x >= m || y < 0 || y >= n || vis >> p & 1)
                return 0; // 不合法
            vis |= 1 << p; // 标记访问过 (x,y)，因为题目要求「不能重复通过同一个方格」
            if (grid[x][y] == 2) // 到达终点
                return vis == all; // 必须访问所有的无障碍方格
            int key = (p << m * n) | vis; // 把参数压缩成一个整数（左移 m*n 是因为 vis 至多有 m*n 个比特）
            if (memo.count(key)) return memo[key]; // 之前算过
            return memo[key] = dfs(x - 1, y, vis) + dfs(x, y - 1, vis) +
                               dfs(x + 1, y, vis) + dfs(x, y + 1, vis);
        };
        return dfs(sx, sy, vis);
    }
};
```

```go
func uniquePathsIII(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    var vis, sx, sy int
    for i, row := range grid {
        for j, x := range row {
            if x < 0 { // 把障碍方格算上
                vis |= 1 << (i*n + j)
            } else if x == 1 { // 起点
                sx, sy = i, j
            }
        }
    }

    all := 1<<(m*n) - 1
    type data struct{ x, y, vis int }
    memo := map[data]int{}
    var dfs func(int, int, int) int
    dfs = func(x, y, vis int) int {
        p := x*n + y
        if x < 0 || x >= m || y < 0 || y >= n || vis>>p&1 > 0 {
            return 0 // 不合法
        }
        vis |= 1 << p // 标记访问过 (x,y)，因为题目要求「不能重复通过同一个方格」
        if grid[x][y] == 2 { // 到达终点
            if vis == all { // 必须访问所有的无障碍方格
                return 1 // 找到了一条合法路径
            }
            return 0 // 不合法
        }
        d := data{x, y, vis}
        if v, ok := memo[d]; ok { // 之前算过
            return v
        }
        ans := dfs(x-1, y, vis) + dfs(x, y-1, vis) +
               dfs(x+1, y, vis) + dfs(x, y+1, vis)
        memo[d] = ans // 记忆化
        return ans
    }
    return dfs(sx, sy, vis)
}
```

```javescript
var uniquePathsIII = function (grid) {
    const m = grid.length, n = grid[0].length;
    let vis = 0, sx = -1, sy = -1;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] < 0) vis |= 1 << (i * n + j); // 把障碍方格算上
            else if (grid[i][j] === 1) sx = i, sy = j; // 起点
        }
    }

    const all = (1 << m * n) - 1;  // 全集（所有格子的坐标集合）
    let memo = new Map();
    function dfs(x, y, vis) {
        const p = x * n + y;
        if (x < 0 || x >= m || y < 0 || y >= n || vis >> p & 1)
            return 0; // 不合法
        vis |= 1 << p; // 标记访问过 (x,y)，因为题目要求「不能重复通过同一个方格」
        if (grid[x][y] === 2) // 到达终点
            return vis === all; // 必须访问所有的无障碍方格
        const key = (p << m * n) | vis; // 把参数压缩成一个整数（左移 m*n 是因为 vis 至多有 m*n 个比特）
        if (memo.has(key)) return memo.get(key); // 之前算过
        const ans = dfs(x - 1, y, vis) + dfs(x, y - 1, vis) +
                    dfs(x + 1, y, vis) + dfs(x, y + 1, vis);
        memo.set(key, ans);
        return ans;
    }
    return dfs(sx, sy, vis);
};
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(mn2^{mn})$，其中 $m$ 和 $n$ 分别为 $grid$ 的行数和列数。动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题中状态个数等于 $\mathcal{O}(mn2^{mn})$，单个状态的计算时间为 $\mathcal{O}(1)$，因此时间复杂度为 $\mathcal{O}(mn2^{mn})$。由于很多状态无法访问到，实际时间远小于这里估计的上界。
-   空间复杂度：$\mathcal{O}(mn2^{mn})$。
