using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0046
{
    public class Solution0046 : Interface0046
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return [];

            List<int> result = [];
            dfs(root, 0);

            return result;

            void dfs(TreeNode node, int depth)
            {
                if (node == null) return;
                if (depth == result.Count) result.Add(node.val);
                dfs(node.right, depth + 1);
                dfs(node.left, depth + 1);
            }
        }
    }
}
