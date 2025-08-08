### [概率 DP（Python/Java/C++/Go）](https://leetcode.cn/problems/soup-servings/solutions/3745893/gai-lu-dppythonjavacgo-by-endlesscheng-25av/)

#### 一、分析

本题 $n\le 10^9$，看上去非常大。

一开始汤 $A$ 和汤 $B$ 都是 $n$ 毫升。每回合从 $A$ 中平均取 $\dfrac{100+75+50+25}{4}=62.5$ 毫升，从 $B$ 中平均取 $\dfrac{0+25+50+75}{4}=37.5$ 毫升。

相对来说，每回合 $A$ 比 $B$ 期望减少 $62.5-37.5=25$ 毫升。$n$ 越大，回合数越多，$A$ 相比 $B$ 期望减少的量越多，$A$ 先取完（先比 $B$ 减到 $\le 0$）的概率越大。

注意本题的这句话：

- 返回值在正确答案 $10^{-5}$ 的范围内将被认为是正确的。

换句话说，如果正确答案 $\ge 1-10^{-5}$，返回值可以等于 $1$。

编程计算发现，当 $n\ge 4451$ 时，正确答案 $\ge 1-10^{-5}$，此时可以直接返回 $1$。

所以本题实际的数据范围只有 $n\le 4450$。

#### 二、寻找子问题

定义目标事件：汤 $A$ 先于 $B$ 耗尽，或者两种汤在同一回合耗尽（此时只计一半的权重）。

比如 $n=200$：

1. 从汤 $A$ 取 $100$ 毫升，从汤 $B$ 取 $0$ 毫升。问题变成两种汤的剩余量分别为 $100$ 毫升和 $200$ 毫升时，目标事件发生的概率。
2. 从汤 $A$ 取 $75$ 毫升，从汤 $B$ 取 $25$ 毫升。问题变成两种汤的剩余量分别为 $125$ 毫升和 $175$ 毫升时，目标事件发生的概率。
3. 从汤 $A$ 取 $50$ 毫升，从汤 $B$ 取 $50$ 毫升。问题变成两种汤的剩余量分别为 $150$ 毫升和 $150$ 毫升时，目标事件发生的概率。
4. 从汤 $A$ 取 $25$ 毫升，从汤 $B$ 取 $75$ 毫升。问题变成两种汤的剩余量分别为 $175$ 毫升和 $125$ 毫升时，目标事件发生的概率。

这些问题都是**和原问题相似的、规模更小的子问题**，可以用**递归**解决。

#### 三、状态定义与状态转移方程

根据「寻找子问题」，定义 $dfs(a,b)$ 表示两种汤的剩余量分别为 $a$ 毫升和 $b$ 毫升时，目标事件发生的概率。

在当前回合，我们**等概率**地选择以下四种操作中的一种执行：

1. 从汤 $A$ 取 $100$ 毫升，从汤 $B$ 取 $0$ 毫升。问题变成两种汤的剩余量分别为 $a-100$ 毫升和 $b$ 毫升时，目标事件发生的概率，即 $dfs(a-100,b)$。
2. 从汤 $A$ 取 $75$ 毫升，从汤 $B$ 取 $25$ 毫升。问题变成两种汤的剩余量分别为 $a-75$ 毫升和 $b-25$ 毫升时，目标事件发生的概率，即 $dfs(a-75,b-25)$。
3. 从汤 $A$ 取 $50$ 毫升，从汤 $B$ 取 $50$ 毫升。问题变成两种汤的剩余量分别为 $a-50$ 毫升和 $b-50$ 毫升时，目标事件发生的概率，即 $dfs(a-50,b-50)$。
4. 从汤 $A$ 取 $25$ 毫升，从汤 $B$ 取 $75$ 毫升。问题变成两种汤的剩余量分别为 $a-25$ 毫升和 $b-75$ 毫升时，目标事件发生的概率，即 $dfs(a-25,b-75)$。

在当前回合，上述四种操作互斥且**等概率**地被选择，因此目标事件发生的概率为四个后续状态的平均值，即

$$dfs(a,b)=\dfrac{1}{4}[dfs(a-100,b)+dfs(a-75,b-25)+dfs(a-50,b-50)+dfs(a-25,b-75)]$$

**递归边界**：

- 如果 $a\le 0$ 且 $b\le 0$，根据题目要求，返回 $0.5$。
- 否则如果 $a\le 0$，返回 $1$。
- 否则如果 $b\le 0$，返回 $0$。

**递归入口**：$dfs(n,n)$，即答案。

对于除了 $Python$ 以外的语言，我们用数组记录状态值，但很多状态我们是访问不到的，比如 $n-1$ 毫升，这会造成大量空间的浪费。由于本题取出的毫升数均为 $25$ 的倍数，我们可以把 $0,25,50,75,100$ 均除以 $25$，得到 $0,1,2,3,4$，相当于份数，每份 $25$ 毫升。相应地，把 $n$ 改成 $\lceil\dfrac{n}{25}\rceil $，也表示能取出的份数（最后剩余的不足 $25$ 的量视作一份，所以是上取整）。根据 [上取整下取整转换公式的证明](https://leetcode.cn/link/?target=https%3A%2F%2Fzhuanlan.zhihu.com%2Fp%2F1890356682149838951)，$\lceil\dfrac{n}{25}\rceil =\lfloor\dfrac{n+24}{25}\rfloor $。

#### 四、递归搜索 $+$ 保存递归返回值 $=$ 记忆化搜索

执行一次操作 $2$ 和一次操作 $4$，会让 $a$ 和 $b$ 均减少 $100$；执行两次操作 $3$，也会让 $a$ 和 $b$ 均减少 $100$。这两种方式都会递归到 $dfs(a-100,b-100)$，这会导致我们重复计算同一个状态。

考虑到整个递归过程中有大量重复递归调用（递归入参相同）。由于递归函数没有副作用，同样的入参无论计算多少次，算出来的结果都是一样的，因此可以用**记忆化搜索**来优化：

- 如果一个状态（递归入参）是第一次遇到，那么可以在返回前，把状态及其结果记到一个 $memo$ 数组中。
- 如果一个状态不是第一次遇到（$memo$ 中保存的结果不等于 $memo$ 的初始值），那么可以直接返回 $memo$ 中保存的结果。

**注意**：$memo$ 数组的**初始值**一定不能等于要记忆化的值！例如初始值设置为 $0$，并且要记忆化的 $dfs(a,b)$ 也等于 $0$，那就没法判断 $0$ 到底表示第一次遇到这个状态，还是表示之前遇到过了，从而导致记忆化失效。一般把初始值设置为 $-1$。本题由于计算结果大于 $0$，memo 数组可以初始化成 $0$。

> $Python$ 用户可以无视上面这段，直接用 `@cache` 装饰器。

具体请看视频讲解 [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)。

```Python
class Solution:
    def soupServings(self, n: int) -> float:
        if n >= 4451:
            return 1

        @cache
        def dfs(a: int, b: int) -> float:
            if a <= 0 and b <= 0:
                return 0.5
            if a <= 0:
                return 1.0
            if b <= 0:
                return 0.0
            return (dfs(a - 100, b) + dfs(a - 75, b - 25) + dfs(a - 50, b - 50) + dfs(a - 25, b - 75)) / 4

        return dfs(n, n)
```

```Java
class Solution {
    public double soupServings(int n) {
        if (n >= 4451) {
            return 1;
        }

        n = (n + 24) / 25;
        double[][] memo = new double[n + 1][n + 1];
        return dfs(n, n, memo);
    }

    private double dfs(int a, int b, double[][] memo) {
        if (a <= 0 && b <= 0) {
            return 0.5;
        }
        if (a <= 0) {
            return 1.0;
        }
        if (b <= 0) {
            return 0.0;
        }
        if (memo[a][b] == 0) { // 没有计算过
            memo[a][b] = (dfs(a - 4, b, memo) + dfs(a - 3, b - 1, memo) + dfs(a - 2, b - 2, memo) + dfs(a - 1, b - 3, memo)) / 4;
        }
        return memo[a][b];
    }
}
```

```C++
class Solution {
public:
    double soupServings(int n) {
        if (n >= 4451) {
            return 1;
        }

        n = (n + 24) / 25;
        vector memo(n + 1, vector<double>(n + 1));

        auto dfs = [&](this auto&& dfs, int a, int b) -> double {
            if (a <= 0 && b <= 0) {
                return 0.5;
            }
            if (a <= 0) {
                return 1.0;
            }
            if (b <= 0) {
                return 0.0;
            }
            double& res = memo[a][b]; // 注意这里是引用
            if (res == 0) { // 没有计算过
                res = (dfs(a - 4, b) + dfs(a - 3, b - 1) + dfs(a - 2, b - 2) + dfs(a - 1, b - 3)) / 4;
            }
            return res;
        };

        return dfs(n, n);
    }
};
```

```Go
func soupServings(n int) float64 {
    if n >= 4451 {
        return 1
    }

    n = (n + 24) / 25
    memo := make([][]float64, n+1)
    for i := range memo {
        memo[i] = make([]float64, n+1)
    }

    var dfs func(a, b int) float64
    dfs = func(a, b int) float64 {
        if a <= 0 && b <= 0 {
            return 0.5
        }
        if a <= 0 {
            return 1
        }
        if b <= 0 {
            return 0
        }
        p := &memo[a][b]
        if *p == 0 { // 没有计算过
            *p = (dfs(a-4, b) + dfs(a-3, b-1) + dfs(a-2, b-2) + dfs(a-1, b-3)) / 4
        }
        return *p
    }

    return dfs(n, n)
}
```

#### 复杂度分析

- 时间复杂度：$O((min(n,U)/L)^2)$，其中 $U=4450$，L=25。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times $ 单个状态的计算时间。本题状态个数等于 $O((min(n,U)/L)^2)$，单个状态的计算时间为 $O(1)$，所以总的时间复杂度为 $O((min(n,U)/L)^2)$。
- 空间复杂度：$O((min(n,U)/L)^2)$。保存多少状态，就需要多少空间。

#### 专题训练

见下面动态规划题单的「**十五、概率/期望 DP**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/基环树/最短路/最小生成树/网络流）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/划分/状态机/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
