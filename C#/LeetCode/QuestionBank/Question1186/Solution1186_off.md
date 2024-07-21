### [方法一：动态规划](https://leetcode.cn/problems/maximum-subarray-sum-with-one-deletion/solutions/2314975/shan-chu-yi-ci-de-dao-zi-shu-zu-de-zui-d-o1o9/)

本题是典型的动态规划应用题，我们可以将问题拆分成多个子问题，即求解以 $arr[i]$ 结尾的最多删除一次的非空子数组的最大和。我们以 $dp[i][k]$ 表示以 $arr[i]$ 结尾，删除 $k$ 次的非空子数组的最大和（删除前的末尾元素为 $arr[i]$，就视为以 $arr[i]$ 结尾）。初始时 $dp[0][0] = arr[0]$，$dp[0][1] ＝ 0$（以 $arr[0]$ 结尾，删除一次的非空子数组不存在，因此 $dp[0][1]$ 不会计入结果）。当 $i \gt 0$ 时，转移方程如下：

$$\begin{aligned} dp[i][0] &= \max(dp[i - 1][0], 0) + arr[i] \\ dp[i][1] &= \max(dp[i - 1][1] + arr[i], dp[i - 1][0]) \end{aligned}$$

- 第一个转移方程表示在不删除的情况下，以 $arr[i]$ 为结尾的非空子数组的最大和 $dp[i][0]$ 与 $dp[i － 1][0]$ 有关，当 $dp[i - 1][0] \gt 0$ 时，直接将 $arr[i]$ 与 $i - 1$ 时的最大非空子数组连接时，取得最大和，否则只选 $arr[i]$ 时，取得最大和。
- 第二个转移方程表示在删除一次的情况下，以 $arr[i]$ 为结尾的非空子数组有两种情况：
    1. 不删除 $arr[i]$，那么选择 $arr[i]$ 与 $dp[i - 1][1]$ 对应的子数组（已执行一次删除）。
    2. 删除 $arr[i]$，那么选择 $dp[i - 1][0]$ 对应的非空子数组（未执行一次删除，但是等同于删除了 $arr[i]$）。
    $dp[i][1]$ 取以上两种情况的最大和的最大值。

注意到 $dp[i][*]$ 的值只与 $dp[i - 1][*]$ 有关，因此我们可以只使用两个整数来节省空间。

```cpp
class Solution {
public:
    int maximumSum(vector<int>& arr) {
        int dp0 = arr[0], dp1 = 0, res = arr[0];
        for (int i = 1; i < arr.size(); i++) {
            dp1 = max(dp0, dp1 + arr[i]);
            dp0 = max(dp0, 0) + arr[i];
            res = max(res, max(dp0, dp1));
        }
        return res;
    }
};
```

```java
class Solution {
    public int maximumSum(int[] arr) {
        int dp0 = arr[0], dp1 = 0, res = arr[0];
        for (int i = 1; i < arr.length; i++) {
            dp1 = Math.max(dp0, dp1 + arr[i]);
            dp0 = Math.max(dp0, 0) + arr[i];
            res = Math.max(res, Math.max(dp0, dp1));
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MaximumSum(int[] arr) {
        int dp0 = arr[0], dp1 = 0, res = arr[0];
        for (int i = 1; i < arr.Length; i++) {
            dp1 = Math.Max(dp0, dp1 + arr[i]);
            dp0 = Math.Max(dp0, 0) + arr[i];
            res = Math.Max(res, Math.Max(dp0, dp1));
        }
        return res;
    }
}
```

```go
func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}

func maximumSum(arr []int) int {
    dp0, dp1, res := arr[0], 0, arr[0]
    for i := 1; i < len(arr); i++ {
        dp0, dp1 = max(dp0, 0) + arr[i], max(dp1 + arr[i], dp0)
        res = max(res, max(dp0, dp1))
    }
    return res
}
```

```python
class Solution:
    def maximumSum(self, arr: List[int]) -> bool:
        dp0, dp1, res = arr[0], 0, arr[0]
        for i in range(1, len(arr)):
            dp1 = max(dp0, dp1 + arr[i])
            dp0 = max(dp0, 0) + arr[i]
            res = max(res, max(dp0, dp1))
        return res
```

```javascript
var maximumSum = function(arr) {
    let dp0 = arr[0], dp1 = 0, res = arr[0];
    for (let i = 1; i < arr.length; i++) {
        dp1 = Math.max(dp0, dp1 + arr[i]);
        dp0 = Math.max(dp0, 0) + arr[i];
        res = Math.max(res, Math.max(dp0, dp1));
    }
    return res;
};
```

```c
int maximumSum(int* arr, int arrSize) {
    int dp0 = arr[0], dp1 = 0, res = arr[0];
    for (int i = 1; i < arrSize; i++) {
        dp1 = fmax(dp0, dp1 + arr[i]);
        dp0 = fmax(dp0, 0) + arr[i];
        res = fmax(res, fmax(dp0, dp1));
    }
    return res;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $arr$ 的长度。
- 空间复杂度：$O(1)$。
