using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1123
{
    public class Solution1123_2 : Interface1123
    {
        /// <summary>
        /// DFS，递归
        /// 1. 如果一个节点的左右子树深度相同，那么结果就是这个节点
        /// 2.                           不同，那么递归更深的子节点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            return dfs(root).node;
        }

        private (TreeNode node, int depth) dfs(TreeNode node)
        {
            if (node == null) return (null, 0);

            var tl = dfs(node.left); var tr = dfs(node.right);
            switch (tl.depth - tr.depth)
            {
                case > 0: return (tl.node, tl.depth + 1);
                case < 0: return (tr.node, tr.depth + 1);
                default: return (node, tl.depth + 1);
            }
        }
    }
}
