### [两种做法：珂朵莉树 / 动态开点线段树（Python/Java/C++/Go）](https://leetcode.cn/problems/count-integers-in-intervals/solutions/1495396/by-endlesscheng-clk2)

思路同 [715. Range 模块](https://leetcode.cn/problems/range-module/)

#### 方法一：珂朵莉树

用一颗平衡树维护**不相交**的区间，每次 add(left,right) 时，删除被该区间覆盖到的区间（部分覆盖也算），然后将被删除的区间与 $[left,right]$ 合并成一个新的大区间（并集），插入平衡树中。

代码实现时，为方便找到第一个被 $[left,right]$ 覆盖到的区间，我们可以用平衡树的 $key$ 存区间右端点，$value$ 存区间左端点。我们要找的就是第一个 $key \ge left$ 的区间。

```python
from sortedcontainers import SortedDict

class CountIntervals:
    def __init__(self):
        self.d = SortedDict()
        self.cnt = 0  # 所有区间长度和

    def add(self, left: int, right: int) -> None:
        # 遍历所有被 [left,right] 覆盖到的区间（部分覆盖也算）
        i = self.d.bisect_left(left)
        while i < len(self.d) and self.d.values()[i] <= right:
            r, l = self.d.items()[i]
            left = min(left, l)    # 合并后的新区间，其左端点为所有被覆盖的区间的左端点的最小值
            right = max(right, r)  # 合并后的新区间，其右端点为所有被覆盖的区间的右端点的最大值
            self.cnt -= r - l + 1
            self.d.popitem(i)
        self.cnt += right - left + 1
        self.d[right] = left  # 所有被覆盖到的区间与 [left,right] 合并成一个新区间

    def count(self) -> int:
        return self.cnt
```

```java
class CountIntervals {
    TreeMap<Integer, Integer> m = new TreeMap<>();
    int cnt; // 所有区间长度和

    public CountIntervals() {}

    public void add(int left, int right) {
        // 遍历所有被 [left,right] 覆盖到的区间（部分覆盖也算）
        for (var e = m.ceilingEntry(left); e != null && e.getValue() <= right; e = m.ceilingEntry(left)) {
            int l = e.getValue(), r = e.getKey();
            left = Math.min(left, l);   // 合并后的新区间，其左端点为所有被覆盖的区间的左端点的最小值
            right = Math.max(right, r); // 合并后的新区间，其右端点为所有被覆盖的区间的右端点的最大值
            cnt -= r - l + 1;
            m.remove(r);
        }
        cnt += right - left + 1;
        m.put(right, left); // 所有被覆盖到的区间与 [left,right] 合并成一个新区间
    }

    public int count() { return cnt; }
}
```

```c++
class CountIntervals {
    map<int, int> m;
    int cnt = 0; // 所有区间长度和

public:
    CountIntervals() {}

    void add(int left, int right) {
        // 遍历所有被 [left,right] 覆盖到的区间（部分覆盖也算）
        for (auto it = m.lower_bound(left); it != m.end() && it->second <= right; m.erase(it++)) {
            int l = it->second, r = it->first;
            left = min(left, l);   // 合并后的新区间，其左端点为所有被覆盖的区间的左端点的最小值
            right = max(right, r); // 合并后的新区间，其右端点为所有被覆盖的区间的右端点的最大值
            cnt -= r - l + 1;
        }
        cnt += right - left + 1;
        m[right] = left; // 所有被覆盖到的区间与 [left,right] 合并成一个新区间
    }

    int count() { return cnt; }
};
```

```go
type CountIntervals struct {
    *redblacktree.Tree
    cnt int // 所有区间长度和
}

func Constructor() CountIntervals {
    return CountIntervals{redblacktree.NewWithIntComparator(), 0}
}

func (t *CountIntervals) Add(left, right int) {
    // 遍历所有被 [left,right] 覆盖到的区间（部分覆盖也算）
    for node, _ := t.Ceiling(left); node != nil && node.Value.(int) <= right; node, _ = t.Ceiling(left) {
        l, r := node.Value.(int), node.Key.(int)
        if l < left { left = l }   // 合并后的新区间，其左端点为所有被覆盖的区间的左端点的最小值
        if r > right { right = r } // 合并后的新区间，其右端点为所有被覆盖的区间的右端点的最大值
        t.cnt -= r - l + 1
        t.Remove(r)
    }
    t.cnt += right - left + 1
    t.Put(right, left) // 所有被覆盖到的区间与 [left,right] 合并成一个新区间
}

func (t *CountIntervals) Count() int { return t.cnt }
```

#### 复杂度分析

- 时间复杂度：每个区间至多被添加删除各一次，因此 add 操作是均摊 $O(\log n)$ 的，这里 $n$ 是 add 的次数。
- 空间复杂度：$O(n)$。

#### 方法二：动态开点线段树

前置知识：线段树、动态开点线段树

完整的动态开点线段树模板见我的 [算法竞赛模板库](https://leetcode.cn/link/?target=https%3A%2F%2Fgithub.com%2FEndlessCheng%2Fcodeforces-go%2Fblob%2Fmaster%2Fcopypasta%2Fsegment_tree.go)。

对于本题来说，线段树的每个节点可以保存对应范围的左右端点 $l$ 和 $r$，以及范围内 add 过的整数个数 $cnt$。

代码实现时，无需记录 lazy tag，这是因为被覆盖的范围无需再次覆盖，因此若 $cnt$ 等于范围的长度 $r-l+1$，则可直接返回。

```python
class CountIntervals:
    __slots__ = 'left', 'right', 'l', 'r', 'cnt'

    def __init__(self, l=1, r=10 ** 9):
        self.left = self.right = None
        self.l, self.r, self.cnt = l, r, 0

    def add(self, l: int, r: int) -> None:
        if self.cnt == self.r - self.l + 1: return  # self 已被完整覆盖，无需执行任何操作
        if l <= self.l and self.r <= r:  # self 已被区间 [l,r] 完整覆盖，不再继续递归
            self.cnt = self.r - self.l + 1
            return
        mid = (self.l + self.r) // 2
        if self.left is None: self.left = CountIntervals(self.l, mid)  # 动态开点
        if self.right is None: self.right = CountIntervals(mid + 1, self.r)  # 动态开点
        if l <= mid: self.left.add(l, r)
        if mid < r: self.right.add(l, r)
        self.cnt = self.left.cnt + self.right.cnt

    def count(self) -> int:
        return self.cnt
```

```java
class CountIntervals {
    CountIntervals left, right;
    int l, r, cnt;

    public CountIntervals() {
        l = 1;
        r = (int) 1e9;
    }

    CountIntervals(int l, int r) {
        this.l = l;
        this.r = r;
    }

    public void add(int L, int R) { // 为方便区分变量名，将递归中始终不变的入参改为大写（视作常量）
        if (cnt == r - l + 1) return; // 当前节点已被完整覆盖，无需执行任何操作
        if (L <= l && r <= R) { // 当前节点已被区间 [L,R] 完整覆盖，不再继续递归
            cnt = r - l + 1;
            return;
        }
        int mid = (l + r) / 2;
        if (left == null) left = new CountIntervals(l, mid); // 动态开点
        if (right == null) right = new CountIntervals(mid + 1, r); // 动态开点
        if (L <= mid) left.add(L, R);
        if (mid < R) right.add(L, R);
        cnt = left.cnt + right.cnt;
    }

    public int count() {
        return cnt;
    }
}
```

```c++
class CountIntervals {
    CountIntervals *left = nullptr, *right = nullptr;
    int l, r, cnt = 0;

public:
    CountIntervals() : l(1), r(1e9) {}

    CountIntervals(int l, int r) : l(l), r(r) {}

    void add(int L, int R) { // 为方便区分变量名，将递归中始终不变的入参改为大写（视作常量）
        if (cnt == r - l + 1) return; // 当前节点已被完整覆盖，无需执行任何操作
        if (L <= l && r <= R) { // 当前节点已被区间 [L,R] 完整覆盖，不再继续递归
            cnt = r - l + 1;
            return;
        }
        int mid = (l + r) / 2;
        if (left == nullptr) left = new CountIntervals(l, mid); // 动态开点
        if (right == nullptr) right = new CountIntervals(mid + 1, r); // 动态开点
        if (L <= mid) left->add(L, R);
        if (mid < R) right->add(L, R);
        cnt = left->cnt + right->cnt;
    }

    int count() { return cnt; }
};
```

```go
type CountIntervals struct {
    left, right *CountIntervals
    l, r, cnt   int
}

func Constructor() CountIntervals { return CountIntervals{l: 1, r: 1e9} }

func (o *CountIntervals) Add(l, r int) {
    if o.cnt == o.r-o.l+1 { return } // o 已被完整覆盖，无需执行任何操作
    if l <= o.l && o.r <= r { // 当前节点已被区间 [l,r] 完整覆盖，不再继续递归
        o.cnt = o.r - o.l + 1
        return
    }
    mid := (o.l + o.r) >> 1
    if o.left == nil { o.left = &CountIntervals{l: o.l, r: mid} } // 动态开点
    if o.right == nil { o.right = &CountIntervals{l: mid + 1, r: o.r} } // 动态开点
    if l <= mid { o.left.Add(l, r)}
    if mid < r { o.right.Add(l, r) }
    o.cnt = o.left.cnt + o.right.cnt
}

func (o *CountIntervals) Count() int { return o.cnt }
```
