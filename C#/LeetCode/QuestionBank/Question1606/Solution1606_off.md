### [找到处理最多请求的服务器](https://leetcode.cn/problems/find-servers-that-handled-most-number-of-requests/solutions/1368833/zhao-dao-chu-li-zui-duo-qing-qiu-de-fu-w-e0a5/)

#### 方法一: 模拟 + 有序集合 + 优先队列

**思路与算法**

将空闲服务器的编号都放入一个有序集合 $available$ 中，将正在处理请求的服务器的处理结束时间和编号都放入一个优先队列 $busy$ 中，优先队列满足队首的服务器的处理结束时间最小，用一个数组 $requests$ 记录对应服务器处理的请求数目。

假设当前到达的请求为第 $i$ 个，如果 $busy$ 不为空，那么我们判断 $busy$ 的队首对应的服务器的结束时间是否小于等于当前请求的到达时间 $arrival[i]$，如果是，那么我们将它从 $busy$ 中移除，并且将该服务器的编号放入 $available$ 中，然后再次进行判断。如果 $available$ 为空，那么该请求被丢弃；否则查找 $available$ 中大于等于 $i\bmod k$ 的第一个元素，如果查找成功，那么将它作为处理请求的服务器，否则将 $available$ 中编号最小的服务器作为处理请求的服务器。设处理请求的服务器的编号为 $j$，那么将 $requests[j]$ 加 $1$，并且将该服务器从 $available$ 移除，然后将服务器 $j$ 放入 $busy$ 中，对应的处理结束时间为 $arrival[i]+load[i]$。

获取 $requests$ 的最大值 $maxRequest$，遍历 $requests$ 数组，对于每个下标 $i$，如果 $requests[i]=maxRequest$，那么将编号 $i$ 加入结果中。

**代码**

```Python
from sortedcontainers import SortedList

class Solution:
    def busiestServers(self, k: int, arrival: List[int], load: List[int]) -> List[int]:
        available = SortedList(range(k))
        busy = []
        requests = [0] * k
        for i, (start, t) in enumerate(zip(arrival, load)):
            while busy and busy[0][0] <= start:
                available.add(busy[0][1])
                heappop(busy)
            if len(available) == 0:
                continue
            j = available.bisect_left(i % k)
            if j == len(available):
                j = 0
            id = available[j]
            requests[id] += 1
            heappush(busy, (start + t, id))
            available.remove(id)
        maxRequest = max(requests)
        return [i for i, req in enumerate(requests) if req == maxRequest]
```

```C++
class Solution {
public:
    vector<int> busiestServers(int k, vector<int> &arrival, vector<int> &load) {
        set<int> available;
        for (int i = 0; i < k; i++) {
            available.insert(i);
        }
        priority_queue<pair<int, int>, vector<pair<int, int>>, greater<>> busy;
        vector<int> requests(k);
        for (int i = 0; i < arrival.size(); i++) {
            while (!busy.empty() && busy.top().first <= arrival[i]) {
                available.insert(busy.top().second);
                busy.pop();
            }
            if (available.empty()) {
                continue;
            }
            auto p = available.lower_bound(i % k);
            if (p == available.end()) {
                p = available.begin();
            }
            requests[*p]++;
            busy.emplace(arrival[i] + load[i], *p);
            available.erase(p);
        }
        int maxRequest = *max_element(requests.begin(), requests.end());
        vector<int> ret;
        for (int i = 0; i < k; i++) {
            if (requests[i] == maxRequest) {
                ret.push_back(i);
            }
        }
        return ret;
    }
};
```

