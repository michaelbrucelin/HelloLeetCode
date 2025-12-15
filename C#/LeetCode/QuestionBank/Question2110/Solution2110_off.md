### [股票平滑下跌阶段的数目](https://leetcode.cn/problems/number-of-smooth-descent-periods-of-a-stock/solutions/1167833/gu-piao-ping-hua-xia-die-jie-duan-de-shu-w3hi/)

#### 方法一：动态规划

**思路与算法**

为了避免重复或者遗漏，我们可以统计数组 $prices$ 以每一天为**结尾**的平滑下降阶段的数目，这些数目之和即为数组中平滑下降阶段的总数。

我们可以用动态规划的方法求出以每一天为结尾的平滑下降阶段的数目。具体地，我们可以用 $dp$ 数组来存储这些数目，其中 $dp[i]$ 代表第 $i$ 天为结尾对应的数目。当 $i=0$ 时，显然有 $dp[0]=1$，即该天本身组成的阶段。对于 $i>0$ 的情况，考虑到长度大于 $1$ 的平滑下降阶段要求每一天价格都需要比前一天少 $1$，因此我们可以考虑第 $i-1$ 天的价格 $prices[i-1]$ 与第 $i$ 天的价格 $prices[i]$ 之间的关系。具体地：

- 如果 $prices[i]\ne prices[i-1]-1$，那么第 $i$ 天无法与第 $i-1$ 天构成平滑下跌阶段，因此以 $i$ 结尾的平滑下跌阶段只有 $i$ 本身，因此 $dp[i]=1$；
- 如果 $prices[i]=prices[i-1]-1$，那么不仅第 $i$ 天自身可以构成平滑下跌的阶段，**任何**以第 $i-1$ 天结尾的平滑下跌阶段都可以加上 $i$ 构成新的以第 $i$ 天结尾的平滑下跌阶段。根据 $dp$ 数组的定义，后者共 $dp[i-1]$ 个，因此此时 $dp[i]=dp[i-1]+1$。

综上可得：

$$dp[i]=\begin{cases}1, & i=0 \\ 1, & i>0, prices[i]\ne prices[i-1]-1 \\ dp[i-1]+1, & i>0, prices[i]=prices[i-1]-1\end{cases}$$

我们只需利用上述的递推式遍历 $prices$ 并维护对应的 $dp$ 数组，同时用 $res$ 维护 $dp$ 数组的元素之和，即为平滑下降阶段的总数。

由于 $dp[i]$ **仅依赖于** $dp[i-1]$，因此我们并不需要显式地维护 $dp$ 数组，只需要在递推的时候用整数 $prev$ 维护 $dp[i-1]$ 即可。我们从 $i=1$ 开始遍历数组下标，此时 $prev$ 的初值为 $dp[0]=1$，与此同时 $res$ 的初值也为 $1$。在遍历至下标 $i$，我们首先按照上文的递推式将 $prev$ 更新为 $dp[i]$，然后将 $res$ 加上 $prev$ 的当前值。在遍历完成之后，$res$ 即为平滑下降阶段的总数，我们返回该数值作为答案。

**细节**

考虑到数据范围，$res$ 的数值有可能超过 $32$ 位有符号整数的上界，因此我们需要使用 $64$ 位整数来维护。

**代码**

```C++
class Solution {
public:
    long long getDescentPeriods(vector<int>& prices) {
        int n = prices.size();
        long long res = 1;   // 平滑下降阶段的总数，初值为 dp[0]
        int prev = 1;   // 上一个元素为结尾的平滑下降阶段的总数，初值为 dp[0]
        // 从 1 开始遍历数组，按照递推式更新 prev 以及总数 res
        for (int i = 1; i < n; ++i) {
            if (prices[i] == prices[i-1] - 1) {
                ++prev;    
            }
            else {
                prev = 1;
            }
            res += prev;
        }
        return res;
    }
};
```

```Python
class Solution:
    def getDescentPeriods(self, prices: List[int]) -> int:
        n = len(prices)
        res = 1   # 平滑下降阶段的总数，初值为 dp[0]
        prev = 1   # 上一个元素为结尾的平滑下降阶段的总数，初值为 dp[0]
        # 从 1 开始遍历数组，按照递推式更新 prev 以及总数 res
        for i in range(1, n):
            if prices[i] == prices[i-1] - 1:
                prev += 1
            else:
                prev = 1
            res += prev
        return res
```

