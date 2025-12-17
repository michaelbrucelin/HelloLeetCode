### [买卖股票的最佳时机 V](https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-v/solutions/3854340/mai-mai-gu-piao-de-zui-jia-shi-ji-v-by-l-di11/)

#### 方法一：记忆化搜索

**思路与算法**

本题与「[188\. 买卖股票的最佳时机 IV](https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-iv/description/)」题面非常类似，唯一不同的是本题多了一个额外的**做空交易**。

根据「[188\. 买卖股票的最佳时机 IV](https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-iv/description/)」的题解可知，动态规划状态定义如下：

- 经过 $i$ 天后，进行恰好 $j$ 笔交易，并且当前手上不持有股票的最大利润 $dfs(i,j,0)$；
- 经过 $i$ 天后，进行恰好 $j$ 笔交易，并且当前手上持有一只股票的最大利润 $dfs(i,j,1)$；

由于本题中多了一个**做空交易**操作，即先卖出股票，后买入股票，此时我们可以定义一个新的状态：

- 经过 $i$ 天后，进行恰好 $j$ 笔交易，并且当前手上已卖出一只股票（做空中）的最大利润 $dfs(i,j,2)$；

根据上述状态定义，对于第 $i$ 天，进行恰好 $j$ 笔交易，此时我们需要考虑以下三种情况：

- 第 $i$ 天不进行任何操作，既没有买入股票也没有卖出股票，保持当前的状态，此时第 $i$ 天的最大利润与前一天相同，此时状态转移方程为：
  - $dfs(i,j,0)=dfs(i-1,j,0)$
  - $dfs(i,j,1)=dfs(i-1,j,1)$
  - $dfs(i,j,2)=dfs(i-1,j,2)$
- 第 $i$ 天买入股票，此时可以从两种状态转移而来：
  - 前一天结束时手上不持有股票，此时开始第 $j$ 次**普通交易**，那么我们需要从状态 $dfs(i-1,j-1,0)$ 转移而来，并且需要扣除 $prices[i]$ 的花费，此时状态转移方程为：
    - $dfs(i,j,1)=dfs(i-1,j-1,0)-prices[i]$
  - 前一天结束时手上已卖出了一只股票，处于做空中，此时买入股票完成第 $j$ 次**做空交易**，那么我们需要从状态 $dfs(i-1,j,2)$ 转移而来，此时利润需要减去 $prices[i]$ 的花费，此时状态转移方程为：
    - $dfs(i,j,0)=dfs(i-1,j,2)-prices[i]$
- 第 $i$ 天卖出股票，此时可以从两种状态转移而来：
  - 前一天结束时手上持有一只股票，此时卖出股票完成第 $j$ 次**普通交易**，那么我们需要从状态 $dfs(i-1,j,1)$ 转移而来，并且需要增加 $prices[i]$ 的收益，此时状态转移方程为：
    - $dfs(i,j,0)=dfs(i-1,j,1)+prices[i]$
  - 前一天结束时手上不持有股票，此时卖出股票开始第 $j$ 次**做空交易**，那么我们需要从状态 $dfs(i-1,j-1,0)$ 转移而来，并且需要增加 $prices[i]$ 的收益，此时状态转移方程为：
    - $dfs(i,j,2)=dfs(i-1,j-1,0)+prices[i]$

根据上述状态分析可知，最终的动态规划转移方程如下：

$$dfs(i,j,0)=max(dfs(i-1,j,0),dfs(i-1,j,1)+prices[i],dfs(i-1,j,2)-prices[i]) \\ dfs(i,j,1)=max(dfs(i-1,j,1),dfs(i-1,j-1,0)-prices[i]) \\ dfs(i,j,2)=max(dfs(i-1,j,2),dfs(i-1,j-1,1)+prices[i])$$

在第 $0$ 天，此时只有一天的股票价格，此时如果不进行任何操作则最大利润是 $0$，如果买入股票则最大利润是 $-prices[0]$，如果做空股票则最大利润是 $prices[0]$；当 $j=0$ 时，此时由于没有产生任何交易，可以获取的最大利润一定是 $0$。此时可以规定边界条件如下：

