### [循环数组中相邻元素的最大差值](https://leetcode.cn/problems/maximum-difference-between-adjacent-elements-in-a-circular-array/solutions/3692736/xun-huan-shu-zu-zhong-xiang-lin-yuan-su-q5nq3/)

#### 方法一：遍历

**思路与算法**

首先计算首尾元素差的绝对值，作为最大绝对差值的初始值。然后遍历数组，计算相邻元素之间的绝对差值，更新答案。

最后返回循环数组的最大绝对差值。

**代码**

```C++
class Solution {
public:
    int maxAdjacentDistance(vector<int>& nums) {
        int n = nums.size();
        int res = abs(nums[0] - nums[n - 1]);
        for (int i = 0; i < n - 1; ++i) {
            res = max(res, abs(nums[i] - nums[i + 1]));
        }
        return res;
    }
};
```

```Java
class Solution {
    public int maxAdjacentDistance(int[] nums) {
        int n = nums.length;
        int res = Math.abs(nums[0] - nums[n - 1]);
        for (int i = 0; i < n - 1; ++i) {
            res = Math.max(res, Math.abs(nums[i] - nums[i + 1]));
        }
        return res;
    }
}
```

```Python
class Solution:
    def maxAdjacentDistance(self, nums: List[int]) -> int:
        n = len(nums)
        res = abs(nums[0] - nums[n - 1])
        for i in range(n - 1):
            res = max(res, abs(nums[i] - nums[i + 1]))
        return res
```

```JavaScript
var maxAdjacentDistance = function(nums) {
    const n = nums.length;
    let res = Math.abs(nums[0] - nums[n - 1]);
    for (let i = 0; i < n - 1; i++) {
        res = Math.max(res, Math.abs(nums[i] - nums[i + 1]));
    }
    return res;
};
```

```TypeScript
function maxAdjacentDistance(nums: number[]): number {
    const n = nums.length;
    let res = Math.abs(nums[0] - nums[n - 1]);
    for (let i = 0; i < n - 1; i++) {
        res = Math.max(res, Math.abs(nums[i] - nums[i + 1]));
    }
    return res;
};
```

```Go
func maxAdjacentDistance(nums []int) int {
    n := len(nums)
    res := int(math.Abs(float64(nums[0] - nums[n-1])))
    for i := 0; i < n-1; i++ {
        res = int(math.Max(float64(res), math.Abs(float64(nums[i]-nums[i+1]))))
    }
    return res
}
```

```CSharp
public class Solution {
    public int MaxAdjacentDistance(int[] nums) {
        int n = nums.Length;
        int res = Math.Abs(nums[0] - nums[n - 1]);
        for (int i = 0; i < n - 1; ++i) {
            res = Math.Max(res, Math.Abs(nums[i] - nums[i + 1]));
        }
        return res;
    }
}
```

```C
int maxAdjacentDistance(int* nums, int numsSize) {
    int res = abs(nums[0] - nums[numsSize - 1]);
    for (int i = 0; i < numsSize - 1; ++i) {
        res = fmax(res, abs(nums[i] - nums[i + 1]));
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn max_adjacent_distance(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut res = (nums[0] - nums[n - 1]).abs();
        for i in 0..n - 1 {
            res = res.max((nums[i] - nums[i + 1]).abs());
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(1)$。
