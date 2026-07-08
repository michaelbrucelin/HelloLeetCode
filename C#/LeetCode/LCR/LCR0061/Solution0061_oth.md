### [讲清楚为什么一开始要把 (i,0) 都入堆！附题单！](https://leetcode.cn/problems/qn8gGX/solutions/2564218/jiang-qing-chu-wei-shi-yao-yi-kai-shi-ya-d3na/?envType=problem-list-v2&envId=ySsxoJfz)

#### 一、初步思路

为描述方便，下文把 $nums_1$ 记作 $a$，$nums_2$ 记作 $b$。

由于数组是有序的，$(a[0],b[0])$ 是和最小的数对，计入答案。并且次小的只能是 $(a[0],b[1])$ 或 $(a[1],b[0])$，因为其它没有计入答案的数对和不会比这两个更小。

$(a[0],b[1])$ 和 $(a[1],b[0])$ 这两个数对和的大小还好比较，但如果要求第 $k$ 小，就要涉及到更多的数对，那样就更加复杂了。如何按从小到大的顺序**快速地**求出这些数对呢？

#### 二、一个复杂的算法

为了更高效地比大小，我们可以借助最小堆来优化。

堆中保存下标对 $(i,j)$，即可能成为下一个数对的 $a$ 的下标 $i$ 和 $b$ 的下标 $j$。堆顶是最小的 $a[i]+b[j]$。

初始把 $(0,0)$ 入堆。

每次出堆时，可能成为下一个数对的是 $(i+1,j)$ 和 $(i,j+1)$，这俩入堆。（和「初步思路」中的讨论一样，其它的不会比这两个更小。）

但这会导致一个问题：例如当 $(1,0)$ 出堆时，会把 $(1,1)$ 入堆；当 $(0,1)$ 出堆时，也会把 $(1,1)$ 入堆，这样堆中会有重复元素。为了避免有重复元素，还需要额外用一个哈希表记录在堆中的下标对。只有当下标对不在堆中时，才能入堆。

能否不用哈希表呢？

#### 三、优化后的算法

换个角度，如果要把 $(i,j)$ 入堆，那么**出堆**的下标对是什么？

根据上面的讨论，出堆的下标对只能是 $(i-1,j)$ 和 $(i,j-1)$。

只要保证 $(i-1,j)$ 和 $(i,j-1)$ 的**其中一个**会将 $(i,j)$ 入堆，而另一个**什么也不做**，就不会出现重复了！

不妨规定 $(i,j-1)$ 出堆时，将 $(i,j)$ 入堆；而 $(i-1,j)$ 出堆时只计入答案，其它什么也不做。

换句话说，在 $(i,j)$ 出堆时，只需将 $(i,j+1)$ 入堆，无需将 $(i+1,j)$ 入堆。

但若按照该规则，初始仅把 $(0,0)$ 入堆的话，只会得到 $(0,1),(0,2),\dots $ 这些下标对。

所以初始不仅要把 $(0,0)$ 入堆，$(1,0),(2,0),\dots $ 这些都要入堆。

代码实现时，为了方便比较大小，实际入堆的是三元组 $(a[i]+b[j],i,j)$。

```Python
class Solution:
    def kSmallestPairs(self, nums1: List[int], nums2: List[int], k: int) -> List[List[int]]:
        ans = []
        h = [(nums1[i] + nums2[0], i, 0) for i in range(min(len(nums1), k))]
        while h and len(ans) < k:
            _, i, j = heappop(h)
            ans.append([nums1[i], nums2[j]])
            if j + 1 < len(nums2):
                heappush(h, (nums1[i] + nums2[j + 1], i, j + 1))
        return ans
```

```Java
class Solution {
    public List<List<Integer>> kSmallestPairs(int[] nums1, int[] nums2, int k) {
        int n = nums1.length, m = nums2.length;
        var ans = new ArrayList<List<Integer>>(k); // 预分配空间
        var pq = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);
        for (int i = 0; i < Math.min(n, k); i++) // 至多 k 个
            pq.add(new int[]{nums1[i] + nums2[0], i, 0});
        while (!pq.isEmpty() && ans.size() < k) {
            var p = pq.poll();
            int i = p[1], j = p[2];
            ans.add(List.of(nums1[i], nums2[j]));
            if (j + 1 < m)
                pq.add(new int[]{nums1[i] + nums2[j + 1], i, j + 1});
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    vector<vector<int>> kSmallestPairs(vector<int> &nums1, vector<int> &nums2, int k) {
        vector<vector<int>> ans;
        priority_queue<tuple<int, int, int>> pq;
        int n = nums1.size(), m = nums2.size();
        for (int i = 0; i < min(n, k); i++) // 至多 k 个
            pq.emplace(-nums1[i] - nums2[0], i, 0); // 取相反数变成小顶堆
        while (!pq.empty() && ans.size() < k) {
            auto [_, i, j] = pq.top();
            pq.pop();
            ans.push_back({nums1[i], nums2[j]});
            if (j + 1 < m)
                pq.emplace(-nums1[i] - nums2[j + 1], i, j + 1);
        }
        return ans;
    }
};
```

