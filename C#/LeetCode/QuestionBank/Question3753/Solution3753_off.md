### [范围内总波动值 II](https://leetcode.cn/problems/total-waviness-of-numbers-in-range-ii/solutions/3977837/fan-wei-nei-zong-bo-dong-zhi-ii-by-leetc-rlp9/)

#### 方法一：数位动态规划

**思路与算法**

本题涉及到数字计数的问题，我们可以采用 $\lceil$ [**数位 DP**](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fdp%2Fnumber%2F)$\rfloor$，先计算 $[0,x]$ 内所有数的波动值总和，再用前缀和思想得到答案。设 $solve(x)$ 表示 $[0,x]$ 内所有数的波动值总和，此时可以得到推理如下：

$$ans=solve(num_2)-solve(num_1-1)$$

对于 $solve(x)$，我们使用 **记忆化搜索**（自顶向下）实现数位 $DP$。核心思想：从左向右逐位确定数字，并记录已经固定的前两位，并利用 $isLimit$ 和 $isLeading$ 处理边界和前导零。$ $
在进行 $DFS$ 时，我们需要关注以下信息：

- $pos$：当前正在处理的数位下标（$0 \sim  n-1$，从左到右）。
- $prev$：$pos-2$ 位的数字，若不存在则用 $-1$ 表示。
- $curr$：$pos-1$ 位的数字，若不存在（还在前导零阶段）则用 $-1$。
- $isLimit$：布尔值，表示之前的所有位是否已经和 $num$ 的对应前缀完全相同。若为 $true$，则当前位的可选数字不能超过 $numpos$；否则可选 $0\sim 9$。
- $isLeading$：布尔值，表示是否仍然处于前导零状态（即还未出现第一个非零数字）。初始为 $true$。

DFS 每次返回两个状态值 $cnt$ 和 $sum$：

- $cnt$：从当前状态出发能构成的合法数字的**个数**。
- $sum$：这些合法数字的波动值**总和**。

我们使用两个三维数组来进行记忆化存储：

- $memo\_cnt[pos][prev][curr]$：记录从该状态出发的合法数字个数。
- $memo\_sum[pos][prev][curr]$：记录从该状态出发的合法数字对应的波动值总和。
- 数组初始化为 $-1$ 表示未计算。为了方便计算，当 $curr$ 或 $prev$ 不存在时（值为 $-1$），这些状态不会被记忆化存储。

枚举当前填充的数字第 $pos$ 位，计算过程如下：

- 计算当前可以枚举的数字范围，如果仍然沿着数字前缀上限，此时 $isLimit=true$，当前位数字的枚举范围为 $[0,numpos]$，否则数字的枚举范围为 $[0,9]$，数字的枚举范围规定为 $[0,up]$。
- 枚举当前位可选的数字 $digit$，试填充并计算返回值；
    - 根据当前填充的数字更新前导零标志：$newLead$；
    - 更新 $prev$ 和 $curr$，newPrev=curr（$pos-1$ 位的数字变成了 $pos-2$ 位），$newCurr=digit$（如果还在前导零，当前位仍无效）。
    - 递归调用 $dfs(pos+1,newPrev,newCurr,\dots )$，得到当前条件的返回值 $(subCnt,subSum)$
- 计算当前 $digit$ 带来的波动贡献：
    - 只有当**已有三位有效数字**，才检查 $(prev,curr,digit)$ 是否构成**峰**或**谷**。
    - 若满足 $prev<curr\wedge curr>digit$ 或 $prev>curr\wedge curr<digit$，则当前位的波动贡献为 $subCnt$（因为每个子数字都额外多了一个波动点），将其累加到 $sum$ 中；
- 累加子状态的值，并返回当前状态的结果 $(cnt,sum)$。

递归边界：

- 当 $pos=n$ 时，表示已经构造完所有数位，返回 $(1,0)$（只有一种方案，且不再产生新波动）。

递归入口：$dfs(0,-1,-1,true,true)$；

剪枝处理：若 $num<100$，则没有三位数，直接返回 $0$；

最终 $solve(num)$ 返回 $dfs(\dots )$ 结果中的 $sum$，即波动值总和。

**代码**

```C++
class Solution {
public:
    long long totalWaviness(long long num1, long long num2) {
        using ll = long long;
        // 计算 [0, num] 内所有数字的波动值总和
        auto solve = [&](ll num) -> ll {
            // 如果少于 3 的数字波动值 0
            if (num < 100) {
                return 0;
            }
            string s = to_string(num);
            int n = s.size();

            // 记忆化搜索使用两个独立的数组
            // memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
            ll memo_cnt[16][10][10];
            // memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
            ll memo_sum[16][10][10];
            memset(memo_cnt, -1, sizeof(memo_cnt));
            memset(memo_sum, -1, sizeof(memo_sum));

            auto dfs = [&](this auto &&dfs, int pos, int prev, int curr, bool isLimit, bool isLeading) -> pair<ll,ll> {
                // 结束位置
                if (pos == n) {
                    return {1, 0};
                }
                // 只有在不受上限限制且不包含前导零时才使用记忆化
                if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
                    if (memo_cnt[pos][prev][curr] != -1) {
                        return {memo_cnt[pos][prev][curr], memo_sum[pos][prev][curr]};
                    }
                }

                // 计算当前条件下的方案数和波动值
                ll cnt = 0, sum = 0;
                int up = isLimit ? s[pos] - '0' : 9;
                for (int digit = 0; digit <= up; ++digit) {
                    bool newLeading = isLeading && (digit == 0);
                    // 前一个数字更新为 curr
                    int newPrev = curr;
                    // 当前数字更新为 digit
                    int newCurr = newLeading ? -1 : digit;
                    auto [subCnt, subSum] = dfs(pos + 1, newPrev, newCurr, isLimit && (digit == up), newLeading);
                    // 不包含前导零时才计算波动值
                    if (!newLeading && prev >= 0 && curr >= 0) {
                        // 数位为峰或为谷时，更新当前的波动值
                        if ((prev < curr && curr > digit) || (prev > curr && curr < digit)) {
                            sum += subCnt;
                        }
                    }

                    cnt += subCnt;
                    sum += subSum;
                }

                if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
                    // 更新记忆化数组
                    memo_cnt[pos][prev][curr] = cnt;
                    memo_sum[pos][prev][curr] = sum;
                }

                return {cnt, sum};
            };

            // 修正：传递 dfs 作为第一个参数
            auto [_, totalSum] = dfs(0, -1, -1, true, true);
            return totalSum;
        };

        return solve(num2) - solve(num1 - 1);
    }
};
```

