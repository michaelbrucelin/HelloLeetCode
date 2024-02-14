### [颜色标记法-一种通用且简明的树遍历方法](https://leetcode.cn/problems/binary-tree-inorder-traversal/solutions/25220/yan-se-biao-ji-fa-yi-chong-tong-yong-qie-jian-ming/)

官方题解中介绍了三种方法来完成树的中序遍历，包括：

- 递归
- 借助栈的迭代方法
- 莫里斯遍历

在树的深度优先遍历中（包括前序、中序、后序遍历），递归方法最为直观易懂，但考虑到效率，我们通常不推荐使用递归。

栈迭代方法虽然提高了效率，但其嵌套循环却非常烧脑，不易理解，容易造成“**一看就懂，一写就废**”的窘况。而且对于不同的遍历顺序（前序、中序、后序），循环结构差异很大，更增加了记忆负担。

因此，我在这里介绍一种“颜色标记法”（瞎起的名字……），**兼具栈迭代方法的高效，又像递归方法一样简洁易懂，更重要的是，这种方法对于前序、中序、后序遍历，能够写出完全一致的代码**。

其核心思想如下：

- 使用颜色标记节点的状态，新节点为白色，已访问的节点为灰色。
- 如果遇到的节点为白色，则将其标记为灰色，然后将其右子节点、自身、左子节点依次入栈。
- 如果遇到的节点为灰色，则将节点的值输出。

使用这种方法实现的中序遍历如下：

```python
class Solution:
    def inorderTraversal(self, root: TreeNode) -> List[int]:
        WHITE, GRAY = 0, 1
        res = []
        stack = [(WHITE, root)]
        while stack:
            color, node = stack.pop()
            if node is None: continue
            if color == WHITE:
                stack.append((WHITE, node.right))
                stack.append((GRAY, node))
                stack.append((WHITE, node.left))
            else:
                res.append(node.val)
        return res
```

```csharp
public IList<int> InorderTraversal(TreeNode root)
{
    List<int> result = new List<int>();
    if (root == null) return result;

    Stack<(bool tag, TreeNode node)> stack = new Stack<(bool, TreeNode)>();  // true:白色, false:灰色
    stack.Push((true, root));
    while (stack.Count > 0)
    {
        var item = stack.Pop();
        if (item.node == null) continue;
        if (item.tag)
        {
            stack.Push((true, item.node.right));
            stack.Push((false, item.node));
            stack.Push((true, item.node.left));
        }
        else
            result.Add(item.node.val);
    }

    return result;
}
```

如要实现前序、后序遍历，只需要调整左右子节点的入栈顺序即可。
