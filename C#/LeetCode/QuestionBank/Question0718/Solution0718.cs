using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0718
{
    public class Solution0718 : Interface0718
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int FindLength(int[] nums1, int[] nums2)
        {
            int result = 0, len1 = nums1.Length, len2 = nums2.Length;
            for (int i = 0, k; i < len1 - result; i++) for (int j = 0; j < len2 - result; j++) if (nums1[i] == nums2[j])
                    {
                        for (k = 0; i + k < len1 && j + k < len2 && nums1[i + k] == nums2[j + k]; k++) ;
                        result = Math.Max(result, k);
                    }

            return result;
        }
    }
}
