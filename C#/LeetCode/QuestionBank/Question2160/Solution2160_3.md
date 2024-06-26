#### [方法一：贪心](https://leetcode.cn/problems/minimum-sum-of-four-digit-number-after-splitting-digits/solutions/1249214/chai-fen-shu-wei-hou-si-wei-shu-zi-de-zu-6awh/)

**提示 $1$**

如果两个整数位数**不相同**，那么将位数较高的整数的最高位添加至位数较低的整数的最高位之前，两个整数之和不会变大。

**提示 $1$ 解释**

假设两个整数的位数分别为 $n_1, n_2 (n_1 > n_2)$，该位数为 $d$，那么变化前，该位数对两数之和的贡献为 $d \times 10^{n_1}$；变化后为 $d \times 10^{n_2+1} \le d \times 10^{n_1}$。

**提示 $2$**

在不改变位数的情况下，我们应当把**较小的数值放在较高位**。

**提示 $2$ 解释**

我们用单个两位整数为例。假设 $new_1$ 的个位与十位分别为 $d_1, d_2 (d_1 < d_2)$。那么交换前，$new_1 = 10 \times d_2 + d_1$；交换后则为 $10 \times d_1 + d_2 < 10 \times d_2 + d_1$。

**思路与算法**

根据提示，我们需要将 $num$ 中较小的两位作为 $new_1$ 和 $new_2$ 的十位，而将较大的两位作为个位，这样可以使得 $new_1 + new_2$ 最小。

我们首先用数组 $digits$ 存储 $num$ 的每位数值，并升序排序，此时，最小的和即为

$$10 \times (digits[0] + digits[1]) + digits[2] + digits[3].$$

我们返回该值作为答案。

**代码**

```cpp
class Solution {
public:
    int minimumSum(int num) {
        vector<int> digits;
        while (num) {
            digits.push_back(num % 10);
            num /= 10;
        }
        sort(digits.begin(), digits.end());
        return 10 * (digits[0] + digits[1]) + digits[2] + digits[3];
    }
};
```

```python
class Solution:
    def minimumSum(self, num: int) -> int:
        digits = []
        while num:
            digits.append(num % 10)
            num //= 10
        digits.sort()
        return 10 * (digits[0] + digits[1]) + digits[2] + digits[3]
```

**复杂度分析**

-   时间复杂度：$O(1)$。
-   空间复杂度：$O(1)$。
