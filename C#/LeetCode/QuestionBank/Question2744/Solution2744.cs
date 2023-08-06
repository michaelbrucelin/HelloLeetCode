using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2744
{
    public class Solution2744 : Interface2744
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MaximumNumberOfStringPairs(string[] words)
        {
            HashSet<string> set = new HashSet<string>(words);

            int result = 0;
            foreach (string word in set)
            {
                if (word[0] != word[1] && set.Contains($"{word[1]}{word[0]}")) result++;
            }

            return result >> 1;
        }

        /// <summary>
        /// 哈希表2
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MaximumNumberOfStringPairs2(string[] words)
        {
            HashSet<string> set = new HashSet<string>();

            int result = 0;
            foreach (string word in words)
            {
                if (set.Contains($"{word[1]}{word[0]}")) result++; else set.Add(word);
            }

            return result;
        }
    }
}
