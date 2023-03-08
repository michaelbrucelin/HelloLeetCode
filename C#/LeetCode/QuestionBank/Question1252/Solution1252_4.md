#### [��������ģ��ռ��Ż�](https://leetcode.cn/problems/cells-with-odd-values-in-a-matrix/solutions/1661036/qi-shu-zhi-dan-yuan-ge-de-shu-mu-by-leet-oa4o/)

����ÿ�β���ֻ�Ὣһ�к�һ�е������� $1$��������ǿ���ʹ��һ�������� $rows$ �������� $cols$ �ֱ��¼ÿһ�к�ÿһ�б����ӵĴ��������� $indices$ �е�ÿһ�� $[r_i, c_i]$�����ǽ� $rows[r_i]$ �� $cols[c_i]$ ��ֵ�ֱ����� $1$�� �����в�����ɺ����ǿ��Լ����λ�� $(x, y)$ λ�õļ�����Ϊ $rows[x] + cols[y]$���������󣬼��ɵõ�������������Ŀ��

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(q + m \times n)$, ���� $q$ ��ʾ���� $indices$ �ĳ��ȣ�$m, n$ Ϊ�������������������������ʱ��Ҫ��ʱ��Ϊ $O(q)$�������Ҫ����������Ҫ��ʱ��Ϊ $O(m \times n)$������ܵ�ʱ�临�Ӷ�Ϊ $O(q + m \times n)$��
-   �ռ临�Ӷȣ�$O(m + n)$������ $m, n$ Ϊ�������������������Ҫ�洢���������ͳ��������ͳ�ơ�
