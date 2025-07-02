### [找到初始输入字符串 II](https://leetcode.cn/problems/find-the-original-typed-string-ii/solutions/3706277/zhao-dao-chu-shi-shu-ru-zi-fu-chuan-ii-b-ldyv/)

#### 方法一：动态规划 + 前缀和优化

**思路与算法**

要想求出长度至少为 $k$ 的结果，我们可以首先求出任意长度的结果，再减去长度为 $1,2,\dots,k-1$ 的结果。

对于任意长度的结果，我们可以使用乘法原理计算得出：如果一个字符在字符串 $word$ 中连续出现了 $p$ 次，那么 $Alice$ 实际上想输入它的次数为 $1,2,\dots,p$，那么就有 $p$ 种可能。将所有的 $p$ 相乘即可得到任意长度的结果。

> 例如字符串 $word$ 为 $abbcccaa$，那么 $p$ 依次为 $[1,2,3,2]$，任意长度的结果即为 $1 \times 2 \times 3 \times 2=12$ 个。

对于长度小于等于 $k-1$ 的结果，我们可以使用动态规划进行计算。我们首先将上面所有的 $p$ 记录在频次数组 $freq$ 中，随后记 $f(i,j)$ 表示考虑用 $freq$ 中下标小于等于 $i$ 的部分构造字符串，并且构造的字符串长度等于 $j$ 的方案数。在进行状态转移时，我们可以枚举 $freq[i]$ 对应的字符使用的次数，范围即为 $1,2,\dots,freq[i]$。如果使用了 $j′$ 次，那么 $freq$ 中 下标严格小于 $i$ 的部分应该构造出长度等于 $j-j′$ 的字符串。这样我们就得到了状态转移方程：

$$f(i,j)=\sum\limits_{j′=1}^{freq[i]}​f(i-1,j-j′)$$

初始条件是 $f(-1,0)=1$，表示空字符串有一种方案。

当 $freq$ 本身的长度大于等于 $k$ 时，我们可以不用进行上述的动态规划计算，这是因为 $freq$ 中每一项都对应至少一个字符，那么构造出的字符串长度一定不会小于 $k-1$。因此，上述动态规划的时间复杂度为 $O(k^3)$，其中枚举 $i,j,j′$ 分别都需要 $O(k)$ 的时间，在 $k=2000$ 是会超出时间限制，我们需要进一步进行优化。

可以发现状态转移方程中的求和部分，它的下标 $j-j′$ 是连续的，因此我们可以在计算出所有的 $f(i-1,\dots)$ 之后，求出它的前缀和数组 $g(i-1,\dots)$，其中：

$$g(i-1,j)=\sum\limits_{j′=0}^j​f(i-1,j′)$$

这样一来，我们可以在 $O(1)$ 的时间直接求出 $f(i,j)$，即为：

$$f(i,j)=g(i-1,j-1)-g(i-1,j-freq[i]-1)$$

时间复杂度降低为 $O(k^2)$ 可以通过。

另一个可以使用的空间优化为，由于 $f(i,j)$ 只会从 $f(i-1,\dots)$（或者说 $g(i-1,\dots)$）得到，那么我们可以使用两个一维数组，代替整个 $f$ 进行状态转移，空间复杂度可以从 $O(k^2)$ 减少至 $O(k)$。

**代码**

```C++
class Solution {
public:
    int possibleStringCount(string word, int k) {
        int n = word.size(), cnt = 1;
        vector<int> freq;
        for (int i = 1; i < n; ++i) {
            if (word[i] == word[i - 1]) {
                ++cnt;
            }
            else {
                freq.push_back(cnt);
                cnt = 1;
            }
        }
        freq.push_back(cnt);

        int ans = 1;
        for (int o: freq) {
            ans = static_cast<long long>(ans) * o % mod;
        }

        if (freq.size() >= k) {
            return ans;
        }

        vector<int> f(k), g(k, 1);
        f[0] = 1;
        for (int i = 0; i < freq.size(); ++i) {
            vector<int> f_new(k);
            for (int j = 1; j < k; ++j) {
                f_new[j] = g[j - 1];
                if (j - freq[i] - 1 >= 0) {
                    f_new[j] = (f_new[j] - g[j - freq[i] - 1] + mod) % mod;
                }
            }
            vector<int> g_new(k);
            g_new[0] = f_new[0];
            for (int j = 1; j < k; ++j) {
                g_new[j] = (g_new[j - 1] + f_new[j]) % mod;
            }
            f = move(f_new);
            g = move(g_new);
        }
        return (ans - g[k - 1] + mod) % mod;
    }

private:
    static const int mod = 1000000007;
};
```

```Python
class Solution:
    def possibleStringCount(self, word: str, k: int) -> int:
        mod = 10**9 + 7
        n, cnt = len(word), 1
        freq = list()

        for i in range(1, n):
            if word[i] == word[i - 1]:
                cnt += 1
            else:
                freq.append(cnt)
                cnt = 1
        freq.append(cnt)

        ans = 1
        for o in freq:
            ans = ans * o % mod

        if len(freq) >= k:
            return ans

        f, g = [1] + [0] * (k - 1), [1] * k
        for i in range(len(freq)):
            f_new = [0] * k
            for j in range(1, k):
                f_new[j] = g[j - 1]
                if j - freq[i] - 1 >= 0:
                    f_new[j] = (f_new[j] - g[j - freq[i] - 1]) % mod
            g_new = [f_new[0]] + [0] * (k - 1)
            for j in range(1, k):
                g_new[j] = (g_new[j - 1] + f_new[j]) % mod
            f, g = f_new, g_new
        return (ans - g[k - 1]) % mod
```

```Java
class Solution {
    private static final int mod = 1000000007;

    public int possibleStringCount(String word, int k) {
        int n = word.length();
        int cnt = 1;
        List<Integer> freq = new ArrayList<>();
        for (int i = 1; i < n; ++i) {
            if (word.charAt(i) == word.charAt(i - 1)) {
                ++cnt;
            } else {
                freq.add(cnt);
                cnt = 1;
            }
        }
        freq.add(cnt);

        long ans = 1;
        for (int o : freq) {
            ans = ans * o % mod;
        }
        if (freq.size() >= k) {
            return (int) ans;
        }

        int[] f = new int[k];
        int[] g = new int[k];
        f[0] = 1;
        Arrays.fill(g, 1);
        for (int i = 0; i < freq.size(); ++i) {
            int[] f_new = new int[k];
            for (int j = 1; j < k; ++j) {
                f_new[j] = g[j - 1];
                if (j - freq.get(i) - 1 >= 0) {
                    f_new[j] = (f_new[j] - g[j - freq.get(i) - 1] + mod) % mod;
                }
            }
            int[] g_new = new int[k];
            g_new[0] = f_new[0];
            for (int j = 1; j < k; ++j) {
                g_new[j] = (g_new[j - 1] + f_new[j]) % mod;
            }
            f = f_new;
            g = g_new;
        }

        return (int) ((ans - g[k - 1] + mod) % mod);
    }
}
```

```CSharp
public class Solution {
    private const int mod = 1000000007;

    public int PossibleStringCount(string word, int k) {
        int n = word.Length;
        int cnt = 1;
        List<int> freq = new List<int>();

        for (int i = 1; i < n; ++i) {
            if (word[i] == word[i - 1]) {
                ++cnt;
            } else {
                freq.Add(cnt);
                cnt = 1;
            }
        }
        freq.Add(cnt);
        long ans = 1;
        foreach (int o in freq) {
            ans = ans * o % mod;
        }
        if (freq.Count >= k) {
            return (int) ans;
        }

        int[] f = new int[k];
        int[] g = new int[k];
        f[0] = 1;
        Array.Fill(g, 1);
        for (int i = 0; i < freq.Count; ++i) {
            int[] f_new = new int[k];
            for (int j = 1; j < k; ++j) {
                f_new[j] = g[j - 1];
                if (j - freq[i] - 1 >= 0) {
                    f_new[j] = (f_new[j] - g[j - freq[i] - 1] + mod) % mod;
                }
            }

            int[] g_new = new int[k];
            g_new[0] = f_new[0];
            for (int j = 1; j < k; ++j) {
                g_new[j] = (g_new[j - 1] + f_new[j]) % mod;
            }

            f = f_new;
            g = g_new;
        }

        return (int) ((ans - g[k - 1] + mod) % mod);
    }
}
```

```Go
const mod = 1000000007

func possibleStringCount(word string, k int) int {
    n := len(word)
    cnt := 1
    var freq []int

    for i := 1; i < n; i++ {
        if word[i] == word[i-1] {
            cnt++
        } else {
            freq = append(freq, cnt)
            cnt = 1
        }
    }
    freq = append(freq, cnt)

    ans := 1
    for _, o := range freq {
        ans = ans * o % mod
    }

    if len(freq) >= k {
        return ans
    }

    f := make([]int, k)
    g := make([]int, k)
    f[0] = 1
    for i := range g {
        g[i] = 1
    }

    for i := 0; i < len(freq); i++ {
        f_new := make([]int, k)
        for j := 1; j < k; j++ {
            f_new[j] = g[j-1]
            if j - freq[i] - 1 >= 0 {
                f_new[j] = (f_new[j] - g[j - freq[i] - 1] + mod) % mod
            }
        }
        g_new := make([]int, k)
        g_new[0] = f_new[0]
        for j := 1; j < k; j++ {
            g_new[j] = (g_new[j-1] + f_new[j]) % mod
        }
        f, g = f_new, g_new
    }

    return (ans - g[k-1] + mod) % mod
}
```

```C
#define MOD 1000000007

int possibleStringCount(char* word, int k) {
    int n = strlen(word);
    int cnt = 1;
    int freq[n];
    memset(freq, 0, sizeof(int) * n);
    int freqSize = 0;
    for (int i = 1; i < n; ++i) {
        if (word[i] == word[i - 1]) {
            ++cnt;
        } else {
            freq[freqSize++] = cnt;
            cnt = 1;
        }
    }
    freq[freqSize++] = cnt;

    long ans = 1;
    for (int i = 0; i < freqSize; ++i) {
        ans = ans * freq[i] % MOD;
    }

    if (freqSize >= k) {
        return (int)ans;
    }

    int f[k], g[k], f_new[k], g_new[k];
    f[0] = 1;
    for (int i = 0; i < k; ++i) {
        g[i] = 1;
    }
    for (int i = 0; i < freqSize; ++i) {
        memset(f_new, 0, sizeof(int) * k);
        for (int j = 1; j < k; ++j) {
            f_new[j] = g[j - 1];
            if (j - freq[i] - 1 >= 0) {
                f_new[j] = (f_new[j] - g[j - freq[i] - 1] + MOD) % MOD;
            }
        }
        memset(g_new, 0, sizeof(int) * k);
        g_new[0] = f_new[0];
        for (int j = 1; j < k; ++j) {
            g_new[j] = (g_new[j - 1] + f_new[j]) % MOD;
        }
        memcpy(f, f_new, sizeof(int) * k);
        memcpy(g, g_new, sizeof(int) * k);
    }

    int result = (ans - g[k - 1] + MOD) % MOD;
    return result;
}
```

