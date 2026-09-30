using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3424
{
    public class Solution3424 : Interface3424
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="brr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MinCost(int[] arr, int[] brr, long k)
        {
            int len = arr.Length;
            long cost1 = 0, cost2 = k;
            for (int i = 0; i < len; i++) cost1 += Math.Abs(arr[i] - brr[i]);
            if (k >= cost1) return cost1;

            Array.Sort(arr);
            Array.Sort(brr);
            for (int i = 0; i < len; i++) cost2 += Math.Abs(arr[i] - brr[i]);

            return Math.Min(cost1, cost2);
        }
    }
}