```Java
class Solution {
    private String s;
    private int n;
    private long[][][] memo_cnt;
    private long[][][] memo_sum;

    public long totalWaviness(long num1, long num2) {
        return solve(num2) - solve(num1 - 1);
    }

    // 计算 [0, num] 内所有数字的波动值之和
    private long solve(long num) {
        // 如果少于 3 的数字波动值 0
        if (num < 100) {
            return 0L;
        }
        s = Long.toString(num);
        n = s.length();

        // 记忆化搜索使用两个独立的数组
        // memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
        memo_cnt = new long[16][10][10];
        // memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
        memo_sum = new long[16][10][10];
        for (int i = 0; i < 16; i++) {
            for (int j = 0; j < 10; j++) {
                Arrays.fill(memo_cnt[i][j], -1);
                Arrays.fill(memo_sum[i][j], -1);
            }
        }

        long[] result = dfs(0, -1, -1, true, true);
        return result[1];
    }

    private long[] dfs(int pos, int prev, int curr, boolean isLimit, boolean isLeading) {
        // 结束位置
        if (pos == n) {
            return new long[]{1L, 0L};
        }
        // 只有在不受上限限制且不包含前导零时才使用记忆化
        if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
            if (memo_cnt[pos][prev][curr] != -1) {
                return new long[]{memo_cnt[pos][prev][curr], memo_sum[pos][prev][curr]};
            }
        }

        // 计算当前条件下的方案数和波动值
        long cnt = 0, sum = 0;
        int up = isLimit ? (s.charAt(pos) - '0') : 9;
        for (int digit = 0; digit <= up; ++digit) {
            boolean newLeading = isLeading && (digit == 0);
            // 前一个数字更新为 curr
            int newPrev = curr;
            // 当前数字更新为 digit
            int newCurr = newLeading ? -1 : digit;
            long[] sub = dfs(pos + 1, newPrev, newCurr, isLimit && (digit == up), newLeading);
            long subCnt = sub[0], subSum = sub[1];
            // 不包含前导零时才计算波动值
            if (!newLeading && prev >= 0 && curr >= 0) {
                // 数位为峰或为谷时，更新当前的波动值
                if ((prev < curr && curr > digit) || (prev > curr && curr < digit)) {
                    sum += subCnt;
                }
            }

            cnt += subCnt;
            sum += subSum;
        }

        if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
            // 更新记忆化数组
            memo_cnt[pos][prev][curr] = cnt;
            memo_sum[pos][prev][curr] = sum;
        }

        return new long[]{cnt, sum};
    }
}
```

```CSharp
public class Solution {
    private string s;
    private int n;
    private long[,,] memo_cnt;
    private long[,,] memo_sum;

    public long TotalWaviness(long num1, long num2) {
        return Solve(num2) - Solve(num1 - 1);
    }

     // 计算 [0, num] 内所有数字的波动值之和
    private long Solve(long num) {
        // 如果少于 3 的数字波动值 0
        if (num < 100) {
            return 0L;
        }
        s = num.ToString();
        n = s.Length;

        // 记忆化搜索使用两个独立的数组
        // memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
        memo_cnt = new long[16, 10, 10];
        // memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
        memo_sum = new long[16, 10, 10];
        for (int i = 0; i < 16; i++) {
            for (int j = 0; j < 10; j++) {
                for (int k = 0; k < 10; k++) {
                    memo_cnt[i, j, k] = -1;
                    memo_sum[i, j, k] = -1;
                }
            }
        }

        long[] result = Dfs(0, -1, -1, true, true);
        return result[1];
    }

    private long[] Dfs(int pos, int prev, int curr, bool isLimit, bool isLeading) {
        // 结束位置
        if (pos == n) {
            return new long[] { 1L, 0L };
        }
        // 只有在不受上限限制且不包含前导零时才使用记忆化
        if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
            if (memo_cnt[pos, prev, curr] != -1) {
                return new long[] { memo_cnt[pos, prev, curr], memo_sum[pos, prev, curr] };
            }
        }

        // 计算当前条件下的方案数和波动值
        long cnt = 0, sum = 0;
        int up = isLimit ? (s[pos] - '0') : 9;
        for (int digit = 0; digit <= up; ++digit) {
            bool newLeading = isLeading && (digit == 0);
            // 前一个数字更新为 curr
            int newPrev = curr;
            // 当前数字更新为 digit
            int newCurr = newLeading ? -1 : digit;
            long[] sub = Dfs(pos + 1, newPrev, newCurr, isLimit && (digit == up), newLeading);
            long subCnt = sub[0], subSum = sub[1];
            // 不包含前导零时才计算波动值
            if (!newLeading && prev >= 0 && curr >= 0) {
                // 数位为峰或为谷时，更新当前的波动值
                if ((prev < curr && curr > digit) || (prev > curr && curr < digit)) {
                    sum += subCnt;
                }
            }

            cnt += subCnt;
            sum += subSum;
        }

        if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
            // 更新记忆化数组
            memo_cnt[pos, prev, curr] = cnt;
            memo_sum[pos, prev, curr] = sum;
        }

        return new long[] { cnt, sum };
    }
}
```

```Go
func totalWaviness(num1 int64, num2 int64) int64 {
    // 计算 [0, num] 内所有数字的波动性总和
    solve := func(num int64) int64 {
        // 如果少于 3 的数字波动值 0
        if num < 100 {
            return 0
        }
        s := fmt.Sprintf("%d", num)
        n := len(s)

        // 记忆化搜索使用两个独立的数组
        // memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
        memo_cnt := make([][][]int64, 16)
        // memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
        memo_sum := make([][][]int64, 16)
        for i := 0; i < 16; i++ {
            memo_cnt[i] = make([][]int64, 10)
            memo_sum[i] = make([][]int64, 10)
            for j := 0; j < 10; j++ {
                memo_cnt[i][j] = make([]int64, 10)
                memo_sum[i][j] = make([]int64, 10)
                for k := 0; k < 10; k++ {
                    memo_cnt[i][j][k] = -1
                    memo_sum[i][j][k] = -1
                }
            }
        }

        var dfs func(pos int, prev int, curr int, isLimit bool, isLeading bool) (int64, int64)
        dfs = func(pos int, prev int, curr int, isLimit bool, isLeading bool) (int64, int64) {
            // 结束位置
            if pos == n {
                return 1, 0
            }
            // 只有在不受上限限制且不包含前导零时才使用记忆化
            if !isLimit && !isLeading && prev >= 0 && curr >= 0 {
                if memo_cnt[pos][prev][curr] != -1 {
                    return memo_cnt[pos][prev][curr], memo_sum[pos][prev][curr]
                }
            }

            // 计算当前条件下的方案数和波动值
            var cnt, sum int64 = 0, 0
            up := 9
            if isLimit {
                up = int(s[pos] - '0')
            }
            for digit := 0; digit <= up; digit++ {
                newLeading := isLeading && (digit == 0)
                // 前一个数字更新为 curr
                newPrev := curr
                // 当前数字更新为 digit
                newCurr := digit
                if newLeading {
                    newCurr = -1
                }
                subCnt, subSum := dfs(pos+1, newPrev, newCurr, isLimit && (digit == up), newLeading)
                // 不包含前导零时才计算波动值
                if !newLeading && prev >= 0 && curr >= 0 {
                    // 数位为峰或为谷时，更新当前的波动值
                    if (prev < curr && curr > digit) || (prev > curr && curr < digit) {
                        sum += subCnt
                    }
                }

                cnt += subCnt
                sum += subSum
            }

            if !isLimit && !isLeading && prev >= 0 && curr >= 0 {
                // 更新记忆化数组
                memo_cnt[pos][prev][curr] = cnt
                memo_sum[pos][prev][curr] = sum
            }

            return cnt, sum
        }

        _, totalSum := dfs(0, -1, -1, true, true)
        return totalSum
    }

    return solve(num2) - solve(num1-1)
}
```

```Python
class Solution:
    def totalWaviness(self, num1: int, num2: int) -> int:
        #  计算 [0, num] 内所有数字的波动值之和
        def solve(num: int) -> int:
            # 如果少于 3 的数字波动值 0
            if num < 100:
                return 0
            s = str(num)
            n = len(s)

            # 记忆化搜索使用两个独立的数组
            # memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
            memo_cnt = [[[-1] * 10 for _ in range(10)] for _ in range(16)]
            # memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
            memo_sum = [[[-1] * 10 for _ in range(10)] for _ in range(16)]

            from functools import lru_cache

            @lru_cache(None)
            def dfs(pos: int, prev: int, curr: int, isLimit: bool, isLeading: bool):
                # 结束位置
                if pos == n:
                    return 1, 0

                # 计算当前条件下的填充方案数和波动值
                cnt = 0
                waviness = 0
                up = int(s[pos]) if isLimit else 9
                for digit in range(up + 1):
                    newLeading = isLeading and (digit == 0)
                    # 前一个数字更新为 curr
                    newPrev = curr
                    # 当前数字更新为 digit
                    newCurr = -1 if newLeading else digit
                    subCnt, subSum = dfs(pos + 1, newPrev, newCurr,
                                         isLimit and (digit == up), newLeading)
                    # 不包含前导零时才计算波动值
                    if not newLeading and prev >= 0 and curr >= 0:
                        # 数位为峰或为谷时，更新当前的波动值
                        if (prev < curr and curr > digit) or (prev > curr and curr < digit):
                            waviness += subCnt

                    cnt += subCnt
                    waviness += subSum

                return cnt, waviness

            _, totalSum = dfs(0, -1, -1, True, True)
            return totalSum

        return solve(num2) - solve(num1 - 1)
```

```C
typedef struct {
    long long cnt;
    long long sum;
} Result;

Result dfs(const char* s, int n,
           long long memo_cnt[20][10][10],
           long long memo_sum[20][10][10],
           int pos, int prev, int curr,
           int isLimit, int isLeading) {
    // 结束位置
    if (pos == n) {
        return (Result){1, 0};
    }
    // 只有在不受上限限制且不包含前导零时才使用记忆化
    if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
        if (memo_cnt[pos][prev][curr] != -1) {
            return (Result){memo_cnt[pos][prev][curr], memo_sum[pos][prev][curr]};
        }
    }

    // 计算当前条件下的方案数和波动值
    long long cnt = 0, sum = 0;
    int up = isLimit ? (s[pos] - '0') : 9;
    for (int digit = 0; digit <= up; ++digit) {
        int newLeading = isLeading && (digit == 0);
        // 前一个数字更新为 curr
        int newPrev = curr;
        // 当前数字更新为 digit
        int newCurr = newLeading ? -1 : digit;
        Result sub = dfs(s, n, memo_cnt, memo_sum,
                         pos + 1, newPrev, newCurr,
                         isLimit && (digit == up), newLeading);
        // 不包含前导零时才计算波动值
        if (!newLeading && prev >= 0 && curr >= 0) {
            // 数位为峰或为谷时，更新当前的波动值
            if ((prev < curr && curr > digit) || (prev > curr && curr < digit)) {
                sum += sub.cnt;
            }
        }

        cnt += sub.cnt;
        sum += sub.sum;
    }

    if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
        // 更新记忆化数组
        memo_cnt[pos][prev][curr] = cnt;
        memo_sum[pos][prev][curr] = sum;
    }

    return (Result){cnt, sum};
}

// 计算 [0, num] 内所有数字的波动值总和
long long solve(long long num) {
    // 如果少于 3 的数字波动值 0
    if (num < 100) {
        return 0;
    }

    char s[20];
    sprintf(s, "%lld", num);
    int n = strlen(s);

    // 记忆化搜索使用两个独立的数组
    // memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
    long long memo_cnt[20][10][10];
    // memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
    long long memo_sum[20][10][10];
    // 初始化记忆化数组
    memset(memo_cnt, -1, sizeof(memo_cnt));
    memset(memo_sum, -1, sizeof(memo_sum));

    Result result = dfs(s, n, memo_cnt, memo_sum, 0, -1, -1, 1, 1);
    return result.sum;
}

long long totalWaviness(long long num1, long long num2) {
    return solve(num2) - solve(num1 - 1);
}
```

