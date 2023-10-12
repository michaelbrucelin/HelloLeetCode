using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2562
{
    public class Solution2562 : Interface2562
    {
        /// <summary>
        /// 模拟
        /// 数学方法串联
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long FindTheArrayConcVal(int[] nums)
        {
            long result = 0, i = -1, j = nums.Length;
            while ((++i) <= (--j))
            {
                if (i != j)
                    result += nums[i] * (int)Math.Pow(10, (int)Math.Log10(nums[j]) + 1) + nums[j];
                else
                    result += nums[i];
            }

            return result;
        }

        /// <summary>
        /// 模拟
        /// 将数学方法串联改为字符串串联
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long FindTheArrayConcVal2(int[] nums)
        {
            long result = 0, i = -1, j = nums.Length;
            while ((++i) <= (--j))
            {
                if (i != j)
                    result += int.Parse($"{nums[i]}{nums[j]}");
                else
                    result += nums[i];
            }

            return result;
        }
    }
}
