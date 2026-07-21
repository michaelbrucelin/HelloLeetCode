### [操作后最大活跃区段数 II](https://leetcode.cn/problems/maximize-active-section-with-trade-ii/solutions/3992724/cao-zuo-hou-zui-da-huo-yue-qu-duan-shu-i-bn0o/)

#### 方法一：二分查找 + 线段树

**思路与算法**

请读者首先解决本题的前置题目「[3499\. 操作后最大活跃区段数 I](https://leetcode.cn/problems/maximize-active-section-with-trade-i/)」。

在「[3499\. 操作后最大活跃区段数 I](https://leetcode.cn/problems/maximize-active-section-with-trade-i/)」 中我们已经知道，进行一次操作后，字符串的最大活跃区段数等于：

$$cnt_1+bestGain$$

且：

- $cnt_1$ 为字符串 $s$ 中 字符 $1$ 的数量
- $bestGain$ 等于两个相邻连续 $0$ 区块长度之和的最大值

---

在本题中，我们需要回答多个查询。

对于每个查询 $[l,r]$，我们只允许在子字符串 $s[l..r]$ 内部进行操作。注意，我们最终需要回答整个字符串 $s$ 在操作后的最大活跃区段数，而不是子字符串内部的最大活跃区段数。所以，对于每个询问，我们实际上只需求出该子字符串中的 $bestGain$ 即可。

暴力处理每个询问需要枚举子字符串中的所有连续 $0$ 区块，时间复杂度为：

$$O(nq)$$

无法通过本题。

因此，我们需要寻找一种能够快速回答查询的方法。

##### 预处理连续 $0$ 区块

我们首先提取原字符串 $s$ 中所有连续 $0$ 区块的长度。设这些区块长度构成数组：

$$zeroBlocks=[z_0,z_1,\dots ,z_{m-1}]$$

其中：

- $m$ 为连续 $0$ 区块的数量
- $z_k$ 表示第 $k$ 个连续 $0$ 区块的长度

对于某个查询 $[l,r]$，设其对应的子字符串 $s[l..r]$ 中的连续 $0$ 区块长度数组为：

$$subZeroBlocks$$

下面给出了一些例子，表示 $subZeroBlocks$ 可能发生的各种情况。

![](./assets/img/Solution3501_off_1_01.png)
![](./assets/img/Solution3501_off_1_02.png)
![](./assets/img/Solution3501_off_1_03.png)
![](./assets/img/Solution3501_off_1_04.png)
![](./assets/img/Solution3501_off_1_05.png)
![](./assets/img/Solution3501_off_1_06.png)

我们发现，除了第一个和最后一个元素外，$subZeroBlocks$ 一定是 $zeroBlocks$ 的一个**连续子数组**。

原因是：

子字符串可能只截取了某个连续 $0$ 区块的一部分，因此只有**首尾区块的长度可能发生变化**。

因此：

$$subZeroBlocks=[z_i^′,z_{i+1},\dots ,z_{j-1},z_j^′]$$

其中：

- $z_i^′$ 表示子字符串 $s[l..r]$ 中第一个连续 $0$ 区块的实际长度，且 $z_i^′\le z_i$。
- $z_j^′$ 表示子字符串 $s[l..r]$ 中最后一个连续 $0$ 区块的实际长度，且 $z_j^′\le z_j$。

更进一步地，我们有：

- 当且仅当 $s[l]=0$ 且 $l$ 不是该连续 $0$ 区块的左端点时，才有：

$$z_i^′<z_i$$

- 当且仅当 $s[r]=0$ 且 $r$ 不是该连续 $0$ 区块的右端点时，才有：

$$z_j^′<z_j$$

##### 计算 $bestGain$

由于我们只关心为了连续 $0$ 区块的情况，为了方便起见，以下我们将连续 $0$ 区块简称为区块。

由于 $bestGain$ 等于两个相邻区块长度之和的最大值，因此，对于当前查询 $[l,r]$，其答案等于以下三种情况的最大值。

- 情况 $1$：使用 $subZeroBlock$ 前两个区块：
    $$val_1=z_i^′+z_{i+1}$$
- 情况 $2$：使用 $subZeroBlock$ 后两个区块：
    $$val_2=z_{j-1}+z_j^′$$
- 情况 $3$：使用完全位于 $subZeroBlock$ 中间的区块：
    $$val_3=\mathop{max}\limits_{i+1\le k\le j-2}(z_k+z_{k+1})$$

最终：

$$bestGain=max(val_1,val_2,val_3)$$

##### 快速定位区块

根据以上计算 $bestGain$ 的方法，我们需要快速定位查询对应的区块范围。为此，我们额外预处理两个数组 $blockLeft$ 和 $blockRight$，其中：

- $blockLeft[k]$ 表示 $s$ 中第 $k$ 个区块的左端点
- $blockRight[k]$ 表示 $s$ 中第 $k$ 个区块的右端点

由于区块互不重叠，因此 $blockLeft$ 和 $blockRight$ 均严格递增。于是我们可以使用二分查找快速定位区块。

##### 具体实现

对于查询 $[l,r]$：
我们首先在 $blockRight$ 中二分查找第一个满足：$blockRight[i]\ge l$ 的区块。设该区块为：

$$[L_i,R_i]$$

则子字符串 $s[l...r]$ 第一个区块的实际长度为：

$$z_i^′=R_i-max(L_i,l)+1$$

类似地，我们在blockLeft 中二分查找最后一个满足：$blockLeft[j]\le r$ 的区块。设该区块为：

$$[L_j,R_j]$$

则子字符串 $s[l...r]$ 最后一个区块的实际长度为：

$$z_j^′=min(R_j,r)-L_j+1$$

此外，为了计算情况 $3$ 对应的答案，我们定义辅助数组：

$$tmpSum_k=z_k+z_{k+1}$$

那么：

$$val_3=\mathop{max}\limits_{i+1\le k\le j-2}tmpSum_k$$

于是问题转化为求 $tmpSum$ 某个区间内的最大值，我们可以使用线段树来解决这个问题。

一些细节需要注意：

- 二分查找可能出现越界的问题，即 $i>m-1$ 或 $j<0$，此时子字符串内一定没有区块，$bestGain=0$。
- 当 $i\ge j$ 时，子字符串内区块个数不会大于 $2$，因此不存在相邻区块，$bestGain=0$。
- 当子字符串内恰好有 $2$ 个区块时，子字符串内可能不存在完整的区块，情况 $3$ 的结果无意义，此时 $bestGain$ 等于这 $2$ 个区块的长度之和。
- 如果原字符串 $s$ 中区块个数小于 $2$，那么无法进行任何操作，可以直接返回答案。

**代码**

```Python
class SegmentTree:
    def __init__(self, arr):
        self.n = len(arr)
        self.arr = arr
        self.seg = [0] * (self.n << 2)

        if self.n:
            self.build(1, 0, self.n - 1)

    def build(self, p: int, l: int, r: int) -> None:
        if l == r:
            self.seg[p] = self.arr[l]
            return

        mid = (l + r) >> 1

        self.build(p << 1, l, mid)
        self.build(p << 1 | 1, mid + 1, r)

        self.seg[p] = max(
            self.seg[p << 1],
            self.seg[p << 1 | 1]
        )

    def query(self, L: int, R: int) -> int:
        if L > R:
            return 0

        def _query(p: int, l: int, r: int) -> int:
            if L <= l and r <= R:
                return self.seg[p]

            mid = (l + r) >> 1
            res = 0

            if L <= mid:
                res = max(res, _query(p << 1, l, mid))

            if R > mid:
                res = max(res, _query(p << 1 | 1, mid + 1, r))

            return res

        return _query(1, 0, self.n - 1)

class Solution:
    def maxActiveSectionsAfterTrade(self, s: str, queries: List[List[int]]) -> List[int]:
        n = len(s)
        cnt1 = s.count('1')

        zeroBlocks = []
        blockLeft = []
        blockRight = []

        i = 0
        while i < n:
            st = i

            while i < n and s[i] == s[st]:
                i += 1

            if s[st] == '0':
                zeroBlocks.append(i - st)
                blockLeft.append(st)
                blockRight.append(i - 1)

        m = len(zeroBlocks)
        if m < 2:  # 连续 0 区块少于 2 段，直接返回答案
            return [cnt1] * len(queries)

        tmpSum = [zeroBlocks[i] + zeroBlocks[i + 1] for i in range(m - 1)]
        seg = SegmentTree(tmpSum)
        ans = []

        for l, r in queries:
            i = bisect_left(blockRight, l)
            j = bisect_right(blockLeft, r) - 1

            # 子字符串内最多有 1 个 连续 0 区块
            if i > m - 1 or j < 0 or i >= j:
                ans.append(cnt1)
                continue

            firstLen = blockRight[i] - max(blockLeft[i], l) + 1 # 子字符串的第一个连续 0 区块的实际长度

            lastLen = min(blockRight[j], r) - blockLeft[j] + 1 # 子字符串的最后一个连续 0 区块的实际长度

            # 子字符串内恰好有 2 个连续 0 区块
            if i + 1 == j:
                bestGain = firstLen + lastLen
                ans.append(cnt1 + bestGain)
                continue

            val1 = firstLen + zeroBlocks[i + 1]

            val2 = zeroBlocks[j - 1] + lastLen

            val3 = seg.query(i + 1, j - 2)

            bestGain = max(val1, val2, val3)

            ans.append(cnt1 + bestGain)

        return ans
```

```C++
class SegmentTree {
private:
    int n;
    vector<int> arr;
    vector<int> seg;

    void build(int p, int l, int r) {
        if (l == r) {
            seg[p] = arr[l];
            return;
        }

        int mid = (l + r) >> 1;
        build(p << 1, l, mid);
        build(p << 1 | 1, mid + 1, r);
        seg[p] = max(seg[p << 1], seg[p << 1 | 1]);
    }

    int _query(int p, int l, int r, int L, int R) {
        if (L <= l && r <= R) {
            return seg[p];
        }

        int mid = (l + r) >> 1;
        int res = 0;
        if (L <= mid) {
            res = max(res, _query(p << 1, l, mid, L, R));
        }
        if (R > mid) {
            res = max(res, _query(p << 1 | 1, mid + 1, r, L, R));
        }

        return res;
    }

public:
    SegmentTree(const vector<int>& arr) : arr(arr) {
        n = arr.size();
        seg.resize(n << 2, 0);
        build(1, 0, n - 1);
    }

    int query(int L, int R) {
        if (L > R) {
            return 0;
        }

        return _query(1, 0, n - 1, L, R);
    }
};

class Solution {
public:
    vector<int> maxActiveSectionsAfterTrade(string s, vector<vector<int>>& queries) {
        int n = s.length();
        int cnt1 = count(s.begin(), s.end(), '1');

        vector<int> zeroBlocks;
        vector<int> blockLeft;
        vector<int> blockRight;

        int i = 0;
        while (i < n) {
            int st = i;
            while (i < n && s[i] == s[st]) {
                i += 1;
            }
            if (s[st] == '0') {
                zeroBlocks.push_back(i - st);
                blockLeft.push_back(st);
                blockRight.push_back(i - 1);
            }
        }

        int m = zeroBlocks.size();
        if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
            return vector<int>(queries.size(), cnt1);
        }

        vector<int> tmpSum(m - 1);
        for (int i = 0; i < m - 1; i++) {
            tmpSum[i] = zeroBlocks[i] + zeroBlocks[i + 1];
        }
        SegmentTree seg(tmpSum);
        vector<int> ans;

        for (const auto& q : queries) {
            int l = q[0], r = q[1];
            int i = lower_bound(blockRight.begin(), blockRight.end(), l) - blockRight.begin();
            int j = upper_bound(blockLeft.begin(), blockLeft.end(), r) - blockLeft.begin() - 1;

            // 子字符串内最多有 1 个 连续 0 区块
            if (i > m - 1 || j < 0 || i >= j) {
                ans.push_back(cnt1);
                continue;
            }
            int firstLen = blockRight[i] - max(blockLeft[i], l) + 1; // 子字符串的第一个连续 0 区块的实际长度
            int lastLen = min(blockRight[j], r) - blockLeft[j] + 1; // 子字符串的最后一个连续 0 区块的实际长度
            // 子字符串内恰好有 2 个连续 0 区块
            if (i + 1 == j) {
                int bestGain = firstLen + lastLen;
                ans.push_back(cnt1 + bestGain);
                continue;
            }

            int val1 = firstLen + zeroBlocks[i + 1];
            int val2 = zeroBlocks[j - 1] + lastLen;
            int val3 = seg.query(i + 1, j - 2);
            int bestGain = max({val1, val2, val3});
            ans.push_back(cnt1 + bestGain);
        }

        return ans;
    }
};
```

```Java
class SegmentTree {
    private int n;
    private int[] arr;
    private int[] seg;

    private void build(int p, int l, int r) {
        if (l == r) {
            seg[p] = arr[l];
            return;
        }

        int mid = (l + r) >> 1;
        build(p << 1, l, mid);
        build(p << 1 | 1, mid + 1, r);
        seg[p] = Math.max(seg[p << 1], seg[p << 1 | 1]);
    }

    private int _query(int p, int l, int r, int L, int R) {
        if (L <= l && r <= R) {
            return seg[p];
        }

        int mid = (l + r) >> 1;
        int res = 0;
        if (L <= mid) {
            res = Math.max(res, _query(p << 1, l, mid, L, R));
        }
        if (R > mid) {
            res = Math.max(res, _query(p << 1 | 1, mid + 1, r, L, R));
        }

        return res;
    }

    public SegmentTree(int[] arr) {
        this.arr = arr;
        this.n = arr.length;
        this.seg = new int[n << 2];
        build(1, 0, n - 1);
    }

    public int query(int L, int R) {
        if (L > R) {
            return 0;
        }

        return _query(1, 0, n - 1, L, R);
    }
}

class Solution {
    public List<Integer> maxActiveSectionsAfterTrade(String s, int[][] queries) {
        int n = s.length();
        int cnt1 = 0;
        for (char c : s.toCharArray()) {
            if (c == '1') {
                cnt1++;
            }
        }

        List<Integer> zeroBlocks = new ArrayList<>();
        List<Integer> blockLeft = new ArrayList<>();
        List<Integer> blockRight = new ArrayList<>();

        int i = 0;
        while (i < n) {
            int st = i;
            while (i < n && s.charAt(i) == s.charAt(st)) {
                i += 1;
            }
            if (s.charAt(st) == '0') {
                zeroBlocks.add(i - st);
                blockLeft.add(st);
                blockRight.add(i - 1);
            }
        }

        int m = zeroBlocks.size();
        if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
            List<Integer> result = new ArrayList<>();
            for (int q = 0; q < queries.length; q++) {
                result.add(cnt1);
            }
            return result;
        }

        int[] tmpSum = new int[m - 1];
        for (int k = 0; k < m - 1; k++) {
            tmpSum[k] = zeroBlocks.get(k) + zeroBlocks.get(k + 1);
        }
        SegmentTree seg = new SegmentTree(tmpSum);
        List<Integer> ans = new ArrayList<>();

        for (int[] q : queries) {
            int l = q[0], r = q[1];
            int idx = lowerBound(blockRight, l);
            int jdx = upperBound(blockLeft, r) - 1;

            // 子字符串内最多有 1 个 连续 0 区块
            if (idx > m - 1 || jdx < 0 || idx >= jdx) {
                ans.add(cnt1);
                continue;
            }
            int firstLen = blockRight.get(idx) - Math.max(blockLeft.get(idx), l) + 1; // 子字符串的第一个连续 0 区块的实际长度
            int lastLen = Math.min(blockRight.get(jdx), r) - blockLeft.get(jdx) + 1; // 子字符串的最后一个连续 0 区块的实际长度
            // 子字符串内恰好有 2 个连续 0 区块
            if (idx + 1 == jdx) {
                int bestGain = firstLen + lastLen;
                ans.add(cnt1 + bestGain);
                continue;
            }

            int val1 = firstLen + zeroBlocks.get(idx + 1);
            int val2 = zeroBlocks.get(jdx - 1) + lastLen;
            int val3 = seg.query(idx + 1, jdx - 2);
            int bestGain = Math.max(Math.max(val1, val2), val3);
            ans.add(cnt1 + bestGain);
        }

        return ans;
    }

    private int lowerBound(List<Integer> list, int target) {
        int left = 0, right = list.size();
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list.get(mid) < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int upperBound(List<Integer> list, int target) {
        int left = 0, right = list.size();
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list.get(mid) <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```CSharp
public class SegmentTree {
    private int n;
    private int[] arr;
    private int[] seg;

    private void Build(int p, int l, int r) {
        if (l == r) {
            seg[p] = arr[l];
            return;
        }

        int mid = (l + r) >> 1;
        Build(p << 1, l, mid);
        Build(p << 1 | 1, mid + 1, r);
        seg[p] = Math.Max(seg[p << 1], seg[p << 1 | 1]);
    }

    private int QueryInternal(int p, int l, int r, int L, int R) {
        if (L <= l && r <= R) {
            return seg[p];
        }

        int mid = (l + r) >> 1;
        int res = 0;
        if (L <= mid) {
            res = Math.Max(res, QueryInternal(p << 1, l, mid, L, R));
        }
        if (R > mid) {
            res = Math.Max(res, QueryInternal(p << 1 | 1, mid + 1, r, L, R));
        }

        return res;
    }

    public SegmentTree(int[] arr) {
        this.arr = arr;
        this.n = arr.Length;
        this.seg = new int[n << 2];
        Build(1, 0, n - 1);
    }

    public int Query(int L, int R) {
        if (L > R) {
            return 0;
        }

        return QueryInternal(1, 0, n - 1, L, R);
    }
}

public class Solution {
    public List<int> MaxActiveSectionsAfterTrade(string s, int[][] queries) {
        int n = s.Length;
        int cnt1 = s.Count(c => c == '1');

        List<int> zeroBlocks = new List<int>();
        List<int> blockLeft = new List<int>();
        List<int> blockRight = new List<int>();

        int i = 0;
        while (i < n) {
            int st = i;
            while (i < n && s[i] == s[st]) {
                i += 1;
            }
            if (s[st] == '0') {
                zeroBlocks.Add(i - st);
                blockLeft.Add(st);
                blockRight.Add(i - 1);
            }
        }

        int m = zeroBlocks.Count;
        if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
            return Enumerable.Repeat(cnt1, queries.Length).ToList();
        }

        int[] tmpSum = new int[m - 1];
        for (int k = 0; k < m - 1; k++) {
            tmpSum[k] = zeroBlocks[k] + zeroBlocks[k + 1];
        }
        SegmentTree seg = new SegmentTree(tmpSum);
        List<int> ans = new List<int>();

        foreach (var q in queries) {
            int l = q[0], r = q[1];
            int idx = LowerBound(blockRight, l);
            int jdx = UpperBound(blockLeft, r) - 1;

            // 子字符串内最多有 1 个 连续 0 区块
            if (idx > m - 1 || jdx < 0 || idx >= jdx) {
                ans.Add(cnt1);
                continue;
            }
            int firstLen = blockRight[idx] - Math.Max(blockLeft[idx], l) + 1; // 子字符串的第一个连续 0 区块的实际长度
            int lastLen = Math.Min(blockRight[jdx], r) - blockLeft[jdx] + 1; // 子字符串的最后一个连续 0 区块的实际长度
            int bestGain;
            // 子字符串内恰好有 2 个连续 0 区块
            if (idx + 1 == jdx) {
                bestGain = firstLen + lastLen;
            } else {
                int val1 = firstLen + zeroBlocks[idx + 1];
                int val2 = zeroBlocks[jdx - 1] + lastLen;
                int val3 = seg.Query(idx + 1, jdx - 2);
                bestGain = Math.Max(Math.Max(val1, val2), val3);
            }
            ans.Add(cnt1 + bestGain);
        }

        return ans;
    }

    private int LowerBound(List<int> list, int target) {
        int left = 0, right = list.Count;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int UpperBound(List<int> list, int target) {
        int left = 0, right = list.Count;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```Go
type SegmentTree struct {
    n   int
    arr []int
    seg []int
}

func NewSegmentTree(arr []int) *SegmentTree {
    st := &SegmentTree{
        arr: arr,
        n:   len(arr),
        seg: make([]int, len(arr)*4),
    }
    st.build(1, 0, st.n-1)

    return st
}

func (st *SegmentTree) build(p, l, r int) {
    if l == r {
        st.seg[p] = st.arr[l]
        return
    }

    mid := (l + r) >> 1
    st.build(p<<1, l, mid)
    st.build(p<<1|1, mid+1, r)

    st.seg[p] = max(
        st.seg[p<<1],
        st.seg[p<<1|1],
    )
}

func (st *SegmentTree) queryInternal(p, l, r, L, R int) int {
    if L <= l && r <= R {
        return st.seg[p]
    }

    mid := (l + r) >> 1
    res := 0
    if L <= mid {
        res = max(res, st.queryInternal(p<<1, l, mid, L, R))
    }
    if R > mid {
        res = max(res, st.queryInternal(p<<1|1, mid+1, r, L, R))
    }

    return res
}

func (st *SegmentTree) Query(L, R int) int {
    if L > R {
        return 0
    }
    return st.queryInternal(1, 0, st.n-1, L, R)
}

func maxActiveSectionsAfterTrade(s string, queries [][]int) []int {
    n := len(s)
    cnt1 := 0
    for _, c := range s {
        if c == '1' {
            cnt1++
        }
    }

    var zeroBlocks []int
    var blockLeft []int
    var blockRight []int

    i := 0
    for i < n {
        st := i
        for i < n && s[i] == s[st] {
            i++
        }
        if s[st] == '0' {
            zeroBlocks = append(zeroBlocks, i-st)
            blockLeft = append(blockLeft, st)
            blockRight = append(blockRight, i-1)
        }
    }

    m := len(zeroBlocks)
    if m < 2 { // 连续 0 区块少于 2 段，直接返回答案
        ans := make([]int, len(queries))
        for i := range ans {
            ans[i] = cnt1
        }
        return ans
    }

    tmpSum := make([]int, m-1)
    for i := 0; i < m-1; i++ {
        tmpSum[i] = zeroBlocks[i] + zeroBlocks[i+1]
    }
    seg := NewSegmentTree(tmpSum)
    ans := make([]int, len(queries))

    for qIdx, q := range queries {
        l, r := q[0], q[1]
        i := sort.Search(len(blockRight), func(idx int) bool { return blockRight[idx] >= l })
        j := sort.Search(len(blockLeft), func(idx int) bool { return blockLeft[idx] > r }) - 1
        // 子字符串内最多有 1 个 连续 0 区块
        if i > m-1 || j < 0 || i >= j {
            ans[qIdx] = cnt1
            continue
        }

        firstLen := blockRight[i] - max(blockLeft[i], l) + 1 // 子字符串的第一个连续 0 区块的实际长度
        lastLen := min(blockRight[j], r) - blockLeft[j] + 1 // 子字符串的最后一个连续 0 区块的实际长度
        // 子字符串内恰好有 2 个连续 0 区块
        if i+1 == j {
            bestGain := firstLen + lastLen
            ans[qIdx] = cnt1 + bestGain
            continue
        }

        val1 := firstLen + zeroBlocks[i+1]
        val2 := zeroBlocks[j-1] + lastLen
        val3 := seg.Query(i+1, j-2)
        bestGain := max(val1, max(val2, val3))

        ans[qIdx] = cnt1 + bestGain
    }

    return ans
}
```

```C
typedef struct {
    int n;
    int* arr;
    int* seg;
} SegmentTree;

void build(SegmentTree* st, int p, int l, int r) {
    if (l == r) {
        st->seg[p] = st->arr[l];
        return;
    }

    int mid = (l + r) >> 1;
    build(st, p << 1, l, mid);
    build(st, (p << 1) | 1, mid + 1, r);

    st->seg[p] = st->seg[p << 1] > st->seg[(p << 1) | 1] ?
                 st->seg[p << 1] : st->seg[(p << 1) | 1];
}

SegmentTree* createSegmentTree(int* arr, int size) {
    SegmentTree* st = (SegmentTree*)malloc(sizeof(SegmentTree));
    st->arr = arr;
    st->n = size;
    st->seg = (int*)calloc(size * 4, sizeof(int));
    build(st, 1, 0, size - 1);

    return st;
}

int queryInternal(SegmentTree* st, int p, int l, int r, int L, int R) {
    if (L <= l && r <= R) {
        return st->seg[p];
    }

    int mid = (l + r) >> 1;
    int res = 0;
    if (L <= mid) {
        int temp = queryInternal(st, p << 1, l, mid, L, R);
        res = res > temp ? res : temp;
    }
    if (R > mid) {
        int temp = queryInternal(st, (p << 1) | 1, mid + 1, r, L, R);
        res = res > temp ? res : temp;
    }

    return res;
}

int query(SegmentTree* st, int L, int R) {
    if (L > R) {
        return 0;
    }
    return queryInternal(st, 1, 0, st->n - 1, L, R);
}

void freeSegmentTree(SegmentTree* st) {
    free(st->seg);
    free(st);
}

int lowerBound(int* arr, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

int upperBound(int* arr, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] <= target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

int* maxActiveSectionsAfterTrade(char* s, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int n = strlen(s);
    int cnt1 = 0;
    for (int i = 0; i < n; i++) {
        if (s[i] == '1') cnt1++;
    }

    int* zeroBlocks = (int*)malloc(n * sizeof(int));
    int* blockLeft = (int*)malloc(n * sizeof(int));
    int* blockRight = (int*)malloc(n * sizeof(int));
    int m = 0;

    int i = 0;
    while (i < n) {
        int st = i;
        while (i < n && s[i] == s[st]) {
            i++;
        }
        if (s[st] == '0') {
            zeroBlocks[m] = i - st;
            blockLeft[m] = st;
            blockRight[m] = i - 1;
            m++;
        }
    }

    int* ans = (int*)malloc(queriesSize * sizeof(int));
    *returnSize = queriesSize;

    if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
        for (int i = 0; i < queriesSize; i++) {
            ans[i] = cnt1;
        }
        free(zeroBlocks);
        free(blockLeft);
        free(blockRight);
        return ans;
    }

    int* tmpSum = (int*)malloc((m - 1) * sizeof(int));
    for (int i = 0; i < m - 1; i++) {
        tmpSum[i] = zeroBlocks[i] + zeroBlocks[i + 1];
    }
    SegmentTree* seg = createSegmentTree(tmpSum, m - 1);
    for (int q = 0; q < queriesSize; q++) {
        int l = queries[q][0], r = queries[q][1];
        int leftIdx = lowerBound(blockRight, m, l);
        int rightIdx = upperBound(blockLeft, m, r) - 1;

        // 子字符串内最多有 1 个 连续 0 区块
        if (leftIdx > m - 1 || rightIdx < 0 || leftIdx >= rightIdx) {
            ans[q] = cnt1;
            continue;
        }

        int maxLeft = blockLeft[leftIdx] > l ? blockLeft[leftIdx] : l;
        int firstLen = blockRight[leftIdx] - maxLeft + 1; // 子字符串的第一个连续 0 区块的实际长度
        int minRight = blockRight[rightIdx] < r ? blockRight[rightIdx] : r;
        int lastLen = minRight - blockLeft[rightIdx] + 1; // 子字符串的最后一个连续 0 区块的实际长度

        // 子字符串内恰好有 2 个连续 0 区块
        if (leftIdx + 1 == rightIdx) {
            int bestGain = firstLen + lastLen;
            ans[q] = cnt1 + bestGain;
            continue;
        }

        int val1 = firstLen + zeroBlocks[leftIdx + 1];
        int val2 = zeroBlocks[rightIdx - 1] + lastLen;
        int val3 = query(seg, leftIdx + 1, rightIdx - 2);
        int bestGain = val1 > val2 ? val1 : val2;
        bestGain = bestGain > val3 ? bestGain : val3;

        ans[q] = cnt1 + bestGain;
    }

    free(zeroBlocks);
    free(blockLeft);
    free(blockRight);
    free(tmpSum);
    freeSegmentTree(seg);

    return ans;
}
```

```JavaScript
class SegmentTree {
    constructor(arr) {
        this.arr = arr;
        this.n = arr.length;
        this.seg = new Array(this.n << 2).fill(0);
        this.build(1, 0, this.n - 1);
    }

    build(p, l, r) {
        if (l === r) {
            this.seg[p] = this.arr[l];
            return;
        }

        const mid = (l + r) >> 1;
        this.build(p << 1, l, mid);
        this.build((p << 1) | 1, mid + 1, r);
        this.seg[p] = Math.max(this.seg[p << 1], this.seg[(p << 1) | 1]);
    }

    _query(p, l, r, L, R) {
        if (L <= l && r <= R) {
            return this.seg[p];
        }

        const mid = (l + r) >> 1;
        let res = 0;
        if (L <= mid) {
            res = Math.max(res, this._query(p << 1, l, mid, L, R));
        }
        if (R > mid) {
            res = Math.max(res, this._query((p << 1) | 1, mid + 1, r, L, R));
        }

        return res;
    }

    query(L, R) {
        if (L > R) {
            return 0;
        }

        return this._query(1, 0, this.n - 1, L, R);
    }
}

function lowerBound(list, target) {
    let left = 0, right = list.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (list[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

function upperBound(list, target) {
    let left = 0, right = list.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (list[mid] <= target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

var maxActiveSectionsAfterTrade = function(s, queries) {
    const n = s.length;
    let cnt1 = 0;
    for (const c of s) {
        if (c === '1') {
            cnt1++;
        }
    }

    const zeroBlocks = [];
    const blockLeft = [];
    const blockRight = [];

    let i = 0;
    while (i < n) {
        const st = i;
        while (i < n && s[i] === s[st]) {
            i += 1;
        }
        if (s[st] === '0') {
            zeroBlocks.push(i - st);
            blockLeft.push(st);
            blockRight.push(i - 1);
        }
    }

    const m = zeroBlocks.length;
    if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
        return new Array(queries.length).fill(cnt1);
    }

    const tmpSum = new Array(m - 1);
    for (let k = 0; k < m - 1; k++) {
        tmpSum[k] = zeroBlocks[k] + zeroBlocks[k + 1];
    }
    const seg = new SegmentTree(tmpSum);
    const ans = [];

    for (const q of queries) {
        const l = q[0], r = q[1];
        const idx = lowerBound(blockRight, l);
        const jdx = upperBound(blockLeft, r) - 1;

        // 子字符串内最多有 1 个 连续 0 区块
        if (idx > m - 1 || jdx < 0 || idx >= jdx) {
            ans.push(cnt1);
            continue;
        }
        const firstLen = blockRight[idx] - Math.max(blockLeft[idx], l) + 1; // 子字符串的第一个连续 0 区块的实际长度
        const lastLen = Math.min(blockRight[jdx], r) - blockLeft[jdx] + 1; // 子字符串的最后一个连续 0 区块的实际长度

        let bestGain;
        // 子字符串内恰好有 2 个连续 0 区块
        if (idx + 1 === jdx) {
            bestGain = firstLen + lastLen;
        } else {
            const val1 = firstLen + zeroBlocks[idx + 1];
            const val2 = zeroBlocks[jdx - 1] + lastLen;
            const val3 = seg.query(idx + 1, jdx - 2);
            bestGain = Math.max(val1, val2, val3);
        }
        ans.push(cnt1 + bestGain);
    }

    return ans;
};
```

```TypeScript
class SegmentTree {
    private n: number;
    private arr: number[];
    private seg: number[];

    constructor(arr: number[]) {
        this.arr = arr;
        this.n = arr.length;
        this.seg = new Array(this.n << 2).fill(0);
        this.build(1, 0, this.n - 1);
    }

    private build(p: number, l: number, r: number): void {
        if (l === r) {
            this.seg[p] = this.arr[l];
            return;
        }

        const mid = (l + r) >> 1;
        this.build(p << 1, l, mid);
        this.build((p << 1) | 1, mid + 1, r);
        this.seg[p] = Math.max(this.seg[p << 1], this.seg[(p << 1) | 1]);
    }

    private _query(p: number, l: number, r: number, L: number, R: number): number {
        if (L <= l && r <= R) {
            return this.seg[p];
        }

        const mid = (l + r) >> 1;
        let res = 0;
        if (L <= mid) {
            res = Math.max(res, this._query(p << 1, l, mid, L, R));
        }
        if (R > mid) {
            res = Math.max(res, this._query((p << 1) | 1, mid + 1, r, L, R));
        }

        return res;
    }

    public query(L: number, R: number): number {
        if (L > R) {
            return 0;
        }

        return this._query(1, 0, this.n - 1, L, R);
    }
}

function lowerBound(list: number[], target: number): number {
    let left = 0, right = list.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (list[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

function upperBound(list: number[], target: number): number {
    let left = 0, right = list.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (list[mid] <= target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

var maxActiveSectionsAfterTrade = function(s: string, queries: number[][]): number[] {
    const n = s.length;
    let cnt1 = 0;
    for (const c of s) {
        if (c === '1') {
            cnt1++;
        }
    }

    const zeroBlocks: number[] = [];
    const blockLeft: number[] = [];
    const blockRight: number[] = [];

    let i = 0;
    while (i < n) {
        const st = i;
        while (i < n && s[i] === s[st]) {
            i += 1;
        }
        if (s[st] === '0') {
            zeroBlocks.push(i - st);
            blockLeft.push(st);
            blockRight.push(i - 1);
        }
    }

    const m = zeroBlocks.length;
    if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
        return new Array(queries.length).fill(cnt1);
    }

    const tmpSum: number[] = new Array(m - 1);
    for (let k = 0; k < m - 1; k++) {
        tmpSum[k] = zeroBlocks[k] + zeroBlocks[k + 1];
    }
    const seg = new SegmentTree(tmpSum);
    const ans: number[] = [];

    for (const q of queries) {
        const l = q[0], r = q[1];
        const idx = lowerBound(blockRight, l);
        const jdx = upperBound(blockLeft, r) - 1;

        // 子字符串内最多有 1 个 连续 0 区块
        if (idx > m - 1 || jdx < 0 || idx >= jdx) {
            ans.push(cnt1);
            continue;
        }
        const firstLen = blockRight[idx] - Math.max(blockLeft[idx], l) + 1; // 子字符串的第一个连续 0 区块的实际长度
        const lastLen = Math.min(blockRight[jdx], r) - blockLeft[jdx] + 1; // 子字符串的最后一个连续 0 区块的实际长度

        let bestGain: number;
        // 子字符串内恰好有 2 个连续 0 区块
        if (idx + 1 === jdx) {
            bestGain = firstLen + lastLen;
        } else {
            const val1 = firstLen + zeroBlocks[idx + 1];
            const val2 = zeroBlocks[jdx - 1] + lastLen;
            const val3 = seg.query(idx + 1, jdx - 2);
            bestGain = Math.max(val1, val2, val3);
        }
        ans.push(cnt1 + bestGain);
    }

    return ans;
};
```

```Rust
use std::cmp::{max, min};

struct SegmentTree {
    n: usize,
    arr: Vec<i32>,
    seg: Vec<i32>,
}

impl SegmentTree {
    fn new(arr: Vec<i32>) -> Self {
        let n = arr.len();
        let seg = vec![0; n << 2];
        let mut st = SegmentTree { n, arr, seg };
        st.build(1, 0, n - 1);
        st
    }

    fn build(&mut self, p: usize, l: usize, r: usize) {
        if l == r {
            self.seg[p] = self.arr[l];
            return;
        }

        let mid = (l + r) >> 1;
        self.build(p << 1, l, mid);
        self.build((p << 1) | 1, mid + 1, r);
        self.seg[p] = max(self.seg[p << 1], self.seg[(p << 1) | 1]);
    }

    fn query_internal(&self, p: usize, l: usize, r: usize, L: usize, R: usize) -> i32 {
        if L <= l && r <= R {
            return self.seg[p];
        }

        let mid = (l + r) >> 1;
        let mut res = 0;
        if L <= mid {
            res = max(res, self.query_internal(p << 1, l, mid, L, R));
        }
        if R > mid {
            res = max(res, self.query_internal((p << 1) | 1, mid + 1, r, L, R));
        }

        res
    }

    fn query(&self, L: usize, R: usize) -> i32 {
        if L > R {
            return 0;
        }

        self.query_internal(1, 0, self.n - 1, L, R)
    }
}

fn lower_bound(list: &[usize], target: usize) -> usize {
    let mut left = 0;
    let mut right = list.len();
    while left < right {
        let mid = left + ((right - left) >> 1);
        if list[mid] < target {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    left
}

fn upper_bound(list: &[usize], target: usize) -> usize {
    let mut left = 0;
    let mut right = list.len();
    while left < right {
        let mid = left + ((right - left) >> 1);
        if list[mid] <= target {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    left
}

impl Solution {
    pub fn max_active_sections_after_trade(s: String, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let n = s.len();
        let s_chars: Vec<char> = s.chars().collect();
        let cnt1 = s_chars.iter().filter(|&&c| c == '1').count() as i32;

        let mut zero_blocks: Vec<i32> = Vec::new();
        let mut block_left: Vec<usize> = Vec::new();
        let mut block_right: Vec<usize> = Vec::new();

        let mut i = 0;
        while i < n {
            let st = i;
            while i < n && s_chars[i] == s_chars[st] {
                i += 1;
            }
            if s_chars[st] == '0' {
                zero_blocks.push((i - st) as i32);
                block_left.push(st);
                block_right.push(i - 1);
            }
        }

        let m = zero_blocks.len();
        if m < 2 {  // 连续 0 区块少于 2 段，直接返回答案
            return vec![cnt1; queries.len()];
        }

        let mut tmp_sum: Vec<i32> = vec![0; m - 1];
        for k in 0..m - 1 {
            tmp_sum[k] = zero_blocks[k] + zero_blocks[k + 1];
        }
        let seg = SegmentTree::new(tmp_sum);
        let mut ans: Vec<i32> = Vec::new();

        for q in queries {
            let l = q[0] as usize;
            let r = q[1] as usize;
            let idx = lower_bound(&block_right, l);
            let jdx = upper_bound(&block_left, r).wrapping_sub(1);

            // 子字符串内最多有 1 个 连续 0 区块
            if idx > m - 1 || jdx >= m || idx >= jdx {
                ans.push(cnt1);
                continue;
            }
            let first_len = (block_right[idx] - max(block_left[idx], l) + 1) as i32; // 子字符串的第一个连续 0 区块的实际长度
            let last_len = (min(block_right[jdx], r) - block_left[jdx] + 1) as i32; // 子字符串的最后一个连续 0 区块的实际长度
            let best_gain;
            // 子字符串内恰好有 2 个连续 0 区块
            if idx + 1 == jdx {
                best_gain = first_len + last_len;
            } else {
                let val1 = first_len + zero_blocks[idx + 1];
                let val2 = zero_blocks[jdx - 1] + last_len;
                let val3 = seg.query(idx + 1, jdx - 2);
                best_gain = max(max(val1, val2), val3);
            }
            ans.push(cnt1 + best_gain);
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+q\log n)$，其中 $n$ 为字符串 $s$ 的长度。包括建立线段树在内的预处理部分的时间复杂度为 $O(n)$。对于每个查询：
    - 两次二分查找的时间复杂度为 $O(\log n)$；
    - 一次线段树区间最大值查询的时间复杂度为 $O(\log n)$。
  因此总时间复杂度为：
  $$O(n+q\log n)$$
- 空间复杂度：$O(n)$。

#### 方法二：二分查找 + ST表

**思路及解法**

方法一中，我们使用线段树查询数组 $tmpSum$ 的区间最大值。

注意到本题中数组 $tmpSum$ 在预处理完成后不会发生修改，因此也可以使用 $ST$ 表(Sparse $Table,$ 稀疏表)来解决静态RMQ（$Range Maximum Query$，区间最值查询）问题。对 $ST$ 表的原理和相关知识感兴趣的读者，可以参考[这个链接](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fds%2Fsparse-table%2F)。

**代码**

```Python
class SparseTable:
    def __init__(self, data: list):
        self.st = [list(data)]
        i, N = 1, len(self.st[0])
        while 2 * i <= N+1:
            pre = self.st[-1]
            self.st.append([max(pre[j], pre[j + i]) for j in range(N - 2 * i + 1)])
            i <<= 1

    def query(self, begin: int, end: int):
        if begin > end:
            return 0
        lg = (end - begin+1).bit_length() - 1
        return max(self.st[lg][begin], self.st[lg][end - (1 << lg) + 1])

class Solution:
    def maxActiveSectionsAfterTrade(self, s: str, queries: List[List[int]]) -> List[int]:
        n = len(s)
        cnt1 = s.count('1')

        zeroBlocks = []
        blockLeft = []
        blockRight = []

        i = 0
        while i < n:
            st = i

            while i < n and s[i] == s[st]:
                i += 1

            if s[st] == '0':
                zeroBlocks.append(i - st)
                blockLeft.append(st)
                blockRight.append(i - 1)

        m = len(zeroBlocks)
        if m < 2:  # 连续 0 区块少于 2 段，直接返回答案
            return [cnt1] * len(queries)

        tmpSum = [zeroBlocks[i] + zeroBlocks[i + 1] for i in range(m - 1)]
        st = SparseTable(tmpSum)
        ans = []

        for l, r in queries:
            i = bisect_left(blockRight, l)
            j = bisect_right(blockLeft, r) - 1

            # 子字符串内最多有 1 个 连续 0 区块
            if i > m - 1 or j < 0 or i >= j:
                ans.append(cnt1)
                continue

            firstLen = blockRight[i] - max(blockLeft[i], l) + 1 # 子字符串的第一个连续 0 区块的实际长度

            lastLen = min(blockRight[j], r) - blockLeft[j] + 1 # 子字符串的最后一个连续 0 区块的实际长度

            # 子字符串内恰好有 2 个连续 0 区块
            if i + 1 == j:
                bestGain = firstLen + lastLen
                ans.append(cnt1 + bestGain)
                continue

            val1 = firstLen + zeroBlocks[i + 1]

            val2 = zeroBlocks[j - 1] + lastLen

            val3 = st.query(i + 1, j - 2)

            bestGain = max(val1, val2, val3)

            ans.append(cnt1 + bestGain)

        return ans
```

```C++
class SparseTable {
private:
    vector<vector<int>> st;

public:
    SparseTable(const vector<int>& data) {
        st.push_back(data);
        int i = 1, N = st[0].size();
        while (2 * i <= N + 1) {
            const auto& pre = st.back();
            vector<int> cur;
            for (int j = 0; j < N - 2 * i + 1; j++) {
                cur.push_back(max(pre[j], pre[j + i]));
            }
            st.push_back(cur);
            i <<= 1;
        }
    }

    int query(int begin, int end) {
        if (begin > end) {
            return 0;
        }
        int len = end - begin + 1;
        int lg = 0;
        while ((1 << (lg + 1)) <= len) {
            lg++;
        }
        return max(st[lg][begin], st[lg][end - (1 << lg) + 1]);
    }
};

class Solution {
public:
    vector<int> maxActiveSectionsAfterTrade(string s, vector<vector<int>>& queries) {
        int n = s.length();
        int cnt1 = count(s.begin(), s.end(), '1');

        vector<int> zeroBlocks;
        vector<int> blockLeft;
        vector<int> blockRight;

        int i = 0;
        while (i < n) {
            int st = i;
            while (i < n && s[i] == s[st]) {
                i += 1;
            }
            if (s[st] == '0') {
                zeroBlocks.push_back(i - st);
                blockLeft.push_back(st);
                blockRight.push_back(i - 1);
            }
        }

        int m = zeroBlocks.size();
        if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
            return vector<int>(queries.size(), cnt1);
        }
        vector<int> tmpSum(m - 1);
        for (int i = 0; i < m - 1; i++) {
            tmpSum[i] = zeroBlocks[i] + zeroBlocks[i + 1];
        }
        SparseTable st(tmpSum);
        vector<int> ans;

        for (const auto& q : queries) {
            int l = q[0], r = q[1];
            int i = lower_bound(blockRight.begin(), blockRight.end(), l) - blockRight.begin();
            int j = upper_bound(blockLeft.begin(), blockLeft.end(), r) - blockLeft.begin() - 1;

            // 子字符串内最多有 1 个 连续 0 区块
            if (i > m - 1 || j < 0 || i >= j) {
                ans.push_back(cnt1);
                continue;
            }

            int firstLen = blockRight[i] - max(blockLeft[i], l) + 1; // 子字符串的第一个连续 0 区块的实际长度
            int lastLen = min(blockRight[j], r) - blockLeft[j] + 1; // 子字符串的最后一个连续 0 区块的实际长度
            // 子字符串内恰好有 2 个连续 0 区块
            if (i + 1 == j) {
                int bestGain = firstLen + lastLen;
                ans.push_back(cnt1 + bestGain);
                continue;
            }

            int val1 = firstLen + zeroBlocks[i + 1];
            int val2 = zeroBlocks[j - 1] + lastLen;
            int val3 = st.query(i + 1, j - 2);
            int bestGain = max({val1, val2, val3});
            ans.push_back(cnt1 + bestGain);
        }

        return ans;
    }
};
```

```Java
class SparseTable {
    private List<List<Integer>> st;

    public SparseTable(List<Integer> data) {
        st = new ArrayList<>();
        st.add(new ArrayList<>(data));
        int i = 1, N = st.get(0).size();
        while (2 * i <= N + 1) {
            List<Integer> pre = st.get(st.size() - 1);
            List<Integer> cur = new ArrayList<>();
            for (int j = 0; j < N - 2 * i + 1; j++) {
                cur.add(Math.max(pre.get(j), pre.get(j + i)));
            }
            st.add(cur);
            i <<= 1;
        }
    }

    public int query(int begin, int end) {
        if (begin > end) {
            return 0;
        }
        int len = end - begin + 1;
        int lg = 31 - Integer.numberOfLeadingZeros(len);
        return Math.max(st.get(lg).get(begin), st.get(lg).get(end - (1 << lg) + 1));
    }
}

class Solution {
    public List<Integer> maxActiveSectionsAfterTrade(String s, int[][] queries) {
        int n = s.length();
        int cnt1 = 0;
        for (char c : s.toCharArray()) {
            if (c == '1') cnt1++;
        }

        List<Integer> zeroBlocks = new ArrayList<>();
        List<Integer> blockLeft = new ArrayList<>();
        List<Integer> blockRight = new ArrayList<>();

        int i = 0;
        while (i < n) {
            int st = i;

            while (i < n && s.charAt(i) == s.charAt(st)) {
                i += 1;
            }

            if (s.charAt(st) == '0') {
                zeroBlocks.add(i - st);
                blockLeft.add(st);
                blockRight.add(i - 1);
            }
        }

        int m = zeroBlocks.size();
        if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
            List<Integer> result = new ArrayList<>();
            for (int q = 0; q < queries.length; q++) {
                result.add(cnt1);
            }
            return result;
        }

        List<Integer> tmpSum = new ArrayList<>();
        for (int k = 0; k < m - 1; k++) {
            tmpSum.add(zeroBlocks.get(k) + zeroBlocks.get(k + 1));
        }
        SparseTable st = new SparseTable(tmpSum);
        List<Integer> ans = new ArrayList<>();

        for (int[] q : queries) {
            int l = q[0], r = q[1];
            int idx = lowerBound(blockRight, l);
            int jdx = upperBound(blockLeft, r) - 1;

            // 子字符串内最多有 1 个 连续 0 区块
            if (idx > m - 1 || jdx < 0 || idx >= jdx) {
                ans.add(cnt1);
                continue;
            }

            int firstLen = blockRight.get(idx) - Math.max(blockLeft.get(idx), l) + 1; // 子字符串的第一个连续 0 区块的实际长度
            int lastLen = Math.min(blockRight.get(jdx), r) - blockLeft.get(jdx) + 1; // 子字符串的最后一个连续 0 区块的实际长度
            // 子字符串内恰好有 2 个连续 0 区块
            if (idx + 1 == jdx) {
                int bestGain = firstLen + lastLen;
                ans.add(cnt1 + bestGain);
                continue;
            }

            int val1 = firstLen + zeroBlocks.get(idx + 1);
            int val2 = zeroBlocks.get(jdx - 1) + lastLen;
            int val3 = st.query(idx + 1, jdx - 2);
            int bestGain = Math.max(Math.max(val1, val2), val3);
            ans.add(cnt1 + bestGain);
        }

        return ans;
    }

    private int lowerBound(List<Integer> list, int target) {
        int left = 0, right = list.size();
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list.get(mid) < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int upperBound(List<Integer> list, int target) {
        int left = 0, right = list.size();
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list.get(mid) <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```CSharp
public class SparseTable {
    private List<List<int>> st;

    public SparseTable(List<int> data) {
        st = new List<List<int>>();
        st.Add(new List<int>(data));
        int i = 1, N = st[0].Count;
        while (2 * i <= N + 1) {
            List<int> pre = st[st.Count - 1];
            List<int> cur = new List<int>();
            for (int j = 0; j < N - 2 * i + 1; j++) {
                cur.Add(Math.Max(pre[j], pre[j + i]));
            }
            st.Add(cur);
            i <<= 1;
        }
    }

    public int Query(int begin, int end) {
        if (begin > end) {
            return 0;
        }
        int len = end - begin + 1;
        int lg = (int)Math.Log2(len);
        return Math.Max(st[lg][begin], st[lg][end - (1 << lg) + 1]);
    }
}

public class Solution {
    public List<int> MaxActiveSectionsAfterTrade(string s, int[][] queries) {
        int n = s.Length;
        int cnt1 = s.Count(c => c == '1');

        List<int> zeroBlocks = new List<int>();
        List<int> blockLeft = new List<int>();
        List<int> blockRight = new List<int>();

        int i = 0;
        while (i < n) {
            int start = i;
            while (i < n && s[i] == s[start]) {
                i += 1;
            }

            if (s[start] == '0') {
                zeroBlocks.Add(i - start);
                blockLeft.Add(start);
                blockRight.Add(i - 1);
            }
        }

        int m = zeroBlocks.Count;
        if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
            return Enumerable.Repeat(cnt1, queries.Length).ToList();
        }

        List<int> tmpSum = new List<int>();
        for (int k = 0; k < m - 1; k++) {
            tmpSum.Add(zeroBlocks[k] + zeroBlocks[k + 1]);
        }
        SparseTable sparseTable = new SparseTable(tmpSum);
        List<int> ans = new List<int>();

        foreach (var q in queries) {
            int l = q[0], r = q[1];
            int idx = LowerBound(blockRight, l);
            int jdx = UpperBound(blockLeft, r) - 1;

            // 子字符串内最多有 1 个 连续 0 区块
            if (idx > m - 1 || jdx < 0 || idx >= jdx) {
                ans.Add(cnt1);
                continue;
            }

            int firstLen = blockRight[idx] - Math.Max(blockLeft[idx], l) + 1; // 子字符串的第一个连续 0 区块的实际长度
            int lastLen = Math.Min(blockRight[jdx], r) - blockLeft[jdx] + 1; // 子字符串的最后一个连续 0 区块的实际长度
            // 子字符串内恰好有 2 个连续 0 区块
            int bestGain;
            if (idx + 1 == jdx) {
                bestGain = firstLen + lastLen;
            } else {
                int val1 = firstLen + zeroBlocks[idx + 1];
                int val2 = zeroBlocks[jdx - 1] + lastLen;
                int val3 = sparseTable.Query(idx + 1, jdx - 2);
                bestGain = Math.Max(Math.Max(val1, val2), val3);
            }
            ans.Add(cnt1 + bestGain);
        }

        return ans;
    }

    private int LowerBound(List<int> list, int target) {
        int left = 0, right = list.Count;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }

    private int UpperBound(List<int> list, int target) {
        int left = 0, right = list.Count;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list[mid] <= target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```Go
type SparseTable struct {
    st [][]int
}

func NewSparseTable(data []int) *SparseTable {
    st := &SparseTable{}
    st.st = append(st.st, append([]int{}, data...))
    i, N := 1, len(st.st[0])
    for 2*i <= N+1 {
        pre := st.st[len(st.st)-1]
        cur := make([]int, N-2*i+1)
        for j := 0; j < N-2*i+1; j++ {
            cur[j] = max(pre[j], pre[j+i])
        }
        st.st = append(st.st, cur)
        i <<= 1
    }
    return st
}

func (st *SparseTable) Query(begin, end int) int {
    if begin > end {
        return 0
    }
    length := end - begin + 1
    lg := bits.Len(uint(length)) - 1
    return max(st.st[lg][begin], st.st[lg][end-(1<<lg)+1])
}

func maxActiveSectionsAfterTrade(s string, queries [][]int) []int {
    n := len(s)
    cnt1 := 0
    for _, c := range s {
        if c == '1' {
            cnt1++
        }
    }

    zeroBlocks := []int{}
    blockLeft := []int{}
    blockRight := []int{}

    i := 0
    for i < n {
        st := i
        for i < n && s[i] == s[st] {
            i += 1
        }
        if s[st] == '0' {
            zeroBlocks = append(zeroBlocks, i-st)
            blockLeft = append(blockLeft, st)
            blockRight = append(blockRight, i-1)
        }
    }

    m := len(zeroBlocks)
    if m < 2 {  // 连续 0 区块少于 2 段，直接返回答案
        ans := make([]int, len(queries))
        for i := range ans {
            ans[i] = cnt1
        }
        return ans
    }

    tmpSum := make([]int, m-1)
    for i := 0; i < m-1; i++ {
        tmpSum[i] = zeroBlocks[i] + zeroBlocks[i+1]
    }
    st := NewSparseTable(tmpSum)
    ans := []int{}

    for _, q := range queries {
        l, r := q[0], q[1]
        idx := sort.Search(len(blockRight), func(i int) bool {
            return blockRight[i] >= l
        })
        jdx := sort.Search(len(blockLeft), func(i int) bool {
            return blockLeft[i] > r
        }) - 1

        // 子字符串内最多有 1 个 连续 0 区块
        if idx > m-1 || jdx < 0 || idx >= jdx {
            ans = append(ans, cnt1)
            continue
        }

        firstLen := blockRight[idx] - max(blockLeft[idx], l) + 1 // 子字符串的第一个连续 0 区块的实际长度
        lastLen := min(blockRight[jdx], r) - blockLeft[jdx] + 1 // 子字符串的最后一个连续 0 区块的实际长度
        // 子字符串内恰好有 2 个连续 0 区块
        if idx+1 == jdx {
            bestGain := firstLen + lastLen
            ans = append(ans, cnt1+bestGain)
            continue
        }

        val1 := firstLen + zeroBlocks[idx+1]
        val2 := zeroBlocks[jdx-1] + lastLen
        val3 := st.Query(idx+1, jdx-2)
        bestGain := max(max(val1, val2), val3)
        ans = append(ans, cnt1+bestGain)
    }

    return ans
}
```

```C
typedef struct {
    int** st;
    int* sizes;
    int levels;
} SparseTable;

int max(int a, int b) {
    return a > b ? a : b;
}

int min(int a, int b) {
    return a < b ? a : b;
}

SparseTable* createSparseTable(int* data, int n) {
    SparseTable* st = (SparseTable*)malloc(sizeof(SparseTable));
    // 计算需要的层数
    int maxLevel = 0;
    int temp = 1;
    while (temp <= n) {
        maxLevel++;
        temp <<= 1;
    }
    maxLevel++; // 额外一层以确保安全
    st->st = (int**)malloc(maxLevel * sizeof(int*));
    st->sizes = (int*)malloc(maxLevel * sizeof(int));
    st->levels = 0;

    // 第0层
    st->st[0] = (int*)malloc(n * sizeof(int));
    memcpy(st->st[0], data, n * sizeof(int));
    st->sizes[0] = n;
    st->levels = 1;

    int i = 1;
    while (2 * i <= n + 1 && st->levels < maxLevel) {
        int curSize = n - 2 * i + 1;
        if (curSize <= 0) {
            break;
        }
        st->st[st->levels] = (int*)malloc(curSize * sizeof(int));
        for (int j = 0; j < curSize; j++) {
            int a = st->st[st->levels - 1][j];
            int b = st->st[st->levels - 1][j + i];
            st->st[st->levels][j] = max(a, b);
        }
        st->sizes[st->levels] = curSize;
        st->levels++;
        i <<= 1;
    }

    return st;
}

int querySparseTable(SparseTable* st, int begin, int end) {
    if (!st || begin > end) {
        return 0;
    }
    int len = end - begin + 1;
    int lg = 0;
    while ((1 << (lg + 1)) <= len) {
        lg++;
    }
    if (lg >= st->levels) {
        lg = st->levels - 1;
    }
    int a = st->st[lg][begin];
    int b = st->st[lg][end - (1 << lg) + 1];
    return max(a, b);
}

void freeSparseTable(SparseTable* st) {
    if (!st) return;
    for (int i = 0; i < st->levels; i++) {
        free(st->st[i]);
    }
    free(st->st);
    free(st->sizes);
    free(st);
}

int lowerBound(int* list, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (list[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

int upperBound(int* list, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (list[mid] <= target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}



int* maxActiveSectionsAfterTrade(char* s, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int n = strlen(s);
    int cnt1 = 0;
    for (int i = 0; i < n; i++) {
        if (s[i] == '1') {
            cnt1++;
        }
    }

    int maxBlocks = n;
    int* zeroBlocks = (int*)malloc(maxBlocks * sizeof(int));
    int* blockLeft = (int*)malloc(maxBlocks * sizeof(int));
    int* blockRight = (int*)malloc(maxBlocks * sizeof(int));

    int i = 0, m = 0;
    while (i < n) {
        int start = i;
        while (i < n && s[i] == s[start]) {
            i += 1;
        }
        if (s[start] == '0' && m < maxBlocks) {
            zeroBlocks[m] = i - start;
            blockLeft[m] = start;
            blockRight[m] = i - 1;
            m++;
        }
    }

    int* ans = (int*)malloc(queriesSize * sizeof(int));
    *returnSize = queriesSize;

    if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
        for (int i = 0; i < queriesSize; i++) {
            ans[i] = cnt1;
        }
        free(zeroBlocks);
        free(blockLeft);
        free(blockRight);
        return ans;
    }

    int* tmpSum = (int*)malloc((m - 1) * sizeof(int));
    for (int i = 0; i < m - 1; i++) {
        tmpSum[i] = zeroBlocks[i] + zeroBlocks[i + 1];
    }
    SparseTable* sparseTable = createSparseTable(tmpSum, m - 1);
    for (int q = 0; q < queriesSize; q++) {
        int l = queries[q][0], r = queries[q][1];
        int idx = lowerBound(blockRight, m, l);
        int jdx = upperBound(blockLeft, m, r) - 1;

        // 子字符串内最多有 1 个 连续 0 区块
        if (idx > m - 1 || jdx < 0 || idx >= jdx) {
            ans[q] = cnt1;
            continue;
        }

        int firstLen = blockRight[idx] - max(blockLeft[idx], l) + 1; // 子字符串的第一个连续 0 区块的实际长度
        int lastLen = min(blockRight[jdx], r) - blockLeft[jdx] + 1; // 子字符串的最后一个连续 0 区块的实际长度
        // 子字符串内恰好有 2 个连续 0 区块
        if (idx + 1 == jdx) {
            int bestGain = firstLen + lastLen;
            ans[q] = cnt1 + bestGain;
            continue;
        }

        int val1 = firstLen + zeroBlocks[idx + 1];
        int val2 = zeroBlocks[jdx - 1] + lastLen;
        int val3 = querySparseTable(sparseTable, idx + 1, jdx - 2);
        int bestGain = max(max(val1, val2), val3);
        ans[q] = cnt1 + bestGain;
    }

    free(zeroBlocks);
    free(blockLeft);
    free(blockRight);
    free(tmpSum);
    freeSparseTable(sparseTable);

    return ans;
}
```

```JavaScript
class SparseTable {
    constructor(data) {
        this.st = [[...data]];
        let i = 1, N = this.st[0].length;
        while (2 * i <= N + 1) {
            const pre = this.st[this.st.length - 1];
            const cur = [];
            for (let j = 0; j < N - 2 * i + 1; j++) {
                cur.push(Math.max(pre[j], pre[j + i]));
            }
            this.st.push(cur);
            i <<= 1;
        }
    }

    query(begin, end) {
        if (begin > end) {
            return 0;
        }
        const len = end - begin + 1;
        const lg = Math.floor(Math.log2(len));
        return Math.max(this.st[lg][begin], this.st[lg][end - (1 << lg) + 1]);
    }
}

function lowerBound(list, target) {
    let left = 0, right = list.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (list[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

function upperBound(list, target) {
    let left = 0, right = list.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (list[mid] <= target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

var maxActiveSectionsAfterTrade = function(s, queries) {
    const n = s.length;
    let cnt1 = 0;
    for (const c of s) {
        if (c === '1') {
            cnt1++;
        }
    }

    const zeroBlocks = [];
    const blockLeft = [];
    const blockRight = [];

    let i = 0;
    while (i < n) {
        const st = i;
        while (i < n && s[i] === s[st]) {
            i += 1;
        }
        if (s[st] === '0') {
            zeroBlocks.push(i - st);
            blockLeft.push(st);
            blockRight.push(i - 1);
        }
    }

    const m = zeroBlocks.length;
    if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
        return new Array(queries.length).fill(cnt1);
    }
    const tmpSum = [];
    for (let k = 0; k < m - 1; k++) {
        tmpSum.push(zeroBlocks[k] + zeroBlocks[k + 1]);
    }
    const st = new SparseTable(tmpSum);
    const ans = [];

    for (const q of queries) {
        const l = q[0], r = q[1];
        const idx = lowerBound(blockRight, l);
        const jdx = upperBound(blockLeft, r) - 1;

        // 子字符串内最多有 1 个 连续 0 区块
        if (idx > m - 1 || jdx < 0 || idx >= jdx) {
            ans.push(cnt1);
            continue;
        }

        const firstLen = blockRight[idx] - Math.max(blockLeft[idx], l) + 1; // 子字符串的第一个连续 0 区块的实际长度
        const lastLen = Math.min(blockRight[jdx], r) - blockLeft[jdx] + 1; // 子字符串的最后一个连续 0 区块的实际长度
        // 子字符串内恰好有 2 个连续 0 区块
        if (idx + 1 === jdx) {
            const bestGain = firstLen + lastLen;
            ans.push(cnt1 + bestGain);
            continue;
        }

        const val1 = firstLen + zeroBlocks[idx + 1];
        const val2 = zeroBlocks[jdx - 1] + lastLen;
        const val3 = st.query(idx + 1, jdx - 2);
        const bestGain = Math.max(val1, val2, val3);
        ans.push(cnt1 + bestGain);
    }

    return ans;
};
```

```TypeScript
class SparseTable {
    private st: number[][];

    constructor(data: number[]) {
        this.st = [[...data]];
        let i = 1, N = this.st[0].length;
        while (2 * i <= N + 1) {
            const pre = this.st[this.st.length - 1];
            const cur: number[] = [];
            for (let j = 0; j < N - 2 * i + 1; j++) {
                cur.push(Math.max(pre[j], pre[j + i]));
            }
            this.st.push(cur);
            i <<= 1;
        }
    }

    query(begin: number, end: number): number {
        if (begin > end) {
            return 0;
        }
        const len = end - begin + 1;
        const lg = Math.floor(Math.log2(len));
        return Math.max(this.st[lg][begin], this.st[lg][end - (1 << lg) + 1]);
    }
}

function lowerBound(list: number[], target: number): number {
    let left = 0, right = list.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (list[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

function upperBound(list: number[], target: number): number {
    let left = 0, right = list.length;
    while (left < right) {
        const mid = left + ((right - left) >> 1);
        if (list[mid] <= target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

var maxActiveSectionsAfterTrade = function(s: string, queries: number[][]): number[] {
    const n = s.length;
    let cnt1 = 0;
    for (const c of s) {
        if (c === '1') {
            cnt1++;
        }
    }

    const zeroBlocks: number[] = [];
    const blockLeft: number[] = [];
    const blockRight: number[] = [];

    let i = 0;
    while (i < n) {
        const st = i;
        while (i < n && s[i] === s[st]) {
            i += 1;
        }
        if (s[st] === '0') {
            zeroBlocks.push(i - st);
            blockLeft.push(st);
            blockRight.push(i - 1);
        }
    }

    const m = zeroBlocks.length;
    if (m < 2) {  // 连续 0 区块少于 2 段，直接返回答案
        return new Array(queries.length).fill(cnt1);
    }
    const tmpSum: number[] = [];
    for (let k = 0; k < m - 1; k++) {
        tmpSum.push(zeroBlocks[k] + zeroBlocks[k + 1]);
    }
    const st = new SparseTable(tmpSum);
    const ans: number[] = [];

    for (const q of queries) {
        const l = q[0], r = q[1];
        const idx = lowerBound(blockRight, l);
        const jdx = upperBound(blockLeft, r) - 1;

        // 子字符串内最多有 1 个 连续 0 区块
        if (idx > m - 1 || jdx < 0 || idx >= jdx) {
            ans.push(cnt1);
            continue;
        }

        const firstLen = blockRight[idx] - Math.max(blockLeft[idx], l) + 1; // 子字符串的第一个连续 0 区块的实际长度
        const lastLen = Math.min(blockRight[jdx], r) - blockLeft[jdx] + 1; // 子字符串的最后一个连续 0 区块的实际长度
        // 子字符串内恰好有 2 个连续 0 区块
        if (idx + 1 === jdx) {
            const bestGain = firstLen + lastLen;
            ans.push(cnt1 + bestGain);
            continue;
        }

        const val1 = firstLen + zeroBlocks[idx + 1];
        const val2 = zeroBlocks[jdx - 1] + lastLen;
        const val3 = st.query(idx + 1, jdx - 2);
        const bestGain = Math.max(val1, val2, val3);
        ans.push(cnt1 + bestGain);
    }

    return ans;
};
```

```Rust
use std::cmp::{max, min};

struct SparseTable {
    st: Vec<Vec<i32>>,
}

impl SparseTable {
    fn new(data: Vec<i32>) -> Self {
        let mut st = Vec::new();
        st.push(data);
        let mut i = 1;
        let n = st[0].len();
        while 2 * i <= n + 1 {
            let pre = st.last().unwrap();
            let mut cur = Vec::with_capacity(n - 2 * i + 1);
            for j in 0..n - 2 * i + 1 {
                cur.push(max(pre[j], pre[j + i]));
            }
            st.push(cur);
            i <<= 1;
        }
        SparseTable { st }
    }

    fn query(&self, begin: usize, end: usize) -> i32 {
        if begin > end {
            return 0;
        }
        let len = end - begin + 1;
        let lg = (usize::BITS - len.leading_zeros() - 1) as usize;
        max(self.st[lg][begin], self.st[lg][end - (1 << lg) + 1])
    }
}

fn lower_bound(list: &[usize], target: usize) -> usize {
    let mut left = 0;
    let mut right = list.len();
    while left < right {
        let mid = left + (right - left) / 2;
        if list[mid] < target {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    left
}

fn upper_bound(list: &[usize], target: usize) -> usize {
    let mut left = 0;
    let mut right = list.len();
    while left < right {
        let mid = left + (right - left) / 2;
        if list[mid] <= target {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    left
}

impl Solution {
    pub fn max_active_sections_after_trade(s: String, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let n = s.len();
        let s_chars: Vec<char> = s.chars().collect();
        let cnt1 = s_chars.iter().filter(|&&c| c == '1').count() as i32;

        let mut zero_blocks: Vec<i32> = Vec::new();
        let mut block_left: Vec<usize> = Vec::new();
        let mut block_right: Vec<usize> = Vec::new();

        let mut i = 0;
        while i < n {
            let start_pos = i;
            while i < n && s_chars[i] == s_chars[start_pos] {
                i += 1;
            }
            if s_chars[start_pos] == '0' {
                zero_blocks.push((i - start_pos) as i32);
                block_left.push(start_pos);
                block_right.push(i - 1);
            }
        }

        let m = zero_blocks.len();
        if m < 2 {  // 连续 0 区块少于 2 段，直接返回答案
            return vec![cnt1; queries.len()];
        }

        let mut tmp_sum: Vec<i32> = Vec::with_capacity(m - 1);
        for k in 0..m - 1 {
            tmp_sum.push(zero_blocks[k] + zero_blocks[k + 1]);
        }
        let sparse_table = SparseTable::new(tmp_sum);
        let mut ans: Vec<i32> = Vec::new();

        for q in queries {
            let l = q[0] as usize;
            let r = q[1] as usize;
            let idx = lower_bound(&block_right, l);
            let jdx = upper_bound(&block_left, r).wrapping_sub(1);

            // 子字符串内最多有 1 个 连续 0 区块
            if idx > m - 1 || jdx >= m || idx >= jdx {
                ans.push(cnt1);
                continue;
            }

            let first_len = (block_right[idx] - max(block_left[idx], l) + 1) as i32; // 子字符串的第一个连续 0 区块的实际长度
            let last_len = (min(block_right[jdx], r) - block_left[jdx] + 1) as i32; // 子字符串的最后一个连续 0 区块的实际长度
            // 子字符串内恰好有 2 个连续 0 区块
            if idx + 1 == jdx {
                let best_gain = first_len + last_len;
                ans.push(cnt1 + best_gain);
                continue;
            }

            let val1 = first_len + zero_blocks[idx + 1];
            let val2 = zero_blocks[jdx - 1] + last_len;
            let val3 = sparse_table.query(idx + 1, jdx - 2);
            let best_gain = max(max(val1, val2), val3);
            ans.push(cnt1 + best_gain);
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O((n+q)\log n)$，其中 $n$ 为字符串 $s$ 的长度。$ST$ 表预处理的时间复杂度为 $O(n\log n)$。对于每个查询：
    - 两次二分查找的时间复杂度为 $O(\log n)$；
    - 单次 $ST$ 表查询的时间复杂度为 $O(1)$。
- 空间复杂度：$O(n\log n)$。ST 表需要 $O(n\log$ n)的额外空间。

#### 方法三：莫队算法(非本题预期复杂度，选读)

莫队算法仅需使用滑窗的技巧，通过巧妙排列回答询问的顺序，便可以以根号的时间复杂度回答多个静态区间询问。本题作为一道不带修改的区间询问问题，是一个介绍该算法的切入点。注意，本解法的时间复杂度不是本题的预期时间复杂度，因此不保证能够通过本题，在这里仅供读者参考学习。

根号分解的思想在莫队算法中起到了重要的作用。我们需要对字符串 $s$ 进行分块，在本文中，为简单起见，我们将块长定为：

$$B=\sqrt{n}$$

我们已经知道，每个询问的暴力解法时间复杂度为 $O(n)$，其中 $n$ 为子字符串的长度。因此，对于区间长度小于等于块长 $B$ 的询问，我们可以暴力计算出结果，这样做的时间复杂度不超过

$$O(q\sqrt{n})$$

现在，我们仅需要处理那些询问区间长度大于 $B$ 的询问。显然，这些询问的左右端点不会在相同块内。

我们将剩余的询问按照**左端点**所在的块分组，此后，每组内部按照询问的**右端点**升序排序。

> 由于我们可以按任意顺序回答每组中的询问，因此可以以询问左端点所在块的 $ID$ 为第一关键字，询问右端点为第二关键字直接将所有剩余询问排序。这样每组中的询问将会是连续的，且组内询问的右端点也是升序的。

下面我们开始依次回答每组中的询问。现在先假定下文中所述操作以及回答询问的时间复杂度均为 $O(1)$。

在**回答每一组的询问前**，我们需要初始化滑动窗口的左右端点和解题所需的数据/数据结构。为了方便起见，下面的区间均表示为**开区间**。

设当前处理的是左端点位于第 $k$ 个块 $(k$ 从 $0$ 开始) 中的所有询问，则我们将滑动窗口左右端点 $(L,R)$ 初始化为：

$$(kB-1,(k+1)B)$$

即 $L$ 和 $R$ 分别取 第 $k$ 个块的右端点和第 $k+1$ 个块的右端点。

注意，由于区间是开区间，两侧端点不能取到，因此初始化后滑动窗口表示一个空区间。

同时，我们需要初始化一个数组 $subZeroBlocks$，用于记录子字符串的连续 $0$ 区块的情况。

接下来，我们按照排序后的顺序从左到右依次处理每组中的询问。

对于询问 $[l,r]$，我们按以下顺序调整滑动窗口：

##### 第一步，不断向右扩展滑动窗口右端点，直到 $R>r$。

在这个过程中，不断有新的字符由滑动窗口右侧进入窗口。

- 如果 $s[R]=1$，subZeroBlocks 不会发生改变。
- 如果 $s[R]=0$，我们需要更新 $subZeroBlocks$。
    - 如果 $R$ 为 $s$ 中一个连续 $0$ 区块的起始位置，我们从 $subZeroBlocks$ 右侧追加元素 $1$，表示有一个长度为 $1$ 的新区块进入询问区间内。
    - 否则，我们将 $subZeroBlocks$ 最后一个元素增加 $1$，表示最右侧的区块长度增大了 $1$。

##### 第二步，向左扩展滑动窗口左端点，直到 $L<l$。

在这个过程中，不断有新的字符由滑动窗口左侧进入窗口。

- 如果 $s[L]=1$，subZeroBlocks 不会发生改变。
- 如果 $s[L]=0$，我们需要更新 $subZeroBlocks$。
    - 如果 $L$ 为 $s$ 中一个连续 $0$ 区块的起始位置，我们从 $subZeroBlocks$ 左侧追加元素 $1$，表示有一个长度为 $1$ 的新区块进入询问区间内。
    - 否则，我们将 $subZeroBlocks$ 第一个元素增加 $1$，表示最左侧的区块长度增大了 $1$。

通过以上方式，我们可以在扩展滑动窗口的过程中，实时维护数组 $subZeroBlocks$。

当滑动窗口扩展结束时，此时的窗口 $(L,R)$ 恰好对应当前的询问区间 $[l,r]$。因此，我们可以从当前的数组 $subZeroBlocks$ 中计算出 $bestGain$，并立即回答该询问。

##### 第三步，将滑动窗口左端点向右还原至至初始化位置。

当询问处理完成后，我们需要将左端点 $L$ 恢复到其初始化位置，即该块的右端点处，以便继续处理下一次询问。

在窗口收缩的过程中，不断有字符从窗口左侧离开窗口。我们可以采取类似第二步的做法，继续实时更新subZeroBlocks，这里不再赘述。

在滑动窗口左端点还原至该块的右端点处之后，我们回到第一步，回答下一个询问。

上述便是使用莫队算法解决本问题的整体框架。

![](./assets/img/Solution3501_off_3_01.png)
![](./assets/img/Solution3501_off_3_02.png)
![](./assets/img/Solution3501_off_3_03.png)
![](./assets/img/Solution3501_off_3_04.png)
![](./assets/img/Solution3501_off_3_05.png)
![](./assets/img/Solution3501_off_3_06.png)
![](./assets/img/Solution3501_off_3_07.png)
![](./assets/img/Solution3501_off_3_08.png)
![](./assets/img/Solution3501_off_3_09.png)
![](./assets/img/Solution3501_off_3_10.png)
![](./assets/img/Solution3501_off_3_11.png)
![](./assets/img/Solution3501_off_3_12.png)
![](./assets/img/Solution3501_off_3_13.png)
![](./assets/img/Solution3501_off_3_14.png)
![](./assets/img/Solution3501_off_3_15.png)
![](./assets/img/Solution3501_off_3_16.png)
![](./assets/img/Solution3501_off_3_17.png)
![](./assets/img/Solution3501_off_3_18.png)
![](./assets/img/Solution3501_off_3_19.png)
![](./assets/img/Solution3501_off_3_20.png)
![](./assets/img/Solution3501_off_3_21.png)
![](./assets/img/Solution3501_off_3_22.png)
![](./assets/img/Solution3501_off_3_23.png)
![](./assets/img/Solution3501_off_3_24.png)
![](./assets/img/Solution3501_off_3_25.png)
![](./assets/img/Solution3501_off_3_26.png)
![](./assets/img/Solution3501_off_3_27.png)
![](./assets/img/Solution3501_off_3_28.png)
![](./assets/img/Solution3501_off_3_29.png)
![](./assets/img/Solution3501_off_3_30.png)
![](./assets/img/Solution3501_off_3_31.png)
![](./assets/img/Solution3501_off_3_32.png)
![](./assets/img/Solution3501_off_3_33.png)
![](./assets/img/Solution3501_off_3_34.png)
![](./assets/img/Solution3501_off_3_35.png)
![](./assets/img/Solution3501_off_3_36.png)
![](./assets/img/Solution3501_off_3_37.png)
![](./assets/img/Solution3501_off_3_38.png)
![](./assets/img/Solution3501_off_3_39.png)
![](./assets/img/Solution3501_off_3_40.png)
![](./assets/img/Solution3501_off_3_41.png)
![](./assets/img/Solution3501_off_3_42.png)
![](./assets/img/Solution3501_off_3_43.png)
![](./assets/img/Solution3501_off_3_44.png)
![](./assets/img/Solution3501_off_3_45.png)
![](./assets/img/Solution3501_off_3_46.png)
![](./assets/img/Solution3501_off_3_47.png)
![](./assets/img/Solution3501_off_3_48.png)
![](./assets/img/Solution3501_off_3_49.png)
![](./assets/img/Solution3501_off_3_50.png)
![](./assets/img/Solution3501_off_3_51.png)
![](./assets/img/Solution3501_off_3_52.png)
![](./assets/img/Solution3501_off_3_53.png)
![](./assets/img/Solution3501_off_3_54.png)

---

##### 时间复杂度分析

下面在假定滑窗时更新操作以及回答询问最终的时间复杂度均为 $O(1)$ 的情况下，分析该算法本身的时间复杂度。

由于同一组中的询问按照右端点非递减排序，因此右端点 $R$ 只会单调向右移动。$ $
我们将一个长为 $n$ 的字符串按块长 $B=\sqrt{n}$ 分块，因此块的数量约为 $blockCount=\dfrac{n}{B}=\sqrt{n}$ 个。

回答**每一组内**的所有询问时，滑动窗口的右端点 $R$ 由起始位置始终向右移动，因此最多滑动 $O(n)$ 次。因此，处理 $blockCount$ 组询问的右端点的总滑动次数的数量级为：

$$O(n\cdot blockCount)=O(n\sqrt{n})$$

再来看滑动窗口左端点 $L$ 的情况。回答**每个**询问需要移动 $L$ 直至 $L<l$，回答完毕后再还原至该块右端点处。因为询问的左端点 $l$ 和 $L$ 在同一块中，所以 $L$ 移动的距离不超过 $2$ 倍块长。因此，滑动窗口左端点 $L$ 在回答所有询问中贡献的时间复杂度是:

$$O(2qB)=O(q\sqrt{n})$$

此外，如前所述，回答所有区间长度不超过 $B$ 的询问带来的时间复杂度是 $O(q\sqrt{n})$。对询问进行排序的时间复杂度是 $O(q\log q)$。因此整个算法的时间复杂度为：

$$O(q\log q+n\sqrt{n}+q\sqrt{n})$$

在 $q$ 和 $n$ 同阶的情况下，算法的整体时间复杂度为：

$$O(n\sqrt{n})$$

这便是莫队算法的核心思想：通过重新排列询问顺序，使滑动窗口移动的总代价尽可能小，从而高效地解决大量静态区间询问问题。

---

下面对一些重要的细节进行说明。

在上文中我们假设滑窗时更新操作以及回答询问最终的时间复杂度均为 $O(1)$，下面讨论这一点是否真的能够实现。

由于需要在 $subZeroBlocks$ 的两端进行修改、添加和删除操作，因此可以使用双端队列（$deque$）维护它，从而将每次更新的时间复杂度控制在 $O(1)$。

然而，如果仅维护 $subZeroBlocks$，那么在回答询问时，仍然需要遍历整个 $subZeroBlocks$ 才能计算出 $bestGain$。

因此，目前回答询问的时间复杂度仍不是 $O(1)$，我们还需要引入额外的信息来辅助维护答案。

那么，应该维护什么信息呢？

注意到，$bestGain$ 等于 $subZeroBlocks$ 中相邻两个元素之和的最大值。因此，我们可以尝试直接维护 $bestGain$。

在处理每组询问之前，除了初始化一个空的双端队列 $subZeroBlocks$ 外，再初始化

$$bestGain=0$$

在扩展左右端点的过程中，更新 $bestGain$ 是比较容易的。因为当 $subZeroBlocks$ 某一侧发生变化时，只有靠近该侧的新相邻元素之和可能影响 $bestGain$。

更形式化地，设当前：

$$subZeroBlocks=[z_0,z_1,\dots ,z_{m-1}]$$

当从右侧修改或加入元素时，只需要更新：

$$bestGain=max(bestGain,z_{m-1}+z_{m-2})$$

同理，当从左侧修改或加入元素时，更新：

$$bestGain=max(bestGain,z_0+z_1)$$

这样，我们便能够利用实时维护的 $bestGain$，在 $O(1)$ 的时间复杂度内回答询问。

然而，在还原左端点的过程中，会出现如下情况：

- $subZeroBlocks$ 的左端元素 $z_0$ 离开窗口；
- 左端元素 $z_0$ 的值减少 $1$。

如果当前 $bestGain=z0_+z_1$，那么在上述变化发生后，新的 $bestGain$ 应该是多少呢？

此时我们无法在 $O(1)$ 的时间内得知答案。因为我们只记录了当前最大值，却不知道“次大值”是多少；一旦当前贡献最大值的相邻元素对失效，就无法立即确定新的最大值。

为了解决这一问题，可以在滑窗过程中额外使用有序集合或懒删除堆，维护所有相邻元素和的集合。这样便能够在元素失效后快速求出新的最大值，但代价是每次更新都需要额外的 $O(\log n)$ 时间复杂度，因此整体更新复杂度又退化为了 $O(\log n)$。

那么，还有没有办法避免这一问题呢？

注意到，我们的流程是：先不断向左扩展滑动窗口左端点 $L$，直到满足当前询问的要求；回答询问后，再将 $L$ 还原，以继续处理下一组询问。

关键在于：在还原 $L$ 的过程中，我们实际上并不需要使用 $bestGain$ 来回答任何询问。对于后续询问而言，我们只需要保证：当左端点还原后，我们维护的信息与扩展之前完全一致即可。

而还原完成后的 $bestGain$，恰好就是扩展左端点之前的 $bestGain$。因为还原后的窗口与扩展前完全相同。

因此，我们只需在扩展左端点之前，先备份当前的 $bestGain$。待左端点恢复后，再直接将 $bestGain$ 还原即可。

这样一来，我们便成功避免了维护“次大值”的问题，也无需额外的数据结构，从而将滑窗更新以及回答询问的时间复杂度都严格控制在了 $O(1)$。

这个做法利用了「[回滚莫队](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fmisc%2Frollback-mo-algo%2F)」的思想，有兴趣的读者可以继续学习，并尝试解决「[3636\. 查询超过阈值频率最高元素](https://leetcode.cn/problems/threshold-majority-queries/description/i/)」。

---

此外，我们可以提前进行预处理以加速滑窗的移动过程。

具体地，预处理两个数组：

- $left[i]$：表示以位置 $i$ 结尾，与 $s[i]$ 相同的连续区块长度；
- $right[i]$：表示以位置 $i$ 开始，与 $s[i]$ 相同的连续区块长度。

例如：

$$s=0011100$$

则有：

$$left=[1,2,1,2,3,1,2]$$

$$right=[2,1,3,2,1,2,1]$$

它们可以在线性时间内预处理完成。

有了这两个数组后，我们在滑窗移动时，就不必再一个字符一个字符地移动，而是能够直接“跳过”整段相同字符。

例如，当右端点位于位置 $R$ 时：

- 若 $s[R]=1$，那么这一整段连续的 $1$ 对答案没有贡献，可以直接跳过；
- 若 $s[R]=0$，则可以直接得到这一段连续 $0$ 的长度为：

$$sz=\mathop{min}(right[R],r-R+1)$$

其中需要取最小值，是因为这一连续段可能超出询问右端点 $r$。

因此，我们可以直接将右端点移动：

$$R\leftarrow R+sz$$

而不是逐个位置移动。

左端点扩展时同理。设当前左端点为 $L$，则当前连续段长度为：

sz=min(left[L],L-l+1)

随后直接令：

L\leftarrow $L-sz$

即可一次性跳过整段相同字符。

这样做的好处在于，滑窗移动的次数不再与区块长度成正比，而是与区块的数量成正比。

因此，在随机数据或连续段较长的数据下，效率会更高一些。

此外，在左端点 $L$ 还原过程中，虽然 $subZeroBlocks$ 已经能够做到单次 $O(1)$ 更新，但还可以进一步简化。

注意到，扩展左端点时，对 $subZeroBlocks$ 的影响只有两种：

- 若左端点落在某个已有的 $0$ 连续区块内部，则只会修改第一个元素；
- 否则只会在左侧新增若干个连续区块。

因此，我们无需逐步撤销左端点移动过程中的所有操作，而只需要在扩展前额外记录：

- $subZeroBlocks$ 第一个元素的原始值；
- 从左侧新增的元素个数。

这样在回滚时：

- 直接从左侧弹出对应数量的新增元素；
- 再将第一个元素恢复为原始值；

即可完成整个 $subZeroBlocks$ 的还原。

**代码**

```Python
class Solution:
    def maxActiveSectionsAfterTrade(self, s: str, queries: List[List[int]]) -> List[int]:
        n, m = len(s), len(queries)
        cnt1 = s.count('1')

        left = [-1] * n  # left[i]：表示以位置 i 结尾，与 s[i] 相同的连续区块长度
        right = [-1] * n  # right[i]：表示以位置 i 开始，与 s[i] 相同的连续区块长度
        for i in range(n):
            left[i] = left[i - 1] + 1 if i > 0 and s[i - 1] == s[i] else 1
        for i in range(n - 1,-1,-1):
            right[i] = right[i + 1] + 1 if i < n-1 and s[i + 1] == s[i] else 1

        ans = [-1] * m
        block_size = isqrt(n)

        longQueries = []  # 长度大于块长的询问
        def brute_force(l, r) -> int:
            i = l
            best = 0
            prev = -inf

            while i <= r:
                start = i

                while i <= r and s[i] == s[start]:
                    i += 1

                if s[start] == '0':
                    cur = i - start
                    best = prev + cur if prev + cur > best else best
                    prev = cur
            return best

        for i, (l, r) in enumerate(queries):
            if r - l + 1 > block_size:
                longQueries.append((l // block_size, l, r, i))
            else:
                ans[i] = cnt1 + brute_force(l, r) # 长度小于块长的询问，暴力计算

        # 以询问左端点所在块的 ID 为第一关键字，询问右端点为第二关键字排序
        longQueries.sort(key=lambda q: (q[0], q[2]))
        subZeroBlocks = deque()

        for i, (bid, l, r, qid) in enumerate(longQueries):
            if i == 0 or bid > longQueries[i - 1][0]:     # 遍历到一个新的块, 进行初始化操作
                L = (bid + 1) * block_size - 1   # L 初始化为为该块右端点
                R = (bid + 1) * block_size       # R 初始化为下一块左端点
                subZeroBlocks.clear()
                bestGain = 0

            while R <= r:
                sz = min(r - R + 1, right[R])
                if s[R] == '0':
                    if subZeroBlocks and s[R-1] == '0':
                        subZeroBlocks[-1] += sz
                    else:
                        subZeroBlocks.append(sz)
                    if len(subZeroBlocks) >= 2:
                        bestGain = max(subZeroBlocks[-1] + subZeroBlocks[-2], bestGain)
                R += sz

            tmp_bestGain = bestGain  # 移动左端点 L 前，备份 bestGain 的值
            tmp_firstValue = subZeroBlocks[0] if subZeroBlocks else None # 移动左端点前，subZeroBlocks第一个元素（如果有）的值
            cnt = 0  # 记录移动左端点 L 的过程中，从左侧加入的数字数量

            while L >= l:
                sz = min(L - l + 1, left[L])
                if s[L] == '0':
                    if subZeroBlocks and s[L+1] == '0':
                        subZeroBlocks[0] += sz
                    else:
                        subZeroBlocks.appendleft(sz)
                        cnt += 1
                    if len(subZeroBlocks) >= 2:
                        bestGain = max(subZeroBlocks[0] + subZeroBlocks[1], bestGain)
                L -= sz

            ans[qid] = bestGain + cnt1  # 回答询问

            # 还原左端点 L
            L = (bid + 1) * block_size - 1

            # 还原 bestGain
            bestGain = tmp_bestGain

            # 还原 subZeroBlocks
            for _ in range(cnt):
                subZeroBlocks.popleft()
            if tmp_firstValue:
                subZeroBlocks[0] = tmp_firstValue
        return ans
```

```C++
class Solution {
public:
    vector<int> maxActiveSectionsAfterTrade(string s, vector<vector<int>>& queries) {
        int n = s.length(), m = queries.size();
        int cnt1 = count(s.begin(), s.end(), '1');
        // left[i]：表示以位置 i 结尾，与 s[i] 相同的连续区块长度
        vector<int> left(n, -1);
        // right[i]：表示以位置 i 开始，与 s[i] 相同的连续区块长度
        vector<int> right(n, -1);

        for (int i = 0; i < n; i++) {
            left[i] = (i > 0 && s[i-1] == s[i]) ? left[i-1] + 1 : 1;
        }
        for (int i = n - 1; i >= 0; i--) {
            right[i] = (i < n-1 && s[i+1] == s[i]) ? right[i+1] + 1 : 1;
        }

        vector<int> ans(m, -1);
        int block_size = (int)sqrt(n);
        // 长度大于块长的询问
        vector<tuple<int, int, int, int>> longQueries;

        auto brute_force = [&](int l, int r) -> int {
            int i = l;
            int best = 0;
            int prev = INT_MIN;

            while (i <= r) {
                int start = i;
                while (i <= r && s[i] == s[start]) {
                    i++;
                }
                if (s[start] == '0') {
                    int cur = i - start;
                    best = (prev != INT_MIN && prev + cur > best) ? prev + cur : best;
                    prev = cur;
                }
            }
            return best;
        };

        for (int i = 0; i < m; i++) {
            int l = queries[i][0], r = queries[i][1];
            if (r - l + 1 > block_size) {
                longQueries.push_back({l / block_size, l, r, i});
            } else {
                // 长度小于块长的询问，暴力计算
                ans[i] = cnt1 + brute_force(l, r);
            }
        }

        // 以询问左端点所在块的 ID 为第一关键字，询问右端点为第二关键字排序
        sort(longQueries.begin(), longQueries.end(),
             [](const tuple<int,int,int,int>& a, const tuple<int,int,int,int>& b) {
                 if (get<0>(a) != get<0>(b)) return get<0>(a) < get<0>(b);
                 return get<2>(a) < get<2>(b);
             });

        deque<int> subZeroBlocks;
        int L = 0, R = 0, bestGain = 0;

        for (int i = 0; i < longQueries.size(); i++) {
            int bid = get<0>(longQueries[i]);
            int l = get<1>(longQueries[i]);
            int r = get<2>(longQueries[i]);
            int qid = get<3>(longQueries[i]);

            if (i == 0 || bid > get<0>(longQueries[i-1])) {
                // 遍历到一个新的块, 进行初始化操作
                L = (bid + 1) * block_size - 1;   // L 初始化为为该块右端点
                R = (bid + 1) * block_size;       // R 初始化为下一块左端点
                subZeroBlocks.clear();
                bestGain = 0;
            }

            while (R <= r) {
                int sz = min(r - R + 1, right[R]);
                if (s[R] == '0') {
                    if (!subZeroBlocks.empty() && s[R-1] == '0') {
                        subZeroBlocks.back() += sz;
                    } else {
                        subZeroBlocks.push_back(sz);
                    }
                    if (subZeroBlocks.size() >= 2) {
                        bestGain = max(subZeroBlocks.back() + subZeroBlocks[subZeroBlocks.size()-2], bestGain);
                    }
                }
                R += sz;
            }

            // 移动左端点 L 前，备份 bestGain 的值
            int tmp_bestGain = bestGain;
            // 移动左端点前，subZeroBlocks第一个元素（如果有）的值
            int tmp_firstValue = subZeroBlocks.empty() ? -1 : subZeroBlocks.front();
            // 记录移动左端点 L 的过程中，从左侧加入的数字数量
            int cnt = 0;

            while (L >= l) {
                int sz = min(L - l + 1, left[L]);
                if (s[L] == '0') {
                    if (!subZeroBlocks.empty() && s[L+1] == '0') {
                        subZeroBlocks.front() += sz;
                    } else {
                        subZeroBlocks.push_front(sz);
                        cnt++;
                    }
                    if (subZeroBlocks.size() >= 2) {
                        bestGain = max(subZeroBlocks[0] + subZeroBlocks[1], bestGain);
                    }
                }
                L -= sz;
            }

            // 回答询问
            ans[qid] = bestGain + cnt1;
            // 还原左端点 L
            L = (bid + 1) * block_size - 1;
            // 还原 bestGain
            bestGain = tmp_bestGain;
            // 还原 subZeroBlocks
            for (int j = 0; j < cnt; j++) {
                subZeroBlocks.pop_front();
            }
            if (tmp_firstValue != -1) {
                subZeroBlocks[0] = tmp_firstValue;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public List<Integer> maxActiveSectionsAfterTrade(String s, int[][] queries) {
        int n = s.length(), m = queries.length;
        int cnt1 = 0;
        for (char c : s.toCharArray()) {
            if (c == '1') cnt1++;
        }
        // left[i]：表示以位置 i 结尾，与 s[i] 相同的连续区块长度
        int[] left = new int[n];
        // right[i]：表示以位置 i 开始，与 s[i] 相同的连续区块长度
        int[] right = new int[n];

        for (int i = 0; i < n; i++) {
            left[i] = (i > 0 && s.charAt(i - 1) == s.charAt(i)) ? left[i - 1] + 1 : 1;
        }
        for (int i = n - 1; i >= 0; i--) {
            right[i] = (i < n - 1 && s.charAt(i + 1) == s.charAt(i)) ? right[i + 1] + 1 : 1;
        }

        List<Integer> ans = new ArrayList<>(Collections.nCopies(m, -1));
        int block_size = (int) Math.sqrt(n);
        // 长度大于块长的询问
        List<int[]> longQueries = new ArrayList<>();

        for (int i = 0; i < m; i++) {
            int l = queries[i][0], r = queries[i][1];
            if (r - l + 1 > block_size) {
                longQueries.add(new int[]{l / block_size, l, r, i});
            } else {
                // 长度小于块长的询问，暴力计算
                ans.set(i, cnt1 + bruteForce(s, l, r));
            }
        }

        // 以询问左端点所在块的 ID 为第一关键字，询问右端点为第二关键字排序
        longQueries.sort((a, b) -> {
            if (a[0] != b[0]) return Integer.compare(a[0], b[0]);
            return Integer.compare(a[2], b[2]);
        });

        Deque<Integer> subZeroBlocks = new ArrayDeque<>();
        int L = 0, R = 0, bestGain = 0;

        for (int i = 0; i < longQueries.size(); i++) {
            int[] q = longQueries.get(i);
            int bid = q[0], l = q[1], r = q[2], qid = q[3];

            if (i == 0 || bid > longQueries.get(i - 1)[0]) {
                // 遍历到一个新的块, 进行初始化操作
                L = (bid + 1) * block_size - 1;   // L 初始化为该块右端点
                R = (bid + 1) * block_size;       // R 初始化为下一块左端点
                subZeroBlocks.clear();
                bestGain = 0;
            }

            while (R <= r) {
                int sz = Math.min(r - R + 1, right[R]);
                if (s.charAt(R) == '0') {
                    if (!subZeroBlocks.isEmpty() && s.charAt(R - 1) == '0') {
                        subZeroBlocks.offerLast(subZeroBlocks.pollLast() + sz);
                    } else {
                        subZeroBlocks.offerLast(sz);
                    }
                    if (subZeroBlocks.size() >= 2) {
                        int last = subZeroBlocks.pollLast();
                        int secondLast = subZeroBlocks.peekLast();
                        subZeroBlocks.offerLast(last);
                        bestGain = Math.max(last + secondLast, bestGain);
                    }
                }
                R += sz;
            }

            // 移动左端点 L 前，备份 bestGain 的值
            int tmp_bestGain = bestGain;
            // 移动左端点前，subZeroBlocks第一个元素（如果有）的值
            int tmp_firstValue = subZeroBlocks.isEmpty() ? -1 : subZeroBlocks.peekFirst();
            // 记录移动左端点 L 的过程中，从左侧加入的数字数量
            int cnt = 0;

            while (L >= l) {
                int sz = Math.min(L - l + 1, left[L]);
                if (s.charAt(L) == '0') {
                    if (!subZeroBlocks.isEmpty() && s.charAt(L + 1) == '0') {
                        subZeroBlocks.offerFirst(subZeroBlocks.pollFirst() + sz);
                    } else {
                        subZeroBlocks.offerFirst(sz);
                        cnt++;
                    }
                    if (subZeroBlocks.size() >= 2) {
                        int first = subZeroBlocks.peekFirst();
                        subZeroBlocks.pollFirst();
                        int second = subZeroBlocks.peekFirst();
                        subZeroBlocks.offerFirst(first);
                        bestGain = Math.max(first + second, bestGain);
                    }
                }
                L -= sz;
            }

            // 回答询问
            ans.set(qid, bestGain + cnt1);
            // 还原左端点 L
            L = (bid + 1) * block_size - 1;
            // 还原 bestGain
            bestGain = tmp_bestGain;
            // 还原 subZeroBlocks
            for (int j = 0; j < cnt; j++) {
                subZeroBlocks.pollFirst();
            }
            if (tmp_firstValue != -1) {
                subZeroBlocks.pollFirst();
                subZeroBlocks.offerFirst(tmp_firstValue);
            }
        }
        return ans;
    }

    private int bruteForce(String s, int l, int r) {
        int i = l;
        int best = 0;
        int prev = Integer.MIN_VALUE;

        while (i <= r) {
            int start = i;
            while (i <= r && s.charAt(i) == s.charAt(start)) {
                i++;
            }
            if (s.charAt(start) == '0') {
                int cur = i - start;
                if (prev != Integer.MIN_VALUE && prev + cur > best) {
                    best = prev + cur;
                }
                prev = cur;
            }
        }
        return best;
    }
}
```

```CSharp
public class Solution {
    public List<int> MaxActiveSectionsAfterTrade(string s, int[][] queries) {
        int n = s.Length, m = queries.Length;
        int cnt1 = 0;
        foreach (char c in s) {
            if (c == '1') {
                cnt1++;
            }
        }
        // left[i]：表示以位置 i 结尾，与 s[i] 相同的连续区块长度
        int[] left = new int[n];
        // right[i]：表示以位置 i 开始，与 s[i] 相同的连续区块长度
        int[] right = new int[n];

        for (int i = 0; i < n; i++) {
            left[i] = (i > 0 && s[i - 1] == s[i]) ? left[i - 1] + 1 : 1;
        }
        for (int i = n - 1; i >= 0; i--) {
            right[i] = (i < n - 1 && s[i + 1] == s[i]) ? right[i + 1] + 1 : 1;
        }

        List<int> ans = new List<int>(new int[m]);
        for (int i = 0; i < m; i++) {
            ans[i] = -1;
        }
        int block_size = (int)Math.Sqrt(n);
        // 长度大于块长的询问
        List<(int bid, int l, int r, int qid)> longQueries = new List<(int, int, int, int)>();

        for (int i = 0; i < m; i++) {
            int l = queries[i][0], r = queries[i][1];
            if (r - l + 1 > block_size) {
                longQueries.Add((l / block_size, l, r, i));
            } else {
                // 长度小于块长的询问，暴力计算
                ans[i] = cnt1 + BruteForce(s, l, r);
            }
        }

        // 以询问左端点所在块的 ID 为第一关键字，询问右端点为第二关键字排序
        longQueries.Sort((a, b) => {
            if (a.bid != b.bid) return a.bid.CompareTo(b.bid);
            return a.r.CompareTo(b.r);
        });

        LinkedList<int> subZeroBlocks = new LinkedList<int>();
        int L = 0, R = 0, bestGain = 0;

        for (int i = 0; i < longQueries.Count; i++) {
            var (bid, l, r, qid) = longQueries[i];

            if (i == 0 || bid > longQueries[i - 1].bid) {
                // 遍历到一个新的块, 进行初始化操作
                L = (bid + 1) * block_size - 1;   // L 初始化为该块右端点
                R = (bid + 1) * block_size;       // R 初始化为下一块左端点
                subZeroBlocks.Clear();
                bestGain = 0;
            }

            while (R <= r) {
                int sz = Math.Min(r - R + 1, right[R]);
                if (s[R] == '0') {
                    if (subZeroBlocks.Count > 0 && s[R - 1] == '0') {
                        subZeroBlocks.Last.Value += sz;
                    } else {
                        subZeroBlocks.AddLast(sz);
                    }
                    if (subZeroBlocks.Count >= 2) {
                        bestGain = Math.Max(subZeroBlocks.Last.Value + subZeroBlocks.Last.Previous.Value, bestGain);
                    }
                }
                R += sz;
            }

            // 移动左端点 L 前，备份 bestGain 的值
            int tmp_bestGain = bestGain;
            // 移动左端点前，subZeroBlocks第一个元素（如果有）的值
            int tmp_firstValue = subZeroBlocks.Count == 0 ? -1 : subZeroBlocks.First.Value;
            // 记录移动左端点 L 的过程中，从左侧加入的数字数量
            int cnt = 0;

            while (L >= l) {
                int sz = Math.Min(L - l + 1, left[L]);
                if (s[L] == '0') {
                    if (subZeroBlocks.Count > 0 && s[L + 1] == '0') {
                        subZeroBlocks.First.Value += sz;
                    } else {
                        subZeroBlocks.AddFirst(sz);
                        cnt++;
                    }
                    if (subZeroBlocks.Count >= 2) {
                        bestGain = Math.Max(subZeroBlocks.First.Value + subZeroBlocks.First.Next.Value, bestGain);
                    }
                }
                L -= sz;
            }

            // 回答询问
            ans[qid] = bestGain + cnt1;
            // 还原左端点 L
            L = (bid + 1) * block_size - 1;
            // 还原 bestGain
            bestGain = tmp_bestGain;
            // 还原 subZeroBlocks
            for (int j = 0; j < cnt; j++) {
                subZeroBlocks.RemoveFirst();
            }
            if (tmp_firstValue != -1) {
                subZeroBlocks.First.Value = tmp_firstValue;
            }
        }
        return ans;
    }

    private int BruteForce(string s, int l, int r) {
        int i = l;
        int best = 0;
        int prev = int.MinValue;

        while (i <= r) {
            int start = i;
            while (i <= r && s[i] == s[start]) {
                i++;
            }
            if (s[start] == '0') {
                int cur = i - start;
                if (prev != int.MinValue && prev + cur > best) {
                    best = prev + cur;
                }
                prev = cur;
            }
        }
        return best;
    }
}
```

```Go
func maxActiveSectionsAfterTrade(s string, queries [][]int) []int {
    n, m := len(s), len(queries)
    cnt1 := 0
    for _, c := range s {
        if c == '1' {
            cnt1++
        }
    }
    // left[i]：表示以位置 i 结尾，与 s[i] 相同的连续区块长度
    left := make([]int, n)
    // right[i]：表示以位置 i 开始，与 s[i] 相同的连续区块长度
    right := make([]int, n)

    for i := 0; i < n; i++ {
        if i > 0 && s[i-1] == s[i] {
            left[i] = left[i-1] + 1
        } else {
            left[i] = 1
        }
    }
    for i := n - 1; i >= 0; i-- {
        if i < n-1 && s[i+1] == s[i] {
            right[i] = right[i+1] + 1
        } else {
            right[i] = 1
        }
    }

    ans := make([]int, m)
    for i := range ans {
        ans[i] = -1
    }
    block_size := int(math.Sqrt(float64(n)))
    // 长度大于块长的询问
    longQueries := make([][4]int, 0, m)

    bruteForce := func(l, r int) int {
        i := l
        best := 0
        prev := math.MinInt32

        for i <= r {
            start := i
            for i <= r && s[i] == s[start] {
                i++
            }
            if s[start] == '0' {
                cur := i - start
                if prev != math.MinInt32 && prev+cur > best {
                    best = prev + cur
                }
                prev = cur
            }
        }
        return best
    }

    for i := 0; i < m; i++ {
        l, r := queries[i][0], queries[i][1]
        if r - l + 1 > block_size {
            longQueries = append(longQueries, [4]int{l / block_size, l, r, i})
        } else {
            // 长度小于块长的询问，暴力计算
            ans[i] = cnt1 + bruteForce(l, r)
        }
    }

    // 以询问左端点所在块的 ID 为第一关键字，询问右端点为第二关键字排序
    sort.Slice(longQueries, func(i, j int) bool {
        if longQueries[i][0] != longQueries[j][0] {
            return longQueries[i][0] < longQueries[j][0]
        }
        return longQueries[i][2] < longQueries[j][2]
    })

    // 使用数组模拟双端队列，从中间开始扩展，避免频繁内存分配
    subZeroBlocks := make([]int, n)
    head, tail := n/2, n/2
    L, R, bestGain := 0, 0, 0

    for i := 0; i < len(longQueries); i++ {
        bid, l, r, qid := longQueries[i][0], longQueries[i][1], longQueries[i][2], longQueries[i][3]
        if i == 0 || bid > longQueries[i-1][0] {
            // 遍历到一个新的块, 进行初始化操作
            L = (bid+1)*block_size - 1 // L 初始化为该块右端点
            R = (bid + 1) * block_size  // R 初始化为下一块左端点
            head, tail = n/2, n/2
            bestGain = 0
        }

        for R <= r {
            sz := right[R]
            if r-R+1 < sz {
                sz = r - R + 1
            }
            if s[R] == '0' {
                if tail > head && s[R-1] == '0' {
                    subZeroBlocks[tail-1] += sz
                } else {
                    subZeroBlocks[tail] = sz
                    tail++
                }
                if tail-head >= 2 {
                    val := subZeroBlocks[tail-1] + subZeroBlocks[tail-2]
                    if val > bestGain {
                        bestGain = val
                    }
                }
            }
            R += sz
        }

        // 移动左端点 L 前，备份 bestGain 的值
        tmp_bestGain := bestGain
        // 移动左端点前，subZeroBlocks第一个元素（如果有）的值
        tmp_firstValue := -1
        if tail > head {
            tmp_firstValue = subZeroBlocks[head]
        }
        // 记录移动左端点 L 的过程中，从左侧加入的数字数量
        cnt := 0

        for L >= l {
            sz := left[L]
            if L-l+1 < sz {
                sz = L - l + 1
            }
            if s[L] == '0' {
                if tail > head && s[L+1] == '0' {
                    subZeroBlocks[head] += sz
                } else {
                    head--
                    subZeroBlocks[head] = sz
                    cnt++
                }
                if tail-head >= 2 {
                    val := subZeroBlocks[head] + subZeroBlocks[head+1]
                    if val > bestGain {
                        bestGain = val
                    }
                }
            }
            L -= sz
        }

        // 回答询问
        ans[qid] = bestGain + cnt1
        // 还原左端点 L
        L = (bid+1)*block_size - 1
        // 还原 bestGain
        bestGain = tmp_bestGain
        // 还原 subZeroBlocks
        head += cnt
        if tmp_firstValue != -1 {
            subZeroBlocks[head] = tmp_firstValue
        }
    }
    return ans
}
```

```C
int bruteForce(char* s, int l, int r) {
    int i = l;
    int best = 0;
    int prev = INT_MIN;

    while (i <= r) {
        int start = i;
        while (i <= r && s[i] == s[start]) {
            i++;
        }
        if (s[start] == '0') {
            int cur = i - start;
            if (prev != INT_MIN && prev + cur > best) {
                best = prev + cur;
            }
            prev = cur;
        }
    }
    return best;
}

int cmp(const void* a, const void* b) {
    int* qa = *(int**)a;
    int* qb = *(int**)b;
    if (qa[0] != qb[0]) {
        return qa[0] - qb[0];
    }
    return qa[2] - qb[2];
}

int* maxActiveSectionsAfterTrade(char* s, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int n = strlen(s), m = queriesSize;
    int cnt1 = 0;
    for (int i = 0; i < n; i++) {
        if (s[i] == '1') cnt1++;
    }
    // left[i]：表示以位置 i 结尾，与 s[i] 相同的连续区块长度
    int* left = (int*)malloc(n * sizeof(int));
    // right[i]：表示以位置 i 开始，与 s[i] 相同的连续区块长度
    int* right = (int*)malloc(n * sizeof(int));

    for (int i = 0; i < n; i++) {
        if (i > 0 && s[i-1] == s[i]) {
            left[i] = left[i-1] + 1;
        } else {
            left[i] = 1;
        }
    }
    for (int i = n - 1; i >= 0; i--) {
        if (i < n-1 && s[i+1] == s[i]) {
            right[i] = right[i+1] + 1;
        } else {
            right[i] = 1;
        }
    }

    int* ans = (int*)malloc(m * sizeof(int));
    for (int i = 0; i < m; i++) {
        ans[i] = -1;
    }
    int block_size = (int)sqrt(n);

    // 长度大于块长的询问
    int** longQueries = (int**)malloc(m * sizeof(int*));
    int longCnt = 0;

    for (int i = 0; i < m; i++) {
        int l = queries[i][0], r = queries[i][1];
        if (r - l + 1 > block_size) {
            longQueries[longCnt] = (int*)malloc(4 * sizeof(int));
            longQueries[longCnt][0] = l / block_size;
            longQueries[longCnt][1] = l;
            longQueries[longCnt][2] = r;
            longQueries[longCnt][3] = i;
            longCnt++;
        } else {
            // 长度小于块长的询问，暴力计算
            ans[i] = cnt1 + bruteForce(s, l, r);
        }
    }

    // 以询问左端点所在块的 ID 为第一关键字，询问右端点为第二关键字排序
    qsort(longQueries, longCnt, sizeof(int*), cmp);
    // 使用数组模拟双端队列，从中间开始扩展，避免频繁内存分配
    int* subZeroBlocks = (int*)malloc(n * sizeof(int));
    int head = n / 2, tail = n / 2;
    int L = 0, R = 0, bestGain = 0;

    for (int i = 0; i < longCnt; i++) {
        int bid = longQueries[i][0];
        int l = longQueries[i][1];
        int r = longQueries[i][2];
        int qid = longQueries[i][3];

        if (i == 0 || bid > longQueries[i-1][0]) {
            // 遍历到一个新的块, 进行初始化操作
            L = (bid + 1) * block_size - 1; // L 初始化为该块右端点
            R = (bid + 1) * block_size;      // R 初始化为下一块左端点
            head = tail = n / 2;
            bestGain = 0;
        }

        while (R <= r) {
            int sz = right[R];
            if (r - R + 1 < sz) {
                sz = r - R + 1;
            }
            if (s[R] == '0') {
                if (tail > head && R > 0 && s[R-1] == '0') {
                    subZeroBlocks[tail-1] += sz;
                } else {
                    subZeroBlocks[tail] = sz;
                    tail++;
                }
                if (tail - head >= 2) {
                    int val = subZeroBlocks[tail-1] + subZeroBlocks[tail-2];
                    if (val > bestGain) {
                        bestGain = val;
                    }
                }
            }
            R += sz;
        }

        // 移动左端点 L 前，备份 bestGain 的值
        int tmp_bestGain = bestGain;
        // 移动左端点前，subZeroBlocks第一个元素（如果有）的值
        int tmp_firstValue = -1;
        if (tail > head) {
            tmp_firstValue = subZeroBlocks[head];
        }
        // 记录移动左端点 L 的过程中，从左侧加入的数字数量
        int cnt = 0;

        while (L >= l) {
            int sz = left[L];
            if (L - l + 1 < sz) {
                sz = L - l + 1;
            }
            if (s[L] == '0') {
                if (tail > head && L + 1 < n && s[L+1] == '0') {
                    subZeroBlocks[head] += sz;
                } else {
                    head--;
                    subZeroBlocks[head] = sz;
                    cnt++;
                }
                if (tail - head >= 2) {
                    int val = subZeroBlocks[head] + subZeroBlocks[head+1];
                    if (val > bestGain) {
                        bestGain = val;
                    }
                }
            }
            L -= sz;
        }

        // 回答询问
        ans[qid] = bestGain + cnt1;
        // 还原左端点 L
        L = (bid + 1) * block_size - 1;
        // 还原 bestGain
        bestGain = tmp_bestGain;
        // 还原 subZeroBlocks
        head += cnt;
        if (tmp_firstValue != -1 && head < tail) {
            subZeroBlocks[head] = tmp_firstValue;
        }
    }

    free(left);
    free(right);
    free(subZeroBlocks);
    for (int i = 0; i < longCnt; i++) {
        free(longQueries[i]);
    }
    free(longQueries);
    *returnSize = m;
    return ans;
}
```

```JavaScript
var maxActiveSectionsAfterTrade = function(s, queries) {
    const n = s.length, m = queries.length;
    let cnt1 = 0;
    for (let c of s) {
        if (c === '1') {
            cnt1++;
        }
    }
    // left[i]：表示以位置 i 结尾，与 s[i] 相同的连续区块长度
    const left = new Array(n);
    // right[i]：表示以位置 i 开始，与 s[i] 相同的连续区块长度
    const right = new Array(n);

    for (let i = 0; i < n; i++) {
        left[i] = (i > 0 && s[i-1] === s[i]) ? left[i-1] + 1 : 1;
    }
    for (let i = n - 1; i >= 0; i--) {
        right[i] = (i < n - 1 && s[i+1] === s[i]) ? right[i+1] + 1 : 1;
    }

    const ans = new Array(m).fill(-1);
    const block_size = Math.floor(Math.sqrt(n));
    // 长度大于块长的询问
    const longQueries = [];

    const bruteForce = (l, r) => {
        let i = l;
        let best = 0;
        let prev = -Infinity;

        while (i <= r) {
            let start = i;
            while (i <= r && s[i] === s[start]) {
                i++;
            }
            if (s[start] === '0') {
                let cur = i - start;
                if (prev !== -Infinity && prev + cur > best) {
                    best = prev + cur;
                }
                prev = cur;
            }
        }
        return best;
    };

    for (let i = 0; i < m; i++) {
        const l = queries[i][0], r = queries[i][1];
        if (r - l + 1 > block_size) {
            longQueries.push([Math.floor(l / block_size), l, r, i]);
        } else {
            // 长度小于块长的询问，暴力计算
            ans[i] = cnt1 + bruteForce(l, r);
        }
    }

    // 以询问左端点所在块的 ID 为第一关键字，询问右端点为第二关键字排序
    longQueries.sort((a, b) => {
        if (a[0] !== b[0]) return a[0] - b[0];
        return a[2] - b[2];
    });

    // 使用数组模拟双端队列，从中间开始扩展
    const subZeroBlocks = new Array(n).fill(0);
    let head = Math.floor(n / 2), tail = Math.floor(n / 2);
    let L = 0, R = 0, bestGain = 0;

    for (let i = 0; i < longQueries.length; i++) {
        const [bid, l, r, qid] = longQueries[i];
        if (i === 0 || bid > longQueries[i-1][0]) {
            // 遍历到一个新的块, 进行初始化操作
            L = (bid + 1) * block_size - 1;   // L 初始化为该块右端点
            R = (bid + 1) * block_size;       // R 初始化为下一块左端点
            head = tail = Math.floor(n / 2);
            bestGain = 0;
        }

        while (R <= r) {
            let sz = Math.min(r - R + 1, right[R]);
            if (s[R] === '0') {
                if (tail > head && s[R-1] === '0') {
                    subZeroBlocks[tail-1] += sz;
                } else {
                    subZeroBlocks[tail] = sz;
                    tail++;
                }
                if (tail - head >= 2) {
                    bestGain = Math.max(subZeroBlocks[tail-1] + subZeroBlocks[tail-2], bestGain);
                }
            }
            R += sz;
        }

        // 移动左端点 L 前，备份 bestGain 的值
        const tmp_bestGain = bestGain;
        // 移动左端点前，subZeroBlocks第一个元素（如果有）的值
        const tmp_firstValue = tail > head ? subZeroBlocks[head] : -1;
        // 记录移动左端点 L 的过程中，从左侧加入的数字数量
        let cnt = 0;

        while (L >= l) {
            let sz = Math.min(L - l + 1, left[L]);
            if (s[L] === '0') {
                if (tail > head && s[L+1] === '0') {
                    subZeroBlocks[head] += sz;
                } else {
                    head--;
                    subZeroBlocks[head] = sz;
                    cnt++;
                }
                if (tail - head >= 2) {
                    bestGain = Math.max(subZeroBlocks[head] + subZeroBlocks[head+1], bestGain);
                }
            }
            L -= sz;
        }

        // 回答询问
        ans[qid] = bestGain + cnt1;
        // 还原左端点 L
        L = (bid + 1) * block_size - 1;
        // 还原 bestGain
        bestGain = tmp_bestGain;
        // 还原 subZeroBlocks
        head += cnt;
        if (tmp_firstValue !== -1) {
            subZeroBlocks[head] = tmp_firstValue;
        }
    }
    return ans;
};
```

```TypeScript
function maxActiveSectionsAfterTrade(s: string, queries: number[][]): number[] {
    const n = s.length, m = queries.length;
    let cnt1 = 0;
    for (let c of s) {
        if (c === '1') {
            cnt1++;
        }
    }
    // left[i]：表示以位置 i 结尾，与 s[i] 相同的连续区块长度
    const left: number[] = new Array(n);
    // right[i]：表示以位置 i 开始，与 s[i] 相同的连续区块长度
    const right: number[] = new Array(n);
    for (let i = 0; i < n; i++) {
        left[i] = (i > 0 && s[i-1] === s[i]) ? left[i-1] + 1 : 1;
    }
    for (let i = n - 1; i >= 0; i--) {
        right[i] = (i < n - 1 && s[i+1] === s[i]) ? right[i+1] + 1 : 1;
    }

    const ans: number[] = new Array(m).fill(-1);
    const block_size: number = Math.floor(Math.sqrt(n));
    // 长度大于块长的询问
    const longQueries: [number, number, number, number][] = [];

    const bruteForce = (l: number, r: number): number => {
        let i = l;
        let best = 0;
        let prev = -Infinity;

        while (i <= r) {
            let start = i;
            while (i <= r && s[i] === s[start]) {
                i++;
            }
            if (s[start] === '0') {
                let cur = i - start;
                if (prev !== -Infinity && prev + cur > best) {
                    best = prev + cur;
                }
                prev = cur;
            }
        }
        return best;
    };

    for (let i = 0; i < m; i++) {
        const l = queries[i][0], r = queries[i][1];
        if (r - l + 1 > block_size) {
            longQueries.push([Math.floor(l / block_size), l, r, i]);
        } else {
            // 长度小于块长的询问，暴力计算
            ans[i] = cnt1 + bruteForce(l, r);
        }
    }

    // 以询问左端点所在块的 ID 为第一关键字，询问右端点为第二关键字排序
    longQueries.sort((a, b) => {
        if (a[0] !== b[0]) return a[0] - b[0];
        return a[2] - b[2];
    });

    // 使用数组模拟双端队列，从中间开始扩展
    const subZeroBlocks: number[] = new Array(n).fill(0);
    let head: number = Math.floor(n / 2), tail: number = Math.floor(n / 2);
    let L: number = 0, R: number = 0, bestGain: number = 0;

    for (let i = 0; i < longQueries.length; i++) {
        const [bid, l, r, qid] = longQueries[i];

        if (i === 0 || bid > longQueries[i-1][0]) {
            // 遍历到一个新的块, 进行初始化操作
            L = (bid + 1) * block_size - 1;   // L 初始化为该块右端点
            R = (bid + 1) * block_size;       // R 初始化为下一块左端点
            head = tail = Math.floor(n / 2);
            bestGain = 0;
        }

        while (R <= r) {
            let sz: number = Math.min(r - R + 1, right[R]);
            if (s[R] === '0') {
                if (tail > head && s[R-1] === '0') {
                    subZeroBlocks[tail-1] += sz;
                } else {
                    subZeroBlocks[tail] = sz;
                    tail++;
                }
                if (tail - head >= 2) {
                    bestGain = Math.max(subZeroBlocks[tail-1] + subZeroBlocks[tail-2], bestGain);
                }
            }
            R += sz;
        }

        // 移动左端点 L 前，备份 bestGain 的值
        const tmp_bestGain: number = bestGain;
        // 移动左端点前，subZeroBlocks第一个元素（如果有）的值
        const tmp_firstValue: number = tail > head ? subZeroBlocks[head] : -1;
        // 记录移动左端点 L 的过程中，从左侧加入的数字数量
        let cnt: number = 0;

        while (L >= l) {
            let sz: number = Math.min(L - l + 1, left[L]);
            if (s[L] === '0') {
                if (tail > head && s[L+1] === '0') {
                    subZeroBlocks[head] += sz;
                } else {
                    head--;
                    subZeroBlocks[head] = sz;
                    cnt++;
                }
                if (tail - head >= 2) {
                    bestGain = Math.max(subZeroBlocks[head] + subZeroBlocks[head+1], bestGain);
                }
            }
            L -= sz;
        }

        // 回答询问
        ans[qid] = bestGain + cnt1;
        // 还原左端点 L
        L = (bid + 1) * block_size - 1;
        // 还原 bestGain
        bestGain = tmp_bestGain;
        // 还原 subZeroBlocks
        head += cnt;
        if (tmp_firstValue !== -1) {
            subZeroBlocks[head] = tmp_firstValue;
        }
    }
    return ans;
}
```

```Rust
use std::collections::VecDeque;

impl Solution {
    pub fn max_active_sections_after_trade(s: String, queries: Vec<Vec<i32>>) -> Vec<i32> {
        let n = s.len();
        let m = queries.len();
        let s_bytes = s.as_bytes();

        let mut cnt1: i32 = 0;
        for &c in s_bytes {
            if c == b'1' {
                cnt1 += 1;
            }
        }

        // left[i]：表示以位置 i 结尾，与 s[i] 相同的连续区块长度
        let mut left = vec![0i32; n];
        // right[i]：表示以位置 i 开始，与 s[i] 相同的连续区块长度
        let mut right = vec![0i32; n];

        for i in 0..n {
            left[i] = if i > 0 && s_bytes[i-1] == s_bytes[i] {
                left[i-1] + 1
            } else {
                1
            };
        }
        for i in (0..n).rev() {
            right[i] = if i < n - 1 && s_bytes[i+1] == s_bytes[i] {
                right[i+1] + 1
            } else {
                1
            };
        }

        let mut ans = vec![-1i32; m];
        let block_size = (n as f64).sqrt() as usize;
        let block_size = if block_size < 1 { 1 } else { block_size };
        // 长度大于块长的询问
        let mut long_queries: Vec<[usize; 4]> = Vec::new();

        let brute_force = |l: usize, r: usize| -> i32 {
            let mut i = l;
            let mut best = 0i32;
            let mut prev = i32::MIN;

            while i <= r {
                let start = i;
                while i <= r && s_bytes[i] == s_bytes[start] {
                    i += 1;
                }
                if s_bytes[start] == b'0' {
                    let cur = (i - start) as i32;
                    if prev != i32::MIN && prev + cur > best {
                        best = prev + cur;
                    }
                    prev = cur;
                }
            }
            best
        };

        for i in 0..m {
            let l = queries[i][0] as usize;
            let r = queries[i][1] as usize;
            if r - l + 1 > block_size {
                long_queries.push([l / block_size, l, r, i]);
            } else {
                // 长度小于块长的询问，暴力计算
                ans[i] = cnt1 + brute_force(l, r);
            }
        }

        // 以询问左端点所在块的 ID 为第一关键字，询问右端点为第二关键字排序
        long_queries.sort_by(|a, b| {
            if a[0] != b[0] {
                a[0].cmp(&b[0])
            } else {
                a[2].cmp(&b[2])
            }
        });

        let mut sub_zero_blocks: VecDeque<i32> = VecDeque::new();
        let mut l_ptr: usize = 0;
        let mut r_ptr: usize = 0;
        let mut best_gain: i32 = 0;

        for i in 0..long_queries.len() {
            let bid = long_queries[i][0];
            let l = long_queries[i][1];
            let r = long_queries[i][2];
            let qid = long_queries[i][3];

            if i == 0 || bid > long_queries[i-1][0] {
                // 遍历到一个新的块, 进行初始化操作
                l_ptr = (bid + 1) * block_size - 1; // L 初始化为该块右端点
                r_ptr = (bid + 1) * block_size;      // R 初始化为下一块左端点
                sub_zero_blocks.clear();
                best_gain = 0;
            }

            while r_ptr <= r {
                let mut sz = right[r_ptr] as usize;
                if r - r_ptr + 1 < sz {
                    sz = r - r_ptr + 1;
                }
                if s_bytes[r_ptr] == b'0' {
                    if !sub_zero_blocks.is_empty() && r_ptr > 0 && s_bytes[r_ptr-1] == b'0' {
                        if let Some(back) = sub_zero_blocks.pop_back() {
                            sub_zero_blocks.push_back(back + sz as i32);
                        }
                    } else {
                        sub_zero_blocks.push_back(sz as i32);
                    }
                    if sub_zero_blocks.len() >= 2 {
                        let last = *sub_zero_blocks.back().unwrap();
                        let second_last = sub_zero_blocks[sub_zero_blocks.len() - 2];
                        best_gain = best_gain.max(last + second_last);
                    }
                }
                r_ptr += sz;
            }

            // 移动左端点 L 前，备份 bestGain 的值
            let tmp_best_gain = best_gain;
            // 移动左端点前，subZeroBlocks第一个元素（如果有）的值
            let tmp_first_value = sub_zero_blocks.front().copied();
            // 记录移动左端点 L 的过程中，从左侧加入的数字数量
            let mut cnt = 0;

            while l_ptr >= l {
                let mut sz = left[l_ptr] as usize;
                if l_ptr - l + 1 < sz {
                    sz = l_ptr - l + 1;
                }
                if s_bytes[l_ptr] == b'0' {
                    if !sub_zero_blocks.is_empty() && l_ptr + 1 < n && s_bytes[l_ptr+1] == b'0' {
                        if let Some(front) = sub_zero_blocks.pop_front() {
                            sub_zero_blocks.push_front(front + sz as i32);
                        }
                    } else {
                        sub_zero_blocks.push_front(sz as i32);
                        cnt += 1;
                    }
                    if sub_zero_blocks.len() >= 2 {
                        let first = *sub_zero_blocks.front().unwrap();
                        let second = sub_zero_blocks[1];
                        best_gain = best_gain.max(first + second);
                    }
                }
                if l_ptr >= sz {
                    l_ptr -= sz;
                } else {
                    break;
                }
            }

            // 回答询问
            ans[qid] = best_gain + cnt1;
            // 还原左端点 L
            l_ptr = (bid + 1) * block_size - 1;
            if l_ptr >= n { l_ptr = n - 1; }
            // 还原 bestGain
            best_gain = tmp_best_gain;
            // 还原 subZeroBlocks
            for _ in 0..cnt {
                sub_zero_blocks.pop_front();
            }
            if let Some(first_val) = tmp_first_value {
                if !sub_zero_blocks.is_empty() {
                    sub_zero_blocks.pop_front();
                    sub_zero_blocks.push_front(first_val);
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(q\log q+n\sqrt{n}+q\sqrt{n})$，在 $q$ 和 $n$ 同阶的情况下，近似为 $O(n\sqrt{n})$。具体分析见正文。
- 空间复杂度：$O(n)$。
