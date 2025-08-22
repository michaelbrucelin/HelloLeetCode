### [包含所有 1 的最小矩形面积 I](https://leetcode.cn/problems/find-the-minimum-area-to-cover-all-ones-i/solutions/3751483/bao-han-suo-you-1-de-zui-xiao-ju-xing-mi-zty7/)

#### 方法一：一次遍历

**思路与算法**

遍历过程中我们要找到 $1$ 出现的上下左右边界。然后根据边界计算最小面积。

**代码**

```C++
class Solution {
public:
    int minimumArea(vector<vector<int>>& grid) {
        int n = grid.size(), m = grid[0].size();
        int min_i = n, max_i = 0;
        int min_j = m, max_j = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) {
                    min_i = min(min_i, i);
                    max_i = max(max_i, i);
                    min_j = min(min_j, j);
                    max_j = max(max_j, j);
                }
            }
        }
        return (max_i - min_i + 1) * (max_j - min_j + 1);
    }
};
```

```Java
class Solution {
    public int minimumArea(int[][] grid) {
        int n = grid.length, m = grid[0].length;
        int min_i = n, max_i = 0;
        int min_j = m, max_j = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) {
                    min_i = Math.min(min_i, i);
                    max_i = Math.max(max_i, i);
                    min_j = Math.min(min_j, j);
                    max_j = Math.max(max_j, j);
                }
            }
        }
        return (max_i - min_i + 1) * (max_j - min_j + 1);
    }
}
```

```CSharp
public class Solution {
    public int MinimumArea(int[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        int min_i = n, max_i = 0;
        int min_j = m, max_j = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1) {
                    min_i = Math.Min(min_i, i);
                    max_i = Math.Max(max_i, i);
                    min_j = Math.Min(min_j, j);
                    max_j = Math.Max(max_j, j);
                }
            }
        }
        return (max_i - min_i + 1) * (max_j - min_j + 1);
    }
}
```

```Python
class Solution:
    def minimumArea(self, grid: List[List[int]]) -> int:
        n, m = len(grid), len(grid[0])
        min_i, max_i = n, 0
        min_j, max_j = m, 0
        
        for i in range(n):
            for j in range(m):
                if grid[i][j] == 1:
                    min_i = min(min_i, i)
                    max_i = max(max_i, i)
                    min_j = min(min_j, j)
                    max_j = max(max_j, j)
        
        return (max_i - min_i + 1) * (max_j - min_j + 1)
```

```Go
func minimumArea(grid [][]int) int {
    n, m := len(grid), len(grid[0])
    min_i, max_i := n, 0
    min_j, max_j := m, 0
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            if grid[i][j] == 1 {
                min_i = min(min_i, i)
                max_i = max(max_i, i)
                min_j = min(min_j, j)
                max_j = max(max_j, j)
            }
        }
    }
    return (max_i - min_i + 1) * (max_j - min_j + 1)
}
```

```C
int minimumArea(int** grid, int gridSize, int* gridColSize) {
    int n = gridSize, m = gridColSize[0];
    int min_i = n, max_i = 0;
    int min_j = m, max_j = 0;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            if (grid[i][j] == 1) {
                if (i < min_i) {
                    min_i = i;
                }
                if (i > max_i) {
                    max_i = i;
                }
                if (j < min_j) {
                    min_j = j;
                }
                if (j > max_j) {
                    max_j = j;
                }
            }
        }
    }
    return (max_i - min_i + 1) * (max_j - min_j + 1);
}
```

```JavaScript
var minimumArea = function(grid) {
    const n = grid.length, m = grid[0].length;
    let min_i = n, max_i = 0;
    let min_j = m, max_j = 0;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            if (grid[i][j] === 1) {
                min_i = Math.min(min_i, i);
                max_i = Math.max(max_i, i);
                min_j = Math.min(min_j, j);
                max_j = Math.max(max_j, j);
            }
        }
    }
    return (max_i - min_i + 1) * (max_j - min_j + 1);
};

```

```TypeScript
function minimumArea(grid: number[][]): number {
    const n = grid.length, m = grid[0].length;
    let min_i = n, max_i = 0;
    let min_j = m, max_j = 0;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            if (grid[i][j] === 1) {
                min_i = Math.min(min_i, i);
                max_i = Math.max(max_i, i);
                min_j = Math.min(min_j, j);
                max_j = Math.max(max_j, j);
            }
        }
    }
    return (max_i - min_i + 1) * (max_j - min_j + 1);
}
```

```Rust
impl Solution {
    pub fn minimum_area(grid: Vec<Vec<i32>>) -> i32 {
        let n = grid.len();
        let m = grid[0].len();
        let mut min_i = n;
        let mut max_i = 0;
        let mut min_j = m;
        let mut max_j = 0;
        
        for (i, row) in grid.iter().enumerate() {
            for (j, &val) in row.iter().enumerate() {
                if val == 1 {
                    min_i = min_i.min(i);
                    max_i = max_i.max(i);
                    min_j = min_j.min(j);
                    max_j = max_j.max(j);
                }
            }
        }
        
        ((max_i - min_i + 1) * (max_j - min_j + 1)) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中 $n$ 是 $grid$ 的长度，$m$ 是 $grid[0]$ 的长度。
- 空间复杂度：$O(1)$。
