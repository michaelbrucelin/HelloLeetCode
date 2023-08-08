#### DP

用$dp[n+1,2]$记录以$nums[n]$结尾的子数组的正数和的最大值以及负数和的最小值，其中$dp[0,0] = dp[0,1] = 0$。

迭代$nums$中的每一项，对于$nums[k]$：

- $nums[k] > 0$
    - $dp[k+1,0] = dp[k,0] + nums[k]$
    - $dp[k+1,1] = Min(dp[k,1] + nums[k], 0)$
- $nums[k] < 0$
    - $dp[k+1,0] = Max(dp[k,0] + nums[k], 0)$
    - $dp[k+1,1] = dp[k,1] + nums[k]$
- $nums[k] = 0$
    - $dp[k+1,0] = dp[k,0]$
    - $dp[k+1,1] = dp[k,1]$

$Max(Abs(nums))$就是结果。
