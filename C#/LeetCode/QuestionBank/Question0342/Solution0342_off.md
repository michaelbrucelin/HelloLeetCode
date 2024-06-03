### [4的幂](https://leetcode.cn/problems/power-of-four/solutions/798268/4de-mi-by-leetcode-solution-b3ya/)

#### 前言

如果 $n$ 是 $4$ 的幂，那么 $n$ 一定也是 $2$ 的幂。因此我们可以首先判断 $n$ 是否是 $2$ 的幂，在此基础上再判断 $n$ 是否是 $4$ 的幂。

判断 $n$ 是否是 $2$ 的幂可以参考「[231\. 2的幂的官方题解](https://leetcode-cn.com/problems/power-of-two/solution/2de-mi-by-leetcode-solution-rny3/)」。由于这一步的方法有很多种，在下面的题解中，我们使用

$$n \& (n - 1)$$

这一方法进行判断。

#### [方法一：二进制表示中 $1$ 的位置](https://leetcode.cn/problems/power-of-four/solutions/798268/4de-mi-by-leetcode-solution-b3ya/)

**思路与算法**

如果 $n$ 是 $4$ 的幂，那么 $n$ 的二进制表示中有且仅有一个 $1$，并且这个 $1$ 出现在从低位开始的第**偶数**个二进制位上（这是因为这个 $1$ 后面必须有偶数个 $0$）。这里我们规定最低位为第 $0$ 位，例如 $n=16$ 时，$n$ 的二进制表示为

$$(10000)_2$$

唯一的 $1$ 出现在第 $4$ 个二进制位上，因此 $n$ 是 $4$ 的幂。

由于题目保证了 $n$ 是一个 $32$ 位的有符号整数，因此我们可以构造一个整数 $mask$，它的所有偶数二进制位都是 $0$，所有奇数二进制位都是 $1$。这样一来，我们将 $n$ 和 $mask$ 进行按位与运算，如果结果为 $0$，说明 $n$ 二进制表示中的 $1$ 出现在偶数的位置，否则说明其出现在奇数的位置。

根据上面的思路，$mask$ 的二进制表示为：

$$mask = (10101010101010101010101010101010)_2$$

我们也可以将其表示成 $16$ 进制的形式，使其更加美观：

$$mask = (AAAAAAAA)_{16}$$

**代码**

```cpp
class Solution {
public:
    bool isPowerOfFour(int n) {
        return n > 0 && (n & (n - 1)) == 0 && (n & 0xaaaaaaaa) == 0;
    }
};
```

```java
class Solution {
    public boolean isPowerOfFour(int n) {
        return n > 0 && (n & (n - 1)) == 0 && (n & 0xaaaaaaaa) == 0;
    }
}
```

```csharp
public class Solution {
    public bool IsPowerOfFour(int n) {
        return n > 0 && (n & (n - 1)) == 0 && (n & 0xaaaaaaaa) == 0;
    }
}
```

```python
class Solution:
    def isPowerOfFour(self, n: int) -> bool:
        return n > 0 and (n & (n - 1)) == 0 and (n & 0xaaaaaaaa) == 0
```

```javascript
var isPowerOfFour = function(n) {
    return n > 0 && (n & (n - 1)) === 0 && (n & 0xaaaaaaaa) === 0;
};
```

```go
func isPowerOfFour(n int) bool {
    return n > 0 && n&(n-1) == 0 && n&0xaaaaaaaa == 0
}
```

```c
bool isPowerOfFour(int n) {
    return n > 0 && (n & (n - 1)) == 0 && (n & 0xaaaaaaaa) == 0;
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。

**思考**

事实上，我们令：

$$mask = (2AAAAAAA)_{16}$$

也可以使得上面的判断满足要求，读者可以思考其中的原因。

**提示：** $n$ 是一个「有符号」的 $32$ 位整数。

#### 方法二：取模性质

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

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
