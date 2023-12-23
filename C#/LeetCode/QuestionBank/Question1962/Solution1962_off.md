### [移除石子使总数最小](https://leetcode.cn/problems/remove-stones-to-minimize-the-total/solutions/922700/yi-chu-shi-zi-shi-zong-shu-zui-xiao-by-l-9lsg/)

#### 方法一：贪心 + 优先队列

##### 思路

题目要求 $k$ 次拿完后，剩下的石头数最少，可以贪心地每次都从石子数最多的堆里拿石头，然后将剩下的放回去。我们假设某一步操作没有选择石子数量最多的一堆（记为第 $opt$ 堆）进行操作，而是选择了第 $i$ 堆，那么后续可能有两种情况：

- 第一种，如果后续的某一步中选择了第 $opt$ 堆，那么我们可以交换这两步的操作，最终剩余的石子数目不变；
- 第二种，如果后续没有移除过第 $opt$ 堆的石子，那么将从当前开始到结束为止所有选择第 $i$ 堆的操作全部换成第 $opt$ 堆，总移除的石子数目也不会减少。

因此，每次选择石子数量最多的一堆进行操作是最优的。每次都要挑出石子数最多的堆，可以考虑用优先队列的数据结构，这样可以 $O(\log{n})$ 的时间复杂度完成出队列和入队列，执行 $k$ 次后返回剩下石子数总和。

##### 代码

```python
class Solution:
    def minStoneSum(self, piles: List[int], k: int) -> int:
        heap = [-a for a in piles]
        heapify(heap)
        for i in range(k):
            a = -heappop(heap)
            a = a - a//2
            heappush(heap, -a)
        return -sum(heap)
```

```java
class Solution {
    public int minStoneSum(int[] piles, int k) {
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>((a, b) -> (b - a));
        for (int pile : piles) {
            pq.offer(pile);
        }
        for (int i = 0; i < k; i++) {
            int pile = pq.poll();
            pile -= pile / 2;
            pq.offer(pile);
        }
        int sum = 0;
        while (!pq.isEmpty()) {
            sum += pq.poll();
        }
        return sum;
    }
}
```

```csharp
public class Solution {
    public int MinStoneSum(int[] piles, int k) {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        foreach (int pile in piles) {
            pq.Enqueue(pile, -pile);
        }
        for (int i = 0; i < k; i++) {
            int pile = pq.Dequeue();
            pile -= pile / 2;
            pq.Enqueue(pile, -pile);
        }
        int sum = 0;
        while (pq.Count > 0) {
            sum += pq.Dequeue();
        }
        return sum;
    }
}
```

```c++
class Solution {
public:
    int minStoneSum(vector<int>& piles, int k) {
        priority_queue<int> pq(piles.begin(), piles.end());
        for (int i = 0; i < k; i++) {
            int pile = pq.top();
            pq.pop();
            pile -= pile / 2;
            pq.push(pile);
        }
        int sum = 0;
        while (!pq.empty()) {
            sum += pq.top();
            pq.pop();
        }
        return sum;
    }
};
```

```go
type PriorityQueue struct {
    sort.IntSlice
}

func (pq *PriorityQueue) Less(i, j int) bool {
    return pq.IntSlice[i] > pq.IntSlice[j]
}

func (pq *PriorityQueue) Push(v interface{}) {
    pq.IntSlice = append(pq.IntSlice, v.(int))
}

func (pq *PriorityQueue) Pop() interface{} {
    arr := pq.IntSlice
    v := arr[len(arr) - 1]
    pq.IntSlice = arr[:len(arr) - 1]
    return v
}

func minStoneSum(piles []int, k int) int {
    pq := &PriorityQueue{piles}
    heap.Init(pq)
    for i := 0; i < k; i++ {
        pile := heap.Pop(pq).(int)
        pile -= pile / 2
        heap.Push(pq, pile)
    }
    sum := 0
    for len(pq.IntSlice) > 0 {
        sum += heap.Pop(pq).(int)
    }
    return sum
}
```

```c
void swap(int *nums, int i, int j) {
    int x = nums[i];
    nums[i] = nums[j];
    nums[j] = x;
}

void down(int *nums, int size, int i) {
    for (int k = 2 * i + 1; k < size; k = 2 * k + 1) {
        // 父节点 (k - 1) / 2，左子节点 k，右子节点 k + 1
        if (k + 1 < size && nums[k] < nums[k + 1]) {
            k++;
        }
        if (nums[k] < nums[(k - 1) / 2]) {
            break;
        }
        swap(nums, k, (k - 1) / 2);
    }
}

void Init(int *nums, int size) {
    for (int i = size / 2 - 1; i >= 0; i--) {
        down(nums, size, i);
    }
}

void Push(int *nums, int size, int x) {
    nums[size] = x;
    for (int i = size; i > 0 && nums[(i - 1) / 2] < nums[i]; i = (i - 1) / 2) {
        swap(nums, i, (i - 1) / 2);
    }
}

int Pop(int *nums, int size) {
    swap(nums, 0, size - 1);
    down(nums, size - 1, 0);
    return nums[size - 1];
}

int minStoneSum(int* piles, int pilesSize, int k) {
    int *pq = piles, n = pilesSize;
    Init(pq, n);
    for (int i = 0; i < k; i++) {
        int pile = Pop(pq, n);
        n--;
        pile -= pile / 2;
        Push(pq, n, pile);
        n++;
    }
    int sum = 0;
    while (n > 0) {
        sum += Pop(pq, n);
        n--;
    }
    return sum;
}
```

```javascript
var minStoneSum = function(piles, k) {
    const pq = new MaxPriorityQueue();
    for (const pile of piles) {
        pq.enqueue(pile, pile);
    }
    for (let i = 0; i < k; i++) {
        let pile = pq.front().element;
        pq.dequeue();
        pile -= Math.floor(pile / 2);
        pq.enqueue(pile, pile);
    }
    let sum = 0;
    while (!pq.isEmpty()) {
        sum += pq.front().element;
        pq.dequeue();
    }
    return sum;
};
```

#### 复杂度分析

- 时间复杂度：$O(k\times \log{n} + n)$，其中 $n$ 是数组 $piles$ 的长度。将数组变为优先队列消耗 $O(n)$，$k$ 次入队列和出队列的操作，每次消耗 $O(\log{n})$，总的时间复杂度是 $O(k\times \log{n} + n)$。
- 空间复杂度：$O(n)$，新建一个优先队列消耗 $O(n)$。
