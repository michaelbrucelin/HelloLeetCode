### [【模板】上下界数位 DP（Python/Java/C++/Go）](https://leetcode.cn/problems/count-the-number-of-powerful-integers/solutions/2595149/shu-wei-dp-shang-xia-jie-mo-ban-fu-ti-da-h6ci/)

- [v1.0 视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1rS4y1s721%2F)
- [v2.0 视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Fg4y1Q7wv%2F)

定义 $dfs(i,limitLow,limitHigh)$ 表示构造第 $i$ 位及其之后数位的合法方案数，其余参数的含义为：

- $limitHigh$ 表示当前是否受到了 $finish$ 的约束（我们要构造的数字不能超过 $finish$）。若为真，则第 $i$ 位填入的数字至多为 $finish[i]$，否则至多为 $9$，这个数记作 $hi$。如果在受到约束的情况下填了 $finish[i]$，那么后续填入的数字仍会受到 $finish$ 的约束。例如 $finish=123$，那么 $i=0$ 填的是 $1$ 的话，$i=1$ 的这一位至多填 $2$。
- $limitLow$ 表示当前是否受到了 $start$ 的约束（我们要构造的数字不能低于 $start$）。若为真，则第 $i$ 位填入的数字至少为 $start[i]$，否则至少为 $0$，这个数记作 $lo$。如果在受到约束的情况下填了 $start[i]$，那么后续填入的数字仍会受到 $start$ 的约束。

枚举第 $i$ 位填什么数字。

如果 $i<n- \vert s \vert$，那么可以填 $[lo,min(hi,limit)]$ 内的数，否则只能填 $s[i-(n- \vert s \vert)]$。这里 $\vert s \vert$ 表示 $s$ 的长度。

为什么不能把 $hi$ 置为 $min(hi,limit)$？请看 [视频](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Fg4y1Q7wv%2F) 中举的反例。

递归终点：$dfs(n,*,*)=1$，表示成功构造出一个合法数字。

递归入口：$dfs(0,true,true)$，表示：

- 从最高位开始枚举。
- 一开始要受到 $start$ 和 $finish$ 的约束（否则就可以随意填了，这肯定不行）。

#### 答疑

**问**：记忆化三个状态有点麻烦，能不能只记忆化 $i$ 这个状态？

**答**：是可以的。比如 $finish=234$，第一位填 $2$，第二位填 $3$，后面无论怎么递归，都不会再次递归到第一位填 $2$，第二位填 $3$ 的情况，所以不需要记录。（注：想象我们在写一个三重循环，枚举每一位填什么数字。第一位填 $2$，第二位填 $3$ 已经是快要结束循环的情况了，不可能再次枚举到。）对于 $start$ 也同理。

根据这个例子，我们可以只记录不受到 $limitLow$ 或 $limitHigh$ 约束时的状态 $i$。相当于记忆化的是 $(i,false,false)$ 这个状态，因为其它状态只会递归访问一次。

```Python
class Solution:
    def numberOfPowerfulInt(self, start: int, finish: int, limit: int, s: str) -> int:
        high = list(map(int, str(finish)))  # 避免在 dfs 中频繁调用 int()
        n = len(high)
        low = list(map(int, str(start).zfill(n)))  # 补前导零，和 high 对齐
        diff = n - len(s)

        @cache
        def dfs(i: int, limit_low: bool, limit_high: bool) -> int:
            if i == n:
                return 1

            # 第 i 个数位可以从 lo 枚举到 hi
            # 如果对数位还有其它约束，应当只在下面的 for 循环做限制，不应修改 lo 或 hi
            lo = low[i] if limit_low else 0
            hi = high[i] if limit_high else 9

            res = 0
            if i < diff:  # 枚举这个数位填什么
                for d in range(lo, min(hi, limit) + 1):
                    res += dfs(i + 1, limit_low and d == lo, limit_high and d == hi)
            else:  # 这个数位只能填 s[i-diff]
                x = int(s[i - diff])
                if lo <= x <= hi:  # 题目保证 x <= limit，无需判断
                    res = dfs(i + 1, limit_low and x == lo, limit_high and x == hi)
            return res

        return dfs(0, True, True)
```

