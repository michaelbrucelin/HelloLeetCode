using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0299
{
    public class Solution0299 : Interface0299
    {
        /// <summary>
        /// 遍历 + 计数
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public string GetHint(string secret, string guess)
        {
            int len = secret.Length, bulls = 0, cows = 0;
            int[,] freq = new int[2, 10];
            for (int i = 0; i < len; i++)
            {
                if (secret[i] != guess[i])
                {
                    freq[0, secret[i] & 15]++; freq[1, guess[i] & 15]++;
                }
                else
                {
                    bulls++;
                }
            }
            for (int i = 0; i < 10; i++) cows += Math.Min(freq[0, i], freq[1, i]);

            return $"{bulls}A{cows}B";
        }
    }
}
