### [逆向思维 + 拓扑序 DP（Python/Java/C++/Go）](https://leetcode.cn/problems/cat-and-mouse/solutions/3070461/ni-xiang-si-wei-tuo-bu-xu-dppythonjavacg-wp8k/)

#### 初步分析

我们要解决的原问题是：

- 鼠在节点 $1$，猫在节点 $2$，当前轮到鼠移动，最终谁获胜（或者平局）。

假如鼠从节点 $1$ 移动到相邻节点 $3$，那么问题变成：

- 鼠在节点 $3$，猫在节点 $2$，当前轮到猫移动，最终谁获胜（或者平局）。

这是和原问题相似的问题，可以用递归解决。

但这是「规模更小的子问题」吗？不是。因为猫鼠可以左右横跳、重复移动（递归结构有环），可能会无限递归下去，也就是平局。

这说明从起点出发，是不好解决的。

#### 逆向思维

正难则反，从终点开始**倒推**，能否得到一个鼠在节点 $1$，猫在节点 $2$，当前轮到鼠移动的状态？

终点是什么？

- 如果鼠移动到洞中（节点 $0$），那么鼠获胜。
- 如果猫鼠相遇，那么猫获胜。

从终点倒推一步：

- 比如 $0$ 和 $3$ 相连，如果上一步鼠在节点 $3$，猫在节点 $4$，轮到鼠移动，那么鼠可以移动到洞中，所以这种（鼠在节点 $3$，猫在节点 $4$，轮到鼠移动）的状态，就可以直接标记为「鼠获胜」。
- 比如 $6$ 和 $7$ 相连，如果上一步鼠在节点 $6$，猫在节点 $7$，轮到猫移动，那么猫可以移动到 $6$ 和鼠相遇，所以这种（鼠在节点 $6$，猫在节点 $7$，轮到猫移动）的状态，就可以直接标记为「猫获胜」。

除此以外，还有两种情况，也可以确定谁一定是获胜的。举例说明：

- 如果发现从（鼠在节点 $8$，猫在节点 $9$，轮到鼠移动）这种状态继续游戏，能到达的状态都是「猫获胜」，那么这种（鼠在节点 $8$，猫在节点 $9$，轮到鼠移动）的状态可以标记为「猫获胜」。
- 如果发现从（鼠在节点 $8$，猫在节点 $9$，轮到猫移动）这种状态继续游戏，能到达的状态都是「鼠获胜」，那么这种（鼠在节点 $8$，猫在节点 $9$，轮到猫移动）的状态可以标记为「鼠获胜」。

## 状态表示

**定义**：

- $winner[i][j][0]$ 表示鼠在节点 $i$，猫在节点 $j$，轮到**鼠**移动，最终谁获胜。
- $winner[i][j][1]$ 表示鼠在节点 $i$，猫在节点 $j$，轮到**猫**移动，最终谁获胜。
- $winner[i][j][k]=0$ 表示「尚未确定」或者「平局」。
- $winner[i][j][k]=1$ 表示「鼠获胜」。
- $winner[i][j][k]=2$ 表示「猫获胜」。

**终点**：

- 如果鼠移动到洞中（节点 $0$），那么鼠获胜。注意这里可以只考虑鼠在洞中，且轮到猫移动的状态，无需考虑继续轮到鼠移动的状态。即 $winner[0][j][1]=1$。
- 如果猫鼠相遇，那么猫获胜。即 $winner[i][i][0]=winner[i][i][1]=2$。

**倒推**：

- 情况一：如果 $winner[i][j][1]=1$，倒推上一个状态（鼠在节点 $i′$，猫在节点 $j$，轮到鼠移动），那么鼠从 $i′$ 移动到 $i$ 即可确保获胜，所以有 $winner[i′][j][0]=1$。
- 情况二：如果 $winner[i][j][0]=2$，倒推上一个状态（鼠在节点 $i$，猫在节点 $j′$，轮到猫移动），那么猫从 $j′$ 移动到 $j$ 即可确保获胜，所以有 $winner[i][j′][1]=2$。
- 情况三：倒推上一个状态（鼠在节点 $i′$，猫在节点 $j$，轮到鼠移动），且无论鼠怎么移动，都是猫赢，那么标记 $winner[i′][j][0]=2$。
- 情况四：倒推上一个状态（鼠在节点 $i$，猫在节点 $j′$，轮到猫移动），且无论猫怎么移动，都是鼠赢，那么标记 $winner[i][j′][1]=1$。

如何判断「无论鼠怎么移动，都是猫赢」？

