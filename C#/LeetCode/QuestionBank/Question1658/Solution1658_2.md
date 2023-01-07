﻿#### 方法一：滑动窗口

**思路与算法**

根据题目描述，在每一次操作中，我们可以移除数组 $nums$ 最左边或最右边的元素。因此，在所有的操作完成后，数组 $nums$ 的一个前缀以及一个后缀被移除，并且它们的和恰好为 $x$。前缀以及后缀可以为空。

记数组的长度为 $n$，我们可以用 $left$ 和 $right$ 分别表示选择的前缀以及后缀的边界。如果 $left=−1$，表示我们选择了空前缀；如果 $right=n$，表示我们选择了空后缀。

由于数组 $nums$ 中的元素均为正数，因此当 $left$ 向右移动（即前缀的范围增加）时，它们的和是严格递增的。要想将它们的和控制在 $x$，我们必须要将 $right$ 向右移动。这样一来，我们就可以用滑动窗口的方法解决本题。

初始时，$left$ 的值为 $−1$，$right$ 为 $0$，表示选择了空前缀以及整个数组作为后缀。我们用 $lsum$ 和 $rsum$ 分别记录前缀以及后缀的和，那么：
-   如果 $lsum + rsum = x$，说明我们找到了一组答案，对应的操作次数为 $(left+1)+(n−right)$；
-   如果 $lsum + rsum > x$，说明和过大，我们需要将 $right$ 向右移动一个位置；
-   如果 $lsum + rsum < x$，说明和过小，我们需要将 $left$ 向右移动一个位置。

**代码**

```cpp
class Solution {
public:
    int minOperations(vector<int>& nums, int x) {
        int n = nums.size();
        int sum = accumulate(nums.begin(), nums.end(), 0);

        if (sum < x) {
            return -1;
        }

        int right = 0;
        int lsum = 0, rsum = sum;
        int ans = n + 1;

        for (int left = -1; left < n; ++left) {
            if (left != -1) {
                lsum += nums[left];
            }
            while (right < n && lsum + rsum > x) {
                rsum -= nums[right];
                ++right;
            }
            if (lsum + rsum == x) {
                ans = min(ans, (left + 1) + (n - right));
            }
        }

        return ans > n ? -1 : ans;
    }
};
```

```java
class Solution {
    public int minOperations(int[] nums, int x) {
        int n = nums.length;
        int sum = Arrays.stream(nums).sum();

        if (sum < x) {
            return -1;
        }

        int right = 0;
        int lsum = 0, rsum = sum;
        int ans = n + 1;

        for (int left = -1; left < n; ++left) {
            if (left != -1) {
                lsum += nums[left];
            }
            while (right < n && lsum + rsum > x) {
                rsum -= nums[right];
                ++right;
            }
            if (lsum + rsum == x) {
                ans = Math.min(ans, (left + 1) + (n - right));
            }
        }

        return ans > n ? -1 : ans;
    }
}
```

```csharp
public class Solution {
    public int MinOperations(int[] nums, int x) {
        int n = nums.Length;
        int sum = nums.Sum();

        if (sum < x) {
            return -1;
        }

        int right = 0;
        int lsum = 0, rsum = sum;
        int ans = n + 1;

        for (int left = -1; left < n; ++left) {
            if (left != -1) {
                lsum += nums[left];
            }
            while (right < n && lsum + rsum > x) {
                rsum -= nums[right];
                ++right;
            }
            if (lsum + rsum == x) {
                ans = Math.Min(ans, (left + 1) + (n - right));
            }
        }

        return ans > n ? -1 : ans;
    }
}
```

```python
class Solution:
    def minOperations(self, nums: List[int], x: int) -> int:
        n = len(nums)
        total = sum(nums)

        if total < x:
            return -1
        
        right = 0
        lsum, rsum = 0, total
        ans = n + 1
        for left in range(-1, n - 1):
            if left != -1:
                lsum += nums[left]
            while right < n and lsum + rsum > x:
                rsum -= nums[right]
                right += 1
            if lsum + rsum == x:
                ans = min(ans, (left + 1) + (n - right))
        
        return -1 if ans > n else ans
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int minOperations(int* nums, int numsSize, int x) {
    int sum = 0;
    for (int i = 0; i < numsSize; i++) {
        sum += nums[i];
    }
    if (sum < x) {
        return -1;
    }

    int right = 0;
    int lsum = 0, rsum = sum;
    int ans = numsSize + 1;

    for (int left = -1; left < numsSize; ++left) {
        if (left != -1) {
            lsum += nums[left];
        }
        while (right < numsSize && lsum + rsum > x) {
            rsum -= nums[right];
            ++right;
        }
        if (lsum + rsum == x) {
            ans = MIN(ans, (left + 1) + (numsSize - right));
        }
    }
    return ans > numsSize ? -1 : ans;
}
```

```javascript
var minOperations = function(nums, x) {
    const n = nums.length;
    const sum = _.sum(nums);

    if (sum < x) {
        return -1;
    }

    let right = 0;
    let lsum = 0, rsum = sum;
    let ans = n + 1;

    for (let left = -1; left < n; ++left) {
        if (left != -1) {
            lsum += nums[left];
        }
        while (right < n && lsum + rsum > x) {
            rsum -= nums[right];
            ++right;
        }
        if (lsum + rsum === x) {
            ans = Math.min(ans, (left + 1) + (n - right));
        }
    }

    return ans > n ? -1 : ans;
};
```

```go
func minOperations(nums []int, x int) int {
    n := len(nums)
    sum := 0
    for _, num := range nums {
        sum += num
    }
    if sum < x {
        return -1
    }

    right := 0
    lsum := 0
    rsum := sum
    ans := n + 1

    for left := -1; left < n; left++ {
        if left != -1 {
            lsum += nums[left]
        }
        for right < n && lsum+rsum > x {
            rsum -= nums[right]
            right++
        }
        if lsum+rsum == x {
            ans = min(ans, (left+1)+(n-right))
        }
    }
    if ans > n {
        return -1
    }
    return ans
}

func min(a, b int) int {
    if b < a {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。$left$ 和 $right$ 均最多遍历整个数组一次。
-   空间复杂度：$O(1)$。
