#### [方法一：模拟](https://leetcode.cn/problems/lucky-numbers-in-a-matrix/solutions/241888/ju-zhen-zhong-de-xing-yun-shu-by-leetcode-solution/)

**思路与算法**

遍历矩阵 $matrix$，判断 $matrix[i][j]$ 是否是它所在行的最小值和所在列的最大值，如果是，则加入返回结果。

**代码**

```python
class Solution:
    def luckyNumbers(self, matrix: List[List[int]]) -> List[int]:
        ans = []
        for row in matrix:
            for j, x in enumerate(row):
                if max(r[j] for r in matrix) <= x <= min(row):
                    ans.append(x)
        return ans
```

```cpp
class Solution {
public:
    vector<int> luckyNumbers (vector<vector<int>>& matrix) {
        int m = matrix.size(), n = matrix[0].size();
        vector<int> ret;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                bool isMin = true, isMax = true;
                for (int k = 0; k < n; k++) {
                    if (matrix[i][k] < matrix[i][j]) {
                        isMin = false;
                        break;
                    }
                }
                if (!isMin) {
                    continue;
                }
                for (int k = 0; k < m; k++) {
                    if (matrix[k][j] > matrix[i][j]) {
                        isMax = false;
                        break;
                    }
                }
                if (isMax) {
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
        List<Integer> ret = new ArrayList<Integer>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                boolean isMin = true, isMax = true;
                for (int k = 0; k < n; k++) {
                    if (matrix[i][k] < matrix[i][j]) {
                        isMin = false;
                        break;
                    }
                }
                if (!isMin) {
                    continue;
                }
                for (int k = 0; k < m; k++) {
                    if (matrix[k][j] > matrix[i][j]) {
                        isMax = false;
                        break;
                    }
                }
                if (isMax) {
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
        IList<int> ret = new List<int>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                bool isMin = true, isMax = true;
                for (int k = 0; k < n; k++) {
                    if (matrix[i][k] < matrix[i][j]) {
                        isMin = false;
                        break;
                    }
                }
                if (!isMin) {
                    continue;
                }
                for (int k = 0; k < m; k++) {
                    if (matrix[k][j] > matrix[i][j]) {
                        isMax = false;
                        break;
                    }
                }
                if (isMax) {
                    ret.Add(matrix[i][j]);
                }
            }
        }
        return ret;
    }
}
```

```c
int *luckyNumbers (int **matrix, int matrixSize, int *matrixColSize, int *returnSize){
    int *ret = (int *)malloc(sizeof(int) * matrixSize * matrixColSize[0]);
    int retSize = 0;
    for (int i = 0; i < matrixSize; i++) {
        for (int j = 0; j < matrixColSize[0]; j++) {
            bool isMin = true, isMax = true;
            for (int k = 0; k < matrixColSize[0]; k++) {
                if (matrix[i][k] < matrix[i][j]) {
                    isMin = false;
                    break;
                }
            }
            if (!isMin) {
                continue;
            }
            for (int k = 0; k < matrixSize; k++) {
                if (matrix[k][j] > matrix[i][j]) {
                    isMax = false;
                    break;
                }
            }
            if (isMax) {
                ret[retSize++] = matrix[i][j];
            }
        }
    *returnSize = retSize;
    return ret;
}
```

```javascript
var luckyNumbers  = function(matrix) {
    const m = matrix.length, n = matrix[0].length;
    const ret = [];
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            let isMin = true, isMax = true;
            for (let k = 0; k < n; k++) {
                if (matrix[i][k] < matrix[i][j]) {
                    isMin = false;
                    break;
                }
            }
            if (!isMin) {
                continue;
            }
            for (let k = 0; k < m; k++) {
                if (matrix[k][j] > matrix[i][j]) {
                    isMax = false;
                    break;
                }
            }
            if (isMax) {
                ret.push(matrix[i][j]);
            }
        }
    }
    return ret;
};
```

```go
func luckyNumbers(matrix [][]int) (ans []int) {
    for _, row := range matrix {
    next:
        for j, x := range row {
            for _, y := range row {
                if y < x {
                    continue next
                }
            }
            for _, r := range matrix {
                if r[j] > x {
                    continue next
                }
            }
            ans = append(ans, x)
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(mn \times (m + n))$，其中 $m$ 和 $n$ 分别是矩阵 $matrix$ 的行数和列数。遍历矩阵 $matrix$ 需要 $O(mn)$，查找行最小值需要 $O(n)$，查找列最大值需要 $O(m)$。
-   空间复杂度：$O(1)$。返回值不计算空间复杂度。
