#### [方法一：枚举到较小值](https://leetcode.cn/problems/number-of-common-factors/solutions/2207533/gong-yin-zi-de-shu-mu-by-leetcode-soluti-u9sl/)

**思路与算法**

由于 $a$ 和 $b$ 的公因子一定不会超过 $a$ 和 $b$，因此我们只需要在 $[1, \min(a, b)]$ 中枚举 $x$，并判断 $x$ 是否为公因子即可。

**代码**

```cpp
class Solution {
public:
    int commonFactors(int a, int b) {
        int ans = 0;
        for (int x = 1; x <= min(a, b); ++x) {
            if (a % x == 0 && b % x == 0) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int commonFactors(int a, int b) {
        int ans = 0;
        for (int x = 1; x <= Math.min(a, b); ++x) {
            if (a % x == 0 && b % x == 0) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int CommonFactors(int a, int b) {
        int ans = 0;
        for (int x = 1; x <= Math.Min(a, b); ++x) {
            if (a % x == 0 && b % x == 0) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def commonFactors(self, a: int, b: int) -> int:
        ans = 0
        for x in range(1, min(a, b) + 1):
            if a % x == 0 and b % x == 0:
                ans += 1
        return ans
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int commonFactors(int a, int b) {
    int ans = 0;
    int c = MIN(a, b);
    for (int x = 1; x <= c; ++x) {
        if (a % x == 0 && b % x == 0) {
            ++ans;
        }
    }
    return ans;
}
```

```javascript
var commonFactors = function(a, b) {
    let ans = 0;
    for (let x = 1; x <= Math.min(a, b); ++x) {
        if (a % x === 0 && b % x === 0) {
            ++ans;
        }
    }
    return ans;
};
```

```go
func commonFactors(a int, b int) int {
    m := min(a, b)
    ans := 0
    for i := 1; i <= m; i++ {
        if a%i == 0 && b%i == 0 {
            ans++
        }
    }
    return ans
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是给定输入 $a$ 和 $b$ 的范围。
-   空间复杂度：$O(1)$。
