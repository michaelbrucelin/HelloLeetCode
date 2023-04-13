using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2540
{
    public class Solution2540_2 : Interface2540
    {
        /// <summary>
        /// 双指针
        /// 有归并排序的意思
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int GetCommon(int[] nums1, int[] nums2)
        {
            int p1 = 0, p2 = 0, len1 = nums1.Length, len2 = nums2.Length;
            while (p1 < len1 && p2 < len2)
            {
                if (nums1[p1] == nums2[p2]) return nums1[p1];
                if (nums1[p1] < nums2[p2]) p1++; else p2++;
            }

            return -1;
        }
    }
}
