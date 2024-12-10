### [骑士在棋盘上的概率](https://leetcode.cn/problems/knight-probability-in-chessboard/solutions/1264717/qi-shi-zai-qi-pan-shang-de-gai-lu-by-lee-2qhk/)

#### 方法一：动态规划

**思路**

一个骑士有 $8$ 种可能的走法，骑士会从中以等概率随机选择一种。部分走法可能会让骑士离开棋盘，另外的走法则会让骑士移动到棋盘的其他位置，并且剩余的移动次数会减少 $1$。

定义 $dp[step][i][j]$ 表示骑士从棋盘上的点 $(i,j)$ 出发，走了 $step$ 步时仍然留在棋盘上的概率。特别地，当点 $(i,j)$ 不在棋盘上时，$dp[step][i][j]=0$；当点 $(i,j)$ 在棋盘上且 $step=0$ 时，$dp[step][i][j]=1$。对于其他情况，$dp[step][i][j]=\dfrac{1}{8} \times \sum\limits_{di,dj} dp[step-1][i+di][j+dj]$。其中 $(di,dj)$ 表示走法对坐标的偏移量，具体为 $(-2,-1),(-2,1),(2,-1),(2,1),(-1,-2),(-1,2),(1,-2),(1,2)$ 共 $8$ 种。

**代码**

```Python
class Solution:
    def knightProbability(self, n: int, k: int, row: int, column: int) -> float:
        dp = [[[0] * n for _ in range(n)] for _ in range(k + 1)]
        for step in range(k + 1):
            for i in range(n):
                for j in range(n):
                    if step == 0:
                        dp[step][i][j] = 1
                    else:
                        for di, dj in ((-2, -1), (-2, 1), (2, -1), (2, 1), (-1, -2), (-1, 2), (1, -2), (1, 2)):
                            ni, nj = i + di, j + dj
                            if 0 <= ni < n and 0 <= nj < n:
                                dp[step][i][j] += dp[step - 1][ni][nj] / 8
        return dp[k][row][column]
```

```Java
class Solution {
    static int[][] dirs = {{-2, -1}, {-2, 1}, {2, -1}, {2, 1}, {-1, -2}, {-1, 2}, {1, -2}, {1, 2}};

    public double knightProbability(int n, int k, int row, int column) {
        double[][][] dp = new double[k + 1][n][n];
        for (int step = 0; step <= k; step++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (step == 0) {
                        dp[step][i][j] = 1;
                    } else {
                        for (int[] dir : dirs) {
                            int ni = i + dir[0], nj = j + dir[1];
                            if (ni >= 0 && ni < n && nj >= 0 && nj < n) {
                                dp[step][i][j] += dp[step - 1][ni][nj] / 8;
                            }
                        }
                    }
                }
            }
        }
        return dp[k][row][column];
    }
}
```

```CSharp
public class Solution {
    static int[][] dirs = {new int[]{-2, -1}, new int[]{-2, 1}, new int[]{2, -1}, new int[]{2, 1}, new int[]{-1, -2}, new int[]{-1, 2}, new int[]{1, -2}, new int[]{1, 2}};

    public double KnightProbability(int n, int k, int row, int column) {
        double[,,] dp = new double[k + 1, n, n];
        for (int step = 0; step <= k; step++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (step == 0) {
                        dp[step, i, j] = 1;
                    } else {
                        foreach (int[] dir in dirs) {
                            int ni = i + dir[0], nj = j + dir[1];
                            if (ni >= 0 && ni < n && nj >= 0 && nj < n) {
                                dp[step, i, j] += dp[step - 1, ni, nj] / 8;
                            }
                        }
                    }
                }
            }
        }
        return dp[k, row, column];
    }
}
```

```C++
class Solution {
public:
    vector<vector<int>> dirs = {{-2, -1}, {-2, 1}, {2, -1}, {2, 1}, {-1, -2}, {-1, 2}, {1, -2}, {1, 2}};

    double knightProbability(int n, int k, int row, int column) {
        vector<vector<vector<double>>> dp(k + 1, vector<vector<double>>(n, vector<double>(n)));
        for (int step = 0; step <= k; step++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (step == 0) {
                        dp[step][i][j] = 1;
                    } else {
                        for (auto & dir : dirs) {
                            int ni = i + dir[0], nj = j + dir[1];
                            if (ni >= 0 && ni < n && nj >= 0 && nj < n) {
                                dp[step][i][j] += dp[step - 1][ni][nj] / 8;
                            }
                        }
                    }
                }
            }
        }
        return dp[k][row][column];
    }
};
```

```C
static int dirs[8][2]  = {{-2, -1}, {-2, 1}, {2, -1}, {2, 1}, {-1, -2}, {-1, 2}, {1, -2}, {1, 2}};

double knightProbability(int n, int k, int row, int column){
    double dp[200][30][30];
    memset(dp, 0, sizeof(dp));
    for (int step = 0; step <= k; step++) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (step == 0) {
                    dp[step][i][j] = 1.0;
                } else {
                    for (int k = 0; k < 8; k++) {
                        int ni = i + dirs[k][0], nj = j + dirs[k][1];
                        if (ni >= 0 && ni < n && nj >= 0 && nj < n) {
                            dp[step][i][j] += dp[step - 1][ni][nj] / 8;
                        }
                    }
                }
            }
        }
    }
    return dp[k][row][column];
}
```

```Go
var dirs = []struct{ i, j int }{{-2, -1}, {-2, 1}, {2, -1}, {2, 1}, {-1, -2}, {-1, 2}, {1, -2}, {1, 2}}

func knightProbability(n, k, row, column int) float64 {
    dp := make([][][]float64, k+1)
    for step := range dp {
        dp[step] = make([][]float64, n)
        for i := 0; i < n; i++ {
            dp[step][i] = make([]float64, n)
            for j := 0; j < n; j++ {
                if step == 0 {
                    dp[step][i][j] = 1
                } else {
                    for _, d := range dirs {
                        if x, y := i+d.i, j+d.j; 0 <= x && x < n && 0 <= y && y < n {
                            dp[step][i][j] += dp[step-1][x][y] / 8
                        }
                    }
                }
            }
        }
    }
    return dp[k][row][column]
}
```

```JavaScript
const dirs = [[-2, -1], [-2, 1], [2, -1], [2, 1], [-1, -2], [-1, 2], [1, -2], [1, 2]];
var knightProbability = function(n, k, row, column) {
    const dp = new Array(k + 1).fill(0).map(() => new Array(n).fill(0).map(() => new Array(n).fill(0)));
    for (let step = 0; step <= k; step++) {
        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                if (step === 0) {
                    dp[step][i][j] = 1;
                } else {
                    for (const dir of dirs) {
                        const ni = i + dir[0], nj = j + dir[1];
                        if (ni >= 0 && ni < n && nj >= 0 && nj < n) {
                            dp[step][i][j] += dp[step - 1][ni][nj] / 8;
                        }
                    }
                }
            }
        }
    }
    return dp[k][row][column];
};
```

```TypeScript
const dirs: number[][] = [[-2, -1], [-2, 1], [2, -1], [2, 1], [-1, -2], [-1, 2], [1, -2], [1, 2]];

function knightProbability(n: number, k: number, row: number, column: number): number {
    const dp: number[][][] = new Array(k + 1).fill(0).map(() => new Array(n).fill(0).map(() => new Array(n).fill(0)));
    for (let step = 0; step <= k; step++) {
        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                if (step === 0) {
                    dp[step][i][j] = 1;
                } else {
                    for (const dir of dirs) {
                        const ni = i + dir[0], nj = j + dir[1];
                        if (ni >= 0 && ni < n && nj >= 0 && nj < n) {
                            dp[step][i][j] += dp[step - 1][ni][nj] / 8;
                        }
                    }
                }
            }
        }
    }
    return dp[k][row][column];
};
```

```Rust
const DIRS: [[i32; 2]; 8] = [[-2, -1], [-2, 1], [2, -1], [2, 1], [-1, -2], [-1, 2], [1, -2], [1, 2]];

impl Solution {
    pub fn knight_probability(n: i32, k: i32, row: i32, column: i32) -> f64 {
        let n = n as usize;
        let k = k as usize;
        let mut dp = vec![vec![vec![0.0; n]; n]; k + 1];

        for step in 0..= k {
            for i in 0..n {
                for j in 0..n {
                    if step == 0 {
                        dp[step][i][j] = 1.0;
                    } else {
                        for dir in &DIRS {
                            let ni = i as i32 + dir[0];
                            let nj = j as i32 + dir[1];
                            if ni >= 0 && ni < n as i32 && nj >= 0 && nj < n as i32 {
                                dp[step][i][j] += dp[step - 1][ni as usize][nj as usize] / 8.0;
                            }
                        }
                    }
                }
            }
        }

        dp[k][row as usize][column as usize]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(k \times n^2)$。状态数一共有 $O(k \times n^2)$，每次转移需要考虑 $8$ 种可能的走法，消耗 $O(1)$ 的时间复杂度，总体的时间复杂度是 $O(k \times n^2)$。
- 空间复杂度：$O(k \times n^2)$。状态数一共有 $O(k \times n^2)$，用一个数组来保存。注意到每一步的状态只由前一步决定，空间复杂度可以优化到 $O(n^2)$。
