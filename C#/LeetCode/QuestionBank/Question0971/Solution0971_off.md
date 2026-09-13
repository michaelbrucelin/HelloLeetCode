### [翻转二叉树以匹配先序遍历](https://leetcode.cn/problems/flip-binary-tree-to-match-preorder-traversal/solutions/3583/fan-zhuan-er-cha-shu-yi-pi-pei-xian-xu-bian-li-by-/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法：深度优先搜索

**思路**

当做先序遍历的时候，我们可能会翻转某一个节点，尝试使我们当前的遍历序列与给定的行程序列相匹配。

如果我们希望先序遍历序列的下一个数字是 `voyage[i]`，那么至多只有一种可行的遍历路径供我们选择，因为所有节点的值都不相同。

**算法**

进行深度优先遍历。如果遍历到某一个节点的时候，节点值不能与行程序列匹配，那么答案一定是 `[-1]`。

否则，当行程序列中的下一个期望数字 `voyage[i]` 与我们即将遍历的子节点的值不同的时候，我们就要翻转一下当前这个节点。

```Java
class Solution {
    List<Integer> flipped;
    int index;
    int[] voyage;

    public List<Integer> flipMatchVoyage(TreeNode root, int[] voyage) {
        flipped = new ArrayList();
        index = 0;
        this.voyage = voyage;

        dfs(root);
        if (!flipped.isEmpty() && flipped.get(0) == -1) {
            flipped.clear();
            flipped.add(-1);
        }

        return flipped;
    }

    public void dfs(TreeNode node) {
        if (node != null) {
            if (node.val != voyage[index++]) {
                flipped.clear();
                flipped.add(-1);
                return;
            }

            if (index < voyage.length && node.left != null &&
                    node.left.val != voyage[index]) {
                flipped.add(node.val);
                dfs(node.right);
                dfs(node.left);
            } else {
                dfs(node.left);
                dfs(node.right);
            }
        }
    }
}
```

```Python
class Solution(object):
    def flipMatchVoyage(self, root, voyage):
        self.flipped = []
        self.i = 0

        def dfs(node):
            if node:
                if node.val != voyage[self.i]:
                    self.flipped = [-1]
                    return
                self.i += 1

                if (self.i < len(voyage) and
                        node.left and node.left.val != voyage[self.i]):
                    self.flipped.append(node.val)
                    dfs(node.right)
                    dfs(node.left)
                else:
                    dfs(node.left)
                    dfs(node.right)

        dfs(root)
        if self.flipped and self.flipped[0] == -1:
            self.flipped = [-1]
        return self.flipped
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是给定树中节点的数量。
- 空间复杂度：$O(N)$。
