using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1995
{
    public class Solution1995 : Interface1995
    {
        /// <summary>
        /// 暴力枚举
        /// 试一下暴力能不能过，能过
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountQuadruplets(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int a = 0; a < len - 3; a++) for (int b = a + 1; b < len - 2; b++) for (int c = b + 1; c < len - 1; c++)
                        for (int d = c + 1; d < len; d++)
                        {
                            if (nums[a] + nums[b] + nums[c] == nums[d]) result++;
                        }

            return result;
        }

        /// <summary>
        /// 与CountQuadruplets()一样，稍加优化
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountQuadruplets2(int[] nums)
        {
            int result = 0, _sum, sum, len = nums.Length;
            for (int a = 0; a < len - 3; a++) for (int b = a + 1; b < len - 2; b++)
                {
                    _sum = nums[a] + nums[b];
                    for (int c = b + 1; c < len - 1; c++)
                    {
                        sum = _sum + nums[c];
                        for (int d = c + 1; d < len; d++)
                        {
                            if (sum == nums[d]) result++;
                        }
                    }
                }

            return result;
        }
    }
}
