#### [����һ���ݹ�](https://leetcode.cn/problems/remove-linked-list-elements/solutions/813358/yi-chu-lian-biao-yuan-su-by-leetcode-sol-654m/)

����Ķ�����еݹ�����ʣ����������Ŀ�������õݹ�ķ�����⡣�����Ҫ��ɾ�����������нڵ�ֵ�����ض�ֵ�Ľڵ㣬�����õݹ�ʵ�֡�

���ڸ������������ȶԳ���ͷ�ڵ� $head$ ����Ľڵ����ɾ��������Ȼ���ж� $head$ �Ľڵ�ֵ�Ƿ���ڸ����� $val$����� $head$ �Ľڵ�ֵ���� $val$���� $head$ ��Ҫ��ɾ�������ɾ���������ͷ�ڵ�Ϊ $head.next$����� $head$ �Ľڵ�ֵ������ $val$���� $head$ ���������ɾ���������ͷ�ڵ㻹�� $head$������������һ���ݹ�Ĺ��̡�

�ݹ����ֹ������ $head$ Ϊ�գ���ʱֱ�ӷ��� $head$���� $head$ ��Ϊ��ʱ���ݹ�ؽ���ɾ��������Ȼ���ж� $head$ �Ľڵ�ֵ�Ƿ���� $val$ �������Ƿ�Ҫɾ�� $head$��

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ������ĳ��ȡ��ݹ��������Ҫ��������һ�Ρ�
-   �ռ临�Ӷȣ�$O(n)$������ $n$ ������ĳ��ȡ��ռ临�Ӷ���Ҫȡ���ڵݹ����ջ����಻�ᳬ�� $n$ �㡣
