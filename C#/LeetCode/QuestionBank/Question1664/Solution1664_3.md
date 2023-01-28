#### [正负交替前缀和](https://leetcode.cn/problems/ways-to-make-a-fair-array/solutions/493715/shuang-bai-zheng-fu-jiao-ti-qian-zhui-he-by-letian/)

去除索引为$i$的元素后，$i$之前元素的奇偶性不变，$i$之后元素的奇偶性改变，即$i$之后奇/偶数下标元素的和变成了偶/奇数下标。

考虑奇偶元素的差值，我们求正负交替的前缀和 $dp[i] = \sum_{j=0}^{i} (-1)^j nums[j-1]$

那么$dp[i−1]$表示索引$i$左边部分奇偶元素差值，$dp[n] − dp[i]$表示索引$i$右边部分奇偶元素差值，去除索引$i$后，$dp[n] − dp[i]$表示索引$i$右边部分奇偶元素差值的相反数。

因此，对任意$i$，只要$dp[i−1] == dp[n] − dp[i]$，即满足题目要求。

```python
class Solution:
    def waysToMakeFair(self, nums: List[int]) -> int:
        n = len(nums)
        dp = [0] * (n + 1)
        for i in range(1, n + 1):
            dp[i] = dp[i-1] + (nums[i-1] if i % 2 else -nums[i-1])

        ans = 0
        for i in range(1, n + 1):
            if dp[i - 1] == dp[n] - dp[i]:
                ans += 1

        return ans
```
