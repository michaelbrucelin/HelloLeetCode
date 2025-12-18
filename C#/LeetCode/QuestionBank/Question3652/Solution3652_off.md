### [按策略买卖股票的最佳时机](https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-using-strategy/solutions/3852536/an-ce-lue-mai-mai-gu-piao-de-zui-jia-shi-9psd/)

#### 方法一：前缀和

令 $n$ 为数组 $prices$ 的长度，假设我们选择的 $k$ 个连续元素为区间 $[i-k+1,i]$ 内的元素（$i\ge k-1$），那么获得的利润由三部分构成：

1. 区间 $[0,i-k]$ 的所有 $strategy[j]\times prices[j]$ 之和
2. 区间 $[i-2k+1,i]$ 的所有 $prices[j]$ 之和
3. 区间 $[i+1,n-1]$ 的所有 $strategy[j]\times prices[j]$ 之和

我们使用数组 $profitSum$ 统计 $strategy[j]\times prices[j]$ 的前缀和，数组 $priceSum$ 统计 $prices[j]$ 的前缀和，依次枚举 $i$，利用前缀和数组计算获取的利润的三部分，返回最大的获得利润。

```C++
class Solution {
public:
    long long maxProfit(vector<int>& prices, vector<int>& strategy, int k) {
        int n = prices.size();
        vector<long long> profitSum(n + 1);
        vector<long long> priceSum(n + 1);
        for (int i = 0; i < n; i++) {
            profitSum[i + 1] = profitSum[i] + prices[i] * strategy[i];
            priceSum[i + 1] = priceSum[i] + prices[i];
        }
        long long res = profitSum[n];
        for (int i = k - 1; i < n; i++) {
            long long leftProfit = profitSum[i - k + 1];
            long long rightProfit = profitSum[n] - profitSum[i + 1];
            long long changeProfit = priceSum[i + 1] - priceSum[i - k / 2 + 1];
            res = max(res, leftProfit + changeProfit + rightProfit);
        }
        return res;
    }
};
```

```Go
func maxProfit(prices []int, strategy []int, k int) int64 {
    n := len(prices)
    profitSum := make([]int64, n + 1)
    priceSum := make([]int64, n + 1)
    for i := 0; i < n; i++ {
        profitSum[i + 1] = profitSum[i] + int64(prices[i]) * int64(strategy[i])
        priceSum[i + 1] = priceSum[i] + int64(prices[i])
    }
    res := profitSum[n]
    for i := k - 1; i < n; i++ {
        leftProfit := profitSum[i - k + 1]
        rightProfit := profitSum[n] - profitSum[i + 1]
        changeProfit := priceSum[i + 1] - priceSum[i - k / 2 + 1]
        res = max(res, leftProfit + changeProfit + rightProfit)
    }
    return res
}
```

```Python
class Solution:
    def maxProfit(self, prices: List[int], strategy: List[int], k: int) -> int:
        n = len(prices)
        profitSum = [0] * (n + 1)
        priceSum = [0] * (n + 1)
        for i in range(n):
            profitSum[i + 1] = profitSum[i] + prices[i] * strategy[i]
            priceSum[i + 1] = priceSum[i] + prices[i]
        res = profitSum[n]
        for i in range(k - 1, n):
            leftProfit = profitSum[i - k + 1]
            rightProfit = profitSum[n] - profitSum[i + 1]
            changeProfit = priceSum[i + 1] - priceSum[i - k // 2 + 1]
            res = max(res, leftProfit + changeProfit + rightProfit)
        return res
```

```Java
class Solution {
    public long maxProfit(int[] prices, int[] strategy, int k) {
        int n = prices.length;
        long[] profitSum = new long[n + 1];
        long[] priceSum = new long[n + 1];
        for (int i = 0; i < n; i++) {
            profitSum[i + 1] = profitSum[i] + (long)prices[i] * strategy[i];
            priceSum[i + 1] = priceSum[i] + prices[i];
        }
        long res = profitSum[n];
        for (int i = k - 1; i < n; i++) {
            long leftProfit = profitSum[i - k + 1];
            long rightProfit = profitSum[n] - profitSum[i + 1];
            long changeProfit = priceSum[i + 1] - priceSum[i - k / 2 + 1];
            res = Math.max(res, leftProfit + changeProfit + rightProfit);
        }
        return res;
    }
}
```

