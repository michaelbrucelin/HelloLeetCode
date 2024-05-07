### [摘樱桃 II](https://leetcode.cn/problems/cherry-pickup-ii/solutions/521172/zhai-ying-tao-ii-by-leetcode-solution-v2k5/)

#### 方法一：动态规划

##### 思路与算法

设矩阵的长度为 $m$，宽度为 $n$，我们用 $f[i][j_1][j_2]$ 表示当第一个机器人从 $(0, 0)$ 走到 $(i, j_1)$，第二个机器人从 $(0, n-1)$ 走到 $(i, j_2)$，最多能收集的樱桃数目。

在进行状态转移时，我们可以枚举这两个机器人在第 $i-1$ 行的位置 $\textit{dj}_1$ 和 $\textit{dj}_2$，它们满足；

$$\begin{aligned} 0 \leq \textit{dj}_1 < n ~且~ \textit{dj}_1 - j_1 \in [-1, 0, 1] \\ 0 \leq \textit{dj}_2 < n ~且~ \textit{dj}_2 - j_2 \in [-1, 0, 1] \end{aligned}$$

也就是说，我们只需要在 $[j_1-1, j_1, j_1+1]$ 中枚举 $\textit{dj}_1$，并且需要判断其是否在 $[0, n)$ 的范围内。对于 $\textit{dj}_2$ 也是如此。因此我们可以写出如下的状态转移方程；

$$f[i][j_1][j_2] = \max(f[i-1][\textit{dj}_1][\textit{dj}_2] + \text{value}(i, j_1, j_2))$$

其中 $\text{value}(i, j_1, j_2)$ 表示两个机器人分别在 $(i, j_1)$ 和 $(i, j_2)$ 时可以收集的樱桃数目总和。根据题目描述，有：

$$\text{value}(i, j_1, j_2) = \begin{cases} \text{grid}[i][j_1] + \text{grid}[i][j_2] & 如果~j_1 \neq j_2 \\ \text{grid}[i][j_1] & 如果~j_1 = j_2 \end{cases}$$

动态规划的边界条件为

$$f[i][0][n-1] = \text{grid}[0][0] + \text{grid}[0][n-1]$$

即两个机器人初始所在的位置。最终的答案即为所有 $f[m-1][j_1][j_2]$ 中的最大值。

##### 细节

动态规划一般有自顶向下和自底向上两种编写方式，其中自顶向下也被称为「记忆化搜索」。

- 如果我们用自顶向下的方式来编写代码，那么代码将会十分简洁，并且不需要考虑很多特殊情况和边界条件，这是因为「记忆化搜索」只会「搜索」可行的状态；
- 如果我们用自底向上的方式来编写代码，那么就需要考虑特殊情况和边界条件。例如在 $i=0$ 时，除了 $f[0][0][n-1]$ 之外的其余状态都是不合法的。对于这些状态，我们可以将其标记为 $-1$，并在状态转移时进行特殊判断。并且，我们可以发现在状态转移方程中，$f[i][..][..]$ 只会从 $f[i-1][..][..]$ 转移而来，因此我们可以使用两个二维数组代替三位数组，交替地进行状态转移，使空间复杂度得到优化。

下面的 `C++` 和 `Java` 代码给出了自底向上 + 空间优化的参考；`Python` 代码给出了自顶向下的参考。

