#### [数位 DP 通用模板，附题单（Python/Java/C++/Go）](https://leetcode.cn/problems/numbers-with-repeated-digits/solutions/1748539/by-endlesscheng-c5vg/)

#### 本题视频讲解

见 [数位 DP 通用模板](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1rS4y1s721%2F%3Ft%3D20%3A05)，从 20:05 开始。

#### 前置知识：记忆化搜索

见[【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)。

#### 前置知识：位运算与集合论

集合可以用二进制表示，二进制从低到高第 $i$ 位为 $1$ 表示 $i$ 在集合中，为 $0$ 表示 $i$ 不在集合中。例如集合 $\{0,2,3\}$ 对应的二进制数为 $1101_{(2)}$。

设集合对应的二进制数为 $x$。本题需要用到两个位运算操作：

1.  判断元素 $d$ 是否在集合中：`x >> d & 1` 可以取出 $x$ 的第 $d$ 个比特位，如果是 $1$ 就说明 $d$ 在集合中。
2.  把元素 $d$ 添加到集合中：将 `x` 更新为 `x | (1 << d)`。

#### 思路

正难则反，转换成求无重复数字的个数。

将 $n$ 转换成字符串 $s$，定义 $f(i,mask,isLimit,isNum)$ 表示构造从高到低第 $i$ 位及其之后数位的合法方案数，其余参数的含义为：

-   $mask$ 表示前面选过的数字集合，换句话说，第 $i$ 位要选的数字不能在 $mask$ 中。
-   $isLimit$ 表示当前是否受到了 $n$ 的约束。若为真，则第 $i$ 位填入的数字至多为 $s[i]$，否则可以是 $9$。如果在受到约束的情况下填了 $s[i]$，那么后续填入的数字仍会受到 $n$ 的约束。
-   $isNum$ 表示 $i$ 前面的数位是否填了数字。若为假，则当前位可以跳过（不填数字），或者要填入的数字至少为 $1$；若为真，则要填入的数字可以从 $0$ 开始。

后面两个参数可适用于其它数位 DP 题目。

> 注：由于 $mask$ 中记录了数字，可以通过判断 $mask$ 是否为 $0$ 来判断前面是否填了数字，所以 $isNum$ 可以省略。下面的代码保留了 $isNum$，主要是为了方便大家掌握这个模板。因为有些题目不需要 $mask$，但需要 $isNum$。

#### 实现细节

递归入口：`f(0, 0, true, false)`，表示：

-   从 $s[0]$ 开始枚举；
-   一开始集合中没有数字；
-   一开始要受到 $n$ 的约束（否则就可以随意填了，这肯定不行）；
-   一开始没有填数字。

递归中：

-   如果 $isNum$ 为假，说明前面没有填数字，那么当前也可以不填数字。一旦从这里递归下去，$isLimit$ 就可以置为 `false` 了，这是因为 $s[0]$ 必然是大于 $0$ 的，后面就不受到 $n$ 的约束了。或者说，最高位不填数字，后面无论怎么填都比 $n$ 小。
-   如果 $isNum$ 为真，那么当前必须填一个数字。枚举填入的数字，根据 $isNum$ 和 $isLimit$ 来决定填入数字的范围。

递归终点：当 $i$ 等于 $s$ 长度时，如果 $isNum$ 为真，则表示得到了一个合法数字（因为不合法的不会继续递归下去），返回 $1$，否则返回 $0$。

> 注：Java/C++/Go 只需要记忆化 $(i,mask)$ 这个状态，因为：
> 
> 1.  对于一个固定的 $(i,mask)$，这个状态受到 $isLimit$ 或 $isNum$ 的约束在整个递归过程中至多会出现一次，没必要记忆化。
>     
> 2.  另外，如果只记忆化 $(i,mask)$，$dp$ 数组的含义就变成**在不受到约束时**的合法方案数，所以要在 `!isLimit && isNum` 成立时才去记忆化。
> 

```python
class Solution:
    def numDupDigitsAtMostN(self, n: int) -> int:
        s = str(n)
        @cache  # 记忆化搜索
        def f(i: int, mask: int, is_limit: bool, is_num: bool) -> int:
            if i == len(s):
                return int(is_num)  # is_num 为 True 表示得到了一个合法数字
            res = 0
            if not is_num:  # 可以跳过当前数位
                res = f(i + 1, mask, False, False)
            low = 0 if is_num else 1  # 如果前面没有填数字，必须从 1 开始（因为不能有前导零）
            up = int(s[i]) if is_limit else 9  # 如果前面填的数字都和 n 的一样，那么这一位至多填 s[i]（否则就超过 n 啦）
            for d in range(low, up + 1):  # 枚举要填入的数字 d
                if (mask >> d & 1) == 0:  # d 不在 mask 中
                    res += f(i + 1, mask | (1 << d), is_limit and d == up, True)
            return res
        return n - f(0, 0, True, False)
```

```java
class Solution {
    char s[];
    int dp[][];

    public int numDupDigitsAtMostN(int n) {
        s = Integer.toString(n).toCharArray();
        int m = s.length;
        dp = new int[m][1 << 10];
        for (int i = 0; i < m; i++) 
            Arrays.fill(dp[i], -1); // -1 表示没有计算过
        return n - f(0, 0, true, false);
    }

    int f(int i, int mask, boolean isLimit, boolean isNum) {
        if (i == s.length)
            return isNum ? 1 : 0; // isNum 为 true 表示得到了一个合法数字
        if (!isLimit && isNum && dp[i][mask] != -1)
            return dp[i][mask];
        int res = 0;
        if (!isNum) // 可以跳过当前数位
            res = f(i + 1, mask, false, false);
        int up = isLimit ? s[i] - '0' : 9; // 如果前面填的数字都和 n 的一样，那么这一位至多填数字 s[i]（否则就超过 n 啦）
        for (int d = isNum ? 0 : 1; d <= up; ++d) // 枚举要填入的数字 d
            if ((mask >> d & 1) == 0) // d 不在 mask 中
                res += f(i + 1, mask | (1 << d), isLimit && d == up, true);
        if (!isLimit && isNum)
            dp[i][mask] = res;
        return res;
    }
}
```

```cpp
class Solution {
public:
    int numDupDigitsAtMostN(int n) {
        auto s = to_string(n);
        int m = s.length(), dp[m][1 << 10];
        memset(dp, -1, sizeof(dp)); // -1 表示没有计算过
        function<int(int, int, bool, bool)> f = [&](int i, int mask, bool is_limit, bool is_num) -> int {
            if (i == m)
                return is_num; // is_num 为 true 表示得到了一个合法数字
            if (!is_limit && is_num && dp[i][mask] != -1)
                return dp[i][mask];
            int res = 0;
            if (!is_num) // 可以跳过当前数位
                res = f(i + 1, mask, false, false);
            int up = is_limit ? s[i] - '0' : 9; // 如果前面填的数字都和 n 的一样，那么这一位至多填数字 s[i]（否则就超过 n 啦）
            for (int d = 1 - is_num; d <= up; ++d) // 枚举要填入的数字 d
                if ((mask >> d & 1) == 0) // d 不在 mask 中
                    res += f(i + 1, mask | (1 << d), is_limit && d == up, true);
            if (!is_limit && is_num)
                dp[i][mask] = res;
            return res;
        };
        return n - f(0, 0, true, false);
    }
};
```

```go
func numDupDigitsAtMostN(n int) (ans int) {
    s := strconv.Itoa(n)
    m := len(s)
    dp := make([][1 << 10]int, m)
    for i := range dp {
        for j := range dp[i] {
            dp[i][j] = -1 // -1 表示没有计算过
        }
    }
    var f func(int, int, bool, bool) int
    f = func(i, mask int, isLimit, isNum bool) (res int) {
        if i == m {
            if isNum {
                return 1 // 得到了一个合法数字
            }
            return
        }
        if !isLimit && isNum {
            dv := &dp[i][mask]
            if *dv >= 0 {
                return *dv
            }
            defer func() { *dv = res }()
        }
        if !isNum { // 可以跳过当前数位
            res += f(i+1, mask, false, false)
        }
        d := 0
        if !isNum {
            d = 1 // 如果前面没有填数字，必须从 1 开始（因为不能有前导零）
        }
        up := 9
        if isLimit {
            up = int(s[i] - '0') // 如果前面填的数字都和 n 的一样，那么这一位至多填数字 s[i]（否则就超过 n 啦）
        }
        for ; d <= up; d++ { // 枚举要填入的数字 d
            if mask>>d&1 == 0 { // d 不在 mask 中
                res += f(i+1, mask|1<<d, isLimit && d == up, true)
            }
        }
        return
    }
    return n - f(0, 0, true, false)
}
```

#### 复杂度分析

-   时间复杂度：$O(mD2^D)$，其中 $m$ 为 $s$ 的长度，即 $O(\log n)$；$D=10$。由于每个状态只会计算一次，因此动态规划的时间复杂度 $=$ 状态个数 $\times$ 单个状态的计算时间。本题状态个数为 $O(m2^D)$，单个状态的计算时间为 $O(D)$，因此时间复杂度为 $O(mD2^D)$。
-   空间复杂度：$O(m2^D)$。

#### 强化训练（数位 DP）

-   [233\. 数字 1 的个数](https://leetcode.cn/problems/number-of-digit-one/)（[题解](https://leetcode.cn/problems/number-of-digit-one/solution/by-endlesscheng-h9ua/)）
-   [面试题 17.06. 2出现的次数](https://leetcode.cn/problems/number-of-2s-in-range-lcci/)（[题解](https://leetcode.cn/problems/number-of-2s-in-range-lcci/solution/by-endlesscheng-x4mf/)）
-   [600\. 不含连续1的非负整数](https://leetcode.cn/problems/non-negative-integers-without-consecutive-ones/)（[题解](https://leetcode.cn/problems/non-negative-integers-without-consecutive-ones/solution/by-endlesscheng-1egu/)）
-   [902\. 最大为 N 的数字组合](https://leetcode.cn/problems/numbers-at-most-n-given-digit-set/)（[数位 DP 通用模板](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1rS4y1s721%2F%3Ft%3D33m22s) 33:22）
-   [1067\. 范围内的数字计数](https://leetcode.cn/problems/digit-count-in-range/)
-   [1397\. 找到所有好字符串](https://leetcode.cn/problems/find-all-good-strings/)（有难度，需要结合一个经典字符串算法）

更多题目见我模板库中的 [dp.go](https://leetcode.cn/link/?target=https%3A%2F%2Fgithub.com%2FEndlessCheng%2Fcodeforces-go%2Fblob%2Fmaster%2Fcopypasta%2Fdp.go%23L1924)（搜索 `数位`）。
