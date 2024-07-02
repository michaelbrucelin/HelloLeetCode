using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0494
{
    public class Solution0494_off_1 : Interface0494
    {
        /// <summary>
        /// 练习一下回溯
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindTargetSumWays(int[] nums, int target)
        {
            int result = 0, len = nums.Length;
            backtrack(0, 0);
            return result;

            void backtrack(int idx, int sum)
            {
                if (idx == len)
                {
                    if (sum == target) result++;
                }
                else  // if (idx < len)
                {
                    sum += nums[idx]; backtrack(idx + 1, sum); sum -= nums[idx];
                    sum -= nums[idx]; backtrack(idx + 1, sum); sum += nums[idx];
                }
            }
        }
    }
}