```Java
class Solution {
    public List<Integer> busiestServers(int k, int[] arrival, int[] load) {
        TreeSet<Integer> available = new TreeSet<Integer>();
        for (int i = 0; i < k; i++) {
            available.add(i);
        }
        PriorityQueue<int[]> busy = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);
        int[] requests = new int[k];
        for (int i = 0; i < arrival.length; i++) {
            while (!busy.isEmpty() && busy.peek()[0] <= arrival[i]) {
                available.add(busy.poll()[1]);
            }
            if (available.isEmpty()) {
                continue;
            }
            Integer p = available.ceiling(i % k);
            if (p == null) {
                p = available.first();
            }
            requests[p]++;
            busy.offer(new int[]{arrival[i] + load[i], p});
            available.remove(p);
        }
        int maxRequest = Arrays.stream(requests).max().getAsInt();
        List<Integer> ret = new ArrayList<Integer>();
        for (int i = 0; i < k; i++) {
            if (requests[i] == maxRequest) {
                ret.add(i);
            }
        }
        return ret;
    }
}
```

```Go
func busiestServers(k int, arrival, load []int) (ans []int) {
    available := redblacktree.NewWithIntComparator()
    for i := 0; i < k; i++ {
        available.Put(i, nil)
    }
    busy := hp{}
    requests := make([]int, k)
    maxRequest := 0
    for i, t := range arrival {
        for len(busy) > 0 && busy[0].end <= t {
            available.Put(busy[0].id, nil)
            heap.Pop(&busy)
        }
        if available.Size() == 0 {
            continue
        }
        node, _ := available.Ceiling(i % k)
        if node == nil {
            node = available.Left()
        }
        id := node.Key.(int)
        requests[id]++
        if requests[id] > maxRequest {
            maxRequest = requests[id]
            ans = []int{id}
        } else if requests[id] == maxRequest {
            ans = append(ans, id)
        }
        heap.Push(&busy, pair{t + load[i], id})
        available.Remove(id)
    }
    return
}

type pair struct{ end, id int }
type hp []pair
func (h hp) Len() int            { return len(h) }
func (h hp) Less(i, j int) bool  { return h[i].end < h[j].end }
func (h hp) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *hp) Push(v interface{}) { *h = append(*h, v.(pair)) }
func (h *hp) Pop() interface{}   { a := *h; v := a[len(a)-1]; *h = a[:len(a)-1]; return v }
```

