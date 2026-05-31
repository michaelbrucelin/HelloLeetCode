### [贪心证明，以及 O(n) 做法（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/destroying-asteroids/solutions/1187846/tan-xin-cong-zui-xiao-de-kA_i-shi-peng-zh-h7d4/)

读完题目，直觉告诉你，可以先摧毁质量小的小行星，积累质量，从而更有可能摧毁质量大的小行星。排序，遍历，提交，通过。

为什么这样做是对的？

**命题**：如果存在一种顺序 $A$ 可以摧毁所有小行星，那么按照质量从小到大的顺序摧毁，也一定可以摧毁所有小行星。

下面给出两种证明方法。

**证法一**：如果 $A$ 是递增的，那么命题成立。如果 $A$ 不是递增的，即存在 $A_i>A_{i+1}$，那么设摧毁 $A_i$ 之前，行星的质量为 $M$，则有 $M\ge A_i$ 以及 $M+A_i\ge A_{i+1}$。现在交换这两颗小行星的顺序，由于 $M\ge A_i>A_{i+1}$，所以可以先摧毁 $A_{i+1}$；又由于 $M\ge A_i$，那么 $M+A_{i+1}\ge A_i$ 更加成立，所以可以后摧毁 $A_i$。于是，交换 $A$ 中逆序的相邻小行星（类似冒泡排序的过程），把 $A$ 排成递增的，仍然可以摧毁所有小行星。

**证法二**：证明原命题的逆否命题，即如果按照质量从小到大的顺序（记作 $B$），无法摧毁所有小行星，那么不存在可以摧毁所有小行星的顺序。设 $i$ 是最小的满足 $B_i>mass+\sum_{j=0}^{i-1}Bj$ 的下标。把 $B$ 分成两个集合 $S={B_0,B_1,\dots ,B_{i-1}}$ 和 $T={B_i,B_{i+1},\dots ,B_{n-1}}$。设 $x$ 是我们尝试摧毁的**第一颗**属于 $T$ 的小行星，那么摧毁 $x$ 之前，行星的质量至多为 $M=mass+\sum_{m\in S}m=mass+\sum_{j=0}^{i-1}Bj$，由于 $M<B_i\le B_{i+1}\le \dots \le B_{n-1}$，所以 $M$ 小于任何 $T$ 中的小行星质量，我们无法摧毁小行星 $x$。所以不存在可以摧毁所有小行星的顺序。

根据该命题，把 $asteroids$ 从小到大排序，检查该顺序能否摧毁所有小行星即可。

#### 优化前

```Python
class Solution:
    def asteroidsDestroyed(self, mass: int, asteroids: List[int]) -> bool:
        asteroids.sort()
        for x in asteroids:
            if mass < x:  # 无法摧毁小行星 x
                return False
            mass += x  # 获得这颗小行星的质量
        return True
```

```Java
class Solution {
    public boolean asteroidsDestroyed(int mass, int[] asteroids) {
        Arrays.sort(asteroids);
        long m = mass;
        for (int x : asteroids) {
            if (m < x) { // 无法摧毁小行星 x
                return false;
            }
            m += x; // 获得这颗小行星的质量
        }
        return true;
    }
}
```

```C++
class Solution {
public:
    bool asteroidsDestroyed(int mass, vector<int>& asteroids) {
        ranges::sort(asteroids);
        long long m = mass;
        for (int x : asteroids) {
            if (m < x) { // 无法摧毁小行星 x
                return false;
            }
            m += x; // 获得这颗小行星的质量
        }
        return true;
    }
};
```

```C
int cmp(const void* a, const void* b) {
    return *(int*)a - *(int*)b;
}

bool asteroidsDestroyed(int mass, int* asteroids, int asteroidsSize) {
    qsort(asteroids, asteroidsSize, sizeof(int), cmp);
    long long m = mass;
    for (int i = 0; i < asteroidsSize; i++) {
        int x = asteroids[i];
        if (m < x) { // 无法摧毁小行星 x
            return false;
        }
        m += x; // 获得这颗小行星的质量
    }
    return true;
}
```

```Go
func asteroidsDestroyed(mass int, asteroids []int) bool {
    slices.Sort(asteroids)
    for _, x := range asteroids {
        if mass < x { // 无法摧毁小行星 x
            return false
        }
        mass += x // 获得这颗小行星的质量
    }
    return true
}
```

