using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3364
{
    public class Solution3364 : Interface3364
    {
        /// <summary>
        /// 前缀和 + 枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int MinimumSumSubarray(IList<int> nums, int l, int r)
        {
            int result = int.MaxValue, len = nums.Count;
            int[] pre = new int[len + 1];
            for (int i = 0; i < len; i++) pre[i + 1] = pre[i] + nums[i];
            for (int i = l; i <= r; i++) for (int j = i - 1; j < len; j++)
                {
                    if (pre[j + 1] - pre[j - i + 1] > 0) result = Math.Min(result, pre[j + 1] - pre[j - i + 1]);
                }

            return result != int.MaxValue ? result : -1;
        }
    }
}
