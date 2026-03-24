### [构造乘积矩阵](https://leetcode.cn/problems/construct-product-matrix/solutions/3922670/gou-zao-cheng-ji-ju-zhen-by-leetcode-sol-01cx/)

#### 方法一：后缀乘积

**思路与算法**

题目对矩阵 $grid$ **乘积矩阵** $p$ 的定义如下：

- 每个元素 $p[i][j]$，它的值等于除了 $grid[i][j]$ 外所有元素的乘积。乘积对 $12345$ 取余数。

如果给定的矩阵为一维数组，则本题即与「[238\. 除了自身以外数组的乘积](https://leetcode.cn/problems/product-of-array-except-self/)」几乎一样。同样的解法，我们如果将二维矩阵展开为一个一维数组，然后分别计算出左边的乘积与右边的乘积，即可计算出除当前元素以外所有元素的乘积。

同样的原理，我们可以分别计算出当前元素的前缀积与后缀积，即可求出 **乘积矩阵** 的每个元素。计算每个元素 $p[i][j]$ 的过程如下：

- 先算出当前元素之后的**后缀积**，即从 $grid[i][j]$ 的下一个元素开始，到最后一个元素 $grid[n-1][m-1]$ 的乘积，记作 $suffix[i][j]$。计算时，我们可以从二维矩阵的最后一个元素开始，即从 $grid[n-1][m-1]$ 开始倒序边遍历边计算。
- 接着算出当前元素之前的**前缀积**，即从第一个元素 $grid[0][0]$ 开始，到 $grid[i][j]$ 的上一个元素的乘积，记作 $prefix[i][j]$。计算时，我们可以从二维矩阵的第一个元素开始，即从 $grid[0][0]$ 开始顺序边边遍历边计算。

此时根据题意可知:

$$p[i][j]=prefix[i][j]\cdot suffix[i][j]$$

具体实现时，为了节省空间，我们可以先在倒序计算后缀积时同时初始化 $p[i][j]=suffix[i][j]$，然后顺序计算前缀积时，我们不必开拓新的空间，直接将当前的前缀积保存到一个变量 $prefix$ 中，直接乘以 $p[i][j]$ 就得到了最终答案。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> constructProductMatrix(vector<vector<int>> &grid) {
        const int MOD = 12345;
        int n = grid.size(), m = grid[0].size();
        vector<vector<int>> p(n, vector<int>(m));

        long long suffix = 1;
        for (int i = n - 1; i >= 0; i--) {
            for (int j = m - 1; j >= 0; j--) {
                p[i][j] = suffix;
                suffix = suffix * grid[i][j] % MOD;
            }
        }

        long long prefix = 1;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                p[i][j] = p[i][j] * prefix % MOD;
                prefix = prefix * grid[i][j] % MOD;
            }
        }

        return p;
    }
};
```

```Java
cclass Solution {
    public int[][] constructProductMatrix(int[][] grid) {
        final int MOD = 12345;
        int n = grid.length, m = grid[0].length;
        int[][] p = new int[n][m];

        long suffix = 1;
        for (int i = n - 1; i >= 0; i--) {
            for (int j = m - 1; j >= 0; j--) {
                p[i][j] = (int)suffix;
                suffix = suffix * grid[i][j] % MOD;
            }
        }

        long prefix = 1;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                p[i][j] = (int)((long)p[i][j] * prefix % MOD);
                prefix = prefix * grid[i][j] % MOD;
            }
        }

        return p;
    }
}
```

```CSharp
public class Solution {
    public int[][] ConstructProductMatrix(int[][] grid) {
        const int MOD = 12345;
        int n = grid.Length, m = grid[0].Length;
        int[][] p = new int[n][];

        for (int i = 0; i < n; i++) {
            p[i] = new int[m];
        }
        long suffix = 1;
        for (int i = n - 1; i >= 0; i--) {
            for (int j = m - 1; j >= 0; j--) {
                p[i][j] = (int)suffix;
                suffix = suffix * grid[i][j] % MOD;
            }
        }

        long prefix = 1;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                p[i][j] = (int)((long)p[i][j] * prefix % MOD);
                prefix = prefix * grid[i][j] % MOD;
            }
        }

        return p;
    }
}
```

```Python
class Solution:
    def constructProductMatrix(self, grid: List[List[int]]) -> List[List[int]]:
        MOD = 12345
        n, m = len(grid), len(grid[0])
        p = [[0] * m for _ in range(n)]

        suffix = 1
        for i in range(n - 1, -1, -1):
            for j in range(m - 1, -1, -1):
                p[i][j] = suffix
                suffix = (suffix * grid[i][j]) % MOD

        prefix = 1
        for i in range(n):
            for j in range(m):
                p[i][j] = (p[i][j] * prefix) % MOD
                prefix = (prefix * grid[i][j]) % MOD

        return p
