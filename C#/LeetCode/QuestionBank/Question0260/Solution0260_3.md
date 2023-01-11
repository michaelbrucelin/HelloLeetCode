#### [方法二：位运算](https://leetcode.cn/problems/single-number-iii/solutions/587516/zhi-chu-xian-yi-ci-de-shu-zi-iii-by-leet-4i8e/)

**思路与算法**

在理解如何使用位运算解决本题前，读者需要首先掌握[「136. 只出现一次的数字」](https://leetcode-cn.com/problems/single-number/)中的位运算做法。

假设数组 $nums$ 中只出现一次的元素分别是 $x_1$ 和 $x_2$。如果把 $nums$ 中的所有元素全部异或起来，得到结果 $x$，那么一定有：$x = x_1 \oplus x_2$

其中 $\oplus$ 表示异或运算。这是因为 $nums$ 中出现两次的元素都会因为异或运算的性质 $a \oplus b \oplus b = a$ 抵消掉，那么最终的结果就只剩下 $x_1$ 和 $x_2$ 的异或和。

$x$ 显然不会等于 $0$，因为如果 $x=0$，那么说明 $x_1 = x_2$，这样 $x_1$ 和 $x_2$ 就不是只出现一次的数字了。因此，我们可以使用位运算 $x \& -x$ 取出 $x$ 的二进制表示中最低位那个 $1$，设其为第 $l$ 位，那么 $x_1$ 和 $x_2$ 中的某一个数的二进制表示的第 $l$ 位为 $0$，另一个数的二进制表示的第 $l$ 位为 $1$。在这种情况下，$x_1 \oplus x_2$ 的二进制表示的第 $l$ 位才能为 $1$。

这样一来，我们就可以把 $nums$ 中的所有元素分成两类，其中一类包含所有二进制表示的第 $l$ 位为 $0$ 的数，另一类包含所有二进制表示的第 $l$ 位为 $1$ 的数。可以发现：

-   对于任意一个在数组 $nums$ 中出现两次的元素，该元素的两次出现会被包含在同一类中；
-   对于任意一个在数组 $nums$ 中只出现了一次的元素，即 $x_1$ 和 $x_2$，它们会被包含在不同类中。

因此，如果我们将每一类的元素全部异或起来，那么其中一类会得到 $x_1$，另一类会得到 $x_2$。这样我们就找出了这两个只出现一次的元素。

**代码**

```cpp
class Solution {
public:
    vector<int> singleNumber(vector<int>& nums) {
        int xorsum = 0;
        for (int num: nums) {
            xorsum ^= num;
        }
        // 防止溢出
        int lsb = (xorsum == INT_MIN ? xorsum : xorsum & (-xorsum));
        int type1 = 0, type2 = 0;
        for (int num: nums) {
            if (num & lsb) {
                type1 ^= num;
            }
            else {
                type2 ^= num;
            }
        }
        return {type1, type2};
    }
};
```

```java
class Solution {
    public int[] singleNumber(int[] nums) {
        int xorsum = 0;
        for (int num : nums) {
            xorsum ^= num;
        }
        // 防止溢出
        int lsb = (xorsum == Integer.MIN_VALUE ? xorsum : xorsum & (-xorsum));
        int type1 = 0, type2 = 0;
        for (int num : nums) {
            if ((num & lsb) != 0) {
                type1 ^= num;
            } else {
                type2 ^= num;
            }
        }
        return new int[]{type1, type2};
    }
}
```

```csharp
public class Solution {
    public int[] SingleNumber(int[] nums) {
        int xorsum = 0;
        foreach (int num in nums) {
            xorsum ^= num;
        }
        // 防止溢出
        int lsb = (xorsum == int.MinValue ? xorsum : xorsum & (-xorsum));
        int type1 = 0, type2 = 0;
        foreach (int num in nums) {
            if ((num & lsb) != 0) {
                type1 ^= num;
            } else {
                type2 ^= num;
            }
        }
        return new int[]{type1, type2};
    }
}
```

```python
class Solution:
    def singleNumber(self, nums: List[int]) -> List[int]:
        xorsum = 0
        for num in nums:
            xorsum ^= num

        lsb = xorsum & (-xorsum)
        type1 = type2 = 0
        for num in nums:
            if num & lsb:
                type1 ^= num
            else:
                type2 ^= num

        return [type1, type2]
```

```javascript
var singleNumber = function(nums) {
    let xorsum = 0;

    for (const num of nums) {
        xorsum ^= num;
    }
    let type1 = 0, type2 = 0;
    const lsb = xorsum & (-xorsum);
    for (const num of nums) {
        if (num & lsb) {
            type1 ^= num;
        } else {
            type2 ^= num;
        }
    }
    return [type1, type2];
};
```

```go
func singleNumber(nums []int) []int {
    xorSum := 0
    for _, num := range nums {
        xorSum ^= num
    }
    lsb := xorSum & -xorSum
    type1, type2 := 0, 0
    for _, num := range nums {
        if num&lsb > 0 {
            type1 ^= num
        } else {
            type2 ^= num
        }
    }
    return []int{type1, type2}
}
```

```c
int* singleNumber(int* nums, int numsSize, int* returnSize) {
    int xorsum = 0;
    for (int i = 0; i < numsSize; i++) {
        xorsum ^= nums[i];
    }
    // 防止溢出
    int lsb = (xorsum == INT_MIN ? xorsum : xorsum & (-xorsum));
    int type1 = 0, type2 = 0;
    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        if (num & lsb) {
            type1 ^= num;
        } else {
            type2 ^= num;
        }
    }

    int *ans = (int *)malloc(sizeof(int) * 2);
    ans[0] = type1;
    ans[1] = type2;
    *returnSize = 2;
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
-   空间复杂度：$O(1)$。