```JavaScript
var totalWaviness = function(num1, num2) {
    // 计算 [0, num] 内所有数字的波动值总和
    const solve = (num) => {
        // 如果少于 3 的数字波动值 0
        if (num < 100) {
            return 0;
        }
        const s = num.toString();
        const n = s.length;

        // 记忆化搜索使用两个独立的数组
        // memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
        const memo_cnt = Array(16).fill().map(() => Array(10).fill().map(() => Array(10).fill(-1)));
        // memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
        const memo_sum = Array(16).fill().map(() => Array(10).fill().map(() => Array(10).fill(-1)));

        const dfs = (pos, prev, curr, isLimit, isLeading) => {
            // 结束位置
            if (pos === n) {
                return [1, 0];
            }
            // 只有在不受上限限制且不包含前导零时才使用记忆化
            if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
                if (memo_cnt[pos][prev][curr] !== -1) {
                    return [memo_cnt[pos][prev][curr], memo_sum[pos][prev][curr]];
                }
            }

            // 计算当前条件下的方案数和波动值
            let cnt = 0, sum = 0;
            const up = isLimit ? parseInt(s[pos]) : 9;
            for (let digit = 0; digit <= up; ++digit) {
                const newLeading = isLeading && (digit === 0);
                // 前一个数字更新为 curr
                const newPrev = curr;
                // 当前数字更新为 digit
                const newCurr = newLeading ? -1 : digit;
                const [subCnt, subSum] = dfs(pos + 1, newPrev, newCurr,
                                              isLimit && (digit === up), newLeading);
                // 不包含前导零时才计算波动值
                if (!newLeading && prev >= 0 && curr >= 0) {
                    // 数位为峰或为谷时，更新当前的波动值
                    if ((prev < curr && curr > digit) || (prev > curr && curr < digit)) {
                        sum += subCnt;
                    }
                }

                cnt += subCnt;
                sum += subSum;
            }

            if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
                // 更新记忆化数组
                memo_cnt[pos][prev][curr] = cnt;
                memo_sum[pos][prev][curr] = sum;
            }

            return [cnt, sum];
        };

        const [_, totalSum] = dfs(0, -1, -1, true, true);
        return totalSum;
    };

    return solve(num2) - solve(num1 - 1);
};
```

```TypeScript
function totalWaviness(num1: number, num2: number): number {
    // 计算 [0, num] 内所有数字的波动值总和
    const solve = (num: number): number => {
        // 如果少于 3 的数字波动值 0
        if (num < 100) {
            return 0;
        }
        const s: string = num.toString();
        const n: number = s.length;

        // 记忆化搜索使用两个独立的数组
        // memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
        const memo_cnt: number[][][] = Array(16).fill(null).map(() => Array(10).fill(null).map(() => Array(10).fill(-1)));
        // memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
        const memo_sum: number[][][] = Array(16).fill(null).map(() => Array(10).fill(null).map(() => Array(10).fill(-1)));

        const dfs = (pos: number, prev: number, curr: number, isLimit: boolean, isLeading: boolean): [number, number] => {
            // 结束位置
            if (pos === n) {
                return [1, 0];
            }
            // 只有在不受上限限制且不包含前导零时才使用记忆化
            if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
                if (memo_cnt[pos][prev][curr] !== -1) {
                    return [memo_cnt[pos][prev][curr], memo_sum[pos][prev][curr]];
                }
            }

            // 计算当前条件下的方案数和波动值
            let cnt: number = 0, sum: number = 0;
            const up: number = isLimit ? parseInt(s[pos]) : 9;
            for (let digit = 0; digit <= up; ++digit) {
                const newLeading: boolean = isLeading && (digit === 0);
                // 前一个数字更新为 curr
                const newPrev: number = curr;
                // 当前数字更新为 digit
                const newCurr: number = newLeading ? -1 : digit;
                const [subCnt, subSum] = dfs(pos + 1, newPrev, newCurr,
                                              isLimit && (digit === up), newLeading);
                // 不包含前导零时才计算波动值
                if (!newLeading && prev >= 0 && curr >= 0) {
                    // 数位为峰或为谷时，更新当前的波动值
                    if ((prev < curr && curr > digit) || (prev > curr && curr < digit)) {
                        sum += subCnt;
                    }
                }

                cnt += subCnt;
                sum += subSum;
            }

            if (!isLimit && !isLeading && prev >= 0 && curr >= 0) {
                // 更新记忆化数组
                memo_cnt[pos][prev][curr] = cnt;
                memo_sum[pos][prev][curr] = sum;
            }

            return [cnt, sum];
        };

        const [_, totalSum] = dfs(0, -1, -1, true, true);
        return totalSum;
    };

    return solve(num2) - solve(num1 - 1);
}
```

```Rust
impl Solution {
    pub fn total_waviness(num1: i64, num2: i64) -> i64 {
        // 计算 [0, num] 内所有数字的波动值总和
        fn solve(num: i64) -> i64 {
            // 如果少于 3 的数字波动值 0
            if num < 100 {
                return 0;
            }
            let s = num.to_string();
            let n = s.len();
            let chars: Vec<char> = s.chars().collect();

            // 记忆化搜索使用两个独立的数组
            // memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
            let mut memo_cnt = vec![vec![vec![-1i64; 10]; 10]; 16];
            // memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
            let mut memo_sum = vec![vec![vec![-1i64; 10]; 10]; 16];

            fn dfs(
                pos: usize,
                prev: i32,
                curr: i32,
                is_limit: bool,
                is_leading: bool,
                n: usize,
                chars: &Vec<char>,
                memo_cnt: &mut Vec<Vec<Vec<i64>>>,
                memo_sum: &mut Vec<Vec<Vec<i64>>>,
            ) -> (i64, i64) {
                // 结束位置
                if pos == n {
                    return (1, 0);
                }
                // 只有在不受上限限制且不包含前导零时才使用记忆化
                if !is_limit && !is_leading && prev >= 0 && curr >= 0 {
                    let p = prev as usize;
                    let c = curr as usize;
                    if memo_cnt[pos][p][c] != -1 {
                        return (memo_cnt[pos][p][c], memo_sum[pos][p][c]);
                    }
                }

                // 计算当前条件下的方案数和波动值
                let mut cnt = 0i64;
                let mut sum = 0i64;
                let up = if is_limit {
                    (chars[pos] as i32 - '0' as i32)
                } else {
                    9
                };
                for digit in 0..=up {
                    let new_leading = is_leading && (digit == 0);
                    // 前一个数字更新为 curr
                    let new_prev = curr;
                    // 当前数字更新为 digit
                    let new_curr = if new_leading { -1 } else { digit };
                    let (sub_cnt, sub_sum) = dfs(
                        pos + 1,
                        new_prev,
                        new_curr,
                        is_limit && (digit == up),
                        new_leading,
                        n,
                        chars,
                        memo_cnt,
                        memo_sum,
                    );
                    // 不包含前导零时才计算波动值
                    if !new_leading && prev >= 0 && curr >= 0 {
                        // 数位为峰或为谷时，更新当前的波动值
                        if (prev < curr && curr > digit) || (prev > curr && curr < digit) {
                            sum += sub_cnt;
                        }
                    }

                    cnt += sub_cnt;
                    sum += sub_sum;
                }

                if !is_limit && !is_leading && prev >= 0 && curr >= 0 {
                    // 更新记忆化数组
                    let p = prev as usize;
                    let c = curr as usize;
                    memo_cnt[pos][p][c] = cnt;
                    memo_sum[pos][p][c] = sum;
                }

                (cnt, sum)
            }

            let (_, total_sum) = dfs(0, -1, -1, true, true, n, &chars, &mut memo_cnt, &mut memo_sum);
            total_sum
        }

        solve(num2) - solve(num1 - 1)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(D^3\log num_2)$，其中 $D$ 是进制数，在本题中 $D=10$，$num_2$ 表示给定的元素。记忆化搜索的状态数是 $O(D^2\log num_2)$，计算每个子状态需要的时间为 $O(D)$，因此总的时间为 $O(D^3\log num_2)$。
- 空间复杂度：$O(D^2\log num_2)$，其中 $D$ 是进制数，在本题中 $D=10$，$num_2$ 表示给定的元素。递归栈的深度为 $\log num_2$，记忆化搜索的状态数是 $O(D^2\log num_2)$。

#### 方法二：自底向上动态规划

**思路与算法**

同样的方法，我们还可以将其展开为自底向上的动态规划，算法原理与解法一相同，在此不再详述。

**代码**

```C++
class Solution {
public:
    using ll = long long;

    struct State {
        int prev, curr, tight, lead;
        ll cnt, sum;
    };

    ll solve(ll num) {
        // 数字小于 3 位波动值为 0
        if (num < 100) {
            return 0;
        }
        string s = to_string(num);
        int n = s.size();

        vector<State> currStates;
        // 数位 10 表示存在前导零时的无效无效状态
        currStates.push_back({10, 10, 1, 1, 1, 0});
        for (int pos = 0; pos < n; ++pos) {
            int limit = s[pos] - '0';
            ll cnt[2][2][11][11] = {0};
            ll sum[2][2][11][11] = {0};

            for (const auto& st : currStates) {
                int maxDigit = st.tight ? limit : 9;
                for (int digit = 0; digit <= maxDigit; ++digit) {
                    int newLead = st.lead && (digit == 0);
                    int newPrev = st.curr;
                    int newCurr = newLead ? 10 : digit;
                    int newTight = st.tight && (digit == maxDigit);

                    ll add = 0;
                    // 已有三位有效数字时才计算波动（prev和curr都有效，且不是前导零）
                    if (!newLead && st.prev != 10 && st.curr != 10) {
                        if ((st.prev < st.curr && st.curr > digit) ||
                            (st.prev > st.curr && st.curr < digit)) {
                            add = st.cnt;
                        }
                    }

                    cnt[newTight][newLead][newPrev][newCurr] += st.cnt;
                    sum[newTight][newLead][newPrev][newCurr] += st.sum + add;
                }
            }

            // 收集合法状态
            vector<State> nextStates;
            for (int tight = 0; tight < 2; ++tight) {
                for (int lead = 0; lead < 2; ++lead) {
                    for (int prev = 0; prev <= 10; ++prev) {
                        for (int curr = 0; curr <= 10; ++curr) {
                            ll c = cnt[tight][lead][prev][curr];
                            ll s = sum[tight][lead][prev][curr];
                            // 如何当前为有效状态，则进入下一轮计算
                            if (c != 0) {
                                nextStates.push_back({prev, curr, tight, lead, c, s});
                            }
                        }
                    }
                }
            }

            currStates.swap(nextStates);
        }

        // 累加所有合法状态的波动值之和
        ll ans = 0;
        for (const auto& st : currStates) {
            ans += st.sum;
        }
        return ans;
    }

    long long totalWaviness(long long num1, long long num2) {
        return solve(num2) - solve(num1 - 1);
    }
};
```

```Java
class Solution {
    static class State {
        int prev, curr, tight, lead;
        long cnt, sum;

        State(int prev, int curr, int tight, int lead, long cnt, long sum) {
            this.prev = prev;
            this.curr = curr;
            this.tight = tight;
            this.lead = lead;
            this.cnt = cnt;
            this.sum = sum;
        }
    }

    private long solve(long num) {
        // 数字小于 3 位波动值为 0
        if (num < 100) {
            return 0;
        }
        String str = Long.toString(num);
        int n = str.length();

        List<State> currStates = new ArrayList<>();
        // 数位 10 表示存在前导零时的无效状态
        currStates.add(new State(10, 10, 1, 1, 1, 0));

        for (int pos = 0; pos < n; ++pos) {
            int limit = str.charAt(pos) - '0';
            long[][][][] cnt = new long[2][2][11][11];
            long[][][][] sum = new long[2][2][11][11];

            for (State st : currStates) {
                int maxDigit = st.tight == 1 ? limit : 9;
                for (int digit = 0; digit <= maxDigit; ++digit) {
                    int newLead = (st.lead == 1 && digit == 0) ? 1 : 0;
                    int newPrev = st.curr;
                    int newCurr = newLead == 1 ? 10 : digit;
                    int newTight = (st.tight == 1 && digit == maxDigit) ? 1 : 0;

                    long add = 0;
                    // 已有三位有效数字时才计算波动（prev和curr都有效，且不是前导零）
                    if (newLead == 0 && st.prev != 10 && st.curr != 10) {
                        if ((st.prev < st.curr && st.curr > digit) ||
                            (st.prev > st.curr && st.curr < digit)) {
                            add = st.cnt;
                        }
                    }

                    cnt[newTight][newLead][newPrev][newCurr] += st.cnt;
                    sum[newTight][newLead][newPrev][newCurr] += st.sum + add;
                }
            }

            // 收集合法状态
            List<State> nextStates = new ArrayList<>();
            for (int tight = 0; tight < 2; ++tight) {
                for (int lead = 0; lead < 2; ++lead) {
                    for (int prev = 0; prev <= 10; ++prev) {
                        for (int curr = 0; curr <= 10; ++curr) {
                            long c = cnt[tight][lead][prev][curr];
                            long s = sum[tight][lead][prev][curr];
                            // 如果当前为有效状态，则进入下一轮计算
                            if (c != 0) {
                                nextStates.add(new State(prev, curr, tight, lead, c, s));
                            }
                        }
                    }
                }
            }

            currStates = nextStates;
        }

        // 累加所有合法状态的波动值之和
        long ans = 0;
        for (State st : currStates) {
            ans += st.sum;
        }
        return ans;
    }

    public long totalWaviness(long num1, long num2) {
        return solve(num2) - solve(num1 - 1);
    }
}
```

```CSharp
public class Solution {
    private class State {
        public int prev, curr, tight, lead;
        public long cnt, sum;

        public State(int prev, int curr, int tight, int lead, long cnt, long sum) {
            this.prev = prev;
            this.curr = curr;
            this.tight = tight;
            this.lead = lead;
            this.cnt = cnt;
            this.sum = sum;
        }
    }

    private long Solve(long num) {
        // 数字小于 3 位波动值为 0
        if (num < 100) {
            return 0;
        }
        string s = num.ToString();
        int n = s.Length;

        List<State> currStates = new List<State>();
        // 数位 10 表示存在前导零时的无效状态
        currStates.Add(new State(10, 10, 1, 1, 1, 0));

        for (int pos = 0; pos < n; ++pos) {
            int limit = s[pos] - '0';
            long[,,,] cnt = new long[2, 2, 11, 11];
            long[,,,] sum = new long[2, 2, 11, 11];

            foreach (State st in currStates) {
                int maxDigit = st.tight == 1 ? limit : 9;
                for (int digit = 0; digit <= maxDigit; ++digit) {
                    int newLead = (st.lead == 1 && digit == 0) ? 1 : 0;
                    int newPrev = st.curr;
                    int newCurr = newLead == 1 ? 10 : digit;
                    int newTight = (st.tight == 1 && digit == maxDigit) ? 1 : 0;

                    long add = 0;
                    // 已有三位有效数字时才计算波动（prev和curr都有效，且不是前导零）
                    if (newLead == 0 && st.prev != 10 && st.curr != 10) {
                        if ((st.prev < st.curr && st.curr > digit) ||
                            (st.prev > st.curr && st.curr < digit)) {
                            add = st.cnt;
                        }
                    }

                    cnt[newTight, newLead, newPrev, newCurr] += st.cnt;
                    sum[newTight, newLead, newPrev, newCurr] += st.sum + add;
                }
            }

            // 收集合法状态
            List<State> nextStates = new List<State>();
            for (int tight = 0; tight < 2; ++tight) {
                for (int lead = 0; lead < 2; ++lead) {
                    for (int prev = 0; prev <= 10; ++prev) {
                        for (int curr = 0; curr <= 10; ++curr) {
                            long c = cnt[tight, lead, prev, curr];
                            long sVal = sum[tight, lead, prev, curr];
                            // 如果当前为有效状态，则进入下一轮计算
                            if (c != 0) {
                                nextStates.Add(new State(prev, curr, tight, lead, c, sVal));
                            }
                        }
                    }
                }
            }

            currStates = nextStates;
        }

        // 累加所有合法状态的波动值之和
        long ans = 0;
        foreach (State st in currStates) {
            ans += st.sum;
        }
        return ans;
    }

    public long TotalWaviness(long num1, long num2) {
        return Solve(num2) - Solve(num1 - 1);
    }
}
```

```Go
type State struct {
    prev, curr, tight, lead int
    cnt, sum                 int64
}

func solve(num int64) int64 {
    // 数字小于 3 位波动值为 0
    if num < 100 {
        return 0
    }
    s := fmt.Sprintf("%d", num)
    n := len(s)

    currStates := []State{{10, 10, 1, 1, 1, 0}}

    for pos := 0; pos < n; pos++ {
        limit := int(s[pos] - '0')
        cnt := [2][2][11][11]int64{}
        sum := [2][2][11][11]int64{}

        for _, st := range currStates {
            maxDigit := limit
            if st.tight == 0 {
                maxDigit = 9
            }
            for digit := 0; digit <= maxDigit; digit++ {
                newLead := 0
                if st.lead == 1 && digit == 0 {
                    newLead = 1
                }
                newPrev := st.curr
                newCurr := digit
                if newLead == 1 {
                    newCurr = 10
                }
                newTight := 0
                if st.tight == 1 && digit == maxDigit {
                    newTight = 1
                }

                add := int64(0)
                // 已有三位有效数字时才计算波动（prev和curr都有效，且不是前导零）
                if newLead == 0 && st.prev != 10 && st.curr != 10 {
                    if (st.prev < st.curr && st.curr > digit) ||
                        (st.prev > st.curr && st.curr < digit) {
                        add = st.cnt
                    }
                }

                cnt[newTight][newLead][newPrev][newCurr] += st.cnt
                sum[newTight][newLead][newPrev][newCurr] += st.sum + add
            }
        }

        // 收集合法状态
        nextStates := []State{}
        for tight := 0; tight < 2; tight++ {
            for lead := 0; lead < 2; lead++ {
                for prev := 0; prev <= 10; prev++ {
                    for curr := 0; curr <= 10; curr++ {
                        c := cnt[tight][lead][prev][curr]
                        sVal := sum[tight][lead][prev][curr]
                        // 如果当前为有效状态，则进入下一轮计算
                        if c != 0 {
                            nextStates = append(nextStates, State{prev, curr, tight, lead, c, sVal})
                        }
                    }
                }
            }
        }
        currStates = nextStates
    }

    // 累加所有合法状态的波动值之和
    var ans int64 = 0
    for _, st := range currStates {
        ans += st.sum
    }
    return ans
}

func totalWaviness(num1 int64, num2 int64) int64 {
    return solve(num2) - solve(num1-1)
}
```

```Python
class Solution:
    def solve(self, num: int) -> int:
        # 数字小于 3 位波动值为 0
        if num < 100:
            return 0
        s = str(num)
        n = len(s)

        # 数位 10 表示存在前导零时的无效状态
        curr_states = [(10, 10, 1, 1, 1, 0)]  # (prev, curr, tight, lead, cnt, sum)

        for pos in range(n):
            limit = int(s[pos])
            cnt = [[[[0] * 11 for _ in range(11)] for _ in range(2)] for _ in range(2)]
            sum_arr = [[[[0] * 11 for _ in range(11)] for _ in range(2)] for _ in range(2)]

            for prev, curr, tight, lead, c, s_val in curr_states:
                max_digit = limit if tight else 9
                for digit in range(max_digit + 1):
                    new_lead = 1 if (lead and digit == 0) else 0
                    new_prev = curr
                    new_curr = 10 if new_lead else digit
                    new_tight = 1 if (tight and digit == max_digit) else 0

                    add = 0
                    # 已有三位有效数字时才计算波动（prev和curr都有效，且不是前导零）
                    if not new_lead and prev != 10 and curr != 10:
                        if (prev < curr and curr > digit) or (prev > curr and curr < digit):
                            add = c

                    cnt[new_tight][new_lead][new_prev][new_curr] += c
                    sum_arr[new_tight][new_lead][new_prev][new_curr] += s_val + add

            # 收集合法状态
            next_states = []
            for tight in range(2):
                for lead in range(2):
                    for prev in range(11):
                        for cur in range(11):
                            c = cnt[tight][lead][prev][cur]
                            if c != 0:
                                next_states.append((prev, cur, tight, lead, c, sum_arr[tight][lead][prev][cur]))
            curr_states = next_states

        # 累加所有合法状态的波动值之和
        ans = 0
        for _, _, _, _, _, s_val in curr_states:
            ans += s_val
        return ans

    def totalWaviness(self, num1: int, num2: int) -> int:
        return self.solve(num2) - self.solve(num1 - 1)
```

```C
typedef struct {
    int prev, curr, tight, lead;
    long long cnt, sum;
} State;

long long solve(long long num) {
    // 数字小于 3 位波动值为 0
    if (num < 100) {
        return 0;
    }

    char s[20];
    sprintf(s, "%lld", num);
    int n = strlen(s);

    State currStates[500];
    int currSize = 0;

    // 数位 10 表示存在前导零时的无效状态
    currStates[currSize++] = (State){10, 10, 1, 1, 1, 0};

    for (int pos = 0; pos < n; ++pos) {
        int limit = s[pos] - '0';

        // 使用四维数组临时存储，维度: [tight][lead][prev][curr]
        long long cnt[2][2][11][11] = {0};
        long long sum[2][2][11][11] = {0};

        for (int i = 0; i < currSize; ++i) {
            State st = currStates[i];
            int maxDigit = st.tight ? limit : 9;

            for (int digit = 0; digit <= maxDigit; ++digit) {
                int newLead = (st.lead && digit == 0) ? 1 : 0;
                int newPrev = st.curr;
                int newCurr = newLead ? 10 : digit;
                int newTight = (st.tight && digit == maxDigit) ? 1 : 0;

                long long add = 0;
                // 已有三位有效数字时才计算波动（prev和curr都有效，且不是前导零）
                if (!newLead && st.prev != 10 && st.curr != 10) {
                    if ((st.prev < st.curr && st.curr > digit) ||
                        (st.prev > st.curr && st.curr < digit)) {
                        add = st.cnt;
                    }
                }

                cnt[newTight][newLead][newPrev][newCurr] += st.cnt;
                sum[newTight][newLead][newPrev][newCurr] += st.sum + add;
            }
        }

        // 收集合法状态到新数组
        State nextStates[500];
        int nextSize = 0;

        for (int tight = 0; tight < 2; ++tight) {
            for (int lead = 0; lead < 2; ++lead) {
                for (int prev = 0; prev <= 10; ++prev) {
                    for (int curr = 0; curr <= 10; ++curr) {
                        long long c = cnt[tight][lead][prev][curr];
                        long long s_val = sum[tight][lead][prev][curr];
                        // 如果当前为有效状态，则进入下一轮计算
                        if (c != 0) {
                            nextStates[nextSize++] = (State){prev, curr, tight, lead, c, s_val};
                        }
                    }
                }
            }
        }

        // 切换到下一轮状态
        memcpy(currStates, nextStates, nextSize * sizeof(State));
        currSize = nextSize;
    }

    // 累加所有合法状态的波动值之和
    long long ans = 0;
    for (int i = 0; i < currSize; ++i) {
        ans += currStates[i].sum;
    }
    return ans;
}

long long totalWaviness(long long num1, long long num2) {
    return solve(num2) - solve(num1 - 1);
}
```

```JavaScript
var totalWaviness = function(num1, num2) {
    // 计算 [0, num] 内所有数字的波动值总和
    const solve = (num) => {
        // 数字小于 3 位波动值为 0
        if (num < 100) {
            return 0;
        }

        const s = num.toString();
        const n = s.length;
        let currStates = [];
        // 数位 10 表示存在前导零时的无效状态
        currStates.push({ prev: 10, curr: 10, tight: 1, lead: 1, cnt: 1, sum: 0 });

        for (let pos = 0; pos < n; ++pos) {
            const limit = parseInt(s[pos]);

            // 使用四维数组临时存储，维度: [tight][lead][prev][curr]
            const cnt = Array(2).fill().map(() => Array(2).fill().map(() => Array(11).fill().map(() => Array(11).fill(0))));
            const sumArr = Array(2).fill().map(() => Array(2).fill().map(() => Array(11).fill().map(() => Array(11).fill(0))));

            for (const st of currStates) {
                const maxDigit = st.tight ? limit : 9;

                for (let digit = 0; digit <= maxDigit; ++digit) {
                    const newLead = (st.lead && digit === 0) ? 1 : 0;
                    const newPrev = st.curr;
                    const newCurr = newLead ? 10 : digit;
                    const newTight = (st.tight && digit === maxDigit) ? 1 : 0;

                    let add = 0;
                    // 已有三位有效数字时才计算波动（prev和curr都有效，且不是前导零）
                    if (!newLead && st.prev !== 10 && st.curr !== 10) {
                        if ((st.prev < st.curr && st.curr > digit) ||
                            (st.prev > st.curr && st.curr < digit)) {
                            add = st.cnt;
                        }
                    }

                    cnt[newTight][newLead][newPrev][newCurr] += st.cnt;
                    sumArr[newTight][newLead][newPrev][newCurr] += st.sum + add;
                }
            }

            // 收集合法状态到新数组
            const nextStates = [];
            for (let tight = 0; tight < 2; ++tight) {
                for (let lead = 0; lead < 2; ++lead) {
                    for (let prev = 0; prev <= 10; ++prev) {
                        for (let curr = 0; curr <= 10; ++curr) {
                            const c = cnt[tight][lead][prev][curr];
                            const sVal = sumArr[tight][lead][prev][curr];
                            // 如果当前为有效状态，则进入下一轮计算
                            if (c !== 0) {
                                nextStates.push({ prev, curr, tight, lead, cnt: c, sum: sVal });
                            }
                        }
                    }
                }
            }

            currStates = nextStates;
        }

        // 累加所有合法状态的波动值之和
        let ans = 0;
        for (const st of currStates) {
            ans += st.sum;
        }
        return ans;
    };

    return solve(num2) - solve(num1 - 1);
};
```

```TypeScript
function totalWaviness(num1: number, num2: number): number {
    // 计算 [0, num] 内所有数字的波动值总和
    const solve = (num: number): number => {
        // 数字小于 3 位波动值为 0
        if (num < 100) {
            return 0;
        }

        const s: string = num.toString();
        const n: number = s.length;

        interface State {
            prev: number;
            curr: number;
            tight: number;
            lead: number;
            cnt: number;
            sum: number;
        }

        let currStates: State[] = [];
        // 数位 10 表示存在前导零时的无效状态
        currStates.push({ prev: 10, curr: 10, tight: 1, lead: 1, cnt: 1, sum: 0 });
        for (let pos = 0; pos < n; ++pos) {
            const limit: number = parseInt(s[pos]);

            // 使用四维数组临时存储，维度: [tight][lead][prev][curr]
            const cnt: number[][][][] = Array(2).fill(null).map(() =>
                Array(2).fill(null).map(() =>
                    Array(11).fill(null).map(() =>
                        Array(11).fill(0)
                    )
                )
            );
            const sumArr: number[][][][] = Array(2).fill(null).map(() =>
                Array(2).fill(null).map(() =>
                    Array(11).fill(null).map(() =>
                        Array(11).fill(0)
                    )
                )
            );

            for (const st of currStates) {
                const maxDigit: number = st.tight ? limit : 9;

                for (let digit = 0; digit <= maxDigit; ++digit) {
                    const newLead: number = (st.lead && digit === 0) ? 1 : 0;
                    const newPrev: number = st.curr;
                    const newCurr: number = newLead ? 10 : digit;
                    const newTight: number = (st.tight && digit === maxDigit) ? 1 : 0;

                    let add: number = 0;
                    // 已有三位有效数字时才计算波动（prev和curr都有效，且不是前导零）
                    if (!newLead && st.prev !== 10 && st.curr !== 10) {
                        if ((st.prev < st.curr && st.curr > digit) ||
                            (st.prev > st.curr && st.curr < digit)) {
                            add = st.cnt;
                        }
                    }

                    cnt[newTight][newLead][newPrev][newCurr] += st.cnt;
                    sumArr[newTight][newLead][newPrev][newCurr] += st.sum + add;
                }
            }

            // 收集合法状态到新数组
            const nextStates: State[] = [];
            for (let tight = 0; tight < 2; ++tight) {
                for (let lead = 0; lead < 2; ++lead) {
                    for (let prev = 0; prev <= 10; ++prev) {
                        for (let curr = 0; curr <= 10; ++curr) {
                            const c: number = cnt[tight][lead][prev][curr];
                            const sVal: number = sumArr[tight][lead][prev][curr];
                            // 如果当前为有效状态，则进入下一轮计算
                            if (c !== 0) {
                                nextStates.push({ prev, curr, tight, lead, cnt: c, sum: sVal });
                            }
                        }
                    }
                }
            }

            currStates = nextStates;
        }

        // 累加所有合法状态的波动值之和
        let ans: number = 0;
        for (const st of currStates) {
            ans += st.sum;
        }
        return ans;
    };

    return solve(num2) - solve(num1 - 1);
}
```

```Rust
impl Solution {
    fn solve(num: i64) -> i64 {
        // 数字小于 3 位波动值为 0
        if num < 100 {
            return 0;
        }
        let s = num.to_string();
        let n = s.len();
        let chars: Vec<char> = s.chars().collect();

        #[derive(Clone)]
        struct State {
            prev: usize,
            curr: usize,
            tight: usize,
            lead: usize,
            cnt: i64,
            sum: i64,
        }

        // 数位 10 表示存在前导零时的无效状态
        let mut curr_states = vec![State {
            prev: 10,
            curr: 10,
            tight: 1,
            lead: 1,
            cnt: 1,
            sum: 0,
        }];

        for pos in 0..n {
            let limit = (chars[pos] as u8 - b'0') as usize;
            let mut cnt = [[[[0i64; 11]; 11]; 2]; 2];
            let mut sum_arr = [[[[0i64; 11]; 11]; 2]; 2];

            for st in &curr_states {
                let max_digit = if st.tight == 1 { limit } else { 9 };
                for digit in 0..=max_digit {
                    let new_lead = if st.lead == 1 && digit == 0 { 1 } else { 0 };
                    let new_prev = st.curr;
                    let new_curr = if new_lead == 1 { 10 } else { digit };
                    let new_tight = if st.tight == 1 && digit == max_digit { 1 } else { 0 };

                    let mut add = 0;
                    // 已有三位有效数字时才计算波动（prev和curr都有效，且不是前导零）
                    if new_lead == 0 && st.prev != 10 && st.curr != 10 {
                        if (st.prev < st.curr && st.curr > digit) || (st.prev > st.curr && st.curr < digit) {
                            add = st.cnt;
                        }
                    }

                    cnt[new_tight][new_lead][new_prev][new_curr] += st.cnt;
                    sum_arr[new_tight][new_lead][new_prev][new_curr] += st.sum + add;
                }
            }

            // 收集合法状态
            let mut next_states = Vec::new();
            for tight in 0..2 {
                for lead in 0..2 {
                    for prev in 0..=10 {
                        for curr in 0..=10 {
                            let c = cnt[tight][lead][prev][curr];
                            if c != 0 {
                                next_states.push(State {
                                    prev,
                                    curr,
                                    tight,
                                    lead,
                                    cnt: c,
                                    sum: sum_arr[tight][lead][prev][curr],
                                });
                            }
                        }
                    }
                }
            }
            curr_states = next_states;
        }

        // 累加所有合法状态的波动值之和
        let mut ans = 0;
        for st in curr_states {
            ans += st.sum;
        }
        ans
    }

    pub fn total_waviness(num1: i64, num2: i64) -> i64 {
        Self::solve(num2) - Self::solve(num1 - 1)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(D^3\log num_2)$，其中 $D$ 是进制数，在本题中 $D=10$，num_2 表示给定的元素。状态数是 $O(D^2\log num_2)$，计算每个子状态需要的时间为 $O(D)$，因此总的时间为 $O(D^3\log num_2)$。
- 空间复杂度：$O(D^2)$，其中 $D$ 是进制数，在本题中 $D=10$。每一轮迭代计算时，需要临时计算和保存的状态数最多为 $O(D^2)$，因此总的空间为 $O(D^2)$。
