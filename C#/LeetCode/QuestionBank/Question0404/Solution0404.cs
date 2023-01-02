using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0404
{
    public class Solution0404 : Interface0404
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0;
            dfs(root, false, ref result);

            return result;
        }

        private void dfs(TreeNode node, bool isleft, ref int result)
        {
            if (node.left == null && node.right == null)
            {
                if (isleft) result += node.val;
            }
            else
            {
                if (node.left != null) dfs(node.left, true, ref result);
                if (node.right != null) dfs(node.right, false, ref result);
            }
        }
    }
}
