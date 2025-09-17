### [设计数字容器系统](https://leetcode.cn/problems/design-a-number-container-system/solutions/3768923/she-ji-shu-zi-rong-qi-xi-tong-by-leetcod-zsgc/)

#### 方法一：优先队列 $+$ 惰性删除

使用哈希表 $nums$ 记录每个下标对应的数字，同时使用哈希表 $+$ 优先队列（最小值）记录每个数字对应的下标集合。

- $change$ 函数：
  记录 $nums[index]=number$，同时将 $index$ 压入 $number$ 对应的优先队列中。
- $find$ 函数：
  $change$ 函数在替换给定下标处的数字时，没有先删除对应优先队列中的下标。因此我们在获取 $number$ 的下标最小值时，需要先校验优先队列堆顶下标对应的数字是否等于 $number$，不等于时直接丢弃，等于则返回该下标。如果优先队列为空，则返回 $-1$。

```C++
class NumberContainers {
private:
    unordered_map<int, int> nums;
    unordered_map<int, priority_queue<int, vector<int>, greater<>>> heaps;

public:
    NumberContainers() {

    }

    void change(int index, int number) {
        nums[index] = number;
        heaps[number].push(index);
    }

    int find(int number) {
        while (!heaps[number].empty() && nums[heaps[number].top()] != number) {
            heaps[number].pop();
        }
        if (heaps[number].empty()) {
            return -1;
        }
        return heaps[number].top();
    }
};
```

```Go
type NumberContainers struct {
    nums  map[int]int
    heaps map[int]*MinHeap
}

func Constructor() NumberContainers {
    return NumberContainers{
        nums:  make(map[int]int),
        heaps: make(map[int]*MinHeap),
    }
}

func (nc *NumberContainers) Change(index int, number int) {
    nc.nums[index] = number
    if _, exists := nc.heaps[number]; !exists {
        nc.heaps[number] = &MinHeap{}
        heap.Init(nc.heaps[number])
    }
    heap.Push(nc.heaps[number], index)
}

func (nc *NumberContainers) Find(number int) int {
    h, ok := nc.heaps[number]
    if !ok {
        return -1
    }
    for h.Len() > 0 && nc.nums[(*h)[0]] != number {
        heap.Pop(h)
    }
    if h.Len() == 0 {
        return -1
    }
    return (*h)[0]
}

type MinHeap []int

func (h MinHeap) Len() int { return len(h) }
func (h MinHeap) Less(i, j int) bool { return h[i] < h[j] }
func (h MinHeap) Swap(i, j int) { h[i], h[j] = h[j], h[i] }

func (h *MinHeap) Push(x any) {
    *h = append(*h, x.(int))
}

func (h *MinHeap) Pop() any {
    old := *h
    n := len(old)
    x := old[n-1]
    *h = old[0 : n-1]
    return x
}
```

```Python
import heapq

class NumberContainers:
    def __init__(self):
        self.nums = {}
        self.heaps = {}

    def change(self, index: int, number: int) -> None:
        self.nums[index] = number
        if number not in self.heaps:
            self.heaps[number] = []
        heapq.heappush(self.heaps[number], index)

    def find(self, number: int) -> int:
        if number not in self.heaps:
            return -1
        heap = self.heaps[number]
        while heap and self.nums[heap[0]] != number:
            heapq.heappop(heap)
        return heap[0] if heap else -1
```

```Java
class NumberContainers {
    private Map<Integer, Integer> nums = new HashMap<>();
    private Map<Integer, PriorityQueue<Integer>> heaps = new HashMap<>();

    public void change(int index, int number) {
        nums.put(index, number);
        heaps.computeIfAbsent(number, k -> new PriorityQueue<>()).add(index);
    }

    public int find(int number) {
        PriorityQueue<Integer> heap = heaps.get(number);
        if (heap == null) {
            return -1;
        }
        while (!heap.isEmpty() && !nums.get(heap.peek()).equals(number)) {
            heap.poll();
        }
        return heap.isEmpty() ? -1 : heap.peek();
    }
}
```

```CSharp
public class NumberContainers {
    private Dictionary<int, int> nums = new();
    private Dictionary<int, PriorityQueue<int, int>> heaps = new();

    public void Change(int index, int number) {
        nums[index] = number;
        if (!heaps.ContainsKey(number)) {
            heaps[number] = new PriorityQueue<int, int>();
        }
        heaps[number].Enqueue(index, index);
    }

    public int Find(int number) {
        if (!heaps.ContainsKey(number)) {
            return -1;
        }
        var heap = heaps[number];
        while (heap.Count > 0 && nums[heap.Peek()] != number) {
            heap.Dequeue();
        }
        return heap.Count == 0 ? -1 : heap.Peek();
    }
}
```

```Rust
use std::collections::{BinaryHeap, HashMap};
use std::cmp::Reverse;

pub struct NumberContainers {
    nums: HashMap<i32, i32>,
    heaps: HashMap<i32, BinaryHeap<Reverse<i32>>>,
}

impl NumberContainers {
    pub fn new() -> Self {
        Self {
            nums: HashMap::new(),
            heaps: HashMap::new(),
        }
    }

    pub fn change(&mut self, index: i32, number: i32) {
        self.nums.insert(index, number);
        self.heaps.entry(number).or_insert(BinaryHeap::new()).push(Reverse(index));
    }

    pub fn find(&mut self, number: i32) -> i32 {
        if let Some(heap) = self.heaps.get_mut(&number) {
            while let Some(&Reverse(top)) = heap.peek() {
                if self.nums.get(&top) != Some(&number) {
                    heap.pop();
                } else {
                    return top;
                }
            }
        }
        -1
    }
}
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

Element *createElement(int x) {
    Element *obj = (Element *)malloc(sizeof(Element));
    obj->data = x;
    return obj;
}

static bool less(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data > e2->data;
}

static bool greater(const void *a, const void *b) {
    Element *e1 = (Element *)a;
    Element *e2 = (Element *)b;
    return e1->data < e2->data;
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

typedef struct {
    int key;
    PriorityQueue *val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}


bool hashAddItem(HashItem **obj, int key, PriorityQueue *val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

PriorityQueue* hashGetItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        freeQueue(curr->val);
        free(curr);
    }
}

typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashMapItem; 

HashMapItem *hashFindMapItem(HashMapItem **obj, int key) {
    HashMapItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddMapItem(HashMapItem **obj, int key, int val) {
    if (hashFindMapItem(obj, key)) {
        return false;
    }
    HashMapItem *pEntry = (HashMapItem *)malloc(sizeof(HashMapItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetMapItem(HashMapItem **obj, int key, int val) {
    HashMapItem *pEntry = hashFindMapItem(obj, key);
    if (!pEntry) {
        hashAddMapItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetMapItem(HashMapItem **obj, int key, int defaultVal) {
    HashMapItem *pEntry = hashFindMapItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashMapFree(HashMapItem **obj) {
    HashMapItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

typedef struct {
    HashMapItem *nums;
    HashItem *heaps;
} NumberContainers;

NumberContainers* numberContainersCreate() {
    NumberContainers *obj = (NumberContainers *)malloc(sizeof(NumberContainers));
    obj->nums = NULL;
    obj->heaps = NULL;
    return obj;
}

void numberContainersChange(NumberContainers* obj, int index, int number) {
    hashSetMapItem(&obj->nums, index, number);
    if (!hashFindItem(&obj->heaps, number)) {
        hashAddItem(&obj->heaps, number, createPriorityQueue(less));
    }
    PriorityQueue *pq = hashGetItem(&obj->heaps, number);
    struct Element e = {index};
    enQueue(pq, &e);
}

int numberContainersFind(NumberContainers* obj, int number) {
    PriorityQueue *pq = hashGetItem(&obj->heaps, number);
    if (pq == NULL) {
        return -1;
    }
    while (!isEmpty(pq) && hashGetMapItem(&obj->nums, front(pq)->data, -1) != number) {
        deQueue(pq);
    }
    if (isEmpty(pq)) {
        return -1;
    }
    return front(pq)->data;
}

void numberContainersFree(NumberContainers* obj) {
    hashFree(&obj->heaps);
    hashMapFree(&obj->nums);
    free(obj);
}
```

```JavaScript
var NumberContainers = function() {
    this.nums = new Map(); 
    this.heaps = new Map();
};

NumberContainers.prototype.change = function(index, number) {
    const oldNumber = this.nums.get(index);
    this.nums.set(index, number);
    if (!this.heaps.has(number)) {
        this.heaps.set(number, new MinPriorityQueue());
    }
    this.heaps.get(number).enqueue(index);
};

NumberContainers.prototype.find = function(number) {
    if (!this.heaps.has(number)) {
        return -1;
    }
    const heap = this.heaps.get(number);
    while (!heap.isEmpty() && this.nums.get(heap.front()) !== number) {
        heap.dequeue();
    }
    return heap.isEmpty() ? -1 : heap.front();
};
```

```TypeScript
class NumberContainers {
    private nums: Map<number, number>;
    private heaps: Map<number, MinPriorityQueue<number>>;

    constructor() {
        this.nums = new Map<number, number>();
        this.heaps = new Map<number, MinPriorityQueue<number>>();
    }

    change(index: number, number: number): void {
        const oldNumber = this.nums.get(index);
        this.nums.set(index, number);
        if (!this.heaps.has(number)) {
            this.heaps.set(number, new MinPriorityQueue<number>());
        }
        this.heaps.get(number)!.enqueue(index);
    }

    find(number: number): number {
        if (!this.heaps.has(number)) {
            return -1;
        }
        
        const heap = this.heaps.get(number)!;
        while (!heap.isEmpty() && this.nums.get(heap.front()!) !== number) {
            heap.dequeue();
        }
        return heap.isEmpty() ? -1 : heap.front()!;
    }
}
```

**复杂度分析**

- 时间复杂度：
  - $change$ 函数：$O(\log n)$，其中 $n$ 是总调用次数。
  - $find$ 函数：均摊 $O(\log n)$。
- 空间复杂度：$O(n)$。

#### 方法二：有序集合

