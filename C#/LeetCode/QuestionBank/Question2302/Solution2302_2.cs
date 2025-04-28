using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2302
{
    public class Solution2302_2 : Interface2302
    {
        /// <summary>
        /// 前缀和 + 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountSubarrays(int[] nums, long k)
        {
            int len = nums.Length;
            long[] pres = new long[len + 1];
            for (int i = 0; i < len; i++) pres[i + 1] = pres[i] + nums[i];

            long result = 0;
            int pl = 0, pr;
            while (pl < len && nums[pl] >= k) pl++;
            pr = pl - 1;
            while (pl < len)
            {
                while (pr + 1 < len && (pres[pr + 1 + 1] - pres[pl]) * (pr + 1 - pl + 1) < k) pr++;
                result += pr - pl + 1;
                pl++;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同CountSubarrays()，不需要提前预处理前缀和数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountSubarrays2(int[] nums, long k)
        {
            long result = 0, sum = 0;
            int pl = 0, pr, len = nums.Length;
            while (pl < len && nums[pl] >= k) pl++;
            pr = pl - 1;
            while (pl < len)
            {
                while (pr + 1 < len && (sum + nums[pr + 1]) * (pr + 1 - pl + 1) < k) sum += nums[++pr];
                result += pr - pl + 1;
                sum -= nums[pl++];
            }

            return result;
        }
    }
}
