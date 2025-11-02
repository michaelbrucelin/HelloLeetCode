### [从链表中移除在数组中存在的节点](https://leetcode.cn/problems/delete-nodes-from-linked-list-present-in-array/solutions/3812472/cong-lian-biao-zhong-yi-chu-zai-shu-zu-z-d25m)

#### 方法一：哈希表 + 哨兵节点

**思路及解法**

首先将数组中的元素存入哈希表中，由于链表的头节点可能被移除，为了简化代码逻辑，我们在头节点之前添加一个哨兵节点。

从哨兵节点的下一位（即头节点）开始遍历链表，如果当前节点的值存在于哈希表中，则将当前节点移除，否则继续遍历，直到链表遍历完成。

**代码**

```C++
class Solution {
public:
    ListNode* modifiedList(vector<int>& nums, ListNode* head) {
        unordered_map<int, int> isExist;
        for (int num : nums) {
            isExist[num] = 1;
        }
        ListNode sentry(0, head);
        ListNode* p = &sentry;
        while (p->next) {
            if (isExist[p->next->val]) {
                p->next = p->next->next;
            } else {
                p = p->next;
            }
        }
        return sentry.next;
    }
};
```

```Java
public class Solution {
    public ListNode modifiedList(int[] nums, ListNode head) {
        Set<Integer> numSet = new HashSet<>();
        for (int num : nums) {
            numSet.add(num);
        }
        ListNode sentry = new ListNode(0, head);
        ListNode p = sentry;
        while (p.next != null) {
            if (numSet.contains(p.next.val)) {
                p.next = p.next.next;
            } else {
                p = p.next;
            }
        }
        return sentry.next;
    }
}
```

```Python
class Solution:
    def modifiedList(self, nums: List[int], head: Optional[ListNode]) -> Optional[ListNode]:
        num_set = set(nums)
        sentry = ListNode(0, head)
        p = sentry
        while p.next is not None:
            if p.next.val in num_set:
                p.next = p.next.next
            else:
                p = p.next
        return sentry.next
```

```CSharp
public class Solution {
    public ListNode ModifiedList(int[] nums, ListNode head) {
        HashSet<int> isExist = new HashSet<int>(nums);
        ListNode sentry = new ListNode(0, head);
        ListNode p = sentry;

        while (p.next != null) {
            if (isExist.Contains(p.next.val)) {
                p.next = p.next.next;
            } else {
                p = p.next;
            }
        }
        return sentry.next;
    }
}
```

```Go
func modifiedList(nums []int, head *ListNode) *ListNode {
    isExist := make(map[int]bool)
    for _, num := range nums {
        isExist[num] = true
    }

    sentry := &ListNode{Next: head}
    p := sentry
    for p.Next != nil {
        if isExist[p.Next.Val] {
            p.Next = p.Next.Next
        } else {
            p = p.Next
        }
    }
    return sentry.Next
}
```

```C
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

struct ListNode* modifiedList(int* nums, int numsSize, struct ListNode* head) {
    HashItem *isExist = NULL;
    for (int i = 0; i < numsSize; i++) {
        hashAddItem(&isExist, nums[i]);
    }

    struct ListNode* sentry = (struct ListNode*)malloc(sizeof(struct ListNode));
    sentry->val = 0;
    sentry->next = head;
    struct ListNode* p = sentry;
    while (p->next) {
        if (hashFindItem(&isExist, p->next->val)) {
            p->next = p->next->next;
        } else {
            p = p->next;
        }
    }
    hashFree(&isExist);
    return sentry->next;
}
```

```JavaScript
var modifiedList = function(nums, head) {
    const isExist = new Set(nums);
    const sentry = new ListNode(0, head);
    let p = sentry;

    while (p.next) {
        if (isExist.has(p.next.val)) {
            p.next = p.next.next;
        } else {
            p = p.next;
        }
    }
    return sentry.next;
};
```

```TypeScript
function modifiedList(nums: number[], head: ListNode | null): ListNode | null {
    const isExist: Set<number> = new Set(nums);
    const sentry: ListNode = new ListNode(0, head);
    let p: ListNode | null = sentry;

    while (p && p.next) {
        if (isExist.has(p.next.val)) {
            p.next = p.next.next;
        } else {
            p = p.next;
        }
    }
    return sentry.next;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn modified_list(nums: Vec<i32>, head: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
        let is_exist: HashSet<i32> = nums.into_iter().collect();
        let mut sentry = Box::new(ListNode::new(0));
        sentry.next = head;

        let mut p = &mut sentry;
        while let Some(ref mut next_node) = p.next {
            if is_exist.contains(&next_node.val) {
                p.next = next_node.next.take();
            } else {
                p = p.next.as_mut().unwrap();
            }
        }

        sentry.next
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 为数组的长度，$m$ 为链表的长度。
- 空间复杂度：$O(n)$，使用哈希表保存数组中的元素，其中 $n$ 为数组的长度。
