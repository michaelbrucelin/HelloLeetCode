### [统计主要元素子数组数目 II](https://leetcode.cn/problems/count-subarrays-with-majority-element-ii/solutions/3984750/tong-ji-zhu-yao-yuan-su-zi-shu-zu-shu-mu-bifu/)

#### 方法一：前缀和

**思路与算法**

本题是[「3737. 统计主要元素子数组数目 I」](https://leetcode.cn/problems/count-majority-element-subarrays-i/)的数据加强版。

记数组 $nums$ 的长度为 $n$，我们将其进行变换：将值为 $target$ 的元素视为 $+1$，其余元素视为 $-1$。这样，$target$ 是子数组 $nums[l..r]$ 的主要元素，当且仅当变换后该子数组的元素和大于 $0$。

设变换后的数组的前缀和为数组 $s$，长度为 $n+1$。此时，子数组 $nums[l..r]$ 变换后的元素和为 $s[r+1]-s[l]$，大于 $0$ 的条件等价于 $s[r+1]>s[l]$。因此问题转化为：对于每个 $r$，统计满足 $0\le l\le r$ 且 $s[l]<s[r+1]$ 的 $l$ 的个数。

朴素做法是对每个 $r$ 遍历所有 $l$，时间复杂度为 $O(n^2)$，会超出时间限制。注意到 $s$ 的值域为整数区间 $[-n,n]$，我们可以用计数数组 $pre$ 来加速：$pre[v]$ 记录到目前为止，前缀和 $v$ 出现了多少次。那么对于当前前缀和 $s[r+1]$，满足 $s[l]<s[r+1]$ 的 $l$ 的个数，就是 $pre$ 数组中所有下标严格小于 $s[r+1]$ 的元素之和，也就是 $pre$ 的一个前缀和。

如果对每个 $r$ 都重新求这个前缀和，时间复杂度仍然很高。但关键观察是：相邻两步之间，$s[r+1]$ 相比 $s[r]$ 只变化了 $+1$ 或 $-1$，因此求和的上界也只偏移了 $1$。这意味着可以用一个变量 $presum$ 来增量维护这个求和，每步只需 $O(1)$ 更新：

- 遇到 $+1$：$s[r+1]=s[r]+1$，求和上界增大，多包含了 $pre[s[r]]$ 这一项，$presum$ 加上它；
- 遇到 $-1$：$s[r+1]=s[r]-1$，求和上界减小，少包含了 $pre[s[r+1]]$ 这一项，$presum$ 减去它。

更新 $presum$ 后，将当前的 $s[r+1]$ 记入 $pre$，再将 $presum$ 累加到答案中。

在代码实现中，用变量 $cnt$ 维护当前的前缀和 $s[r+1]$。由于前缀和可能为负数，而大部分语言的数组不支持负数下标，因此将下标整体偏移 $n$。

**代码**

```C++
class Solution {
public:
    long long countMajoritySubarrays(vector<int>& nums, int target) {
        int n = nums.size();
        // 表示前缀和为 -n, -(n-1), ..., 0, 1, ..., n 的出现次数，下标偏移 n
        vector<int> pre(n * 2 + 1, 0);
        pre[n] = 1;
        int cnt = n;
        long long ans = 0, presum = 0;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == target) {
                presum += pre[cnt];
                ++cnt;
                ++pre[cnt];
            } else {
                --cnt;
                presum -= pre[cnt];
                ++pre[cnt];
            }
            ans += presum;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countMajoritySubarrays(self, nums: List[int], target: int) -> int:
        n = len(nums)
        # 表示前缀和为 -n, -(n-1), ..., 0, 1, ..., n 的前缀数量，下标偏移 n
        pre = [0] * (n * 2 + 1)
        pre[n] = 1
        cnt = n
        ans = presum = 0
        for i in range(n):
            if nums[i] == target:
                presum += pre[cnt]
                cnt += 1
                pre[cnt] += 1
            else:
                cnt -= 1
                presum -= pre[cnt]
                pre[cnt] += 1
            ans += presum
        return ans
```

```Java
class Solution {
    public long countMajoritySubarrays(int[] nums, int target) {
        int n = nums.length;
        // 表示前缀和为 -n, -(n-1), ..., 0, 1, ..., n 的出现次数，下标偏移 n
        int[] pre = new int[n * 2 + 1];
        pre[n] = 1;
        int cnt = n;
        long ans = 0, presum = 0;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == target) {
                presum += pre[cnt];
                ++cnt;
                ++pre[cnt];
            } else {
                --cnt;
                presum -= pre[cnt];
                ++pre[cnt];
            }
            ans += presum;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long CountMajoritySubarrays(int[] nums, int target) {
        int n = nums.Length;
        // 表示前缀和为 -n, -(n-1), ..., 0, 1, ..., n 的出现次数，下标偏移 n
        int[] pre = new int[n * 2 + 1];
        pre[n] = 1;
        int cnt = n;
        long ans = 0, presum = 0;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == target) {
                presum += pre[cnt];
                ++cnt;
                ++pre[cnt];
            } else {
                --cnt;
                presum -= pre[cnt];
                ++pre[cnt];
            }
            ans += presum;
        }
        return ans;
    }
}
```

```Go
func countMajoritySubarrays(nums []int, target int) int64 {
    n := len(nums)
    // 表示前缀和为 -n, -(n-1), ..., 0, 1, ..., n 的出现次数，下标偏移 n
    pre := make([]int, n*2+1)
    pre[n] = 1
    cnt := n
    var ans, presum int64 = 0, 0
    for i := 0; i < n; i++ {
        if nums[i] == target {
            presum += int64(pre[cnt])
            cnt++
            pre[cnt]++
        } else {
            cnt--
            presum -= int64(pre[cnt])
            pre[cnt]++
        }
        ans += presum
    }
    return ans
}
```

```C
long long countMajoritySubarrays(int* nums, int numsSize, int target) {
    int n = numsSize;
    // 表示前缀和为 -n, -(n-1), ..., 0, 1, ..., n 的出现次数，下标偏移 n
    int* pre = (int*)calloc(n * 2 + 1, sizeof(int));
    pre[n] = 1;
    int cnt = n;
    long long ans = 0, presum = 0;
    for (int i = 0; i < n; ++i) {
        if (nums[i] == target) {
            presum += pre[cnt];
            ++cnt;
            ++pre[cnt];
        } else {
            --cnt;
            presum -= pre[cnt];
            ++pre[cnt];
        }
        ans += presum;
    }
    free(pre);
    return ans;
}
```

```JavaScript
var countMajoritySubarrays = function(nums, target) {
    const n = nums.length;
    // 表示前缀和为 -n, -(n-1), ..., 0, 1, ..., n 的出现次数，下标偏移 n
    const pre = new Array(n * 2 + 1).fill(0);
    pre[n] = 1;
    let cnt = n;
    let ans = 0, presum = 0;
    for (let i = 0; i < n; ++i) {
        if (nums[i] === target) {
            presum += pre[cnt];
            ++cnt;
            ++pre[cnt];
        } else {
            --cnt;
            presum -= pre[cnt];
            ++pre[cnt];
        }
        ans += presum;
    }
    return ans;
};
```

```TypeScript
function countMajoritySubarrays(nums: number[], target: number): number {
    const n = nums.length;
    // 表示前缀和为 -n, -(n-1), ..., 0, 1, ..., n 的出现次数，下标偏移 n
    const pre = new Array<number>(n * 2 + 1).fill(0);
    pre[n] = 1;
    let cnt = n;
    let ans = 0, presum = 0;
    for (let i = 0; i < n; ++i) {
        if (nums[i] === target) {
            presum += pre[cnt];
            ++cnt;
            ++pre[cnt];
        } else {
            --cnt;
            presum -= pre[cnt];
            ++pre[cnt];
        }
        ans += presum;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn count_majority_subarrays(nums: Vec<i32>, target: i32) -> i64 {
        let n = nums.len();
        // 表示前缀和为 -n, -(n-1), ..., 0, 1, ..., n 的出现次数，下标偏移 n
        let mut pre = vec![0; n * 2 + 1];
        pre[n] = 1;
        let mut cnt = n as i32;
        let mut ans: i64 = 0;
        let mut presum: i64 = 0;
        for i in 0..n {
            if nums[i] == target {
                presum += pre[cnt as usize] as i64;
                cnt += 1;
                pre[cnt as usize] += 1;
            } else {
                cnt -= 1;
                presum -= pre[cnt as usize] as i64;
                pre[cnt as usize] += 1;
            }
            ans += presum;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(n)$，即为数组 $pre$ 需要使用的空间。
