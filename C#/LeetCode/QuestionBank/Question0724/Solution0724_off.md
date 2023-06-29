#### 方法一：前缀和

**思路**

记数组的全部元素之和为 $total$，当遍历到第 $i$ 个元素时，设其左侧元素之和为 $sum$，则其右侧元素之和为 $total-nums_i-sum$。左右侧元素相等即为 $sum=total-nums_i-sum$，即 $2\times sum+nums_i=total$。

当中心索引左侧或右侧没有元素时，即为零个项相加，这在数学上称作「空和」（$empty sum$）。在程序设计中我们约定「空和是零」。

**代码**

```cpp
class Solution {
public:
    int pivotIndex(vector<int> &nums) {
        int total = accumulate(nums.begin(), nums.end(), 0);
        int sum = 0;
        for (int i = 0; i < nums.size(); ++i) {
            if (2 * sum + nums[i] == total) {
                return i;
            }
            sum += nums[i];
        }
        return -1;
    }
};
```

```java
class Solution {
    public int pivotIndex(int[] nums) {
        int total = Arrays.stream(nums).sum();
        int sum = 0;
        for (int i = 0; i < nums.length; ++i) {
            if (2 * sum + nums[i] == total) {
                return i;
            }
            sum += nums[i];
        }
        return -1;
    }
}
```

```csharp
public class Solution {
    public int PivotIndex(int[] nums) {
        int total = nums.Sum();
        int sum = 0;
        for (int i = 0; i < nums.Length; ++i) {
            if (2 * sum + nums[i] == total) {
                return i;
            }
            sum += nums[i];
        }
        return -1;
    }
}
```

```go
func pivotIndex(nums []int) int {
    total := 0
    for _, v := range nums {
        total += v
    }
    sum := 0
    for i, v := range nums {
        if 2*sum+v == total {
            return i
        }
        sum += v
    }
    return -1
}
```

```javascript
var pivotIndex = function(nums) {
    const total = nums.reduce((a, b) => a + b, 0);
    let sum = 0;
    for (let i = 0; i < nums.length; i++) {
        if (2 * sum + nums[i] === total) {
            return i;
        }
        sum += nums[i];
    }
    return -1;
};
```

```c
int pivotIndex(int* nums, int numsSize) {
    int total = 0;
    for (int i = 0; i < numsSize; ++i) {
        total += nums[i];
    }
    int sum = 0;
    for (int i = 0; i < numsSize; ++i) {
        if (2 * sum + nums[i] == total) {
            return i;
        }
        sum += nums[i];
    }
    return -1;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为数组的长度。
-   空间复杂度：$O(1)$。