```TypeScript
function maxProfit(prices: number[], strategy: number[], k: number): number {
    const n = prices.length;
    const profitSum = new Array(n + 1).fill(0);
    const priceSum = new Array(n + 1).fill(0);
    for (let i = 0; i < n; i++) {
        profitSum[i + 1] = profitSum[i] + prices[i] * strategy[i];
        priceSum[i + 1] = priceSum[i] + prices[i];
    }
    let res = profitSum[n];
    for (let i = k - 1; i < n; i++) {
        const leftProfit = profitSum[i - k + 1];
        const rightProfit = profitSum[n] - profitSum[i + 1];
        const changeProfit = priceSum[i + 1] - priceSum[i - Math.floor(k / 2) + 1];
        res = Math.max(res, leftProfit + changeProfit + rightProfit);
    }
    return res;
}
```

```JavaScript
function maxProfit(prices, strategy, k) {
    const n = prices.length;
    const profitSum = new Array(n + 1).fill(0);
    const priceSum = new Array(n + 1).fill(0);
    for (let i = 0; i < n; i++) {
        profitSum[i + 1] = profitSum[i] + prices[i] * strategy[i];
        priceSum[i + 1] = priceSum[i] + prices[i];
    }
    let res = profitSum[n];
    for (let i = k - 1; i < n; i++) {
        const leftProfit = profitSum[i - k + 1];
        const rightProfit = profitSum[n] - profitSum[i + 1];
        const changeProfit = priceSum[i + 1] - priceSum[i - Math.floor(k / 2) + 1];
        res = Math.max(res, leftProfit + changeProfit + rightProfit);
    }
    return res;
}
```

```CSharp
public class Solution {
    public long MaxProfit(int[] prices, int[] strategy, int k) {
        int n = prices.Length;
        long[] profitSum = new long[n + 1];
        long[] priceSum = new long[n + 1];
        for (int i = 0; i < n; i++) {
            profitSum[i + 1] = profitSum[i] + (long)prices[i] * strategy[i];
            priceSum[i + 1] = priceSum[i] + prices[i];
        }
        long res = profitSum[n];
        for (int i = k - 1; i < n; i++) {
            long leftProfit = profitSum[i - k + 1];
            long rightProfit = profitSum[n] - profitSum[i + 1];
            long changeProfit = priceSum[i + 1] - priceSum[i - k / 2 + 1];
            res = Math.Max(res, leftProfit + changeProfit + rightProfit);
        }
        return res;
    }
}
```

```C
long long maxProfit(int* prices, int pricesSize, int* strategy, int strategySize, int k) {
    int n = pricesSize;
    long long* profitSum = (long long*)calloc(n + 1, sizeof(long long));
    long long* priceSum = (long long*)calloc(n + 1, sizeof(long long));
    for (int i = 0; i < n; i++) {
        profitSum[i + 1] = profitSum[i] + (long long)prices[i] * strategy[i];
        priceSum[i + 1] = priceSum[i] + prices[i];
    }
    long long res = profitSum[n];
    for (int i = k - 1; i < n; i++) {
        long long leftProfit = profitSum[i - k + 1];
        long long rightProfit = profitSum[n] - profitSum[i + 1];
        long long changeProfit = priceSum[i + 1] - priceSum[i - k / 2 + 1];
        long long total = leftProfit + changeProfit + rightProfit;
        if (total > res) res = total;
    }
    free(profitSum);
    free(priceSum);
    return res;
}
```

```Rust
impl Solution {
    pub fn max_profit(prices: Vec<i32>, strategy: Vec<i32>, k: i32) -> i64 {
        let n = prices.len();
        let mut profit_sum = vec![0i64; n + 1];
        let mut price_sum = vec![0i64; n + 1];
        for i in 0..n {
            profit_sum[i + 1] = profit_sum[i] + prices[i] as i64 * strategy[i] as i64;
            price_sum[i + 1] = price_sum[i] + prices[i] as i64;
        }
        let mut res = profit_sum[n];
        for i in (k - 1) as usize..n {
            let left_profit = profit_sum[i - (k as usize) + 1];
            let right_profit = profit_sum[n] - profit_sum[i + 1];
            let change_profit = price_sum[i + 1] - price_sum[i - (k as usize) / 2 + 1];
            res = res.max(left_profit + change_profit + right_profit);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $prices$ 的长度。
- 空间复杂度：$O(n)$。
