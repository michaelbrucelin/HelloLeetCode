#### [方法二：双指针](https://leetcode.cn/problems/liang-ge-lian-biao-de-di-yi-ge-gong-gong-jie-dian-lcof/solutions/883382/liang-ge-lian-biao-de-di-yi-ge-gong-gong-pzbs/)

**思路和算法**

使用双指针的方法，可以将空间复杂度降至 $O(1)$。

只有当链表 $headA$ 和 $headB$ 都不为空时，两个链表才可能相交。因此首先判断链表 $headA$ 和 $headB$ 是否为空，如果其中至少有一个链表为空，则两个链表一定不相交，返回 $null$。

当链表 $headA$ 和 $headB$ 都不为空时，创建两个指针 $pA$ 和 $pB$，初始时分别指向两个链表的头节点 $headA$ 和 $headB$，然后将两个指针依次遍历两个链表的每个节点。具体做法如下：

-   每步操作需要同时更新指针 $pA$ 和 $pB$。
-   如果指针 $pA$ 不为空，则将指针 $pA$ 移到下一个节点；如果指针 $pB$ 不为空，则将指针 $pB$ 移到下一个节点。
-   如果指针 $pA$ 为空，则将指针 $pA$ 移到链表 $headB$ 的头节点；如果指针 $pB$ 为空，则将指针 $pB$ 移到链表 $headA$ 的头节点。
-   当指针 $pA$ 和 $pB$ 指向同一个节点或者都为空时，返回它们指向的节点或者 $null$。

**证明**

下面提供双指针方法的正确性证明。考虑两种情况，第一种情况是两个链表相交，第二种情况是两个链表不相交。

情况一：两个链表相交

链表 $headA$ 和 $headB$ 的长度分别是 $m$ 和 $n$。假设链表 $headA$ 的不相交部分有 $a$ 个节点，链表 $headB$ 的不相交部分有 $b$ 个节点，两个链表相交的部分有 $c$ 个节点，则有 $a+c=m$，$b+c=n$。

-   如果 $a=b$，则两个指针会同时到达两个链表的第一个公共节点，此时返回两个链表的第一个公共节点；
-   如果 $a \ne b$，则指针 $pA$ 会遍历完链表 $headA$，指针 $pB$ 会遍历完链表 $headB$，两个指针不会同时到达链表的尾节点，然后指针 $pA$ 移到链表 $headB$ 的头节点，指针 $pB$ 移到链表 $headA$ 的头节点，然后两个指针继续移动，在指针 $pA$ 移动了 $a+c+b$ 次、指针 $pB$ 移动了 $b+c+a$ 次之后，两个指针会同时到达两个链表的第一个公共节点，该节点也是两个指针第一次同时指向的节点，此时返回两个链表的第一个公共节点。

情况二：两个链表不相交

链表 $headA$ 和 $headB$ 的长度分别是 $m$ 和 $n$。考虑当 $m=n$ 和 $m \ne n$ 时，两个指针分别会如何移动：

-   如果 $m=n$，则两个指针会同时到达两个链表的尾节点，然后同时变成空值 $null$，此时返回 $null$；
-   如果 $m \ne n$，则由于两个链表没有公共节点，两个指针也不会同时到达两个链表的尾节点，因此两个指针都会遍历完两个链表，在指针 $pA$ 移动了 $m+n$ 次、指针 $pB$ 移动了 $n+m$ 次之后，两个指针会同时变成空值 $null$，此时返回 $null$。

**代码**

```java
public class Solution {
    public ListNode getIntersectionNode(ListNode headA, ListNode headB) {
        if (headA == null || headB == null) {
            return null;
        }
        ListNode pA = headA, pB = headB;
        while (pA != pB) {
            pA = pA == null ? headB : pA.next;
            pB = pB == null ? headA : pB.next;
        }
        return pA;
    }
}
```

```csharp
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        if (headA == null || headB == null) {
            return null;
        }
        ListNode pA = headA, pB = headB;
        while (pA != pB) {
            pA = pA == null ? headB : pA.next;
            pB = pB == null ? headA : pB.next;
        }
        return pA;
    }
}
```

```javascript
var getIntersectionNode = function(headA, headB) {
    if (headA === null || headB === null) {
        return null;
    }
    let pA = headA, pB = headB;
    while (pA !== pB) {
        pA = pA === null ? headB : pA.next;
        pB = pB === null ? headA : pB.next;
    }
    return pA;
};
```

```go
func getIntersectionNode(headA, headB *ListNode) *ListNode {
    if headA == nil || headB == nil {
        return nil
    }
    pa, pb := headA, headB
    for pa != pb {
        if pa == nil {
            pa = headB
        } else {
            pa = pa.Next
        }
        if pb == nil {
            pb = headA
        } else {
            pb = pb.Next
        }
    }
    return pa
}
```

```cpp
class Solution {
public:
    ListNode *getIntersectionNode(ListNode *headA, ListNode *headB) {
        if (headA == nullptr || headB == nullptr) {
            return nullptr;
        }
        ListNode *pA = headA, *pB = headB;
        while (pA != pB) {
            pA = pA == nullptr ? headB : pA->next;
            pB = pB == nullptr ? headA : pB->next;
        }
        return pA;
    }
};
```

```c
struct ListNode *getIntersectionNode(struct ListNode *headA, struct ListNode *headB) {
    if (headA == NULL || headB == NULL) {
        return NULL;
    }
    struct ListNode *pA = headA, *pB = headB;
    while (pA != pB) {
        pA = pA == NULL ? headB : pA->next;
        pB = pB == NULL ? headA : pB->next;
    }
    return pA;
}
```

**复杂度分析**

-   时间复杂度：$O(m+n)$，其中 $m$ 和 $n$ 是分别是链表 $headA$ 和 $headB$ 的长度。两个指针同时遍历两个链表，每个指针遍历两个链表各一次。
-   空间复杂度：$O(1)$。
