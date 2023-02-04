#### [方法四：动态规划——最低设置位](https://leetcode.cn/problems/counting-bits/solutions/627418/bi-te-wei-ji-shu-by-leetcode-solution-0t1i/)

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

-   时间复杂度：$O(n)$。对于每个整数，只需要 $O(1)$ 的时间计算「一比特数」。
-   空间复杂度：$O(1)$。除了返回的数组以外，空间复杂度为常数。
