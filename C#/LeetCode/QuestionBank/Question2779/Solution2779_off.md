### [数组的最大美丽值](https://leetcode.cn/problems/maximum-beauty-of-an-array-after-applying-operation/solutions/2806897/shu-zu-de-zui-da-mei-li-zhi-by-leetcode-9jgs0/)

#### 方法一：排序 + 滑动窗口

根据题目对子序列的定义，我们知道元素的顺序对数组的美丽值无影响，因此我们先对数组 $\textit{nums}$ 进行排序。假设数组的最大美丽值对应的相等元素为 $x$，那么经过任意操作后，可以变为 $x$ 的元素范围为 $[x - k, x + k]$，对应排序后数组的一个连续子数组。因此题目等价于找到最大最小值之差小于等于 $2k$ 的最长连续子数组，该子数组的长度即为数组的最大美丽值。

我们使用滑动窗口的方法来解决，令某连续子数组的右端点为 $i$，左端点为 $j$，初始时都为 $0$，我们依次枚举右端点 $i$：为了使 $\textit{nums}[i] - \textit{nums}[j] \le 2k$，我们不断地右移左端点 $j$ 直到 $\textit{nums}[i] - \textit{nums}[j] \le 2k$ 成立，那么右端点 $i$ 对应的最大最小值之差小于等于 $2k$ 的最长连续子数组的长度为 $i - j + 1$。最后返回这些长度的最大值为数组的最大美丽值。

```C++
class Solution {
public:
    int maximumBeauty(vector<int>& nums, int k) {
        int res = 0, n = nums.size();
        sort(nums.begin(), nums.end());
        for (int i = 0, j = 0; i < n; i++) {
            while (nums[i] - 2 * k > nums[j]) {
                j++;
            }
            res = max(res, i - j + 1);
        }
        return res;
    }
};
```

```Go
func maximumBeauty(nums []int, k int) int {
    res, n := 0, len(nums)
    sort.Ints(nums)
    for i, j := 0, 0; i < n; i++ {
        for nums[i] - 2 * k > nums[j] {
            j++
        }
        res = max(res, i - j + 1)
    }
    return res
}
```

```Java
class Solution {
    public int maximumBeauty(int[] nums, int k) {
        int res = 0, n = nums.length;
        Arrays.sort(nums);
        for (int i = 0, j = 0; i < n; i++) {
            while (nums[i] - 2 * k > nums[j]) {
                j++;
            }
            res = Math.max(res, i - j + 1);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MaximumBeauty(int[] nums, int k) {
        int res = 0, n = nums.Length;
        Array.Sort(nums);
        for (int i = 0, j = 0; i < n; i++) {
            while (nums[i] - 2 * k > nums[j]) {
                j++;
            }
            res = Math.Max(res, i - j + 1);
        }
        return res;
    }
}
```

```Python
class Solution:
    def maximumBeauty(self, nums: List[int], k: int) -> int:
        res, j, n = 0, 0, len(nums)
        nums.sort()
        for i in range(n):
            while nums[i] - 2 * k > nums[j]:
                j += 1
            res = max(res, i - j + 1)
        return res
```

```C
int cmp(const void *x1, const void *x2) {
    return *(const int *)x1 - *(const int *)x2;
}

int maximumBeauty(int* nums, int numsSize, int k){
    int res = 0;
    qsort(nums, numsSize, sizeof(int), cmp);
    for (int i = 0, j = 0; i < numsSize; i++) {
        while (nums[i] - 2 * k > nums[j]) {
            j++;
        }
        res = fmax(res, i - j + 1);
    }
    return res;
}
```

```JavaScript
var maximumBeauty = function(nums, k) {
    let res = 0, n = nums.length;
    nums.sort((x, y) => x - y);
    for (let i = 0, j = 0; i < n; i++) {
        while (nums[i] - 2 * k > nums[j]) {
            j++;
        }
        res = Math.max(res, i - j + 1);
    }
    return res;
};
```

