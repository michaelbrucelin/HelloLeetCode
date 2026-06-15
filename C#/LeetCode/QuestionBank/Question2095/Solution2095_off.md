### [删除链表的中间节点](https://leetcode.cn/problems/delete-the-middle-node-of-a-linked-list/solutions/1140770/shan-chu-lian-biao-de-zhong-jian-jie-dia-yvv7/)

#### 方法一：快慢指针

**思路与算法**

由于链表不支持随机访问，因此常见的找出链表中间节点的方法是使用快慢指针：即我们使用两个指针 $fast$ 和 $slow$ 对链表进行遍历，其中快指针 $fast$ 每次遍历两个元素，慢指针 $slow$ 每次遍历一个元素。这样在快指针遍历完链表时，慢指针就恰好在链表的中间位置。

在本题中，我们还需要删除链表的中间节点，因此除了慢指针 $slow$ 外，我们再使用一个指针 $pre$ 时刻指向 $slow$ 的前一个节点。这样我们就可以在遍历结束后，通过 $pre$ 将 $slow$ 删除了。

**细节**

当链表中只有一个节点时，我们会删除这个节点并返回空链表。但这个节点不存在前一个节点，即 $pre$ 是没有意义的，因此对于这种情况，我们可以在遍历前进行特殊判断，直接返回空指针作为答案。

**代码**

```C++
class Solution {
public:
    ListNode* deleteMiddle(ListNode* head) {
        if (head->next == nullptr) {
            return nullptr;
        }

        ListNode* slow = head;
        ListNode* fast = head;
        ListNode* pre = nullptr;
        while (fast && fast->next) {
            fast = fast->next->next;
            pre = slow;
            slow = slow->next;
        }
        pre->next = pre->next->next;
        return head;
    }
};
```

```Python
class Solution:
    def deleteMiddle(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if head.next is None:
            return None

        slow, fast, pre = head, head, None
        while fast and fast.next:
            fast = fast.next.next
            pre = slow
            slow = slow.next

        pre.next = pre.next.next
        return head
```

```Java
class Solution {
    public ListNode deleteMiddle(ListNode head) {
        if (head.next == null) {
            return null;
        }
        ListNode slow = head;
        ListNode fast = head;
        ListNode pre = null;

        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            pre = slow;
            slow = slow.next;
        }

        pre.next = pre.next.next;
        return head;
    }
}
```

```CSharp
public class Solution {
    public ListNode DeleteMiddle(ListNode head) {
        if (head.next == null) {
            return null;
        }

        ListNode slow = head;
        ListNode fast = head;
        ListNode pre = null;

        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            pre = slow;
            slow = slow.next;
        }

        pre.next = pre.next.next;
        return head;
    }
}
```

```Go
func deleteMiddle(head *ListNode) *ListNode {
    if head.Next == nil {
        return nil
    }
    slow := head
    fast := head
    var pre *ListNode

    for fast != nil && fast.Next != nil {
        fast = fast.Next.Next
        pre = slow
        slow = slow.Next
    }

    pre.Next = pre.Next.Next
    return head
}
```

```C
struct ListNode* deleteMiddle(struct ListNode* head) {
    if (head->next == NULL) {
        return NULL;
    }

    struct ListNode* slow = head;
    struct ListNode* fast = head;
    struct ListNode* pre = NULL;
    while (fast != NULL && fast->next != NULL) {
        fast = fast->next->next;
        pre = slow;
        slow = slow->next;
    }

    pre->next = pre->next->next;
    return head;
}
```

```JavaScript
var deleteMiddle = function(head) {
    if (head.next === null) {
        return null;
    }

    let slow = head;
    let fast = head;
    let pre = null;

    while (fast !== null && fast.next !== null) {
        fast = fast.next.next;
        pre = slow;
        slow = slow.next;
    }

    pre.next = pre.next.next;
    return head;
};
```

```TypeScript
function deleteMiddle(head: ListNode | null): ListNode | null {
    if (head === null || head.next === null) {
        return null;
    }

    let slow: ListNode | null = head;
    let fast: ListNode | null = head;
    let pre: ListNode | null = null;

    while (fast !== null && fast.next !== null) {
        fast = fast.next.next;
        pre = slow;
        slow = slow!.next;
    }

    if (pre !== null && pre.next !== null) {
        pre.next = pre.next.next;
    }

    return head;
}
```

```Rust
impl Solution {
    pub fn delete_middle(head: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
        if head.is_none() || head.as_ref()?.next.is_none() {
            return None;
        }

        let mut dummy = Some(Box::new(ListNode { val: 0, next: head }));
        let mut slow = &mut dummy as *mut Option<Box<ListNode>>;
        let mut fast = dummy.as_ref().unwrap().next.as_ref();
        while fast.is_some() && fast.unwrap().next.is_some() {
            fast = fast.unwrap().next.as_ref().unwrap().next.as_ref();
            unsafe {
                slow = &mut (*slow).as_mut().unwrap().next as *mut Option<Box<ListNode>>;
            }
        }

        unsafe {
            let next_next = (*slow).as_mut().unwrap().next.as_mut().unwrap().next.take();
            (*slow).as_mut().unwrap().next = next_next;
        }

        dummy.unwrap().next
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
