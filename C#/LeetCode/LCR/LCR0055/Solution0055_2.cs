using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0055
{
    public class Solution0055_2
    {
    }

    /// <summary>
    /// 在树上原地迭代，本质上就是将DFS改为迭代
    /// </summary>
    public class BSTIterator_2 : Interface0055
    {
        public BSTIterator_2(TreeNode root)
        {
            stack = new Stack<(TreeNode, bool)>();
            if (root != null) stack.Push((root, true));
        }

        private Stack<(TreeNode, bool)> stack;
        private (TreeNode node, bool first) ptr;

        public int Next()
        {
            while ((ptr = stack.Pop()).first)
            {
                if (ptr.node.right != null) stack.Push((ptr.node.right, true));
                stack.Push((ptr.node, false));
                if (ptr.node.left != null) stack.Push((ptr.node.left, true));
            }
            return ptr.node.val;
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }
    }
}
