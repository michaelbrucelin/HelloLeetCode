#### [方法三：动态规划——最低有效位](https://leetcode.cn/problems/counting-bits/solutions/627418/bi-te-wei-ji-shu-by-leetcode-solution-0t1i/)

方法二需要实时维护最高有效位，当遍历到的数是 $2$ 的整数次幂时，需要更新最高有效位。如果再换一个思路，可以使用「最低有效位」计算「一比特数」。

对于正整数 $x$，将其二进制表示右移一位，等价于将其二进制表示的最低位去掉，得到的数是 $\lfloor \frac{x}{2} \rfloor$。如果 $bits \big[\lfloor \frac{x}{2} \rfloor\big]$ 的值已知，则可以得到 $bits[x]$ 的值：

-   如果 $x$ 是偶数，则 $bits[x] = bits \big[\lfloor \frac{x}{2} \rfloor\big]$；
-   如果 $x$ 是奇数，则 $bits[x] = bits \big[\lfloor \frac{x}{2} \rfloor\big] + 1$。

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

-   时间复杂度：$O(n)$。对于每个整数，只需要 $O(1)$ 的时间计算「一比特数」。
-   空间复杂度：$O(1)$。除了返回的数组以外，空间复杂度为常数。
