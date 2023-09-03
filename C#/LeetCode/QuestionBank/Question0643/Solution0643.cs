using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0643
{
    public class Solution0643 : Interface0643
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double FindMaxAverage(int[] nums, int k)
        {
            double sum = 0, _sum;
            for (int i = 0; i < k; i++) sum += nums[i];
            _sum = sum;
            for (int i = k; i < nums.Length; i++)
            {
                _sum += nums[i] - nums[i - k]; sum = Math.Max(sum, _sum);
            }

            return sum / k;
        }
    }
}
