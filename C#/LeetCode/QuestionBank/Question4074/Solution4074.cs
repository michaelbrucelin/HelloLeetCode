using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4074
{
    public class Solution4074 : Interface4074
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] MaxProductPair(int[] nums, int target)
        {
            int[] result = [-1, -1];
            int max = int.MinValue, len = nums.Length;
            for (int i = 0; i < len; i++) for (int j = 0; j < len; j++) if (nums[i] + nums[j] == target && nums[i] > nums[j])
                    {
                        if (nums[i] * nums[j] > max)
                        {
                            result[0] = i; result[1] = j; max = nums[i] * nums[j];
                        }
                    }

            return result;
        }
    }
}
