using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3319
{
    public class Solution3319_2 : Interface3319
    {
        /// <summary>
        /// 递归 + 快速选择
        /// 逻辑完全同Solution3319，将堆改为快速选择
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthLargestPerfectSubtree(TreeNode root, int k)
        {
            List<int> list = [];
            rec(root);

            if (list.Count < k) return -1;
            int p = -1, lo = 0, hi = list.Count - 1;
            while ((p = partition(list, lo, hi)) != k - 1) if (p < k - 1) lo = p + 1; else hi = p - 1;

            return list[p];

            (bool, int) rec(TreeNode node)
            {
                if (node == null) return (true, 0);

                (bool, int) linfo = rec(node.left);
                (bool, int) rinfo = rec(node.right);
                if (!linfo.Item1 || !rinfo.Item1 || linfo.Item2 != rinfo.Item2) return (false, -1);

                int cnt = linfo.Item2 + rinfo.Item2 + 1;
                list.Add(cnt);
                return (true, cnt);
            }

            int partition(List<int> list, int lo, int hi)
            {
                if (lo == hi) return lo;

                int v = list[lo], t, i = lo, j = hi + 1;
                while (true)
                {
                    while (list[++i] > v) if (i == hi) break;
                    while (list[--j] < v) ;  // if (j == lo) break;
                    if (i >= j) break;
                    t = list[i]; list[i] = list[j]; list[j] = t;
                }
                list[lo] = list[j]; list[j] = v;
                return j;
            }
        }
    }
}
