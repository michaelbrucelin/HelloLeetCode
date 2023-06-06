#### [方法一：模拟](https://leetcode.cn/problems/equal-row-and-column-pairs/solutions/2293933/xiang-deng-xing-lie-dui-by-leetcode-solu-gvcg/)

**思路**

按照题目要求，对任意一行，将它与每一列都进行比较，如果相等，则对结果加一，最后返回总数。

**代码**

```python
class Solution:
    def equalPairs(self, grid: List[List[int]]) -> int:
        res, n = 0, len(grid)
        for row in range(n):
            for col in range(n):
                if self.equal(row, col, n, grid):
                    res += 1
        return res
    
    def equal(self, row: int, col: int, n: int, grid: List[List[int]]) -> bool:
        for i in range(n):
            if grid[row][i] != grid[i][col]:
                return False
        return True
```

```java
class Solution {
    public int equalPairs(int[][] grid) {
        int res = 0, n = grid.length;
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                if (equal(row, col, n, grid)) {
                    res++;
                }
            }
        }
        return res;
    }

    public boolean equal(int row, int col, int n, int[][] grid) {
        for (int i = 0; i < n; i++) {
            if (grid[row][i] != grid[i][col]) {
                return false;
            }
        }
        return true;
    }
}
```

```csharp
public class Solution {
    public int EqualPairs(int[][] grid) {
        int res = 0, n = grid.Length;
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                if (Equal(row, col, n, grid)) {
                    res++;
                }
            }
        }
        return res;
    }

    public bool Equal(int row, int col, int n, int[][] grid) {
        for (int i = 0; i < n; i++) {
            if (grid[row][i] != grid[i][col]) {
                return false;
            }
        }
        return true;
    }
}
```

```cpp
class Solution {
public:
    int equalPairs(vector<vector<int>>& grid) {
        int res = 0, n = grid.size();
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                if (equal(row, col, grid)) {
                    res++;
                }
            }
        }
        return res;
    }

    bool equal(int row, int col, vector<vector<int>>& grid) {
        int n = grid.size();
        for (int i = 0; i < n; i++) {
            if (grid[row][i] != grid[i][col]) {
                return false;
            }
        }
        return true;
    }
};
```

```c
bool equal(int row, int col, const int** grid, int gridSize) {
    for (int i = 0; i < gridSize; i++) {
        if (grid[row][i] != grid[i][col]) {
            return false;
        }
    }
    return true;
}

int equalPairs(int** grid, int gridSize, int* gridColSize) {
    int res = 0;
    for (int row = 0; row < gridSize; row++) {
        for (int col = 0; col < gridSize; col++) {
            if (equal(row, col, grid, gridSize)) {
                res++;
            }
        }
    }
    return res;
}
```

**复杂度分析**

-   时间复杂度：$O(n^3)$，需要进行双层循环，每次循环最多需要遍历 $n$ 个数字。
-   空间复杂度：$O(1)$，仅使用常数空间。
