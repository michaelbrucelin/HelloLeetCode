using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2527
{
    public class Solution2527 : Interface2527
    {
        /// <summary>
        /// 数学
        /// i == j == k，即 i, i, i
        ///     ((nums[i] | nums[i]) & nums[i]) = nums[i]
        /// i != j == k，即 i, j, j + i, i, j
        ///     ((nums[j] | nums[i]) & nums[i]) ^ ((nums[i] | nums[j]) & nums[i]) ^ ((nums[i] | nums[i]) & nums[j]) = nums[i] & nums[j]
        ///     ((nums[i] | nums[j]) & nums[j]) ^ ((nums[j] | nums[i]) & nums[j]) ^ ((nums[j] | nums[j]) & nums[i]) = nums[j] & nums[i]
        ///     (nums[i] & nums[j]) ^ (nums[j] & nums[i]) = 0
        /// i != j != k，即 i, j, k
        ///     ((nums[i] | nums[j]) & nums[k]) ^ ((nums[j] | nums[i]) & nums[k]) = 0
        ///     ((nums[i] | nums[k]) & nums[j]) ^ ((nums[k] | nums[i]) & nums[j]) = 0
        ///     ((nums[j] | nums[k]) & nums[i]) ^ ((nums[k] | nums[j]) & nums[i]) = 0
        /// 
        /// 所以结果为nums[0]^nums[1]^...^nums[-1]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int XorBeauty(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len; i++) result ^= nums[i];

            return result;
        }
    }
}
