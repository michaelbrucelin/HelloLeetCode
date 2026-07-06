### [从 $O(\log n)$ 到 $O(1)$（Python/Java/C++/Go）](https://leetcode.cn/problems/elimination-game/solutions/3862426/cong-olog-n-dao-o1pythonjavacgo-by-endle-krc1/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：用等差数列模拟

示例 $1$ 的操作流程如下：

- 序列一开始是 $[1,2,3,4,5,6,7,8,9]$，这是一个首项为 $1$，公差为 $1$ 的等差数列。
- 删除所有偶数下标数字，得到序列 $[2,4,6,8]$。由于下次操作要从右侧开始删，我们可以把序列**反转**，得到 $[8,6,4,2]$，那么下次操作相当于还是从左侧开始删。序列 $[8,6,4,2]$ 是一个首项为 $8$，公差为 $-2$ 的等差数列。
- 删除所有偶数下标数字，得到序列 $[6,2]$。由于下次操作要从右侧开始删，我们可以把序列**反转**，得到 $[2,6]$，那么下次操作相当于还是从左侧开始删。序列 $[2,6]$ 是一个首项为 $2$，公差为 $4$ 的等差数列。
- 删除所有偶数下标数字，得到序列 $[6]$。

考察上述流程：

- 每次操作，删除所有偶数下标数字。当 $n$ 是偶数时，删除一半，当 $n$ 是奇数时，删除 $\lceil \dfrac{n}{2}\rceil $ 个（比如 $n=5$ 时删除 $3$ 个）。所以每次都会删除 $\lceil \dfrac{n}{2}\rceil $ 个元素，序列元素个数从 $n$ 变成 $\lfloor \dfrac{n}{2}\rfloor $。
- 间隔地删除一个等差数列中的元素，得到的仍然是一个等差数列。
- 公差初始为 $d=1$，每次操作把 $d$ 乘以 $-2$。
- 如果 $n$ 是偶数，那么序列的最后一个数一定保留。操作后，首项 $start$ 变成序列的最后一个数 $start+(n-1)\cdot d$，其中 $n$ 和 $d$ 都是操作之前的值。
- 如果 $n$ 是奇数，那么序列的最后一个数被删除，倒数第二个数保留。操作后，首项 $start$ 变成序列的倒数第二个数 $start+(n-2)\cdot d$，其中 $n$ 和 $d$ 都是操作之前的值。

```Python
class Solution:
    def lastRemaining(self, n: int) -> int:
        start = d = 1  # 等差数列的首项和公差
        while n > 1:
            start += (n - 1 - n % 2) * d
            d *= -2
            n //= 2
        return start
```

```Python
# range
class Solution:
    def lastRemaining(self, n: int) -> int:
        # range 是一个等差数列对象，不是 list
        # 计算 len、计算切片都可以用数学公式做到 O(1) 时间复杂度
        r = range(1, n + 1)
        while len(r) > 1:
            r = r[1::2][::-1]
        return r[0]
```

```Java
class Solution {
    public int lastRemaining(int n) {
        int start = 1; // 等差数列首项
        int d = 1; // 等差数列公差
        for (; n > 1; n /= 2) {
            start += (n - 1 - n % 2) * d;
            d *= -2;
        }
        return start;
    }
}
```

```C++
class Solution {
public:
    int lastRemaining(int n) {
        int start = 1, d = 1; // 等差数列的首项和公差
        for (; n > 1; n /= 2) {
            start += (n - 1 - n % 2) * d;
            d *= -2;
        }
        return start;
    }
};
```

```Go
func lastRemaining(n int) int {
    start, d := 1, 1 // 等差数列的首项和公差
    for ; n > 1; n /= 2 {
        start += (n - 1 - n%2) * d
        d *= -2
    }
    return start
}
```

#### 复杂度分析

- 时间复杂度：$O(\log n)$。
- 空间复杂度：$O(1)$。

#### 方法二：位运算

为方便计算，把初始序列改成从 $0$ 开始，即 $0,1,2,\dots ,n-1$。

第一次操作，我们删除了所有的偶数，剩余的都是奇数。这意味着，（从 $0$ 开始的）最终答案，二进制最低位一定是 $1$。

把剩余元素 $1,3,5,\dots $ 全部右移一位，我们又得到了序列 $0,1,2,\dots $

在此基础上，执行第二次操作。

在第二次操作中，我们要从右往左删除：

- 如果序列最后一个数是偶数，例如 $0,1,2,3,4$（对应着一开始 $n=10$ 或者 $11$），那么我们会删除所有的偶数，剩余的都是奇数，这和序列最后一个数加一的奇偶性相同。注意序列最后一个数加一等于 $n$ 右移一位。
- 如果序列最后一个数是奇数，例如 $0,1,2,3$（对应着一开始 $n=8$ 或者 $9$），那么我们会删除所有的奇数，剩余的都是偶数，这和序列最后一个数加一的奇偶性相同。注意序列最后一个数加一等于 $n$ 右移一位。

这意味着，（从 $0$ 开始的）最终答案，二进制从低到高第二位一定和 $n$ 从低到高第二位相同。

依此类推。

一般地，（从 $0$ 开始的）最终答案，二进制从低到高第 $1,3,5,\dots $ 位一定是 $1$；第 $2,4,6,\dots $ 位一定和 $n$ 的第 $2,4,6,\dots $ 位相同。

设 $n$ 的二进制长度为 $m$，由于我们只会操作 $m-1$ 次，所以按照上述流程构造的（从 $0$ 开始的）最终答案，二进制长度至多为 $m-1$。

算出答案后，把答案加一（因为原题的序列是从 $1$ 开始的）。

```Python
class Solution:
    def lastRemaining(self, n: int) -> int:
        MASK = 0x55555555  # ...0101
        mask2 = (1 << (n.bit_length() - 1)) - 1  # 答案（从 0 开始）的二进制长度至多为 n.bit_length() - 1
        return ((n | MASK) & mask2) + 1
```

```Java
class Solution {
    public int lastRemaining(int n) {
        final int MASK = 0x55555555; // ...0101
        int m = 32 - Integer.numberOfLeadingZeros(n);
        int mask2 = (1 << (m - 1)) - 1; // 答案（从 0 开始）的二进制长度至多为 m - 1
        return ((n | MASK) & mask2) + 1;
    }
}
```

```C++
class Solution {
public:
    int lastRemaining(int n) {
        constexpr int MASK = 0x55555555; // ...0101
        int mask2 = (1 << (bit_width((uint32_t) n) - 1)) - 1; // 答案（从 0 开始）的二进制长度至多为 bit_width(n) - 1
        return ((n | MASK) & mask2) + 1;
    }
};
```

```Go
func lastRemaining(n int) int {
    const mask = 0x55555555 // ...0101
    mask2 := 1<<(bits.Len(uint(n))-1) - 1 // 答案（从 0 开始）的二进制长度至多为 bits.Len(n)-1
    return (n|mask)&mask2 + 1
}
```

#### 复杂度分析

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。

#### 相似题目

[3782\. 交替删除操作后最后剩下的整数](https://leetcode.cn/problems/last-remaining-integer-after-alternating-deletion-operations/)

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/基环树/最短路/最小生成树/网络流）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/划分/状态机/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
