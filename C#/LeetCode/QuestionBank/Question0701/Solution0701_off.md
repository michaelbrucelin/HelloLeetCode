### [二叉搜索树中的插入操作](https://leetcode.cn/problems/insert-into-a-binary-search-tree/solutions/432223/er-cha-sou-suo-shu-zhong-de-cha-ru-cao-zuo-by-le-3/)

#### 方法一：模拟

**思路与算法**

首先回顾二叉搜索树的性质：对于任意节点 $root$ 而言，左子树（如果存在）上所有节点的值均小于 $root.val$，右子树（如果存在）上所有节点的值均大于 $root.val$，且它们都是二叉搜索树。

因此，当将 $val$ 插入到以 $root$ 为根的子树上时，根据 $val$ 与 $root.val$ 的大小关系，就可以确定要将 $val$ 插入到哪个子树中。

- 如果该子树不为空，则问题转化成了将 $val$ 插入到对应子树上。
- 否则，在此处新建一个以 $val$ 为值的节点，并链接到其父节点 $root$ 上。

**代码**

```C++
class Solution {
public:
    TreeNode* insertIntoBST(TreeNode* root, int val) {
        if (root == nullptr) {
            return new TreeNode(val);
        }
        TreeNode* pos = root;
        while (pos != nullptr) {
            if (val < pos->val) {
                if (pos->left == nullptr) {
                    pos->left = new TreeNode(val);
                    break;
                } else {
                    pos = pos->left;
                }
            } else {
                if (pos->right == nullptr) {
                    pos->right = new TreeNode(val);
                    break;
                } else {
                    pos = pos->right;
                }
            }
        }
        return root;
    }
};
```

```Java
class Solution {
    public TreeNode insertIntoBST(TreeNode root, int val) {
        if (root == null) {
            return new TreeNode(val);
        }
        TreeNode pos = root;
        while (pos != null) {
            if (val < pos.val) {
                if (pos.left == null) {
                    pos.left = new TreeNode(val);
                    break;
                } else {
                    pos = pos.left;
                }
            } else {
                if (pos.right == null) {
                    pos.right = new TreeNode(val);
                    break;
                } else {
                    pos = pos.right;
                }
            }
        }
        return root;
    }
}
```

```Python
class Solution:
    def insertIntoBST(self, root: TreeNode, val: int) -> TreeNode:
        if not root:
            return TreeNode(val)

        pos = root
        while pos:
            if val < pos.val:
                if not pos.left:
                    pos.left = TreeNode(val)
                    break
                else:
                    pos = pos.left
            else:
                if not pos.right:
                    pos.right = TreeNode(val)
                    break
                else:
                    pos = pos.right

        return root
```

```JavaScript
var insertIntoBST = function(root, val) {
    if (root === null) {
        return new TreeNode(val);
    }
    let pos = root;
    while (pos !== null) {
        if (val < pos.val) {
            if (pos.left === null) {
                pos.left = new TreeNode(val);
                break;
            } else {
                pos = pos.left;
            }
        } else {
            if (pos.right === null) {
                pos.right = new TreeNode(val);
                break;
            } else {
                pos = pos.right;
            }
        }
    }
    return root;
};
```

```Go
func insertIntoBST(root *TreeNode, val int) *TreeNode {
    if root == nil {
        return &TreeNode{Val: val}
    }
    p := root
    for p != nil {
        if val < p.Val {
            if p.Left == nil {
                p.Left = &TreeNode{Val: val}
                break
            }
            p = p.Left
        } else {
            if p.Right == nil {
                p.Right = &TreeNode{Val: val}
                break
            }
            p = p.Right
        }
    }
    return root
}
```

```C
struct TreeNode* createTreeNode(int val) {
    struct TreeNode* ret = malloc(sizeof(struct TreeNode));
    ret->val = val;
    ret->left = ret->right = NULL;
    return ret;
}

struct TreeNode* insertIntoBST(struct TreeNode* root, int val) {
    if (root == NULL) {
        root = createTreeNode(val);
        return root;
    }
    struct TreeNode* pos = root;
    while (pos != NULL) {
        if (val < pos->val) {
            if (pos->left == NULL) {
                pos->left = createTreeNode(val);
                break;
            } else {
                pos = pos->left;
            }
        } else {
            if (pos->right == NULL) {
                pos->right = createTreeNode(val);
                break;
            } else {
                pos = pos->right;
            }
        }
    }
    return root;
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 为树中节点的数目。最坏情况下，我们需要将值插入到树的最深的叶子结点上，而叶子节点最深为 $O(N)$。
- 空间复杂度：$O(1)$。我们只使用了常数大小的空间。
