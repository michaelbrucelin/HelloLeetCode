using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3162
{
    public class Solution3162 : Interface3162
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumberOfPairs(int[] nums1, int[] nums2, int k)
        {
            int result = 0;
            for (int i = 0; i < nums1.Length; i++) for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] % (nums2[j] * k) == 0) result++;
                }

            return result;
        }
    }
}
