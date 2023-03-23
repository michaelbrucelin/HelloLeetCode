#### [方法一：动态规划](https://leetcode.cn/problems/contiguous-sequence-lcci/solutions/586439/lian-xu-shu-lie-by-leetcode-solution-be4z/)

**思路和算法**

假设 $nums$ 数组的长度是 $n$，下标从 $0$ 到 $n-1$。

我们用 $f(i)$ 代表以第 $i$ 个数结尾的「连续子数组的最大和」，那么很显然我们要求的答案就是：

$$\max_{0 \leq i \leq n-1} \{ f(i) \}$$

因此我们只需要求出每个位置的 $f(i)$，然后返回 $f$ 数组中的最大值即可。那么我们如何求 $f(i)$ 呢？我们可以考虑 $nums[i]$ 单独成为一段还是加入 $f(i-1)$ 对应的那一段，这取决于 $nums[i]$ 和 $f(i-1) + nums[i]$ 的大小，我们希望获得一个比较大的，于是可以写出这样的动态规划转移方程：

$$f(i) = \max \{ f(i-1) + nums[i], nums[i] \} $$ 

不难给出一个时间复杂度 $O(n)$、空间复杂度 $O(n)$ 的实现，即用一个 $f$ 数组来保存 $f(i)$ 的值，用一个循环求出所有 $f(i)$。考虑到 $f(i)$ 只和 $f(i-1)$ 相关，于是我们可以只用一个变量 $pre$ 来维护对于当前 $f(i)$ 的 $f(i-1)$ 的值是多少，从而让空间复杂度降低到 $O(1)$，这有点类似「滚动数组」的思想。 

**代码** 
```cpp [sol1-C++]
class Solution {
    public: int maxSubArray(vector<int>& nums) {
        int pre = 0, maxAns = nums[0];
        for (const auto &x: nums) {
            pre = max(pre + x, x);
            maxAns = max(maxAns, pre);
        }
        return maxAns;
    }
};
```

```csharp [sol1-C#]
public class Solution {
    public int MaxSubArray(int[] nums) {
        int pre = 0, maxAns = nums[0];
        foreach (int x in nums) {
            pre = Math.Max(pre + x, x);
            maxAns = Math.Max(maxAns, pre);
        }
        return maxAns;
    }
}
```

```Java [sol1-Java]
class Solution {
    public int maxSubArray(int[] nums) {
        int pre = 0, maxAns = nums[0];
        for (int x : nums) {
            pre = Math.max(pre + x, x);
            maxAns = Math.max(maxAns, pre);
        }
        return maxAns;
    }
}
```

```JavaScript [sol1-JavaScript]
var maxSubArray = function(nums) {
    let pre = 0, maxAns = nums[0];
    nums.forEach((x) => {
        pre = Math.max(pre + x, x);
        maxAns = Math.max(maxAns, pre);
    });
    return maxAns;
};
```

```go [sol1-Golang]
func maxSubArray(nums []int) int {
    max := nums[0]
    for i := 1; i < len(nums); i++ {
        if nums[i] + nums[i-1] > nums[i] {
            nums[i] += nums[i-1]
        }
        if nums[i] > max {
            max = nums[i]
        }
    }
    return max
}
```

```C [sol1-C]
int maxSubArray(int* nums, int numsSize) {
    int pre = 0, maxAns = nums[0];
    for (int i = 0; i < numsSize; i++) {
        pre = fmax(pre + nums[i], nums[i]);
        maxAns = fmax(maxAns, pre);
    }
    return maxAns;
}
```

**复杂度** 
+ 时间复杂度：$O(n)$，其中 $n$ 为 $nums$ 数组的长度。我们只需要遍历一遍数组即可求得答案。
+ 空间复杂度：$O(1)$。我们只需要常数空间存放若干变量。 
