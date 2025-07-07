### [两种方法：最小堆 / 并查集（Python/Java/C++/Go/JS/Rust）](https://leetcode.cn/problems/maximum-number-of-events-that-can-be-attended/solutions/3707151/liang-chong-fang-fa-zui-xiao-dui-bing-ch-ijbf/)

#### 方法一：按开始时间分组 + 最小堆

##### 分析

**观察一**：第一天（即开始时间 $startDay_i$ 的最小值）一定要参加会议，若不参加，岂不是白白浪费机会？比如有个会议是 $[1,1]$，不参加就错过了。

> 或者说，对于任意最优解，如果第一天什么也没做，我们总是可以把其中某个会议的参加时间改成第一天。

如果有多个会议的 $startDay_i$ 都相同呢？比如有三个会议 $[1,1],[1,2],[1,3]$，参加哪个会议更好？

**观察二**：参加结束时间 $endDay_i$ 最小的会议。如果第一天不参加会议 $[1,1]$，而是参加会议 $[1,2]$，那么第二天就没法参加会议 $[1,1]$ 了。

参加 $endDay_i$ 最小的会议后，问题变成从第二天开始，解决剩余 $n-1$ 个会议的子问题。

##### 需要知道哪些信息？

在第一天，可以参加哪些会议？

在第二天，可以参加哪些会议？

在第 $i$ 天，可以参加哪些会议？

若按照开始时间分组，那么在第 $i$ 天，开始时间为 $i$ 的会议就是**新增**的可以参加的会议。

此外，还需要知道**在剩余可以参加的会议中，结束时间最小的会议**。根据观察二，参加这个会议。

##### 算法

把会议按照开始时间分组，用 $groups[i]$ 表示所有开始时间为 $i$ 的会议的结束时间。

我们需要一个数据结构维护结束时间。这个数据结构需要支持如下操作：

- 添加结束时间。
- 查询结束时间的最小值。
- 删除最小的结束时间，表示我们参加这个会议，或者这个会议已过期（结束时间小于当前时间）。

**最小堆**完美符合要求。

在第 $i$ 天：

1. 删除最小堆中结束时间小于 $i$ 的会议（已过期）。
2. 把开始时间为 $i$ 的会议的结束时间，加到最小堆中。
3. 如果最小堆不为空，那么弹出堆顶（参加会议），把答案加一。

```Python
class Solution:
    def maxEvents(self, events: List[List[int]]) -> int:
        mx = max(e[1] for e in events) 

        # 按照开始时间分组
        groups = [[] for _ in range(mx + 1)]
        for e in events:
            groups[e[0]].append(e[1])

        ans = 0
        h = []
        for i, g in enumerate(groups):
            # 删除过期会议
            while h and h[0] < i:
                heappop(h)
            # 新增可以参加的会议
            for end_day in g:
                heappush(h, end_day)
            # 参加一个结束时间最早的会议
            if h:
                ans += 1
                heappop(h)
        return ans
```

```Java
class Solution {
    public int maxEvents(int[][] events) {
        int mx = 0;
        for (int[] e : events) {
            mx = Math.max(mx, e[1]);
        }

        // 按照开始时间分组
        List<Integer>[] groups = new ArrayList[mx + 1];
        Arrays.setAll(groups, i -> new ArrayList<>());
        for (int[] e : events) {
            groups[e[0]].add(e[1]);
        }

        int ans = 0;
        PriorityQueue<Integer> pq = new PriorityQueue<>();
        for (int i = 0; i <= mx; i++) {
            // 删除过期会议
            while (!pq.isEmpty() && pq.peek() < i) {
                pq.poll();
            }
            // 新增可以参加的会议
            for (int endDay : groups[i]) {
                pq.offer(endDay);
            }
            // 参加一个结束时间最早的会议
            if (!pq.isEmpty()) {
                ans++;
                pq.poll();
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int maxEvents(vector<vector<int>>& events) {
        int mx = 0;
        for (auto& e : events) {
            mx = max(mx, e[1]);
        }

        // 按照开始时间分组
        vector<vector<int>> groups(mx + 1);
        for (auto& e : events) {
            groups[e[0]].push_back(e[1]);
        }

        int ans = 0;
        priority_queue<int, vector<int>, greater<>> pq;
        for (int i = 0; i <= mx; i++) {
            // 删除过期会议
            while (!pq.empty() && pq.top() < i) {
                pq.pop();
            }
            // 新增可以参加的会议
            for (int end_day : groups[i]) {
                pq.push(end_day);
            }
            // 参加一个结束时间最早的会议
            if (!pq.empty()) {
                ans++;
                pq.pop();
            }
        }
        return ans;
    }
};
```

