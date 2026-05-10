### [两种方法：普通 DP/值域线段树优化 DP（Python/Java/C++/Go）](https://leetcode.cn/problems/maximum-number-of-jumps-to-reach-the-last-index/solutions/2336752/dong-tai-gui-hua-cong-ji-yi-hua-sou-suo-2ptkg/)

#### 一、寻找子问题

想一想，最后一步发生了什么？

最后一步，我们从某个满足条件的下标 $i$ 跳到了下标 $n-1$。

枚举满足条件的 $i$，问题变成：

- 从下标 $0$ 到达下标 $i$ 所需的最大跳跃次数。

这是**和原问题相似的、规模更小的子问题**，可以用**递归**解决。

> 注：从右往左思考，主要是方便把递归翻译成从左往右的递推。从左往右思考也是可以的。

#### 二、状态定义与状态转移方程

根据上面的讨论，定义 $dfs(j)$ 表示从下标 $0$ 到达下标 $j$ 所需的最大跳跃次数。

枚举满足 $0\le i<j$ 且 $\vert nums[i]-nums[j]\vert \le target$ 的下标 $i$，问题变成从下标 $0$ 到达下标 $i$ 所需的最大跳跃次数，再加上从 $i$ 跳到 $j$ 的一次。

取最大值，得

$$dfs(j)=\mathop{max}\limits_i dfs(i)+1$$

其中 $0\le i<j$ 且 $\vert nums[i]-nums[j]\vert \le target$。

**递归边界**：

- $dfs(0)=0$。从 $0$ 到 $0$ 不用跳。
- 如果没有满足条件的 $i$，那么 $dfs(j)=-\infty $。

**递归入口**：$dfs(n-1)$，这是原问题，也是答案。

#### 三、递归搜索 $+$ 保存递归返回值 $=$ 记忆化搜索

考虑到整个递归过程中有大量重复递归调用（递归入参相同）。由于递归函数没有副作用，同样的入参无论计算多少次，算出来的结果都是一样的，因此可以用**记忆化搜索**来优化：

- 如果一个状态（递归入参）是第一次遇到，那么可以在返回前，把状态及其结果记到一个 $memo$ 数组中。
- 如果一个状态不是第一次遇到（$memo$ 中保存的结果不等于 $memo$ 的初始值），那么可以直接返回 $memo$ 中保存的结果。

> $Python$ 用户可以无视上面这段，直接用 `@cache` 装饰器。

关于记忆化搜索的原理，请看视频讲解 [动态规划入门：从记忆化搜索到递推【基础算法精讲 17】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1Xj411K7oF%2F)，其中包含把记忆化搜索 $1:1$ 翻译成递推的技巧。

```Python
class Solution:
    def maximumJumps(self, nums: List[int], target: int) -> int:
        @cache  # 缓存装饰器，避免重复计算 dfs（一行代码实现记忆化）
        def dfs(j: int) -> int:
            if j == 0:  # 起点
                return 0
            res = -inf
            for i in range(j):
                if abs(nums[i] - nums[j]) <= target:  # 可以从 i 跳到 j
                    res = max(res, dfs(i) + 1)
            return res

        ans = dfs(len(nums) - 1)  # 终点
        return -1 if ans < 0 else ans
```

```Java
class Solution {
    public int maximumJumps(int[] nums, int target) {
        int n = nums.length;
        int[] memo = new int[n];
        int ans = dfs(n - 1, nums, target, memo);
        return ans < 0 ? -1 : ans;
    }

    private int dfs(int j, int[] nums, int target, int[] memo) {
        if (j == 0) { // 起点
            return 0;
        }

        if (memo[j] != 0) { // 之前计算过
            return memo[j];
        }

        int res = Integer.MIN_VALUE;
        for (int i = 0; i < j; i++) {
            if (Math.abs(nums[i] - nums[j]) <= target) { // 可以从 i 跳到 j
                res = Math.max(res, dfs(i, nums, target, memo) + 1);
            }
        }
        memo[j] = res; // 记忆化
        return res;
    }
}
```

```C++
class Solution {
public:
    int maximumJumps(vector<int>& nums, int target) {
        int n = nums.size();
        vector<int> memo(n);

        auto dfs = [&](this auto&& dfs, int j) -> int {
            if (j == 0) { // 起点
                return 0;
            }

            int& res = memo[j]; // 注意这里是引用
            if (res) { // 之前计算过
                return res;
            }

            res = INT_MIN;
            for (int i = 0; i < j; i++) {
                if (abs(nums[i] - nums[j]) <= target) { // 可以从 i 跳到 j
                    res = max(res, dfs(i) + 1);
                }
            }
            return res;
        };

        int ans = dfs(n - 1); // 终点
        return ans < 0 ? -1 : ans;
    }
};
```

```Go
func maximumJumps(nums []int, target int) int {
    n := len(nums)
    memo := make([]int, n)

    var dfs func(int) int
    dfs = func(j int) int {
        if j == 0 { // 起点
            return 0
        }

        p := &memo[j]
        if *p != 0 { // 之前计算过
            return *p
        }

        res := math.MinInt
        for i, x := range nums[:j] {
            if abs(x-nums[j]) <= target { // 可以从 i 跳到 j
                res = max(res, dfs(i)+1)
            }
        }
        *p = res // 记忆化
        return res
    }

    ans := dfs(n - 1) // 终点
    if ans < 0 {
        return -1
    }
    return ans
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $nums$ 的长度。由于每个状态只会计算一次，动态规划的时间复杂度 $=$ 状态个数 $\times $ 单个状态的计算时间。本题状态个数等于 $O(n)$，单个状态的计算时间为 $O(n)$，所以总的时间复杂度为 $O(n^2)$。
- 空间复杂度：$O(n)$。保存多少状态，就需要多少空间。

## 四、1:1 翻译成递推

我们可以去掉递归中的「递」，只保留「归」的部分，即自底向上计算。

具体来说，$f[j]$ 的定义和 $dfs(j)$ 的定义是完全一样的，都表示从下标 $0$ 到达下标 $j$ 所需的最大跳跃次数。

相应的递推式（状态转移方程）也和 $dfs$ 一样：

$$f[j]=\mathop{max}\limits_i f[i]+1$$

其中 $0\le i<j$ 且 $\vert nums[i]-nums[j]\vert \le target$。

如果没有满足条件的 $i$，那么 $f[j]=-\infty $。

初始值 $f[0]=0$，翻译自递归边界 $dfs(0)=0$。

答案为 $f[n-1]$，翻译自递归入口 $dfs(n-1)$。

```Python
class Solution:
    def maximumJumps(self, nums: List[int], target: int) -> int:
        n = len(nums)
        f = [-inf] * n
        f[0] = 0
        for j in range(1, n):
            for i in range(j):
                if abs(nums[i] - nums[j]) <= target:  # 可以从 i 跳到 j
                    f[j] = max(f[j], f[i] + 1)
        return -1 if f[-1] < 0 else f[-1]
