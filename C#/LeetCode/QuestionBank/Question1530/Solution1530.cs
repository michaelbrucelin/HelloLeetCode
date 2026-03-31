using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1530
{
    public class Solution1530 : Interface1530
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public int CountPairs(TreeNode root, int distance)
        {
            if (distance < 2) return 0;

            int result = 0;
            dfs(root);
            return result;

            int[] dfs(TreeNode node)
            {
                if (node == null) return null;

                int[] info = new int[distance];
                if (node.left == null && node.right == null) { info[0] = 1; return info; }

                int[] linfo = dfs(node.left);
                if (linfo != null) for (int i = 1; i < distance; i++) info[i] += linfo[i - 1];
                int[] rinfo = dfs(node.right);
                if (rinfo != null) for (int i = 1; i < distance; i++) info[i] += rinfo[i - 1];

                if (linfo != null && rinfo != null) for (int d = distance; d > 1; d--)
                    {
                        for (int i = 1, j = d - 1; i < d; i++, j--) result += linfo[i - 1] * rinfo[j - 1];
                    }

                return info;
            }
        }
    }
}