```Java
class Solution {
    public long getDescentPeriods(int[] prices) {
        int n = prices.length;
        long res = 1;   // 平滑下降阶段的总数，初值为 dp[0]
        int prev = 1;   // 上一个元素为结尾的平滑下降阶段的总数，初值为 dp[0]
        // 从 1 开始遍历数组，按照递推式更新 prev 以及总数 res
        for (int i = 1; i < n; ++i) {
            if (prices[i] == prices[i - 1] - 1) {
                ++prev;    
            } else {
                prev = 1;
            }
            res += prev;
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long GetDescentPeriods(int[] prices) {
        int n = prices.Length;
        long res = 1;   // 平滑下降阶段的总数，初值为 dp[0]
        int prev = 1;   // 上一个元素为结尾的平滑下降阶段的总数，初值为 dp[0]
        // 从 1 开始遍历数组，按照递推式更新 prev 以及总数 res
        for (int i = 1; i < n; ++i) {
            if (prices[i] == prices[i - 1] - 1) {
                ++prev;    
            } else {
                prev = 1;
            }
            res += prev;
        }
        return res;
    }
}
```

```Go
func getDescentPeriods(prices []int) int64 {
    n := len(prices)
    res := int64(1)   // 平滑下降阶段的总数，初值为 dp[0]
    prev := 1   // 上一个元素为结尾的平滑下降阶段的总数，初值为 dp[0]
    // 从 1 开始遍历数组，按照递推式更新 prev 以及总数 res
    for i := 1; i < n; i++ {
        if prices[i] == prices[i - 1] - 1 {
            prev++    
        } else {
            prev = 1
        }
        res += int64(prev)
    }
    return res
}
```

```C
long long getDescentPeriods(int* prices, int pricesSize) {
    int n = pricesSize;
    long long res = 1;   // 平滑下降阶段的总数，初值为 dp[0]
    int prev = 1;   // 上一个元素为结尾的平滑下降阶段的总数，初值为 dp[0]
    // 从 1 开始遍历数组，按照递推式更新 prev 以及总数 res
    for (int i = 1; i < n; ++i) {
        if (prices[i] == prices[i - 1] - 1) {
            ++prev;    
        } else {
            prev = 1;
        }
        res += prev;
    }
    return res;
}
```

```JavaScript
var getDescentPeriods = function(prices) {
    const n = prices.length;
    let res = 1;   // 平滑下降阶段的总数，初值为 dp[0]
    let prev = 1;   // 上一个元素为结尾的平滑下降阶段的总数，初值为 dp[0]
    // 从 1 开始遍历数组，按照递推式更新 prev 以及总数 res
    for (let i = 1; i < n; ++i) {
        if (prices[i] === prices[i - 1] - 1) {
            ++prev;    
        } else {
            prev = 1;
        }
        res += prev;
    }
    return res;
};
```

```TypeScript
function getDescentPeriods(prices: number[]): number {
    const n = prices.length;
    let res: number = 1;   // 平滑下降阶段的总数，初值为 dp[0]
    let prev: number = 1;   // 上一个元素为结尾的平滑下降阶段的总数，初值为 dp[0]
    // 从 1 开始遍历数组，按照递推式更新 prev 以及总数 res
    for (let i = 1; i < n; ++i) {
        if (prices[i] === prices[i - 1] - 1) {
            ++prev;    
        } else {
            prev = 1;
        }
        res += prev;
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn get_descent_periods(prices: Vec<i32>) -> i64 {
        let n = prices.len();
        let mut res: i64 = 1;   // 平滑下降阶段的总数，初值为 dp[0]
        let mut prev: i32 = 1;   // 上一个元素为结尾的平滑下降阶段的总数，初值为 dp[0]
        // 从 1 开始遍历数组，按照递推式更新 prev 以及总数 res
        for i in 1..n {
            if prices[i] == prices[i - 1] - 1 {
                prev += 1;    
            } else {
                prev = 1;
            }
            res += prev as i64;
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $prices$ 的长度。即为计算每个元素结尾的平滑下降阶段数目并求和的时间复杂度。
- 空间复杂度：$O(1)$。
