### [有序三元组中的最大值 II](https://leetcode.cn/problems/maximum-value-of-an-ordered-triplet-ii/solutions/3610892/you-xu-san-yuan-zu-zhong-de-zui-da-zhi-i-angc/)

#### 方法一：贪心 + 前后缀数组

令数组 $nums$ 的长度为 $n$。根据值公式 $(nums[i]-nums[j]) \times nums[k]$ 可知，当固定 $j$ 时，$nums[i]$ 和 $nums[k]$ 分别取 $[0,j)$ 和 $[j+1,n)$ 的最大值时，三元组的值最大。我们使用 $leftMax[j]$ 和 $rightMax[j]$ 维护前缀 $[0,j)$ 最大值和后缀 $[j+1,n)$ 最大值，依次枚举 $j$，计算值 $(leftMax[j]-nums[j]) \times rightMax[j]$，返回最大值（若所有值都为负数，则返回 $0$）。

```C++
class Solution {
public:
    long long maximumTripletValue(vector<int>& nums) {
        int n = nums.size();
        vector<int> leftMax(n), rightMax(n);
        for (int i = 1; i < n; i++) {
            leftMax[i] = max(leftMax[i - 1], nums[i - 1]);
            rightMax[n - 1 - i] = max(rightMax[n - i], nums[n - i]);
        }
        long long res = 0;
        for (int j = 1; j < n - 1; j++) {
            res = max(res, (long long)(leftMax[j] - nums[j]) * rightMax[j]);
        }
        return res;
    }
};
```

```Go
func maximumTripletValue(nums []int) int64 {
    n := len(nums)
    leftMax := make([]int, n)
    rightMax := make([]int, n)
    for i := 1; i < n; i++ {
        leftMax[i] = max(leftMax[i - 1], nums[i - 1])
    }
    for i := 1; i < n; i++ {
        rightMax[n - 1 - i] = max(rightMax[n - i], nums[n - i])
    }
    var res int64 = 0
    for j := 1; j < n - 1; j++ {
        res = max(res, int64((leftMax[j] - nums[j]) * rightMax[j]))
    }
    return res
}
```

```Python
class Solution:
    def maximumTripletValue(self, nums: List[int]) -> int:
        n = len(nums)
        leftMax = [0] * n
        rightMax = [0] * n
        for i in range(1, n):
            leftMax[i] = max(leftMax[i - 1], nums[i - 1])
            rightMax[n - 1 - i] = max(rightMax[n - i], nums[n - i])
        res = 0
        for j in range(1, n - 1):
            res = max(res, (leftMax[j] - nums[j]) * rightMax[j])
        return res
```

```Java
public class Solution {
    public long maximumTripletValue(int[] nums) {
        int n = nums.length;
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];
        for (int i = 1; i < n; i++) {
            leftMax[i] = Math.max(leftMax[i - 1], nums[i - 1]);
            rightMax[n - 1 - i] = Math.max(rightMax[n - i], nums[n - i]);
        }
        long res = 0;
        for (int j = 1; j < n - 1; j++) {
            res = Math.max(res, (long)(leftMax[j] - nums[j]) * rightMax[j]);
        }
        return res;
    }
}
```

```JavaScript
var maximumTripletValue = function(nums) {
    const n = nums.length;
    const leftMax = new Array(n).fill(0);
    const rightMax = new Array(n).fill(0);
    for (let i = 1; i < n; i++) {
        leftMax[i] = Math.max(leftMax[i - 1], nums[i - 1]);
        rightMax[n - 1 - i] = Math.max(rightMax[n - i], nums[n - i]);
    }
    let res = 0;
    for (let j = 1; j < n - 1; j++) {
        res = Math.max(res, (leftMax[j] - nums[j]) * rightMax[j]);
    }
    return res;
};
```

```TypeScript
function maximumTripletValue(nums: number[]): number {
    const n = nums.length;
    const leftMax: number[] = new Array(n).fill(0);
    const rightMax: number[] = new Array(n).fill(0);
    for (let i = 1; i < n; i++) {
        leftMax[i] = Math.max(leftMax[i - 1], nums[i - 1]);
        rightMax[n - 1 - i] = Math.max(rightMax[n - i], nums[n - i]);
    }
    let res = 0;
    for (let j = 1; j < n - 1; j++) {
        res = Math.max(res, (leftMax[j] - nums[j]) * rightMax[j]);
    }
    return res;
}
```

```CSharp
public class Solution {
    public long MaximumTripletValue(int[] nums) {
        int n = nums.Length;
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];
        for (int i = 1; i < n; i++) {
            leftMax[i] = Math.Max(leftMax[i - 1], nums[i - 1]);
            rightMax[n - 1 - i] = Math.Max(rightMax[n - i], nums[n - i]);
        }
        long res = 0;
        for (int j = 1; j < n - 1; j++) {
            res = Math.Max(res, (long)(leftMax[j] - nums[j]) * rightMax[j]);
        }
        return res;
    }
}
```

```C
long long maximumTripletValue(int *nums, int numsSize) {
    int leftMax[numsSize], rightMax[numsSize];
    leftMax[0] = 0;
    rightMax[numsSize - 1] = 0;
    for (int i = 1; i < numsSize; i++) {
        leftMax[i] = fmax(leftMax[i - 1], nums[i - 1]);
        rightMax[numsSize - 1 - i] = fmax(rightMax[numsSize - i], nums[numsSize - i]);
    }
    long long res = 0;
    for (int j = 1; j < numsSize - 1; j++) {
        long long temp = (long long)(leftMax[j] - nums[j]) * rightMax[j];
        res = fmax(res, temp);
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn maximum_triplet_value(nums: Vec<i32>) -> i64 {
        let n = nums.len();
        let mut left_max = vec![0; n];
        let mut right_max = vec![0; n];
        for i in 1..n {
            left_max[i] = left_max[i - 1].max(nums[i - 1]);
            right_max[n - i - 1] = right_max[n - i].max(nums[n - i]);
        }
        let mut res = 0;
        for j in 1..n - 1 {
            res = res.max((left_max[j] - nums[j]) as i64 * right_max[j] as i64);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(n)$。

#### 方法二：贪心

类似于方法一，我们固定 $k$，那么当 $nums[i]-nums[j]$ 取最大值时，三元组的值最大。我们可以用 $imax$ 维护 $nums[i]$ 的最大值，$dmax$ 维护 $nums[i]-nums[j]$ 的最大值，在枚举 $k$ 的过程中，更新 $dmax$ 和 $imax$。

```C++
class Solution {
public:
    long long maximumTripletValue(vector<int>& nums) {
        int n = nums.size();
        long long res = 0, imax = 0, dmax = 0;
        for (int k = 0; k < n; k++) {
            res = max(res, dmax * nums[k]);
            dmax = max(dmax, imax - nums[k]);
            imax = max(imax, static_cast<long long>(nums[k]));
        }
        return res;
    }
};
```

```Java
class Solution {
    public long maximumTripletValue(int[] nums) {
        int n = nums.length;
        long res = 0, imax = 0, dmax = 0;
        for (int k = 0; k < n; k++) {
            res = Math.max(res, dmax * nums[k]);
            dmax = Math.max(dmax, imax - nums[k]);
            imax = Math.max(imax, nums[k]);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public long MaximumTripletValue(int[] nums) {
        int n = nums.Length;
        long res = 0, imax = 0, dmax = 0;
        for (int k = 0; k < n; k++) {
            res = Math.Max(res, dmax * nums[k]);
            dmax = Math.Max(dmax, imax - nums[k]);
            imax = Math.Max(imax, nums[k]);
        }
        return res;
    }
}
```

```Python
class Solution:
    def maximumTripletValue(self, nums: List[int]) -> int:
        n = len(nums)
        res, imax, dmax = 0, 0, 0
        for k in range(n):
            res = max(res, dmax * nums[k])
            dmax = max(dmax, imax - nums[k])
            imax = max(imax, nums[k])
        return res
```

```C
long long maximumTripletValue(int* nums, int numsSize) {
    long long res = 0, imax = 0, dmax = 0;
    for (int k = 0; k < numsSize; k++) {
        res = fmax(res, dmax * nums[k]);
        dmax = fmax(dmax, imax - nums[k]);
        imax = fmax(imax, nums[k]);
    }
    return res;
}
```

```Go
func maximumTripletValue(nums []int) int64 {
    n := len(nums)
    var res, imax, dmax int64 = 0, 0, 0
    for k := 0; k < n; k++ {
        res = max(res, dmax * int64(nums[k]))
        dmax = max(dmax, imax - int64(nums[k]))
        imax = max(imax, int64(nums[k]))
    }
    return res
}
```

```JavaScript
var maximumTripletValue = function(nums) {
    const n = nums.length;
    let res = 0, imax = 0, dmax = 0;
    for (let k = 0; k < n; k++) {
        res = Math.max(res, dmax * nums[k]);
        dmax = Math.max(dmax, imax - nums[k]);
        imax = Math.max(imax, nums[k]);
    }
    return res;
};
```

```TypeScript
function maximumTripletValue(nums: number[]): number {
    const n: number = nums.length;
    let res: number = 0, imax: number = 0, dmax: number = 0;
    for (let k = 0; k < n; k++) {
        res = Math.max(res, dmax * nums[k]);
        dmax = Math.max(dmax, imax - nums[k]);
        imax = Math.max(imax, nums[k]);
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn maximum_triplet_value(nums: Vec<i32>) -> i64 {
        let mut res = 0;
        let mut imax = 0;
        let mut dmax = 0;
        for &num in nums.iter() {
            res = res.max(dmax * num as i64);
            dmax = dmax.max(imax - num as i64);
            imax = imax.max(num as i64);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
