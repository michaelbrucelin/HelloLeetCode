using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0349
{
    public class Solution0349_2 : Interface0349
    {
        /// <summary>
        /// 排序 + 双指针
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            List<int> result = new List<int>();
            int ptr1 = 0, ptr2 = 0, len1 = nums1.Length, len2 = nums2.Length;
            while (ptr1 < len1 && ptr2 < len2)
            {
                while (ptr1 + 1 < len1 && nums1[ptr1 + 1] == nums1[ptr1]) ptr1++;
                while (ptr2 + 1 < len2 && nums2[ptr2 + 1] == nums2[ptr2]) ptr2++;
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
