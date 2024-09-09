### [合并零之间的节点](https://leetcode.cn/problems/merge-nodes-in-between-zeros/solutions/1301107/he-bing-ling-zhi-jian-de-jie-dian-by-lee-zo9b/)

#### 方法一：模拟

**思路与算法**

我们从链表头节点 $head$ 的下一个节点开始遍历，并使用一个变量 $total$ 维护当前遍历到的节点的元素之和。

如果当前节点的值为 $0$，那么我们就新建一个值为 $total$ 的节点，放在答案链表的尾部，并将 $total$ 置零，否则我们将值累加进 $total$ 中。

**细节**

为了方便维护答案，我们可以在遍历前新建一个伪头节点 $dummy$，并在遍历完成之后返回 $dummy$ 的下一个节点作为答案。

**代码**

下面给出的 $C++$ 代码中没有释放 $dummy$ 节点的空间。如果在面试中遇到本题，需要和面试官进行沟通。

```C++
class Solution {
public:
    ListNode* mergeNodes(ListNode* head) {
        ListNode* dummy = new ListNode();
        ListNode* tail = dummy;
        
        int total = 0;
        for (ListNode* cur = head->next; cur; cur = cur->next) {
            if (cur->val == 0) {
                ListNode* node = new ListNode(total);
                tail->next = node;
                tail = tail->next;
                total = 0;
            }
            else {
                total += cur->val;
            }
        }
        
        return dummy->next;
    }
};
```

```Java
class Solution {
    public ListNode mergeNodes(ListNode head) {
        ListNode dummy = new ListNode();
        ListNode tail = dummy;
        int total = 0;
        for (ListNode cur = head.next; cur != null; cur = cur.next) {
            if (cur.val == 0) {
                ListNode node = new ListNode(total);
                tail.next = node;
                tail = tail.next;
                total = 0;
            } else {
                total += cur.val;
            }
        }
        
        return dummy.next;
    }
}
```

```Python
class Solution:
    def mergeNodes(self, head: Optional[ListNode]) -> Optional[ListNode]:
        dummy = tail = ListNode()
        total = 0
        cur = head.next

        while cur:
            if cur.val == 0:
                node = ListNode(total)
                tail.next = node
                tail = tail.next
                total = 0
            else:
                total += cur.val
            
            cur = cur.next
        
        return dummy.next
```

```C
struct ListNode* creatListNode(int val) {
    struct ListNode* obj = (struct ListNode*)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

struct ListNode* mergeNodes(struct ListNode* head){
    struct ListNode* dummy = creatListNode(0);
    struct ListNode* tail = dummy;
    
    int total = 0;
    for (struct ListNode* cur = head->next; cur; cur = cur->next) {
        if (cur->val == 0) {
            struct ListNode* node = creatListNode(total);
            tail->next = node;
            tail = tail->next;
            total = 0;
        } else {
            total += cur->val;
        }
    }
    return dummy->next;
}
```

```Go
func mergeNodes(head *ListNode) *ListNode {
    dummy := &ListNode{}
    tail := dummy
    total := 0
    for cur := head.Next; cur != nil; cur = cur.Next {
        if cur.Val == 0 {
            node := &ListNode{Val: total}
            tail.Next = node
            tail = tail.Next
            total = 0
        } else {
            total += cur.Val
        }
    }
    return dummy.Next
}
```

```JavaScript
var mergeNodes = function(head) {
    const dummy = new ListNode();
    let tail = dummy;
    let total = 0;
    for (let cur = head.next; cur !== null; cur = cur.next) {
        if (cur.val === 0) {
            const node = new ListNode(total);
            tail.next = node;
            tail = tail.next;
            total = 0;
        } else {
            total += cur.val;
        }
    }

    return dummy.next;
};
```

```TypeScript
function mergeNodes(head: ListNode | null): ListNode | null {
    const dummy = new ListNode();
    let tail = dummy;
    let total = 0;
    for (let cur = head.next; cur !== null; cur = cur.next) {
        if (cur.val === 0) {
            const node = new ListNode(total);
            tail.next = node;
            tail = tail.next;
            total = 0;
        } else {
            total += cur.val;
        }
    }

    return dummy.next;
};
```

```Rust
impl Solution {
    pub fn merge_nodes(head: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
        let mut dummy = Box::new(ListNode::new(0));
        let mut tail = &mut dummy;
        let mut total = 0;
        let mut cur = head.unwrap().next;
        while let Some(mut node) = cur {
            if node.val == 0 {
                tail.next = Some(Box::new(ListNode::new(total)));
                tail = tail.next.as_mut().unwrap();
                total = 0;
            } else {
                total += node.val;
            }
            cur = node.next.take();
        }

        dummy.next
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是给定链表的长度。
- 空间复杂度：$O(1)$。
