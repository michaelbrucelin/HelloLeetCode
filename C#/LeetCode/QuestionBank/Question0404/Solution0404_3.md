#### ǰ��

һ���ڵ�Ϊ����Ҷ�ӡ��ڵ㣬���ҽ�������ĳ���ڵ�����ӽڵ㣬��������һ��Ҷ�ӽ�㡣������ǿ��Կ��Ƕ����������б����������Ǳ������ڵ� $node$ ʱ������������ӽڵ���һ��Ҷ�ӽ�㣬��ô�ͽ��������ӽڵ��ֵ�ۼӼ���𰸡�

�����������ķ�����������������͹����������������ֱ������ʵ�ִ��롣

#### [����һ�������������](https://leetcode.cn/problems/sum-of-left-leaves/solutions/419103/zuo-xie-zi-zhi-he-by-leetcode-solution/)

```cpp
class Solution {
public:
    bool isLeafNode(TreeNode* node) {
        return !node->left && !node->right;
    }

    int dfs(TreeNode* node) {
        int ans = 0;
        if (node->left) {
            ans += isLeafNode(node->left) ? node->left->val : dfs(node->left);
        }
        if (node->right && !isLeafNode(node->right)) {
            ans += dfs(node->right);
        }
        return ans;
    }

    int sumOfLeftLeaves(TreeNode* root) {
        return root ? dfs(root) : 0;
    }
};
```

```java
class Solution {
    public int sumOfLeftLeaves(TreeNode root) {
        return root != null ? dfs(root) : 0;
    }

    public int dfs(TreeNode node) {
        int ans = 0;
        if (node.left != null) {
            ans += isLeafNode(node.left) ? node.left.val : dfs(node.left);
        }
        if (node.right != null && !isLeafNode(node.right)) {
            ans += dfs(node.right);
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
        isLeafNode = lambda node: not node.left and not node.right

        def dfs(node: TreeNode) -> int:
            ans = 0
            if node.left:
                ans += node.left.val if isLeafNode(node.left) else dfs(node.left)
            if node.right and not isLeafNode(node.right):
                ans += dfs(node.right)
            return ans
        
        return dfs(root) if root else 0
```

```go
func isLeafNode(node *TreeNode) bool {
    return node.Left == nil && node.Right == nil
}

func dfs(node *TreeNode) (ans int) {
    if node.Left != nil {
        if isLeafNode(node.Left) {
            ans += node.Left.Val
        } else {
            ans += dfs(node.Left)
        }
    }
    if node.Right != nil && !isLeafNode(node.Right) {
        ans += dfs(node.Right)
    }
    return
}

func sumOfLeftLeaves(root *TreeNode) int {
    if root == nil {
        return 0
    }
    return dfs(root)
}
```

```c
bool isLeafNode(struct TreeNode *node) {
    return !node->left && !node->right;
}

int dfs(struct TreeNode *node) {
    int ans = 0;
    if (node->left) {
        ans += isLeafNode(node->left) ? node->left->val : dfs(node->left);
    }
    if (node->right && !isLeafNode(node->right)) {
        ans += dfs(node->right);
    }
    return ans;
}

int sumOfLeftLeaves(struct TreeNode *root) {
    return root ? dfs(root) : 0;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ �����еĽڵ������
-   �ռ临�Ӷȣ�$O(n)$���ռ临�Ӷ��������������ʹ�õ�ջ����������ء����������£���������ʽ�ṹ�����Ϊ $O(n)$����Ӧ�Ŀռ临�Ӷ�ҲΪ $O(n)$��
