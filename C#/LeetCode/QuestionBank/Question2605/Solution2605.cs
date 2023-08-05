using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2605
{
    public class Solution2605 : Interface2605
    {
        /// <summary>
        /// 分析
        /// 有相同的取相同的最小值，没有相同的各取最小值
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MinNumber(int[] nums1, int[] nums2)
        {
            int[] freq1 = new int[10], freq2 = new int[10];
            for (int i = 0; i < nums1.Length; i++) freq1[nums1[i]] = 1;
            for (int i = 0; i < nums2.Length; i++) freq2[nums2[i]] = 1;
            for (int i = 1; i < 10; i++) if (freq1[i] == 1 && freq2[i] == 1) return i;

            int min1 = -1, min2 = -1;
            for (int i = 1; i < 10; i++) if (freq1[i] == 1) { min1 = i; break; }
            for (int i = 1; i < 10; i++) if (freq2[i] == 1) { min2 = i; break; }
            return min1 <= min2 ? min1 * 10 + min2 : min1 + min2 * 10;
        }
    }
}
