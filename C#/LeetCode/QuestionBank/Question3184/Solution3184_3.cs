using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3184
{
    public class Solution3184_3 : Interface3184
    {
        /// <summary>
        /// 取余 + 一次遍历
        /// 逻辑同Solution3184
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public int CountCompleteDayPairs(int[] hours)
        {
            int result = 0;
            int[] freq = new int[24];
            for (int i = 0, mod; i < hours.Length; i++)
            {
                mod = hours[i] % 24;
                result += freq[(24 - mod) % 24];
                freq[mod]++;
            }

            return result;
        }
    }
}
