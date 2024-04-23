using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3120
{
    public class Solution3120 : Interface3120
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int NumberOfSpecialChars(string word)
        {
            bool[] mask = new bool[123];
            for (int i = 0; i < word.Length; i++) mask[word[i]] = true;

            int result = 0;
            for (int i = 65; i < 91; i++) if (mask[i] && mask[i | 32]) result++;

            return result;
        }
    }
}
