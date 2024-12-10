### [骑士拨号器](https://leetcode.cn/problems/knight-dialer/solutions/3002022/qi-shi-bo-hao-qi-by-leetcode-solution-5x9m/)

#### 方法一：动态规划

**思路与算法**

我们用 $d[n][x]$ 表示在数字单元格 $x$ 上执行 $n-1$ 次跳跃后可得到的不同的长度为 $n$ 的号码数量，别紧张，我们只是暂时用它来描述要解决的问题。现在我们要从 $x$ 出发，遵循骑士的移动方式来跳跃到其他的数字上，例如 $y$，而此时问题将变为求解 $d[n-1][y]$。因此，我们只要找到对于 $x$ 来说所有合法的 $y$，就可以将一个需要移动 $n-1$ 次来解决的问题缩减为几个需要移动 $n-2$ 次来解决的问题。

值得庆幸的是，题目给定的电话垫很小，总共不过 $10$ 个合法的位置，只需预处理出每个 $x$ 的 $y$ 集合即可。这样我们就不用在每个位置上一一枚举 $8$ 个方向进行移动了。

综上，我们得到递推方程：

$$d[n][x]= \sum_{y \in S_x}​​d[n][y]$$

其中 $S_x​$ 是位置 $x$ 的合法移动集合，例如 $x=0$ 时，$S_0​=\{4,6\}, x=4$ 时，$S_4​=\{3,9,0\}$。

最初，所有的 $d[1][x]$ 都初始化为 $1$，最终答案是所有 $d[n][x]$ 的和。一般情况下，我们需要一个形状为 $n \times 10$ 的二维数组来存放所有问题的解，但注意到第 $n$ 维度的问题只需要借助第 $n-1$ 维度的答案来求解，因此可以压缩为 $2 \times 10$ 的二维数组，然后通过循环、滚动的方式不断重复利用另一层为空的数组（大小为 $10$），进而降低空间利用率。

**代码**

```C++
class Solution {
    static constexpr int mod = 1e9 + 7;

public:
    int knightDialer(int n) {
        vector<vector<int>> moves = {
            {4, 6},
            {6, 8},
            {7, 9},
            {4, 8},
            {3, 9, 0},
            {},
            {1, 7, 0},
            {2, 6},
            {1, 3},
            {2, 4}
        };
        vector<vector<int>> d(2, vector<int>(10, 0));
        fill(d[1].begin(), d[1].end(), 1);
        for (int i = 2; i <= n; i++) {
            int x = i & 1;
            for (int j = 0; j < 10; j++) {
                d[x][j] = 0;
                for (int k : moves[j]) {
                    d[x][j] = (d[x][j] + d[x ^ 1][k]) % mod;
                }
            }
        }
        int res = 0;
        for (auto x : d[n % 2]) {
            res = (res + x) % mod;
        }
        return res;
    }
};
```

```Java
class Solution {
    static final int MOD = 1000000007;

    public int knightDialer(int n) {
        int[][] moves = {
            {4, 6},
            {6, 8},
            {7, 9},
            {4, 8},
            {3, 9, 0},
            {},
            {1, 7, 0},
            {2, 6},
            {1, 3},
            {2, 4}
        };
        int[][] d = new int[2][10];
        Arrays.fill(d[1], 1);
        for (int i = 2; i <= n; i++) {
            int x = i & 1;
            for (int j = 0; j < 10; j++) {
                d[x][j] = 0;
                for (int k : moves[j]) {
                    d[x][j] = (d[x][j] + d[x ^ 1][k]) % MOD;
                }
            }
        }
        int res = 0;
        for (int x : d[n % 2]) {
            res = (res + x) % MOD;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    const int MOD = 1000000007;

    public int KnightDialer(int n) {
        int[][] moves = {
            new int[]{4, 6},
            new int[]{6, 8},
            new int[]{7, 9},
            new int[]{4, 8},
            new int[]{3, 9, 0},
            new int[]{},
            new int[]{1, 7, 0},
            new int[]{2, 6},
            new int[]{1, 3},
            new int[]{2, 4}
        };
        int[][] d = new int[2][];
        for (int i = 0; i < 2; i++) {
            d[i] = new int[10];
        }
        Array.Fill(d[1], 1);
        for (int i = 2; i <= n; i++) {
            int x = i & 1;
            for (int j = 0; j < 10; j++) {
                d[x][j] = 0;
                foreach (int k in moves[j]) {
                    d[x][j] = (d[x][j] + d[x ^ 1][k]) % MOD;
                }
            }
        }
        int res = 0;
        foreach (int x in d[n % 2]) {
            res = (res + x) % MOD;
        }
        return res;
    }
}
```

