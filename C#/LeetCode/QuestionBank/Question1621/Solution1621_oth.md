### [组合数学（Python/Java/C++/Go）](https://leetcode.cn/problems/number-of-sets-of-k-non-overlapping-line-segments/solutions/4022747/zu-he-shu-xue-pythonjavacgo-by-endlessch-p8wu/)

设 $x_i$ 是第 $i$ 条线段的**长度**。例如第一条线段覆盖了点 $1,2,3$，那么 $x_1=2$。

设 $d_0$ 是第一条线段左侧的空白长度（没被覆盖的长度），$d_i (i<k)$ 是第 $i$ 条线段与第 $i+1$ 条线段之间的空白长度，$d_k$ 是最后一条线段右侧的空白长度。

示例 $1$ 的第三种方案为 $x_1=x_2=1, d_0=0, d_1=1,d_2=0$。

所有长度相加，等于从 $0$ 到 $n-1$ 的长度 $n-1$，写成式子就是

$$d_0+x_1+d_1+x_2+d_2+\dots +x_k+d_k=n-1$$

其中 $x_i\ge 1, d_i\ge 0$。

为方便计算，令 $e_i=d_i+1$，上式变为

$$e_0+x_1+e_1+x_2+e_2\dots +x_k+e_k=n-1+(k+1)=n+k$$

左边有 $2k+1$ 个变量，每个变量都是正整数。原问题的方案数等价于该不定方程的正整数解的个数。

这是一个经典的组合数学问题：

- 有 $n+k$ 个无区分的小球，放入 $2k+1$ 个有区分的盒子，不允许空盒，有多少种放法？

这可以用**隔板法**解决。把这 $n+k$ 个小球排成一行，有 $n+k-1$ 个空隙，从中选出 $2k$ 个空隙插入隔板，就把小球分成了 $2k+1$ 组，放入对应的盒子。方案数为

$$\binom{n+k-1}{2k}$$

关于「组合数取模」的原理及模板，见 [模运算的世界：当加减乘除遇上取模](https://leetcode.cn/circle/discuss/mDfnkW/)。

```Python
class Solution:
    def numberOfSets(self, n: int, k: int) -> int:
        return comb(n + k - 1, k * 2) % 1_000_000_007
```

```Python
# 写法二
MOD = 1_000_000_007
MX = 1999

# 把预处理的逻辑写在 class 外面，这样只会初始化一次
fac = [0] * MX  # fac[i] = i!
fac[0] = 1
for i in range(1, MX):
    fac[i] = fac[i - 1] * i % MOD

inv_f = [0] * MX  # inv_f[i] = i!^-1
inv_f[-1] = pow(fac[-1], -1, MOD)
for i in range(MX - 1, 0, -1):
    inv_f[i - 1] = inv_f[i] * i % MOD

def comb(n: int, m: int) -> int:
    return fac[n] * inv_f[m] * inv_f[n - m] % MOD

class Solution:
    def numberOfSets(self, n: int, k: int) -> int:
        return comb(n + k - 1, k * 2)
```

```Java
class Solution {
    private static final int MOD = 1_000_000_007;
    private static final int MX = 1999;

    private static final long[] F = new long[MX]; // F[i] = i!
    private static final long[] INV_F = new long[MX]; // INV_F[i] = i!^-1 = pow(i!, MOD-2)

    private static boolean initialized = false;

    // 这样写比 static block 快
    public Solution() {
        if (initialized) {
            return;
        }
        initialized = true;

        F[0] = 1;
        for (int i = 1; i < MX; i++) {
            F[i] = F[i - 1] * i % MOD;
        }

        INV_F[MX - 1] = pow(F[MX - 1], MOD - 2);
        for (int i = MX - 1; i > 0; i--) {
            INV_F[i - 1] = INV_F[i] * i % MOD;
        }
    }

    private long pow(long x, int n) {
        long res = 1;
        for (; n > 0; n /= 2) {
            if (n % 2 > 0) {
                res = res * x % MOD;
            }
            x = x * x % MOD;
        }
        return res;
    }

    private long comb(int n, int m) {
        return F[n] * INV_F[m] % MOD * INV_F[n - m] % MOD;
    }

    public int numberOfSets(int n, int k) {
        return (int) comb(n + k - 1, k * 2);
    }
}
```

```C++
const int MOD = 1'000'000'007;
const int MX = 1999;

long long F[MX]; // F[i] = i!
long long INV_F[MX]; // INV_F[i] = i!^-1 = qpow(i!, MOD-2)

long long qpow(long long x, int n) {
    long long res = 1;
    for (; n; n /= 2) {
        if (n % 2) {
            res = res * x % MOD;
        }
        x = x * x % MOD;
    }
    return res;
}

auto init = [] {
    F[0] = 1;
    for (int i = 1; i < MX; i++) {
        F[i] = F[i - 1] * i % MOD;
    }

    INV_F[MX - 1] = qpow(F[MX - 1], MOD - 2);
    for (int i = MX - 1; i; i--) {
        INV_F[i - 1] = INV_F[i] * i % MOD;
    }
    return 0;
}();

long long comb(int n, int m) {
    return F[n] * INV_F[m] % MOD * INV_F[n - m] % MOD;
}

class Solution {
public:
    int numberOfSets(int n, int k) {
        return comb(n + k - 1, k * 2);
    }
};
```

```Go
const mod = 1_000_000_007
const mx = 1999

var fac [mx]int  // fac[i] = i!
var invF [mx]int // invF[i] = i!^-1 = pow(i!, mod-2)

func init() {
    fac[0] = 1
    for i := 1; i < mx; i++ {
        fac[i] = fac[i-1] * i % mod
    }

    invF[mx-1] = pow(fac[mx-1], mod-2)
    for i := mx - 1; i > 0; i-- {
        invF[i-1] = invF[i] * i % mod
    }
}

func pow(x, n int) int {
    res := 1
    for ; n > 0; n /= 2 {
        if n%2 > 0 {
            res = res * x % mod
        }
        x = x * x % mod
    }
    return res
}

func comb(n, m int) int {
    return fac[n] * invF[m] % mod * invF[n-m] % mod
}

func numberOfSets(n, k int) int {
    return comb(n+k-1, k*2)
}
```

#### 复杂度分析

不计入预处理的时间和空间。

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。

#### 专题训练

见下面数学题单的「**§2.2 组合计数**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/discuss/post/3141566/ru-he-ke-xue-shua-ti-by-endlesscheng-q3yd/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/discuss/post/3578981/ti-dan-hua-dong-chuang-kou-ding-chang-bu-rzz7/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/discuss/post/3579164/ti-dan-er-fen-suan-fa-er-fen-da-an-zui-x-3rqn/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/discuss/post/3579480/ti-dan-dan-diao-zhan-ju-xing-xi-lie-zi-d-u4hk/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/discuss/post/3580195/fen-xiang-gun-ti-dan-wang-ge-tu-dfsbfszo-l3pa/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/discuss/post/3580371/fen-xiang-gun-ti-dan-wei-yun-suan-ji-chu-nth4/)
6. [图论算法（DFS/BFS/拓扑排序/基环树/最短路/最小生成树/网络流）](https://leetcode.cn/discuss/post/3581143/fen-xiang-gun-ti-dan-tu-lun-suan-fa-dfsb-qyux/)
7. [动态规划（入门/背包/划分/状态机/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/discuss/post/3581838/fen-xiang-gun-ti-dan-dong-tai-gui-hua-ru-007o/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/discuss/post/3583665/fen-xiang-gun-ti-dan-chang-yong-shu-ju-j-bvmv/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/discuss/post/3584388/fen-xiang-gun-ti-dan-shu-xue-suan-fa-shu-gcai/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/discuss/post/3091107/fen-xiang-gun-ti-dan-tan-xin-ji-ben-tan-k58yb/)
11. [链表、树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA）](https://leetcode.cn/discuss/post/3142882/fen-xiang-gun-ti-dan-lian-biao-er-cha-sh-6srp/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/discuss/post/3144832/fen-xiang-gun-ti-dan-zi-fu-chuan-kmpzhan-ugt4/)
