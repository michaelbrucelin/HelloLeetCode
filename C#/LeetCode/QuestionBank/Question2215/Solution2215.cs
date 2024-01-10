using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2215
{
    public class Solution2215 : Interface2215
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>(nums2);

            List<IList<int>> result = new List<IList<int>>();
            result.Add(set1.Except(set2).ToList());
            result.Add(set2.Except(set1).ToList());

            return result;
        }

        /// <summary>
        /// Hash
        /// 小表驱动大表
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public IList<IList<int>> FindDifference2(int[] nums1, int[] nums2)
        {
            HashSet<int> set1, set2;
            set1 = new HashSet<int>(nums1); set2 = new HashSet<int>(nums2);

            if (nums1.Length <= nums2.Length)
            {
                foreach (int num in set1) if (set2.Contains(num))
                    {
                        set1.Remove(num); set2.Remove(num);
                    }
            }
            else
            {
                foreach (int num in set2) if (set1.Contains(num))
                    {
                        set1.Remove(num); set2.Remove(num);
                    }
            }

            return new List<IList<int>>() { set1.ToList(), set2.ToList() };
        }
    }
}
