### [交替子数组计数](https://leetcode.cn/problems/count-alternating-subarrays/solutions/2828635/jiao-ti-zi-shu-zu-ji-shu-by-leetcode-sol-p8l2/)

#### 方法一：遍历

**思路与算法**

遍历数组，记录上一个数的数值和当前最长交替子数组的长度。如果当前数和之前的数不一样，则交替子数组的长度加一，否则交替子数组长度为一。
当前最长交替子数组的长度，即是以当前元素为结尾的交替子数组的个数，累加到答案当中。

最后返回结果即可。

**代码**

```C++
class Solution {
public:
    long long countAlternatingSubarrays(vector<int>& nums) {
        long long res = 0, cur = 0;
        int pre = -1;
        for (int a : nums) {
            cur = (pre != a) ? cur + 1 : 1;
            pre = a;
            res += cur;
        }
        return res;
    }
};
```

```Java
class Solution {
    public long countAlternatingSubarrays(int[] nums) {
        long res = 0, cur = 0;
        int pre = -1;
        for (int a : nums) {
            cur = (pre != a) ? cur + 1 : 1;
            pre = a;
            res += cur;
        }
        return res;
    }
}
```

```Python
class Solution:
    def countAlternatingSubarrays(self, nums: List[int]) -> int:
        res = cur = 0
        pre = -1
        for a in nums:
            if pre != a:
                cur += 1
            else:
                cur = 1
            pre = a
            res += cur
        return res
```

```JavaScript
var countAlternatingSubarrays = function(nums) {
    let res = 0, cur = 0, pre = -1;
    for (const a of nums) {
        cur = (pre != a) ? cur + 1 : 1;
        pre = a;
        res += cur;
    }
    return res;
};
```

```TypeScript
function countAlternatingSubarrays(nums: number[]): number {
    let res = 0, cur = 0, pre = -1;
    for (const a of nums) {
        cur = (pre != a) ? cur + 1 : 1;
        pre = a;
        res += cur;
    }
    return res;
};
```

```Go
func countAlternatingSubarrays(nums []int) int64 {
    var res, cur int64
    pre := -1
    for _, a := range nums {
        if pre != a {
            cur++
        } else {
            cur = 1
        }
        pre = a
        res += cur
    }
    return res
}
```

```CSharp
public class Solution {
    public long CountAlternatingSubarrays(int[] nums) {
        long res = 0, cur = 0;
        int pre = -1;
        foreach (int a in nums) {
            cur = (pre != a) ? cur + 1 : 1;
            pre = a;
            res += cur;
        }
        return res;
    }
}
```

```C
long long countAlternatingSubarrays(int* nums, int numsSize) {
    long long res = 0, cur = 0;
    int pre = -1;
    for (int i = 0; i < numsSize; i++) {
        cur = (pre != nums[i]) ? cur + 1 : 1;
        pre = nums[i];
        res += cur;
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn count_alternating_subarrays(nums: Vec<i32>) -> i64 {
        let mut res: i64 = 0;
        let mut cur = 0;
        let mut pre = -1;
        for &a in &nums {
            if pre != a {
                cur += 1;
            } else {
                cur = 1;
            }
            pre = a;
            res += cur;
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(1)$。
