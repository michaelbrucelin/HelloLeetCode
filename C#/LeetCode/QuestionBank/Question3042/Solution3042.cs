using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3042
{
    public class Solution3042 : Interface3042
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int CountPrefixSuffixPairs(string[] words)
        {
            int result = 0, len = words.Length;
            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    if (words[j].StartsWith(words[i]) && words[j].EndsWith(words[i])) result++;
                }

            return result;
        }
    }
}
