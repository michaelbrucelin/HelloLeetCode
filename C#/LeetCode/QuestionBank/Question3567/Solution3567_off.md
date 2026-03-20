### [子矩阵的最小绝对差](https://leetcode.cn/problems/minimum-absolute-difference-in-sliding-submatrix/solutions/3920192/zi-ju-zhen-de-zui-xiao-jue-dui-chai-by-l-d2l5/)

#### 方法一：排序

枚举矩阵 $grid$ 中的每个连续的 $k\times k$ 子矩阵，将子矩阵的所有元素放到数组 $kgrid$ 里，然后将 $kgrid$ 从小到大进行排序。遍历 $kgrid$，计算数组 $kgrid$ 所有相邻且不相等的元素间最小绝对差，即子矩阵的最小绝对差。

```C++
class Solution {
public:
    vector<vector<int>> minAbsDiff(vector<vector<int>>& grid, int k) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> res(m - k + 1, vector<int>(n - k + 1));
        for (int i = 0; i + k <= m; i++) {
            for (int j = 0; j + k <= n; j++) {
                vector<int> kgrid;
                for (int x = i; x < i + k; x++) {
                    for (int y = j; y < j + k; y++) {
                        kgrid.push_back(grid[x][y]);
                    }
                }
                int kmin = INT_MAX;
                sort(kgrid.begin(), kgrid.end());
                for (int t = 1; t < kgrid.size(); t++) {
                    if (kgrid[t] == kgrid[t - 1]) {
                        continue;
                    }
                    kmin = min(kmin, kgrid[t] - kgrid[t - 1]);
                }
                if (kmin != INT_MAX) {
                    res[i][j] = kmin;
                }
            }
        }
        return res;
    }
};
```

```Go
func minAbsDiff(grid [][]int, k int) [][]int {
    m, n := len(grid), len(grid[0])
    res := make([][]int, m - k + 1)
    for i := range res {
        res[i] = make([]int, n - k + 1)
    }
    for i := 0; i + k <= m; i++ {
        for j := 0; j + k <= n; j++ {
            kgrid := []int{}
            for x := i; x < i + k; x++ {
                for y := j; y < j + k; y++ {
                    kgrid = append(kgrid, grid[x][y])
                }
            }
            kmin := math.MaxInt
            sort.Ints(kgrid)
            for t := 1; t < len(kgrid); t++ {
                if kgrid[t] == kgrid[t - 1] {
                    continue
                }
                kmin = min(kmin, kgrid[t] - kgrid[t-1])
            }
            if kmin != math.MaxInt {
                res[i][j] = kmin
            }
        }
    }
    return res
}
```

```Python
class Solution:
    def minAbsDiff(self, grid: List[List[int]], k: int) -> List[List[int]]:
        m, n = len(grid), len(grid[0])
        res = [[0] * (n - k + 1) for _ in range(m - k + 1)]
        for i in range(m - k + 1):
            for j in range(n - k + 1):
                kgrid = []
                for x in range(i, i + k):
                    for y in range(j, j + k):
                        kgrid.append(grid[x][y])
                kmin = float('inf')
                kgrid.sort()
                for t in range(1, len(kgrid)):
                    if kgrid[t] == kgrid[t - 1]:
                        continue
                    kmin = min(kmin, kgrid[t] - kgrid[t - 1])
                if kmin != float('inf'):
                    res[i][j] = kmin
        return res
```

```Java
class Solution {
    public int[][] minAbsDiff(int[][] grid, int k) {
        int m = grid.length, n = grid[0].length;
        int[][] res = new int[m - k + 1][n - k + 1];
        for (int i = 0; i + k <= m; i++) {
            for (int j = 0; j + k <= n; j++) {
                List<Integer> kgrid = new ArrayList<>();
                for (int x = i; x < i + k; x++) {
                    for (int y = j; y < j + k; y++) {
                        kgrid.add(grid[x][y]);
                    }
                }
                int kmin = Integer.MAX_VALUE;
                Collections.sort(kgrid);
                for (int t = 1; t < kgrid.size(); t++) {
                    if (kgrid.get(t).equals(kgrid.get(t - 1))) {
                        continue;
                    }
                    kmin = Math.min(kmin, kgrid.get(t) - kgrid.get(t - 1));
                }
                if (kmin != Integer.MAX_VALUE) {
                    res[i][j] = kmin;
                }
            }
        }
        return res;
    }
}
```

```TypeScript
function minAbsDiff(grid: number[][], k: number): number[][] {
    const m = grid.length, n = grid[0].length;
    const res: number[][] = Array.from({ length: m - k + 1 }, () => Array(n - k + 1).fill(0));
    for (let i = 0; i + k <= m; i++) {
        for (let j = 0; j + k <= n; j++) {
            let kgrid: number[] = [];
            for (let x = i; x < i + k; x++) {
                for (let y = j; y < j + k; y++) {
                    kgrid.push(grid[x][y]);
                }
            }
            let kmin = Number.MAX_SAFE_INTEGER;
            kgrid.sort((a, b) => a - b);
            for (let t = 1; t < kgrid.length; t++) {
                if (kgrid[t] === kgrid[t - 1]) {
                    continue;
                }
                kmin = Math.min(kmin, kgrid[t] - kgrid[t - 1]);
            }
            if (kmin !== Number.MAX_SAFE_INTEGER) {
                res[i][j] = kmin;
            }
        }
    }
    return res;
}
```

```JavaScript
var minAbsDiff = function(grid, k) {
    const m = grid.length, n = grid[0].length;
    const res = Array.from({ length: m - k + 1 }, () => Array(n - k + 1).fill(0));
    for (let i = 0; i + k <= m; i++) {
        for (let j = 0; j + k <= n; j++) {
            let kgrid = [];
            for (let x = i; x < i + k; x++) {
                for (let y = j; y < j + k; y++) {
                    kgrid.push(grid[x][y]);
                }
            }
            let kmin = Number.MAX_SAFE_INTEGER;
            kgrid.sort((a, b) => a - b);
            for (let t = 1; t < kgrid.length; t++) {
                if (kgrid[t] === kgrid[t - 1]) {
                    continue;
                }
                kmin = Math.min(kmin, kgrid[t] - kgrid[t - 1]);
            }
            if (kmin !== Number.MAX_SAFE_INTEGER) {
                res[i][j] = kmin;
            }
        }
    }
    return res;
};
```

```CSharp
public class Solution {
    public int[][] MinAbsDiff(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;
        int[][] res = new int[m - k + 1][];
        for (int i = 0; i < m - k + 1; i++) {
            res[i] = new int[n - k + 1];
        }
        for (int i = 0; i + k <= m; i++) {
            for (int j = 0; j + k <= n; j++) {
                List<int> kgrid = new List<int>();
                for (int x = i; x < i + k; x++) {
                    for (int y = j; y < j + k; y++) {
                        kgrid.Add(grid[x][y]);
                    }
                }
                int kmin = int.MaxValue;
                kgrid.Sort();
                for (int t = 1; t < kgrid.Count; t++) {
                    if (kgrid[t] == kgrid[t - 1]) {
                        continue;
                    }
                    kmin = Math.Min(kmin, kgrid[t] - kgrid[t - 1]);
                }
                if (kmin != int.MaxValue) {
                    res[i][j] = kmin;
                }
            }
        }
        return res;
    }
}
```

```C
int cmp(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int** minAbsDiff(int** grid, int m, int* gridColSize, int k, int* returnSize, int** returnColumnSizes) {
    int n = gridColSize[0];
    int rows = m - k + 1, cols = n - k + 1;
    int** res = (int**)malloc(rows * sizeof(int*));
    *returnSize = rows;
    *returnColumnSizes = (int*)malloc(rows * sizeof(int));
    for (int i = 0; i < rows; i++) {
        res[i] = (int*)calloc(cols, sizeof(int));
        (*returnColumnSizes)[i] = cols;
    }
    int size = k * k;
    int* kgrid = (int*)malloc(size * sizeof(int));
    for (int i = 0; i + k <= m; i++) {
        for (int j = 0; j + k <= n; j++) {
            int idx = 0;
            for (int x = i; x < i + k; x++) {
                for (int y = j; y < j + k; y++) {
                    kgrid[idx++] = grid[x][y];
                }
            }
            int kmin = INT_MAX;
            qsort(kgrid, size, sizeof(int), cmp);
            for (int t = 1; t < size; t++) {
                if (kgrid[t] == kgrid[t - 1]) {
                    continue;
                }
                kmin = fmin(kmin, kgrid[t] - kgrid[t - 1]);
            }
            if (kmin != INT_MAX) {
                res[i][j] = kmin;
            }
        }
    }
    free(kgrid);
    return res;
}
```

```Rust
impl Solution {
    pub fn min_abs_diff(grid: Vec<Vec<i32>>, k: i32) -> Vec<Vec<i32>> {
        let k = k as usize;
        let m = grid.len();
        let n = grid[0].len();
        let mut res = vec![vec![0; n - k + 1]; m - k + 1];
        for i in 0..=m - k {
            for j in 0..=n - k {
                let mut kgrid = Vec::new();
                for x in i..i + k {
                    for y in j..j + k {
                        kgrid.push(grid[x][y]);
                    }
                }
                let mut kmin = i32::MAX;
                kgrid.sort();
                for t in 1..kgrid.len() {
                    if kgrid[t] == kgrid[t - 1] {
                        continue;
                    }
                    kmin = std::cmp::min(kmin, kgrid[t] - kgrid[t - 1]);
                }
                if kmin != i32::MAX {
                    res[i][j] = kmin;
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O((m-k)\times (n-k)\times k^2\times \log k)$，其中 $m$ 和 $n$ 分别是 $grid$ 的行数和列数，$k$ 是给定整数。
- 空间复杂度：$O(k^2)$。返回值不计入空间复杂度。
