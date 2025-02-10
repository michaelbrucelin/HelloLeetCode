### [【宫水三叶】动态规划运用题](https://leetcode.cn/problems/cat-and-mouse/solutions/1190693/gong-shui-san-xie-dong-tai-gui-hua-yun-y-0bx1/)

#### 动态规划

数据范围只有 $50$，使得本题的难度大大降低。

**定义 $f[k][i][j]$ 为当前进行了 $k$ 步，老鼠所在位置为 $i$，猫所在的位置为 $j$ 时，最终的获胜情况（$0$ 为平局，$1$ 和 $2$ 分别代表老鼠和猫获胜），起始我们让所有的 $f[k][i][j]=-1$（为无效值），最终答案为 $f[0][1][2]$。**

不失一般性的考虑 $f[i][j][k]$ 该如何转移，根据题意，将当前所在位置 $i$ 和 $j$ 结合「游戏结束，判定游戏」的规则来分情况讨论：

- 若 $i=0$，说明老鼠位于洞中，老鼠获胜，此时有 $f[k][i][j]=1$；
- 若 $i=j$，说明两者为与同一位置，猫获胜，此时有 $f[k][i][j]=2$；
- 考虑如何定义平局，即 $f[k][i][j]=0$ 的情况？

我们最多有 $n$ 个位置，因此 $(i,j)$ 位置对组合数最多为 $n^2$ 种，然后 $k$ 其实代表的是老鼠先手还是猫先手，共有 $2$ 种可能，因此状态数量数据有明确上界为 $2 \times n^2$。

所以我们可以设定 $k$ 的上界为 $2 \times n^2$（抽屉原理，走超过 $2 \times n^2$ 步，必然会有相同的局面出现过至少两次），但是这样的计算量为 $2 \times 50^2 \times 50 \times 50=1.25 \times 10^7$，有 `TLE` 风险，转移过程增加剪枝，可以过。

而更小的 $k$ 值需要证明：在最优策略中，相同局面（状态）成环的最大长度的最小值为 $k$。

题目规定轮流移动，且只能按照 $graph$ 中存在的边进行移动。

1. 如果当前 $k$ 为偶数（该回合老鼠移动），此时所能转移所有点为 $f[k+1][ne][j]$，其中 $ne$ 为 $i$ 所能到达的点。由于采用的是最优移动策略，因此 $f[k][i][j]$ 会优先往 $f[k+1][ne][j]=1$ 的点移动（自身获胜），否则往 $f[k+1][ne][j]=0$ 的点移动（平局），再否则才是往 $f[k+1][ne][j]=2$ 的点移动（对方获胜）；
2. 同理，如果当前 $k$ 为奇数（该回合猫移动），此时所能转移所有点为 $f[k+1][i][ne]$，其中 $ne$ 为 $j$ 所能到达的点。由于采用的是最优移动策略，因此 $f[k][i][j]$ 会优先往 $f[k+1][i][ne]=2$ 的点移动（自身获胜），否则往 $f[k+1][i][ne]=0$ 的点移动（平局），再否则才是往 $f[k+1][i][ne]=1$ 的点移动（对方获胜）。

使用该转移优先级进行递推即可，为了方便我们使用「记忆化搜索」的方式来实现动态规划。

注意，该优先级转移其实存在「贪心」决策，但证明这样的决策会使得「最坏情况最好」是相对容易的，而证明存在更小的 $k$ 值才是本题难点。

> 一些细节：由于本身就要对动规数组进行无效值的初始化，为避免每个样例都 `new` 大数组，我们使用 `static` 来修饰大数组，可以有效减少一点时间（不使用 `static` 的话，`N` 只能取到 $51$）。

代码：

```java
class Solution {
    static int N = 55;
    static int[][][] f = new int[2 * N * N][N][N];
    int[][] g;
    int n;
    public int catMouseGame(int[][] graph) {
        g = graph;
        n = g.length;
        for (int k = 0; k < 2 * n * n; k++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    f[k][i][j] = -1;
                }
            }
        }
        return dfs(0, 1, 2);
    }
    // 0:draw / 1:mouse / 2:cat
    int dfs(int k, int a, int b) {
        int ans = f[k][a][b];
        if (a == 0) ans = 1;
        else if (a == b) ans = 2;
        else if (k >= 2 * n * n) ans = 0;
        else if (ans == -1) {
            if (k % 2 == 0) { // mouse
                boolean win = false, draw = false;
                for (int ne : g[a]) {
                    int t = dfs(k + 1, ne, b);
                    if (t == 1) win = true;
                    else if (t == 0) draw = true;
                    if (win) break;
                }
                if (win) ans = 1;
                else if (draw) ans = 0;
                else ans = 2;
            } else { // cat
                boolean win = false, draw = false;
                for (int ne : g[b]) {
                    if (ne == 0) continue;
                    int t = dfs(k + 1, a, ne);
                    if (t == 2) win = true;
                    else if (t == 0) draw = true;
                    if (win) break;
                }
                if (win) ans = 2;
                else if (draw) ans = 0;
                else ans = 1;
            }
        }
        f[k][a][b] = ans;
        return ans;
    }
}
```

- 时间复杂度：状态的数量级为 $n^4$，可以确保每个状态只会被计算一次。复杂度为 $O(n^4)$
- 空间复杂度：$O(n^4)$