```CSharp
public class Solution {
    public IList<int> BusiestServers(int k, int[] arrival, int[] load) {
        SortedSet<int> available = new SortedSet<int>();
        for (int i = 0; i < k; i++) {
            available.Add(i);
        }

        PriorityQueue<(int finishTime, int server), int> busy = new PriorityQueue<(int, int), int>(
            Comparer<int>.Create((a, b) => a.CompareTo(b))
        );

        int[] requests = new int[k];

        for (int i = 0; i < arrival.Length; i++) {
            while (busy.Count > 0 && busy.Peek().finishTime <= arrival[i]) {
                var item = busy.Dequeue();
                available.Add(item.server);
            }

            if (available.Count == 0) {
                continue;
            }

            int target = i % k;
            int? p = null;
            foreach (int server in available) {
                if (server >= target) {
                    p = server;
                    break;
                }
            }

            if (p == null) {
                p = available.Min;
            }

            requests[p.Value]++;
            busy.Enqueue((arrival[i] + load[i], p.Value), arrival[i] + load[i]);
            available.Remove(p.Value);
        }

        int maxRequest = requests.Max();
        List<int> ret = new List<int>();
        for (int i = 0; i < k; i++) {
            if (requests[i] == maxRequest) {
                ret.Add(i);
            }
        }
        return ret;
    }
}
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int data[2];
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

static void memswap(void *m1, void *m2, size_t size) {
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

void enQueue(PriorityQueue *obj, Element *e) {
    if (obj->queueSize == obj->capacity) {
        obj->capacity *= 2;
        obj->arr = (Element *)realloc(obj->arr, sizeof(Element) * obj->capacity);
    }
    memcpy(&obj->arr[obj->queueSize], e, sizeof(Element));
    for (int i = obj->queueSize; i > 0 && obj->lessFunc(&obj->arr[(i - 1) / 2], &obj->arr[i]); i = (i - 1) / 2) {
        swap(obj->arr, i, (i - 1) / 2);
    }
    obj->queueSize++;
}

bool deQueue(PriorityQueue *obj, Element *out) {
    if (obj->queueSize == 0) {
        return false;
    }
    memcpy(out, &obj->arr[0], sizeof(Element));
    swap(obj->arr, 0, obj->queueSize - 1);
    down(obj->arr, obj->queueSize - 1, 0, obj->lessFunc);
    obj->queueSize--;
    return true;
}

bool isEmpty(const PriorityQueue *obj) {
    return obj->queueSize == 0;
}

bool front(const PriorityQueue *obj, Element *out) {
    if (obj->queueSize == 0) {
        return false;
    }
    memcpy(out, &obj->arr[0], sizeof(Element));
    return true;
}

void freeQueue(PriorityQueue *obj) {
    free(obj->arr);
    free(obj);
}

static bool busyLess(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    if (e1->data[0] != e2->data[0]) {
        return e1->data[0] > e2->data[0];
    }
    return e1->data[1] > e2->data[1];
}

static gint int_compare(gconstpointer a, gconstpointer b, gpointer user_data) {
    int ia = GPOINTER_TO_INT(a);
    int ib = GPOINTER_TO_INT(b);
    return ia - ib;
}

typedef struct {
    GTree *tree;
} AvailableSet;

AvailableSet* createAvailableSet(int k) {
    AvailableSet *set = g_malloc(sizeof(AvailableSet));
    set->tree = g_tree_new_full((GCompareDataFunc)int_compare, NULL,
                                NULL, NULL);
    for (int i = 0; i < k; i++) {
        g_tree_insert(set->tree, GINT_TO_POINTER(i), GINT_TO_POINTER(i));
    }
    return set;
}

void availableAdd(AvailableSet *set, int value) {
    g_tree_insert(set->tree, GINT_TO_POINTER(value), GINT_TO_POINTER(value));
}

void availableRemove(AvailableSet *set, int value) {
    g_tree_remove(set->tree, GINT_TO_POINTER(value));
}

int availableSize(AvailableSet *set) {
    return g_tree_nnodes(set->tree);
}

int availableCeil(AvailableSet *set, int target) {
    GTreeNode *node = g_tree_lower_bound(set->tree, GINT_TO_POINTER(target));
    if (node) {
        return GPOINTER_TO_INT(g_tree_node_key(node));
    }
    node = g_tree_node_first(set->tree);
    if (node) {
        return GPOINTER_TO_INT(g_tree_node_key(node));
    }
    return -1;
}

void freeAvailableSet(AvailableSet *set) {
    g_tree_destroy(set->tree);
    g_free(set);
}

int* busiestServers(int k, int* arrival, int arrivalSize, int* load, int loadSize, int* returnSize) {
    AvailableSet *available = createAvailableSet(k);
    PriorityQueue *busy = createPriorityQueue(busyLess);
    int *requests = (int *)calloc(k, sizeof(int));

    for (int i = 0; i < arrivalSize; i++) {
        Element frontElem;
        while (!isEmpty(busy)) {
            front(busy, &frontElem);
            if (frontElem.data[0] > arrival[i]) break;
            deQueue(busy, &frontElem);
            availableAdd(available, frontElem.data[1]);
        }

        if (availableSize(available) == 0) {
            continue;
        }

        int target = i % k;
        int p = availableCeil(available, target);
        requests[p]++;
        Element e;
        e.data[0] = arrival[i] + load[i];
        e.data[1] = p;
        enQueue(busy, &e);
        availableRemove(available, p);
    }

    int maxRequest = 0;
    for (int i = 0; i < k; i++) {
        if (requests[i] > maxRequest) maxRequest = requests[i];
    }

    int *ret = (int *)malloc(sizeof(int) * k);
    *returnSize = 0;
    for (int i = 0; i < k; i++) {
        if (requests[i] == maxRequest) {
            ret[(*returnSize)++] = i;
        }
    }

    freeAvailableSet(available);
    freeQueue(busy);
    free(requests);
    return ret;
}

```

```JavaScript
const { AvlTree } = require('@datastructures-js/binary-search-tree');

var busiestServers = function(k, arrival, load) {
    const available = new AvlTree();
    for (let i = 0; i < k; i++) {
        available.insert(i);
    }

    const busy = new MinPriorityQueue({
        compare: (a, b) => {
            if (a[0] !== b[0]) return a[0] - b[0];
            return a[1] - b[1];
        }
    });

    const requests = new Array(k).fill(0);

    for (let i = 0; i < arrival.length; i++) {
        while (!busy.isEmpty() && busy.front()[0] <= arrival[i]) {
            const [, server] = busy.dequeue();
            available.insert(server);
        }
        if (available.count() === 0) {
            continue;
        }

        const target = i % k;
        let p;

        const ceilNode = available.ceil(target, true);
        if (ceilNode) {
            p = ceilNode.getValue();
        } else {
            p = available.min().getValue();
        }

        requests[p]++;
        busy.enqueue([arrival[i] + load[i], p]);
        available.remove(p);
    }

    const maxRequest = Math.max(...requests);
    const ret = [];
    for (let i = 0; i < k; i++) {
        if (requests[i] === maxRequest) {
            ret.push(i);
        }
    }
    return ret;
};
```

```TypeScript
import { AvlTree } from '@datastructures-js/binary-search-tree';

function busiestServers(k: number, arrival: number[], load: number[]): number[] {
    const available = new AvlTree<number>();
    for (let i = 0; i < k; i++) {
        available.insert(i);
    }

    const busy = new MinPriorityQueue<[number, number]>({
        compare: (a, b) => {
            if (a[0] !== b[0]) return a[0] - b[0];
            return a[1] - b[1];
        }
    });

    const requests: number[] = new Array(k).fill(0);

    for (let i = 0; i < arrival.length; i++) {
        while (!busy.isEmpty() && busy.front()![0] <= arrival[i]) {
            const [, server] = busy.dequeue()!;
            available.insert(server);
        }
        if (available.count() === 0) {
            continue;
        }

        const target = i % k;
        let p: number;
        const ceilNode = available.ceil(target, true);
        if (ceilNode) {
            p = ceilNode.getValue();
        } else {
            p = available.min()!.getValue();
        }

        requests[p]++;
        busy.enqueue([arrival[i] + load[i], p]);
        available.remove(p);
    }

    const maxRequest = Math.max(...requests);
    const ret: number[] = [];
    for (let i = 0; i < k; i++) {
        if (requests[i] === maxRequest) {
            ret.push(i);
        }
    }
    return ret;
};
```

```Rust
use std::collections::{BinaryHeap, BTreeSet};
use std::cmp::Reverse;

impl Solution {
    pub fn busiest_servers(k: i32, arrival: Vec<i32>, load: Vec<i32>) -> Vec<i32> {
        let k = k as usize;
        let mut available = BTreeSet::new();
        for i in 0..k {
            available.insert(i);
        }

        let mut busy: BinaryHeap<Reverse<(i32, usize)>> = BinaryHeap::new();
        let mut requests = vec![0; k];

        for i in 0..arrival.len() {
            while let Some(&Reverse((finish_time, server))) = busy.peek() {
                if finish_time > arrival[i] {
                    break;
                }
                busy.pop();
                available.insert(server);
            }

            if available.is_empty() {
                continue;
            }

            let target = i % k;
            let p = if let Some(&server) = available.range(target..).next() {
                server
            } else {
                *available.iter().next().unwrap()
            };

            requests[p] += 1;
            busy.push(Reverse((arrival[i] + load[i], p)));
            available.remove(&p);
        }

        let max_request = *requests.iter().max().unwrap();
        let mut ret = Vec::new();
        for i in 0..k {
            if requests[i] == max_request {
                ret.push(i as i32);
            }
        }
        ret
    }
}
```

