#### [方法一：哈希表](https://leetcode.cn/problems/linked-list-cycle/solutions/440042/huan-xing-lian-biao-by-leetcode-solution/)

**思路及算法**

最容易想到的方法是遍历所有节点，每次遍历到一个节点时，判断该节点此前是否被访问过。

具体地，我们可以使用哈希表来存储所有已经访问过的节点。每次我们到达一个节点，如果该节点已经存在于哈希表中，则说明该链表是环形链表，否则就将该节点加入哈希表中。重复这一过程，直到我们遍历完整个链表即可。

**代码**

```java
public class Solution {
    public boolean hasCycle(ListNode head) {
        Set<ListNode> seen = new HashSet<ListNode>();
        while (head != null) {
            if (!seen.add(head)) {
                return true;
            }
            head = head.next;
        }
        return false;
    }
}
```

```cpp
class Solution {
public:
    bool hasCycle(ListNode *head) {
        unordered_set<ListNode*> seen;
        while (head != nullptr) {
            if (seen.count(head)) {
                return true;
            }
            seen.insert(head);
            head = head->next;
        }
        return false;
    }
};
```

```python
class Solution:
    def hasCycle(self, head: ListNode) -> bool:
        seen = set()
        while head:
            if head in seen:
                return True
            seen.add(head)
            head = head.next
        return False
```

```go
func hasCycle(head *ListNode) bool {
    seen := map[*ListNode]struct{}{}
    for head != nil {
        if _, ok := seen[head]; ok {
            return true
        }
        seen[head] = struct{}{}
        head = head.Next
    }
    return false
}
```

```c
struct hashTable {
    struct ListNode* key;
    UT_hash_handle hh;
};

struct hashTable* hashtable;

struct hashTable* find(struct ListNode* ikey) {
    struct hashTable* tmp;
    HASH_FIND_PTR(hashtable, &ikey, tmp);
    return tmp;
}

void insert(struct ListNode* ikey) {
    struct hashTable* tmp = malloc(sizeof(struct hashTable));
    tmp->key = ikey;
    HASH_ADD_PTR(hashtable, key, tmp);
}

bool hasCycle(struct ListNode* head) {
    hashtable = NULL;
    while (head != NULL) {
        if (find(head) != NULL) {
            return true;
        }
        insert(head);
        head = head->next;
    }
    return false;
}
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 是链表中的节点数。最坏情况下我们需要遍历每个节点一次。
-   空间复杂度：$O(N)$，其中 $N$ 是链表中的节点数。主要为哈希表的开销，最坏情况下我们需要将每个节点插入到哈希表中一次。