- 当 $j=0$ 时，对于任意 $i$ 都有 $dfs(i,0,0)=dfs(i,0,1)=dfs(i,0,2)=0$。
- 当 $i=0$ 时，对于任意 $1\le j\le k$ 都有 $dfs(0,j,0)=0$，dfs(0,j,1)=-prices[0]，$dfs(0,j,2)=prices[0]$。

由于最多有只能进行 $k$ 笔交易且最后一天必须完成所有的交易（即手上必须不持有股票），因此最大利润是 $dfs(n-1,k,0)$，其中 $n$ 是数组 $prices$ 的长度，我们返回答案即可。

**代码**

```C++
class Solution {
public:
    long long maximumProfit(vector<int>& prices, int k) {
        int n = prices.size();
        vector<vector<vector<long long>>>memo(n, vector<vector<long long>>(k + 1, vector<long long>(3, -1)));

        function<long long(int, int, int)> dfs = [&](int i, int j, int state) -> long long {
            if (j == 0) {
                return 0;
            }
            if (i == 0) {
                return state == 0 ? 0 : (state == 1 ? -prices[0] : prices[0]);
            }
            if (memo[i][j][state] != -1) {
                return memo[i][j][state];
            }
            
            int p = prices[i];
            long long res;
            if (state == 0) {
                res = max(dfs(i - 1, j, 0), max(dfs(i - 1, j, 1) + p, dfs(i - 1, j, 2) - p));
            } else if (state == 1) {
                res = max(dfs(i - 1, j, 1), dfs(i - 1, j - 1, 0) - p);
            } else {
                res = max(dfs(i - 1, j, 2), dfs(i - 1, j - 1, 0) + p);
            }
            memo[i][j][state] = res;
            
            return res;
        };

        return dfs(n - 1, k, 0);
    }
};
```

```Java
class Solution {
    private int[] prices;
    private long[][][] memo;

    public long maximumProfit(int[] prices, int k) {
        this.prices = prices;
        int n = prices.length;
        memo = new long[n][k + 1][3];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= k; j++) {
                for (int s = 0; s < 3; s++) {
                    memo[i][j][s] = -1;
                }
            }
        }
        return dfs(n - 1, k, 0);
    }

    private long dfs(int i, int j, int state) {
        if (j == 0) {
            return 0;
        }
        if (i == 0) {
            return state == 0 ? 0 : (state == 1 ? -prices[0] : prices[0]);
        }
        if (memo[i][j][state] != -1) {
            return memo[i][j][state];
        }
        
        int p = prices[i];
        long res;
        if (state == 0) {
            res = Math.max(dfs(i - 1, j, 0), Math.max(dfs(i - 1, j, 1) + p, dfs(i - 1, j, 2) - p));
        } else if (state == 1) {
            res = Math.max(dfs(i - 1, j, 1), dfs(i - 1, j - 1, 0) - p);
        } else {
            res = Math.max(dfs(i - 1, j, 2), dfs(i - 1, j - 1, 0) + p);
        }
        memo[i][j][state] = res;
        return res;
    }
}
```

```CSharp
public class Solution {
    private int[] prices;
    private long[,,] memo;
    
    public long MaximumProfit(int[] prices, int k) {
        this.prices = prices;
        int n = prices.Length;
        memo = new long[n, k + 1, 3];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= k; j++) {
                for (int s = 0; s < 3; s++) {
                    memo[i, j, s] = -1;
                }
            }
        }
        return Dfs(n - 1, k, 0);
    }
    
    private long Dfs(int i, int j, int state) {
        if (j == 0) {
            return 0;
        }
        if (i == 0) {
            return state == 0 ? 0 : (state == 1 ? -prices[0] : prices[0]);
        }

        long res = memo[i, j, state];
        if (res != -1) {
            return res;
        }

        int p = prices[i];
        if (state == 0) {
            res = Math.Max(Dfs(i - 1, j, 0), Math.Max(Dfs(i - 1, j, 1) + p, Dfs(i - 1, j, 2) - p));
        } else if (state == 1) {
            res = Math.Max(Dfs(i - 1, j, 1), Dfs(i - 1, j - 1, 0) - p);
        } else {
            res = Math.Max(Dfs(i - 1, j, 2), Dfs(i - 1, j - 1, 0) + p);
        }
        memo[i, j, state] = res;
        return res;
    }
}
```

```Go
func maximumProfit(prices []int, k int) int64 {
    n := len(prices)
    memo := make([][][]int64, n)
    for i := range memo {
        memo[i] = make([][]int64, k+1)
        for j := range memo[i] {
            memo[i][j] = make([]int64, 3)
            for s := range memo[i][j] {
                memo[i][j][s] = -1
            }
        }
    }
    
    var dfs func(int, int, int) int64
    dfs = func(i, j, state int) int64 {
        if j == 0 {
            return 0
        }
        if i == 0 {
            if state == 0 {
                return 0
            } else if state == 1 {
                return -int64(prices[0])
            } else {
                return int64(prices[0])
            }
        }
        if memo[i][j][state] != -1 {
            return memo[i][j][state]
        }
        
        p := prices[i]
        var res int64
        if state == 0 {
            res = max(dfs(i - 1, j, 0), max(dfs(i - 1, j, 1) + int64(p), dfs(i - 1, j, 2) - int64(p)))
        } else if state == 1 {
            res = max(dfs(i - 1, j, 1), dfs(i - 1, j - 1, 0) - int64(p))
        } else {
            res = max(dfs(i - 1, j, 2), dfs(i - 1, j - 1, 0) + int64(p))
        }
        memo[i][j][state] = res
        return res
    }
    
    return dfs(n-1, k, 0)
}
```

```Python
class Solution:
    def maximumProfit(self, prices: List[int], k: int) -> int:
        n = len(prices)

        @cache
        def dfs(i, j, state):
            if j == 0:
                return 0
            if i == 0:
                return 0 if state == 0 else -prices[0] if state == 1 else prices[0]
            p = prices[i]
            if state == 0:
                res = max(dfs(i - 1, j, 0), dfs(i - 1, j, 1) + p, dfs(i - 1, j, 2) - p)
            elif state == 1:
                res = max(dfs(i - 1, j, 1), dfs(i - 1, j - 1, 0) - p)
            else:
                res = max(dfs(i - 1, j, 2), dfs(i - 1, j - 1, 0) + p)

            return res

        ans = dfs(n - 1, k, 0)
        dfs.cache_clear()
        return ans
```

```C
long long dfs(long long ***memo, int* prices, int n, int i, int j, int state) {
    if (j == 0) {
        return 0;
    }
    if (i == 0) {
        return state == 0 ? 0 : (state == 1 ? -prices[0] : prices[0]);
    }
    if (memo[i][j][state] != -1) {
        return memo[i][j][state];
    }
    int p = prices[i];
    long long res;
    if (state == 0) {
        long long a = dfs(memo, prices, n, i - 1, j, 0);
        long long b = dfs(memo, prices, n, i - 1, j, 1) + p;
        long long c = dfs(memo, prices, n, i - 1, j, 2) - p;
        res = fmax(a, fmax(b, c));
    } else if (state == 1) {
        long long a = dfs(memo, prices, n, i - 1, j, 1);
        long long b = dfs(memo, prices, n, i - 1, j - 1, 0) - p;
        res = fmax(a, b);
    } else {
        long long a = dfs(memo, prices, n, i - 1, j, 2);
        long long b = dfs(memo, prices, n, i - 1, j - 1, 0) + p;
        res = fmax(a, b);
    }
    memo[i][j][state] = res;
    return res;
}

long long maximumProfit(int* prices, int pricesSize, int k) {
    long long ***memo = (long long ***)malloc(sizeof(long long **) * pricesSize);
    for (int i = 0; i < pricesSize; i++) {
        memo[i] = (long long**)malloc(sizeof(long long *) * (k + 1));
        for (int j = 0; j <= k; j++) {
            memo[i][j] = (long long*)malloc(sizeof(long long) * 3);
            memset(memo[i][j], -1, sizeof(long long) * 3);
        }
    }

    long long ret = dfs(memo, prices, pricesSize, pricesSize - 1, k, 0);
    for (int i = 0; i < pricesSize; i++) {
        for (int j = 0; j <= k; j++) {
            free(memo[i][j]);
        }
        free(memo[i]);
    }

    return ret;
}
```

```JavaScript
var maximumProfit = function(prices, k) {
    const n = prices.length;
    const memo = Array(n).fill().map(() => 
        Array(k + 1).fill().map(() => 
            Array(3).fill(-1)
        )
    );
    
    const dfs = (i, j, state) => {
        if (j == 0) {
            return 0;
        }
        if (i == 0) {
            return state == 0 ? 0 : (state == 1 ? -prices[0] : prices[0]);
        }
        if (memo[i][j][state] !== -1) {
            return memo[i][j][state];
        }
        const p = prices[i];
        let res;
        if (state === 0) {
            res = Math.max(
                dfs(i - 1, j, 0),
                Math.max(dfs(i - 1, j, 1) + p, dfs(i - 1, j, 2) - p)
            );
        } else if (state === 1) {
            res = Math.max(dfs(i - 1, j, 1), dfs(i - 1, j - 1, 0) - p);
        } else {
            res = Math.max(dfs(i - 1, j, 2), dfs(i - 1, j - 1, 0) + p);
        }
        memo[i][j][state] = res;
        return res;
    };
    
    return dfs(n - 1, k, 0);
};
```

```TypeScript
function maximumProfit(prices: number[], k: number): number {
    const n = prices.length;
    const memo: number[][][] = Array(n).fill(null).map(() => 
        Array(k + 1).fill(null).map(() => 
            Array(3).fill(-1)
        )
    );
    
    const dfs = (i: number, j: number, state: number): number => {
        if (j == 0) {
            return 0;
        }
        if (i == 0) {
            return state == 0 ? 0 : (state == 1 ? -prices[0] : prices[0]);
        }
        if (memo[i][j][state] !== -1) {
            return memo[i][j][state];
        }
        const p = prices[i];
        let res: number;
        if (state === 0) {
            res = Math.max(
                dfs(i - 1, j, 0),
                Math.max(dfs(i - 1, j, 1) + p, dfs(i - 1, j, 2) - p)
            );
        } else if (state === 1) {
            res = Math.max(dfs(i - 1, j, 1), dfs(i - 1, j - 1, 0) - p);
        } else {
            res = Math.max(dfs(i - 1, j, 2), dfs(i - 1, j - 1, 0) + p);
        }
        memo[i][j][state] = res;
        return res;
    };
    
    return dfs(n - 1, k, 0);
}
```

