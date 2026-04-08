### [区间乘法查询后的异或 $II](https://leetcode.cn/problems/xor-after-range-multiplication-queries-ii/solutions/3941260/qu-jian-cheng-fa-cha-xun-hou-de-yi-huo-i-wifp/)$

#### 方法一：根号分治 $+$ 差分

**思路与算法**

最朴素的做法是对每个查询，直接模拟，逐个去乘。单次查询时间复杂度就是 $O(n)$，q 次查询总计 $O(nq)$，规模约 $10^{10}$，必然超时。问题出在当 $k$ 很小时，一次查询会触及大量元素，代价很高。

注意到步长 $k$ 对复杂度的影响是截然不同的，我们可以按 $k$ 和 $\sqrt{n}$ 的大小关系，将查询分为两类，分别用最适合的方法处理：

- $k\ge \sqrt{n}$ 时，每次查询最多触及 $\dfrac{n}{k}\le \sqrt{n}$ 个元素，暴力可以接受。时间复杂度为 $O(q\sqrt{n})$。
- $k<\sqrt{n}$ 时，单次查询可以触及很多元素，暴力就扛不住了。

针对较小步长（$k<\sqrt{n}$），我们把查询按 $k$ 值分组，相同的 $k$ 可以一起处理。因为相同的 $k$ 影响到的下标构成的网格是一样的，比如 $k=3$ 时的所有查询，影响的下标都形如 $l,l+3,l+6,\dots $，它们都是按步长 $3$ 跳跃的。

这样一来，我们固定了 $k$ 之后，对于每个查询 $[l,r,v]$，我们需要把 $l,l+k,l+2k,\dots $ 上的元素都乘上 $v$，这本质上是一个区间乘法，但不是直接应用在原数组的连续区间，而是在步长为 $k$ 的子序列上。

我们构造一个差分数组 $dif$，所有值初始化为 $1$，处理查询 $[l,r,v]$ 时，找到最后一个需要处理的元素下标的下一个位置，设为 $R$（举个例子，对于查询 $[2,7,3]$ 来讲，最后一个处理的元素下标为 $5$，那么 $R$ 等于 $8$）。将 $dif[l]=dif[l]\times v$，$dif[R]=dif[R]\times v^{-1}$。其中 $v^{-1}$ 是 $v$ 在摸 $M=10^9+7$ 意义下的逆元，可以使用费马小定理求解 $v^{M-2}$ 得到。这样单次查询的处理时间复杂度是 $O(\log M)$。

最后我们从前到后遍历 $dif$ 数组，令 $dif[i]=dif[i]\times dif[i-k]$，即得到当前 $k$ 下每个位置对于所有查询的累乘量，然后将其更新到原数组中，时间复杂度为 $O(n)$。对于较小步长的查询处理，总体的时间复杂度为 $O(n\sqrt{n}+q\log M)$。

还有一个问题是 $R$ 如何计算？查询影响到的最后一个下标是 $l+\lfloor\dfrac{r-l}{k}\rfloor \times k$，因此 $R=l+\lfloor (\dfrac{r-l}{k}\rfloor +1)\times k$。$R$ 最大值是 $n+k$，为了方便编码，我们申请 $dif$ 数组大小为 $n+T$。

**代码**

```C++
class Solution {
    const int mod = 1e9 + 7;
    using ll = long long;
    int pow(ll x, ll y) {
        ll res = 1;
        for (; y; y >>= 1) {
            if (y & 1) {
                res = res * x % mod;
            }
            x = x * x % mod;
        }
        return res;
    }
public:
    int xorAfterQueries(vector<int>& nums, vector<vector<int>>& queries) {
        int n = nums.size();
        int T = sqrt(n);
        vector<vector<vector<int>>> groups(T);
        for (auto &q : queries) {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            if (k < T) {
                groups[k].push_back({l, r, v});
            } else {
                for (int i = l; i <= r; i += k) {
                    nums[i] = 1ll * nums[i] * v % mod;
                }
            }
        }

        vector<ll> dif(n + T);
        for (int k = 1; k < T; k++) {
            if (groups[k].empty()) {
                continue;
            }
            fill(dif.begin(), dif.end(), 1);
            for (auto &q : groups[k]) {
                int l = q[0], r = q[1], v = q[2];
                dif[l] = dif[l] * v % mod;
                int R = ((r - l) / k + 1) * k + l;
                dif[R] = dif[R] * pow(v, mod - 2) % mod;
            }

            for (int i = k; i < n; i++) {
                dif[i] = dif[i] * dif[i - k] % mod;
            }
            for (int i = 0; i < n; i++) {
                nums[i] = 1ll * nums[i] * dif[i] % mod;
            }
        }
        int res = 0;
        for (int i = 0; i < n; i++){
            res = res ^ nums[i];
        }
        return res;
    }
};
```

```Python
class Solution:
    def xorAfterQueries(self, nums: List[int], queries: List[List[int]]) -> int:
        mod = 10**9 + 7
        n = len(nums)
        T = int(n ** 0.5)

        groups = [[] for _ in range(T)]
        for l, r, k, v in queries:
            if k < T:
                groups[k].append((l, r, v))
            else:
                for i in range(l, r + 1, k):
                    nums[i] = nums[i] * v % mod

        dif = [1] * (n + T)
        for k in range(1, T):
            if not groups[k]:
                continue
            dif[:] = [1] * len(dif)
            for l, r, v in groups[k]:
                dif[l] = dif[l] * v % mod
                R = ((r - l) // k + 1) * k + l
                dif[R] = dif[R] * pow(v, mod - 2, mod) % mod

            for i in range(k, n):
                dif[i] = dif[i] * dif[i - k] % mod
            for i in range(n):
                nums[i] = nums[i] * dif[i] % mod

        res = 0
        for x in nums:
            res ^= x
        return res
```

```Rust
impl Solution {
    pub fn xor_after_queries(nums: Vec<i32>, queries: Vec<Vec<i32>>) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let mut nums: Vec<i64> = nums.into_iter().map(|x| x as i64).collect();
        let n = nums.len();
        let t = (n as f64).sqrt() as usize;

        let mut groups: Vec<Vec<(usize, usize, i64)>> = vec![vec![]; t];
        for q in queries {
            let l = q[0] as usize;
            let r = q[1] as usize;
            let k = q[2] as usize;
            let v = q[3] as i64;
            if k < t {
                groups[k].push((l, r, v));
            } else {
                let mut i = l;
                while i <= r {
                    nums[i] = nums[i] * v % MOD;
                    i += k;
                }
            }
        }

        let mut dif = vec![1; n + t];
        for k in 1..t {
            if groups[k].is_empty() {
                continue;
            }
            dif.fill(1);
            for &(l, r, v) in &groups[k] {
                dif[l] = dif[l] * v % MOD;
                let r_idx = ((r - l) / k + 1) * k + l;
                dif[r_idx] = dif[r_idx] * Self::pow_mod(v, MOD - 2, MOD) % MOD;
            }

            for i in k..n {
                dif[i] = dif[i] * dif[i - k] % MOD;
            }
            for i in 0..n {
                nums[i] = nums[i] * dif[i] % MOD;
            }
        }

        nums.into_iter().fold(0, |acc, x| acc ^ x as i32)
    }

    fn pow_mod(mut x: i64, mut y: i64, m: i64) -> i64 {
        let mut res = 1;
        while y > 0 {
            if y & 1 == 1 {
                res = res * x % m;
            }
            x = x * x % m;
            y >>= 1;
        }
        res
    }
}
```

```Java
class Solution {
    private static final int MOD = 1_000_000_007;

    private int pow(long x, long y) {
        long res = 1;
        while (y > 0) {
            if ((y & 1) == 1) {
                res = res * x % MOD;
            }
            x = x * x % MOD;
            y >>= 1;
        }
        return (int) res;
    }

    public int xorAfterQueries(int[] nums, int[][] queries) {
        int n = nums.length;
        int T = (int) Math.sqrt(n);
        List<List<int[]>> groups = new ArrayList<>(T);
        for (int i = 0; i < T; i++) {
            groups.add(new ArrayList<>());
        }

        for (int[] q : queries) {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            if (k < T) {
                groups.get(k).add(new int[]{l, r, v});
            } else {
                for (int i = l; i <= r; i += k) {
                    nums[i] = (int) ((long) nums[i] * v % MOD);
                }
            }
        }

        long[] dif = new long[n + T];
        for (int k = 1; k < T; k++) {
            if (groups.get(k).isEmpty()) {
                continue;
            }
            Arrays.fill(dif, 1);
            for (int[] q : groups.get(k)) {
                int l = q[0], r = q[1], v = q[2];
                dif[l] = dif[l] * v % MOD;
                int R = ((r - l) / k + 1) * k + l;
                dif[R] = dif[R] * pow(v, MOD - 2) % MOD;
            }

            for (int i = k; i < n; i++) {
                dif[i] = dif[i] * dif[i - k] % MOD;
            }
            for (int i = 0; i < n; i++) {
                nums[i] = (int) ((long) nums[i] * dif[i] % MOD);
            }
        }

        int res = 0;
        for (int x : nums) {
            res ^= x;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    private const int MOD = 1_000_000_007;

    private int Pow(long x, long y) {
        long res = 1;
        while (y > 0) {
            if ((y & 1) == 1) {
                res = res * x % MOD;
            }
            x = x * x % MOD;
            y >>= 1;
        }
        return (int) res;
    }

    public int XorAfterQueries(int[] nums, int[][] queries) {
        int n = nums.Length;
        int T = (int) Math.Sqrt(n);

        List<List<int[]>> groups = new List<List<int[]>>(T);
        for (int i = 0; i < T; i++) {
            groups.Add(new List<int[]>());
        }

        foreach (var q in queries) {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            if (k < T) {
                groups[k].Add(new int[] { l, r, v });
            } else {
                for (int i = l; i <= r; i += k) {
                    nums[i] = (int)((long)nums[i] * v % MOD);
                }
            }
        }

        long[] dif = new long[n + T];
        for (int k = 1; k < T; k++) {
            if (groups[k].Count == 0) {
                continue;
            }
            Array.Fill(dif, 1L);
            foreach (var q in groups[k]) {
                int l = q[0], r = q[1], v = q[2];
                dif[l] = dif[l] * v % MOD;
                int R = ((r - l) / k + 1) * k + l;
                dif[R] = dif[R] * Pow(v, MOD - 2) % MOD;
            }

            for (int i = k; i < n; i++) {
                dif[i] = dif[i] * dif[i - k] % MOD;
            }
            for (int i = 0; i < n; i++) {
                nums[i] = (int)((long)nums[i] * dif[i] % MOD);
            }
        }

        int res = 0;
        foreach (int x in nums) {
            res ^= x;
        }
        return res;
    }
}
```

