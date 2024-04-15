### [训练计划 II](https://leetcode.cn/problems/lian-biao-zhong-dao-shu-di-kge-jie-dian-lcof/solutions/972458/lian-biao-zhong-dao-shu-di-kge-jie-dian-1pz9l/)

#### 方法一：顺序查找

##### 思路与算法

最简单直接的方法即为顺序查找，假设当前链表的长度为 $n$，则我们知道链表的倒数第 $cnt$ 个节点即为正数第 $n - cnt$ 个节点，此时我们只需要顺序遍历到链表的第 $n - cnt$ 个节点即为倒数第 $cnt$ 个节点。

- 我们首先求出链表的长度 $n$，然后顺序遍历到链表的第 $n - cnt$ 个节点返回即可。

##### 代码

```c++
class Solution {
public:
    ListNode* trainningPlan(ListNode* head, int cnt) {
        int n = 0;
        ListNode* node = nullptr;

        for (node = head; node; node = node->next) {
            n++;
        }
        for (node = head; n > cnt; n--) {
            node = node->next;
        }
      
        return node;
    }
};
```

```java
class Solution {
    public ListNode trainningPlan(ListNode head, int cnt) {
        int n = 0;
        ListNode node = null;

        for (node = head; node != null; node = node.next) {
            n++;
        }
        for (node = head; n > cnt; n--) {
            node = node.next;
        }

        return node;
    }
}
```

```csharp
public class Solution {
    public ListNode TrainningPlan(ListNode head, int cnt) {
        int n = 0;
        ListNode node = null;

        for (node = head; node != null; node = node.next) {
            n++;
        }
        for (node = head; n > cnt; n--) {
            node = node.next;
        }

        return node;
    }
}
```

```python
class Solution:
    def trainningPlan(self, head: ListNode, cnt: int) -> ListNode:
        node, n = head, 0  
        while node:
            node = node.next
            n += 1

        node = head
        for _ in range(n-cnt):
            node = node.next
        
        return node  
```

```javascript
var trainningPlan = function(head, cnt) {
    let node = head, n = 0;
    while (node) {
        node = node.next;
        n++;
    }
    node = head;
    for (let i = 0; i < n - cnt; i++) {
        node = node.next;
    }
    return node; 
};
```

```go
func trainningPlan(head *ListNode, cnt int) (kth *ListNode) {
    n := 0
    for node := head; node != nil; node = node.Next {
        n++
    }
    for kth = head; n > cnt; n-- {
        kth = kth.Next
    }
    return
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为链表的长度。需要两次遍历。
- 空间复杂度：$O(1)$。

#### 方法二：双指针

##### 思路与算法

快慢指针的思想。我们将第一个指针 $\textit{fast}$ 指向链表的第 $cnt + 1$ 个节点，第二个指针 $\textit{slow}$ 指向链表的第一个节点，此时指针 $\textit{fast}$ 与 $\textit{slow}$ 二者之间刚好间隔 $cnt$ 个节点。此时两个指针同步向后走，当第一个指针 $\textit{fast}$ 走到链表的尾部空节点时，则此时 $\textit{slow}$ 指针刚好指向链表的倒数第$cnt$个节点。

- 我们首先将 $\textit{fast}$ 指向链表的头节点，然后向后走 $cnt$ 步，则此时 $\textit{fast}$ 指针刚好指向链表的第 $cnt + 1$ 个节点。
- 我们首先将 $\textit{slow}$ 指向链表的头节点，同时 $\textit{slow}$ 与 $\textit{fast}$ 同步向后走，当 $\textit{fast}$ 指针指向链表的尾部空节点时，则此时返回 $\textit{slow}$ 所指向的节点即可。

##### 代码

```c++
class Solution {
public:
    ListNode* trainningPlan(ListNode* head, int cnt) {
        ListNode* fast = head;
        ListNode* slow = head;

        while (fast && cnt > 0) {
            fast = fast->next;
            cnt--;
        }
        while (fast) {
            fast = fast->next;
            slow = slow->next;
        }

        return slow;
    }
};
```

```java
class Solution {
    public ListNode trainningPlan(ListNode head, int cnt) {
        ListNode fast = head;
        ListNode slow = head;

        while (fast != null && cnt > 0) {
            fast = fast.next;
            cnt--;
        }
        while (fast != null) {
            fast = fast.next;
            slow = slow.next;
        }

        return slow;
    }
}
```

```csharp
public class Solution {
    public ListNode TrainningPlan(ListNode head, int cnt) {
        ListNode fast = head;
        ListNode slow = head;

        while (fast != null && cnt > 0) {
            fast = fast.next;
            cnt--;
        }
        while (fast != null) {
            fast = fast.next;
            slow = slow.next;
        }

        return slow;
    }
}
```

```python
class Solution:
    def trainningPlan(self, head: ListNode, cnt: int) -> ListNode:
        fast, slow = head, head

        while fast and cnt > 0:
            fast, cnt = fast.next, cnt - 1
        while fast:
            fast,slow = fast.next,slow.next
        
        return slow
```

```javascript
var trainningPlan = function(head, cnt) {
    let fast = head, slow = head;
    
    while (fast && cnt > 0) {
        [fast, cnt] = [fast.next, cnt - 1];
    }
    while (fast) {
        [fast, slow] = [fast.next, slow.next];
    }
    return slow;
};
```

```go
func trainningPlan(head *ListNode, cnt int) *ListNode {
    fast, slow := head, head
    for fast != nil && cnt > 0 {
        fast = fast.Next
        cnt--
    }
    for fast != nil {
        fast = fast.Next
        slow = slow.Next
    }
    return slow
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为链表的长度。我们使用快慢指针，只需要一次遍历即可，复杂度为 $O(n)$。
- 空间复杂度：$O(1)$。
