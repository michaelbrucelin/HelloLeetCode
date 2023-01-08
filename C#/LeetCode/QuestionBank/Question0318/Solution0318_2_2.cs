using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0318
{
    public class Solution0318_2_2 : Interface0318
    {
        private const int alletter = (1 << 26) - 1;

        public int MaxProduct(string[] words)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < words.Length; i++)
            {
                int mask = GetKeyCode(words[i]);
                if (mask == alletter) continue;
                if (buffer.ContainsKey(mask))
                    buffer[mask] = Math.Max(buffer[mask], words[i].Length);
                else
                    buffer.Add(mask, words[i].Length);
            }

            int result = 0;
            foreach (var info1 in buffer) foreach (var info2 in buffer)
                {
                    if ((info1.Key & info2.Key) == 0) result = Math.Max(result, info1.Value * info2.Value);
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
