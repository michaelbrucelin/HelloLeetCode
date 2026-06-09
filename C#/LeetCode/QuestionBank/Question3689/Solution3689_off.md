### [最大子数组总值 I](https://leetcode.cn/problems/maximum-total-subarray-value-i/solutions/3980920/zui-da-zi-shu-zu-zong-zhi-i-by-leetcode-vg490/)

#### 方法一：贪心

**思路与算法**

由于可以重复选择同一个子数组，我们只需要找到价值最大的子数组，然后选择 $k$ 次即可。

对于任意子数组 $nums[l..r]$，其价值定义为 $max(nums[l..r])-min(nums[l..r])$。因为子数组的最大值不会超过整个数组的最大值，最小值不会低于整个数组的最小值，所以任意子数组的价值最多为 $max(nums)-min(nums)$。

包含全局最大值和全局最小值的子数组可以达到这个上界（例如直接选择整个数组），因此最大总价值为 $k\times (max(nums)-min(nums))$。

**代码**

```C++
class Solution {
public:
    long long maxTotalValue(vector<int>& nums, int k) {
        int m1 = INT_MAX, m2 = INT_MIN;
        for (int x : nums) {
            m1 = min(m1, x);
            m2 = max(m2, x);
        }
        return (long long)(m2 - m1) * k;
    }
};
```

```Go
func maxTotalValue(nums []int, k int) int64 {
    m1, m2 := math.MaxInt, math.MinInt
    for _, x := range nums {
        m1 = min(m1, x)
        m2 = max(m2, x)
    }
    return int64(m2 - m1) * int64(k)
}
```

```Python
class Solution:
    def maxTotalValue(self, nums: List[int], k: int) -> int:
        m1 = min(nums)
        m2 = max(nums)
        return (m2 - m1) * k
```

```Java
class Solution {
    public long maxTotalValue(int[] nums, int k) {
        int m1 = Integer.MAX_VALUE, m2 = Integer.MIN_VALUE;
        for (int x : nums) {
            m1 = Math.min(m1, x);
            m2 = Math.max(m2, x);
        }
        return (long)(m2 - m1) * k;
    }
}
```

```TypeScript
function maxTotalValue(nums: number[], k: number): number {
    let m1 = Infinity, m2 = -Infinity;
    for (const x of nums) {
        m1 = Math.min(m1, x);
        m2 = Math.max(m2, x);
    }
    return (m2 - m1) * k;
}
```

```JavaScript
var maxTotalValue = function(nums, k) {
    let m1 = Infinity, m2 = -Infinity;
    for (const x of nums) {
        m1 = Math.min(m1, x);
        m2 = Math.max(m2, x);
    }
    return (m2 - m1) * k;
};
```

```CSharp
public class Solution {
    public long MaxTotalValue(int[] nums, int k) {
        int m1 = int.MaxValue, m2 = int.MinValue;
        foreach (int x in nums) {
            m1 = Math.Min(m1, x);
            m2 = Math.Max(m2, x);
        }
        return (long)(m2 - m1) * k;
    }
}
```

```C
long long maxTotalValue(int* nums, int numsSize, int k) {
    int m1 = INT_MAX, m2 = INT_MIN;
    for (int i = 0; i < numsSize; i++) {
        m1 = fmin(m1, nums[i]);
        m2 = fmax(m2, nums[i]);
    }
    return (long long)(m2 - m1) * k;
}
```

```Rust
impl Solution {
    pub fn max_total_value(nums: Vec<i32>, k: i32) -> i64 {
        let m1 = *nums.iter().min().unwrap() as i64;
        let m2 = *nums.iter().max().unwrap() as i64;
        (m2 - m1) * k as i64
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。只需一次遍历找出最大值和最小值。
- 空间复杂度：$O(1)$。仅使用常数额外空间。
