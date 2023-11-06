using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0318
{
    public class Solution0318_off : Interface0318
    {
        private const int alletter = (1 << 26) - 1;

        public int MaxProduct(string[] words)
        {
            int len = words.Length;
            int[] masks = new int[len];
            for (int i = 0; i < len; i++) masks[i] = GetKeyCode(words[i]);

            int result = 0;
            for (int i = 0; i < len; i++) for (int j = 0; j < len; j++)
                {
                    if ((masks[i] & masks[j]) == 0) result = Math.Max(result, words[i].Length * words[j].Length);
                }

            return result;
        }

        /// <summary>
        /// 用一个26位的bitmap记录word中含有哪些字母
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private int GetKeyCode(string word)
        {
            int result = 0;

            for (int i = 0; i < word.Length; i++)
            {
                result |= (1 << (word[i] - 'a'));
                if (result == alletter) break;
            }

            return result;
        }
    }
}
