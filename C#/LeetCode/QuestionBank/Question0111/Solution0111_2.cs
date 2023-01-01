using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0111
{
    public class Solution0111_2 : Interface0111
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            int result = int.MaxValue;
            dfs(root, 1, ref result);

            return result;
        }

        private void dfs(TreeNode node, int level, ref int result)
        {
            if (level >= result) return;

            if (node.left == null && node.right == null)
            {
                result = level;
            }
            else
            {
                if (node.left != null) dfs(node.left, level + 1, ref result);
                if (node.right != null) dfs(node.right, level + 1, ref result);
            }
        }
    }
}
