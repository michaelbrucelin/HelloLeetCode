### [解码异或后的数组](https://leetcode.cn/problems/decode-xored-array/solutions/759855/jie-ma-yi-huo-hou-de-shu-zu-by-leetcode-yp0mg/)

#### 方法一：利用异或运算的性质

原数组 $arr$ 的长度为 $n$，对 $arr$ 编码后得到长度为 $n-1$ 的数组 $encoded$，编码规则为：$encoded[i]=arr[i] \oplus arr[i+1]$，其中 $\oplus$ 是异或运算符，$0 \le i<n-1$。

已知编码后的数组 $encoded$ 和原数组 $arr$ 的第一个元素 $arr[0]=first$，需要解码得到原数组 $arr$。可以利用异或运算的性质实现。

异或运算具有如下性质：

- 异或运算满足交换律和结合律；
- 任意整数和自身做异或运算的结果都等于 0，即 $x \oplus x=0$；
- 任意整数和 0 做异或运算的结果都等于其自身，即 $x \oplus 0=0 \oplus x=x$。

当 $1 \le i<n$ 时，有 $encoded[i-1]=arr[i-1] \oplus arr[i]$。在等号两边同时异或 $arr[i-1]$，可以得到 $arr[i]=arr[i-1] \oplus encoded[i-1]$，计算过程如下：

$$\begin{array}{rll}encoded[i-1] & = & arr[i-1] \oplus arr[i] \\ encoded[i-1] \oplus arr[i-1] & = & arr[i-1] \oplus arr[i] \oplus arr[i-1] \\ arr[i-1] \oplus encoded[i-1] & = & arr[i-1] \oplus arr[i-1] \oplus arr[i]​ \\ arr[i-1] \oplus encoded[i-1] & =& 0 \oplus arr[i] \\ arr[i-1] \oplus encoded[i-1] & =& arr[i]\end{array}$$

因此当 $1 \le i<n$ 时，有 $arr[i]=arr[i-1] \oplus encoded[i-1]$。

由于 $arr[0]=first$ 已知，因此对 $i$ 从 $1$ 到 $n-1$ 依次计算 $arr[i]$ 的值，即可解码得到原数组 $arr$。

```Java
class Solution {
    public int[] decode(int[] encoded, int first) {
        int n = encoded.length + 1;
        int[] arr = new int[n];
        arr[0] = first;
        for (int i = 1; i < n; i++) {
            arr[i] = arr[i - 1] ^ encoded[i - 1];
        }
        return arr;
    }
}
```

```CSharp
public class Solution {
    public int[] Decode(int[] encoded, int first) {
        int n = encoded.Length + 1;
        int[] arr = new int[n];
        arr[0] = first;
        for (int i = 1; i < n; i++) {
            arr[i] = arr[i - 1] ^ encoded[i - 1];
        }
        return arr;
    }
}
```

```JavaScript
var decode = function(encoded, first) {
    const n = encoded.length + 1;
    const arr = new Array(n).fill(0);
    arr[0] = first;
    for (let i = 1; i < n; i++) {
        arr[i] = arr[i - 1] ^ encoded[i - 1];
    }
    return arr;
};
```

```Go
func decode(encoded []int, first int) []int {
    ans := make([]int, len(encoded)+1)
    ans[0] = first
    for i, e := range encoded {
        ans[i+1] = ans[i] ^ e
    }
    return ans
}
```

```Python
class Solution:
    def decode(self, encoded: List[int], first: int) -> List[int]:
        arr = [first]
        for num in encoded:
            arr.append(arr[-1] ^ num)
        return arr
```

```C
int* decode(int* encoded, int encodedSize, int first, int* returnSize) {
    int* arr = malloc(sizeof(int) * (encodedSize + 1));
    arr[0] = first;
    for (int i = 0; i < encodedSize; i++) {
        arr[i + 1] = encoded[i] ^ arr[i];
    }
    *returnSize = encodedSize + 1;
    return arr;
}
```

```C++
class Solution {
public:
    vector<int> decode(vector<int>& encoded, int first) {
        int n = encoded.size() + 1;
        vector<int> arr(n);
        arr[0] = first;
        for (int i = 1; i < n; i++) {
            arr[i] = arr[i - 1] ^ encoded[i - 1];
        }
        return arr;
    }
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是原数组 $arr$ 的长度。需要遍历长度为 $n-1$ 的编码数组 $encoded$ 一次，计算原数组 $arr$ 的每个元素值。
- 空间复杂度：$O(1)$。注意空间复杂度不考虑返回值。
