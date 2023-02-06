#### [方法二：判断是否为最大 $3$ 的幂的约数](https://leetcode.cn/problems/power-of-three/solutions/1011809/3de-mi-by-leetcode-solution-hnap/)

**思路与算法**

我们还可以使用一种较为取巧的做法。

在题目给定的 $32$ 位有符号整数的范围内，最大的 $3$ 的幂为 $3^{19} = 1162261467$。我们只需要判断 $n$ 是否是 $3^{19}$ 的约数即可。

与方法一不同的是，这里需要特殊判断 $n$ 是负数或 $0$ 的情况。

**代码**

```cpp
class Solution {
public:
    bool isPowerOfThree(int n) {
        return n > 0 && 1162261467 % n == 0;
    }
};
```

```java
class Solution {
    public boolean isPowerOfThree(int n) {
        return n > 0 && 1162261467 % n == 0;
    }
}
```

```c
public class Solution {
    public bool IsPowerOfThree(int n) {
        return n > 0 && 1162261467 % n == 0;
    }
}
```

```python
class Solution:
    def isPowerOfThree(self, n: int) -> bool:
        return n > 0 and 1162261467 % n == 0
```

```javascript
var isPowerOfThree = function(n) {
    return n > 0 && 1162261467 % n === 0;
};
```

```go
func isPowerOfThree(n int) bool {
    return n > 0 && 1162261467%n == 0
}
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
