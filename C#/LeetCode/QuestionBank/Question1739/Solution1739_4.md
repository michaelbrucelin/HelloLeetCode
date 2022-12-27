#### [方法三：解方程](https://leetcode.cn/problems/building-boxes/solutions/2030450/fang-zhi-he-zi-by-leetcode-solution-7ah2/)

**思路与算法**

由方法二可知，我们要找到最小的 $i$ 满足 $g(i) \ge n$，其中 $g(i) = \frac{i \times (i + 1) \times (i + 2)}{6}$。因为有 $i^3 \lt i \times (i + 1) \times (i + 2) \lt (i + 1)^3$ 成立， 所以有 $\frac{i^3}{6} \lt g(i) \lt \frac{(i + 1)^3}{6}$。

因此，我们先求得 $i = \lfloor \sqrt[3]{6 \times n} \rfloor$，如果 $g(i) \lt n$，则将 $i$ 加一后就是我们要求的 $i$。

将 $n$ 减去 $g(i−1)$，然后求解 $j$：

$f(j) = \frac{j \times (j + 1)}{2} \ge n$

化解后可得 $j \ge \lceil \frac{\sqrt{8\times n + 1} - 1}{2} \rceil$。

得到正确的 $i$ 和 $j$ 之后，答案为 $\frac{(i - 1) \times i}{2} + j$。

```cpp
class Solution {
public:
    int g(int x) {
        return (long long) x * (x + 1) * (x + 2) / 6;
    }

    int minimumBoxes(int n) {
        int i = pow(6.0 * n, 1.0 / 3);
        if (g(i) < n) {
            i++;
        }
        n -= g(i - 1);
        int j = ceil(1.0 * (sqrt((long long) 8 * n + 1) - 1) / 2);
        return (i - 1) * i / 2 + j;
    }
};
```

```java
class Solution {
    public int minimumBoxes(int n) {
        int i = (int) Math.pow(6.0 * n, 1.0 / 3);
        if (g(i) < n) {
            i++;
        }
        n -= g(i - 1);
        int j = (int) Math.ceil(1.0 * (Math.sqrt((long) 8 * n + 1) - 1) / 2);
        return (i - 1) * i / 2 + j;
    }

    public long g(int x) {
        return (long) x * (x + 1) * (x + 2) / 6;
    }
}
```

```c#
public class Solution {
    public int MinimumBoxes(int n) {
        int i = (int) Math.Pow(6.0 * n, 1.0 / 3);
        if (G(i) < n) {
            i++;
        }
        n = (int) (n - G(i - 1));
        int j = (int) Math.Ceiling(1.0 * (Math.Sqrt((long) 8 * n + 1) - 1) / 2);
        return (i - 1) * i / 2 + j;
    }

    public long G(int x) {
        return (long) x * (x + 1) * (x + 2) / 6;
    }
}
```

```c
int g(int x) {
    return (long long) x * (x + 1) * (x + 2) / 6;
}

int minimumBoxes(int n) {
    int i = pow(6.0 * n, 1.0 / 3);
    if (g(i) < n) {
        i++;
    }
    n -= g(i - 1);
    int j = ceil(1.0 * (sqrt((long long) 8 * n + 1) - 1) / 2);
    return (i - 1) * i / 2 + j;
}
```

```javascript
var minimumBoxes = function(n) {
    let i = Math.floor(Math.pow(6.0 * n, 1.0 / 3));
    if (g(i) < n) {
        i++;
    }
    n -= g(i - 1);
    const j = Math.floor(Math.ceil(1.0 * (Math.sqrt(8 * n + 1) - 1) / 2));
    return (i - 1) * i / 2 + j;
}

const g = (x) => {
    return x * (x + 1) * (x + 2) / 6;
};
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
