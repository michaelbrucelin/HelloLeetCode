#### [����һ��ת����������](https://leetcode.cn/problems/bianry-number-to-string-lcci/solutions/2140053/er-jin-zhi-shu-zhuan-zi-fu-chuan-by-leet-1rjh/)

���� $0$ �� $1$ ֮���ʵ�������������� $0$��С�����ִ��� $0$�����������Ʊ�ʾ������������ $0$����Ҫ��С������ת���ɶ����Ʊ�ʾ��

��ʾ�� 1 Ϊ����ʮ������ $0.625$ ����д�� $\dfrac{1}{2^1} + \dfrac{1}{2^3}$����˶�Ӧ�Ķ��������� $0.101_{(2)}$�����������е���ߵ� $1$ ΪС������һλ����ʾ $\dfrac{1}{2^1}$���ұߵ� $1$ ΪС��������λ����ʾ $\dfrac{1}{2^3}$��

�����ʮ������ $0.625$ ���� $2$����õ� $1.25$������д�� $1 + \dfrac{1}{2^2}$����˶�Ӧ�Ķ��������� $1.01_{(2)}$���������� $0.101_{(2)}$ �������� $1.01_{(2)}$������ڶ����Ʊ�ʾ�У���һ�������� $2$ ��Ч���ǽ�С���������ƶ�һλ��

�����������ۣ���ʵ����ʮ���Ʊ�ʾת���ɶ����Ʊ�ʾ�ķ����ǣ�ÿ�ν�ʵ������ $2$������ʱ������������ӵ������Ʊ�ʾ��ĩβ��Ȼ������������Ϊ $0$���ظ�����������ֱ��С�����ֱ�� $0$ ����С�����ֳ���ѭ��ʱ������������С�����ֱ�� $0$ ʱ���õ������Ʊ�ʾ�µ�����С������С�����ֳ���ѭ��ʱ���õ������Ʊ�ʾ�µ�����ѭ��С����

���������Ҫ������Ʊ�ʾ�ĳ������Ϊ $32$ λ�����򷵻� $��ERROR��$����˲���Ҫ�жϸ���ʵ���Ķ����Ʊ�ʾ�Ľ��������С����������ѭ��С����������С�����ֱ�� $0$ ���߶����Ʊ�ʾ�ĳ��ȳ��� $32$ λʱ��������������������ʱ����������Ʊ�ʾ�ĳ��Ȳ����� $32$ λ�򷵻ض����Ʊ�ʾ�����򷵻� $��ERROR��$��

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(C)$������ $C$ �ǽ���ַ�������󳤶ȣ�$C = 32$�������� $32$ λ��ÿһλ�ļ���ʱ���� $O(1)$��
-   �ռ临�Ӷȣ�$O(C)$������ $C$ �ǽ���ַ�������󳤶ȣ�$C = 32$���洢������ַ�����Ҫ $O(C)$ ��ʱ�䡣