```TypeScript
function maximumBeauty(nums: number[], k: number): number {
    let res = 0, n = nums.length;
    nums.sort((x, y) => x - y);
    for (let i = 0, j = 0; i < n; i++) {
        while (nums[i] - 2 * k > nums[j]) {
            j++;
        }
        res = Math.max(res, i - j + 1);
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn maximum_beauty(nums: Vec<i32>, k: i32) -> i32 {
        let mut nums = nums.clone();
        nums.sort();
        let mut res = 0;
        let mut i = 0;
        let mut j = 0;
        while i < nums.len() {
            while nums[i] - 2 * k > nums[j] {
                j += 1;
            }
            res = std::cmp::max(res, i - j + 1);
            i += 1;
        }
        res as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n)$，其中 $n$ 为数组的长度。排序需要 $O(n \log n)$，滑动窗口需要 $O(n)$。
- 空间复杂度：$O(\log n)$。排序需要 $O(\log n)$ 的栈空间。

#### 方法二：差分数组

对于数组的某一元素 $x$，经过操作后，它可以被替换成区间 $[x - k, x + k]$ 内的任一整数。因此我们可以使用差分数组 $\textit{diff}$ 维护能够被替换成某一整数 $y$ 的数组元素数目。

遍历数组，记当前遍历的元素为 $x$，令 $\textit{diff}[x - k] = \textit{diff}[x - k] + 1$，$\textit{diff}[x + k + 1] = \textit{diff}[x + k + 1] - 1$。遍历结束后，数组 $\textit{nums}$ 经过任意操作后，由相等元素 $y$ 组成的最长子序列的长度为 $\sum^y_{i = 0}\textit{diff}[i]$，即差分数组的区间 $[0, y]$ 前缀和。依次枚举相等元素 $y \in [1, m]$，取对应最长子序列长度的最大值，即为最大美丽值。

> 最大美丽值对应的相等元素必定可以为数组 $\textit{nums}$ 的某一元素，因此我们只需要枚举 $y \in [1, m]$。

```C++
class Solution {
public:
    int maximumBeauty(vector<int>& nums, int k) {
        int m = *max_element(nums.begin(), nums.end());
        vector<int> diff(m + 2);
        for (int x : nums) {
            diff[max(x - k, 0)]++;
            diff[min(x + k + 1, m + 1)]--;
        }
        int res = 0, count = 0;
        for (int x : diff) {
            count += x;
            res = max(res, count);
        }
        return res;
    }
};
```

```Go
func maximumBeauty(nums []int, k int) int {
    m := 0
    for _, x := range nums {
        m = max(m, x)
    }
    diff := make([]int, m + 2)
    for _, x := range nums {
        diff[max(x - k, 0)]++
        diff[min(x + k + 1, m + 1)]--
    }
    res, count := 0, 0
    for _, x := range diff {
        count += x
        res = max(res, count)
    }
    return res
}
```

```Java
class Solution {
    public int maximumBeauty(int[] nums, int k) {
        int m = 0;
        for (int x : nums) {
            m = Math.max(m, x);
        }
        int[] diff = new int[m + 2];
        for (int x : nums) {
            diff[Math.max(x - k, 0)]++;
            diff[Math.min(x + k + 1, m + 1)]--;
        }
        int res = 0, count = 0;
        for (int x : diff) {
            count += x;
            res = Math.max(res, count);
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MaximumBeauty(int[] nums, int k) {
        int m = 0;
        foreach (int x in nums) {
            m = Math.Max(m, x);
        }
        int[] diff = new int[m + 2];
        foreach (int x in nums) {
            diff[Math.Max(x - k, 0)]++;
            diff[Math.Min(x + k + 1, m + 1)]--;
        }
        int res = 0, count = 0;
        foreach (int x in diff) {
            count += x;
            res = Math.Max(res, count);
        }
        return res;
    }
}
```

```Python
class Solution:
    def maximumBeauty(self, nums: List[int], k: int) -> int:
        m = max(nums)
        diff = [0] * (m + 2)
        for x in nums:
            diff[max(x - k, 0)] += 1
            diff[min(x + k + 1, m + 1)] -= 1
        res, count = 0, 0
        for x in diff:
            count += x
            res = max(res, count)
        return res
```

```C
int maximumBeauty(int* nums, int numsSize, int k){
    int m = 0;
    for (int i = 0; i < numsSize; i++) {
        m = fmax(m, nums[i]);
    }
    int diff[m + 2];
    memset(diff, 0, sizeof(diff));
    for (int i = 0; i < numsSize; i++) {
        diff[(int)fmax(nums[i] - k, 0)]++;
        diff[(int)fmin(nums[i] + k + 1, m + 1)]--;
    }
    int res = 0, count = 0;
    for (int i = 0; i < m + 2; i++) {
        count += diff[i];
        res = fmax(res, count);
    }
    return res;
}
```

```JavaScript
var maximumBeauty = function(nums, k) {
    let m = Math.max(...nums);
    let diff = new Array(m + 2).fill(0);
    for (let i = 0; i < nums.length; i++) {
        diff[Math.max(nums[i] - k, 0)]++;
        diff[Math.min(nums[i] + k + 1, m + 1)]--;
    }
    let res = 0, count = 0;
    for (let i = 0; i < diff.length; i++) {
        count += diff[i];
        res = Math.max(res, count);
    }
    return res;
};
```

```TypeScript
function maximumBeauty(nums: number[], k: number): number {
    let m = Math.max(...nums);
    let diff = new Array(m + 2).fill(0);
    for (let i = 0; i < nums.length; i++) {
        diff[Math.max(nums[i] - k, 0)]++;
        diff[Math.min(nums[i] + k + 1, m + 1)]--;
    }
    let res = 0, count = 0;
    for (let i = 0; i < diff.length; i++) {
        count += diff[i];
        res = Math.max(res, count);
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn maximum_beauty(nums: Vec<i32>, k: i32) -> i32 {
        let mut m = nums.iter().max().unwrap();
        let mut diff = vec![0; (m + 2) as usize];
        for x in nums.iter() {
            diff[std::cmp::max(x - k, 0) as usize] += 1;
            diff[std::cmp::min(x + k + 1, m + 1) as usize] -= 1;
        }
        let mut res = 0;
        let mut count = 0;
        for x in diff.iter() {
            count += x;
            res = std::cmp::max(res, count);
        }
        res as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n + m)$，其中 $n$ 是数组 $\textit{nums}$ 的长度，$m$ 是数组 $\textit{nums}$ 的最大值。
- 空间复杂度：$O(m)$。差分数组 $\textit{diff}$ 需要 $O(m)$ 的空间。
