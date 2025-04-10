### [统计强大整数的数目](https://leetcode.cn/problems/count-the-number-of-powerful-integers/solutions/3636119/tong-ji-qiang-da-zheng-shu-de-shu-mu-by-pozr1/)

#### 方法一：数位动态规划

**思路与算法**

题目要求我们求出一个区间范围内，满足后缀部分为 $s$ 的正整数的数量。

注意到区间的范围很大，逐个枚举数字判断的暴力做法既会超时，又会进行很多不必要的枚举。实际上，我们可以固定后缀 $s$，只考虑有多少种前缀可以与它组成大小在范围内的数字即可。这符合数位 $dp$ 的运用条件。关于数位动态规划的详细介绍可以参考 「[2719\. 统计整数数目 题解](https://leetcode.cn/problems/count-of-integers/solutions/2601111/tong-ji-zheng-shu-shu-mu-by-leetcode-sol-qxqd/)」。

定义 $dfs(i,limitLow,limitHigh)$ 表示第 $i$ 位及其之后数位所能够组成满足条件的数字数量，以及：

- $limitLow$ 表示当前是否受到 $start$ 的约束，如果为 $true$，意味着前 $i-1$ 位与 $start$ 相同，那么在第 $i$ 位可以填入的数字范围是 $[start[i],9]$。如果当前位受到约束且填入了 $start[i]$，那么下一位依然受到约束。将这位数字计作 $lo$。
- $limitHigh$ 与 $limitLow$ 类似，表示当前是否受到 $finish$ 的约束，如果为 $true$，意味着前 $i-1$ 位与 $finish$ 相同。在第 $i$ 位可以填入的数字范围是 $[0,min(finish[i],limit)]$。将这位数字计作 $hi$。
- 如果第 $i$ 位数字没有受到约束，那么可以填入 $[0,limit]$ 的任意数字。注意，不要忘记题目要求每个数位至多是 $limit$。

我们使用递归枚举第 $i$ 位填的数字，那么对于前缀和后缀两个部份转移方程如下，其中 $\vert s \vert$ 表示 $s$ 的长度：

$$dfs(i,limitLow,limitHigh)= \begin{cases} ​1, & i = n \\ \sum\limits_{d=lo}^{min(hi,limit)}​dfs(i+1,limitLow \wedge (d=lo),limitHigh \wedge (d=hi)), & i<n- \vert s \vert \\ dfs(i+1,limitLow \wedge (d=lo),limitHigh \wedge (d=hi)), & ​i \ge n- \vert s \vert ,d=s[i-(n- \vert s \vert )]​ \end{cases}$$

一开始，我们从 $dfs(0,true,true)$ 开始，表示从最高位开始枚举，且受到 $start$ 和 $finish$ 约束。根据题意，在前缀部份的数位中，我们可以填入满足约束条件的任何数，但在后缀部份每一位都是固定的。

在枚举完第 $i$ 个数位能够填入的数字后，之后填入的数字并不会改变这个结果，因此我们可以使用记忆化的方法来避免重复计算。注意，对于受到 $limitLow$ 或 $limitHigh$ 约束的状态来说，它们只会被遍历到一次。这是因为如果当前位受到约束，那么前面的所有位都受到约束，这只有一种方案，所以我们只需要记忆化没有受到约束的状态即可。

**代码**

```C++
class Solution {
public:
    long long numberOfPowerfulInt(long long start, long long finish, int limit,
                                  string s) {
        string low = to_string(start);
        string high = to_string(finish);
        int n = high.size();
        low = string(n - low.size(), '0') + low; // 对齐位数
        int pre_len = n - s.size();              // 前缀长度

        vector<long long> memo(n, -1);
        std::function<long long(int, bool, bool)> dfs =
            [&](int i, bool limit_low,
                bool limit_high) -> long long {
            // 递归边界
            if (i == low.size()) {
                return 1;
            }

            if (!limit_low && !limit_high && memo[i] != -1) {
                return memo[i];
            }

            int lo = limit_low ? low[i] - '0' : 0;
            int hi = limit_high ? high[i] - '0' : 9;

            long long res = 0;
            if (i < pre_len) {
                for (int digit = lo; digit <= min(hi, limit); digit++) {
                    res += dfs(i + 1, limit_low && digit == lo,
                               limit_high && digit == hi);
                }
            } else {
                int x = s[i - pre_len] - '0';
                if (lo <= x && x <= min(hi, limit)) {
                    res =
                        dfs(i + 1, limit_low && x == lo, limit_high && x == hi);
                }
            }

            if (!limit_low && !limit_high) {
                memo[i] = res;
            }
            return res;
        };
        return dfs(0, true, true);
    }
};
```

```Java
class Solution {
    public long numberOfPowerfulInt(long start, long finish, int limit, String s) {
        String low = Long.toString(start);
        String high = Long.toString(finish);
        int n = high.length();
        low = String.format("%" + n + "s", low).replace(' ', '0'); // 对齐位数
        int pre_len = n - s.length(); // 前缀长度
        long[] memo = new long[n];
        Arrays.fill(memo, -1);
        
        return dfs(0, true, true, low, high, limit, s, pre_len, memo);
    }

    private long dfs(int i, boolean limit_low, boolean limit_high, 
                    String low, String high, int limit, String s, 
                    int pre_len, long[] memo) {
        // 递归边界
        if (i == low.length()) {
            return 1;
        }
        if (!limit_low && !limit_high && memo[i] != -1) {
            return memo[i];
        }

        int lo = limit_low ? low.charAt(i) - '0' : 0;
        int hi = limit_high ? high.charAt(i) - '0' : 9;
        long res = 0;
        if (i < pre_len) {
            for (int digit = lo; digit <= Math.min(hi, limit); digit++) {
                res += dfs(i + 1, limit_low && digit == lo,
                          limit_high && digit == hi,
                          low, high, limit, s, pre_len, memo);
            }
        } else {
            int x = s.charAt(i - pre_len) - '0';
            if (lo <= x && x <= Math.min(hi, limit)) {
                res = dfs(i + 1, limit_low && x == lo,
                         limit_high && x == hi,
                         low, high, limit, s, pre_len, memo);
            }
        }
        if (!limit_low && !limit_high) {
            memo[i] = res;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s) {
        string low = start.ToString();
        string high = finish.ToString();
        int n = high.Length;
        low = low.PadLeft(n, '0'); // 对齐位数
        int pre_len = n - s.Length; // 前缀长度
        long[] memo = new long[n];
        Array.Fill(memo, -1);

        return Dfs(0, true, true, low, high, limit, s, pre_len, memo);
    }

    private long Dfs(int i, bool limitLow, bool limitHigh, 
                    string low, string high, int limit, string s, 
                    int preLen, long[] memo) {
        // 递归边界
        if (i == low.Length) {
            return 1;
        }
        if (!limitLow && !limitHigh && memo[i] != -1) {
            return memo[i];
        }
        int lo = limitLow ? low[i] - '0' : 0;
        int hi = limitHigh ? high[i] - '0' : 9;
        long res = 0;
        if (i < preLen) {
            for (int digit = lo; digit <= Math.Min(hi, limit); digit++) {
                res += Dfs(i + 1, limitLow && digit == lo,
                          limitHigh && digit == hi,
                          low, high, limit, s, preLen, memo);
            }
        } else {
            int x = s[i - preLen] - '0';
            if (lo <= x && x <= Math.Min(hi, limit)) {
                res = Dfs(i + 1, limitLow && x == lo,
                         limitHigh && x == hi,
                         low, high, limit, s, preLen, memo);
            }
        }

        if (!limitLow && !limitHigh) {
            memo[i] = res;
        }
        return res;
    }
}
```

```Go
func numberOfPowerfulInt(start int64, finish int64, limit int, s string) int64 {
    low := fmt.Sprintf("%d", start)
    high := fmt.Sprintf("%d", finish)
    n := len(high)
    low = strings.Repeat("0", n - len(low)) + low // 对齐位数
    pre_len := n - len(s)                       // 前缀长度
    memo := make([]int64, n)
    for i := range memo {
        memo[i] = -1
    }

    var dfs func(int, bool, bool) int64
    dfs = func(i int, limit_low, limit_high bool) int64 {
        // 递归边界
        if i == n {
            return 1
        }
        if !limit_low && !limit_high && memo[i] != -1 {
            return memo[i]
        }
        lo := 0
        if limit_low {
            lo = int(low[i] - '0')
        }
        hi := 9
        if limit_high {
            hi = int(high[i] - '0')
        }

        var res int64 = 0
        if i < pre_len {
            for digit := lo; digit <= min(hi, limit); digit++ {
                res += dfs(i + 1, limit_low && digit == lo, limit_high && digit == hi)
            }
        } else {
            x := int(s[i - pre_len] - '0')
            if lo <= x && x <= min(hi, limit) {
                res = dfs(i + 1, limit_low && x == lo, limit_high && x == hi)
            }
        }

        if !limit_low && !limit_high {
            memo[i] = res
        }
        return res
    }
    return dfs(0, true, true)
}
```

```Python
class Solution:
    def numberOfPowerfulInt(self, start: int, finish: int, limit: int, s: str) -> int:
        low = str(start)
        high = str(finish)
        n = len(high)
        low = low.zfill(n)  # 对齐位数
        pre_len = n - len(s)  # 前缀长度

        @cache
        def dfs(i, limit_low, limit_high):
            # 递归边界
            if i == n:
                return 1
            lo = int(low[i]) if limit_low else 0
            hi = int(high[i]) if limit_high else 9
            res = 0
            if i < pre_len:
                for digit in range(lo, min(hi, limit) + 1):
                    res += dfs(i + 1, limit_low and digit == lo, limit_high and digit == hi)
            else:
                x = int(s[i - pre_len])
                if lo <= x <= min(hi, limit):
                    res = dfs(i + 1, limit_low and x == lo, limit_high and x == hi)
                    
            return res

        return dfs(0, True, True)
```

```C
long long dfs(int i, bool limit_low, bool limit_high, 
             const char* low, const char* high, int limit, 
             const char* s, int pre_len, long long* memo, int n) {
    // 递归边界
    if (i == n) {
        return 1;
    }
    if (!limit_low && !limit_high && memo[i] != -1) {
        return memo[i];
    }

    int lo = limit_low ? low[i] - '0' : 0;
    int hi = limit_high ? high[i] - '0' : 9;
    long long res = 0;
    if (i < pre_len) {
        for (int digit = lo; digit <= fmin(hi, limit); digit++) {
            res += dfs(i + 1, limit_low && digit == (low[i] - '0'),
                      limit_high && digit == (high[i] - '0'),
                      low, high, limit, s, pre_len, memo, n);
        }
    } else {
        int x = s[i - pre_len] - '0';
        if (lo <= x && x <= fmin(hi, limit)) {
            res = dfs(i + 1, limit_low && x == (low[i] - '0'),
                     limit_high && x == (high[i] - '0'),
                     low, high, limit, s, pre_len, memo, n);
        }
    }
    if (!limit_low && !limit_high) {
        memo[i] = res;
    }
    return res;
}

long long numberOfPowerfulInt(long long start, long long finish, int limit, char* s) {
    char low[32], high[32];
    sprintf(low, "%lld", start);
    sprintf(high, "%lld", finish);
    int n = strlen(high);
    char* padded_low = (char*)malloc(n + 1);
    
    memset(padded_low, '0', sizeof(char) * n);  
    sprintf(padded_low + n - strlen(low), "%s", low); // 对齐位数
    int pre_len = n - strlen(s); // 前缀长度
    long long* memo = (long long*)malloc(n * sizeof(long long));
    for (int i = 0; i < n; i++) {
        memo[i] = -1;
    }
    long long result = dfs(0, true, true, padded_low, high, limit, s, pre_len, memo, n);
    free(padded_low);
    free(memo);

    return result;
}
```

```JavaScript
var numberOfPowerfulInt = function(start, finish, limit, s) {
    let low = start.toString();
    let high = finish.toString();
    const n = high.length;
    low = low.padStart(n, '0'); // 对齐位数
    const pre_len = n - s.length; // 前缀长度
    const memo = new Array(n).fill(-1);

    function dfs(i, limit_low, limit_high) {
        // 递归边界
        if (i === n) {
            return 1;
        }
        if (!limit_low && !limit_high && memo[i] !== -1) {
            return memo[i];
        }
        
        const lo = limit_low ? parseInt(low[i]) : 0;
        const hi = limit_high ? parseInt(high[i]) : 9;
        let res = 0;
        if (i < pre_len) {
            for (let digit = lo; digit <= Math.min(hi, limit); digit++) {
                res += dfs(i + 1, limit_low && digit === lo, limit_high && digit === hi);
            }
        } else {
            const x = parseInt(s[i - pre_len]);
            if (lo <= x && x <= Math.min(hi, limit)) {
                res = dfs(i + 1, limit_low && x === lo, limit_high && x === hi);
            }
        }
        if (!limit_low && !limit_high) {
            memo[i] = res;
        }

        return res;
    }

    return dfs(0, true, true);
}
```

```TypeScript
function numberOfPowerfulInt(start: number, finish: number, limit: number, s: string): number {
    let low = start.toString();
    let high = finish.toString();
    const n = high.length;
    low = low.padStart(n, '0'); // 对齐位数
    const pre_len = n - s.length; // 前缀长度
    const memo: number[] = new Array(n).fill(-1);

    function dfs(i: number, limit_low: boolean, limit_high: boolean): number {
        // 递归边界
        if (i === n) {
            return 1;
        }
        if (!limit_low && !limit_high && memo[i] !== -1) {
            return memo[i];
        }
        
        const lo = limit_low ? parseInt(low[i]) : 0;
        const hi = limit_high ? parseInt(high[i]) : 9;
        let res = 0;
        if (i < pre_len) {
            for (let digit = lo; digit <= Math.min(hi, limit); digit++) {
                res += dfs(i + 1, limit_low && digit === lo, limit_high && digit === hi);
            }
        } else {
            const x = parseInt(s[i - pre_len]);
            if (lo <= x && x <= Math.min(hi, limit)) {
                res = dfs(i + 1, limit_low && x === lo, limit_high && x === hi);
            }
        }
        if (!limit_low && !limit_high) {
            memo[i] = res;
        }

        return res;
    }

    return dfs(0, true, true);
}
```

```Rust
use std::cmp::min;

impl Solution {
    pub fn number_of_powerful_int(start: i64, finish: i64, limit: i32, s: String) -> i64 {
        let low = start.to_string();
        let high = finish.to_string();
        let n = high.len();
        let low = format!("{:0>width$}", low, width = n); // 对齐位数
        let pre_len = n - s.len(); // 前缀长度
        let mut memo = vec![-1; n];

        fn dfs(
            i: usize,
            limit_low: bool,
            limit_high: bool,
            low: &[u8],
            high: &[u8],
            limit: i32,
            s: &[u8],
            pre_len: usize,
            memo: &mut Vec<i64>,
        ) -> i64 {
            // 递归边界
            if i == low.len() {
                return 1;
            }
            if !limit_low && !limit_high && memo[i] != -1 {
                return memo[i];
            }

            let lo = if limit_low { (low[i] - b'0') as i32 } else { 0 };
            let hi = if limit_high { (high[i] - b'0') as i32 } else { 9 };
            let mut res = 0;
            if i < pre_len {
                for digit in lo..= min(hi, limit) {
                    res += dfs(
                        i + 1,
                        limit_low && digit == (low[i] - b'0') as i32,
                        limit_high && digit == (high[i] - b'0') as i32,
                        low,
                        high,
                        limit,
                        s,
                        pre_len,
                        memo,
                    );
                }
            } else {
                let x = (s[i - pre_len] - b'0') as i32;
                if lo <= x && x <= min(hi, limit) {
                    res = dfs(
                        i + 1,
                        limit_low && x == (low[i] - b'0') as i32,
                        limit_high && x == (high[i] - b'0') as i32,
                        low,
                        high,
                        limit,
                        s,
                        pre_len,
                        memo,
                    );
                }
            }
            if !limit_low && !limit_high {
                memo[i] = res;
            }
            res
        }

        dfs(
            0,
            true,
            true,
            low.as_bytes(),
            high.as_bytes(),
            limit,
            s.as_bytes(),
            pre_len,
            &mut memo,
        )
    }
}
```

**复杂度分析**

- 时间复杂度：$O(log(finish) \times 10)$。我们枚举每一个数位能够填入的数字，数位的长度即为 $log(finish)$，而一位上只有 $[0,9]$ 共 $10$ 个数字。
- 空间复杂度：$O(log(finish))$。我们需要一个长度与数位长度相同的数组来记忆化每一个数位的结果。

#### 方法二：组合数学

**思路与算法**

我们可以实现一个计数函数 $calculate(x)$ 来直接计算小于等于 $x$ 的满足 $limit$ 的数字数量，然后答案即为 $calculate(finish)-calculate(start-1)$。

首先考虑 $x$ 中与 $s$ 长度相等的后缀部份（如果 $x$ 长度小于 $s$，答案为 $0$），如果 $x$ 的后缀大于等于 $s$，那么后缀部份对答案贡献为 $1$。

接着考虑剩余的前缀部份。令 $preLen$ 表示前缀的长度，即 $\vert x \vert - \vert s \vert$。对于前缀的每一位 $x[i]$：

- 如果超过了 $limit$，意味着当前位最多只能取到 $limit$，后面的所有位任取组成的数字也不会超过 $x$。因此包括第 $i$ 位，后面的所有位（共 $preLen-i$ 位）都可以取 $[0,limit]$（共 $limit+1$ 个数），对答案的贡献是 $(limit+1)preLen-i$。
- 如果 $x[i]$ 没有超过 $limit$，那么当前位最多取到 $x[i]$，后面的所有位可以取 $[0,limit]$，对答案的贡献是 $x[i] \times (limit+1)preLen-i-1$。

**代码**

```C++
class Solution {
public:
    long long numberOfPowerfulInt(long long start, long long finish, int limit,
                                  string s) {
        string start_ = to_string(start - 1), finish_ = to_string(finish);
        return calculate(finish_, s, limit) - calculate(start_, s, limit);
    }

    long long calculate(string x, string s, int limit) {
        if (x.length() < s.length()) {
            return 0;
        }
        if (x.length() == s.length()) {
            return x >= s ? 1 : 0;
        }

        string suffix = x.substr(x.length() - s.length(), s.length());
        long long count = 0;
        int preLen = x.length() - s.length();

        for (int i = 0; i < preLen; i++) {
            if (limit < (x[i] - '0')) {
                count += (long)pow(limit + 1, preLen - i);
                return count;
            }
            count += (long)(x[i] - '0') * (long)pow(limit + 1, preLen - 1 - i);
        }
        if (suffix >= s) {
            count++;
        }
        return count;
    }
};
```

```Java
class Solution {
    public long numberOfPowerfulInt(long start, long finish, int limit, String s) {
        String start_ = Long.toString(start - 1);
        String finish_ = Long.toString(finish);
        return calculate(finish_, s, limit) - calculate(start_, s, limit);
    }

    private long calculate(String x, String s, int limit) {
        if (x.length() < s.length()) {
            return 0;
        }
        if (x.length() == s.length()) {
            return x.compareTo(s) >= 0 ? 1 : 0;
        }

        String suffix = x.substring(x.length() - s.length());
        long count = 0;
        int preLen = x.length() - s.length();

        for (int i = 0; i < preLen; i++) {
            int digit = x.charAt(i) - '0';
            if (limit < digit) {
                count += (long) Math.pow(limit + 1, preLen - i);
                return count;
            }
            count += (long) (digit) * (long) Math.pow(limit + 1, preLen - 1 - i);
        }
        if (suffix.compareTo(s) >= 0) {
            count++;
        }
        return count;
    }
}
```

```Python
class Solution:
    def numberOfPowerfulInt(self, start: int, finish: int, limit: int, s: str) -> int:
        start_ = str(start - 1)
        finish_ = str(finish)
        return self.calculate(finish_, s, limit) - self.calculate(start_, s, limit)

    def calculate(self, x: str, s: str, limit: int) -> int:
        if len(x) < len(s):
            return 0
        if len(x) == len(s):
            return 1 if x >= s else 0

        suffix = x[len(x) - len(s) :]
        count = 0
        pre_len = len(x) - len(s)

        for i in range(pre_len):
            if limit < int(x[i]):
                count += (limit + 1) ** (pre_len - i)
                return count
            count += int(x[i]) * (limit + 1) ** (pre_len - 1 - i)

        if suffix >= s:
            count += 1

        return count

```

```CSharp
public class Solution {
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s) {
        string start_ = (start - 1).ToString();
        string finish_ = finish.ToString();
        return Calculate(finish_, s, limit) - Calculate(start_, s, limit);
    }

    private long Calculate(string x, string s, int limit) {
        if (x.Length < s.Length) {
            return 0;
        }
        if (x.Length == s.Length) {
            return string.Compare(x, s) >= 0 ? 1 : 0;
        }

        string suffix = x.Substring(x.Length - s.Length);
        long count = 0;
        int preLen = x.Length - s.Length;

        for (int i = 0; i < preLen; i++) {
            int digit = x[i] - '0';
            if (limit < digit) {
                count += (long) Math.Pow(limit + 1, preLen - i);
                return count;
            }
            count += (long) digit * (long) Math.Pow(limit + 1, preLen - 1 - i);
        }
        if (string.Compare(suffix, s) >= 0) {
            count++;
        }
        return count;
    }
}
```

```Go
func numberOfPowerfulInt(start int64, finish int64, limit int, s string) int64 {
    start_ := strconv.FormatInt(start - 1, 10)
    finish_ := strconv.FormatInt(finish, 10)
    return calculate(finish_, s, limit) - calculate(start_, s, limit)
}

func calculate(x string, s string, limit int) int64 {
    if len(x) < len(s) {
        return 0
    }
    if len(x) == len(s) {
        if x >= s {
            return 1
        }
        return 0
    }

    suffix := x[len(x) - len(s):]
    var count int64
    preLen := len(x) - len(s)

    for i := 0; i < preLen; i++ {
        digit := int(x[i] - '0')
        if limit < digit {
            count += int64(math.Pow(float64(limit + 1), float64(preLen - i)))
            return count
        }
        count += int64(digit) * int64(math.Pow(float64(limit + 1), float64(preLen - 1- i)))
    }
    if suffix >= s {
        count++
    }
    return count
}
```

```C
long long calculate(const char* x, const char* s, int limit) {
    int x_len = strlen(x);
    int s_len = strlen(s);
    if (x_len < s_len) {
        return 0;
    }
    if (x_len == s_len) {
        return strcmp(x, s) >= 0 ? 1 : 0;
    }

    char* suffix = (char*)malloc(s_len + 1);
    strncpy(suffix, x + x_len - s_len, s_len);
    suffix[s_len] = '\0';
    long long count = 0;
    int preLen = x_len - s_len;
    
    for (int i = 0; i < preLen; i++) {
        int digit = x[i] - '0';
        if (limit < digit) {
            count += (long long)pow(limit + 1, preLen - i);
            free(suffix);
            return count;
        }
        count += (long long)digit * (long long)pow(limit + 1, preLen - 1 - i);
    }
    if (strcmp(suffix, s) >= 0) {
        count++;
    }
    free(suffix);
    return count;
}

long long numberOfPowerfulInt(long long start, long long finish, int limit, const char* s) {
    char start_[20], finish_[20];
    sprintf(start_, "%lld", start - 1);
    sprintf(finish_, "%lld", finish);
    return calculate(finish_, s, limit) - calculate(start_, s, limit);
}
```

```JavaScript
var numberOfPowerfulInt = function(start, finish, limit, s) {
    const start_ = (start - 1).toString();
    const finish_ = finish.toString();
    return calculate(finish_, s, limit) - calculate(start_, s, limit);
}

function calculate(x, s, limit) {
    if (x.length < s.length) {
        return 0;
    }
    if (x.length === s.length) {
        return x >= s ? 1 : 0;
    }

    const suffix = x.slice(-s.length);
    let count = 0;
    const preLen = x.length - s.length;

    for (let i = 0; i < preLen; i++) {
        const digit = parseInt(x[i]);
        if (limit < digit) {
            count += Math.pow(limit + 1, preLen - i);
            return count;
        }
        count += digit * Math.pow(limit + 1, preLen - 1 - i);
    }
    if (suffix >= s) {
        count++;
    }
    return count;
}
```

```TypeScript
function numberOfPowerfulInt(start: number, finish: number, limit: number, s: string): number {
    const start_ = (start - 1).toString();
    const finish_ = finish.toString();
    return calculate(finish_, s, limit) - calculate(start_, s, limit);
};
    
function calculate(x: string, s: string, limit: number): number {
    if (x.length < s.length) {
        return 0;
    }
    if (x.length === s.length) {
        return x >= s ? 1 : 0;
    }

    const suffix = x.slice(-s.length);
    let count = 0;
    const preLen = x.length - s.length;

    for (let i = 0; i < preLen; i++) {
        const digit = parseInt(x[i]);
        if (limit < digit) {
            count += Math.pow(limit + 1, preLen - i);
            return count;
        }
        count += digit * Math.pow(limit + 1, preLen - 1 - i);
    }
    if (suffix >= s) {
        count++;
    }
    return count;
}
```

```Rust
impl Solution {
    pub fn number_of_powerful_int(start: i64, finish: i64, limit: i32, s: String) -> i64 {
        let start_ = (start - 1).to_string();
        let finish_ = finish.to_string();
        let val1 = Self::calculate(&finish_, &s, limit);
        let val2 = Self::calculate(&start_, &s, limit);
        Self::calculate(&finish_, &s, limit) - Self::calculate(&start_, &s, limit)
    }

    pub fn calculate(x: &str, s: &str, limit: i32) -> i64 {
        if x.len() < s.len() {
            return 0;
        }
        if x.len() == s.len() {
            return if x >= s { 1 } else { 0 };
        }

        let suffix = &x[x.len() - s.len()..];
        let mut count = 0i64;
        let pre_len = x.len() - s.len();

        for i in 0..pre_len {
            let digit = x.chars().nth(i).unwrap().to_digit(10).unwrap() as i32;
            if limit < digit {
                count += ((limit + 1) as i64).pow((pre_len - i) as u32);
                return count;
            }
            count += (digit as i64) * ((limit + 1) as i64).pow((pre_len - 1 - i) as u32);
        }
        if suffix >= s {
            count += 1;
        }
        count
    }
}
```

**复杂度分析**

- 时间复杂度：$O(log(finish))$。遍历 $finish$ 的每一位数来累加组合数。
- 空间复杂度：$O(log(finish))$。我们需要一个与数位长度相同的数组保存后缀。
