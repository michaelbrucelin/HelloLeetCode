using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2974
{
    public class Solution2974 : Interface2974
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int[] NumberGame(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            Array.Copy(nums, result, len);
            Array.Sort(result);
            for (int i = 1, t; i < len; i += 2)
            {
                // t = result[i - 1]; result[i - 1] = result[i]; result[i] = t;
                (result[i - 1], result[i]) = (result[i], result[i - 1]);
            }

            return result;
        }

        public int[] NumberGame2(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            Array.Sort(nums);
            for (int i = 1; i < len; i += 2)
            {
                result[i - 1] = nums[i]; result[i] = nums[i - 1];
            }

            return result;
        }
    }
}
