using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0965
{
    public class Solution0965 : Interface0965
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsUnivalTree(TreeNode root)
        {
            return dfs(root, root.val);
        }

        private bool dfs(TreeNode node, int val)
        {
            if (node == null) return true;
            if (node.val != val) return false;

            return dfs(node.left, val) ? dfs(node.right, val) : false;
        }
    }
}