```Go
const mod = 1_000_000_007

func pow(x, y int64) int {
    res := int64(1)
    for y > 0 {
        if y&1 == 1 {
            res = res * x % mod
        }
        x = x * x % mod
        y >>= 1
    }
    return int(res)
}

func xorAfterQueries(nums []int, queries [][]int) int {
    n := len(nums)
    T := int(math.Sqrt(float64(n)))

    groups := make([][][]int, T)
    for i := 0; i < T; i++ {
        groups[i] = make([][]int, 0)
    }

    for _, q := range queries {
        l, r, k, v := q[0], q[1], q[2], q[3]
        if k < T {
            groups[k] = append(groups[k], []int{l, r, v})
        } else {
            for i := l; i <= r; i += k {
                nums[i] = int((int64(nums[i]) * int64(v)) % mod)
            }
        }
    }

    dif := make([]int64, n+T)
    for k := 1; k < T; k++ {
        if len(groups[k]) == 0 {
            continue
        }
        for i := range dif {
            dif[i] = 1
        }
        for _, q := range groups[k] {
            l, r, v := q[0], q[1], q[2]
            dif[l] = dif[l] * int64(v) % mod
            R := ((r-l)/k + 1)*k + l
            dif[R] = dif[R] * int64(pow(int64(v), mod-2)) % mod
        }

        for i := k; i < n; i++ {
            dif[i] = dif[i] * dif[i-k] % mod
        }
        for i := 0; i < n; i++ {
            nums[i] = int((int64(nums[i]) * dif[i]) % mod)
        }
    }

    res := 0
    for _, x := range nums {
        res ^= x
    }
    return res
}
```