```

```Java
class Solution {
    public int maximumJumps(int[] nums, int target) {
        int n = nums.length;
        int[] f = new int[n];
        for (int j = 1; j < n; j++) {
            f[j] = Integer.MIN_VALUE;
            for (int i = 0; i < j; i++) {
                if (Math.abs(nums[i] - nums[j]) <= target) { // 可以从 i 跳到 j
                    f[j] = Math.max(f[j], f[i] + 1);
                }
            }
        }
        return f[n - 1] < 0 ? -1 : f[n - 1];
    }
}
```

```C++
class Solution {
public:
    int maximumJumps(vector<int>& nums, int target) {
        int n = nums.size();
        vector<int> f(n, INT_MIN);
        f[0] = 0;
        for (int j = 1; j < n; j++) {
            for (int i = 0; i < j; i++) {
                if (abs(nums[i] - nums[j]) <= target) { // 可以从 i 跳到 j
                    f[j] = max(f[j], f[i] + 1);
                }
            }
        }
        return f[n - 1] < 0 ? -1 : f[n - 1];
    }
};
```

```Go
func maximumJumps(nums []int, target int) int {
    n := len(nums)
    f := make([]int, n)

    for j := 1; j < n; j++ {
        f[j] = math.MinInt
        for i, x := range nums[:j] {
            if abs(x-nums[j]) <= target { // 可以从 i 跳到 j
                f[j] = max(f[j], f[i]+1)
            }
        }
    }

    if f[n-1] < 0 {
        return -1
    }
    return f[n-1]
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(n)$。

## 五、值域线段树优化 $DP$

如果 $n=105$，上面的做法就超时了。

遍历到 $nums[j]$ 时，我们需要知道满足 $nums[j]-target\le nums[i]\le nums[j]+target$ 的最大的 $f[i]$。

这可以用一棵**值域线段树**维护。线段树的区间是值域区间，例如区间 $[20,23]$ 指的是 $nums$ 中的元素 $20,21,22,23$。线段树的每个节点保存的是值域区间对应的最大的 $f[i]$。例如 $nums[4]=20$ 且 $f[4]=3$，那么线段树维护的位置 $20$ 更新为 $3$。

如此一来，满足 $nums[j]-target\le nums[i]\le nums[j]+target$ 的最大的 $f[i]$，可以通过线段树的**区间最值查询**得到。

```Python
# 完整的线段树模板见 https://leetcode.cn/circle/discuss/mOr1u6/
class SegmentTree:
    def __init__(self, n: int) -> None:
        self.t = [-inf] * (2 << (n - 1).bit_length())

    def update(self, node: int, l: int, r: int, i: int, val: int) -> None:
        if l == r:  # 叶子
            self.t[node] = val
            return
        m = (l + r) // 2
        if i <= m:  # i 在左子树
            self.update(node * 2, l, m, i, val)
        else:  # i 在右子树
            self.update(node * 2 + 1, m + 1, r, i, val)
        self.t[node] = max(self.t[node * 2], self.t[node * 2 + 1])

    def query(self, node: int, l: int, r: int, ql: int, qr: int) -> int:
        if ql <= l and r <= qr:  # 当前子树完全在 [ql, qr] 内
            return self.t[node]
        m = (l + r) // 2
        if qr <= m:  # [ql, qr] 在左子树
            return self.query(node * 2, l, m, ql, qr)
        if ql > m:  # [ql, qr] 在右子树
            return self.query(node * 2 + 1, m + 1, r, ql, qr)
        return max(self.query(node * 2, l, m, ql, qr), self.query(node * 2 + 1, m + 1, r, ql, qr))


class Solution:
    def maximumJumps(self, nums: List[int], target: int) -> int:
        # 去重排序，便于离散化
        sorted_nums = sorted(set(nums))

        n = len(nums)
        m = len(sorted_nums)
        t = SegmentTree(m)  # 值域线段树

        # nums[0] 对应的 f[0] = 0
        t.update(1, 0, m - 1, bisect_left(sorted_nums, nums[0]), 0)

        for j in range(1, n):
            l = bisect_left(sorted_nums, nums[j] - target)       # >= nums[j]-target 的第一个数
            r = bisect_right(sorted_nums, nums[j] + target) - 1  # <= nums[j]+target 的最后一个数
            # t.query 返回满足 nums[j]-target <= nums[i] <= nums[j]+target 的最大的 f[i]
            fj = t.query(1, 0, m - 1, l, r) + 1
            t.update(1, 0, m - 1, bisect_left(sorted_nums, nums[j]), fj)

        return -1 if fj < 0 else fj
```

```Java
class Solution {
    // 完整的线段树模板见 https://leetcode.cn/circle/discuss/mOr1u6/
    private int[] tree;

    private void update(int node, int l, int r, int i, int val) {
        if (l == r) { // 叶子
            tree[node] = val;
            return;
        }
        int m = (l + r) / 2;
        if (i <= m) { // i 在左子树
            update(node * 2, l, m, i, val);
        } else { // i 在右子树
            update(node * 2 + 1, m + 1, r, i, val);
        }
        tree[node] = Math.max(tree[node * 2], tree[node * 2 + 1]);
    }

    private int query(int node, int l, int r, int ql, int qr) {
        if (ql <= l && r <= qr) { // 当前子树完全在 [ql, qr] 内
            return tree[node];
        }
        int m = (l + r) / 2;
        if (qr <= m) { // [ql, qr] 在左子树
            return query(node * 2, l, m, ql, qr);
        }
        if (ql > m) { // [ql, qr] 在右子树
            return query(node * 2 + 1, m + 1, r, ql, qr);
        }
        return Math.max(query(node * 2, l, m, ql, qr), query(node * 2 + 1, m + 1, r, ql, qr));
    }

    public int maximumJumps(int[] nums, int target) {
        int n = nums.length;
        int[] sorted = nums.clone(); // 用于离散化
        Arrays.sort(sorted);

        tree = new int[2 << (32 - Integer.numberOfLeadingZeros(n - 1))];
        Arrays.fill(tree, Integer.MIN_VALUE);

        // nums[0] 对应的 f[0] = 0
        update(1, 0, n - 1, lowerBound(sorted, nums[0]), 0);

        for (int j = 1; ; j++) {
            int l = lowerBound(sorted, (long) nums[j] - target);         // >= nums[j]-target 的第一个数
            int r = lowerBound(sorted, (long) nums[j] + target + 1) - 1; // <= nums[j]+target 的最后一个数
            // query 返回满足 nums[j]-target <= nums[i] <= nums[j]+target 的最大的 f[i]
            int fj = query(1, 0, n - 1, l, r) + 1;
            if (j == n - 1) {
                return fj < 0 ? -1 : fj;
            }
            update(1, 0, n - 1, lowerBound(sorted, nums[j]), fj);
        }
    }

    // 见 https://www.bilibili.com/video/BV1AP41137w7/
    private int lowerBound(int[] nums, long target) {
        int left = -1;
        int right = nums.length;
        while (left + 1 < right) {
            int mid = (left + right) >>> 1;
            if (nums[mid] >= target) {
                right = mid;
            } else {
                left = mid;
            }
        }
        return right;
    }
}
```

```C++
// 完整的线段树模板见 https://leetcode.cn/circle/discuss/mOr1u6/
class SegmentTree {
    vector<int> tree;

public:
    SegmentTree(int n) : tree(2 << bit_width(n - 1u), INT_MIN) {}

    void update(int node, int l, int r, int i, int val) {
        if (l == r) { // 叶子
            tree[node] = val;
            return;
        }
        int m = (l + r) / 2;
        if (i <= m) { // i 在左子树
            update(node * 2, l, m, i, val);
        } else { // i 在右子树
            update(node * 2 + 1, m + 1, r, i, val);
        }
        tree[node] = max(tree[node * 2], tree[node * 2 + 1]);
    }

    int query(int node, int l, int r, int ql, int qr) const {
        if (ql <= l && r <= qr) { // 当前子树完全在 [ql, qr] 内
            return tree[node];
        }
        int m = (l + r) / 2;
        if (qr <= m) { // [ql, qr] 在左子树
            return query(node * 2, l, m, ql, qr);
        }
        if (ql > m) { // [ql, qr] 在右子树
            return query(node * 2 + 1, m + 1, r, ql, qr);
        }
        return max(query(node * 2, l, m, ql, qr), query(node * 2 + 1, m + 1, r, ql, qr));
    }
};

class Solution {
public:
    int maximumJumps(vector<int>& nums, int target) {
        // 排序去重，便于离散化
        auto sorted = nums;
        ranges::sort(sorted);
        sorted.erase(ranges::unique(sorted).begin(), sorted.end());

        int n = nums.size();
        int m = sorted.size();

        SegmentTree t(m); // 值域线段树

        // nums[0] 对应的 f[0] = 0
        int pos = ranges::lower_bound(sorted, nums[0]) - sorted.begin();
        t.update(1, 0, m - 1, pos, 0);

        long long tar = target;
        for (int j = 1; ; j++) {
            int l = ranges::lower_bound(sorted, nums[j] - tar) - sorted.begin();     // >= nums[j]-target 的第一个数
            int r = ranges::upper_bound(sorted, nums[j] + tar) - sorted.begin() - 1; // <= nums[j]+target 的最后一个数
            // t.query 返回满足 nums[j]-target <= nums[i] <= nums[j]+target 的最大的 f[i]
            int fj = t.query(1, 0, m - 1, l, r) + 1;
            if (j == n - 1) {
                return fj < 0 ? -1 : fj;
            }
            pos = ranges::lower_bound(sorted, nums[j]) - sorted.begin();
            t.update(1, 0, m - 1, pos, fj);
        }
    }
};
```

```Go
// 完整的线段树模板见 https://leetcode.cn/circle/discuss/mOr1u6/
type seg []int

func (t seg) update(node, l, r, i, val int) {
    if l == r { // 叶子
        t[node] = val
        return
    }
    m := (l + r) / 2
    if i <= m { // i 在左子树
        t.update(node*2, l, m, i, val)
    } else { // i 在右子树
        t.update(node*2+1, m+1, r, i, val)
    }
    t[node] = max(t[node*2], t[node*2+1])
}

func (t seg) query(node, l, r, ql, qr int) int {
    if ql <= l && r <= qr { // 当前子树完全在 [ql, qr] 内
        return t[node]
    }
    m := (l + r) / 2
    if qr <= m { // [ql, qr] 在左子树
        return t.query(node*2, l, m, ql, qr)
    }
    if ql > m { // [ql, qr] 在右子树
        return t.query(node*2+1, m+1, r, ql, qr)
    }
    return max(t.query(node*2, l, m, ql, qr), t.query(node*2+1, m+1, r, ql, qr))
}

func maximumJumps(nums []int, target int) int {
    // 排序去重，便于离散化
    sorted := slices.Clone(nums)
    slices.Sort(sorted)
    sorted = slices.Compact(sorted)

    n := len(nums)
    m := len(sorted)

    t := make(seg, 2<<bits.Len(uint(m-1))) // 值域线段树
    for i := range t {
        t[i] = math.MinInt
    }

    // nums[0] 对应的 f[0] = 0
    t.update(1, 0, m-1, sort.SearchInts(sorted, nums[0]), 0)

    for j := 1; ; j++ {
        l := sort.SearchInts(sorted, nums[j]-target)       // >= nums[j]-target 的第一个数
        r := sort.SearchInts(sorted, nums[j]+target+1) - 1 // <= nums[j]+target 的最后一个数
        // t.query 返回满足 nums[j]-target <= nums[i] <= nums[j]+target 的最大的 f[i]
        fj := t.query(1, 0, m-1, l, r) + 1
        if j == n-1 {
            if fj < 0 {
                return -1
            }
            return fj
        }
        t.update(1, 0, m-1, sort.SearchInts(sorted, nums[j]), fj)
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n\log n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(n)$。

#### 相似题目

[2407\. 最长递增子序列 $II](https://leetcode.cn/problems/longest-increasing-subsequence-ii/)$

更多相似题目，见下面动态规划题单的「**§11.4 树状数组/线段树优化 DP**」和「**专题：跳跃游戏**」。

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
