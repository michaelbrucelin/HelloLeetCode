#### [����������ѧ����](https://leetcode.cn/problems/convert-to-base-2/solutions/2209807/fu-er-jin-zhi-zhuan-huan-by-leetcode-sol-9qlh/)

**˼·���㷨**

���������֪��$32$ λ���������ơ����е� $i$ λ���ʾ$(-2)^i$���� $i$ Ϊż��ʱ���� $(-2)^i = 2^i$���� $i$ Ϊ����ʱ���� $(-2)^i = -2^i$����˿��Եõ������ֵ����Сֵ�ֱ�Ϊ���£�

-   ���ֵ�����е�ż��λȫ����Ϊ $1$������λȫΪ $0$�����ֵ��Ϊ $0x55555555 = 1,431,655,765$��
-   ��Сֵ�����е�ż��λȫ����Ϊ $0$������λȫΪ $1$����Сֵ��Ϊ $0xAAAAAAAA = -2,863,311,530$��
-   $0x55555555,0xAAAAAAAA$ ��Ϊ��ʮ�����ơ�����ԭ���ʾ��

�� $maxVal = 0x55555555$��������Ŀ�� $n$ �����ķ�ΧΪ $0 \le n \le 10^9$�����һ������ $maxVal > n$���� $maxVal$ �� $n$ �Ĳ�Ϊ $diff$�����ʱ $diff = maxVal - n$��������ǽ� $maxVal$ �ڡ��������ơ���ʾ�¼�ȥ $diff$����ô�õ��ġ��������ơ�һ��Ϊ $n$ �ġ��������ơ�����֪ $maxVal$ �е�ż��λȫΪ $1$������λȫΪ $0$����ʱ�ļ������������������ʵ��:

-   ���� $diff$ ��ż��λΪ $1$ ��λ���� $maxVal$ ����Ҫ������Ϊ $0$����ʱ $maxVal$ ��ż��λȫ��Ϊ $1$��$1 \oplus 1 = 0$��ż��λ���������ɽ���Ҫ��λ��Ϊ $0$��
-   ���� $diff$ ������λΪ $1$ ��λ���� $maxVal$ ����Ҫ������Ϊ $1$����ʱ $maxVal$ ������λȫ��Ϊ $0$��$0 \oplus 1 = 1$������λ����������Ҫ��λ��Ϊ $1$��

�����������ۿ���֪�������������ơ�������ͬ�� $maxVal \oplus diff$������������������֪�� $n$ �ġ��������ơ������� $maxVal \oplus (maxVal - n)$��������� $n$ �ġ��������ơ�����Ȼ����ת��Ϊ�����Ƶ��ַ������ɡ�

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(\log n)$������ $n$ �Ǹ��������������� $n$ ��Ӧ�ġ��������ơ���ʾ�ĳ����� $\log n$����Ҫ���ɡ��������ơ���ʾ��ÿһλ��
-   �ռ临�Ӷȣ�$O(1)$��������ֵ�⣬����Ҫ����Ŀռ䡣
