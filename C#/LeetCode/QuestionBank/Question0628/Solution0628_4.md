#### [方法二：线性扫描](https://leetcode.cn/problems/maximum-product-of-three-numbers/solutions/567309/san-ge-shu-de-zui-da-cheng-ji-by-leetcod-t9sb/)

在方法一中，我们实际上只要求出数组中最大的三个数以及最小的两个数，因此我们可以不用排序，用线性扫描直接得出这五个数。

```cpp
class Solution {
public:
    int maximumProduct(vector<int>& nums) {
        // 最小的和第二小的
        int min1 = INT_MAX, min2 = INT_MAX;
        // 最大的、第二大的和第三大的
        int max1 = INT_MIN, max2 = INT_MIN, max3 = INT_MIN;

        for (int x: nums) {
            if (x < min1) {
                min2 = min1;
                min1 = x;
            } else if (x < min2) {
                min2 = x;
            }

            if (x > max1) {
                max3 = max2;
                max2 = max1;
                max1 = x;
            } else if (x > max2) {
                max3 = max2;
                max2 = x;
            } else if (x > max3) {
                max3 = x;
            }
        }

        return max(min1 * min2 * max1, max1 * max2 * max3);
    }
};
```

```java
class Solution {
    public int maximumProduct(int[] nums) {
        // 最小的和第二小的
        int min1 = Integer.MAX_VALUE, min2 = Integer.MAX_VALUE;
        // 最大的、第二大的和第三大的
        int max1 = Integer.MIN_VALUE, max2 = Integer.MIN_VALUE, max3 = Integer.MIN_VALUE;

        for (int x : nums) {
            if (x < min1) {
                min2 = min1;
                min1 = x;
            } else if (x < min2) {
                min2 = x;
            }

            if (x > max1) {
                max3 = max2;
                max2 = max1;
                max1 = x;
            } else if (x > max2) {
                max3 = max2;
                max2 = x;
            } else if (x > max3) {
                max3 = x;
            }
        }

        return Math.max(min1 * min2 * max1, max1 * max2 * max3);
    }
}
```

```go
func maximumProduct(nums []int) int {
    // 最小的和第二小的
    min1, min2 := math.MaxInt64, math.MaxInt64
    // 最大的、第二大的和第三大的
    max1, max2, max3 := math.MinInt64, math.MinInt64, math.MinInt64

    for _, x := range nums {
        if x < min1 {
            min2 = min1
            min1 = x
        } else if x < min2 {
            min2 = x
        }

        if x > max1 {
            max3 = max2
            max2 = max1
            max1 = x
        } else if x > max2 {
            max3 = max2
            max2 = x
        } else if x > max3 {
            max3 = x
        }
    }

    return max(min1*min2*max1, max1*max2*max3)
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}
```

```c
int maximumProduct(int* nums, int numsSize) {
    // 最小的和第二小的
    int min1 = INT_MAX, min2 = INT_MAX;
    // 最大的、第二大的和第三大的
    int max1 = INT_MIN, max2 = INT_MIN, max3 = INT_MIN;

    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        if (x < min1) {
            min2 = min1;
            min1 = x;
        } else if (x < min2) {
            min2 = x;
        }

        if (x > max1) {
            max3 = max2;
            max2 = max1;
            max1 = x;
        } else if (x > max2) {
            max3 = max2;
            max2 = x;
        } else if (x > max3) {
            max3 = x;
        }
    }

    return fmax(min1 * min2 * max1, max1 * max2 * max3);
}
```

```javascript
var maximumProduct = function(nums) {
    // 最小的和第二小的
    let min1 = Number.MAX_SAFE_INTEGER, min2 = Number.MAX_SAFE_INTEGER;
    // 最大的、第二大的和第三大的
    let max1 = -Number.MAX_SAFE_INTEGER, max2 = -Number.MAX_SAFE_INTEGER, max3 = -Number.MAX_SAFE_INTEGER;

    for (const x of nums) {
        if (x < min1) {
            min2 = min1;
            min1 = x;
        } else if (x < min2) {
            min2 = x;
        }

        if (x > max1) {
            max3 = max2;
            max2 = max1;
            max1 = x;
        } else if (x > max2) {
            max3 = max2;
            max2 = x;
        } else if (x > max3) {
            max3 = x;
        }
    }

    return Math.max(min1 * min2 * max1, max1 * max2 * max3);
};
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 为数组长度。我们仅需遍历数组一次。
-   空间复杂度：$O(1)$。
