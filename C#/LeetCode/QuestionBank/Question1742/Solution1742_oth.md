### [三种方法：暴力枚举/前缀和/数位DP（Python/Java/C++/Go）](https://leetcode.cn/problems/maximum-number-of-balls-in-a-box/solutions/3073112/san-chong-fang-fa-bao-li-mei-ju-qian-zhu-kze9/)

#### 方法一：暴力枚举

遍历 $[lowLimit,highLimit]$ 中的每个整数 $i$，计算 $i$ 的数位和 $s$，用数组（或者哈希表）统计 $s$ 的出现次数 $cnt[s]$。

最后返回 $cnt[s]$ 的最大值。

关于数位和，可以转成字符串计算，也可以不断地把 $i$ 除以 $10$ 直到 $0$，例如 $123 \rightarrow 12 \rightarrow 1 \rightarrow 0$，这个过程中把个位数（模 $10$）相加，就是数位和。

```Python
class Solution:
    def countBalls(self, lowLimit: int, highLimit: int) -> int:
        cnt = Counter(
            sum(map(int, str(i))) for i in range(lowLimit, highLimit + 1)
        )
        return max(cnt.values())
```

```Java
class Solution {
    public int countBalls(int lowLimit, int highLimit) {
        int ans = 0;
        int[] cnt = new int[46]; // 99999 的数位和 = 45
        for (int i = lowLimit; i <= highLimit; i++) {
            int s = 0;
            for (int x = i; x > 0; x /= 10) {
                s += x % 10;
            }
            cnt[s]++;
            ans = Math.max(ans, cnt[s]);
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int countBalls(int lowLimit, int highLimit) {
        int cnt[46]{}; // 99999 的数位和 = 45
        for (int i = lowLimit; i <= highLimit; i++) {
            int s = 0;
            for (int x = i; x > 0; x /= 10) {
                s += x % 10;
            }
            cnt[s]++;
        }
        return ranges::max(cnt);
    }
};
```

```Go
func countBalls(lowLimit, highLimit int) (ans int) {
    cnt := [46]int{} // 99999 的数位和 = 45
    for i := lowLimit; i <= highLimit; i++ {
        s := 0
        for x := i; x > 0; x /= 10 {
            s += x % 10
        }
        cnt[s]++
        ans = max(ans, cnt[s])
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$O((highLimit-lowLimit) \log highLimit)$。每个数需要 $O( \log highLimit)$ 的时间计算数位和。
- 空间复杂度：$O(D \log highLimit)$，其中 $D=9$。这是 $cnt$ 需要的空间。

#### 方法二：预处理前缀和

**前置知识**：[前缀和](https://leetcode.cn/problems/range-sum-query-immutable/solution/qian-zhui-he-ji-qi-kuo-zhan-fu-ti-dan-py-vaar/)。

定义 $s[i][j]$ 表示 $[0,i]$ 中的数位和为 $j$ 的数字个数。

那么 $[lowLimit,highLimit]$ 中的数位和为 $j$ 的数字个数为

$$s[highLimit][j]-s[lowLimit-1][j]$$

枚举数位和 $j$，答案为

$$\max\limits_{j=1}^{45} ​s[highLimit][j]-s[lowLimit-1][j]$$

其中 $45$ 是因为在本题数据范围下，$99999$ 的数位和最大，为 $45$。

```Python
s = [[0] * 46]
for i in range(1, 100_001):
    s.append(s[i - 1][:])
    s[i][sum(map(int, str(i)))] += 1

class Solution:
    def countBalls(self, lowLimit: int, highLimit: int) -> int:
        return max(s[highLimit][j] - s[lowLimit - 1][j] for j in range(1, len(s[0])))
```

```Java
class Solution {
    static int[][] s = new int[100_001][46];

    static {
        for (int i = 1; i < s.length; i++) {
            System.arraycopy(s[i - 1], 0, s[i], 0, 46);
            int sum = 0;
            for (int x = i; x > 0; x /= 10) {
                sum += x % 10;
            }
            s[i][sum]++;
        }
    }

    public int countBalls(int lowLimit, int highLimit) {
        int ans = 0;
        for (int j = 1; j < s[0].length; j++) {
            ans = Math.max(ans, s[highLimit][j] - s[lowLimit - 1][j]);
        }
        return ans;
    }
}
```

```C++
const int MX = 100'001;
array<int, 46> s[MX];

auto init = [] {
    for (int i = 1; i < MX; i++) {
        s[i] = s[i - 1];
        int sum = 0;
        for (int x = i; x > 0; x /= 10) {
            sum += x % 10;
        }
        s[i][sum]++;
    }
    return 0;
}();

class Solution {
public:
    int countBalls(int lowLimit, int highLimit) {
        int ans = 0;
        for (int j = 1; j < s[0].size(); j++) {
            ans = max(ans, s[highLimit][j] - s[lowLimit - 1][j]);
        }
        return ans;
    }
};
```

```Go
var s [100_001][46]int

func init() {
    for i := 1; i < len(s); i++ {
        s[i] = s[i-1]
        sum := 0
        for x := i; x > 0; x /= 10 {
            sum += x % 10
        }
        s[i][sum]++
    }
}

func countBalls(lowLimit, highLimit int) (ans int) {
    for j := 1; j < len(s[0]); j++ {
        ans = max(ans, s[highLimit][j]-s[lowLimit-1][j])
    }
    return
}
```

#### 复杂度分析

预处理的时间和空间忽略不计。

- 时间复杂度：$O(D \log highLimit)$，其中 $D=9$。代码用了固定的上界 $45$。
- 空间复杂度：$O(1)$。

## 方法三：数位 DP

**进阶问题**：如果 $highLimit$ 更大，大到 $10^{18}$ 这个数量级，要怎么做？

方法二的做法就行不通了。

本题的进阶做法，是**数位 DP**。

[数位 DP v1.0 模板讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1rS4y1s721%2F%3Ft%3D19m36s)（先看这个）

[数位 DP v2.0 模板讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Fg4y1Q7wv%2F%3Ft%3D31m28s)

**核心思路**：枚举数位和 $j=1,2,3, \dots ,45$，计算 $[lowLimit,highLimit]$ 中的数位和为 $j$ 的数字个数。

根据模板讲解，定义 $dfs(i,j,limitLow,limitHigh)$ 表示构造第 $i$ 位及其之后数位的合法方案数，其余参数的含义为：

- $j$ 表示剩余数字的数位和必须恰好等于 $j$。
- $limitHigh$ 表示当前是否受到了 $limitHigh$ 的约束（我们要构造的数字不能超过 $limitHigh$）。若为真，则第 $i$ 位填入的数字至多为 $limitHigh[i]$，否则至多为 $9$，这个数记作 $hi$。如果在受到约束的情况下填了 $limitHigh[i]$，那么后续填入的数字仍会受到 $limitHigh$ 的约束。例如 $limitHigh=123$，那么 $i=0$ 填的是 $1$ 的话，$i=1$ 的这一位至多填 $2$。
- $limitLow$ 表示当前是否受到了 $limitLow$ 的约束（我们要构造的数字不能低于 $limitLow$）。若为真，则第 $i$ 位填入的数字至少为 $limitLow[i]$，否则至少为 $0$，这个数记作 $lo$。如果在受到约束的情况下填了 $limitLow[i]$，那么后续填入的数字仍会受到 $limitLow$ 的约束。

设 $n$ 为 $highLimit$ 的十进制长度。

**递归终点**：$dfs(n,0,*,*)=1$，表示成功构造出一个合法数字。其余 $dfs(n,j,*,*)=0$。

**递归入口**：$dfs(0,j,true,true)$，表示：

- 从最高位开始枚举。
- 一开始要受到 $lowLimit$ 和 $highLimit$ 的约束（否则就可以随意填了，这肯定不行）。

#### 答疑

**问**：记忆化四个状态有点麻烦，能不能只记忆化 $(i,j)$？

**答**：可以的。比如 $highLimit=234$，我们第一位填 $2$，第二位填 $3$，后面无论怎么递归，都不会重复递归到第一位填 $2$，第二位填 $3$ 的情况，所以不需要记录。对于 $lowLimit$ 也同理。

根据这个例子，我们可以只记录不受到 $lowLimit$ 或 $highLimit$ 约束时的状态 $(i,j)$。或者说，我们记忆化的是 $(i,j,false,false)$，因为其它状态只会递归访问一次，不会重复递归访问。

```Python
class Solution:
    def countBalls(self, lowLimit: int, highLimit: int) -> int:
        high_s = str(highLimit)
        n = len(high_s)
        low_s = str(lowLimit).zfill(n)  # 补前导零，和 high_s 对齐

        @cache
        def dfs(i: int, j: int, limit_low: bool, limit_high: bool) -> int:
            if i == n:
                return 0 if j else 1

            lo = int(low_s[i]) if limit_low else 0
            hi = int(high_s[i]) if limit_high else 9

            res = 0
            for d in range(lo, min(hi, j) + 1):  # 枚举当前数位填 d，但不能超过 j
                res += dfs(i + 1, j - d, limit_low and d == lo, limit_high and d == hi)
            return res

        return max(dfs(0, j, True, True) for j in range(1, 46))
```

```Java
class Solution {
    public int countBalls(int lowLimit, int highLimit) {
        String highS = String.valueOf(highLimit);
        int n = highS.length();
        String lowS = String.valueOf(lowLimit);
        lowS = "0".repeat(n - lowS.length()) + lowS; // 补前导零，和 highS 对齐

        int[][] memo = new int[n][46];
        for (int[] row : memo) {
            Arrays.fill(row, -1);
        }

        int ans = 0;
        for (int j = 1; j <= 45; j++) {
            ans = Math.max(ans, dfs(0, j, true, true, lowS.toCharArray(), highS.toCharArray(), memo));
        }
        return ans;
    }

    private int dfs(int i, int j, boolean limitLow, boolean limitHigh, char[] lowS, char[] highS, int[][] memo) {
        if (i == highS.length) {
            return j == 0 ? 1 : 0;
        }
        if (!limitLow && !limitHigh && memo[i][j] != -1) {
            return memo[i][j];
        }

        int lo = limitLow ? lowS[i] - '0' : 0;
        int hi = limitHigh ? highS[i] - '0' : 9;

        int res = 0;
        for (int d = lo; d <= Math.min(hi, j); d++) { // 枚举当前数位填 d，但不能超过 j
            res += dfs(i + 1, j - d, limitLow && d == lo, limitHigh && d == hi, lowS, highS, memo);
        }

        if (!limitLow && !limitHigh) {
            memo[i][j] = res;
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    int countBalls(int lowLimit, int highLimit) {
        string high_s = to_string(highLimit);
        int n = high_s.size();
        string low_s = to_string(lowLimit);
        low_s = string(n - low_s.size(), '0') + low_s; // 补前导零，和 high_s 对齐

        vector memo(n, vector<int>(46, -1));
        auto dfs = [&](this auto&& dfs, int i, int j, bool limit_low, bool limit_high) -> int {
            if (i == n) {
                return j == 0;
            }
            if (!limit_low && !limit_high && memo[i][j] != -1) {
                return memo[i][j];
            }

            int lo = limit_low ? low_s[i] - '0' : 0;
            int hi = limit_high ? high_s[i] - '0' : 9;

            int res = 0;
            for (int d = lo; d <= min(hi, j); d++) { // 枚举当前数位填 d，但不能超过 j
                res += dfs(i + 1, j - d, limit_low && d == lo, limit_high && d == hi);
            }

            if (!limit_low && !limit_high) {
                memo[i][j] = res;
            }
            return res;
        };

        int ans = 0;
        for (int j = 1; j <= 45; j++) {
            ans = max(ans, dfs(0, j, true, true));
        }
        return ans;
    }
};
```

```Go
func countBalls(lowLimit, highLimit int) (ans int) {
    highS := strconv.Itoa(highLimit)
    n := len(highS)
    lowS := strconv.Itoa(lowLimit)
    lowS = strings.Repeat("0", n-len(lowS)) + lowS // 补前导零，和 num2 对齐

    memo := make([][46]int, n)
    for i := range memo {
        for j := range memo[i] {
            memo[i][j] = -1
        }
    }
    var dfs func(int, int, bool, bool) int
    dfs = func(i, j int, limitLow, limitHigh bool) (res int) {
        if i == n {
            if j == 0 { // 合法
                return 1
            }
            return
        }

        if !limitLow && !limitHigh {
            p := &memo[i][j]
            if *p >= 0 {
                return *p
            }
            defer func() { *p = res }()
        }

        lo := 0
        if limitLow {
            lo = int(lowS[i] - '0')
        }
        hi := 9
        if limitHigh {
            hi = int(highS[i] - '0')
        }

        for d := lo; d <= min(hi, j); d++ { // 枚举当前数位填 d，但不能超过 j
            res += dfs(i+1, j-d, limitLow && d == lo, limitHigh && d == hi)
        }
        return
    }

    for j := 1; j <= 45; j++ {
        ans = max(ans, dfs(0, j, true, true))
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$O(D^2 \log^2highLimit)$，其中 $D=10$。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题 $i$ 有 $O( \log highLimit)$ 个，$j$ 有 $O(D \log highLimit)$ 个（代码固定为 $45$），所以状态个数等于 $O(D \log^2highLimit)$，单个状态的计算时间为 $O(D)$，所以总的时间复杂度为 $O(D^2 \log^2highLimit)$。
- 空间复杂度：$O(D \log^2highLimit)$。保存多少状态，就需要多少空间。

更多相似题目，见下面动态规划题单中的「**十、数位 DP**」。

## 分类题单

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
