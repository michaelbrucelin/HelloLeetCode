#### [方法三：计数优化](https://leetcode.cn/problems/cells-with-odd-values-in-a-matrix/solutions/1661036/qi-shu-zhi-dan-yuan-ge-de-shu-mu-by-leet-oa4o/)

继续对方法二进行优化，矩阵中位于 $(x, y)$ 位置的数为奇数，当且仅当 $rows[x]$ 和 $cols[y]$ 中恰好有一个为奇数，一个为偶数。设 $rows$ 有 $odd_x$ 个奇数，$cols$ 有 $odd_y$ 个奇数，因此对于 $rows[x]$ 为偶数，那么在第 $x$ 行有 $odd_y$ 个位置的数为奇数；对于 $rows[x]$ 为奇数，那么在第 $x$ 行有 $n - odd_y$ 个位置的数为偶数。综上我们可以得到奇数的数目为 $odd_x \times (n - odd_y) + (m - odd_x) \times odd_y$。

```python
class Solution:
    def oddCells(self, m: int, n: int, indices: List[List[int]]) -> int:
        rows = [0] * m
        cols = [0] * n
        for x, y in indices:
            rows[x] += 1
            cols[y] += 1
        oddx = sum(row % 2 for row in rows)
        oddy = sum(col % 2 for col in cols)
        return oddx * (n - oddy) + (m - oddx) * oddy
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
        int oddx = 0, oddy = 0;
        for (int i = 0; i < m; i++) {
            if (rows[i] & 1) {
                oddx++;
            }
        }
        for (int i = 0; i < n; i++) {
            if (cols[i] & 1) {
                oddy++;
            }
        }
        return oddx * (n - oddy) + (m - oddx) * oddy;
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
        int oddx = 0, oddy = 0;
        for (int i = 0; i < m; i++) {
            if ((rows[i] & 1) != 0) {
                oddx++;
            }
        }
        for (int i = 0; i < n; i++) {
            if ((cols[i] & 1) != 0) {
                oddy++;
            }
        }
        return oddx * (n - oddy) + (m - oddx) * oddy;
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
        int oddx = 0, oddy = 0;
        for (int i = 0; i < m; i++) {
            if ((rows[i] & 1) != 0) {
                oddx++;
            }
        }
        for (int i = 0; i < n; i++) {
            if ((cols[i] & 1) != 0) {
                oddy++;
            }
        }
        return oddx * (n - oddy) + (m - oddx) * oddy;
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
    int oddx = 0, oddy = 0;
    for (int i = 0; i < m; i++) {
        if (rows[i] & 1) {
            oddx++;
        }
    }
    for (int i = 0; i < n; i++) {
        if (cols[i] & 1) {
            oddy++;
        }
    }
    return oddx * (n - oddy) + (m - oddx) * oddy;
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
    let oddx = 0, oddy = 0;
    for (let i = 0; i < m; i++) {
        if ((rows[i] & 1) !== 0) {
            oddx++;
        }
    }
    for (let i = 0; i < n; i++) {
        if ((cols[i] & 1) !== 0) {
            oddy++;
        }
    }
    return oddx * (n - oddy) + (m - oddx) * oddy;
};
```

```go
func oddCells(m, n int, indices [][]int) int {
    rows := make([]int, m)
    cols := make([]int, n)
    for _, p := range indices {
        rows[p[0]]++
        cols[p[1]]++
    }
    oddx := 0
    for _, row := range rows {
        oddx += row % 2
    }
    oddy := 0
    for _, col := range cols {
        oddy += col % 2
    }
    return oddx*(n-oddy) + (m-oddx)*oddy
}
```

**复杂度分析**

-   时间复杂度：$O(q + m + n)$, 其中 $q$ 表示数组 $indices$ 的长度，$m, n$ 为矩阵的行数与列数。
-   空间复杂度：$O(m + n)$，其中 $m, n$ 为矩阵的行数与列数。需要存储矩阵的行数统计与列数统计。
