#### [方法二：预处理 + 模拟](https://leetcode.cn/problems/lucky-numbers-in-a-matrix/solutions/241888/ju-zhen-zhong-de-xing-yun-shu-by-leetcode-solution/)

**思路与算法**

预处理出每行的最小值数组 $minRow$ 和每列的最大值数组 $maxCol$，其中 $minRow[i]$ 表示第 $i$ 行的最小值，$maxCol[j]$ 表示第 $j$ 列的最大值。遍历矩阵 $matrix$，如果 $matrix[i][j]$ 同时满足 $matrix[i][j]=minRow[i]$ 和 $matrix[i][j] = maxCol[j]$，那么 $matrix[i][j]$ 是矩阵中的幸运数，加入返回结果。

**代码**

```python
class Solution:
    def luckyNumbers(self, matrix: List[List[int]]) -> List[int]:
        minRow = [min(row) for row in matrix]
        maxCol = [max(col) for col in zip(*matrix)]
        ans = []
        for i, row in enumerate(matrix):
            for j, x in enumerate(row):
                if x == minRow[i] == maxCol[j]:
                    ans.append(x)
        return ans
```

```cpp
class Solution {
public:
    vector<int> luckyNumbers (vector<vector<int>>& matrix) {
        int m = matrix.size(), n = matrix[0].size();
        vector<int> minRow(m, INT_MAX), maxCol(n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                minRow[i] = min(minRow[i], matrix[i][j]);
                maxCol[j] = max(maxCol[j], matrix[i][j]);
            }
        }
        vector<int> ret;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == minRow[i] && matrix[i][j] == maxCol[j]) {
                    ret.push_back(matrix[i][j]);
                }
            }
        }
        return ret;
    }
};
```

```java
class Solution {
    public List<Integer> luckyNumbers (int[][] matrix) {
        int m = matrix.length, n = matrix[0].length;
        int[] minRow = new int[m];
        Arrays.fill(minRow, Integer.MAX_VALUE);
        int[] maxCol = new int[n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                minRow[i] = Math.min(minRow[i], matrix[i][j]);
                maxCol[j] = Math.max(maxCol[j], matrix[i][j]);
            }
        }
        List<Integer> ret = new ArrayList<Integer>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == minRow[i] && matrix[i][j] == maxCol[j]) {
                    ret.add(matrix[i][j]);
                }
            }
        }
        return ret;
    }
}
```

```csharp
public class Solution {
    public IList<int> LuckyNumbers (int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        int[] minRow = new int[m];
        Array.Fill(minRow, int.MaxValue);
        int[] maxCol = new int[n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                minRow[i] = Math.Min(minRow[i], matrix[i][j]);
                maxCol[j] = Math.Max(maxCol[j], matrix[i][j]);
            }
        }
        IList<int> ret = new List<int>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == minRow[i] && matrix[i][j] == maxCol[j]) {
                    ret.Add(matrix[i][j]);
                }
            }
        }
        return ret;
    }
}
```

```c
static inline int max(int n1, int n2) {
    return n1 > n2 ? n1 : n2;
}

static inline int min(int n1, int n2) {
    return n1 < n2 ? n1 : n2;
}

int *luckyNumbers (int **matrix, int matrixSize, int *matrixColSize, int *returnSize){
    int *ret = (int *)malloc(sizeof(int) * matrixSize * matrixColSize[0]);
    int retSize = 0;
    int *minRow = (int *)malloc(sizeof(int) * matrixSize), *maxCol = (int *)malloc(sizeof(int) * matrixColSize[0]);
    memset(minRow, 0x3f, sizeof(int) * matrixSize);
    memset(maxCol, 0, sizeof(int) * matrixColSize[0]);
    for (int i = 0; i < matrixSize; i++) {
        for (int j = 0; j < matrixColSize[0]; j++) {
            minRow[i] = min(minRow[i], matrix[i][j]);
            maxCol[j] = max(maxCol[j], matrix[i][j]);
        }
    }
    for (int i = 0; i < matrixSize; i++) {
        for (int j = 0; j < matrixColSize[0]; j++) {
            if (matrix[i][j] == minRow[i] && matrix[i][j] == maxCol[j]) {
                ret[retSize++] = matrix[i][j];
            }
        }
    }
    free(minRow);
    free(maxCol);
    *returnSize = retSize;
    return ret;
}
```

```javascript
var luckyNumbers  = function(matrix) {
    const m = matrix.length, n = matrix[0].length;
    const minRow = new Array(m).fill(Number.MAX_SAFE_INTEGER);
    const maxCol = new Array(n).fill(0);
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            minRow[i] = Math.min(minRow[i], matrix[i][j]);
            maxCol[j] = Math.max(maxCol[j], matrix[i][j]);
        }
    }
    const ret = [];
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (matrix[i][j] === minRow[i] && matrix[i][j] === maxCol[j]) {
                ret.push(matrix[i][j]);
            }
        }
    }
    return ret;
};
```

```go
func luckyNumbers(matrix [][]int) (ans []int) {
    minRow := make([]int, len(matrix))
    maxCol := make([]int, len(matrix[0]))
    for i, row := range matrix {
        minRow[i] = row[0]
        for j, x := range row {
            minRow[i] = min(minRow[i], x)
            maxCol[j] = max(maxCol[j], x)
        }
    }
    for i, row := range matrix {
        for j, x := range row {
            if x == minRow[i] && x == maxCol[j] {
                ans = append(ans, x)
            }
        }
    }
    return
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别是矩阵 $matrix$ 的行数和列数。预处理 $minRow$ 和 $maxCol$ 需要 $O(mn)$，查找幸运数需要 $O(mn)$。
-   空间复杂度：$O(m + n)$。保存 $minRow$ 和 $maxCol$ 需要 $O(m + n)$ 的额外空间，返回值不计入空间复杂度。
