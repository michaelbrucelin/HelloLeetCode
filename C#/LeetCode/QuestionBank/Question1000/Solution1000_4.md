#### [方法二：状态优化](https://leetcode.cn/problems/minimum-cost-to-merge-stones/solutions/2206339/he-bing-shi-tou-de-zui-di-cheng-ben-by-l-pnvh/)

在方法一中，我们用 $d[l][r][t]$ 表示将区间 $[l,r]$ 的石头堆合并为 $t$ 堆的最小成本，这里 $t$ 的范围是 $[1,k]$。事实上，对于一个固定的区间 $[l,r]$，最终合并到小于 $k$ 堆时的堆数是固定的。

我们每次合并都会减小 $k - 1$ 堆，初始时 $[l,r]$ 的堆数是 $r - l + 1$，合并到不能合并时的堆数为 $(r - l) \mod (k - 1) + 1$。所以我们可以直接用 $d[l][r]$ 表示将区间 $[l,r]$ 合并到不能为止时的最小成本。它本质上是通过忽略方法一中一定无解的状态，加快求解。

-   初态：对于所有的 $d[i][i]$，初始化为 $0$，其他状态设置为正无穷。
-   转移方程：
    -   $d[l][r] = \min\{d[l][p] + d[p+1][r]\}$，其中 $l \le p \lt r$。
    -   如果 $(r - l) \mod (k - 1) = 0$ 则还需加上 $sum[l][r]$。
-   目标：$d[0][n-1]$。

```cpp
class Solution {
    static constexpr int inf = 0x3f3f3f3f;
public:
    int mergeStones(vector<int>& stones, int k) {
        int n = stones.size();
        if ((n - 1) % (k - 1) != 0) {
            return -1;
        }

        vector d(n, vector<int>(n, inf));
        vector<int> sum(n, 0);

        for (int i = 0, s = 0; i < n; i++) {
            d[i][i] = 0;
            s += stones[i];
            sum[i] = s;
        }

        for (int len = 2; len <= n; len++) {
            for (int l = 0; l < n && l + len - 1 < n; l++) {
                int r = l + len - 1;
                for (int p = l; p < r; p += k - 1) {
                    d[l][r] = min(d[l][r], d[l][p] + d[p + 1][r]);
                }
                if ((r - l) % (k - 1) == 0) {
                    d[l][r] += sum[r] - (l == 0 ? 0 : sum[l - 1]);
                }
            }
        }
        return d[0][n - 1];
    }
};
```

```java
class Solution {
    static final int INF = 0x3f3f3f3f;

    public int mergeStones(int[] stones, int k) {
        int n = stones.length;
        if ((n - 1) % (k - 1) != 0) {
            return -1;
        }

        int[][] d = new int[n][n];
        for (int i = 0; i < n; i++) {
            Arrays.fill(d[i], INF);
        }
        int[] sum = new int[n];

        for (int i = 0, s = 0; i < n; i++) {
            d[i][i] = 0;
            s += stones[i];
            sum[i] = s;
        }

        for (int len = 2; len <= n; len++) {
            for (int l = 0; l < n && l + len - 1 < n; l++) {
                int r = l + len - 1;
                for (int p = l; p < r; p += k - 1) {
                    d[l][r] = Math.min(d[l][r], d[l][p] + d[p + 1][r]);
                }
                if ((r - l) % (k - 1) == 0) {
                    d[l][r] += sum[r] - (l == 0 ? 0 : sum[l - 1]);
                }
            }
        }
        return d[0][n - 1];
    }
}
```

```csharp
public class Solution {
    const int INF = 0x3f3f3f3f;

    public int MergeStones(int[] stones, int k) {
        int n = stones.Length;
        if ((n - 1) % (k - 1) != 0) {
            return -1;
        }

        int[][] d = new int[n][];
        for (int i = 0; i < n; i++) {
            d[i] = new int[n];
            Array.Fill(d[i], INF);
        }
        int[] sum = new int[n];

        for (int i = 0, s = 0; i < n; i++) {
            d[i][i] = 0;
            s += stones[i];
            sum[i] = s;
        }

        for (int len = 2; len <= n; len++) {
            for (int l = 0; l < n && l + len - 1 < n; l++) {
                int r = l + len - 1;
                for (int p = l; p < r; p += k - 1) {
                    d[l][r] = Math.Min(d[l][r], d[l][p] + d[p + 1][r]);
                }
                if ((r - l) % (k - 1) == 0) {
                    d[l][r] += sum[r] - (l == 0 ? 0 : sum[l - 1]);
                }
            }
        }
        return d[0][n - 1];
    }
}
```

