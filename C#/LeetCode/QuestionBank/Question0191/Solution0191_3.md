﻿#### [方法二：位运算优化](https://leetcode.cn/problems/number-of-1-bits/solutions/672082/wei-1de-ge-shu-by-leetcode-solution-jnwf/)

**思路及解法**

观察这个运算：$n~\&~(n - 1)$，其运算结果恰为把 $n$ 的二进制位中的最低位的 $1$ 变为 $0$ 之后的结果。

如：$6~\&~(6-1) = 4, 6 = (110)_2, 4 = (100)_2$，运算结果 $4$ 即为把 $6$ 的二进制位中的最低位的 $1$ 变为 $0$ 之后的结果。

这样我们可以利用这个位运算的性质加速我们的检查过程，在实际代码中，我们不断让当前的 $n$ 与 $n - 1$ 做与运算，直到 $n$ 变为 $0$ 即可。因为每次运算会使得 $n$ 的最低位的 $1$ 被翻转，因此运算次数就等于 $n$ 的二进制位中 $1$ 的个数。

**代码**

```cpp
class Solution {
public:
    int hammingWeight(uint32_t n) {
        int ret = 0;
        while (n) {
            n &= n - 1;
            ret++;
        }
        return ret;
    }
};
```

```java
public class Solution {
    public int hammingWeight(int n) {
        int ret = 0;
        while (n != 0) {
            n &= n - 1;
            ret++;
        }
        return ret;
    }
}
```

```python
class Solution:
    def hammingWeight(self, n: int) -> int:
        ret = 0
        while n:
            n &= n - 1
            ret += 1
        return ret
```

```go
func hammingWeight(num uint32) (ones int) {
    for ; num > 0; num &= num - 1 {
        ones++
    }
    return
}
```

```javascript
var hammingWeight = function(n) {
    let ret = 0;
    while (n) {
        n &= n - 1;
        ret++;
    }
    return ret;
};
```

```c
int hammingWeight(uint32_t n) {
    int ret = 0;
    while (n) {
        n &= n - 1;
        ret++;
    }
    return ret;
}
```

**复杂度分析**

-   时间复杂度：$O(\log n)$。循环次数等于 $n$ 的二进制位中 $1$ 的个数，最坏情况下 $n$ 的二进制位全部为 $1$。我们需要循环 $\log n$ 次。
-   空间复杂度：$O(1)$，我们只需要常数的空间保存若干变量。