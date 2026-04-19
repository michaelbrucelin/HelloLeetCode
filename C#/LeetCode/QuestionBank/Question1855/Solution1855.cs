using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1855
{
    public class Solution1855 : Interface1855
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MaxDistance(int[] nums1, int[] nums2)
        {
            if (nums1[^1] > nums2[0]) return 0;

            int result = 0, p1 = -1, p2 = 0, len1 = nums1.Length, len2 = nums2.Length;
            while (++p1 < len1 && p2 < len2)
            {
                p2 = Math.Max(p1, p2);
                while (p2 + 1 < len2 && nums2[p2 + 1] >= nums1[p1]) p2++;
                result = Math.Max(result, p2 - p1);
                if (p2 == len2 - 1) break;
            }

            return result;
        }
    }
}
