using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2348
{
    public class Solution2348 : Interface2348
    {
        /// <summary>
        /// 双指针 + 数学
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long ZeroFilledSubarray(int[] nums)
        {
            long result = 0;
            int pl = 0, pr, len = nums.Length;
            while (pl < len)
            {
                while (pl < len && nums[pl] != 0) pl++;
                if (pl == len) break;
                pr = pl;
                while (pr + 1 < len && nums[pr + 1] == 0) pr++;
                result += (1L * (pr - pl + 1) * (pr - pl + 2)) >> 1;
                pl = pr + 2;
            }

            return result;
        }
    }
}