```JavaScript
var asteroidsDestroyed = function(mass, asteroids) {
    asteroids.sort((a, b) => a - b);
    for (const x of asteroids) {
        if (mass < x) { // 无法摧毁小行星 x
            return false;
        }
        mass += x; // 获得这颗小行星的质量
    }
    return true;
};
```

```Rust
impl Solution {
    pub fn asteroids_destroyed(mass: i32, mut asteroids: Vec<i32>) -> bool {
        asteroids.sort_unstable();
        let mut mass = mass as i64;
        for x in asteroids {
            if mass < x as i64 { // 无法摧毁小行星 x
                return false;
            }
            mass += x as i64; // 获得这颗小行星的质量
        }
        true
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n\log n)$，其中 $n$ 是 $asteroids$ 的长度。瓶颈在排序上。
- 空间复杂度：$O(1)$。忽略排序的栈开销。

#### 优化：按二进制长度分组

这个做法基于一个简单的事实：

- 一个 $\ge 2^k$ 的数，加上另一个 $\ge 2^k$ 的数，和一定 $\ge 2^{k+1}$。

基于这一事实，我们可以把 $asteroids$ 中的元素按照**二进制长度**分组：

- 在 $[2^0,2^1)$ 中的数分到同一组。
- 在 $[2^1,2^2)$ 中的数分到同一组。
- 在 $[2^2,2^3)$ 中的数分到同一组。
- $\dots \dots$

设行星的质量为 $M$。如果 $M\ge $ 组内最小值，那么 $M$ 加上组内最小值后，结果一定大于组内的每个值，所以这一组的质量可以全部加到 $M$ 中。如此一来，我们只需统计每一组的最小值，以及每一组的元素和，无需对组内元素排序。

```Python
class Solution:
    def asteroidsDestroyed(self, mass: int, asteroids: List[int]) -> bool:
        max_width = max(asteroids).bit_length()
        mn = [inf] * max_width
        sum_ = [0] * max_width

        for x in asteroids:
            i = x.bit_length() - 1
            mn[i] = min(mn[i], x)
            sum_[i] += x

        for m, s in zip(mn, sum_):
            if m == inf:
                continue
            if mass < m:  # 无法摧毁这组的任意小行星
                return False
            mass += s  # 获得这组小行星的质量
        return True
```

```Python
# 写法二
class Solution:
    def asteroidsDestroyed(self, mass: int, asteroids: List[int]) -> bool:
        mn = defaultdict(lambda: inf)
        sum_ = defaultdict(int)
        mask = 0

        for x in asteroids:
            i = x.bit_length() - 1
            mn[i] = min(mn[i], x)
            sum_[i] += x
            mask |= 1 << i

        while mask:
            lowbit = mask & -mask  # mask 的最低位
            i = lowbit.bit_length() - 1
            if mass < mn[i]:  # 无法摧毁这组的任意小行星
                return False
            mass += sum_[i]  # 获得这组小行星的质量
            mask ^= lowbit  # 移除 mask 的最低位
        return True
```

```Java
class Solution {
    public boolean asteroidsDestroyed(int mass, int[] asteroids) {
        int mx = 0;
        for (int x : asteroids) {
            mx = Math.max(mx, x);
        }

        int maxWidth = 32 - Integer.numberOfLeadingZeros(mx);
        long[] sum = new long[maxWidth];
        int[] mn = new int[maxWidth];
        Arrays.fill(mn, Integer.MAX_VALUE);

        for (int x : asteroids) {
            int i = 31 - Integer.numberOfLeadingZeros(x); // x 的二进制长度减一
            sum[i] += x;
            mn[i] = Math.min(mn[i], x);
        }

        long m = mass;
        for (int i = 0; i < maxWidth; i++) {
            if (mn[i] == Integer.MAX_VALUE) {
                continue;
            }
            if (m < mn[i]) { // 无法摧毁这组的任意小行星
                return false;
            }
            m += sum[i]; // 获得这组小行星的质量
        }
        return true;
    }
}
```

```C++
class Solution {
public:
    bool asteroidsDestroyed(int mass, vector<int>& asteroids) {
        int max_width = bit_width(1u * ranges::max(asteroids));
        vector<int> mn(max_width, INT_MAX);
        vector<long long> sum(max_width);

        for (int x : asteroids) {
            int i = bit_width(1u * x) - 1;
            mn[i] = min(mn[i], x);
            sum[i] += x;
        }

        long long m = mass;
        for (int i = 0; i < max_width; i++) {
            if (mn[i] == INT_MAX) {
                continue;
            }
            if (m < mn[i]) { // 无法摧毁这组的任意小行星
                return false;
            }
            m += sum[i]; // 获得这组小行星的质量
        }
        return true;
    }
};
```

```C
bool asteroidsDestroyed(int mass, int* asteroids, int asteroidsSize) {
    int mx = 0;
    for (int i = 0; i < asteroidsSize; i++) {
        mx = MAX(mx, asteroids[i]);
    }

    int max_width = 32 - __builtin_clz(mx);
    long long* sum = calloc(max_width, sizeof(long long));
    int* mn = malloc(max_width * sizeof(int));
    for (int i = 0; i < max_width; i++) {
        mn[i] = INT_MAX;
    }

    for (int i = 0; i < asteroidsSize; i++) {
        int x = asteroids[i];
        int j = 31 - __builtin_clz(x); // x 的二进制长度减一
        sum[j] += x;
        mn[j] = MIN(mn[j], x);
    }

    long long m = mass;
    for (int i = 0; i < max_width; i++) {
        if (mn[i] == INT_MAX) {
            continue;
        }
        if (m < mn[i]) { // 无法摧毁这组的任意小行星
            free(mn);
            free(sum);
            return false;
        }
        m += sum[i]; // 获得这组小行星的质量
    }

    free(mn);
    free(sum);
    return true;
}
```

```Go
func asteroidsDestroyed(mass int, asteroids []int) bool {
    maxWidth := bits.Len(uint(slices.Max(asteroids)))
    sum := make([]int, maxWidth)
    mn := make([]int, maxWidth)
    for i := range mn {
        mn[i] = math.MaxInt
    }

    for _, x := range asteroids {
        i := bits.Len(uint(x)) - 1
        sum[i] += x
        mn[i] = min(mn[i], x)
    }

    for i, m := range mn {
        if m == math.MaxInt {
            continue
        }
        if mass < m { // 无法摧毁这组的任意小行星
            return false
        }
        mass += sum[i] // 获得这组小行星的质量
    }
    return true
}
```

```JavaScript
var asteroidsDestroyed = function(mass, asteroids) {
    const maxWidth = 32 - Math.clz32(Math.max(...asteroids));
    const mn = Array(maxWidth).fill(Infinity);
    const sum = Array(maxWidth).fill(0);

    for (const x of asteroids) {
        const i = 31 - Math.clz32(x); // x 的二进制长度减一
        mn[i] = Math.min(mn[i], x);
        sum[i] += x;
    }

    for (let i = 0; i < maxWidth; i++) {
        if (mn[i] === Infinity) {
            continue;
        }
        if (mass < mn[i]) { // 无法摧毁这组的任意小行星
            return false;
        }
        mass += sum[i]; // 获得这组小行星的质量
    }
    return true;
};
```

```Rust
impl Solution {
    pub fn asteroids_destroyed(mass: i32, asteroids: Vec<i32>) -> bool {
        let mx = *asteroids.iter().max().unwrap();
        let max_width = 32 - mx.leading_zeros() as usize;
        let mut mn = vec![i32::MAX; max_width];
        let mut sum = vec![0; max_width];

        for x in asteroids {
            let i = 31 - x.leading_zeros() as usize; // x 的二进制长度减一
            mn[i] = mn[i].min(x);
            sum[i] += x as i64;
        }

        let mut mass = mass as i64;
        for (m, s) in mn.into_iter().zip(sum.into_iter()) {
            if m == i32::MAX {
                continue;
            }
            if mass < m as i64 { // 无法摧毁这组的任意小行星
                return false;
            }
            mass += s; // 获得这组小行星的质量
        }
        true
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n+\log U)$ 或 $O(n)$，其中 $n$ 是 $asteroids$ 的长度，$U=max(asteroids)$。O(n) 做法可以参考【Python3 写法二】。
- 空间复杂度：$O(\log U)$ 或 $O(min(n,\log U))$。

#### 专题训练

见下面贪心题单的「**§1.1 从最小/最大开始贪心**」和「**§1.7 交换论证法**」。

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
