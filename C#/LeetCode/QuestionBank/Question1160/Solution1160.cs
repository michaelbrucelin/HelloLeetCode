using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1160
{
    public class Solution1160 : Interface1160
    {
        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="words"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public int CountCharacters(string[] words, string chars)
        {
            int result = 0;
            int[] freq = new int[26];
            for (int i = 0; i < chars.Length; i++) freq[chars[i] - 'a']++;

            bool flag; int[] _freq = new int[26];
            for (int i = 0; i < words.Length; i++)
            {
                flag = true; Array.Copy(freq, _freq, 26);
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (--_freq[words[i][j] - 'a'] < 0)
                    {
                        flag = false; break;
                    }
                }
                if (flag) result += words[i].Length;
            }

            return result;
        }
    }
}
