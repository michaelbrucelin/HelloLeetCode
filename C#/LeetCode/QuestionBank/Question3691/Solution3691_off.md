### [最大子数组总值 II](https://leetcode.cn/problems/maximum-total-subarray-value-ii/solutions/3980921/zui-da-zi-shu-zu-zong-zhi-ii-by-leetcode-3gi0/)

#### 方法一：ST 表 + 最大堆

**思路与算法**

本题是「[3689\. 最大子数组总值 I](https://leetcode.cn/problems/maximum-total-subarray-value-i/)」的进阶版，区别在于本题要求选择 $k$ 个不同的子数组。

对于一个固定的左端点 $l$，当右端点 $r$ 增大时，子数组 $nums[l..r]$ 的最大值只会增大（或不变），最小值只会减小（或不变），因此子数组的值 $max(nums[l..r])-min(nums[l..r])$ 是单调递增的。

这意味着，对于每个左端点 $l$，我们有一个长度为 $n-l$ 的单调递增序列，序列的第 $i$ 个元素是 $nums[l..l+i]$ 的值（即子数组的 $max(nums[l..l+i])-min(nums[l..l+i])$）。问题转化为：给定 $n$ 个单调递增序列，求所有序列中前 $k$ 大的元素之和。以 $nums=[3,1,4,1]$ 为例，$l=1$ 对应的序列为 $[0,3,3]$（子数组 $[1]$、$[1,4]$、$[1,4,1]$ 的值），$l=2$ 对应的序列为 $[0,3]$，等等。由于每个序列的末尾元素是该序列的最大值，我们可以用堆来高效筛选：每次取全局最大，然后将其前一个元素加入堆，重复 $k$ 次即可。

综上所述，这个子问题可以用最大堆来解决：

1. 初始时，将每个序列的最后一个元素（即 $r=n-1$）及其坐标 $(l,r)$ 放入最大堆。
2. 重复 $k$ 次：弹出堆顶元素 $(v,l,r)$，将 $v$ 累加到答案中，然后将同一序列的前一个元素 $(l,r-1)$（如果 $r>l$）的值放入堆中。

为了在 $O(1)$ 时间内查询任意子数组 $[l,r]$ 的最大值和最小值，我们可以预处理稀疏表（$ST$ 表）。$ST$ 表是一种支持 $O(1)$ 区间最值查询的数据结构：对于长度为 $n$ 的数组，我们预处理出 $stMax[i][j]$ 表示从下标 $i$ 开始、长度为 $2j$ 的区间内的最大值（最小值同理）。查询 $[l,r]$ 时，令 $j=\lfloor \log 2(r-l+1)\rfloor $，则区间最值为 $max(st[l][j],st[r-2j+1][j])$，这两个长度为 $2j$ 的区间恰好覆盖 $[l,r]$。预处理时间复杂度为 $O(n\log n)$。

**代码**

```C++
class Solution {
public:
    long long maxTotalValue(vector<int>& nums, int k) {
        int n = nums.size();
        int logn = 32 - __builtin_clz(n);
        vector<vector<int>> stMax(n, vector<int>(logn));
        vector<vector<int>> stMin(n, vector<int>(logn));
        for (int i = 0; i < n; i++) {
            stMax[i][0] = stMin[i][0] = nums[i];
        }
        for (int j = 1; j < logn; j++) {
            for (int i = 0; i + (1 << j) <= n; i++) {
                stMax[i][j] = max(stMax[i][j - 1], stMax[i + (1 << (j - 1))][j - 1]);
                stMin[i][j] = min(stMin[i][j - 1], stMin[i + (1 << (j - 1))][j - 1]);
            }
        }
        auto queryMax = [&](int l, int r) {
            int j = 31 - __builtin_clz(r - l + 1);
            return max(stMax[l][j], stMax[r - (1 << j) + 1][j]);
        };
        auto queryMin = [&](int l, int r) {
            int j = 31 - __builtin_clz(r - l + 1);
            return min(stMin[l][j], stMin[r - (1 << j) + 1][j]);
        };
        priority_queue<tuple<int, int, int>> pq;
        for (int l = 0; l < n; l++) {
            pq.emplace(queryMax(l, n - 1) - queryMin(l, n - 1), l, n - 1);
        }
        long long ans = 0;
        while (k--) {
            auto [val, l, r] = pq.top();
            pq.pop();
            ans += val;
            if (r > l) {
                pq.emplace(queryMax(l, r - 1) - queryMin(l, r - 1), l, r - 1);
            }
        }
        return ans;
    }
};
```

```Go
func maxTotalValue(nums []int, k int) int64 {
    n := len(nums)
    logn := bits.Len(uint(n))
    stMax := make([][]int, n)
    stMin := make([][]int, n)
    for i := range stMax {
        stMax[i] = make([]int, logn)
        stMin[i] = make([]int, logn)
        stMax[i][0] = nums[i]
        stMin[i][0] = nums[i]
    }
    for j := 1; j < logn; j++ {
        for i := 0; i+(1<<j) <= n; i++ {
            stMax[i][j] = max(stMax[i][j-1], stMax[i+(1<<(j-1))][j-1])
            stMin[i][j] = min(stMin[i][j-1], stMin[i+(1<<(j-1))][j-1])
        }
    }
    queryMax := func(l, r int) int {
        j := bits.Len(uint(r-l+1)) - 1
        return max(stMax[l][j], stMax[r-(1<<j)+1][j])
    }
    queryMin := func(l, r int) int {
        j := bits.Len(uint(r-l+1)) - 1
        return min(stMin[l][j], stMin[r-(1<<j)+1][j])
    }
    h := &hp{}
    for l := 0; l < n; l++ {
        heap.Push(h, tuple{queryMax(l, n-1) - queryMin(l, n-1), l, n - 1})
    }
    var ans int64 = 0
    for ; k > 0; k-- {
        t := heap.Pop(h).(tuple)
        ans += int64(t.val)
        if t.r > t.l {
            heap.Push(h, tuple{queryMax(t.l, t.r-1) - queryMin(t.l, t.r-1), t.l, t.r - 1})
        }
    }
    return ans
}

type tuple struct{ val, l, r int }
type hp []tuple
func (h hp) Len() int           { return len(h) }
func (h hp) Less(i, j int) bool { return h[i].val > h[j].val }
func (h hp) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }
func (h *hp) Push(v any)        { *h = append(*h, v.(tuple)) }
func (h *hp) Pop() any          { a := *h; v := a[len(a)-1]; *h = a[:len(a)-1]; return v }
```

```Python
class Solution:
    def maxTotalValue(self, nums: List[int], k: int) -> int:
        n = len(nums)
        logn = n.bit_length()
        stMax = [[0] * logn for _ in range(n)]
        stMin = [[0] * logn for _ in range(n)]
        for i in range(n):
            stMax[i][0] = stMin[i][0] = nums[i]
        for j in range(1, logn):
            step = 1 << (j - 1)
            for i in range(n - (1 << j) + 1):
                stMax[i][j] = max(stMax[i][j - 1], stMax[i + step][j - 1])
                stMin[i][j] = min(stMin[i][j - 1], stMin[i + step][j - 1])

        def queryMax(l: int, r: int) -> int:
            j = (r - l + 1).bit_length() - 1
            return max(stMax[l][j], stMax[r - (1 << j) + 1][j])

        def queryMin(l: int, r: int) -> int:
            j = (r - l + 1).bit_length() - 1
            return min(stMin[l][j], stMin[r - (1 << j) + 1][j])

        pq = [(-(queryMax(l, n - 1) - queryMin(l, n - 1)), l, n - 1) for l in range(n)]
        heapq.heapify(pq)
        ans = 0
        while k:
            negVal, l, r = heapq.heappop(pq)
            ans -= negVal
            k -= 1
            if r > l:
                heapq.heappush(pq, (-(queryMax(l, r - 1) - queryMin(l, r - 1)), l, r - 1))
        return ans
```

```Java
class Solution {
    public long maxTotalValue(int[] nums, int k) {
        int n = nums.length;
        int logn = 32 - Integer.numberOfLeadingZeros(n);
        int[][] stMax = new int[n][logn];
        int[][] stMin = new int[n][logn];
        for (int i = 0; i < n; i++) {
            stMax[i][0] = stMin[i][0] = nums[i];
        }
        for (int j = 1; j < logn; j++) {
            for (int i = 0; i + (1 << j) <= n; i++) {
                stMax[i][j] = Math.max(stMax[i][j - 1], stMax[i + (1 << (j - 1))][j - 1]);
                stMin[i][j] = Math.min(stMin[i][j - 1], stMin[i + (1 << (j - 1))][j - 1]);
            }
        }
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> b[0] - a[0]);
        for (int l = 0; l < n; l++) {
            int j = 31 - Integer.numberOfLeadingZeros(n - 1 - l + 1);
            int mx = Math.max(stMax[l][j], stMax[n - 1 - (1 << j) + 1][j]);
            int mn = Math.min(stMin[l][j], stMin[n - 1 - (1 << j) + 1][j]);
            pq.offer(new int[]{mx - mn, l, n - 1});
        }
        long ans = 0;
        while (k-- > 0) {
            int[] top = pq.poll();
            ans += top[0];
            int l = top[1], r = top[2];
            if (r > l) {
                int j = 31 - Integer.numberOfLeadingZeros(r - 1 - l + 1);
                int mx = Math.max(stMax[l][j], stMax[r - 1 - (1 << j) + 1][j]);
                int mn = Math.min(stMin[l][j], stMin[r - 1 - (1 << j) + 1][j]);
                pq.offer(new int[]{mx - mn, l, r - 1});
            }
        }
        return ans;
    }
}
```

```TypeScript
function maxTotalValue(nums: number[], k: number): number {
    const n = nums.length;
    const logn = 32 - Math.clz32(n);
    const stMax: number[][] = Array.from({ length: n }, () => Array(logn).fill(0));
    const stMin: number[][] = Array.from({ length: n }, () => Array(logn).fill(0));
    for (let i = 0; i < n; i++) {
        stMax[i][0] = stMin[i][0] = nums[i];
    }
    for (let j = 1; j < logn; j++) {
        for (let i = 0; i + (1 << j) <= n; i++) {
            stMax[i][j] = Math.max(stMax[i][j - 1], stMax[i + (1 << (j - 1))][j - 1]);
            stMin[i][j] = Math.min(stMin[i][j - 1], stMin[i + (1 << (j - 1))][j - 1]);
        }
    }
    const queryMax = (l: number, r: number): number => {
        const j = 31 - Math.clz32(r - l + 1);
        return Math.max(stMax[l][j], stMax[r - (1 << j) + 1][j]);
    };
    const queryMin = (l: number, r: number): number => {
        const j = 31 - Math.clz32(r - l + 1);
        return Math.min(stMin[l][j], stMin[r - (1 << j) + 1][j]);
    };

    const heap = new Heap((a: [number, number, number], b: [number, number, number]) => b[0] - a[0]);
    for (let l = 0; l < n; l++) {
        heap.push([queryMax(l, n - 1) - queryMin(l, n - 1), l, n - 1]);
    }
    let ans = 0;
    while (k--) {
        const [val, l, r] = heap.pop()!;
        ans += val;
        if (r > l) {
            heap.push([queryMax(l, r - 1) - queryMin(l, r - 1), l, r - 1]);
        }
    }
    return ans;
}
```

```JavaScript
var maxTotalValue = function(nums, k) {
    const n = nums.length;
    const logn = 32 - Math.clz32(n);
    const stMax = Array.from({ length: n }, () => Array(logn).fill(0));
    const stMin = Array.from({ length: n }, () => Array(logn).fill(0));
    for (let i = 0; i < n; i++) {
        stMax[i][0] = stMin[i][0] = nums[i];
    }
    for (let j = 1; j < logn; j++) {
        for (let i = 0; i + (1 << j) <= n; i++) {
            stMax[i][j] = Math.max(stMax[i][j - 1], stMax[i + (1 << (j - 1))][j - 1]);
            stMin[i][j] = Math.min(stMin[i][j - 1], stMin[i + (1 << (j - 1))][j - 1]);
        }
    }
    const queryMax = (l, r) => {
        const j = 31 - Math.clz32(r - l + 1);
        return Math.max(stMax[l][j], stMax[r - (1 << j) + 1][j]);
    };
    const queryMin = (l, r) => {
        const j = 31 - Math.clz32(r - l + 1);
        return Math.min(stMin[l][j], stMin[r - (1 << j) + 1][j]);
    };

    const heap = new Heap((a, b) => b[0] - a[0]);
    for (let l = 0; l < n; l++) {
        heap.push([queryMax(l, n - 1) - queryMin(l, n - 1), l, n - 1]);
    }
    let ans = 0;
    while (k--) {
        const [val, l, r] = heap.pop();
        ans += val;
        if (r > l) {
            heap.push([queryMax(l, r - 1) - queryMin(l, r - 1), l, r - 1]);
        }
    }
    return ans;
};
```

```CSharp
public class Solution {
    public long MaxTotalValue(int[] nums, int k) {
        int n = nums.Length;
        int logn = 32 - BitOperations.LeadingZeroCount((uint)n);
        int[][] stMax = new int[n][];
        int[][] stMin = new int[n][];
        for (int i = 0; i < n; i++) {
            stMax[i] = new int[logn];
            stMin[i] = new int[logn];
            stMax[i][0] = stMin[i][0] = nums[i];
        }
        for (int j = 1; j < logn; j++) {
            for (int i = 0; i + (1 << j) <= n; i++) {
                stMax[i][j] = Math.Max(stMax[i][j - 1], stMax[i + (1 << (j - 1))][j - 1]);
                stMin[i][j] = Math.Min(stMin[i][j - 1], stMin[i + (1 << (j - 1))][j - 1]);
            }
        }
        var pq = new PriorityQueue<(int l, int r), int>();
        for (int l = 0; l < n; l++) {
            int j = 31 - BitOperations.LeadingZeroCount((uint)(n - 1 - l + 1));
            int mx = Math.Max(stMax[l][j], stMax[n - 1 - (1 << j) + 1][j]);
            int mn = Math.Min(stMin[l][j], stMin[n - 1 - (1 << j) + 1][j]);
            pq.Enqueue((l, n - 1), -(mx - mn));
        }
        long ans = 0;
        while (k-- > 0) {
            pq.TryDequeue(out var top, out int negVal);
            ans -= negVal;
            int l = top.l, r = top.r;
            if (r > l) {
                int j = 31 - BitOperations.LeadingZeroCount((uint)(r - 1 - l + 1));
                int mx = Math.Max(stMax[l][j], stMax[r - 1 - (1 << j) + 1][j]);
                int mn = Math.Min(stMin[l][j], stMin[r - 1 - (1 << j) + 1][j]);
                pq.Enqueue((l, r - 1), -(mx - mn));
            }
        }
        return ans;
    }
}
```

```C
typedef struct {
    int val, l, r;
} Tuple;

typedef struct {
    Tuple* data;
    int size;
} MaxHeap;

void heapPush(MaxHeap* h, Tuple t) {
    int i = h->size++;
    while (i > 0) {
        int p = (i - 1) >> 1;
        if (h->data[p].val >= t.val) {
            break;
        }
        h->data[i] = h->data[p];
        i = p;
    }
    h->data[i] = t;
}

Tuple heapPop(MaxHeap* h) {
    Tuple top = h->data[0];
    Tuple last = h->data[--h->size];
    if (h->size > 0) {
        h->data[0] = last;
        int i = 0;
        while (1) {
            int largest = i;
            int l = 2 * i + 1, r = 2 * i + 2;
            if (l < h->size && h->data[l].val > h->data[largest].val) {
                largest = l;
            }
            if (r < h->size && h->data[r].val > h->data[largest].val) {
                largest = r;
            }
            if (largest == i) {
                break;
            }
            Tuple tmp = h->data[i];
            h->data[i] = h->data[largest];
            h->data[largest] = tmp;
            i = largest;
        }
    }
    return top;
}

long long maxTotalValue(int* nums, int numsSize, int k) {
    int n = numsSize;
    int logn = 32 - __builtin_clz(n);
    int (*stMax)[logn] = malloc(n * logn * sizeof(int));
    int (*stMin)[logn] = malloc(n * logn * sizeof(int));
    for (int i = 0; i < n; i++) {
        stMax[i][0] = stMin[i][0] = nums[i];
    }
    for (int j = 1; j < logn; j++) {
        for (int i = 0; i + (1 << j) <= n; i++) {
            stMax[i][j] = (int)fmax(stMax[i][j - 1], stMax[i + (1 << (j - 1))][j - 1]);
            stMin[i][j] = (int)fmin(stMin[i][j - 1], stMin[i + (1 << (j - 1))][j - 1]);
        }
    }
    MaxHeap heap;
    heap.data = malloc(n * sizeof(Tuple));
    heap.size = 0;
    for (int l = 0; l < n; l++) {
        int j = 31 - __builtin_clz(n - 1 - l + 1);
        int mx = (int)fmax(stMax[l][j], stMax[n - 1 - (1 << j) + 1][j]);
        int mn = (int)fmin(stMin[l][j], stMin[n - 1 - (1 << j) + 1][j]);
        heapPush(&heap, (Tuple){mx - mn, l, n - 1});
    }
    long long ans = 0;
    while (k--) {
        Tuple t = heapPop(&heap);
        ans += t.val;
        if (t.r > t.l) {
            int j = 31 - __builtin_clz(t.r - 1 - t.l + 1);
            int mx = (int)fmax(stMax[t.l][j], stMax[t.r - 1 - (1 << j) + 1][j]);
            int mn = (int)fmin(stMin[t.l][j], stMin[t.r - 1 - (1 << j) + 1][j]);
            heapPush(&heap, (Tuple){mx - mn, t.l, t.r - 1});
        }
    }
    free(heap.data);
    free(stMax);
    free(stMin);
    return ans;
}
```

```Rust
use std::collections::BinaryHeap;

impl Solution {
    pub fn max_total_value(nums: Vec<i32>, k: i32) -> i64 {
        let n = nums.len();
        let logn = 32 - (n as u32).leading_zeros() as usize;
        let mut st_max = vec![vec![0; logn]; n];
        let mut st_min = vec![vec![0; logn]; n];
        for i in 0..n {
            st_max[i][0] = nums[i];
            st_min[i][0] = nums[i];
        }
        for j in 1..logn {
            for i in 0..n {
                if i + (1 << j) > n {
                    break;
                }
                st_max[i][j] = st_max[i][j - 1].max(st_max[i + (1 << (j - 1))][j - 1]);
                st_min[i][j] = st_min[i][j - 1].min(st_min[i + (1 << (j - 1))][j - 1]);
            }
        }
        let query_max = |l: usize, r: usize| -> i32 {
            let j = 31 - ((r - l + 1) as u32).leading_zeros() as usize;
            st_max[l][j].max(st_max[r - (1 << j) + 1][j])
        };
        let query_min = |l: usize, r: usize| -> i32 {
            let j = 31 - ((r - l + 1) as u32).leading_zeros() as usize;
            st_min[l][j].min(st_min[r - (1 << j) + 1][j])
        };
        let mut heap = BinaryHeap::new();
        for l in 0..n {
            let val = query_max(l, n - 1) - query_min(l, n - 1);
            heap.push((val, l, n - 1));
        }
        let mut ans: i64 = 0;
        let mut k = k as usize;
        while k > 0 {
            if let Some((val, l, r)) = heap.pop() {
                ans += val as i64;
                if r > l {
                    let new_val = query_max(l, r - 1) - query_min(l, r - 1);
                    heap.push((new_val, l, r - 1));
                }
            }
            k -= 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n+k\log n)$，其中 $n$ 是 $nums$ 的长度，$k$ 是选择的非空子数组数目。$ST$ 表预处理需要 $O(n\log n)$ 的时间，堆的初始化需要 $O(n\log n)$，每次弹出和压入堆需要 $O(\log n)$，共 $k$ 次操作。
- 空间复杂度：$O(n\log n)$。ST 表需要 $O(n\log n)$ 的空间存储，堆需要 $O(n)$ 的空间。

#### 方法二：线段树 $+$ 最大堆

**思路与算法**

方法一使用 $ST$ 表实现 $O(1)$ 区间最值查询，预处理需要 $O(n\log n)$ 的空间。我们也可以使用线段树替代 $ST$ 表，将空间复杂度降低到 $O(n)$。线段树是一种二叉树结构，每个节点存储对应区间的最大值和最小值，支持 $O(\log n)$ 的区间查询。

算法流程与方法一完全相同：

1. 预处理线段树，存储每个区间的最大值和最小值。
2. 对于每个左端点 $l$，将子数组 $nums[l..n-1]$ 的值放入最大堆。
3. 重复 $k$ 次：弹出堆顶，累加答案，若 $r>l$ 则将 $nums[l..r-1]$ 的值放入堆。

**代码**

```C++
class SegTree {
    vector<int> maxv, minv;
    int n;

public:
    SegTree(vector<int>& nums) {
        n = nums.size();
        maxv.resize(n * 4);
        minv.resize(n * 4);
        build(1, 0, n - 1, nums);
    }

    void build(int node, int l, int r, vector<int>& nums) {
        if (l == r) {
            maxv[node] = minv[node] = nums[l];
            return;
        }
        int m = (l + r) / 2;
        build(node * 2, l, m, nums);
        build(node * 2 + 1, m + 1, r, nums);
        maxv[node] = max(maxv[node * 2], maxv[node * 2 + 1]);
        minv[node] = min(minv[node * 2], minv[node * 2 + 1]);
    }

    int queryMax(int node, int l, int r, int ql, int qr) {
        if (ql <= l && r <= qr) {
            return maxv[node];
        }
        int m = (l + r) / 2, res = INT_MIN;
        if (ql <= m) {
            res = max(res, queryMax(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = max(res, queryMax(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }

    int queryMin(int node, int l, int r, int ql, int qr) {
        if (ql <= l && r <= qr) {
            return minv[node];
        }
        int m = (l + r) / 2, res = INT_MAX;
        if (ql <= m) {
            res = min(res, queryMin(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = min(res, queryMin(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }
};

class Solution {
public:
    long long maxTotalValue(vector<int>& nums, int k) {
        int n = nums.size();
        SegTree seg(nums);
        priority_queue<tuple<int, int, int>> pq;
        for (int l = 0; l < n; l++) {
            pq.emplace(seg.queryMax(1, 0, n - 1, l, n - 1) - seg.queryMin(1, 0, n - 1, l, n - 1), l, n - 1);
        }
        long long ans = 0;
        while (k--) {
            auto [val, l, r] = pq.top();
            pq.pop();
            ans += val;
            if (r > l) {
                pq.emplace(seg.queryMax(1, 0, n - 1, l, r - 1) - seg.queryMin(1, 0, n - 1, l, r - 1), l, r - 1);
            }
        }
        return ans;
    }
};
```

```Go
type segTree struct {
    maxv, minv []int
    n          int
}

func newSegTree(nums []int) *segTree {
    n := len(nums)
    s := &segTree{
        maxv: make([]int, n*4),
        minv: make([]int, n*4),
        n:    n,
    }
    s.build(1, 0, n-1, nums)
    return s
}

func (s *segTree) build(node, l, r int, nums []int) {
    if l == r {
        s.maxv[node] = nums[l]
        s.minv[node] = nums[l]
        return
    }
    m := (l + r) / 2
    s.build(node*2, l, m, nums)
    s.build(node*2+1, m+1, r, nums)
    s.maxv[node] = max(s.maxv[node*2], s.maxv[node*2+1])
    s.minv[node] = min(s.minv[node*2], s.minv[node*2+1])
}

func (s *segTree) queryMax(node, l, r, ql, qr int) int {
    if ql <= l && r <= qr {
        return s.maxv[node]
    }
    m := (l + r) / 2
    res := math.MinInt
    if ql <= m {
        res = max(res, s.queryMax(node*2, l, m, ql, qr))
    }
    if qr > m {
        res = max(res, s.queryMax(node*2+1, m+1, r, ql, qr))
    }
    return res
}

func (s *segTree) queryMin(node, l, r, ql, qr int) int {
    if ql <= l && r <= qr {
        return s.minv[node]
    }
    m := (l + r) / 2
    res := math.MaxInt
    if ql <= m {
        res = min(res, s.queryMin(node*2, l, m, ql, qr))
    }
    if qr > m {
        res = min(res, s.queryMin(node*2+1, m+1, r, ql, qr))
    }
    return res
}

func maxTotalValue(nums []int, k int) int64 {
    n := len(nums)
    seg := newSegTree(nums)
    h := &hp{}
    for l := 0; l < n; l++ {
        heap.Push(h, tuple{seg.queryMax(1, 0, n-1, l, n-1) - seg.queryMin(1, 0, n-1, l, n-1), l, n - 1})
    }
    var ans int64 = 0
    for ; k > 0; k-- {
        t := heap.Pop(h).(tuple)
        ans += int64(t.val)
        if t.r > t.l {
            heap.Push(h, tuple{seg.queryMax(1, 0, n-1, t.l, t.r-1) - seg.queryMin(1, 0, n-1, t.l, t.r-1), t.l, t.r - 1})
        }
    }
    return ans
}

type tuple struct{ val, l, r int }
type hp []tuple
func (h hp) Len() int           { return len(h) }
func (h hp) Less(i, j int) bool { return h[i].val > h[j].val }
func (h hp) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }
func (h *hp) Push(v any)        { *h = append(*h, v.(tuple)) }
func (h *hp) Pop() any          { a := *h; v := a[len(a)-1]; *h = a[:len(a)-1]; return v }
```

```Python
class SegTree:
    def __init__(self, nums: List[int]):
        self.n = len(nums)
        self.maxv = [0] * (4 * self.n)
        self.minv = [0] * (4 * self.n)
        self.build(1, 0, self.n - 1, nums)

    def build(self, node: int, l: int, r: int, nums: List[int]):
        if l == r:
            self.maxv[node] = self.minv[node] = nums[l]
            return
        m = (l + r) // 2
        self.build(node * 2, l, m, nums)
        self.build(node * 2 + 1, m + 1, r, nums)
        self.maxv[node] = max(self.maxv[node * 2], self.maxv[node * 2 + 1])
        self.minv[node] = min(self.minv[node * 2], self.minv[node * 2 + 1])

    def queryMax(self, node: int, l: int, r: int, ql: int, qr: int) -> int:
        if ql <= l and r <= qr:
            return self.maxv[node]
        m = (l + r) // 2
        res = -10**18
        if ql <= m:
            res = max(res, self.queryMax(node * 2, l, m, ql, qr))
        if qr > m:
            res = max(res, self.queryMax(node * 2 + 1, m + 1, r, ql, qr))
        return res

    def queryMin(self, node: int, l: int, r: int, ql: int, qr: int) -> int:
        if ql <= l and r <= qr:
            return self.minv[node]
        m = (l + r) // 2
        res = 10**18
        if ql <= m:
            res = min(res, self.queryMin(node * 2, l, m, ql, qr))
        if qr > m:
            res = min(res, self.queryMin(node * 2 + 1, m + 1, r, ql, qr))
        return res


class Solution:
    def maxTotalValue(self, nums: List[int], k: int) -> int:
        n = len(nums)
        seg = SegTree(nums)
        pq = [(-(seg.queryMax(1, 0, n - 1, l, n - 1) - seg.queryMin(1, 0, n - 1, l, n - 1)), l, n - 1) for l in range(n)]
        heapq.heapify(pq)
        ans = 0
        while k:
            negVal, l, r = heapq.heappop(pq)
            ans -= negVal
            k -= 1
            if r > l:
                heapq.heappush(pq, (-(seg.queryMax(1, 0, n - 1, l, r - 1) - seg.queryMin(1, 0, n - 1, l, r - 1)), l, r - 1))
        return ans
```

```Java
class SegTree {
    int[] maxv, minv;
    int n;

    SegTree(int[] nums) {
        n = nums.length;
        maxv = new int[n * 4];
        minv = new int[n * 4];
        build(1, 0, n - 1, nums);
    }

    void build(int node, int l, int r, int[] nums) {
        if (l == r) {
            maxv[node] = minv[node] = nums[l];
            return;
        }
        int m = (l + r) / 2;
        build(node * 2, l, m, nums);
        build(node * 2 + 1, m + 1, r, nums);
        maxv[node] = Math.max(maxv[node * 2], maxv[node * 2 + 1]);
        minv[node] = Math.min(minv[node * 2], minv[node * 2 + 1]);
    }

    int queryMax(int node, int l, int r, int ql, int qr) {
        if (ql <= l && r <= qr) {
            return maxv[node];
        }
        int m = (l + r) / 2, res = Integer.MIN_VALUE;
        if (ql <= m) {
            res = Math.max(res, queryMax(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = Math.max(res, queryMax(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }

    int queryMin(int node, int l, int r, int ql, int qr) {
        if (ql <= l && r <= qr) {
            return minv[node];
        }
        int m = (l + r) / 2, res = Integer.MAX_VALUE;
        if (ql <= m) {
            res = Math.min(res, queryMin(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = Math.min(res, queryMin(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }
}

class Solution {
    public long maxTotalValue(int[] nums, int k) {
        int n = nums.length;
        SegTree seg = new SegTree(nums);
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> b[0] - a[0]);
        for (int l = 0; l < n; l++) {
            pq.offer(new int[]{seg.queryMax(1, 0, n - 1, l, n - 1) - seg.queryMin(1, 0, n - 1, l, n - 1), l, n - 1});
        }
        long ans = 0;
        while (k-- > 0) {
            int[] top = pq.poll();
            ans += top[0];
            int l = top[1], r = top[2];
            if (r > l) {
                pq.offer(new int[]{seg.queryMax(1, 0, n - 1, l, r - 1) - seg.queryMin(1, 0, n - 1, l, r - 1), l, r - 1});
            }
        }
        return ans;
    }
}
```

```TypeScript
class SegTree {
    maxv: number[];
    minv: number[];
    n: number;
    constructor(nums: number[]) {
        this.n = nums.length;
        this.maxv = new Array(this.n * 4).fill(0);
        this.minv = new Array(this.n * 4).fill(0);
        this.build(1, 0, this.n - 1, nums);
    }

    build(node: number, l: number, r: number, nums: number[]) {
        if (l === r) {
            this.maxv[node] = this.minv[node] = nums[l];
            return;
        }
        const m = (l + r) >> 1;
        this.build(node * 2, l, m, nums);
        this.build(node * 2 + 1, m + 1, r, nums);
        this.maxv[node] = Math.max(this.maxv[node * 2], this.maxv[node * 2 + 1]);
        this.minv[node] = Math.min(this.minv[node * 2], this.minv[node * 2 + 1]);
    }

    queryMax(node: number, l: number, r: number, ql: number, qr: number): number {
        if (ql <= l && r <= qr) {
            return this.maxv[node];
        }
        const m = (l + r) >> 1;
        let res = -Infinity;
        if (ql <= m) {
            res = Math.max(res, this.queryMax(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = Math.max(res, this.queryMax(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }

    queryMin(node: number, l: number, r: number, ql: number, qr: number): number {
        if (ql <= l && r <= qr) {
            return this.minv[node];
        }
        const m = (l + r) >> 1;
        let res = Infinity;
        if (ql <= m) {
            res = Math.min(res, this.queryMin(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = Math.min(res, this.queryMin(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }
}

function maxTotalValue(nums: number[], k: number): number {
    const n = nums.length;
    const seg = new SegTree(nums);
    const heap = new Heap((a: [number, number, number], b: [number, number, number]) => b[0] - a[0]);
    for (let l = 0; l < n; l++) {
        heap.push([seg.queryMax(1, 0, n - 1, l, n - 1) - seg.queryMin(1, 0, n - 1, l, n - 1), l, n - 1]);
    }
    let ans = 0;
    while (k--) {
        const [val, l, r] = heap.pop()!;
        ans += val;
        if (r > l) {
            heap.push([seg.queryMax(1, 0, n - 1, l, r - 1) - seg.queryMin(1, 0, n - 1, l, r - 1), l, r - 1]);
        }
    }
    return ans;
}
```

```JavaScript
class SegTree {
    constructor(nums) {
        this.n = nums.length;
        this.maxv = new Array(this.n * 4).fill(0);
        this.minv = new Array(this.n * 4).fill(0);
        this.build(1, 0, this.n - 1, nums);
    }

    build(node, l, r, nums) {
        if (l === r) {
            this.maxv[node] = this.minv[node] = nums[l];
            return;
        }
        const m = (l + r) >> 1;
        this.build(node * 2, l, m, nums);
        this.build(node * 2 + 1, m + 1, r, nums);
        this.maxv[node] = Math.max(this.maxv[node * 2], this.maxv[node * 2 + 1]);
        this.minv[node] = Math.min(this.minv[node * 2], this.minv[node * 2 + 1]);
    }

    queryMax(node, l, r, ql, qr) {
        if (ql <= l && r <= qr) {
            return this.maxv[node];
        }
        const m = (l + r) >> 1;
        let res = -Infinity;
        if (ql <= m) {
            res = Math.max(res, this.queryMax(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = Math.max(res, this.queryMax(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }

    queryMin(node, l, r, ql, qr) {
        if (ql <= l && r <= qr) {
            return this.minv[node];
        }
        const m = (l + r) >> 1;
        let res = Infinity;
        if (ql <= m) {
            res = Math.min(res, this.queryMin(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = Math.min(res, this.queryMin(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }
}

var maxTotalValue = function(nums, k) {
    const n = nums.length;
    const seg = new SegTree(nums);
    const heap = new Heap((a, b) => b[0] - a[0]);
    for (let l = 0; l < n; l++) {
        heap.push([seg.queryMax(1, 0, n - 1, l, n - 1) - seg.queryMin(1, 0, n - 1, l, n - 1), l, n - 1]);
    }
    let ans = 0;
    while (k--) {
        const [val, l, r] = heap.pop();
        ans += val;
        if (r > l) {
            heap.push([seg.queryMax(1, 0, n - 1, l, r - 1) - seg.queryMin(1, 0, n - 1, l, r - 1), l, r - 1]);
        }
    }
    return ans;
};
```

```CSharp
public class SegTree {
    int[] maxv, minv;
    int n;

    public SegTree(int[] nums) {
        n = nums.Length;
        maxv = new int[n * 4];
        minv = new int[n * 4];
        Build(1, 0, n - 1, nums);
    }

    void Build(int node, int l, int r, int[] nums) {
        if (l == r) {
            maxv[node] = minv[node] = nums[l];
            return;
        }
        int m = (l + r) / 2;
        Build(node * 2, l, m, nums);
        Build(node * 2 + 1, m + 1, r, nums);
        maxv[node] = Math.Max(maxv[node * 2], maxv[node * 2 + 1]);
        minv[node] = Math.Min(minv[node * 2], minv[node * 2 + 1]);
    }

    public int QueryMax(int node, int l, int r, int ql, int qr) {
        if (ql <= l && r <= qr) {
            return maxv[node];
        }
        int m = (l + r) / 2, res = int.MinValue;
        if (ql <= m) {
            res = Math.Max(res, QueryMax(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = Math.Max(res, QueryMax(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }

    public int QueryMin(int node, int l, int r, int ql, int qr) {
        if (ql <= l && r <= qr) {
            return minv[node];
        }
        int m = (l + r) / 2, res = int.MaxValue;
        if (ql <= m) {
            res = Math.Min(res, QueryMin(node * 2, l, m, ql, qr));
        }
        if (qr > m) {
            res = Math.Min(res, QueryMin(node * 2 + 1, m + 1, r, ql, qr));
        }
        return res;
    }
}

public class Solution {
    public long MaxTotalValue(int[] nums, int k) {
        int n = nums.Length;
        var seg = new SegTree(nums);
        var pq = new PriorityQueue<(int l, int r), int>();
        for (int l = 0; l < n; l++) {
            int val = seg.QueryMax(1, 0, n - 1, l, n - 1) - seg.QueryMin(1, 0, n - 1, l, n - 1);
            pq.Enqueue((l, n - 1), -val);
        }
        long ans = 0;
        while (k-- > 0) {
            pq.TryDequeue(out var top, out int negVal);
            ans -= negVal;
            int l = top.l, r = top.r;
            if (r > l) {
                int val = seg.QueryMax(1, 0, n - 1, l, r - 1) - seg.QueryMin(1, 0, n - 1, l, r - 1);
                pq.Enqueue((l, r - 1), -val);
            }
        }
        return ans;
    }
}
```

```C
typedef struct {
    int* maxv;
    int* minv;
    int n;
} SegTree;

void segBuild(SegTree* seg, int node, int l, int r, int* nums) {
    if (l == r) {
        seg->maxv[node] = seg->minv[node] = nums[l];
        return;
    }
    int m = (l + r) / 2;
    segBuild(seg, node * 2, l, m, nums);
    segBuild(seg, node * 2 + 1, m + 1, r, nums);
    seg->maxv[node] = (int)fmax(seg->maxv[node * 2], seg->maxv[node * 2 + 1]);
    seg->minv[node] = (int)fmin(seg->minv[node * 2], seg->minv[node * 2 + 1]);
}

SegTree* segTreeCreate(int* nums, int n) {
    SegTree* seg = malloc(sizeof(SegTree));
    seg->n = n;
    seg->maxv = calloc(n * 4, sizeof(int));
    seg->minv = calloc(n * 4, sizeof(int));
    segBuild(seg, 1, 0, n - 1, nums);
    return seg;
}

int segQueryMax(SegTree* seg, int node, int l, int r, int ql, int qr) {
    if (ql <= l && r <= qr) {
        return seg->maxv[node];
    }
    int m = (l + r) / 2, res = INT_MIN;
    if (ql <= m) {
        res = (int)fmax(res, segQueryMax(seg, node * 2, l, m, ql, qr));
    }
    if (qr > m) {
        res = (int)fmax(res, segQueryMax(seg, node * 2 + 1, m + 1, r, ql, qr));
    }
    return res;
}

int segQueryMin(SegTree* seg, int node, int l, int r, int ql, int qr) {
    if (ql <= l && r <= qr) {
        return seg->minv[node];
    }
    int m = (l + r) / 2, res = INT_MAX;
    if (ql <= m) {
        res = (int)fmin(res, segQueryMin(seg, node * 2, l, m, ql, qr));
    }
    if (qr > m) {
        res = (int)fmin(res, segQueryMin(seg, node * 2 + 1, m + 1, r, ql, qr));
    }
    return res;
}

void segTreeFree(SegTree* seg) {
    free(seg->maxv);
    free(seg->minv);
    free(seg);
}

typedef struct {
    int val, l, r;
} Tuple;

typedef struct {
    Tuple* data;
    int size;
} MaxHeap;

void heapPush(MaxHeap* h, Tuple t) {
    int i = h->size++;
    while (i > 0) {
        int p = (i - 1) >> 1;
        if (h->data[p].val >= t.val) {
            break;
        }
        h->data[i] = h->data[p];
        i = p;
    }
    h->data[i] = t;
}

Tuple heapPop(MaxHeap* h) {
    Tuple top = h->data[0];
    Tuple last = h->data[--h->size];
    if (h->size > 0) {
        h->data[0] = last;
        int i = 0;
        while (1) {
            int largest = i;
            int lc = 2 * i + 1, rc = 2 * i + 2;
            if (lc < h->size && h->data[lc].val > h->data[largest].val) {
                largest = lc;
            }
            if (rc < h->size && h->data[rc].val > h->data[largest].val) {
                largest = rc;
            }
            if (largest == i) {
                break;
            }
            Tuple tmp = h->data[i];
            h->data[i] = h->data[largest];
            h->data[largest] = tmp;
            i = largest;
        }
    }
    return top;
}

long long maxTotalValue(int* nums, int numsSize, int k) {
    int n = numsSize;
    SegTree* seg = segTreeCreate(nums, n);
    MaxHeap heap;
    heap.data = malloc(n * sizeof(Tuple));
    heap.size = 0;
    for (int l = 0; l < n; l++) {
        int mx = segQueryMax(seg, 1, 0, n - 1, l, n - 1);
        int mn = segQueryMin(seg, 1, 0, n - 1, l, n - 1);
        heapPush(&heap, (Tuple){mx - mn, l, n - 1});
    }
    long long ans = 0;
    while (k--) {
        Tuple t = heapPop(&heap);
        ans += t.val;
        if (t.r > t.l) {
            int mx = segQueryMax(seg, 1, 0, n - 1, t.l, t.r - 1);
            int mn = segQueryMin(seg, 1, 0, n - 1, t.l, t.r - 1);
            heapPush(&heap, (Tuple){mx - mn, t.l, t.r - 1});
        }
    }
    free(heap.data);
    segTreeFree(seg);
    return ans;
}
```

```Rust
use std::collections::BinaryHeap;

struct SegTree {
    maxv: Vec<i32>,
    minv: Vec<i32>,
    n: usize,
}

impl SegTree {
    fn new(nums: &Vec<i32>) -> Self {
        let n = nums.len();
        let mut seg = SegTree {
            maxv: vec![0; n * 4],
            minv: vec![0; n * 4],
            n,
        };
        seg.build(1, 0, n - 1, nums);
        seg
    }

    fn build(&mut self, node: usize, l: usize, r: usize, nums: &Vec<i32>) {
        if l == r {
            self.maxv[node] = nums[l];
            self.minv[node] = nums[l];
            return;
        }
        let m = (l + r) / 2;
        self.build(node * 2, l, m, nums);
        self.build(node * 2 + 1, m + 1, r, nums);
        self.maxv[node] = self.maxv[node * 2].max(self.maxv[node * 2 + 1]);
        self.minv[node] = self.minv[node * 2].min(self.minv[node * 2 + 1]);
    }

    fn query_max(&self, node: usize, l: usize, r: usize, ql: usize, qr: usize) -> i32 {
        if ql <= l && r <= qr {
            return self.maxv[node];
        }
        let m = (l + r) / 2;
        let mut res = i32::MIN;
        if ql <= m {
            res = res.max(self.query_max(node * 2, l, m, ql, qr));
        }
        if qr > m {
            res = res.max(self.query_max(node * 2 + 1, m + 1, r, ql, qr));
        }
        res
    }

    fn query_min(&self, node: usize, l: usize, r: usize, ql: usize, qr: usize) -> i32 {
        if ql <= l && r <= qr {
            return self.minv[node];
        }
        let m = (l + r) / 2;
        let mut res = i32::MAX;
        if ql <= m {
            res = res.min(self.query_min(node * 2, l, m, ql, qr));
        }
        if qr > m {
            res = res.min(self.query_min(node * 2 + 1, m + 1, r, ql, qr));
        }
        res
    }
}

impl Solution {
    pub fn max_total_value(nums: Vec<i32>, k: i32) -> i64 {
        let n = nums.len();
        let seg = SegTree::new(&nums);
        let mut heap = BinaryHeap::new();
        for l in 0..n {
            let val = seg.query_max(1, 0, n - 1, l, n - 1) - seg.query_min(1, 0, n - 1, l, n - 1);
            heap.push((val, l, n - 1));
        }
        let mut ans: i64 = 0;
        let mut k = k as usize;
        while k > 0 {
            if let Some((val, l, r)) = heap.pop() {
                ans += val as i64;
                if r > l {
                    let new_val = seg.query_max(1, 0, n - 1, l, r - 1) - seg.query_min(1, 0, n - 1, l, r - 1);
                    heap.push((new_val, l, r - 1));
                }
            }
            k -= 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O((n+k)\log n)$。线段树建树需要 $O(n)$，每次区间查询需要 $O(\log n)$，共 $O(n+k)$ 次查询，堆操作共 $O((n+k)\log n)$。
- 空间复杂度：$O(n)$。线段树和堆均需要 $O(n)$ 的空间。
