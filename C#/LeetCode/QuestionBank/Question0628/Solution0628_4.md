#### [������������ɨ��](https://leetcode.cn/problems/maximum-product-of-three-numbers/solutions/567309/san-ge-shu-de-zui-da-cheng-ji-by-leetcod-t9sb/)

�ڷ���һ�У�����ʵ����ֻҪ��������������������Լ���С����������������ǿ��Բ�������������ɨ��ֱ�ӵó����������

```cpp
class Solution {
public:
    int maximumProduct(vector<int>& nums) {
        // ��С�ĺ͵ڶ�С��
        int min1 = INT_MAX, min2 = INT_MAX;
        // ���ġ��ڶ���ĺ͵������
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
        // ��С�ĺ͵ڶ�С��
        int min1 = Integer.MAX_VALUE, min2 = Integer.MAX_VALUE;
        // ���ġ��ڶ���ĺ͵������
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
    // ��С�ĺ͵ڶ�С��
    min1, min2 := math.MaxInt64, math.MaxInt64
    // ���ġ��ڶ���ĺ͵������
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
    // ��С�ĺ͵ڶ�С��
    int min1 = INT_MAX, min2 = INT_MAX;
    // ���ġ��ڶ���ĺ͵������
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
    // ��С�ĺ͵ڶ�С��
    let min1 = Number.MAX_SAFE_INTEGER, min2 = Number.MAX_SAFE_INTEGER;
    // ���ġ��ڶ���ĺ͵������
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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(N)$������ $N$ Ϊ���鳤�ȡ����ǽ����������һ�Ρ�
-   �ռ临�Ӷȣ�$O(1)$��
