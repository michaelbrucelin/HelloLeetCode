#### [方法二：贪心 + 优先队列](https://leetcode.cn/problems/o8SXZn/solutions/2276388/xu-shui-by-leetcode-solution-g4lx/)

**思路与算法**

因为「升级水桶」操作都在「蓄水」操作之前，所以若现在在「蓄水」操作前第 $i$ 个水桶的容量为 $bucket'[i]$，$0 \le i < n$，则需要「蓄水」的操作至少为

$$\max\{\lceil{\frac{vat[i]}{bucket'[i]}}\rceil\}$$

即此时总的操作次数为

$$\sum_{j = 0}^{n - 1}{(bucket'[i] - bucket[i])} + \max\{\lceil{\frac{vat[i]}{bucket'[i]}}\rceil\}$$

因为需要「蓄水」的操作次数只与 $n$ 个水缸中需要「蓄水」操作的最大值决定。所以若此时我们想减少总的操作次数，我们只能尝试选择需要进行最多次「蓄水」操作的水缸，在进行「蓄水」前对其配备的水桶进行「升级水桶」操作，使得其需要的「蓄水」操作至少减少 $1$。

我们可以用「最大堆」（「优先队列」）来实现以上操作。我们以二元组 $(cnt_i, i)$ 来表示第 $i$ 个水缸需要的「蓄水」操作 $cnt_i$ 次。从初始时将每一个水缸对应的二元组加入「最大堆」，其中需要注意某若一个水缸需要的蓄水要求为 $0$ 时可以直接忽略该水缸，和若某一个水缸配备的水桶初始容量为 $0$ 时且水缸的蓄水要求大于 $0$ 时，为了避免无法达到蓄水要求，此时需要进行一次「升级水桶」操作。然后我们每次尝试进行减小总的操作次数——从「最大堆」中取出需要「蓄水」操作最多的水桶，并进行「升级水桶」操作使得其需要的「蓄水」操作至少减少 $1$，然后再次放入「最大堆」中，并更新当前需要的总的操作次数最小值，直到当「升级水桶」的操作次数已经不能再减少总的操作次数为止：

-   「升级水桶」的次数已经大于等于当前已得的总操作次数最小值；
-   此时需要的「蓄水」操作等于 $1$。

**代码**

```cpp
class Solution {
public:
    int storeWater(vector<int>& bucket, vector<int>& vat) {
        int n = bucket.size();
        priority_queue<pair<int, int>> q;
        int cnt = 0;
        for (int i = 0; i < n; ++i) {
            if (bucket[i] == 0 && vat[i]) {
                ++cnt;
                ++bucket[i];
            }
            if (vat[i] > 0) {
                q.emplace((vat[i] + bucket[i] - 1) / bucket[i], i);
            }
        }
        if (q.empty()) {
            return 0;
        }
        int res = INT_MAX;
        while (cnt < res) {
            auto [v, i] = q.top();
            res = min(res, cnt + v);
            if (v == 1) {
                break;
            }
            q.pop();
            int t = (vat[i] + v - 2) / (v - 1);
            cnt += t - bucket[i];
            bucket[i] = t;
            q.emplace((vat[i] + bucket[i] - 1) / bucket[i], i);
        }
        return res;
    }
};
```

```java
class Solution {
    public int storeWater(int[] bucket, int[] vat) {
        int n = bucket.length;
        PriorityQueue<int[]> pq = new PriorityQueue<int[]>((a, b) -> b[0] - a[0]);
        int cnt = 0;
        for (int i = 0; i < n; ++i) {
            if (bucket[i] == 0 && vat[i] != 0) {
                ++cnt;
                ++bucket[i];
            }
            if (vat[i] > 0) {
                pq.offer(new int[]{(vat[i] + bucket[i] - 1) / bucket[i], i});
            }
        }
        if (pq.isEmpty()) {
            return 0;
        }
        int res = Integer.MAX_VALUE;
        while (cnt < res) {
            int[] arr = pq.poll();
            int v = arr[0], i = arr[1];
            res = Math.min(res, cnt + v);
            if (v == 1) {
                break;
            }
            int t = (vat[i] + v - 2) / (v - 1);
            cnt += t - bucket[i];
            bucket[i] = t;
            pq.offer(new int[]{(vat[i] + bucket[i] - 1) / bucket[i], i});
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int StoreWater(int[] bucket, int[] vat) {
        int n = bucket.Length;
        PriorityQueue<Tuple<int, int>, int> pq = new PriorityQueue<Tuple<int, int>, int>();
        int cnt = 0;
        for (int i = 0; i < n; ++i) {
            if (bucket[i] == 0 && vat[i] != 0) {
                ++cnt;
                ++bucket[i];
            }
            if (vat[i] > 0) {
                pq.Enqueue(new Tuple<int, int>((vat[i] + bucket[i] - 1) / bucket[i], i), -(vat[i] + bucket[i] - 1) / bucket[i]);
            }
        }
        if (pq.Count == 0) {
            return 0;
        }
        int res = int.MaxValue;
        while (cnt < res) {
            Tuple<int, int> tuple = pq.Dequeue();
            int v = tuple.Item1, i = tuple.Item2;
            res = Math.Min(res, cnt + v);
            if (v == 1) {
                break;
            }
            int t = (vat[i] + v - 2) / (v - 1);
            cnt += t - bucket[i];
            bucket[i] = t;
            pq.Enqueue(new Tuple<int, int>((vat[i] + bucket[i] - 1) / bucket[i], i), -(vat[i] + bucket[i] - 1) / bucket[i]);
        }
        return res;
    }
}
```

```python
class Solution:
    def storeWater(self, bucket: List[int], vat: List[int]) -> int:
        n = len(bucket)
        pq = []
        cnt = 0
        for i in range(n):
            if bucket[i] == 0 and vat[i]:
                cnt += 1
                bucket[i] += 1
            if vat[i] > 0:
                heapq.heappush(pq, [-((vat[i] + bucket[i] - 1) // bucket[i]), i])
        if not pq:
            return 0
        res = float('inf')
        while cnt < res:
            v, i = heapq.heappop(pq)
            v = -v
            res = min(res, cnt + v)
            if v == 1:
                break
            t = (vat[i] + v - 2) // (v - 1)
            cnt += t - bucket[i]
            bucket[i] = t
            heapq.heappush(pq, [-((vat[i] + bucket[i] - 1) // bucket[i]), i])
        return res
```

```go
func storeWater(bucket []int, vat []int) int {
    n := len(bucket)
    pq := make(priorityQueue, 0)
    cnt := 0
    for i := 0; i < n; i++ {
        if bucket[i] == 0 && vat[i] > 0 {
            cnt++
            bucket[i]++
        }
        if vat[i] > 0 {
            heap.Push(&pq, &item{priority: -(vat[i] + bucket[i] - 1) / bucket[i], index: i})
        }
    }
    if pq.Len() == 0 {
        return 0
    }
    res := math.MaxInt32
    for cnt < res {
        it := heap.Pop(&pq).(*item)
        v, i := -it.priority, it.index
        res = min(res, cnt+v)
        if v == 1 {
            break
        }
        t := (vat[i] + v - 2) / (v - 1)
        cnt += t - bucket[i]
        bucket[i] = t
        heap.Push(&pq, &item{priority: -(vat[i] + bucket[i] - 1) / bucket[i], index: i})
    }
    return res
}

type item struct {
    priority int
    index    int
}

type priorityQueue []*item

func (pq priorityQueue) Len() int {
    return len(pq)
}

func (pq priorityQueue) Less(i, j int) bool {
    return pq[i].priority < pq[j].priority
}

func (pq priorityQueue) Swap(i, j int) {
    pq[i], pq[j] = pq[j], pq[i]
}

func (pq *priorityQueue) Push(x interface{}) {
    item := x.(*item)
    *pq = append(*pq, item)
}

func (pq *priorityQueue) Pop() interface{} {
    n := len(*pq)
    item := (*pq)[n-1]
    *pq = (*pq)[:n-1]
    return item
}

func min(x, y int) int {
    if x < y {
        return x
    }
    return y
}
```

```javascript
var storeWater = function(bucket, vat) {
    const n = bucket.length;
    const pq = new MaxHeap((a, b) => a[0] > b[0]);
    let cnt = 0;
    for (let i = 0; i < n; ++i) {
        if (bucket[i] === 0 && vat[i] !== 0) {
            ++cnt;
            ++bucket[i];
        }
        if (vat[i] > 0) {
            pq.add([Math.floor((vat[i] + bucket[i] - 1) / bucket[i]), i]);
        }
    }
    if (pq.size <= 0) {
        return 0;
    }
    let res = Number.MAX_VALUE;
    while (cnt < res) {
        const arr = pq.poll();
        const v = arr[0], i = arr[1];
        res = Math.min(res, cnt + v);
        if (v === 1) {
            break;
        }
        const t = Math.floor((vat[i] + v - 2) / (v - 1));
        cnt += t - bucket[i];
        bucket[i] = t;
        pq.add([Math.floor((vat[i] + bucket[i] - 1) / bucket[i]), i]);
    }
    return res;
};

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
```

**复杂度分析**

-   时间复杂度：$O(n \times \log n + n \times \log{n} \times \sqrt{C})$，其中 $n$ 为数组 $bucket$ 的长度，$C$ 为数组 $vat$ 的范围。「最大堆」中的一次存取操作的时间操作为 $O(\log n)$，初始化「最大堆」的时间复杂度为 $O(n \times \log n)$。在每一个水桶的「蓄水」次数收敛到 $1$ 的复杂度渐进为 $O(\sqrt{C})$。
-   空间复杂度：$O(n)$，其中 $n$ 为数组 $bucket$ 的长度，主要为「最大堆」的空间开销。
