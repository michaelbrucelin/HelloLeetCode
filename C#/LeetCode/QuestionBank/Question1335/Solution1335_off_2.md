#### [方法二：单调栈](https://leetcode.cn/problems/minimum-difficulty-of-a-job-schedule/solutions/2271103/gong-zuo-ji-hua-de-zui-di-nan-du-by-leet-dule/)

**思路与算法**

现在对于前 $j$ 份工作，找到小于 $j$ 的最大下标 $p$，使得 $jobDifficulty[p] > jobDifficulty[j]$。那么在「方法一」中，对于 $dp[i][j]$ 的求解可以分解为：

-   当 $k \ge p$ 时，有 $f(k+1, j) = jobDifficulty[j]$，得：

$$\begin{equation} \begin{aligned} dp[i][j] =& \min_{k=p,p+1,\dots,j - 1}\{dp[i-1][k] + jobDifficulty[j]\} \\ =& \min_{k=p,p+1,\dots,j - 1}\{dp[i-1][k]\} + jobDifficulty[j] \end{aligned} \end{equation}$$

-   当 $k < p$ 时，有 $f(k+1, j) = f(k+1, p)$，得：

$$\begin{equation} \begin{aligned} dp[i][j] =& \min_{k=i-1,i,\dots,p - 1}\{dp[i-1][k] + f(k + 1, p)\} \\ =& dp[i][p] \end{aligned} \end{equation}$$

