#### 方法一：[循环检查二进制位](https://leetcode.cn/problems/number-of-1-bits/solutions/672082/wei-1de-ge-shu-by-leetcode-solution-jnwf/)

**思路及解法**

我们可以直接循环检查给定整数 $n$ 的二进制位的每一位是否为 $1$。

具体代码中，当检查第 $i$ 位时，我们可以让 $n$ 与 $2^i$ 进行与运算，当且仅当 $n$ 的第 $i$ 位为 $1$ 时，运算结果不为 $0$。

**代码**

```cpp
class Solution {
public:
    int hammingWeight(uint32_t n) {
        int ret = 0;
        for (int i = 0; i < 32; i++) {
            if (n & (1 << i)) {
                ret++;
            }
        }
        return ret;
    }
};
```

```java
public class Solution {
    public int hammingWeight(int n) {
        int ret = 0;
        for (int i = 0; i < 32; i++) {
            if ((n & (1 << i)) != 0) {
                ret++;
            }
        }
        return ret;
    }
}
```

```python
class Solution:
    def hammingWeight(self, n: int) -> int:
        ret = sum(1 for i in range(32) if n & (1 << i)) 
        return ret
```

```go
func hammingWeight(num uint32) (ones int) {
    for i := 0; i < 32; i++ {
        if 1<<i&num > 0 {
            ones++
        }
    }
    return
}
```

```javascript
var hammingWeight = function(n) {
    let ret = 0;
    for (let i = 0; i < 32; i++) {
        if ((n & (1 << i)) !== 0) {
            ret++;
        }
    }
    return ret;
};
```

```c
int hammingWeight(uint32_t n) {
    int ret = 0;
    for (int i = 0; i < 32; i++) {
        if (n & (1u << i)) {
            ret++;
        }
    }
    return ret;
}
```

**复杂度分析**

-   时间复杂度：$O(k)$，其中 $k$ 是 $int$ 型的二进制位数，$k=32$。我们需要检查 $n$ 的二进制位的每一位，一共需要检查 $32$ 位。
-   空间复杂度：$O(1)$，我们只需要常数的空间保存若干变量。