**复杂度分析**

- 时间复杂度：$O((k+n)\log k)$，其中 $k$ 为服务器的数目，$n$ 为请求的数目。开始时 $available$ 放入所有的服务器的时间复杂度为 $O(k\log k)$；在处理请求时，$busy$ 最多执行 $n$ 次放入和移除操作，$available$ 最多执行 $n$ 次放入、移除和查找操作，因此时间复杂度为 $O(n\log k)$；获取最繁忙服务器列表的时间复杂度为 $O(k)$。
- 空间复杂度：$O(k)$。busy 和 $available$ 最多放入 $k$ 个元素，需要 $O(k)$ 的空间；$requests$ 需要 $O(k)$ 的空间。

#### 方法二：模拟 + 双优先队列

**思路与算法**

方法一中的 $available$ 也可以用优先队列实现。

设在第 $i$ 个请求到来时，编号为 $id$ 的服务器已经处理完请求，那么将 $id$ 从 $busy$ 中移除，并放入一个不小于 $i$ 且同余于 $id$ 的编号，这样就能在保证 $available$ 中，编号小于 $i\bmod k$ 的空闲服务器能排到编号不小于 $i\bmod k$ 的空闲服务器后面。

**代码**

```Python
class Solution:
    def busiestServers(self, k: int, arrival: List[int], load: List[int]) -> List[int]:
        available = list(range(k))
        busy = []
        requests = [0] * k
        for i, (start, t) in enumerate(zip(arrival, load)):
            while busy and busy[0][0] <= start:
                _, id = heappop(busy)
                heappush(available, i + (id - i) % k)  # 利用 Python 负数取模变成同余的非负数的性质
            if available:
                id = heappop(available) % k
                requests[id] += 1
                heappush(busy, (start + t, id))
        maxRequest = max(requests)
        return [i for i, req in enumerate(requests) if req == maxRequest]
```

```C++
class Solution {
public:
    vector<int> busiestServers(int k, vector<int> &arrival, vector<int> &load) {
        priority_queue<int, vector<int>, greater<int>> available;
        for (int i = 0; i < k; i++) {
            available.push(i);
        }
        priority_queue<pair<int, int>, vector<pair<int, int>>, greater<pair<int, int>>> busy;
        vector<int> requests(k, 0);
        for (int i = 0; i < arrival.size(); i++) {
            while (!busy.empty() && busy.top().first <= arrival[i]) {
                auto[_, id] = busy.top();
                busy.pop();
                available.push(i + ((id - i) % k + k) % k); // 保证得到的是一个不小于 i 的且与 id 同余的数
            }
            if (available.empty()) {
                continue;
            }
            int id = available.top() % k;
            available.pop();
            requests[id]++;
            busy.push({arrival[i] + load[i], id});
        }
        int maxRequest = *max_element(requests.begin(), requests.end());
        vector<int> ret;
        for (int i = 0; i < k; i++) {
            if (requests[i] == maxRequest) {
                ret.push_back(i);
            }
        }
        return ret;
    }
};
```

```Java
class Solution {
    public List<Integer> busiestServers(int k, int[] arrival, int[] load) {
        PriorityQueue<Integer> available = new PriorityQueue<Integer>((a, b) -> a - b);
        for (int i = 0; i < k; i++) {
            available.offer(i);
        }
        PriorityQueue<int[]> busy = new PriorityQueue<int[]>((a, b) -> a[0] - b[0]);
        int[] requests = new int[k];
        for (int i = 0; i < arrival.length; i++) {
            while (!busy.isEmpty() && busy.peek()[0] <= arrival[i]) {
                int id = busy.peek()[1];
                busy.poll();
                available.offer(i + ((id - i) % k + k) % k); // 保证得到的是一个不小于 i 的且与 id 同余的数
            }
            if (available.isEmpty()) {
                continue;
            }
            int server = available.poll() % k;
            requests[server]++;
            busy.offer(new int[]{arrival[i] + load[i], server});
        }
        int maxRequest = Arrays.stream(requests).max().getAsInt();
        List<Integer> ret = new ArrayList<Integer>();
        for (int i = 0; i < k; i++) {
            if (requests[i] == maxRequest) {
                ret.add(i);
            }
        }
        return ret;
    }
}
```

