### [[Python3/Java/C++/Go] 一题一解：排序 + 离线查询 + 优先队列（小根堆）](https://leetcode.cn/problems/minimum-interval-to-include-each-query/solutions/2348342/python3javacgo-yi-ti-yi-jie-pai-xu-chi-x-5mgt/)

#### 方法一：排序 + 离线查询 + 优先队列（小根堆）

我们注意到，题目中查询的顺序并不会影响答案，并且涉及到的区间也不会发生变化，因此，我们考虑将所有的查询按照从小到大的顺序进行排序，同时将所有的区间按照左端点从小到大的顺序进行排序。

我们使用一个优先队列（小根堆） $pq$ 来维护当前所有的区间，队列的每个元素是一个二元组 $(v, r)$，表示一个区间长度为 $v$，右端点为 $r$ 的区间。初始时，优先队列为空。另外，我们定义一个指针 $i$，指向当前遍历到的区间，初始时 i=0i=0i\=0。

我们按照从小到大的顺序依次遍历每个查询 $(x, j)$，并进行如下操作：

-   如果指针 $i$ 尚未遍历完所有的区间，并且当前遍历到的区间 $[a, b]$ 的左端点小于等于 $x$，那么我们将该区间加入优先队列中，并将指针 $i$ 后移一位，循环此过程；
-   如果优先队列不为空，并且堆顶元素的区间右端点小于 $x$，那么我们将堆顶元素弹出，循环此过程；
-   此时，如果优先队列不为空，那么堆顶元素就是包含 $x$ 的最小区间。我们将其长度 $v$ 加入答案数组 $ans$ 中。

在上述过程结束后，我们返回答案数组 $ans$ 即可。

```python
class Solution:
    def minInterval(self, intervals: List[List[int]], queries: List[int]) -> List[int]:
        n, m = len(intervals), len(queries)
        intervals.sort()
        queries = sorted((x, i) for i, x in enumerate(queries))
        ans = [-1] * m
        pq = []
        i = 0
        for x, j in queries:
            while i < n and intervals[i][0] <= x:
                a, b = intervals[i]
                heappush(pq, (b - a + 1, b))
                i += 1
            while pq and pq[0][1] < x:
                heappop(pq)
            if pq:
                ans[j] = pq[0][0]
        return ans
```

```java
class Solution {
    public int[] minInterval(int[][] intervals, int[] queries) {
        int n = intervals.length, m = queries.length;
        Arrays.sort(intervals, (a, b) -> a[0] - b[0]);
        int[][] qs = new int[m][0];
        for (int i = 0; i < m; ++i) {
            qs[i] = new int[] {queries[i], i};
        }
        Arrays.sort(qs, (a, b) -> a[0] - b[0]);
        int[] ans = new int[m];
        Arrays.fill(ans, -1);
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> a[0] - b[0]);
        int i = 0;
        for (int[] q : qs) {
            while (i < n && intervals[i][0] <= q[0]) {
                int a = intervals[i][0], b = intervals[i][1];
                pq.offer(new int[] {b - a + 1, b});
                ++i;
            }
            while (!pq.isEmpty() && pq.peek()[1] < q[0]) {
                pq.poll();
            }
            if (!pq.isEmpty()) {
                ans[q[1]] = pq.peek()[0];
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    vector<int> minInterval(vector<vector<int>>& intervals, vector<int>& queries) {
        int n = intervals.size(), m = queries.size();
        sort(intervals.begin(), intervals.end());
        using pii = pair<int, int>;
        vector<pii> qs;
        for (int i = 0; i < m; ++i) {
            qs.emplace_back(queries[i], i);
        }
        sort(qs.begin(), qs.end());
        vector<int> ans(m, -1);
        priority_queue<pii, vector<pii>, greater<pii>> pq;
        int i = 0;
        for (auto& [x, j] : qs) {
            while (i < n && intervals[i][0] <= x) {
                int a = intervals[i][0], b = intervals[i][1];
                pq.emplace(b - a + 1, b);
                ++i;
            }
            while (!pq.empty() && pq.top().second < x) {
                pq.pop();
            }
            if (!pq.empty()) {
                ans[j] = pq.top().first;
            }
        }
        return ans;
    }
};
```

```go
func minInterval(intervals [][]int, queries []int) []int {
    n, m := len(intervals), len(queries)
    sort.Slice(intervals, func(i, j int) bool { return intervals[i][0] < intervals[j][0] })
    qs := make([][2]int, m)
    ans := make([]int, m)
    for i := range qs {
        qs[i] = [2]int{queries[i], i}
        ans[i] = -1
    }
    sort.Slice(qs, func(i, j int) bool { return qs[i][0] < qs[j][0] })
    pq := hp{}
    i := 0
    for _, q := range qs {
        x, j := q[0], q[1]
        for i < n && intervals[i][0] <= x {
            a, b := intervals[i][0], intervals[i][1]
            heap.Push(&pq, pair{b - a + 1, b})
            i++
        }
        for len(pq) > 0 && pq[0].r < x {
            heap.Pop(&pq)
        }
        if len(pq) > 0 {
            ans[j] = pq[0].v
        }
    }
    return ans
}

type pair struct{ v, r int }
type hp []pair

func (h hp) Len() int            { return len(h) }
func (h hp) Less(i, j int) bool  { return h[i].v < h[j].v }
func (h hp) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *hp) Push(v interface{}) { *h = append(*h, v.(pair)) }
func (h *hp) Pop() interface{}   { a := *h; v := a[len(a)-1]; *h = a[:len(a)-1]; return v }
```

时间复杂度 $O(n \times \log n + m \times \log m)$，空间复杂度 $O(n + m)$。其中 $n$ 和 $m$ 分别是数组 $intervals$ 和 $queries$ 的长度。