```c++
class Solution {
public:
    int cherryPickup(vector<vector<int>>& grid) {
        int m = grid.size();
        int n = grid[0].size();
        
        vector<vector<int>> f(n, vector<int>(n, -1)), g(n, vector<int>(n, -1));
        f[0][n - 1] = grid[0][0] + grid[0][n - 1];
        for (int i = 1; i < m; ++i) {
            for (int j1 = 0; j1 < n; ++j1) {
                for (int j2 = 0; j2 < n; ++j2) {
                    int best = -1;
                    for (int dj1 = j1 - 1; dj1 <= j1 + 1; ++dj1) {
                        for (int dj2 = j2 - 1; dj2 <= j2 + 1; ++dj2) {
                            if (dj1 >= 0 && dj1 < n && dj2 >= 0 && dj2 < n && f[dj1][dj2] != -1) {
                                best = max(best, f[dj1][dj2] + (j1 == j2 ? grid[i][j1] : grid[i][j1] + grid[i][j2]));
                            }
                        }
                    }
                    g[j1][j2] = best;
                }
            }
            swap(f, g);
        }

        int ans = 0;
        for (int j1 = 0; j1 < n; ++j1) {
            for (int j2 = 0; j2 < n; ++j2) {
                ans = max(ans, f[j1][j2]);
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int cherryPickup(int[][] grid) {
        int m = grid.length;
        int n = grid[0].length;
        
        int[][] f = new int[n][n];
        int[][] g = new int[n][n];
        for (int i = 0; i < n; i++) {
            Arrays.fill(f[i], -1);
            Arrays.fill(g[i], -1);
        }
        f[0][n - 1] = grid[0][0] + grid[0][n - 1];
        for (int i = 1; i < m; ++i) {
            for (int j1 = 0; j1 < n; ++j1) {
                for (int j2 = 0; j2 < n; ++j2) {
                    int best = -1;
                    for (int dj1 = j1 - 1; dj1 <= j1 + 1; ++dj1) {
                        for (int dj2 = j2 - 1; dj2 <= j2 + 1; ++dj2) {
                            if (dj1 >= 0 && dj1 < n && dj2 >= 0 && dj2 < n && f[dj1][dj2] != -1) {
                                best = Math.max(best, f[dj1][dj2] + (j1 == j2 ? grid[i][j1] : grid[i][j1] + grid[i][j2]));
                            }
                        }
                    }
                    g[j1][j2] = best;
                }
            }
            int[][] temp = f;
            f = g;
            g = temp;
        }

        int ans = 0;
        for (int j1 = 0; j1 < n; ++j1) {
            for (int j2 = 0; j2 < n; ++j2) {
                ans = Math.max(ans, f[j1][j2]);
            }
        }
        return ans;

    }
}
```

```python
class Solution:
    def cherryPickup(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])

        def getValue(i, j1, j2):
            return grid[i][j1] + grid[i][j2] if j1 != j2 else grid[i][j1]

        @lru_cache(None)
        def dfs(i, j1, j2):
            if i == m - 1:
                return getValue(i, j1, j2)
            
            best = 0
            for dj1 in [j1 - 1, j1, j1 + 1]:
                for dj2 in [j2 - 1, j2, j2 + 1]:
                    if 0 <= dj1 < n and 0 <= dj2 < n:
                        best = max(best, dfs(i + 1, dj1, dj2))

            return best + getValue(i, j1, j2)
        
        return dfs(0, 0, n - 1)
```

```c
int cherryPickup(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize;
    int n = gridColSize[0];
    
    int** f = (int**)malloc(n * sizeof(int*));
    int** g = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; ++i) {
        f[i] = (int*)malloc(n * sizeof(int));
        g[i] = (int*)malloc(n * sizeof(int));
        for (int j = 0; j < n; ++j) {
            f[i][j] = -1;
            g[i][j] = -1;
        }
    }

    f[0][n - 1] = grid[0][0] + grid[0][n - 1];
    for (int i = 1; i < m; ++i) {
        for (int j1 = 0; j1 < n; ++j1) {
            for (int j2 = 0; j2 < n; ++j2) {
                int best = -1;
                for (int dj1 = j1 - 1; dj1 <= j1 + 1; ++dj1) {
                    for (int dj2 = j2 - 1; dj2 <= j2 + 1; ++dj2) {
                        if (dj1 >= 0 && dj1 < n && dj2 >= 0 && dj2 < n && f[dj1][dj2] != -1) {
                            best = fmax(best, f[dj1][dj2] + (j1 == j2 ? grid[i][j1] : grid[i][j1] + grid[i][j2]));
                        }
                    }
                }
                g[j1][j2] = best;
            }
        }
        int** temp = f;
        f = g;
        g = temp;
    }

    int ans = 0;
    for (int j1 = 0; j1 < n; ++j1) {
        for (int j2 = 0; j2 < n; ++j2) {
            ans = fmax(ans, f[j1][j2]);
        }
    }

    for (int i = 0; i < n; ++i) {
        free(f[i]);
        free(g[i]);
    }
    free(f);
    free(g);
    return ans;
}
```

```go
func cherryPickup(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    f := make([][]int, n)
    g := make([][]int, n)
    for i := range f {
        f[i] = make([]int, n)
        g[i] = make([]int, n)
        for j := range f[i] {
            f[i][j] = -1
            g[i][j] = -1
        }
    }

    f[0][n - 1] = grid[0][0] + grid[0][n - 1]
    for i := 1; i < m; i++ {
        for j1 := 0; j1 < n; j1++ {
            for j2 := 0; j2 < n; j2++ {
                best := -1
                for dj1 := j1 - 1; dj1 <= j1 + 1; dj1++ {
                    for dj2 := j2 - 1; dj2 <= j2 + 1; dj2++ {
                        if dj1 >= 0 && dj1 < n && dj2 >= 0 && dj2 < n && f[dj1][dj2] != -1 {
                            if j1 == j2 {
                                best = max(best, f[dj1][dj2] + grid[i][j1])
                            } else {
                                best = max(best, f[dj1][dj2] + grid[i][j1] + grid[i][j2])
                            }
                        }
                    }
                }
                g[j1][j2] = best
            }
        }
        f, g = g, f
    }

    ans := 0
    for _, row := range f {
        for _, v := range row {
            ans = max(ans, v)
        }
    }
    return ans
}
```

