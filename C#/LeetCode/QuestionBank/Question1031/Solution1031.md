#### 预处理+DP

1. 预处理下面3组数据
    1. 前缀和，这样可以快速求出任意子数组的和
    2. 前缀最大子数组1，$MAX1$
    3. 前缀最大子数组2，$MAX2$
2. 然后进行DP，假定$F(n)$表示数组截止到索引为$n$的元素的最大值
    1. 如果$n \lt firstLen + secondLen$，那么$F(n) = 0$
    2. 如果$n \ge firstLen + secondLen$，那么$nums[n]$有两种可能
        1. 不使用$nums[n]$，$F(n) = F(n-1)$
        2. 使用$nums[n]$，有两种可能
            - $nums[n]$，构成了$firstLen$，
            - $nums[n]$，构成了$secondLen$
