### [分裂二叉树的最大乘积](https://leetcode.cn/problems/maximum-product-of-splitted-binary-tree/solutions/130598/fen-lie-er-cha-shu-de-zui-da-cheng-ji-by-leetcode/)

#### 方法一：数学

记二叉树中所有元素的值之和为 `sum_r`。

假设我们删除的边的两个端点为 `u` 和 `v`，其中 `u` 是 `v` 的父节点，那么在这条边删除之后，其中的一棵子树以 `v` 为根节点，记其中所有元素之和为 `sum_v`；另一棵子树以原二叉树的根节点 `root` 为根节点，其中元素之和为 `sum_r - sum_v`。我们需要找到一个节点 `v`，使得 <code>(sum_v) &times; (sum_r - sum_v)</code> 的值最大。

那么我们如何找到这个节点呢？我们首先使用深度优先搜索计算出 `sum_r`，即遍历二叉树中的每一个节点，将其对应的元素值进行累加。随后我们再次使用深度优先搜索，通过递归的方式计算出每一个节点 `v` 对应的子树元素之和 `sum_v`，并求出所有 <code>(sum_v) &times; (sum_r - sum_v)</code> 中的最大值，就可以得到答案。

由于题目中需要将结果对 `10^9+7` 取模，我们需要注意的是，不能在计算 <code>(sum_v) &times; (sum_r - sum_v)</code> 时将其直接对 `10^9+7` 取模，这是因为原先较大的数，取模之后不一定仍然较大。这一步可以有两种解决方案：

- 我们用 $64$ 位的整数类型（例如 `long`，`long $long`$ 等）计算和存储 <code>(sum_v) &times; (sum_r - sum_v)</code> 的值，并在最后对 `10^9+7` 取模；
- 我们使用均值不等式的知识，当 `sum_r` 为定值时，`sum_v` 越接近 `sum_r` 的一半，<code>(sum_v) &times; (sum_r - sum_v)</code> 的值越大。我们只需要存储最接近 `sum_r` 的一半的那个 `sum_v`，在最后计算 <code>(sum_v) &times; (sum_r - sum_v)</code> 的值并对 <code>10<sup>9</sup>+7</code> 取模。

```C++
class Solution {
private:
    int sum = 0;
    int best = 0;

public:
    void dfs(TreeNode* node) {
        if (!node) {
            return;
        }
        sum += node->val;
        dfs(node->left);
        dfs(node->right);
    }

    int dfs2(TreeNode* node) {
        if (!node) {
            return 0;
        }
        int cur = dfs2(node->left) + dfs2(node->right) + node->val;
        if (abs(cur*2 - sum) < abs(best*2 - sum)) {
            best = cur;
        }
        return cur;
    }

    int maxProduct(TreeNode* root) {
        dfs(root);
        dfs2(root);
        return (long long)best * (sum - best) % 1000000007;
    }
};
```

```Java
class Solution {
    private int sum = 0;
    private int best = 0;

    public int maxProduct(TreeNode root) {
        dfs(root);
        dfs2(root);
        return (int)((long)best * (sum - best) % 1000000007);
    }

    private void dfs(TreeNode node) {
        if (node == null) {
            return;
        }
        sum += node.val;
        dfs(node.left);
        dfs(node.right);
    }

    private int dfs2(TreeNode node) {
        if (node == null) {
            return 0;
        }
        int cur = dfs2(node.left) + dfs2(node.right) + node.val;
        if (Math.abs(cur * 2 - sum) < Math.abs(best * 2 - sum)) {
            best = cur;
        }
        return cur;
    }
}
```

```CSharp
public class Solution {
    private int sum = 0;
    private int best = 0;

    public int MaxProduct(TreeNode root) {
        Dfs(root);
        Dfs2(root);
        return (int)((long)best * (sum - best) % 1000000007);
    }

    private void Dfs(TreeNode node) {
        if (node == null) {
            return;
        }
        sum += node.val;
        Dfs(node.left);
        Dfs(node.right);
    }

    private int Dfs2(TreeNode node) {
        if (node == null) {
            return 0;
        }
        int cur = Dfs2(node.left) + Dfs2(node.right) + node.val;
        if (Math.Abs(cur * 2 - sum) < Math.Abs(best * 2 - sum)) {
            best = cur;
        }
        return cur;
    }
}
```

