using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2918
{
    public class Solution2918 : Interface2918
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public long MinSum(int[] nums1, int[] nums2)
        {
            long sum1 = 0, sum2 = 0;
            int cnt1 = 0, cnt2 = 0;
            foreach (int num in nums1) if (num > 0) sum1 += num; else cnt1++;
            foreach (int num in nums2) if (num > 0) sum2 += num; else cnt2++;
            sum1 += cnt1;
            sum2 += cnt2;

            if (sum1 > sum2 && cnt2 == 0) return -1;
            if (sum2 > sum1 && cnt1 == 0) return -1;
            return Math.Max(sum1, sum2);
        }
    }
}
