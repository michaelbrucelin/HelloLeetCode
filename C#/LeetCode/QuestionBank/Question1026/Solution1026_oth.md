﻿### [两种方法：自顶向下/自底向上（Python/Java/C++/Go）](https://leetcode.cn/problems/maximum-difference-between-node-and-ancestor/solutions/2232367/liang-chong-fang-fa-zi-ding-xiang-xia-zi-wj9v/)

#### 前置知识：二叉树与递归

见[【基础算法精讲 09】](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1UD4y1Y769%2F)。

> APP 用户需要分享到 wx 打开链接。

#### 方法一：「递」

如果节点 $A$ 在从根节点到节点 $B$ 的**路径**上，则称 $A$ 是 $B$ 的**祖先**节点，称 $B$ 是 $A$ 的**子孙**节点。

> 注：在这个定义中，$B$ 的祖先节点可以是 $B$ 自己。例如示例 1 中 $6$ 的祖先节点自上而下依次为 $8,3,6$。
>  
> 注 2：虽然题目要求「不同节点」，但计算的是**最大**差值，相同节点算出来的差值为 $0$，不影响最大差值。

对于题目给出的公式 $V = |A.val - B.val|$，为了让 $V$ 尽量大，分类讨论：

- 如果 $A.val < B.val$，那么 $A.val$ 越小，$V$ 越大。
- 如果 $A.val \ge B.val$，那么 $A.val$ 越大，$V$ 越大；

因此，无需记录递归路径中的全部节点值，只需要记录递归路径中的最小值 $mn$ 和最大值 $mx$。

每递归到一个节点 $B$，计算

$$\max(|mn-B.val|,|mx-B.val|)$$

并更新答案的最大值。

由于 $mn \le B.val \le mx$，上式可化简为

$$\max(B.val-mn,mx-B.val)$$

```python
class Solution:
    def maxAncestorDiff(self, root: Optional[TreeNode]) -> int:
        ans = 0
        def dfs(node: Optional[TreeNode], mn: int, mx: int) -> None:
            if node is None: return
            # 虽然题目要求「不同节点」，但是相同节点的差值为 0，不会影响最大差值
            # 所以先更新 mn 和 mx，再计算差值也是可以的
            # 在这种情况下，一定满足 mn <= node.val <= mx
            mn = min(mn, node.val)
            mx = max(mx, node.val)
            nonlocal ans
            ans = max(ans, node.val - mn, mx - node.val)
            dfs(node.left, mn, mx)
            dfs(node.right, mn, mx)
        dfs(root, root.val, root.val)
        return ans
```

```java
class Solution {
    private int ans;

    public int maxAncestorDiff(TreeNode root) {
        dfs(root, root.val, root.val);
        return ans;
    }

    private void dfs(TreeNode node, int mn, int mx) {
        if (node == null) return;
        // 虽然题目要求「不同节点」，但是相同节点的差值为 0，不会影响最大差值
        // 所以先更新 mn 和 mx，再计算差值也是可以的
        // 在这种情况下，一定满足 mn <= node.val <= mx
        mn = Math.min(mn, node.val);
        mx = Math.max(mx, node.val);
        ans = Math.max(ans, Math.max(node.val - mn, mx - node.val));
        dfs(node.left, mn, mx);
        dfs(node.right, mn, mx);
    }
}
```

```cpp
class Solution {
    int ans = 0;

    void dfs(TreeNode *node, int mn, int mx) {
        if (node == nullptr) return;
        // 虽然题目要求「不同节点」，但是相同节点的差值为 0，不会影响最大差值
        // 所以先更新 mn 和 mx，再计算差值也是可以的
        // 在这种情况下，一定满足 mn <= node.val <= mx
        mn = min(mn, node->val);
        mx = max(mx, node->val);
        ans = max(ans, max(node->val - mn, mx - node->val));
        dfs(node->left, mn, mx);
        dfs(node->right, mn, mx);
    }

public:
    int maxAncestorDiff(TreeNode *root) {
        dfs(root, root->val, root->val);
        return ans;
    }
};
```

