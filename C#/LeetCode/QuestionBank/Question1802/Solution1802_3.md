#### [方法一：贪心 + 二分查找](https://leetcode.cn/problems/maximum-value-at-a-given-index-in-a-bounded-array/solutions/2042360/you-jie-shu-zu-zhong-zhi-ding-xia-biao-c-aav4/)

**思路**

根据题意，需要构造一个长度为 $n$ 的数组 $nums$，所有元素均为正整数，元素之和不超过 $maxSum$，相邻元素之差不超过 $1$，且需要最大化 $nums[index]$。根据贪心的思想，可以使 $nums[index]$ 成为数组最大的元素，并使其他元素尽可能小，即从 $nums[index]$ 开始，往左和往右，下标每相差 $1$，元素值就减少 $1$，直到到达数组边界，或者减少到仅为 $1$ 后保持为 $1$ 不变。

根据这个思路，一旦 $nums[index]$ 确定后，这个数组的和 $numsSum$ 也就确定了。并且 $nums[index]$ 越大，数组和 $numsSum$ 也越大。据此，可以使用二分搜索来找出最大的使得 $numsSum \leq maxSum$ 成立的 $nums[index]$。

代码实现上，二分搜索的左边界为 $1$，右边界为 $maxSum$。函数 $valid$ 用来判断当前的 $nums[index]$ 对应的 $numsSum$ 是否满足条件。$numsSum$ 由三部分组成，$nums[index]$，$nums[index]$ 左边的部分之和，和 $nums[index]$ 右边的部分之和。$cal$ 用来计算单边的元素和，需要考虑边界元素是否早已下降到 $1$ 的情况。

**代码**

```python
class Solution:
    def maxValue(self, n: int, index: int, maxSum: int) -> int: 
        left, right = 1, maxSum
        while left < right:
            mid = (left + right + 1) // 2
            if self.valid(mid, n, index, maxSum):
                left = mid
            else:
                right = mid - 1
        return left

    def valid(self, mid: int, n: int, index: int, maxSum: int) -> bool:
        left = index
        right = n - index - 1
        return mid + self.cal(mid, left) + self.cal(mid, right) <= maxSum

    def cal(self, big: int, length: int) -> int:
        if length + 1 < big:
            small = big - length
            return ((big - 1 + small) * length) // 2
        else:
            ones = length - (big - 1)
            return (big - 1 + 1) * (big - 1) // 2 + ones
```

```java
class Solution {
    public int maxValue(int n, int index, int maxSum) {
        int left = 1, right = maxSum;
        while (left < right) {
            int mid = (left + right + 1) / 2;
            if (valid(mid, n, index, maxSum)) {
                left = mid;
            } else {
                right = mid - 1;
            }
        }
        return left;
    }

    public boolean valid(int mid, int n, int index, int maxSum) {
        int left = index;
        int right = n - index - 1;
        return mid + cal(mid, left) + cal(mid, right) <= maxSum;
    }

    public long cal(int big, int length) {
        if (length + 1 < big) {
            int small = big - length;
            return (long) (big - 1 + small) * length / 2;
        } else {
            int ones = length - (big - 1);
            return (long) big * (big - 1) / 2 + ones;
        }
    }
}
```

```csharp
public class Solution {
    public int MaxValue(int n, int index, int maxSum) {
        int left = 1, right = maxSum;
        while (left < right) {
            int mid = (left + right + 1) / 2;
            if (Valid(mid, n, index, maxSum)) {
                left = mid;
            } else {
                right = mid - 1;
            }
        }
        return left;
    }

    public bool Valid(int mid, int n, int index, int maxSum) {
        int left = index;
        int right = n - index - 1;
        return mid + Cal(mid, left) + Cal(mid, right) <= maxSum;
    }

    public long Cal(int big, int length) {
        if (length + 1 < big) {
            int small = big - length;
            return (long) (big - 1 + small) * length / 2;
        } else {
            int ones = length - (big - 1);
            return (long) big * (big - 1) / 2 + ones;
        }
    }
}
```

```cpp
class Solution {
public:
    int maxValue(int n, int index, int maxSum) {
        int left = 1, right = maxSum;
        while (left < right) {
            int mid = (left + right + 1) / 2;
            if (valid(mid, n, index, maxSum)) {
                left = mid;
            } else {
                right = mid - 1;
            }
        }
        return left;
    }

    bool valid(int mid, int n, int index, int maxSum) {
        int left = index;
        int right = n - index - 1;
        return mid + cal(mid, left) + cal(mid, right) <= maxSum;
    }

    long cal(int big, int length) {
        if (length + 1 < big) {
            int small = big - length;
            return (long) (big - 1 + small) * length / 2;
        } else {
            int ones = length - (big - 1);
            return (long) big * (big - 1) / 2 + ones;
        }
    }
};
```

```c
long cal(int big, int length) {
    if (length + 1 < big) {
        int small = big - length;
        return (long) (big - 1 + small) * length / 2;
    } else {
        int ones = length - (big - 1);
        return (long) big * (big - 1) / 2 + ones;
    }
}

bool valid(int mid, int n, int index, int maxSum) {
    int left = index;
    int right = n - index - 1;
    return mid + cal(mid, left) + cal(mid, right) <= maxSum;
}

int maxValue(int n, int index, int maxSum) {
    int left = 1, right = maxSum;
    while (left < right) {
        int mid = (left + right + 1) / 2;
        if (valid(mid, n, index, maxSum)) {
            left = mid;
        } else {
            right = mid - 1;
        }
    }
    return left;
}
```

```javascript
var maxValue = function(n, index, maxSum) {
    let left = 1, right = maxSum;
    while (left < right) {
        const mid = Math.floor((left + right + 1) / 2);
        if (valid(mid, n, index, maxSum)) {
            left = mid;
        } else {
            right = mid - 1;
        }
    }
    return left;
}

const valid = (mid, n, index, maxSum) => {
    let left = index;
    let right = n - index - 1;
    return mid + cal(mid, left) + cal(mid, right) <= maxSum;
}

const cal = (big, length) => {
    if (length + 1 < big) {
        const small = big - length;
        return Math.floor((big - 1 + small) * length / 2);
    } else {
        const ones = length - (big - 1);
        return Math.floor(big * (big - 1) / 2) + ones;
    }
};
```

```go
func f(big, length int) int {
    if length == 0 {
        return 0
    }
    if length <= big {
        return (2*big + 1 - length) * length / 2
    }
    return (big+1)*big/2 + length - big
}

func maxValue(n, index, maxSum int) int {
    return sort.Search(maxSum, func(mid int) bool {
        left := index
        right := n - index - 1
        return mid+f(mid, left)+f(mid, right) >= maxSum
    })
}
```

**复杂度分析**

-   时间复杂度：$O(\lg (maxSum))$。二分搜索上下界的差为 $maxSum$。
-   空间复杂度：$O(1)$，仅需要常数空间。
