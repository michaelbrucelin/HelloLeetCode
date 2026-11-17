### [得到 K 个半回文串的最少修改次数](https://leetcode.cn/problems/minimum-changes-to-make-k-semi-palindromes/solutions/4055468/de-dao-k-ge-ban-hui-wen-chuan-de-zui-sha-rrtx/)

#### 方法一：预处理单段代价 + 自顶向下求解

**思路与算法**

题目要我们做两件事：先算出任意一段子串单独变成半回文串要改多少个字符，再决定在哪些位置切分，把它分成 $k$ 段使总和最小。两件事可以分开做，先算好每段的修改次数，之后只关心切点。

**先算每段的修改次数**

给定一段长度为 $m$ 的子串和它的一个真因子 $d$，把子串按下标对 $d$ 取模分成 $d$ 组。第 $o$ 组包含下标 $o, o+d, o+2d, \dots $ 上的字符（$o=0,1,\dots ,d-1$）。由于 $d$ 能整除 $m$，每组正好有 $g=\dfrac{m}{d}$ 个字符，组内第 $t$ 个字符要和倒数第 $t+1$ 个字符相同（即下标 $o+t\cdot d$ 与 $o+(g-1-t)\cdot d$ 的字符相同），不同就要改一次。

把 $d$ 组的修改次数加起来，就是选这个 $d$ 的代价。把 $m$ 的每个真因子都试一遍取最小值，就是这段子串的修改次数，记为 $cost[l][r]$，l 和 $r$ 是这段的首尾下标。

每组有多少个字符只跟段长 $m$ 有关，而段长最多是 $n$。所以可以先把 $1$ 到 $n$ 每个数的真因子都算出来存进 $factors$ 表，后面直接查表，不用每次重新找：枚举 $d$，把它依次加到 $2d,3d,\dots $ 的表项里。这一步用 $O(n\log n)$ 的时间。

**再决定怎么切**

设 $best(seg,start)$ 表示把 $s[start]$ 到 $s[n-1]$ 这部分切成 $seg$ 段所需的最少修改次数。

- 如果 $seg=1$，不用切，答案就是 $cost[start][n-1]$；
- 否则枚举第一段的结尾 $e$，第一段是 $s[start]$ 到 $s[e]$，剩下的 $s[e+1]$ 到 $s[n-1]$ 还要切成 $seg-1$ 段。

$$best(seg,start)=\mathop{min}\limits_{e=start+1}^{n-1-2(seg-1)}(cost[start][e]+best(seg-1,e+1))$$

e 从 $start+1$ 开始，因为每段长度至少要 $2$；e 最大到 $n-1-2(seg-1)$，因为第一段之后剩下的字符还要分给 $seg-1$ 段，每段至少 $2$ 个。

最终答案是 $best(k,0)$。同一个 $(seg,start)$ 可能被算很多次，用 $memo$ 记下来，算过就直接返回。

**代码**

```C++
class Solution {
    int segmentCost(const string &s, int l, int m, const vector<vector<int>> &factors) {
        int best = m;
        for (int d : factors[m]) {
            int groups = m / d; // 每组有 groups 个字符
            int changes = 0;
            for (int offset = 0; offset < d; offset++) {
                for (int t = 0; t < groups / 2; t++) { // 组内首尾配对
                    if (s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]) {
                        changes++;
                    }
                }
            }
            best = min(best, changes);
        }
        return best;
    }

    int solve(int seg, int start, int n, const vector<vector<int>> &cost, vector<vector<int>> &memo) {
        if (seg == 1) { // 只剩一段
            return cost[start][n - 1];
        }
        if (memo[seg][start] != -1) { // 之前算过
            return memo[seg][start];
        }
        int best = n;
        int limit = n - 1 - 2 * (seg - 1); // 第一段之后还要留出 seg-1 段
        for (int e = start + 1; e <= limit; e++) {
            best = min(best, cost[start][e] + solve(seg - 1, e + 1, n, cost, memo));
        }
        memo[seg][start] = best;
        return best;
    }

public:
    int minimumChanges(string s, int k) {
        int n = s.length();
        vector<vector<int>> factors(n + 1);
        // 预处理每个数的真因子
        for (int d = 1; d <= n / 2; d++) {
            for (int m = d * 2; m <= n; m += d) {
                factors[m].push_back(d);
            }
        }
        vector cost(n, vector<int>(n, 0));
        for (int l = 0; l + 1 < n; l++) {
            for (int r = l + 1; r < n; r++) { // 子串长度至少为 2
                cost[l][r] = segmentCost(s, l, r - l + 1, factors);
            }
        }
        vector<vector<int>> memo(k + 1, vector<int>(n, -1));
        return solve(k, 0, n, cost, memo);
    }
};
```

```Go
func segmentCost(s string, l, m int, factors [][]int) int {
    best := m
    for _, d := range factors[m] {
        groups := m / d // 每组有 groups 个字符
        changes := 0
        for offset := 0; offset < d; offset++ {
            for t := 0; t < groups/2; t++ { // 组内首尾配对
                if s[l+offset+t*d] != s[l+offset+(groups-1-t)*d] {
                    changes++
                }
            }
        }
        best = min(best, changes)
    }
    return best
}

func minimumChanges(s string, k int) int {
    n := len(s)
    factors := make([][]int, n+1)
    // 预处理每个数的真因子
    for d := 1; d <= n/2; d++ {
        for m := d * 2; m <= n; m += d {
            factors[m] = append(factors[m], d)
        }
    }
    cost := make([][]int, n)
    for l := range cost {
        cost[l] = make([]int, n)
    }
    for l := 0; l+1 < n; l++ {
        for r := l + 1; r < n; r++ { // 子串长度至少为 2
            cost[l][r] = segmentCost(s, l, r-l+1, factors)
        }
    }

    memo := make([][]int, k+1)
    for seg := range memo {
        memo[seg] = make([]int, n)
        for start := range memo[seg] {
            memo[seg][start] = -1
        }
    }
    var solve func(seg, start int) int
    solve = func(seg, start int) int {
        if seg == 1 { // 只剩一段
            return cost[start][n-1]
        }
        if memo[seg][start] != -1 { // 之前算过
            return memo[seg][start]
        }
        best := n
        limit := n - 1 - 2*(seg-1) // 第一段之后还要留出 seg-1 段
        for e := start + 1; e <= limit; e++ {
            best = min(best, cost[start][e]+solve(seg-1, e+1))
        }
        memo[seg][start] = best
        return best
    }
    return solve(k, 0)
}
```

```Python
def segmentCost(s: str, l: int, m: int, factors: list) -> int:
    best = m
    for d in factors[m]:
        groups = m // d  # 每组有 groups 个字符
        changes = 0
        for offset in range(d):
            for t in range(groups // 2):  # 组内首尾配对
                if s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]:
                    changes += 1
        best = min(best, changes)
    return best

class Solution:
    def minimumChanges(self, s: str, k: int) -> int:
        n = len(s)
        factors = [[] for _ in range(n + 1)]
        # 预处理每个数的真因子
        for d in range(1, n // 2 + 1):
            for m in range(d * 2, n + 1, d):
                factors[m].append(d)
        cost = [[0] * n for _ in range(n)]
        for l in range(n - 1):
            for r in range(l + 1, n):  # 子串长度至少为 2
                cost[l][r] = segmentCost(s, l, r - l + 1, factors)

        @cache
        def solve(seg: int, start: int) -> int:
            if seg == 1:  # 只剩一段
                return cost[start][n - 1]
            limit = n - 1 - 2 * (seg - 1)  # 第一段之后还要留出 seg-1 段
            return min(cost[start][e] + solve(seg - 1, e + 1) for e in range(start + 1, limit + 1))

        return solve(k, 0)
```

```Java
class Solution {
    private int segmentCost(char[] s, int l, int m, List<Integer>[] factors) {
        int best = m;
        for (int d : factors[m]) {
            int groups = m / d; // 每组有 groups 个字符
            int changes = 0;
            for (int offset = 0; offset < d; offset++) {
                for (int t = 0; t < groups / 2; t++) { // 组内首尾配对
                    if (s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]) {
                        changes++;
                    }
                }
            }
            best = Math.min(best, changes);
        }
        return best;
    }

    private int solve(int seg, int start, int n, int[][] cost, int[][] memo) {
        if (seg == 1) { // 只剩一段
            return cost[start][n - 1];
        }
        if (memo[seg][start] != -1) { // 之前算过
            return memo[seg][start];
        }
        int best = n;
        int limit = n - 1 - 2 * (seg - 1); // 第一段之后还要留出 seg-1 段
        for (int e = start + 1; e <= limit; e++) {
            best = Math.min(best, cost[start][e] + solve(seg - 1, e + 1, n, cost, memo));
        }
        memo[seg][start] = best;
        return best;
    }

    public int minimumChanges(String s, int k) {
        int n = s.length();
        char[] ch = s.toCharArray();
        List<Integer>[] factors = new ArrayList[n + 1];
        Arrays.setAll(factors, x -> new ArrayList<>());
        // 预处理每个数的真因子
        for (int d = 1; d <= n / 2; d++) {
            for (int m = d * 2; m <= n; m += d) {
                factors[m].add(d);
            }
        }
        int[][] cost = new int[n][n];
        for (int l = 0; l + 1 < n; l++) {
            for (int r = l + 1; r < n; r++) { // 子串长度至少为 2
                cost[l][r] = segmentCost(ch, l, r - l + 1, factors);
            }
        }
        int[][] memo = new int[k + 1][n];
        for (int seg = 0; seg <= k; seg++) {
            Arrays.fill(memo[seg], -1);
        }
        return solve(k, 0, n, cost, memo);
    }
}
```

