using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0104
{
    public class Solution0104 : Interface0104
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0;
            dfs(root, 1, ref result);

            return result;
        }

        private void dfs(TreeNode node, int level, ref int result)
        {
            if (level > result) result = level;
            if (node.left != null) dfs(node.left, level + 1, ref result);
            if (node.right != null) dfs(node.right, level + 1, ref result);
        }
    }
}