```Go
func kSmallestPairs(nums1, nums2 []int, k int) [][]int {
    n, m := len(nums1), len(nums2)
    ans := make([][]int, 0, min(k, n*m)) // 预分配空间
    h := make(hp, min(k, n))
    for i := range h {
        h[i] = tuple{nums1[i] + nums2[0], i, 0}
    }
    for len(h) > 0 && len(ans) < k {
        p := heap.Pop(&h).(tuple)
        i, j := p.i, p.j
        ans = append(ans, []int{nums1[i], nums2[j]})
        if j+1 < m {
            heap.Push(&h, tuple{nums1[i] + nums2[j+1], i, j + 1})
        }
    }
    return ans
}

type tuple struct{ s, i, j int }
type hp []tuple
func (h hp) Len() int           { return len(h) }
func (h hp) Less(i, j int) bool { return h[i].s < h[j].s }
func (h hp) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }
func (h *hp) Push(v any)        { *h = append(*h, v.(tuple)) }
func (h *hp) Pop() any          { a := *h; v := a[len(a)-1]; *h = a[:len(a)-1]; return v }
func min(a, b int) int { if b < a { return b }; return a }
```

也可以在循环的过程中去把 $(i,0)$ 入堆。由于一开始堆的大小不大，出堆入堆更快，整体效率更高。

```Python
class Solution:
    def kSmallestPairs(self, nums1: List[int], nums2: List[int], k: int) -> List[List[int]]:
        ans = []
        h = [(nums1[0] + nums2[0], 0, 0)]
        while h and len(ans) < k:
            _, i, j = heappop(h)
            ans.append([nums1[i], nums2[j]])
            if j == 0 and i + 1 < len(nums1):
                heappush(h, (nums1[i + 1] + nums2[0], i + 1, 0))
            if j + 1 < len(nums2):
                heappush(h, (nums1[i] + nums2[j + 1], i, j + 1))
        return ans
```

```Java
class Solution {
    public List<List<Integer>> kSmallestPairs(int[] nums1, int[] nums2, int k) {
        int n = nums1.length, m = nums2.length;
        var ans = new ArrayList<List<Integer>>(k); // 预分配空间
        var pq = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);
        pq.add(new int[]{nums1[0] + nums2[0], 0, 0});
        while (!pq.isEmpty() && ans.size() < k) {
            var p = pq.poll();
            int i = p[1], j = p[2];
            ans.add(List.of(nums1[i], nums2[j]));
            if (j == 0 && i + 1 < n)
                pq.add(new int[]{nums1[i + 1] + nums2[0], i + 1, 0});
            if (j + 1 < m)
                pq.add(new int[]{nums1[i] + nums2[j + 1], i, j + 1});
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    vector<vector<int>> kSmallestPairs(vector<int> &nums1, vector<int> &nums2, int k) {
        vector<vector<int>> ans;
        priority_queue<tuple<int, int, int>> pq;
        int n = nums1.size(), m = nums2.size();
        pq.emplace(-nums1[0] - nums2[0], 0, 0); // 取相反数变成小顶堆
        while (!pq.empty() && ans.size() < k) {
            auto [_, i, j] = pq.top();
            pq.pop();
            ans.push_back({nums1[i], nums2[j]});
            if (j == 0 && i + 1 < n)
                pq.emplace(-nums1[i + 1] - nums2[0], i + 1, 0);
            if (j + 1 < m)
                pq.emplace(-nums1[i] - nums2[j + 1], i, j + 1);
        }
        return ans;
    }
};
```

```Go
func kSmallestPairs(nums1, nums2 []int, k int) [][]int {
    n, m := len(nums1), len(nums2)
    ans := make([][]int, 0, min(k, n*m)) // 预分配空间
    h := hp{{nums1[0] + nums2[0], 0, 0}}
    for len(h) > 0 && len(ans) < k {
        p := heap.Pop(&h).(tuple)
        i, j := p.i, p.j
        ans = append(ans, []int{nums1[i], nums2[j]})
        if j == 0 && i+1 < n {
            heap.Push(&h, tuple{nums1[i+1] + nums2[0], i + 1, 0})
        }
        if j+1 < m {
            heap.Push(&h, tuple{nums1[i] + nums2[j+1], i, j + 1})
        }
    }
    return ans
}

type tuple struct{ s, i, j int }
type hp []tuple
func (h hp) Len() int           { return len(h) }
func (h hp) Less(i, j int) bool { return h[i].s < h[j].s }
func (h hp) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }
func (h *hp) Push(v any)        { *h = append(*h, v.(tuple)) }
func (h *hp) Pop() any          { a := *h; v := a[len(a)-1]; *h = a[:len(a)-1]; return v }
func min(a, b int) int { if b < a { return b }; return a }
```

#### 复杂度分析

- 时间复杂度：$O(k\log min(n,k))$，其中 $n$ 为 $nums_1$ 的长度。为了得到 $k$ 个数对，需要循环 $k$ 次，每次出堆入堆的时间复杂度为 $\log min(n,k)$。所以总的时间复杂度为 $O(k\log min(n,k))$。
- 空间复杂度：$O(min(n,k))$。堆中至多有 $O(min(n,k))$ 个三元组。

#### 相似题目（第 $k$ 小/大）

- [373\. 查找和最小的 K 对数字](https://leetcode.cn/problems/find-k-pairs-with-smallest-sums/)
- [378\. 有序矩阵中第 K 小的元素](https://leetcode.cn/problems/kth-smallest-element-in-a-sorted-matrix/)
- [719\. 找出第 K 小的数对距离](https://leetcode.cn/problems/find-k-th-smallest-pair-distance/)
- [786\. 第 K 个最小的素数分数](https://leetcode.cn/problems/k-th-smallest-prime-fraction/)
- [2040\. 两个有序数组的第 K 小乘积](https://leetcode.cn/problems/kth-smallest-product-of-two-sorted-arrays/)
- [2386\. 找出数组的第 K 大和](https://leetcode.cn/problems/find-the-k-sum-of-an-array/)
