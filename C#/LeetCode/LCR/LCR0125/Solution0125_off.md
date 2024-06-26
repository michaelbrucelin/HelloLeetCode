### [用两个栈实现队列](https://leetcode.cn/problems/yong-liang-ge-zhan-shi-xian-dui-lie-lcof/solutions/103069/mian-shi-ti-09-yong-liang-ge-zhan-shi-xian-dui-l-3/)

#### 方法一：双栈

##### 思路

将一个栈当作输入栈，用于压入 $\texttt{appendTail}$ 传入的数据；另一个栈当作输出栈，用于 $\texttt{deleteHead}$ 操作。

每次 $\texttt{deleteHead}$ 时，若输出栈为空则将输入栈的全部数据依次弹出并压入输出栈，这样输出栈从栈顶往栈底的顺序就是队列从队首往队尾的顺序。

##### 代码

```c++
class CQueue {
private:
    stack<int> inStack, outStack;

    void in2out() {
        while (!inStack.empty()) {
            outStack.push(inStack.top());
            inStack.pop();
        }
    }

public:
    CQueue() {}

    void appendTail(int value) {
        inStack.push(value);
    }

    int deleteHead() {
        if (outStack.empty()) {
            if (inStack.empty()) {
                return -1;
            }
            in2out();
        }
        int value = outStack.top();
        outStack.pop();
        return value;
    }
};
```

```java
class CQueue {
    Deque<Integer> inStack;
    Deque<Integer> outStack;

    public CQueue() {
        inStack = new ArrayDeque<Integer>();
        outStack = new ArrayDeque<Integer>();
    }

    public void appendTail(int value) {
        inStack.push(value);
    }

    public int deleteHead() {
        if (outStack.isEmpty()) {
            if (inStack.isEmpty()) {
                return -1;
            }
            in2out();
        }
        return outStack.pop();
    }

    private void in2out() {
        while (!inStack.isEmpty()) {
            outStack.push(inStack.pop());
        }
    }
}
```

```csharp
public class CQueue {
    Stack<int> inStack;
    Stack<int> outStack;

    public CQueue() {
        inStack = new Stack<int>();
        outStack = new Stack<int>();
    }

    public void AppendTail(int value) {
        inStack.Push(value);
    }

    public int DeleteHead() {
        if (outStack.Count == 0) {
            if (inStack.Count == 0) {
                return -1;
            }
            In2Out();
        }
        return outStack.Pop();
    }

    private void In2Out() {
        while (inStack.Count > 0) {
            outStack.Push(inStack.Pop());
        }
    }
}
```

```go
type CQueue struct {
    inStack, outStack []int
}

func Constructor() CQueue {
    return CQueue{}
}

func (this *CQueue) AppendTail(value int)  {
    this.inStack = append(this.inStack, value)
}

func (this *CQueue) DeleteHead() int {
    if len(this.outStack) == 0 {
        if len(this.inStack) == 0 {
            return -1
        }
        this.in2out()
    }
    value := this.outStack[len(this.outStack)-1]
    this.outStack = this.outStack[:len(this.outStack)-1]
    return value
}

func (this *CQueue) in2out() {
    for len(this.inStack) > 0 {
        this.outStack = append(this.outStack, this.inStack[len(this.inStack)-1])
        this.inStack = this.inStack[:len(this.inStack)-1]
    }
}
```

```javascript
var CQueue = function() {
    this.inStack = [];
    this.outStack = [];
};

CQueue.prototype.appendTail = function(value) {
    this.inStack.push(value);
};

CQueue.prototype.deleteHead = function() {
    if (!this.outStack.length) {
        if (!this.inStack.length) {
            return -1;
        }
        this.in2out();
    }
    return this.outStack.pop();
};

CQueue.prototype.in2out = function() {
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

void stackPush(Stack* obj, int value) {
    obj->stk[obj->stkSize++] = value;
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
} CQueue;

CQueue* cQueueCreate() {
    CQueue* ret = malloc(sizeof(CQueue));
    ret->inStack = stackCreate(10000);
    ret->outStack = stackCreate(10000);
    return ret;
}

void in2out(CQueue* obj) {
    while (!stackEmpty(obj->inStack)) {
        stackPush(obj->outStack, stackTop(obj->inStack));
        stackPop(obj->inStack);
    }
}

void cQueueAppendTail(CQueue* obj, int value) {
    stackPush(obj->inStack, value);
}

int cQueueDeleteHead(CQueue* obj) {
    if (stackEmpty(obj->outStack)) {
        if (stackEmpty(obj->inStack)) {
            return -1;
        }
        in2out(obj);
    }
    int x = stackTop(obj->outStack);
    stackPop(obj->outStack);
    return x;
}

void cQueueFree(CQueue* obj) {
    stackFree(obj->inStack);
    stackFree(obj->outStack);
}
```

##### 复杂度分析

- 时间复杂度：$\texttt{appendTail}$ 为 $O(1)$，$\texttt{deleteHead}$ 为均摊 $O(1)$。对于每个元素，至多入栈和出栈各两次，故均摊复杂度为 $O(1)$。
- 空间复杂度：$O(n)$。其中 $n$ 是操作总数。对于有 $n$ 次 $\texttt{appendTail}$ 操作的情况，队列中会有 $n$ 个元素，故空间复杂度为 $O(n)$。
