using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3264
{
    public class Solution3264 : Interface3264
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public int[] GetFinalState(int[] nums, int k, int multiplier)
        {
            int len = nums.Length;
            for (int i = 0, minid; i < k; i++)
            {
                minid = 0;
                for (int j = 0; j < len; j++) if (nums[j] < nums[minid]) minid = j;
                nums[minid] *= multiplier;
            }

            return nums;
        }
    }
}