```Python
class Solution:
    def knightDialer(self, n: int) -> int:
        mod = 10**9 + 7
        moves = [
            [4, 6],
            [6, 8],
            [7, 9],
            [4, 8],
            [3, 9, 0],
            [], 
            [1, 7, 0],
            [2, 6],
            [1, 3],
            [2, 4]
        ]
        
        d = [[0] * 10 for _ in range(2)]
        d[1] = [1] * 10
        
        for i in range(2, n + 1):
            x = i & 1  
            for j in range(10):
                d[x][j] = 0
                for k in moves[j]:
                    d[x][j] = (d[x][j] + d[x ^ 1][k]) % mod
        
        return sum(d[n % 2]) % mod
```

```Go
func knightDialer(n int) int {
    const mod = 1_000_000_007
    moves := [][]int{
        {4, 6},
        {6, 8},
        {7, 9},
        {4, 8},
        {3, 9, 0},
        {},
        {1, 7, 0},
        {2, 6},
        {1, 3},
        {2, 4},
    }
    d := [2][10]int{}
    for i := 0; i < 10; i++ {
        d[1][i] = 1
    }
    for i := 2; i <= n; i++ {
        x := i & 1
        for j := 0; j < 10; j++ {
            d[x][j] = 0
            for _, k := range moves[j] {
                d[x][j] = (d[x][j] + d[x ^ 1][k]) % mod
            }
        }
    }
    res := 0
    for _, x := range d[n%2] {
        res = (res + x) % mod
    }
    return res
}
```

```C
#define MOD 1000000007

int knightDialer(int n) {
    int moves[10][4] = {
        {4, 6, -1, -1},
        {6, 8, -1, -1},
        {7, 9, -1, -1},
        {4, 8, -1, -1},
        {3, 9, 0, -1},
        {-1, -1, -1, -1},
        {1, 7, 0, -1},
        {2, 6, -1, -1},
        {1, 3, -1, -1},
        {2, 4, -1, -1}
    };
    int d[2][10] = {0};
    for (int i = 0; i < 10; i++) {
        d[1][i] = 1;
    }
    for (int i = 2; i <= n; i++) {
        int x = i & 1;
        for (int j = 0; j < 10; j++) {
            d[x][j] = 0;
            for (int k = 0; moves[j][k] != -1; k++) {
                d[x][j] = (d[x][j] + d[x ^ 1][moves[j][k]]) % MOD;
            }
        }
    }
    int res = 0;
    for (int i = 0; i < 10; i++) {
        res = (res + d[n % 2][i]) % MOD;
    }
    return res;
}
```

```JavaScript
var knightDialer = function(n) {
    const mod = 1_000_000_007;
    const moves = [
        [4, 6],
        [6, 8],
        [7, 9],
        [4, 8],
        [3, 9, 0],
        [],
        [1, 7, 0],
        [2, 6],
        [1, 3],
        [2, 4],
    ];
    const d = Array.from({ length: 2 }, () => Array(10).fill(0));
    d[1].fill(1);
    for (let i = 2; i <= n; i++) {
        const x = i & 1;
        for (let j = 0; j < 10; j++) {
            d[x][j] = 0;
            for (const k of moves[j]) {
                d[x][j] = (d[x][j] + d[x ^ 1][k]) % mod;
            }
        }
    }
    return d[n % 2].reduce((res, x) => (res + x) % mod, 0);
};
```

```TypeScript
function knightDialer(n: number): number {
    const mod = 1_000_000_007;
    const moves: number[][] = [
        [4, 6],
        [6, 8],
        [7, 9],
        [4, 8],
        [3, 9, 0],
        [],
        [1, 7, 0],
        [2, 6],
        [1, 3],
        [2, 4],
    ];
    const d = Array.from({ length: 2 }, () => Array(10).fill(0));
    d[1].fill(1);

    for (let i = 2; i <= n; i++) {
        const x = i & 1;
        for (let j = 0; j < 10; j++) {
            d[x][j] = 0;
            for (const k of moves[j]) {
                d[x][j] = (d[x][j] + d[x ^ 1][k]) % mod;
            }
        }
    }
    return d[n % 2].reduce((res, x) => (res + x) % mod, 0);
};
```

```Rust
const MOD: i32 = 1_000_000_007;

impl Solution {
    pub fn knight_dialer(n: i32) -> i32 {
        let moves = vec![
            vec![4, 6],
            vec![6, 8],
            vec![7, 9],
            vec![4, 8],
            vec![3, 9, 0],
            vec![],
            vec![1, 7, 0],
            vec![2, 6],
            vec![1, 3],
            vec![2, 4],
        ];
        let mut d = vec![vec![0; 10], vec![1; 10]];
        for i in 2..=n {
            let x = (i % 2) as usize;
            for j in 0..10 {
                d[x][j] = 0;
                for &k in &moves[j] {
                    d[x][j] = (d[x][j] + d[1 - x][k]) % MOD;
                }
            }
        }
        d[(n % 2) as usize].iter().fold(0, |res, &x| (res + x) % MOD)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。此处我们忽略了状态转移时的复杂度，因为这部分的系数是一个常数，大约为 $10$，但在做题过程中，你需要考虑这部分影响来评估是否可通过所有测试。
- 空间复杂度：$O(1)$。在使用滚动数组实现时，空间复杂度为 $O(1)$，否则为 $O(n)$。

#### 方法二：矩阵快速幂

**思路与算法**

本题还有另外一种时间复杂度更低的做法，是使用矩阵快速幂。我们把每次 $10$ 个一组的递推视作矩阵相乘，假设现在有一个形状为 $1 \times 10$ 的矩阵 $s$ 表示十个位置的答案，那么它的一次递推大概是做这样一次运算：

$$[s_0​,s_1​,s_2​,s_3​,s_4​,s_5​,s_6​,s_7​,s_8​,s_9​​] \times \begin{bmatrix} 0,0,0,0,1,0,1,0,0,0 \\ 0,0,0,0,0,0,1,0,1,0 \\ 0,0,0,0,0,0,0,1,0,1 \\ 0,0,0,0,1,0,0,0,1,0 \\ 1,0,0,1,0,0,0,0,0,1 \\ 0,0,0,0,0,0,0,0,0,0 \\ 1,1,0,0,0,0,0,1,0,0 \\ 0,0,1,0,0,0,1,0,0,0 \\ 0,1,0,1,0,0,0,0,0,0 \\ 0,0,1,0,1,0,0,0,0,0​ \end{bmatrix}$$

我们把右侧那个矩阵称作 $base$，因为它是我们后面每次转移的基座，我们注意观察它第四列的元素，在第 $0,3,9$ 行处为 $1$，其他地方为 $0$，那么相乘结果就是 $s_0​+s_2​+s_9$​，这正是 $s_4^′$​ 的答案。

因此，我们其实只需要求出 $base^{n-1}$， 就可以快速的求出答案了！而求解 $base^{n-1}$ 可以使用矩阵快速幂加速，因此复杂度将降低至 $O(10^3logn)$，由于这里的 $n$ 最大为 $5000$，所以实际优化不明显，但它的优势将在 $n$ 更大时显现。

**代码**

```C++
class Solution {
    static constexpr int mod = 1e9 + 7;

public:
    vector<vector<int>> mul(const vector<vector<int>> &lth, const vector<vector<int>> &rth) {
        vector<vector<int>> res(lth.size(), vector<int>(rth[0].size(), 0));
        for (int k = 0; k < lth[0].size(); k++) {
            for (int i = 0; i < lth.size(); i++) {
                for (int j = 0; j < rth[0].size(); j++) {
                    res[i][j] = (res[i][j] + 1ll * lth[i][k] * rth[k][j] % mod) % mod;
                }
            }
        }
        return res;
    }

