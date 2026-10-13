### [最大交替平方和](https://leetcode.cn/problems/maximum-alternating-sum-of-squares/solutions/4039939/zui-da-jiao-ti-ping-fang-he-by-leetcode-oanjp/)

#### 方法一：贪心 + 排序

**思路与算法**

令数组 $nums$ 的长度为 $n$，题目要求我们求出将 $nums$ 重新排序后 $\sum\limits_{i=0}^{n-1}(-1)^{i}nums_i^2$ 的最大值。

容易想到一个贪心策略，即符号为负时，安排绝对值更小的数。符号为正时，安排绝对值更大的数。这样能够使结果最大。

具体实现时，可以将数组按绝对值排序，也可以将数组的每一个元素平方后再排序。然后取前 $\big\lfloor\dfrac{n}{n}\big\rfloor$ 项作为负数项，其余元素作为正数项，求和即可。

**代码**

```C++
class Solution {
public:
    long long maxAlternatingSum(vector<int>& nums) {
        int n = nums.size();
        for (auto& num : nums) {
            num *= num;
        }
        ranges::sort(nums);
        return -accumulate(nums.begin(), nums.begin() + n / 2, 0LL) +
               accumulate(nums.begin() + n / 2, nums.end(), 0LL);
    }
};
```

```Python
class Solution:
    def maxAlternatingSum(self, nums: List[int]) -> int:
        n = len(nums)
        for i in range(n):
            nums[i] *= nums[i]
        nums.sort()
        return -sum(nums[:n // 2]) + sum(nums[n // 2:])
```

```Java
class Solution {
    public long maxAlternatingSum(int[] nums) {
        int n = nums.length;
        for (int i = 0; i < n; i++) {
            nums[i] *= nums[i];
        }
        Arrays.sort(nums);

        long ans = 0;
        for (int i = 0; i < n / 2; i++) {
            ans -= nums[i];
        }
        for (int i = n / 2; i < n; i++) {
            ans += nums[i];
        }
        return ans;
    }
}
```

```C
int cmp(const void* a, const void* b) {
    int x = *(const int*)a;
    int y = *(const int*)b;
    return (x > y) - (x < y);
}

long long maxAlternatingSum(int* nums, int numsSize) {
    int n = numsSize;
    for (int i = 0; i < n; i++) {
        nums[i] *= nums[i];
    }
    qsort(nums, n, sizeof(int), cmp);

    long long ans = 0;
    for (int i = 0; i < n / 2; i++) {
        ans -= nums[i];
    }
    for (int i = n / 2; i < n; i++) {
        ans += nums[i];
    }
    return ans;
}
```

```Go
func maxAlternatingSum(nums []int) int64 {
    n := len(nums)
    for i := range nums {
        nums[i] *= nums[i]
    }
    sort.Ints(nums)

    var ans int64
    for i := 0; i < n/2; i++ {
        ans -= int64(nums[i])
    }
    for i := n / 2; i < n; i++ {
        ans += int64(nums[i])
    }
    return ans
}
```

```CSharp
public class Solution {
    public long MaxAlternatingSum(int[] nums) {
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            nums[i] *= nums[i];
        }
        Array.Sort(nums);

        long ans = 0;
        for (int i = 0; i < n / 2; i++) {
            ans -= nums[i];
        }
        for (int i = n / 2; i < n; i++) {
            ans += nums[i];
        }
        return ans;
    }
}
```

```JavaScript
var maxAlternatingSum = function(nums) {
    const n = nums.length;
    for (let i = 0; i < n; i++) {
        nums[i] *= nums[i];
    }
    nums.sort((a, b) => a - b);

    let ans = 0;
    for (let i = 0; i < Math.floor(n / 2); i++) {
        ans -= nums[i];
    }
    for (let i = Math.floor(n / 2); i < n; i++) {
        ans += nums[i];
    }
    return ans;
};
```

```TypeScript
function maxAlternatingSum(nums: number[]): number {
    const n = nums.length;
    for (let i = 0; i < n; i++) {
        nums[i] *= nums[i];
    }
    nums.sort((a, b) => a - b);

    let ans = 0;
    for (let i = 0; i < Math.floor(n / 2); i++) {
        ans -= nums[i];
    }
    for (let i = Math.floor(n / 2); i < n; i++) {
        ans += nums[i];
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn max_alternating_sum(nums: Vec<i32>) -> i64 {
        let mut nums = nums;
        let n = nums.len();

        for num in nums.iter_mut() {
            *num *= *num;
        }
        nums.sort_unstable();

        let mut ans = 0i64;
        for i in 0..n / 2 {
            ans -= nums[i] as i64;
        }
        for i in n / 2..n {
            ans += nums[i] as i64;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$ 或 $O(n)$，其中 $n$ 是数组 $nums$ 的长度。排序需要 $O(n\log n)$ 的时间。如果使用快速选择算法代替排序，则可以达到 $O(n)$ 的平均时间复杂度。
- 空间复杂度：$O(1)$。只使用了若干额外变量。