```C
#define MOD 1000000007

int pow_mod(long long x, long long y) {
    long long res = 1;
    while (y > 0) {
        if (y & 1) {
            res = res * x % MOD;
        }
        x = x * x % MOD;
        y >>= 1;
    }
    return (int) res;
}

int xorAfterQueries(int* nums, int numsSize, int** queries, int queriesSize, int* queriesColSize) {
    int n = numsSize;
    int T = (int) sqrt(n);
    int*** groups = (int***) malloc(T * sizeof(int**));
    int* groupCounts = (int*) calloc(T, sizeof(int));
    int* groupCapacities = (int*) calloc(T, sizeof(int));

    for (int i = 0; i < T; i++) {
        groupCapacities[i] = 10;
        groups[i] = (int**) malloc(groupCapacities[i] * sizeof(int*));
    }

    for (int idx = 0; idx < queriesSize; idx++) {
        int l = queries[idx][0], r = queries[idx][1];
        int k = queries[idx][2], v = queries[idx][3];

        if (k < T) {
            if (groupCounts[k] >= groupCapacities[k]) {
                groupCapacities[k] *= 2;
                groups[k] = (int**) realloc(groups[k], groupCapacities[k] * sizeof(int*));
            }
            int* q = (int*) malloc(3 * sizeof(int));
            q[0] = l; q[1] = r; q[2] = v;
            groups[k][groupCounts[k]++] = q;
        } else {
            for (int i = l; i <= r; i += k) {
                nums[i] = (int)((long long)nums[i] * v % MOD);
            }
        }
    }

    long long* dif = (long long*) calloc(n + T, sizeof(long long));
    for (int k = 1; k < T; k++) {
        if (groupCounts[k] == 0) {
            continue;
        }
        for (int i = 0; i < n + T; i++) {
            dif[i] = 1;
        }
        for (int g = 0; g < groupCounts[k]; g++) {
            int l = groups[k][g][0];
            int r = groups[k][g][1];
            int v = groups[k][g][2];

            dif[l] = dif[l] * v % MOD;
            int R = ((r - l) / k + 1) * k + l;
            dif[R] = dif[R] * pow_mod(v, MOD - 2) % MOD;
        }

        for (int i = k; i < n; i++) {
            dif[i] = dif[i] * dif[i - k] % MOD;
        }
        for (int i = 0; i < n; i++) {
            nums[i] = (int)((long long)nums[i] * dif[i] % MOD);
        }
    }

    int res = 0;
    for (int i = 0; i < n; i++) {
        res ^= nums[i];
    }

    for (int i = 0; i < T; i++) {
        for (int j = 0; j < groupCounts[i]; j++) {
            free(groups[i][j]);
        }
        free(groups[i]);
    }
    free(groups);
    free(groupCounts);
    free(groupCapacities);
    free(dif);

    return res;
}
```

```JavaScript
const MOD = 1_000_000_007n;

const pow = (x, y) => {
    let res = 1n;
    for (; y > 0n; y >>= 1n) {
        if (y & 1n) {
            res = res * x % MOD;
        }
        x = x * x % MOD;
    }
    return res;
}

var xorAfterQueries = function (nums, queries) {
    const n = nums.length;
    const T = Math.floor(Math.sqrt(n));
    const groups = Array.from({ length: T }, () => []);

    for (const [l, r, k, v] of queries) {
        if (k < T) {
            groups[k].push([l, r, BigInt(v)]);
        } else {
            for (let i = l; i <= r; i += k) {
                nums[i] = Number(BigInt(nums[i]) * BigInt(v) % MOD);
            }
        }
    }

    const dif = new BigInt64Array(n + T);
    for (let k = 1; k < T; k++) {
        if (groups[k].length === 0) {
            continue;
        }
        dif.fill(1n);
        for (let [l, r, v] of groups[k]) {
            dif[l] = dif[l] * BigInt(v) % MOD;
            const R = Math.floor((r - l) / k + 1) * k + l;
            dif[R] = dif[R] * pow(BigInt(v), MOD - 2n) % MOD;
        }

        for (let i = k; i < n; i++) {
            dif[i] = dif[i] * dif[i - k] % MOD;
        }
        for (let i = 0; i < n; i++) {
            nums[i] = Number(BigInt(nums[i]) * dif[i] % MOD);
        }
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        res = res ^ nums[i];
    }
    return res;
};
```

```TypeScript
const MOD = 1_000_000_007n;

const pow = (x: bigint, y: bigint) => {
    let res = 1n;
    for (; y > 0n; y >>= 1n) {
        if (y & 1n) {
            res = res * x % MOD;
        }
        x = x * x % MOD;
    }
    return res;
}

function xorAfterQueries(nums: number[], queries: number[][]): number {
    const n = nums.length;
    const T = Math.floor(Math.sqrt(n));
    const groups = Array.from<unknown, Array<[number, number, bigint]>>({ length: T }, () => []);

    for (const [l, r, k, v] of queries) {
        if (k < T) {
            groups[k].push([l, r, BigInt(v)]);
        } else {
            for (let i = l; i <= r; i += k) {
                nums[i] = Number(BigInt(nums[i]) * BigInt(v) % MOD);
            }
        }
    }

    const dif = new BigInt64Array(n + T);
    for (let k = 1; k < T; k++) {
        if (groups[k].length === 0) {
            continue;
        }
        dif.fill(1n);
        for (let [l, r, v] of groups[k]) {
            dif[l] = dif[l] * BigInt(v) % MOD;
            const R = Math.floor((r - l) / k + 1) * k + l;
            dif[R] = dif[R] * pow(BigInt(v), MOD - 2n) % MOD;
        }

        for (let i = k; i < n; i++) {
            dif[i] = dif[i] * dif[i - k] % MOD;
        }
        for (let i = 0; i < n; i++) {
            nums[i] = Number(BigInt(nums[i]) * dif[i] % MOD);
        }
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        res = res ^ nums[i];
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O((n+q)\sqrt{n}+q\log M)$。
- 空间复杂度：$O(\sqrt{n}+q)$。
