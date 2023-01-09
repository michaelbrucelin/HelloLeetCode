#### [方法二：数学](https://leetcode.cn/problems/minimum-number-of-operations-to-reinitialize-a-permutation/solutions/2051628/huan-yuan-pai-lie-de-zui-shao-cao-zuo-bu-d9cn/)

**思路与算法**

我们需要观察一下原排列中对应的索引变换关系。对于原排列中第 $i$ 个元素，设 $g(i)$ 为进行一次操作后，该元素的新的下标，题目转化规则如下:

-   如果 $g(i)$ 为偶数，那么 $arr[g(i)] = perm[\dfrac{g(i)}{2}]$，令 $x = \dfrac{g(i)}{2}$，则该等式转换为 $arr[2x] = perm[x]$，此时 $x \in [0,\dfrac{n-1}{2}]$；
-   如果 $g(i)$ 为奇数，那么 $arr[g(i)] = perm[\dfrac{n}{2} + \dfrac{g(i)-1}{2}]$，令 $x = \dfrac{n}{2} + \dfrac{g(i)-1}{2}$，则该等式转换为 $arr[2x-n-1] = perm[x]$，此时 $x \in[\dfrac{n+1}{2},\dfrac{n}{2}]$；

因此根据题目的转换规则可以得到以下对应关系:

-   当 $0 \le i < \dfrac{n}{2}$ 时，此时 $g(i) = 2i$；
-   当 $\dfrac{n}{2} \le i < n$ 时，此时 $g(i) = 2i-(n-1)$；

其中原排列中的第 $0$ 和 $n−1$ 个元素的下标不会变换，我们无需进行考虑。 对于其余元素 $i \in [1, n-1)$，上述两个等式可以转换为对 $n−1$ 取模，等式可以转换为 $g(i) \equiv 2i \pmod {(n-1)}$。

记 $g^k(i)$ 表示原排列 $perm$ 中第 $i$ 个元素经过 $k$ 次变换后的下标，即 $g^2(i) = g(g(i)), g^3(i) = g(g(g(i)))$ 等等，那么我们可以推出:$g^k(i) \equiv 2^ki \pmod {(n-1)}$

为了让排列还原到初始值，原数组中索引为 $i$ 的元素经过多次变换后索引变回 $i$，此时必须有：$g^k(i) \equiv 2^ki \equiv i \pmod {(n-1)}$。我们只需要找到最小的 $k$，使得上述等式对于 $i \in [1,n-1)$ 均成立，此时的 $k$ 即为所求的最小变换次数。

当 $i=1$ 时，我们有：$g^k(1) \equiv 2^k \equiv 1 \pmod {(n-1)}$

如果存在 $k$ 满足上式，那么将上式两侧同乘 $i$，得到 $g^k(i) \equiv 2^ki \equiv i \pmod {(n-1)}$ 即对于 $i \in [1, n-1)$ 恒成立。因此原题等价于寻找最小的 $k$，使得 $2^k \equiv 1 \pmod {(n-1)}$。

由于 $n$ 为偶数，则 $n−1$ 是奇数，$2$ 和 $n−1$ 互质，那么根据「[欧拉定理](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fmath%2Fnumber-theory%2Ffermat%2F)」：$2^{\varphi(n-1)} \equiv 1 \pmod {(n-1)}$

即 $k=\varphi(n-1)$ 一定是一个解，其中 $\varphi$ 为「[欧拉函数](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fmath%2Fnumber-theory%2Feuler%2F)」。因此，最小的 $k$ 一定小于等于 $\varphi(n-1)$，而欧拉函数 $\varphi(n-1) \le n-1$，因此可以知道 $k \le n - 1$ 的，因此总的时间复杂度不超过 $O(n)$。

根据上述推论，我们直接模拟即找到最小的 $k$ 使得满足 $2^k \equiv 1 \pmod {(n-1)}$ 即可。

**代码**

```python
class Solution:
    def reinitializePermutation(self, n: int) -> int:
        if n == 2:
            return 1
        step, pow2 = 1, 2
        while pow2 != 1:
            step += 1
            pow2 = pow2 * 2 % (n - 1)
        return step
```

```cpp
class Solution {
public:
    int reinitializePermutation(int n) {
        if (n == 2) {
            return 1;
        }
        int step = 1, pow2 = 2;
        while (pow2 != 1) {
            step++;
            pow2 = pow2 * 2 % (n - 1);
        }
        return step;
    }
};
```

```java
class Solution {
    public int reinitializePermutation(int n) {
        if (n == 2) {
            return 1;
        }
        int step = 1, pow2 = 2;
        while (pow2 != 1) {
            step++;
            pow2 = pow2 * 2 % (n - 1);
        }
        return step;
    }
}
```

```csharp
public class Solution {
    public int ReinitializePermutation(int n) {
        if (n == 2) {
            return 1;
        }
        int step = 1, pow2 = 2;
        while (pow2 != 1) {
            step++;
            pow2 = pow2 * 2 % (n - 1);
        }
        return step;
    }
}
```

```c
int reinitializePermutation(int n) {
    if (n == 2) {
        return 1;
    }
    int step = 1, pow2 = 2;
    while (pow2 != 1) {
        step++;
        pow2 = pow2 * 2 % (n - 1);
    }
    return step;
}
```

```javascript
var reinitializePermutation = function(n) {
    if (n === 2) {
        return 1;
    }
    let step = 1, pow2 = 2;
    while (pow2 !== 1) {
        step++;
        pow2 = pow2 * 2 % (n - 1);
    }
    return step;
};
```

```go
func reinitializePermutation(n int) int {
    if n == 2 {
        return 1
    }
    step := 1
    pow2 := 2
    for pow2 != 1 {
        step++
        pow2 = pow2 * 2 % (n - 1)
    }
    return step
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 表示给定的元素。根据推论可以知道最多需要进行计算的次数不超过 $n$，因此时间复杂度为 $O(n)$。
-   空间复杂度：$O(1)$。
