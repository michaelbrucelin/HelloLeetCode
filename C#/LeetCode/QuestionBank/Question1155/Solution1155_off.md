### [掷骰子等于目标和的方法数](https://leetcode.cn/problems/number-of-dice-rolls-with-target-sum/solutions/2490436/zhi-tou-zi-deng-yu-mu-biao-he-de-fang-fa-eewv/)

#### 方法一：动态规划

**思路与算法**

我们可以使用动态规划解决本题。

记 $f(i, j)$ 表示使用 $i$ 个骰子且数字之和为 $j$ 的方案数。为了计算该值，我们可以枚举最后一个骰子的数字，它的范围为 $[1, k]$，那么状态转移方程即为：

$$f(i, j) = \sum_{x=1}^k f(i-1, j-x) \tag{1}$$

动态规划的边界条件为：

$$f(0, 0) = 1$$

即我们还没有掷骰子时，数字之和为 $0$。以及：

$$f(i, j) = 0 \text{~if~} j < 0$$

即骰子的和不能小于 $0$。在进行 $(1)$ 式的状态转移时，我们可以忽略所有 $j - x < 0$ 的情况。

最终的答案即为 $f(n, target)$。

下面的给出的是使用递推方式进行动态规划的代码。上述状态转移方程也可以使用记忆化搜索来编写。

**代码**

```cpp
class Solution {
public:
    int numRollsToTarget(int n, int k, int target) {
        vector<vector<int>> f(n + 1, vector<int>(target + 1));
        f[0][0] = 1;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= target; ++j) {
                for (int x = 1; x <= k; ++x) {
                    if (j - x >= 0) {
                        f[i][j] = (f[i][j] + f[i - 1][j - x]) % mod;
                    }
                }
            }
        }
        return f[n][target];
    }

private:
    static constexpr int mod = 1000000007;
};
```

```java
class Solution {
    static final int MOD = 1000000007;

    public int numRollsToTarget(int n, int k, int target) {
        int[][] f = new int[n + 1][target + 1];
        f[0][0] = 1;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= target; ++j) {
                for (int x = 1; x <= k; ++x) {
                    if (j - x >= 0) {
                        f[i][j] = (f[i][j] + f[i - 1][j - x]) % MOD;
                    }
                }
            }
        }
        return f[n][target];
    }
}
```

```csharp
public class Solution {
    const int MOD = 1000000007;

    public int NumRollsToTarget(int n, int k, int target) {
        int[][] f = new int[n + 1][];
        for (int i = 0; i <= n; ++i) {
            f[i] = new int[target + 1];
        }
        f[0][0] = 1;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= target; ++j) {
                for (int x = 1; x <= k; ++x) {
                    if (j - x >= 0) {
                        f[i][j] = (f[i][j] + f[i - 1][j - x]) % MOD;
                    }
                }
            }
        }
        return f[n][target];
    }
}
```

```python
class Solution:
    def numRollsToTarget(self, n: int, k: int, target: int) -> int:
        mod = 10**9 + 7
        f = [[0] * (target + 1) for _ in range(n + 1)]
        f[0][0] = 1
        for i in range(1, n + 1):
            for j in range(target + 1):
                for x in range(1, k + 1):
                    if j - x >= 0:
                        f[i][j] = (f[i][j] + f[i - 1][j - x]) % mod
        return f[n][target]
```

```c
const int MOD = 1e9 + 7;

int numRollsToTarget(int n, int k, int target) {
    int f[n + 1][target + 1];
    memset(f, 0, sizeof(f));
    f[0][0] = 1;
    for (int i = 1; i <= n; ++i) {
        for (int j = 0; j <= target; ++j) {
            for (int x = 1; x <= k; ++x) {
                if (j - x >= 0) {
                    f[i][j] = (f[i][j] + f[i - 1][j - x]) % MOD;
                }
            }
        }
    }
    return f[n][target];
}
```

```go
func numRollsToTarget(n int, k int, target int) int {
    mod := int(1e9 + 7)
    f := make([][]int, n + 1)
    for i := 0; i <= n; i++ {
        f[i] = make([]int, target + 1)
    }
    f[0][0] = 1;
    for i := 1; i <= n; i++ {
        for j := 0; j <= target; j++ {
            for x := 1; x <= k; x++ {
                if j - x >= 0 {
                    f[i][j] = (f[i][j] + f[i - 1][j - x]) % mod
                }
            }
        }
    }
    return f[n][target]
}
```

