using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0103
{
    public class Solution0103_2 : Interface0103
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            dfs(root, result, 0);
            for (int i = 1; i < result.Count; i += 2)
            {
                // result[i] = result[i].Reverse().ToList();
                for (int j = 0, k = result[i].Count - 1, t; j < k; j++, k--)
                {
                    t = result[i][j]; result[i][j] = result[i][k]; result[i][k] = t;
                }
            }

            return result;
        }

        private void dfs(TreeNode node, IList<IList<int>> buffer, int level)
        {
            // if (node == null) return;  // null不会进来

            if (level == buffer.Count) buffer.Add(new List<int>());
            buffer[level].Add(node.val);
            if (node.left != null) dfs(node.left, buffer, level + 1);
            if (node.right != null) dfs(node.right, buffer, level + 1);
        }
    }
}
