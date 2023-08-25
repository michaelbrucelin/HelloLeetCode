using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0543
{
    public class Solution0543 : Interface0543
    {
        /// <summary>
        /// 递归
        /// 每颗树的直径都应该是下面3者中的最大值
        ///     1. 左子树深度 + 右子树深度
        ///     2. 左子树直径
        ///     3. 右子树直径
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int DiameterOfBinaryTree(TreeNode root)
        {
            return rec(root).diameter;
        }

        private (int diameter, int depth) rec(TreeNode node)
        {
            if (node == null) return (0, -1);

            var tl = rec(node.left);
            var tr = rec(node.right);
            int diameter = Math.Max(tl.depth + tr.depth + 2, Math.Max(tl.diameter, tr.diameter));
            int depth = Math.Max(tl.depth, tr.depth) + 1;

            return (diameter, depth);
        }
    }
}
