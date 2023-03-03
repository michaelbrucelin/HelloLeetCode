#### [方法一：迭代](https://leetcode.cn/problems/island-perimeter/solutions/466248/dao-yu-de-zhou-chang-by-leetcode-solution/)

**思路与算法**

对于一个陆地格子的每条边，它被算作岛屿的周长当且仅当这条边为网格的边界或者相邻的另一个格子为水域。 因此，我们可以遍历每个陆地格子，看其四个方向是否为边界或者水域，如果是，将这条边的贡献（即 $1$）加入答案 $ans$ 中即可。

**代码**

```cpp
class Solution {
    constexpr static int dx[4] = {0, 1, 0, -1};
    constexpr static int dy[4] = {1, 0, -1, 0};
public:
    int islandPerimeter(vector<vector<int>> &grid) {
        int n = grid.size(), m = grid[0].size();
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if (grid[i][j]) {
                    int cnt = 0;
                    for (int k = 0; k < 4; ++k) {
                        int tx = i + dx[k];
                        int ty = j + dy[k];
                        if (tx < 0 || tx >= n || ty < 0 || ty >= m || !grid[tx][ty]) {
                            cnt += 1;
                        }
                    }
                    ans += cnt;
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    static int[] dx = {0, 1, 0, -1};
    static int[] dy = {1, 0, -1, 0};

    public int islandPerimeter(int[][] grid) {
        int n = grid.length, m = grid[0].length;
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                if (grid[i][j] == 1) {
                    int cnt = 0;
                    for (int k = 0; k < 4; ++k) {
                        int tx = i + dx[k];
                        int ty = j + dy[k];
                        if (tx < 0 || tx >= n || ty < 0 || ty >= m || grid[tx][ty] == 0) {
                            cnt += 1;
                        }
                    }
                    ans += cnt;
                }
            }
        }
        return ans;
    }
}
```

```javascript
var islandPerimeter = function (grid) {
    const dx = [0, 1, 0, -1];
    const dy = [1, 0, -1, 0];
    const n = grid.length, m = grid[0].length;
    let ans = 0;
    for (let i = 0; i < n; ++i) {
        for (let j = 0; j < m; ++j) {
            if (grid[i][j]) {
                let cnt = 0;
                for (let k = 0; k < 4; ++k) {
                    let tx = i + dx[k];
                    let ty = j + dy[k];
                    if (tx < 0 || tx >= n || ty < 0 || ty >= m || !grid[tx][ty]) {
                        cnt += 1;
                    }
                }
                ans += cnt;
            }
        }
    }
    return ans;
};
```

```go
type pair struct{ x, y int }
var dir4 = []pair{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}

func islandPerimeter(grid [][]int) (ans int) {
    n, m := len(grid), len(grid[0])
    for i, row := range grid {
        for j, v := range row {
            if v == 1 {
                for _, d := range dir4 {
                    if x, y := i+d.x, j+d.y; x < 0 || x >= n || y < 0 || y >= m || grid[x][y] == 0 {
                        ans++
                    }
                }
            }
        }
    }
    return
}
```

```c
const int dx[4] = {0, 1, 0, -1};
const int dy[4] = {1, 0, -1, 0};

int islandPerimeter(int** grid, int gridSize, int* gridColSize) {
    int n = gridSize, m = gridColSize[0];
    int ans = 0;
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < m; ++j) {
            if (grid[i][j]) {
                int cnt = 0;
                for (int k = 0; k < 4; ++k) {
                    int tx = i + dx[k];
                    int ty = j + dy[k];
                    if (tx < 0 || tx >= n || ty < 0 || ty >= m || !grid[tx][ty]) {
                        cnt += 1;
                    }
                }
                ans += cnt;
            }
        }
    }
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(nm)$，其中 $n$ 为网格的高度，$m$ 为网格的宽度。我们需要遍历每个格子，每个格子要看其周围 $4$ 个格子是否为岛屿，因此总时间复杂度为 $O(4nm)=O(nm)$。
-   空间复杂度：$O(1)$。只需要常数空间存放若干变量。
