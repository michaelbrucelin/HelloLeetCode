### [打家劫舍 IV](https://leetcode.cn/problems/house-robber-iv/solutions/2441849/da-jia-jie-she-iv-by-leetcode-solution-n93j/)

#### 方法一：二分查找

题目需要获取窃取至少 $k$ 间房屋时小偷的最小窃取能力，属于常见的最小化最大值问题。假设小偷偷取的房屋的最大金额为 $y$，显然 $y \in [nums_{\min}, nums_{\max}]$。记 $f(y)$ 为在最大金额 $y$ 的限制下，小偷可以偷取的最大房屋数目，$f(y)$ 的计算方式为：

> 记当前偷取的房屋数目为 $count$，遍历数组 $nums$，假设当前遍历的房屋的金额为 $x$，如果 $x \le y$ 成立，且上一遍历的房屋没有被偷取，那么令偷取的房屋数目 $count$ 加 $1$，表示该房屋被偷取。 遍历结束后 $f(y) = count$，显然 $f(y)$ 是非递减函数。

那么我们可以使用二分查找的方法，找到满足 $f(y) \ge k$ 的最小 $y$，即题目所求的小偷最小窃取能力。具体二分查找算法如下：

1.  初始时 $⁡lower = nums_{\min}$，$⁡upper = nums_{\max}$。
2.  令 $middle = \Big \lfloor \dfrac{lower + upper}{2} \Big \rfloor$，如果 $f(middle) \ge k$，那么 $upper = middle - 1$；否则 $lower = middle + 1$。
3.  当 $lower \le upper$ 时，继续执行步骤 $2$；否则返回 $lower$ 为结果。

```cpp
class Solution {
public:
    int minCapability(vector<int>& nums, int k) {
        int lower = *min_element(nums.begin(), nums.end());
        int upper = *max_element(nums.begin(), nums.end());
        while (lower <= upper) {
            int middle = (lower + upper) / 2;
            int count = 0;
            bool visited = false;
            for (int x : nums) {
                if (x <= middle && !visited) {
                    count++;
                    visited = true;
                } else {
                    visited = false;
                }
            }
            if (count >= k) {
                upper = middle - 1;
            } else {
                lower = middle + 1;
            }
        }
        return lower;
    }
};
```

```java
class Solution {
    public int minCapability(int[] nums, int k) {
        int lower = Arrays.stream(nums).min().getAsInt();
        int upper = Arrays.stream(nums).max().getAsInt();
        while (lower <= upper) {
            int middle = (lower + upper) / 2;
            int count = 0;
            boolean visited = false;
            for (int x : nums) {
                if (x <= middle && !visited) {
                    count++;
                    visited = true;
                } else {
                    visited = false;
                }
            }
            if (count >= k) {
                upper = middle - 1;
            } else {
                lower = middle + 1;
            }
        }
        return lower;
    }
}
```

```csharp
public class Solution {
    public int MinCapability(int[] nums, int k) {
        int lower = nums.Min();
        int upper = nums.Max();
        while (lower <= upper) {
            int middle = (lower + upper) / 2;
            int count = 0;
            bool visited = false;
            foreach (int x in nums) {
                if (x <= middle && !visited) {
                    count++;
                    visited = true;
                } else {
                    visited = false;
                }
            }
            if (count >= k) {
                upper = middle - 1;
            } else {
                lower = middle + 1;
            }
        }
        return lower;
    }
}
```

```go
func max(a, b int) int {
    if a < b {
        return b
    }
    return a
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}

func minCapability(nums []int, k int) int {
    lower, upper := nums[0], nums[0]
    for _, x := range nums {
        lower = min(lower, x)
        upper = max(upper, x)
    }

    for lower <= upper {
        middle := (lower + upper) / 2
        count, visited := 0, false
        for _, x := range nums {
            if x <= middle && !visited {
                count, visited = count + 1, true
            } else {
                visited = false
            }
        }
        if count >= k {
            upper = middle - 1
        } else {
            lower = middle + 1
        }
    }
    return lower
}
```

```python
class Solution:
    def minCapability(self, nums: List[int], k: int) -> int:
        def f(y : int) -> int:
            count, visited = 0, False
            for x in nums:
                if x <= y and not visited:
                    count, visited = count + 1, True
                else:
                    visited = False
            return count
        return bisect_left(range(min(nums), max(nums)), k, key = f) + min(nums)
```

```c
int minCapability(int* nums, int numsSize, int k){
    int lower = nums[0], upper = nums[0];
    for (int i = 0; i < numsSize; i++) {
        lower = lower > nums[i] ? nums[i] : lower;
        upper = upper < nums[i] ? nums[i] : upper;
    }
    while (lower <= upper) {
        int middle = (lower + upper) / 2;
        int count = 0;
        bool visited = false;
        for (int i = 0; i < numsSize; i++) {
            if (nums[i] <= middle && !visited) {
                count++;
                visited = true;
            } else {
                visited = false;
            }
        }
        if (count >= k) {
            upper = middle - 1;
        } else {
            lower = middle + 1;
        }
    }
    return lower;
}
```

```javascript
var minCapability = function(nums, k) {
    let lower = Math.min(...nums);
    let upper = Math.max(...nums);
    while (lower <= upper) {
        const middle = Math.floor((lower + upper) / 2);
        let count = 0;
        let visited = false;
        for (const x of nums) {
            if (x <= middle && !visited) {
                count++;
                visited = true;
            } else {
                visited = false;
            }
        }
        if (count >= k) {
            upper = middle - 1;
        } else {
            lower = middle + 1;
        }
    }
    return lower;
};
```

**复杂度分析**

-   时间复杂度：$O(n \log T)$，其中 $n$ 是数组 $nums$ 的长度，$T$ 是数组最大值与最小值之差。二分查找的次数为 $O(\log T)$，每次查找需要 $O(n)$。
-   空间复杂度：$O(1)$。
