#### [证明：至多循环 6 次（Python/Java/C++/Go）...](https://leetcode.cn/problems/bianry-number-to-string-lcci/solutions/2141577/zheng-ming-zhi-duo-xun-huan-6-ci-pythonj-b6sj/)

$num$ 如果可以表示为**有限位**二进制小数，那么可以表示为一个形如 $\dfrac{b}{2^k}$ 的**最简分数**，这里 $b$ 是整数且与 $2^k$ 互质。当 $num$ 在 $(0,1)$ 内时，$k \ge 1$，$b$ 与 $2$ 互质。

例如 $0.625 = \dfrac{5}{8} = \dfrac{5}{2^3}$，由于 $5 = 101_{(2)}$，所以 $0.625=0.101_{(2)}$。

对于一个十进制小数位数最多有 $6$ 位的数 $num$，可以表示为分数 $\dfrac{a}{10^6}$ 或者 $\dfrac{a}{2^6 \cdot 5^6}$。这里不要求是最简分数，只规定 $a$ 是整数。

如果 $num$ 可以表示为有限位二进制小数，则有

$$\dfrac{a}{2^6 \cdot 5^6} = \dfrac{b}{2^k}$$

等号两边同时乘上 $2^k$，得

$$\dfrac{a \cdot 2^{k-6}}{5^6} = b$$

由于 $b$ 与 $2$ 互质，等号左边不能有因子 $2$，所以 $k-6 \le 0$，即 $k \le 6$，当 $a$ 是奇数时取等号。

因此，**当 $num$ 的十进制的小数位数最多只有 $6$ 位时，若 $num$ 能表示为有限位二进制小数，则二进制的小数位数同样至多为 $6$ 位**。

如何用代码实现呢？

设 $num$ 的二进制表示为 $0.b_1b_2 \cdots b_k$，将其乘 $2$ 得到 $b_1.b_2 \cdots b_k$，这样就可以通过与 $1$ 比较大小，知道 $b_1$ 是 $0$ 还是 $1$ 了。然后减去 $b_1$，得到 $0.b_2 \cdots b_k$。重复该过程，循环 $k$ 次后，就得到了 $b_1,b_2,\cdots,b_k$。

由于 $k \le 6$，循环 $6$ 次后，如果 $num$ 仍不为 $0$，则它必定无法精确地用二进制表示（是一个无限循环二进制小数）。

```python
class Solution:
    def printBin(self, num: float) -> str:
        s = ["0."]
        for _ in range(6):  # 至多循环 6 次
            num *= 2
            if num < 1:
                s.append('0')
            else:
                s.append('1')
                num -= 1
                if num == 0:
                    return ''.join(s)
        return "ERROR"
```

```java
class Solution {
    public String printBin(double num) {
        var bin = new StringBuilder("0.");
        for (int i = 0; i < 6; ++i) { // 至多循环 6 次
            num *= 2;
            if (num < 1)
                bin.append('0');
            else {
                bin.append('1');
                if (--num == 0)
                    return bin.toString();
            }
        }
        return "ERROR";
    }
}
```

```cpp
class Solution {
public:
    string printBin(double num) {
        string bin = "0.";
        for (int i = 0; i < 6; ++i) { // 至多循环 6 次
            num *= 2;
            if (num < 1)
                bin += '0';
            else {
                bin += '1';
                if (--num == 0)
                    return bin;
            }
        }
        return "ERROR";
    }
};
```

```go
func printBin(num float64) string {
    bin := &strings.Builder{}
    bin.WriteString("0.")
    for i := 0; i < 6; i++ { // 至多循环 6 次
        num *= 2
        if num < 1 {
            bin.WriteByte('0')
        } else {
            bin.WriteByte('1')
            num--
            if num == 0 {
                return bin.String()
            }
        }
    }
    return "ERROR"
}
```

#### 复杂度分析

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。

#### 思考题

如果转换成 $p$ 进制呢？

根据上面的证明过程，当 $p$ 是多少的时候，$num$ 才可能表示为有限位 $p$ 进制小数？
