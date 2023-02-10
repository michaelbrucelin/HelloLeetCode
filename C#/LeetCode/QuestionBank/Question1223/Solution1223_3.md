#### [方法一：动态规划](https://leetcode.cn/problems/dice-roll-simulation/solutions/2102282/zhi-tou-zi-mo-ni-by-leetcode-solution-yg0s/)

**思路与算法**

为了方便编写程序，我们重新定义骰子模拟器每次投掷生成的随机数为 $0 \sim 5$，且连续掷出数字 $i$ 的次数不能超过 $rollMax[i]$，其中 $i \in [0, 5]$。

定义状态 $d[i][j][k]$ 表示已经完成了 $i$ 次掷骰子，第 $i$ 次掷的是 $j$，并且已经连续掷了 $k$ 次 $j$ 的合法序列数。

初始状态从 $i=1$ 开始，对于所有的 $j \in [0, 5]$，令 $d[1][j][1] = 1$。

状态转移时，我们首先枚举表示上一次投掷的状态 $d[i-1][j][k]$，然后再枚举当前这一次投掷生成的随机数 $p$，根据 $p$ 是否等于 $j$ 来分情况转移：

-   若 $p \neq j$，则令 $d[i][p][1]$ 加上 $d[i - 1][j][k]$。
-   若 $p = j$，并且 $k + 1 \le rollMax[j]$，则令 $d[i][p][k + 1]$ 加上 $d[i - 1][j][k]$。

最终，我们要求的答案是：

$$\sum_{j=0}^{5} \sum_{k=1}^{rollMax[j]} d[n][j][k]$$

**空间优化**

注意到状态转移过程中，$d[i]$ 这一层状态仅依赖 $d[i - 1]$ 的状态，所以我们可以将 $n$ 维状态表示压缩为 $2$ 维，进一步优化空间。

具体的，我们令 $t = i ~\&~ 1$（其中 $\&$ 表示按位与运算），则 $d[t][j][k]$ 表示原 $d[i][j][k]$ 状态， $d[t \oplus 1][j][k]$ 表示原 $d[i - 1][j][k]$ 状态（其中 $\oplus$ 表示按位异或运算）。每次转移时，从 $t \oplus 1$ 向 $t$ 进行转移，注意转移之前需要将 $d[t]$ 所有内容重置为 $0$。

**代码**

未使用空间优化的代码如下：

```cpp
class Solution {
public:
    static constexpr int mod = 1E9 + 7;
    int dieSimulator(int n, vector<int>& rollMax) {
        vector d(n + 1, vector(6, vector<int>(16)));
        for (int j = 0; j < 6; j++) {
            d[1][j][1] = 1;
        }
        for (int i = 2; i <= n; i++) {
            for (int j = 0; j < 6; j++) {
                for (int k = 1; k <= rollMax[j]; k++) {
                    for (int p = 0; p < 6; p++) {
                        if (p != j) {
                            d[i][p][1] = (d[i][p][1] + d[i - 1][j][k]) % mod;
                        } else if (k + 1 <= rollMax[j]) {
                            d[i][p][k + 1] = (d[i][p][k + 1] + d[i - 1][j][k]) % mod;
                        }
                    }
                }
            }
        }
        
        int res = 0;
        for (int j = 0; j < 6; j++) {
            for (int k = 1; k <= rollMax[j]; k++) {
                res = (res + d[n][j][k]) % mod;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    static final int MOD = 1$0$$0$007;

    public int dieSimulator(int n, int[] rollMax) {
        int[][][] d = new int[n + 1][6][16];
        for (int j = 0; j < 6; j++) {
            d[1][j][1] = 1;
        }
        for (int i = 2; i <= n; i++) {
            for (int j = 0; j < 6; j++) {
                for (int k = 1; k <= rollMax[j]; k++) {
                    for (int p = 0; p < 6; p++) {
                        if (p != j) {
                            d[i][p][1] = (d[i][p][1] + d[i - 1][j][k]) % MOD;
                        } else if (k + 1 <= rollMax[j]) {
                            d[i][p][k + 1] = (d[i][p][k + 1] + d[i - 1][j][k]) % MOD;
                        }
                    }
                }
            }
        }
        
        int res = 0;
        for (int j = 0; j < 6; j++) {
            for (int k = 1; k <= rollMax[j]; k++) {
                res = (res + d[n][j][k]) % MOD;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    const int MOD = 1$0$$0$007;

    public int DieSimulator(int n, int[] rollMax) {
        int[][][] d = new int[n + 1][][];
        for (int i = 0; i <= n; i++) {
            d[i] = new int[6][];
            for (int j = 0; j < 6; j++) {
                d[i][j] = new int[16];
            }
        }
        for (int j = 0; j < 6; j++) {
            d[1][j][1] = 1;
        }
        for (int i = 2; i <= n; i++) {
            for (int j = 0; j < 6; j++) {
                for (int k = 1; k <= rollMax[j]; k++) {
                    for (int p = 0; p < 6; p++) {
                        if (p != j) {
                            d[i][p][1] = (d[i][p][1] + d[i - 1][j][k]) % MOD;
                        } else if (k + 1 <= rollMax[j]) {
                            d[i][p][k + 1] = (d[i][p][k + 1] + d[i - 1][j][k]) % MOD;
                        }
                    }
                }
            }
        }
        
        int res = 0;
        for (int j = 0; j < 6; j++) {
            for (int k = 1; k <= rollMax[j]; k++) {
                res = (res + d[n][j][k]) % MOD;
            }
        }
        return res;
    }
}
```

```c
const int mod = 1E9 + 7;

int dieSimulator(int n, int* rollMax, int rollMaxSize) {
    int d[n + 1][6][16];
    memset(d, 0, sizeof(d));
    for (int j = 0; j < 6; j++) {
        d[1][j][1] = 1;
    }
    for (int i = 2; i <= n; i++) {
        for (int j = 0; j < 6; j++) {
            for (int k = 1; k <= rollMax[j]; k++) {
                for (int p = 0; p < 6; p++) {
                    if (p != j) {
                        d[i][p][1] = (d[i][p][1] + d[i - 1][j][k]) % mod;
                    } else if (k + 1 <= rollMax[j]) {
                        d[i][p][k + 1] = (d[i][p][k + 1] + d[i - 1][j][k]) % mod;
                    }
                }
            }
        }
    }
    
    int res = 0;
    for (int j = 0; j < 6; j++) {
        for (int k = 1; k <= rollMax[j]; k++) {
            res = (res + d[n][j][k]) % mod;
        }
    }
    return res;
}
```

```javascript
const MOD = 1$0$$0$007;
var dieSimulator = function(n, rollMax) {
    const d = new Array(n + 1).fill(0).map(() => new Array(6).fill(0).map(() => new Array(16).fill(0)));
    for (let j = 0; j < 6; j++) {
        d[1][j][1] = 1;
    }
    for (let i = 2; i <= n; i++) {
        for (let j = 0; j < 6; j++) {
            for (let k = 1; k <= rollMax[j]; k++) {
                for (let p = 0; p < 6; p++) {
                    if (p !== j) {
                        d[i][p][1] = (d[i][p][1] + d[i - 1][j][k]) % MOD;
                    } else if (k + 1 <= rollMax[j]) {
                        d[i][p][k + 1] = (d[i][p][k + 1] + d[i - 1][j][k]) % MOD;
                    }
                }
            }
        }
    }

    let res = 0;
    for (let j = 0; j < 6; j++) {
        for (let k = 1; k <= rollMax[j]; k++) {
            res = (res + d[n][j][k]) % MOD;
        }
    }
    return res;
};
```

使用空间优化的代码如下：

