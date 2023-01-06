#### [方法二：数学](https://leetcode.cn/problems/count-integers-with-even-digit-sum/solutions/2045888/tong-ji-ge-wei-shu-zi-zhi-he-wei-ou-shu-rvqol/)

首先有两个简单的数学结论：
-   给定 $0 \le x \lt 10$，位于区间 $[0, x]$ 内的偶数个数为 $\left\lfloor \dfrac{x}{2} \right\rfloor + 1$，位于区间 $[0, x]$ 内的奇数个数为 $\left\lceil \dfrac{x}{2} \right\rceil$。
-   位于区间 $[0, 10)$ 的奇数和偶数的个数都是 $5$ 个。

我们将 $num$ 表示为 $10 \times y + x$ 的形式，其中 $0 \le x \lt 10$ 且 $y \ge 0$，那么位于区间 $[0, num]$ 的整数可以分为两个部分：
-   区间 $[10 \times y + 0, 10 \times y + x]$：
    -   如果 $y$ 的各位数字之和为偶数，那么该区间内各位数字之和为偶数的整数个数为 $\left\lfloor \dfrac{x}{2} \right\rfloor + 1$；
    -   如果 $y$ 的各位数字之和为奇数，那么该区间内各位数字之和为偶数的整数个数为 $\left\lceil \dfrac{x}{2} \right\rceil$。
-   区间 $[0, 10 \times y + 0)$：
    注意到该区间的数可以表示为 $10 \times t + g$ 的形式，其中 $0 \le t \lt y$ 且 $0 \le g \lt 10$。固定住 $t$ 时，如果 $t$ 的各位数字之和为偶数，那么 $g$ 为偶数的取值数目为 $5$，奇数时类似，因此该区间内的各位数字之和为偶数的整数个数为 $y \times 5$。

注意到上述区间中我们多计入了整数 $0$，因此结果应该是位于上述区间且各位数字之和为偶数的个数减 $1$。

```python
class Solution:
    def countEven(self, num: int) -> int:
        y, x = divmod(num, 10)
        ans = y * 5
        y_sum = 0
        while y:
            y_sum += y % 10
            y //= 10
        return ans + ((x + 1) // 2 - 1 if y_sum % 2 else x // 2)
```

```cpp
class Solution {
public:
    int countEven(int num) {
        int y = num / 10, x = num % 10;
        int res = y * 5, ySum = 0;
        while (y) {
            ySum += y % 10;
            y /= 10;
        }
        if (ySum % 2 == 0) {
            res += x / 2 + 1;
        } else {
            res += (x + 1) / 2;
        }
        return res - 1;
    }
};
```

```java
class Solution {
    public int countEven(int num) {
        int y = num / 10, x = num % 10;
        int res = y * 5, ySum = 0;
        while (y != 0) {
            ySum += y % 10;
            y /= 10;
        }
        if (ySum % 2 == 0) {
            res += x / 2 + 1;
        } else {
            res += (x + 1) / 2;
        }
        return res - 1;
    }
}
```

```csharp
public class Solution {
    public int CountEven(int num) {
        int y = num / 10, x = num % 10;
        int res = y * 5, ySum = 0;
        while (y != 0) {
            ySum += y % 10;
            y /= 10;
        }
        if (ySum % 2 == 0) {
            res += x / 2 + 1;
        } else {
            res += (x + 1) / 2;
        }
        return res - 1;
    }
}
```

```c
int countEven(int num) {
    int y = num / 10, x = num % 10;
    int res = y * 5, ySum = 0;
    while (y) {
        ySum += y % 10;
        y /= 10;
    }
    if (ySum % 2 == 0) {
        res += x / 2 + 1;
    } else {
        res += (x + 1) / 2;
    }
    return res - 1;
}
```

```javascript
var countEven = function(num) {
    let y = Math.floor(num / 10), x = num % 10;
    let res = y * 5, ySum = 0;
    while (y !== 0) {
        ySum += y % 10;
        y = Math.floor(y / 10);
    }
    if (ySum % 2 === 0) {
        res += Math.floor(x / 2) + 1;
    } else {
        res += Math.floor((x + 1) / 2);
    }
    return res - 1;
};
```

```go
func countEven(num int) int {
    y, x := num/10, num%10
    ans := y * 5
    ySum := 0
    for ; y > 0; y /= 10 {
        ySum += y % 10
    }
    if ySum%2 == 0 {
        ans += x / 2
    } else {
        ans += (x+1)/2 - 1
    }
    return ans
}
```

**复杂度分析**

-   时间复杂度：$O(\log num)$。
-   空间复杂度：$O(1)$。
