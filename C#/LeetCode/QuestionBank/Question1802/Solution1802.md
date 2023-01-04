#### 数学题

例如：$n = 4, index = 2,  maxSum = 6$
令解为$x$，则数组为$[x-2, x-1, x, x-1]$，则 $(x-2) + (x-1) + (x) + (x-1) \le 6，x \le 2.5，x = 2$
再如：$n = 6, index = 1,  maxSum = 10$
令解为$x$，则数组为$[x-1, x, x-1, x-2, x-3, x-4]$，则 $(x-1) + (x) + (x-1) + (x-2) + (x-3) + (x-4) \le 10，x \le 3.5，x = 3$

下面推导一下最终解：

最终的数组为：
$[x-index, x-index+1, ..., x-1, x, x-1, x-2, ..., x-(n-index-1)]$

数组元素和为：
$\begin{aligned} & (x-index) + (x-index+1) + ... + (x-1) & +x & +(x-1) + (x-2) + ... + (x-(n-index-1)) \\ = & index \times x - \frac{1}{2}index\times(index+1) & +x & +(n-index-1) \times x - \frac{1}{2}(n-index-1)\times(n-index) \\ = & (index + 1 + (n-index-1)) \times x & & - \frac{1}{2}(index \times (index+1) + (n-index-1) \times (n-index)) \\ = & n \times x - \frac{1}{2}((n-index)^2 + (index+1)^2 -n-1) \end{aligned}$

所以
$n \times x - \dfrac{1}{2}((n-index)^2 + (index+1)^2 -n-1) \le maxSum \\ n \times x \le maxSum + \dfrac{1}{2}((n-index)^2 + (index+1)^2 -n-1) \\ x \le \dfrac{1}{n}(maxSum + \dfrac{1}{2}((n-index)^2 + (index+1)^2 -n-1))$

即
$x = \lfloor \dfrac{1}{n}(maxSum + \dfrac{1}{2}((n-index)^2 + (index+1)^2 -n-1)) \rfloor$

**上面解法是错误的，因为忽略了题目中的一个要求，即数组中的每一项都需要 `> 0`**

既然有数组的每一项是正整数这一限制，那么只需要在上面逻辑的基础上稍加改动即可。

1. 首先，如果$index > \dfrac{n - 1}{2}$，令$index = (n-1) - index$，因为结果的对称性，将$index$映射成它的“镜像$index$”；
2. 然后利用上面的思路，得出结果$x$，这时验证两端的元素$x-index$（令其为$x_0$）与$x-(n-index-1)$（令其为$x_n$）；
   1. 如果$x_0 > 0$且$x_n > 0$，此时$x$就是解；
   2. 如果$x_0 > 0$且$x_n \le 0$，此时需要调整后重新求解，将最后的几项（共$1-x_n$项）都调整为$1$，此时令$n = n - (1-x_n),\space maxSum = maxSum - (1-x_n)$，然后回到步骤1，继续求解；
   3. 如果$x_0 \le 0$，则$x_n \le 0$，此时需要调整后重新求解，将最前面迹象与最后的几项（共$(1-x_0) + (1-x_n)$项）都调整为$1$，此时令$n = n - (1-x_0) - (1-x_n),\space maxSum = maxSum - (1-x_0) - (1-x_n),\space index = index - (1-x_0)$，然后回到步骤1，继续求解；
