### [使数组平衡的最少移除数目](https://leetcode.cn/problems/minimum-removals-to-balance-array/solutions/3895129/shi-shu-zu-ping-heng-de-zui-shao-yi-chu-utab7/)

#### 方法一：排序 + 双指针

**思路与算法**

我们将数组 $nums$ 进行排序。当我们移除若干个元素，使数组平衡时，记数组中元素最小值为 $min$，最大值为 $max$，那么我们移除了 $nums$ 中所有严格小于 $min$，以及所有严格大于 $max$ 的元素。移除在 $[min,max]$ 中的元素是没有意义的。

因此，我们可以使用双指针解决本题。左指针 $left$ 最初指向排序后的首元素 $x$，而右指针 $right$ 不断向右移动，直到指向第一个严格大于 $k\times x$ 的元素，或者超出数组的边界为止。此时左闭右开的区间 $[left,right)$ 对应着一个平衡的数组，长度为 $right-left$。

在左指针 $left$ 不断向右移动的过程中，我们不断用 $n-(right-left)$ 更新答案即可，其中 $n$ 是数组 $nums$ 的长度。

**代码**

```C++
class Solution {
public:
    int minRemoval(vector<int>& nums, int k) {
        int n = nums.size();
        sort(nums.begin(), nums.end());

        int ans = n, right = 0;
        for (int left = 0; left < n; ++left) {
            while (right < n && nums[right] <= static_cast<long long>(nums[left]) * k) {
                ++right;
            }
            ans = min(ans, n - (right - left));
        }

        return ans;
    }
};
```

```Python
class Solution:
    def minRemoval(self, nums: List[int], k: int) -> int:
        n = len(nums)
        nums.sort()

        ans = n
        right = 0
        for left in range(n):
            while right < n and nums[right] <= nums[left] * k:
                right += 1
            ans = min(ans, n - (right - left))

        return ans
```

```Java
class Solution {
    public int minRemoval(int[] nums, int k) {
        int n = nums.length;
        Arrays.sort(nums);

        int ans = n;
        int right = 0;

        for (int left = 0; left < n; left++) {
            while (right < n && nums[right] <= (long)nums[left] * k) {
                right++;
            }
            ans = Math.min(ans, n - (right - left));
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinRemoval(int[] nums, int k) {
        int n = nums.Length;
        Array.Sort(nums);

        int ans = n;
        int right = 0;

        for (int left = 0; left < n; left++) {
            while (right < n && nums[right] <= (long)nums[left] * k) {
                right++;
            }
            ans = Math.Min(ans, n - (right - left));
        }

        return ans;
    }
}
```

```Go
func minRemoval(nums []int, k int) int {
    n := len(nums)
    sort.Ints(nums)

    ans := n
    right := 0

    for left := 0; left < n; left++ {
        for right < n && int64(nums[right]) <= int64(nums[left]) * int64(k) {
            right++
        }
        current := n - (right - left)
        if current < ans {
            ans = current
        }
    }

    return ans
}
```

```C
int compare(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

int minRemoval(int* nums, int numsSize, int k) {
    qsort(nums, numsSize, sizeof(int), compare);

    int ans = numsSize;
    int right = 0;

    for (int left = 0; left < numsSize; left++) {
        while (right < numsSize && (long long)nums[right] <= (long long)nums[left] * k) {
            right++;
        }
        int current = numsSize - (right - left);
        if (current < ans) {
            ans = current;
        }
    }

    return ans;
}
```

```JavaScript
var minRemoval = function(nums, k) {
    const n = nums.length;
    nums.sort((a, b) => a - b);

    let ans = n;
    let right = 0;

    for (let left = 0; left < n; left++) {
        while (right < n && nums[right] <= nums[left] * k) {
            right++;
        }
        ans = Math.min(ans, n - (right - left));
    }

    return ans;
}
```

```TypeScript
function minRemoval(nums: number[], k: number): number {
    const n = nums.length;
    nums.sort((a, b) => a - b);

    let ans = n;
    let right = 0;
    for (let left = 0; left < n; left++) {
        while (right < n && nums[right] <= nums[left] * k) {
            right++;
        }
        ans = Math.min(ans, n - (right - left));
    }

    return ans;
}
```

```Rust
impl Solution {
    pub fn min_removal(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len();
        let mut nums = nums;
        nums.sort();

        let mut ans = n as i32;
        let mut right = 0;

        for left in 0..n {
            while right < n && (nums[right] as i64) <= (nums[left] as i64) * (k as i64) {
                right += 1;
            }
            ans = ans.min(n as i32 - (right - left) as i32);
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是数组 $nums$ 的长度。排序需要的时间为 $O(n\log n)$，双指针计算答案需要的时间为 $O(n)$。
- 空间复杂度：$O(\log n)$，即为排序需要使用的栈空间大小。大部分语言自带的排序为变种的快速排序。