    int knightDialer(int n) {
        vector<vector<int>> base = {
            {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
            {0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
            {1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {1, 1, 0, 0, 0, 0, 0, 1, 0, 0},
            {0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
            {0, 1, 0, 1, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 1, 0, 0, 0, 0, 0}
        };
        vector<vector<int>> res = {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };

        vector<vector<int>> base2 = vector<vector<int>>(10, vector<int>(10, 0));
        for (int i = 0; i < 10; i++) {
            base2[i][i] = 1;
        }
        n--;
        while (n > 0) {
            if (n & 1) {
                base2 = mul(base2, base);
            }
            base = mul(base, base);
            n >>= 1;
        }
        res = mul(res, base2);
        int ret = 0;
        for (auto x : res[0]) {
            ret = (ret + x) % mod;
        }

        return ret;
    }
};
```

```Java
class Solution {
    static final int MOD = 1000000007;

    public int knightDialer(int n) {
        int[][] original = {
            {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
            {0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
            {0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
            {1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {1, 1, 0, 0, 0, 0, 0, 1, 0, 0},
            {0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
            {0, 1, 0, 1, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 1, 0, 0, 0, 0, 0}
        };
        int[][] res = {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };

        int[][] original2 = new int[10][10];
        for (int i = 0; i < 10; i++) {
            original2[i][i] = 1;
        }
        n--;
        while (n > 0) {
            if ((n & 1) != 0) {
                original2 = mul(original2, original);
            }
            original = mul(original, original);
            n >>= 1;
        }
        res = mul(res, original2);
        int ret = 0;
        for (int x : res[0]) {
            ret = (ret + x) % MOD;
        }

        return ret;
    }

    public int[][] mul(int[][] lth, int[][] rth) {
        int[][] res = new int[lth.length][rth[0].length];
        for (int k = 0; k < lth[0].length; k++) {
            for (int i = 0; i < lth.length; i++) {
                for (int j = 0; j < rth[0].length; j++) {
                    res[i][j] = (int) ((res[i][j] + 1L * lth[i][k] * rth[k][j] % MOD) % MOD);
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    const int MOD = 1000000007;

    public int KnightDialer(int n) {
        int[][] original = {
            new int[]{0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
            new int[]{0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
            new int[]{0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
            new int[]{0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
            new int[]{1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
            new int[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            new int[]{1, 1, 0, 0, 0, 0, 0, 1, 0, 0},
            new int[]{0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
            new int[]{0, 1, 0, 1, 0, 0, 0, 0, 0, 0},
            new int[]{0, 0, 1, 0, 1, 0, 0, 0, 0, 0}
        };
        int[][] res = {
            new int[]{1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };

        int[][] original2 = new int[10][];
        for (int i = 0; i < 10; i++) {
            original2[i] = new int[10];
            original2[i][i] = 1;
        }
        n--;
        while (n > 0) {
            if ((n & 1) != 0) {
                original2 = Mul(original2, original);
            }
            original = Mul(original, original);
            n >>= 1;
        }
        res = Mul(res, original2);
        int ret = 0;
        foreach (int x in res[0]) {
            ret = (ret + x) % MOD;
        }

        return ret;
    }

    public int[][] Mul(int[][] lth, int[][] rth) {
        int[][] res = new int[lth.Length][];
        for (int i = 0; i < lth.Length; i++) {
            res[i] = new int[rth[0].Length];
        }
        for (int k = 0; k < lth[0].Length; k++) {
            for (int i = 0; i < lth.Length; i++) {
                for (int j = 0; j < rth[0].Length; j++) {
                    res[i][j] = (int) ((res[i][j] + 1L * lth[i][k] * rth[k][j] % MOD) % MOD);
                }
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    MOD = 10**9 + 7
    
    def mul(self, lth: list[list[int]], rth: list[list[int]]) -> list[list[int]]:
        rows, cols, inner_dim = len(lth), len(rth[0]), len(lth[0])
        res = [[0] * cols for _ in range(rows)]
        
        for k in range(inner_dim):
            for i in range(rows):
                for j in range(cols):
                    res[i][j] = (res[i][j] + lth[i][k] * rth[k][j] % self.MOD) % self.MOD
        return res
    
    def knightDialer(self, n: int) -> int:
        base = [
            [0, 0, 0, 0, 1, 0, 1, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 1, 0, 1, 0],
            [0, 0, 0, 0, 0, 0, 0, 1, 0, 1],
            [0, 0, 0, 0, 1, 0, 0, 0, 1, 0],
            [1, 0, 0, 1, 0, 0, 0, 0, 0, 1],
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [1, 1, 0, 0, 0, 0, 0, 1, 0, 0],
            [0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
            [0, 1, 0, 1, 0, 0, 0, 0, 0, 0],
            [0, 0, 1, 0, 1, 0, 0, 0, 0, 0]
        ]
        
        res = [[1] * 10]
        
        base2 = [[1 if i == j else 0 for j in range(10)] for i in range(10)]
        
        n -= 1
        while n > 0:
            if n & 1:
                base2 = self.mul(base2, base)
            base = self.mul(base, base)
            n >>= 1
        
        res = self.mul(res, base2)
        return sum(res[0]) % self.MOD
```

```Go
const mod = 1_000_000_007

func knightDialer(n int) int {
    base := [][]int{
        {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
        {0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
        {0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
        {1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 0, 0, 0, 0, 0, 1, 0, 0},
        {0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
        {0, 1, 0, 1, 0, 0, 0, 0, 0, 0},
        {0, 0, 1, 0, 1, 0, 0, 0, 0, 0},
    }
    res := [][]int{
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
    }
    base2 := make([][]int, 10)
    for i := 0; i < 10; i++ {
        base2[i] = make([]int, 10)
        base2[i][i] = 1
    }
    n--
    for n > 0 {
        if n & 1 == 1 {
            base2 = mul(base2, base)
        }
        base = mul(base, base)
        n >>= 1
    }
    res = mul(res, base2)
    ret := 0
    for _, x := range res[0] {
        ret = (ret + x) % mod
    }
    return ret
}

func mul(lth, rth [][]int) [][]int {
    rows, cols, inner := len(lth), len(rth[0]), len(lth[0])
    res := make([][]int, rows)
    for i := range res {
        res[i] = make([]int, cols)
    }
    for k := 0; k < inner; k++ {
        for i := 0; i < rows; i++ {
            for j := 0; j < cols; j++ {
                res[i][j] = (res[i][j] + lth[i][k] * rth[k][j] % mod) % mod
            }
        }
    }
    return res
}
```

```C
#define MOD 1000000007

int matrix[10][10] = {
    {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
    {0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
    {0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
    {1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {1, 1, 0, 0, 0, 0, 0, 1, 0, 0},
    {0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
    {0, 1, 0, 1, 0, 0, 0, 0, 0, 0},
    {0, 0, 1, 0, 1, 0, 0, 0, 0, 0},
};

void mul(int **lth, int **rth, int **res, int rowsl, int colsl, int colsr) {
    int *temp[rowsl];
    for (int i = 0; i < rowsl; i++) {
        temp[i] = (int *)malloc(sizeof(int) * colsr);
        memset(temp[i], 0, sizeof(int) * colsr);
        for (int j = 0; j < colsr; j++) {
            for (int k = 0; k < colsl; k++) {
                temp[i][j] = (temp[i][j] + (long long)lth[i][k] * rth[k][j] % MOD) % MOD;
            }
        }
    }
    for (int i = 0; i < rowsl; i++) {
        memcpy(res[i], temp[i], sizeof(int) * colsr);
        free(temp[i]);
    }
}

int knightDialer(int n) {
    int *base[10], *base2[10];
    int *res[1];
    int *finalRes[1];
    for (int i = 0; i < 10; i++) {
        base[i] = (int *)malloc(sizeof(int) * 10);
        base2[i] = (int *)malloc(sizeof(int) * 10);
        memset(base2[i], 0, sizeof(int) * 10);
        memcpy(base[i], &matrix[i], sizeof(int) * 10);
    }
    res[0] = (int *)malloc(sizeof(int) * 10);
    finalRes[0] = (int *)malloc(sizeof(int) * 10);
    for (int i = 0; i < 10; i++) {
        base2[i][i] = 1;
        res[0][i] = 1;
    }
    n--;
    while (n > 0) {
        if (n & 1) {
            mul(base2, base, base2, 10, 10, 10);
        }
        mul(base, base, base, 10, 10 , 10);
        n >>= 1;
    }
    mul(res, base2, finalRes, 1, 10, 10);
    long long ret = 0;
    for (int i = 0; i < 10; i++) {
        ret = (ret + finalRes[0][i]) % MOD;
    }
    for (int i = 0; i < 10; i++) {
        free(base[i]);
        free(base2[i]);
    }
    free(res[0]);
    free(finalRes[0]);
    return ret;
}
```

```JavaScript
const mod = 1_000_000_007;

var knightDialer = function(n) {
    let base = [
        [0, 0, 0, 0, 1, 0, 1, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 1, 0, 1, 0],
        [0, 0, 0, 0, 0, 0, 0, 1, 0, 1],
        [0, 0, 0, 0, 1, 0, 0, 0, 1, 0],
        [1, 0, 0, 1, 0, 0, 0, 0, 0, 1],
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        [1, 1, 0, 0, 0, 0, 0, 1, 0, 0],
        [0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
        [0, 1, 0, 1, 0, 0, 0, 0, 0, 0],
        [0, 0, 1, 0, 1, 0, 0, 0, 0, 0],
    ];
    let base2 = Array.from({ length: 10 }, (_, i) => Array(10).fill(0).map((_, j) => (i === j ? 1 : 0)));
    let res = [[1, 1, 1, 1, 1, 1, 1, 1, 1, 1]];
    n--;
    while (n > 0) {
        if (n & 1) {
            base2 = mul(base2, base);
        }
        base = mul(base, base);
        n >>= 1;
    }

    res = mul(res, base2);
    return res[0].reduce((sum, x) => (sum + x) % mod, 0);
};

function mul(lth, rth) {
    const res = Array.from({ length: lth.length }, () => Array(rth[0].length).fill(0));
    for (let k = 0; k < lth[0].length; k++) {
        for (let i = 0; i < lth.length; i++) {
            for (let j = 0; j < rth[0].length; j++) {
                res[i][j] = Number((BigInt(res[i][j]) + (BigInt(lth[i][k]) * BigInt(rth[k][j])) % BigInt(mod)) % BigInt(mod));
            }
        }
    }
    return res;
}
```

```TypeScript
const mod = 1e9 + 7;

function mul(lth: number[][], rth: number[][]): number[][] {
    const rows = lth.length;
    const cols = rth[0].length;
    const temp: number[][] = Array.from({ length: rows }, () => Array(cols).fill(0));

    for (let k = 0; k < lth[0].length; k++) {
        for (let i = 0; i < rows; i++) {
            for (let j = 0; j < cols; j++) {
                temp[i][j] = Number((BigInt(temp[i][j]) + (BigInt(lth[i][k]) * BigInt(rth[k][j])) % BigInt(mod)) % BigInt(mod));
            }
        }
    }

    return temp;
}

function knightDialer(n: number): number {
    let base = [
        [0, 0, 0, 0, 1, 0, 1, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 1, 0, 1, 0],
        [0, 0, 0, 0, 0, 0, 0, 1, 0, 1],
        [0, 0, 0, 0, 1, 0, 0, 0, 1, 0],
        [1, 0, 0, 1, 0, 0, 0, 0, 0, 1],
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        [1, 1, 0, 0, 0, 0, 0, 1, 0, 0],
        [0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
        [0, 1, 0, 1, 0, 0, 0, 0, 0, 0],
        [0, 0, 1, 0, 1, 0, 0, 0, 0, 0],
    ];
    let base2: number[][] = Array.from({ length: 10 }, (_, i) => Array(10).fill(0).map((_, j) => (i === j ? 1 : 0)));
    let res: number[][] = [[1, 1, 1, 1, 1, 1, 1, 1, 1, 1]];
    n--;
    while (n > 0) {
        if (n & 1) {
            base2 = mul(base2, base);
        }
        base = mul(base, base);
        n >>= 1;
    }
    res = mul(res, base2);
    return res[0].reduce((sum, x) => (sum + x) % mod, 0);
};
```

```Rust
const MOD: i64 = 1_000_000_007;

impl Solution {
    pub fn knight_dialer(n: i32) -> i32 {
        let mut base = vec![
            vec![0, 0, 0, 0, 1, 0, 1, 0, 0, 0],
            vec![0, 0, 0, 0, 0, 0, 1, 0, 1, 0],
            vec![0, 0, 0, 0, 0, 0, 0, 1, 0, 1],
            vec![0, 0, 0, 0, 1, 0, 0, 0, 1, 0],
            vec![1, 0, 0, 1, 0, 0, 0, 0, 0, 1],
            vec![0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            vec![1, 1, 0, 0, 0, 0, 0, 1, 0, 0],
            vec![0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
            vec![0, 1, 0, 1, 0, 0, 0, 0, 0, 0],
            vec![0, 0, 1, 0, 1, 0, 0, 0, 0, 0],
        ];
        let mut base2 = vec![vec![0; 10]; 10];
        for i in 0..10 {
            base2[i][i] = 1;
        }
        let mut res = vec![vec![1; 10]];

        let mut n = n - 1;
        while n > 0 {
            if n & 1 == 1 {
                base2 = Self::mul(&base2, &base);
            }
            base = Self::mul(&base, &base);
            n >>= 1;
        }

        res = Self::mul(&res, &base2);
        res[0].iter().fold(0, |acc, &x| (acc + x) % MOD) as i32
    }

    pub fn mul(lth: &Vec<Vec<i64>>, rth: &Vec<Vec<i64>>) -> Vec<Vec<i64>> {
        let rows = lth.len();
        let cols = rth[0].len();
        let mut temp = vec![vec![0; cols]; rows];

        for k in 0..lth[0].len() {
            for i in 0..rows {
                for j in 0..cols {
                    temp[i][j] = (temp[i][j] + lth[i][k] * rth[k][j] % MOD) % MOD;
                }
            }
        }

        temp
    }
}
```

**复杂度分析**

- 时间复杂度：$O(logn)$。需要注意这里的系数是 $10^3$，即单次矩阵乘法的时间复杂度。
- 空间复杂度：$O(1)$。
