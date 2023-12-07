### [网格中的最小路径代价](https://leetcode.cn/problems/minimum-path-cost-in-a-grid/solutions/2529083/wang-ge-zhong-de-zui-xiao-lu-jing-dai-ji-qqqf/)

#### 方法一：记忆化搜索

> 为了方便描述，我们将 $grid[0]$ 记为第 $0$ 行。

记 $grid$ 的行数为$m$，列数为 $n$。函数值 $dfs(i, j)$ 为从第 $0$ 行的任意单元格出发，到达第 $i$ 行 $j$ 列的单元格的最小路径代价。当 $i \gt 0$ 时，可以从第 $i-1$ 行的任一单元格移动单元格 $(i, j)$，因此转移关系为：

$$dfs(i, j) = \begin{cases} grid[i][j] & i = 0 \\ \min_{k = 0}^{n - 1} \{ dfs(i - 1, k) + moveCost[grid[i - 1][k]][j] + grid[i][j] \} & i \gt 0 \end{cases}$$

我们枚举最后一行的所有单元格 $(m - 1, j)$，对 $(m - 1, j)$ 进行深度优先搜索，得到 $dfs(m - 1, j)$，取其中的最小值。

> 深度优先搜索的过程中，会重复计算 $dfs(i, j)$ 的值，我们可以使用 $memo[i][j]$ 记录 $dfs(i, j)$ 的值，避免重复计算。

```cpp
class Solution {
public:
    int minPathCost(vector<vector<int>>& grid, vector<vector<int>>& moveCost) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> memo(m, vector<int>(n, -1));
        function<int(int, int)> dfs = [&](int i, int j) -> int {
            if (i == 0) {
                return grid[i][j];
            }
            if (memo[i][j] >= 0) {
                return memo[i][j];
            }
            int res = INT_MAX;
            for (int k = 0; k < n; k++) {
                res = min(res, dfs(i - 1, k) + moveCost[grid[i - 1][k]][j] + grid[i][j]);
            }
            memo[i][j] = res;
            return res;
        };
        int res = INT_MAX;
        for (int j = 0; j < n; j++) {
            res = min(res, dfs(m - 1, j));
        }
        return res;
    }
};
```

```java
class Solution {
    public int[][] memo;
    public int dfs(int i, int j, int[][] grid, int[][] moveCost) {
        if (i == 0) {
            return grid[i][j];
        }
        if (memo[i][j] >= 0) {
            return memo[i][j];
        }
        int res = Integer.MAX_VALUE;
        for (int k = 0; k < grid[0].length; k++) {
            res = Math.min(res, dfs(i - 1, k, grid, moveCost) + moveCost[grid[i - 1][k]][j] + grid[i][j]);
        }
        memo[i][j] = res;
        return res;
    }

    public int minPathCost(int[][] grid, int[][] moveCost) {
        int m = grid.length, n = grid[0].length;
        memo = new int[m][n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                memo[i][j] = -1;
            }
        }
        int res = Integer.MAX_VALUE;
        for (int j = 0; j < n; j++) {
            res = Math.min(res, dfs(m - 1, j, grid, moveCost));
        }
        return res;
    }
}
```

```go
func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}

const Inf = 0x3f3f3f3f

func minPathCost(grid [][]int, moveCost [][]int) int {
    m, n := len(grid), len(grid[0])
    memo := make([][]int, m)
    for i := 0; i < m; i++ {
        memo[i] = make([]int, n)
        for j := 0; j < n; j++ {
            memo[i][j] = -1
        }
    }
    var dfs func(int, int)int
    dfs = func(i, j int) int {
        if i == 0 {
            return grid[i][j]
        }
        if memo[i][j] >= 0 {
            return memo[i][j]
        }
        res := Inf
        for k := 0; k < n; k++ {
            res = min(res, dfs(i - 1, k) + moveCost[grid[i - 1][k]][j] + grid[i][j])
        }
        memo[i][j] = res
        return res
    }
    res := Inf
    for j := 0; j < n; j++ {
        res = min(res, dfs(m - 1, j))
    }
    return res
}
```

```python
class Solution:
    def minPathCost(self, grid: List[List[int]], moveCost: List[List[int]]) -> int:
        @cache
        def dfs(i: int, j: int) -> int:
            return grid[i][j] if i == 0 else min(dfs(i - 1, k) + moveCost[grid[i - 1][k]][j] + grid[i][j] for k in range(len(grid[0])))
        return min(dfs(len(grid) - 1, j) for j in range(len(grid[0])))
```

```c
int min(int a, int b) {
    return a > b ? b : a;
}

int **memo = NULL;

int dfs(int i, int j, int **grid, int **moveCost, int n) {
    if (i == 0) {
        return grid[i][j];
    }
    if (memo[i][j] >= 0) {
        return memo[i][j];
    }
    int res = INT_MAX;
    for (int k = 0; k < n; k++) {
        res = min(res, dfs(i - 1, k, grid, moveCost, n) + moveCost[grid[i - 1][k]][j] + grid[i][j]);
    }
    memo[i][j] = res;
    return res;
}

int minPathCost(int** grid, int gridSize, int* gridColSize, int** moveCost, int moveCostSize, int* moveCostColSize) {
    int m = gridSize, n = gridColSize[0];
    memo = (int **)malloc(sizeof(int *) * m);
    for (int i = 0; i < m; i++) {
        memo[i] = (int *)malloc(sizeof(int) * n);
        for (int j = 0; j < n; j++) {
            memo[i][j] = -1;
        }
    }
    int res = INT_MAX;
    for (int j = 0; j < n; j++) {
        res = min(res, dfs(m - 1, j, grid, moveCost, n));
    }
    for (int i = 0; i < m; i++) {
        free(memo[i]);
    }
    free(memo);
    return res;
}
```

```javascript
var minPathCost = function(grid, moveCost) {
    let m = grid.length, n = grid[0].length;
    let memo = new Array(m).fill(0).map(() => new Array(n).fill(-1));
    function dfs(i, j) {
        if (i == 0) {
            return grid[i][j];
        }
        if (memo[i][j] >= 0) {
            return memo[i][j];
        }
        let res = Infinity;
        for (let k = 0; k < n; k++) {
            res = Math.min(res, dfs(i - 1, k) + moveCost[grid[i - 1][k]][j] + grid[i][j]);
        }
        memo[i][j] = res;
        return res;
    }
    let res = Infinity;
    for (let j = 0; j < n; j++) {
        res = Math.min(res, dfs(m - 1, j));
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(mn^2)$，其中 $m$ 和 $n$ 分别是数组 $grid$ 的行数和列数。记忆化搜索最多计算 $mn$ 个状态，每个状态需要 $O(n)$。
-   空间复杂度：$O(mn)$。

#### 方法二：动态规划

类似于方法一，我们使用 $dp[i][j]$ 表示从第 $0$ 行的任意单元格出发，到达第 $i$ 行 $j$ 列的单元格的最小路径代价，那么转移方程为：

$$dp[i][j] = \begin{cases} grid[i][j] & i = 0 \\ \min_{k = 0}^{n - 1} \{ dp[i - 1][k] + moveCost[grid[i - 1][k]][j] + grid[i][j] \} & i \gt 0 \end{cases}$$

```cpp
class Solution {
public:
    int minPathCost(vector<vector<int>>& grid, vector<vector<int>>& moveCost) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> dp(2, vector<int>(n));
        dp[0] = grid[0];
        int cur = 0;
        for (int i = 1; i < m; i++) {
            int next = 1 - cur;
            for (int j = 0; j < n; j++) {
                dp[next][j] = INT_MAX;
                for (int k = 0; k < n; k++) {
                    dp[next][j] = min(dp[next][j], dp[cur][k] + moveCost[grid[i - 1][k]][j] + grid[i][j]);
                }
            }
            cur = next;
        }
        return *min_element(dp[cur].begin(), dp[cur].end());
    }
};
```

```java
class Solution {
    public int minPathCost(int[][] grid, int[][] moveCost) {
        int m = grid.length, n = grid[0].length;
        int[][] dp = new int[2][n];
        dp[0] = grid[0].clone();
        int cur = 0;
        for (int i = 1; i < m; i++) {
            int next = 1 - cur;
            for (int j = 0; j < n; j++) {
                dp[next][j] = Integer.MAX_VALUE;
                for (int k = 0; k < n; k++) {
                    dp[next][j] = Math.min(dp[next][j], dp[cur][k] + moveCost[grid[i - 1][k]][j] + grid[i][j]);
                }
            }
            cur = next;
        }
        return Arrays.stream(dp[cur]).min().getAsInt();
    }
}
```

```go
const Inf = 0x3f3f3f3f

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}

func minPathCost(grid [][]int, moveCost [][]int) int {
    m, n, cur := len(grid), len(grid[0]), 0
    dp := [2][]int{
        make([]int, n), make([]int, n),
    }
    copy(dp[0], grid[0])
    for i := 1; i < m; i++ {
        next := 1 - cur
        for j := 0; j < n; j++ {
            dp[next][j] = Inf
            for k := 0; k < n; k++ {
                dp[next][j] = min(dp[next][j], dp[cur][k] + moveCost[grid[i - 1][k]][j] + grid[i][j])
            }
        }
        cur = next
    }
    res := Inf
    for j := 0; j < n; j++ {
        res = min(res, dp[cur][j])
    }
    return res
}
```

```python
class Solution:
    def minPathCost(self, grid: List[List[int]], moveCost: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        dp = grid[0]
        for i in range(1, len(grid)):
            dp = [grid[i][j] + min(dp[k] + moveCost[grid[i - 1][k]][j] for k in range(n)) for j in range(n)]
        return min(dp)
```

```c
int min(int a, int b) {
    return a > b ? b : a;
}

int minPathCost(int** grid, int gridSize, int* gridColSize, int** moveCost, int moveCostSize, int* moveCostColSize) {
    int m = gridSize, n = gridColSize[0];
    int *dp[2] = {
        (int *)malloc(sizeof(int) * n),
        (int *)malloc(sizeof(int) * n)
    };
    for (int j = 0; j < n; j++) {
        dp[0][j] = grid[0][j];
    }
    int cur = 0;
    for (int i = 1; i < m; i++) {
        int next = 1 - cur;
        for (int j = 0; j < n; j++) {
            dp[next][j] = INT_MAX;
            for (int k = 0; k < n; k++) {
                dp[next][j] = min(dp[next][j], dp[cur][k] + moveCost[grid[i - 1][k]][j] + grid[i][j]);
            }
        }
        cur = next;
    }
    int res = INT_MAX;
    for (int j = 0; j < n; j++) {
        res = min(res, dp[cur][j]);
    }
    free(dp[0]);
    free(dp[1]);
    return res;
}
```

```javascript
var minPathCost = function(grid, moveCost) {
    let m = grid.length, n = grid[0].length;
    let dp = new Array(2).fill(0).map(() => new Array(n));
    dp[0] = Array.from(grid[0]);
    let cur = 0;
    for (let i = 1; i < m; i++) {
        let next = 1 - cur;
        for (let j = 0; j < n; j++) {
            dp[next][j] = Infinity;
            for (let k = 0; k < n; k++) {
                dp[next][j] = Math.min(dp[next][j], dp[cur][k] + moveCost[grid[i - 1][k]][j] + grid[i][j]);
            }
        }
        cur = next;
    }
    return Math.min(...dp[cur]);
};
```

**复杂度分析**

-   时间复杂度：$O(mn^2)$，其中 $m$ 和 $n$ 分别是数组 $grid$ 的行数和列数。
-   空间复杂度：$O(n)$。
