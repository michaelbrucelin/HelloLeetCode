#### [方法一：二进制表示](https://leetcode.cn/problems/power-of-two/solutions/796201/2de-mi-by-leetcode-solution-rny3/)

**思路与算法**

一个数 $n$ 是 $2$ 的幂，当且仅当 $n$ 是正整数，并且 $n$ 的二进制表示中仅包含 $1$ 个 $1$。

因此我们可以考虑使用位运算，将 $n$ 的二进制表示中最低位的那个 $1$ 提取出来，再判断剩余的数值是否为 $0$ 即可。下面介绍两种常见的与「二进制表示中最低位」相关的位运算技巧。

第一个技巧是

$$n \& (n - 1)$$

其中 $\&$ 表示按位与运算。该位运算技巧可以直接将 $n$ 二进制表示的最低位 $1$ 移除，它的原理如下：

> 假设 $n$ 的二进制表示为 $(a 10 \cdots 0)_2$，其中 $a$ 表示若干个高位，$1$ 表示最低位的那个 $1$，$0 \cdots 0$ 表示后面的若干个 $0$，那么 $n−1$ 的二进制表示为：
> 
> $$(a 01 \cdots 1)_2$$
> 
> 我们将 $(a 10 \cdots 0)_2$ 与 $(a 01 \cdots 1)_2$ 进行按位与运算，高位 $a$ 不变，在这之后的所有位都会变为 $0$，这样我们就将最低位的那个 $1$ 移除了。

因此，如果 $n$ 是正整数并且 $n \& (n - 1) = 0$，那么 $n$ 就是 $2$ 的幂。

第二个技巧是

$$n \& (-n)$$

其中 $-n$ 是 $n$ 的相反数，是一个负数。该位运算技巧可以直接获取 $n$ 二进制表示的最低位的 $1$。

由于负数是按照补码规则在计算机中存储的，$-n$ 的二进制表示为 $n$ 的二进制表示的每一位取反再加上 $1$，因此它的原理如下：

> 假设 $n$ 的二进制表示为 $(a 10 \cdots 0)_2$，其中 $a$ 表示若干个高位，$1$ 表示最低位的那个 $1$，$0 \cdots 0$ 表示后面的若干个 $0$，那么 $-n$ 的二进制表示为：
> 
> $$(\bar{a} 01 \cdots 1)_2 + (1)_2 = (\bar{a} 10 \cdots 0)_2$$
> 
> 其中 $\bar{a}$ 表示将 $a$ 每一位取反。我们将 $(a 10 \cdots 0)_2$ 与 $(\bar{a} 10 \cdots 0)_2$ 进行按位与运算，高位全部变为 $0$，最低位的 $1$ 以及之后的所有 $0$ 不变，这样我们就获取了 $n$ 二进制表示的最低位的 $1$。

因此，如果 $n$ 是正整数并且 $n \& (-n) = n$，那么 $n$ 就是 $2$ 的幂。

**代码**

下面分别给出两种位运算技巧对应的代码。 **在一些语言中，位运算的优先级较低，需要注意运算顺序**。

```cpp
class Solution {
public:
    bool isPowerOfTwo(int n) {
        return n > 0 && (n & (n - 1)) == 0;
    }
};
```

```java
class Solution {
    public boolean isPowerOfTwo(int n) {
        return n > 0 && (n & (n - 1)) == 0;
    }
}
```

```csharp
public class Solution {
    public bool IsPowerOfTwo(int n) {
        return n > 0 && (n & (n - 1)) == 0;
    }
}
```

```python
class Solution:
    def isPowerOfTwo(self, n: int) -> bool:
        return n > 0 and (n & (n - 1)) == 0
```

```javascript
var isPowerOfTwo = function(n) {
    return n > 0 && (n & (n - 1)) === 0;
};
```

```go
func isPowerOfTwo(n int) bool {
    return n > 0 && n&(n-1) == 0
}
```

```c
bool isPowerOfTwo(int n) {
    return n > 0 && (n & (n - 1)) == 0;
}
```

---

```cpp
class Solution {
public:
    bool isPowerOfTwo(int n) {
        return n > 0 && (n & -n) == n;
    }
};
```

```java
class Solution {
    public boolean isPowerOfTwo(int n) {
        return n > 0 && (n & -n) == n;
    }
}
```

```csharp
public class Solution {
    public bool IsPowerOfTwo(int n) {
        return n > 0 && (n & -n) == n;
    }
}
```

```python
class Solution:
    def isPowerOfTwo(self, n: int) -> bool:
        return n > 0 and (n & -n) == n
```

```javascript
var isPowerOfTwo = function(n) {
    return n > 0 && (n & -n) === n;
};
```

```go
func isPowerOfTwo(n int) bool {
    return n > 0 && n&-n == n
}
```

```c
bool isPowerOfTwo(int n) {
    return n > 0 && (n & -n) == n;
}
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
