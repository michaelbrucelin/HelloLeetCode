### [分割回文串 III](https://leetcode.cn/problems/palindrome-partitioning-iii/solutions/101707/fen-ge-hui-wen-chuan-iii-by-leetcode-solution/?envType=daily-question&envId=2025-03-03)

#### 方法一：动态规划

我们用 `f[i][j]` 表示对于字符串 `S` 的前 `i` 个字符，将它分割成 `j` 个非空且不相交的回文串，最少需要修改的字符数。在进行状态转移时，我们可以枚举第 `j` 个回文串的起始位置 `i0`，那么就有如下的状态转移方程：

```python
f[i][j] = min(f[i0][j - 1] + cost(S, i0 + 1, i))
```

其中 `cost(S, l, r)` 表示将 `S` 的第 `l` 个到第 `r` 个字符组成的子串变成回文串，最少需要修改的字符数。`cost(S, l, r)` 可以通过双指针的方法求出：

- 初始时将第一个指针置于位置 `l`，第二个指针置于位置 `r`；
- 每次比较时，判断两个指针指向的字符是否相等。若相等，则这两个位置构成回文，不需要进行修改；若不相等，则为了保证回文，需要修改其中的任意一个字符；
- 在每次比较后，将第一个指针向右移动一步，第二个指针向左移动一步，如果第一个指针仍然在第二个指针的左侧，那么继续进行下一次比较。

上述的状态转移方程中有一些边界情况需要考虑，例如只有当 `i >= j` 时，`f[i][j]` 的值才有意义，这是因为 `i` 个字符最多只能被分割成 `i` 个非空且不相交的字符串，因此在状态转移时，必须要满足 `i >= j` 且 `i0 >= j - 1`。此外，当 `j = 1` 时，我们并不需要枚举 `i0`，这是因为将前 `i` 个字符分割成 `j = 1` 个非空字符串的方法是唯一的。

```C++
class Solution {
public:
    int cost(string& s, int l, int r) {
        int ret = 0;
        for (int i = l, j = r; i < j; ++i, --j) {
            if (s[i] != s[j]) {
                ++ret;
            }
        }
        return ret;
    }

    int palindromePartition(string& s, int k) {
        int n = s.size();
        vector<vector<int>> f(n + 1, vector<int>(k + 1, INT_MAX));
        f[0][0] = 0;
        for (int i = 1; i <= n; ++i) {
            for (int j = 1; j <= min(k, i); ++j) {
                if (j == 1) {
                    f[i][j] = cost(s, 0, i - 1);
                }
                else {
                    for (int i0 = j - 1; i0 < i; ++i0) {
                        f[i][j] = min(f[i][j], f[i0][j - 1] + cost(s, i0, i - 1));
                    }
                }
            }
        }
        
        return f[n][k];
    }
};
```

```Python
class Solution:
    def palindromePartition(self, s: str, k: int) -> int:
        def cost(l, r):
            ret, i, j = 0, l, r
            while i < j:
                ret += (0 if s[i] == s[j] else 1)
                i += 1
                j -= 1
            return ret
        
        n = len(s)
        f = [[10**9] * (k + 1) for _ in range(n + 1)]
        f[0][0] = 0
        for i in range(1, n + 1):
            for j in range(1, min(k, i) + 1):
                if j == 1:
                    f[i][j] = cost(0, i - 1)
                else:
                    for i0 in range(j - 1, i):
                        f[i][j] = min(f[i][j], f[i0][j - 1] + cost(i0, i - 1))
        
        return f[n][k]
```

```Java
class Solution {
    public int palindromePartition(String s, int k) {
        int n = s.length();        
        int[][] f = new int[n + 1][k + 1];
        for (int[] row : f) {
            Arrays.fill(row, 1000000000);
        }
        f[0][0] = 0;

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= Math.min(k, i); j++) {
                if (j == 1) {
                    f[i][j] = cost(0, i - 1, s);
                } else {
                    for (int i0 = j - 1; i0 < i; i0++) {
                        f[i][j] = Math.min(f[i][j], f[i0][j - 1] + cost(i0, i - 1, s));
                    }
                }
            }
        }

        return f[n][k];
    }

    private int cost(int l, int r, String s) {
        int ret = 0;
        int i = l, j = r;
        while (i < j) {
            ret += (s.charAt(i) == s.charAt(j) ? 0 : 1);
            i++;
            j--;
        }
        return ret;
    }
}
```

```CSharp
public class Solution {
    public int PalindromePartition(string s, int k) {
        int n = s.Length;
        int[,] f = new int[n + 1, k + 1];
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= k; j++) {
                f[i, j] = int.MaxValue;
            }
        }
        f[0, 0] = 0;
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= Math.Min(k, i); j++) {
                if (j == 1) {
                    f[i, j] = Cost(0, i - 1, s);
                } else {
                    for (int i0 = j - 1; i0 < i; i0++) {
                        f[i, j] = Math.Min(f[i, j], f[i0, j - 1] + Cost(i0, i - 1, s));
                    }
                }
            }
        }

        return f[n, k];
    }

    private int Cost(int l, int r, string s) {
        int ret = 0;
        int i = l, j = r;
        while (i < j) {
            ret += (s[i] == s[j] ? 0 : 1);
            i++;
            j--;
        }
        return ret;
    }
}
```

```Go
func palindromePartition(s string, k int) int {
    n := len(s)
    cost := func(l, r int) int {
        ret := 0
        i, j := l, r
        for i < j {
            if s[i] != s[j] {
                ret++
            }
            i++
            j--
        }
        return ret
    }
    f := make([][]int, n+1)
    for i := range f {
        f[i] = make([]int, k+1)
        for j := range f[i] {
            f[i][j] = math.MaxInt
        }
    }
    f[0][0] = 0
    for i := 1; i <= n; i++ {
        for j := 1; j <= min(k, i); j++ {
            if j == 1 {
                f[i][j] = cost(0, i-1)
            } else {
                for i0 := j - 1; i0 < i; i0++ {
                    f[i][j] = min(f[i][j], f[i0][j-1]+cost(i0, i-1))
                }
            }
        }
    }

    return f[n][k]
}
```

```C
int cost(int l, int r, const char *s) {
    int ret = 0;
    int i = l, j = r;
    while (i < j) {
        ret += (s[i] == s[j] ? 0 : 1);
        i++;
        j--;
    }
    return ret;
}

int palindromePartition(char* s, int k) {
    int n = strlen(s);
    int f[n + 1][k + 1];
    for (int i = 0; i <= n; i++) {
        for (int j = 0; j <= k; j++) {
            f[i][j] = INT_MAX;
        }
    }
    f[0][0] = 0;
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= (i < k ? i : k); j++) {
            if (j == 1) {
                f[i][j] = cost(0, i - 1, s);
            } else {
                for (int i0 = j - 1; i0 < i; i0++) {
                    f[i][j] = fmin(f[i][j], f[i0][j - 1] + cost(i0, i - 1, s));
                }
            }
        }
    }

    return f[n][k];
}
```

```JavaScript
var palindromePartition = function(s, k) {
    const n = s.length;
    const cost = (l, r) => {
        let ret = 0;
        let i = l, j = r;
        while (i < j) {
            ret += (s[i] === s[j] ? 0 : 1);
            i++;
            j--;
        }
        return ret;
    }
    const f = Array.from({ length: n + 1 }, () => Array(k + 1).fill(1000000000));
    f[0][0] = 0;
    for (let i = 1; i <= n; i++) {
        for (let j = 1; j <= Math.min(k, i); j++) {
            if (j === 1) {
                f[i][j] = cost(0, i - 1);
            } else {
                for (let i0 = j - 1; i0 < i; i0++) {
                    f[i][j] = Math.min(f[i][j], f[i0][j - 1] + cost(i0, i - 1));
                }
            }
        }
    }
    return f[n][k];
};
```

```TypeScript
function palindromePartition(s: string, k: number): number {
    const n = s.length;
    const cost = (l: number, r: number): number => {
        let ret = 0;
        let i = l, j = r;
        while (i < j) {
            ret += (s[i] === s[j] ? 0 : 1);
            i++;
            j--;
        }
        return ret;
    }
    const f: number[][] = Array.from({ length: n + 1 }, () => Array(k + 1).fill(1000000000));
    f[0][0] = 0;
    for (let i = 1; i <= n; i++) {
        for (let j = 1; j <= Math.min(k, i); j++) {
            if (j === 1) {
                f[i][j] = cost(0, i - 1);
            } else {
                for (let i0 = j - 1; i0 < i; i0++) {
                    f[i][j] = Math.min(f[i][j], f[i0][j - 1] + cost(i0, i - 1));
                }
            }
        }
    }

    return f[n][k];
};
```

```Rust
use std::cmp::min;

impl Solution {
    pub fn palindrome_partition(s: String, k: i32) -> i32 {
        let n = s.len();
        let cost = |l: usize, r: usize| -> i32 {
            let mut ret = 0;
            let (mut i, mut j) = (l, r);
            while i < j {
                if s.as_bytes()[i] != s.as_bytes()[j] {
                    ret += 1;
                }
                i += 1;
                j -= 1;
            }
            ret
        };

        let mut f = vec![vec![i32::MAX; k as usize + 1]; n + 1];
        f[0][0] = 0;
        for i in 1..=n {
            for j in 1..=std::cmp::min(k as usize, i) {
                if j == 1 {
                    f[i][j] = cost(0, i - 1);
                } else {
                    for i0 in (j - 1)..i {
                        f[i][j] = min(f[i][j], f[i0][j - 1] + cost(i0, i - 1));
                    }
                }
            }
        }
        f[n][k as usize]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N^3K)$，其中 $N$ 是字符串 `S` 的长度。在动态规划中，我们需要枚举 `i`，`j` 以及 `i0`，它们需要的时间分别为 $O(N)$，$O(K)$ 和 $O(N)$。我们还需要计算 `cost()` 函数来进行状态转移，单次的时间复杂度为 $O(N)$，因此总的时间复杂度为 $O(N^3K)$。在 `Python` 中，该方法可以卡着时间通过。
- 空间复杂度：$O(NK)$。

#### 方法二：动态规划 + 预处理

方法一中的时间复杂度瓶颈在于 `cost()` 函数。在调用 `cost()` 函数之前，我们枚举了 `i`，`j` 以及 `i0` ，因此它一共被调用了 $O(N^2K)$ 次。然而观察 `cost()` 函数本身的形式 `cost(S, l, r)`，不同的 `(l, r)` 的数量只有 $O(N^2)$ 种，这说明在动态规划中，我们对 `cost()` 函数进行了大量的重复调用。因此我们可以预处理出所有的 `cost(S, l, r)`，在后续调用 `cost()` 函数时，我们只需要 $O(1)$ 的时间便可以返回结果。

我们同样可以使用动态规划求出所有的 `cost(S, l, r)`。记 `cost[l][r] = cost(S, l, r)`，根据方法一中计算 `cost()` 函数的双指针方法，我们可以得到如下的状态转移方程：

```C
cost[l][r] = cost[l + 1][r - 1],       if S[l] == S[r]
cost[l][r] = cost[l + 1][r - 1] + 1,   if S[l] != S[r]
cost[l][r] = 0,                        if l >= r
```

这是一个经典的区间动态规划，时间复杂度为 $O(N^2)$。在预处理出所有的 `cost(S, l, r)` 后，下一步使用动态规划计算 `f[i][j]` 的时间复杂度就从 $O(N^3K)$ 降低至 $O(N^2K)$。

```C++
class Solution {
public:
    int palindromePartition(string& s, int k) {
        int n = s.size();
        vector<vector<int>> cost(n, vector<int>(n));
        for (int span = 2; span <= n; ++span) {
            for (int i = 0; i <= n - span; ++i) {
                int j = i + span - 1;
                cost[i][j] = cost[i + 1][j - 1] + (s[i] == s[j] ? 0 : 1);
            }
        }

        vector<vector<int>> f(n + 1, vector<int>(k + 1, INT_MAX));
        f[0][0] = 0;
        for (int i = 1; i <= n; ++i) {
            for (int j = 1; j <= min(k, i); ++j) {
                if (j == 1) {
                    f[i][j] = cost[0][i - 1];
                }
                else {
                    for (int i0 = j - 1; i0 < i; ++i0) {
                        f[i][j] = min(f[i][j], f[i0][j - 1] + cost[i0][i - 1]);
                    }
                }
            }
        }
        
        return f[n][k];
    }
};
```

```Python
class Solution:
    def palindromePartition(self, s: str, k: int) -> int:
        n = len(s)
        cost = [[0] * n for _ in range(n)]
        for span in range(2, n + 1):
            for i in range(n - span + 1):
                j = i + span - 1
                cost[i][j] = cost[i + 1][j - 1] + (0 if s[i] == s[j] else 1)

        f = [[10**9] * (k + 1) for _ in range(n + 1)]
        f[0][0] = 0
        for i in range(1, n + 1):
            for j in range(1, min(k, i) + 1):
                if j == 1:
                    f[i][j] = cost[0][i - 1]
                else:
                    for i0 in range(j - 1, i):
                        f[i][j] = min(f[i][j], f[i0][j - 1] + cost[i0][i - 1])
        
        return f[n][k]
