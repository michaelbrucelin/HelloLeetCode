#### [方法二：广度优先搜索](https://leetcode.cn/problems/minimum-depth-of-binary-tree/solutions/382646/er-cha-shu-de-zui-xiao-shen-du-by-leetcode-solutio/)

**思路及解法**

同样，我们可以想到使用广度优先搜索的方法，遍历整棵树。

当我们找到一个叶子节点时，直接返回这个叶子节点的深度。广度优先搜索的性质保证了最先搜索到的叶子节点的深度一定最小。

**代码**

```cpp
class Solution {
public:
    int minDepth(TreeNode *root) {
        if (root == nullptr) {
            return 0;
        }

        queue<pair<TreeNode *, int> > que;
        que.emplace(root, 1);
        while (!que.empty()) {
            TreeNode *node = que.front().first;
            int depth = que.front().second;
            que.pop();
            if (node->left == nullptr && node->right == nullptr) {
                return depth;
            }
            if (node->left != nullptr) {
                que.emplace(node->left, depth + 1);
            }
            if (node->right != nullptr) {
                que.emplace(node->right, depth + 1);
            }
        }

        return 0;
    }
};
```

```java
class Solution {
    class QueueNode {
        TreeNode node;
        int depth;

        public QueueNode(TreeNode node, int depth) {
            this.node = node;
            this.depth = depth;
        }
    }

    public int minDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        Queue<QueueNode> queue = new LinkedList<QueueNode>();
        queue.offer(new QueueNode(root, 1));
        while (!queue.isEmpty()) {
            QueueNode nodeDepth = queue.poll();
            TreeNode node = nodeDepth.node;
            int depth = nodeDepth.depth;
            if (node.left == null && node.right == null) {
                return depth;
            }
            if (node.left != null) {
                queue.offer(new QueueNode(node.left, depth + 1));
            }
            if (node.right != null) {
                queue.offer(new QueueNode(node.right, depth + 1));
            }
        }

        return 0;
    }
}
```

```c
typedef struct {
    int val;
    struct TreeNode *node;
    struct queNode *next;
} queNode;

void init(queNode **p, int val, struct TreeNode *node) {
    (*p) = (queNode *)malloc(sizeof(queNode));
    (*p)->val = val;
    (*p)->node = node;
    (*p)->next = NULL;
}

int minDepth(struct TreeNode *root) {
    if (root == NULL) {
        return 0;
    }

    queNode *queLeft, *queRight;
    init(&queLeft, 1, root);
    queRight = queLeft;
    while (queLeft != NULL) {
        struct TreeNode *node = queLeft->node;
        int depth = queLeft->val;
        if (node->left == NULL && node->right == NULL) {
            return depth;
        }
        if (node->left != NULL) {
            init(&queRight->next, depth + 1, node->left);
            queRight = queRight->next;
        }
        if (node->right != NULL) {
            init(&queRight->next, depth + 1, node->right);
            queRight = queRight->next;
        }
        queLeft = queLeft->next;
    }
    return false;
}
```

```python
class Solution:
    def minDepth(self, root: TreeNode) -> int:
        if not root:
            return 0

        que = collections.deque([(root, 1)])
        while que:
            node, depth = que.popleft()
            if not node.left and not node.right:
                return depth
            if node.left:
                que.append((node.left, depth + 1))
            if node.right:
                que.append((node.right, depth + 1))
        
        return 0
```

```go
func minDepth(root *TreeNode) int {
    if root == nil {
        return 0
    }
    queue := []*TreeNode{}
    count := []int{}
    queue = append(queue, root)
    count = append(count, 1)
    for i := 0; i < len(queue); i++ {
        node := queue[i]
        depth := count[i]
        if node.Left == nil && node.Right == nil {
            return depth
        }
        if node.Left != nil {
            queue = append(queue, node.Left)
            count = append(count, depth + 1)
        }
        if node.Right != nil {
            queue = append(queue, node.Right)
            count = append(count, depth + 1)
        }
    }
    return 0
}
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 是树的节点数。对每个节点访问一次。
-   空间复杂度：$O(N)$，其中 $N$ 是树的节点数。空间复杂度主要取决于队列的开销，队列中的元素个数不会超过树的节点数。
