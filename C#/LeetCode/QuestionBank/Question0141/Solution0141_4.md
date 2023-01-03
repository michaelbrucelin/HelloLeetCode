#### [������������ָ��](https://leetcode.cn/problems/linked-list-cycle/solutions/440042/huan-xing-lian-biao-by-leetcode-solution/)

**˼·���㷨**

��������Ҫ���߶ԡ�Floyd ��Ȧ�㷨�����ֳƹ��������㷨�������˽⡣

���롸�ڹ꡹�͡����ӡ����������ƶ��������ӡ��ܵÿ죬���ڹ꡹�ܵ����������ڹ꡹�͡����ӡ��������ϵ�ͬһ���ڵ㿪ʼ�ƶ�ʱ�������������û�л�����ô�����ӡ���һֱ���ڡ��ڹ꡹��ǰ����������������л�����ô�����ӡ������ڡ��ڹ꡹���뻷������һֱ�ڻ����ƶ����ȵ����ڹ꡹���뻷ʱ�����ڡ����ӡ����ٶȿ죬��һ������ĳ��ʱ�����ڹ������������ˡ��ڹ꡹����Ȧ��

���ǿ��Ը�������˼·��������⡣����أ����Ƕ�������ָ�룬һ��һ������ָ��ÿ��ֻ�ƶ�һ��������ָ��ÿ���ƶ���������ʼʱ����ָ����λ�� `head`������ָ����λ�� `head.next`������һ����������ƶ��Ĺ����У���ָ�뷴����׷����ָ�룬��˵��������Ϊ�������������ָ�뽫��������β����������Ϊ��������

![](./assets/img/Solution0141_4_01.png)
![](./assets/img/Solution0141_4_02.png)
![](./assets/img/Solution0141_4_03.png)
![](./assets/img/Solution0141_4_04.png)
![](./assets/img/Solution0141_4_05.png)

**ϸ��**

Ϊʲô����Ҫ�涨��ʼʱ��ָ����λ�� `head`����ָ����λ�� `head.next`������������ָ�붼��λ�� `head`�����롸�ڹ꡹�͡����ӡ��е�������ͬ����

-   �۲�����Ĵ��룬����ʹ�õ��� `while` ѭ����ѭ����������ѭ���塣����ѭ������һ�����жϿ���ָ���Ƿ��غϣ�������ǽ�����ָ���ʼ������ `head`����ô `while` ѭ���Ͳ���ִ�С���ˣ����ǿ��Լ���һ���� `head` ֮ǰ������ڵ㣬��ָ�������ڵ��ƶ�һ������ `head`����ָ�������ڵ��ƶ��������� `head.next`���������ǾͿ���ʹ�� `while` ѭ���ˡ�
-   ��Ȼ������Ҳ����ʹ�� `do-while` ѭ������ʱ�����ǾͿ��԰ѿ���ָ��ĳ�ʼֵ����Ϊ `head`��


**����**

```java
public class Solution {
    public boolean hasCycle(ListNode head) {
        if (head == null || head.next == null) {
            return false;
        }
        ListNode slow = head;
        ListNode fast = head.next;
        while (slow != fast) {
            if (fast == null || fast.next == null) {
                return false;
            }
            slow = slow.next;
            fast = fast.next.next;
        }
        return true;
    }
}
```

```cpp
class Solution {
public:
    bool hasCycle(ListNode* head) {
        if (head == nullptr || head->next == nullptr) {
            return false;
        }
        ListNode* slow = head;
        ListNode* fast = head->next;
        while (slow != fast) {
            if (fast == nullptr || fast->next == nullptr) {
                return false;
            }
            slow = slow->next;
            fast = fast->next->next;
        }
        return true;
    }
};
```

```python
class Solution:
    def hasCycle(self, head: ListNode) -> bool:
        if not head or not head.next:
            return False
        
        slow = head
        fast = head.next

        while slow != fast:
            if not fast or not fast.next:
                return False
            slow = slow.next
            fast = fast.next.next
        
        return True
```

```go
func hasCycle(head *ListNode) bool {
    if head == nil || head.Next == nil {
        return false
    }
    slow, fast := head, head.Next
    for fast != slow {
        if fast == nil || fast.Next == nil {
            return false
        }
        slow = slow.Next
        fast = fast.Next.Next
    }
    return true
}
```

```c
bool hasCycle(struct ListNode* head) {
    if (head == NULL || head->next == NULL) {
        return false;
    }
    struct ListNode* slow = head;
    struct ListNode* fast = head->next;
    while (slow != fast) {
        if (fast == NULL || fast->next == NULL) {
            return false;
        }
        slow = slow->next;
        fast = fast->next->next;
    }
    return true;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(N)$������ $N$ �������еĽڵ�����
    -   �������в����ڻ�ʱ����ָ�뽫������ָ�뵽������β����������ÿ���ڵ����౻�������Ρ�
    -   �������д��ڻ�ʱ��ÿһ���ƶ��󣬿���ָ��ľ��뽫��Сһ������ʼ����Ϊ���ĳ��ȣ���������ƶ� $N$ �֡�
-   �ռ临�Ӷȣ�$O(1)$������ֻʹ��������ָ��Ķ���ռ䡣
