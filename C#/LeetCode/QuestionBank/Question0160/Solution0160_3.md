#### [����һ����ϣ����](https://leetcode.cn/problems/intersection-of-two-linked-lists/solutions/811625/xiang-jiao-lian-biao-by-leetcode-solutio-a8jn/)

**˼·���㷨**

�ж����������Ƿ��ཻ������ʹ�ù�ϣ���ϴ洢����ڵ㡣

���ȱ������� $headA$���������� $headA$ �е�ÿ���ڵ�����ϣ�����С�Ȼ��������� $headB$�����ڱ�������ÿ���ڵ㣬�жϸýڵ��Ƿ��ڹ�ϣ�����У�
-   �����ǰ�ڵ㲻�ڹ�ϣ�����У������������һ���ڵ㣻
-   �����ǰ�ڵ��ڹ�ϣ�����У������Ľڵ㶼�ڹ�ϣ�����У����ӵ�ǰ�ڵ㿪ʼ�����нڵ㶼������������ཻ���֣���������� $headB$ �б������ĵ�һ���ڹ�ϣ�����еĽڵ�������������ཻ�Ľڵ㣬���ظýڵ㡣

������� $headB$ �е����нڵ㶼���ڹ�ϣ�����У������������ཻ������ $null$��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(m+n)$������ $m$ �� $n$ �Ƿֱ������� $headA$ �� $headB$ �ĳ��ȡ���Ҫ�������������һ�Ρ�
-   �ռ临�Ӷȣ�$O(m)$������ $m$ ������ $headA$ �ĳ��ȡ���Ҫʹ�ù�ϣ���ϴ洢���� $headA$ �е�ȫ���ڵ㡣