```cpp
class Solution {
public:
    static constexpr int mod = 1E9 + 7;
    int dieSimulator(int n, vector<int>& rollMax) {
        vector d(2, vector(6, vector<int>(16)));
        for (int j = 0; j < 6; j++) {
            d[1][j][1] = 1;
        }
        for (int i = 2; i <= n; i++) {
            int t = i & 1;
            for (int j = 0; j < 6; j++) {
                fill(d[t][j].begin(), d[t][j].end(), 0);
            }
            for (int j = 0; j < 6; j++) {
                for (int k = 1; k <= rollMax[j]; k++) {
                    for (int p = 0; p < 6; p++) {
                        if (p != j) {
                            d[t][p][1] = (d[t][p][1] + d[t ^ 1][j][k]) % mod;
                        } else if (k + 1 <= rollMax[j]) {
                            d[t][p][k + 1] = (d[t][p][k + 1] + d[t ^ 1][j][k]) % mod;
                        }
                    }
                }
            }
        }
        
        int res = 0;
        for (int j = 0; j < 6; j++) {
            for (int k = 1; k <= rollMax[j]; k++) {
                res = (res + d[n & 1][j][k]) % mod;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    static final int MOD = 1$0$$0$007;

    public int dieSimulator(int n, int[] rollMax) {
        int[][][] d = new int[2][6][16];
        for (int j = 0; j < 6; j++) {
            d[1][j][1] = 1;
        }
        for (int i = 2; i <= n; i++) {
            int t = i & 1;
            for (int j = 0; j < 6; j++) {
                Arrays.fill(d[t][j], 0);
            }
            for (int j = 0; j < 6; j++) {
                for (int k = 1; k <= rollMax[j]; k++) {
                    for (int p = 0; p < 6; p++) {
                        if (p != j) {
                            d[t][p][1] = (d[t][p][1] + d[t ^ 1][j][k]) % MOD;
                        } else if (k + 1 <= rollMax[j]) {
                            d[t][p][k + 1] = (d[t][p][k + 1] + d[t ^ 1][j][k]) % MOD;
                        }
                    }
                }
            }
        }
        
        int res = 0;
        for (int j = 0; j < 6; j++) {
            for (int k = 1; k <= rollMax[j]; k++) {
                res = (res + d[n & 1][j][k]) % MOD;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    const int MOD = 1$0$$0$007;

    public int DieSimulator(int n, int[] rollMax) {
        int[][][] d = new int[2][][];
        for (int i = 0; i < 2; i++) {
            d[i] = new int[6][];
            for (int j = 0; j < 6; j++) {
                d[i][j] = new int[16];
            }
        }
        for (int j = 0; j < 6; j++) {
            d[1][j][1] = 1;
        }
        for (int i = 2; i <= n; i++) {
            int t = i & 1;
            for (int j = 0; j < 6; j++) {
                Array.Fill(d[t][j], 0);
            }
            for (int j = 0; j < 6; j++) {
                for (int k = 1; k <= rollMax[j]; k++) {
                    for (int p = 0; p < 6; p++) {
                        if (p != j) {
                            d[t][p][1] = (d[t][p][1] + d[t ^ 1][j][k]) % MOD;
                        } else if (k + 1 <= rollMax[j]) {
                            d[t][p][k + 1] = (d[t][p][k + 1] + d[t ^ 1][j][k]) % MOD;
                        }
                    }
                }
            }
        }
        
        int res = 0;
        for (int j = 0; j < 6; j++) {
            for (int k = 1; k <= rollMax[j]; k++) {
                res = (res + d[n & 1][j][k]) % MOD;
            }
        }
        return res;
    }
}
```

```c
const int mod = 1E9 + 7;

int dieSimulator(int n, int* rollMax, int rollMaxSize) {
    int d[2][6][16];
    memset(d, 0, sizeof(d));
    for (int j = 0; j < 6; j++) {
        d[1][j][1] = 1;
    }
    for (int i = 2; i <= n; i++) {
        int t = i & 1;
        for (int j = 0; j < 6; j++) {
            memset(d[t][j], 0, sizeof(d[t][j]));
        }
        for (int j = 0; j < 6; j++) {
            for (int k = 1; k <= rollMax[j]; k++) {
                for (int p = 0; p < 6; p++) {
                    if (p != j) {
                        d[t][p][1] = (d[t][p][1] + d[t ^ 1][j][k]) % mod;
                    } else if (k + 1 <= rollMax[j]) {
                        d[t][p][k + 1] = (d[t][p][k + 1] + d[t ^ 1][j][k]) % mod;
                    }
                }
            }
        }
    }
    
    int res = 0;
    for (int j = 0; j < 6; j++) {
        for (int k = 1; k <= rollMax[j]; k++) {
            res = (res + d[n & 1][j][k]) % mod;
        }
    }
    return res;
}
```

```javascript
const MOD = 1$0$$0$007;
var dieSimulator = function(n, rollMax) {
    const d = new Array(n + 1).fill(0).map(() => new Array(6).fill(0).map(() => new Array(16).fill(0)));
    for (let j = 0; j < 6; j++) {
        d[1][j][1] = 1;
    }
    for (let i = 2; i <= n; i++) {
        let t = i & 1;
        for (let j = 0; j < 6; j++) {
            d[t][j].fill(0);
        }
        for (let j = 0; j < 6; j++) {
            for (let k = 1; k <= rollMax[j]; k++) {
                for (let p = 0; p < 6; p++) {
                    if (p !== j) {
                        d[t][p][1] = (d[t][p][1] + d[t ^ 1][j][k]) % MOD;
                    } else if (k + 1 <= rollMax[j]) {
                        d[t][p][k + 1] = (d[t][p][k + 1] + d[t ^ 1][j][k]) % MOD;
                    }
                }
            }
        }
    }

    let res = 0;
    for (let j = 0; j < 6; j++) {
        for (let k = 1; k <= rollMax[j]; k++) {
            res = (res + d[n & 1][j][k]) % MOD;
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(nm^2k)$，其中 $n$ 是掷骰子的次数，$m$ 是随机数的种类数，在本题中等于 $6$，$k$ 是 $rollMax$ 数组中的最大值。
-   空间复杂度：$O(nmk)$。使用空间优化后的空间复杂度为 $O(mk)$。
