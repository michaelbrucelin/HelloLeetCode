using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3319
{
    public class Solution3319 : Interface3319
    {
        /// <summary>
        /// 递归 + 堆
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthLargestPerfectSubtree(TreeNode root, int k)
        {
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            rec(root);

            if (maxpq.Count < k) return -1;
            while (--k > 0) maxpq.Dequeue();
            return maxpq.Dequeue();

            (bool, int) rec(TreeNode node)
            {
                if (node == null) return (true, 0);

                (bool, int) linfo = rec(node.left);
                (bool, int) rinfo = rec(node.right);
                if (!linfo.Item1 || !rinfo.Item1 || linfo.Item2 != rinfo.Item2) return (false, -1);

                int cnt = linfo.Item2 + rinfo.Item2 + 1;
                maxpq.Enqueue(cnt, -cnt);
                return (true, cnt);
            }
        }
    }
}
