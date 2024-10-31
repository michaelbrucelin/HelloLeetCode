### [不包含相邻元素的子序列的最大和](https://leetcode.cn/problems/maximum-sum-of-subsequence-with-non-adjacent-elements/solutions/2970964/bu-bao-han-xiang-lin-yuan-su-de-zi-xu-li-53hw/)

#### 方法一：线段树

**思路与算法**

如果没有 $queries$ 中的修改操作，那么本题就是经典的「[198\. 打家劫舍](https://leetcode.cn/problems/house-robber/description/)」，可以使用动态规划进行解决。

在有修改操作的情况下，每一次操作会将 $nums[pos_i​]$ 的值修改为 $x_i$​。由于只修改了一个元素的值，这就提示我们可以**复用**动态规划中的结果，即：

- 如果我们在答案中选择了位置 $pos_i$​，那么相邻的位置 $pos_{i-1​}$ 以及 $pos_{i+1}$​ 均不能被选择，左右两侧分别变成 $nums[0]$ 到 $nums[pos_{i-2​}]$，以及 $nums[pos_{i+2}​]$ 到 $nums[pos_{n-1}​]$ 的子问题；
- 如果我们在答案中没有选择位置 $pos_i$​，那么没有任何限制，左右两侧分别变成 $nums[0]$ 到 $nums[pos_{i-1}​]$，以及 $nums[pos_{i+1}​]$ 到 $nums[pos_{n-1}​]$ 的子问题。

其中 $n$ 是数组 $nums$ 的长度。这种带修改操作的「子问题」的形式，就提示我们可以使用线段树来解决。

在线段树中，对于每个节点 $t_{l,r}$​，它表示的区间为 $[l,r]$，对应 $nums[l]$ 到 $nums[r]$ 这个子数组。我们需要存储四个值：$t_{l,r}​(x,y)$，其中 $x,y$ 的取值为 $0$ 或 $1$：

- $x$ 表示左边界的选择情况；
- $y$ 表示右边界的选择情况；
- $0$ 表示对应的边界元素**一定没有**被选择；
- $1$ 表示对应的边界元素**可能**被选择，也就是没有任何要求。

接下来我们考虑如何计算这四个值。如果 $l=r$，那么 $x=0$ 或者 $y=0$ 时没有元素被选择，它们的值均为 $0$；当 $x=y=1$ 时，可以选择 $nums[l]$，也可以不选择，值为 $max{nums[l],0}$。

如果 $l \ne r$，那么在线段树中该节点不是叶子结点，它的两个孩子已经存储了将这个区间从中间切开后，左右两侧的子数组分别的四个值。分别考虑 $(x,y)$ 的四种情况，以 $(x,y)=(0,0)$ 为例，左侧只能是 $(0,0)$ 或 $(0,1)$。如果左侧是 $(0,0)$，那么右侧是 $(1,0)$（这里右侧是 $(0,0)$ 也可以，但某个边界没有任何要求的答案，一定不会差于该边界一定没有被选择的答案，因此 $(1,0)$ 可行时就可以忽略 $(0,0)$，后续类似的情况不重复进行解释）；如果左侧是 $(0,1)$，那么右侧是 $(0,0)$。

同理考虑剩余的三种情况，可以得到所有的结果如下：

$$t_{l,r}​(0,0)=max{L(0,0)+R(1,0),L(0,1)+R(0,0)} \\ t_{l,r}​(0,1)=max{L(0,0)+R(1,1),L(0,1)+R(0,1)} \\ t_{l,r}​(1,0)=max{L(1,0)+R(1,0),L(1,1)+R(0,0)} \\ t_{l,r}​(1,1)=max{L(1,0)+R(1,1),L(1,1)+R(0,1)}$$

其中 $L( \cdot , \cdot )$ 和 $R( \cdot , \cdot )$ 分别是 $t_{l,r}$​ 的左孩子和右孩子的某种情况，这样就可以在 $O(1)$ 的时间得到 $t_{l,r}$​ 的四个值，因此使用单点修改的线段树，就可以在 $O(logn)$ 的时间处理每一次修改操作，随后 $O(1)$ 的时间通过根节点得到修改后的答案。

**代码**

```C++
struct SegNode {
    SegNode() {
        v00 = v01 = v10 = v11 = 0;
    }
    void set(long long v) {
        v00 = v01 = v10 = 0;
        v11 = max(v, 0LL);
    }
    long long best() {
        return v11;
    }
    
    long long v00, v01, v10, v11;
};

class SegTree {
public:
    SegTree(int n): n(n), tree(n * 4 + 1) {}
    void init(const vector<int>& nums) {
        internal_init(nums, 1, 1, n);
    }
    void update(int x, int v) {
        internal_update(1, 1, n, x + 1, v);
    }
    long long query() {
        return tree[1].best();
    }

private:
    void internal_init(const vector<int>& nums, int x, int l, int r) {
        if (l == r) {
            tree[x].set(nums[l - 1]);
            return;
        }
        int mid = (l + r) / 2;
        internal_init(nums, x * 2, l, mid);
        internal_init(nums, x * 2 + 1, mid + 1, r);
        pushup(x);
    }
    void internal_update(int x, int l, int r, int pos, int v) {
        if (l > pos || r < pos) {
            return;
        }
        if (l == r) {
            tree[x].set(v);
            return;
        }
        int mid = (l + r) / 2;
        internal_update(x * 2, l, mid, pos, v);
        internal_update(x * 2 + 1, mid + 1, r, pos, v);
        pushup(x);
    }
    void pushup(int x) {
        int l = x * 2, r = x * 2 + 1;
        tree[x].v00 = max(tree[l].v00 + tree[r].v10, tree[l].v01 + tree[r].v00);
        tree[x].v01 = max(tree[l].v00 + tree[r].v11, tree[l].v01 + tree[r].v01);
        tree[x].v10 = max(tree[l].v10 + tree[r].v10, tree[l].v11 + tree[r].v00);
        tree[x].v11 = max(tree[l].v10 + tree[r].v11, tree[l].v11 + tree[r].v01);
    }

private:
    int n;
    vector<SegNode> tree;
};

class Solution {
public:
    int maximumSumSubsequence(vector<int>& nums, vector<vector<int>>& queries) {
        int n = nums.size();
        SegTree tree(n);
        tree.init(nums);
        
        int ans = 0;
        for (const auto& q: queries) {
            tree.update(q[0], q[1]);
            ans = ((long long)ans + tree.query()) % mod;
        }
        return ans;
    }

private:
    static constexpr int mod = 1000000007;
};
```

```Python
class SegNode:
    def __init__(self) -> None:
        self.v00 = self.v01 = self.v10 = self.v11 = 0
    
    def set_value(self, v: int) -> None:
        self.v00 = self.v01 = self.v10 = 0
        self.v11 = max(v, 0)
    
    def best(self) -> int:
        return self.v11

class SegTree:
    def __init__(self, n: int) -> None:
        self.n = n
        self.tree = [SegNode() for _ in range(n * 4 + 1)]
    
    def init(self, nums: List[int]) -> None:
        def internal_init(x: int, l: int, r: int) -> None:
            if l == r:
                self.tree[x].set_value(nums[l - 1])
                return
            mid = (l + r) // 2
            internal_init(x * 2, l, mid)
            internal_init(x * 2 + 1, mid + 1, r)
            self.pushup(x)
        internal_init(1, 1, self.n)
    
    def update(self, x: int, v: int) -> None:
        def internal_update(x: int, l: int, r: int, pos: int, v: int) -> None:
            if l > pos or r < pos:
                return
            if l == r:
                self.tree[x].set_value(v)
                return
            mid = (l + r) // 2
            internal_update(x * 2, l, mid, pos, v)
            internal_update(x * 2 + 1, mid + 1, r, pos, v)
            self.pushup(x)
        internal_update(1, 1, self.n, x + 1, v)
    
    def query(self) -> int:
        return self.tree[1].best()

    def pushup(self, x: int) -> None:
        tree_ = self.tree

        l, r = x * 2, x * 2 + 1
        tree_[x].v00 = max(tree_[l].v00 + tree_[r].v10, tree_[l].v01 + tree_[r].v00)
        tree_[x].v01 = max(tree_[l].v00 + tree_[r].v11, tree_[l].v01 + tree_[r].v01)
        tree_[x].v10 = max(tree_[l].v10 + tree_[r].v10, tree_[l].v11 + tree_[r].v00)
        tree_[x].v11 = max(tree_[l].v10 + tree_[r].v11, tree_[l].v11 + tree_[r].v01)

class Solution:
    def maximumSumSubsequence(self, nums: List[int], queries: List[List[int]]) -> int:
        tree = SegTree(len(nums))
        tree.init(nums)
        
        ans = 0
        for x, v in queries:
            tree.update(x, v)
            ans += tree.query()
        return ans % (10**9 + 7)
```

```Java
class SegNode {
    long v00, v01, v10, v11;
    SegNode() {
        v00 = v01 = v10 = v11 = 0;
    }

    void set(long v) {
        v00 = v01 = v10 = 0;
        v11 = Math.max(v, 0);
    }

    long best() {
        return v11;
    }
}

class SegTree {
    int n;
    SegNode[] tree;

    SegTree(int n) {
        this.n = n;
        tree = new SegNode[n * 4 + 1];
        for (int i = 0; i < tree.length; i++) {
            tree[i] = new SegNode();
        }
    }

    void init(int[] nums) {
        internalInit(nums, 1, 1, n);
    }

    void update(int x, int v) {
        internalUpdate(1, 1, n, x + 1, v);
    }

    long query() {
        return tree[1].best();
    }

    private void internalInit(int[] nums, int x, int l, int r) {
        if (l == r) {
            tree[x].set(nums[l - 1]);
            return;
        }
        int mid = (l + r) / 2;
        internalInit(nums, x * 2, l, mid);
        internalInit(nums, x * 2 + 1, mid + 1, r);
        pushup(x);
    }

    private void internalUpdate(int x, int l, int r, int pos, int v) {
        if (l > pos || r < pos) {
            return;
        }
        if (l == r) {
            tree[x].set(v);
            return;
        }
        int mid = (l + r) / 2;
        internalUpdate(x * 2, l, mid, pos, v);
        internalUpdate(x * 2 + 1, mid + 1, r, pos, v);
        pushup(x);
    }

    private void pushup(int x) {
        int l = x * 2, r = x * 2 + 1;
        tree[x].v00 = Math.max(tree[l].v00 + tree[r].v10, tree[l].v01 + tree[r].v00);
        tree[x].v01 = Math.max(tree[l].v00 + tree[r].v11, tree[l].v01 + tree[r].v01);
        tree[x].v10 = Math.max(tree[l].v10 + tree[r].v10, tree[l].v11 + tree[r].v00);
        tree[x].v11 = Math.max(tree[l].v10 + tree[r].v11, tree[l].v11 + tree[r].v01);
    }
}

class Solution {
    public static final int MOD = 1000000007;
    public int maximumSumSubsequence(int[] nums, int[][] queries) {
        int n = nums.length;
        SegTree tree = new SegTree(n);
        tree.init(nums);

        long ans = 0;
        for (int[] q : queries) {
            tree.update(q[0], q[1]);
            ans = (ans + tree.query()) % MOD;
        }
        return (int) ans;
    }
}
```

```CSharp
public class SegNode {
    public long v00, v01, v10, v11;

    public SegNode() {
        v00 = v01 = v10 = v11 = 0;
    }

    public void Set(long v) {
        v00 = v01 = v10 = 0;
        v11 = Math.Max(v, 0);
    }

    public long Best() {
        return v11;
    }
}

public class SegTree {
    private int n;
    private SegNode[] tree;

    public SegTree(int n) {
        this.n = n;
        tree = new SegNode[n * 4 + 1];
        for (int i = 0; i < tree.Length; i++) {
            tree[i] = new SegNode();
        }
    }

    public void Init(int[] nums) {
        InternalInit(nums, 1, 1, n);
    }

    public void Update(int x, int v) {
        InternalUpdate(1, 1, n, x + 1, v);
    }

    public long Query() {
        return tree[1].Best();
    }

    private void InternalInit(int[] nums, int x, int l, int r) {
        if (l == r) {
            tree[x].Set(nums[l - 1]);
            return;
        }
        int mid = (l + r) / 2;
        InternalInit(nums, x * 2, l, mid);
        InternalInit(nums, x * 2 + 1, mid + 1, r);
        Pushup(x);
    }

    private void InternalUpdate(int x, int l, int r, int pos, int v) {
        if (l > pos || r < pos) {
            return;
        }
        if (l == r) {
            tree[x].Set(v);
            return;
        }
        int mid = (l + r) / 2;
        InternalUpdate(x * 2, l, mid, pos, v);
        InternalUpdate(x * 2 + 1, mid + 1, r, pos, v);
        Pushup(x);
    }

    private void Pushup(int x) {
        int l = x * 2, r = x * 2 + 1;
        tree[x].v00 = Math.Max(tree[l].v00 + tree[r].v10, tree[l].v01 + tree[r].v00);
        tree[x].v01 = Math.Max(tree[l].v00 + tree[r].v11, tree[l].v01 + tree[r].v01);
        tree[x].v10 = Math.Max(tree[l].v10 + tree[r].v10, tree[l].v11 + tree[r].v00);
        tree[x].v11 = Math.Max(tree[l].v10 + tree[r].v11, tree[l].v11 + tree[r].v01);
    }
}

public class Solution {
    public const int MOD = 1000000007;
    public int MaximumSumSubsequence(int[] nums, int[][] queries) {
        int n = nums.Length;
        SegTree tree = new SegTree(n);
        tree.Init(nums);
        
        long ans = 0;
        foreach (var q in queries) {
            tree.Update(q[0], q[1]);
            ans = (ans + tree.Query()) % MOD;
        }
        return (int)ans;
    }
}
```

```Go
const MOD = 1000000007

func maximumSumSubsequence(nums []int, queries [][]int) int {
    n := len(nums)
    tree := NewSegTree(n)
    tree.Init(nums)

    ans := int64(0)
    for _, q := range queries {
        tree.Update(q[0], q[1])
        ans = (ans + tree.Query()) % MOD
    }
    return int(ans)
}

type SegNode struct {
    v00, v01, v10, v11 int64
}

func NewSegNode() *SegNode {
    return &SegNode{0, 0, 0, 0}
}

func (sn *SegNode) Set(v int64) {
    sn.v00, sn.v01, sn.v10 = 0, 0, 0
    sn.v11 = int64(math.Max(float64(v), 0))
}

func (sn *SegNode) Best() int64 {
    return sn.v11
}

type SegTree struct {
    n    int
    tree []*SegNode
}

func NewSegTree(n int) *SegTree {
    tree := make([]*SegNode, n * 4 + 1)
    for i := range tree {
        tree[i] = NewSegNode()
    }
    return &SegTree{n, tree}
}

func (st *SegTree) Init(nums []int) {
    st.internalInit(nums, 1, 1, st.n)
}

func (st *SegTree) Update(x, v int) {
    st.internalUpdate(1, 1, st.n, x + 1, int64(v))
}

func (st *SegTree) Query() int64 {
    return st.tree[1].Best()
}

func (st *SegTree) internalInit(nums []int, x, l, r int) {
    if l == r {
        st.tree[x].Set(int64(nums[l - 1]))
        return
    }
    mid := (l + r) / 2
    st.internalInit(nums, x * 2, l, mid)
    st.internalInit(nums, x * 2 + 1, mid + 1, r)
    st.pushup(x)
}

func (st *SegTree) internalUpdate(x, l, r int, pos int, v int64) {
    if l > pos || r < pos {
        return
    }
    if l == r {
        st.tree[x].Set(v)
        return
    }
    mid := (l + r) / 2
    st.internalUpdate(x * 2, l, mid, pos, v)
    st.internalUpdate(x * 2 + 1, mid + 1, r, pos, v)
    st.pushup(x)
}

func (st *SegTree) pushup(x int) {
    l, r := x * 2, x * 2 + 1
    st.tree[x].v00 = max(st.tree[l].v00 + st.tree[r].v10, st.tree[l].v01 + st.tree[r].v00)
    st.tree[x].v01 = max(st.tree[l].v00 + st.tree[r].v11, st.tree[l].v01 + st.tree[r].v01)
    st.tree[x].v10 = max(st.tree[l].v10 + st.tree[r].v10, st.tree[l].v11 + st.tree[r].v00)
    st.tree[x].v11 = max(st.tree[l].v10 + st.tree[r].v11, st.tree[l].v11 + st.tree[r].v01)
}
```

```C
typedef struct SegNode {
    long long v00, v01, v10, v11;
} SegNode;

SegNode* segNodeCreate() {
    SegNode* node = (SegNode*)malloc(sizeof(SegNode));
    node->v00 = node->v01 = node->v10 = node->v11 = 0;
    return node;
}

void setSegNode(SegNode* node, long long v) {
    node->v00 = node->v01 = node->v10 = 0;
    node->v11 = fmax(v, 0LL);
}

long long bestSegNode(SegNode* node) {
    return node->v11;
}

typedef struct SegTree {
    int n;
    SegNode** tree;
} SegTree;

SegTree* segTreeCreate(int n) {
    SegTree* tree = (SegTree*)malloc(sizeof(SegTree));
    tree->n = n;
    tree->tree = (SegNode**)malloc((n * 4 + 1) * sizeof(SegNode*));
    for (int i = 0; i < n * 4 + 1; i++) {
        tree->tree[i] = segNodeCreate();
    }
    return tree;
}

void freeSegTree(SegTree* tree) {
    for (int i = 0; i <= tree->n * 4; i++) {
        free(tree->tree[i]);
    }
    free(tree->tree);
    free(tree);
}

void initSegTree(SegTree* tree, int* nums) {
    internalInit(tree, nums, 1, 1, tree->n);
}

void updateSegTree(SegTree* tree, int x, int v) {
    internalUpdate(tree, 1, 1, tree->n, x + 1, v);
}

long long querySegTree(SegTree* tree) {
    return bestSegNode(tree->tree[1]);
}

void internalInit(SegTree* tree, int* nums, int x, int l, int r) {
    if (l == r) {
        setSegNode(tree->tree[x], nums[l - 1]);
        return;
    }
    int mid = (l + r) / 2;
    internalInit(tree, nums, x * 2, l, mid);
    internalInit(tree, nums, x * 2 + 1, mid + 1, r);
    pushup(tree, x);
}

void internalUpdate(SegTree* tree, int x, int l, int r, int pos, int v) {
    if (l > pos || r < pos) {
        return;
    }
    if (l == r) {
        setSegNode(tree->tree[x], v);
        return;
    }
    int mid = (l + r) / 2;
    internalUpdate(tree, x * 2, l, mid, pos, v);
    internalUpdate(tree, x * 2 + 1, mid + 1, r, pos, v);
    pushup(tree, x);
}

void pushup(SegTree* tree, int x) {
    int l = x * 2, r = x * 2 + 1;
    tree->tree[x]->v00 = fmax(tree->tree[l]->v00 + tree->tree[r]->v10, tree->tree[l]->v01 + tree->tree[r]->v00);
    tree->tree[x]->v01 = fmax(tree->tree[l]->v00 + tree->tree[r]->v11, tree->tree[l]->v01 + tree->tree[r]->v01);
    tree->tree[x]->v10 = fmax(tree->tree[l]->v10 + tree->tree[r]->v10, tree->tree[l]->v11 + tree->tree[r]->v00);
    tree->tree[x]->v11 = fmax(tree->tree[l]->v10 + tree->tree[r]->v11, tree->tree[l]->v11 + tree->tree[r]->v01);
}

#define MOD 1000000007

int maximumSumSubsequence(int* nums, int numsSize, int** queries, int queriesSize, int* queriesColSize) {
    SegTree* tree = segTreeCreate(numsSize);
    initSegTree(tree, nums);

    long long ans = 0;
    for (int i = 0; i < queriesSize; i++) {
        updateSegTree(tree, queries[i][0], queries[i][1]);
        ans = (ans + querySegTree(tree)) % MOD;
    }
    freeSegTree(tree);
    return (int)ans;
}
```

```JavaScript
class SegNode {
    constructor() {
        this.v00 = this.v01 = this.v10 = this.v11 = 0;
    }

    set(v) {
        this.v00 = this.v01 = this.v10 = 0;
        this.v11 = Math.max(v, 0);
    }

    best() {
        return this.v11;
    }
}

class SegTree {
    constructor(n) {
        this.n = n;
        this.tree = Array.from({ length: n * 4 + 1 }, () => new SegNode());
    }

    init(nums) {
        this.internalInit(nums, 1, 1, this.n);
    }

    update(x, v) {
        this.internalUpdate(1, 1, this.n, x + 1, v);
    }

    query() {
        return this.tree[1].best();
    }

    internalInit(nums, x, l, r) {
        if (l === r) {
            this.tree[x].set(nums[l - 1]);
            return;
        }
        const mid = Math.floor((l + r) / 2);
        this.internalInit(nums, x * 2, l, mid);
        this.internalInit(nums, x * 2 + 1, mid + 1, r);
        this.pushup(x);
    }

    internalUpdate(x, l, r, pos, v) {
        if (l > pos || r < pos) {
            return;
        }
        if (l === r) {
            this.tree[x].set(v);
            return;
        }
        const mid = Math.floor((l + r) / 2);
        this.internalUpdate(x * 2, l, mid, pos, v);
        this.internalUpdate(x * 2 + 1, mid + 1, r, pos, v);
        this.pushup(x);
    }

    pushup(x) {
        const l = x * 2, r = x * 2 + 1;
        this.tree[x].v00 = Math.max(this.tree[l].v00 + this.tree[r].v10, this.tree[l].v01 + this.tree[r].v00);
        this.tree[x].v01 = Math.max(this.tree[l].v00 + this.tree[r].v11, this.tree[l].v01 + this.tree[r].v01);
        this.tree[x].v10 = Math.max(this.tree[l].v10 + this.tree[r].v10, this.tree[l].v11 + this.tree[r].v00);
        this.tree[x].v11 = Math.max(this.tree[l].v10 + this.tree[r].v11, this.tree[l].v11 + this.tree[r].v01);
    }
}

const MOD = 1000000007;

var maximumSumSubsequence = function(nums, queries) {
    const n = nums.length;
        const tree = new SegTree(n);
        tree.init(nums);

        let ans = 0;
        for (const q of queries) {
            tree.update(q[0], q[1]);
            ans = (ans + tree.query()) % MOD;
        }
        return ans;
};
```

```TypeScript
const MOD = 1000000007;

function maximumSumSubsequence(nums: number[], queries: number[][]): number {
    const n = nums.length;
    const tree = new SegTree(n);
    tree.init(nums);

    let ans = 0;
    for (const q of queries) {
        tree.update(q[0], q[1]);
        ans = (ans + tree.query()) % MOD;
    }
    return ans;
};

class SegNode {
    v00: number;
    v01: number;
    v10: number;
    v11: number;

    constructor() {
        this.v00 = this.v01 = this.v10 = this.v11 = 0;
    }

    set(v: number) {
        this.v00 = this.v01 = this.v10 = 0;
        this.v11 = Math.max(v, 0);
    }

    best(): number {
        return this.v11;
    }
}

class SegTree {
    n: number;
    tree: SegNode[];

    constructor(n: number) {
        this.n = n;
        this.tree = Array.from({ length: n * 4 + 1 }, () => new SegNode());
    }

    init(nums: number[]) {
        this.internalInit(nums, 1, 1, this.n);
    }

    update(x: number, v: number) {
        this.internalUpdate(1, 1, this.n, x + 1, v);
    }

    query(): number {
        return this.tree[1].best();
    }

    private internalInit(nums: number[], x: number, l: number, r: number) {
        if (l === r) {
            this.tree[x].set(nums[l - 1]);
            return;
        }
        const mid = Math.floor((l + r) / 2);
        this.internalInit(nums, x * 2, l, mid);
        this.internalInit(nums, x * 2 + 1, mid + 1, r);
        this.pushup(x);
    }

    private internalUpdate(x: number, l: number, r: number, pos: number, v: number) {
        if (l > pos || r < pos) {
            return;
        }
        if (l === r) {
            this.tree[x].set(v);
            return;
        }
        const mid = Math.floor((l + r) / 2);
        this.internalUpdate(x * 2, l, mid, pos, v);
        this.internalUpdate(x * 2 + 1, mid + 1, r, pos, v);
        this.pushup(x);
    }

    private pushup(x: number) {
        const l = x * 2, r = x * 2 + 1;
        this.tree[x].v00 = Math.max(this.tree[l].v00 + this.tree[r].v10, this.tree[l].v01 + this.tree[r].v00);
        this.tree[x].v01 = Math.max(this.tree[l].v00 + this.tree[r].v11, this.tree[l].v01 + this.tree[r].v01);
        this.tree[x].v10 = Math.max(this.tree[l].v10 + this.tree[r].v10, this.tree[l].v11 + this.tree[r].v00);
        this.tree[x].v11 = Math.max(this.tree[l].v10 + this.tree[r].v11, this.tree[l].v11 + this.tree[r].v01);
    }
}
```

```Rust
#[derive(Clone)]
struct SegNode {
    v00: i64,
    v01: i64,
    v10: i64,
    v11: i64,
}

impl SegNode {
    fn new() -> Self {
        Self { v00: 0, v01: 0, v10: 0, v11: 0 }
    }

    fn set(&mut self, v: i64) {
        self.v00 = 0;
        self.v01 = 0;
        self.v10 = 0;
        self.v11 = v.max(0);
    }

    fn best(&self) -> i64 {
        self.v11
    }
}

struct SegTree {
    n: usize,
    tree: Vec<SegNode>,
}

impl SegTree {
    fn new(n: usize) -> Self {
        let tree = vec![SegNode::new(); n * 4 + 1];
        Self { n, tree }
    }

    fn init(&mut self, nums: &[i32]) {
        self.internal_init(nums, 1, 1, self.n);
    }

    fn update(&mut self, x: usize, v: i32) {
        self.internal_update(1, 1, self.n, x + 1, v as i64);
    }

    fn query(&self) -> i64 {
        self.tree[1].best()
    }

    fn internal_init(&mut self, nums: &[i32], x: usize, l: usize, r: usize) {
        if l == r {
            self.tree[x].set(nums[l - 1] as i64);
            return;
        }
        let mid = (l + r) / 2;
        self.internal_init(nums, x * 2, l, mid);
        self.internal_init(nums, x * 2 + 1, mid + 1, r);
        self.pushup(x);
    }

    fn internal_update(&mut self, x: usize, l: usize, r: usize, pos: usize, v: i64) {
        if l > pos || r < pos {
            return;
        }
        if l == r {
            self.tree[x].set(v);
            return;
        }
        let mid = (l + r) / 2;
        self.internal_update(x * 2, l, mid, pos, v);
        self.internal_update(x * 2 + 1, mid + 1, r, pos, v);
        self.pushup(x);
    }

    fn pushup(&mut self, x: usize) {
        let l = x * 2;
        let r = x * 2 + 1;
        self.tree[x].v00 = (self.tree[l].v00 + self.tree[r].v10).max(self.tree[l].v01 + self.tree[r].v00);
        self.tree[x].v01 = (self.tree[l].v00 + self.tree[r].v11).max(self.tree[l].v01 + self.tree[r].v01);
        self.tree[x].v10 = (self.tree[l].v10 + self.tree[r].v10).max(self.tree[l].v11 + self.tree[r].v00);
        self.tree[x].v11 = (self.tree[l].v10 + self.tree[r].v11).max(self.tree[l].v11 + self.tree[r].v01);
    }
}

const MOD: i64 = 1_000_000_007;

impl Solution {
    pub fn maximum_sum_subsequence(nums: Vec<i32>, queries: Vec<Vec<i32>>) -> i32 {
        let n = nums.len();
        let mut tree = SegTree::new(n);
        tree.init(&nums);

        let mut ans = 0;
        for q in queries {
            tree.update(q[0] as usize, q[1]);
            ans = (ans + tree.query()) % MOD;
        }
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+qlogn)$，其中 $n$ 是数组 $nums$ 的长度，$q$ 是数组 $queries$ 的长度。线段树初始化的时间为 $O(n)$，每次修改操作需要 $O(logn)$ 的时间。
- 空间复杂度：$O(n)$，即为线段树需要使用的空间。
