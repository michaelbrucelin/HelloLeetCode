using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0045
{
    public class Solution0045 : Interface0045
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            int result = root.val, level = 1;
            dfs(root, 1);
            return result;

            void dfs(TreeNode node, int depth)
            {
                if (node == null) return;
                if (depth > level) { result = node.val; level = depth; }
                dfs(node.left, depth + 1);
                dfs(node.right, depth + 1);
            }
        }
    }
}
