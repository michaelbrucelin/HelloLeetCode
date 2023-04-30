#### [������������������� + ��ϣ��](https://leetcode.cn/problems/two-sum-iv-input-is-a-bst/solutions/1347526/liang-shu-zhi-he-iv-shu-ru-bst-by-leetco-b4nl/)

**˼·���㷨**

���ǿ���ʹ�ù�����������ķ�ʽ�������������ù�ϣ���¼�������Ľڵ��ֵ��

����أ��������ȴ���һ����ϣ���һ�����У������ڵ��������У�Ȼ��ִ�����²��裺

1.  �Ӷ�����ȡ����ͷ��������ֵΪ $x$��
2.  ����ϣ�����Ƿ���� $k - x$��������ڣ����� $True$��
3.  ���򣬽��ýڵ�����ҵķǿ��ӽڵ�����β��
4.  �ظ����ϲ��裬ֱ������Ϊ�գ�
5.  �������Ϊ�գ�˵�����ϲ�����������Ϊ $k$ �Ľڵ㣬���� $False$��

**����**

```python
class Solution:
    def findTarget(self, root: Optional[TreeNode], k: int) -> bool:
        s = set()
        q = deque([root])
        while q:
            node = q.popleft()
            if k - node.val in s:
                return True
            s.add(node.val)
            if node.left:
                q.append(node.left)
            if node.right:
                q.append(node.right)
        return False
```

```cpp
class Solution {
public:
    bool findTarget(TreeNode *root, int k) {
        unordered_set<int> hashTable;
        queue<TreeNode *> que;
        que.push(root);
        while (!que.empty()) {
            TreeNode *node = que.front();
            que.pop();
            if (hashTable.count(k - node->val)) {
                return true;
            }
            hashTable.insert(node->val);
            if (node->left != nullptr) {
                que.push(node->left);
            }
            if (node->right != nullptr) {
                que.push(node->right);
            }
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean findTarget(TreeNode root, int k) {
        Set<Integer> set = new HashSet<Integer>();
        Queue<TreeNode> queue = new ArrayDeque<TreeNode>();
        queue.offer(root);
        while (!queue.isEmpty()) {
            TreeNode node = queue.poll();
            if (set.contains(k - node.val)) {
                return true;
            }
            set.add(node.val);
            if (node.left != null) {
                queue.offer(node.left);
            }
            if (node.right != null) {
                queue.offer(node.right);
            }
        }
        return false;
    }
}
```

```csharp
public class Solution {
    public bool FindTarget(TreeNode root, int k) {
        ISet<int> set = new HashSet<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            TreeNode node = queue.Dequeue();
            if (set.Contains(k - node.val)) {
                return true;
            }
            set.Add(node.val);
            if (node.left != null) {
                queue.Enqueue(node.left);
            }
            if (node.right != null) {
                queue.Enqueue(node.right);
            }
        }
        return false;
    }
}
```

```c
#define MAX_NODE_SIZE 1e4

typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem;

bool findTarget(struct TreeNode* root, int k){
    HashItem * hashTable = NULL;
    struct TreeNode ** que = (struct TreeNode **)malloc(sizeof(struct TreeNode *) * MAX_NODE_SIZE);
    int head = 0, tail = 0;
    que[tail++] = root;
    while (head != tail) {
        struct TreeNode *node = que[head++];
        int key = k - node->val;
        HashItem * pEntry = NULL;
        HASH_FIND_INT(hashTable, &key, pEntry);
        if (pEntry != NULL) {
            return true;
        }
        pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = node->val;
        HASH_ADD_INT(hashTable, key, pEntry);
        if (node->left != NULL) {
            que[tail++] = node->left;
        }
        if (node->right != NULL) {
            que[tail++] = node->right;
        }
    }
    HashItem * curr = NULL, * next = NULL;
    HASH_ITER(hh, hashTable, curr, next) {
        HASH_DEL(hashTable, curr); 
        free(curr);           
    }
    return false;
}
```

```javascript
var findTarget = function(root, k) {
    const set = new Set();
    const queue = [];
    queue.push(root);
    while (queue.length) {
        const node = queue.shift();
        if (set.has(k - node.val)) {
            return true;
        }
        set.add(node.val);
        if (node.left) {
            queue.push(node.left);
        }
        if (node.right) {
            queue.push(node.right);
        }
    }
    return false;
};
```

```go
func findTarget(root *TreeNode, k int) bool {
    set := map[int]struct{}{}
    q := []*TreeNode{root}
    for len(q) > 0 {
        node := q[0]
        q = q[1:]
        if _, ok := set[k-node.Val]; ok {
            return true
        }
        set[node.Val] = struct{}{}
        if node.Left != nil {
            q = append(q, node.Left)
        }
        if node.Right != nil {
            q = append(q, node.Right)
        }
    }
    return false
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ�����������Ĵ�С��������Ҫ����������һ�Ρ�
-   �ռ临�Ӷȣ�$O(n)$������ $n$ Ϊ�����������Ĵ�С����ҪΪ��ϣ��Ͷ��еĿ�����������������Ҫ��ÿ���ڵ�����ϣ��Ͷ��и�һ�Ρ�
