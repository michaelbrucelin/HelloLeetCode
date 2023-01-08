#### [方法二：位运算](https://leetcode.cn/problems/add-binary/solutions/299667/er-jin-zhi-qiu-he-by-leetcode-solution/)

**思路和算法**

如果不允许使用加减乘除，则可以使用位运算替代上述运算中的一些加减乘除的操作。

如果不了解位运算，可以先了解位运算并尝试练习以下题目：

-   [只出现一次的数字 II](https://leetcode-cn.com/problems/single-number-ii/)
-   [只出现一次的数字 III](https://leetcode-cn.com/problems/single-number-iii/)
-   [数组中两个数的最大异或值](https://leetcode-cn.com/problems/maximum-xor-of-two-numbers-in-an-array/)
-   [重复的DNA序列](https://leetcode-cn.com/problems/repeated-dna-sequences/)
-   [最大单词长度乘积](https://leetcode-cn.com/problems/maximum-product-of-word-lengths/)

我们可以设计这样的算法来计算：

-   把 $a$ 和 $b$ 转换成整型数字 $x$ 和 $y$，在接下来的过程中，$x$ 保存结果，$y$ 保存进位。
-   当进位不为 $0$ 时
    -   计算当前 $x$ 和 $y$ 的无进位相加结果：`answer = x ^ y`
    -   计算当前 $x$ 和 $y$ 的进位：`carry = (x & y) << 1`
    -   完成本次循环，更新 `x = answer`，`y = carry`
-   返回 $x$ 的二进制形式

为什么这个方法是可行的呢？在第一轮计算中，`answer` 的最后一位是 $x$ 和 $y$ 相加之后的结果，`carry` 的倒数第二位是 $x$ 和 $y$ 最后一位相加的进位。接着每一轮中，由于 `carry` 是由 $x$ 和 $y$ 按位与并且左移得到的，那么最后会补零，所以在下面计算的过程中后面的数位不受影响，而每一轮都可以得到一个低 $i$ 位的答案和它向低 $i + 1$ 位的进位，也就模拟了加法的过程。

**代码**

```python
class Solution:
    def addBinary(self, a, b) -> str:
        x, y = int(a, 2), int(b, 2)
        while y:
            answer = x ^ y
            carry = (x & y) << 1
            x, y = answer, carry
        return bin(x)[2:]
```

**复杂度分析**

-   时间复杂度：$O(|a| + |b| + X \cdot \max ({|a| + |b|}))$，字符串转化成数字需要的时间代价为 $O(|a| + |b|)$，计算的时间代价为 $O(\max \{ |a|, |b| \})$，$X$ 为位运算所需的时间，因为这里用到了高精度计算，所以位运算的时间不一定为 $O(1)$。
-   空间复杂度：这里使用了 $x$ 和 $y$ 来保存 $a$ 和 $b$ 的整数形式，如果用 Python 实现，这里用到了 Python 的高精度功能，实际的空间代价是 $O(|a| + |b|)$。
