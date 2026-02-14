using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0049
{
    public class Solution0049 : Interface0049
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumNumbers(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0;
            dfs(root, root.val);

            return result;

            void dfs(TreeNode node, int val)
            {
                if (node.left == null && node.right == null)
                {
                    result += val;
                    return;
                }
                if (node.left != null) dfs(node.left, val * 10 + node.left.val);
                if (node.right != null) dfs(node.right, val * 10 + node.right.val);
            }
        }
    }
}
