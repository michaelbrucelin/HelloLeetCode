using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2583
{
    public class Solution2583 : Interface2583
    {
        /// <summary>
        /// BFS + 大根堆
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long KthLargestLevelSum(TreeNode root, int k)
        {
            List<long> sums = new List<long>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);  // 题目限定树至少有两个节点
            int cnt; long sum; TreeNode node;
            while ((cnt = queue.Count) > 0)
            {
                sum = 0;
                for (int i = 0; i < cnt; i++)
                {
                    sum += (node = queue.Dequeue()).val;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                sums.Add(sum);
            }
            if (sums.Count < k) return -1;

            // sums.Sort(Comparer<long>.Create((i, j) => (j - i) switch { > 0 => 1, < 0 => -1, _ => 0 }));
            PriorityQueue<long, long> maxpq = new PriorityQueue<long, long>();  // 可以把大根堆改为TopK算法
            foreach (long val in sums) maxpq.Enqueue(val, -val);
            for (int i = 1; i < k; i++) maxpq.Dequeue();

            return maxpq.Dequeue();
        }
    }
}