```Go
func maxProduct(root *TreeNode) int {
    sum := 0
    best := 0

    var dfs func(*TreeNode)
    dfs = func(node *TreeNode) {
        if node == nil {
            return
        }
        sum += node.Val
        dfs(node.Left)
        dfs(node.Right)
    }

    var dfs2 func(*TreeNode) int
    dfs2 = func(node *TreeNode) int {
        if node == nil {
            return 0
        }
        cur := dfs2(node.Left) + dfs2(node.Right) + node.Val
        if abs(cur*2 - sum) < abs(best*2 - sum) {
            best = cur
        }
        return cur
    }

    dfs(root)
    dfs2(root)
    return best * (sum - best) % 1000000007
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```Python
class Solution:
    def maxProduct(self, root: Optional[TreeNode]) -> int:
        self.sum = 0
        self.best = 0

        def dfs(node):
            if not node:
                return
            self.sum += node.val
            dfs(node.left)
            dfs(node.right)

        def dfs2(node):
            if not node:
                return 0
            cur = dfs2(node.left) + dfs2(node.right) + node.val
            if abs(cur * 2 - self.sum) < abs(self.best * 2 - self.sum):
                self.best = cur
            return cur

        dfs(root)
        dfs2(root)
        return self.best * (self.sum - self.best) % 1000000007
```

```C
void dfs(struct TreeNode* node, int *sum) {
    if (!node) {
        return;
    }
    *sum += node->val;
    dfs(node->left, sum);
    dfs(node->right, sum);
}

int dfs2(struct TreeNode* node, int *sum, int *best) {
    if (!node) {
        return 0;
    }
    int cur = dfs2(node->left, sum, best) + dfs2(node->right, sum, best) + node->val;
    if (abs(cur * 2 - *sum) < abs(*best * 2 - *sum)) {
        *best = cur;
    }
    return cur;
}

int maxProduct(struct TreeNode* root) {
    int sum = 0, best = 0;
    best = 0;
    dfs(root, &sum);
    dfs2(root, &sum, &best);
    return (long long)best * (sum - best) % 1000000007;
}
```

```JavaScript
var maxProduct = function(root) {
    let sum = 0;
    let best = 0;

    const dfs = (node) => {
        if (!node) return;
        sum += node.val;
        dfs(node.left);
        dfs(node.right);
    };

    const dfs2 = (node) => {
        if (!node) return 0;
        const cur = dfs2(node.left) + dfs2(node.right) + node.val;
        if (Math.abs(cur * 2 - sum) < Math.abs(best * 2 - sum)) {
            best = cur;
        }
        return cur;
    };

    dfs(root);
    dfs2(root);
    return Number((BigInt(best) * BigInt(sum - best)) % 1000000007n);
};
```

```TypeScript
function maxProduct(root: TreeNode | null): number {
    let sum = 0;
    let best = 0;

    const dfs = (node: TreeNode | null): void => {
        if (!node) return;
        sum += node.val;
        dfs(node.left);
        dfs(node.right);
    };

    const dfs2 = (node: TreeNode | null): number => {
        if (!node) return 0;
        const cur = dfs2(node.left) + dfs2(node.right) + node.val;
        if (Math.abs(cur * 2 - sum) < Math.abs(best * 2 - sum)) {
            best = cur;
        }
        return cur;
    };

    dfs(root);
    dfs2(root);
    return Number((BigInt(best) * BigInt(sum - best)) % 1000000007n);
}
```

```Rust
use std::rc::Rc;
use std::cell::RefCell;

impl Solution {
    pub fn max_product(root: Option<Rc<RefCell<TreeNode>>>) -> i32 {
        let mut sum = 0;
        let mut best = 0;

        fn dfs(node: &Option<Rc<RefCell<TreeNode>>>, sum: &mut i32) {
            if let Some(n) = node {
                let node_ref = n.borrow();
                *sum += node_ref.val;
                dfs(&node_ref.left, sum);
                dfs(&node_ref.right, sum);
            }
        }

        fn dfs2(node: &Option<Rc<RefCell<TreeNode>>>, sum: i32, best: &mut i32) -> i32 {
            if let Some(n) = node {
                let node_ref = n.borrow();
                let cur = dfs2(&node_ref.left, sum, best) +
                         dfs2(&node_ref.right, sum, best) +
                         node_ref.val;
                if (cur * 2 - sum).abs() < (*best * 2 - sum).abs() {
                    *best = cur;
                }
                cur
            } else {
                0
            }
        }

        dfs(&root, &mut sum);
        dfs2(&root, sum, &mut best);
        ((best as i64) * ((sum - best) as i64) % 1000000007) as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是二叉树的节点个数。
- 空间复杂度：$O(1)$。
