### [将矩阵按对角线排序](https://leetcode.cn/problems/sort-the-matrix-diagonally/solutions/2754949/jiang-ju-zhen-an-dui-jiao-xian-pai-xu-by-fsf0/)

#### 方法一：模拟

##### 思路与算法

依次遍历矩阵，将同一条对角线上的元素放在相同的数组内，对所有数组进行倒序排序，再重新遍历矩阵，将排序好的元素放回矩阵内。

##### 代码

```c++
class Solution {
public:
    vector<vector<int>> diagonalSort(vector<vector<int>>& mat) {
        int n = mat.size(), m = mat[0].size();
        vector<vector<int>> diag(m + n);
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                diag[i - j + m].push_back(mat[i][j]);
            }
        }
        for (auto& d : diag) {
            sort(d.rbegin(), d.rend());
        }
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                mat[i][j] = diag[i - j + m].back();
                diag[i - j + m].pop_back();
            }
        }
        return mat;
    }
};
```

```java
class Solution {
    public int[][] diagonalSort(int[][] mat) {
        int n = mat.length, m = mat[0].length;
        List<List<Integer>> diag = new ArrayList<>(m + n);
        for (int i = 0; i < m + n; i++) {
            diag.add(new ArrayList<>());
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                diag.get(i - j + m).add(mat[i][j]);
            }
        }
        for (List<Integer> d : diag) {
            Collections.sort(d, Collections.reverseOrder());
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                mat[i][j] = diag.get(i - j + m).removeLast();
            }
        }
        return mat;
    }
}
```

```csharp
public class Solution {
    public int[][] DiagonalSort(int[][] mat) {
        int n = mat.Length, m = mat[0].Length;
        IList<IList<int>> diag = new List<IList<int>>(m + n);
        for (int i = 0; i < m + n; i++) {
            diag.Add(new List<int>());
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                diag[i - j + m].Add(mat[i][j]);
            }
        }
        foreach (IList<int> d in diag) {
            ((List<int>) d).Sort((a, b) => b - a);
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                mat[i][j] = diag[i - j + m][diag[i - j + m].Count - 1];
                diag[i - j + m].RemoveAt(diag[i - j + m].Count - 1);
            }
        }
        return mat;
    }
}
```

```python
class Solution:
    def diagonalSort(self, mat: List[List[int]]) -> List[List[int]]:
        n = len(mat)
        m = len(mat[0])
        diag = [[] for _ in range(m + n)]
        for i in range(n):
            for j in range(m):
                diag[i - j + m].append(mat[i][j])
        for d in diag:
            d.sort(reverse=True)
        for i in range(n):
            for j in range(m):
                mat[i][j] = diag[i - j + m].pop()
        return mat
```

```javascript
var diagonalSort = function(mat) {
    const n = mat.length;
    const m = mat[0].length;
    const diag = new Array(m + n).fill().map(() => []);
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            diag[i - j + m].push(mat[i][j]);
        }
    }
    diag.forEach(d => d.sort((a, b) => b - a));
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            mat[i][j] = diag[i - j + m].pop();
        }
    }
    return mat;
};
```

```typescript
function diagonalSort(mat: number[][]): number[][] {
    const n = mat.length;
    const m = mat[0].length;
    const diag = new Array(m + n).fill().map(() => []);
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            diag[i - j + m].push(mat[i][j]);
        }
    }
    diag.forEach(d => d.sort((a, b) => b - a));
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            mat[i][j] = diag[i - j + m].pop();
        }
    }
    return mat;
};
```

```go
func diagonalSort(mat [][]int) [][]int {
    n := len(mat)
    m := len(mat[0])
    diag := make([][]int, m+n)
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            diag[i - j + m] = append(diag[i - j + m], mat[i][j])
        }
    }
    for _, d := range diag {
        sort.Sort(sort.Reverse(sort.IntSlice(d)))
    }
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            mat[i][j] = diag[i - j + m][len(diag[i - j + m])-1]
            diag[i - j + m] = diag[i - j + m][:len(diag[i - j + m])-1]
        }
    }
    return mat
}
```

```csharp
public class Solution {
    public int[][] DiagonalSort(int[][] mat) {
        int n = mat.Length, m = mat[0].Length;
        List<List<int>> diag = new List<List<int>>(m + n);
        for (int i = 0; i < m + n; i++) {
            diag.Add(new List<int>());
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                diag[i - j + m].Add(mat[i][j]);
            }
        }
        foreach (List<int> d in diag) {
            d.Sort();
            d.Reverse();
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                int index = diag[i - j + m].Count - 1;
                mat[i][j] = diag[i - j + m][index];
                diag[i - j + m].RemoveAt(index);
            }
        }
        return mat;
    }
}
```

```c
typedef struct {
    int *arr;
    int size;
} Diagonal;

int compare(const void *a, const void *b) {
    return *(int*)b - *(int*)a;
}

int** diagonalSort(int** mat, int matSize, int* matColSize, int* returnSize, int** returnColumnSizes) {
    int n = matSize;
    int m = matColSize[0];
    *returnSize = matSize;
    *returnColumnSizes = matColSize;

    Diagonal *diag = malloc((m + n) * sizeof(Diagonal));
    for (int i = 0; i < m + n; i++) {
        diag[i].arr = NULL;
        diag[i].size = 0;
    }
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            int d = i - j + m;
            diag[d].size++;
            diag[d].arr = realloc(diag[d].arr, diag[d].size * sizeof(int));
            diag[d].arr[diag[d].size - 1] = mat[i][j];
        }
    }

    for (int i = 0; i < m + n; i++) {
        if (diag[i].size > 0) {
            qsort(diag[i].arr, diag[i].size, sizeof(int), compare);
        }
    }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            int d = i - j + m;
            mat[i][j] = diag[d].arr[--diag[d].size];
        }
    }

    for (int i = 0; i < m + n; i++) {
        free(diag[i].arr);
    }
    free(diag);

    return mat;
}
```

```rust
impl Solution {
    pub fn diagonal_sort(mut mat: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        let n = mat.len();
        let m = mat[0].len();
        let mut diag = vec![vec![]; m + n];
        for i in 0..n {
            for j in 0..m {
                diag[i - j + m].push(mat[i][j]);
            }
        }
        for d in diag.iter_mut() {
            d.sort_by(|a, b| b.cmp(a));
        }
        for i in 0..n {
            for j in 0..m {
                mat[i][j] = diag[i - j + m].pop().unwrap();
            }
        }
        mat
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(mn \log mn)$，其中 $m$ 和 $n$ 是矩阵的大小。
- 空间复杂度：$O(mn)$，其中 $m$ 和 $n$ 是矩阵的大小。
