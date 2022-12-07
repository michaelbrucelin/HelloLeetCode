using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1775
{
    public class Solution1775 : Interface1775
    {
        /// <summary>
        /// 贪心调整
        /// 具体见Solution1775.md
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums1, int[] nums2)
        {
            int sum1 = 0, sum2 = 0;
            int[] freq1 = new int[7], freq2 = new int[7];
            for (int i = 0; i < nums1.Length; i++) { sum1 += nums1[i]; freq1[nums1[i]]++; }
            for (int i = 0; i < nums2.Length; i++) { sum2 += nums2[i]; freq2[nums2[i]]++; }
            if (sum1 == sum2) return 0;

            int left = Math.Max(nums1.Length, nums2.Length), right = 6 * Math.Min(nums1.Length, nums2.Length);
            if (left > right) return -1;  // 可能的范围无交集

            if (sum1 > sum2)              // 让nums1是较小的那个数组
            {
                int t = sum1; sum1 = sum2; sum2 = t;
                int[] arr_t = nums1; nums1 = nums2; nums2 = arr_t;
                arr_t = freq1; freq1 = freq2; freq2 = arr_t;
            }

            // 必有解，所以不判断ptr_l与ptr_r是否数组越界
            int steps = 0;
            int ptr_l = 1; while (freq1[ptr_l] == 0) ptr_l++;
            int ptr_r = 6; while (freq2[ptr_r] == 0) ptr_r--;
            while (sum1 < left)
            {
                sum1 += (6 - ptr_l); steps++; if (--freq1[ptr_l] == 0) ptr_l++;
            }
            while (sum2 > right)
            {
                sum2 -= (ptr_r - 1); steps++; if (--freq2[ptr_r] == 0) ptr_r--;
            }
            while (sum1 < sum2)
            {
                if ((6 - ptr_l) >= (ptr_r - 1))
                {
                    sum1 += (6 - ptr_l); if (--freq1[ptr_l] == 0) ptr_l++;
                }
                else
                {
                    sum2 -= (ptr_r - 1); if (--freq2[ptr_r] == 0) ptr_r--;
                }
                steps++;
            }

            return steps;
        }
    }
}
