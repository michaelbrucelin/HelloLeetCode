using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2903
{
    public class Solution2903 : Interface2903
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="indexDifference"></param>
        /// <param name="valueDifference"></param>
        /// <returns></returns>
        public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
        {
            int[] result = new int[] { -1, -1 };
            if (indexDifference >= nums.Length) return result;

            int len = nums.Length;
            for (int i = 0; i < len - indexDifference; i++) for (int j = i + indexDifference; j < len; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) >= valueDifference)
                    {
                        result[0] = i; result[1] = j; break;
                    }
                }

            return result;
        }
    }
}
