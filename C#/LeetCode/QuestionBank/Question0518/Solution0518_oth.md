### [【视频】完全背包：从记忆化搜索到递推，附题单！（Python/Java/C++/Go）](https://leetcode.cn/problems/coin-change-ii/solutions/2706227/shi-pin-wan-quan-bei-bao-cong-ji-yi-hua-o3ew0/)

#### 视频讲解

请看[【基础算法精讲 18】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV16Y411v7Y6%2F)。如果这个视频对你有帮助，欢迎一键三连！

#### 思路

本题思路和 [322. 零钱兑换](https://leetcode.cn/problems/coin-change/) 一样，定义 $\textit{dfs}(i,c)$ 表示用前 $i$ 种硬币组成金额 $c$ 的方案数，考虑「选或不选」，有：

- 不再继续选第 $i$ 种硬币：$\textit{dfs}(i-1,c)$。
- 继续选一枚第 $i$ 种硬币：$\textit{dfs}(i,c-\textit{coins}[i])$。

二者相加得

$$\textit{dfs}(i,c) = \textit{dfs}(i-1,c) + \textit{dfs}(i,c-\textit{coins}[i])$$

**递归边界：** $\textit{dfs}(-1,0) = 1,\ \textit{dfs}(-1,>0) = 0$
递归入口：$\textit{dfs}(n-1, \textit{amount})$。

#### 一、递归搜索 + 保存计算结果 = 记忆化搜索

##### 代码

```python
class Solution:
    def change(self, amount: int, coins: List[int]) -> int:
        @cache
        def dfs(i: int, c: int) -> int:
            if i < 0:
                return 1 if c == 0 else 0
            if c < coins[i]:
                return dfs(i - 1, c)
            return dfs(i - 1, c) + dfs(i, c - coins[i])
        return dfs(len(coins) - 1, amount)
```

```java
class Solution {
    private int[] coins;
    private int[][] memo;

    public int change(int amount, int[] coins) {
        this.coins = coins;
        int n = coins.length;
        memo = new int[n][amount + 1];
        for (int[] row : memo) {
            Arrays.fill(row, -1); // -1 表示没有访问过
        }
        return dfs(n - 1, amount);
    }

    private int dfs(int i, int c) {
        if (i < 0) {
            return c == 0 ? 1 : 0;
        }
        if (memo[i][c] != -1) { // 之前算过了
            return memo[i][c];
        }
        if (c < coins[i]) {
            return memo[i][c] = dfs(i - 1, c);
        }
        return memo[i][c] = dfs(i - 1, c) + dfs(i, c - coins[i]);
    }
}
```

```c++
class Solution {
public:
    int change(int amount, vector<int> &coins) {
        int n = coins.size();
        vector<vector<int>> memo(n, vector<int>(amount + 1, -1)); // -1 表示没有访问过
        function<int(int, int)> dfs = [&](int i, int c) -> int {
            if (i < 0) {
                return c == 0 ? 1 : 0;
            }
            int &res = memo[i][c]; // 注意这里是引用
            if (res != -1) { // 之前算过了
                return res;
            }
            if (c < coins[i]) {
                return res = dfs(i - 1, c);
            }
            return res = dfs(i - 1, c) + dfs(i, c - coins[i]);
        };
        return dfs(n - 1, amount);
    }
};
```

```go
func change(amount int, coins []int) int {
    n := len(coins)
    memo := make([][]int, n)
    for i := range memo {
        memo[i] = make([]int, amount+1)
        for j := range memo[i] {
            memo[i][j] = -1 // -1 表示没有访问过
        }
    }
    var dfs func(int, int) int
    dfs = func(i, c int) (res int) {
        if i < 0 {
            if c == 0 {
                return 1
            }
            return
        }
        p := &memo[i][c]
        if *p != -1 { // 之前算过了
            return *p
        }
        defer func() { *p = res }() // 记忆化
        if c < coins[i] {
            return dfs(i-1, c)
        }
        return dfs(i-1, c) + dfs(i, c-coins[i])
    }
    return dfs(n-1, amount)
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n\cdot\textit{amount})$，其中 $n$ 为 $\textit{coins}$ 的长度。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题状态个数等于 $\mathcal{O}(n\cdot\textit{amount})$，单个状态的计算时间为 $\mathcal{O}(1)$，所以动态规划的时间复杂度为 $\mathcal{O}(n\cdot\textit{amount})$。
- 空间复杂度：$\mathcal{O}(n\cdot\textit{amount})$。

#### 二、1:1 翻译成递推

##### 代码

```python
class Solution:
    def change(self, amount: int, coins: List[int]) -> int:
        n = len(coins)
        f = [[0] * (amount + 1) for _ in range(n + 1)]
        f[0][0] = 1
        for i, x in enumerate(coins):
            for c in range(amount + 1):
                if c < x:
                    f[i + 1][c] = f[i][c]
                else:
                    f[i + 1][c] = f[i][c] + f[i + 1][c - x]
        return f[n][amount]
```

```java
class Solution {
    public int change(int amount, int[] coins) {
        int n = coins.length;
        int[][] f = new int[n + 1][amount + 1];
        f[0][0] = 1;
        for (int i = 0; i < n; i++) {
            for (int c = 0; c <= amount; c++) {
                if (c < coins[i]) {
                    f[i + 1][c] = f[i][c];
                } else {
                    f[i + 1][c] = f[i][c] + f[i + 1][c - coins[i]];
                }
            }
        }
        return f[n][amount];
    }
}
```

```c++
class Solution {
public:
    int change(int amount, vector<int> &coins) {
        int n = coins.size();
        vector<vector<int>> f(n + 1, vector<int>(amount + 1));
        f[0][0] = 1;
        for (int i = 0; i < n; i++) {
            for (int c = 0; c <= amount; c++) {
                if (c < coins[i]) {
                    f[i + 1][c] = f[i][c];
                } else {
                    f[i + 1][c] = f[i][c] + f[i + 1][c - coins[i]];
                }
            }
        }
        return f[n][amount];
    }
};
```

```go
func change(amount int, coins []int) int {
    n := len(coins)
    f := make([][]int, n+1)
    for i := range f {
        f[i] = make([]int, amount+1)
    }
    f[0][0] = 1
    for i, x := range coins {
        for c := 0; c <= amount; c++ {
            if c < x {
                f[i+1][c] = f[i][c]
            } else {
                f[i+1][c] = f[i][c] + f[i+1][c-x]
            }
        }
    }
    return f[n][amount]
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n\cdot\textit{amount})$，其中 $n$ 为 $\textit{coins}$ 的长度。
- 空间复杂度：$\mathcal{O}(n\cdot\textit{amount})$。

#### 三、空间优化

##### 代码

```python
class Solution:
    def change(self, amount: int, coins: List[int]) -> int:
        f = [1] + [0] * amount
        for x in coins:
            for c in range(x, amount + 1):
                f[c] += f[c - x]
        return f[amount]
```

```java
class Solution {
    public int change(int amount, int[] coins) {
        int[] f = new int[amount + 1];
        f[0] = 1;
        for (int x : coins) {
            for (int c = x; c <= amount; c++) {
                f[c] += f[c - x];
            }
        }
        return f[amount];
    }
}
```

```c++
class Solution {
public:
    int change(int amount, vector<int> &coins) {
        vector<int> f(amount + 1);
        f[0] = 1;
        for (int x : coins) {
            for (int c = x; c <= amount; c++) {
                f[c] += f[c - x];
            }
        }
        return f[amount];
    }
};
```

```go
func change(amount int, coins []int) int {
    f := make([]int, amount+1)
    f[0] = 1
    for _, x := range coins {
        for c := x; c <= amount; c++ {
            f[c] += f[c-x]
        }
    }
    return f[amount]
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n\cdot\textit{amount})$，其中 $n$ 为 $\textit{coins}$ 的长度。
- 空间复杂度：$\mathcal{O}(\textit{amount})$。

#### 分类题单

1. [滑动窗口（定长/不定长/多指针）](https://leetcode.cn/circle/discuss/0viNMK/)
1. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
1. [单调栈（矩形系列/字典序最小/贡献法）](https://leetcode.cn/circle/discuss/9oZFK9/)
1. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
1. [位运算（基础/性质/拆位/试填/恒等式/贪心/脑筋急转弯）](https://leetcode.cn/circle/discuss/dHn9Vk/)
1. [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
1. [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
