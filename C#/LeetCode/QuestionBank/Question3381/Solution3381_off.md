### [长度可被 K 整除的子数组的最大元素和](https://leetcode.cn/problems/maximum-subarray-sum-with-length-divisible-by-k/solutions/3837035/chang-du-ke-bei-k-zheng-chu-de-zi-shu-zu-dzxb/)

#### 方法一：前缀和

**思路与算法**

令数组 $nums$ 的前缀和为 $prefixSum[i]=\sum_{j=0}^inums[j]$，那么区间 $[j,i]$ 的子数组和为 $sum(j,i)=prefixSum[i]-prefixSum[j-1]$。题目要求非空子数组的长度可以被 $k$ 整除，即：

$$(i-j+1)\mod k=0$$

那么有：

$$i\mod k=(j-1)\mod k$$

使用 $kSum[l]$ 记录下标同余为 $l$ 的所有前缀和最小值。根据上面的推导，对于每个 $i$，我们只需要找到一个与它同余的最小前缀和 $prefixSum[j-1]$，即 $kSum[i\mod k]$，就可以得到 $i$ 为末尾元素的子数组最大和 $prefixSum[i]-kSum[i\mod k]$。返回最终的最大值即可。

**代码**

```C++
class Solution {
public:
    long long maxSubarraySum(vector<int>& nums, int k) {
        int n = nums.size();
        long long prefixSum = 0, maxSum = LONG_LONG_MIN;
        vector<long long> kSum(k, LONG_LONG_MAX / 2);
        kSum[k - 1] = 0;
        for (int i = 0; i < n; i++) {
            prefixSum += nums[i];
            maxSum = max(maxSum, prefixSum - kSum[i % k]);
            kSum[i % k] = min(kSum[i % k], prefixSum);
        }
        return maxSum;
    }
};
```

```Go
func maxSubarraySum(nums []int, k int) int64 {
    n := len(nums)
    prefixSum := int64(0)
    maxSum := int64(math.MinInt64)
    kSum := make([]int64, k)
    for i := 0; i < k; i++ {
        kSum[i] = math.MaxInt64 / 2
    }
    kSum[k - 1] = 0
    for i := 0; i < n; i++ {
        prefixSum += int64(nums[i])
        maxSum = max(maxSum, prefixSum - kSum[i % k])
        kSum[i % k] = min(kSum[i % k], prefixSum)
    }
    return maxSum
}
```

```Python
class Solution:
    def maxSubarraySum(self, nums: List[int], k: int) -> int:
        n = len(nums)
        prefixSum = 0
        maxSum = -sys.maxsize
        kSum = [sys.maxsize // 2] * k
        kSum[k - 1] = 0
        for i in range(n):
            prefixSum += nums[i]
            maxSum = max(maxSum, prefixSum - kSum[i % k])
            kSum[i % k] = min(kSum[i % k], prefixSum)
        return maxSum
```

```Java
class Solution {
    public long maxSubarraySum(int[] nums, int k) {
        int n = nums.length;
        long prefixSum = 0;
        long maxSum = Long.MIN_VALUE;
        long[] kSum = new long[k];
        for (int i = 0; i < k; i++) {
            kSum[i] = Long.MAX_VALUE / 2;
        }
        kSum[k - 1] = 0;
        for (int i = 0; i < n; i++) {
            prefixSum += nums[i];
            maxSum = Math.max(maxSum, prefixSum - kSum[i % k]);
            kSum[i % k] = Math.min(kSum[i % k], prefixSum);
        }
        return maxSum;
    }
}
```

```TypeScript
function maxSubarraySum(nums: number[], k: number): number {
    let n = nums.length;
    let prefixSum = 0;
    let maxSum = -Number.MAX_SAFE_INTEGER;
    let kSum: number[] = Array(k).fill(Number.MAX_SAFE_INTEGER / 2);
    kSum[k - 1] = 0;
    for (let i = 0; i < n; i++) {
        prefixSum += nums[i];
        maxSum = Math.max(maxSum, prefixSum - kSum[i % k]);
        kSum[i % k] = Math.min(kSum[i % k], prefixSum);
    }
    return maxSum;
}
```

```JavaScript
var maxSubarraySum = function(nums, k) {
    let n = nums.length;
    let prefixSum = 0;
    let maxSum = -Number.MAX_SAFE_INTEGER;
    let kSum = Array(k).fill(Number.MAX_SAFE_INTEGER / 2);
    kSum[k - 1] = 0;
    for (let i = 0; i < n; i++) {
        prefixSum += nums[i];
        maxSum = Math.max(maxSum, prefixSum - kSum[i % k]);
        kSum[i % k] = Math.min(kSum[i % k], prefixSum);
    }
    return maxSum;
};
```

```CSharp
public class Solution {
    public long MaxSubarraySum(int[] nums, int k) {
        int n = nums.Length;
        long prefixSum = 0;
        long maxSum = long.MinValue;
        long[] kSum = new long[k];
        for (int i = 0; i < k; i++) {
            kSum[i] = long.MaxValue / 2;
        }
        kSum[k - 1] = 0;
        for (int i = 0; i < n; i++) {
            prefixSum += nums[i];
            maxSum = Math.Max(maxSum, prefixSum - kSum[i % k]);
            kSum[i % k] = Math.Min(kSum[i % k], prefixSum);
        }
        return maxSum;
    }
}
```

```C
long long maxSubarraySum(int* nums, int numsSize, int k) {
    long long prefixSum = 0;
    long long maxSum = LONG_MIN;
    long long* kSum = (long long*)malloc(sizeof(long long) * k);
    for (int i = 0; i < k; i++) {
        kSum[i] = LLONG_MAX / 2;
    }
    kSum[k - 1] = 0;
    for (int i = 0; i < numsSize; i++) {
        prefixSum += nums[i];
        if (prefixSum - kSum[i % k] > maxSum) {
            maxSum = prefixSum - kSum[i % k];
        }
        if (prefixSum < kSum[i % k]) {
            kSum[i % k] = prefixSum;
        }
    }
    free(kSum);
    return maxSum;
}
```

```Rust
impl Solution {
    pub fn max_subarray_sum(nums: Vec<i32>, k: i32) -> i64 {
        let n = nums.len();
        let mut prefix_sum: i64 = 0;
        let mut max_sum: i64 = i64::MIN;
        let k = k as usize;
        let mut k_sum: Vec<i64> = vec![i64::MAX / 2; k];
        k_sum[k - 1] = 0;
        for i in 0..n {
            prefix_sum += nums[i] as i64;
            let idx = i % k;
            max_sum = max_sum.max(prefix_sum - k_sum[idx]);
            k_sum[idx] = k_sum[idx].min(prefix_sum);
        }
        max_sum
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组 $nums$ 的长度。
- 空间复杂度：$O(k)$。
