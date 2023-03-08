#### [方法一：动态规划](https://leetcode.cn/problems/li-wu-de-zui-da-jie-zhi-lcof/solutions/2153371/li-wu-de-zui-da-jie-zhi-by-leetcode-solu-g64i/)

**思路与算法**

我们可以使用动态规划的方法解决本题。记 $f(i, j)$ 表示从棋盘的左上角走到位置 $(i, j)$，最多可以拿到的礼物的价值。在进行状态转移时，可以考虑我们是通过何种方式走到位置 $(i, j)$ 的。根据题目的要求，我们可以每次向右或者向下移动一格，如果我们向右走到位置 $(i, j)$，那么我们上一步位于 $(i, j-1)$，可以得到状态转移方程：

$$f(i, j) \leftarrow f(i-1, j) + grid(i, j)$$

如果我们向下走到位置 $(i, j)$，那么我们上一步位于 $(i-1, j)$，可以得到状态转移方程：

$$f(i, j) \leftarrow f(i, j-1) + grid(i, j)$$

由于我们需要求出的是「最多可以拿到的礼物的价值」，因此可以将 $f(i, j)$ 的初始值置为一个很小的值（例如 $0$），在进行状态转移时不断地将 $f(i, j)$ 替换为更大的值。

需要注意的是，当 $i=0$ 时，第一种状态转移方程是无效的；当 $j=0$ 时，第二种状态转移方程是无效的；当 $i=j=0$ 时，两种状态转移方程都是无效的，但根据 $f(i, j)$ 的定义，我们应当有 $f(0, 0) = grid(0, 0)$，因此在进行状态转移时，我们可以只进行 $f(i, j) \leftarrow f(i-1, j)$ 和 $f(i, j) \leftarrow f(i, j-1)$ 这部分的转移。在转移完成后，我们再将 $f(i, j)$ 加上 $grid(i, j)$，这样就可以适配各种情况。

最后的答案即为 $f(m-1, n-1)$。

**细节**

这道题可以使用动态规划的原因在于，在任何一条路径中，如果同时经过了 $(i-1, j)$ 和 $(i, j)$，那么一定是先经过 $(i-1, j)$，再经过 $(i, j)$。因此，我们才能首先计算出 $f(i-1, j)$ 的值，再去用它来转移得到 $f(i, j)$。对于 $(i, j-1)$ 和 $(i, j)$ 也是同样的道理。

如果我们可以向四个方向进行移动，那么上面的限制就不再满足，我们也就不能使用动态规划来解决了。

**代码**

```cpp
class Solution {
public:
    int maxValue(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> f(m, vector<int>(n));
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i > 0) {
                    f[i][j] = max(f[i][j], f[i - 1][j]);
                }
                if (j > 0) {
                    f[i][j] = max(f[i][j], f[i][j - 1]);
                }
                f[i][j] += grid[i][j];
            }
        }
        return f[m - 1][n - 1];
    }
};
```

```java
class Solution {
    public int maxValue(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[][] f = new int[m][n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i > 0) {
                    f[i][j] = Math.max(f[i][j], f[i - 1][j]);
                }
                if (j > 0) {
                    f[i][j] = Math.max(f[i][j], f[i][j - 1]);
                }
                f[i][j] += grid[i][j];
            }
        }
        return f[m - 1][n - 1];
    }
}
```

```csharp
public class Solution {
    public int MaxValue(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] f = new int[m][];
        for (int i = 0; i < m; ++i) {
            f[i] = new int[n];
            for (int j = 0; j < n; ++j) {
                if (i > 0) {
                    f[i][j] = Math.Max(f[i][j], f[i - 1][j]);
                }
                if (j > 0) {
                    f[i][j] = Math.Max(f[i][j], f[i][j - 1]);
                }
                f[i][j] += grid[i][j];
            }
        }
        return f[m - 1][n - 1];
    }
}
```

```python
class Solution:
    def maxValue(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        f = [[0] * n for _ in range(m)]

        for i in range(m):
            for j in range(n):
                if i > 0:
                    f[i][j] = max(f[i][j], f[i - 1][j])
                if j > 0:
                    f[i][j] = max(f[i][j], f[i][j - 1])
                f[i][j] += grid[i][j]
        
        return f[m - 1][n - 1]
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int maxValue(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int f[m][n];
    memset(f, 0, sizeof(f));
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
            if (i > 0) {
                f[i][j] = MAX(f[i][j], f[i - 1][j]);
            }
            if (j > 0) {
                f[i][j] = MAX(f[i][j], f[i][j - 1]);
            }
            f[i][j] += grid[i][j];
        }
    }
    return f[m - 1][n - 1];
}
```

```javascript
var maxValue = function(grid) {
    const m = grid.length, n = grid[0].length;
    const f = new Array(m).fill(0).map(() => new Array(n).fill(0));
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i > 0) {
                f[i][j] = Math.max(f[i][j], f[i - 1][j]);
            }
            if (j > 0) {
                f[i][j] = Math.max(f[i][j], f[i][j - 1]);
            }
            f[i][j] += grid[i][j];
        }
    }
    return f[m - 1][n - 1];
};
```

