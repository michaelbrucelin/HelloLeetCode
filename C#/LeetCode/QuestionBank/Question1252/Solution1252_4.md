#### [方法二：模拟空间优化](https://leetcode.cn/problems/cells-with-odd-values-in-a-matrix/solutions/1661036/qi-shu-zhi-dan-yuan-ge-de-shu-mu-by-leet-oa4o/)

由于每次操作只会将一行和一列的数增加 $1$，因此我们可以使用一个行数组 $rows$ 和列数组 $cols$ 分别记录每一行和每一列被增加的次数。对于 $indices$ 中的每一对 $[r_i, c_i]$，我们将 $rows[r_i]$ 和 $cols[c_i]$ 的值分别增加 $1$。 在所有操作完成后，我们可以计算出位置 $(x, y)$ 位置的计数即为 $rows[x] + cols[y]$。遍历矩阵，即可得到所有奇数的数目。

```python
class Solution:
    def oddCells(self, m: int, n: int, indices: List[List[int]]) -> int:
        rows = [0] * m
        cols = [0] * n
        for x, y in indices:
            rows[x] += 1
            cols[y] += 1
        return sum((row + col) % 2 for row in rows for col in cols)
```

```cpp
class Solution {
public:
    int oddCells(int m, int n, vector<vector<int>>& indices) {
        vector<int> rows(m), cols(n);
        for (auto & index : indices) {
            rows[index[0]]++;
            cols[index[1]]++;
        }
        int res = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if ((rows[i] + cols[j]) & 1) {
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
        int[] rows = new int[m];
        int[] cols = new int[n];
        for (int[] index : indices) {
            rows[index[0]]++;
            cols[index[1]]++;
        }
        int res = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (((rows[i] + cols[j]) & 1) != 0) {
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
        int[] rows = new int[m];
        int[] cols = new int[n];
        foreach (int[] index in indices) {
            rows[index[0]]++;
            cols[index[1]]++;
        }
        int res = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (((rows[i] + cols[j]) & 1) != 0) {
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
    int *rows = (int *)malloc(sizeof(int) * m);
    int *cols = (int *)malloc(sizeof(int) * n);
    memset(rows, 0, sizeof(int) * m);
    memset(cols, 0, sizeof(int) * n);
    for (int i = 0; i < indicesSize; i++) {
        rows[indices[i][0]]++;
        cols[indices[i][1]]++;
    }
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if ((rows[i] + cols[j]) & 1) {
                res++;
            }
        }
    }
    free(rows);
    free(cols);
    return res;
}
```

```javascript
var oddCells = function(m, n, indices) {
    const rows = new Array(m).fill(0);
    const cols = new Array(n).fill(0);
    for (const index of indices) {
        rows[index[0]]++;
        cols[index[1]]++;
    }
    let res = 0;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (((rows[i] + cols[j]) & 1) !== 0) {
                res++;
            }
        }
    }
    return res;
};
```

```go
func oddCells(m, n int, indices [][]int) (ans int) {
    rows := make([]int, m)
    cols := make([]int, n)
    for _, p := range indices {
        rows[p[0]]++
        cols[p[1]]++
    }
    for _, row := range rows {
        for _, col := range cols {
            ans += (row + col) % 2
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(q + m \times n)$, 其中 $q$ 表示数组 $indices$ 的长度，$m, n$ 为矩阵的行数与列数。遍历数组时需要的时间为 $O(q)$，最后还需要遍历矩阵，需要的时间为 $O(m \times n)$，因此总的时间复杂度为 $O(q + m \times n)$。
-   空间复杂度：$O(m + n)$，其中 $m, n$ 为矩阵的行数与列数。需要存储矩阵的行数统计与列数统计。
