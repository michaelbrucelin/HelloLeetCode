#### [方法一：转换二进制数](https://leetcode.cn/problems/bianry-number-to-string-lcci/solutions/2140053/er-jin-zhi-shu-zhuan-zi-fu-chuan-by-leet-1rjh/)

介于 $0$ 和 $1$ 之间的实数的整数部分是 $0$，小数部分大于 $0$，因此其二进制表示的整数部分是 $0$，需要将小数部分转换成二进制表示。

以示例 1 为例，十进制数 $0.625$ 可以写成 $\dfrac{1}{2^1} + \dfrac{1}{2^3}$，因此对应的二进制数是 $0.101_{(2)}$，二进制数中的左边的 $1$ 为小数点后第一位，表示 $\dfrac{1}{2^1}$，右边的 $1$ 为小数点后第三位，表示 $\dfrac{1}{2^3}$。

如果将十进制数 $0.625$ 乘以 $2$，则得到 $1.25$，可以写成 $1 + \dfrac{1}{2^2}$，因此对应的二进制数是 $1.01_{(2)}$。二进制数 $0.101_{(2)}$ 的两倍是 $1.01_{(2)}$，因此在二进制表示中，将一个数乘以 $2$ 的效果是将小数点向右移动一位。

根据上述结论，将实数的十进制表示转换成二进制表示的方法是：每次将实数乘以 $2$，将此时的整数部分添加到二进制表示的末尾，然后将整数部分置为 $0$，重复上述操作，直到小数部分变成 $0$ 或者小数部分出现循环时结束操作。当小数部分变成 $0$ 时，得到二进制表示下的有限小数；当小数部分出现循环时，得到二进制表示下的无限循环小数。

由于这道题要求二进制表示的长度最多为 $32$ 位，否则返回 $“ERROR”$，因此不需要判断给定实数的二进制表示的结果是有限小数还是无限循环小数，而是在小数部分变成 $0$ 或者二进制表示的长度超过 $32$ 位时结束操作。当操作结束时，如果二进制表示的长度不超过 $32$ 位则返回二进制表示，否则返回 $“ERROR”$。

```python
class Solution:
    def printBin(self, num: float) -> str:
        res = "0."
        while len(res) <= 32 and num != 0:
            num *= 2
            digit = int(num)
            res += str(digit)
            num -= digit
        return res if len(res) <= 32 else "ERROR"
```

```java
class Solution {
    public String printBin(double num) {
        StringBuilder sb = new StringBuilder("0.");
        while (sb.length() <= 32 && num != 0) {
            num *= 2;
            int digit = (int) num;
            sb.append(digit);
            num -= digit;
        }
        return sb.length() <= 32 ? sb.toString() : "ERROR";
    }
}
```

```csharp
public class Solution {
    public string PrintBin(double num) {
        StringBuilder sb = new StringBuilder("0.");
        while (sb.Length <= 32 && num != 0) {
            num *= 2;
            int digit = (int) num;
            sb.Append(digit);
            num -= digit;
        }
        return sb.Length <= 32 ? sb.ToString() : "ERROR";
    }
}
```

```cpp
class Solution {
public:
    string printBin(double num) {
        string res = "0.";
        while (res.size() <= 32 && num != 0) {
            num *= 2;
            int digit = num;
            res.push_back(digit + '0');
            num -= digit;
        }
        return res.size() <= 32 ? res : "ERROR";
    }
};
```

```c
char* printBin(double num) {
    char *res = (char *)calloc(sizeof(int), 33);
    int pos = 0;
    pos += sprintf(res, "%s", "0.");
    while (pos <= 32 && num != 0) {
        num *= 2;
        int digit = num;
        res[pos++] = digit + '0';
        num -= digit;
    }
    if (pos > 32) {
        free(res);
        return "ERROR";
    }
    return res;
}
```

```javascript
var printBin = function(num) {
    let sb = '0.';
    while (sb.length <= 32 && num !== 0) {
        num *= 2;
        const digit = Math.floor(num);
        sb += digit;
        num -= digit;
    }
    return sb.length <= 32 ? sb : "ERROR";
};
```

```go
func printBin(num float64) string {
    sb := &strings.Builder{}
    sb.WriteString("0.")
    for sb.Len() <= 32 && num != 0 {
        num *= 2
        digit := byte(num)
        sb.WriteByte('0' + digit)
        num -= float64(digit)
    }
    if sb.Len() <= 32 {
        return sb.String()
    }
    return "ERROR"
}
```

**复杂度分析**

-   时间复杂度：$O(C)$，其中 $C$ 是结果字符串的最大长度，$C = 32$。最多计算 $32$ 位，每一位的计算时间是 $O(1)$。
-   空间复杂度：$O(C)$，其中 $C$ 是结果字符串的最大长度，$C = 32$。存储结果的字符串需要 $O(C)$ 的时间。
