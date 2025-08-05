### [矩阵中的最大得分](https://leetcode.cn/problems/maximum-difference-score-in-a-grid/solutions/2877233/ju-zhen-zhong-de-zui-da-de-fen-by-leetco-c5tv/)

#### 方法一：动态规划

**思路与算法**

记 $f(i,j)$ 表示以矩阵 $grid$ 中位置 $(i,j)$ 结束的最大得分。由于每一步只能往右走或者往下走，因此在进行状态转移时，我们分别枚举这两种情况：

对于往右走，我们有：

$$ f(i,j)=\max\limits_{0\le k<j}\{max\{f(i,k),0\}+(grid(i,j)-grid(i,k))\}$$

这里的 $max{f(i,k),0}$ 是由于题目要求「必须至少移动一次」，所以 $f(i,k)$ 中并不包含「以 $(i,k)$ 同时为起点和终点」的情况，需要增加 $0$ 来表示这一情况，才能让状态转移中包含「以 $(i,k)$ 为起点，$(i,j)$ 为终点」的情况。

就算不考虑往右走的情况，上述状态转移方程的时间复杂度也达到了 $O(mn)\times O(n)=O(mn^2)$，会超出时间限制，因此需要进行优化。

注意到 $grid(i,j)$ 与 $k$ 无关，我们可以将其从 $max$ 中提出：

$$f(i,j)=grid(i,j)+\max\limits_{0\le k<j}\{max\{f(i,k),0\}-grid(i,k)\}$$

记 $prerow(i,j)=max_{0\le k\le j}\{max{f(i,k),0}-grid(i,k)\}$，那么可以使用前缀和的思想，在计算完 $f(i,j)$ 后用 $O(1)$ 的时间得到它的值：

$$\begin{cases}prerow(i,0)=max\{f(i,0),0\}-grid(i,0) \\ prerow(i,j)=max\{prerow(i,j-1),max\{f(i,j),0\}-grid(i,j)\}\end{cases}$$

此时状态转移方程变为简单的递推：

$$f(i,j)=grid(i,j)+prerow(i,j-1)$$

同理，对于往左走，我们有：

$$f(i,j)=grid(i,j)+precol(i-1,j)$$

这里 $precol(i,j)$ 是与 $prerow(i,j)$ 类似的列的前缀最大值。当所有的 $f(i,j)$ 都计算完成后，其中的最大值即为最终的答案。

```C++
class Solution {
public:
    int maxScore(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> prerow(m, vector<int>(n));
        vector<vector<int>> precol(m, vector<int>(n));
        vector<vector<int>> f(m, vector<int>(n, INT_MIN));
        int ans = INT_MIN;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i > 0) {
                    f[i][j] = max(f[i][j], grid[i][j] + precol[i - 1][j]);
                }
                if (j > 0) {
                    f[i][j] = max(f[i][j], grid[i][j] + prerow[i][j - 1]);
                }
                ans = max(ans, f[i][j]);
                prerow[i][j] = precol[i][j] = max(f[i][j], 0) - grid[i][j];
                if (i > 0) {
                    precol[i][j] = max(precol[i][j], precol[i - 1][j]);
                }
                if (j > 0) {
                    prerow[i][j] = max(prerow[i][j], prerow[i][j - 1]);
                }
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maxScore(List<List<Integer>> grid) {
        int m = grid.size(), n = grid.get(0).size();
        int[][] prerow = new int[m][n];
        int[][] precol = new int[m][n];
        int[][] f = new int[m][n];
        for (int i = 0; i < m; ++i) {
            Arrays.fill(f[i], Integer.MIN_VALUE);
        }
        int ans = Integer.MIN_VALUE;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i > 0) {
                    f[i][j] = Math.max(f[i][j], grid.get(i).get(j) + precol[i - 1][j]);
                }
                if (j > 0) {
                    f[i][j] = Math.max(f[i][j], grid.get(i).get(j) + prerow[i][j - 1]);
                }
                ans = Math.max(ans, f[i][j]);
                prerow[i][j] = precol[i][j] = Math.max(f[i][j], 0) - grid.get(i).get(j);
                if (i > 0) {
                    precol[i][j] = Math.max(precol[i][j], precol[i - 1][j]);
                }
                if (j > 0) {
                    prerow[i][j] = Math.max(prerow[i][j], prerow[i][j - 1]);
                }
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxScore(IList<IList<int>> grid) {
        int m = grid.Count, n = grid[0].Count;
        int[][] prerow = new int[m][];
        int[][] precol = new int[m][];
        int[][] f = new int[m][];
        for (int i = 0; i < m; ++i) {
            prerow[i] = new int[n];
            precol[i] = new int[n];
            f[i] = new int[n];
            Array.Fill(f[i], int.MinValue);
        }
        int ans = int.MinValue;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i > 0) {
                    f[i][j] = Math.Max(f[i][j], grid[i][j] + precol[i - 1][j]);
                }
                if (j > 0) {
                    f[i][j] = Math.Max(f[i][j], grid[i][j] + prerow[i][j - 1]);
                }
                ans = Math.Max(ans, f[i][j]);
                prerow[i][j] = precol[i][j] = Math.Max(f[i][j], 0) - grid[i][j];
                if (i > 0) {
                    precol[i][j] = Math.Max(precol[i][j], precol[i - 1][j]);
                }
                if (j > 0) {
                    prerow[i][j] = Math.Max(prerow[i][j], prerow[i][j - 1]);
                }
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def maxScore(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        prerow = [[0] * n for _ in range(m)]
        precol = [[0] * n for _ in range(m)]
        f = [[-inf] * n for _ in range(m)]
        ans = -inf

        for i in range(m):
            for j in range(n):
                if i > 0:
                    f[i][j] = max(f[i][j], grid[i][j] + precol[i - 1][j])
                if j > 0:
                    f[i][j] = max(f[i][j], grid[i][j] + prerow[i][j - 1])
                ans = max(ans, f[i][j])
                prerow[i][j] = precol[i][j] = max(f[i][j], 0) - grid[i][j]
                if i > 0:
                    precol[i][j] = max(precol[i][j], precol[i - 1][j])
                if j > 0:
                    prerow[i][j] = max(prerow[i][j], prerow[i][j - 1])
        
        return ans
```

```Go
func maxScore(grid [][]int) int {
    m := len(grid)
    n := len(grid[0])
    prerow := make([][]int, m)
    precol := make([][]int, m)
    f := make([][]int, m)

    for i := range prerow {
        prerow[i] = make([]int, n)
        precol[i] = make([]int, n)
        f[i] = make([]int, n)
        for j := range f[i] {
            f[i][j] = math.MinInt32
        }
    }

    ans := math.MinInt32
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if i > 0 {
                f[i][j] = max(f[i][j], grid[i][j] + precol[i - 1][j])
            }
            if j > 0 {
                f[i][j] = max(f[i][j], grid[i][j] + prerow[i][j - 1])
            }
            ans = max(ans, f[i][j])
            prerow[i][j] = max(f[i][j], 0) - grid[i][j]
            precol[i][j] = prerow[i][j]
            if i > 0 {
                precol[i][j] = max(precol[i][j], precol[i - 1][j])
            }
            if j > 0 {
                prerow[i][j] = max(prerow[i][j], prerow[i][j - 1])
            }
        }
    }
    return ans
}   
```

```C
int maxScore(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int prerow[m][n];
    int precol[m][n];
    int f[m][n];
    int ans = INT_MIN;

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            prerow[i][j] = 0;
            precol[i][j] = 0;
            f[i][j] = INT_MIN;
        }
    }

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (i > 0) {
                f[i][j] = fmax(f[i][j], grid[i][j] + precol[i - 1][j]);
            }
            if (j > 0) {
                f[i][j] = fmax(f[i][j], grid[i][j] + prerow[i][j - 1]);
            }
            ans = fmax(ans, f[i][j]);
            prerow[i][j] = precol[i][j] = fmax(f[i][j], 0) - grid[i][j];
            if (i > 0) {
                precol[i][j] = fmax(precol[i][j], precol[i - 1][j]);
            }
            if (j > 0) {
                prerow[i][j] = fmax(prerow[i][j], prerow[i][j - 1]);
            }
        }
    }

    return ans;
}
```

```JavaScript
var maxScore = function(grid) {
    const m = grid.length;
    const n = grid[0].length;
    const prerow = Array.from({ length: m }, () => Array(n).fill(0));
    const precol = Array.from({ length: m }, () => Array(n).fill(0));
    const f = Array.from({ length: m }, () => Array(n).fill(Number.MIN_SAFE_INTEGER));
    let ans = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i > 0) {
                f[i][j] = Math.max(f[i][j], grid[i][j] + precol[i - 1][j]);
            }
            if (j > 0) {
                f[i][j] = Math.max(f[i][j], grid[i][j] + prerow[i][j - 1]);
            }
            ans = Math.max(ans, f[i][j]);
            prerow[i][j] = precol[i][j] = Math.max(f[i][j], 0) - grid[i][j];
            if (i > 0) {
                precol[i][j] = Math.max(precol[i][j], precol[i - 1][j]);
            }
            if (j > 0) {
                prerow[i][j] = Math.max(prerow[i][j], prerow[i][j - 1]);
            }
        }
    }

    return ans;
};
```

```TypeScript
function maxScore(grid: number[][]): number {
    const m = grid.length;
    const n = grid[0].length;
    const prerow: number[][] = Array.from({ length: m }, () => Array(n).fill(0));
    const precol: number[][] = Array.from({ length: m }, () => Array(n).fill(0));
    const f: number[][] = Array.from({ length: m }, () => Array(n).fill(Number.MIN_SAFE_INTEGER));
    let ans: number = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i > 0) {
                f[i][j] = Math.max(f[i][j], grid[i][j] + precol[i - 1][j]);
            }
            if (j > 0) {
                f[i][j] = Math.max(f[i][j], grid[i][j] + prerow[i][j - 1]);
            }
            ans = Math.max(ans, f[i][j]);
            prerow[i][j] = precol[i][j] = Math.max(f[i][j], 0) - grid[i][j];
            if (i > 0) {
                precol[i][j] = Math.max(precol[i][j], precol[i - 1][j]);
            }
            if (j > 0) {
                prerow[i][j] = Math.max(prerow[i][j], prerow[i][j - 1]);
            }
        }
    }

    return ans;
};
```

```Rust
function maxScore(grid: number[][]): number {
    const m = grid.length;
    const n = grid[0].length;
    const prerow: number[][] = Array.from({ length: m }, () => Array(n).fill(0));
    const precol: number[][] = Array.from({ length: m }, () => Array(n).fill(0));
    const f: number[][] = Array.from({ length: m }, () => Array(n).fill(Number.MIN_SAFE_INTEGER));
    let ans: number = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i > 0) {
                f[i][j] = Math.max(f[i][j], grid[i][j] + precol[i - 1][j]);
            }
            if (j > 0) {
                f[i][j] = Math.max(f[i][j], grid[i][j] + prerow[i][j - 1]);
            }
            ans = Math.max(ans, f[i][j]);
            prerow[i][j] = precol[i][j] = Math.max(f[i][j], 0) - grid[i][j];
            if (i > 0) {
                precol[i][j] = Math.max(precol[i][j], precol[i - 1][j]);
            }
            if (j > 0) {
                prerow[i][j] = Math.max(prerow[i][j], prerow[i][j - 1]);
            }
        }
    }

    return ans;
};
```

上述代码的空间复杂度为 $O(mn)$，其中有很多地方可以进行优化：

- $f(i,j)$ 本身不需要存储，我们只关心其中的最大值；
- $prerow(i,j)$ 的状态转移只与 $prerow(i,j-1)$ 有关，且 $prerow(i,j-1)$ 之后不会再用到，它的作用范围仅为第 $i$ 行，因此可以直接使用一个普通变量代替整个二维数组；
- $precol(i,j)$ 的状态转移只与 $precol(i-1,j)$ 有关，且 $precol(i-1,j)$ 之后不会再用到，它的作用范围仅为第 $i$ 行，因此可以使用一个长度为 $n$ 的一维数组代替整个二维数组。

```C++
class Solution {
public:
    int maxScore(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<int> precol(n, INT_MIN);
        int ans = INT_MIN;
        for (int i = 0; i < m; ++i) {
            int prerow = INT_MIN;
            for (int j = 0; j < n; ++j) {
                int f = INT_MIN;
                if (i > 0) {
                    f = max(f, grid[i][j] + precol[j]);
                }
                if (j > 0) {
                    f = max(f, grid[i][j] + prerow);
                }
                ans = max(ans, f);
                precol[j] = max(precol[j], max(f, 0) - grid[i][j]);
                prerow = max(prerow, max(f, 0) - grid[i][j]);
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maxScore(List<List<Integer>> grid) {
        int m = grid.size(), n = grid.get(0).size();
        int[] precol = new int[n];
        Arrays.fill(precol, Integer.MIN_VALUE);
        int ans = Integer.MIN_VALUE;
        for (int i = 0; i < m; ++i) {
            int prerow = Integer.MIN_VALUE;
            for (int j = 0; j < n; ++j) {
                int f = Integer.MIN_VALUE;
                if (i > 0) {
                    f = Math.max(f, grid.get(i).get(j) + precol[j]);
                }
                if (j > 0) {
                    f = Math.max(f, grid.get(i).get(j) + prerow);
                }
                ans = Math.max(ans, f);
                precol[j] = Math.max(precol[j], Math.max(f, 0) - grid.get(i).get(j));
                prerow = Math.max(prerow, Math.max(f, 0) - grid.get(i).get(j));
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxScore(IList<IList<int>> grid) {
        int m = grid.Count, n = grid[0].Count;
        int[] precol = new int[n];
        Array.Fill(precol, int.MinValue);
        int ans = int.MinValue;
        for (int i = 0; i < m; ++i) {
            int prerow = int.MinValue;
            for (int j = 0; j < n; ++j) {
                int f = int.MinValue;
                if (i > 0) {
                    f = Math.Max(f, grid[i][j] + precol[j]);
                }
                if (j > 0) {
                    f = Math.Max(f, grid[i][j] + prerow);
                }
                ans = Math.Max(ans, f);
                precol[j] = Math.Max(precol[j], Math.Max(f, 0) - grid[i][j]);
                prerow = Math.Max(prerow, Math.Max(f, 0) - grid[i][j]);
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def maxScore(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        precol = [-inf] * n
        ans = -inf

        for i in range(m):
            prerow = -inf
            for j in range(n):
                f = -inf
                if i > 0:
                    f = max(f, grid[i][j] + precol[j])
                if j > 0:
                    f = max(f, grid[i][j] + prerow)
                ans = max(ans, f)
                precol[j] = max(precol[j], max(f, 0) - grid[i][j])
                prerow = max(prerow, max(f, 0) - grid[i][j])
        
        return ans
```

```Go
func maxScore(grid [][]int) int {
    m := len(grid)
    n := len(grid[0])
    precol := make([]int, n)
    for i := range precol {
        precol[i] = math.MinInt32
    }
    ans := math.MinInt32

    for i := 0; i < m; i++ {
        prerow := math.MinInt32
        for j := 0; j < n; j++ {
            f := math.MinInt32
            if i > 0 {
                f = max(f, grid[i][j]+precol[j])
            }
            if j > 0 {
                f = max(f, grid[i][j]+prerow)
            }
            ans = max(ans, f)
            precol[j] = max(precol[j], max(f, 0)-grid[i][j])
            prerow = max(prerow, max(f, 0)-grid[i][j])
        }
    }

    return ans
}
```

```C
int maxScore(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int precol[n];
    for (int i = 0; i < n; i++) {
        precol[i] = INT_MIN;
    }
    int ans = INT_MIN;

    for (int i = 0; i < m; i++) {
        int prerow = INT_MIN;
        for (int j = 0; j < n; j++) {
            int f = INT_MIN;
            if (i > 0) {
                f = fmax(f, grid[i][j] + precol[j]);
            }
            if (j > 0) {
                f = fmax(f, grid[i][j] + prerow);
            }
            ans = fmax(ans, f);
            precol[j] = fmax(precol[j], fmax(f, 0) - grid[i][j]);
            prerow = fmax(prerow, fmax(f, 0) - grid[i][j]);
        }
    }

    return ans;
}
```

```JavaScript
var maxScore = function(grid) {
     const m = grid.length;
    const n = grid[0].length;
    const precol = Array(n).fill(Number.MIN_SAFE_INTEGER);
    let ans = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < m; i++) {
        let prerow = Number.MIN_SAFE_INTEGER;
        for (let j = 0; j < n; j++) {
            let f = Number.MIN_SAFE_INTEGER;
            if (i > 0) {
                f = Math.max(f, grid[i][j] + precol[j]);
            }
            if (j > 0) {
                f = Math.max(f, grid[i][j] + prerow);
            }
            ans = Math.max(ans, f);
            precol[j] = Math.max(precol[j], Math.max(f, 0) - grid[i][j]);
            prerow = Math.max(prerow, Math.max(f, 0) - grid[i][j]);
        }
    }

    return ans;
};
```

```TypeScript
function maxScore(grid: number[][]): number {
    const m = grid.length;
    const n = grid[0].length;
    const precol: number[] = Array(n).fill(Number.MIN_SAFE_INTEGER);
    let ans: number = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < m; i++) {
        let prerow: number = Number.MIN_SAFE_INTEGER;
        for (let j = 0; j < n; j++) {
            let f: number = Number.MIN_SAFE_INTEGER;
            if (i > 0) {
                f = Math.max(f, grid[i][j] + precol[j]);
            }
            if (j > 0) {
                f = Math.max(f, grid[i][j] + prerow);
            }
            ans = Math.max(ans, f);
            precol[j] = Math.max(precol[j], Math.max(f, 0) - grid[i][j]);
            prerow = Math.max(prerow, Math.max(f, 0) - grid[i][j]);
        }
    }

    return ans;
};
```

```Rust
impl Solution {
    pub fn max_score(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        let mut precol = vec![i32::MIN; n];
        let mut ans = i32::MIN;

        for i in 0..m {
            let mut prerow = i32::MIN;
            for j in 0..n {
                let mut f = i32::MIN;
                if i > 0 {
                    f = f.max(grid[i][j] + precol[j]);
                }
                if j > 0 {
                    f = f.max(grid[i][j] + prerow);
                }
                ans = ans.max(f);
                precol[j] = precol[j].max(f.max(0) - grid[i][j]);
                prerow = prerow.max(f.max(0) - grid[i][j]);
            }
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$。
- 空间复杂度：$O(n)$，即为前缀和数组 $precol$ 需要使用的空间。

#### 方法二：二维前缀和

**思路与算法**

如果我们移动路径上的元素依次为 $x_0,x_1,\dots ,x_t$，那么最后的得分为：

$$(x_1-x_0)+(x2-x_1)+\dots +(x_t-x_{t-1})=x_t-x_0$$

实际上只与起点和终点有关，与移动路径中的元素无关。由于每一步只能往右走或者往下走，因此只要起点的二维坐标均不大于终点（不能重合），那就一定存在一条移动路径。

因此状态转移方程可以简单地写成：

$$f(i,j)=\max\limits_{\tiny{\begin{array}{c} 0<i_0\le i \\ 0<j_0\le j \\ (i_0,j_0)\ne (i,j) \end{array}}}\{grid(i,j)-grid(i_0,j_0)\}$$

同样将与 $max$ 无关的 $grid(i,j)$ 提出可以得到：

$$f(i,j)=grid(i,j)-\min\limits_{\tiny{\begin{array}{c}0<i_0\le i \\ 0<j_0\le j \\ (i_0,j_0)\ne (i,j)\end{array}}}\{grid(i_0,j_0)\}$$

此时 $min$ 中的部分就是经典的[二维前缀和](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fbasic%2Fprefix-sum%2F%3Fquery%3D%E5%89%8D%E7%BC%80%E5%92%8C%23%E4%BA%8C%E7%BB%B4%E5%A4%9A%E7%BB%B4%E5%89%8D%E7%BC%80%E5%92%8C)。

```C++
class Solution {
public:
    int maxScore(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> premin(m, vector<int>(n, INT_MAX));
        int ans = INT_MIN;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                int pre = INT_MAX;
                if (i > 0) {
                    pre = min(pre, premin[i - 1][j]);
                }
                if (j > 0) {
                    pre = min(pre, premin[i][j - 1]);
                }
                // i = j = 0 时没有转移
                if (i + j > 0) {
                    ans = max(ans, grid[i][j] - pre);
                }
                premin[i][j] = min(pre, grid[i][j]);
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maxScore(List<List<Integer>> grid) {
        int m = grid.size(), n = grid.get(0).size();
        int[][] premin = new int[m][n];
        for (int i = 0; i < m; ++i) {
            Arrays.fill(premin[i], Integer.MAX_VALUE);
        }
        int ans = Integer.MIN_VALUE;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                int pre = Integer.MAX_VALUE;
                if (i > 0) {
                    pre = Math.min(pre, premin[i - 1][j]);
                }
                if (j > 0) {
                    pre = Math.min(pre, premin[i][j - 1]);
                }
                // i = j = 0 时没有转移
                if (i + j > 0) {
                    ans = Math.max(ans, grid.get(i).get(j) - pre);
                }
                premin[i][j] = Math.min(pre, grid.get(i).get(j));
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxScore(IList<IList<int>> grid) {
        int m = grid.Count, n = grid[0].Count;
        int[][] premin = new int[m][];
        for (int i = 0; i < m; ++i) {
            premin[i] = new int[n];
            Array.Fill(premin[i], int.MaxValue);
        }
        int ans = int.MinValue;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                int pre = int.MaxValue;
                if (i > 0) {
                    pre = Math.Min(pre, premin[i - 1][j]);
                }
                if (j > 0) {
                    pre = Math.Min(pre, premin[i][j - 1]);
                }
                // i = j = 0 时没有转移
                if (i + j > 0) {
                    ans = Math.Max(ans, grid[i][j] - pre);
                }
                premin[i][j] = Math.Min(pre, grid[i][j]);
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def maxScore(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        premin = [[inf] * n for _ in range(m)]
        ans = -inf

        for i in range(m):
            for j in range(n):
                pre = inf
                if i > 0:
                    pre = min(pre, premin[i - 1][j])
                if j > 0:
                    pre = min(pre, premin[i][j - 1])
                # i = j = 0 时没有转移
                if i + j > 0:
                    ans = max(ans, grid[i][j] - pre)
                premin[i][j] = min(pre, grid[i][j])
        
        return ans
```

```Go
func maxScore(grid [][]int) int {
    m := len(grid)
    n := len(grid[0])
    premin := make([][]int, m)
    for i := range premin {
        premin[i] = make([]int, n)
        for j := range premin[i] {
            premin[i][j] = math.MaxInt32
        }
    }
    ans := math.MinInt32

    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            pre := math.MaxInt32
            if i > 0 {
                pre = min(pre, premin[i - 1][j])
            }
            if j > 0 {
                pre = min(pre, premin[i][j - 1])
            }
            // i = j = 0 时没有转移
            if i + j > 0 {
                ans = max(ans, grid[i][j] - pre)
            }
            premin[i][j] = min(pre, grid[i][j])
        }
    }
    return ans
}
```

```C
int maxScore(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int premin[m][n];
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            premin[i][j] = INT_MAX;
        }
    }
    int ans = INT_MIN;

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            int pre = INT_MAX;
            if (i > 0) {
                pre = fmin(pre, premin[i - 1][j]);
            }
            if (j > 0) {
                pre = fmin(pre, premin[i][j - 1]);
            }
            // i = j = 0 时没有转移
            if (i + j > 0) {
                ans = fmax(ans, grid[i][j] - pre);
            }
            premin[i][j] = fmin(pre, grid[i][j]);
        }
    }

    return ans;
}
```

```JavaScript
var maxScore = function(grid) {
    const m = grid.length;
    const n = grid[0].length;
    const premin = Array.from({ length: m }, () => Array(n).fill(Number.MAX_SAFE_INTEGER));
    let ans = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            let pre = Number.MAX_SAFE_INTEGER;
            if (i > 0) {
                pre = Math.min(pre, premin[i - 1][j]);
            }
            if (j > 0) {
                pre = Math.min(pre, premin[i][j - 1]);
            }
            // i = j = 0 时没有转移
            if (i + j > 0) {
                ans = Math.max(ans, grid[i][j] - pre);
            }
            premin[i][j] = Math.min(pre, grid[i][j]);
        }
    }

    return ans;
};
```

```TypeScript
function maxScore(grid: number[][]): number {
    const m = grid.length;
    const n = grid[0].length;
    const premin: number[][] = Array.from({ length: m }, () => Array(n).fill(Number.MAX_SAFE_INTEGER));
    let ans: number = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            let pre: number = Number.MAX_SAFE_INTEGER;
            if (i > 0) {
                pre = Math.min(pre, premin[i - 1][j]);
            }
            if (j > 0) {
                pre = Math.min(pre, premin[i][j - 1]);
            }
            // i = j = 0 时没有转移
            if (i + j > 0) {
                ans = Math.max(ans, grid[i][j] - pre);
            }
            premin[i][j] = Math.min(pre, grid[i][j]);
        }
    }

    return ans;
};
```

```Rust
impl Solution {
    pub fn max_score(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        let mut premin = vec![vec![i32::MAX; n]; m];
        let mut ans = i32::MIN;

        for i in 0..m {
            for j in 0..n {
                let mut pre = i32::MAX;
                if i > 0 {
                    pre = pre.min(premin[i - 1][j]);
                }
                if j > 0 {
                    pre = pre.min(premin[i][j - 1]);
                }
                // i = j = 0 时没有转移
                if i + j > 0 {
                    ans = ans.max(grid[i][j] - pre);
                }
                premin[i][j] = pre.min(grid[i][j]);
            }
        }

        ans
    }
}
```

上述代码的空间复杂度为 $O(mn)$，同样也可以进行优化。在第 $i$ 行时我们只会用到 $premin(i-1,\dots )$ 以及 $premin(i,\dots )$，因此可以使用两个一维数组代替整个二维数组。

```C++
class Solution {
public:
    int maxScore(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> premin(2, vector<int>(n, INT_MAX));
        int ans = INT_MIN;
        for (int i = 0; i < m; ++i) {
            fill(premin[i & 1].begin(), premin[i & 1].end(), INT_MAX);
            for (int j = 0; j < n; ++j) {
                int pre = INT_MAX;
                if (i > 0) {
                    pre = min(pre, premin[(i - 1) & 1][j]);
                }
                if (j > 0) {
                    pre = min(pre, premin[i & 1][j - 1]);
                }
                // i = j = 0 时没有转移
                if (i + j > 0) {
                    ans = max(ans, grid[i][j] - pre);
                }
                premin[i & 1][j] = min(pre, grid[i][j]);
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maxScore(List<List<Integer>> grid) {
        int m = grid.size(), n = grid.get(0).size();
        int[][] premin = new int[2][n];
        for (int i = 0; i < 2; ++i) {
            Arrays.fill(premin[i], Integer.MAX_VALUE);
        }
        int ans = Integer.MIN_VALUE;
        for (int i = 0; i < m; ++i) {
            Arrays.fill(premin[i & 1], Integer.MAX_VALUE);
            for (int j = 0; j < n; ++j) {
                int pre = Integer.MAX_VALUE;
                if (i > 0) {
                    pre = Math.min(pre, premin[(i - 1) & 1][j]);
                }
                if (j > 0) {
                    pre = Math.min(pre, premin[i & 1][j - 1]);
                }
                // i = j = 0 时没有转移
                if (i + j > 0) {
                    ans = Math.max(ans, grid.get(i).get(j) - pre);
                }
                premin[i & 1][j] = Math.min(pre, grid.get(i).get(j));
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxScore(IList<IList<int>> grid) {
        int m = grid.Count, n = grid[0].Count;
        int[][] premin = new int[2][];
        for (int i = 0; i < 2; ++i) {
            premin[i] = new int[n];
            Array.Fill(premin[i], int.MaxValue);
        }
        int ans = int.MinValue;
        for (int i = 0; i < m; ++i) {
            Array.Fill(premin[i & 1], int.MaxValue);
            for (int j = 0; j < n; ++j) {
                int pre = int.MaxValue;
                if (i > 0) {
                    pre = Math.Min(pre, premin[(i - 1) & 1][j]);
                }
                if (j > 0) {
                    pre = Math.Min(pre, premin[i & 1][j - 1]);
                }
                // i = j = 0 时没有转移
                if (i + j > 0) {
                    ans = Math.Max(ans, grid[i][j] - pre);
                }
                premin[i & 1][j] = Math.Min(pre, grid[i][j]);
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def maxScore(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        premin = [[inf] * n for _ in range(2)]
        ans = -inf

        for i in range(m):
            premin[i & 1] = [inf] * n
            for j in range(n):
                pre = inf
                if i > 0:
                    pre = min(pre, premin[(i - 1) & 1][j])
                if j > 0:
                    pre = min(pre, premin[i & 1][j - 1])
                # i = j = 0 时没有转移
                if i + j > 0:
                    ans = max(ans, grid[i][j] - pre)
                premin[i & 1][j] = min(pre, grid[i][j])
        
        return ans
```

```Go
func maxScore(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    premin := make([][]int, 2)
    for i := range premin {
        premin[i] = make([]int, n)
        for j := range premin[i] {
            premin[i][j] = math.MaxInt
        }
    }
    ans := math.MinInt
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            pre := math.MaxInt
            if i > 0 {
                pre = min(pre, premin[(i - 1) & 1][j])
            }
            if j > 0 {
                pre = min(pre, premin[i & 1][j - 1])
            }
            // i = j = 0 时没有转移
            if i + j > 0 {
                ans = max(ans, grid[i][j] - pre)
            }
            premin[i&1][j] = min(pre, grid[i][j])
        }
    }
    return ans
}
```

```C
int maxScore(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int premin[2][n];
    for (int i = 0; i < 2; ++i) {
        for (int j = 0; j < n; ++j) {
            premin[i][j] = INT_MAX;
        }
    }

    int ans = INT_MIN;
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
            int pre = INT_MAX;
            if (i > 0) {
                pre = fmin(pre, premin[(i - 1) & 1][j]);
            }
            if (j > 0) {
                pre = fmin(pre, premin[i & 1][j - 1]);
            }
            // i = j = 0 时没有转移
            if (i + j > 0) {
                ans = fmax(ans, grid[i][j] - pre);
            }
            premin[i & 1][j] = fmin(pre, grid[i][j]);
        }
    }
    return ans;
}
```

```JavaScript
var maxScore = function(grid) {
    const m = grid.length, n = grid[0].length;
    const premin = Array.from({ length: 2 }, () => Array(n).fill(Number.MAX_SAFE_INTEGER));

    let ans = Number.MIN_SAFE_INTEGER;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            let pre = Number.MAX_SAFE_INTEGER;
            if (i > 0) {
                pre = Math.min(pre, premin[(i-1) & 1][j]);
            }
            if (j > 0) {
                pre = Math.min(pre, premin[i & 1][j - 1]);
            }
            // i = j = 0 时没有转移
            if (i + j > 0) {
                ans = Math.max(ans, grid[i][j] - pre);
            }
            premin[i & 1][j] = Math.min(pre, grid[i][j]);
        }
    }
    return ans;
};
```

```TypeScript
function maxScore(grid: number[][]): number {
    const m = grid.length, n = grid[0].length;
    const premin = Array.from({ length: 2 }, () => Array(n).fill(Number.MAX_SAFE_INTEGER));

    let ans = Number.MIN_SAFE_INTEGER;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            let pre = Number.MAX_SAFE_INTEGER;
            if (i > 0) {
                pre = Math.min(pre, premin[(i - 1) & 1][j]);
            }
            if (j > 0) {
                pre = Math.min(pre, premin[i & 1][j - 1]);
            }
            // i = j = 0 时没有转移
            if (i + j > 0) {
                ans = Math.max(ans, grid[i][j] - pre);
            }
            premin[i & 1][j] = Math.min(pre, grid[i][j]);
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn max_score(grid: Vec<Vec<i32>>) -> i32 {
        let (m, n) = (grid.len(), grid[0].len());
        let mut premin = vec![vec![i32::MAX; n]; 2];

        let mut ans = i32::MIN;
        for i in 0..m {
            for j in 0..n {
                let mut pre = i32::MAX;
                if i > 0 {
                    pre = pre.min(premin[(i - 1) & 1][j]);
                }
                if j > 0 {
                    pre = pre.min(premin[i & 1][j - 1]);
                }
                // i = j = 0 时没有转移
                if i + j > 0 {
                    ans = ans.max(grid[i][j] - pre);
                }
                premin[i & 1][j] = pre.min(grid[i][j]);
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$。
- 空间复杂度：$O(n)$，即为前缀最小值数组 $premin$ 需要使用的空间。
