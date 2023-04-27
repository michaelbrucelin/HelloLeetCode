#### 预处理+DP

1. 预处理下面3组数据
    1. 前缀和，$PRE$，这样可以快速求出任意子数组的和
    2. 前缀最大子数组1，$MAX1$
    3. 前缀最大子数组2，$MAX2$
2. 然后进行DP，假定$F(n)$表示数组截止到索引为$n$的元素的最大值
    1. 如果$n \lt firstLen + secondLen$，那么$F(n) = 0$
    2. 如果$n =   firstLen + secondLen$，那么$F(n) = SUM(nums) = PRE[n+1]$有两种可能
    3. 如果$n \gt firstLen + secondLen$，那么$nums[n]$有两种可能
        1. 不使用$nums[n]$，$F(n) = F(n-1)$
        2. 使用$nums[n]$，有两种可能
            - $nums[n]$，构成了$firstLen$，$F(n) = PRE[n+1]-PRE[n-firstLen+1] + MAX1[n-firstLen]$
            - $nums[n]$，构成了$secondLen$，$F(n) = PRE[n+1]-PRE[n-secondLen+1] + MAX1[n-secondLen]$
        3. $F(n)$取上面3个值中的最大值

##### 示例

```C
nums = [2,1,5,6,0,9,5,0,3,8], firstLen = 4, secondLen = 3
```

预处理及DP的结果

```C
id          0, 1, 2,  3,  4,  5,  6,  7,  8,  9
nums = [    2, 1, 5,  6,  0,  9,  5,  0,  3,  8 ]
pre =  [ 0, 2, 3, 8, 14, 14, 23, 28, 28, 31, 39 ]
max1 = [    0, 0, 0, 14, 14, 20, 20, 20, 20, 20 ]  // firstLen  = 4
max2 = [    0, 0, 8, 12, 12, 15, 15, 15, 15, 15 ]  // secondLen = 3
dp   = [    0, 0, 0,  0,  0,  0, 28, 28, 29, 31 ]
```
