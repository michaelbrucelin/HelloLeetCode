### [从链表中移除节点](https://leetcode.cn/problems/remove-nodes-from-linked-list/solutions/2587737/cong-lian-biao-zhong-yi-chu-jie-dian-by-z53sr/)

#### 方法一：递归
由题意可知，节点对它右侧的所有节点都没有影响，因此对于某一节点，我们可以对它的右侧节点递归地进行移除操作：

- 该节点为空，那么递归函数返回空指针。
- 该节点不为空，那么先对它的右侧节点进行移除操作，得到一个新的子链表，如果子链表的表头节点值大于该节点的值，那么移除该节点，否则将该节点作为子链表的表头节点，最后返回该子链表。

```c++
class Solution {
public:
    ListNode* removeNodes(ListNode* head) {
        if (head == nullptr) {
            return nullptr;
        }
        head->next = removeNodes(head->next);
        if (head->next != nullptr && head->val < head->next->val) {
            return head->next;
        } else {
            return head;
        }
    }
};
```

```java
class Solution {
    public ListNode removeNodes(ListNode head) {
        if (head == null) {
            return null;
        }
        head.next = removeNodes(head.next);
        if (head.next != null && head.val < head.next.val) {
            return head.next;
        } else {
            return head;
        }
    }
}
```

```csharp
public class Solution {
    public ListNode RemoveNodes(ListNode head) {
        if (head == null) {
            return null;
        }
        head.next = RemoveNodes(head.next);
        if (head.next != null && head.val < head.next.val) {
            return head.next;
        } else {
            return head;
        }
    }
}
```

```go
func removeNodes(head *ListNode) *ListNode {
    if head == nil {
        return nil
    }
    head.Next = removeNodes(head.Next)
    if (head.Next != nil && head.Val < head.Next.Val) {
        return head.Next
    } else {
        return head
    }
}
```

```python
class Solution:
    def removeNodes(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if head is None:
            return None
        head.next = self.removeNodes(head.next)
        if head.next is not None and head.val < head.next.val:
            return head.next
        else:
            return head
```

```c
struct ListNode *removeNodes(struct ListNode *head) {
    if (head == NULL) {
        return NULL;
    }
    head->next = removeNodes(head->next);
    if (head->next != NULL && head->val < head->next->val) {
        return head->next;
    } else {
        return head;
    }
}
```

```javascript
var removeNodes = function(head) {
    if (head == null) {
        return null;
    }
    head.next = removeNodes(head.next);
    if (head.next != null && head.val < head.next.val) {
        return head.next;
    } else {
        return head;
    }
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是链表节点个数。
- 空间复杂度：$O(n)$。

#### 方法二：栈

类似于方法一，我们可以用栈来模拟递归，具体为：

- 将所有链表节点按从左到右的顺序压入栈中，同时新链表初始为空。
- 不断地从栈中弹出节点，如果节点的值大于等于新链表的表头节点值，那么将该节点插入新链表的表头，否则移除该节点。

最后返回该链表。

```c++
class Solution {
public:
    ListNode* removeNodes(ListNode* head) {
        stack<ListNode *> st;
        for (; head != nullptr; head = head->next) {
            st.push(head);
        }
        for(; !st.empty(); st.pop()) {
            if (head == nullptr || st.top()->val >= head->val) {
                st.top()->next = head;
                head = st.top();
            }
        }
        return head;
    }
};
```

```java
class Solution {
    public ListNode removeNodes(ListNode head) {
        Deque<ListNode> stack = new ArrayDeque<ListNode>();
        for (; head != null; head = head.next) {
            stack.push(head);
        }
        for (; !stack.isEmpty(); stack.pop()) {
            if (head == null || stack.peek().val >= head.val) {
                stack.peek().next = head;
                head = stack.peek();
            }
        }
        return head;
    }
}
```

```csharp
public class Solution {
    public ListNode RemoveNodes(ListNode head) {
        Stack<ListNode> stack = new Stack<ListNode>();
        for (; head != null; head = head.next) {
            stack.Push(head);
        }
        for (; stack.Count > 0; stack.Pop()) {
            if (head == null || stack.Peek().val >= head.val) {
                stack.Peek().next = head;
                head = stack.Peek();
            }
        }
        return head;
    }
}
```

```go
func removeNodes(head *ListNode) *ListNode {
    var st []*ListNode
    for ; head != nil; head = head.Next {
        st = append(st, head)
    }
    for ; len(st) > 0; st = st[:len(st) - 1] {
        if head == nil || st[len(st) - 1].Val >= head.Val {
            st[len(st) - 1].Next = head
            head = st[len(st) - 1]
        }
    }
    return head
}
```

```python
class Solution:
    def removeNodes(self, head: Optional[ListNode]) -> Optional[ListNode]:
        st = []
        while head is not None:
            st.append(head)
            head = head.next
        while st:
            if head is None or st[-1].val >= head.val:
                st[-1].next = head
                head = st[-1]
            st.pop()
        return head
```

```c
int len(struct ListNode *head) {
    int n = 0;
    while (head != NULL) {
        n++;
        head = head->next;
    }
    return n;
}

