using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3131
{
    public class Solution3131 : Interface3131
    {
        /// <summary>
        /// 阅读理解题
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int AddedInteger(int[] nums1, int[] nums2)
        {
            // 题目保证了一定有解
            // return nums2.Min() - nums1.Min();
            int min1 = nums1[0], min2 = nums2[0], len = nums1.Length;
            for (int i = 1; i < len; i++)
            {
                min1 = Math.Min(min1, nums1[i]); min2 = Math.Min(min2, nums2[i]);
            }

            return min2 - min1;
        }
    }
}
