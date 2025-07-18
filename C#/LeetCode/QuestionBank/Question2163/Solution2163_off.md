### [删除元素后和的最小差值](https://leetcode.cn/problems/minimum-difference-in-sums-after-removal-of-elements/solutions/1249409/shan-chu-yuan-su-hou-he-de-zui-xiao-chai-ah0j/)

#### 方法一：优先队列

**思路与算法**

题目中的要求等价于：

- 在 $[n,2n]$ 中选择一个正整数 $k$；
- 数组 $nums$ 的前 $k$ 个数属于第一部分，但只能保留 $n$ 个；
- 数组 $nums$ 的后 $3n-k$ 个数属于第二部分，但只能保留 $n$ 个；
- 需要最小化第一部分和与第二部分和的差值。

其中 $k \in [n,2n]$ 的原因是需要保证每一部分都至少有 $n$ 个元素。

由于我们需要「最小化第一部分和与第二部分和的差值」，那么就需要第一部分的和尽可能小，第二部分的和尽可能大，也就是说：

> 我们需要在第一部分中选择 $n$ 个最小的元素，第二部分中选择 $n$ 个最大的元素。

因此我们可以使用优先队列来进行选择。对于第一部分而言，我们首先将 $nums[0..n-1]$ 全部放入大根堆中，随后遍历 $[n,2n)$，记当前的下标为 $i$，那么将 $nums[i]$ 放入大根堆后再取出堆顶的元素，剩余堆中的元素即为 $num[0..i]$ 中的 $n$ 个最小的元素。

对于第二部分而言，类似地，我们首先将 $nums[2n..3n-1]$ 全部放入小根堆中，随后**逆序**遍历 $[n,2n)$，记当前的下标为 $i$，那么将 $nums[i]$ 放入小根堆后再取出堆顶的元素，剩余堆中的元素即为 $num[i..3n-1]$ 中的 $n$ 个最大的元素。

在对优先队列进行操作时，我们还需要维护当前所有在优先队列中的元素之和。当元素被放入堆时，我们加上元素的值；当元素被从堆顶取出时，我们减去元素的值。这样一来，我们就可以得到 $part_1[n-1], \dots part_1[2n-1]$ 以及 $part_2[n], \dots part_2[2n]$，其中 $part_1[i]$ 表示 $nums[0..i]$ 中 $n$ 个最小的元素之和，$part_2[i]$ 表示 $nums[i..3n-1]$ 中 $n$ 个最大的元素之和。

最终所有 $part_1[i]-part_2[i+1]$ 中的最小值即为答案。需要保证 $i \in [n-1,2n)$。

**细节**

我们可以将 $part_1$ 的下标全部减去 $n-1$，$part_2$ 的下标全部减去 $n$，这样它们的下标范围都是 $[0,n)$，我们只需要使用两个长度为 $n+1$ 的数组进行存储。

更进一步，在计算 $part_2$ 时，我们无需使用数组进行存储，只需要使用一个变量。当下标为 $i$ 时，我们需要的 $part_1$ 项是 $part_1[i-1]$，下标减去 $n-1$ 变为 $part_1[i-n]$，那么使用 $part_1[i-n]-part_2$ 更新答案即可。

**代码**

```C++
class Solution {
public:
    long long minimumDifference(vector<int>& nums) {
        int n3 = nums.size(), n = n3 / 3;
        vector<long long> part1(n + 1);
        long long sum = 0;
        // 大根堆
        priority_queue<int> ql;
        for (int i = 0; i < n; ++i) {
            sum += nums[i];
            ql.push(nums[i]);
        }
        part1[0] = sum;
        for (int i = n; i < n * 2; ++i) {
            sum += nums[i];
            ql.push(nums[i]);
            sum -= ql.top();
            ql.pop();
            part1[i - (n - 1)] = sum;
        }
        
        long long part2 = 0;
        // 小根堆
        priority_queue<int, vector<int>, greater<int>> qr;
        for (int i = n * 3 - 1; i >= n * 2; --i) {
            part2 += nums[i];
            qr.push(nums[i]);
        }
        long long ans = part1[n] - part2;
        for (int i = n * 2 - 1; i >= n; --i) {
            part2 += nums[i];
            qr.push(nums[i]);
            part2 -= qr.top();
            qr.pop();
            ans = min(ans, part1[i - n] - part2);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def minimumDifference(self, nums: List[int]) -> int:
        n3, n = len(nums), len(nums) // 3

        part1 = [0] * (n + 1)
        # 大根堆
        total = sum(nums[:n])
        ql = [-x for x in nums[:n]]
        heapq.heapify(ql)
        part1[0] = total

        for i in range(n, n * 2):
            total += nums[i]
            heapq.heappush(ql, -nums[i])
            total -= -heapq.heappop(ql)
            part1[i - (n - 1)] = total
        
        # 小根堆
        part2 = sum(nums[n * 2:])
        qr = nums[n * 2:]
        heapq.heapify(qr)
        ans = part1[n] - part2

        for i in range(n * 2 - 1, n - 1, -1):
            part2 += nums[i]
            heapq.heappush(qr, nums[i])
            part2 -= heapq.heappop(qr)
            ans = min(ans, part1[i - n] - part2)
        
        return ans
```

```Java
public class Solution {
    public long minimumDifference(int[] nums) {
        int n3 = nums.length, n = n3 / 3;
        long[] part1 = new long[n + 1];
        long sum = 0;
        // 大根堆（用相反数模拟）
        PriorityQueue<Integer> ql = new PriorityQueue<>((a, b) -> b - a);
        for (int i = 0; i < n; ++i) {
            sum += nums[i];
            ql.add(nums[i]);
        }
        part1[0] = sum;
        for (int i = n; i < n * 2; ++i) {
            sum += nums[i];
            ql.add(nums[i]);
            sum -= ql.poll();
            part1[i - (n - 1)] = sum;
        }
        
        long part2 = 0;
        // 小根堆
        PriorityQueue<Integer> qr = new PriorityQueue<>();
        for (int i = n * 3 - 1; i >= n * 2; --i) {
            part2 += nums[i];
            qr.add(nums[i]);
        }
        long ans = part1[n] - part2;
        for (int i = n * 2 - 1; i >= n; --i) {
            part2 += nums[i];
            qr.add(nums[i]);
            part2 -= qr.poll();
            ans = Math.min(ans, part1[i - n] - part2);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long MinimumDifference(int[] nums) {
        int n3 = nums.Length, n = n3 / 3;
        long[] part1 = new long[n + 1];
        long sum = 0;
        // 大根堆（用相反数模拟）
        var ql = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        for (int i = 0; i < n; ++i) {
            sum += nums[i];
            ql.Enqueue(nums[i], nums[i]);
        }
        part1[0] = sum;
        for (int i = n; i < n * 2; ++i) {
            sum += nums[i];
            ql.Enqueue(nums[i], nums[i]);
            sum -= ql.Dequeue();
            part1[i - (n - 1)] = sum;
        }
        
        long part2 = 0;
        // 小根堆
        var qr = new PriorityQueue<int, int>();
        for (int i = n * 3 - 1; i >= n * 2; --i) {
            part2 += nums[i];
            qr.Enqueue(nums[i], nums[i]);
        }
        long ans = part1[n] - part2;
        for (int i = n * 2 - 1; i >= n; --i) {
            part2 += nums[i];
            qr.Enqueue(nums[i], nums[i]);
            part2 -= qr.Dequeue();
            ans = Math.Min(ans, part1[i - n] - part2);
        }
        return ans;
    }
}
```

```Go
func minimumDifference(nums []int) int64 {
    n3 := len(nums)
    n := n3 / 3
    part1 := make([]int64, n+1)
    var sum int64 = 0
    ql := &MaxHeap{}
    heap.Init(ql)
    for i := 0; i < n; i++ {
        sum += int64(nums[i])
        heap.Push(ql, nums[i])
    }
    part1[0] = sum
    for i := n; i < n*2; i++ {
        sum += int64(nums[i])
        heap.Push(ql, nums[i])
        sum -= int64(heap.Pop(ql).(int))
        part1[i-(n-1)] = sum
    }
    
    var part2 int64 = 0
    qr := &IntMinHeap{}
    heap.Init(qr)
    for i := n * 3 - 1; i >= n * 2; i-- {
        part2 += int64(nums[i])
        heap.Push(qr, nums[i])
    }
    ans := part1[n] - part2
    for i := n * 2 - 1; i >= n; i-- {
        part2 += int64(nums[i])
        heap.Push(qr, nums[i])
        part2 -= int64(heap.Pop(qr).(int))
        if part1[i - n] - part2 < ans {
            ans = part1[i - n] - part2
        }
    }
    return ans
}

type MaxHeap []int
func (h MaxHeap) Len() int           { return len(h) }
func (h MaxHeap) Less(i, j int) bool { return h[i] > h[j] }
func (h MaxHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }
func (h *MaxHeap) Push(x interface{}) { *h = append(*h, x.(int)) }
func (h *MaxHeap) Pop() interface{} {
    old := *h
    n := len(old)
    x := old[n - 1]
    *h = old[0 : n - 1]
    return x
}

type IntMinHeap []int
func (h IntMinHeap) Len() int           { return len(h) }
func (h IntMinHeap) Less(i, j int) bool { return h[i] < h[j] }
func (h IntMinHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }
func (h *IntMinHeap) Push(x interface{}) { *h = append(*h, x.(int)) }
func (h *IntMinHeap) Pop() interface{} {
    old := *h
    n := len(old)
    x := old[n - 1]
    *h = old[0 : n - 1]
    return x
}
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int data[1];
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

Element *createElement(int x, int y) {
    Element *obj = (Element *)malloc(sizeof(Element));
    obj->data[0] = x;
    obj->data[1] = y;
    return obj;
}

static bool less(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data[0] > e2->data[0];
}

static bool greater(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data[0] < e2->data[0];
}

static void memswap(void *m1, void *m2, size_t size){
    unsigned char *a = (unsigned char*)m1;
    unsigned char *b = (unsigned char*)m2;
    while (size--) {
        *b ^= *a ^= *b ^= *a;
        a++;
        b++;
    }
}

static void swap(Element *arr, int i, int j) {
    memswap(&arr[i], &arr[j], sizeof(Element));
}

static void down(Element *arr, int size, int i, compare cmpFunc) {
    for (int k = 2 * i + 1; k < size; k = 2 * k + 1) {
        if (k + 1 < size && cmpFunc(&arr[k], &arr[k + 1])) {
            k++;
        }
        if (cmpFunc(&arr[k], &arr[(k - 1) / 2])) {
            break;
        }
        swap(arr, k, (k - 1) / 2);
    }
}

PriorityQueue *createPriorityQueue(compare cmpFunc) {
    PriorityQueue *obj = (PriorityQueue *)malloc(sizeof(PriorityQueue));
    obj->capacity = MIN_QUEUE_SIZE;
    obj->arr = (Element *)malloc(sizeof(Element) * obj->capacity);
    obj->queueSize = 0;
    obj->lessFunc = cmpFunc;
    return obj;
}

void heapfiy(PriorityQueue *obj) {
    for (int i = obj->queueSize / 2 - 1; i >= 0; i--) {
        down(obj->arr, obj->queueSize, i, obj->lessFunc);
    }
}

void enQueue(PriorityQueue *obj, Element *e) {
    // we need to alloc more space, just twice space size
    if (obj->queueSize == obj->capacity) {
        obj->capacity *= 2;
        obj->arr = realloc(obj->arr, sizeof(Element) * obj->capacity);
    }
    memcpy(&obj->arr[obj->queueSize], e, sizeof(Element));
    for (int i = obj->queueSize; i > 0 && obj->lessFunc(&obj->arr[(i - 1) / 2], &obj->arr[i]); i = (i - 1) / 2) {
        swap(obj->arr, i, (i - 1) / 2);
    }
    obj->queueSize++;
}

Element* deQueue(PriorityQueue *obj) {
    swap(obj->arr, 0, obj->queueSize - 1);
    down(obj->arr, obj->queueSize - 1, 0, obj->lessFunc);
    Element *e =  &obj->arr[obj->queueSize - 1];
    obj->queueSize--;
    return e;
}

bool isEmpty(const PriorityQueue *obj) {
    return obj->queueSize == 0;
}

Element* front(const PriorityQueue *obj) {
    if (obj->queueSize == 0) {
        return NULL;
    } else {
        return &obj->arr[0];
    }
}

void clear(PriorityQueue *obj) {
    obj->queueSize = 0;
}

int size(const PriorityQueue *obj) {
    return obj->queueSize;
}

void freeQueue(PriorityQueue *obj) {
    free(obj->arr);
    free(obj);
}

long long minimumDifference(int* nums, int numsSize) {
    int n3 = numsSize, n = n3 / 3;
    long long part1[n + 1];
    memset(part1, 0, sizeof(part1));
    long long sum = 0;
    // 大根堆
    PriorityQueue *ql = createPriorityQueue(greater);
    for (int i = 0; i < n; ++i) {
        sum += nums[i];
        Element e = {nums[i]};
        enQueue(ql, &e);
    }
    part1[0] = sum;
    for (int i = n; i < n * 2; ++i) {
        sum += nums[i];
        Element e = {nums[i]};
        enQueue(ql, &e);
        sum -= front(ql)->data[0];
        deQueue(ql);
        part1[i - (n - 1)] = sum;
    }
    
    long long part2 = 0;
    // 小根堆
    PriorityQueue *qr = createPriorityQueue(less);
    for (int i = n * 3 - 1; i >= n * 2; --i) {
        part2 += nums[i];
        Element e = {nums[i]};
        enQueue(qr, &e);
    }
    long long ans = part1[n] - part2;
    for (int i = n * 2 - 1; i >= n; --i) {
        part2 += nums[i];
        Element e = {nums[i]};
        enQueue(qr, &e);
        part2 -= front(qr)->data[0];
        deQueue(qr);
        ans = fmin(ans, part1[i - n] - part2);
    }
    freeQueue(ql);
    freeQueue(qr);
    return ans;
}
```

