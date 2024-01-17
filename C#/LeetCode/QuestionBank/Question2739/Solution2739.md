### 空瓶换瓶

这道题本质上就是传统的每$3$个空瓶换$1$瓶饮料的问题的变种，多了个可以换的次数的限制而已。

首先算出额外从副油箱添加到主油箱的油量。
由于每次完成 消耗 $5$ 升油 $\rightarrow$ 补充 $1$ 升油，相当于花费 $4$ 升油，这样算出来是 $\lfloor mainTank / 4 \rfloor$。
但是，假如 $mainTank$ 是 $4$ 的倍数，那么最后 $4$ 升油是得不到补充的，因此实际上应该是 $\lfloor (mainTank - 1) / 4 \rfloor$。
注意额外补充的油量不能超过 $additionalTank$。
算出总油量后，乘以 $10$ 即可。

---

### [总行驶距离（详细数学推理论证过程）](https://leetcode.cn/problems/total-distance-traveled/solutions/2377670/2739-zong-xing-shi-ju-chi-shu-xue-tui-li-zzhr/)

设主油箱油量mainTank的值为$x \ L$，副油箱油量additionalTank的值为$y \ L$。假设**不考虑副油箱中的油量**（$additionalTank=\infty$），如果整个过程进行了$n$次补油，那么主油箱耗费的公式为：
$$x+(-5+1)_{1}+(-5+1)_{2}+ \cdots +(-5+1)_{n}-a=x-4n-a=0$$
其中$a \ L$为最后一刻剩余的油量，可得：
$$0 \lt a \lt 5$$
因为$a$为整数，不等式亦可写成：
$$1 \le a \le 4$$
即：
$$1 \le x-4n \le 4$$
最终可以确定整数$n$的范围：
$$\frac{x-4}{4} \le n \le \frac{x-1}{4}$$
既然得到了整数$n$的范围，则可以通过整数$x$来**反推**整数$n$的值：
$$n=\lfloor\frac{x-1}{4}\rfloor$$
由于整数$n$为补油的次数，一次补$1L$，总共补了$n \ L$油量，所以总行驶距离为：
$$(x+n) \ L \times 10 \ km/L = 10 \ (x+n) \ km$$
由于以上不考虑副油箱中的油量，所以如果要考虑副油箱中的油量，无非两种情况：
$$n \leq y \text{ 或 } n > y$$
若$n \leq y$，则不影响上述结果；若$n > y$，则说明主油箱油量到用完的过程中补油的次数最多只有$y$次（即最多只能补$y \ L$），所以只能令$n=y$带入。

综上所述，补油的次数$n$次（$n\ L$）为：
$$n=min \ \{\ \lfloor\frac{x-1}{4}\rfloor\ , \ y \ \}$$
总行驶距离为：
$$10 \ (x+n) \ km$$
