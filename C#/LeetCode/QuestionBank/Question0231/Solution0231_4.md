#### [方法二：判断是否为最大 $2$ 的幂的约数](https://leetcode.cn/problems/power-of-two/solutions/796201/2de-mi-by-leetcode-solution-rny3/)

**思路与算法**

除了使用二进制表示判断之外，还有一种较为取巧的做法。

在题目给定的 $32$ 位有符号整数的范围内，最大的 $2$ 的幂为 $2^{30} = 1073741824$。我们只需要判断 $n$ 是否是 $2^{30}$ 的约数即可。

**代码**

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

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