struct ListNode *removeNodes(struct ListNode *head) {
    struct ListNode **st = (struct ListNode **)malloc(sizeof(struct ListNode *) * len(head));
    int top = -1;
    for (; head != NULL; head = head->next) {
        top++;
        st[top] = head;
    }
    for (; top >= 0; top--) {
        if (head == NULL || st[top]->val >= head->val) {
            st[top]->next = head;
            head = st[top];
        }
    }
    return head;
}
```

```javascript
var removeNodes = function(head) {
    let st = new Array();
    for (; head != null; head = head.next) {
        st.push(head);
    }
    for (; st.length > 0; st.pop()) {
        if (head == null || st[st.length - 1].val >= head.val) {
            st[st.length - 1].next = head;
            head = st[st.length - 1];
        }
    }
    return head;
};
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是链表节点个数。
- 空间复杂度：$O(n)$。

#### 方法三：反转链表

方法一和方法二都是从右到左进行移除，然后对于单链表来说，从左到右更高效，因此我们可以先对链表进行反转。问题转化为：给定一个链表，移除每一个左侧有一个更大数值的节点。

对于以上问题，我们可以从左到右对链表进行遍历，对于当前访问的节点：

- 不断地移除该节点的右侧节点，直到该节点的右侧节点值大于或等于该节点值。
- 访问下一节点。

最后对剩余的链表进行再一次反转，即为结果。

```c++
class Solution {
public:
    ListNode *reverse(ListNode *head) {
        ListNode dummy;
        while (head != nullptr) {
            ListNode *p = head;
            head = head->next;
            p->next = dummy.next;
            dummy.next = p;
        }
        return dummy.next;
    }

    ListNode* removeNodes(ListNode* head) {
        head = reverse(head);
        for (ListNode *p = head; p->next != nullptr; ) {
            if (p->val > p->next->val) {
                p->next = p->next->next;
            } else {
                p = p->next;
            }
        }
        return reverse(head);
    }
};
```

```java
class Solution {
    public ListNode removeNodes(ListNode head) {
        head = reverse(head);
        for (ListNode p = head; p.next != null; ) {
            if (p.val > p.next.val) {
                p.next = p.next.next;
            } else {
                p = p.next;
            }
        }
        return reverse(head);
    }

    public ListNode reverse(ListNode head) {
        ListNode dummy = new ListNode();
        while (head != null) {
            ListNode p = head;
            head = head.next;
            p.next = dummy.next;
            dummy.next = p;
        }
        return dummy.next;
    }
}
```

```csharp
public class Solution {
    public ListNode RemoveNodes(ListNode head) {
        head = Reverse(head);
        for (ListNode p = head; p.next != null; ) {
            if (p.val > p.next.val) {
                p.next = p.next.next;
            } else {
                p = p.next;
            }
        }
        return Reverse(head);
    }

    public ListNode Reverse(ListNode head) {
        ListNode dummy = new ListNode();
        while (head != null) {
            ListNode p = head;
            head = head.next;
            p.next = dummy.next;
            dummy.next = p;
        }
        return dummy.next;
    }
}
```

```go
func reverse(head *ListNode) *ListNode {
    dummy := &ListNode{}
    for head != nil {
        p := head
        head = head.Next
        p.Next = dummy.Next
        dummy.Next = p
    }
    return dummy.Next
}

func removeNodes(head *ListNode) *ListNode {
    head = reverse(head)
    for p := head; p.Next != nil; {
        if p.Val > p.Next.Val {
            p.Next = p.Next.Next
        } else {
            p = p.Next
        }
    }
    return reverse(head)
}
```

```python
class Solution:
    def reverse(self, head: Optional[ListNode]) -> Optional[ListNode]:
        dummy = ListNode()
        while head is not None:
            p = head
            head = head.next
            p.next = dummy.next
            dummy.next = p
        return dummy.next

    def removeNodes(self, head: Optional[ListNode]) -> Optional[ListNode]:
        head = self.reverse(head)
        p = head
        while p.next is not None:
            if p.val > p.next.val:
                p.next = p.next.next
            else:
                p = p.next
        return self.reverse(head)
```

```c
struct ListNode *reverse(struct ListNode *head) {
    struct ListNode dummy = {
        next:NULL
    };
    while (head != NULL) {
        struct ListNode *p = head;
        head = head->next;
        p->next = dummy.next;
        dummy.next = p;
    }
    return dummy.next;
}

struct ListNode *removeNodes(struct ListNode *head) {
    head = reverse(head);
    for (struct ListNode *p = head; p->next != NULL; ) {
        if (p->val > p->next->val) {
            p->next = p->next->next;
        } else {
            p = p->next;
        }
    }
    return reverse(head);
}
```

```javascript
var reverse = function(head) {
    let dummy = new ListNode();
    while (head != null) {
        let p = head;
        head = head.next;
        p.next = dummy.next;
        dummy.next = p;
    }
    return dummy.next;
};

var removeNodes = function(head) {
    head = reverse(head);
    for (let p = head; p.next != null; ) {
        if (p.val > p.next.val) {
            p.next = p.next.next;
        } else {
            p = p.next;
        }
    }
    return reverse(head);
};
```

复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是链表节点个数。
- 空间复杂度：$O(1)$。
