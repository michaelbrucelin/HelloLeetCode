### [懒更新 + 等价转化（Python/Java/C++/Go）](https://leetcode.cn/problems/fancy-sequence/solutions/3917656/lan-geng-xin-deng-jie-zhuan-hua-pythonja-csvl/)

#### 只有加法

从特殊到一般，先考虑一个简单的问题：只有加法，没有乘法，怎么做？

执行 $addAll(inc)$ 时，如果把每个数都增加 $inc$，就太慢了。

我们可以采用一种「**懒更新**」的想法，等到调用 $getIndex(idx)$ 时，才做计算。

比如序列 $vals=[3,1,4]$，执行 $addAll(2)$ 时，我们不去把 $vals$ 的每个数都增加 $2$，而是用一个变量 $add$ 表示「每个数都要增加 add」。执行 $addAll(2)$ 时，只把 $add$ 增加 $2$。等到调用 $getIndex(idx)$ 时，才计算加法：

$$vals[idx]+add$$

即为 $vals[idx]$ 更新后的数值。

如何处理 $append(val)$ 呢？

为了让 $val$ 兼容 $vals[idx]+add$ 这个式子，我们可以先把 $val$ **减少** $add$，再添加到 $vals$ 的末尾，比如 $val=5$，add=2，那么往 $vals$ 的末尾添加 $5-2=3$，就可以让式子 $vals[idx]+add$ **对所有元素都保持一致**。

#### 只有乘法

如果只有乘法，没有加法呢？

同理，用变量 $mul$ 表示「每个数都要乘以 mul」。执行 $multAll(2)$ 时，只把 $mul$ 乘以 $2$。等到调用 $getIndex(idx)$ 时，才计算乘法：

$$vals[idx]\cdot mul$$

即为 $vals[idx]$ 更新后的数值。

如何处理 $append(val)$ 呢？

为了让 $val$ 兼容 $vals[idx]\cdot mul$ 这个式子，我们可以先把 $val$ **除以** $mul$，再添加到 $vals$ 的末尾，比如 $val=6$，mul=2，那么往 $vals$ 的末尾添加 $6/2=3$，就可以让式子 $vals[idx]\cdot mul$ **对所有元素都保持一致**。

⚠**注意**：在模运算中，除以 $mul$ 等价于乘以 $mul$ 关于 $M=10^9+7$ 的**逆元**，即 $mul^{M-2}$。原理见 [模运算的世界：当加减乘除遇上取模](https://leetcode.cn/circle/discuss/mDfnkW/)。

#### 加法和乘法

把上述方法结合起来，用 $add$ 记录操作 $addAll$，用 $mul$ 记录操作 $multAll$。

- 初始值：$add=0$，mul=1。
- 执行 $addAll(inc)$ 时，把 $add$ 增加 $inc$。
- 执行 $multAll(m)$ 时，由于 $(v\cdot mul+add)\cdot m=v\cdot (mul\cdot m)+add\cdot m$，所以把 $mul$ 乘以 $m$，把 $add$ 乘以 $m$。

调用 $getIndex(idx)$ 时，计算

$$vals[idx]\cdot mul+add$$

即为 $vals[idx]$ 更新后的数值。

如何处理 $append(val)$ 呢？

为了让 $val$ 兼容 $vals[idx]\cdot mul+add$ 这个式子，我们可以先计算 $v=\dfrac{val-add}{mul}$，再把 $v$ 添加到 $vals$ 的末尾，就可以让式子 $vals[idx]\cdot mul+add$ **对所有元素都保持一致**。

代码实现时，注意取模。为什么可以在**中途取模**？原理见 [模运算的世界：当加减乘除遇上取模](https://leetcode.cn/circle/discuss/mDfnkW/)。

```Python
MOD = 1_000_000_007

class Fancy:
    def __init__(self):
        self.vals = []
        self.add = 0
        self.mul = 1

    def append(self, val: int) -> None:
        self.vals.append((val - self.add) * pow(self.mul, -1, MOD) % MOD)

    def addAll(self, inc: int) -> None:
        self.add += inc

    def multAll(self, m: int) -> None:
        self.mul = self.mul * m % MOD
        self.add = self.add * m % MOD

    def getIndex(self, idx: int) -> int:
        if idx >= len(self.vals):
            return -1
        return (self.vals[idx] * self.mul + self.add) % MOD
```

```Java
class Fancy {
    private static final int MOD = 1_000_000_007;

    private final List<Integer> vals = new ArrayList<>();
    private long add = 0;
    private long mul = 1;

    public void append(int val) {
        // 注意这里有减法，计算结果可能是负数，+MOD 可以保证计算结果非负
        vals.add((int) ((val - add + MOD) * pow(mul, MOD - 2) % MOD));
    }

    public void addAll(int inc) {
        add = (add + inc) % MOD;
    }

    public void multAll(int m) {
        mul = mul * m % MOD;
        add = add * m % MOD;
    }

    public int getIndex(int idx) {
        if (idx >= vals.size()) {
            return -1;
        }
        return (int) ((vals.get(idx) * mul + add) % MOD);
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
}
```

```C++
class Fancy {
    static constexpr int MOD = 1'000'000'007;

    vector<int> vals;
    long long add = 0;
    long long mul = 1;

    long long pow(long long x, int n) {
        long long res = 1;
        for (; n; n /= 2) {
            if (n % 2) {
                res = res * x % MOD;
            }
            x = x * x % MOD;
        }
        return res;
    }

public:
    void append(int val) {
        // 注意这里有减法，计算结果可能是负数，+MOD 可以保证计算结果非负
        vals.push_back((val - add + MOD) * pow(mul, MOD - 2) % MOD);
    }

    void addAll(int inc) {
        add = (add + inc) % MOD;
    }

    void multAll(int m) {
        mul = mul * m % MOD;
        add = add * m % MOD;
    }

    int getIndex(int idx) {
        if (idx >= vals.size()) {
            return -1;
        }
        return (vals[idx] * mul + add) % MOD;
    }
};
```

```Go
const mod = 1_000_000_007

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

type Fancy struct {
    vals []int
    add  int
    mul  int
}

func Constructor() Fancy {
    return Fancy{mul: 1}
}

func (f *Fancy) Append(val int) {
    // 注意这里有减法，计算结果可能是负数，+mod 可以保证计算结果非负
    f.vals = append(f.vals, (val-f.add+mod)*pow(f.mul, mod-2)%mod)
}

func (f *Fancy) AddAll(inc int) {
    f.add = (f.add + inc) % mod
}

func (f *Fancy) MultAll(m int) {
    f.mul = f.mul * m % mod
    f.add = f.add * m % mod
}

func (f *Fancy) GetIndex(idx int) int {
    if idx >= len(f.vals) {
        return -1
    }
    return (f.vals[idx]*f.mul + f.add) % mod
}
```

#### 复杂度分析

- 时间复杂度：$append$ 为 $O(\log M)$，其余为 $O(1)$，其中 $M=10^9+7$。
- 空间复杂度：$O(q)$，其中 $q$ 是 $append$ 的调用次数。

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
