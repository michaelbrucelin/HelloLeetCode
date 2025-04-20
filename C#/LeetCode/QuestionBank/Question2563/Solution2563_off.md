### [统计公平数对的数目](https://leetcode.cn/problems/count-the-number-of-fair-pairs/solutions/3645253/tong-ji-gong-ping-shu-dui-de-shu-mu-by-l-hbgf/)

#### 方法一：二分查找

**思路与算法**

题目要求我们找到两个数 $nums[i]$ 和 $nums[j]$，满足

$$lower \le nums[i]+nums[j] \le upper$$

可以发现排序并不会影响最后的计数结果，因此我们可以先进行排序。对于每一个 $nums[j]$，可以使用二分查找找到一个区间 $[l,r]$，使得所有的 $i \in [l,r]$ 满足

$$lower-nums[j] \le nums[i] \le upper-nums[j]$$

具体来说，我们可以找到 $\le upper-nums[j]$ 的元素个数，减去 $< lower-nums[j]$ 的元素个数，加入答案。

**代码**

```C++
class Solution {
public:
    long long countFairPairs(vector<int>& nums, int lower, int upper) {
        sort(nums.begin(), nums.end());
        long long ans = 0;
        for (int j = 0; j < nums.size(); ++j) {
            auto r =
                upper_bound(nums.begin(), nums.begin() + j, upper - nums[j]);
            auto l =
                lower_bound(nums.begin(), nums.begin() + j, lower - nums[j]);
            ans += r - l;
        }
        return ans;
    }
};
```

```C
int compare(const void* a, const void* b) { return (*(int*)a - *(int*)b); }

int lower_bound(int* arr, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] < target){
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

long long countFairPairs(int* nums, int numsSize, int lower, int upper) {
    qsort(nums, numsSize, sizeof(int), compare);
    long long ans = 0;

    for (int j = 0; j < numsSize; ++j) {
        int r = lower_bound(nums, j, upper - nums[j] + 1);
        int l = lower_bound(nums, j, lower - nums[j]);
        ans += (r - l);
    }

    return ans;
}
```

```Java
class Solution {
    public long countFairPairs(int[] nums, int lower, int upper) {
        Arrays.sort(nums);
        long ans = 0;
        for (int j = 0; j < nums.length; j++) {
            int r = lowerBound(nums, j, upper - nums[j] + 1);
            int l = lowerBound(nums, j, lower - nums[j]);
            ans += r - l;
        }
        return ans;
    }

    private int lowerBound(int[] nums, int right, int target) {
        int left = -1;
        while (left + 1 < right) {
            int mid = (left + right) >>> 1;
            if (nums[mid] < target) {
                left = mid;
            } else {
                right = mid;
            }
        }
        return right;
    }
}
```

```Python
class Solution:
    def countFairPairs(self, nums: List[int], lower: int, upper: int) -> int:
        nums.sort()
        ans = 0
        for j, x in enumerate(nums):
            r = bisect_right(nums, upper - x, 0, j)
            l = bisect_left(nums, lower - x, 0, j)
            ans += r - l
        return ans
```

```Go
func countFairPairs(nums []int, lower, upper int) (ans int64) {
    slices.Sort(nums)
    for j, x := range nums {
        r := sort.SearchInts(nums[:j], upper-x+1)
        l := sort.SearchInts(nums[:j], lower-x)
        ans += int64(r - l)
    }
    return
}
```

```CSharp
public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums); 
        long ans = 0;

        for (int j = 0; j < nums.Length; j++) {
            int r = LowerBound(nums, j, upper - nums[j] + 1);
            int l = LowerBound(nums, j, lower - nums[j]);
            ans += r - l;
        }

        return ans;
    }

    private int LowerBound(int[] nums, int right, int target) {
        int left = -1;
        while (left + 1 < right) {
            int mid = (left + right) >> 1;
            if (nums[mid] < target) {
                left = mid;
            } else {
                right = mid;
            }
        }
        return right;
    }
}
```

```Rust
impl Solution {
    pub fn count_fair_pairs(mut nums: Vec<i32>, lower: i32, upper: i32) -> i64 {
        nums.sort();
        let mut ans = 0;
        for i in 0..nums.len() {
            let l = nums[0..i].partition_point(|num| * num + nums[i] < lower);
            let r = nums[0..i].partition_point(|num| * num + nums[i] <= upper );
            ans += r - l
        }
        ans as i64
    }
}
```

```JavaScript
var countFairPairs = function(nums, lower, upper) {
    nums.sort((a, b) => a - b);
    let ans = 0;

    for (let j = 0; j < nums.length; j++) {
        let r = lowerBound(nums, 0, j, upper - nums[j] + 1);
        let l = lowerBound(nums, 0, j, lower - nums[j]);
        ans += r - l;
    }

    return ans;
};

function lowerBound(nums, left, right, target) {
    while (left < right) {
        let mid = Math.floor((left + right) / 2);
        if (nums[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}
```

