### [交换论证法（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/m_inimum-init_ial-energy-to-finish-tasks/solut_ions/3965592/jiao-huan-lun-zheng-fa-pythonjavaccgojsr-ozft/)

#### 按照什么规则排序？

本文把 $actual$ 简称为 $a$，把 $m_inimum$ 简称为 $m$。

如果 $tasks$ 的某个排列 $T$ 是最优的（完成所有任务所需的初始能量最少），那么 $T$ 中的相邻任务满足什么性质？

设 $T$ 中的一对相邻任务为 $t_1=(a_1,m_1)$ 和 $t_2=(a_2,m_2)$。设初始能量为 $E_0$，完成这两个任务之前的能量为 $E$。由于从一开始到完成这两个任务之前，所消耗的能量之和是固定的 $S$，所以有 $E=E_0-S$。根据该式，$E$ 越小，初始能量 $E_0$ 也越小。

先完成哪个任务更好？

- 如果先完成 $t_1$ 再完成 $t_2$，那么完成 $t_1$ 之前，必须满足 $E\ge m_1$；完成 $t_2$ 之前，必须满足 $E-a_1\ge m_2$。联立得 $E\ge max(m_1,m_2+a_1)$。
- 如果先完成 $t_2$ 再完成 $t_1$，那么完成 $t_2$ 之前，必须满足 $E\ge m_2$；完成 $t_1$ 之前，必须满足 $E-a_2\ge m_1$。联立得 $E\ge max(m_2,m_1+a_2)$。

如果先完成 $t_1$ 再完成 $t_2$ 更优（或者相同），则有

$$max(m_1,m_2+a_1)\le max(m_2,m_1+a_2)$$

两边同时减去 $a_1+a_2$，得

$$max(m_1-a_1-a_2,m_2-a_2)\le max(m_2-a_1-a_2,m_1-a_1)$$

为方便阅读，令 $X=m_1-a_1$，$Y=m_2-a_2$，上式化简为

$$max(X-a_2,Y)\le max(Y-a_1,X)$$

- 如果 $X<Y$，那么上式左侧等于 $Y$，右侧严格小于 $Y$（题目保证 $a_1>0$），此时 $max(X-a_2,Y)>max(Y-a_1,X)$。
- 如果 $X\ge Y$，那么上式左侧两个值都 $\le X$，右侧等于 $X$，此时 $max(X-a_2,Y)\le max(Y-a_1,X)$。

所以当且仅当 $X\ge Y$ 成立时，$max(X-a_2,Y)\le max(Y-a_1,X)$ 成立。

所以当且仅当 $m_1-a_1\ge m_2-a_2$ 成立时，先完成 $t_1$ 再完成 $t_2$ 更优（或者相同）。

这意味着，对于 $tasks$ 中的相邻任务，设左边的任务为 $(a_1,m_1)$，右边的任务为 $(a_2,m_2)$，如果 $m_1-a_1<m_2-a_2$，那么交换这两个任务可以让初始能量变得更小（或者不变）。于是通过交换 $tasks$ 的相邻任务（类似冒泡排序的过程），把 $tasks$ 按照 $m_i-a_i$ 从大到小排序，可以得到 $tasks$ 的最优排列。

#### 计算初始能量（正序）

设初始能量为 $E_0$，设执行 $tasks[i]=(a_i,m_i)$ 之前，累计耗费的能量为 $S$，那么当前能量为 $E_0-S$，必须满足

$$E_0-S\ge m_i$$

即

$$E_0\ge S+m_i$$

由此可以得到 $n$ 个关于 $E_0$ 的下界，所有下界取最大值，即为答案。

```Python
class Solution:
    def minimumEffort(self, tasks: List[List[int]]) -> int:
        tasks.sort(key=lambda t: t[0] - t[1])  # 按照 minimum - actual 从大到小排序

        ans = 0
        s = 0  # 累计耗费的能量
        for actual, minimum in tasks:
            # 题目要求 E0 - s >= minimum，即 E0 >= s + minimum
            # 由此可以得到 n 个关于 E0 的下界，所有下界的最大值即为答案
            ans = max(ans, s + minimum)
            s += actual
        return ans
```

