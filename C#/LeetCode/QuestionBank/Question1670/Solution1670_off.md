### [设计前中后队列](https://leetcode.cn/problems/design-front-middle-back-queue/solutions/2539737/she-ji-qian-zhong-hou-dui-lie-by-leetcod-b3p0/)

#### 方法一：双端队列

**思路与算法**

在本题中，我们需要设计一种支持在头部、中部和尾部插入、删除元素的数据结构。可以自然而然的想到将该数据结构分为左右两个部分，它们的长度大致相同，并且左边尾部与右边头部相接。这样一来，我们对中部的操作可以转换为对左边尾部或者右边头部的操作。

由于左右两个部分都需要支持头部、尾部的插入和删除，因此使用双端队列这一基础数据结构。我们用 $left$ 表示左边，用 $right$ 表示右边。在整个过程中，保持 $left$ 和 $right$ 的长度相同，或者 $left$ 的长度恰好比 $right$ 大 $1$，即 $right.length \le left.length \le right.length + 1$（当然也可以反过来，让 $left$ 的长度与 $right$ 的长度相等或者 $right$ 的长度比 $left$ 恰好大 $1$），这样做是为了能够方便的在中部进行插入和删除操作。

在以下六个基本操作中，你需要设置一些调整让两个双端队列满足长度约束：

-   头部插入 $pushFront$，在 $left$ 的头部插入，若插入后 $left$ 的长度比 $right$ 的长度大 $2$，需要将 $left$ 的尾部元素移动到 $right$ 的头部
-   中部插入 $pushMiddle$，在 $left$ 的尾部插入，若插入前 $left$ 的长度比 $right$ 的长度大 $1$，需要先把 $left$ 的尾部元素移动到 $right$ 的头部，然后再插入新元素
-   尾部插入 $pushBack$，在 $right$ 尾部插入，若插入后 $right$ 的长度比 $left$ 的长度大 $1$，需要将 $right$ 的头部元素移动到 $left$ 的尾部
-   头部删除 $popFront$，若 $left$ 为空则直接返回 $-1$（因为当队列中有元素时，$left$ 总是不为空，以下同理），否则删除 $left$ 的头部元素，若删除后 $left$ 的长度比 $right$ 的长度小 $1$，需要将 $right$ 的头部元素移动到 $left$ 的尾部
-   中部删除 $popMiddle$，若 $left$ 为空则直接返回 $-1$，否则删除 $left$ 的尾部元素，若删除后 $left$ 的长度比 $right$ 的长度小 $1$，需要将 $right$ 的头部元素移动到 $left$ 的尾部
-   尾部删除 $popBack$，若 $left$ 为空则直接返回 $-1$，否则再看 $right$ 的长度:
    -   若 $right$ 为空（此时队列中仅存在一个元素），删除 $left$ 的尾部元素
    -   若 $right$ 不为空，删除 $right$ 的尾部元素，若删除后 $left$ 的长度比 $right$ 的长度大 $2$，需要将 $left$ 的尾部元素移动到 $right$ 的头部。

**代码**

```c++
class FrontMiddleBackQueue {
public:
    FrontMiddleBackQueue() {

    }

    void pushFront(int val) {
        left.push_front(val);
        if (left.size() == right.size() + 2) {
            right.push_front(left.back());
            left.pop_back();
        }
    }

    void pushMiddle(int val) {
        if (left.size() == right.size() + 1) {
            right.push_front(left.back());
            left.pop_back();
        }
        left.push_back(val);
    }

    void pushBack(int val) {
        right.push_back(val);
        if (left.size() + 1 == right.size()) {
            left.push_back(right.front());
            right.pop_front();
        }
    }

    int popFront() {
        if (left.empty()) {
            return -1;
        }
        int val = left.front();
        left.pop_front();
        if (left.size() + 1 == right.size()) {
            left.push_back(right.front());
            right.pop_front();
        }
        return val;
    }

    int popMiddle() {
        if (left.empty()) {
            return -1;
        }
        int val = left.back();
        left.pop_back();
        if (left.size() + 1 == right.size()) {
            left.push_back(right.front());
            right.pop_front();
        }
        return val;
    }

    int popBack() {
        if (left.empty()) {
            return -1;
        }
        int val = 0;
        if (right.empty()) {
            val = left.back();
            left.pop_back();
        } else {
            val = right.back();
            right.pop_back();
            if (left.size() == right.size() + 2) {
                right.push_front(left.back());
                left.pop_back();
            }
        }
        return val;
    }
private:
    deque<int> left;
    deque<int> right;
};
```

```java
class FrontMiddleBackQueue {
    Deque<Integer> left;
    Deque<Integer> right;

    public FrontMiddleBackQueue() {
        left = new ArrayDeque<Integer>();
        right = new ArrayDeque<Integer>();
    }

    public void pushFront(int val) {
        left.offerFirst(val);
        if (left.size() == right.size() + 2) {
            right.offerFirst(left.pollLast());
        }
    }

    public void pushMiddle(int val) {
        if (left.size() == right.size() + 1) {
            right.offerFirst(left.pollLast());
        }
        left.offerLast(val);
    }

    public void pushBack(int val) {
        right.offerLast(val);
        if (left.size() + 1 == right.size()) {
            left.offerLast(right.pollFirst());
        }
    }

    public int popFront() {
        if (left.isEmpty()) {
            return -1;
        }
        int val = left.pollFirst();
        if (left.size() + 1 == right.size()) {
            left.offerLast(right.pollFirst());
        }
        return val;
    }

    public int popMiddle() {
        if (left.isEmpty()) {
            return -1;
        }
        int val = left.pollLast();
        if (left.size() + 1 == right.size()) {
            left.offerLast(right.pollFirst());
        }
        return val;
    }

    public int popBack() {
        if (left.isEmpty()) {
            return -1;
        }
        int val = 0;
        if (right.isEmpty()) {
            val = left.pollLast();
        } else {
            val = right.pollLast();
            if (left.size() == right.size() + 2) {
                right.offerFirst(left.pollLast());
            }
        }
        return val;
    }
}
```

```go
type FrontMiddleBackQueue struct {
    left *list.List
    right *list.List
}

func Constructor() FrontMiddleBackQueue {
    return FrontMiddleBackQueue{
        left: list.New(), 
        right: list.New(),
    }
}

func (this *FrontMiddleBackQueue) PushFront(val int)  {
    this.left.PushFront(val)
    if this.left.Len() == this.right.Len() + 2 {
        this.right.PushFront(this.left.Back().Value.(int))
        this.left.Remove(this.left.Back())
    }
}

func (this *FrontMiddleBackQueue) PushMiddle(val int)  {
    if this.left.Len() == this.right.Len() + 1 {
        this.right.PushFront(this.left.Back().Value.(int))
        this.left.Remove(this.left.Back())
    }
    this.left.PushBack(val)
}

func (this *FrontMiddleBackQueue) PushBack(val int)  {
    this.right.PushBack(val)
    if this.left.Len() + 1 == this.right.Len() {
        this.left.PushBack(this.right.Front().Value.(int))
        this.right.Remove(this.right.Front())
    }
}

func (this *FrontMiddleBackQueue) PopFront() int {
    if this.left.Len() == 0 {
        return -1
    }
    val := this.left.Front().Value.(int)
    this.left.Remove(this.left.Front())
    if this.left.Len() + 1 == this.right.Len() {
        this.left.PushBack(this.right.Front().Value.(int))
        this.right.Remove(this.right.Front())
    }
    return val
}

func (this *FrontMiddleBackQueue) PopMiddle() int {
    if this.left.Len() == 0 {
        return -1
    }
    val := this.left.Back().Value.(int)
    this.left.Remove(this.left.Back())
    if this.left.Len() + 1 == this.right.Len() {
        this.left.PushBack(this.right.Front().Value.(int))
        this.right.Remove(this.right.Front())
    }
    return val
}

func (this *FrontMiddleBackQueue) PopBack() int {
    if this.left.Len() == 0 {
        return -1
    }
    if this.right.Len() == 0 {
        val := this.left.Back().Value.(int)
        this.left.Remove(this.left.Back())
        return val
    } else {
        val := this.right.Back().Value.(int)
        this.right.Remove(this.right.Back())
        if this.left.Len() == this.right.Len() + 2 {
            this.right.PushFront(this.left.Back().Value.(int))
            this.left.Remove(this.left.Back())
        }
        return val
    }
}
```

```python
class FrontMiddleBackQueue:

    def __init__(self):
        self.left = collections.deque()
        self.right = collections.deque()

    def pushFront(self, val: int) -> None:
        self.left.appendleft(val)
        if len(self.left) == len(self.right) + 2:
            self.right.appendleft(self.left.pop())

    def pushMiddle(self, val: int) -> None:
        if len(self.left) == len(self.right) + 1:
            self.right.appendleft(self.left.pop())
        self.left.append(val)

    def pushBack(self, val: int) -> None:
        self.right.append(val)
        if len(self.left) + 1 == len(self.right):
            self.left.append(self.right.popleft())

    def popFront(self) -> int:
        if len(self.left) == 0:
            return -1
        val = self.left.popleft()
        if len(self.left) + 1 == len(self.right):
            self.left.append(self.right.popleft())
        return val

    def popMiddle(self) -> int:
        if len(self.left) == 0:
            return -1
        val = self.left.pop()
        if len(self.left) + 1 == len(self.right):
            self.left.append(self.right.popleft())
        return val

    def popBack(self) -> int:
        if len(self.left) == 0:
            return -1
        val = 0
        if len(self.right) == 0:
            val = self.left.pop()
        else:
            val = self.right.pop()
            if len(self.left) == len(self.right) + 2:
                self.right.appendleft(self.left.pop())
        return val
```

