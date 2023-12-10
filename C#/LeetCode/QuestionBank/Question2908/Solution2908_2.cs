using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2908
{
    public class Solution2908_2 : Interface2908
    {
        /// <summary>
        /// 预处理数组每个位置左侧的最小值与右侧的最小值，方便计算
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumSum(int[] nums)
        {
            int result = -1, sum, len = nums.Length;
            int[] lmin = new int[len], rmin = new int[len];
            lmin[0] = nums[0];
            for (int i = 1; i < len; i++) lmin[i] = Math.Min(nums[i], lmin[i - 1]);
            rmin[len - 1] = nums[len - 1];
            for (int i = len - 2; i >= 0; i--) rmin[i] = Math.Min(nums[i], rmin[i + 1]);

            for (int i = 1; i < len - 1; i++) if (lmin[i - 1] < nums[i] && nums[i] > rmin[i + 1])
                {
                    sum = lmin[i - 1] + nums[i] + rmin[i + 1];
                    result = result == -1 ? sum : Math.Min(result, sum);
                }

            return result;
        }
    }
}
