### [一维数组的动态和](https://leetcode.cn/problems/running-sum-of-1d-array/solutions/962723/yi-wei-shu-zu-de-dong-tai-he-by-leetcode-flkm/)

#### 方法一：原地修改

**思路和算法**

因为有 $runningSum[i]= \sum_{i=0}^i​nums[i]$。

可以推导出：

$$runningSum[i]=\left\{\begin{array}{ll}nums[0], && ​i=0 \\ runningSum[i-1]+nums[i], && i>0\end{array}\right.​$$

这样我们可以从下标 $1$ 开始遍历 $nums$ 数组，每次让 $nums[i]$ 变为 $nums[i-1]+nums[i]$ 即可（因为此时的 $nums[i-1]$ 即为 $runningSum[i-1]$）。

**代码**

```C++
class Solution {
public:
    vector<int> runningSum(vector<int>& nums) {
        int n = nums.size();
        for (int i = 1; i < n; i++) {
            nums[i] += nums[i - 1];
        }
        return nums;
    }
};
```

```Java
class Solution {
    public int[] runningSum(int[] nums) {
        int n = nums.length;
        for (int i = 1; i < n; i++) {
            nums[i] += nums[i - 1];
        }
        return nums;
    }
}
```

```CSharp
public class Solution {
    public int[] RunningSum(int[] nums) {
        int n = nums.Length;
        for (int i = 1; i < n; i++) {
            nums[i] += nums[i - 1];
        }
        return nums;
    }
}
```

```C
int* runningSum(int* nums, int numsSize, int* returnSize) {
    *returnSize = numsSize;
    for (int i = 1; i < numsSize; i++) {
        nums[i] += nums[i - 1];
    }
    return nums;
}
```

```Python
class Solution:
    def runningSum(self, nums: List[int]) -> List[int]:
        n = len(nums)
        for i in range(1, n):
            nums[i] += nums[i - 1]
        return nums
```

```JavaScript
var runningSum = function(nums) {
    const n = nums.length;
    for (let i = 1; i < n; i++) {
        nums[i] += nums[i - 1];
    }
    return nums;
};
```

```Go
func runningSum(nums []int) []int {
    n := len(nums)
    for i := 1; i < n; i++ {
        nums[i] += nums[i-1]
    }
    return nums
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是给定数组长度。
- 空间复杂度：$O(1)$。我们只需要常数的空间保存若干变量。
