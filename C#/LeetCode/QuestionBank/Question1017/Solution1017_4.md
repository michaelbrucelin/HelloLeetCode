#### [方法三：数学计算](https://leetcode.cn/problems/convert-to-base-2/solutions/2209807/fu-er-jin-zhi-zhuan-huan-by-leetcode-sol-9qlh/)

**思路与算法**

根据题意可知，$32$ 位「负二进制」数中第 $i$ 位则表示$(-2)^i$，当 $i$ 为偶数时，则 $(-2)^i = 2^i$，当 $i$ 为奇数时，则 $(-2)^i = -2^i$，因此可以得到其最大值与最小值分别为如下：

-   最大值即所有的偶数位全部都为 $1$，奇数位全为 $0$，最大值即为 $0x55555555 = 1,431,655,765$；
-   最小值即所有的偶数位全部都为 $0$，奇数位全为 $1$，最小值即为 $0xAAAAAAAA = -2,863,311,530$；
-   $0x55555555,0xAAAAAAAA$ 均为「十六进制」进制原码表示；

令 $maxVal = 0x55555555$，由于题目中 $n$ 给定的范围为 $0 \le n \le 10^9$，因此一定满足 $maxVal > n$。设 $maxVal$ 与 $n$ 的差为 $diff$，则此时 $diff = maxVal - n$，如果我们将 $maxVal$ 在「负二进制」表示下减去 $diff$，那么得到的「负二进制」一定为 $n$ 的「负二进制」。已知 $maxVal$ 中的偶数位全为 $1$，奇数位全为 $0$，此时的减法操作可以用异或来实现:

-   对于 $diff$ 中偶数位为 $1$ 的位，在 $maxVal$ 中需要将其置为 $0$，此时 $maxVal$ 中偶数位全部为 $1$，$1 \oplus 1 = 0$，偶数位异或操作即可将需要的位置为 $0$；
-   对于 $diff$ 中奇数位为 $1$ 的位，在 $maxVal$ 中需要将其置为 $1$，此时 $maxVal$ 中奇数位全部为 $0$，$0 \oplus 1 = 1$，奇数位异或操作将需要的位置为 $1$，

根据以上推论可以知道，「负二进制」减法等同于 $maxVal \oplus diff$。按照上述方法可以知道 $n$ 的「负二进制」数等于 $maxVal \oplus (maxVal - n)$，我们求出 $n$ 的「负二进制」数，然后将其转换为二进制的字符串即可。

**代码**

```cpp
class Solution {
public:
    string baseNeg2(int n) {
        int val = 0x55555555 ^ (0x55555555 - n);
        if (val == 0) {
            return "0";
        }
        string res;
        while (val) {
            res.push_back('0' + (val & 1));
            val >>= 1;
        }
        reverse(res.begin(), res.end());
        return res;
    }
};
```

```java
class Solution {
    public String baseNeg2(int n) {
        int val = 0x55555555 ^ (0x55555555 - n);
        if (val == 0) {
            return "0";
        }
        StringBuilder res = new StringBuilder();
        while (val != 0) {
            res.append(val & 1);
            val >>= 1;
        }
        return res.reverse().toString();
    }
}
```

```csharp
public class Solution {
    public string BaseNeg2(int n) {
        int val = 0x55555555 ^ (0x55555555 - n);
        if (val == 0) {
            return "0";
        }
        StringBuilder sb = new StringBuilder();
        while (val != 0) {
            sb.Append(val & 1);
            val >>= 1;
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
    int val = 0x55555555 ^ (0x55555555 - n);
    if (val == 0) {
        return "0";
    }
    char *res = (char *)calloc(sizeof(char), 32);
    int pos = 0;
    while (val) {
        res[pos++] = '0' + (val & 1);
        val >>= 1;
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
        val = 0x55555555 ^ (0x55555555 - n)
        if val == 0:
            return "0"
        res = []
        while val:
            res.append(str(val & 1))
            val >>= 1
        return ''.join(res[::-1])
```

```javascript
var baseNeg2 = function(n) {
    let val = 0x55555555 ^ (0x55555555 - n);
    if (val === 0) {
        return "0";
    }
    let res = "";
    while (val !== 0) {
        res += val & 1;
        val >>= 1;
    }
    return res.split('').reverse().join('');
};
```

```go
func baseNeg2(n int) string {
    val := 0x55555555 ^ (0x55555555 - n)
    if val == 0 {
        return "0"
    }
    res := []byte{}
    for val > 0 {
        res = append(res, '0'+byte(val&1))
        val >>= 1
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
