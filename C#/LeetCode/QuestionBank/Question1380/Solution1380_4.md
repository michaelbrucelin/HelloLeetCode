#### [方法三：幸运数的性质](https://leetcode.cn/problems/lucky-numbers-in-a-matrix/solutions/241888/ju-zhen-zhong-de-xing-yun-shu-by-leetcode-solution/)

**思路与算法**

因为矩阵中的数字互不相同，我们可以推导出幸运数的一些性质：

-   如果 $matrix[i][j]$ 是幸运数，即 $matrix[i][j]=minRow[i]$ 且 $matrix[i][j] = maxCol[j]$，那么 $minRow[i]$ 是 $minRow$ 的最大值（记作 $rowMax$），$maxCol[j]$ 是 $maxCol$ 的最小值（记作 $colMin$）。
    > 证明：如果 $minRow[i]$ 不是 $minRow$ 的最大值，那么假设最大值 $rowMax = minRow[k] = matrix[k][l]$，其中 $k \ne i$。于是 $matrix[i][j] = minRow[i] \lt rowMax = minRow[k] = matrix[k][l] \lt matrix[k][j]$，所以 $matrix[i][j] \ne maxCol[j]$，矛盾。因此 $minRow[i]$ 是 $minRow$ 的最大值。同理我们也可以证明 $maxCol[j]$ 是 $maxCol$ 的最小值。
-   幸运数不超过一个。
    > 证明：如果存在两个幸运数 $a$ 和 $b$，那么 $a = b = rowMax$，与矩阵中的数字互不相同矛盾。

如果存在幸运数，那么幸运数一定等于 $rowMax$。因此我们可以先求出 $minRow$ 的最大值 $rowMax$，并记录 $rowMax$ 所在的列 $k$，然后判断 $rowMax$ 是不是第 $k$ 列的最大值，如果是，则返回 $rowMax$。

**代码**

```go
class Solution:
    def luckyNumbers(self, matrix: List[List[int]]) -> List[int]:
        rowMax, k = 0, 0
        for row in matrix:
            minRow = min(row)
            if minRow > rowMax:
                rowMax, k = minRow, row.index(minRow)
        return [rowMax] if all(row[k] <= rowMax for row in matrix) else []
```

```cpp
class Solution {
public:
    vector<int> luckyNumbers (vector<vector<int>>& matrix) {
        int m = matrix.size();
        int rowMax = 0, k;
        for (int i = 0; i < m; i++) {
            int c = min_element(matrix[i].begin(), matrix[i].end()) - matrix[i].begin();
            if (rowMax < matrix[i][c]) {
                rowMax = matrix[i][c];
                k = c;
            }
        }
        for (int i = 0; i < m; i++) {
            if (rowMax < matrix[i][k]) {
                return {};
            }
        }
        return {rowMax};
    }
};
```

```java
class Solution {
    public List<Integer> luckyNumbers (int[][] matrix) {
        List<Integer> ret = new ArrayList<Integer>();
        int m = matrix.length, n = matrix[0].length;
        int rowMax = 0, k = 0;
        for (int i = 0; i < m; i++) {
            int curMin = matrix[i][0];
            int c = 0;
            for (int j = 1; j < n; j++) {
                if (curMin > matrix[i][j]) {
                    curMin = matrix[i][j];
                    c = j;
                }
            }
            if (rowMax < curMin) {
                rowMax = curMin;
                k = c;
            }
        }
        for (int i = 0; i < m; i++) {
            if (rowMax < matrix[i][k]) {
                return ret;
            }
        }
        ret.add(rowMax);
        return ret;
    }
}
```

```csharp
public class Solution {
    public IList<int> LuckyNumbers (int[][] matrix) {
        IList<int> ret = new List<int>();
        int m = matrix.Length, n = matrix[0].Length;
        int rowMax = 0, k = 0;
        for (int i = 0; i < m; i++) {
            int curMin = matrix[i][0];
            int c = 0;
            for (int j = 1; j < n; j++) {
                if (curMin > matrix[i][j]) {
                    curMin = matrix[i][j];
                    c = j;
                }
            }
            if (rowMax < curMin) {
                rowMax = curMin;
                k = c;
            }
        }
        for (int i = 0; i < m; i++) {
            if (rowMax < matrix[i][k]) {
                return ret;
            }
        }
        ret.Add(rowMax);
        return ret;
    }
}
```

```c
int *luckyNumbers (int **matrix, int matrixSize, int *matrixColSize, int *returnSize){
    int m = matrixSize, n = matrixColSize[0];
    int rowMax = 0, k;
    for (int i = 0; i < m; i++) {
        int index = 0;
        for (int j = 1; j < n; j++) {
            if (matrix[i][index] > matrix[i][j]) {
                index = j;
            }
        }
        if (rowMax < matrix[i][index]) {
            rowMax = matrix[i][index];
            k = index;
        }
    }

    for (int i = 0; i < m; i++) {
        if (rowMax < matrix[i][k]) {
            *returnSize = 0;
            return NULL;
        }
    }

    int *ret = (int *)malloc(sizeof(int));
    *ret = rowMax;
    *returnSize = 1;
    return ret;
}
```

```go
func luckyNumbers(matrix [][]int) []int {
    rowMax, k := 0, 0
    for _, row := range matrix {
        c := 0
        for j, v := range row {
            if v < row[c] {
                c = j
            }
        }
        if row[c] > rowMax {
            rowMax = row[c]
            k = c
        }
    }
    for _, row := range matrix {
        if row[k] > rowMax {
            return nil
        }
    }
    return []int{rowMax}
}
```

```javascript
var luckyNumbers  = function(matrix) {
    const ret = [];
    const m = matrix.length, n = matrix[0].length;
    let rowMax = 0, k = 0;
    for (let i = 0; i < m; i++) {
        let curMin = matrix[i][0];
        let c = 0;
        for (let j = 1; j < n; j++) {
            if (curMin > matrix[i][j]) {
                curMin = matrix[i][j];
                c = j;
            }
        }
        if (rowMax < curMin) {
            rowMax = curMin;
            k = c;
        }
    }
    for (let i = 0; i < m; i++) {
        if (rowMax < matrix[i][k]) {
            return ret;
        }
    }
    ret.push(rowMax);
    return ret;
};
```

**复杂度分析**

-   时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别是矩阵 $matrix$ 的行数和列数。获取 $rowMax$ 需要 $O(mn)$，判断 $rowMax$ 是否是列最大值需要 $O(m)$。
-   空间复杂度：$O(1)$。
