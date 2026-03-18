### [元素和小于等于 k 的子矩阵的数目](https://leetcode.cn/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/solutions/3920188/yuan-su-he-xiao-yu-deng-yu-k-de-zi-ju-zh-5ry4/)

#### 方法一：二维前缀和

**思路与算法**

题目要求统计包含矩阵 $grid$ 左上角元素的所有子矩阵中，元素和不超过 $k$ 的子矩阵个数。

我们从左上角出发，按行优先顺序遍历矩阵，将当前访问位置 $(i,j)$ 视为子矩阵的右下角。为了在一次遍历中高效计算子矩阵的和，我们维护一个数组 $cols[j]$，用于记录当前行之前第 $j$ 列所有元素的和。在遍历第 $i$ 行时，按列从左到右遍历 $j$，将 $grid[i][j]$ 累加到 cols[j]后，并将 $cols[j]$ 累加起来，若当前累加和 $\le k$，则答案加 $1$。

**代码**

```C++
class Solution {
public:
    int countSubmatrices(vector<vector<int>>& grid, int k) {
        int n = grid.size(), m = grid[0].size();
        vector<int> cols(m);
        int res = 0;
        for (int i = 0; i < n; i++) {
            int rows = 0;
            for (int j = 0; j < m; j++) {
                cols[j] += grid[i][j];
                rows += cols[j];
                if (rows <= k) {
                    res++;
                }
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def countSubmatrices(self, grid: List[List[int]], k: int) -> int:
        n, m = len(grid), len(grid[0])
        cols = [0] * m
        res = 0

        for i in range(n):
            row_sum = 0
            for j in range(m):
                cols[j] += grid[i][j]
                row_sum += cols[j]
                if row_sum <= k:
                    res += 1

        return res
```

```Rust
impl Solution {
    pub fn count_submatrices(grid: Vec<Vec<i32>>, k: i32) -> i32 {
        let n = grid.len();
        let m = grid[0].len();
        let mut cols = vec![0; m];
        let mut res = 0;

        for i in 0..n {
            let mut row_sum = 0;
            for j in 0..m {
                cols[j] += grid[i][j];
                row_sum += cols[j];
                if row_sum <= k {
                    res += 1;
                }
            }
        }

        res
    }
}
```

```Java
class Solution {
    public int countSubmatrices(int[][] grid, int k) {
        int n = grid.length, m = grid[0].length;
        int[] cols = new int[m];
        int res = 0;

        for (int i = 0; i < n; i++) {
            int rows = 0;
            for (int j = 0; j < m; j++) {
                cols[j] += grid[i][j];
                rows += cols[j];
                if (rows <= k) {
                    res++;
                }
            }
        }

        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountSubmatrices(int[][] grid, int k) {
        int n = grid.Length, m = grid[0].Length;
        int[] cols = new int[m];
        int res = 0;

        for (int i = 0; i < n; i++) {
            int rows = 0;
            for (int j = 0; j < m; j++) {
                cols[j] += grid[i][j];
                rows += cols[j];
                if (rows <= k) {
                    res++;
                }
            }
        }

        return res;
    }
}
```

```Go
func countSubmatrices(grid [][]int, k int) int {
    n := len(grid)
    m := len(grid[0])
    cols := make([]int, m)
    res := 0

    for i := 0; i < n; i++ {
        rows := 0
        for j := 0; j < m; j++ {
            cols[j] += grid[i][j]
            rows += cols[j]
            if rows <= k {
                res++
            }
        }
    }

    return res
}
```

```C
int countSubmatrices(int** grid, int gridSize, int* gridColSize, int k) {
    int n = gridSize;
    int m = *gridColSize;
    int* cols = (int*)calloc(m, sizeof(int));
    int res = 0;

    for (int i = 0; i < n; i++) {
        int rows = 0;
        for (int j = 0; j < m; j++) {
            cols[j] += grid[i][j];
            rows += cols[j];
            if (rows <= k) {
                res++;
            }
        }
    }

    free(cols);
    return res;
}
```

```JavaScript
var countSubmatrices = function(grid, k) {
    const n = grid.length;
    const m = grid[0].length;
    const cols = new Array(m).fill(0);
    let res = 0;

    for (let i = 0; i < n; i++) {
        let rows = 0;
        for (let j = 0; j < m; j++) {
            cols[j] += grid[i][j];
            rows += cols[j];
            if (rows <= k) {
                res++;
            }
        }
    }

    return res;
};
```

```TypeScript
function countSubmatrices(grid: number[][], k: number): number {
    const n: number = grid.length;
    const m: number = grid[0].length;
    const cols: number[] = new Array(m).fill(0);
    let res: number = 0;

    for (let i = 0; i < n; i++) {
        let rows: number = 0;
        for (let j = 0; j < m; j++) {
            cols[j] += grid[i][j];
            rows += cols[j];
            if (rows <= k) {
                res++;
            }
        }
    }

    return res;
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 是 $grid$ 的行数，$n$ 是 $grid$ 的列数。
- 空间复杂度：$O(n)$。
