### [如何自然引入大小堆？简洁写法！（Python/Java/C++/Go/JS/Rust）](https://leetcode.cn/problems/find-median-from-data-stream/solutions/3015873/ru-he-zi-ran-yin-ru-da-xiao-dui-jian-ji-4v22k/)

比如现在有 $6$ 个数：$1,5,6,2,3,4$，要计算中位数，可以把这 $6$ 个数从小到大排序，得到 $1,2,3,4,5,6$，中间 $3$ 和 $4$ 的平均值 $3.5$ 就是中位数。

回顾一下百科中关于中位数的定义：

> 中位数$\dots \dots$ 可将数值集合划分为相等的两部分。

中位数把这 $6$ 个数均分成了左右两部分，小的那一组记作 $left=[1,2,3]$，大的那一组记作 $right=[4,5,6]$。我们要计算的中位数，就来自 $left$ 中的**最大值**，以及 $right$ 中的**最小值**。

随着 $addNum$ 不断地添加数字，我们需要：

- 保证 $left$ 的大小和 $right$ 的大小尽量相等。**规定**：在有奇数个数时，$left$ 比 $right$ 多 $1$ 个数。
- 保证 $left$ 的所有元素都小于等于 $right$ 的所有元素。

只要时时刻刻满足以上两个要求（满足中位数的定义），我们就可以用 $left$ 中的最大值以及 $right$ 中的最小值计算中位数。

分类讨论：

- 如果当前 $left$ 的大小和 $right$ 的大小相等：
    - 如果添加的数字 $num$ 比较大，比如添加 $7$，那么把 $7$ 加到 $right$ 中。现在 $left$ 比 $right$ 少 $1$ 个数，不符合前文的规定，所以必须把 $right$ 的最小值从 $right$ 中去掉，添加到 $left$ 中。如此操作后，可以保证 $left$ 的所有元素都小于等于 $right$ 的所有元素。
    - 如果添加的数字 $num$ 比较小，比如添加 $0$，那么把 $0$ 加到 $left$ 中。
    - 这两种情况可以**合并**：无论 $num$ 是大是小，都可以先把 $num$ 加到 $right$ 中，然后把 $right$ 的最小值从 $right$ 中去掉，并添加到 $left$ 中。
- 如果当前 $left$ 比 $right$ 多 $1$ 个数：
    - 如果添加的数字 $num$ 比较大，比如添加 $7$，那么把 $7$ 加到 $right$ 中。
    - 如果添加的数字 $num$ 比较小，比如添加 $0$，那么把 $0$ 加到 $left$ 中。现在 $left$ 比 $right$ 多 $2$ 个数，不符合前文的规定，所以必须把 $left$ 的最大值从 $left$ 中去掉，添加到 $right$ 中。如此操作后，可以保证 $left$ 的所有元素都小于等于 $right$ 的所有元素。
    - 这两种情况可以**合并**：无论 $num$ 是大是小，都可以先把 $num$ 加到 $left$ 中，然后把 $left$ 的最大值从 $left$ 中去掉，并添加到 $right$ 中。

最后，我们需要什么样的数据结构？这个数据结构要能高效地执行如下操作：

- 添加元素。
- 找到最大（小）值。
- 删除最大（小）值。

这个数据结构是**堆**。

left 是**最大堆**，$right$ 是**最小堆**。

- 如果当前有奇数个元素，中位数是 $left$ 的堆顶。
- 如果当前有偶数个元素，中位数是 $left$ 的堆顶和 $right$ 的堆顶的平均值。

```Python
class MedianFinder:
    def __init__(self):
        self.left = []  # 最大堆
        self.right = []  # 最小堆

    def addNum(self, num: int) -> None:
        if len(self.left) == len(self.right):
            heappush_max(self.left, heappushpop(self.right, num))
        else:
            heappush(self.right, heappushpop_max(self.left, num))

    def findMedian(self) -> float:
        if len(self.left) > len(self.right):
            return self.left[0]
        return (self.left[0] + self.right[0]) / 2
```

```Java
class MedianFinder {
    private final PriorityQueue<Integer> left = new PriorityQueue<>((a, b) -> b - a); // 最大堆
    private final PriorityQueue<Integer> right = new PriorityQueue<>(); // 最小堆

    public void addNum(int num) {
        if (left.size() == right.size()) {
            right.offer(num);
            left.offer(right.poll());
        } else {
            left.offer(num);
            right.offer(left.poll());
        }
    }

    public double findMedian() {
        if (left.size() > right.size()) {
            return left.peek();
        }
        return (left.peek() + right.peek()) / 2.0;
    }
}
```

```C++
class MedianFinder {
    priority_queue<int> left; // 最大堆
    priority_queue<int, vector<int>, greater<>> right; // 最小堆

public:
    void addNum(int num) {
        if (left.size() == right.size()) {
            right.push(num);
            left.push(right.top());
            right.pop();
        } else {
            left.push(num);
            right.push(left.top());
            left.pop();
        }
    }

    double findMedian() {
        if (left.size() > right.size()) {
            return left.top();
        }
        return (left.top() + right.top()) / 2.0;
    }
};
```

```Go
type MedianFinder struct {
    left  hp // 入堆的元素取相反数，变成最大堆
    right hp // 最小堆
}

func Constructor() (_ MedianFinder) { return }

func (mf *MedianFinder) AddNum(num int) {
    if mf.left.Len() == mf.right.Len() {
        heap.Push(&mf.right, num)
        heap.Push(&mf.left, -heap.Pop(&mf.right).(int))
    } else {
        heap.Push(&mf.left, -num)
        heap.Push(&mf.right, -heap.Pop(&mf.left).(int))
    }
}

func (mf *MedianFinder) FindMedian() float64 {
    if mf.left.Len() > mf.right.Len() {
        return float64(-mf.left.IntSlice[0])
    }
    return float64(mf.right.IntSlice[0]-mf.left.IntSlice[0]) / 2
}

type hp struct{ sort.IntSlice }

func (h *hp) Push(v any) { h.IntSlice = append(h.IntSlice, v.(int)) }
func (h *hp) Pop() any   { a := h.IntSlice; v := a[len(a)-1]; h.IntSlice = a[:len(a)-1]; return v }
```

```Go
// 写法二
type MedianFinder struct {
    left  hp // 入堆的元素取相反数，变成最大堆
    right hp // 最小堆
}

func Constructor() (_ MedianFinder) { return }

func (mf *MedianFinder) AddNum(num int) {
    if mf.left.Len() == mf.right.Len() {
        heap.Push(&mf.left, -mf.right.pushPop(num))
    } else {
        heap.Push(&mf.right, -mf.left.pushPop(-num))
    }
}

func (mf *MedianFinder) FindMedian() float64 {
    if mf.left.Len() > mf.right.Len() {
        return float64(-mf.left.IntSlice[0])
    }
    return float64(mf.right.IntSlice[0]-mf.left.IntSlice[0]) / 2
}

type hp struct{ sort.IntSlice }

func (h *hp) Push(v any) { h.IntSlice = append(h.IntSlice, v.(int)) }
func (hp) Pop() (_ any)  { return }

// pushPop 先将 v 入堆，然后弹出并返回堆顶
func (h *hp) pushPop(v int) int {
    if h.Len() > 0 && v > h.IntSlice[0] {
        v, h.IntSlice[0] = h.IntSlice[0], v
        heap.Fix(h, 0)
    }
    return v
}
```

```JavaScript
var MedianFinder = function() {
    this.left = new MaxPriorityQueue();
    this.right = new MinPriorityQueue();
};

MedianFinder.prototype.addNum = function(num) {
    if (this.left.size() === this.right.size()) {
        this.right.enqueue(num);
        this.left.enqueue(this.right.dequeue());
    } else {
        this.left.enqueue(num);
        this.right.enqueue(this.left.dequeue());
    }
};

MedianFinder.prototype.findMedian = function() {
    if (this.left.size() > this.right.size()) {
        return this.left.front();
    }
    return (this.left.front() + this.right.front()) / 2;
};
```

```Rust
use std::collections::BinaryHeap;

struct MedianFinder {
    left: BinaryHeap<i32>, // 最大堆
    right: BinaryHeap<i32>, // 入堆的元素取相反数，变成最小堆
}

impl MedianFinder {
    fn new() -> Self {
        Self {
            left: BinaryHeap::new(),
            right: BinaryHeap::new(),
        }
    }

    fn add_num(&mut self, num: i32) {
        if self.left.len() == self.right.len() {
            self.right.push(-num);
            self.left.push(-self.right.pop().unwrap());
        } else {
            self.left.push(num);
            self.right.push(-self.left.pop().unwrap());
        }
    }

    fn find_median(&self) -> f64 {
        if self.left.len() > self.right.len() {
            *self.left.peek().unwrap() as _
        } else {
            (*self.left.peek().unwrap() - self.right.peek().unwrap()) as f64 / 2.0
        }
    }
}
```

#### 复杂度分析

- 时间复杂度：初始化和 $findMedian$ 都是 $O(1)$，$addNum$ 是 $O(\log q)$，其中 $q$ 是 $addNum$ 的调用次数。每次操作堆需要 $O(\log q)$ 的时间。
- 空间复杂度：$O(q)$。

#### 思考题

如果还有删除操作（删除数据流中的**任意**元素），要求仍然用堆实现，要怎么做？

见 [480\. 滑动窗口中位数](https://leetcode.cn/problems/sliding-window-median/)。

#### 专题训练

见下面数据结构题单的「**§5.7 对顶堆**」。

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
