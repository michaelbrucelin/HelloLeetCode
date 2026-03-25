### [等和矩阵分割 I](https://leetcode.cn/problems/equal-sum-grid-partition-i/solutions/3926909/deng-he-ju-zhen-fen-ge-i-by-leetcode-sol-g2ob/)

#### 方法一：二维前缀和 + 枚举边界元素

**思路与算法**

题目要求我们通过 **一条** 水平或竖直的分割线将矩阵分割为两个部分，然后判断是否存在这样一条分割线，使得每个部分中的元素之和相等。

看到要求矩阵某个部分中所有元素之和，很容易想到使用前缀和进行预处理。

那么我们只需要用二维前缀和预处理，得到一个二维前缀和矩阵 $sum[m][n]$，然后按照以下方式进行判断：

1. 竖直分割线：
  想要判断是否存在竖直分割线，我们只需要枚举前缀和矩阵下边界上的元素 $sum[m][i]$，这个元素的值代表了以 $grid[0][0]$ 为左上角，以 $grid[m-1][i-1]$ 为右下角的矩阵中所有元素之和，如果这个值的两倍等于总和，那么就说明存在这样一条竖直分割线。
2. 水平分割线：
  同理于竖直分割线，枚举前缀和矩阵右边界上的元素进行判断即可。

**代码**

```C++
class Solution {
public:
    bool canPartitionGrid(vector<vector<int>>& grid) {
        int m = grid.size();
        int n = grid[0].size();
        long long sum[m + 1][n + 1];
        long long total = 0;
        memset(sum, 0, sizeof(sum));
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                sum[i + 1][j + 1] = sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + grid[i][j];
                total += grid[i][j];
            }
        }
        for (int i = 0; i < m - 1; i++) {
            if (total == sum[i + 1][n] * 2) {
                return true;
            }
        }
        for (int i = 0; i < n - 1; i++) {
            if (total == sum[m][i + 1] * 2) {
                return true;
            }
        }
        return false;
    }
};
```

```JavaScript
var canPartitionGrid = function(grid) {
    const m = grid.length;
    const n = grid[0].length;
    const sum = Array.from({ length: m + 1 }, () => Array(n + 1).fill(0));
    let total = 0;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            sum[i + 1][j + 1] = sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + grid[i][j];
            total += grid[i][j];
        }
    }
    for (let i = 0; i < m - 1; i++) {
        if (total === sum[i + 1][n] * 2) {
            return true;
        }
    }
    for (let i = 0; i < n - 1; i++) {
        if (total === sum[m][i + 1] * 2) {
            return true;
        }
    }
    return false;
};
```

```TypeScript
function canPartitionGrid(grid: number[][]): boolean {
    const m = grid.length;
    const n = grid[0].length;
    const sum: number[][] = Array.from({ length: m + 1 }, () => Array(n + 1).fill(0));
    let total = 0;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            sum[i + 1][j + 1] = sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + grid[i][j];
            total += grid[i][j];
        }
    }
    for (let i = 0; i < m - 1; i++) {
        if (total === sum[i + 1][n] * 2) {
            return true;
        }
    }
    for (let i = 0; i < n - 1; i++) {
        if (total === sum[m][i + 1] * 2) {
            return true;
        }
    }
    return false;
}
```

```Java
class Solution {
    public boolean canPartitionGrid(int[][] grid) {
        int m = grid.length;
        int n = grid[0].length;
        long[][] sum = new long[m + 1][n + 1];
        long total = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                sum[i + 1][j + 1] = sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + grid[i][j];
                total += grid[i][j];
            }
        }
        for (int i = 0; i < m - 1; i++) {
            if (total == sum[i + 1][n] * 2) {
                return true;
            }
        }
        for (int i = 0; i < n - 1; i++) {
            if (total == sum[m][i + 1] * 2) {
                return true;
            }
        }
        return false;
    }
}
```

```CSharp
public class Solution {
    public bool CanPartitionGrid(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        long[][] sum = new long[m + 1][];
        for (int i = 0; i <= m; i++) {
            sum[i] = new long[n + 1];
        }
        long total = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                sum[i + 1][j + 1] = sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + grid[i][j];
                total += grid[i][j];
            }
        }
        for (int i = 0; i < m - 1; i++) {
            if (total == sum[i + 1][n] * 2) {
                return true;
            }
        }
        for (int i = 0; i < n - 1; i++) {
            if (total == sum[m][i + 1] * 2) {
                return true;
            }
        }
        return false;
    }
}
```

```Go
func canPartitionGrid(grid [][]int) bool {
    m, n := len(grid), len(grid[0])
    sum := make([][]int64, m+1)
    for i := range sum {
        sum[i] = make([]int64, n+1)
    }
    var total int64 = 0
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            sum[i+1][j+1] = sum[i+1][j] + sum[i][j+1] - sum[i][j] + int64(grid[i][j])
            total += int64(grid[i][j])
        }
    }
    for i := 0; i < m-1; i++ {
        if total == sum[i+1][n]*2 {
            return true
        }
    }
    for i := 0; i < n-1; i++ {
        if total == sum[m][i+1]*2 {
            return true
        }
    }
    return false
}
```

```Python
class Solution:
    def canPartitionGrid(self, grid: List[List[int]]) -> bool:
        m, n = len(grid), len(grid[0])
        sum = [[0] * (n + 1) for _ in range(m + 1)]
        total = 0
        for i in range(m):
            for j in range(n):
                sum[i + 1][j + 1] = (sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + grid[i][j])
                total += grid[i][j]
        for i in range(m - 1):
            if total == sum[i + 1][n] * 2:
                return True
        for i in range(n - 1):
            if total == sum[m][i + 1] * 2:
                return True
        return False
```

```C
bool canPartitionGrid(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    long long sum[m + 1][n + 1];
    long long total = 0;
    memset(sum, 0, sizeof(sum));
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            sum[i + 1][j + 1] = sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + grid[i][j];
            total += grid[i][j];
        }
    }
    for (int i = 0; i < m - 1; i++) {
        if (total == sum[i + 1][n] * 2) {
            return true;
        }
    }
    for (int i = 0; i < n - 1; i++) {
        if (total == sum[m][i + 1] * 2) {
            return true;
        }
    }
    return false;
}
```

```Rust
impl Solution {
    pub fn can_partition_grid(grid: Vec<Vec<i32>>) -> bool {
        let m = grid.len();
        let n = grid[0].len();
        let mut sum = vec![vec![0i64; n + 1]; m + 1];
        let mut total: i64 = 0;
        for i in 0..m {
            for j in 0..n {
                sum[i + 1][j + 1] = sum[i + 1][j] + sum[i][j + 1] - sum[i][j] + grid[i][j] as i64;
                total += grid[i][j] as i64;
            }
        }
        for i in 0..m - 1 {
            if total == sum[i + 1][n] * 2 {
                return true;
            }
        }
        for i in 0..n - 1 {
            if total == sum[m][i + 1] * 2 {
                return true;
            }
        }
        false
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 为 $grid$ 矩阵的行数，$n$ 为 $grid$ 矩阵的列数。
- 空间复杂度：$O(mn)$，其中 $m$ 为 $grid$ 矩阵的行数，$n$ 为 $grid$ 矩阵的列数。

#### 方法二：旋转矩阵 $+$ 枚举上半矩阵之和

**思路与算法**

题目要求判断两种分割线，我们可以将原矩阵 $grid$ 旋转 $90$ 度之后复用旋转之前的代码，这样只需要判断一种分割线了，本方法判断的是水平分割线，竖直分割线的判断方法类似，在此不再赘述。

判断方式如下：

枚举矩阵 $grid$ 每一行的元素，并维护一个 $sum$ 来保存当前行及之前行所有元素的和，在遍历完一行后进行判断，如果 $sum$ 的值的两倍等于总和，那么分割线存在。

**代码**

```C++
class Solution {
public:
    vector<vector<int>> rotation(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector tmp(n, vector<int>(m));
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                tmp[j][m - 1 - i] = grid[i][j];
            }
        }
        return tmp;
    }
    bool canPartitionGrid(vector<vector<int>>& grid) {
        long long total = 0;
        long long sum;
        int m = grid.size();
        int n = grid[0].size();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                total += grid[i][j];
            }
        }
        for (int k = 0; k < 2; k++) {
            sum = 0;
            m = grid.size();
            n = grid[0].size();
            for (int i = 0; i < m - 1; i++) {
                for(int j = 0; j < n; j++){
                    sum += grid[i][j];
                }
                if(sum * 2 == total){
                    return true;
                }
            }
            grid = rotation(grid);
        }
        return false;
    }
};
```

```JavaScript
var canPartitionGrid = function(grid) {
    let total = 0;
    let m = grid.length;
    let n = grid[0].length;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            total += grid[i][j];
        }
    }
    for (let k = 0; k < 2; k++) {
        let sum = 0;
        m = grid.length;
        n = grid[0].length;
        for (let i = 0; i < m - 1; i++) {
            for (let j = 0; j < n; j++) {
                sum += grid[i][j];
            }
            if (sum * 2 === total) {
                return true;
            }
        }
        grid = rotation(grid);
    }
    return false;
};

