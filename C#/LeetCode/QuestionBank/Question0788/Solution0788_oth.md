### [数位 DP 通用模板（Python/Java/C++/Go）](https://leetcode.cn/problems/rotated-digits/solutions/1847409/by-endlesscheng-9b96/)

[视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1rS4y1s721)，从 19:30 开始（基于题目 [2376\. 统计特殊整数](https://leetcode.cn/problems/count-special-integers/)）。
讲了数位 $DP$ 的通用模板，以及如何使用该模板秒杀相关困难题目。
讲完题目后还讲了一些上分的训练技巧。

---

根据题意，好数中不能有 $3,4,7$，且至少包含 $2,5,6,9$ 中的一个。

将 $n$ 转换成字符串 $s$，定义 $f(i,hasDiff,isLimit,isNum)$ 表示构造从左往右第 $i$ 位及其之后数位的合法方案数，其余参数的含义为：

- $hasDiff$ 表示前面填的数字是否包含 $2,5,6,9$（至少一个）。
- $isLimit$ 表示当前是否受到了 $n$ 的约束。若为真，则第 $i$ 位填入的数字至多为 $s[i]$，否则可以是 $9$。如果在受到约束的情况下填了 $s[i]$，那么后续填入的数字仍会受到 $n$ 的约束。
- $isNum$ 表示 $i$ 前面的数位是否填了数字。若为假，则当前位可以跳过（不填数字），或者要填入的数字至少为 $1$；若为真，则要填入的数字可以从 $0$ 开始。

后面两个参数可适用于其它数位 $DP$ 题目。

枚举要填入的数字，具体实现逻辑见代码。**对于本题来说，由于前导零对答案无影响，$isNum$ 可以省略。**

下面代码中 $Java/C++/Go$ 只需要记忆化 $(i,hasDiff)$ 这个状态，因为：

1. 对于一个固定的 $(i,hasDiff)$，这个状态受到 $isLimit$ 的约束在整个递归过程中至多会出现一次，没必要记忆化。比如 $n=1234$，当 $i=2$ 的时候，前面可以填 $10,11,12$ 等等，如果受到 $isLimit$ 的约束，就说明前面填的是 $12$。「当 $i=2$ 的时候，前面填的是 12」这件事情，在整个递归中只会发生一次。
2. 另外，如果只记忆化 $(i,hasDiff)$，dp 数组的含义就变成**在不受到约束时**的合法方案数，所以要在 `!isLimit` 成立时才去记忆化。接着上面的例子，在前面填 $12$ 的时候，下一位填的数字不能超过 $3$，因此算出来的结果是不能套用到前面填的是 $10,11$ 这些数字上面的。

```Python
DIFFS = (0, 0, 1, -1, -1, 1, 1, -1, 0, 1)

class Solution:
    def rotatedDigits(self, n: int) -> int:
        s = str(n)
        @cache
        def f(i: int, has_diff: bool, is_limit: bool) -> int:
            if i == len(s):
                return has_diff  # 只有包含 2/5/6/9 才算一个好数
            res = 0
            up = int(s[i]) if is_limit else 9
            for d in range(0, up + 1):  # 枚举要填入的数字 d
                if DIFFS[d] != -1:  # d 不是 3/4/7
                    res += f(i + 1, has_diff or DIFFS[d], is_limit and d == up)
            return res
        return f(0, False, True)
```

```Java
class Solution {
    private static int[] DIFFS = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};

    public int rotatedDigits(int n) {
        char[] s = Integer.toString(n).toCharArray();
        int[][] memo = new int[s.length][2];
        for (int[] row : memo) {
            Arrays.fill(row, -1);
        }
        return dfs(0, 0, true, s, memo);
    }

    private int dfs(int i, int hasDiff, boolean isLimit, char[] s, int[][] memo) {
        if (i == s.length) {
            return hasDiff; // 只有包含 2/5/6/9 才算一个好数
        }
        if (!isLimit && memo[i][hasDiff] >= 0) {
            return memo[i][hasDiff];
        }
        int res = 0;
        int up = isLimit ? s[i] - '0' : 9;
        for (int d = 0; d <= up; d++) { // 枚举要填入的数字 d
            if (DIFFS[d] != -1) { // d 不是 3/4/7
                res += dfs(i + 1, hasDiff | DIFFS[d], isLimit && d == up, s, memo);
            }
        }
        if (!isLimit) {
            memo[i][hasDiff] = res;
        }
        return res;
    }
}
```

```C++
int diffs[10] = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};

class Solution {
public:
    int rotatedDigits(int n) {
        string s = to_string(n);
        int m = s.size();
        vector<array<int, 2>> memo(m, {-1, -1});

        auto dfs = [&](this auto&& dfs, int i, bool has_diff, bool is_limit) -> int {
            if (i == m) {
                return has_diff; // 只有包含 2/5/6/9 才算一个好数
            }
            if (!is_limit && memo[i][has_diff] >= 0) {
                return memo[i][has_diff];
            }
            int res = 0;
            int up = is_limit ? s[i] - '0' : 9;
            for (int d = 0; d <= up; d++) { // 枚举要填入的数字 d
                if (diffs[d] != -1) { // d 不是 3/4/7
                    res += dfs(i + 1, has_diff || diffs[d], is_limit && d == up);
                }
            }
            if (!is_limit) {
                memo[i][has_diff] = res;
            }
            return res;
        };

        return dfs(0, false, true);
    }
};
```

```Go
var diffs = [10]int{0, 0, 1, -1, -1, 1, 1, -1, 0, 1}

func rotatedDigits(n int) int {
    s := strconv.Itoa(n)
    m := len(s)
    memo := make([][2]int, m)
    for i := range memo {
        memo[i] = [2]int{-1, -1}
    }
    var dfs func(int, int, bool) int
    dfs = func(i, isDiff int, isLimit bool) (res int) {
        if i == m {
            return isDiff // 只有包含 2/5/6/9 才算一个好数
        }
        if !isLimit {
            p := &memo[i][isDiff]
            if *p >= 0 {
                return *p
            }
            defer func() { *p = res }()
        }
        up := 9
        if isLimit {
            up = int(s[i] - '0')
        }
        for d := 0; d <= up; d++ { // 枚举要填入的数字 d
            if diffs[d] != -1 { // d 不是 3/4/7
                res += dfs(i+1, isDiff|diffs[d], isLimit && d == up)
            }
        }
        return
    }
    return dfs(0, 0, true)
}
```

#### 复杂度分析

- 时间复杂度：$O(mD)$，其中 $m=O(\log n), D=10$。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times $ 单个状态的计算时间。本题状态个数等于 $O(m)$，单个状态的计算时间为 $O(D)$，所以动态规划的时间复杂度为 $O(mD)$。
- 空间复杂度：$O(m)$。

#### 专题训练

见下面动态规划题单的「**十、数位 DP**」。

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
