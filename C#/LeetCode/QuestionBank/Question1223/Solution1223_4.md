#### [方法二：状态表示优化](https://leetcode.cn/problems/dice-roll-simulation/solutions/2102282/zhi-tou-zi-mo-ni-by-leetcode-solution-yg0s/)

**思路与算法**

定义状态 $d[i][j]$ 表示已经完成了 $i$ 次掷骰子，且第 $i$ 次掷的是 $j$ 时的合法序列数。那么有以下状态转移方程：

$$d[i][j] = \sum_{t=1}^{rollMax[j]}\sum_{\substack{k = 0 \\ k != j}}^5 d[i-t][k]$$

其具体含义是指，考虑从上一个不是 $j$ 的位置 $d[i - t]$ 来转移，可以覆盖到所有合法情况。此时，我们可以很容易的在 $O(nm^2k)$ 的时间复杂度内求出答案。

若递推过程中顺便计算出每个 $\sum\limits_{k=0}^5d[i][k]$，则可以将时间复杂度加快到 $O(nmk)$。

更进一步，我们发现在求解 $d[i][j]$ 和 $d[i - 1][j]$ 的过程中有很多重复运算：

$$d[i][j] = \sum_{\substack{k = 0 \\ k != j}}^5(d[i - 1][k] + d[i - 2][k] + \cdots + d[i - rollMax[j]][k])$$

$$d[i - 1][j] = \sum_{\substack{k = 0 \\ k != j}}^5(d[i - 2][k] + d[i - 3][k] + \cdots + d[i - rollMax[j] - 1][k]$$

因此，我们可以直接从 $d[i - 1][j]$ 递推到 $d[i][j]$：

$$d[i][j] = \sum_{\substack{k = 0}}^5d[i - 1][k] - \sum_{\substack{k = 0 \\ k != j}}^5d[i - rollMax[j] - 1][k]$$

这个过程可以简单理解为求解长度是 $rollMax[j]$ 的一段区间和。过程中有三个边界情况需要处理：

1.  若 $i - rollMax[j] - 1 < 0$，我们取 $0$ 作为转移点。
2.  设 $sum[i] = \sum\limits_{j=0}^5 d[i][j]$，特殊的，我们令 $sum[0] = 1$。
3.  若 $i \le rollMax[j]$，我们需要额外给 $d[i][j]$ 加 $1$。

**代码**

```cpp
class Solution {
public:
    static constexpr int mod = 1E9 + 7;
    int dieSimulator(int n, vector<int>& rollMax) {
        vector d(n + 1, vector<int>(6, 0));
        vector<int> sum(n + 1, 0);
        sum[0] = 1;
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j < 6; j++) {
                int pos = max(i - rollMax[j] - 1, 0);
                int sub = ((sum[pos] - d[pos][j]) % mod + mod) % mod;
                d[i][j] = ((sum[i - 1] - sub) % mod + mod) % mod;
                if (i <= rollMax[j]) {
                    d[i][j] = (d[i][j] + 1) % mod;
                }
                sum[i] = (sum[i] + d[i][j]) % mod;
            }
        }
        return sum[n];
    }
};
```

```java
class Solution {
    static final int MOD = 1$0$$0$007;

    public int dieSimulator(int n, int[] rollMax) {
        int[][] d = new int[n + 1][6];
        int[] sum = new int[n + 1];
        sum[0] = 1;
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j < 6; j++) {
                int pos = Math.max(i - rollMax[j] - 1, 0);
                int sub = ((sum[pos] - d[pos][j]) % MOD + MOD) % MOD;
                d[i][j] = ((sum[i - 1] - sub) % MOD + MOD) % MOD;
                if (i <= rollMax[j]) {
                    d[i][j] = (d[i][j] + 1) % MOD;
                }
                sum[i] = (sum[i] + d[i][j]) % MOD;
            }
        }
        return sum[n];
    }
}
```

```csharp
public class Solution {
    const int MOD = 1$0$$0$007;

    public int DieSimulator(int n, int[] rollMax) {
        int[][] d = new int[n + 1][];
        for (int i = 0; i <= n; i++) {
            d[i] = new int[6];
        }
        int[] sum = new int[n + 1];
        sum[0] = 1;
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j < 6; j++) {
                int pos = Math.Max(i - rollMax[j] - 1, 0);
                int sub = ((sum[pos] - d[pos][j]) % MOD + MOD) % MOD;
                d[i][j] = ((sum[i - 1] - sub) % MOD + MOD) % MOD;
                if (i <= rollMax[j]) {
                    d[i][j] = (d[i][j] + 1) % MOD;
                }
                sum[i] = (sum[i] + d[i][j]) % MOD;
            }
        }
        return sum[n];
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

const int mod = 1$0$$0$007;

int dieSimulator(int n, int* rollMax, int rollMaxSize){
    int d[n + 1][6];
    int sum[n + 1];
    memset(d, 0, sizeof(d));
    memset(sum, 0, sizeof(sum));
    sum[0] = 1;
    for (int i = 1; i <= n; i++) {
        for (int j = 0; j < 6; j++) {
            int pos = MAX(i - rollMax[j] - 1, 0);
            int sub = ((sum[pos] - d[pos][j]) % mod + mod) % mod;
            d[i][j] = ((sum[i - 1] - sub) % mod + mod) % mod;
            if (i <= rollMax[j]) {
                d[i][j] = (d[i][j] + 1) % mod;
            }
            sum[i] = (sum[i] + d[i][j]) % mod;
        }
    }
    return sum[n];
}
```

```javascript
const MOD = 1$0$$0$007;
var dieSimulator = function(n, rollMax) {
    const d = new Array(n + 1).fill(0).map(() => new Array(6).fill(0));
    const sum = new Array(n + 1).fill(0);
    sum[0] = 1;
    for (let i = 1; i <= n; i++) {
        for (let j = 0; j < 6; j++) {
            let pos = Math.max(i - rollMax[j] - 1, 0);
            let sub = ((sum[pos] - d[pos][j]) % MOD + MOD) % MOD;
            d[i][j] = ((sum[i - 1] - sub) % MOD + MOD) % MOD;
            if (i <= rollMax[j]) {
                d[i][j] = (d[i][j] + 1) % MOD;
            }
            sum[i] = (sum[i] + d[i][j]) % MOD;
        }
    }
    return sum[n];
};
```

**复杂度分析**

-   时间复杂度：$O(nm)$，其中 $n$ 是掷骰子的次数，$m$ 是随机数的种类数，在本题中等于 $6$。
-   空间复杂度：$O(nm)$。