```go
func maxAncestorDiff(root *TreeNode) (ans int) {
    var dfs func(*TreeNode, int, int)
    dfs = func(node *TreeNode, mn, mx int) {
        if node == nil {
            return
        }
        // 虽然题目要求「不同节点」，但是相同节点的差值为 0，不会影响最大差值
        // 所以先更新 mn 和 mx，再计算差值也是可以的
        // 在这种情况下，一定满足 mn <= node.val <= mx
        mn = min(mn, node.Val)
        mx = max(mx, node.Val)
        ans = max(ans, max(node.Val-mn, mx-node.Val))
        dfs(node.Left, mn, mx)
        dfs(node.Right, mn, mx)
    }
    dfs(root, root.Val, root.Val)
    return
}

func min(a, b int) int { if a > b { return b }; return a }
func max(a, b int) int { if a < b { return b }; return a }
```

#### 优化

换个角度看问题：对于一条从根出发向下的路径，我们要计算的实际上是这条路径上任意两点的最大差值。

递归到叶子时，$mx$ 是从根到叶子的路径上的最大值，$mn$ 是从根到叶子的路径上的最小值，所以 mx−mnmx-mnmx−mn 就是从根到叶子的路径上任意两点的最大差值。

所以无需每个节点都去更新答案，而是在递归到终点时才去更新答案。

```python
class Solution:
    def maxAncestorDiff(self, root: Optional[TreeNode]) -> int:
        ans = 0
        def dfs(node: Optional[TreeNode], mn: int, mx: int) -> None:
            if node is None:
                nonlocal ans
                ans = max(ans, mx - mn)
                return
            mn = min(mn, node.val)
            mx = max(mx, node.val)
            dfs(node.left, mn, mx)
            dfs(node.right, mn, mx)
        dfs(root, root.val, root.val)
        return ans
```

```java
class Solution {
    private int ans;

    public int maxAncestorDiff(TreeNode root) {
        dfs(root, root.val, root.val);
        return ans;
    }

    private void dfs(TreeNode node, int mn, int mx) {
        if (node == null) {
            ans = Math.max(ans, mx - mn);
            return;
        }
        mn = Math.min(mn, node.val);
        mx = Math.max(mx, node.val);
        dfs(node.left, mn, mx);
        dfs(node.right, mn, mx);
    }
}
```

```cpp
class Solution {
    int ans = 0;

    void dfs(TreeNode *node, int mn, int mx) {
        if (node == nullptr) {
            ans = max(ans, mx - mn);
            return;
        }
        mn = min(mn, node->val);
        mx = max(mx, node->val);
        dfs(node->left, mn, mx);
        dfs(node->right, mn, mx);
    }

public:
    int maxAncestorDiff(TreeNode *root) {
        dfs(root, root->val, root->val);
        return ans;
    }
};
```

```go
func maxAncestorDiff(root *TreeNode) (ans int) {
    var dfs func(*TreeNode, int, int)
    dfs = func(node *TreeNode, mn, mx int) {
        if node == nil {
            ans = max(ans, mx-mn)
            return
        }
        mn = min(mn, node.Val)
        mx = max(mx, node.Val)
        dfs(node.Left, mn, mx)
        dfs(node.Right, mn, mx)
    }
    dfs(root, root.Val, root.Val)
    return
}

func min(a, b int) int { if a > b { return b }; return a }
func max(a, b int) int { if a < b { return b }; return a }
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为二叉树的节点个数。
- 空间复杂度：$O(n)$。最坏情况下，二叉树退化成一条链，递归需要 $O(n)$ 的栈空间。

#### 方法二：「归」

方法一的思路是维护 $B$ 的祖先节点中的最小值和最大值，我们还可以站在 $A$ 的视角，维护 $A$ 的子孙节点中的最小值 $mn$ 和最大值 $mx$。

换句话说，最小值和最大值不再作为入参，而是作为返回值，意思是以 $A$ 为根的子树中的最小值和最大值。

递归到节点 $A$ 时，初始化 $mn$ 和 $mx$ 为 $A.val$，然后递归左右子树，拿到左右子树的最小值和最大值，去更新 $mn$ 和 $mx$，然后计算

$$\max(|mn-A.val|,|mx-A.val|)$$

并更新答案的最大值。

由于 $mn \le A.val \le mx$，上式可化简为

$$\max(A.val-mn,mx-A.val)$$

```python
class Solution:
    def maxAncestorDiff(self, root: Optional[TreeNode]) -> int:
        ans = 0
        def dfs(node: Optional[TreeNode]) -> (int, int):
            if node is None:
                return inf, -inf  # 保证空节点不影响 mn 和 mx
            mn = mx = node.val
            l_mn, l_mx = dfs(node.left)
            r_mn, r_mx = dfs(node.right)
            mn = min(mn, l_mn, r_mn)
            mx = max(mx, l_mx, r_mx)
            nonlocal ans
            ans = max(ans, node.val - mn, mx - node.val)
            return mn, mx
        dfs(root)
        return ans
```

```java
class Solution {
    private int ans;

    public int maxAncestorDiff(TreeNode root) {
        dfs(root);
        return ans;
    }

    private int[] dfs(TreeNode node) {
        if (node == null) // 需要保证空节点不影响 mn 和 mx
            return new int[]{Integer.MAX_VALUE, Integer.MIN_VALUE};
        int mn = node.val, mx = mn;
        var p = dfs(node.left);
        var q = dfs(node.right);
        mn = Math.min(mn, Math.min(p[0], q[0]));
        mx = Math.max(mx, Math.max(p[1], q[1]));
        ans = Math.max(ans, Math.max(node.val - mn, mx - node.val));
        return new int[]{mn, mx};
    }
}
```

```cpp
class Solution {
    int ans = 0;

    pair<int, int> dfs(TreeNode *node) {
        if (node == nullptr)
            return {INT_MAX, INT_MIN}; // 保证空节点不影响 mn 和 mx
        int mn = node->val, mx = mn;
        auto [l_mn, l_mx] = dfs(node->left);
        auto [r_mn, r_mx] = dfs(node->right);
        mn = min(mn, min(l_mn, r_mn));
        mx = max(mx, max(l_mx, r_mx));
        ans = max(ans, max(node->val - mn, mx - node->val));
        return {mn, mx};
    }

public:
    int maxAncestorDiff(TreeNode *root) {
        dfs(root);
        return ans;
    }
};
```

```go
func maxAncestorDiff(root *TreeNode) (ans int) {
    var dfs func(*TreeNode) (int, int)
    dfs = func(node *TreeNode) (int, int) {
        if node == nil {
            return math.MaxInt, math.MinInt // 保证空节点不影响 mn 和 mx
        }
        mn, mx := node.Val, node.Val
        lMn, lMx := dfs(node.Left)
        rMn, rMx := dfs(node.Right)
        mn = min(mn, min(lMn, rMn))
        mx = max(mx, max(lMx, rMx))
        ans = max(ans, max(node.Val-mn, mx-node.Val))
        return mn, mx
    }
    dfs(root)
    return
}

func min(a, b int) int { if a > b { return b }; return a }
func max(a, b int) int { if a < b { return b }; return a }
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为二叉树的节点个数。
- 空间复杂度：$O(n)$。最坏情况下，二叉树退化成一条链，递归需要 $O(n)$ 的栈空间。

#### 练习

用「递」和「归」两种思路，解决如下题目：

- [104\. 二叉树的最大深度](https://leetcode.cn/problems/maximum-depth-of-binary-tree/) | [视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV1UD4y1Y769%2F)
- [98\. 验证二叉搜索树](https://leetcode.cn/problems/validate-binary-search-tree/) | [视频讲解](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.bilibili.com%2Fvideo%2FBV14G411P7C1%2F)
