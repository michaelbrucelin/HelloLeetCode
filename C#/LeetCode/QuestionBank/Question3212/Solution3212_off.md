### [统计 X 和 Y 频数相等的子矩阵数量](https://leetcode.cn/problems/count-submatrices-with-equal-frequency-of-x-and-y/solutions/3926908/tong-ji-x-he-y-pin-shu-xiang-deng-de-zi-77zcu/)

#### 方法一：二维前缀和

**思路及解法**

我们可以顺着题目的条件来寻找子矩阵：

首先是包含 $grid[0][0]$，根据这个条件，我们已经知道了子矩阵的左上角，只需要确定右下角的元素便可确定一个子矩阵。

其次是 $X$ 与 $Y$ 的频数要相等，那么可以根据 $X$ 和 $Y$ 的频数来计数，出现一个 $X$ 计数加一，出现一个 $Y$ 计数减一，出现一个 $.$ 则保持计数不变。那么只需要判断一个子矩阵的总计数是否为 $0$ 即可判断 $X$ 与 $Y$ 的频数是否相等，这里的计数可以通过二维前缀和来统计。

最后这个子矩阵中至少要包含一个 $X$ 才能计算在答案内，因此在进行二维前缀和处理时可以在前缀和矩阵中多开辟一个维度来判断以 $(i,j)$ 为右下角的子矩阵中是否包含 $X$。判断方式如下：

1. 当 $grid[i][j]=X$ 时，这个以 $(i,j)$ 为右下角的子矩阵必定包含 $X$。
2. 当 $grid[i][j]\ne X$ 时，这个以 $(i,j)$ 为右下角的子矩阵是否包含 $X$ 可以通过以 $(i-1,j)$ 为右下角的子矩阵以及以 $(i,j-1)$ 为右下角的子矩阵中是否存在 $X$ 来判断，这两个子矩阵中的任意一个存在 $X$ 即可判断当前子矩阵中存在 $X$。

当然，我们还可以通过构建两个前缀和矩阵来分别统计并比较子矩阵中 $X$ 以及 $Y$ 的数量，此处不再赘述。

**代码**

```C++
class Solution {
public:
    int numberOfSubmatrices(vector<vector<char>>& grid) {
        int n = grid.size(), m = grid[0].size();
        int ans = 0;
        vector<vector<array<int, 2>>> sum(n + 1, vector<array<int, 2>>(m + 1));
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 'X') {
                    sum[i + 1][j + 1][0] =
                        sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] + 1;
                    sum[i + 1][j + 1][1] = 1;
                } else if (grid[i][j] == 'Y') {
                    sum[i + 1][j + 1][0] =
                        sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] - 1;
                    sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1];
                } else {
                    sum[i + 1][j + 1][0] =
                        sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0];
                    sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1];
                }
                ans += (!sum[i + 1][j + 1][0] && sum[i + 1][j + 1][1]) ? 1 : 0;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int numberOfSubmatrices(char[][] grid) {
        int n = grid.length, m = grid[0].length;
        int ans = 0;
        int[][][] sum = new int[n + 1][m + 1][2];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 'X') {
                    sum[i + 1][j + 1][0] =
                        sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] + 1;
                    sum[i + 1][j + 1][1] = 1;
                } else if (grid[i][j] == 'Y') {
                    sum[i + 1][j + 1][0] =
                        sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] - 1;
                    sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1];
                } else {
                    sum[i + 1][j + 1][0] =
                        sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0];
                    sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1];
                }
                ans += (sum[i + 1][j + 1][0] == 0 && sum[i + 1][j + 1][1] == 1) ? 1 : 0;
            }
        }
        return ans;
    }
}
```

```JavaScript
var numberOfSubmatrices = function(grid) {
    const n = grid.length, m = grid[0].length;
    let ans = 0;
    const sum = new Array(n + 1).fill(0).map(() =>
        new Array(m + 1).fill(0).map(() => [0, 0])
    );

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            if (grid[i][j] === 'X') {
                sum[i + 1][j + 1][0] =
                    sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] + 1;
                sum[i + 1][j + 1][1] = 1;
            } else if (grid[i][j] === 'Y') {
                sum[i + 1][j + 1][0] =
                    sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] - 1;
                sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1];
            } else {
                sum[i + 1][j + 1][0] =
                    sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0];
                sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1];
            }
            if (sum[i + 1][j + 1][0] === 0 && sum[i + 1][j + 1][1] === 1) {
                ans++;
            }
        }
    }
    return ans;
};
```

```Python
class Solution:
    def numberOfSubmatrices(self, grid: List[List[str]]) -> int:
        n, m = len(grid), len(grid[0])
        ans = 0
        sum = [[[0, 0] for _ in range(m + 1)] for _ in range(n + 1)]

        for i in range(n):
            for j in range(m):
                if grid[i][j] == 'X':
                    sum[i + 1][j + 1][0] = (
                        sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] + 1
                    )
                    sum[i + 1][j + 1][1] = 1
                elif grid[i][j] == 'Y':
                    sum[i + 1][j + 1][0] = (
                        sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] - 1
                    )
                    sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1]
                else:
                    sum[i + 1][j + 1][0] = (
                        sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0]
                    )
                    sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1]
                if sum[i + 1][j + 1][0] == 0 and sum[i + 1][j + 1][1] == 1:
                    ans += 1

        return ans
```

```CSharp
public class Solution {
    public int NumberOfSubmatrices(char[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        int ans = 0;
        int[,,] sum = new int[n + 1, m + 1, 2];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 'X') {
                    sum[i + 1, j + 1, 0] =
                        sum[i + 1, j, 0] + sum[i, j + 1, 0] - sum[i, j, 0] + 1;
                    sum[i + 1, j + 1, 1] = 1;
                } else if (grid[i][j] == 'Y') {
                    sum[i + 1, j + 1, 0] =
                        sum[i + 1, j, 0] + sum[i, j + 1, 0] - sum[i, j, 0] - 1;
                    sum[i + 1, j + 1, 1] = (sum[i + 1, j, 1] | sum[i, j + 1, 1]) == 1 ? 1 : 0;
                } else {
                    sum[i + 1, j + 1, 0] =
                        sum[i + 1, j, 0] + sum[i, j + 1, 0] - sum[i, j, 0];
                    sum[i + 1, j + 1, 1] = (sum[i + 1, j, 1] | sum[i, j + 1, 1]) == 1 ? 1 : 0;
                }

                if (sum[i + 1, j + 1, 0] == 0 && sum[i + 1, j + 1, 1] == 1) {
                    ans++;
                }
            }
        }
        return ans;
    }
}
```

```Go
func numberOfSubmatrices(grid [][]byte) int {
    n := len(grid)
    m := len(grid[0])
    ans := 0

    sum := make([][][]int, n+1)
    for i := range sum {
        sum[i] = make([][]int, m+1)
        for j := range sum[i] {
            sum[i][j] = make([]int, 2)
        }
    }

    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            if grid[i][j] == 'X' {
                sum[i+1][j+1][0] = sum[i+1][j][0] + sum[i][j+1][0] - sum[i][j][0] + 1
                sum[i+1][j+1][1] = 1
            } else if grid[i][j] == 'Y' {
                sum[i+1][j+1][0] = sum[i+1][j][0] + sum[i][j+1][0] - sum[i][j][0] - 1
                if sum[i+1][j][1] == 1 || sum[i][j+1][1] == 1 {
                    sum[i+1][j+1][1] = 1
                } else {
                    sum[i+1][j+1][1] = 0
                }
            } else {
                sum[i+1][j+1][0] = sum[i+1][j][0] + sum[i][j+1][0] - sum[i][j][0]
                if sum[i+1][j][1] == 1 || sum[i][j+1][1] == 1 {
                    sum[i+1][j+1][1] = 1
                } else {
                    sum[i+1][j+1][1] = 0
                }
            }

            if sum[i+1][j+1][0] == 0 && sum[i+1][j+1][1] == 1 {
                ans++
            }
        }
    }
    return ans
}
```

```C
int numberOfSubmatrices(char** grid, int gridSize, int* gridColSize) {
    int n = gridSize, m = gridColSize[0];
    int ans = 0;
    int sum[n + 1][m + 1][2];

    memset(sum, 0, sizeof(sum));

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            if (grid[i][j] == 'X') {
                sum[i + 1][j + 1][0] =
                    sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] + 1;
                sum[i + 1][j + 1][1] = 1;
            } else if (grid[i][j] == 'Y') {
                sum[i + 1][j + 1][0] =
                    sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] - 1;
                sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1];
            } else {
                sum[i + 1][j + 1][0] =
                    sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0];
                sum[i + 1][j + 1][1] = sum[i + 1][j][1] | sum[i][j + 1][1];
            }
            if (sum[i + 1][j + 1][0] == 0 && sum[i + 1][j + 1][1] == 1) {
                ans++;
            }
        }
    }
    return ans;
}
```

```TypeScript
function numberOfSubmatrices(grid: string[][]): number {
    const n = grid.length;
    const m = grid[0].length;
    let ans = 0;

    const sum: number[][][] = Array(n + 1).fill(null)
        .map(() => Array(m + 1).fill(null)
            .map(() => [0, 0]));

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            if (grid[i][j] === 'X') {
                sum[i + 1][j + 1][0] =
                    sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] + 1;
                sum[i + 1][j + 1][1] = 1;
            } else if (grid[i][j] === 'Y') {
                sum[i + 1][j + 1][0] =
                    sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] - 1;
                sum[i + 1][j + 1][1] = (sum[i + 1][j][1] | sum[i][j + 1][1]) ? 1 : 0;
            } else {
                sum[i + 1][j + 1][0] =
                    sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0];
                sum[i + 1][j + 1][1] = (sum[i + 1][j][1] | sum[i][j + 1][1]) ? 1 : 0;
            }

            if (sum[i + 1][j + 1][0] === 0 && sum[i + 1][j + 1][1] === 1) {
                ans++;
            }
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn number_of_submatrices(grid: Vec<Vec<char>>) -> i32 {
        let n = grid.len();
        let m = grid[0].len();
        let mut ans = 0;
        let mut sum = vec![vec![vec![0; 2]; m + 1]; n + 1];

        for i in 0..n {
            for j in 0..m {
                match grid[i][j] {
                    'X' => {
                        sum[i + 1][j + 1][0] =
                            sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] + 1;
                        sum[i + 1][j + 1][1] = 1;
                    },
                    'Y' => {
                        sum[i + 1][j + 1][0] =
                            sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0] - 1;
                        sum[i + 1][j + 1][1] =
                            if sum[i + 1][j][1] == 1 || sum[i][j + 1][1] == 1 { 1 } else { 0 };
                    },
                    _ => {
                        sum[i + 1][j + 1][0] =
                            sum[i + 1][j][0] + sum[i][j + 1][0] - sum[i][j][0];
                        sum[i + 1][j + 1][1] =
                            if sum[i + 1][j][1] == 1 || sum[i][j + 1][1] == 1 { 1 } else { 0 };
                    }
                }

                if sum[i + 1][j + 1][0] == 0 && sum[i + 1][j + 1][1] == 1 {
                    ans += 1;
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中 $n$ 是 $grid$ 的行数，$m$ 是 $grid$ 的列数。
- 空间复杂度：$O(nm)$，构建了一个大小为 $n\times m$ 的前缀和矩阵 $sum$。
