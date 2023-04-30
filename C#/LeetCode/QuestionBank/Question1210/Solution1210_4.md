#### [方法二：动态规划](https://leetcode.cn/problems/minimum-moves-to-reach-target-with-rotations/solutions/2091767/chuan-guo-mi-gong-de-zui-shao-yi-dong-ci-pmnh/)

**思路与算法**

由于蛇只能向右或者向下移动，因此 $(x,y,status)$ 这个状态只会从 $(x−1,y,status)$，$(x,y−1,status)$ 或者 $(x,y,1−status)$ 通过一次操作得到。因此，如果我们使用双重循环分别递增地遍历 $x$ 和 $y$，那么在计算 $(x,y,status)$ 时，$(x−1,y,status)$ 和 $(x,y−1,status)$ 都已经完成计算，这样我们只需要小心地考虑 $(x,y,1−status)$ 这种特殊的情况（即旋转），就可以使用动态规划解决本题了。

在进行状态转移之前，我们首先需要判断 $(x,y,status)$ 这个状态本身是否是合法的。这是因为在方法一的广度优先搜索中，我们只会从一个有效的状态转移到另一些新的有效状态，而在动态规划中，我们使用双重循环遍历所有状态，这些状态并不都是有效的。

我们用 $canHorizontal$ 和 $canVertical$ 这两个布尔变量分别表示当 $status=0$ 和 $status=1$ 时，$(x,y,status)$ 是否是合法的。当 $canHorizontal=True$ 时，有如下两种状态转移：

$$\begin{aligned} & f(x, y, 0) \leftarrow f(x-1, y, 0) + 1 \\ & f(x, y, 0) \leftarrow f(x, y-1, 0) + 1 \\ \end{aligned}$$

当 $canVertical=True$ 时，有如下两种状态转移：

$$\begin{aligned} & f(x, y, 1) \leftarrow f(x-1, y, 1) + 1 \\ & f(x, y, 1) \leftarrow f(x, y-1, 1) + 1 \\ \end{aligned}$$

如果一个状态不是合法的，我们可以将它赋值为一个很大的整数 $\infty$。这样一来，在进行状态转移时，我们无需考虑 $f(x−1,y,0)$ 或 $f(x,y−1,1)$ 本身是否合法：如果它们不合法，那么转移式的右侧是一个很大的整数，而我们要求的是最少移动次数，因此无法进行转移。

除了上述的四种状态转移之外，我们还需要考虑 $(x,y,0)$ 与 $(x,y,1)$ 之间通过一次旋转操作的转移。由于在同一个 $(x, y)$ 不会旋转两次及以上，因此在上述四种状态转移完成之后，我们额外进行两种状态转移：

$$\begin{aligned} & f(x, y, 0) \leftarrow f(x, y, 1) + 1 \\ & f(x, y, 1) \leftarrow f(x, y, 0) + 1 \\ \end{aligned}$$

即可。需要注意的是，除了 $canHorizontal$ 和 $canVertical$ 均为 $True$ 以外，我们还需要保证 $(x+1, y+1)$ 也是空的单元格。

> 读者可以思考一下，为什么一定要在「上述四种状态转移完成之后」才进行这两种特殊转移。如果改变顺序会出现什么问题。

动态规划的初始值为 $f(0, 0, 0) = 0$，其余所有的 $f(x, y, status) = \infty$。最终的答案即为 $f(n−1,n−2,0)$。

**代码**

```cpp
class Solution {
public:
    int minimumMoves(vector<vector<int>>& grid) {
        int n = grid.size();
        vector<vector<array<int, 2>>> f(n, vector<array<int, 2>>(n, {INVALID, INVALID}));
        f[0][0][0] = 0;

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                bool canHorizontal = (j + 1 < n && grid[i][j] == 0 && grid[i][j + 1] == 0);
                bool canVertical = (i + 1 < n && grid[i][j] == 0 && grid[i + 1][j] == 0);

                if (i - 1 >= 0 && canHorizontal) {
                    f[i][j][0] = min(f[i][j][0], f[i - 1][j][0] + 1);
                }
                if (j - 1 >= 0 && canHorizontal) {
                    f[i][j][0] = min(f[i][j][0], f[i][j - 1][0] + 1);
                }
                if (i - 1 >= 0 && canVertical) {
                    f[i][j][1] = min(f[i][j][1], f[i - 1][j][1] + 1);
                }
                if (j - 1 >= 0 && canVertical) {
                    f[i][j][1] = min(f[i][j][1], f[i][j - 1][1] + 1);
                }

                if (canHorizontal && canVertical && grid[i + 1][j + 1] == 0) {
                    f[i][j][0] = min(f[i][j][0], f[i][j][1] + 1);
                    f[i][j][1] = min(f[i][j][1], f[i][j][0] + 1);
                }
            }
        }

        return (f[n - 1][n - 2][0] == INVALID ? -1 : f[n - 1][n - 2][0]);
    }

private:
    static constexpr int INVALID = INT_MAX / 2;
};
```

```java
class Solution {
    static final int INVALID = Integer.MAX_VALUE / 2;

    public int minimumMoves(int[][] grid) {
        int n = grid.length;
        int[][][] f = new int[n][n][2];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Arrays.fill(f[i][j], INVALID);
            }
        }
        f[0][0][0] = 0;

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                boolean canHorizontal = (j + 1 < n && grid[i][j] == 0 && grid[i][j + 1] == 0);
                boolean canVertical = (i + 1 < n && grid[i][j] == 0 && grid[i + 1][j] == 0);

                if (i - 1 >= 0 && canHorizontal) {
                    f[i][j][0] = Math.min(f[i][j][0], f[i - 1][j][0] + 1);
                }
                if (j - 1 >= 0 && canHorizontal) {
                    f[i][j][0] = Math.min(f[i][j][0], f[i][j - 1][0] + 1);
                }
                if (i - 1 >= 0 && canVertical) {
                    f[i][j][1] = Math.min(f[i][j][1], f[i - 1][j][1] + 1);
                }
                if (j - 1 >= 0 && canVertical) {
                    f[i][j][1] = Math.min(f[i][j][1], f[i][j - 1][1] + 1);
                }

                if (canHorizontal && canVertical && grid[i + 1][j + 1] == 0) {
                    f[i][j][0] = Math.min(f[i][j][0], f[i][j][1] + 1);
                    f[i][j][1] = Math.min(f[i][j][1], f[i][j][0] + 1);
                }
            }
        }

        return (f[n - 1][n - 2][0] == INVALID ? -1 : f[n - 1][n - 2][0]);
    }
}
```

```csharp
public class Solution {
    const int INVALID = int.MaxValue / 2;

    public int MinimumMoves(int[][] grid) {
        int n = grid.Length;
        int[][][] f = new int[n][][];
        for (int i = 0; i < n; i++) {
            f[i] = new int[n][];
            for (int j = 0; j < n; j++) {
                f[i][j] = new int[2];
                Array.Fill(f[i][j], INVALID);
            }
        }
        f[0][0][0] = 0;

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                bool canHorizontal = (j + 1 < n && grid[i][j] == 0 && grid[i][j + 1] == 0);
                bool canVertical = (i + 1 < n && grid[i][j] == 0 && grid[i + 1][j] == 0);

                if (i - 1 >= 0 && canHorizontal) {
                    f[i][j][0] = Math.Min(f[i][j][0], f[i - 1][j][0] + 1);
                }
                if (j - 1 >= 0 && canHorizontal) {
                    f[i][j][0] = Math.Min(f[i][j][0], f[i][j - 1][0] + 1);
                }
                if (i - 1 >= 0 && canVertical) {
                    f[i][j][1] = Math.Min(f[i][j][1], f[i - 1][j][1] + 1);
                }
                if (j - 1 >= 0 && canVertical) {
                    f[i][j][1] = Math.Min(f[i][j][1], f[i][j - 1][1] + 1);
                }

                if (canHorizontal && canVertical && grid[i + 1][j + 1] == 0) {
                    f[i][j][0] = Math.Min(f[i][j][0], f[i][j][1] + 1);
                    f[i][j][1] = Math.Min(f[i][j][1], f[i][j][0] + 1);
                }
            }
        }

        return (f[n - 1][n - 2][0] == INVALID ? -1 : f[n - 1][n - 2][0]);
    }
}
```

```python
class Solution:
    def minimumMoves(self, grid: List[List[int]]) -> int:
        n = len(grid)
        f = [[[float("inf"), float("inf")] for _ in range(n)] for _ in range(n)]
        f[0][0][0] = 0

        for i in range(n):
            for j in range(n):
                canHorizontal = (j + 1 < n and grid[i][j] == grid[i][j + 1] == 0)
                canVertical = (i + 1 < n and grid[i][j] == grid[i + 1][j] == 0)

                if i - 1 >= 0 and canHorizontal:
                    f[i][j][0] = min(f[i][j][0], f[i - 1][j][0] + 1)
                if j - 1 >= 0 and canHorizontal:
                    f[i][j][0] = min(f[i][j][0], f[i][j - 1][0] + 1)
                if i - 1 >= 0 and canVertical:
                    f[i][j][1] = min(f[i][j][1], f[i - 1][j][1] + 1)
                if j - 1 >= 0 and canVertical:
                    f[i][j][1] = min(f[i][j][1], f[i][j - 1][1] + 1)
                
                if canHorizontal and canVertical and grid[i + 1][j + 1] == 0:
                    f[i][j][0] = min(f[i][j][0], f[i][j][1] + 1)
                    f[i][j][1] = min(f[i][j][1], f[i][j][0] + 1)

        return -1 if f[n - 1][n - 2][0] == float("inf") else f[n - 1][n - 2][0]
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

typedef struct {
    int x;
    int y;
    int status;
} Tuple;

const int INVALID = INT_MAX / 2;

int minimumMoves(int** grid, int gridSize, int* gridColSize) {
    int n = gridSize;
    int f[n][n][2];
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            f[i][j][0] = f[i][j][1] = INVALID;
        }
    }
    f[0][0][0] = 0;

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j) {
            bool canHorizontal = (j + 1 < n && grid[i][j] == 0 && grid[i][j + 1] == 0);
            bool canVertical = (i + 1 < n && grid[i][j] == 0 && grid[i + 1][j] == 0);

            if (i - 1 >= 0 && canHorizontal) {
                f[i][j][0] = MIN(f[i][j][0], f[i - 1][j][0] + 1);
            }
            if (j - 1 >= 0 && canHorizontal) {
                f[i][j][0] = MIN(f[i][j][0], f[i][j - 1][0] + 1);
            }
            if (i - 1 >= 0 && canVertical) {
                f[i][j][1] = MIN(f[i][j][1], f[i - 1][j][1] + 1);
            }
            if (j - 1 >= 0 && canVertical) {
                f[i][j][1] = MIN(f[i][j][1], f[i][j - 1][1] + 1);
            }

            if (canHorizontal && canVertical && grid[i + 1][j + 1] == 0) {
                f[i][j][0] = MIN(f[i][j][0], f[i][j][1] + 1);
                f[i][j][1] = MIN(f[i][j][1], f[i][j][0] + 1);
            }
        }
    }

    return (f[n - 1][n - 2][0] == INVALID ? -1 : f[n - 1][n - 2][0]);
}
```

