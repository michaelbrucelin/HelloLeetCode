#### [����һ��˫ջ](https://leetcode.cn/problems/implement-queue-using-stacks/solutions/632369/yong-zhan-shi-xian-dui-lie-by-leetcode-s-xnb6/)

**˼·**

��һ��ջ��������ջ������ѹ�� $push$ ��������ݣ���һ��ջ�������ջ������ $pop$ �� $peek$ ������

ÿ�� $pop$ �� $peek$ ʱ�������ջΪ��������ջ��ȫ���������ε�����ѹ�����ջ���������ջ��ջ����ջ�׵�˳����Ƕ��дӶ�������β��˳��

**����**

```cpp
class MyQueue {
private:
    stack<int> inStack, outStack;

    void in2out() {
        while (!inStack.empty()) {
            outStack.push(inStack.top());
            inStack.pop();
        }
    }

public:
    MyQueue() {}

    void push(int x) {
        inStack.push(x);
    }

    int pop() {
        if (outStack.empty()) {
            in2out();
        }
        int x = outStack.top();
        outStack.pop();
        return x;
    }

    int peek() {
        if (outStack.empty()) {
            in2out();
        }
        return outStack.top();
    }

    bool empty() {
        return inStack.empty() && outStack.empty();
    }
};
```

```java
class MyQueue {
    Deque<Integer> inStack;
    Deque<Integer> outStack;

    public MyQueue() {
        inStack = new ArrayDeque<Integer>();
        outStack = new ArrayDeque<Integer>();
    }

    public void push(int x) {
        inStack.push(x);
    }

    public int pop() {
        if (outStack.isEmpty()) {
            in2out();
        }
        return outStack.pop();
    }

    public int peek() {
        if (outStack.isEmpty()) {
            in2out();
        }
        return outStack.peek();
    }

    public boolean empty() {
        return inStack.isEmpty() && outStack.isEmpty();
    }

    private void in2out() {
        while (!inStack.isEmpty()) {
            outStack.push(inStack.pop());
        }
    }
}
```

```csharp
public class MyQueue {
    Stack<int> inStack;
    Stack<int> outStack;

    public MyQueue() {
        inStack = new Stack<int>();
        outStack = new Stack<int>();
    }

    public void Push(int x) {
        inStack.Push(x);
    }

    public int Pop() {
        if (outStack.Count == 0) {
            In2Out();
        }
        return outStack.Pop();
    }

    public int Peek() {
        if (outStack.Count == 0) {
            In2Out();
        }
        return outStack.Peek();
    }

    public bool Empty() {
        return inStack.Count == 0 && outStack.Count == 0;
    }

    private void In2Out() {
        while (inStack.Count > 0) {
            outStack.Push(inStack.Pop());
        }
    }
}
```

```go
type MyQueue struct {
    inStack, outStack []int
}

func Constructor() MyQueue {
    return MyQueue{}
}

func (q *MyQueue) Push(x int) {
    q.inStack = append(q.inStack, x)
}

func (q *MyQueue) in2out() {
    for len(q.inStack) > 0 {
        q.outStack = append(q.outStack, q.inStack[len(q.inStack)-1])
        q.inStack = q.inStack[:len(q.inStack)-1]
    }
}

func (q *MyQueue) Pop() int {
    if len(q.outStack) == 0 {
        q.in2out()
    }
    x := q.outStack[len(q.outStack)-1]
    q.outStack = q.outStack[:len(q.outStack)-1]
    return x
}

func (q *MyQueue) Peek() int {
    if len(q.outStack) == 0 {
        q.in2out()
    }
    return q.outStack[len(q.outStack)-1]
}

func (q *MyQueue) Empty() bool {
    return len(q.inStack) == 0 && len(q.outStack) == 0
}
```

```javascript
var MyQueue = function() {
    this.inStack = [];
    this.outStack = [];
};

MyQueue.prototype.push = function(x) {
    this.inStack.push(x);
};

MyQueue.prototype.pop = function() {
    if (!this.outStack.length) {
        this.in2out();
    }
    return this.outStack.pop();
};

MyQueue.prototype.peek = function() {
    if (!this.outStack.length) {
        this.in2out();
    }
    return this.outStack[this.outStack.length - 1];
};

MyQueue.prototype.empty = function() {
    return this.outStack.length === 0 && this.inStack.length === 0;
};

MyQueue.prototype.in2out = function() {
    while (this.inStack.length) {
        this.outStack.push(this.inStack.pop());
    }
};
```

```c
typedef struct {
    int* stk;
    int stkSize;
    int stkCapacity;
} Stack;

Stack* stackCreate(int cpacity) {
    Stack* ret = malloc(sizeof(Stack));
    ret->stk = malloc(sizeof(int) * cpacity);
    ret->stkSize = 0;
    ret->stkCapacity = cpacity;
    return ret;
}

void stackPush(Stack* obj, int x) {
    obj->stk[obj->stkSize++] = x;
}

void stackPop(Stack* obj) {
    obj->stkSize--;
}

int stackTop(Stack* obj) {
    return obj->stk[obj->stkSize - 1];
}

bool stackEmpty(Stack* obj) {
    return obj->stkSize == 0;
}

void stackFree(Stack* obj) {
    free(obj->stk);
}

typedef struct {
    Stack* inStack;
    Stack* outStack;
} MyQueue;

MyQueue* myQueueCreate() {
    MyQueue* ret = malloc(sizeof(MyQueue));
    ret->inStack = stackCreate(100);
    ret->outStack = stackCreate(100);
    return ret;
}

void in2out(MyQueue* obj) {
    while (!stackEmpty(obj->inStack)) {
        stackPush(obj->outStack, stackTop(obj->inStack));
        stackPop(obj->inStack);
    }
}

void myQueuePush(MyQueue* obj, int x) {
    stackPush(obj->inStack, x);
}

int myQueuePop(MyQueue* obj) {
    if (stackEmpty(obj->outStack)) {
        in2out(obj);
    }
    int x = stackTop(obj->outStack);
    stackPop(obj->outStack);
    return x;
}

int myQueuePeek(MyQueue* obj) {
    if (stackEmpty(obj->outStack)) {
        in2out(obj);
    }
    return stackTop(obj->outStack);
}

bool myQueueEmpty(MyQueue* obj) {
    return stackEmpty(obj->inStack) && stackEmpty(obj->outStack);
}

void myQueueFree(MyQueue* obj) {
    stackFree(obj->inStack);
    stackFree(obj->outStack);
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$push$ �� $empty$ Ϊ $O(1)$��$pop$ �� $peek$ Ϊ��̯ $O(1)$������ÿ��Ԫ�أ�������ջ�ͳ�ջ�����Σ��ʾ�̯���Ӷ�Ϊ $O(1)$��
-   �ռ临�Ӷȣ�$O(n)$������ $n$ �ǲ��������������� $n$ �� $push$ ����������������л��� $n$ ��Ԫ�أ��ʿռ临�Ӷ�Ϊ $O(n)$��
