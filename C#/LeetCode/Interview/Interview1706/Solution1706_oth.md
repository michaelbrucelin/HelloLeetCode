### [数位 DP 通用模板，附题单（Python/Java/C++/Go）](https://leetcode.cn/problems/number-of-2s-in-range-lcci/solutions/1750395/by-endlesscheng-x4mf/?envType=problem-list-v2&envId=ySsxoJfz)

更新：[周赛精讲](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1rS4y1s721) 出炉啦，欢迎一键三连~
本节讲了数位 $DP$ 的通用模板，以及如何使用该模板秒杀相关困难题目。
讲完题目后还讲了一些上分的训练技巧。

---

将 $n$ 转换成字符串 $s$，定义 $f(i,cnt_2,isLimit,isNum)$ 表示在前 $i$ 位有 $cnt_2$ 个 $2$ 的前提下，我们能构造出的数中的 $2$ 的个数总和。

其余参数的含义为：

- $isLimit$ 表示当前是否受到了 $n$ 的约束。若为真，则第 $i$ 位填入的数字至多为 $s[i]$，否则可以是 $9$。如果在受到约束的情况下填了 $s[i]$，那么后续填入的数字仍会受到 $n$ 的约束。
- $isNum$ 表示 $i$ 前面的数位是否填了数字。若为假，则当前位可以跳过（不填数字），或者要填入的数字至少为 $1$；若为真，则要填入的数字可以从 $0$ 开始。

后面两个参数可适用于其它数位 $DP$ 题目。

枚举要填入的数字，具体实现逻辑见代码。**对于本题来说，由于前导零对答案无影响，$isNum$ 可以省略。**

下面代码中 $Java/C++/Go$ 只需要记忆化 $(i,cnt_2)$ 这个状态，因为：

1. 对于一个固定的 $(i,cnt_2)$，这个状态受到 $isLimit$ 的约束在整个递归过程中至多会出现一次，没必要记忆化。
2. 另外，如果只记忆化 $(i,cnt_2)$，dp 数组的含义就变成**在不受到约束时**的合法方案数，所以要在 `!isLimit` 成立时才去记忆化。

```Python
class Solution:
    def numberOf2sInRange(self, n: int) -> int:
        s = str(n)
        @cache
        def f(i: int, cnt2: int, is_limit: bool) -> int:
            if i == len(s):
                return cnt2
            res = 0
            up = int(s[i]) if is_limit else 9
            for d in range(up + 1):  # 枚举要填入的数字 d
                res += f(i + 1, cnt2 + (d == 2), is_limit and d == up)
            return res
        return f(0, 0, True)
```

```Java
class Solution {
    char s[];
    int dp[][];

    public int numberOf2sInRange(int n) {
        s = Integer.toString(n).toCharArray();
        var m = s.length;
        dp = new int[m][m];
        for (var i = 0; i < m; i++) Arrays.fill(dp[i], -1);
        return f(0, 0, true);
    }

    int f(int i, int cnt2, boolean isLimit) {
        if (i == s.length) return cnt2;
        if (!isLimit && dp[i][cnt2] >= 0) return dp[i][cnt2];
        var res = 0;
        for (int d = 0, up = isLimit ? s[i] - '0' : 9; d <= up; ++d) // 枚举要填入的数字 d
            res += f(i + 1, cnt2 + (d == 2 ? 1 : 0), isLimit && d == up);
        if (!isLimit) dp[i][cnt2] = res;
        return res;
    }
}
```

```C++
class Solution {
public:
    int numberOf2sInRange(int n) {
        auto s = to_string(n);
        int m = s.length(), dp[m][m];
        memset(dp, -1, sizeof(dp));
        function<int(int, int, bool)> f = [&](int i, int cnt2, bool is_limit) -> int {
            if (i == m) return cnt2;
            if (!is_limit && dp[i][cnt2] >= 0) return dp[i][cnt2];
            int res = 0;
            for (int d = 0, up = is_limit ? s[i] - '0' : 9; d <= up; ++d) // 枚举要填入的数字 d
                res += f(i + 1, cnt2 + (d == 2), is_limit && d == up);
            if (!is_limit) dp[i][cnt2] = res;
            return res;
        };
        return f(0, 0, true);
    }
};
```

```Go
func numberOf2sInRange(n int) int {
    s := strconv.Itoa(n)
    m := len(s)
    dp := make([][]int, m)
    for i := range dp {
        dp[i] = make([]int, m)
        for j := range dp[i] {
            dp[i][j] = -1
        }
    }
    var f func(int, int, bool) int
    f = func(i, cnt2 int, isLimit bool) (res int) {
        if i == m {
            return cnt2
        }
        if !isLimit {
            dv := &dp[i][cnt2]
            if *dv >= 0 {
                return *dv
            }
            defer func() { *dv = res }()
        }
        up := 9
        if isLimit {
            up = int(s[i] - '0')
        }
        for d := 0; d <= up; d++ { // 枚举要填入的数字 d
            c := cnt2
            if d == 2 {
                c++
            }
            res += f(i+1, c, isLimit && d == up)
        }
        return
    }
    return f(0, 0, true)
}
```

#### 复杂度分析

- 时间复杂度：$O(m^2D)$，其中 $m=O(\log n), D=10$。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times $ 单个状态的计算时间。本题状态个数等于 $O(m^2)$，单个状态的计算时间为 $O(D)$，所以动态规划的时间复杂度为 $O(m^2D)$。
- 空间复杂度：$O(m^2)$。
