using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0373
{
    public class Solution0373 : Interface0373
    {
        /// <summary>
        /// 类BFS，双指针
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            List<IList<int>> result = new List<IList<int>>();
            PriorityQueue<(int, int), int> minpq = new PriorityQueue<(int, int), int>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            int p1 = 0, p2 = 0, len1 = nums1.Length, len2 = nums2.Length;
            minpq.Enqueue((0, 0), nums1[0] + nums2[0]);
            visited.Add((0, 0));
            while (k-- > 0)
            {
                (p1, p2) = minpq.Dequeue();
                result.Add([nums1[p1], nums2[p2]]);
                if (p1 < len1 - 1 && !visited.Contains((p1 + 1, p2))) { minpq.Enqueue((p1 + 1, p2), nums1[p1 + 1] + nums2[p2]); visited.Add((p1 + 1, p2)); }
                if (p2 < len2 - 1 && !visited.Contains((p1, p2 + 1))) { minpq.Enqueue((p1, p2 + 1), nums1[p1] + nums2[p2 + 1]); visited.Add((p1, p2 + 1)); }
            }

            return result;
        }
    }
}
