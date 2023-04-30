#### [前言](https://leetcode.cn/problems/counting-bits/solutions/627418/bi-te-wei-ji-shu-by-leetcode-solution-0t1i/)

这道题需要计算从 $0$ 到 $n$ 的每个整数的二进制表示中的 $1$ 的数目。

部分编程语言有相应的内置函数用于计算给定的整数的二进制表示中的 $1$ 的数目，例如 $Java$ 的 $Integer.bitCount$，$C++$ 的 $\_\_builtin\_popcount$，$Go$ 的 $bits.OnesCount$ 等，读者可以自行尝试。下列各种方法均为不使用内置函数的解法。

为了表述简洁，下文用「一比特数」表示二进制表示中的 $1$ 的数目。

#### [方法一：$Brian Kernighan$ 算法](https://leetcode.cn/problems/counting-bits/solutions/627418/bi-te-wei-ji-shu-by-leetcode-solution-0t1i/)

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

-   时间复杂度：$O(n \log n)$。需要对从 $0$ 到 $n$ 的每个整数使用计算「一比特数」，对于每个整数计算「一比特数」的时间都不会超过 $O(\log n)$。
-   空间复杂度：$O(1)$。除了返回的数组以外，空间复杂度为常数。
