### [$O(1)$ 公式推导（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/xor-operation-in-an-array/solutions/2793723/o1-gong-shi-tui-dao-pythonjavaccgojsrust-le23/)

#### $start$ 是偶数的情况

如果 $start$ 是偶数，那么 $nums[i] = start+2i$ 也是偶数。例如 $n = 5, start = 0$，即

$$0,2,4,6,8$$

由于这些数二进制最低位都是 $0$，我们可以先把这些数都右移一位（除以 $2$），计算异或和，然后把异或和左移一位（乘以 $2$），就得到了答案，也就是

$$0 \oplus 2 \oplus 4 \oplus 6 \oplus 8 = (0 \oplus 1 \oplus 2 \oplus 3 \oplus 4) \cdot 2 = 4 \cdot 2 = 8$$

#### $start$ 是奇数的情况

如果 $start$ 是奇数，那么 $nums[i] = start+2i$ 也是奇数。例如 $n = 5, start = 3$，即

$$3,5,7,9,11$$

我们分两部分计算这些数的异或和：

- **最低位**：由于这些数二进制最低位都是 $1$，所以答案的最低位取决于有多少个 $1$，偶数个 $1$ 的异或和是 $0$，奇数个 $1$ 的异或和是 $1$。
- **除了最低位的其余比特位**：先把这些数都右移一位（除以 $2$），计算异或和，然后把异或和左移一位（乘以 $2$）。

两部分相加，得

$$3 \oplus 5 \oplus 7 \oplus 9 \oplus 11 = (1 \oplus 2 \oplus 3 \oplus 4 \oplus 5) \cdot 2+1 = 1 \cdot 2+1 = 3$$

#### 合二为一

无论 $start$ 是偶数还是奇数，都可以用同一个规则计算。

设 $a = \lfloor \dfrac{start}{2} \rfloor$，$b$ 为异或和的最低位。只有 $n$ 和 $start$ 都为奇数时 $b = 1$，其余情况 $b = 0$。那么异或和等于

$$(a \oplus (a+1) \oplus (a+2) \oplus \cdots \oplus (a+n-1)) \cdot 2+b$$

由于 $x \oplus x = 0$，上式中的异或和可以变形为

$$\begin{aligned} & a \oplus (a+1) \oplus (a+2) \oplus \cdots \oplus (a+n-1) \\ = & \underbrace{0 \oplus 0 \oplus \cdots \oplus 0}_{a 个 0} \oplus a \oplus (a+1) \oplus (a+2) \oplus \cdots \oplus (a+n-1) \\ = & (0 \oplus 0) \oplus (1 \oplus 1) \oplus \cdots \oplus ((a-1) \oplus (a-1)) \oplus a \oplus (a+1) \oplus (a+2) \oplus \cdots \oplus (a+n-1) \\ = & (0 \oplus 1 \oplus 2 \oplus \cdots \oplus a+n-1) \oplus (0 \oplus 1 \oplus 2 \oplus \cdots \oplus a-1)\end{aligned}$$

也就是 $0$ 到 $a+n-1$ 的异或和，异或上 $0$ 到 $a-1$ 的异或和。

#### $0$ 到 $n$ 的异或和

当 $x$ 是偶数时，$x$ 和 $x+1$ 只有最低位不同，所以 $x \oplus (x+1) = 1$，即

$$\begin{aligned} & 0 \oplus 1 = 1 \\ & 2 \oplus 3 = 1 \\ & 4 \oplus 5 = 1 \\ & 6 \oplus 7 = 1 \\ & \cdots \end{aligned}$$

又因为 $1 \oplus 1 = 0$，所以从 $0$ 开始，每 $4$ 个数的异或和都是 $0$：

$$\begin{aligned} & 0 \oplus 1 \oplus 2 \oplus 3 = 0 \\ & 4 \oplus 5 \oplus 6 \oplus 7 = 0 \\ & 8 \oplus 9 \oplus 1 0 \oplus 11 = 0 \\ & \cdots \end{aligned}$$

这启发我们按照 $n$ 模 $4$ 的结果分类：

- 当 $n = 4k+3$（例如 $3,7,11$）时，两个数一组，可以得到 $\dfrac{n+1}{2} = \dfrac{4k+4}{2} = 2(k+1)$ 组，也就是偶数个 $1$，其异或和等于 $0$。
- 当 $n = 4k+1$（例如 $1,5,9$）时，两个数一组，可以得到 $\dfrac{n+1}{2} = \dfrac{4k+2}{2} = 2k+1$ 组，也就是奇数个 $1$，其异或和等于 $1$。
- 当 $n = 4k+2$（例如 $2,6,10$）时，先拿一个 $n$ 出来，问题变成 $4k+1$ 的情况，异或和等于 $1$，再异或上 $n = 4k+2$，得 $4k+3$，即 $n+1$。
- 当 $n = 4k+4$（例如 $4,8,12$）时，先拿一个 $n$ 出来，问题变成 $4k+3$ 的情况，异或和等于 $0$，再异或上 $n = 4k+4$，得 $4k+4$，即 $n$。

综上所述，$0$ 到 $n$ 的异或和为：

$$\bigoplus_{i=0}^{n}i = \begin{cases}n, & n = 4k \\ 1, & n = 4k+1 \\ n + 1, & n = 4k+2 \\ 0, & n = 4k+3 \end{cases}$$

```Python
class Solution:
    def xorOperation(self, n: int, start: int) -> int:
        xor_n = lambda n: (n, 1, n + 1, 0)[n % 4]
        a = start // 2
        b = n & start & 1  # 都为奇数才是 1
        return (xor_n(a + n - 1) ^ xor_n(a - 1)) * 2 + b
```

```Java
class Solution {
    public int xorOperation(int n, int start) {
        int a = start / 2;
        int b = n & start & 1; // 都为奇数才是 1
        return (xorN(a + n - 1) ^ xorN(a - 1)) * 2 + b;
    }

    private int xorN(int n) {
        return switch (n % 4) {
            case 0 -> n;
            case 1 -> 1;
            case 2 -> n + 1;
            default -> 0;
        };
    }
}
```

```C++
class Solution {
    int xor_n(int n) {
        switch (n % 4) {
            case 0: return n;
            case 1: return 1;
            case 2: return n + 1;
            default: return 0;
        }
    }

public:
    int xorOperation(int n, int start) {
        int a = start / 2;
        int b = n & start & 1; // 都为奇数才是 1
        return (xor_n(a + n - 1) ^ xor_n(a - 1)) * 2 + b;
    }
};
```

```C
int xor_n(int n) {
    switch (n % 4) {
        case 0: return n;
        case 1: return 1;
        case 2: return n + 1;
        default: return 0;
    }
}

int xorOperation(int n, int start) {
    int a = start / 2;
    int b = n & start & 1; // 都为奇数才是 1
    return (xor_n(a + n - 1) ^ xor_n(a - 1)) * 2 + b;
}
```

```Go
func xorN(n int) int {
    switch n % 4 {
        case 0: return n
        case 1: return 1
        case 2: return n + 1
        default: return 0
    }
}

func xorOperation(n, start int) int {
    a := start / 2
    b := n & start & 1 // 都为奇数才是 1
    return (xorN(a+n-1)^xorN(a-1))*2 + b
}
```

```JavaScript
function xorN(n) {
    switch (n % 4) {
        case 0: return n;
        case 1: return 1;
        case 2: return n + 1;
        default: return 0;
    }
}

var xorOperation = function(n, start) {
    const a = Math.floor(start / 2);
    const b = n & start & 1; // 都为奇数才是 1
    return (xorN(a + n - 1) ^ xorN(a - 1)) * 2 + b;
};
```

```Rust
impl Solution {
    pub fn xor_operation(n: i32, start: i32) -> i32 {
        let xor_n = |n| match n % 4 {
            0 => n,
            1 => 1,
            2 => n + 1,
            _ => 0,
        };
        let a = start / 2;
        let b = n & start & 1; // 都为奇数才是 1
        (xor_n(a + n - 1) ^ xor_n(a - 1)) * 2 + b
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与一般树（前后指针/快慢指针/DFS/BFS/直径/LCA）](https://leetcode.cn/circle/discuss/K0n2gO/)
