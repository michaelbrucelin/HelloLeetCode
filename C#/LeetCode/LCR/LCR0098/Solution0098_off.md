### [路径的数目](https://leetcode.cn/problems/2AoeFn/solutions/1398902/lu-jing-de-shu-mu-by-leetcode-solution-ozcc/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：动态规划

**思路与算法**

我们用 $f(i,j)$ 表示从左上角走到 $(i,j)$ 的路径数量，其中 $i$ 和 $j$ 的范围分别是 $[0,m)$ 和 $[0,n)$。

由于我们每一步只能从向下或者向右移动一步，因此要想走到 $(i,j)$，如果向下走一步，那么会从 $(i-1,j)$ 走过来；如果向右走一步，那么会从 $(i,j-1)$ 走过来。因此我们可以写出动态规划转移方程：

$$f(i,j)=f(i-1,j)+f(i,j-1)$$

需要注意的是，如果 $i=0$，那么 $f(i-1,j)$ 并不是一个满足要求的状态，我们需要忽略这一项；同理，如果 $j=0$，那么 $f(i,j-1)$ 并不是一个满足要求的状态，我们需要忽略这一项。

初始条件为 $f(0,0)=1$，即从左上角走到左上角有一种方法。

最终的答案即为 $f(m-1,n-1)$。

**细节**

为了方便代码编写，我们可以将所有的 $f(0,j)$ 以及 $f(i,0)$ 都设置为边界条件，它们的值均为 $1$。

**代码**

```C++
class Solution {
public:
    int uniquePaths(int m, int n) {
        vector<vector<int>> f(m, vector<int>(n));
        for (int i = 0; i < m; ++i) {
            f[i][0] = 1;
        }
        for (int j = 0; j < n; ++j) {
            f[0][j] = 1;
        }
        for (int i = 1; i < m; ++i) {
            for (int j = 1; j < n; ++j) {
                f[i][j] = f[i - 1][j] + f[i][j - 1];
            }
        }
        return f[m - 1][n - 1];
    }
};
```

```Java
class Solution {
    public int uniquePaths(int m, int n) {
        int[][] f = new int[m][n];
        for (int i = 0; i < m; ++i) {
            f[i][0] = 1;
        }
        for (int j = 0; j < n; ++j) {
            f[0][j] = 1;
        }
        for (int i = 1; i < m; ++i) {
            for (int j = 1; j < n; ++j) {
                f[i][j] = f[i - 1][j] + f[i][j - 1];
            }
        }
        return f[m - 1][n - 1];
    }
}
```

```Python
class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        f = [[1] * n] + [[1] + [0] * (n - 1) for _ in range(m - 1)]
        print(f)
        for i in range(1, m):
            for j in range(1, n):
                f[i][j] = f[i - 1][j] + f[i][j - 1]
        return f[m - 1][n - 1]
```

```Go
func uniquePaths(m, n int) int {
    dp := make([][]int, m)
    for i := range dp {
        dp[i] = make([]int, n)
        dp[i][0] = 1
    }
    for j := 0; j < n; j++ {
        dp[0][j] = 1
    }
    for i := 1; i < m; i++ {
        for j := 1; j < n; j++ {
            dp[i][j] = dp[i-1][j] + dp[i][j-1]
        }
    }
    return dp[m-1][n-1]
}
```

```C
int uniquePaths(int m, int n) {
    int f[m][n];
    for (int i = 0; i < m; ++i) {
        f[i][0] = 1;
    }
    for (int j = 0; j < n; ++j) {
        f[0][j] = 1;
    }
    for (int i = 1; i < m; ++i) {
        for (int j = 1; j < n; ++j) {
            f[i][j] = f[i - 1][j] + f[i][j - 1];
        }
    }
    return f[m - 1][n - 1];
}
```

```JavaScript
var uniquePaths = function(m, n) {
    const f = new Array(m).fill(0).map(() => new Array(n).fill(0));
    for (let i = 0; i < m; i++) {
        f[i][0] = 1;
    }
    for (let j = 0; j < n; j++) {
        f[0][j] = 1;
    }
    for (let i = 1; i < m; i++) {
        for (let j = 1; j < n; j++) {
            f[i][j] = f[i - 1][j] + f[i][j - 1];
        }
    }
    return f[m - 1][n - 1];
};
```

**复杂度分析**

- 时间复杂度：$O(mn)$。
- 空间复杂度：$O(mn)$，即为存储所有状态需要的空间。注意到 $f(i,j)$ 仅与第 $i$ 行和第 $i-1$ 行的状态有关，因此我们可以使用滚动数组代替代码中的二维数组，使空间复杂度降低为 $O(n)$。此外，由于我们交换行列的值并不会对答案产生影响，因此我们总可以通过交换 $m$ 和 $n$ 使得 $m\le n$，这样空间复杂度降低至 $O(min(m,n))$。

#### 方法二：组合数学

**思路与算法**

从左上角到右下角的过程中，我们需要移动 $m+n-2$ 次，其中有 $m-1$ 次向下移动，$n-1$ 次向右移动。因此路径的总数，就等于从 $m+n-2$ 次移动中选择 $m-1$ 次向下移动的方案数，即组合数：

$${\Large C}_{m+n-2}^{m-1}=\binom{m+n-2}{m-1}=\dfrac{(m+n-2)(m+n-3)\dots n}{(m-1)!}=\dfrac{(m+n-2)!}{(m-1)!(n-1)!}$$

因此我们直接计算出这个组合数即可。计算的方法有很多种：

- 如果使用的语言有组合数计算的 $API$，我们可以调用 $API$ 计算；
- 如果没有相应的 $API$，我们可以使用 $\dfrac{(m+n-2)(m+n-3)\dots n}{(m-1)!}$ 进行计算。

**代码**

```C++
class Solution {
public:
    int uniquePaths(int m, int n) {
        long long ans = 1;
        for (int x = n, y = 1; y < m; ++x, ++y) {
            ans = ans * x / y;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int uniquePaths(int m, int n) {
        long ans = 1;
        for (int x = n, y = 1; y < m; ++x, ++y) {
            ans = ans * x / y;
        }
        return (int) ans;
    }
}
```

```Python
class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        return comb(m + n - 2, n - 1)
```

```Go
func uniquePaths(m, n int) int {
    return int(new(big.Int).Binomial(int64(m+n-2), int64(n-1)).Int64())
}
```

```C
int uniquePaths(int m, int n) {
    long long ans = 1;
    for (int x = n, y = 1; y < m; ++x, ++y) {
        ans = ans * x / y;
    }
    return ans;
}
```

```JavaScript
var uniquePaths = function(m, n) {
    let ans = 1;
    for (let x = n, y = 1; y < m; ++x, ++y) {
        ans = Math.floor(ans * x / y);
    }
    return ans;
};
```

**复杂度分析**

- 时间复杂度：$O(m)$。由于我们交换行列的值并不会对答案产生影响，因此我们总可以通过交换 $m$ 和 $n$ 使得 $m\le n$，这样空间复杂度降低至 $O(min(m,n))$。
- 空间复杂度：$O(1)$。
