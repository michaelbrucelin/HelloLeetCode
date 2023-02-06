using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0349
{
    public class Solution0349 : Interface0349
    {
        /// <summary>
        /// hash表
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>(nums2);

            return set1.Intersect(set2).ToArray();
        }

        public int[] Intersection2(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>(nums2);

            List<int> result = new List<int>();
            if (set1.Count <= set2.Count)
            {
                foreach (int val in set1) if (set2.Contains(val)) result.Add(val);
            }
            else
            {
                foreach (int val in set2) if (set1.Contains(val)) result.Add(val);
            }

            return result.ToArray();
        }
    }
}
