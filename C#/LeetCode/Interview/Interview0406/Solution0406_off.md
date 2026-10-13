### [后继者](https://leetcode.cn/problems/successor-lcci/solutions/1490642/hou-ji-zhe-by-leetcode-solution-6hgc/?envType=problem-list-v2&envId=h15Gc5qm)

#### 方法一：中序遍历

为了找到二叉搜索树中的节点 $p$ 的后继节点，最直观的方法是中序遍历。由于只需要找到节点 $p$ 的后继节点，因此不需要维护完整的中序遍历序列，只需要在中序遍历的过程中维护上一个访问的节点和当前访问的节点。如果上一个访问的节点是节点 $p$，则当前访问的节点即为节点 $p$ 的后继节点。

如果节点 $p$ 是最后被访问的节点，则不存在节点 $p$ 的后继节点，返回 $null$。

```Python
class Solution:
    def inorderSuccessor(self, root: TreeNode, p: TreeNode) -> TreeNode:
        st, pre, cur = [], None, root
        while st or cur:
            while cur:
                st.append(cur)
                cur = cur.left
            cur = st.pop()
            if pre == p:
                return cur
            pre = cur
            cur = cur.right
        return None
```

```Java
class Solution {
    public TreeNode inorderSuccessor(TreeNode root, TreeNode p) {
        Deque<TreeNode> stack = new ArrayDeque<TreeNode>();
        TreeNode prev = null, curr = root;
        while (!stack.isEmpty() || curr != null) {
            while (curr != null) {
                stack.push(curr);
                curr = curr.left;
            }
            curr = stack.pop();
            if (prev == p) {
                return curr;
            }
            prev = curr;
            curr = curr.right;
        }
        return null;
    }
}
```

```CSharp
public class Solution {
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode prev = null, curr = root;
        while (stack.Count > 0 || curr != null) {
            while (curr != null) {
                stack.Push(curr);
                curr = curr.left;
            }
            curr = stack.Pop();
            if (prev == p) {
                return curr;
            }
            prev = curr;
            curr = curr.right;
        }
        return null;
    }
}
```

```C++
class Solution {
public:
    TreeNode* inorderSuccessor(TreeNode* root, TreeNode* p) {
        stack<TreeNode*> st;
        TreeNode *prev = nullptr, *curr = root;
        while (!st.empty() || curr != nullptr) {
            while (curr != nullptr) {
                st.emplace(curr);
                curr = curr->left;
            }
            curr = st.top();
            st.pop();
            if (prev == p) {
                return curr;
            }
            prev = curr;
            curr = curr->right;
        }
        return nullptr;
    }
};
```

```C
typedef struct ElementNode {
    struct TreeNode * val;
    struct ElementNode * next;
} ElementNode;

struct TreeNode* inorderSuccessor(struct TreeNode* root, struct TreeNode* p) {
    ElementNode * st = NULL;
    struct TreeNode *prev = NULL, *curr = root;
    while (st || curr != NULL) {
        while (curr != NULL) {
            ElementNode * node = (ElementNode *)malloc(sizeof(ElementNode));
            node->val = curr;
            node->next = st;
            st = node;
            curr = curr->left;
        }
        ElementNode * node = st;
        curr = node->val;
        st = st->next;
        free(node);
        if (prev == p) {
            return curr;
        }
        prev = curr;
        curr = curr->right;
    }
    return NULL;
}
```

```JavaScript
var inorderSuccessor = function(root, p) {
    const stack = [];
    let prev = null, curr = root;
    while (stack.length || curr) {
        while (curr) {
            stack.push(curr);
            curr = curr.left;
        }
        curr = stack.pop();
        if (prev === p) {
            return curr;
        }
        prev = curr;
        curr = curr.right;
    }
    return null;
};
```

```Go
func inorderSuccessor(root, p *TreeNode) *TreeNode {
    st := []*TreeNode{}
    var pre, cur *TreeNode = nil, root
    for len(st) > 0 || cur != nil {
        for cur != nil {
            st = append(st, cur)
            cur = cur.Left
        }
        cur = st[len(st)-1]
        st = st[:len(st)-1]
        if pre == p {
            return cur
        }
        pre = cur
        cur = cur.Right
    }
    return nil
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是二叉搜索树的节点数。中序遍历最多需要访问二叉搜索树中的每个节点一次。
- 空间复杂度：$O(n)$，其中 $n$ 是二叉搜索树的节点数。空间复杂度取决于栈深度，平均情况是 $O(\log n)$，最坏情况是 $O(n)$。

#### 方法二：利用二叉搜索树的性质

二叉搜索树的一个性质是中序遍历序列单调递增，因此二叉搜索树中的节点 $p$ 的后继节点满足以下条件：

- 后继节点的节点值大于 $p$ 的节点值；
- 后继节点是节点值大于 $p$ 的节点值的所有节点中节点值最小的一个节点。

利用二叉搜索树的性质，可以在不做中序遍历的情况下找到节点 $p$ 的后继节点。

如果节点 $p$ 的右子树不为空，则节点 $p$ 的后继节点在其右子树中，在其右子树中定位到最左边的节点，即为节点 $p$ 的后继节点。

如果节点 $p$ 的右子树为空，则需要从根节点开始遍历寻找节点 $p$ 的祖先节点。

将答案初始化为 $null$。用 $node$ 表示遍历到的节点，初始时 $node=root$。每次比较 $node$ 的节点值和 $p$ 的节点值，执行相应操作：

- 如果 $node$ 的节点值大于 $p$ 的节点值，则 $p$ 的后继节点可能是 $node$ 或者在 $node$ 的左子树中，因此用 $node$ 更新答案，并将 $node$ 移动到其左子节点继续遍历；
- 如果 $node$ 的节点值小于或等于 $p$ 的节点值，则 $p$ 的后继节点可能在 $node$ 的右子树中，因此将 $node$ 移动到其右子节点继续遍历。

由于在遍历过程中，当且仅当 $node$ 的节点值大于 $p$ 的节点值的情况下，才会用 $node$ 更新答案，因此当节点 $p$ 有后继节点时一定可以找到后继节点，当节点 $p$ 没有后继节点时答案一定为 $null$。

```Python
class Solution:
    def inorderSuccessor(self, root: TreeNode, p: TreeNode) -> TreeNode:
        successor = None
        if p.right:
            successor = p.right
            while successor.left:
                successor = successor.left
            return successor
        node = root
        while node:
            if node.val > p.val:
                successor = node
                node = node.left
            else:
                node = node.right
        return successor
```

```Java
class Solution {
    public TreeNode inorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode successor = null;
        if (p.right != null) {
            successor = p.right;
            while (successor.left != null) {
                successor = successor.left;
            }
            return successor;
        }
        TreeNode node = root;
        while (node != null) {
            if (node.val > p.val) {
                successor = node;
                node = node.left;
            } else {
                node = node.right;
            }
        }
        return successor;
    }
}
```

```CSharp
public class Solution {
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode successor = null;
        if (p.right != null) {
            successor = p.right;
            while (successor.left != null) {
                successor = successor.left;
            }
            return successor;
        }
        TreeNode node = root;
        while (node != null) {
            if (node.val > p.val) {
                successor = node;
                node = node.left;
            } else {
                node = node.right;
            }
        }
        return successor;
    }
}
```

```C++
class Solution {
public:
    TreeNode* inorderSuccessor(TreeNode* root, TreeNode* p) {
        TreeNode *successor = nullptr;
        if (p->right != nullptr) {
            successor = p->right;
            while (successor->left != nullptr) {
                successor = successor->left;
            }
            return successor;
        }
        TreeNode *node = root;
        while (node != nullptr) {
            if (node->val > p->val) {
                successor = node;
                node = node->left;
            } else {
                node = node->right;
            }
        }
        return successor;
    }
};
```

```C
struct TreeNode* inorderSuccessor(struct TreeNode* root, struct TreeNode* p) {
    struct TreeNode *successor = NULL;
    if (p->right != NULL) {
        successor = p->right;
        while (successor->left != NULL) {
            successor = successor->left;
        }
        return successor;
    }
    struct TreeNode *node = root;
    while (node != NULL) {
        if (node->val > p->val) {
            successor = node;
            node = node->left;
        } else {
            node = node->right;
        }
    }
    return successor;
}
```

```JavaScript
var inorderSuccessor = function(root, p) {
    let successor = null;
    if (p.right) {
        successor = p.right;
        while (successor.left) {
            successor = successor.left;
        }
        return successor;
    }
    let node = root;
    while (node) {
        if (node.val > p.val) {
            successor = node;
            node = node.left;
        } else {
            node = node.right;
        }
    }
    return successor;
};
```

```Go
func inorderSuccessor(root, p *TreeNode) *TreeNode {
    var successor *TreeNode
    if p.Right != nil {
        successor = p.Right
        for successor.Left != nil {
            successor = successor.Left
        }
        return successor
    }
    node := root
    for node != nil {
        if node.Val > p.Val {
            successor = node
            node = node.Left
        } else {
            node = node.Right
        }
    }
    return successor
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是二叉搜索树的节点数。遍历的节点数不超过二叉搜索树的高度，平均情况是 $O(\log n)$，最坏情况是 $O(n)$。
- 空间复杂度：$O(1)$。
