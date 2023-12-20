using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2828
{
    public class Solution2828_api : Interface2828
    {
        public bool IsAcronym(IList<string> words, string s)
        {
            if (words.Count != s.Length) return false;

            return words.Select(s => s[0].ToString()).Aggregate((s1, s2) => $"{s1}{s2}") == s;
        }

        public bool IsAcronym2(IList<string> words, string s)
        {
            if (words.Count != s.Length) return false;

            return Enumerable.SequenceEqual(words.Select(s => s[0]), s);
        }
    }
}