```

```Java
class Solution {
    public int palindromePartition(String s, int k) {
        int n = s.length();
        int[][] cost = new int[n][n];
        for (int span = 2; span <= n; ++span) {
            for (int i = 0; i <= n - span; ++i) {
                int j = i + span - 1;
                cost[i][j] = cost[i + 1][j - 1] + (s.charAt(i) == s.charAt(j) ? 0 : 1);
            }
        }
        int[][] f = new int[n + 1][k + 1];
        for (int[] row : f) {
            Arrays.fill(row, Integer.MAX_VALUE);
        }
        f[0][0] = 0;
        for (int i = 1; i <= n; ++i) {
            for (int j = 1; j <= Math.min(k, i); ++j) {
                if (j == 1) {
                    f[i][j] = cost[0][i - 1];
                } else {
                    for (int i0 = j - 1; i0 < i; ++i0) {
                        f[i][j] = Math.min(f[i][j], f[i0][j - 1] + cost[i0][i - 1]);
                    }
                }
            }
        }

        return f[n][k];
    }
}
```

```CSharp
public class Solution {
    public int PalindromePartition(string s, int k) {
        int n = s.Length;
        int[,] cost = new int[n, n];
        for (int span = 2; span <= n; ++span) {
            for (int i = 0; i <= n - span; ++i) {
                int j = i + span - 1;
                cost[i, j] = cost[i + 1, j - 1] + (s[i] == s[j] ? 0 : 1);
            }
        }
        int[,] f = new int[n + 1, k + 1];
        for (int i = 0; i <= n; ++i) {
            for (int j = 0; j <= k; ++j) {
                f[i, j] = int.MaxValue;
            }
        }
        f[0, 0] = 0;
        for (int i = 1; i <= n; ++i) {
            for (int j = 1; j <= Math.Min(k, i); ++j) {
                if (j == 1) {
                    f[i, j] = cost[0, i - 1];
                } else {
                    for (int i0 = j - 1; i0 < i; ++i0) {
                        f[i, j] = Math.Min(f[i, j], f[i0, j - 1] + cost[i0, i - 1]);
                    }
                }
            }
        }
        return f[n, k];
    }
}
```

```Go
func palindromePartition(s string, k int) int {
    n := len(s)
    cost := make([][]int, n)
    for i := range cost {
        cost[i] = make([]int, n)
    }
    for span := 2; span <= n; span++ {
        for i := 0; i <= n - span; i++ {
            j := i + span - 1
            cost[i][j] = cost[i + 1][j - 1]
            if s[i] != s[j] {
                cost[i][j]++
            }
        }
    }

    f := make([][]int, n + 1)
    for i := range f {
        f[i] = make([]int, k + 1)
        for j := range f[i] {
            f[i][j] = math.MaxInt
        }
    }
    f[0][0] = 0
    for i := 1; i <= n; i++ {
        for j := 1; j <= min(k, i); j++ {
            if j == 1 {
                f[i][j] = cost[0][i - 1]
            } else {
                for i0 := j - 1; i0 < i; i0++ {
                    f[i][j] = min(f[i][j], f[i0][j - 1] + cost[i0][i - 1])
                }
            }
        }
    }

    return f[n][k]
}
```

```C
int palindromePartition(char* s, int k) {
    int n = strlen(s);
    int cost[n][n];
    memset(cost, 0, sizeof(cost));
    for (int span = 2; span <= n; ++span) {
        for (int i = 0; i <= n - span; ++i) {
            int j = i + span - 1;
            cost[i][j] = cost[i + 1][j - 1] + (s[i] == s[j] ? 0 : 1);
        }
    }
    int f[n + 1][k + 1];
    for (int i = 0; i <= n; ++i) {
        for (int j = 0; j <= k; ++j) {
            f[i][j] = n;
        }
    }
    f[0][0] = 0;
    for (int i = 1; i <= n; ++i) {
        for (int j = 1; j <= (i < k ? i : k); ++j) {
            if (j == 1) {
                f[i][j] = cost[0][i - 1];
            } else {
                for (int i0 = j - 1; i0 < i; ++i0) {
                    f[i][j] = fmin(f[i][j], f[i0][j - 1] + cost[i0][i - 1]);
                }
            }
        }
    }
    return f[n][k];
}
```

```JavaScript
var palindromePartition = function(s, k) {
    const n = s.length;
    const cost = Array.from({ length: n }, () => Array(n).fill(0));
    for (let span = 2; span <= n; ++span) {
        for (let i = 0; i <= n - span; ++i) {
            const j = i + span - 1;
            cost[i][j] = cost[i + 1][j - 1] + (s[i] === s[j] ? 0 : 1);
        }
    }
    const f = Array.from({ length: n + 1 }, () => Array(k + 1).fill(Infinity));
    f[0][0] = 0;
    for (let i = 1; i <= n; ++i) {
        for (let j = 1; j <= Math.min(k, i); ++j) {
            if (j === 1) {
                f[i][j] = cost[0][i - 1];
            } else {
                for (let i0 = j - 1; i0 < i; ++i0) {
                    f[i][j] = Math.min(f[i][j], f[i0][j - 1] + cost[i0][i - 1]);
                }
            }
        }
    }

    return f[n][k];
};
```

```TypeScript
function palindromePartition(s: string, k: number): number {
    const n = s.length;
    const cost: number[][] = Array.from({ length: n }, () => Array(n).fill(0));
    for (let span = 2; span <= n; ++span) {
        for (let i = 0; i <= n - span; ++i) {
            const j = i + span - 1;
            cost[i][j] = cost[i + 1][j - 1] + (s[i] === s[j] ? 0 : 1);
        }
    }
    const f: number[][] = Array.from({ length: n + 1 }, () => Array(k + 1).fill(Infinity));
    f[0][0] = 0;
    for (let i = 1; i <= n; ++i) {
        for (let j = 1; j <= Math.min(k, i); ++j) {
            if (j === 1) {
                f[i][j] = cost[0][i - 1];
            } else {
                for (let i0 = j - 1; i0 < i; ++i0) {
                    f[i][j] = Math.min(f[i][j], f[i0][j - 1] + cost[i0][i - 1]);
                }
            }
        }
    }

    return f[n][k];
};
```

```Rust
use std::cmp::min;

