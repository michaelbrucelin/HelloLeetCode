using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2063
{
    public class Solution2063 : Interface2063
    {
        private static readonly HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];

        /// <summary>
        /// 贡献法
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public long CountVowels(string word)
        {
            long result = 0;
            for (int i = 0, len = word.Length; i < len; i++)
            {
                if (vowels.Contains(word[i])) result += 1L * (i + 1) * (len - i);
            }

            return result;
        }

        private static readonly long[] map = [1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0];

        /// <summary>
        /// 逻辑同CountVowels()，使用数组加速hash，快了很多
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public long CountVowels2(string word)
        {
            long result = 0;
            for (int i = 0, len = word.Length; i < len; i++)
            {
                result += map[word[i] - 'a'] * (i + 1) * (len - i);
            }

            return result;
        }

        private const int mask = 1065233;

        /// <summary>
        /// 逻辑同CountVowels()，使用位运算加速hash，快了很多
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public long CountVowels3(string word)
        {
            long result = 0;
            for (int i = 0, len = word.Length; i < len; i++)
            {
                result += 1L * ((mask >> (word[i] - 'a')) & 1) * (i + 1) * (len - i);
            }

            return result;
        }
    }
}
