#### [方法二：广度优先搜索 + 哈希表](https://leetcode.cn/problems/two-sum-iv-input-is-a-bst/solutions/1347526/liang-shu-zhi-he-iv-shu-ru-bst-by-leetco-b4nl/)

**思路和算法**

我们可以使用广度优先搜索的方式遍历整棵树，用哈希表记录遍历过的节点的值。

具体地，我们首先创建一个哈希表和一个队列，将根节点加入队列中，然后执行以下步骤：

1.  从队列中取出队头，假设其值为 $x$；
2.  检查哈希表中是否存在 $k - x$，如果存在，返回 $True$；
3.  否则，将该节点的左右的非空子节点加入队尾；
4.  重复以上步骤，直到队列为空；
5.  如果队列为空，说明树上不存在两个和为 $k$ 的节点，返回 $False$。

**代码**

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

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为二叉搜索树的大小。我们需要遍历整棵树一次。
-   空间复杂度：$O(n)$，其中 $n$ 为二叉搜索树的大小。主要为哈希表和队列的开销，最坏情况下我们需要将每个节点加入哈希表和队列各一次。
