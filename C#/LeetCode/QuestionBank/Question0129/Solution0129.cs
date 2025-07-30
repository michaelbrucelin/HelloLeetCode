using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0129
{
    public class Solution0129 : Interface0129
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumNumbers(TreeNode root)
        {
            int result = 0;
            dfs(root, 0);
            return result;

            void dfs(TreeNode node, int val)
            {
                val = val * 10 + node.val;
                if (node.left == null && node.right == null) { result += val; return; }
                if (node.left != null) dfs(node.left, val);
                if (node.right != null) dfs(node.right, val);
            }
        }
    }
}
