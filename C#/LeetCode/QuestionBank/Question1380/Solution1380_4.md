#### [��������������������](https://leetcode.cn/problems/lucky-numbers-in-a-matrix/solutions/241888/ju-zhen-zhong-de-xing-yun-shu-by-leetcode-solution/)

**˼·���㷨**

��Ϊ�����е����ֻ�����ͬ�����ǿ����Ƶ�����������һЩ���ʣ�

-   ��� $matrix[i][j]$ ������������ $matrix[i][j]=minRow[i]$ �� $matrix[i][j] = maxCol[j]$����ô $minRow[i]$ �� $minRow$ �����ֵ������ $rowMax$����$maxCol[j]$ �� $maxCol$ ����Сֵ������ $colMin$����
    > ֤������� $minRow[i]$ ���� $minRow$ �����ֵ����ô�������ֵ $rowMax = minRow[k] = matrix[k][l]$������ $k \ne i$������ $matrix[i][j] = minRow[i] \lt rowMax = minRow[k] = matrix[k][l] \lt matrix[k][j]$������ $matrix[i][j] \ne maxCol[j]$��ì�ܡ���� $minRow[i]$ �� $minRow$ �����ֵ��ͬ������Ҳ����֤�� $maxCol[j]$ �� $maxCol$ ����Сֵ��
-   ������������һ����
    > ֤��������������������� $a$ �� $b$����ô $a = b = rowMax$��������е����ֻ�����ͬì�ܡ�

�����������������ô������һ������ $rowMax$��������ǿ�������� $minRow$ �����ֵ $rowMax$������¼ $rowMax$ ���ڵ��� $k$��Ȼ���ж� $rowMax$ �ǲ��ǵ� $k$ �е����ֵ������ǣ��򷵻� $rowMax$��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(mn)$������ $m$ �� $n$ �ֱ��Ǿ��� $matrix$ ����������������ȡ $rowMax$ ��Ҫ $O(mn)$���ж� $rowMax$ �Ƿ��������ֵ��Ҫ $O(m)$��
-   �ռ临�Ӷȣ�$O(1)$��
