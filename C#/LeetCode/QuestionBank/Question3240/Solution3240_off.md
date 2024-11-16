### [最少翻转次数使二进制矩阵回文 II](https://leetcode.cn/problems/minimum-number-of-flips-to-make-binary-grid-palindromic-ii/solutions/2981502/zui-shao-fan-zhuan-ci-shu-shi-er-jin-zhi-hslz/)

#### 方法一：分类讨论

**思路**

题目要求所有行列都必须是回文的，即满足

$$grid[i][j]=grid[i][n-1-j]=grid[m-1-i][j]=grid[m-1-i][n-1-j]$$

其中，$i$ 和 $j$ 满足 $0 \le i \le \lfloor\dfrac{m}{2}​\rfloor$，$0 \le j \le \lfloor\dfrac{n}{2}​\rfloor$。

将这四个数都变为 $0$ 需要的次数记作 $cnt$ 次，那么将它们都变为 $1$ 则需要 $4-cnt$ 次。将这四个数变为相同所需要的次数就是 $min(cnt,4-cnt)$ 次。当 $m$，$n$ 都为偶数时，答案就是所有将四个数变为相同数字所需次数之和。

接下来讨论 $m$ 或 $n$ 为奇数时的情况。当 $m$ 是奇数，矩阵正中间会多出一行；当 $n$ 为奇数，矩阵正中间会多出一列。

当 $m$ 和 $n$ 都为奇数时，由于矩阵中 $1$ 的数目可以被 $4$ 整除，所以正中间的元素必须是 $0$。

当只有行数 $n$ 为奇数时，需要满足对称性 $grid[i][j]=grid[i][m-1-j]$。除为了满足对称性所需要的操作次数外，我们可能还需要额外的操作来使该行中 $1$ 的个数为 $4$ 的整数倍。

将对称位置相同的 $1$ 的个数记为 $cnt_1$​，对称位置的数不同的数对个数记作 $diff$。

- 当 $cnt_1$​ 模 $4$ 为 $0$ 时，无需额外操作。
- 当 $cnt_1$​ 模 $4$ 为 $2$ 时：
  - 如果 $diff>0$，可以将其中一对数变为 $1$，其余数都变成 $0$，这样 $cnt_1$​ 的数量就会增加 $2$，成为 $4$ 的倍数。
  - 如果 $diff=0$，可以把 $cnt_1$​ 中的一对 $1$ 变成 $0$，花费两次操作。

对于列数 $m$ 为奇数时的讨论结果类似。

**代码**

```C++
class Solution {
public:
    int minFlips(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size(), ans = 0;
        for (int i = 0; i < m / 2; i++) {
            for (int j = 0; j < n / 2; j++) {
                int cnt1 = grid[i][j] + grid[i][n - 1 - j] +
                           grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j];
                ans += min(cnt1, 4 - cnt1);
            }
        }

        int diff = 0, cnt1 = 0;
        if (m & 1) {
            for (int j = 0; j < n / 2; j++) {
                if (grid[m / 2][j] ^ grid[m / 2][n - 1 - j]) {
                    diff++;
                } else {
                    cnt1 += grid[m / 2][j] * 2;
                }
            }
        }
        if (n & 1) {
            for (int i = 0; i < m / 2; i++) {
                if (grid[i][n / 2] ^ grid[m - 1 - i][n / 2]) {
                    diff++;
                } else {
                    cnt1 += grid[i][n / 2] * 2;
                }
            }
        }
        if (m & 1 && n & 1) {
            ans += grid[m / 2][n / 2];
        }
        if (diff > 0) {
            ans += diff;
        } else {
            ans += cnt1 % 4;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int minFlips(int[][] grid) {
        int m = grid.length, n = grid[0].length, ans = 0;
        for (int i = 0; i < m / 2; i++) {
            for (int j = 0; j < n / 2; j++) {
                int cnt1 = grid[i][j] + grid[i][n - 1 - j] +
                           grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j];
                ans += Math.min(cnt1, 4 - cnt1);
            }
        }
        int diff = 0, cnt1 = 0;
        if (m % 2 == 1) {
            for (int j = 0; j < n / 2; j++) {
                if ((grid[m / 2][j] ^ grid[m / 2][n - 1 - j]) != 0) {
                    diff++;
                } else {
                    cnt1 += grid[m / 2][j] * 2;
                }
            }
        }
        if (n % 2 == 1) {
            for (int i = 0; i < m / 2; i++) {
                if ((grid[i][n / 2] ^ grid[m - 1 - i][n / 2]) != 0) {
                    diff++;
                } else {
                    cnt1 += grid[i][n / 2] * 2;
                }
            }
        }
        if (m % 2 == 1 && n % 2 == 1) {
            ans += grid[m / 2][n / 2];
        }
        if (diff > 0) {
            ans += diff;
        } else {
            ans += cnt1 % 4;
        }
        return ans;   
    }
}

```

```CSharp
public class Solution {
    public int MinFlips(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, ans = 0;
        int cnt1 = 0;
        for (int i = 0; i < m / 2; i++) {
            for (int j = 0; j < n / 2; j++) {
                cnt1 = grid[i][j] + grid[i][n - 1 - j] + 
                           grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j];
                ans += Math.Min(cnt1, 4 - cnt1);
            }
        }

        int diff = 0;
        cnt1 = 0;
        if (m % 2 == 1) {
            for (int j = 0; j < n / 2; j++) {
                if ((grid[m / 2][j] ^ grid[m / 2][n - 1 - j]) != 0) {
                    diff++;
                } else {
                    cnt1 += grid[m / 2][j] * 2;
                }
            }
        }
        if (n % 2 == 1) {
            for (int i = 0; i < m / 2; i++) {
                if ((grid[i][n / 2] ^ grid[m - 1 - i][n / 2]) != 0) {
                    diff++;
                } else {
                    cnt1 += grid[i][n / 2] * 2;
                }
            }
        }
        if (m % 2 == 1 && n % 2 == 1) {
            ans += grid[m / 2][n / 2];
        }
        if (diff > 0) {
            ans += diff;
        } else {
            ans += cnt1 % 4;
        }
        return ans;
    }
}
```

```Python
class Solution:
    def minFlips(self, grid: List[List[int]]) -> int:
        m, n, ans = len(grid), len(grid[0]), 0
        for i in range(m // 2):
            for j in range(n // 2):
                cnt1 = grid[i][j] + grid[i][n - 1 - j] + \
                       grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j]
                ans += min(cnt1, 4 - cnt1)

        diff, cnt1 = 0, 0
        if m % 2 == 1:
            for j in range(n // 2):
                if grid[m // 2][j] ^ grid[m // 2][n - 1 - j]:
                    diff += 1
                else:
                    cnt1 += grid[m // 2][j] * 2
        if n % 2 == 1:
            for i in range(m // 2):
                if grid[i][n // 2] ^ grid[m - 1 - i][n // 2]:
                    diff += 1
                else:
                    cnt1 += grid[i][n // 2] * 2
        if m % 2 == 1 and n % 2 == 1:
            ans += grid[m // 2][n // 2]
        if diff > 0:
            ans += diff
        else:
            ans += cnt1 % 4
        return ans
```

```Go
func minFlips(grid [][]int) int {
    m, n, ans := len(grid), len(grid[0]), 0
    for i := 0; i < m / 2; i++ {
        for j := 0; j < n / 2; j++ {
            cnt1 := grid[i][j] + grid[i][n - 1 - j] +
                    grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j]
            ans += min(cnt1, 4 - cnt1)
        }
    }

    diff, cnt1 := 0, 0
    if m % 2 == 1 {
        for j := 0; j < n / 2; j++ {
            if grid[m / 2][j] ^ grid[m / 2][n - 1 - j] != 0 {
                diff++
            } else {
                cnt1 += grid[m / 2][j] * 2
            }
        }
    }
    if n % 2 == 1 {
        for i := 0; i < m / 2; i++ {
            if grid[i][n / 2] ^ grid[m - 1 - i][n / 2] != 0 {
                diff++
            } else {
                cnt1 += grid[i][n / 2] * 2
            }
        }
    }
    if m % 2 == 1 && n % 2 == 1 {
        ans += grid[m / 2][n / 2]
    }
    if diff > 0 {
        ans += diff
    } else {
        ans += cnt1 % 4
    }
    return ans
}
```

```C
int minFlips(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize;
    int n = gridColSize[0];
    int ans = 0;
    for (int i = 0; i < m / 2; i++) {
        for (int j = 0; j < n / 2; j++) {
            int cnt1 = grid[i][j] + grid[i][n - 1 - j] +
                       grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j];
            ans += fmin(cnt1, 4 - cnt1);
        }
    }

    int diff = 0, cnt1 = 0;
    if (m % 2 == 1) {
        for (int j = 0; j < n / 2; j++) {
            if (grid[m / 2][j] ^ grid[m / 2][n - 1 - j]) {
                diff++;
            } else {
                cnt1 += grid[m / 2][j] * 2;
            }
        }
    }
    if (n % 2 == 1) {
        for (int i = 0; i < m / 2; i++) {
            if (grid[i][n / 2] ^ grid[m - 1 - i][n / 2]) {
                diff++;
            } else {
                cnt1 += grid[i][n / 2] * 2;
            }
        }
    }
    if (m % 2 == 1 && n % 2 == 1) {
        ans += grid[m / 2][n / 2];
    }
    if (diff > 0) {
        ans += diff;
    } else {
        ans += cnt1 % 4;
    }
    return ans;
}
```

```JavaScript
var minFlips = function(grid) {
    const m = grid.length, n = grid[0].length;
    let ans = 0;
    for (let i = 0; i < Math.floor(m / 2); i++) {
        for (let j = 0; j < Math.floor(n / 2); j++) {
            const cnt1 = grid[i][j] + grid[i][n - 1 - j] +
                         grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j];
            ans += Math.min(cnt1, 4 - cnt1);
        }
    }
    let diff = 0, cnt1 = 0;
    if (m % 2 === 1) {
        for (let j = 0; j < Math.floor(n / 2); j++) {
            if (grid[Math.floor(m / 2)][j] ^ grid[Math.floor(m / 2)][n - 1 - j]) {
                diff++;
            } else {
                cnt1 += grid[Math.floor(m / 2)][j] * 2;
            }
        }
    }
    if (n % 2 === 1) {
        for (let i = 0; i < Math.floor(m / 2); i++) {
            if (grid[i][Math.floor(n / 2)] ^ grid[m - 1 - i][Math.floor(n / 2)]) {
                diff++;
            } else {
                cnt1 += grid[i][Math.floor(n / 2)] * 2;
            }
        }
    }
    if (m % 2 === 1 && n % 2 === 1) {
        ans += grid[Math.floor(m / 2)][Math.floor(n / 2)];
    }
    if (diff > 0) {
        ans += diff;
    } else {
        ans += cnt1 % 4;
    }
    return ans;
};
```

```TypeScript
function minFlips(grid: number[][]): number {
    const m = grid.length, n = grid[0].length;
    let ans = 0;
    for (let i = 0; i < Math.floor(m / 2); i++) {
        for (let j = 0; j < Math.floor(n / 2); j++) {
            const cnt1 = grid[i][j] + grid[i][n - 1 - j] +
                         grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j];
            ans += Math.min(cnt1, 4 - cnt1);
        }
    }
    let diff = 0, cnt1 = 0;
    if (m % 2 === 1) {
        for (let j = 0; j < Math.floor(n / 2); j++) {
            if (grid[Math.floor(m / 2)][j] ^ grid[Math.floor(m / 2)][n - 1 - j]) {
                diff++;
            } else {
                cnt1 += grid[Math.floor(m / 2)][j] * 2;
            }
        }
    }
    if (n % 2 === 1) {
        for (let i = 0; i < Math.floor(m / 2); i++) {
            if (grid[i][Math.floor(n / 2)] ^ grid[m - 1 - i][Math.floor(n / 2)]) {
                diff++;
            } else {
                cnt1 += grid[i][Math.floor(n / 2)] * 2;
            }
        }
    }
    if (m % 2 === 1 && n % 2 === 1) {
        ans += grid[Math.floor(m / 2)][Math.floor(n / 2)];
    }
    if (diff > 0) {
        ans += diff;
    } else {
        ans += cnt1 % 4;
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn min_flips(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        let mut ans = 0;
        for i in 0..m / 2 {
            for j in 0..n / 2 {
                let cnt1 = grid[i][j] + grid[i][n - 1 - j] +
                           grid[m - 1 - i][j] + grid[m - 1 - i][n - 1 - j];
                ans += cnt1.min(4 - cnt1);
            }
        }
        let mut diff = 0;
        let mut cnt1 = 0;
        if m % 2 == 1 {
            for j in 0..n / 2 {
                if grid[m / 2][j] ^ grid[m / 2][n - 1 - j] != 0 {
                    diff += 1;
                } else {
                    cnt1 += grid[m / 2][j] * 2;
                }
            }
        }
        if n % 2 == 1 {
            for i in 0..m / 2 {
                if grid[i][n / 2] ^ grid[m - 1 - i][n / 2] != 0 {
                    diff += 1;
                } else {
                    cnt1 += grid[i][n / 2] * 2;
                }
            }
        }
        if m % 2 == 1 && n % 2 == 1 {
            ans += grid[m / 2][n / 2];
        }
        if diff > 0 {
            ans += diff;
        } else {
            ans += cnt1 % 4;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，需要遍历一遍矩阵。
- 空间复杂度：$O(1)$。

#### 方法二：动态规划

**思路**

将矩阵中对称的元素分组，每一组都必须相等。（当行数或列数为奇数时，不一定每一组都有 $4$ 个元素）要么都为 $1$，要么都为 $0$。要使整个矩阵的 $1$ 的数量模 $4$ 等于 $0$，就是让每一组的 $1$ 的个数的总和等于 $4$ 的倍数。

定义 $f[i][j]$ 表示在前 $i$ 组中，$1$ 的数量模 $4$ 的余数为 $j$ 时的最小操作数。那么对于第 $i+1$ 组：

- 将这一组全都变为 $0$，那么余数不变，有 $f[i+1][j]=f[i][j]$。
- 将这一组全都变为 $1$，设组内有 $cnt$ 个元素，那么有 $f[i+1][(j+cnt)\%4]=f[i][j]$。

设总分组的数量为 $group$，$f[group][0]$ 即所求答案。

**代码**

```C++
class Solution {
public:
    int minFlips(vector<vector<int>>& grid) {
        int m = grid.size(), n = grid[0].size();
        vector<int> f(4, INT_MAX / 2);
        f[0] = 0;
        for (int i = 0; i < (m + 1) / 2; i++) {
            for (int j = 0; j < (n + 1) / 2; j++) {
                int ones = grid[i][j], cnt = 1;
                if (j != n - 1 - j) {
                    ones += grid[i][n - 1 - j];
                    cnt++;
                }
                if (i != m - 1 - i) {
                    ones += grid[m - 1 - i][j];
                    cnt++;
                }
                if (i != m - 1 - i && j != n - 1 - j) {
                    ones += grid[m - 1 - i][n - 1 - j];
                    cnt++;
                }
                // 将这一组全部变成 1 的代价
                int cnt1 = cnt - ones;
                // 将这一组全部变成 0 的代价
                int cnt0 = ones;
                vector<int> tmp(4);
                for (int k = 0; k < 4; k++) {
                    tmp[k] = f[k] + cnt0;
                }
                for (int k = 0; k < 4; k++) {
                    tmp[(k + cnt) % 4] = min(tmp[(k + cnt) % 4], f[k] + cnt1);
                }
                swap(f, tmp);
            }
        }
        return f[0];
    }
};
```

```Java
class Solution {
    public int minFlips(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[] f = new int[4];
        Arrays.fill(f, Integer.MAX_VALUE / 2); 
        f[0] = 0;

        for (int i = 0; i < (m + 1) / 2; i++) {
            for (int j = 0; j < (n + 1) / 2; j++) {
                int ones = grid[i][j], cnt = 1;
                if (j != n - 1 - j) {
                    ones += grid[i][n - 1 - j];
                    cnt++;
                }
                if (i != m - 1 - i) {
                    ones += grid[m - 1 - i][j];
                    cnt++;
                }
                if (i != m - 1 - i && j != n - 1 - j) {
                    ones += grid[m - 1 - i][n - 1 - j];
                    cnt++;
                }
                // 计算将这一组全部变为 1 的代价
                int cnt1 = cnt - ones;
                // 计算将这一组全部变为 0 的代价
                int cnt0 = ones;
                int[] tmp = new int[4];
                for (int k = 0; k < 4; k++) {
                    tmp[k] = f[k] + cnt0;
                }
                for (int k = 0; k < 4; k++) {
                    tmp[(k + cnt) % 4] = Math.min(tmp[(k + cnt) % 4], f[k] + cnt1);
                }
                f = tmp;
            }
        }
        return f[0];
    }
}
```

```CSharp
public class Solution {
    public int MinFlips(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[] f = new int[4];
        Array.Fill(f, int.MaxValue / 2);
        f[0] = 0;
        for (int i = 0; i < (m + 1) / 2; i++) {
            for (int j = 0; j < (n + 1) / 2; j++) {
                int ones = grid[i][j], cnt = 1;
                if (j != n - 1 - j) {
                    ones += grid[i][n - 1 - j];
                    cnt++;
                }
                if (i != m - 1 - i) {
                    ones += grid[m - 1 - i][j];
                    cnt++;
                }
                if (i != m - 1 - i && j != n - 1 - j) {
                    ones += grid[m - 1 - i][n - 1 - j];
                    cnt++;
                }
                // 计算将这一组全部变为 1 的代价
                int cnt1 = cnt - ones;
                // 计算将这一组全部变为 0 的代价
                int cnt0 = ones;
                int[] tmp = new int[4];
                for (int k = 0; k < 4; k++) {
                    tmp[k] = f[k] + cnt0;
                }
                for (int k = 0; k < 4; k++) {
                    tmp[(k + cnt) % 4] = Math.Min(tmp[(k + cnt) % 4], f[k] + cnt1);
                }
                f = tmp;
            }
        }
        return f[0];
    }
}
```

```Python
class Solution:
    def minFlips(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        f = [float('inf')] * 4
        f[0] = 0
        for i in range((m + 1) // 2):
            for j in range((n + 1) // 2):
                ones = grid[i][j]
                cnt = 1
                if j != n - 1 - j:
                    ones += grid[i][n - 1 - j]
                    cnt += 1
                if i != m - 1 - i:
                    ones += grid[m - 1 - i][j]
                    cnt += 1
                if i != m - 1 - i and j != n - 1 - j:
                    ones += grid[m - 1 - i][n - 1 - j]
                    cnt += 1
                # 计算将这一组全部变为 1 的代价
                cnt1 = cnt - ones
                # 计算将这一组全部变为 0 的代价
                cnt0 = ones
                tmp = [0] * 4
                for k in range(4):
                    tmp[k] = f[k] + cnt0
                for k in range(4):
                    tmp[(k + cnt) % 4] = min(tmp[(k + cnt) % 4], f[k] + cnt1)
                f = tmp
        return f[0]
```

```Go
func minFlips(grid [][]int) int {
    m, n := len(grid), len(grid[0])
    f := make([]int, 4)
    for i := range f {
        f[i] = math.MaxInt32 / 2
    }
    f[0] = 0
    for i := 0; i < (m + 1) / 2; i++ {
        for j := 0; j < (n + 1) / 2; j++ {
            ones := grid[i][j]
            cnt := 1
            if j != n - 1 - j {
                ones += grid[i][n - 1 - j]
                cnt++
            }
            if i != m - 1 - i {
                ones += grid[m - 1 - i][j]
                cnt++
            }
            if i != m - 1 - i && j != n - 1 - j {
                ones += grid[m - 1 - i][n - 1 - j]
                cnt++
            }
            // 计算将这一组全部变为 1 的代价
            cnt1 := cnt - ones
            // 计算将这一组全部变为 0 的代价
            cnt0 := ones
            tmp := make([]int, 4)
            for k := 0; k < 4; k++ {
                tmp[k] = f[k] + cnt0
            }
            for k := 0; k < 4; k++ {
                tmp[(k + cnt) % 4] = min(tmp[(k + cnt) % 4], f[k] + cnt1)
            }
            f = tmp
        }
    }
    return f[0]
}
```

```C
int minFlips(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize, n = gridColSize[0];
    int f[4];
    for (int i = 0; i < 4; i++) {
        f[i] = INT_MAX / 2;
    }
    f[0] = 0;
    for (int i = 0; i < (m + 1) / 2; i++) {
        for (int j = 0; j < (n + 1) / 2; j++) {
            int ones = grid[i][j], cnt = 1;
            if (j != n - 1 - j) {
                ones += grid[i][n - 1 - j];
                cnt++;
            }
            if (i != m - 1 - i) {
                ones += grid[m - 1 - i][j];
                cnt++;
            }
            if (i != m - 1 - i && j != n - 1 - j) {
                ones += grid[m - 1 - i][n - 1 - j];
                cnt++;
            }
            // 计算将这一组全部变为 1 的代价
            int cnt1 = cnt - ones;
            // 计算将这一组全部变为 0 的代价
            int cnt0 = ones;
            int tmp[4];
            for (int k = 0; k < 4; k++) {
                tmp[k] = f[k] + cnt0;
            }
            for (int k = 0; k < 4; k++) {
                tmp[(k + cnt) % 4] = fmin(tmp[(k + cnt) % 4], f[k] + cnt1);
            }
            for (int k = 0; k < 4; k++) {
                f[k] = tmp[k]; 
            }
        }
    }
    return f[0]; 
}
```

```JavaScript
var minFlips = function(grid) {
    const m = grid.length, n = grid[0].length;
    let f = new Array(4).fill(Infinity);
    f[0] = 0;
    for (let i = 0; i < Math.floor((n + 1) / 2); i++) {
        for (let j = 0; j < Math.floor((m + 1) / 2); j++) {
            let ones = grid[i][j];
            let cnt = 1;
            if (j !== n - 1 - j) {
                ones += grid[i][n - 1 - j];
                cnt++;
            }
            if (i !== m - 1 - i) {
                ones += grid[m - 1 - i][j];
                cnt++;
            }
            if (i !== m - 1 - i && j !== n - 1 - j) {
                ones += grid[m - 1 - i][n - 1 - j];
                cnt++;
            }
            // 计算将这一组全部变为 1 的代价
            const cnt1 = cnt - ones;
            // 计算将这一组全部变为 0 的代价
            const cnt0 = ones;
            let tmp = new Array(4).fill(0);
            for (let k = 0; k < 4; k++) {
                tmp[k] = f[k] + cnt0;
            }
            for (let k = 0; k < 4; k++) {
                tmp[(k + cnt) % 4] = Math.min(tmp[(k + cnt) % 4], f[k] + cnt1);
            }
            f = tmp;
        }
    }
    return f[0];
};
```

```TypeScript
function minFlips(grid: number[][]): number {
    const m = grid.length, n = grid[0].length;
    let f: number[] = new Array(4).fill(Infinity);
    f[0] = 0;
    for (let i = 0; i < Math.floor((m + 1) / 2); i++) {
        for (let j = 0; j < Math.floor((n + 1) / 2); j++) {
            let ones = grid[i][j];
            let cnt = 1;
            if (j !== n - 1 - j) {
                ones += grid[i][n - 1 - j];
                cnt++;
            }
            if (i !== m - 1 - i) {
                ones += grid[m - 1 - i][j];
                cnt++;
            }
            if (i !== m - 1 - i && j !== n - 1 - j) {
                ones += grid[m - 1 - i][n - 1 - j];
                cnt++;
            }
            // 计算将这一组全部变为 1 的代价
            const cnt1 = cnt - ones;
            // 计算将这一组全部变为 0 的代价
            const cnt0 = ones;
            let tmp: number[] = new Array(4).fill(0);
            for (let k = 0; k < 4; k++) {
                tmp[k] = f[k] + cnt0;
            }
            for (let k = 0; k < 4; k++) {
                tmp[(k + cnt) % 4] = Math.min(tmp[(k + cnt) % 4], f[k] + cnt1);
            }
            f = tmp;
        }
    }
    return f[0];
};
```

```Rust
impl Solution {
    pub fn min_flips(grid: Vec<Vec<i32>>) -> i32 {
        let m = grid.len();
        let n = grid[0].len();
        let mut f = vec![i32::MAX / 2; 4];
        f[0] = 0;
        for i in 0..(m + 1) / 2 {
            for j in 0..(n + 1) / 2 {
                let mut ones = grid[i][j];
                let mut cnt = 1;
                if j != n - 1 - j {
                    ones += grid[i][n - 1 - j];
                    cnt += 1;
                }
                if i != m - 1 - i {
                    ones += grid[m - 1 - i][j];
                    cnt += 1;
                }
                if i != m - 1 - i && j != n - 1 - j {
                    ones += grid[m - 1 - i][n - 1 - j];
                    cnt += 1;
                }
                // 计算将这一组全部变为 1 的代价
                let cnt1 = cnt - ones;
                // 计算将这一组全部变为 0 的代价
                let cnt0 = ones;
                let mut tmp = vec![0; 4];
                for k in 0..4 {
                    tmp[k] = f[k] + cnt0;
                }
                for k in 0..4 {
                    tmp[(k + cnt) as usize % 4] = tmp[(k + cnt) as usize % 4].min(f[k as usize] + cnt1);
                }
                f = tmp;
            }
        }
        f[0]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，需要遍历与矩阵数量相同的次数。
- 空间复杂度：$O(1)$，使用滚动数组将数组压缩为 $1$ 维。
