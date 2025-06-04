using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2367
{
    public class Solution2367 : Interface2367
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="diff"></param>
        /// <returns></returns>
        public int ArithmeticTriplets(int[] nums, int diff)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++) for (int k = j + 1; k < len; k++)
                    {
                        if (nums[j] - nums[i] == diff && nums[k] - nums[j] == diff) result++;
                    }

            return result;
        }

        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="diff"></param>
        /// <returns></returns>
        public int ArithmeticTriplets2(int[] nums, int diff)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len - 2; i++) for (int j = i + 1; j <= i + diff && j < len - 1; j++) for (int k = j + 1; k <= j + diff && k < len; k++)
                    {
                        if (nums[j] - nums[i] == diff && nums[k] - nums[j] == diff) result++;
                    }

            return result;
        }

        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="diff"></param>
        /// <returns></returns>
        public int ArithmeticTriplets3(int[] nums, int diff)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len - 2; i++) for (int j = i + 1; j <= i + diff && j < len - 1; j++)
                {
                    if (nums[j] - nums[i] < diff) continue;
                    if (nums[j] - nums[i] == diff) for (int k = j + 1; k <= j + diff && k < len; k++)
                        {
                            if (nums[k] - nums[j] < diff) continue;
                            if (nums[k] - nums[j] == diff) result++;
                            break;
                        }
                    break;
                }

            return result;
        }
    }
}
