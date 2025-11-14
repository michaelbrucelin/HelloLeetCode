### [子矩阵元素加 1](https://leetcode.cn/problems/increment-submatrices-by-one/solutions/3820749/zi-ju-zhen-yuan-su-jia-1-by-leetcode-sol-3iob/)

#### 方法一：二维差分 + 前缀和

题目要求我们对一个 $n\times n$ 的整数矩阵 $mat$ 执行多次「矩形内元素加一」的操作，并返回执行完所有操作后的矩阵 $mat$。在二维情况下，如果对矩形内的所有元素都加一，可以在二维差分数组 $diff$ 上执行以下操作：

$$\begin{array}{l}diff[row_1][col_1]+=1 \\ diff[row_2+1][col_1]-=1 \\ diff[row_1][col_2+1]-=1 \\ diff[row_2+1][col_2+1]+=1\end{array}$$

那么执行完所有操作后的矩阵 $mat$ 就是在二维差分数组上的前缀和：

$$mat[i][j]=diff[i][j]+mat[i-1][j]+mat[i][j-1]-mat[i-1][j-1]$$

```C++
class Solution {
public:
    vector<vector<int>> rangeAddQueries(int n, vector<vector<int>>& queries) {
        vector diff(n + 1, vector<int>(n + 1));
        for (const auto& query : queries) {
            int row1 = query[0], col1 = query[1];
            int row2 = query[2], col2 = query[3];
            diff[row1][col1] += 1;
            diff[row2 + 1][col1] -= 1;
            diff[row1][col2 + 1] -= 1;
            diff[row2 + 1][col2 + 1] += 1;
        }
        vector mat(n, vector<int>(n));
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int x1 = (i == 0) ? 0 : mat[i - 1][j];
                int x2 = (j == 0) ? 0 : mat[i][j - 1];
                int x3 = (i == 0 || j == 0) ? 0 : mat[i - 1][j - 1];
                mat[i][j] = diff[i][j] + x1 + x2 - x3;
            }
        }
        return mat;
    }
};
```

```Go
func rangeAddQueries(n int, queries [][]int) [][]int {
    diff := make([][]int, n + 1)
    for i := range diff {
        diff[i] = make([]int, n + 1)
    }

    for _, q := range queries {
        row1, col1, row2, col2 := q[0], q[1], q[2], q[3]
        diff[row1][col1] += 1
        diff[row2 + 1][col1] -= 1
        diff[row1][col2 + 1] -= 1
        diff[row2 + 1][col2 + 1] += 1
    }

    mat := make([][]int, n)
    for i := range mat {
        mat[i] = make([]int, n)
    }

    for i := 0; i < n; i++ {
        for j := 0; j < n; j++ {
            x1 := 0
            if i > 0 {
                x1 = mat[i-1][j]
            }
            x2 := 0
            if j > 0 {
                x2 = mat[i][j-1]
            }
            x3 := 0
            if i > 0 && j > 0 {
                x3 = mat[i-1][j-1]
            }
            mat[i][j] = diff[i][j] + x1 + x2 - x3
        }
    }
    return mat
}
```

```Python
class Solution:
    def rangeAddQueries(self, n: int, queries: List[List[int]]) -> List[List[int]]:
        diff = [[0] * (n + 1) for _ in range(n + 1)]
        for row1, col1, row2, col2 in queries:
            diff[row1][col1] += 1
            diff[row2 + 1][col1] -= 1
            diff[row1][col2 + 1] -= 1
            diff[row2 + 1][col2 + 1] += 1

        mat = [[0] * n for _ in range(n)]
        for i in range(n):
            for j in range(n):
                x1 = 0 if i == 0 else mat[i - 1][j]
                x2 = 0 if j == 0 else mat[i][j - 1]
                x3 = 0 if i == 0 or j == 0 else mat[i - 1][j - 1]
                mat[i][j] = diff[i][j] + x1 + x2 - x3
        return mat
```

```Java
class Solution {
    public int[][] rangeAddQueries(int n, int[][] queries) {
        int[][] diff = new int[n + 1][n + 1];
        for (int[] q : queries) {
            int row1 = q[0], col1 = q[1], row2 = q[2], col2 = q[3];
            diff[row1][col1] += 1;
            diff[row2 + 1][col1] -= 1;
            diff[row1][col2 + 1] -= 1;
            diff[row2 + 1][col2 + 1] += 1;
        }

        int[][] mat = new int[n][n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int x1 = (i == 0) ? 0 : mat[i - 1][j];
                int x2 = (j == 0) ? 0 : mat[i][j - 1];
                int x3 = (i == 0 || j == 0) ? 0 : mat[i - 1][j - 1];
                mat[i][j] = diff[i][j] + x1 + x2 - x3;
            }
        }
        return mat;
    }
}
```

```TypeScript
function rangeAddQueries(n: number, queries: number[][]): number[][] {
    let diff: number[][] = Array.from({length: n+1}, () => Array(n+1).fill(0));
    for (let [row1, col1, row2, col2] of queries) {
        diff[row1][col1] += 1;
        diff[row2+1][col1] -= 1;
        diff[row1][col2+1] -= 1;
        diff[row2+1][col2+1] += 1;
    }

    let mat: number[][] = Array.from({length: n}, () => Array(n).fill(0));
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            let x1 = i === 0 ? 0 : mat[i-1][j];
            let x2 = j === 0 ? 0 : mat[i][j-1];
            let x3 = (i === 0 || j === 0) ? 0 : mat[i-1][j-1];
            mat[i][j] = diff[i][j] + x1 + x2 - x3;
        }
    }
    return mat;
}
```

```JavaScript
var rangeAddQueries = function(n, queries) {
    let diff = Array.from({length: n+1}, () => Array(n+1).fill(0));
    for (let [row1, col1, row2, col2] of queries) {
        diff[row1][col1] += 1;
        diff[row2+1][col1] -= 1;
        diff[row1][col2+1] -= 1;
        diff[row2+1][col2+1] += 1;
    }

    let mat = Array.from({length: n}, () => Array(n).fill(0));
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            let x1 = i === 0 ? 0 : mat[i-1][j];
            let x2 = j === 0 ? 0 : mat[i][j-1];
            let x3 = (i === 0 || j === 0) ? 0 : mat[i-1][j-1];
            mat[i][j] = diff[i][j] + x1 + x2 - x3;
        }
    }
    return mat;
};
```

```CSharp
public class Solution {
    public int[][] RangeAddQueries(int n, int[][] queries) {
        int[][] diff = new int[n + 1][];
        for (int i = 0; i <= n; i++) {
            diff[i] = new int[n + 1];
        }

        foreach (var q in queries) {
            int row1 = q[0], col1 = q[1], row2 = q[2], col2 = q[3];
            diff[row1][col1] += 1;
            diff[row2 + 1][col1] -= 1;
            diff[row1][col2 + 1] -= 1;
            diff[row2 + 1][col2 + 1] += 1;
        }

        int[][] mat = new int[n][];
        for (int i = 0; i < n; i++) {
            mat[i] = new int[n];
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int x1 = (i == 0) ? 0 : mat[i - 1][j];
                int x2 = (j == 0) ? 0 : mat[i][j - 1];
                int x3 = (i == 0 || j == 0) ? 0 : mat[i - 1][j - 1];
                mat[i][j] = diff[i][j] + x1 + x2 - x3;
            }
        }
        return mat;
    }
}
```

```C
int** rangeAddQueries(int n, int** queries, int queriesSize, int* queriesColSize, int* returnSize, int** returnColumnSizes) {
    int diff[n + 1][n + 1] = {};
    for (int k = 0; k < queriesSize; k++) {
        int row1 = queries[k][0], col1 = queries[k][1], row2 = queries[k][2], col2 = queries[k][3];
        diff[row1][col1] += 1;
        diff[row2 + 1][col1] -= 1;
        diff[row1][col2 + 1] -= 1;
        diff[row2 + 1][col2 + 1] += 1;
    }

    int** mat = (int**)malloc(n * sizeof(int*));
    *returnColumnSizes = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        mat[i] = (int*)calloc(n, sizeof(int));
        (*returnColumnSizes)[i] = n;
    }
    *returnSize = n;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            int x1 = (i == 0) ? 0 : mat[i-1][j];
            int x2 = (j == 0) ? 0 : mat[i][j-1];
            int x3 = (i == 0 || j == 0) ? 0 : mat[i-1][j-1];
            mat[i][j] = diff[i][j] + x1 + x2 - x3;
        }
    }
    return mat;
}
```

```Rust
impl Solution {
    pub fn range_add_queries(n: i32, queries: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        let n = n as usize;
        let mut diff = vec![vec![0; n+1]; n+1];
        for q in queries.iter() {
            let (row1, col1, row2, col2) = (q[0] as usize, q[1] as usize, q[2] as usize, q[3] as usize);
            diff[row1][col1] += 1;
            diff[row2+1][col1] -= 1;
            diff[row1][col2+1] -= 1;
            diff[row2+1][col2+1] += 1;
        }

        let mut mat = vec![vec![0; n]; n];
        for i in 0..n {
            for j in 0..n {
                let x1 = if i == 0 { 0 } else { mat[i-1][j] };
                let x2 = if j == 0 { 0 } else { mat[i][j-1] };
                let x3 = if i == 0 || j == 0 { 0 } else { mat[i-1][j-1] };
                mat[i][j] = diff[i][j] + x1 + x2 - x3;
            }
        }
        mat
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$。
- 空间复杂度：$O(n^2)$。
