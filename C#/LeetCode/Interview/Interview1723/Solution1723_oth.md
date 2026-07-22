### [$O(n^2\log n)$ 做法（Python/Java/C++/Go）](https://leetcode.cn/problems/max-black-square-lcci/solutions/3777966/on2logn-zuo-fa-pythonjavacgo-by-endlessc-sjnq/?envType=problem-list-v2&envId=tBJHVASZ)

> 这个做法是本题的进阶做法，可以解决 $2000\times 2000$ 大小的 $matrix$。

考虑**左下角**在 $(i,j)$ 的正方形，它的最大边长是多少？

比如从 $(i,j)$ 往右看有 $5$ 个 $0$，往上看有 $7$ 个 $0$。那么正方形的边长**至多**为 $min(5,7)=5$。

但这只看了正方形的下边和左边这两条边，我们还得确认正方形的上边和右边这两条边是否全为 $0$，这需要正方形右上角的信息。

举两个例子：

- 正方形右上角在 $(i-4,j+4)$，假设往左看有 $3$ 个 $0$，往下看有 $2$ 个 $0$。这样的正方形，边太短了（或者说边不是全为 $0$），所以 $(i-4,j+4)$ 不能是右上角。
- 正方形右上角在 $(i-3,j+3)$，假设往左看有 $6$ 个 $0$，往下看有 $5$ 个 $0$。这样的正方形，边足够长，所以 $(i-3,j+3)$ 可以是右上角。

怎么维护这样的右上角信息呢？

由于这些右上角都**在同一条反对角线上**，我们可以遍历所有的反对角线，原理见 [498\. 对角线遍历](https://leetcode.cn/problems/diagonal-traverse/)，[我的题解](https://leetcode.cn/problems/diagonal-traverse/solutions/3762798/mo-ban-bian-li-dui-jiao-xian-pythonjavac-jnky/)。

当我们遍历到 $(i,j)$ 时，假设往左看有 $6$ 个 $0$，往下看有 $5$ 个 $0$，那么 $(i,j)$ 作为正方形的右上角，可以服务于左下角横坐标在 $[i,i+min(6,5)-1]$ 中的正方形。

为了维护这样的信息，我们需要做两件事情：

1. 把右上角的横坐标 $i$ 添加到一个有序集合中，当我们遍历到左下角 $(x,y)$ 时，设正方形的边长至多为 $sz$（往右往上的 $0$ 的最小值），那么在有序集合中查找大于 $i-sz$ 的最小元素，就是右上角的横坐标的最小值。
2. 及时清除过期数据。$(i,j)$ 作为正方形的右上角，设往左往下的 $0$ 的最小值为 $sz^′$，那么当循环到左下角横坐标为 $i+sz^′-1$ 时，$(i,j)$ 服务到期，在循环的末尾，把 $i$ 从有序集合中删掉。

```Python
class Solution:
    def findSquare(self, matrix: List[List[int]]) -> List[int]:
        n = len(matrix)
        # 预处理每个格子左右上下最近的 1 的位置
        left1 = [[0] * n for _ in range(n)]
        right1 = [[0] * n for _ in range(n)]
        up1 = [[0] * n for _ in range(n)]
        down1 = [[0] * n for _ in range(n)]

        for i, row in enumerate(matrix):
            l = -1
            for j, x in enumerate(row):
                if x:
                    l = j
                left1[i][j] = l

            r = n
            for j in range(n - 1, -1, -1):
                if row[j]:
                    r = j
                right1[i][j] = r

        for j, col in enumerate(zip(*matrix)):
            u = -1
            for i, x in enumerate(col):
                if x:
                    u = i
                up1[i][j] = u

            d = n
            for i in range(n - 1, -1, -1):
                if col[i]:
                    d = i
                down1[i][j] = d

        ans = (0, 0, 0)  # (size, -r, -c)

        for k in range(n * 2 - 1):
            sl = SortedList()
            min_j = max(k - n + 1, 0)
            max_j = min(k, n - 1)
            to_remove = [[] for _ in range(n)]

            for j in range(max_j, min_j - 1, -1):
                i = k - j
                if matrix[i][j] == 0:
                    # (i,j) 作为正方形的右上角，可以服务于左下角横坐标在 [i,i+sz-1] 中的正方形
                    sl.add(i)
                    sz = min(j - left1[i][j], down1[i][j] - i)  # min(左,下)
                    to_remove[i + sz - 1].append(i)  # 在未来移除

                    # (i,j) 作为正方形的左下角
                    # 找 sl 中的大于 i-size 的最小横坐标 i2
                    sz = min(right1[i][j] - j, i - up1[i][j])  # min(右,上)
                    i2 = sl[sl.bisect_right(i - sz)]
                    # i-i2+1 就是 (i,j) 作为正方形左下角时，正方形的最大边长
                    ans = max(ans, (i - i2 + 1, -i2, -j))

                # 移除那些超过服务范围的右上角横坐标
                for i2 in to_remove[i]:
                    sl.discard(i2)

        return [-ans[1], -ans[2], ans[0]] if ans[0] else []
```

```Java
class Solution {
    public int[] findSquare(int[][] matrix) {
        int n = matrix.length;
        // 预处理每个格子左右上下最近的 1 的位置
        int[][] left1 = new int[n][n];
        int[][] right1 = new int[n][n];
        int[][] up1 = new int[n][n];
        int[][] down1 = new int[n][n];

        for (int i = 0; i < n; i++) {
            int l = -1;
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == 1) {
                    l = j;
                }
                left1[i][j] = l;
            }

            int r = n;
            for (int j = n - 1; j >= 0; j--) {
                if (matrix[i][j] == 1) {
                    r = j;
                }
                right1[i][j] = r;
            }
        }

        for (int j = 0; j < n; j++) {
            int u = -1;
            for (int i = 0; i < n; i++) {
                if (matrix[i][j] == 1) {
                    u = i;
                }
                up1[i][j] = u;
            }

            int d = n;
            for (int i = n - 1; i >= 0; i--) {
                if (matrix[i][j] == 1) {
                    d = i;
                }
                down1[i][j] = d;
            }
        }

        int maxSize = 0;
        int minR = 0;
        int minC = 0;

        List<Integer>[] toRemove = new ArrayList[n];
        Arrays.setAll(toRemove, _ -> new ArrayList<>());
        TreeSet<Integer> sl = new TreeSet<>();

        for (int k = 0; k < n * 2 - 1; k++) {
            sl.clear();
            int min_j = Math.max(k - n + 1, 0);
            int max_j = Math.min(k, n - 1);
            for (List<Integer> lst : toRemove) {
                lst.clear();
            }

            for (int j = max_j; j >= min_j; j--) {
                int i = k - j;
                if (matrix[i][j] == 0) {
                    // (i,j) 作为正方形的右上角，可以服务于左下角横坐标在 [i,i+sz-1] 中的正方形
                    sl.add(i);
                    int sz = Math.min(j - left1[i][j], down1[i][j] - i); // min(左,下)
                    toRemove[i + sz - 1].add(i); // 在未来移除

                    // (i,j) 作为正方形的左下角
                    // 找 sl 中的大于 i-size 的最小横坐标 i2
                    sz = Math.min(right1[i][j] - j, i - up1[i][j]); // min(右,上)
                    int i2 = sl.higher(i - sz);
                    // i-i2+1 就是 (i,j) 作为正方形左下角时，正方形的最大边长
                    int size = i - i2 + 1;
                    if (size > maxSize || size == maxSize && (i2 < minR || i2 == minR && j < minC)) {
                        maxSize = size;
                        minR = i2;
                        minC = j;
                    }
                }

                // 移除那些超过服务范围的右上角横坐标
                for (int i2 : toRemove[i]) {
                    sl.remove(i2);
                }
            }
        }

        if (maxSize == 0) {
            return new int[]{};
        }
        return new int[]{minR, minC, maxSize};
    }
}
```

```C++
class Solution {
public:
    vector<int> findSquare(vector<vector<int>>& matrix) {
        int n = matrix.size();
        // 预处理每个格子左右上下最近的 1 的位置
        vector left1(n, vector<int>(n));
        vector right1(n, vector<int>(n));
        vector up1(n, vector<int>(n));
        vector down1(n, vector<int>(n));

        for (int i = 0; i < n; i++) {
            int l = -1;
            for (int j = 0; j < n; j++) {
                if (matrix[i][j]) {
                    l = j;
                }
                left1[i][j] = l;
            }

            int r = n;
            for (int j = n - 1; j >= 0; j--) {
                if (matrix[i][j]) {
                    r = j;
                }
                right1[i][j] = r;
            }
        }

        for (int j = 0; j < n; j++) {
            int u = -1;
            for (int i = 0; i < n; i++) {
                if (matrix[i][j]) {
                    u = i;
                }
                up1[i][j] = u;
            }

            int d = n;
            for (int i = n - 1; i >= 0; i--) {
                if (matrix[i][j]) {
                    d = i;
                }
                down1[i][j] = d;
            }
        }

        tuple<int, int, int> ans{}; // (size, -r, -c)

        for (int k = 0; k < n * 2 - 1; k++) {
            set<int> st;
            int min_j = max(k - n + 1, 0);
            int max_j = min(k, n - 1);
            vector<vector<int>> to_remove(n);

            for (int j = max_j; j >= min_j; j--) {
                int i = k - j;
                if (matrix[i][j] == 0) {
                    // (i,j) 作为正方形的右上角，可以服务于左下角横坐标在 [i,i+sz-1] 中的正方形
                    st.insert(i);
                    int sz = min(j - left1[i][j], down1[i][j] - i); // min(左,下)
                    to_remove[i + sz - 1].push_back(i); // 在未来移除

                    // (i,j) 作为正方形的左下角
                    // 找 sl 中的大于 i-size 的最小横坐标 i2
                    sz = min(right1[i][j] - j, i - up1[i][j]); // min(右,上)
                    int i2 = *st.upper_bound(i - sz);
                    // i-i2+1 就是 (i,j) 作为正方形左下角时，正方形的最大边长
                    ans = max(ans, {i - i2 + 1, -i2, -j});
                }

                // 移除那些超过服务范围的右上角横坐标
                for (int i2 : to_remove[i]) {
                    st.erase(i2);
                }
            }
        }

        if (get<0>(ans) == 0) {
            return {};
        }
        return {-get<1>(ans), -get<2>(ans), get<0>(ans)};
    }
};
```

```Go
func findSquare(matrix [][]int) []int {
    n := len(matrix)
    // 预处理每个格子左右上下最近的 1 的位置
    left1 := make([][]int, n)
    right1 := make([][]int, n)
    up1 := make([][]int, n)
    down1 := make([][]int, n)
    for i := range n {
        left1[i] = make([]int, n)
        right1[i] = make([]int, n)
        up1[i] = make([]int, n)
        down1[i] = make([]int, n)
    }

    for i, row := range matrix {
        l := -1
        for j, x := range row {
            if x == 1 {
                l = j
            }
            left1[i][j] = l
        }

        r := n
        for j := n - 1; j >= 0; j-- {
            if row[j] == 1 {
                r = j
            }
            right1[i][j] = r
        }
    }

    for j := range n {
        u := -1
        for i, row := range matrix {
            if row[j] == 1 {
                u = i
            }
            up1[i][j] = u
        }

        d := n
        for i := n - 1; i >= 0; i-- {
            if matrix[i][j] == 1 {
                d = i
            }
            down1[i][j] = d
        }
    }

    var maxSize, minR, minC int

    for k := range n*2 - 1 {
        set := redblacktree.New[int, struct{}]()
        toRemove := make([][]int, n)
        minJ := max(k-n+1, 0)
        maxJ := min(k, n-1)

        for j := maxJ; j >= minJ; j-- {
            i := k - j
            if matrix[i][j] == 0 {
                // (i,j) 作为正方形的右上角，可以服务于左下角横坐标在 [i,i+sz-1] 中的正方形
                set.Put(i, struct{}{})
                sz := min(j-left1[i][j], down1[i][j]-i) // min(左,下)
                toRemove[i+sz-1] = append(toRemove[i+sz-1], i)

                // (i,j) 作为正方形的左下角
                // 找 sl 中的大于 i-size 的最小横坐标 i2
                sz = min(right1[i][j]-j, i-up1[i][j]) // min(右,上)
                node, _ := set.Ceiling(i - sz + 1)
                i2 := node.Key
                size := i - i2 + 1
                if size > maxSize || size == maxSize && (i2 < minR || i2 == minR && j < minC) {
                    maxSize, minR, minC = size, i2, j
                }
            }

            // 移除那些超过服务范围的右上角横坐标
            for _, i2 := range toRemove[i] {
                set.Remove(i2)
            }
        }
    }

    if maxSize == 0 {
        return nil
    }
    return []int{minR, minC, maxSize}
}
```

#### 复杂度分析

注：由于本题数据范围小，这个做法的优势并不明显。

- 时间复杂度：$O(n^2\log n)$，其中 $n$ 是 $matrix$ 的行数和列数。
- 空间复杂度：$O(n^2)$。

#### 相似题目

[CF628E. Zbazi in Zeydabad](https://leetcode.cn/link/?target=https%3A%2F%2Fcodeforces.com%2Fproblemset%2Fproblem%2F628%2FE)

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
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