```Go
func maxEvents(events [][]int) (ans int) {
    mx := 0
    for _, e := range events {
        mx = max(mx, e[1])
    }

    // 按照开始时间分组
    groups := make([][]int, mx+1)
    for _, e := range events {
        groups[e[0]] = append(groups[e[0]], e[1])
    }

    h := &hp{}
    for i, g := range groups {
        // 删除过期会议
        for h.Len() > 0 && h.IntSlice[0] < i {
            heap.Pop(h)
        }
        // 新增可以参加的会议
        for _, endDay := range g {
            heap.Push(h, endDay)
        }
        // 参加一个结束时间最早的会议
        if h.Len() > 0 {
            ans++
            heap.Pop(h)
        }
    }
    return
}

type hp struct{ sort.IntSlice }
func (h *hp) Push(v any) { h.IntSlice = append(h.IntSlice, v.(int)) }
func (h *hp) Pop() any   { a := h.IntSlice; v := a[len(a)-1]; h.IntSlice = a[:len(a)-1]; return v }
```

```JavaScript
var maxEvents = function(events) {
    let mx = 0;
    for (const e of events) {
        mx = Math.max(mx, e[1]);
    }

    // 按照开始时间分组
    const groups = Array.from({ length: mx + 1 }, () => []);
    for (const [startDay, endDay] of events) {
        groups[startDay].push(endDay);
    }

    let ans = 0;
    const pq = new MinPriorityQueue();
    for (let i = 0; i <= mx; i++) {
        // 删除过期会议
        while (!pq.isEmpty() && pq.front() < i) {
            pq.dequeue();
        }
        // 新增可以参加的会议
        for (const endDay of groups[i]) {
            pq.enqueue(endDay);
        }
        // 参加一个结束时间最早的会议
        if (!pq.isEmpty()) {
            pq.dequeue();
            ans++;
        }
    }
    return ans;
};
```

```Rust
use std::collections::BinaryHeap;

impl Solution {
    pub fn max_events(events: Vec<Vec<i32>>) -> i32 {
        let mut mx = 0;
        for e in &events {
            mx = mx.max(e[1]);
        }

        // 按照开始时间分组
        let mut groups = vec![vec![]; (mx + 1) as usize];
        for e in events {
            groups[e[0] as usize].push(e[1]);
        }

        let mut ans = 0;
        let mut h = BinaryHeap::<i32>::new();
        for (i, g) in groups.into_iter().enumerate() {
            // 删除过期会议
            while let Some(end_day) = h.peek() {
                if -end_day >= i as i32 {
                    break;
                }
                h.pop();
            }
            // 新增可以参加的会议
            for end_day in g {
                h.push(-end_day); // 取相反数，变成最小堆
            }
            // 参加一个结束时间最早的会议
            if let Some(_) = h.pop() {
                ans += 1;
            }
        }
        ans
    }
}
```


#### 复杂度分析

- 时间复杂度：$O(U+n\log n)$，其中 $n$ 是 $events$ 的长度，$U=max(endDay_i)$。注意不是 $O(U\log n)$，因为有 $n$ 个会议，所以在 $O(U)$ 天中，只有 $O(n)$ 天在做入堆出堆的操作。可以优化到 $O(n\log n)$，留给读者思考。
- 空间复杂度：$O(n+U)$。

#### 方法二：按结束时间排序 + 并查集

把问题换个表述，大家就很熟悉了：

- 你有 $n$ 门课程要考试，第 $i$ 门课程可以复习的时间段为 $[startDay_i,endDay_i]$。对于每门课程，你可以选择时间段内的一天~速通~复习，一天最多复习一门课程。为了最大化可以复习的课程数，应该如何安排？

优先复习临考（$endDay_i$ 小）的课程，即按照 $endDay_i$ 从小到大排序。对于每门课，选择区间中最早的未被占用的那天复习。

这可以用**并查集**实现：

- 当 $i$ 被占用时，合并 $i$ 和 $i+1$，把 $i$ 指向 $i+1$。
- 如此一来，通过 $find(startDay_i)$ 找到的值，就是 $\ge startDay_i$ 的未被占用的最小值 $x$。如果 $x\le endDay_i$，那么就可以在 $x$ 这一天复习。然后合并 $x$ 和 $x+1$，表示 $x$ 被占用。

```Python
class Solution:
    def maxEvents(self, events: List[List[int]]) -> int:
        events.sort(key=lambda e: e[1])

        mx = events[-1][1]
        fa = list(range(mx + 2))

        def find(x: int) -> int:
            if fa[x] != x:
                fa[x] = find(fa[x])
            return fa[x]

        ans = 0
        for start_day, end_day in events:
            x = find(start_day)  # 查找从 start_day 开始的第一个可用天
            if x <= end_day:
                ans += 1
                fa[x] = x + 1  # 标记 x 已占用
        return ans
```

```Java
class Solution {
    public int maxEvents(int[][] events) {
        Arrays.sort(events, (a, b) -> a[1] - b[1]);

        int mx = events[events.length - 1][1];
        int[] fa = new int[mx + 2];
        for (int i = 0; i < fa.length; i++) {
            fa[i] = i;
        }

        int ans = 0;
        for (int[] e : events) {
            int x = find(e[0], fa); // 查找从 startDay 开始的第一个可用天
            if (x <= e[1]) {
                ans++;
                fa[x] = x + 1; // 标记 x 已占用
            }
        }
        return ans;
    }

    private int find(int x, int[] fa) {
        if (fa[x] != x) {
            fa[x] = find(fa[x], fa);
        }
        return fa[x];
    }
}
```

```C++
class Solution {
public:
    int maxEvents(vector<vector<int>>& events) {
        ranges::sort(events, {}, [](auto& e) { return e[1]; });

        int mx = events.back()[1];
        vector<int> fa(mx + 2);
        ranges::iota(fa, 0);

        auto find = [&](this auto&& find, int x) -> int {
            if (fa[x] != x) {
                fa[x] = find(fa[x]);
            }
            return fa[x];
        };

        int ans = 0;
        for (auto& e : events) {
            int x = find(e[0]); // 查找从 startDay 开始的第一个可用天
            if (x <= e[1]) {
                ans++;
                fa[x] = x + 1; // 标记 x 已占用
            }
        }
        return ans;
    }
};
```

```Go
func maxEvents(events [][]int) (ans int) {
    slices.SortFunc(events, func(a, b []int) int { return a[1] - b[1] })

    mx := events[len(events)-1][1]
    fa := make([]int, mx+2)
    for i := range fa {
        fa[i] = i
    }

    var find func(int) int
    find = func(x int) int {
        if fa[x] != x {
            fa[x] = find(fa[x])
        }
        return fa[x]
    }

    for _, e := range events {
        x := find(e[0]) // 查找从 startDay 开始的第一个可用天
        if x <= e[1] {
            ans++
            fa[x] = x + 1 // 标记 x 已占用
        }
    }
    return
}
```

```JavaScript
var maxEvents = function(events) {
    events.sort((a, b) => a[1] - b[1]);

    const mx = events[events.length - 1][1];
    const fa = _.range(mx + 2);

    function find(x) {
        if (fa[x] !== x) {
            fa[x] = find(fa[x]);
        }
        return fa[x];
    }

    let ans = 0;
    for (const [startDay, endDay] of events) {
        const x = find(startDay); // 查找从 startDay 开始的第一个可用天
        if (x <= endDay) {
            ans++;
            fa[x] = x + 1; // 标记 x 已占用
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn max_events(mut events: Vec<Vec<i32>>) -> i32 {
        events.sort_unstable_by_key(|a| a[1]);

        let mx = events.last().unwrap()[1] as usize;
        let mut fa = (0..=mx+1).collect::<Vec<_>>();

        fn find(x: usize, fa: &mut [usize]) -> usize {
            if fa[x] != x {
                fa[x] = find(fa[x], fa);
            }
            fa[x]
        }

        let mut ans = 0;
        for e in events {
            let x = find(e[0] as usize, &mut fa); // 查找从 startDay 开始的第一个可用天
            if x <= e[1] as usize {
                ans += 1;
                fa[x] = x + 1; // 标记 x 已占用
            }
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(U+n\log n)$，其中 $n$ 是 $events$ 的长度，$U=max(endDay_i)$。
- 空间复杂度：$O(U)$。

**注**：用哈希表实现并查集，可以做到 $O(n\log n)$ 时间和 $O(n)$ 空间。留给感兴趣的读者思考。

#### 相似题目

1. 贪心题单的「**二、区间贪心**」。
2. 数据结构题单的「**五、堆（优先队列）**」。
3. 数据结构题单的「**§7.4 数组上的并查集**」。

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
