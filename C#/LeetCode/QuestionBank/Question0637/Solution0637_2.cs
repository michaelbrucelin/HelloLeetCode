using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0637
{
    public class Solution0637_2 : Interface0637
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            if (root == null) return new List<double>();

            List<double> sums = new List<double>();
            List<int> cnts = new List<int>();
            dfs(root, 0, sums, cnts);

            for (int i = 0; i < sums.Count; i++) sums[i] /= cnts[i];
            return sums;
        }

        private void dfs(TreeNode node, int level, List<double> sums, List<int> cnts)
        {
            if (level < sums.Count)
            {
                sums[level] += node.val; cnts[level]++;
            }
            else
            {
                sums.Add(node.val); cnts.Add(1);
            }
            if (node.left != null) dfs(node.left, level + 1, sums, cnts);
            if (node.right != null) dfs(node.right, level + 1, sums, cnts);
        }
    }
}
