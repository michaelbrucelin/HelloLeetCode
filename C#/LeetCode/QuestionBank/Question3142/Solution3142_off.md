### [判断矩阵是否满足条件](https://leetcode.cn/problems/check-if-grid-satisfies-conditions/solutions/2886830/pan-duan-ju-zhen-shi-fou-man-zu-tiao-jia-qct9/)

#### 方法一：直接模拟

**思路与算法**

根据题意直接模拟即可。设矩阵 $grid$ 的行数与列数分别为 $m,n$。我们遍历阵 $grid$，对于任意的位置判断 $grid[i][j]$ 是否满足条件即可：

- 如果满足 $i+1<m$，此时需要满足 $grid[i][j] = grid[i+1][j]$，如果不满足则返回 $false$；
- 如果满足 $j+1<n$，此时需要满足 $grid[i][j] \ne grid[i][j+1]$，如果不满足则返回 $false$；

遍历结束之后，如果没有遇到不满足条件的情况，则返回 $true$。

**代码**

```C++
class Solution {
public:
    bool satisfiesConditions(vector<vector<int>>& grid) {
        for (int i = 0; i < grid.size(); ++i) {
            for (int j = 0; j < grid[0].size(); ++j) {
                if (i + 1 < grid.size() && grid[i][j] != grid[i + 1][j]) {
                    return false;
                }
                if (j + 1 < grid[0].size() && grid[i][j] == grid[i][j + 1]) {
                    return false;
                }
            }
        }
        return true;
    }
};
```

```Java
class Solution {
    public boolean satisfiesConditions(int[][] grid) {
        for (int i = 0; i < grid.length; ++i) {
            for (int j = 0; j < grid[0].length; ++j) {
                if (i + 1 < grid.length && grid[i][j] != grid[i + 1][j]) {
                    return false;
                }
                if (j + 1 < grid[0].length && grid[i][j] == grid[i][j + 1]) {
                    return false;
                }
            }
        }
        return true;
    }
}
```

```CSharp
public class Solution {
    public bool SatisfiesConditions(int[][] grid) {
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[0].Length; ++j) {
                if (i + 1 < grid.Length && grid[i][j] != grid[i + 1][j]) {
                    return false;
                }
                if (j + 1 < grid[0].Length && grid[i][j] == grid[i][j + 1]) {
                    return false;
                }
            }
        }
        return true;
    }
}
```

```Go
func satisfiesConditions(grid [][]int) bool {
    for i := range grid {
        for j := range grid[0] {
            if i + 1 < len(grid) && grid[i][j] != grid[i + 1][j] {
                return false
            }
            if j + 1 < len(grid[0]) && grid[i][j] == grid[i][j + 1] {
                return false
            }
        }
    }
    return true
}
```

```Python
class Solution:
    def satisfiesConditions(self, grid: List[List[int]]) -> bool:
        for i in range(len(grid)):
            for j in range(len(grid[0])):
                if i + 1 < len(grid) and grid[i][j] != grid[i + 1][j]:
                    return False
                if j + 1 < len(grid[0]) and grid[i][j] == grid[i][j + 1]:
                    return False
        return True
```

```C
bool satisfiesConditions(int** grid, int gridSize, int* gridColSize) {
     for (int i = 0; i < gridSize; ++i) {
        for (int j = 0; j < gridColSize[0]; ++j) {
            if (i + 1 < gridSize && grid[i][j] != grid[i + 1][j]) {
                return false;
            }
            if (j + 1 < gridColSize[0] && grid[i][j] == grid[i][j + 1]) {
                return false;
            }
        }
    }
    return true;
}
```

```JavaScript
var satisfiesConditions = function(grid) {
    for (let i = 0; i < grid.length; ++i) {
        for (let j = 0; j < grid[0].length; ++j) {
            if (i + 1 < grid.length && grid[i][j] !== grid[i + 1][j]) {
                return false;
            }
            if (j + 1 < grid[0].length && grid[i][j] === grid[i][j + 1]) {
                return false;
            }
        }
    }
    return true;
};
```

```TypeScript
function satisfiesConditions(grid: number[][]): boolean {
    for (let i = 0; i < grid.length; ++i) {
        for (let j = 0; j < grid[0].length; ++j) {
            if (i + 1 < grid.length && grid[i][j] !== grid[i + 1][j]) {
                return false;
            }
            if (j + 1 < grid[0].length && grid[i][j] === grid[i][j + 1]) {
                return false;
            }
        }
    }
    return true;
};
```

```Rust
impl Solution {
    pub fn satisfies_conditions(grid: Vec<Vec<i32>>) -> bool {
        for i in 0..grid.len() {
            for j in 0..grid[0].len() {
                if i + 1 < grid.len() && grid[i][j] != grid[i + 1][j] {
                    return false;
                }
                if j + 1 < grid[0].len() && grid[i][j] == grid[i][j + 1] {
                    return false;
                }
            }
        }
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m,n$ 表示给定矩阵的行数与列数。只需遍历矩阵一次即可。
- 空间复杂度：$O(1)$。
