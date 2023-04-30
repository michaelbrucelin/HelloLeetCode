﻿#### [方法一：动态规划](https://leetcode.cn/problems/the-masseuse-lcci/solutions/166465/an-mo-shi-by-leetcode-solution/)

**思路和算法**

定义 $dp[i][0]$ 表示考虑前 $i$ 个预约，第 $i$ 个预约不接的最长预约时间，$dp[i][1]$ 表示考虑前 $i$ 个预约，第 $i$ 个预约接的最长预约时间。

从前往后计算 $dp$ 值，假设我们已经计算出前 $i-1$ 个 $dp$ 值，考虑计算 $dp[i][0/1]$ 的答案。

首先考虑 $dp[i][0]$ 的转移方程，由于这个状态下第 $i$ 个预约是不接的，所以第 $i-1$ 个预约接或不接都可以，故可以从 $dp[i-1][0]$ 和 $dp[i-1][1]$ 两个状态转移过来，转移方程即为：

$$dp[i][0]=max(dp[i-1][0],dp[i-1][1])$$

对于 $dp[i][1]$ ，由于这个状态下第 $i$ 个预约要接，根据题目要求按摩师不能接受相邻的预约，所以第 $i-1$ 个预约不能接受，故我们只能从 $dp[i-1][0]$ 这个状态转移过来，转移方程即为：

$$dp[i][1]=dp[i-1][0] + nums_i$$

其中 $nums_i$ 表示第 $i$ 个预约的时长。

最后答案即为 $max(dp[n][0],dp[n][1])$ ，其中 $n$ 表示预约的个数。

再回来看转移方程，我们发现计算 $dp[i][0/1]$ 时，只与前一个状态 $dp[i-1][0/1]$ 有关，所以我们可以不用开数组，只用两个变量 $dp_0$，$dp_1$ 分别存储 $dp[i-1][0]$ 和 $dp[i-1][1]$ 的答案，然后去转移更新答案即可。

```cpp
class Solution {
public:
    int massage(vector<int>& nums) {
        int n = (int)nums.size();
        if (!n) {
            return 0;
        }
        int dp0 = 0, dp1 = nums[0];

        for (int i = 1; i < n; ++i){
            int tdp0 = max(dp0, dp1); // 计算 dp[i][0]
            int tdp1 = dp0 + nums[i]; // 计算 dp[i][1]

            dp0 = tdp0; // 用 dp[i][0] 更新 dp_0
            dp1 = tdp1; // 用 dp[i][1] 更新 dp_1
        }
        return max(dp0, dp1);
    }
};
```

```java
class Solution {
    public int massage(int[] nums) {
        int n = nums.length;
        if (n == 0) {
            return 0;
        }
        int dp0 = 0, dp1 = nums[0];

        for (int i = 1; i < n; ++i){
            int tdp0 = Math.max(dp0, dp1); // 计算 dp[i][0]
            int tdp1 = dp0 + nums[i]; // 计算 dp[i][1]

            dp0 = tdp0; // 用 dp[i][0] 更新 dp_0
            dp1 = tdp1; // 用 dp[i][1] 更新 dp_1
        }
        return Math.max(dp0, dp1);
    }
}
```

```python
class Solution:
    def massage(self, nums: List[int]) -> int:
        n = len(nums)
        if n == 0:
            return 0

        dp0, dp1 = 0, nums[0]
        for i in range(1, n):
            tdp0 = max(dp0, dp1)   # 计算 dp[i][0]
            tdp1 = dp0 + nums[i]   # 计算 dp[i][1]
            dp0, dp1 = tdp0, tdp1
        
        return max(dp0, dp1)
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为预约的个数。我们有 $2n$ 个状态需要计算，每次状态转移需要 $O(1)$ 的时间，所以一共需要 $O(2n)=O(n)$ 的时间复杂度。
-   空间复杂度：$O(1)$，只需要常数的空间存放若干变量。
