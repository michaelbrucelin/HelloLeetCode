### [两种方法：暴力枚举 / 卷积（Python/Java/C++/Go）](https://leetcode.cn/problems/image-overlap/solutions/4022390/liang-chong-fang-fa-bao-li-mei-ju-juan-j-6bqq/)

#### 方法一：暴力枚举

![](./assets/img/Solution0835_oth.jpg)

为方便描述，把 $img_1$ 简记为 $A$，把 $img_2$ 简记为 $B$。

如果把 $A$ 向下移动 $x$ 个单位，向右移动 $y$ 个单位（向上/向左则 $x,y$ 为负），那么 $A_{i,j}$ 对应着 $B_{i+x,j+y}$。例如，把 $A$ 向下移动 $1$ 个单位，向右移动 $1$ 个单位，那么 $A_{0,0}$ 对应 $B_{1,1}$。

移动后，重叠 $1$ 的个数为

$$f(x,y)=\sum\limits_{i=0}^{n-1}\sum\limits_{j=0}^{n-1}A_{i,j}\cdot B_{i+x,j+y}$$

> **注 1**：如果 $A_{i,j}$ 和 $B_{i+x,j+y}$ 都是 $1$，才能把计数器增加一，否则计数器不变。这等价于把计数器增加 $A_{i,j}\cdot B_{i+x,j+y}$。
> **注 2**：超出下标范围的元素视作 $0$。

枚举 $x$ 和 $y$，答案为

$$\mathop{max}\limits_{-(n-1)\le x,y\le n-1}f(x,y)$$

代码实现时，由于 $0$ 对答案无贡献，可以只遍历满足 $0\le i<n$ 且 $0\le i+x<n$ 的 $i$，即

$$max(-x,0)\le i<min(n-x,n)$$

对于 $j$，同理有

$$max(-y,0)\le j<min(n-y,n)$$

```Python
class Solution:
    def largestOverlap(self, img1: List[List[int]], img2: List[List[int]]) -> int:
        n = len(img1)
        ans = 0
        for dx in range(1 - n, n):
            for dy in range(1 - n, n):
                cnt1 = 0
                for i in range(max(-dx, 0), min(n - dx, n)):
                    for j in range(max(-dy, 0), min(n - dy, n)):
                        # 两个数都是 1，才能让 cnt1 增加 1
                        cnt1 += img1[i][j] * img2[i + dx][j + dy]
                ans = max(ans, cnt1)
        return ans
```

```Java
class Solution {
    public int largestOverlap(int[][] img1, int[][] img2) {
        int n = img1.length;
        int ans = 0;
        for (int dx = 1 - n; dx < n; dx++) {
            for (int dy = 1 - n; dy < n; dy++) {
                int cnt1 = 0;
                for (int i = Math.max(-dx, 0); i < Math.min(n - dx, n); i++) {
                    for (int j = Math.max(-dy, 0); j < Math.min(n - dy, n); j++) {
                        // 两个数都是 1，才能让 cnt1 增加 1
                        cnt1 += img1[i][j] * img2[i + dx][j + dy];
                    }
                }
                ans = Math.max(ans, cnt1);
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int largestOverlap(vector<vector<int>>& img1, vector<vector<int>>& img2) {
        int n = img1.size();
        int ans = 0;
        for (int dx = 1 - n; dx < n; dx++) {
            for (int dy = 1 - n; dy < n; dy++) {
                int cnt1 = 0;
                for (int i = max(-dx, 0); i < min(n - dx, n); i++) {
                    for (int j = max(-dy, 0); j < min(n - dy, n); j++) {
                        // 两个数都是 1，才能让 cnt1 增加 1
                        cnt1 += img1[i][j] * img2[i + dx][j + dy];
                    }
                }
                ans = max(ans, cnt1);
            }
        }
        return ans;
    }
};
```

```Go
func largestOverlap(img1, img2 [][]int) (ans int) {
    n := len(img1)
    for dx := 1 - n; dx < n; dx++ {
        for dy := 1 - n; dy < n; dy++ {
            cnt1 := 0
            for i := max(-dx, 0); i < min(n-dx, n); i++ {
                for j := max(-dy, 0); j < min(n-dy, n); j++ {
                    // 两个数都是 1，才能让 cnt1 增加 1
                    cnt1 += img1[i][j] * img2[i+dx][j+dy]
                }
            }
            ans = max(ans, cnt1)
        }
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$O(n^4)$，其中 $n$ 是 $img_i$ 的行数和列数。
- 空间复杂度：$O(1)$。

## 方法二：二维卷积

> 本质上来说，我们计算的是 $A$ 和 $B$ 的互相关（$cross-correlation$）。

为了和卷积联系上，定义 $B$ 的翻转矩阵 $\tilde{B}_{i,j}=B_{n-1-i,n-1-j}$。

计算 $A$ 和 $\tilde{B}$ 的二维卷积

$$C_{x,y}=\sum\limits_{i=0}^{n-1}\sum\limits_{j=0}^{n-1}A_{i,j}\cdot \tilde{B}_{x-i,y-j}$$

其中 $0\le x,y\le 2n-2$。超出下标范围的元素视作 $0$。

代入 $\tilde{B}$ 的定义，上式变为

$$C_{x,y}=\sum\limits_{i=0}^{n-1}\sum\limits_{j=0}^{n-1}A_{i,j}\cdot B_{n-1-x+i,n-1-y+j}$$

令 $x^′=n-1-x$，y^′=n-1-y，上式变为

$$C_{x,y}=\sum\limits_{i=0}^{n-1}\sum\limits_{j=0}^{n-1}A_{i,j}\cdot B_{i+x^′,j+y^′}=f(x^′,y^′)$$

其中 $-(n-1)\le x^′,y^′\le n-1$。

上式表明，卷积矩阵 $C$ 恰好对应着所有 $(2n-1)^2$ 种平移情况，所以答案为 $C$ 中的最大值。

```python
# NumPy
import numpy as np

