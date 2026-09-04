### [最小稳定下标 I](https://leetcode.cn/problems/smallest-stable-index-i/solutions/4018459/zui-xiao-wen-ding-xia-biao-i-by-leetcode-j2et/)

#### 方法一：枚举

**思路与算法**

记数组 $nums$ 的长度为 $n$。由于数据范围较小，我们可以直接枚举每个下标并计算其不稳定值。

从 $0$ 到 $n-1$ 依次枚举下标 $i$。对于每个 $i$，遍历 $nums[0..i]$ 求出最大值，遍历 $nums[i..n-1]$ 求出最小值，二者之差即为该下标的不稳定值。若该值不超过 $k$，则 $i$ 就是最小的稳定下标，直接返回。

若所有下标都不满足条件，返回 $-1$。

**代码**

```C++
class Solution {
public:
    int firstStableIndex(vector<int>& nums, int k) {
        int n = nums.size();
        for (int i = 0; i < n; ++i) {
            int maxValue = nums[i], minValue = nums[i];
            for (int j = 0; j < i; ++j) {
                maxValue = max(maxValue, nums[j]);
            }
            for (int j = i + 1; j < n; ++j) {
                minValue = min(minValue, nums[j]);
            }
            if (maxValue - minValue <= k) {
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
        for i in range(n):
            maxValue = minValue = nums[i]
            for j in range(i):
                maxValue = max(maxValue, nums[j])
            for j in range(i + 1, n):
                minValue = min(minValue, nums[j])
            if maxValue - minValue <= k:
                return i
        return -1
```

```Java
public class Solution {
    public int firstStableIndex(int[] nums, int k) {
        int n = nums.length;
        for (int i = 0; i < n; i++) {
            int maxValue = nums[i];
            int minValue = nums[i];
            for (int j = 0; j < i; j++) {
                maxValue = Math.max(maxValue, nums[j]);
            }
            for (int j = i + 1; j < n; j++) {
                minValue = Math.min(minValue, nums[j]);
            }
            if (maxValue - minValue <= k) {
                return i;
            }
        }
        return -1;
    }
}
```

```CSharp
public class Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            int maxValue = nums[i];
            int minValue = nums[i];
            for (int j = 0; j < i; j++) {
                maxValue = Math.Max(maxValue, nums[j]);
            }
            for (int j = i + 1; j < n; j++) {
                minValue = Math.Min(minValue, nums[j]);
            }
            if (maxValue - minValue <= k) {
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
    for i := 0; i < n; i++ {
        maxValue := nums[i]
        minValue := nums[i]
        for j := 0; j < i; j++ {
            if nums[j] > maxValue {
                maxValue = nums[j]
            }
        }
        for j := i + 1; j < n; j++ {
            if nums[j] < minValue {
                minValue = nums[j]
            }
        }
        if maxValue-minValue <= k {
            return i
        }
    }
    return -1
}
```

```C
int firstStableIndex(int* nums, int numsSize, int k) {
    int n = numsSize;
    for (int i = 0; i < n; i++) {
        int maxValue = nums[i];
        int minValue = nums[i];
        for (int j = 0; j < i; j++) {
            maxValue = fmax(maxValue, nums[j]);
        }
        for (int j = i + 1; j < n; j++) {
            minValue = fmin(minValue, nums[j]);
        }
        if (maxValue - minValue <= k) {
            return i;
        }
    }
    return -1;
}
```

```JavaScript
var firstStableIndex = function(nums, k) {
    const n = nums.length;
    for (let i = 0; i < n; i++) {
        let maxValue = nums[i];
        let minValue = nums[i];
        for (let j = 0; j < i; j++) {
            maxValue = Math.max(maxValue, nums[j]);
        }
        for (let j = i + 1; j < n; j++) {
            minValue = Math.min(minValue, nums[j]);
        }
        if (maxValue - minValue <= k) {
            return i;
        }
    }
    return -1;
};
```

```TypeScript
function firstStableIndex(nums: number[], k: number): number {
    const n = nums.length;
    for (let i = 0; i < n; i++) {
        let maxValue = nums[i];
        let minValue = nums[i];
        for (let j = 0; j < i; j++) {
            maxValue = Math.max(maxValue, nums[j]);
        }
        for (let j = i + 1; j < n; j++) {
            minValue = Math.min(minValue, nums[j]);
        }
        if (maxValue - minValue <= k) {
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
        for i in 0..n {
            let mut max_value = nums[i];
            let mut min_value = nums[i];
            for j in 0..i {
                max_value = max_value.max(nums[j]);
            }
            for j in i + 1..n {
                min_value = min_value.min(nums[j]);
            }
            if max_value - min_value <= k {
                return i as i32;
            }
        }
        -1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $nums$ 的长度。枚举每个下标时，需要 $O(n)$ 的时间计算前缀最大值与后缀最小值。
- 空间复杂度：$O(1)$。
