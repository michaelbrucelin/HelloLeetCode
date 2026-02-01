### [将数组分成最小总代价的子数组 I](https://leetcode.cn/problems/divide-an-array-into-subarrays-with-minimum-cost-i/solutions/3891856/jiang-shu-zu-fen-cheng-zui-xiao-zong-dai-55sz/)

#### 方法一：排序

**思路与算法**

根据题意可知一个数组的**代价**是它的**第一个元素**。需要将给定数组 $nums$ 分成 $3$ 个**连续且没有交集**的子数组，题目要求返回这 $3$ 子数组的**最小**代价和。
根据题意可知，第一个子数组的**代价**已确定为 $nums[0]$。如果确定了第二个子数组的第一个数的位置和第三个子数组的第一个数的位置，此时子数组的划分方案也就确定。我们可以任意选择两个索引 $(i,j)$ 作为第二个子数组的起始位置和第三个子数组的起始位置，且满足 $1\le i<j\le n-1$，其中 $n$ 表示给定数组 $nums$ 的长度。此时，第二个子数组的**代价**为 $nums[i]$，第三个子数组的**代价**为 $nums[j]$。为保证代价和最小，此时可以在 $[1,n-1]$ 中的选择值最小的两个下标即可，可将子数组 $nums[1\dots n-1]$ 按照从小到大排序，取最小的两个元素即可。

**代码**

```C++
class Solution {
public:
    int minimumCost(vector<int>& nums) {
        sort(nums.begin() + 1, nums.end());
        return reduce(nums.begin(), nums.begin() + 3, 0);
    }
};
```

```Java
class Solution {
    public int minimumCost(int[] nums) {
        Arrays.sort(nums, 1, nums.length);
        return nums[0] + nums[1] + nums[2];
    }
}
```

```CSharp
public class Solution {
    public int MinimumCost(int[] nums) {
        Array.Sort(nums, 1, nums.Length - 1);
        return nums.Take(3).Sum();
    }
}
```

```Go
func minimumCost(nums []int) int {
    sort.Ints(nums[1:])
    return nums[0] + nums[1] + nums[2]
}
```

```Python
class Solution:
    def minimumCost(self, nums: List[int]) -> int:
        nums[1:] = sorted(nums[1:])
        return sum(nums[:3])
```

```C
int cmp(const void *a, const void *b) {
    return (*(int *)a) - (*(int *)b);
}

int minimumCost(int *nums, int numsSize) {
    qsort(nums + 1, numsSize - 1, sizeof(int), cmp);
    return nums[0] + nums[1] + nums[2];
}
```

```JavaScript
var minimumCost = function(nums) {
    nums = [nums[0], ...nums.slice(1).sort((a, b) => a - b)];
    return nums.slice(0, 3).reduce((sum, num) => sum + num, 0);
};
```

```TypeScript
function minimumCost(nums: number[]): number {
    nums = [nums[0], ...nums.slice(1).sort((a, b) => a - b)];
    return nums.slice(0, 3).reduce((sum, num) => sum + num, 0);
};
```

```Rust
impl Solution {
    pub fn minimum_cost(mut nums: Vec<i32>) -> i32 {
        if nums.len() > 1 {
            let (first, rest) = nums.split_at_mut(1);
            rest.sort();
        }
        nums.iter().take(3).sum()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 表示给定数组 $nums$ 的长度。排序需要 $O(n\log n)$ 的时间。
- 空间复杂度：$O(\log n)$。排序需要 $O(\log n)$ 的栈空间。

#### 方法二：维护最小值和次小值

**思路与算法**

根据方法一可知，我们需要找到下标在 $[1,n-1]$ 中的两个最小元素，此时可以在遍历数组的过程中维护最小值 $first$ 和次小值 $second$，最终答案即为 $nums[0]+first+second$。

**代码**

```C
class Solution {
public:
    int minimumCost(vector<int> &nums) {
        int first = INT_MAX, second = INT_MAX;
        for (int i = 1; i < nums.size(); i++) {
            int x = nums[i];
            if (x < first) {
                second = first;
                first = x;
            } else if (x < second) {
                second = x;
            }
        }
        return nums[0] + first + second;
    }
};
```

```Java
class Solution {
    public int minimumCost(int[] nums) {
        int first = Integer.MAX_VALUE;
        int second = Integer.MAX_VALUE;

        for (int i = 1; i < nums.length; i++) {
            int x = nums[i];
            if (x < first) {
                second = first;
                first = x;
            } else if (x < second) {
                second = x;
            }
        }
        return nums[0] + first + second;
    }
}
```

```CSharp
public class Solution {
    public int MinimumCost(int[] nums) {
        int first = int.MaxValue;
        int second = int.MaxValue;

        for (int i = 1; i < nums.Length; i++) {
            int x = nums[i];
            if (x < first) {
                second = first;
                first = x;
            } else if (x < second) {
                second = x;
            }
        }
        return nums[0] + first + second;
    }
}
```

```Go
func minimumCost(nums []int) int {
    first := int(^uint(0) >> 1)
    second := int(^uint(0) >> 1)

    for i := 1; i < len(nums); i++ {
        x := nums[i]
        if x < first {
            second = first
            first = x
        } else if x < second {
            second = x
        }
    }
    return nums[0] + first + second
}
```

```Python
class Solution:
    def minimumCost(self, nums: List[int]) -> int:
        return nums[0] + sum(nsmallest(2, nums[1:]))
```

```C
int minimumCost(int* nums, int numsSize) {
    int first = INT_MAX;
    int second = INT_MAX;

    for (int i = 1; i < numsSize; i++) {
        int x = nums[i];
        if (x < first) {
            second = first;
            first = x;
        } else if (x < second) {
            second = x;
        }
    }
    return nums[0] + first + second;
}
```

```JavaScript
var minimumCost = function(nums) {
    let first = Number.MAX_SAFE_INTEGER;
    let second = Number.MAX_SAFE_INTEGER;

    for (let i = 1; i < nums.length; i++) {
        const x = nums[i];
        if (x < first) {
            second = first;
            first = x;
        } else if (x < second) {
            second = x;
        }
    }
    return nums[0] + first + second;
};
```

```TypeScript
function minimumCost(nums: number[]): number {
    let first: number = Number.MAX_SAFE_INTEGER;
    let second: number = Number.MAX_SAFE_INTEGER;

    for (let i = 1; i < nums.length; i++) {
        const x: number = nums[i];
        if (x < first) {
            second = first;
            first = x;
        } else if (x < second) {
            second = x;
        }
    }
    return nums[0] + first + second;
};
```

```Rust
impl Solution {
    pub fn minimum_cost(nums: Vec<i32>) -> i32 {
        let mut first = i32::MAX;
        let mut second = i32::MAX;

        for i in 1..nums.len() {
            let x = nums[i];
            if x < first {
                second = first;
                first = x;
            } else if x < second {
                second = x;
            }
        }
        nums[0] + first + second
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