function rotation(grid) {
    const m = grid.length, n = grid[0].length;
    const tmp = Array.from({ length: n }, () => Array(m).fill(0));
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            tmp[j][m - 1 - i] = grid[i][j];
        }
    }
    return tmp;
}
```

```TypeScript
function canPartitionGrid(grid: number[][]): boolean {
    let total = 0;
    let m = grid.length;
    let n = grid[0].length;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            total += grid[i][j];
        }
    }
    for (let k = 0; k < 2; k++) {
        let sum = 0;
        m = grid.length;
        n = grid[0].length;
        for (let i = 0; i < m - 1; i++) {
            for (let j = 0; j < n; j++) {
                sum += grid[i][j];
            }
            if (sum * 2 === total) {
                return true;
            }
        }
        grid = rotation(grid);
    }
    return false;
}

function rotation(grid: number[][]): number[][] {
    const m = grid.length, n = grid[0].length;
    const tmp: number[][] = Array.from({ length: n }, () => Array(m).fill(0));
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            tmp[j][m - 1 - i] = grid[i][j];
        }
    }
    return tmp;
}
```

```Java
class Solution {
    public boolean canPartitionGrid(int[][] grid) {
        long total = 0;
        int m = grid.length;
        int n = grid[0].length;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                total += grid[i][j];
            }
        }
        for (int k = 0; k < 2; k++) {
            long sum = 0;
            m = grid.length;
            n = grid[0].length;
            for (int i = 0; i < m - 1; i++) {
                for (int j = 0; j < n; j++) {
                    sum += grid[i][j];
                }
                if (sum * 2 == total) {
                    return true;
                }
            }
            grid = rotation(grid);
        }
        return false;
    }

    public int[][] rotation(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[][] tmp = new int[n][m];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                tmp[j][m - 1 - i] = grid[i][j];
            }
        }
        return tmp;
    }
}
```

```CSharp
public class Solution {
    public bool CanPartitionGrid(int[][] grid) {
        long total = 0;
        int m = grid.Length;
        int n = grid[0].Length;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                total += grid[i][j];
            }
        }
        for (int k = 0; k < 2; k++) {
            long sum = 0;
            m = grid.Length;
            n = grid[0].Length;
            for (int i = 0; i < m - 1; i++) {
                for (int j = 0; j < n; j++) {
                    sum += grid[i][j];
                }
                if (sum * 2 == total) {
                    return true;
                }
            }
            grid = Rotation(grid);
        }
        return false;
    }

    public int[][] Rotation(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] tmp = new int[n][];
        for (int i = 0; i < n; i++) {
            tmp[i] = new int[m];
        }
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                tmp[j][m - 1 - i] = grid[i][j];
            }
        }
        return tmp;
    }
}
```

```Go
func canPartitionGrid(grid [][]int) bool {
    var total int64 = 0
    m, n := len(grid), len(grid[0])
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            total += int64(grid[i][j])
        }
    }
    for k := 0; k < 2; k++ {
        var sum int64 = 0
        m, n = len(grid), len(grid[0])
        for i := 0; i < m-1; i++ {
            for j := 0; j < n; j++ {
                sum += int64(grid[i][j])
            }
            if sum*2 == total {
                return true
            }
        }
        grid = rotation(grid)
    }
    return false
}

func rotation(grid [][]int) [][]int {
    m, n := len(grid), len(grid[0])
    tmp := make([][]int, n)
    for i := range tmp {
        tmp[i] = make([]int, m)
    }
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            tmp[j][m-1-i] = grid[i][j]
        }
    }
    return tmp
}
```

```Python
class Solution:
    def canPartitionGrid(self, grid: List[List[int]]) -> bool:
        total = 0
        m = len(grid)
        n = len(grid[0])
        for i in range(m):
            for j in range(n):
                total += grid[i][j]
        for _ in range(2):
            sum_val = 0
            m = len(grid)
            n = len(grid[0])
            for i in range(m - 1):
                for j in range(n):
                    sum_val += grid[i][j]
                if sum_val * 2 == total:
                    return True
            grid = self.rotation(grid)
        return False

    def rotation(self, grid: List[List[int]]) -> List[List[int]]:
        m = len(grid)
        n = len(grid[0])
        tmp = [[0] * m for _ in range(n)]
        for i in range(m):
            for j in range(n):
                tmp[j][m - 1 - i] = grid[i][j]
        return tmp
```

```C
int** rotation(int** grid, int gridSize, int* gridColSize, int* returnSize, int** returnColumnSizes) {
    int m = gridSize, n = gridColSize[0];
    int** tmp = (int**)malloc(sizeof(int*) * n);
    for (int i = 0; i < n; i++) {
        tmp[i] = (int*)malloc(sizeof(int) * m);
    }
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            tmp[j][m - 1 - i] = grid[i][j];
        }
    }
    *returnSize = n;
    *returnColumnSizes = (int*)malloc(sizeof(int) * n);
    for (int i = 0; i < n; i++) {
        (*returnColumnSizes)[i] = m;
    }
    return tmp;
}

bool canPartitionGrid(int** grid, int gridSize, int* gridColSize) {
    long long total = 0;
    int m = gridSize, n = gridColSize[0];
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            total += grid[i][j];
        }
    }
    for (int k = 0; k < 2; k++) {
        long long sum = 0;
        m = gridSize;
        n = gridColSize[0];
        for (int i = 0; i < m - 1; i++) {
            for (int j = 0; j < n; j++) {
                sum += grid[i][j];
            }
            if (sum * 2 == total) {
                return true;
            }
        }
        int returnSize, *returnColumnSizes;
        grid = rotation(grid, gridSize, gridColSize, &returnSize, &returnColumnSizes);
        gridSize = returnSize;
        gridColSize = returnColumnSizes;
    }
    return false;
}
```

```Rust
impl Solution {
    pub fn can_partition_grid(mut grid: Vec<Vec<i32>>) -> bool {
        let mut total: i64 = 0;
        let mut m = grid.len();
        let mut n = grid[0].len();
        for i in 0..m {
            for j in 0..n {
                total += grid[i][j] as i64;
            }
        }
        for _ in 0..2 {
            let mut sum: i64 = 0;
            m = grid.len();
            n = grid[0].len();
            for i in 0..m - 1 {
                for j in 0..n {
                    sum += grid[i][j] as i64;
                }
                if sum * 2 == total {
                    return true;
                }
            }
            grid = Self::rotation(grid);
        }
        false
    }

    fn rotation(grid: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        let m = grid.len();
        let n = grid[0].len();
        let mut tmp = vec![vec![0; m]; n];
        for i in 0..m {
            for j in 0..n {
                tmp[j][m - 1 - i] = grid[i][j];
            }
        }
        tmp
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 为 $grid$ 矩阵的行数，$n$ 为 $grid$ 矩阵的列数。
- 空间复杂度：$O(mn)$，其中 $m$ 为 $grid$ 矩阵的行数，$n$ 为 $grid$ 矩阵的列数。
