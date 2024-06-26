#### DP

<span style='color:red; font-weight:bold'>思路是错误的，例如`{ 8, -19, 5, -4, 20 }`。</span>

由于数组中的每个元素只有**选**与**不选**两种选择，所以这里采用**动态规划**进行解题。
下面对其进行简单描述：

##### DP的变量

- $F(N)$表示$nums[0..N]$的最大子数组和
- $I(N)$表示$nums[0..N]$中$F(N)$对应的子数组后面没有选择的那部分的和，所以其值一定$\le 0$

##### 初始值

- $F(0) = 0$
- $I(0) = 0$

##### 递推

对于数组的第$N+1$项$NUMS(N+1)$，我们考量$I(N) + NUMS(N+1)$

- 如果$I(N) + NUMS(N+1) \ge 0$
    - 如果$F(N) + I(N) + NUMS(N+1) \gt NUMS(N+1)$
        > $F(N+1) = F(N) + I(N) + NUMS(N+1)$
        > $I(N+1) = 0$
    - 如果$F(N) + I(N) + NUMS(N+1) \le NUMS(N+1)$
        > $F(N+1) = NUMS(N+1)$
        > $I(N+1) = 0$
- 如果$I(N) + NUMS(N+1) \lt 0$
    - 如果$F(N) \gt NUMS(N+1)$
        > $F(N+1) = F(N)$
        > $I(N+1) = I(N) + NUMS(N+1)$
    - 如果$F(N) \le NUMS(N+1)$
        > $F(N+1) = NUMS(N+1)$
        > $I(N+1) = 0$

##### 证明

略。
