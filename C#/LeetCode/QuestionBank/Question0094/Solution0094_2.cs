using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0094
{
    public class Solution0094_2 : Interface0094
    {
        /// <summary>
        /// 迭代
        /// 1. 将指针指向根节点
        /// 2. 指针有左孩子，指针入栈，指针指向其左孩子，直至指针无左孩子
        /// 3. 指针无左孩子，输出指针
        ///     3.1. 指针有右孩子，指针指向其右孩子，回到2
        ///     3.2. 指针无右孩子，指针指向栈顶并输出栈顶（弹栈）
        ///         3.2.1. 指针无右孩子，回到3.2，直至指针有右孩子
        ///         3.2.2. 指针有右孩子，指针指向其右孩子，回到2
        /// 4. 指针无左孩子、无右孩子，且栈空，遍历结束
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null)
            {
                while (ptr.left != null) { stack.Push(ptr); ptr = ptr.left; }
                result.Add(ptr.val);
                if (ptr.right != null) ptr = ptr.right;
                else
                {
                    while (ptr.right == null && stack.Count > 0)
                    {
                        ptr = stack.Pop();
                        result.Add(ptr.val);
                    }
                    if (ptr.right != null) ptr = ptr.right; else break;
                }
            }

            return result;
        }
    }
}