impl Solution {
    pub fn palindrome_partition(s: String, k: i32) -> i32 {
        let n = s.len();
        let mut cost = vec![vec![0; n]; n];
        for span in 2..=n {
            for i in 0..=n - span {
                let j = i + span - 1;
                cost[i][j] = cost[i + 1][j - 1] + if s.as_bytes()[i] == s.as_bytes()[j] { 0 } else { 1 };
            }
        }
        let mut f = vec![vec![i32::MAX; k as usize + 1]; n + 1];
        f[0][0] = 0;
        for i in 1..=n {
            for j in 1..=std::cmp::min(k as usize, i) {
                if j == 1 {
                    f[i][j] = cost[0][i - 1];
                } else {
                    for i0 in (j - 1)..i {
                        f[i][j] = min(f[i][j], f[i0][j - 1] + cost[i0][i - 1]);
                    }
                }
            }
        }
        f[n][k as usize]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N^2K)$，其中 $N$ 是字符串 `S` 的长度。预处理 `cost()` 函数需要的时间为 $O(N^2)$。在动态规划中，我们需要枚举 `i`，`j` 以及 `i0`，它们需要的时间分别为 $O(N)$，$O(K)$ 和 $O(N)$，整体复杂度为 $O(N^2K)$。由于 $O(N^2) < O(N^2K)$，因此算法的总时间复杂度为 $O(N^2K)$。
- 空间复杂度：$O(N^2+NK)$。存储 `cost()` 函数需要的空间为 $O(N^2)$，存储动态规划的结果 `f` 需要的空间为 $O(NK)$。
