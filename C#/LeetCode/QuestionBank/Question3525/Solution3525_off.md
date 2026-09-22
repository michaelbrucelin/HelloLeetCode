### [求出数组的 X 值 II](https://leetcode.cn/problems/find-x-value-of-array-ii/solutions/4023775/qiu-chu-shu-zu-de-x-zhi-ii-by-leetcode-s-hbjk/)

#### 方法一：线段树

请读者先完成本题的前置题「[3524\. 求出数组的 $X$ 值 I](https://leetcode.cn/problems/find-x-value-of-array-i/)」。

在本题中我们需要回答询问 $queries[i]=[index_i,value_i,start_i,x_i]$。

在每个询问中，我们将对数组 $nums$ 做出如下更改：

- 更新元素：$nums[index_i]:=value_i$
- 移除 $nums$ 的前缀 $nums[0,start_i-1]$

我们需要求出进行上述更改**后**，数组 $nums$ 的 $x_i$ 值。

x 值的定义与前置题相同，即统计执行一次操作后，剩余元素的乘积除以 $k$ 的余数为 $x$ 的方案数。

不过，本题中操作的定义与前置题有所不同：在前置题中，我们可以在一次操作中移除任意不重叠的前缀和后缀；而在本题中，我们只能移除一个后缀。

注意，我们要求的是更改后数组的 $x$ 值。原数组的前缀 $nums[0,start_i-1]$ 在我们进行操作前已经被移除，此后我们可以执行一次操作，继续移除一个后缀。因此对于每个查询来说，操作结束后的剩余部分一定是原数组的一个**非空子数组** $nums[start_i,j]$。

进一步地，不同的子数组 $nums[start_i,j]$ 与不同的合法操作之间同样存在一一对应的关系。具体来说，为了得到子数组 $nums[start_i,j]$，我们只能移除后缀 $nums[j+1,n-1]$，其中 $n$ 是 $nums$ 的长度。

因此，本题的询问可以转化为以下问题：

1. 单点修改 $nums[index_i]$；
2. 统计所有以 $start_i$ 为左端点的非空子数组 $nums[start_i,j]$ 中，满足子数组元素乘积除以 $k$ 的余数为 $x_i$ 的子数组个数。

**思路与算法**

前置题的动态规划解法需要遍历整个数组 $nums$。因此，如果对于每次询问都重新执行一次动态规划，时间复杂度将达到 $O(nq)$，无法通过本题。

注意到，子数组元素乘积除以 $k$ 后的余数只有 $k$ 种可能，且本题中 $k$ 的范围仍然很小。我们考虑在线段树的每个节点中维护不同余数对应的统计信息，并通过枚举余数完成区间合并。为方便起见，除非有特殊说明，下文中的余数均指元素乘积除以 $k$ 后得到的余数。

具体来说，对于线段树中的每个节点所表示的区间，我们维护一个长度为 $k$ 的数组：

pre[x]：表示以该区间左端点开始的**非空**子数组中，子数组元素乘积的余数为 $x$ 的子数组个数。

设当前节点对应区间为 $[l,r]$，左右子节点分别对应区间 $[l,m]$ 和 $[m+1,r]$。

下面讨论如何由子节点的信息合并得到当前节点的信息。

对于 $pre$，考虑一个以 $l$ 为左端点的子数组，有两种情况：

**1\. 完全位于左节点对应的区间中**

$$[l,j]l\le j\le m$$

这种情况下，子数组个数可以直接由左节点的 $pre$ 转移得到。

**2\. 包含整个左节点对应的区间，并继续向右延伸到右节点的部分区间**

$$[l,j]=[l,m]+[m+1,j]m+1\le j\le r$$

在这种情况中，子数组由两部分拼接而成：左节点代表的完整区间 $[l,m]$，以及以右节点所代表区间的左端点 $m+1$ 为起始位置的区间 $[m+1,j]$。

设左节点整个区间元素乘积的余数为 $mul_L$，若右节点某个前缀子数组乘积的余数为 $x$，则合并后的乘积余数为

$$(mul_L\times x)\bmod k$$

因此，只需枚举右节点的所有前缀余数即可完成转移，合并得到单个节点的 $pre$ 数组的时间复杂度为 $O(k)$。此外，这里的转移需要用到整个区间元素乘积的余数，我们在线段树中额外维护即可。

通过以上方法，我们实时维护了 $nums$ 中任意一个非空后缀 $nums[i,n-1]$ 的信息 $pre[x]$，即以该后缀左端点 $i$ 开始的子数组中，元素乘积的余数为 $x$ 的子数组个数。

对于每个询问，我们查询区间 $[start,n-1]$ 对应节点的信息 $pre$，答案就是 $pre[x_i]$。

在下面的示例代码中，$pre$ 数组长度被设置为 $k+1$，最后一个元素表示整个区间元素乘积的余数 $mul$。

> 思考题：
>
> 本题中，对于每个询问，我们需要回答所有以 $starti$ 为左端点的非空子数组中，满足子数组元素乘积的余数为 $x_i$ 的子数组个数。在这里，纳入统计的子数组的左端点是固定的。
>
> 如果需要进行统计的子数组左右端点均不固定，本题代码是否能直接解决该问题？换句话说，如果我们需要回答位于子数组 $nums[starti,endi]$ **内部**的所有子数组中，满足子数组元素乘积的余数为 $x_i$ 的子数组个数，解法如何？

**代码**

```Python
class SegmentTree:
    def __init__(self, nums: List[int], k: int):
        self.k = k
        n = len(nums)
        size = 2 << n.bit_length()

        # tree[o] = pre + [mul]
        self.tree = [[0] * (k + 1) for _ in range(size)]

        self.build(nums, 1, 0, n - 1)

    def makeLeaf(self, o: int, value: int) -> None:
        info = [0] * (self.k + 1)
        r = value % self.k
        info[r] = 1
        info[self.k] = r  # mul
        self.tree[o] = info

    def mergePre(self, left: List[int], right: List[int]) -> List[int]:
        pre = [0] * (self.k + 1)

        mul_L = left[self.k]
        mul_R = right[self.k]

        # 整个区间的乘积余数
        pre[self.k] = (mul_L * mul_R) % self.k

        # 情况 1：完全位于左区间
        for x in range(self.k):
            pre[x] = left[x]

        # 情况 2：包含整个左区间，再接右区间前缀
        for x in range(self.k):
            pre[(mul_L * x) % self.k] += right[x]

        return pre

    def maintain(self, o: int) -> None:
        self.tree[o] = self.mergePre(
            self.tree[o * 2],
            self.tree[o * 2 + 1],
        )

    def build(self, nums: List[int], o: int, l: int, r: int) -> None:
        if l == r:
            self.makeLeaf(o, nums[l])
            return

        m = (l + r) // 2
        self.build(nums, o * 2, l, m)
        self.build(nums, o * 2 + 1, m + 1, r)
        self.maintain(o)

    def update(self, o: int, l: int, r: int, index: int, value: int) -> None:
        if l == r:
            self.makeLeaf(o, value)
            return

        m = (l + r) // 2
        if index <= m:
            self.update(o * 2, l, m, index, value)
        else:
            self.update(o * 2 + 1, m + 1, r, index, value)

        self.maintain(o)

    def query(self, o: int, l: int, r: int, L: int, R: int) -> List[int]:
        if L <= l and r <= R:
            return self.tree[o]

        m = (l + r) // 2
        if R <= m:
            return self.query(o * 2, l, m, L, R)
        if L > m:
            return self.query(o * 2 + 1, m + 1, r, L, R)

        left = self.query(o * 2, l, m, L, R)
        right = self.query(o * 2 + 1, m + 1, r, L, R)
        return self.mergePre(left, right)


class Solution:
    def resultArray(self, nums: List[int], k: int, queries: List[List[int]]) -> List[int]:
        n = len(nums)
        seg = SegmentTree(nums, k)

        ans = []
        for index, value, start, x in queries:
            seg.update(1, 0, n - 1, index, value)
            pre = seg.query(1, 0, n - 1, start, n - 1)
            ans.append(pre[x])

        return ans
```

```C++
class SegmentTree {
private:
    static const int MAXK = 6;
    int k;
    int n;
    vector<array<int, MAXK>> tree;

    void makeLeaf(int o, int value) {
        tree[o].fill(0);
        int r = value % k;
        tree[o][r] = 1;
        tree[o][k] = r;  // mul
    }

    void mergePre(const array<int, MAXK>& left, const array<int, MAXK>& right, array<int, MAXK>& result) {
        result.fill(0);

        int mulL = left[k];
        int mulR = right[k];
        result[k] = (mulL * mulR) % k;

        // 情况1：完全位于左区间
        for (int x = 0; x < k; x++) {
            result[x] = left[x];
        }

        // 情况2：包含整个左区间，再接右区间前缀
        for (int x = 0; x < k; x++) {
            result[(mulL * x) % k] += right[x];
        }
    }

    void maintain(int o) {
        mergePre(tree[o * 2], tree[o * 2 + 1], tree[o]);
    }

    void build(const vector<int>& nums, int o, int l, int r) {
        if (l == r) {
            makeLeaf(o, nums[l]);
            return;
        }
        int m = (l + r) / 2;
        build(nums, o * 2, l, m);
        build(nums, o * 2 + 1, m + 1, r);
        maintain(o);
    }

public:
    SegmentTree(const vector<int>& nums, int k) : k(k), n(nums.size()) {
        int size = 2 << (int)ceil(log2(n));
        tree.resize(size);
        build(nums, 1, 0, n - 1);
    }

    void update(int o, int l, int r, int index, int value) {
        if (l == r) {
            makeLeaf(o, value);
            return;
        }
        int m = (l + r) / 2;
        if (index <= m) update(o * 2, l, m, index, value);
        else update(o * 2 + 1, m + 1, r, index, value);
        maintain(o);
    }

    array<int, MAXK> query(int o, int l, int r, int L, int R) {
        if (L <= l && r <= R) {
            return tree[o];
        }
        int m = (l + r) / 2;
        if (R <= m) {
            return query(o * 2, l, m, L, R);
        }
        if (L > m) {
            return query(o * 2 + 1, m + 1, r, L, R);
        }
        array<int, MAXK> left = query(o * 2, l, m, L, R);
        array<int, MAXK> right = query(o * 2 + 1, m + 1, r, L, R);
        array<int, MAXK> result;
        mergePre(left, right, result);
        return result;
    }
};

class Solution {
public:
    vector<int> resultArray(vector<int>& nums, int k, vector<vector<int>>& queries) {
        int n = nums.size();
        SegmentTree seg(nums, k);
        vector<int> ans;

        for (auto& q : queries) {
            int index = q[0], value = q[1], start = q[2], x = q[3];
            seg.update(1, 0, n - 1, index, value);
            auto pre = seg.query(1, 0, n - 1, start, n - 1);
            ans.push_back(pre[x]);
        }
        return ans;
    }
};
```

```Java
class SegmentTree {
    private static final int MAXK = 6;
    private int k;
    private int n;
    private int[][] tree;

    public SegmentTree(int[] nums, int k) {
        this.k = k;
        this.n = nums.length;
        int size = 2 << (Integer.toBinaryString(n).length());
        tree = new int[size][MAXK];
        build(nums, 1, 0, n - 1);
    }

    private void makeLeaf(int o, int value) {
        Arrays.fill(tree[o], 0);
        int r = value % k;
        tree[o][r] = 1;
        tree[o][k] = r;
    }

    private void mergePre(int[] left, int[] right, int[] result) {
        int mulL = left[k];
        int mulR = right[k];
        result[k] = (mulL * mulR) % k;

        for (int x = 0; x < k; x++) {
            result[x] = left[x];
        }
        for (int x = 0; x < k; x++) {
            result[(mulL * x) % k] += right[x];
        }
    }

    private void maintain(int o) {
        mergePre(tree[o * 2], tree[o * 2 + 1], tree[o]);
    }

    private void build(int[] nums, int o, int l, int r) {
        if (l == r) {
            makeLeaf(o, nums[l]);
            return;
        }
        int m = (l + r) / 2;
        build(nums, o * 2, l, m);
        build(nums, o * 2 + 1, m + 1, r);
        maintain(o);
    }

    public void update(int o, int l, int r, int index, int value) {
        if (l == r) {
            makeLeaf(o, value);
            return;
        }
        int m = (l + r) / 2;
        if (index <= m) {
            update(o * 2, l, m, index, value);
        } else {
            update(o * 2 + 1, m + 1, r, index, value);
        }
        maintain(o);
    }

    public int[] query(int o, int l, int r, int L, int R) {
        if (L <= l && r <= R) {
            return tree[o];
        }

        int m = (l + r) / 2;
        if (R <= m) {
            return query(o * 2, l, m, L, R);
        }
        if (L > m) {
            return query(o * 2 + 1, m + 1, r, L, R);
        }

        int[] left = query(o * 2, l, m, L, R);
        int[] right = query(o * 2 + 1, m + 1, r, L, R);
        int[] result = new int[MAXK];
        mergePre(left, right, result);
        return result;
    }
}

class Solution {
    public int[] resultArray(int[] nums, int k, int[][] queries) {
        int n = nums.length;
        SegmentTree seg = new SegmentTree(nums, k);
        int[] ans = new int[queries.length];

        for (int i = 0; i < queries.length; i++) {
            int[] q = queries[i];
            int index = q[0];
            int value = q[1];
            int start = q[2];
            int x = q[3];

            seg.update(1, 0, n - 1, index, value);
            int[] pre = seg.query(1, 0, n - 1, start, n - 1);
            ans[i] = pre[x];
        }

        return ans;
    }
}
```

```CSharp
public class SegmentTree {
    private const int MAXK = 6;
    private int k;
    private int n;
    private int[][] tree;

    public SegmentTree(int[] nums, int k) {
        this.k = k;
        this.n = nums.Length;
        int size = 2 << (Convert.ToString(n, 2).Length);
        tree = new int[size][];
        for (int i = 0; i < size; i++) {
            tree[i] = new int[MAXK];
        }
        Build(nums, 1, 0, n - 1);
    }

    private void MakeLeaf(int o, int value) {
        Array.Fill(tree[o], 0);
        int r = value % k;
        tree[o][r] = 1;
        tree[o][k] = r;
    }

    private void MergePre(int[] left, int[] right, int[] result) {
        int mulL = left[k];
        int mulR = right[k];
        result[k] = (mulL * mulR) % k;

        for (int x = 0; x < k; x++) {
            result[x] = left[x];
        }
        for (int x = 0; x < k; x++) {
            result[(mulL * x) % k] += right[x];
        }
    }

    private void Maintain(int o) {
        MergePre(tree[o * 2], tree[o * 2 + 1], tree[o]);
    }

    private void Build(int[] nums, int o, int l, int r) {
        if (l == r) {
            MakeLeaf(o, nums[l]);
            return;
        }
        int m = (l + r) / 2;
        Build(nums, o * 2, l, m);
        Build(nums, o * 2 + 1, m + 1, r);
        Maintain(o);
    }

    public void Update(int o, int l, int r, int index, int value) {
        if (l == r) {
            MakeLeaf(o, value);
            return;
        }
        int m = (l + r) / 2;
        if (index <= m) {
            Update(o * 2, l, m, index, value);
        } else {
            Update(o * 2 + 1, m + 1, r, index, value);
        }
        Maintain(o);
    }

    public int[] Query(int o, int l, int r, int L, int R) {
        if (L <= l && r <= R) {
            return tree[o];
        }

        int m = (l + r) / 2;
        if (R <= m) {
            return Query(o * 2, l, m, L, R);
        }
        if (L > m) {
            return Query(o * 2 + 1, m + 1, r, L, R);
        }

        int[] left = Query(o * 2, l, m, L, R);
        int[] right = Query(o * 2 + 1, m + 1, r, L, R);
        int[] result = new int[MAXK];
        MergePre(left, right, result);
        return result;
    }
}

public class Solution {
    public int[] ResultArray(int[] nums, int k, int[][] queries) {
        int n = nums.Length;
        SegmentTree seg = new SegmentTree(nums, k);
        int[] ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++) {
            int[] q = queries[i];
            int index = q[0];
            int value = q[1];
            int start = q[2];
            int x = q[3];

            seg.Update(1, 0, n - 1, index, value);
            int[] pre = seg.Query(1, 0, n - 1, start, n - 1);
            ans[i] = pre[x];
        }

        return ans;
    }
}
```

```Go
func resultArray(nums []int, k int, queries [][]int) []int {
    n := len(nums)
    seg := NewSegmentTree(nums, k)
    ans := []int{}

    for _, q := range queries {
        index, value, start, x := q[0], q[1], q[2], q[3]
        seg.Update(1, 0, n-1, index, value)
        pre := seg.Query(1, 0, n-1, start, n-1)
        ans = append(ans, pre[x])
    }
    return ans
}

type SegmentTree struct {
    k    int
    tree [][]int
}

func NewSegmentTree(nums []int, k int) *SegmentTree {
    n := len(nums)
    size := 1 << (bitsLen(n) + 1)
    tree := make([][]int, size)
    for i := range tree {
        tree[i] = make([]int, k+1)
    }
    seg := &SegmentTree{k: k, tree: tree}
    seg.build(nums, 1, 0, n-1)
    return seg
}

func bitsLen(n int) int {
    cnt := 0
    for n > 0 {
        cnt++
        n >>= 1
    }
    return cnt
}

func (seg *SegmentTree) makeLeaf(o int, value int) {
    info := make([]int, seg.k+1)
    r := value % seg.k
    info[r] = 1
    info[seg.k] = r
    seg.tree[o] = info
}

func (seg *SegmentTree) mergePre(left, right []int) []int {
    pre := make([]int, seg.k+1)
    mulL := left[seg.k]
    mulR := right[seg.k]
    pre[seg.k] = (mulL * mulR) % seg.k

    for x := 0; x < seg.k; x++ {
        pre[x] = left[x]
    }
    for x := 0; x < seg.k; x++ {
        pre[(mulL*x)%seg.k] += right[x]
    }
    return pre
}

func (seg *SegmentTree) maintain(o int) {
    seg.tree[o] = seg.mergePre(seg.tree[o*2], seg.tree[o*2+1])
}

func (seg *SegmentTree) build(nums []int, o, l, r int) {
    if l == r {
        seg.makeLeaf(o, nums[l])
        return
    }
    m := (l + r) / 2
    seg.build(nums, o*2, l, m)
    seg.build(nums, o*2+1, m+1, r)
    seg.maintain(o)
}

func (seg *SegmentTree) Update(o, l, r, index, value int) {
    if l == r {
        seg.makeLeaf(o, value)
        return
    }
    m := (l + r) / 2
    if index <= m {
        seg.Update(o*2, l, m, index, value)
    } else {
        seg.Update(o*2+1, m+1, r, index, value)
    }
    seg.maintain(o)
}

func (seg *SegmentTree) Query(o, l, r, L, R int) []int {
    if L <= l && r <= R {
        return seg.tree[o]
    }
    m := (l + r) / 2
    if R <= m {
        return seg.Query(o*2, l, m, L, R)
    }
    if L > m {
        return seg.Query(o*2+1, m+1, r, L, R)
    }
    left := seg.Query(o*2, l, m, L, R)
    right := seg.Query(o*2+1, m+1, r, L, R)
    return seg.mergePre(left, right)
}
```

```C
#define MAXK 6

typedef struct {
    int k;
    int n;
    int* tree;
} SegmentTree;

static inline int* getNode(SegmentTree* seg, int o) {
    return &seg->tree[o * MAXK];
}

static void makeLeaf(SegmentTree* seg, int o, int value) {
    int* node = getNode(seg, o);
    memset(node, 0, MAXK * sizeof(int));
    int r = value % seg->k;
    node[r] = 1;
    node[seg->k] = r;
}

static void mergePre(SegmentTree* seg, int* left, int* right, int* result) {
    int mulL = left[seg->k];
    int mulR = right[seg->k];
    result[seg->k] = (mulL * mulR) % seg->k;

    for (int x = 0; x < seg->k; x++) {
        result[x] = left[x];
    }
    for (int x = 0; x < seg->k; x++) {
        result[(mulL * x) % seg->k] += right[x];
    }
}

static void maintain(SegmentTree* seg, int o) {
    int* left = getNode(seg, o * 2);
    int* right = getNode(seg, o * 2 + 1);
    int* node = getNode(seg, o);
    mergePre(seg, left, right, node);
}

static void build(SegmentTree* seg, int* nums, int o, int l, int r) {
    if (l == r) {
        makeLeaf(seg, o, nums[l]);
        return;
    }
    int m = (l + r) / 2;
    build(seg, nums, o * 2, l, m);
    build(seg, nums, o * 2 + 1, m + 1, r);
    maintain(seg, o);
}

SegmentTree* createSegmentTree(int* nums, int n, int k) {
    SegmentTree* seg = (SegmentTree*)malloc(sizeof(SegmentTree));
    seg->k = k;
    seg->n = n;

    int size = 2 << (int)ceil(log2(n));
    seg->tree = (int*)calloc(size * MAXK, sizeof(int));
    build(seg, nums, 1, 0, n - 1);
    return seg;
}

void destroySegmentTree(SegmentTree* seg) {
    if (seg) {
        free(seg->tree);
        free(seg);
    }
}

void update(SegmentTree* seg, int o, int l, int r, int index, int value) {
    if (l == r) {
        makeLeaf(seg, o, value);
        return;
    }
    int m = (l + r) / 2;
    if (index <= m) {
        update(seg, o * 2, l, m, index, value);
    } else {
        update(seg, o * 2 + 1, m + 1, r, index, value);
    }
    maintain(seg, o);
}

void query(SegmentTree* seg, int o, int l, int r, int L, int R, int* result) {
    if (L <= l && r <= R) {
        int* node = getNode(seg, o);
        memcpy(result, node, MAXK * sizeof(int));
        return;
    }

    int m = (l + r) / 2;
    if (R <= m) {
        query(seg, o * 2, l, m, L, R, result);
        return;
    }
    if (L > m) {
        query(seg, o * 2 + 1, m + 1, r, L, R, result);
        return;
    }

    int left[MAXK];
    int right[MAXK];
    query(seg, o * 2, l, m, L, R, left);
    query(seg, o * 2 + 1, m + 1, r, L, R, right);
    mergePre(seg, left, right, result);
}

int* resultArray(int* nums, int numsSize, int k, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int n = numsSize;
    SegmentTree* seg = createSegmentTree(nums, n, k);
    int* ans = (int*)malloc(queriesSize * sizeof(int));
    *returnSize = queriesSize;

    for (int i = 0; i < queriesSize; i++) {
        int* q = queries[i];
        int index = q[0];
        int value = q[1];
        int start = q[2];
        int x = q[3];

        update(seg, 1, 0, n - 1, index, value);
        int pre[MAXK];
        query(seg, 1, 0, n - 1, start, n - 1, pre);
        ans[i] = pre[x];
    }

    destroySegmentTree(seg);
    return ans;
}


```

```JavaScript
class SegmentTree {
    constructor(nums, k) {
        this.k = k;
        const n = nums.length;
        const size = 2 << (n.toString(2).length);
        this.tree = Array.from({ length: size }, () => new Array(k + 1).fill(0));
        this.build(nums, 1, 0, n - 1);
    }

    makeLeaf(o, value) {
        const info = new Array(this.k + 1).fill(0);
        const r = value % this.k;
        info[r] = 1;
        info[this.k] = r;
        this.tree[o] = info;
    }

    mergePre(left, right) {
        const pre = new Array(this.k + 1).fill(0);
        const mulL = left[this.k];
        const mulR = right[this.k];
        pre[this.k] = (mulL * mulR) % this.k;

        for (let x = 0; x < this.k; x++) pre[x] = left[x];
        for (let x = 0; x < this.k; x++) {
            pre[(mulL * x) % this.k] += right[x];
        }
        return pre;
    }

    maintain(o) {
        this.tree[o] = this.mergePre(this.tree[o * 2], this.tree[o * 2 + 1]);
    }

    build(nums, o, l, r) {
        if (l === r) {
            this.makeLeaf(o, nums[l]);
            return;
        }
        const m = Math.floor((l + r) / 2);
        this.build(nums, o * 2, l, m);
        this.build(nums, o * 2 + 1, m + 1, r);
        this.maintain(o);
    }

    update(o, l, r, index, value) {
        if (l === r) {
            this.makeLeaf(o, value);
            return;
        }
        const m = Math.floor((l + r) / 2);
        if (index <= m) this.update(o * 2, l, m, index, value);
        else this.update(o * 2 + 1, m + 1, r, index, value);
        this.maintain(o);
    }

    query(o, l, r, L, R) {
        if (L <= l && r <= R) return this.tree[o];
        const m = Math.floor((l + r) / 2);
        if (R <= m) return this.query(o * 2, l, m, L, R);
        if (L > m) return this.query(o * 2 + 1, m + 1, r, L, R);
        const left = this.query(o * 2, l, m, L, R);
        const right = this.query(o * 2 + 1, m + 1, r, L, R);
        return this.mergePre(left, right);
    }
}

var resultArray = function(nums, k, queries) {
    const n = nums.length;
    const seg = new SegmentTree(nums, k);
    const ans = [];

    for (const [index, value, start, x] of queries) {
        seg.update(1, 0, n - 1, index, value);
        const pre = seg.query(1, 0, n - 1, start, n - 1);
        ans.push(pre[x]);
    }
    return ans;
}
```

```TypeScript
class SegmentTree {
    private k: number;
    private tree: number[][];

    constructor(nums: number[], k: number) {
        this.k = k;
        const n = nums.length;
        const size = 2 << (n.toString(2).length);
        this.tree = Array.from({ length: size }, () => new Array(k + 1).fill(0));
        this.build(nums, 1, 0, n - 1);
    }

    private makeLeaf(o: number, value: number): void {
        const info = new Array(this.k + 1).fill(0);
        const r = value % this.k;
        info[r] = 1;
        info[this.k] = r;
        this.tree[o] = info;
    }

    private mergePre(left: number[], right: number[]): number[] {
        const pre = new Array(this.k + 1).fill(0);
        const mulL = left[this.k];
        const mulR = right[this.k];
        pre[this.k] = (mulL * mulR) % this.k;

        for (let x = 0; x < this.k; x++) pre[x] = left[x];
        for (let x = 0; x < this.k; x++) {
            pre[(mulL * x) % this.k] += right[x];
        }
        return pre;
    }

    private maintain(o: number): void {
        this.tree[o] = this.mergePre(this.tree[o * 2], this.tree[o * 2 + 1]);
    }

    private build(nums: number[], o: number, l: number, r: number): void {
        if (l === r) {
            this.makeLeaf(o, nums[l]);
            return;
        }
        const m = Math.floor((l + r) / 2);
        this.build(nums, o * 2, l, m);
        this.build(nums, o * 2 + 1, m + 1, r);
        this.maintain(o);
    }

    public update(o: number, l: number, r: number, index: number, value: number): void {
        if (l === r) {
            this.makeLeaf(o, value);
            return;
        }
        const m = Math.floor((l + r) / 2);
        if (index <= m) this.update(o * 2, l, m, index, value);
        else this.update(o * 2 + 1, m + 1, r, index, value);
        this.maintain(o);
    }

    public query(o: number, l: number, r: number, L: number, R: number): number[] {
        if (L <= l && r <= R) return this.tree[o];
        const m = Math.floor((l + r) / 2);
        if (R <= m) return this.query(o * 2, l, m, L, R);
        if (L > m) return this.query(o * 2 + 1, m + 1, r, L, R);
        const left = this.query(o * 2, l, m, L, R);
        const right = this.query(o * 2 + 1, m + 1, r, L, R);
        return this.mergePre(left, right);
    }
}

function resultArray(nums: number[], k: number, queries: number[][]): number[] {
    const n = nums.length;
    const seg = new SegmentTree(nums, k);
    const ans: number[] = [];

    for (const [index, value, start, x] of queries) {
        seg.update(1, 0, n - 1, index, value);
        const pre = seg.query(1, 0, n - 1, start, n - 1);
        ans.push(pre[x]);
    }
    return ans;
}
```

```Rust
use std::collections::VecDeque;

struct SegmentTree {
    k: usize,
    tree: Vec<Vec<i32>>,
}

impl SegmentTree {
    fn new(nums: &[i32], k: usize) -> Self {
        let n = nums.len();
        let size = 2 << (n as f64).log2().ceil() as usize;
        let mut tree = vec![vec![0; k + 1]; size];
        let mut seg = SegmentTree { k, tree };
        seg.build(nums, 1, 0, n - 1);
        seg
    }

    fn make_leaf(&mut self, o: usize, value: i32) {
        let mut info = vec![0; self.k + 1];
        let r = (value % self.k as i32) as usize;
        info[r] = 1;
        info[self.k] = r as i32;
        self.tree[o] = info;
    }

    fn merge_pre(&self, left: &[i32], right: &[i32]) -> Vec<i32> {
        let mut pre = vec![0; self.k + 1];
        let mul_l = left[self.k];
        let mul_r = right[self.k];
        pre[self.k] = (mul_l * mul_r) % self.k as i32;

        for x in 0..self.k {
            pre[x] = left[x];
        }
        for x in 0..self.k {
            pre[((mul_l * x as i32) % self.k as i32) as usize] += right[x];
        }
        pre
    }

    fn maintain(&mut self, o: usize) {
        let left = self.tree[o * 2].clone();
        let right = self.tree[o * 2 + 1].clone();
        self.tree[o] = self.merge_pre(&left, &right);
    }

    fn build(&mut self, nums: &[i32], o: usize, l: usize, r: usize) {
        if l == r {
            self.make_leaf(o, nums[l]);
            return;
        }
        let m = (l + r) / 2;
        self.build(nums, o * 2, l, m);
        self.build(nums, o * 2 + 1, m + 1, r);
        self.maintain(o);
    }

    pub fn update(&mut self, o: usize, l: usize, r: usize, index: usize, value: i32) {
        if l == r {
            self.make_leaf(o, value);
            return;
        }
        let m = (l + r) / 2;
        if index <= m {
            self.update(o * 2, l, m, index, value);
        } else {
            self.update(o * 2 + 1, m + 1, r, index, value);
        }
        self.maintain(o);
    }

    pub fn query(&self, o: usize, l: usize, r: usize, L: usize, R: usize) -> Vec<i32> {
        if L <= l && r <= R {
            return self.tree[o].clone();
        }
        let m = (l + r) / 2;
        if R <= m {
            return self.query(o * 2, l, m, L, R);
        }
        if L > m {
            return self.query(o * 2 + 1, m + 1, r, L, R);
        }
        let left = self.query(o * 2, l, m, L, R);
        let right = self.query(o * 2 + 1, m + 1, r, L, R);
        self.merge_pre(&left, &right)
    }
}

impl Solution {
    pub fn result_array(nums: Vec<i32>, k: i32, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let n = nums.len();
        let k_usize = k as usize;
        let mut seg = SegmentTree::new(&nums, k_usize);
        let mut ans = Vec::new();

        for q in queries {
            let index = q[0] as usize;
            let value = q[1];
            let start = q[2] as usize;
            let x = q[3] as usize;
            seg.update(1, 0, n - 1, index, value);
            let pre = seg.query(1, 0, n - 1, start, n - 1);
            ans.push(pre[x]);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O((n+q)k\log n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(nk)$。线段树每个节点维护一个长度为 $k+1$ 的数组，共有 $O(n)$ 个节点。
