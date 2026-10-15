using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0047
{
    public class Solution0047 : Interface0047
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode PruneTree(TreeNode root)
        {
            TreeNode dummy = new TreeNode(-1, root, null);
            rec(dummy, root, true);
            return dummy.left;

            void rec(TreeNode father, TreeNode node, bool isleft)
            {
                if (node.left != null) rec(node, node.left, true);
                if (node.right != null) rec(node, node.right, false);

                if (node.left == null && node.right == null && node.val == 0)
                {
                    if (isleft) father.left = null; else father.right = null;
                }
            }
        }
    }
}
