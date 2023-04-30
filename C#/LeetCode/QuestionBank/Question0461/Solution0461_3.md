#### [方法二：移位实现位计数](https://leetcode.cn/problems/hamming-distance/solutions/797339/yi-ming-ju-chi-by-leetcode-solution-u1w7/)

**思路及算法**

在锻炼算法能力时，重复造轮子是不可避免的，也是应当的。因此读者们也需要尝试使用各种方法自己实现几个具有位计数功能的函数。本方法将使用位运算中移位的操作实现位计数功能。

![](./assets/img/Solution0461_3_01.png)

具体地，记 $s = x \oplus y$，我们可以不断地检查 $s$ 的最低位，如果最低位为 $1$，那么令计数器加一，然后我们令 $s$ 整体右移一位，这样 $s$ 的最低位将被舍去，原本的次低位就变成了新的最低位。我们重复这个过程直到 $s=0$ 为止。这样计数器中就累计了 $s$ 的二进制表示中 $1$ 的数量。

**代码**

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

**复杂度分析**

-   时间复杂度：$O(\log C)$，其中 $C$ 是元素的数据范围，在本题中 $\log C=\log 2^{31} = 31$。
-   空间复杂度：$O(1)$。
