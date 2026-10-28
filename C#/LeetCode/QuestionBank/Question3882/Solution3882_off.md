### [网格图中最小异或路径](https://leetcode.cn/problems/minimum-xor-path-in-a-grid/solutions/4043905/wang-ge-tu-zhong-zui-xiao-yi-huo-lu-jing-09le/)

#### 方法一：动态规划

给定一个 $m$ 行 $n$ 列的矩阵 $grid$，我们需要在以 $(0,0)$ 为起点，以 $(m-1,n-1)$ 为终点的所有路径中，找到路径上的最小异或和。

由于每次只能向下或向右移动，到达每个格子时，异或和的可能取值仅取决于其上方和左侧的格子，具有天然的无后效性与最优子问题结构，故考虑使用动态规划求解。

观察题目限制，我们有 $m\cdot n\le 1000$ 且 $0\le grid[i][j]\le 1023$，因此我们可以直接定义状态 $dp[i][j][v]$，表示**是否存在一条从起点 $(0,0)$ 到达 $(i,j)$ 的路径，使得路径上的异或和恰好为 v**。若存在则为 $true$，否则为 $false$。其转移方程为：

$$dp[i][j][v]=dp[i-1][j][v\oplus grid[i][j]]\vee dp[i][j-1][v\oplus grid[i][j]]$$

上述转移方程用到了异或的一个性质：异或是自身的逆运算，即 $a\oplus$ b=c⟺a=c\oplus $b$，故前一个状态的异或和就是 $v\oplus grid[i][j]$。实际上，为了方便理解，我们也可以直接将 $v$ 直接看作前一个状态的异或和，从而得到如下转移方程，效果和上面的式子等价：

$$dp[i][j][v\oplus grid[i][j]]=dp[i-1][j][v]\vee dp[i][j-1][v]$$

按转移方程计算每个位置，即可得到所有以当前位置为终点的路径能得到的异或和，最后取使 $dp[m-1][n-1][v]=true$ 成立的最小的 $v$ 即为答案。

> 另注：此类动态规划题目的状态本质上是维护每个位置的候选取值集合。在具体实现时，可以根据语言特性选择布尔数组、位集或哈希集等多种数据结构实现。

**空间优化**

鉴于本题是一个经典的走格子模型，即状态只能从上方和左侧转移得到，因此基于滚动数组的思想，我们可以用 $dp[j]$ 表示当前行的状态，从上到下、从左到右遍历 $grid$：

- 计算 $(i,j)$ 时，更新前的 $dp[j]$ 恰好代表上一行的状态；
- 而更新完毕的 $dp[j-1]$ 则代表当前行左侧格子的状态。

为了区分更新前后的状态，简单的方法是使用一个临时数组存储更新后的状态，整行计算完毕后覆盖之前的 $dp$ 即可。通过这种方式，可以将空间复杂度从 $O(m\cdot n\cdot V)$ 降低至 $O(n\cdot V)$，其中 $V=1024$ 为本题异或和的最大可能取值。

**代码**

```Python
class Solution:
    def minCost(self, grid: list[list[int]]) -> int:
        m, n = len(grid), len(grid[0])

        dp = [set() for _ in range(n)]
        dp[0].add(grid[0][0])

        for i in range(m):
            for j in range(n):
                if i == 0 and j == 0:
                    continue

                value = grid[i][j]
                reachable = dp[j] | (dp[j - 1] if j > 0 else set())

                dp[j] = {k ^ value for k in reachable}

        return min(dp[-1])
```

```C++
class Solution {
public:
    int minCost(vector<vector<int>>& grid) {
        const int m = grid.size();
        const int n = grid[0].size();

        vector<array<bool, 1024>> dp(n);
        array<bool, 1024> next{};

        dp[0][grid[0][0]] = true;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 && j == 0) {
                    continue;
                }

                const int value = grid[i][j];
                next.fill(false);

                for (int k = 0; k < 1024; k++) {
                    if (dp[j][k] || (j > 0 && dp[j - 1][k])) {
                        next[k ^ value] = true;
                    }
                }

                dp[j] = next;
            }
        }

        for (int k = 0; k < 1024; k++) {
            if (dp[n - 1][k]) {
                return k;
            }
        }

        return -1;
    }
};
```

```Java
class Solution {
    public int minCost(int[][] grid) {
        int m = grid.length;
        int n = grid[0].length;

        boolean[][] dp = new boolean[n][1024];
        boolean[] next = new boolean[1024];

        dp[0][grid[0][0]] = true;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 && j == 0) {
                    continue;
                }

                int value = grid[i][j];
                Arrays.fill(next, false);

                for (int k = 0; k < 1024; k++) {
                    if (dp[j][k] || (j > 0 && dp[j - 1][k])) {
                        next[k ^ value] = true;
                    }
                }

                System.arraycopy(next, 0, dp[j], 0, 1024);
            }
        }

        for (int k = 0; k < 1024; k++) {
            if (dp[n - 1][k]) {
                return k;
            }
        }

        return -1;
    }
}
```

```CSharp
public class Solution {
    public int MinCost(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

        bool[][] dp = new bool[n][];
        for (int j = 0; j < n; j++) {
            dp[j] = new bool[1024];
        }
        bool[] next = new bool[1024];

        dp[0][grid[0][0]] = true;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 && j == 0) {
                    continue;
                }

                int value = grid[i][j];
                Array.Clear(next, 0, next.Length);

                for (int k = 0; k < 1024; k++) {
                    if (dp[j][k] || (j > 0 && dp[j - 1][k])) {
                        next[k ^ value] = true;
                    }
                }

                Array.Copy(next, dp[j], 1024);
            }
        }

        return Array.IndexOf(dp[n - 1], true);
    }
}
```

```Go
func minCost(grid [][]int) int {
	m := len(grid)
	n := len(grid[0])

	dp := make([][1024]bool, n)
	var next [1024]bool

	dp[0][grid[0][0]] = true

	for i := 0; i < m; i++ {
		for j := 0; j < n; j++ {
			if i == 0 && j == 0 {
				continue
			}

			value := grid[i][j]
			clear(next[:])

			for k := 0; k < 1024; k++ {
				if dp[j][k] || (j > 0 && dp[j-1][k]) {
					next[k^value] = true
				}
			}

			dp[j] = next
		}
	}

	for k, value := range dp[n-1] {
		if value {
			return k
		}
	}

	return -1
}
```

```C
int minCost(int **grid, int gridSize, int *gridColSize) {
    const int m = gridSize;
    const int n = gridColSize[0];

    bool (*dp)[1024] = calloc(n, sizeof(*dp));
    bool next[1024];

    dp[0][grid[0][0]] = true;

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (i == 0 && j == 0) {
                continue;
            }

            const int value = grid[i][j];
            memset(next, 0, sizeof(next));

            for (int k = 0; k < 1024; k++) {
                if (dp[j][k] || (j > 0 && dp[j - 1][k])) {
                    next[k ^ value] = true;
                }
            }

            memcpy(dp[j], next, sizeof(next));
        }
    }

    int result = -1;

    for (int k = 0; k < 1024; k++) {
        if (dp[n - 1][k]) {
            result = k;
            break;
        }
    }

    free(dp);
    return result;
}
```

```JavaScript
var minCost = function(grid) {
    const m = grid.length;
    const n = grid[0].length;

    const dp = Array.from({ length: n }, () => new Uint8Array(1024));
    const next = new Uint8Array(1024);

    dp[0][grid[0][0]] = 1;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i === 0 && j === 0) {
                continue;
            }

            const value = grid[i][j];
            next.fill(0);

            for (let k = 0; k < 1024; k++) {
                if (dp[j][k] || (j > 0 && dp[j - 1][k])) {
                    next[k ^ value] = 1;
                }
            }

            dp[j].set(next);
        }
    }

    return dp[n - 1].indexOf(1);
};
```

```TypeScript
function minCost(grid: number[][]): number {
    const m = grid.length;
    const n = grid[0].length;

    const dp = Array.from({ length: n }, () => new Uint8Array(1024));
    const next = new Uint8Array(1024);

    dp[0][grid[0][0]] = 1;

    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (i === 0 && j === 0) {
                continue;
            }

            const value = grid[i][j];
            next.fill(0);

            for (let k = 0; k < 1024; k++) {
                if (dp[j][k] === 1 || (j > 0 && dp[j - 1][k])) {
                    next[k ^ value] = 1;
                }
            }

            dp[j].set(next);
        }
    }

    return dp[n - 1].findIndex(v => v === 1);
}
```

```Rust
impl Solution {
    pub fn min_cost(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();

        let mut dp = vec![[false; 1024]; n];
        let mut next = [false; 1024];

        dp[0][grid[0][0] as usize] = true;

        for i in 0..m {
            for j in 0..n {
                if i == 0 && j == 0 {
                    continue;
                }

                let value = grid[i][j] as usize;
                next.fill(false);

                for k in 0..1024 {
                    if dp[j][k] || (j > 0 && dp[j - 1][k]) {
                        next[k ^ value] = true;
                    }
                }

                dp[j] = next;
            }
        }

        dp[n - 1]
            .iter()
            .position(|&value| value)
            .map_or(-1, |index| index as i32)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m\cdot n\cdot V)$，其中 $grid$ 的行数为 $m$，列数为 $n$，路径上的异或和上限为 $V$。动态规划外层双重循环遍历需要 $O(m\times n)$，对于每个格子，遍历异或和的可能 $V$ 种取值，状态转移需要 $O(V)$。
- 空间复杂度：$O(n\cdot V)$，状态数量为 $O(m\cdot n\cdot V)$，使用滚动数组优化后，状态数组 $dp$ 仅需维护一行的状态，需要 $O(n\cdot V)$ 的空间。
