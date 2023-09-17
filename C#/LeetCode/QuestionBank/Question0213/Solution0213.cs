using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0213
{
    public class Solution0213 : Interface0213
    {
        /// <summary>
        /// DP
        /// 如果数组首尾不相连，那么就是常规DP，参考Question0198，但是这里是环形数组
        /// 1. 前面的选择同Question0198，那么到达数组的最后一项时，这一项只有选与不选两种可能
        ///     不选，那就相当于少了最后一项的Question0198，可解
        ///     选，  那么数组的第一项就一定不可以选择，那就相当于少了第一项的Question0198，可解
        /// 2. 最后一项选与不选的最大值，就是结果
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int r0, r1, len = nums.Length;
            int dp0 = nums[0], dp1 = 0;  // dp0，取nums[i]，dp1，不取nums[i]
            for (int i = 1, _; i < len - 1; i++)
            {
                _ = dp0; dp0 = dp1 + nums[i]; dp1 = Math.Max(dp1, _);
            }
            r0 = Math.Max(dp0, dp1);
            dp0 = nums[1]; dp1 = 0;
            for (int i = 2, _; i < len; i++)
            {
                _ = dp0; dp0 = dp1 + nums[i]; dp1 = Math.Max(dp1, _);
            }
            r1 = Math.Max(dp0, dp1);

            return Math.Max(r0, r1);
        }
    }
}
