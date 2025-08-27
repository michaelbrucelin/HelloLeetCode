### [最长 V 形对角线段的长度](https://leetcode.cn/problems/length-of-longest-v-shaped-diagonal-segment/solutions/3756168/zui-chang-v-xing-dui-jiao-xian-duan-de-c-3pul/)

#### 方法一：记忆化搜索

**思路与算法**

根据题意可知，对于 $V$ 形对角线段定义如下：

- $V$ 形对角线段的起始元素一定是 $1$，且后续元素按照 $[2,0,2,0,\dots ]$ 交替出现，即元素的**访问序列**一定为 $[1,2,0,2,0,\dots ]$；
- 起始于某个对角方向（左上到右下、右下到左上、右上到左下或左下到右上），且沿着相同的对角方向继续前进，在保持 **序列模式** 的前提下，最多允许 **一次顺时针 $90$ 度转向** 另一个对角方向；

根据题意可以知道对角方向一共有 $4$ 个，分别是：左上到右下、右上到左下、右下到左上、左下到右上，对应的二维坐标偏移量即为：$(1,1),(1,-1),(-1,-1),(-1,1)$，我们用下标 $0$ 到 $3$ 分别代表 $4$ 个不同方向，如果当前方向 $d$，顺时针选旋转 $90$ 度后则对角度方向变为 $(d+1)mod4$。仔细分析可知，当确定 $V$ 形对角线段的起始置与起始对角方向后，则当前对角线段的最大长度取决于以下一个位置可以前进的最大线段长度，此时我们可以使用动态规划计算以每个点作为起始位置的 $V$ 形对角线段的最大长度。

为方便计算我们采用自顶向下的记忆化搜索，用 $dfs(x,y,direction,turn,target)$ 表示上一个位置是 $(x,y)$，当前对角方向是 $direction$，当前元素目标值为 $target$ 且当前旋转状态为 $turn$ 时的 $V$ 形对角线段的最大长度，同时用 $memo$ 记录所有子状态的最大值，为了方便计算，所有初始状态均为 $-1$。由于 $V$ 形对角线段中的相邻元素存在约束，此时需要根据上一个元素的值检测当前元素的值是否合法，此时也需要考虑该细节，$dfs(x,y,direction,turn,target)$ 计算过程如下：

- 由于上一个位置为 $(x,y)$，且在当前方向为 $direction$ 的情况下，累加坐标偏移即可计算出当前元素的位置为 $(nx,ny)$，此时需要检测当前位置 $(nx,ny)$ 是否越界与值合法，此时检查 $grid[nx][ny]$ 是否与目标值 $target$ 相等即可，如果越界或值不合法则表示当前路径不合法则直接返回 $0$；
- 如果当前位置 $(nx,ny)$ 不进行旋转，则下一个元素仍沿着之前的对角方向前进，则从下一个元素为起始位置的最大长度即为 $dfs(nx,ny,direction,turn,2-target)$；如果当前位置 $(nx,ny)$ 进行旋转，则下一个元素则沿着旋转后的对角方向前进，则从下一个元素为起始位置的最大长度即为 $dfs(nx,ny,(direction+1)mod4,turn,2-target)$，从当前位置 $(nx,ny)$ 起始的最大长度则为上述两种情况的最大值加 $1$，此时可知递推公式为:
  $dfs(x,y,direction,turn,target)=max(dfs(nx,ny,direction,turn,2-target) \\ dfs(nx,ny,(direction+1)mod4,turn,2-target))+1$
  由于每次元素的目标值 $target$，可以直接根据上一个元素位置得到，实际在用 $memo$ 记录所有子状态的最大值时无需记录 $target$，上述递推公式可以去掉参数 $target$，递推公式可以进一步优化为：
  $dfs(x,y,direction,turn)=max(dfs(nx,ny,direction,turn) \\ dfs(nx,ny,(direction+1)mod4,turn))+1$

根据题意可以知道 $V$ 形对角线定义，起点元素必须为 $1$，此时我们遍历矩阵 $grid$，从所有元素为 $1$ 的位置开始进行 $DFS$，即可得到矩阵 $grid$ 中的 $V$ 形对角线段的最大长度。

**代码**

```C++
class Solution {
public:
    int lenOfVDiagonal(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        int dirs[4][2] = {{1, 1}, {1, -1}, {-1, -1}, {-1, 1}};
        int memo[m][n][4][2];
        memset(memo, -1, sizeof(memo));
        
        function<int(int, int, int, bool, int)> dfs = [&](int cx, int cy, int direction, bool turn, int target) -> int {
            int nx = cx + dirs[direction][0];
            int ny = cy + dirs[direction][1];
            /* 如果超出边界或者下一个节点值不是目标值，则返回 */
            if (nx < 0 || ny < 0 || nx >= m || ny >= n || grid[nx][ny] != target) {
                return 0;
            }
            if (memo[nx][ny][direction][turn] != -1) {
                return memo[nx][ny][direction][turn];
            }

            /* 按照原来的方向继续行走 */
            int maxStep = dfs(nx, ny, direction, turn, 2 - target);
            if (turn) {
                /* 顺时针旋转 90 度转向 */
                maxStep = fmax(maxStep, dfs(nx, ny, (direction + 1) % 4, false, 2 - target));
            }
            memo[nx][ny][direction][turn] = maxStep + 1;
            return maxStep + 1;
        };
        
        int res = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    for (int direction = 0; direction < 4; ++direction) {
                        res = fmax(res, dfs(i, j, direction, true, 2) + 1);
                    }
                }
            }
        }

        return res;
    }
};
```

```Java
class Solution {
    private static final int[][] DIRS = {{1, 1}, {1, -1}, {-1, -1}, {-1, 1}};
    private int[][][][] memo;
    private int[][] grid;
    private int m, n;

    public int lenOfVDiagonal(int[][] grid) {
        this.grid = grid;
        this.m = grid.length;
        this.n = grid[0].length;
        this.memo = new int[m][n][4][2];
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < 4; k++) {
                    Arrays.fill(memo[i][j][k], -1);
                }
            }
        }

        int res = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    for (int direction = 0; direction < 4; direction++) {
                        res = Math.max(res, dfs(i, j, direction, true, 2) + 1);
                    }
                }
            }
        }
        return res;
    }

    private int dfs(int cx, int cy, int direction, boolean turn, int target) {
        int nx = cx + DIRS[direction][0];
        int ny = cy + DIRS[direction][1];
        /* 如果超出边界或者下一个节点值不是目标值，则返回 */
        if (nx < 0 || ny < 0 || nx >= m || ny >= n || grid[nx][ny] != target) {
            return 0;
        }
        
        int turnInt = turn ? 1 : 0;
        if (memo[nx][ny][direction][turnInt] != -1) {
            return memo[nx][ny][direction][turnInt];
        }

        /* 按照原来的方向继续行走 */
        int maxStep = dfs(nx, ny, direction, turn, 2 - target);
        if (turn) {
            /* 顺时针旋转 90 度转向 */
            maxStep = Math.max(maxStep, dfs(nx, ny, (direction + 1) % 4, false, 2 - target));
        }
        memo[nx][ny][direction][turnInt] = maxStep + 1;
        return maxStep + 1;
    }
}
```

```CSharp
public class Solution {
    private readonly int[][] DIRS = new int[][] {
        new int[] {1, 1}, new int[] {1, -1}, 
        new int[] {-1, -1}, new int[] {-1, 1}
    };
    private int[,,,] memo;
    private int[][] grid;
    private int m, n;

    public int LenOfVDiagonal(int[][] grid) {
        this.grid = grid;
        m = grid.Length;
        n = grid[0].Length;
        memo = new int[m, n, 4, 2];
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < 4; k++) {
                    for (int l = 0; l < 2; l++) {
                        memo[i, j, k, l] = -1;
                    }
                }
            }
        }

        int res = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    for (int direction = 0; direction < 4; direction++) {
                        res = Math.Max(res, Dfs(i, j, direction, true, 2) + 1);
                    }
                }
            }
        }
        return res;
    }

    private int Dfs(int cx, int cy, int direction, bool turn, int target) {
        int nx = cx + DIRS[direction][0];
        int ny = cy + DIRS[direction][1];
        /* 如果超出边界或者下一个节点值不是目标值，则返回 */
        if (nx < 0 || ny < 0 || nx >= m || ny >= n || grid[nx][ny] != target) {
            return 0;
        }
        
        int turnInt = turn ? 1 : 0;
        if (memo[nx, ny, direction, turnInt] != -1) {
            return memo[nx, ny, direction, turnInt];
        }

        /* 按照原来的方向继续行走 */
        int maxStep = Dfs(nx, ny, direction, turn, 2 - target);
        if (turn) {
            /* 顺时针旋转 90 度转向 */
            maxStep = Math.Max(maxStep, Dfs(nx, ny, (direction + 1) % 4, false, 2 - target));
        }
        memo[nx, ny, direction, turnInt] = maxStep + 1;
        return maxStep + 1;
    }
}
```

```Go
func lenOfVDiagonal(grid [][]int) int {
    dirs := [4][2]int{{1, 1}, {1, -1}, {-1, -1}, {-1, 1}}
    m, n := len(grid), len(grid[0])
    memo := make([][][4][2]int, m)
    for i := range memo {
        memo[i] = make([][4][2]int, n)
        for j := range memo[i] {
            for k := range memo[i][j] {
                for l := range memo[i][j][k] {
                    memo[i][j][k][l] = -1
                }
            }
        }
    }

    var dfs func(cx, cy, direction int, turn bool, target int) int
    dfs = func(cx, cy, direction int, turn bool, target int) int {
        nx, ny := cx+dirs[direction][0], cy+dirs[direction][1]
        /* 如果超出边界或者下一个节点值不是目标值，则返回 */
        if nx < 0 || ny < 0 || nx >= m || ny >= n || grid[nx][ny] != target {
            return 0
        }
        
        turnInt := 0
        if turn {
            turnInt = 1
        }
        if memo[nx][ny][direction][turnInt] != -1 {
            return memo[nx][ny][direction][turnInt]
        }

        /* 按照原来的方向继续行走 */
        maxStep := dfs(nx, ny, direction, turn, 2-target)
        if turn {
            /* 顺时针旋转 90 度转向 */
            maxStep = max(maxStep, dfs(nx, ny, (direction+1)%4, false, 2-target))
        }
        memo[nx][ny][direction][turnInt] = maxStep + 1
        return maxStep + 1
    }

    res := 0
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if grid[i][j] == 1 {
                for direction := 0; direction < 4; direction++ {
                    res = max(res, dfs(i, j, direction, true, 2)+1)
                }
            }
        }
    }
    return res
}
```

```Python
class Solution:
    def lenOfVDiagonal(self, grid: List[List[int]]) -> int:
        DIRS = [(1, 1), (1, -1), (-1, -1), (-1, 1)]
        m, n = len(grid), len(grid[0])
        
        @cache
        def dfs(cx, cy, direction, turn, target):
            nx, ny = cx + DIRS[direction][0], cy + DIRS[direction][1]
            # 如果超出边界或者下一个节点值不是目标值，则返回 
            if nx < 0 or ny < 0 or nx >= m or ny >= n or grid[nx][ny] != target:
                return 0
            turn_int = 1 if turn else 0
            # 按照原来的方向继续行走
            max_step = dfs(nx, ny, direction, turn, 2 - target)
            if turn:
                # 顺时针旋转 90 度转向
                max_step = max(max_step, dfs(nx, ny, (direction + 1) % 4, False, 2 - target))
            return max_step + 1
        
        res = 0
        for i in range(m):
            for j in range(n):
                if grid[i][j] == 1:
                    for direction in range(4):
                        res = max(res, dfs(i, j, direction, True, 2) + 1)
        return res
```

```C
#define MAX_N 500

const int dirs[4][2] = {{1, 1}, {1, -1}, {-1, -1}, {-1, 1}};
int memo[MAX_N][MAX_N][4][2][3];

int dfs(int cx, int cy, int direction, int turn, int target, int **grid, int m, int n) {
    int nx = cx + dirs[direction][0];
    int ny = cy + dirs[direction][1];
    /* 如果超出边界或者下一个节点值不是目标值，则返回 */
    if (nx < 0 || ny < 0 || nx >= m || ny >= n || grid[nx][ny] != target) {
        return 0;
    }
    if (memo[nx][ny][direction][turn][2 - target] != -1) {
        return memo[nx][ny][direction][turn][2 - target];
    }
    /* 按照原来的方向继续行走 */
    int maxStep = dfs(nx, ny, direction, turn, 2 - target, grid, m, n);
    if (turn) {
        /* 顺时针旋转 90 度转向 */
        maxStep = fmax(maxStep, dfs(nx, ny, (direction + 1) % 4, 0, 2 - target, grid, m, n));
    }
    memo[nx][ny][direction][turn][2 - target] = maxStep + 1;
    return maxStep + 1;
}

int lenOfVDiagonal(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    memset(memo, -1, sizeof(memo));

    int res = 0;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (grid[i][j] == 1) {
                for (int direction = 0; direction < 4; direction++) {
                    res = fmax(res, dfs(i, j, direction, 1, 2, grid, m, n) + 1);
                }
            }
        }
    }

    return res;
}
```

```JavaScript
var lenOfVDiagonal = function(grid) {
    const DIRS = [[1, 1], [1, -1], [-1, -1], [-1, 1]];
    const m = grid.length, n = grid[0].length;
    const memo = new Array(m * n * 8).fill(-1);

    function dfs(cx, cy, direction, turn, target) {
        const nx = cx + DIRS[direction][0];
        const ny = cy + DIRS[direction][1];
        /* 如果超出边界或者下一个节点值不是目标值，则返回 */
        if (nx < 0 || ny < 0 || nx >= m || ny >= n || grid[nx][ny] != target) {
            return 0;
        }
        
        const turnInt = turn ? 1 : 0;
        const index = nx * n * 8 + ny * 8 + direction * 2 + turnInt;
        if (memo[index] !== -1) {
            return memo[index];
        }

        /* 按照原来的方向继续行走 */
        let maxStep = dfs(nx, ny, direction, turn, 2 - target);
        if (turn) {
            /* 顺时针旋转 90 度转向 */
            maxStep = Math.max(maxStep, dfs(nx, ny, (direction + 1) % 4, false, 2 - target));
        }
        memo[index] = maxStep + 1;
        return maxStep + 1;
    }

    let res = 0;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] === 1) {
                for (let direction = 0; direction < 4; direction++) {
                    res = Math.max(res, dfs(i, j, direction, true, 2) + 1);
                }
            }
        }
    }
    return res;
};
```

```TypeScript
function lenOfVDiagonal(grid: number[][]): number {
    const DIRS = [[1, 1], [1, -1], [-1, -1], [-1, 1]];
    const m = grid.length, n = grid[0].length;
    const memo: number[] = new Array(m * n * 8).fill(-1);

    function dfs(cx: number, cy: number, direction: number, turn: boolean, target: number): number {
        const nx = cx + DIRS[direction][0];
        const ny = cy + DIRS[direction][1];
        /* 如果超出边界或者下一个节点值不是目标值，则返回 */
        if (nx < 0 || ny < 0 || nx >= m || ny >= n || grid[nx][ny] !== target) {
            return 0;
        }
        
        const turnInt = turn ? 1 : 0;
        const index = nx * n * 8 + ny * 8 + direction * 2 + turnInt;
        if (memo[index] !== -1) {
            return memo[index];
        }

        /* 按照原来的方向继续行走 */
        let maxStep = dfs(nx, ny, direction, turn, 2 - target);
        if (turn) {
            /* 顺时针旋转 90 度转向 */
            maxStep = Math.max(maxStep, dfs(nx, ny, (direction + 1) % 4, false, 2 - target));
        }
        memo[index] = maxStep + 1;
        return maxStep + 1;
    }

    let res = 0;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] === 1) {
                for (let direction = 0; direction < 4; direction++) {
                    res = Math.max(res, dfs(i, j, direction, true, 2) + 1);
                }
            }
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn len_of_v_diagonal(grid: Vec<Vec<i32>>) -> i32 {
        let dirs = [[1, 1], [1, -1], [-1, -1], [-1, 1]];
        let m = grid.len();
        let n = grid[0].len();
        let mut memo = vec![vec![vec![vec![-1; 2]; 4]; n]; m];
        
        fn dfs(
            cx: usize, 
            cy: usize, 
            direction: usize, 
            turn: bool, 
            target: i32,
            grid: &Vec<Vec<i32>>,
            memo: &mut Vec<Vec<Vec<Vec<i32>>>>,
            dirs: &[[i32; 2]; 4]
        ) -> i32 {
            let m = grid.len();
            let n = grid[0].len();
            let nx = (cx as i32 + dirs[direction][0]) as usize;
            let ny = (cy as i32 + dirs[direction][1]) as usize;
            /* 如果超出边界或者下一个节点值不是目标值，则返回 */
            if nx >= m || ny >= n || grid[nx][ny] != target {
                return 0;
            }
            
            let turn_int = if turn { 1 } else { 0 };
            if memo[nx][ny][direction][turn_int] != -1 {
                return memo[nx][ny][direction][turn_int];
            }

            /* 按照原来的方向继续行走 */
            let mut max_step = dfs(nx, ny, direction, turn, 2 - target, grid, memo, dirs);
            if turn {
                /* 顺时针旋转 90 度转向 */
                max_step = max_step.max(dfs(nx, ny, (direction + 1) % 4, false, 2 - target, grid, memo, dirs));
            }
            memo[nx][ny][direction][turn_int] = max_step + 1;
            max_step + 1
        }

        let mut res = 0;
        for i in 0..m {
            for j in 0..n {
                if grid[i][j] == 1 {
                    for direction in 0..4 {
                        res = res.max(dfs(i, j, direction, true, 2, &grid, &mut memo, &dirs) + 1);
                    }
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m,n$ 表示给定矩阵 $grid$ 的行数与列数。记忆化搜索一共存在 $O(nm)$ 个子状态，每个状态的计算时间是 $O(1)$，因此总的时间复杂度是 $O(nm)$。
- 空间复杂度：$O(mn)$，其中 $m,n$ 表示给定矩阵 $grid$ 的行数与列数。记忆化搜索递归调用栈的深度和需要存储的子状态数是 $O(nm)$。
