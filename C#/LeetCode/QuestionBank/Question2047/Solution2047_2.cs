using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2047
{
    public class Solution2047_2 : Interface2047
    {
        public int CountValidWords(string sentence)
        {
            return sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Where(s => Regex.IsMatch(s, @"^[a-z]*([a-z]-[a-z])?[a-z]*[!.,]?$"))
                                .Count();
        }
    }
}
