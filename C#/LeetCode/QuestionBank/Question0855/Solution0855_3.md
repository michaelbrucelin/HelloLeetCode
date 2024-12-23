#### [方法一：延迟删除 + 有序集合 + 优先队列](https://leetcode.cn/problems/exam-room/solutions/2036518/kao-chang-jiu-zuo-by-leetcode-solution-074y/)

假设有两个学生，他们的位置分别为 $s_1$ 和 $s_2$，我们用区间 $[s_1, s_2]$ 表示他们之间的空闲座位区间。如果固定某一个区间，那么座位选择该区间的中点 $s=s_1 + \lfloor \dfrac{s_2-s_1}{2} \rfloor$ 能够使新进入的学生与离他最近的人之间的距离达到最大化。

由题意可知，我们需要实时地维护这些区间的顺序关系，并且能实时地获取这些区间中最优区间（最优区间：能够使新进入的学生与离他最近的人之间的距离达到最大化），同时还要求实时地删除某个学生占用的座位以及修改对应的区间关系。现成的数据结构并不能很好地满足这些需求，我们尝试将删除区间这一操作延迟到获取最优区间时执行。

使用有序集合 $seats$ 保存已经有学生的座位编号，优先队列 $pq$ 保存座位区间（假设优先队列中的两个区间分别为 $[s_1, s_2]$ 和 $[s_3, s_4]$，那么如果 $\lfloor \dfrac{s_2 - s_1}{2} \rfloor \gt \lfloor \dfrac{s_4 - s_3}{2} \rfloor$ 或者 $\lfloor \dfrac{s_2 - s_1}{2} \rfloor = \lfloor \dfrac{s_4 - s_3}{2} \rfloor \space and \space s_1 \lt s_3$，那么区间 $[s_1, s_2]$ 比区间 $[s_3, s_4]$ 更优）。

- 对于 $seat$ 函数：
    学生进入考场时，有三种情况：
    1. 考场没有一个学生，那么学生只能坐在座位 $0$；
        将座位 $0$ 插入有序集合 $seats$，并且返回座位 $0$。
    2. 考场有超过两位学生，并且选择这些学生所在的座位组成的区间比直接坐在考场的最左或者最右的座位更优；
        首先判断优先队列中最优的区间是否有效（有效指当前区间的左右两个端点的座位有学生，中间的所有座位都没有学生），如果无效，删除该区间。设当前有效区间为 $[s_1, s_2]$，最左的座位跟最左的有学生的座位的距离为 $left$，最右的座位跟最右的有学生的座位的距离为 $right$，如果 $\lfloor \dfrac{s_2 - s_1}{2} \rfloor \gt left$ 且 $\lfloor \dfrac{s_2 - s_1}{2} \rfloor \ge right$，那么选择当前最优区间比直接坐在考场的最左或者最右的座位更优，学生坐下的座位为 $s=s_1 + \lfloor \dfrac{s_2-s_1}{2} \rfloor$，将当前区间从优先队列 $pq$ 中移除，然后分别将新增加的两个区间 $[s_1, s]$ 和 $[s, s_2]$ 插入优先队列 $pq$，将 $s$ 插入有序集合 $seats$，返回座位 $s$。
    3. 考场少于两位学生，或者直接坐在考场的最左或者最右的座位比选择这些学生组成的区间更优。
        如果是最左的座位更优，那么将新增加的区间插入优先队列 $pq$，最左的座位插入有序集合 $seats$，并且返回最左的座位；最右的座位的做法类似。
- 对于 $leave$ 函数：
    如果要删除的座位 $p$ 上的学生不是所有学生的最左或者最右的学生，那么删除该学生会产生新的区间，我们将该区间放入优先队列 $pq$ 中，然后在有序集合 $seats$ 中删除该学生；否则只需要在有序集合 $seats$ 中删除该学生。对于删除座位后已经无效的区间，我们只需要在 $seat$ 函数中判断区间是否有效即可。

```C++
struct Comp {
    bool operator()(const pair<int, int> &p1, const pair<int, int> &p2) {
        int d1 = p1.second - p1.first, d2 = p2.second - p2.first;
        return d1 / 2 < d2 / 2 || (d1 / 2 == d2 / 2 && p1.first > p2.first);
    }
};

class ExamRoom {
private:
    int n;
    set<int> seats;
    priority_queue<pair<int, int>, vector<pair<int, int>>, Comp> pq;

public:
    ExamRoom(int n) : n(n) {
        
    }

    int seat() {
        if (seats.empty()) {
            seats.insert(0);
            return 0;
        }
        int left = *seats.begin(), right = n - 1 - *seats.rbegin();
        while (seats.size() >= 2) {
            auto p = pq.top();
            if (seats.count(p.first) > 0 && seats.count(p.second) > 0 && 
                *next(seats.find(p.first)) == p.second) { // 不属于延迟删除的区间
                int d = p.second - p.first;
                if (d / 2 < right || d / 2 <= left) { // 最左或最右的座位更优
                    break;
                }
                pq.pop();
                pq.push({p.first, p.first + d / 2});
                pq.push({p.first + d / 2, p.second});
                seats.insert(p.first + d / 2);
                return p.first + d / 2;
            }
            pq.pop(); // leave 函数中延迟删除的区间在此时删除
        }
        if (right > left) { // 最右的位置更优
            pq.push({*seats.rbegin(), n - 1});
            seats.insert(n - 1);
            return n - 1;
        } else {
            pq.push({0, *seats.begin()});
            seats.insert(0);
            return 0;
        }
    }

    void leave(int p) {
        if (p != *seats.begin() && p != *seats.rbegin()) {
            auto it = seats.find(p);
            pq.push({*prev(it), *next(it)});
        }
        seats.erase(p);
    }
};
```

```Java
class ExamRoom {
    int n;
    TreeSet<Integer> seats;
    PriorityQueue<int[]> pq;

    public ExamRoom(int n) {
        this.n = n;
        this.seats = new TreeSet<Integer>();
        this.pq = new PriorityQueue<int[]>((a, b) -> {
            int d1 = a[1] - a[0], d2 = b[1] - b[0];
            return d1 / 2 < d2 / 2 || (d1 / 2 == d2 / 2 && a[0] > b[0]) ? 1 : -1;
        });
    }

    public int seat() {
        if (seats.isEmpty()) {
            seats.add(0);
            return 0;
        }
        int left = seats.first(), right = n - 1 - seats.last();
        while (seats.size() >= 2) {
            int[] p = pq.peek();
            if (seats.contains(p[0]) && seats.contains(p[1]) && seats.higher(p[0]) == p[1]) { // 不属于延迟删除的区间
                int d = p[1] - p[0];
                if (d / 2 < right || d / 2 <= left) { // 最左或最右的座位更优
                    break;
                }
                pq.poll();
                pq.offer(new int[]{p[0], p[0] + d / 2});
                pq.offer(new int[]{p[0] + d / 2, p[1]});
                seats.add(p[0] + d / 2);
                return p[0] + d / 2;
            }
            pq.poll(); // leave 函数中延迟删除的区间在此时删除
        }
        if (right > left) { // 最右的位置更优
            pq.offer(new int[]{seats.last(), n - 1});
            seats.add(n - 1);
            return n - 1;
        } else {
            pq.offer(new int[]{0, seats.first()});
            seats.add(0);
            return 0;
        }
    }

    public void leave(int p) {
        if (p != seats.first() && p != seats.last()) {
            int prev = seats.lower(p), next = seats.higher(p);
            pq.offer(new int[]{prev, next});
        }
        seats.remove(p);
    }
}
```

```CSharp
public class ExamRoom {
    private int n;
    private SortedSet<int> seats;
    private PriorityQueue<int[], int[]> pq;

    public ExamRoom(int n) {
        this.n = n;
        this.seats = new SortedSet<int>();
        this.pq = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((p1, p2) => {
            int d1 = p1[1] - p1[0], d2 = p2[1] - p2[0];
            return d1 / 2 == d2 / 2 ? (p1[0] > p2[0] ? 1 : -1) : (d1 / 2 < d2 / 2 ? 1 : -1);
        }));
    }
    
    public int Seat() {
        if (seats.Count == 0) {
            seats.Add(0);
            return 0;
        }
        int left = seats.Min, right = n - 1 - seats.Max;
        while (seats.Count >= 2) {
            var p = pq.Peek();
            if (seats.Contains(p[0]) && seats.Contains(p[1]) && seats.GetViewBetween(p[0] + 1, n - 1).Min == p[1]) { // 不属于延迟删除的区间
                int d = p[1] - p[0];
                if (d / 2 < right || d / 2 <= left) { // 最左或最右的座位更优
                    break;
                }
                pq.Dequeue();
                pq.Enqueue(new int[] {p[0], p[0] + d / 2}, new int[] {p[0], p[0] + d / 2});
                pq.Enqueue(new int[] {p[0] + d / 2, p[1]}, new int[] {p[0] + d / 2, p[1]});
                seats.Add(p[0] + d / 2);
                return p[0] + d / 2;
            }
            pq.Dequeue(); // leave 函数中延迟删除的区间在此时删除
        }
        if (right > left) { // 最右的位置更优
            pq.Enqueue(new int[] {seats.Max, n - 1}, new int[] {seats.Max, n - 1});
            seats.Add(n - 1);
            return n - 1;
        } else {
            pq.Enqueue(new int[] {0, seats.Min}, new int[] {0, seats.Min});
            seats.Add(0);
            return 0;
        }
    }
    
    public void Leave(int p) {
        if (p != seats.Min && p != seats.Max) {
            int prev = seats.GetViewBetween(0, p - 1).Max;
            int next = seats.GetViewBetween(p + 1, n - 1).Min;
            pq.Enqueue(new int[] {prev, next}, new int[] {prev, next});
        }
        seats.Remove(p);
    }
}
```

```Python
from sortedcontainers import SortedSet
import heapq

class Interval:
    def __init__(self, start, end):
        self.start = start
        self.end = end

    def __lt__(self, other):
        d1 = (self.end - self.start) // 2
        d2 = (other.end - other.start) // 2
        if d1 == d2:
            return self.start < other.start
        return d1 > d2

class ExamRoom:
    def __init__(self, n: int):
        self.n = n
        self.seats = SortedSet()
        self.pq = []

    def seat(self) -> int:
        if not self.seats:
            self.seats.add(0)
            return 0

        left = self.seats[0]
        right = self.n - 1 - self.seats[-1]
        while len(self.seats) >= 2:
            p = self.pq[0]
            start, end = p.start, p.end
            if start in self.seats and end in self.seats and self.seats[self.seats.index(start) + 1] == end: # 不属于延迟删除的区间
                d = end - start
                if d // 2 < right or d // 2 <= left:  # 最左或最右的座位更优
                    break
                heapq.heappop(self.pq)
                mid = start + d // 2
                heapq.heappush(self.pq, Interval(start, mid))
                heapq.heappush(self.pq, Interval(mid, end))
                self.seats.add(mid)
                return mid
            heapq.heappop(self.pq) # leave 函数中延迟删除的区间在此时删除

        if right > left: # 最右的位置更优
            heapq.heappush(self.pq, Interval(self.seats[-1], self.n - 1))
            self.seats.add(self.n - 1)
            return self.n - 1
        else:
            heapq.heappush(self.pq, Interval(0, self.seats[0]))
            self.seats.add(0)
            return 0

    def leave(self, p: int) -> None:
        if p != self.seats[0] and p != self.seats[-1]:
            prev = self.seats[self.seats.index(p) - 1]
            next = self.seats[self.seats.index(p) + 1]
            heapq.heappush(self.pq, Interval(prev, next))
        self.seats.remove(p)
```

```Rust
use std::cmp::Ordering;
use std::collections::{BTreeSet, BinaryHeap};

#[derive(Debug, Eq, PartialEq)]
struct Interval {
    start: i32,
    end: i32,
}

impl Interval {
    fn new(start: i32, end: i32) -> Self {
        Interval {start, end}
    }

    fn length(&self) -> i32 {
        (self.end - self.start) / 2
    }
}

impl Ord for Interval {
    fn cmp(&self, other: &Self) -> Ordering {
        let length_cmp = self.length().cmp(&other.length());
        if length_cmp == Ordering::Equal {
            other.start.cmp(&self.start)
        } else {
            length_cmp
        }
    }
}

impl PartialOrd for Interval {
    fn partial_cmp(&self, other: &Self) -> Option<Ordering> {
        Some(self.cmp(other))
    }
}

struct ExamRoom {
    n: i32,
    seats: BTreeSet<i32>,
    pq: BinaryHeap<Interval>,
}

impl ExamRoom {
    fn new(n: i32) -> Self {
        ExamRoom {
            n,
            seats: BTreeSet::new(),
            pq: BinaryHeap::new(),
        }
    }
    
    fn seat(&mut self) -> i32 {
        if self.seats.is_empty() {
            self.seats.insert(0);
            return 0;
        }

        let left = *self.seats.iter().next().unwrap();
        let right = self.n - 1 - *self.seats.iter().rev().next().unwrap();
        while self.seats.len() >= 2 {
            if let Some(interval) = self.pq.peek() {
                let start = interval.start;
                let end = interval.end;
                if self.seats.contains(&start) && self.seats.contains(&end) &&
                   *self.seats.range((start + 1)..).next().unwrap() == end { // 不属于延迟删除的区间
                    let d = end - start;
                    if d / 2 < right || d / 2 <= left { // 最左或最右的座位更优
                        break;
                    }

                    self.pq.pop();
                    let mid = start + d / 2;
                    self.pq.push(Interval::new(start, mid));
                    self.pq.push(Interval::new(mid, end));
                    self.seats.insert(mid);
                    return mid;
                }
            }
            self.pq.pop(); // leave 函数中延迟删除的区间在此时删除
        }

        if right > left { // 最右的位置更优
            let last = *self.seats.iter().rev().next().unwrap();
            self.pq.push(Interval::new(last, self.n - 1));
            self.seats.insert(self.n - 1);
            self.n - 1
        } else {
            let first = *self.seats.iter().next().unwrap();
            self.pq.push(Interval::new(0, first));
            self.seats.insert(0);
            0
        }
    }
    
    fn leave(&mut self, p: i32) {
        if p != *self.seats.iter().next().unwrap() && p != *self.seats.iter().rev().next().unwrap() {
            let prev = *self.seats.range(..p).rev().next().unwrap();
            let next = *self.seats.range((p + 1)..).next().unwrap();
            self.pq.push(Interval::new(prev, next));
        }
        self.seats.remove(&p);
    }
}
```

**复杂度分析**

- 时间复杂度：
    - $seat$ 函数：均摊时间复杂度 $O(\log m)$，其中 $m$ 是调用 $seat$ 函数的次数。因为优先队列最多保存不超过 $2 \times m$ 个元素，所以一次 $seat$ 函数平均只有不超过 $2$ 次的优先队列延迟删除操作，对优先队列和有序集合操作的时间复杂度都是 $O(\log m)$。
    - $leave$ 函数：$O(\log m)$。删除有序集合 $seats$ 的一个元素和优先队列插入一个元素的时间复杂度都是 $O(\log m)$。
- 空间复杂度：$O(m)$。有序集合 $seats$ 和优先队列 $pq$ 中最多保存不超过 $2 \times m$ 个元素。
