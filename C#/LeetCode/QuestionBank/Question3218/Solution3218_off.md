### [切蛋糕的最小总开销 I](https://leetcode.cn/problems/minimum-cost-for-cutting-cake-i/solutions/3016927/qie-dan-gao-de-zui-xiao-zong-kai-xiao-i-7kpj5/)

#### 方法一：记忆化搜索

**思路**

将原问题分解成子问题，设计函数 $dp[row_1,col_1,row_2,col_2]$ 表示切割完整的子矩形至最小单元的代价，其中子矩形的两个对角顶点的坐标分别为 $(row_1,col_1)$ 和 $(row_2,col_2)$。我们可以任意水平或者垂直切一刀，然后将问题分解成更小的子问题，直到分到最小单元。遍历所有可能的切法，取出最小值作为子问题的返回值。因为递归过程中有许多重复状态，我们利用记忆话搜索的方式来降低时间复杂度。最后返回 $dp(0,0,m-1,n-1)$ 即可。

**代码**

```Python
class Solution:
    def minimumCost(self, m: int, n: int, horizontalCut: List[int], verticalCut: List[int]) -> int:
        
        @cache
        def dp(row1: int, col1: int, row2: int, col2: int) -> int:
            if row1 == row2 and col1 == col2:
                return 0
            res = inf
            for i in range(row1, row2):
                res = min(res, dp(row1, col1, i, col2) + dp(i + 1, col1, row2, col2) + horizontalCut[i])
            for i in range(col1, col2):
                res = min(res, dp(row1, col1, row2, i) + dp(row1, i + 1, row2, col2) + verticalCut[i])
            return res

        return dp(0, 0, m - 1, n - 1)
```

```C++
class Solution {
public:
    int minimumCost(int m, int n, vector<int>& horizontalCut, vector<int>& verticalCut) {
        vector<int> cache(m * m * n * n, -1);
        auto index = [&](int row1, int col1, int row2, int col2) -> int {
            return (row1 * n + col1) * m * n + row2 * n + col2;
        };
        function<int(int, int, int, int)> dp;
        dp = [&](int row1, int col1, int row2, int col2) -> int {
            if (row1 == row2 && col1 == col2) {
                return 0;
            }
            int ind = index(row1, col1, row2, col2);
            if (cache[ind] >= 0) {
                return cache[ind];
            }
            cache[ind] = INT_MAX;
            for (int i = row1; i < row2; i++) {
                cache[ind] = min(cache[ind], dp(row1, col1, i, col2) + dp(i + 1, col1, row2, col2) + horizontalCut[i]);
            }
            for (int i = col1; i < col2; i++) {
                cache[ind] = min(cache[ind], dp(row1, col1, row2, i) + dp(row1, i + 1, row2, col2) + verticalCut[i]);
            }
            return cache[ind];
        };
        return dp(0, 0, m - 1, n - 1);
    }
};
```

```Go
func minimumCost(m int, n int, horizontalCut []int, verticalCut []int) int {
    cache := make([]int, m*m*n*n)
    for i := range cache {
        cache[i] = -1
    }

    index := func(row1, col1, row2, col2 int) int {
        return (row1*n + col1)*m*n + row2*n + col2
    }

    var dp func(row1, col1, row2, col2 int) int
    dp = func(row1, col1, row2, col2 int) int {
        if row1 == row2 && col1 == col2 {
            return 0
        }
        ind := index(row1, col1, row2, col2)
        if cache[ind] >= 0 {
            return cache[ind]
        }
        cache[ind] = math.MaxInt32
        for i := row1; i < row2; i++ {
            cache[ind] = min(cache[ind], dp(row1, col1, i, col2)+dp(i+1, col1, row2, col2)+horizontalCut[i])
        }
        for i := col1; i < col2; i++ {
            cache[ind] = min(cache[ind], dp(row1, col1, row2, i)+dp(row1, i+1, row2, col2)+verticalCut[i])
        }
        return cache[ind]
    }

    return dp(0, 0, m-1, n-1)
}
```

```C
int idx(int m, int n, int row1, int col1, int row2, int col2) {
    return (row1 * n + col1) * m * n + row2 * n + col2;
}

int dp(int m, int n, int row1, int col1, int row2, int col2, int *horizontalCut, int *verticalCut, int *cache) {
    if (row1 == row2 && col1 == col2) {
        return 0;
    }
    int ind = idx(m, n, row1, col1, row2, col2);
    if (cache[ind] >= 0) {
        return cache[ind];
    }
    cache[ind] = INT_MAX;
    for (int i = row1; i < row2; i++) {
        cache[ind] = fmin(cache[ind], dp(m, n, row1, col1, i, col2, horizontalCut, verticalCut, cache) + dp(m, n, i + 1, col1, row2, col2, horizontalCut, verticalCut, cache) + horizontalCut[i]);
    }
    for (int i = col1; i < col2; i++) {
        cache[ind] = fmin(cache[ind], dp(m, n, row1, col1, row2, i, horizontalCut, verticalCut, cache) + dp(m, n, row1, i + 1, row2, col2, horizontalCut, verticalCut, cache) + verticalCut[i]);
    }
    return cache[ind];
}

int minimumCost(int m, int n, int *horizontalCut, int horizontalCutSize, int *verticalCut, int verticalCutSize) {
    int *cache = (int *)malloc(m * m * n * n * sizeof(int));
    memset(cache, 0xff, m * m * n * n * sizeof(int));
    int res = dp(m, n, 0, 0, m - 1, n - 1, horizontalCut, verticalCut, cache);
    free(cache);
    return res;
}
```

```Java
class Solution {
    int[][][][] memo;
    int[] horizontalCut;
    int[] verticalCut;

    public int minimumCost(int m, int n, int[] horizontalCut, int[] verticalCut) {
        this.memo = new int[m][n][m][n];
        this.horizontalCut = horizontalCut;
        this.verticalCut = verticalCut;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < m; k++) {
                    Arrays.fill(memo[i][j][k], -1);
                }
            }
        }
        return dp(0, 0, m - 1, n - 1);
    }

    public int dp(int row1, int col1, int row2, int col2) {
        if (row1 == row2 && col1 == col2) {
            return 0;
        }
        if (memo[row1][col1][row2][col2] < 0) {
            int res = Integer.MAX_VALUE;
            for (int i = row1; i < row2; i++) {
                res = Math.min(res, dp(row1, col1, i, col2) + dp(i + 1, col1, row2, col2) + horizontalCut[i]);
            }
            for (int i = col1; i < col2; i++) {
                res = Math.min(res, dp(row1, col1, row2, i) + dp(row1, i + 1, row2, col2) + verticalCut[i]);
            }
            memo[row1][col1][row2][col2] = res;
        }
        return memo[row1][col1][row2][col2];
    }
}
```

```CSharp
public class Solution {
    int[][][][] memo;
    int[] horizontalCut;
    int[] verticalCut;

    public int MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut) {
        this.memo = new int[m][][][];
        this.horizontalCut = horizontalCut;
        this.verticalCut = verticalCut;
        for (int i = 0; i < m; i++) {
            memo[i] = new int[n][][];
            for (int j = 0; j < n; j++) {
                memo[i][j] = new int[m][];
                for (int k = 0; k < m; k++) {
                    memo[i][j][k] = new int[n];
                    Array.Fill(memo[i][j][k], -1);
                }
            }
        }
        return DP(0, 0, m - 1, n - 1);
    }

    public int DP(int row1, int col1, int row2, int col2) {
        if (row1 == row2 && col1 == col2) {
            return 0;
        }
        if (memo[row1][col1][row2][col2] < 0) {
            int res = int.MaxValue;
            for (int i = row1; i < row2; i++) {
                res = Math.Min(res, DP(row1, col1, i, col2) + DP(i + 1, col1, row2, col2) + horizontalCut[i]);
            }
            for (int i = col1; i < col2; i++) {
                res = Math.Min(res, DP(row1, col1, row2, i) + DP(row1, i + 1, row2, col2) + verticalCut[i]);
            }
            memo[row1][col1][row2][col2] = res;
        }
        return memo[row1][col1][row2][col2];
    }
}
```

```JavaScript
var minimumCost = function(m, n, horizontalCut, verticalCut) {
    const memo = new Array(m * m * n * n).fill(-1);
    const index = (row1, col1, row2, col2) => {
        return (row1 * n + col1) * m * n + row2 * n + col2;
    };

    const dp = (row1, col1, row2, col2) => {
        if (row1 === row2 && col1 === col2) {
            return 0;
        }
        const ind = index(row1, col1, row2, col2);
        if (memo[ind] >= 0) {
            return memo[ind];
        }

        memo[ind] = Number.MAX_SAFE_INTEGER;
        for (let i = row1; i < row2; i++) {
            memo[ind] = Math.min(memo[ind], dp(row1, col1, i, col2) + dp(i + 1, col1, row2, col2) + horizontalCut[i]);
        }
        for (let i = col1; i < col2; i++) {
            memo[ind] = Math.min(memo[ind], dp(row1, col1, row2, i) + dp(row1, i + 1, row2, col2) + verticalCut[i]);
        }
        return memo[ind];
    };

    return dp(0, 0, m - 1, n - 1);
};
```

```TypeScript
function minimumCost(m: number, n: number, horizontalCut: number[], verticalCut: number[]): number {
    const memo: number[] = new Array(m * m * n * n).fill(-1);
    const index = (row1: number, col1: number, row2: number, col2: number): number => {
        return (row1 * n + col1) * m * n + row2 * n + col2;
    };
    const dp = (row1: number, col1: number, row2: number, col2: number): number => {
        if (row1 === row2 && col1 === col2) {
            return 0;
        }
        const ind = index(row1, col1, row2, col2);
        if (memo[ind] >= 0) {
            return memo[ind];
        }
        memo[ind] = Number.MAX_SAFE_INTEGER;
        for (let i = row1; i < row2; i++) {
            memo[ind] = Math.min(memo[ind], dp(row1, col1, i, col2) + dp(i + 1, col1, row2, col2) + horizontalCut[i]);
        }
        for (let i = col1; i < col2; i++) {
            memo[ind] = Math.min(memo[ind], dp(row1, col1, row2, i) + dp(row1, i + 1, row2, col2) + verticalCut[i]);
        }
        return memo[ind];
    };

    return dp(0, 0, m - 1, n - 1);
};
```

```Rust
impl Solution {
    pub fn minimum_cost(m: i32, n: i32, horizontal_cut: Vec<i32>, vertical_cut: Vec<i32>) -> i32 {
        let mut memo = vec![-1; (m * m * n * n) as usize];

        fn dp(
            row1: i32,
            col1: i32,
            row2: i32,
            col2: i32,
            m: i32,
            n: i32,
            horizontal_cut: &Vec<i32>,
            vertical_cut: &Vec<i32>,
            memo: &mut Vec<i32>
        ) -> i32 {
            let index = |row1: i32, col1: i32, row2: i32, col2: i32| -> usize {
                ((row1 * n + col1) * m * n + row2 * n + col2) as usize
            };
            if row1 == row2 && col1 == col2 {
                return 0;
            }
            let ind = index(row1, col1, row2, col2);
            if memo[ind] >= 0 {
                return memo[ind];
            }
            memo[ind] = i32::MAX;
            for i in row1..row2 {
                memo[ind] = memo[ind].min(dp(row1, col1, i, col2, m, n, horizontal_cut, vertical_cut, memo)
                    + dp(i + 1, col1, row2, col2, m, n, horizontal_cut, vertical_cut, memo)
                    + horizontal_cut[i as usize]);
            }
            for i in col1..col2 {
                memo[ind] = memo[ind].min(dp(row1, col1, row2, i, m, n, horizontal_cut, vertical_cut, memo)
                    + dp(row1, i + 1, row2, col2, m, n, horizontal_cut, vertical_cut, memo)
                    + vertical_cut[i as usize]);
            }
            memo[ind]
        }

        dp(0, 0, m - 1, n - 1, m, n, &horizontal_cut, &vertical_cut, &mut memo)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m^2 \times n^2 \times (m+n))$，一共有 $O(m^2 \times n^2)$ 个状态，每个状态消耗 $O(m+n)$ 的时间计算。
- 空间复杂度：$O(m^2 \times n^2)$。
