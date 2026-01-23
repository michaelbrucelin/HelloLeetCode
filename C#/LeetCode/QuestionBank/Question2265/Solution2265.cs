using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2265
{
    public class Solution2265 : Interface2265
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int AverageOfSubtree(TreeNode root)
        {
            int result = 0;
            dfs(root);
            return result;

            (int, int) dfs(TreeNode node)
            {
                if (node == null) return (0, 0);
                (int, int) info_l = dfs(node.left);
                (int, int) info_r = dfs(node.right);

                int sum = info_l.Item1 + info_r.Item1 + node.val;
                int cnt = info_l.Item2 + info_r.Item2 + 1;
                if (sum / cnt == node.val) result++;

                return (sum, cnt);
            }
        }
    }
}
