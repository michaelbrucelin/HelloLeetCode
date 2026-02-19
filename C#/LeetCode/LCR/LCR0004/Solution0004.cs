using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0004
{
    public class Solution0004 : Interface0004
    {
        /// <summary>
        /// 逐位判断
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0, cnt; i < 32; i++)
            {
                cnt = 0;
                for (int j = 0; j < len; j++) cnt += (nums[j] >> i) & 1;
                if (cnt % 3 == 1) result |= 1 << i;
            }

            return result;
        }
    }
}
