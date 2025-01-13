using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2270
{
    public class Solution2270 : Interface2270
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int WaysToSplitArray(int[] nums)
        {
            int result = 0, len = nums.Length;
            long lsum = 0, rsum = 0;
            for (int i = 0; i < len; i++) lsum += nums[i];
            for (int i = len - 2; i >= 0; i--)
            {
                lsum -= nums[i + 1];
                rsum += nums[i + 1];
                if (lsum >= rsum) result++;
            }

            return result;
        }
    }
}