class Solution:
    def largestOverlap(self, img1: List[List[int]], img2: List[List[int]]) -> int:
        a = np.array(img1, dtype=np.int8)
        b = np.array(img2, dtype=np.int8)
        b = np.flip(b)

        n = len(img1)
        shape = (n * 2 - 1, n * 2 - 1)
        fa = np.fft.fft2(a, shape)
        fb = np.fft.fft2(b, shape)
        conv = np.rint(np.fft.ifft2(fa * fb).real)

        return int(conv.max())
```

```python
# SciPy
from scipy.signal import correlate2d

class Solution:
    def largestOverlap(self, img1: List[List[int]], img2: List[List[int]]) -> int:
        return int(correlate2d(img1, img2).max())
```

```Go
type fft struct {
    n        int
    omega    []complex128
    omegaInv []complex128
}

func newFFT(n int) *fft {
    omega := make([]complex128, n)
    omegaInv := make([]complex128, n)
    for i := range omega {
        sin, cos := math.Sincos(2 * math.Pi * float64(i) / float64(n))
        omega[i] = complex(cos, sin)
        omegaInv[i] = complex(cos, -sin)
    }
    return &fft{n, omega, omegaInv}
}

func (t *fft) transform(a, omega []complex128) {
    n := t.n
    for i, j := 0, 0; i < n; i++ {
        if i > j { // 保证同一对元素只交换一次
            a[i], a[j] = a[j], a[i]
        }
        for l := n / 2; ; l /= 2 {
            j ^= l
            if j >= l {
                break
            }
        }
    }
    for l := 2; l <= n; l *= 2 {
        m := l / 2
        for st := 0; st < n; st += l {
            b := a[st:]
            for i := range m {
                v := omega[n/l*i] * b[m+i]
                b[m+i] = b[i] - v
                b[i] += v
            }
        }
    }
}

func (t *fft) dft(a []complex128) {
    t.transform(a, t.omega)
}

func (t *fft) idft(a []complex128) {
    t.transform(a, t.omegaInv)
    cn := complex(float64(t.n), 0)
    for i := range a {
        a[i] /= cn
    }
}

func (t *fft) transform2(a [][]complex128, f func([]complex128)) {
    for _, row := range a {
        f(row)
    }

    n := len(a)
    tmp := make([]complex128, n)
    for j := range n {
        for i, row := range a {
            tmp[i] = row[j]
        }
        f(tmp)
        for i, row := range a {
            row[j] = tmp[i]
        }
    }
}

// 计算方阵 mat1 和方阵 mat2 的二维卷积
func conv2(mat1, mat2 [][]int) [][]int {
    n := len(mat1)
    n2 := n*2 - 1
    size := 1 << bits.Len(uint(n2))

    a := make([][]complex128, size)
    b := make([][]complex128, size)
    for i := range a {
        a[i] = make([]complex128, size)
        b[i] = make([]complex128, size)
    }
    for i, row := range mat1 {
        for j, x := range row {
            a[i][j] = complex(float64(x), 0)
            b[i][j] = complex(float64(mat2[i][j]), 0)
        }
    }

    f := newFFT(size)
    f.transform2(a, f.dft)
    f.transform2(b, f.dft)
    for i, row := range b {
        for j, x := range row {
            a[i][j] *= x
        }
    }
    f.transform2(a, f.idft)

    conv := make([][]int, n2)
    for i, row := range a[:n2] {
        conv[i] = make([]int, n2)
        for j, c := range row[:n2] {
            conv[i][j] = int(math.Round(real(c)))
        }
    }
    return conv
}

func largestOverlap(img1, img2 [][]int) (ans int) {
    for _, row := range img2 {
        slices.Reverse(row)
    }
    slices.Reverse(img2)

    conv := conv2(img1, img2)

    for _, row := range conv {
        ans = max(ans, slices.Max(row))
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$O(n^2\log n)$，其中 $n$ 是 $img_i$ 的行数和列数。
- 空间复杂度：$O(n^2)$。

相关题目，见下面数学题单的「**§7.4 卷积**」。

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