```go
func maxValue(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    f := make([][]int, m)
    for i := range f {
        f[i] = make([]int, n)
    }
    for i, g := range grid {
        for j, x := range g {
            if i > 0 {
                f[i][j] = max(f[i][j], f[i-1][j])
            }
            if j > 0 {
                f[i][j] = max(f[i][j], f[i][j-1])
            }
            f[i][j] += x
        }
    }
    return f[m-1][n-1]
}

func max(a, b int) int {
    if a < b {
        return b
    }
    return a
}
```

注意到状态转移方程中，$f(i, j)$ 只会从 $f(i-1, j)$ 和 $f(i, j-1)$ 转移而来，而与 $f(i-2, \cdots)$ 以及更早的状态无关，因此我们同一时刻只需要存储最后两行的状态，即使用两个长度为 $n$ 的一位数组代替 $m \times n$ 的二维数组 $f$，交替地进行状态转移，减少空间复杂度。

```cpp
class Solution {
public:
    int maxValue(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> f(2, vector<int>(n));
        for (int i = 0; i < m; ++i) {
            int pos = i % 2;
            for (int j = 0; j < n; ++j) {
                f[pos][j] = 0;
                if (i > 0) {
                    f[pos][j] = max(f[pos][j], f[1 - pos][j]);
                }
                if (j > 0) {
                    f[pos][j] = max(f[pos][j], f[pos][j - 1]);
                }
                f[pos][j] += grid[i][j];
            }
        }
        return f[(m - 1) % 2][n - 1];
    }
};
```

```java
class Solution {
    public int maxValue(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[][] f = new int[2][n];
        for (int i = 0; i < m; ++i) {
            int pos = i % 2;
            for (int j = 0; j < n; ++j) {
                f[pos][j] = 0;
                if (i > 0) {
                    f[pos][j] = Math.max(f[pos][j], f[1 - pos][j]);
                }
                if (j > 0) {
                    f[pos][j] = Math.max(f[pos][j], f[pos][j - 1]);
                }
                f[pos][j] += grid[i][j];
            }
        }
        return f[(m - 1) % 2][n - 1];
    }
}
```

```csharp
public class Solution {
    public int MaxValue(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] f = new int[2][];
        for (int i = 0; i < 2; ++i) {
            f[i] = new int[n];
        }
        for (int i = 0; i < m; ++i) {
            int pos = i % 2;
            for (int j = 0; j < n; ++j) {
                f[pos][j] = 0;
                if (i > 0) {
                    f[pos][j] = Math.Max(f[pos][j], f[1 - pos][j]);
                }
                if (j > 0) {
                    f[pos][j] = Math.Max(f[pos][j], f[pos][j - 1]);
                }
                f[pos][j] += grid[i][j];
            }
        }
        return f[(m - 1) % 2][n - 1];
    }
}
```

```python
class Solution:
    def maxValue(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        f = [[0] * n for _ in range(2)]

        for i in range(m):
            pos = i % 2
            for j in range(n):
                if i > 0:
                    f[pos][j] = max(f[pos][j], f[1 - pos][j])
                if j > 0:
                    f[pos][j] = max(f[pos][j], f[pos][j - 1])
                f[pos][j] += grid[i][j]
        
        return f[(m - 1) % 2][n - 1]
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int maxValue(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int f[2][n];
    memset(f, 0, sizeof(f));
    for (int i = 0; i < m; ++i) {
        int pos = i % 2;
        for (int j = 0; j < n; ++j) {
            f[pos][j] = 0;
            if (i > 0) {
                f[pos][j] = MAX(f[pos][j], f[1 - pos][j]);
            }
            if (j > 0) {
                f[pos][j] = MAX(f[pos][j], f[pos][j - 1]);
            }
            f[pos][j] += grid[i][j];
        }
    }
    return f[(m - 1) % 2][n - 1];
}
```

```javascript
var maxValue = function(grid) {
    const m = grid.length, n = grid[0].length;
    const f = new Array(2).fill(0).map(() => new Array(n).fill(0));
    for (let i = 0; i < m; i++) {
        const pos = i % 2;
        for (let j = 0; j < n; j++) {
            if (i > 0) {
                f[pos][j] = Math.max(f[pos][j], f[1 - pos][j]);
            }
            if (j > 0) {
                f[pos][j] = Math.max(f[pos][j], f[pos][j - 1]);
            }
            f[pos][j] += grid[i][j];
        }
    }
    return f[(m - 1) % 2][n - 1];
};
```

```go
func maxValue(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    f := make([][]int, 2)
    for i := range f {
        f[i] = make([]int, n)
    }
    for i, g := range grid {
        pos := i % 2
        for j, x := range g {
            f[pos][j] = 0
            if i > 0 {
                f[pos][j] = max(f[pos][j], f[1-pos][j])
            }
            if j > 0 {
                f[pos][j] = max(f[pos][j], f[pos][j-1])
            }
            f[pos][j] += x
        }
    }
    return f[(m-1)%2][n-1]
}

func max(a, b int) int {
    if a < b {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(mn)$。
-   空间复杂度：$O(mn)$ 或 $O(n)$，即为动态规划需要使用的空间。
