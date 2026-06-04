### [范围内总波动值 I](https://leetcode.cn/problems/total-waviness-of-numbers-in-range-i/solutions/3977833/fan-wei-nei-zong-bo-dong-zhi-i-by-leetco-wvv5/)

#### 方法一：枚举

**思路与算法**

由于给定的数范围为 $1\le num_1\le num_2\le 10^5$，我们直接枚举区间 $[num_1,num_2]$ 的每个数，并计算每个数的波动值，累加所有数的波动值即为答案。

计算给定的数 $x$ 的波动值时，我们可以将每个整数转化为字符串形式，然后遍历字符串并求出 **峰** 与 **谷** 的数目即为波动值。

**代码**

```C++
class Solution {
public:
    int totalWaviness(int num1, int num2) {
        auto getWaviness = [](int x) -> int {
            string s = to_string(x);
            int waviness = 0;

            for (size_t i = 1; i < s.size() - 1; ++i) {
                bool isPeak = s[i] > s[i - 1] && s[i] > s[i + 1];
                bool isValley = s[i] < s[i - 1] && s[i] < s[i + 1];
                if (isPeak || isValley) {
                    ++waviness;
                }
            }

            return waviness;
        };

        int total = 0;
        for (int i = num1; i <= num2; ++i) {
            total += getWaviness(i);
        }

        return total;
    }
};
```

```Java
class Solution {
    public int totalWaviness(int num1, int num2) {
        int total = 0;
        for (int i = num1; i <= num2; i++) {
            total += getWaviness(i);
        }
        return total;
    }

    private int getWaviness(int x) {
        String s = Integer.toString(x);
        int waviness = 0;

        for (int i = 1; i < s.length() - 1; i++) {
            boolean isPeak = s.charAt(i) > s.charAt(i - 1) && s.charAt(i) > s.charAt(i + 1);
            boolean isValley = s.charAt(i) < s.charAt(i - 1) && s.charAt(i) < s.charAt(i + 1);
            if (isPeak || isValley) {
                waviness++;
            }
        }

        return waviness;
    }
}
```

```CSharp
public class Solution {
    public int TotalWaviness(int num1, int num2) {
        int total = 0;
        for (int i = num1; i <= num2; i++) {
            total += GetWaviness(i);
        }
        return total;
    }

    private int GetWaviness(int x) {
        string s = x.ToString();
        int waviness = 0;

        for (int i = 1; i < s.Length - 1; i++) {
            bool isPeak = s[i] > s[i - 1] && s[i] > s[i + 1];
            bool isValley = s[i] < s[i - 1] && s[i] < s[i + 1];
            if (isPeak || isValley) {
                waviness++;
            }
        }

        return waviness;
    }
}
```

```Go
func totalWaviness(num1 int, num2 int) int {
    getWaviness := func(x int) int {
        str := strconv.Itoa(x)
        waviness := 0

        for i := 1; i < len(str)-1; i++ {
            isPeak := str[i] > str[i-1] && str[i] > str[i+1]
            isValley := str[i] < str[i-1] && str[i] < str[i+1]
            if isPeak || isValley {
                waviness++
            }
        }

        return waviness
    }

    total := 0
    for i := num1; i <= num2; i++ {
        total += getWaviness(i)
    }

    return total
}
```

```Python
class Solution:
    def totalWaviness(self, num1: int, num2: int) -> int:
        def waviness(n: int) -> int:
            s = str(n)
            return sum((a < b > c) or (a > b < c)
                      for a, b, c in zip(s, s[1:], s[2:]))

        return sum(waviness(n) for n in range(num1, num2 + 1))
```

```C
int getWaviness(int x) {
    char s[12];
    sprintf(s, "%d", x);
    int waviness = 0;
    int len = strlen(s);

    for (int i = 1; i < len - 1; i++) {
        int isPeak = s[i] > s[i - 1] && s[i] > s[i + 1];
        int isValley = s[i] < s[i - 1] && s[i] < s[i + 1];
        if (isPeak || isValley) {
            waviness++;
        }
    }

    return waviness;
}

int totalWaviness(int num1, int num2) {
    int total = 0;
    for (int i = num1; i <= num2; i++) {
        total += getWaviness(i);
    }
    return total;
}
```

```JavaScript
var totalWaviness = function(num1, num2) {
    const getWaviness = (x) => {
        const s = x.toString();
        let waviness = 0;

        for (let i = 1; i < s.length - 1; i++) {
            const isPeak = s[i] > s[i - 1] && s[i] > s[i + 1];
            const isValley = s[i] < s[i - 1] && s[i] < s[i + 1];
            if (isPeak || isValley) {
                waviness++;
            }
        }

        return waviness;
    };

    let total = 0;
    for (let i = num1; i <= num2; i++) {
        total += getWaviness(i);
    }

    return total;
};
```

