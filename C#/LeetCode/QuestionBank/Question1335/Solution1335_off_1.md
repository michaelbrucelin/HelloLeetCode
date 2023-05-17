#### [方法一：动态规划](https://leetcode.cn/problems/minimum-difficulty-of-a-job-schedule/solutions/2271103/gong-zuo-ji-hua-de-zui-di-nan-du-by-leet-dule/)

**思路与算法**

题目给出了 $n$ 份工作，其中第 $i$ 份（工作下标从 $0$ 开始计算）工作的工作强度为 $jobDifficulty[i]$，$0 \le i < n$。现在我们需要将 $n$ 份工作分配到 $d$ 天完成，其中每一天至少需要完成一份工作，并且在完成第 $i$ 份工作时，必须完成全部第 $j$ 份工作，$0 \le j < i$。每一天的工作难度为当天应该完成工作的最大难度，现在需要求整个工作计划的最小难度。

首先当工作份数小于 $d$ 时，因为每天至少需要完成一份工作，所以此时无法制定工作计划，直接返回 $-1$。否则我们设 $dp[i][j]$ 表示前 $i + 1$ 天完成前 $j$ 项工作的最小难度，有：

$$dp[i][j] = \min_{k=i-1,i,\dots,j - 1}\{dp[i-1][k] + f(k + 1, j)\}$$

其中 $k$ 为前 $i$ 天完成的工作份数，$f(i,j)$ 表示第 $i$ 份工作到第 $j$ 份工作的最大工作强度，即：

$$f(i, j) = \max_{t = i, i + 1, \dots, j}\{jobDifficulty[t]\}$$

以上的讨论建立在 $i > 0$ 的基础上，边界条件当 $i = 0$ 时，有：

$$dp[i][j] = f(0, j)$$

最后我们返回 $dp[d - 1][n - 1]$ 即可。在实现的过程中可以发现 $dp[i]$ 的求解只与上一层状态 $dp[i-1]$ 有关，因此我们可以通过「滚动数组」来实现编码过程中的空间优化。

**代码**

未空间优化版

```cpp
class Solution {
public:
    int minDifficulty(vector<int>& jobDifficulty, int d) {
        int n = jobDifficulty.size();
        if (n < d) {
            return -1;
        }
        vector<vector<int>> dp(d + 1, vector<int>(n, 0x3f3f3f3f));
        int ma = 0;
        for (int i = 0; i < n; ++i) {
            ma = max(ma, jobDifficulty[i]);
            dp[0][i] = ma;
        }
        for (int i = 1; i < d; ++i) {
            for (int j = i; j < n; ++j) {
                ma = 0;
                for (int k = j; k >= i; --k) {
                    ma = max(ma, jobDifficulty[k]);
                    dp[i][j] = min(dp[i][j], ma + dp[i - 1][k - 1]);
                }
            }
        }
        return dp[d - 1][n - 1];
    }
};
```

```java
class Solution {
    public int minDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.length;
        if (n < d) {
            return -1;
        }
        int[][] dp = new int[d + 1][n];
        for (int i = 0; i <= d; ++i) {
            Arrays.fill(dp[i], 0x3f3f3f3f);
        }
        int ma = 0;
        for (int i = 0; i < n; ++i) {
            ma = Math.max(ma, jobDifficulty[i]);
            dp[0][i] = ma;
        }
        for (int i = 1; i < d; ++i) {
            for (int j = i; j < n; ++j) {
                ma = 0;
                for (int k = j; k >= i; --k) {
                    ma = Math.max(ma, jobDifficulty[k]);
                    dp[i][j] = Math.min(dp[i][j], ma + dp[i - 1][k - 1]);
                }
            }
        }
        return dp[d - 1][n - 1];
    }
}
```

```csharp
public class Solution {
    public int MinDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.Length;
        if (n < d) {
            return -1;
        }
        int[][] dp = new int[d + 1][];
        for (int i = 0; i <= d; ++i) {
            dp[i] = new int[n];
            Array.Fill(dp[i], 0x3f3f3f3f);
        }
        int ma = 0;
        for (int i = 0; i < n; ++i) {
            ma = Math.Max(ma, jobDifficulty[i]);
            dp[0][i] = ma;
        }
        for (int i = 1; i < d; ++i) {
            for (int j = i; j < n; ++j) {
                ma = 0;
                for (int k = j; k >= i; --k) {
                    ma = Math.Max(ma, jobDifficulty[k]);
                    dp[i][j] = Math.Min(dp[i][j], ma + dp[i - 1][k - 1]);
                }
            }
        }
        return dp[d - 1][n - 1];
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int minDifficulty(int* jobDifficulty, int jobDifficultySize, int d) {
    int n = jobDifficultySize;
    if (n < d) {
        return -1;
    }
    int dp[n + 1][n];
    memset(dp, 0x3f, sizeof(dp));
    int ma = 0;
    for (int i = 0; i < n; ++i) {
        ma = MAX(ma, jobDifficulty[i]);
        dp[0][i] = ma;
    }
    for (int i = 1; i < d; ++i) {
        for (int j = i; j < n; ++j) {
            ma = 0;
            for (int k = j; k >= i; --k) {
                ma = MAX(ma, jobDifficulty[k]);
                dp[i][j] = MIN(dp[i][j], ma + dp[i - 1][k - 1]);
            }
        }
    }
    return dp[d - 1][n - 1];
}
```

```javascript
var minDifficulty = function(jobDifficulty, d) {
    const n = jobDifficulty.length;
    if (n < d) {
        return -1;
    }
    const dp = new Array(d + 1).fill(0).map(() => new Array(n).fill(0x3f3f3f3f));
    let ma = 0;
    for (let i = 0; i < n; ++i) {
        ma = Math.max(ma, jobDifficulty[i]);
        dp[0][i] = ma;
    }
    for (let i = 1; i < d; ++i) {
        for (let j = i; j < n; ++j) {
            ma = 0;
            for (let k = j; k >= i; --k) {
                ma = Math.max(ma, jobDifficulty[k]);
                dp[i][j] = Math.min(dp[i][j], ma + dp[i - 1][k - 1]);
            }
        }
    }
    return dp[d - 1][n - 1];
};
```

通过「滚动数组」空间优化版

```cpp
class Solution {
public:
    int minDifficulty(vector<int>& jobDifficulty, int d) {
        int n = jobDifficulty.size();
        if (n < d) {
            return -1;
        }
        vector<int> dp(n);
        for (int i = 0, j = 0; i < n; ++i) {
            j = max(j, jobDifficulty[i]);
            dp[i] = j;
        }
        for (int i = 1; i < d; ++i) {
            vector<int> ndp(n, 0x3f3f3f3f);
            for (int j = i; j < n; ++j) {
                int ma = 0;
                for (int k = j; k >= i; --k) {
                    ma = max(ma, jobDifficulty[k]);
                    ndp[j] = min(ndp[j], ma + dp[k - 1]);
                }
            }
            swap(ndp, dp);
        }
        return dp[n - 1];
    }
};
```

```java
class Solution {
    public int minDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.length;
        if (n < d) {
            return -1;
        }
        int[] dp = new int[n];
        for (int i = 0, j = 0; i < n; ++i) {
            j = Math.max(j, jobDifficulty[i]);
            dp[i] = j;
        }
        for (int i = 1; i < d; ++i) {
            int[] ndp = new int[n];
            Arrays.fill(ndp, 0x3f3f3f3f);
            for (int j = i; j < n; ++j) {
                int ma = 0;
                for (int k = j; k >= i; --k) {
                    ma = Math.max(ma, jobDifficulty[k]);
                    ndp[j] = Math.min(ndp[j], ma + dp[k - 1]);
                }
            }
            dp = ndp;
        }
        return dp[n - 1];
    }
}
```

```csharp
public class Solution {
    public int MinDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.Length;
        if (n < d) {
            return -1;
        }
        int[] dp = new int[n];
        for (int i = 0, j = 0; i < n; ++i) {
            j = Math.Max(j, jobDifficulty[i]);
            dp[i] = j;
        }
        for (int i = 1; i < d; ++i) {
            int[] ndp = new int[n];
            Array.Fill(ndp, 0x3f3f3f3f);
            for (int j = i; j < n; ++j) {
                int ma = 0;
                for (int k = j; k >= i; --k) {
                    ma = Math.Max(ma, jobDifficulty[k]);
                    ndp[j] = Math.Min(ndp[j], ma + dp[k - 1]);
                }
            }
            dp = ndp;
        }
        return dp[n - 1];
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int minDifficulty(int* jobDifficulty, int jobDifficultySize, int d) {
    int n = jobDifficultySize;
    if (n < d) {
        return -1;
    }
    int dp[n];
    for (int i = 0, j = 0; i < n; ++i) {
        j = MAX(j, jobDifficulty[i]);
        dp[i] = j;
    }
    for (int i = 1; i < d; ++i) {
        int ndp[n];
        memset(ndp, 0x3f, sizeof(ndp));
        for (int j = i; j < n; ++j) {
            int ma = 0;
            for (int k = j; k >= i; --k) {
                ma = MAX(ma, jobDifficulty[k]);
                ndp[j] = MIN(ndp[j], ma + dp[k - 1]);
            }
        }
        memcpy(dp, ndp, sizeof(dp));
    }
    return dp[n - 1];
}
```

```javascript
var minDifficulty = function(jobDifficulty, d) {
    const n = jobDifficulty.length;
    if (n < d) {
        return -1;
    }
    let dp = new Array(n).fill(0);
    for (let i = 0, j = 0; i < n; ++i) {
        j = Math.max(j, jobDifficulty[i]);
        dp[i] = j;
    }
    for (let i = 1; i < d; ++i) {
        const ndp = new Array(n).fill(0x3f3f3f3f);
        for (let j = i; j < n; ++j) {
            let ma = 0;
            for (let k = j; k >= i; --k) {
                ma = Math.max(ma, jobDifficulty[k]);
                ndp[j] = Math.min(ndp[j], ma + dp[k - 1]);
            }
        }
        dp = ndp;
    }
    return dp[n - 1];
};
```

**复杂度分析**

-   时间复杂度：$O(n^2 \times d)$，其中 $n$ 为数组 $jobDifficulty$ 的长度，$d$ 为需要分配工作的天数。其中共有 $n \times d$ 个状态，每一个状态的求解时间开销为 $O(n)$。
-   空间复杂度：$O(n)$，其中 $n$ 为数组 $jobDifficulty$ 的长度。在通过「滚动数组」优化后的空间复杂度为 $O(n)$。
