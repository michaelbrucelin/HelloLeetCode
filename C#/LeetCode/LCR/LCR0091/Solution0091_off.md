### [粉刷房子](https://leetcode.cn/problems/JEj789/solutions/1621250/fen-shua-fang-zi-by-leetcode-solution-q0kh/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：动态规划

每个房子可以被粉刷成三种颜色中的一种，需要计算在满足相邻房子的颜色不同的情况下粉刷所有房子的最小花费成本。由于当已知粉刷前 $i$ 个房子的最小花费成本时，根据粉刷第 $i+1$ 号房子的花费成本可以计算粉刷前 $i+1$ 个房子的最小花费成本，因此可以使用动态规划计算最小花费成本。

由于每个房子可以被粉刷成三种颜色中的一种，因此需要分别考虑粉刷成三种颜色时的最小花费成本。

用 $dp[i][j]$ 表示粉刷第 $0$ 号房子到第 $i$ 号房子且第 $i$ 号房子被粉刷成第 $j$ 种颜色时的最小花费成本。由于一共有 $n$ 个房子和 $3$ 种颜色，因此 $0\le i<n$，$0\le j<3$。

当只有第 $0$ 号房子被粉刷时，对于每一种颜色，总花费成本即为将第 $0$ 号房子粉刷成该颜色的花费成本，因此边界条件是：对于任意 $0\le j<3$，$dp[0][j]=costs[0][j]$。

对于 $1\le i<n$，第 $i$ 号房子和第 $i-1$ 号房子的颜色必须不同，因此当第 $i$ 号房子被粉刷成某一种颜色时，第 $i-1$ 号房子只能被粉刷成另外两种颜色之一。当第 $i$ 号房子分别被粉刷成三种颜色时，粉刷第 $0$ 号房子到第 $i$ 号房子的最小花费成本计算如下：

$$dp[i][0]=min(dp[i-1][1],dp[i-1][2])+costs[i][0] \\ dp[i][1]=min(dp[i-1][0],dp[i-1][2])+costs[i][1] \\ dp[i][2]=min(dp[i-1][0],dp[i-1][1])+costs[i][2]$$

三种颜色的情况可以合并为一个状态转移方程，对于 $1\le i<n$ 和 $0\le j<3$，状态转移方程如下：

$$dp[i][j]=min(dp[i-1][(j+1)\bmod 3],dp[i-1][(j+2)\bmod 3])+costs[i][j]$$

计算结束时，$dp[n-1]$ 中的最小值即为粉刷所有房子的最小花费成本。

当 $i\ge 1$ 时，由于 $dp[i]$ 的计算只和 $dp[i-1]$ 有关，因此可以使用滚动数组优化空间，将空间复杂度降低到 $O(1)$。

```Python
class Solution:
    def minCost(self, costs: List[List[int]]) -> int:
        dp = costs[0]
        for i in range(1, len(costs)):
            dp = [min(dp[j - 1], dp[j - 2]) + c for j, c in enumerate(costs[i])]
        return min(dp)
```

```Java
class Solution {
    public int minCost(int[][] costs) {
        int n = costs.length;
        int[] dp = new int[3];
        for (int j = 0; j < 3; j++) {
            dp[j] = costs[0][j];
        }
        for (int i = 1; i < n; i++) {
            int[] dpNew = new int[3];
            for (int j = 0; j < 3; j++) {
                dpNew[j] = Math.min(dp[(j + 1) % 3], dp[(j + 2) % 3]) + costs[i][j];
            }
            dp = dpNew;
        }
        return Arrays.stream(dp).min().getAsInt();
    }
}
```

```CSharp
public class Solution {
    public int MinCost(int[][] costs) {
        int n = costs.Length;
        int[] dp = new int[3];
        for (int j = 0; j < 3; j++) {
            dp[j] = costs[0][j];
        }
        for (int i = 1; i < n; i++) {
            int[] dpNew = new int[3];
            for (int j = 0; j < 3; j++) {
                dpNew[j] = Math.Min(dp[(j + 1) % 3], dp[(j + 2) % 3]) + costs[i][j];
            }
            dp = dpNew;
        }
        return Math.Min(Math.Min(dp[0], dp[1]), dp[2]);
    }
}
```

```C++
class Solution {
public:
    int minCost(vector<vector<int>>& costs) {
        int n = costs.size();
        vector<int> dp(3);
        for (int j = 0; j < 3; j++) {
            dp[j] = costs[0][j];
        }
        for (int i = 1; i < n; i++) {
            vector<int> dpNew(3);
            for (int j = 0; j < 3; j++) {
                dpNew[j] = min(dp[(j + 1) % 3], dp[(j + 2) % 3]) + costs[i][j];
            }
            dp = dpNew;
        }
        return *min_element(dp.begin(), dp.end());
    }
};
```

```C
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int minCost(int** costs, int costsSize, int* costsColSize) {
    int dp[3];
    for (int j = 0; j < 3; j++) {
        dp[j] = costs[0][j];
    }
    for (int i = 1; i < costsSize; i++) {
        int dpNew[3];
        for (int j = 0; j < 3; j++) {
            dpNew[j] = MIN(dp[(j + 1) % 3], dp[(j + 2) % 3]) + costs[i][j];
        }
        memcpy(dp, dpNew, sizeof(dpNew));
    }
    int res = INT_MAX;
    for (int i = 0; i < 3; i++) {
        res = MIN(res, dp[i]);
    }
    return res;
}
```

```JavaScript
var minCost = function(costs) {
    const n = costs.length;
    let dp = new Array(3).fill(0);
    for (let j = 0; j < 3; j++) {
        dp[j] = costs[0][j];
    }
    for (let i = 1; i < n; i++) {
        const dpNew = new Array(3).fill(0);
        for (let j = 0; j < 3; j++) {
            dpNew[j] = Math.min(dp[(j + 1) % 3], dp[(j + 2) % 3]) + costs[i][j];
        }
        dp = dpNew;
    }
    return parseInt(_.min(dp));
};
```

```Go
func minCost(costs [][]int) int {
    dp := costs[0]
    for _, cost := range costs[1:] {
        dpNew := make([]int, 3)
        for j, c := range cost {
            dpNew[j] = min(dp[(j+1)%3], dp[(j+2)%3]) + c
        }
        dp = dpNew
    }
    return min(min(dp[0], dp[1]), dp[2])
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是房子个数。需要遍历全部房子一次，由于颜色数量固定是三种，因此对于每个房子计算粉刷房子的最小花费成本的时间是 $O(1)$，总时间复杂度是 $O(n)$。
- 空间复杂度：$O(1)$。使用空间优化的方法，只需要维护一个长度为 $3$ 的数组，空间复杂度是 $O(1)$。
