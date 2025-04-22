### [统计理想数组的数目](https://leetcode.cn/problems/count-the-number-of-ideal-arrays/solutions/3650511/tong-ji-li-xiang-shu-zu-de-shu-mu-by-lee-usvr/)

#### 方法一：组合数学

**思路与算法**

题目要求我们找出所有 $arr$ 数组，满足 $arr[i] \in [1,maxValue]$ 且 $\forall i \in (0,n),arr[i-1] \vert arr[i]$。换句话说，$\dfrac{arr[i]}{arr[i-1]}=k_i,k_i \in N,i \in (0,n)$。

我们考虑以 $x$ 结尾的 $arr$ 数组个数。不难想到有 $\prod\limits_{i=0}^{n-1}k_i=x$ 成立。反过来想，$k_i$ 即为 $x$ 的因子，问题转化为求有多少种不同的 $k_i$ 序列。我们可以先使用素数筛对 $x$ 分解质因数，再来寻找答案。

我们可以把每个 $k_i$ 看作一个空位，每个空位中可以填入若干个质因子。假设 $x$ 的某个质因子有 $p$ 个，那么这些质因子能够组成的不同 $k_i$ 序列数量是一个经典的组合问题，可以用隔板法解决。在 $n$ 个空位中可以插入 $n-1$ 个隔板，加上 $p$ 个质因子共有 $n-1+p$ 个位置，在这些位置中放入 $p$ 个质因子，方案数即为 $C(n+p-1,p)$。对于不同的质因子，互相之间没有影响，使用乘法原理计算即可。

最后，我们枚举所有 $[1,maxValue]$ 的 $x$，计算其对应的组合数，累加即为答案。

**代码**

```C++
const int MOD = 1e9 + 7, MAX_N = 1e4 + 10, MAX_P = 15; // 最多有 15 个质因子
int c[MAX_N + MAX_P][MAX_P + 1];
vector<int> ps[MAX_N]; // 质因子个数列表
int sieve[MAX_N]; // 最小质因子

class Solution {
public:
    Solution() {
        if (c[0][0]){
            return;
        }
        for (int i = 2; i < MAX_N; i++) {
            if (sieve[i] == 0) {
                for (int j = i; j < MAX_N; j += i) {
                    sieve[j] = i;
                }
            }
        }
        for (int i = 2; i < MAX_N; i++) {
            int x = i;
            while (x > 1) {
                int p = sieve[x];
                int cnt = 0;
                while (x % p == 0) {
                    x /= p;
                    cnt++;
                }
                ps[i].push_back(cnt);
            }
        }
        c[0][0] = 1;
        for (int i = 1; i < MAX_N + MAX_P; i++) {
            c[i][0] = 1;
            for (int j = 1; j <= min(i, MAX_P); j++) {
                c[i][j] = (c[i - 1][j] + c[i - 1][j - 1]) % MOD;
            }
        }
    }
    int idealArrays(int n, int maxValue) {
        long long ans = 0;
        for (int x = 1; x <= maxValue; x++) {
            long long mul = 1;
            for (int p : ps[x]) {
                mul = mul * c[n + p - 1][p] % MOD;
            }
            ans = (ans + mul) % MOD;
        }
        return ans;
    }
};
```

```C
const int MOD = 1e9 + 7;
#define MAX_N 10010
#define MAX_P 15 // 最多有 15 个质因子

int c[MAX_N + MAX_P][MAX_P + 1];
int sieve[MAX_N]; // 最小质因子
int ps[MAX_N][MAX_P], psLen[MAX_N]; // 质因子个数列表

void init() {
    if (c[0][0]) {
        return;
    }
    for (int i = 2; i < MAX_N; i++) {
        if (sieve[i] == 0) {
            for (int j = i; j < MAX_N; j += i) {
                if (sieve[j] == 0) {
                    sieve[j] = i;
                }
            }
        }
    }

    for (int i = 2; i < MAX_N; i++) {
        int x = i;
        while (x > 1) {
            int p = sieve[x];
            int cnt = 0;
            while (x % p == 0) {
                x /= p;
                cnt++;
            }
            ps[i][psLen[i]++] = cnt;
        }
    }

    c[0][0] = 1;
    for (int i = 1; i < MAX_N + MAX_P; i++) {
        c[i][0] = 1;
        for (int j = 1; j <= MAX_P && j <= i; j++) {
            c[i][j] = (c[i - 1][j] + c[i - 1][j - 1]) % MOD;
        }
    }
}

int idealArrays(int n, int maxValue) {
    init();
    long long ans = 0;
    for (int x = 1; x <= maxValue; x++) {
        long long mul = 1;
        for (int i = 0; i < psLen[x]; i++) {
            mul = mul * c[n + ps[x][i] - 1][ps[x][i]] % MOD;
        }
        ans = (ans + mul) % MOD;
    }
    return ans;
}
```

