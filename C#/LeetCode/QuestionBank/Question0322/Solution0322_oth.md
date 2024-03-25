### [【视频】教你一步步思考动态规划！附题单！（Python/Java/C++/Go）](https://leetcode.cn/problems/coin-change/solutions/2119065/jiao-ni-yi-bu-bu-si-kao-dong-tai-gui-hua-21m5/)

#### 视频讲解

请看[【基础算法精讲 18】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV16Y411v7Y6%2F)。如果这个视频对你有帮助，欢迎一键三连！

#### 一、递归搜索 + 保存计算结果 = 记忆化搜索

##### 代码

```python
class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        @cache
        def dfs(i, c):
            if i < 0:
                return 0 if c == 0 else inf
            if c < coins[i]:
                return dfs(i - 1, c)
            return min(dfs(i - 1, c), dfs(i, c - coins[i]) + 1)
        ans = dfs(len(coins) - 1, amount)
        return ans if ans < inf else -1
```

```java
class Solution {
    private int[] coins;
    private int[][] memo;

    public int coinChange(int[] coins, int amount) {
        this.coins = coins;
        int n = coins.length;
        memo = new int[n][amount + 1];
        for (int[] row : memo)
            Arrays.fill(row, -1); // -1 表示没有访问过
        int ans = dfs(n - 1, amount);
        return ans < Integer.MAX_VALUE / 2 ? ans : -1;
    }

    private int dfs(int i, int c) {
        if (i < 0) return c == 0 ? 0 : Integer.MAX_VALUE / 2; // 除 2 是防止下面 + 1 溢出
        if (memo[i][c] != -1) return memo[i][c];
        if (c < coins[i]) return memo[i][c] = dfs(i - 1, c);
        return memo[i][c] = Math.min(dfs(i - 1, c), dfs(i, c - coins[i]) + 1);
    }
}
```

```c++
class Solution {
public:
    int coinChange(vector<int> &coins, int amount) {
        int n = coins.size(), memo[n][amount + 1];
        memset(memo, -1, sizeof(memo)); // -1 表示没有访问过
        function<int(int, int)> dfs = [&](int i, int c) -> int {
            if (i < 0) return c == 0 ? 0 : INT_MAX / 2; // 除 2 是防止下面 + 1 溢出
            int &res = memo[i][c];
            if (res != -1) return res;
            if (c < coins[i]) return res = dfs(i - 1, c);
            return res = min(dfs(i - 1, c), dfs(i, c - coins[i]) + 1);
        };
        int ans = dfs(n - 1, amount);
        return ans < INT_MAX / 2 ? ans : -1;
    }
};
```

```go
func coinChange(coins []int, amount int) int {
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
                return 0
            }
            return math.MaxInt / 2 // 除 2 是防止下面 + 1 溢出
        }
        p := &memo[i][c]
        if *p != -1 {
            return *p
        }
        defer func() { *p = res }()
        if c < coins[i] {
            return dfs(i-1, c)
        }
        return min(dfs(i-1, c), dfs(i, c-coins[i])+1)
    }
    ans := dfs(n-1, amount)
    if ans < math.MaxInt/2 {
        return ans
    }
    return -1
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n\cdot\textit{amount})$，其中 $n$ 为 $\textit{coins}$ 的长度。
- 空间复杂度：$\mathcal{O}(n\cdot\textit{amount})$。

#### 二、1:1 翻译成递推

##### 代码

```python
class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        n = len(coins)
        f = [[inf] * (amount + 1) for _ in range(n + 1)]
        f[0][0] = 0
        for i, x in enumerate(coins):
            for c in range(amount + 1):
                if c < x:
                    f[i + 1][c] = f[i][c]
                else:
                    f[i + 1][c] = min(f[i][c], f[i + 1][c - x] + 1)
        ans = f[n][amount]
        return ans if ans < inf else -1
```

```java
class Solution {
    public int coinChange(int[] coins, int amount) {
        int n = coins.length;
        int[][] f = new int[n + 1][amount + 1];
        Arrays.fill(f[0], Integer.MAX_VALUE / 2); // 除 2 是防止下面 + 1 溢出
        f[0][0] = 0;
        for (int i = 0; i < n; ++i)
            for (int c = 0; c <= amount; ++c)
                if (c < coins[i]) f[i + 1][c] = f[i][c];
                else f[i + 1][c] = Math.min(f[i][c], f[i + 1][c - coins[i]] + 1);
        int ans = f[n][amount];
        return ans < Integer.MAX_VALUE / 2 ? ans : -1;
    }
}
```

```c++
class Solution {
public:
    int coinChange(vector<int> &coins, int amount) {
        int n = coins.size(), f[n + 1][amount + 1];
        memset(f, 0x3f, sizeof(f));
        f[0][0] = 0;
        for (int i = 0; i < n; ++i)
            for (int c = 0; c <= amount; ++c)
                if (c < coins[i]) f[i + 1][c] = f[i][c];
                else f[i + 1][c] = min(f[i][c], f[i + 1][c - coins[i]] + 1);
        int ans = f[n][amount];
        return ans < 0x3f3f3f3f ? ans : -1;
    }
};
```

```go
func coinChange(coins []int, amount int) int {
    n := len(coins)
    f := make([][]int, n+1)
    for i := range f {
        f[i] = make([]int, amount+1)
    }
    for j := range f[0] {
        f[0][j] = math.MaxInt / 2 // 除 2 是防止下面 + 1 溢出
    }
    f[0][0] = 0
    for i, x := range coins {
        for c := 0; c <= amount; c++ {
            if c < x {
                f[i+1][c] = f[i][c]
            } else {
                f[i+1][c] = min(f[i][c], f[i+1][c-x]+1)
            }
        }
    }
    ans := f[n][amount]
    if ans < math.MaxInt/2 {
        return ans
    }
    return -1
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n\cdot\textit{amount})$，其中 $n$ 为 $\textit{coins}$ 的长度。
- 空间复杂度：$\mathcal{O}(n\cdot\textit{amount})$。

#### 三、空间优化：两个数组（滚动数组）

##### 代码

```python
class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        n = len(coins)
        f = [[inf] * (amount + 1) for _ in range(2)]
        f[0][0] = 0
        for i, x in enumerate(coins):
            for c in range(amount + 1):
                if c < x:
                    f[(i + 1) % 2][c] = f[i % 2][c]
                else:
                    f[(i + 1) % 2][c] = min(f[i % 2][c], f[(i + 1) % 2][c - x] + 1)
        ans = f[n % 2][amount]
        return ans if ans < inf else -1
```

```java
class Solution {
    public int coinChange(int[] coins, int amount) {
        int n = coins.length;
        int[][] f = new int[2][amount + 1];
        Arrays.fill(f[0], Integer.MAX_VALUE / 2); // 除 2 是防止下面 + 1 溢出
        f[0][0] = 0;
        for (int i = 0; i < n; ++i)
            for (int c = 0; c <= amount; ++c)
                if (c < coins[i]) f[(i + 1) % 2][c] = f[i % 2][c];
                else f[(i + 1) % 2][c] = Math.min(f[i % 2][c], f[(i + 1) % 2][c - coins[i]] + 1);
        int ans = f[n % 2][amount];
        return ans < Integer.MAX_VALUE / 2 ? ans : -1;
    }
}
```

```c++
class Solution {
public:
    int coinChange(vector<int> &coins, int amount) {
        int n = coins.size(), f[2][amount + 1];
        memset(f, 0x3f, sizeof(f));
        f[0][0] = 0;
        for (int i = 0; i < n; ++i)
            for (int c = 0; c <= amount; ++c)
                if (c < coins[i]) f[(i + 1) % 2][c] = f[i % 2][c];
                else f[(i + 1) % 2][c] = min(f[i % 2][c], f[(i + 1) % 2][c - coins[i]] + 1);
        int ans = f[n % 2][amount];
        return ans < 0x3f3f3f3f ? ans : -1;
    }
};
```

```go
func coinChange(coins []int, amount int) int {
    n := len(coins)
    f := make([][]int, 2)
    for i := range f {
        f[i] = make([]int, amount+1)
    }
    for j := range f[0] {
        f[0][j] = math.MaxInt / 2 // 除 2 是防止下面 + 1 溢出
    }
    f[0][0] = 0
    for i, x := range coins {
        for c := 0; c <= amount; c++ {
            if c < x {
                f[(i+1)%2][c] = f[i%2][c]
            } else {
                f[(i+1)%2][c] = min(f[i%2][c], f[(i+1)%2][c-coins[i]]+1)
            }
        }
    }
    ans := f[n%2][amount]
    if ans < math.MaxInt/2 {
        return ans
    }
    return -1
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n\cdot\textit{amount})$，其中 $n$ 为 $\textit{coins}$ 的长度。
- 空间复杂度：$\mathcal{O}(\textit{amount})$。

#### 四、空间优化：一个数组

##### 代码

```python
class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        f = [0] + [inf] * amount
        for x in coins:
            for c in range(x, amount + 1):
                f[c] = min(f[c], f[c - x] + 1)
        ans = f[amount]
        return ans if ans < inf else -1
```

```java
class Solution {
    public int coinChange(int[] coins, int amount) {
        int[] f = new int[amount + 1];
        Arrays.fill(f, Integer.MAX_VALUE / 2); // 除 2 是防止下面 + 1 溢出
        f[0] = 0;
        for (int x : coins)
            for (int c = x; c <= amount; ++c)
                f[c] = Math.min(f[c], f[c - x] + 1);
        int ans = f[amount];
        return ans < Integer.MAX_VALUE / 2 ? ans : -1;
    }
}
```

```c++
class Solution {
public:
    int coinChange(vector<int> &coins, int amount) {
        int f[amount + 1];
        memset(f, 0x3f, sizeof(f));
        f[0] = 0;
        for (int x : coins)
            for (int c = x; c <= amount; ++c)
                f[c] = min(f[c], f[c - x] + 1);
        int ans = f[amount];
        return ans < 0x3f3f3f3f ? ans : -1;
    }
};
```

```go
func coinChange(coins []int, amount int) int {
    f := make([]int, amount+1)
    for i := range f {
        f[i] = math.MaxInt / 2 // 除 2 是防止下面 + 1 溢出
    }
    f[0] = 0
    for _, x := range coins {
        for c := x; c <= amount; c++ {
            f[c] = min(f[c], f[c-x]+1)
        }
    }
    ans := f[amount]
    if ans < math.MaxInt/2 {
        return ans
    }
    return -1
}
```

##### 复杂度分析

- 时间复杂度：$\mathcal{O}(n\cdot\textit{amount})$，其中 $n$ 为 $\textit{coins}$ 的长度。
- 空间复杂度：$\mathcal{O}(\textit{amount})$。

#### 分类题单

- [滑动窗口（定长/不定长/多指针）](https://leetcode.cn/circle/discuss/0viNMK/)
- [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
- [单调栈（矩形系列/字典序最小/贡献法）](https://leetcode.cn/circle/discuss/9oZFK9/)
- [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
- [位运算（基础/性质/拆位/试填/恒等式/贪心/脑筋急转弯）](https://leetcode.cn/circle/discuss/dHn9Vk/)
- [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
- [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
