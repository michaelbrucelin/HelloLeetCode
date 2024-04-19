### [准时抵达会议现场的最小跳过休息次数](https://leetcode.cn/problems/minimum-skips-to-arrive-at-meeting-on-time/solutions/802990/minimum-skips-to-arrive-at-meeting-on-ti-dp7v/)

#### 方法一：动态规划

##### 思路与算法

我们用 $f[i][j]$ 表示经过了 $\textit{dist}[0]$ 到 $\textit{dist}[i-1]$ 的 $i$ 段道路，并且跳过了 $j$ 次的最短用时。

在进行状态转移时，我们考虑最后一段道路 $\textit{dist}[i-1]$ 是否选择跳过：

- 如果没有跳过，那么状态转移方程为：
    $$f[i][j] = \left\lceil f[i-1][j] + \frac{\textit{dist}[i-1]}{\textit{speed}} \right\rceil$$
    其中 ⌈x⌉\lceil x \rceil⌈x⌉ 表示将 $x$ 向上取整。对于最后一段道路，我们无需等待到下一个整数小时，但由于题目中给定的 $\textit{hoursBefore}$ 是一个整数，因此在状态转移方程中向上取整是不会影响结果的。
- 如果跳过，那么状态转移方程为：
    $$f[i][j] = f[i-1][j-1] + \frac{\textit{dist}[i-1]}{\textit{speed}}$$

由于我们到达的时间尽可能早，因此需要选择这两种转移中的较小值，即：

$$f[i][j] = \min \left\{ \left\lceil f[i-1][j] + \frac{\textit{dist}[i-1]}{\textit{speed}} \right\rceil, f[i-1][j-1] + \frac{\textit{dist}[i-1]}{\textit{speed}}\right\}$$

需要注意的是，当 $j=0$ 时，我们不能通过「跳过」进行转移；当 $j=i$ 时，我们不能通过「没有跳过」进行转移；当 $j>i$ 时，我们无法在 $i$ 段道路内跳过超过 $i$ 次，对应的状态不合法。

当我们计算完所有状态的值后，我们只需要找到最小的 $j$，使得 $f[n][j] \leq \textit{hoursBefore}$，这个 $j$ 即为最少需要跳过的次数。如果不存在这样的 $j$，那么返回 $-1$。

##### 动态规划的细节

动态规划的边界条件为 $f[0][0] = 0$，表示初始（未走过任何道路）时的时间为 $0$。

由于状态转移方程中的取值为 $\min$，因此我们可以将除了 $f[0][0]$ 以外所有的状态置为一个极大值 $\infty$，方便进行转移。

##### 浮点数运算的细节

这一部分非常重要，希望读者仔细阅读。

根据 [IEEE 754](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2FIEEE%20754) 标准，浮点数在计算机中存储的精度是有限的，而本题中我们不可避免的会使用「浮点数运算」以及「向上取整」运算，如果强行忽略产生的计算误差，会得到错误的结果。

举一个简单的例子，假设使用的语言中「向上取整」运算的函数为 $\texttt{ceil}$，下面的运算：

$$\texttt{ceil(8.0 + 1.0 / 3 + 1.0 / 3 + 1.0 / 3)}$$

应当是 $9$，而计算机会给出 $10$。这是因为浮点数误差导致：

$$\texttt{8.0 + 1.0 / 3 + 1.0 / 3 + 1.0 / 3}$$

计算出的结果约为：

$$\texttt{9.000000000000002}$$

向上取整后会得到 $10$，产生了错误的答案。

因此我们引入常量 $\text{eps}$ 表示一个极小值，例如 $10^{-8}$。在进行「向上取整」运算前，我们将待取整的浮点数减去 $\text{eps}$ 再进行取整，就可以避免上述的误差。

同时，我们需要说明 $\text{eps}$ 不会引入其它的问题。在本题中速度最大为 $10^6$，时间与速度成反比，那么 $\text{eps}$ 的粒度只需要高于时间的精度 $10^{-6}$ 即可，取 $10^{-7}$ 或 $10^{-8}$ 都是可行的。

最后在比较 $f[n][j] \leq \textit{hoursBefore}$ 时，我们也需要将左侧减去 $\text{eps}$ 或将右侧加上 $\text{eps}$，再进行比较。


##### 代码

```c++
class Solution {
private:
    // 可忽略误差
    static constexpr double EPS = 1e-7;
    // 极大值
    static constexpr double INFTY = 1e20;

public:
    int minSkips(vector<int>& dist, int speed, int hoursBefore) {
        int n = dist.size();
        vector<vector<double>> f(n + 1, vector<double>(n + 1, INFTY));
        f[0][0] = 0.;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= i; ++j) {
                if (j != i) {
                    f[i][j] = min(f[i][j], ceil(f[i - 1][j] + (double)dist[i - 1] / speed - EPS));
                }
                if (j != 0) {
                    f[i][j] = min(f[i][j], f[i - 1][j - 1] + (double)dist[i - 1] / speed);
                }
            }
        }
        for (int j = 0; j <= n; ++j) {
            if (f[n][j] < hoursBefore + EPS) {
                return j;
            }
        }
        return -1;
    }
};
```

```python
class Solution:
    def minSkips(self, dist: List[int], speed: int, hoursBefore: int) -> int:
        # 可忽略误差
        EPS = 1e-7
        
        n = len(dist)
        f = [[float("inf")] * (n + 1) for _ in range(n + 1)]
        f[0][0] = 0.
        for i in range(1, n + 1):
            for j in range(i + 1):
                if j != i:
                    f[i][j] = min(f[i][j], ceil(f[i - 1][j] + dist[i - 1] / speed - EPS))
                if j != 0:
                    f[i][j] = min(f[i][j], f[i - 1][j - 1] + dist[i - 1] / speed)
        
        for j in range(n + 1):
            if f[n][j] < hoursBefore + EPS:
                return j
        return -1
```

```java
class Solution {
    // 可忽略误差
    static final double EPS = 1e-7;
    // 极大值
    static final double INFTY = 1e20;

    public int minSkips(int[] dist, int speed, int hoursBefore) {
        int n = dist.length;
        double[][] f = new double[n + 1][n + 1];
        for (int i = 0; i <= n; ++i) {
            Arrays.fill(f[i], INFTY);
        }
        f[0][0] = 0;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= i; ++j) {
                if (j != i) {
                    f[i][j] = Math.min(f[i][j], Math.ceil(f[i - 1][j] + (double) dist[i - 1] / speed - EPS));
                }
                if (j != 0) {
                    f[i][j] = Math.min(f[i][j], f[i - 1][j - 1] + (double) dist[i - 1] / speed);
                }
            }
        }
        for (int j = 0; j <= n; ++j) {
            if (f[n][j] < hoursBefore + EPS) {
                return j;
            }
        }
        return -1;
    }
}
```

```csharp
public class Solution {
    // 可忽略误差
    const double EPS = 1e-7;
    // 极大值
    const double INFTY = 1e20;

    public int MinSkips(int[] dist, int speed, int hoursBefore) {
        int n = dist.Length;
        double[][] f = new double[n + 1][];
        for (int i = 0; i <= n; ++i) {
            f[i] = new double[n + 1];
            Array.Fill(f[i], INFTY);
        }
        f[0][0] = 0;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= i; ++j) {
                if (j != i) {
                    f[i][j] = Math.Min(f[i][j], Math.Ceiling(f[i - 1][j] + (double) dist[i - 1] / speed - EPS));
                }
                if (j != 0) {
                    f[i][j] = Math.Min(f[i][j], f[i - 1][j - 1] + (double) dist[i - 1] / speed);
                }
            }
        }
        for (int j = 0; j <= n; ++j) {
            if (f[n][j] < hoursBefore + EPS) {
                return j;
            }
        }
        return -1;
    }
}
```

```c
// 可忽略误差
const double EPS = 1e-7;
// 极大值
const double INFTY = 1e20;

int minSkips(int* dist, int distSize, int speed, int hoursBefore) {    
    int n = distSize;
    double f[n + 1][n + 1];
    for (int i = 0; i <= n; i++) {
        for (int j = 0; j <= n; j++) {
            f[i][j] = INFTY;
        }
    }
    f[0][0] = 0;
    for (int i = 1; i <= n; i++) {
        for (int j = 0; j <= i; j++) {
            if (j != i) {
                f[i][j] = fmin(f[i][j], ceil(f[i - 1][j] + (double)dist[i - 1] / speed - EPS));
            }
            if (j != 0) {
                f[i][j] = fmin(f[i][j], f[i - 1][j - 1] + (double)dist[i - 1] / speed);
            }
        }
    }
    
    for (int j = 0; j <= n; j++) {
        if (f[n][j] < hoursBefore + EPS) {
            return j;
        }
    }
    return -1;
}
```

```go
func minSkips(dist []int, speed int, hoursBefore int) int {
    // 可忽略误差
    const EPS = 1e-7

    n := len(dist)
    f := make([][]float64, n + 1)
    for i := range f {
        f[i] = make([]float64, n + 1)
        for j := range f[i] {
            f[i][j] = math.Inf(1)
        }
    }
    f[0][0] = 0.0
    for i := 1; i <= n; i++ {
        for j := 0; j <= i; j++ {
            if j != i {
                f[i][j] = math.Min(f[i][j], math.Ceil(f[i - 1][j] + float64(dist[i - 1]) / float64(speed) - EPS))
            }
            if j != 0 {
                f[i][j] = math.Min(f[i][j], f[i - 1][j - 1]+float64(dist[i - 1]) / float64(speed))
            }
        }
    }

    for j := 0; j <= n; j++ {
        if f[n][j] < float64(hoursBefore) + EPS {
            return j
        }
    }
    return -1
}
```

```javascript
var minSkips = function(dist, speed, hoursBefore) {
    // 可忽略误差
    const EPS = 1e-7;
    const n = dist.length;
    const f = new Array(n + 1).fill(0).map(() => new Array(n + 1).fill(Infinity));
    f[0][0] = 0;
    for (let i = 1; i <= n; i++) {
        for (let j = 0; j <= i; j++) {
            if (j !== i) {
                f[i][j] = Math.min(f[i][j], Math.ceil(f[i - 1][j] + dist[i - 1] / speed - EPS));
            }
            if (j !== 0) {
                f[i][j] = Math.min(f[i][j], f[i - 1][j - 1] + dist[i - 1] / speed);
            }
        }
    }

    for (let j = 0; j <= n; j++) {
        if (f[n][j] < hoursBefore + EPS) {
            return j;
        }
    }
    return -1;
};
```

```typescript
function minSkips(dist: number[], speed: number, hoursBefore: number): number {
    // 可忽略误差
    const EPS = 1e-7;
    const n = dist.length;
    const f: number[][] = new Array(n + 1).fill(0).map(() => new Array(n + 1).fill(Infinity));
    f[0][0] = 0;
    for (let i = 1; i <= n; i++) {
        for (let j = 0; j <= i; j++) {
            if (j !== i) {
                f[i][j] = Math.min(f[i][j], Math.ceil(f[i - 1][j] + dist[i - 1] / speed - EPS));
            }
            if (j !== 0) {
                f[i][j] = Math.min(f[i][j], f[i - 1][j - 1] + dist[i - 1] / speed);
            }
        }
    }

    for (let j = 0; j <= n; j++) {
        if (f[n][j] < hoursBefore + EPS) {
            return j;
        }
    }
    return -1;
};
```

```rust
use std::f64::INFINITY;

impl Solution {
    pub fn min_skips(dist: Vec<i32>, speed: i32, hours_before: i32) -> i32 {
        // 可忽略误差
        let eps = 1e-7;
        let n = dist.len();
        let mut f = vec![vec![f64::INFINITY; n + 1]; n + 1];
        f[0][0] = 0.0;
        for i in 1..= n {
            for j in 0..= i {
                if j != i {
                    f[i][j] = f[i][j].min((f[i - 1][j] + (dist[i - 1] as f64) / (speed as f64) - eps).ceil());
                }
                if j != 0 {
                    f[i][j] = f[i][j].min(f[i - 1][j - 1] + (dist[i - 1] as f64) / (speed as f64));
                }
            }
        }

        for j in 0..= n {
            if f[n][j] < (hours_before as f64) + eps {
                return j as i32;
            }
        }
        -1
    }
}
```

复杂度分析

- 时间复杂度：$O(n^2)$。
- 空间复杂度：$O(n^2)$，即为存储所有状态需要的空间。

#### 方法二：动态规划 + 将所有运算变为整数运算

##### 思路与算法

我们可以将数组 $\textit{dist}$ 中的道路长度和 $\textit{hoursBefore}$ 都乘以 $\textit{speed}$。由于方法一的代码中所有除法运算的除数都是 $\textit{speed}$，因此这样做可以保证所有的除法运算的结果都是整数，从根本上避免浮点数误差。

