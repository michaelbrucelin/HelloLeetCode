### [半有序排列](https://leetcode.cn/problems/semi-ordered-permutation/solutions/2999667/ban-you-xu-pai-lie-by-leetcode-solution-9s0r/)

#### 方法一：模拟

**思路与算法**

根据题意我们找到 $1$ 在数组中的索引 $first$，$n$ 在数组中的索引 $last$，此时分为两种情况讨论：

- 如果 $first<last$，此时将 $1$ 通过交换相邻元素移到数组的首位需要的交换次数为 $first$，将 $n$ 通过交换相邻元素移到数组的末尾需要的交换次数为 $n-1-last$，总的交换次数即为 $first+n-1-last$；
- 如果 $first>last$，此时将 $1$ 通过交换相邻元素移到数组的首位需要的交换次数为 $first$，将 $n$ 通过交换相邻元素移到数组的末尾需要的交换次数为 $n-1-first$，由于 $first>last$，实际交换过程时 $1$ 与 $n$ 会同时交换 $1$ 次，因此会减少 $1$ 次交换，总的交换次数即为 $first+n-1-last-1$。

**代码**

```C++
class Solution {
public:
    int semiOrderedPermutation(vector<int>& nums) {
        auto [first, last] = minmax_element(nums.begin(), nums.end());
        return first + nums.size() - 1 - last - (last < first);
    }
};
```

```Java
class Solution {
    public int semiOrderedPermutation(int[] nums) {
        int n = nums.length;
        int first = 0, last = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 1) {
                first = i;
            }
            if (nums[i] == n) {
                last = i;
            }
        }
        return first + n - 1 - last - (last < first ? 1 : 0);
    }
}
```

```CSharp
public class Solution {
    public int SemiOrderedPermutation(int[] nums) {
        int n = nums.Length;
        int first = 0, last = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] == 1) {
                first = i;
            }
            if (nums[i] == n) {
                last = i;
            }
        }
        return first + n - 1 - last - (last < first ? 1 : 0);
    }
}
```

```Go
func semiOrderedPermutation(nums []int) int {
    n := len(nums)
    first, last := 0, 0
    for i := 0; i < n; i++ {
        if nums[i] == 1 {
            first = i
        }
        if nums[i] == n {
            last = i
        }
    }
    if last < first {
        return first + n - 1 - last - 1
    }
    return first + n - 1 - last
}
```

```Python
class Solution:
    def semiOrderedPermutation(self, nums: List[int]) -> int:
        n = len(nums)
        first = nums.index(1)
        last = nums.index(n)
        return first + n - 1 - last - (first > last)
```

```C
int semiOrderedPermutation(int* nums, int numsSize) {
    int first = 0, last = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] == 1) {
            first = i;
        }
        if (nums[i] == numsSize) {
            last = i;
        }
    }
    return first + numsSize - 1 - last - (last < first ? 1 : 0);
}
```

```JavaScript
var semiOrderedPermutation = function(nums) {
    const n = nums.length;
    let first = 0, last = 0;
    for (let i = 0; i < n; i++) {
        if (nums[i] === 1) {
            first = i;
        }
        if (nums[i] === n) {
            last = i;
        }
    }
    return first + n - 1 - last - (last < first ? 1 : 0);
};
```

```TypeScript
function semiOrderedPermutation(nums: number[]): number {
    const n = nums.length;
    let first = 0, last = 0;
    for (let i = 0; i < n; i++) {
        if (nums[i] === 1) {
            first = i;
        }
        if (nums[i] === n) {
            last = i;
        }
    }
    return first + n - 1 - last - (last < first ? 1 : 0);
};
```

```Rust
impl Solution {
    pub fn semi_ordered_permutation(nums: Vec<i32>) -> i32 {
        let n = nums.len() as i32;
        let mut first = 0;
        let mut last = 0;
        for (i, &num) in nums.iter().enumerate() {
            if num == 1 {
                first = i as i32;
            }
            if num == n {
                last = i as i32;
            }
        }
        first + n - 1 - last - if last < first { 1 } else { 0 }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定数组的长度。遍历数组找到 $1$ 与 $n$ 的索引需要的时间为 $O(n)$。
- 空间复杂度：$O(1)$。
