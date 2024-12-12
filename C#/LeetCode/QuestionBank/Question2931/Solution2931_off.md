### [购买物品的最大开销](https://leetcode.cn/problems/maximum-spending-after-buying-items/solutions/3004329/gou-mai-wu-pin-de-zui-da-kai-xiao-by-lee-zwv3/)

#### 方法一：排序不等式 + 小根堆

**思路与算法**

由于每一个商店的物品都已经按照价值单调递减排好序了，那么当我们选择某个商店购买物品时，都可以买到该商店中价值最低的物品。由于我们可以任意选择商店，这就说，我们**总是可以买到当前所有物品中价值最低的那个**。

在开销的计算公式中，物品的价值会乘上购买它的天数。根据排序不等式，在理想状态下我们应该将所有商品按照价值从低到高排序，分别在第 $1$ 到 $m \times n$ 天去购买。根据上一段的结论，我们一定是可以达到这个理想状态的。

因此，我们可以将 $m \times n$ 个商品按照价值进行排序，就可以得到答案，但这样做的时间复杂度是 $O(mnlog(mn))$，没有进一步用到「每一个商店的物品都已经按照价值单调递减排好序」这个性质。我们可以使用「[23\. 合并 K 个升序链表](https://leetcode.cn/problems/merge-k-sorted-lists/)」中的方法，使用一个小根堆，存储每个商店当前价值最小的物品，那么小根堆的堆顶就是全局价值最小的物品。随后，我们将该物品在对应的商店中的下一个物品放入小根堆中，重复一共 $m \times n$ 次操作即可，时间复杂度降低至 $O(mnlogm)$。

**代码**

```C++
class Solution {
public:
    long long maxSpending(vector<vector<int>>& values) {
        int m = values.size(), n = values[0].size();
        priority_queue<ti3, vector<ti3>, greater<ti3>> q;
        for (int i = 0; i < m; ++i) {
            q.emplace(values[i][n - 1], i, n - 1);
        }
        long long ans = 0;
        for (int turn = 1; turn <= m * n; ++turn) {
            auto [val, i, j] = q.top();
            q.pop();
            ans += static_cast<long long>(val) * turn;
            if (j > 0) {
                q.emplace(values[i][j - 1], i, j - 1);
            }
        }
        return ans;
    }

private:
    using ti3 = tuple<int, int, int>;
};
```

```Python
class Solution:
    def maxSpending(self, values: List[List[int]]) -> int:
        m, n = len(values), len(values[0])
        q = [(values[i][-1], i, n - 1) for i in range(m)]
        heapify(q)
        ans = 0
        for turn in range(1, m * n + 1):
            val, i, j = heappop(q)
            ans += val * turn
            if j > 0:
                heappush(q, (values[i][j - 1], i, j - 1))
        return ans
```

```Java
class Solution {
    public long maxSpending(int[][] values) {
        int m = values.length, n = values[0].length;
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> a[0] - b[0]);
        for (int i = 0; i < m; i++) {
            pq.offer(new int[]{values[i][n - 1], i, n - 1});
        }

        long ans = 0;
        for (int turn = 1; turn <= m * n; turn++) {
            int[] top = pq.poll();
            int val = top[0], i = top[1], j = top[2];
            ans += (long)val * turn;
            if (j > 0) {
                pq.offer(new int[]{values[i][j - 1], i, j - 1});
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long MaxSpending(int[][] values) {
        int m = values.Length, n = values[0].Length;
        var pq = new PriorityQueue<int[], int>(
            Comparer<int>.Create((a, b) => a.CompareTo(b))
        );
        for (int i = 0; i < m; i++) {
            pq.Enqueue(new int[]{values[i][n - 1], i, n - 1}, values[i][n - 1]);
        }
        long ans = 0;
        for (int turn = 1; turn <= m * n; turn++) {
            var top = pq.Dequeue();
            int val = top[0], i = top[1], j = top[2];
            ans += (long)val * turn;
            if (j > 0) {
                pq.Enqueue(new int[]{values[i][j - 1], i, j - 1}, values[i][j - 1]);
            }
        }
        return ans;
    }
}
```

```Go
func maxSpending(values [][]int) int64 {
    m, n := len(values), len(values[0])
    pq := &Heap{}
    for i := 0; i < m; i++ {
        heap.Push(pq, []int{values[i][n-1], i, n - 1})
    }
    ans := int64(0)
    for turn := 1; turn <= m * n; turn++ {
        top := heap.Pop(pq).([]int)
        val, i, j := top[0], top[1], top[2]
        ans += int64(val) * int64(turn)
        if j > 0 {
            heap.Push(pq, []int{values[i][j-1], i, j - 1})
        }
    }
    return ans
}

type Heap [][]int

func (h Heap) Len() int { 
    return len(h) 
}

func (h Heap) Less(i, j int) bool { 
    if (h[i][0] == h[j][0]) {
        return h[i][1] < h[j][1]
    }
    return h[i][0] < h[j][0]
}

func (h Heap) Swap(i, j int) { 
    h[i], h[j] = h[j], h[i] 
}

func (h *Heap) Push(x interface{}) { 
    *h = append(*h, x.([]int)) 
}

func (h *Heap) Pop() interface{} {
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
    int data[3];
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

static bool less(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data[0] > e2->data[0] || \
           (e1->data[0] == e2->data[0] && \
           e1->data[1] > e2->data[1]);
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

long long maxSpending(int** values, int valuesSize, int* valuesColSize) {
    int m = valuesSize, n = valuesColSize[0];
    PriorityQueue *pq = createPriorityQueue(less);
    Element e;
    for (int i = 0; i < m; ++i) {
        e.data[0] = values[i][n - 1];
        e.data[1] = i;
        e.data[2] = n - 1;
        enQueue(pq, &e);
    }
    long long ans = 0;
    for (int turn = 1; turn <= m * n; ++turn) {
        Element *p = front(pq);
        int val = p->data[0];
        int i = p->data[1];
        int j = p->data[2];
        deQueue(pq);
        ans += (long long)val * turn;
        if (j > 0) {
            e.data[0] = values[i][j - 1];
            e.data[1] = i;
            e.data[2] = j - 1;
            enQueue(pq, &e);
        }
    }
    freeQueue(pq);
    return ans;
}
```

```JavaScript
var maxSpending = function(values) {
    const m = values.length, n = values[0].length;
    const pq = new MinPriorityQueue();
    for (let i = 0; i < m; i++) {
        pq.enqueue([values[i][n - 1], i, n - 1], values[i][n - 1]);
    }
    
    let ans = 0;
    for (let turn = 1; turn <= m * n; turn++) {
        const [val, i, j] = pq.dequeue().element;
        ans += val * turn;
        if (j > 0) {
            pq.enqueue([values[i][j - 1], i, j - 1], values[i][j - 1]);
        }
    }
    return ans;
};
```

```TypeScript
function maxSpending(values: number[][]): number {
    const m = values.length, n = values[0].length;
    const pq = new MinPriorityQueue();
    for (let i = 0; i < m; i++) {
        pq.enqueue([values[i][n - 1], i, n - 1], values[i][n - 1]);
    }
    
    let ans = 0;
    for (let turn = 1; turn <= m * n; turn++) {
        const [val, i, j] = pq.dequeue().element;
        ans += val * turn;
        if (j > 0) {
            pq.enqueue([values[i][j - 1], i, j - 1], values[i][j - 1]);
        }
    }
    return ans;
};
```

```Rust
use std::collections::BinaryHeap;

#[derive(Eq, PartialEq)]
struct Item {
    value: i32,
    i: usize,
    j: usize,
}

impl Ord for Item {
    fn cmp(&self, other: &Self) -> std::cmp::Ordering {
        other.value.cmp(&self.value)
    }
}

impl PartialOrd for Item {
    fn partial_cmp(&self, other: &Self) -> Option<std::cmp::Ordering> {
        Some(self.cmp(other))
    }
}

impl Solution {
    pub fn max_spending(values: Vec<Vec<i32>>) -> i64 {
        let m = values.len();
        let n = values[0].len();
        let mut pq = BinaryHeap::new();
        for i in 0..m {
            pq.push(Item { value: values[i][n - 1], i, j: n - 1 });
        }
        
        let mut ans: i64 = 0;
        for turn in 1..= m * n {
            if let Some(top) = pq.pop() {
                let val = top.value;
                let i = top.i;
                let j = top.j;
                ans += (val as i64) * (turn as i64);
                if j > 0 {
                    pq.push(Item { value: values[i][j - 1], i, j: j - 1 });
                }
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mnlogm)$。
- 空间复杂度：$O(m)$，即为小根堆（优先队列）需要使用的空间。