在求解 $dp[i][j]$，$i \le j < n$ 时，对于 $p$ 的求解，类似于 [739\. 每日温度](https://leetcode.cn/problems/daily-temperatures/)，我们可以通过「单调栈」来进行求解，这样对于 $j$ 求解 $p$ 的均摊时间复杂度为 $O(1)$。我们维护一个存储二元组 $(idx_i, val_i)$ 的单调栈，从栈底到栈顶的二元组对应的 $idx_i$ 依次递减，其中 $idx_i$ 为对应的工作下标，$val_i$ 表示相应区间的最小值，具体来说，如果现在正在求解状态 $dp[i][j]$，$i > 0$，且「单调栈」中所存的下标为 $idx_1,idx_2,\dots,idx_m$，则 $val_1$ 表示区间 $dp[i-1][0]$ 到 $dp[i-1][idx_1 - 1]$ 的最小值，$val_2$ 表示区间 $dp[i-1][idx_1]$ 到 $dp[i-1][idx_2 - 1]$ 的最小值，以此类推。这样在维护「单调栈」的过程中，就可以在得到对应 $p$ 的同时，得到：

$$\min_{k = p,p+1,\dots,j-1}dp[k][j - 1]$$

以上的分析在 $i > 0$ 的基础上，同样与「方法一」相同，当 $i = 0$ 时为边界情况，有：

$$dp[i][j] = f(0, j)$$

最后我们返回 $dp[d - 1][n - 1]$ 即可。在实现的过程中同样可以发现 $dp[i]$ 的求解只与上一层状态 $dp[i-1]$ 有关，因此我们可以通过「滚动数组」来实现编码过程中的空间优化。

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
        vector<vector<int>> dp(d, vector<int>(n));
        for (int j = 0, ma = 0; j < n; ++j) {
            ma = max(ma, jobDifficulty[j]);
            dp[0][j] = ma;
        }
        for (int i = 1; i < d; ++i) {
            stack<pair<int, int>> st;
            for (int j = i; j < n; ++j) {
                int mi = dp[i - 1][j - 1];
                while (!st.empty() && jobDifficulty[st.top().first] < jobDifficulty[j]) {
                    mi = min(mi, st.top().second);
                    st.pop();
                }
                if (st.empty()) {
                    dp[i][j] = mi + jobDifficulty[j];
                } else {
                    dp[i][j] = min(dp[i][st.top().first], mi + jobDifficulty[j]);
                }
                st.emplace(j, mi);
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
        int[][] dp = new int[d][n];
        for (int j = 0, ma = 0; j < n; ++j) {
            ma = Math.max(ma, jobDifficulty[j]);
            dp[0][j] = ma;
        }
        for (int i = 1; i < d; ++i) {
            Deque<int[]> stack = new ArrayDeque<int[]>();
            for (int j = i; j < n; ++j) {
                int mi = dp[i - 1][j - 1];
                while (!stack.isEmpty() && jobDifficulty[stack.peek()[0]] < jobDifficulty[j]) {
                    mi = Math.min(mi, stack.pop()[1]);
                }
                if (stack.isEmpty()) {
                    dp[i][j] = mi + jobDifficulty[j];
                } else {
                    dp[i][j] = Math.min(dp[i][stack.peek()[0]], mi + jobDifficulty[j]);
                }
                stack.push(new int[]{j, mi});
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
        int[][] dp = new int[d][];
        for (int i = 0; i < d; ++i) {
            dp[i] = new int[n];
        }
        for (int j = 0, ma = 0; j < n; ++j) {
            ma = Math.Max(ma, jobDifficulty[j]);
            dp[0][j] = ma;
        }
        for (int i = 1; i < d; ++i) {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            for (int j = i; j < n; ++j) {
                int mi = dp[i - 1][j - 1];
                while (stack.Count > 0 && jobDifficulty[stack.Peek().Item1] < jobDifficulty[j]) {
                    mi = Math.Min(mi, stack.Pop().Item2);
                }
                if (stack.Count == 0) {
                    dp[i][j] = mi + jobDifficulty[j];
                } else {
                    dp[i][j] = Math.Min(dp[i][stack.Peek().Item1], mi + jobDifficulty[j]);
                }
                stack.Push(new Tuple<int, int>(j, mi));
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
    int dp[d][n];
    memset(dp, 0, sizeof(dp));
    for (int j = 0, ma = 0; j < n; ++j) {
        ma = MAX(ma, jobDifficulty[j]);
        dp[0][j] = ma;
    }
    for (int i = 1; i < d; ++i) {
        int stack[n][2];
        int top = 0;
        for (int j = i; j < n; ++j) {
            int mi = dp[i - 1][j - 1];
            while (top > 0 && jobDifficulty[stack[top - 1][0]] < jobDifficulty[j]) {
                mi = MIN(mi, stack[top - 1][1]);
                top--;
            }
            if (top == 0) {
                dp[i][j] = mi + jobDifficulty[j];
            } else {
                dp[i][j] = MIN(dp[i][stack[top - 1][0]], mi + jobDifficulty[j]);
            }
            stack[top][0] = j;
            stack[top][1] = mi;
            top++;
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
    const dp = new Array(d).fill(0).map(() => new Array(n).fill(0));
    for (let j = 0, ma = 0; j < n; ++j) {
        ma = Math.max(ma, jobDifficulty[j]);
        dp[0][j] = ma;
    }
    for (let i = 1; i < d; ++i) {
        const stack = [];
        for (let j = i; j < n; ++j) {
            let mi = dp[i - 1][j - 1];
            while (stack.length && jobDifficulty[stack[stack.length - 1][0]] < jobDifficulty[j]) {
                mi = Math.min(mi, stack.pop()[1]);
            }
            if (stack.length === 0) {
                dp[i][j] = mi + jobDifficulty[j];
            } else {
                dp[i][j] = Math.min(dp[i][stack[stack.length - 1][0]], mi + jobDifficulty[j]);
            }
            stack.push([j, mi]);
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
        for (int j = 0, ma = 0; j < n; ++j) {
            ma = max(ma, jobDifficulty[j]);
            dp[j] = ma;
        }
        for (int i = 1; i < d; ++i) {
            stack<pair<int, int>> st;
            vector<int> ndp(n);
            for (int j = i; j < n; ++j) {
                int mi = dp[j - 1];
                while (!st.empty() && jobDifficulty[st.top().first] < jobDifficulty[j]) {
                    mi = min(mi, st.top().second);
                    st.pop();
                }
                if (st.empty()) {
                    ndp[j] = mi + jobDifficulty[j];
                } else {
                    ndp[j] = min(ndp[st.top().first], mi + jobDifficulty[j]);
                }
                st.emplace(j, mi);
            }
            swap(dp, ndp);
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
        for (int j = 0, ma = 0; j < n; ++j) {
            ma = Math.max(ma, jobDifficulty[j]);
            dp[j] = ma;
        }
        for (int i = 1; i < d; ++i) {
            Deque<int[]> stack = new ArrayDeque<int[]>();
            int[] ndp = new int[n];
            for (int j = i; j < n; ++j) {
                int mi = dp[j - 1];
                while (!stack.isEmpty() && jobDifficulty[stack.peek()[0]] < jobDifficulty[j]) {
                    mi = Math.min(mi, stack.pop()[1]);
                }
                if (stack.isEmpty()) {
                    ndp[j] = mi + jobDifficulty[j];
                } else {
                    ndp[j] = Math.min(ndp[stack.peek()[0]], mi + jobDifficulty[j]);
                }
                stack.push(new int[]{j, mi});
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
        for (int j = 0, ma = 0; j < n; ++j) {
            ma = Math.Max(ma, jobDifficulty[j]);
            dp[j] = ma;
        }
        for (int i = 1; i < d; ++i) {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            int[] ndp = new int[n];
            for (int j = i; j < n; ++j) {
                int mi = dp[j - 1];
                while (stack.Count > 0 && jobDifficulty[stack.Peek().Item1] < jobDifficulty[j]) {
                    mi = Math.Min(mi, stack.Pop().Item2);
                }
                if (stack.Count == 0) {
                    ndp[j] = mi + jobDifficulty[j];
                } else {
                    ndp[j] = Math.Min(ndp[stack.Peek().Item1], mi + jobDifficulty[j]);
                }
                stack.Push(new Tuple<int, int>(j, mi));
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
    for (int j = 0, ma = 0; j < n; ++j) {
        ma = MAX(ma, jobDifficulty[j]);
        dp[j] = ma;
    }
    for (int i = 1; i < d; ++i) {
        int stack[n][2];
        int top = 0;
        int ndp[n];
        memset(ndp, 0, sizeof(ndp));
        for (int j = i; j < n; ++j) {
            int mi = dp[j - 1];
            while (top > 0 && jobDifficulty[stack[top - 1][0]] < jobDifficulty[j]) {
                mi = MIN(mi, stack[top - 1][1]);
                top--;
            }
            if (top == 0) {
                ndp[j] = mi + jobDifficulty[j];
            } else {
                ndp[j] = MIN(ndp[stack[top - 1][0]], mi + jobDifficulty[j]);
            }
            stack[top][0] = j;
            stack[top][1] = mi;
            top++;
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
    for (let j = 0, ma = 0; j < n; ++j) {
        ma = Math.max(ma, jobDifficulty[j]);
        dp[j] = ma;
    }
    for (let i = 1; i < d; ++i) {
        const stack = [];
        const ndp = new Array(n).fill(0);
        for (let j = i; j < n; ++j) {
            let mi = dp[j - 1];
            while (stack.length && jobDifficulty[stack[stack.length - 1][0]] < jobDifficulty[j]) {
                mi = Math.min(mi, stack.pop()[1]);
            }
            if (stack.length === 0) {
                ndp[j] = mi + jobDifficulty[j];
            } else {
                ndp[j] = Math.min(ndp[stack[stack.length - 1][0]], mi + jobDifficulty[j]);
            }
            stack.push([j, mi]);
        }
        dp = ndp;
    }
    return dp[n - 1];
};
```

**复杂度分析**

-   时间复杂度：$O(n \times d)$，其中 $n$ 为数组 $jobDifficulty$ 的长度，$d$ 为需要分配工作的天数。其中共有 $n \times d$ 个状态，每一个状态的求解时间开销均摊为 $O(1)$。
-   空间复杂度：$O(n)$，其中 $n$ 为数组 $jobDifficulty$ 的长度。在通过「滚动数组」优化后的空间复杂度为 $O(n)$。
