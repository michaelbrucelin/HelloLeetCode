### [座位预约管理系统](https://leetcode.cn/problems/seat-reservation-manager/solutions/754909/zuo-wei-yu-yue-guan-li-xi-tong-by-leetco-wj45/)

#### 方法一：最小堆（优先队列）

**提示 1**

考虑 $reserve$ 与 $unreserve$ 方法对应的需求。什么样的数据结构能够在较好的时间复杂度下支持这些操作？

**思路与算法**

根据 **提示 1**，假设我们使用数据结构 $available$ 来维护所有可以预约的座位，我们需要分析 $reserve$ 与 $unreserve$ 的具体需求：

- 对于 $reserve$ 方法，我们需要弹出并返回 $available$ 中的最小元素；
- 对于 $unreserve$ 方法，我们需要将 $seatNumber$ 添加至 $available$ 中。

因此我们可以使用二叉堆实现的优先队列作为 $available$。对于一个最小堆，可以在 $O(logn)$ 的时间复杂度内完成单次「添加元素」与「弹出最小值」的操作。

需要注意的是，$Python$ 的二叉堆默认为最小堆，但 $C++$ 的二叉堆默认为最大堆。

**代码**

```C++
class SeatManager {
public:
    vector<int> available;

    SeatManager(int n) {
        for (int i = 1; i <= n; ++i){
            available.push_back(i);
        }
    }
    
    int reserve() {
        pop_heap(available.begin(), available.end(), greater<int>());
        int tmp = available.back();
        available.pop_back();
        return tmp;
    }
    
    void unreserve(int seatNumber) {
        available.push_back(seatNumber);
        push_heap(available.begin(), available.end(), greater<int>());
    }
};
```

```Python
from heapq import heappush, heappop

class SeatManager:

    def __init__(self, n: int):
        self.available = list(range(1, n + 1))

    def reserve(self) -> int:
        return heappop(self.available)

    def unreserve(self, seatNumber: int) -> None:
        heappush(self.available, seatNumber)

```

```Java
class SeatManager {
    private PriorityQueue<Integer> available;
    public SeatManager(int n) {
        available = new PriorityQueue<>();
        for (int i = 1; i <= n; i++) {
            available.offer(i);
        }
    }
    
    public int reserve() {
        return available.poll();
    }
    
    public void unreserve(int seatNumber) {
        available.offer(seatNumber);
    }
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

Element *createElement(int x) {
    Element *obj = (Element *)malloc(sizeof(Element));
    obj->data[0] = x;
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
        Element *mem = (Element *)malloc(sizeof(Element) * obj->capacity);
        memcpy(mem, obj->arr, sizeof(Element) * obj->queueSize);
        free(obj->arr);
        obj->arr = mem;
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

typedef struct {
    PriorityQueue *available;
} SeatManager;

SeatManager* seatManagerCreate(int n) {
    SeatManager *obj = (SeatManager *)malloc(sizeof(SeatManager));
    obj->available = createPriorityQueue(less);
    Element e;
    for (int i = 1; i <= n; i++) {
        e.data[0] = i;
        enQueue(obj->available, &e);
    }
    return obj;
}

int seatManagerReserve(SeatManager* obj) {
    int ret = front(obj->available)->data[0];
    deQueue(obj->available);
    return ret;
}

void seatManagerUnreserve(SeatManager* obj, int seatNumber) {
    Element e;
    e.data[0] = seatNumber;
    enQueue(obj->available, &e);
}

void seatManagerFree(SeatManager* obj) {
    freeQueue(obj->available);
    free(obj);
}
```

```Go
type SeatManager struct {
    available *Heap
}

func Constructor(n int) SeatManager {
    h := &Heap{}
    heap.Init(h)
    for i := 1; i <= n; i++ {
        heap.Push(h, i)
    }
    return SeatManager{available: h}
}

func (this *SeatManager) Reserve() int {
    return heap.Pop(this.available).(int)
}

func (this *SeatManager) Unreserve(seatNumber int)  {
    heap.Push(this.available, seatNumber)
}

type Heap []int

func (h Heap) Len() int           { return len(h) }
func (h Heap) Less(i, j int) bool { return h[i] < h[j] }
func (h Heap) Swap(i, j int)      { h[i], h[j] = h[j], h[i] }

func (h *Heap) Push(x interface{}) {
    *h = append(*h, x.(int))
}

func (h *Heap) Pop() interface{} {
    old := *h
    n := len(old)
    x := old[n-1]
    *h = old[0 : n-1]
    return x
}
```