```TypeScript
function countFairPairs(nums: number[], lower: number, upper: number): number {
    nums.sort((a, b) => a - b);
    let ans = 0;

    for (let j = 0; j < nums.length; j++) {
        let r = lowerBound(nums, 0, j, upper - nums[j] + 1);
        let l = lowerBound(nums, 0, j, lower - nums[j]);
        ans += r - l;
    }

    return ans;
};

function lowerBound(nums: number[], left: number, right: number, target: number) {
    while (left < right) {
        let mid = Math.floor((left + right) / 2);
        if (nums[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n)$，其中 $n$ 为 $nums$ 的长度。排序操作需要 $O(n \log n)$，每次二分查找需要 O( \log n)。
- 空间复杂度：$O(1)$，仅需要若干额外变量。

#### 方法二：三指针

**思路与算法**

在给数组 $nums$ 排序后，随着枚举的 $nums[j]$ 变大，$upper-nums[j]$ 和 $lower-nums[j]$ 都变小，于是我们可以用三指针来代替二分查找的搜索过程。

具体来说，使用两个指针 $left$ 和 $right$ 分别表示 $\le upper-nums[j]$ 的最大元素位置，和 $< lower-nums[j]$ 的最大元素位置，那么满足条件的 $nums[i]$ 就被夹在三个指针当中，作差从而得到答案的数量。

**代码**

```C++
class Solution {
public:
    long long countFairPairs(vector<int>& nums, int lower, int upper) {
        sort(nums.begin(), nums.end());
        long long ans = 0;
        int left = nums.size(), right = nums.size();
        for (int j = 0; j < nums.size(); ++j) {
            while (right && nums[right - 1] > upper - nums[j]) {
                right--;
            }
            while (left && nums[left - 1] >= lower - nums[j]) {
                left--;
            }
            ans += min(right, j) - min(left, j);
        }
        return ans;
    }
};
```

```C
int cmp(const void* a, const void* b) { return (*(int*)a - *(int*)b); }

long long countFairPairs(int* nums, int numsSize, int lower, int upper) {
    qsort(nums, numsSize, sizeof(int), cmp);
    long long ans = 0;
    int left = numsSize, right = numsSize;
    for (int j = 0; j < numsSize; ++j) {
        while (right && nums[right - 1] > upper - nums[j]) {
            right--;
        }
        while (left && nums[left - 1] >= lower - nums[j]) {
            left--;
        }
        ans += fmin(right, j) - fmin(left, j);
    }
    return ans;
}
```

```Java
class Solution {
    public long countFairPairs(int[] nums, int lower, int upper) {
        Arrays.sort(nums);
        long ans = 0;
        int left = nums.length, right = nums.length;
        for (int j = 0; j < nums.length; ++j) {
            while (right > 0 && nums[right - 1] > upper - nums[j]) {
                right--;
            }
            while (left > 0 && nums[left - 1] >= lower - nums[j]) {
                left--;
            }
            ans += Math.min(right, j) - Math.min(left, j);
        }
        return ans;
    }
}
```

```Python
class Solution:
    def countFairPairs(self, nums: List[int], lower: int, upper: int) -> int:
        nums.sort()
        ans = 0
        left = right = len(nums)
        for j, x in enumerate(nums):
            while right and nums[right - 1] > upper - x:
                right -= 1
            while left and nums[left - 1] >= lower - x:
                left -= 1
            ans += min(right, j) - min(left, j)
        return ans
```

```Go
func countFairPairs(nums []int, lower, upper int) (ans int64) {
    slices.Sort(nums)
    left, right := len(nums), len(nums)
    for j, x := range nums {
        for right > 0 && nums[right-1] > upper-x {
            right--
        }
        for left > 0 && nums[left-1] >= lower-x {
            left--
        }
        ans += int64(min(right, j) - min(left, j))
    }
    return
}
```

```CSharp
public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums);
        long ans = 0;
        int left = nums.Length, right = nums.Length;
        
        for (int j = 0; j < nums.Length; ++j) {
            while (right > 0 && nums[right - 1] > upper - nums[j]) {
                right--;
            }
            while (left > 0 && nums[left - 1] >= lower - nums[j]) {
                left--;
            }
            ans += Math.Min(right, j) - Math.Min(left, j);
        }
        
        return ans;
    }
}
```

```Rust
impl Solution {
    pub fn count_fair_pairs(mut nums: Vec<i32>, lower: i32, upper: i32) -> i64 {
        nums.sort();
        let mut ans = 0;
        let (mut left, mut right) = (nums.len(), nums.len());

        for (j, &num) in nums.iter().enumerate() {
            while right > 0 && nums[right - 1] > upper - num {
                right -= 1;
            }
            while left > 0 && nums[left - 1] >= lower - num {
                left -= 1;
            }
            ans += (right.min(j) as i64) - (left.min(j) as i64);
        }
        
        ans
    }
}
```

```JavaScript
var countFairPairs = function(nums, lower, upper) {
    nums.sort((a, b) => a - b);
    let ans = 0;
    let left = nums.length, right = nums.length;

    for (let j = 0; j < nums.length; j++) {
        while (right > 0 && nums[right - 1] > upper - nums[j]) {
            right--;
        }
        while (left > 0 && nums[left - 1] >= lower - nums[j]) {
            left--;
        }
        ans += Math.min(right, j) - Math.min(left, j);
    }

    return ans;
};
```

```TypeScript
function countFairPairs(nums: number[], lower: number, upper: number): number {
    nums.sort((a, b) => a - b);
    let ans = 0;
    let left = nums.length, right = nums.length;

    for (let j = 0; j < nums.length; j++) {
        while (right > 0 && nums[right - 1] > upper - nums[j]) {
            right--;
        }
        while (left > 0 && nums[left - 1] >= lower - nums[j]) {
            left--;
        }
        ans += Math.min(right, j) - Math.min(left, j);
    }

    return ans;
};
```

**复杂度分析**

- 时间复杂度：$O(n \log n)$，其中 $n$ 为 $nums$ 的长度。排序操作需要 $O(n \log n)$，搜索使用的三指针总共需要 $O(n)$。
- 空间复杂度：$O(1)$，仅需要若干额外变量。
