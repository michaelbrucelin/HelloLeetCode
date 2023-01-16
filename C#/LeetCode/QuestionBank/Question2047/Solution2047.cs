using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2047
{
    public class Solution2047 : Interface2047
    {
        public int CountValidWords(string sentence)
        {
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int result = 0;
            for (int i = 0; i < words.Length; i++) if (IsWord(words[i])) result++;

            return result;
        }

        public int CountValidWords2(string sentence)
        {
            return sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Where(s => IsWord(s))
                                .Count();
        }

        private bool IsWord(string token)
        {
            int len = token.Length;
            char c = token[len - 1];
            if (c == '!' || c == '.' || c == ',') len--;
            bool flag = false;
            for (int i = 0; i < len; i++)
            {
                c = token[i];
                if (char.IsDigit(c) || c == '!' || c == '.' || c == ',') return false;
                if (c == '-')
                {
                    if (flag) return false;
                    if (i == 0 || i == len - 1 || !char.IsLower(token[i - 1]) || !char.IsLower(token[i + 1])) return false;
                    flag = true;
                }
            }

            return true;
        }
    }
}
