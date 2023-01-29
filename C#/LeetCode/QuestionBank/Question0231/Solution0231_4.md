#### [���������ж��Ƿ�Ϊ��� $2$ ���ݵ�Լ��](https://leetcode.cn/problems/power-of-two/solutions/796201/2de-mi-by-leetcode-solution-rny3/)

**˼·���㷨**

����ʹ�ö����Ʊ�ʾ�ж�֮�⣬����һ�ֽ�Ϊȡ�ɵ�������

����Ŀ������ $32$ λ�з��������ķ�Χ�ڣ����� $2$ ����Ϊ $2^{30} = 1073741824$������ֻ��Ҫ�ж� $n$ �Ƿ��� $2^{30}$ ��Լ�����ɡ�

**����**

```cpp
class Solution {
private:
    static constexpr int BIG = 1 << 30;

public:
    bool isPowerOfTwo(int n) {
        return n > 0 && BIG % n == 0;
    }
};
```

```java
class Solution {
    static final int BIG = 1 << 30;

    public boolean isPowerOfTwo(int n) {
        return n > 0 && BIG % n == 0;
    }
}
```

```csharp
public class Solution {
    const int BIG = 1 << 30;

    public bool IsPowerOfTwo(int n) {
        return n > 0 && BIG % n == 0;
    }
}
```

```python
class Solution:

    BIG = 2**30

    def isPowerOfTwo(self, n: int) -> bool:
        return n > 0 and Solution.BIG % n == 0
```

```javascript
var isPowerOfTwo = function(n) {
    const BIG = 1 << 30;
    return n > 0 && BIG % n === 0;
};
```

```go
func isPowerOfTwo(n int) bool {
    const big = 1 << 30
    return n > 0 && big%n == 0
}
```

```c
const int BIG = 1 << 30;

bool isPowerOfTwo(int n) {
    return n > 0 && BIG % n == 0;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(1)$��
-   �ռ临�Ӷȣ�$O(1)$��
