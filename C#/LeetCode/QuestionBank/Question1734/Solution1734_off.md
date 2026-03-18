### [解码异或后的排列](https://leetcode.cn/problems/decode-xored-permutation/solutions/769140/jie-ma-yi-huo-hou-de-pai-lie-by-leetcode-9gw4/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：利用异或运算解码

这道题规定了数组 $perm$ 是前 $n$ 个正整数的排列，其中 $n$ 是**奇数**，只有充分利用给定的条件，才能得到答案。

为了得到原始数组 $perm$，应首先得到数组 $perm$ 的第一个元素（即下标为 $0$ 的元素），这也是最容易得到的。如果能得到数组 $perm$ 的全部元素的异或运算结果，以及数组 $perm$ 除了 $perm[0]$ 以外的全部元素的异或运算结果，即可得到 $perm[0]$ 的值。

由于数组 $perm$ 是前 $n$ 个正整数的排列，因此数组 $perm$ 的全部元素的异或运算结果即为从 $1$ 到 $n$ 的全部正整数的异或运算结果。用 $total$ 表示数组 $perm$ 的全部元素的异或运算结果，则有

$$\begin{array}{rcl}
    total & = & 1\oplus 2\oplus \dots \oplus n \\
          & = & perm[0]\oplus perm[1]\oplus \dots \oplus perm[n-1]
\end{array}$$

其中 $\oplus$ 是异或运算符。

如何得到数组 $perm$ 除了 $perm[0]$ 以外的全部元素的异或运算结果？由于 $n$ 是奇数，除了 $perm[0]$ 以外，数组 $perm$ 还有 $n-1$ 个其他元素，$n-1$ 是偶数，又由于数组 $encoded$ 的每个元素都是数组 $perm$ 的两个元素异或运算的结果，因此数组 $encoded$ 中存在 $2n-1$ 个元素，这些元素的异或运算的结果为数组 $perm$ 除了 $perm[0]$ 以外的全部元素的异或运算结果。

具体而言，数组 $encoded$ 的所有下标为奇数的元素的异或运算结果即为数组 $perm$ 除了 $perm[0]$ 以外的全部元素的异或运算结果。用 $odd$ 表示数组 $encoded$ 的所有下标为奇数的元素的异或运算结果，则有

$$\begin{array}{rcl}
    odd & = & encoded[1]\oplus encoded[3]\oplus \dots \oplus encoded[n-2] \\
        & = & perm[1]\oplus perm[2]\oplus \dots \oplus perm[n]
\end{array}$$

根据 $total$ 和 $odd$ 的值，即可计算得到 $perm[0]$ 的值：

$$\begin{array}{rcl}
    perm[0] & = & (perm[0]\oplus \dots \oplus perm[n])\oplus (perm[1]\oplus \dots \oplus perm[n]) \\
            & = & total\oplus odd
\end{array}$$

当 $1\le i<n$ 时，有 $encoded[i-1]=perm[i-1]\oplus perm[i]$。在等号两边同时异或 $perm[i-1]$，即可得到 $perm[i]=perm[i-1]\oplus encoded[i-1]$。计算过程见「[1720\. 解码异或后的数组的官方题解](https://leetcode.cn/problems/decode-xored-array/solution/jie-ma-yi-huo-hou-de-shu-zu-by-leetcode-yp0mg/)」。

由于 $perm[0]$ 已知，因此对 $i$ 从 $1$ 到 $n-1$ 依次计算 $perm[i]$ 的值，即可得到原始数组 $perm$。

```Java
class Solution {
    public int[] decode(int[] encoded) {
        int n = encoded.length + 1;
        int total = 0;
        for (int i = 1; i <= n; i++) {
            total ^= i;
        }
        int odd = 0;
        for (int i = 1; i < n - 1; i += 2) {
            odd ^= encoded[i];
        }
        int[] perm = new int[n];
        perm[0] = total ^ odd;
        for (int i = 0; i < n - 1; i++) {
            perm[i + 1] = perm[i] ^ encoded[i];
        }
        return perm;
    }
}
```

```CSharp
public class Solution {
    public int[] Decode(int[] encoded) {
        int n = encoded.Length + 1;
        int total = 0;
        for (int i = 1; i <= n; i++) {
            total ^= i;
        }
        int odd = 0;
        for (int i = 1; i < n - 1; i += 2) {
            odd ^= encoded[i];
        }
        int[] perm = new int[n];
        perm[0] = total ^ odd;
        for (int i = 0; i < n - 1; i++) {
            perm[i + 1] = perm[i] ^ encoded[i];
        }
        return perm;
    }
}
```

```JavaScript
var decode = function(encoded) {
    const n = encoded.length + 1;
    let total = 0;
    for (let i = 1; i <= n; i++) {
        total ^= i;
    }
    let odd = 0;
    for (let i = 1; i < n - 1; i += 2) {
        odd ^= encoded[i];
    }
    const perm = new Array(n).fill(0);
    perm[0] = total ^ odd;
    for (let i = 0; i < n - 1; i++) {
        perm[i + 1] = perm[i] ^ encoded[i];
    }
    return perm;
};
```

```Go
func decode(encoded []int) []int {
    n := len(encoded)
    total := 0
    for i := 1; i <= n+1; i++ {
        total ^= i
    }
    odd := 0
    for i := 1; i < n; i += 2 {
        odd ^= encoded[i]
    }
    perm := make([]int, n+1)
    perm[0] = total ^ odd
    for i, v := range encoded {
        perm[i+1] = perm[i] ^ v
    }
    return perm
}
```

```C++
class Solution {
public:
    vector<int> decode(vector<int>& encoded) {
        int n = encoded.size() + 1;
        int total = 0;
        for (int i = 1; i <= n; i++) {
            total ^= i;
        }
        int odd = 0;
        for (int i = 1; i < n - 1; i += 2) {
            odd ^= encoded[i];
        }
        vector<int> perm(n);
        perm[0] = total ^ odd;
        for (int i = 0; i < n - 1; i++) {
            perm[i + 1] = perm[i] ^ encoded[i];
        }
        return perm;
    }
};
```

```C
int* decode(int* encoded, int encodedSize, int* returnSize) {
    int n = encodedSize + 1;
    int total = 0;
    for (int i = 1; i <= n; i++) {
        total ^= i;
    }
    int odd = 0;
    for (int i = 1; i < n - 1; i += 2) {
        odd ^= encoded[i];
    }
    int* perm = malloc(sizeof(int) * n);
    *returnSize = n;
    perm[0] = total ^ odd;
    for (int i = 0; i < n - 1; i++) {
        perm[i + 1] = perm[i] ^ encoded[i];
    }
    return perm;
}
```

```Python
class Solution:
    def decode(self, encoded: List[int]) -> List[int]:
        n = len(encoded) + 1
        total = reduce(xor, range(1, n + 1))
        odd = 0
        for i in range(1, n - 1, 2):
            odd ^= encoded[i]

        perm = [total ^ odd]
        for i in range(n - 1):
            perm.append(perm[-1] ^ encoded[i])

        return perm
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是原始数组 $perm$ 的长度。计算 $total$ 和 $odd$ 各需要遍历长度为 $n-1$ 的数组 $encoded$ 一次，计算原数组 $perm$ 的每个元素值也需要遍历长度为 $n-1$ 的数组 $encoded$ 一次。
- 空间复杂度：$O(1)$。注意空间复杂度不考虑返回值。