```javascript
var numRollsToTarget = function(n, k, target) {
    const mod = 1e9 + 7;
    f = new Array(n + 1).fill(0).map(() => new Array(target + 1).fill(0));
    f[0][0] = 1;
    for (let i = 1; i <= n; i++) {
        for (let j = 0; j <= target; j++) {
            for (let x = 1; x <= k; x++) {
                if (j - x >= 0) {
                    f[i][j] = (f[i][j] + f[i - 1][j - x]) % mod;
                }
            }
        }
    }
    return f[n][target];
};
```

注意到 $(1)$ 式中，$f(i, j)$ 只会从 $f(i-1, \cdots)$ 转移而来，因此我们只需要存储当前行（第 $i$ 行）和上一行（第 $i-1$ 行）的值，即可以用两个一维数组代替上面代码中的二维数组 $f$ 进行状态转移。

```cpp
class Solution {
public:
    int numRollsToTarget(int n, int k, int target) {
        vector<int> f(target + 1);
        f[0] = 1;
        for (int i = 1; i <= n; ++i) {
            vector<int> g(target + 1);
            for (int j = 0; j <= target; ++j) {
                for (int x = 1; x <= k; ++x) {
                    if (j - x >= 0) {
                        g[j] = (g[j] + f[j - x]) % mod;
                    }
                }
            }
            f = move(g);
        }
        return f[target];
    }

private:
    static constexpr int mod = 1000000007;
};
```

```java
class Solution {
    static final int MOD = 1000000007;

    public int numRollsToTarget(int n, int k, int target) {
        int[] f = new int[target + 1];
        f[0] = 1;
        for (int i = 1; i <= n; ++i) {
            int[] g = new int[target + 1];
            for (int j = 0; j <= target; ++j) {
                for (int x = 1; x <= k; ++x) {
                    if (j - x >= 0) {
                        g[j] = (g[j] + f[j - x]) % MOD;
                    }
                }
            }
            f = g;
        }
        return f[target];
    }
}
```

```csharp
public class Solution {
    const int MOD = 1000000007;

    public int NumRollsToTarget(int n, int k, int target) {
        int[] f = new int[target + 1];
        f[0] = 1;
        for (int i = 1; i <= n; ++i) {
            int[] g = new int[target + 1];
            for (int j = 0; j <= target; ++j) {
                for (int x = 1; x <= k; ++x) {
                    if (j - x >= 0) {
                        g[j] = (g[j] + f[j - x]) % MOD;
                    }
                }
            }
            f = g;
        }
        return f[target];
    }
}
```

```python
class Solution:
    def numRollsToTarget(self, n: int, k: int, target: int) -> int:
        mod = 10**9 + 7
        f = [1] + [0] * target
        for i in range(1, n + 1):
            g = [0] * (target + 1)
            for j in range(target + 1):
                for x in range(1, k + 1):
                    if j - x >= 0:
                        g[j] = (g[j] + f[j - x]) % mod
            f = g
        return f[target]
```

```c
const int MOD = 1e9 + 7;

int numRollsToTarget(int n, int k, int target) {
    int f[target + 1];
    memset(f, 0, sizeof(f));
    f[0] = 1;
    for (int i = 1; i <= n; ++i) {
        int g[target + 1];
        memset(g, 0, sizeof(g));
        for (int j = 0; j <= target; ++j) {
            for (int x = 1; x <= k; ++x) {
                if (j - x >= 0) {
                    g[j] = (g[j] + f[j - x]) % MOD;
                }
            }
        }
        memcpy(f, g, sizeof(g));
    }
    return f[target];
}
```

```go
func numRollsToTarget(n int, k int, target int) int {
    mod := int(1e9 + 7)
    f := make([]int, target + 1)
    f[0] = 1;
    for i := 1; i <= n; i++ {
        g := make([]int, target + 1)
        for j := 0; j <= target; j++ {
            for x := 1; x <= k; x++ {
                if j - x >= 0 {
                    g[j] = (g[j] + f[j - x]) % mod
                }
            }
        }
        f = g
    }
    return f[target]
}
```

```javascript
var numRollsToTarget = function(n, k, target) {
    const mod = 1e9 + 7;
    f = new Array(target + 1).fill(0);
    f[0] = 1;
    for (let i = 1; i <= n; i++) {
        g = new Array(target + 1).fill(0);
        for (let j = 0; j <= target; j++) {
            for (let x = 1; x <= k; x++) {
                if (j - x >= 0) {
                    g[j] = (g[j] + f[j - x]) % mod;
                }
            }
        }
        f = g;
    }
    return f[target];
};
```

