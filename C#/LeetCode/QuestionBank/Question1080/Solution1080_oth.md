#### [简洁写法，调用自身！（Python/Java/C++/Go）](https://leetcode.cn/problems/insufficient-nodes-in-root-to-leaf-paths/solutions/2278769/jian-ji-xie-fa-diao-yong-zi-shen-pythonj-64lf/)

#### 视频讲解

1.  [如何思考递归？【基础算法精讲 09】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1UD4y1Y769%2F)
2.  [如何灵活运用递归？【基础算法精讲 10】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV18M411z7bb%2F)

> 制作不易，欢迎点赞！APP 用户如果无法打开，可以分享到微信。

#### 一、思考

对于一个叶子节点，要想删除它，需要满足什么条件？

对于一个非叶节点，如果它有一个儿子没被删除，那么它能被删除吗？如果它的儿子都被删除，意味着什么？

#### 二、解惑

对于一个叶子节点 $leaf$，由于根到 $leaf$ 的路径仅有一条，所以如果这条路径的元素和小于 $limit$，就删除 $leaf$。

对于一个非叶节点 $node$，如果 $node$ 有一个儿子没被删除，那么 $node$ 就不能被删除。这可以用反证法证明：假设可以把 $node$ 删除，那么经过 $node$ 的所有路径和都小于 $limit$，也就意味着经过 $node$ 的儿子的路径和也小于 $limit$，说明 $node$ 的儿子需要被删除，矛盾，所以 $node$ 不能被删除。

如果 $node$ 的儿子都被删除，说明经过 $node$ 的所有儿子的路径和都小于 $limit$，这等价于经过 $node$ 的所有路径和都小于 $limit$，所以 $node$ 需要被删除。

因此，要删除非叶节点 $node$，当且仅当 $node$ 的所有儿子都被删除。

#### 三、算法

一个直接的想法是，添加一个递归参数 $sumPath$，表示从根到当前节点的路径和。

但为了能直接调用 $sufficientSubset$，还可以从 $limit$ 中减去当前节点值。

如果当前节点是叶子，且此时 $limit>0$，说明从根到这个叶子的路径和小于 $limit$，那么删除这个叶子。

如果当前节点不是叶子，那么往下递归，更新它的左儿子为对左儿子调用 $sufficientSubset$ 的结果，更新它的右儿子为对右儿子调用 $sufficientSubset$ 的结果。

如果左右儿子都为空，那么就删除当前节点，返回空；否则不删，返回当前节点。

```python
class Solution:
    def sufficientSubset(self, root: Optional[TreeNode], limit: int) -> Optional[TreeNode]:
        limit -= root.val
        if root.left is root.right:  # root 是叶子
            # 如果 limit > 0 说明从根到叶子的路径和小于 limit，删除叶子，否则不删除
            return None if limit > 0 else root
        if root.left: root.left = self.sufficientSubset(root.left, limit)
        if root.right: root.right = self.sufficientSubset(root.right, limit)
        # 如果有儿子没被删除，就不删 root，否则删 root
        return root if root.left or root.right else None
```

```java
class Solution {
    public TreeNode sufficientSubset(TreeNode root, int limit) {
        limit -= root.val;
        if (root.left == root.right) // root 是叶子
            // 如果 limit > 0 说明从根到叶子的路径和小于 limit，删除叶子，否则不删除
            return limit > 0 ? null : root;
        if (root.left != null) root.left = sufficientSubset(root.left, limit);
        if (root.right != null) root.right = sufficientSubset(root.right, limit);
        // 如果儿子都被删除，就删 root，否则不删 root
        return root.left == null && root.right == null ? null : root;
    }
}
```

```cpp
class Solution {
public:
    TreeNode *sufficientSubset(TreeNode *root, int limit) {
        limit -= root->val;
        if (root->left == root->right) // root 是叶子
            // 如果 limit > 0 说明从根到叶子的路径和小于 limit，删除叶子，否则不删除
            return limit > 0 ? nullptr : root;
        if (root->left) root->left = sufficientSubset(root->left, limit);
        if (root->right) root->right = sufficientSubset(root->right, limit);
        // 如果有儿子没被删除，就不删 root，否则删 root
        return root->left || root->right ? root : nullptr;
    }
};
```

```go
func sufficientSubset(root *TreeNode, limit int) *TreeNode {
    if root == nil {
        return nil
    }
    limit -= root.Val
    if root.Left == root.Right { // root 是叶子
        if limit > 0 { // 从根到叶子的路径和小于 limit，删除叶子
            return nil
        }
        return root // 否则不删除
    }
    root.Left = sufficientSubset(root.Left, limit)
    root.Right = sufficientSubset(root.Right, limit)
    if root.Left == nil && root.Right == nil { // 如果儿子都被删除，就删 root
        return nil
    }
    return root // 否则不删 root
}
```

#### 复杂度分析

-   时间复杂度：$\mathcal{O}(n)$，其中 $n$ 为二叉树的节点个数。
-   空间复杂度：$\mathcal{O}(n)$。最坏情况下，二叉树是一条链，递归需要 $\mathcal{O}(n)$ 的栈空间。
