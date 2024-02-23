using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2583
{
    public class Solution2583_2 : Interface2583
    {
        /// <summary>
        /// DFS + 大根堆
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long KthLargestLevelSum(TreeNode root, int k)
        {
            List<long> sums = new List<long>();
            dfs(root, 0, sums);
            if (sums.Count < k) return -1;

            // sums.Sort(Comparer<long>.Create((i, j) => (j - i) switch { > 0 => 1, < 0 => -1, _ => 0 }));
            PriorityQueue<long, long> maxpq = new PriorityQueue<long, long>();  // 可以把大根堆改为TopK算法
            foreach (long val in sums) maxpq.Enqueue(val, -val);
            for (int i = 1; i < k; i++) maxpq.Dequeue();

            return maxpq.Dequeue();
        }

        private void dfs(TreeNode node, int level, List<long> sums)
        {
            if (node == null) return;

            if (level == sums.Count) sums.Add(0);
            sums[level] += node.val;

            dfs(node.left, level + 1, sums);
            dfs(node.right, level + 1, sums);
        }
    }
}
