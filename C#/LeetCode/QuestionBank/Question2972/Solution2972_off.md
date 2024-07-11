### [统计移除递增子数组的数目 II](https://leetcode.cn/problems/count-the-number-of-incremovable-subarrays-ii/solutions/2834783/tong-ji-yi-chu-di-zeng-zi-shu-zu-de-shu-u702h/)

#### 方法一：双指针

**思路**

删除一个子数组后，整个数组还剩下前后两部分，需要满足这两个部分都是严格递增，并且第一部分的最后一个元素小于第二个部分的第一个元素。

基于这个思路，可以采用双指针的思想，先用左指针从前开始扫，指针停在最长严格递增的位置 $l$。如果 $l$ 等于最后一个元素，表示删除任意一个子数组即可，此时可直接计算答案。可以删除 $n$ 个长度为 $1$ 的，$n-1$ 个长度为 $2$ 的... $1$ 个长度为 $n$ 的子数组，一共有 $\frac{n \times (n+1)}{2}$ 个子数组。

对于一般情况把右指针从后扫，当 $nums[r] \le nums[l]$ 时，此时把左指针 $l$ 向前移动直到满足 $nums[r] \lt nums[l]$ 即可。此时可以删除子数组 $[l,r-1], [l-1,r-1] \dots [0,r-1]$，一共可贡献 $l+2$ 个答案。计算完 $r$ 的答案后，继续向前移动右指针，当不满足 $nums[r] \lt nums[r+1]$ 时，停止遍历。

**代码**

```C++
class Solution {
public:
    long long incremovableSubarrayCount(vector<int>& nums) {
        long long ans = 0;
        int len = nums.size();
        int l = 0;
        while (l < len - 1) {
            if (nums[l] >= nums[l + 1]) {
                break;
            }
            l++;
        }
        if (l == len - 1) {
            return 1LL * len * (len + 1) / 2;
        }

        ans += l + 2;
        for (int r = len - 1; r > 0; r--) {
            if (r < len - 1 && nums[r] >= nums[r + 1]) {
                break;
            }
            
            while (l >= 0 && nums[l] >= nums[r]) {
                l--;
            }
            ans += l + 2;
        } 
        
        return ans;
    }
};
```

```Java
class Solution {
    public long incremovableSubarrayCount(int[] nums) {
        long ans = 0;
        int len = nums.length;
        int l = 0;
        while (l < len - 1) {
            if (nums[l] >= nums[l + 1]) {
                break;
            }
            l++;
        }
        if (l == len - 1) {
            return 1L * len * (len + 1) / 2;
        }

        ans += l + 2;
        for (int r = len - 1; r > 0; r--) {
            if (r < len - 1 && nums[r] >= nums[r + 1]) {
                break;
            }
            
            while (l >= 0 && nums[l] >= nums[r]) {
                l--;
            }
            ans += l + 2;
        } 

        return ans;
    }
}
```

```CSharp
public class Solution {
    public long IncremovableSubarrayCount(int[] nums) {
        long ans = 0;
        int len = nums.Length;
        int l = 0;
        while (l < len - 1) {
            if (nums[l] >= nums[l + 1]) {
                break;
            }
            l++;
        }
        if (l == len - 1) {
            return 1L * len * (len + 1) / 2;
        }

        ans += l + 2;
        for (int r = len - 1; r > 0; r--) {
            if (r < len - 1 && nums[r] >= nums[r + 1]) {
                break;
            }
            
            while (l >= 0 && nums[l] >= nums[r]) {
                l--;
            }
            ans += l + 2;
        } 

        return ans;
    }
}
```

```C
long long incremovableSubarrayCount(int* nums, int numsSize) {
    long long ans = 0;
    int l = 0;

    while (l < numsSize - 1) {
        if (nums[l] >= nums[l + 1]) {
            break;
        }
        l++;
    }
    if (l == numsSize - 1) {
        return 1LL * numsSize * (numsSize + 1) / 2;
    }
    ans += l + 2;
    for (int r = numsSize - 1; r > 0; r--) {
        if (r < numsSize - 1 && nums[r] >= nums[r + 1]) {
            break;
        }
        while (l >= 0 && nums[l] >= nums[r]) {
            l--;
        }
        ans += l + 2;
    }

    return ans;
}
```

```Python
class Solution:
    def incremovableSubarrayCount(self, nums: List[int]) -> int:
        ans = 0
        l = 0

        while l < len(nums) - 1:
            if nums[l] >= nums[l + 1]:
                break
            l += 1
        if l == len(nums) - 1:
            return 1 * len(nums) * (len(nums) + 1) // 2

        ans += l + 2
        for r in range(len(nums) - 1, 0, -1):
            if r < len(nums) - 1 and nums[r] >= nums[r + 1]:
                break
            while l >= 0 and nums[l] >= nums[r]:
                l -= 1
            ans += l + 2
        return ans
```

```Go
func incremovableSubarrayCount(nums []int) int64 {
    var ans int64 = 0
    length := len(nums)
    l := 0
    for l < length-1 {
        if nums[l] >= nums[l+1] {
            break
        }
        l++
    }

    if l == length - 1 {
        return int64(length) * int64(length + 1) / 2
    }
    ans += int64(l + 2)
    for r := length - 1; r > 0; r-- {
        if r < length-1 && nums[r] >= nums[r + 1] {
            break
        }
        for l >= 0 && nums[l] >= nums[r] {
            l--
        }
        ans += int64(l + 2)
    }

    return ans
}
```

```JavaScript
var incremovableSubarrayCount = function(nums) {
    let ans = 0;
    const length = nums.length;
    let l = 0;

    while (l < length - 1) {
        if (nums[l] >= nums[l + 1]) {
            break;
        }
        l++;
    }
    if (l === length - 1) {
        return 1 * length * (length + 1) / 2;
    }

    ans += l + 2;
    for (let r = length - 1; r > 0; r--) {
        if (r < length - 1 && nums[r] >= nums[r + 1]) {
            break;
        }
        while (l >= 0 && nums[l] >= nums[r]) {
            l--;
        }
        ans += l + 2;
    }

    return ans;
};
```

```TypeScript
function incremovableSubarrayCount(nums: number[]): number {
    let ans = 0;
    const length = nums.length;
    let l = 0;
    while (l < length - 1) {
        if (nums[l] >= nums[l + 1]) {
            break;
        }
        l++;
    }

    if (l === length - 1) {
        return 1 * length * (length + 1) / 2;
    }
    ans += l + 2;
    for (let r = length - 1; r > 0; r--) {
        if (r < length - 1 && nums[r] >= nums[r + 1]) {
            break;
        }
        while (l >= 0 && nums[l] >= nums[r]) {
            l--;
        }
        ans += l + 2;
    }

    return ans;
};
```

```Rust
impl Solution {
    pub fn incremovable_subarray_count(nums: Vec<i32>) -> i64 {
        let mut ans: i64 = 0;
        let length = nums.len();
        let mut l = 0;

        while l < length - 1 {
            if nums[l] >= nums[l + 1] {
                break;
            }
            l += 1;
        }

        if l == length - 1 {
            return length as i64 * (length as i64 + 1) / 2;
        }
        ans += l as i64 + 2;
        for r in (1..length).rev() {
            if r < length - 1 && nums[r] >= nums[r + 1] {
                break;
            }

            while l as i32 >= 0 && nums[l] >= nums[r] {
                l -= 1;
            }
            ans += l as i64 + 2;
        }

        return ans;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组的长度。
- 空间复杂度：$O(1)$。
