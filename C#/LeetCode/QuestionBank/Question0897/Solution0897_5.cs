using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0897
{
    public class Solution0897_5 : Interface0897
    {
        /// <summary>
        /// dfs
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode IncreasingBST(TreeNode root)
        {
            TreeNode dummy = new TreeNode();
            TreeNode prev = dummy;
            dfs(root);
            prev.left = prev.right = null;

            return dummy.right;

            void dfs(TreeNode node)
            {
                if (node == null) return;
                dfs(node.left);
                prev.left = null; prev.right = node; prev = node;
                dfs(node.right);
            }
        }
    }
}
