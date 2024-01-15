### [删除排序链表中的重复元素 II](https://leetcode.cn/problems/remove-duplicates-from-sorted-list-ii/solutions/678122/shan-chu-pai-xu-lian-biao-zhong-de-zhong-oayn/)

#### 方法一：一次遍历

##### 思路与算法

由于给定的链表是排好序的，因此**重复的元素在链表中出现的位置是连续的**，因此我们只需要对链表进行一次遍历，就可以删除重复的元素。由于链表的头节点可能会被删除，因此我们需要额外使用一个哑节点（dummy node）指向链表的头节点。

具体地，我们从指针 $cur$ 指向链表的哑节点，随后开始对链表进行遍历。如果当前 $cur.next$ 与 $cur.next.next$ 对应的元素相同，那么我们就需要将 $cur.next$ 以及所有后面拥有相同元素值的链表节点全部删除。我们记下这个元素值 $x$，随后不断将 $cur.next$ 从链表中移除，直到 $cur.next$ 为空节点或者其元素值不等于 $x$ 为止。此时，我们将链表中所有元素值为 $x$ 的节点全部删除。

如果当前 $cur.next$ 与 $cur.next.next$ 对应的元素不相同，那么说明链表中只有一个元素值为 $cur.next$ 的节点，那么我们就可以将 $cur$ 指向 $cur.next$。

当遍历完整个链表之后，我们返回链表的的哑节点的下一个节点 $dummy.next$ 即可。

##### 细节

需要注意 $cur.next$ 以及 $cur.next.next$ 可能为空节点，如果不加以判断，可能会产生运行错误。

##### 代码

注意下面 $C++$ 代码中并没有释放被删除的链表节点以及哑节点的空间。如果在面试中遇到本题，读者需要针对这一细节与面试官进行沟通。

```c++
class Solution {
public:
    ListNode* deleteDuplicates(ListNode* head) {
        if (!head) {
            return head;
        }
        
        ListNode* dummy = new ListNode(0, head);

        ListNode* cur = dummy;
        while (cur->next && cur->next->next) {
            if (cur->next->val == cur->next->next->val) {
                int x = cur->next->val;
                while (cur->next && cur->next->val == x) {
                    cur->next = cur->next->next;
                }
            }
            else {
                cur = cur->next;
            }
        }

        return dummy->next;
    }
};
```

```java
class Solution {
    public ListNode deleteDuplicates(ListNode head) {
        if (head == null) {
            return head;
        }
        
        ListNode dummy = new ListNode(0, head);

        ListNode cur = dummy;
        while (cur.next != null && cur.next.next != null) {
            if (cur.next.val == cur.next.next.val) {
                int x = cur.next.val;
                while (cur.next != null && cur.next.val == x) {
                    cur.next = cur.next.next;
                }
            } else {
                cur = cur.next;
            }
        }

        return dummy.next;
    }
}
```

```python
class Solution:
    def deleteDuplicates(self, head: ListNode) -> ListNode:
        if not head:
            return head
        
        dummy = ListNode(0, head)

        cur = dummy
        while cur.next and cur.next.next:
            if cur.next.val == cur.next.next.val:
                x = cur.next.val
                while cur.next and cur.next.val == x:
                    cur.next = cur.next.next
            else:
                cur = cur.next

        return dummy.next
```

```javascript
var deleteDuplicates = function(head) {
    if (!head) {
        return head;
    }

    const dummy = new ListNode(0, head);

    let cur = dummy;
    while (cur.next && cur.next.next) {
        if (cur.next.val === cur.next.next.val) {
            const x = cur.next.val;
            while (cur.next && cur.next.val === x) {
                cur.next = cur.next.next;
            } 
        } else {
            cur = cur.next;
        }
    }
    return dummy.next;
};
```

```go
func deleteDuplicates(head *ListNode) *ListNode {
    if head == nil {
        return nil
    }

    dummy := &ListNode{0, head}

    cur := dummy
    for cur.Next != nil && cur.Next.Next != nil {
        if cur.Next.Val == cur.Next.Next.Val {
            x := cur.Next.Val
            for cur.Next != nil && cur.Next.Val == x {
                cur.Next = cur.Next.Next
            }
        } else {
            cur = cur.Next
        }
    }

    return dummy.Next
}
```

```c
struct ListNode* deleteDuplicates(struct ListNode* head) {
    if (!head) {
        return head;
    }

    struct ListNode* dummy = malloc(sizeof(struct ListNode));
    dummy->next = head;

    struct ListNode* cur = dummy;
    while (cur->next && cur->next->next) {
        if (cur->next->val == cur->next->next->val) {
            int x = cur->next->val;
            while (cur->next && cur->next->val == x) {
                cur->next = cur->next->next;
            }
        } else {
            cur = cur->next;
        }
    }

    return dummy->next;
}
```

#### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是链表的长度。
- 空间复杂度：$O(1)$。
