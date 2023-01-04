#### [方法二：数学推导](https://leetcode.cn/problems/maximum-value-at-a-given-index-in-a-bounded-array/solutions/2042360/you-jie-shu-zu-zhong-zhi-ding-xia-biao-c-aav4/)

**思路**

仍然按照方法一的贪心思路，根据方法一的推导，$nums[index]$ 左边或者右边的元素和，要分情况讨论。记 $nums[index]$ 为 $big$，它离数组的某个边界的距离为 $length$。当 $big \leq length+1$ 时，还未到达边界附近时，元素值就已经降为 $1$，并保持为 $1$ 直到到达数组边界，此时这部分的元素和为 $\dfrac{big^2-3big}{2}+length+1$。否则，元素会呈现出梯形的形状，此时这部分的元素和为 $\dfrac{(2big-length-1) \times length}{2}$。

$numsSum$ 由三部分组成，$nums[index]$，$nums[index]$ 左边的部分之和，和 $nums[index]$ 右边的部分之和。记 $nums[index]$ 左边的元素个数为 $left=index$，右边的元素个数为 $right=n−1−index$。根据对称性，不妨设 $left \leq right$。这样一来，$numsSum$ 的组成可以用三种情况来表示。即:

-   $big \leq left+1$，$numsSum = \dfrac{big^2-3big}{2}+left+1 + big + \dfrac{big^2-3big}{2}+right+1$
-   $left+1 \lt big \leq right+1$, $numsSum = \dfrac{(2big-left-1) \times left}{2} + big + \dfrac{big^2-3big}{2}+right+1$
-   $right+1 \lt big$, $numsSum = \dfrac{(2big-left-1) \times left}{2} + big + \dfrac{(2big-right-1) \times right}{2}$

对于前两种情况，我们可以分别求出上限，如果上限不超过 $maxSum$，则可以通过解一元二次方程来求出 $big$。否则需要根据第三种情况解一元一次方程来求 $big$。

**代码**

```python
class Solution:
    def maxValue(self, n: int, index: int, maxSum: int) -> int: 
        left = index
        right = n - index - 1
        if left > right:
            left, right = right, left

        upper = ((left + 1) ** 2 - 3 * (left + 1)) // 2 + left + 1 + (left + 1) + ((left + 1) ** 2 - 3 * (left + 1)) // 2 + right + 1
        if upper >= maxSum:
            a = 1
            b = -2
            c = left + right + 2 - maxSum
            return floor(((-b + (b ** 2 - 4 * a * c) ** 0.5) / (2 * a)))

        upper = (2 * (right + 1) - left - 1) * left // 2 + (right + 1) + ((right + 1) ** 2 - 3 * (right + 1)) // 2 + right + 1
        if upper >= maxSum:
            a = 1/2
            b = left + 1 - 3/2
            c = right + 1 + (-left - 1) * left / 2 - maxSum
            return floor(((-b + (b ** 2 - 4 * a * c) ** 0.5) / (2 * a)))

        else:
            a = left + right + 1
            b = (-left ** 2 - left - right ** 2 - right) / 2 - maxSum
            return floor(-b / a)
```

```java
class Solution {
    public int maxValue(int n, int index, int maxSum) {
        double left = index;
        double right = n - index - 1;
        if (left > right) {
            double temp = left;
            left = right;
            right = temp;
        }

        double upper = ((double) (left + 1) * (left + 1) - 3 * (left + 1)) / 2 + left + 1 + (left + 1) + ((left + 1) * (left + 1) - 3 * (left + 1)) / 2 + right + 1;
        if (upper >= maxSum) {
            double a = 1;
            double b = -2;
            double c = left + right + 2 - maxSum;
            return (int) Math.floor((-b + Math.sqrt(b * b - 4 * a * c)) / (2 * a));
        }

        upper = ((double) 2 * (right + 1) - left - 1) * left / 2 + (right + 1) + ((right + 1) * (right + 1) - 3 * (right + 1)) / 2 + right + 1;
        if (upper >= maxSum) {
            double a = 1.0 / 2;
            double b = left + 1 - 3.0 / 2;
            double c = right + 1 + (-left - 1) * left / 2 - maxSum;
            return (int) Math.floor((-b + Math.sqrt(b * b - 4 * a * c)) / (2 * a));
        } else {
            double a = left + right + 1;;
            double b = (-left * left - left - right * right - right) / 2 - maxSum;
            return (int) Math.floor(-b / a);
        }
    }
}
```

```csharp
public class Solution {
    public int MaxValue(int n, int index, int maxSum) {
        double left = index;
        double right = n - index - 1;
        if (left > right) {
            double temp = left;
            left = right;
            right = temp;
        }

        double upper = ((double) (left + 1) * (left + 1) - 3 * (left + 1)) / 2 + left + 1 + (left + 1) + ((left + 1) * (left + 1) - 3 * (left + 1)) / 2 + right + 1;
        if (upper >= maxSum) {
            double a = 1;
            double b = -2;
            double c = left + right + 2 - maxSum;
            return (int) Math.Floor((-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a));
        }

        upper = ((double) 2 * (right + 1) - left - 1) * left / 2 + (right + 1) + ((right + 1) * (right + 1) - 3 * (right + 1)) / 2 + right + 1;
        if (upper >= maxSum) {
            double a = 1.0 / 2;
            double b = left + 1 - 3.0 / 2;
            double c = right + 1 + (-left - 1) * left / 2 - maxSum;
            return (int) Math.Floor((-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a));
        } else {
            double a = left + right + 1;;
            double b = (-left * left - left - right * right - right) / 2 - maxSum;
            return (int) Math.Floor(-b / a);
        }
    }
}
```

```cpp
class Solution {
public:
    int maxValue(int n, int index, int maxSum) {
        double left = index;
        double right = n - index - 1;
        if (left > right) {
            double temp = left;
            left = right;
            right = temp;
        }

        double upper = ((double) (left + 1) * (left + 1) - 3 * (left + 1)) / 2 + left + 1 + (left + 1) + ((left + 1) * (left + 1) - 3 * (left + 1)) / 2 + right + 1;
        if (upper >= maxSum) {
            double a = 1;
            double b = -2;
            double c = left + right + 2 - maxSum;
            return (int) floor((-b + sqrt(b * b - 4 * a * c)) / (2 * a));
        }

        upper = ((double) 2 * (right + 1) - left - 1) * left / 2 + (right + 1) + ((right + 1) * (right + 1) - 3 * (right + 1)) / 2 + right + 1;
        if (upper >= maxSum) {
            double a = 1.0 / 2;
            double b = left + 1 - 3.0 / 2;
            double c = right + 1 + (-left - 1) * left / 2 - maxSum;
            return (int) floor((-b + sqrt(b * b - 4 * a * c)) / (2 * a));
        } else {
            double a = left + right + 1;;
            double b = (-left * left - left - right * right - right) / 2 - maxSum;
            return (int) floor(-b / a);
        }
    }
};
```

```c
int maxValue(int n, int index, int maxSum) {
    double left = index;
    double right = n - index - 1;
    if (left > right) {
        double temp = left;
        left = right;
        right = temp;
    }

    double upper = ((double) (left + 1) * (left + 1) - 3 * (left + 1)) / 2 + left + 1 + (left + 1) + ((left + 1) * (left + 1) - 3 * (left + 1)) / 2 + right + 1;
    if (upper >= maxSum) {
        double a = 1;
        double b = -2;
        double c = left + right + 2 - maxSum;
        return (int) floor((-b + sqrt(b * b - 4 * a * c)) / (2 * a));
    }

    upper = ((double) 2 * (right + 1) - left - 1) * left / 2 + (right + 1) + ((right + 1) * (right + 1) - 3 * (right + 1)) / 2 + right + 1;
    if (upper >= maxSum) {
        double a = 1.0 / 2;
        double b = left + 1 - 3.0 / 2;
        double c = right + 1 + (-left - 1) * left / 2 - maxSum;
        return (int) floor((-b + sqrt(b * b - 4 * a * c)) / (2 * a));
    } else {
        double a = left + right + 1;;
        double b = (-left * left - left - right * right - right) / 2 - maxSum;
        return (int) floor(-b / a);
    }
}
```

```javascript
var maxValue = function(n, index, maxSum) {
    let left = index;
    let right = n - index - 1;
    if (left > right) {
        let temp = left;
        left = right;
        right = temp;
    }

    let upper = ((left + 1) * (left + 1) - 3 * (left + 1)) / 2 + left + 1 + (left + 1) + ((left + 1) * (left + 1) - 3 * (left + 1)) / 2 + right + 1;
    if (upper >= maxSum) {
        let a = 1;
        let b = -2;
        let c = left + right + 2 - maxSum;
        return Math.floor((-b + Math.sqrt(b * b - 4 * a * c)) / (2 * a));
    }

    upper = (2 * (right + 1) - left - 1) * left / 2 + (right + 1) + ((right + 1) * (right + 1) - 3 * (right + 1)) / 2 + right + 1;
    if (upper >= maxSum) {
        let a = 1.0 / 2;
        let b = left + 1 - 3.0 / 2;
        let c = right + 1 + (-left - 1) * left / 2 - maxSum;
        return Math.floor((-b + Math.sqrt(b * b - 4 * a * c)) / (2 * a));
    } else {
        let a = left + right + 1;;
        let b = (-left * left - left - right * right - right) / 2 - maxSum;
        return Math.floor(-b / a);
    }
};
```

```go
func maxValue(n, index, maxSum int) int {
    left := index
    right := n - index - 1
    if left > right {
        left, right = right, left
    }

    upper := ((left+1)*(left+1)-3*(left+1))/2 + left + 1 + (left + 1) + ((left+1)*(left+1)-3*(left+1))/2 + right + 1
    if upper >= maxSum {
        a := 1.0
        b := -2.0
        c := float64(left + right + 2 - maxSum)
        return int((-b + math.Sqrt(b*b-4*a*c)) / (2 * a))
    }

    upper = (2*(right+1)-left-1)*left/2 + (right + 1) + ((right+1)*(right+1)-3*(right+1))/2 + right + 1
    if upper >= maxSum {
        a := 1.0 / 2
        b := float64(left) + 1 - 3.0/2
        c := float64(right + 1 + (-left-1)*left/2.0 - maxSum)
        return int((-b + math.Sqrt(b*b-4*a*c)) / (2 * a))
    } else {
        a := float64(left + right + 1)
        b := float64(-left*left-left-right*right-right)/2 - float64(maxSum)
        return int(-b / a)
    }
}
```

**复杂度分析**

-   时间复杂度：$O(1)$，仅使用常数时间。
-   空间复杂度：$O(1)$，仅使用常数空间。
