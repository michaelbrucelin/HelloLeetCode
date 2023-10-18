### [执行 K 次操作后的最大分数](https://leetcode.cn/problems/maximal-score-after-applying-k-operations/solutions/2484596/zhi-xing-k-ci-cao-zuo-hou-de-zui-da-fen-a1jub/)

#### 方法一：贪心 + 优先队列

**思路与算法**

在一次操作中，我们会将 $nums[i]$ 变成 $\lceil \dfrac{nums[i]}{3} \rceil$，并且增加 $nums[i]$ 的得分。由于：

-   数组中其它的元素不会变化；
-   对于两个不同的元素 $nums[i]$ 和 $nums[j]$，如果 $nums[i] \leq nums[j]$，在对它们都进行一次操作后，$nums[i] \leq nums[j]$ 仍然成立；

这就说明，我们每一次操作都应当贪心地选出当前**最大的那个元素**。

因此，我们可以使用一个大根堆（优先队列）来维护数组中所有的元素。在每一次操作中，我们取出堆顶的元素 $x$，将答案增加 $x$，再将 $\lceil \dfrac{x}{3} \rceil$ 放回大根堆中即可。

**细节**

为了避免浮点数运算，我们可以用 $(x+2)/3$ 等价 $\lceil \dfrac{x}{3} \rceil$，其中 $/$ 表示整数除法。

**代码**

```cpp
class Solution {
public:
    long long maxKelements(vector<int>& nums, int k) {
        priority_queue<int> q(nums.begin(), nums.end());
        long long ans = 0;
        for (int _ = 0; _ < k; ++_) {
            int x = q.top();
            q.pop();
            ans += x;
            q.push((x + 2) / 3);
        }
        return ans;
    }
};
```

```java
class Solution {
    public long maxKelements(int[] nums, int k) {
        PriorityQueue<Integer> q = new PriorityQueue<Integer>((a, b) -> b - a);
        for (int num : nums) {
            q.offer(num);
        }
        long ans = 0;
        for (int i = 0; i < k; ++i) {
            int x = q.poll();
            ans += x;
            q.offer((x + 2) / 3);
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public long MaxKelements(int[] nums, int k) {
        PriorityQueue<int, int> q = new PriorityQueue<int, int>();
        foreach (int num in nums) {
            q.Enqueue(num, -num);
        }
        long ans = 0;
        for (int i = 0; i < k; ++i) {
            int x = q.Dequeue();
            ans += x;
            q.Enqueue((x + 2) / 3, -(x + 2) / 3);
        }
        return ans;
    }
}
```

```go
type PriorityQueue []int

func (pq PriorityQueue) Swap(i, j int) {
    pq[i], pq[j] = pq[j], pq[i]
}

func (pq PriorityQueue) Len() int {
    return len(pq)
}

func (pq PriorityQueue) Less(i, j int) bool {
    return pq[i] > pq[j]
}

func (pq *PriorityQueue) Push(x any) {
    *pq = append(*pq, x.(int))
}

func (pq *PriorityQueue) Pop() any {
    n := len(*pq)
    x := (*pq)[n - 1]
    *pq = (*pq)[:n-1]
    return x
}

func maxKelements(nums []int, k int) int64 {
    q := (*PriorityQueue)(&nums)
    heap.Init(q)
    var ans int64
    for i := 0; i < k; i++ {
        x := heap.Pop(q).(int)
        ans += int64(x)
        heap.Push(q, (x + 2) / 3)
    }
    return ans
}
```

```python
class Solution:
    def maxKelements(self, nums: List[int], k: int) -> int:
        # python 中的 heap 默认是小根堆，需要对元素取相反数
        q = [-x for x in nums]
        heapify(q)

        ans = 0
        for _ in range(k):
            x = heappop(q)
            ans += -x
            heappush(q, -((-x + 2) // 3))
        return ans
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

long long maxKelements(int *nums, int numsSize, int k) {
    Init(nums, numsSize);
    long long ans = 0;
    for (int i = 0; i < k; i++) {
        int x = Pop(nums, numsSize);
        ans += x;
        Push(nums, numsSize - 1, (x + 2) / 3);
    }
    return ans;
}
```

```javascript
var maxKelements = function(nums, k) {
    q = new MaxPriorityQueue();
    let ans = 0;
    for (const num of nums) {
        q.enqueue(num);
    }
    for (let i = 0; i < k; i++) {
        const x = q.dequeue().element;
        ans += x;
        q.enqueue(Math.ceil(x / 3));
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(k \log n + n)$，其中 $n$ 是数组 $nums$ 的长度。构造优先队列需要的时间为 $O(n)$，每一轮操作需要的时间为 $O(\log n)$，一共有 $k$ 轮操作。
-   空间复杂度：$O(n)$ 或 $O(1)$。优先队列需要的空间为 $O(n)$。某些语言原地对数组建堆，空间复杂度为 $O(1)$。
