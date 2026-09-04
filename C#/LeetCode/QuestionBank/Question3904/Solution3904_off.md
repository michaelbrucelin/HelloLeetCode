### [最小稳定下标 II](https://leetcode.cn/problems/smallest-stable-index-ii/solutions/4018463/zui-xiao-wen-ding-xia-biao-ii-by-leetcod-r3mj/)

#### 方法一：前缀最大值 + 后缀最小值

**思路与算法**

本题是[「3903. 最小稳定下标 I」](https://leetcode.cn/problems/smallest-stable-index-i/)的数据加强版，需要 $O(n)$ 的算法，其中 $n$ 是数组 $nums$ 的长度。

我们预处理数组 $minValue$，其中 $minValue[i]$ 表示 $nums[i..n-1]$ 中的最小值。从后往前遍历即可：

- $minValue[n-1]=nums[n-1]$；
- 对于 $i\ne n-1$ 的情况，$minValue[i]=min(minValue[i+1],nums[i])$。

然后从前往后遍历，维护变量 $maxValue$ 表示 $nums[0..i]$ 中的最大值。对于每个下标 $i$，不稳定值为 $maxValue-minValue[i]$。若该值不超过 $k$，则 $i$ 即为最小的稳定下标，直接返回；若遍历结束仍未找到，返回 $-1$。

**代码**

```C++
class Solution {
public:
    int firstStableIndex(vector<int>& nums, int k) {
        int n = nums.size();
        vector<int> minValue(n);
        minValue[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            minValue[i] = min(minValue[i + 1], nums[i]);
        }

        int maxValue = 0;
        for (int i = 0; i < n; ++i) {
            maxValue = max(maxValue, nums[i]);
            if (maxValue - minValue[i] <= k) {
                return i;
            }
        }
        return -1;
    }
};
```

```Python
class Solution:
    def firstStableIndex(self, nums: list[int], k: int) -> int:
        n = len(nums)
        minValue = [inf] * (n - 1) + [nums[-1]]
        for i in range(n - 2, -1, -1):
            minValue[i] = min(minValue[i + 1], nums[i])

        maxValue = 0
        for i in range(n):
            maxValue = max(maxValue, nums[i])
            if maxValue - minValue[i] <= k:
                return i
        return -1
```

```Java
class Solution {
    public int firstStableIndex(int[] nums, int k) {
        int n = nums.length;
        int[] minValue = new int[n];
        minValue[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            minValue[i] = Math.min(minValue[i + 1], nums[i]);
        }

        int maxValue = 0;
        for (int i = 0; i < n; i++) {
            maxValue = Math.max(maxValue, nums[i]);
            if (maxValue - minValue[i] <= k) {
                return i;
            }
        }
        return -1;
    }
}
```

```CSharp
class Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int n = nums.Length;
        int[] minValue = new int[n];
        minValue[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            minValue[i] = Math.Min(minValue[i + 1], nums[i]);
        }

        int maxValue = 0;
        for (int i = 0; i < n; i++) {
            maxValue = Math.Max(maxValue, nums[i]);
            if (maxValue - minValue[i] <= k) {
                return i;
            }
        }
        return -1;
    }
}
```

```Go
func firstStableIndex(nums []int, k int) int {
    n := len(nums)
    if n == 0 {
        return -1
    }

    minValue := make([]int, n)
    minValue[n-1] = nums[n-1]
    for i := n - 2; i >= 0; i-- {
        if minValue[i+1] < nums[i] {
            minValue[i] = minValue[i+1]
        } else {
            minValue[i] = nums[i]
        }
    }

    maxValue := 0
    for i := 0; i < n; i++ {
        if nums[i] > maxValue {
            maxValue = nums[i]
        }
        if maxValue-minValue[i] <= k {
            return i
        }
    }
    return -1
}
```

```C
int firstStableIndex(int* nums, int numsSize, int k) {
    int n = numsSize;
    if (n == 0) return -1;

    int* minValue = (int*)malloc(n * sizeof(int));
    minValue[n - 1] = nums[n - 1];
    for (int i = n - 2; i >= 0; i--) {
        minValue[i] = fmin(minValue[i + 1], nums[i]);
    }

    int maxValue = 0;
    int result = -1;
    for (int i = 0; i < n; i++) {
        maxValue = fmax(nums[i], maxValue);
        if (maxValue - minValue[i] <= k) {
            result = i;
            break;
        }
    }

    free(minValue);
    return result;
}
```

```JavaScript
var firstStableIndex = function(nums, k) {
    const n = nums.length;
    if (n === 0) {
        return -1;
    }
    const minValue = new Array(n);
    minValue[n - 1] = nums[n - 1];
    for (let i = n - 2; i >= 0; i--) {
        minValue[i] = Math.min(minValue[i + 1], nums[i]);
    }

    let maxValue = 0;
    for (let i = 0; i < n; i++) {
        maxValue = Math.max(maxValue, nums[i]);
        if (maxValue - minValue[i] <= k) {
            return i;
        }
    }
    return -1;
};

```

```TypeScript
function firstStableIndex(nums: number[], k: number): number {
    const n = nums.length;
    if (n === 0) {
        return -1;
    }
    const minValue: number[] = new Array(n);
    minValue[n - 1] = nums[n - 1];
    for (let i = n - 2; i >= 0; i--) {
        minValue[i] = Math.min(minValue[i + 1], nums[i]);
    }

    let maxValue: number = 0;
    for (let i = 0; i < n; i++) {
        maxValue = Math.max(maxValue, nums[i]);
        if (maxValue - minValue[i] <= k) {
            return i;
        }
    }
    return -1;
}
```

```Rust
impl Solution {
    pub fn first_stable_index(nums: Vec<i32>, k: i32) -> i32 {
        let n = nums.len();
        if n == 0 {
            return -1;
        }

        let mut min_value = vec![0; n];
        min_value[n - 1] = nums[n - 1];
        for i in (0..n - 1).rev() {
            min_value[i] = min_value[i + 1].min(nums[i]);
        }

        let mut max_value = 0;
        for i in 0..n {
            max_value = max_value.max(nums[i]);
            if max_value - min_value[i] <= k {
                return i as i32;
            }
        }
        -1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。预处理后缀最小值与从前往后遍历各需要 $O(n)$ 的时间。
- 空间复杂度：$O(n)$，即为数组 $minValue$ 需要使用的空间。
