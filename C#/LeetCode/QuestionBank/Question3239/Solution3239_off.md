### [最少翻转次数使二进制矩阵回文 I](https://leetcode.cn/problems/minimum-number-of-flips-to-make-binary-grid-palindromic-i/solutions/2981496/zui-shao-fan-zhuan-ci-shu-shi-er-jin-zhi-9vam/)

#### 方法一：双指针

我们可以分别考虑将所有行变为回文所需要的翻转次数 $rowCnt$ 或将所有列变为回文所需要的翻转次数 $textitcolCnt$，那么所需要的最少反转次数就是 $min(rowCnt,colCnt)$。

可以使用双指针同时从一行或一列的开头和结尾开始枚举，如果两个指针指向的矩阵元素不同，那么所需要的翻转次数就增加 $1$。使用双指针遍历矩阵的每一行和每一列，就能够得到 $rowCnt$ 和 $colCnt$。

**代码**

```C++
class Solution {
public:
    int minFlips(vector<vector<int>>& grid) {
        int rowCnt = 0, colCnt = 0;
        int m = grid.size(), n = grid[0].size();
        for (int i = 0; i < m; i++) {
            for (int j1 = 0, j2 = n - 1; j1 < j2; j1++, j2--) {
                if (grid[i][j1] ^ grid[i][j2]) {
                    rowCnt++;
                }
            }
        }
        for (int j = 0; j < n; j++) {
            for (int i1 = 0, i2 = m - 1; i1 < i2; i1++, i2--) {
                if (grid[i1][j] ^ grid[i2][j]) {
                    colCnt++;
                }
            }
        }
        return min(colCnt, rowCnt);
    }
};
```

```Java
class Solution {
    public int minFlips(int[][] grid) {
        int rowCnt = 0, colCnt = 0;
        int m = grid.length, n = grid[0].length;
        for (int i = 0; i < m; i++) {
            for (int j1 = 0, j2 = n - 1; j1 < j2; j1++, j2--) {
                if ((grid[i][j1] ^ grid[i][j2]) != 0) {
                    rowCnt++;
                }
            }
        }
        for (int j = 0; j < n; j++) {
            for (int i1 = 0, i2 = m - 1; i1 < i2; i1++, i2--) {
                if ((grid[i1][j] ^ grid[i2][j]) != 0) {
                    colCnt++;
                }
            }
        }
        return Math.min(colCnt, rowCnt);
    }
}
```

```CSharp
public class Solution {
    public int MinFlips(int[][] grid) {
        int rowCnt = 0, colCnt = 0;
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++) {
            for (int j1 = 0, j2 = n - 1; j1 < j2; j1++, j2--) {
                if ((grid[i][j1] ^ grid[i][j2]) != 0) {
                    rowCnt++;
                }
            }
        }
        for (int j = 0; j < n; j++) {
            for (int i1 = 0, i2 = m - 1; i1 < i2; i1++, i2--) {
                if ((grid[i1][j] ^ grid[i2][j]) != 0) {
                    colCnt++;
                }
            }
        }
        return Math.Min(colCnt, rowCnt);
    }
}
```

```Python
class Solution:
    def minFlips(self, grid: List[List[int]]) -> int:
        row_cnt, col_cnt = 0, 0
        m, n = len(grid), len(grid[0])
        for i in range(m):
            for j1 in range(n // 2):
                j2 = n - 1 - j1
                if grid[i][j1] != grid[i][j2]:
                    row_cnt += 1
        for j in range(n):
            for i1 in range(m // 2):
                i2 = m - 1 - i1
                if grid[i1][j] != grid[i2][j]:
                    col_cnt += 1
        return min(col_cnt, row_cnt)
        
```

```Go
func minFlips(grid [][]int) int {
    rowCnt, colCnt := 0, 0
    m, n := len(grid), len(grid[0])
    for i := 0; i < m; i++ {
        for j1 := 0; j1 < n / 2; j1++ {
            j2 := n - 1 - j1
            if grid[i][j1] != grid[i][j2] {
                rowCnt++
            }
        }
    }
    for j := 0; j < n; j++ {
        for i1 := 0; i1 < m / 2; i1++ {
            i2 := m - 1 - i1
            if grid[i1][j] != grid[i2][j] {
                colCnt++
            }
        }
    }
    return min(colCnt, rowCnt)
}
```

```C
int minFlips(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int rowCnt = 0, colCnt = 0;
    for (int i = 0; i < m; i++) {
        for (int j1 = 0; j1 < n / 2; j1++) {
            int j2 = n - 1 - j1;
            if (grid[i][j1] != grid[i][j2]) {
                rowCnt++;
            }
        }
    }
    for (int j = 0; j < n; j++) {
        for (int i1 = 0; i1 < m / 2; i1++) {
            int i2 = m - 1 - i1;
            if (grid[i1][j] != grid[i2][j]) {
                colCnt++;
            }
        }
    }
    return fmin(colCnt, rowCnt);
}
```

```JavaScript
var minFlips = function(grid) {
    let rowCnt = 0;
    let colCnt = 0;
    const m = grid.length;
    const n = grid[0].length;
    for (let i = 0; i < m; i++) {
        for (let j1 = 0; j1 < Math.floor(n / 2); j1++) {
            const j2 = n - 1 - j1;
            if (grid[i][j1] !== grid[i][j2]) {
                rowCnt++;
            }
        }
    }
    for (let j = 0; j < n; j++) {
        for (let i1 = 0; i1 < Math.floor(m / 2); i1++) {
            const i2 = m - 1 - i1;
            if (grid[i1][j] !== grid[i2][j]) {
                colCnt++;
            }
        }
    }
    return Math.min(colCnt, rowCnt);
};
```

```TypeScript
function minFlips(grid: number[][]): number {
    let rowCnt = 0;
    let colCnt = 0;
    const m = grid.length;
    const n = grid[0].length;
    for (let i = 0; i < m; i++) {
        for (let j1 = 0; j1 < Math.floor(n / 2); j1++) {
            const j2 = n - 1 - j1;
            if (grid[i][j1] !== grid[i][j2]) {
                rowCnt++;
            }
        }
    }
    for (let j = 0; j < n; j++) {
        for (let i1 = 0; i1 < Math.floor(m / 2); i1++) {
            const i2 = m - 1 - i1;
            if (grid[i1][j] !== grid[i2][j]) {
                colCnt++;
            }
        }
    }
    return Math.min(colCnt, rowCnt);
};
```

```Rust
impl Solution {
    pub fn min_flips(grid: Vec<Vec<i32>>) -> i32 {
        let mut row_cnt = 0;
        let mut col_cnt = 0;
        let m = grid.len();
        let n = grid[0].len();
        for i in 0..m {
            for j1 in 0..(n / 2) {
                let j2 = n - 1 - j1;
                if grid[i][j1] != grid[i][j2] {
                    row_cnt += 1;
                }
            }
        }
        for j in 0..n {
            for i1 in 0..(m / 2) {
                let i2 = m - 1 - i1;
                if grid[i1][j] != grid[i2][j] {
                    col_cnt += 1;
                }
            }
        }
        col_cnt.min(row_cnt)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别矩阵 $grid$ 的行数和列数，遍历矩阵两次来得到最小值。
- 空间复杂度：$O(1)$。
