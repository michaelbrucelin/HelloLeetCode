using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2451
{
    public class Solution2451 : Interface2451
    {
        /// <summary>
        /// 分析
        /// 1. 先找出两个不同的string，再用第3个string就能把不同的string找出来
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string OddString(string[] words)
        {
            int len = words.Length, n = words[0].Length;
            int i, j;
            for (i = 1; i < len; i++) if (!IsSameDiff(words[i], words[0], n)) break;
            j = i == 1 ? 2 : 1;

            return IsSameDiff(words[j], words[0], n) ? words[i] : words[0];
        }

        private bool IsSameDiff(string word1, string word2, int n)
        {
            for (int i = 1; i < n; i++)  // 题目限定了word1.Length == word2.Length  == n
                if (word1[i] - word1[i - 1] != word2[i] - word2[i - 1]) return false;

            return true;
        }

        /// <summary>
        /// 与OddString()一样，略加优化，如果i > 1，说明words[0]与words[1]一致，那么结果必是words[i]
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string OddString2(string[] words)
        {
            int len = words.Length, n = words[0].Length;
            int i;
            for (i = 1; i < len; i++) if (!IsSameDiff(words[i], words[0], n)) break;
            if (i > 1) return words[i];

            return IsSameDiff(words[2], words[0], n) ? words[1] : words[0];
        }
    }
}
