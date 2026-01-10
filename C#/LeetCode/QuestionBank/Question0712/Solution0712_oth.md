### [正难则反：计算最多保留的 ASCII 之和（Python/Java/C++/Go）](https://leetcode.cn/problems/minimum-ascii-delete-sum-for-two-strings/solutions/3869951/kao-lu-zui-duo-bao-liu-de-ascii-zhi-he-p-ijdc/)

用 $s_1$ 和 $s_2$ 的 $ASCII$ 值之和，减去保留的 $ASCII$ 之和的最大值，就是删除字符的 $ASCII$ 值之和的最小值。

计算最多保留的 $ASCII$ 之和，方法和 [1143\. 最长公共子序列](https://leetcode.cn/problems/longest-common-subsequence/) 一样：

- $1143$ 题，$s_1[i]=s_2[j]$ 时，都保留，最长公共子序列长度增加 $1$。
- 本题，$s_1[i]=s_2[j]$ 时，都保留，保留的 $ASCII$ 之和增加 $ASCII(s_1[i])\cdot 2$。

所以只需把 $1143$ 题的 $+1$ 改成 $+ASCII(s_1[i])\cdot 2$。

也可以改成 $+ASCII(s_1[i])$，最后返回时再乘以 $2$。

```Python
class Solution:
    def minimumDeleteSum(self, s1: str, s2: str) -> int:
        n, m = len(s1), len(s2)
        total = sum(map(ord, s1)) + sum(map(ord, s2))

        f = [[0] * (m + 1) for _ in range(n + 1)]
        for i, x in enumerate(s1):
            for j, y in enumerate(s2):
                if x == y:
                    f[i + 1][j + 1] = f[i][j] + ord(x)
                else:
                    f[i + 1][j + 1] = max(f[i][j + 1], f[i + 1][j])
        return total - f[n][m] * 2
```

```Java
class Solution {
    public int minimumDeleteSum(String s1, String s2) {
        int total = s1.chars().sum() + s2.chars().sum();

        char[] s = s1.toCharArray();
        char[] t = s2.toCharArray();
        int n = s.length;
        int m = t.length;

        int[][] f = new int[n + 1][m + 1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (s[i] == t[j]) {
                    f[i + 1][j + 1] = f[i][j] + s[i];
                } else {
                    f[i + 1][j + 1] = Math.max(f[i][j + 1], f[i + 1][j]);
                }
            }
        }
        return total - f[n][m] * 2;
    }
}
```

```C++
class Solution {
public:
    int minimumDeleteSum(string s1, string s2) {
        int n = s1.size(), m = s2.size();
        int total = reduce(s1.begin(), s1.end(), 0) + reduce(s2.begin(), s2.end(), 0);

        vector f(n + 1, vector<int>(m + 1));
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (s1[i] == s2[j]) {
                    f[i + 1][j + 1] = f[i][j] + s1[i];
                } else {
                    f[i + 1][j + 1] = max(f[i][j + 1], f[i + 1][j]);
                }
            }
        }
        return total - f[n][m] * 2;
    }
};
```

```Go
func minimumDeleteSum(s1, s2 string) int {
    n, m := len(s1), len(s2)
    total := 0
    for _, c := range s1 {
        total += int(c)
    }
    for _, c := range s2 {
        total += int(c)
    }

    f := make([][]int, n+1)
    for i := range f {
        f[i] = make([]int, m+1)
    }
    for i, x := range s1 {
        for j, y := range s2 {
            if x == y {
                f[i+1][j+1] = f[i][j] + int(x)
            } else {
                f[i+1][j+1] = max(f[i][j+1], f[i+1][j])
            }
        }
    }
    return total - f[n][m]*2
}
```

空间优化：

```Python
# 更快的写法见【Python3 手写 max】
class Solution:
    def minimumDeleteSum(self, s1: str, s2: str) -> int:
        m = len(s2)
        total = sum(map(ord, s1)) + sum(map(ord, s2))

        f = [0] * (m + 1)
        for x in s1:
            ord_x = ord(x)
            pre = 0  # f[0]
            for j, y in enumerate(s2):
                tmp = f[j + 1]
                if x == y:
                    f[j + 1] = pre + ord_x
                else:
                    f[j + 1] = max(f[j + 1], f[j])
                pre = tmp
        return total - f[m] * 2
```

```Python
# 手写 max
class Solution:
    def minimumDeleteSum(self, s1: str, s2: str) -> int:
        m = len(s2)
        total = sum(map(ord, s1)) + sum(map(ord, s2))

        f = [0] * (m + 1)
        for x in s1:
            ord_x = ord(x)
            pre = 0  # f[0]
            for j, y in enumerate(s2):
                tmp = f[j + 1]
                if x == y:
                    f[j + 1] = pre + ord_x
                elif f[j] > f[j + 1]:
                    f[j + 1] = f[j]
                pre = tmp
        return total - f[m] * 2
```

```Java
class Solution {
    public int minimumDeleteSum(String s1, String s2) {
        int total = s1.chars().sum() + s2.chars().sum();

        char[] s = s1.toCharArray();
        char[] t = s2.toCharArray();
        int m = t.length;

        int[] f = new int[m + 1];
        for (char x : s) {
            int pre = 0; // f[0]
            for (int j = 0; j < m; j++) {
                int tmp = f[j + 1];
                if (x == t[j]) {
                    f[j + 1] = pre + x;
                } else {
                    f[j + 1] = Math.max(f[j + 1], f[j]);
                }
                pre = tmp;
            }
        }
        return total - f[m] * 2;
    }
}
```

```C++
class Solution {
public:
    int minimumDeleteSum(string s1, string s2) {
        int m = s2.size();
        int total = reduce(s1.begin(), s1.end(), 0) + reduce(s2.begin(), s2.end(), 0);

        vector<int> f(m + 1);
        for (char x : s1) {
            int pre = 0; // f[0]
            for (int j = 0; j < m; j++) {
                int tmp = f[j + 1];
                if (x == s2[j]) {
                    f[j + 1] = pre + x;
                } else {
                    f[j + 1] = max(f[j + 1], f[j]);
                }
                pre = tmp;
            }
        }
        return total - f[m] * 2;
    }
};
```

```Go
func minimumDeleteSum(s1, s2 string) int {
    m := len(s2)
    total := 0
    for _, c := range s1 {
        total += int(c)
    }
    for _, c := range s2 {
        total += int(c)
    }

    f := make([]int, m+1)
    for _, x := range s1 {
        pre := 0 // f[0]
        for j, y := range s2 {
            tmp := f[j+1]
            if x == y {
                f[j+1] = pre + int(x)
            } else {
                f[j+1] = max(f[j+1], f[j])
            }
            pre = tmp
        }
    }
    return total - f[m]*2
}
```

#### 复杂度分析

- 时间复杂度：$O(nm)$，其中 $n$ 是 $s_1$ 的长度，$m$ 是 $s_2$ 的长度。
- 空间复杂度：$O(m)$。

#### 专题训练

见下面动态规划题单的「**§4.1 最长公共子序列（$LCS$）**」。

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
