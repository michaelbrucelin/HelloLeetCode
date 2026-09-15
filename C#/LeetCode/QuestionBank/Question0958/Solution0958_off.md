### [二叉树的完全性检验](https://leetcode.cn/problems/check-completeness-of-a-binary-tree/solutions/18187/er-cha-shu-de-wan-quan-xing-jian-yan-by-leetcode/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法 1：广度优先搜索

**想法**

这个问题可以简化成两个小问题：用 `(depth, position)` 元组表示每个节点的”位置“；确定如何定义所有节点都是在最左边的。

假如我们在深度为 $3$ 的行有 $4$ 个节点，位置为 $0$，1，$2$，3；那么就有 $8$ 个深度为 $4$ 的新节点位置在 $0$，1，$2$，3，$4$，5，$6$，7；所以我们可以找到规律：对于一个节点，它的左孩子为：`(depth, position) -> (depth + 1, position * 2)`，右孩子为 `(depth, position) -> (depth + 1, position * 2 + 1)`。所以，对于深度为 $d$ 的行恰好含有 $2^{d-1}$ 个节点，所有节点都是靠左边排列的当他们的位置编号是 `0, 1, ...` 且没有间隙。

一个更简单的表示深度和位置的方法是：用 `1` 表示根节点，对于任意一个节点 `v`，它的左孩子为 `2*v` 右孩子为 `2*v + 1`。这就是我们用的规则，在这个规则下，一颗二叉树是完全二叉树当且仅当节点编号依次为 `1, 2, 3, ...` 且没有间隙。

**算法**

对于根节点，我们定义其编号为 `1`。然后，对于每个节点 `v`，我们将其左节点编号为 `2 * v`，将其右节点编号为 `2 * v + 1`。

我们可以发现，树中所有节点的编号按照广度优先搜索顺序正好是升序。（也可以使用深度优先搜索，之后对序列排序）。

然后，我们检测编号序列是否为无间隔的 `1, 2, 3, \dots `，事实上，我们只需要检查最后一个编号是否正确，因为最后一个编号的值最大。

```Java
class Solution {
    public boolean isCompleteTree(TreeNode root) {
        List<ANode> nodes = new ArrayList();
        nodes.add(new ANode(root, 1));
        int i = 0;
        while (i < nodes.size()) {
            ANode anode = nodes.get(i++);
            if (anode.node != null) {
                nodes.add(new ANode(anode.node.left, anode.code * 2));
                nodes.add(new ANode(anode.node.right, anode.code * 2 + 1));
            }
        }

        return nodes.get(i-1).code == nodes.size();
    }
}

class ANode {  // Annotated Node
    TreeNode node;
    int code;
    ANode(TreeNode node, int code) {
        this.node = node;
        this.code = code;
    }
}
```

```Python
class Solution(object):
    def isCompleteTree(self, root):
        nodes = [(root, 1)]
        i = 0
        while i < len(nodes):
            node, v = nodes[i]
            i += 1
            if node:
                nodes.append((node.left, 2*v))
                nodes.append((node.right, 2*v+1))

        return  nodes[-1][1] == len(nodes)
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是树节点个数。
- 空间复杂度：$O(N)$。
