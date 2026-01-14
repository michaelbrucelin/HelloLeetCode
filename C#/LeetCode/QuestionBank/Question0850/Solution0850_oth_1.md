### [Lazy 线段树 + 扫描线（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/rectangle-area-ii/solutions/3078272/lazy-xian-duan-shu-sao-miao-xian-pythonj-4tkr/)

![](./assets/img/Solution0850_oth_1.png)

想象有一根水平扫描线在从下往上扫描，对于示例 $1$，这根扫描线依次扫过 $y=0,1,2,3$：

- 从 $y=0$ 到 $y=1$，面积的增加量等于底边长为 $3$，高为 $1$ 的矩形的面积，即 $3\cdot 1=3$。
- 从 $y=1$ 到 $y=2$，面积的增加量等于底边长为 $2$，高为 $1$ 的矩形的面积，即 $2\cdot 1=2$。
- 从 $y=2$ 到 $y=3$，面积的增加量等于底边长为 $1$，高为 $1$ 的矩形的面积，即 $1\cdot 1=1$。

总面积为 $3+2+1=6$。

在扫描的过程中，需要维护横坐标 $[0,3]$ 中，被至少一个矩形覆盖的底边长之和。

也可以反过来计算，用 $3$ 减去没被矩形覆盖的底边长之和。

考虑用 **Lazy 线段树**维护，线段树每个节点维护一段横坐标区间 $[lx,rx]$，记录区间内的：

- $minCoverLen$，区间内被矩形覆盖次数最少的底边长之和。
- $minCover$，区间内被矩形覆盖的最小次数。
- $todo$，子树内的所有节点的 $minCover$ 需要增加的量，注意这可以是负数。

特别地，如果 $minCover=0$，那么 $minCoverLen$ 就表示区间内没被矩形覆盖的底边长之和。

#### 更新操作

- 当扫描线遇到矩形的下边界时，把下边界（这是一个横坐标区间）中的 $minCover$ 都加一。
- 当扫描线遇到矩形的上边界时，把上边界（这是一个横坐标区间）中的 $minCover$ 都减一。
- 线段树节点的 $minCoverLen$，等于其左右儿子 $minCover$ 较小者的 $minCoverLen$。如果左右儿子的 $minCover$ 相等，则节点的 $minCoverLen$ 等于其左右儿子的 $minCoverLen$ 之和。

#### 面积计算

设当前扫描线位于 $y$，下一个需要经过的上/下边界的纵坐标为 $y^′$，那么面积的增加量等于

$$sumLen\cdot (y^′-y)$$

其中 $sumLen$ 是被至少一个矩形覆盖的底边长之和，计算方式如下：

- 设最小的 $x_1$ 为 $minX$，最大的 $x_2$ 为 $maxX$。线段树的根节点为 $tree[1]$，维护横坐标区间 $[minX,maxX]$ 的信息。
- 如果 $tree[1].minCover>0$，说明从 $minX$ 到 $maxX$ 都被至少一个矩形覆盖，那么 $sumLen=maxX-minX$。
- 否则，$sumLen=maxX-minX-tree[1].minCoverLen$，也就是减去 $[minX,maxX]$ 中的没被矩形覆盖的底边长之和。

代码实现时，由于横坐标太大，为了方便使用线段树，可以把所有横坐标**离散化**。例如把 $[10,20,30,40]$ 离散化成 $[0,1,2,3]$。

```Python
class Node:
    __slots__ = 'l', 'r', 'min_cover_len', 'min_cover', 'todo'

    def __init__(self):
        self.l = 0
        self.r = 0
        self.min_cover_len = 0  # 区间内被矩形覆盖次数最少的底边长之和
        self.min_cover = 0      # 区间内被矩形覆盖的最小次数
        self.todo = 0           # 子树内的所有节点的 min_cover 需要增加的量，注意这可以是负数


class SegmentTree:
    def __init__(self, xs: List[int]):
        n = len(xs) - 1  # xs.size() 个横坐标有 xs.size()-1 个差值
        self.seg = [Node() for _ in range(2 << (n - 1).bit_length())]
        self.build(xs, 1, 0, n - 1)

    def get_uncovered_length(self) -> int:
        return 0 if self.seg[1].min_cover else self.seg[1].min_cover_len

    # 根据左右儿子的信息，更新当前节点的信息
    def maintain(self, o: int) -> None:
        lo = self.seg[o * 2]
        ro = self.seg[o * 2 + 1]
        mn = min(lo.min_cover, ro.min_cover)
        self.seg[o].min_cover = mn
        # 只统计等于 min_cover 的底边长之和
        self.seg[o].min_cover_len = (lo.min_cover_len if lo.min_cover == mn else 0) + \
                                    (ro.min_cover_len if ro.min_cover == mn else 0)

    # 仅更新节点信息，不下传懒标记 todo
    def do(self, o: int, v: int) -> None:
        self.seg[o].min_cover += v
        self.seg[o].todo += v

    # 下传懒标记 todo
    def spread(self, o: int) -> None:
        v = self.seg[o].todo
        if v:
            self.do(o * 2, v)
            self.do(o * 2 + 1, v)
            self.seg[o].todo = 0

    # 建树
    def build(self, xs: List[int], o: int, l: int, r: int) -> None:
        self.seg[o].l = l
        self.seg[o].r = r
        if l == r:
            self.seg[o].min_cover_len = xs[l + 1] - xs[l]
            return
        m = (l + r) // 2
        self.build(xs, o * 2, l, m)
        self.build(xs, o * 2 + 1, m + 1, r)
        self.maintain(o)

    # 区间更新
    def update(self, o: int, l: int, r: int, v: int) -> None:
        if l <= self.seg[o].l and self.seg[o].r <= r:
            self.do(o, v)
            return
        self.spread(o)
        m = (self.seg[o].l + self.seg[o].r) // 2
        if l <= m:
            self.update(o * 2, l, r, v)
        if m < r:
            self.update(o * 2 + 1, l, r, v)
        self.maintain(o)


class Solution:
    def rectangleArea(self, rectangles: List[List[int]]) -> int:
        xs = []
        events = []
        for lx, ly, rx, ry in rectangles:
            xs.append(lx)
            xs.append(rx)
            events.append((ly, lx, rx, 1))
            events.append((ry, lx, rx, -1))

        # 排序，方便离散化
        xs = sorted(set(xs))

        # 初始化线段树
        t = SegmentTree(xs)

        # 模拟扫描线从下往上移动
        events.sort(key=lambda e: e[0])
        ans = 0
        for (y, lx, rx, delta), e2 in pairwise(events):
            l = bisect_left(xs, lx)  # 离散化
            r = bisect_left(xs, rx) - 1  # r 对应着 xs[r] 与 xs[r+1]=rx 的差值
            t.update(1, l, r, delta)  # 更新被 [lx, rx] 覆盖的次数
            sum_len = xs[-1] - xs[0] - t.get_uncovered_length()  # 减去没被矩形覆盖的长度
            ans += sum_len * (e2[0] - y)  # 新增面积 = 被至少一个矩形覆盖的底边长之和 * 矩形高度
        return ans % 1_000_000_007
```

```Java
class SegmentTree {
    private final int n;
    private final int[] minCoverLen; // 区间内被矩形覆盖次数最少的底边长之和
    private final int[] minCover;    // 区间内被矩形覆盖的最小次数
    private final int[] todo;        // 子树内的所有节点的 minCover 需要增加的量，注意这可以是负数

    public SegmentTree(int[] xs) {
        n = xs.length - 1; // xs.length 个横坐标有 xs.length-1 个差值
        int size = 2 << (32 - Integer.numberOfLeadingZeros(n - 1));
        minCoverLen = new int[size];
        minCover = new int[size];
        todo = new int[size];
        build(xs, 1, 0, n - 1);
    }

    public void update(int l, int r, int v) {
        update(1, 0, n - 1, l, r, v);
    }

    public int getUncoveredLength() {
        return minCover[1] == 0 ? minCoverLen[1] : 0;
    }

    // 根据左右儿子的信息，更新当前节点的信息
    private void maintain(int o) {
        int mn = Math.min(minCover[o * 2], minCover[o * 2 + 1]);
        minCover[o] = mn;
        // 只统计等于 mn 的底边长之和
        minCoverLen[o] = (minCover[o * 2] == mn ? minCoverLen[o * 2] : 0) +
                         (minCover[o * 2 + 1] == mn ? minCoverLen[o * 2 + 1] : 0);
    }

    // 仅更新节点信息，不下传懒标记 todo
    private void do_(int o, int v) {
        minCover[o] += v;
        todo[o] += v;
    }

    // 下传懒标记 todo
    private void spread(int o) {
        if (todo[o] != 0) {
            do_(o * 2, todo[o]);
            do_(o * 2 + 1, todo[o]);
            todo[o] = 0;
        }
    }

    // 建树
    private void build(int[] xs, int o, int l, int r) {
        if (l == r) {
            minCoverLen[o] = xs[l + 1] - xs[l];
            return;
        }
        int m = (l + r) / 2;
        build(xs, o * 2, l, m);
        build(xs, o * 2 + 1, m + 1, r);
        maintain(o);
    }

    // 区间更新
    private void update(int o, int l, int r, int ql, int qr, int v) {
        if (ql <= l && r <= qr) {
            do_(o, v);
            return;
        }
        spread(o);
        int m = (l + r) / 2;
        if (ql <= m) {
            update(o * 2, l, m, ql, qr, v);
        }
        if (m < qr) {
            update(o * 2 + 1, m + 1, r, ql, qr, v);
        }
        maintain(o);
    }
}

class Solution {
    private record Event(int y, int lx, int rx, int delta) {
    }

    public int rectangleArea(int[][] rectangles) {
        int n = rectangles.length * 2;
        int[] xs = new int[n];
        Event[] events = new Event[n];
        n = 0;
        for (int[] rect : rectangles) {
            int lx = rect[0];
            int rx = rect[2];
            xs[n] = lx;
            xs[n + 1] = rx;
            events[n++] = new Event(rect[1], lx, rx, 1);
            events[n++] = new Event(rect[3], lx, rx, -1);
        }

        // 排序，方便离散化
        Arrays.sort(xs);

        // 初始化线段树
        SegmentTree t = new SegmentTree(xs);

        // 模拟扫描线从下往上移动
        Arrays.sort(events, (a, b) -> a.y - b.y);
        long ans = 0;
        for (int i = 0; i < n - 1; i++) {
            Event e = events[i];
            int l = Arrays.binarySearch(xs, e.lx); // 离散化
            int r = Arrays.binarySearch(xs, e.rx) - 1; // r 对应着 xs[r] 与 xs[r+1]=rx 的差值
            t.update(l, r, e.delta); // 更新被 [lx, rx] 覆盖的次数
            int sumLen = xs[n - 1] - xs[0] - t.getUncoveredLength(); // 减去没被矩形覆盖的长度
            ans += (long) sumLen * (events[i + 1].y - e.y); // 新增面积 = 被至少一个矩形覆盖的底边长之和 * 矩形高度
        }
        return (int) (ans % 1_000_000_007);
    }
}
```

```C++
class SegmentTree {
public:
    SegmentTree(vector<int>& xs) {
        unsigned n = xs.size() - 1; // xs.size() 个横坐标有 xs.size()-1 个差值
        seg.resize(2 << bit_width(n - 1));
        build(xs, 1, 0, n - 1);
    }

    void update(int l, int r, int v) {
        update(1, l, r, v);
    }

    int get_uncovered_length() {
        return seg[1].min_cover ? 0 : seg[1].min_cover_len;
    }

private:
    struct Node {
        int l, r;
        int min_cover_len = 0; // 区间内被矩形覆盖次数最少的底边长之和
        int min_cover = 0;     // 区间内被矩形覆盖的最小次数
        int todo = 0;          // 子树内的所有节点的 min_cover 需要增加的量，注意这可以是负数
    };

    vector<Node> seg;

    // 根据左右儿子的信息，更新当前节点的信息
    void maintain(int o) {
        Node& lo = seg[o * 2];
        Node& ro = seg[o * 2 + 1];
        int mn = min(lo.min_cover, ro.min_cover);
        seg[o].min_cover = mn;
        // 只统计等于 min_cover 的底边长之和
        seg[o].min_cover_len = (lo.min_cover == mn ? lo.min_cover_len : 0) +
                               (ro.min_cover == mn ? ro.min_cover_len : 0);
    }

    // 仅更新节点信息，不下传懒标记 todo
    void do_(int o, int v) {
        seg[o].min_cover += v;
        seg[o].todo += v;
    }

    // 下传懒标记 todo
    void spread(int o) {
        int& v = seg[o].todo;
        if (v != 0) {
            do_(o * 2, v);
            do_(o * 2 + 1, v);
            v = 0;
        }
    }

    // 建树
    void build(vector<int>& xs, int o, int l, int r) {
        seg[o].l = l;
        seg[o].r = r;
        if (l == r) {
            seg[o].min_cover_len = xs[l + 1] - xs[l];
            return;
        }
        int m = (l + r) / 2;
        build(xs, o * 2, l, m);
        build(xs, o * 2 + 1, m + 1, r);
        maintain(o);
    }

    // 区间更新
    void update(int o, int l, int r, int v) {
        if (l <= seg[o].l && seg[o].r <= r) {
            do_(o, v);
            return;
        }
        spread(o);
        int m = (seg[o].l + seg[o].r) / 2;
        if (l <= m) {
            update(o * 2, l, r, v);
        }
        if (m < r) {
            update(o * 2 + 1, l, r, v);
        }
        maintain(o);
    }
};

class Solution {
public:
    int rectangleArea(vector<vector<int>>& rectangles) {
        vector<int> xs;
        struct Event { int y, lx, rx, delta; };
        vector<Event> events;
        for (auto& rect : rectangles) {
            int lx = rect[0], rx = rect[2];
            xs.push_back(lx);
            xs.push_back(rx);
            events.emplace_back(rect[1], lx, rx, 1);
            events.emplace_back(rect[3], lx, rx, -1);
        }

        // 排序去重，方便离散化
        ranges::sort(xs);
        xs.erase(ranges::unique(xs).begin(), xs.end());

        // 初始化线段树
        SegmentTree t(xs);

        // 模拟扫描线从下往上移动
        ranges::sort(events, {}, &Event::y);
        long long ans = 0;
        for (int i = 0; i + 1 < events.size(); i++) {
            auto& [y, lx, rx, delta] = events[i];
            int l = ranges::lower_bound(xs, lx) - xs.begin(); // 离散化
            int r = ranges::lower_bound(xs, rx) - xs.begin() - 1; // r 对应着 xs[r] 与 xs[r+1]=rx 的差值
            t.update(l, r, delta); // 更新被 [lx, rx] 覆盖的次数
            int sum_len = xs.back() - xs[0] - t.get_uncovered_length(); // 减去没被矩形覆盖的长度
            ans += 1LL * sum_len * (events[i + 1].y - y); // 新增面积 = 被至少一个矩形覆盖的底边长之和 * 矩形高度
        }
        return ans % 1'000'000'007;
    }
};
```

```Go
// 线段树每个节点维护一段横坐标区间 [lx, rx]
type seg []struct {
    l, r        int
    minCoverLen int // 区间内被矩形覆盖次数最少的底边长之和
    minCover    int // 区间内被矩形覆盖的最小次数
    todo        int // 子树内的所有节点的 minCover 需要增加的量，注意这可以是负数
}

// 根据左右儿子的信息，更新当前节点的信息
func (t seg) maintain(o int) {
    lo, ro := &t[o<<1], &t[o<<1|1]
    mn := min(lo.minCover, ro.minCover)
    t[o].minCover = mn
    t[o].minCoverLen = 0
    if lo.minCover == mn { // 只统计等于 minCover 的底边长之和
        t[o].minCoverLen = lo.minCoverLen
    }
    if ro.minCover == mn {
        t[o].minCoverLen += ro.minCoverLen
    }
}

// 仅更新节点信息，不下传懒标记 todo
func (t seg) do(o, v int) {
    t[o].minCover += v
    t[o].todo += v
}

// 下传懒标记 todo
func (t seg) spread(o int) {
    v := t[o].todo
    if v != 0 {
        t.do(o<<1, v)
        t.do(o<<1|1, v)
        t[o].todo = 0
    }
}

// 建树
func (t seg) build(xs []int, o, l, r int) {
    t[o].l, t[o].r = l, r
    if l == r {
        t[o].minCoverLen = xs[l+1] - xs[l]
        return
    }
    m := (l + r) >> 1
    t.build(xs, o<<1, l, m)
    t.build(xs, o<<1|1, m+1, r)
    t.maintain(o)
}

// 区间更新
func (t seg) update(o, l, r, v int) {
    if l <= t[o].l && t[o].r <= r {
        t.do(o, v)
        return
    }
    t.spread(o)
    m := (t[o].l + t[o].r) >> 1
    if l <= m {
        t.update(o<<1, l, r, v)
    }
    if m < r {
        t.update(o<<1|1, l, r, v)
    }
    t.maintain(o)
}

func rectangleArea(rectangles [][]int) (ans int) {
    xs := make([]int, 0, len(rectangles)*2)
    type event struct{ y, lx, rx, delta int }
    events := make([]event, 0, len(rectangles)*2)
    for _, rect := range rectangles {
        lx, rx := rect[0], rect[2]
        xs = append(xs, lx, rx)
        events = append(events, event{rect[1], lx, rx, 1}, event{rect[3], lx, rx, -1})
    }

    // 排序去重，方便离散化
    slices.Sort(xs)
    xs = slices.Compact(xs)

    // 初始化线段树
    n := len(xs) - 1 // len(xs) 个横坐标有 len(xs)-1 个差值
    t := make(seg, 2<<bits.Len(uint(n-1)))
    t.build(xs, 1, 0, n-1)

    // 模拟扫描线从下往上移动
    slices.SortFunc(events, func(a, b event) int { return a.y - b.y })
    for i, e := range events[:len(events)-1] {
        l := sort.SearchInts(xs, e.lx)     // 离散化
        r := sort.SearchInts(xs, e.rx) - 1 // r 对应着 xs[r] 与 xs[r+1]=e.rx 的差值
        t.update(1, l, r, e.delta)         // 更新被 [e.lx, e.rx] 覆盖的次数
        sumLen := xs[len(xs)-1] - xs[0]    // 总的底边长度
        if t[1].minCover == 0 {            // 需要去掉没被矩形覆盖的长度
            sumLen -= t[1].minCoverLen
        }
        ans += sumLen * (events[i+1].y - e.y) // 新增面积 = 被至少一个矩形覆盖的底边长之和 * 矩形高度
    }
    return ans % 1_000_000_007
}
```

#### 复杂度分析

- 时间复杂度：$O(n\log n)$，其中 $n$ 是 $rectangles$ 的长度。
- 空间复杂度：$O(n)$。

更多相似题目，见下面数据结构题单中的「**§8.4 $Lazy$ 线段树**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. 【本题相关】[常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
