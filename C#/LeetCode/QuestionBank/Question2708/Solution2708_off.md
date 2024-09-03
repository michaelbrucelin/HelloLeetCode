### [一个小组的最大实力值](https://leetcode.cn/problems/maximum-strength-of-a-group/solutions/2896423/yi-ge-xiao-zu-de-zui-da-shi-li-zhi-by-le-o3nd/)

#### 方法一：分类讨论

**思路**

这道题实际上是求所有元素都为整数的数组的子序列的最大积，从最大积的正负性入手。

- 当数组仅有 $1$ 个元素且为负数时，最大积为负数。
- 当数组不包含正数，且负数元素小于等于 $1$ 个时，最大积为 $0$。
- 其他情况下，最大积为正数。那么如何求这个最大积呢？可以将所有非 $0$ 元素求积，如果乘积为正数，则为最大积。如果乘积为负数，则说明乘积中包含奇数个负数，此时将这个乘积除以最大负数则为最大积。

**代码**

```Python
class Solution:
    def maxStrength(self, nums: List[int]) -> int:
        negativeCount, zeroCount, positiveCount = 0, 0, 0
        prod = 1
        maxNegative = -9
        for num in nums:
            if num < 0:
                negativeCount += 1
                prod *= num
                maxNegative = max(maxNegative, num)
            elif num == 0:
                zeroCount += 1
            else:
                prod *= num
                positiveCount += 1
        if negativeCount == 1 and zeroCount == 0 and positiveCount == 0:
            return nums[0]
        if negativeCount <= 1 and positiveCount == 0:
            return 0
        if prod < 0:
            return prod // maxNegative
        else:
            return prod
```

```Java
class Solution {
    public long maxStrength(int[] nums) {
        int negativeCount = 0, zeroCount = 0, positiveCount = 0;
        long prod = 1;
        int maxNegative = -9;
        for (int num : nums) {
            if (num < 0) {
                negativeCount++;
                prod *= num;
                maxNegative = Math.max(maxNegative, num);
            } else if (num == 0) {
                zeroCount++;
            } else {
                prod *= num;
                positiveCount++;
            }
        }
        if (negativeCount == 1 && zeroCount == 0 && positiveCount == 0) {
            return nums[0];
        }
        if (negativeCount <= 1 && positiveCount == 0) {
            return 0;
        }
        if (prod < 0) {
            return prod / maxNegative;
        } else {
            return prod;
        }
    }
}
```

```CSharp
public class Solution {
    public long MaxStrength(int[] nums) {
        int negativeCount = 0, zeroCount = 0, positiveCount = 0;
        long prod = 1;
        int maxNegative = -9;
        foreach (int num in nums) {
            if (num < 0) {
                negativeCount++;
                prod *= num;
                maxNegative = Math.Max(maxNegative, num);
            } else if (num == 0) {
                zeroCount++;
            } else {
                prod *= num;
                positiveCount++;
            }
        }
        if (negativeCount == 1 && zeroCount == 0 && positiveCount == 0) {
            return nums[0];
        }
        if (negativeCount <= 1 && positiveCount == 0) {
            return 0;
        }
        if (prod < 0) {
            return prod / maxNegative;
        } else {
            return prod;
        }
    }
}
```

```C++
class Solution {
public:
    long long maxStrength(vector<int>& nums) {
        int negativeCount = 0, zeroCount = 0, positiveCount = 0;
        long long prod = 1;
        int maxNegative = INT_MIN;
        for (int num : nums) {
            if (num < 0) {
                negativeCount++;
                prod *= num;
                maxNegative = max(maxNegative, num);
            } else if (num == 0) {
                zeroCount++;
            } else {
                prod *= num;
                positiveCount++;
            }
        }

        if (negativeCount == 1 && zeroCount == 0 && positiveCount == 0) {
            return nums[0];
        }
        if (negativeCount <= 1 && positiveCount == 0) {
            return 0;
        }
        if (prod < 0) {
            return prod / maxNegative;
        } else {
            return prod;
        }
    }
};
```

