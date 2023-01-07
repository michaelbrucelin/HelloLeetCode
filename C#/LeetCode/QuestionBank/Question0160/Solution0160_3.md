#### [方法一：哈希集合](https://leetcode.cn/problems/intersection-of-two-linked-lists/solutions/811625/xiang-jiao-lian-biao-by-leetcode-solutio-a8jn/)

**思路和算法**

判断两个链表是否相交，可以使用哈希集合存储链表节点。

首先遍历链表 $headA$，并将链表 $headA$ 中的每个节点加入哈希集合中。然后遍历链表 $headB$，对于遍历到的每个节点，判断该节点是否在哈希集合中：
-   如果当前节点不在哈希集合中，则继续遍历下一个节点；
-   如果当前节点在哈希集合中，则后面的节点都在哈希集合中，即从当前节点开始的所有节点都在两个链表的相交部分，因此在链表 $headB$ 中遍历到的第一个在哈希集合中的节点就是两个链表相交的节点，返回该节点。

如果链表 $headB$ 中的所有节点都不在哈希集合中，则两个链表不相交，返回 $null$。

**代码**

```java
public class Solution {
    public ListNode getIntersectionNode(ListNode headA, ListNode headB) {
        Set<ListNode> visited = new HashSet<ListNode>();
        ListNode temp = headA;
        while (temp != null) {
            visited.add(temp);
            temp = temp.next;
        }
        temp = headB;
        while (temp != null) {
            if (visited.contains(temp)) {
                return temp;
            }
            temp = temp.next;
        }
        return null;
    }
}
```

```csharp
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        ISet<ListNode> visited = new HashSet<ListNode>();
        ListNode temp = headA;
        while (temp != null) {
            visited.Add(temp);
            temp = temp.next;
        }
        temp = headB;
        while (temp != null) {
            if (visited.Contains(temp)) {
                return temp;
            }
            temp = temp.next;
        }
        return null;
    }
}
```

```javascript
var getIntersectionNode = function(headA, headB) {
    const visited = new Set();
    let temp = headA;
    while (temp !== null) {
        visited.add(temp);
        temp = temp.next;
    }
    temp = headB;
    while (temp !== null) {
        if (visited.has(temp)) {
            return temp;
        }
        temp = temp.next;
    }
    return null;
};
```

```go
func getIntersectionNode(headA, headB *ListNode) *ListNode {
    vis := map[*ListNode]bool{}
    for tmp := headA; tmp != nil; tmp = tmp.Next {
        vis[tmp] = true
    }
    for tmp := headB; tmp != nil; tmp = tmp.Next {
        if vis[tmp] {
            return tmp
        }
    }
    return nil
}
```

```cpp
class Solution {
public:
    ListNode *getIntersectionNode(ListNode *headA, ListNode *headB) {
        unordered_set<ListNode *> visited;
        ListNode *temp = headA;
        while (temp != nullptr) {
            visited.insert(temp);
            temp = temp->next;
        }
        temp = headB;
        while (temp != nullptr) {
            if (visited.count(temp)) {
                return temp;
            }
            temp = temp->next;
        }
        return nullptr;
    }
};
```

```c
struct HashTable {
    struct ListNode *key;
    UT_hash_handle hh;
};

struct ListNode *getIntersectionNode(struct ListNode *headA, struct ListNode *headB) {
    struct HashTable *hashTable = NULL;
    struct ListNode *temp = headA;
    while (temp != NULL) {
        struct HashTable *tmp;
        HASH_FIND(hh, hashTable, &temp, sizeof(struct HashTable *), tmp);
        if (tmp == NULL) {
            tmp = malloc(sizeof(struct HashTable));
            tmp->key = temp;
            HASH_ADD(hh, hashTable, key, sizeof(struct HashTable *), tmp);
        }
        temp = temp->next;
    }
    temp = headB;
    while (temp != NULL) {
        struct HashTable *tmp;
        HASH_FIND(hh, hashTable, &temp, sizeof(struct HashTable *), tmp);
        if (tmp != NULL) {
            return temp;
        }
        temp = temp->next;
    }
    return NULL;
}
```

**复杂度分析**

-   时间复杂度：$O(m+n)$，其中 $m$ 和 $n$ 是分别是链表 $headA$ 和 $headB$ 的长度。需要遍历两个链表各一次。
-   空间复杂度：$O(m)$，其中 $m$ 是链表 $headA$ 的长度。需要使用哈希集合存储链表 $headA$ 中的全部节点。
