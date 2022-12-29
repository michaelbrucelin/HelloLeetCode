using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2032
{
    public class Solution2032 : Interface2032
    {
        public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {
            HashSet<int> set1 = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>(nums2);
            HashSet<int> set3 = new HashSet<int>(nums3);

            // 让set1中的元素最少，set3中的元素最多，用小表驱动大表
            HashSet<int> sett = new HashSet<int>();
            if (set1.Count > set2.Count) { sett = set1; set1 = set2; set2 = sett; }
            if (set2.Count > set3.Count) { sett = set2; set2 = set3; set3 = sett; }
            if (set1.Count > set2.Count) { sett = set1; set1 = set2; set2 = sett; }

            HashSet<int> result = new HashSet<int>();
            foreach (int i in set1) { if (set2.Contains(i) || set3.Contains(i)) result.Add(i); }
            foreach (int i in set2) { if (set3.Contains(i)) result.Add(i); }

            return result.ToList();
        }

        /// <summary>
        /// 使用API
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="nums3"></param>
        /// <returns></returns>
        public IList<int> TwoOutOfThree2(int[] nums1, int[] nums2, int[] nums3)
        {
            HashSet<int> result = new HashSet<int>(nums1.Intersect(nums2));
            result.UnionWith(nums1.Intersect(nums3));
            result.UnionWith(nums2.Intersect(nums3));

            return result.ToList();
        }
    }
}
