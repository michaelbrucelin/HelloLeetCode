#### [�������������ѧ](https://leetcode.cn/problems/count-sorted-vowel-strings/solutions/2195462/tong-ji-zi-dian-xu-yuan-yin-zi-fu-chuan-sk7y1/)

����һ�����ֵ������е�Ԫ���ַ��������� $'a'$��$'e'$��$'i'$��$'o'$��$'u'$ ����ʼ�±�ֱ�Ϊ $i_a$��$i_e$��$i_i$��$i_o$��$i_u$����Ȼ $i_a=0$ �� $0 \le i_e \le i_i \le i_o \le i_u \le n$������ֵ���Ԫ���ַ�������Ŀ�������� $0 \le i_e \le i_i \le i_o \le i_u \le n$ �� $(i_e, i_i, i_o, i_u)$ ��ȡֵ��Ŀ����Ҫֱ����� $(i_e, i_i, i_o, i_u)$ ��ȡֵ��Ŀ��ʮ�����ѵģ����ǿ���������ת����

$$\begin{align} i_e'&=i_e \\ i_i'&=i_i+1 \\ i_o'&=i_o+2 \\ i_u'&=i_u+3 \\ \end{align}$$

�� $0 \le i_e \le i_i \le i_o \le i_u \le n$ ��֪ $0 \le i_e' \lt i_i' \lt i_o' \lt i_u' \le n + 3$��ÿһ�� $(i_e, i_i, i_o, i_u)$ ��Ψһ�ض�Ӧһ�� $(i_e', i_i', i_o', i_u')$����� $(i_e, i_i, i_o, i_u)$ ��ȡֵ��Ŀ���� $(i_e', i_i', i_o', i_u')$ ��ȡֵ��Ŀ��$(i_e', i_i', i_o', i_u')$ �ȼ��ڴ� $n+4$ ������ѡȡ������ȵ� $4$ ���������$(i_e', i_i', i_o', i_u')$ ��ȡֵ��Ŀ��������� $C^{4}_{n+4}$��

```python
class Solution:
    def countVowelStrings(self, n: int) -> int:
        return comb(n + 4, 4)
```

```cpp
class Solution {
public:
    int countVowelStrings(int n) {
        return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
    }
};
```

```java
class Solution {
    public int countVowelStrings(int n) {
        return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
    }
}
```

```csharp
public class Solution {
    public int CountVowelStrings(int n) {
        return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
    }
}
```

```c
int countVowelStrings(int n) {
    return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
}
```

```javascript
var countVowelStrings = function(n) {
    return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24;
};
```

```go
func countVowelStrings(n int) int {
    return (n + 1) * (n + 2) * (n + 3) * (n + 4) / 24
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(\Sigma)$������ $\Sigma = 5$ ��ʾԪ���ַ�����С��
-   �ռ临�Ӷȣ�$O(1)$��
