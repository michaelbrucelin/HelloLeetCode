#### [方法一：递归](https://leetcode.cn/problems/remove-linked-list-elements/solutions/813358/yi-chu-lian-biao-yuan-su-by-leetcode-sol-654m/)

链表的定义具有递归的性质，因此链表题目常可以用递归的方法求解。这道题要求删除链表中所有节点值等于特定值的节点，可以用递归实现。

对于给定的链表，首先对除了头节点 $head$ 以外的节点进行删除操作，然后判断 $head$ 的节点值是否等于给定的 $val$。如果 $head$ 的节点值等于 $val$，则 $head$ 需要被删除，因此删除操作后的头节点为 $head.next$；如果 $head$ 的节点值不等于 $val$，则 $head$ 保留，因此删除操作后的头节点还是 $head$。上述过程是一个递归的过程。

递归的终止条件是 $head$ 为空，此时直接返回 $head$。当 $head$ 不为空时，递归地进行删除操作，然后判断 $head$ 的节点值是否等于 $val$ 并决定是否要删除 $head$。

```java
class Solution {
    public ListNode removeElements(ListNode head, int val) {
        if (head == null) {
            return head;
        }
        head.next = removeElements(head.next, val);
        return head.val == val ? head.next : head;
    }
}
```

```csharp
public class Solution {
    public ListNode RemoveElements(ListNode head, int val) {
        if (head == null) {
            return head;
        }
        head.next = RemoveElements(head.next, val);
        return head.val == val ? head.next : head;
    }
}
```

```javascript
var removeElements = function(head, val) {
    if (head === null) {
            return head;
        }
        head.next = removeElements(head.next, val);
        return head.val === val ? head.next : head;
};
```

```go
func removeElements(head *ListNode, val int) *ListNode {
    if head == nil {
        return head
    }
    head.Next = removeElements(head.Next, val)
    if head.Val == val {
        return head.Next
    }
    return head
}
```

```cpp
class Solution {
public:
    ListNode* removeElements(ListNode* head, int val) {
        if (head == nullptr) {
            return head;
        }
        head->next = removeElements(head->next, val);
        return head->val == val ? head->next : head;
    }
};
```

```c
struct ListNode* removeElements(struct ListNode* head, int val) {
    if (head == NULL) {
        return head;
    }
    head->next = removeElements(head->next, val);
    return head->val == val ? head->next : head;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是链表的长度。递归过程中需要遍历链表一次。
-   空间复杂度：$O(n)$，其中 $n$ 是链表的长度。空间复杂度主要取决于递归调用栈，最多不会超过 $n$ 层。
