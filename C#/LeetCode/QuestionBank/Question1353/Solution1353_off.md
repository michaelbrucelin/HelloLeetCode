### [最多可以参加的会议数目](https://leetcode.cn/problems/maximum-number-of-events-that-can-be-attended/solutions/101227/zui-duo-ke-yi-can-jia-de-hui-yi-shu-mu-by-leetcode/)

#### 方法一：贪心

**思路与算法**

根据题意可知，会议 $i$ 开始于 $startDay_i$，结束于 $endDay_i$，此时可以在区间 $[startDay_i,endDay_i]$ 中任意安排一天参会即可。由于每天只能参加一场会议，根据贪心原则可知，如果第 $k$ 天可以安排参加会议 $i$ 和 $j$，此时应尽量安排**结束时间** $min(endDay_i,endDay_j)$ 较早的会议，才能使得剩余时间还可以安排**结束时间**较晚的会议。

根据上述推论可知，设所有会议结束的最晚时间为 $maxDay$，我们可以从 $1$ 开始枚举每个时间点，直到 $maxDay$ 结束，贪心选择该时间点下结束会议最早的时间。用**最小堆**保存当前待选择会议的结束时间，为了方便计算，将所有的会议按照开始时间先后顺序进行排序。假设当前时间点为 $i$，此时应处理如下：

- 将当前所有参会时间早于或等于 $i$ 的会议全部加入到待选队列中，此时**小根堆**中保存所有待选会议；
- 由于结束时间早于 $i$ 的会议无法参会，此时将所有结束时间小于 $i$ 的会议从待选队列中删除；
- 此时选择待选会议中结束时间最早的会议参会，当前堆顶元素即为最早的会议结束时间，当前时间点 $i$ 选择该会议参会即可，同时可参会计数加 $1$；

返回最终的参会计数即为答案。

**代码**

```C++
class Solution {
public:
    int maxEvents(vector<vector<int>>& events) {
        int n = events.size();
        int maxDay = 0;
        for (int i = 0; i < events.size(); i++) {
            maxDay = max(maxDay, events[i][1]);
        }
        priority_queue<int, vector<int>, greater<>> pq;
        sort(events.begin(), events.end());
        int ans = 0;
        for (int i = 0, j = 0; i <= maxDay; i++) {
            while (j < n && events[j][0] <= i) {
                pq.emplace(events[j][1]);
                j++;
            }
            while (!pq.empty() && pq.top() < i) {
                pq.pop();
            }
            if (!pq.empty()) {
                pq.pop();
                ans++;
            }
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int maxEvents(int[][] events) {
        int n = events.length;
        int maxDay = 0;
        for (int[] event : events) {
            maxDay = Math.max(maxDay, event[1]);
        }

        PriorityQueue<Integer> pq = new PriorityQueue<>();
        Arrays.sort(events, (a, b) -> a[0] - b[0]);
        int ans = 0;
        for (int i = 1, j = 0; i <= maxDay; i++) {
            while (j < n && events[j][0] <= i) {
                pq.offer(events[j][1]);
                j++;
            }
            while (!pq.isEmpty() && pq.peek() < i) {
                pq.poll();
            }
            if (!pq.isEmpty()) {
                pq.poll();
                ans++;
            }
        }
        
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaxEvents(int[][] events) {
        int n = events.Length;
        int maxDay = 0;
        foreach (var e in events) {
            maxDay = Math.Max(maxDay, e[1]);
        }
        
        var pq = new PriorityQueue<int, int>();
        Array.Sort(events, (a, b) => a[0] - b[0]);
        int ans = 0;
        for (int i = 1, j = 0; i <= maxDay; i++) {
            while (j < n && events[j][0] <= i) {
                pq.Enqueue(events[j][1], events[j][1]);
                j++;
            }
            while (pq.Count > 0 && pq.Peek() < i) {
                pq.Dequeue();
            }
            if (pq.Count > 0) {
                pq.Dequeue();
                ans++;
            }
        }

        return ans;
    }
}
```

```Go
func maxEvents(events [][]int) int {
    n := len(events)
    maxDay := 0
    for _, event := range events {
        if event[1] > maxDay {
            maxDay = event[1]
        }
    }
    sort.Slice(events, func(i, j int) bool {
        return events[i][0] < events[j][0]
    })
    pq := &IntHeap{}
    heap.Init(pq)
    ans := 0
    for i, j := 1, 0; i <= maxDay; i++ {
        for j < n && events[j][0] <= i {
            heap.Push(pq, events[j][1])
            j++
        }
        for pq.Len() > 0 && (*pq)[0] < i {
            heap.Pop(pq)
        }
        if pq.Len() > 0 {
            heap.Pop(pq)
            ans++
        }
    }
    return ans
}

type IntHeap []int

func (h IntHeap) Len() int { 
    return len(h) 
}

func (h IntHeap) Less(i, j int) bool { 
    return h[i] < h[j] 
}

func (h IntHeap) Swap(i, j int) { 
    h[i], h[j] = h[j], h[i] 
}

func (h *IntHeap) Push(x any) { 
    *h = append(*h, x.(int)) 
}

func (h *IntHeap) Pop() any {
    old := *h
    n := len(old)
    x := old[n - 1]
    *h = old[0 : n - 1]
    return x
}
```

