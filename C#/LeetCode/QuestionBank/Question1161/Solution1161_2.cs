using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1161
{
    public class Solution1161_2 : Interface1161
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxLevelSum(TreeNode root)
        {
            List<int> levels = new List<int>();
            dfs(root, 0);

            int level = 0, cnt = levels.Count;
            for (int i = 1; i < cnt; i++) if (levels[i] > levels[level]) level = i;
            return level + 1;

            void dfs(TreeNode node, int level)
            {
                if (level == levels.Count) levels.Add(0);
                levels[level] += node.val;
                if (node.left != null) dfs(node.left, level + 1);
                if (node.right != null) dfs(node.right, level + 1);
            }
        }
    }
}
