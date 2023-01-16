using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2114
{
    public class Solution2114 : Interface2114
    {
        public int MostWordsFound(string[] sentences)
        {
            int result = 0;
            for (int i = 0; i < sentences.Length; i++)
            {
                int _result = 1;
                for (int j = 0; j < sentences[i].Length; j++) if (sentences[i][j] == ' ') _result++;
                result = Math.Max(result, _result);
            }

            return result;
        }

        public int MostWordsFound2(string[] sentences)
        {
            return sentences.Select(s => s.Where(c => c == ' ').Count()).Max() + 1;
        }
    }
}
