### [最低加油次数](https://leetcode.cn/problems/minimum-number-of-refueling-stops/solutions/1636921/zui-di-jia-you-ci-shu-by-leetcode-soluti-nmga/)

#### 方法一：动态规划

由于数组 $stations$ 按照加油站的位置非递减排序，因此从左到右遍历数组 $stations$ 的过程中，当遍历到一个加油站时，位置小于该加油站的所有加油站都已经被遍历过。

用 $n$ 表示数组 $stations$ 的长度，即加油站的个数。最多可以加油 $n$ 次，为了得到可以到达目的地的最少加油次数，需要计算每个加油次数对应的最大行驶英里数，然后得到最大行驶英里数大于等于 $target$ 的最少加油次数。

用 $dp[i]$ 表示加油 $i$ 次的最大行驶英里数。由于初始时汽油量是 $startFuel$ 升，可以行驶 $startFuel$ 英里，因此 $dp[0]=startFuel$。

当遍历到加油站 $stations[i]$ 时，假设在到达该加油站之前已经加油 $j$ 次，其中 $0 \le j \le i$，则只有当 $dp[j] \ge stations[i][0]$ 时才能在加油 $j$ 次的情况下到达加油站 $stations[i]$ 的位置，在加油站 $stations[i]$ 加油之后，共加油 $j+1$ 次，可以行驶的英里数是 $dp[j]+stations[i][1]$。遍历满足 $0 \le j \le i$ 且 $dp[j] \ge stations[i][0]$ 的每个下标 $j$，计算 $dp[j+1]$ 的最大值。

当遍历到加油站 $stations[i]$ 时，对于每个符合要求的下标 $j$，计算 $dp[j+1]$ 时都是将加油站 $stations[i]$ 作为最后一次加油的加油站。为了确保每个 $dp[j+1]$ 的计算中，加油站 $stations[i]$ 只会被计算一次，应该按照从大到小的顺序遍历下标 $j$。

以示例 3 为例。对于加油站 $stations[2]$ 计算之后，$dp[2]=100$。对于加油站 $stations[3]$ 计算的过程中会将 $dp[2]$ 的值更新为 $110$，如果在计算 $dp[3]$ 之前计算 $dp[2]$，则 $dp[3]$ 的值将被错误地计算为 $dp[2]+stations[3][1]=150$。只有当从大到小遍历下标 $j$ 时，才能得到 $dp[3]=140$ 的正确结果。

当所有的加油站遍历结束之后，遍历 $dp$，寻找使得 $dp[i] \ge target$ 的最小下标 $i$ 并返回。如果不存在这样的下标，则无法到达目的地，返回 $-1$。

```Python
class Solution:
    def minRefuelStops(self, target: int, startFuel: int, stations: List[List[int]]) -> int:
        dp = [startFuel] + [0] * len(stations)
        for i, (pos, fuel) in enumerate(stations):
            for j in range(i, -1, -1):
                if dp[j] >= pos:
                    dp[j + 1] = max(dp[j + 1], dp[j] + fuel)
        return next((i for i, v in enumerate(dp) if v >= target), -1)
```

```Java
class Solution {
    public int minRefuelStops(int target, int startFuel, int[][] stations) {
        int n = stations.length;
        long[] dp = new long[n + 1];
        dp[0] = startFuel;
        for (int i = 0; i < n; i++) {
            for (int j = i; j >= 0; j--) {
                if (dp[j] >= stations[i][0]) {
                    dp[j + 1] = Math.max(dp[j + 1], dp[j] + stations[i][1]);
                }
            }
        }
        for (int i = 0; i <= n; i++) {
            if (dp[i] >= target) {
                return i;
            }
        }
        return -1;
    }
}
```

```CSharp
public class Solution {
    public int MinRefuelStops(int target, int startFuel, int[][] stations) {
        int n = stations.Length;
        long[] dp = new long[n + 1];
        dp[0] = startFuel;
        for (int i = 0; i < n; i++) {
            for (int j = i; j >= 0; j--) {
                if (dp[j] >= stations[i][0]) {
                    dp[j + 1] = Math.Max(dp[j + 1], dp[j] + stations[i][1]);
                }
            }
        }
        for (int i = 0; i <= n; i++) {
            if (dp[i] >= target) {
                return i;
            }
        }
        return -1;
    }
}
```

```C++
class Solution {
public:
    int minRefuelStops(int target, int startFuel, vector<vector<int>>& stations) {
        int n = stations.size();
        vector<long> dp(n + 1);
        dp[0] = startFuel;
        for (int i = 0; i < n; i++) {
            for (int j = i; j >= 0; j--) {
                if (dp[j] >= stations[i][0]) {
                    dp[j + 1] = max(dp[j + 1], dp[j] + stations[i][1]);
                }
            }
        }
        for (int i = 0; i <= n; i++) {
            if (dp[i] >= target) {
                return i;
            }
        }
        return -1;
    }
};
```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int minRefuelStops(int target, int startFuel, int** stations, int stationsSize, int* stationsColSize){
    long *dp = (long *)malloc(sizeof(long) * (stationsSize + 1));
    memset(dp, 0, sizeof(long) * (stationsSize + 1));
    dp[0] = startFuel;
    for (int i = 0; i < stationsSize; i++) {
        for (int j = i; j >= 0; j--) {
            if (dp[j] >= stations[i][0]) {
                dp[j + 1] = MAX(dp[j + 1], dp[j] + stations[i][1]);
            }
        }
    }
    for (int i = 0; i <= stationsSize; i++) {
        if (dp[i] >= target) {
            free(dp);
            return i;
        }
    }
    free(dp);
    return -1;
}
```

```Go
func minRefuelStops(target, startFuel int, stations [][]int) int {
    n := len(stations)
    dp := make([]int, n+1)
    dp[0] = startFuel
    for i, s := range stations {
        for j := i; j >= 0; j-- {
            if dp[j] >= s[0] {
                dp[j+1] = max(dp[j+1], dp[j]+s[1])
            }
        }
    }
    for i, v := range dp {
        if v >= target {
            return i
        }
    }
    return -1
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

```JavaScript
var minRefuelStops = function(target, startFuel, stations) {
    const n = stations.length;
    const dp = new Array(n + 1).fill(0);
    dp[0] = startFuel;
    for (let i = 0; i < n; i++) {
        for (let j = i; j >= 0; j--) {
            if (dp[j] >= stations[i][0]) {
                dp[j + 1] = Math.max(dp[j + 1], dp[j] + stations[i][1]);
            }
        }
    }
    for (let i = 0; i <= n; i++) {
        if (dp[i] >= target) {
            return i;
        }
    }
    return -1;
};
```

```TypeScript
function minRefuelStops(target: number, startFuel: number, stations: number[][]): number {
    const n = stations.length;
    const dp = new Array(n + 1).fill(0);
    dp[0] = startFuel;
    for (let i = 0; i < n; i++) {
        for (let j = i; j >= 0; j--) {
            if (dp[j] >= stations[i][0]) {
                dp[j + 1] = Math.max(dp[j + 1], dp[j] + stations[i][1]);
            }
        }
    }
    for (let i = 0; i <= n; i++) {
        if (dp[i] >= target) {
            return i;
        }
    }
    return -1;
};
```

```Rust
impl Solution {
    pub fn min_refuel_stops(target: i32, start_fuel: i32, stations: Vec<Vec<i32>>) -> i32 {
        let n = stations.len();
        let mut dp = vec![0; n + 1];
        dp[0] = start_fuel;
        for i in 0..n {
            for j in (0..=i).rev() {
                if dp[j] >= stations[i][0] {
                    dp[j + 1] = dp[j + 1].max(dp[j] + stations[i][1]);
                }
            }
        }
        for i in 0..=n {
            if dp[i] >= target {
                return i as i32;
            }
        }
        -1
    }
}
```

```Cangjie
class Solution {
    func minRefuelStops(target: Int64, startFuel: Int64, stations: Array<Array<Int64>>): Int64 {
        let n = stations.size
        var dp = Array<Int64>(n + 1, item: 0)
        dp[0] = startFuel
        for (i in 0..n) {
            for (j in i..-1 : -1) {
                if (dp[j] >= stations[i][0]) {
                    dp[j + 1] = max(dp[j + 1], dp[j] + stations[i][1])
                }
            }
        }
        for (i in 0..= n) {
            if (dp[i] >= target) {
                return i
            }
        }
        return -1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $stations$ 的长度。动态规划的状态数是 $O(n)$，每个状态需要 $O(n)$ 的时间计算，因此时间复杂度是 $O(n^2)$。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $stations$ 的长度。需要创建长度为 $n+1$ 的数组 $dp$。

#### 方法二：贪心

用 $n$ 表示数组 $stations$ 的长度，即加油站的个数。行驶的过程中依次到达 $n+1$ 个位置，分别是 $n$ 个加油站和目的地。为了得到最少加油次数，应该在确保每个位置都能到达的前提下，选择最大加油量的加油站加油。

为了得到已经到达过的加油站中的最大加油量，需要使用优先队列记录所有已经到达过的加油站的加油量，优先队列中的最大元素位于队首，即每次从优先队列中取出的元素都是优先队列中的最大元素。

从左到右遍历数组 $stations$，对于每个加油站，首先判断该位置是否可以达到，然后将当前加油站的加油量添加到优先队列中。对于目的地，则只需要判断是否可以达到。

具体做法如下。

1. 计算当前位置（加油站或目的地）与上一个位置的距离之差，根据该距离之差得到从上一个位置行驶到当前位置需要使用的汽油量，将使用的汽油量从剩余的汽油量中减去。
2. 如果剩余的汽油量小于 $0$，则表示在不加油的情况下无法从上一个位置行驶到当前位置，需要加油。取出优先队列中的最大元素加到剩余的汽油量，并将加油次数加 $1$，重复该操作直到剩余的汽油量大于等于 $0$ 或优先队列变为空。
3. 如果优先队列变为空时，剩余的汽油量仍小于 $0$，则表示在所有经过的加油站加油之后仍然无法到达当前位置，返回 $-1$。
4. 如果当前位置是加油站，则将当前加油站的加油量添加到优先队列中，并使用当前位置更新上一个位置。

如果无法到达目的地，则在遍历过程中返回 $-1$。如果遍历结束仍未返回 $-1$，则可以到达目的地，返回加油次数。

```Python
class Solution:
    def minRefuelStops(self, target: int, startFuel: int, stations: List[List[int]]) -> int:
        n = len(stations)
        ans, fuel, prev, h = 0, startFuel, 0, []
        for i in range(n + 1):
            curr = stations[i][0] if i < n else target
            fuel -= curr - prev
            while fuel < 0 and h:
                fuel -= heappop(h)
                ans += 1
            if fuel < 0:
                return -1
            if i < n:
                heappush(h, -stations[i][1])
                prev = curr
        return ans
```

```Java
class Solution {
    public int minRefuelStops(int target, int startFuel, int[][] stations) {
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>((a, b) -> b - a);
        int ans = 0, prev = 0, fuel = startFuel;
        int n = stations.length;
        for (int i = 0; i <= n; i++) {
            int curr = i < n ? stations[i][0] : target;
            fuel -= curr - prev;
            while (fuel < 0 && !pq.isEmpty()) {
                fuel += pq.poll();
                ans++;
            }
            if (fuel < 0) {
                return -1;
            }
            if (i < n) {
                pq.offer(stations[i][1]);
                prev = curr;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinRefuelStops(int target, int startFuel, int[][] stations) {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        int ans = 0, prev = 0, fuel = startFuel;
        int n = stations.Length;
        for (int i = 0; i <= n; i++) {
            int curr = i < n ? stations[i][0] : target;
            fuel -= curr - prev;
            while (fuel < 0 && pq.Count > 0) {
                fuel += pq.Dequeue();
                ans++;
            }
            if (fuel < 0) {
                return -1;
            }
            if (i < n) {
                pq.Enqueue(stations[i][1], -stations[i][1]);
                prev = curr;
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int minRefuelStops(int target, int startFuel, vector<vector<int>>& stations) {
        priority_queue<int> pq;
        int ans = 0, prev = 0, fuel = startFuel;
        int n = stations.size();
        for (int i = 0; i <= n; i++) {
            int curr = i < n ? stations[i][0] : target;
            fuel -= curr - prev;
            while (fuel < 0 && !pq.empty()) {
                fuel += pq.top();
                pq.pop();
                ans++;
            }
            if (fuel < 0) {
                return -1;
            }
            if (i < n) {
                pq.emplace(stations[i][1]);
                prev = curr;
            }
        }
        return ans;
    }
};
```

```Go
func minRefuelStops(target, startFuel int, stations [][]int) (ans int) {
    fuel, prev, h := startFuel, 0, hp{}
    for i, n := 0, len(stations); i <= n; i++ {
        curr := target
        if i < n {
            curr = stations[i][0]
        }
        fuel -= curr - prev
        for fuel < 0 && h.Len() > 0 {
            fuel += heap.Pop(&h).(int)
            ans++
        }
        if fuel < 0 {
            return -1
        }
        if i < n {
            heap.Push(&h, stations[i][1])
            prev = curr
        }
    }
    return
}

type hp struct{ sort.IntSlice }
func (h hp) Less(i, j int) bool  { return h.IntSlice[i] > h.IntSlice[j] }
func (h *hp) Push(v interface{}) { h.IntSlice = append(h.IntSlice, v.(int)) }
func (h *hp) Pop() interface{}   { a := h.IntSlice; v := a[len(a)-1]; h.IntSlice = a[:len(a)-1]; return v }
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

int minRefuelStops(int target, int startFuel, int** stations, int stationsSize, int* stationsColSize) {
    PriorityQueue *pq = createPriorityQueue(greater);
    int ans = 0, prev = 0, fuel = startFuel;
    int n = stationsSize;
    for (int i = 0; i <= n; i++) {
        int curr = i < n ? stations[i][0] : target;
        fuel -= curr - prev;
        while (fuel < 0 && !isEmpty(pq)) {
            Element *p = front(pq);
            fuel += p->data[0];
            deQueue(pq);
            ans++;
        }
        if (fuel < 0) {
            freeQueue(pq);
            return -1;
        }
        if (i < n) {
            Element e;
            e.data[0] = stations[i][1];
            enQueue(pq, &e);
            prev = curr;
        }
    }

    freeQueue(pq);
    return ans;
}
```

```JavaScript
var minRefuelStops = function(target, startFuel, stations) {
    const pq = new MaxPriorityQueue();
    let ans = 0, prev = 0, fuel = startFuel;
    const n = stations.length;
    for (let i = 0; i <= n; i++) {
        let curr = i < n ? stations[i][0] : target;
        fuel -= curr - prev;
        while (fuel < 0 && !pq.isEmpty()) {
            fuel += pq.front().element;
            pq.dequeue();
            ans++;
        }
        if (fuel < 0) {
            return -1;
        }
        if (i < n) {
            pq.enqueue(stations[i][1], stations[i][1]);
            prev = curr;
        }
    }
    return ans;
};
```

```TypeScript
function minRefuelStops(target: number, startFuel: number, stations: number[][]): number {
    const pq = new MaxPriorityQueue();
    let ans = 0, prev = 0, fuel = startFuel;
    const n = stations.length;
    for (let i = 0; i <= n; i++) {
        let curr = i < n ? stations[i][0] : target;
        fuel -= curr - prev;
        while (fuel < 0 && !pq.isEmpty()) {
            fuel += pq.front().element;
            pq.dequeue();
            ans++;
        }
        if (fuel < 0) {
            return -1;
        }
        if (i < n) {
            pq.enqueue(stations[i][1], stations[i][1]);
            prev = curr;
        }
    }
    return ans;
};
```

```Rust
use std::collections::BinaryHeap;

impl Solution {
    pub fn min_refuel_stops(target: i32, start_fuel: i32, stations: Vec<Vec<i32>>) -> i32 {
        let mut pq = BinaryHeap::new();
        let mut ans = 0;
        let mut prev = 0;
        let mut fuel = start_fuel;
        let n = stations.len();

        for i in 0..=n {
            let curr = if i < n { stations[i][0]} else { target };
            fuel -= curr - prev;
            while fuel < 0 && !pq.is_empty() {
                if let Some(max_fuel) = pq.pop() {
                    fuel += max_fuel;
                    ans += 1;
                }
            }
            if fuel < 0 {
                return -1;
            }
            if i < n {
                pq.push(stations[i][1]);
                prev = curr;
            }
        }
        ans
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
            // 父节点 (k - 1) / 2，左子节点 k，右子节点 k + 1
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

class Solution {
    func minRefuelStops(target: Int64, startFuel: Int64, stations: Array<Array<Int64>>): Int64 {
        let maxComparator = {a: Int64, b: Int64 => a < b }
        let pq = PriorityQueue<Int64>(maxComparator)
        var ans = 0
        var prev = 0
        var fuel = startFuel
        let n = stations.size
        for (i in 0..= n) {
            var curr = target
            if (i < n) {
                curr = stations[i][0]
            }
            fuel -= curr - prev
            while (fuel < 0 && !pq.isEmpty()) {
                fuel += pq.dequeue().getOrThrow()
                ans++
            }
            if (fuel < 0) {
                return -1
            }
            if (i < n) {
                pq.enqueue(stations[i][1])
                prev = curr
            }
        }

        return ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 是数组 $stations$ 的长度。需要遍历数组 $stations$ 一次，每个加油站的汽油量最多添加到优先队列和从优先队列中移除各一次，每次优先队列的操作需要 $O(logn)$ 的时间，因此时间复杂度是 $O(nlogn)$。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $stations$ 的长度。优先队列需要 $O(n)$ 的空间。