```JavaScript
var SeatManager = function(n) {
    this.available = new MinPriorityQueue();
    for (let i = 1; i <= n; i++) {
        this.available.enqueue(i, i);
    }
};

SeatManager.prototype.reserve = function() {
    return this.available.dequeue().element;
};

SeatManager.prototype.unreserve = function(seatNumber) {
    this.available.enqueue(seatNumber);
};
```

```TypeScript
class SeatManager {
    private available;

    constructor(n: number) {
        this.available = new MinPriorityQueue();
        for (let i = 1; i <= n; i++) {
            this.available.enqueue(i, i);
        }
    }

    reserve(): number {
        return this.available.dequeue().element;
    }

    unreserve(seatNumber: number): void {
        this.available.enqueue(seatNumber);
    }
}
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

struct SeatManager {
    available: BinaryHeap<Reverse<i32>>,
}

impl SeatManager {
    fn new(n: i32) -> Self {
        let mut available = BinaryHeap::new();
        for i in 1..=n {
            available.push(Reverse(i));
        }
        SeatManager { available }
    }
    
    fn reserve(&mut self) -> i32 {
        self.available.pop().unwrap().0
    }
    
    fn unreserve(&mut self, seat_number: i32) {
        self.available.push(Reverse(seat_number));
    }
}
```

```Cangjie
class PriorityQueue<T> {
    private let queue: ArrayList<T>
    private let comparator: (T, T) -> Bool

    init(comp: (T, T) -> Bool) {
        this.queue = ArrayList<T>()
        this.comparator = comp
    }

    public func enqueue(item: T): Unit {
        this.queue.append(item)
        var i = queue.size - 1
        while (i > 0 && this.comparator(this.queue.get((i - 1) / 2).getOrThrow(), 
            this.queue.get(i).getOrThrow())) {
            swap(i, (i - 1) / 2)
            i = (i - 1) / 2
        }
    }

    public func dequeue(): Option<T> {
        if (isEmpty()) {
            return None
        }
        swap(0, this.queue.size - 1)
        let val = this.queue.remove(this.queue.size - 1)
        down(0)
        return Some(val)
    }

    public func peek(): Option<T> {
        return this.queue.get(0)
    }

    public func isEmpty(): Bool {
        return this.queue.isEmpty()
    }

    public func size(): Int64 {
        return this.queue.size
    }

    private func swap(i: Int64, j: Int64) {
        let val = this.queue.get(i).getOrThrow()
        this.queue.set(i, this.queue.get(j).getOrThrow())
        this.queue.set(j, val)
    }

    private func down(i: Int64): Unit {
        var k = 2 * i + 1
        while (k < this.queue.size) {
            if (k + 1 < this.queue.size && this.comparator(this.queue.get(k).getOrThrow(), 
                this.queue.get(k + 1).getOrThrow())) {
                k++
            }
            if (this.comparator(this.queue.get(k).getOrThrow(),
                this.queue.get((k - 1) / 2).getOrThrow())) {
                break
            }
            swap(k, (k - 1) / 2)
            k = k * 2 + 1
        }
    }
}

class SeatManager {
    let available: PriorityQueue<Int64>
    init(n: Int64) {
        let maxComparator = {a: Int64, b: Int64 => a > b }
        this.available = PriorityQueue<Int64>(maxComparator)
        for (i in 1..= n) {
            this.available.enqueue(i)
        }
    }
    
    func reserve(): Int64 {
        return this.available.dequeue().getOrThrow()
    }
    
    func unreserve(seatNumber: Int64): Unit {
        this.available.enqueue(seatNumber)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+(q_1​+q_2​)logn)$，其中 $n$ 为座位的数量，$q_1$​ 为 $reserve$ 操作的次数，$q_2$​ 为 $unreserve$ 的次数。初始化的时间复杂度为 $O(n)$，二叉堆实现的优先队列单次添加元素与弹出最小值操作的复杂度均为 $O(logn)$。
- 空间复杂度：$O(n)$，二叉堆的空间开销。
