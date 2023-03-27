using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2108
{
    public class Solution2108_api : Interface2108
    {
        public string FirstPalindrome(string[] words)
        {
            return words.FirstOrDefault(s => Enumerable.Range(0, s.Length >> 1)
                                                       .All(i => s[i] == s[s.Length - i - 1]), "");
        }
    }
}
