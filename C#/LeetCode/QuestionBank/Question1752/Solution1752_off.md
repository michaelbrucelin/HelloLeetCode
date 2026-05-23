### [检查数组是否经排序和轮转得到](https://leetcode.cn/problems/check-if-array-is-sorted-and-rotated/solutions/1990942/jian-cha-shu-zu-shi-fou-jing-pai-xu-he-l-cbqk/)

#### 方法一：直接遍历

**思路与算法**

按照题意可以知道 $nums$ 的源数组 $source$ 中的所有元素都按非递减顺序排列，假设数组的长度为 $n$，假设当数组向右轮转 $x$ 个位置，令 $x=x\bmod n$，根据置换公式 $source[i]=nums[(i+x)\bmod n]$ 可以知道：

$$nums[0,\dots ,x-1]=source[n-x,\dots ,n-1] \\ nums[x,\dots ,n-1]=source[0,\dots ,n-x-1]$$

- 当 $x=0$ 时，则意味着数组 $nums$ 本身为非递减顺序排列，$nums$ 与原数组相同，此时我们只需要判断 $nums$ 是否为非递减顺序排列；
- 当 $x>0$ 时，则意味着数组 $nums$ 分为了两部分，$nums[0,\dots ,x-1],nums[x,\dots ,n-1]$，需进行分类检测；

对于 $x>0$ 时，根据题意可以知道对于原始数组 $source$ 一定满足当 $i\le j$ 时，则 $source[i]\le source[j]$，由此我们可以推出：

- 当 $0<i<x$ 时，则一定满足 $nums[i-1]\le nums[i]$；
- 当 $x<i<n$ 时，则一定满足 $nums[i-1]\le nums[i]$；
- 当 $x\le i<n$ 时，由于 $source[n-x-1]\le source[n-x]$，则一定满足 $nums[i]\le nums[n-1]\le nums[0]$；
  - 当满足 $source[n-1]=source[0]$ 时，则意味着整个数组均为相等，从任意处轮转数组均保持不变；
  - 当满足 $source[n-1]>source[0]$ 时，此时 $source[n-1],source[0]$ 对应的元素为 $nums[x-1],nums[x]$，此时一定满足 $nums[x-1]>nums[x]$，则此时找到第一个索引 $i$ 满足 $nums[i]<nums[i-1]$ 时，$nums[i-1],nums[i]$ 对应着源数组中的 $source[n-1],source[0]$；

根据上述推理，我们检测过程如下：

- 首先检测数组是否非递减排序，如果满足非递减排序则直接返回 $true$；
- 如果数组不满足非递减排序，则找到第一个 $i$ 满足 $nums[i]<nums[i-1]$，然后分别检测子数组 $nums[0,\dots ,i-1],nums[i,\dots ,n-1]$ 是否都满足非递减排序；
- 如果两个子数组都满足非递减排序，还需检测 $nums[i,\dots ,n-1]$ 中的元素是否都满足小于等于 $nums[0]$，实际我们只需检测 $nums[n-1]$ 是否满足小于等于 $nums[0]$ 即可；

根据上述描述的检测过程进行检测即可。

**代码**

```Python
class Solution:
    def check(self, nums: List[int]) -> bool:
        n = len(nums)
        x = 0
        for i in range(1, n):
            if nums[i] < nums[i - 1]:
                x = i
                break
        if x == 0:
            return True
        for i in range(x + 1, n):
            if nums[i] < nums[i - 1]:
                return False
        return nums[0] >= nums[-1]
```

```C++
class Solution {
public:
    bool check(vector<int>& nums) {
        int n = nums.size(), x = 0;
        for (int i = 1; i < n; ++i) {
            if (nums[i] < nums[i - 1]) {
                x = i;
                break;
            }
        }
        if (x == 0) {
            return true;
        }
        for (int i = x + 1; i < n; ++i) {
            if (nums[i] < nums[i - 1]) {
                return false;
            }
        }
        return nums[0] >= nums[n - 1];
    }
};
```

```Java
class Solution {
    public boolean check(int[] nums) {
        int n = nums.length, x = 0;
        for (int i = 1; i < n; ++i) {
            if (nums[i] < nums[i - 1]) {
                x = i;
                break;
            }
        }
        if (x == 0) {
            return true;
        }
        for (int i = x + 1; i < n; ++i) {
            if (nums[i] < nums[i - 1]) {
                return false;
            }
        }
        return nums[0] >= nums[n - 1];
    }
}
```

```CSharp
public class Solution {
    public bool Check(int[] nums) {
        int n = nums.Length, x = 0;
        for (int i = 1; i < n; ++i) {
            if (nums[i] < nums[i - 1]) {
                x = i;
                break;
            }
        }
        if (x == 0) {
            return true;
        }
        for (int i = x + 1; i < n; ++i) {
            if (nums[i] < nums[i - 1]) {
                return false;
            }
        }
        return nums[0] >= nums[n - 1];
    }
}
```

```C
bool check(int* nums, int numsSize) {
    int x = 0;
    for (int i = 1; i < numsSize; ++i) {
        if (nums[i] < nums[i - 1]) {
            x = i;
            break;
        }
    }
    if (x == 0) {
        return true;
    }
    for (int i = x + 1; i < numsSize; ++i) {
        if (nums[i] < nums[i - 1]) {
            return false;
        }
    }
    return nums[0] >= nums[numsSize - 1];
}
```

```JavaScript
var check = function(nums) {
    let n = nums.length, x = 0;
    for (let i = 1; i < n; ++i) {
        if (nums[i] < nums[i - 1]) {
            x = i;
            break;
        }
    }
    if (x === 0) {
        return true;
    }
    for (let i = x + 1; i < n; ++i) {
        if (nums[i] < nums[i - 1]) {
            return false;
        }
    }
    return nums[0] >= nums[n - 1];
};
```

```Go
func check(nums []int) bool {
    n := len(nums)
    x := 0
    for i := 1; i < n; i++ {
        if nums[i] < nums[i-1] {
            x = i
            break
        }
    }
    if x == 0 {
        return true
    }
    for i := x + 1; i < n; i++ {
        if nums[i] < nums[i-1] {
            return false
        }
    }
    return nums[0] >= nums[n-1]
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示数组的长度。我们只需遍历一遍数组即可。
- 空间复杂度：$O(1)$。遍历过程中不需要额外的空间。
