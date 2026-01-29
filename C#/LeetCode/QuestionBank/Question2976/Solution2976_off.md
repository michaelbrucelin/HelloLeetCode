### [转换字符串的最小成本 I](https://leetcode.cn/problems/minimum-cost-to-convert-string-i/solutions/3889113/zhuan-huan-zi-fu-chuan-de-zui-xiao-cheng-9qc0/)

#### 方法一：Floyd 算法

**思路与算法**

我们需要得到字符串 $source$ 转换为 $target$ 的最小成本，而每个字符都是单独修改的，因此最小成本等于每一组 $source[i]$ 转换为 $target[i]$ 的最小成本之和。

我们构造有向图 $G$，G 中的每个节点是一个小写字母。对于每一组 $(original[i],changed[i],cost[i])$，我们在 $G$ 中从 $original[i]$ 向 $changed[i]$ 建边，边权为 $cost[i]$。这样一来，将 $source[i]$ 转换为 $target[i]$ 的最小成本，就等于 $G$ 中 $source[i]$ 到 $target[i]$ 的最短路径。

由于 $G$ 中不超过 $\vert \sum \vert =26$ 个节点，并且最多有 $m=2000$ 条边，因此可以使用 $Floyd$ 算法预处理出所有节点之间的最短路。

**代码**

```C++
class Solution {
public:
    long long minimumCost(string source, string target, vector<char>& original, vector<char>& changed, vector<int>& cost) {
        vector<vector<int>> G(26, vector<int>(26, inf));
        for (int i = 0; i < 26; ++i) {
            G[i][i] = 0;
        }

        int m = original.size();
        for (int i = 0; i < m; ++i) {
            int idx = original[i] - 'a';
            int idy = changed[i] - 'a';
            G[idx][idy] = min(G[idx][idy], cost[i]);
        }

        for (int k = 0; k < 26; ++k) {
            for (int i = 0; i < 26; ++i) {
                for (int j = 0; j < 26; ++j) {
                    G[i][j] = min(G[i][j], G[i][k] + G[k][j]);
                }
            }
        }

        int n = source.size();
        long long ans = 0;
        for (int i = 0; i < n; ++i) {
            int idx = source[i] - 'a';
            int idy = target[i] - 'a';
            if (G[idx][idy] == inf) {
                return -1;
            }
            ans += G[idx][idy];
        }

        return ans;
    }

private:
    static constexpr int inf = INT_MAX / 2;
};
```

```Python
class Solution:
    def minimumCost(self, source: str, target: str, original: List[str], changed: List[str], cost: List[int]) -> int:
        G = [[inf] * 26 for _ in range(26)]
        for i in range(26):
            G[i][i] = 0

        for x, y, z in zip(original, changed, cost):
            idx = ord(x) - ord("a")
            idy = ord(y) - ord("a")
            G[idx][idy] = min(G[idx][idy], z)

        for k in range(26):
            for i in range(26):
                for j in range(26):
                    G[i][j] = min(G[i][j], G[i][k] + G[k][j])

        ans = 0
        for x, y in zip(source, target):
            idx = ord(x) - ord("a")
            idy = ord(y) - ord("a")
            if G[idx][idy] == inf:
                return -1
            ans += G[idx][idy]

        return ans
```

```Java
class Solution {
    private static final int INF = Integer.MAX_VALUE / 2;

    public long minimumCost(String source, String target, char[] original, char[] changed, int[] cost) {
        int[][] G = new int[26][26];
        for (int i = 0; i < 26; i++) {
            Arrays.fill(G[i], INF);
            G[i][i] = 0;
        }

        int m = original.length;
        for (int i = 0; i < m; i++) {
            int idx = original[i] - 'a';
            int idy = changed[i] - 'a';
            G[idx][idy] = Math.min(G[idx][idy], cost[i]);
        }

        for (int k = 0; k < 26; k++) {
            for (int i = 0; i < 26; i++) {
                for (int j = 0; j < 26; j++) {
                    if (G[i][k] != INF && G[k][j] != INF) {
                        G[i][j] = Math.min(G[i][j], G[i][k] + G[k][j]);
                    }
                }
            }
        }

        int n = source.length();
        long ans = 0;
        for (int i = 0; i < n; i++) {
            int idx = source.charAt(i) - 'a';
            int idy = target.charAt(i) - 'a';
            if (G[idx][idy] == INF) {
                return -1;
            }
            ans += G[idx][idy];
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    private const int INF = int.MaxValue / 2;

    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
        int[,] G = new int[26, 26];
        for (int i = 0; i < 26; i++) {
            for (int j = 0; j < 26; j++) {
                G[i, j] = INF;
            }
            G[i, i] = 0;
        }

        int m = original.Length;
        for (int i = 0; i < m; i++) {
            int idx = original[i] - 'a';
            int idy = changed[i] - 'a';
            G[idx, idy] = Math.Min(G[idx, idy], cost[i]);
        }

        for (int k = 0; k < 26; k++) {
            for (int i = 0; i < 26; i++) {
                for (int j = 0; j < 26; j++) {
                    if (G[i, k] != INF && G[k, j] != INF) {
                        G[i, j] = Math.Min(G[i, j], G[i, k] + G[k, j]);
                    }
                }
            }
        }

        int n = source.Length;
        long ans = 0;
        for (int i = 0; i < n; i++) {
            int idx = source[i] - 'a';
            int idy = target[i] - 'a';
            if (G[idx, idy] == INF) {
                return -1;
            }
            ans += G[idx, idy];
        }

        return ans;
    }
}
```

```Go
func minimumCost(source string, target string, original []byte, changed []byte, cost []int) int64 {
    const INF = int(^uint(0) >> 1) / 2

    G := make([][]int, 26)
    for i := range G {
        G[i] = make([]int, 26)
        for j := range G[i] {
            G[i][j] = INF
        }
        G[i][i] = 0
    }

    m := len(original)
    for i := 0; i < m; i++ {
        idx := int(original[i] - 'a')
        idy := int(changed[i] - 'a')
        if cost[i] < G[idx][idy] {
            G[idx][idy] = cost[i]
        }
    }

    for k := 0; k < 26; k++ {
        for i := 0; i < 26; i++ {
            for j := 0; j < 26; j++ {
                if G[i][k] != INF && G[k][j] != INF {
                    G[i][j] = min(G[i][j], G[i][k] + G[k][j])
                }
            }
        }
    }

    n := len(source)
    var ans int64 = 0
    for i := 0; i < n; i++ {
        idx := int(source[i] - 'a')
        idy := int(target[i] - 'a')
        if G[idx][idy] == INF {
            return -1
        }
        ans += int64(G[idx][idy])
    }

    return ans
}
```

```C
const int INF = INT_MAX / 2;

long long minimumCost(char* source, char* target, char* original, int originalSize, char* changed, int changedSize, int* cost, int costSize) {
    int G[26][26];

    for (int i = 0; i < 26; i++) {
        for (int j = 0; j < 26; j++) {
            G[i][j] = INF;
        }
        G[i][i] = 0;
    }

    for (int i = 0; i < costSize; i++) {
        int idx = original[i] - 'a';
        int idy = changed[i] - 'a';
        if (cost[i] < G[idx][idy]) {
            G[idx][idy] = cost[i];
        }
    }

    for (int k = 0; k < 26; k++) {
        for (int i = 0; i < 26; i++) {
            for (int j = 0; j < 26; j++) {
                if (G[i][k] != INF && G[k][j] != INF) {
                    int new_cost = G[i][k] + G[k][j];
                    if (new_cost < G[i][j]) {
                        G[i][j] = new_cost;
                    }
                }
            }
        }
    }

    long long ans = 0;
    int n = strlen(source);
    for (int i = 0; i < n; i++) {
        int idx = source[i] - 'a';
        int idy = target[i] - 'a';
        if (G[idx][idy] == INF) {
            return -1;
        }
        ans += G[idx][idy];
    }

    return ans;
}
```

```JavaScript
function minimumCost(source, target, original, changed, cost) {
    const INF = Number.MAX_SAFE_INTEGER / 2;
    const G = Array(26).fill().map(() => Array(26).fill(INF));
    for (let i = 0; i < 26; i++) {
        G[i][i] = 0;
    }

    const m = original.length;
    for (let i = 0; i < m; i++) {
        const idx = original[i].charCodeAt(0) - 97;
        const idy = changed[i].charCodeAt(0) - 97;
        G[idx][idy] = Math.min(G[idx][idy], cost[i]);
    }

    for (let k = 0; k < 26; k++) {
        for (let i = 0; i < 26; i++) {
            for (let j = 0; j < 26; j++) {
                if (G[i][k] !== INF && G[k][j] !== INF) {
                    G[i][j] = Math.min(G[i][j], G[i][k] + G[k][j]);
                }
            }
        }
    }

    let ans = 0;
    const n = source.length;
    for (let i = 0; i < n; i++) {
        const idx = source.charCodeAt(i) - 97;
        const idy = target.charCodeAt(i) - 97;
        if (G[idx][idy] === INF) {
            return -1;
        }
        ans += G[idx][idy];
    }

    return ans;
}
```

```TypeScript
function minimumCost(source, target, original, changed, cost) {
    const INF = Number.MAX_SAFE_INTEGER / 2;
    const G = Array(26).fill().map(() => Array(26).fill(INF));
    for (let i = 0; i < 26; i++) {
        G[i][i] = 0;
    }

    const m = original.length;
    for (let i = 0; i < m; i++) {
        const idx = original.charCodeAt(i) - 97;
        const idy = changed.charCodeAt(i) - 97;
        G[idx][idy] = Math.min(G[idx][idy], cost[i]);
    }

    for (let k = 0; k < 26; k++) {
        for (let i = 0; i < 26; i++) {
            for (let j = 0; j < 26; j++) {
                if (G[i][k] !== INF && G[k][j] !== INF) {
                    G[i][j] = Math.min(G[i][j], G[i][k] + G[k][j]);
                }
            }
        }
    }

    let ans = 0;
    const n = source.length;
    for (let i = 0; i < n; i++) {
        const idx = source.charCodeAt(i) - 97;
        const idy = target.charCodeAt(i) - 97;
        if (G[idx][idy] === INF) {
            return -1;
        }
        ans += G[idx][idy];
    }

    return ans;
}
```

```Go
impl Solution {
    pub fn minimum_cost(source: String, target: String, original: Vec<char>, changed: Vec<char>, cost: Vec<i32>) -> i64 {
        const INF: i32 = i32::MAX / 2;
        let mut g = [[INF; 26]; 26];
        for i in 0..26 {
            g[i][i] = 0;
        }

        for i in 0..original.len() {
            let idx = (original[i] as u8 - b'a') as usize;
            let idy = (changed[i] as u8 - b'a') as usize;
            g[idx][idy] = g[idx][idy].min(cost[i]);
        }

        for k in 0..26 {
            for i in 0..26 {
                for j in 0..26 {
                    if g[i][k] != INF && g[k][j] != INF {
                        g[i][j] = g[i][j].min(g[i][k] + g[k][j]);
                    }
                }
            }
        }

        let mut ans: i64 = 0;
        let source_bytes = source.as_bytes();
        let target_bytes = target.as_bytes();

        for i in 0..source_bytes.len() {
            let idx = (source_bytes[i] - b'a') as usize;
            let idy = (target_bytes[i] - b'a') as usize;
            if g[idx][idy] == INF {
                return -1;
            }
            ans += g[idx][idy] as i64;
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m+\vert \sum \vert^3)$，其中 $n$ 是数组 $source$ 和 $target$ 的长度，$m$ 是数组 original、changed 和 $cost$ 的长度，$\sum $ 是字符集，在本题中为全部小写字母，$\vert \sum \vert =26$。
- 空间复杂度：$O(\vert \sum \vert^2)$。
