#### [牛顿迭代法](https://leetcode.cn/problems/valid-perfect-square/solutions/1081379/you-xiao-de-wan-quan-ping-fang-shu-by-le-wkee/)

**前置知识**

牛顿迭代法。牛顿迭代法是一种近似求解方程（近似求解函数零点）的方法。其本质是借助泰勒级数，从初始值开始快速向函数零点逼近。

![](./assets/img/Solution0367_3_01.png)

对于函数 $f(x)$，我们任取 $x_0$ 作为初始值。在每一次迭代中，我们根据当前值 $x_i$ 找到函数图像上的点 $(x_i,f(x_i))$，过该点做一条斜率为该点导数 $f'(x_0)$ 的直线，该直线与横轴（$x$ 轴）的交点记作 $(x_{i+1},0)$。$x_{i+1}$ 相较于 $x_i$ 而言，距离函数零点更近。在经过多次迭代后，我们就可以得到距离函数零点非常近的交点。

**思路**

如果 $num$ 为完全平方数，那么一定存在正整数 $x$ 满足 $x \times x = num$。于是我们写出如下方程：

$$y = f(x) = x^2 - num$$

如果方程能够取得整数解，则说明存在满足 $x \times x = num$ 的正整数 $x$。这个方程可以通过牛顿迭代法求解。

**算法**

在算法实现中，我们需要解决以下四个问题：

-   如何选取初始值？

因为 $num$ 是正整数，所以 $y = x^2 - num$ 有两个零点 $-\sqrt{num}$ 和 $\sqrt{num}$，其中 $1 \le \sqrt{num} \le num$。我们只需要判断 $\sqrt{num}$ 是否为正整数即可。又因为 $y = x^2 - num$ 是凸函数，所以只要我们选取的初始值大于等于 $\sqrt{num}$，那么每次迭代得到的结果也都会大于等于 $\sqrt{num}$。

因此，我们可以选择 $num$ 作为初始值。

-   如何进行迭代？

对 $f(x)$ 求导，得到

$$f'(x) = 2 x$$

假设当前值为 $x_i$，将 $x_i$ 代入 $f(x)$ 得到函数图像上的点 $(x_i,x_i^2 - num)$，过该点做一条斜率为 $f'(x_i) = 2 x_i$ 的直线，则直线的方程为

$$y - (x_i^2 - num) = 2 x_i (x - x_i)$$

直线与横轴（$x$ 轴）交点的横坐标为上式中的 $y = 0$ 时 $x$ 的解。于是令上式中 $y=0$，得到

$$2 x_i x - x_i^2 - num = 0$$

整理上式即可得到下一次迭代的值：

$$x_{i+1} = \frac{x_i^2 + num}{2 x_i} = \frac{1}{2} \big( x_i + \frac{num}{x_i} \big) \tag{1}$$

-   如何判断迭代是否可以结束？

每一次迭代后，我们都会距离零点更近一步，所以当相邻两次迭代的结果非常接近时，我们就可以断定，此时的结果已经足够我们得到答案了。一般来说，可以判断相邻两次迭代的结果的差值是否小于一个极小的非负数 $\epsilon$，其中 $\epsilon$ 一般可以取 $10^{-6}$ 或 $10^{-7}$。

-   如何通过迭代得到的近似零点得到最终的答案？

因为初始值的选择以及 $y = x^2 - num$ 凸函数的性质，我们通过迭代得到的 $x_i$ 一定是 $\sqrt{num}$ 的近似零点，且满足 $x_i \ge \sqrt{num}$。

当 $num$ 是完全平方数时，$\sqrt{num}$ 为正整数，则有 $\lfloor x_i \rfloor^2 = (\sqrt{num})^2 = num$，其中符号 $\lfloor x \rfloor$ 表示 $x$ 的向下取整。

**代码**

```python
class Solution:
    def isPerfectSquare(self, num: int) -> bool:
        x0 = num
        while True:
            x1 = (x0 + num / x0) / 2
            if x0 - x1 < 1e-6:
                break
            x0 = x1
        x0 = int(x0)
        return x0 * x0 == num
```

```java
class Solution {
    public boolean isPerfectSquare(int num) {
        double x0 = num;
        while (true) {
            double x1 = (x0 + num / x0) / 2;
            if (x0 - x1 < 1e-6) {
                break;
            }
            x0 = x1;
        }
        int x = (int) x0;
        return x * x == num;
    }
}
```

```csharp
public class Solution {
    public bool IsPerfectSquare(int num) {
        double x0 = num;
        while (true) {
            double x1 = (x0 + num / x0) / 2;
            if (x0 - x1 < 1e-6) {
                break;
            }
            x0 = x1;
        }
        int x = (int) x0;
        return x * x == num;
    }
}
```

```cpp
class Solution {
public:
    bool isPerfectSquare(int num) {
        double x0 = num;
        while (true) {
            double x1 = (x0 + num / x0) / 2;
            if (x0 - x1 < 1e-6) {
                break;
            }
            x0 = x1;
        }
        int x = (int) x0;
        return x * x == num;
    }
};
```

```go
func isPerfectSquare(num int) bool {
    x0 := float64(num)
    for {
        x1 := (x0 + float64(num)/x0) / 2
        if x0-x1 < 1e-6 {
            x := int(x0)
            return x*x == num
        }
        x0 = x1
    }
}
```

```javascript
var isPerfectSquare = function(num) {
    let x0 = num;
    while (true) {
        const x1 = Math.floor((x0 + num / x0) / 2);
        if (x0 - x1 < 1e-6) {
            break;
        }
        x0 = x1;
    }
    x = x0;
    return x * x === num;
};
```

**复杂度分析**

-   时间复杂度：$O(\log n)$，其中 $n$ 为正整数 $num$ 的最大值。具体计算如下：
    不妨设当前值为 $x_i$，误差为 $\epsilon_i = x_i^2 - num$；根据式 $(1)$ 解得下一次迭代的值为 $x_{i+1}$，误差为
    $$\begin{aligned} \epsilon_{i+1} & = x_{i+1}^2 - num \\ & = \Big( \frac{x_i^2 + num}{2 x_i} \Big)^2 - num \\ & = \frac{(x_i^2 - num)^2}{4 x_i^2} \\ & = \frac{\epsilon_i^2}{4x_i^2} \end{aligned}$$
    因为 $num$ 是正整数，所以有
    $$\frac{\epsilon_{i+1}}{\epsilon_i} = \frac{\epsilon_i}{4 x_i^2} = \frac{x_i^2 - num}{4 x_i^2} < \frac{1}{4}$$
    因为每一次迭代都可以将误差缩小到原来的 $\frac{1}{4}$ 以下，所以只需要最多 $\log_4 m$ 次迭代即可将误差缩小到阈值范围内，其中 $m$ 为初始值的误差与阈值的比。根据大 $O$ 符号表示法，其量级可以表示为 $O(\log n)$。
-   空间复杂度：$O(1)$。
