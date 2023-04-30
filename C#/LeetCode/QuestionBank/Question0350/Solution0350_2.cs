using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0350
{
    public class Solution0350_2 : Interface0350
    {
        /// <summary>
        /// 排序 + 双指针
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            if (nums1.Length > nums2.Length) { var t = nums1; nums1 = nums2; nums2 = t; }  // 小表驱动大表

            List<int> result = new List<int>();
            int ptr1 = 0, ptr2 = 0, len1 = nums1.Length, len2 = nums2.Length;
            while (ptr1 < len1 && ptr2 < len2)
            {
                if (nums1[ptr1] == nums2[ptr2])
                {
                    result.Add(nums1[ptr1]); ptr1++; ptr2++;
                }
                else if (nums1[ptr1] < nums2[ptr2])
                {
                    while (ptr1 < len1 && nums1[ptr1] < nums2[ptr2]) ptr1++;
                }
                else  // if (nums1[ptr1] > nums2[ptr2])
                {
                    while (ptr2 < len2 && nums2[ptr2] < nums1[ptr1]) ptr2++;
                }
            }

            return result.ToArray();
        }
    }
}
