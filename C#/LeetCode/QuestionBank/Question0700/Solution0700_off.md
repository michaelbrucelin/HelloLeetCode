### [二叉搜索树中的搜索](https://leetcode.cn/problems/search-in-a-binary-search-tree/solutions/1121178/er-cha-sou-suo-shu-zhong-de-sou-suo-by-l-d8zi/)

#### 方法一：递归

二叉搜索树满足如下性质：

-   左子树所有节点的元素值均小于根的元素值；
-   右子树所有节点的元素值均大于根的元素值。

据此可以得到如下算法：

-   若 $root$ 为空则返回空节点；
-   若 $val=root.val$，则返回 $root$；
-   若 $val<root.val$，递归左子树；
-   若 $val>root.val$，递归右子树。

```python
class Solution:
    def searchBST(self, root: TreeNode, val: int) -> TreeNode:
        if root is None:
            return None
        if val == root.val:
            return root
        return self.searchBST(root.left if val < root.val else root.right, val)
```

```cpp
class Solution {
public:
    TreeNode *searchBST(TreeNode *root, int val) {
        if (root == nullptr) {
            return nullptr;
        }
        if (val == root->val) {
            return root;
        }
        return searchBST(val < root->val ? root->left : root->right, val);
    }
};
```

```java
class Solution {
    public TreeNode searchBST(TreeNode root, int val) {
        if (root == null) {
            return null;
        }
        if (val == root.val) {
            return root;
        }
        return searchBST(val < root.val ? root.left : root.right, val);
    }
}
```

```csharp
public class Solution {
    public TreeNode SearchBST(TreeNode root, int val) {
        if (root == null) {
            return null;
        }
        if (val == root.val) {
            return root;
        }
        return SearchBST(val < root.val ? root.left : root.right, val);
    }
}
```

```go
func searchBST(root *TreeNode, val int) *TreeNode {
    if root == nil {
        return nil
    }
    if val == root.Val {
        return root
    }
    if val < root.Val {
        return searchBST(root.Left, val)
    }
    return searchBST(root.Right, val)
}
```

```javascript
var searchBST = function(root, val) {
    if (!root) {
        return null;
    }
    if (val === root.val) {
        return root;
    }
    return searchBST(val < root.val ? root.left : root.right, val);
};
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 是二叉搜索树的节点数。最坏情况下二叉搜索树是一条链，且要找的元素比链末尾的元素值还要小（大），这种情况下我们需要递归 $N$ 次。
-   空间复杂度：$O(N)$。最坏情况下递归需要 $O(N)$ 的栈空间。

#### 方法二：迭代

我们将方法一的递归改成迭代写法：

-   若 $root$ 为空则跳出循环，并返回空节点；
-   若 $val=root.val$，则返回 $root$；
-   若 $val<root.val$，将 $root$ 置为 $root.left$；
-   若 $val>root.val$，将 $root$ 置为 $root.right$。

```python
class Solution:
    def searchBST(self, root: TreeNode, val: int) -> TreeNode:
        while root:
            if val == root.val:
                return root
            root = root.left if val < root.val else root.right
        return None
```

```cpp
class Solution {
public:
    TreeNode *searchBST(TreeNode *root, int val) {
        while (root) {
            if (val == root->val) {
                return root;
            }
            root = val < root->val ? root->left : root->right;
        }
        return nullptr;
    }
};
```

```java
class Solution {
    public TreeNode searchBST(TreeNode root, int val) {
        while (root != null) {
            if (val == root.val) {
                return root;
            }
            root = val < root.val ? root.left : root.right;
        }
        return null;
    }
}
```

```csharp
public class Solution {
    public TreeNode SearchBST(TreeNode root, int val) {
        while (root != null) {
            if (val == root.val) {
                return root;
            }
            root = val < root.val ? root.left : root.right;
        }
        return null;
    }
}
```

```go
func searchBST(root *TreeNode, val int) *TreeNode {
    for root != nil {
        if val == root.Val {
            return root
        }
        if val < root.Val {
            root = root.Left
        } else {
            root = root.Right
        }
    }
    return nil
}
```

```javascript
var searchBST = function(root, val) {
    while (root) {
        if (val === root.val) {
            return root;
        }
        root = val < root.val ? root.left : root.right;
    }
    return null;
};
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 是二叉搜索树的节点数。最坏情况下二叉搜索树是一条链，且要找的元素比链末尾的元素值还要小（大），这种情况下我们需要迭代 $N$ 次。
-   空间复杂度：$O(1)$。没有使用额外的空间。
