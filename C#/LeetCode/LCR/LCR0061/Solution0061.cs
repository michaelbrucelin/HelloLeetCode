using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0061
{
    public class Solution0061 : Interface0061
    {
        /// <summary>
        /// 双指针 + 小顶堆
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            List<IList<int>> result = new List<IList<int>>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            PriorityQueue<(int, int), int> minpq = new PriorityQueue<(int, int), int>();
            minpq.Enqueue((0, 0), 0);
            int p1, p2, len1 = nums1.Length, len2 = nums2.Length;
            while (result.Count < k && minpq.Count > 0)
            {
                if (visited.Contains((p1, p2) = minpq.Dequeue())) continue;
                result.Add([nums1[p1], nums2[p2]]);
                visited.Add((p1, p2));
                if (p1 + 1 < len1) minpq.Enqueue((p1 + 1, p2), nums1[p1 + 1] + nums2[p2]);
                if (p2 + 1 < len2) minpq.Enqueue((p1, p2 + 1), nums1[p1] + nums2[p2 + 1]);
            }

            return result;
        }
    }
}