```Go
func busiestServers(k int, arrival, load []int) (ans []int) {
    available := hi{make([]int, k)}
    for i := 0; i < k; i++ {
        available.IntSlice[i] = i
    }
    busy := hp{}
    requests := make([]int, k)
    maxRequest := 0
    for i, t := range arrival {
        for len(busy) > 0 && busy[0].end <= t {
            heap.Push(&available, i+((busy[0].id-i)%k+k)%k) // 保证得到的是一个不小于 i 的且与 id 同余的数
            heap.Pop(&busy)
        }
        if available.Len() == 0 {
            continue
        }
        id := heap.Pop(&available).(int) % k
        requests[id]++
        if requests[id] > maxRequest {
            maxRequest = requests[id]
            ans = []int{id}
        } else if requests[id] == maxRequest {
            ans = append(ans, id)
        }
        heap.Push(&busy, pair{t + load[i], id})
    }
    return
}

type hi struct{ sort.IntSlice }
func (h *hi) Push(v interface{}) { h.IntSlice = append(h.IntSlice, v.(int)) }
func (h *hi) Pop() interface{}   { a := h.IntSlice; v := a[len(a)-1]; h.IntSlice = a[:len(a)-1]; return v }

type pair struct{ end, id int }
type hp []pair
func (h hp) Len() int            { return len(h) }
func (h hp) Less(i, j int) bool  { return h[i].end < h[j].end }
func (h hp) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *hp) Push(v interface{}) { *h = append(*h, v.(pair)) }
func (h *hp) Pop() interface{}   { a := *h; v := a[len(a)-1]; *h = a[:len(a)-1]; return v }
```

```CSharp
public class Solution {
    public IList<int> BusiestServers(int k, int[] arrival, int[] load) {
        var available = new PriorityQueue<int, int>();
        for (int i = 0; i < k; i++) {
            available.Enqueue(i, i);
        }

        var busy = new PriorityQueue<(int finish, int server), int>();
        int[] requests = new int[k];

        for (int i = 0; i < arrival.Length; i++) {
            while (busy.Count > 0 && busy.Peek().finish <= arrival[i]) {
                var (_, id) = busy.Dequeue();
                int pos = i + ((id - i) % k + k) % k;
                available.Enqueue(pos, pos);
            }

            if (available.Count == 0) {
                continue;
            }

            int serverId = available.Dequeue() % k;
            requests[serverId]++;
            busy.Enqueue((arrival[i] + load[i], serverId), arrival[i] + load[i]);
        }

        int maxRequest = requests.Max();
        return Enumerable.Range(0, k)
            .Where(i => requests[i] == maxRequest)
            .ToList();
    }
}
```

