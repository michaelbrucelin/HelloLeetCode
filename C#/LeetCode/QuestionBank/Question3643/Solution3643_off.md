### [垂直翻转子矩阵](https://leetcode.cn/problems/flip-square-submatrix-vertically/solutions/3926928/chui-zhi-fan-zhuan-zi-ju-zhen-by-leetcod-aco6/)

#### 方法一：模拟

**思路与算法**

题目要求对以 $(x,y)$ 为左上角、边长为 $k$ 的正方形子矩阵，将其行顺序进行垂直翻转，即第一行与最后一行交换，第二行与倒数第二行交换，以此类推。

我们使用两个指针 $i_0$ 和 $i_1$，分别从子矩阵的首行 $x$ 和末行 $x+k-1$ 开始，向中间靠拢。每一步中，对于子矩阵所在的列范围 $j\in [y,y+k)$，逐列交换 $grid[i_0][j]$ 与 $grid[i_1][j]$，然后令 $i_0$ 加一、$i_1$ 减一，直到 $i_0\ge i_1$ 为止，即可完成交换操作。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> reverseSubmatrix(vector<vector<int>>& grid, int x, int y, int k) {
        for (int i0 = x, i1 = x + k - 1; i0 < i1; ++i0, --i1) {
            for (int j = y; j < y + k; ++j) {
                swap(grid[i0][j], grid[i1][j]);
            }
        }
        return grid;
    }
};
```

```Python
class Solution:
    def reverseSubmatrix(self, grid: List[List[int]], x: int, y: int, k: int) -> List[List[int]]:
        i0, i1 = x, x + k - 1
        while i0 < i1:
            for j in range(y, y + k):
                grid[i0][j], grid[i1][j] = grid[i1][j], grid[i0][j]
            i0, i1 = i0 + 1, i1 - 1
        return grid
```

```Java
class Solution {
    public int[][] reverseSubmatrix(int[][] grid, int x, int y, int k) {
        for (int i0 = x, i1 = x + k - 1; i0 < i1; i0++, i1--) {
            for (int j = y; j < y + k; j++) {
                int temp = grid[i0][j];
                grid[i0][j] = grid[i1][j];
                grid[i1][j] = temp;
            }
        }
        return grid;
    }
}
```

```CSharp
public class Solution {
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k) {
        for (int i0 = x, i1 = x + k - 1; i0 < i1; i0++, i1--) {
            for (int j = y; j < y + k; j++) {
                int temp = grid[i0][j];
                grid[i0][j] = grid[i1][j];
                grid[i1][j] = temp;
            }
        }
        return grid;
    }
}
```

```Go
func reverseSubmatrix(grid [][]int, x int, y int, k int) [][]int {
    for i0, i1 := x, x+k-1; i0 < i1; i0, i1 = i0+1, i1-1 {
        for j := y; j < y+k; j++ {
            grid[i0][j], grid[i1][j] = grid[i1][j], grid[i0][j]
        }
    }
    return grid
}
```

```C
int** reverseSubmatrix(int** grid, int gridSize, int* gridColSize, int x, int y, int k, int* returnSize, int** returnColumnSizes) {
    for (int i0 = x, i1 = x + k - 1; i0 < i1; ++i0, --i1) {
        for (int j = y; j < y + k; ++j) {
            int temp = grid[i0][j];
            grid[i0][j] = grid[i1][j];
            grid[i1][j] = temp;
        }
    }
    *returnSize = gridSize;
    *returnColumnSizes = gridColSize;
    return grid;
}
```

```JavaScript
var reverseSubmatrix = function(grid, x, y, k) {
    for (let i0 = x, i1 = x + k - 1; i0 < i1; i0++, i1--) {
        for (let j = y; j < y + k; j++) {
            [grid[i0][j], grid[i1][j]] = [grid[i1][j], grid[i0][j]];
        }
    }
    return grid;
};
```

```TypeScript
function reverseSubmatrix(grid: number[][], x: number, y: number, k: number): number[][] {
    for (let i0 = x, i1 = x + k - 1; i0 < i1; i0++, i1--) {
        for (let j = y; j < y + k; j++) {
            [grid[i0][j], grid[i1][j]] = [grid[i1][j], grid[i0][j]];
        }
    }
    return grid;
};
```

```Rust
impl Solution {
    pub fn reverse_submatrix(grid: Vec<Vec<i32>>, x: i32, y: i32, k: i32) -> Vec<Vec<i32>> {
        let x = x as usize;
        let y = y as usize;
        let k = k as usize;
        let mut grid = grid;
        let mut i0 = x;
        let mut i1 = x + k - 1;

        while i0 < i1 {
            for j in y..y + k {
                let temp = grid[i0][j];
                grid[i0][j] = grid[i1][j];
                grid[i1][j] = temp;
            }
            i0 += 1;
            i1 -= 1;
        }

        grid
    }
}
```

**复杂度分析**

- 时间复杂度：$O(k^2)$，其中 $k$ 是正方形子矩阵的边长。外层循环交换 $\lfloor k/2\rfloor $ 对行，每对行需要交换 $k$ 个元素。
- 空间复杂度：$O(1)$。仅使用常数个额外变量。
