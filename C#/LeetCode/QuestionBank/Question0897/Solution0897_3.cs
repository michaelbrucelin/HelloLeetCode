using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0897
{
    public class Solution0897_3 : Interface0897
    {
        /// <summary>
        /// 与Solution0897逻辑一样，只是将递归改为Morris迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            TreeNode ptr = root, pre;
            while (ptr != null)
            {
                if (ptr.left == null) { list.Add(ptr); ptr = ptr.right; }
                else
                {
                    pre = ptr.left; while (pre.right != null && pre.right != ptr) pre = pre.right;
                    if (pre.right == null)
                    {
                        pre.right = ptr; ptr = ptr.left;
                    }
                    else
                    {
                        pre.right = null; list.Add(ptr); ptr = ptr.right;
                    }
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