```TypeScript
function totalWaviness(num1: number, num2: number): number {
    const getWaviness = (x: number): number => {
        const s: string = x.toString();
        let waviness: number = 0;

        for (let i = 1; i < s.length - 1; i++) {
            const isPeak: boolean = s[i] > s[i - 1] && s[i] > s[i + 1];
            const isValley: boolean = s[i] < s[i - 1] && s[i] < s[i + 1];
            if (isPeak || isValley) {
                waviness++;
            }
        }

        return waviness;
    };

    let total: number = 0;
    for (let i = num1; i <= num2; i++) {
        total += getWaviness(i);
    }

    return total;
};
```

```Rust
impl Solution {
    pub fn total_waviness(num1: i32, num2: i32) -> i32 {
        fn get_waviness(x: i32) -> i32 {
            let s = x.to_string();
            let chars: Vec<char> = s.chars().collect();
            let mut waviness = 0;

            for i in 1..chars.len() - 1 {
                let is_peak = chars[i] > chars[i - 1] && chars[i] > chars[i + 1];
                let is_valley = chars[i] < chars[i - 1] && chars[i] < chars[i + 1];
                if is_peak || is_valley {
                    waviness += 1;
                }
            }

            waviness
        }

        let mut total = 0;
        for i in num1..=num2 {
            total += get_waviness(i);
        }

        total
    }
}
```

**复杂度分析**

- 时间复杂度：$O(num_2\cdot \log num_2)$，其中 $num_2$ 表示给定的数。需要遍历区间 $[num_1,num_2]$，区间内包含的整数个数的上限是 $num_2$，遍历每个整数的数位需要的时间为 $O(\log num_2)$，因此总的时间为 $O(num_2\cdot \log num_2)$。
- 空间复杂度：$O(\log num_2)$，其中 $num_2$ 表示给定的数。每个整数的数位需要的空间为 $O(\log num_2)$。

#### 方法二：数位动态规划

**思路与算法**

本题涉及到数字计数的问题，我们可以采用 $\lceil$ [**数位 DP**](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fdp%2Fnumber%2F)$\rfloor$，先计算 $[0,x]$ 内所有数的波动值总和，再用前缀和思想得到答案。设 $solve(x)$ 表示 $[0,x]$ 内所有数的波动值总和，此时可以得到推理如下：

$$ans=solve(num_2)-solve(num_1-1)$$

对于 $solve(x)$，我们使用 **记忆化搜索**（自顶向下）实现数位 $DP$。核心思想：从左向右逐位确定数字，并记录已经固定的前两位，并利用 $isLimit$ 和 $isLeading$ 处理边界和前导零。$ $
在进行 $DFS$ 时，我们需要关注以下信息：

- $pos$：当前正在处理的数位下标（$0 \sim n-1$，从左到右）。
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
    int totalWaviness(int num1, int num2) {
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

            auto [_, totalSum] = dfs(0, -1, -1, true, true);
            return totalSum;
        };

        return (int)(solve(num2) - solve(num1 - 1));
    }
};
```

```Java
class Solution {
    private String s;
    private int n;
    private long[][][] memo_cnt;
    private long[][][] memo_sum;

    public int totalWaviness(int num1, int num2) {
        return (int)(solve(num2) - solve(num1 - 1));
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

    public int TotalWaviness(int num1, int num2) {
        return (int)(Solve(num2) - Solve(num1 - 1));
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
func totalWaviness(num1 int, num2 int) int {
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

    return int(solve(int64(num2)) - solve(int64(num1-1)))
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
           long long memo_cnt[16][10][10],
           long long memo_sum[16][10][10],
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

    char s[16];
    sprintf(s, "%lld", num);
    int n = strlen(s);

    // 记忆化搜索使用两个独立的数组
    // memo_cnt[pos][x][y]：当前位为 pos 位，且前两位为 x, y 的合法填充方案数
    long long memo_cnt[16][10][10];
    // memo_sum[pos][x][y]：当前位为 pos 位，且左边两位为 x, y 的波动值
    long long memo_sum[16][10][10];
    // 初始化记忆化数组
    memset(memo_cnt, -1, sizeof(memo_cnt));
    memset(memo_sum, -1, sizeof(memo_sum));

    Result result = dfs(s, n, memo_cnt, memo_sum, 0, -1, -1, 1, 1);
    return result.sum;
}

int totalWaviness(int num1, int num2) {
    return (int)(solve(num2) - solve(num1 - 1));
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
    pub fn total_waviness(num1: i32, num2: i32) -> i32 {
        // 计算 [0, num] 内所有数字的波动值总和
        fn solve(num: i32) -> i64 {
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

        (solve(num2) - solve(num1 - 1)) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(D^3\log num_2)$，其中 $D$ 是进制数，在本题中 $D=10$，$num_2$ 表示给定的元素。记忆化搜索的状态数是 $O(D^2\log num_2)$，计算每个子状态需要的时间为 $O(D)$，因此总的时间为 $O(D^3\log num_2)$。
- 空间复杂度：$O(D^2\log num_2)$，其中 $D$ 是进制数，在本题中 $D=10$，$num_2$ 表示给定的元素。递归栈的深度为 $\log num_2$，记忆化搜索的状态数是 $O(D^2\log num_2)$。
