#### [动态规划](https://leetcode.cn/problems/maximum-alternating-subsequence-sum/solutions/846375/dong-tai-gui-hua-by-endlesscheng-d92a/)

定义 $f[i][0]$ 表示前 $i$ 个数中长为偶数的子序列的最大交替和，$f[i][1]$ 表示前 $i$ 个数中长为奇数的子序列的最大交替和。

初始时有 $f[0][0] = 0$，$f[0][1] = -\infty$。

对于第 $i$ 个数，有选或不选两种决策。

对于 $f[i+1][0]$，若不选第 $i$ 个数，则从 $f[i][0]$ 转移过来，否则从 $f[i][1]-nums[i]$ 转移过来，取二者最大值。

对于 $f[i+1][1]$，若不选第 $i$ 个数，则从 $f[i][1]$ 转移过来，否则从 $f[i][0]+nums[i]$ 转移过来，取二者最大值。

因此得到如下状态转移方程：

$$\begin{aligned} &f[i+1][0] = \max(f[i][0], f[i][1]-nums[i])\\ &f[i+1][1] = \max(f[i][1], f[i][0]+nums[i]) \end{aligned}$$

记 $nums$ 的长度为 nnn，$nums$ 子序列的最大交替和为 $\max(f[n][0],f[n][1])$。

注意到，由于长度为偶数的子序列的最后一个元素在交替和中需要取负号，在 $nums$ 的元素均为正数的情况下，那不如不计入该元素。

因此 $f[n][1]>f[n][0]$ 必然成立，于是返回 $f[n][1]$ 即可。

代码实现时可以用滚动数组优化。

```go
func maxAlternatingSum(nums []int) int64 {
    f := [2]int{0, math.MinInt64 / 2} // 除 2 防止计算时溢出
    for _, v := range nums {
        f = [2]int{max(f[0], f[1]-v), max(f[1], f[0]+v)}
    }
    return int64(f[1])
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}
```
