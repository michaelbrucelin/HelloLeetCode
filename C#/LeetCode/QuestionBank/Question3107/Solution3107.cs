using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3107
{
    public class Solution3107 : Interface3107
    {
        /// <summary>
        /// 贪心
        /// 1. 排序
        /// 2. 将当前的中位数调整为k
        /// 3. 使k位置不变，即
        ///     如果k变大了，需要使k左边比k大的值变为k
        ///     如果k变小了，需要使k右边比k小的值变为k
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public long MinOperationsToMakeMedianK(int[] nums, int k)
        {
            Array.Sort(nums);
            long result = 0; int p = nums.Length >> 1, len = nums.Length;
            switch (nums[p] - k)
            {
                case > 0:
                    for (int i = p; i >= 0 && nums[i] > k; i--) result += nums[i] - k;
                    break;
                case < 0:
                    for (int i = p; i < len && nums[i] < k; i++) result += k - nums[i];
                    break;
                default: return 0;
            }

            return result;
        }
    }
}
