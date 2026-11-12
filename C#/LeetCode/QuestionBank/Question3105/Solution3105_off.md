### [最长的严格递增或递减子数组](https://leetcode.cn/problems/longest-strictly-increasing-or-strictly-decreasing-subarray/solutions/4052110/zui-chang-de-yan-ge-di-zeng-huo-di-jian-2iogk/)

#### 方法一：朴素模拟

**思路与算法**

我们可以分开求严格递增和严格递减的最长非空子数组的长度，用 $cnt_1$ 来表示严格递增的子数组的长度，用 $cnt_2$ 来表示严格递减的子数组的长度。

以下是求严格递增的最长非空子数组的方法：

从原数组的第二个元素开始遍历，对于每一个元素，如果这个元素严格大于上一个元素，那么令 $cnt_1+1$，否则更新答案并将 $cnt_1$ 更新为 $1$，表示新的子数组从当前这个元素开始。

严格递减的最长非空子数组也可以用类似的方法来求得：

从原数组的第二个元素开始遍历，对于每一个元素，如果这个元素严格小于上一个元素，那么令 $cnt_2+1$，否则更新答案并将 $cnt_2$ 更新为 $1$，表示新的子数组从当前这个元素开始。

**代码**

```C++
class Solution {
public:
    int longestMonotonicSubarray(vector<int>& nums) {
        int cnt1 = 1, cnt2 = 1;
        int ans = 1;
        int n = nums.size();
        for (int i = 1; i < n; i++) {
            if (nums[i] <= nums[i - 1]) {
                ans = max(ans, cnt1);
                cnt1 = 1;
            } else {
                cnt1++;
            }
            if (nums[i] >= nums[i - 1]) {
                ans = max(ans, cnt2);
                cnt2 = 1;
            } else {
                cnt2++;
            }
        }
        ans = max(ans, max(cnt1, cnt2));
        return ans;
    }
};
```

```Java
class Solution {
    public int longestMonotonicSubarray(int[] nums) {
        int cnt1 = 1, cnt2 = 1;
        int ans = 1;
        int n = nums.length;
        for (int i = 1; i < n; i++) {
            if (nums[i] <= nums[i - 1]) {
                ans = Math.max(ans, cnt1);
                cnt1 = 1;
            } else {
                cnt1++;
            }
            if (nums[i] >= nums[i - 1]) {
                ans = Math.max(ans, cnt2);
                cnt2 = 1;
            } else {
                cnt2++;
            }
        }
        ans = Math.max(ans, Math.max(cnt1, cnt2));
        return ans;
    }
}
```

```Python
class Solution:
    def longestMonotonicSubarray(self, nums: List[int]) -> int:
        cnt1, cnt2 = 1, 1
        ans = 1
        n = len(nums)
        for i in range(1, n):
            if nums[i] <= nums[i - 1]:
                ans = max(ans, cnt1)
                cnt1 = 1
            else:
                cnt1 += 1
            if nums[i] >= nums[i - 1]:
                ans = max(ans, cnt2)
                cnt2 = 1
            else:
                cnt2 += 1
        ans = max(ans, max(cnt1, cnt2))
        return ans
```

```CSharp
public class Solution {
    public int LongestMonotonicSubarray(int[] nums) {
        int cnt1 = 1, cnt2 = 1;
        int ans = 1;
        int n = nums.Length;
        for (int i = 1; i < n; i++) {
            if (nums[i] <= nums[i - 1]) {
                ans = Math.Max(ans, cnt1);
                cnt1 = 1;
            } else {
                cnt1++;
            }
            if (nums[i] >= nums[i - 1]) {
                ans = Math.Max(ans, cnt2);
                cnt2 = 1;
            } else {
                cnt2++;
            }
        }
        ans = Math.Max(ans, Math.Max(cnt1, cnt2));
        return ans;
    }
}
```

```JavaScript
var longestMonotonicSubarray = function(nums) {
    let cnt1 = 1, cnt2 = 1;
    let ans = 1;
    const n = nums.length;
    for (let i = 1; i < n; i++) {
        if (nums[i] <= nums[i - 1]) {
            ans = Math.max(ans, cnt1);
            cnt1 = 1;
        } else {
            cnt1++;
        }
        if (nums[i] >= nums[i - 1]) {
            ans = Math.max(ans, cnt2);
            cnt2 = 1;
        } else {
            cnt2++;
        }
    }
    ans = Math.max(ans, Math.max(cnt1, cnt2));
    return ans;
};
```

```TypeScript
function longestMonotonicSubarray(nums: number[]): number {
    let cnt1 = 1, cnt2 = 1;
    let ans = 1;
    const n = nums.length;
    for (let i = 1; i < n; i++) {
        if (nums[i] <= nums[i - 1]) {
            ans = Math.max(ans, cnt1);
            cnt1 = 1;
        } else {
            cnt1++;
        }
        if (nums[i] >= nums[i - 1]) {
            ans = Math.max(ans, cnt2);
            cnt2 = 1;
        } else {
            cnt2++;
        }
    }
    ans = Math.max(ans, Math.max(cnt1, cnt2));
    return ans;
}
```

```Go
func longestMonotonicSubarray(nums []int) int {
    cnt1, cnt2 := 1, 1
    ans := 1
    n := len(nums)
    for i := 1; i < n; i++ {
        if nums[i] <= nums[i - 1] {
            ans = max(ans, cnt1)
            cnt1 = 1
        } else {
            cnt1++
        }
        if nums[i] >= nums[i - 1] {
            ans = max(ans, cnt2)
            cnt2 = 1
        } else {
            cnt2++
        }
    }
    ans = max(ans, max(cnt1, cnt2))
    return ans
}
```

```C
int longestMonotonicSubarray(int* nums, int numsSize) {
    int cnt1 = 1, cnt2 = 1;
    int ans = 1;
    int n = numsSize;
    for (int i = 1; i < n; i++) {
        if (nums[i] <= nums[i - 1]) {
            ans = fmax(ans, cnt1);
            cnt1 = 1;
        } else {
            cnt1++;
        }
        if (nums[i] >= nums[i - 1]) {
            ans = fmax(ans, cnt2);
            cnt2 = 1;
        } else {
            cnt2++;
        }
    }
    ans = fmax(ans, fmax(cnt1, cnt2));
    return ans;
}
```

```Rust
impl Solution {
    pub fn longest_monotonic_subarray(nums: Vec<i32>) -> i32 {
        let mut cnt1 = 1;
        let mut cnt2 = 1;
        let mut ans = 1;
        let n = nums.len();
        for i in 1..n {
            if nums[i] <= nums[i - 1] {
                ans = ans.max(cnt1);
                cnt1 = 1;
            } else {
                cnt1 += 1;
            }
            if nums[i] >= nums[i - 1] {
                ans = ans.max(cnt2);
                cnt2 = 1;
            } else {
                cnt2 += 1;
            }
        }
        ans = ans.max(cnt1.max(cnt2));
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(1)$，只用到了常数个变量。

#### 方法二：基调标志 $+$ 模拟

**思路与算法**

我们可以按单调方向分段扫描数组，用布尔变量 $inc$ 记录当前子数组是严格递增还是严格递减。初始化时，令答案 $ans=1$，扫描位置 $i=0$。

如果 $nums[i+1]=nums[i]$，由于在严格单调的子数组中，这两个元素不能同时出现，故继续递增 $i$ 寻找起点。否则，令 $j=i$ 为当前子数组的起点，并根据 $nums[i+1]>nums[i]$ 确定 $inc$：为真表示严格递增，为假表示严格递减。因为前两个元素已经具有单调性，此时令 $i=i+2$，从第三个元素开始向右扩展。

在满足 $i<n$ 的前提下，若相邻元素 $nums[i]$ 和 $nums[i-1]$ 的单调性 $inc$ 表述的一致，就持续递增 $i$。循环结束时，子数组 $nums[j\dots i-1]$ 严格单调，长度为 $i-j$，据此更新答案 $ans$。

随后将 $i$ 减一，让当前子数组的最后一个元素作为下一次扫描的候选起点。这是因为单调方向改变时，相邻的两个子数组可以共享转折处的元素。例如，$[1,3,2]$ 中的 $3$ 同时属于递增段 $[1,3]$ 和递减段 $[3,2]$，不能跳过。扫描结束后，返回 $ans$。

**代码**

```C++
class Solution {
public:
    int longestMonotonicSubarray(vector<int> &nums) {
        int ans = 1;
        int i = 0;
        int n = nums.size();
        while (i < n - 1) {
            if (nums[i + 1] == nums[i]) {
                i++;
                continue;
            }
            int j = i;
            bool inc = nums[i + 1] > nums[i];
            i += 2;
            while (i < n && nums[i] != nums[i - 1] && (nums[i] > nums[i - 1]) == inc) {
                i++;
            }
            ans = max(ans, i - j);
            i--;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int longestMonotonicSubarray(int[] nums) {
        int ans = 1;
        int i = 0;
        int n = nums.length;
        while (i < n - 1) {
            if (nums[i + 1] == nums[i]) {
                i++;
                continue;
            }
            int j = i;
            boolean inc = nums[i + 1] > nums[i];
            i += 2;
            while (i < n && nums[i] != nums[i - 1] && (nums[i] > nums[i - 1]) == inc) {
                i++;
            }
            ans = Math.max(ans, i - j);
            i--;
        }
        return ans;
    }
}
```

```Python
class Solution:
    def longestMonotonicSubarray(self, nums: List[int]) -> int:
        ans = 1
        i = 0
        n = len(nums)
        while i < n - 1:
            if nums[i + 1] == nums[i]:
                i += 1
                continue
            j = i
            inc = nums[i + 1] > nums[i]
            i += 2
            while i < n and nums[i] != nums[i - 1] and (nums[i] > nums[i - 1]) == inc:
                i += 1
            ans = max(ans, i - j)
            i -= 1
        return ans
```

```CSharp
public class Solution {
    public int LongestMonotonicSubarray(int[] nums) {
        int ans = 1;
        int i = 0;
        int n = nums.Length;
        while (i < n - 1) {
            if (nums[i + 1] == nums[i]) {
                i++;
                continue;
            }
            int j = i;
            bool inc = nums[i + 1] > nums[i];
            i += 2;
            while (i < n && nums[i] != nums[i - 1] && (nums[i] > nums[i - 1]) == inc) {
                i++;
            }
            ans = Math.Max(ans, i - j);
            i--;
        }
        return ans;
    }
}
```

```JavaScript
var longestMonotonicSubarray = function(nums) {
    let ans = 1;
    let i = 0;
    const n = nums.length;
    while (i < n - 1) {
        if (nums[i + 1] === nums[i]) {
            i++;
            continue;
        }
        const j = i;
        const inc = nums[i + 1] > nums[i];
        i += 2;
        while (i < n && nums[i] !== nums[i - 1] && (nums[i] > nums[i - 1]) === inc) {
            i++;
        }
        ans = Math.max(ans, i - j);
        i--;
    }
    return ans;
};
```

```TypeScript
function longestMonotonicSubarray(nums: number[]): number {
    let ans = 1;
    let i = 0;
    const n = nums.length;
    while (i < n - 1) {
        if (nums[i + 1] === nums[i]) {
            i++;
            continue;
        }
        const j = i;
        const inc = nums[i + 1] > nums[i];
        i += 2;
        while (i < n && nums[i] !== nums[i - 1] && (nums[i] > nums[i - 1]) === inc) {
            i++;
        }
        ans = Math.max(ans, i - j);
        i--;
    }
    return ans;
}
```

```Go
func longestMonotonicSubarray(nums []int) int {
    ans := 1
    i := 0
    n := len(nums)
    for i < n - 1 {
        if nums[i + 1] == nums[i] {
            i++
            continue
        }
        j := i
        inc := nums[i + 1] > nums[i]
        i += 2
        for i < n && nums[i] != nums[i - 1] && (nums[i] > nums[i - 1]) == inc {
            i++
        }
        ans = max(ans, i - j)
        i--
    }
    return ans
}
```

```C
int longestMonotonicSubarray(int* nums, int numsSize) {
    int ans = 1;
    int i = 0;
    int n = numsSize;
    while (i < n - 1) {
        if (nums[i + 1] == nums[i]) {
            i++;
            continue;
        }
        int j = i;
        bool inc = nums[i + 1] > nums[i];
        i += 2;
        while (i < n && nums[i] != nums[i - 1] && (nums[i] > nums[i - 1]) == inc) {
            i++;
        }
        ans = fmax(ans, i - j);
        i--;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn longest_monotonic_subarray(nums: Vec<i32>) -> i32 {
        let mut ans = 1;
        let mut i = 0;
        let n = nums.len();
        while i < n - 1 {
            if nums[i + 1] == nums[i] {
                i += 1;
                continue;
            }
            let j = i;
            let inc = nums[i + 1] > nums[i];
            i += 2;
            while i < n && nums[i] != nums[i - 1] && (nums[i] > nums[i - 1]) == inc {
                i += 1;
            }
            ans = ans.max(i - j);
            i -= 1;
        }
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(1)$，只用到了常数个变量。