```javascript
var cherryPickup = function(grid) {
    const m = grid.length;
    const n = grid[0].length;

    let f = Array.from({ length: n }, () => Array(n).fill(-1));
    let g = Array.from({ length: n }, () => Array(n).fill(-1));

    f[0][n - 1] = grid[0][0] + grid[0][n - 1];
    for (let i = 1; i < m; ++i) {
        for (let j1 = 0; j1 < n; ++j1) {
            for (let j2 = 0; j2 < n; ++j2) {
                let best = -1;
                for (let dj1 = j1 - 1; dj1 <= j1 + 1; ++dj1) {
                    for (let dj2 = j2 - 1; dj2 <= j2 + 1; ++dj2) {
                        if (dj1 >= 0 && dj1 < n && dj2 >= 0 && dj2 < n && f[dj1][dj2] != -1) {
                            best = Math.max(best, f[dj1][dj2] + (j1 == j2 ? grid[i][j1] : grid[i][j1] + grid[i][j2]));
                        }
                    }
                }
                g[j1][j2] = best;
            }
        }
        [f, g] = [g, f];
    }
    let ans = 0;
    for (let j1 = 0; j1 < n; ++j1) {
        ans = Math.max(ans, Math.max(...f[j1]));
    }
    return ans;
};
```

```typescript
function cherryPickup(grid: number[][]): number {
    const m = grid.length;
    const n = grid[0].length;
    let f: number[][] = Array.from({ length: n }, () => Array(n).fill(-1));
    let g: number[][] = Array.from({ length: n }, () => Array(n).fill(-1));

    f[0][n - 1] = grid[0][0] + grid[0][n - 1];
    for (let i = 1; i < m; ++i) {
        for (let j1 = 0; j1 < n; ++j1) {
            for (let j2 = 0; j2 < n; ++j2) {
                let best = -1;
                for (let dj1 = j1 - 1; dj1 <= j1 + 1; ++dj1) {
                    for (let dj2 = j2 - 1; dj2 <= j2 + 1; ++dj2) {
                        if (dj1 >= 0 && dj1 < n && dj2 >= 0 && dj2 < n && f[dj1][dj2] != -1) {
                            best = Math.max(best, f[dj1][dj2] + (j1 == j2 ? grid[i][j1] : grid[i][j1] + grid[i][j2]));
                        }
                    }
                }
                g[j1][j2] = best;
            }
        }
        [f, g] = [g, f];
    }

    let ans = 0;
    for (let j1 = 0; j1 < n; ++j1) {
        ans = Math.max(ans, Math.max(...f[j1]));
    }
    return ans;
};
```

```rust
impl Solution {
    pub fn cherry_pickup(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        let mut f = vec![vec![-1; n]; n];
        let mut g = vec![vec![-1; n]; n];

        f[0][n - 1] = grid[0][0] + grid[0][n - 1];
        for i in 1..m {
            for j1 in 0..n {
                for j2 in 0..n {
                    let mut best = -1;
                    for dj1 in -1..=1 {
                        for dj2 in -1..=1 {
                            let dj1 = j1 as i32 + dj1;
                            let dj2 = j2 as i32 + dj2;
                            if dj1 >= 0 && dj1 < n as i32 && dj2 >= 0 && dj2 < n as i32 && f[dj1 as usize][dj2 as usize] != -1 {
                                best = best.max(f[dj1 as usize][dj2 as usize] + if j1 == j2 { grid[i][j1] } else { grid[i][j1] + grid[i][j2] });
                            }
                        }
                    }
                    g[j1][j2] = best;
                }
            }
            std::mem::swap(&mut f, &mut g);
        }

        let mut ans = 0;
        for j1 in 0..n {
            ans = ans.max(*f[j1].iter().max().unwrap_or(&0));
        }
        ans
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(mn^2)$。动态规划中的状态有 $mn^2$ 个，对于每个状态，我们会从最多 $3*3=9$ 个前置状态中选择一个进行转移。
- 空间复杂度：$O(mn^2)$ 或 $O(n^2)$，取决于是否使用了空间优化。
