### [逆向思维 + 拓扑序 DP，复用 913 题代码（Python/Java/C++/Go）](https://leetcode.cn/problems/cat-and-mouse-ii/solutions/3070697/ni-xiang-si-wei-tuo-bu-xu-dpfu-yong-913-t99rl/)

请先完成 [913\. 猫和老鼠](https://leetcode.cn/problems/cat-and-mouse/)，[我的题解](https://leetcode.cn/problems/cat-and-mouse/solutions/3070461/ni-xiang-si-wei-tuo-bu-xu-dppythonjavacg-wp8k/)。

本题思路一样，为了复用 913 题的代码，需要做一些预处理和修改：

1. 把二维坐标 $(i,j)$ 映射为 $i \cdot n+j$（$n$ 为列数），这样可以把二维坐标转换成一维坐标。
2. 遍历 $gird$，枚举位置和跳跃长度，鼠和猫分别建图 $gMouse$ 和 $gCat$。
3. $deg[i][j][0]$ 等于 $gMouse[i]$ 的长度，$deg[i][j][1]$ 等于 $gCat[j]$ 的长度。
4. 913 题猫不能进洞，本题可以（把食物当作洞）。

注：本题虽然有「$1000$ 次操作内」的要求，但由于 $mn \ll 1000$，如果 $1000$ 次操作内还没有从起点走到终点，那么一定是平局。所以 1000 的要求等同于平局。

```Python
class Solution:
    # 913. 猫和老鼠
    def catMouseGame(self, g_mouse: List[List[int]], g_cat: List[List[int]], mouse_start: int, cat_start: int, hole: int) -> int:
        n = len(g_mouse)
        deg = [[[0, 0] for _ in range(n)] for _ in range(n)]
        for i in range(n):
            for j in range(n):
                deg[i][j][0] = len(g_mouse[i])
                deg[i][j][1] = len(g_cat[j])

        winner = [[[0, 0] for _ in range(n)] for _ in range(n)]
        q = deque()
        for i in range(n):
            winner[hole][i][1] = 1  # 鼠到达洞中（此时轮到猫移动），鼠获胜
            winner[i][hole][0] = 2  # 猫到达洞中（此时轮到鼠移动），猫获胜
            winner[i][i][0] = winner[i][i][1] = 2  # 猫和鼠出现在同一个节点，无论轮到谁移动，都是猫获胜
            q.append((hole, i, 1))
            q.append((i, hole, 0))
            q.append((i, i, 0))
            q.append((i, i, 1))

        # 获取 (mouse, cat, turn) 的上个状态（值尚未确定）
        def get_pre_states() -> List[Tuple[int, int]]:
            if turn:  # 当前轮到猫移动，枚举上一轮鼠的位置
                return [(pre_mouse, cat) for pre_mouse in g_mouse[mouse] if winner[pre_mouse][cat][0] == 0]
            # 当前轮到鼠移动，枚举上一轮猫的位置
            return [(mouse, pre_cat) for pre_cat in g_cat[cat] if winner[mouse][pre_cat][1] == 0]

        # 减少上个状态的度数
        def dec_deg_to_zero() -> bool:
            deg[pre_mouse][pre_cat][pre_turn] -= 1
            return deg[pre_mouse][pre_cat][pre_turn] == 0

        while q:
            mouse, cat, turn = q.popleft()
            win = winner[mouse][cat][turn]  # 最终谁赢了
            pre_turn = turn ^ 1
            for pre_mouse, pre_cat in get_pre_states():
                # 情况一：如果上一回合鼠从 pre 移动到 cur，最终鼠赢，那么标记 pre 状态的 winner = 鼠
                # 情况二：如果上一回合猫从 pre 移动到 cur，最终猫赢，那么标记 pre 状态的 winner = 猫
                # 情况三：如果上一回合鼠从 pre 移动到 cur，最终猫赢，那么待定，直到我们发现从 pre 出发能到达的状态都是猫赢，那么标记 pre 状态的 winner = 猫
                # 情况四：如果上一回合猫从 pre 移动到 cur，最终鼠赢，那么待定，直到我们发现从 pre 出发能到达的状态都是鼠赢，那么标记 pre 状态的 winner = 鼠
                if pre_turn == win - 1 or dec_deg_to_zero():
                    winner[pre_mouse][pre_cat][pre_turn] = win
                    q.append((pre_mouse, pre_cat, pre_turn))

        # 鼠在节点 mouse_start，猫在节点 cat_start，当前轮到鼠移动
        return winner[mouse_start][cat_start][0]  # 返回最终谁赢了（或者平局）

    def canMouseWin(self, grid: List[str], catJump: int, mouseJump: int) -> bool:
        DIRS = (0, -1), (0, 1), (-1, 0), (1, 0)  # 左右上下
        m, n = len(grid), len(grid[0])
        # 鼠和猫分别建图
        g_mouse = [[] for _ in range(m * n)]
        g_cat = [[] for _ in range(m * n)]
        for i, row in enumerate(grid):
            for j, c in enumerate(row):
                if c == '#':  # 墙
                    continue
                if c == 'M':  # 鼠的位置
                    mx, my = i, j
                elif c == 'C':  # 猫的位置
                    cx, cy = i, j
                elif c == 'F':  # 食物（洞）的位置
                    fx, fy = i, j
                v = i * n + j  # 二维坐标 (i,j) 映射为一维坐标 v
                for dx, dy in DIRS:  # 枚举左右上下四个方向
                    for k in range(mouseJump + 1):  # 枚举跳跃长度
                        x, y = i + k * dx, j + k * dy
                        if not (0 <= x < m and 0 <= y < n and grid[x][y] != '#'):  # 出界或者遇到墙
                            break
                        g_mouse[v].append(x * n + y)  # 连边
                    for k in range(catJump + 1):  # 枚举跳跃长度
                        x, y = i + k * dx, j + k * dy
                        if not (0 <= x < m and 0 <= y < n and grid[x][y] != '#'):  # 出界或者遇到墙
                            break
                        g_cat[v].append(x * n + y)  # 连边

        # 判断是否鼠赢
        return self.catMouseGame(g_mouse, g_cat, mx * n + my, cx * n + cy, fx * n + fy) == 1
```

```Java
class Solution {
    private static final int[][] DIRS = {{0, -1}, {0, 1}, {-1, 0}, {1, 0}}; // 左右上下

    public boolean canMouseWin(String[] grid, int catJump, int mouseJump) {
        int m = grid.length, n = grid[0].length();
        // 鼠和猫分别建图
        List<Integer>[] gMouse = new ArrayList[m * n];
        List<Integer>[] gCat = new ArrayList[m * n];
        Arrays.setAll(gMouse, i -> new ArrayList<>());
        Arrays.setAll(gCat, i -> new ArrayList<>());
        int mx = 0, my = 0, cx = 0, cy = 0, fx = 0, fy = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                char c = grid[i].charAt(j);
                if (c == '#') { // 墙
                    continue;
                }
                if (c == 'M') { // 鼠的位置
                    mx = i; my = j;
                } else if (c == 'C') { // 猫的位置
                    cx = i; cy = j;
                } else if (c == 'F') { // 食物（洞）的位置
                    fx = i; fy = j;
                }
                int v = i * n + j; // 二维坐标 (i,j) 映射为一维坐标 v
                for (int[] dir : DIRS) { // 枚举左右上下四个方向
                    for (int k = 0; k <= mouseJump; k++) { // 枚举跳跃长度
                        int x = i + k * dir[0], y = j + k * dir[1];
                        if (x < 0 || x >= m || y < 0 || y >= n || grid[x].charAt(y) == '#') { // 出界或者遇到墙
                            break;
                        }
                        gMouse[v].add(x * n + y); // 连边
                    }
                    for (int k = 0; k <= catJump; k++) { // 枚举跳跃长度
                        int x = i + k * dir[0], y = j + k * dir[1];
                        if (x < 0 || x >= m || y < 0 || y >= n || grid[x].charAt(y) == '#') { // 出界或者遇到墙
                            break;
                        }
                        gCat[v].add(x * n + y); // 连边
                    }
                }
            }
        }

        // 判断是否鼠赢
        return catMouseGame(gMouse, gCat, mx * n + my, cx * n + cy, fx * n + fy) == 1;
    }

    // 913. 猫和老鼠
    private int catMouseGame(List<Integer>[] gMouse, List<Integer>[] gCat, int mouseStart, int catStart, int hole) {
        int n = gMouse.length;
        int[][][] deg = new int[n][n][2];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                deg[i][j][0] = gMouse[i].size();
                deg[i][j][1] = gCat[j].size();
            }
        }

        int[][][] winner = new int[n][n][2];
        Queue<int[]> q = new ArrayDeque<>();
        for (int i = 0; i < n; i++) {
            winner[hole][i][1] = 1; // 鼠到达洞中（此时轮到猫移动），鼠获胜
            winner[i][hole][0] = 2;  // 猫到达洞中（此时轮到鼠移动），猫获胜
            winner[i][i][0] = winner[i][i][1] = 2; // 猫和鼠出现在同一个节点，无论轮到谁移动，都是猫获胜
            q.offer(new int[]{hole, i, 1});
            q.offer(new int[]{i, hole, 0});
            q.offer(new int[]{i, i, 0});
            q.offer(new int[]{i, i, 1});
        }

        while (!q.isEmpty()) {
            int[] cur = q.poll();
            int mouse = cur[0], cat = cur[1], turn = cur[2];
            int win = winner[mouse][cat][turn]; // 最终谁赢了
            for (int[] pre : getPreStates(mouse, cat, turn, gMouse, gCat, winner)) {
                int preMouse = pre[0], preCat = pre[1], preTurn = turn ^ 1;
                // 情况一：如果上一回合鼠从 pre 移动到 cur，最终鼠赢，那么标记 pre 状态的 winner = 鼠
                // 情况二：如果上一回合猫从 pre 移动到 cur，最终猫赢，那么标记 pre 状态的 winner = 猫
                // 情况三：如果上一回合鼠从 pre 移动到 cur，最终猫赢，那么待定，直到我们发现从 pre 出发能到达的状态都是猫赢，那么标记 pre 状态的 winner = 猫
                // 情况四：如果上一回合猫从 pre 移动到 cur，最终鼠赢，那么待定，直到我们发现从 pre 出发能到达的状态都是鼠赢，那么标记 pre 状态的 winner = 鼠
                if (preTurn == win - 1 || --deg[preMouse][preCat][preTurn] == 0) {
                    winner[preMouse][preCat][preTurn] = win;
                    q.offer(new int[]{preMouse, preCat, preTurn}); // 继续倒推
                }
            }
        }

        // 鼠在节点 mouseStart，猫在节点 catStart，当前轮到鼠移动
        return winner[mouseStart][catStart][0]; // 返回最终谁赢了（或者平局）
    }

    // 获取 (mouse, cat, turn) 的上个状态（值尚未确定）
    private List<int[]> getPreStates(int mouse, int cat, int turn, List<Integer>[] gMouse, List<Integer>[] gCat, int[][][] winner) {
        List<int[]> preStates = new ArrayList<>();
        if (turn == 0) { // 当前轮到鼠移动
            for (int preCat : gCat[cat]) { // 上一轮猫的位置
                if (winner[mouse][preCat][1] == 0) { // 猫无法移动到洞中
                    preStates.add(new int[]{mouse, preCat});
                }
            }
        } else { // 当前轮到猫移动
            for (int preMouse : gMouse[mouse]) { // 上一轮鼠的位置
                if (winner[preMouse][cat][0] == 0) {
                    preStates.add(new int[]{preMouse, cat});
                }
            }
        }
        return preStates;
    }
}
```

```C++
class Solution {
    // 913. 猫和老鼠
    int catMouseGame(vector<vector<int>>& g_mouse, vector<vector<int>>& g_cat, int mouse_start, int cat_start, int hole) {
        int n = g_mouse.size();
        vector deg(n, vector<array<int, 2>>(n));
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                deg[i][j][0] = g_mouse[i].size();
                deg[i][j][1] = g_cat[j].size();
            }
        }

        vector winner(n, vector<array<int, 2>>(n));
        queue<tuple<int, int, int>> q;
        for (int i = 0; i < n; i++) {
            winner[hole][i][1] = 1; // 鼠到达洞中（此时轮到猫移动），鼠获胜
            winner[i][hole][0] = 2;  // 猫到达洞中（此时轮到鼠移动），猫获胜
            winner[i][i][0] = winner[i][i][1] = 2; // 猫和鼠出现在同一个节点，无论轮到谁移动，都是猫获胜
            q.emplace(hole, i, 1);
            q.emplace(i, hole, 0);
            q.emplace(i, i, 0);
            q.emplace(i, i, 1);
        }

        // 获取 (mouse, cat, turn) 的上个状态（值尚未确定）
        auto get_pre_states = [&](int mouse, int cat, int turn) {
            vector<pair<int, int>> pre_states;
            if (turn == 0) { // 当前轮到鼠移动
                for (int pre_cat : g_cat[cat]) { // 上一轮猫的位置
                    if (winner[mouse][pre_cat][1] == 0) {
                        pre_states.emplace_back(mouse, pre_cat);
                    }
                }
            } else { // 当前轮到猫移动
                for (int pre_mouse : g_mouse[mouse]) { // 上一轮鼠的位置
                    if (winner[pre_mouse][cat][0] == 0) {
                        pre_states.emplace_back(pre_mouse, cat);
                    }
                }
            }
            return pre_states;
        };

        while (!q.empty()) {
            auto [mouse, cat, turn] = q.front(); q.pop();
            int win = winner[mouse][cat][turn]; // 最终谁赢了
            int pre_turn = turn ^ 1;
            for (auto [pre_mouse, pre_cat] : get_pre_states(mouse, cat, turn)) {
                // 情况一：如果上一回合鼠从 pre 移动到 cur，最终鼠赢，那么标记 pre 状态的 winner = 鼠
                // 情况二：如果上一回合猫从 pre 移动到 cur，最终猫赢，那么标记 pre 状态的 winner = 猫
                // 情况三：如果上一回合鼠从 pre 移动到 cur，最终猫赢，那么待定，直到我们发现从 pre 出发能到达的状态都是猫赢，那么标记 pre 状态的 winner = 猫
                // 情况四：如果上一回合猫从 pre 移动到 cur，最终鼠赢，那么待定，直到我们发现从 pre 出发能到达的状态都是鼠赢，那么标记 pre 状态的 winner = 鼠
                if (pre_turn == win - 1 || --deg[pre_mouse][pre_cat][pre_turn] == 0) {
                    winner[pre_mouse][pre_cat][pre_turn] = win;
                    q.emplace(pre_mouse, pre_cat, pre_turn); // 继续倒推
                }
            }
        }

        // 鼠在节点 mouse_start，猫在节点 cat_start，当前轮到鼠移动
        return winner[mouse_start][cat_start][0]; // 返回最终谁赢了（或者平局）
    }

public:
    bool canMouseWin(vector<string>& grid, int catJump, int mouseJump) {
        static constexpr int DIRS[4][2] = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}}; // 左右上下
        int m = grid.size(), n = grid[0].size();
        // 鼠和猫分别建图
        vector<vector<int>> g_mouse(m * n), g_cat(m * n);
        int mx, my, cx, cy, fx, fy;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '#') { // 墙
                    continue;
                }
                if (grid[i][j] == 'M') { // 鼠的位置
                    mx = i; my = j;
                } else if (grid[i][j] == 'C') { // 猫的位置
                    cx = i; cy = j;
                } else if (grid[i][j] == 'F') { // 食物（洞）的位置
                    fx = i; fy = j;
                }
                int v = i * n + j; // 二维坐标 (i,j) 映射为一维坐标 v
                for (auto [dx, dy] : DIRS) { // 枚举左右上下四个方向
                    for (int k = 0; k <= mouseJump; k++) { // 枚举跳跃长度
                        int x = i + k * dx, y = j + k * dy;
                        if (x < 0 || x >= m || y < 0 || y >= n || grid[x][y] == '#') { // 出界或者遇到墙
                            break;
                        }
                        g_mouse[v].push_back(x * n + y); // 连边
                    }
                    for (int k = 0; k <= catJump; k++) { // 枚举跳跃长度
                        int x = i + k * dx, y = j + k * dy;
                        if (x < 0 || x >= m || y < 0 || y >= n || grid[x][y] == '#') { // 出界或者遇到墙
                            break;
                        }
                        g_cat[v].push_back(x * n + y); // 连边
                    }
                }
            }
        }

        // 判断是否鼠赢
        return catMouseGame(g_mouse, g_cat, mx * n + my, cx * n + cy, fx * n + fy) == 1;
    }
};
```

```Go
// 913. 猫和老鼠
func catMouseGame(gMouse, gCat [][]int, mouseStart, catStart, hole int) int {
    n := len(gMouse)
    deg := make([][][2]int, n)
    for i := range deg {
        deg[i] = make([][2]int, n)
    }
    for i, m := range gMouse {
        for j, c := range gCat {
            deg[i][j][0] = len(m)
            deg[i][j][1] = len(c)
        }
    }

    winner := make([][][2]int, n)
    for i := range winner {
        winner[i] = make([][2]int, n)
    }
    q := [][3]int{}
    for i := range n {
        winner[hole][i][1] = 1 // 鼠到达洞中（此时轮到猫移动），鼠获胜
        winner[i][hole][0] = 2 // 猫到达洞中（此时轮到鼠移动），猫获胜
        winner[i][i][0] = 2    // 猫和鼠出现在同一个节点，无论轮到谁移动，都是猫获胜
        winner[i][i][1] = 2
        q = append(q, [3]int{hole, i, 1})
        q = append(q, [3]int{i, hole, 0})
        q = append(q, [3]int{i, i, 0})
        q = append(q, [3]int{i, i, 1})
    }

    // 获取 (mouse, cat, turn) 的上个状态（值尚未确定）
    getPreStates := func(mouse, cat, turn int) (preStates [][2]int) {
        if turn == 0 { // 当前轮到鼠移动
            for _, preCat := range gCat[cat] { // 上一轮猫的位置
                if winner[mouse][preCat][1] == 0 { // 猫无法移动到洞中
                    preStates = append(preStates, [2]int{mouse, preCat})
                }
            }
        } else { // 当前轮到猫移动
            for _, preMouse := range gMouse[mouse] { // 上一轮鼠的位置
                if winner[preMouse][cat][0] == 0 {
                    preStates = append(preStates, [2]int{preMouse, cat})
                }
            }
        }
        return preStates
    }

    // 减少上个状态的度数
    decDegToZero := func(preMouse, preCat, preTurn int) bool {
        deg[preMouse][preCat][preTurn]--
        return deg[preMouse][preCat][preTurn] == 0
    }

    for len(q) > 0 {
        mouse, cat, turn := q[0][0], q[0][1], q[0][2]
        q = q[1:]
        win := winner[mouse][cat][turn] // 最终谁赢了
        for _, pre := range getPreStates(mouse, cat, turn) {
            preMouse, preCat, preTurn := pre[0], pre[1], turn^1
            // 情况一：如果上一回合鼠从 pre 移动到 cur，最终鼠赢，那么标记 pre 状态的 winner = 鼠
            // 情况二：如果上一回合猫从 pre 移动到 cur，最终猫赢，那么标记 pre 状态的 winner = 猫
            // 情况三：如果上一回合鼠从 pre 移动到 cur，最终猫赢，那么待定，直到我们发现从 pre 出发能到达的状态都是猫赢，那么标记 pre 状态的 winner = 猫
            // 情况四：如果上一回合猫从 pre 移动到 cur，最终鼠赢，那么待定，直到我们发现从 pre 出发能到达的状态都是鼠赢，那么标记 pre 状态的 winner = 鼠
            if preTurn == win-1 || decDegToZero(preMouse, preCat, preTurn) {
                winner[preMouse][preCat][preTurn] = win
                q = append(q, [3]int{preMouse, preCat, preTurn}) // 继续倒推
            }
        }
    }

    // 鼠在节点 mouseStart，猫在节点 catStart，当前轮到鼠移动
    return winner[mouseStart][catStart][0] // 返回最终谁赢了（或者平局）
}

func canMouseWin(grid []string, catJump, mouseJump int) bool {
    dirs := [4]struct{ dx, dy int }{{0, -1}, {0, 1}, {-1, 0}, {1, 0}} // 左右上下
    m, n := len(grid), len(grid[0])
    // 鼠和猫分别建图
    gMouse := make([][]int, m*n)
    gCat := make([][]int, m*n)
    var mx, my, cx, cy, fx, fy int
    for i := 0; i < m; i++ {
        for j := 0; j < n; j++ {
            if grid[i][j] == '#' { // 墙
                continue
            }
            if grid[i][j] == 'M' { // 鼠的位置
                mx, my = i, j
            } else if grid[i][j] == 'C' { // 猫的位置
                cx, cy = i, j
            } else if grid[i][j] == 'F' { // 食物（洞）的位置
                fx, fy = i, j
            }
            v := i*n + j // 二维坐标 (i,j) 映射为一维坐标 v
            for _, d := range dirs { // 枚举左右上下四个方向
                for k := range mouseJump + 1 { // 枚举跳跃长度
                    x, y := i+k*d.dx, j+k*d.dy
                    if x < 0 || x >= m || y < 0 || y >= n || grid[x][y] == '#' { // 出界或者遇到墙
                        break
                    }
                    gMouse[v] = append(gMouse[v], x*n+y) // 连边
                }
                for k := range catJump + 1 { // 枚举跳跃长度
                    x, y := i+k*d.dx, j+k*d.dy
                    if x < 0 || x >= m || y < 0 || y >= n || grid[x][y] == '#' { // 出界或者遇到墙
                        break
                    }
                    gCat[v] = append(gCat[v], x*n+y) // 连边
                }
            }
        }
    }

    // 判断是否鼠赢
    return catMouseGame(gMouse, gCat, mx*n+my, cx*n+cy, fx*n+fy) == 1
}
```

#### 复杂度分析

- 时间复杂度：$O(m^2n^2(m+n))$，其中 $m$ 和 $n$ 分别为 $grid$ 的行数和列数。有 $O(m^2n^2)$ 个状态，每个状态需要遍历 $O(m+n)$ 个相邻的状态。
- 空间复杂度：$O(m^2n^2)$。

更多相似题目，见下面动态规划题单中的「**十四、博弈 DP**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
7. 【本题相关】[动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
