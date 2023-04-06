#### [方法一：模拟进位](https://leetcode.cn/problems/convert-to-base-2/solutions/2209807/fu-er-jin-zhi-zhuan-huan-by-leetcode-sol-9qlh/)

**思路与算法**

对于「二进制数」我们可以很直观地得到以下结论：

-   对于 $2^i$，如果 $i$ 为偶数时，此时 $2^i = (-2)^i$；
-   对于 $2^i$，如果 $i$ 为奇数时，此时 $2^i = (-2)^{i+1} + (-2)^i$；

因此自然可以想到将 $n$ 转换为 $-2$ 的幂数和，即此时 $n = \sum\limits_{i=0}^{m}C_{i} \times (-2)^{i}$，由于 $-2$ 进制的每一位只能为 $0$ 或 $1$，需要对每一位进行加法「[进位](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E8%BF%9B%E4%BD%8D%2F5989952%3Ffr%3Daladdin)」运算即可得到完整的「负二进制」数。对于「负二进制」数，此时需要思考一下进位规则。对于 $C \times (-2)^i$，期望得到如下变换规则：

-   如果 $C$ 为奇数则需要将等式变为 $C \times (-2)^i = a \times (-2)^{i + 1} + (-2)^{i}$，此时第 $i$ 位为 $1$，第 $i + 1$ 位需要加上 $a$；
-   如果 $C$ 为偶数则需要将等式变为 $C \times (-2)^i = a \times (-2)^{i + 1}$，此时第 $i$ 位为 $0$，第 $i + 1$ 位需要加上 $a$；

根据以上的变换规则，只需要求出 $a$ 即可。假设当前数位上的数字为 $val$，当前的位上保留的余数为 $r$，在 $x$ 进制下的进位为 $a$，根据「[进位](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E8%BF%9B%E4%BD%8D%2F5989952%3Ffr%3Daladdin)」的运算规则可知 $val = a \times x + r$，此时可以得到进位 $a = \dfrac{val-r}{x}$。根据题意可知，「负二进制」数的每一位上保留的余数为 $0$ 或 $1$，因此可以计算出当前的余数 $r$，由于在有符号整数的均采用补码表示，最低位的奇偶性保持不变，因此可以直接取 $val$ 的最低位即可，此时可以得到 $r = val \And 1$。根据上述等式可以知道，当前数位上的数字为 $val$ 时，此时在「负二进制」下向高位的进位为 $a = \dfrac{val-(val \And 1)}{-2}$。 基于以上进位规则，将变换出来的数列进行进位运算即可得到完整的「负二进制」数。整个转换过程如下：

-   将 $n$ 转换为二进制数，并将二进制数中的每一位转换为「负二进制」中的每一位，变换后的数列为 $bits$；
-   将 $bits$ 从低位向高位进行「[进位](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E8%BF%9B%E4%BD%8D%2F5989952%3Ffr%3Daladdin)」运算，即将 $bits$ 中的每一位都变为 $0$ 或者 $1$；
-   去掉前导 $0$ 以后，将 $bits$ 转换为字符串返回即可。

**代码**

```cpp
class Solution {
public:
    string baseNeg2(int n) {
        if (n == 0) {
            return "0";
        }
        vector<int> bits(32);
        for (int i = 0; i < 32 && n != 0; i++) {
            if (n & 1) {
                bits[i]++;
                if (i & 1) {
                    bits[i + 1]++;
                }
            }
            n >>= 1;
        }
        int carry = 0;
        for (int i = 0; i < 32; i++) {
            int val = carry + bits[i];
            bits[i] = val & 1;
            carry = (val - bits[i]) / (-2);
        }
        int pos = 31;
        string res;
        while (pos >= 0 && bits[pos] == 0) {
            pos--;
        }
        while (pos >= 0) {
            res.push_back(bits[pos] + '0');
            pos--;
        }
        return res;
    }
};
```

```java
class Solution {
    public String baseNeg2(int n) {
        if (n == 0) {
            return "0";
        }
        int[] bits = new int[32];
        for (int i = 0; i < 32 && n != 0; i++) {
            if ((n & 1) != 0) {
                bits[i]++;
                if ((i & 1) != 0) {
                    bits[i + 1]++;
                }
            }
            n >>= 1;
        }
        int carry = 0;
        for (int i = 0; i < 32; i++) {
            int val = carry + bits[i];
            bits[i] = val & 1;
            carry = (val - bits[i]) / (-2);
        }
        int pos = 31;
        StringBuilder res = new StringBuilder();
        while (pos >= 0 && bits[pos] == 0) {
            pos--;
        }
        while (pos >= 0) {
            res.append(bits[pos]);
            pos--;
        }
        return res.toString();
    }
}
```

```csharp
public class Solution {
    public string BaseNeg2(int n) {
        if (n == 0) {
            return "0";
        }
        int[] bits = new int[32];
        for (int i = 0; i < 32 && n != 0; i++) {
            if ((n & 1) != 0) {
                bits[i]++;
                if ((i & 1) != 0) {
                    bits[i + 1]++;
                }
            }
            n >>= 1;
        }
        int carry = 0;
        for (int i = 0; i < 32; i++) {
            int val = carry + bits[i];
            bits[i] = val & 1;
            carry = (val - bits[i]) / (-2);
        }
        int pos = 31;
        StringBuilder res = new StringBuilder();
        while (pos >= 0 && bits[pos] == 0) {
            pos--;
        }
        while (pos >= 0) {
            res.Append(bits[pos]);
            pos--;
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
    int bits[32];
    memset(bits, 0, sizeof(bits));
    for (int i = 0; i < 32 && n != 0; i++) {
        if (n & 1) {
            bits[i]++;
            if (i & 1) {
                bits[i + 1]++;
            }
        }
        n >>= 1;
    }
    int carry = 0;
    for (int i = 0; i < 32; i++) {
        int val = carry + bits[i];
        bits[i] = val & 1;
        carry = (val - bits[i]) / (-2);
    }
    int pos = 31;
    char *res = (char *)calloc(sizeof(char), 32);
    while (pos >= 0 && bits[pos] == 0) {
        pos--;
    }
    int i = 0;
    while (pos >= 0) {
        res[i] = bits[pos] + '0';
        pos--;
        i++;
    }
    return res;
}
```

```python
class Solution:
    def baseNeg2(self, n: int) -> str:
        if n == 0:
            return "0"

        bits = [0] * 32
        for i in range(32):
            if n == 0:
                break
            if n & 1:
                bits[i] += 1
                if i & 1:
                    bits[i + 1] += 1
            n >>= 1

        carry = 0
        for i in range(32):
            val = carry + bits[i]
            bits[i] = val & 1
            carry = (val - bits[i]) // -2

        pos = 31
        res = ""
        while pos >= 0 and bits[pos] == 0:
            pos -= 1
        while pos >= 0:
            res += str(bits[pos])
            pos -= 1
        return res
```

```javascript
var baseNeg2 = function(n) {
    if (n === 0) {
        return "0";
    }
    const bits = new Array(32).fill(0);
    for (let i = 0; i < 32 && n !== 0; i++) {
        if ((n & 1) !== 0) {
            bits[i]++;
            if ((i & 1) !== 0) {
                bits[i + 1]++;
            }
        }
        n >>= 1;
    }
    let carry = 0;
    for (let i = 0; i < 32; i++) {
        const val = carry + bits[i];
        bits[i] = val & 1;
        carry = (val - bits[i]) / (-2);
    }
    let pos = 31;
    let res = "";
    while (pos >= 0 && bits[pos] === 0) {
        pos--;
    }
    while (pos >= 0) {
        res += bits[pos];
        pos--;
    }
    return res;
};
```

```go
func baseNeg2(n int) string {
    if n == 0 {
        return "0"
    }
    bits := [32]int{}
    for i := 0; i < 32 && n != 0; i++ {
        if n&1 > 0 {
            bits[i]++
            if i&1 > 0 {
                bits[i+1]++
            }
        }
        n >>= 1
    }
    carry := 0
    for i := 0; i < 32; i++ {
        val := carry + bits[i]
        bits[i] = val & 1
        carry = (val - bits[i]) / -2
    }
    pos := 31
    res := []byte{}
    for pos >= 0 && bits[pos] == 0 {
        pos--
    }
    for pos >= 0 {
        res = append(res, byte(bits[pos])+'0')
        pos--
    }
    return string(res)
}
```

**复杂度分析**

-   时间复杂度：$O(C)$，其中 $C = 32$。需要对 $n$ 转换为二进制位，需要的时间复杂度为 $O(\log n)$，然后需要对其进行二进制位的中每一位进行「负二进制进位」运算，由于整数有 $32$ 位，因此需要「负二进制进位」运算 $32$ 次即可。
-   空间复杂度：$O(C)$，其中 $C = 32$。需要对 $n$ 转换为二进制位，由于整数最多只有 $32$ 位，在此每次采取固定的存储空间为 $O(32)$。
