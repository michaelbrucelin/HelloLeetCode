using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2874
{
    public class Solution2874_2 : Interface2874
    {
        /// <summary>
        /// 枚举k
        /// 枚举k，预处理 k 左侧的最大的 nums[i] - nums[j]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumTripletValue(int[] nums)
        {
            int len = nums.Length;
            long[] pre = new long[len];
            for (int i = 1, max = nums[0]; i < len; i++)
            {
                pre[i] = Math.Max(pre[i - 1], max - nums[i]);
                max = Math.Max(max, nums[i]);
            }

            long result = 0;
            for (int i = len - 1; i > 0; i--) result = Math.Max(result, pre[i - 1] * nums[i]);

            return result;
        }
    }
}