```c
const int inf = 0x3f3f3f3f;

int min(int a, int b) {
    return a < b ? a : b;
}

int mergeStones(int* stones, int stonesSize, int k) {
    int n = stonesSize;
    if ((n - 1) % (k - 1) != 0) {
        return -1;
    }

    int d[n][n];
    int sum[n];
    memset(d, 0x3f, sizeof(d));
    memset(sum, 0, sizeof(sum));

    for (int i = 0, s = 0; i < n; i++) {
        d[i][i] = 0;
        s += stones[i];
        sum[i] = s;
    }

    for (int len = 2; len <= n; len++) {
        for (int l = 0; l < n && l + len - 1 < n; l++) {
            int r = l + len - 1;
            for (int p = l; p < r; p += k - 1) {
                d[l][r] = min(d[l][r], d[l][p] + d[p + 1][r]);
            }
            if ((r - l) % (k - 1) == 0) {
                d[l][r] += sum[r] - (l == 0 ? 0 : sum[l - 1]);
            }
        }
    }
    return d[0][n - 1];
}
```

```python
class Solution:
    def mergeStones(self, stones: List[int], k: int) -> int:
        n = len(stones)
        if (n - 1) % (k - 1) != 0:
            return -1

        d = [[inf] * n for _ in range(n)]
        sum = [0] * n
        s = 0
        for i in range(n):
            d[i][i] = 0
            s += stones[i]
            sum[i] = s

        for L in range(2, n + 1):
            for l in range(n - L + 1):
                r = l + L - 1
                for p in range(l, r, k - 1):
                    d[l][r] = min(d[l][r], d[l][p] + d[p + 1][r])
                if (r - l) % (k - 1) == 0:
                    d[l][r] += (sum[r] - (0 if l == 0 else sum[l - 1]))
        return d[0][n - 1]
```

```javascript
const INF = 0x3f3f3f3f;
var mergeStones = function(stones, k) {
    const n = stones.length;
    if ((n - 1) % (k - 1) !== 0) {
        return -1;
    }

    const d = new Array(n).fill(0).map(() => new Array(n).fill(INF));
    const sum = new Array(n).fill(0);

    for (let i = 0, s = 0; i < n; i++) {
        d[i][i] = 0;
        s += stones[i];
        sum[i] = s;
    }

    for (let len = 2; len <= n; len++) {
        for (let l = 0; l < n && l + len - 1 < n; l++) {
            let r = l + len - 1;
            for (let p = l; p < r; p += k - 1) {
                d[l][r] = Math.min(d[l][r], d[l][p] + d[p + 1][r]);
            }
            if ((r - l) % (k - 1) === 0) {
                d[l][r] += sum[r] - (l === 0 ? 0 : sum[l - 1]);
            }
        }
    }
    return d[0][n - 1];
};
```

```go
func mergeStones(stones []int, k int) int {
    n := len(stones)
    if (n-1)%(k-1) != 0 {
        return -1
    }

    d := make([][]int, n)
    for i := range d {
        d[i] = make([]int, n)
        for j := range d[i] {
            d[i][j] = 1e9
        }
    }
    sum := make([]int, n+1)
    for i, s := 0, 0; i < n; i++ {
        d[i][i] = 0
        s += stones[i]
        sum[i+1] = s
    }

    for len := 2; len <= n; len++ {
        for l := 0; l < n && l+len-1 < n; l++ {
            r := l + len - 1
            for p := l; p < r; p += k - 1 {
                d[l][r] = min(d[l][r], d[l][p]+d[p+1][r])
            }
            if (r-l)%(k-1) == 0 {
                d[l][r] += sum[r+1] - sum[l]
            }
        }
    }
    return d[0][n-1]
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(n^3)$，其中 $n$ 是 $stones$ 的长度。
-   空间复杂度：$O(n^2)$，其中 $n$ 是 $stones$ 的长度。