```TypeScript
function segmentCost(s: string, l: number, m: number, factors: number[][]): number {
    let best = m;
    for (const d of factors[m]) {
        const groups = Math.floor(m / d); // 每组有 groups 个字符
        let changes = 0;
        for (let offset = 0; offset < d; offset++) {
            for (let t = 0; t < Math.floor(groups / 2); t++) { // 组内首尾配对
                if (s[l + offset + t * d] !== s[l + offset + (groups - 1 - t) * d]) {
                    changes++;
                }
            }
        }
        best = Math.min(best, changes);
    }
    return best;
}

function minimumChanges(s: string, k: number): number {
    const n = s.length;
    const factors: number[][] = Array.from({ length: n + 1 }, () => []);
    // 预处理每个数的真因子
    for (let d = 1; d <= Math.floor(n / 2); d++) {
        for (let m = d * 2; m <= n; m += d) {
            factors[m].push(d);
        }
    }
    const cost: number[][] = Array.from({ length: n }, () => new Array(n).fill(0));
    for (let l = 0; l + 1 < n; l++) {
        for (let r = l + 1; r < n; r++) { // 子串长度至少为 2
            cost[l][r] = segmentCost(s, l, r - l + 1, factors);
        }
    }

    const memo: number[][] = Array.from({ length: k + 1 }, () => new Array(n).fill(-1));
    const solve = (seg: number, start: number): number => {
        if (seg === 1) { // 只剩一段
            return cost[start][n - 1];
        }
        if (memo[seg][start] !== -1) { // 之前算过
            return memo[seg][start];
        }
        let best = n;
        const limit = n - 1 - 2 * (seg - 1); // 第一段之后还要留出 seg-1 段
        for (let e = start + 1; e <= limit; e++) {
            best = Math.min(best, cost[start][e] + solve(seg - 1, e + 1));
        }
        memo[seg][start] = best;
        return best;
    };
    return solve(k, 0);
}
```

```JavaScript
function segmentCost(s, l, m, factors) {
    let best = m;
    for (const d of factors[m]) {
        const groups = Math.floor(m / d); // 每组有 groups 个字符
        let changes = 0;
        for (let offset = 0; offset < d; offset++) {
            for (let t = 0; t < Math.floor(groups / 2); t++) { // 组内首尾配对
                if (s[l + offset + t * d] !== s[l + offset + (groups - 1 - t) * d]) {
                    changes++;
                }
            }
        }
        best = Math.min(best, changes);
    }
    return best;
}

var minimumChanges = function(s, k) {
    const n = s.length;
    const factors = Array.from({ length: n + 1 }, () => []);
    // 预处理每个数的真因子
    for (let d = 1; d <= Math.floor(n / 2); d++) {
        for (let m = d * 2; m <= n; m += d) {
            factors[m].push(d);
        }
    }
    const cost = Array.from({ length: n }, () => new Array(n).fill(0));
    for (let l = 0; l + 1 < n; l++) {
        for (let r = l + 1; r < n; r++) { // 子串长度至少为 2
            cost[l][r] = segmentCost(s, l, r - l + 1, factors);
        }
    }

    const memo = Array.from({ length: k + 1 }, () => new Array(n).fill(-1));
    const solve = (seg, start) => {
        if (seg === 1) { // 只剩一段
            return cost[start][n - 1];
        }
        if (memo[seg][start] !== -1) { // 之前算过
            return memo[seg][start];
        }
        let best = n;
        const limit = n - 1 - 2 * (seg - 1); // 第一段之后还要留出 seg-1 段
        for (let e = start + 1; e <= limit; e++) {
            best = Math.min(best, cost[start][e] + solve(seg - 1, e + 1));
        }
        memo[seg][start] = best;
        return best;
    };
    return solve(k, 0);
};
```

```CSharp
public class Solution {
    private int SegmentCost(string s, int l, int m, List<int>[] factors) {
        int best = m;
        foreach (int d in factors[m]) {
            int groups = m / d; // 每组有 groups 个字符
            int changes = 0;
            for (int offset = 0; offset < d; offset++) {
                for (int t = 0; t < groups / 2; t++) { // 组内首尾配对
                    if (s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]) {
                        changes++;
                    }
                }
            }
            best = Math.Min(best, changes);
        }
        return best;
    }

    private int Solve(int seg, int start, int n, int[][] cost, int[][] memo) {
        if (seg == 1) { // 只剩一段
            return cost[start][n - 1];
        }
        if (memo[seg][start] != -1) { // 之前算过
            return memo[seg][start];
        }
        int best = n;
        int limit = n - 1 - 2 * (seg - 1); // 第一段之后还要留出 seg-1 段
        for (int e = start + 1; e <= limit; e++) {
            best = Math.Min(best, cost[start][e] + Solve(seg - 1, e + 1, n, cost, memo));
        }
        memo[seg][start] = best;
        return best;
    }

    public int MinimumChanges(string s, int k) {
        int n = s.Length;
        List<int>[] factors = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) {
            factors[i] = new List<int>();
        }
        // 预处理每个数的真因子
        for (int d = 1; d <= n / 2; d++) {
            for (int m = d * 2; m <= n; m += d) {
                factors[m].Add(d);
            }
        }
        int[][] cost = new int[n][];
        for (int i = 0; i < n; i++) {
            cost[i] = new int[n];
        }
        for (int l = 0; l + 1 < n; l++) {
            for (int r = l + 1; r < n; r++) { // 子串长度至少为 2
                cost[l][r] = SegmentCost(s, l, r - l + 1, factors);
            }
        }
        int[][] memo = new int[k + 1][];
        for (int seg = 0; seg <= k; seg++) {
            memo[seg] = new int[n];
            Array.Fill(memo[seg], -1);
        }
        return Solve(k, 0, n, cost, memo);
    }
}
```

