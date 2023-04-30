#### [方法二：取模性质](https://leetcode.cn/problems/power-of-four/solutions/798268/4de-mi-by-leetcode-solution-b3ya/)

**思路与算法**

如果 $n$ 是 $4$ 的幂，那么它可以表示成 $4^x$ 的形式，我们可以发现它除以 $3$ 的余数一定为 $1$，即：

$$4^x \equiv (3+1)^x \equiv 1^x \equiv 1 \quad (\bmod ~3)$$

如果 $n$ 是 $2$ 的幂却不是 $4$ 的幂，那么它可以表示成 $4^x \times 2$ 的形式，此时它除以 $3$ 的余数一定为 $2$。

因此我们可以通过 $n$ 除以 $3$ 的余数是否为 $1$ 来判断 $n$ 是否是 $4$ 的幂。

**代码**

```cpp
class Solution {
public:
    bool isPowerOfFour(int n) {
        return n > 0 && (n & (n - 1)) == 0 && n % 3 == 1;
    }
};
```

```java
class Solution {
    public boolean isPowerOfFour(int n) {
        return n > 0 && (n & (n - 1)) == 0 && n % 3 == 1;
    }
}
```

```csharp
public class Solution {
    public bool IsPowerOfFour(int n) {
        return n > 0 && (n & (n - 1)) == 0 && n % 3 == 1;
    }
}
```

```python
class Solution:
    def isPowerOfFour(self, n: int) -> bool:
        return n > 0 and (n & (n - 1)) == 0 and n % 3 == 1
```

```javascript
var isPowerOfFour = function(n) {
    return n > 0 && (n & (n - 1)) === 0 && n % 3 === 1;
};
```

```go
func isPowerOfFour(n int) bool {
    return n > 0 && n&(n-1) == 0 && n%3 == 1
}
```

```c
bool isPowerOfFour(int n) {
    return n > 0 && (n & (n - 1)) == 0 && n % 3 == 1;
}
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