```Java
class Solution {
    public int minimumEffort(int[][] tasks) {
        // 按照 minimum - actual 从大到小排序
        Arrays.sort(tasks, (a, b) -> (b[1] - b[0]) - (a[1] - a[0]));

        int ans = 0;
        int s = 0; // 累计耗费的能量
        for (int[] t : tasks) {
            int actual = t[0];
            int minimum = t[1];
            // 题目要求 E0 - s >= minimum，即 E0 >= s + minimum
            // 由此可以得到 n 个关于 E0 的下界，所有下界的最大值即为答案
            ans = Math.max(ans, s + minimum);
            s += actual;
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int minimumEffort(vector<vector<int>>& tasks) {
        ranges::sort(tasks, {}, [](auto& t) { return t[0] - t[1]; }); // 按照 minimum - actual 从大到小排序

        int ans = 0;
        int s = 0; // 累计耗费的能量
        for (auto& t : tasks) {
            int actual = t[0], minimum = t[1];
            // 题目要求 E0 - s >= minimum，即 E0 >= s + minimum
            // 由此可以得到 n 个关于 E0 的下界，所有下界的最大值即为答案
            ans = max(ans, s + minimum);
            s += actual;
        }
        return ans;
    }
};
```

```C
int cmp(const void* p, const void* q) {
    int* a = *(int**)p;
    int* b = *(int**)q;
    return (b[1] - b[0]) - (a[1] - a[0]); // 按照 minimum - actual 从大到小排序
}

int minimumEffort(int** tasks, int tasksSize, int* tasksColSize) {
    qsort(tasks, tasksSize, sizeof(int*), cmp);

    int ans = 0;
    int s = 0; // 累计耗费的能量
    for (int i = 0; i < tasksSize; i++) {
        int actual = tasks[i][0];
        int minimum = tasks[i][1];
        // 题目要求 E0 - s >= minimum，即 E0 >= s + minimum
        // 由此可以得到 n 个关于 E0 的下界，所有下界的最大值即为答案
        ans = MAX(ans, s + minimum);
        s += actual;
    }
    return ans;
}
```

```Go
func minimumEffort(tasks [][]int) (ans int) {
    slices.SortFunc(tasks, func(a, b []int) int {
        return (b[1] - b[0]) - (a[1] - a[0]) // 按照 minimum - actual 从大到小排序
    })

    s := 0 // 累计耗费的能量
    for _, t := range tasks {
        actual, minimum := t[0], t[1]
        // 题目要求 E0 - s >= minimum，即 E0 >= s + minimum
        // 由此可以得到 n 个关于 E0 的下界，所有下界的最大值即为答案
        ans = max(ans, s+minimum)
        s += actual
    }
    return
}
```

```JavaScript
var minimumEffort = function(tasks) {
    tasks.sort((a, b) => (b[1] - b[0]) - (a[1] - a[0])); // 按照 minimum - actual 从大到小排序

    let ans = 0;
    let s = 0; // 累计耗费的能量
    for (const [actual, minimum] of tasks) {
        // 题目要求 E0 - s >= minimum，即 E0 >= s + minimum
        // 由此可以得到 n 个关于 E0 的下界，所有下界的最大值即为答案
        ans = Math.max(ans, s + minimum);
        s += actual;
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn minimum_effort(mut tasks: Vec<Vec<i32>>) -> i32 {
        tasks.sort_unstable_by_key(|t| t[0] - t[1]); // 按照 minimum - actual 从大到小排序

        let mut ans = 0;
        let mut s = 0; // 累计耗费的能量
        for t in tasks {
            let actual = t[0];
            let minimum = t[1];
            // 题目要求 E0 - s >= minimum，即 E0 >= s + minimum
            // 由此可以得到 n 个关于 E0 的下界，所有下界的最大值即为答案
            ans = ans.max(s + minimum);
            s += actual;
        }
        ans
    }
}
```

#### 计算初始能量（倒序）

也可以从右到左计算。

设完成任务 $t_i=(a_i,m_i)$ 之后的能量为 $E$，那么完成 $t_i$ 之前的能量为 $E+a_i$，但这个能量又必须 $\ge m_i$，所以完成 $t_i$ 之前的能量至少为

$$max(E+a_i,m_i)$$

为了最小化初始能量，完成最后一个任务后的能量应当为 $0$，作为 $E$ 的初始值。

代码实现时，可以改成按照 $m_i-a_i$ 从小到大排序，这样可以正序遍历数组，更方便。

```Python
class Solution:
    def minimumEffort(self, tasks: list[list[int]]) -> int:
        tasks.sort(key=lambda t: t[1] - t[0])  # 按照 minimum - actual 从小到大排序

        e = 0
        for actual, minimum in tasks:
            # 完成该任务之后的能量为 e，那么完成该任务之前的能量为 e+actual，同时该能量必须至少为 minimum
            e = max(e + actual, minimum)
        return e
```

```Java
class Solution {
    public int minimumEffort(int[][] tasks) {
        // 按照 minimum - actual 从小到大排序
        Arrays.sort(tasks, (a, b) -> (a[1] - a[0]) - (b[1] - b[0]));

        int e = 0;
        for (int[] t : tasks) {
            int actual = t[0];
            int minimum = t[1];
            // 完成 t 之后的能量为 e，那么完成 t 之前的能量为 e+actual，同时该能量必须至少为 minimum
            e = Math.max(e + actual, minimum);
        }
        return e;
    }
}
```

```C++
class Solution {
public:
    int minimumEffort(vector<vector<int>>& tasks) {
        ranges::sort(tasks, {}, [](auto& t) { return t[1] - t[0]; }); // 按照 minimum - actual 从小到大排序

        int e = 0;
        for (auto& t : tasks) {
            int actual = t[0], minimum = t[1];
            // 完成 t 之后的能量为 e，那么完成 t 之前的能量为 e+actual，同时该能量必须至少为 minimum
            e = max(e + actual, minimum);
        }
        return e;
    }
};
```

```C
int cmp(const void* p, const void* q) {
    int* a = *(int**)p;
    int* b = *(int**)q;
    return (a[1] - a[0]) - (b[1] - b[0]); // 按照 minimum - actual 从小到大排序
}

int minimumEffort(int** tasks, int tasksSize, int* tasksColSize) {
    qsort(tasks, tasksSize, sizeof(int*), cmp);

    int e = 0;
    for (int i = 0; i < tasksSize; i++) {
        int actual = tasks[i][0];
        int minimum = tasks[i][1];
        // 完成 tasks[i] 之后的能量为 e，那么完成 tasks[i] 之前的能量为 e+actual，同时该能量必须至少为 minimum
        e = MAX(e + actual, minimum);
    }
    return e;
}
```

```Go
func minimumEffort(tasks [][]int) (e int) {
    slices.SortFunc(tasks, func(a, b []int) int {
        return (a[1] - a[0]) - (b[1] - b[0]) // 按照 minimum - actual 从小到大排序
    })

    for _, t := range tasks {
        actual, minimum := t[0], t[1]
        // 完成 t 之后的能量为 e，那么完成 t 之前的能量为 e+actual，同时该能量必须至少为 minimum
        e = max(e+actual, minimum)
    }
    return
}
```

```JavaScript
var minimumEffort = function(tasks) {
    tasks.sort((a, b) => (a[1] - a[0]) - (b[1] - b[0])); // 按照 minimum - actual 从小到大排序

    let e = 0;
    for (const [actual, minimum] of tasks) {
        // 完成该任务之后的能量为 e，那么完成该任务之前的能量为 e+actual，同时该能量必须至少为 minimum
        e = Math.max(e + actual, minimum);
    }
    return e;
};
```

```Rust
impl Solution {
    pub fn minimum_effort(mut tasks: Vec<Vec<i32>>) -> i32 {
        tasks.sort_unstable_by_key(|t| t[1] - t[0]); // 按照 minimum - actual 从小到大排序

        let mut e = 0;
        for t in tasks {
            let actual = t[0];
            let minimum = t[1];
            // 完成 t 之后的能量为 e，那么完成 t 之前的能量为 e+actual，同时该能量必须至少为 minimum
            e = minimum.max(e + actual);
        }
        e
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n\log n)$，其中 $n$ 是 $tasks$ 的长度。瓶颈在排序上。
- 空间复杂度：$O(1)$。不计入排序的栈开销。

#### 专题训练

见下面贪心题单的「**§1.7 交换论证法**」。

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
