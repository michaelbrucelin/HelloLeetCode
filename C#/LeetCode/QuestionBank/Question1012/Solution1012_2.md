#### [前言](https://leetcode.cn/problems/numbers-with-repeated-digits/solutions/2178714/zhi-shao-you-1-wei-zhong-fu-de-shu-zi-by-0mvu/)

关于数位 DP 的详细介绍可以参考「[数位DP(OI Wiki)](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fdp%2Fnumber%2F)」，类似题目有「[233\. 数字 1 的个数](https://leetcode.cn/problems/number-of-digit-one/)」、「[600\. 不含连续1的非负整数](https://leetcode.cn/problems/non-negative-integers-without-consecutive-ones/)」等。

#### [方法一：记忆化搜索](https://leetcode.cn/problems/numbers-with-repeated-digits/solutions/2178714/zhi-shao-you-1-wei-zhong-fu-de-shu-zi-by-0mvu/)

由互斥原理可知，至少有 $1$ 位重复的数字的正整数个数等于总个数减去没有重复数字的正整数个数。为了方便计算，我们首先求出在整数区间 $[0, n]$ 之间的没有重复数字的正整数个数 $x$，那么结果等于 $n+1-x$。

我们从最高位开始填入各个数字，使用整数掩码 $mask$ 记录前面已经填入过的数字（注意前缀 $0$ 不计入已填入的数字）。假设当前填入第 $i$ 位，如果前面填入的数字与 $n$ 对应位置的数字相同，那么可选的填入数字小于等于 $n$ 在第 $i$ 位的数字，否则可填入全部数字。

记可填入的最大数字为 $t$，依次尝试填入数字 $k \in [0, t]$，如果 $k$ 已经出现在 $mask$ 中，那么说明填入数字 $k$ 不合法，否则说明可以填入数字 $k$，那么尝试填入第 $i+1$ 位的数字。

在填入第 $i+1$ 位的数字时，如果掩码 $mask_i = 0$ 且 $k=0$ 成立，那么说明前面都是前缀 $0$，掩码 $mask_{i+1}$ 为 $0$，否则 $mask_{i+1}$ 等于 $mask_i$ 在第 $k$ 位设为一后的值。如果在填入第 $i$ 位时，前面填入的数字与 $n$ 对应位置的数字相同，且在第 $i$ 位填入的数字为 $t$，那么填入第 $i+1$ 位时，前面填入的数字也与 $n$ 对应位置的数字相同。

注意到，假设当前需要填入第 $i$ 位，且前面填入的数字与 $n$ 对应位置的数字不相同，那么需要求得的不重复数字的正整数个数只与 $mask$ 相关，我们可以使用备忘录 $dp$ 记录该结果，避免重复计算。

```python
class Solution:
    def numDupDigitsAtMostN(self, n: int) -> int:
        A = list(map(int, str(n)))
        N = len(A)
        @cache
        def f(i, tight, mask, hasDup):
            if i >= N:
                if hasDup:
                    return 1
                return 0
            upperLimit = A[i] if tight else 9
            ans = 0
            for d in range(upperLimit + 1):
                tight2 = tight and d == upperLimit
                mask2 = mask if mask == 0 and d == 0 else mask | (1 << d)
                hasDup2 = hasDup or (mask & (1 << d))
                ans += f(i + 1, tight2, mask2, hasDup2)
            return ans
        return f(0, True, 0, False)
```

```cpp
class Solution {
public:
    vector<vector<int>> dp;

    int f(int mask, const string &sn, int i, bool same) {
        if (i == sn.size()) {
            return 1;
        }
        if (!same && dp[i][mask] >= 0) {
            return dp[i][mask];
        }
        int res = 0, t = same ? (sn[i] - '0') : 9;
        for (int k = 0; k <= t; k++) {
            if (mask & (1 << k)) {
                continue;
            }
            res += f(mask == 0 && k == 0 ? mask : mask | (1 << k), sn, i + 1, same && k == t);
        }
        if (!same) {
            dp[i][mask] = res;
        }
        return res;
    }

    int numDupDigitsAtMostN(int n) {
        string sn = to_string(n);
        dp.resize(sn.size(), vector<int>(1 << 10, -1));
        return n + 1 - f(0, sn, 0, true);
    }
};
```

```java
class Solution {
    int[][] dp;

    public int numDupDigitsAtMostN(int n) {
        String sn = String.valueOf(n);
        dp = new int[sn.length()][1 << 10];
        for (int i = 0; i < sn.length(); i++) {
            Arrays.fill(dp[i], -1);
        }
        return n + 1 - f(0, sn, 0, true);
    }

    public int f(int mask, String sn, int i, boolean same) {
        if (i == sn.length()) {
            return 1;
        }
        if (!same && dp[i][mask] >= 0) {
            return dp[i][mask];
        }
        int res = 0, t = same ? (sn.charAt(i) - '0') : 9;
        for (int k = 0; k <= t; k++) {
            if ((mask & (1 << k)) != 0) {
                continue;
            }
            res += f(mask == 0 && k == 0 ? mask : mask | (1 << k), sn, i + 1, same && k == t);
        }
        if (!same) {
            dp[i][mask] = res;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    int[][] dp;

    public int NumDupDigitsAtMostN(int n) {
        string sn = n.ToString();
        dp = new int[sn.Length][];
        for (int i = 0; i < sn.Length; i++) {
            dp[i] = new int[1 << 10];
            Array.Fill(dp[i], -1);
        }
        return n + 1 - F(0, sn, 0, true);
    }

    public int F(int mask, string sn, int i, bool same) {
        if (i == sn.Length) {
            return 1;
        }
        if (!same && dp[i][mask] >= 0) {
            return dp[i][mask];
        }
        int res = 0, t = same ? (sn[i] - '0') : 9;
        for (int k = 0; k <= t; k++) {
            if ((mask & (1 << k)) != 0) {
                continue;
            }
            res += F(mask == 0 && k == 0 ? mask : mask | (1 << k), sn, i + 1, same && k == t);
        }
        if (!same) {
            dp[i][mask] = res;
        }
        return res;
    }
}
```

```c
int f(int mask, const char *sn, int i, bool same, int **dp) {
    if (sn[i] == '\0') {
        return 1;
    }
    if (!same && dp[i][mask] >= 0) {
        return dp[i][mask];
    }
    int res = 0, t = same ? (sn[i] - '0') : 9;
    for (int k = 0; k <= t; k++) {
        if (mask & (1 << k)) {
            continue;
        }
        res += f(mask == 0 && k == 0 ? mask : mask | (1 << k), sn, i + 1, same && k == t, dp);
    }
    if (!same) {
        dp[i][mask] = res;
    }
    return res;
}

int numDupDigitsAtMostN(int n) {
    char sn[32];
    sprintf(sn, "%d", n);
    int len = strlen(sn);
    int *dp[len];
    for (int i = 0; i < len; i++) {
        dp[i] = (int *)malloc(sizeof(int) * (1 << 10));
        memset(dp[i], 0xff, sizeof(int) * (1 << 10));
    }
    int ret = n + 1 - f(0, sn, 0, true, dp);
    for (int i = 0; i < len; i++) {
        free(dp[i]);
    }
    return ret;
}
```

```javascript
var numDupDigitsAtMostN = function(n) {
    const sn = '' + n;
    dp = new Array(sn.length).fill(0).map(() => new Array(1 << 10).fill(-1));
    const f = (mask, sn, i, same) => {
        if (i === sn.length) {
            return 1;
        }
        if (!same && dp[i][mask] >= 0) {
            return dp[i][mask];
        }
        let res = 0, t = same ? (sn[i].charCodeAt() - '0'.charCodeAt()) : 9;
        for (let k = 0; k <= t; k++) {
            if ((mask & (1 << k)) !== 0) {
                continue;
            }
            res += f(mask === 0 && k === 0 ? mask : mask | (1 << k), sn, i + 1, same && k === t);
        }
        if (!same) {
            dp[i][mask] = res;
        }
        return res;
    };
    return n + 1 - f(0, sn, 0, true);
}
```

**复杂度分析**

-   时间复杂度：$O(m \times w \times 2^w)$，其中 $m$ 是整数 $n$ 的十进制位数，$w=10$ 表示十进制数的数字类型数目。最多计算 $m \times 2^w$ 个状态，单个状态需要 $O(w)$ 的时间。
-   空间复杂度：$O(m \times 2^w)$。保存 $dp$ 需要 $O(m \times 2^w)$ 的空间。