```c
typedef struct DoubleLinkListNode {
    struct DoubleLinkListNode *prev;
    struct DoubleLinkListNode *next;
    int val;
} DLNode;

typedef struct {
    DLNode *head;
    DLNode *tail;
    int length;
} Deque;

typedef struct {
    Deque *left;
    Deque *right;
} FrontMiddleBackQueue;

DLNode* doubleLinkListNodeCreate(int val) {
    DLNode *obj = (DLNode *)malloc(sizeof(DLNode));
    obj->prev = NULL;
    obj->next = NULL;
    obj->val = val;
    return obj;
}

Deque* dequeCreate() {
    Deque *obj = (Deque *)malloc(sizeof(Deque));
    obj->head = doubleLinkListNodeCreate(-1);
    obj->tail = doubleLinkListNodeCreate(-1);
    obj->head->next = obj->tail;
    obj->tail->prev = obj->head;
    obj->length = 0;
    return obj;
}

bool dequePushFront(Deque* obj, int val) {
    assert(obj != NULL);
    DLNode *node = doubleLinkListNodeCreate(val);
    node->next = obj->head->next;
    node->next->prev = node;
    node->prev = obj->head;
    obj->head->next = node;
    obj->length++;
    return true;
}

bool dequePushBack(Deque* obj, int val) {
    assert(obj != NULL);
    DLNode *node = doubleLinkListNodeCreate(val);
    node->next = obj->tail;
    node->prev = obj->tail->prev;
    node->prev->next = node;
    obj->tail->prev = node;
    obj->length++;
    return true;
}

int dequeFront(Deque* obj) {
    assert(obj != NULL && obj->length != 0);
    return obj->head->next->val;
}

int dequeBack(Deque* obj) {
    assert(obj != NULL && obj->length != 0);
    return obj->tail->prev->val;
}

int dequePopFront(Deque* obj) {
    assert(obj != NULL && obj->length != 0);
    int val = obj->head->next->val;
    DLNode *node = obj->head->next;
    obj->head->next = node->next;
    node->next->prev = obj->head;
    obj->length--;
    free(node);
    return val;
}

int dequePopBack(Deque* obj) {
    assert(obj != NULL && obj->length != 0);
    int val = obj->tail->prev->val;
    DLNode *node = obj->tail->prev;
    node->prev->next = obj->tail;
    obj->tail->prev = node->prev;
    obj->length--;
    free(node);
    return val;
}

int dequeLength(Deque* obj) {
    assert(obj != NULL);
    return obj->length;
}

bool dequeEmpty(Deque *obj) {
    assert(obj != NULL);
    return obj->length == 0;
}

void dequeFree(Deque *obj) {
    DLNode *curr = obj->head;
    while (curr) {
        DLNode *node = curr;
        curr = curr->next;
        free(node);
    }
    free(obj);
}

FrontMiddleBackQueue* frontMiddleBackQueueCreate() {
    FrontMiddleBackQueue *obj = (FrontMiddleBackQueue *)malloc(sizeof(FrontMiddleBackQueue));
    obj->left = dequeCreate();
    obj->right = dequeCreate();
    return obj;
}

void frontMiddleBackQueuePushFront(FrontMiddleBackQueue* obj, int val) {
    dequePushFront(obj->left, val);
    if (dequeLength(obj->left) == dequeLength(obj->right) + 2) {
        dequePushFront(obj->right, dequePopBack(obj->left));
    }
}

void frontMiddleBackQueuePushMiddle(FrontMiddleBackQueue* obj, int val) {
    if (dequeLength(obj->left) == dequeLength(obj->right) + 1) {
        dequePushFront(obj->right, dequePopBack(obj->left));
    }
    dequePushBack(obj->left, val);
}

void frontMiddleBackQueuePushBack(FrontMiddleBackQueue* obj, int val) {
    dequePushBack(obj->right, val);
    if (dequeLength(obj->left) + 1 == dequeLength(obj->right)) {
        dequePushBack(obj->left, dequePopFront(obj->right));
    }
}

int frontMiddleBackQueuePopFront(FrontMiddleBackQueue* obj) {
    if (dequeEmpty(obj->left)) {
        return -1;
    }
    int val = dequePopFront(obj->left);
    if (dequeLength(obj->left) + 1 == dequeLength(obj->right)) {
        dequePushBack(obj->left, dequePopFront(obj->right));
    }
    return val;
}

int frontMiddleBackQueuePopMiddle(FrontMiddleBackQueue* obj) {
    if (dequeEmpty(obj->left)) {
        return -1;
    }
    int val = dequePopBack(obj->left);
    if (dequeLength(obj->left) + 1 == dequeLength(obj->right)) {
        dequePushBack(obj->left, dequePopFront(obj->right));
    }
    return val;
}

int frontMiddleBackQueuePopBack(FrontMiddleBackQueue* obj) {
    if (dequeEmpty(obj->left)) {
        return -1;
    }
    int val = 0;
    if (dequeEmpty(obj->right)) {
        val = dequePopBack(obj->left);
    } else {
        val = dequePopBack(obj->right);
        if (dequeLength(obj->left) == dequeLength(obj->right) + 2) {
            dequePushFront(obj->right, dequePopBack(obj->left));
        }
    }
    return val;
}

void frontMiddleBackQueueFree(FrontMiddleBackQueue* obj) {
    dequeFree(obj->left);
    dequeFree(obj->right);
    free(obj);
}
```

```javascript
function DLNode(val, next = null, prev = null) {
    this.val = val;
    this.next = next;
    this.prev = prev;
}

function Deque() {
    this.head = new DLNode(-1)
    this.tail = new DLNode(-1);
    this.head.next = this.tail;
    this.tail.prev = this.head;
    this.count = 0;
    this.pushFront = function(val) {
        node = new DLNode(val);
        node.prev = this.head;
        node.next = this.head.next;
        node.next.prev = node;
        this.head.next = node; 
        this.count++;
    }

    this.pushBack = function(val) {
        node = new DLNode(val);
        node.prev = this.tail.prev;
        node.next = this.tail;
        node.prev.next = node;
        this.tail.prev = node; 
        this.count++;
    }

    this.popFront = function() {
        if (this.isEmpty()) {
            return -1;
        }
        var val = this.head.next.val;
        this.head.next = this.head.next.next;
        this.head.next.prev = this.head;
        this.count--;
        return val;
    }
    this.popBack = function() {
        if (this.isEmpty()) {
            return -1;
        }
        var val = this.tail.prev.val;
        this.tail.prev = this.tail.prev.prev;
        this.tail.prev.next = this.tail;
        this.count--;
        return val;
    }

    this.length = function() {
        return this.count;
    }

    this.isEmpty = function() {
        return this.count == 0;
    }
};

var FrontMiddleBackQueue = function() {
    this.left = new Deque();
    this.right = new Deque();
};

FrontMiddleBackQueue.prototype.pushFront = function(val) {
    this.left.pushFront(val);
    if (this.left.length() == this.right.length() + 2) {
        this.right.pushFront(this.left.popBack());
    }
};

FrontMiddleBackQueue.prototype.pushMiddle = function(val) {
    if (this.left.length() == this.right.length() + 1) {
        this.right.pushFront(this.left.popBack());
    }
    this.left.pushBack(val);
};

FrontMiddleBackQueue.prototype.pushBack = function(val) {
    this.right.pushBack(val);
    if (this.left.length() + 1 == this.right.length()) {
        this.left.pushBack(this.right.popFront());
    }
};

FrontMiddleBackQueue.prototype.popFront = function() {
    if (this.left.isEmpty()) {
        return -1;
    }
    var val = this.left.popFront();
    if (this.left.length() + 1 == this.right.length()) {
        this.left.pushBack(this.right.popFront());
    }
    return val;
};

FrontMiddleBackQueue.prototype.popMiddle = function() {
    if (this.left.isEmpty()) {
        return -1;
    }
    var val = this.left.popBack();
    if (this.left.length() + 1 == this.right.length()) {
        this.left.pushBack(this.right.popFront());
    }
    return val;
};

FrontMiddleBackQueue.prototype.popBack = function() {
    if (this.left.isEmpty()) {
        return -1;
    }
    var val = 0;
    if (this.right.isEmpty()) {
        val = this.left.popBack();   
    } else {
        val = this.right.popBack();
        if (this.left.length() == this.right.length() + 2) {
            this.right.pushFront(this.left.popBack());
        }
    }
    return val;
};
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是操作次数。由于在双端队列头部和尾部进行插入或者删除的时间复杂度为 $O(1)$，因此总体时间复杂度为 $O(n)$。
-   空间复杂度：$O(n)$。
