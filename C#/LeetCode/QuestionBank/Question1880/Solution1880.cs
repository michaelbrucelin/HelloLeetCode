using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1880
{
    public class Solution1880 : Interface1880
    {
        public bool IsSumEqual(string firstWord, string secondWord, string targetWord)
        {
            return ToInt(targetWord) == ToInt(firstWord) + ToInt(secondWord);
        }

        private int ToInt(string word)
        {
            int result = 0;
            for (int i = 0; i < word.Length; i++)
                result = result * 10 + word[i] - 'a';

            return result;
        }
    }
}
