### [超过阈值的最少操作数 I](https://leetcode.cn/problems/minimum-operations-to-exceed-threshold-value-i/solutions/3040103/chao-guo-yu-zhi-de-zui-shao-cao-zuo-shu-q9obn/)

#### 方法一：遍历

**思路与算法**

遍历数组，和 $k$ 比较大小，返回比 $k$ 小的元素的个数。

**代码**

```C++
class Solution {
public:
    int minOperations(vector<int>& nums, int k) {
        int res = 0;
        for (int num: nums) {
            if (num < k) {
                res++;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int minOperations(int[] nums, int k) {
        int res = 0;
        for (int num : nums) {
            if (num < k) {
                res++;
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def minOperations(self, nums: List[int], k: int) -> int:
        res = 0
        for num in nums:
            if num < k:
                res += 1
        return res
```

```JavaScript
var minOperations = function(nums, k) {
    let res = 0;
    for (let num of nums) {
        if (num < k) {
            res++;
        }
    }
    return res;
};
```

```TypeScript
function minOperations(nums: number[], k: number): number {
    let res = 0;
    for (let num of nums) {
        if (num < k) {
            res++;
        }
    }
    return res;
};
```

```Go
func minOperations(nums []int, k int) int {
    res := 0
    for _, num := range nums {
        if num < k {
            res++
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public int MinOperations(int[] nums, int k) {
        int res = 0;
        foreach (int num in nums) {
            if (num < k) {
                res++;
            }
        }
        return res;
    }
}
```

```C
int minOperations(int* nums, int numsSize, int k) {
    int res = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] < k) {
            res++;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn min_operations(nums: Vec<i32>, k: i32) -> i32 {
        let mut res = 0;
        for num in nums {
            if num < k {
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(1)$。
