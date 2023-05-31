#### [方法一：动态规划](https://leetcode.cn/problems/minimum-cost-tree-from-leaf-values/solutions/2285433/xie-zhi-de-zui-xiao-dai-jie-sheng-cheng-26ozf/)

已知数组 $arr$ 与二叉树的中序遍历的所有叶子节点对应，并且二叉树的每个节点都有 $0$ 个节点或 $2$ 个节点。考虑数组 $arr$ 可以生成的所有二叉树，我们可以将 $arr$ 切分成任意两个非空子数组，分别对应左子树和右子树，然后递归地对两个非空子树组执行相同的操作，直到子数组大小等于 $1$，即叶子节点，那么一种切分方案对应一个合法的二叉树。

使用 $dp[i][j]$ 表示子数组 $[i, j]~(i \le j)$ 对应的子树所有非叶子节点的最小总和，那么 $dp[i][j]$ 可以通过切分子树求得，状态转移方程如下：

$$dp[i][j] = \begin{cases} 0, & i = j \\ \min \limits _{k \in [i,j)} ~ (dp[i][k] + dp[k + 1][j] + m_{ik} \times m_{(k+1)j}), & i \lt j \end{cases}$$

其中 $m_{ik}$ 表示子数组 $[i, k]$ 的最大值，可以预先计算并保存下来。

```cpp
class Solution {
public:
    int mctFromLeafValues(vector<int>& arr) {
        int n = arr.size();
        vector<vector<int>> dp(n, vector<int>(n, INT_MAX / 4)), mval(n, vector<int>(n));
        for (int j = 0; j < n; j++) {
            mval[j][j] = arr[j];
            dp[j][j] = 0;
            for (int i = j - 1; i >= 0; i--) {
                mval[i][j] = max(arr[i], mval[i + 1][j]);
                for (int k = i; k < j; k++) {
                    dp[i][j] = min(dp[i][j], dp[i][k] + dp[k + 1][j] + mval[i][k] * mval[k + 1][j]);
                }
            }
        }
        return dp[0][n - 1];
    }
};
```

```java
class Solution {
    public int mctFromLeafValues(int[] arr) {
        int n = arr.length;
        int[][] dp = new int[n][n];
        for (int i = 0; i < n; i++) {
            Arrays.fill(dp[i], Integer.MAX_VALUE / 4);
        }
        int[][] mval = new int[n][n];
        for (int j = 0; j < n; j++) {
            mval[j][j] = arr[j];
            dp[j][j] = 0;
            for (int i = j - 1; i >= 0; i--) {
                mval[i][j] = Math.max(arr[i], mval[i + 1][j]);
                for (int k = i; k < j; k++) {
                    dp[i][j] = Math.min(dp[i][j], dp[i][k] + dp[k + 1][j] + mval[i][k] * mval[k + 1][j]);
                }
            }
        }
        return dp[0][n - 1];
    }
}
```

```csharp
public class Solution {
    public int MctFromLeafValues(int[] arr) {
        int n = arr.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[n];
            Array.Fill(dp[i], int.MaxValue / 4);
        }
        int[][] mval = new int[n][];
        for (int i = 0; i < n; i++) {
            mval[i] = new int[n];
        }
        for (int j = 0; j < n; j++) {
            mval[j][j] = arr[j];
            dp[j][j] = 0;
            for (int i = j - 1; i >= 0; i--) {
                mval[i][j] = Math.Max(arr[i], mval[i + 1][j]);
                for (int k = i; k < j; k++) {
                    dp[i][j] = Math.Min(dp[i][j], dp[i][k] + dp[k + 1][j] + mval[i][k] * mval[k + 1][j]);
                }
            }
        }
        return dp[0][n - 1];
    }
}
```

```python
class Solution:
    def mctFromLeafValues(self, arr: List[int]) -> int:
        n = len(arr)
        dp = [[inf for i in range(n)] for j in range(n)]
        mval = [[0 for i in range(n)] for j in range(n)]
        for j in range(n):
            mval[j][j] = arr[j]
            dp[j][j] = 0
            for i in range(j - 1, -1, -1):
                mval[i][j] = max(arr[i], mval[i + 1][j])
                for k in range(i, j):
                    dp[i][j] = min(dp[i][j], dp[i][k] + dp[k + 1][j] + mval[i][k] * mval[k + 1][j])
        return dp[0][n - 1]
```

```javascript
var mctFromLeafValues = function(arr) {
    const n = arr.length;
    const dp = Array(n).fill(0).map(() => Array(n).fill(Infinity));
    const mval = Array(n).fill(0).map(() => Array(n));
    for (let j = 0; j < n; j++) {
        mval[j][j] = arr[j];
        dp[j][j] = 0;
    }
    for (let i = n - 1; i >= 0; i--) {
        for (let j = i + 1; j < n; j++) {
          mval[i][j] = Math.max(arr[i], mval[i + 1][j]);
          for (let k = i; k < j; k++) {
              dp[i][j] = Math.min(dp[i][j], dp[i][k] + dp[k + 1][j] + mval[i][k] * mval[k + 1][j]);
          }
        }
    }
    return dp[0][n - 1];
}
```

```go
func min(a, b int) int {
    if a < b {
        return a
    }
    return b
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func mctFromLeafValues(arr []int) int {
    n := len(arr)
    dp, mval := make([][]int, n), make([][]int, n)
    for i := 0; i < n; i++ {
        dp[i] = make([]int, n)
        mval[i] = make([]int, n)
    }
    for j := 0; j < n; j++ {
        mval[j][j] = arr[j]
        for i := j - 1; i >= 0; i-- {
            mval[i][j] = max(arr[i], mval[i + 1][j])
            dp[i][j] = 0x3f3f3f3f
            for k := i; k < j; k++ {
                dp[i][j] = min(dp[i][j], dp[i][k] + dp[k + 1][j] + mval[i][k] * mval[k + 1][j])
            }
        }
    }
    return dp[0][n - 1]
}
```

```c
const int INF = 0x3f3f3f3f;

static inline int max(int a, int b) {
    return a > b ? a : b;
}

static inline int min(int a, int b) {
    return a < b ? a : b;
}

int mctFromLeafValues(int* arr, int arrSize) {
    int n = arrSize;
    int dp[n][n];
    int mval[n][n];
    memset(dp, 0x3f, sizeof(dp));
    memset(mval, 0, sizeof(mval));
    for (int j = 0; j < n; j++) {
        mval[j][j] = arr[j];
        dp[j][j] = 0;
        for (int i = j - 1; i >= 0; i--) {
            mval[i][j] = max(arr[i], mval[i + 1][j]);
            for (int k = i; k < j; k++) {
                dp[i][j] = min(dp[i][j], dp[i][k] + dp[k + 1][j] + mval[i][k] * mval[k + 1][j]);
            }
        }
    }
    return dp[0][n - 1];
}
```

**复杂度分析**

-   时间复杂度：$O(n^3)$，其中 $n$ 是数组 $arr$ 的长度。三重循环需要 $O(n^3)$ 的空间。
-   空间复杂度：$O(n^2)$。保存 $dp$ 和 $mval$ 需要 $O(n^2)$ 的空间。
