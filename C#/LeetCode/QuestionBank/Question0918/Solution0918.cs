using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0918
{
    public class Solution0918 : Interface0918
    {
        /// <summary>
        /// DP
        /// 1. 使用Question0053的DP思路，可以找出子数组的最大和sum_max与最小和sum_min
        /// 2. 结果就是Max(sum_max, sum-sum_min)
        /// 3. 注意
        ///     计算sum_max时，至少取一项，可以取数组的全部项
        ///     计算sum_min时，可以一项都不取，不可以取数组的全部项
        /// 简要证明：
        ///     如果环形数组的子数组最大和，没有连接数组的首尾，那么上面求解的sum_max就是最大解
        ///     如果环形数组的子数组最大和，连接了数组的首尾，那么上面求解的sum-sum_min就是最大解
        ///     没有第三种情况
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubarraySumCircular(int[] nums)
        {
            int sum_max = nums[0], sum_min = nums[0], max = nums[0], sum = nums[0], len = nums.Length;
            for (int i = 1, dp_max = nums[0], dp_min = nums[0]; i < len; i++)
            {
                dp_max = Math.Max(nums[i], dp_max + nums[i]);
                sum_max = Math.Max(sum_max, dp_max);
                dp_min = Math.Min(nums[i], dp_min + nums[i]);
                sum_min = Math.Min(sum_min, dp_min);
                max = Math.Max(max, nums[i]);
                sum += nums[i];
            }

            return max <= 0 ? max : Math.Max(sum_max, sum - sum_min);
        }
    }
}
