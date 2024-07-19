using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3184
{
    public class Solution3184_2 : Interface3184
    {
        /// <summary>
        /// 取余，排列组合
        /// 如果数组长度足够大，这样做有意义
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public int CountCompleteDayPairs(int[] hours)
        {
            int[] freq = new int[24];
            for (int i = 0; i < hours.Length; i++) freq[hours[i] % 24]++;

            int result = 0;
            result += freq[0] * (freq[0] - 1) >> 1;
            result += freq[12] * (freq[12] - 1) >> 1;
            for (int i = 1; i < 12; i++) result += freq[i] * freq[24 - i];

            return result;
        }
    }
}
