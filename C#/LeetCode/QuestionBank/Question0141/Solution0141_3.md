#### [����һ����ϣ��](https://leetcode.cn/problems/linked-list-cycle/solutions/440042/huan-xing-lian-biao-by-leetcode-solution/)

**˼·���㷨**

�������뵽�ķ����Ǳ������нڵ㣬ÿ�α�����һ���ڵ�ʱ���жϸýڵ��ǰ�Ƿ񱻷��ʹ���

����أ����ǿ���ʹ�ù�ϣ�����洢�����Ѿ����ʹ��Ľڵ㡣ÿ�����ǵ���һ���ڵ㣬����ýڵ��Ѿ������ڹ�ϣ���У���˵���������ǻ�����������ͽ��ýڵ�����ϣ���С��ظ���һ���̣�ֱ�����Ǳ��������������ɡ�

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(N)$������ $N$ �������еĽڵ�����������������Ҫ����ÿ���ڵ�һ�Ρ�
-   �ռ临�Ӷȣ�$O(N)$������ $N$ �������еĽڵ�������ҪΪ��ϣ��Ŀ�����������������Ҫ��ÿ���ڵ���뵽��ϣ����һ�Ρ�
