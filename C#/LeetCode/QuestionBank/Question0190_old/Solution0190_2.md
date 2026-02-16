#### [方法一：逐位颠倒](https://leetcode.cn/problems/reverse-bits/solutions/685436/dian-dao-er-jin-zhi-wei-by-leetcode-solu-yhxz/)

**思路**

将 $n$ 视作一个长为 $32$ 的二进制串，从低位往高位枚举 $n$ 的每一位，将其倒序添加到翻转结果 $rev$ 中。

代码实现中，每枚举一位就将 $n$ 右移一位，这样当前 $n$ 的最低位就是我们要枚举的比特位。当 $n$ 为 $0$ 时即可结束循环。

需要注意的是，在某些语言（如 `Java`）中，没有无符号整数类型，因此对 $n$ 的右移操作应使用逻辑右移。

**代码**

```cpp
class Solution {
public:
    uint32_t reverseBits(uint32_t n) {
        uint32_t rev = 0;
        for (int i = 0; i < 32 && n > 0; ++i) {
            rev |= (n & 1) << (31 - i);
            n >>= 1;
        }
        return rev;
    }
};
```

```java
public class Solution {
    public int reverseBits(int n) {
        int rev = 0;
        for (int i = 0; i < 32 && n != 0; ++i) {
            rev |= (n & 1) << (31 - i);
            n >>>= 1;
        }
        return rev;
    }
}
```

```go
func reverseBits(n uint32) (rev uint32) {
    for i := 0; i < 32 && n > 0; i++ {
        rev |= n & 1 << (31 - i)
        n >>= 1
    }
    return
}
```

```javascript
var reverseBits = function(n) {
    let rev = 0;
    for (let i = 0; i < 32 && n > 0; ++i) {
        rev |= (n & 1) << (31 - i);
        n >>>= 1;
    }
    return rev >>> 0;
};
```

```c
uint32_t reverseBits(uint32_t n) {
    uint32_t rev = 0;
    for (int i = 0; i < 32 && n > 0; ++i) {
        rev |= (n & 1) << (31 - i);
        n >>= 1;
    }
    return rev;
}
```

**复杂度分析**

-   时间复杂度：$O(\log n)$。
-   空间复杂度：$O(1)$。
