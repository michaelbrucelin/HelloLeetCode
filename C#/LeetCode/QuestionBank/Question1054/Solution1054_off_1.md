#### [方法一：最大堆](https://leetcode.cn/problems/distant-barcodes/solutions/2267110/ju-chi-xiang-deng-de-tiao-xing-ma-by-lee-31qt/)

**思路**

题目要求重新排列这些条形码，使其中任意两个相邻的条形码不能相等，可以返回任何满足该要求的答案，并且此题保证存在答案。我们首先想到的思路就是，找到剩余数量最多的元素，尽可能优先排列它。

我们首先统计 $barcodes$ 每个元素的个数，然后遍历这个频数表，把每个元素的 (剩余数量， 元素值) 二元数组，依次插入最大堆。这样操作后，堆顶的元素就是剩余数量最多的元素。

然后我们每次从堆顶拿出一个剩余最多的元素，放入排列中，再更新剩余数量，重新放入最大堆中。如果这个元素和排列结果中的最后一个元素相同，那么我们就需要再从最大堆中取出第二多的元素，放入排列中，之后再把这两个元素放回最大堆中。

依次重复上面的操作，直到我们把所有元素都重新排列。

**代码**

```java
class Solution {
    public int[] rearrangeBarcodes(int[] barcodes) {
        Map<Integer, Integer> count = new HashMap<>();
        for (int b : barcodes) {
            if (!count.containsKey(b)) {
                count.put(b, 0);
            }
            count.put(b, count.get(b) + 1);
        }
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> b[0] - a[0]);
        for (Map.Entry<Integer, Integer> entry : count.entrySet()) {
            pq.offer(new int[]{entry.getValue(), entry.getKey()});
        }
        int n = barcodes.length;
        int[] res = new int[n];
        for (int i = 0; i < n; ++i) {
            int[] p = pq.poll();
            int cx = p[0], x = p[1];
            if (i == 0 || res[i - 1] != x) {
                res[i] = x;
                if (cx > 1) {
                    pq.offer(new int[]{cx - 1, x});
                }
            } else {
                int[] p2 = pq.poll();
                int cy = p2[0], y = p2[1];
                res[i] = y;
                if (cy > 1) {
                    pq.offer(new int[]{cy - 1, y});
                }
                pq.offer(new int[]{cx, x});
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] RearrangeBarcodes(int[] barcodes) {
        IDictionary<int, int> count = new Dictionary<int, int>();
        foreach (int b in barcodes) {
            count.TryAdd(b, 0);
            count[b]++;
        }
        PriorityQueue<Tuple<int, int>, int> pq = new PriorityQueue<Tuple<int, int>, int>();
        foreach (KeyValuePair<int, int> pair in count) {
            pq.Enqueue(new Tuple<int, int>(pair.Value, pair.Key), -pair.Value);
        }
        int n = barcodes.Length;
        int[] res = new int[n];
        for (int i = 0; i < n; ++i) {
            Tuple<int, int> p = pq.Dequeue();
            int cx = p.Item1, x = p.Item2;
            if (i == 0 || res[i - 1] != x) {
                res[i] = x;
                if (cx > 1) {
                    pq.Enqueue(new Tuple<int, int>(cx - 1, x), 1 - cx);
                }
            } else {
                Tuple<int, int> p2 = pq.Dequeue();
                int cy = p2.Item1, y = p2.Item2;
                res[i] = y;
                if (cy > 1) {
                    pq.Enqueue(new Tuple<int, int>(cy - 1, y), 1 - cy);
                }
                pq.Enqueue(new Tuple<int, int>(cx, x), -cx);
            }
        }
        return res;
    }
}
```

```cpp
class Solution {
public:
    vector<int> rearrangeBarcodes(vector<int>& barcodes) {
        unordered_map<int, int> count;
        for (int b : barcodes) {
            count[b]++;
        }
        priority_queue<pair<int, int>> q;
        for (const auto &[x, cx] : count) {
            q.push({cx, x});
        }
        vector<int> res;
        while (q.size()) {
            auto [cx, x] = q.top();
            q.pop();
            if (res.empty() || res.back() != x) {
                res.push_back(x);
                if (cx > 1) {
                    q.push({cx - 1, x});
                }
            } else {
                if (q.size() < 1) return res;
                auto [cy, y] = q.top();
                q.pop();
                res.push_back(y);
                if (cy > 1)  {
                    q.push({cy - 1, y});
                }
                q.push({cx, x});
            }
        }
        return res;
    }
};
```

```python
class Solution:
    def rearrangeBarcodes(self, barcodes: List[int]) -> List[int]:
        count = Counter(barcodes)
        q = []
        for x, cx in count.items():
            heapq.heappush(q, (-cx, x))
        res = []
        while len(q) > 0:
            cx, x = heapq.heappop(q)
            if len(res) == 0 or res[-1] != x:
                res.append(x)
                if cx < -1:
                    heapq.heappush(q, (cx + 1, x))
            else:
                cy, y = heapq.heappop(q)
                res.append(y)
                if cy < -1:
                    heapq.heappush(q, (cy + 1, y))
                heapq.heappush(q, (cx, x))
        return res
```

```go
type PriorityQueue [][]int

func (pq PriorityQueue) Len() int {
    return len(pq)
}
func (pq PriorityQueue) Less(i, j int) bool {
    return pq[i][0] > pq[j][0]
}
func (pq PriorityQueue) Swap(i, j int) {
    pq[i], pq[j] = pq[j], pq[i]
}
func (pq *PriorityQueue) Push(x interface{}) {
    item := x.([]int)
    *pq = append(*pq, item)
}
func (pq *PriorityQueue) Pop() interface{} {
    old := *pq
    n := len(old)
    item := old[n-1]
    *pq = old[:n-1]
    return item
}

func rearrangeBarcodes(barcodes []int) []int {
    count := make(map[int]int)
    for _, b := range barcodes {
        count[b]++
    }
    q := &PriorityQueue{}
    heap.Init(q)
    for k, v := range count {
        heap.Push(q, []int{v, k})
    }
    n := len(barcodes)
    res := make([]int, n)
    for i := 0; i < n; i++ {
        p := heap.Pop(q).([]int)
        cx, x := p[0], p[1]
        if i == 0 || res[i-1] != x {
            res[i] = x
            if cx > 1 {
                heap.Push(q, []int{cx - 1, x})
            }
        } else {
            p2 := heap.Pop(q).([]int)
            cy, y := p2[0], p2[1]
            res[i] = y
            if cy > 1 {
                heap.Push(q, []int{cy - 1, y})
            }
            heap.Push(q, []int{cx, x})
        }
    }
    return res
}
```

```javascript
class MaxHeap {
  constructor(compareFunc = (a, b) => a > b) {
    this.compare = compareFunc;
    this.heap = [];
  }

  get size() {
    return this.heap.length;
  }

  peek() {
    return this.heap[0];
  }

  add(value) {
    this.heap.push(value);
    this.heapifyUp();
  }

  poll() {
    if (this.size === 0) {
      return null;
    }
    if (this.size === 1) {
      return this.heap.pop();
    }
    const max = this.heap[0];
    this.heap[0] = this.heap.pop();
    this.heapifyDown();
    return max;
  }

  heapifyUp() {
    let currentIndex = this.size - 1;
    while (currentIndex > 0) {
      const parentIndex = Math.floor((currentIndex - 1) / 2);
      if (this.compare(this.heap[currentIndex], this.heap[parentIndex])) {
        [this.heap[currentIndex], this.heap[parentIndex]] = [this.heap[parentIndex], this.heap[currentIndex]];
        currentIndex = parentIndex;
      } else {
        break;
      }
    }
  }

  heapifyDown() {
    let currentIndex = 0;
    while (currentIndex < this.size) {
      let largestIndex = currentIndex;
      const leftChildIndex = 2 * currentIndex + 1;
      const rightChildIndex = 2 * currentIndex + 2;
      if (leftChildIndex < this.size && this.compare(this.heap[leftChildIndex], this.heap[largestIndex])) {
        largestIndex = leftChildIndex;
      }
      if (rightChildIndex < this.size && this.compare(this.heap[rightChildIndex], this.heap[largestIndex])) {
        largestIndex = rightChildIndex;
      }
      if (largestIndex !== currentIndex) {
        [this.heap[currentIndex], this.heap[largestIndex]] = [this.heap[largestIndex], this.heap[currentIndex]];
        currentIndex = largestIndex;
      } else {
        break;
      }
    }
  }
}

var rearrangeBarcodes = function(barcodes) {
    const count = new Map();
    for (const b of barcodes) {
        if (!count.has(b)) {
            count.set(b, 0);
        }
        count.set(b, count.get(b) + 1);
    }
    const pq = new MaxHeap((a, b) => a[0] > b[0] || (a[0] === b[0] && a[1] > b[1]));
    for (const [k, v] of count.entries()) {
        pq.add([v, k]);
    }
    const n = barcodes.length;
    const res = new Array(n).fill(0);
    for (let i = 0; i < n; ++i) {
        const p = pq.poll();
        const cx = p[0], x = p[1];
        if (i === 0 || res[i - 1] !== x) {
            res[i] = x;
            if (cx > 1) {
                pq.add([cx - 1, x]);
            }
        } else {
            const p2 = pq.poll();
            const cy = p2[0], y = p2[1];
            res[i] = y;
            if (cy > 1) {
                pq.add([cy - 1, y]);
            }
            pq.add([cx, x]);
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n \log n)$，其中 $n$ 是 $barcodes$ 长度。
-   空间复杂度：$O(n)$，其中 $n$ 是 $barcodes$ 长度。