```Java
class Solution {
    static int MOD = 1000000007;
    static int MAX_N = 10010;
    static int MAX_P = 15; // 最多有 15 个质因子
    static int[][] c = new int[MAX_N + MAX_P][MAX_P + 1];
    static int[] sieve = new int[MAX_N]; // 最小质因子
    static List<Integer>[] ps = new List[MAX_N]; // 质因子个数列表

    public Solution() {
        if (c[0][0] == 1) {
            return;
        }

        for (int i = 0; i < MAX_N; i++) {
            ps[i] = new ArrayList<>();
        }

        for (int i = 2; i < MAX_N; i++) {
            if (sieve[i] == 0) {
                for (int j = i; j < MAX_N; j += i) {
                    if (sieve[j] == 0) {
                        sieve[j] = i;
                    }
                }
            }
        }

        for (int i = 2; i < MAX_N; i++) {
            int x = i;
            while (x > 1) {
                int p = sieve[x], cnt = 0;
                while (x % p == 0) {
                    x /= p;
                    cnt++;
                }
                ps[i].add(cnt);
            }
        }

        c[0][0] = 1;
        for (int i = 1; i < MAX_N + MAX_P; i++) {
            c[i][0] = 1;
            for (int j = 1; j <= Math.min(i, MAX_P); j++) {
                c[i][j] = (c[i - 1][j] + c[i - 1][j - 1]) % MOD;
            }
        }
    }

    public int idealArrays(int n, int maxValue) {
        long ans = 0;
        for (int x = 1; x <= maxValue; x++) {
            long mul = 1;
            for (int p : ps[x]) {
                mul = mul * c[n + p - 1][p] % MOD;
            }
            ans = (ans + mul) % MOD;
        }
        return (int) ans;
    }
}
```

```Python
MOD = 10**9 + 7
MAX_N = 10**4 + 10
MAX_P = 15  # 最多 15 个质因子

sieve = [0] * MAX_N  # 最小质因子

for i in range(2, MAX_N):
    if sieve[i] == 0:
        for j in range(i, MAX_N, i):
            sieve[j] = i

ps = [[] for _ in range(MAX_N)]

for i in range(2, MAX_N):
    x = i
    while x > 1:
        p = sieve[x]
        cnt = 0
        while x % p == 0:
            x //= p
            cnt += 1
        ps[i].append(cnt)

c = [[0] * (MAX_P + 1) for _ in range(MAX_N + MAX_P)]

c[0][0] = 1
for i in range(1, MAX_N + MAX_P):
    c[i][0] = 1
    for j in range(1, min(i, MAX_P) + 1):
        c[i][j] = (c[i - 1][j] + c[i - 1][j - 1]) % MOD

class Solution:
    def idealArrays(self, n: int, maxValue: int) -> int:
        ans = 0
        for x in range(1, maxValue + 1):
            mul = 1
            for p in ps[x]:
                mul = mul * c[n + p - 1][p] % MOD
            ans = (ans + mul) % MOD
        return ans

```

