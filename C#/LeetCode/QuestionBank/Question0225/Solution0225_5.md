#### [方法二：一个队列](https://leetcode.cn/problems/implement-stack-using-queues/solutions/432204/yong-dui-lie-shi-xian-zhan-by-leetcode-solution/)

方法一使用了两个队列实现栈的操作，也可以使用一个队列实现栈的操作。

使用一个队列时，为了满足栈的特性，即最后入栈的元素最先出栈，同样需要满足队列前端的元素是最后入栈的元素。

入栈操作时，首先获得入栈前的元素个数 $n$，然后将元素入队到队列，再将队列中的前 $n$ 个元素（即除了新入栈的元素之外的全部元素）依次出队并入队到队列，此时队列的前端的元素即为新入栈的元素，且队列的前端和后端分别对应栈顶和栈底。

由于每次入栈操作都确保队列的前端元素为栈顶元素，因此出栈操作和获得栈顶元素操作都可以简单实现。出栈操作只需要移除队列的前端元素并返回即可，获得栈顶元素操作只需要获得队列的前端元素并返回即可（不移除元素）。

由于队列用于存储栈内的元素，判断栈是否为空时，只需要判断队列是否为空即可。

![](./assets/img/Solution0225_5_01.gif)

```java
class MyStack {
    Queue<Integer> queue;

    /** Initialize your data structure here. */
    public MyStack() {
        queue = new LinkedList<Integer>();
    }

    /** Push element x onto stack. */
    public void push(int x) {
        int n = queue.size();
        queue.offer(x);
        for (int i = 0; i < n; i++) {
            queue.offer(queue.poll());
        }
    }

    /** Removes the element on top of the stack and returns that element. */
    public int pop() {
        return queue.poll();
    }

    /** Get the top element. */
    public int top() {
        return queue.peek();
    }

    /** Returns whether the stack is empty. */
    public boolean empty() {
        return queue.isEmpty();
    }
}
```

```cpp
class MyStack {
public:
    queue<int> q;

    /** Initialize your data structure here. */
    MyStack() {

    }

    /** Push element x onto stack. */
    void push(int x) {
        int n = q.size();
        q.push(x);
        for (int i = 0; i < n; i++) {
            q.push(q.front());
            q.pop();
        }
    }

    /** Removes the element on top of the stack and returns that element. */
    int pop() {
        int r = q.front();
        q.pop();
        return r;
    }

    /** Get the top element. */
    int top() {
        int r = q.front();
        return r;
    }

    /** Returns whether the stack is empty. */
    bool empty() {
        return q.empty();
    }
};
```

```python
class MyStack:

    def __init__(self):
        """
        Initialize your data structure here.
        """
        self.queue = collections.deque()


    def push(self, x: int) -> None:
        """
        Push element x onto stack.
        """
        n = len(self.queue)
        self.queue.append(x)
        for _ in range(n):
            self.queue.append(self.queue.popleft())


    def pop(self) -> int:
        """
        Removes the element on top of the stack and returns that element.
        """
        return self.queue.popleft()


    def top(self) -> int:
        """
        Get the top element.
        """
        return self.queue[0]


    def empty(self) -> bool:
        """
        Returns whether the stack is empty.
        """
        return not self.queue
```

```go
type MyStack struct {
    queue []int
}

/** Initialize your data structure here. */
func Constructor() (s MyStack) {
    return
}

/** Push element x onto stack. */
func (s *MyStack) Push(x int) {
    n := len(s.queue)
    s.queue = append(s.queue, x)
    for ; n > 0; n-- {
        s.queue = append(s.queue, s.queue[0])
        s.queue = s.queue[1:]
    }
}

/** Removes the element on top of the stack and returns that element. */
func (s *MyStack) Pop() int {
    v := s.queue[0]
    s.queue = s.queue[1:]
    return v
}

/** Get the top element. */
func (s *MyStack) Top() int {
    return s.queue[0]
}

/** Returns whether the stack is empty. */
func (s *MyStack) Empty() bool {
    return len(s.queue) == 0
}
```

```c
typedef struct tagListNode {
    struct tagListNode* next;
    int val;
} ListNode;

typedef struct {
    ListNode* top;
} MyStack;

MyStack* myStackCreate() {
    MyStack* stk = calloc(1, sizeof(MyStack));
    return stk;
}

void myStackPush(MyStack* obj, int x) {
    ListNode* node = malloc(sizeof(ListNode));
    node->val = x;
    node->next = obj->top;
    obj->top = node;
}

int myStackPop(MyStack* obj) {
    ListNode* node = obj->top;
    int val = node->val;
    obj->top = node->next;
    free(node);

    return val;
}

int myStackTop(MyStack* obj) {
    return obj->top->val;
}

bool myStackEmpty(MyStack* obj) {
    return (obj->top == NULL);
}

void myStackFree(MyStack* obj) {
    while (obj->top != NULL) {
        ListNode* node = obj->top;
        obj->top = obj->top->next;
        free(node);
    }
    free(obj);
}
```

**复杂度分析**

-   时间复杂度：入栈操作 $O(n)$，其余操作都是 $O(1)$，其中 $n$ 是栈内的元素个数。 入栈操作需要将队列中的 $n$ 个元素出队，并入队 $n+1$ 个元素到队列，共有 $2n+1$ 次操作，每次出队和入队操作的时间复杂度都是 $O(1)$，因此入栈操作的时间复杂度是 $O(n)$。 出栈操作对应将队列的前端元素出队，时间复杂度是 $O(1)$。 获得栈顶元素操作对应获得队列的前端元素，时间复杂度是 $O(1)$。 判断栈是否为空操作只需要判断队列是否为空，时间复杂度是 $O(1)$。
-   空间复杂度：$O(n)$，其中 $n$ 是栈内的元素个数。需要使用一个队列存储栈内的元素。
