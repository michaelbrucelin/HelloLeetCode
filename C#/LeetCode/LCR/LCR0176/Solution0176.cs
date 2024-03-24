using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0176
{
    public class Solution0176 : Interface0176
    {
        /// <summary>
        /// 递归
        /// 自底向上递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            return TreeHeight(root) != -1;
        }

        private int TreeHeight(TreeNode node)
        {
            if (node == null) return 0;

            int height_l = TreeHeight(node.left);
            int height_r = TreeHeight(node.right);

            if (height_l == -1 || height_r == -1 || Math.Abs(height_l - height_r) > 1) return -1;
            return Math.Max(height_l, height_r) + 1;
        }
    }
}