```Rust
impl Solution {
    pub fn maximum_profit(prices: Vec<i32>, k: i32) -> i64 {
        let n = prices.len();
        let k = k as usize;
        let mut memo = vec![vec![vec![-1; 3]; k + 1]; n];
        
        fn dfs(i: i32, j: i32, state: i32, prices: &Vec<i32>, memo: &mut Vec<Vec<Vec<i64>>>) -> i64 {
            let i_usize = i as usize;
            let j_usize = j as usize;
            let state_usize = state as usize;
            
            if j_usize == 0 {
                return 0;
            }
            if i_usize == 0 {
                return if state_usize == 0 { 0 } else if state_usize == 1 { -prices[0] as i64 } else { prices[0] as i64 };
            }
            if memo[i_usize][j_usize][state_usize] != -1 {
                return memo[i_usize][j_usize][state_usize];
            }
            
            let p = prices[i_usize] as i64;
            let res = match state {
                0 => {
                    let a = dfs(i - 1, j, 0, prices, memo);
                    let b = dfs(i - 1, j, 1, prices, memo) + p;
                    let c = dfs(i - 1, j, 2, prices, memo) - p;
                    a.max(b).max(c)
                }
                1 => {
                    let a = dfs(i - 1, j, 1, prices, memo);
                    let b = dfs(i - 1, j - 1, 0, prices, memo) - p;
                    a.max(b)
                }
                _ => {
                    let a = dfs(i - 1, j, 2, prices, memo);
                    let b = dfs(i - 1, j - 1, 0, prices, memo) + p;
                    a.max(b)
                }
            };
            memo[i_usize][j_usize][state_usize] = res;
            res
        }
        
        dfs(n as i32 - 1, k as i32, 0, &prices, &mut memo)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nk)$，其中 $n$ 表示给定数组 $prices$ 的长度，$ k$ 表示给定的数。记忆化搜索一共有 $3\times n\times k$ 个子状态，因此时间复杂度为 $O(nk)$。
- 空间复杂度：$O(nk)$，其中 $n$ 表示给定数组 $prices$ 的长度，$ k$ 表示给定的数。记忆化搜索一共需要存储 $3\times n\times k$ 个子状态，因此最多需要的空间为 $O(nk)$。

#### 方法二：动态规划

**思路与算法**

同样地，我们可以使用自底向上的动态规划的方法求解，将记忆化搜索递归展开即可。

**代码**

```C++
class Solution {
public:
    long long maximumProfit(vector<int>& prices, int k) {
        int n = prices.size();
        vector<vector<vector<long long>>> dp(n, vector<vector<long long>>(k + 1, vector<long long>(3, 0)));
        // 初始化第 0 天的状态
        for (int j = 1; j <= k; j++) {
            dp[0][j][1] = -prices[0];
            dp[0][j][2] = prices[0];
        }
        
        for (int i = 1; i < n; i++) {
            for (int j = 1; j <= k; j++) {
                dp[i][j][0] = max(dp[i - 1][j][0], max(dp[i - 1][j][1] + prices[i], dp[i - 1][j][2] - prices[i]));
                dp[i][j][1] = max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i]);
                dp[i][j][2] = max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + prices[i]);                
            }
        }
        
        return dp[n - 1][k][0];
    }
};
```

```Java
class Solution {
    public long maximumProfit(int[] prices, int k) {
        int n = prices.length;
        long[][][] dp = new long[n][k + 1][3];
        
        // 初始化第 0 天的状态
        for (int j = 1; j <= k; j++) {
            dp[0][j][1] = -prices[0];
            dp[0][j][2] = prices[0];
        }
        for (int i = 1; i < n; i++) {
            for (int j = 1; j <= k; j++) {
                dp[i][j][0] = Math.max(dp[i - 1][j][0], Math.max(dp[i - 1][j][1] + prices[i], dp[i - 1][j][2] - prices[i]));
                dp[i][j][1] = Math.max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i]);
                dp[i][j][2] = Math.max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + prices[i]);
            }
        }
        
        return dp[n - 1][k][0];
    }
}
```

```CSharp
using System;

public class Solution {
    public long MaximumProfit(int[] prices, int k) {
        int n = prices.Length;
        long[,,] dp = new long[n, k + 1, 3];
        
        // 初始化第 0 天的状态    
        for (int j = 1; j <= k; j++) {
            dp[0, j, 1] = -prices[0];
            dp[0, j, 2] = prices[0];
        }
        for (int i = 1; i < n; i++) {
            for (int j = 1; j <= k; j++) {
                dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], Math.Max(dp[i - 1, j, 1] + prices[i], dp[i - 1, j, 2] - prices[i]));
                dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i]);
                dp[i, j, 2] = Math.Max(dp[i - 1, j, 2], dp[i - 1, j - 1, 0] + prices[i]);
            }
        }
        
        return dp[n - 1, k, 0];
    }
}
```

```Go
func maximumProfit(prices []int, k int) int64 {
    n := len(prices)
    dp := make([][][]int64, n)
    for i := range dp {
        dp[i] = make([][]int64, k + 1)
        for j := range dp[i] {
            dp[i][j] = make([]int64, 3)
        }
    }
    
    // 初始化第 0 天的状态
    for j := 1; j <= k; j++ {
        dp[0][j][1] = int64(-prices[0])
        dp[0][j][2] = int64(prices[0])
    }
    
    for i := 1; i < n; i++ {
        for j := 1; j <= k; j++ {
            dp[i][j][0] = max(dp[i - 1][j][0], max(dp[i-1][j][1] + int64(prices[i]), dp[i - 1][j][2] - int64(prices[i])))
            dp[i][j][1] = max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - int64(prices[i]))
            dp[i][j][2] = max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + int64(prices[i]))
        }
    }
    
    return dp[n - 1][k][0]
}
```

```Python
class Solution:
    def maximumProfit(self, prices: List[int], k: int) -> int:
        n = len(prices)
        dp = [[[0] * 3 for _ in range(k + 1)] for _ in range(n)]
        
        # 初始化第 0 天的状态       
        for j in range(1, k + 1):
            dp[0][j][1] = -prices[0]
            dp[0][j][2] = prices[0]
        
        for i in range(1, n):
            for j in range(1, k + 1):
                dp[i][j][0] = max(dp[i - 1][j][0], max(dp[i - 1][j][1] + prices[i], dp[i - 1][j][2] - prices[i]))
                dp[i][j][1] = max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i])
                dp[i][j][2] = max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + prices[i])
        
        return dp[n - 1][k][0]
```

```C
long long max(long long a, long long b) {
    return a > b ? a : b;
}

long long maximumProfit(int* prices, int pricesSize, int k) {
    int n = pricesSize;
    long long dp[n][k + 1][3];
    memset(dp, 0, sizeof(dp));

    // 初始化第 0 天的状态         
    for (int j = 1; j <= k; j++) {
        dp[0][j][1] = -(long long)prices[0];
        dp[0][j][2] = (long long)prices[0];
    }

    for (int i = 1; i < n; i++) {
        for (int j = 1; j <= k; j++) {
            dp[i][j][0] = max(dp[i - 1][j][0], max(dp[i - 1][j][1] + prices[i], dp[i - 1][j][2] - prices[i]));
            dp[i][j][1] = max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i]);
            dp[i][j][2] = max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + prices[i]);
        }
    }
    
    return dp[n - 1][k][0];
}
```

```JavaScript
var maximumProfit = function(prices, k) {
    const n = prices.length;
    const dp = new Array(n);
    for (let i = 0; i < n; i++) {
        dp[i] = new Array(k + 1);
        for (let j = 0; j <= k; j++) {
            dp[i][j] = new Array(3).fill(0);
        }
    }

    // 初始化第 0 天的状态 
    for (let j = 1; j <= k; j++) {
        dp[0][j][1] = -prices[0];
        dp[0][j][2] = prices[0];
    }
    for (let i = 1; i < n; i++) {
        for (let j = 1; j <= k; j++) {
            dp[i][j][0] = Math.max(dp[i - 1][j][0], Math.max(dp[i - 1][j][1] + prices[i], dp[i - 1][j][2] - prices[i]));
            dp[i][j][1] = Math.max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i]);
            dp[i][j][2] = Math.max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + prices[i]);
        }
    }
    
    return dp[n - 1][k][0];
};
```

```TypeScript
function maximumProfit(prices: number[], k: number): number {
    const n: number = prices.length;
    const dp: number[][][] = new Array(n);
    for (let i = 0; i < n; i++) {
        dp[i] = new Array(k + 1);
        for (let j = 0; j <= k; j++) {
            dp[i][j] = new Array(3).fill(0);
        }
    }
    
    // 初始化第 0 天的状态 
    for (let j = 1; j <= k; j++) {
        dp[0][j][1] = -prices[0];
        dp[0][j][2] = prices[0];
    }
    
    for (let i = 1; i < n; i++) {
        for (let j = 1; j <= k; j++) {
            dp[i][j][0] = Math.max(dp[i - 1][j][0], Math.max(dp[i - 1][j][1] + prices[i], dp[i - 1][j][2] - prices[i]));
            dp[i][j][1] = Math.max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i]);
            dp[i][j][2] = Math.max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + prices[i]);
        }
    }
    
    return dp[n - 1][k][0];
}
```

```Rust
use std::cmp::max;

