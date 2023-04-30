#### [方法二：数学](https://leetcode.cn/problems/perfect-number/solutions/1179051/wan-mei-shu-by-leetcode-solution-d5pw/)

根据欧几里得-欧拉定理，每个偶完全数都可以写成

$$2^{p-1}(2^p-1)$$

的形式，其中 $p$ 为素数且 $2^p-1$ 为素数。

由于目前奇完全数还未被发现，因此题目范围 $[1,10^8]$ 内的完全数都可以写成上述形式。

这一共有如下 $5$ 个：

$$6, 28, 496, 8128, 33550336$$

```python
class Solution:
    def checkPerfectNumber(self, num: int) -> bool:
        return num == 6 or num == 28 or num == 496 or num == 8128 or num == 33550336
```

```cpp
class Solution {
public:
    bool checkPerfectNumber(int num) {
        return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336;
    }
};
```

```java
class Solution {
    public boolean checkPerfectNumber(int num) {
        return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336;
    }
}
```

```csharp
public class Solution {
    public bool CheckPerfectNumber(int num) {
        return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336;
    }
}
```

```go
func checkPerfectNumber(num int) bool {
    return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336
}
```

```c
bool checkPerfectNumber(int num){
    return num == 6 || num == 28 || num == 496 || num == 8128 || num == 33550336;
}
```

```javascript
var checkPerfectNumber = function(num) {
    return num === 6 || num === 28 || num === 496 || num === 8128 || num === 33550336;
};
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
