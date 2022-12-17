#### 题目分析

「离陆地区域最远」要求海洋区域距离它最近的陆地区域的曼哈顿距离是最大的。所以我们需要找一个海洋区域，满足它到陆地的最小距离是最大的。

#### [方法一：广度优先搜索](https://leetcode.cn/problems/as-far-from-land-as-possible/solutions/147423/di-tu-fen-xi-by-leetcode-solution/)

**思路**

考虑最朴素的方法，即求出每一个海洋区域（`grid[i][j] == 0` 的区域）的「最近陆地区域」，然后记录下它们的距离，然后在这些距离里面取一个最大值。

![](./assets/img/Solution1162_3.gif)

对于一个给定的区域 $(x, y)$ ，求它的「最近陆地区域」，可以使用广度优先搜索思想。我们把每个区域的坐标作以及这个区域与 $(x, y)$ 的曼哈顿距离为搜索状态，即 `Coordinate` 结构体的 `x`、`y` 和 `step` 属性。`findNearestLand` 方法实现了广度优先搜索的过程，我们用一个 `vis[u][v]` 数组记录 $(u, v)$ 区域是否被访问过，在拓展新状态的时候按照如下四个方向：
-   $(x - 1, y)$
-   $(x, y + 1)$
-   $(x + 1, y)$
-   $(x, y - 1)$

在这里我们可以把四个方向定义为常量增量数组 `dx` 和 `dy`。

**思考：我们需不需要搜索到队列为空才停止 BFS ？** 答案是不需要。当我们搜索到一个新入队的区域它的 `grid` 值为 `1`，即这个区域是陆地区域的时候我们就可以停止搜索，因为 BFS 能保证当前的这个区域是最近的陆地区域（BFS 的性质决定了这里求出来的一定是最短路）。

`findNearestLand`如果我们找不不到任何一个点是陆地区域则返回 `-1`。最终我们把 `ans` 的初始值置为 `-1`，然后与所有的 BFS 结果取最大。

代码实现如下。

**代码实现**

```cpp
class Solution {
public:
    static constexpr int dx[4] = {-1, 0, 1, 0}, dy[4] = {0, 1, 0, -1};
    static constexpr int MAX_N = 100 + 5;

    struct Coordinate {
        int x, y, step;
    };

    int n, m;
    vector<vector<int>> a;

    bool vis[MAX_N][MAX_N];

    int findNearestLand(int x, int y) {
        memset(vis, 0, sizeof vis);
        queue <Coordinate> q;
        q.push({x, y, 0});
        vis[x][y] = 1;
        while (!q.empty()) {
            auto f = q.front(); q.pop();
            for (int i = 0; i < 4; ++i) {
                int nx = f.x + dx[i], ny = f.y + dy[i];
                if (!(nx >= 0 && nx <= n - 1 && ny >= 0 && ny <= m - 1)) {
                    continue;
                }
                if (!vis[nx][ny]) {
                    q.push({nx, ny, f.step + 1});
                    vis[nx][ny] = 1;
                    if (a[nx][ny]) {
                        return f.step + 1;
                    }
                }
            }
        }
        return -1;
    }
    
    int maxDistance(vector<vector<int>>& grid) {
        this->n = grid.size();
        this->m = grid.at(0).size();
        a = grid;
        int ans = -1;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if (!a[i][j]) {
                    ans = max(ans, findNearestLand(i, j));
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    static int[] dx = {-1, 0, 1, 0};
    static int[] dy = {0, 1, 0, -1};
    int n;
    int[][] grid;

    public int maxDistance(int[][] grid) {
        this.n = grid.length;
        this.grid = grid;
        int ans = -1;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    ans = Math.max(ans, findNearestLand(i, j));
                }
            }
        }
        return ans;
    }

    public int findNearestLand(int x, int y) {
        boolean[][] vis = new boolean[n][n];
        Queue<int[]> queue = new LinkedList<int[]>();
        queue.offer(new int[]{x, y, 0});
        vis[x][y] = true;
        while (!queue.isEmpty()) {
            int[] f = queue.poll();
            for (int i = 0; i < 4; ++i) {
                int nx = f[0] + dx[i], ny = f[1] + dy[i];
                if (!(nx >= 0 && nx < n && ny >= 0 && ny < n)) {
                    continue;
                }
                if (!vis[nx][ny]) {
                    queue.offer(new int[]{nx, ny, f[2] + 1});
                    vis[nx][ny] = true;
                    if (grid[nx][ny] == 1) {
                        return f[2] + 1;
                    }
                }
            }
        }
        return -1;
    }
}
```

**复杂度分析**

-   时间复杂度：该算法最多执行 $n^2$ 次 BFS，即我们考虑最坏情况所有的区域都是海洋，那么每一个区域都会进行 BFS。对于每一次 BFS，最坏的情况是找不到陆地区域，我们只能遍历完剩下的 $n^2 - 1$ 个海洋区域，由于 `vis` 数组确保每个区域只被访问一次，所以单次 BFS 的渐进时间复杂度是 $O(n^2)$，程序的总的渐进时间复杂度是 $O(n^4)$。
-   空间复杂度：该算法使用了 `vis` 数组，渐进空间复杂度为 $O(n^2)$。
