### [最小差值 I](https://leetcode.cn/problems/smallest-range-i/solutions/1449819/zui-xiao-chai-zhi-i-by-leetcode-solution-7lcl/)

#### 方法一：数学

**思路与算法**

假设整数数组 $nums$ 的最小值为 $minNum$，最大值为 $maxNum$。

- 如果 $maxNum-minNum \le 2k$，那么我们总可以将整数数组 $nums$ 的所有元素都改为同一个整数，因此更改后的整数数组 $nums$ 的最低分数为 $0$。
    > 证明：因为 $maxNum-minNum \le 2k$，所以存在整数 $x \in [minNum,maxNum]$，使得 $x-minNum \le k$ 且 $maxNum-x \le k$。那么整数数组 $nums$ 的所有元素与整数 $x$ 的绝对差值都不超过 $k$，即所有元素都可以改为 $x$。
- 如果 $maxNum-minNum > 2k$，那么更改后的整数数组 $nums$ 的最低分数为 $maxNum-minNum-2k$。
    > 证明：对于 $minNum$ 和 $maxNum$ 两个元素，我们将 $minNum$ 改为 $minNum+k$，$maxNum$ 改为 $maxNum-k$，此时两个元素的绝对差值最小。因此更改后的整数数组 $nums$ 的最低分数大于等于 $maxNum-minNum-2k$。
    > 对于整数数组 $nums$ 中的元素 $x$，如果 $x<minNum+k$，那么 $x$ 可以更改为 $minNum+k$，如果 $x>maxNum-k$，那么 $x$ 可以更改为 $maxNum-k$，因此整数数组 $nums$ 的所有元素都可以改为区间 $[minNum+k,maxNum-k]$ 的整数，所以更改后的整数数组 $nums$ 的最低分数小于等于 $maxNum-minNum-2k$。
    > 综上所述，更改后的整数数组 $nums$ 的最低分数为 $maxNum-minNum-2k$。
    

**代码**

```Python
class Solution:
    def smallestRangeI(self, nums: List[int], k: int) -> int:
        return max(0, max(nums) - min(nums) - 2 * k)
```

```C++
class Solution {
public:
    int smallestRangeI(vector<int>& nums, int k) {
        int minNum = *min_element(nums.begin(), nums.end());
        int maxNum = *max_element(nums.begin(), nums.end());
        return maxNum - minNum <= 2 * k ? 0 : maxNum - minNum - 2 * k;
    }
};
```

```Java
class Solution {
    public int smallestRangeI(int[] nums, int k) {
        int minNum = Arrays.stream(nums).min().getAsInt();
        int maxNum = Arrays.stream(nums).max().getAsInt();
        return maxNum - minNum <= 2 * k ? 0 : maxNum - minNum - 2 * k;
    }
}
```

```CSharp
public class Solution {
    public int SmallestRangeI(int[] nums, int k) {
        int minNum = nums.Min();
        int maxNum = nums.Max();
        return maxNum - minNum <= 2 * k ? 0 : maxNum - minNum - 2 * k;
    }
}
```

```C
#define MIN(a, b) ((a) < (b) ? (a) : (b))
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int smallestRangeI(int* nums, int numsSize, int k) {
    int minNum = INT_MAX, maxNum = INT_MIN;
    for (int i = 0; i < numsSize; i++) {
        minNum = MIN(minNum, nums[i]);
        maxNum = MAX(maxNum, nums[i]);
    }
    return maxNum - minNum <= 2 * k ? 0 : maxNum - minNum - 2 * k;
}
```

```Go
func smallestRangeI(nums []int, k int) int {
    minNum, maxNum := nums[0], nums[0]
    for _, num := range nums[1:] {
        if num < minNum {
            minNum = num
        } else if num > maxNum {
            maxNum = num
        }
    }
    ans := maxNum - minNum - 2*k
    if ans > 0 {
        return ans
    }
    return 0
}
```

```JavaScript
var smallestRangeI = function(nums, k) {
    const minNum = _.min(nums);
    const maxNum = _.max(nums);
    return maxNum - minNum <= 2 * k ? 0 : maxNum - minNum - 2 * k;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是整数数组 $nums$ 的长度。需要 $O(n)$ 的时间遍历数组 $nums$ 得到最小值和最大值，然后需要 $O(1)$ 的时间计算最低分数。
- 空间复杂度：$O(1)$。