```javascript
var minimumMoves = function(grid) {
    const INVALID = Number.MAX_VALUE;
    const n = grid.length;
    const f = new Array(n).fill(0).map(() => new Array(n).fill(0).map(() => new Array(2).fill(INVALID)));
    f[0][0][0] = 0;

    for (let i = 0; i < n; ++i) {
        for (let j = 0; j < n; ++j) {
            const canHorizontal = (j + 1 < n && grid[i][j] === 0 && grid[i][j + 1] === 0);
            const canVertical = (i + 1 < n && grid[i][j] === 0 && grid[i + 1][j] === 0);

            if (i - 1 >= 0 && canHorizontal) {
                f[i][j][0] = Math.min(f[i][j][0], f[i - 1][j][0] + 1);
            }
            if (j - 1 >= 0 && canHorizontal) {
                f[i][j][0] = Math.min(f[i][j][0], f[i][j - 1][0] + 1);
            }
            if (i - 1 >= 0 && canVertical) {
                f[i][j][1] = Math.min(f[i][j][1], f[i - 1][j][1] + 1);
            }
            if (j - 1 >= 0 && canVertical) {
                f[i][j][1] = Math.min(f[i][j][1], f[i][j - 1][1] + 1);
            }

            if (canHorizontal && canVertical && grid[i + 1][j + 1] === 0) {
                f[i][j][0] = Math.min(f[i][j][0], f[i][j][1] + 1);
                f[i][j][1] = Math.min(f[i][j][1], f[i][j][0] + 1);
            }
        }
    }

    return (f[n - 1][n - 2][0] === INVALID ? -1 : f[n - 1][n - 2][0]);
};
```

```go
func minimumMoves(grid [][]int) int {
    const inf = math.MaxInt / 2
    n := len(grid)
    f := make([][][2]int, n)
    for i := range f {
        f[i] = make([][2]int, n)
        for j := range f[i] {
            f[i][j] = [2]int{inf, inf}
        }
    }
    f[0][0][0] = 0

    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            canHorizontal := j+1 < n && grid[i][j] == 0 && grid[i][j+1] == 0
            canVertical := i+1 < n && grid[i][j] == 0 && grid[i+1][j] == 0

            if i-1 >= 0 && canHorizontal {
                f[i][j][0] = min(f[i][j][0], f[i-1][j][0]+1)
            }
            if j-1 >= 0 && canHorizontal {
                f[i][j][0] = min(f[i][j][0], f[i][j-1][0]+1)
            }
            if i-1 >= 0 && canVertical {
                f[i][j][1] = min(f[i][j][1], f[i-1][j][1]+1)
            }
            if j-1 >= 0 && canVertical {
                f[i][j][1] = min(f[i][j][1], f[i][j-1][1]+1)
            }

            if canHorizontal && canVertical && grid[i+1][j+1] == 0 {
                f[i][j][0] = min(f[i][j][0], f[i][j][1]+1)
                f[i][j][1] = min(f[i][j][1], f[i][j][0]+1)
            }
        }
    }
    if f[n-1][n-2][0] == inf {
        return -1
    }
    return f[n-1][n-2][0]
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，动态规划使用双重循环，而每个状态转移需要的时间为 $O(1)$。
-   空间复杂度：$O(n^2)$，即为数组 $f$ 需要使用的空间。注意到 $f(x, \cdots)$ 只会从 $f(x-1, \cdots)$ 和 $f(x, \cdots)$ 转移而来，因此可以使用滚动数组进行空间优化，使得空间复杂度降低至 $O(n)$。
