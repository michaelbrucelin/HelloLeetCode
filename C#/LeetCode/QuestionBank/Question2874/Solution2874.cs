using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2874
{
    public class Solution2874 : Interface2874
    {
        /// <summary>
        /// 枚举j
        /// 预处理 j 的前缀最大值和后缀最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumTripletValue(int[] nums)
        {
            int len = nums.Length;
            long[] pre = new long[len];
            pre[0] = nums[0];
            for (int i = 1; i < len; i++) pre[i] = Math.Max(pre[i - 1], nums[i]);

            long result = 0, suf = nums[len - 1];
            for (int i = len - 2; i > 0; i--)
            {
                suf = Math.Max(suf, nums[i + 1]);
                result = Math.Max(result, (pre[i - 1] - nums[i]) * suf);
            }

            return result;
        }
    }
}