```JavaScript
var minimumDifference = function(nums) {
    const n3 = nums.length, n = Math.floor(n3 / 3);
    const part1 = new Array(n + 1).fill(0);
    let sum = 0;
    // 大根堆（用相反数模拟）
    const ql = new MaxPriorityQueue();
    for (let i = 0; i < n; ++i) {
        sum += nums[i];
        ql.enqueue(nums[i]);
    }
    
    part1[0] = sum;
    for (let i = n; i < n * 2; ++i) {
        sum += nums[i];
        ql.enqueue(nums[i]);
        sum -= ql.dequeue();
        part1[i - (n - 1)] = sum;
    }
    let part2 = 0;
    // 小根堆
    const qr = new MinPriorityQueue();
    for (let i = n * 3 - 1; i >= n * 2; --i) {
        part2 += nums[i];
        qr.enqueue(nums[i]);
    }

    let ans = part1[n] - part2;
    for (let i = n * 2 - 1; i >= n; --i) {
        part2 += nums[i];
        qr.enqueue(nums[i]);
        part2 -= qr.dequeue();
        ans = Math.min(ans, part1[i - n] - part2);
    }
    return ans;
}
```

```TypeScript
function minimumDifference(nums: number[]): number {
    const n3 = nums.length, n = Math.floor(n3 / 3);
    const part1: number[] = new Array(n + 1).fill(0);
    let sum = 0;
    // 大根堆（用相反数模拟）
    const ql = new MaxPriorityQueue<number>();
    for (let i = 0; i < n; ++i) {
        sum += nums[i];
        ql.enqueue(nums[i]);
    }
    part1[0] = sum;
    for (let i = n; i < n * 2; ++i) {
        sum += nums[i];
        ql.enqueue(nums[i]);
        sum -= ql.dequeue();
        part1[i - (n - 1)] = sum;
    }
    
    let part2 = 0;
    // 小根堆
    const qr = new MinPriorityQueue<number>();
    for (let i = n * 3 - 1; i >= n * 2; --i) {
        part2 += nums[i];
        qr.enqueue(nums[i]);
    }
    let ans = part1[n] - part2;
    for (let i = n * 2 - 1; i >= n; --i) {
        part2 += nums[i];
        qr.enqueue(nums[i]);
        part2 -= qr.dequeue();
        ans = Math.min(ans, part1[i - n] - part2);
    }
    return ans;
}
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

impl Solution {
    pub fn minimum_difference(nums: Vec<i32>) -> i64 {
        let n3 = nums.len();
        let n = n3 / 3;
        let mut part1 = vec![0i64; n + 1];
        let mut sum = 0i64;
        // 大根堆
        let mut ql = BinaryHeap::new();
        for i in 0..n {
            sum += nums[i] as i64;
            ql.push(nums[i]);
        }
        part1[0] = sum;
        for i in n..2*n {
            sum += nums[i] as i64;
            ql.push(nums[i]);
            sum -= ql.pop().unwrap() as i64;
            part1[i - (n - 1)] = sum;
        }
        
        let mut part2 = 0i64;
        // 小根堆（用Reverse模拟）
        let mut qr = BinaryHeap::new();
        for i in (2*n..3*n).rev() {
            part2 += nums[i] as i64;
            qr.push(Reverse(nums[i]));
        }
        let mut ans = part1[n] - part2;
        for i in (n..2*n).rev() {
            part2 += nums[i] as i64;
            qr.push(Reverse(nums[i]));
            if let Some(Reverse(val)) = qr.pop() {
                part2 -= val as i64;
            }
            ans = ans.min(part1[i - n] - part2);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$。优先队列中包含 $n$ 个元素，单次操作时间复杂度为 $O(\log n)$，操作次数为 $O(n)$。
- 空间复杂度：$O(n)$，即为优先队列和数组 $part_1$ 需要使用的空间。
