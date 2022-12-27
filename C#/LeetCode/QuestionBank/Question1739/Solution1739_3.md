#### [方法二：二分查找](https://leetcode.cn/problems/building-boxes/solutions/2030450/fang-zhi-he-zi-by-leetcode-solution-7ah2/)

**思路与算法**

为了方便描述，我们设 $f(x) = \frac{x \times (x + 1)}{2}$ 表示在同一层中连续放置 $x$ 个接触地面的盒子时，总共可以增加多少个可放置盒子。由于第 $i$ 层最多可以放置 $i$ 个接触地面的盒子，所以第 $i$ 层放满可以增加 $f(i)$ 个可放置盒子。

因此，前 $i$ 层可以放置的盒子总数为 $g(i) = \sum_{k=1}^i f(k) = \frac{i \times (i + 1) \times (i + 2)}{6}$。

由于 $g(i)$ 具有单调性，我们可以通过二分查找来找到 $i$，使得前 $i$ 层的数量足够容纳 $n$ 个盒子。与方法一中描述的一样，我们将 $n$ 分解为完整的 $i - 1$ 层和可能不完整的第 $i$ 层。因此，需要找到一个最小的 $i$ 使得：$g(i) \ge n$。

然后由于 $f(j)$ 也具有单调性，对于 $j$ 的求解仍然可以使用二分查找，我们要找到最小的 $j$ 使得 $f(j) \ge n - g(i - 1)$。

得到正确的 $i$ 和 $j$ 之后，答案为 $\frac{(i - 1) \times i}{2} + j$。

需要注意在选取二分查找初始边界时，左边界可以选 $1$，右边界为了防止计算溢出，可以选择 $\min(n, 100000)$ 作为一个保守值。因为 $n \le 10^9$，答案不会超过 $100000$。

有关二分查找的内容，读者同学可以参考：[「在排序数组中查找元素的第一个和最后一个位置」](https://leetcode.cn/problems/find-first-and-last-position-of-element-in-sorted-array/solutions/504484/zai-pai-xu-shu-zu-zhong-cha-zhao-yuan-su-de-di-3-4/)。

```cpp
class Solution {
public:
    int minimumBoxes(int n) {
        int i = 0, j = 0;
        int low = 1, high = min(n, 100000);
        while (low < high) {
            int mid = (low + high) >> 1;
            long long sum = (long long) mid * (mid + 1) * (mid + 2) / 6;
            if (sum >= n) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        i = low;
        n -= (long long) (i - 1) * i * (i + 1) / 6;
        low = 1, high = i;
        while (low < high) {
            int mid = (low + high) >> 1;
            long long sum = (long long) mid * (mid + 1) / 2;
            if (sum >= n) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        j = low;
        return (i - 1) * i / 2 + j;
    }
};
```

```java
class Solution {
    public int minimumBoxes(int n) {
        int i = 0, j = 0;
        int low = 1, high = Math.min(n, 100000);
        while (low < high) {
            int mid = (low + high) >> 1;
            long sum = (long) mid * (mid + 1) * (mid + 2) / 6;
            if (sum >= n) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        i = low;
        n -= (long) (i - 1) * i * (i + 1) / 6;
        low = 1;
        high = i;
        while (low < high) {
            int mid = (low + high) >> 1;
            long sum = (long) mid * (mid + 1) / 2;
            if (sum >= n) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        j = low;
        return (i - 1) * i / 2 + j;
    }
}
```

```c#
public class Solution {
    public int MinimumBoxes(int n) {
        int i = 0, j = 0;
        int low = 1, high = Math.Min(n, 100000);
        while (low < high) {
            int mid = (low + high) >> 1;
            long sum = (long) mid * (mid + 1) * (mid + 2) / 6;
            if (sum >= n) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        i = low;
        n = (int) (n - (long) (i - 1) * i * (i + 1) / 6);
        low = 1;
        high = i;
        while (low < high) {
            int mid = (low + high) >> 1;
            long sum = (long) mid * (mid + 1) / 2;
            if (sum >= n) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        j = low;
        return (i - 1) * i / 2 + j;
    }
}
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int minimumBoxes(int n) {
    int i = 0, j = 0;
    int low = 1, high = MIN(n, 100000);
    while (low < high) {
        int mid = (low + high) >> 1;
        long long sum = (long long) mid * (mid + 1) * (mid + 2) / 6;
        if (sum >= n) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    i = low;
    n -= (long long) (i - 1) * i * (i + 1) / 6;
    low = 1, high = i;
    while (low < high) {
        int mid = (low + high) >> 1;
        long long sum = (long long) mid * (mid + 1) / 2;
        if (sum >= n) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    j = low;
    return (i - 1) * i / 2 + j;
}
```

```javascript
var minimumBoxes = function(n) {
    let i = 0, j = 0;
    let low = 1, high = Math.min(n, 100000);
    while (low < high) {
        const mid = (low + high) >> 1;
        const sum = mid * (mid + 1) * (mid + 2) / 6;
        if (sum >= n) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    i = low;
    n -= (i - 1) * i * (i + 1) / 6;
    low = 1;
    high = i;
    while (low < high) {
        const mid = (low + high) >> 1;
        const sum = mid * (mid + 1) / 2;
        if (sum >= n) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    j = low;
    return (i - 1) * i / 2 + j;
};
```

**复杂度分析**

-   时间复杂度：$O(\log n)$，其中 $n$ 是盒子数。
-   空间复杂度：$O(1)$。
