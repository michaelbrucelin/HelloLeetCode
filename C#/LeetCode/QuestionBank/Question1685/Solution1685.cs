using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1685
{
    public class Solution1685 : Interface1685
    {
        /// <summary>
        /// 前缀和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] GetSumAbsoluteDifferences(int[] nums)
        {
            int len = nums.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + nums[i];

            int[] result = new int[len];
            for (int i = 0; i < len; i++)
            {
                result[i] += nums[i] * i - sums[i];
                result[i] += sums[len] - sums[i + 1] - nums[i] * (len - i - 1);
            }

            return result;
        }
    }
}
