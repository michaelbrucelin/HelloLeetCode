#### [��������˫ָ��](https://leetcode.cn/problems/liang-ge-lian-biao-de-di-yi-ge-gong-gong-jie-dian-lcof/solutions/883382/liang-ge-lian-biao-de-di-yi-ge-gong-gong-pzbs/)

**˼·���㷨**

ʹ��˫ָ��ķ��������Խ��ռ临�ӶȽ��� $O(1)$��

ֻ�е����� $headA$ �� $headB$ ����Ϊ��ʱ����������ſ����ཻ����������ж����� $headA$ �� $headB$ �Ƿ�Ϊ�գ��������������һ������Ϊ�գ�����������һ�����ཻ������ $null$��

������ $headA$ �� $headB$ ����Ϊ��ʱ����������ָ�� $pA$ �� $pB$����ʼʱ�ֱ�ָ�����������ͷ�ڵ� $headA$ �� $headB$��Ȼ������ָ�����α������������ÿ���ڵ㡣�����������£�

-   ÿ��������Ҫͬʱ����ָ�� $pA$ �� $pB$��
-   ���ָ�� $pA$ ��Ϊ�գ���ָ�� $pA$ �Ƶ���һ���ڵ㣻���ָ�� $pB$ ��Ϊ�գ���ָ�� $pB$ �Ƶ���һ���ڵ㡣
-   ���ָ�� $pA$ Ϊ�գ���ָ�� $pA$ �Ƶ����� $headB$ ��ͷ�ڵ㣻���ָ�� $pB$ Ϊ�գ���ָ�� $pB$ �Ƶ����� $headA$ ��ͷ�ڵ㡣
-   ��ָ�� $pA$ �� $pB$ ָ��ͬһ���ڵ���߶�Ϊ��ʱ����������ָ��Ľڵ���� $null$��

**֤��**

�����ṩ˫ָ�뷽������ȷ��֤�������������������һ����������������ཻ���ڶ�����������������ཻ��

���һ�����������ཻ

���� $headA$ �� $headB$ �ĳ��ȷֱ��� $m$ �� $n$���������� $headA$ �Ĳ��ཻ������ $a$ ���ڵ㣬���� $headB$ �Ĳ��ཻ������ $b$ ���ڵ㣬���������ཻ�Ĳ����� $c$ ���ڵ㣬���� $a+c=m$��$b+c=n$��

-   ��� $a=b$��������ָ���ͬʱ������������ĵ�һ�������ڵ㣬��ʱ������������ĵ�һ�������ڵ㣻
-   ��� $a \ne b$����ָ�� $pA$ ����������� $headA$��ָ�� $pB$ ����������� $headB$������ָ�벻��ͬʱ���������β�ڵ㣬Ȼ��ָ�� $pA$ �Ƶ����� $headB$ ��ͷ�ڵ㣬ָ�� $pB$ �Ƶ����� $headA$ ��ͷ�ڵ㣬Ȼ������ָ������ƶ�����ָ�� $pA$ �ƶ��� $a+c+b$ �Ρ�ָ�� $pB$ �ƶ��� $b+c+a$ ��֮������ָ���ͬʱ������������ĵ�һ�������ڵ㣬�ýڵ�Ҳ������ָ���һ��ͬʱָ��Ľڵ㣬��ʱ������������ĵ�һ�������ڵ㡣

����������������ཻ

���� $headA$ �� $headB$ �ĳ��ȷֱ��� $m$ �� $n$�����ǵ� $m=n$ �� $m \ne n$ ʱ������ָ��ֱ������ƶ���

-   ��� $m=n$��������ָ���ͬʱ�������������β�ڵ㣬Ȼ��ͬʱ��ɿ�ֵ $null$����ʱ���� $null$��
-   ��� $m \ne n$����������������û�й����ڵ㣬����ָ��Ҳ����ͬʱ�������������β�ڵ㣬�������ָ�붼�����������������ָ�� $pA$ �ƶ��� $m+n$ �Ρ�ָ�� $pB$ �ƶ��� $n+m$ ��֮������ָ���ͬʱ��ɿ�ֵ $null$����ʱ���� $null$��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(m+n)$������ $m$ �� $n$ �Ƿֱ������� $headA$ �� $headB$ �ĳ��ȡ�����ָ��ͬʱ������������ÿ��ָ��������������һ�Ρ�
-   �ռ临�Ӷȣ�$O(1)$��
