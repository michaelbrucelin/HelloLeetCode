### [带传送的最小路径成本](https://leetcode.cn/problems/minimum-cost-path-with-teleportations/solutions/3883954/dai-chuan-song-de-zui-xiao-lu-jing-cheng-gc8s/)

#### 方法一：动态规划

根据题意，我们使用 $costs[t][i][j]$ 表示恰好使用 $t$ 次传送，从 $(i,j)$ 移动到 $(m-1,n-1)$ 的最小移动总成本。考虑从 $(i,j)$ 首次移动的两种情况：

1. 不使用传送，可以从 $(i,j)$ 移动到 $(i+1,j)$ 或 $(i,j+1)$，转移方程为：
    $$costs[t][i][j]=min(costs[t][i+1][j]+grid[i+1][j],costs[t][i][j+1]+grid[i][j+1])$$
2. 使用传送，可以传送到所有 $(x,y)$ 且 $grid[x][y]\le grid[i][j]$，转移方程为：
    $$costs[t][i][j]=\mathop{min}\limits_{grid[x][y]\le grid[i][j]}costs[t-1][x][y]$$

第二种情况需要计算所有 $(x,y)$ 且 $grid[x][y]\le grid[i][j]$ 在 $costs[t-1]$ 上的最小值 $T(t-1,i,j)$。

因此，我们使用 $points$ 存放所有单元格坐标，并按 $grid$ 值升序排序。遍历 $points$，用双指针记录值相同的区间 $[j,i]$，并维护已遍历单元格在 $costs[t-1]$ 的最小值 $minCost$，然后更新区间内所有单元格 $points[r]=(x_r,y_r)$ 的 $T(t-1,x_r,y_r)$ 值为 $minCost$。

由于 $costs[t]$ 只依赖 $costs[t-1]$，可以省略 $t$ 这一维度，直接用二维数组 $costs[i][j]$，降低空间复杂度。

```C++
class Solution {
public:
    int minCost(vector<vector<int>>& grid, int k) {
        int m = grid.size(), n = grid[0].size();
        vector<pair<int, int>> points;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                points.push_back({i, j});
            }
        }
        sort(points.begin(), points.end(), [&](const auto& p1, const auto& p2) -> bool {
            return grid[p1.first][p1.second] < grid[p2.first][p2.second];
        });
        vector<vector<int>> costs(m, vector<int>(n, INT_MAX));
        for (int t = 0; t <= k; t++) {
            int minCost = INT_MAX;
            for (int i = 0, j = 0; i < points.size(); i++) {
                minCost = min(minCost, costs[points[i].first][points[i].second]);
                if (i + 1 < points.size() && grid[points[i].first][points[i].second] == grid[points[i + 1].first][points[i + 1].second]) {
                    continue;
                }
                for (int r = j; r <= i; r++) {
                    costs[points[r].first][points[r].second] = minCost;
                }
                j = i + 1;
            }
            for (int i = m - 1; i >= 0; i--) {
                for (int j = n - 1; j >= 0; j--) {
                    if (i == m - 1 && j == n - 1) {
                        costs[i][j] = 0;
                        continue;
                    }
                    if (i != m - 1) {
                        costs[i][j] = min(costs[i][j], costs[i + 1][j] + grid[i + 1][j]);
                    }
                    if (j != n - 1) {
                        costs[i][j] = min(costs[i][j], costs[i][j + 1] + grid[i][j + 1]);
                    }
                }
            }
        }
        return costs[0][0];
    }
};
```

```Go
func minCost(grid [][]int, k int) int {
    m, n := len(grid), len(grid[0])
    type point struct{ x, y int }
    points := make([]point, 0, m * n)
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            points = append(points, point{ i, j })
        }
    }
    sort.Slice(points, func(i, j int) bool {
        return grid[points[i].x][points[i].y] < grid[points[j].x][points[j].y]
    })
    costs := make([][]int, m)
    for i := range costs {
        costs[i] = make([]int, n)
        for j := range costs[i] {
            costs[i][j] = math.MaxInt
        }
    }
    for t := 0; t <= k; t++ {
        minCost := math.MaxInt
        for i, j := 0, 0; i < len(points); i++ {
            minCost = min(minCost, costs[points[i].x][points[i].y])
            if i + 1 < len(points) && grid[points[i].x][points[i].y] == grid[points[i + 1].x][points[i + 1].y] {
                continue
            }
            for r := j; r <= i; r++ {
                costs[points[r].x][points[r].y] = minCost
            }
            j = i + 1
        }
        for i := m - 1; i >= 0; i-- {
            for j := n - 1; j >= 0; j-- {
                if i == m - 1 && j == n - 1 {
                    costs[i][j] = 0
                    continue
                }
                if i != m - 1 {
                    costs[i][j] = min(costs[i][j], costs[i + 1][j] + grid[i + 1][j])
                }
                if j != n - 1 {
                    costs[i][j] = min(costs[i][j], costs[i][j + 1] + grid[i][j + 1])
                }
            }
        }
    }
    return costs[0][0]
}
```

```Python
class Solution:
    def minCost(self, grid: list[list[int]], k: int) -> int:
        m, n = len(grid), len(grid[0])
        points = [(i, j) for i in range(m) for j in range(n)]
        points.sort(key=lambda p: grid[p[0]][p[1]])
        costs = [[float('inf')] * n for _ in range(m)]
        for t in range(k + 1):
            minCost = float('inf')
            j = 0
            for i in range(len(points)):
                minCost = min(minCost, costs[points[i][0]][points[i][1]])
                if i + 1 < len(points) and grid[points[i][0]][points[i][1]] == grid[points[i + 1][0]][points[i + 1][1]]:
                    i += 1
                    continue
                for r in range(j, i + 1):
                    costs[points[r][0]][points[r][1]] = minCost
                j = i + 1
            for i in range(m - 1, -1, -1):
                for j in range(n - 1, -1, -1):
                    if i == m - 1 and j == n - 1:
                        costs[i][j] = 0
                        continue
                    if i != m - 1:
                        costs[i][j] = min(costs[i][j], costs[i + 1][j] + grid[i + 1][j])
                    if j != n - 1:
                        costs[i][j] = min(costs[i][j], costs[i][j + 1] + grid[i][j + 1])
        return costs[0][0]
```

```Java
class Solution {
    public int minCost(int[][] grid, int k) {
        int m = grid.length, n = grid[0].length;
        List<int[]> points = new ArrayList<>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                points.add(new int[]{i, j});
            }
        }
        points.sort(Comparator.comparingInt(p -> grid[p[0]][p[1]]));
        int[][] costs = new int[m][n];
        for (int[] row : costs) {
            Arrays.fill(row, Integer.MAX_VALUE);
        }
        for (int t = 0; t <= k; t++) {
            int minCost = Integer.MAX_VALUE;
            for (int i = 0, j = 0; i < points.size(); i++) {
                minCost = Math.min(minCost, costs[points.get(i)[0]][points.get(i)[1]]);
                if (i + 1 < points.size() && grid[points.get(i)[0]][points.get(i)[1]] == grid[points.get(i + 1)[0]][points.get(i + 1)[1]]) {
                    continue;
                }
                for (int r = j; r <= i; r++) {
                    costs[points.get(r)[0]][points.get(r)[1]] = minCost;
                }
                j = i + 1;
            }
            for (int i = m - 1; i >= 0; i--) {
                for (int j = n - 1; j >= 0; j--) {
                    if (i == m - 1 && j == n - 1) {
                        costs[i][j] = 0;
                        continue;
                    }
                    if (i != m - 1) {
                        costs[i][j] = Math.min(costs[i][j], costs[i + 1][j] + grid[i + 1][j]);
                    }
                    if (j != n - 1) {
                        costs[i][j] = Math.min(costs[i][j], costs[i][j + 1] + grid[i][j + 1]);
                    }
                }
            }
        }
        return costs[0][0];
    }
}
```

```TypeScript
function minCost(grid: number[][], k: number): number {
    const m = grid.length, n = grid[0].length;
    const points: [number, number][] = [];
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            points.push([i, j]);
        }
    }
    points.sort((a, b) => grid[a[0]][a[1]] - grid[b[0]][b[1]]);
    const costs = Array.from({ length: m }, () => Array(n).fill(Number.MAX_SAFE_INTEGER));
    for (let t = 0; t <= k; t++) {
        let minCost = Number.MAX_SAFE_INTEGER;
        for (let i = 0, j = 0; i < points.length; i++) {
            minCost = Math.min(minCost, costs[points[i][0]][points[i][1]]);
            if (i + 1 < points.length && grid[points[i][0]][points[i][1]] === grid[points[i + 1][0]][points[i + 1][1]]) {
                continue;
            }
            for (let r = j; r <= i; r++) {
                costs[points[r][0]][points[r][1]] = minCost;
            }
            j = i + 1;
        }
        for (let i = m - 1; i >= 0; i--) {
            for (let j = n - 1; j >= 0; j--) {
                if (i === m - 1 && j === n - 1) {
                    costs[i][j] = 0;
                    continue;
                }
                if (i !== m - 1) {
                    costs[i][j] = Math.min(costs[i][j], costs[i + 1][j] + grid[i + 1][j]);
                }
                if (j !== n - 1) {
                    costs[i][j] = Math.min(costs[i][j], costs[i][j + 1] + grid[i][j + 1]);
                }
            }
        }
    }
    return costs[0][0];
}
```

```JavaScript
function minCost(grid, k) {
    const m = grid.length, n = grid[0].length;
    const points = [];
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            points.push([i, j]);
        }
    }
    points.sort((a, b) => grid[a[0]][a[1]] - grid[b[0]][b[1]]);
    const costs = Array.from({ length: m }, () => Array(n).fill(Number.MAX_SAFE_INTEGER));
    for (let t = 0; t <= k; t++) {
        let minCost = Number.MAX_SAFE_INTEGER;
        for (let i = 0, j = 0; i < points.length; i++) {
            minCost = Math.min(minCost, costs[points[i][0]][points[i][1]]);
            if (i + 1 < points.length && grid[points[i][0]][points[i][1]] === grid[points[i + 1][0]][points[i + 1][1]]) {
                continue;
            }
            for (let r = j; r <= i; r++) {
                costs[points[r][0]][points[r][1]] = minCost;
            }
            j = i + 1;
        }
        for (let i = m - 1; i >= 0; i--) {
            for (let j = n - 1; j >= 0; j--) {
                if (i === m - 1 && j === n - 1) {
                    costs[i][j] = 0;
                    continue;
                }
                if (i !== m - 1) {
                    costs[i][j] = Math.min(costs[i][j], costs[i + 1][j] + grid[i + 1][j]);
                }
                if (j !== n - 1) {
                    costs[i][j] = Math.min(costs[i][j], costs[i][j + 1] + grid[i][j + 1]);
                }
            }
        }
    }
    return costs[0][0];
}
```

```CSharp
public class Solution {
    public int MinCost(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;
        var points = new List<(int, int)>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                points.Add((i, j));
            }
        }
        points.Sort((p1, p2) => grid[p1.Item1][p1.Item2].CompareTo(grid[p2.Item1][p2.Item2]));
        int[,] costs = new int[m, n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                costs[i, j] = int.MaxValue;
            }
        }
        for (int t = 0; t <= k; t++) {
            int minCost = int.MaxValue;
            for (int i = 0, j = 0; i < points.Count; i++) {
                minCost = Math.Min(minCost, costs[points[i].Item1, points[i].Item2]);
                if (i + 1 < points.Count && grid[points[i].Item1][points[i].Item2] == grid[points[i + 1].Item1][points[i + 1].Item2]) {
                    continue;
                }
                for (int r = j; r <= i; r++) {
                    costs[points[r].Item1, points[r].Item2] = minCost;
                }
                j = i + 1;
            }
            for (int i = m - 1; i >= 0; i--) {
                for (int j = n - 1; j >= 0; j--) {
                    if (i == m - 1 && j == n - 1) {
                        costs[i, j] = 0;
                        continue;
                    }
                    if (i != m - 1) {
                        costs[i, j] = Math.Min(costs[i, j], costs[i + 1, j] + grid[i + 1][j]);
                    }
                    if (j != n - 1) {
                        costs[i, j] = Math.Min(costs[i, j], costs[i, j + 1] + grid[i][j + 1]);
                    }
                }
            }
        }
        return costs[0, 0];
    }
}
```

```C
static int** gridPtr = NULL;

static int cmp(const void* a, const void* b) {
    int* pa = (int*)a;
    int* pb = (int*)b;
    return gridPtr[pa[0]][pa[1]] - gridPtr[pb[0]][pb[1]];
}

int minCost(int** grid, int gridSize, int* gridColSize, int k){
    int m = gridSize, n = gridColSize[0];
    gridPtr = grid;
    int points[m * n][2], idx = 0;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            points[idx][0] = i, points[idx++][1] = j;
        }
    }
    qsort(points, m*n, sizeof(points[0]), cmp);
    int costs[m][n];
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            costs[i][j] = INT_MAX;
        }
    }
    for (int t = 0; t <= k; t++) {
        int minCost = INT_MAX;
        for (int i = 0, j = 0; i < m * n; i++) {
            minCost = fmin(minCost, costs[points[i][0]][points[i][1]]);
            if (i + 1 < m * n && grid[points[i][0]][points[i][1]] == grid[points[i + 1][0]][points[i + 1][1]]) {
                continue;
            }
            for (int r = j; r <= i; r++) {
                costs[points[r][0]][points[r][1]] = minCost;
            }
            j = i + 1;
        }
        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                if (i == m - 1 && j == n - 1) {
                    costs[i][j] = 0;
                    continue;
                }
                if (i != m - 1) {
                    costs[i][j] = fmin(costs[i][j], costs[i+1][j] + grid[i+1][j]);
                }
                if (j != n - 1) {
                    costs[i][j] = fmin(costs[i][j], costs[i][j+1] + grid[i][j+1]);
                }
            }
        }
    }
    return costs[0][0];
}
```

```Rust
impl Solution {
    pub fn min_cost(grid: Vec<Vec<i32>>, k: i32) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        let mut points = vec![];
        for i in 0..m {
            for j in 0..n {
                points.push((i, j));
            }
        }
        points.sort_by_key(|&(i, j)| grid[i][j]);
        let mut costs = vec![vec![i32::MAX; n]; m];
        for _ in 0..=k {
            let mut min_cost = i32::MAX;
            let mut i = 0;
            let mut j = 0;
            while i < points.len() {
                min_cost = min_cost.min(costs[points[i].0][points[i].1]);
                if i + 1 < points.len() && grid[points[i].0][points[i].1] == grid[points[i + 1].0][points[i + 1].1] {
                    i += 1;
                    continue;
                }
                for r in j..=i {
                    let p = points[r];
                    costs[p.0][p.1] = min_cost;
                }
                j = i + 1;
                i += 1;
            }
            for i in (0..m).rev() {
                for j in (0..n).rev() {
                    if i == m - 1 && j == n - 1 {
                        costs[i][j] = 0;
                        continue;
                    }
                    if i != m - 1 {
                        costs[i][j] = costs[i][j].min(costs[i + 1][j] + grid[i + 1][j]);
                    }
                    if j != n - 1 {
                        costs[i][j] = costs[i][j].min(costs[i][j + 1] + grid[i][j + 1]);
                    }
                }
            }
        }
        costs[0][0]
    }
}
```

**复杂度分析**

- 时间复杂度：$O((k+\log mn)\times mn)$，其中 $m$ 和 $n$ 分别是 $grid$ 的行数和列数，$k$ 是最多传送的次数。
- 空间复杂度：$O(mn)$。
