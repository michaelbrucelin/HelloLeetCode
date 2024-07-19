using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3184
{
    public class Solution3184 : Interface3184
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public int CountCompleteDayPairs(int[] hours)
        {
            int result = 0, len = hours.Length;
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++)
                    if ((hours[i] + hours[j]) % 24 == 0) result++;

            return result;
        }
    }
}
