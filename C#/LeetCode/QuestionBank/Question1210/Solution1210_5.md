﻿#### [还在 if-else？一个循环处理六种移动！（Python/Java/C++/Go）](https://leetcode.cn/problems/minimum-moves-to-reach-target-with-rotations/solutions/2093126/huan-zai-if-elseyi-ge-xun-huan-chu-li-li-tw8b/)

本题相当于在网格图上求起点到终点的最短路长度，这可以用 BFS 解决。相比一般的网格图 BFS（例如 [1926 题](https://leetcode.cn/problems/nearest-exit-from-entrance-in-maze/)），本题多了个「水平／竖直状态」，这可以通过添加一个维度来解决，也就是用 $(x,y,s)$ 表示**蛇尾**在第 $x$ 行第 $y$ 列，$s=0$ 表示水平状态，$s=1$ 表示竖直状态。这样初始位置为 $(0,0,0)$，最终位置为 $(n−1,n−2,0)$。

一些同学在写代码时，会写出很多的 if-else，对这 $6$ 种移动方式分别编程：

-   水平状态：向下移动／向右移动／顺时针旋转 $90$ 度。
-   竖直状态：向下移动／向右移动／逆时针旋转 $90$ 度。

代码越长，就越容易出 bug。能否总结出这 $6$ 种移动方式的异同，用同一份代码解决呢？

无论是水平状态还是竖直状态：

-   向下移动：$x$ 增加 $1$，$y$ 和 $s$ 不变。用三元组 $(1,0,0)$ 表示。
-   向右移动：$y$ 增加 $1$，$x$ 和 $s$ 不变。用三元组 $(0,1,0)$ 表示。
-   旋转：$s$ **切换**，即 $0$ 变为 $1$，$1$ 变为 $0$；$x$ 和 $y$ 不变。用三元组 $(0,0,1)$ 表示。

三元组中的数字表示 $(x,y,s)$ 每个值对应的**变化量**。对于旋转可以用异或运算解决。

这样就能把 $6$ 种移动方式用 $3$ 个三元组表示了。把这 $3$ 个三元组存到数组 $dirs$ 中，遍历 $dirs$，**用同一份代码处理不同的移动**，这样就不用对每种移动各写一份代码了。

最后，还需要判断：

-   移动后蛇身不能出界。
-   移动后蛇身不能在障碍物上。
-   对于旋转，还需要保证 $(x+1,y+1)$ 没有障碍物。

蛇尾在 $(x,y)$，蛇头呢？如果 $s=0$，蛇头在 $(x,y+1)$；如果 $s=1$，蛇头在 $(x+1,y)$。也可以合并为一个公式表示蛇头：

$$(x+s,y+(s \oplus 1))$$

其中 $\oplus$ 表示异或运算。

```python
class Solution:
    def minimumMoves(self, g: List[List[int]]) -> int:
        step, n = 1, len(g)
        vis = {(0, 0, 0)}
        q = [(0, 0, 0)]  # 初始位置
        while q:
            tmp = q
            q = []
            for X, Y, S in tmp:
                for t in (X + 1, Y, S), (X, Y + 1, S), (X, Y, S ^ 1):  # 直接把移动后的位置算出来
                    x, y, s = t
                    x2, y2 = x + s, y + (s ^ 1)  # 蛇头
                    if x2 < n and y2 < n and t not in vis and \
                       g[x][y] == 0 and g[x2][y2] == 0 and (s == S or g[x + 1][y + 1] == 0):
                        if x == n - 1 and y == n - 2:  # 此时蛇头一定在 (n-1,n-1)
                            return step
                        vis.add(t)
                        q.append(t)
            step += 1
        return -1
```

```java
class Solution {
    private static int[][] DIRS = {{1, 0, 0}, {0, 1, 0}, {0, 0, 1}};

    public int minimumMoves(int[][] g) {
        int n = g.length;
        var vis = new boolean[n][n][2];
        var q = new ArrayList<int[]>();
        vis[0][0][0] = true;
        q.add(new int[]{0, 0, 0}); // 初始位置
        for (int step = 1; !q.isEmpty(); ++step) {
            var tmp = q;
            q = new ArrayList<>();
            for (var t : tmp) {
                for (var d : DIRS) {
                    int x = t[0] + d[0], y = t[1] + d[1], s = t[2] ^ d[2];
                    int x2 = x + s, y2 = y + (s ^ 1); // 蛇头
                    if (x2 < n && y2 < n && !vis[x][y][s] &&
                        g[x][y] == 0 && g[x2][y2] == 0 && (d[2] == 0 || g[x + 1][y + 1] == 0)) {
                        if (x == n - 1 && y == n - 2) return step; // 此时蛇头一定在 (n-1,n-1)
                        vis[x][y][s] = true;
                        q.add(new int[]{x, y, s});
                    }
                }
            }
        }
        return -1;
    }
}
```

```cpp
class Solution {
    static constexpr int DIRS[3][3] = {{1, 0, 0}, {0, 1, 0}, {0, 0, 1}};
public:
    int minimumMoves(vector<vector<int>> &g) {
        int n = g.size();
        bool vis[n][n][2]; memset(vis, 0, sizeof(vis));
        vis[0][0][0] = true;
        vector<tuple<int, int, int>> q = {{0, 0, 0}}; // 初始位置
        for (int step = 1; !q.empty(); ++step) {
            vector<tuple<int, int, int>> nxt;
            for (const auto &[X, Y, S] : q) {
                for (const auto &d : DIRS) {
                    int x = X + d[0], y = Y + d[1], s = S ^ d[2];
                    int x2 = x + s, y2 = y + (s ^ 1); // 蛇头
                    if (x2 < n && y2 < n && !vis[x][y][s] &&
                        g[x][y] == 0 && g[x2][y2] == 0 && (d[2] == 0 || g[x + 1][y + 1] == 0)) {
                        if (x == n - 1 && y == n - 2) return step; // 此时蛇头一定在 (n-1,n-1)
                        vis[x][y][s] = true;
                        nxt.emplace_back(x, y, s);
                    }
                }
            }
            q = move(nxt);
        }
        return -1;
    }
};
```

```go
type tuple struct{ x, y, s int }
var dirs = []tuple{{1, 0, 0}, {0, 1, 0}, {0, 0, 1}}

func minimumMoves(g [][]int) int {
    n := len(g)
    vis := make([][][2]bool, n)
    for i := range vis {
        vis[i] = make([][2]bool, n)
    }
    vis[0][0][0] = true // 初始位置
    q := []tuple{{}}
    for step := 1; len(q) > 0; step++ {
        tmp := q
        q = nil
        for _, t := range tmp {
            for _, d := range dirs {
                x, y, s := t.x+d.x, t.y+d.y, t.s^d.s
                x2, y2 := x+s, y+(s^1) // 蛇头
                if x2 < n && y2 < n && !vis[x][y][s] &&
                    g[x][y] == 0 && g[x2][y2] == 0 && (d.s == 0 || g[x+1][y+1] == 0) {
                    if x == n-1 && y == n-2 { // 此时蛇头一定在 (n-1,n-1)
                        return step
                    }
                    vis[x][y][s] = true
                    q = append(q, tuple{x, y, s})
                }
            }
        }
    }
    return -1
}
```

#### 复杂度分析

-   时间复杂度：$O(n^2)$，其中 $n$ 为 $grid$ 的长度。$vis$ 保证每个位置至多访问一次。
-   空间复杂度：$O(n^2)$。

#### 思考题

如果蛇身还可以朝上／朝左，还可以向上／向右移动，要如何修改呢？
