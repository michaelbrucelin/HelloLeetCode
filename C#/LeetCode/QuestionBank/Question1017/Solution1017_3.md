#### [方法二：进制转换](https://leetcode.cn/problems/convert-to-base-2/solutions/2209807/fu-er-jin-zhi-zhuan-huan-by-leetcode-sol-9qlh/)

**思路与算法**

当基数 $x > 1$ 时，将整数 $n$ 转换成 $x$ 进制的原理是：令 $n_0 = n$，计算过程如下:

-   当计算第 $0$ 位上的数字时，此时 $n_1 = \Big\lfloor \dfrac{n_0}{x} \Big\rfloor$，$n_0 = n_1 \times x + r$，其中 $0 \le r < x$；
-   当计算第 $i$ 位上的数字时，此时 $n_{i + 1} = \Big\lfloor \dfrac{n_i}{x} \Big\rfloor$，$n_i = n_{i+1} \times x + r$，其中 $0 \le r < x$；
-   按照上述计算方式进行计算，直到满足 $n_{i} = 0$ 结束。

如果基数 $x$ 为负数，只要能确定余数的可能取值，上述做法同样适用。由于「负二进制」表示中的每一位都是 $0$ 或 $1$，因此余数的可能取值是 $0$ 和 $1$，可以使用上述做法将整数 $n$ 转换成「负二进制」。具体转换过程如下：

-   如果 $n = 0$ 则返回 $"0"$，$n = 1$ 则直接返回 $"1"$；
-   如果 $n > 1$ 则使用一个字符串记录余数，将整数 $n$ 转换成「负二进制」，重复执行如下操作，直到 $n = 0$；
    -   计算当前 $n$ 的余数，由于当前的余数只能为 $0$ 或 $1$，由于有符号整数均采用补码表示，最低位的奇偶性保持不变，因此可以直接取 $C$ 的最低位即可，此时直接用 $n \And 1$ 即可得到最低位的余数，将余数拼接到字符串的末尾。
    -   将 $n$ 的值减去余数，然后将 $n$ 的值除以 $-2$。

上述操作结束之后，将字符串翻转之后得到「负二进制」数。

**代码**

```cpp
class Solution {
public:
    string baseNeg2(int n) {
        if (n == 0 || n == 1) {
            return to_string(n);
        }
        string res;
        while (n != 0) {
            int remainder = n & 1;
            res.push_back('0' + remainder);
            n -= remainder;
            n /= -2;
        }
        reverse(res.begin(), res.end());
        return res;
    }
};
```

```java
class Solution {
    public String baseNeg2(int n) {
        if (n == 0 || n == 1) {
            return String.valueOf(n);
        }
        StringBuilder res = new StringBuilder();
        while (n != 0) {
            int remainder = n & 1;
            res.append(remainder);
            n -= remainder;
            n /= -2;
        }
        return res.reverse().toString();
    }
}
```

```csharp
public class Solution {
    public string BaseNeg2(int n) {
        if (n == 0 || n == 1) {
            return n.ToString();
        }
        StringBuilder sb = new StringBuilder();
        while (n != 0) {
            int remainder = n & 1;
            sb.Append(remainder);
            n -= remainder;
            n /= -2;
        }
        StringBuilder res = new StringBuilder();
        for (int i = sb.Length - 1; i >= 0; i--) {
            res.Append(sb[i]);
        }
        return res.ToString();
    }
}
```

```c
char * baseNeg2(int n) {
    if (n == 0) {
        return "0";
    }
    if (n == 1) {
        return "1";
    }
    char *res = (char *)calloc(sizeof(char), 32);
    int pos = 0;
    while (n != 0) {
        int remainder = n & 1;
        res[pos++] = '0' + remainder;
        n -= remainder;
        n /= -2;
    }
    for (int l = 0, r = pos - 1; l < r; l++, r--) {
        char c = res[l];
        res[l] = res[r];
        res[r] = c;
    }
    return res;
}
```

```python
class Solution:
    def baseNeg2(self, n: int) -> str:
        if n == 0 or n == 1:
            return str(n)
        res = []
        while n:
            remainder = n & 1
            res.append(str(remainder))
            n -= remainder
            n //= -2
        return ''.join(res[::-1])
```

```javascript
var baseNeg2 = function(n) {
    if (n === 0 || n === 1) {
        return '' + n;
    }
    let res = '';
    while (n !== 0) {
        const remainder = n & 1;
        res += remainder;
        n -= remainder;
        n /= -2;
    }
    return res.split('').reverse().join('');
};
```

```go
func baseNeg2(n int) string {
    if n == 0 || n == 1 {
        return strconv.Itoa(n)
    }
    res := []byte{}
    for n != 0 {
        remainder := n & 1
        res = append(res, '0'+byte(remainder))
        n -= remainder
        n /= -2
    }
    for i, n := 0, len(res); i < n/2; i++ {
        res[i], res[n-1-i] = res[n-1-i], res[i]
    }
    return string(res)
}
```

**复杂度分析**

-   时间复杂度：$O(\log n)$，其中 $n$ 是给定的整数。整数 $n$ 对应的「负二进制」表示的长度是 $\log n$，需要生成「负二进制」表示的每一位。
-   空间复杂度：$O(1)$。除返回值外，不需要额外的空间。
