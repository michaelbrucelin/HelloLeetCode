#### [��ɫ��Ƿ�-һ��ͨ���Ҽ���������������](https://leetcode.cn/problems/binary-tree-inorder-traversal/solutions/25220/yan-se-biao-ji-fa-yi-chong-tong-yong-qie-jian-ming/)

�ٷ�����н��������ַ�����������ĺ��������������
-   �ݹ�
-   ����ջ�ĵ�������
-   Ī��˹����

������������ȱ����У�����ǰ�����򡢺�����������ݹ鷽����Ϊֱ���׶��������ǵ�Ч�ʣ�����ͨ�����Ƽ�ʹ�õݹ顣

ջ����������Ȼ�����Ч�ʣ�����Ƕ��ѭ��ȴ�ǳ����ԣ�������⣬������ɡ�**һ���Ͷ���һд�ͷ�**���ľ��������Ҷ��ڲ�ͬ�ı���˳��ǰ�����򡢺��򣩣�ѭ���ṹ����ܴ󣬸������˼��为����

��ˣ������������һ�֡���ɫ��Ƿ�����Ϲ������֡�������**���ջ���������ĸ�Ч������ݹ鷽��һ������׶�������Ҫ���ǣ����ַ�������ǰ�����򡢺���������ܹ�д����ȫһ�µĴ���**��

�����˼�����£�
-   ʹ����ɫ��ǽڵ��״̬���½ڵ�Ϊ��ɫ���ѷ��ʵĽڵ�Ϊ��ɫ��
-   ��������Ľڵ�Ϊ��ɫ��������Ϊ��ɫ��Ȼ�����������ӽڵ㡢���ӽڵ�������ջ��
-   ��������Ľڵ�Ϊ��ɫ���򽫽ڵ��ֵ�����

ʹ�����ַ���ʵ�ֵĺ���������£�

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
public IList<int> PostorderTraversal(TreeNode root)
{
    List<int> result = new List<int>();
    if (root == null) return result;

    Stack<(bool tag, TreeNode node)> stack = new Stack<(bool, TreeNode)>();  // true:��ɫ, false:��ɫ
    stack.Push((true, root));
    while (stack.Count > 0)
    {
        var item = stack.Pop();
        if (item.node == null) continue;
        if (item.tag)
        {
            stack.Push((false, item.node));
            stack.Push((true, item.node.right));
            stack.Push((true, item.node.left));
        }
        else
            result.Add(item.node.val);
    }

    return result;
}
```

��Ҫʵ��ǰ�����������ֻ��Ҫ���������ӽڵ����ջ˳�򼴿ɡ�
