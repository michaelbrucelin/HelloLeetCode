#### [方法一：优化计算](https://leetcode.cn/problems/factorial-zeros-lcci/solutions/1396206/jie-cheng-wei-shu-by-leetcode-solution-991v/)

考虑 $[1,n]$ 中质因子 $p$ 的个数。

$[1,n]$ 中 $p$ 的倍数有 $n_1=\Big\lfloor\dfrac{n}{p}\Big\rfloor$ 个，这些数至少贡献出了 $n_1$ 个质因子 $p$。$p^2$ 的倍数有 $n_2=\Big\lfloor\dfrac{n}{p^2}\Big\rfloor$ 个，由于这些数已经是 $p$ 的倍数了，为了不重复统计 $p$ 的个数，我们仅考虑额外贡献的质因子个数，即这些数额外贡献了至少 $n_2$ 个质因子 $p$。

依此类推，$[1,n]$ 中质因子 $p$ 的个数为

$$\sum_{k=1}^{\infty} \Big\lfloor\dfrac{n}{p^k}\Big\rfloor$$

上式表明：

1.  $n$ 不变，$p$ 越大，质因子个数越少，因此 $[1,n]$ 中质因子 $5$ 的个数不会大于质因子 $2$ 的个数；
2.  $[1,n]$ 中质因子 $5$ 的个数为
    $$\sum_{k=1}^{\infty} \Big\lfloor\dfrac{n}{5^k}\Big\rfloor < \sum_{k=1}^{\infty} \dfrac{n}{5^k} = \dfrac{n}{4} = O(n)$$


代码实现时，由于

$$\Big\lfloor\dfrac{n}{5^k}\Big\rfloor = \Bigg\lfloor\dfrac{\Big\lfloor\dfrac{n}{5^{k-1}}\Big\rfloor}{5}\Bigg\rfloor$$

因此我们可以通过不断将 $n$ 除以 $5$，并累加每次除后的 $n$，来得到答案。

```python
class Solution:
    def trailingZeroes(self, n: int) -> int:
        ans = 0
        while n:
            n //= 5
            ans += n
        return ans
```

```cpp
class Solution {
public:
    int trailingZeroes(int n) {
        int ans = 0;
        while (n) {
            n /= 5;
            ans += n;
        }
        return ans;
    }
};
```

```java
class Solution {
    public int trailingZeroes(int n) {
        int ans = 0;
        while (n != 0) {
            n /= 5;
            ans += n;
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int TrailingZeroes(int n) {
        int ans = 0;
        while (n != 0) {
            n /= 5;
            ans += n;
        }
        return ans;
    }
}
```

```go
func trailingZeroes(n int) (ans int) {
    for n > 0 {
        n /= 5
        ans += n
    }
    return
}
```

```c
int trailingZeroes(int n) {
    int ans = 0;
    while (n) {
        n /= 5;
        ans += n;
    }
    return ans;
}
```

```javascript
var trailingZeroes = function(n) {
    let ans = 0;
    while (n !== 0) {
        n = Math.floor(n / 5);
        ans += n;
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(\log n)$。
-   空间复杂度：$O(1)$。
