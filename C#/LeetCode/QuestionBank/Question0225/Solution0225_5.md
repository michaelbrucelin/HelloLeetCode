#### [��������һ������](https://leetcode.cn/problems/implement-stack-using-queues/solutions/432204/yong-dui-lie-shi-xian-zhan-by-leetcode-solution/)

����һʹ������������ʵ��ջ�Ĳ�����Ҳ����ʹ��һ������ʵ��ջ�Ĳ�����

ʹ��һ������ʱ��Ϊ������ջ�����ԣ��������ջ��Ԫ�����ȳ�ջ��ͬ����Ҫ�������ǰ�˵�Ԫ���������ջ��Ԫ�ء�

��ջ����ʱ�����Ȼ����ջǰ��Ԫ�ظ��� $n$��Ȼ��Ԫ����ӵ����У��ٽ������е�ǰ $n$ ��Ԫ�أ�����������ջ��Ԫ��֮���ȫ��Ԫ�أ����γ��Ӳ���ӵ����У���ʱ���е�ǰ�˵�Ԫ�ؼ�Ϊ����ջ��Ԫ�أ��Ҷ��е�ǰ�˺ͺ�˷ֱ��Ӧջ����ջ�ס�

����ÿ����ջ������ȷ�����е�ǰ��Ԫ��Ϊջ��Ԫ�أ���˳�ջ�����ͻ��ջ��Ԫ�ز��������Լ�ʵ�֡���ջ����ֻ��Ҫ�Ƴ����е�ǰ��Ԫ�ز����ؼ��ɣ����ջ��Ԫ�ز���ֻ��Ҫ��ö��е�ǰ��Ԫ�ز����ؼ��ɣ����Ƴ�Ԫ�أ���

���ڶ������ڴ洢ջ�ڵ�Ԫ�أ��ж�ջ�Ƿ�Ϊ��ʱ��ֻ��Ҫ�ж϶����Ƿ�Ϊ�ռ��ɡ�

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ���ջ���� $O(n)$������������� $O(1)$������ $n$ ��ջ�ڵ�Ԫ�ظ����� ��ջ������Ҫ�������е� $n$ ��Ԫ�س��ӣ������ $n+1$ ��Ԫ�ص����У����� $2n+1$ �β�����ÿ�γ��Ӻ���Ӳ�����ʱ�临�Ӷȶ��� $O(1)$�������ջ������ʱ�临�Ӷ��� $O(n)$�� ��ջ������Ӧ�����е�ǰ��Ԫ�س��ӣ�ʱ�临�Ӷ��� $O(1)$�� ���ջ��Ԫ�ز�����Ӧ��ö��е�ǰ��Ԫ�أ�ʱ�临�Ӷ��� $O(1)$�� �ж�ջ�Ƿ�Ϊ�ղ���ֻ��Ҫ�ж϶����Ƿ�Ϊ�գ�ʱ�临�Ӷ��� $O(1)$��
-   �ռ临�Ӷȣ�$O(n)$������ $n$ ��ջ�ڵ�Ԫ�ظ�������Ҫʹ��һ�����д洢ջ�ڵ�Ԫ�ء�
