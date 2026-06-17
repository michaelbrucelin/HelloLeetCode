### [删除二叉搜索树中的节点](https://leetcode.cn/problems/delete-node-in-a-bst/solutions/1529700/shan-chu-er-cha-sou-suo-shu-zhong-de-jie-n6vo/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：递归

**思路**

二叉搜索树有以下性质：

- 左子树的所有节点（如果有）的值均小于当前节点的值；
- 右子树的所有节点（如果有）的值均大于当前节点的值；
- 左子树和右子树均为二叉搜索树。

二叉搜索树的题目往往可以用递归来解决。此题要求删除二叉树的节点，函数 $deleteNode$ 的输入是二叉树的根节点 $root$ 和一个整数 $key$，输出是删除值为 $key$ 的节点后的二叉树，并保持二叉树的有序性。可以按照以下情况分类讨论：

- $root$ 为空，代表未搜索到值为 $key$ 的节点，返回空。
- $root.val>key$，表示值为 $key$ 的节点可能存在于 $root$ 的左子树中，需要递归地在 $root.left$ 调用 $deleteNode$，并返回 $root$。
- $root.val<key$，表示值为 $key$ 的节点可能存在于 $root$ 的右子树中，需要递归地在 $root.right$ 调用 $deleteNode$，并返回 $root$。
- $root.val=key$，root 即为要删除的节点。此时要做的是删除 $root$，并将它的子树合并成一棵子树，保持有序性，并返回根节点。根据 $root$ 的子树情况分成以下情况讨论：
  - root 为叶子节点，没有子树。此时可以直接将它删除，即返回空。
  - root 只有左子树，没有右子树。此时可以将它的左子树作为新的子树，返回它的左子节点。
  - root 只有右子树，没有左子树。此时可以将它的右子树作为新的子树，返回它的右子节点。
  - root 有左右子树，这时可以将 $root$ 的后继节点（比 $root$ 大的最小节点，即它的右子树中的最小节点，记为 $successor$）作为新的根节点替代 $root$，并将 $successor$ 从 $root$ 的右子树中删除，使得在保持有序性的情况下合并左右子树。$ $
    简单证明，$successor$ 位于 $root$ 的右子树中，因此大于 $root$ 的所有左子节点；$successor$ 是 $root$ 的右子树中的最小节点，因此小于 $root$ 的右子树中的其他节点。以上两点保持了新子树的有序性。$ $
    在代码实现上，我们可以先寻找 $successor$，再删除它。$successor$ 是 $root$ 的右子树中的最小节点，可以先找到 $root$ 的右子节点，再不停地往左子节点寻找，直到找到一个不存在左子节点的节点，这个节点即为 $successor$。然后递归地在 $root.right$ 调用 $deleteNode$ 来删除 $successor$。因为 $successor$ 没有左子节点，因此这一步递归调用不会再次步入这一种情况。然后将 $successor$ 更新为新的 $root$ 并返回。

**代码**

```Python
class Solution:
    def deleteNode(self, root: Optional[TreeNode], key: int) -> Optional[TreeNode]:
        if root is None:
            return None
        if root.val > key:
            root.left = self.deleteNode(root.left, key)
        elif root.val < key:
            root.right = self.deleteNode(root.right, key)
        elif root.left is None or root.right is None:
            root = root.left if root.left else root.right
        else:
            successor = root.right
            while successor.left:
                successor = successor.left
            successor.right = self.deleteNode(root.right, successor.val)
            successor.left = root.left
            return successor
        return root
```

```C++
class Solution {
public:
    TreeNode* deleteNode(TreeNode* root, int key) {
        if (root == nullptr) {
            return nullptr;
        }
        if (root->val > key) {
            root->left = deleteNode(root->left, key);
            return root;
        }
        if (root->val < key) {
            root->right = deleteNode(root->right, key);
            return root;
        }
        if (root->val == key) {
            if (!root->left && !root->right) {
                return nullptr;
            }
            if (!root->right) {
                return root->left;
            }
            if (!root->left) {
                return root->right;
            }
            TreeNode *successor = root->right;
            while (successor->left) {
                successor = successor->left;
            }
            root->right = deleteNode(root->right, successor->val);
            successor->right = root->right;
            successor->left = root->left;
            return successor;
        }
        return root;
    }
};
```

```Java
class Solution {
    public TreeNode deleteNode(TreeNode root, int key) {
        if (root == null) {
            return null;
        }
        if (root.val > key) {
            root.left = deleteNode(root.left, key);
            return root;
        }
        if (root.val < key) {
            root.right = deleteNode(root.right, key);
            return root;
        }
        if (root.val == key) {
            if (root.left == null && root.right == null) {
                return null;
            }
            if (root.right == null) {
                return root.left;
            }
            if (root.left == null) {
                return root.right;
            }
            TreeNode successor = root.right;
            while (successor.left != null) {
                successor = successor.left;
            }
            root.right = deleteNode(root.right, successor.val);
            successor.right = root.right;
            successor.left = root.left;
            return successor;
        }
        return root;
    }
}
```

```CSharp
public class Solution {
    public TreeNode DeleteNode(TreeNode root, int key) {
        if (root == null) {
            return null;
        }
        if (root.val > key) {
            root.left = DeleteNode(root.left, key);
            return root;
        }
        if (root.val < key) {
            root.right = DeleteNode(root.right, key);
            return root;
        }
        if (root.val == key) {
            if (root.left == null && root.right == null) {
                return null;
            }
            if (root.right == null) {
                return root.left;
            }
            if (root.left == null) {
                return root.right;
            }
            TreeNode successor = root.right;
            while (successor.left != null) {
                successor = successor.left;
            }
            root.right = DeleteNode(root.right, successor.val);
            successor.right = root.right;
            successor.left = root.left;
            return successor;
        }
        return root;
    }
}
```

```C
struct TreeNode* deleteNode(struct TreeNode* root, int key){
    if (root == NULL) {
        return NULL;
    }
    if (root->val > key) {
        root->left = deleteNode(root->left, key);
        return root;
    }
    if (root->val < key) {
        root->right = deleteNode(root->right, key);
        return root;
    }
    if (root->val == key) {
        if (!root->left && !root->right) {
            return NULL;
        }
        if (!root->right) {
            return root->left;
        }
        if (!root->left) {
            return root->right;
        }
        struct TreeNode *successor = root->right;
        while (successor->left) {
            successor = successor->left;
        }
        root->right = deleteNode(root->right, successor->val);
        successor->right = root->right;
        successor->left = root->left;
        return successor;
    }
    return root;
}
```

```Go
func deleteNode(root *TreeNode, key int) *TreeNode {
    switch {
    case root == nil:
        return nil
    case root.Val > key:
        root.Left = deleteNode(root.Left, key)
    case root.Val < key:
        root.Right = deleteNode(root.Right, key)
    case root.Left == nil || root.Right == nil:
        if root.Left != nil {
            return root.Left
        }
        return root.Right
    default:
        successor := root.Right
        for successor.Left != nil {
            successor = successor.Left
        }
        successor.Right = deleteNode(root.Right, successor.Val)
        successor.Left = root.Left
        return successor
    }
    return root
}
```

```JavaScript
var deleteNode = function(root, key) {
    if (!root) {
        return null;
    }
    if (root.val > key) {
        root.left = deleteNode(root.left, key);
        return root;
    }
    if (root.val < key) {
        root.right = deleteNode(root.right, key);
        return root;
    }
    if (root.val === key) {
        if (!root.left && !root.right) {
            return null;
        }
        if (!root.right) {
            return root.left;
        }
        if (!root.left) {
            return root.right;
        }
        let successor = root.right;
        while (successor.left) {
            successor = successor.left;
        }
        root.right = deleteNode(root.right, successor.val);
        successor.right = root.right;
        successor.left = root.left;
        return successor;
    }
    return root;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $root$ 的节点个数。最差情况下，寻找和删除 $successor$ 各需要遍历一次树。
- 空间复杂度：$O(n)$，其中 $n$ 为 $root$ 的节点个数。递归的深度最深为 $O(n)$。

#### 方法二：迭代

**思路**

方法一的递归深度最多为 $n$，而大部分是由寻找值为 $key$ 的节点贡献的，而寻找节点这一部分可以用迭代来优化。寻找并删除 $successor$ 时，也可以用一个变量保存它的父节点，从而可以节省一步递归操作。

**代码**

```Python
class Solution:
    def deleteNode(self, root: Optional[TreeNode], key: int) -> Optional[TreeNode]:
        cur, curParent = root, None
        while cur and cur.val != key:
            curParent = cur
            cur = cur.left if cur.val > key else cur.right
        if cur is None:
            return root
        if cur.left is None and cur.right is None:
            cur = None
        elif cur.right is None:
            cur = cur.left
        elif cur.left is None:
            cur = cur.right
        else:
            successor, successorParent = cur.right, cur
            while successor.left:
                successorParent = successor
                successor = successor.left
            if successorParent.val == cur.val:
                successorParent.right = successor.right
            else:
                successorParent.left = successor.right
            successor.right = cur.right
            successor.left = cur.left
            cur = successor
        if curParent is None:
            return cur
        if curParent.left and curParent.left.val == key:
            curParent.left = cur
        else:
            curParent.right = cur
        return root
```

```C++
class Solution {
public:
    TreeNode* deleteNode(TreeNode* root, int key) {
        TreeNode *cur = root, *curParent = nullptr;
        while (cur && cur->val != key) {
            curParent = cur;
            if (cur->val > key) {
                cur = cur->left;
            } else {
                cur = cur->right;
            }
        }
        if (!cur) {
            return root;
        }
        if (!cur->left && !cur->right) {
            cur = nullptr;
        } else if (!cur->right) {
            cur = cur->left;
        } else if (!cur->left) {
            cur = cur->right;
        } else {
            TreeNode *successor = cur->right, *successorParent = cur;
            while (successor->left) {
                successorParent = successor;
                successor = successor->left;
            }
            if (successorParent->val == cur->val) {
                successorParent->right = successor->right;
            } else {
                successorParent->left = successor->right;
            }
            successor->right = cur->right;
            successor->left = cur->left;
            cur = successor;
        }
        if (!curParent) {
            return cur;
        } else {
            if (curParent->left && curParent->left->val == key) {
                curParent->left = cur;
            } else {
                curParent->right = cur;
            }
            return root;
        }
    }
};
```

```Java
class Solution {
    public TreeNode deleteNode(TreeNode root, int key) {
        TreeNode cur = root, curParent = null;
        while (cur != null && cur.val != key) {
            curParent = cur;
            if (cur.val > key) {
                cur = cur.left;
            } else {
                cur = cur.right;
            }
        }
        if (cur == null) {
            return root;
        }
        if (cur.left == null && cur.right == null) {
            cur = null;
        } else if (cur.right == null) {
            cur = cur.left;
        } else if (cur.left == null) {
            cur = cur.right;
        } else {
            TreeNode successor = cur.right, successorParent = cur;
            while (successor.left != null) {
                successorParent = successor;
                successor = successor.left;
            }
            if (successorParent.val == cur.val) {
                successorParent.right = successor.right;
            } else {
                successorParent.left = successor.right;
            }
            successor.right = cur.right;
            successor.left = cur.left;
            cur = successor;
        }
        if (curParent == null) {
            return cur;
        } else {
            if (curParent.left != null && curParent.left.val == key) {
                curParent.left = cur;
            } else {
                curParent.right = cur;
            }
            return root;
        }
    }
}
```

```CSharp
public class Solution {
    public TreeNode DeleteNode(TreeNode root, int key) {
        TreeNode cur = root, curParent = null;
        while (cur != null && cur.val != key) {
            curParent = cur;
            if (cur.val > key) {
                cur = cur.left;
            } else {
                cur = cur.right;
            }
        }
        if (cur == null) {
            return root;
        }
        if (cur.left == null && cur.right == null) {
            cur = null;
        } else if (cur.right == null) {
            cur = cur.left;
        } else if (cur.left == null) {
            cur = cur.right;
        } else {
            TreeNode successor = cur.right, successorParent = cur;
            while (successor.left != null) {
                successorParent = successor;
                successor = successor.left;
            }
            if (successorParent.val == cur.val) {
                successorParent.right = successor.right;
            } else {
                successorParent.left = successor.right;
            }
            successor.right = cur.right;
            successor.left = cur.left;
            cur = successor;
        }
        if (curParent == null) {
            return cur;
        } else {
            if (curParent.left != null && curParent.left.val == key) {
                curParent.left = cur;
            } else {
                curParent.right = cur;
            }
            return root;
        }
    }
}
```

```C
struct TreeNode* deleteNode(struct TreeNode* root, int key){
    struct TreeNode *cur = root, *curParent = NULL;
    while (cur && cur->val != key) {
        curParent = cur;
        if (cur->val > key) {
            cur = cur->left;
        } else {
            cur = cur->right;
        }
    }
    if (!cur) {
        return root;
    }
    if (!cur->left && !cur->right) {
        cur = NULL;
    } else if (!cur->right) {
        cur = cur->left;
    } else if (!cur->left) {
        cur = cur->right;
    } else {
        struct TreeNode *successor = cur->right, *successorParent = cur;
        while (successor->left) {
            successorParent = successor;
            successor = successor->left;
        }
        if (successorParent->val == cur->val) {
            successorParent->right = successor->right;
        } else {
            successorParent->left = successor->right;
        }
        successor->right = cur->right;
        successor->left = cur->left;
        cur = successor;
    }
    if (!curParent) {
        return cur;
    } else {
        if (curParent->left && curParent->left->val == key) {
            curParent->left = cur;
        } else {
            curParent->right = cur;
        }
        return root;
    }
}
```

```Go
func deleteNode(root *TreeNode, key int) *TreeNode {
    var cur, curParent *TreeNode = root, nil
    for cur != nil && cur.Val != key {
        curParent = cur
        if cur.Val > key {
            cur = cur.Left
        } else {
            cur = cur.Right
        }
    }
    if cur == nil {
        return root
    }
    if cur.Left == nil && cur.Right == nil {
        cur = nil
    } else if cur.Right == nil {
        cur = cur.Left
    } else if cur.Left == nil {
        cur = cur.Right
    } else {
        successor, successorParent := cur.Right, cur
        for successor.Left != nil {
            successorParent = successor
            successor = successor.Left
        }
        if successorParent.Val == cur.Val {
            successorParent.Right = successor.Right
        } else {
            successorParent.Left = successor.Right
        }
        successor.Right = cur.Right
        successor.Left = cur.Left
        cur = successor
    }
    if curParent == nil {
        return cur
    }
    if curParent.Left != nil && curParent.Left.Val == key {
        curParent.Left = cur
    } else {
        curParent.Right = cur
    }
    return root
}
```

```JavaScript
var deleteNode = function(root, key) {
    let cur = root, curParent = null;
    while (cur && cur.val !== key) {
        curParent = cur;
        if (cur.val > key) {
            cur = cur.left;
        } else {
            cur = cur.right;
        }
    }
    if (!cur) {
        return root;
    }
    if (!cur.left && !cur.right) {
        cur = null;
    } else if (!cur.right) {
        cur = cur.left;
    } else if (!cur.left) {
        cur = cur.right;
    } else {
        let successor = cur.right, successorParent = cur;
        while (successor.left) {
            successorParent = successor;
            successor = successor.left;
        }
        if (successorParent.val === cur.val) {
            successorParent.right = successor.right;
        } else {
            successorParent.left = successor.right;
        }
        successor.right = cur.right;
        successor.left = cur.left;
        cur = successor;
    }
    if (!curParent) {
        return cur;
    } else {
        if (curParent.left && curParent.left.val === key) {
            curParent.left = cur;
        } else {
            curParent.right = cur;
        }
        return root;
    }
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $root$ 的节点个数。最差情况下，需要遍历一次树。
- 空间复杂度：$O(1)$。使用的空间为常数。
