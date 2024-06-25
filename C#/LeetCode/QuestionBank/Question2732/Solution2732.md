### 数学解

证明，如果有解，必然存在只有1行或2行的解。

#### 证明

假设数组有$n$列，且有一个$m$行的解，这个解中一共有$N$个$1$。

由于这$m$行是解，即每一列的$1$都不超过$\lfloor\dfrac{m}{2}\rfloor$个，即
$$N \le \lfloor\dfrac{m}{2}\rfloor \times n$$

假设这个解中，没有任何$2$行也是解，即任意$2$行都至少有$1$列是$2$个$1$，即
$$N \ge C_m^2 \times 2 \\
  N \ge m(m-1)$$

即
$$m(m-1) \le N \le \lfloor\dfrac{m}{2}\rfloor \times n \\
  m(m-1)       \le \lfloor\dfrac{m}{2}\rfloor \times n$$

- 如果$m$是偶数，则
    $$m(m-1) \le \lfloor\dfrac{m}{2}\rfloor \times n \\
      m(m-1) \le \dfrac{m}{2} \times n \\
      m \le \dfrac{n}{2} + 1$$
    由于$n \le 5$且$m$是偶数，所以$m = 2$。
- 如果$m$是奇数，则
    $$m(m-1) \le \lfloor\dfrac{m}{2}\rfloor \times n \\
      m(m-1) \le \dfrac{m-1}{2} \times n \\
      m \le \dfrac{n}{2} + 1$$
    由于$n \ le 5$且$m$是奇数数，所以$m = 1$。
