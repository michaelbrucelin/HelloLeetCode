#### [前言](https://leetcode.cn/problems/the-k-weakest-rows-in-a-matrix/solutions/130589/fang-zhen-zhong-zhan-dou-li-zui-ruo-de-k-xing-by-l/)

由于本题中的矩阵行数 $m$ 和列数 $n$ 均不超过 $100$，数据规模较小，因此我们可以设计出一些时间复杂度较高的方法，例如直接对整个矩阵进行一次遍历，计算出每一行的战斗力，再进行排序并返回最弱的 $k$ 行的索引。

下面我们根据矩阵的性质，给出一种时间复杂度较为优秀的方法。

#### [方法一：二分查找 + 堆](https://leetcode.cn/problems/the-k-weakest-rows-in-a-matrix/solutions/130589/fang-zhen-zhong-zhan-dou-li-zui-ruo-de-k-xing-by-l/)

**思路与算法**

题目描述中有一条重要的保证：

> 军人**总是**排在一行中的靠前位置，也就是说 $1$ 总是出现在 $0$ 之前。

因此，我们可以通过二分查找的方法，找出一行中最后的那个 $1$ 的位置。如果其位置为 $pos$，那么这一行 $1$ 的个数就为 $pos + 1$。特别地，如果这一行没有 $1$，那么令 $pos=-1$。

当我们得到每一行的战斗力后，我们可以将它们全部放入一个小根堆中，并不断地取出堆顶的元素 $k$ 次，这样我们就得到了最弱的 $k$ 行的索引。

需要注意的是，如果我们依次将每一行的战斗力以及索引（因为如果战斗力相同，索引较小的行更弱，所以我们需要在小根堆中存放战斗力和索引的二元组）放入小根堆中，那么这样做的时间复杂度是 $O(m \log m)$ 的。一种更好的方法是使用这 $m$ 个战斗力值直接初始化一个小根堆，时间复杂度为 $O(m)$。读者可以参考《算法导论》的 6.3\\text{6.3}6.3 节或者[「堆排序中建堆过程时间复杂度 $O(n)$ 怎么来的？」](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.zhihu.com%2Fquestion%2F20729324)了解该过程时间复杂度的证明方法。

**代码**

```cpp
class Solution {
public:
    vector<int> kWeakestRows(vector<vector<int>>& mat, int k) {
        int m = mat.size(), n = mat[0].size();
        vector<pair<int, int>> power;
        for (int i = 0; i < m; ++i) {
            int l = 0, r = n - 1, pos = -1;
            while (l <= r) {
                int mid = (l + r) / 2;
                if (mat[i][mid] == 0) {
                    r = mid - 1;
                }
                else {
                    pos = mid;
                    l = mid + 1;
                }
            }
            power.emplace_back(pos + 1, i);
        }

        priority_queue q(greater<pair<int, int>>(), move(power));
        vector<int> ans;
        for (int i = 0; i < k; ++i) {
            ans.push_back(q.top().second);
            q.pop();
        }
        return ans;
    }
};
```

```java
class Solution {
    public int[] kWeakestRows(int[][] mat, int k) {
        int m = mat.length, n = mat[0].length;
        List<int[]> power = new ArrayList<int[]>();
        for (int i = 0; i < m; ++i) {
            int l = 0, r = n - 1, pos = -1;
            while (l <= r) {
                int mid = (l + r) / 2;
                if (mat[i][mid] == 0) {
                    r = mid - 1;
                } else {
                    pos = mid;
                    l = mid + 1;
                }
            }
            power.add(new int[]{pos + 1, i});
        }

        PriorityQueue<int[]> pq = new PriorityQueue<int[]>(new Comparator<int[]>() {
            public int compare(int[] pair1, int[] pair2) {
                if (pair1[0] != pair2[0]) {
                    return pair1[0] - pair2[0];
                } else {
                    return pair1[1] - pair2[1];
                }
            }
        });
        for (int[] pair : power) {
            pq.offer(pair);
        }
        int[] ans = new int[k];
        for (int i = 0; i < k; ++i) {
            ans[i] = pq.poll()[1];
        }
        return ans;
    }
}
```

```python
class Solution:
    def kWeakestRows(self, mat: List[List[int]], k: int) -> List[int]:
        m, n = len(mat), len(mat[0])
        power = list()
        for i in range(m):
            l, r, pos = 0, n - 1, -1
            while l <= r:
                mid = (l + r) // 2
                if mat[i][mid] == 0:
                    r = mid - 1
                else:
                    pos = mid
                    l = mid + 1
            power.append((pos + 1, i))

        heapq.heapify(power)
        ans = list()
        for i in range(k):
            ans.append(heapq.heappop(power)[1])
        return ans
```

```go
func kWeakestRows(mat [][]int, k int) []int {
    h := hp{}
    for i, row := range mat {
        pow := sort.Search(len(row), func(j int) bool { return row[j] == 0 })
        h = append(h, pair{pow, i})
    }
    heap.Init(&h)
    ans := make([]int, k)
    for i := range ans {
        ans[i] = heap.Pop(&h).(pair).idx
    }
    return ans
}

type pair struct{ pow, idx int }
type hp []pair

func (h hp) Len() int            { return len(h) }
func (h hp) Less(i, j int) bool  { a, b := h[i], h[j]; return a.pow < b.pow || a.pow == b.pow && a.idx < b.idx }
func (h hp) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *hp) Push(v interface{}) { *h = append(*h, v.(pair)) }
func (h *hp) Pop() interface{}   { a := *h; v := a[len(a)-1]; *h = a[:len(a)-1]; return v }
```

**复杂度分析**

-   时间复杂度：$O(m \log n + k \log m)$：
    -   我们需要 $O(m \log n)$ 的时间对每一行进行二分查找。
    -   我们需要 $O(m)$ 的时间建立小根堆。
    -   我们需要 $O(k \log m)$ 的时间从堆中取出 $k$ 个最小的元素。
-   空间复杂度：$O(m)$，即为堆需要使用的空间。
