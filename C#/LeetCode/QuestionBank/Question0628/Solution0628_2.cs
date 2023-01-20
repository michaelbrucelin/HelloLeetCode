using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0628
{
    public class Solution0628_2 : Interface0628
    {
        /// <summary>
        /// 逻辑与Solution0628一样，倒是没有排序，而是遍历一次把需要的值给找出来
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumProduct(int[] nums)
        {
            if (nums.Length == 3) return nums[0] * nums[1] * nums[2];

            int[] max_posi = new int[] { 0, 0, 0 }, min_posi = new int[] { 1001, 1001 };
            int[] max_nega = new int[] { -1001, -1001, -1001 }, min_nega = new int[] { 0, 0 };
            bool has_zero = false;
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                int[] maxarr, minarr;
                if (val == 0)
                {
                    has_zero = true; continue;
                }
                else if (val > 0)
                {
                    maxarr = max_posi; minarr = min_posi;
                }
                else  // val < 0
                {
                    maxarr = max_nega; minarr = min_nega;
                }

                if (val > maxarr[2])
                {
                    maxarr[0] = maxarr[1]; maxarr[1] = maxarr[2]; maxarr[2] = val;
                }
                else if (val > maxarr[1])
                {
                    maxarr[0] = maxarr[1]; maxarr[1] = val;
                }
                else if (val > maxarr[0])
                {
                    maxarr[0] = val;
                }

                if (val < minarr[0])
                {
                    minarr[1] = minarr[0]; minarr[0] = val;
                }
                else if (val < minarr[1])
                {
                    minarr[1] = val;
                }
            }

            int result = int.MinValue;
            if (max_posi[0] != 0) result = Math.Max(result, max_posi[0] * max_posi[1] * max_posi[2]);
            if (max_posi[2] != 0 && min_nega[1] != 0) result = Math.Max(result, max_posi[2] * min_nega[0] * min_nega[1]);
            if (result != int.MinValue) return result;
            if (has_zero) return 0;
            if (max_nega[0] != -1001) result = Math.Max(result, max_nega[0] * max_nega[1] * max_nega[2]);
            if (max_nega[2] != -1001 && min_posi[1] != 1001) result = Math.Max(result, max_nega[2] * min_posi[0] * min_posi[1]);

            return result;
        }
    }
}
