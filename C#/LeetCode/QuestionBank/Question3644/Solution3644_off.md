### [排序排列](https://leetcode.cn/problems/maximum-k-to-sort-a-permutation/solutions/4043251/pai-xu-pai-lie-by-leetcode-solution-ogs1/)

#### 方法一：遍历按位与

**思路与算法**

题目要求找到一个最大的非负整数 $k$，使得可以通过任意次交换满足 $nums[i]\&nums[j]=k$ 的元素对，将排列排成非递减顺序。

首先考虑一个关键性质：如果两个数 $a$ 和 $b$ 满足 $a\&b=k$，那么 $k$ 的每个二进制位在 $a$ 和 $b$ 中都必须为 $1$。换句话说，$k$ 的二进制表示必须是 $a$ 和 $b$ 的二进制表示的公共子集，即 $a\&k=k$ 且 $b\&k=k$。

对于排列 $nums$，我们最终需要将其变为 $[0,1,2,\dots ,n-1]$。对于已经在正确位置的元素（即 $nums[i]=i$），它们不需要参与任何交换。对于所有不在正确位置的元素，它们必须通过交换到达正确的位置。

对于任意要参与交换的元素 $nums[i]$（满足 $nums[i]\ne i$），由于它需要通过满足 $nums[i]\&nums[j]=k$ 的交换来移动，因此必须有 $nums[i]\&k=k$。这意味着 $k$ 的每一个 $1$ 位都必须同时出现在所有需要移动的元素中。

因此，最大的 $k$ 就是所有不在正确位置的元素的按位与结果：

$$k=\mathop{\bigwedge}\limits_{nums[i]\ne i} nums[i]$$

特别地，如果数组已经有序，则不存在需要移动的元素，此时返回 $0$。
下面证明这个 $k$ 总是可行的。记 $k^{*} =\mathop{\wedge}\limits_{nums[i]\ne i} nums[i]$。由于按位与只保留参与运算各数的公共二进制位，$k^{*}$ 的每一个二进制位都出现在所有错位元素中，即对任意错位元素 $x$ 都有 $k^{*}\&x=k^{*}$。

另一方面，$nums$ 是 $[0,n-1]$ 的一个排列且 $k^{*}\le n-1$，因此值 $k^{*}$ 一定出现在数组中。将值为 $k^{*}$ 的元素称为「中继」，它与任意错位元素的按位与都等于 $k^{*}$，所以中继可以与任意错位元素直接交换。借助中继，任意两个错位元素 a、b 可以通过三次交换互换位置：先交换中继与 $a$，再交换中继与 $b$，最后再交换中继与 $a$。每一步交换都满足条件，且三次交换后中继恰好回到原位，而 a、b 完成互换（若中继本身就是错位元素，把它当作普通元素参与同一论证即可）。因此任意两个错位元素都可以互换位置。反复进行这样的交换（例如每次选择仍未归位的最小位置，将属于该位置的元素交换过去），就能把排列逐步整理为 $[0,1,\dots ,n-1]$，故 $k^{*}$ 可行。结合上界分析，$k^{*}$ 即为最大的可行 $k$。

**代码**

```C++
class Solution {
public:
    int sortPermutation(vector<int>& nums) {
        int n = nums.size();
        int res = INT_MAX;
        for (int i = 0; i < n; i++) {
            if (nums[i] == i) {
                continue;
            }
            res &= nums[i];
        }
        return res == INT_MAX ? 0 : res;
    }
};
```

```Go
func sortPermutation(nums []int) int {
    n := len(nums)
    res := math.MaxInt32
    for i := 0; i < n; i++ {
        if nums[i] == i {
            continue
        }
        res &= nums[i]
    }
    if res == math.MaxInt32 {
        return 0
    }
    return res
}
```

```Python
class Solution:
    def sortPermutation(self, nums: List[int]) -> int:
        n = len(nums)
        res = -1
        for i in range(n):
            if nums[i] == i:
                continue
            res &= nums[i]
        return 0 if res == -1 else res
```

```Java
class Solution {
    public int sortPermutation(int[] nums) {
        int n = nums.length;
        int res = Integer.MAX_VALUE;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == i) {
                continue;
            }
            res &= nums[i];
        }
        return res == Integer.MAX_VALUE ? 0 : res;
    }
}
```

```TypeScript
function sortPermutation(nums: number[]): number {
    const n = nums.length;
    let res = 2 ** 31 - 1;
    for (let i = 0; i < n; ++i) {
        if (nums[i] === i) {
            continue;
        }
        res &= nums[i];
    }
    return res === 2 ** 31 - 1 ? 0 : res;
}
```

```JavaScript
var sortPermutation = function(nums) {
    const n = nums.length;
    let res = 2 ** 31 - 1;
    for (let i = 0; i < n; ++i) {
        if (nums[i] === i) {
            continue;
        }
        res &= nums[i];
    }
    return res === 2 ** 31 - 1 ? 0 : res;
};
```

```CSharp
public class Solution {
    public int SortPermutation(int[] nums) {
        int n = nums.Length;
        int res = int.MaxValue;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == i) {
                continue;
            }
            res &= nums[i];
        }
        return res == int.MaxValue ? 0 : res;
    }
}
```

```C
int sortPermutation(int* nums, int numsSize) {
    int res = INT_MAX;
    for (int i = 0; i < numsSize; ++i) {
        if (nums[i] == i) {
            continue;
        }
        res &= nums[i];
    }
    return res == INT_MAX ? 0 : res;
}
```

```Rust
impl Solution {
    pub fn sort_permutation(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut res = i32::MAX;
        for i in 0..n {
            if nums[i] == i as i32 {
                continue;
            }
            res &= nums[i];
        }
        if res == i32::MAX { 0 } else { res }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。只需要遍历数组一次，对每个元素进行常数时间的判断和位运算操作。
- 空间复杂度：$O(1)$。仅使用了常数级的额外空间。
