#### [方法二：广度优先搜索](https://leetcode.cn/problems/sum-of-left-leaves/solutions/419103/zuo-xie-zi-zhi-he-by-leetcode-solution/)

```cpp
class Solution {
public:
    bool isLeafNode(TreeNode* node) {
        return !node->left && !node->right;
    }

    int sumOfLeftLeaves(TreeNode* root) {
        if (!root) {
            return 0;
        }

        queue<TreeNode*> q;
        q.push(root);
        int ans = 0;
        while (!q.empty()) {
            TreeNode* node = q.front();
            q.pop();
            if (node->left) {
                if (isLeafNode(node->left)) {
                    ans += node->left->val;
                }
                else {
                    q.push(node->left);
                }
            }
            if (node->right) {
                if (!isLeafNode(node->right)) {
                    q.push(node->right);
                }
            }
        }
        return ans;
    }
};
```

```cpp
class Solution {
public:
    bool isLeafNode(TreeNode* node) {
        return !node->left && !node->right;
    }

    int sumOfLeftLeaves(TreeNode* root) {
        if (!root) {
            return 0;
        }

        queue q{deque{root}};
        int ans = 0;
        while (!q.empty()) {
            TreeNode* node = q.front();
            q.pop();
            if (node->left) {
                if (isLeafNode(node->left)) {
                    ans += node->left->val;
                }
                else {
                    q.push(node->left);
                }
            }
            if (node->right) {
                if (!isLeafNode(node->right)) {
                    q.push(node->right);
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int sumOfLeftLeaves(TreeNode root) {
        if (root == null) {
            return 0;
        }

        Queue<TreeNode> queue = new LinkedList<TreeNode>();
        queue.offer(root);
        int ans = 0;
        while (!queue.isEmpty()) {
            TreeNode node = queue.poll();
            if (node.left != null) {
                if (isLeafNode(node.left)) {
                    ans += node.left.val;
                } else {
                    queue.offer(node.left);
                }
            }
            if (node.right != null) {
                if (!isLeafNode(node.right)) {
                    queue.offer(node.right);
                }
            }
        }
        return ans;
    }

    public boolean isLeafNode(TreeNode node) {
        return node.left == null && node.right == null;
    }
}
```

```python
class Solution:
    def sumOfLeftLeaves(self, root: TreeNode) -> int:
        if not root:
            return 0
        
        isLeafNode = lambda node: not node.left and not node.right
        q = collections.deque([root])
        ans = 0

        while q:
            node = q.popleft()
            if node.left:
                if isLeafNode(node.left):
                    ans += node.left.val
                else:
                    q.append(node.left)
            if node.right:
                if not isLeafNode(node.right):
                    q.append(node.right)
        
        return ans
```

```go
func isLeafNode(node *TreeNode) bool {
    return node.Left == nil && node.Right == nil
}

func sumOfLeftLeaves(root *TreeNode) (ans int) {
    if root == nil {
        return
    }
    q := []*TreeNode{root}
    for len(q) > 0 {
        node := q[0]
        q = q[1:]
        if node.Left != nil {
            if isLeafNode(node.Left) {
                ans += node.Left.Val
            } else {
                q = append(q, node.Left)
            }
        }
        if node.Right != nil && !isLeafNode(node.Right) {
            q = append(q, node.Right)
        }
    }
    return
}
```

```c
bool isLeafNode(struct TreeNode *node) {
    return !node->left && !node->right;
}

int sumOfLeftLeaves(struct TreeNode *root) {
    if (!root) {
        return 0;
    }
    struct TreeNode **q = malloc(sizeof(struct TreeNode *) * 2001);
    int left = 0, right = 0;
    q[right++] = root;
    int ans = 0;
    while (left < right) {
        struct TreeNode *node = q[left++];
        if (node->left) {
            if (isLeafNode(node->left)) {
                ans += node->left->val;
            } else {
                q[right++] = node->left;
            }
        }
        if (node->right) {
            if (!isLeafNode(node->right)) {
                q[right++] = node->right;
            }
        }
    }
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是树中的节点个数。
-   空间复杂度：$O(n)$。空间复杂度与广度优先搜索使用的队列需要的容量相关，为 $O(n)$。
