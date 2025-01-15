### [超过阈值的最少操作数 II](https://leetcode.cn/problems/minimum-operations-to-exceed-threshold-value-ii/solutions/3040119/chao-guo-yu-zhi-de-zui-shao-cao-zuo-shu-y7tgx/)

#### 方法一： 模拟

**思路与算法**

本题使用「最小堆」实现的「优先队列」来进行模拟。

首先把所有数加入堆中。当堆顶元素小于 $k$ 时，就把取出堆中最小的两个数，把更新后的数加入堆中。

最后返回操作的数目。

**代码**

```C++
class Solution {
public:
    int minOperations(vector<int> &nums, int k) {
        int res = 0;
        priority_queue<long long, vector<long long>, greater<long long>> pq(nums.begin(), nums.end());
        while (pq.top() < k) {
            long long x = pq.top(); pq.pop();
            long long y = pq.top(); pq.pop();
            pq.push(x + x + y);
            res++;
        }
        return res;
    }
};
```

```Java
class Solution {
    public int minOperations(int[] nums, int k) {
        int res = 0;
        PriorityQueue<Long> pq = new PriorityQueue<>();
        for (long num : nums) {
            pq.offer(num);
        }
        while (pq.peek() < k) {
            long x = pq.poll(), y = pq.poll();
            pq.offer(x + x + y);
            res++;
        }
        return res;
    }
}
```

```Python
class Solution:
    def minOperations(self, nums: List[int], k: int) -> int:
        res = 0
        h = nums[:]
        heapify(h)
        while h[0] < k:
            x = heappop(h)
            y = heappop(h)
            heappush(h, x + x + y)
            res += 1
        return res
```

```JavaScript
var minOperations = function(nums, k) {
    let res = 0;
    const pq = new MinHeap();

    for (const num of nums) {
        pq.push(num);
    }
    while (pq.peek() < k) {
        const x = pq.pop();
        const y = pq.pop();
        pq.push(x + x + y);
        res++;
    }

    return res;
};

class MinHeap {
    constructor() {
        this.heap = [];
    }

    size() {
        return this.heap.length;
    }

    isEmpty() {
        return this.size() === 0;
    }

    peek() {
        return this.heap[0];
    }

    push(val) {
        this.heap.push(val);
        this._heapifyUp();
    }

    pop() {
        if (this.size() === 1) return this.heap.pop();

        const root = this.heap[0];
        this.heap[0] = this.heap.pop();
        this._heapifyDown();
        return root;
    }

    _heapifyUp() {
        let index = this.size() - 1;
        const element = this.heap[index];

        while (index > 0) {
            const parentIndex = Math.floor((index - 1) / 2);
            const parent = this.heap[parentIndex];

            if (element >= parent) break;

            this.heap[index] = parent;
            this.heap[parentIndex] = element;
            index = parentIndex;
        }
    }

    _heapifyDown() {
        let index = 0;
        const length = this.size();
        const element = this.heap[0];

        while (true) {
            let leftChildIndex = 2 * index + 1;
            let rightChildIndex = 2 * index + 2;
            let smallest = index;

            if (
                leftChildIndex < length &&
                this.heap[leftChildIndex] < this.heap[smallest]
            ) {
                smallest = leftChildIndex;
            }

            if (
                rightChildIndex < length &&
                this.heap[rightChildIndex] < this.heap[smallest]
            ) {
                smallest = rightChildIndex;
            }

            if (smallest === index) break;

            this.heap[index] = this.heap[smallest];
            this.heap[smallest] = element;
            index = smallest;
        }
    }
}
```

```TypeScript
function minOperations(nums: number[], k: number): number {
    let res = 0;
    const pq = new MinHeap();

    for (const num of nums) {
        pq.push(num);
    }

    while (pq.peek() < k) {
        const x = pq.pop();
        const y = pq.pop();
        pq.push(x + x + y);
        res++;
    }

    return res;
};

class MinHeap {
    private heap: number[];

    constructor() {
        this.heap = [];
    }

    size(): number {
        return this.heap.length;
    }

    isEmpty(): boolean {
        return this.size() === 0;
    }

    peek(): number {
        if (this.isEmpty()) {
            throw new Error("Heap is empty");
        }
        return this.heap[0];
    }

    push(val: number): void {
        this.heap.push(val);
        this._heapifyUp();
    }

    pop(): number {
        if (this.isEmpty()) {
            throw new Error("Heap is empty");
        }
        if (this.size() === 1) {
            return this.heap.pop() as number;
        }

        const root = this.heap[0];
        this.heap[0] = this.heap.pop() as number;
        this._heapifyDown();
        return root;
    }

    private _heapifyUp(): void {
        let index = this.size() - 1;
        const element = this.heap[index];

        while (index > 0) {
            const parentIndex = Math.floor((index - 1) / 2);
            const parent = this.heap[parentIndex];

            if (element >= parent) break;

            this.heap[index] = parent;
            this.heap[parentIndex] = element;
            index = parentIndex;
        }
    }

    private _heapifyDown(): void {
        let index = 0;
        const length = this.size();
        const element = this.heap[0];

        while (true) {
            let leftChildIndex = 2 * index + 1;
            let rightChildIndex = 2 * index + 2;
            let smallest = index;

            if (
                leftChildIndex < length &&
                this.heap[leftChildIndex] < this.heap[smallest]
            ) {
                smallest = leftChildIndex;
            }

            if (
                rightChildIndex < length &&
                this.heap[rightChildIndex] < this.heap[smallest]
            ) {
                smallest = rightChildIndex;
            }

            if (smallest === index) break;

            this.heap[index] = this.heap[smallest];
            this.heap[smallest] = element;
            index = smallest;
        }
    }
}
```

```Go
func minOperations(nums []int, k int) int {
    res := 0
    pq := &MinHeap{}
    heap.Init(pq)
    for _, num := range nums {
        heap.Push(pq, num)
    }

    for (*pq)[0] < k {
        x := heap.Pop(pq).(int)
        y := heap.Pop(pq).(int)
        heap.Push(pq, x+x+y)
        res++
    }

    return res
}

// MinHeap
type MinHeap []int

func (h MinHeap) Len() int           { return len(h) }
func (h MinHeap) Less(i, j int) bool { return h[i] < h[j] }
func (h MinHeap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }

func (h *MinHeap) Push(x interface{}) {
    *h = append(*h, x.(int))
}

func (h *MinHeap) Pop() interface{} {
    old := *h
    n := len(old)
    x := old[n-1]
    *h = old[0 : n-1]
    return x
}
```

```CSharp
public class Solution {
    public int MinOperations(int[] nums, int k) {
        int res = 0;
        PriorityQueue<long, long> pq = new PriorityQueue<long, long>();
        foreach (int num in nums) {
            pq.Enqueue(num, num);
        }
        while (pq.Peek() < k) {
            long x = pq.Dequeue(), y = pq.Dequeue();
            pq.Enqueue(x + x + y, x + x + y);
            res++;
        }
        return res;
    }
}
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    long long data[1];
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

int minOperations(int* nums, int numsSize, int k) {
    int res = 0;
    PriorityQueue *pq = createPriorityQueue(less);
    struct Element e;
    for (int i = 0; i < numsSize; i++) {
        e.data[0] = nums[i];
        enQueue(pq, &e);
    }
    while (front(pq)->data[0] < k) {
        long long x = front(pq)->data[0]; deQueue(pq);
        long long y = front(pq)->data[0]; deQueue(pq);
        e.data[0] = x + x + y;
        enQueue(pq, &e);
        res++;
    }
    freeQueue(pq);
    return res;
}
```

```Rust
use std::collections::BinaryHeap;
use core::cmp::Reverse;

impl Solution {
    pub fn min_operations(nums: Vec<i32>, k: i32) -> i32 {
        let mut res = 0;
        let mut pq: BinaryHeap<Reverse<i64>> = BinaryHeap::new();
        for &num in &nums {
            pq.push(Reverse(num as i64));
        }
        while let Some(Reverse(x)) = pq.pop() {
            if x >= k as i64 {
                break;
            }
            if let Some(Reverse(y)) = pq.pop() {
                pq.push(Reverse(x + x + y));
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度。
