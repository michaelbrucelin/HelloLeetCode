### [统计值等于子树平均值的节点数](https://leetcode.cn/problems/count-nodes-equal-to-average-of-subtree/solutions/4018468/tong-ji-zhi-deng-yu-zi-shu-ping-jun-zhi-xzfhi/)

#### 方法一：深度优先搜索

**思路与算法**

本题是用「深度优先搜索」来计算子树中节点数量 $Size$ 以及子树中每个节点值的总和 $Sum$。使用「深度优先搜索」在遍历子树节点时维护这两个状态即可。对于当前子树 $node$，如果其中节点值的平均值等于子树 $node$ 根节点的值，那么答案加一，否则不修改答案。

子树中节点数量 $Size$ 可以通过左子树节点数量 $leftSize +$ 右子树节点数量 $rightSize +$ 根节点来计算。

子树中每个节点值的总和 $Sum$ 可以通过左子树节点值之和 $leftSum +$ 右子树节点值之和 $rightSum +$ 当前子树根节点值 $node\rightarrow val$ 来计算。

```C++
class Solution {
public:
    int averageOfSubtree(TreeNode* root) {
        int ans = 0;
        auto dfs = [&](auto&& dfs, TreeNode* node) -> pair<int, int> {
            if (!node) {
                return {0, 0};
            }
            auto [leftSum, leftSize] = dfs(dfs, node->left);
            auto [rightSum, rightSize] = dfs(dfs, node->right);
            int Size = leftSize + rightSize + 1;
            int Sum = leftSum + rightSum + node->val;
            if (Size && Sum / Size == node->val) {
                ans++;
            }
            return {Sum, Size};
        };
        dfs(dfs, root);
        return ans;
    }
};
```

```Go
func averageOfSubtree(root *TreeNode) int {
    ans := 0
    var dfs func(*TreeNode) (int, int)
    dfs = func(node *TreeNode) (int, int) {
        if node == nil {
            return 0, 0
        }
        leftSum, leftSize := dfs(node.Left)
        rightSum, rightSize := dfs(node.Right)
        Size := leftSize + rightSize + 1
        Sum := leftSum + rightSum + node.Val
        if Size > 0 && Sum/Size == node.Val {
            ans++
        }
        return Sum, Size
    }
    dfs(root)
    return ans
}
```

```Python
class Solution:
    def averageOfSubtree(self, root: Optional[TreeNode]) -> int:
        ans = 0

        def dfs(node: Optional[TreeNode]) -> tuple[int, int]:
            nonlocal ans
            if node is None:
                return 0, 0
            leftSum, leftSize = dfs(node.left)
            rightSum, rightSize = dfs(node.right)
            Size = leftSize + rightSize + 1
            Sum = leftSum + rightSum + node.val
            if Size and Sum // Size == node.val:
                ans += 1
            return Sum, Size

        dfs(root)
        return ans
```

```Java
class Solution {
    private int ans;

    public int averageOfSubtree(TreeNode root) {
        ans = 0;
        dfs(root);
        return ans;
    }

    private int[] dfs(TreeNode node) {
        if (node == null) {
            return new int[] { 0, 0 };
        }
        int[] left = dfs(node.left);
        int leftSum = left[0];
        int leftSize = left[1];
        int[] right = dfs(node.right);
        int rightSum = right[0];
        int rightSize = right[1];
        int Size = leftSize + rightSize + 1;
        int Sum = leftSum + rightSum + node.val;
        if (Size > 0 && Sum / Size == node.val) {
            ans++;
        }
        return new int[] { Sum, Size };
    }
}
```

```CSharp
public class Solution {
    private int ans;

    public int AverageOfSubtree(TreeNode root) {
        ans = 0;
        Dfs(root);
        return ans;
    }

    private (int Sum, int Size) Dfs(TreeNode node) {
        if (node == null) {
            return (0, 0);
        }
        var (leftSum, leftSize) = Dfs(node.left);
        var (rightSum, rightSize) = Dfs(node.right);
        int Size = leftSize + rightSize + 1;
        int Sum = leftSum + rightSum + node.val;
        if (Size > 0 && Sum / Size == node.val) {
            ans++;
        }
        return (Sum, Size);
    }
}
```

```C
struct Pair {
    int Sum;
    int Size;
};

struct Pair dfs(struct TreeNode* node, int* ans) {
    if (node == NULL) {
        return (struct Pair){0, 0};
    }
    struct Pair left = dfs(node->left, ans);
    struct Pair right = dfs(node->right, ans);
    int Size = left.Size + right.Size + 1;
    int Sum = left.Sum + right.Sum + node->val;
    if (Size > 0 && Sum / Size == node->val) {
        (*ans)++;
    }
    return (struct Pair){Sum, Size};
}

int averageOfSubtree(struct TreeNode* root) {
    int ans = 0;
    dfs(root, &ans);
    return ans;
}
```

```JavaScript
function averageOfSubtree(root) {
    let ans = 0;

    function dfs(node) {
        if (node === null) {
            return [0, 0];
        }
        const [leftSum, leftSize] = dfs(node.left);
        const [rightSum, rightSize] = dfs(node.right);
        const Size = leftSize + rightSize + 1;
        const Sum = leftSum + rightSum + node.val;
        if (Size > 0 && Math.floor(Sum / Size) === node.val) {
            ans++;
        }
        return [Sum, Size];
    }

    dfs(root);
    return ans;
}
```

```TypeScript
function averageOfSubtree(root: TreeNode | null): number {
    let ans = 0;

    function dfs(node: TreeNode | null): [number, number] {
        if (node === null) {
            return [0, 0];
        }
        const [leftSum, leftSize] = dfs(node.left);
        const [rightSum, rightSize] = dfs(node.right);
        const Size = leftSize + rightSize + 1;
        const Sum = leftSum + rightSum + node.val;
        if (Size > 0 && Math.floor(Sum / Size) === node.val) {
            ans++;
        }
        return [Sum, Size];
    }

    dfs(root);
    return ans;
}
```

```Rust
use std::rc::Rc;
use std::cell::RefCell;
impl Solution {
    pub fn average_of_subtree(root: Option<Rc<RefCell<TreeNode>>>) -> i32 {
        let mut ans = 0;
        Self::dfs(&root, &mut ans);
        ans
    }
    fn dfs(node: &Option<Rc<RefCell<TreeNode>>>, ans: &mut i32) -> (i32, i32) {
        match node {
            None => (0, 0),
            Some(node) => {
                let node = node.borrow();
                let (leftSum, leftSize) = Self::dfs(&node.left, ans);
                let (rightSum, rightSize) = Self::dfs(&node.right, ans);
                let Size = leftSize + rightSize + 1;
                let Sum = leftSum + rightSum + node.val;
                if Size > 0 && Sum / Size == node.val {
                    *ans += 1;
                }
                (Sum, Size)
            }
        }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为二叉树中节点的数量，在「深度优先搜索」的过程中，每个节点只会访问一次。
- 空间复杂度：$O(n)$，其中 $n$ 为二叉树中节点的数量，「深度优先搜索」的递归栈大小最差情况下为 $O(n)$。
