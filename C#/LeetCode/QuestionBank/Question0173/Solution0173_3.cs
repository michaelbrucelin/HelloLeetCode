using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0173
{
    public class Solution0173_3
    {
    }

    /// <summary>
    /// 进阶
    /// 逻辑同Solution0173_2，改为边迭代边输出
    /// </summary>
    public class BSTIterator_3 : Interface0173
    {
        public BSTIterator_3(TreeNode root)
        {
            ptr = (root, false);
            hasnext = root != null;
            stack = new Stack<(TreeNode, bool)>();
        }

        private (TreeNode node, bool flag) ptr;
        private bool hasnext;
        private Stack<(TreeNode, bool)> stack;

        public bool HasNext()
        {
            return hasnext;
        }

        public int Next()
        {
            int next;
            while (true)
            {
                if (ptr.flag)
                {
                    next = ptr.node.val;
                    if (stack.Count == 0) hasnext = false; else ptr = stack.Pop();
                    break;
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
                        next = ptr.node.val;
                        if (stack.Count == 0) hasnext = false; else ptr = stack.Pop();
                        break;
                    }
                }
            }
            return next;
        }
    }
}