```C
int segmentCost(const char *s, int l, int m, int **factors, int *factorCount) {
    int best = m;
    for (int idx = 0; idx < factorCount[m]; idx++) {
        int d = factors[m][idx];
        int groups = m / d; // 每组有 groups 个字符
        int changes = 0;
        for (int offset = 0; offset < d; offset++) {
            for (int t = 0; t < groups / 2; t++) { // 组内首尾配对
                if (s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]) {
                    changes++;
                }
            }
        }
        best = (int)fmin(best, changes);
    }
    return best;
}

int solve(int seg, int start, int n, int **cost, int **memo) {
    if (seg == 1) { // 只剩一段
        return cost[start][n - 1];
    }
    if (memo[seg][start] != -1) { // 之前算过
        return memo[seg][start];
    }
    int best = n;
    int limit = n - 1 - 2 * (seg - 1); // 第一段之后还要留出 seg-1 段
    for (int e = start + 1; e <= limit; e++) {
        best = (int)fmin(best, cost[start][e] + solve(seg - 1, e + 1, n, cost, memo));
    }
    memo[seg][start] = best;
    return best;
}

int minimumChanges(char *s, int k) {
    int n = strlen(s);
    int **factors = malloc((n + 1) * sizeof(int *));
    int *factorCount = calloc(n + 1, sizeof(int));
    for (int i = 0; i <= n; i++) {
        factors[i] = malloc((n + 5) * sizeof(int));
    }
    // 预处理每个数的真因子
    for (int d = 1; d <= n / 2; d++) {
        for (int m = d * 2; m <= n; m += d) {
            factors[m][factorCount[m]++] = d;
        }
    }
    int **cost = malloc(n * sizeof(int *));
    for (int l = 0; l < n; l++) {
        cost[l] = calloc(n, sizeof(int));
    }
    for (int l = 0; l + 1 < n; l++) {
        for (int r = l + 1; r < n; r++) { // 子串长度至少为 2
            cost[l][r] = segmentCost(s, l, r - l + 1, factors, factorCount);
        }
    }
    int **memo = malloc((k + 1) * sizeof(int *));
    for (int seg = 0; seg <= k; seg++) {
        memo[seg] = malloc(n * sizeof(int));
        memset(memo[seg], -1, n * sizeof(int));
    }
    int answer = solve(k, 0, n, cost, memo);
    for (int i = 0; i <= n; i++) {
        free(factors[i]);
    }
    free(factors);
    free(factorCount);
    for (int l = 0; l < n; l++) {
        free(cost[l]);
    }
    free(cost);
    for (int seg = 0; seg <= k; seg++) {
        free(memo[seg]);
    }
    free(memo);
    return answer;
}
```

```Rust
fn segment_cost(s: &[u8], l: usize, m: usize, factors: &Vec<Vec<usize>>) -> i32 {
    let mut best = m as i32;
    for &d in &factors[m] {
        let groups = m / d; // 每组有 groups 个字符
        let mut changes = 0;
        for offset in 0..d {
            for t in 0..groups / 2 {
                // 组内首尾配对
                if s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d] {
                    changes += 1;
                }
            }
        }
        best = best.min(changes);
    }
    best
}

fn solve(seg: usize, start: usize, n: usize, cost: &Vec<Vec<i32>>, memo: &mut Vec<Vec<i32>>) -> i32 {
    if seg == 1 {
        // 只剩一段
        return cost[start][n - 1];
    }
    if memo[seg][start] != -1 {
        // 之前算过
        return memo[seg][start];
    }
    let mut best = n as i32;
    let limit = n - 1 - 2 * (seg - 1); // 第一段之后还要留出 seg-1 段
    for e in (start + 1)..=limit {
        best = best.min(cost[start][e] + solve(seg - 1, e + 1, n, cost, memo));
    }
    memo[seg][start] = best;
    best
}

impl Solution {
    pub fn minimum_changes(s: String, k: i32) -> i32 {
        let s = s.as_bytes();
        let n = s.len();
        let k = k as usize;
        let mut factors = vec![vec![]; n + 1];
        // 预处理每个数的真因子
        for d in 1..=n / 2 {
            let mut m = d * 2;
            while m <= n {
                factors[m].push(d);
                m += d;
            }
        }
        let mut cost = vec![vec![0i32; n]; n];
        for l in 0..n - 1 {
            for r in (l + 1)..n {
                // 子串长度至少为 2
                cost[l][r] = segment_cost(s, l, r - l + 1, &factors);
            }
        }
        let mut memo = vec![vec![-1i32; n]; k + 1];
        solve(k, 0, n, &cost, &mut memo)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^3\log n)$，其中 $n$ 为字符串 $s$ 的长度。求因子表用 $O(n\log n)$。主要时间花在 $cost$ 表上：$O(n^2)$ 个子串，每个子串平均有 $O(\log n)$ 个真因子，每试一个因子要把整段扫一遍，需要 $O(n)$，合计 $O(n^3\log n)$。搜索部分有 $O(kn)$ 个状态，每个状态枚举 $O(n)$ 个切点，共 $O(kn^2)$，不超过前面的 $O(n^3)$。
- 空间复杂度：$O(n^2)$，其中 $n$ 为字符串 $s$ 的长度。$cost$ 表用 $O(n^2)$，memo 表用 $O(kn)$。

#### 方法二：自底向上递推

**思路与算法**

方法一里 $best(seg,start)$ 依赖段数更少的 $best(seg-1,\cdot )$，所以可以按段数从小到大算：先写出 $seg=1$ 的所有答案，再依次算出 $seg=2,3,\dots ,k$。

用 $prev[start]$ 存 $seg-1$ 段的结果，$cur[start]$ 存 $seg$ 段的结果：

$$cur[start]=\mathop{min}\limits_{e=start+1}^{n-1-2(seg-1)}(cost[start][e]+prev[e+1])$$

start 只要枚举到 $n-2seg$，因为从 $start$ 到末尾剩下的字符不足 $2seg$ 个时，切不出 $seg$ 段长度都不小于 $2$ 的子串。这一层的 $cur$ 算完后，把 $cur$ 当作下一层的 $prev$ 继续算。$cost$ 表的算法和方法一完全一样，只是这里不需要二维记忆表。

**代码**

```C++
class Solution {
    int segmentCost(const string &s, int l, int m, const vector<vector<int>> &factors) {
        int best = m;
        for (int d : factors[m]) {
            int groups = m / d; // 每组有 groups 个字符
            int changes = 0;
            for (int offset = 0; offset < d; offset++) {
                for (int t = 0; t < groups / 2; t++) { // 组内首尾配对
                    if (s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]) {
                        changes++;
                    }
                }
            }
            best = min(best, changes);
        }
        return best;
    }

public:
    int minimumChanges(string s, int k) {
        int n = s.length();
        vector<vector<int>> factors(n + 1);
        // 预处理每个数的真因子
        for (int d = 1; d <= n / 2; d++) {
            for (int m = d * 2; m <= n; m += d) {
                factors[m].push_back(d);
            }
        }
        vector cost(n, vector<int>(n, 0));
        for (int l = 0; l + 1 < n; l++) {
            for (int r = l + 1; r < n; r++) { // 子串长度至少为 2
                cost[l][r] = segmentCost(s, l, r - l + 1, factors);
            }
        }
        vector<int> prev(n);
        for (int start = 0; start < n; start++) { // seg = 1 的情况
            prev[start] = cost[start][n - 1];
        }
        for (int seg = 2; seg <= k; seg++) { // 段数从 2 推到 k
            vector<int> cur(n, n);
            int limit = n - 1 - 2 * (seg - 1);
            for (int start = 0; start + 2 * seg <= n; start++) { // 至少留够 2*seg 个字符
                for (int e = start + 1; e <= limit; e++) {
                    cur[start] = min(cur[start], cost[start][e] + prev[e + 1]);
                }
            }
            prev.swap(cur);
        }
        return prev[0];
    }
};
```

```Go
func segmentCost(s string, l, m int, factors [][]int) int {
    best := m
    for _, d := range factors[m] {
        groups := m / d // 每组有 groups 个字符
        changes := 0
        for offset := 0; offset < d; offset++ {
            for t := 0; t < groups/2; t++ { // 组内首尾配对
                if s[l+offset+t*d] != s[l+offset+(groups-1-t)*d] {
                    changes++
                }
            }
        }
        best = min(best, changes)
    }
    return best
}

func minimumChanges(s string, k int) int {
    n := len(s)
    factors := make([][]int, n+1)
    // 预处理每个数的真因子
    for d := 1; d <= n/2; d++ {
        for m := d * 2; m <= n; m += d {
            factors[m] = append(factors[m], d)
        }
    }
    cost := make([][]int, n)
    for l := range cost {
        cost[l] = make([]int, n)
    }
    for l := 0; l+1 < n; l++ {
        for r := l + 1; r < n; r++ { // 子串长度至少为 2
            cost[l][r] = segmentCost(s, l, r-l+1, factors)
        }
    }

    prev := make([]int, n)
    for start := 0; start < n; start++ { // seg = 1 的情况
        prev[start] = cost[start][n-1]
    }
    for seg := 2; seg <= k; seg++ { // 段数从 2 推到 k
        cur := make([]int, n)
        for i := range cur {
            cur[i] = n
        }
        limit := n - 1 - 2*(seg-1)
        for start := 0; start+2*seg <= n; start++ { // 至少留够 2*seg 个字符
            for e := start + 1; e <= limit; e++ {
                cur[start] = min(cur[start], cost[start][e]+prev[e+1])
            }
        }
        prev = cur
    }
    return prev[0]
}
```

```Python
def segmentCost(s: str, l: int, m: int, factors: list) -> int:
    best = m
    for d in factors[m]:
        groups = m // d  # 每组有 groups 个字符
        changes = 0
        for offset in range(d):
            for t in range(groups // 2):  # 组内首尾配对
                if s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]:
                    changes += 1
        best = min(best, changes)
    return best

class Solution:
    def minimumChanges(self, s: str, k: int) -> int:
        n = len(s)
        factors = [[] for _ in range(n + 1)]
        # 预处理每个数的真因子
        for d in range(1, n // 2 + 1):
            for m in range(d * 2, n + 1, d):
                factors[m].append(d)
        cost = [[0] * n for _ in range(n)]
        for l in range(n - 1):
            for r in range(l + 1, n):  # 子串长度至少为 2
                cost[l][r] = segmentCost(s, l, r - l + 1, factors)

        prev = [cost[start][n - 1] for start in range(n)]  # seg = 1 的情况
        for seg in range(2, k + 1):  # 段数从 2 推到 k
            cur = [n] * n
            limit = n - 1 - 2 * (seg - 1)
            for start in range(n - 2 * seg + 1):  # 至少留够 2*seg 个字符
                cur[start] = min(cost[start][e] + prev[e + 1] for e in range(start + 1, limit + 1))
            prev = cur
        return prev[0]
```

```Java
class Solution {
    private int segmentCost(char[] s, int l, int m, List<Integer>[] factors) {
        int best = m;
        for (int d : factors[m]) {
            int groups = m / d; // 每组有 groups 个字符
            int changes = 0;
            for (int offset = 0; offset < d; offset++) {
                for (int t = 0; t < groups / 2; t++) { // 组内首尾配对
                    if (s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]) {
                        changes++;
                    }
                }
            }
            best = Math.min(best, changes);
        }
        return best;
    }

    public int minimumChanges(String s, int k) {
        int n = s.length();
        char[] ch = s.toCharArray();
        List<Integer>[] factors = new ArrayList[n + 1];
        Arrays.setAll(factors, x -> new ArrayList<>());
        // 预处理每个数的真因子
        for (int d = 1; d <= n / 2; d++) {
            for (int m = d * 2; m <= n; m += d) {
                factors[m].add(d);
            }
        }
        int[][] cost = new int[n][n];
        for (int l = 0; l + 1 < n; l++) {
            for (int r = l + 1; r < n; r++) { // 子串长度至少为 2
                cost[l][r] = segmentCost(ch, l, r - l + 1, factors);
            }
        }
        int[] prev = new int[n];
        for (int start = 0; start < n; start++) { // seg = 1 的情况
            prev[start] = cost[start][n - 1];
        }
        for (int seg = 2; seg <= k; seg++) { // 段数从 2 推到 k
            int[] cur = new int[n];
            Arrays.fill(cur, n);
            int limit = n - 1 - 2 * (seg - 1);
            for (int start = 0; start + 2 * seg <= n; start++) { // 至少留够 2*seg 个字符
                for (int e = start + 1; e <= limit; e++) {
                    cur[start] = Math.min(cur[start], cost[start][e] + prev[e + 1]);
                }
            }
            prev = cur;
        }
        return prev[0];
    }
}
```

```TypeScript
function segmentCost(s: string, l: number, m: number, factors: number[][]): number {
    let best = m;
    for (const d of factors[m]) {
        const groups = Math.floor(m / d); // 每组有 groups 个字符
        let changes = 0;
        for (let offset = 0; offset < d; offset++) {
            for (let t = 0; t < Math.floor(groups / 2); t++) { // 组内首尾配对
                if (s[l + offset + t * d] !== s[l + offset + (groups - 1 - t) * d]) {
                    changes++;
                }
            }
        }
        best = Math.min(best, changes);
    }
    return best;
}

function minimumChanges(s: string, k: number): number {
    const n = s.length;
    const factors: number[][] = Array.from({ length: n + 1 }, () => []);
    // 预处理每个数的真因子
    for (let d = 1; d <= Math.floor(n / 2); d++) {
        for (let m = d * 2; m <= n; m += d) {
            factors[m].push(d);
        }
    }
    const cost: number[][] = Array.from({ length: n }, () => new Array(n).fill(0));
    for (let l = 0; l + 1 < n; l++) {
        for (let r = l + 1; r < n; r++) { // 子串长度至少为 2
            cost[l][r] = segmentCost(s, l, r - l + 1, factors);
        }
    }

    let prev: number[] = Array.from({ length: n }, (_, start) => cost[start][n - 1]); // seg = 1 的情况
    for (let seg = 2; seg <= k; seg++) { // 段数从 2 推到 k
        const cur: number[] = new Array(n).fill(n);
        const limit = n - 1 - 2 * (seg - 1);
        for (let start = 0; start + 2 * seg <= n; start++) { // 至少留够 2*seg 个字符
            for (let e = start + 1; e <= limit; e++) {
                cur[start] = Math.min(cur[start], cost[start][e] + prev[e + 1]);
            }
        }
        prev = cur;
    }
    return prev[0];
}
```

```JavaScript
function segmentCost(s, l, m, factors) {
    let best = m;
    for (const d of factors[m]) {
        const groups = Math.floor(m / d); // 每组有 groups 个字符
        let changes = 0;
        for (let offset = 0; offset < d; offset++) {
            for (let t = 0; t < Math.floor(groups / 2); t++) { // 组内首尾配对
                if (s[l + offset + t * d] !== s[l + offset + (groups - 1 - t) * d]) {
                    changes++;
                }
            }
        }
        best = Math.min(best, changes);
    }
    return best;
}

var minimumChanges = function(s, k) {
    const n = s.length;
    const factors = Array.from({ length: n + 1 }, () => []);
    // 预处理每个数的真因子
    for (let d = 1; d <= Math.floor(n / 2); d++) {
        for (let m = d * 2; m <= n; m += d) {
            factors[m].push(d);
        }
    }
    const cost = Array.from({ length: n }, () => new Array(n).fill(0));
    for (let l = 0; l + 1 < n; l++) {
        for (let r = l + 1; r < n; r++) { // 子串长度至少为 2
            cost[l][r] = segmentCost(s, l, r - l + 1, factors);
        }
    }

    let prev = Array.from({ length: n }, (_, start) => cost[start][n - 1]); // seg = 1 的情况
    for (let seg = 2; seg <= k; seg++) { // 段数从 2 推到 k
        const cur = new Array(n).fill(n);
        const limit = n - 1 - 2 * (seg - 1);
        for (let start = 0; start + 2 * seg <= n; start++) { // 至少留够 2*seg 个字符
            for (let e = start + 1; e <= limit; e++) {
                cur[start] = Math.min(cur[start], cost[start][e] + prev[e + 1]);
            }
        }
        prev = cur;
    }
    return prev[0];
};
```

```CSharp
public class Solution {
    private int SegmentCost(string s, int l, int m, List<int>[] factors) {
        int best = m;
        foreach (int d in factors[m]) {
            int groups = m / d; // 每组有 groups 个字符
            int changes = 0;
            for (int offset = 0; offset < d; offset++) {
                for (int t = 0; t < groups / 2; t++) { // 组内首尾配对
                    if (s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]) {
                        changes++;
                    }
                }
            }
            best = Math.Min(best, changes);
        }
        return best;
    }

    public int MinimumChanges(string s, int k) {
        int n = s.Length;
        List<int>[] factors = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) {
            factors[i] = new List<int>();
        }
        // 预处理每个数的真因子
        for (int d = 1; d <= n / 2; d++) {
            for (int m = d * 2; m <= n; m += d) {
                factors[m].Add(d);
            }
        }
        int[][] cost = new int[n][];
        for (int i = 0; i < n; i++) {
            cost[i] = new int[n];
        }
        for (int l = 0; l + 1 < n; l++) {
            for (int r = l + 1; r < n; r++) { // 子串长度至少为 2
                cost[l][r] = SegmentCost(s, l, r - l + 1, factors);
            }
        }
        int[] prev = new int[n];
        for (int start = 0; start < n; start++) { // seg = 1 的情况
            prev[start] = cost[start][n - 1];
        }
        for (int seg = 2; seg <= k; seg++) { // 段数从 2 推到 k
            int[] cur = new int[n];
            Array.Fill(cur, n);
            int limit = n - 1 - 2 * (seg - 1);
            for (int start = 0; start + 2 * seg <= n; start++) { // 至少留够 2*seg 个字符
                for (int e = start + 1; e <= limit; e++) {
                    cur[start] = Math.Min(cur[start], cost[start][e] + prev[e + 1]);
                }
            }
            prev = cur;
        }
        return prev[0];
    }
}
```

```C
int segmentCost(const char *s, int l, int m, int **factors, int *factorCount) {
    int best = m;
    for (int idx = 0; idx < factorCount[m]; idx++) {
        int d = factors[m][idx];
        int groups = m / d; // 每组有 groups 个字符
        int changes = 0;
        for (int offset = 0; offset < d; offset++) {
            for (int t = 0; t < groups / 2; t++) { // 组内首尾配对
                if (s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d]) {
                    changes++;
                }
            }
        }
        best = (int)fmin(best, changes);
    }
    return best;
}

int minimumChanges(char *s, int k) {
    int n = strlen(s);
    int **factors = malloc((n + 1) * sizeof(int *));
    int *factorCount = calloc(n + 1, sizeof(int));
    for (int i = 0; i <= n; i++) {
        factors[i] = malloc((n + 5) * sizeof(int));
    }
    // 预处理每个数的真因子
    for (int d = 1; d <= n / 2; d++) {
        for (int m = d * 2; m <= n; m += d) {
            factors[m][factorCount[m]++] = d;
        }
    }
    int **cost = malloc(n * sizeof(int *));
    for (int l = 0; l < n; l++) {
        cost[l] = calloc(n, sizeof(int));
    }
    for (int l = 0; l + 1 < n; l++) {
        for (int r = l + 1; r < n; r++) { // 子串长度至少为 2
            cost[l][r] = segmentCost(s, l, r - l + 1, factors, factorCount);
        }
    }
    int *prev = malloc(n * sizeof(int));
    int *cur = malloc(n * sizeof(int));
    for (int start = 0; start < n; start++) { // seg = 1 的情况
        prev[start] = cost[start][n - 1];
    }
    for (int seg = 2; seg <= k; seg++) { // 段数从 2 推到 k
        for (int start = 0; start < n; start++) {
            cur[start] = n;
        }
        int limit = n - 1 - 2 * (seg - 1);
        for (int start = 0; start + 2 * seg <= n; start++) { // 至少留够 2*seg 个字符
            for (int e = start + 1; e <= limit; e++) {
                cur[start] = (int)fmin(cur[start], cost[start][e] + prev[e + 1]);
            }
        }
        int *tmp = prev;
        prev = cur;
        cur = tmp;
    }
    int answer = prev[0];
    for (int i = 0; i <= n; i++) {
        free(factors[i]);
    }
    free(factors);
    free(factorCount);
    for (int l = 0; l < n; l++) {
        free(cost[l]);
    }
    free(cost);
    free(prev);
    free(cur);
    return answer;
}
```

```Rust
fn segment_cost(s: &[u8], l: usize, m: usize, factors: &Vec<Vec<usize>>) -> i32 {
    let mut best = m as i32;
    for &d in &factors[m] {
        let groups = m / d; // 每组有 groups 个字符
        let mut changes = 0;
        for offset in 0..d {
            for t in 0..groups / 2 {
                // 组内首尾配对
                if s[l + offset + t * d] != s[l + offset + (groups - 1 - t) * d] {
                    changes += 1;
                }
            }
        }
        best = best.min(changes);
    }
    best
}

impl Solution {
    pub fn minimum_changes(s: String, k: i32) -> i32 {
        let s = s.as_bytes();
        let n = s.len();
        let k = k as usize;
        let mut factors = vec![vec![]; n + 1];
        // 预处理每个数的真因子
        for d in 1..=n / 2 {
            let mut m = d * 2;
            while m <= n {
                factors[m].push(d);
                m += d;
            }
        }
        let mut cost = vec![vec![0i32; n]; n];
        for l in 0..n - 1 {
            for r in (l + 1)..n {
                // 子串长度至少为 2
                cost[l][r] = segment_cost(s, l, r - l + 1, &factors);
            }
        }
        let mut prev: Vec<i32> = (0..n).map(|start| cost[start][n - 1]).collect(); // seg = 1 的情况
        for seg in 2..=k {
            // 段数从 2 推到 k
            let mut cur = vec![n as i32; n];
            let limit = n - 1 - 2 * (seg - 1);
            for start in 0..=(n - 2 * seg) {
                // 至少留够 2*seg 个字符
                let mut e = start + 1;
                while e <= limit {
                    cur[start] = cur[start].min(cost[start][e] + prev[e + 1]);
                    e += 1;
                }
            }
            prev = cur;
        }
        prev[0]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^3\log n)$，其中 $n$ 为字符串 $s$ 的长度。求因子表用 $O(n\log n)$；cost 表占主要开销：$O(n^2)$ 个子串，每个子串平均有 $O(\log n)$ 个真因子，每试一个因子要把整段扫一遍，需要 $O(n)$，合计 $O(n^3\log n)$。递推部分有 $O(k)$ 层，每层 $O(n^2)$，共 $O(kn^2)$，不超过前面的 $O(n^3)$。
- 空间复杂度：$O(n^2)$，其中 $n$ 为字符串 $s$ 的长度。主要是 $cost$ 表；递推只用了两个长度为 $n$ 的数组，额外空间 $O(n)$。
