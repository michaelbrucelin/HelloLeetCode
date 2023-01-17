#### [������������](https://leetcode.cn/problems/remove-linked-list-elements/solutions/813358/yi-chu-lian-biao-yuan-su-by-leetcode-sol-654m/)

Ҳ�����õ����ķ���ɾ�����������нڵ�ֵ�����ض�ֵ�Ľڵ㡣

�� $temp$ ��ʾ��ǰ�ڵ㡣��� $temp$ ����һ���ڵ㲻Ϊ������һ���ڵ�Ľڵ�ֵ���ڸ����� $val$������Ҫɾ����һ���ڵ㡣ɾ����һ���ڵ����ͨ����������ʵ�֣�

$$temp.next = temp.next.next$$

��� $temp$ ����һ���ڵ�Ľڵ�ֵ�����ڸ����� $val$��������һ���ڵ㣬�� $temp$ �ƶ�����һ���ڵ㼴�ɡ�

�� $temp$ ����һ���ڵ�Ϊ��ʱ�����������������ʱ���нڵ�ֵ���� $val$ �Ľڵ㶼��ɾ����

����ʵ�ַ��棬���������ͷ�ڵ� $head$ �п�����Ҫ��ɾ������˴����ƽڵ� $dummyHead$���� $dummyHead.next = head$����ʼ�� $temp = dummyHead$��Ȼ������������ɾ�����������շ��� $dummyHead.next$ ��Ϊɾ���������ͷ�ڵ㡣

```java
class Solution {
    public ListNode removeElements(ListNode head, int val) {
        ListNode dummyHead = new ListNode(0);
        dummyHead.next = head;
        ListNode temp = dummyHead;
        while (temp.next != null) {
            if (temp.next.val == val) {
                temp.next = temp.next.next;
            } else {
                temp = temp.next;
            }
        }
        return dummyHead.next;
    }
}
```

```csharp
public class Solution {
    public ListNode RemoveElements(ListNode head, int val) {
        ListNode dummyHead = new ListNode(0);
        dummyHead.next = head;
        ListNode temp = dummyHead;
        while (temp.next != null) {
            if (temp.next.val == val) {
                temp.next = temp.next.next;
            } else {
                temp = temp.next;
            }
        }
        return dummyHead.next;
    }
}
```

```javascript
var removeElements = function(head, val) {
    const dummyHead = new ListNode(0);
    dummyHead.next = head;
    let temp = dummyHead;
    while (temp.next !== null) {
        if (temp.next.val == val) {
            temp.next = temp.next.next;
        } else {
            temp = temp.next;
        }
    }
    return dummyHead.next;
};
```

```go
func removeElements(head *ListNode, val int) *ListNode {
    dummyHead := &ListNode{Next: head}
    for tmp := dummyHead; tmp.Next != nil; {
        if tmp.Next.Val == val {
            tmp.Next = tmp.Next.Next
        } else {
            tmp = tmp.Next
        }
    }
    return dummyHead.Next
}
```

```cpp
class Solution {
public:
    ListNode* removeElements(ListNode* head, int val) {
        struct ListNode* dummyHead = new ListNode(0, head);
        struct ListNode* temp = dummyHead;
        while (temp->next != NULL) {
            if (temp->next->val == val) {
                temp->next = temp->next->next;
            } else {
                temp = temp->next;
            }
        }
        return dummyHead->next;
    }
};
```

```c
struct ListNode* removeElements(struct ListNode* head, int val) {
    struct ListNode* dummyHead = malloc(sizeof(struct ListNode));
    dummyHead->next = head;
    struct ListNode* temp = dummyHead;
    while (temp->next != NULL) {
        if (temp->next->val == val) {
            temp->next = temp->next->next;
        } else {
            temp = temp->next;
        }
    }
    return dummyHead->next;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ������ĳ��ȡ���Ҫ��������һ�Ρ�
-   �ռ临�Ӷȣ�$O(1)$��
