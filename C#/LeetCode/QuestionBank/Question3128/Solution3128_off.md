### [直角三角形](https://leetcode.cn/problems/right-triangles/solutions/2861202/zhi-jiao-san-jiao-xing-by-leetcode-solut-zbz2/)

#### 方法一：枚举

**思路与算法**

直接枚举三个点判断是否为直角三角形的方法未免过于低效，我们可以固定一个点，然后来统计其他两个点的合法方法数。

考虑枚举两条直角边的交点，然后将「该点所在行的其他点」与「该点所在列的其他点」一一匹配，即可得到所有以该点为直角边交点的所有方案。设 $row$ 为交点所在行 $1$ 的个数，$col$ 为交点所在列 $1$ 的个数，那么它的贡献是 $(row-1) \times (col-1)$，将所有交点的贡献加起来就是答案。

**代码**

```Python
class Solution:
    def numberOfRightTriangles(self, grid: List[List[int]]) -> int:
        n, m = len(grid), len(grid[0])
        col = [0] * m
        for j in range(m):
            for i in range(n):
                col[j] += grid[i][j]
        res = 0
        for i in range(n):
            row = sum(grid[i])
            for j in range(m):
                if grid[i][j] == 1:
                    res += (row - 1) * (col[j] - 1)
        return res
```

```C++
class Solution {
public:
    long long numberOfRightTriangles(vector<vector<int>>& grid) {
        int n = grid.size(), m = grid[0].size();
        vector<int> col(m);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                col[j] += grid[i][j];
            }
        }
        long long res = 0;
        for (int i = 0; i < n; i++) {
            int row = accumulate(grid[i].begin(), grid[i].end(), 0);
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) {
                    res += (row - 1) * (col[j] - 1);
                }
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public long numberOfRightTriangles(int[][] grid) {
        int n = grid.length, m = grid[0].length;
        int[] col = new int[m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                col[j] += grid[i][j];
            }
        }
        long res = 0;
        for (int i = 0; i < n; i++) {
            int row = Arrays.stream(grid[i]).sum();
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) {
                    res += (row - 1) * (col[j] - 1);
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long NumberOfRightTriangles(int[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        int[] col = new int[m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                col[j] += grid[i][j];
            }
        }
        long res = 0;
        for (int i = 0; i < n; i++) {
            int row = grid[i].Sum();
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) {
                    res += (row - 1) * (col[j] - 1);
                }
            }
        }
        return res;
    }
}
```

```C
long long numberOfRightTriangles(int** grid, int gridSize, int* gridColSize) {
    int n = gridSize, m = gridColSize[0];
    int col[m];
    memset(col, 0, sizeof(col));
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            col[j] += grid[i][j];
        }
    }

    long long res = 0;
    for (int i = 0; i < n; i++) {
        int row = 0;
        for (int j = 0; j < m; j++) {
            row += grid[i][j];
        }
        for (int j = 0; j < m; j++) {
            if (grid[i][j] == 1) {
                res += (long long)(row - 1) * (col[j] - 1);
            }
        }
    }
    return res;
}
```

```Go
func numberOfRightTriangles(grid [][]int) int64 {
    n := len(grid)
    m := len(grid[0])
    col := make([]int, m)
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            col[j] += grid[i][j]
        }
    }

    var res int64
    for i := 0; i < n; i++ {
        row := 0
        for j := 0; j < m; j++ {
            row += grid[i][j]
        }
        for j := 0; j < m; j++ {
            if grid[i][j] == 1 {
                res += int64(row-1) * int64(col[j]-1)
            }
        }
    }
    return res
}
```

```JavaScript
var numberOfRightTriangles = function(grid) {
    const n = grid.length;
    const m = grid[0].length;
    const col = Array(m).fill(0);

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            col[j] += grid[i][j];
        }
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        let row = grid[i].reduce((a, b) => a + b, 0);
        for (let j = 0; j < m; j++) {
            if (grid[i][j] === 1) {
                res +=(row - 1) * (col[j] - 1);
            }
        }
    }

    return res;
};
```

```TypeScript
function numberOfRightTriangles(grid: number[][]): number {
    const n = grid.length;
    const m = grid[0].length;
    const col = new Array(m).fill(0);

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            col[j] += grid[i][j];
        }
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        let row = grid[i].reduce((a, b) => a + b, 0);
        for (let j = 0; j < m; j++) {
            if (grid[i][j] === 1) {
                res += (row - 1) * (col[j] - 1);
            }
        }
    }

    return res;
};
```

```Rust
impl Solution {
    pub fn number_of_right_triangles(grid: Vec<Vec<i32>>) -> i64 {
        let n = grid.len();
        let m = grid[0].len();
        let mut col = vec![0; m];

        for i in 0..n {
            for j in 0..m {
                col[j] += grid[i][j];
            }
        }
        let mut res: i64 = 0;
        for i in 0..n {
            let row: i32 = grid[i].iter().sum();
            for j in 0..m {
                if grid[i][j] == 1 {
                    res += (row - 1) as i64 * (col[j] - 1) as i64;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中 $n$ 是 $grid$ 的行数，$m$ 是 $grid$ 的列数。
- 空间复杂度：$O(m)$。
