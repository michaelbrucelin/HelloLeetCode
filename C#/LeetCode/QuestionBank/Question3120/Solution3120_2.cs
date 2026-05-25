using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3120
{
    public class Solution3120_2 : Interface3120
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int NumberOfSpecialChars(string word)
        {
            int[,] mask = new int[27, 2];
            for (int i = 0, len = word.Length; i < len; i++) mask[word[i] & 31, (word[i] >> 5) & 1] = 1;

            int result = 0;
            for (int i = 1; i < 27; i++) result += mask[i, 0] & mask[i, 1];

            return result;
        }
    }
}
