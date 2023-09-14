### [二进制表示中质数个计算置位](https://leetcode.cn/problems/prime-number-of-set-bits-in-binary-representation/solutions/1389365/er-jin-zhi-biao-shi-zhong-zhi-shu-ge-ji-jy35g/)

#### 方法一：数学 + 位运算

我们可以枚举 $[left,right]$ 范围内的每个整数，挨个判断是否满足题目要求。

对于每个数 $x$，我们需要解决两个问题：

1.  如何求出 $x$ 的二进制中的 $1$ 的个数，见「[191\. 位 1 的个数](https://leetcode-cn.com/problems/number-of-1-bits/)」，下面代码用库函数实现；
2.  如何判断一个数是否为质数，见「[204\. 计数质数](https://leetcode-cn.com/problems/count-primes/)」的「[官方解法](https://leetcode-cn.com/problems/count-primes/solution/ji-shu-zhi-shu-by-leetcode-solution/)」的方法一（注意 $0$ 和 $1$ 不是质数）。

```python
class Solution:
    def isPrime(self, x: int) -> bool:
        if x < 2:
            return False
        i = 2
        while i * i <= x:
            if x % i == 0:
                return False
            i += 1
        return True

    def countPrimeSetBits(self, left: int, right: int) -> int:
        return sum(self.isPrime(x.bit_count()) for x in range(left, right + 1))
```

```cpp
class Solution {
    bool isPrime(int x) {
        if (x < 2) {
            return false;
        }
        for (int i = 2; i * i <= x; ++i) {
            if (x % i == 0) {
                return false;
            }
        }
        return true;
    }

public:
    int countPrimeSetBits(int left, int right) {
        int ans = 0;
        for (int x = left; x <= right; ++x) {
            if (isPrime(__builtin_popcount(x))) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int countPrimeSetBits(int left, int right) {
        int ans = 0;
        for (int x = left; x <= right; ++x) {
            if (isPrime(Integer.bitCount(x))) {
                ++ans;
            }
        }
        return ans;
    }

    private boolean isPrime(int x) {
        if (x < 2) {
            return false;
        }
        for (int i = 2; i * i <= x; ++i) {
            if (x % i == 0) {
                return false;
            }
        }
        return true;
    }
}
```

```csharp
public class Solution {
    public int CountPrimeSetBits(int left, int right) {
        int ans = 0;
        for (int x = left; x <= right; ++x) {
            if (IsPrime(BitCount(x))) {
                ++ans;
            }
        }
        return ans;
    }

    private bool IsPrime(int x) {
        if (x < 2) {
            return false;
        }
        for (int i = 2; i * i <= x; ++i) {
            if (x % i == 0) {
                return false;
            }
        }
        return true;
    }

    private static int BitCount(int i) {
        i = i - ((i >> 1) & 0x55555555);
        i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
        i = (i + (i >> 4)) & 0x0f0f0f0f;
        i = i + (i >> 8);
        i = i + (i >> 16);
        return i & 0x3f;
    }
}
```

```go
func isPrime(x int) bool {
    if x < 2 {
        return false
    }
    for i := 2; i*i <= x; i++ {
        if x%i == 0 {
            return false
        }
    }
    return true
}

func countPrimeSetBits(left, right int) (ans int) {
    for x := left; x <= right; x++ {
        if isPrime(bits.OnesCount(uint(x))) {
            ans++
        }
    }
    return
}
```

```c
bool isPrime(int x) {
    if (x < 2) {
        return false;
    }
    for (int i = 2; i * i <= x; ++i) {
        if (x % i == 0) {
            return false;
        }
    }
    return true;
}

int countPrimeSetBits(int left, int right){
    int ans = 0;
    for (int x = left; x <= right; ++x) {
        if (isPrime(__builtin_popcount(x))) {
            ++ans;
        }
    }
    return ans;
}
```

```javascript
var countPrimeSetBits = function(left, right) {
    let ans = 0;
    for (let x = left; x <= right; ++x) {
        if (isPrime(bitCount(x))) {
            ++ans;
        }
    }
    return ans;
};

const isPrime = (x) => {
    if (x < 2) {
        return false;
    }
    for (let i = 2; i * i <= x; ++i) {
        if (x % i === 0) {
            return false;
        }
    }
    return true;
}

const bitCount = (x) => {
    return x.toString(2).split('0').join('').length;
}
```

**复杂度分析**

-   时间复杂度：$O((right-left)\sqrt{\log right})$。二进制中 $1$ 的个数为 $O(\log right)$，判断值为 $x$ 的数是否为质数的时间为 $O(\sqrt{x})$。
-   空间复杂度：$O(1)$。我们只需要常数的空间保存若干变量。

#### 方法二：判断质数优化

注意到 $right \le 10^6 < 2^{20}$，因此二进制中 $1$ 的个数不会超过 $19$，而不超过 $19$ 的质数只有

$$2, 3, 5, 7, 11, 13, 17, 19$$

我们可以用一个二进制数 $mask=665772=10100010100010101100_{2}$ 来存储这些质数，其中 $mask$ 二进制的从低到高的第 $i$ 位为 $1$ 表示 $i$ 是质数，为 $0$ 表示 $i$ 不是质数。

设整数 $x$ 的二进制中 $1$ 的个数为 $c$，若 $mask$ 按位与 $2^c$ 不为 $0$，则说明 $c$ 是一个质数。

```python
class Solution:
    def countPrimeSetBits(self, left: int, right: int) -> int:
        return sum(((1 << x.bit_count()) & 665772) != 0 for x in range(left, right + 1))
```

```cpp
class Solution {
public:
    int countPrimeSetBits(int left, int right) {
        int ans = 0;
        for (int x = left; x <= right; ++x) {
            if ((1 << __builtin_popcount(x)) & 665772) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int countPrimeSetBits(int left, int right) {
        int ans = 0;
        for (int x = left; x <= right; ++x) {
            if (((1 << Integer.bitCount(x)) & 665772) != 0) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int CountPrimeSetBits(int left, int right) {
        int ans = 0;
        for (int x = left; x <= right; ++x) {
            if (((1 << BitCount(x)) & 665772) != 0) {
                ++ans;
            }
        }
        return ans;
    }

    private static int BitCount(int i) {
        i = i - ((i >> 1) & 0x55555555);
        i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
        i = (i + (i >> 4)) & 0x0f0f0f0f;
        i = i + (i >> 8);
        i = i + (i >> 16);
        return i & 0x3f;
    }
}
```

```go
func countPrimeSetBits(left, right int) (ans int) {
    for x := left; x <= right; x++ {
        if 1<<bits.OnesCount(uint(x))&665772 != 0 {
            ans++
        }
    }
    return
}
```

```c
int countPrimeSetBits(int left, int right){
    int ans = 0;
    for (int x = left; x <= right; ++x) {
        if ((1 << __builtin_popcount(x)) & 665772) {
            ++ans;
        }
    }
    return ans;
}
```

```javascript
var countPrimeSetBits = function(left, right) {
    let ans = 0;
    for (let x = left; x <= right; ++x) {
        if (((1 << bitCount(x)) & 665772) != 0) {
            ++ans;
        }
    }
    return ans;
};

const bitCount = (x) => {
    return x.toString(2).split('0').join('').length;
}
```

**复杂度分析**

-   时间复杂度：$O(right-left)$。
-   空间复杂度：$O(1)$。我们只需要常数的空间保存若干变量。
