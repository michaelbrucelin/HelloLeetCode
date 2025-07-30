### [按位与最大的最长子数组](https://leetcode.cn/problems/longest-subarray-with-maximum-bitwise-and/solutions/3726046/an-wei-yu-zui-da-de-zui-chang-zi-shu-zu-w0t3f/)

#### 方法一：线性扫描

**思路与算法**

题目要求找到数组 $nums$ 中进行**按位与**运算得到的值**最大**的**非空**子数组的最长长度，最直接的办法则为枚举 $nums$ 的所有子数组，此时时间复杂度为 $O(n^2)$，实际可以进一步优化。根据**与**运算的性质可知 $a$ 和任意数 $x$ **与**运算的结果一定小于等于 $a$，即 $a\&x\le a$，因此数组中的连续子数组中**与**运算最大值一定为数组的最大值 $max(nums)$。设数组 $nums$ 最大值为 $maxVal$，根据**与**运算的性质可知，此时**最大**的**非空**子数组最大长度即为数组中连续出现 $maxVal$ 的最大次数，我们此时直接遍历数组，找到 $maxVal$ 连续出现的最大次数即为答案。

**代码**

```C++
class Solution {
public:
    int longestSubarray(vector<int>& nums) {
        int maxValue = nums[0];
        int ans = 1, cnt = 1;
        for (int i = 1; i < nums.size(); i++) {
            if (nums[i] > maxValue) {
                ans = cnt = 1;
                maxValue = nums[i];
            } else if (nums[i] < maxValue) {
                cnt = 0;
            } else if (nums[i] == maxValue) {
                cnt++;
            }
            ans = max(cnt, ans);
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int longestSubarray(int[] nums) {
        int maxValue = nums[0];
        int ans = 1, cnt = 1;
        for (int i = 1; i < nums.length; i++) {
            if (nums[i] > maxValue) {
                ans = cnt = 1;
                maxValue = nums[i];
            } else if (nums[i] < maxValue) {
                cnt = 0;
            } else if (nums[i] == maxValue) {
                cnt++;
            }
            ans = Math.max(cnt, ans);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int LongestSubarray(int[] nums) {
        int maxValue = nums[0];
        int ans = 1, cnt = 1;
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > maxValue) {
                ans = cnt = 1;
                maxValue = nums[i];
            } else if (nums[i] < maxValue) {
                cnt = 0;
            } else if (nums[i] == maxValue) {
                cnt++;
            }
            ans = Math.Max(cnt, ans);
        }
        return ans;
    }
}
```

```Go
func longestSubarray(nums []int) int {
    maxValue := nums[0]
    ans, cnt := 1, 1
    for i := 1; i < len(nums); i++ {
        if nums[i] > maxValue {
            ans, cnt = 1, 1
            maxValue = nums[i]
        } else if nums[i] < maxValue {
            cnt = 0
        } else if nums[i] == maxValue {
            cnt++
        }
        ans = max(ans, cnt)
    }
    return ans
}
```

```Python
class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        max_value = nums[0]
        ans = cnt = 1
        for i in range(1, len(nums)):
            if nums[i] > max_value:
                ans = cnt = 1
                max_value = nums[i]
            elif nums[i] < max_value:
                cnt = 0
            elif nums[i] == max_value:
                cnt += 1
            ans = max(cnt, ans)
        return ans
```

```C
int longestSubarray(int* nums, int numsSize) {
    int maxValue = nums[0];
    int ans = 1, cnt = 1;
    for (int i = 1; i < numsSize; i++) {
        if (nums[i] > maxValue) {
            ans = cnt = 1;
            maxValue = nums[i];
        } else if (nums[i] < maxValue) {
            cnt = 0;
        } else if (nums[i] == maxValue) {
            cnt++;
        }
        ans = fmax(ans, cnt);
    }
    return ans;
}
```

```JavaScript
var longestSubarray = function(nums) {
    let maxValue = nums[0];
    let ans = 1, cnt = 1;
    for (let i = 1; i < nums.length; i++) {
        if (nums[i] > maxValue) {
            ans = cnt = 1;
            maxValue = nums[i];
        } else if (nums[i] < maxValue) {
            cnt = 0;
        } else if (nums[i] === maxValue) {
            cnt++;
        }
        ans = Math.max(cnt, ans);
    }
    return ans;
};
```

```TypeScript
function longestSubarray(nums: number[]): number {
    let maxValue = nums[0];
    let ans = 1, cnt = 1;
    for (let i = 1; i < nums.length; i++) {
        if (nums[i] > maxValue) {
            ans = cnt = 1;
            maxValue = nums[i];
        } else if (nums[i] < maxValue) {
            cnt = 0;
        } else if (nums[i] === maxValue) {
            cnt++;
        }
        ans = Math.max(cnt, ans);
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn longest_subarray(nums: Vec<i32>) -> i32 {
        let mut max_value = nums[0];
        let mut ans = 1;
        let mut cnt = 1;
        for i in 1..nums.len() {
            if nums[i] > max_value {
                ans = 1;
                cnt = 1;
                max_value = nums[i];
            } else if nums[i] < max_value {
                cnt = 0;
            } else if nums[i] == max_value {
                cnt += 1;
            }
            ans = ans.max(cnt);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，$n$ 表示数组 $nums$ 的长度。经过优化后只需要遍历数组一遍即可，因此时间复杂度为 $O(n)$。
- 空间复杂度：$O(1)$。
