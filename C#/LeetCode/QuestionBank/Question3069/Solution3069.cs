using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3069
{
    public class Solution3069 : Interface3069
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ResultArray(int[] nums)
        {
            int len = nums.Length, p1 = 0, p2 = 0;
            int[] result = new int[len], buffer = new int[len];
            result[p1++] = nums[0];  // 题目限定nums.Length >= 3
            buffer[p2++] = nums[1];
            for (int i = 2; i < len; i++)
            {
                if (result[p1 - 1] > buffer[p2 - 1]) result[p1++] = nums[i]; else buffer[p2++] = nums[i];
            }

            for (int i = p1, j = 0; i < len; i++, j++) result[i] = buffer[j];

            return result;
        }
    }
}
