#### [方法二：贪心 + 优先队列](https://leetcode.cn/problems/mice-and-cheese/solutions/2292688/lao-shu-he-nai-luo-by-leetcode-solution-6ia1/)

方法一当中，计算最大得分的做法是创建长度为 $n$ 的数组 $diffs$，其中 $diffs[i] = reward_1[i] - reward_2[i]$，将数组 $diffs$ 排序之后计算 $sum$ 与数组 $diffs$ 的 $k$ 个最大值之和。也可以使用优先队列存储数组 $diffs$ 中的 $k$ 个最大值，优先队列的队首元素为最小元素，优先队列的空间是 $O(k)$。

用 $sum$ 表示数组 $reward_2$ 的元素之和。同时遍历数组 $reward_1$ 和 $reward_2$，当遍历到下标 $i$ 时，执行如下操作。

1.  将 $reward_1[i] - reward_2[i]$ 添加到优先队列。
2.  如果优先队列中的元素个数大于 $k$，则取出优先队列的队首元素，确保优先队列中的元素个数不超过 $k$。

遍历结束时，优先队列中有 $k$ 个元素，为数组 $reward_1$ 和 $reward_2$ 的 $k$ 个最大差值。计算 $sum$ 与优先队列中的 $k$ 个元素之和，即为第一只老鼠恰好吃掉 $k$ 块奶酪的情况下的最大得分。

```java
class Solution {
    public int miceAndCheese(int[] reward1, int[] reward2, int k) {
        int ans = 0;
        int n = reward1.length;
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();
        for (int i = 0; i < n; i++) {
            ans += reward2[i];
            pq.offer(reward1[i] - reward2[i]);
            if (pq.size() > k) {
                pq.poll();
            }
        }
        while (!pq.isEmpty()) {
            ans += pq.poll();
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int MiceAndCheese(int[] reward1, int[] reward2, int k) {
        int ans = 0;
        int n = reward1.Length;
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        for (int i = 0; i < n; i++) {
            ans += reward2[i];
            pq.Enqueue(reward1[i] - reward2[i], reward1[i] - reward2[i]);
            if (pq.Count > k) {
                pq.Dequeue();
            }
        }
        while (pq.Count > 0) {
            ans += pq.Dequeue();
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int miceAndCheese(vector<int>& reward1, vector<int>& reward2, int k) {
        int ans = 0;
        int n = reward1.size();
        priority_queue<int, vector<int>, greater<int>> pq;
        for (int i = 0; i < n; i++) {
            ans += reward2[i];
            pq.emplace(reward1[i] - reward2[i]);
            if (pq.size() > k) {
                pq.pop();
            }
        }
        while (!pq.empty()) {
            ans += pq.top();
            pq.pop();
        }
        return ans;
    }
};
```

```python
class Solution:
    def miceAndCheese(self, reward1: List[int], reward2: List[int], k: int) -> int:
        ans = 0
        n = len(reward1)
        pq = []
        for i in range(n):
            ans += reward2[i]
            heappush(pq, reward1[i] - reward2[i])
            if len(pq) > k:
                heappop(pq)
        while pq:
            ans += heappop(pq)
        return ans
```

```go
type IntHeap []int
 
func (h IntHeap) Less(i, j int) bool {
    return h[i] < h[j]
}
func (h IntHeap) Swap(i, j int) {
    h[i], h[j] = h[j], h[i]
}
func (h *IntHeap) Push(x interface{}) {
    *h = append(*h, x.(int))
}
func (h IntHeap) Len() int {
    return len(h)
}
func (h *IntHeap) Pop() interface{} {
    old := *h
    n := len(old)
    x := old[n - 1]
    *h = old[:n - 1]
    return x
}

func miceAndCheese(reward1 []int, reward2 []int, k int) int {
    ans := 0
    n := len(reward1)
    pq := &IntHeap{}
    heap.Init(pq)
    for i := 0; i < n; i++ {
        ans += reward2[i]
        diff := reward1[i] - reward2[i]
        heap.Push(pq, diff)
        if pq.Len() > k {
            heap.Pop(pq)
        }
    }
    for pq.Len() > 0 {
        ans += heap.Pop(pq).(int)
    }
    return ans
}
```

```javascript
class Heap {
    constructor() {
        this.heap = [];
    }

    push(value) {
        this.heap.push(value);
        this.bubbleUp(this.heap.length - 1);
    }

    poll() {
        const result = this.heap[0];
        const end = this.heap.pop();
        if (this.heap.length > 0) {
            this.heap[0] = end;
            this.sinkDown(0);
        }
        return result;
    }

    size() {
        return this.heap.length;
    }

    isEmpty() {
        return this.heap.length === 0;
    }

    bubbleUp(index) {
        const element = this.heap[index];
        while (index > 0) {
            const parentIndex = Math.floor((index - 1) / 2);
            const parent = this.heap[parentIndex];
            if (element >= parent) {
                break;
            }
            this.heap[parentIndex] = element;
            this.heap[index] = parent;
            index = parentIndex;
        }
    }

    sinkDown(index) {
        const element = this.heap[index];
        const length = this.heap.length;
        while (true) {
            let leftChildIndex = 2 * index + 1;
            let rightChildIndex = 2 * index + 2;
            let leftChild, rightChild;
            let swap = null;

            if (leftChildIndex < length) {
                leftChild = this.heap[leftChildIndex];
                if (leftChild < element) {
                    swap = leftChildIndex;
                }
            }

            if (rightChildIndex < length) {
                rightChild = this.heap[rightChildIndex];
                if ((swap === null && rightChild < element) ||
                    (swap !== null && rightChild < leftChild)) {
                    swap = rightChildIndex;
                }
            }

            if (swap === null) {
                break;
            }

            this.heap[index] = this.heap[swap];
            this.heap[swap] = element;
            index = swap;
        }
    }
}

var miceAndCheese = function(reward1, reward2, k) {
    let ans = 0;
    let n = reward1.length;
    let pq = new Heap();
    for (let i = 0; i < n; i++) {
        ans += reward2[i];
        pq.push(reward1[i] - reward2[i]);
        if (pq.size() > k) {
            pq.poll();
        }
    }
    while (!pq.isEmpty()) {
        ans += pq.poll();
    }
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(n \log k)$，其中 $n$ 是数组 $reward_1$ 和 $reward_2$ 的长度，$k$ 是第一只老鼠吃掉的奶酪块数。遍历两个数组的过程中，每个下标处的优先队列操作时间是 $O(\log k)$，共需要 $O(n \log k)$ 的时间，遍历数组之后计算优先队列中的 $k$ 个元素之和需要 $O(k \log k)$ 的时间，其中 $k \le n$，因此时间复杂度是 $O(n \log k + k \log k) = O(n \log k)$。
-   空间复杂度：$O(k)$，其中 $k$ 是第一只老鼠吃掉的奶酪块数。优先队列需要 $O(k)$ 的空间。
