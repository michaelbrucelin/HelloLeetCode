#### [方法一：遍历](https://leetcode.cn/problems/average-value-of-even-numbers-that-are-divisible-by-three/solutions/2284975/ke-bei-san-zheng-chu-de-ou-shu-de-ping-j-vruh/)

**思路与算法**

题目给定正整数组成的整数数组 $nums$，返回其中可被 $3$ 整除的所有偶数的平均值。被 $3$ 整除的所有偶数，等价于 $6$ 的倍数。

遍历 $nums$ 中的每一个数，判断是否除以 $6$ 没有余数，没有余数即是 $6$ 的倍数，累加到总和中。

最后，返回求和后的平均数，$k$ 个元素的平均值等于求和后除以 $k$，结果向下取整。如果不存在 $6$ 的倍数，返回 $0$。

**代码**

```cpp
class Solution {
public:
    int averageValue(vector<int>& nums) {
        int total = 0, k = 0;
        for (int a : nums) {
            if (a % 6 == 0) {
                total += a;
                k++;
            }
        }
        return k > 0 ? total / k : 0;
    }
};
```

```java
class Solution {
    public int averageValue(int[] nums) {
        int total = 0, k = 0;
        for (int a : nums) {
            if (a % 6 == 0) {
                total += a;
                k++;
            }
        }
        return k > 0 ? total / k : 0;
    }
}
```

```python
class Solution:
    def averageValue(self, nums: List[int]) -> int:
        total = 0
        k = 0
        for a in nums:
            if a % 6 == 0:
                total += a
                k += 1
        return total // k if k > 0 else 0
```

```go
func averageValue(nums []int) int {
    total := 0
    k := 0
    for _, a := range nums {
        if a % 6 == 0 {
            total += a
            k++
        }
    }
    if k > 0 {
        return total / k
    } else {
        return 0
    }
}
```

```javascript
var averageValue = function(nums) {
    let total = 0;
    let k = 0;
    for (let a of nums) {
        if (a % 6 === 0) {
            total += a;
            k++;
        }
    }
    return k > 0 ? Math.floor(total / k) : 0;
};
```

```csharp
public class Solution {
    public int AverageValue(int[] nums) {
        int total = 0, k = 0, n = nums.Length;
        for (int i = 0; i < n; i++) {
            int a = nums[i];
            if (a % 6 == 0) {
                total += a;
                k++;
            }
        }
        return k > 0 ? total / k : 0;
    }
}
```

```c
int averageValue(int* nums, int numsSize){
    int total = 0, k = 0;
    for (int i = 0; i < numsSize; i++) {
        int a = nums[i];
        if (a % 6 == 0) {
            total += a;
            k++;
        }
    }
    return k > 0 ? total / k : 0;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
-   空间复杂度：$O(1)$。