用**拓扑排序**处理，原理见 [210\. 课程表 II](https://leetcode.cn/problems/course-schedule-ii/)。

每个状态维护相应的度数 $deg[i][j][k]$。比如发现 $deg[i′][j][0]=0$，但 $winner[i′][j][0]$ 仍然是 $0$（仍然没有找到鼠赢的状态），那么标记 $winner[i′][j][0]=2$（猫赢）。

**起点（答案）**：

- 鼠在节点 $1$，猫在节点 $2$，当前轮到鼠移动，即 $winner[1][2][0]$。

注：如果最终 $winner[1][2][0]=0$，说明无法从终点倒推得到，也就是无法从起点移动到终点（鼠获胜或者猫获胜），即平局。

#### 编程细节

设当前状态为 $winner[i][j][k]$，那么上一个状态的 $k′=k \oplus 1$（$k$ 异或 $1$）。这样可以在 $0$ 和 $1$ 之间切换。

情况一和情况二可以合并为：如果发现 $k′=winner[i][j][k]-1$，那么上一个状态的值就是 $winner[i][j][k]$。

下面代码把 $graph$ 简记为 $g$。

```Python
class Solution:
    def catMouseGame(self, g: List[List[int]]) -> int:
        HOLE = 0
        n = len(g)
        deg = [[[0, 0] for _ in range(n)] for _ in range(n)]
        for i in range(n):
            for j in range(1, n):
                deg[i][j][0] = len(g[i])
                deg[i][j][1] = len(g[j])
            # 对于猫来说，所有连到洞的边都不能走
            for j in g[HOLE]:
                deg[i][j][1] -= 1

        winner = [[[0, 0] for _ in range(n)] for _ in range(n)]
        q = deque()
        for i in range(1, n):
            winner[HOLE][i][1] = 1  # 鼠到达洞中（此时轮到猫移动），鼠获胜
            winner[i][i][0] = winner[i][i][1] = 2  # 猫和鼠出现在同一个节点，无论轮到谁移动，都是猫获胜
            q.append((HOLE, i, 1))
            q.append((i, i, 0))
            q.append((i, i, 1))

        # 获取 (mouse, cat, turn) 的上个状态（值尚未确定）
        def get_pre_states() -> List[Tuple[int, int]]:
            if turn:  # 当前轮到猫移动，枚举上一轮鼠的位置
                return [(pre_mouse, cat) for pre_mouse in g[mouse] if winner[pre_mouse][cat][0] == 0]
            # 当前轮到鼠移动，枚举上一轮猫的位置，注意猫无法移动到洞中
            return [(mouse, pre_cat) for pre_cat in g[cat] if pre_cat != HOLE and winner[mouse][pre_cat][1] == 0]

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
                    q.append((pre_mouse, pre_cat, pre_turn))  # 继续倒推

        # 鼠在节点 1，猫在节点 2，当前轮到鼠移动
        return winner[1][2][0]  # 返回最终谁赢了
```

```Java
class Solution {
    private static final int HOLE = 0;

    public int catMouseGame(int[][] g) {
        int n = g.length;
        int[][][] deg = new int[n][n][2];
        for (int i = 0; i < n; i++) {
            for (int j = 1; j < n; j++) {
                deg[i][j][0] = g[i].length;
                deg[i][j][1] = g[j].length;
            }
            // 对于猫来说，所有连到洞的边都不能走
            for (int j : g[HOLE]) {
                deg[i][j][1]--;
            }
        }

        int[][][] winner = new int[n][n][2];
        Queue<int[]> q = new ArrayDeque<>();
        for (int i = 1; i < n; i++) {
            winner[HOLE][i][1] = 1; // 鼠到达洞中（此时轮到猫移动），鼠获胜
            winner[i][i][0] = winner[i][i][1] = 2; // 猫和鼠出现在同一个节点，无论轮到谁移动，都是猫获胜
            q.offer(new int[]{HOLE, i, 1});
            q.offer(new int[]{i, i, 0});
            q.offer(new int[]{i, i, 1});
        }

        while (!q.isEmpty()) {
            int[] cur = q.poll();
            int mouse = cur[0], cat = cur[1], turn = cur[2];
            int win = winner[mouse][cat][turn]; // 最终谁赢了
            for (int[] pre : getPreStates(mouse, cat, turn, g, winner)) {
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

        // 鼠在节点 1，猫在节点 2，当前轮到鼠移动
        return winner[1][2][0]; // 返回最终谁赢了
    }

    // 获取 (mouse, cat, turn) 的上个状态（值尚未确定）
    private List<int[]> getPreStates(int mouse, int cat, int turn, int[][] g, int[][][] winner) {
        List<int[]> preStates = new ArrayList<>();
        if (turn == 0) { // 当前轮到鼠移动
            for (int preCat : g[cat]) { // 上一轮猫的位置
                if (preCat != HOLE && winner[mouse][preCat][1] == 0) { // 猫无法移动到洞中
                    preStates.add(new int[]{mouse, preCat});
                }
            }
        } else { // 当前轮到猫移动
            for (int preMouse : g[mouse]) { // 上一轮鼠的位置
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
public:
    int catMouseGame(vector<vector<int>>& g) {
        const int HOLE = 0;
        int n = g.size();
        vector deg(n, vector<array<int, 2>>(n));
        for (int i = 0; i < n; i++) {
            for (int j = 1; j < n; j++) {
                deg[i][j][0] = g[i].size();
                deg[i][j][1] = g[j].size();
            }
            // 对于猫来说，所有连到洞的边都不能走
            for (int j : g[HOLE]) {
                deg[i][j][1]--;
            }
        }

        vector winner(n, vector<array<int, 2>>(n));
        queue<tuple<int, int, int>> q;
        for (int i = 1; i < n; i++) {
            winner[HOLE][i][1] = 1; // 鼠到达洞中（此时轮到猫移动），鼠获胜
            winner[i][i][0] = winner[i][i][1] = 2; // 猫和鼠出现在同一个节点，无论轮到谁移动，都是猫获胜
            q.emplace(HOLE, i, 1);
            q.emplace(i, i, 0);
            q.emplace(i, i, 1);
        }

        // 获取 (mouse, cat, turn) 的上个状态（值尚未确定）
        auto get_pre_states = [&](int mouse, int cat, int turn) {
            vector<pair<int, int>> pre_states;
            if (turn == 0) { // 当前轮到鼠移动
                for (int pre_cat : g[cat]) { // 上一轮猫的位置
                    if (pre_cat != HOLE && winner[mouse][pre_cat][1] == 0) { // 猫无法移动到洞中
                        pre_states.emplace_back(mouse, pre_cat);
                    }
                }
            } else { // 当前轮到猫移动
                for (int pre_mouse : g[mouse]) { // 上一轮鼠的位置
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

        // 鼠在节点 1，猫在节点 2，当前轮到鼠移动
        return winner[1][2][0]; // 返回最终谁赢了
    }
};
```

```Go
func catMouseGame(g [][]int) int {
    const HOLE = 0
    n := len(g)
    deg := make([][][2]int, n)
    for i := range deg {
        deg[i] = make([][2]int, n)
    }

    for i, gi := range g {
        for j := 1; j < n; j++ {
            deg[i][j][0] = len(gi)
            deg[i][j][1] = len(g[j])
        }
        // 对于猫来说，所有连到洞的边都不能走
        for _, j := range g[HOLE] {
            deg[i][j][1]--
        }
    }

    winner := make([][][2]int, n)
    for i := range winner {
        winner[i] = make([][2]int, n)
    }
    q := [][3]int{}
    for i := 1; i < n; i++ {
        winner[HOLE][i][1] = 1 // 鼠到达洞中（此时轮到猫移动），鼠获胜
        winner[i][i][0] = 2    // 猫和鼠出现在同一个节点，无论轮到谁移动，都是猫获胜
        winner[i][i][1] = 2
        q = append(q, [3]int{HOLE, i, 1})
        q = append(q, [3]int{i, i, 0})
        q = append(q, [3]int{i, i, 1})
    }

    // 获取 (mouse, cat, turn) 的上个状态（值尚未确定）
    getPreStates := func(mouse, cat, turn int) (preStates [][2]int) {
        if turn == 0 { // 当前轮到鼠移动
            for _, preCat := range g[cat] { // 上一轮猫的位置
                if preCat != 0 && winner[mouse][preCat][1] == 0 { // 猫无法移动到洞中
                    preStates = append(preStates, [2]int{mouse, preCat})
                }
            }
        } else { // 当前轮到猫移动
            for _, preMouse := range g[mouse] { // 上一轮鼠的位置
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

    // 鼠在节点 1，猫在节点 2，当前轮到鼠移动
    return winner[1][2][0] // 返回最终谁赢了
}
```

#### 复杂度分析

- 时间复杂度：$O(n^3)$，其中 $n$ 是 $graph$ 的长度。有 $O(n^2)$ 个状态，每个状态需要遍历 $O(n)$ 个相邻的状态。
- 空间复杂度：$O(n^2)$。

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
