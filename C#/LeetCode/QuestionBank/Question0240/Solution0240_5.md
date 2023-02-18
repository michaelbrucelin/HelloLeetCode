#### [方法三：Z 字形查找](https://leetcode.cn/problems/search-a-2d-matrix-ii/solutions/1062538/sou-suo-er-wei-ju-zhen-ii-by-leetcode-so-9hcx/)

**思路与算法**

我们可以从矩阵 $matrix$ 的右上角 $(0, n-1)$ 进行搜索。在每一步的搜索过程中，如果我们位于位置 $(x, y)$，那么我们希望在以 $matrix$ 的左下角为左下角、以 $(x, y)$ 为右上角的矩阵中进行搜索，即行的范围为 $[x, m - 1]$，列的范围为 $[0, y]$：
-   如果 $matrix[x, y] = target$，说明搜索完成；
-   如果 $matrix[x, y] > target$，由于每一列的元素都是升序排列的，那么在当前的搜索矩阵中，所有位于第 $y$ 列的元素都是严格大于 $target$ 的，因此我们可以将它们全部忽略，即将 $y$ 减少 $1$；
-   如果 $matrix[x,y] < target$，由于每一行的元素都是升序排列的，那么在当前的搜索矩阵中，所有位于第 $x$ 行的元素都是严格小于 $target$ 的，因此我们可以将它们全部忽略，即将 $x$ 增加 $1$。

在搜索的过程中，如果我们超出了矩阵的边界，那么说明矩阵中不存在 $target$。

**代码**

```cpp
class Solution {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {
        int m = matrix.size(), n = matrix[0].size();
        int x = 0, y = n - 1;
        while (x < m && y >= 0) {
            if (matrix[x][y] == target) {
                return true;
            }
            if (matrix[x][y] > target) {
                --y;
            }
            else {
                ++x;
            }
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean searchMatrix(int[][] matrix, int target) {
        int m = matrix.length, n = matrix[0].length;
        int x = 0, y = n - 1;
        while (x < m && y >= 0) {
            if (matrix[x][y] == target) {
                return true;
            }
            if (matrix[x][y] > target) {
                --y;
            } else {
                ++x;
            }
        }
        return false;
    }
}
```

```csharp
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length, n = matrix[0].Length;
        int x = 0, y = n - 1;
        while (x < m && y >= 0) {
            if (matrix[x][y] == target) {
                return true;
            }
            if (matrix[x][y] > target) {
                --y;
            } else {
                ++x;
            }
        }
        return false;
    }
}
```

```python
class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        m, n = len(matrix), len(matrix[0])
        x, y = 0, n - 1
        while x < m and y >= 0:
            if matrix[x][y] == target:
                return True
            if matrix[x][y] > target:
                y -= 1
            else:
                x += 1
        return False
```

```javascript
var searchMatrix = function(matrix, target) {
    const m = matrix.length, n = matrix[0].length;
    let x = 0, y = n - 1;
    while (x < m && y >= 0) {
        if (matrix[x][y] === target) {
            return true;
        }
        if (matrix[x][y] > target) {
            --y;
        } else {
            ++x;
        }
    }
    return false;
};
```

```go
func searchMatrix(matrix [][]int, target int) bool {
    m, n := len(matrix), len(matrix[0])
    x, y := 0, n-1
    for x < m && y >= 0 {
        if matrix[x][y] == target {
            return true
        }
        if matrix[x][y] > target {
            y--
        } else {
            x++
        }
    }
    return false
}
```

**复杂度分析**

-   时间复杂度：$O(m + n)$。在搜索的过程中，如果我们没有找到 $target$，那么我们要么将 $y$ 减少 $1$，要么将 $x$ 增加 $1$。由于 $(x, y)$ 的初始值分别为 $(0, n-1)$，因此 $y$ 最多能被减少 $n$ 次，$x$ 最多能被增加 $m$ 次，总搜索次数为 $m + n$。在这之后，$x$ 和 $y$ 就会超出矩阵的边界。
-   空间复杂度：$O(1)$。
