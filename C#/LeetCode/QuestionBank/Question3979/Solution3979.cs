using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3979
{
    public class Solution3979 : Interface3979
    {
        /// <summary>
        /// 预处理
        /// 预处理后缀数组的最大值，然后枚举数对左侧的位置即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxValidPairSum(int[] nums, int k)
        {
            int result = int.MinValue, len = nums.Length;
            int[] maxs = new int[len];
            maxs[^1] = nums[^1];
            for (int i = len - 2; i >= 0; i--) maxs[i] = Math.Max(maxs[i + 1], nums[i]);
            for (int i = k; i < len; i++) result = Math.Max(result, nums[i - k] + maxs[i]);

            return result;
        }
    }
}
