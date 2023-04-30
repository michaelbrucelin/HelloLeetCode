#### [前言](https://leetcode.cn/problems/sqrtx/solutions/238553/x-de-ping-fang-gen-by-leetcode-solution/)

本题是一道常见的面试题，面试官一般会要求面试者在不使用 $\sqrt{x}$ 函数的情况下，得到 $x$ 的平方根的整数部分。一般的思路会有以下几种：
-   通过其它的数学函数代替平方根函数得到精确结果，取整数部分作为答案；
-   通过数学方法得到近似结果，直接作为答案。

#### [方法一：袖珍计算器算法](https://leetcode.cn/problems/sqrtx/solutions/238553/x-de-ping-fang-gen-by-leetcode-solution/)

「袖珍计算器算法」是一种用指数函数 $\exp$ 和对数函数 $\ln$ 代替平方根函数的方法。我们通过有限的可以使用的数学函数，得到我们想要计算的结果。

我们将 $\sqrt{x}$ 写成幂的形式 $x^{1/2}$，再使用自然对数 $e$ 进行换底，即可得到
$$\sqrt{x} = x^{1/2} = (e ^ {\ln x})^{1/2} = e^{\frac{1}{2} \ln x}$$

这样我们就可以得到 $\sqrt{x}$ 的值了。

**注意：** 由于计算机无法存储浮点数的精确值（浮点数的存储方法可以参考 [IEEE 754](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2FIEEE%20754)，这里不再赘述），而指数函数和对数函数的参数和返回值均为浮点数，因此运算过程中会存在误差。例如当 $x = 2147395600$ 时，$e^{\frac{1}{2} \ln x}$ 的计算结果与正确值 $46340$ 相差 $10^{-11}$，这样在对结果取整数部分时，会得到 $46339$ 这个错误的结果。

因此在得到结果的整数部分 $ans$ 后，我们应当找出 $ans$ 与 $ans + 1$ 中哪一个是真正的答案。

```cpp
class Solution {
public:
    int mySqrt(int x) {
        if (x == 0) {
            return 0;
        }
        int ans = exp(0.5 * log(x));
        return ((long long)(ans + 1) * (ans + 1) <= x ? ans + 1 : ans);
    }
};
```

```java
class Solution {
    public int mySqrt(int x) {
        if (x == 0) {
            return 0;
        }
        int ans = (int) Math.exp(0.5 * Math.log(x));
        return (long) (ans + 1) * (ans + 1) <= x ? ans + 1 : ans;
    }
}
```

```python
class Solution:
    def mySqrt(self, x: int) -> int:
        if x == 0:
            return 0
        ans = int(math.exp(0.5 * math.log(x)))
        return ans + 1 if (ans + 1) ** 2 <= x else ans
```

```go
func mySqrt(x int) int {
    if x == 0 {
        return 0
    }
    ans := int(math.Exp(0.5 * math.Log(float64(x))))
    if (ans + 1) * (ans + 1) <= x {
        return ans + 1
    }
    return ans
}
```

**复杂度分析**

-   时间复杂度：$O(1)$，由于内置的 `exp` 函数与 `log` 函数一般都很快，我们在这里将其复杂度视为 $O(1)$。
-   空间复杂度：$O(1)$。
