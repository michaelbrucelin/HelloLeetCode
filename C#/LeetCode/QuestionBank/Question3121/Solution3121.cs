using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3121
{
    public class Solution3121 : Interface3121
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int NumberOfSpecialChars(string word)
        {
            int[] pos = new int[26], POS = new int[26];
            Array.Fill(pos, int.MinValue);
            Array.Fill(POS, int.MaxValue);
            for (int i = 0, len = word.Length; i < len; i++)
            {
                if (((word[i] >> 5) & 1) == 1)
                    pos[word[i] - 'a'] = Math.Max(pos[word[i] - 'a'], i);
                else
                    POS[word[i] - 'A'] = Math.Min(POS[word[i] - 'A'], i);
            }

            int result = 0;
            for (int i = 0; i < 26; i++) if (pos[i] > int.MinValue && POS[i] < int.MaxValue && pos[i] < POS[i]) result++;
            return result;
        }

        /// <summary>
        /// 逻辑同NumberOfSpecialChars()，玩点编码花活
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int NumberOfSpecialChars2(string word)
        {
            int[,] pos = new int[27, 2];
            for (int i = 1; i < 27; i++) { pos[i, 0] = int.MaxValue; pos[i, 1] = int.MinValue; }
            Func<int, int, int>[] funcs = [Math.Min, Math.Max];
            for (int i = 0, d1, d2, len = word.Length; i < len; i++)
            {
                d1 = word[i] & 31;
                d2 = (word[i] >> 5) & 1;
                pos[d1, d2] = funcs[d2](pos[d1, d2], i);
            }

            int result = 0;
            for (int i = 1; i < 27; i++) if (pos[i, 1] > int.MinValue && pos[i, 0] < int.MaxValue && pos[i, 1] < pos[i, 0]) result++;
            return result;
        }
    }
}
