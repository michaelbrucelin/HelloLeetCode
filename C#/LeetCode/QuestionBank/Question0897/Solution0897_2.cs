using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0897
{
    public class Solution0897_2 : Interface0897
    {
        /// <summary>
        /// 与Solution0897逻辑一样，只是将递归改为迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null)
            {
                while (ptr.left != null) { stack.Push(ptr); ptr = ptr.left; }
                list.Add(ptr);
                if (ptr.right != null) ptr = ptr.right;
                else
                {
                    while (ptr.right == null && stack.Count > 0)
                    {
                        ptr = stack.Pop();
                        list.Add(ptr);
                    }
                    if (ptr.right != null) ptr = ptr.right; else break;
                }
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                list[i].left = null; list[i].right = list[i + 1];
            }
            list[^1].left = list[^1].right = null;

            return list[0];
        }
    }
}
