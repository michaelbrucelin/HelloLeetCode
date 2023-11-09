### [【图解】两种方法：二分答案 / 直接计算（Python/Java/C++/Go/JS/Rust）](https://leetcode.cn/problems/escape-the-spreading-fire/solutions/1460794/er-fen-bfspythonjavacgo-by-endlesscheng-ypp1/)

首先明确题意：人在到达安全屋**之前**，如果人移动到某个格子，火也移动到这个格子，那么人就被火烧到了。但是，允许人和火同时到达安全屋，这种情况不算人被火烧到。

#### 方法一：二分答案

##### 提示 1

如果人可以在**初始位置**停留 $t$ 分钟，那么肯定也可以停留少于 $t$ 分钟；如果人不能在初始位置停留 $t$ 分钟，那么肯定也不能停留超过 $t$ 分钟。

例如示例 1，人可以在初始位置停留 $3$ 分钟，那同样也可以在初始位置停留 $0,1,2$ 分钟；人不能在初始位置停留 $4$ 分钟，那同样也不能在初始位置停留 $5,6,7,\cdots$ 分钟。

这样我们就可以二分猜答案（最长停留时间）了。不了解二分答案的同学，可以先看这篇[【图解】一图掌握二分答案！四种写法！附题单！](https://leetcode.cn/problems/h-index-ii/solution/tu-jie-yi-tu-zhang-wo-er-fen-da-an-si-ch-d15k/)

##### 提示 2

二分答案前，先估计一下二分的上界。

![](./assets/img/Solution2258_oth_01.png)

如图，火可能要绕很多圈才能到达左上角，人可以在被火烧到的前一分钟出发。

所以粗略估计，就用 $mn$ 当作二分的上界。

> 注：也可以 BFS 算出火到人的最短距离，但这样要多写一个 BFS 的逻辑。考虑到方法二已经做到线性了，这里方法一就写简单点了。

假设当前二分的答案为 $t$。

为了避免被火烧到，人需要用最短时间到达安全屋，BFS 非常适合做这件事情。

在人移动前，先原地等待 $t$ 分钟。每分钟，着火的格子会扩散到所有不是墙的相邻格子，这种「扩展」模型也非常适合用 BFS 实现。

然后，每分钟人先移动，火再移动。如何判断人和火到达同一个格子？如果下一分钟人的格子出队时，发现已经被火烧到了，就直接跳过。

如果人可以到达安全屋，则说明答案至少为 $t$，否则答案小于 $t$。

二分结束后，如果发现答案大于 $mn$，说明火被堵住了（或者压根就没有火），返回 $10^9$。

代码实现时，为了方便模拟每分钟人的移动和火的扩散，不用队列实现，而是用**双数组**实现 BFS。

```python
class Solution:
    def maximumMinutes(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])

        # 返回能否在初始位置停留 t 分钟，并安全到达安全屋
        def check(t: int) -> bool:
            f = [(i, j) for i, row in enumerate(grid) for j, x in enumerate(row) if x == 1]
            on_fire = set(f)  # 标记着火的位置
            def spread_fire():
                # 火的 BFS
                nonlocal f
                tmp = f
                f = []
                for i, j in tmp:
                    for x, y in (i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1):  # 上下左右
                        if 0 <= x < m and 0 <= y < n and grid[x][y] == 0 and (x, y) not in on_fire:
                            on_fire.add((x, y))  # 标记着火的位置
                            f.append((x, y))
            while t and f:  # 如果火无法扩散就提前退出
                spread_fire()  # 火扩散
                t -= 1
            if (0, 0) in on_fire:
                return False  # 起点着火，寄

            # 人的 BFS
            q = [(0, 0)]
            vis = set(q)
            while q:
                tmp = q
                q = []
                for i, j in tmp:
                    if (i, j) in on_fire: continue  # 人走到这个位置后，火也扩散到了这个位置
                    for x, y in (i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1):  # 上下左右
                        if 0 <= x < m and 0 <= y < n and grid[x][y] == 0 and (x, y) not in on_fire and (x, y) not in vis:
                            if x == m - 1 and y == n - 1:
                                return True  # 我们安全了…暂时。
                            vis.add((x, y))  # 避免反复访问同一个位置
                            q.append((x, y))
                spread_fire()  # 火扩散
            return False  # 人被火烧到，或者没有可以到达安全屋的路

        # 这里我用开区间二分（其它写法也可以）
        left = -1
        right = m * n + 1
        while left + 1 < right:
            mid = (left + right) // 2
            if check(mid):
                left = mid
            else:
                right = mid
        return left if left < m * n else 10 ** 9
```

```java
class Solution {
    private static final int[][] DIRS = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

    public int maximumMinutes(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        // 这里我用开区间二分（其它写法也可以）
        int left = -1, right = m * n + 1;
        while (left + 1 < right) {
            int mid = (left + right) >>> 1;
            if (check(grid, mid)) {
                left = mid;
            } else {
                right = mid;
            }
        }
        return left < m * n ? left : 1_000_000_000;
    }

    // 返回能否在初始位置停留 t 分钟，并安全到达安全屋
    private boolean check(int[][] grid, int t) {
        int m = grid.length, n = grid[0].length;
        boolean[][] onFire = new boolean[m][n];
        List<int[]> f = new ArrayList<>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    onFire[i][j] = true; // 标记着火的位置
                    f.add(new int[]{i, j});
                }
            }
        }
        while (t-- > 0 && !f.isEmpty()) { // 如果火无法扩散就提前退出
            f = spreadFire(grid, onFire, f); // 火扩散
        }
        if (onFire[0][0]) {
            return false; // 起点着火，寄
        }

        // 人的 BFS
        boolean[][] vis = new boolean[m][n];
        vis[0][0] = true;
        List<int[]> q = List.of(new int[]{0, 0});
        while (!q.isEmpty()) {
            List<int[]> tmp = q;
            q = new ArrayList<>();
            for (int[] p : tmp) {
                if (onFire[p[0]][p[1]]) { // 人走到这个位置后，火也扩散到了这个位置
                    continue;
                }
                for (int[] d : DIRS) { // 枚举上下左右四个方向
                    int x = p[0] + d[0], y = p[1] + d[1];
                    if (0 <= x && x < m && 0 <= y && y < n && !onFire[x][y] && !vis[x][y] && grid[x][y] == 0) {
                        if (x == m - 1 && y == n - 1) {
                            return true; // 我们安全了…暂时。
                        }
                        vis[x][y] = true; // 避免反复访问同一个位置
                        q.add(new int[]{x, y});
                    }
                }
            }
            f = spreadFire(grid, onFire, f); // 火扩散
        }
        return false; // 人被火烧到，或者没有可以到达安全屋的路
    }

    // 火的 BFS
    private List<int[]> spreadFire(int[][] grid, boolean[][] fire, List<int[]> f) {
        int m = grid.length, n = grid[0].length;
        List<int[]> tmp = f;
        f = new ArrayList<>();
        for (int[] p : tmp) {
            for (int[] d : DIRS) { // 枚举上下左右四个方向
                int x = p[0] + d[0], y = p[1] + d[1];
                if (0 <= x && x < m && 0 <= y && y < n && !fire[x][y] && grid[x][y] == 0) {
                    fire[x][y] = true; // 标记着火的位置
                    f.add(new int[]{x, y});
                }
            }
        }
        return f;
    }
}
```

```c++
class Solution {
    const int dirs[4][2] = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

    // 返回能否在初始位置停留 t 分钟，并安全到达安全屋
    bool check(vector<vector<int>> &grid, int t) {
        int m = grid.size(), n = grid[0].size();
        vector<vector<int>> on_fire(m, vector<int>(n));
        vector<pair<int, int>> f;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    on_fire[i][j] = true; // 标记着火的位置
                    f.emplace_back(i, j);
                }
            }
        }
        // 火的 BFS
        auto spread_fire = [&]() {
            vector<pair<int, int>> nf;
            for (auto &[i, j]: f) {
                for (auto &[dx, dy]: dirs) { // 枚举上下左右四个方向
                    int x = i + dx, y = j + dy;
                    if (0 <= x && x < m && 0 <= y && y < n && !on_fire[x][y] && grid[x][y] == 0) {
                        on_fire[x][y] = true; // 标记着火的位置
                        nf.emplace_back(x, y);
                    }
                }
            }
            f = move(nf);
        };
        while (t-- && !f.empty()) { // 如果火无法扩散就提前退出
            spread_fire(); // 火扩散
        }
        if (on_fire[0][0]) {
            return false; // 起点着火，寄
        }

        // 人的 BFS
        vector<vector<int>> vis(m, vector<int>(n));
        vis[0][0] = true;
        vector<pair<int, int>> q{{0, 0}};
        while (!q.empty()) {
            vector<pair<int, int>> nq;
            for (auto &[i, j]: q) {
                if (on_fire[i][j]) continue; // 人走到这个位置后，火也扩散到了这个位置
                for (auto &[dx, dy]: dirs) { // 枚举上下左右四个方向
                    int x = i + dx, y = j + dy;
                    if (0 <= x && x < m && 0 <= y && y < n && !on_fire[x][y] && !vis[x][y] && grid[x][y] == 0) {
                        if (x == m - 1 && y == n - 1) {
                            return true; // 我们安全了…暂时。
                        }
                        vis[x][y] = true; // 避免反复访问同一个位置
                        nq.emplace_back(x, y);
                    }
                }
            }
            q = move(nq);
            spread_fire(); // 火扩散
        }
        return false; // 人被火烧到，或者没有可以到达安全屋的路
    }

public:
    int maximumMinutes(vector<vector<int>> &grid) {
        int m = grid.size(), n = grid[0].size();
        // 这里我用开区间二分（其它写法也可以）
        int left = -1, right = m * n + 1;
        while (left + 1 < right) {
            int mid = (left + right) / 2;
            (check(grid, mid) ? left : right) = mid;
        }
        return left < m * n ? left : 1'000'000'000;
    }
};
```

```go
type pair struct{ x, y int }
var dirs = []pair{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}

func maximumMinutes(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    ans := sort.Search(m*n+1, func(t int) bool {
        onFire := make([][]bool, m)
        for i := range onFire {
            onFire[i] = make([]bool, n)
        }
        f := []pair{}
        for i, row := range grid {
            for j, x := range row {
                if x == 1 {
                    onFire[i][j] = true // 标记着火的位置
                    f = append(f, pair{i, j})
                }
            }
        }
        // 火的 BFS
        spreadFire := func() {
            tmp := f
            f = nil
            for _, p := range tmp {
                for _, d := range dirs { // 枚举上下左右四个方向
                    x, y := p.x+d.x, p.y+d.y
                    if 0 <= x && x < m && 0 <= y && y < n && !onFire[x][y] && grid[x][y] == 0 {
                        onFire[x][y] = true // 标记着火的位置
                        f = append(f, pair{x, y})
                    }
                }
            }
        }
        for ; t > 0 && len(f) > 0; t-- { // 如果火无法扩散就提前退出
            spreadFire() // 火扩散
        }
        if onFire[0][0] {
            return true // 起点着火，寄
        }

        // 人的 BFS
        vis := make([][]bool, m)
        for i := range vis {
            vis[i] = make([]bool, n)
        }
        vis[0][0] = true
        q := []pair{{}}
        for len(q) > 0 {
            tmp := q
            q = nil
            for _, p := range tmp {
                if onFire[p.x][p.y] { // 人走到这个位置后，火也扩散到了这个位置
                    continue
                }
                for _, d := range dirs { // 枚举上下左右四个方向
                    x, y := p.x+d.x, p.y+d.y
                    if 0 <= x && x < m && 0 <= y && y < n && !vis[x][y] && !onFire[x][y] && grid[x][y] == 0 {
                        if x == m-1 && y == n-1 {
                            return false // 我们安全了…暂时。
                        }
                        vis[x][y] = true // 避免反复访问同一个位置
                        q = append(q, pair{x, y})
                    }
                }
            }
            spreadFire() // 火扩散
        }
        return true // 人被火烧到，或者没有可以到达安全屋的路
    }) - 1
    if ans < m*n {
        return ans
    }
    return 1_000_000_000
}
```

```javascript
var maximumMinutes = function (grid) {
    const m = grid.length, n = grid[0].length;
    // 返回能否在初始位置停留 t 分钟，并安全到达安全屋
    function check(t) {
        const onFire = Array(m).fill(null).map(() => Array(n).fill(false));
        let f = [];
        for (let i = 0; i < m; i++) {
            for (let j = 0; j < n; j++) {
                if (grid[i][j] === 1) {
                    onFire[i][j] = true; // 标记着火的位置
                    f.push([i, j]);
                }
            }
        }
        // 火的 BFS
        function spreadFire() {
            const tmp = f;
            f = [];
            for (const [i, j] of tmp) {
                for (const [x, y] of [[i - 1, j], [i + 1, j], [i, j - 1], [i, j + 1]]) { // 上下左右
                    if (0 <= x && x < m && 0 <= y && y < n && !onFire[x][y] && grid[x][y] === 0) {
                        onFire[x][y] = true; // 标记着火的位置
                        f.push([x, y]);
                    }
                }
            }
        }
        while (t-- && f.length) { // 如果火无法扩散就提前退出
            spreadFire(); // 火扩散
        }
        if (onFire[0][0]) {
            return false; // 起点着火，寄
        }

        // 人的 BFS
        const vis = Array(m).fill(null).map(() => Array(n).fill(false));
        vis[0][0] = true;
        let q = [[0, 0]];
        while (q.length) {
            const tmp = q;
            q = [];
            for (const [i, j] of tmp) {
                if (onFire[i][j]) continue; // 人走到这个位置后，火也扩散到了这个位置
                for (const [x, y] of [[i - 1, j], [i + 1, j], [i, j - 1], [i, j + 1]]) { // 上下左右
                    if (0 <= x && x < m && 0 <= y && y < n && !onFire[x][y] && !vis[x][y] && grid[x][y] === 0) {
                        if (x === m - 1 && y === n - 1) {
                            return true; // 我们安全了…暂时。
                        }
                        vis[x][y] = true; // 避免反复访问同一个位置
                        q.push([x, y]);
                    }
                }
            }
            spreadFire(); // 火扩散
        }
        return false; // 人被火烧到，或者没有可以到达安全屋的路
    }

    // 这里我用开区间二分（其它写法也可以）
    let left = -1, right = m * n + 1;
    while (left + 1 < right) {
        const mid = Math.floor((left + right) / 2);
        if (check(mid)) {
            left = mid;
        } else {
            right = mid;
        }
    }
    return left < m * n ? left : 1e9;
};
```

```rust
impl Solution {
    pub fn maximum_minutes(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        // 返回能否在初始位置停留 t 分钟，并安全到达安全屋
        let check = |mut t: i32| -> bool {
            let mut on_fire = vec![vec![false; n]; m];
            let mut f = Vec::new();
            for (i, row) in grid.iter().enumerate() {
                for (j, &x) in row.iter().enumerate() {
                    if x == 1 {
                        on_fire[i][j] = true; // 标记着火的位置
                        f.push((i, j));
                    }
                }
            }
            while t > 0 && !f.is_empty() { // 如果火无法扩散就提前退出
                // 火扩散
                let mut tmp = Vec::new();
                for &(i, j) in &f {
                    for &(x, y) in &[(i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1)] { // 上下左右
                        if 0 <= x && x < m && 0 <= y && y < n && !on_fire[x][y] && grid[x][y] == 0 {
                            on_fire[x][y] = true; // 标记着火的位置
                            tmp.push((x, y));
                        }
                    }
                }
                f = tmp;
                t -= 1;
            }
            if on_fire[0][0] {
                return false; // 起点着火，寄
            }

            let mut vis = vec![vec![false; n]; m];
            vis[0][0] = true;
            let mut q = vec![(0, 0)];
            while !q.is_empty() {
                let mut tmp = Vec::new();
                for &(i, j) in &q {
                    if on_fire[i][j] { // 人走到这个位置后，火也扩散到了这个位置
                        continue;
                    }
                    for &(x, y) in &[(i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1)] { // 上下左右
                        if x >= 0 && x < m && y >= 0 && y < n && !on_fire[x][y] && !vis[x][y] && grid[x][y] == 0 {
                            if x == m - 1 && y == n - 1 {
                                return true; // 我们安全了…暂时。
                            }
                            vis[x][y] = true; // 避免反复访问同一个位置
                            tmp.push((x, y));
                        }
                    }
                }
                q = tmp;
                // 火扩散
                tmp = Vec::new();
                for &(i, j) in &f {
                    for &(x, y) in &[(i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1)] { // 上下左右
                        if 0 <= x && x < m && 0 <= y && y < n && !on_fire[x][y] && grid[x][y] == 0 {
                            on_fire[x][y] = true;
                            tmp.push((x, y));
                        }
                    }
                }
                f = tmp;
            }
            false // 人被火烧到，或者没有可以到达安全屋的路
        };

        // 这里我用开区间二分（其它写法也可以）
        let mut left = -1;
        let mut right = (m * n) as i32 + 1;
        while left + 1 < right {
            let mid = (left + right) / 2;
            if check(mid) {
                left = mid;
            } else {
                right = mid;
            }
        }
        if left < (m * n) as i32 { left } else { 1_000_000_000 }
    }
}
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(mn\log mn)$，其中 $m$ 和 $n$ 分别为 $grid$ 的行数和列数。二分循环 $\mathcal{O}(\log mn)$ 次，每次 `check` 的时间为 $\mathcal{O}(mn)$。
-   空间复杂度：$\mathcal{O}(mn)$。

#### 方法二：直接计算

这个方法来自如下观察：

考虑网格图中的一个格子，记作 $C$。设人在 $t_1$ 分钟到达 $C$，火在 $t_2$ 分钟到达 $C$。如果人比火先到达 $C$，即 $t_1 < t_2$，那么**不会出现中途火把人烧到的情况**。这可以用反证法证明：如果中途火把人烧到，那么火可以沿着人走的最短路到达 $C$，火到达 $C$ 的时间和人是一样的 $t_1$，但这与实际矛盾。

**推论**：在 $t_1<t_2$ 时，人在初始位置停留 $t_2-t_1-1$ 分钟，也可以比火先到达 $C$，且中途不会被火烧到。

**证明**：这相当于人在 $t_2-1$ 分钟到达 $C$，显然人比火先到。假设中途人被火烧到，那么火可以沿着人走的最短路到达 $C$，这说明火到达 $C$ 的时间应该是 $t_2-1$ 而不是 $t_2$，与实际矛盾。所以原命题成立，人中途不会被火烧到。

如果 $C$ 是安全屋，答案就是 $t_2-t_1-1$ 吗？

##### 更加细致的分析

很不幸，题目允许人和火可以同时到达安全屋。

这就引出了最后的问题：设人在 $t_1$ 分钟到达安全屋，火在 $t_2$ 分钟到达安全屋，那么人可以在初始位置停留 $t_2-t_1$ 分钟吗？

![](./assets/img/Solution2258_oth_02.png)

##### 算法

首先通过 BFS 求出人到每个格子的最短时间 $manTime$，以及火到每个格子的最短时间 $fireTime$。

分类讨论：

-   如果 $manTime[m-1][n-1]<0$，说明人无法到达安全屋，返回 $-1$。
-   否则，如果 $fireTime[m-1][n-1]<0$，说明火无法到达安全屋。由于此时人和安全屋是连通的，但火和安全屋不是连通的，说明人和火是隔开的，人可以无限等待下去，返回 $10^9$。
-   否则，记 $d=fireTime[m-1][n-1]-manTime[m-1][n-1]$：
-   如果 $d < 0$，说明火比人先到安全屋，返回 $-1$。
-   如果 $d \ge 0$，判断人能否在停留 $d$ 分钟后，先比火到达安全屋左边**或**上边相邻格子。如果可以，返回 $d$，对应上图第一种情况；否则返回 $d-1$，对应上图第二种情况。

```python
class Solution:
    def maximumMinutes(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])

        # 返回三个数，分别表示到达安全屋/安全屋左边/安全屋上边的最短时间
        def bfs(q: List[Tuple[int, int]]) -> (int, int, int):
            time = [[-1] * n for _ in range(m)]  # -1 表示未访问
            for i, j in q:
                time[i][j] = 0
            t = 1
            while q:  # 每次循环向外扩展一圈
                tmp = q
                q = []
                for i, j in tmp:
                    for x, y in (i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1):  # 上下左右
                        if 0 <= x < m and 0 <= y < n and grid[x][y] == 0 and time[x][y] < 0:
                            time[x][y] = t
                            q.append((x, y))
                t += 1
            return time[-1][-1], time[-1][-2], time[-2][-1]

        man_to_house_time, m1, m2 = bfs([(0, 0)])
        if man_to_house_time < 0:  # 人无法到安全屋
            return -1

        fire_pos = [(i, j) for i, row in enumerate(grid) for j, x in enumerate(row) if x == 1]
        fire_to_house_time, f1, f2 = bfs(fire_pos)
        if fire_to_house_time < 0:  # 火无法到安全屋
            return 10 ** 9

        d = fire_to_house_time - man_to_house_time
        if d < 0:  # 火比人先到安全屋
            return -1

        if m1 != -1 and m1 + d < f1 or \
           m2 != -1 and m2 + d < f2:  # 安全屋左边或上边的其中一个格子人比火先到
            return d  # 图中第一种情况
        return d - 1  # 图中第二种情况
```

```java
class Solution {
    private static final int[][] DIRS = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

    public int maximumMinutes(int[][] grid) {
        int[] res = bfs(grid, List.of(new int[]{0, 0}));
        int manToHouseTime = res[0], m1 = res[1], m2 = res[2];
        if (manToHouseTime < 0) { // 人无法到安全屋
            return -1;
        }

        List<int[]> firePos = new ArrayList<>();
        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[i].length; j++) {
                if (grid[i][j] == 1) {
                    firePos.add(new int[]{i, j});
                }
            }
        }
        res = bfs(grid, firePos); // 多个着火点同时跑 BFS
        int fireToHouseTime = res[0], f1 = res[1], f2 = res[2];
        if (fireToHouseTime < 0) { // 火无法到安全屋
            return 1_000_000_000;
        }

        int d = fireToHouseTime - manToHouseTime;
        if (d < 0) { // 火比人先到安全屋
            return -1;
        }

        if (m1 != -1 && m1 + d < f1 || // 安全屋左边相邻格子，人比火先到
            m2 != -1 && m2 + d < f2) { // 安全屋上边相邻格子，人比火先到
            return d; // 图中第一种情况
        }
        return d - 1; // 图中第二种情况
    }

    // 返回的数组包含三个数，分别表示到达安全屋/安全屋左边/安全屋上边的最短时间
    private int[] bfs(int[][] grid, List<int[]> q) {
        int m = grid.length, n = grid[0].length;
        int[][] time = new int[m][n];
        for (int[] t : time) {
            Arrays.fill(t, -1); // -1 表示未访问
        }
        for (int[] p : q) {
            time[p[0]][p[1]] = 0;
        }
        for (int t = 1; !q.isEmpty(); t++) { // 每次循环向外扩展一圈
            List<int[]> tmp = q;
            q = new ArrayList<>();
            for (int[] p : tmp) {
                for (int[] d : DIRS) { // 枚举上下左右四个方向
                    int x = p[0] + d[0], y = p[1] + d[1];
                    if (0 <= x && x < m && 0 <= y && y < n && grid[x][y] == 0 && time[x][y] < 0) {
                        time[x][y] = t;
                        q.add(new int[]{x, y});
                    }
                }
            }
        }
        return new int[]{time[m - 1][n - 1], time[m - 1][n - 2], time[m - 2][n - 1]};
    }
}
```

```c++
class Solution {
    const int dirs[4][2] = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};
public:
    int maximumMinutes(vector<vector<int>> &grid) {
        int m = grid.size(), n = grid[0].size();
        // 返回三个数，分别表示到达安全屋/安全屋左边/安全屋上边的最短时间
        auto bfs = [&](vector<pair<int, int>> &q) -> tuple<int, int, int> {
            vector<vector<int>> time(m, vector<int>(n, -1)); // -1 表示未访问
            for (auto &[i, j]: q) {
                time[i][j] = 0;
            }
            for (int t = 1; !q.empty(); t++) { // 每次循环向外扩展一圈
                vector<pair<int, int>> nq;
                for (auto &[i, j]: q) {
                    for (auto &[dx, dy]: dirs) { // 枚举上下左右四个方向
                        int x = i + dx, y = j + dy;
                        if (0 <= x && x < m && 0 <= y && y < n && grid[x][y] == 0 && time[x][y] < 0) {
                            time[x][y] = t;
                            nq.emplace_back(x, y);
                        }
                    }
                }
                q = move(nq);
            }
            return {time[m - 1][n - 1], time[m - 1][n - 2], time[m - 2][n - 1]};
        };

        vector<pair<int, int>> q = {{0, 0}};
        auto [man_to_house_time, m1, m2] = bfs(q);
        if (man_to_house_time < 0) { // 人无法到安全屋
            return -1;
        }

        vector<pair<int, int>> fire_pos;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    fire_pos.emplace_back(i, j);
                }
            }
        }
        auto [fire_to_house_time, f1, f2] = bfs(fire_pos); // 多个着火点同时跑 BFS
        if (fire_to_house_time < 0) { // 火无法到安全屋
            return 1'000'000'000;
        }

        int d = fire_to_house_time - man_to_house_time;
        if (d < 0) { // 火比人先到安全屋
            return -1;
        }

        if (m1 != -1 && m1 + d < f1 || // 安全屋左边相邻格子，人比火先到
            m2 != -1 && m2 + d < f2) { // 安全屋上边相邻格子，人比火先到
            return d; // 图中第一种情况
        }
        return d - 1; // 图中第二种情况
    }
};
```

```go
type pair struct{ x, y int }
var dirs = []pair{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}

func maximumMinutes(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    // 返回三个数，分别表示到达安全屋/安全屋左边/安全屋上边的最短时间
    bfs := func(q []pair) (int, int, int) {
        time := make([][]int, m)
        for i := range time {
            time[i] = make([]int, n)
            for j := range time[i] {
                time[i][j] = -1 // -1 表示未访问
            }
        }
        for _, p := range q {
            time[p.x][p.y] = 0
        }
        for t := 1; len(q) > 0; t++ { // 每次循环向外扩展一圈
            tmp := q
            q = nil
            for _, p := range tmp {
                for _, d := range dirs { // 枚举上下左右四个方向
                    if x, y := p.x+d.x, p.y+d.y; 0 <= x && x < m && 0 <= y && y < n && grid[x][y] == 0 && time[x][y] < 0 {
                        time[x][y] = t
                        q = append(q, pair{x, y})
                    }
                }
            }
        }
        return time[m-1][n-1], time[m-1][n-2], time[m-2][n-1]
    }

    manToHouseTime, m1, m2 := bfs([]pair{{}})
    if manToHouseTime < 0 { // 人无法到安全屋
        return -1
    }

    firePos := []pair{}
    for i, row := range grid {
        for j, x := range row {
            if x == 1 {
                firePos = append(firePos, pair{i, j})
            }
        }
    }
    fireToHouseTime, f1, f2 := bfs(firePos) // 多个着火点同时跑 BFS
    if fireToHouseTime < 0 { // 火无法到安全屋
        return 1_000_000_000
    }

    d := fireToHouseTime - manToHouseTime
    if d < 0 { // 火比人先到安全屋
        return -1
    }

    if m1 != -1 && m1+d < f1 || // 安全屋左边相邻格子，人比火先到
       m2 != -1 && m2+d < f2 {  // 安全屋上边相邻格子，人比火先到
        return d // 图中第一种情况
    }
    return d - 1 // 图中第二种情况
}
```

```javascript
var maximumMinutes = function (grid) {
    const m = grid.length, n = grid[0].length;
    // 返回三个数，分别表示到达安全屋/安全屋左边/安全屋上边的最短时间
    function bfs(q) {
        const time = Array(m).fill(null).map(() => Array(n).fill(-1));
        for (const [i, j] of q) {
            time[i][j] = 0;
        }
        for (let t = 1; q.length; t++) {
            const tmp = q;
            q = [];
            for (const [i, j] of tmp) {
                for (const [x, y] of [[i - 1, j], [i + 1, j], [i, j - 1], [i, j + 1]]) { // 上下左右
                    if (0 <= x && x < m && 0 <= y && y < n && grid[x][y] === 0 && time[x][y] < 0) {
                        time[x][y] = t;
                        q.push([x, y]);
                    }
                }
            }
        }
        return [time[m - 1][n - 1], time[m - 1][n - 2], time[m - 2][n - 1]];
    }

    const [manToHouseTime, m1, m2] = bfs([[0, 0]]);
    if (manToHouseTime < 0) { // 人无法到安全屋
        return -1;
    }

    const firePos = [];
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] === 1) {
                firePos.push([i, j]);
            }
        }
    }
    const [fireToHouseTime, f1, f2] = bfs(firePos); // 多个着火点同时跑 BFS
    if (fireToHouseTime < 0) { // 火无法到安全屋
        return 1e9;
    }

    const d = fireToHouseTime - manToHouseTime;
    if (d < 0) { // 火比人先到安全屋
        return -1;
    }

    if (m1 !== -1 && m1 + d < f1 || // 安全屋左边相邻格子，人比火先到
        m2 !== -1 && m2 + d < f2) { // 安全屋上边相邻格子，人比火先到
        return d; // 图中第一种情况
    }
    return d - 1; // 图中第二种情况
};
```

```rust
impl Solution {
    pub fn maximum_minutes(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        // 返回三个数，分别表示到达安全屋/安全屋左边/安全屋上边的最短时间
        let bfs = |q: &mut Vec<(usize, usize)>| -> (i32, i32, i32) {
            let mut time = vec![vec![-1; n]; m]; // -1 表示未访问
            for &(i, j) in q.iter() {
                time[i][j] = 0;
            }
            let mut t = 1;
            while !q.is_empty() { // 每次循环向外扩展一圈
                let mut tmp = Vec::new();
                for &(i, j) in q.iter() {
                    for &(x, y) in &[(i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1)] { // 上下左右
                        if 0 <= x && x < m && 0 <= y && y < n && grid[x][y] == 0 && time[x][y] < 0 {
                            time[x][y] = t;
                            tmp.push((x, y));
                        }
                    }
                }
                t += 1;
                *q = tmp;
            }
            (time[m - 1][n - 1], time[m - 1][n - 2], time[m - 2][n - 1])
        };

        let (man_to_house_time, m1, m2) = bfs(&mut vec![(0, 0)]);
        if man_to_house_time < 0 { // 人无法到安全屋
            return -1;
        }

        let mut fire_pos = Vec::new();
        for (i, row) in grid.iter().enumerate() {
            for (j, &x) in row.iter().enumerate() {
                if x == 1 {
                    fire_pos.push((i, j));
                }
            }
        }
        let (fire_to_house_time, f1, f2) = bfs(&mut fire_pos); // 多个着火点同时跑 BFS
        if fire_to_house_time < 0 { // 火无法到安全屋
            return 1_000_000_000;
        }

        let d = fire_to_house_time - man_to_house_time;
        if d < 0 { // 火比人先到安全屋
            return -1;
        }

        if m1 != -1 && m1 + d < f1 || // 安全屋左边相邻格子，人比火先到
           m2 != -1 && m2 + d < f2 {  // 安全屋上边相邻格子，人比火先到
            return d; // 图中第一种情况
        }
        return d - 1; // 图中第二种情况
    }
}
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(mn)$，其中 $m$ 和 $n$ 分别为 $grid$ 的行数和列数。
-   空间复杂度：$\mathcal{O}(mn)$。
