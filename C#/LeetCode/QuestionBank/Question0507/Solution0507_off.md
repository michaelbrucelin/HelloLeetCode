#### [方法一：枚举](https://leetcode.cn/problems/perfect-number/solutions/1179051/wan-mei-shu-by-leetcode-solution-d5pw/)

我们可以枚举 $num$ 的所有真因子，累加所有真因子之和，记作 $sum$。若 $sum=num$ 则返回 $true$，否则返回 $false$。

在枚举时，我们只需要枚举不超过 $\sqrt {num}$ 的数。这是因为如果 $num$ 有一个大于 $\sqrt {num}$ 的因数 $d$，那么它一定有一个小于 $\sqrt {num}$ 的因数 $\dfrac{num}{d}$。

在枚举时，若找到了一个因数 $d$，那么就找到了因数 $\dfrac{num}{d}$。注意当 $d\cdot d=num$ 时这两个因数相同，此时不能重复计算。

```python
class Solution:
    def checkPerfectNumber(self, num: int) -> bool:
        if num == 1:
            return False

        sum = 1
        d = 2
        while d * d <= num:
            if num % d == 0:
                sum += d
                if d * d < num:
                    sum += num / d
            d += 1
        return sum == num
```

```cpp
class Solution {
public:
    bool checkPerfectNumber(int num) {
        if (num == 1) {
            return false;
        }

        int sum = 1;
        for (int d = 2; d * d <= num; ++d) {
            if (num % d == 0) {
                sum += d;
                if (d * d < num) {
                    sum += num / d;
                }
            }
        }
        return sum == num;
    }
};
```

```java
class Solution {
    public boolean checkPerfectNumber(int num) {
        if (num == 1) {
            return false;
        }

        int sum = 1;
        for (int d = 2; d * d <= num; ++d) {
            if (num % d == 0) {
                sum += d;
                if (d * d < num) {
                    sum += num / d;
                }
            }
        }
        return sum == num;
    }
}
```

```csharp
public class Solution {
    public bool CheckPerfectNumber(int num) {
        if (num == 1) {
            return false;
        }

        int sum = 1;
        for (int d = 2; d * d <= num; ++d) {
            if (num % d == 0) {
                sum += d;
                if (d * d < num) {
                    sum += num / d;
                }
            }
        }
        return sum == num;
    }
}
```

```go
func checkPerfectNumber(num int) bool {
    if num == 1 {
        return false
    }

    sum := 1
    for d := 2; d*d <= num; d++ {
        if num%d == 0 {
            sum += d
            if d*d < num {
                sum += num / d
            }
        }
    }
    return sum == num
}
```

```c
bool checkPerfectNumber(int num){
    if (num == 1) {
        return false;
    }

    int sum = 1;
    for (int d = 2; d * d <= num; ++d) {
        if (num % d == 0) {
            sum += d;
            if (d * d < num) {
                sum += num / d;
            }
        }
    }
    return sum == num;
}
```

```javascript
var checkPerfectNumber = function(num) {
    if (num === 1) {
        return false;
    }

    let sum = 1;
    for (let d = 2; d * d <= num; ++d) {
        if (num % d === 0) {
            sum += d;
            if (d * d < num) {
                sum += Math.floor(num / d);
            }
        }
    }
    return sum === num;
};
```

**复杂度分析**

-   时间复杂度：$O(\sqrtnum)$。
-   空间复杂度：$O(1)$。
