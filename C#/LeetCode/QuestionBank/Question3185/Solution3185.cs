using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3185
{
    public class Solution3185 : Interface3185
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public long CountCompleteDayPairs(int[] hours)
        {
            long result = 0;
            int[] cache = new int[24];
            for (int i = 0, hour = 0, id1 = 0, id2 = 0; i < hours.Length; i++)
            {
                hour = hours[i];
                id2 = hour % 24;
                id1 = id2 != 0 ? 24 - id2 : 0;
                result += cache[id1];
                cache[id2]++;
            }

            return result;
        }
    }
}