```C
long long maxStrength(int* nums, int numsSize){
    int negativeCount = 0, zeroCount = 0, positiveCount = 0;
    long long prod = 1;
    int maxNegative = INT_MIN;

    for (int i = 0; i < numsSize; ++i) {
        int num = nums[i];
        if (num < 0) {
            negativeCount++;
            prod *= num;
            if (num > maxNegative) {
                maxNegative = num;
            }
        } else if (num == 0) {
            zeroCount++;
        } else {
            prod *= num;
            positiveCount++;
        }
    }

    if (negativeCount == 1 && zeroCount == 0 && positiveCount == 0) {
        return nums[0];
    }
    if (negativeCount <= 1 && positiveCount == 0) {
        return 0;
    }
    if (prod < 0) {
        return prod / maxNegative;
    } else {
        return prod;
    }
}
```

```Go
func maxStrength(nums []int) int64 {
    negativeCount, zeroCount, positiveCount := 0, 0, 0
    prod := 1
    maxNegative := math.MinInt32

    for _, num := range nums {
        if num < 0 {
            negativeCount++
            prod *= num
            if num > maxNegative {
                maxNegative = num
            }
        } else if num == 0 {
            zeroCount++
        } else {
            prod *= num
            positiveCount++
        }
    }

    if negativeCount == 1 && zeroCount == 0 && positiveCount == 0 {
        return int64(nums[0])
    }
    if negativeCount <= 1 && positiveCount == 0 {
        return int64(0)
    }
    if prod < 0 {
        return int64(prod / maxNegative)
    } else {
        return int64(prod)
    }
}
```

```JavaScript

var maxStrength = function(nums) {
    let negativeCount = 0, zeroCount = 0, positiveCount = 0;
    let prod = 1;
    let maxNegative = -Number.MAX_VALUE;

    for (let num of nums) {
        if (num < 0) {
            negativeCount++;
            prod *= num;
            maxNegative = Math.max(maxNegative, num);
        } else if (num === 0) {
            zeroCount++;
        } else {
            prod *= num;
            positiveCount++;
        }
    }
    if (negativeCount === 1 && zeroCount === 0 && positiveCount === 0) {
        return nums[0];
    }
    if (negativeCount <= 1 && positiveCount === 0) {
        return 0;
    }
    if (prod < 0) {
        return Math.floor(prod / maxNegative);
    } else {
        return prod;
    }
};
```

```TypeScript
function maxStrength(nums: number[]): number {
    let negativeCount = 0, zeroCount = 0, positiveCount = 0;
    let prod = 1;
    let maxNegative = Number.MIN_SAFE_INTEGER;

    for (const num of nums) {
        if (num < 0) {
            negativeCount++;
            prod *= num;
            maxNegative = Math.max(maxNegative, num);
        } else if (num === 0) {
            zeroCount++;
        } else {
            prod *= num;
            positiveCount++;
        }
    }

    if (negativeCount === 1 && zeroCount === 0 && positiveCount === 0) {
        return nums[0];
    }
    if (negativeCount <= 1 && positiveCount === 0) {
        return 0;
    }
    if (prod < 0) {
        return Math.floor(prod / maxNegative);
    } else {
        return prod;
    }
};
```

```Rust
impl Solution {
    pub fn max_strength(nums: Vec<i32>) -> i64 {
        let mut negative_count = 0;
        let mut zero_count = 0;
        let mut positive_count = 0;
        let mut prod: i64 = 1;
        let mut max_negative = i32::MIN;

        for &num in &nums {
            if num < 0 {
                negative_count += 1;
                prod *= num as i64;
                if num > max_negative {
                    max_negative = num;
                }
            } else if num == 0 {
                zero_count += 1;
            } else {
                prod *= num as i64;
                positive_count += 1;
            }
        }

        if negative_count == 1 && zero_count == 0 && positive_count == 0 {
            return nums[0] as i64;
        }
        if negative_count <= 1 && positive_count == 0 {
            return 0;
        }
        if prod < 0 {
            prod / (max_negative as i64)
        } else {
            prod as i64
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。$n$ 为数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
