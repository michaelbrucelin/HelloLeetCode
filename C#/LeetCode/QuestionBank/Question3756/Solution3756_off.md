### [连接非零数字并乘以其数字和 II](https://leetcode.cn/problems/concatenate-non-zero-digits-and-multiply-by-sum-ii/solutions/3988832/lian-jie-fei-ling-shu-zi-bing-cheng-yi-q-qyxo/)

#### 方法一：前缀数组

**思路与算法**

我们设 $pow10[i]$ 用来表示 $10$ 的 $i$ 次幂的求余后的结果。预处理数组 $pow10$，可以使得对于每个用例，不必重复计算这个过程。

参考题目 [3754\. 连接非零数字并乘以其数字和 I](https://leetcode.cn/problems/concatenate-non-zero-digits-and-multiply-by-sum-i/description/) 题解中的字符串解法，我们可以得到输入字符串任意前缀的 $x$ 和 $sum$ 的值。$ $
同时我们还要维护第三个前缀数组 $cnt$，用来表示字符串前缀中包含的非零数字的数量。

对于 $queries$ 中的每一个查询，我们利用前缀数组求差的方式，可以得到任意范围内的 $x$ 和 $sum$ 的值。

最后返回结果的数组即可。

**代码**

```C++
const int MOD = 1e9 + 7;
const int MAX_N = 100001;
long long pow10[MAX_N];

// init 对于所有测试用例只运行一次
int init = []() {
    pow10[0] = 1;
    for (int i = 1; i < MAX_N; ++i) {
        pow10[i] = (pow10[i - 1] * 10) % MOD;
    }
    return 0;
}();

class Solution {
public:
    vector<int> sumAndMultiply(string s, vector<vector<int>>& queries) {
        int n = s.size();
        vector<int> sum(n + 1, 0);
        vector<long long> x(n + 1, 0);
        vector<int> cnt(n + 1, 0);
        for (int i = 0; i < n; ++i) {
            int d = s[i] - '0';
            sum[i + 1] = sum[i] + d;
            x[i + 1] = (d > 0) ? (x[i] * 10 + d) % MOD : x[i];
            cnt[i + 1] = cnt[i] + (d > 0);
        }
        int m = queries.size();
        vector<int> res(m, 0);
        for (int i = 0; i < m; ++i) {
            int l = queries[i][0];
            int r = queries[i][1] + 1;
            int length = cnt[r] - cnt[l];
            long long val_x = (x[r] - x[l] * pow10[length] % MOD + MOD) % MOD;
            long long val_sum = sum[r] - sum[l];
            res[i] = (val_x * val_sum) % MOD;
        }
        return res;
    }
};
```

```Java
class Solution {
    private static final int MOD = 1000000007;
    private static final int MAX_N = 100001;
    private static final long[] pow10 = new long[MAX_N];

    // static 对于所有测试用例只运行一次
    static {
        pow10[0] = 1;
        for (int i = 1; i < MAX_N; ++i) {
            pow10[i] = (pow10[i - 1] * 10) % MOD;
        }
    }

    public int[] sumAndMultiply(String s, int[][] queries) {
        int n = s.length();
        int[] sum = new int[n + 1];
        long[] x = new long[n + 1];
        int[] cnt = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            int d = s.charAt(i) - '0';
            sum[i + 1] = sum[i] + d;
            x[i + 1] = (d > 0) ? (x[i] * 10 + d) % MOD : x[i];
            cnt[i + 1] = cnt[i] + (d > 0 ? 1 : 0);
        }
        int m = queries.length;
        int[] res = new int[m];
        for (int i = 0; i < m; ++i) {
            int l = queries[i][0];
            int r = queries[i][1] + 1;
            int length = cnt[r] - cnt[l];
            long val_x = (x[r] - x[l] * pow10[length] % MOD + MOD) % MOD;
            long val_sum = sum[r] - sum[l];
            res[i] = (int)((val_x * val_sum) % MOD);
        }
        return res;
    }
}

```

```Python
MOD = 10 ** 9 + 7
pow10 = [1] * 100001
for i in range(1, 100001):
    pow10[i] = pow10[i - 1] * 10 % MOD

class Solution:
    def sumAndMultiply(self, s: str, queries: List[List[int]]) -> List[int]:
        n = len(s)
        sum = [0] * (n + 1)
        x = [0] * (n + 1)
        cnt = [0] * (n + 1)
        for i, c in enumerate(s):
            d = int(c)
            sum[i + 1] = sum[i] + d
            x[i + 1] = (x[i] * 10 + d) % MOD if d > 0 else x[i]
            cnt[i + 1] = cnt[i] + (d > 0)

        m = len(queries)
        res = [0] * m
        for i in range(m):
            l = queries[i][0]
            r = queries[i][1] + 1
            length = cnt[r] - cnt[l]
            res[i] = (x[r] - x[l] * pow10[length]) * (sum[r] - sum[l] ) % MOD

        return res
```

```JavaScript
const MOD = 1000000007;
const MAX_N = 100001;
const pow10 = new Array(MAX_N);

pow10[0] = 1n;
for (let i = 1; i < MAX_N; ++i) {
    pow10[i] = (pow10[i - 1] * 10n) % BigInt(MOD);
}

var sumAndMultiply = function(s, queries) {
    const n = s.length;
    const sum = new Array(n + 1).fill(0);
    const x = new Array(n + 1).fill(0n);
    const cnt = new Array(n + 1).fill(0);
    for (let i = 0; i < n; ++i) {
        const d = s.charCodeAt(i) - 48;
        sum[i + 1] = sum[i] + d;
        x[i + 1] = d > 0 ? (x[i] * 10n + BigInt(d)) % BigInt(MOD) : x[i];
        cnt[i + 1] = cnt[i] + (d > 0 ? 1 : 0);
    }
    const m = queries.length;
    const res = new Array(m);
    for (let i = 0; i < m; ++i) {
        const l = queries[i][0];
        const r = queries[i][1] + 1;
        const length = cnt[r] - cnt[l];
        const val_x = (x[r] - x[l] * pow10[length] % BigInt(MOD) + BigInt(MOD)) % BigInt(MOD);
        const val_sum = BigInt(sum[r] - sum[l]);
        res[i] = Number((val_x * val_sum) % BigInt(MOD));
    }
    return res;
};
```

```TypeScript
const MOD = 1000000007;
const MAX_N = 100001;
const pow10: bigint[] = new Array(MAX_N);

pow10[0] = 1n;
for (let i = 1; i < MAX_N; ++i) {
    pow10[i] = (pow10[i - 1] * 10n) % BigInt(MOD);
}

function sumAndMultiply(s: string, queries: number[][]): number[] {
    const n = s.length;
    const sum: number[] = new Array(n + 1).fill(0);
    const x: bigint[] = new Array(n + 1).fill(0n);
    const cnt: number[] = new Array(n + 1).fill(0);
    for (let i = 0; i < n; ++i) {
        const d = s.charCodeAt(i) - 48;
        sum[i + 1] = sum[i] + d;
        x[i + 1] = d > 0 ? (x[i] * 10n + BigInt(d)) % BigInt(MOD) : x[i];
        cnt[i + 1] = cnt[i] + (d > 0 ? 1 : 0);
    }
    const m = queries.length;
    const res: number[] = new Array(m);
    for (let i = 0; i < m; ++i) {
        const l = queries[i][0];
        const r = queries[i][1] + 1;
        const length = cnt[r] - cnt[l];
        const val_x = (x[r] - x[l] * pow10[length] % BigInt(MOD) + BigInt(MOD)) % BigInt(MOD);
        const val_sum = BigInt(sum[r] - sum[l]);
        res[i] = Number((val_x * val_sum) % BigInt(MOD));
    }
    return res;
}
```

```Go
const MOD int64 = 1000000007
const MAX_N = 100001

var pow10 []int64

// init 对于所有测试用例只运行一次
func init() {
    pow10 = make([]int64, MAX_N)
    pow10[0] = 1
    for i := 1; i < MAX_N; i++ {
        pow10[i] = (pow10[i-1] * 10) % MOD
    }
}

func sumAndMultiply(s string, queries [][]int) []int {
    n := len(s)
    sum := make([]int, n+1)
    x := make([]int64, n+1)
    cnt := make([]int, n+1)
    for i := 0; i < n; i++ {
        d := int(s[i] - '0')
        sum[i+1] = sum[i] + d
        if d > 0 {
            x[i+1] = (x[i]*10 + int64(d)) % MOD
            cnt[i+1] = cnt[i] + 1
        } else {
            x[i+1] = x[i]
            cnt[i+1] = cnt[i]
        }
    }
    m := len(queries)
    res := make([]int, m)
    for i := 0; i < m; i++ {
        l := queries[i][0]
        r := queries[i][1] + 1
        length := cnt[r] - cnt[l]
        val_x := (x[r] - x[l]*pow10[length]%MOD + MOD) % MOD
        val_sum := int64(sum[r] - sum[l])
        res[i] = int((val_x * val_sum) % MOD)
    }
    return res
}

```

```CSharp
public class Solution {
    private static readonly long MOD = 1000000007;
    private static readonly int MAX_N = 100001;
    private static readonly long[] pow10 = new long[MAX_N];

    // static 对于所有测试用例只运行一次
    static Solution() {
        pow10[0] = 1;
        for (int i = 1; i < MAX_N; ++i) {
            pow10[i] = (pow10[i - 1] * 10) % MOD;
        }
    }

    public int[] SumAndMultiply(string s, int[][] queries) {
        int n = s.Length;
        int[] sum = new int[n + 1];
        long[] x = new long[n + 1];
        int[] cnt = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            int d = s[i] - '0';
            sum[i + 1] = sum[i] + d;
            x[i + 1] = (d > 0) ? (x[i] * 10 + d) % MOD : x[i];
            cnt[i + 1] = cnt[i] + (d > 0 ? 1 : 0);
        }
        int m = queries.Length;
        int[] res = new int[m];
        for (int i = 0; i < m; ++i) {
            int l = queries[i][0];
            int r = queries[i][1] + 1;
            int length = cnt[r] - cnt[l];
            long val_x = (x[r] - x[l] * pow10[length] % MOD + MOD) % MOD;
            long val_sum = sum[r] - sum[l];
            res[i] = (int)((val_x * val_sum) % MOD);
        }
        return res;
    }
}

```

```C
#define MAX_N 100005
static long long pow10[MAX_N];
static bool initialized = false;

void init_pow10() {
    if (initialized) return;
    long long MOD = 1000000007;
    pow10[0] = 1;
    for (int i = 1; i < MAX_N; ++i) {
        pow10[i] = (pow10[i - 1] * 10) % MOD;
    }
    initialized = true;
}

int* sumAndMultiply(char* s, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    init_pow10();
    int n = strlen(s);
    long long MOD = 1000000007;
    int* sum = (int*)calloc(n + 1, sizeof(int));
    long long* x = (long long*)calloc(n + 1, sizeof(long long));
    int* cnt = (int*)calloc(n + 1, sizeof(int));
    for (int i = 0; i < n; ++i) {
        int d = s[i] - '0';
        sum[i + 1] = sum[i] + d;
        x[i + 1] = (d > 0) ? (x[i] * 10 + d) % MOD : x[i];
        cnt[i + 1] = cnt[i] + (d > 0);
    }
    int m = queriesSize;
    int* res = (int*)malloc(m * sizeof(int));
    for (int i = 0; i < m; ++i) {
        int l = queries[i][0];
        int r = queries[i][1] + 1;
        int length = cnt[r] - cnt[l];
        long long val_x = (x[r] - x[l] * pow10[length] % MOD + MOD) % MOD;
        long long val_sum = sum[r] - sum[l];
        res[i] = (int)((val_x * val_sum) % MOD);
    }
    free(sum);
    free(x);
    free(cnt);
    *returnSize = m;
    return res;
}
```

```Rust
use std::sync::OnceLock;

static POW10: OnceLock<Vec<i64>> = OnceLock::new();

fn get_pow10() -> &'static Vec<i64> {
    POW10.get_or_init(|| {
        let MOD = 1_000_000_007i64;
        let mut p = vec![1i64; 100005];
        for i in 1..100005 {
            p[i] = (p[i - 1] * 10) % MOD;
        }
        p
    })
}

impl Solution {
    pub fn sum_and_multiply(s: String, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let pow10 = get_pow10();
        let n = s.len();
        let s_bytes = s.as_bytes();
        let MOD = 1_000_000_007i64;
        let mut sum = vec![0i32; n + 1];
        let mut x = vec![0i64; n + 1];
        let mut cnt = vec![0i32; n + 1];
        for i in 0..n {
            let d = (s_bytes[i] - b'0') as i32;
            sum[i + 1] = sum[i] + d;
            x[i + 1] = if d > 0 {
                (x[i] * 10 + d as i64) % MOD
            } else {
                x[i]
            };
            cnt[i + 1] = cnt[i] + if d > 0 { 1 } else { 0 };
        }
        let m = queries.len();
        let mut res = vec![0i32; m];
        for i in 0..m {
            let l = queries[i][0] as usize;
            let r = (queries[i][1] + 1) as usize;
            let length = (cnt[r] - cnt[l]) as usize;
            let val_x = (x[r] - x[l] * pow10[length] % MOD + MOD) % MOD;
            let val_sum = (sum[r] - sum[l]) as i64;
            res[i] = ((val_x * val_sum) % MOD) as i32;
        }
        res
    }
}
```

**复杂度分析**

预处理：

- 时间复杂度：$O(MAX_N)$，其中 $MAX_N$ 是数组的最大长度。
- 空间复杂度：$O(MAX_N)$，其中 $MAX_N$ 是数组的最大长度。

对于每个用例：

- 时间复杂度：$O(n+m)$，其中 $n$ 是字符串的长度，$m$ 是查询数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是字符串的长度，返回结果我们不计入空间复杂度。
