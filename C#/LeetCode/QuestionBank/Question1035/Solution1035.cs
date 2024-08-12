using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1035
{
    public class Solution1035 : Interface1035
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            throw new NotImplementedException();

            /*
            int result1 = 0, result2 = 0, p1, p2, len1 = nums1.Length, len2 = nums2.Length;
            for (p1 = 0, p2 = 0; p1 < len1 && p2 < len2; p1++, p2++)
            {
                while (p2 < len2 && nums2[p2] != nums1[p1]) p2++;
                if (p2 < len2) result1++;
            }
            for (p1 = 0, p2 = 0; p1 < len1 && p2 < len2; p1++, p2++)
            {
                while (p1 < len1 && nums1[p1] != nums2[p2]) p1++;
                if (p1 < len1) result2++;
            }

            return Math.Max(result1, result2);
            */
        }
    }
}