类似于方法一，使用哈希表 $nums$ 记录每个下标对应的数字，同时使用哈希表 $+$ 有序集合记录每个数字对应的下标集合。

- $change$ 函数：
  如果下标 $index$ 处已经有数字，那么从该数字的下标有序集合中删除下标 $index$。记录 $nums[index]=number$，同时将 $index$ 插入 $number$ 对应的下标有序集合中。
- $find$ 函数：
  如果 $number$ 对应的下标有序集合非空，则返回该有序集合的最小值，否则返回 $-1$。

```C++
class NumberContainers {
private:
    unordered_map<int, int> nums;
    unordered_map<int, set<int>> us;
public:
    NumberContainers() {
        
    }
    
    void change(int index, int number) {
        if (nums[index] != 0) {
            us[nums[index]].erase(index);
        }
        us[number].insert(index);
        nums[index] = number;
    }
    
    int find(int number) {
        if (us[number].empty()) {
            return -1;
        }
        return *us[number].begin();
    }
};
```

```Go
type NumberContainers struct {
    nums  map[int]int
    heaps map[int]*treeset.Set
}

func Constructor() NumberContainers {
    return NumberContainers{
        nums:  make(map[int]int),
        heaps: make(map[int]*treeset.Set),
    }
}

func (nc *NumberContainers) Change(index int, number int) {
    if prev, exists := nc.nums[index]; exists && prev != number {
        if set, ok := nc.heaps[prev]; ok {
            set.Remove(index)
        }
    }
    nc.nums[index] = number
    if _, ok := nc.heaps[number]; !ok {
        nc.heaps[number] = treeset.NewWithIntComparator()
    }
    nc.heaps[number].Add(index)
}

func (nc *NumberContainers) Find(number int) int {
    if set, ok := nc.heaps[number]; ok {
        it := set.Iterator()
        if it.First() {
            return it.Value().(int)
        }
    }
    return -1
}
```

```Python
class NumberContainers:
    def __init__(self):
        self.nums = {}
        self.heaps = {}

    def change(self, index: int, number: int) -> None:
        if index in self.nums:
            old_num = self.nums[index]
            if old_num != number:
                self.heaps[old_num].discard(index)

        self.nums[index] = number
        if number not in self.heaps:
            self.heaps[number] = SortedSet()
        self.heaps[number].add(index)

    def find(self, number: int) -> int:
        if number in self.heaps and self.heaps[number]:
            return self.heaps[number][0]
        return -1
```

```Java
public class NumberContainers {
    private Map<Integer, Integer> nums;
    private Map<Integer, TreeSet<Integer>> us;

    public NumberContainers() {
        nums = new HashMap<>();
        us = new HashMap<>();
    }

    public void change(int index, int number) {
        int prev = nums.getOrDefault(index, 0);
        if (prev != 0) {
            TreeSet<Integer> set = us.get(prev);
            if (set != null) {
                set.remove(index);
            }
        }
        us.computeIfAbsent(number, k -> new TreeSet<>()).add(index);
        nums.put(index, number);
    }

    public int find(int number) {
        TreeSet<Integer> set = us.get(number);
        if (set == null || set.isEmpty()) {
            return -1;
        }
        return set.first();
    }
}
```

```CSharp
public class NumberContainers {
    private Dictionary<int,int> nums;
    private Dictionary<int, SortedSet<int>> us;

    public NumberContainers() {
        nums = new Dictionary<int,int>();
        us = new Dictionary<int, SortedSet<int>>();
    }

    public void Change(int index, int number) {
        int prev = nums.ContainsKey(index) ? nums[index] : 0;
        if (prev != 0) {
            if (us.TryGetValue(prev, out var set)) {
                set.Remove(index);
            }
        }
        if (!us.ContainsKey(number)) {
            us[number] = new SortedSet<int>();
        }
        us[number].Add(index);
        nums[index] = number;
    }

    public int Find(int number) {
        if (!us.TryGetValue(number, out var set) || set.Count == 0) {
            return -1;
        }
        return set.Min;
    }
}
```

```Rust
use std::collections::{HashMap, BTreeSet};

pub struct NumberContainers {
    nums: HashMap<i32, i32>,
    us: HashMap<i32, BTreeSet<i32>>,
}

impl NumberContainers {
    pub fn new() -> Self {
        Self {
            nums: HashMap::new(),
            us: HashMap::new(),
        }
    }

    pub fn change(&mut self, index: i32, number: i32) {
        if let Some(&prev) = self.nums.get(&index) {
            if prev != 0 {
                if let Some(set) = self.us.get_mut(&prev) {
                    set.remove(&index);
                }
            }
        }
        self.us.entry(number).or_insert_with(BTreeSet::new).insert(index);
        self.nums.insert(index, number);
    }

    pub fn find(&self, number: i32) -> i32 {
        self.us.get(&number).and_then(|s| s.iter().next().copied()).unwrap_or(-1)
    }
}
```

**复杂度分析**

- 时间复杂度：
  - $change$ 函数：$O(\log n)$，其中 $n$ 是 $change$ 和 $find$ 的总调用次数。
  - $find$ 函数：$O(\log n)$。
- 空间复杂度：$O(n)$。
