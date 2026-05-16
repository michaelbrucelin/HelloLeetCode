using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0044
{
    public class Solution0044 : Interface0044
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> LargestValues(TreeNode root)
        {
            List<int> result = [];
            if (root == null) return result;

            dfs(root, 0);
            return result;

            void dfs(TreeNode node, int depth)
            {
                if (node == null) return;
                if (result.Count == depth) result.Add(node.val); else result[depth] = Math.Max(result[depth], node.val);
                dfs(node.left, depth + 1);
                dfs(node.right, depth + 1);
            }
        }
    }
}
