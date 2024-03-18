### [比特位计数](https://leetcode.cn/problems/counting-bits/solutions/627418/bi-te-wei-ji-shu-by-leetcode-solution-0t1i/)

#### 前言

这道题需要计算从 $0$ 到 $n$ 的每个整数的二进制表示中的 $1$ 的数目。

部分编程语言有相应的内置函数用于计算给定的整数的二进制表示中的 $1$ 的数目，例如 $Java$ 的 $Integer.bitCount$，$C++$ 的 $\_\_builtin\_popcount$，$Go$ 的 $bits.OnesCount$ 等，读者可以自行尝试。下列各种方法均为不使用内置函数的解法。

为了表述简洁，下文用「一比特数」表示二进制表示中的 $1$ 的数目。

#### 方法一：$Brian Kernighan$ 算法

最直观的做法是对从 $0$ 到 $n$ 的每个整数直接计算「一比特数」。每个 $int$ 型的数都可以用 $32$ 位二进制数表示，只要遍历其二进制表示的每一位即可得到 $1$ 的数目。

利用 $Brian Kernighan$ 算法，可以在一定程度上进一步提升计算速度。$Brian Kernighan$ 算法的原理是：对于任意整数 $x$，令 $x=x~\&~(x-1)$，该运算将 $x$ 的二进制表示的最后一个 $1$ 变成 $0$。因此，对 $x$ 重复该操作，直到 $x$ 变成 $0$，则操作次数即为 $x$ 的「一比特数」。

对于给定的 $n$，计算从 $0$ 到 $n$ 的每个整数的「一比特数」的时间都不会超过 $O(\log n)$，因此总时间复杂度为 $O(n \log n)$。

```java
class Solution {
    public int[] countBits(int n) {
        int[] bits = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            bits[i] = countOnes(i);
        }
        return bits;
    }

    public int countOnes(int x) {
        int ones = 0;
        while (x > 0) {
            x &= (x - 1);
            ones++;
        }
        return ones;
    }
}
```

```javascript
var countBits = function(n) {
    const bits = new Array(n + 1).fill(0);
    for (let i = 0; i <= n; i++) {
        bits[i] = countOnes(i);
    }
    return bits
};

const countOnes = (x) => {
    let ones = 0;
    while (x > 0) {
        x &= (x - 1);
        ones++;
    }
    return ones;
}
```

```go
func onesCount(x int) (ones int) {
    for ; x > 0; x &= x - 1 {
        ones++
    }
    return
}

func countBits(n int) []int {
    bits := make([]int, n+1)
    for i := range bits {
        bits[i] = onesCount(i)
    }
    return bits
}
```

```python
class Solution:
    def countBits(self, n: int) -> List[int]:
        def countOnes(x: int) -> int:
            ones = 0
            while x > 0:
                x &= (x - 1)
                ones += 1
            return ones
        
        bits = [countOnes(i) for i in range(n + 1)]
        return bits
```

```cpp
class Solution {
public:
    int countOnes(int x) {
        int ones = 0;
        while (x > 0) {
            x &= (x - 1);
            ones++;
        }
        return ones;
    }

    vector<int> countBits(int n) {
        vector<int> bits(n + 1);
        for (int i = 0; i <= n; i++) {
            bits[i] = countOnes(i);
        }
        return bits;
    }
};
```

```c
int countOnes(int x) {
    int ones = 0;
    while (x > 0) {
        x &= (x - 1);
        ones++;
    }
    return ones;
}

int* countBits(int n, int* returnSize) {
    int* bits = malloc(sizeof(int) * (n + 1));
    *returnSize = n + 1;
    for (int i = 0; i <= n; i++) {
        bits[i] = countOnes(i);
    }
    return bits;
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n)$。需要对从 $0$ 到 $n$ 的每个整数使用计算「一比特数」，对于每个整数计算「一比特数」的时间都不会超过 $O(\log n)$。
- 空间复杂度：$O(1)$。除了返回的数组以外，空间复杂度为常数。

#### 方法二：动态规划——最高有效位

方法一需要对每个整数使用 $O(\log n)$ 的时间计算「一比特数」。可以换一个思路，当计算 $i$ 的「一比特数」时，如果存在 $0 \le j < i$，$j$ 的「一比特数」已知，且 $i$ 和 $j$ 相比，$i$ 的二进制表示只多了一个 $1$，则可以快速得到 $i$ 的「一比特数」。

令 $bits[i]$ 表示 $i$ 的「一比特数」，则上述关系可以表示成：$bits[i]=bits[j]+1$。

对于正整数 $x$，如果可以知道最大的正整数 $y$，使得 $y \le x$ 且 $y$ 是 $2$ 的整数次幂，则 $y$ 的二进制表示中只有最高位是 $1$，其余都是 $0$，此时称 $y$ 为 $x$ 的「最高有效位」。令 $z=x−y$，显然 $0 \le z < x$，则 $bits[x] = bits[z] + 1$。

为了判断一个正整数是不是 $2$ 的整数次幂，可以利用方法一中提到的按位与运算的性质。如果正整数 $y$ 是 $2$ 的整数次幂，则 $y$ 的二进制表示中只有最高位是 $1$，其余都是 $0$，因此 $y~\&~(y-1) = 0$。由此可见，正整数 $y$ 是 $2$ 的整数次幂，当且仅当 $y~\&~(y-1) = 0$。

显然，$0$ 的「一比特数」为 $0$。使用 $highBit$ 表示当前的最高有效位，遍历从 $1$ 到 $n$ 的每个正整数 $i$，进行如下操作。

- 如果 $i~\&~(i-1) = 0$，则令 $highBit = i$，更新当前的最高有效位。
- $i$ 比 $i−highBit$ 的「一比特数」多 $1$，由于是从小到大遍历每个整数，因此遍历到 $i$ 时，$i−highBit$ 的「一比特数」已知，令 $bits[i] = bits[i−highBit] + 1$。

最终得到的数组 $bits$ 即为答案。

```java
class Solution {
    public int[] countBits(int n) {
        int[] bits = new int[n + 1];
        int highBit = 0;
        for (int i = 1; i <= n; i++) {
            if ((i & (i - 1)) == 0) {
                highBit = i;
            }
            bits[i] = bits[i - highBit] + 1;
        }
        return bits;
    }
}
```

```javascript
var countBits = function(n) {
    const bits = new Array(n + 1).fill(0);
    let highBit = 0;
    for (let i = 1; i <= n; i++) {
        if ((i & (i - 1)) == 0) {
            highBit = i;
        }
        bits[i] = bits[i - highBit] + 1;
    }
    return bits;
};
```

```go
func countBits(n int) []int {
    bits := make([]int, n+1)
    highBit := 0
    for i := 1; i <= n; i++ {
        if i&(i-1) == 0 {
            highBit = i
        }
        bits[i] = bits[i-highBit] + 1
    }
    return bits
}
```

```python
class Solution:
    def countBits(self, n: int) -> List[int]:
        bits = [0]
        highBit = 0
        for i in range(1, n + 1):
            if i & (i - 1) == 0:
                highBit = i
            bits.append(bits[i - highBit] + 1)
        return bits
```

```cpp
class Solution {
public:
    vector<int> countBits(int n) {
        vector<int> bits(n + 1);
        int highBit = 0;
        for (int i = 1; i <= n; i++) {
            if ((i & (i - 1)) == 0) {
                highBit = i;
            }
            bits[i] = bits[i - highBit] + 1;
        }
        return bits;
    }
};
```

```c
int* countBits(int n, int* returnSize) {
    int* bits = malloc(sizeof(int) * (n + 1));
    *returnSize = n + 1;
    bits[0] = 0;
    int highBit = 0;
    for (int i = 1; i <= n; i++) {
        if ((i & (i - 1)) == 0) {
            highBit = i;
        }
        bits[i] = bits[i - highBit] + 1;
    }
    return bits;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。对于每个整数，只需要 $O(1)$ 的时间计算「一比特数」。
- 空间复杂度：$O(1)$。除了返回的数组以外，空间复杂度为常数。

#### 方法三：动态规划——最低有效位

方法二需要实时维护最高有效位，当遍历到的数是 $2$ 的整数次幂时，需要更新最高有效位。如果再换一个思路，可以使用「最低有效位」计算「一比特数」。

对于正整数 $x$，将其二进制表示右移一位，等价于将其二进制表示的最低位去掉，得到的数是 $\lfloor \frac{x}{2} \rfloor$。如果 $bits \big[\lfloor \frac{x}{2} \rfloor\big]$ 的值已知，则可以得到 $bits[x]$ 的值：

- 如果 $x$ 是偶数，则 $bits[x] = bits \big[\lfloor \frac{x}{2} \rfloor\big]$；
- 如果 $x$ 是奇数，则 $bits[x] = bits \big[\lfloor \frac{x}{2} \rfloor\big] + 1$。

上述两种情况可以合并成：$bits[x]$ 的值等于 $bits \big[\lfloor \frac{x}{2} \rfloor\big]$ 的值加上 $x$ 除以 $2$ 的余数。

由于 $\lfloor \frac{x}{2} \rfloor$ 可以通过 $x >> 1$ 得到，$x$ 除以 $2$ 的余数可以通过 $x~\&~1$ 得到，因此有：$bits[x] = bits[x>>1] + (x~\&~1)$。

遍历从 $1$ 到 $n$ 的每个正整数 $i$，计算 $bits$ 的值。最终得到的数组 $bits$ 即为答案。

```java
class Solution {
    public int[] countBits(int n) {
        int[] bits = new int[n + 1];
        for (int i = 1; i <= n; i++) {
            bits[i] = bits[i >> 1] + (i & 1);
        }
        return bits;
    }
}
```

```javascript
var countBits = function(n) {
    const bits = new Array(n + 1).fill(0);
    for (let i = 1; i <= n; i++) {
        bits[i] = bits[i >> 1] + (i & 1);
    }
    return bits;
};
```

```go
func countBits(n int) []int {
    bits := make([]int, n+1)
    for i := 1; i <= n; i++ {
        bits[i] = bits[i>>1] + i&1
    }
    return bits
}
```

```python
class Solution:
    def countBits(self, n: int) -> List[int]:
        bits = [0]
        for i in range(1, n + 1):
            bits.append(bits[i >> 1] + (i & 1))
        return bits
```

```cpp
class Solution {
public:
    vector<int> countBits(int n) {
        vector<int> bits(n + 1);
        for (int i = 1; i <= n; i++) {
            bits[i] = bits[i >> 1] + (i & 1);
        }
        return bits;
    }
};
```

```c
int* countBits(int n, int* returnSize) {
    int* bits = malloc(sizeof(int) * (n + 1));
    *returnSize = n + 1;
    bits[0] = 0;
    for (int i = 1; i <= n; i++) {
        bits[i] = bits[i >> 1] + (i & 1);
    }
    return bits;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。对于每个整数，只需要 $O(1)$ 的时间计算「一比特数」。
- 空间复杂度：$O(1)$。除了返回的数组以外，空间复杂度为常数。

#### 方法四：动态规划——最低设置位

定义正整数 $x$ 的「最低设置位」为 $x$ 的二进制表示中的最低的 $1$ 所在位。例如，$10$ 的二进制表示是 $1010_{(2)}$，其最低设置位为 $2$，对应的二进制表示是 $10_{(2)}$。

令 $y = x~\&~(x-1)$，则 $y$ 为将 $x$ 的最低设置位从 $1$ 变成 $0$ 之后的数，显然 $0 \le y < x$，$bits[x] = bits[y] + 1$。因此对任意正整数 $x$，都有 $bits[x] = bits[x~\&~(x-1)] + 1$。

遍历从 $1$ 到 $n$ 的每个正整数 $i$，计算 $bits$ 的值。最终得到的数组 $bits$ 即为答案。

```java
class Solution {
    public int[] countBits(int n) {
        int[] bits = new int[n + 1];
        for (int i = 1; i <= n; i++) {
            bits[i] = bits[i & (i - 1)] + 1;
        }
        return bits;
    }
}
```

```javascript
var countBits = function(n) {
    const bits = new Array(n + 1).fill(0);
    for (let i = 1; i <= n; i++) {
        bits[i] = bits[i & (i - 1)] + 1;
    }
    return bits;
};
```

```go
func countBits(n int) []int {
    bits := make([]int, n+1)
    for i := 1; i <= n; i++ {
        bits[i] = bits[i&(i-1)] + 1
    }
    return bits
}
```

```python
class Solution:
    def countBits(self, n: int) -> List[int]:
        bits = [0]
        for i in range(1, n + 1):
            bits.append(bits[i & (i - 1)] + 1)
        return bits
```

```cpp
class Solution {
public:
    vector<int> countBits(int n) {
        vector<int> bits(n + 1);
        for (int i = 1; i <= n; i++) {
            bits[i] = bits[i & (i - 1)] + 1;
        }
        return bits;
    }
};
```

```c
int* countBits(int n, int* returnSize) {
    int* bits = malloc(sizeof(int) * (n + 1));
    *returnSize = n + 1;
    bits[0] = 0;
    for (int i = 1; i <= n; i++) {
        bits[i] = bits[i & (i - 1)] + 1;
    }
    return bits;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。对于每个整数，只需要 $O(1)$ 的时间计算「一比特数」。
- 空间复杂度：$O(1)$。除了返回的数组以外，空间复杂度为常数。
