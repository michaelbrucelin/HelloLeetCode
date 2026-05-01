using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0396
{
    public class Solution0396 : Interface0396
    {
        /// <summary>
        /// 递推
        /// 0a + 1b + 2c + 3d 的 下一个是 0d + 1a + 2b + 3c = (0a + 1b + 2c + 3d) + (a + b + c + d) - 4d
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxRotateFunction(int[] nums)
        {
            int init = 0, sum = 0, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                sum += nums[i];
                init += nums[i] * i;
            }

            int result = init;
            for (int i = len - 1; i > 0; i--)
            {
                init = init + sum - len * nums[i];
                result = Math.Max(result, init);
            }

            return result;
        }
    }
}