```JavaScript
var possibleStringCount = function(word, k) {
    const mod = 1000000007;
    const n = word.length;
    let cnt = 1;
    const freq = [];

    for (let i = 1; i < n; ++i) {
        if (word[i] === word[i - 1]) {
            ++cnt;
        } else {
            freq.push(cnt);
            cnt = 1;
        }
    }
    freq.push(cnt);

    let ans = 1;
    for (const o of freq) {
        ans = ans * o % mod;
    }

    if (freq.length >= k) {
        return ans;
    }

    let f = new Array(k).fill(0);
    let g = new Array(k).fill(1);
    f[0] = 1;

    for (let i = 0; i < freq.length; ++i) {
        const f_new = new Array(k).fill(0);
        for (let j = 1; j < k; ++j) {
            f_new[j] = g[j - 1];
            if (j - freq[i] - 1 >= 0) {
                f_new[j] = (f_new[j] - g[j - freq[i] - 1] + mod) % mod;
            }
        }
        const g_new = new Array(k).fill(0);
        g_new[0] = f_new[0];
        for (let j = 1; j < k; ++j) {
            g_new[j] = (g_new[j - 1] + f_new[j]) % mod;
        }
        f = f_new;
        g = g_new;
    }
    return (ans - g[k - 1] + mod) % mod;
};
```

```TypeScript
function possibleStringCount(word: string, k: number): number {
    const mod: number = 1000000007;
    const n = word.length;
    let cnt = 1;
    const freq: number[] = [];

    for (let i = 1; i < n; ++i) {
        if (word[i] === word[i - 1]) {
            ++cnt;
        } else {
            freq.push(cnt);
            cnt = 1;
        }
    }
    freq.push(cnt);

    let ans = 1;
    for (const o of freq) {
        ans = ans * o % mod;
    }

    if (freq.length >= k) {
        return ans;
    }

    let f: number[] = new Array(k).fill(0);
    let g: number[] = new Array(k).fill(1);
    f[0] = 1;
    for (let i = 0; i < freq.length; ++i) {
        const f_new: number[] = new Array(k).fill(0);
        for (let j = 1; j < k; ++j) {
            f_new[j] = g[j - 1];
            if (j - freq[i] - 1 >= 0) {
                f_new[j] = (f_new[j] - g[j - freq[i] - 1] + mod) % mod;
            }
        }
        const g_new: number[] = new Array(k).fill(0);
        g_new[0] = f_new[0];
        for (let j = 1; j < k; ++j) {
            g_new[j] = (g_new[j - 1] + f_new[j]) % mod;
        }
        f = f_new;
        g = g_new;
    }

    return (ans - g[k - 1] + mod) % mod;
};
```

```Rust
impl Solution {
    pub fn possible_string_count(word: String, k: i32) -> i32 {
        const MOD: i64 = 1_000_000_007;
        let n = word.len();
        let mut cnt = 1;
        let mut freq: Vec<i32> = Vec::new();
        let word_chars: Vec<char> = word.chars().collect();

        for i in 1..n {
            if word_chars[i] == word_chars[i - 1] {
                cnt += 1;
            } else {
                freq.push(cnt);
                cnt = 1;
            }
        }
        freq.push(cnt);

        let mut ans: i64 = 1;
        for &o in &freq {
            ans = ans * o as i64 % MOD;
        }

        if freq.len() >= k as usize {
            return ans as i32;
        }

        let k_usize = k as usize;
        let mut f = vec![0; k_usize];
        let mut g = vec![1; k_usize];
        f[0] = 1;

        for &num in &freq {
            let mut f_new = vec![0; k_usize];
            for j in 1..k_usize {
                f_new[j] = g[j - 1];
                if j as i32 - num - 1 >= 0 {
                    f_new[j] = (f_new[j] - g[j - num as usize - 1] + MOD) % MOD;
                }
            }
            let mut g_new = vec![0; k_usize];
            g_new[0] = f_new[0];
            for j in 1..k_usize {
                g_new[j] = (g_new[j - 1] + f_new[j]) % MOD;
            }
            f = f_new;
            g = g_new;
        }

        ((ans - g[k_usize - 1] as i64 + MOD) % MOD) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+k^2)$，其中 $n$ 是字符串 $words$ 的长度。
- 空间复杂度：$O(k)$。
