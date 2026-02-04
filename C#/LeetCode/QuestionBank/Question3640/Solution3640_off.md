### [三段式数组 II](https://leetcode.cn/problems/trionic-array-ii/solutions/3895084/san-duan-shi-shu-zu-ii-by-leetcode-solut-3gz7/)

#### 方法一：分组循环

**思路及解法**

注意到题目要求我们找到所有三段式子数组中和最大的那一个，这个目标可以分为两步来进行：

1. 找到满足 **三段式** 要求的子数组。
2. 计算该子数组的和并记录最大值。

对于第一步，考察 $nums$ 数组，我们可以使用[三段式数组 I](https://leetcode.cn/problems/trionic-array-i/description/)中判断边界合理性的方法来找到满足 **极大三段式** 要求的子数组。这里的极大是指该子数组不能再往左右延长。

并且在逻辑上，假设我们找到了一个极大三段式子数组，其满足 **增减增** 的规律，那么下一个可能的三段式子数组中的第一个元素应该是当前这个极大三段式子数组中第三段的第一个元素。于是，利用分组循环的方式，能够在 $O(n)$ 时间复杂度内找到所有满足 **极大三段式** 要求的子数组。

对于第二步，考察一个极大三段式子数组，容易想到第二段中的元素需要全部求和，并且第一段中倒数第二个元素以及第三段中第二个元素也需要计算到答案中，这样能够得到一个极小三段式子数组，这里的极小是指该子数组不能再从左右缩短。接下来就是在第一段中从右往左（从第一段中倒数第三个元素开始）计算累加最大值，在第三段中从左往右（从第三段中第三个元素开始）计算累加最大值，然后将这两个最大值累加到答案上即可。要注意的是如果这里的两个最大值小于零，那么就以 $0$ 进行累加，也就是不在极小三段式子数组的基础上增添元素。

**代码**

```C++
class Solution {
public:
    long long maxSumTrionic(vector<int>& nums) {
        int n = nums.size();
        int p, q, j;
        long long max_sum, sum, res;
        long long ans = LLONG_MIN;
        for (int i = 0; i < n; i++) {
            j = i + 1;
            res = 0;
            //第一段
            for(; j < n && nums[j -1] < nums[j]; j++);
            p = j - 1;
            if (p == i) {
                continue;
            }
            //第二段
            res += nums[p] + nums[p - 1];
            for(; j < n && nums[j - 1] > nums[j]; j++){
                res += nums[j];
            }
            q = j - 1;
            if (q == p || q == n - 1 || (nums[j] <= nums[q])) {
                i = q;
                continue;
            }
            //第三段
            res += nums[q + 1];
            //第三段求累加最大值
            max_sum = 0;
            sum = 0;
            for (int k = q + 2; k < n && nums[k] > nums[k - 1]; k++) {
                sum += nums[k];
                max_sum = max(max_sum, sum);
            }
            res += max_sum;
            //第一段求累加最大值
            max_sum = 0;
            sum = 0;
            for (int k = p - 2; k >= i; k--) {
                sum += nums[k];
                max_sum = max(max_sum, sum);
            }
            res += max_sum;
            //更新答案
            ans = max(ans, res);
            i = q - 1;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public long maxSumTrionic(int[] nums) {
        int n = nums.length;
        long ans = Long.MIN_VALUE;

        for (int i = 0; i < n; i++) {
            int j = i + 1;
            long res = 0;

            // 第一段: 上升段
            while (j < n && nums[j - 1] < nums[j]) {
                j++;
            }
            int p = j - 1;

            if (p == i) {
                continue;
            }

            // 第二段: 下降段
            res += nums[p] + nums[p - 1];
            while (j < n && nums[j - 1] > nums[j]) {
                res += nums[j];
                j++;
            }
            int q = j - 1;

            if (q == p || q == n - 1 || (j < n && nums[j] <= nums[q])) {
                i = q;
                continue;
            }

            // 第三段: 上升段
            res += nums[q + 1];

            // 第三段求累加最大值
            long maxSum = 0;
            long sum = 0;
            for (int k = q + 2; k < n && nums[k] > nums[k - 1]; k++) {
                sum += nums[k];
                maxSum = Math.max(maxSum, sum);
            }
            res += maxSum;

            // 第一段求累加最大值
            maxSum = 0;
            sum = 0;
            for (int k = p - 2; k >= i; k--) {
                sum += nums[k];
                maxSum = Math.max(maxSum, sum);
            }
            res += maxSum;

            // 更新答案
            ans = Math.max(ans, res);
            i = q - 1;
        }

        return ans;
    }
}
```

```JavaScript
var maxSumTrionic = function(nums) {
    const n = nums.length;
    let ans = -Infinity;

    for (let i = 0; i < n; i++) {
        let j = i + 1;
        let res = 0;

        // 第一段: 上升段
        while (j < n && nums[j - 1] < nums[j]) {
            j++;
        }
        const p = j - 1;

        if (p === i) {
            continue;
        }

        // 第二段: 下降段
        res += nums[p] + nums[p - 1];
        while (j < n && nums[j - 1] > nums[j]) {
            res += nums[j];
            j++;
        }
        const q = j - 1;

        if (q === p || q === n - 1 || (j < n && nums[j] <= nums[q])) {
            i = q;
            continue;
        }

        // 第三段: 上升段
        res += nums[q + 1];

        // 第三段求累加最大值
        let maxSum = 0;
        let sum = 0;
        for (let k = q + 2; k < n && nums[k] > nums[k - 1]; k++) {
            sum += nums[k];
            maxSum = Math.max(maxSum, sum);
        }
        res += maxSum;

        // 第一段求累加最大值
        maxSum = 0;
        sum = 0;
        for (let k = p - 2; k >= i; k--) {
            sum += nums[k];
            maxSum = Math.max(maxSum, sum);
        }
        res += maxSum;

        // 更新答案
        ans = Math.max(ans, res);
        i = q - 1;
    }

    return ans;
};
```

```Python
class Solution:
    def maxSumTrionic(self, nums: List[int]) -> int:
        n = len(nums)
        ans = float('-inf')
        i = 0

        while i < n:
            j = i + 1
            res = 0

            # 第一段: 上升段
            while j < n and nums[j - 1] < nums[j]:
                j += 1
            p = j - 1

            if p == i:  # 没有有效的上升段
                i += 1
                continue

            # 第二段: 下降段
            res += nums[p] + nums[p - 1]
            while j < n and nums[j - 1] > nums[j]:
                res += nums[j]
                j += 1
            q = j - 1

            if q == p or q == n - 1 or (j < n and nums[j] <= nums[q]):
                i = q
                continue

            # 第三段: 上升段
            res += nums[q + 1]

            # 第三段求累加最大值
            max_sum = 0
            curr_sum = 0
            k = q + 2
            while k < n and nums[k] > nums[k - 1]:
                curr_sum += nums[k]
                max_sum = max(max_sum, curr_sum)
                k += 1
            res += max_sum

            # 第一段求累加最大值
            max_sum = 0
            curr_sum = 0
            for k in range(p - 2, i - 1, -1):
                curr_sum += nums[k]
                max_sum = max(max_sum, curr_sum)
            res += max_sum

            # 更新答案
            ans = max(ans, res)
            i = q

        return ans
```

```CSharp
public class Solution {
    public long MaxSumTrionic(int[] nums) {
        int n = nums.Length;
        int p, q, j;
        long max_sum, sum, res;
        long ans = long.MinValue;
        for (int i = 0; i < n; i++) {
            j = i + 1;
            res = 0;
            //第一段
            for(; j < n && nums[j -1] < nums[j]; j++);
            p = j - 1;
            if (p == i) {
                continue;
            }
            //第二段
            res += nums[p] + nums[p - 1];
            for(; j < n && nums[j - 1] > nums[j]; j++){
                res += nums[j];
            }
            q = j - 1;
            if (q == p || q == n - 1 || (nums[j] <= nums[q])) {
                i = q;
                continue;
            }
            //第三段
            res += nums[q + 1];
            //第三段求累加最大值
            max_sum = 0;
            sum = 0;
            for (int k = q + 2; k < n && nums[k] > nums[k - 1]; k++) {
                sum += nums[k];
                max_sum = Math.Max(max_sum, sum);
            }
            res += max_sum;
            //第一段求累加最大值
            max_sum = 0;
            sum = 0;
            for (int k = p - 2; k >= i; k--) {
                sum += nums[k];
                max_sum = Math.Max(max_sum, sum);
            }
            res += max_sum;
            //更新答案
            ans = Math.Max(ans, res);
            i = q - 1;
        }
        return ans;
    }
}
```

```Go
func maxSumTrionic(nums []int) int64 {
    n := len(nums)
    var p, q, j int
    var max_sum, sum, res int64
    ans := int64(math.MinInt64)
    for i := 0; i < n; i++ {
        j = i + 1
        res = 0
        //第一段
        for ; j < n && nums[j-1] < nums[j]; j++ {
        }
        p = j - 1
        if p == i {
            continue
        }
        //第二段
        res += int64(nums[p] + nums[p-1])
        for ; j < n && nums[j-1] > nums[j]; j++ {
            res += int64(nums[j])
        }
        q = j - 1
        if q == p || q == n-1 || (j < n && nums[j] <= nums[q]) {
            i = q
            continue
        }
        //第三段
        res += int64(nums[q+1])
        //第三段求累加最大值
        max_sum = 0
        sum = 0
        for k := q + 2; k < n && nums[k] > nums[k-1]; k++ {
            sum += int64(nums[k])
            if sum > max_sum {
                max_sum = sum
            }
        }
        res += max_sum
        //第一段求累加最大值
        max_sum = 0
        sum = 0
        for k := p - 2; k >= i; k-- {
            sum += int64(nums[k])
            if sum > max_sum {
                max_sum = sum
            }
        }
        res += max_sum
        //更新答案
        if res > ans {
            ans = res
        }
        i = q - 1
    }
    return ans
}
```

```C
long long maxSumTrionic(int* nums, int numsSize) {
    int n = numsSize;
    int p, q, j;
    long long max_sum, sum, res;
    long long ans = LLONG_MIN;
    for (int i = 0; i < n; i++) {
        j = i + 1;
        res = 0;
        //第一段
        for(; j < n && nums[j -1] < nums[j]; j++);
        p = j - 1;
        if (p == i) {
            continue;
        }
        //第二段
        res += nums[p] + nums[p - 1];
        for(; j < n && nums[j - 1] > nums[j]; j++){
            res += nums[j];
        }
        q = j - 1;
        if (q == p || q == n - 1 || (j < n && nums[j] <= nums[q])) {
            i = q;
            continue;
        }
        //第三段
        res += nums[q + 1];
        //第三段求累加最大值
        max_sum = 0;
        sum = 0;
        for (int k = q + 2; k < n && nums[k] > nums[k - 1]; k++) {
            sum += nums[k];
            max_sum = fmaxl(max_sum, sum);
        }
        res += max_sum;
        //第一段求累加最大值
        max_sum = 0;
        sum = 0;
        for (int k = p - 2; k >= i; k--) {
            sum += nums[k];
            max_sum = fmaxl(max_sum, sum);
        }
        res += max_sum;
        //更新答案
        if (res > ans) {
            ans = res;
        }
        i = q - 1;
    }
    return ans;
}
```

```TypeScript
function maxSumTrionic(nums: number[]): number {
    const n = nums.length;
    let p: number, q: number, j: number;
    let max_sum: number, sum: number, res: number;
    let ans: number = -Infinity;
    for (let i = 0; i < n; i++) {
        j = i + 1;
        res = 0;
        //第一段
        for(; j < n && nums[j -1] < nums[j]; j++);
        p = j - 1;
        if (p === i) {
            continue;
        }
        //第二段
        res += nums[p] + nums[p - 1];
        for(; j < n && nums[j - 1] > nums[j]; j++){
            res += nums[j];
        }
        q = j - 1;
        if (q === p || q === n - 1 || (j < n && nums[j] <= nums[q])) {
            i = q;
            continue;
        }
        //第三段
        res += nums[q + 1];
        //第三段求累加最大值
        max_sum = 0;
        sum = 0;
        for (let k = q + 2; k < n && nums[k] > nums[k - 1]; k++) {
            sum += nums[k];
            max_sum = Math.max(max_sum, sum);
        }
        res += max_sum;
        //第一段求累加最大值
        max_sum = 0;
        sum = 0;
        for (let k = p - 2; k >= i; k--) {
            sum += nums[k];
            max_sum = Math.max(max_sum, sum);
        }
        res += max_sum;
        //更新答案
        ans = Math.max(ans, res);
        i = q - 1;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn max_sum_trionic(nums: Vec<i32>) -> i64 {
        let n = nums.len();
        let mut p: usize;
        let mut q: usize;
        let mut j: usize;
        let mut max_sum: i64;
        let mut sum: i64;
        let mut res: i64;
        let mut ans: i64 = i64::MIN;
        let mut i = 0;
        while i < n {
            j = i + 1;
            res = 0;
            //第一段
            while j < n && nums[j - 1] < nums[j] {
                j += 1;
            }
            p = j - 1;
            if p == i {
                i += 1;
                continue;
            }
            //第二段
            res += (nums[p] + nums[p - 1]) as i64;
            while j < n && nums[j - 1] > nums[j] {
                res += nums[j] as i64;
                j += 1;
            }
            q = j - 1;
            if q == p || q == n - 1 || (j < n && nums[j] <= nums[q]) {
                i = q;
                continue;
            }
            //第三段
            res += nums[q + 1] as i64;
            //第三段求累加最大值
            max_sum = 0;
            sum = 0;
            let mut k = q + 2;
            while k < n && nums[k] > nums[k - 1] {
                sum += nums[k] as i64;
                if sum > max_sum {
                    max_sum = sum;
                }
                k += 1;
            }
            res += max_sum;
            //第一段求累加最大值
            max_sum = 0;
            sum = 0;
            let mut k = p as isize - 2;
            while k >= i as isize {
                sum += nums[k as usize] as i64;
                if sum > max_sum {
                    max_sum = sum;
                }
                k -= 1;
            }
            res += max_sum;
            //更新答案
            if res > ans {
                ans = res;
            }
            i = q - 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(1)$。