```C
#define MIN_QUEUE_SIZE 64

typedef struct Element {
    int data[2];
} Element;

typedef bool (*compare)(const void *, const void *);

typedef struct PriorityQueue {
    Element *arr;
    int capacity;
    int queueSize;
    compare lessFunc;
} PriorityQueue;

static void memswap(void *m1, void *m2, size_t size) {
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

void enQueue(PriorityQueue *obj, Element *e) {
    if (obj->queueSize == obj->capacity) {
        obj->capacity *= 2;
        obj->arr = (Element *)realloc(obj->arr, sizeof(Element) * obj->capacity);
    }
    memcpy(&obj->arr[obj->queueSize], e, sizeof(Element));
    for (int i = obj->queueSize; i > 0 && obj->lessFunc(&obj->arr[(i - 1) / 2], &obj->arr[i]); i = (i - 1) / 2) {
        swap(obj->arr, i, (i - 1) / 2);
    }
    obj->queueSize++;
}

bool deQueue(PriorityQueue *obj, Element *out) {
    if (obj->queueSize == 0) {
        return false;
    }
    memcpy(out, &obj->arr[0], sizeof(Element));
    swap(obj->arr, 0, obj->queueSize - 1);
    down(obj->arr, obj->queueSize - 1, 0, obj->lessFunc);
    obj->queueSize--;
    return true;
}

bool isEmpty(const PriorityQueue *obj) {
    return obj->queueSize == 0;
}

bool front(const PriorityQueue *obj, Element *out) {
    if (obj->queueSize == 0) {
        return false;
    }
    memcpy(out, &obj->arr[0], sizeof(Element));
    return true;
}

void freeQueue(PriorityQueue *obj) {
    free(obj->arr);
    free(obj);
}

static bool idleLess(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data[0] > e2->data[0];
}

static bool busyLess(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    if (e1->data[0] != e2->data[0]) {
        return e1->data[0] > e2->data[0];
    }
    return e1->data[1] > e2->data[1];
}

int* busiestServers(int k, int* arrival, int arrivalSize, int* load, int loadSize, int* returnSize) {
    PriorityQueue *available = createPriorityQueue(idleLess);
    for (int i = 0; i < k; i++) {
        Element e;
        e.data[0] = i;
        e.data[1] = i;
        enQueue(available, &e);
    }

    PriorityQueue *busy = createPriorityQueue(busyLess);
    int *requests = (int *)calloc(k, sizeof(int));

    for (int i = 0; i < arrivalSize; i++) {
        Element frontElem;
        while (!isEmpty(busy)) {
            front(busy, &frontElem);
            if (frontElem.data[0] > arrival[i]) break;
            deQueue(busy, &frontElem);
            int id = frontElem.data[1];
            // 保证得到的是一个不小于 i 的且与 id 同余的数
            int pos = i + ((id - i) % k + k) % k;
            Element e;
            e.data[0] = pos;
            e.data[1] = pos;
            enQueue(available, &e);
        }

        if (isEmpty(available)) {
            continue;
        }

        Element e;
        deQueue(available, &e);
        int serverId = e.data[0] % k;
        requests[serverId]++;
        Element busyElem;
        busyElem.data[0] = arrival[i] + load[i];
        busyElem.data[1] = serverId;
        enQueue(busy, &busyElem);
    }

    int maxRequest = 0;
    for (int i = 0; i < k; i++) {
        if (requests[i] > maxRequest) maxRequest = requests[i];
    }

    int *ret = (int *)malloc(sizeof(int) * k);
    *returnSize = 0;
    for (int i = 0; i < k; i++) {
        if (requests[i] == maxRequest) {
            ret[(*returnSize)++] = i;
        }
    }

    freeQueue(available);
    freeQueue(busy);
    free(requests);
    return ret;
}
```

```JavaScript
var busiestServers = function(k, arrival, load) {
    const available = new MinPriorityQueue();
    for (let i = 0; i < k; i++) {
        available.enqueue(i);
    }

    const busy = new MinPriorityQueue({
        compare: (a, b) => {
            if (a[0] !== b[0]) return a[0] - b[0];
            return a[1] - b[1];
        }
    });

    const requests = new Array(k).fill(0);

    for (let i = 0; i < arrival.length; i++) {
        while (!busy.isEmpty() && busy.front()[0] <= arrival[i]) {
            const [, id] = busy.dequeue();
            const pos = i + ((id - i) % k + k) % k;
            available.enqueue(pos);
        }

        if (available.isEmpty()) {
            continue;
        }

        const pos = available.dequeue();
        const serverId = pos % k;
        requests[serverId]++;
        busy.enqueue([arrival[i] + load[i], serverId]);
    }

    const maxRequest = Math.max(...requests);
    const result = [];
    for (let i = 0; i < k; i++) {
        if (requests[i] === maxRequest) {
            result.push(i);
        }
    }
    return result;
};
```

