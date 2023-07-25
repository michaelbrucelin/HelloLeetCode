using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2574
{
    public class Solution2574 : Interface2574
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] LeftRightDifference(int[] nums)
        {
            int lsum = 0, rsum = 0, len = nums.Length;
            for (int i = 1; i < len; i++) rsum += nums[i];

            int[] result = new int[len];
            result[0] = rsum;
            for (int i = 1; i < len; i++)
            {
                lsum += nums[i - 1]; rsum -= nums[i];
                result[i] = Math.Abs(lsum - rsum);
            }

            return result;
        }
    }
}
