### [具有所有最深节点的最小子树](https://leetcode.cn/problems/smallest-subtree-with-all-the-deepest-nodes/solutions/2421008/ju-you-suo-you-zui-shen-jie-dian-de-zui-zz40c/)

#### 方法一：递归

**思路与算法**

题目给出一个二叉树，要求返回包含二叉树中所有最深节点的最小子树。其中树的根节点的深度为 $0$，我们注意到所有深度最大的节点，都是树的叶节点。为方便说明，我们把最深的叶节点的最近公共祖先，称之为 $lca$ 节点。

我们用递归的方式，进行深度优先搜索，对树中的每个节点进行递归，返回当前子树的最大深度 $d$ 和 $lca$ 节点。如果当前节点为空，我们返回深度 $0$ 和空节点。在每次搜索中，我们递归地搜索左子树和右子树，然后比较左右子树的深度：

- 如果左子树更深，最深叶节点在左子树中，我们返回 {左子树深度 $+1$，左子树的 $lca$ 节点}
- 如果右子树更深，最深叶节点在右子树中，我们返回 {右子树深度 $+1$，右子树的 $lca$ 节点}
- 如果左右子树一样深，左右子树都有最深叶节点，我们返回 {左子树深度 $+1$，当前节点}

最后我们返回根节点的 $lca$ 节点即可。

**代码**

```C++
class Solution {
public:
    pair<TreeNode*, int> f(TreeNode* root) {
        if (!root) {
            return {root, 0};
        }

        auto left = f(root->left);
        auto right = f(root->right);

        if (left.second > right.second) {
            return {left.first, left.second + 1};
        }
        if (left.second < right.second) {
            return {right.first, right.second + 1};
        }
        return {root, left.second + 1};

    }

    TreeNode* subtreeWithAllDeepest(TreeNode* root) {
        return f(root).first;
    }
};

```

```Java
class Solution {
    public TreeNode subtreeWithAllDeepest(TreeNode root) {
        return f(root).getKey();
    }

    private Pair<TreeNode, Integer> f(TreeNode root) {
        if (root == null) {
            return new Pair<>(root, 0);
        }

        Pair<TreeNode, Integer> left = f(root.left);
        Pair<TreeNode, Integer> right = f(root.right);

        if (left.getValue() > right.getValue()) {
            return new Pair<>(left.getKey(), left.getValue() + 1);
        }
        if (left.getValue() < right.getValue()) {
            return new Pair<>(right.getKey(), right.getValue() + 1);
        }
        return new Pair<>(root, left.getValue() + 1);
    }
}
```

```CSharp
public class Solution {
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        return f(root).Item1;
    }

    private Tuple<TreeNode, int> f(TreeNode root) {
        if (root == null) {
            return new Tuple<TreeNode, int>(root, 0);
        }

        Tuple<TreeNode, int> left = f(root.left);
        Tuple<TreeNode, int> right = f(root.right);

        if (left.Item2 > right.Item2) {
            return new Tuple<TreeNode, int>(left.Item1, left.Item2 + 1);
        }
        if (left.Item2 < right.Item2) {
            return new Tuple<TreeNode, int>(right.Item1, right.Item2 + 1);
        }
        return new Tuple<TreeNode, int>(root, left.Item2 + 1);
    }
}
```

```Python
class Solution:
    def subtreeWithAllDeepest(self, root: TreeNode) -> TreeNode:
        def f(root):
            if not root:
                return 0, None

            d1, lca1 = f(root.left)
            d2, lca2 = f(root.right)

            if d1 > d2:
                return d1 + 1, lca1
            if d1 < d2:
                return d2 + 1, lca2
            return d1 + 1, root

        return f(root)[1]
```

```JavaScript
var subtreeWithAllDeepest = function(root) {
    return f(root)[1];
};

function f(root) {
    if (!root) {
      return [0, root];
    }

    let [d1, lca1] = f(root.left);
    let [d2, lca2] = f(root.right);

    if (d1 > d2) {
      return [d1 + 1, lca1];
    }
    if (d1 < d2) {
      return [d2 + 1, lca2];
    }
    return [d1 + 1, root];
}
```

```Go
func subtreeWithAllDeepest(root *TreeNode) *TreeNode {
    _, lca := f(root)
    return lca
}

func f(root *TreeNode) (int, *TreeNode) {
    if root == nil {
        return 0, nil
    }

    d1, lca1 := f(root.Left)
    h2, lca2 := f(root.Right)

    if d1 > h2 {
        return d1 + 1, lca1
    }
    if d1 < h2 {
        return h2 + 1, lca2
    }
    return d1 + 1, root
}
```

```C
struct Pair {
    struct TreeNode *node;
    int depth;
};

struct Pair f(struct TreeNode *root) {
    if (root == NULL) {
        return (struct Pair) {NULL, 0};
    }

    struct Pair left = f(root->left);
    struct Pair right = f(root->right);

    if (left.depth > right.depth) {
        return (struct Pair) {left.node, left.depth + 1};
    }
    if (left.depth < right.depth) {
        return (struct Pair) {right.node, right.depth + 1};
    }
    return (struct Pair) {root, left.depth + 1};
}

struct TreeNode *subtreeWithAllDeepest(struct TreeNode *root) {
    return f(root).node;
}
```

```TypeScript
function subtreeWithAllDeepest(root: TreeNode | null): TreeNode | null {
    return f(root)[1];
}

function f(root: TreeNode | null): [number, TreeNode | null] {
    if (!root) {
        return [0, root];
    }

    const [d1, lca1] = f(root.left);
    const [d2, lca2] = f(root.right);

    if (d1 > d2) {
        return [d1 + 1, lca1];
    }
    if (d1 < d2) {
        return [d2 + 1, lca2];
    }
    return [d1 + 1, root];
}
```

```Rust
use std::rc::Rc;
use std::cell::RefCell;

impl Solution {
    pub fn subtree_with_all_deepest(root: Option<Rc<RefCell<TreeNode>>>) -> Option<Rc<RefCell<TreeNode>>> {
        Self::dfs(&root).1
    }

    fn dfs(node: &Option<Rc<RefCell<TreeNode>>>) -> (i32, Option<Rc<RefCell<TreeNode>>>) {
        match node {
            None => (0, None),
            Some(node_ref) => {
                let node_borrow = node_ref.borrow();
                let (left_depth, left_lca) = Self::dfs(&node_borrow.left);
                let (right_depth, right_lca) = Self::dfs(&node_borrow.right);

                if left_depth > right_depth {
                    (left_depth + 1, left_lca)
                } else if left_depth < right_depth {
                    (right_depth + 1, right_lca)
                } else {
                    (left_depth + 1, Some(node_ref.clone()))
                }
            }
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是树的节点数量。
- 空间复杂度：$O(d)$，其中 $d$ 是树的深度。空间复杂度主要是递归的空间，最差情况为 $O(n)$，其中 $n$ 是树的节点数量。
