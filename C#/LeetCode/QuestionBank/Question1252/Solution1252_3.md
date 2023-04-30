#### [方法一：直接模拟](https://leetcode.cn/problems/cells-with-odd-values-in-a-matrix/solutions/1661036/qi-shu-zhi-dan-yuan-ge-de-shu-mu-by-leet-oa4o/)

直接使用使用一个 $n \times m$ 的矩阵来存放操作的结果，对于 $indices$ 中的每一对 $[r_i, c_i]$，将矩阵第 $r_i$ 行的所有数增加 $1$，第 $c_i$ 列的所有数增加 $1$。在所有操作模拟完毕后，我们遍历矩阵，得到奇数的数目。

```python
class Solution:
    def oddCells(self, m: int, n: int, indices: List[List[int]]) -> int:
        matrix = [[0] * n for _ in range(m)]
        for x, y in indices:
            for j in range(n):
                matrix[x][j] += 1
            for row in matrix:
                row[y] += 1
        return sum(x % 2 for row in matrix for x in row)
```

```cpp
class Solution {
public:
    int oddCells(int m, int n, vector<vector<int>>& indices) {
        int res = 0;
        vector<vector<int>> matrix(m, vector<int>(n));
        for (auto &index : indices) {
            for (int i = 0; i < n; i++) {
                matrix[index[0]][i]++;
            }
            for (int i = 0; i < m; i++) {
                matrix[i][index[1]]++;
            }
        }
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] & 1) {
                    res++;
                }
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int oddCells(int m, int n, int[][] indices) {
        int res = 0;
        int[][] matrix = new int[m][n];
        for (int[] index : indices) {
            for (int i = 0; i < n; i++) {
                matrix[index[0]][i]++;
            }
            for (int i = 0; i < m; i++) {
                matrix[i][index[1]]++;
            }
        }
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if ((matrix[i][j] & 1) != 0) {
                    res++;
                }
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int OddCells(int m, int n, int[][] indices) {
        int res = 0;
        int[,] matrix = new int[m, n];
        foreach (int[] index in indices) {
            for (int i = 0; i < n; i++) {
                matrix[index[0], i]++;
            }
            for (int i = 0; i < m; i++) {
                matrix[i, index[1]]++;
            }
        }
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if ((matrix[i, j] & 1) != 0) {
                    res++;
                }
            }
        }
        return res;
    }
}
```

```c
int oddCells(int m, int n, int** indices, int indicesSize, int* indicesColSize) {
    int res = 0;
    int **matrix = (int **)malloc(sizeof(int *) * m);
    for (int i = 0; i < m; i++) {
        matrix[i] = (int *)malloc(sizeof(int) * n);
        memset(matrix[i], 0, sizeof(int) * n);
    }
    for (int i = 0; i < indicesSize; i++) {
        for (int j = 0; j < n; j++) {
            matrix[indices[i][0]][j]++;
        }
        for (int j = 0; j < m; j++) {
            matrix[j][indices[i][1]]++;
        }
    }
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (matrix[i][j] & 1) {
                res++;
            }
        }
        free(matrix[i]);
    }
    free(matrix);
    return res;
}
```

```javascript
var oddCells = function(m, n, indices) {
    let res = 0;
    const matrix = new Array(m).fill(0).map(() => new Array(n).fill(0));
    for (const index of indices) {
        for (let i = 0; i < n; i++) {
            matrix[index[0]][i]++;
        }
        for (let i = 0; i < m; i++) {
            matrix[i][index[1]]++;
        }
    }
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if ((matrix[i][j] & 1) !== 0) {
                res++;
            }
        }
    }
    return res;
};
```

```go
func oddCells(m, n int, indices [][]int) (ans int) {
    matrix := make([][]int, m)
    for i := range matrix {
        matrix[i] = make([]int, n)
    }
    for _, p := range indices {
        for j := range matrix[p[0]] {
            matrix[p[0]][j]++
        }
        for _, row := range matrix {
            row[p[1]]++
        }
    }
    for _, row := range matrix {
        for _, v := range row {
            ans += v % 2
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(q \times (m + n) + m \times n)$, 其中 $q$ 表示数组 $indices$ 的长度，$m, n$ 为矩阵的行数与列数。遍历数组时，每次都需要更新矩阵中一行加一列，需要的时间为 $O(q \times (m + n))$，最后还需要遍历矩阵，需要的时间为 $O(m \times n)$，总的时间复杂度为 $O(q \times (m + n) + m \times n)$。
-   空间复杂度：$O(m \times n)$，其中 $m, n$ 为矩阵的行数与列数。需要存储矩阵的所有元素。
