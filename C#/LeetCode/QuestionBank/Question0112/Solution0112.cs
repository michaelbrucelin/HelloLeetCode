using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0112
{
    public class Solution0112 : Interface0112
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            bool result = false;
            dfs(root, 0, targetSum, ref result);

            return result;
        }

        private void dfs(TreeNode node, int sum, int target, ref bool result)
        {
            if (result || node == null) return;

            if (node.left == null && node.right == null)
            {
                if (sum + node.val == target) result = true;
            }
            else
            {
                if (node.left != null) dfs(node.left, sum + node.val, target, ref result);
                if (node.right != null) dfs(node.right, sum + node.val, target, ref result);
            }
        }
    }
}
