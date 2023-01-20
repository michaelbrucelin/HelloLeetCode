#### [方法一：排序](https://leetcode.cn/problems/maximum-product-of-three-numbers/solutions/567309/san-ge-shu-de-zui-da-cheng-ji-by-leetcod-t9sb/)

首先将数组排序。

如果数组中全是非负数，则排序后最大的三个数相乘即为最大乘积；如果全是非正数，则最大的三个数相乘同样也为最大乘积。

如果数组中有正数有负数，则最大乘积既可能是三个最大正数的乘积，也可能是两个最小负数（即绝对值最大）与最大正数的乘积。

综上，我们在给数组排序后，分别求出三个最大正数的乘积，以及两个最小负数与最大正数的乘积，二者之间的最大值即为所求答案。

```cpp
class Solution {
public:
    int maximumProduct(vector<int>& nums) {
        sort(nums.begin(), nums.end());
        int n = nums.size();
        return max(nums[0] * nums[1] * nums[n - 1], nums[n - 3] * nums[n - 2] * nums[n - 1]);
    }
};
```

```java
class Solution {
    public int maximumProduct(int[] nums) {
        Arrays.sort(nums);
        int n = nums.length;
        return Math.max(nums[0] * nums[1] * nums[n - 1], nums[n - 3] * nums[n - 2] * nums[n - 1]);
    }
}
```

```go
func maximumProduct(nums []int) int {
    sort.Ints(nums)
    n := len(nums)
    return max(nums[0]*nums[1]*nums[n-1], nums[n-3]*nums[n-2]*nums[n-1])
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}
```

```c
int cmp(int* a, int* b) {
    return *a - *b;
}

int maximumProduct(int* nums, int numsSize) {
    qsort(nums, numsSize, sizeof(int), cmp);
    return fmax(nums[0] * nums[1] * nums[numsSize - 1], nums[numsSize - 3] * nums[numsSize - 2] * nums[numsSize - 1]);
}
```

```javascript
var maximumProduct = function(nums) {
    nums.sort((a, b) => a - b);
    const n = nums.length;
    return Math.max(nums[0] * nums[1] * nums[n - 1], nums[n - 1] * nums[n - 2] * nums[n - 3]);
};
```

**复杂度分析**

-   时间复杂度：$O(N \log N)$，其中 $N$ 为数组长度。排序需要 $O(N \log N)$ 的时间。
-   空间复杂度：$O(\log N)$，主要为排序的空间开销。
