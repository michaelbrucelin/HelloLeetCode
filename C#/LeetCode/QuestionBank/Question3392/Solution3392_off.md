### [统计符合条件长度为 3 的子数组数目](https://leetcode.cn/problems/count-subarrays-of-length-three-with-a-condition/solutions/3651614/tong-ji-fu-he-tiao-jian-chang-du-wei-3-d-t7rt/)

#### 方法一：一次遍历

**思路与算法**

记数组 $nums$ 的长度为 $n$，我们对在 $[1,n-2]$ 范围内的下标进行一次遍历。当遍历到下标 $i$ 时，如果 $nums[i]$ 与 $(nums[i-1]+nums[i+1]) \times 2$ 相等，那么答案增加 $1$。

**代码**

```C++
class Solution {
public:
    int countSubarrays(vector<int>& nums) {
        int n = nums.size();
        int ans = 0;
        for (int i = 1; i < n - 1; ++i) {
            if (nums[i] == (nums[i - 1] + nums[i + 1]) * 2) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countSubarrays(self, nums: List[int]) -> int:
        n = len(nums)
        ans = 0
        for i in range(1, n - 1):
            if nums[i] == (nums[i - 1] + nums[i + 1]) * 2:
                ans += 1
        return ans
```

```Java
class Solution {
    public int countSubarrays(int[] nums) {
        int n = nums.length;
        int ans = 0;
        for (int i = 1; i < n - 1; ++i) {
            if (nums[i] == (nums[i - 1] + nums[i + 1]) * 2) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountSubarrays(int[] nums) {
        int n = nums.Length;
        int ans = 0;
        for (int i = 1; i < n - 1; ++i) {
            if (nums[i] == (nums[i - 1] + nums[i + 1]) * 2) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```Go
func countSubarrays(nums []int) int {
    n := len(nums)
    ans := 0
    for i := 1; i < n - 1; i++ {
        if nums[i] == (nums[i - 1] + nums[i + 1]) * 2 {
            ans++
        }
    }
    return ans
}
```

```C
int countSubarrays(int* nums, int numsSize) {
    int ans = 0;
    for (int i = 1; i < numsSize - 1; ++i) {
        if (nums[i] == (nums[i - 1] + nums[i + 1]) * 2) {
            ++ans;
        }
    }
    return ans;
}
```

```JavaScript
var countSubarrays = function(nums) {
    const n = nums.length;
    let ans = 0;
    for (let i = 1; i < n - 1; ++i) {
        if (nums[i] === (nums[i - 1] + nums[i + 1]) * 2) {
            ++ans;
        }
    }
    return ans;
};
```

```TypeScript
function countSubarrays(nums: number[]): number {
    const n = nums.length;
    let ans = 0;
    for (let i = 1; i < n - 1; ++i) {
        if (nums[i] === (nums[i - 1] + nums[i + 1]) * 2) {
            ++ans;
        }
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn count_subarrays(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut ans = 0;
        for i in 1..n-1 {
            if nums[i] == (nums[i - 1] + nums[i + 1]) * 2 {
                ans += 1;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