```CSharp
public class Solution {
    const int MOD = 1000000007;
    const int MAX_N = 10010;
    const int MAX_P = 15; // 最多有 15 个质因子
    int[,] c = new int[MAX_N + MAX_P, MAX_P + 1];
    int[] sieve = new int[MAX_N]; // 最小质因子
    List<int>[] ps = new List<int>[MAX_N]; // 质因子个数列表

    public Solution() {
        if(c[0, 0] == 1){
            return;
        }
        for (int i = 0; i < MAX_N; i++) {
            ps[i] = new List<int>();
        }
        for (int i = 2; i < MAX_N; i++) {
            if (sieve[i] == 0) {
                for (int j = i; j < MAX_N; j += i) {
                    if (sieve[j] == 0) {
                        sieve[j] = i;
                    }
                }
            }
        }

        for (int i = 2; i < MAX_N; i++) {
            int x = i;
            while (x > 1) {
                int p = sieve[x];
                int cnt = 0;
                while (x % p == 0) {
                    x /= p;
                    cnt++;
                }
                ps[i].Add(cnt);
            }
        }
        c[0, 0] = 1;
        for (int i = 1; i < MAX_N + MAX_P; i++) {
            c[i, 0] = 1;
            for (int j = 1; j <= Math.Min(i, MAX_P); j++) {
                c[i, j] = (c[i - 1, j] + c[i - 1, j - 1]) % MOD;
            }
        }
    }

    public int IdealArrays(int n, int maxValue) {
        long ans = 0;
        for (int x = 1; x <= maxValue; x++) {
            long mul = 1;
            foreach (var p in ps[x]) {
                mul = mul * c[n + p - 1, p] % MOD;
            }
            ans = (ans + mul) % MOD;
        }
        return (int)ans;
    }
}
```

```JavaScript
const MOD = 1e9 + 7;
const MAX_N = 10010;
const MAX_P = 15; // 最多有 15 个质因子
const c = Array.from({ length: MAX_N + MAX_P }, () => Array(MAX_P + 1).fill(0));
const sieve = Array(MAX_N).fill(0); // 最小质因子
const ps = Array.from({ length: MAX_N }, () => []); // 质因子个数列表

(function init() {
    for (let i = 2; i < MAX_N; i++) {
        if (sieve[i] === 0) {
            for (let j = i; j < MAX_N; j += i) {
                if (sieve[j] === 0) {
                    sieve[j] = i;
                }
            }
        }
    }

    for (let i = 2; i < MAX_N; i++) {
        let x = i;
        while (x > 1) {
            const p = sieve[x];
            let cnt = 0;
            while (x % p === 0) {
                x = Math.floor(x / p);
                cnt++;
            }
            ps[i].push(cnt);
        }
    }

    c[0][0] = 1;
    for (let i = 1; i < MAX_N + MAX_P; i++) {
        c[i][0] = 1;
        for (let j = 1; j <= Math.min(i, MAX_P); j++) {
            c[i][j] = (c[i - 1][j] + c[i - 1][j - 1]) % MOD;
        }
    }
})();

function idealArrays(n, maxValue) {
    let ans = 0n;
    for (let x = 1; x <= maxValue; x++) {
        let mul = 1n;
        for (const p of ps[x]) {
            mul = (mul * BigInt(c[n + p - 1][p])) % BigInt(MOD);
        }
        ans = (ans + mul) % BigInt(MOD);
    }
    return Number(ans);
}
```

```TypeScript
const MOD = 1e9 + 7;
const MAX_N = 10010;
const MAX_P = 15; // 最多有 15 个质因子
const c: number[][] = Array.from({ length: MAX_N + MAX_P }, () => Array(MAX_P + 1).fill(0));
const sieve: number[] = Array(MAX_N).fill(0); // 最小质因子
const ps: number[][] = Array.from({ length: MAX_N }, () => []); // 质因子个数列表

(function init() {
    for (let i = 2; i < MAX_N; i++) {
        if (sieve[i] === 0) {
            for (let j = i; j < MAX_N; j += i) {
                if (sieve[j] === 0) {
                    sieve[j] = i;
                }
            }
        }
    }

    for (let i = 2; i < MAX_N; i++) {
        let x = i;
        while (x > 1) {
            const p = sieve[x];
            let cnt = 0;
            while (x % p === 0) {
                x = Math.floor(x / p);
                cnt++;
            }
            ps[i].push(cnt);
        }
    }

    c[0][0] = 1;
    for (let i = 1; i < MAX_N + MAX_P; i++) {
        c[i][0] = 1;
        for (let j = 1; j <= Math.min(i, MAX_P); j++) {
            c[i][j] = (c[i - 1][j] + c[i - 1][j - 1]) % MOD;
        }
    }
})();

function idealArrays(n: number, maxValue: number): number {
    let ans = 0n;
    for (let x = 1; x <= maxValue; x++) {
        let mul = 1n;
        for (const p of ps[x]) {
            mul = (mul * BigInt(c[n + p - 1][p])) % BigInt(MOD);
        }
        ans = (ans + mul) % BigInt(MOD);
    }
    return Number(ans);
}
```

```Go
const MOD int = 1e9 + 7
const MAX_N = 10010
const MAX_P = 15 // 最多有 15 个质因子

var c [MAX_N + MAX_P][MAX_P + 1]int
var sieve [MAX_N]int // 最小质因子
var ps [MAX_N][]int // 质因子个数列表

func initialize() {
    if c[0][0] != 0 {
        return
    }

    for i := 2; i < MAX_N; i++ {
        if sieve[i] == 0 {
            for j := i; j < MAX_N; j += i {
                if sieve[j] == 0 {
                    sieve[j] = i
                }
            }
        }
    }

    for i := 2; i < MAX_N; i++ {
        x := i
        for x > 1 {
            p := sieve[x]
            cnt := 0
            for x%p == 0 {
                x /= p
                cnt++
            }
            ps[i] = append(ps[i], cnt)
        }
    }

    c[0][0] = 1
    for i := 1; i < MAX_N+MAX_P; i++ {
        c[i][0] = 1
        for j := 1; j <= MAX_P && j <= i; j++ {
            c[i][j] = (c[i-1][j] + c[i-1][j-1]) % MOD
        }
    }
}

func idealArrays(n int, maxValue int) int {
    initialize()
    ans := 0
    for x := 1; x <= maxValue; x++ {
        mul := 1
        for _, p := range ps[x] {
            mul = mul * c[n+p-1][p] % MOD
        }
        ans = (ans + mul) % MOD
    }
    return ans
}
```

```Rust
impl Solution {
    pub fn ideal_arrays(n: i32, max_value: i32) -> i32 {
        const MOD: i64 = 1_000_000_007;
        const MAX_N: usize = 10_000 + 10;
        const MAX_P: usize = 15; // 最多有 15 个质因子

        let mut sieve = vec![0; MAX_N]; // 最小质因子
        for i in 2..MAX_N {
            if sieve[i] == 0 {
                for j in (i..MAX_N).step_by(i) {
                    sieve[j] = i as i32;
                }
            }
        }

        let mut ps = vec![vec![]; MAX_N]; // 质因子个数列表
        for i in 2..=max_value as usize {
            let mut x = i;
            while x > 1 {
                let p = sieve[x] as usize;
                let mut cnt = 0;
                while x % p == 0 {
                    x /= p;
                    cnt += 1;
                }
                ps[i].push(cnt);
            }
        }

        let mut c = vec![vec![0; MAX_P + 1]; n as usize + MAX_P + 1];
        c[0][0] = 1;
        for i in 1..n as usize + MAX_P + 1 {
            c[i][0] = 1;
            for j in 1..=i.min(MAX_P) {
                c[i][j] = (c[i - 1][j] + c[i - 1][j - 1]) % MOD;
            }
        }

        let mut ans = 0i64;
        let n = n as usize;
        for x in 1..=max_value as usize {
            let mut mul = 1i64;
            for &p in &ps[x] {
                mul = mul * c[n + p as usize - 1][p as usize] % MOD;
            }
            ans = (ans + mul) % MOD;
        }

        ans as i32
    }
}
```

**复杂度分析**

令 $m$ 表示 $maxValue$，$n$ 表示 $arr$ 数组的长度，$ω(m)$ 表示 $m$ 的不同质因子的个数，其在数论中的平均阶数是 $\log \log m$。

- 时间复杂度：$O((n+ω(m)) \cdot ω(m)+mω(m))$。预处理中，用埃氏筛筛出最小质因子需要 $O(n \log \log n)$，分解质因数需要 $O(n \log n)$，求组合数需要 $O((n+ω(m)) \cdot ω(m))$。正式求解中，求数组数量的时间复杂度是 $O(mω(m))=O(m \log \log m)$。
- 空间复杂度：$O((n+ \log (m)) \cdot  \log (m))$。我们需要保存从 $(n+ \log (m)-1)$ 个位置中选出 $\log (m)$ 个位置的组合数和质因子的预处理结果。由于代码中开辟的是固定长度的数组，因子个数取最大值而不是平均值，所以空间复杂度因数是 $\log (m)$ 而不是 $ω(m)$。
