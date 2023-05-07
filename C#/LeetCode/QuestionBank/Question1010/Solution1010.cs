using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1010
{
    public class Solution1010 : Interface1010
    {
        /// <summary>
        /// 数学，排列组合
        /// 1. 余0找余0，余30找余30，余i找余60-i
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int NumPairsDivisibleBy60(int[] time)
        {
            int[] group = new int[60];
            for (int i = 0; i < time.Length; i++) group[time[i] % 60]++;

            int result = 0;
            // result += group[0] > 0 ? (group[0] * (group[0] - 1)) >> 1 : 0;     // 小心溢出
            // result += group[30] > 0 ? (group[30] * (group[30] - 1)) >> 1 : 0;  // 小心溢出
            if (group[0] > 1) result += (group[0] & 1) == 0 ? (group[0] >> 1) * (group[0] - 1) : group[0] * ((group[0] - 1) >> 1);
            if (group[30] > 1) result += (group[30] & 1) == 0 ? (group[30] >> 1) * (group[30] - 1) : group[30] * ((group[30] - 1) >> 1);
            for (int i = 1; i < 30; i++)
                result += group[i] * group[60 - i];

            return result;
        }

        /// <summary>
        /// 与NumPairsDivisibleBy60()一样，但是“逐步累加”，不是“先统计再组合”
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int NumPairsDivisibleBy60_2(int[] time)
        {
            int result = 0;
            int[] group = new int[60];
            for (int i = 0, remainder; i < time.Length; i++)
            {
                remainder = time[i] % 60;
                if (remainder == 0)
                {
                    result += group[0]; group[0]++;
                }
                else
                {
                    result += group[60 - remainder]; group[remainder]++;
                }
            }

            return result;
        }
    }
}