```Python
class Solution:
    def maxEvents(self, events: List[List[int]]) -> int:
        n = len(events)
        max_day = max(event[1] for event in events)
        events.sort()
        pq = []
        ans, j = 0, 0
        for i in range(1, max_day + 1):
            while j < n and events[j][0] <= i:
                heapq.heappush(pq, events[j][1])
                j += 1
            while pq and pq[0] < i:
                heapq.heappop(pq)
            if pq:
                heapq.heappop(pq)
                ans += 1
                
        return ans
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int data;
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

static bool greater(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data > e2->data;
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

int cmp(const void *a, const void *b) {
    return (*(int **)a)[0] - (*(int **)b)[0];
};

int maxEvents(int** events, int eventsSize, int* eventsColSize) {
    int n = eventsSize;
    int maxDay = 0;
    for (int i = 0; i < eventsSize; i++) {
        maxDay = fmax(maxDay, events[i][1]);
    }

    PriorityQueue *pq = createPriorityQueue(greater);
    qsort(events, eventsSize, sizeof(events[0]), cmp);
    int ans = 0;
    for (int i = 1, j = 0; i <= maxDay; i++) {
        while (j < n && events[j][0] <= i) {
            Element e = {events[j][1]};
            enQueue(pq, &e);
            j++;
        }
        while (!isEmpty(pq) && front(pq)->data < i) {
            deQueue(pq);
        }
        if (!isEmpty(pq)) {
            deQueue(pq);
            ans++;
        }
    }

    freeQueue(pq);
    return ans;
}
```

```JavaScript
var maxEvents = function(events) {
    const n = events.length;
    let maxDay = 0;
    for (const e of events) {
        maxDay = Math.max(maxDay, e[1]);
    }
    events.sort((a, b) => a[0] - b[0]);
    const pq = new MinPriorityQueue();
    let ans = 0;
    for (let i = 1, j = 0; i <= maxDay; i++) {
        while (j < n && events[j][0] <= i) {
            pq.enqueue(events[j][1]);
            j++;
        }
        while (!pq.isEmpty() && pq.front() < i) {
            pq.dequeue();
        }
        if (!pq.isEmpty()) {
            pq.dequeue();
            ans++;
        }
    }
    return ans;
};
```

```TypeScript
function maxEvents(events: number[][]): number {
    const n = events.length;
    let maxDay = 0;
    for (const e of events) {
        maxDay = Math.max(maxDay, e[1]);
    }
    events.sort((a, b) => a[0] - b[0]);
    const pq = new MinPriorityQueue<number>();
    let ans = 0;
    for (let i = 1, j = 0; i <= maxDay; i++) {
        while (j < n && events[j][0] <= i) {
            pq.enqueue(events[j][1]);
            j++;
        }
        while (!pq.isEmpty() && pq.front() < i) {
            pq.dequeue();
        }
        if (!pq.isEmpty()) {
            pq.dequeue();
            ans++;
        }
    }
    return ans;
}
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

impl Solution {
    pub fn max_events(events: Vec<Vec<i32>>) -> i32 {
        let mut events = events;
        events.sort_by(|a, b| a[0].cmp(&b[0]));
        let max_day = events.iter().map(|e| e[1]).max().unwrap_or(0);
        let mut pq = BinaryHeap::new();
        let mut ans = 0;
        let mut j = 0;
        for i in 1..= max_day {
            while j < events.len() && events[j][0] <= i {
                pq.push(Reverse(events[j][1]));
                j += 1;
            }
            while let Some(&Reverse(end)) = pq.peek() {
                if end < i {
                    pq.pop();
                } else {
                    break;
                }
            }
            if let Some(Reverse(_)) = pq.pop() {
                ans += 1;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O((T+n)\log n)$，其中 $n$ 表示给定数组 $events$ 的长度，$T$ 表示 $events$ 中结束时间的最大值。将数组 $events$ 排序需要的时间为 $O(n\log n)$，一共需要枚举 $T$ 个时间，由于优先队列中最多有 $n$ 个元素，每个时间点进出队列的时间为 $O(\log n)$，因此枚举并操作优先队列的时间为 $O(T\log n)$，总的时间复杂度为 $O((T+n)\log n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组 $events$ 的长度。用优先队列来保存所有待选会议，此时优先队列中最多存在 $n$ 个元素，因此空间复杂度为 $O(n)$。