```TypeScript
function busiestServers(k: number, arrival: number[], load: number[]): number[] {
    const available = new MinPriorityQueue<number>();
    for (let i = 0; i < k; i++) {
        available.enqueue(i);
    }

    const busy = new MinPriorityQueue<[number, number]>({
        compare: (a, b) => {
            if (a[0] !== b[0]) return a[0] - b[0];
            return a[1] - b[1];
        }
    });

    const requests: number[] = new Array(k).fill(0);

    for (let i = 0; i < arrival.length; i++) {
        while (!busy.isEmpty() && busy.front()![0] <= arrival[i]) {
            const [, id] = busy.dequeue()!;
            // 保证得到的是一个不小于 i 的且与 id 同余的数
            const pos = i + ((id - i) % k + k) % k;
            available.enqueue(pos);
        }

        if (available.isEmpty()) {
            continue;
        }

        const pos = available.dequeue()!;
        const serverId = pos % k;
        requests[serverId]++;
        busy.enqueue([arrival[i] + load[i], serverId]);
    }

    const maxRequest = Math.max(...requests);
    const result: number[] = [];
    for (let i = 0; i < k; i++) {
        if (requests[i] === maxRequest) {
            result.push(i);
        }
    }
    return result;
};
```

```Rust
use std::collections::BinaryHeap;
use std::cmp::Reverse;

impl Solution {
    pub fn busiest_servers(k: i32, arrival: Vec<i32>, load: Vec<i32>) -> Vec<i32> {
        let k = k as usize;
        let mut available: BinaryHeap<Reverse<usize>> = BinaryHeap::new();
        for i in 0..k {
            available.push(Reverse(i));
        }

        let mut busy: BinaryHeap<Reverse<(i32, usize)>> = BinaryHeap::new();
        let mut requests = vec![0; k];

        for (i, (&start, &t)) in arrival.iter().zip(load.iter()).enumerate() {
            while let Some(&Reverse((finish, id))) = busy.peek() {
                if finish > start {
                    break;
                }
                busy.pop();
                // 保证得到的是一个不小于 i 的且与 id 同余的数
                let i32_i = i as i32;
                let i32_id = id as i32;
                let i32_k = k as i32;
                let pos = (i32_i + ((i32_id - i32_i) % i32_k + i32_k) % i32_k) as usize;
                available.push(Reverse(pos));
            }

            if available.is_empty() {
                continue;
            }

            let Reverse(pos) = available.pop().unwrap();
            let server_id = pos % k;
            requests[server_id] += 1;
            busy.push(Reverse((start + t, server_id)));
        }

        let max_request = *requests.iter().max().unwrap();
        requests.iter()
            .enumerate()
            .filter(|&(_, &req)| req == max_request)
            .map(|(i, _)| i as i32)
            .collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O((k+n)\log k)$ 或 $O(k+n\log k)$，其中 $k$ 为服务器的数目，$n$ 为请求的数目。开始时 $available$ 放入所有的服务器的时间复杂度为 $O(k\log k)$ 或 $O(k)$，取决于语言实现；在处理请求时，$busy$ 最多执行 $n$ 次放入和移除操作，$available$ 最多执行 $n$ 次放入和移除操作，因此时间复杂度为 $O(n\log k)$；获取最繁忙服务器列表的时间复杂度为 $O(k)$。
- 空间复杂度：$O(k)$。busy 和 $available$ 最多放入 $k$ 个元素，需要 $O(k)$ 的空间；$requests$ 需要 $O(k)$ 的空间。
