### [找出有效子序列的最大长度 II](https://leetcode.cn/problems/find-the-maximum-length-of-valid-subsequence-ii/solutions/3718001/zhao-chu-you-xiao-zi-xu-lie-de-zui-da-ch-6s7c/)

#### 方法一：动态规划

**思路**

根据有效子序列的定义，可以发现，子序列中所有奇数下标的元素模 $k$ 同余，偶数下标的元素模 $k$ 同余。考虑子序列最后两个元素的模 $k$ 的余数，一共有 $k^2$ 种可能性。用二维数组 $dp$ 来表示子序列的最大长度，$dp[i][j]$ 表示一个有效子序列，最后两个元素模 $k$ 的余数分别是 $i$ 和 $j$，它的最大长度。

遍历 $nums$ 来更新 $dp[i][j]$。每遍历到一个数字 $num$，我们就试图将其加入子序列。具体来说，此时最后一个元素模 $k$ 为 $num \mod k=curr$，然后我们遍历前一个元素模 $k$ 所有的可能性 $prev$，将 $dp[prev][curr]$ 更新为 $dp[curr][prev]+1$。最后返回二维数组的最大值即可。

**代码**

```Python
class Solution:
    def maximumLength(self, nums: List[int], k: int) -> int:
        dp = [[0] * k for _ in range(k)]
        res = 0
        for num in nums:
            num %= k
            for prev in range(k):
                dp[prev][num] = dp[num][prev] + 1
                res = max(res, dp[prev][num])
        return res
```

```C++
class Solution {
public:
    int maximumLength(vector<int>& nums, int k) {
        vector<vector<int>> dp(k, vector<int>(k, 0));
        int res = 0;
        for (int num : nums) {
            num %= k;
            for (int prev = 0; prev < k; ++prev) {
                dp[prev][num] = dp[num][prev] + 1;
                res = max(res, dp[prev][num]);
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int maximumLength(int[] nums, int k) {
        int[][] dp = new int[k][k];
        int res = 0;
        for (int num : nums) {
            num %= k;
            for (int prev = 0; prev < k; prev++) {
                dp[prev][num] = dp[num][prev] + 1;
                res = Math.max(res, dp[prev][num]);
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MaximumLength(int[] nums, int k) {
        int[,] dp = new int[k, k];
        int res = 0;
        foreach (int num in nums) {
            int mod = num % k;
            for (int prev = 0; prev < k; prev++) {
                dp[prev, mod] = dp[mod, prev] + 1;
                res = Math.Max(res, dp[prev, mod]);
            }
        }
        return res;
    }
}
```

```Go
func maximumLength(nums []int, k int) int {
    dp := make([][]int, k)
    for i := range dp {
        dp[i] = make([]int, k)
    }
    res := 0
    for _, num := range nums {
        num %= k
        for prev := 0; prev < k; prev++ {
            dp[prev][num] = dp[num][prev] + 1
            res = max(res, dp[prev][num])
        }
    }
    return res
}
```

```C
int maximumLength(int* nums, int numsSize, int k) {
    int dp[k][k];
    memset(dp, 0, sizeof(dp));
    int res = 0;
    for (int i = 0; i < numsSize; i++) {
        int num = nums[i] % k;
        for (int prev = 0; prev < k; prev++) {
            dp[prev][num] = dp[num][prev] + 1;
            if (dp[prev][num] > res) {
                res = dp[prev][num];
            }
        }
    }
    return res;
}
```

```JavaScript
var maximumLength = function(nums, k) {
    const dp = Array.from({length: k}, () => new Array(k).fill(0));
    let res = 0;
    for (const num of nums) {
        const mod = num % k;
        for (let prev = 0; prev < k; prev++) {
            dp[prev][mod] = dp[mod][prev] + 1;
            res = Math.max(res, dp[prev][mod]);
        }
    }
    return res;
};
```

```TypeScript
function maximumLength(nums: number[], k: number): number {
    const dp: number[][] = Array.from({length: k}, () => new Array(k).fill(0));
    let res = 0;
    for (const num of nums) {
        const mod = num % k;
        for (let prev = 0; prev < k; prev++) {
            dp[prev][mod] = dp[mod][prev] + 1;
            res = Math.max(res, dp[prev][mod]);
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn maximum_length(nums: Vec<i32>, k: i32) -> i32 {
        let k = k as usize;
        let mut dp = vec![vec![0; k]; k];
        let mut res = 0;
        for num in nums {
            let mod_num = (num % k as i32) as usize;
            for prev in 0..k {
                dp[prev][mod_num] = dp[mod_num][prev] + 1;
                res = res.max(dp[prev][mod_num]);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(k^2+n \times k)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(k^2)$。
