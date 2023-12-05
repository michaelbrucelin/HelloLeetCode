using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0053
{
    public class Solution0053_err : Interface0053
    {
        /// <summary>
        /// DP
        /// 具体分析见Solution0053_error.md
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int len = nums.Length, max = nums[0];  // 子数组至少取一项，下面的DP可以取空数组，所以这里用max记录数组的最大值
            int[] dp1 = new int[len + 1], dp2 = new int[len + 1];
            for (int i = 0, num, _dp2; i < len; i++)
            {
                num = nums[i]; _dp2 = dp2[i] + num; max = Math.Max(max, num);
                if (_dp2 >= 0)
                {
                    dp1[i + 1] = Math.Max(dp1[i] + _dp2, num);  // dp2[i + 1] = 0;
                }
                else
                {
                    if (dp1[i] > num)
                    {
                        dp1[i + 1] = dp1[i]; dp2[i + 1] = _dp2;
                    }
                    else
                    {
                        dp1[i + 1] = num;  // dp2[i + 1] = 0;
                    }
                }
            }

            return max < 0 ? max : dp1[len];
        }
    }
}
