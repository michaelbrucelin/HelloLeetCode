using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1712
{
    public class Solution1712_4 : Interface1712
    {
        /// <summary>
        /// 逻辑同Solution1712_3，只是将递归1:1翻译为迭代试一下
        /// 
        /// 提交依然TLE且MLE。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TreeNode ConvertBiNode(TreeNode root)
        {
            TreeNode dummy = new TreeNode(-1);
            TreeNode parent = dummy;
            Stack<(TreeNode node, bool flag)> stack = new Stack<(TreeNode node, bool flag)>();
            stack.Push((root, false));
            (TreeNode node, bool flag) ptr;
            while (stack.Count > 0)
            {
                ptr = stack.Pop();
                if (ptr.node == null) continue;
                if (ptr.flag)
                {
                    parent.left = null; parent.right = ptr.node; parent = ptr.node;
                }
                else
                {
                    stack.Push((ptr.node.right, false));
                    stack.Push((ptr.node, true));
                    stack.Push((ptr.node.left, false));
                }
            }

            return dummy.right;
        }
    }
}