impl Solution {
    pub fn maximum_profit(prices: Vec<i32>, k: i32) -> i64 {
        let n = prices.len();
        let k = k as usize;
        let mut dp = vec![vec![vec![0i64; 3]; k + 1]; n];
        
        // 初始化第 0 天的状态 
        for j in 1..=k {
            dp[0][j][1] = -(prices[0] as i64);
            dp[0][j][2] = prices[0] as i64;
        }
        
        for i in 1..n {
            let val = prices[i] as i64;
            for j in 1..=k {
                dp[i][j][0] = max(dp[i - 1][j][0], max(dp[i - 1][j][1] + val, dp[i - 1][j][2] - val));
                dp[i][j][1] = max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - val);
                dp[i][j][2] = max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + val);
            }
        }
        
        dp[n - 1][k][0]
    }
}
```

我们观察到第 $i$ 天的最优状态仅仅取决于 $i-1$ 天的最优状态，与更早时间的最优状态无关，此时我们可以使用滚动数组，只保留前一天的最优状态，从而降低空间复杂度，此时空间复杂度降为 $O(k)$。实际遍历时，我们可以按照 $j$ 从大到小的顺序依次计算，不需要创建临时变量。

```C++
class Solution {
public:
    long long maximumProfit(vector<int>& prices, int k) {
        int n = prices.size();
        vector<vector<long long>> dp(k + 1, vector<long long>(3));
        // 初始化第 0 天的状态 
        for (int j = 1; j <= k; j++) {
            dp[j][1] = -prices[0];
            dp[j][2] = prices[0];
        }
        for (int i = 1; i < n; i++) {
            for (int j = k; j > 0; j--) {
                dp[j][0] = max(dp[j][0], max(dp[j][1] + prices[i], dp[j][2] - prices[i]));
                dp[j][1] = max(dp[j][1], dp[j - 1][0] - prices[i]);
                dp[j][2] = max(dp[j][2], dp[j - 1][0] + prices[i]);  
            }
        }
        
        return dp[k][0];
    }
};
```

```Java
class Solution {
    public long maximumProfit(int[] prices, int k) {
        int n = prices.length;
        long[][] dp = new long[k + 1][3];
        // 初始化第 0 天的状态
        for (int j = 1; j <= k; j++) {
            dp[j][1] = -prices[0];  
            dp[j][2] = prices[0]; 
        }
        for (int i = 1; i < n; i++) {
            for (int j = k; j > 0; j--) {
                dp[j][0] = Math.max(dp[j][0], Math.max(dp[j][1] + prices[i], dp[j][2] - prices[i]));
                dp[j][1] = Math.max(dp[j][1], dp[j - 1][0] - prices[i]);
                dp[j][2] = Math.max(dp[j][2], dp[j - 1][0] + prices[i]);
            }
        }
        
        return dp[k][0];
    }
}
```

```CSharp
public class Solution {
    public long MaximumProfit(int[] prices, int k) {
        int n = prices.Length;
        long[,] dp = new long[k + 1, 3];
        // 初始化第 0 天的状态
        for (int j = 1; j <= k; j++) {
            dp[j, 1] = -prices[0];  
            dp[j, 2] = prices[0]; 
        }
        
        for (int i = 1; i < n; i++) {
            for (int j = k; j > 0; j--) {
                dp[j, 0] = Math.Max(dp[j, 0], Math.Max(dp[j, 1] + prices[i], dp[j, 2] - prices[i]));
                dp[j, 1] = Math.Max(dp[j, 1], dp[j - 1, 0] - prices[i]);
                dp[j, 2] = Math.Max(dp[j, 2], dp[j - 1, 0] + prices[i]);
            }
        }
        
        return dp[k, 0];
    }
}
```

```Go
func maximumProfit(prices []int, k int) int64 {
    n := len(prices)
    dp := make([][3]int64, k + 1)
    // 初始化第 0 天的状态
    for j := 1; j <= k; j++ {
        dp[j][1] = int64(-prices[0])
        dp[j][2] = int64(prices[0])
    }
    
    for i := 1; i < n; i++ {
        for j := k; j > 0; j-- {
            dp[j][0] = max(dp[j][0], max(dp[j][1] + int64(prices[i]), dp[j][2] - int64(prices[i])))
            dp[j][1] = max(dp[j][1], dp[j - 1][0] - int64(prices[i]))
            dp[j][2] = max(dp[j][2], dp[j - 1][0] + int64(prices[i]))
        }
    }
    
    return dp[k][0]
}
```

```Python
class Solution:
    def maximumProfit(self, prices: List[int], k: int) -> int:
        n = len(prices)
        dp = [[0] * 3 for _ in range(k + 1)]
        # 初始化第 0 天的状态
        for j in range(1, k + 1):
            dp[j][1] = -prices[0]
            dp[j][2] = prices[0]
        
        for i in range(1, n):
            for j in range(k, 0, -1):
                dp[j][0] = max(dp[j][0], max(dp[j][1] + prices[i], dp[j][2] - prices[i]))
                dp[j][1] = max(dp[j][1], dp[j - 1][0] - prices[i])
                dp[j][2] = max(dp[j][2], dp[j - 1][0] + prices[i])
        
        return dp[k][0]
```

```C
long long maximumProfit(int* prices, int pricesSize, int k) {
    long long** dp = (long long**)malloc((k + 1) * sizeof(long long*));
    // 初始化第 0 天的状态
    for (int i = 0; i <= k; i++) {
        dp[i] = (long long*)malloc(3 * sizeof(long long));
        memset(dp[i], 0, 3 * sizeof(long long));
    }
    for (int j = 1; j <= k; j++) {
        dp[j][1] = -prices[0];
        dp[j][2] = prices[0];
    }
    
    for (int i = 1; i < pricesSize; i++) {
        for (int j = k; j > 0; j--) {
            dp[j][0] = fmax(dp[j][0], fmax(dp[j][1] + prices[i], dp[j][2] - prices[i]));
            dp[j][1] = fmax(dp[j][1], dp[j - 1][0] - prices[i]);
            dp[j][2] = fmax(dp[j][2], dp[j - 1][0] + prices[i]);
        }
    }
    
    long long result = dp[k][0];
    for (int i = 0; i <= k; i++) {
        free(dp[i]);
    }
    free(dp);
    
    return result;
}
```

```JavaScript
var maximumProfit = function(prices, k) {
    const n = prices.length;
    const dp = Array(k + 1).fill().map(() => [0, 0, 0]);
    // 初始化第 0 天的状态 
    for (let j = 1; j <= k; j++) {
        dp[j][1] = -prices[0]; 
        dp[j][2] = prices[0]; 
    }
    
    for (let i = 1; i < n; i++) {
        for (let j = k; j > 0; j--) {
            dp[j][0] = Math.max(dp[j][0], Math.max(dp[j][1] + prices[i], dp[j][2] - prices[i]));
            dp[j][1] = Math.max(dp[j][1], dp[j - 1][0] - prices[i]);
            dp[j][2] = Math.max(dp[j][2], dp[j - 1][0] + prices[i]);
        }
    }
    
    return dp[k][0];
};
```

```TypeScript
function maximumProfit(prices: number[], k: number): number {
    const n = prices.length;
    const dp: number[][] = Array(k + 1).fill(0).map(() => [0, 0, 0]);
    // 初始化第 0 天的状态 
    for (let j = 1; j <= k; j++) {
        dp[j][1] = -prices[0];
        dp[j][2] = prices[0];
    }
    
    for (let i = 1; i < n; i++) {
        for (let j = k; j > 0; j--) {
            dp[j][0] = Math.max(dp[j][0], Math.max(dp[j][1] + prices[i], dp[j][2] - prices[i]));
            dp[j][1] = Math.max(dp[j][1], dp[j - 1][0] - prices[i]);
            dp[j][2] = Math.max(dp[j][2], dp[j - 1][0] + prices[i]);
        }
    }
    
    return dp[k][0];
}
```

```Rust
impl Solution {
    pub fn maximum_profit(prices: Vec<i32>, k: i32) -> i64 {
        let n = prices.len();
        let k = k as usize;
        let mut dp = vec![vec![0_i64; 3]; k + 1];
        for j in 1..=k {
            dp[j][1] = -(prices[0] as i64);
            dp[j][2] = prices[0] as i64; 
        }
        
        for i in 1..n {
            for j in (1..=k).rev() {
                dp[j][0] = dp[j][0]
                    .max(dp[j][1] + prices[i] as i64)
                    .max(dp[j][2] - prices[i] as i64);
                dp[j][1] = dp[j][1].max(dp[j - 1][0] - prices[i] as i64);
                dp[j][2] = dp[j][2].max(dp[j - 1][0] + prices[i] as i64);
            }
        }
        
        dp[k][0]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nk)$，其中 $n$ 表示给定数组 $prices$ 的长度，$ k$ 表示给定的数。动态规划一共有 $3\times n\times k$ 个子状态，因此时间复杂度为 $O(nk)$。
- 空间复杂度：$O(k)$，其中 $k$ 表示给定的数。经过空间优化后，每次只需要存储 $3k$ 个状态，因此空间复杂度为 $O(k)$。
