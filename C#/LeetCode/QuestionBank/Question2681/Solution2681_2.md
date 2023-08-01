#### 排序 + 排列组合

可以使用排序 + 排列组合来优化计算的过程，下面对计算过程做简要的描述。

1. 数组升序排序，假定数组长度为$n$，每一项分别为$\{ x_0, x_1, ~\dots,~ x_{n-1} \}$
2. 如果组合中只含有一个元素，结果为$\sum_{i=0}^{n-1}x_i^3$
3. 如果组合中至少有两个元素，假定最大值与最小值分别为$x_{max}$与$x_{min}$，结果为$x_{max}^2 \times x_{min} \times 2^{max-min-1}$
    - 总和为：$\sum_{max=1}^{n-1}(x_{max}^2 \times \sum_{min=0}^{max-1}x_{min} \times 2^{max-min-1})$

下面对上面的第三步进行数学推导

令$N = x_0 \times 2^{n-1} + x_1 \times 2^{n-2} + \dots + x_{n-2} \times 2^1 + x_{n-1} \times 2^0$
则下面伪代码可以实现计算

```c
int result = 0, n = len - 1;
while (n > 1) {
    N = (N - nums[n]) / 2;
    result += nums[n] * nums[n] * N;
    n--;
}
```

但是上面的算法有问题，问题就在于$N$必然会溢出，所以需要使用特殊的算法来推导$N$
假定$N = p \times 2 + q = x \times MOD + y(0 \le y \lt MOD)$，下面就要求解出$p \% MOD$的解
假定$p = x_1 \times MOD + y_1(0 \le y_1 \lt MOD)$，即求$y_1$的值

$$\begin{array}{rrl}
p \times 2 + q & = & x \times MOD + y \\ 
2x_1 \times MOD + 2y_1 + q & = & x \times MOD + y \\ 
(2x_1 \times MOD + 2y_1 + q) \% MOD & = & (x \times MOD + y) \% MOD \\
(2y_1 + q) \% MOD & = & y  \\
2y_1 + q & = & k \times MOD + y \\
y_1 & = & (k \times MOD + y - q)/2
\end{array}$$
