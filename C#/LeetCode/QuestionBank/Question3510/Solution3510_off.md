### [移除最小数对使数组有序 II](https://leetcode.cn/problems/minimum-pair-removal-to-sort-array-ii/solutions/3880129/yi-chu-zui-xiao-shu-dui-shi-shu-zu-you-x-klaf/)

#### 方法一：优先队列 + 惰性删除

**思路与算法**

本题是[「3507. 移除最小数对使数组有序 I」](https://leetcode.cn/problems/minimum-pair-removal-to-sort-array-i/)的数据增强版。朴素模拟在这个数据规模下会超时，故我们需要对原模拟过程中的三个关键逻辑进行优化：寻找最小相邻数对和、判断当前数组单调性以及合并最小相邻数对。

**维护最小相邻数对和**

首先考虑如何寻找最小相邻数对和，易想到使用优先队列来维护。将数对的引用存入优先队列，假设当前弹出的相邻数对为 $(i,j)$，那么完成合并操作后，原来位于 $i-1$ 和 $j+1$ 两个位置的元素会与合并后的新元素形成两个新的相邻数对，因此需要把新的数对加入优先队列。同时，原来 $(i-1,i)$ 和 $(j,j+1)$ 构成的两个数对（若存在）就变成了优先队列中的脏数据。此时一般使用惰性删除的技巧，即**在弹出操作中判断弹出的是否是脏数据**，而不是立刻在优先队列中删除对应元素，这也是此类题目的常见处理方法。

本题判断优先队列中的元素是否是脏数据有多种实现，这里提供一种思路，假设总是将数对向左合并，可以考虑维护两个信息：

- 用一个 $merged$ 数组判断某个位置的元素是否已经被合并，只有两个元素都没被合并时，它们的引用才是有效的。
- 在存入数对时，同时存入**当前的数对和**。待弹出该数对时，即便两个元素都有效，如果数对和发生了变化，显然该数对也是脏数据。

该实现存在数对中的两个元素都有效且数对和不变，但仍是脏数据的极端情况。可以证明，此情况并不影响结果的正确性，因为在该情境下，即便该数对为脏数据，它依然是本轮合并的目标。

**维护数组单调性**

接下来是判断数组单调性，不难发现：相邻元素的单调性可以决定整个数组的单调性。故考虑维护一个变量 $decreaseCount$，表示当前 $nums$ 中有多少个相邻的数对是递减的。显然，当 $decreaseCount$ 为 $0$ 时 $nums$ 即为非严格单调递增状态。

我们可以在合并数对 $(i,j)$ 的过程维护 $decreaseCount$ 的变化。分为三种情况考虑：

- 对于数对 $(i,j)$，若原来就满足 $nums[i]>nums[j]$，则 $decreaseCount$ 应该减一。
- 若 $i$ 不是首项元素，则考虑 $nums[i-1]$ 与 $nums[i]$ 在合并前后的单调性变化。如果从单调递减变成了非严格单调递增，则将 $decreaseCount$ 减一，反之加一。
- 类似地，若 $j$ 不是末项元素，则对 $nums[j]$ 与 $nums[j+1]$ 应用上述相同的逻辑进行更新。

此时 $decreaseCount$ 是否为 $0$ 就是外层循环的终止条件。

**合并元素**

经上述处理后，我们已经不需要直接遍历 $nums$，仅需要获取当前数对的前驱和后继，且合并元素必然会涉及到线性表的删除，显然此时使用双向链表维护 $nums$ 最为合适。

优化上述三个逻辑后，再按照题意去模拟寻找最小数对并合并的流程，即可通过本题。

**代码**

```C++
typedef long long ll;

const int MAX_N = 100005;

struct Node {
    ll value;
    int left;
};

using ListIt = std::list<Node>::iterator;

struct Pair {
    ListIt first;
    ListIt second;
    ll cost;
    size_t firstLeft;
    size_t secondLeft;

    Pair() {}
    Pair(ListIt fi, ListIt se, ll cost)
        : first(fi), second(se), firstLeft(fi->left), secondLeft(se->left),
          cost(cost) {}
};

struct ComparePair {
    bool operator()(const Pair& a, const Pair& b) {
        if (a.cost != b.cost) {
            return a.cost > b.cost;
        }
        return a.firstLeft > b.firstLeft;
    }
};

class Solution {
public:
    int minimumPairRemoval(std::vector<int>& nums) {
        std::list<Node> list;
        std::bitset<MAX_N> merged;
        std::priority_queue<Pair, std::vector<Pair>, ComparePair> pq;

        int decreaseCount = 0;
        int count = 0;

        list.push_back({nums[0], 0});

        for (size_t i = 1; i < nums.size(); ++i) {
            list.push_back({nums[i], (int)i});

            auto curr = std::prev(list.end());
            auto prev = std::prev(curr);

            pq.push({prev, curr, prev->value + curr->value});

            if (nums[i - 1] > nums[i]) {
                decreaseCount++;
            }
        }

        while (decreaseCount > 0 && !pq.empty()) {
            auto top = pq.top();
            pq.pop();

            if (merged[top.firstLeft] || merged[top.secondLeft]) {
                continue;
            }

            auto first = top.first;
            auto second = top.second;
            auto cost = top.cost;

            if (first->value + second->value != cost) {
                continue;
            }

            count++;

            if (first->value > second->value) {
                decreaseCount--;
            }

            ListIt prev =
                (first == list.begin()) ? list.end() : std::prev(first);
            ListIt next = std::next(second);

            if (prev != list.end()) {
                if (prev->value > first->value && prev->value <= cost) {
                    decreaseCount--;
                }
                if (prev->value <= first->value && prev->value > cost) {
                    decreaseCount++;
                }
                pq.push({prev, first, prev->value + cost});
            }

            if (next != list.end()) {
                if (second->value > next->value && cost <= next->value) {
                    decreaseCount--;
                }
                if (second->value <= next->value && cost > next->value) {
                    decreaseCount++;
                }
                pq.push({first, next, cost + next->value});
            }

            first->value = cost;
            merged[second->left] = 1;
            list.erase(second);
        }

        return count;
    }
};
```

```Java
class Node {
    long value;
    int left;
    Node prev;
    Node next;

    Node(int value, int left) {
        this.value = value;
        this.left = left;
    }
}

class PQItem implements Comparable<PQItem> {
    Node first;
    Node second;
    long cost;

    PQItem(Node first, Node second, long cost) {
        this.first = first;
        this.second = second;
        this.cost = cost;
    }

    @Override
    public int compareTo(PQItem other) {
        if (this.cost == other.cost) {
            return this.first.left - other.first.left;
        }
        return this.cost < other.cost ? -1 : 1;
    }
}

public class Solution {
    public int minimumPairRemoval(int[] nums) {
        PriorityQueue<PQItem> pq = new PriorityQueue<>();
        boolean[] merged = new boolean[nums.length];

        int decreaseCount = 0;
        int count = 0;
        Node head = new Node(nums[0], 0);
        Node current = head;

        for (int i = 1; i < nums.length; i++) {
            Node newNode = new Node(nums[i], i);
            current.next = newNode;
            newNode.prev = current;
            pq.offer(new PQItem(current, newNode, current.value + newNode.value));
            if (nums[i - 1] > nums[i]) {
                decreaseCount++;
            }
            current = newNode;
        }

        while (decreaseCount > 0) {
            PQItem item = pq.poll();
            Node first = item.first;
            Node second = item.second;
            long cost = item.cost;

            if (merged[first.left] || merged[second.left] || first.value + second.value != cost) {
                continue;
            }
            count++;
            if (first.value > second.value) {
                decreaseCount--;
            }

            Node prevNode = first.prev;
            Node nextNode = second.next;
            first.next = nextNode;
            if (nextNode != null) {
                nextNode.prev = first;
            }

            if (prevNode != null) {
                if (prevNode.value > first.value && prevNode.value <= cost) {
                    decreaseCount--;
                } else if (prevNode.value <= first.value && prevNode.value > cost) {
                    decreaseCount++;
                }

                pq.offer(new PQItem(prevNode, first, prevNode.value + cost));
            }

            if (nextNode != null) {
                if (second.value > nextNode.value && cost <= nextNode.value) {
                    decreaseCount--;
                } else if (second.value <= nextNode.value && cost > nextNode.value) {
                    decreaseCount++;
                }

                pq.offer(new PQItem(first, nextNode, cost + nextNode.value));
            }

            first.value = cost;
            merged[second.left] = true;
        }

        return count;
    }
}
```

```CSharp
public class Node {
    public long value;
    public int left;
    public Node prev;
    public Node next;

    public Node(long value, int left) {
        this.value = value;
        this.left = left;
    }
}

public class Item : IComparable<Item> {
    public Node first;
    public Node second;
    public long cost;

    public Item(Node first, Node second, long cost) {
        this.first = first;
        this.second = second;
        this.cost = cost;
    }

    public int CompareTo(Item other) {
        if (cost == other.cost) {
            return first.left.CompareTo(other.first.left);
        }
        return cost.CompareTo(other.cost);
    }
}

public class Solution {
    public int MinimumPairRemoval(int[] nums) {
        var pq = new PriorityQueue<Item, Item>();
        bool[] merged = new bool[nums.Length];
        int decreaseCount = 0;
        int count = 0;
        List<Node> nodes = new List<Node>();
        nodes.Add(new Node(nums[0], 0));

        for (int i = 1; i < nums.Length; i++) {
            nodes.Add(new Node(nums[i], i));
            nodes[i - 1].next = nodes[i];
            nodes[i].prev = nodes[i - 1];
            var item = new Item(nodes[i - 1], nodes[i], nodes[i - 1].value + nodes[i].value);
            pq.Enqueue(item, item);

            if (nums[i - 1] > nums[i]) {
                decreaseCount++;
            }
        }

        while (decreaseCount > 0) {
            var item = pq.Dequeue();
            Node first = item.first;
            Node second = item.second;
            long cost = item.cost;

            if (merged[first.left] || merged[second.left] ||
                first.value + second.value != cost) {
                continue;
            }
            count++;
            if (first.value > second.value) {
                decreaseCount--;
            }

            Node prevNode = first.prev;
            Node nextNode = second.next;
            first.next = nextNode;
            if (nextNode != null) {
                nextNode.prev = first;
            }

            if (prevNode != null) {
                if (prevNode.value > first.value && prevNode.value <= cost) {
                    decreaseCount--;
                } else if (prevNode.value <= first.value && prevNode.value > cost) {
                    decreaseCount++;
                }
                var newItem = new Item(prevNode, first, prevNode.value + cost);
                pq.Enqueue(newItem, newItem);
            }

            if (nextNode != null) {
                if (second.value > nextNode.value && cost <= nextNode.value) {
                    decreaseCount--;
                } else if (second.value <= nextNode.value && cost > nextNode.value) {
                    decreaseCount++;
                }
                var newItem = new Item(first, nextNode, cost + nextNode.value);
                pq.Enqueue(newItem, newItem);
            }

            first.value = cost;
            merged[second.left] = true;
        }

        return count;
    }
}
```

```Python
class Node:
    def __init__(self, value, left):
        self.value = value
        self.left = left
        self.prev = None
        self.next = None

class Solution:
    def minimumPairRemoval(self, nums: List[int]) -> int:
        class PQItem:
            def __init__(self, first, second, cost):
                self.first = first
                self.second = second
                self.cost = cost

            def __lt__(self, other):
                if self.cost == other.cost:
                    return self.first.left < other.first.left
                return self.cost < other.cost

        pq = []
        head = Node(nums[0], 0)
        current = head
        merged = [False] * len(nums)
        decrease_count = 0
        count = 0

        for i in range(1, len(nums)):
            new_node = Node(nums[i], i)
            current.next = new_node
            new_node.prev = current
            heapq.heappush(pq, PQItem(current, new_node, current.value + new_node.value))

            if nums[i - 1] > nums[i]:
                decrease_count += 1

            current = new_node

        while decrease_count > 0:
            item = heapq.heappop(pq)
            first, second, cost = item.first, item.second, item.cost

            if merged[first.left] or merged[second.left] or first.value + second.value != cost:
                continue
            count += 1

            if first.value > second.value:
                decrease_count -= 1

            prev_node = first.prev
            next_node = second.next
            first.next = next_node
            if next_node:
                next_node.prev = first

            if prev_node:
                if prev_node.value > first.value and prev_node.value <= cost:
                    decrease_count -= 1
                elif prev_node.value <= first.value and prev_node.value > cost:
                    decrease_count += 1

                heapq.heappush(pq, PQItem(prev_node, first, prev_node.value + cost))

            if next_node:
                if second.value > next_node.value and cost <= next_node.value:
                    decrease_count -= 1
                elif second.value <= next_node.value and cost > next_node.value:
                    decrease_count += 1
                heapq.heappush(pq, PQItem(first, next_node, cost + next_node.value))

            first.value = cost
            merged[second.left] = True

        return count
```

```Go
func minimumPairRemoval(nums []int) int {
    pq := &PriorityQueue{}
    heap.Init(pq)
    merged := make([]bool, len(nums))
    decreaseCount := 0
    count := 0
    head := &Node{value: int64(nums[0]), left: 0}
    current := head

    for i := 1; i < len(nums); i++ {
        newNode := &Node{value: int64(nums[i]), left: i}
        current.next = newNode
        newNode.prev = current

        heap.Push(pq, &Item{
            first:  current,
            second: newNode,
            cost:   current.value + newNode.value,
        })
        if nums[i-1] > nums[i] {
            decreaseCount++
        }

        current = newNode
    }

    for decreaseCount > 0 {
        item := heap.Pop(pq).(*Item)
        first := item.first
        second := item.second
        cost := item.cost

        if merged[first.left] || merged[second.left] || first.value+second.value != cost {
            continue
        }
        count++
        if first.value > second.value {
            decreaseCount--
        }

        prevNode := first.prev
        nextNode := second.next
        first.next = nextNode
        if nextNode != nil {
            nextNode.prev = first
        }

        if prevNode != nil {
            if prevNode.value > first.value && prevNode.value <= cost {
                decreaseCount--
            } else if prevNode.value <= first.value && prevNode.value > cost {
                decreaseCount++
            }
            heap.Push(pq, &Item{
                first:  prevNode,
                second: first,
                cost:   prevNode.value + cost,
            })
        }

        if nextNode != nil {
            if second.value > nextNode.value && cost <= nextNode.value {
                decreaseCount--
            } else if second.value <= nextNode.value && cost > nextNode.value {
                decreaseCount++
            }
            heap.Push(pq, &Item{
                first:  first,
                second: nextNode,
                cost:   cost + nextNode.value,
            })
        }

        first.value = cost
        merged[second.left] = true
    }

    return count
}

type Node struct {
    value int64
    left  int
    prev  *Node
    next  *Node
}

type Item struct {
    first  *Node
    second *Node
    cost   int64
    index  int
}

type PriorityQueue []*Item

func (pq PriorityQueue) Len() int { return len(pq) }
func (pq PriorityQueue) Less(i, j int) bool {
    if pq[i].cost == pq[j].cost {
        return pq[i].first.left < pq[j].first.left
    }
    return pq[i].cost < pq[j].cost
}
func (pq PriorityQueue) Swap(i, j int) {
    pq[i], pq[j] = pq[j], pq[i]
    pq[i].index = i
    pq[j].index = j
}
func (pq *PriorityQueue) Push(x interface{}) {
    n := len(*pq)
    item := x.(*Item)
    item.index = n
    *pq = append(*pq, item)
}
func (pq *PriorityQueue) Pop() interface{} {
    old := *pq
    n := len(old)
    item := old[n-1]
    item.index = -1
    *pq = old[0 : n-1]
    return item
}
```

```C
#define MIN_QUEUE_SIZE 4096

typedef struct Node {
    long long value;
    int left;
    struct Node* prev;
    struct Node* next;
} Node;

Node* createNode(long long value, int left) {
    Node* node = (Node*)malloc(sizeof(Node));
    node->value = value;
    node->left = left;
    node->prev = NULL;
    node->next = NULL;
    return node;
}

typedef struct QueueItem {
    Node* first;
    Node* second;
    long long cost;
    int firstLeft;
    int secondLeft;
} QueueItem;

typedef struct Element {
    QueueItem item;
} Element;

typedef bool (*CompareFunc)(const void*, const void*);

static bool itemLess(const void* a, const void* b) {
    const Element* e1 = (const Element*)a;
    const Element* e2 = (const Element*)b;
    const QueueItem* item1 = &e1->item;
    const QueueItem* item2 = &e2->item;
    if (item1->cost != item2->cost) {
        return item1->cost > item2->cost;
    }
    return item1->firstLeft > item2->firstLeft;
}

static void swap(Element* arr, int i, int j) {
    Element t = arr[i];
    arr[i] = arr[j];
    arr[j] = t;
}

typedef struct PriorityQueue {
    Element* arr;
    int capacity;
    int queueSize;
    CompareFunc lessFunc;
} PriorityQueue;

PriorityQueue* createPriorityQueue(CompareFunc cmpFunc) {
    PriorityQueue* obj = (PriorityQueue*)malloc(sizeof(PriorityQueue));
    obj->capacity = MIN_QUEUE_SIZE;
    obj->arr = (Element*)malloc(sizeof(Element) * obj->capacity);
    obj->queueSize = 0;
    obj->lessFunc = cmpFunc;
    return obj;
}

static void down(Element* arr, int size, int i, CompareFunc cmpFunc) {
    while (true) {
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        int smallest = i;
        if (left < size && cmpFunc(&arr[smallest], &arr[left])) {
            smallest = left;
        }
        if (right < size && cmpFunc(&arr[smallest], &arr[right])) {
            smallest = right;
        }
        if (smallest == i) {
            break;
        }
        swap(arr, i, smallest);
        i = smallest;
    }
}

void enQueue(PriorityQueue* obj, const QueueItem* item) {
    if (obj->queueSize == obj->capacity) {
        obj->capacity *= 2;
        obj->arr = (Element*)realloc(obj->arr, sizeof(Element) * obj->capacity);
    }

    obj->arr[obj->queueSize].item = *item;

    int i = obj->queueSize;
    while (i > 0) {
        int parent = (i - 1) / 2;
        if (!obj->lessFunc(&obj->arr[parent], &obj->arr[i])) {
            break;
        }
        swap(obj->arr, i, parent);
        i = parent;
    }

    obj->queueSize++;
}

QueueItem* deQueue(PriorityQueue* obj) {
    if (obj->queueSize == 0) {
        return NULL;
    }

    swap(obj->arr, 0, obj->queueSize - 1);
    QueueItem* result = &obj->arr[obj->queueSize - 1].item;
    obj->queueSize--;
    if (obj->queueSize > 0) {
        down(obj->arr, obj->queueSize, 0, obj->lessFunc);
    }

    return result;
}

QueueItem* front(const PriorityQueue* obj) {
    if (obj->queueSize == 0) {
        return NULL;
    }
    return &obj->arr[0].item;
}

bool isEmpty(const PriorityQueue* obj) {
    return obj->queueSize == 0;
}

int size(const PriorityQueue* obj) {
    return obj->queueSize;
}

void freeQueue(PriorityQueue* obj) {
    free(obj->arr);
    free(obj);
}

int minimumPairRemoval(int* nums, int numsSize) {
    PriorityQueue* pq = createPriorityQueue(itemLess);
    bool* merged = (bool*)calloc(numsSize, sizeof(bool));
    int decreaseCount = 0;
    int count = 0;

    Node** nodes = (Node**)malloc(sizeof(Node*) * numsSize);
    for (int i = 0; i < numsSize; i++) {
        nodes[i] = createNode(nums[i], i);
        if (i > 0) {
            nodes[i - 1]->next = nodes[i];
            nodes[i]->prev = nodes[i - 1];
        }
    }

    for (int i = 1; i < numsSize; i++) {
        QueueItem item;
        item.first = nodes[i - 1];
        item.second = nodes[i];
        item.cost = item.first->value + item.second->value;
        item.firstLeft = item.first->left;
        item.secondLeft = item.second->left;
        enQueue(pq, &item);
        if (nums[i - 1] > nums[i]) {
            decreaseCount++;
        }
    }

    while (decreaseCount > 0 && !isEmpty(pq)) {
        QueueItem* itemPtr = deQueue(pq);
        if (!itemPtr) {
            break;
        }
        QueueItem item = *itemPtr;

        if (merged[item.firstLeft] || merged[item.secondLeft]) {
            continue;
        }

        Node* first = item.first;
        Node* second = item.second;
        long long cost = item.cost;

        if (!first || !second) {
            continue;
        }
        if (first->next != second) {
            continue;
        }
        if (first->value + second->value != cost) {
            continue;
        }

        count++;

        if (first->value > second->value) {
            decreaseCount--;
        }

        Node* prevNode = first->prev;
        Node* nextNode = second->next;

        first->next = nextNode;
        if (nextNode) {
            nextNode->prev = first;
        }
        second->prev = NULL;
        second->next = NULL;

        if (prevNode) {
            if (prevNode->value > first->value && prevNode->value <= cost) {
                decreaseCount--;
            }
            if (prevNode->value <= first->value && prevNode->value > cost) {
                decreaseCount++;
            }
            QueueItem newItem;
            newItem.first = prevNode;
            newItem.second = first;
            newItem.cost = prevNode->value + cost;
            newItem.firstLeft = prevNode->left;
            newItem.secondLeft = first->left;
            enQueue(pq, &newItem);
        }

        if (nextNode) {
            if (second->value > nextNode->value && cost <= nextNode->value) {
                decreaseCount--;
            }
            if (second->value <= nextNode->value && cost > nextNode->value) {
                decreaseCount++;
            }
            QueueItem newItem;
            newItem.first = first;
            newItem.second = nextNode;
            newItem.cost = cost + nextNode->value;
            newItem.firstLeft = first->left;
            newItem.secondLeft = nextNode->left;
            enQueue(pq, &newItem);
        }

        first->value = cost;
        merged[second->left] = true;
    }

    for (int i = 0; i < numsSize; i++) {
        if (!merged[i]) {
            free(nodes[i]);
        }
    }
    free(nodes);
    free(merged);
    freeQueue(pq);

    return count;
}
```

```JavaScript
class Node extends DoublyLinkedListNode {
    value;
    left;
    constructor(value, left) {
        super(value);
        this.value = value;
        this.left = left;
    }
}

var minimumPairRemoval = function (nums) {
    const pq = new PriorityQueue((a, b) =>
        a.cost === b.cost ? a.first.left - b.first.left : a.cost - b.cost
    );

    const list = new DoublyLinkedList();
    const merged = new Array(nums.length).fill(false);
    let decreaseCount = 0;
    let count = 0;
    list.insertLast(new Node(nums[0], 0));

    for (let i = 1; i < nums.length; i++) {
        list.insertLast(new Node(nums[i], i));
        const curr = list.tail();
        pq.enqueue({
            first: curr.getPrev(),
            second: curr,
            cost: nums[i] + nums[i - 1],
        });
        if (nums[i - 1] > nums[i]) {
            decreaseCount++;
        }
    }

    while (decreaseCount > 0) {
        const { first, second, cost } = pq.dequeue();
        if (merged[first.left] || merged[second.left] || first.value + second.value !== cost)
            continue;
        count++;

        if (first.value > second.value) {
            decreaseCount--;
        }

        const prev = first.getPrev();
        const next = second.getNext();

        if (prev) {
            if (prev.value > first.value && prev.value <= cost) {
                decreaseCount--;
            }
            if (prev.value <= first.value && prev.value > cost) {
                decreaseCount++;
            }

            pq.enqueue({
                first: prev,
                second: first,
                cost: prev.value + cost,
            });
        }

        if (next) {
            if (second.value > next.value && cost <= next.value) {
                decreaseCount--;
            }
            if (second.value <= next.value && cost > next.value) {
                decreaseCount++;
            }

            pq.enqueue({
                first: first,
                second: next,
                cost: cost + next.value,
            });
        }

        list.remove(second);
        first.value = cost;
        merged[second.left] = true;
    }

    return count;
};
```

```TypeScript
class Node extends DoublyLinkedListNode {
    constructor(public value: number, public left: number) {
        super(value);
    }
}

interface Pair {
    first: Node;
    second: Node;
    cost: number;
}

function minimumPairRemoval(nums: number[]): number {
    const pq = new PriorityQueue<Pair>((a, b) =>
        a.cost === b.cost ? a.first.left - b.first.left : a.cost - b.cost
    );
    const list = new DoublyLinkedList<Node>();
    const merged = new Array<boolean>(nums.length).fill(false);

    let decreaseCount = 0;
    let count = 0;
    list.insertLast(new Node(nums[0], 0));

    for (let i = 1; i < nums.length; i++) {
        list.insertLast(new Node(nums[i], i));

        const curr = list.tail();
        pq.enqueue({
            first: curr.getPrev() as Node,
            second: curr,
            cost: nums[i] + nums[i - 1],
        });

        if (nums[i - 1] > nums[i]) {
            decreaseCount++;
        }
    }

    while (decreaseCount > 0) {
        const { first, second, cost } = pq.dequeue()!;
        if (merged[first.left] || merged[second.left] || first.value + second.value !== cost)
            continue;
        count++;

        if (first.value > second.value) {
            decreaseCount--;
        }

        const prev = first.getPrev() as Node | null;
        const next = second.getNext() as Node | null;

        if (prev) {
            if (prev.value > first.value && prev.value <= cost) {
                decreaseCount--;
            }
            if (prev.value <= first.value && prev.value > cost) {
                decreaseCount++;
            }

            pq.enqueue({
                first: prev,
                second: first,
                cost: prev.value + cost,
            });
        }

        if (next) {
            if (second.value > next.value && cost <= next.value) {
                decreaseCount--;
            }
            if (second.value <= next.value && cost > next.value) {
                decreaseCount++;
            }

            pq.enqueue({
                first: first,
                second: next,
                cost: cost + next.value,
            });
        }

        list.remove(second);
        first.value = cost;
        merged[second.left] = true;
    }

    return count;
}
```

```Rust
use std::cmp::Ordering;
use std::collections::BinaryHeap;

#[derive(Debug)]
struct Node {
    value: i64,
    left: usize,
    prev: Option<usize>,
    next: Option<usize>,
}

#[derive(Debug)]
struct Item {
    first: usize,
    second: usize,
    cost: i64,
}

impl PartialEq for Item {
    fn eq(&self, other: &Self) -> bool {
        self.cost == other.cost
    }
}

impl Eq for Item {}

impl PartialOrd for Item {
    fn partial_cmp(&self, other: &Self) -> Option<Ordering> {
        Some(self.cmp(other))
    }
}

impl Ord for Item {
    fn cmp(&self, other: &Self) -> Ordering {
        if self.cost == other.cost {
            self.first.cmp(&other.first).reverse()
        } else {
            self.cost.cmp(&other.cost).reverse()
        }
    }
}

impl Solution {
    pub fn minimum_pair_removal(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let mut nodes = Vec::with_capacity(n);
        let mut merged = vec![false; n];
        let mut pq = BinaryHeap::new();

        let mut decrease_count = 0;
        let mut count = 0;

        nodes.push(Node {
            value: nums[0] as i64,
            left: 0,
            prev: None,
            next: Some(1),
        });

        for i in 1..n {
            nodes.push(Node {
                value: nums[i] as i64,
                left: i,
                prev: Some(i - 1),
                next: if i < n - 1 { Some(i + 1) } else { None },
            });

            if i > 0 {
                nodes[i - 1].next = Some(i);
                pq.push(Item {
                    first: i - 1,
                    second: i,
                    cost: nums[i - 1] as i64 + nums[i] as i64,
                });

                if nums[i - 1] > nums[i] {
                    decrease_count += 1;
                }
            }
        }

        while decrease_count > 0 {
            let item = pq.pop().unwrap();
            let first_idx = item.first;
            let second_idx = item.second;
            let cost = item.cost;

            if merged[first_idx] || merged[second_idx] ||
            nodes[first_idx].value + nodes[second_idx].value != cost {
                continue;
            }
            count += 1;
            if nodes[first_idx].value > nodes[second_idx].value {
                decrease_count -= 1;
            }

            let prev_idx = nodes[first_idx].prev;
            let next_idx = nodes[second_idx].next;
            nodes[first_idx].next = next_idx;
            if let Some(next) = next_idx {
                nodes[next].prev = Some(first_idx);
            }
            if let Some(prev) = prev_idx {
                if nodes[prev].value > nodes[first_idx].value && nodes[prev].value <= cost {
                    decrease_count -= 1;
                } else if nodes[prev].value <= nodes[first_idx].value && nodes[prev].value > cost {
                    decrease_count += 1;
                }

                pq.push(Item {
                    first: prev,
                    second: first_idx,
                    cost: nodes[prev].value + cost,
                });
            }

            if let Some(next) = next_idx {
                if nodes[second_idx].value > nodes[next].value && cost <= nodes[next].value {
                    decrease_count -= 1;
                } else if nodes[second_idx].value <= nodes[next].value && cost > nodes[next].value {
                    decrease_count += 1;
                }

                pq.push(Item {
                    first: first_idx,
                    second: next,
                    cost: cost + nodes[next].value,
                });
            }

            nodes[first_idx].value = cost;
            merged[second_idx] = true;
        }

        count
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是 $nums$ 的长度。合并操作最多进行 $n-1$ 轮，每轮中除了向优先队列添加元素需要 $O(\log n)$ 的时间外，其余操作均可在常数时间内完成，故总时间复杂度为 $O(\log n)$。
- 空间复杂度：$O(n)$，双向链表和优先队列等辅助数据结构占用的空间均为 $O(n)$。
