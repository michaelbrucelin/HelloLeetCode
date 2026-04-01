using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0515
{
    public class Solution0515 : Interface0515
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> LargestValues(TreeNode root)
        {
            List<int> result = [];
            dfs(root, 0);

            return result;

            void dfs(TreeNode node, int level)
            {
                if (node == null) return;
                if (result.Count == level) result.Add(int.MinValue);

                result[level] = Math.Max(result[level], node.val);
                dfs(node.left, level + 1);
                dfs(node.right, level + 1);
            }
        }
    }
}
