#### [������������ָ��](https://leetcode.cn/problems/palindrome-linked-list/solutions/457059/hui-wen-lian-biao-by-leetcode-solution/)

**˼·**

����ʹ�� O(n)O(n)O(n) ����ռ�ķ������Ǹı����롣

���ǿ��Խ�����ĺ�벿�ַ�ת���޸�����ṹ����Ȼ��ǰ�벿�ֺͺ�벿�ֽ��бȽϡ��Ƚ���ɺ�����Ӧ�ý�����ָ�ԭ������Ȼ����Ҫ�ָ�Ҳ��ͨ����������������ʹ�øú�������ͨ����ϣ������ṹ�����ġ�

�÷�����Ȼ���Խ��ռ临�ӶȽ��� O(1)O(1)O(1)�������ڲ��������£��÷���Ҳ��ȱ�㡣�ڲ��������£���������ʱ��Ҫ���������̻߳���̶�����ķ��ʣ���Ϊ�ں���ִ�й���������ᱻ�޸ġ�

**�㷨**

�������̿��Է�Ϊ����������裺

1.  �ҵ�ǰ�벿�������β�ڵ㡣
2.  ��ת��벿������
3.  �ж��Ƿ���ġ�
4.  �ָ�����
5.  ���ؽ����

ִ�в���һ�����ǿ��Լ�������ڵ��������Ȼ����������ҵ�ǰ�벿�ֵ�β�ڵ㡣

����Ҳ����ʹ��**����ָ��**��һ�α������ҵ�����ָ��һ����һ������ָ��һ��������������ָ��ͬʱ����������ָ���ƶ��������ĩβʱ����ָ��ǡ�õ�������м䡣ͨ����ָ�뽫�����Ϊ�����֡�

���������������ڵ㣬���м�Ľڵ�Ӧ�ÿ�����ǰ�벿�֡�

���������ʹ�á�[206\. ��ת����](https://leetcode-cn.com/problems/reverse-linked-list/)�������еĽ����������ת����ĺ�벿�֡�

�������Ƚ��������ֵ�ֵ������벿�ֵ���ĩβ��Ƚ���ɣ����Ժ��Լ�������е��м�ڵ㡣

�������벽���ʹ�õĺ�����ͬ���ٷ�תһ�λָ�������

**����**

```python
class Solution:

    def isPalindrome(self, head: ListNode) -> bool:
        if head is None:
            return True

        # �ҵ�ǰ�벿�������β�ڵ㲢��ת��벿������
        first_half_end = self.end_of_first_half(head)
        second_half_start = self.reverse_list(first_half_end.next)

        # �ж��Ƿ����
        result = True
        first_position = head
        second_position = second_half_start
        while result and second_position is not None:
            if first_position.val != second_position.val:
                result = False
            first_position = first_position.next
            second_position = second_position.next

        # ��ԭ�������ؽ��
        first_half_end.next = self.reverse_list(second_half_start)
        return result    

    def end_of_first_half(self, head):
        fast = head
        slow = head
        while fast.next is not None and fast.next.next is not None:
            fast = fast.next.next
            slow = slow.next
        return slow

    def reverse_list(self, head):
        previous = None
        current = head
        while current is not None:
            next_node = current.next
            current.next = previous
            previous = current
            current = next_node
        return previous
```

```java
class Solution {
    public boolean isPalindrome(ListNode head) {
        if (head == null) {
            return true;
        }

        // �ҵ�ǰ�벿�������β�ڵ㲢��ת��벿������
        ListNode firstHalfEnd = endOfFirstHalf(head);
        ListNode secondHalfStart = reverseList(firstHalfEnd.next);

        // �ж��Ƿ����
        ListNode p1 = head;
        ListNode p2 = secondHalfStart;
        boolean result = true;
        while (result && p2 != null) {
            if (p1.val != p2.val) {
                result = false;
            }
            p1 = p1.next;
            p2 = p2.next;
        }        

        // ��ԭ�������ؽ��
        firstHalfEnd.next = reverseList(secondHalfStart);
        return result;
    }

    private ListNode reverseList(ListNode head) {
        ListNode prev = null;
        ListNode curr = head;
        while (curr != null) {
            ListNode nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }
        return prev;
    }

    private ListNode endOfFirstHalf(ListNode head) {
        ListNode fast = head;
        ListNode slow = head;
        while (fast.next != null && fast.next.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }
        return slow;
    }
}
```

```cpp
class Solution {
public:
    bool isPalindrome(ListNode* head) {
        if (head == nullptr) {
            return true;
        }

        // �ҵ�ǰ�벿�������β�ڵ㲢��ת��벿������
        ListNode* firstHalfEnd = endOfFirstHalf(head);
        ListNode* secondHalfStart = reverseList(firstHalfEnd->next);

        // �ж��Ƿ����
        ListNode* p1 = head;
        ListNode* p2 = secondHalfStart;
        bool result = true;
        while (result && p2 != nullptr) {
            if (p1->val != p2->val) {
                result = false;
            }
            p1 = p1->next;
            p2 = p2->next;
        }        

        // ��ԭ�������ؽ��
        firstHalfEnd->next = reverseList(secondHalfStart);
        return result;
    }

    ListNode* reverseList(ListNode* head) {
        ListNode* prev = nullptr;
        ListNode* curr = head;
        while (curr != nullptr) {
            ListNode* nextTemp = curr->next;
            curr->next = prev;
            prev = curr;
            curr = nextTemp;
        }
        return prev;
    }

    ListNode* endOfFirstHalf(ListNode* head) {
        ListNode* fast = head;
        ListNode* slow = head;
        while (fast->next != nullptr && fast->next->next != nullptr) {
            fast = fast->next->next;
            slow = slow->next;
        }
        return slow;
    }
};
```

```javascript
const reverseList = (head) => {
    let prev = null;
    let curr = head;
    while (curr !== null) {
        let nextTemp = curr.next;
        curr.next = prev;
        prev = curr;
        curr = nextTemp;
    }
    return prev;
}

const endOfFirstHalf = (head) => {
    let fast = head;
    let slow = head;
    while (fast.next !== null && fast.next.next !== null) {
        fast = fast.next.next;
        slow = slow.next;
    }
    return slow;
}

var isPalindrome = function(head) {
    if (head == null) return true;

    // �ҵ�ǰ�벿�������β�ڵ㲢��ת��벿������
    const firstHalfEnd = endOfFirstHalf(head);
    const secondHalfStart = reverseList(firstHalfEnd.next);

    // �ж��Ƿ����
    let p1 = head;
    let p2 = secondHalfStart;
    let result = true;
    while (result && p2 != null) {
        if (p1.val != p2.val) result = false;
        p1 = p1.next;
        p2 = p2.next;
    }        

    // ��ԭ�������ؽ��
    firstHalfEnd.next = reverseList(secondHalfStart);
    return result;
};
```

```go
func reverseList(head *ListNode) *ListNode {
    var prev, cur *ListNode = nil, head
    for cur != nil {
        nextTmp := cur.Next
        cur.Next = prev
        prev = cur
        cur = nextTmp
    }
    return prev
}

func endOfFirstHalf(head *ListNode) *ListNode {
    fast := head
    slow := head
    for fast.Next != nil && fast.Next.Next != nil {
        fast = fast.Next.Next
        slow = slow.Next
    }
    return slow
}

func isPalindrome(head *ListNode) bool {
    if head == nil {
        return true
    }

    // �ҵ�ǰ�벿�������β�ڵ㲢��ת��벿������
    firstHalfEnd := endOfFirstHalf(head)
    secondHalfStart := reverseList(firstHalfEnd.Next)

    // �ж��Ƿ����
    p1 := head
    p2 := secondHalfStart
    result := true
    for result && p2 != nil {
        if p1.Val != p2.Val {
            result = false
        }
        p1 = p1.Next
        p2 = p2.Next
    }

    // ��ԭ�������ؽ��
    firstHalfEnd.Next = reverseList(secondHalfStart)
    return result
}
```

```c
struct ListNode* reverseList(struct ListNode* head) {
    struct ListNode* prev = NULL;
    struct ListNode* curr = head;
    while (curr != NULL) {
        struct ListNode* nextTemp = curr->next;
        curr->next = prev;
        prev = curr;
        curr = nextTemp;
    }
    return prev;
}

struct ListNode* endOfFirstHalf(struct ListNode* head) {
    struct ListNode* fast = head;
    struct ListNode* slow = head;
    while (fast->next != NULL && fast->next->next != NULL) {
        fast = fast->next->next;
        slow = slow->next;
    }
    return slow;
}

bool isPalindrome(struct ListNode* head) {
    if (head == NULL) {
        return true;
    }

    // �ҵ�ǰ�벿�������β�ڵ㲢��ת��벿������
    struct ListNode* firstHalfEnd = endOfFirstHalf(head);
    struct ListNode* secondHalfStart = reverseList(firstHalfEnd->next);

    // �ж��Ƿ����
    struct ListNode* p1 = head;
    struct ListNode* p2 = secondHalfStart;
    bool result = true;
    while (result && p2 != NULL) {
        if (p1->val != p2->val) {
            result = false;
        }
        p1 = p1->next;
        p2 = p2->next;
    }

    // ��ԭ�������ؽ��
    firstHalfEnd->next = reverseList(secondHalfStart);
    return result;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ָ��������Ĵ�С��
-   �ռ临�Ӷȣ�$O(1)$������ֻ���޸�ԭ�������нڵ��ָ�򣬶��ڶ�ջ�ϵĶ�ջ֡������ $O(1)$��
