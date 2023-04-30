#### [方法三：一次遍历](https://leetcode.cn/problems/third-maximum-number/solutions/1032401/di-san-da-de-shu-by-leetcode-solution-h3sp/)

我们可以遍历数组，并用三个变量 $a$、$b$ 和 $c$ 来维护数组中的最大值、次大值和第三大值，以模拟方法二中的插入和删除操作。为方便编程实现，我们将其均初始化为小于数组最小值的元素，视作「无穷小」，比如 $-2^{63}$ 等。

遍历数组，对于数组中的元素 $num$：

-   若 $num>a$，我们将 $c$ 替换为 $b$，$b$ 替换为 $a$，$a$ 替换为 $num$，这模拟了将 $num$ 插入有序集合，并删除有序集合中的最小值的过程；
-   若 $a>num>b$，类似地，我们将 $c$ 替换为 $b$，$b$ 替换为 $num$，$a$ 保持不变；
-   若 $b>num>c$，类似地，我们将 $c$ 替换为 $num$，$a$ 和 $b$ 保持不变；
-   其余情况不做处理。

遍历结束后，若 $c$ 仍然为 $-2^{63}$，则说明数组中不存在三个或三个以上的不同元素，即第三大的数不存在，返回 $a$，否则返回 $c$。

```python
class Solution:
    def thirdMax(self, nums: List[int]) -> int:
        a, b, c = float('-inf'), float('-inf'), float('-inf')
        for num in nums:
            if num > a:
                a, b, c = num, a, b
            elif a > num > b:
                b, c = num, b
            elif b > num > c:
                c = num
        return a if c == float('-inf') else c
```

```cpp
class Solution {
public:
    int thirdMax(vector<int> &nums) {
        long a = LONG_MIN, b = LONG_MIN, c = LONG_MIN;
        for (long num : nums) {
            if (num > a) {
                c = b;
                b = a;
                a = num;
            } else if (a > num && num > b) {
                c = b;
                b = num;
            } else if (b > num && num > c) {
                c = num;
            }
        }
        return c == LONG_MIN ? a : c;
    }
};
```

```java
class Solution {
    public int thirdMax(int[] nums) {
        long a = Long.MIN_VALUE, b = Long.MIN_VALUE, c = Long.MIN_VALUE;
        for (long num : nums) {
            if (num > a) {
                c = b;
                b = a;
                a = num;
            } else if (a > num && num > b) {
                c = b;
                b = num;
            } else if (b > num && num > c) {
                c = num;
            }
        }
        return c == Long.MIN_VALUE ? (int) a : (int) c;
    }
}
```

```csharp
public class Solution {
    public int ThirdMax(int[] nums) {
        long a = long.MinValue, b = long.MinValue, c = long.MinValue;
        foreach (long num in nums) {
            if (num > a) {
                c = b;
                b = a;
                a = num;
            } else if (a > num && num > b) {
                c = b;
                b = num;
            } else if (b > num && num > c) {
                c = num;
            }
        }
        return c == long.MinValue ? (int) a : (int) c;
    }
}
```

```go
func thirdMax(nums []int) int {
    a, b, c := math.MinInt64, math.MinInt64, math.MinInt64
    for _, num := range nums {
        if num > a {
            a, b, c = num, a, b
        } else if a > num && num > b {
            b, c = num, b
        } else if b > num && num > c {
            c = num
        }
    }
    if c == math.MinInt64 {
        return a
    }
    return c
}
```

```javascript
var thirdMax = function(nums) {
    let a = -Number.MAX_VALUE, b = -Number.MAX_VALUE, c = -Number.MAX_VALUE;
    for (const num of nums) {
        if (num > a) {
            c = b;
            b = a;
            a = num;
        } else if (a > num && num > b) {
            c = b;
            b = num;
        } else if (b > num && num > c) {
            c = num;
        }
    }
    return c === -Number.MAX_VALUE ? a : c;
};
```

另一种不依赖元素范围的做法是，将 $a$、$b$ 和 $c$ 初始化为空指针或空对象，视作「无穷小」，并在比较大小前先判断是否为空指针或空对象。遍历结束后，若 $c$ 为空，则说明第三大的数不存在，返回 $a$，否则返回 $c$。

```python
class Solution:
    def thirdMax(self, nums: List[int]) -> int:
        a, b, c = None, None, None
        for num in nums:
            if a is None or num > a:
                a, b, c = num, a, b
            elif a > num and (b is None or num > b):
                b, c = num, b
            elif b is not None and b > num and (c is None or num > c):
                c = num
        return a if c is None else c
```

```cpp
class Solution {
public:
    int thirdMax(vector<int> &nums) {
        int *a = nullptr, *b = nullptr, *c = nullptr;
        for (int &num : nums) {
            if (a == nullptr || num > *a) {
                c = b;
                b = a;
                a = &num;
            } else if (*a > num && (b == nullptr || num > *b)) {
                c = b;
                b = &num;
            } else if (b != nullptr && *b > num && (c == nullptr || num > *c)) {
                c = &num;
            }
        }
        return c == nullptr ? *a : *c;
    }
};
```

```java
class Solution {
    public int thirdMax(int[] nums) {
        Integer a = null, b = null, c = null;
        for (int num : nums) {
            if (a == null || num > a) {
                c = b;
                b = a;
                a = num;
            } else if (a > num && (b == null || num > b)) {
                c = b;
                b = num;
            } else if (b != null && b > num && (c == null || num > c)) {
                c = num;
            }
        }
        return c == null ? a : c;
    }
}
```

```csharp
public class Solution {
    public int ThirdMax(int[] nums) {
        int? a = null, b = null, c = null;
        foreach (int num in nums) {
            if (a == null || num > a) {
                c = b;
                b = a;
                a = num;
            } else if (a > num && (b == null || num > b)) {
                c = b;
                b = num;
            } else if (b != null && b > num && (c == null || num > c)) {
                c = num;
            }
        }
        return c == null ? (int) a : (int) c;
    }
}
```

```go
func thirdMax(nums []int) int {
    var a, b, c *int
    for _, num := range nums {
        num := num
        if a == nil || num > *a {
            a, b, c = &num, a, b
        } else if *a > num && (b == nil || num > *b) {
            b, c = &num, b
        } else if b != nil && *b > num && (c == nil || num > *c) {
            c = &num
        }
    }
    if c == nil {
        return *a
    }
    return *c
}
```

```javascript
var thirdMax = function(nums) {
    let a = null, b = null, c = null;
    for (const num of nums) {
        if (a === null || num > a) {
            c = b;
            b = a;
            a = num;
        } else if (a > num && (b === null || num > b)) {
            c = b;
            b = num;
        } else if (b !== null && b > num && (c === null || num > c)) {
            c = num;
        }
    }
    return c === null ? a : c;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。
-   空间复杂度：$O(1)$。
