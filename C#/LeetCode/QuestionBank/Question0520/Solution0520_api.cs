using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0520
{
    public class Solution0520_api : Interface0520
    {
        public bool DetectCapitalUse(string word)
        {
            if (word.Length == 1) return true;

            return Regex.IsMatch(word, @"^([a-z]+|[A-Z]+|[A-Z][a-z]*)$");
        }
    }
}
