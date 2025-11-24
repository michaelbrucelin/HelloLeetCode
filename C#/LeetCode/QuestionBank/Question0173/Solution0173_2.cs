using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0173
{
    public class Solution0173_2
    {
    }

    /// <summary>
    /// 进阶
    /// 改为使用迭代进行中序遍历，并边遍历边输出即可
    /// 先把迭代版写出来，然后再改为边迭代边输出
    /// </summary>
    public class BSTIterator_2 : Interface0173
    {
        public BSTIterator_2(TreeNode root)
        {
            ptr = 0;
            list = [];
            stack = new Stack<(TreeNode, bool)>();
            iteration(root);
        }

        private List<int> list;
        private int ptr;
        private Stack<(TreeNode, bool)> stack;

        public bool HasNext()
        {
            return ptr < list.Count();
        }

        public int Next()
        {
            return list[ptr++];
        }

        private void iteration(TreeNode root)
        {
            (TreeNode node, bool flag) ptr = (root, false);
            while (root != null)
            {
                if (ptr.flag)
                {
                    list.Add(ptr.node.val);
                    if (stack.Count == 0) break;
                    ptr = stack.Pop();
                }
                else
                {
                    if (ptr.node.right != null) stack.Push((ptr.node.right, false));
                    if (ptr.node.left != null)
                    {
                        stack.Push((ptr.node, true));
                        ptr = (ptr.node.left, false);
                    }
                    else
                    {
                        list.Add(ptr.node.val);
                        if (stack.Count == 0) break;
                        ptr = stack.Pop();
                    }
                }
            }
        }
    }
}
