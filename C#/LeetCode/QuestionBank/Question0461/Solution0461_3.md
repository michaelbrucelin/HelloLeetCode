#### [����������λʵ��λ����](https://leetcode.cn/problems/hamming-distance/solutions/797339/yi-ming-ju-chi-by-leetcode-solution-u1w7/)

**˼·���㷨**

�ڶ����㷨����ʱ���ظ��������ǲ��ɱ���ģ�Ҳ��Ӧ���ġ���˶�����Ҳ��Ҫ����ʹ�ø��ַ����Լ�ʵ�ּ�������λ�������ܵĺ�������������ʹ��λ��������λ�Ĳ���ʵ��λ�������ܡ�

![](./assets/img/Solution0461_3_01.png)

����أ��� $s = x \oplus y$�����ǿ��Բ��ϵؼ�� $s$ �����λ��������λΪ $1$����ô���������һ��Ȼ�������� $s$ ��������һλ������ $s$ �����λ������ȥ��ԭ���Ĵε�λ�ͱ�����µ����λ�������ظ��������ֱ�� $s=0$ Ϊֹ�������������о��ۼ��� $s$ �Ķ����Ʊ�ʾ�� $1$ ��������

**����**

```cpp
class Solution {
public:
    int hammingDistance(int x, int y) {
        int s = x ^ y, ret = 0;
        while (s) {
            ret += s & 1;
            s >>= 1;
        }
        return ret;
    }
};
```

```java
class Solution {
    public int hammingDistance(int x, int y) {
        int s = x ^ y, ret = 0;
        while (s != 0) {
            ret += s & 1;
            s >>= 1;
        }
        return ret;
    }
}
```

```csharp
public class Solution {
    public int HammingDistance(int x, int y) {
        int s = x ^ y, ret = 0;
        while (s != 0) {
            ret += s & 1;
            s >>= 1;
        }
        return ret;
    }
}
```

```javascript
var hammingDistance = function(x, y) {
    let s = x ^ y, ret = 0;
    while (s != 0) {
        ret += s & 1;
        s >>= 1;
    }
    return ret;
};
```

```go
func hammingDistance(x, y int) (ans int) {
    for s := x ^ y; s > 0; s >>= 1 {
        ans += s & 1
    }
    return
}
```

```c
int hammingDistance(int x, int y) {
    int s = x ^ y, ret = 0;
    while (s) {
        ret += s & 1;
        s >>= 1;
    }
    return ret;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(\log C)$������ $C$ ��Ԫ�ص����ݷ�Χ���ڱ����� $\log C=\log 2^{31} = 31$��
-   �ռ临�Ӷȣ�$O(1)$��
