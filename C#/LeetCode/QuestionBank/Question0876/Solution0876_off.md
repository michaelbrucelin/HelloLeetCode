### [链表的中间结点](https://leetcode.cn/problems/middle-of-the-linked-list/solutions/164351/lian-biao-de-zhong-jian-jie-dian-by-leetcode-solut/)

#### 方法一：数组

**思路和算法**

链表的缺点在于不能通过下标访问对应的元素。因此我们可以考虑对链表进行遍历，同时将遍历到的元素依次放入数组 `A` 中。如果我们遍历到了 `N` 个元素，那么链表以及数组的长度也为 `N`，对应的中间节点即为 `A[N/2]`。

```cpp
class Solution {
public:
    ListNode* middleNode(ListNode* head) {
        vector<ListNode*> A = {head};
        while (A.back()->next != NULL)
            A.push_back(A.back()->next);
        return A[A.size() / 2];
    }
};
```

```java
class Solution {
    public ListNode middleNode(ListNode head) {
        ListNode[] A = new ListNode[100];
        int t = 0;
        while (head != null) {
            A[t++] = head;
            head = head.next;
        }
        return A[t / 2];
    }
}
```

```python
class Solution:
    def middleNode(self, head: ListNode) -> ListNode:
        A = [head]
        while A[-1].next:
            A.append(A[-1].next)
        return A[len(A) // 2]
```

```javascript
var middleNode = function(head) {
    let A = [head];
    while (A[A.length - 1].next != null)
        A.push(A[A.length - 1].next);
    return A[Math.trunc(A.length / 2)];
};
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 是给定链表中的结点数目。
-   空间复杂度：$O(N)$，即数组 `A` 用去的空间。

#### 方法二：单指针法

我们可以对方法一进行空间优化，省去数组 `A`。

我们可以对链表进行两次遍历。第一次遍历时，我们统计链表中的元素个数 `N`；第二次遍历时，我们遍历到第 `N/2` 个元素（链表的首节点为第 `0` 个元素）时，将该元素返回即可。

```cpp
class Solution {
public:
    ListNode* middleNode(ListNode* head) {
        int n = 0;
        ListNode* cur = head;
        while (cur != nullptr) {
            ++n;
            cur = cur->next;
        }
        int k = 0;
        cur = head;
        while (k < n / 2) {
            ++k;
            cur = cur->next;
        }
        return cur;
    }
};
```

```java
class Solution {
    public ListNode middleNode(ListNode head) {
        int n = 0;
        ListNode cur = head;
        while (cur != null) {
            ++n;
            cur = cur.next;
        }
        int k = 0;
        cur = head;
        while (k < n / 2) {
            ++k;
            cur = cur.next;
        }
        return cur;
    }
}
```

```python
class Solution:
    def middleNode(self, head: ListNode) -> ListNode:
        n, cur = 0, head
        while cur:
            n += 1
            cur = cur.next
        k, cur = 0, head
        while k < n // 2:
            k += 1
            cur = cur.next
        return cur
```

```javascript
var middleNode = function(head) {
    n = 0;
    cur = head;
    while (cur != null) {
        ++n;
        cur = cur.next;
    }
    k = 0;
    cur = head;
    while (k < Math.trunc(n / 2)) {
        ++k;
        cur = cur.next;
    }
    return cur;
};
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 是给定链表的结点数目。
-   空间复杂度：$O(1)$，只需要常数空间存放变量和指针。

#### 方法三：快慢指针法

**思路和算法**

我们可以继续优化方法二，用两个指针 `slow` 与 `fast` 一起遍历链表。`slow` 一次走一步，`fast` 一次走两步。那么当 `fast` 到达链表的末尾时，`slow` 必然位于中间。

```cpp
class Solution {
public:
    ListNode* middleNode(ListNode* head) {
        ListNode* slow = head;
        ListNode* fast = head;
        while (fast != NULL && fast->next != NULL) {
            slow = slow->next;
            fast = fast->next->next;
        }
        return slow;
    }
};
```

```java
class Solution {
    public ListNode middleNode(ListNode head) {
        ListNode slow = head, fast = head;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }
}
```

```python
class Solution:
    def middleNode(self, head: ListNode) -> ListNode:
        slow = fast = head
        while fast and fast.next:
            slow = slow.next
            fast = fast.next.next
        return slow
```

```javascript
var middleNode = function(head) {
    slow = fast = head;
    while (fast && fast.next) {
        slow = slow.next;
        fast = fast.next.next;
    }
    return slow;
};
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 是给定链表的结点数目。
-   空间复杂度：$O(1)$，只需要常数空间存放 `slow` 和 `fast` 两个指针。
