### [最大的幻方](https://leetcode.cn/problems/largest-magic-square/solutions/825471/zui-da-de-huan-fang-by-leetcode-solution-p8a1/)

#### 方法一：枚举正方形 $+$ 前缀和优化

**思路与算法**

我们只需要按照从大到小的顺序枚举正方形的边长 $edge$，再枚举给定的矩阵 $grid$ 中所有边长为 $edge$ 的正方形，并依次判断它们是否满足幻方的要求即可。

这样做的时间复杂度是多少呢？我们记 $l=min(m,n)$，那么 $edge$ 的范围为 $[1,l]$，边长为 $edge$ 的正方形有 $(m-edge+1)(n-edge+1)=O(mn)$ 个，对于每个正方形，我们需要计算其每一行、列和对角线的和，一共有 $edge$ 行 $edge$ 列以及 $2$ 条对角线，那么计算这些和的总时间复杂度为 $((2\cdot edge+2)\cdot edge)=O(l^2)$。将所有项相乘，总时间复杂度即为 $O(l^3mn)$。

我们无法 $100%$ 保证 $O(l^3mn)$ 的算法可以在规定时间内通过所有的测试数据：虽然它的时间复杂度看起来很大，但是常数实际上很小，如果代码写得比较优秀，还是有通过的机会的。

但做一些不复杂的优化也是很有必要的。一个可行的优化点是：我们可以预处理出矩阵 $grid$ 每一行以及每一列的前缀和，这样对于计算和的部分：

- 每一行只需要 $O(1)$ 的时间即可求和，所有的 $edge$ 行的总时间复杂度为 $O(l)$；
- 每一列只需要 $O(1)$ 的时间即可求和，所有的 $edge$ 列的总时间复杂度为 $O(l)$；
- 我们没有预处理对角线的前缀和，这是因为对角线只有 $2$ 条，即使我们直接计算求和，时间复杂度也为 $O(2\cdot l)=O(l)$。

因此，求和部分的总时间复杂度从 $O(l^2)$ 降低为 $O(l)$，总时间复杂度降低为 $O(l^2mn)$，对于本题 $m,n\le 50$ 的范围，该时间复杂度是合理的。

前缀和的具体实现过程可以参考下面的代码。

**优化**

我们只需要在 $[2,l]$ 的范围内从大到小遍历 $edge$ 即可，这是因为边长为 $1$ 的正方形一定是一个幻方。

**代码**

```C++
class Solution {
public:
    int largestMagicSquare(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        // 每一行的前缀和
        vector<vector<int>> rowsum(m, vector<int>(n));
        for (int i = 0; i < m; ++i) {
            rowsum[i][0] = grid[i][0];
            for (int j = 1; j < n; ++j) {
                rowsum[i][j] = rowsum[i][j - 1] + grid[i][j];
            }
        }
        // 每一列的前缀和
        vector<vector<int>> colsum(m, vector<int>(n));
        for (int j = 0; j < n; ++j) {
            colsum[0][j] = grid[0][j];
            for (int i = 1; i < m; ++i) {
                colsum[i][j] = colsum[i - 1][j] + grid[i][j];
            }
        }

        // 从大到小枚举边长 edge
        for (int edge = min(m, n); edge >= 2; --edge) {
            // 枚举正方形的左上角位置 (i,j)
            for (int i = 0; i + edge <= m; ++i) {
                for (int j = 0; j + edge <= n; ++j) {
                    // 计算每一行、列、对角线的值应该是多少（以第一行为样本）
                    int stdsum = rowsum[i][j + edge - 1] - (j ? rowsum[i][j - 1] : 0);
                    bool check = true;
                    // 枚举每一行并用前缀和直接求和
                    // 由于我们已经拿第一行作为样本了，这里可以跳过第一行
                    for (int ii = i + 1; ii < i + edge; ++ii) {
                        if (rowsum[ii][j + edge - 1] - (j ? rowsum[ii][j - 1] : 0) != stdsum) {
                            check = false;
                            break;
                        }
                    }
                    if (!check) {
                        continue;
                    }
                    // 枚举每一列并用前缀和直接求和
                    for (int jj = j; jj < j + edge; ++jj) {
                        if (colsum[i + edge - 1][jj] - (i ? colsum[i - 1][jj] : 0) != stdsum) {
                            check = false;
                            break;
                        }
                    }
                    if (!check) {
                        continue;
                    }
                    // d1 和 d2 分别表示两条对角线的和
                    // 这里 d 表示 diagonal
                    int d1 = 0, d2 = 0;
                    // 不使用前缀和，直接遍历求和
                    for (int k = 0; k < edge; ++k) {
                        d1 += grid[i + k][j + k];
                        d2 += grid[i + k][j + edge - 1 - k];
                    }
                    if (d1 == stdsum && d2 == stdsum) {
                        return edge;
                    }
                }
            }
        }

        return 1;
    }
};
```

```Python
class Solution:
    def largestMagicSquare(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])

        # 每一行的前缀和
        rowsum = [[0] * n for _ in range(m)]
        for i in range(m):
            rowsum[i][0] = grid[i][0]
            for j in range(1, n):
                rowsum[i][j] = rowsum[i][j - 1] + grid[i][j]

        # 每一列的前缀和
        colsum = [[0] * n for _ in range(m)]
        for j in range(n):
            colsum[0][j] = grid[0][j]
            for i in range(1, m):
                colsum[i][j] = colsum[i - 1][j] + grid[i][j]

        # 从大到小枚举边长 edge
        for edge in range(min(m, n), 1, -1):
            # 枚举正方形的左上角位置 (i,j)
            for i in range(m - edge + 1):
                for j in range(n - edge + 1):
                    # 计算每一行、列、对角线的值应该是多少（以第一行为样本）
                    stdsum = rowsum[i][j + edge - 1] - (0 if j == 0 else rowsum[i][j - 1])
                    check = True
                    # 枚举每一行并用前缀和直接求和
                    # 由于我们已经拿第一行作为样本了，这里可以跳过第一行
                    for ii in range(i + 1, i + edge):
                        if rowsum[ii][j + edge - 1] - (0 if j == 0 else rowsum[ii][j - 1]) != stdsum:
                            check = False
                            break
                    if not check:
                        continue

                    # 枚举每一列并用前缀和直接求和
                    for jj in range(j, j + edge):
                        if colsum[i + edge - 1][jj] - (0 if i == 0 else colsum[i - 1][jj]) != stdsum:
                            check = False
                            break
                    if not check:
                        continue

                    # d1 和 d2 分别表示两条对角线的和
                    # 这里 d 表示 diagonal
                    d1 = d2 = 0
                    # 不使用前缀和，直接遍历求和
                    for k in range(edge):
                        d1 += grid[i + k][j + k]
                        d2 += grid[i + k][j + edge - 1 - k]
                    if d1 == stdsum and d2 == stdsum:
                        return edge

        return 1
```

```Java
class Solution {
    public int largestMagicSquare(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        // 每一行的前缀和
        int[][] rowsum = new int[m][n];
        for (int i = 0; i < m; ++i) {
            rowsum[i][0] = grid[i][0];
            for (int j = 1; j < n; ++j) {
                rowsum[i][j] = rowsum[i][j - 1] + grid[i][j];
            }
        }
        // 每一列的前缀和
        int[][] colsum = new int[m][n];
        for (int j = 0; j < n; ++j) {
            colsum[0][j] = grid[0][j];
            for (int i = 1; i < m; ++i) {
                colsum[i][j] = colsum[i - 1][j] + grid[i][j];
            }
        }

        // 从大到小枚举边长 edge
        for (int edge = Math.min(m, n); edge >= 2; --edge) {
            // 枚举正方形的左上角位置 (i,j)
            for (int i = 0; i + edge <= m; ++i) {
                for (int j = 0; j + edge <= n; ++j) {
                    // 计算每一行、列、对角线的值应该是多少（以第一行为样本）
                    int stdsum = rowsum[i][j + edge - 1] - (j > 0 ? rowsum[i][j - 1] : 0);
                    boolean check = true;
                    // 枚举每一行并用前缀和直接求和
                    for (int ii = i + 1; ii < i + edge; ++ii) {
                        if (rowsum[ii][j + edge - 1] - (j > 0 ? rowsum[ii][j - 1] : 0) != stdsum) {
                            check = false;
                            break;
                        }
                    }
                    if (!check) continue;
                    // 枚举每一列并用前缀和直接求和
                    for (int jj = j; jj < j + edge; ++jj) {
                        if (colsum[i + edge - 1][jj] - (i > 0 ? colsum[i - 1][jj] : 0) != stdsum) {
                            check = false;
                            break;
                        }
                    }
                    if (!check) continue;
                    // 两条对角线的和
                    int d1 = 0, d2 = 0;
                    for (int k = 0; k < edge; ++k) {
                        d1 += grid[i + k][j + k];
                        d2 += grid[i + k][j + edge - 1 - k];
                    }
                    if (d1 == stdsum && d2 == stdsum) {
                        return edge;
                    }
                }
            }
        }
        return 1;
    }
}
```

```CSharp
public class Solution {
    public int LargestMagicSquare(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        // 每一行的前缀和
        int[][] rowsum = new int[m][];
        for (int i = 0; i < m; ++i) {
            rowsum[i] = new int[n];
            rowsum[i][0] = grid[i][0];
            for (int j = 1; j < n; ++j) {
                rowsum[i][j] = rowsum[i][j - 1] + grid[i][j];
            }
        }
        // 每一列的前缀和
        int[][] colsum = new int[m][];
        for (int i = 0; i < m; ++i) {
            colsum[i] = new int[n];
        }
        for (int j = 0; j < n; ++j) {
            colsum[0][j] = grid[0][j];
            for (int i = 1; i < m; ++i) {
                colsum[i][j] = colsum[i - 1][j] + grid[i][j];
            }
        }

        // 从大到小枚举边长 edge
        for (int edge = Math.Min(m, n); edge >= 2; --edge) {
            // 枚举正方形的左上角位置 (i,j)
            for (int i = 0; i + edge <= m; ++i) {
                for (int j = 0; j + edge <= n; ++j) {
                    // 计算标准值
                    int stdsum = rowsum[i][j + edge - 1] - (j > 0 ? rowsum[i][j - 1] : 0);
                    bool check = true;
                    // 检查每一行
                    for (int ii = i + 1; ii < i + edge; ++ii) {
                        if (rowsum[ii][j + edge - 1] - (j > 0 ? rowsum[ii][j - 1] : 0) != stdsum) {
                            check = false;
                            break;
                        }
                    }
                    if (!check) continue;
                    // 检查每一列
                    for (int jj = j; jj < j + edge; ++jj) {
                        if (colsum[i + edge - 1][jj] - (i > 0 ? colsum[i - 1][jj] : 0) != stdsum) {
                            check = false;
                            break;
                        }
                    }
                    if (!check) continue;
                    // 检查对角线
                    int d1 = 0, d2 = 0;
                    for (int k = 0; k < edge; ++k) {
                        d1 += grid[i + k][j + k];
                        d2 += grid[i + k][j + edge - 1 - k];
                    }
                    if (d1 == stdsum && d2 == stdsum) {
                        return edge;
                    }
                }
            }
        }
        return 1;
    }
}
```

```Go
func largestMagicSquare(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    // 每一行的前缀和
    rowsum := make([][]int, m)
    for i := 0; i < m; i++ {
        rowsum[i] = make([]int, n)
        rowsum[i][0] = grid[i][0]
        for j := 1; j < n; j++ {
            rowsum[i][j] = rowsum[i][j-1] + grid[i][j]
        }
    }
    // 每一列的前缀和
    colsum := make([][]int, m)
    for i := 0; i < m; i++ {
        colsum[i] = make([]int, n)
    }
    for j := 0; j < n; j++ {
        colsum[0][j] = grid[0][j]
        for i := 1; i < m; i++ {
            colsum[i][j] = colsum[i-1][j] + grid[i][j]
        }
    }

    for edge := min(m, n); edge >= 2; edge-- {
        // 枚举正方形的左上角位置 (i,j)
        for i := 0; i+edge <= m; i++ {
            for j := 0; j+edge <= n; j++ {
                // 计算标准值
                stdsum := rowsum[i][j+edge-1]
                if j > 0 {
                    stdsum -= rowsum[i][j-1]
                }
                check := true
                // 检查每一行
                for ii := i + 1; ii < i+edge; ii++ {
                    sum := rowsum[ii][j+edge-1]
                    if j > 0 {
                        sum -= rowsum[ii][j-1]
                    }
                    if sum != stdsum {
                        check = false
                        break
                    }
                }
                if !check {
                    continue
                }
                // 检查每一列
                for jj := j; jj < j+edge; jj++ {
                    sum := colsum[i+edge-1][jj]
                    if i > 0 {
                        sum -= colsum[i-1][jj]
                    }
                    if sum != stdsum {
                        check = false
                        break
                    }
                }
                if !check {
                    continue
                }
                // 检查对角线
                d1, d2 := 0, 0
                for k := 0; k < edge; k++ {
                    d1 += grid[i+k][j+k]
                    d2 += grid[i+k][j+edge-1-k]
                }
                if d1 == stdsum && d2 == stdsum {
                    return edge
                }
            }
        }
    }
    return 1
}
```

```C
int largestMagicSquare(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    // 每一行的前缀和
    int** rowsum = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; ++i) {
        rowsum[i] = (int*)malloc(n * sizeof(int));
        rowsum[i][0] = grid[i][0];
        for (int j = 1; j < n; ++j) {
            rowsum[i][j] = rowsum[i][j - 1] + grid[i][j];
        }
    }
    // 每一列的前缀和
    int** colsum = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; ++i) {
        colsum[i] = (int*)malloc(n * sizeof(int));
    }
    for (int j = 0; j < n; ++j) {
        colsum[0][j] = grid[0][j];
        for (int i = 1; i < m; ++i) {
            colsum[i][j] = colsum[i - 1][j] + grid[i][j];
        }
    }

    int min_edge = m < n ? m : n;
    // 从大到小枚举边长 edge
    for (int edge = min_edge; edge >= 2; --edge) {
        // 枚举正方形的左上角位置 (i,j)
        for (int i = 0; i + edge <= m; ++i) {
            for (int j = 0; j + edge <= n; ++j) {
                // 计算标准值
                int stdsum = rowsum[i][j + edge - 1] - (j > 0 ? rowsum[i][j - 1] : 0);
                int check = 1;
                // 检查每一行
                for (int ii = i + 1; ii < i + edge; ++ii) {
                    int sum = rowsum[ii][j + edge - 1] - (j > 0 ? rowsum[ii][j - 1] : 0);
                    if (sum != stdsum) {
                        check = 0;
                        break;
                    }
                }
                if (!check) continue;
                // 检查每一列
                for (int jj = j; jj < j + edge; ++jj) {
                    int sum = colsum[i + edge - 1][jj] - (i > 0 ? colsum[i - 1][jj] : 0);
                    if (sum != stdsum) {
                        check = 0;
                        break;
                    }
                }
                if (!check) continue;
                // 检查对角线
                int d1 = 0, d2 = 0;
                for (int k = 0; k < edge; ++k) {
                    d1 += grid[i + k][j + k];
                    d2 += grid[i + k][j + edge - 1 - k];
                }
                if (d1 == stdsum && d2 == stdsum) {
                    // 释放内存
                    for (int i = 0; i < m; ++i) {
                        free(rowsum[i]);
                        free(colsum[i]);
                    }
                    free(rowsum);
                    free(colsum);
                    return edge;
                }
            }
        }
    }

    // 释放内存
    for (int i = 0; i < m; ++i) {
        free(rowsum[i]);
        free(colsum[i]);
    }
    free(rowsum);
    free(colsum);

    return 1;
}
```

```JavaScript
var largestMagicSquare = function(grid) {
    const m = grid.length, n = grid[0].length;
    // 每一行的前缀和
    const rowsum = Array.from({length: m}, () => new Array(n));
    for (let i = 0; i < m; ++i) {
        rowsum[i][0] = grid[i][0];
        for (let j = 1; j < n; ++j) {
            rowsum[i][j] = rowsum[i][j - 1] + grid[i][j];
        }
    }
    // 每一列的前缀和
    const colsum = Array.from({length: m}, () => new Array(n));
    for (let j = 0; j < n; ++j) {
        colsum[0][j] = grid[0][j];
        for (let i = 1; i < m; ++i) {
            colsum[i][j] = colsum[i - 1][j] + grid[i][j];
        }
    }

    // 从大到小枚举边长 edge
    for (let edge = Math.min(m, n); edge >= 2; --edge) {
        // 枚举正方形的左上角位置 (i,j)
        for (let i = 0; i + edge <= m; ++i) {
            for (let j = 0; j + edge <= n; ++j) {
                // 计算标准值
                let stdsum = rowsum[i][j + edge - 1] - (j > 0 ? rowsum[i][j - 1] : 0);
                let check = true;
                // 检查每一行
                for (let ii = i + 1; ii < i + edge; ++ii) {
                    let sum = rowsum[ii][j + edge - 1] - (j > 0 ? rowsum[ii][j - 1] : 0);
                    if (sum !== stdsum) {
                        check = false;
                        break;
                    }
                }
                if (!check) continue;
                // 检查每一列
                for (let jj = j; jj < j + edge; ++jj) {
                    let sum = colsum[i + edge - 1][jj] - (i > 0 ? colsum[i - 1][jj] : 0);
                    if (sum !== stdsum) {
                        check = false;
                        break;
                    }
                }
                if (!check) continue;
                // 检查对角线
                let d1 = 0, d2 = 0;
                for (let k = 0; k < edge; ++k) {
                    d1 += grid[i + k][j + k];
                    d2 += grid[i + k][j + edge - 1 - k];
                }
                if (d1 === stdsum && d2 === stdsum) {
                    return edge;
                }
            }
        }
    }
    return 1;
};
```

```TypeScript
function largestMagicSquare(grid: number[][]): number {
    const m = grid.length, n = grid[0].length;
    // 每一行的前缀和
    const rowsum: number[][] = Array.from({length: m}, () => new Array(n));
    for (let i = 0; i < m; ++i) {
        rowsum[i][0] = grid[i][0];
        for (let j = 1; j < n; ++j) {
            rowsum[i][j] = rowsum[i][j - 1] + grid[i][j];
        }
    }
    // 每一列的前缀和
    const colsum: number[][] = Array.from({length: m}, () => new Array(n));
    for (let j = 0; j < n; ++j) {
        colsum[0][j] = grid[0][j];
        for (let i = 1; i < m; ++i) {
            colsum[i][j] = colsum[i - 1][j] + grid[i][j];
        }
    }

    // 从大到小枚举边长 edge
    for (let edge = Math.min(m, n); edge >= 2; --edge) {
        // 枚举正方形的左上角位置 (i,j)
        for (let i = 0; i + edge <= m; ++i) {
            for (let j = 0; j + edge <= n; ++j) {
                // 计算标准值
                const stdsum = rowsum[i][j + edge - 1] - (j > 0 ? rowsum[i][j - 1] : 0);
                let check = true;
                // 检查每一行
                for (let ii = i + 1; ii < i + edge; ++ii) {
                    const sum = rowsum[ii][j + edge - 1] - (j > 0 ? rowsum[ii][j - 1] : 0);
                    if (sum !== stdsum) {
                        check = false;
                        break;
                    }
                }
                if (!check) continue;
                // 检查每一列
                for (let jj = j; jj < j + edge; ++jj) {
                    const sum = colsum[i + edge - 1][jj] - (i > 0 ? colsum[i - 1][jj] : 0);
                    if (sum !== stdsum) {
                        check = false;
                        break;
                    }
                }
                if (!check) continue;
                // 检查对角线
                let d1 = 0, d2 = 0;
                for (let k = 0; k < edge; ++k) {
                    d1 += grid[i + k][j + k];
                    d2 += grid[i + k][j + edge - 1 - k];
                }
                if (d1 === stdsum && d2 === stdsum) {
                    return edge;
                }
            }
        }
    }
    return 1;
}
```

```Rust
impl Solution {
    pub fn largest_magic_square(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        // 每一行的前缀和
        let mut rowsum = vec![vec![0; n]; m];
        for i in 0..m {
            rowsum[i][0] = grid[i][0];
            for j in 1..n {
                rowsum[i][j] = rowsum[i][j - 1] + grid[i][j];
            }
        }
        // 每一列的前缀和
        let mut colsum = vec![vec![0; n]; m];
        for j in 0..n {
            colsum[0][j] = grid[0][j];
            for i in 1..m {
                colsum[i][j] = colsum[i - 1][j] + grid[i][j];
            }
        }

        // 从大到小枚举边长 edge
        for edge in (2..=m.min(n)).rev() {
            let edge = edge as i32;
            // 枚举正方形的左上角位置 (i,j)
            for i in 0..=(m as i32 - edge) {
                for j in 0..=(n as i32 - edge) {
                    let i = i as usize;
                    let j = j as usize;
                    // 计算标准值
                    let stdsum = rowsum[i][j + edge as usize - 1] - if j > 0 { rowsum[i][j - 1] } else { 0 };
                    let mut check = true;
                    // 检查每一行
                    for ii in i + 1..i + edge as usize {
                        let sum = rowsum[ii][j + edge as usize - 1] - if j > 0 { rowsum[ii][j - 1] } else { 0 };
                        if sum != stdsum {
                            check = false;
                            break;
                        }
                    }
                    if !check {
                        continue;
                    }
                    // 检查每一列
                    for jj in j..j + edge as usize {
                        let sum = colsum[i + edge as usize - 1][jj] - if i > 0 { colsum[i - 1][jj] } else { 0 };
                        if sum != stdsum {
                            check = false;
                            break;
                        }
                    }
                    if !check {
                        continue;
                    }
                    // 检查对角线
                    let mut d1 = 0;
                    let mut d2 = 0;
                    for k in 0..edge as usize {
                        d1 += grid[i + k][j + k];
                        d2 += grid[i + k][j + edge as usize - 1 - k];
                    }
                    if d1 == stdsum && d2 == stdsum {
                        return edge;
                    }
                }
            }
        }
        1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mnmin(m,n)^2)$。
- 空间复杂度：$O(mn)$，即为存储前缀和需要的空间。