进一步，我们发现 $f(i, j)$ 只会从第二维严格小于它的 $f(i-1, \cdots)$ 转移而来，因此我们可以倒序遍历第二维来计算 $f(i, j)$，这样可以只使用一个一位数组。也就是说，当我们计算 $f(i, j)$ 时，一维数组中下标大于 $j$ 的位置都是 $f(i, \cdots)$ 的值，下标小于 $j$ 的位置都是 $f(i-1, \cdots)$ 的值，这样就保证了 $f(i, j)$ 结果的正确性。

```cpp
class Solution {
public:
    int numRollsToTarget(int n, int k, int target) {
        vector<int> f(target + 1);
        f[0] = 1;
        for (int i = 1; i <= n; ++i) {
            for (int j = target; j >= 0; --j) {
                f[j] = 0;
                for (int x = 1; x <= k; ++x) {
                    if (j - x >= 0) {
                        f[j] = (f[j] + f[j - x]) % mod;
                    }
                }
            }
        }
        return f[target];
    }

private:
    static constexpr int mod = 1000000007;
};
```

```java
class Solution {
    static final int MOD = 1000000007;

    public int numRollsToTarget(int n, int k, int target) {
        int[] f = new int[target + 1];
        f[0] = 1;
        for (int i = 1; i <= n; ++i) {
            for (int j = target; j >= 0; --j) {
                f[j] = 0;
                for (int x = 1; x <= k; ++x) {
                    if (j - x >= 0) {
                        f[j] = (f[j] + f[j - x]) % MOD;
                    }
                }
            }
        }
        return f[target];
    }
}
```

```csharp
public class Solution {
    const int MOD = 1000000007;

    public int NumRollsToTarget(int n, int k, int target) {
        int[] f = new int[target + 1];
        f[0] = 1;
        for (int i = 1; i <= n; ++i) {
            for (int j = target; j >= 0; --j) {
                f[j] = 0;
                for (int x = 1; x <= k; ++x) {
                    if (j - x >= 0) {
                        f[j] = (f[j] + f[j - x]) % MOD;
                    }
                }
            }
        }
        return f[target];
    }
}
```

```python
class Solution:
    def numRollsToTarget(self, n: int, k: int, target: int) -> int:
        mod = 10**9 + 7
        f = [1] + [0] * target
        for i in range(1, n + 1):
            for j in range(target, -1, -1):
                f[j] = 0
                for x in range(1, k + 1):
                    if j - x >= 0:
                        f[j] = (f[j] + f[j - x]) % mod
        return f[target]
```

```c
const int MOD = 1e9 + 7;

int numRollsToTarget(int n, int k, int target) {
    int f[target + 1];
    memset(f, 0, sizeof(f));
    f[0] = 1;
    for (int i = 1; i <= n; ++i) {
        for (int j = target; j >= 0; --j) {
            f[j] = 0;
            for (int x = 1; x <= k; ++x) {
                if (j - x >= 0) {
                    f[j] = (f[j] + f[j - x]) % MOD;
                }
            }
        }
    }
    return f[target];
}
```

```go
func numRollsToTarget(n int, k int, target int) int {
    mod := int(1e9 + 7)
    f := make([]int, target + 1)
    f[0] = 1;
    for i := 1; i <= n; i++ {
        for j := target; j >= 0; j-- {
            f[j] = 0
            for x := 1; x <= k; x++ {
                if j - x >= 0 {
                    f[j] = (f[j] + f[j - x]) % mod
                }
            }
        }
    }
    return f[target]
}
```

```javascript
var numRollsToTarget = function(n, k, target) {
    const mod = 1e9 + 7;
    f = new Array(target + 1).fill(0);
    f[0] = 1;
    for (let i = 1; i <= n; i++) {
        for (let j = target; j >= 0; j--) {
            f[j] = 0;
            for (let x = 1; x <= k; x++) {
                if (j - x >= 0) {
                    f[j] = (f[j] + f[j - x]) % mod;
                }
            }
        }
    }
    return f[target];
};
```

**复杂度分析**

-   时间复杂度：$O(n \cdot k \cdot target)$，即为动态规划需要的时间。
-   空间复杂度：$O(n \cdot target)$ 或 $O(target)$，即为动态规划需要的空间。