```

```Go
func constructProductMatrix(grid [][]int) [][]int {
    const MOD = 12345
    n, m := len(grid), len(grid[0])
    p := make([][]int, n)
    for i := range p {
        p[i] = make([]int, m)
    }

    suffix := int64(1)
    for i := n - 1; i >= 0; i-- {
        for j := m - 1; j >= 0; j-- {
            p[i][j] = int(suffix)
            suffix = (suffix * int64(grid[i][j])) % MOD
        }
    }

    prefix := int64(1)
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            p[i][j] = int((int64(p[i][j]) * prefix) % MOD)
            prefix = (prefix * int64(grid[i][j])) % MOD
        }
    }

    return p
}
```

```C
int** constructProductMatrix(int** grid, int gridSize, int* gridColSize, int* returnSize, int** returnColumnSizes) {
    const int MOD = 12345;
    int n = gridSize, m = gridColSize[0];

    int** p = (int**)malloc(n * sizeof(int*));
    *returnColumnSizes = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        p[i] = (int*)malloc(m * sizeof(int));
        (*returnColumnSizes)[i] = m;
    }
    *returnSize = n;

    long long suffix = 1;
    for (int i = n - 1; i >= 0; i--) {
        for (int j = m - 1; j >= 0; j--) {
            p[i][j] = suffix % MOD;
            suffix = (suffix * grid[i][j]) % MOD;
        }
    }

    long long prefix = 1;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            p[i][j] = (p[i][j] * prefix) % MOD;
            prefix = (prefix * grid[i][j]) % MOD;
        }
    }

    return p;
}
```

```JavaScript
var constructProductMatrix = function(grid) {
    const MOD = 12345;
    const n = grid.length, m = grid[0].length;
    const p = Array.from({length: n}, () => new Array(m).fill(0));

    let suffix = 1;
    for (let i = n - 1; i >= 0; i--) {
        for (let j = m - 1; j >= 0; j--) {
            p[i][j] = suffix;
            suffix = (suffix * grid[i][j]) % MOD;
        }
    }

    let prefix = 1;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            p[i][j] = (p[i][j] * prefix) % MOD;
            prefix = (prefix * grid[i][j]) % MOD;
        }
    }

    return p;
};
```

```TypeScript
function constructProductMatrix(grid: number[][]): number[][] {
    const MOD: number = 12345;
    const n: number = grid.length, m: number = grid[0].length;
    const p: number[][] = Array.from({length: n}, () => new Array(m).fill(0));

    let suffix: number = 1;
    for (let i = n - 1; i >= 0; i--) {
        for (let j = m - 1; j >= 0; j--) {
            p[i][j] = suffix;
            suffix = (suffix * grid[i][j]) % MOD;
        }
    }

    let prefix: number = 1;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            p[i][j] = (p[i][j] * prefix) % MOD;
            prefix = (prefix * grid[i][j]) % MOD;
        }
    }

    return p;
}
```

```Rust
impl Solution {
    pub fn construct_product_matrix(grid: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        const MOD: i64 = 12345;
        let n = grid.len();
        let m = grid[0].len();
        let mut p = vec![vec![0; m]; n];

        let mut suffix: i64 = 1;
        for i in (0..n).rev() {
            for j in (0..m).rev() {
                p[i][j] = (suffix % MOD) as i32;
                suffix = (suffix * grid[i][j] as i64) % MOD;
            }
        }

        let mut prefix: i64 = 1;
        for i in 0..n {
            for j in 0..m {
                p[i][j] = ((p[i][j] as i64 * prefix) % MOD) as i32;
                prefix = (prefix * grid[i][j] as i64) % MOD;
            }
        }

        p
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中 $n,m$ 表示给定二维矩阵的行数与列数。需要遍历整个二维矩阵，因此总的时间复杂度为 $O(nm)$。
- 空间复杂度：$O(1)$。除了返回值外，不需要额外的空间。