但需要注意的是，在题目中我们规定「必须休息并等待，直到**下一个整数小时**才能开始继续通过下一条道路」，那么当我们将上面的变量都乘以 $\textit{speed}$ 后，规定应当变更为「必须休息并等待，直到**下一个 $\textit{speed}$ 的倍数小时**才能开始继续通过下一条道路」。

其余的逻辑与方法一完全相同，读者可以比较方法一和方法二的代码体会其中的差异。

##### 细节

时间 $x$ 的下一个 $\textit{speed}$ 的倍数小时为：

$$\left( \lfloor \frac{x-1}{\textit{speed}} \rfloor + 1 \right) \cdot \textit{speed}$$

其中 $\lfloor x \rfloor$ 表示将 $x$ 向下取整。

##### 代码

```c++
class Solution {
private:
    using LL = long long;

public:
    int minSkips(vector<int>& dist, int speed, int hoursBefore) {
        int n = dist.size();
        vector<vector<LL>> f(n + 1, vector<LL>(n + 1, LLONG_MAX / 2));
        f[0][0] = 0;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= i; ++j) {
                if (j != i) {
                    f[i][j] = min(f[i][j], ((f[i - 1][j] + dist[i - 1] - 1) / speed + 1) * speed);
                }
                if (j != 0) {
                    f[i][j] = min(f[i][j], f[i - 1][j - 1] + dist[i - 1]);
                }
            }
        }
        for (int j = 0; j <= n; ++j) {
            if (f[n][j] <= (LL)hoursBefore * speed) {
                return j;
            }
        }
        return -1;
    }
};
```

```python
class Solution:
    def minSkips(self, dist: List[int], speed: int, hoursBefore: int) -> int:
        n = len(dist)
        f = [[float("inf")] * (n + 1) for _ in range(n + 1)]
        f[0][0] = 0
        for i in range(1, n + 1):
            for j in range(i + 1):
                if j != i:
                    f[i][j] = min(f[i][j], ((f[i - 1][j] + dist[i - 1] - 1) // speed + 1) * speed)
                if j != 0:
                    f[i][j] = min(f[i][j], f[i - 1][j - 1] + dist[i - 1])
        
        for j in range(n + 1):
            if f[n][j] <= hoursBefore * speed:
                return j
        return -1
```

```java
class Solution {
    public int minSkips(int[] dist, int speed, int hoursBefore) {
        int n = dist.length;
        long[][] f = new long[n + 1][n + 1];
        for (int i = 0; i <= n; ++i) {
            Arrays.fill(f[i], Long.MAX_VALUE / 2);
        }
        f[0][0] = 0;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= i; ++j) {
                if (j != i) {
                    f[i][j] = Math.min(f[i][j], ((f[i - 1][j] + dist[i - 1] - 1) / speed + 1) * speed);
                }
                if (j != 0) {
                    f[i][j] = Math.min(f[i][j], f[i - 1][j - 1] + dist[i - 1]);
                }
            }
        }
        for (int j = 0; j <= n; ++j) {
            if (f[n][j] <= (long) hoursBefore * speed) {
                return j;
            }
        }
        return -1;
    }
}
```

```csharp
public class Solution {
    public int MinSkips(int[] dist, int speed, int hoursBefore) {
        int n = dist.Length;
        long[][] f = new long[n + 1][];
        for (int i = 0; i <= n; ++i) {
            f[i] = new long[n + 1];
            Array.Fill(f[i], long.MaxValue / 2);
        }
        f[0][0] = 0;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= i; ++j) {
                if (j != i) {
                    f[i][j] = Math.Min(f[i][j], ((f[i - 1][j] + dist[i - 1] - 1) / speed + 1) * speed);
                }
                if (j != 0) {
                    f[i][j] = Math.Min(f[i][j], f[i - 1][j - 1] + dist[i - 1]);
                }
            }
        }
        for (int j = 0; j <= n; ++j) {
            if (f[n][j] <= (long) hoursBefore * speed) {
                return j;
            }
        }
        return -1;
    }
}
```

```c
typedef long long LL;

int minSkips(int* dist, int distSize, int speed, int hoursBefore) {
    int n = distSize;
    LL f[n + 1][n + 1];
    for (int i = 0; i <= n; ++i) {
        for (int j = 0; j <= n; ++j) {
            f[i][j] = LLONG_MAX / 2;
        }
    }
    f[0][0] = 0;
    for (int i = 1; i <= n; ++i) {
        for (int j = 0; j <= i; ++j) {
            if (j != i) {
                f[i][j] = fmin(f[i][j], ((f[i - 1][j] + dist[i - 1] - 1) / speed + 1) * speed);
            }
            if (j != 0) {
                f[i][j] = fmin(f[i][j], f[i - 1][j - 1] + dist[i - 1]);
            }
        }
    }
    for (int j = 0; j <= n; ++j) {
        if (f[n][j] <= (LL)hoursBefore * speed) {
            return j;
        }
    }
    return -1;
}
```

```go
func minSkips(dist []int, speed int, hoursBefore int) int {
    n := len(dist)
    f := make([][]int64, n + 1)
    for i := range f {
        f[i] = make([]int64, n + 1)
        for j := range f[i] {
            f[i][j] = math.MaxInt64 / 2
        }
    }
    f[0][0] = 0
    for i := 1; i <= n; i++ {
        for j := 0; j <= i; j++ {
            if j != i {
                f[i][j] = min(f[i][j], ((f[i - 1][j] + int64(dist[i - 1]) - 1) / int64(speed) + 1) * int64(speed))
            }
            if j != 0 {
                f[i][j] = min(f[i][j], f[i - 1][j - 1] + int64(dist[i - 1]))
            }
        }
    }
    for j := 0; j <= n; j++ {
        if f[n][j] <= int64(hoursBefore) * int64(speed) {
            return j
        }
    }
    return -1
}
```

```javascript
var minSkips = function(dist, speed, hoursBefore) {
    const n = dist.length;
    const f = new Array(n + 1).fill(0).map(() => new Array(n + 1).fill(Number.MAX_SAFE_INTEGER / 2));
    f[0][0] = 0;
    for (let i = 1; i <= n; i++) {
        for (let j = 0; j <= i; j++) {
            if (j !== i) {
                f[i][j] = Math.min(f[i][j], Math.floor((f[i - 1][j] + dist[i - 1] - 1) / speed + 1) * speed);
            }
            if (j !== 0) {
                f[i][j] = Math.min(f[i][j], f[i - 1][j - 1] + dist[i - 1]);
            }
        }
    }
    for (let j = 0; j <= n; j++) {
        if (f[n][j] <= hoursBefore * speed) {
            return j;
        }
    }
    return -1;
};
```

```typescript
function minSkips(dist: number[], speed: number, hoursBefore: number): number {
    const n = dist.length;
    const f: number[][] = new Array(n + 1).fill(0).map(() => new Array(n + 1).fill(Number.MAX_SAFE_INTEGER / 2));
    f[0][0] = 0;
    for (let i = 1; i <= n; i++) {
        for (let j = 0; j <= i; j++) {
            if (j !== i) {
                f[i][j] = Math.min(f[i][j], Math.floor((f[i - 1][j] + dist[i - 1] - 1) / speed + 1) * speed);
            }
            if (j !== 0) {
                f[i][j] = Math.min(f[i][j], f[i - 1][j - 1] + dist[i - 1]);
            }
        }
    }
    for (let j = 0; j <= n; j++) {
        if (f[n][j] <= hoursBefore * speed) {
            return j;
        }
    }
    return -1;
};
```

```rust
use std::cmp::min;

impl Solution {
    pub fn min_skips(dist: Vec<i32>, speed: i32, hours_before: i32) -> i32 {
        let n = dist.len();
        let mut f = vec![vec![i64::MAX / 2; n + 1]; n + 1];
        f[0][0] = 0;
        for i in 1..= n {
            for j in 0..= i {
                if j != i {
                    f[i][j] = f[i][j].min(((f[i - 1][j] + dist[i - 1] as i64 - 1) as f64 / speed as f64 + 1.0).floor() as i64 * speed as i64);
                }
                if j != 0 {
                    f[i][j] = f[i][j].min(f[i - 1][j - 1] + dist[i - 1] as i64);
                }
            }
        }
        for j in 0..=n {
            if f[n][j]  <= hours_before as i64 * speed as i64 {
                return j as i32;
            }
        }
        -1
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n^2)$。
- 空间复杂度：$O(n^2)$，即为存储所有状态需要的空间。
