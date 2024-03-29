using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0012
{
    public class Solution0012 : Interface0012
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex(int[] nums)
        {
            int rsum = 0, lsum = 0, len = nums.Length;
            for (int i = 1; i < len; i++) rsum += nums[i];
            if (rsum == 0) return 0;
            for (int i = 1; i < len; i++)
            {
                lsum += nums[i - 1]; rsum -= nums[i];
                if (lsum == rsum) return i;
            }

            return -1;
        }
    }
}
