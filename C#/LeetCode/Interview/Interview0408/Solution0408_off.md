### [首个共同祖先](https://leetcode.cn/problems/first-common-ancestor-lcci/solutions/531807/shou-ge-gong-tong-zu-xian-by-leetcode-so-c2sl/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：深度优先搜索

**思路和算法**

我们递归遍历整棵二叉树，定义 $f_x$ 表示 $x$ 节点的子树中是否包含 $p$ 节点或 $q$ 节点，如果包含为 `true`，否则为 `false`。那么符合条件的首个共同祖先 $x$ 一定满足如下条件：

$$(f_{lson} \&\& f_{rson}) \vert \vert  ((x = p \vert \vert  x = q) \&\& (f_{lson} \vert \vert  f_{rson}))$$

其中 $lson$ 和 $rson$ 分别代表 $x$ 节点的左孩子和右孩子。初看可能会感觉条件判断有点复杂，我们来一条条看，$f_{lson} \&\& f_{rson}$ 说明左子树和右子树均包含 $p$ 节点或 $q$ 节点，如果左子树包含的是 $p$ 节点，那么右子树只能包含 $q$ 节点，反之亦然，因为 $p$ 节点和 $q$ 节点都是不同且唯一的节点，因此如果满足这个判断条件即可说明 $x$ 就是我们要找的首个共同祖先。再来看第二条判断条件，这个判断条件即是考虑了 $x$ 恰好是 $p$ 节点或 $q$ 节点且它的左子树或右子树有一个包含了另一个节点的情况，因此如果满足这个判断条件亦可说明 $x$ 就是我们要找的首个共同祖先。

你可能会疑惑这样找出来的公共祖先深度是否是最大的。其实是最大的，因为我们是自底向上从叶子节点开始更新的，所以在所有满足条件的公共祖先中一定是深度最大的祖先先被访问到，且由于 $f_x$ 本身的定义很巧妙，在找到首个共同祖先 $x$ 以后，$f_x$ 按定义被设置为 `true`，即假定了这个子树中只有一个 $p$ 节点或 $q$ 节点，因此其他公共祖先不会再被判断为符合条件。

下图展示了一个示例，搜索树中两个节点 `9` 和 `11` 的首个共同祖先。

![](./assets/img/Solution0408_off_01.png)
![](./assets/img/Solution0408_off_02.png)
![](./assets/img/Solution0408_off_03.png)
![](./assets/img/Solution0408_off_04.png)
![](./assets/img/Solution0408_off_05.png)
![](./assets/img/Solution0408_off_06.png)
![](./assets/img/Solution0408_off_07.png)
![](./assets/img/Solution0408_off_08.png)
![](./assets/img/Solution0408_off_09.png)
![](./assets/img/Solution0408_off_10.png)
![](./assets/img/Solution0408_off_11.PNG)

```C++
class Solution {
public:
    TreeNode* ans;
    bool dfs(TreeNode* root, TreeNode* p, TreeNode* q) {
        if (root == nullptr) return false;
        bool lson = dfs(root->left, p, q);
        bool rson = dfs(root->right, p, q);
        if ((lson && rson) || ((root->val == p->val || root->val == q->val) && (lson || rson))) {
            ans = root;
        }
        return lson || rson || (root->val == p->val || root->val == q->val);
    }
    TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q) {
        dfs(root, p, q);
        return ans;
    }
};
```

```JavaScript
var lowestCommonAncestor = function(root, p, q) {
    let ans;
    const dfs = (root, p, q) => {
        if (root === null) return false;
        const lson = dfs(root.left, p, q);
        const rson = dfs(root.right, p, q);
        if ((lson && rson) || ((root.val === p.val || root.val === q.val) && (lson || rson))) {
            ans = root;
        }
        return lson || rson || (root.val === p.val || root.val === q.val);
    }
    dfs(root, p, q);
    return ans;
};
```

```Java
class Solution {

    private TreeNode ans;

    public Solution() {
        this.ans = null;
    }

    private boolean dfs(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null) return false;
        boolean lson = dfs(root.left, p, q);
        boolean rson = dfs(root.right, p, q);
        if ((lson && rson) || ((root.val == p.val || root.val == q.val) && (lson || rson))) {
            ans = root;
        }
        return lson || rson || (root.val == p.val || root.val == q.val);
    }

    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        this.dfs(root, p, q);
        return this.ans;
    }
}
```

```Go
func lowestCommonAncestor(root, p, q *TreeNode) *TreeNode {
    if root == nil {
        return nil
    }
    if root.Val == p.Val || root.Val == q.Val {
        return root
    }
    left := lowestCommonAncestor(root.Left, p, q)
    right := lowestCommonAncestor(root.Right, p, q)
    if left != nil && right != nil {
        return root
    }
    if left == nil {
        return right
    }
    return left
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是二叉树的节点数。二叉树的所有节点有且只会被访问一次，因此时间复杂度为 $O(N)$。
- 空间复杂度：$O(N)$，其中 $N$ 是二叉树的节点数。递归调用的栈深度取决于二叉树的高度，二叉树最坏情况下为一条链，此时高度为 $N$，因此空间复杂度为 $O(N)$。
