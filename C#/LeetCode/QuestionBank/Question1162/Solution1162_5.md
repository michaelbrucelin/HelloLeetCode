#### [方法三：动态规划](https://leetcode.cn/problems/as-far-from-land-as-possible/solutions/147423/di-tu-fen-xi-by-leetcode-solution/)

**思路**

考虑优化方法二中的「把陆地区域作为源点集、海洋区域作为目标点集，求最短路」的过程。我们知道对于每个海洋区域 $(x, y)$，离它最近的陆地区域到它的路径要么从上方或者左方来，要么从右方或者下方来。考虑做两次动态规划，第一次从左上到右下，第二次从右下到左上，记 $f(x, y)$ 为 $(x, y)$ 距离最近的陆地区域的曼哈顿距离，则我们可以推出这样的转移方程：
-   第一阶段
$f(x, y) = \left \{ \begin{aligned} & 0 & , & (x, y) {\rm \, is\, land} \\ & \min \{ f(x - 1, y), f(x, y - 1) \} + 1 & , & (x, y) {\rm \, is\,ocean} \end{aligned} \right.$
-   第二阶段
$f(x, y) = \left \{ \begin{aligned} & 0 & , & (x, y) {\rm \, is\, land} \\ & \min \{ f(x + 1, y), f(x, y + 1) \} + 1 & , & (x, y) {\rm \, is\,ocean} \end{aligned} \right.$

我们初始化的时候把陆地的 `f` 值全部预置为 `0`，海洋的 `f` 全部预置为 `INF`，做完两个阶段的动态规划后，我们在所有的不为零的 `f[i][j]` 中比一个最大值即可，如果最终比较出的最大值为 `INF`，就返回 `-1`。

**思考：如果用 $f(x, y)$ 记录左上方的 DP 结果，$g(x, y)$ 记录右下方的DP结果可行吗？** 答案是不可行。因为考虑距离点 $(x, y)$ 最近的点可能既不来自左上方，也不来自右下方，比如它来自右上方，这个时候，第二阶段我们就需要用到第一阶段的计算结果。

代码实现如下。

**代码实现**

```cpp
class Solution {
public:
    static constexpr int MAX_N = 100 + 5;
    static constexpr int INF = int(1E6);
    
    int f[MAX_N][MAX_N];
    int n;

    int maxDistance(vector<vector<int>>& grid) {
        this->n = grid.size();
        vector<vector<int>>& a = grid;

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                f[i][j] = (a[i][j] ? 0 : INF);
            }
        }

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (a[i][j]) {
                    continue;
                }
                if (i - 1 >= 0) {
                    f[i][j] = min(f[i][j], f[i - 1][j] + 1);
                }
                if (j - 1 >= 0) {
                    f[i][j] = min(f[i][j], f[i][j - 1] + 1);
                }
            }
        }

        for (int i = n - 1; i >= 0; --i) {
            for (int j = n - 1; j >= 0; --j) {
                if (a[i][j]) {
                    continue;
                }
                if (i + 1 < n) {
                    f[i][j] = min(f[i][j], f[i + 1][j] + 1);
                }
                if (j + 1 < n) {
                    f[i][j] = min(f[i][j], f[i][j + 1] + 1);
                }
            }
        }

        int ans = -1;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (!a[i][j]) {
                    ans = max(ans, f[i][j]);
                }
            }
        }

        if (ans == INF) {
            return -1;
        } else {
            return ans;
        }
    }
};
```

```java
class Solution {
    public int maxDistance(int[][] grid) {
        final int INF = 1000000;
        int n = grid.length;
        int[][] f = new int[n][n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                f[i][j] = grid[i][j] == 1 ? 0 : INF;
            }
        }

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    continue;
                }
                if (i - 1 >= 0) {
                    f[i][j] = Math.min(f[i][j], f[i - 1][j] + 1);
                }
                if (j - 1 >= 0) {
                    f[i][j] = Math.min(f[i][j], f[i][j - 1] + 1);
                }
            }
        }

        for (int i = n - 1; i >= 0; --i) {
            for (int j = n - 1; j >= 0; --j) {
                if (grid[i][j] == 1) {
                    continue;
                }
                if (i + 1 < n) {
                    f[i][j] = Math.min(f[i][j], f[i + 1][j] + 1);
                }
                if (j + 1 < n) {
                    f[i][j] = Math.min(f[i][j], f[i][j + 1] + 1);
                }
            }
        }

        int ans = -1;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    ans = Math.max(ans, f[i][j]);
                }
            }
        }

        if (ans == INF) {
            return -1;
        } else {
            return ans;
        }
    }
}
```

**复杂度分析**

-   时间复杂度：从代码不难看出，这个算法的过程就是四个双重 `for` 循环，渐进时间复杂度为 $O(n^2)$。
-   空间复杂度：该算法使用了 `f` 数组，渐进空间复杂度为 $O(n^2)$。
