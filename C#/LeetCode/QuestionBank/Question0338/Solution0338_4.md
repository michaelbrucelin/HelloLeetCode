#### [方法二：动态规划——最高有效位](https://leetcode.cn/problems/counting-bits/solutions/627418/bi-te-wei-ji-shu-by-leetcode-solution-0t1i/)

方法一需要对每个整数使用 $O(\log n)$ 的时间计算「一比特数」。可以换一个思路，当计算 $i$ 的「一比特数」时，如果存在 $0 \le j < i$，$j$ 的「一比特数」已知，且 $i$ 和 $j$ 相比，$i$ 的二进制表示只多了一个 $1$，则可以快速得到 $i$ 的「一比特数」。

令 $bits[i]$ 表示 $i$ 的「一比特数」，则上述关系可以表示成：$bits[i]=bits[j]+1$。

对于正整数 $x$，如果可以知道最大的正整数 $y$，使得 $y \le x$ 且 $y$ 是 $2$ 的整数次幂，则 $y$ 的二进制表示中只有最高位是 $1$，其余都是 $0$，此时称 $y$ 为 $x$ 的「最高有效位」。令 $z=x−y$，显然 $0 \le z < x$，则 $bits[x] = bits[z] + 1$。

为了判断一个正整数是不是 $2$ 的整数次幂，可以利用方法一中提到的按位与运算的性质。如果正整数 $y$ 是 $2$ 的整数次幂，则 $y$ 的二进制表示中只有最高位是 $1$，其余都是 $0$，因此 $y~\&~(y-1) = 0$。由此可见，正整数 $y$ 是 $2$ 的整数次幂，当且仅当 $y~\&~(y-1) = 0$。

显然，$0$ 的「一比特数」为 $0$。使用 $highBit$ 表示当前的最高有效位，遍历从 $1$ 到 $n$ 的每个正整数 $i$，进行如下操作。

-   如果 $i~\&~(i-1) = 0$，则令 $highBit = i$，更新当前的最高有效位。
-   $i$ 比 $i−highBit$ 的「一比特数」多 $1$，由于是从小到大遍历每个整数，因此遍历到 $i$ 时，$i−highBit$ 的「一比特数」已知，令 $bits[i] = bits[i−highBit] + 1$。

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

-   时间复杂度：$O(n)$。对于每个整数，只需要 $O(1)$ 的时间计算「一比特数」。
-   空间复杂度：$O(1)$。除了返回的数组以外，空间复杂度为常数。