```Java
class Solution {
    public long numberOfPowerfulInt(long start, long finish, int limit, String s) {
        String low = Long.toString(start);
        String high = Long.toString(finish);
        int n = high.length();
        low = "0".repeat(n - low.length()) + low; // 补前导零，和 high 对齐
        long[] memo = new long[n];
        Arrays.fill(memo, -1);
        return dfs(0, true, true, low.toCharArray(), high.toCharArray(), limit, s.toCharArray(), memo);
    }

    private long dfs(int i, boolean limitLow, boolean limitHigh, char[] low, char[] high, int limit, char[] s, long[] memo) {
        if (i == high.length) {
            return 1;
        }

        if (!limitLow && !limitHigh && memo[i] != -1) {
            return memo[i]; // 之前计算过
        }

        // 第 i 个数位可以从 lo 枚举到 hi
        // 如果对数位还有其它约束，应当只在下面的 for 循环做限制，不应修改 lo 或 hi
        int lo = limitLow ? low[i] - '0' : 0;
        int hi = limitHigh ? high[i] - '0' : 9;

        long res = 0;
        if (i < high.length - s.length) { // 枚举这个数位填什么
            for (int d = lo; d <= Math.min(hi, limit); d++) {
                res += dfs(i + 1, limitLow && d == lo, limitHigh && d == hi, low, high, limit, s, memo);
            }
        } else { // 这个数位只能填 s[i-diff]
            int x = s[i - (high.length - s.length)] - '0';
            if (lo <= x && x <= hi) { // 题目保证 x <= limit，无需判断
                res = dfs(i + 1, limitLow && x == lo, limitHigh && x == hi, low, high, limit, s, memo);
            }
        }

        if (!limitLow && !limitHigh) {
            memo[i] = res; // 记忆化 (i,false,false)
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    long long numberOfPowerfulInt(long long start, long long finish, int limit, string s) {
        string low = to_string(start);
        string high = to_string(finish);
        int n = high.size();
        low = string(n - low.size(), '0') + low; // 补前导零，和 high 对齐
        int diff = n - s.size();

        vector<long long> memo(n, -1);
        auto dfs = [&](this auto&& dfs, int i, bool limit_low, bool limit_high) -> long long {
            if (i == low.size()) {
                return 1;
            }

            if (!limit_low && !limit_high && memo[i] != -1) {
                return memo[i]; // 之前计算过
            }

            // 第 i 个数位可以从 lo 枚举到 hi
            // 如果对数位还有其它约束，应当只在下面的 for 循环做限制，不应修改 lo 或 hi
            int lo = limit_low ? low[i] - '0' : 0;
            int hi = limit_high ? high[i] - '0' : 9;

            long long res = 0;
            if (i < diff) { // 枚举这个数位填什么
                for (int d = lo; d <= min(hi, limit); d++) {
                    res += dfs(i + 1, limit_low && d == lo, limit_high && d == hi);
                }
            } else { // 这个数位只能填 s[i-diff]
                int x = s[i - diff] - '0';
                if (lo <= x && x <= hi) { // 题目保证 x <= limit，无需判断
                    res = dfs(i + 1, limit_low && x == lo, limit_high && x == hi);
                }
            }

            if (!limit_low && !limit_high) {
                memo[i] = res; // 记忆化 (i,false,false)
            }
            return res;
        };
        return dfs(0, true, true);
    }
};
```

```Go
func numberOfPowerfulInt(start, finish int64, limit int, s string) int64 {
    low := strconv.FormatInt(start, 10)
    high := strconv.FormatInt(finish, 10)
    n := len(high)
    low = strings.Repeat("0", n-len(low)) + low // 补前导零，和 high 对齐
    diff := n - len(s)

    memo := make([]int64, n)
    for i := range memo {
        memo[i] = -1
    }
    var dfs func(int, bool, bool) int64
    dfs = func(i int, limitLow, limitHigh bool) (res int64) {
        if i == n {
            return 1
        }
        
        if !limitLow && !limitHigh {
            p := &memo[i]
            if *p >= 0 {
                return *p
            }
            defer func() { *p = res }()
        }

        // 第 i 个数位可以从 lo 枚举到 hi
        // 如果对数位还有其它约束，应当只在下面的 for 循环做限制，不应修改 lo 或 hi
        lo := 0
        if limitLow {
            lo = int(low[i] - '0')
        }
        hi := 9
        if limitHigh {
            hi = int(high[i] - '0')
        }

        if i < diff { // 枚举这个数位填什么
            for d := lo; d <= min(hi, limit); d++ {
                res += dfs(i+1, limitLow && d == lo, limitHigh && d == hi)
            }
        } else { // 这个数位只能填 s[i-diff]
            x := int(s[i-diff] - '0')
            if lo <= x && x <= hi { // 题目保证 x <= limit，无需判断
                res += dfs(i+1, limitLow && x == lo, limitHigh && x == hi)
            }
        }
        return
    }
    return dfs(0, true, true)
}
```

#### 复杂度分析

- 时间复杂度：$O(nD)$，其中 $n=O(\log finish)$，$D=10$。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题状态个数等于 $O(n)$，单个状态的计算时间为 $O(D)$，所以动态规划的时间复杂度为 $O(nD)$。
- 空间复杂度：$O(n)$。即状态个数。

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
